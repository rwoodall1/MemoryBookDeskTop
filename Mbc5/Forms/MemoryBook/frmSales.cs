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
using BaseClase.Classes;
using System.Data.SqlClient;
using Mbc5.Classes;
using Mbc5.LookUpForms;
using BindingModels;
using Exceptionless;
using Exceptionless.Models;
using Outlook= Microsoft.Office.Interop.Outlook;
namespace Mbc5.Forms.MemoryBook {
    public partial class frmSales : BaseClass.frmBase, INotifyPropertyChanged {
        private static string _ConnectionString = ConfigurationManager.ConnectionStrings["Mbc"].ConnectionString;
        private bool startup = true;
        public frmSales(UserPrincipal userPrincipal,int invno,string schcode) : base(new string[] { "SA","Administrator","MbcCS" },userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = invno;
            this.Schcode = schcode;

            }
        public frmSales(UserPrincipal userPrincipal) : base(new string[] { "SA","Administrator","MbcCS" },userPrincipal) {
            InitializeComponent();
            this.DisableControls(this);
            EnableControls(this.txtInvoSrch);
            EnableControls(btnInvSrch);
            EnableControls(btnPoSrch);
            EnableControls(txtPoSrch);
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = 0;
            this.Schcode = null;

            }
        private void frmSales_Load(object sender,EventArgs e) {
            
          
            lblPCEach.DataBindings.Add("Text",this,"PrcEa",false,DataSourceUpdateMode.OnPropertyChanged);//bind 
            lblPCTotal.DataBindings.Add("Text",this,"PrcTot",false,DataSourceUpdateMode.OnPropertyChanged);//bind
            Fill();
            if (ApplicationUser.Roles.Contains("SA") || ApplicationUser.Roles.Contains("Administrator")) {
                this.dp1descComboBox.ContextMenuStrip = this.mnuEditLkUp;
                }
            startup = false;
            CalculateEach();
            BookCalc();
            }
        private void btnInvSrch_Click(object sender,EventArgs e) {
            var sqlQuery = new SQLQuery();
            string querystring = "Select schcode,invno from Quotes where Invno=@Invno";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Invno",txtInvoSrch.Text.Trim())
            };
            DataTable result = sqlQuery.ExecuteReaderAsync(CommandType.Text,querystring,parameters);
            if (result.Rows.Count > 0) {
                foreach (DataRow row in result.Rows) {
                    //only one row so just set variabls
                    this.Invno = Convert.ToInt32(row["invno"]);
                    this.Schcode = row["schcode"].ToString();
                    this.Fill();
                    EnableAllControls(this);
                    }
                } else { MessageBox.Show("No records were found.","Search",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }

        #region "Properties"
        public void InvokePropertyChanged(PropertyChangedEventArgs e) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this,e);
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
        public BookOptionPrice BookOptionPricing { get; set; }
        public string CurPriceYr { get; set; } = null;
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
        private void CalculatePayments() {
            var SqlQuery = new SQLQuery();
            var cmdText = "SELECT        SUM(ISNULL(payment, 0) + ISNULL(refund, 0) + ISNULL(adjmnt, 0) + ISNULL(compamt, 0)) AS paymentresult FROM paymnt where Invno=@Invno";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Invno",lblInvoice.Text) };
            var result = SqlQuery.ExecuteReaderAsync(CommandType.Text,cmdText,parameters);
            var paymentTotals =(decimal) result.Rows[0]["paymentresult"];
            cmdText = "Insert into invoice (paymnt) Values(@payments) where Invno=@Invno ";
            SqlParameter[] parameters1 = new SqlParameter[] {
                new SqlParameter("@Invno",lblInvoice.Text),
                new SqlParameter("@payments",paymentTotals)};
            SqlQuery.ExecuteNonQueryAsync(CommandType.Text,cmdText,parameters1);
            this.invoiceTableAdapter.Fill(dsInvoice.invoice,Convert.ToDecimal(lblInvoice.Text));
            }
        private void Fill() {
            if (Schcode != null) {
                custTableAdapter.Fill(dsSales.cust,Schcode);
                quotesTableAdapter.Fill(dsSales.quotes,Schcode);
                }
            if (Invno != 0) {
                var pos = quotesBindingSource.Find("invno",this.Invno);
                if (pos > -1) {
                    quotesBindingSource.Position = pos;
                    } else {
                    MessageBox.Show("Invoice number was not found.","Invoice#",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    }
                }
            CalculateEach();
            BookCalc();

            }
        private new bool Save() {
            bool retval = false;
            if (ValidSales()) {

                try {
                    this.quotesBindingSource.EndEdit();
                    quotesTableAdapter.Update(dsSales.quotes);
                    //must refill so we get updated time stamp so concurrency is not thrown
                    this.Fill();
                    retval = true;
                    } catch (DBConcurrencyException ex1) {
                    retval = false;
                    string errmsg = "Concurrency violation" + Environment.NewLine + ex1.Row.ItemArray[0].ToString();
                    this.Log.Error(ex1,ex1.Message);
                    MessageBox.Show(errmsg);
                    } catch (Exception ex) {
                    retval = false;
                    MessageBox.Show("Record faild to update:" + ex.Message);
                    this.Log.Error(ex,"Record faild to update:" + ex.Message);
                    }
                }

            return retval;
            }
        private void CalculateEach() {
            //Don't calculate until fill is done.
            decimal thePrice = 0;
            if (!startup) {
                if (!ValidateCopies() || !ValidatePageCount()) {
                    return;
                    }
                string vPage = "Pg" + txtNoPages.Text;
                int copies;
                int calcCopies;
                var result = int.TryParse(txtNocopies.Text,out copies);
                if (copies < 100)//min is 100 for calculating
                {
                    calcCopies = 100;
                    } else { calcCopies = copies; }
                if (!result) {
                    MessageBox.Show("Copies is not a numeral.");
                    return;
                    }

                var lowCopies = 0;
                if (copies > 125) {
                    lowCopies = copies - 25;
                    } else {
                    lowCopies = 100;
                    }
                if (copies > 1800) {
                    MessageBox.Show("Copies are more than the maximum that can be calculated. Contact your supervisor, quantity is being reset at 1800.","Copies",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    txtNocopies.Text = "1800";
                    lowCopies = 1800;
                    calcCopies = 1800;
                    }

                if (this.Pricing == null || CurPriceYr != txtBYear.Text) {
                    GetBookPricing();
                    if (this.Pricing == null) {
                        MessageBox.Show("Pricing was not found.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        Log.Error("Pricing was not found:Year-" + txtBYear.Text);
                        return;
                        }
                    }

                //var vPricingRow = Pricing.Where(a => a.Copies >= lowCopies && a.Copies <= copies).ToList();
                //var aprice = vPricingRow.Select(x => x.GetType().GetProperty("Pg12").GetValue(x));

                var vBookPrice = Pricing.Where(a => a.Copies >= lowCopies && a.Copies <= calcCopies).Select(x => x.GetType().GetProperty(vPage).GetValue(x)).ToList();
                if (vBookPrice.Count < 1) {
                    return;
                    }
                decimal vFoundPrice = (decimal)vBookPrice[0];
                decimal vdiscountamount = 1;
                if (cmbYrDiscountAmt.SelectedIndex > 0) {
                    decimal promAmt = 0;
                    bool proAmtResult = decimal.TryParse(cmbYrDiscountAmt.SelectedItem.ToString(),out promAmt);

                    vdiscountamount = 1 - promAmt;
                    }
                vFoundPrice = vFoundPrice * vdiscountamount;
                lblPriceEach.Text = vFoundPrice.ToString("c");

                if (String.IsNullOrEmpty(txtPriceOverRide.Text) || txtPriceOverRide.Text == "$0.00" || txtPriceOverRide.Text == "$0") {
                    try {
                        string price = lblPriceEach.Text.Replace("$","");//must strip dollar sign
                        thePrice = System.Convert.ToDecimal(price);

                        lblBookTotal.Text = (thePrice * copies).ToString("c");

                        } catch (Exception ex) {
                        MessageBox.Show("Book price is not in a decimal value.");
                        }
                    } else {
                    try {
                        string price = txtPriceOverRide.Text.Replace("$","");//must strip dollar sign
                        thePrice = System.Convert.ToDecimal(price);
                        lblBookTotal.Text = (thePrice * copies).ToString("c");
                        } catch (Exception ex) {
                        MessageBox.Show("Book price is not in a decimal value.");
                        }

                    }
                //original book thePrice
                var theTotal = System.Convert.ToDecimal(lblBookTotal.Text.Replace("$",""));
                decimal profTotal = 0;
                decimal conTotal = 0;
                result = decimal.TryParse(lblProfAmt.Text.Replace("$",""),out profTotal);
                result = decimal.TryParse(lblConvAmt.Text.Replace("$",""),out conTotal);
                decimal vprofprce = thePrice + ((conTotal / copies) + (profTotal / copies));
                lblprofprice.Text = vprofprce.ToString("c");

                lblProftotalPrc.Text = (vprofprce * copies).ToString("c");


                BookCalc();
                }
            }
        private void CalcInk() {


            }
        private void BookCalc() {
            if (!startup) {
                if (!ValidateCopies() || !ValidatePageCount()) {
                    return;
                    }
                if (BookOptionPricing == null) { GetBookOptionPricing(); }
                if (CurPriceYr != txtBYear.Text) { CalculateEach(); }
                int numberOfCopies = 0;
                int numberOfPages = 0;
                var parseresult = int.TryParse(txtNocopies.Text,out numberOfCopies);
                var parseresult1 = int.TryParse(txtNoPages.Text,out numberOfPages);
                if (!parseresult) {
                    MessageBox.Show("Number of copies is not valid!","Copies",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                    }
                if (!parseresult1) {
                    MessageBox.Show("Number of pages is not valid!","Pages",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                    }
                if (this.BookOptionPricing != null && CurPriceYr == txtBYear.Text) {

                    //Hardback
                    decimal HardBack = 0;
                    if (chkHardBack.Checked) {
                        HardBack = BookOptionPricing.Hardbk * numberOfCopies;
                        lblHardbackAmt.Text = HardBack.ToString();
                        CalcInk();
                        } else {
                        lblHardbackAmt.Text = "0.00";
                        HardBack = 0;
                        }
                    //Casebind
                    decimal Casebind = 0;
                    if (chkCaseBind.Checked) {
                        Casebind = BookOptionPricing.Case * numberOfCopies;
                        lblCaseamt.Text = Casebind.ToString();
                        CalcInk();
                        } else {
                        lblCaseamt.Text = "0.00";
                        Casebind = 0;
                        }
                    //Check if harback and case both not checked
                    if (!chkHardBack.Checked && !chkCaseBind.Checked) {
                        CalcInk();
                        }
                    //Perfect Bind
                    decimal Perfectbind = 0;
                    if (chkPerfBind.Checked) {
                        Perfectbind = BookOptionPricing.Perfectbind * numberOfCopies;
                        lblPerfbindAmt.Text = Perfectbind.ToString();

                        } else {
                        lblPerfbindAmt.Text = "0.00";
                        Perfectbind = 0;
                        }
                    //Spiral
                    decimal Spiral = 0;
                    if (chkSpiral.Checked) {
                        Spiral = (BookOptionPricing.Spiral * numberOfCopies);
                        lblSpiralAmt.Text = Spiral.ToString();
                        } else {
                        lblSpiralAmt.Text = "0.00";
                        Spiral = 0;
                        }
                    //SaddleStitch
                    decimal SaddleStitch = 0;
                    if (chkSaddlStitch.Checked) {
                        SaddleStitch = (BookOptionPricing.SaddleStitch * numberOfCopies);
                        lblSaddleAmt.Text = SaddleStitch.ToString();

                        } else {
                        lblSaddleAmt.Text = "0.00";
                        SaddleStitch = 0;
                        }

                    //Professional
                    decimal Professional = 0;
                    if (chkProfessional.Checked) {
                        Professional = (BookOptionPricing.Professional * numberOfPages);
                        lblProfAmt.Text = Professional.ToString();

                        } else {
                        lblProfAmt.Text = "0.00";
                        Professional = 0;
                        }

                    //Convenient
                    decimal Convenient = 0;
                    if (chkConv.Checked) {
                        Convenient = (BookOptionPricing.Convenient * numberOfPages);
                        lblConvAmt.Text = Convenient.ToString();

                        } else {
                        lblConvAmt.Text = "0.00";
                        Convenient = 0;
                        }
                    //Yir
                    decimal Yir = 0;
                    if (chkYir.Checked) {
                        Yir = (BookOptionPricing.Yir * numberOfCopies);
                        lblYir.Text = Yir.ToString();
                        } else {
                        lblYir.Text = "0.00";
                        Yir = 0;
                        }

                    //Story
                    decimal Story = 0;
                    if (chkStory.Checked) {
                        Story = (BookOptionPricing.Story);
                        lblStoryAmt.Text = Story.ToString();

                        } else {
                        lblStoryAmt.Text = "0.00";
                        Story = 0;
                        }

                    //Gloss
                    decimal Gloss = 0;
                    if (chkGlossLam.Checked) {
                        if (chkHardBack.Checked || chkCaseBind.Checked) {
                            lblLaminateAmt.Text = "0.00";
                            Gloss = 0;
                            } else {
                            Gloss = (BookOptionPricing.Lamination * numberOfCopies);
                            lblLaminateAmt.Text = Gloss.ToString();
                            }
                        } else {
                        lblLaminateAmt.Text = "0.00";
                        Gloss = 0;
                        }
                    //foilamt/msStory
                    decimal Foil = 0;
                    int MsCopies = 0;
                    var result = int.TryParse(txtMsQty.Text,out MsCopies);

                    if (chkMsStandard.Checked) {
                        if (result) {
                            foilamtTextBox.Text = BookOptionPricing.Foil.ToString("0.00");
                            Foil = (BookOptionPricing.Foil * MsCopies);
                            lblMsTot.Text = Foil.ToString("0.00");
                            } else {
                            lblMsTot.Text = "0.00";
                            foilamtTextBox.Text = "0.00";
                            }
                        } else {
                        lblMsTot.Text = "0.00";
                        foilamtTextBox.Text = "0.00";
                        }
                    //Lam
                    decimal Laminationsft = 0;
                    if (chkMLaminate.Checked) {
                        Laminationsft = (BookOptionPricing.Laminationsft * numberOfCopies);
                        lblMLaminateAmt.Text = Laminationsft.ToString();

                        } else {
                        lblMLaminateAmt.Text = "0.00";
                        Laminationsft = 0;
                        }
                    //convert rest of info from strings to decimals for calculations
                    bool vParseResult;
                    decimal BookTotal = 0;
                    decimal SpecCvrTot = 0;
                    decimal FoilTot = 0;
                    decimal ClrPgTot = 0;
                    decimal MiscTot = 0;
                    decimal Desc1Tot = 0;
                    decimal Desc3Tot = 0;
                    decimal Desc4Tot = 0;

                    vParseResult = decimal.TryParse(lblBookTotal.Text.ToString().Replace("$",""),out BookTotal);
                    vParseResult = decimal.TryParse(lblSpeccvrtot.Text,out SpecCvrTot);
                    vParseResult = decimal.TryParse(txtFoilAd.Text,out FoilTot);
                    vParseResult = decimal.TryParse(txtClrTot.Text,out ClrPgTot);
                    vParseResult = decimal.TryParse(txtMisc.Text,out MiscTot);
                    vParseResult = decimal.TryParse(txtDesc1amt.Text,out Desc1Tot);
                    vParseResult = decimal.TryParse(txtDesc3tot.Text,out Desc3Tot);
                    vParseResult = decimal.TryParse(txtDesc4tot.Text,out Desc4Tot);




                    decimal SubTotal = (BookTotal + HardBack + Casebind + Perfectbind + Spiral + SaddleStitch + Professional + Convenient + Yir + Story + Gloss + Laminationsft + SpecCvrTot + FoilTot + ClrPgTot + MiscTot + Desc1Tot + Desc3Tot + Desc4Tot);

                    lblsubtot.Text = SubTotal.ToString("c");
                    //calculate after subtotal
                    decimal disc1 = 0;
                    decimal disc2 = 0;
                    decimal disc3 = 0;
                    decimal msTot = 0;
                    decimal persTot = 0;

                    vParseResult = decimal.TryParse(lbldisc1.Text,out disc1);
                    vParseResult = decimal.TryParse(lbldisc2.Text,out disc2);
                    vParseResult = decimal.TryParse(lblDisc3.Text,out disc3);
                    vParseResult = decimal.TryParse(lblMsTot.Text,out msTot);
                    vParseResult = decimal.TryParse(lblperstotal.Text,out persTot);
                    lblFinalTotPrc.Text = (SubTotal + disc1 + disc2 + disc3 + msTot + persTot).ToString("c");
                    txtFinalbookprc.Text = ((SubTotal + disc1 + disc2 + disc3 + msTot + persTot) / numberOfCopies).ToString("c");
                    //other charges and credies
                    decimal credit1 = 0;
                    decimal credit2 = 0;
                    decimal otherchrg1 = 0;
                    decimal otherchrg2 = 0;
                    vParseResult = decimal.TryParse(txtCredits.Text,out credit1);
                    vParseResult = decimal.TryParse(txtCredits2.Text,out credit2);
                    vParseResult = decimal.TryParse(txtOtherChrg.Text,out otherchrg1);
                    vParseResult = decimal.TryParse(txtOtherChrg2.Text,out otherchrg2);
                    lbladjbef.Text = (SubTotal + disc1 + disc2 + disc3 + msTot + persTot + credit1 + credit2 + otherchrg1 + otherchrg2).ToString("c");

                    }
                }
            }
        private void GetBookPricing() {
            if (String.IsNullOrEmpty(txtBYear.Text)) {
                errorProvider1.Clear();
                errorProvider1.SetError(txtBYear,"Please enter a  base price year.");
                return;
                }
            this.CurPriceYr = txtBYear.Text;


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT * From Pricing where Type=@Type and yr=@Yr order by copies",conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Yr",txtBYear.Text);//base price yr
            if (chkAllClr.Checked) {
                cmd.Parameters.AddWithValue("@Type","Color");
                } else {
                cmd.Parameters.AddWithValue("@Type","Base");
                }


            List<Price> PriceList = new List<Price>();

            try {

                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {
                    Price vprice = new Price() {
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
                        Pg132 = rdr["Pg132"] == DBNull.Value ? 0 : (decimal)rdr["Pg132"],
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
                } catch (Exception ex) {
                Log.Fatal("Failed to retrieve pricing:" + ex.Message);
                MessageBox.Show("There was an error retrieving pricing.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        private void GetBookOptionPricing() {
            this.CurPriceYr = txtBYear.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT * From BookOptionPricing where yr=@Yr",conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Yr",txtBYear.Text);//base price yr

            try {

                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {
                    BookOptionPrice vOptionPrice = new BookOptionPrice() {
                        Yr = rdr.GetOrdinal("Yr").ToString(),
                        Case = rdr.GetDecimal(rdr.GetOrdinal("Case")),
                        Professional = rdr.GetDecimal(rdr.GetOrdinal("Professional")),
                        Convenient = rdr.GetDecimal(rdr.GetOrdinal("Convenient")),
                        Specialcvr = rdr.GetDecimal(rdr.GetOrdinal("Specialcvr")),
                        Lamination = rdr.GetDecimal(rdr.GetOrdinal("Lamination")),
                        Perfectbind = rdr.GetDecimal(rdr.GetOrdinal("Perfectbind")),
                        Customized = rdr.GetDecimal(rdr.GetOrdinal("Customized")),
                        Hardbk = rdr.GetDecimal(rdr.GetOrdinal("Hardbk")),
                        Foil = rdr.GetDecimal(rdr.GetOrdinal("Foil")),
                        Ink = rdr.GetDecimal(rdr.GetOrdinal("Ink")),
                        Spiral = rdr.GetDecimal(rdr.GetOrdinal("Spiral")),
                        Theme = rdr.GetDecimal(rdr.GetOrdinal("Theme")),
                        Story = rdr.GetDecimal(rdr.GetOrdinal("Story")),
                        Yir = rdr.GetDecimal(rdr.GetOrdinal("Yir")),
                        Supplement = rdr.GetDecimal(rdr.GetOrdinal("Supplement")),
                        Laminationsft = rdr.GetDecimal(rdr.GetOrdinal("Laminationsft"))

                        };
                    this.BookOptionPricing = vOptionPrice;

                    }
                } catch (Exception ex) {
                Log.Fatal("Error retrieving Book Option Pricing" + ex.Message);
                MessageBox.Show("There was an error retrieving Book Option Pricing.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            if (this.BookOptionPricing == null) {
                MessageBox.Show("Book Option pricing for this contract year was not found. Contact your supervisor.");
                }

            }
        private bool ValidatePageCount() {
            bool retval = true;
            errorProvider1.Clear();
            int count;
            var result = int.TryParse(txtNoPages.Text,out count);
            //non numeric
            if (!result) {
                errorProvider1.SetError(txtNoPages,"Please enter a number.");
                retval = false;
                }
            //Check over 360
            if (count > 360) {
                errorProvider1.SetError(txtNoPages,"Calculations are limited to 360 pages!");
                retval = false;
                }
            //check divisible by 4
            var mod = (count % 4);
            if (mod != 0 || count < 12) {
                errorProvider1.SetError(txtNoPages,"Pages must be 12 or greater and divisible by 4!");
                retval = false;
                }

            //If CaseBind
            if (chkCaseBind.Checked && (count < 40 || count > 120)) {
                errorProvider1.SetError(txtNoPages,"Case Bind pages must between 40 and 120!");
                retval = false;
                }

            if (count > 84 && chkSaddlStitch.Checked) {
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
            if (!result || count == 0) {
                errorProvider1.SetError(txtNocopies,"Please enter a number.");
                retval = false;
                }
            if (count > 1800) {
                errorProvider1.SetError(txtNocopies,"Number exceeds maximun quantity. Contact your supervisor.");
                retval = false;
                }
            return retval;
            }
        private bool ValidSales() {
            bool retval = true;
            retval = ValidatePageCount();
            if (!retval) { return retval; }
            retval = ValidateCopies();
            if (!retval) { return retval; }
            retval = this.ValidateChildren();
            if (!retval) { return retval; }
            retval = this.Validate();
            return retval;
            }
        private bool DeleteInvoice() {
            bool retval = true;
            var sqlQuery = new SQLQuery();
            var queryString = "Delete  From Invoice where Invno=@Invno ";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Invno",lblInvoice.Text)
            };
            var result = sqlQuery.ExecuteNonQueryAsync(CommandType.Text,queryString,parameters);
            queryString = "Delete  From InvDetail where Invno=@Invno ";
            SqlParameter[] parameters1 = new SqlParameter[] {
                new SqlParameter("@Invno",lblInvoice.Text)
            };
            //use same parameter
            var result1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text,queryString,parameters1);
            if (result1 == 0 || result == 0) { retval = false; }
            return retval;
            }
        private bool CreateInvoice() {
            bool retval = true;
            var connection = new SqlConnection(_ConnectionString);
            string cmdText = "";
            var command = new SqlCommand(cmdText,connection);

            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@invno",lblInvoice.Text);
            try {
                connection.Open();
                var trans = connection.BeginTransaction();
                command.Transaction = trans;
                //command.Parameters.AddWithValue("@invno",lblInvoice.Text);
                cmdText = "Update Quotes set invoiced=1 where invno=@invno";
                command.CommandText = cmdText;
                command.ExecuteNonQuery();
                cmdText = "Insert into Invoice (Invno,schcode,qtedate,nopages,nocopies,book_ea,source,ponum,invtot,baldue,contryear,allclrck,freebooks) VALUES(@invno,@schcode,@qtedate,@nopages,@nocopies,@book_each,@source,@ponum,@invtot,@baldue,@contryear,@allclrck,@freebooks)";
                //cmdText = "Insert into Invoice (Invno,schcode,qtedate,nopages,nocopies,book_ea) VALUES(@invno,@schcode,@qtedate,@nopages,@nocopies,@book_each)";
                command.CommandText = cmdText;
                command.Parameters.Clear();
                var aa = lblPriceEach.Text.Replace("$","");
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@invno",lblInvoice.Text),
                    new SqlParameter("@schcode",this.Schcode ),
                    new SqlParameter("@qtedate",dteQuote.Value ),
                    new SqlParameter("@nopages",txtNoPages.Text ),
                    new SqlParameter("@nocopies",txtNocopies.Text ),
                    new SqlParameter("@book_each",lblPriceEach.Text.Replace("$","").Replace(",","")),
                    new SqlParameter("@source",txtSource.Text ),
                    new SqlParameter("@ponum",txtPoNum.Text),
                    new SqlParameter("@invtot",lblFinalTotPrc.Text.Replace("$","").Replace(",","") ),
                    new SqlParameter("@baldue",lblFinalTotPrc.Text.Replace("$","").Replace(",","") ),
                    new SqlParameter("@contryear",txtYear.Text),
                    new SqlParameter("@allclrck",chkAllClr.Checked),
                    new SqlParameter("@freebooks",txtfreebooks.Text ),

              };
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                cmdText = "Insert Into Invdetail (descr,price,discpercent,invno,schcode) Values(@descr,@price,@discpercent,@invno,@schcode)";
                var Details = GetDetailRecords(lblInvoice.Text);
                command.CommandText = cmdText;
                if (Details.Count > 0) {
                    foreach (var row in Details) {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@descr",row.descr);
                        command.Parameters.AddWithValue("@price",row.price);
                        command.Parameters.AddWithValue("@discpercent",row.discpercent);
                        command.Parameters.AddWithValue("@invno",row.invno);
                        command.Parameters.AddWithValue("@schcode",row.schoolcode);
                        try {
                            command.ExecuteNonQuery();

                            } catch (Exception ex) {
                            ex.ToExceptionless()
                                .AddTags("CreateInvoice")
                                .AddObject(command)
                                .MarkAsCritical()
                                .Submit();
                            command.Transaction.Rollback();
                            MessageBox.Show("There was an error creating the invoice.","Invoice",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            retval = false;
                            }

                        }
                    command.Transaction.Commit();
                    MessageBox.Show("Invoice has been created.","Invoice",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    } else {
                    //no detail records so just commit header.
                    command.Transaction.Commit();
                    MessageBox.Show("Invoice has been created.","Invoice",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }

                } catch (Exception ex) {
                ex.ToExceptionless()
                                .AddTags("CreateInvoice")
                                .AddObject(command)
                                .MarkAsCritical()
                                .Submit();
                command.Transaction.Rollback();
                MessageBox.Show("There was an error creating the invoice.","Invoice",MessageBoxButtons.OK,MessageBoxIcon.Error);
                retval = false;

                } finally { connection.Close(); }
            return retval;
            } 
      
     
        private void SetOnlinePayOptions(string textboxname,string checkboxname,bool vcheck ) {
            List<TextBox> vControls = new List<TextBox>();
            List<CheckBox> vControls1 = new List<CheckBox>();
                vControls.Add(this.txtInkPersAmt);
                vControls.Add(this.txtInkTxtOnly);
                vControls.Add(this.txtFoilIcons);
                vControls.Add(this.txtFoilTxt);
                vControls.Add(this.txtPicPers);
                vControls1.Add(this.chkInkPers);
                vControls1.Add(this.chkInkTxt);
                vControls1.Add(this.chkFoilIcons);
                vControls1.Add(this.chkFoiltxt);
                vControls1.Add(this.chkPicPers);
            
            foreach (TextBox ctr in vControls) {
                if (vcheck == true) {
                    if (ctr.Name != textboxname) {
                        ctr.Enabled = false;
                        ctr.Text = "0.00";
                        } else { ctr.Enabled = true; }
                    } else {
                    ctr.Text = "0.00";
                    ctr.Enabled = false;
                    }
                }
            foreach(CheckBox ctr1 in vControls1) {
                if (vcheck== true) {
                    if (ctr1.Name != checkboxname) {
                        ctr1.Enabled = false;

                        } else { ctr1.Enabled = true; }

                    }else {
                    
                    ctr1.Enabled = true;

                    }


                }

            }
        private void CalcOnlineTotals()
        {
            
            if (basicamounTextBox1.Text != null && basicamounTextBox1.Text != "0.00" && basicamounTextBox1.Text != ""){
                lblOprcperbk.Text = basicamounTextBox1.Text;
            }
            else
            {
                lblOprcperbk.Text = "0.00";

            }

            if (txtInkPersAmt.Text != null && txtInkPersAmt.Text != "0.00" && txtInkPersAmt.Text != "")
            {
                txtOprcperbk2.Text = txtInkPersAmt.Text;
                return;
            }
            else
            {
                txtOprcperbk2.Text = "0.00";
               
                }
            if (txtInkTxtOnly.Text != null && txtInkTxtOnly.Text != "0.00" && txtInkTxtOnly.Text != "")
            {
                txtOprcperbk2.Text = txtInkTxtOnly.Text;
                return;
                }
            else
            {
                txtOprcperbk2.Text = "0.00";

            }

            if (txtFoilIcons.Text != null && txtFoilIcons.Text != "0.00" && txtFoilIcons.Text != "")
            {
                txtOprcperbk2.Text = txtFoilIcons.Text;
                return;
                }
            else
            {
                txtOprcperbk2.Text = "0.00";

            }
            if (txtFoilTxt.Text != null && txtFoilTxt.Text != "0.00" && txtFoilTxt.Text != "")
            {
                txtOprcperbk2.Text = txtFoilTxt.Text;
                return;
                }
            else
            {
                txtOprcperbk2.Text = "0.00";

            }
            
            if (txtPicPers.Text != null && txtPicPers.Text != "0.00" && txtPicPers.Text != "") {
                txtOprcperbk2.Text = txtFoilTxt.Text;
                return;
                } else {
                txtOprcperbk2.Text = "0.00";

                }

            }
        private List<InvoiceDetailBindingModel> GetDetailRecords(string invno) {
            int vinvno = 0;
            decimal per;
            if (!int.TryParse(lblInvoice.Text,out vinvno)) {
                MessageBox.Show("Could not create invoice because invoice number is not available.");
                return null;
                }
             
            var Details = new List<InvoiceDetailBindingModel>();
        if (true) {
            //add base alway true
            var rec = new InvoiceDetailBindingModel {
                invno = vinvno,
                descr = "Base Price",
                discpercent = 0,
                price = Convert.ToDecimal(lblBookTotal.Text.Replace("$","")),
                schoolcode = this.Schcode
                };
            Details.Add(rec);

            }


            
            if (chkHardBack.Checked) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Hard Back (sewn)",
                    discpercent = 0,
                    price= Convert.ToDecimal(lblHardbackAmt.Text),
                    schoolcode = this.Schcode
                    };
                Details.Add(rec);

                }

            if (chkCaseBind.Checked) {                          
                    var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Case Binding (glued)",
                    discpercent = 0,
                    price= Convert.ToDecimal(lblCaseamt.Text),
                        schoolcode = this.Schcode
                    };
              
                Details.Add(rec);

                }
            if (chkPerfBind.Checked) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Perfect Bind",
                    discpercent = 0,
                    price = Convert.ToDecimal(lblPerfbindAmt.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if (chkSpiral.Checked) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Spiral Bind",
                    discpercent = 0,
                    price = Convert.ToDecimal(lblSpiralAmt.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if (chkSaddlStitch.Checked) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Soft Cover Stapled",
                    discpercent = 0,
                    price = Convert.ToDecimal(lblSaddleAmt.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if (chkProfessional.Checked) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Professional",
                    discpercent = 0,
                    price = Convert.ToDecimal(lblProfAmt.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if (chkConv.Checked) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Convenient",
                    discpercent = 0,
                    price = Convert.ToDecimal(lblConvAmt.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if (chkYir.Checked) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Year In Review Standard",
                    discpercent = 0,
                    price = Convert.ToDecimal(lblYir.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if (chkStory.Checked) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Our Story/My Story Cover",
                    discpercent = 0,
                    price = Convert.ToDecimal(lblStoryAmt.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if (chkMLaminate.Checked) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Matte Laminate",
                    discpercent = 0,
                    price = Convert.ToDecimal(lblMLaminateAmt.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if (chkGlossLam.Checked) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Gloss Laminate",
                    discpercent = 0,
                    price = Convert.ToDecimal(lblLaminateAmt.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if ((String.IsNullOrEmpty(lblSpeccvrtot.Text)? 0 : Convert.ToDecimal(lblSpeccvrtot.Text))  >0) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Special Cover",
                    discpercent = 0,
                    price = Convert.ToDecimal(lblSpeccvrtot.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if ((String.IsNullOrEmpty(txtFoilAd.Text)?0:Convert.ToDecimal(txtFoilAd.Text)) > 0) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Foil (Additional)",
                    discpercent = 0,
                    price = Convert.ToDecimal(txtFoilAd.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if ((String.IsNullOrEmpty(lbldisc1.Text) ?0:Convert.ToDecimal(lbldisc1.Text)) > 0) {
                per = String.IsNullOrEmpty(txtDisc.Text) ? 0 : Convert.ToDecimal(txtDisc.Text);
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = dp1descComboBox.SelectedValue.ToString(),
                    discpercent = per,
                    price = Convert.ToDecimal(txtFoilAd.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if (chkDc2.Checked) {
                per = String.IsNullOrEmpty(txtDp2.Text) ? 0 : Convert.ToDecimal(txtDp2.Text);
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Full pay w/page submission",
                    discpercent =per,
                    price =String.IsNullOrEmpty(lbldisc2.Text)?0:Convert.ToDecimal(lbldisc2.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if ((String.IsNullOrEmpty(lblDisc3.Text) ?0:Convert.ToDecimal(lblDisc3.Text))>0) {
                per = String.IsNullOrEmpty(dp3ComboBox.Text) ? 0 : Convert.ToDecimal(dp3ComboBox.Text);
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = txtDp3Desc.Text,
                    discpercent = per,
                    price = Convert.ToDecimal(lblDisc3.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if (chkMsStandard.Checked) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "My Story With Picture Personalization",
                    discpercent =0,
                    price =String.IsNullOrEmpty(lblMsTot.Text) ?0: Convert.ToDecimal(lblMsTot.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if ((String.IsNullOrEmpty(lblperstotal.Text) ?0:Convert.ToDecimal(lblperstotal.Text))>0) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Personalization",
                    discpercent = 0,
                    price = Convert.ToDecimal(lblperstotal.Text),
                    schoolcode = this.Schcode
                    };

                Details.Add(rec);

                }
            if ((String.IsNullOrEmpty(lblIconTot.Text) ?0:Convert.ToDecimal(lblIconTot.Text)) > 0) {
                var rec = new InvoiceDetailBindingModel {
                    invno = vinvno,
                    descr = "Icons",
                    discpercent =0,
                    price = Convert.ToDecimal(lblIconTot.Text),
                    schoolcode = this.Schcode
                    };

        Details.Add(rec);

                }
            return Details;
            }
      
            
        #endregion
        #region CalcEvents
        private void chkHardBack_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkAllClr_Click(object sender, EventArgs e)
        {
            GetBookPricing();
            CalculateEach();
            BookCalc();
        }

        private void chkPromo_Click(object sender, EventArgs e)
        {
            CalculateEach();
        }

        private void txtBYear_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBYear.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtBYear, "Please enter a  base price year.");
            }
            GetBookPricing();
            GetBookOptionPricing();
            CalculateEach();
        }
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
                lblSpeccvrtot.Text = (copies * spcEach).ToString();
            }
            else {  lblSpeccvrtot.Text = ""; }
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

        private void txtClrTot_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtDisc_Leave(object sender, EventArgs e)
        {
            decimal discountpercent = 0;
            decimal subtot = 0;
            bool vParseResult = decimal.TryParse(txtDisc.Text, out discountpercent);
           bool vParseResult1 = decimal.TryParse(lblsubtot.Text.Replace("$",""), out subtot);
            if (vParseResult && vParseResult1)
            {
                var discountprice = (subtot * discountpercent) - ((subtot * discountpercent) * 2);
                lbldisc1.Text = discountprice.ToString("0.00");
                BookCalc();
            }
            else
            {
                lbldisc1.Text = "0.00";
                BookCalc();
            }
            
        }

        private void chkDc2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDc2.Checked)
            {
                txtDp2.Text = ".05";
                decimal discountpercent = 0;
                decimal subtot = 0;
                bool vParseResult = decimal.TryParse(txtDp2.Text, out discountpercent);
                bool vParseResult1 = decimal.TryParse(lblsubtot.Text.Replace("$", ""), out subtot);
                if (vParseResult && vParseResult1)
                {
                    var discountprice = (subtot * discountpercent) - ((subtot * discountpercent) * 2);
                    lbldisc2.Text = discountprice.ToString("0.00");
                    BookCalc();
                }
                else
                {
                    txtDp2.Text = "0.00";
                    lbldisc2.Text = "0.00";
                    BookCalc();
                }

            }
            else
            {
                txtDp2.Text = "0.00";
                lbldisc2.Text = "0.00";
                BookCalc();
            }
        }

        private void txtDp2_Leave(object sender, EventArgs e)
        {
            if (chkDc2.Checked)
            {
               
                decimal discountpercent = 0;
                decimal subtot = 0;
                bool vParseResult = decimal.TryParse(txtDp2.Text, out discountpercent);
                bool vParseResult1 = decimal.TryParse(lblsubtot.Text.Replace("$", ""), out subtot);
                if (vParseResult && vParseResult1)
                {
                    var discountprice = (subtot * discountpercent) - ((subtot * discountpercent) * 2);
                    lbldisc2.Text = discountprice.ToString("0.00");
                    BookCalc();
                }
                else
                {
                    txtDp2.Text = "0.00";
                    lbldisc2.Text = "0.00";
                    BookCalc();
                }

            }
            else
            {
                txtDp2.Text = "0.00";
                lbldisc2.Text = "0.00";
                BookCalc();
            }
        }

        private void dp3ComboBox_Leave(object sender, EventArgs e)
        {
            decimal discountpercent = 0;
            decimal subtot = 0;
            bool vParseResult = decimal.TryParse(dp3ComboBox.SelectedItem.ToString(), out discountpercent);
            bool vParseResult1 = decimal.TryParse(lblsubtot.Text.Replace("$", ""), out subtot);
            if (vParseResult && vParseResult1)
            {
                var discountprice = (subtot * discountpercent) - ((subtot * discountpercent) * 2);
                lblDisc3.Text = discountprice.ToString("0.00");
                BookCalc();
            }


        }

        private void chkMsStandard_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtMsQty_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void perscopiesTextBox_Leave(object sender, EventArgs e)
        {
            int number = 0;
            decimal prc = 0;
            bool result = int.TryParse(perscopiesTextBox.Text, out number);
            bool result2 = decimal.TryParse(persamountTextBox.Text, out prc);
           if(result && result2)
            {
              lblperstotal.Text = (number * prc).ToString("0.00");
                BookCalc();
            }
            else
            {
                lblperstotal.Text = "0.00";
                BookCalc();
            }
            
        }

        private void persamountTextBox_Leave(object sender, EventArgs e)
        {
            int number = 0;
            decimal prc = 0;
            bool result = int.TryParse(perscopiesTextBox.Text, out number);
            bool result2 = decimal.TryParse(persamountTextBox.Text, out prc);
            if (result && result2)
            {
                lblperstotal.Text = (number * prc).ToString("0.00");
                BookCalc();
            }
            else
            {
                lblperstotal.Text = "0.00";
                BookCalc();
            }
        }

        private void txtCredits_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtCredits2_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtOtherChrg_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtOtherChrg2_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        #endregion

        #region Validation
        private void txtBYear_Validating(object sender, CancelEventArgs e)
        {
          
            errorProvider1.Clear();
            int numeral;
            var result = int.TryParse(txtBYear.Text, out numeral);
            //non numeric
            if (!result || numeral == 0||String.IsNullOrEmpty(txtBYear.Text))
            {
                errorProvider1.SetError(txtBYear, "Please enter a  base price year.");
                e.Cancel = true;
             
            }
         

        }
        private void basicamounTextBox1_Validating(object sender,CancelEventArgs e) {
            errorProvider1.Clear();
            if (String.IsNullOrEmpty(basicamounTextBox1.Text)) {
                basicamounTextBox1.Text = "0.00";
                }
                string price = basicamounTextBox1.Text.Replace("$","");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price,out val);
                //non numeric
                if (!result) {
                    errorProvider1.SetError(basicamounTextBox1,"Please enter a decimal amount.");
                    e.Cancel = true;

                    }
                
            }

        private void txtInkPersAmt_Validating(object sender,CancelEventArgs e) {

            }

        private void txtInkTxtOnly_Validating(object sender,CancelEventArgs e) {

            }

        private void txtFoilIcons_VisibleChanged(object sender,EventArgs e) {

            }

        private void txtFoilTxt_Validating(object sender,CancelEventArgs e) {

            }

        private void txtPicPers_Validating(object sender,CancelEventArgs e) {

            }

        private void txtLuvLineAmt_Validating(object sender,CancelEventArgs e) {

            }

        private void txtFullAd_Validating(object sender,CancelEventArgs e) {

            }

        private void txtHaldfAd_Validating(object sender,CancelEventArgs e) {

            }

        private void txtQuarterAd_Validating(object sender,CancelEventArgs e) {

            }

        private void txtEighthAd_Validating(object sender,CancelEventArgs e) {

            }

        private void totalsoldonlineTextBox_Validating(object sender,CancelEventArgs e) {

            }

        private void totalpersonlineTextBox_Validating(object sender,CancelEventArgs e) {

            }

        private void totaldollarsonlineTextBox_Validating(object sender,CancelEventArgs e) {

            }

        private void totallovelinesTextBox_Validating(object sender,CancelEventArgs e) {

            }

        private void totaladsTextBox_Validating(object sender,CancelEventArgs e) {

            }
        private void txtYear_Validating(object sender, CancelEventArgs e)
        {
            
            errorProvider1.Clear();
            int numeral;
            var result = int.TryParse(txtYear.Text, out numeral);
            //non numeric
            if (!result || numeral == 0 || String.IsNullOrEmpty(txtYear.Text))
            {
                errorProvider1.SetError(txtYear, "Please enter a year.");
                e.Cancel = true;
              
            }
        }
        private void txtClrNumber_Validating(object sender, CancelEventArgs e)
        {
            //might have letters
            //if (!String.IsNullOrEmpty(txtClrNumber.Text))
            //{
            //    
            //    errorProvider1.Clear();
            //    int numeral;
            //    var result = int.TryParse(txtClrNumber.Text, out numeral);
            //    //non numeric
            //    if (!result)
            //    {
            //        errorProvider1.SetError(txtBYear, "Please enter a number.");
            //        e.Cancel = true;
            //      
            //    }
            //}
        }

        private void txtSpecCvrEa_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSpecCvrEa.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtSpecCvrEa.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtSpecCvrEa, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtFoilAd_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFoilAd.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtFoilAd.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtFoilAd, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtDisc_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDisc.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtDisc.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtDisc, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtDp2_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDp2.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtDp2.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtDp2, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtMsQty_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMsQty.Text))
            {
                
                errorProvider1.Clear();
                int numeral;
                var result = int.TryParse(txtMsQty.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtMsQty, "Please enter a number.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void perscopiesTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(perscopiesTextBox.Text))
            {
                
                errorProvider1.Clear();
                int numeral;
                var result = int.TryParse(perscopiesTextBox.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(perscopiesTextBox, "Please enter a number.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void persamountTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(persamountTextBox.Text))
            {
                
                errorProvider1.Clear();
                int numeral;
                var result = int.TryParse(persamountTextBox.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(persamountTextBox, "Please enter a number.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtNumtoPers_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNumtoPers.Text))
            {
                
                errorProvider1.Clear();
                int numeral;
                var result = int.TryParse(txtNumtoPers.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtNumtoPers, "Please enter a number.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void freebooksTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtfreebooks.Text))
            {
                
                errorProvider1.Clear();
                int numeral;
                var result = int.TryParse(txtfreebooks.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtfreebooks, "Please enter a number.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtClrTot_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtClrTot.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtClrTot.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtClrTot, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtMisc_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMisc.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtMisc.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtMisc, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtDesc1amt_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDesc1amt.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtDesc1amt.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtDesc1amt, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtDesc3tot_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDesc3tot.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtDesc3tot.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtDesc3tot, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtDesc4tot_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDesc4tot.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtDesc4tot.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtDesc4tot, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtCredits_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCredits.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtCredits.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtCredits, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtCredits2_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCredits2.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtCredits2.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtCredits2, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtOtherChrg_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtOtherChrg.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtOtherChrg.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtOtherChrg, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtOtherChrg2_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtOtherChrg2.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(txtOtherChrg2.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtOtherChrg2, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void saletaxTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(saletaxTextBox.Text))
            {
                
                errorProvider1.Clear();
                decimal numeral;
                var result = decimal.TryParse(saletaxTextBox.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(saletaxTextBox, "Please enter a decimal amount.");
                    e.Cancel = true;
                  
                }
            }
        }

        private void txtPriceOverRide_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPriceOverRide.Text))
            {
                errorProvider1.Clear();
                if (!String.IsNullOrEmpty(txtPriceOverRide.Text)) {
                    string price = txtPriceOverRide.Text.Replace("$","");//must strip dollar sign
                    decimal val;
                    var result = decimal.TryParse(price,out val);
                    //non numeric
                    if (!result) {
                        errorProvider1.SetError(txtPriceOverRide,"Please enter a decimal amount.");
                        e.Cancel = true;

                        }
                    }             
            }
        }
        
        private void txtreqcoverCopies_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtreqcoverCopies.Text))
            {
                
                errorProvider1.Clear();
                int numeral;
                var result = int.TryParse(txtreqcoverCopies.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtreqcoverCopies, "Please enter a numeral.");
                    e.Cancel = true;
                  
                }
            }
        }

        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            Save();
       
        }

       

        private void lblSchoolName_Paint(object sender, PaintEventArgs e)
        {
            try { this.Text = "Sales-" + lblSchoolName.Text.Trim()+" ("+this.Schcode.Trim()+")"; } catch {

                }
           
        }

        private void editLookUpItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LkpDiscount frmDiscount = new LkpDiscount(this.ApplicationUser);
            this.Cursor = Cursors.AppStarting;
            frmDiscount.MdiParent = this.MdiParent;
            frmDiscount.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnInvoice_Click(object sender,EventArgs e) {
            //Check if invoice exist to see what to do.
            var sqlQuery = new SQLQuery();
            var queryString = "SELECT Invno From Invoice where Invno=@Invno ";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Invno",lblInvoice.Text)
            };
            var result = sqlQuery.ExecuteReaderAsync(CommandType.Text,queryString,parameters);
            //refill to keep concurrency correct
            if (result.Rows.Count > 0) {
               DialogResult invoiceresult= MessageBox.Show("There is already an invoice created, do you want to overwrite the current invoice","Invoice",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (invoiceresult == DialogResult.Yes) {
                    if (DeleteInvoice()) {
                        CreateInvoice();
                        this.Fill();
                        }
                    }
                
                } else {
                CreateInvoice();
                this.Fill();
                }
            }

        private void txtIconCopies_Leave(object sender,EventArgs e) {
            int number = 0;
            decimal prc = 0;
            bool result = int.TryParse(txtIconCopies.Text,out number);
            bool result2 = decimal.TryParse(txtIconamt.Text,out prc);
            if (result && result2) {
                lblIconTot.Text = (number * prc).ToString("0.00");
                BookCalc();
                } else {
                lblIconTot.Text = "0.00";
                BookCalc();
                }
            }

        private void tabSales_SelectedIndexChanged(object sender,EventArgs e) {


            if (this.tabSales.SelectedIndex == 2 || this.tabSales.SelectedIndex == 3) {
                this.invoiceTableAdapter.Fill(dsInvoice.invoice,Convert.ToDecimal(lblInvoice.Text));
                this.invdetailTableAdapter.Fill(dsInvoice.invdetail,Convert.ToDecimal(lblInvoice.Text));
                this.paymntTableAdapter.Fill(dsInvoice.paymnt,Convert.ToDecimal(lblInvoice.Text));
                }
            }

        private void oppicpersCheckBox1_CheckedChanged(object sender,EventArgs e) {
            SetOnlinePayOptions(this.txtPicPers.Name,this.chkPicPers.Name,chkPicPers.Checked);
            }

        private void luvlinesCheckBox_CheckedChanged(object sender,EventArgs e) {
            if (!luvlinesCheckBox.Checked) {
                txtLuvLineAmt.Text = "0.00";
                txtLuvLineAmt.Enabled = false;
                } else {
                txtLuvLineAmt.Enabled = true;
                }
            }

        private void chkInkPers_CheckedChanged(object sender,EventArgs e) {
            SetOnlinePayOptions(this.txtInkPersAmt.Name,chkInkPers.Name,chkInkPers.Checked);
            }

        private void chkInkTxt_CheckedChanged(object sender,EventArgs e) {
            SetOnlinePayOptions(this.txtInkTxtOnly.Name,chkInkTxt.Name,chkInkTxt.Checked);
            
            }

        private void chkFoilIcons_CheckedChanged(object sender,EventArgs e) {
            SetOnlinePayOptions(this.txtFoilIcons.Name,chkFoilIcons.Name,chkFoilIcons.Checked);
            }

        private void chkFoiltxt_CheckedChanged(object sender,EventArgs e) {
            SetOnlinePayOptions(this.txtFoilTxt.Name,chkFoiltxt.Name,chkFoiltxt.Checked);
            }

       

        private void chkAllowAds_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowAds.Checked)
            {
                txtFullAd.Enabled = true;
                txtHaldfAd.Enabled = true;
                txtQuarterAd.Enabled = true;
                txtEighthAd.Enabled = true;

            }
            else
            {
                txtFullAd.Enabled = false;
                txtHaldfAd.Enabled = false;
                txtQuarterAd.Enabled = false;
                txtEighthAd.Enabled = false;

                txtFullAd.Text ="0.00";
                txtHaldfAd.Text = "0.00";
                txtQuarterAd.Text = "0.00";
                txtEighthAd.Text = "0.00";
            }
        }

        private void bascippCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var vcheck = bascippCheckBox.Checked;
            List<TextBox> vControls = new List<TextBox>();
            List<CheckBox> vControls1 = new List<CheckBox>();
            vControls.Add(this.txtInkPersAmt);
            vControls.Add(this.txtInkTxtOnly);
            vControls.Add(this.txtFoilIcons);
            vControls.Add(this.txtFoilTxt);
            vControls.Add(this.txtPicPers);
            vControls1.Add(this.chkInkPers);
            vControls1.Add(this.chkInkTxt);
            vControls1.Add(this.chkFoilIcons);
            vControls1.Add(this.chkFoiltxt);
            vControls1.Add(this.chkPicPers);

            foreach (TextBox ctr in vControls)
            {
                
                if (vcheck == true)
                {
                    if (ctr.Name != bascippCheckBox.Name)
                    {
                        ctr.Enabled = false;
                        ctr.Text = "0.00";
                    }
                    else { ctr.Enabled = true; }
                }
                else
                {
                    ctr.Text = "0.00";
                    ctr.Enabled = false;
                }
            }
            foreach (CheckBox ctr1 in vControls1)
            {
                if (vcheck == true)
                {
                    if (ctr1.Name != bascippCheckBox.Name)
                    {
                        ctr1.Checked = false;
                        ctr1.Enabled = false;
                        

                    }
                    else {
                        ctr1.Enabled = true; }

                }
                else
                {

                    ctr1.Enabled = true;

                }
            }
            }

        private void basicamounTextBox1_Leave(object sender, EventArgs e)
        {           
            CalcOnlineTotals();
        }

        private void chkInkPers_Paint(object sender,PaintEventArgs e) {
          
            }

        private void tabSales_Click(object sender,EventArgs e) {
            if (tabSales.SelectedIndex == 2) {
               
                }
            }

        private void txtInkPersAmt_Leave(object sender,EventArgs e) {
            CalcOnlineTotals();
            }

        private void txtInkTxtOnly_Leave(object sender,EventArgs e) {
            CalcOnlineTotals();
            }

        private void txtFoilIcons_Leave(object sender,EventArgs e) {
            CalcOnlineTotals();
            }

        private void txtFoilTxt_Leave(object sender,EventArgs e) {
            CalcOnlineTotals();
            }

        private void txtPicPers_Leave(object sender,EventArgs e) {
            CalcOnlineTotals();
            }

        private void tabSales_Selecting(object sender,TabControlCancelEventArgs e) {
           //validation is done in save if validation fails returns false.
            if (!this.Save()) {
                e.Cancel = true;
                } 
            }

        private void lblProfAmt_TextChanged(object sender,EventArgs e) {
               CalculateEach();
            }

        private void lblConvAmt_TextChanged(object sender,EventArgs e) {
            CalculateEach();
            }

        private void pg1_Click(object sender,EventArgs e) {

            }

        private void button1_Click_1(object sender,EventArgs e) {
           
            }

        private void btnDeleteInvoice_Click(object sender,EventArgs e) {
            DeleteInvoice();
            this.invoiceTableAdapter.Fill(dsInvoice.invoice,Convert.ToDecimal(lblInvoice.Text));
            this.invdetailTableAdapter.Fill(dsInvoice.invdetail,Convert.ToDecimal(lblInvoice.Text));
            var sqlQuery = new SQLQuery();
            var queryString = "Update Invoice set invno=0 where Invno=@Invno ";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Invno",lblInvoice.Text)
            };
            var result = sqlQuery.ExecuteNonQueryAsync(CommandType.Text,queryString,parameters);
            this.Fill();
            }

        private void btnOnlineAgreement_Click(object sender,EventArgs e) {
            List<string> address = new List<string>();
            address.Add("randy@305spin.com");
            address.Add("randy@woodalldevelopment.com");
            EmailHelper a = new EmailHelper();
            a.SendOutLookEmail("test",address,"","This is a test.",EmailType.Mbc);


            }

        private void btnNewPayment_Click(object sender,EventArgs e) {
            txtPaypoamt.Enabled = true;
            txtInitials.Enabled = true;
            calpmtdate.Enabled = true;
            txtCheckNo.Enabled = true;
            txtMethod.Enabled = true;
            txtPayment.Enabled = true;
            txtRefund.Enabled = true;
            txtAdjustment.Enabled = true;
            txtCompensation.Enabled = true;
            txtCompReason.Enabled = true;
            paymntBindingSource.AddNew();

            DataRowView current = (DataRowView)paymntBindingSource.Current;
            current["Invno"] = lblInvoice.Text;
            current["Code"] = lblschname11.Text;


            }

        private void button1_Click_2(object sender,EventArgs e) {
            this.paymntBindingSource.EndEdit();
             this.paymntTableAdapter.Update(dsInvoice.paymnt);
            this.paymntTableAdapter.Fill(dsInvoice.paymnt,Convert.ToDecimal(lblInvoice.Text));
            this.CalculatePayments();
            }





        //nothing below here  
        }
}
    
