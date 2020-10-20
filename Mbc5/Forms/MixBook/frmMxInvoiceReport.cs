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
            frmMain.CleanShipping(); //takes out shipping value that are not for mixbook. Need to remove this if we go to memorybook.
            var sqlClient = new SQLCustomClient();
                string cmd = @"Select M.ClientOrderId
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
                ,M.TrackingNumber
                ,MS.Cost As Freight
                ,MP.SellPrice As UnitPrice 
                ,MP.SellPrice * M.Copies AS UnitTotal
                ,MP.PerPage * M.Pages AS PageFee
                ,MP.HandlingPerBox AS Fulfillment
                ,(MP.SellPrice * M.Copies)+(MP.PerPage * M.Pages)+(MP.HandlingPerBox) AS Total
                FROM MixbookOrder M INNER JOIN MixBookPricing MP ON M.ItemCode=MP.ItemCode
                Left Join MixbookShipping MS ON M.ClientOrderId=MS.ClientOrderId
                Where M.MixbookOrderStatus='Shipped' And M.DateShipped>=@DateFrom And M.DateShipped<=@DateTo Order By DateShipped";
            sqlClient.CommandText(cmd);
            sqlClient.AddParameter("@DateFrom", dtFrom.Value);
            sqlClient.AddParameter("@DateTo", dtTo.Value);

            var reportResult = sqlClient.SelectMany<MixbookInvoiceReport>();
            if (reportResult.IsError)
            {
                MbcMessageBox.Error(reportResult.Errors[0].DeveloperMessage);
                return;
            }
            var data =(List< MixbookInvoiceReport>) reportResult.Data;
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
    }
}
