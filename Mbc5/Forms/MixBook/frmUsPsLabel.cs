using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
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
using System.Drawing.Printing;
using System.IO;
using pitneyBower.Api;
using pitneyBower.Client;
using pitneyBower.Model;
using Configuration = pitneyBower.Client.Configuration;

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
        public UsPsBarScanReturn OrderInfo { get; set; }
        private SecurityToken SecurityToken { get; set; } = new SecurityToken();
        public string fileToPrint{get;set;}
        private void txtScan_Leave(object sender, EventArgs e)
        {
            this.pnlData.Visible = false;
            cmbPkgType.Items.Clear();
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
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Error retrieving order for shipment:" + result.Errors[0].DeveloperMessage);
                return;
            }
            if (result.Data == null)
            {
                MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            OrderInfo =(UsPsBarScanReturn) result.Data;
            LoadPackageCombo();
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
                MbcMessageBox.Hand("This order is not a USPS ship order", "Incorrect Carrier");
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
            
          GetLabel();
        }
        protected async Task<ApiProcessingResult> GetLabel()
        {
            var processingResult = new ApiProcessingResult();
            if (!ValidationCheck() || !this.ValidateChildren())
            {
                return processingResult;
            }
            if (SecurityToken == null || SecurityToken.Issued < DateTime.Now.AddHours(-9))
            {
                var tokenResult = await SetSecurityToken();
                if (tokenResult.IsError)
                {
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            // Have token print label
            ////https://stackoverflow.com/questions/20692697/how-to-print-a-document-using-c-sharp-code
            ////  https://docs.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-print-in-windows-forms-using-print-preview?view=netframeworkdesktop-4.8
                List<string> vaddressLines = new List<string>() { lblShipAddr.Text };
            if (!string.IsNullOrEmpty(lblShipAddr2.Text))
            {
                vaddressLines.Add(lblShipAddr2.Text);
            }
            Address fromAddress = new Address(name: "MixBook", residential: false, addressLines: new List<string>() { "2000 Broadway Street" }, company: "MixBook",
                countryCode: "US", cityTown: "Redwood", stateProvince: "CA", postalCode: "94063");
            Address toAddress = new Address(name: lblShipName.Text, phone: lblShipPhone.Text, cityTown: lblShipCity.Text, countryCode: "US", addressLines: vaddressLines,postalCode:lblShipZipCode.Text,
                        stateProvince: lblShipState.Text, residential: true);
            ParcelDimension parcelDimension = new ParcelDimension(height: decimal.Parse(txtHeight.Text),length: decimal.Parse(txtLength.Text),width: decimal.Parse(txtWidth.Text),unitOfMeasurement: UnitOfDimension.IN);
            ParcelWeight parcelWeight = new ParcelWeight(int.Parse(txtWeight.Text), rbOz.Checked ? UnitOfWeight.OZ : UnitOfWeight.LB);
            Parcel parcel = new Parcel(parcelDimension, parcelWeight);
            SpecialService specialService = new SpecialService(specialServiceId: "DelCon", inputParameters: new List<Parameter> { new Parameter("ADD_TO_MANIFEST", "true"), new Parameter("INPUT_VALUE", "0") });//this insures tracking
            Services vServiceId=Services.PM;
            if (OrderInfo.ServiceId=="PM")
            {
                vServiceId = Services.PM;
            }else if (OrderInfo.ServiceId == "FCM")
            {
                 vServiceId = Services.FCM;
            }
            PkgItem vParcelType1 = (PkgItem)cmbPkgType.SelectedItem;
            var value = vParcelType1.Value;
            ParcelType vParcelType = value;
            Rate rate=null;
            //if (OrderInfo.ServiceId == "PM")
            //{
                 rate = new Rate(inductionPostalCode: "65301", carrier: Carrier.USPS, serviceId: vServiceId, parcelType: vParcelType, specialServices: new List<SpecialService>() { specialService });
            //}
            //else if(OrderInfo.ServiceId == "FCM")
            //{
            //     rate = new Rate(inductionPostalCode: "65301", carrier: Carrier.USPS, serviceId: vServiceId, parcelType: vParcelType);
            //}

           

            Document document = new Document(type: "SHIPPING_LABEL", contentType: Document.ContentTypeEnum.BASE64, size: Document.SizeEnum._4X6, fileFormat: Document.FileFormatEnum.PNG, printDialogOption: Document.PrintDialogOptionEnum.NOPRINTDIALOG);
            List<Parameter> shipmentoption = null;
           
            shipmentoption = new List<Parameter> { new Parameter("SHIPPER_ID", ConfigurationManager.AppSettings["PitneybowesShipperId"].ToString()), new Parameter("HIDE_TOTAL_CARRIER_CHARGE", "true"), new Parameter("PRINT_CUSTOM_MESSAGE_1", "Order Number:" + OrderInfo.ClientOrderId), new Parameter("SHIPPING_LABEL_RECEIPT", "NO_OPTIONS") };
           
            var shipment = new Shipment(fromAddress: fromAddress, toAddress: toAddress, parcel: parcel, rates: new List<Rate>() { rate }, documents: new List<Document>() { document }, shipmentOptions: shipmentoption); 
            
            Configuration.Default.OAuthApiKey =ConfigurationManager.AppSettings["ZnWijtapGwb2pmRFj8FJbUGuTHQE0FEZ"];
            Configuration.Default.OAuthSecret = ConfigurationManager.AppSettings["vfjGPCc8STyvVt8C"];
            Configuration.Default.AccessToken = this.SecurityToken.Token;
            var apiInstance = new ShipmentApi(Configuration.Default);
            var xPBTransactionId = DateTime.Now.Millisecond.ToString();  // string | Required. A unique identifier for the transaction, up to 25 characters.
            var xPBUnifiedErrorStructure = true;  // bool? | Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional)  (default to true)
            var xPBIntegratorCarrierId = "";                                                                                                                                                                                                             // List<Header> vHeaders = new List<Header>() { new Header() { Key = "Accept", Value = "application/json" }, new Header() { Key = "X-PB-TransactionId", Value =DateTime.Now.Millisecond.ToString() },new Header() { Key = "X-PB-UnifiedErrorStructure", Value = "true" }, new Header() { Key = "X-PB-Integrator-CarrierId", Value = ConfigurationManager.AppSettings["PitneybowesShipperId"] }};

            try
            {
                Shipment result = apiInstance.CreateShipmentLabel(xPBTransactionId, shipment, xPBUnifiedErrorStructure, xPBIntegratorCarrierId);

                var printLabelResult = await PrintLabel(result);
                this.OrderInfo = null;
                this.pnlData.Visible = false;
                cmbPkgType.Items.Clear();
                return processingResult;
            }
            catch (ApiException e)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to Retrieve Label from Pitney:" +e.Message);
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve label from Pitney", "Failed to retrieve label from Pitney",""));
                MbcMessageBox.Error("Failed to retrieve label:" + e.Message);
                return processingResult;

            }

           
            
        }
        protected async Task<ApiProcessingResult> PrintLabel(Shipment model) {
            var processingResult = new ApiProcessingResult();
            //save label to disk
            string base64Label = model.Documents[0].Pages[0].Contents;//should only be one page for a label hardcode array
             fileToPrint = "c:\\temp\\" + OrderInfo.ClientOrderId + ".png";
            using (System.IO.FileStream stream = System.IO.File.Create(fileToPrint))
            {
                System.Byte[] byteArray = System.Convert.FromBase64String(base64Label);
                stream.Write(byteArray, 0, byteArray.Length);
            }
            //show dialog
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("4x6", 400, 600);
            printDoc.DocumentName = fileToPrint;
            printDialog1.Document = printDoc;
            printDialog1.AllowSelection = true;
            printDialog1.AllowSomePages = true;
            //if (printDialog1.ShowDialog() == DialogResult.OK)
            //{
                printDoc.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                printDoc.Print();
            //}
        
            return processingResult;

        }
        protected async Task<ApiProcessingResult> RePrintLabel(string clientOrderId)                                                                  
        {
            var processingResult = new ApiProcessingResult();

            fileToPrint = "c:\\temp\\" + clientOrderId + ".png";
            if (File.Exists(fileToPrint))
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.DefaultPageSettings.PaperSize = new PaperSize("4x6", 400, 600);
                printDoc.DocumentName = fileToPrint;
                printDialog1.Document = printDoc;
                printDialog1.AllowSelection = true;
                printDialog1.AllowSomePages = true;
                //if (printDialog1.ShowDialog() == DialogResult.OK)
                //{
                printDoc.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                printDoc.Print();
                //}
            }
            else
            {
                MbcMessageBox.Information("The label you want printed could not be found.");
                processingResult.IsError = true;
            }
            return processingResult; 

        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
        
            System.Drawing.Image img = Image.FromFile(fileToPrint);
            ev.Graphics.DrawImage(img,ev.PageBounds);
            
        }
        private void frmUsPsLabel_Load(object sender, EventArgs e)
        {
           

            SetSecurityToken();
        }
        protected async Task<ApiProcessingResult> SetSecurityToken()
        {
            var processResult = new ApiProcessingResult<bool>();
            this.SecurityToken = null;
            var tokenResult = new SQLCustomClient().CommandText("Select Token,Issued From PitneyBowesToken").Select<SecurityToken>();
            if (tokenResult.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(tokenResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to retrieve Security Token. Shipment can not be made. Contact your superviser.");
                processResult.IsError = true;
                
            }
            var tmpData= (SecurityToken)tokenResult.Data;
            if (tmpData==null||tmpData.Issued < DateTime.Now.AddHours(-9))
            {
                var dataBytes = System.Text.Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["PitneybowesApiKey"].ToString() + ":" + ConfigurationManager.AppSettings["PitneybowesApiSecret"].ToString());
                var dataString = System.Convert.ToBase64String(dataBytes);
                var vHeader = new Header() { Key = "Authorization", Value = "Basic " + dataString };
                var getTokenResult =await new RESTService(isPitney: true, token: dataString).MakeRESTCall(actionType: "POST", sentRequestData: "grant_type=client_credentials", headers:new List<Header>() {} ,vContentType: "application/x-www-form-urlencoded", vEndPoint: "https://shipping-api-sandbox.pitneybowes.com/oauth/token");
                if (getTokenResult.IsError || getTokenResult.Data == null || getTokenResult.Data.APIResult == null) { 
                
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(getTokenResult.Errors[0].DeveloperMessage);
                    MbcMessageBox.Error("Failed to retrieve Security Token. Shipment can not be made. Contact your superviser.");
                    processResult.IsError = true;
                    return processResult;
                };
                   
                this.SecurityToken = JsonConvert.DeserializeObject<SecurityToken>(getTokenResult.Data.APIResult);
                this.SecurityToken.Token = this.SecurityToken.access_token;
                this.SecurityToken.Issued = DateTime.Now;
                var updateResult = new SQLCustomClient().AddParameter("@Token",this.SecurityToken.access_token).CommandText("Update PitneyBowesToken Set Token=@Token,Issued=GetDate()").Update();
                if (updateResult.IsError)
                {
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update Token in Database:" + updateResult.Errors[0].DeveloperMessage);
                    //User will be able to use token  until form is closed. Do not stop
                }
                return processResult;
            }
            else
            {
                if (SecurityToken == null)
                {
                    this.SecurityToken = new SecurityToken();
                }
                this.SecurityToken.Token = tmpData.Token;
                this.SecurityToken.Issued = tmpData.Issued;
                return processResult;
            }

           
        }
        private bool ValidationCheck()
        {
            bool retval = true;
            errorProvider.Clear();
            if (string.IsNullOrEmpty(lblShipName.Text))
            {
                errorProvider.SetError(lblShipName, "Ship Name Required.");
                retval = false;
            }

            if (string.IsNullOrEmpty(lblShipAddr.Text))
            {
                errorProvider.SetError(lblShipAddr, "Address Required.");
                retval = false;
            }

            if (string.IsNullOrEmpty(lblShipCity.Text))
            {
                errorProvider.SetError(lblShipCity, "City Required.");
                retval = false;
            }

            if (string.IsNullOrEmpty(lblShipState.Text))
            {
                errorProvider.SetError(lblShipState, "State Required.");
                retval = false;
            }
            if (string.IsNullOrEmpty(lblShipZipCode.Text))
            {
                errorProvider.SetError(lblShipZipCode, "Zip Code Required.");
                retval = false;
            }
            try
            {
                if (cmbPkgType.SelectedItem==null|| cmbPkgType.SelectedItem.ToString()=="")
                {
                    errorProvider.SetError(cmbPkgType, "Package Type Required.");
                    retval = false;
                }
            }catch(Exception ex) { }
            if (string.IsNullOrEmpty(txtWeight.Text))
            {
                errorProvider.SetError(txtWeight, "Weight Required.");
                retval = false;
            }
            if (string.IsNullOrEmpty(txtWidth.Text))
            {
                errorProvider.SetError(txtWidth, "All Dimmensions Required.");
                retval = false;
            }
            if (string.IsNullOrEmpty(txtHeight.Text))
            {
                errorProvider.SetError(txtHeight, "All Dimmensions Required.");
                retval = false;
            }
            if (string.IsNullOrEmpty(txtLength.Text))
            {
                errorProvider.SetError(txtLength, "All Dimmensions Required.");
                retval = false;
            }
            if (OrderInfo.ShipMethod== "MX_USPS_FIRST_CLASS_PARCEL")
            {
                try
                {
                    if (decimal.Parse(txtLength.Text) > 15)
                {
                    errorProvider.SetError(txtLength, "Max length is 15.");
                    retval = false;
                }
                if (decimal.Parse(txtWidth.Text) > 18)
                {
                    errorProvider.SetError(txtWidth, "Max width is 18.");
                    retval = false;
                }
                if (decimal.Parse(txtHeight.Text) > 12)
                {
                    errorProvider.SetError(txtHeight, "Max height is 12.");
                    retval = false;
                }
            }catch (Exception ex) { retval = false; MbcMessageBox.Error("Data must be numberic"); }

        }
            if (cmbPkgType.Text.ToUpper()=="ENVELOPE")
            {
                try
                {
                    if (decimal.Parse(txtLength.Text) > 18)
                    {
                        errorProvider.SetError(txtLength, "Max length is 18.");
                        retval = false;
                    }
                    if (decimal.Parse(txtWidth.Text) > 18)
                    {
                        errorProvider.SetError(txtWidth, "Max width is 18.");
                        retval = false;
                    }
                    if (decimal.Parse(txtHeight.Text) > 2)
                    {
                        errorProvider.SetError(txtHeight, "Max height is 12.");
                        retval = false;
                    }
                }catch(Exception ex) { retval = false;MbcMessageBox.Error("Data must be numberic"); }

            }
            return retval;
        }
        private void btnReprint_Click(object sender, EventArgs e)
        {
            RePrintLabel(txtScan.Text);
        }
        protected async Task<ApiProcessingResult> CreateManifest()
        {
            var processingResult = new ApiProcessingResult();
            if (SecurityToken == null || SecurityToken.Issued < DateTime.Now.AddHours(-9))
            {
                var tokenResult = await SetSecurityToken();
                if (tokenResult.IsError)
                {
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            var vsubmissionDate = DateTime.Now.ToString("u").Substring(0,10);
            try
            {
                Configuration.Default.OAuthApiKey = ConfigurationManager.AppSettings["ZnWijtapGwb2pmRFj8FJbUGuTHQE0FEZ"];
                Configuration.Default.OAuthSecret = ConfigurationManager.AppSettings["vfjGPCc8STyvVt8C"];
                Configuration.Default.AccessToken = this.SecurityToken.Token;
                var xPBTransactionId = DateTime.Now.Millisecond.ToString();  // string | Required. A unique identifier for the transaction, up to 25 characters.
                var xPBUnifiedErrorStructure = true;  // bool? | Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional)  (default to true)
                var xPBIntegratorCarrierId = "";
                var apiInstance = new ManifestsApi(Configuration.Default);
                Address fromAddress = new Address(name: "MixBook", residential: false, addressLines: new List<string>() { "2000 Broadway Street" }, company: "MixBook",
                    countryCode: "US", cityTown: "Redwood", stateProvince: "CA", postalCode: "94063");

                var manifest = new Manifest(submissionDate: DateTime.Now.ToString("u").Substring(0, 10), fromAddress: fromAddress, parameters: new List<Parameter>() { new Parameter(name: "SHIPPER_ID", value: ConfigurationManager.AppSettings["PitneybowesShipperId"].ToString()) }, carrier: Manifest.CarrierEnum.USPS);

                var result = apiInstance.CreateManifest(xPBTransactionId: xPBTransactionId, manifest: manifest, xPBUnifiedErrorStructure: true);
               
                Process.Start(result.Documents[0].Contents);
            }
            catch(Exception ex) {
                if(ex.Message.Contains("No shipments are available to create a scanform/manifest document"))
                {
                    MbcMessageBox.Information("No shipments are available to create a scanform / manifest document");
                    processingResult.IsError = true;
                    return processingResult;
                }
                

            }
                return processingResult;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CreateManifest();
        }
        protected void LoadPackageCombo()
        {
            switch (OrderInfo.ServiceId)
            {
                case "PM":
                    PkgItem item = new PkgItem();
                    item.Text = "Package";
                    item.Value = ParcelType.PKG;
                    cmbPkgType.Items.Add(item);
                    PkgItem item1 = new PkgItem();
                    item1.Text = "Envelope";
                    item1.Value = ParcelType.SOFTPACK;
                    cmbPkgType.Items.Add(item1);
                    break;
                case "FCM":
                    PkgItem item11 = new PkgItem();
                    item11.Text = "Package";
                    item11.Value = ParcelType.PKG;
                    cmbPkgType.Items.Add(item11);
                    break;
            }
        }
        private void txtWidth_Validating(object sender, CancelEventArgs e)
        {
            decimal val = 0;
            errorProvider.Clear();
            if (!decimal.TryParse(txtWidth.Text, out val))
            {
                errorProvider.SetError(txtWidth, "Data must be numeric");
                e.Cancel = true;
            }
            if (val < 1)
            {
                errorProvider.SetError(txtWidth, "Width must be greater that 1 ");

                e.Cancel = true;
            }

        }
        private void txtLength_Validating(object sender, CancelEventArgs e)
        {
            decimal val = 0;
            errorProvider.Clear();
            if (!decimal.TryParse(txtLength.Text, out val))
            {
                if (val < 1)
                {
                    errorProvider.SetError(txtWidth, "Length must be greater that 1 ");
                  
                    e.Cancel = true;
                }
                errorProvider.SetError(txtLength, "Data must be numeric");
           
                e.Cancel = true;
            }
           ;
        }
        private void txtHeight_Validating(object sender, CancelEventArgs e)
        {
            decimal val = 0;
            errorProvider.Clear();
            if (!decimal.TryParse(txtHeight.Text, out val))
            {
                if (val < 0)
                {
                    errorProvider.SetError(txtHeight, "Height must be greater than 0");
                   
                    e.Cancel = true;
                }
                errorProvider.SetError(txtHeight, "Data must be numeric");
               
                e.Cancel = true;
            }
         
        }
        private void txtWeight_Validating(object sender, CancelEventArgs e)
        {
            decimal val = 0;
            errorProvider.Clear();
            if (!decimal.TryParse(txtWeight.Text, out val))
            {
                if (val < 0)
                {
                    errorProvider.SetError(txtWeight, "Weight must be greater that 1");
                  
                    e.Cancel = true;
                }
                errorProvider.SetError(txtWeight, "Data must be numeric");
             
                e.Cancel = true;
            }
            
        }
    }
    public class SecurityToken
    {
        public DateTime Issued { get; set; }
        public string Token { get; set; }
        public string access_token { get; set; }
        public string issuedAt { get; set; }
    }
    public class PkgItem
    {
        public string Text { get; set; }
        public ParcelType Value { get; set; }
        public override string ToString()
        {
          
            return Text;
        }
       
    }
}
