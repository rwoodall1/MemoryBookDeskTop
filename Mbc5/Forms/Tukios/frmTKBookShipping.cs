using BaseClass;
using BaseClass.Classes;
using BaseClass.Core;
using BindingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mbc5.Forms.Tukios
{
    public partial class frmTKBookShipping : BaseClass.frmBase
    {
        public frmTKBookShipping(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;

        }
        public UserPrincipal ApplicationUser { get; set; }
        public TukiosBarScanModel TukModel { get; set; }
        public TukiosNotification ShipNotification { get; set; }
        public string ClientOrderId { get; set; }
        public Shipment Shipment { get; set; }
        public List<Package> Packages { get; set; } = new List<Package>();
        public Package CurrentPackage { get; set; }
        public bool Loading { get; set; } = true;

        public bool ByPassTrkValidation { get; set; } = false;
        private void txtClientIdLookup_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtClientIdLookup.Text)) { return; }
            this.btnShip.Enabled = true;
            var sqlQuery = new SQLCustomClient();

            string cmdText = @"
                            SELECT TO1.Invno,TO1.ShipName,TO1.TukiosOrderStatus,TO1.RequestedShipDate,TO1.BookType,TO1.ClientOrderId,'UPS' As ShipMethod,'GROUND SAVER' as ShippingMethodName,TO1.ProdInOrder
                                From TukiosOrder TO1 
                               Where TO1.ClientOrderId=@ClientOrderId AND ProdInOrder IN(Select Max(ProdInOrder) from TukiosOrder where ClientOrderId=@ClientOrderId)";
            sqlQuery.CommandText(cmdText);

            sqlQuery.AddParameter("@ClientOrderId", txtClientIdLookup.Text);
            var result = sqlQuery.Select<TukiosBarScanModel>();
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
            TukModel = (TukiosBarScanModel)result.Data;
            if (TukModel.TukiosOrderStatus != null && TukModel.TukiosOrderStatus.Trim() == "Cancelled")
            {
                MbcMessageBox.Hand("This order has been cancelled, contact your supervisor", "Order Cancelled");

                return;
            }
            if (TukModel.TukiosOrderStatus != null && TukModel.TukiosOrderStatus.Trim() == "Shipped")
            {
                MbcMessageBox.Hand("This order has been shipped, contact your supervisor", "Order Shipped");

                return;
            }
            if (TukModel.TukiosOrderStatus != null && TukModel.TukiosOrderStatus.Trim() == "Hold")
            {
                MbcMessageBox.Hand("This order is on Hold, contact your supervisor", "Order On Hold");

                return;
            }
            ClientOrderId = TukModel.ClientOrderId;
            txtDateTime.Text = DateTime.Now.ToString();
            lblShpName.Text = TukModel.ShipName;
            lblShpMethod.Text = TukModel.ShippingMethodName;

        }

        private void txtTrackingNo_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtTrackingNo, "");
            if (ByPassTrkValidation)
            {
                ByPassTrkValidation = false;
                txtTrackingNo.Text = "";
                txtClientIdLookup.Text = "";
                txtWeight.Text = "";
                return;
            }
            if (string.IsNullOrEmpty(txtTrackingNo.Text))
            {


                errorProvider1.SetError(txtTrackingNo, "Please enter a valid  tracking number.");
                e.Cancel = true;
            }
            //else if (txtTrackingNo.Text.Length < 10)
            //{
            //    errorProvider1.SetError(txtTrackingNo, "Please enter a valid tracking number.");
            //    e.Cancel = true;
            //    }

        }

        private void txtWeight_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtWeight, "");
            decimal vWeight = 0;
            if (!decimal.TryParse(txtWeight.Text, out vWeight) || vWeight == 0)
            {


                errorProvider1.SetError(txtWeight, "Please enter a  valid weight.");
                e.Cancel = true;
            }

            if (Shipment == null)
            {
                this.CreateShipment();
                CreatePackage();
            }
            else
            {
                UpdatePackage();
            }

            txtItemBarcode.Focus();
        }

        private void txtWeight_Leave(object sender, EventArgs e)
        {
            //if (Shipment == null)
            //{
            //    this.CreateShipment();
            //    CreatePackage();
            //}
            //else
            //{
            //    UpdatePackage();
            //}

            //txtItemBarcode.Focus();
        }

        private void txtWeight_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtItemBarcode_Leave(object sender, EventArgs e)
        {
            lblLastScan.Text = txtItemBarcode.Text;
            txtItemBarcode.Tag = "";
            string vInvno = "";



            try
            {
                if (string.IsNullOrEmpty(txtItemBarcode.Text))
                {

                    return;
                }
                var Company = txtItemBarcode.Text.ToUpper().Substring(0, 3);
                if (Company == "TUK")
                {
                    //expecting MXB1111111YB

                    vInvno = txtItemBarcode.Text.Replace("TUK", "").Replace("YB", "");

                }
                else
                {
                    if (txtItemBarcode.Text.Length == 12)
                    {
                        vInvno = txtItemBarcode.Text.Substring(4, txtItemBarcode.Text.Length - 6);
                    }
                    else if (txtItemBarcode.Text.Length == 11)
                    {
                        vInvno = txtItemBarcode.Text.Substring(4, txtItemBarcode.Text.Length - 4);
                    }

                    else
                    {
                        MbcMessageBox.Error("Scan code is not in correct format");
                        txtItemBarcode.Tag = "Cancel";
                        return;
                    }
                }

                int parsedInvno = 0;

                var parseResult = int.TryParse(vInvno, out parsedInvno);

                if (!parseResult)
                {
                    MessageBox.Show("Invalid scan code");
                    txtItemBarcode.Tag = "Cancel";

                    return;
                }
                //check that item scan matches clientidscan
                bool exists = Packages.Any(pkg => pkg.Items.Any(item => item.Invno == parsedInvno));
                if (exists)
                {
                    MbcMessageBox.Information("This item is already in the shipment, scan another Item.");
                    return;
                }
                var sqlQuery = new SQLCustomClient();
                string cmdText = @"
                            SELECT TO1.ClientOrderId,TO1.BookId As Identifier,TO1.Invno,TO1.Copies As Quantity,TO1.Description,TO1.BookType
                                From TukiosOrder TO1 
                                Where TO1.Invno=@Invno";
                sqlQuery.CommandText(cmdText);
                sqlQuery.AddParameter("@Invno", parsedInvno);
                var result = sqlQuery.Select<TItem>();

                if (result.IsError)
                {
                    MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(result.Errors[0].DeveloperMessage);
                    return;
                }
                if (result.Data == null)
                {
                    MbcMessageBox.Error("Record not found");
                    txtItemBarcode.Tag = "Cancel";
                    return;
                }
                var vItem = (TItem)result.Data;
                if (txtClientIdLookup.Text != vItem.ClientOrderId.ToString())
                {
                    MessageBox.Show("The scanned item was not found in the order. Check that you have scanned the correct packing list.");
                    txtItemBarcode.Tag = "Cancel";

                    return;
                }


                CreateItemAddToPkg(vItem);
                txtItemBarcode.Clear();




            }
            catch (Exception ex)
            {
                MbcMessageBox.Error("An error has occured:" + ex.Message);
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("An error has occured:" + ex.Message);
            }



        }

        private void btnShip_Click(object sender, EventArgs e)
        {
            this.btnShip.Enabled = false;

            foreach (var pkg in Shipment.Packages)
            {
                if (pkg.Items == null || pkg.Items.Count == 0)
                {
                    MbcMessageBox.Error("You have an invalid quantity (0) in a packages. Please Clear all shipments and rescan the order.");
                    return;
                }
            }
            int numProductsInOrder = Shipment.Packages
                .SelectMany(package => package.Items)
                .Select(item => item.Invno)
                .Distinct().Count();

            if (numProductsInOrder != TukModel.ProdInOrder)
            {
                MbcMessageBox.Error("You have " + numProductsInOrder.ToString() + " items in the shipments but the order has " + TukModel.ProdInOrder.ToString() + " items. Please Clear all shipments and rescan the order.");
                btnShip.Enabled = true;
                return;
            }
            //new
            // Get items in order and check
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Select Invno From TukiosOrder Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", TukModel.ClientOrderId);
            var vItems = new List<TItem>();
            var itemResult = sqlClient.SelectMany<TItem>();
            if (itemResult.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retrieve tukios items for item check:" + itemResult.Errors[0].DeveloperMessage);
            }
            else
            {
                vItems = (List<TItem>)itemResult.Data;


            }

            if (vItems.Count > 0)
            {
                foreach (var pkg in Shipment.Packages)
                {
                    foreach (var item in pkg.Items)
                    {
                        bool itemExist = vItems.Exists(x => x.Invno == item.Invno);
                        if (!itemExist)
                        {
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("item exist that does not belong to this order:" + TukModel.ClientOrderId + " Item Invno:" + item.Invno.ToString());
                            MbcMessageBox.Hand(@"An item exist that does not belong to this order. Click the Clear All Shipments and rescan order.(" + item.Invno.ToString() + ")", "Invalid Item");
                            return;

                        }
                    }
                }

                //end new
                SetTrackingNumber();
                UpdateTukiosShipmentJSON();

                ClearShipment();
                this.btnShip.Enabled = true;

                //this.Enabled = false;
                //timer1.Enabled = true;
                //bgWorker.RunWorkerAsync();



            }
            txtClientIdLookup.Select();
        }
        private void SetTrackingNumber()
        {
            var sqlClient = new SQLCustomClient();
            foreach (var pkg in Shipment.Packages)
            {
                foreach (var item in pkg.Items)
                {


                    
                   
                  
                    sqlClient.ClearParameters();

                    sqlClient.CommandText(@"UPDATE TukiosOrder  Set Weight = Coalesce(Weight,0)+@Weight
                                            ,TrackingNumber=@TrackingNumber + COALESCE(CONVERT(nvarchar(max),TrackingNumber),CONVERT(nvarchar(max),''))
                                           
                                            ,DateShipped=GETDATE()
                                            ,DateModified=GETDATE()
                                            ,ModifiedBy='SYS' where Invno=@Invno");
                    sqlClient.AddParameter("@Invno", item.Invno);
                    sqlClient.AddParameter("@Weight", pkg.Weight);
                    string vTracking = txtTrackingNo.Text.Trim() + " | ";
                    if (string.IsNullOrEmpty(vTracking))
                    {
                        MbcMessageBox.Error("Tracking Number is missing.");
                        return;
                    }
                    sqlClient.AddParameter("@TrackingNumber", vTracking);
                    var trackingResult = sqlClient.Update();
                    if (trackingResult.IsError)
                    {
                        MbcMessageBox.Error("Failed to update tukios tracking number in order screen.");
                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update tukios tracking number in order screen:" + trackingResult.Errors[0].DeveloperMessage);
                    }
                }
            }
        }

        private void btnItemReset_Click(object sender, EventArgs e)
        {

            CurrentPackage.Items.Clear();



            Shipment.Packages.Remove(CurrentPackage);
            Shipment.Packages.Add(CurrentPackage);//replace withnew
            bsItems.DataSource = null;
            bsItems.DataSource = CurrentPackage;
            bsItems.DataMember = "Items";
            custDataGridView.DataSource = bsItems;

        }

        private void btnShipmentReset_Click(object sender, EventArgs e)
        {
            ClearShipment();

        }
        private void plnTracking_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtClientIdLookup.Text) && string.IsNullOrEmpty(txtItemBarcode.Text)) { return; }
            if (this.Validate())
            {
                plnTracking.Enabled = false;
                pnlGrid.Enabled = true;
                txtItemBarcode.Focus();
            }
        }
        private void btnEnable_Click(object sender, EventArgs e)
        {
            SetPanels();


        }
        private void ClearShipment()
        {
            lblShpName.Text = "";
            lblShpMethod.Text = "";
            txtClientIdLookup.Clear();
            txtTrackingNo.Clear();
            txtWeight.Clear();
            Shipment.Packages.Clear();
            Shipment = null;
            CurrentPackage = null;
            bsItems.DataSource = null;

            custDataGridView.DataSource = bsItems;
            SetPanels();
        }

        //public string AddMbEventLog(string jobId, string status, string note, string notificationXML, bool notified)
        //{
        //    var retval = "0";
        //    var sqlClient = new SQLCustomClient();
        //    sqlClient.CommandText(@"Insert Into TukiosEventLog (DateCreated,ModifiedDate,StatusChangedTo,Notified,Note,NotificationJSON) Values(@JobId,GetDate(),GETDATE(),@StatusChangedTo,@Notified,@Note,@NotificationXML)");
        //    sqlClient.AddParameter("@Jobid", jobId);
        //    sqlClient.AddParameter("@StatusChangedTo", status);
        //    sqlClient.AddParameter("@Notified", notified);
        //    sqlClient.AddParameter("@Note", note);
        //    sqlClient.AddParameter("@NotificationJSON", notificationXML);
        //    var sqlResult = sqlClient.Insert();
        //    if (sqlResult.IsError)
        //    {
        //        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("AddMbEventLog failure:" + sqlResult.Errors[0].DeveloperMessage);

        //        var emailHelper = new EmailHelper();
        //        string vBody = "Failed to insert values JobId:" + jobId + " StatusChangedTo:" + status + " Notified:" + notified + " Note:" + note;
        //        emailHelper.SendEmail("Failed to notify item shipped", "randy.woodall@jostens.com", null, vBody, EmailType.System);
        //        return retval;
        //    }
        //    retval = sqlResult.Data;
        //    return retval;
        //}
        private void CreateShipment()
        {
            this.Shipment = null;
            Shipment = new Shipment();
            Shipment.Packages = this.Packages;
            Shipment.ShippedAt = DateTime.Now;
            Shipment.Method = TukModel.ShipMethod;

        }
        private void CreatePackage()
        {

            CurrentPackage = new Package()
            {
                Items = new List<TItem>(),
            };


            decimal vWeight = 0;
            decimal.TryParse(txtWeight.Text, out vWeight);
            CurrentPackage.Weight = vWeight;
            CurrentPackage.TrackingNumber = txtTrackingNo.Text;
            Shipment.Packages.Add(CurrentPackage);
            bsItems.DataSource = CurrentPackage;
            bsItems.DataMember = "Items";

        }
        private void UpdatePackage()
        {
            decimal vWeight = 0;
            decimal.TryParse(txtWeight.Text, out vWeight);
            CurrentPackage.Weight = vWeight;
            CurrentPackage.TrackingNumber = txtTrackingNo.Text;
            Shipment.Packages.Remove(CurrentPackage);
            Shipment.Packages.Add(CurrentPackage);
        }
        private void CreateItemAddToPkg(TItem item)
        {
            var _item = new TItem()
            {
                Invno = item.Invno,
                Quantity = item.Quantity,
                Description = item.Description,
                ClientOrderId = item.ClientOrderId,
                BookType = item.BookType,
                Identifier = item.Identifier,
            };
            Shipment.Packages.Remove(CurrentPackage);//clear out Package
            CurrentPackage.Items.Add(_item);

            Shipment.Packages.Add(CurrentPackage);//replace withnew
            bsItems.DataSource = null;
            bsItems.DataSource = CurrentPackage;
            bsItems.DataMember = "Items";
            custDataGridView.DataSource = bsItems;
            txtItemBarcode.Text = "";
        }






        private void CreateShipNotification()
        {
            ShipNotification = new TukiosNotification();



            ShipNotification.Request.Identifier = ClientOrderId;//neeeds to be set with ClientOrderId 
            ShipNotification.Request.Status.OccurredAt = DateTime.UtcNow;
            ShipNotification.Request.Status.StatusText = "Shipped";
            ShipNotification.Request.Status.Message = "";
            ShipNotification.Request.Shipment = new Shipment()
            {

                ShippedAt = DateTime.Now,
                Method = TukModel.ShipMethod,
                Packages = new List<Package>()
            };


        }




        private void txt1_Enter(object sender, EventArgs e)
        {
            txtItemBarcode.Focus();
        }
        private void SetPanels()
        {
            if (plnTracking.Enabled)
            {
                plnTracking.Enabled = false;
                pnlGrid.Enabled = true;
            }
            else
            {
                plnTracking.Enabled = true;
                pnlGrid.Enabled = false;
            }
        }
        private void plnTracking_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void txtItemBarcode_Validating(object sender, CancelEventArgs e)
        {
            if (txtItemBarcode.Tag == "Cancel")
            {
                e.Cancel = true;
            }
        }

        private void btnAddPkg_Click(object sender, EventArgs e)
        {
            var a = Packages;
            txtTrackingNo.Clear();
            txtWeight.Clear();
            txtItemBarcode.Clear();
            CreatePackage();
            SetPanels();
            plnTracking.Enabled = true;
            txtClientIdLookup.Enabled = false;


        }

        private void txtTrackingNo_Leave(object sender, EventArgs e)
        {
            if (ByPassTrkValidation)
            {
                return;
            }
            if (string.IsNullOrEmpty(txtTrackingNo.Text))
            {
                return;
            }
            if (TukModel == null)
            {
                MbcMessageBox.Hand("Rescan shipment barcode.", "Barcode");
                txtClientIdLookup.Focus();
                return;
            }
            //try
            //{
            //    string vTracking = txtTrackingNo.Text.Trim();
            //    if (TukModel.ShipMethod.Trim() == "MX_MI" && vTracking.Substring(0, 3) != "920" && vTracking.Substring(0, 3) != "924" && vTracking.Substring(0, 3) != "927")
            //    {
            //        txtTrackingNo.Text = vTracking.Substring(8);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MbcMessageBox.Error("Error trimming Mail Innovations tracking number. Please rescan or contact your supervisor.");
            //    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Error trimming Mail Innovations tracking number.(Tracking:" + txtTrackingNo.Text + " | clientid:" + this.TukModel.ClientOrderId.ToString());
            //    txtClientIdLookup.Focus();
            //    return;
            //}
            string vPartTrack = "";

            try
            {
                if (txtTrackingNo.Text.Trim().Length < 3)
                {
                    return;

                }
                vPartTrack = txtTrackingNo.Text.Trim().Substring(0, 3);
            }
            catch (Exception ex)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Value is not valid for subst:" + txtTrackingNo.Text);
                txtClientIdLookup.Focus();
                return;
            }
            //var upsList = new List<string>() { "MX_2DAY", "MX_OVERNIGHT_SAVER", "MX_MI_INT", "MX_INT_EXPRESS", "MX_INT_EXPEDITED", "MX_GROUND" };
            //var uspsList = new List<string>() { "MX_USPS_PRIORITY_CUBIC_3", "MX_USPS_PRIORITY_CUBIC_1", "MX_USPS_PRIORITY", "MX_USPS_PRIORITY_CUBIC_2", "MX_USPS_FIRST_CLASS_PARCEL", "USPS_GROUND_ADVANTAGE" };


            //if (vPartTrack.ToUpper() == "1ZR")//ups
            //{
            //    bool found = false;
            //    foreach (var a in upsList)
            //    {
            //        if (a == TukModel.ShipMethod.Trim())
            //        {
            //            found = true;
            //            break;
            //        }

            //    }

            //    if (!found)
            //    {

            //        MbcMessageBox.Hand("This tracking number is in the format of a UPS order but does not correspon with the shipping method. Check that shipping method is for UPS", "Tracking Number");
            //        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Tracking Number format (UPS) incorrect:" + txtTrackingNo.Text + " | clientid:" + this.TukModel.ClientOrderId.ToString());
            //    }

            //}
            //else if (vPartTrack == "924" || vPartTrack == "920" || vPartTrack == "927" || vPartTrack == "926")//mail innovations
            //{
            //    if (TukModel.ShipMethod.Trim() != "MX_MI")
            //    {
            //        MbcMessageBox.Hand("This tracking number is in the format of a Mail Innovations order but does not correspond with the shipping method. Check that shipping label is for Mail Innovations", "Tracking Number");
            //        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Tracking Number format (Mail Innovations) incorrect:" + txtTrackingNo.Text + " | clientid:" + this.TukModel.ClientOrderId.ToString());
            //    }


            //}
            //else if (vPartTrack == "420" || vPartTrack == "940" || vPartTrack == "943")//usps
            //{
            //    //First Class has 4201stClass as trk number. First Class does not get a trk number but we need one to pass validation
            //    bool found = false;
            //    foreach (var shipmethod in uspsList)
            //    {
            //        if (shipmethod == TukModel.ShipMethod.Trim())
            //        {
            //            found = true;
            //            break;
            //        }

            //    }

            //    if (!found)
            //    {

            //        MbcMessageBox.Hand("This tracking number is in the format of a USPS order but does not correspond with the shipping method. Check that shipping label is for USPS", "Tracking Number");
            //        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Tracking Number format (USPS) incorrect:" + txtTrackingNo.Text + " | clientid:" + this.TukModel.ClientOrderId.ToString());
            //    }

            //}
            //else
            //{
            //    MbcMessageBox.Error("Tracking Number format was not recognized, please scan tracking number again or contact your superviser. THIS MUST BE RESOLVED DO NOT IGNORE, YOU SHOULD NOT SEE THIS MESSAGE");
            //    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Tracking Number format not reconized:" + txtTrackingNo.Text + " | clientid:" + this.TukModel.ClientOrderId.ToString());
            //    return;
            //}

        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {


            //var result = NotifyMixbookOfShipment();
            //while (!bgWorker.CancellationPending && result.Result == null)
            //{

            //}
            //if (bgWorker.CancellationPending)
            //{
            //    e.Cancel = true;
            //    btnShipmentReset_Click(null, null);
            //}




        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.Enabled = true;
            //plnTracking.Enabled = false;//get in sync so it is true
            //timer1.Enabled = false;
            //btnShipmentReset_Click(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MbcMessageBox.Stop("Shipping Notification Failed,rescan package. If this continues notify supervisor.", "Nofification Error");
            //btnShipmentReset_Click(null, null);
            //bgWorker.CancelAsync();


        }

        private void txtItemBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItemBarcode_Enter(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtTrackingNo.Text))
            {
                MbcMessageBox.Hand("Tracking number is required", "Tracking Number");
                txtTrackingNo.Focus();
            }
        }

        private void txtTrackingNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ByPassTrkValidation = true;

            txtClientIdLookup.Focus();
        }

        public async Task<ApiProcessingResult> UpdateTukiosShipmentJSON()
        {
            var processingResult = new ApiProcessingResult();
            ShipNotification = new TukiosNotification();
            ShipNotification.Request.Identifier = TukModel.ClientOrderId;//neeeds to be set with ClientOrderId
            ShipNotification.Request.Status.StatusText = "Shipped";
            ShipNotification.Request.Status.OccurredAt = DateTime.Now;
            ShipNotification.Request.Status.ProjectedShipDate = TukModel.RequestedShipDate.ToShortDateString();
            this.Shipment.ShippedAt = DateTime.Now;
            this.Shipment.Method = TukModel.ShipMethod;
            ShipNotification.Request.Shipment = this.Shipment;
            string vReturnNotification = JsonSerializer.Serialize(this.ShipNotification);
            var sqlClient = new SQLCustomClient().CommandText(@"Update TukiosOrder Set ShipNotification=@ShipNotification Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ShipNotification", vReturnNotification);
            sqlClient.AddParameter("@ClientOrderId", TukModel.ClientOrderId);
            var sqlResult = sqlClient.Update();
            if (sqlResult.IsError)
            {
                MbcMessageBox.Error("Failed to update tukios order with ship notification.", "Error");
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update tukios order with ship notification:" + sqlResult.Errors[0].DeveloperMessage);
                processingResult.IsError = true;
                processingResult.Errors = sqlResult.Errors;
                return processingResult;
            }
            return processingResult;

            //    try
            //{

            //    string endpoint;
            //    if (TukModel.BookType.ToUpper() == "PHOTO")
            //    {
            //        endpoint = ConfigurationManager.AppSettings["TukiosEPPhoto"].ToString(); ;
            //    }
            //    else
            //    {
            //        endpoint = ConfigurationManager.AppSettings["TukiosEPFuneral"].ToString(); ;
            //    }
            //    string AccessKey = ConfigurationManager.AppSettings["TukiosApiKey"].ToString();
            //    string curDate = DateTime.UtcNow.ToString();
            //    string accessString = curDate + "|" + AccessKey;
            //    string headerValue = Encryptor.Encrypt(accessString, ConfigurationManager.AppSettings["TukiosPassPhrase"].ToString(), true);

            //    var headers = new List<RESTModule.Header>()
            //    {
            //        new RESTModule.Header()
            //        {
            //           Key="Authorize",
            //           Value=headerValue

            //        },

            //    };

            //    var restServiceResult = await new RESTService(endpoint).MakeRESTCall("POST", vReturnNotification, headers, null, "application/json");
            //    var response = JsonSerializer.Deserialize<TukiosResponse>(restServiceResult.Data.APIResult.ToString());
            //    if (!restServiceResult.IsError)
            //    {
            //        if (response.success == true)
            //        {
            //            //if not set to notified scheduled task will try again
            //            AddMbEventLog(TukModel.ClientOrderId, "Shipped", "", vReturnNotification, true);
            //        }
            //        else
            //        {
            //            string msg = restServiceResult.Data.APIResult.ToString();
            //            AddMbEventLog(TukModel.ClientOrderId, "Shippped ERROR 2", msg, vReturnNotification, false);
            //            var emailHelper = new EmailHelper();
            //            string emailmsg = msg;
            //            emailHelper.SendEmail("Failed to notify Tukios of shipped order:" + TukModel.Invno.ToString(), "randy.woodall@jostens.com", null, msg, EmailType.System);
            //            MbcMessageBox.Hand("Failed to notify Tukios of shipment, please rescan the item. If you don't succede place the package to the side and notify a supervisor.", "Error");
            //        }


            //    }
            //    else
            //    {
            //        AddMbEventLog(TukModel.ClientOrderId, "Shipped Error", "", vReturnNotification, false);
            //        var emailHelper = new EmailHelper();
            //        emailHelper.SendEmail("Failed to notify Tukios of shipped order:" + TukModel.ClientOrderId, "randy.woodall@jostens.com", null, restServiceResult.Errors[0].ErrorMessage, EmailType.System);
            //        MbcMessageBox.Hand("Failed to notify Tukios of shipment, please rescan the item. If you don't succede place the package to the side and notify a supervisor.", "Error");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.Error("Error notifying tukios of ClientOrderId " + TukModel.ClientOrderId + " shipment:" + ex.Message);
            //    MbcMessageBox.Error("Error notifying tukios of shipment:" + ex.Message);

            //}



        }


    }
}