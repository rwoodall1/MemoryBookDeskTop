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
using BaseClass.Classes;
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

            }
        private void frmProdutn_Load(object sender,EventArgs e) {
            

            Fill();
          
         
            
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

        #endregion
        #region "Methods"
       private void SetEmail() {
            SchEmail = dsProdutn.cust.Rows[0].IsNull("schemail") ? null : dsProdutn.cust.Rows[0]["schemail"].ToString().Trim();
            ContactEmail = dsProdutn.cust.Rows[0].IsNull("contemail") ? null : dsProdutn.cust.Rows[0]["contemail"].ToString().Trim();
           BcontactEmail = dsProdutn.cust.Rows[0].IsNull("bcontemail") ? null : dsProdutn.cust.Rows[0]["bcontemail"].ToString().Trim();
           CcontactEmail = dsProdutn.cust.Rows[0].IsNull("ccontemail") ? null : dsProdutn.cust.Rows[0]["ccontemail"].ToString().Trim();
            var vAllEmails = new List<string>();
            if (!String.IsNullOrEmpty(SchEmail) {
                vAllEmails.Add(SchEmail);
                }
            if (!String.IsNullOrEmpty(ContactEmail) {
                vAllEmails.Add(ContactEmail);
                }
            if (!String.IsNullOrEmpty(BcontactEmail) {
                vAllEmails.Add(BcontactEmail);
                }

            if (!String.IsNullOrEmpty(CcontactEmail) {
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
                partbkTableAdapter.Fill(dsProdutn.partbk,Schcode);
                ptbkbTableAdapter.Fill(dsProdutn.ptbkb,Schcode);
                wipgTableAdapter.Fill(dsProdutn.wipg,Schcode);
                wipTableAdapter.Fill(dsProdutn.wip,Schcode);
                
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
        public override void  Save() {
            switch (tbProdutn.SelectedIndex) {
                case 0:
                    SaveProdutn();
                    break;
                case 1:
                        {
                        //SaveSales();
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
        private void SaveProdutn() {


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
            if (!String.IsNullOrEmpty(kitrecvdDateTimePicker.Value.ToString())){
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
            string body = "Here is your Memory Book deadline information.<br/><br/>Pages due in plant " + dedayinDateTimePicker.Value.ToShortDateString() +"<br/>Delivery date " + dedayoutDateTimePicker.Value.ToShortDateString();
            EmailType type =EmailType.Blank;
            if (CurrentCompany == "MBC") {
                 type = EmailType.Mbc;
                }else if (CurrentCompany == "MER") {
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






        #endregion

        //nothing below here  
        }
    public class BinderyInfo {
        public string Schname { get; set; }
        public string CoverType { get; set; }
        public string ProdNo { get; set; }
        public int NoPages{get;set;}
        public int NoCopies { get; set; }
        public bool Diecut { get; set; }
        public string CoilClr { get; set; }
        public DateTime ProjShpDate { get; set; }

}


