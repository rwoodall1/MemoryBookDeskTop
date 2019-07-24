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
using Mbc5.Classes;
namespace Mbc5.Forms.Meridian {
    public partial class frmMBids : BaseClass.frmBase {
        public frmMBids(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MerCS" }, userPrincipal)
        { 
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            }
        public frmMBids(UserPrincipal userPrincipal, string schcode) : base(new string[] { "SA", "Administrator", "MerCS" }, userPrincipal)
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Schcode = schcode;
        }

        #region Properties
        private UserPrincipal ApplicationUser { get; set; }
        protected frmMain frmMain { get; set; }
        protected string CurPriceYr { get; set; }
        protected string Schname { get; set; }
        protected string SchoolZipCode { get; set; }
        protected MeridianPrice Pricing { get; set; }
        protected MeridianOptionPricing OptionPrices { get; set; }
        #endregion

        private void frmMBids_Load(object sender, EventArgs e)
        {
            this.frmMain = (frmMain)this.MdiParent;
            this.SetConnectionString();
            Fill();
            mbidsBindingSource.ResetBindings(true);
        }
        #region Methods
        private void Fill()
        {
            if (Schcode != null)
            {
                try
                {
                    this.mbidsTableAdapter.Fill(this.dsMBids.mbids, this.Schcode);
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "");
                }
            }
            if (mbidsBindingSource.Count == 0)
            {
                DisableControls(this);
                EnableControls(this);
            }
            else
            {
               
            }
            try
            {
                this.Schname = ((DataRowView)mbidsBindingSource.Current).Row["schname"].ToString().Trim();
                this.SchoolZipCode = ((DataRowView)this.mbidsBindingSource.Current).Row["schzip"].ToString().Trim().Substring(0, 5);

            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message, "");
            }
        }
        private void SetConnectionString()
        {
            mbidsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
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
        private void CalculateOptions()
        {
            if (!Validate())
            {
                return;
            }
            if (sfRadioButton.Checked)
            {

                vpbqtyTextBox.Enabled = false;
                vpbqtyTextBox.Text = "0";
                vpbprcTextBox.Text = "0.00";

            }
            else
            {
                vpbqtyTextBox.Enabled = true;
            }

            if (OptionPrices == null)
            {
                GetOptionPricing();
            }
            int vnumberOfCovers = 0;
            if (desc2TextBox1.Text.Length > 0)
            {
                vnumberOfCovers += 1;
            }
            if (desc3TextBox1.Text.Length > 0)
            {
                vnumberOfCovers += 1;
            }
            if (desc4TextBox1.Text.Length > 0)
            {
                vnumberOfCovers += 1;
            }
            switch (vnumberOfCovers)
            {
                case 1:
                    lblSpecialCoverPrice.Text = OptionPrices.SpecialCoverPrice1.ToString();
                    break;
                case 2:
                    lblSpecialCoverPrice.Text = OptionPrices.SpecialCoverPrice2.ToString();
                    break;
                case 3:
                    lblSpecialCoverPrice.Text = OptionPrices.SpecialCoverPrice3.ToString();
                    break;
                default:
                    lblSpecialCoverPrice.Text = "0.00";
                    break;

            }

            hallppriceTextBox.Text = (hallpqtyTextBox.ConvertToInt() * (lfRadioButton.Checked ? OptionPrices.HallPassSF : OptionPrices.HallPassLF)).ToString();
            bmarkprcTextBox.Text = (bmarkqtyTextBox.ConvertToInt() * OptionPrices.BkMrk).ToString();
            vpprcTextBox.Text = (vpaqtyTextBox.ConvertToInt() * (sfRadioButton.Checked ? OptionPrices.VpSF : OptionPrices.VpLF)).ToString();
            vpbprcTextBox.Text = (vpbqtyTextBox.ConvertToInt() * OptionPrices.VpLF).ToString();//vinyle pocket B only available if LF
            idpouchprcTextBox.Text = (idpouchqtyTextBox.ConvertToInt() * OptionPrices.IdPouch).ToString();
            stdttitpgprcTextBox.Text = (stttitpgqtyTextBox.ConvertToInt() * (lfRadioButton.Checked ? OptionPrices.TitlePgLF : OptionPrices.TitlePgSF)).ToString();
            duraglzprcTextBox.Text = (duraglzqtyTextBox.ConvertToInt() * (lfRadioButton.Checked ? OptionPrices.DuraGlazeLF : OptionPrices.DuraGlazeSF)).ToString();
            wallchprcTextBox.Text = (wallchqtyTextBox.ConvertToInt() * OptionPrices.WallChart).ToString();
            typesetprcTextBox.Text = (typesetqtyTextBox.ConvertToInt() * OptionPrices.TypeSet).ToString();
            //TotalOption __________________________________________________________________
            lblTotalOptions.Text = (hallppriceTextBox.ConvertToDecimal() + bmarkprcTextBox.ConvertToDecimal() + idpouchprcTextBox.ConvertToDecimal()
             + stdttitpgprcTextBox.ConvertToDecimal() + duraglzprcTextBox.ConvertToDecimal() + wallchprcTextBox.ConvertToDecimal() + typesetprcTextBox.ConvertToDecimal()
             + lblSpecialCoverPrice.ConvertToDecimal() + vpprcTextBox.ConvertToDecimal() + vpbprcTextBox.ConvertToDecimal()).ToString();
            //________________________________________________________________


            //Before Discounts Total__________________________________________________________________________
            lblsbtot.Text = (lblTotalBasePrice.ConvertToDecimal() + lblCoverPricetotal.ConvertToDecimal() + lblTotalOptions.ConvertToDecimal() + txtmisc.ConvertToDecimal()).ToString();
            //Sbtot_____________________________________________________
            decimal vSbtot = lblsbtot.ConvertToDecimal();
            //After Discount Total__________________________________________________________________________
            afterdisctotLabel2.Text = (vSbtot + erldiscamtTextBox.ConvertToDecimal() + desc1amtTextBox1.ConvertToDecimal() + descamtTextBox.ConvertToDecimal()
            + desc4amtTextBox.ConvertToDecimal() + desc3amtTextBox.ConvertToDecimal()).ToString();
            //___________________________________________________________________
            decimal vTotal = afterdisctotLabel2.ConvertToDecimal() + txtShipping.ConvertToDecimal() + txtAdditionChrg.ConvertToDecimal();

            lblFinalPrice.Text = vTotal.ToString();
            if (!doNotChargeTaxCheckBox.Checked)
            {
                // Control values are set in function
                GetTax(vTotal);
            }
            else
            {
                lblTaxRate.Text = "0.00";
                lblTax.Text = "0.00";
            }

            // lblFinalTotal.Text = (lblFinalPrice.ConvertToDecimal() + lblTax.ConvertToDecimal()).ToString();



        }
        private void CalculateBase()
        {
            if (!ValidateCalcData())
            {

                return;
            }
            if (Pricing == null)
            {
                if (!GetBookPricing())
                {
                    return;
                }
            }
            if (chkGeneric.Checked)
            {
                if (CalculateGeneric())
                { return; }

            }
            if (chkJostens.Checked)
            {
                if (CalculateJostenBase())
                {
                    return;
                }

            }
            //calculate regular
            decimal vBasePrice = 0;
            decimal vPriceOveride = 0;
            decimal vTeacherBasePrice = 0;
            int mPages;
            int vTotalQty = 0;
            int pageMultiplier = 0;
            decimal xtraPagePrice = 0;
            var vMiscAmt = txtmisc.ConvertToDecimal();
            var vQtyTeacher = txtQtyTeacher.ConvertToInt();
            var vQtyStudent = txtQtyStudent.ConvertToInt();
            vTotalQty = vQtyStudent + vQtyTeacher;
            var vPages = txtNoPages.ConvertToInt();
            var vPriceOverride = txtPriceOverRide.ConvertToDecimal();
            lblQtyTotal.Text = vTotalQty.ToString();

            if (contryearTextBox.Text == "")
            {
                return;
            }


            if (lfRadioButton.Checked)
            {
                if (vPriceOveride > 0)
                {
                    vBasePrice = vPriceOveride;
                    lblBasePrice.Text = vBasePrice.ToString();
                    if (string.IsNullOrEmpty(txtQtyTeacher.Text))
                    {
                        vTeacherBasePrice = 0;
                        lblTeachBasePrice.Text = "0.00";
                    }
                    else
                    {
                        lblTeachBasePrice.Text = vBasePrice.ToString();
                        //always same for Large Font
                        vTeacherBasePrice = vBasePrice;
                    }
                    lblTotalBasePrice.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher)).ToString();
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
                if (string.IsNullOrEmpty(txtQtyTeacher.Text) || txtQtyTeacher.Text == "0")
                {
                    lblTeachBasePrice.Text = "0.00";
                    vTeacherBasePrice = 0;
                }
                else
                {
                    lblTeachBasePrice.Text = vBasePrice.ToString();
                    vTeacherBasePrice = vBasePrice;
                }
                lblBasePrice.Text = vBasePrice.ToString();
                lblsbtot.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher) + vMiscAmt).ToString();
                lblTotalBasePrice.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher)).ToString();
            }
            //////////////----------------------------------------------------------------
            if (sfRadioButton.Checked)
            {
                if (vPriceOveride > 0)
                {
                    vBasePrice = vPriceOveride;
                    lblBasePrice.Text = vBasePrice.ToString();
                    if (string.IsNullOrEmpty(txtQtyTeacher.Text))
                    {
                        vTeacherBasePrice = 0;
                        lblTeachBasePrice.Text = "0.00";
                    }
                    else
                    {
                        lblTeachBasePrice.Text = vBasePrice.ToString();
                        vTeacherBasePrice = vBasePrice;
                    }
                    lblTotalBasePrice.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher)).ToString();
                    return;
                }
                if (vPages == 0) { mPages = 8; } else { mPages = vPages; }//test
                var qtyField = GetCopies(vTotalQty);
                pageMultiplier = GetXtraPages(mPages, "SF", CurPriceYr);
                xtraPagePrice = pageMultiplier * Pricing.StandardPageCost;
                vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>(qtyField, Pricing);
                if (vPages == 0) { vBasePrice += Pricing.ZeroPageCost; }
                if (vPages == 8) { vBasePrice += Pricing.EightPageCost; }
                vBasePrice += xtraPagePrice;
                if (string.IsNullOrEmpty(txtQtyTeacher.Text) || txtQtyTeacher.Text == "0")
                {
                    lblTeachBasePrice.Text = "0.00";
                    vTeacherBasePrice = 0;
                }
                else
                {
                    lblTeachBasePrice.Text = vBasePrice.ToString();
                    vTeacherBasePrice = vBasePrice;
                }

                lblBasePrice.Text = vBasePrice.ToString();

            }
            lblTotalBasePrice.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher)).ToString();
            lblsbtot.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher) + vMiscAmt).ToString();
            CalculateOptions();
        }
        private bool CalculateJostenBase()
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
            lblQtyTotal.Text = vTotalQty.ToString("0.00");
            if (contryearTextBox.Text == "")
            {
                return false;
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
                return true;
            }
            if (vPages > 76)

            {
                MbcMessageBox.Information("Pages are over 76, Jostens pricing not available. Enter a price override.");
                return false;

            }
            if (string.IsNullOrEmpty(txtBYear.Text))
            {
                MbcMessageBox.Information("Enter a base price year");
                return false;
            }
            var vJostenPrice = GetJostensPricing(txtBYear.Text, sfRadioButton.Checked ? "SF" : "LF", vPages);
            if (vTotalQty < 600)
            {
                vJostenPrice += .25m;
            }
            lblBasePrice.Text = vJostenPrice.ToString("0.00");
            if (vQtyTeacher > 0)
            {
                lblTeachBasePrice.Text = vJostenPrice.ToString("0.00");//same as student
            }
            lblTotalBasePrice.Text = ((vJostenPrice * vQtyStudent) + (vJostenPrice * vQtyTeacher)).ToString("0.00");
            CalculateOptions();
            return true;
        }
        private bool CalculateGeneric()
        {
            CalculateOptions();
            return false;//temporary then make true;
        }
        private decimal GetJostensPricing(string vYear, string vType, int pageQty)
        {
            string fieldName = vType + pageQty.ToString();
            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"Select * From JostensPricing where Yr=@Yr");
            sqlQuery.AddParameter("@Yr", vYear);
            var result = sqlQuery.Select<JostenPricing>();
            var vPricing = (JostenPricing)result.Data;
            if (result.IsError)
            { MbcMessageBox.Error(result.Errors[0].ErrorMessage); return 0; }
            var vJostensBasePrice = (decimal)ObjectFieldValue.Get<JostenPricing>(fieldName, vPricing);
            return vJostensBasePrice;
        }
        private int GetXtraPages(int Qty, string Facing, string Year)
        {
            int retval = 0;
            if (Facing == "LF" && Qty == 4)
            {
                retval = 0;
            }
            else if (Facing == "LF" && Qty >= 8)
            {
                var vLeftOver = Qty % 2;//make sure pages are even
                if (vLeftOver == 0)
                {
                    retval = (Qty - 8);
                }
            }

            //SF
            if (Facing == "SF" && Qty == 8)
            {
                retval = 0;
            }
            else if (Facing == "SF" && Qty >= 16)
            {
                var vLeftOver = Qty % 2;
                if (vLeftOver == 0)
                {
                    retval = (Qty - 16);
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
            }
            else if (requestedCopies >= 200 && requestedCopies <= 249)
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
            else if (requestedCopies >= 400 && requestedCopies <= 599)
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
            else if (requestedCopies >= 2000)
            {
                retval = "Q2000";
            }

            return retval;
        }
        private bool GetBookPricing()
        {

            if (!ValidateBookYear())
            {
                lblTotalBasePrice.Text = "0.00";
                return false;
            }
            var sqlQuery = new SQLCustomClient();
            sqlQuery.ClearParameters();
            if (String.IsNullOrEmpty(txtBYear.Text))
            {
                errorProvider1.SetError(txtBYear, "");

                errorProvider1.SetError(txtBYear, "Please enter a  base price year.");
                lblTotalBasePrice.Text = "0.00";
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
                MbcMessageBox.Error("Failed to get meridian base pricing" + pricingResult.Errors[0].DeveloperMessage);
                lblTotalBasePrice.Text = "0.00";
                return false;
            }
            if (pricingResult.Data == null)
            {
                MbcMessageBox.Information("Meridian base pricing for the given year and type was not found.");
                lblTotalBasePrice.Text = "0.00";
                return false; ;
            }
            Pricing = (MeridianPrice)pricingResult.Data;
            return true;
        }
        private void SetCoverColor()
        {
            if (fourclrCheckBox.Checked)
            {
                threeclrCheckBox.Checked = false;
                twoclrCheckBox.Checked = false;
                oneclrCheckBox.Checked = false;

            }
            else if (threeclrCheckBox.Checked)
            {
                fourclrCheckBox.Checked = false;
                twoclrCheckBox.Checked = false;
                oneclrCheckBox.Checked = false;
            }
            else if (twoclrCheckBox.Checked)
            {
                threeclrCheckBox.Checked = false;
                fourclrCheckBox.Checked = false;
                oneclrCheckBox.Checked = false;

            }
            else if (oneclrCheckBox.Checked)
            {
                threeclrCheckBox.Checked = false;
                twoclrCheckBox.Checked = false;
                fourclrCheckBox.Checked = false;
            }
            else
            {
                oneclrCheckBox.Checked = true;
                threeclrCheckBox.Checked = false;
                twoclrCheckBox.Checked = false;
                fourclrCheckBox.Checked = false;
            }
            CoverCalc();
            CalculateBase();
            CalculateOptions();
        }
        private void CoverCalc()
        {
            if (OptionPrices == null)
            {
                GetOptionPricing();
            }

            if (fourclrCheckBox.Checked)
            {


                if (chkJostens.Checked)
                {
                    lblCoverPricetotal.Text = OptionPrices.JostensFourClr.ToString("0.00");
                }
                else
                {
                    lblCoverPricetotal.Text = OptionPrices.FourClr.ToString("0.00");
                }
            }
            else if (threeclrCheckBox.Checked)
            {

                if (chkJostens.Checked)
                {
                    lblCoverPricetotal.Text = OptionPrices.JostensFourClr.ToString("0.00");
                }
                else
                {
                    lblCoverPricetotal.Text = OptionPrices.ThreeClr.ToString("0.00");
                }
            }
            else if (twoclrCheckBox.Checked)
            {

                lblCoverPricetotal.Text = OptionPrices.TwoClr.ToString("0.00");
            }
            else
            {

                lblCoverPricetotal.Text = OptionPrices.OneClr.ToString("0.00");
            }
            CalculateOptions();
        }
        private void GetOptionPricing()
        {
            if (string.IsNullOrEmpty(contryearTextBox.Text))
            {
                return;
            }
            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"Select * From MeridianOptionPrices Where Yr=@Yr");
            sqlQuery.AddParameter("@Yr", contryearTextBox.Text);
            var result = sqlQuery.Select<MeridianOptionPricing>();
            if (result.IsError)
            {
                ExceptionlessClient.Default.CreateLog("MeridianOption Pricing")
                    .AddObject(result)
                    .MarkAsCritical()
                    .Submit();
                MbcMessageBox.Error("Error retrieving Meridian Option Prices:" + result.Errors[0].ErrorMessage);
                return;
            }
            OptionPrices = (MeridianOptionPricing)result.Data;
        }
        private bool ValidateCalcData()
        {
            bool retval = true;
            int vNum;
            errorProvider1.SetError(txtQtyTeacher, "");

            if (!int.TryParse(txtQtyTeacher.Text, out vNum))
            {
                errorProvider1.SetError(txtQtyTeacher, "Enter a  valid number.");
                retval = false;
            }


            errorProvider1.SetError(txtQtyStudent, "");

            if (!int.TryParse(txtQtyStudent.Text, out vNum))
            {
                errorProvider1.SetError(txtQtyStudent, "Enter a  valid number.");

                retval = false;
            }

            int vPages;
            errorProvider1.SetError(txtNoPages, "");

            if (!int.TryParse(txtNoPages.Text, out vPages))
            {
                errorProvider1.SetError(txtNoPages, "Enter a  valid number.");
                retval = false;

            }
            errorProvider1.SetError(txtPriceOverRide, "");
            if (txtPriceOverRide.Text != "")
            {
                decimal vPriceOverride;
                errorProvider1.SetError(txtPriceOverRide, "");

                if (!decimal.TryParse(txtPriceOverRide.Text, out vPriceOverride))
                {
                    errorProvider1.SetError(txtPriceOverRide, "Enter a  valid decimal number.");
                    retval = false;

                }
            }
            retval = ValidateBookYear();

            return retval;
        }
        private bool ValidateBookYear()
        {
            bool retval = true;
            int vYear;
            errorProvider1.SetError(txtBYear, "");
            if (txtBYear.TextLength < 2)
            {
                errorProvider1.SetError(txtBYear, "Enter a  valid 2 digit pricing year.");

                retval = false;
            }
            if (!int.TryParse(txtBYear.Text, out vYear))
            {
                errorProvider1.SetError(txtBYear, "Enter a  valid 2 digit pricing year.");
                retval = false; ;

            }


            return retval;
        }
        private decimal GetTax(decimal vAmount)
        {
            try
            {
                var vschname = ((DataRowView)mbidsBindingSource.Current).Row["schname"].ToString().Trim();
                var vaddress = ((DataRowView)mbidsBindingSource.Current).Row["InvAddr"].ToString().Trim();
                var vaddress2 = ((DataRowView)mbidsBindingSource.Current).Row["InvAddr2"].ToString().Trim();
                var vcity = ((DataRowView)mbidsBindingSource.Current).Row["InvCity"].ToString().Trim();
                var vState = ((DataRowView)mbidsBindingSource.Current).Row["InvState"].ToString().Trim();
                var vzipCode = ((DataRowView)mbidsBindingSource.Current).Row["InvZip"].ToString().Trim();
                var vTaxingInfo = new AvaSalesTaxingInfo()
                {
                    CompanyName = vschname,
                    Address = vaddress,
                    Address2 = vaddress2,
                    City = vcity,
                    State = vState,
                    ZipCode = vzipCode,
                    TaxableAmount = vAmount
                };

                var totalTaxCharged = TaxService.CaclulateTax(vTaxingInfo);
                lblTaxRate.Text = (totalTaxCharged / vAmount).ToString("0.0000");
                lblTax.Text = totalTaxCharged.ToString("0.00");

                return totalTaxCharged;
            }
            catch
            {
                return 0;
            }
        }
        #endregion
        private void qtedateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            qtedateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void orderDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            orderDateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

      
    }
    }
