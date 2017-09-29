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
using Mbc5.Classes;
using System.Linq;
namespace Mbc5.Forms.MemoryBook {
    public partial class frmBids : BaseClass.frmBase, INotifyPropertyChanged
    {
        private bool startup = true;
        public frmBids(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
        }
        public frmBids(UserPrincipal userPrincipal,string schcode) : base(new string[] { "SA","Administrator","MbcCS" },userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Schcode = schcode;

        }
       

		private void bidsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			this.Validate();
			this.bidsBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.dsBids);

		}

        private void frmBids_Load_1(object sender, EventArgs e)
        {

            lblPCEach.DataBindings.Add("Text", this, "PrcEa", false, DataSourceUpdateMode.OnPropertyChanged);//bind 
            lblPCTotal.DataBindings.Add("Text", this, "PrcTot", false, DataSourceUpdateMode.OnPropertyChanged);//bind
            Fill();
            startup = false;
            CalculateEach();
            BookCalc();
            txtBYear.Focus();
          
        }
     

        #region "Properties"
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private Decimal nPrcTot = 0;
        private Decimal nPrcEach = 0;
        private UserPrincipal ApplicationUser { get; set; }
        private string Schname { get; set;}
        public Decimal PrcTot
        {
            get { return nPrcTot; }
            set
            {
                nPrcTot = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("PrcTot"));
            }
        }
        public Decimal PrcEa
        {
            get { return nPrcEach; }
            set
            {
                nPrcEach = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("PrcEach"));
            }
        }
        public List<Price> Pricing { get; set; }
        public BookOptionPrice BookOptionPricing { get; set; }
        public string CurPriceYr { get; set; } = null;
        private bool StartUp { get; set; }
        #endregion
        #region "Methods"
        private void Fill()
        {
            if (Schcode != null)
            {
                this.custTableAdapter.Fill(this.dsBids.cust, this.Schcode);
                this.bidsTableAdapter.Fill(this.dsBids.bids, this.Schcode);
                DataRowView current = (DataRowView)bidsBindingSource.Current;
                this.Schname = current["schname"].ToString();

            }
            CalculateEach();
            BookCalc();
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
      
       
        //Sales
        private bool SaveBid()
        {
            bool retval = false;
            if (bidsBindingSource.Count > 0)
            {
                if (ValidBid())
                {

                    try
                    {
                        this.bidsBindingSource.EndEdit();
                        bidsTableAdapter.Update(dsBids.bids);
                        //must refill so we get updated time stamp so concurrency is not thrown
                        this.Fill();
                      
                        retval = true;
                    }
                    catch (DBConcurrencyException ex1)
                    {
                        DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsBids.bidsRow)(ex1.Row), ref dsBids);
                        if (result == DialogResult.Yes)
                        {
                            Save();
                        }
                        else
                        {
                            retval = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        retval = false;
                        MessageBox.Show("Sales record failed to update:" + ex.Message);
                        this.Log.Error(ex, "Record sales record failed to update:" + ex.Message);
                    }
                }
                else { retval = false; }
            }
            return retval;
        }
        private bool DeleteBid()
        {
            bool retval = true;
            DialogResult messageResult = MessageBox.Show("This will delete the selected bid record.  Do you want to proceed?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (messageResult == DialogResult.Yes)
            {
                var sqlQuery = new SQLQuery();
                var queryString = "Delete  From bids where Id=@Id ";
                SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Id",lblId.Text)
            };
                var result = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, queryString, parameters);
                if (result == 1)
                {
                 
                    this.Fill();
                }
                else { retval = false; }
            }
            if (String.IsNullOrEmpty(lblId.Text) || lblId.Text == "000")
            {
                this.DisableControls(this);
              //  EnableControls(this.txtInvoSrch);
               
            }
            return retval;
        }
        private void CalculateEach()
        {
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
                if (bidsBindingSource.Count > 0)
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

                    if (String.IsNullOrEmpty(txtPriceOverRide.Text) || txtPriceOverRide.Text == "0.00" || txtPriceOverRide.Text == "0")
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


                    BookCalc();
                }
            }

        }
        private void CalcInk()
        {


        }
        private void BookCalc()
        {
            if (!startup)
            {
                if (bidsBindingSource.Count > 0)
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
                            Casebind = BookOptionPricing.Case * numberOfCopies;
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
                            Yir = (BookOptionPricing.Yir * numberOfCopies);
                            lblYir.Text = Yir.ToString();
                        }
                        else
                        {
                            lblYir.Text = "0.00";
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
                        {
                            lblStoryAmt.Text = "0.00";
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




                        decimal SubTotal = (BookTotal + HardBack + Casebind + Perfectbind + Spiral + SaddleStitch + Professional + Convenient + Yir + Story + Gloss + Laminationsft + SpecCvrTot + FoilTot + ClrPgTot + MiscTot + Desc1Tot + Desc3Tot + Desc4Tot);

                        lblsubtot.Text = SubTotal.ToString("c");
                        //calculate after subtotal
                        decimal disc1 = 0;
                        decimal disc2 = 0;
                        decimal disc3 = 0;
                        decimal msTot = 0;
                        decimal persTot = 0;

                        vParseResult = decimal.TryParse(lbldisc1.Text, out disc1);
                        vParseResult = decimal.TryParse(lbldisc2.Text, out disc2);
                        vParseResult = decimal.TryParse(lblDisc3.Text, out disc3);
                        vParseResult = decimal.TryParse(lblMsTot.Text, out msTot);
                        vParseResult = decimal.TryParse(lblperstotal.Text, out persTot);
                        lblFinalTotPrc.Text = (SubTotal + disc1 + disc2 + disc3 + msTot + persTot).ToString("c");
                        txtFinalbookprc.Text = ((SubTotal + disc1 + disc2 + disc3 + msTot + persTot) / numberOfCopies).ToString("c");
                        //other charges and credies
                        decimal credit1 = 0;
                        decimal credit2 = 0;
                        decimal otherchrg1 = 0;
                        decimal otherchrg2 = 0;
                        vParseResult = decimal.TryParse(txtCredits.Text, out credit1);
                        vParseResult = decimal.TryParse(txtCredits2.Text, out credit2);
                        vParseResult = decimal.TryParse(txtOtherChrg.Text, out otherchrg1);
                        vParseResult = decimal.TryParse(txtOtherChrg2.Text, out otherchrg2);
                        lbladjbef.Text = (SubTotal + disc1 + disc2 + disc3 + msTot + persTot + credit1 + credit2 + otherchrg1 + otherchrg2).ToString("c");

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


            SqlConnection conn = new SqlConnection(Properties.Settings.Default.Mbc5ConnectionString);
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
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.Mbc5ConnectionString);
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

      

        //General
        public override bool Save()
        {
            //txtModifiedBy.Text = this.ApplicationUser.id;
           
            bool retval = true;
            switch (tabBids.SelectedIndex)
            {
                case 0:
            
                    {
                        bidsBindingSource.EndEdit();
                        bidsTableAdapter.Update(dsBids.bids);
                        break;
                    }



            }
            return retval;
        }
        public override bool Add()
        {
            //txtModifiedBy.Text = this.ApplicationUser.id;
            //txtModifiedByInv.Text = this.ApplicationUser.id;
            //txtModifiedByInvdetail.Text = this.ApplicationUser.id;
            //txtModifiedByPay.Text = this.ApplicationUser.id;
            switch (tabBids.SelectedIndex)
            {
                case 0:
               
                    {
                        bidsBindingSource.AddNew();

                        break;
                    }


               

            }
            return true;
        }
        public override void Delete()
        {
            //txtModifiedBy.Text = this.ApplicationUser.id;
     
            switch (tabBids.SelectedIndex)
            {
                case 0:
                case 1:
                    {
                        DialogResult dialogResult =MessageBox.Show("This will remove the record permanently. Proceed? ", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                        if (dialogResult == DialogResult.Yes)
                        {
                            int vid;
                            var result = int.TryParse(lblId.Text, out vid);
                            if (result)
                            {
                                bidsTableAdapter.Delete(vid);
                            }
                            

                        }
                        break;
                    }
               

            }
        }
        public override void Cancel()
        {
           
            bidsBindingSource.CancelEdit();
         
        }

        #endregion
        #region Validation
       
        private bool ValidatePageCount()
        {
            bool retval = true;
            errorProvider1.SetError(txtNoPages, "");
            if (String.IsNullOrEmpty(txtNoPages.Text))
            {

                retval = false;

            }
            int count;
            var result = int.TryParse(txtNoPages.Text, out count);
            //non numeric
            if (!result)
            {
                errorProvider1.SetError(txtNoPages, "Please enter a number.");
                retval = false;
            }
            //Check over 360
            if (count > 360)
            {
                errorProvider1.SetError(txtNoPages, "Calculations are limited to 360 pages!");
                retval = false;
            }
            //check divisible by 4
            var mod = (count % 4);
            if (mod != 0 || count < 12)
            {
                errorProvider1.SetError(txtNoPages, "Pages must be 12 or greater and divisible by 4!");
                retval = false;
            }

            //If CaseBind
            if (chkCaseBind.Checked && (count < 40 || count > 120))
            {
                errorProvider1.SetError(txtNoPages, "Case Bind pages must between 40 and 120!");
                retval = false;
            }

            if (count > 84 && chkSaddlStitch.Checked)
            {
                errorProvider1.SetError(txtNoPages, "Saddle Stitch must be 84 pages or less!");
                retval = false;
            }

            if (retval == false)
            {
                lblBookTotal.Text = (0 * 0).ToString("c");
                lblProftotalPrc.Text = (0 * 0).ToString("c");
                lblPriceEach.Text = (0 * 0).ToString("c");
                lblprofprice.Text = 0.ToString("c");
            }

            return retval;
        }
        private bool ValidateCopies()
        {

            bool retval = true;

            errorProvider1.SetError(txtNocopies, "");
            int count;
            var result = int.TryParse(txtNocopies.Text, out count);
            //non numeric
            if (!result || count == 0)
            {
                errorProvider1.SetError(txtNocopies, "Please enter a number.");
                retval = false;
            }
            if (count > 1800)
            {
                errorProvider1.SetError(txtNocopies, "Number exceeds maximun quantity. Contact your supervisor.");
                retval = false;
            }
            if (retval == false)
            {
                lblBookTotal.Text = (0 * 0).ToString("c");
                lblProftotalPrc.Text = (0 * 0).ToString("c");
                lblPriceEach.Text = (0 * 0).ToString("c");
                lblprofprice.Text = 0.ToString("c");
            }
            return retval;

        }
        private bool ValidBid()
        {
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
      
       
        private void txtBYear_Validating(object sender, CancelEventArgs e)
        {

            errorProvider1.SetError(txtBYear, "");
            int numeral;
            var result = int.TryParse(txtBYear.Text, out numeral);
            //non numeric
            if (!result || numeral == 0 || String.IsNullOrEmpty(txtBYear.Text))
            {
                errorProvider1.SetError(txtBYear, "Please enter a  base price year.");
                e.Cancel = true;
                return;
            }


        }

        private void txtYear_Validating(object sender, CancelEventArgs e)
        {

            errorProvider1.SetError(txtYear, "");
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

                errorProvider1.SetError(txtSpecCvrEa, "");
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

                errorProvider1.SetError(txtFoilAd, "");
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

                errorProvider1.SetError(txtDisc, "");
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

                errorProvider1.SetError(txtDp2, "");
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

                errorProvider1.SetError(txtMsQty, "");
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

                errorProvider1.SetError(perscopiesTextBox, "");
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

                errorProvider1.SetError(persamountTextBox, "");
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

                errorProvider1.SetError(txtNumtoPers, "");
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

                errorProvider1.SetError(txtfreebooks, "");
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

                errorProvider1.SetError(txtClrTot, "");
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

                errorProvider1.SetError(txtMisc, "");
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

                errorProvider1.SetError(txtDesc1amt, "");
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

                errorProvider1.SetError(txtDesc3tot, "");
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

                errorProvider1.SetError(txtDesc4tot, "");
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

                errorProvider1.SetError(txtCredits, "");
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

                errorProvider1.SetError(txtCredits2, "");
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

                errorProvider1.SetError(txtOtherChrg, "");
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

                errorProvider1.SetError(txtOtherChrg2, "");
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

                errorProvider1.SetError(saletaxTextBox, "");
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
                errorProvider1.SetError(txtPriceOverRide, "");
                if (!String.IsNullOrEmpty(txtPriceOverRide.Text))
                {
                    string price = txtPriceOverRide.Text.Replace("$", "");//must strip dollar sign
                    decimal val;
                    var result = decimal.TryParse(price, out val);
                    //non numeric
                    if (!result)
                    {
                        errorProvider1.SetError(txtPriceOverRide, "Please enter a decimal amount.");
                        e.Cancel = true;

                    }
                }
            }
        }

        private void txtreqcoverCopies_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtreqcoverCopies.Text))
            {

                errorProvider1.SetError(txtreqcoverCopies, "");
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

        private void frmBids_Paint(object sender, PaintEventArgs e)
        {
            try { this.Text = "MBC Customer-" + this.Schname.Trim() + " (" + this.Schcode.Trim() + ")"; }
            catch
            {

            }
        }

        private void txtNocopies_Leave(object sender, EventArgs e)
        {
            CalculateEach();
            BookCalc();
        }

        private void txtNoPages_Leave(object sender, EventArgs e)
        {
            CalculateEach();
            BookCalc();
        }

        private void txtBYear_Leave(object sender, EventArgs e)
        {
            CalculateEach();
            BookCalc();
        }

        private void txtPriceOverRide_Leave(object sender, EventArgs e)
        {
            CalculateEach();
            BookCalc();
        }

        private void chkPromo_Click(object sender, EventArgs e)
        {
            CalculateEach();
            BookCalc();
        }

        private void chkHardBack_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkCaseBind_CheckedChanged(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkPerfBind_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkSpiral_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkSaddlStitch_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkProfessional_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkConv_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkYir_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkStory_CheckedChanged(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkAllClr_CheckedChanged(object sender, EventArgs e)
        {
            GetBookPricing();
            CalculateEach();
            BookCalc();
        }

        private void chkGlossLam_CheckedChanged(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkMLaminate_CheckedChanged(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtClrTot_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtMisc_Leave(object sender, EventArgs e)
        {
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

        private void txtDisc_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtDp2_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void dp3ComboBox_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void cmbYrDiscountAmt_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateEach();
            BookCalc();
        }

       
    }
}
