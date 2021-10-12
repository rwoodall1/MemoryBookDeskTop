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
using Mbc5.Forms.MixBook;
using BaseClass.Classes;
using BaseClass.Forms;
using System.Diagnostics;
using Mbc5.LookUpForms;
using NLog;
//using Mbc5.Reports;
using Mbc5.Classes;
using System.Data.SqlClient;
using Exceptionless;
using Exceptionless.Models;
using BaseClass;
using BindingModels;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using CustomControls;
using NLog;
namespace Mbc5.Forms
{
    public partial class frmMain : BaseClass.ParentForm
    {

        public frmMain()
        {

            InitializeComponent();
        }
        protected Logger Log { get; set; }
        private void frmMain_Load(object sender, EventArgs e)
        {
            var Environment = ConfigurationManager.AppSettings["Environment"].ToString();
            if (Environment == "DEV")
            {
                AppConnectionString = "Data Source=sedswjpsql01; Initial Catalog=Mbc5_demo;User Id=mbcuser_demo;password=F8GFxAtT9Hpzbnck; Connect Timeout=5";
            }
            else if (Environment == "PROD") { AppConnectionString = "Data Source=sedswjpsql01;Initial Catalog=Mbc5; Persist Security Info =True;Trusted_Connection=True;"; }
            // AppConnectionString = "Data Source=Sedswbpsql01;Initial Catalog=Mbc5; Persist Security Info =True;Trusted_Connection=True;";
            List<string> roles = new List<string>();
            this.ValidatedUserRoles = roles;
            this.WindowState = FormWindowState.Maximized;
            this.Hide();

            for (int i = 0; i < 3; i++)
            {
                if (this.Login())
                {
                    break;
                };
                if (i == 2)
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
        #region "Properties"
        public bool keepLoading { get; set; } = true;
        public bool ForcePasswordChange { get; set; }
        public string AppConnectionString { get; set; }
        public List<string> ValidatedUserRoles { get; private set; }
        #endregion
        #region "Methods"
        public bool Login()
        {
            frmLogin Login = new frmLogin(this);
            var _result = Login.ShowDialog();
            if (_result == DialogResult.Cancel || _result == DialogResult.Abort)
            {
                keepLoading = false;
                Application.Exit();
            }
            else if (_result == DialogResult.No)
            {
                MessageBox.Show("Your password or user name was incorrect.", " Login Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            SetMenu();

            return true;
        }
        private void SetMenu()
        {

            if (ApplicationUser.UserName == "BARCODE")
            {
                //Show barscan screen hid every thing else
                tsMain.Visible = false;
                toolStripMenuItem2.Visible = false;
                systemToolStripMenuItem.Visible = false;
                mBCToolStripMenuItem.Visible = false;
                meridianToolStripMenuItem.Visible = false;
                productionWIPToolStripMenuItem.Visible = false;
                endSheetSupplementPreFlightToolStripMenuItem.Visible = false;
                barScanToolStripMenuItem_Click(null, null);



            }
            else if (ApplicationUser.UserName == "onboard" | ApplicationUser.UserName == "press"
               || ApplicationUser.UserName == "press" || ApplicationUser.UserName == "binding"
               || ApplicationUser.UserName == "quality" || ApplicationUser.UserName == "trimming")
            {
                caseMatchScanToolStripMenuItem.Visible = false;
                mixBookOrdersToolStripMenuItem.Visible = false;
                mixBookLoadTestToolStripMenuItem.Visible = false;
                productionToolStripMenuItem.Visible = false;
                tsMain.Visible = false;
                toolStripMenuItem2.Visible = false;
                systemToolStripMenuItem.Visible = false;
                mBCToolStripMenuItem.Visible = false;
                meridianToolStripMenuItem.Visible = false;
                productionWIPToolStripMenuItem.Visible = false;
                endSheetSupplementPreFlightToolStripMenuItem.Visible = false;
                mixbookBarscanToolStripMenuItem_Click(null, null);
                productionToolStripMenuItem.Visible = false;
            }
            else if (ApplicationUser.UserName == "casein")
            {
                mixbookBarscanToolStripMenuItem.Visible = false;
                mixBookOrdersToolStripMenuItem.Visible = false;
                mixBookLoadTestToolStripMenuItem.Visible = false;
                productionToolStripMenuItem.Visible = false;
                tsMain.Visible = false;
                toolStripMenuItem2.Visible = false;
                systemToolStripMenuItem.Visible = false;
                mBCToolStripMenuItem.Visible = false;
                meridianToolStripMenuItem.Visible = false;
                productionWIPToolStripMenuItem.Visible = false;
                endSheetSupplementPreFlightToolStripMenuItem.Visible = false;
                productionToolStripMenuItem.Visible = false;

                caseMatchScanToolStripMenuItem_Click(null, null);

            }
            else if (ApplicationUser.UserName == "shipping")
            {
                caseMatchScanToolStripMenuItem.Visible = false;
                mixbookBarscanToolStripMenuItem.Visible = false;
                mixBookOrdersToolStripMenuItem.Visible = false;
                mixBookLoadTestToolStripMenuItem.Visible = false;
                productionToolStripMenuItem.Visible = false;
                tsMain.Visible = false;
                toolStripMenuItem2.Visible = false;
                systemToolStripMenuItem.Visible = false;
                mBCToolStripMenuItem.Visible = false;
                meridianToolStripMenuItem.Visible = false;
                productionWIPToolStripMenuItem.Visible = false;
                endSheetSupplementPreFlightToolStripMenuItem.Visible = false;
                productionToolStripMenuItem.Visible = false;
                shippingScanToolStripMenuItem_Click(null, null);

            }

            else
            {
                tsMain.Visible = true;
                mixbookReportsToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator" });
                this.mixBookToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator", "MB" });
                mixBookOrdersToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator", "MB" });
                this.mixBookLoadTestToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA" });
                productionToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator", "MB" });
                productionWIPToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator", "MB" });
                systemToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator" });
                this.userMaintinanceToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator" });
                this.tsDeptScanLabel.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator" });
                lookUpMaintenanceToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator" });
                mixBookLoadTestToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA" });
                // invoicesToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator" });
                // meridianToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator", "MeridianCs" });
                // mBCToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator", "MbcCS" });
                //cancelationStatementsToolStripMenuItem.Visible = ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator" });
            }



        }
        public void ShowSearchButtons(string formName)
        {
            tsSchcodeSearch.Visible = true;
            tsSchnameSearch.Visible = true;
            tsInvno.Visible = true;
            tsProdutnNumberSearch.Visible = true;
            tsOracleCodeSearch.Visible = true;
            tsJobNo.Visible = true;
            if (formName == "frmMbcCust")
            {
                tsFirstNameSearch.Visible = true;
                tsLastNameSearch.Visible = true;
                tsZipCodeSearch.Visible = true;
                tsEmailSearch.Visible = true;
                tsJobNo.Visible = true;
            }
            else if (formName == "frmMerCust")
            {
                tsFirstNameSearch.Visible = true;
                tsLastNameSearch.Visible = true;
                tsZipCodeSearch.Visible = true;
                tsEmailSearch.Visible = true;
                tsJobNo.Visible = false;

            }
            else if (formName == "frmSales")
            {

                tsJobNo.Visible = true;
            }
            else if (formName == "frmMSales")
            {
                tsJobNo.Visible = false;
            }
            else if (formName == "frmProdutn")
            {
                tsJobNo.Visible = true;
                tsMxbClientOrderId.Visible = true;
            }
            else if (formName == "frmBids")
            {

                tsInvno.Visible = false;
                tsProdutnNumberSearch.Visible = false;
                tsOracleCodeSearch.Visible = false;
                tsJobNo.Visible = false;
            }
            else if (formName == "frmMBids")
            {

                tsInvno.Visible = false;
                tsProdutnNumberSearch.Visible = false;
                tsOracleCodeSearch.Visible = false;
                tsJobNo.Visible = false;
            }
            else
            {
                tsFirstNameSearch.Visible = false;
                tsLastNameSearch.Visible = false;
                tsZipCodeSearch.Visible = false;
                tsEmailSearch.Visible = false;
            }

        }
        public void HideSearchButtons()
        {
            tsSchcodeSearch.Visible = false;
            tsSchnameSearch.Visible = false;
            tsInvno.Visible = false;
            tsProdutnNumberSearch.Visible = false;
            tsOracleCodeSearch.Visible = false;
            tsFirstNameSearch.Visible = false;
            tsLastNameSearch.Visible = false;
            tsZipCodeSearch.Visible = false;
            tsEmailSearch.Visible = false;
            tsJobNo.Visible = false;
            tsJobNo.Visible = false;
            tsMxbClientOrderId.Visible = false;
        }
        public void PrintScreen()
        {
            ScreenPrinter vScreenPrinter = new ScreenPrinter(this);
            vScreenPrinter.PrintScreen();

        }
        public void ValidateUserRoles()
        {
            string[] AvailableRoles = new string[] { "SA", "Administrator" };//list all roles when completed
            foreach (string role in AvailableRoles)
                try
                {
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
                case "frmMerCust":
                    {
                        var tmpForm = (frmMerCust)this.ActiveMdiChild;
                        vInvno = tmpForm.Invno;
                        break;

                    }
                case "frmMSales":
                    {
                        var tmpForm = (frmMSales)this.ActiveMdiChild;
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
                case "frmMBOrders":
                    {
                        var tmpForm = (frmMBOrders)this.ActiveMdiChild;
                        vInvno = tmpForm.Invno;
                        break;

                    }

            }
            return vInvno;
        }
        private string GetSchcode(string company)
        {
            string vSchcode = null;
            if (company == "MBC")
            {
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
            }
            else if (company == "MER")
            {
                switch (this.ActiveMdiChild.Name)
                {

                    case "frmMerCust":
                        {

                            var tmpForm = (frmMerCust)this.ActiveMdiChild;

                            vSchcode = tmpForm.Schcode;
                            break;
                        }

                    case "frmMBids":
                        {
                            var tmpForm = (frmMBids)this.ActiveMdiChild;
                            vSchcode = tmpForm.Schcode;
                            break;
                        }
                    case "frmMSales":
                        {
                            var tmpForm = (frmMSales)this.ActiveMdiChild;
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

            }
            else if (company == "")
            {
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
                    case "frmMerCust":
                        {

                            var tmpForm = (frmMerCust)this.ActiveMdiChild;

                            vSchcode = tmpForm.Schcode;
                            break;
                        }

                    case "frmMBids":
                        {
                            var tmpForm = (frmMBids)this.ActiveMdiChild;
                            vSchcode = tmpForm.Schcode;
                            break;
                        }
                    case "frmMSales":
                        {
                            var tmpForm = (frmMSales)this.ActiveMdiChild;
                            vSchcode = tmpForm.Schcode;
                            break;
                        }
                }
            }
            return vSchcode;

        }
        public int GetNewInvno()
        {

            var sqlQuery = new BaseClass.Classes.SQLQuery();

            SqlParameter[] parameters = new SqlParameter[] {

                    };
            var strQuery = "SELECT Invno FROM Invcnum";
            try
            {
                DataTable userResult = sqlQuery.ExecuteReaderAsync(CommandType.Text, strQuery, parameters);
                DataRow dr = userResult.Rows[0];
                int Invno = (int)dr["Invno"];
                int newInvno = Invno + 1;
                strQuery = "Update Invcnum Set invno=@newInvno";
                SqlParameter[] parameters1 = new SqlParameter[] {
                      new SqlParameter("@newInvno",newInvno),
                    };
                sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters1);

                return Invno;

            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                       .SetMessage("Failed to get invoice number for a new record");

                MessageBox.Show("Failed to get invoice number for a new record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;

            }

        }
        public string GetProdNo()
        {
            var sqlQuery = new SQLQuery();
            //useing hard code until function to generate invno is done
            SqlParameter[] parameters = new SqlParameter[] { };
            var strQuery = "Select * from prodnum";
            var result = sqlQuery.ExecuteReaderAsync(CommandType.Text, strQuery, parameters);
            int? prodNum = null;
            try
            {
                prodNum = Convert.ToInt32(result.Rows[0]["lstprodno"]);
                strQuery = "Update Prodnum Set lstprodno=@lstprodno";
                SqlParameter[] parameters1 = new SqlParameter[] { new SqlParameter("@lstprodno", (prodNum + 1)) };
                var result1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters1);
                if (result1 != 1)
                {
                    ExceptionlessClient.Default.CreateLog("Error updating Prodnum table with new value.")
                         .AddTags("New prod number error.")
                         .Submit();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error getting the production number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ex.ToExceptionless()
                  .AddTags("MBCWindows")
                  .SetMessage("Error getting production number.")
                  .Submit();

            }
            string vprodNum = prodNum.ToString();
            vprodNum = " " + vprodNum;
            return prodNum.ToString();

        }
        public string GetCoverNumber()
        {
            var sqlQuery = new SQLQuery();
            //useing hard code until function to generate invno is done
            SqlParameter[] parameters = new SqlParameter[] { };
            var strQuery = "Select * from Spcover";
            var result = sqlQuery.ExecuteReaderAsync(CommandType.Text, strQuery, parameters);
            int coverNum = 0;
            try
            {
                coverNum = Convert.ToInt32(result.Rows[0]["speccvno"]);
                strQuery = "Update Spcover set speccvno=@speccvno";
                SqlParameter[] parameters1 = new SqlParameter[] { new SqlParameter("@speccvno", (coverNum + 1)) };
                var result1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters1);
                if (result1 != 1)
                {
                    ExceptionlessClient.Default.CreateLog("Error updating Spcover table with new value.")
                         .AddTags("New cover number error.")
                         .Submit();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error getting the cover number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ex.ToExceptionless()
                  .AddTags("MBCWindows")
                  .SetMessage("Error getting cover number.")
                  .Submit();

            }

            return coverNum.ToString();
        }
        public void PrintJobTickets()
        {
            string value = "";
            if (DateInputBox.Show("Request Date", "Enter Request Date:", ref value) == DialogResult.OK) {

                var sqlClient = new SQLCustomClient().CommandText(@"
                Select Invno,ShipName,RequestedShipDate,Description,Copies,Pages,Backing,OrderReceivedDate,ProdInOrder,'*MXB'+CAST(Invno as varchar)+'SC*' AS SCBarcode,
                 '*MXB'+CAST(Invno as varchar)+'YB*' AS YBBarcode From MixBookOrder Where (JobTicketPrinted Is Null OR JobTicketPrinted=0) AND
                    MixBookOrder.RequestedShipDate <=@RequestedShipDate AND  MixBookOrder.BookStatus IS Null
            "); ;
             
                sqlClient.AddParameter("@RequestedShipDate",value );
          
                var result = sqlClient.SelectMany<JobTicketQuery>();
                if (result.IsError)
                {
                    MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error("Failed to retieve orders for JobTicketQuery:" + result.Errors[0].DeveloperMessage);
                    return;
                }
          
                var jobData = (List<JobTicketQuery>)result.Data;
                if (jobData!=null) {
                    reportViewer1.LocalReport.DataSources.Clear();
                    JobTicketQueryBindingSource.DataSource = jobData;
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", JobTicketQueryBindingSource));
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixbookJobTicketQuery.rdlc";
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MbcMessageBox.Hand("There were no records found to print.", "No Records");
                }


            }
        }
        private void SetJobTicketsPrinted()
        {
            var sqlClient = new SQLCustomClient().CommandText(@"Update MixbookOrder Set JobTicketPrinted=@SetJobTicketPrinted Where Invno=@Invno");
            foreach(JobTicketQuery rec in JobTicketQueryBindingSource.List)
            {
                
                var vInvno = rec.Invno.ToString();
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@Invno", vInvno);
                sqlClient.AddParameter("@SetJobTicketPrinted",1);
                var updateResult=sqlClient.Update();
            }
        }
        
        private void PrintRemakeTickets()
        {
         
              var sqlClient = new SQLCustomClient().CommandText(@"
                Select MO.Invno,MO.ShipName,MO.RequestedShipDate,MO.Description,MO.Copies,MO.Pages,MO.Backing,MO.OrderReceivedDate,MO.ProdInOrder,'*MXB'+CAST(MO.Invno as varchar)+'SC*' AS SCBarcode,
                 '*MXB'+CAST(MO.Invno as varchar)+'YB*' AS YBBarcode,W.Rmbto AS RemakeDate,W.Rmbtot As RemakeTotal
                    From MixBookOrder MO LEFT JOIN WIP W ON MO.Invno=W.INVNO
                Where W.Rmbto IS NOT NULL AND MO.RemakeTicketPrinted=0
            "); 

           

                var result = sqlClient.SelectMany<RemakeTicketQuery>();
                if (result.IsError)
                {
                    MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error("Failed to retieve orders for RemakeTicketQuery:" + result.Errors[0].DeveloperMessage);
                    return;
                }

                var jobData = (List<RemakeTicketQuery>)result.Data;
                if (jobData != null)
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    JobTicketQueryBindingSource.DataSource = jobData;
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", JobTicketQueryBindingSource));
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookRemakeTicketQuery.rdlc";
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MbcMessageBox.Hand("There were no records found to print.", "No Records");
                }


          
        }
        private void SetRemakeTicketsPrinted()
        {
            var sqlClient = new SQLCustomClient().CommandText(@"Update MixbookOrder Set RemakeTicketPrinted=@RemakeTicketPrinted Where Invno=@Invno");
            foreach (RemakeTicketQuery rec in JobTicketQueryBindingSource.List)
            {

                var vInvno = rec.Invno.ToString();
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@Invno", vInvno);
                sqlClient.AddParameter("@RemakeTicketPrinted", 1);
                var updateResult = sqlClient.Update();
            }
        }
        #endregion

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

            if (this.ActiveMdiChild == null)
            {
                this.Cursor = Cursors.AppStarting;

                frmMbcCust frmCust = new frmMbcCust(this.ApplicationUser);
                frmCust.MdiParent = this;
                frmCust.Show();
                this.Cursor = Cursors.Default;


            }
            else
            {
                this.Cursor = Cursors.AppStarting;
                string vSchcode = GetSchcode("MBC");

                if (String.IsNullOrEmpty(vSchcode))
                {
                    this.Cursor = Cursors.AppStarting;

                    frmMbcCust frmCust1 = new frmMbcCust(this.ApplicationUser);
                    frmCust1.MdiParent = this;
                    frmCust1.Show();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.AppStarting;

                    frmMbcCust frmCust = new frmMbcCust(this.ApplicationUser, vSchcode);
                    frmCust.MdiParent = this;
                    frmCust.Show();
                    this.Cursor = Cursors.Default;

                }

            }


        }

        private void MerToolStrip_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            if (this.ActiveMdiChild == null)
            {
                frmMerCust frmMer = new frmMerCust(this.ApplicationUser);
                frmMer.MdiParent = this;
                frmMer.Show();
                this.Cursor = Cursors.Default;

            }
            else
            {
                this.Cursor = Cursors.AppStarting;
                string vSchcode = GetSchcode("MER");

                if (String.IsNullOrEmpty(vSchcode))
                {
                    this.Cursor = Cursors.AppStarting;

                    frmMerCust frmMer1 = new frmMerCust(this.ApplicationUser);
                    frmMer1.MdiParent = this;
                    frmMer1.Show();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.AppStarting;

                    frmMerCust frmCust = new frmMerCust(this.ApplicationUser, vSchcode);
                    frmCust.MdiParent = this;
                    frmCust.Show();
                    this.Cursor = Cursors.Default;

                }

            }
        }

        private void bidsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            if (this.ActiveMdiChild == null)
            {
                //default cs record
                frmBids frmSales = new frmBids(this.ApplicationUser, "038752");
                frmSales.MdiParent = this;
                frmSales.Show();
                this.Cursor = Cursors.Default;


            }
            else
            {
                string vSchcode = GetSchcode("MBC");
                frmBids frmSales = new frmBids(this.ApplicationUser, vSchcode);
                frmSales.MdiParent = this;
                frmSales.Show();
                this.Cursor = Cursors.Default;
            }
        }

        private void mbidsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            if (this.ActiveMdiChild == null)
            {

                frmMBids frmMBids = new frmMBids(this.ApplicationUser, "124487");
                frmMBids.MdiParent = this;
                frmMBids.Show();
                this.Cursor = Cursors.Default;
            }
            else
            {
                string vSchcode = GetSchcode("MER");
                frmMBids frmMBids = new frmMBids(this.ApplicationUser, vSchcode);
                frmMBids.MdiParent = this;
                frmMBids.Show();
                this.Cursor = Cursors.Default;
            }
        }

        private void msalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                frmMSales frmMSales = new frmMSales(this.ApplicationUser);
                frmMSales.MdiParent = this;
                frmMSales.Show();
                this.Cursor = Cursors.Default;


            }
            else
            {
                this.Cursor = Cursors.AppStarting;
                int vInvno = GetInvno();
                string vSchcode = GetSchcode("MER");

                if (vInvno == 0)
                {
                    MessageBox.Show("This school does not have a sales record to go to. Please search for record from Sales Screen.", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMSales frmSales1 = new frmMSales(this.ApplicationUser);
                    frmSales1.MdiParent = this;
                    frmSales1.Show();
                    this.Cursor = Cursors.Default;
                }
                else
                {

                    frmMSales frmSales = new frmMSales(this.ApplicationUser, vInvno, vSchcode);
                    frmSales.MdiParent = this;
                    frmSales.Show();
                    this.Cursor = Cursors.Default;
                }

            }

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
                string vSchcode = GetSchcode("MBC");

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
        private void productionWIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                frmProdutn frmProdutn = new frmProdutn(this.ApplicationUser);
                frmProdutn.MdiParent = this;
                frmProdutn.Show();
                this.Cursor = Cursors.Default;


            }else if (ActiveMdiChild.Name == "frmMBOrders")
            {
                this.Cursor = Cursors.AppStarting;
                int vInvno = GetInvno();
               
                if (vInvno == 0)
                {
                    MessageBox.Show("This book does not have a production record to go to. Please search for record from Production Screen.", "Production", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmProdutn frmProdutn1 = new frmProdutn(this.ApplicationUser);
                    frmProdutn1.MdiParent = this;
                    frmProdutn1.Show();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                frmProdutn frmProduction = new frmProdutn(this.ApplicationUser, vInvno, "");
                frmProduction.MdiParent = this;
                frmProduction.Show();
                this.Cursor = Cursors.Default;
                }

                

            }
            else
            {
                this.Cursor = Cursors.AppStarting;
                int vInvno = GetInvno();
                string vSchcode = GetSchcode("");

                if (vInvno == 0)
                {
                    MessageBox.Show("This school does not have a production record to go to. Please search for record from Production Screen.", "Production", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmProdutn frmProdutn1 = new frmProdutn(this.ApplicationUser);
                    frmProdutn1.MdiParent = this;
                    frmProdutn1.Show();
                    this.Cursor = Cursors.Default;
                }

                frmProdutn frmProduction = new frmProdutn(this.ApplicationUser, vInvno, vSchcode);
                frmProduction.MdiParent = this;
                frmProduction.Show();
                this.Cursor = Cursors.Default;

            }
        }
        public void exitMBCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void tsPrintScreen_Click(object sender, EventArgs e)
        {
            this.PrintScreen();
        }
        private void tsSave_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.Save(true);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Save is not implemented", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.Add();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Add record is not implemented for this form.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.Delete();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete is not implemented for this form.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.undo();
        }

        private void tsCut_Click(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void tsUndo_Click(object sender, EventArgs e)
        {
            this.undo();
        }

        private void tsCopy_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void tsPaste_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void tsPrint_Click(object sender, EventArgs e)
        {
            //this.PrintScreen();
            try
            {
                Process snippingToolProcess = new Process();
                snippingToolProcess.EnableRaisingEvents = true;
                if (!Environment.Is64BitProcess)
                {
                    snippingToolProcess.StartInfo.FileName = "C:\\Windows\\sysnative\\SnippingTool.exe";
                    snippingToolProcess.Start();
                }
                else
                {
                    snippingToolProcess.StartInfo.FileName = "C:\\Windows\\system32\\SnippingTool.exe";
                    snippingToolProcess.Start();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void tsEmail_Click(object sender, EventArgs e)
        {

            var helper = new EmailHelper();
            helper.SendOutLookEmail("", "", "", "", EmailType.Blank);
        }

        private void tsCancel_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.Cancel();

            }
            catch (Exception ex)
            {

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
                frmEndSheet frmEndSheet = new frmEndSheet(this.ApplicationUser);
                frmEndSheet.MdiParent = this;
                frmEndSheet.Show();
                this.Cursor = Cursors.Default;


            }
            else
            {
                this.Cursor = Cursors.AppStarting;
                int vInvno = GetInvno();
                string vSchcode = GetSchcode("MBC");

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

        #region "Events"
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //var root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            ////localfilePath = root.Replace("StartUpApp", "Mbc5");
            //var localfile = root + "\\Mbc5.exe";
            //var localfileInfo = FileVersionInfo.GetVersionInfo(localfile);
            //string localVersion = localfileInfo.FileVersion;
            // MessageBox.Show("MBC version:" + localVersion, "Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AboutBox frmAbout = new AboutBox();
            frmAbout.ShowDialog();
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

        private void tsSchcodeSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.SchCodeSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void tsSchnameSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.SchnameSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void tsProdutnNumberSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.ProdutnNoSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void tsOracleCodeSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.OracleCodeSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void tsInvno_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.InvoiceNumberSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void tsFirstNameSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.FirstNameSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void tsLastNameSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.LastNameSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void tsZipCodeSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.ZipCodeSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void tsEmailSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.EmailSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void tsJobNo_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.JobNoSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void testFormToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void tsFileFolder_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild.Name == "frmMbcCust"))
            {
                var cusFrm = (frmMbcCust)this.ActiveMdiChild;
                cusFrm.PrintLabel("FILEFOLDER");


            }
            else
            {
                MbcMessageBox.Stop("You must be on the proper screen to print this label.", "Stop");

            }

        }

        private void tsAddress_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild.Name == "frmMbcCust"))
            {
                var cusFrm = (frmMbcCust)this.ActiveMdiChild;
                cusFrm.PrintLabel("ADDRESSLABEL");


            }
            else
            {
                MbcMessageBox.Stop("You must be on the proper screen to print this label.", "Stop");

            }

        }

        private void tsReceivingLabel_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild.Name == "frmMbcCust"))
            {
                var cusFrm = (frmMbcCust)this.ActiveMdiChild;
                cusFrm.PrintLabel("RECEIVINGLABEL");


            }
            else
            {
                MbcMessageBox.Stop("You must be on the proper screen to print this label.", "");

            }
        }

        private void tsEnvelopeLabel_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild.Name == "frmMbcCust"))
            {
                var cusFrm = (frmMbcCust)this.ActiveMdiChild;
                cusFrm.PrintLabel("ENVELOPELABEL");


            }
            else
            {
                MbcMessageBox.Stop("You must be on the proper screen to print this label.", "");

            }
        }

        private void tsYearBookLabel_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild.Name == "frmProdutn"))
            {
                var produtnFrm = (frmProdutn)this.ActiveMdiChild;
                produtnFrm.PrintYearBookLabel();
            }
            else
            {
                MbcMessageBox.Stop("You must be on the proper screen to print this label.", "");

            }
        }

        private void tsDeptScanLabel_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.AppStarting;
            frmScanLabels frmDeptLabel = new frmScanLabels();

            frmDeptLabel.ShowDialog();
            this.Cursor = Cursors.Default;

        }

        private void cancelationStatementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCancellationStatements frmCancel = new frmCancellationStatements(this.ApplicationUser);
            frmCancel.MdiParent = this;
            frmCancel.Show();
            this.Cursor = Cursors.Default;

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();

            }
            this.ApplicationUser = null;
            List<string> roles = new List<string>();
            this.ValidatedUserRoles = roles;
            this.Hide();
            for (int i = 0; i < 3; i++)
            {
                if (this.Login())
                {
                    break;
                };
                if (i == 2)
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.JobNoSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as BaseClass.frmBase;
                activeform.Fill();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fill is not implemented", "Fill", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void wIPDescriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmWipDescriptions form = new frmWipDescriptions(this.ApplicationUser);
                form.MdiParent = this;
                form.Show();
            }
            catch { }


        }

        private void invoicesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            frmMInvoicInq frmMInvoice = new frmMInvoicInq(this.ApplicationUser);
            frmMInvoice.MdiParent = this;
            frmMInvoice.Show();
            this.Cursor = Cursors.Default;
        }

        private void paymentReceiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var vReceiptform = new frmPayments(this.ApplicationUser);
            vReceiptform.MdiParent = this;
            vReceiptform.Show();

        }

        private void receivingSurveyCompensationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {

                var vInvno = GetInvno();
                string vCompany = "";
                string vSchcode = "";
                if (this.ActiveMdiChild.Name == "frmMbcCust")
                {
                    vCompany = "MBC";
                    frmMbcCust custFrm = (frmMbcCust)ActiveMdiChild;
                    vSchcode = custFrm.Schcode;
                }
                else if (this.ActiveMdiChild.Name == "frmMerCust")
                {
                    vCompany = "MER";
                    frmMerCust mcustFrm = (frmMerCust)ActiveMdiChild;
                    vSchcode = mcustFrm.Schcode;
                }
                else
                {
                    //don't open form
                    return;
                }
                frmRecSurvey form = new frmRecSurvey(ApplicationUser, vInvno, vCompany, vSchcode);
                form.MdiParent = this;
                form.Show();
            }
            else
            {

            }
        }

        private void receivingSurveyCompensationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var vInvno = GetInvno();
            string vCompany = "";
            string vSchcode = "";
            if (this.ActiveMdiChild.Name == "frmMbcCust")
            {
                vCompany = "MBC";
                frmMbcCust custFrm = (frmMbcCust)ActiveMdiChild;
                vSchcode = custFrm.Schcode;
            }
            else if (this.ActiveMdiChild.Name == "frmMerCust")
            {
                vCompany = "MER";
                frmMerCust mcustFrm = (frmMerCust)ActiveMdiChild;
                vSchcode = mcustFrm.Schcode;
            }
            else
            {
                //don't open form
            }
            frmRecSurvey form = new frmRecSurvey(ApplicationUser, vInvno, vCompany, vSchcode);
            form.MdiParent = this;
            form.Show();
        }

        private void memeroyBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmInqCount(ApplicationUser, "MBC");
            frm.MdiParent = this;
            frm.Show();
        }

        private void meridianInqCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmInqCount(ApplicationUser, "MER");
            frm.MdiParent = this;
            frm.Show();
        }

        private void mixBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mixBookOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                this.Cursor = Cursors.AppStarting;

                frmMBOrders frmMBOrders = new frmMBOrders(this.ApplicationUser);
                frmMBOrders.MdiParent = this;
                frmMBOrders.Show();
                this.Cursor = Cursors.Default;

            }
            else
            {
                this.Cursor = Cursors.AppStarting;
                int vClientId =0;
                if (this.ActiveMdiChild.Name == "frmProdutn")
                {
                    var tmpForm = (frmProdutn)this.ActiveMdiChild;
                    
                    if (tmpForm.Company=="MXB")
                    {
                         vClientId = tmpForm.ClientId;
                    }
                 
                }

                if (vClientId>0)
                {
                    this.Cursor = Cursors.AppStarting;

                    frmMBOrders frmMBOrders = new frmMBOrders(this.ApplicationUser,vClientId);
                    frmMBOrders.MdiParent = this;
                    frmMBOrders.Show();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.AppStarting;

                    frmMBOrders frmMBOrders = new frmMBOrders(this.ApplicationUser);
                    frmMBOrders.MdiParent = this;
                    frmMBOrders.Show();
                    this.Cursor = Cursors.Default;

                }

            }









            //this.Cursor = Cursors.AppStarting;

            //frmMBOrders frmMBOrders = new frmMBOrders(this.ApplicationUser);
            //frmMBOrders.MdiParent = this;
            //frmMBOrders.Show();
            //this.Cursor = Cursors.Default;
        }

        private void mixBookLoadTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            frmLoadTest frmLoadTest = new frmLoadTest(this.ApplicationUser);
            frmLoadTest.MdiParent = this;
            frmLoadTest.Show();
            this.Cursor = Cursors.Default;
        }

        private void mixbookBarscanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            frmMxBookBarScan frmBarScan = new frmMxBookBarScan(this.ApplicationUser);
            frmBarScan.MdiParent = this;
            frmBarScan.Show();
            this.Cursor = Cursors.Default;
        }

        private void caseMatchScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCaseMatch frmCaseMatch = new frmCaseMatch(this.ApplicationUser,this);

            frmCaseMatch.MdiParent = this;
            frmCaseMatch.Show();
            this.Cursor = Cursors.Default;
        }

        private void tsMxbClientOrderId_Click(object sender, EventArgs e)
        {
            try
            {
                var activeform = this.ActiveMdiChild as Mbc5.Forms.frmProdutn;
                activeform.ClientOrderIdSearch();

            }
            catch (Exception ex)
            {

            }
        }

        private void wipReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWipReport frmWipReport = new frmWipReport(this.ApplicationUser);
            frmWipReport.MdiParent = this;
            frmWipReport.Show();

           
          

        }

     
        private void shippingScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMxBookShipping frmMxBookShipping = new frmMxBookShipping(this.ApplicationUser);

            frmMxBookShipping.MdiParent = this;
            frmMxBookShipping.Show();
            this.Cursor = Cursors.Default;
        }

        private void printJobTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintJobTickets();
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            if (reportViewer1.LocalReport.ReportEmbeddedResource== "Mbc5.Reports.MixbookJobTicketQuery.rdlc")
            {
                try {
                   
                    if (reportViewer1.PrintDialog()!=DialogResult.Cancel)
                    {
                        SetJobTicketsPrinted();
                    }
                } catch (Exception ex) { }
            }
            else
            {
                //Remake Ticket
                if (reportViewer1.PrintDialog() != DialogResult.Cancel)
                {
                    SetRemakeTicketsPrinted();
                }
            }
            
        }

        private void printRemakeTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintRemakeTickets();
        }

        private void mixBookUSPSLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsPsLabel frmUsPsLabel = new frmUsPsLabel(this.ApplicationUser);

            frmUsPsLabel.MdiParent = this;
            frmUsPsLabel.Show();
            this.Cursor = Cursors.Default;
        }

        private void coverSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCoverSearch frmCoverSearch = new frmCoverSearch(this.ApplicationUser);

            frmCoverSearch.MdiParent = this;
            frmCoverSearch.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion
        //nothing below here
    }
}

