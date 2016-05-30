using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BaseClass.Classes;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Mbc5.Forms.MemoryBook {
    public partial class frmSales : BaseClass.Base,INotifyPropertyChanged {
        public frmSales(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS"}, userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            }
        public void InvokePropertyChanged(PropertyChangedEventArgs e) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this,e);
            }
        public event PropertyChangedEventHandler PropertyChanged;
        private Decimal nPrcTot =0;
        private Decimal nPrcEach = 0;
        private UserPrincipal ApplicationUser { get; set; }
        public Decimal PrcTot {
            get { return nPrcTot; }
            set {
                nPrcTot = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("PrcTot"));
                }
            }
        public Decimal PrcEa {
            get { return nPrcEach; }
            set {
                nPrcEach = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("PrcEach"));
                }
            }
       
        

        private void contryearTextBox_TextChanged(object sender,EventArgs e) {

            }

        private void frmSales_Load(object sender,EventArgs e) {
            lblPCEach.DataBindings.Add("Text",this,"PrcEa",false,DataSourceUpdateMode.OnPropertyChanged);//bind 
            lblPCTotal.DataBindings.Add("Text",this,"PrcTot",false,DataSourceUpdateMode.OnPropertyChanged);//bind



            }

 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblPCEach_Click(object sender, EventArgs e)
        {

        }

        private void prcorLabel_Click(object sender, EventArgs e)
        {

        }

        private void prcorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAllClrAmt_TextChanged(object sender, EventArgs e)
        {

        }

        private void msstanqtyLabel_Click(object sender, EventArgs e)
        {

        }

        private void pg1_Click(object sender, EventArgs e)
        {

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.invHstTableAdapter.Fill(this.dsSales.InvHst, ((decimal)(System.Convert.ChangeType(invnoToolStripTextBox.Text, typeof(decimal)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
    }
