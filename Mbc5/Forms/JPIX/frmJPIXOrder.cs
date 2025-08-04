using BaseClass;
using BaseClass.Classes;
using BindingModels;
using Core;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;



namespace Mbc5.Forms.JPIX
{
    public partial class frmJPIXOrder : BaseClass.frmBase
    {
        public frmMain frmMain { get; set; }
        public frmJPIXOrder(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MixBook", "BARCODE", "MBLead", "MbcCs" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;

        }

        public UserPrincipal ApplicationUser { get; set; }

        private void frmJPIXOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsJPIXOrders.JPIXOrders' table. You can move, or remove it, as needed.
            frmMain = (frmMain)this.MdiParent;
            this.SetConnectionString();
            this.GetOrders();
        }
        private async void GetOrders()
        {
            //string path = "D:\\JPIX\\";
            string path = "\\\\sedsujpisl01\\Plant_Transfer\\JPIX\\Flyers\\";
            if (Directory.Exists(path))
            {
                System.IO.DirectoryInfo dir = new DirectoryInfo(path);
                var serializer = new XmlSerializer(typeof(JostensPIXFulfillmentRequests));
                foreach (FileInfo file in dir.GetFiles("*.xml"))
                {
                    string contents = File.ReadAllText(file.FullName);

                    try
                    {

                        var stringreader = new StringReader(contents);
                        JostensPIXFulfillmentRequests jpixOrders = (JostensPIXFulfillmentRequests)serializer.Deserialize(stringreader);

                        var result = await this.InsertOrders(jpixOrders);


                        await SetFoldersAndFiles(jpixOrders, file.Name);

                    }
                    catch (Exception ex)
                    {
                        MbcMessageBox.Error(ex.InnerException.Message, "Error reading XML");
                    }


                }


            }
            this.Fill();

        }
        private void Fill()
        {
            this.jPIXOrdersTableAdapter.Fill(this.dsJPIXOrders.JPIXOrders);
           
            this.lblRecCount.Text = jPIXOrdersBindingSource.Count.ToString() + " Records";


            if (jPIXOrdersBindingSource.Count == 0 || ((DataRowView)jPIXOrdersBindingSource.Current).Row.IsNull("Invno"))
            {
                this.Invno = 0;
                this.Schcode = "";
            }
            else
            {
                this.Invno = (int)((DataRowView)this.jPIXOrdersBindingSource.Current).Row["Invno"];
                this.Schcode = ((DataRowView)this.jPIXOrdersBindingSource.Current).Row["OracleCode"].ToString();
            }

        }

        private async Task<ApiProcessingResult> InsertOrders(JostensPIXFulfillmentRequests jpixOrders)
        {
            var processingResult = new ApiProcessingResult();
            var sqlClient = new SQLCustomClient().CommandText(@"Insert Into JPIXOrders
           (Document
           ,NeedsByDate
            ,ProjectedShipDate
           ,ProductType
           ,Quantity
           ,ShipToContact
           ,ShipToCustomerName
           ,ShipToAddress1
           ,ShipToAddress2
           ,ShipToCity
           ,ShipToStateOrProvince
           ,ShipToPostalCode
           ,ShipToCountry
           ,ShipToGroup
           ,Reference
           ,DateReceived
           ,OracleCode,RequestId,OrderStatus) Values(
            @Document
           ,@NeedsByDate
            ,@ProjectedShipDate
           ,@ProductType
           ,@Quantity
           ,@ShipToContact
           ,@ShipToCustomerName
           ,@ShipToAddress1
           ,@ShipToAddress2
           ,@ShipToCity
           ,@ShipToStateOrProvince
           ,@ShipToPostalCode
           ,@ShipToCountry
           ,@ShipToGroup
           ,@Reference
           ,@DateReceived
           ,@OracleCode,@RequestId,@OrderStatus)");


            foreach (var order in jpixOrders.JostensPIXOrder)
            {
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@Document", "\\\\sedsujpisl01\\workflow\\JPixFlyers\\Archive\\" + jpixOrders.RequestId + "\\" + order.JostensPIXOrderItem.Document);
                sqlClient.AddParameter("@NeedsByDate", order.JostensPIXOrderItem.DateNeedsByDate);
                sqlClient.AddParameter("@@ProjectedShipDate", order.JostensPIXOrderItem.DateNeedsByDate.AddDays(-4));
                sqlClient.AddParameter("@ProductType", order.JostensPIXOrderItem.ProductType);
                sqlClient.AddParameter("@Quantity", order.JostensPIXOrderItem.Quantity);
                sqlClient.AddParameter("@ShipToContact", order.JostensPIXOrderItem.ShipToContact);
                sqlClient.AddParameter("@ShipToCustomerName", order.JostensPIXOrderItem.ShipToCustomerName);
                sqlClient.AddParameter("@ShipToAddress1", order.JostensPIXOrderItem.ShipToAddress1);
                sqlClient.AddParameter("@ShipToAddress2", order.JostensPIXOrderItem.ShipToAddress2);
                sqlClient.AddParameter("@ShipToCity", order.JostensPIXOrderItem.ShipToCity);
                sqlClient.AddParameter("@ShipToStateOrProvince", order.JostensPIXOrderItem.ShipToStateOrProvince);
                sqlClient.AddParameter("@ShipToPostalCode", order.JostensPIXOrderItem.ShipToPostalCode);
                sqlClient.AddParameter("@ShipToCountry", order.JostensPIXOrderItem.ShipToCountry);
                sqlClient.AddParameter("@ShipToGroup", order.JostensPIXOrderItem.ShipToGroup);
                sqlClient.AddParameter("@Reference", order.JostensPIXOrderItem.Reference);
                sqlClient.AddParameter("@DateReceived", DateTime.Now);
                sqlClient.AddParameter("@OracleCode", order.JostensPIXOrderItem.SchoolCode);
                sqlClient.AddParameter("@OrderStatus", "Received");
                string DateId = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString();
                sqlClient.AddParameter("@RequestId", jpixOrders.RequestId + DateId);
                var result = sqlClient.Insert();
                if (result.IsError)
                {
                    Log.Error("Failed to insert record for JPXIX document:" + order.JostensPIXOrderItem.Document + " RequestId:" + jpixOrders.RequestId.ToString() + "Name:" + order.JostensPIXOrderItem.ShipToCustomerName + "|" + result.Errors[0].DeveloperMessage);
                    MbcMessageBox.Error("Failed to insert record for document:" + order.JostensPIXOrderItem.Document + " RequestId:" + jpixOrders.RequestId.ToString() + "Name:" + order.JostensPIXOrderItem.ShipToCustomerName + "|" + result.Errors[0].DeveloperMessage);
                }
                await InsertProduction(order, result.Data);

            }
            return processingResult;
        }

        private async Task<ApiProcessingResult> InsertProduction(JostensPIXFulfillmentRequestsJostensPIXOrder order, string invno)
        {
            var processingResult = new ApiProcessingResult();
            var sqlClient = new SQLCustomClient().CommandText(@"Insert INTO Produtn (Company,Contryear,OracleCode,Schcode,Invno,Prodno,NoCopies,KitRecvd,Prshpdte)
                                                                 Values(@Company,@Contryear,@OracleCode,@Schcode,@Invno,@Prodno,@NoCopies,@KitRecvd,@Prshpdte)");
            sqlClient.ClearParameters();
            // is actually oracle code
            sqlClient.AddParameter("@OracleCode", order.JostensPIXOrderItem.SchoolCode);
            sqlClient.AddParameter("@Invno", invno);
            sqlClient.AddParameter("@Schcode", "01");
            sqlClient.AddParameter("@Contryear", ConfigurationManager.AppSettings["Contryear"]);
            sqlClient.AddParameter("@Company", "JPX");
            sqlClient.AddParameter("@Prodno", "J" + invno.ToString());
            sqlClient.AddParameter("@NoCopies", order.JostensPIXOrderItem.Quantity);
            sqlClient.AddParameter("@KitRecvd", DateTime.Now);
            sqlClient.AddParameter("@Prshpdte", order.JostensPIXOrderItem.DateNeedsByDate);
            var insertResult = sqlClient.Insert();
            if (insertResult.IsError)
            {
                Log.Error("Failed to insert produtn record for JPIX document:" + order.JostensPIXOrderItem.Document + " Invno:" + invno.ToString() + "|" + insertResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to insert produtn record for document:" + order.JostensPIXOrderItem.Document + " Invno:" + invno.ToString() + "|" + insertResult.Errors[0].DeveloperMessage);
            }
            sqlClient.ClearParameters();
            sqlClient.CommandText(@"Insert INTO Wip (Schcode,OracleCode,Invno)
                                  Values(@Schcode,@OracleCode,@Invno)");
            sqlClient.AddParameter("@Schcode", "JPX");
            sqlClient.AddParameter("@OracleCode", order.JostensPIXOrderItem.SchoolCode);
            sqlClient.AddParameter("@Invno", invno);
            var wipResult = sqlClient.Insert();
            if (wipResult.IsError)
            {
                Log.Error("Failed to insert wip record for JPXIX document:" + order.JostensPIXOrderItem.Document + " Invno:" + invno.ToString() + "|" + insertResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to insert wip record for document:" + order.JostensPIXOrderItem.Document + " Invno:" + invno.ToString() + "|" + insertResult.Errors[0].DeveloperMessage);
            }
            return processingResult;
        }

        private async Task SetFoldersAndFiles(JostensPIXFulfillmentRequests jpixOrders, string xmlName)
        {
            // string dropPath = "D:\\JPIX\\";
            string dropPath = "\\\\sedsujpisl01\\Plant_Transfer\\JPIX\\Flyers\\";
            //string workpath = "D:\\JPIX\\Work\\";
            string workpath = " \\\\sedsujpisl01\\workflow\\_App-HotFolders\\Prinergy_Processing\\JPix\\Flatwork_Funnel_JPix\\";// isilon/printergy

            // string archivepath = "D:\\JPIX\\Archive\\";
            string archivepath = "\\\\sedsujpisl01\\workflow\\JPixFlyers\\Archive\\";
            string newFolder = archivepath + jpixOrders.RequestId.ToString();
            Directory.CreateDirectory(newFolder);
            foreach (var order in jpixOrders.JostensPIXOrder)
            {
                try
                {

                    string fileToCopy = dropPath + order.JostensPIXOrderItem.Document;
                    string destinationDirectory = workpath + order.JostensPIXOrderItem.Document;
                    File.Copy(fileToCopy, destinationDirectory, true);

                    File.Copy(fileToCopy, newFolder + "\\" + order.JostensPIXOrderItem.Document, true);
                    File.Delete(fileToCopy);

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error("Failed to copy file:" + order.JostensPIXOrderItem.Document + " RequestId:" + jpixOrders.RequestId.ToString() + "|" + ex.Message);
                    Log.Error(ex.Message);
                }

            }
            //moves xml file
            File.Copy(dropPath + xmlName, archivepath + jpixOrders.RequestId.ToString() + "\\" + xmlName, true);
            File.Delete(dropPath + xmlName);

        }



        private void jPIXOrdersDataGridView_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int _invno = (int)jPIXOrdersDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                frmJPIXOrderDetail frmJPIXOrderDetail = new frmJPIXOrderDetail(this.ApplicationUser, _invno);
                frmJPIXOrderDetail.MdiParent = this.MdiParent;
                frmJPIXOrderDetail.frmMain = this.frmMain;
                frmJPIXOrderDetail.Show();
            }
        }

        private void jPIXOrdersDataGridView_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            int _invno = (int)jPIXOrdersDataGridView.Rows[e.RowIndex].Cells[0].Value;
            frmJPIXOrderDetail frmJPIXOrderDetail = new frmJPIXOrderDetail(this.ApplicationUser, _invno);
            frmJPIXOrderDetail.MdiParent = this.MdiParent;
            frmJPIXOrderDetail.frmMain = this.frmMain;
            frmJPIXOrderDetail.Show();
        }

        private void btnPrntProd_Click(object sender, EventArgs e)
        {
            if (jPIXOrdersBindingSource.Count < 1)
            {
                return;
            }
            reportViewer1.LocalReport.DataSources.Clear();

            try
            {
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", jPIXOrdersBindingSource));

                reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.JPIXJobTicketQuery.rdlc";
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }
        private void SetRecordPrinted()
        {
            var sqlClient = new SQLCustomClient().CommandText(@"Update JPIXOrders Set PTicketPrinted = 1 Where Invno = @Invno");

            int _invno;
            foreach (DataRowView row in jPIXOrdersBindingSource)
            {
                sqlClient.ClearParameters();
                _invno = (int)row["Invno"];
                sqlClient.AddParameter("@Invno", _invno);
                var result = sqlClient.Update();
            }

            this.Fill();
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {



            try
            {

                if (reportViewer1.PrintDialog() != DialogResult.Cancel)
                {
                    this.SetRecordPrinted();
                }
            }
            catch (Exception ex)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("PrintJPIXJobTicketQuery" + ex.Message);
            }
        }
        private void SetConnectionString()
        {
            try
            {

                this.jPIXOrdersTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;


            }
            catch (Exception ex)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to set JPIX orders connection strings");

            }
        }

        private void jPIXOrdersDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (jPIXOrdersDataGridView.Rows[e.RowIndex].Cells[0].Value != null)
            {
                try
                {
                    this.Invno = (int)jPIXOrdersDataGridView.Rows[e.RowIndex].Cells[0].Value;
                    this.Schcode = jPIXOrdersDataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
                }
                catch (Exception ex)
                {

                }
            }



        }
    }
}
