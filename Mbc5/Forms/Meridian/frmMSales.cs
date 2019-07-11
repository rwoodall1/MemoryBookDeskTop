using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BaseClass.Classes;
using BaseClass;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Mbc5.Forms.Meridian {
    public partial class frmMSales : BaseClass.frmBase {
        
        public frmMSales(UserPrincipal userPrincipal, int invno, string schcode) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = invno;
            this.Schcode = schcode;

        }
        public frmMSales(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
        {
            InitializeComponent();
            this.DisableControls(this);

            //EnableControls(btnPoSrch);
            //EnableControls(txtPoSrch);
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = 0;
            this.Schcode = null;

        }
        private UserPrincipal ApplicationUser { get; set; }
           public frmMain frmMain { get; set; }

        private void frmMSales_Load(object sender, EventArgs e)
        {

        }
        private void mquotesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.mquotesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsMSales);

        }
        #region Methods
        private void SetNoticeLabels()
            {
                //DataRowView dr = (DataRowView)quotesBindingSource.Current;
                //bool vHoldPayment = dr.Row.IsNull("holdpmt") ? false : (bool)dr.Row["holdpmt"];
                //lblIncollections.Visible = vHoldPayment;
                //bool vshpdate = dr.Row.IsNull("shpdate");
                //lblShipped.Visible = !vshpdate;

            }
        private void Fill()
            {
            //if (!string.IsNullOrEmpty(Schcode))
            //{
                //try
                //{
                //    custTableAdapter.Fill(dsSales.cust, Schcode);


                //    this.SchoolZipCode = ((DataRowView)this.custBindingSource.Current).Row["schzip"].ToString().Trim();
                //    if (this.SchoolZipCode.Length > 5)
                //    {
                //        this.SchoolZipCode = this.SchoolZipCode.Substring(0, 5);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MbcMessageBox.Error(ex.Message, "");
                //}

            //}
            if (Invno != 0)
            {
                try
                {
                    mquotesTableAdapter.Fill(dsMSales.mquotes, Invno);
                   // xtraTableAdapter.Fill(dsExtra.xtra, Invno);


                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "");
                }

            }
            CalculateEach();
            BookCalc();
            SetCodeInvno();
           lblAppUser.Text = this.ApplicationUser.id;
            //txtModifiedByInv.Text = this.ApplicationUser.id;
            //txtModifiedByInvdetail.Text = this.ApplicationUser.id;
            //txtModifiedByPay.Text = this.ApplicationUser.id;
            SetNoticeLabels();
        }
        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }
        private void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControls(con.Parent);
            }
        }
        private void EnableAllControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                EnableAllControls(c);
            }
            con.Enabled = true;
        }
        private void SetConnectionString()
        {
            this.frmMain = (frmMain)this.MdiParent;
            this.FormConnectionString = frmMain.AppConnectionString;
            
            this.mquotesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
           // this.paymntTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
           // this.invdetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
           // this.invCustTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            //this.invHstTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
           // this.invoiceTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            //this.xtraTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;

        }
        private void CalculateEach()
        {
            if (!donotchargeschoolsalestaxCheckBox.Checked)
            {
                //this.TaxRate = this.GetTaxRate();
            }
            else
            {
                // this.TaxRate = 0;
            }



            this.lblTaxRateValue.Text = this.TaxRate.ToString();
            if (String.IsNullOrEmpty(txtBYear.Text))
            {

                lblBookTotal.Text = (0 * 0).ToString("c");
                lblProftotalPrc.Text = (0 * 0).ToString("c");
                lblPriceEach.Text = (0 * 0).ToString("c");
                lblprofprice.Text = 0.ToString("c");
                return;
            }
            //Don't calculate until fill is done.
            decimal thePrice = 0;
            if (!startup)
            {
                if (quotesBindingSource.Count > 0)
                {
                    if (!ValidateCopies() || !ValidatePageCount())
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

                    if (this.Pricing == null || CurPriceYr != txtBYear.Text)
                    {
                        GetBookPricing();
                        if (this.Pricing == null)
                        {
                            MessageBox.Show("Pricing was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (cmbYrDiscountAmt.SelectedIndex > 0)
                    {
                        decimal promAmt = 0;
                        bool proAmtResult = decimal.TryParse(cmbYrDiscountAmt.SelectedItem.ToString(), out promAmt);

                        vdiscountamount = 1 - promAmt;
                    }
                    vFoundPrice = vFoundPrice * vdiscountamount;
                    lblPriceEach.Text = vFoundPrice.ToString("c");

                    if (String.IsNullOrEmpty(txtPriceOverRide.Text) || txtPriceOverRide.Text == "0.00" || txtPriceOverRide.Text == "$0.00" || txtPriceOverRide.Text == "0")
                    {
                        try
                        {
                            string price = lblPriceEach.Text.Replace("$", "");//must strip dollar sign
                            thePrice = System.Convert.ToDecimal(price);

                            lblBookTotal.Text = (thePrice * copies).ToString("c");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Book price is not in a decimal value.");
                        }
                    }
                    else
                    {
                        try
                        {
                            string price = txtPriceOverRide.Text.Replace("$", "");//must strip dollar sign
                            thePrice = System.Convert.ToDecimal(price);
                            lblBookTotal.Text = (thePrice * copies).ToString("c");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Book price is not in a decimal value.");
                        }

                    }
                    //original book thePrice
                    var theTotal = System.Convert.ToDecimal(lblBookTotal.Text.Replace("$", ""));

                    decimal profTotal = 0;
                    decimal conTotal = 0;
                    result = decimal.TryParse(lblProfAmt.Text.Replace("$", ""), out profTotal);
                    result = decimal.TryParse(lblConvAmt.Text.Replace("$", ""), out conTotal);
                    decimal vprofprce = thePrice + ((conTotal / copies) + (profTotal / copies));
                    lblprofprice.Text = vprofprce.ToString("c");

                    lblProftotalPrc.Text = (vprofprce * copies).ToString("c");


                    // BookCalc();
                }
            }

        }
       
        private void BookCalc()
        {
            // removes old tax calc
            this.TaxRate = 0;
            //
            decimal vbookTotal = 0;
            decimal vBookCalcTax = 0;
            try
            {
                //errors when refilling and this is called before values refreshed
                vbookTotal = System.Convert.ToDecimal(lblBookTotal.Text.Replace("$", ""));
                vBookCalcTax = this.TaxRate * vbookTotal;
            }
            catch (Exception ex)
            {

                return;
            }
            if (!startup)
            {
                if (quotesBindingSource.Count > 0)
                {
                    if (!ValidateCopies() || !ValidatePageCount())
                    {
                        return;
                    }
                    if (BookOptionPricing == null) { GetBookOptionPricing(); }
                    if (CurPriceYr != txtBYear.Text) { CalculateEach(); }
                    int numberOfCopies = 0;
                    int numberOfPages = 0;
                    var parseresult = int.TryParse(txtNocopies.Text, out numberOfCopies);
                    var parseresult1 = int.TryParse(txtNoPages.Text, out numberOfPages);
                    if (!parseresult)
                    {
                        MessageBox.Show("Number of copies is not valid!", "Copies", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!parseresult1)
                    {
                        MessageBox.Show("Number of pages is not valid!", "Pages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (this.BookOptionPricing != null && CurPriceYr == txtBYear.Text)
                    {

                        //Hardback
                        decimal HardBack = 0;
                        if (chkHardBack.Checked)
                        {
                            HardBack = BookOptionPricing.Hardbk * numberOfCopies;
                            vBookCalcTax += (HardBack * this.TaxRate);
                            lblHardbackAmt.Text = HardBack.ToString();
                            CalcInk();
                        }
                        else
                        {
                            lblHardbackAmt.Text = "0.00";

                            HardBack = 0;
                        }
                        //Casebind
                        decimal Casebind = 0;
                        if (chkCaseBind.Checked)
                        {
                            Casebind = BookOptionPricing.Customized * numberOfCopies;
                            vBookCalcTax += (Casebind * this.TaxRate);
                            lblCaseamt.Text = Casebind.ToString();
                            CalcInk();
                        }
                        else
                        {
                            lblCaseamt.Text = "0.00";
                            Casebind = 0;
                        }
                        //Check if harback and case both not checked
                        if (!chkHardBack.Checked && !chkCaseBind.Checked)
                        {
                            CalcInk();
                        }
                        //Perfect Bind
                        decimal Perfectbind = 0;
                        if (chkPerfBind.Checked)
                        {
                            Perfectbind = BookOptionPricing.Perfectbind * numberOfCopies;
                            vBookCalcTax += (Perfectbind * this.TaxRate);
                            lblPerfbindAmt.Text = Perfectbind.ToString();

                        }
                        else
                        {
                            lblPerfbindAmt.Text = "0.00";
                            Perfectbind = 0;
                        }
                        //Spiral
                        decimal Spiral = 0;
                        if (chkSpiral.Checked)
                        {
                            Spiral = (BookOptionPricing.Spiral * numberOfCopies);
                            vBookCalcTax += (Spiral * this.TaxRate);
                            lblSpiralAmt.Text = Spiral.ToString();
                        }
                        else
                        {
                            lblSpiralAmt.Text = "0.00";
                            Spiral = 0;
                        }
                        //SaddleStitch
                        decimal SaddleStitch = 0;
                        if (chkSaddlStitch.Checked)
                        {
                            SaddleStitch = (BookOptionPricing.SaddleStitch * numberOfCopies);
                            vBookCalcTax += (SaddleStitch * this.TaxRate);
                            lblSaddleAmt.Text = SaddleStitch.ToString();

                        }
                        else
                        {
                            lblSaddleAmt.Text = "0.00";
                            SaddleStitch = 0;
                        }

                        //Professional
                        decimal Professional = 0;
                        if (chkProfessional.Checked)
                        {
                            Professional = (BookOptionPricing.Professional * numberOfPages);
                            vBookCalcTax += (Professional * this.TaxRate);
                            lblProfAmt.Text = Professional.ToString();

                        }
                        else
                        {
                            lblProfAmt.Text = "0.00";
                            Professional = 0;
                        }

                        //Convenient
                        decimal Convenient = 0;
                        if (chkConv.Checked)
                        {
                            Convenient = (BookOptionPricing.Convenient * numberOfPages);
                            vBookCalcTax += (Convenient * this.TaxRate);
                            lblConvAmt.Text = Convenient.ToString();

                        }
                        else
                        {
                            lblConvAmt.Text = "0.00";
                            Convenient = 0;
                        }
                        //Yir
                        decimal Yir = 0;
                        if (chkYir.Checked)
                        {
                            Yir = (BookOptionPricing.Ink * numberOfCopies);
                            vBookCalcTax += (Yir * this.TaxRate);
                            lblYir.Text = Yir.ToString();
                        }
                        else
                        {
                            lblYir.Text = "0.00";
                            Yir = 0;
                        }
                        //our story
                        decimal Story = 0;
                        if (chkStory.Checked)
                        {
                            Story = (BookOptionPricing.Story * numberOfCopies);
                            vBookCalcTax += (Story * this.TaxRate);
                            lblStoryAmount.Text = Story.ToString();
                        }
                        else
                        {
                            lblStoryAmount.Text = "0.00";
                            Story = 0;
                        }


                        //Gloss
                        decimal Gloss = 0;
                        if (chkGlossLam.Checked)
                        {
                            if (chkHardBack.Checked || chkCaseBind.Checked)
                            {
                                lblLaminateAmt.Text = "0.00";
                                Gloss = 0;
                            }
                            else
                            {
                                Gloss = (BookOptionPricing.Lamination * numberOfCopies);
                                vBookCalcTax += (Gloss * this.TaxRate);
                                lblLaminateAmt.Text = Gloss.ToString();
                            }
                        }
                        else
                        {
                            lblLaminateAmt.Text = "0.00";
                            Gloss = 0;
                        }
                        //foilamt/msStory
                        decimal Foil = 0;
                        int MsCopies = 0;
                        var result = int.TryParse(txtMsQty.Text, out MsCopies);

                        if (chkMsStandard.Checked)
                        {
                            if (result)
                            {
                                foilamtTextBox.Text = BookOptionPricing.Foil.ToString("0.00");
                                Foil = (BookOptionPricing.Foil * MsCopies);
                                vBookCalcTax += (Foil * this.TaxRate);
                                lblMsTot.Text = Foil.ToString("0.00");
                            }
                            else
                            {
                                lblMsTot.Text = "0.00";
                                foilamtTextBox.Text = "0.00";
                            }
                        }
                        else
                        {
                            lblMsTot.Text = "0.00";
                            foilamtTextBox.Text = "0.00";
                        }
                        //Lam
                        decimal Laminationsft = 0;
                        if (chkMLaminate.Checked)
                        {
                            Laminationsft = (BookOptionPricing.Laminationsft * numberOfCopies);
                            vBookCalcTax += (Laminationsft * this.TaxRate);
                            lblMLaminateAmt.Text = Laminationsft.ToString();

                        }
                        else
                        {
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

                        vParseResult = decimal.TryParse(lblBookTotal.Text.ToString().Replace("$", ""), out BookTotal);
                        vParseResult = decimal.TryParse(lblSpeccvrtot.Text, out SpecCvrTot);
                        vParseResult = decimal.TryParse(txtFoilAd.Text, out FoilTot);
                        vParseResult = decimal.TryParse(txtClrTot.Text, out ClrPgTot);
                        vParseResult = decimal.TryParse(txtMisc.Text, out MiscTot);
                        vParseResult = decimal.TryParse(txtDesc1amt.Text, out Desc1Tot);
                        vParseResult = decimal.TryParse(txtDesc3tot.Text, out Desc3Tot);
                        vParseResult = decimal.TryParse(txtDesc4tot.Text, out Desc4Tot);
                        vBookCalcTax += (this.TaxRate * (SpecCvrTot + FoilTot + ClrPgTot + MiscTot + Desc1Tot + Desc3Tot + Desc4Tot));
                        //old way of sales tax
                        // this.SalesTax = Math.Round(vBookCalcTax, 2, MidpointRounding.AwayFromZero);                    
                        //this.lblSalesTax.Text = this.SalesTax.ToString("c");

                        decimal SubTotal = (BookTotal + HardBack + Casebind + Perfectbind + Spiral + SaddleStitch + Professional + Convenient + Yir + Story + Gloss + Laminationsft + SpecCvrTot + FoilTot + ClrPgTot + MiscTot + Desc1Tot + Desc3Tot + Desc4Tot);

                        lblsubtot.Text = SubTotal.ToString("c");
                        //calculate after subtotal
                        decimal disc1 = 0;
                        decimal disc2 = 0;
                        decimal disc3 = 0;
                        decimal msTot = 0;
                        decimal persTot = 0;
                        decimal iconTot = 0;
                        decimal vTax = 0;
                        vParseResult = decimal.TryParse(lbldisc1.Text, out disc1);
                        vParseResult = decimal.TryParse(lbldisc2.Text, out disc2);
                        vParseResult = decimal.TryParse(lblDisc3.Text, out disc3);
                        vParseResult = decimal.TryParse(lblMsTot.Text, out msTot);
                        vParseResult = decimal.TryParse(lblperstotal.Text, out persTot);
                        vParseResult = decimal.TryParse(lblIconTot.Text, out iconTot);
                        //Old way of taxes
                        //var a = (disc1 * this.TaxRate);
                        //vBookCalcTax += (disc1 * this.TaxRate);
                        //vBookCalcTax += (disc2 * this.TaxRate);
                        //vBookCalcTax += (disc3 * this.TaxRate);
                        //vBookCalcTax += (msTot * this.TaxRate);
                        //vBookCalcTax += (persTot * this.TaxRate);
                        //vBookCalcTax += (iconTot * this.TaxRate);
                        //this.SalesTax = Math.Round(vBookCalcTax, 2, MidpointRounding.AwayFromZero);
                        // this.lblSalesTax.Text = this.SalesTax.ToString("c");
                        //new tax cal
                        vParseResult = decimal.TryParse(lblSalesTax.Text.Replace("$", ""), out vTax);
                        SubTotal += (disc1 + disc2 + disc3 + msTot + persTot + iconTot);
                        if (!donotchargeschoolsalestaxCheckBox.Checked)
                        {
                            vTax = GetTax(SubTotal);
                            this.lblSalesTax.Text = vTax.ToString("$0.00");
                        }
                        else
                        {
                            vTax = 0;
                            this.lblSalesTax.Text = vTax.ToString("$0.00");
                            lblTaxRateValue.Text = "$.00";
                        }



                        //----------------------------------------------------------



                        lblFinalTotPrc.Text = SubTotal.ToString("$0.00");
                        txtFinalbookprc.Text = ((SubTotal) / numberOfCopies).ToString("c");
                        //other charges and credies
                        decimal credit1 = 0;
                        decimal credit2 = 0;
                        decimal otherchrg1 = 0;
                        decimal otherchrg2 = 0;
                        vParseResult = decimal.TryParse(txtCredits.Text, out credit1);
                        vParseResult = decimal.TryParse(txtCredits2.Text, out credit2);
                        vParseResult = decimal.TryParse(txtOtherChrg.Text, out otherchrg1);
                        vParseResult = decimal.TryParse(txtOtherChrg2.Text, out otherchrg2);
                        lbladjbef.Text = (SubTotal + credit1 + credit2 + otherchrg1 + otherchrg2 + vTax).ToString("c");

                    }
                }
            }
        }
        private void GetBookPricing()
        {
            if (String.IsNullOrEmpty(txtBYear.Text))
            {
                errorProvider1.SetError(txtBYear, "");

                errorProvider1.SetError(txtBYear, "Please enter a  base price year.");
                return;
            }
            this.CurPriceYr = txtBYear.Text;


            SqlConnection conn = new SqlConnection(this.FormConnectionString);
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


            List<Price> PriceList = new List<Price>();

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
            SqlConnection conn = new SqlConnection(FormConnectionString);
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
            }
            catch (Exception ex)
            {
                Log.Fatal("Error retrieving Book Option Pricing" + ex.Message);
                MessageBox.Show("There was an error retrieving Book Option Pricing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this.BookOptionPricing == null)
            {
                MessageBox.Show("Book Option pricing for this contract year was not found. Contact your supervisor.");
            }

        }
        #endregion

        private void collectionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetNoticeLabels();
        }

        private void frmMSales_Activated(object sender, EventArgs e)
        {
            try { frmMain.ShowSearchButtons(this.Name); } catch { }
        }

        private void frmMSales_Deactivate(object sender, EventArgs e)
        {
            try { frmMain.HideSearchButtons(); } catch { }
        }



        //nothing below here
    }
    }
