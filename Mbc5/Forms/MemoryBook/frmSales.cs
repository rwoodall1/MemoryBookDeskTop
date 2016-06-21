﻿using System;
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
namespace Mbc5.Forms.MemoryBook {
    public partial class frmSales : BaseClass.frmBase, INotifyPropertyChanged {
        public frmSales(UserPrincipal userPrincipal, int invno, string schcode) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = invno;
            this.Schcode = schcode;

        }
        public frmSales(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = 0;
            this.Schcode = null;

        }
        private void frmSales_Load(object sender, EventArgs e)
        {
            lblPCEach.DataBindings.Add("Text", this, "PrcEa", false, DataSourceUpdateMode.OnPropertyChanged);//bind 
            lblPCTotal.DataBindings.Add("Text", this, "PrcTot", false, DataSourceUpdateMode.OnPropertyChanged);//bind
            Fill();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CalculateEach();
        }

        private void btnInvSrch_Click(object sender, EventArgs e)
        {

        }
        #region "Properties"
        public void InvokePropertyChanged(PropertyChangedEventArgs e) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private Decimal nPrcTot = 0;
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
        public List<Price> Pricing { get; set; }
        public BookOptionPrice BookOptionPricing{get;set;}
        public string CurPriceYr { get; set; } = null;
        #endregion
        #region "Methods"
        private void Fill()
        {
            if (Schcode != null)
            {
                custTableAdapter.Fill(dsSales.cust, Schcode);
                quotesTableAdapter.Fill(dsSales.quotes, Schcode);
            }
            if (Invno != 0)
            {
                var pos = quotesBindingSource.Find("invno", this.Invno);
                if (pos > -1)
                {
                    quotesBindingSource.Position = pos;
                }
                else
                {
                    MessageBox.Show("Invoice number was not found.", "Invoice#", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }


        }
        private void CalculateEach()
        {
            string vPage = "Pg" + txtNoPages.Text;
            int copies;
            var result = int.TryParse(txtNocopies.Text, out copies);
            if (!result)
            {
                 MessageBox.Show("Copies is not a numeral.");
                return;
            }
            
            var lowCopies = 0;
            if (copies > 125)
            {
                lowCopies = copies - 25;
            }


            if (this.Pricing == null|| CurPriceYr != txtBYear.Text)
            {
                
                GetBookPricing();
                //var vPricingRow = Pricing.Where(a => a.Copies >= lowCopies && a.Copies <= copies).ToList();
                //var aprice = vPricingRow.Select(x => x.GetType().GetProperty("Pg12").GetValue(x));
                var vBookPrice = Pricing.Where(a => a.Copies >= lowCopies && a.Copies <= copies).Select(x => x.GetType().GetProperty(vPage).GetValue(x)).ToList();
               decimal vFoundPrice  =(decimal) vBookPrice[0];
                decimal vdiscountamount = 1;
                if (chkPromo.Checked)
                {
                    vdiscountamount =1-((decimal)cmbYrDiscountAmt.SelectedItem);
                }
                vFoundPrice = vFoundPrice * vdiscountamount;
                lblPriceEach.Text = vFoundPrice.ToString("c");
            }
            else
            {
                //var vPricingRow = Pricing.Where(a => a.Copies >= lowCopies && a.Copies <= copies).ToList();
                //var aprice = vPricingRow.Select(x => x.GetType().GetProperty("Pg12").GetValue(x));
                //do it in one statement
                var vBookPrice = Pricing.Where(a => a.Copies >= lowCopies && a.Copies <= copies).Select(x => x.GetType().GetProperty(vPage).GetValue(x)).ToList();
                 decimal vFoundPrice =(decimal) vBookPrice[0];
                decimal vdiscountamount = 1;
                if (chkPromo.Checked)
                {
                    var discamt = System.Convert.ToDecimal(cmbYrDiscountAmt.SelectedItem);
                    vdiscountamount = (1 - discamt);
                }
                vFoundPrice = vFoundPrice * vdiscountamount;
                lblPriceEach.Text = vFoundPrice.ToString("c");
             
            }

            if (String.IsNullOrEmpty(txtPriceOverRide.Text)|| txtPriceOverRide.Text=="$0.00"|| txtPriceOverRide.Text=="$0")
            {
                try
                {
                    string price = lblPriceEach.Text.Replace("$", "");//must strip dollar sign
                    var vBookPrice=System.Convert.ToDecimal(price);
                    
                      lblBookTotal.Text = (vBookPrice * copies).ToString("c");
                                                        
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Book price is not in a decimal value.");
                }
              }
            else
            {
                var vBookPrice = System.Convert.ToDecimal(txtPriceOverRide.Text);
             
                    lblBookTotal.Text = (vBookPrice * copies).ToString();             
            }
          }
        private void BookCalc()
        {
            if (this.BookOptionPricing == null || CurPriceYr != txtBYear.Text)
            {
                //Hardback
                if (chkHardBack.Checked)
                {
                    lblHardbackAmt.Text = BookOptionPricing.Hardbk.ToString();
                }
                else { lblHardbackAmt.Text = null; }

                //Casebind
                if (chkCaseBind.Checked)
                {
                    lblCaseamt.Text = BookOptionPricing.Case.ToString();
                }
                else { lblCaseamt.Text = null; }
                //Perfect Bind
                if (chkPerfBind.Checked)
                {
                    lblPerfbindAmt.Text = BookOptionPricing.Perfectbind.ToString();
                }
                else { lblPerfbindAmt.Text = null; }
                //Spiral
                if (chkSpiral.Checked)
                {

                }
                //SaddleStitch
                if (chkSaddlStich.Checked)
                {

                }
                //Professional
                if (chkProfessional.Checked)
                {

                }
                //Convenient
                if (chkConv.Checked)
                {

                }
                //Yir
                if (chkYir.Checked)
                {

                }

                //Story
                if (chkStory.Checked)
                {

                }
                //AllClr
                if (chkAllClr.Checked)
                {

                }
                //Gloss
                if (chkGlossLam.Checked)
                {

                }
                if (chkMLaminate.Checked)
                {

                }



            }

        }
        private void GetBookPricing()
        {
            this.CurPriceYr = txtBYear.Text;
            
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT * From Pricing where Type=@Type and yr=@Yr order by copies", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Yr", txtBYear.Text);//base price yr
            if (chkAllClr.Checked)
            {
                cmd.Parameters.AddWithValue("@Type", "Color");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Type", "Base");
            }
           

            List<Price> PriceList=new List<Price>();
         
            try
            {

                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Price vprice = new Price()
                    {
                        Copies = rdr.GetInt32(rdr.GetOrdinal("Copies")),
                       
                        Pg12 = rdr.GetDecimal(rdr.GetOrdinal("Pg12")),
                        Pg16 = rdr.GetDecimal(rdr.GetOrdinal("Pg16")),
                        Pg20 = rdr.GetDecimal(rdr.GetOrdinal("Pg20")),
                        Pg24 = rdr.GetDecimal(rdr.GetOrdinal("Pg24")),
                        Pg28 = rdr.GetDecimal(rdr.GetOrdinal("Pg28")),
                        Pg32 = rdr.GetDecimal(rdr.GetOrdinal("Pg32")),
                        Pg36 = rdr.GetDecimal(rdr.GetOrdinal("Pg36")),
                        Pg40 = rdr.GetDecimal(rdr.GetOrdinal("Pg40")),
                        Pg44 = rdr.GetDecimal(rdr.GetOrdinal("Pg44")),
                        Pg48 = rdr.GetDecimal(rdr.GetOrdinal("Pg48")),
                        Pg52 = rdr.GetDecimal(rdr.GetOrdinal("Pg52")),
                        Pg56 = rdr.GetDecimal(rdr.GetOrdinal("Pg56")),
                        Pg60 = rdr.GetDecimal(rdr.GetOrdinal("Pg60")),
                        Pg64 = rdr.GetDecimal(rdr.GetOrdinal("Pg64")),
                        Pg68 = rdr.GetDecimal(rdr.GetOrdinal("Pg68")),
                        Pg72 = rdr.GetDecimal(rdr.GetOrdinal("Pg72")),
                        Pg76 = rdr.GetDecimal(rdr.GetOrdinal("Pg76")),
                        Pg80 = rdr.GetDecimal(rdr.GetOrdinal("Pg80")),
                        Pg84 = rdr.GetDecimal(rdr.GetOrdinal("Pg84")),
                        Pg88 = rdr.GetDecimal(rdr.GetOrdinal("Pg88")),
                        Pg92 = rdr.GetDecimal(rdr.GetOrdinal("Pg92")),
                        Pg96 = rdr.GetDecimal(rdr.GetOrdinal("Pg96")),
                        Pg100 = rdr.GetDecimal(rdr.GetOrdinal("Pg100")),
                        Pg104 = rdr.GetDecimal(rdr.GetOrdinal("Pg104")),
                        Pg108 = rdr.GetDecimal(rdr.GetOrdinal("Pg108")),
                        Pg112 = rdr.GetDecimal(rdr.GetOrdinal("Pg112")),
                        Pg116 = rdr.GetDecimal(rdr.GetOrdinal("Pg116")),
                        Pg120 = rdr.GetDecimal(rdr.GetOrdinal("Pg120")),
                        Pg124 = rdr.GetDecimal(rdr.GetOrdinal("Pg124")),
                        Pg128 = rdr.GetDecimal(rdr.GetOrdinal("Pg128")),
                        Pg132 = rdr.GetDecimal(rdr.GetOrdinal("Pg132")),
                        Pg136 = rdr.GetDecimal(rdr.GetOrdinal("Pg136")),
                        Pg140 = rdr.GetDecimal(rdr.GetOrdinal("Pg140")),
                        Pg144 = rdr.GetDecimal(rdr.GetOrdinal("Pg144")),
                        Pg148 = rdr.GetDecimal(rdr.GetOrdinal("Pg148")),
                        Pg152 = rdr.GetDecimal(rdr.GetOrdinal("Pg152")),
                        Pg156 = rdr.GetDecimal(rdr.GetOrdinal("Pg156")),
                        Pg160 = rdr.GetDecimal(rdr.GetOrdinal("Pg160")),
                        Pg164 = rdr.GetDecimal(rdr.GetOrdinal("Pg164")),
                        Pg168 = rdr.GetDecimal(rdr.GetOrdinal("Pg168")),
                        Pg172 = rdr.GetDecimal(rdr.GetOrdinal("Pg172")),
                        Pg176 = rdr.GetDecimal(rdr.GetOrdinal("Pg176")),
                        Pg180 = rdr.GetDecimal(rdr.GetOrdinal("Pg180")),
                        Pg184 = rdr.GetDecimal(rdr.GetOrdinal("Pg184")),
                        Pg188 = rdr.GetDecimal(rdr.GetOrdinal("Pg188")),
                        Pg192 = rdr.GetDecimal(rdr.GetOrdinal("Pg192")),
                        Pg196 = rdr.GetDecimal(rdr.GetOrdinal("Pg196")),
                        Pg200 = rdr.GetDecimal(rdr.GetOrdinal("Pg200")),
                        Pg204 = rdr.GetDecimal(rdr.GetOrdinal("Pg204")),
                        Pg208 = rdr.GetDecimal(rdr.GetOrdinal("Pg208")),
                        Pg212 = rdr.GetDecimal(rdr.GetOrdinal("Pg212")),
                        Pg216 = rdr.GetDecimal(rdr.GetOrdinal("Pg216")),
                        Pg220 = rdr.GetDecimal(rdr.GetOrdinal("Pg220")),
                        Pg224 = rdr.GetDecimal(rdr.GetOrdinal("Pg224")),
                        Pg228 = rdr.GetDecimal(rdr.GetOrdinal("Pg228")),
                        Pg232 = rdr.GetDecimal(rdr.GetOrdinal("Pg232")),
                        Pg236 = rdr.GetDecimal(rdr.GetOrdinal("Pg236")),
                        Pg240 = rdr.GetDecimal(rdr.GetOrdinal("Pg240")),
                        Pg244 = rdr.GetDecimal(rdr.GetOrdinal("Pg244")),
                        Pg248 = rdr.GetDecimal(rdr.GetOrdinal("Pg248")),
                        Pg252 = rdr.GetDecimal(rdr.GetOrdinal("Pg252")),
                        Pg256 = rdr.GetDecimal(rdr.GetOrdinal("Pg256")),
                        Pg260 = rdr.GetDecimal(rdr.GetOrdinal("Pg260")),
                        Pg264 = rdr.GetDecimal(rdr.GetOrdinal("Pg264")),
                        Pg268 = rdr.GetDecimal(rdr.GetOrdinal("Pg268")),
                        Pg272 = rdr.GetDecimal(rdr.GetOrdinal("Pg272")),
                        Pg276 = rdr.GetDecimal(rdr.GetOrdinal("Pg276")),
                        Pg280 = rdr.GetDecimal(rdr.GetOrdinal("Pg280")),
                        Pg284 = rdr.GetDecimal(rdr.GetOrdinal("Pg284")),
                        Pg288 = rdr.GetDecimal(rdr.GetOrdinal("Pg288")),
                        Pg292 = rdr.GetDecimal(rdr.GetOrdinal("Pg292")),
                        Pg296 = rdr.GetDecimal(rdr.GetOrdinal("Pg296")),
                        Pg300 = rdr.GetDecimal(rdr.GetOrdinal("Pg300")),
                        Pg304 = rdr.GetDecimal(rdr.GetOrdinal("Pg304")),
                        Pg308 = rdr.GetDecimal(rdr.GetOrdinal("Pg308")),
                        Pg312 = rdr.GetDecimal(rdr.GetOrdinal("Pg312")),
                        Pg316 = rdr.GetDecimal(rdr.GetOrdinal("Pg316")),
                        Pg320 = rdr.GetDecimal(rdr.GetOrdinal("Pg320")),
                        Pg324 = rdr.GetDecimal(rdr.GetOrdinal("Pg324")),
                        Pg328 = rdr.GetDecimal(rdr.GetOrdinal("Pg328")),
                        Pg332 = rdr.GetDecimal(rdr.GetOrdinal("Pg332")),
                        //Pg336 = rdr.GetDecimal(rdr.GetOrdinal("Pg336")),
                        //Pg340 = rdr.GetDecimal(rdr.GetOrdinal("Pg340")),
                        //Pg344 = rdr.GetDecimal(rdr.GetOrdinal("Pg344")),
                        //Pg348 = rdr.GetDecimal(rdr.GetOrdinal("Pg348")),
                        //Pg352 = rdr.GetDecimal(rdr.GetOrdinal("Pg352")),
                        //Pg356 = rdr.GetDecimal(rdr.GetOrdinal("Pg356")),
                        //Pg360 = rdr.GetDecimal(rdr.GetOrdinal("Pg360"))

                    };
                    PriceList.Add(vprice);
                 
                    this.Pricing = PriceList;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal("Failed to retrieve pricing:" + ex.Message);
                MessageBox.Show("There was an error retrieving pricing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void GetBookOptionPricing()
        {
            this.CurPriceYr = txtBYear.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT * From BookOptionPricing where yr=@Yr", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Yr", txtBYear.Text);//base price yr
            
            try
            {

                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BookOptionPrice vOptionPrice = new BookOptionPrice()
                    {
                       Yr = rdr.GetOrdinal("Yr").ToString(),
                       Case = rdr.GetDecimal(rdr.GetOrdinal("Case")),
                        Professional = rdr.GetDecimal(rdr.GetOrdinal("Professional")),
                       Convenient= rdr.GetDecimal(rdr.GetOrdinal("Convenient")),
                       Specialcvr= rdr.GetDecimal(rdr.GetOrdinal("Specialcvr")),
                       Lamination= rdr.GetDecimal(rdr.GetOrdinal("Lamination")),
                       Perfectbind= rdr.GetDecimal(rdr.GetOrdinal("Perfectbind")),
                       Customized= rdr.GetDecimal(rdr.GetOrdinal("Customized")),
                       Hardbk= rdr.GetDecimal(rdr.GetOrdinal("Hardbk")),
                       Foil= rdr.GetDecimal(rdr.GetOrdinal("Foil")),
                       Ink= rdr.GetDecimal(rdr.GetOrdinal("Ink")),
                       Spiral= rdr.GetDecimal(rdr.GetOrdinal("Spiral")),
                       Allclr= rdr.GetDecimal(rdr.GetOrdinal("Allclr")),
                       Theme= rdr.GetDecimal(rdr.GetOrdinal("Theme")),
                       Story= rdr.GetDecimal(rdr.GetOrdinal("Story")),
                       Yir= rdr.GetDecimal(rdr.GetOrdinal("Yir")),
                       Supplement= rdr.GetDecimal(rdr.GetOrdinal("Supplement")),
                       Laminationhrd= rdr.GetDecimal(rdr.GetOrdinal("Laminationhrd")),
                       Laminationsft= rdr.GetDecimal(rdr.GetOrdinal("Laminationsft"))

                    };
                    this.BookOptionPricing = vOptionPrice;

                }
            }catch(Exception ex)
            {
                Log.Fatal("Error retrieving Book Option Pricing" + ex.Message);
                MessageBox.Show("There was an error retrieving Book Option Pricing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           } 
        
        #endregion

        private void chkAllClr_CheckedChanged(object sender, EventArgs e)
        {
            GetBookPricing();
            CalculateEach();
        }

        private void chkPromo_CheckedChanged(object sender, EventArgs e)
        {
            CalculateEach();
        }

        private void txtBYear_TextChanged(object sender, EventArgs e)
        {
            GetBookPricing();
            GetBookOptionPricing();
            CalculateEach();
        }
    }


    }
