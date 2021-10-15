using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass;
using System.Diagnostics;

namespace Mbc5.Forms.MixBook
{
    public partial class frmCoverSearch : BaseClass.frmBase
    {
        public frmCoverSearch(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        public UserPrincipal ApplicationUser { get; set; }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                return;
            }
            string vInvno = "";
            lblCoverLocationResult.Text = "";
            lblStatusData.Text ="";
           vInvno = txtBarcode.Text.Replace("MXB", "").Replace("YB", "").Replace("SC", "");
            //if (txtBarcode.Text.Length == 12)
            //{
            //    vInvno = txtBarcode.Text.Substring(4, txtBarcode.Text.Length - 6);
            //}
            //else if (txtBarcode.Text.Length == 11)
            //{
            //    vInvno = txtBarcode.Text.Substring(4, txtBarcode.Text.Length - 4);
            //}
            //else
            //{
            //    MbcMessageBox.Error("Scan code is not in correct format");
            //    return;
            //}

            var sqlClient = new SQLCustomClient().CommandText("Select CurrentCoverLoc,CoverPreviewUrl,MixbookOrderStatus From MixbookOrder Where Invno=@Invno ").AddParameter("@Invno", vInvno);
            var sqlResult = sqlClient.Select<CoverSearch>();
            if (sqlResult.IsError)
            {
                Log.Error("Failed to retrieve cover informaiton for Casein Search:" + sqlResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to retrieve cover informaiton for Casein Search:" + sqlResult.Errors[0].DeveloperMessage);
                return;
            }
            var vData = (CoverSearch)sqlResult.Data;
            lblCoverLocationResult.Text = string.IsNullOrEmpty(vData.CurrentCoverLoc) ? "Not Found" : vData.CurrentCoverLoc;
            lblStatusData.Text = vData.MixbookOrderStatus;
            if (!string.IsNullOrEmpty(vData.CoverPreviewUrl))
            {
                Process.Start(vData.CoverPreviewUrl);
            }
            txtBarcode.Text = "";

        }

        private void txtS_Enter(object sender, EventArgs e)
        {
            SelectNextControl(ActiveControl, true, true, true, true);
        }
    }
    public class CoverSearch
    {
        public string CurrentCoverLoc { get; set; }
        public string CoverPreviewUrl { get; set; }
        public string MixbookOrderStatus { get; set; }
    }
}
