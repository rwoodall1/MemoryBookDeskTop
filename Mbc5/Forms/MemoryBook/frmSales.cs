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
    public partial class frmSales : BaseClass.frmBase,INotifyPropertyChanged {
        public frmSales(UserPrincipal userPrincipal,int invno,string schcode) : base(new string[] { "SA", "Administrator", "MbcCS"}, userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = invno;
            this.Schcode = schcode;

            }
        #region "Properties"
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
        #endregion
        private void frmSales_Load(object sender,EventArgs e) {
            lblPCEach.DataBindings.Add("Text",this,"PrcEa",false,DataSourceUpdateMode.OnPropertyChanged);//bind 
            lblPCTotal.DataBindings.Add("Text",this,"PrcTot",false,DataSourceUpdateMode.OnPropertyChanged);//bind
            Fill();
            }
        private void Fill()
        {
            if (Schcode != null)
            {
             custTableAdapter.Fill(dsSales.cust, Schcode);
            quotesTableAdapter.Fill(dsSales.quotes,Schcode);
            }
            if (Invno != 0)
            {
                var pos=quotesBindingSource.Find("invno", 814533);
                if (pos > -1)
                {
                    quotesBindingSource.Position = pos;
                }
                else {
                    MessageBox.Show("Invoice number was not found.","Invoice#",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        }
            }
           

        }
        
      }
    }
