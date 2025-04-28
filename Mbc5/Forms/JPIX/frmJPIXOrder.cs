using BaseClass;
using BaseClass.Classes;
using BindingModels;
using Core;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mbc5.Forms.JPIX
{
    public partial class frmJPIXOrder : BaseClass.frmBase
    {
        public frmMain frmMain { get; set; }
        public frmJPIXOrder(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MixBook", "BARCODE", "MBLead" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }

        public UserPrincipal ApplicationUser { get; set; }

        private void frmJPIXOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsJPIXOrders.JPIXOrders' table. You can move, or remove it, as needed.

            this.GetOrders();
        }
        private async void GetOrders()
        {
            string path = "D:\\JPIX\\";
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

                    }


                }
                this.jPIXOrdersTableAdapter.Fill(this.dsJPIXOrders.JPIXOrders);
                this.lblRecCount.Text = jPIXOrdersBindingSource.Count.ToString() + " Records";

            }

        }

        private async Task<ApiProcessingResult> InsertOrders(JostensPIXFulfillmentRequests jpixOrders)
        {
            var processingResult = new ApiProcessingResult();
            var sqlClient = new SQLCustomClient().CommandText(@"Insert Into JPIXOrders
           (Document
           ,NeedsByDate
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
           ,OracleCode,RequestId) Values(
            @Document
           ,@NeedsByDate
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
           ,@OracleCode,@RequestId)");


            foreach (var order in jpixOrders.JostensPIXOrder)
            {
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@Document", "D:\\JPIX\\Archive\\" + jpixOrders.RequestId + "\\" + order.JostensPIXOrderItem.Document);
                sqlClient.AddParameter("@NeedsByDate", order.JostensPIXOrderItem.DateNeedsByDate);
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
                sqlClient.AddParameter("@RequestId", jpixOrders.RequestId);
                var result = sqlClient.Insert();
                if (result.IsError)
                {
                    Log.Error("Failed to insert record for JPXIX document:" + order.JostensPIXOrderItem.Document + " RequestId:" + jpixOrders.RequestId.ToString() + "|" + result.Errors[0].DeveloperMessage);
                    MbcMessageBox.Error("Failed to insert record for document:" + order.JostensPIXOrderItem.Document + " RequestId:" + jpixOrders.RequestId.ToString() + "|" + result.Errors[0].DeveloperMessage);
                }
                await InsertProduction(order, result.Data);

            }
            return processingResult;
        }

        private async Task<ApiProcessingResult> InsertProduction(JostensPIXFulfillmentRequestsJostensPIXOrder order, string invno)
        {
            var processingResult = new ApiProcessingResult();
            var sqlClient = new SQLCustomClient().CommandText(@"Insert INTO Produtn (Company,OracleCode,Invno,Prodno,NoCopies,KitRecvd,Prshpdte)
                                                                 Values(@Company,@OracleCode,@Invno,@Prodno,@NoCopies,@KitRecvd,@Prshpdte)");
            sqlClient.ClearParameters();
            // is actually oracle code
            sqlClient.AddParameter("@OracleCode", order.JostensPIXOrderItem.SchoolCode);
            sqlClient.AddParameter("@Invno", invno);
            sqlClient.AddParameter("@Company", "JPX");
            sqlClient.AddParameter("@Prodno", "J" + invno.ToString());
            sqlClient.AddParameter("@NoCopies", order.JostensPIXOrderItem.Quantity);
            sqlClient.AddParameter("@KitRecvd", DateTime.Now);
            sqlClient.AddParameter("@Prshpdte", order.JostensPIXOrderItem.DateNeedsByDate);
            var insertResult = sqlClient.Insert();
            if (insertResult.IsError)
            {
                Log.Error("Failed to insert produtn record for JPXIX document:" + order.JostensPIXOrderItem.Document + " Invno:" + invno.ToString() + "|" + insertResult.Errors[0].DeveloperMessage);
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
            string rootpath = "D:\\JPIX\\";
            string workpath = "D:\\JPIX\\Work\\";
            string archivepath = "D:\\JPIX\\Archive\\";
            string newFolder = archivepath + jpixOrders.RequestId.ToString();
            Directory.CreateDirectory(newFolder);
            foreach (var order in jpixOrders.JostensPIXOrder)
            {
                try
                {

                    string fileToCopy = rootpath + order.JostensPIXOrderItem.Document;
                    string destinationDirectory = workpath + order.JostensPIXOrderItem.Document;
                    File.Copy(fileToCopy, destinationDirectory, true);

                    File.Move(fileToCopy, newFolder + "\\" + order.JostensPIXOrderItem.Document);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }

            }
            //moves xml file
            File.Move(rootpath + xmlName, archivepath + jpixOrders.RequestId.ToString() + "\\" + xmlName);

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
    }
}
