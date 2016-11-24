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
using BaseClase.Classes;
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
            //if (ApplicationUser.Roles.Contains("SA") || ApplicationUser.Roles.Contains("Administrator")) {
            //    this.dp1descComboBox.ContextMenuStrip = this.mnuEditLkUp;
            //    }
         
            
            }
     
        #region "Properties"
        public void InvokePropertyChanged(PropertyChangedEventArgs e) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this,e);
            }
        public event PropertyChangedEventHandler PropertyChanged;
        private UserPrincipal ApplicationUser { get; set; }
        private bool StartUp { get; set; }
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
            //switch (tabSales.SelectedIndex) {
            //    case 0:
            //    case 1:
            //            {
            //            SaveSales();
            //                break;
            //            }

                   
            //    case 2:
            //        MessageBox.Show("This function is not available in the invoice tab.","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //        break;
            //    case 3:
            //        SavePayment();
            //        break;
              
            //    }

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

        #endregion

        //nothing below here  
        }
}
    
