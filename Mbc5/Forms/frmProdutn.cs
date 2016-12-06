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

        #endregion
        #region "Methods"
       
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
            string subject = this.Schcode + " " + lblSchoolName.Text + " " + "Memorybook Deadlines";
            string body = "Here is your Memory Book deadline information." + Environment.NewLine+ System.Environment.NewLine+ System.Environment.NewLine + "Pages due in plant " + dedayinDateTimePicker.Value.ToShortDateString() + System.Environment.NewLine+ "Delivery date " + dedayoutDateTimePicker.Value.ToShortDateString();
            EmailType type =EmailType.Blank;
            if (CurrentCompany == "MBC") {
                 type = EmailType.Mbc;
                }else if (CurrentCompany == "MER") {
                 type = EmailType.Meridian;
                }

            emailHelper.SendEmail(subject,,,body,EmailType.Mbc)
            }






        #endregion

        //nothing below here  
        }
}

    
