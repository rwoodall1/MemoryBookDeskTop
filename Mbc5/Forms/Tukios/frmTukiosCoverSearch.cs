using BaseClass;
using BaseClass.Classes;
using System;
using System.Diagnostics;

namespace Mbc5.Forms.Tukios
{
    public partial class frmTukiosCoverSearch : BaseClass.frmBase
    {
        public frmTukiosCoverSearch(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
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
            lblStatusData.Text = "";
            vInvno = txtBarcode.Text.Replace("TUK", "").Replace("YB", "").Replace("SC", "");

            var sqlClient = new SQLCustomClient().CommandText("Select CurrentCoverLoc,CoverURL,TukiosOrderStatus From TukiosOrder Where Invno=@Invno ").AddParameter("@Invno", vInvno);
            var sqlResult = sqlClient.Select<TukiosCoverSearch>();
            if (sqlResult.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retrieve cover informaiton for Cover Search:" + sqlResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to retrieve cover informaiton for Cover Search:" + sqlResult.Errors[0].DeveloperMessage);
                return;
            }
            var vData = (TukiosCoverSearch)sqlResult.Data;
            lblCoverLocationResult.Text = string.IsNullOrEmpty(vData.CurrentCoverLoc) ? "Not Found" : vData.CurrentCoverLoc;
            lblStatusData.Text = vData.TukiosOrderStatus;
            if (vData.TukiosOrderStatus.ToUpper() == "SHIPPED" || vData.TukiosOrderStatus.ToUpper() == "CANCELLED")
            {
                MbcMessageBox.Information("This order has been " + vData.TukiosOrderStatus.ToUpper());
            }
            if (!string.IsNullOrEmpty(vData.CoverURL))
            {
                Process.Start(vData.CoverURL);
            }
            txtBarcode.Text = "";

        }

        private void txtS_Enter(object sender, EventArgs e)
        {
            SelectNextControl(ActiveControl, true, true, true, true);
        }
    }
    public class TukiosCoverSearch
    {
        public string CurrentCoverLoc { get; set; }
        public string CoverURL { get; set; }
        public string TukiosOrderStatus { get; set; }
    }
}
