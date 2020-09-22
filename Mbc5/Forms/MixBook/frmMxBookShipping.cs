using System;
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


namespace Mbc5.Forms.MixBook
{
    public partial class frmMxBookShipping : BaseClass.frmBase
    {
        public frmMxBookShipping(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
            bsItems.DataSource = Items;
        }
        public UserPrincipal ApplicationUser { get; set; }
        public MixBookBarScanModel MbxModel { get; set; }
        public MixbookNotification ShipNotification { get; set; }
        public List<MixBookItemScanModel> Items { get; set; } = new List<MixBookItemScanModel>();
        private void txtClientIdLookup_Leave(object sender, EventArgs e)
        {
            var sqlQuery = new SQLCustomClient();
            string cmdText = @"
                            SELECT M.ShipName,M.ProdInOrder,M.ClientOrderId,M.PrintergyFile,M.ItemId,M.JobId,M.Invno,M.Backing,M.ShipMethod,M.CoverPreviewUrl,M.BookPreviewUrl,M.Copies As Quantity
                                From MixBookOrder M 
                          Where M.ClientOrderId=@ClientOrderId";
            sqlQuery.CommandText(cmdText);
            sqlQuery.AddParameter("@ClientOrderId", txtClientIdLookup.Text);
            var result = sqlQuery.Select<MixBookBarScanModel>();
            if (result.IsError)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (result.Data == null)
            {
                MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            MbxModel = (MixBookBarScanModel)result.Data;
            ShipNotification = new MixbookNotification();
            ShipNotification.Request.Status.occurredAt = DateTime.Now;
            ShipNotification.Request.Shipment[0].shippedAt = DateTime.Now;
            txtDateTime.Text = DateTime.Now.ToString();
        }

        private void txtTrackingNo_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtTrackingNo, "");
            if (string.IsNullOrEmpty(txtTrackingNo.Text))
            {


                errorProvider1.SetError(txtTrackingNo, "Please enter a  tracking number.");
                e.Cancel = true;
            }
        }

        private void txtWeight_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtWeight, "");
            int vWeight = 0;
            if (!int.TryParse(txtWeight.Text, out vWeight) || vWeight == 0)
            {


                errorProvider1.SetError(txtWeight, "Please enter a  valid weight.");
                e.Cancel = true;
            }
        }

        private void txtWeight_Leave(object sender, EventArgs e)
        {
            plnTracking.Enabled = false;
            txtClientIdLookup.Enabled = false;
        }

        private void txtWeight_DoubleClick(object sender, EventArgs e)
        {
            plnTracking.Enabled = true;
            txtClientIdLookup.Enabled = true;
        }

        private void txtItemBarcode_Leave(object sender, EventArgs e)
        {
            lblLastScan.Text = txtItemBarcode.Text;
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
                        return;
                    }
                }

                int parsedInvno = 0;

                var parseResult = int.TryParse(vInvno, out parsedInvno);
                this.Invno = parsedInvno;
                if (!parseResult)
                {
                    MessageBox.Show("Invalid scan code");
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
                    return;
                }
                if (result.Data == null)
                {
                    MbcMessageBox.Error("Record not found");
                    return;
                }
                var vItem = (MixBookItemScanModel)result.Data;
                if (string.IsNullOrEmpty(ShipNotification.Request.Shipment[0].Package[0].Item.identifier))
                {
                    ShipNotification.Request.Shipment[0].Package[0].Item.identifier = vItem.ItemId;
                    ShipNotification.Request.Shipment[0].Package[0].Item.quantity = vItem.Quantity;
                }
                else
                {
                    var vPkg = new MixbookNotificationRequestShipmentPackage() {Item=new MixbookNotificationRequestShipmentPackageItem() };
                    vPkg.Item.identifier = vItem.ItemId;
                    vPkg.Item.quantity = vItem.Quantity;
                    ShipNotification.Request.Shipment[0].Package.Add(vPkg);
                }

                Items.Add(vItem);
             
                bsItems.DataSource = Items;
                custDataGridView.DataSource=bsItems;
              
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error("An error has occured:" + ex.Message);
            }




            }
    }
}
