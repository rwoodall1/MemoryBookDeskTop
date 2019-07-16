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
using BindingModels;
using Exceptionless;
using System.Reflection;

namespace Mbc5.Forms.Meridian {
    public partial class frmMSales : BaseClass.frmBase
    {

        public frmMSales(UserPrincipal userPrincipal, int invno, string schcode) : base(new string[] { "SA", "Administrator", "MerCS" }, userPrincipal)
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = invno;
            this.Schcode = schcode;

        }
        public frmMSales(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MerCS" }, userPrincipal)
        {
            InitializeComponent();
            //this.DisableControls(this);

            //EnableControls(btnPoSrch);
            //EnableControls(txtPoSrch);
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = 0;
            this.Schcode = null;

        }
        private UserPrincipal ApplicationUser { get; set; }
        public frmMain frmMain { get; set; }
        protected string CurPriceYr { get; set; }
        protected MeridianPrice Pricing { get; set; }
        private void frmMSales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lookUp.MeridianProducts' table. You can move, or remove it, as needed.
            this.meridianProductsTableAdapter.Fill(this.lookUp.MeridianProducts);
            SetConnectionString();
            Fill();
            this.tabControl1.TabPages[0].AutoScroll = false;
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

            if (Invno != 0)
            {
                try
                {
                    mquotesTableAdapter.Fill(dsMSales.mquotes, Invno);
                    // xtraTableAdapter.Fill(dsExtra.xtra, Invno);
                    SetCodeInvno();
                    lblAppUser.Text = this.ApplicationUser.id;
                    SetNoticeLabels();
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "");
                }

            }




        }
        private void DisableControls(Control con)
        {
            //foreach (Control c in con.Controls)
            //{
            //    DisableControls(c);
            //}
            //con.Enabled = false;
        }
        private void EnableControls(Control con)
        {
            //if (con != null)
            //{
            //    con.Enabled = true;
            //    EnableControls(con.Parent);
            //}
        }
        private void EnableAllControls(Control con)
        {
            //foreach (Control c in con.Controls)
            //{
            //    EnableAllControls(c);
            //}
            //con.Enabled = true;
        }
        private void SetConnectionString()
        {
            this.frmMain = (frmMain)this.MdiParent;
            this.FormConnectionString = frmMain.AppConnectionString;
            this.meridianProductsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.mquotesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            // this.paymntTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            // this.invdetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            // this.invCustTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            //this.invHstTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            // this.invoiceTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            //this.xtraTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;

        }
        private void Test()
        {
            GetBookPricing();
            var qtyField = "Q400";

            var a = (decimal)ObjectFieldValue.Get<MeridianPrice>(qtyField, Pricing);

        }
        private void CalculateBase()
        {
            if (Pricing == null)
            {
                if (!GetBookPricing())
                {
                    return;
                }
            }
            if (chkGeneric.Checked)
            {
                CalculateGeneric();
            }
            if (chkJostens.Checked)
            {
                CalculateJostenBase();
                return;
            }
            //calculate regular
            decimal vBasePrice = 0;
            decimal vPriceOveride = 0;
            decimal vTeacherBasePrice = 0;
            int vQtyTeacher = 0;
            int vQtyStudent = 0;
            int vTotalQty = 0;
            int vPages = 0;
            int pageMultiplier = 0;
            decimal xtraPagePrice = 0;
            decimal.TryParse(txtPriceOverRide.Text, out vPriceOveride);
            int.TryParse(txtQtyTeacher.Text, out vQtyTeacher);
            int.TryParse(txtQtyStudent.Text, out vQtyStudent);
            vTotalQty = vQtyStudent + vQtyTeacher;
            int.TryParse(txtNoPages.Text, out vPages);
            int mPages;
            txtTotalQty.Text = vTotalQty.ToString("0.00");
            if (contryearTextBox.Text == "")
            {
                return;
            }


            if (lfRadioButton.Checked)
            {
                if (vPriceOveride > 0)
                {
                    vBasePrice = vPriceOveride;
                    lblBasePrice.Text = vBasePrice.ToString("0.00");
                    if (string.IsNullOrEmpty(txtQtyTeacher.Text))
                    {
                        vTeacherBasePrice = 0;
                        lblTeachBasePrice.Text = "0.00";
                    }
                    else
                    {
                        lblTeachBasePrice.Text = vBasePrice.ToString("0.00");
                        //always same for Large Font
                        vTeacherBasePrice = vBasePrice;
                    }
                    lblTotalBasePrice.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher)).ToString("0.00");
                    return;
                }

                if (vPages == 0) { mPages = 4; } else { mPages = vPages; }
                //field to look for
                string qtyField = GetCopies(vTotalQty);
                pageMultiplier = GetXtraPages(mPages, "LF", CurPriceYr);
                xtraPagePrice = pageMultiplier * Pricing.StandardPageCost;
                vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>(qtyField, Pricing);
                if (vPages == 0) { vBasePrice += Pricing.ZeroPageCost; }
                if (vPages == 4) { vBasePrice += Pricing.FourPageCost; }
                vBasePrice += xtraPagePrice;
                if (string.IsNullOrEmpty(txtQtyTeacher.Text))
                {
                    lblTeachBasePrice.Text = "0.00";
                }
                else
                {
                    lblTeachBasePrice.Text = vBasePrice.ToString("0.00");
                }
                if (!string.IsNullOrEmpty(txtPriceOverRide.Text))
                {
                    lblBasePrice.Text = txtPriceOverRide.Text;
                }
                else { lblBasePrice.Text = vBasePrice.ToString("0.00"); }

            }
            //////////////----------------------------------------------------------------
            if (sfRadioButton.Checked)
            {
                if (vPriceOveride > 0)
                {
                    vBasePrice = vPriceOveride;
                    lblBasePrice.Text = vBasePrice.ToString("0.00");
                    if (string.IsNullOrEmpty(txtQtyTeacher.Text))
                    {
                        vTeacherBasePrice = 0;
                        lblTeachBasePrice.Text = "0.00";
                    }
                    else
                    {
                        lblTeachBasePrice.Text = vBasePrice.ToString("0.00");
                        vTeacherBasePrice = vBasePrice;
                    }
                    lblTotalBasePrice.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher)).ToString("0.00");
                    return;
                }
                if (vPages == 0) { mPages = 8; } else { mPages = vPages; }
                var qtyField = GetCopies(vTotalQty);
                pageMultiplier = GetXtraPages(mPages, "SF", CurPriceYr);
                xtraPagePrice = pageMultiplier * Pricing.StandardPageCost;
                vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>(qtyField, Pricing);
                if (vPages == 0) { vBasePrice += Pricing.ZeroPageCost; }
                if (vPages == 8) { vBasePrice += Pricing.EightPageCost; }
                vBasePrice += xtraPagePrice;


                lblBasePrice.Text = vBasePrice.ToString("0.00");
            }

        }
        private void CalculateJostenBase()
        {
            decimal vBasePrice = 0;
            decimal vPriceOveride = 0;
            decimal vTeacherBasePrice = 0;
            int vQtyTeacher = 0;
            int vQtyStudent = 0;
            int vTotalQty = 0;
            int vPages = 0;
            int pageMultiplier = 0;
            decimal xtraPagePrice = 0;
            decimal.TryParse(txtPriceOverRide.Text, out vPriceOveride);
            int.TryParse(txtQtyTeacher.Text, out vQtyTeacher);
            int.TryParse(txtQtyStudent.Text, out vQtyStudent);
            vTotalQty = vQtyStudent + vQtyTeacher;
            int.TryParse(txtNoPages.Text, out vPages);
            int mPages;
            txtTotalQty.Text = vTotalQty.ToString("0.00");
            if (contryearTextBox.Text == "")
            {
                return;
            }
            if (vPriceOveride > 0)
            {
                vBasePrice = vPriceOveride;
                lblBasePrice.Text = vBasePrice.ToString("0.00");
                if (string.IsNullOrEmpty(txtQtyTeacher.Text))
                {
                    vTeacherBasePrice = 0;
                    lblTeachBasePrice.Text = "0.00";
                }
                else
                {
                    lblTeachBasePrice.Text = vBasePrice.ToString("0.00");
                    //always same for Large Font
                    vTeacherBasePrice = vBasePrice;
                }
                lblTotalBasePrice.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher)).ToString("0.00");
                return;
            }
            if (vPages > 76)

            {
                MbcMessageBox.Information("Pages are over 76, Jostens pricing not available. Enter a price override.");
                return;

            }
            if (string.IsNullOrEmpty(txtBYear.Text))
            {
                MbcMessageBox.Information("Enter a base price year");
                return;
            }
            var vJostenPrice = GetJostensPricing(txtBYear.Text, sfRadioButton.Checked ? "SF" : "LF", vPages);
            if (vTotalQty < 600)
            {
                vJostenPrice += .25m;
            }
            lblBasePrice.Text = vJostenPrice.ToString("0.00");
            if (vQtyTeacher>0) {
                lblTeachBasePrice.Text = vJostenPrice.ToString("0.00");//same as student
            }
            lblTotalBasePrice.Text = ((vJostenPrice * vQtyStudent) + (vJostenPrice * vQtyTeacher)).ToString("0.00");

        }

    
        private void CalculateGeneric()
        {

        }
        private decimal GetJostensPricing(string vYear,string vType,int pageQty)
        {
            string fieldName = vType + pageQty.ToString();
            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"Select * From JostensPricing where Yr=@Yr");
            sqlQuery.AddParameter("@Yr",vYear);
            var result=sqlQuery.Select<JostenPricing>();
            var vPricing=(JostenPricing)result.Data;
            if(result.IsError)
            { MbcMessageBox.Error(result.Errors[0].ErrorMessage); return 0; }
            var vJostensBasePrice =(decimal)ObjectFieldValue.Get<JostenPricing>(fieldName, vPricing);
            return vJostensBasePrice;
        }
        private int GetXtraPages(int Qty,string Facing,string Year)
        {
            int retval = 0;
            if(Facing=="LF"&& Qty == 4)
            {
                retval = 0;
            }else if (Facing == "LF" && Qty>=8)
            {
                var vLeftOver = Qty % 2;//make sure pages are even
               if(vLeftOver==0)
                {
                    retval = (Qty - 8);
                }
            }

            //SF
            if (Facing == "SF" && Qty == 8)
            {
                retval = 0;
            }else if (Facing=="SF" && Qty>=16)
            {
                var vLeftOver = Qty % 2;
                if (vLeftOver == 0)
                {
                    retval=(Qty-16);
                }
            }

            return retval;

        }
        private string GetCopies(int requestedCopies)
        {
            
            string retval = "";
            int a = 1;
            if (requestedCopies <= 199)
            {
                retval = "Q100";
            }else if (requestedCopies >= 200 && requestedCopies <= 249)
            {
                retval = "Q200";
            }
            else if (requestedCopies >= 250 && requestedCopies <= 299)
            {
                retval = "Q250";
            }
            else if (requestedCopies >= 300 && requestedCopies <= 399)
            {
                retval = "Q300";
            }
            else if (requestedCopies >=400 && requestedCopies <= 599)
            {
                retval = "Q400";
            }
            else if (requestedCopies >= 600 && requestedCopies <= 799)
            {
                retval = "Q600";
            }
            else if (requestedCopies >= 800 && requestedCopies <= 999)
            {
                retval = "Q800";
            }
            else if (requestedCopies >= 1000 && requestedCopies <= 1999)
            {
                retval = "Q1000";
            }
            else if (requestedCopies >= 2000 )
            {
                retval = "Q2000";
            }

            return retval;
        }

        //private void BookCalc()
        //{
        //    // removes old tax calc
        //    this.TaxRate = 0;
        //    //
        //    decimal vbookTotal = 0;
        //    decimal vBookCalcTax = 0;
        //    try
        //    {
        //        //errors when refilling and this is called before values refreshed
        //        vbookTotal = System.Convert.ToDecimal(lblBookTotal.Text.Replace("$", ""));
        //        vBookCalcTax = this.TaxRate * vbookTotal;
        //    }
        //    catch (Exception ex)
        //    {

        //        return;
        //    }
        //    if (!startup)
        //    {
        //        if (quotesBindingSource.Count > 0)
        //        {
        //            if (!ValidateCopies() || !ValidatePageCount())
        //            {
        //                return;
        //            }
        //            if (BookOptionPricing == null) { GetBookOptionPricing(); }
        //            if (CurPriceYr != txtBYear.Text) { CalculateEach(); }
        //            int numberOfCopies = 0;
        //            int numberOfPages = 0;
        //            var parseresult = int.TryParse(txtNocopies.Text, out numberOfCopies);
        //            var parseresult1 = int.TryParse(txtNoPages.Text, out numberOfPages);
        //            if (!parseresult)
        //            {
        //                MessageBox.Show("Number of copies is not valid!", "Copies", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return;
        //            }
        //            if (!parseresult1)
        //            {
        //                MessageBox.Show("Number of pages is not valid!", "Pages", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return;
        //            }
        //            if (this.BookOptionPricing != null && CurPriceYr == txtBYear.Text)
        //            {

        //                //Hardback
        //                decimal HardBack = 0;
        //                if (chkHardBack.Checked)
        //                {
        //                    HardBack = BookOptionPricing.Hardbk * numberOfCopies;
        //                    vBookCalcTax += (HardBack * this.TaxRate);
        //                    lblHardbackAmt.Text = HardBack.ToString();
        //                    CalcInk();
        //                }
        //                else
        //                {
        //                    lblHardbackAmt.Text = "0.00";

        //                    HardBack = 0;
        //                }
        //                //Casebind
        //                decimal Casebind = 0;
        //                if (chkCaseBind.Checked)
        //                {
        //                    Casebind = BookOptionPricing.Customized * numberOfCopies;
        //                    vBookCalcTax += (Casebind * this.TaxRate);
        //                    lblCaseamt.Text = Casebind.ToString();
        //                    CalcInk();
        //                }
        //                else
        //                {
        //                    lblCaseamt.Text = "0.00";
        //                    Casebind = 0;
        //                }
        //                //Check if harback and case both not checked
        //                if (!chkHardBack.Checked && !chkCaseBind.Checked)
        //                {
        //                    CalcInk();
        //                }
        //                //Perfect Bind
        //                decimal Perfectbind = 0;
        //                if (chkPerfBind.Checked)
        //                {
        //                    Perfectbind = BookOptionPricing.Perfectbind * numberOfCopies;
        //                    vBookCalcTax += (Perfectbind * this.TaxRate);
        //                    lblPerfbindAmt.Text = Perfectbind.ToString();

        //                }
        //                else
        //                {
        //                    lblPerfbindAmt.Text = "0.00";
        //                    Perfectbind = 0;
        //                }
        //                //Spiral
        //                decimal Spiral = 0;
        //                if (chkSpiral.Checked)
        //                {
        //                    Spiral = (BookOptionPricing.Spiral * numberOfCopies);
        //                    vBookCalcTax += (Spiral * this.TaxRate);
        //                    lblSpiralAmt.Text = Spiral.ToString();
        //                }
        //                else
        //                {
        //                    lblSpiralAmt.Text = "0.00";
        //                    Spiral = 0;
        //                }
        //                //SaddleStitch
        //                decimal SaddleStitch = 0;
        //                if (chkSaddlStitch.Checked)
        //                {
        //                    SaddleStitch = (BookOptionPricing.SaddleStitch * numberOfCopies);
        //                    vBookCalcTax += (SaddleStitch * this.TaxRate);
        //                    lblSaddleAmt.Text = SaddleStitch.ToString();

        //                }
        //                else
        //                {
        //                    lblSaddleAmt.Text = "0.00";
        //                    SaddleStitch = 0;
        //                }

        //                //Professional
        //                decimal Professional = 0;
        //                if (chkProfessional.Checked)
        //                {
        //                    Professional = (BookOptionPricing.Professional * numberOfPages);
        //                    vBookCalcTax += (Professional * this.TaxRate);
        //                    lblProfAmt.Text = Professional.ToString();

        //                }
        //                else
        //                {
        //                    lblProfAmt.Text = "0.00";
        //                    Professional = 0;
        //                }

        //                //Convenient
        //                decimal Convenient = 0;
        //                if (chkConv.Checked)
        //                {
        //                    Convenient = (BookOptionPricing.Convenient * numberOfPages);
        //                    vBookCalcTax += (Convenient * this.TaxRate);
        //                    lblConvAmt.Text = Convenient.ToString();

        //                }
        //                else
        //                {
        //                    lblConvAmt.Text = "0.00";
        //                    Convenient = 0;
        //                }
        //                //Yir
        //                decimal Yir = 0;
        //                if (chkYir.Checked)
        //                {
        //                    Yir = (BookOptionPricing.Ink * numberOfCopies);
        //                    vBookCalcTax += (Yir * this.TaxRate);
        //                    lblYir.Text = Yir.ToString();
        //                }
        //                else
        //                {
        //                    lblYir.Text = "0.00";
        //                    Yir = 0;
        //                }
        //                //our story
        //                decimal Story = 0;
        //                if (chkStory.Checked)
        //                {
        //                    Story = (BookOptionPricing.Story * numberOfCopies);
        //                    vBookCalcTax += (Story * this.TaxRate);
        //                    lblStoryAmount.Text = Story.ToString();
        //                }
        //                else
        //                {
        //                    lblStoryAmount.Text = "0.00";
        //                    Story = 0;
        //                }


        //                //Gloss
        //                decimal Gloss = 0;
        //                if (chkGlossLam.Checked)
        //                {
        //                    if (chkHardBack.Checked || chkCaseBind.Checked)
        //                    {
        //                        lblLaminateAmt.Text = "0.00";
        //                        Gloss = 0;
        //                    }
        //                    else
        //                    {
        //                        Gloss = (BookOptionPricing.Lamination * numberOfCopies);
        //                        vBookCalcTax += (Gloss * this.TaxRate);
        //                        lblLaminateAmt.Text = Gloss.ToString();
        //                    }
        //                }
        //                else
        //                {
        //                    lblLaminateAmt.Text = "0.00";
        //                    Gloss = 0;
        //                }
        //                //foilamt/msStory
        //                decimal Foil = 0;
        //                int MsCopies = 0;
        //                var result = int.TryParse(txtMsQty.Text, out MsCopies);

        //                if (chkMsStandard.Checked)
        //                {
        //                    if (result)
        //                    {
        //                        foilamtTextBox.Text = BookOptionPricing.Foil.ToString("0.00");
        //                        Foil = (BookOptionPricing.Foil * MsCopies);
        //                        vBookCalcTax += (Foil * this.TaxRate);
        //                        lblMsTot.Text = Foil.ToString("0.00");
        //                    }
        //                    else
        //                    {
        //                        lblMsTot.Text = "0.00";
        //                        foilamtTextBox.Text = "0.00";
        //                    }
        //                }
        //                else
        //                {
        //                    lblMsTot.Text = "0.00";
        //                    foilamtTextBox.Text = "0.00";
        //                }
        //                //Lam
        //                decimal Laminationsft = 0;
        //                if (chkMLaminate.Checked)
        //                {
        //                    Laminationsft = (BookOptionPricing.Laminationsft * numberOfCopies);
        //                    vBookCalcTax += (Laminationsft * this.TaxRate);
        //                    lblMLaminateAmt.Text = Laminationsft.ToString();

        //                }
        //                else
        //                {
        //                    lblMLaminateAmt.Text = "0.00";
        //                    Laminationsft = 0;
        //                }
        //                //convert rest of info from strings to decimals for calculations
        //                bool vParseResult;
        //                decimal BookTotal = 0;
        //                decimal SpecCvrTot = 0;
        //                decimal FoilTot = 0;
        //                decimal ClrPgTot = 0;
        //                decimal MiscTot = 0;
        //                decimal Desc1Tot = 0;
        //                decimal Desc3Tot = 0;
        //                decimal Desc4Tot = 0;

        //                vParseResult = decimal.TryParse(lblBookTotal.Text.ToString().Replace("$", ""), out BookTotal);
        //                vParseResult = decimal.TryParse(lblSpeccvrtot.Text, out SpecCvrTot);
        //                vParseResult = decimal.TryParse(txtFoilAd.Text, out FoilTot);
        //                vParseResult = decimal.TryParse(txtClrTot.Text, out ClrPgTot);
        //                vParseResult = decimal.TryParse(txtMisc.Text, out MiscTot);
        //                vParseResult = decimal.TryParse(txtDesc1amt.Text, out Desc1Tot);
        //                vParseResult = decimal.TryParse(txtDesc3tot.Text, out Desc3Tot);
        //                vParseResult = decimal.TryParse(txtDesc4tot.Text, out Desc4Tot);
        //                vBookCalcTax += (this.TaxRate * (SpecCvrTot + FoilTot + ClrPgTot + MiscTot + Desc1Tot + Desc3Tot + Desc4Tot));
        //                //old way of sales tax
        //                // this.SalesTax = Math.Round(vBookCalcTax, 2, MidpointRounding.AwayFromZero);                    
        //                //this.lblSalesTax.Text = this.SalesTax.ToString("c");

        //                decimal SubTotal = (BookTotal + HardBack + Casebind + Perfectbind + Spiral + SaddleStitch + Professional + Convenient + Yir + Story + Gloss + Laminationsft + SpecCvrTot + FoilTot + ClrPgTot + MiscTot + Desc1Tot + Desc3Tot + Desc4Tot);

        //                lblsubtot.Text = SubTotal.ToString("c");
        //                //calculate after subtotal
        //                decimal disc1 = 0;
        //                decimal disc2 = 0;
        //                decimal disc3 = 0;
        //                decimal msTot = 0;
        //                decimal persTot = 0;
        //                decimal iconTot = 0;
        //                decimal vTax = 0;
        //                vParseResult = decimal.TryParse(lbldisc1.Text, out disc1);
        //                vParseResult = decimal.TryParse(lbldisc2.Text, out disc2);
        //                vParseResult = decimal.TryParse(lblDisc3.Text, out disc3);
        //                vParseResult = decimal.TryParse(lblMsTot.Text, out msTot);
        //                vParseResult = decimal.TryParse(lblperstotal.Text, out persTot);
        //                vParseResult = decimal.TryParse(lblIconTot.Text, out iconTot);
        //                //Old way of taxes
        //                //var a = (disc1 * this.TaxRate);
        //                //vBookCalcTax += (disc1 * this.TaxRate);
        //                //vBookCalcTax += (disc2 * this.TaxRate);
        //                //vBookCalcTax += (disc3 * this.TaxRate);
        //                //vBookCalcTax += (msTot * this.TaxRate);
        //                //vBookCalcTax += (persTot * this.TaxRate);
        //                //vBookCalcTax += (iconTot * this.TaxRate);
        //                //this.SalesTax = Math.Round(vBookCalcTax, 2, MidpointRounding.AwayFromZero);
        //                // this.lblSalesTax.Text = this.SalesTax.ToString("c");
        //                //new tax cal
        //                vParseResult = decimal.TryParse(lblSalesTax.Text.Replace("$", ""), out vTax);
        //                SubTotal += (disc1 + disc2 + disc3 + msTot + persTot + iconTot);
        //                if (!donotchargeschoolsalestaxCheckBox.Checked)
        //                {
        //                    vTax = GetTax(SubTotal);
        //                    this.lblSalesTax.Text = vTax.ToString("$0.00");
        //                }
        //                else
        //                {
        //                    vTax = 0;
        //                    this.lblSalesTax.Text = vTax.ToString("$0.00");
        //                    lblTaxRateValue.Text = "$.00";
        //                }



        //                //----------------------------------------------------------



        //                lblFinalTotPrc.Text = SubTotal.ToString("$0.00");
        //                txtFinalbookprc.Text = ((SubTotal) / numberOfCopies).ToString("c");
        //                //other charges and credies
        //                decimal credit1 = 0;
        //                decimal credit2 = 0;
        //                decimal otherchrg1 = 0;
        //                decimal otherchrg2 = 0;
        //                vParseResult = decimal.TryParse(txtCredits.Text, out credit1);
        //                vParseResult = decimal.TryParse(txtCredits2.Text, out credit2);
        //                vParseResult = decimal.TryParse(txtOtherChrg.Text, out otherchrg1);
        //                vParseResult = decimal.TryParse(txtOtherChrg2.Text, out otherchrg2);
        //                lbladjbef.Text = (SubTotal + credit1 + credit2 + otherchrg1 + otherchrg2 + vTax).ToString("c");

        //            }
        //        }
        //    }
        //}
        private bool GetBookPricing()
        {
            var sqlQuery = new SQLCustomClient();
            sqlQuery.ClearParameters();
            if (String.IsNullOrEmpty(txtBYear.Text))
            {
                errorProvider1.SetError(txtBYear, "");

                errorProvider1.SetError(txtBYear, "Please enter a  base price year.");
                return false;
            }
            this.CurPriceYr = txtBYear.Text;
            sqlQuery.CommandText(@"
                SELECT * From MeridianPricing where Type=@Type and yr=@Yr 
                ");
            sqlQuery.AddParameter("@Type", lfRadioButton.Checked ? "LF" : "SF");
            sqlQuery.AddParameter("@Yr", CurPriceYr);
            var pricingResult = sqlQuery.Select<MeridianPrice>();
            if (pricingResult.IsError)
            {
                ExceptionlessClient.Default.CreateLog("Error getting Meridian Pricing")
                    .AddObject(pricingResult)
                    .MarkAsCritical()
                    .Submit();
                MbcMessageBox.Error("Failed to get meridian pricing" + pricingResult.Errors[0].DeveloperMessage);
                return false;
            }
            if (pricingResult.Data == null)
            {
                MbcMessageBox.Information("Meridian pricing for the given year and type was not found.");
                return false; ;
            }
            Pricing = (MeridianPrice)pricingResult.Data;
            return true;
        }
        //private void GetBookOptionPricing()
        //{
        //    this.CurPriceYr = txtBYear.Text;
        //    SqlConnection conn = new SqlConnection(FormConnectionString);
        //    SqlCommand cmd = new SqlCommand("SELECT * From BookOptionPricing where yr=@Yr", conn);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.Clear();
        //    cmd.Parameters.AddWithValue("@Yr", txtBYear.Text);//base price yr

        //    try
        //    {

        //        cmd.Connection.Open();
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            BookOptionPrice vOptionPrice = new BookOptionPrice()
        //            {
        //                Yr = rdr.GetOrdinal("Yr").ToString(),
        //                Case = rdr.GetDecimal(rdr.GetOrdinal("Case")),
        //                Professional = rdr.GetDecimal(rdr.GetOrdinal("Professional")),
        //                Convenient = rdr.GetDecimal(rdr.GetOrdinal("Convenient")),
        //                Specialcvr = rdr.GetDecimal(rdr.GetOrdinal("Specialcvr")),
        //                Lamination = rdr.GetDecimal(rdr.GetOrdinal("Lamination")),
        //                Perfectbind = rdr.GetDecimal(rdr.GetOrdinal("Perfectbind")),
        //                Customized = rdr.GetDecimal(rdr.GetOrdinal("Customized")),
        //                Hardbk = rdr.GetDecimal(rdr.GetOrdinal("Hardbk")),
        //                Foil = rdr.GetDecimal(rdr.GetOrdinal("Foil")),
        //                Ink = rdr.GetDecimal(rdr.GetOrdinal("Ink")),
        //                Spiral = rdr.GetDecimal(rdr.GetOrdinal("Spiral")),
        //                Theme = rdr.GetDecimal(rdr.GetOrdinal("Theme")),
        //                Story = rdr.GetDecimal(rdr.GetOrdinal("Story")),
        //                Yir = rdr.GetDecimal(rdr.GetOrdinal("Yir")),
        //                Supplement = rdr.GetDecimal(rdr.GetOrdinal("Supplement")),
        //                Laminationsft = rdr.GetDecimal(rdr.GetOrdinal("Laminationsft"))

        //            };
        //            this.BookOptionPricing = vOptionPrice;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Fatal("Error retrieving Book Option Pricing" + ex.Message);
        //        MessageBox.Show("There was an error retrieving Book Option Pricing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    if (this.BookOptionPricing == null)
        //    {
        //        MessageBox.Show("Book Option pricing for this contract year was not found. Contact your supervisor.");
        //    }

        //}
        private void SetCodeInvno()
        {
            if (mquotesBindingSource.Count > 0)
            {
                DataRowView current = (DataRowView)mquotesBindingSource.Current;
                this.Schcode = current["schcode"].ToString();
                this.Invno = Convert.ToInt32(current["invno"]);
                var vKitrecvd = "";
                if (!((DataRowView)mquotesBindingSource.Current).Row.IsNull("kitrecvd"))
                {
                    ((DataRowView)mquotesBindingSource.Current).Row["kitrecvd"].ToString();
                }

                //booktypeTextBox.ReadOnly = string.IsNullOrEmpty(vKitrecvd);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Test();
        }



        private void chkindateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            chkindateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void txtQtyStudent_Leave(object sender, EventArgs e)
        {
            CalculateBase();
        }

        private void txtQtyTeacher_Leave(object sender, EventArgs e)
        {
            CalculateBase();
        }

        private void prodcodeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var dr = (DataRowView)mquotesBindingSource.Current;
            if (prodcodeComboBox.SelectedValue.ToString() == "HSP"|| prodcodeComboBox.SelectedValue.ToString() == "ADVLOG"|| prodcodeComboBox.SelectedValue.ToString() == "MAG")
            {
                sfRadioButton.Checked = true;
                lfRadioButton.Checked = false;
              

                  
            }
            else
            {
                sfRadioButton.Checked = false;
                lfRadioButton.Checked = true;
            }
            switch (prodcodeComboBox.SelectedValue.ToString())
            {
                case "HSP":
                    dr.Row["Schtype"] = "HS";
                break;
                case "MSP":
                    dr.Row["Schtype"] = "MS";
                break;
                case "MAG":
                    dr.Row["Schtype"] = "MAGNET";
                break;
                case "ADVLOG":
                    dr.Row["Schtype"] = "ADVENTURE LOG";
                break;
                case "ELSP":
                    dr.Row["Schtype"] = "ELEM";
                break;
                case "PRISP":
                    dr.Row["Schtype"] ="PRIM";
                break;
            }



        }



        //nothing below here
    }
    }
