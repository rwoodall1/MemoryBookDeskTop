﻿using System;
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
using BaseClass.Core;
using Microsoft.Reporting.WinForms;
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
           lblModifiedby.Text = frmMain.ApplicationUser.id;

            this.reportViewer1.RefreshReport();
        }
        #region Methods
        #region CalcMethods
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
                if (!GetOptionPricing())
                {
                    return;
                }
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

            hallppriceTextBox.Text = (hallpqtyTextBox.ConvertToInt() * (lfRadioButton.Checked ? OptionPrices.HallPassLF : OptionPrices.HallPassSF)).ToString();
            bmarkprcTextBox.Text = (bmarkqtyTextBox.ConvertToInt() * OptionPrices.BkMrk).ToString();
            vpprcTextBox.Text = (vpaqtyTextBox.ConvertToInt() * (sfRadioButton.Checked ? OptionPrices.VpSF : OptionPrices.VpLF)).ToString();
            vpbprcTextBox.Text = (vpbqtyTextBox.ConvertToInt() * OptionPrices.VpLF).ToString();//vinyle pocket B only available if LF
            idpouchprcTextBox.Text = (idpouchqtyTextBox.ConvertToInt() * OptionPrices.IdPouch).ToString();
            stdttitpgprcTextBox.Text = (stttitpgqtyTextBox.ConvertToInt() * (lfRadioButton.Checked ? OptionPrices.TitlePgLF : OptionPrices.TitlePgSF)).ToString();
            duraglzprcTextBox.Text = (duraglzqtyTextBox.ConvertToInt() * (lfRadioButton.Checked ? OptionPrices.DuraGlazeLF : OptionPrices.DuraGlazeSF)).ToString();
            wallchprcTextBox.Text = (wallchqtyTextBox.ConvertToInt() * OptionPrices.WallChart).ToString();
            characterResourceAmtTextBox.Text = (characterResourceQtyTextBox.ConvertToInt() * (lfRadioButton.Checked ? OptionPrices.CharacterResourceLF : OptionPrices.CharacterResourceSF)).ToString();
            //TotalOption __________________________________________________________________
            lblTotalOptions.Text = (hallppriceTextBox.ConvertToDecimal() + bmarkprcTextBox.ConvertToDecimal() + idpouchprcTextBox.ConvertToDecimal()
             + stdttitpgprcTextBox.ConvertToDecimal() + duraglzprcTextBox.ConvertToDecimal() + wallchprcTextBox.ConvertToDecimal() + characterResourceAmtTextBox.ConvertToDecimal()
             + lblSpecialCoverPrice.ConvertToDecimal() + vpprcTextBox.ConvertToDecimal() + vpbprcTextBox.ConvertToDecimal()).ToString();
            //________________________________________________________________


            //Before Discounts Total__________________________________________________________________________
            lblsbtot.Text = (lblTotalBasePrice.ConvertToDecimal() + lblCoverPricetotal.ConvertToDecimal() + lblTotalOptions.ConvertToDecimal() + txtmisc.ConvertToDecimal()).ToString();
            //Sbtot_____________________________________________________
            decimal vSbtot = lblsbtot.ConvertToDecimal();
            //After Discount Total__________________________________________________________________________
            erldiscamtTextBox.Text = "-" + (dp1TextBox.ConvertToDecimal() * vSbtot).ToString("0.00");
            afterdisctotLabel2.Text = (vSbtot + erldiscamtTextBox.ConvertToDecimal() + desc1amtTextBox1.ConvertToDecimal() + descamtTextBox.ConvertToDecimal()
            + desc4amtTextBox.ConvertToDecimal() + desc3amtTextBox.ConvertToDecimal()).ToString();
            //___________________________________________________________________
            decimal vTotal = afterdisctotLabel2.ConvertToDecimal();

            lblFinalPrice.Text =( vTotal/ lblQtyTotal.ConvertToInt()).ToString();
            if (!doNotChargeTaxCheckBox.Checked)
            {
                // Control tax values are set in function
                GetTax(vTotal);
            }
            else
            {
                lblTaxRate.Text = "0.00";
                lblTax.Text = "0.00";
            }
           
          
             lblFinalTotal.Text = (afterdisctotLabel2.ConvertToDecimal() + txtShipping.ConvertToDecimal()+ lblTax.ConvertToDecimal()).ToString();



        }
        private void CalculateBase()
        {
            if (prodcodeComboBox.SelectedValue == null)
            {
                //form closing dropdown has no values return
                return;
            }
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
            if (prodcodeComboBox.SelectedValue.ToString()=="ADVLOG")
            {
                lblBasePrice.Text = (vBasePrice+.50m).ToString("0.00");
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
            decimal vBasePrice = 0;
            decimal vPriceOveride = 0;
            decimal vTeacherBasePrice = 0;
            int vQtyTeacher = 0;
            int vQtyStudent = 0;
            int vTotalQty = 0;
            int vPages = 0;

            decimal.TryParse(txtPriceOverRide.Text, out vPriceOveride);
            int.TryParse(txtQtyTeacher.Text, out vQtyTeacher);
            int.TryParse(txtQtyStudent.Text, out vQtyStudent);
            vTotalQty = vQtyStudent + vQtyTeacher;
            int.TryParse(txtNoPages.Text, out vPages);

            lblQtyTotal.Text = vTotalQty.ToString();
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
                CalculateOptions();
                return true;
            }
            if (lfRadioButton.Checked)
            {
              
                if (prodcodeComboBox.SelectedValue.ToString() == "ADVLOG")
                {
                    if (string.IsNullOrEmpty(txtQtyTeacher.Text))
                    {
                        vTeacherBasePrice = 0;
                        lblTeachBasePrice.Text = "0.00";
                    }
                    else
                    {
                        vTeacherBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("Generic", Pricing);
                        vTeacherBasePrice += .50m;
                        lblTeachBasePrice.Text = vTeacherBasePrice.ToString();
                    }
                    if (vTotalQty > 0 && vTotalQty <= 249)
                    {
                        vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("Generic", Pricing);
                        vBasePrice += .50m;
                        lblBasePrice.Text = vBasePrice.ToString();

                    }
                    else if (vTotalQty >= 250 && vTotalQty <= 599)
                    {
                        vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("GenericCM", Pricing);
                        vBasePrice += .50m;
                        lblBasePrice.Text = vBasePrice.ToString();

                    }
                    else if (vTotalQty >= 600)
                    {
                        vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("GenericCL", Pricing);
                        vBasePrice += .50m;
                        lblBasePrice.Text = vBasePrice.ToString();

                    }


                }
                else
                {
                    if (string.IsNullOrEmpty(txtQtyTeacher.Text))
                    {
                        vTeacherBasePrice = 0;
                        lblTeachBasePrice.Text = "0.00";
                    }
                    else
                    {
                        vTeacherBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("Generic", Pricing);
                        lblTeachBasePrice.Text = vTeacherBasePrice.ToString();
                    }
                    if (vTotalQty > 0 && vTotalQty <= 249)
                    {
                        vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("Generic", Pricing);
                        lblBasePrice.Text = vBasePrice.ToString();

                    }
                    else if (vTotalQty >= 250 && vTotalQty <= 599)
                    {
                        vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("GenericM", Pricing);
                        lblBasePrice.Text = vBasePrice.ToString();

                    }
                    else if (vTotalQty >= 600)
                    {
                        vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("GenericCL", Pricing);
                        lblBasePrice.Text = vBasePrice.ToString();

                    }
                }
            }
            else if (sfRadioButton.Checked)
            {
                if (prodcodeComboBox.SelectedValue.ToString() == "ADVLOG")
                {
                    if (string.IsNullOrEmpty(txtQtyTeacher.Text))
                    {
                        vTeacherBasePrice = 0;
                        lblTeachBasePrice.Text = "0.00";
                    }
                    else
                    {
                        vTeacherBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("Generic", Pricing);
                        vTeacherBasePrice += .50m;
                        lblTeachBasePrice.Text = vTeacherBasePrice.ToString();
                    }
                    if (vTotalQty > 0 && vTotalQty <= 599)
                    {
                        vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("Generic", Pricing);
                        vBasePrice += .50m;
                        lblBasePrice.Text = vBasePrice.ToString();

                    }

                    else if (vTotalQty >= 600)
                    {
                        vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("GenericCL", Pricing);
                        vBasePrice += .50m;
                        lblBasePrice.Text = vBasePrice.ToString();

                    }


                }
                else
                {
                    if (string.IsNullOrEmpty(txtQtyTeacher.Text))
                    {
                        vTeacherBasePrice = 0;
                        lblTeachBasePrice.Text = "0.00";
                    }
                    else
                    {
                        vTeacherBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("Generic", Pricing);
                        lblTeachBasePrice.Text = vTeacherBasePrice.ToString();
                    }
                    if (vTotalQty > 0 && vTotalQty <= 599)
                    {
                        vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("Generic", Pricing);
                        lblBasePrice.Text = vBasePrice.ToString();

                    }

                    else if (vTotalQty >= 600)
                    {
                        vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("GenericCL", Pricing);
                        lblBasePrice.Text = vBasePrice.ToString();

                    }
                }
            }
            lblTotalBasePrice.Text = ((vBasePrice * vQtyStudent) + (vTeacherBasePrice * vQtyTeacher)).ToString("0.00");
            CalculateOptions();
            return true;
        }
        #endregion
        public override void Save(bool ShowSpinner)
        {
            //so call can be made from menu
            if (ShowSpinner)
            {
                basePanel.Visible = true;
                // backgroundWorker1.RunWorkerAsync("Save");
            }
            else
            {
                var result = SaveBid();
                if (result.IsError)
                {
                    MbcMessageBox.Error(result.Errors[0].ErrorMessage);
                }

            }


        }
        private ApiProcessingResult<bool> SaveBid()
        {
            var processingResult = new ApiProcessingResult<bool>();
            CalculateBase();
            CalculateOptions();
            if (!ValidBid())
            {
                processingResult.IsError = true;
                return processingResult;
            }

            try
            {
                if (Validate())
                {
                    mbidsBindingSource.EndEdit();
                    var a = mbidsTableAdapter.Update(dsMBids.mbids);
            
                    Fill();
                    processingResult.Data = true;
                    return processingResult;

                }
                processingResult.Data = false;
                return processingResult;
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .AddObject(ex)
                    .MarkAsCritical()
                    .Submit();
                processingResult.Data = false;
                processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
                MbcMessageBox.Error(ex.Message);
                //var a = dsMBids.Tables["mbids"].GetErrors();
                return processingResult;
            }
        }
        private bool ValidBid()
        {
            bool retval = true;

            retval = ValidateCalcData();
            if (!retval) { return retval; }

            retval = this.ValidateChildren();
            if (!retval) { return retval; }
            retval = this.Validate();
            return retval;
        }
       public override void Fill()
        {
            if (Schcode != null)
            {
                try
                {
                    this.meridianProductsTableAdapter.Fill(this.lookUp.MeridianProducts);
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
                if (mbidsBindingSource.Count > 0)
                {
                    this.Schname = ((DataRowView)mbidsBindingSource.Current).Row["schname"].ToString().Trim();
                    this.SchoolZipCode = ((DataRowView)this.mbidsBindingSource.Current).Row["schzip"].ToString().Trim().Substring(0, 5);
                }

            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message, "");
            }
        }
        private void SetConnectionString()
        {
            meridianProductsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
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
                MbcMessageBox.Information("Meridian base pricing for the given base price year and type was not found.");
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
        private bool GetOptionPricing()
        {
            if (string.IsNullOrEmpty(contryearTextBox.Text))
            {
                return false;
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
                return false;
            }
            if (result.Data == null)
            {
                MbcMessageBox.Error("There were no option prices found for contract year:"+ contryearTextBox.Text);
                
                return false;
            }
            OptionPrices = (MeridianOptionPricing)result.Data;
            return true;
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
                txtBYear.Focus();
                retval = false;
            }
            if (!int.TryParse(txtBYear.Text, out vYear))
            {
                errorProvider1.SetError(txtBYear, "Enter a  valid 2 digit pricing year.");
                txtBYear.Focus();
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
        

       

        private void txtBYear_Leave(object sender, EventArgs e)
        {
            if (!GetBookPricing())
            {
                return;
            }
            CalculateBase();
            CalculateOptions();
        }

        private void txtQtyStudent_Leave(object sender, EventArgs e)
        {
            int vQtyStudent = txtQtyStudent.ConvertToInt();
            int vQtyTeacher = txtQtyTeacher.ConvertToInt();
            int vRemainder = (vQtyStudent + vQtyTeacher) % 25;
            int vExtra = vRemainder == 0 ? 0 : 1;

            txtImpGuideQty.Text = (((vQtyStudent + vQtyTeacher) / 25) + vExtra).ToString();
            impquidprcTextBox.Text = "0.00"; //Free
            CalculateBase();
            CalculateOptions();
        }

        private void txtQtyTeacher_Leave(object sender, EventArgs e)
        {
            if (txtQtyTeacher.Text.Trim()=="")
            {
                txtQtyTeacher.Text = "0";
            }
            CalculateBase();
            CalculateOptions();
        }

        private void txtPriceOverRide_Leave(object sender, EventArgs e)
        {
            CalculateBase();
            CalculateOptions();
        }

        private void txtmisc_Leave(object sender, EventArgs e)
        {
            txtmisc.Text = txtmisc.ConvertToDecimal().ToString("0.00");
            CalculateOptions();
        }

        private void dp1TextBox_Leave(object sender, EventArgs e)
        {
            dp1TextBox.Text = dp1TextBox.ConvertToDecimal().ToString("0.0000");
            CalculateOptions();
        }

        private void erldiscamtTextBox_Leave(object sender, EventArgs e)
        {

        }

        private void desc1amtTextBox1_Leave(object sender, EventArgs e)
        {
            desc1amtTextBox1.Text = desc1amtTextBox1.ConvertToDecimal().ToString("0.00");
            CalculateOptions();
        }

        private void descamtTextBox_Leave(object sender, EventArgs e)
        {
            descamtTextBox.Text = descamtTextBox.ConvertToDecimal().ToString("0.00");
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

        private void txtShipping_Leave(object sender, EventArgs e)
        {
            txtShipping.Text = txtShipping.ConvertToDecimal().ToString("0.00");
            CalculateOptions();
        }

       

        private void desc2TextBox1_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void desc3TextBox1_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void desc4TextBox1_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void chkGeneric_Click(object sender, EventArgs e)
        {
            if (chkGeneric.Checked)
            {
                txtNoPages.Text = "0";
                chkJostens.Checked = false;
            }
            CalculateBase();
            CalculateOptions();
        }

        private void chkJostens_Click(object sender, EventArgs e)
        {
            if (chkJostens.Checked)
            {
                chkGeneric.Checked = false;
            }
            CalculateBase();
            CalculateOptions();
        }

        private void fourclrCheckBox_Click(object sender, EventArgs e)
        {
            if (fourclrCheckBox.Checked)
            {
                threeclrCheckBox.Checked = false;
                twoclrCheckBox.Checked = false;
                oneclrCheckBox.Checked = false;
            }
            CoverCalc();
        }

        private void threeclrCheckBox_Click(object sender, EventArgs e)
        {
            if (threeclrCheckBox.Checked)
            {
                fourclrCheckBox.Checked = false;
                twoclrCheckBox.Checked = false;
                oneclrCheckBox.Checked = false;
            }
            CoverCalc();
        }

        private void twoclrCheckBox_Click(object sender, EventArgs e)
        {
            if (twoclrCheckBox.Checked)
            {
                threeclrCheckBox.Checked = false;
                fourclrCheckBox.Checked = false;
                oneclrCheckBox.Checked = false;
            }
            CoverCalc();
        }

        private void oneclrCheckBox_Click(object sender, EventArgs e)
        {
            if (oneclrCheckBox.Checked)
            {
                threeclrCheckBox.Checked = false;
                fourclrCheckBox.Checked = false;
                twoclrCheckBox.Checked = false;
            }
            CoverCalc();
        }

        private void disc4CheckBox_Click(object sender, EventArgs e)
        {
            if (disc4CheckBox.Checked)
            {
                desc4amtTextBox.Text = "-100.00";
            }
            else
            {
                desc4amtTextBox.Text = "0.00";
            }
            CalculateOptions();
        }

        private void disc3CheckBox_Click(object sender, EventArgs e)
        {
            if (disc3CheckBox.Checked)
            {

                desc3amtTextBox.Text = "-" + (lblQtyTotal.ConvertToDecimal() * .25m).ToString("0.00");
            }
            else { desc3amtTextBox.Text = "0.00"; }
            CalculateOptions();
        }

        private void doNotChargeTaxCheckBox_Click(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void prodcodeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var dr = (DataRowView)mbidsBindingSource.Current;
            if (prodcodeComboBox.SelectedValue.ToString() == "HSP" || prodcodeComboBox.SelectedValue.ToString() == "ADVLOG" || prodcodeComboBox.SelectedValue.ToString() == "MAG")
            {
                sfRadioButton.Checked = true;
                lfRadioButton.Checked = false;
                if(prodcodeComboBox.SelectedValue.ToString() == "ADVLOG")
                {
                    chkJostens.Checked = false;
                    chkJostens.AutoCheck = false;
                    chkGeneric.Checked = false;

                }
                else { chkJostens.AutoCheck = true; }
                if (prodcodeComboBox.SelectedValue.ToString() == "MAG")
                {
                    chkJostens.Checked = false;
                    chkJostens.AutoCheck = false;
                    chkGeneric.Checked = false;
                    
                }
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
                    txtQtyTeacher.ReadOnly = false;
                    break;
                case "MSP":
                    lblSchtype.Text = "MS";
                    txtQtyTeacher.ReadOnly = false;
                    break;
                case "MAG":
                    lblSchtype.Text = "MAGNET";
                    txtQtyTeacher.Text = "0";
                    txtQtyTeacher.ReadOnly = true;
                    break;
                case "ADVLOG":
                    lblSchtype.Text = "ADVENTURE LOG";
                    txtQtyTeacher.Text = "0";
                    txtQtyTeacher.ReadOnly = true;
                    break;
                case "ELSP":
                    lblSchtype.Text = "ELEM";
                    txtQtyTeacher.ReadOnly = false;
                    break;
                case "PRISP":
                    lblSchtype.Text = "PRIM";
                    txtQtyTeacher.ReadOnly = false;
                    break;
            }
            if (!GetBookPricing())
            {
                return;
            }
            CalculateBase();
            CalculateOptions();
        }

        private void typesetqtyTextBox_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void wallchqtyTextBox_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void duraglzqtyTextBox_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void stttitpgqtyTextBox_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void idpouchqtyTextBox_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void vpbqtyTextBox_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void vpaqtyTextBox_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void bmarkqtyTextBox_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void hallpqtyTextBox_Leave(object sender, EventArgs e)
        {
            CalculateOptions();
        }

        private void txtNoPages_Leave(object sender, EventArgs e)
        {
            if (txtNoPages.Text.Trim()=="")
            {
                txtNoPages.Text = "0";
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

        private void frmMBids_FormClosing(object sender, FormClosingEventArgs e)
        {
            var salesResult = SaveBid();
            if (salesResult.IsError)
            {
                var result = MessageBox.Show("Bid record could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void frmMBids_Activated(object sender, EventArgs e)
        {
            try { frmMain.ShowSearchButtons(this.Name); } catch { }
        }

        private void frmMBids_Deactivate(object sender, EventArgs e)
        {
            try { frmMain.HideSearchButtons(); } catch { }
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

        private void dp1TextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal vValue;
            errorProvider1.SetError(dp1TextBox, "");
            if (dp1TextBox.Text != "")
            {
                if (!decimal.TryParse(dp1TextBox.Text, out vValue))
                {
                    errorProvider1.SetError(dp1TextBox, "Enter a  valid percentage.");
                    e.Cancel = true;
                }
            }
        }

        private void txtAdditionChrg_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnPrnQuote_Click(object sender, EventArgs e)
        {
            var vBidDetails = new List<MBidInvoiceDetail>();
            var vrow = new MBidInvoiceDetail();
                if (lblSchtype.Text== "MAGNET")
                {

                vrow.Description = lblSchtype.Text + " 4 x 7 Personalized Magnet";
                vrow.UnitPrice = lblBasePrice.ConvertToDecimal();
                vrow.Quantity = txtQtyStudent.ConvertToInt();
                vrow.Price = vrow.UnitPrice * vrow.Quantity;
                vrow.DiscountPercentage = "";
            }
            if ( lblSchtype.Text == "ADVENTURE LOG")
            {
                vrow.Description = lblSchtype.Text;
                vrow.UnitPrice = lblBasePrice.ConvertToDecimal();
                vrow.Quantity = txtQtyStudent.ConvertToInt();
                vrow.Price = vrow.UnitPrice * vrow.Quantity;
                vrow.DiscountPercentage = "";
            }
            if (chkGeneric.Checked)
            {
                vrow.Description = "Standard " + lblSchtype.Text +" "+ txtNoPages.Text+ " Pages "+ (lfRadioButton.Checked==true?"Large Format 8 3/8 x 10 7/8":"Small Format 5 3/8 x 8 3/8");
                vrow.UnitPrice = lblBasePrice.ConvertToDecimal();
                vrow.Quantity = txtQtyStudent.ConvertToInt();
                vrow.Price = vrow.UnitPrice * vrow.Quantity;
                vrow.DiscountPercentage = "0";
            }
            else
            {
                vrow.Description =lblSchtype.Text + " " + txtNoPages.Text + " Pages " + (lfRadioButton.Checked == true ? "Large Format 8 3/8 x 10 7/8" : "Small Format 5 3/8 x 8 3/8");
                vrow.UnitPrice = lblBasePrice.ConvertToDecimal();
                vrow.Quantity = txtQtyStudent.ConvertToInt();
                vrow.Price = vrow.UnitPrice * vrow.Quantity;
                vrow.DiscountPercentage = "0";

            }
            vBidDetails.Add(vrow);
            vrow = null;
            //Teachers Edition------------------------------------------------------------------------------
           vrow = new MBidInvoiceDetail();
            if (txtQtyTeacher.ConvertToInt() > 0 && lblSchtype.Text != "ADVENTURE LOG"&& lblSchtype.Text != "MAGNET")
            {
               
                    if (chkGeneric.Checked)
                    {
                        vrow.Description = "Standard " + lblSchtype.Text + " " + txtNoPages.Text + " Pages " + (lfRadioButton.Checked == true ? "Large Format 8 3/8 x 10 7/8" : "Small Format 5 3/8 x 8 3/8");
                        vrow.UnitPrice = lblBasePrice.ConvertToDecimal();
                        vrow.Quantity = txtQtyStudent.ConvertToInt();
                        vrow.Price = vrow.UnitPrice * vrow.Quantity;
                        vrow.DiscountPercentage = "0";
                    }
                    else
                    {
                        vrow.Description = lblSchtype.Text + " " + txtNoPages.Text + " Pages " + (lfRadioButton.Checked == true ? "Large Format 8 3/8 x 10 7/8" : "Small Format 5 3/8 x 8 3/8");
                        vrow.UnitPrice = lblBasePrice.ConvertToDecimal();
                        vrow.Quantity = txtQtyStudent.ConvertToInt();
                        vrow.Price = vrow.UnitPrice * vrow.Quantity;
                        vrow.DiscountPercentage = "0";

                    }
                    vBidDetails.Add(vrow);
                    vrow = null;
                
            }
            //-----------------------------------------------------------------------
            vrow = new MBidInvoiceDetail();
            string vProdCode = prodcodeComboBox.SelectedValue.ToString();
            switch(vProdCode)
            {
                case "HSP":
                        vrow.Description = "Implementation Guides(1 per 25 planners ordered) - Included";
                        vrow.Price = 0;
                        vrow.Quantity = txtImpGuideQty.ConvertToInt();
                        vBidDetails.Add(vrow);
                        vrow = null;
                   //--------------
                    if (!chkGeneric.Checked && lblCoverPricetotal.ConvertToDecimal() < 1)
                    {
                        vrow = new MBidInvoiceDetail();
                        vrow.Description = "School Name and Mascot on cover-Included";
                        vrow.Price = 0;
                        vBidDetails.Add(vrow);
                        vrow = null;
                    }
                    //-----------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Double-side laminated covers w/round corners - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //--------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Educational resource pages - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //--------------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "'Character Makes a Difference' on inside back cover -Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //---------------------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Hallpasses(one sheet plus those in weekly spread) - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    break;
                case "MSP":
                    vrow.Description = "Implementation Guides(1 per 25 planners ordered) - Included";
                    vrow.Price = 0;
                    vrow.Quantity = txtImpGuideQty.ConvertToInt();
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //--------------
                    if (!chkGeneric.Checked && lblCoverPricetotal.ConvertToDecimal() < 1)
                    {
                        vrow = new MBidInvoiceDetail();
                        vrow.Description = "School Name and Mascot on cover-Included";
                        vrow.Price = 0;
                        vBidDetails.Add(vrow);
                        vrow = null;
                    }
                    //-----------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Double-side laminated covers w/round corners - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //-----------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "3 hole punch to fit in binder - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //--------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Educational resource pages - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //--------------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "'Character Makes a Difference' on inside back cover -Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //---------------------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Hallpasses(one sheet plus those in weekly spread) - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    break;

                case "ELSP":
                    vrow.Description = "Implementation Guides(1 per 25 planners ordered) - Included";
                    vrow.Price = 0;
                    vrow.Quantity = txtImpGuideQty.ConvertToInt();
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //--------------
                    if (!chkGeneric.Checked && lblCoverPricetotal.ConvertToDecimal() < 1)
                    {
                        vrow = new MBidInvoiceDetail();
                        vrow.Description = "School Name and Mascot on cover-Included";
                        vrow.Price = 0;
                        vBidDetails.Add(vrow);
                        vrow = null;
                    }
                    //-----------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Double-side laminated covers w/round corners - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //--------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Educational resource pages - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //--------------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Title Page - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //---------------------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "3 hole punch to fit in binder - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;

                    break;

                case "PRISP":
                    vrow.Description = "Implementation Guides(1 per 25 planners ordered) - Included";
                    vrow.Price = 0;
                    vrow.Quantity = txtImpGuideQty.ConvertToInt();
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //--------------
                    if (!chkGeneric.Checked && lblCoverPricetotal.ConvertToDecimal() < 1)
                    {
                        vrow = new MBidInvoiceDetail();
                        vrow.Description = "School Name and Mascot on cover-Included";
                        vrow.Price = 0;
                        vBidDetails.Add(vrow);
                        vrow = null;
                    }
                    //-----------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Double-side laminated covers w/round corners - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //--------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Educational resource pages - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //--------------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "Title Page - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    //---------------------------------------------------
                    vrow = new MBidInvoiceDetail();
                    vrow.Description = "3 hole punch to fit in binder - Included";
                    vrow.Price = 0;
                    vBidDetails.Add(vrow);
                    vrow = null;
                    break;

            }
            //----------------------------------
            if (hallpqtyTextBox.ConvertToInt()>0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Quantity = hallpqtyTextBox.ConvertToInt();
                vrow.Price = hallppriceTextBox.ConvertToDecimal();
                vrow.UnitPrice = vrow.Price / vrow.Quantity;
                vrow.Description = "Hall Pass per Planner * No. of Students";
                vBidDetails.Add(vrow);
                vrow = null;
               }

            //--------------------------
            if (bmarkqtyTextBox.ConvertToInt() > 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Quantity = bmarkqtyTextBox.ConvertToInt();
                vrow.Price = bmarkprcTextBox.ConvertToDecimal();
                vrow.UnitPrice = vrow.Price / vrow.Quantity;
                vrow.Description = "Book Mark";
                vBidDetails.Add(vrow);
                vrow = null;
            }

            //--------------------------
            if (vpaqtyTextBox.ConvertToInt() > 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Quantity = vpaqtyTextBox.ConvertToInt();
                vrow.Price = vpprcTextBox.ConvertToDecimal();
                vrow.UnitPrice = vrow.Price / vrow.Quantity;
                vrow.Description = "Vinyl Pocket A";
                vBidDetails.Add(vrow);
                vrow = null;

            }

            //--------------------------
            if (vpbqtyTextBox.ConvertToInt() > 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Quantity = vpbqtyTextBox.ConvertToInt();
                vrow.Price = vpbprcTextBox.ConvertToDecimal();
                vrow.UnitPrice = vrow.Price / vrow.Quantity;
                vrow.Description = "Vinyl Pocket B";
                vBidDetails.Add(vrow);
                vrow = null;

            }

            //--------------------------
            if (idpouchqtyTextBox.ConvertToInt() > 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Quantity = idpouchqtyTextBox.ConvertToInt();
                vrow.Price = idpouchprcTextBox.ConvertToDecimal();
                vrow.UnitPrice = vrow.Price / vrow.Quantity;
                vrow.Description = "Id Pouch";
                vBidDetails.Add(vrow);
                vrow = null;

            }

            //--------------------------
            if (stttitpgqtyTextBox.ConvertToInt() > 0 && vProdCode!= "PRISP" && vProdCode != "ELSP")
            {
                vrow = new MBidInvoiceDetail();
                vrow.Quantity = stttitpgqtyTextBox.ConvertToInt();
                vrow.Price = stdttitpgprcTextBox.ConvertToDecimal();
                vrow.UnitPrice = vrow.Price / vrow.Quantity;
                vrow.Description = "Standard Title Page";
                vBidDetails.Add(vrow);
                vrow = null;

            }

            //--------------------------
            if (duraglzqtyTextBox.ConvertToInt() > 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Quantity = duraglzqtyTextBox.ConvertToInt();
                vrow.Price = duraglzprcTextBox.ConvertToDecimal();
                vrow.UnitPrice = vrow.Price / vrow.Quantity;
                vrow.Description = "Duraglaze Cover";
                vBidDetails.Add(vrow);
                vrow = null;

            }

            //--------------------------
            if (wallchqtyTextBox.ConvertToInt() > 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Quantity = wallchqtyTextBox.ConvertToInt();
                vrow.Price = wallchprcTextBox.ConvertToDecimal();
                vrow.UnitPrice = vrow.Price / vrow.Quantity;
                vrow.Description = "Elementary Wall Chart";
                vBidDetails.Add(vrow);
                vrow = null;

            }

            //--------------------------
            if (characterResourceQtyTextBox.ConvertToInt() > 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Quantity = characterResourceQtyTextBox.ConvertToInt();
                vrow.Price = characterResourceAmtTextBox.ConvertToDecimal();
                vrow.UnitPrice = vrow.Price / vrow.Quantity;
                vrow.Description = "Character Resource";
                vBidDetails.Add(vrow);
                vrow = null;

            }
            //------------------------------------------------
            string vNumberColors="One Color";
            if (fourclrCheckBox.Checked == true)
            {
                vNumberColors = "Four Colors";
            }else if (threeclrCheckBox.Checked)
            {
                vNumberColors = "Three Colors";
            }
            else if (twoclrCheckBox.Checked)
            {
                vNumberColors = "Two Colors";
            }else if (oneclrCheckBox.Checked)
            {
                vNumberColors = "One Color";
            }
            vrow = new MBidInvoiceDetail();
            if (lblCoverPricetotal.ConvertToDecimal()>0) {
                vrow.Price = lblCoverPricetotal.ConvertToDecimal();
                vrow.Description = "Cover Price - " + vNumberColors;
                vBidDetails.Add(vrow);
                vrow = null;
            }
            //---------------------------------------------------------------
            vrow = new MBidInvoiceDetail();
            if (lblSpecialCoverPrice.ConvertToDecimal() > 0)
            {
                vrow.Price = lblSpecialCoverPrice.ConvertToDecimal();
                vrow.Description = "Special cover Price - " + (desc2TextBox1.Text.Trim().Length>0?"Insided Front,":"")+(desc3TextBox1.Text.Trim().Length > 0 ? "Insided Back," : "") +(desc4TextBox1.Text.Trim().Length > 0 ? "Outside Back " : "");
                vBidDetails.Add(vrow);
                vrow = null;
            }

            //---------------------------------------------------------
            if (txtmisc.ConvertToDecimal()!=0)
            {
                vrow = new MBidInvoiceDetail();                
                vrow.Price = txtmisc.ConvertToDecimal();               
                vrow.Description = mdescTextBox.Text;
                vBidDetails.Add(vrow);
                vrow = null;
            }
            //---------------------------------------------------------------
            if (erldiscamtTextBox.ConvertToDecimal() != 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Price = erldiscamtTextBox.ConvertToDecimal();
                vrow.Description = dp1TextBox.Text+ " pecent discount";
                vBidDetails.Add(vrow);
                vrow = null;
            }
            //---------------------------------------------------------------
            if (desc1amtTextBox1.ConvertToDecimal() != 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Price = desc1amtTextBox1.ConvertToDecimal();
                vrow.Description = desc1TextBox.Text;
                vBidDetails.Add(vrow);
                vrow = null;
            }
            //---------------------------------------------------------------
            if (descamtTextBox.ConvertToDecimal() != 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Price = descamtTextBox.ConvertToDecimal();
                vrow.Description = desc2TextBox.Text;
                vBidDetails.Add(vrow);
                vrow = null;
            }
            //---------------------------------------------------------------
            if (desc4amtTextBox.ConvertToDecimal() != 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Price = desc4amtTextBox.ConvertToDecimal();
                vrow.Description = desc4TextBox.Text;
                vBidDetails.Add(vrow);
                vrow = null;
            }
            //---------------------------------------------------------------
            if (desc3amtTextBox.ConvertToDecimal() != 0)
            {
                vrow = new MBidInvoiceDetail();
                vrow.Price = desc3amtTextBox.ConvertToDecimal();
                vrow.Description =".25 off per planner"+ desc3TextBox.Text;
                vBidDetails.Add(vrow);
                vrow = null;
            }
            //---------------------------------------------------------------
           
            MBidInvoiceDetailBindingSource.DataSource = vBidDetails;
            ReportParameter rp0 = new ReportParameter("ReportType", chkPrntAsInvoice.Checked.ToString());

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp0 });
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsMeridianBidDetails", bsBidQuote));

            Cursor.Current = Cursors.WaitCursor;

            this.reportViewer1.RefreshReport();


            Cursor.Current = Cursors.Arrow;
        }

        private void txtQtyStudent_Validating(object sender, CancelEventArgs e)
        {
            int val;
            errorProvider1.SetError(txtQtyStudent, "");
            if ( !int.TryParse(txtQtyStudent.Text,out val))
            {
                errorProvider1.SetError(txtQtyStudent, "Enter a valid number");
            }
            if (prodcodeComboBox.SelectedValue.ToString() == "MAGNET"&&txtQtyStudent.ConvertToInt()<100)
            {
                errorProvider1.SetError(txtQtyStudent, "A minimum of 100 is required for this product");
            }
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            try { reportViewer1.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
        }
    }
    }
