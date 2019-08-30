using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
using Mbc5.Dialogs;
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
this.DisableControls(this);

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
        
private void frmMSales_Load(object sender, System.EventArgs e)
    {    
        SetConnectionString();
        Fill();
        this.salesTabControl.TabPages[0].AutoScroll = false;
        mquotesBindingSource.ResetBindings(true);
    }
        #region SearchMethods
        private void NullParseHandler(object sender, ConvertEventArgs e)
{
if (e.Value != null && string.IsNullOrEmpty(e.Value.ToString()))
    e.Value =DBNull.Value;
}
public override void SchCodeSearch()
{
var saveResult = this.Save();
if (saveResult.IsError)
{

    return;
}


var currentSchool = this.Schcode;
frmSearch frmSearch = new frmSearch("Schcode", "MSALES", Schcode);

var result = frmSearch.ShowDialog();
if (result == DialogResult.OK)
{
    //values preserved after close

    try
    {
        this.Invno = frmSearch.ReturnValue.Invno;
        this.Schcode = frmSearch.ReturnValue.Schcode;
        if (string.IsNullOrEmpty(Schcode))
        {
            MbcMessageBox.Hand("A search value was not returned", "Error");
            return;
        }
        this.Fill();
        DataRowView current = (DataRowView)mquotesBindingSource.Current;

        this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
        this.Schcode = current["Schcode"].ToString();
        EnableAllControls(this);

    }
    catch (Exception ex)
    {
        MbcMessageBox.Error(ex.Message, "Error");
        return;

    }

    frmMSales_Paint(this, null);
    this.Cursor = Cursors.Default;
}
}
public override void SchnameSearch()
{
var saveResult = this.Save();
if (saveResult.IsError)
{

    return;
}
DataRowView currentrow = (DataRowView)mquotesBindingSource.Current;
var schname = currentrow["schname"].ToString();

frmSearch frmSearch = new frmSearch("Schname", "MSALES", schname);

var result = frmSearch.ShowDialog();
if (result == DialogResult.OK)
{
    //values preserved after close

    try
    {
        this.Invno = frmSearch.ReturnValue.Invno;
        this.Schcode = frmSearch.ReturnValue.Schcode;
        if (string.IsNullOrEmpty(Schcode))
        {
            MbcMessageBox.Hand("A search value was not returned", "Error");
            return;
        }
        this.Fill();
        DataRowView current = (DataRowView)mquotesBindingSource.Current;

        this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
        this.Schcode = current["Schcode"].ToString();
        EnableAllControls(this);

    }
    catch (Exception ex)
    {
        MbcMessageBox.Error(ex.Message, "Error");
        return;

    }

    frmMSales_Paint(this, null);
    this.Cursor = Cursors.Default;
}



}
public override void OracleCodeSearch()
{
var saveResult = this.Save();
if (saveResult.IsError)
{

    return;
}
DataRowView currentrow = (DataRowView)mquotesBindingSource.Current;
var oraclecode = currentrow["oraclecode"].ToString();

frmSearch frmSearch = new frmSearch("OracleCode", "MSALES", oraclecode);

var result = frmSearch.ShowDialog();
if (result == DialogResult.OK)
{
    //values preserved after close

    try
    {
        this.Invno = frmSearch.ReturnValue.Invno;
        this.Schcode = frmSearch.ReturnValue.Schcode;
        if (string.IsNullOrEmpty(Schcode))
        {
            MbcMessageBox.Hand("A search value was not returned", "Error");
            return;
        }
        this.Fill();
        DataRowView current = (DataRowView)mquotesBindingSource.Current;

        this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
        this.Schcode = current["Schcode"].ToString();
        EnableAllControls(this);

    }
    catch (Exception ex)
    {
        MbcMessageBox.Error(ex.Message, "Error");
        return;

    }
    frmMSales_Paint(this, null);

    this.Cursor = Cursors.Default;
}
}
public override void InvoiceNumberSearch()
{
var invno = "0";
var saveResult = this.Save();
if (saveResult.IsError)
{

    return;
}
DataRowView currentrow = (DataRowView)mquotesBindingSource.Current;
if (currentrow != null)
{
    invno = currentrow["invno"].ToString();
}
frmSearch frmSearch = new frmSearch("INVNO", "MSALES", invno);

var result = frmSearch.ShowDialog();
if (result == DialogResult.OK)
{
    //values preserved after close

    try
    {
        this.Invno = frmSearch.ReturnValue.Invno;
        this.Schcode = frmSearch.ReturnValue.Schcode;
        if (string.IsNullOrEmpty(Schcode))
        {
            MbcMessageBox.Hand("A search value was not returned", "Error");
            return;
        }
        this.Fill();
        DataRowView current = (DataRowView)mquotesBindingSource.Current;

        this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
        this.Schcode = current["Schcode"].ToString();
        EnableAllControls(this);

    }
    catch (Exception ex)
    {
        MbcMessageBox.Error(ex.Message, "Error");
        return;

    }
    frmMSales_Paint(this, null);

    this.Cursor = Cursors.Default;
}
}

        #endregion
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
            erldiscamtTextBox.Text = "-" + (dp1TextBox.ConvertToDecimal() * vSbtot).ToString("0.00");

            afterdisctotLabel2.Text = (vSbtot + erldiscamtTextBox.ConvertToDecimal() + desc1amtTextBox1.ConvertToDecimal() + descamtTextBox.ConvertToDecimal()
            + desc4amtTextBox.ConvertToDecimal() + desc3amtTextBox.ConvertToDecimal()).ToString();
            //___________________________________________________________________
            decimal vTotal = (vSbtot + erldiscamtTextBox.ConvertToDecimal() + desc1amtTextBox1.ConvertToDecimal() + descamtTextBox.ConvertToDecimal());

            lblFinalPrice.Text = Math.Round((vTotal / lblQtyTotal.ConvertToInt()),2).ToString("0.00");
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

            lblFinalTotal.Text = (afterdisctotLabel2.ConvertToDecimal() + txtShipping.ConvertToDecimal() + lblTax.ConvertToDecimal()).ToString();



        }
        private void CalculateBase()
        {
            if (prodcodeComboBox.SelectedValue==null)
            {
                //form closing dropdown has no values return
                return ;
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
                        vBasePrice = (decimal)ObjectFieldValue.Get<MeridianPrice>("GenericM", Pricing);
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
        private void NewPayment()
        {
            txtPaypoamt.Enabled = true;
            txtInitials.Enabled = true;
            pmtdateDateBox.Enabled = true;
            txtCheckNo.Enabled = true;
            txtMethod.Enabled = true;
            txtPayment.Enabled = true;
            txtRefund.Enabled = true;
            txtAdjustment.Enabled = true;
            txtCompensation.Enabled = true;
            txtCompReason.Enabled = true;
            paymntBindingSource.AddNew();

            DataRowView current = (DataRowView)paymntBindingSource.Current;
            current["Invno"] = Invno;
            current["Code"] = this.Schcode;
            SetCrudButtons();
        }
        private bool ValidatePayment()
        {
            bool retval = true;
            if (txtInitials.Enabled == true)
            {
                errorProvider1.SetError(txtInitials, "");

                if (String.IsNullOrEmpty(txtInitials.Text))
                {
                    errorProvider1.SetError(txtInitials, "Please enter your initials.");
                    retval = false;
                    return retval;
                }
            }
            bool result = true;
            decimal val = 0;
            if (!String.IsNullOrEmpty(txtPaypoamt.Text))
            {
                result = Decimal.TryParse(txtPaypoamt.Text, out val);
                errorProvider1.SetError(txtPaypoamt, "");
                if (!result)
                {

                    errorProvider1.SetError(txtPaypoamt, "Value must be a Decimal.");
                    retval = false;
                    return retval;
                }

            }
            if (!String.IsNullOrEmpty(txtPayment.Text))
            {
                result = Decimal.TryParse(txtPayment.Text, out val);
                errorProvider1.SetError(txtPayment, "");
                if (!result)
                {

                    errorProvider1.SetError(txtPayment, "Value must be a Decimal.");
                    retval = false;
                    return retval;
                }

            }
         if (!String.IsNullOrEmpty(txtRefund.Text))
            {
                result = Decimal.TryParse(txtRefund.Text, out val);
                errorProvider1.SetError(txtRefund, "");
                if (!result)
                {

                    errorProvider1.SetError(txtRefund, "Value must be a Decimal.");
                    retval = false;
                    return retval;
                }

            }
             if (!String.IsNullOrEmpty(txtAdjustment.Text))
            {
                result = Decimal.TryParse(txtAdjustment.Text, out val);
                errorProvider1.SetError(txtAdjustment, "");
                if (!result)
                {

                    errorProvider1.SetError(txtAdjustment, "Value must be a Decimal.");
                    retval = false;
                    return retval;
                }


            }
            else if (!String.IsNullOrEmpty(txtCompensation.Text))
            {
                result = Decimal.TryParse(txtCompensation.Text, out val);
                errorProvider1.SetError(txtCompensation, "");
                if (!result)
                {

                    errorProvider1.SetError(txtCompensation, "Value must be a Decimal.");
                    retval = false;
                    return retval;
                }

            }

            return retval;
        }
        private ApiProcessingResult<bool> SavePayment()
        {
            var processingResult = new ApiProcessingResult<bool>();
            if (paymntBindingSource.Count > 0)
            {
                if (this.ValidatePayment())
                {

                    try
                    {
                        this.paymntBindingSource.EndEdit();
                        this.paymntTableAdapter.Update(dsMInvoice.paymnt);
                        this.paymntTableAdapter.Fill(dsMInvoice.paymnt,Invno);
                        this.CalculatePayments();
                        txtPaypoamt.Enabled = false;
                        txtInitials.Enabled = false;
                        pmtdateDateBox.Enabled = false;
                        txtCheckNo.Enabled = false;
                        txtMethod.Enabled = false;
                        txtPayment.Enabled = false;
                        txtRefund.Enabled = false;
                        txtAdjustment.Enabled = false;
                        txtCompensation.Enabled = false;
                        txtCompReason.Enabled = false;

                    }
                    catch (DBConcurrencyException ex1)
                    {
                        MbcMessageBox.Hand("Another user has updated this record, your copy is not current. Your data is being reverted, Please re-enter your data.", "Concurrency Error");
                        this.Fill();
                        string errmsg = "Concurrency violation" + Environment.NewLine + ex1.Row.ItemArray[0].ToString();

                        processingResult.IsError = true;
                        processingResult.Errors.Add(new ApiProcessingError(errmsg, errmsg, ""));

                    }
                    catch (Exception ex)
                    {
                        processingResult.IsError = true;
                        processingResult.Errors.Add(new ApiProcessingError("Payment failed to update:" + ex.Message, "Payment failed to update:" + ex.Message, ""));

                    }
                }
                else
                {
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError("Payment failed to validate.", "Payment failed to validate.", ""));
                }
            }
            return processingResult;
        }
        private bool DeletePayment()
        {
            bool retval = true;
            DialogResult messageResult = MessageBox.Show("This will delete the current line item payment. Do you want to proceed?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (messageResult == DialogResult.Yes)
            {
                DataRowView current = (DataRowView)paymntBindingSource.Current;
                var Id = current["Id"];

                var sqlQuery = new SQLQuery();
                var queryString = "Delete  From  paymnt where Id=@Id ";
                SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Id",Id)
            };
                var result = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, queryString, parameters);
                CalculatePayments();
                this.paymntTableAdapter.Fill(dsMInvoice.paymnt,Invno);

                if (result == 0) { retval = false; }
                SetCrudButtons();
            }
            return retval;

        }
        private void CancelPayment()
        {
            paymntBindingSource.CancelEdit();
            txtPaypoamt.Enabled = false; 
            txtInitials.Enabled = false;
            pmtdateDateBox.Enabled = false;
            txtCheckNo.Enabled = false;
            txtMethod.Enabled = false;
            txtPayment.Enabled = false;
            txtRefund.Enabled = false;
            txtAdjustment.Enabled = false;
            txtCompensation.Enabled = false;
            txtCompReason.Enabled = false;
            errorProvider1.Clear();
        }
        private void EditPayment()
        {
            txtPaypoamt.Enabled = true;
            txtInitials.Enabled = true;
            pmtdateDateBox.Enabled = true;
            txtCheckNo.Enabled = true;
            txtMethod.Enabled = true;
            txtPayment.Enabled = true;
            txtRefund.Enabled = true;
            txtAdjustment.Enabled = true;
            txtCompensation.Enabled = true;
            txtCompReason.Enabled = true;

        }
        private bool CalculatePayments()
        {
            return CalculatePayments(Invno.ToString());
        }
        private bool CalculatePayments(string invoiceNumber)
        {
            bool retval = false;
            decimal? paymentTotals = 0;
            if (string.IsNullOrEmpty(invoiceNumber))
            {
                return retval;
            }
            var SqlQuery = new SQLQuery();
            var cmdText = @"SELECT ISNULL(SUM(ISNULL(payment, 0) + ISNULL(refund, 0) + ISNULL(adjmnt, 0)),0) AS paymentresult
                         FROM paymnt where Invno=@Invno";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Invno",invoiceNumber) };
            var result = SqlQuery.ExecuteReaderAsync(CommandType.Text, cmdText, parameters);
            //paymentTotals =(decimal)this.paymntTableAdapter.SumPayment(Convert.ToInt32(lblInvoice.Text));
            try
            {

                paymentTotals = (decimal)result.Rows[0]["paymentresult"];
                cmdText = @"Update invoice set payments=@payments,baldue=invtot-@payments  where Invno=@Invno ";
                SqlParameter[] parameters1 = new SqlParameter[] {
                new SqlParameter("@Invno",invoiceNumber),
                new SqlParameter("@payments",paymentTotals)};
                var a = SqlQuery.ExecuteNonQueryAsync(CommandType.Text, cmdText, parameters1);
                this.merinvoiceTableAdapter.Fill(dsMInvoice.merinvoice, Invno);
                retval = true;
            }
            catch (Exception ex)
            {

            }
            return retval;
        }
        private void SetCrudButtons()
        {
            btnSavePayment.Enabled = paymntBindingSource.Count > 0;
            btnDelete.Enabled = paymntBindingSource.Count > 0;
            btnEdit.Enabled = paymntBindingSource.Count > 0;
            if (paymntBindingSource.Count < 1)
            {
                txtPaypoamt.Enabled = false;
                txtInitials.Enabled = false;
                pmtdateDateBox.Enabled = false;
                txtCheckNo.Enabled = false;
                txtMethod.Enabled = false;
                txtPayment.Enabled = false;
                txtRefund.Enabled = false;
                txtAdjustment.Enabled = false;
                txtCompensation.Enabled = false;
                txtCompReason.Enabled = false;
            }
        }
        private void CreateInvoice()
{
            //check if invoice exist

            var sqlQuery1 = new SQLQuery();
            var queryString = "SELECT Invno From MerInvoice where Invno=@Invno ";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Invno",this.Invno)
            };
            DataTable result = new DataTable();
            try
            {
                result = sqlQuery1.ExecuteReaderAsync(CommandType.Text, queryString, parameters);
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message, "");
                return;
            }

            //refill to keep concurrency correct
            if (result.Rows.Count > 0)
            {
                DialogResult invoiceresult = MessageBox.Show("There is already an invoice created, do you want to overwrite the current invoice", "Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (invoiceresult == DialogResult.Yes)
                {
                    if (!DeleteInvoice())
                    {
                        
                        return;
                       
                    }
                    this.Fill();
                }

            }
            //Create the invoice

            //txtModifiedBy.Text = this.ApplicationUser.id;
            //txtModifiedByInv.Text = this.ApplicationUser.id;
            //txtModifiedByInvdetail.Text = this.ApplicationUser.id;
            //txtModifiedByPay.Text = this.ApplicationUser.id;
            var sqlQuery = new SQLCustomClient();
            var cmd = @"
                        Insert INTO MerInvoice (Schcode,Invno,QteDate,NoPages,QtyTotal,FplnPrc,Source,PoNum,fplntot,BalDue,ContFname,ContLname
                        ,SchName,InvName,InvAddr,InvAddr2,InvCity,InvState,InvZip,ShpName,ShpAddr,ShpAddr2,ShpCity,ShpState,ShpZip,ContrYear,BasePrc,BaseTot,FormatType,SchType
                    ,QtyStudent,QtyTeacher,Generic,TeBasePrc,ShpDate,SalesTax,ModifiedBy,ProdCode,SubTotal,TeacherBaseTotal,ShpHandling,StudentTotalBasePrice,invnotes) 
                        Values(@Schcode,@Invno,@QteDate,@NoPages,@QtyTotal,@FplnPrc,@Source,@PoNum,@fplntot,@BalDue,@ContFname,@ContLname
                        ,@SchName,@InvName,@InvAddr,@InvAddr2,@InvCity,@InvState,@InvZip,@ShpName,@ShipAddr,@ShpAddr2,@ShpCity,@ShpState,@ShpZip,@ContrYear,@BasePrc,@BaseTot,@FormatType,@SchType
                    ,@QtyStudent,@QtyTeacher,@Generic,@TeBasePrc,@ShpDate,@SalesTax,@ModifiedBy,@ProdCode,@SubTotal,@TeacherBaseTotal,@ShpHandling,@StudentTotalBasePrice,@invnotes)
                        ";
            sqlQuery.CommandText(cmd);
            var dr = (DataRowView)mquotesBindingSource.Current;
     
            sqlQuery.AddParameter("@StudentTotalBasePrice", (txtQtyStudent.ConvertToInt()* lblBasePrice.ConvertToDecimal()));
            sqlQuery.AddParameter("@ShpHandling", txtShipping.Text==""?"0": txtShipping.Text);
            sqlQuery.AddParameter("@invnotes", dr["invnotes"].ToString());
            sqlQuery.AddParameter("@Schcode", Schcode);
            sqlQuery.AddParameter("@Invno",Invno);
            sqlQuery.AddParameter("@QteDate", qtedateDateBox.DateValue);
            sqlQuery.AddParameter("@NoPages", txtNoPages.Text);
            sqlQuery.AddParameter("@QtyTotal", lblQtyTotal.Text);
            sqlQuery.AddParameter("@FplnPrc", lblFinalPrice.Text);
            sqlQuery.AddParameter("@Source", sourceTextBox.Text);
            sqlQuery.AddParameter("@PoNum", ponumTextBox.Text);
            sqlQuery.AddParameter("@fplntot", lblFinalTotal.Text);
            sqlQuery.AddParameter("@BalDue", lblFinalTotal.Text);
            sqlQuery.AddParameter("@ContFname",dr["ContFname"].ToString());
            sqlQuery.AddParameter("@ContLname", dr["ContLname"].ToString());
            sqlQuery.AddParameter("@SchName", dr["schname"].ToString());
            sqlQuery.AddParameter("@InvName", dr["InvName"].ToString());
            sqlQuery.AddParameter("@InvAddr", dr["InvAddr"].ToString());
            sqlQuery.AddParameter("@InvAddr2", dr["InvAddr2"].ToString());
            sqlQuery.AddParameter("@InvCity", dr["InvCity"].ToString());
            sqlQuery.AddParameter("@InvState", dr["InvState"].ToString());
            sqlQuery.AddParameter("@InvZip", dr["InvZip"].ToString());
            sqlQuery.AddParameter("@ShpName", dr["ShpName"].ToString());
            sqlQuery.AddParameter("@ShipAddr", dr["ShpAddr"].ToString());
            sqlQuery.AddParameter("@ShpAddr2", dr["ShpAddr2"].ToString());
            sqlQuery.AddParameter("@ShpCity", dr["ShpCity"].ToString());
            sqlQuery.AddParameter("@ShpState", dr["ShpState"].ToString());
            sqlQuery.AddParameter("@ShpZip", dr["ShpZip"].ToString());
            sqlQuery.AddParameter("@ContrYear", contryearTextBox.Text);
            sqlQuery.AddParameter("@BasePrc", lblBasePrice.Text);
            sqlQuery.AddParameter("@BaseTot", lblTotalBasePrice.Text);
            sqlQuery.AddParameter("@FormatType",lfRadioButton.Checked?"Large Format":"Small Format");
            sqlQuery.AddParameter("@SubTotal", afterdisctotLabel2.Text);
            sqlQuery.AddParameter("@ProdCode",dr["prodcode"].ToString());
            sqlQuery.AddParameter("ModifiedBy", this.ApplicationUser.id);
            sqlQuery.AddParameter("TeacherBaseTotal", (lblTeachBasePrice.ConvertToDecimal()* txtQtyTeacher.ConvertToInt()));
            
            string vSchType = "";
            switch (dr["prodcode"].ToString())
            {
                case "MAG":
                    vSchType = "MAGNET";
                    break;
                case "ADVLOG":
                    vSchType = "ADVENTURE LOG";
                        break;
                case "HSP":
                    vSchType = "HS";
                        break;
                case "MSP":;
                    vSchType = "MS";
                        break;
                case "ELSP":
                    vSchType = "ELEM";
                        break;
                case "PRISP":
                    vSchType = "PRIM";
                        break;

            }
            sqlQuery.AddParameter("@SchType",vSchType);
            sqlQuery.AddParameter("@QtyStudent", txtQtyStudent.Text);
            sqlQuery.AddParameter("@QtyTeacher", txtQtyTeacher.Text);
            sqlQuery.AddParameter("@Generic", chkGeneric.Checked);
            sqlQuery.AddParameter("@TeBasePrc", lblTeachBasePrice.Text);
            sqlQuery.AddParameter("@SalesTax", lblTax.Text);
            sqlQuery.AddParameter("@ShpDate",dr["shpdate"].ToString());
            var updateResult=sqlQuery.Update();
            if (updateResult.IsError)
            {
                MbcMessageBox.Error("Failed to create invoice:" + updateResult.Errors[0].ErrorMessage);
                return;
            }
            sqlQuery.ClearParameters();
            sqlQuery.CommandText(@"Insert INTO MerInvDetail (Schcode,Invno,Descr,Amount,Discpercent,Quantity,UnitPrice) Values(@Schcode,@Invno,@Descr,@Amount,@Discpercent,@Quantity,@UnitPrice)");
            var updateDetailResult = new ApiProcessingResult<int>();
            
            if (lblCoverPricetotal.ConvertToDecimal() > 0)
            {
                string vNumberColors = "One Color";
                if (fourclrCheckBox.Checked == true)
                {
                    vNumberColors = "Four Colors";
                }
                else if (threeclrCheckBox.Checked)
                {
                    vNumberColors = "Three Colors";
                }
                else if (twoclrCheckBox.Checked)
                {
                    vNumberColors = "Two Colors";
                }
                else if (oneclrCheckBox.Checked)
                {
                    vNumberColors = "One Color";
                }

                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", "Cover Price - " + vNumberColors);
                sqlQuery.AddParameter("@Amount", lblCoverPricetotal.ConvertToDecimal());
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", DBNull.Value);
                sqlQuery.AddParameter("@UnitPrice",DBNull.Value);
                    updateDetailResult=sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }

            }
            if (hallpqtyTextBox.ConvertToInt() > 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", "Hall Pass per Planner * No. of Students");
                sqlQuery.AddParameter("@Amount", hallppriceTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", hallpqtyTextBox.Text);
                sqlQuery.AddParameter("@UnitPrice", (hallppriceTextBox.ConvertToDecimal()/ hallpqtyTextBox.ConvertToInt()));
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }
            }

            //--------------------------
            if (bmarkqtyTextBox.ConvertToInt() > 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", "Book Mark");
                sqlQuery.AddParameter("@Amount", bmarkprcTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", bmarkqtyTextBox.Text);
                sqlQuery.AddParameter("@UnitPrice", (bmarkprcTextBox.ConvertToDecimal() / bmarkqtyTextBox.ConvertToInt()));
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }
            }

            //--------------------------
            if (vpaqtyTextBox.ConvertToInt() > 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", "Vinyl Pocket A");
                sqlQuery.AddParameter("@Amount", vpprcTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", vpaqtyTextBox.Text);
                sqlQuery.AddParameter("@UnitPrice", (vpprcTextBox.ConvertToDecimal() / vpaqtyTextBox.ConvertToInt()));
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }

            }

            //--------------------------
            if (vpbqtyTextBox.ConvertToInt() > 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", "Vinyl Pocket B");
                sqlQuery.AddParameter("@Amount", vpbprcTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", vpbqtyTextBox.Text);
                sqlQuery.AddParameter("@UnitPrice", (vpbprcTextBox.ConvertToDecimal() / vpbqtyTextBox.ConvertToInt()));
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }

            }

            //--------------------------
            if (idpouchqtyTextBox.ConvertToInt() > 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", "Id Pouch");
                sqlQuery.AddParameter("@Amount", idpouchprcTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", idpouchqtyTextBox.Text);
                sqlQuery.AddParameter("@UnitPrice", (idpouchprcTextBox.ConvertToDecimal() / idpouchqtyTextBox.ConvertToInt()));
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }

            }
            
            //--------------------------
            if (stttitpgqtyTextBox.ConvertToInt() > 0 && dr["prodcode"].ToString() != "PRISP" && dr["prodcode"].ToString() != "ELSP")
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", "Standard Title Page");
                sqlQuery.AddParameter("@Amount", stdttitpgprcTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", stttitpgqtyTextBox.Text);
                sqlQuery.AddParameter("@UnitPrice", (stdttitpgprcTextBox.ConvertToDecimal() / stttitpgqtyTextBox.ConvertToInt()));
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }

            }

            //--------------------------
            if (duraglzqtyTextBox.ConvertToInt() > 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", "Standard Title Page");
                sqlQuery.AddParameter("@Amount", duraglzprcTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", duraglzqtyTextBox.Text);
                sqlQuery.AddParameter("@UnitPrice", (duraglzprcTextBox.ConvertToDecimal() / duraglzqtyTextBox.ConvertToInt()));
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }

            }

            //--------------------------
            if (wallchqtyTextBox.ConvertToInt() > 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", "Duraglaze Cover");
                sqlQuery.AddParameter("@Amount", duraglzprcTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", duraglzqtyTextBox.Text);
                sqlQuery.AddParameter("@UnitPrice", (duraglzprcTextBox.ConvertToDecimal() / duraglzqtyTextBox.ConvertToInt()));
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }

            }

            //--------------------------
            if (typesetqtyTextBox.ConvertToInt() > 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", "Typesetting Service");
                sqlQuery.AddParameter("@Amount", typesetprcTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", typesetqtyTextBox.Text);
                sqlQuery.AddParameter("@UnitPrice", (typesetprcTextBox.ConvertToDecimal() / typesetqtyTextBox.ConvertToInt()));
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }

            }
            if (lblSpecialCoverPrice.ConvertToDecimal() > 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", "Special cover Price - " + (desc2TextBox1.Text.Trim().Length > 0 ? "Insided Front," : "") + (desc3TextBox1.Text.Trim().Length > 0 ? "Insided Back," : "") + (desc4TextBox1.Text.Trim().Length > 0 ? "Outside Back " : ""));
                sqlQuery.AddParameter("@Amount", lblSpecialCoverPrice.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", DBNull.Value);
                sqlQuery.AddParameter("@UnitPrice", DBNull.Value);
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }
            }
            //---------------------------------------------------------
            if (txtmisc.ConvertToDecimal() != 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", mdescTextBox.Text);
                sqlQuery.AddParameter("@Amount", txtmisc.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", DBNull.Value);
                sqlQuery.AddParameter("@UnitPrice", DBNull.Value);
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }
            }
            //---------------------------------------------------------------
            if (erldiscamtTextBox.ConvertToDecimal() != 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", dp1TextBox.Text + " pecent discount");
                sqlQuery.AddParameter("@Amount", erldiscamtTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", DBNull.Value);
                sqlQuery.AddParameter("@UnitPrice", DBNull.Value);
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }
            }
            //---------------------------------------------------------------
            if (desc1amtTextBox1.ConvertToDecimal() != 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", desc1TextBox.Text);
                sqlQuery.AddParameter("@Amount", desc1amtTextBox1.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", DBNull.Value);
                sqlQuery.AddParameter("@UnitPrice", DBNull.Value);
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }
            }
            //---------------------------------------------------------------
            if (descamtTextBox.ConvertToDecimal() != 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", desc2TextBox.Text);
                sqlQuery.AddParameter("@Amount", descamtTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", DBNull.Value);
                sqlQuery.AddParameter("@UnitPrice", DBNull.Value);
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }
            }
            //---------------------------------------------------------------
            if (desc4amtTextBox.ConvertToDecimal() != 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", desc4TextBox.Text);
                sqlQuery.AddParameter("@Amount", desc4amtTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", DBNull.Value);
                sqlQuery.AddParameter("@UnitPrice", DBNull.Value);
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }
            }
            //---------------------------------------------------------------
            if (desc3amtTextBox.ConvertToDecimal() != 0)
            {
                sqlQuery.ClearParameters();
                sqlQuery.AddParameter("@Schcode", Schcode);
                sqlQuery.AddParameter("@Invno", Invno);
                sqlQuery.AddParameter("@Descr", ".25 off per planner" + desc3TextBox.Text);
                sqlQuery.AddParameter("@Amount", desc3amtTextBox.Text);
                sqlQuery.AddParameter("@Discpercent", DBNull.Value);
                sqlQuery.AddParameter("@Quantity", DBNull.Value);
                sqlQuery.AddParameter("@UnitPrice", DBNull.Value);
                updateDetailResult = sqlQuery.Update();
                if (updateDetailResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert invoice detail record:" + updateDetailResult.Errors[0].ErrorMessage);
                }
            }
            sqlQuery.ClearParameters();
            sqlQuery.CommandText(@"Update mquotes Set Invoiced=@Invoiced where Invno=@Invno ");
            sqlQuery.AddParameter("@Invoiced", true);
            sqlQuery.AddParameter("@Invno", Invno);
            var invoicedResult = sqlQuery.Update();
            if (invoicedResult.IsError)
            {
                MbcMessageBox.Error("Failed to set meridian sale as invoiced:" + invoicedResult.Errors[0].ErrorMessage);
            }
            Fill();

        }
 private bool DeleteInvoice()
        {
            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText("Delete From MerInvoice Where Invno=@Invno");
            sqlQuery.AddParameter("@Invno", this.Invno);
            var result = sqlQuery.Delete();
            if (result.IsError)
            {
                MbcMessageBox.Error("Failed to delete invoice:"+result.Errors[0].ErrorMessage);
                return false;
            }
            sqlQuery.ClearParameters();
            sqlQuery.CommandText("Delete From MerInvdetail Where Invno=@Invno");
            sqlQuery.AddParameter("@Invno", this.Invno);
            var result1 = sqlQuery.Delete();
            if (result1.IsError)
            {
                MbcMessageBox.Error("Failed to delete invoice details:" + result.Errors[0].ErrorMessage);
                return false;
            }
            return true;
        }

private bool ValidSales()
{
bool retval = true;

retval = ValidateCalcData();
if (!retval) { return retval; }
            
retval = this.ValidateChildren();
if (!retval) { return retval; }
retval = this.Validate();
return retval;
}
public override ApiProcessingResult<bool> Save()
{
           
                
return SaveSales();
}
private ApiProcessingResult<bool> SaveSales()
{
var processingResult = new ApiProcessingResult<bool>();
            CalculateBase();
            CalculateOptions();
            if (!ValidSales())
{
    processingResult.IsError = true;
    return processingResult;
}
            
try {
    if (Validate())
    {
        mquotesBindingSource.EndEdit();                  
        var a = mquotesTableAdapter.Update(dsMSales.mquotes);
        //var aa = dsMSales.Tables["mquotes"].GetErrors();
        coversBindingSource.EndEdit();
        var aaa=coversTableAdapter.Update(dsMSales.covers);
        Fill();
        processingResult.Data = true;
        return processingResult;
                    
    }
    processingResult.Data =false;
    return processingResult;
} catch (Exception ex)
{
    ex.ToExceptionless()
        .AddObject(ex)
        .MarkAsCritical()
        .Submit();
    processingResult.Data = false;
    processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message,""));
    return processingResult;
}       
}
private void SetNoticeLabels()
{
try
{
    lblIncollections.Location = new Point(157, 86);
    lblIncollections.Visible = collectionsCheckBox.Checked;
    DataRowView dr = (DataRowView)mquotesBindingSource.Current;
    bool vshpdate = dr.Row.IsNull("shpdate");
    lblShipped.Visible = !vshpdate;
}
catch
{

    //}

}
}
private void Fill()
{

if (Invno != 0)
{
    try
    {
        this.meridianProductsTableAdapter.Fill(this.lookUp.MeridianProducts);
        mquotesTableAdapter.Fill(dsMSales.mquotes, Invno);
        coversTableAdapter.Fill(dsMSales.covers, Invno);
        merinvoiceTableAdapter.Fill(dsMInvoice.merinvoice, Invno);
        merinvdetailTableAdapter.Fill(dsMInvoice.merinvdetail, Invno);
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
        this.meridianProductsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
        this.mquotesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
        coversTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
        merinvoiceTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
        merinvdetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
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
                MbcMessageBox.Error("There were no option prices found for year:" + contryearTextBox.Text);
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
catch
{
    return 0;
}
}
#endregion
private void collectionsCheckBox_CheckedChanged(object sender, System.EventArgs e)
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
   // chkindateDateTimePicker.Format = DateTimePickerFormat.Short;
}      
private void prodcodeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
{
            
    var dr = (DataRowView)mquotesBindingSource.Current;
    if (prodcodeComboBox.SelectedValue.ToString() == "HSP" || prodcodeComboBox.SelectedValue.ToString() == "ADVLOG" || prodcodeComboBox.SelectedValue.ToString() == "MAG")
    {
        sfRadioButton.Checked = true;
        lfRadioButton.Checked = false;
                sfRadioButton.Checked = true;
                lfRadioButton.Checked = false;
                if (prodcodeComboBox.SelectedValue.ToString() == "ADVLOG")
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
    threeclrCheckBox.Checked = false;
    twoclrCheckBox.Checked = false;
    oneclrCheckBox.Checked = false;
    CoverCalc();
    CalculateOptions();
}
private void threeclrCheckBox_Click(object sender, EventArgs e)
{
    fourclrCheckBox.Checked = false;
    twoclrCheckBox.Checked = false;
    oneclrCheckBox.Checked = false;
    CoverCalc();
    CalculateOptions();
}
private void twoclrCheckBox_Click(object sender, EventArgs e)
{
    threeclrCheckBox.Checked = false;
    fourclrCheckBox.Checked = false;
    oneclrCheckBox.Checked = false;
    CoverCalc();
    CalculateOptions();
}
private void oneclrCheckBox_Click(object sender, EventArgs e)
{
    threeclrCheckBox.Checked = false;
    twoclrCheckBox.Checked = false;
    fourclrCheckBox.Checked = false;
    CoverCalc();
    CalculateOptions();
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

private void collectionsCheckBox_CheckedChanged_1(object sender, EventArgs e)
{
    SetNoticeLabels();
}
private void frmMSales_Paint(object sender, PaintEventArgs e)
{
    try { this.Text = "Meridian Sales-" + lblSchname.Text.Trim() + " (" + this.Schcode.Trim() + ")  Invoice No."+Invno ; }
    catch
    {

    }
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
private void txtNoPages_Validating(object sender, CancelEventArgs e)
{
    errorProvider1.SetError(txtNoPages, "");
    if (sfRadioButton.Checked)
    {
        if (txtNoPages.ConvertToInt() > 152)
        {
            errorProvider1.SetError(txtNoPages, "Number of pages should be 152 or less for josten planners.");
            e.Cancel = true;
        }
        if (chkJostens.Checked)
        {
            if (txtNoPages.ConvertToInt() % 4 > 0 || txtNoPages.ConvertToInt() < 1)
            {
                errorProvider1.SetError(txtNoPages, "The number of pages entry must divisible by 4");
                e.Cancel = true;
                return;
            }
        }

        if (txtNoPages.ConvertToInt() % 2 != 0)
        {

            errorProvider1.SetError(txtNoPages, "The number of pages entry must be greater divisible by 2!");
            e.Cancel = true;
            return;
        }

    }
    else
    {
        //LF-----------------
        if (txtNoPages.ConvertToInt() > 76 && chkJostens.Checked && txtPriceOverRide.ConvertToDecimal() == 0)
        {
            errorProvider1.SetError(txtNoPages, "Number of pages should be 76 or less for josten planners.");
            e.Cancel = true;
            return;

        }

        if (chkJostens.Checked)
        {
            if (txtNoPages.ConvertToInt() % 2 > 0 || txtNoPages.ConvertToInt() < 1)
            {
                errorProvider1.SetError(txtNoPages, "The number of pages entry must be greater than 1 and divisible by 2!");
                e.Cancel = true;
                return;
            }
        }
        if (txtNoPages.ConvertToInt() % 2 != 0)
        {

            errorProvider1.SetError(txtNoPages, "The number of pages entry must be greater divisible by 2!");
            e.Cancel = true;
            return;
        }

    }

    }
private void frmMSales_FormClosing(object sender, FormClosingEventArgs e)
{
    switch (salesTabControl.SelectedIndex)
    {
        case 0:
        case 1:
            var salesResult = SaveSales();
            if (salesResult.IsError)
            {
                var result = MessageBox.Show("Sales record could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            break;
        case 3:
            //var paymentResult = SavePayment();
            //if (paymentResult.IsError)
            //{
            //    var result = MessageBox.Show("Payment record could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (result == DialogResult.No)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}
            break;
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
private void txtQtyStudent_Leave(object sender, EventArgs e)
{

    int vQtyStudent = txtQtyStudent.ConvertToInt();
    int vQtyTeacher = txtQtyTeacher.ConvertToInt();
    int vRemainder = (vQtyStudent + vQtyTeacher) % 25;
    int vExtra = vRemainder == 0 ? 0 : 1;

    txtImpGuideQty.Text = (((vQtyStudent + vQtyTeacher) / 25) + vExtra).ToString();
    impquidprcTextBox.Text = "0.00" ; //Free
    CalculateBase();

}
private void txtQtyTeacher_Leave(object sender, EventArgs e)
{
    CalculateBase();

}
private void txtBYear_Leave(object sender, EventArgs e)
{
    if (GetBookPricing())
    {
        CalculateBase();
        CalculateOptions();
    }


}
private void wghtTextBox_Leave(object sender, EventArgs e)
{
    Validate();
}
private void hallpqtyTextBox_Leave(object sender, EventArgs e)
{

    CalculateOptions();

}
private void bmarkqtyTextBox_Leave(object sender, EventArgs e)
{
    CalculateOptions();
}
private void vpaqtyTextBox_Leave(object sender, EventArgs e)
{

    CalculateOptions();

}
private void contryearTextBox_Leave(object sender, EventArgs e)
{
    this.Validate();
    GetOptionPricing();
    CalculateOptions();
}
private void vpbqtyTextBox_Leave(object sender, EventArgs e)
{
    CalculateOptions();
}
private void idpouchqtyTextBox_Leave(object sender, EventArgs e)
{
    CalculateOptions();
}
private void stttitpgqtyTextBox_Leave(object sender, EventArgs e)
{
    CalculateOptions();
}
private void duraglzqtyTextBox_Leave(object sender, EventArgs e)
{
    CalculateOptions();
}
private void wallchqtyTextBox_Leave(object sender, EventArgs e)
{
    CalculateOptions();
}
private void typesetqtyTextBox_Leave(object sender, EventArgs e)
{
    CalculateOptions();
}
private void txtmisc_Leave(object sender, EventArgs e)
{
    txtmisc.Text = txtmisc.ConvertToDecimal().ToString("0.00");
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
private void dp1TextBox_Leave(object sender, EventArgs e)
{
    if (Validate())
    {
        erldiscamtTextBox.Text = "-" + (dp1TextBox.ConvertToDecimal() * lblsbtot.ConvertToDecimal()).ToString("0.00");

        CalculateOptions();
    }
}
private void erldiscamtTextBox_Leave(object sender, EventArgs e)
{
    erldiscamtTextBox.Text = erldiscamtTextBox.ConvertToDecimal().ToString("0.00");
    CalculateOptions();
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
private void shpphndlTextBox_Leave(object sender, EventArgs e)
{
    txtShipping.Text = txtShipping.ConvertToDecimal().ToString("0.00");
    CalculateOptions();
}       
private void txtAdditionChrg_Leave(object sender, EventArgs e)
{
    txtAdditionChrg.Text = txtAdditionChrg.ConvertToDecimal().ToString("0.00");
    CalculateOptions();
}
private void txtShipping_Leave(object sender, EventArgs e)
{
    txtShipping.Text = txtShipping.ConvertToDecimal().ToString("0.00");
    CalculateOptions();
}
private void txtImpGuideQty_Leave(object sender, EventArgs e)
{
    txtImpGuideQty.Text = txtImpGuideQty.ConvertToDecimal().ToString("0.00");
    CalculateOptions();
}
private void threeclrCheckBox_Click_1(object sender, EventArgs e)
{
    if (threeclrCheckBox.Checked)
    {
        fourclrCheckBox.Checked = false;
        twoclrCheckBox.Checked = false;
        oneclrCheckBox.Checked = false;
    }
    CoverCalc();
}
private void fourclrCheckBox_Click_1(object sender, EventArgs e)
{
    if (fourclrCheckBox.Checked)
    {
        threeclrCheckBox.Checked = false;
        twoclrCheckBox.Checked = false;
        oneclrCheckBox.Checked = false;
    }
    CoverCalc();
}
private void twoclrCheckBox_Click_1(object sender, EventArgs e)
{
    if (twoclrCheckBox.Checked)
    {
        threeclrCheckBox.Checked = false;
        fourclrCheckBox.Checked = false;
        oneclrCheckBox.Checked = false;
    }
    CoverCalc();
}
private void oneclrCheckBox_Click_1(object sender, EventArgs e)
{
    if (oneclrCheckBox.Checked)
    {
        threeclrCheckBox.Checked = false;
        fourclrCheckBox.Checked = false;
        twoclrCheckBox.Checked = false;
    }
    CoverCalc();
}
private void dp1TextBox_Leave_1(object sender, EventArgs e)
{
            if (dp1TextBox.Text.Trim()=="")
            {
                dp1TextBox.Text = "0";
            }      
    CalculateOptions();
}

private void btnCreateInvoice_Click(object sender, EventArgs e)
{
            //Check if invoice exist to see what to do.
            qtedateDateBox.DateValue = DateTime.Now;
            qtedateDateBox.Date = qtedateDateBox.DateValue.ToString();
            var saveResult = Save();
            if (saveResult.IsError)
            {
                return;
            }
            CreateInvoice();
}

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

       
        private void salesTabControl_Enter(object sender, EventArgs e)
        {
            try
            {
                this.paymntTableAdapter.Fill(dsMInvoice.paymnt,Invno);
                SetCrudButtons();

            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message);
                ex.ToExceptionless()
                    .MarkAsCritical()
                    .AddObject(ex)
                    .Submit();
            }
        }

        private void btnSavePayment_Click(object sender, EventArgs e)
        {
            SavePayment();
        }

        private void btnNewPayment_Click(object sender, EventArgs e)
        {
            NewPayment();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPayment();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelPayment();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePayment();
        }

        private void reportViewer1_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            try { reportViewer1.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
        }

        private void btnPrntInvoice_Click(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

       


        //nothing below here
    }
}
