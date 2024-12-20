﻿using System;
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
using BindingModels;
using BaseClass;
using BaseClass.Core;
using Microsoft.Reporting.WinForms;
using Mbc5.Dialogs;
using Exceptionless;
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
       
        private void SetConnectionString()
        {
            
            this.FormConnectionString = frmMain.AppConnectionString;
            this.custTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
           

        }
        private void bidsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			//this.Validate();
			//this.bidsBindingSource.EndEdit();
            this.Save();
			

		}
        public frmMain frmMain { get; set; }

        private void frmBids_Load_1(object sender, EventArgs e)
        {
           this.frmMain =(frmMain) this.MdiParent;
            this.SetConnectionString();
            //this.custTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            //this.bidsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            lblPCEach.DataBindings.Add("Text", this, "PrcEa", false, DataSourceUpdateMode.OnPropertyChanged);//bind 
            lblPCTotal.DataBindings.Add("Text", this, "PrcTot", false, DataSourceUpdateMode.OnPropertyChanged);//bind
            Fill();
       
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
        private string SchoolZipCode { get; set; }
        public Decimal TaxRate { get; set; } = 0;
        public Decimal SalesTax { get; set; } = 0;
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

        public override void Fill()
        {
            if (Schcode != null)
            {
				try {
					this.custTableAdapter.Fill(this.dsBids.cust, this.Schcode);
					
					this.bidsTableAdapter.Fill(this.dsBids.bids, this.Schcode);
                    
                    
                }
                catch(Exception ex) {
					MbcMessageBox.Error(ex.Message, "");
				}
            }
            if (bidsBindingSource.Count == 0)
            {
                DisableControls(this.tabBids);
                EnableControls(bidsBindingNavigator);
            }
            else {
                CalculateEach();
               BookCalc(); }
            try
            {
                this.Schname = ((DataRowView)custBindingSource.Current).Row["schname"].ToString().Trim();
                this.SchoolZipCode = ((DataRowView)this.custBindingSource.Current).Row["schzip"].ToString().Trim().Substring(0, 5);
              
            }
            catch(Exception ex)
            {
                //MbcMessageBox.Error(ex.Message, "");
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
        private ApiProcessingResult CopyToSales()
        {
            var processingResult = new ApiProcessingResult();
               int InvNum = this.frmMain.GetNewInvno();
                if (InvNum < 1)
                {
                    
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("There was an error getting an new invoice number", "There was an error getting an new invoice number",""));
                    return processingResult;
                }
                DataRowView drview = (DataRowView)this.bidsBindingSource.Current;
                int vId = (int)drview["id"];
                var sqlclient = new SQLCustomClient();
                sqlclient.AddParameter("@id", vId);
                sqlclient.AddParameter("@Invno", InvNum);

                string cmdText = @"INSERT INTO [dbo].[quotes]
                            ([invno],[schcode],[booktype],[qtedate],[contryear],[nopages],[nocopies],[book_ea]

                            ,[book_price],[pryn],[prof],[coyn],[conven],[specea],[speccvr],[scovrde],[layn],[laminate]

                            ,[peyn],[perfbind],[foilck],[foilamt],[insck],[insamt],[spirck],[spiramt],[hdbky_n],[hardback]

                            ,[casey_n],[caseamt],[customy_n],[customized],[misc],[mdesc],[sbtot],[dc1],[dp1],[disc1],[dc2],[dp2]

                            ,[disc2],[dp3desc],[dp3],[disc3],[dp4],[disc4],[cred_etc],[adjbef],[adjaftr],[fbkprc],[ftotprc]

                            ,[source],[xtrabkno],[xtrabkprc],[desc1],[desc1tot],[desc2],[desc2tot],[ponum],[newprice]

                             ,[allclrck],[allclramt],[inkclr],[foiladamt],[desc3],[desc3tot],[desc4],[desc4tot],[clrpgdesc]
							 ,[clrpgtot],[glspaper],[glsamt] ,[bpovrde],[bpyear],[themck],[themamt],[yirschool],[story],[supplements]
							 
				,[yiramt],[storyamt],[suppamt],[persamount],[perstotal],[perscopies],[oursupp],[oursuppamt],[ourovrride]

                            ,[dp1desc] ,[myovrride],[profovrride],[conovrride],[themovrride],[cbovrride],[spiovrride],[pbovrride]

                            ,[yirsovrride],[ourstyovrride],[laminateovrride],[foilyearovrride],[sdlstich],[sdlstichamt],[copiesovride]

                            ,[perpp],[agreerec],[basicamoun],[peramount],[oprcperbk],[oprcperbk2],[agreedte],[onlinecuto],[msstanqty]

                            ,[msstandtot],[fldtype],[isfolder],[priceovrd],[mlaminationamt],[mlamination],[opinkpers],[opfoilpers]

                            ,[opinkpersamt],[opfoilpersamt],[oppicpers],[oppicpersamt],[opcustom],[opcustomamt],[opfoiltxtamt],[opfoiltxt]

                            ,[opink] ,[yrdiscount] ,[luvlines],[yrdiscountamt],[luvlineamt],[fullad],[fulladamt],[halfad],[halfadamt]

                            ,[quarterad] ,[quarteradamt],[eighthad],[eighthadamt],[adline],[cred_etc2],[desc22],[adjaftr2],[desc22tot]


                            ,[prcor] ,[adcuto],[webonly],[freebooks] ,[basicpp],[IconCopies],[IconAmt] ,[extrchg],[schooltax]


                            ,[schooltaxrate],[donotchargeschoolsalestax]
                            
                           )
                   Select @Invno AS Invno,[schcode],[booktype],[qtedate],[contryear],[nopages],[nocopies],[book_ea],

                            [book_price],[pryn],[prof],[coyn],[conven],[specea],[speccvr] ,[scovrde],[layn],[laminate]

                           ,[peyn],[perfbind],[foilck],[foilamt],[insck],[insamt],[spirck],[spiramt],[hdbky_n],[hardback]

                            ,[casey_n],[caseamt],[customy_n],[customized],[misc],[mdesc],[sbtot],[dc1],[dp1],[disc1],[dc2],[dp2]

                            ,[disc2],[dp3desc],[dp3],[disc3],[dp4],[disc4],[cred_etc],[adjbef],[adjaftr],[fbkprc],[ftotprc]

                            ,[source],[xtrabkno],[xtrabkprc],[desc1],[desc1tot],[desc2],[desc2tot],[ponum],[newprice]

                            ,[allclrck],[allclramt],[inkclr],[foiladamt],[desc3],[desc3tot] ,[desc4],[desc4tot],[clrpgdesc]
							,[clrpgtot],[glspaper],[glsamt],[bpovrde],[bpyear],[themck],[themamt],[yirschool],[story],[supplements]
							,[yiramt],[storyamt],[suppamt],[persamount] ,[perstotal],[perscopies],[oursupp],[oursuppamt],[ourovrride]
                           ,[dp1desc],[myovrride],[profovrride],[conovrride],[themovrride],[cbovrride],[spiovrride],[pbovrride]                     

                            ,[yirsovrride],[ourstyovrride],[laminateovrride],[foilyearovrride],[sdlstich],[sdlstichamt],[copiesovride]
                            
                            ,[perpp],[agreerec],[basicamoun],[peramount],[oprcperbk],[oprcperbk2],[agreedte],[onlinecuto],[msstanqty]


                            ,[msstandtot],[fldtype],[isfolder],[priceovrd],[mlaminationamt],[mlamination],[opinkpers],[opfoilpers]


                            ,[opinkpersamt],[opfoilpersamt],[oppicpers],[oppicpersamt],[opcustom],[opcustomamt],[opfoiltxtamt],[opfoiltxt] 

                            ,[opink],[yrdiscount],[luvlines],[yrdiscountamt],[luvlineamt],[fullad] ,[fulladamt],[halfad],[halfadamt]


                           ,[quarterad],[quarteradamt],[eighthad],[eighthadamt],[adline],[cred_etc2],[desc22],[adjaftr2],[desc22tot]


                            ,[prcor],[adcuto],[webonly],[freebooks],[basicpp],[IconCopies],[IconAmt],[extrchg],[schooltax],[schooltaxrate]      
							
							 ,[donotchargeschoolsalestax]
                        FROM [Mbc5].[dbo].[bids] where id=@id";
                sqlclient.CommandText(cmdText);
                string quoteInsert;
                try
                {
                    var quoteInsertResult = sqlclient.Insert();
                    if (quoteInsertResult.IsError)
                    {
                    ExceptionlessClient.Default.CreateLog("Insert Error Copy To Sales")
                      .AddObject(quoteInsertResult)
                      .Submit();
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError("There was an error creating a the sales record.", "There was an error creating a the sales record.",""));
                        return processingResult;
                    }
                }
                catch (Exception ex)
                {

                   
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("There was an error creating a the sales record.", "There was an error creating a the sales record.", ""));
                return processingResult;
            };

                sqlclient.ClearParameters();

                string vProdNo = frmMain.GetProdNo();

                ;
                if (string.IsNullOrEmpty(vProdNo))
                {
               
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to get a production number", "Failed to get a production number", ""));
                return processingResult;
            }
                sqlclient.AddParameter("@Invno", InvNum);
                sqlclient.AddParameter("@Schcode", this.Schcode);
                sqlclient.AddParameter("@ProdNo", vProdNo);
                sqlclient.AddParameter("@Contryear", txtBYear.Text);
                sqlclient.AddParameter("@Company", "MBC");

                string strQuery = "INSERT INTO [dbo].[produtn](Invno,Schcode,Contryear,Prodno,Company)  VALUES (@Invno,@Schcode,@Contryear,@ProdNo,@Company)";
                sqlclient.CommandText(strQuery);
                try
                {
                    var prodResult = sqlclient.Insert();
                    if (prodResult.IsError)
                    {
                       ExceptionlessClient.Default.CreateLog("Insert Error")
                        .AddObject(prodResult)
                        .Submit();
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError("Failed to insert production record.", "Failed to insert production record.", ""));
                    return processingResult;
                }
                }
                catch (Exception ex)
                {
                ex.ToExceptionless()
                 .AddObject(ex)
                 .Submit();
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to insert production record.", "Failed to insert production record.", ""));
                return processingResult;
            }

                sqlclient.ClearParameters();

                var vCoverNumber = frmMain.GetCoverNumber();
                var vInstructions = GetInstructions();
                sqlclient.AddParameter("@Invno", InvNum);
                sqlclient.AddParameter("@Schcode", this.Schcode);
                sqlclient.AddParameter("@Specovr", vCoverNumber);
                sqlclient.AddParameter("@Specinst", vInstructions);
                sqlclient.AddParameter("@Company", "MBC");
                strQuery = "Insert into Covers (schcode,invno,company,specovr,Specinst) Values(@Schcode,@Invno,@Company,@Specovr,@Specinst)";
                sqlclient.CommandText(strQuery);

                try
                {
                    var coverinsertResult = sqlclient.Insert();
                    if (coverinsertResult.IsError)
                    {
                    ExceptionlessClient.Default.CreateLog("Failed to insert covers record.")
                     .AddObject(coverinsertResult)
                     .Submit();
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError("Failed to insert covers record.", "Failed to insert covers record.", ""));
                    return processingResult;
                }
                }
                catch (Exception ex)
                {
                ex.ToExceptionless()
                 .AddObject(ex)
                 .Submit();
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to insert covers record.", "Failed to insert covers record.", ""));
                return processingResult;
            }
               
            processingResult.Tag = "A sales record with Invoice# " + InvNum + " has been created.";
            return processingResult;
          
        }
        private ApiProcessingResult PrintQuote()
        {
            var processingResult = new ApiProcessingResult();
            var vBidDetails = new List<BidInvoiceDetail>();
            var vrow = new BidInvoiceDetail();
            if (chkAllClr.Checked)
            {
                vrow.Description = "Color book with " + txtNoPages.Text + " Pages " + txtNocopies.Text + " Copies";
                vrow.Price = Convert.ToDecimal(lblBookTotal.Text);
                vrow.DiscountPercentage = "";

            }
            else
            {
                vrow.Description = "Black and White book with " + txtNoPages.Text + " Pages " + txtNocopies.Text + " Copies";
                vrow.Price = Convert.ToDecimal(lblBookTotal.Text);
                vrow.DiscountPercentage = "";
            }
            vBidDetails.Add(vrow);
            if (chkHardBack.Checked)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Hard Back (sewn)",
                    Price = Convert.ToDecimal(lblHardbackAmt.Text)

                };
                vBidDetails.Add(vrow);
            }
            if (chkCaseBind.Checked)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Case Binding (glued)",
                    Price = Convert.ToDecimal(lblCaseamt.Text)

                };
                vBidDetails.Add(vrow);
            }
            if (chkPerfBind.Checked)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Perfect Bind",
                    Price = Convert.ToDecimal(lblPerfbindAmt.Text)

                };
                vBidDetails.Add(vrow);
            }
            if (chkSpiral.Checked)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Spiral Bind",
                    Price = Convert.ToDecimal(lblSpiralAmt.Text)

                };
                vBidDetails.Add(vrow);
            }
            if (chkSaddlStitch.Checked)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Soft Cover Stapled",
                    Price = Convert.ToDecimal(lblSaddleAmt.Text)

                };
                vBidDetails.Add(vrow);
            }
            if (chkProfessional.Checked)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Professional",
                    Price = Convert.ToDecimal(lblProfAmt.Text)

                };
                vBidDetails.Add(vrow);
            }

            if (chkConv.Checked)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Convenient",
                    Price = Convert.ToDecimal(lblConvAmt.Text)

                };
                vBidDetails.Add(vrow);
            }
            if (chkYir.Checked)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Flashbax",
                    Price = Convert.ToDecimal(lblYir.Text)

                };
                vBidDetails.Add(vrow);
            }


            if (chkGlossLam.Checked)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Gloss Laminate",
                    Price = Convert.ToDecimal(lblLaminateAmt.Text)

                };
                vBidDetails.Add(vrow);
            }
            if (chkMLaminate.Checked)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Matte Laminate",
                    Price = Convert.ToDecimal(lblMLaminateAmt.Text)

                };
                vBidDetails.Add(vrow);
            }
            decimal vCoverTotal = 0;
            decimal.TryParse(lblSpeccvrtot.Text, out vCoverTotal);
            if (vCoverTotal > 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Special Cover",
                    Price = Convert.ToDecimal(lblSpeccvrtot.Text)

                };
                vBidDetails.Add(vrow);
            }
            decimal vFoilTotal = 0;
            decimal.TryParse(txtFoilAd.Text, out vFoilTotal);
            if (vFoilTotal > 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Foil (Additional)",
                    Price = Convert.ToDecimal(txtFoilAd.Text)

                };
                vBidDetails.Add(vrow);
            }
            decimal vclrDiscount = 0;
            decimal.TryParse(txtClrTot.Text, out vclrDiscount);
            if (vclrDiscount > 0 || vclrDiscount < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = txtClrDesc.Text,
                    Price = Convert.ToDecimal(txtClrTot.Text)

                };
                vBidDetails.Add(vrow);
            }
            decimal vMisc = 0;
            decimal.TryParse(txtMisc.Text, out vMisc);
            if (vMisc > 0 || vMisc < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = txtMdesc.Text,
                    Price = Convert.ToDecimal(txtMisc.Text)

                };
                vBidDetails.Add(vrow);
            }
            decimal vMisc2 = 0;
            decimal.TryParse(txtDesc1amt.Text, out vMisc2);
            if (vMisc2 > 0 || vMisc2 < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = txtDesc1.Text,
                    Price = Convert.ToDecimal(txtDesc1amt.Text)

                };
                vBidDetails.Add(vrow);
            }
            decimal vMisc3 = 0;
            decimal.TryParse(txtDesc3tot.Text, out vMisc3);
            if (vMisc3 > 0 || vMisc3 < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = textBox5.Text,
                    Price = Convert.ToDecimal(txtDesc3tot.Text)

                };
                vBidDetails.Add(vrow);
            }
            decimal vMisc4 = 0;
            decimal.TryParse(txtDesc4tot.Text, out vMisc4);
            if (vMisc4 > 0 || vMisc4 < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = txtDesc4.Text,
                    Price = Convert.ToDecimal(txtDesc4tot.Text)

                };
                vBidDetails.Add(vrow);
            }
            decimal vdisc1amount = 0;
            decimal.TryParse(lbldisc1amount.Text, out vdisc1amount);
            if (vdisc1amount > 0 || vdisc1amount < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = dp1descComboBox.SelectedItem == null ? "" : dp1descComboBox.SelectedItem.ToString(),
                    Price = Convert.ToDecimal(lbldisc1amount.Text),
                    DiscountPercentage = txtDisc.Text

                };
                vBidDetails.Add(vrow);
            }
            decimal vdisc2amount = 0;
            decimal.TryParse(lbldisc2amount.Text, out vdisc2amount);
            if (vdisc2amount > 0 || vdisc2amount < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Full pay with submission",
                    Price = Convert.ToDecimal(lbldisc2amount.Text),
                    DiscountPercentage = txtDp2.Text

                };
                vBidDetails.Add(vrow);
            }
            decimal vOtherdiscamt = 0;
            decimal.TryParse(otherdiscamt.Text, out vOtherdiscamt);
            if (vOtherdiscamt > 0 || vOtherdiscamt < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = txtDp3Desc.Text,
                    Price = Convert.ToDecimal(otherdiscamt.Text),
                    DiscountPercentage = dp3ComboBox.SelectedItem == null ? "0" : dp3ComboBox.SelectedItem.ToString().Trim()

                };
                vBidDetails.Add(vrow);
            }

            if (chkMsStandard.Checked)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "My Story With Picture Personalization",
                    Price = Convert.ToDecimal(lblMsTot.Text),
                    DiscountPercentage = ""

                };
                vBidDetails.Add(vrow);
            }
            decimal vperstotal = 0;
            decimal.TryParse(lblperstotal.Text, out vperstotal);
            if (vperstotal > 0 || vperstotal < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Personalization",
                    Price = Convert.ToDecimal(lblperstotal.Text),
                    DiscountPercentage = ""

                };
                vBidDetails.Add(vrow);
            }
            decimal vIconTot = 0;
            decimal.TryParse(lblIconTot.Text, out vIconTot);
            if (vIconTot > 0 || vIconTot < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = "Icons",
                    Price = Convert.ToDecimal(lblIconTot.Text),


                };
                vBidDetails.Add(vrow);
            }
            //no tax
            decimal vCredit = 0;
            decimal.TryParse(txtCredits.Text, out vCredit);
            if (vCredit > 0 || vCredit < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = cred_etcTextBox.Text + " (No Tax Calculated)",
                    Price = Convert.ToDecimal(txtCredits.Text),


                };
                vBidDetails.Add(vrow);
            }
            decimal vCredit2 = 0;
            decimal.TryParse(txtCredits2.Text, out vCredit2);
            if (vCredit2 > 0 || vCredit2 < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = cred_etcTextBox1.Text + " (No Tax Calculated)",
                    Price = Convert.ToDecimal(txtCredits2.Text),


                };
                vBidDetails.Add(vrow);
            }
            decimal vOtherChrg = 0;
            decimal.TryParse(txtOtherChrg.Text, out vOtherChrg);
            if (vOtherChrg > 0 || vOtherChrg < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = textBox5.Text + " (No Tax Calculated)",
                    Price = Convert.ToDecimal(txtOtherChrg.Text),


                };
                vBidDetails.Add(vrow);
            }
            decimal vOtherChrg2 = 0;
            decimal.TryParse(txtOtherChrg2.Text, out vOtherChrg2);
            if (vOtherChrg2 > 0 || vOtherChrg2 < 0)
            {
                vrow = new BidInvoiceDetail()
                {
                    Description = desc22TextBox.Text + " (No Tax Calculated)",
                    Price = Convert.ToDecimal(txtOtherChrg2.Text),


                };
                vBidDetails.Add(vrow);
            }


            BidInvoiceDetailBindingSource.DataSource = vBidDetails;
            try
            {
                ReportParameter rp0 = new ReportParameter("ReportType", chkPrntAsInvoice.Checked.ToString());

                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp0 });



                Cursor.Current = Cursors.WaitCursor;
                ReportDataSource rds = new ReportDataSource("dsCust", custBindingSource);
                ReportDataSource rds1 = new ReportDataSource("dsBidValues", bidsBindingSource);
                ReportDataSource rds2 = new ReportDataSource("detailbid", BidInvoiceDetailBindingSource);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.DataSources.Add(rds1);
                reportViewer1.LocalReport.DataSources.Add(rds2);

                
                return processingResult;
            }
            catch (Exception ex) {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError(ex.Message,ex.Message,""));
                return processingResult;
            };

            Cursor.Current = Cursors.Arrow;
            return processingResult;

        }
        //bids
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
                        //DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsBids.bidsRow)(ex1.Row), ref dsBids);
                        //if (result == DialogResult.Yes)
                        //{
                            Save();
                        //}
                        //else
                        //{
                        //    retval = true;
                        //}
                    }
                    catch (Exception ex)
                    {
                        retval = false;
                        MessageBox.Show("Sales record failed to update:" + ex.Message);
                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Record sales record failed to update:" + ex.Message);
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
            if (!donotchargeschoolsalestaxCheckBox.Checked)
            {
                this.TaxRate = this.GetTaxRate();
            }
            else { this.TaxRate = 0; }
            
            
            schooltaxrateLabel1.Text = TaxRate.ToString("0.000");
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
                        lowCopies = copies - 24;
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
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Pricing was not found:Year-" + txtBYear.Text);
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
            bidsBindingSource.EndEdit();//commits to datasource
            
            var dr = (DataRowView)bidsBindingSource.Current;
            bool byPass =dr.Row.IsNull("ColorPriceOverRide")?false:(bool)dr["ColorPriceOverRide"];
            if (byPass)
            {
                //over ride
                txtSpecCvrEa.Text = "0.00";
                return;
            }
            var vInkNum = inkclrComboBox.Text.Trim();
            int vCopies = 0;
            try {  vCopies = dr.Row.IsNull("nocopies") ? 0 :(int) dr["nocopies"]; }catch(Exception ex) { };
           
            if (vInkNum == "1" || vInkNum == "")
            {
                txtSpecCvrEa.Text = "0.00";
                lblSpeccvrtot.Text = "0.00";
                return;

            }
            if (vCopies<=100)
            {
                vCopies = 100;
            }else if (vCopies > 100 && vCopies <= 125)
            {
                vCopies = 125;
            }else if (vCopies>100 && vCopies <= 150)
            {
                vCopies = 150;
            }
            else if (vCopies > 150 && vCopies <= 175)
            {
                vCopies = 175;
            }
            else if (vCopies > 175 && vCopies <= 200)
            {
                vCopies = 200;
            }
            else if (vCopies > 200 && vCopies <= 225)
            {
                vCopies = 225;
            }
            else if (vCopies > 225 && vCopies <= 250)
            {
                vCopies = 250;
            }
            else if (vCopies > 250 && vCopies <= 275)
            {
                vCopies = 275;
            }
            else if (vCopies > 275 && vCopies <= 300)
            {
                vCopies = 300;
            }
            else if (vCopies > 300 && vCopies <= 325)
            {
                vCopies = 325;
            }
            else if (vCopies > 325 && vCopies <= 350)
            {
                vCopies = 350;
            }
            else if (vCopies > 350 && vCopies <= 375)
            {
                vCopies = 375;
            }
            else if (vCopies > 375 && vCopies <= 400)
            {
                vCopies = 400;
            }
            else if (vCopies > 400 && vCopies <= 425)
            {
                vCopies =425 ;
            }
            else if (vCopies > 425 && vCopies <= 450)
            {
                vCopies =450 ;
            }
            else if (vCopies > 450 && vCopies <= 475)
            {
                vCopies =475 ;
            }
            else if (vCopies > 475 && vCopies <= 500)
            {
                vCopies =500 ;
            }
            else if (vCopies > 500 && vCopies <= 525)
            {
                vCopies =525 ;
            }
            else if (vCopies > 525 && vCopies <= 550)
            {
                vCopies =550 ;
            }
            else if (vCopies > 550 && vCopies <= 575)
            {
                vCopies =575 ;
            }
            else if (vCopies > 575 && vCopies <= 600)
            {
                vCopies =600 ;
            }
            else if (vCopies > 600 && vCopies <= 625)
            {
                vCopies =625 ;
            }
            else if (vCopies > 625 && vCopies <= 650)
            {
                vCopies =650 ;
            }
            else if (vCopies > 650 && vCopies <= 675)
            {
                vCopies =675 ;
            }
            else if (vCopies > 675 && vCopies <= 700)
            {
                vCopies =700 ;
            }
            else if (vCopies > 700 && vCopies <= 725)
            {
                vCopies =725 ;
            }
            else if (vCopies > 725 && vCopies <= 750)
            {
                vCopies =750 ;
            }
            else if (vCopies>= 800)
            {
                vCopies =800 ;
            }
          
            string cmd = "";
            var sqlQuery = new SQLCustomClient();
            sqlQuery.AddParameter("@Copies",vCopies);
            var result = new ApiProcessingResult<string>();
            switch (vInkNum)
            {
                case "2":
                    cmd = "Select TwoInk From InkPricing Where Casing=@Casing and Copies=@Copies";
                    break;
                case "3":
                    cmd = "Select ThreeInk From InkPricing Where Casing=@Casing and Copies=@Copies";
                    break;
                case "Scan":
                    cmd = "Select FourScan From InkPricing Where Casing=@Casing and Copies=@Copies";
                    break;
                   
            }
            if (chkHardBack.Checked||chkCaseBind.Checked)
            {
                sqlQuery.CommandText(cmd);
                sqlQuery.AddParameter("@Casing", "HardBack");
                result = sqlQuery.SelectSingleColumn();
                if (result.IsError)
                {
                    MbcMessageBox.Error("Failed to retrieve Ink Pricing:" + result.Errors[0].ErrorMessage);
                    return;
                }
                decimal vPrice = 0;
                decimal.TryParse(result.Data, out vPrice);
                decimal vTotal = vPrice * vCopies;
                txtSpecCvrEa.Text = vPrice.ToString();
                lblSpeccvrtot.Text = vTotal.ToString("0.00");
                return;


            }
            else
            {
                //softback
                if (vInkNum=="Scan")
                {
                    txtSpecCvrEa.Text = "0.00";
                    lblSpeccvrtot.Text = "335.00";
                    return;
                }
                sqlQuery.CommandText(cmd);
                sqlQuery.AddParameter("@Casing", "Soft");
                result = sqlQuery.SelectSingleColumn();
                if (result.IsError){
                    MbcMessageBox.Error("Failed to retrieve Ink Pricing:" + result.Errors[0].ErrorMessage);
                    return;
                }
                decimal vPrice = 0;
                decimal.TryParse(result.Data, out vPrice);
                decimal vTotal = vPrice * vCopies;
                txtSpecCvrEa.Text = vPrice.ToString();
                lblSpeccvrtot.Text =vTotal.ToString("0.00");
                return;

            }
               

        }
        private void BookCalc()
        {
            decimal vbookTotal = System.Convert.ToDecimal(lblBookTotal.Text.Replace("$", ""));
            decimal vBookCalcTax = this.TaxRate * vbookTotal;
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

						//Story
						decimal Story = 0;
						if (chkStory.Checked)
						{
							Story = (BookOptionPricing.Story);
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
                        decimal Lamination = 0;
                        if (chkMLaminate.Checked)
                        {
                            Lamination = (BookOptionPricing.Lamination * numberOfCopies);
                            vBookCalcTax += (Lamination * this.TaxRate);
                            lblMLaminateAmt.Text = Lamination.ToString();

                        }
                        else
                        {
                            lblMLaminateAmt.Text = "0.00";
                            Lamination = 0;
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

                       




                        decimal SubTotal = (BookTotal + HardBack + Casebind + Perfectbind + Spiral + SaddleStitch + Professional + Convenient + Yir + Story + Gloss + Lamination + SpecCvrTot + FoilTot + ClrPgTot + MiscTot + Desc1Tot + Desc3Tot + Desc4Tot);
                        lblsubtot.Text = SubTotal.ToString("c");
                        this.SalesTax = Math.Round(vBookCalcTax, 2, MidpointRounding.AwayFromZero);
                        this.lblSalesTax.Text = this.SalesTax.ToString("c");

                        //calculate after subtotal
                        decimal disc1 = 0;
                        decimal disc2 = 0;
                        decimal disc3 = 0;
                        decimal msTot = 0;
                        decimal persTot = 0;
                        decimal iconTot = 0;
                        decimal Credits = 0;
                        decimal Credits2 = 0;
                        decimal OtherChrg = 0;
                        decimal OtherChrg2 = 0;
                        vParseResult = decimal.TryParse(txtCredits.Text, out Credits);
                        vParseResult = decimal.TryParse(txtCredits2.Text, out Credits2);
                        vParseResult = decimal.TryParse(txtOtherChrg.Text, out OtherChrg);
                        vParseResult = decimal.TryParse(txtOtherChrg2.Text, out OtherChrg2);


                        vParseResult = decimal.TryParse(lbldisc1amount.Text, out disc1);
                        vParseResult = decimal.TryParse(lbldisc2amount.Text, out disc2);
                        vParseResult = decimal.TryParse(otherdiscamt.Text, out disc3);
                        vParseResult = decimal.TryParse(lblMsTot.Text, out msTot);
                        vParseResult = decimal.TryParse(lblperstotal.Text, out iconTot);
                        vParseResult = decimal.TryParse(lblIconTot.Text, out persTot);

                        vBookCalcTax += (disc1 * this.TaxRate);
                        vBookCalcTax += (disc2 * this.TaxRate);
                        vBookCalcTax += (disc3 * this.TaxRate);
                        vBookCalcTax += (msTot * this.TaxRate);
                        vBookCalcTax += (persTot * this.TaxRate);
                        vBookCalcTax += (iconTot * this.TaxRate);
                        this.SalesTax = Math.Round(vBookCalcTax, 2, MidpointRounding.AwayFromZero);
                        this.lblSalesTax.Text = this.SalesTax.ToString("c");

                        lblfilnalsubtotal.Text = (SubTotal + disc1 + disc2 + disc3 + msTot + persTot + iconTot+Credits+Credits2+OtherChrg+OtherChrg2).ToString("c");
                        SubTotal += (disc1 + disc2 + disc3 + msTot + persTot + iconTot);
                        txtFinalbookprc.Text =(SubTotal / numberOfCopies).ToString("c");
                        //other charges and credits
                        decimal credit1 = 0;
                        decimal credit2 = 0;
                        decimal otherchrg1 = 0;
                        decimal otherchrg2 = 0;
                        decimal vTax = 0;
                        vParseResult = decimal.TryParse(txtCredits.Text, out credit1);
                        vParseResult = decimal.TryParse(txtCredits2.Text, out credit2);
                        vParseResult = decimal.TryParse(txtOtherChrg.Text, out otherchrg1);
                        vParseResult = decimal.TryParse(txtOtherChrg2.Text, out otherchrg2);
                        vParseResult = decimal.TryParse(lblSalesTax.Text.Replace("$",""), out vTax);
                        lbladjbef.Text = (SubTotal + disc1 + disc2 + disc3 + msTot + persTot + credit1 + credit2 + otherchrg1 + otherchrg2+vTax).ToString("c");

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


            SqlConnection conn = new SqlConnection(FormConnectionString);
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

        //General
        public override void Save(bool ShowSpinner)
        {
            //so call can be made from menu
            if (ShowSpinner)
            {
                basePanel.Visible = true;
               backgroundWorker1.RunWorkerAsync("Save");
            }
            else
            {
                var result = Save();
                if (result.IsError)
                {
                    MbcMessageBox.Error(result.Errors[0].ErrorMessage);
                }

            }


        }
        public  ApiProcessingResult<bool> Save()
        {
          var processingResult=new ApiProcessingResult<bool>();
          
            //switch (tabBids.SelectedIndex)
            //{
            //    case 0:
            
            //        {
						try {
							bidsBindingSource.EndEdit();
							var a=bidsTableAdapter.Update(dsBids.bids);
                          
						
						}catch(Exception ex) {
							MbcMessageBox.Error(ex.Message, "");
							processingResult.IsError = true;
                            processingResult.Errors.Add(new ApiProcessingError(ex.Message,ex.Message,""));
                            return processingResult;
						}
     //               }
					//break;


           // }
            return processingResult;
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
								try {bidsTableAdapter.Delete(vid); } catch (Exception ex) { MbcMessageBox.Error("Failed to delete record:" + ex.Message, ""); }
                                
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
        private decimal GetTaxRate()
        {
            if (this.SchoolZipCode == null)
            {
                return 0;
            }
            var a = this.SchoolZipCode.Trim();
            decimal val = 0;
            var sqlQuery = new SQLQuery();
            string querystring = "SELECT Rate FROM SaleTax where ZipCode=@ZipCode";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Zipcode",this.SchoolZipCode)
            };
			try {
				var result = sqlQuery.ExecuteReaderAsync<TaxRate>(CommandType.Text, querystring, parameters);
				if (result != null) {
					var vRateList = (List<TaxRate>)result;
					val = vRateList[0].Rate;

				}
			} catch(Exception ex) {
				MbcMessageBox.Error(ex.Message, "");

			}
           
            
            return val;
        }
        public override void SchCodeSearch()
        {
            
            var saveResult = this.Save();
            if (saveResult.IsError)
            {

                return;
            }


            var currentSchool = this.Schcode;
            frmSearch frmSearch = new frmSearch("Schcode", "BIDS", Schcode);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    int vId = frmSearch.ReturnValue.Invno;//this will be the bid id
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }
                    this.Fill();
                    DataRowView current = (DataRowView)bidsBindingSource.Current;

                  
                    this.Schcode = current["Schcode"].ToString();
                    EnableAllControls(this);
                    var vPos = bidsBindingSource.Find("Id", vId);
                    bidsBindingSource.Position = vPos;

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                frmBids_Paint(this, null);
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


            var currentSchool = this.Schname;
            frmSearch frmSearch = new frmSearch("Schname", "BIDS", currentSchool);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    int vId = frmSearch.ReturnValue.Invno;//this will be the bid id
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }
                    this.Fill();
                    DataRowView current = (DataRowView)bidsBindingSource.Current;


                    this.Schcode = current["Schcode"].ToString();
                    EnableAllControls(this);
                    var vPos = bidsBindingSource.Find("Id", vId);
                    bidsBindingSource.Position = vPos;

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                frmBids_Paint(this, null);
                this.Cursor = Cursors.Default;
            }



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

        }

        private void txtMisc_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtDesc1amt_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtDesc3tot_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtDesc4tot_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtCredits_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtCredits2_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtOtherChrg_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtOtherChrg2_Validating(object sender, CancelEventArgs e)
        {

        }

        private void saletaxTextBox_Validating(object sender, CancelEventArgs e)
        {
            //if (!String.IsNullOrEmpty(saletaxTextBox.Text))
            //{

            //    errorProvider1.SetError(saletaxTextBox, "");
            //    decimal numeral;
            //    var result = decimal.TryParse(saletaxTextBox.Text, out numeral);
            //    //non numeric
            //    if (!result)
            //    {
            //        errorProvider1.SetError(saletaxTextBox, "Please enter a decimal amount.");
            //        e.Cancel = true;

            //    }
            //}
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
            //if (!String.IsNullOrEmpty(txtreqcoverCopies.Text))
            //{

            //    errorProvider1.SetError(txtreqcoverCopies, "");
            //    int numeral;
            //    var result = int.TryParse(txtreqcoverCopies.Text, out numeral);
            //    //non numeric
            //    if (!result)
            //    {
            //        errorProvider1.SetError(txtreqcoverCopies, "Please enter a numeral.");
            //        e.Cancel = true;

            //    }
            //}
        }


        #endregion

        private void frmBids_Paint(object sender, PaintEventArgs e)
        {
            try { this.Text = "Bids-" + this.Schname.Trim() + " (" + this.Schcode.Trim() + ")"; }
            catch
            {

            }
        }

        private void txtNocopies_Leave(object sender, EventArgs e)
        {
            this.BookOptionPricing = null;
            this.Pricing = null;
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
            this.BookOptionPricing = null;
            this.Pricing = null;
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
            decimal total = 0;
            decimal discount = 0;
            decimal.TryParse(this.lblsubtot.Text.Replace("$","").Replace(",",""), out total);
            decimal.TryParse(this.txtDisc.Text, out discount);
            this.lbldisc1amount.Text = "-"+(total * discount).ToString("0.00");
            BookCalc();
        }

        private void txtDp2_Leave(object sender, EventArgs e)
        {
            if (chkDc2.Checked)
            {
                decimal total = 0;
                decimal discount = 0;
                decimal.TryParse(this.lblsubtot.Text.Replace("$", "").Replace(",", ""), out total);
                decimal.TryParse(this.txtDp2.Text, out discount);
                this.lbldisc2amount.Text = "-" + (total * discount).ToString("0.00");
            }
            else { this.lbldisc2amount.Text = "0"; }
            BookCalc();
        }

        private void dp3ComboBox_Leave(object sender, EventArgs e)
        {
            if (dp3ComboBox.SelectedItem == null) { dp3ComboBox.SelectedItem = ".000"; }
            decimal discountpercent = 0;
            decimal subtot = 0;
            bool vParseResult = decimal.TryParse(dp3ComboBox.SelectedItem.ToString(), out discountpercent);
            bool vParseResult1 = decimal.TryParse(lblsubtot.Text.Replace("$", ""), out subtot);
            if (vParseResult && vParseResult1)
            {
                var discountprice = (subtot * discountpercent) - ((subtot * discountpercent) * 2);
                otherdiscamt.Text = discountprice.ToString("0.00");
                BookCalc();
            }
        }

        private void cmbYrDiscountAmt_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateEach();
            BookCalc();
        }

        private void chkDc2_Click(object sender, EventArgs e)
        {
          
        }

        private void chkDc2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDc2.Checked)
            {
                decimal total = 0;
                decimal discount = 0;
                decimal.TryParse(this.lblsubtot.Text.Replace("$", "").Replace(",", ""), out total);
                decimal.TryParse(this.txtDp2.Text, out discount);
                this.lbldisc2amount.Text = "-" + (total * discount).ToString("0.00");
            }
            else { this.lbldisc2amount.Text = "0"; }
            BookCalc();
        }

        private void chkMsStandard_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMsStandard.Checked)
            {
                decimal amount = 0;
                int qty = 0;
                decimal.TryParse(foilamtTextBox.Text, out amount);
                int.TryParse(txtMsQty.Text, out qty);
                lblMsTot.Text = (amount * qty).ToString();
            }
            else { lblMsTot.Text = "0"; }
            BookCalc();

        }

        private void txtMsQty_Leave(object sender, EventArgs e)
        {
            if (chkMsStandard.Checked) {
                decimal amount = 0;
                    int qty = 0;
                decimal.TryParse(foilamtTextBox.Text, out amount);
                int.TryParse(txtMsQty.Text, out qty);
                lblMsTot.Text = (amount * qty).ToString();
            } else { lblMsTot.Text = "0"; }
            BookCalc();
        }

        private void perscopiesTextBox_TextChanged(object sender, EventArgs e)
        {
            int number = 0;
            int number1 = 0;
            decimal prc = 0;
            bool result = int.TryParse(perscopiesTextBox.Text, out number);
            bool result3 = int.TryParse(txtIconCopies.Text, out number1);
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
            txtNumtoPers.Text = (number1 + number).ToString();
        }

        private void perscopiesTextBox_Leave(object sender, EventArgs e)
        {
            int number = 0;
            int number1 = 0;
            decimal prc = 0;
            bool result = int.TryParse(perscopiesTextBox.Text, out number);
            bool result3 = int.TryParse(txtIconCopies.Text, out number1);
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
            txtNumtoPers.Text = (number1 + number).ToString();
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

        private void txtIconCopies_Leave(object sender, EventArgs e)
        {
            int number = 0;
            int number1 = 0;
            decimal prc = 0;
            bool result = int.TryParse(perscopiesTextBox.Text, out number);
            bool result3 = int.TryParse(txtIconCopies.Text, out number1);

            bool result2 = decimal.TryParse(txtIconamt.Text, out prc);
            if (result && result2)
            {
                lblIconTot.Text = (number * prc).ToString("0.00");
                BookCalc();
            }
            else
            {
                lblIconTot.Text = "0.00";
                BookCalc();
            }
            txtNumtoPers.Text = (number1 + number).ToString();
        }

        private void txtIconamt_Leave(object sender, EventArgs e)
        {
            int number = 0;
            decimal prc = 0;
            bool result = int.TryParse(txtIconCopies.Text, out number);
            bool result2 = decimal.TryParse(txtIconamt.Text, out prc);
            if (result && result2)
            {
                lblIconTot.Text = (number * prc).ToString("0.00");
                BookCalc();
            }
            else
            {
                lblIconTot.Text = "0.00";
                BookCalc();
            }
        }

        private void foilamtTextBox_Leave(object sender, EventArgs e)
        {
            if (chkMsStandard.Checked)
            {
                decimal amount = 0;
                int qty = 0;
                decimal.TryParse(foilamtTextBox.Text, out amount);
                int.TryParse(txtMsQty.Text, out qty);
                lblMsTot.Text = (amount * qty).ToString();
            }
            else { lblMsTot.Text = "0"; }
            BookCalc();
        }

        private void donotchargeschoolsalestaxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.CalculateEach();
        }

        private void btnPrntQuote_Click(object sender, EventArgs e)
         
       {
            basePanel.Visible = true;
            backgroundWorker1.RunWorkerAsync("PrintQuote");
            
        }
        private void prntBid()
        {
           
        }

        private void reportViewer1_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
            this.reportViewer1.PrintDialog();
            }catch(Exception ex)
            {
               
                MbcMessageBox.Error(ex.Message,"");
            }
            
           Cursor.Current = Cursors.Arrow;

        }

        private void frmBids_Shown(object sender, EventArgs e)
        {
            tabBids.Visible = true;
            startup = false;
        }

        private void btnCopyToSales_Click(object sender, EventArgs e)
        {
            basePanel.Visible = true;
            backgroundWorker1.RunWorkerAsync("CopyToSales");
            
        }

    private string GetInstructions()
    {
        string val = "";
   
        DataRowView current = (DataRowView)custBindingSource.Current;
        string instructions = current["spcinst"].ToString();

        return instructions;

    }

    private void btnCopyToNewBid_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = dsBids.Tables["bids"];
                DataRowView drview = (DataRowView)this.bidsBindingSource.Current;
                DataRow dr = drview.Row;
                DataRow newRow = dt.NewRow();
                newRow.ItemArray = dr.ItemArray.ToArray();
                newRow["Id"] = 1;

                dt.Rows.Add(newRow);
                SaveBid();
              bidsBindingSource.Position = bidsBindingSource.Count - 1;
                MessageBox.Show("You are now on a copy of the bid you were previously on.","Bid Copy",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }catch(Exception ex)
            {
                
                MessageBox.Show("There was an error creating a copy of the current bid.", "Bid Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
   
        }

        private void frmBids_Activated(object sender, EventArgs e)
        {
            try { frmMain.ShowSearchButtons(this.Name); } catch { }
        }

        private void frmBids_Deactivate(object sender, EventArgs e)
        {
            try { frmMain.HideSearchButtons(); } catch { }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            EnableAllControls(this.tabBids);
            this.lblschode.Text = this.Schcode;
            qtedateDateBox.DateValue = DateTime.Now;
            qtedateDateBox.Date = qtedateDateBox.DateValue.ToString();
        }

        private void chkStory_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtClrTot_Leave_1(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtMisc_Leave_1(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtDesc1amt_Leave_1(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtDesc3tot_Leave_1(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtDesc4tot_Leave_1(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtCredits_Leave_1(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtCredits2_Leave_1(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtOtherChrg_Leave_1(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtOtherChrg2_Leave_1(object sender, EventArgs e)
        {
           BookCalc();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        

        private void frmBids_KeyPress(object sender, KeyPressEventArgs e)
        {
            //set KeyPriview to True first.
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.KeyChar = (char)Keys.Tab;
                SendKeys.Send(e.KeyChar.ToString());//send the keystroke to the form.
            }
        }

        private void cred_etcLabel_Click(object sender, EventArgs e)
        {

        }

        private void inkclrComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void lblSpeccvrtot_MouseDown(object sender, MouseEventArgs e)
        {
            if (ApplicationUser.IsInRole("Administrator") || ApplicationUser.IsInRole("SA"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    InkOverRide.Items["overRidePrice"].Visible = true;
                    InkOverRide.Show(lblSpeccvrtot, new Point(e.X, e.Y));
                }
            }
        }

        private void overRidePrice_Click(object sender, EventArgs e)
        {
            var dr = (DataRowView)bidsBindingSource.Current;
            var val=dr.Row.IsNull("ColorPriceOverRide") ?false:(bool)dr["ColorPriceOverRide"];
            if (!val)
            {
                var dialogResult= MessageBox.Show("Do you want to over ride the Ink Pricing?", "Pricing Over Ride",MessageBoxButtons.YesNo,MessageBoxIcon.Hand);
                if (dialogResult == DialogResult.Yes)
                {
                    dr["ColorPriceOverRide"] = true;
                }
            }
            else
            {
                //ask to turn off price over ride
                var dialogResult = MessageBox.Show("Do you want to turn off the price over ride for Ink Pricing?", "Pricing Over Ride", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (dialogResult == DialogResult.Yes)
                {
                    dr["ColorPriceOverRide"] = false;
                }
            }

        }

        private void txtFoilAd_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string Arg = e.Argument.ToString();

            ApiProcessingResult<bool> taskResult;
            var result = new ApiProcessingResult();
            switch (Arg)
            {
                    case "Save":

                        result = Save();
                    result.Tag = "Fill";
                        break;
                case "CopyToSales":
                    result =CopyToSales();
                    
                    break;
                case "PrintQuote":
                    result =PrintQuote();
                    result.Tag = "RefreshReport";
                    break;


            }
            System.Threading.Thread.Sleep(2000);
            e.Result = result;

           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.basePanel.Visible = false;
            ApiProcessingResult result = (ApiProcessingResult)e.Result;
            if (result.IsError)
            {
                MbcMessageBox.Error(result.Errors[0].ErrorMessage);
                return;
            }
            if (result.Tag == "Fill")
            {
                Fill();
            }
            if (result.Tag == "RefreshReport")
            {
               this.reportViewer1.RefreshReport();
                return;
            }
            
            //Checked for fill so this should work.
            if (result.Tag.Length>0)
            {
                
            }
            
        }

        private void oaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
           }

        private void oaCheckBox_Click(object sender, EventArgs e)
        {
            string curBidId = lblId.Text.Trim();
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            var sqlquery = new SQLCustomClient();
            sqlquery.AddParameter("@schcode", Schcode);
            sqlquery.AddParameter("@Contryear", txtYear.Text);
            sqlquery.CommandText(@"Update Bids Set oa=0 Where schcode=@schcode and contryear=@Contryear");
            var blankResult = sqlquery.Update();
            if (blankResult.IsError)
            {
                ExceptionlessClient.Default.CreateLog("Current Bid Clear Error")
                    .AddObject(blankResult)
                    .MarkAsCritical()
                    .Submit();
                MbcMessageBox.Error("Failed to clear current bids from this school");
                return;
            }
            if (oaCheckBox.Checked)
            {
                sqlquery.ClearParameters();
                sqlquery.AddParameter("@Id", curBidId) ;
                sqlquery.CommandText(@"Update Bids Set OA=1 Where Id=@Id");
                var result = sqlquery.Update();
                if (result.IsError)
                {
                    ExceptionlessClient.Default.CreateLog("Current Bid Update Error")
                        .AddObject(blankResult)
                        .MarkAsCritical()
                        .Submit();
                    MbcMessageBox.Error("Failed to update current bids for this school");

                }
            }
            this.bidsTableAdapter.Fill(dsBids.bids, Schcode);
            var pos =bidsBindingSource.Find("id", curBidId);
            if (pos > -1) {
                bidsBindingSource.Position = pos;
            }

            Cursor.Current = Cursors.Default;
        }
    }
    }
