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

using System.Data.SqlClient;
using Mbc5.Classes;
using Mbc5.LookUpForms;
using BindingModels;
using Exceptionless;
using Exceptionless.Models;
using Outlook= Microsoft.Office.Interop.Outlook;
namespace Mbc5.Forms.MemoryBook {
    public partial class frmProdutn : BaseClass.frmBase, INotifyPropertyChanged {
        private static string _ConnectionString = ConfigurationManager.ConnectionStrings["Mbc"].ConnectionString;
        private bool startup = true;
        public frmProdutn(UserPrincipal userPrincipal,int invno,string schcode) : base(new string[] { "SA","Administrator","MbcCS" },userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = invno;
            this.Schcode = schcode;

            }
        public frmProdutn(UserPrincipal userPrincipal) : base(new string[] { "SA","Administrator","MbcCS" },userPrincipal) {
            InitializeComponent();
           
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
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
                //partbkTableAdapter.Fill(dsProdutn.partbk,Schcode);
                //ptbkbTableAdapter.Fill(dsProdutn.ptbkb,Schcode);
                //wipgTableAdapter.Fill(dsProdutn.wipg,Schcode);
               
                FillWithInvno();
                if (dsProdutn.produtn.Count > 0) {
                    EnableAllControls(this);
                    } else { DisableControls(this); }
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
        private void FillWithInvno() {
            if (Invno != 0) {
                coversTableAdapter.Fill(dsProdutn.covers,Invno);
                coverdetailTableAdapter.Fill(dsProdutn.coverdetail,Invno);

              
                if (dsProdutn.covers.Count < 1) {
                   
                    DisableControls(specinstTextBox);
                    var aa = this.tbProdutn.TabPages[2];
                    } else { EnableAllControls(this.tbProdutn.TabPages[2]); }
                wipTableAdapter.Fill(dsProdutn.wip,Invno);
           
                //wipDetailTableAdapter.Fill(dsProdutn.WipDetail,Invno);
                //if (dsProdutn.wip.Count < 1) {
                //    DisableControls(this.tbProdutn.TabPages[3]);

                //    } else { EnableAllControls(this.tbProdutn.TabPages[3]); }


                }
            }


        public override void  Save() {
            switch (tbProdutn.SelectedIndex) {
                case 0:
                    SaveProdutn();
                    break;
                case 1:
                        {
                        SaveWip();
                        break;
                        }


                case 2:
                    MessageBox.Show("This function is not available in the invoice tab.","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    break;
                case 3:
                    //SavePayment();
                    break;

                }

            }
        private bool SaveProdutn() {
            bool retval = false;
            if (dsProdutn.produtn.Count > 0) {
           

                    try {
                        this.produtnBindingSource.EndEdit();
                       produtnTableAdapter.Update(dsProdutn.produtn);
                        //must refill so we get updated time stamp so concurrency is not thrown
                        this.Fill();
                    SetShipLabel();
                        retval = true;
                        } catch (DBConcurrencyException ex1) {
                    ex1.ToExceptionless()
                   .SetMessage("Production record failed to update:" + ex1.Message)
                   .Submit();
                        retval = false;
                        string errmsg = "Concurrency violation" + Environment.NewLine + ex1.Row.ItemArray[0].ToString();
                        //this.Log.Error(ex1,ex1.Message);

                        MessageBox.Show(errmsg);
                        } catch (Exception ex) {
                        retval = false;
                        MessageBox.Show("Production record failed to update:" + ex.Message);
                    ex.ToExceptionless()
                   .SetMessage("Production record failed to update:" + ex.Message)
                   .Submit();
                       
                        }
                    } else { retval = false; }
            
            return retval;

            }
        private bool SaveWip() {
            bool retval = false;
            if (dsProdutn.wip.Count > 0) {
              

                try {
                    this.wipBindingSource.EndEdit();
                    wipTableAdapter.Update(dsProdutn.wip); 
                    //must refill so we get updated time stamp so concurrency is not thrown
                    this.Fill();
                    retval = true;
                    } catch (DBConcurrencyException ex1) {
                    ex1.ToExceptionless()
                   .SetMessage("WIP record failed to update:" + ex1.Message)
                   .Submit();
                    retval = false;
                    string errmsg = "Concurrency violation" + Environment.NewLine + ex1.Row.ItemArray[0].ToString();
                   
                    MessageBox.Show(errmsg);
                    } catch (Exception ex) {
                    ex.ToExceptionless()
                   .SetMessage("WIP record failed to update:" + ex.Message)
                   .Submit();
                    retval = false;
                    MessageBox.Show("Wip record failed to update:" + ex.Message);
                 ;
                    }
                } else { retval = false; }
            
            return retval;

            }
        private bool SaveCovers() {
            bool retval = false;
            if (dsProdutn.covers.Count > 0) {


                try {
                    this.coversBindingSource.EndEdit();
                    coversTableAdapter.Update(dsProdutn.covers);
                    //must refill so we get updated time stamp so concurrency is not thrown
                    this.Fill();
                    retval = true;
                    } catch (DBConcurrencyException ex1) {
                    ex1.ToExceptionless()
                   .SetMessage("Covers record failed to update:" + ex1.Message)
                   .Submit();
                    retval = false;
                    string errmsg = "Concurrency violation" + Environment.NewLine + ex1.Row.ItemArray[0].ToString();
                
                    MessageBox.Show(errmsg);
                    } catch (Exception ex) {
                    ex.ToExceptionless()
                   .SetMessage("Coves record failed to update:" + ex.Message)
                   .Submit();
                    retval = false;
                  
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
                        if (!String.IsNullOrEmpty(prodno.Substring(0, 1)))//letter changed not added
                        {
                            MessageBox.Show("Your Production Number (Binding) First Digit is not the same as this value... Press andy key to continue...It is being changed!", "Binding Type Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         if(txtPerfbind.Text=="C"|| txtPerfbind.Text == "G"|| txtPerfbind.Text == "K"|| txtPerfbind.Text == "H"|| txtPerfbind.Text == "P"|| txtPerfbind.Text == "S"|| txtPerfbind.Text == "M"|| txtPerfbind.Text == "")
                            {
                                lblProdNo.Text = txtPerfbind.Text + lblProdNo.Text.Substring(0);
                                //need to replace quote prono at some time.
                            }


                        }//if2

                    }//if 1
                    break;
                case "MER":

                    break;
            }

        }

               

        private void produtnBindingSource_CurrentChanged(object sender,EventArgs e) {
            FillWithInvno();
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

        private void wipDetailDataGridView_CellContentClick(object sender,DataGridViewCellEventArgs e) {
            wipDetailDataGridView.CurrentCell.RowIndex;
            }


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


