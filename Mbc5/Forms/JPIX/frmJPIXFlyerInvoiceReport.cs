using BaseClass;
using BaseClass.Classes;
using BindingModels;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace Mbc5.Forms.MixBook
{
    public partial class frmJPIXFlyerInvoiceReport : BaseClass.frmBase
    {
        public frmJPIXFlyerInvoiceReport(UserPrincipal userPrincipal, frmMain parent) : base(new string[] { "SA", "Administrator", "JPIX" }, userPrincipal)
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
            string cmd = @"Select 
JO.Invno
,JO.Quantity
  ,JO.OrderStatus
,JO.DateReceived 
,JO.NeedsByDate
,JO.DateShipped
,JO.ProjectedShipDate
,JO.TrackingNumber
,JO.OracleCode
,JO.ProductType
,JO.RequestId
,JO.Reference
,JO.ShipToCustomerName
,JO.ShipToContact
,JO.ShipToAddress1
,JO.ShipToAddress2
,JO.ShipToCity
,JO.ShipToStateOrProvince
,JO.ShipToPostalCode
,JO.ShipToCountry
,JO.ShipToGroup
,''as ShipMethod
,Invoiced
,@ShipCost As ShipCost
,@UnitPrice As UnitPrice
,(@UnitPrice * Quantity) As LineItemTotal
,(@UnitPrice * Quantity + @ShipCost) AS Total
FROM JPIXOrders JO 
Where JO.OrderStatus='Shipped' AND (Invoiced IS NULL OR Invoiced =0)And (JO.DateShipped >= @DateFrom And JO.DateShipped <= @DateTo)  Order By DateShipped,Invno";

            sqlClient.CommandText(cmd);
            var from = dtFrom.Value.Date;
            var to = dtTo.Value.Date.AddDays(1);
            sqlClient.AddParameter("@DateFrom", dtFrom.Value.Date);
            sqlClient.AddParameter("@DateTo", dtTo.Value.Date.AddDays(1));
            sqlClient.AddParameter("@UnitPrice", .12m);
            sqlClient.AddParameter("@ShipCost", 0.00m);
            var reportResult = sqlClient.SelectMany<JPIXFlyerInvoiceReport>();
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
            var data = (List<JPIXFlyerInvoiceReport>)reportResult.Data;

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
            var data = (List<JPIXFlyerInvoiceReport>)bsData.List;
            if (data == null || data.Count == 0)
            {
                MbcMessageBox.Hand("There are no records to mark invoice.", "No Records To Process");
                return;
            }
            bool updateErrors = false;
            var sqlClient = new SQLCustomClient();
            string cmd = @"Update JPIXOrders Set Invoiced=1,InvoiceDate=GETDATE() Where Invno =@Invno";
            sqlClient.CommandText(cmd);
            foreach (JPIXFlyerInvoiceReport rec in data)
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
