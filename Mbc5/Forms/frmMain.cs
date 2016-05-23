using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using NLog;
namespace Mbc5.Forms
{
    public partial class frmMain : BaseClass.ParentForm
    {

        public frmMain()
        {

            InitializeComponent();
        }
        #region "Properties"

        public bool ForcePasswordChange { get; set; }

        public List<string> ValidatedUserRoles { get; private set; }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<string> a = new List<string>();
            this.ValidatedUserRoles = a;
            this.WindowState = FormWindowState.Maximized;
            this.Hide();

            frmLogin Login = new frmLogin(this);
            var _result = Login.ShowDialog();
            if (_result == DialogResult.Cancel)
            {
                Application.Exit();
            }
            else if (_result == DialogResult.No)
            {
                MessageBox.Show("Your login is invalid", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
            else if (_result == DialogResult.Abort)
            {
                MessageBox.Show("There was a fatal error. Application is closing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
            else
            {

                this.WindowState = FormWindowState.Maximized;


                if (this.ForcePasswordChange)
                {
                    this.Cursor = Cursors.AppStarting;

                    frmChangePassword frmPassword = new frmChangePassword(this.ApplicationUser.id, this);

                    frmPassword.ShowDialog();
                    this.Cursor = Cursors.Default;
                    if (ForcePasswordChange)
                    {
                        MessageBox.Show("Password was not changed.");
                        Application.Exit();
                    }
                }
                ValidateUserRoles();
                SetMenu();
                mnuMain.Enabled = true;
                this.WindowState = FormWindowState.Maximized;
            }


        }
        private void SetMenu()
        {

            this.userMaintinanceToolStripMenuItem.Enabled = this.ValidatedUserRoles.Contains("SA");
        }
        public void exitMBCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userMaintinanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser vUser = new frmUser(this.ApplicationUser);
            this.Cursor = Cursors.AppStarting;
            vUser.MdiParent = this;
            vUser.Show();
            this.Cursor = Cursors.Default;

        }
        public void ValidateUserRoles()
        {
            string[] AvailableRoles = new string[] { "SA", "Administrator" };//list all roles when completed
            foreach (string role in AvailableRoles)

                if (this.ApplicationUser.IsInRole(role))
                    this.ValidatedUserRoles.Add(role);
           
        }

        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.AppStarting;

            frmChangePassword frmPassword = new frmChangePassword(this.ApplicationUser.id, this);

            frmPassword.ShowDialog();
            this.Cursor = Cursors.Default;

        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            frmMbcCust frmCust = new frmMbcCust(this.ApplicationUser);
            frmCust.MdiParent = this;
            frmCust.Show();
            this.Cursor = Cursors.Default;
        }

        private void MerToolStrip_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.AppStarting;

            frmMbcCust frmMer = new frmMbcCust(this.ApplicationUser);
            frmMer.MdiParent = this;
            frmMer.Show();
            this.Cursor = Cursors.Default;
            }
        }
}
