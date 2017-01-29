using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using BaseClass.Classes;
using System.Data.Sql;
using Mbc5.Dialogs;
using System.Data.SqlClient;
using Mbc5.Classes;
using Mbc5.LookUpForms;
using BindingModels;
using Exceptionless;
using Exceptionless.Models;
using Outlook= Microsoft.Office.Interop.Outlook;

namespace Mbc5.Forms {
    public partial class frmProdutn : BaseClass.frmBase, INotifyPropertyChanged {
        private static string _ConnectionString = ConfigurationManager.ConnectionStrings["Mbc"].ConnectionString;
        private bool startup = true;
        public frmProdutn(UserPrincipal userPrincipal,int invno,string schcode) : base(new string[] { "SA","Administrator","MbcCS" },userPrincipal) {
            InitializeComponent();
            //this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
           // this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ApplicationUser = userPrincipal;
            this.Invno = invno;
            this.Schcode = schcode;

            }
        public frmProdutn(UserPrincipal userPrincipal) : base(new string[] { "SA","Administrator","MbcCS" },userPrincipal) {
            InitializeComponent();

            // this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
           // this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ApplicationUser = userPrincipal;
            this.Invno = 0;
            this.Schcode = null;
            DisableControls(this.tbProdutn.TabPages[0]);
           foreach(TabPage tab in tbProdutn.TabPages) {
                DisableControls(tab);
                }
            EnableControls(this.txtInvoiceNoSrch);
            EnableControls(this.txtProdNoSrch);
            EnableControls(this.btnProdSrch);
            EnableControls(this.btnInvoiceSrch);

            }
        private void frmProdutn_Load(object sender,EventArgs e) {
           
            Fill();
            SetShipLabel();
            CurrentProdNo = lblProdNo.Text ;

            }
     
        #region "Properties"
        public void InvokePropertyChanged(PropertyChangedEventArgs e) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this,e);
            }
        public event PropertyChangedEventHandler PropertyChanged;
        private UserPrincipal ApplicationUser { get; set; }
        private string CurrentCompany { get; set; }
        private string SchEmail { get; set; }
        private string ContactEmail { get; set; }
        private string BcontactEmail { get; set; }
        private string CcontactEmail { get; set; }
        private List<string> AllEmails { get; set; }
        private string CurrentProdNo { get; set; }
        #endregion
        #region "Methods"
        private void DisableControls(Control con) {
            foreach (Control c in con.Controls) {
                DisableControls(c);
                }
            con.Enabled = false;
            }
        private void EnableControls(Control con) {
            if (con != null) {
                con.Enabled = true;
                EnableControls(con.Parent);
                }
            }
        private void EnableAllControls(Control con) {
            foreach (Control c in con.Controls) {
                EnableAllControls(c);
                }
            con.Enabled = true;
            }
        private void SetShipLabel()
        {
            var current = (DataRowView)produtnBindingSource.Current;
            if (current != null) {
              var shipdate = current["shpdate"].ToString();
             lblShipped.Visible = !String.IsNullOrEmpty(shipdate);
                }
           
        }
       private void SetEmail() {
            SchEmail = dsProdutn.cust.Rows[0].IsNull("schemail") ? null : dsProdutn.cust.Rows[0]["schemail"].ToString().Trim();
            ContactEmail = dsProdutn.cust.Rows[0].IsNull("contemail") ? null : dsProdutn.cust.Rows[0]["contemail"].ToString().Trim();
           BcontactEmail = dsProdutn.cust.Rows[0].IsNull("bcontemail") ? null : dsProdutn.cust.Rows[0]["bcontemail"].ToString().Trim();
           CcontactEmail = dsProdutn.cust.Rows[0].IsNull("ccontemail") ? null : dsProdutn.cust.Rows[0]["ccontemail"].ToString().Trim();
            var vAllEmails = new List<string>();
            if (!String.IsNullOrEmpty(SchEmail)) {
                vAllEmails.Add(SchEmail);
                }
            if (!String.IsNullOrEmpty(ContactEmail)) {
                vAllEmails.Add(ContactEmail);
                }
            if (!String.IsNullOrEmpty(BcontactEmail)) {
                vAllEmails.Add(BcontactEmail);
                }

            if (!String.IsNullOrEmpty(CcontactEmail)) {
                vAllEmails.Add(CcontactEmail);
                }

            }
       
        //General
        private void SetCodeInvno() {
            //if (quotesBindingSource.Count > 0) {
            //    DataRowView current = (DataRowView)quotesBindingSource.Current;
            //    this.Schcode = current["schcode"].ToString();
            //    this.Invno = Convert.ToInt32(current["invno"]);
            //    }
            }
        private void Fill() {
            if (Schcode != null) {
                custTableAdapter.Fill(dsProdutn.cust,Schcode);
                quotesTableAdapter.Fill(dsProdutn.quotes,Schcode);
                
                produtnTableAdapter.Fill(dsProdutn.produtn,Schcode);             
                if (dsProdutn.produtn.Count < 1) {
                    DisableControls(this.tbProdutn.TabPages[0]);
                    foreach (TabPage tab in tbProdutn.TabPages) {
                        DisableControls(tab);
                        }
                    EnableControls(this.txtInvoiceNoSrch);
                    EnableControls(this.txtProdNoSrch);
                    EnableControls(this.btnProdSrch);
                    EnableControls(this.btnInvoiceSrch);
                    } else {EnableAllControls(this); }
                coversTableAdapter.Fill(dsProdutn.covers,Schcode);
               // coverdetailTableAdapter.Fill(dsProdutn.coverdetail,Invno);
                if (dsProdutn.covers.Count < 1) {
                    DisableControls(this.tbProdutn.TabPages[2]);
                    } else { EnableAllControls(this.tbProdutn.TabPages[2]); }
                wipTableAdapter.Fill(dsProdutn.wip,Schcode);
                wipDetailTableAdapter.Fill(dsProdutn.WipDetail,Invno);
                if (dsProdutn.wip.Count < 1) {
                    DisableControls(this.tbProdutn.TabPages[1]);
                    } else { EnableAllControls(this.tbProdutn.TabPages[1]); }
                //partbkTableAdapter.Fill(dsProdutn.partbk,Schcode);
                //ptbkbTableAdapter.Fill(dsProdutn.ptbkb,Schcode);
                //wipgTableAdapter.Fill(dsProdutn.wipg,Schcode);


                    
                }
            if (Invno != 0) {
                var pos = produtnBindingSource.Find("invno",this.Invno);
                if (pos > -1) {
                    produtnBindingSource.Position = pos;
                    } else {
                    MessageBox.Show("Production record was not found.","Invoice#",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    }
                }
                

                }
     
        public override bool  Save() {
            bool retval = true;
            switch (tbProdutn.SelectedIndex) {
                case 0:
                    SaveProdutn();
                 
                    break;
                case 1:
                        {
                        SaveWip();
                        SaveProdutn();//some produtn fiels are on covers tab so save
                        break;
                        }
                case 2: 
                    {
                      SaveCovers();
                      SaveProdutn();//some produtn fiels are on covers tab so save
                       
                        break;
                        }
                   
                case 3:
                    //SavePayment();
                    break;

                }
            return retval;
            }
        private bool SaveProdutn()
        {
            bool retval = false;
            if (dsProdutn.produtn.Count > 0) {
                if (this.ValidateChildren(ValidationConstraints.Enabled)) {
                    try {

                        this.produtnBindingSource.EndEdit();
                        var a = produtnTableAdapter.Update(dsProdutn.produtn);
                        //must refill so we get updated time stamp so concurrency is not thrown
                        produtnTableAdapter.Fill(dsProdutn.produtn,Schcode);
                        SetShipLabel();
                        retval = true;

                        } catch (DBConcurrencyException dbex) {
                        DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsProdutn.produtnRow)(dbex.Row),ref dsProdutn);
                        if (result == DialogResult.Yes) { SaveProdutn(); }
                        } catch (Exception ex) {
                        retval = false;
                        MessageBox.Show("Production record failed to update:" + ex.Message);
                        ex.ToExceptionless()
                       .SetMessage("Production record failed to update:" + ex.Message)
                       .Submit();
                        }
                    }
                } else { retval = false; }
            return retval;
        }
        private bool SaveWip() {
            bool retval = false;
            if (dsProdutn.wip.Count > 0) {

              //  if (this.Validate()) {
                    try {
                        this.wipBindingSource.EndEdit();
                        var a = wipTableAdapter.Update(dsProdutn.wip);
                        //must refill so we get updated time stamp so concurrency is not thrown
                        wipTableAdapter.Fill(dsProdutn.wip,Schcode);
                        retval = true;
                        } catch (DBConcurrencyException ex1) {
                        DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsProdutn.wipRow)(ex1.Row),ref dsProdutn);
                        if (result == DialogResult.Yes) { SaveWip(); };
                        } catch (Exception ex) {
                        ex.ToExceptionless()
                       .SetMessage("WIP record failed to update:" + ex.Message)
                       .Submit();
                        retval = false;
                        MessageBox.Show("Wip record failed to update:" + ex.Message);
                        ;
                        }
                   // }
                } 
                else { retval = false; }
                
            return retval;

            }
        private bool SaveCovers() {
            bool retval = false;
            if (dsProdutn.covers.Count > 0) {
                if (this.ValidateChildren(ValidationConstraints.Enabled)) {
                    try {
                        this.coversBindingSource1.EndEdit();
                        var a = coversTableAdapter.Update(dsProdutn.covers);
                        //must refill so we get updated time stamp so concurrency is not thrown
                        coversTableAdapter.Fill(dsProdutn.covers,Schcode);
                        retval = true;
                        } catch (DBConcurrencyException dbex) {
                        DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsProdutn.coversRow)(dbex.Row),ref dsProdutn);
                        if (result == DialogResult.Yes) { SaveCovers(); };
                        } catch (Exception ex) {
                        ex.ToExceptionless()
                       .SetMessage("Covers record failed to update:" + ex.Message)
                       .Submit();
                        retval = false;
                        }
                    }
                } else { retval = false; }

            return retval;
            }
        public override void Add() {
            //switch (tabSales.SelectedIndex) {
            //    case 0:
            //    case 1:
            //            {
            //            MessageBox.Show("This function is not available in the sales screen tab. Add a sales record from the customer screen.","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //            break;
            //            }


            //    case 2:
            //        MessageBox.Show("This function is not available in the invoice tab.","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //        break;
            //    case 3:
            //        NewPayment();
            //        break;

            //    }
            }
        public override void Delete() {
            //switch (tabSales.SelectedIndex) {
            //    case 0:
            //    case 1:
            //            {
            //            DeleteSale();
            //            break;
            //            }
            //    case 2:
            //        DeleteInvoice();
            //        break;
            //    case 3:
            //        DeletePayment();
            //        break;

            //    }
            }
        public override void Cancel() {
            //CancelPayment();
            //quotesBindingSource.CancelEdit();
            //invdetailBindingSource.CancelEdit();
            //invoiceBindingSource.CancelEdit();
            }
        #endregion
        #region DatePickers
        private void prntsamDateTimePicker_ValueChanged(object sender,EventArgs e) {

            prntsamDateTimePicker.Format = DateTimePickerFormat.Long;

            }

        private void prtdtesentDateTimePicker_ValueChanged(object sender,EventArgs e) {
            prtdtesentDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void prtdtebkDateTimePicker_ValueChanged(object sender,EventArgs e) {
            prtdtebkDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void dcdtesentDateTimePicker_ValueChanged(object sender,EventArgs e) {
            dcdtesentDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void dcdtebkDateTimePicker_ValueChanged(object sender,EventArgs e) {
            dcdtebkDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void otdtesentDateTimePicker1_ValueChanged(object sender,EventArgs e) {
            otdtesentDateTimePicker1.Format = DateTimePickerFormat.Long;
            }

        private void otdtebkDateTimePicker_ValueChanged(object sender,EventArgs e) {
            otdtebkDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void perslistdateDateTimePicker_ValueChanged(object sender,EventArgs e) {
            perslistdateDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void lamdtesentDateTimePicker_ValueChanged(object sender,EventArgs e) {
            lamdtesentDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void reprntdteDateTimePicker_ValueChanged(object sender,EventArgs e) {
            reprntdteDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void desorgdteDateTimePicker_ValueChanged(object sender,EventArgs e) {
            desorgdteDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void screcvDateTimePicker1_ValueChanged(object sender,EventArgs e) {
            screcvDateTimePicker1.Format = DateTimePickerFormat.Long;
            }
        private void rmbfrmDateTimePicker_ValueChanged(object sender,EventArgs e) {
            rmbfrmDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void rmbtoDateTimePicker_ValueChanged(object sender,EventArgs e) {
            rmbtoDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void ioutDateTimePicker_ValueChanged(object sender,EventArgs e) {
            ioutDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void frmbindDateTimePicker_ValueChanged(object sender,EventArgs e) {
            frmbindDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void iinDateTimePicker_ValueChanged(object sender,EventArgs e) {
            iinDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void binddteDateTimePicker_ValueChanged(object sender,EventArgs e) {
            binddteDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void rmptoDateTimePicker_ValueChanged(object sender,EventArgs e) {
            rmptoDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void rmpfrmDateTimePicker_ValueChanged(object sender,EventArgs e) {
            rmpfrmDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void adduploaddateDateTimePicker_ValueChanged(object sender,EventArgs e) {
            adduploaddateDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void dedayinDateTimePicker_ValueChanged(object sender,EventArgs e) {
            dedayinDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void dedayoutDateTimePicker_ValueChanged(object sender,EventArgs e) {
            dedayoutDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void screcvDateTimePicker_ValueChanged(object sender,EventArgs e) {
            screcvDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void cprecvDateTimePicker_ValueChanged(object sender,EventArgs e) {
            cprecvDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void ptrecvdDateTimePicker_ValueChanged(object sender,EventArgs e) {
            ptrecvdDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void ptbrcvdDateTimePicker_ValueChanged(object sender,EventArgs e) {
            ptbrcvdDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void kitrecvdDateTimePicker_ValueChanged(object sender,EventArgs e) {
            kitrecvdDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void toprodDateTimePicker_ValueChanged(object sender,EventArgs e) {
            toprodDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void tovendDateTimePicker_ValueChanged(object sender,EventArgs e) {
            tovendDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void warndateDateTimePicker_ValueChanged(object sender,EventArgs e) {
            warndateDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void prshpdteDateTimePicker_ValueChanged(object sender,EventArgs e) {
            prshpdteDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void prmsdateDateTimePicker_ValueChanged(object sender,EventArgs e) {
            prmsdateDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void shpdateDateTimePicker_ValueChanged(object sender,EventArgs e) {
            shpdateDateTimePicker.Format = DateTimePickerFormat.Long;
           
        }

        private void cstsvcdteDateTimePicker_ValueChanged(object sender,EventArgs e) {
            cstsvcdteDateTimePicker.Format = DateTimePickerFormat.Long;
            }

        private void comdateDateTimePicker_ValueChanged(object sender,EventArgs e) {
            comdateDateTimePicker.Format = DateTimePickerFormat.Long;
            }
        #endregion
        private void frmProdutn_Paint(object sender,PaintEventArgs e) {
            try { this.Text = "Production-" + lblSchoolName.Text.Trim() + " (" + this.Schcode.Trim() + ")"; } catch {

                }
            }

        private void btnCalcDeadLine_Click(object sender,EventArgs e) {
            if (!String.IsNullOrEmpty(dedayoutDateTimePicker.Value.ToString())) {
                int wks = 0;
                int days = 0;
                int.TryParse(txtWeeks.Text,out wks);
                int.TryParse(txtDays.Text,out days);
                var BusinessDay = new BusinessDays();

                var numDays = (wks * 5) + (days);
                var result = BusinessDay.BusDaySubtract(dedayoutDateTimePicker.Value,numDays);
                if (result != null) {
                    dedayinDateTimePicker.Value = result;
                    }
                } else { MessageBox.Show("Please enter a Deadline out Date."); }


            }

        private void btnCalCS_Click(object sender,EventArgs e) {
            if (!String.IsNullOrEmpty(kitrecvdDateTimePicker.Value.ToString())) {
                int wks = 0;
                int days = 0;
                int.TryParse(txtWeeks.Text,out wks);
                int.TryParse(txtDays.Text,out days);
                var BusinessDay = new BusinessDays();

                var numDays = (wks * 5) + (days);
                var result = BusinessDay.BusDayAdd(kitrecvdDateTimePicker.Value,numDays);
                if (result != null) {
                    dedayinDateTimePicker.Value = result;
                    }
                txtCalcResult.Text = result.ToShortDateString();

                }
            }

        private void btnDeadLineInfo_Click(object sender,EventArgs e) {
            var emailHelper = new EmailHelper();
            string subject = this.Schcode + " " + lblSchoolName.Text.Trim() + " " + "Memorybook Deadlines";
            string body = "Here is your Memory Book deadline information.<br/><br/>Pages due in plant " + dedayinDateTimePicker.Value.ToShortDateString() + "<br/>Delivery date " + dedayoutDateTimePicker.Value.ToShortDateString();
            EmailType type = EmailType.Blank;
            if (CurrentCompany == "MBC") {
                type = EmailType.Mbc;
                } else if (CurrentCompany == "MER") {
                type = EmailType.Meridian;
                }

            emailHelper.SendOutLookEmail(subject,AllEmails,"",body,EmailType.Mbc);
            }

        private void btnEmailPw_Click(object sender,EventArgs e) {
            var emailHelper = new EmailHelper();
            string subject = this.Schcode + " " + lblSchoolName.Text.Trim() + " " + "Memorybook Online Access";
            string body = "Here is your Memory Book Online Access information.<br/>(Online account available the following business day by noon central time)<br/><br/>Job Number - " + txtjobno.Text + "<br/>Adviser User Name - Adviser<br/>Adviser Password - " + txtadvpw.Text + "<br/>Staff User Name - Staff <br/>Staff Password - " + txtstfpw.Text + "<br/><br/>Please note the passwords are case sensitive<br/>You can copy and paste the link below into a web browser to take you to the online website to enter your password information.<br/><br/>www.memoryebooks.com";
            EmailType type = EmailType.Blank;
            if (CurrentCompany == "MBC") {
                type = EmailType.Mbc;
                } else if (CurrentCompany == "MER") {
                type = EmailType.Meridian;
                }

            emailHelper.SendOutLookEmail(subject,AllEmails,"",body,type);
            }

        private void btnBinderyEmail_Click(object sender,EventArgs e) {
            var sqlQuery = new SQLQuery();
            var queryString = " Select cust.schname,quotes.invno,produtn.prodno,produtn.nopages,covers.reqstdcpy,produtn.covertype,produtn.diecut,produtn.coilclr,produtn.prshpdte from cust inner join quotes on cust.schcode = quotes.schcodeleft join produtn on quotes.invno = produtn.invno left join covers on quotes.invno = covers.invno where cust.schcode = @Schcode and quotes.invno = @Invno";
            int vInvno = 0;
            int.TryParse(lblInvno.Text,out vInvno);
            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@Schcode",Schcode),
                 new SqlParameter("@Invno",vInvno)
            };
            List<BinderyInfo> result = (List<BinderyInfo>)sqlQuery.ExecuteReaderAsync<BinderyInfo>(CommandType.Text,queryString,parameters);
            if (result.Count < 1) {
                MessageBox.Show("Bindery information was not found.");
                return;
                }
            var body = "<strong>School Information<strong/><br/><br/>School Name " + result[0].Schname + "<br/>Production No. " + result[0].ProdNo + "<br/> No. of Pages " + result[0].NoPages + "<br/>Cover Type " + result[0].CoverType + "<br/>Die Cut " + result[0].Diecut + "<br/>Coil Color " + result[0].CoilClr + "<br/>Projected Ship Date " + result[0].ProjShpDate;
            var subject = "Memory Book company Vendor Information";
            var emailHelper = new EmailHelper();
            EmailType type = EmailType.Blank;
            if (CurrentCompany == "MBC") {
                type = EmailType.Mbc;
                } else if (CurrentCompany == "MER") {
                type = EmailType.Meridian;
                }
            emailHelper.SendOutLookEmail(subject,"production@memorybook.com","",body,type);


            }

        private void btnUpdateJob_Click(object sender,EventArgs e) {
            if (String.IsNullOrEmpty(txtPerfbind.Text)) {
                MessageBox.Show("Please enter binding information before issueing a job number.");
                return;
                }
            var vInvno = 0;
            int.TryParse(lblInvno.Text,out vInvno);
            var sqlQuery = new SQLQuery();
            var queryString = "Select Top(1) quotes.invno,produtn.jobno from quotes inner join produtn on quotes.invno=produtn.invno  where quotes.schcode=@Schcode and quotes.invno<@Invno Order by Invno";
            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@Schcode",Schcode),
                 new SqlParameter("@Invno",vInvno)
            };

            var result = sqlQuery.ExecuteReaderAsync(CommandType.Text,queryString,parameters);
            if (result.Rows.Count > 0) {
                var oldJobNo = result.Rows[0]["jobno"].ToString();
                txtjobno.Text = oldJobNo;
                } else {
                txtjobno.Text = "8" + lblProdNo.Text.Substring(1,5);

                }
            txtadvpw.Text = lblProdNo.Text.Substring(0,6);
            txtstfpw.Text = dsProdutn.cust.Rows[0]["schstate"].ToString().Substring(0,2) + lblcontryear.Text;



            }

        private void pg2_Click(object sender,EventArgs e) {

            }

        private void txtPerfbind_Leave(object sender, EventArgs e)
        {
            var row = (DataRowView)produtnBindingSource.Current;
           
            string prodno = lblProdNo.Text;
            switch (txtCompany.Text.ToUpper())
            {
                case "MBC":
                    if (!String.IsNullOrEmpty(prodno.Substring(0,2)))//has prodno
                    {
                        if (!String.IsNullOrEmpty(prodno))//letter changed not added
                        {
                            var vVal = prodno.Substring(0,1);
                            if (txtPerfbind.Text!= vVal) {
                            MessageBox.Show("Your Production Number (Binding) First Digit is not the same as this value... Press andy key to continue...It is being changed!", "Binding Type Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (txtPerfbind.Text == "C" || txtPerfbind.Text == "G" || txtPerfbind.Text == "K" || vVal == "H" || txtPerfbind.Text == "P" || txtPerfbind.Text == "S" || txtPerfbind.Text == "M") {
                                    if (vVal == "C" || vVal == "G" || vVal == "K" || vVal == "H" || vVal == "P" || vVal == "S" || vVal == "M") {

                                        //replacing binding
                                        lblProdNo.Text = txtPerfbind.Text + lblProdNo.Text.Substring(1).Trim();

                                        } else {
                                        //adding binding
                                       
                                            lblProdNo.Text = txtPerfbind.Text + lblProdNo.Text.Trim();
                                        //need to replace quote prono at some time.


                                        }
                                    }else { MessageBox.Show("Unknow binding!","Binding"); }

                                }




                       


                        }//if2

                    }//if 1
                    break;
                case "MER":

                    break;
            }

        }

        private void produtnBindingSource_CurrentChanged(object sender,EventArgs e) {
           
            }

        private void btnProdSrch_Click(object sender,EventArgs e) {
            var sqlQuery = new SQLQuery();
            string query = "Select prodno,invno,schcode from produtn where prodno=@prodno";
            var parameters = new SqlParameter[] { new SqlParameter("@prodno",txtProdNoSrch.Text) };
            var result = sqlQuery.ExecuteReaderAsync(CommandType.Text,query,parameters);
            if (result.Rows.Count > 0) {
                Schcode = result.Rows[0]["schcode"].ToString();
                Invno = int.Parse(result.Rows[0]["invno"].ToString());// will always have a invno
                Fill();
                }
            else{ MessageBox.Show("Record was not found.","Production Number Search",MessageBoxButtons.OK,MessageBoxIcon.Information); }
            }

        private void btnInvoiceSrch_Click(object sender,EventArgs e) {
            
            var sqlQuery = new SQLQuery();
            string query = "Select prodno,invno,schcode from produtn where invno=@invno";
            var parameters = new SqlParameter[] { new SqlParameter("@invno",txtInvoiceNoSrch.Text) };
            var result = sqlQuery.ExecuteReaderAsync(CommandType.Text,query,parameters);
            if (result.Rows.Count > 0) {
                Schcode = result.Rows[0]["schcode"].ToString();
                Invno = int.Parse(result.Rows[0]["invno"].ToString());// will always have a invno
                Fill();
                } else { MessageBox.Show("Record was not found.","Invoice Number Search",MessageBoxButtons.OK,MessageBoxIcon.Information); }
            }

        private void wipDetailDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataRowView row = (DataRowView)wipDetailBindingSource.Current;
            int id = (int)row["id"];
            int invno = (int)row["invno"];
            frmEditWip frmeditWip = new frmEditWip(id, invno);
            var result=frmeditWip.ShowDialog();
            if (result == DialogResult.OK)
            {
                wipDetailTableAdapter.Fill(dsProdutn.WipDetail, Invno);
            }
        }

        private void nocopiesTextBox1_Validating(object sender,CancelEventArgs e) {
            this.errorProvider1.SetError(nocopiesTextBox,"");
            int vInt;
            if (String.IsNullOrEmpty(nocopiesTextBox.Text))
            { nocopiesTextBox.Text = "0"; }
                if (!String.IsNullOrEmpty(nocopiesTextBox.Text) &&!int.TryParse(nocopiesTextBox.Text,out vInt)) {
           
                this.errorProvider1.SetError(nocopiesTextBox,"Only numbers are allowed.");
                e.Cancel = true;
                }
            }

        private void totsigsTextBox_Validating(object sender,CancelEventArgs e) {
            this.errorProvider1.SetError(totsigsTextBox,"");
            int vInt;
            if (String.IsNullOrEmpty(totsigsTextBox.Text) )
            { totsigsTextBox.Text = "0"; }
                if (!String.IsNullOrEmpty(totsigsTextBox.Text) && !int.TryParse(totsigsTextBox.Text,out vInt)) {
                
                this.errorProvider1.SetError(totsigsTextBox,"Only numbers are allowed.");
                e.Cancel = true;
                }else { e.Cancel = false; }
            }

        private void reqstdcpyTextBox_Validating(object sender,CancelEventArgs e) {
            this.errorProvider1.SetError(reqstdcpyTextBox,"");
            if (String.IsNullOrEmpty(reqstdcpyTextBox.Text))
            {
                reqstdcpyTextBox.Text = "0";
            }
                int vInt;
            if (!String.IsNullOrEmpty(reqstdcpyTextBox.Text) && !int.TryParse(reqstdcpyTextBox.Text,out vInt)) {

                this.errorProvider1.SetError(reqstdcpyTextBox,"Only numbers are allowed.");
                e.Cancel = true;
                }
            }

        private void txtnoPlates_Validating(object sender,CancelEventArgs e) {
            this.errorProvider1.SetError(txtnoPlates,"");
            if (String.IsNullOrEmpty(txtnoPlates.Text))
            { txtnoPlates.Text = "0"; }
                int vInt;
            if (!String.IsNullOrEmpty(txtnoPlates.Text) && !int.TryParse(txtnoPlates.Text,out vInt)) {

                this.errorProvider1.SetError(txtnoPlates,"Only numbers are allowed.");
                e.Cancel = true;
                }
            }

        private void textBox7_Validating(object sender,CancelEventArgs e) {
            this.errorProvider1.SetError(textBox7,"");
            int vInt;
            if (!String.IsNullOrEmpty(textBox7.Text) && !int.TryParse(textBox7.Text,out vInt)) {

                this.errorProvider1.SetError(textBox7,"Only numbers are allowed.");
                e.Cancel = true;
                }
            }
        #region Validation


        #endregion

        //nothing below here  
        }
    public class BinderyInfo
    {
        public string Schname { get; set; }
        public string CoverType { get; set; }
        public string ProdNo { get; set; }
        public int NoPages { get; set; }
        public int NoCopies { get; set; }
        public bool Diecut { get; set; }
        public string CoilClr { get; set; }
        public DateTime ProjShpDate { get; set; }
    }
 }


