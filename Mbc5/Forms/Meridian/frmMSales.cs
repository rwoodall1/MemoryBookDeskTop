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
using BaseClass.Core;
using Mbc5.Classes;
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
        #region Properties
        private UserPrincipal ApplicationUser { get; set; }
        protected frmMain frmMain { get; set; }
        protected string CurPriceYr { get; set; }
        protected MeridianPrice Pricing { get; set; }
        protected MeridianOptionPricing OptionPrices { get; set; }
        #endregion
        
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
        private void CalculateOptions()
        {
            if (OptionPrices == null)
            {
                GetOptionPricing();
            }

            hallppriceTextBox.Text = (hallpqtyTextBox.ConvertToInt() * (lfRadioButton.Checked ? OptionPrices.HallPassSF : OptionPrices.HallPassLF)).ToString("0.00");
            bmarkprcTextBox.Text= (bmarkqtyTextBox.ConvertToInt() *OptionPrices.BkMrk).ToString("0.00");
            idpouchprcTextBox.Text= (idpouchqtyTextBox.ConvertToInt() *OptionPrices.IdPouch).ToString("0.00");
            stdttitpgprcTextBox.Text = (stttitpgqtyTextBox.ConvertToInt() * (lfRadioButton.Checked ? OptionPrices.TitlePgLF : OptionPrices.TitlePgSF)).ToString("0.00");
            duraglzprcTextBox.Text= (duraglzqtyTextBox.ConvertToInt() * (lfRadioButton.Checked ? OptionPrices.DuraGlazeLF : OptionPrices.DuraGlaseSF)).ToString("0.00");
            wallchprcTextBox.Text = (wallchqtyTextBox.ConvertToInt() * OptionPrices.WallChart).ToString("0.00");
            typesetprcTextBox.Text = (typesetqtyTextBox.ConvertToInt() * OptionPrices.TypeSet).ToString("0.00");





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
                if (string.IsNullOrEmpty(txtQtyTeacher.Text) || txtQtyTeacher.Text == "0")
                {
                    lblTeachBasePrice.Text = "0.00";
                    vTeacherBasePrice = 0;
                }
                else
                {
                    lblTeachBasePrice.Text = vBasePrice.ToString("0.00");
                    vTeacherBasePrice = vBasePrice;
                }
                lblBasePrice.Text = vBasePrice.ToString("0.00");
                lblsbtot.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher) + vMiscAmt).ToString("0.00");
                lblTotalBasePrice.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher)).ToString("0.00");
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
                if (vPages == 0) { mPages = 8; } else { mPages = vPages; }//test
                var qtyField = GetCopies(vTotalQty);
                pageMultiplier = GetXtraPages(mPages, "SF", CurPriceYr);
                xtraPagePrice = pageMultiplier * Pricing.StandardPageCost;
                vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>(qtyField, Pricing);
                if (vPages == 0) { vBasePrice += Pricing.ZeroPageCost; }
                if (vPages == 8) { vBasePrice += Pricing.EightPageCost; }
                vBasePrice += xtraPagePrice;
                if (string.IsNullOrEmpty(txtQtyTeacher.Text)|| txtQtyTeacher.Text=="0")
                {
                    lblTeachBasePrice.Text = "0.00";
                    vTeacherBasePrice = 0;
                }
                else
                {
                    lblTeachBasePrice.Text = vBasePrice.ToString("0.00");
                    vTeacherBasePrice = vBasePrice;
                }

                lblBasePrice.Text = vBasePrice.ToString("0.00");
              
            }
            lblTotalBasePrice.Text= ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher)).ToString("0.00");
            lblsbtot.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher) + vMiscAmt).ToString("0.00");
            CalculateOptions();
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
           lblQtyTotal.Text = vTotalQty.ToString("0.00");
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
            CalculateOptions();

        }
        private void CalculateGeneric()
        {
            CalculateOptions();
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
        private bool GetBookPricing()
        {
           
            if (!ValidateBookYear()){
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
                lblCoverPricetotal.Text = OptionPrices.ThreeClr.ToString("0.00");
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
            sqlQuery.CommandText(@"Select * From MeridianPricing Where Yr=@Yr");
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
        
            var vschname = ((DataRowView)mquotesBindingSource.Current).Row["schname"].ToString().Trim();
            var vaddress = ((DataRowView)mquotesBindingSource.Current).Row["InvAddr"].ToString().Trim();
            var vaddress2 = ((DataRowView)mquotesBindingSource.Current).Row["InvAddr2"].ToString().Trim();
            var vcity = ((DataRowView)mquotesBindingSource.Current).Row["InvCity"].ToString().Trim();
            var vState = ((DataRowView)mquotesBindingSource.Current).Row["InvState"].ToString().Trim();
            var vzipCode = ((DataRowView)mquotesBindingSource.Current).Row["InvZip"].ToString().Trim();
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
        private void prodcodeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!GetBookPricing())
            {
                   return;
            }
            var dr = (DataRowView)mquotesBindingSource.Current;
            if (prodcodeComboBox.SelectedValue.ToString() == "HSP" || prodcodeComboBox.SelectedValue.ToString() == "ADVLOG" || prodcodeComboBox.SelectedValue.ToString() == "MAG")
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
                    lblSchtype.Text = "HS";
                    break;
                case "MSP":
                    lblSchtype.Text = "MS";
                    break;
                case "MAG":
                    lblSchtype.Text = "MAGNET";
                    break;
                case "ADVLOG":
                    lblSchtype.Text = "ADVENTURE LOG";
                    break;
                case "ELSP":
                    lblSchtype.Text = "ELEM";
                    break;
                case "PRISP":
                    lblSchtype.Text = "PRIM";
                    break;
            }
            
            CalculateBase();
            CalculateOptions();
        }
        private void contryearTextBox_Validating(object sender, CancelEventArgs e)
        {
            int vYear;
            errorProvider1.SetError(contryearTextBox, "");
            if (contryearTextBox.TextLength < 2)
            {
                errorProvider1.SetError(contryearTextBox, "Enter a  valid 2 digit year.");
                e.Cancel = true;
            }
            if (!int.TryParse(contryearTextBox.Text, out vYear))
            {
                errorProvider1.SetError(contryearTextBox, "Enter a  valid 2 digit year.");
                e.Cancel = true;
            }

           
        }
        private void txtBYear_Leave(object sender, EventArgs e)
        {
            if (GetBookPricing())
            {
                CalculateBase();
                CalculateOptions();
            }              
                
            
        }
        private void contryearTextBox_Leave(object sender, EventArgs e)
        {
            this.Validate();
        }
        private void wghtTextBox_Leave(object sender, EventArgs e)
        {
            Validate();
        }
        private void wghtTextBox_Validating(object sender, CancelEventArgs e)
        {
            int vWeight;
            errorProvider1.SetError(wghtTextBox, "");
            if (wghtTextBox.Text != "")
            {
                if (!int.TryParse(wghtTextBox.Text, out vWeight))
                {
                    errorProvider1.SetError(wghtTextBox, "Enter a  valid weight.");
                    e.Cancel = true;
                }
            }
        }
        private void txtNoPages_Leave(object sender, EventArgs e)
        {
            CalculateBase();
            CalculateOptions();
        }
        private void txtPriceOverRide_Leave(object sender, EventArgs e)
        {
            CalculateBase();
            CalculateOptions();
        }
        private void chkGeneric_Click(object sender, EventArgs e)
        {
            CalculateBase();
            CalculateOptions();
        }
        private void chkJostens_Click(object sender, EventArgs e)
        {
            CalculateBase();
            CalculateOptions();
        }     
        private void fourclrCheckBox_Click(object sender, EventArgs e)
        {
            CoverCalc();
            CalculateOptions();
        }
        private void threeclrCheckBox_Click(object sender, EventArgs e)
        {
            CoverCalc();
            CalculateOptions();
        }
        private void twoclrCheckBox_Click(object sender, EventArgs e)
        {
            CoverCalc();
            CalculateOptions();
        }
        private void oneclrCheckBox_Click(object sender, EventArgs e)
        {
            CoverCalc();
            CalculateOptions();
        }

        private void dp1TextBox_Leave(object sender, EventArgs e)
        {
            dp1TextBox.Text = dp1TextBox.ConvertToDecimal().ToString("0.00");
            CalculateOptions();
        }

        private void erldiscamtTextBox_Leave(object sender, EventArgs e)
        {
            erldiscamtTextBox.Text = erldiscamtTextBox.ConvertToDecimal().ToString("0.00");
            CalculateOptions();
        }

        private void desc1amtTextBox1_Leave(object sender, EventArgs e)
        {
            desc1amtTextBox1.Text= desc1amtTextBox1.ConvertToDecimal().ToString("0.00");
            CalculateOptions();
        }

        private void descamtTextBox_Leave(object sender, EventArgs e)
        {
            descamtTextBox.Text= descamtTextBox.ConvertToDecimal().ToString("0.00");
            CalculateOptions();
        }

        private void desc4amtTextBox_Leave(object sender, EventArgs e)
        {
            desc4amtTextBox.Text = desc4amtTextBox.ConvertToDecimal().ToString("0.00");
            CalculateOptions();
        }

        private void desc3amtTextBox_Leave(object sender, EventArgs e)
        {
            desc3amtTextBox.Text = desc3amtTextBox.ConvertToDecimal().ToString("0.00");
            CalculateOptions();
        }

        private void shpphndlTextBox_Leave(object sender, EventArgs e)
        {
            shpphndlTextBox.Text = shpphndlTextBox.ConvertToDecimal().ToString("0.00");
            CalculateOptions();
        }

        private void adcamtTextBox_Leave(object sender, EventArgs e)
        {
            adcamtTextBox.Text = adcamtTextBox.ConvertToDecimal().ToString("0.00");
            CalculateOptions();
        }

       

        private void disc4CheckBox_Click(object sender, EventArgs e)
        {            
                CalculateOptions();
        }

        private void disc3CheckBox_Click(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void doNotChargeTaxCheckBox_Click(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void hallpqtyTextBox_Leave(object sender, EventArgs e)
        {
           
            

        }

        private void bmarkqtyTextBox_Leave(object sender, EventArgs e)
        {
           
        }

        private void vpaqtyTextBox_Leave(object sender, EventArgs e)
        {
            
          
        }

        private void vpbqtyTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void idpouchqtyTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void stttitpgqtyTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void duraglzqtyTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void wallchqtyTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void typesetqtyTextBox_Leave(object sender, EventArgs e)
        {
          
        }


        //nothing below here
    }
    }
