using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass;
using BaseClass.Classes;
using BindingModels;
using System.Configuration;
using RESTModule;
using System.Threading.Tasks;
using BaseClass.Core;
using Newtonsoft.Json;
namespace Mbc5.Forms.MixBook
{
    public partial class frmUsPsLabel : BaseClass.frmBase
    {
        public frmUsPsLabel(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }

            public UserPrincipal ApplicationUser { get; set; }
            public UsPsBarScanReturn OrderInfo{get;set;}
            private SecurityToken SecurityToken { get; set; }
        private void txtScan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtScan.Text)) { return; }
            var sqlQuery = new SQLCustomClient();

            string cmdText = @"
                            SELECT M.ShipName,M.ShipAddr,M.ShipAddr2,M.ShipCity,M.ShipState,M.ShipZip,M.MixbookOrderStatus,M.JobId,M.ClientOrderId,M.ShipMethod,SC.ShipName as ShippingMethodName,SC.Carrier,SC.ServiceId,SC.PkgType,M.ProdInOrder
                                From MixBookOrder M 
                                Left Join ShipCarriers SC On M.ShipMethod=SC.ShipAlias
                          Where M.ClientOrderId=@ClientOrderId AND ProdInOrder IN(Select Max(ProdInOrder) from MixbookOrder where ClientOrderId=@ClientOrderId)";
            sqlQuery.CommandText(cmdText);
            int vClientId = 0;
            if (!int.TryParse(txtScan.Text, out vClientId))
            {
                MbcMessageBox.Error("ClientId is not in proper format.");
            }
            sqlQuery.AddParameter("@ClientOrderId", vClientId);
            var result = sqlQuery.Select<UsPsBarScanReturn>();
            if (result.IsError)
            {
                MessageBox.Show(result.Errors[0].DeveloperMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Error retrieving order for shipment:" + result.Errors[0].DeveloperMessage);
                return;
            }
            if (result.Data == null)
            {
                MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            OrderInfo =(UsPsBarScanReturn) result.Data;
            if (OrderInfo.MixbookOrderStatus != null && OrderInfo.MixbookOrderStatus.Trim() == "Cancelled")
            {
                MbcMessageBox.Hand("This order has been cancelled, contact your supervisor", "Order Cancelled");

                return;
            }
            if (OrderInfo.MixbookOrderStatus != null && OrderInfo.MixbookOrderStatus.Trim() == "Shipped")
            {
                MbcMessageBox.Hand("This order has been shipped, contact your supervisor", "Order Shipped");

                return;
            }
            if (OrderInfo.MixbookOrderStatus != null && OrderInfo.MixbookOrderStatus.Trim() == "Hold")
            {
                MbcMessageBox.Hand("This order is on Hold, contact your supervisor", "Order On Hold");

                return;
            }
            if(OrderInfo.Carrier != "USPS")
            {
                MbcMessageBox.Hand("This order is not a USPS ship order", "Order On Hold");
                return;
            }

            lblShipName.Text = OrderInfo.ShipName;
            lblShipAddr.Text = OrderInfo.ShipAddr;
            lblShipAddr2.Text = OrderInfo.ShipAddr2;
            lblShipCity.Text = OrderInfo.ShipCity;
            lblShipState.Text = OrderInfo.ShipState;
            lblShipZipCode.Text = OrderInfo.ShipZip;
            lblShpMethod.Text = OrderInfo.ShippingMethodName;
            pnlData.Visible = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ////https://stackoverflow.com/questions/20692697/how-to-print-a-document-using-c-sharp-code
            ////  https://docs.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-print-in-windows-forms-using-print-preview?view=netframeworkdesktop-4.8

            //if (SecurityToken.Issued < DateTime.Now.AddHours(-9))
            //{
            //    if (!SetSecurityToken())
            //    {
            //        return;
            //    }
            //}
            //List<string> vaddressLines = new List<string>() {lblShipAddr.Text };
            //if (!string.IsNullOrEmpty(lblShipAddr2.Text)){
            //    vaddressLines.Add(lblShipAddr2.Text);
            //}
            //Address fromAddress = new Address(name: "MixBook", residential: false, addressLines: new List<string>() { "2000 Broadway Street" }, company: "MixBook",
            //    countryCode:"US",cityTown:"Redwood",stateProvince:"CA",postalCode:"94063");
            
            //Address toAddress = new Address(name: lblShipName.Text, phone: lblShipPhone.Text, cityTown: lblShipCity.Text, countryCode: "US", addressLines: vaddressLines,
            //            stateProvince:lblShipState.Text,residential:true);

            //ParcelDimension parcelDimension = new ParcelDimension();
            //parcelDimension.Height = decimal.Parse(txtHeight.Text);
            //parcelDimension.Length = decimal.Parse(txtLength.Text);
            //parcelDimension.Width = decimal.Parse(txtWidth.Text);
            //parcelDimension.UnitOfMeasurement ="IN";

            //ParcelWeight parcelWeight = new ParcelWeight(int.Parse(txtWeight.Text),rbOz.Checked?rbOz.Text:rbLb.Text );

            //Parcel parcel = new Parcel(parcelDimension, parcelWeight);
            //SpecialService specialService = new SpecialService(specialServiceId: "DelCon", inputParameters: new List<Parameter> { new Parameter("INPUT_VALUE", "0") });//this insures tracking
            //Rate rate = new Rate(carrier:"USPS", serviceId:OrderInfo.ServiceId, parcelType:OrderInfo.PkgType, specialServices: new List<SpecialService>() { specialService });
            //Document document = new Document(type: "SHIPPING_LABEL", contentType: Document.ContentTypeEnum.BASE64, size: Document.SizeEnum.DOC_4X6, fileFormat: Document.FileFormatEnum.PDF, printDialogOption: Document.PrintDialogOptionEnum.NOPRINTDIALOG);
            //List<Parameter> shipmentoption = new List<Parameter> { new Parameter("SHIPPER_ID",ConfigurationManager.AppSettings["PitneybowesShipperId"].ToString()), new Parameter("ADD_TO_MANIFEST", "true"), new Parameter("HIDE_TOTAL_CARRIER_CHARGE", "true"), new Parameter("PRINT_CUSTOM_MESSAGE_1", "Order Number:"+OrderInfo.ClientOrderId), new Parameter("SHIPPING_LABEL_RECEIPT", "NO_OPTIONS") };
            //var shipment = new Shipment(fromAddress: fromAddress, toAddress: toAddress, parcel: parcel, rates: new List<Rate>() { rate }, documents: new List<Document>() { document }, shipmentOptions: shipmentoption); // Shipment | request
            //List<Header> vHeaders = new List<Header>() { new Header() { Key = "", Value = "" }, new Header() { Key = "", Value = "" }, new Header() { Key = "", Value = "" }, new Header() { Key = "", Value = "" }, new Header() { Key = "", Value = "" }, new Header() { Key = "", Value = "" } };
            //var creatShipResult=new RESTService().MakeRESTCall(actionType:"POST",sentRequestData:shipment,headers:)

        }

        private void frmUsPsLabel_Load(object sender, EventArgs e)
        {
           // SetSecurityToken();
        }
        protected async Task<ApiProcessingResult> SetSecurityToken()
        {
            var processResult = new ApiProcessingResult<bool>();
            this.SecurityToken = null;
            var tokenResult = new SQLCustomClient().CommandText("Select Token,Issued From PitneyBowesToken").Select<SecurityToken>();
            if (tokenResult.IsError)
            {
                Log.Error(tokenResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to retrieve Security Token. Shipment can not be made. Contact your superviser.");
                processResult.IsError = true;
                
            }
            var tmpData= (SecurityToken)tokenResult.Data;
            if (tmpData.Issued < DateTime.Now.AddHours(-9))
            {
                var dataBytes = System.Text.Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["PitneybowesApiKey"].ToString() + ":" + ConfigurationManager.AppSettings["PitneybowesApiSecret"].ToString());
                var dataString = System.Convert.ToBase64String(dataBytes);
                var vHeader = new Header() { Key = "Authorization", Value = "Basic " + dataString };
                var getTokenResult =await new RESTService(isPitney: true, token: dataString).MakeRESTCall(actionType: "POST", sentRequestData: "grant_type=client_credentials", headers:new List<Header>() { new Header() { Key = "Content-Type", Value = "application/x-www-form-urlencoded" } } , vEndPoint: "https://shipping-api-sandbox.pitneybowes.com/oauth/token");
                if (getTokenResult.IsError)
                {
                    Log.Error(getTokenResult.Errors[0].DeveloperMessage);
                    MbcMessageBox.Error("Failed to retrieve Security Token. Shipment can not be made. Contact your superviser.");
                    processResult.IsError = true;
                }
                   
                this.SecurityToken = JsonConvert.DeserializeObject<SecurityToken>(getTokenResult.Data.APIResult);
                 return processResult;
            }
            else
            {
                return processResult;
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test();
        }
        public async Task<ApiProcessingResult> Test()
        {
            var pr = new ApiProcessingResult();
            var dataBytes = System.Text.Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["PitneybowesApiKey"].ToString() + ":" + ConfigurationManager.AppSettings["PitneybowesApiSecret"].ToString());
            var dataString = System.Convert.ToBase64String(dataBytes);
            var vHeader = new Header() { Key = "Authorization", Value = dataString };
            var getTokenResult =await new RESTService(isPitney: true, token: dataString).MakeRESTCall(actionType: "POST", sentRequestData: "grant_type=client_credentials", vContentType: "application/x-www-form-urlencoded", vEndPoint: "https://shipping-api-sandbox.pitneybowes.com/oauth/token");
            try {
                var a = JsonConvert.DeserializeObject<SecurityToken>(getTokenResult.Data.APIResult);
                var b = a.issuedAt.Substring(0, a.issuedAt.Length-1);
                Int64 epochSeconds = Int64.Parse(b);
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochSeconds);
                DateTime testdate= dateTimeOffset.DateTime;


            } catch (Exception ex)
            {

            }
            
            
            return pr;
        }

    }
    public class SecurityToken
    {
        public DateTime Issued { get; set; }
        public string Token { get; set; }
        public string access_token { get; set; }
        public string issuedAt { get; set; }
    }
}
