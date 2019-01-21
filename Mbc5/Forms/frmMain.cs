using System;
using System.Configuration;
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
using System.Diagnostics;
using Mbc5.LookUpForms;
using NLog;
using Mbc5.Reports;
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
        public string AppConnectionString { get; set; }
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
                try {
                    if (this.ApplicationUser.IsInRole(role))
                    this.ValidatedUserRoles.Add(role);
                }
                catch (Exception ex)
                {

                }
                

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
				case "frmSales":
					{
						var tmpForm = (frmSales)this.ActiveMdiChild;
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
            var Environment = ConfigurationManager.AppSettings["Environment"].ToString();
            if (Environment == "DEV")
            {
                this.AppConnectionString = "Data Source=192.168.1.101; Initial Catalog=Mbc5; User Id=sa;password=Briggitte1; Connect Timeout=5";
            }
            else if (Environment == "PROD") { this.AppConnectionString = "Data Source=10.37.32.49;Initial Catalog=Mbc5;User Id = MbcUser; password = 3l3phant1; Connect Timeout=5"; }
            

            List<string> roles = new List<string>();
            this.ValidatedUserRoles = roles;
            this.WindowState = FormWindowState.Maximized;
            this.Hide();
            bool keepLoading = true;
            for (int i = 0; i < 3; i++)
            {
                if (this.Login())
                {
                    break;
                };
                if (i==2)
                {
                    //if 2 tries close 
                    MessageBox.Show("You do not have the proper credentials. Contact your supervisor.", "Final Login Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    keepLoading = false;
                    Application.Exit();
                }
            }

            if (keepLoading)
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

            if (this.ActiveMdiChild == null)
            {
                //frmBids frmBids = new frmBids(this.ApplicationUser);
                //frmBids.MdiParent = this;
                //frmBids.Show();
                //this.Cursor = Cursors.Default;
                MessageBox.Show("Customer screen must be open and on the customer to place bid for.");
                return;


            }
            else
            {               
                string vSchcode = GetSchcode();
                frmBids frmSales = new frmBids(this.ApplicationUser, vSchcode);
                frmSales.MdiParent = this;
                frmSales.Show();
                this.Cursor = Cursors.Default;
            }
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

                if (vInvno == 0)
                {
                    MessageBox.Show("This school does not have a sales record to go to. Please search for record from Sales Screen.", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmSales frmSales1 = new frmSales(this.ApplicationUser);
                    frmSales1.MdiParent = this;
                    frmSales1.Show();
                    this.Cursor = Cursors.Default;
                }
                else
                {

                    frmSales frmSales = new frmSales(this.ApplicationUser, vInvno, vSchcode);
                    frmSales.MdiParent = this;
                    frmSales.Show();
                    this.Cursor = Cursors.Default;
                }

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

		private void endSheetSupplementPreFlightToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.ActiveMdiChild == null)
			{
				frmEndSheet frmProdutn = new frmEndSheet(this.ApplicationUser);
				frmProdutn.MdiParent = this;
				frmProdutn.Show();
				this.Cursor = Cursors.Default;


			}
			else
			{
				this.Cursor = Cursors.AppStarting;
				int vInvno = GetInvno();
				string vSchcode = GetSchcode();

				if (vInvno == 0)
				{
					MessageBox.Show("This school does not have a end sheet record to go to. Please search for record from end sheet Screen.", "Production", MessageBoxButtons.OK, MessageBoxIcon.Information);
					frmProdutn frmProdutn1 = new frmProdutn(this.ApplicationUser);
					frmProdutn1.MdiParent = this;
					frmProdutn1.Show();
					this.Cursor = Cursors.Default;
				}

				frmEndSheet frmEndSheet = new frmEndSheet(this.ApplicationUser, vInvno, vSchcode);
				frmEndSheet.MdiParent = this;
				frmEndSheet.Show();
				this.Cursor = Cursors.Default;

			}
		}


		#endregion
        public bool Login()
        {
            frmLogin Login = new frmLogin(this);
            var _result = Login.ShowDialog();
            if (_result == DialogResult.Cancel)
            {
                Application.Exit();
            }
            else if (_result == DialogResult.No)
            {
                MessageBox.Show("Your password or user name was incorrect.", " Login Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            else if (_result == DialogResult.Abort)
            {

                Application.Exit();
            }
            

            return true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            //localfilePath = root.Replace("StartUpApp", "Mbc5");
            var localfile = root + "\\Mbc5.exe";
            var localfileInfo = FileVersionInfo.GetVersionInfo(localfile);
            string localVersion = localfileInfo.FileVersion;
            MessageBox.Show("MBC version:" + localVersion, "Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void testFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
          test test = new test();
           
            test.Show();
            this.Cursor = Cursors.Default;
        }

        private void barScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                this.Cursor = Cursors.AppStarting;

                frmBarScan frmBarScan = new frmBarScan(this.ApplicationUser);
                frmBarScan.MdiParent = this;
                frmBarScan.Show();
                this.Cursor = Cursors.Default;

        }

        private void leadSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LkpLeadSource frmLkpLeadSource = new LkpLeadSource(this.ApplicationUser);
            this.Cursor = Cursors.AppStarting;
            frmLkpLeadSource.MdiParent = this;
            frmLkpLeadSource.Show();
            this.Cursor = Cursors.Default;
        }

        private void leadNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LkpLeadName frmLkpLeadName = new LkpLeadName(this.ApplicationUser);
            this.Cursor = Cursors.AppStarting;
            frmLkpLeadName.MdiParent = this;
            frmLkpLeadName.Show();
            this.Cursor = Cursors.Default;
        }

        private void typeStylesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LkpTypeStyle frmLkpTypeStyle = new LkpTypeStyle(this.ApplicationUser);
            this.Cursor = Cursors.AppStarting;
            frmLkpTypeStyle.MdiParent = this;
            frmLkpTypeStyle.Show();
            this.Cursor = Cursors.Default;
        }

        private void invoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            frmInvoicInq frmInvoice = new frmInvoicInq(this.ApplicationUser);
            frmInvoice.MdiParent = this;
            frmInvoice.Show();
            this.Cursor = Cursors.Default;
        }




        //nothing below here
    }
        }

