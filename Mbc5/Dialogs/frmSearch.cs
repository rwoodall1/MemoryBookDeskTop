using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass;
using BindingModels;
namespace Mbc5.Dialogs {
    public partial class frmSearch : Form
    {
        public frmSearch(string vSearchType, string vForm, string vcurrentSearchValue)
        {
            this.SearchType = vSearchType.ToUpper();
            this.ReturnForm = vForm.ToUpper();
            currentSearchValue = vcurrentSearchValue==null?"": vcurrentSearchValue.Trim();
            InitializeComponent();

            //SearchType:
            //Schcode
            //Schname
            //Jobno
            //Invoice
            //Production

        }
        private int CurrentIndex { get; set; }
        private string SearchType { get; set; }
        private string ReturnForm { get; set; }
        private List<SchcodeSearch> CustCode { get; set; }
        private List<SchnameSearch> CustName { get; set; }
        private List<SchnameSalesSearch> SalesCustName { get; set; }
       private List<ProdutnSchnameSearch> ProdutnSchnameList { get; set; }
        private List<OracleCodeSearch> OracleCodeList { get; set; }
        private List<ProdutnOracleCodeSearch> ProdutnOracleCodeList { get; set; }
        private List<ProdNoSearch> ProdutnNoList { get; set; }
        private List<ProdutnSchcodeSearch> ProdutnSchoolCodeList { get; set; }
        private List<InvnoSearch> InvnoList { get; set; }
        private List<ProdutnInvnoSearch>ProdutnInvnoList{ get; set; }
        private List<FirstNameSearch> FirstNameList { get; set; }
        private List<LastNameSearch> LastNameList { get; set; }
        private List<ZipCodeSearch> ZipeCodeList { get; set; }
        private List<EmailSearch> EmailList { get; set; }
        private List<SchcodeSalesSearch> SaleSchoolCodeList { get; set; }
        private List<OracleSalesSearch> OracleSalesCodeList { get; set; }
        private List<JobNoSearch> CustJobCodeList { get; set; }
        private List<SalesJobCode> SalesJobCodeList { get; set; }
		private List<SalesJobCode> ProdJobCodeList { get; set; }
		private List<EndSheetSchcodeSearch> EndSheetSchoolCodeList { get; set; }
        private List<EndSheetSchNameSearch> EndSheetSchoolNameList { get; set; }
        private List<EndSheetOracleCodeSearch> EndSheetOracleCodeList { get; set; }
        private List<EndSheetJobNoSearch> EndSheetJobNoList { get; set; }
        private List<BidsSchcodeSearch> BidSchcodeList { get; set; }
        private List<BidsSchnameSearch> BidSchnameList { get; set; }
        private List<EndSheetInvnoSearch> EndSheetInvnoList { get; set; }
        public ReturnValues ReturnValue { get; set; } = new ReturnValues();

        private string currentSearchValue;

        private void frmSearch_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            var sqlclient = new SQLCustomClient();
            string cmdtext = "";
            switch (SearchType)
            {
                case "SCHCODE":
                    this.Text = "School code Search";
                    switch (ReturnForm)
                    {
                        case "CUST":
                            cmdtext = @"Select C.Schcode,C.Schname,C.OracleCode,C.Contryear,C.SchZip,C.SchState From Cust C Order By Schcode";
                            sqlclient.CommandText(cmdtext);
                            var custresult = sqlclient.SelectMany<SchcodeSearch>();
                            if (custresult.IsError)
                            {
                                MbcMessageBox.Error(custresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var Cust = (List<SchcodeSearch>)custresult.Data;
                            this.CustCode = Cust;
                            bsData.DataSource = this.CustCode;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "MCUST":
                            cmdtext = @"Select C.Schcode,C.Schname,C.OracleCode,C.Contryear,C.SchZip,C.SchState From MCust C Order By Schcode";
                            sqlclient.CommandText(cmdtext);
                            var mcustresult = sqlclient.SelectMany<SchcodeSearch>();
                            if (mcustresult.IsError)
                            {
                                MbcMessageBox.Error(mcustresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var MCust = (List<SchcodeSearch>)mcustresult.Data;
                            this.CustCode = MCust;
                            bsData.DataSource = this.CustCode;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "MSALES":

                            cmdtext = @"Select C.Schcode,C.Schname,Q.Invno AS Invoice,C.OracleCode,C.Contryear,C.SchZip,C.SchState,P.ProdNo From MQuotes Q INNER JOIN MCust C on Q.Schcode=C.Schcode Left Join Produtn P on Q.Invno=P.Invno Order By Schcode";
                            sqlclient.CommandText(cmdtext);
                            var msalesresult = sqlclient.SelectMany<SchcodeSalesSearch>();
                            if (msalesresult.IsError)
                            {
                                MbcMessageBox.Error(msalesresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var retmVal = (List<SchcodeSalesSearch>)msalesresult.Data;
                            this.SaleSchoolCodeList = retmVal;
                            bsData.DataSource = this.SaleSchoolCodeList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "SALES":

                            cmdtext = @"Select C.Schcode,C.Schname,Q.Invno AS Invoice,C.OracleCode,C.Contryear,C.SchZip,C.SchState,P.ProdNo From Quotes Q INNER JOIN Cust C on Q.Schcode=C.Schcode Left Join Produtn P on Q.Invno=P.Invno Order By Schcode";
                            sqlclient.CommandText(cmdtext);
                            var salesresult = sqlclient.SelectMany<SchcodeSalesSearch>();
                            if (salesresult.IsError)
                            {
                                MbcMessageBox.Error(salesresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var retVal = (List<SchcodeSalesSearch>)salesresult.Data;
                            this.SaleSchoolCodeList = retVal;
                            bsData.DataSource = this.SaleSchoolCodeList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;

                        case "PRODUCTION":
                            cmdtext = @"Select C.Schcode,C.Schname,P.Invno AS Invoice,P.ProdNo,C.Contryear From Produtn P INNER JOIN Cust C ON P.Schcode=C.Schcode Order By Schcode";
                            sqlclient.CommandText(cmdtext);
                            var prodresult = sqlclient.SelectMany<ProdutnSchcodeSearch>();
                            if (prodresult.IsError)
                            {
                                MbcMessageBox.Error(prodresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var retVal2 = (List<ProdutnSchcodeSearch>)prodresult.Data;
                            this.ProdutnSchoolCodeList = retVal2;
                            bsData.DataSource = this.ProdutnSchoolCodeList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "BIDS":
                            cmdtext = @"Select C.Schcode,C.Schname,B.Id,B.Contryear,C.SchZip,C.SchState From Bids B  INNER JOIN Cust C on B.Schcode=C.Schcode Order By Schcode,Id";
                            sqlclient.CommandText(cmdtext);
                            var bidresult = sqlclient.SelectMany<BidsSchcodeSearch>();
                            if (bidresult.IsError)
                            {
                                MbcMessageBox.Error(bidresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var bidretVal = (List<BidsSchcodeSearch>)bidresult.Data;
                            this.BidSchcodeList = bidretVal;
                            bsData.DataSource = this.BidSchcodeList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "MBIDS":
                            cmdtext = @"Select C.Schcode,C.Schname,B.Id,B.Contryear,C.SchZip,C.SchState From MBids B  INNER JOIN MCust C on B.Schcode=C.Schcode Order By Schcode,Id";
                            sqlclient.CommandText(cmdtext);
                            var mbidresult = sqlclient.SelectMany<BidsSchcodeSearch>();
                            if (mbidresult.IsError)
                            {
                                MbcMessageBox.Error(mbidresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var mbidretVal = (List<BidsSchcodeSearch>)mbidresult.Data;
                            this.BidSchcodeList = mbidretVal;
                            bsData.DataSource = this.BidSchcodeList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "ENDSHEET":
                            cmdtext = @"Select C.Schcode,C.Schname,E.Invno AS Invoice,E.endshtno AS EndSheetNo,C.Contryear,P.ProdNo From Cust C 
                                        Inner JOIN Quotes Q  ON C.Schcode=Q.Schcode
                                        Left Join EndSheet E On Q.Invno=E.Invno
                                        Left Join Produtn P on Q.Invno=P.Invno
                                        Order By Schcode";
                            sqlclient.CommandText(cmdtext);
                            var endsheetresult = sqlclient.SelectMany<EndSheetSchcodeSearch>();
                            if (endsheetresult.IsError)
                            {
                                MbcMessageBox.Error(endsheetresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var retVal3 = (List<EndSheetSchcodeSearch>)endsheetresult.Data;
                            this.EndSheetSchoolCodeList = retVal3;
                            bsData.DataSource = this.EndSheetSchoolCodeList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        default:
                            MbcMessageBox.Hand("Search is not implemented here.", "");
                            break;
                    }
                    break;
                case "SCHNAME":
                    this.Text = "School Name Search";
                    switch (ReturnForm)
                    {
                        case "CUST":
                            cmdtext = @"Select C.Schname,C.Schcode,C.Contryear,C.SchZip,C.SchState From Cust C Order By Schname";
                            sqlclient.CommandText(cmdtext);
                            var result = sqlclient.SelectMany<SchnameSearch>();
                            if (result.IsError)
                            {
                                MbcMessageBox.Error(result.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var Cust = (List<SchnameSearch>)result.Data;
                            this.CustName = Cust;
                            bsData.DataSource = this.CustName;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "MCUST":
                            cmdtext = @"Select C.Schname,C.Schcode,C.Contryear,C.SchZip,C.SchState From MCust C Order By Schname";
                            sqlclient.CommandText(cmdtext);
                            var resultmcust = sqlclient.SelectMany<SchnameSearch>();
                            if (resultmcust.IsError)
                            {
                                MbcMessageBox.Error(resultmcust.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var MCust = (List<SchnameSearch>)resultmcust.Data;
                            this.CustName = MCust;
                            bsData.DataSource = this.CustName;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "SALES":
                            cmdtext = @"Select C.Schname,C.Schcode,Q.Invno AS Invoice,C.Contryear,C.SchZip,C.SchState,P.ProdNo From Quotes Q Inner Join Cust C ON Q.Schcode=C.Schcode Left Join Produtn P on Q.Invno=P.Invno Order By Schname";
                            sqlclient.CommandText(cmdtext);
                            var result1 = sqlclient.SelectMany<SchnameSalesSearch>();
                            if (result1.IsError)
                            {
                                MbcMessageBox.Error(result1.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var Cust1 = (List<SchnameSalesSearch>)result1.Data;
                            this.SalesCustName = Cust1;
                            bsData.DataSource = this.SalesCustName;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "MSALES":
                            cmdtext = @"Select C.Schname,C.Schcode,Q.Invno AS Invoice,C.Contryear,C.SchZip,C.SchState,P.ProdNo From MQuotes Q Inner Join MCust C ON Q.Schcode=C.Schcode Left Join Produtn P on Q.Invno=P.Invno Order By Schname";
                            sqlclient.CommandText(cmdtext);
                            var result11 = sqlclient.SelectMany<SchnameSalesSearch>();
                            if (result11.IsError)
                            {
                                MbcMessageBox.Error(result11.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var Cust11 = (List<SchnameSalesSearch>)result11.Data;
                            this.SalesCustName = Cust11;
                            bsData.DataSource = this.SalesCustName;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "PRODUCTION":
                            cmdtext = @"Select C.Schname,C.Schcode,P.Invno AS Invoice,P.ProdNo,C.Contryear From Produtn P Inner Join Cust C ON P.Schcode=C.Schcode Order By Schname";
                            sqlclient.CommandText(cmdtext);
                            var result3 = sqlclient.SelectMany<ProdutnSchnameSearch>();
                            if (result3.IsError)
                            {
                                MbcMessageBox.Error(result3.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var prodList = (List<ProdutnSchnameSearch>)result3.Data;
                            this.ProdutnSchnameList = prodList;
                            bsData.DataSource = this.ProdutnSchnameList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "BIDS":
                            cmdtext = @"Select C.Schcode,C.Schname,B.Id,B.Contryear,C.SchZip,C.SchState From Bids B  INNER JOIN Cust C on B.Schcode=C.Schcode Order By Schcode,Id";
                            sqlclient.CommandText(cmdtext);
                            var bidresult = sqlclient.SelectMany<BidsSchnameSearch>();
                            if (bidresult.IsError)
                            {
                                MbcMessageBox.Error(bidresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var bidretVal1 = (List<BidsSchnameSearch>)bidresult.Data;
                            this.BidSchnameList = bidretVal1;
                            bsData.DataSource = this.BidSchnameList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();


                            break;
                        case "ENDSHEET":
                            cmdtext = @"Select C.Schname,C.Schcode,E.Invno AS Invoice,E.endshtno AS EndSheetNo,C.Contryear,P.ProdNo From Cust C 
                                        Inner JOIN Quotes Q  ON C.Schcode=Q.Schcode
                                        Left Join EndSheet E On Q.Invno=E.Invno
                                        Left Join Produtn P on Q.Invno=P.Invno
                                        Order By Schcode";
                            sqlclient.CommandText(cmdtext);
                            var endsheetresult = sqlclient.SelectMany<EndSheetSchNameSearch>();
                            if (endsheetresult.IsError)
                            {
                                MbcMessageBox.Error(endsheetresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var retVal4 = (List<EndSheetSchNameSearch>)endsheetresult.Data;
                            this.EndSheetSchoolNameList = retVal4;
                            bsData.DataSource = this.EndSheetSchoolNameList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                    }
                    break;
                case "ORACLECODE":
                    this.Text = "Oracle Code Search";
                    switch (ReturnForm)
                    {
                        case "CUST":
                            
                                cmdtext = @"Select COALESCE(C.OracleCode,'')AS OracleCode,C.Schname,C.Schcode,C.Contryear,C.SchZip,C.SchState From Cust C  WHERE C.OracleCode !='' ORDER By OracleCode";
                                sqlclient.CommandText(cmdtext);
                                var result = sqlclient.SelectMany<OracleCodeSearch>();
                                if (result.IsError)
                                {
                                    MbcMessageBox.Error(result.Errors[0].ErrorMessage, "Error");
                                    return;
                                }
                                var lRetRecs = (List<OracleCodeSearch>)result.Data;
                                this.OracleCodeList = lRetRecs;
                                bsData.DataSource = this.OracleCodeList;

                                dgSearch.DataSource = bsData.DataSource;

                                txtSearch.Select();
                                break;
                        case "MCUST":

                            cmdtext = @"Select COALESCE(C.OracleCode,'')AS OracleCode,C.Schname,C.Schcode,C.Contryear,C.SchZip,C.SchState From MCust C  WHERE C.OracleCode !='' ORDER By OracleCode";
                            sqlclient.CommandText(cmdtext);
                            var resultOC = sqlclient.SelectMany<OracleCodeSearch>();
                            if (resultOC.IsError)
                            {
                                MbcMessageBox.Error(resultOC.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecs1 = (List<OracleCodeSearch>)resultOC.Data;
                            this.OracleCodeList = lRetRecs1;
                            bsData.DataSource = this.OracleCodeList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();
                            break;

                        case "SALES":
                            cmdtext = @"Select COALESCE(C.OracleCode,'')AS OracleCode,C.Schname,C.Schcode,Q.Invno As Invoice,C.Contryear,C.SchZip,C.SchState,P.ProdNo From Quotes Q  Inner Join Cust C On Q.Schcode=C.Schcode Left Join Produtn P on Q.Invno=P.Invno WHERE C.OracleCode !=''  Order By OracleCode";
                            sqlclient.CommandText(cmdtext);
                            var oracleCodeResult = sqlclient.SelectMany<OracleSalesSearch>();
                            if (oracleCodeResult.IsError)
                            {
                                MbcMessageBox.Error(oracleCodeResult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lOracleCodeList = (List<OracleSalesSearch>)oracleCodeResult.Data;
                            this.OracleSalesCodeList = lOracleCodeList;
                            bsData.DataSource = this.OracleSalesCodeList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;
                        case "MSALES":
                            cmdtext = @"Select COALESCE(C.OracleCode,'') AS OracleCode,C.Schname,C.Schcode,Q.Invno As Invoice,C.Contryear,C.SchZip,C.SchState From MQuotes Q  Inner Join MCust C On Q.Schcode=C.Schcode Left Join Produtn P on Q.Invno=P.Invno WHERE C.OracleCode !='' Order By OracleCode";
                            sqlclient.CommandText(cmdtext);
                            var oracleCodeResult1 = sqlclient.SelectMany<OracleSalesSearch>();
                            if (oracleCodeResult1.IsError)
                            {
                                MbcMessageBox.Error(oracleCodeResult1.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lOracleCodeList1 = (List<OracleSalesSearch>)oracleCodeResult1.Data;
                            this.OracleSalesCodeList = lOracleCodeList1;
                            bsData.DataSource = this.OracleSalesCodeList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;
                        case "ENDSHEET":
                            cmdtext = @"Select C.OracleCode,C.Schname,C.Schcode,E.Invno AS Invoice,E.endshtno as EndSheetNo,C.Contryear,P.ProdNo From Cust C 
                                        Inner JOIN Quotes Q  ON C.Schcode=Q.Schcode
                                        Left Join EndSheet E On Q.Invno=E.Invno
                                        Left Join Produtn P on Q.Invno=P.Invno
                                        Order By Schcode";
                            sqlclient.CommandText(cmdtext);
                            var endsheetresult = sqlclient.SelectMany<EndSheetOracleCodeSearch>();
                            if (endsheetresult.IsError)
                            {
                                MbcMessageBox.Error(endsheetresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var retVal4 = (List<EndSheetOracleCodeSearch>)endsheetresult.Data;
                            this.EndSheetOracleCodeList = retVal4;
                            bsData.DataSource = this.EndSheetOracleCodeList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "PRODUCTION":
                            cmdtext = @"Select COALESCE(C.OracleCode,'',C.Schname,C.Schcode,P.Invno As Invoice,P.ProdNo,C.Contryear From Produtn P Inner Join Cust C On P.Schcode=C.Schcode WHERE C.OracleCode !='' Order By OracleCode";
                            sqlclient.CommandText(cmdtext);
                            var produtnOracleCodeResult = sqlclient.SelectMany<ProdutnOracleCodeSearch>();
                            if (produtnOracleCodeResult.IsError)
                            {
                                MbcMessageBox.Error(produtnOracleCodeResult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lProdutnOracleCodeList = (List<ProdutnOracleCodeSearch>)produtnOracleCodeResult.Data;
                            this.ProdutnOracleCodeList = lProdutnOracleCodeList;
                            bsData.DataSource = this.ProdutnOracleCodeList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;
                        case "BIDS":
                            break;
                    }

                    break;
                case "JOBNO":
                    this.Text = "Job # Search";
                    switch (ReturnForm)
                    {
                        case "CUST":
                            cmdtext = @"Select COALESCE(P.JobNo,'')AS JobNo,C.Schcode,C.Schname,C.OracleCode,C.Contryear,C.SchZip,C.SchState From Cust C Left JOIN Produtn P on C.schcode=P.schcode Where P.JobNo !='' Order By Schcode";
                            sqlclient.CommandText(cmdtext);
                            var custresult = sqlclient.SelectMany<JobNoSearch>();
                            if (custresult.IsError)
                            {
                                MbcMessageBox.Error(custresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var Cust = (List<JobNoSearch>)custresult.Data;
                            this.CustJobCodeList = Cust;
                            bsData.DataSource = this.CustJobCodeList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                       
                            break;
                        case "SALES":
                            cmdtext = @"Select COALESCE(P.JobNo,'')AS JobNo,C.Schcode,C.Schname,Q.Invno AS Invoice,P.ProdNo,C.Contryear From Cust C Left Join Quotes Q ON C.schcode=Q.Schcode Left Join Produtn P on Q.Invno=P.Invno  Where P.JobNo !='' Order By Jobno";
                            sqlclient.CommandText(cmdtext);
                            var jobcoderesult = sqlclient.SelectMany<SalesJobCode>();
                            if (jobcoderesult.IsError)
                            {
                                MbcMessageBox.Error(jobcoderesult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var vJobCodes = (List<SalesJobCode>)jobcoderesult.Data;
                            this.SalesJobCodeList = vJobCodes;
                            bsData.DataSource = this.SalesJobCodeList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "ENDSHEET":
                            cmdtext = @"Select C.JobNo,C.Schname,C.Schcode,E.Invno AS Invoice,E.endshtno as EndSheetNo,C.Contryear,P.ProdNo From Cust C 
                                        Inner JOIN Quotes Q  ON C.Schcode=Q.Schcode
                                        Left Join EndSheet E On Q.Invno=E.Invno
                                        Left Join Produtn P on Q.Invno=P.Invno
                                        Order By Schcode";
                            sqlclient.CommandText(cmdtext);
                            var endsheetresult = sqlclient.SelectMany<EndSheetJobNoSearch>();
                            if (endsheetresult.IsError)
                            {
                                MbcMessageBox.Error(endsheetresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var retVal4 = (List<EndSheetJobNoSearch>)endsheetresult.Data;
                            this.EndSheetJobNoList = retVal4;
                            bsData.DataSource = this.EndSheetJobNoList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                        case "PRODUCTION":
							cmdtext = @"Select COALESCE(P.JobNo,'')AS JobNo,C.Schcode,C.Schname,Q.Invno AS Invoice,P.ProdNo,C.Contryear From Cust C Left Join Quotes Q ON C.schcode=Q.Schcode Left Join Produtn P on Q.Invno=P.invno Where P.JobNo !='' Order By Jobno";
							sqlclient.CommandText(cmdtext);
							var prodJobcoderesult = sqlclient.SelectMany<SalesJobCode>();
							if (prodJobcoderesult.IsError) {
								MbcMessageBox.Error(prodJobcoderesult.Errors[0].ErrorMessage, "Error");
								return;
							}
							var vProdJobCodes = (List<SalesJobCode>)prodJobcoderesult.Data;
							this.ProdJobCodeList = vProdJobCodes;
							bsData.DataSource = this.ProdJobCodeList;
							dgSearch.DataSource = bsData;
							txtSearch.Select();
							break;
                    }
                    break;
                case "INVNO":
                    this.Text = "Invoice # Search";
                    switch (ReturnForm)
                    {
                        case "CUST":
                            cmdtext = @"Select Q.Invno AS Invoice,C.Schname,C.Schcode,C.OracleCode,C.Contryear,C.SchZip,C.SchState From Quotes Q Left JOIN Cust C On Q.Schcode=C.Schcode Order By Invno";
                            sqlclient.CommandText(cmdtext);
                            var result = sqlclient.SelectMany<InvnoSearch>();
                            if (result.IsError)
                            {
                                MbcMessageBox.Error(result.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecs = (List<InvnoSearch>)result.Data;
                            this.InvnoList = lRetRecs;
                            bsData.DataSource = this.InvnoList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();
                            break;
                        case "SALES":
                            cmdtext = @"Select Q.Invno AS Invoice,C.Schname,C.Schcode,C.OracleCode,C.Contryear,C.SchZip,C.SchState,P.ProdNo From Quotes Q Left JOIN Cust C On Q.Schcode=C.Schcode Left Join Produtn P on Q.Invno=P.Invno Order By Q.Invno";
                            sqlclient.CommandText(cmdtext);
                            var result1 = sqlclient.SelectMany<InvnoSearch>();
                            if (result1.IsError)
                            {
                                MbcMessageBox.Error(result1.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecs1 = (List<InvnoSearch>)result1.Data;
                            this.InvnoList = lRetRecs1;
                            bsData.DataSource = this.InvnoList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();
                            break;
                        case "MSALES":
                            cmdtext = @"Select Q.Invno AS Invoice,C.Schname,C.Schcode,C.OracleCode,C.Contryear,C.SchZip,C.SchState,P.ProdNo From MQuotes Q Left JOIN MCust C On Q.Schcode=C.Schcode Left Join Produtn P on Q.Invno=P.Invno Order By Q.Invno";
                            sqlclient.CommandText(cmdtext);
                            var result12 = sqlclient.SelectMany<InvnoSearch>();
                            if (result12.IsError)
                            {
                                MbcMessageBox.Error(result12.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecs12 = (List<InvnoSearch>)result12.Data;
                            this.InvnoList = lRetRecs12;
                            bsData.DataSource = this.InvnoList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();
                            break;
                        case "PRODUCTION":
                            cmdtext = @"Select P.Invno AS Invoice,C.Schname,C.Schcode,C.OracleCode,C.Contryear From Produtn P Inner JOIN Cust C On P.Schcode=C.Schcode Order By Invoice";
                            sqlclient.CommandText(cmdtext);
                            var result4 = sqlclient.SelectMany<ProdutnInvnoSearch>();
                            if (result4.IsError)
                            {
                                MbcMessageBox.Error(result4.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecsInvno = (List<ProdutnInvnoSearch>)result4.Data;
                            this.ProdutnInvnoList = lRetRecsInvno;
                            bsData.DataSource = this.ProdutnInvnoList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;
                        case "ENDSHEET":
                            cmdtext = @"Select E.Invno AS Invoice,C.Schname,C.Schcode,E.endshtno As EndSheetNo,C.Contryear,P.ProdNo From EndSheet E  
                                        Inner JOIN Quotes Q  ON E.Invno=Q.Invno
                                        Left Join Cust C On Q.Schcode=C.Schcode
                                        Left Join Produtn P on Q.Invno=P.Invno
                                        Order By Q.Invoice";
                            sqlclient.CommandText(cmdtext);
                            var endsheetresult = sqlclient.SelectMany<EndSheetInvnoSearch>();
                            if (endsheetresult.IsError)
                            {
                                MbcMessageBox.Error(endsheetresult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var retVal4 = (List<EndSheetInvnoSearch>)endsheetresult.Data;
                            this.EndSheetInvnoList = retVal4;
                            bsData.DataSource = this.EndSheetInvnoList;
                            dgSearch.DataSource = bsData;
                            txtSearch.Select();
                            break;
                    }
                    break;
                case "PRODNO":
                    switch (ReturnForm)
                    {
                        case "CUST":
                            cmdtext = @"Select RTrim(P.ProdNo)AS ProdNo,P.Invno AS Invoice,C.Schname,C.Schcode,C.Contryear From Produtn P Left Join Cust C On P.Schcode=C.Schcode Order By ProdNo";
                            sqlclient.CommandText(cmdtext);
                            var result = sqlclient.SelectMany<ProdNoSearch>();
                            if (result.IsError)
                            {
                                MbcMessageBox.Error(result.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecs = (List<ProdNoSearch>)result.Data;
                            this.ProdutnNoList = lRetRecs;
                            bsData.DataSource = this.ProdutnNoList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();


                            break;
                        case "MCUST":
                            cmdtext = @"Select RTrim(P.ProdNo)AS ProdNo,P.Invno AS Invoice,C.Schname,C.Schcode,C.Contryear From Produtn P Left Join MCust C On P.Schcode=C.Schcode Order By ProdNo";
                            sqlclient.CommandText(cmdtext);
                            var resultPn = sqlclient.SelectMany<ProdNoSearch>();
                            if (resultPn.IsError)
                            {
                                MbcMessageBox.Error(resultPn.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecsPn = (List<ProdNoSearch>)resultPn.Data;
                            this.ProdutnNoList = lRetRecsPn;
                            bsData.DataSource = this.ProdutnNoList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();


                            break;
                        case "SALES":
							cmdtext = @"Select RTrim(P.ProdNo)AS ProdNo,P.Invno as Invoice,C.Schname,C.Schcode,C.Contryear From Produtn P Left Join Cust C On P.Schcode=C.Schcode Order By ProdNo";
							sqlclient.CommandText(cmdtext);
							var result1 = sqlclient.SelectMany<ProdNoSearch>();
							if (result1.IsError) {
								MbcMessageBox.Error(result1.Errors[0].ErrorMessage, "Error");
								return;
							}
							var lRetRecs1 = (List<ProdNoSearch>)result1.Data;
							this.ProdutnNoList = lRetRecs1;
							bsData.DataSource = this.ProdutnNoList;

							dgSearch.DataSource = bsData.DataSource;

							txtSearch.Select();
							break;
					
                        case "PRODUCTION":
                            cmdtext = @"Select RTrim(P.ProdNo)AS ProdNo,P.Invno AS Invoice,C.Schname,C.Schcode,C.Contryear From Produtn P Left Join Cust C On P.Schcode=C.Schcode Order By ProdNo";
                            sqlclient.CommandText(cmdtext);
                            var result2 = sqlclient.SelectMany<ProdNoSearch>();
                            if (result2.IsError)
                            {
                                MbcMessageBox.Error(result2.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecs2 = (List<ProdNoSearch>)result2.Data;
                            this.ProdutnNoList = lRetRecs2;
                            bsData.DataSource = this.ProdutnNoList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();
                            break;
                        case "COVERS":
                            break;
                    }
                    break;
                case "FIRSTNAME":
                    switch (ReturnForm)
                    {
                        case "CUST":
                            cmdtext = @"SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(contfname)) AS FirstName
                                            ,RTrim(LTrim(contlname)) AS LastName
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM cust
                                    Union All
                                        SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(bcontfname)) AS FirstName
                                            ,RTrim(LTrim(bcontlname)) AS LastName
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM cust
                                     Union ALL
                                        SELECT Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(ccontfname)) AS FirstName
                                            ,RTrim(LTrim(ccontlname)) AS LastName
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM cust
                                        ORDER BY FirstName";
                            sqlclient.CommandText(cmdtext);
                            var result = sqlclient.SelectMany<FirstNameSearch>();
                            if (result.IsError)
                            {
                                MbcMessageBox.Error(result.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecs = (List<FirstNameSearch>)result.Data;
                            this.FirstNameList = lRetRecs;
                            bsData.DataSource = this.FirstNameList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;

                        case "MCUST":
                            cmdtext = @"SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(contfname)) AS FirstName
                                            ,RTrim(LTrim(contlname)) AS LastName
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM mcust
                                    Union All
                                        SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(bcontfname)) AS FirstName
                                            ,RTrim(LTrim(bcontlname)) AS LastName
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM mcust
                                       ORDER BY FirstName";
                            sqlclient.CommandText(cmdtext);
                            var resultFn = sqlclient.SelectMany<FirstNameSearch>();
                            if (resultFn.IsError)
                            {
                                MbcMessageBox.Error(resultFn.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecs1 = (List<FirstNameSearch>)resultFn.Data;
                            this.FirstNameList = lRetRecs1;
                            bsData.DataSource = this.FirstNameList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;

                    }
                    break;
                case "LASTNAME":
                    switch (ReturnForm)
                    {
                        case "CUST":
                            cmdtext = @"SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(contfname)) AS FirstName
                                            ,RTrim(LTrim(contlname)) AS LastName
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM cust
                                    Union All
                                        SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(bcontfname)) AS FirstName
                                            ,RTrim(LTrim(bcontlname)) AS LastName
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM cust
                                     Union ALL
                                        SELECT Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(ccontfname)) AS FirstName
                                            ,RTrim(LTrim(ccontlname)) AS LastName
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM cust
                                        ORDER BY lastName";
                            sqlclient.CommandText(cmdtext);
                            var result = sqlclient.SelectMany<LastNameSearch>();
                            if (result.IsError)
                            {
                                MbcMessageBox.Error(result.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecs = (List<LastNameSearch>)result.Data;
                            this.LastNameList = lRetRecs;
                            bsData.DataSource = this.LastNameList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;
                        case "MCUST":
                            cmdtext = @"SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(contfname)) AS FirstName
                                            ,RTrim(LTrim(contlname)) AS LastName
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM mcust
                                    Union All
                                        SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(bcontfname)) AS FirstName
                                            ,RTrim(LTrim(bcontlname)) AS LastName
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM mcust
                                     
                                        ORDER BY lastName";
                            sqlclient.CommandText(cmdtext);
                            var resultLn = sqlclient.SelectMany<LastNameSearch>();
                            if (resultLn.IsError)
                            {
                                MbcMessageBox.Error(resultLn.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecsLn = (List<LastNameSearch>)resultLn.Data;
                            this.LastNameList = lRetRecsLn;
                            bsData.DataSource = this.LastNameList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;


                    }
                    break;
                case "EMAIL":
                    switch (ReturnForm)
                    {
                        case "CUST":
                            cmdtext = @"SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(schemail)) AS Email
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM cust
                                    Union All
                                        SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(contemail)) AS Email
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM cust
                                     Union ALL
                                        SELECT Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(bcontemail)) AS Email
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM cust
                                    Union ALL
                                        SELECT Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(ccontemail)) AS Email
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM cust
                                        ORDER BY Email";
                            sqlclient.CommandText(cmdtext);
                            var result = sqlclient.SelectMany<EmailSearch>();
                            if (result.IsError)
                            {
                                MbcMessageBox.Error(result.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecs = (List<EmailSearch>)result.Data;
                            this.EmailList = lRetRecs;
                            bsData.DataSource = this.EmailList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;

                        case "MCUST":
                            cmdtext = @"SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(schemail)) AS Email
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM mcust
                                    Union All
                                        SELECT 
                                            Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(contemail)) AS Email
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM mcust
                                     Union ALL
                                        SELECT Schcode 
                                            ,Schname
                                            ,Schcode
                                            ,OracleCode 
                                            ,RTrim(LTrim(bcontemail)) AS Email
                                            ,Contryear 
                                            ,SchZip 
                                            ,SchState
                                        FROM mcust
                                    
                                        ORDER BY Email";
                            sqlclient.CommandText(cmdtext);
                            var resultEm = sqlclient.SelectMany<EmailSearch>();
                            if (resultEm.IsError)
                            {
                                MbcMessageBox.Error(resultEm.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecsEm = (List<EmailSearch>)resultEm.Data;
                            this.EmailList = lRetRecsEm;
                            bsData.DataSource = this.EmailList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;

                    }
                    break;
                case "ZIPCODE":
                    switch (ReturnForm)
                    {
                        case "CUST":

                            cmdtext = @"Select SchZip,SchState,RTrim(LTrim(C.Schname)),C.Schcode,C.OracleCode,C.Contryear From Cust C  Order By SchZip";
                            sqlclient.CommandText(cmdtext);
                            var result = sqlclient.SelectMany<ZipCodeSearch>();
                            if (result.IsError)
                            {
                                MbcMessageBox.Error(result.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecs = (List<ZipCodeSearch>)result.Data;
                            this.ZipeCodeList = lRetRecs;
                            bsData.DataSource = this.ZipeCodeList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;
                        case "MCUST":

                            cmdtext = @"Select SchZip,SchState,RTrim(LTrim(C.Schname)),C.Schcode,C.OracleCode,C.Contryear From MCust C  Order By SchZip";
                            sqlclient.CommandText(cmdtext);
                            var resultZC = sqlclient.SelectMany<ZipCodeSearch>();
                            if (resultZC.IsError)
                            {
                                MbcMessageBox.Error(resultZC.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lRetRecsZC = (List<ZipCodeSearch>)resultZC.Data;
                            this.ZipeCodeList = lRetRecsZC;
                            bsData.DataSource = this.ZipeCodeList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;

                    }

                    break;
                 
            }
            this.dgSearch.Columns[0].Width = 125;
            this.Cursor = Cursors.Default;
            if (SearchType == "PRODNO")
            {
                if (currentSearchValue!="") {
                    txtSearch.Text = currentSearchValue.Substring(1);
                }
            }
            else
            {
                txtSearch.Text = currentSearchValue;
            }
            
            Search(txtSearch.Text);
        }
        private void Search(string value)
     {

            int vIndex;
            switch (SearchType)
            {
                  
                case "SCHCODE":
                    List<string>  vList =new List<string>();
                    if (ReturnForm == "CUST"|| ReturnForm == "MCUST")
                    {
                        vList = this.CustCode.Select(x => x.Schcode).ToList();
                    }
                    else if (ReturnForm == "SALES"|| ReturnForm == "MSALES")
                    {
                        vList = this.SaleSchoolCodeList.Select(x => x.Schcode).ToList();
                    }else if (ReturnForm == "PRODUCTION")
                    {
                        vList=this.ProdutnSchoolCodeList.Select(x => x.Schcode).ToList();
                    }else if (ReturnForm == "ENDSHEET")
                    {
                        vList = this.EndSheetSchoolCodeList.Select(x => x.Schcode).ToList();
                    }else if (ReturnForm=="BIDS")
                    {
                        vList = this.BidSchcodeList.Select(x => x.Schcode).ToList();
                    }
                        
    
                    try
                    {
                        vIndex = vList.FindIndex(vcust => !string.IsNullOrEmpty(vcust)&& vcust.ToString().Trim().ToUpper().StartsWith(value.ToUpper()));
                        if (vIndex != -1)
                        {
                            dgSearch.ClearSelection();
                            bsData.Position = vIndex;
                            dgSearch.Rows[vIndex].Selected = true;
                            dgSearch.FirstDisplayedScrollingRowIndex = vIndex;

                            CurrentIndex = vIndex;

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                case "SCHNAME":
                    List<string> vListName = new List<string>();
                    if (ReturnForm == "CUST"|| ReturnForm == "MCUST")
                    {
                        vListName = this.CustName.Select(x => x.Schname).ToList();
                    }
                    else if (ReturnForm == "SALES"|| ReturnForm == "MSALES")
                    {
                        vListName = this.SalesCustName.Select(x => x.Schname).ToList();
                    }else if (ReturnForm == "PRODUCTION")
                    {
                        vListName = this.ProdutnSchnameList.Select(x => x.Schname).ToList();
                    }else if (ReturnForm == "BIDS")
                    {
                        vListName = this.BidSchnameList.Select(x => x.Schname).ToList();
                    }
                    else if (ReturnForm == "ENDSHEET")
                    {
                        vListName = this.EndSheetSchoolNameList.Select(x => x.Schname).ToList();
                    }
                    try
                    {
                        vIndex = vListName.FindIndex(vcust => vcust.ToString().Trim().ToUpper().StartsWith(value.ToUpper()));
                        if (vIndex != -1)
                        {
                            dgSearch.ClearSelection();
                            bsData.Position = vIndex;
                            dgSearch.Rows[vIndex].Selected = true;
                            dgSearch.FirstDisplayedScrollingRowIndex = vIndex;

                            CurrentIndex = vIndex;

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    break;
                case "JOBNO":
                   List<string> vJobList = new List<string>();
                    if (ReturnForm == "CUST" )
                    {
                        vJobList = this.CustJobCodeList.Select(x => x.JobNo).ToList();
                    }else if (ReturnForm == "SALES")
                    {
                        vJobList = this.SalesJobCodeList.Select(x => x.JobNo).ToList();
                    }
                    else if (ReturnForm == "PRODUCTION")
                    {
						vJobList = this.ProdJobCodeList.Select(x => x.JobNo).ToList();
					}
                    else if (ReturnForm == "ENDSHEET")
                    {
                        vJobList = this.EndSheetJobNoList.Select(x => x.JobNo).ToList();
                    }

                    try
                    {
                        
                        vIndex = vJobList.FindIndex(vcust => vcust !=null && vcust.ToString().StartsWith(value.ToUpper()));
                        if (vIndex != -1)
                        {
                            dgSearch.ClearSelection();
                            bsData.Position = vIndex;
                            dgSearch.Rows[vIndex].Selected = true;
                            dgSearch.FirstDisplayedScrollingRowIndex = vIndex;

                            CurrentIndex = vIndex;

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                case "ORACLECODE":

                    List<string> vOracleList = new List<string>();
                    if (ReturnForm == "CUST"|| ReturnForm == "MCUST")
                    {
                        vOracleList = this.OracleCodeList.Select(x => x.OracleCode).ToList();
                    }
                    else if (ReturnForm == "SALES"|| ReturnForm == "MSALES")
                    {
                        vOracleList = this.OracleSalesCodeList.Select(x => x.OracleCode).ToList();
                    }else if (ReturnForm == "PRODUCTION")
                    {
                        vOracleList = this.ProdutnOracleCodeList.Select(x => x.OracleCode).ToList();
                    }
                    else if (ReturnForm == "ENDSHEET")
                    {
                        vOracleList = this.EndSheetOracleCodeList.Select(x => x.OracleCode).ToList();
                    }

                    try
                    {

                        var vIndex1 = vOracleList.FindIndex(vcust => vcust != null && vcust.ToString().Trim().ToUpper().StartsWith(value.ToUpper()));
                        if (vIndex1 != -1)
                        {
                            dgSearch.ClearSelection();
                            bsData.Position = vIndex1;
                            dgSearch.Rows[vIndex1].Selected = true;
                            dgSearch.FirstDisplayedScrollingRowIndex = vIndex1;

                            CurrentIndex = vIndex1;

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    break;
                case "PRODNO":
                     List<string> vProdNoList = new List<string>();
                    if (ReturnForm == "CUST"|| ReturnForm == "MCUST")
                    {
                        vProdNoList = this.ProdutnNoList.Select(x => x.ProdNo).ToList();
                    }
                    else if (ReturnForm == "PRODUCTION")
                    {
                        vProdNoList = this.ProdutnNoList.Select(x => x.ProdNo).ToList();
                    }
                    try
                    {
                        //value is trimmed to 5 spaces, binding is took out
                        vIndex = vProdNoList.FindIndex(vcust => vcust != null && vcust.Substring(1).ToUpper().StartsWith(value.ToUpper()));
                        if (vIndex != -1)
                        {
                           
                            dgSearch.ClearSelection();
                            bsData.Position = vIndex;
                            dgSearch.Rows[vIndex].Selected = true;
                            dgSearch.FirstDisplayedScrollingRowIndex = vIndex;
                            CurrentIndex = vIndex;
                            

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                case "INVNO":
                    List<string> vInvnoList = new List<string>();
                    if (ReturnForm == "CUST"|| ReturnForm == "SALES"|| ReturnForm == "MCUST" || ReturnForm == "MSALES")
                    {
                        vInvnoList = this.InvnoList.Select(x => x.Invoice.ToString()).ToList();
                    }else if (ReturnForm == "PRODUCTION")
                    {
                        vInvnoList = this.ProdutnInvnoList.Select(x => x.Invoice.ToString()).ToList();
                    }
                    else if (ReturnForm == "ENDSHEET")
                    {
                        vInvnoList = this.EndSheetInvnoList.Select(x => x.Invoice.ToString()).ToList();
                    }

                    try
                    {
                        //value is trimmed to 5 spaces, binding is took out
                        vIndex =vInvnoList.FindIndex(vcust => vcust != "0" && vcust.ToString().StartsWith(value.ToUpper()));
                        if (vIndex != -1)
                        {
                            dgSearch.ClearSelection();
                            bsData.Position = vIndex;
                            dgSearch.Rows[vIndex].Selected = true;
                            dgSearch.FirstDisplayedScrollingRowIndex = vIndex;

                            CurrentIndex = vIndex;

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                case "FIRSTNAME":

                    try
                    {
                        
                        vIndex = this.FirstNameList.FindIndex(vcust => !string.IsNullOrEmpty(vcust.FirstName) && vcust.FirstName.ToUpper().Trim().StartsWith(value.ToUpper()));
                        if (vIndex != -1)
                        {
                            dgSearch.ClearSelection();
                            bsData.Position = vIndex;
                            dgSearch.Rows[vIndex].Selected = true;
                            dgSearch.FirstDisplayedScrollingRowIndex = vIndex;

                            CurrentIndex = vIndex;

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                case "LASTNAME":

                    try
                    {
                        //value is trimmed to 5 spaces, binding is took out
                        vIndex = this.LastNameList.FindIndex(vcust => !string.IsNullOrEmpty(vcust.LastName) && vcust.LastName.ToUpper().Trim().StartsWith(value.ToUpper()));
                        if (vIndex != -1)
                        {
                            dgSearch.ClearSelection();
                            bsData.Position = vIndex;
                            dgSearch.Rows[vIndex].Selected = true;
                            dgSearch.FirstDisplayedScrollingRowIndex = vIndex;

                            CurrentIndex = vIndex;

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                case "ZIPCODE":

                    try
                    {
                        //value is trimmed to 5 spaces, binding is took out
                        vIndex = this.ZipeCodeList.FindIndex(vcust => vcust.SchZip != null && vcust.SchZip.ToUpper().Trim().StartsWith(value.ToUpper()));
                        if (vIndex != -1)
                        {
                            dgSearch.ClearSelection();
                            bsData.Position = vIndex;
                            dgSearch.Rows[vIndex].Selected = true;
                            dgSearch.FirstDisplayedScrollingRowIndex = vIndex;

                            CurrentIndex = vIndex;

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                case "EMAIL":

                    try
                    {
                      
                        vIndex = this.EmailList.FindIndex(vcust => vcust.Email != null && vcust.Email.ToUpper().Trim().StartsWith(value.ToUpper()));
                        if (vIndex != -1)
                        {
                            dgSearch.ClearSelection();
                            bsData.Position = vIndex;
                            dgSearch.Rows[vIndex].Selected = true;
                            dgSearch.FirstDisplayedScrollingRowIndex = vIndex;

                            CurrentIndex = vIndex;

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
            }



        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
      {
            if (e.KeyChar == 13)
            {
                this.DialogResult = DialogResult.OK;
                //cust form
                if (SearchType == "SCHCODE" && (ReturnForm == "CUST" || ReturnForm == "MCUST"))
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();

                } else if (SearchType == "SCHCODE" && (ReturnForm == "SALES" || ReturnForm == "MSALES"))
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[1].Value;
                }
                else if (SearchType == "SCHCODE" && ReturnForm == "PRODUCTION")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[2].Value;
                } else if (SearchType == "SCHCODE" && ReturnForm == "ENDSHEET")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[2].Value;
                } else if (SearchType == "SCHCODE" && ReturnForm == "BIDS")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[3].Value;//bid id put in Invno
                }
                else if (SearchType == "SCHNAME" && (ReturnForm == "CUST" || ReturnForm == "MCUST"))

                {
                    //search on schname return code though
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();

                } else if (SearchType == "SCHNAME" && (ReturnForm == "SALES" || ReturnForm == "MSALES"))
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[2].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[1].Value;

                } else if (SearchType == "SCHNAME" && ReturnForm == "PRODUCTION") {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[2].Value;

                } else if (SearchType == "SCHNAME" && ReturnForm == "BIDS")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[3].Value;
                }
                else if (SearchType == "SCHNAME" && ReturnForm == "ENDSHEET")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[2].Value;
                }
                else if (SearchType == "JobNo" && ReturnForm == "CUST") {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[2].Value;

                }
                else if (SearchType == "JOBNO" && (ReturnForm == "SALES" || ReturnForm == "PRODUCTION"))
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[3].Value;

                }
                else if (SearchType == "JOBNO" && ReturnForm == "ENDSHEET")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[2].Value;
                }

                else if (SearchType == "ORACLECODE" && (ReturnForm == "CUST" || ReturnForm == "MCUST"))

                {
                    //search on schname return code though
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();
                } else if (SearchType == "ORACLECODE" && (ReturnForm == "SALES" || ReturnForm == "MSALES"))
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[3].Value;
                } else if (SearchType == "ORACLECODE" && ReturnForm == "PRODUCTION")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[3].Value;
                }
                else if (SearchType == "PRODNO" && (ReturnForm == "CUST" || ReturnForm == "MCUST"))
                {
                    //search on schname return code though
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[3].Value.ToString();
                } else if (SearchType == "PRODNO" && ReturnForm == "PRODUCTION")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[3].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[1].Value;
                } else if (SearchType == "PRODNO" && ReturnForm == "SALES") {
                    
                        this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[3].Value.ToString();
                        this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[1].Value;
                    

                } else if (SearchType == "INVNO" && (ReturnForm == "CUST" || ReturnForm == "MCUST"))
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[2].Value.ToString();
                } else if (SearchType == "INVNO" && (ReturnForm == "SALES" || ReturnForm == "MSALES"))
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[2].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[0].Value;
                } else if (SearchType == "INVNO" && ReturnForm == "PRODUCTION")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[2].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[0].Value;
                }
                else if (SearchType == "INVNO" && ReturnForm == "ENDSHEET")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[2].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[0].Value;
                }
                else if (SearchType == "FIRSTNAME" && (ReturnForm == "CUST" || ReturnForm == "MCUST"))
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[3].Value.ToString();
                }
                else if (SearchType == "LASTNAME" && (ReturnForm == "CUST" || ReturnForm == "MCUST"))
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[3].Value.ToString();
                }
                else if (SearchType == "ZIPCODE" && (ReturnForm == "CUST" || ReturnForm == "MCUST"))
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[3].Value.ToString();
                } else if (SearchType == "EMAIL" && (ReturnForm == "CUST" || ReturnForm == "MCUST"))
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[2].Value.ToString();
                }


                //

                this.Close();

            }

        }

        private void dgSearch_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            txtSearch.SelectionStart = txtSearch.Text.Length;

            CurrentIndex = e.RowIndex;
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            try
            {
                if (SearchType == "PRODNO")
                {
                    string sVal = dgSearch.Rows[CurrentIndex].Cells[0].Value == null ? "" : dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
                    txtSearch.Text = sVal.Substring(1);
                }
                else
                {
                    txtSearch.Text = dgSearch.Rows[CurrentIndex].Cells[0].Value == null ? "" : dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                txtSearch.Text = "";
            }
            txtSearch.SelectionStart = txtSearch.Text.Length;
        }
        private void dgSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            //tabs 1 row so take row back off
            if (e.KeyChar == 13)
            {
               CurrentIndex = dgSearch.CurrentCell.RowIndex-1;
                txtSearch_KeyPress(sender, e);
            }
        }
        private void dgSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            char a =(char)13;
            KeyPressEventArgs ee = new KeyPressEventArgs(a);

            txtSearch_KeyPress(sender, ee);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }
    }
   

}
