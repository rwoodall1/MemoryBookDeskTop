using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass;
using BaseClass.Core;
using BindingModels;
using CsvHelper;
using System.IO;
using System.Diagnostics;
namespace Mbc5.Forms.MixBook
{
    public partial class frmMxInvoiceReport : BaseClass.frmBase
    {
        public frmMxInvoiceReport(UserPrincipal userPrincipal,frmMain parent) : base(new string[] { "SA", "Administrator", "MixBook" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
            this.frmMain = parent;
        }
        public UserPrincipal ApplicationUser { get; set; }
        public frmMain frmMain { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            RunReport();
        }
        private void RunReport()
        {
            bsData.Clear();
            frmMain.CleanShipping(); //takes out shipping value that are not for mixbook. Need to remove this if we go to memorybook.
            var sqlClient = new SQLCustomClient();
                string cmd = @"Select M.ClientOrderId
                ,M.Invno
                ,MixbookOrderStatus   
                ,M.OrderReceivedDate
                ,M.RequestedShipDate
                ,M.DateShipped
                ,M.ItemCode
                ,M.ItemId
                ,M.Description
                ,M.Pages
                ,M.Copies
                ,M.Weight
                ,M.ShipMethod
                ,M.ShipName
                ,M.ShipState
                ,M.ShipZip
                ,''''+ Convert(VARCHAR, M.TrackingNumber) AS TrackingNumber
                ,MS.Cost As Freight
                ,MP.SellPrice As UnitPrice 
                ,MP.SellPrice * M.Copies AS UnitTotal
                ,MP.PerPage * (M.Pages * M.Copies )AS PageFee
                ,MP.HandlingPerBox AS Fulfillment
                ,(MP.SellPrice * M.Copies)+(MP.PerPage * (M.Pages * M.Copies ))+(MP.HandlingPerBox) AS Total
                FROM MixbookOrder M INNER JOIN MixBookPricing MP ON M.ItemCode=MP.ItemCode
                Left Join MixbookShipping MS ON M.ClientOrderId=MS.ClientOrderId
                Where M.MixbookOrderStatus='Shipped' and (Invoiced IS NULL OR Invoiced =0)And M.DateShipped >= @DateFrom And M.DateShipped <= @DateTo  Order By Invno,DateShipped";

            //
            //and Invoiced !=1
            sqlClient.CommandText(cmd);
            sqlClient.AddParameter("@DateFrom", dtFrom.Value);
            sqlClient.AddParameter("@DateTo", dtTo.Value);

            var reportResult = sqlClient.SelectMany<MixbookInvoiceReport>();
            if (reportResult.IsError)
            {
                MbcMessageBox.Error(reportResult.Errors[0].DeveloperMessage);
                return;
            }
            if (reportResult.Data==null)
            {
                MbcMessageBox.Information("No records were returned.");
                return;
            }
            var data =(List< MixbookInvoiceReport>) reportResult.Data;
            sqlClient.ClearParameters();
            cmd = @"Select M.ClientOrderId
                ,M.Invno
                ,MixbookOrderStatus   
                ,M.OrderReceivedDate
                ,M.DateShipped
                ,M.ItemCode
                ,M.ItemId
                ,M.Description
                ,M.Pages
                ,M.Copies
                ,M.Weight
                ,M.ShipMethod
                ,M.ShipName
                ,M.ShipState
                ,M.ShipZip
                ,''''+ Convert(VARCHAR, M.TrackingNumber) AS TrackingNumber
                ,MS.Cost As Freight
                ,MP.SellPrice As UnitPrice 
                ,MP.SellPrice * M.Copies AS UnitTotal
                ,MP.PerPage * (M.Pages * M.Copies )AS PageFee
                ,MP.HandlingPerBox AS Fulfillment
                ,(MP.SellPrice * M.Copies)+(MP.PerPage * (M.Pages * M.Copies ))+(MP.HandlingPerBox) AS Total
                FROM MixbookOrder M INNER JOIN MixBookPricing MP ON M.ItemCode=MP.ItemCode
                Left Join MixbookShipping MS ON M.ClientOrderId=MS.ClientOrderId
                Where (M.Invoiced IS NULL OR M.Invoiced =0) and M.Invno IN(Select Invno from WipDetail where Invno=M.invno) AND M.MixbookOrderStatus='Cancelled' ";
            sqlClient.CommandText(cmd);
            var cancelledDataResult = sqlClient.SelectMany<MixbookInvoiceReport>();
            if (cancelledDataResult.IsError)
            {
                MbcMessageBox.Error(cancelledDataResult.Errors[0].DeveloperMessage);
                return;
            }
            if (cancelledDataResult.Data != null)
            {
                
                var cancelledData = (List<MixbookInvoiceReport>)cancelledDataResult.Data;
                data.AddRange(cancelledData);
            }
            bsData.DataSource = data;
            lblRecords.Text = data.Count.ToString();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            var data = bsData.List;
            if (data == null || data.Count == 0)
            {
                MbcMessageBox.Hand("There are no records to print.", "No Records To Process");
                return;
            }
            try
            {
                saveFileDialog1.Filter = "Comma Seperated Value|*.csv";
                saveFileDialog1.ShowDialog();
                //using (var mem = new MemoryStream())
                using (var writer = new StreamWriter(saveFileDialog1.FileName))
                using (var csvWriter = new CsvWriter(writer))
                {
                    csvWriter.Configuration.Delimiter = ",";
                    //csvWriter.Configuration.HasHeaderRecord = true;
                    // csvWriter.Configuration.AutoMap<InqCountModel>();

                    //csvWriter.WriteHeader<InqCountModel>();
                    csvWriter.WriteRecords(data);

                    writer.Flush();

                    Process.Start(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error("Error creating file:" + ex.Message);
            }
        }

        private void btnMarkInvoiced_Click(object sender, EventArgs e)
        {
            var data =(List<MixbookInvoiceReport>) bsData.List;
            if (data==null || data.Count==0)
            {
                MbcMessageBox.Hand("There are no records to mark invoice.","No Records To Process");
                return;
            }
            bool updateErrors = false;
            var sqlClient = new SQLCustomClient();
        string cmd = @"Update MixbookOrder Set Invoiced=1,InvoiceDate=GETDATE() Where Invno =@Invno";
            sqlClient.CommandText(cmd);
            foreach (MixbookInvoiceReport rec in data)
            {
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@Invno",rec.Invno);
                var updateResult=sqlClient.Update();
                if (updateResult.IsError)
                {
                    updateErrors = true;
                    Log.Error("Failed to mark records as invoiced invno("+rec.Invno.ToString()+"):" + updateResult.Errors[0].DeveloperMessage);
                }
            }
                if (updateErrors)
            {
                MbcMessageBox.Error("Some records were not marked as invoice, check error logs for reason and which ones");
            }
            else
            {
                    MbcMessageBox.Exclamation("All records were successfully marked invoice.");
            }

           

            //bsData.Clear();
        }

        private void frmMxInvoiceReport_Load(object sender, EventArgs e)
        {

        }
    }
}
