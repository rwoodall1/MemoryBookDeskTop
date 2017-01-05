using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mbc5.Dialogs;
using Mbc5.Forms.MemoryBook;
using Mbc5.Forms.Meridian;
using BaseClass.Classes;
using BaseClass.Forms;

using Mbc5.LookUpForms;
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
        #region "Methods"
        public void PrintScreen() {
            ScreenPrinter vScreenPrinter = new ScreenPrinter(this);
           vScreenPrinter.PrintScreen();

            }
        public void ValidateUserRoles() {
            string[] AvailableRoles = new string[] { "SA","Administrator" };//list all roles when completed
            foreach (string role in AvailableRoles)

                if (this.ApplicationUser.IsInRole(role))
                    this.ValidatedUserRoles.Add(role);

            }
        private int GetInvno()
        {
          

            int vInvno = 0;
            switch (this.ActiveMdiChild.Name)
            {

                case "frmMbcCust":
                    {

                        var tmpForm = (frmMbcCust)this.ActiveMdiChild;

                        vInvno = tmpForm.Invno;
                        break;
                    }
                case "frmBids":
                    {
                        var tmpForm = (frmBids)this.ActiveMdiChild;
                        vInvno = tmpForm.Invno;
                        break;
                    }
                case "frmProdutn":
                    {
                        var tmpForm = (frmProdutn)this.ActiveMdiChild;
                        vInvno = tmpForm.Invno;
                        break;
                    }
                
            }
            return vInvno;
        }
        private string GetSchcode()
        {
            string vSchcode =null;
            switch (this.ActiveMdiChild.Name)
            {
                case "frmSales":
                        {

                        var tmpForm = (frmSales)this.ActiveMdiChild;

                        vSchcode = tmpForm.Schcode;
                        break;
                        }
                case "frmMbcCust":
                    {

                        var tmpForm = (frmMbcCust)this.ActiveMdiChild;

                        vSchcode = tmpForm.Schcode;
                        break;
                    }
                case "frmBids":
                    {
                        var tmpForm = (frmBids)this.ActiveMdiChild;
                        vSchcode = tmpForm.Schcode;
                        break;
                    }
                case "frmProdutn":
                    {
                        var tmpForm = (frmProdutn)this.ActiveMdiChild;
                        vSchcode = tmpForm.Schcode;
                        break;
                    }

            }
            return vSchcode;

        }
        #endregion
        private void frmMain_Load(object sender, EventArgs e)
        {
            List<string> roles = new List<string>();
            this.ValidatedUserRoles = roles;
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
        #region MenuActions
        private void userMaintinanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser vUser = new frmUser(this.ApplicationUser);
            this.Cursor = Cursors.AppStarting;
            vUser.MdiParent = this;
            vUser.Show();
            this.Cursor = Cursors.Default;

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
            
            if (this.ActiveMdiChild == null) {
                this.Cursor = Cursors.AppStarting;

                frmMbcCust frmCust = new frmMbcCust(this.ApplicationUser);
                frmCust.MdiParent = this;
                frmCust.Show();
                this.Cursor = Cursors.Default;


                } else {
                this.Cursor = Cursors.AppStarting;
                string vSchcode = GetSchcode();

                if (String.IsNullOrEmpty(vSchcode) ) {
                    this.Cursor = Cursors.AppStarting;

                    frmMbcCust frmCust1 = new frmMbcCust(this.ApplicationUser);
                    frmCust1.MdiParent = this;
                    frmCust1.Show();
                    this.Cursor = Cursors.Default;
                    }

                this.Cursor = Cursors.AppStarting;

                frmMbcCust frmCust = new frmMbcCust(this.ApplicationUser,vSchcode);
                frmCust.MdiParent = this;
                frmCust.Show();
                this.Cursor = Cursors.Default;

                }


            }

        private void MerToolStrip_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.AppStarting;

            frmMbcCust frmMer = new frmMbcCust(this.ApplicationUser);
            frmMer.MdiParent = this;
            frmMer.Show();
            this.Cursor = Cursors.Default;
            }

        private void bidsToolStripMenuItem_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.AppStarting;

            frmBids frmBids = new frmBids(this.ApplicationUser);
            frmBids.MdiParent = this;
            frmBids.Show();
            this.Cursor = Cursors.Default;
            }

        private void mbidsToolStripMenuItem_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.AppStarting;

            frmMBids frmMBids = new frmMBids(this.ApplicationUser);
            frmMBids.MdiParent = this;
            frmMBids.Show();
            this.Cursor = Cursors.Default;
            }

        private void msalesToolStripMenuItem_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.AppStarting;
            frmMSales frmMSales = new frmMSales(this.ApplicationUser);
            frmMSales.MdiParent = this;
            frmMSales.Show();
            this.Cursor = Cursors.Default;
            }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (this.ActiveMdiChild == null)
            {
               frmSales frmSales = new frmSales(this.ApplicationUser);
                frmSales.MdiParent = this;
                frmSales.Show();
                this.Cursor = Cursors.Default;


            }
            else
            {
                this.Cursor = Cursors.AppStarting;
                int vInvno = GetInvno();
                string vSchcode = GetSchcode();

                if (vInvno==0) {
                    MessageBox.Show("This school does not have a sales record to go to. Please search for record from Sales Screen.","Sales",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frmSales frmSales1 = new frmSales(this.ApplicationUser);
                    frmSales1.MdiParent = this;
                    frmSales1.Show();
                    this.Cursor = Cursors.Default;
                    }

                frmSales frmSales = new frmSales(this.ApplicationUser, vInvno, vSchcode);
                frmSales.MdiParent = this;
                frmSales.Show();
                this.Cursor = Cursors.Default;

            }



        }
        private void productionWIPToolStripMenuItem_Click(object sender,EventArgs e) {
            if (this.ActiveMdiChild == null) {
                frmProdutn frmProdutn = new frmProdutn(this.ApplicationUser);
                frmProdutn.MdiParent = this;
                frmProdutn.Show();
                this.Cursor = Cursors.Default;


                } else {
                this.Cursor = Cursors.AppStarting;
                int vInvno = GetInvno();
                string vSchcode = GetSchcode();

                if (vInvno == 0) {
                    MessageBox.Show("This school does not have a production record to go to. Please search for record from Production Screen.","Production",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frmProdutn frmProdutn1 = new frmProdutn(this.ApplicationUser);
                    frmProdutn1.MdiParent = this;
                    frmProdutn1.Show();
                    this.Cursor = Cursors.Default;
                    }

                frmProdutn frmProduction = new frmProdutn(this.ApplicationUser,vInvno,vSchcode);
                frmProduction.MdiParent = this;
                frmProduction.Show();
                this.Cursor = Cursors.Default;

                }
            }
        #endregion
        #region DataMaint
        private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LkpDiscount frmDiscount = new LkpDiscount(this.ApplicationUser);
            this.Cursor = Cursors.AppStarting;
            frmDiscount.MdiParent = this;
            frmDiscount.Show();
            this.Cursor = Cursors.Default;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void tsPrintScreen_Click(object sender,EventArgs e) {
            this.PrintScreen();
            }

        private void testToolStripMenuItem_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.AppStarting;
            test test = new test();
          
            test.MdiParent = this;
            test.Show();
            this.Cursor = Cursors.Default;
            }

        private void tsSave_Click(object sender,EventArgs e) {
            try {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.Save(); }
            catch(Exception ex) {
                MessageBox.Show("Save is not implemented for this form.","Save",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }

        private void tsAdd_Click(object sender,EventArgs e) {
            try {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.Add();
                
                } catch (Exception ex) {
                MessageBox.Show("Add record is not implemented for this form.","Add",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }

        private void tsDelete_Click(object sender,EventArgs e) {
            try {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.Delete();

                } catch (Exception ex) {
                MessageBox.Show("Delete is not implemented for this form.","Delete",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }

        private void undoToolStripMenuItem_Click(object sender,EventArgs e) {
            this.undo();
            }

        private void tsCut_Click(object sender,EventArgs e) {
            this.Cut();
            }

        private void copyToolStripMenuItem_Click(object sender,EventArgs e) {
            this.Copy();
            }

        private void pasteToolStripMenuItem_Click(object sender,EventArgs e) {
            this.Paste();
            }

        private void tsUndo_Click(object sender,EventArgs e) {
            this.undo();
            }

        private void tsCopy_Click(object sender,EventArgs e) {
            this.Copy();
            }

        private void tsPaste_Click(object sender,EventArgs e) {
            this.Paste();
            }

        private void tsPrint_Click(object sender,EventArgs e) {
            this.PrintScreen();
            }

        private void tsEmail_Click(object sender,EventArgs e) {
            
            var helper = new EmailHelper();
            helper.SendOutLookEmail("","","","",EmailType.Blank);
            }

        private void tsCancel_Click(object sender,EventArgs e) {
            try {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.Cancel();

                } catch (Exception ex) {
                MessageBox.Show("Add record is not implemented for this form.","Add",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }

        private void scanDescriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LkpWipDescriptions frmWipDesc = new LkpWipDescriptions(this.ApplicationUser);
            this.Cursor = Cursors.AppStarting;
            frmWipDesc.MdiParent = this;
            frmWipDesc.Show();
            this.Cursor = Cursors.Default;
        }


        #endregion





        //nothing below here
    }
        }

