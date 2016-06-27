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
 private void chkPromo_CheckedChanged(object sender, EventArgs e)
        {
            //CalculateEach();
        }

        private void chkHardBack_Click(object sender,EventArgs e) {
            BookCalc();
            }

        private void chkAllClr_Click(object sender,EventArgs e) {
            GetBookPricing();
            CalculateEach();
            BookCalc();
            }

        private void chkPromo_Click(object sender,EventArgs e) {
            CalculateEach();
            }

        private void txtBYear_Leave(object sender,EventArgs e) {
            GetBookPricing();
            GetBookOptionPricing();
            CalculateEach();
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
                if(!ValidateCopies() || !ValidatePageCount())
                {
                   return;
                }
            string vPage = "Pg" + txtNoPages.Text;
            int copies;
            int calcCopies;
            var result = int.TryParse(txtNocopies.Text, out copies);
            if (copies < 100)//min is 100 for calculating
            {
                calcCopies = 100;
            }
            else { calcCopies = copies; }
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
            else
            {
                lowCopies = 100;
            }
            if (copies > 1800)
            {
                MessageBox.Show("Copies are more than the maximum that can be calculated. Contact your supervisor, quantity is being reset at 1800.", "Copies", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtNocopies.Text = "1800";
                lowCopies = 1800;
                calcCopies = 1800;
            }

            if (this.Pricing == null|| CurPriceYr != txtBYear.Text)
            {                
                GetBookPricing();
                if (this.Pricing == null)
                    { MessageBox.Show("Pricing was not found.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Log.Error("Pricing was not found:Year-" + txtBYear.Text);
                    return;
                    }
            }
           
            //var vPricingRow = Pricing.Where(a => a.Copies >= lowCopies && a.Copies <= copies).ToList();
            //var aprice = vPricingRow.Select(x => x.GetType().GetProperty("Pg12").GetValue(x));

            var vBookPrice = Pricing.Where(a => a.Copies >= lowCopies && a.Copies <= calcCopies).Select(x => x.GetType().GetProperty(vPage).GetValue(x)).ToList();
            if (vBookPrice.Count < 1)
                {
                return;
                }
            decimal vFoundPrice = (decimal)vBookPrice[0];
            decimal vdiscountamount = 1;
            if ( cmbYrDiscountAmt.SelectedIndex >0)
                {
                  decimal promAmt = 0;
                   bool proAmtResult = decimal.TryParse(cmbYrDiscountAmt.SelectedItem.ToString(),out promAmt);
               
                vdiscountamount = 1 -promAmt;
                }
            vFoundPrice = vFoundPrice * vdiscountamount;
            lblPriceEach.Text = vFoundPrice.ToString("c");

            if (String.IsNullOrEmpty(txtPriceOverRide.Text)|| txtPriceOverRide.Text=="$0.00"|| txtPriceOverRide.Text=="$0")
            {
                try
                {
                    string price = lblPriceEach.Text.Replace("$", "");//must strip dollar sign
                   var thePrice=System.Convert.ToDecimal(price);
                    
                      lblBookTotal.Text = (thePrice * copies).ToString("c");
                                                        
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Book price is not in a decimal value.");
                }
              }
            else
            {
                try
                    {
                     var thePrice = System.Convert.ToDecimal(txtPriceOverRide.Text);
                     lblBookTotal.Text = (thePrice * copies).ToString("c");
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show("Book price is not in a decimal value.");
                    }

                }
            BookCalc();
          }
        private void CalcInk() {


            }
        private void BookCalc()
        {
            if(!ValidateCopies() || !ValidatePageCount())
                {
                   return;
                }
            if (BookOptionPricing == null)
                { GetBookOptionPricing(); }
            if(CurPriceYr != txtBYear.Text)
                { CalculateEach(); }
            int numberOfCopies=0;
            int numberOfPages = 0;
           var parseresult = int.TryParse(txtNocopies.Text,out numberOfCopies);
            var parseresult1 = int.TryParse(txtNoPages.Text,out numberOfPages);
            if (!parseresult)
                { MessageBox.Show("Number of copies is not valid!","Copies",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
                }
            if (!parseresult1)
                {
                MessageBox.Show("Number of pages is not valid!","Pages",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
                }
            if (this.BookOptionPricing != null && CurPriceYr == txtBYear.Text)
            {
                
                //Hardback
                decimal HardBack =0;
                if (chkHardBack.Checked)
                {
                    HardBack = BookOptionPricing.Hardbk * numberOfCopies;
                    lblHardbackAmt.Text = HardBack.ToString();
                    CalcInk();
                    }
                else { lblHardbackAmt.Text = null;
                    HardBack = 0; }
                //Casebind
                decimal Casebind = 0;
                if (chkCaseBind.Checked)
                    {
                    Casebind = BookOptionPricing.Case * numberOfCopies;
                    lblCaseamt.Text = Casebind.ToString();
                    CalcInk();
                    }
                else
                    {
                    lblCaseamt.Text = null;
                    Casebind = 0;
                    }
                //Check if harback and case both not checked
                if(!chkHardBack.Checked && !chkCaseBind.Checked)
                    {
                    CalcInk();
                    }
                //Perfect Bind
                decimal Perfectbind = 0;
                if (chkPerfBind.Checked)
                {
                    Perfectbind = BookOptionPricing.Perfectbind * numberOfCopies;
                    lblPerfbindAmt.Text = Perfectbind.ToString();
                    
                }
                else { lblPerfbindAmt.Text = null;
                    Perfectbind = 0;
                    }
                //Spiral
                decimal Spiral = 0;
                if (chkSpiral.Checked)
                {
                    Spiral = (BookOptionPricing.Spiral * numberOfCopies);
                    lblSpiralAmt.Text = Spiral.ToString(); 
                }
                else{ lblSpiralAmt.Text = null;
                    Spiral = 0;
                    }
                //SaddleStitch
               decimal SaddleStitch = 0;
                if (chkSaddlStitch.Checked)
                {
                    SaddleStitch = (BookOptionPricing.SaddleStitch*numberOfCopies) ;
                    lblSaddleAmt.Text = SaddleStitch.ToString();
                    
                    }
                else{ lblSaddleAmt.Text = null;
                    SaddleStitch = 0;
                    }

                //Professional
                decimal Professional = 0;
                if (chkProfessional.Checked)
                {    Professional =(BookOptionPricing.Professional*numberOfPages) ;
                    lblProfAmt.Text = Professional.ToString();
                    
                    }
                else { lblProfAmt.Text = null;
                    Professional = 0; }

                //Convenient
                decimal Convenient = 0;
                if (chkConv.Checked)
                {
                    Convenient =(BookOptionPricing.Convenient*numberOfPages);
                    lblConvAmt.Text = Convenient.ToString();
                    
                    }
                else{ lblConvAmt.Text = null;
                    Convenient = 0;
                    }
                //Yir
                decimal Yir = 0;
                if (chkYir.Checked)
                {
                    Yir = (BookOptionPricing.Yir * numberOfCopies);
                    lblYir.Text =Yir.ToString();   
                }
                else
                    { lblYir.Text = null;
                    Yir = 0;
                    }

                //Story
                decimal Story = 0;
                if (chkStory.Checked)
                {
                     Story = (BookOptionPricing.Story);
                    lblStoryAmt.Text = Story.ToString();
                    
                    }
                else
                    { lblStoryAmt.Text = null;
                    Story = 0;
                    }
                             
                //Gloss
                decimal Gloss = 0;
                if (chkGlossLam.Checked)
                {
                    Gloss =(BookOptionPricing.Lamination*numberOfCopies) ;
                    lblLaminateAmt.Text = Gloss.ToString();
                    
                    }
                else
                    { lblLaminateAmt.Text = null;
                    Gloss = 0;
                    }
                //Lam
                decimal Laminationsft = 0;
                if (chkMLaminate.Checked)
                {
                    Laminationsft =(BookOptionPricing.Laminationsft*numberOfCopies);
                    lblMLaminateAmt.Text = Laminationsft.ToString();
                    
                    }
                else
                    { lblMLaminateAmt.Text = null;
                    Laminationsft = 0;
                    }
                //convert rest of info from strings to decimals for calculations
                bool vParseResult;
                decimal BookTotal = 0;
                decimal SpecCvrTot = 0;
                decimal FoilTot=0;
                decimal ClrPgTot = 0;
                decimal MiscTot = 0;
                decimal Desc1Tot = 0;
                decimal Desc3Tot = 0;
                decimal Desc4Tot = 0;
               
                vParseResult = decimal.TryParse(lblBookTotal.Text.ToString().Replace("$",""),out BookTotal);
                vParseResult = decimal.TryParse(lblSpeccvr.Text,out SpecCvrTot);
                vParseResult = decimal.TryParse(txtFoilAd.Text,out FoilTot);
                vParseResult = decimal.TryParse(txtClrTot.Text,out ClrPgTot);
                vParseResult = decimal.TryParse(txtMisc.Text,out MiscTot);
                vParseResult = decimal.TryParse(txtDesc1amt.Text,out Desc1Tot);
                vParseResult = decimal.TryParse(txtDesc3tot.Text,out Desc3Tot);
                vParseResult = decimal.TryParse(txtDesc4tot.Text,out Desc4Tot);



                decimal SubTotal = (BookTotal+HardBack + Casebind + Perfectbind + Spiral + SaddleStitch + Professional + Convenient + Yir + Story  + Gloss + Laminationsft+SpecCvrTot+FoilTot+ClrPgTot+MiscTot+Desc1Tot+Desc3Tot+Desc4Tot);

              lblsubtot.Text = SubTotal.ToString("c");
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

                        Pg12 = rdr["Pg12"] == DBNull.Value ? 0 : (decimal)rdr["Pg12"],        
                        Pg16 = rdr["Pg16"] == DBNull.Value ? 0 : (decimal)rdr["Pg16"],
                        Pg20 = rdr["Pg20"] == DBNull.Value ? 0 : (decimal)rdr["Pg20"],
                        Pg24 = rdr["Pg24"] == DBNull.Value ? 0 : (decimal)rdr["Pg24"],
                        Pg28 = rdr["Pg28"] == DBNull.Value ? 0 : (decimal)rdr["Pg28"],
                        Pg32 = rdr["Pg32"] == DBNull.Value ? 0 : (decimal)rdr["Pg32"],
                        Pg36 = rdr["Pg36"] == DBNull.Value ? 0 : (decimal)rdr["Pg36"],
                        Pg40 = rdr["Pg40"] == DBNull.Value ? 0 : (decimal)rdr["Pg40"],
                        Pg44 = rdr["Pg44"] == DBNull.Value ? 0 : (decimal)rdr["Pg44"],
                        Pg48 = rdr["Pg48"] == DBNull.Value ? 0 : (decimal)rdr["Pg48"],
                        Pg52 = rdr["Pg52"] == DBNull.Value ? 0 : (decimal)rdr["Pg52"],
                        Pg56 = rdr["Pg56"] == DBNull.Value ? 0 : (decimal)rdr["Pg56"],
                        Pg60 = rdr["Pg60"] == DBNull.Value ? 0 : (decimal)rdr["Pg60"],
                        Pg64 = rdr["Pg64"] == DBNull.Value ? 0 : (decimal)rdr["Pg64"],
                        Pg68 = rdr["Pg68"] == DBNull.Value ? 0 : (decimal)rdr["Pg68"],
                        Pg72 = rdr["Pg72"] == DBNull.Value ? 0 : (decimal)rdr["Pg72"],
                        Pg76 = rdr["Pg76"] == DBNull.Value ? 0 : (decimal)rdr["Pg76"],
                        Pg80 = rdr["Pg80"] == DBNull.Value ? 0 : (decimal)rdr["Pg80"],
                        Pg84 = rdr["Pg84"] == DBNull.Value ? 0 : (decimal)rdr["Pg84"],
                        Pg88 = rdr["Pg88"] == DBNull.Value ? 0 : (decimal)rdr["Pg88"],
                        Pg92 = rdr["Pg92"] == DBNull.Value ? 0 : (decimal)rdr["Pg92"],
                        Pg96 = rdr["Pg96"] == DBNull.Value ? 0 : (decimal)rdr["Pg96"],
                        Pg100 = rdr["Pg100"] == DBNull.Value ? 0 : (decimal)rdr["Pg100"],
                        Pg104 = rdr["Pg104"] == DBNull.Value ? 0 : (decimal)rdr["Pg104"],
                        Pg108 = rdr["Pg108"] == DBNull.Value ? 0 : (decimal)rdr["Pg108"],
                        Pg112 = rdr["Pg112"] == DBNull.Value ? 0 : (decimal)rdr["Pg112"],
                        Pg116 = rdr["Pg116"] == DBNull.Value ? 0 : (decimal)rdr["Pg116"],
                        Pg120 = rdr["Pg120"] == DBNull.Value ? 0 : (decimal)rdr["Pg120"],
                        Pg124 = rdr["Pg124"] == DBNull.Value ? 0 : (decimal)rdr["Pg124"],
                        Pg128 = rdr["Pg128"] == DBNull.Value ? 0 : (decimal)rdr["Pg128"],
                        Pg132 = rdr["Pg132"]== DBNull.Value ? 0 : (decimal)rdr["Pg132"],
                        Pg136 = rdr["Pg136"] == DBNull.Value ? 0 : (decimal)rdr["Pg136"],
                        Pg140 = rdr["Pg140"] == DBNull.Value ? 0 : (decimal)rdr["Pg140"],
                        Pg144 = rdr["Pg144"] == DBNull.Value ? 0 : (decimal)rdr["Pg144"],
                        Pg148 = rdr["Pg148"] == DBNull.Value ? 0 : (decimal)rdr["Pg148"],
                        Pg152 = rdr["Pg152"] == DBNull.Value ? 0 : (decimal)rdr["Pg152"],
                        Pg156 = rdr["Pg156"] == DBNull.Value ? 0 : (decimal)rdr["Pg156"],
                        Pg160 = rdr["Pg160"] == DBNull.Value ? 0 : (decimal)rdr["Pg160"],
                        Pg164 = rdr["Pg164"] == DBNull.Value ? 0 : (decimal)rdr["Pg164"],
                        Pg168 = rdr["Pg168"] == DBNull.Value ? 0 : (decimal)rdr["Pg168"],
                        Pg172 = rdr["Pg172"] == DBNull.Value ? 0 : (decimal)rdr["Pg172"],
                        Pg176 = rdr["Pg176"] == DBNull.Value ? 0 : (decimal)rdr["Pg176"],
                        Pg180 = rdr["Pg180"] == DBNull.Value ? 0 : (decimal)rdr["Pg180"],
                        Pg184 = rdr["Pg184"] == DBNull.Value ? 0 : (decimal)rdr["Pg184"],
                        Pg188 = rdr["Pg188"] == DBNull.Value ? 0 : (decimal)rdr["Pg188"],
                        Pg192 = rdr["Pg192"] == DBNull.Value ? 0 : (decimal)rdr["Pg192"],
                        Pg196 = rdr["Pg196"] == DBNull.Value ? 0 : (decimal)rdr["Pg196"],
                        Pg200 = rdr["Pg200"] == DBNull.Value ? 0 : (decimal)rdr["Pg200"],
                        Pg204 = rdr["Pg204"] == DBNull.Value ? 0 : (decimal)rdr["Pg204"],
                        Pg208 = rdr["Pg208"] == DBNull.Value ? 0 : (decimal)rdr["Pg208"],
                        Pg212 = rdr["Pg212"] == DBNull.Value ? 0 : (decimal)rdr["Pg212"],
                        Pg216 = rdr["Pg216"] == DBNull.Value ? 0 : (decimal)rdr["Pg216"],
                        Pg220 = rdr["Pg220"] == DBNull.Value ? 0 : (decimal)rdr["Pg220"],
                        Pg224 = rdr["Pg224"] == DBNull.Value ? 0 : (decimal)rdr["Pg224"],
                        Pg228 = rdr["Pg228"] == DBNull.Value ? 0 : (decimal)rdr["Pg228"],
                        Pg232 = rdr["Pg232"] == DBNull.Value ? 0 : (decimal)rdr["Pg232"],
                        Pg236 = rdr["Pg236"] == DBNull.Value ? 0 : (decimal)rdr["Pg236"],
                        Pg240 = rdr["Pg240"] == DBNull.Value ? 0 : (decimal)rdr["Pg240"],
                        Pg244 = rdr["Pg244"] == DBNull.Value ? 0 : (decimal)rdr["Pg244"],
                        Pg248 = rdr["Pg248"] == DBNull.Value ? 0 : (decimal)rdr["Pg248"],
                        Pg252 = rdr["Pg252"] == DBNull.Value ? 0 : (decimal)rdr["Pg252"],
                        Pg256 = rdr["Pg256"] == DBNull.Value ? 0 : (decimal)rdr["Pg256"],
                        Pg260 = rdr["Pg260"] == DBNull.Value ? 0 : (decimal)rdr["Pg260"],
                        Pg264 = rdr["Pg264"] == DBNull.Value ? 0 : (decimal)rdr["Pg264"],
                        Pg268 = rdr["Pg268"] == DBNull.Value ? 0 : (decimal)rdr["Pg268"],
                        Pg272 = rdr["Pg272"] == DBNull.Value ? 0 : (decimal)rdr["Pg272"],
                        Pg276 = rdr["Pg276"] == DBNull.Value ? 0 : (decimal)rdr["Pg276"],
                        Pg280 = rdr["Pg280"] == DBNull.Value ? 0 : (decimal)rdr["Pg280"],
                        Pg284 = rdr["Pg284"] == DBNull.Value ? 0 : (decimal)rdr["Pg284"],
                        Pg288 = rdr["Pg288"] == DBNull.Value ? 0 : (decimal)rdr["Pg288"],
                        Pg292 = rdr["Pg292"] == DBNull.Value ? 0 : (decimal)rdr["Pg292"],
                        Pg296 = rdr["Pg296"] == DBNull.Value ? 0 : (decimal)rdr["Pg296"],
                        Pg300 = rdr["Pg300"] == DBNull.Value ? 0 : (decimal)rdr["Pg300"],
                        Pg304 = rdr["Pg304"] == DBNull.Value ? 0 : (decimal)rdr["Pg304"],
                        Pg308 = rdr["Pg308"] == DBNull.Value ? 0 : (decimal)rdr["Pg308"],
                        Pg312 = rdr["Pg312"] == DBNull.Value ? 0 : (decimal)rdr["Pg312"],
                        Pg316 = rdr["Pg316"] == DBNull.Value ? 0 : (decimal)rdr["Pg316"],
                        Pg320 = rdr["Pg320"] == DBNull.Value ? 0 : (decimal)rdr["Pg320"],
                        Pg324 = rdr["Pg324"] == DBNull.Value ? 0 : (decimal)rdr["Pg324"],
                        Pg328 = rdr["Pg328"] == DBNull.Value ? 0 : (decimal)rdr["Pg328"],
                        Pg332 = rdr["Pg332"] == DBNull.Value ? 0 : (decimal)rdr["Pg332"]
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
                       Theme= rdr.GetDecimal(rdr.GetOrdinal("Theme")),
                       Story= rdr.GetDecimal(rdr.GetOrdinal("Story")),
                       Yir= rdr.GetDecimal(rdr.GetOrdinal("Yir")),
                       Supplement= rdr.GetDecimal(rdr.GetOrdinal("Supplement")),
                      Laminationsft= rdr.GetDecimal(rdr.GetOrdinal("Laminationsft"))

                    };
                    this.BookOptionPricing = vOptionPrice;

                }
            }catch(Exception ex)
            {
                Log.Fatal("Error retrieving Book Option Pricing" + ex.Message);
                MessageBox.Show("There was an error retrieving Book Option Pricing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this.BookOptionPricing == null)
            {
                MessageBox.Show("Book Option pricing for this contract year was not found. Contact your supervisor.");
            }

           } 
        private bool ValidatePageCount() {
            bool retval = true;
          errorProvider1.Clear();
            int count;
            var result = int.TryParse(txtNoPages.Text,out count);
            //non numeric
            if (!result)
                {
                  errorProvider1.SetError(txtNoPages,"Please enter a number.");
                retval = false;
                }
            //Check over 360
            if (count > 360)
                {
                errorProvider1.SetError(txtNoPages,"Calculations are limited to 360 pages!");
                retval = false;
                }
            //check divisible by 4
            var mod = (count % 4);
            if (mod != 0 || count< 12)
                {
                   errorProvider1.SetError(txtNoPages,"Pages must be 12 or greater and divisible by 4!");
                   retval = false;
                }

            //If CaseBind
            if(chkCaseBind.Checked && (count < 40 || count>120))
                {
                errorProvider1.SetError(txtNoPages,"Case Bind pages must between 40 and 120!");
                retval = false;
                }

            if (count > 84 && chkSaddlStitch.Checked)
                {
                errorProvider1.SetError(txtNoPages,"Saddle Stitch must be 84 pages or less!");
                retval = false;
                }



            return retval;
         }
        private bool ValidateCopies() {
            bool retval = true;
            errorProvider1.Clear();
            int count;
            var result = int.TryParse(txtNocopies.Text,out count);
            //non numeric
            if (!result || count==0)
                {
                errorProvider1.SetError(txtNocopies,"Please enter a number.");
                retval = false;
                }
            if (count > 1800)
                {
                errorProvider1.SetError(txtNocopies,"Number exceeds maximun quantity. Contact your supervisor.");
                retval = false;
                }
            return retval;
            }
            


        #endregion

        private void txtNoPages_Leave(object sender,EventArgs e) {
            
               
                CalculateEach();
                BookCalc();

               
            }

        private void txtNocopies_Leave(object sender,EventArgs e) {
           
                CalculateEach();
                BookCalc();
               

            }

        private void txtPriceOverRide_Leave(object sender,EventArgs e) {
            CalculateEach();
            BookCalc();
            }

        private void cmbYrDiscountAmt_Leave(object sender,EventArgs e) {
            CalculateEach();
            BookCalc();
            }

        private void chkCaseBind_Click(object sender,EventArgs e) {
            BookCalc();
            }

        private void chkPerfBind_Click(object sender,EventArgs e) {
            BookCalc();
            }

        private void chkSpiral_Click(object sender,EventArgs e) {
            BookCalc();
            }

        private void chkSaddlStitch_Click(object sender,EventArgs e) {
            BookCalc();
            }

        private void chkProfessional_Click(object sender,EventArgs e) {
            BookCalc();
            }

        private void chkConv_Click(object sender,EventArgs e) {
            BookCalc();
            }

        private void chkYir_Click(object sender,EventArgs e) {
            BookCalc();
            }

        private void chkStory_Click(object sender,EventArgs e) {
            BookCalc();
            }

        private void chkGlossLam_Click(object sender,EventArgs e) {
            BookCalc();
            }

        private void chkMLaminate_Click(object sender,EventArgs e) {
            BookCalc();
            }

        private void txtSpecCvrEa_Leave(object sender,EventArgs e) {
            decimal spcEach;
            int copies;
            bool result = decimal.TryParse(txtSpecCvrEa.Text,out spcEach);
            bool result2 = int.TryParse(txtNocopies.Text,out copies);
            if (result && result2)
            {
                lblSpeccvr.Text = (copies * spcEach).ToString();
            }
            else {  lblSpeccvr.Text = ""; }
            BookCalc();

        }

        private void txtMisc_Leave(object sender, EventArgs e)
        {
           var a= String.Format("{0:0.00}", txtMisc.Text);
            BookCalc();
        }

        private void txtDesc1amt_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtDesc3tot_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtDesc4tot_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }
    }


    }
