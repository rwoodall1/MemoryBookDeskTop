﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BindingModels;
using BaseClass.Classes;
using BaseClass;
using BaseClass.Core;
using Microsoft.Reporting.WinForms;
using System.IO;
using Mbc5.Classes;
using RESTModule;
using System.Threading.Tasks;
using Exceptionless;
using System.Configuration;
using System.Diagnostics;
using Mbc5.Dialogs;
using Equin.ApplicationFramework;

namespace Mbc5.Forms.MixBook
{
    public partial class frmMxBookShipping : BaseClass.frmBase
    {
        public frmMxBookShipping(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
            
        }
        public UserPrincipal ApplicationUser { get; set; }
        public MixBookBarScanModel MbxModel { get; set; }
        public MixbookNotification ShipNotification { get; set; } 
        public List<MixbookNotificationRequestShipment> Shipments { get; set; } = new List<MixbookNotificationRequestShipment>();
        public MixbookNotificationRequestShipment Shipment { get; set; }
        public List<MixBookItemScanModel> NotificationItems { get; set; } = new List<MixBookItemScanModel>();
        public List<MixBookItemScanModel> Items { get; set; } = new List<MixBookItemScanModel>();
        public bool Loading { get; set; } = true;
        public int Itemcount { get; set; } = 0;
        private void txtClientIdLookup_Leave(object sender, EventArgs e)
        {
          
            if (string.IsNullOrEmpty(txtClientIdLookup.Text)) {return; }
            var sqlQuery = new SQLCustomClient();
          
            string cmdText = @"
                            SELECT M.ShipName,M.MixbookOrderStatus,M.JobId,M.ClientOrderId,M.ShipMethod,SC.ShipName as ShippingMethodName,M.ProdInOrder
                                From MixBookOrder M 
                                Left Join ShipCarriers SC On M.ShipMethod=SC.ShipAlias
                          Where M.ClientOrderId=@ClientOrderId AND ProdInOrder IN(Select Max(ProdInOrder) from MixbookOrder where ClientOrderId=@ClientOrderId)";
            sqlQuery.CommandText(cmdText);
            int vClientId = 0;
            if(!int.TryParse(txtClientIdLookup.Text,out vClientId))
            {
                MbcMessageBox.Error("ClientId is not in proper format.");
            }
            sqlQuery.AddParameter("@ClientOrderId", vClientId);
            var result = sqlQuery.Select<MixBookBarScanModel>();
            if (result.IsError)
            {
                MessageBox.Show(result.Errors[0].DeveloperMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Error retrieving order for shipment:"+result.Errors[0].DeveloperMessage);
                return;
            }
            if (result.Data == null)
            {
                MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            MbxModel = (MixBookBarScanModel)result.Data;
            if (MbxModel.MixbookOrderStatus  != null && MbxModel.MixbookOrderStatus.Trim() == "Cancelled")
            {
                MbcMessageBox.Hand("This order has been cancelled, contact your supervisor", "Order Cancelled");
              
                return;
            }
           
            this.CreateShipment();
             txtDateTime.Text = DateTime.Now.ToString();
            lblShpName.Text = MbxModel.ShipName;
            lblShpMethod.Text = MbxModel.ShippingMethodName;
        }

        private void txtTrackingNo_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtTrackingNo, "");
            if (string.IsNullOrEmpty(txtTrackingNo.Text))
            {


                errorProvider1.SetError(txtTrackingNo, "Please enter a valid  tracking number.");
                e.Cancel = true;
            }else if (txtTrackingNo.Text.Length<10)
            {
                errorProvider1.SetError(txtTrackingNo, "Please enter a valid tracking number.");
                e.Cancel = true;
            }
            else
            {
                try
                {
                    string vTracking = txtTrackingNo.Text.Trim();
                    if (MbxModel.ShipMethod.Trim() == "MX_MI")
                    {
                       txtTrackingNo.Text = vTracking.Substring(8, 26);
                    }
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error("Error trimming Mail Innovations tracking number. Please rescan or contact your supervisor.");
                    Log.Error(ex, "Error trimming Mail Innovations tracking number.");
                }
               

            }
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
        }

        private void txtWeight_Leave(object sender, EventArgs e)
        {
                txtItemBarcode.Focus();
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
                if (Company == "MXB")
                {
                    //expecting MXB1111111YB

                    vInvno = txtItemBarcode.Text.Substring(3, txtItemBarcode.Text.Length - 5);

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
                var checkscanResult = Items.Find(x => x.Invno == parsedInvno);
                if (checkscanResult !=null)
                {
                    MbcMessageBox.Information("This item is already in the shipment, scan another Item.");
                    return;
                }



                var sqlQuery = new SQLCustomClient();
                string cmdText = @"
                            SELECT M.ClientOrderId,M.ItemId,M.JobId,M.Invno,M.Copies As Quantity,M.Description
                                From MixBookOrder M 
                                Where M.Invno=@Invno";
                sqlQuery.CommandText(cmdText);
                sqlQuery.AddParameter("@Invno", parsedInvno);
                var result = sqlQuery.Select<MixBookItemScanModel>();
                
                if (result.IsError)
                {
                    MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error(result.Errors[0].DeveloperMessage);
                    return;
                }
                if (result.Data == null)
                {
                    MbcMessageBox.Error("Record not found");
                    txtItemBarcode.Tag = "Cancel";
                    return;
                }
                var vItem = (MixBookItemScanModel)result.Data;
                if (string.IsNullOrEmpty(Shipment.Package[0].Item.identifier))
                {
                    Shipment.Package[0].Item.identifier = vItem.ItemId;
                    Shipment.Package[0].Item.quantity = vItem.Quantity;
                }
                else
                {
                    var vPkg = new MixbookNotificationRequestShipmentPackage() {Item=new MixbookNotificationRequestShipmentPackageItem() };
                    vPkg.Item.identifier = vItem.ItemId;
                    vPkg.Item.quantity = vItem.Quantity;
                   Shipment.Package.Add(vPkg);
                }
           
                var singleItem = NotificationItems.Exists(item => item.Invno == vItem.Invno);
                Items.Add(vItem);
                NotificationItems.Add(vItem);
                if (!singleItem)
                {
                    this.Itemcount += 1;
                }
                
                BindingListView<MixBookItemScanModel> Items1 = new BindingListView<MixBookItemScanModel>(Items);
                bsItems.DataSource = Items1;
                custDataGridView.DataSource=bsItems;
                txtItemBarcode.Text = "";
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error("An error has occured:" + ex.Message);
                Log.Error("An error has occured:" + ex.Message);
            }

         }

        private void btnShip_Click(object sender, EventArgs e)
        {

            if (Itemcount != MbxModel.ProdInOrder)
            {
                MbcMessageBox.Error("You have " + Itemcount.ToString() + " items in the shipments but the order has " + MbxModel.ProdInOrder.ToString() + " items. ");
                return;
            }
         
            Shipment.trackingNumber = txtTrackingNo.Text;
            decimal vWeight = 0;
            decimal.TryParse(txtWeight.Text, out vWeight);
            Shipment.weight = vWeight;
            Shipment.shippedAt = DateTime.Now;
            Shipment.method = MbxModel.ShipMethod;
            

          UpdateShippingWip();
            Items.Clear();
            
           
          
            this.ShipNotification.Request.Shipment.Add(this.Shipment);
            var result = NotifyMixbookOfShipment();
            btnShipmentReset_Click(null, null);

        }
        private void UpdateShippingWip()
        {
            var sqlClient = new SQLCustomClient();
            string vDeptCode = "40";
           string vWIR = "SH";
    
            foreach (var item in Items)
            {
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Update WIPDetail SET
                                    WAR= @WAR, WIR =@WIR WHERE Invno=@Invno AND DescripID=@DescripID ");
                sqlClient.AddParameter("@Invno",item.Invno);
                sqlClient.AddParameter("@DescripID", vDeptCode);
                sqlClient.AddParameter("@WAR", DateTime.Now);
                sqlClient.AddParameter("@WIR", vWIR);
                sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                var mxResult4 = sqlClient.Update();
                if (mxResult4.IsError)
                {
                   
                    Log.Error("Failed to update shipping WIP:"+mxResult4.Errors[0].DeveloperMessage);
                MessageBox.Show("Failed to update shipping WIP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
                sqlClient.ClearParameters();
                sqlClient.ReturnSqlIdentityId(true);
                sqlClient.AddParameter("@Invno", item.Invno);
                sqlClient.AddParameter("@DescripID", vDeptCode);
                sqlClient.AddParameter("@WAR", DateTime.Now);
                sqlClient.AddParameter("@WIR", vWIR);
                sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                    END
                                                    ");

                var result4 = sqlClient.Insert();
                if (result4.IsError)
                {
                    Log.Error("Failed to insert shipping WIP:"+result4.Errors[0].DeveloperMessage);
                    MessageBox.Show("Failed to insert shipping WIP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"UPDATE Produtn Set Shpdate=GETDATE() where Invno=@Invno");
                sqlClient.AddParameter("@Invno", item.Invno);

                var produtnResult = sqlClient.Update();
                if (produtnResult.IsError)
                {
                    Log.Error("Failed to update production ship date:" + produtnResult.Errors[0].DeveloperMessage);
                    MbcMessageBox.Error("Failed to update shipdate on production screen.");

                }
                sqlClient.ClearParameters();
               
                sqlClient.CommandText(@"UPDATE Mixbookorder Set TrackingNumber=@TrackingNumber + ISNULL(TrackingNumber,''),Weight=Weight+@Weight,MixbookOrderStatus='Shipped',DateShipped=GETDATE(),DateModified=GETDATE(),ModifiedBy='SYS' where Invno=@Invno");
                sqlClient.AddParameter("@Invno", item.Invno);
                sqlClient.AddParameter("@Weight",Shipment.weight);//ShipNotification.Request.Shipment[0].weight)
                string vTracking = txtTrackingNo.Text.Trim()+" | ";
                if (string.IsNullOrEmpty(vTracking))
                {
                    MbcMessageBox.Error("Tracking Number is missing.");
                    return;
                }
                  sqlClient.AddParameter("@TrackingNumber", vTracking);
                var trackingResult = sqlClient.Update();
                if (trackingResult.IsError)
                {
                    MbcMessageBox.Error("Failed to update tracking number in order screen.");
                    Log.Error("Failed to update tracking number in order screen:"+trackingResult.Errors[0].DeveloperMessage);
                }
            }
        }

        private void btnItemReset_Click(object sender, EventArgs e)
        {
            try
            {
              
                int start = NotificationItems.Count - Items.Count;
             if (NotificationItems.Count>0 && NotificationItems.Count>=Items.Count)
                {
                    NotificationItems.RemoveRange(start, Items.Count);
                }
              
               
                
                Items.Clear();
                BindingListView<MixBookItemScanModel> Items1 = new BindingListView<MixBookItemScanModel>(Items);
                bsItems.DataSource = Items1;
                custDataGridView.DataSource = bsItems;
                txtItemBarcode.Focus();
                Itemcount = 0;


            }
            catch(Exception ex) 
            {
                Log.Error(ex,"Error clearing shipment items");
                

            }


        }

        private void btnShipmentReset_Click(object sender, EventArgs e)
        {
         
            
            txtClientIdLookup.Text = "";
            txtTrackingNo.Text = "";
            txtWeight.Text = "";
            txtDateTime.Text = "";
            Itemcount = 0;
            CreateShipNotification();

            txtClientIdLookup.Focus();
            Items.Clear();
            NotificationItems.Clear();
            BindingListView<MixBookItemScanModel> Items1 = new BindingListView<MixBookItemScanModel>(Items);
            bsItems.DataSource = Items1;
            custDataGridView.DataSource = bsItems;
            CreateShipNotification();
            SetPanels();
        }
        private void plnTracking_Leave(object sender, EventArgs e)
        {
        
            if(string.IsNullOrEmpty(txtClientIdLookup.Text)&& string.IsNullOrEmpty(txtItemBarcode.Text)) { return; }
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
        private void frmMxBookShipping_Load(object sender, EventArgs e)
        {
            if (Loading)
            {
                Loading = false;
                this.CreateShipNotification();

            }
        }
        public async Task<ApiProcessingResult> NotifyMixbookOfShipment()
        {
            var processingResult = new ApiProcessingResult();
           

            ShipNotification.Request.identifier = MbxModel.JobId;//needs to be set with jobid should always have one element
            ShipNotification.Request.Status.occurredAt = DateTime.Now;
            ShipNotification.Request.Status.Value = "Shipped";
            var vReturnNotification = Serialize.ToXml(this.ShipNotification);

            var restServiceResult = await new RESTService().MakeRESTCall("POST", vReturnNotification);
            if (!restServiceResult.IsError)
            {
                if (restServiceResult.Data.APIResult.ToString().Contains("Success"))
                {
                    //if not set to notified scheduled task will try again
                    AddMbEventLog(MbxModel.JobId, "Shipped", "", vReturnNotification, true);
                }
                else
                {
                    AddMbEventLog(MbxModel.JobId, "Error", restServiceResult.Data.APIResult.ToString(), vReturnNotification, true);
                    var emailHelper = new EmailHelper();
                    emailHelper.SendEmail("Failed to notify mixbook of shipped order:"+ MbxModel.JobId, "randy.woodall@jostens.com", null, restServiceResult.Data.APIResult.ToString(), EmailType.System);
                }


            }
            else
            {
                AddMbEventLog(MbxModel.JobId, "Error", "", vReturnNotification, false);
                var emailHelper = new EmailHelper();
                emailHelper.SendEmail("Failed to notify mixbook of shipped order:"+MbxModel.JobId, "randy.woodall@jostens.com", null, restServiceResult.Errors[0].ErrorMessage, EmailType.System);

            }
            return processingResult;
        }
        public string AddMbEventLog(string jobId, string status, string note, string notificationXML, bool notified)
        {
            var retval = "0";
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Insert Into MixBookEventLog (JobId,DateCreated,ModifiedDate,StatusChangedTo,Notified,Note,NotificationXML) Values(@JobId,GetDate(),GETDATE(),@StatusChangedTo,@Notified,@Note,@NotificationXML)");
            sqlClient.AddParameter("@Jobid", jobId);
            sqlClient.AddParameter("@StatusChangedTo", status);
            sqlClient.AddParameter("@Notified", notified);
            sqlClient.AddParameter("@Note", note);
            sqlClient.AddParameter("@NotificationXML", notificationXML);
            var sqlResult = sqlClient.Insert();
            if (sqlResult.IsError)
            {
                Log.Error("AddMbEventLog failure:"+sqlResult.Errors[0].DeveloperMessage);
                
                var emailHelper = new EmailHelper();
                string vBody = "Failed to insert values JobId:" + jobId + " StatusChangedTo:" + status + " Notified:" + notified + " Note:" + note;
                emailHelper.SendEmail("Failed to notify item shipped", "randy.woodall@jostens.com", null, vBody, EmailType.System);
                return retval;
            }
            retval = sqlResult.Data;
            return retval;
        }
   
        private void CreateShipNotification()
        {
            ShipNotification = new MixbookNotification();
            txtDateTime.Text ="";
            ShipNotification.Request.Shipment.Clear();
            
            
        }
        private void CreateShipment()
        {
            this.Shipment = new MixbookNotificationRequestShipment();
            Shipment.Package = new List<MixbookNotificationRequestShipmentPackage>();
            var pkg = new MixbookNotificationRequestShipmentPackage();
            pkg.Item = new MixbookNotificationRequestShipmentPackageItem();
            try
            {
                Shipment.Package.Add(pkg);
            }
            catch (Exception ex) { Log.Error(ex); }
          

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
            if (Items.Count > 0)
            {
              
                UpdateShippingWip();

                Shipment.trackingNumber = txtTrackingNo.Text;
                
                decimal vWeight = 0;
                decimal.TryParse(txtWeight.Text, out vWeight);
                Shipment.weight = vWeight;
                Shipment.shippedAt = DateTime.Now;
                Shipment.method = MbxModel.ShipMethod;
                var tmpShipment = Shipment;
                this.ShipNotification.Request.Shipment.Add(tmpShipment);
                SetPanels();
                Items.Clear();
                BindingListView<MixBookItemScanModel> Items1 = new BindingListView<MixBookItemScanModel>(Items);
                bsItems.DataSource = Items1;
                custDataGridView.DataSource = bsItems;
                CreateShipment();
                txtTrackingNo.Focus();
            }
            else { MbcMessageBox.Error("Please scan items into the shipment."); }
        }
    }
}
