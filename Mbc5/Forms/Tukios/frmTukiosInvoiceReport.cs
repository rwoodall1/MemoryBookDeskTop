using BaseClass;
using BaseClass.Classes;
using BindingModels;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace Mbc5.Forms.Tukios
{
    public partial class frmTukiosInvoiceReport : BaseClass.frmBase
    {
        public frmTukiosInvoiceReport(UserPrincipal userPrincipal, frmMain parent) : base(new string[] { "SA", "Administrator", "MixBook" }, userPrincipal)
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
            //frmMain.TukiosCleanShipping(); //takes out shipping value that are not for Tukios. Need method created to remove this if we go to memorybook.
            var sqlClient = new SQLCustomClient();
            string cmd = @"Select T.ClientOrderId
                        ,T.Invno
                        ,T.TukiosOrderStatus As Status
                        ,T.OrderReceivedDate
                        ,T.RequestedShipDate
                        ,T.DateShipped
                        ,T.BookId
                        ,T.ItemCode
                        ,T.Description
                        ,T.Pages
                        ,T.Copies
                        ,T.Weight
                        ,T.ShipMethod
                        ,T.ShipName
                        ,T.ShipState
                        ,T.ShipZip
                        ,''''+ Convert(VARCHAR, T.TrackingNumber) AS TrackingNumber
                        ,TS.Cost As Freight
                        ,TP.SellPrice As UnitPrice 
                        ,TP.SellPrice * T.Copies AS UnitTotal
                        ,TP.PerPage * (T.Pages * T.Copies )AS PageFee
                        ,TP.HandlingPerBox AS Fulfillment
                        ,(TP.SellPrice * T.Copies)+(TP.PerPage * (T.Pages * T.Copies ))+(TP.HandlingPerBox) AS Total
                        FROM TukiosOrder T INNER JOIN TukiosPricing TP ON T.ItemCode=TP.ItemCode
                        Left Join TukiosShipping TS On T.ClientOrderId=TS.ClientOrderId
                        Where T.TukiosOrderStatus='Shipped' and (OrderReprint=0 OR OrderReprint IS NULL) and (Invoiced IS NULL OR Invoiced =0) 
                          AND (T.DateShipped >= @DateFrom And T.DateShipped <= @DateTo)
                            Order By DateShipped,Invno";

            sqlClient.CommandText(cmd);
            var from = dtFrom.Value.Date;
            var to = dtTo.Value.Date.AddDays(1);
            sqlClient.AddParameter("@DateFrom", dtFrom.Value.Date);
            sqlClient.AddParameter("@DateTo", dtTo.Value.Date.AddDays(1));

            var reportResult = sqlClient.SelectMany<TukiosInvoiceReport>();
            if (reportResult.IsError)
            {
                MbcMessageBox.Error(reportResult.Errors[0].DeveloperMessage);
                return;
            }
            if (reportResult.Data == null)
            {
                MbcMessageBox.Information("No records were returned.");
                return;
            }
            var data = (List<TukiosInvoiceReport>)reportResult.Data;
            sqlClient.ClearParameters();
            cmd = @"Select T.ClientOrderId
,T.Invno
,TukiosOrderStatus As Status
,T.OrderReceivedDate
,T.DateShipped
,T.ItemCode
,T.BookId
,T.Description
,T.Pages
,T.Copies
,T.Weight
,T.ShipMethod
,T.ShipName
,T.ShipState
,T.ShipZip
,''''+ Convert(VARCHAR, T.TrackingNumber) AS TrackingNumber
,TS.Cost As Freight
,TP.SellPrice As UnitPrice 
,TP.SellPrice * T.Copies AS UnitTotal
,TP.PerPage * (T.Pages * T.Copies )AS PageFee
,TP.HandlingPerBox AS Fulfillment
,(TP.SellPrice * T.Copies)+(TP.PerPage * (T.Pages * T.Copies ))+(TP.HandlingPerBox) AS Total
FROM TukiosOrder T INNER JOIN TukiosPricing TP ON T.ItemCode=TP.ItemCode
Left Join TukiosShipping TS ON T.ClientOrderId=TS.ClientOrderId
Where (T.Invoiced IS NULL OR T.Invoiced =0) and T.Invno IN(Select Invno from WipDetail where Invno=T.invno) AND T.TukiosOrderStatus ='Cancelled' ";
            sqlClient.CommandText(cmd);
            var cancelledDataResult = sqlClient.SelectMany<TukiosInvoiceReport>();
            if (cancelledDataResult.IsError)
            {
                MbcMessageBox.Error(cancelledDataResult.Errors[0].DeveloperMessage);
                return;
            }
            if (cancelledDataResult.Data != null)
            {

                var cancelledData = (List<TukiosInvoiceReport>)cancelledDataResult.Data;
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
            var data = (List<TukiosInvoiceReport>)bsData.List;
            if (data == null || data.Count == 0)
            {
                MbcMessageBox.Hand("There are no records to mark invoice.", "No Records To Process");
                return;
            }
            bool updateErrors = false;
            var sqlClient = new SQLCustomClient();
            string cmd = @"Update tukiosOrder Set Invoiced=1,InvoiceDate=GETDATE() Where Invno =@Invno";
            sqlClient.CommandText(cmd);
            foreach (TukiosInvoiceReport rec in data)
            {
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@Invno", rec.Invno);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    updateErrors = true;
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to mark records as invoiced invno(" + rec.Invno.ToString() + "):" + updateResult.Errors[0].DeveloperMessage);
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
        }

        private void frmMxInvoiceReport_Load(object sender, EventArgs e)
        {

        }
    }
}
