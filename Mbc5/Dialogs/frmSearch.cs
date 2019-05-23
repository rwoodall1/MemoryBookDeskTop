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
namespace Mbc5.Forms.MemoryBook {
    public partial class frmSearch : Form
    {
        public frmSearch(string vSearchType, string vForm, string vcurrentSearchValue)
        {
            this.SearchType = vSearchType.ToUpper();
            this.ReturnForm = vForm.ToUpper();
            currentSearchValue = vcurrentSearchValue.Trim();
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
        private List<OracleCodeSearch> OracleCodeList { get; set; }
        private List<ProdNoSearch> ProdutnNoList { get; set; }
        private List<InvnoSearch> InvnoList { get; set; }
        private List<FirstNameSearch> FirstNameList { get; set; }
        private List<LastNameSearch> LastNameList { get; set; }
        private List<ZipCodeSearch> ZipeCodeList { get; set; }
        private List<EmailSearch> EmailList { get; set; }
        private List<SchcodeSalesSearch> SaleSchoolCodeList { get; set; }
        private List<OracleSalesSearch> OracleSalesCodeList { get; set; }
        public ReturnValues ReturnValue { get; set; }

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
                        case "SALES":
                            cmdtext = @"Select C.Schcode,C.Schname,Q.Invno,C.OracleCode,C.Contryear,C.SchZip,C.SchState From Cust C LEFT JOIN Quotes Q on C.Schcode=Q.Schcode Order By Schcode";
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
                          
                            break;
                        case "BIDS":
                            
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
                        case "SALES":
                            break;
                        case "PRODUCTION":
                            break;
                        case "BIDS":
                            break;
                    }
                    break;
                case "ORACLECODE":
                    this.Text = "Oracle Code Search";
                    switch (ReturnForm)
                    {
                        case "CUST":
                            
                                cmdtext = @"Select C.OracleCode,C.Schname,C.Schcode,C.Contryear,C.SchZip,C.SchState From Cust C Order By OracleCode";
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
                            
                        case "SALES":
                            cmdtext = @"Select C.OracleCode,C.Schname,C.Schcode,Q.Invno As InvoiceNo,C.Contryear,C.SchZip,C.SchState From Cust C Left Join Qoutes Q On C.Schcode=Q.Schcode Order By OracleCode";
                            sqlclient.CommandText(cmdtext);
                            var oracleCodeResult = sqlclient.SelectMany<OracleSalesSearch>();
                            if (oracleCodeResult.IsError)
                            {
                                MbcMessageBox.Error(oracleCodeResult.Errors[0].ErrorMessage, "Error");
                                return;
                            }
                            var lOracleCodeList = (List<OracleSalesSearch>)oracleCodeResult.Data;
                            this.OracleSalesCodeList = lOracleCodeList;
                            bsData.DataSource = this.OracleCodeList;

                            dgSearch.DataSource = bsData.DataSource;

                            txtSearch.Select();

                            break;
                        case "PRODUCTION":
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
                            break;
                        case "SALES":
                            break;
                        case "PRODUCTION":
                            break;
                    }
                    break;
                case "INVNO":
                    this.Text = "Invoice # Search";
                    switch (ReturnForm)
                    {
                        case "CUST":
                            cmdtext = @"Select Q.Invno,C.Schname,C.Schcode,C.OracleCode,C.Contryear,C.SchZip,C.SchState From Quotes Q Left JOIN Cust C On Q.Schcode=C.Schcode Order By Invno";
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
                            break;
                        case "PRODUCTION":
                            break;
                    }
                    break;
                case "PRODUTNNO":
                    switch (ReturnForm)
                    {
                        case "CUST":
                            cmdtext = @"Select RTrim(P.ProdNo)AS ProdNo,P.Invno,C.Schname,C.Schcode,C.Contryear From Produtn P Left Join Cust C On P.Schcode=C.Schcode Order By ProdNo";
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
                        case "SALES":
                            break;
                        case "PRODUCTION":
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

                    }

                    break;
                 
            }
            this.dgSearch.Columns[0].Width = 125;
            this.Cursor = Cursors.Default;
            txtSearch.Text = currentSearchValue;
            Search(currentSearchValue);
        }
        private void Search(string value)
        {
            int vIndex;
            switch (SearchType)
            {

                case "SCHCODE":

                    try
                    {
                        vIndex = this.CustCode.FindIndex(vcust => vcust.Schcode.ToString().Trim().ToUpper().StartsWith(value.ToUpper()));
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

                    try
                    {
                        vIndex = this.CustName.FindIndex(vcust => vcust.Schname.ToString().Trim().ToUpper().StartsWith(value.ToUpper()));
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


                    try
                    {

                        var vIndex1 = this.OracleCodeList.FindIndex(vcust => vcust.OracleCode != null && vcust.OracleCode.ToString().Trim().ToUpper().StartsWith(value.ToUpper()));
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
                case "PRODUTNNO":

                    try
                    {
                        //value is trimmed to 5 spaces, binding is took out
                        vIndex = this.ProdutnNoList.FindIndex(vcust => vcust.ProdNo != null && vcust.ProdNo.Substring(1).ToUpper().StartsWith(value.ToUpper()));
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

                    try
                    {
                        //value is trimmed to 5 spaces, binding is took out
                        vIndex = this.InvnoList.FindIndex(vcust => vcust.Invno != 0 && vcust.Invno.ToString().StartsWith(value.ToUpper()));
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
                        //value is trimmed to 5 spaces, binding is took out
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
                        //value is trimmed to 5 spaces, binding is took out
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            Search(txtSearch.Text);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.DialogResult = DialogResult.OK;
                //cust form
                if (SearchType == "SCHCODE" && ReturnForm == "CUST")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
                }else if (SearchType == "SCHCODE" && ReturnForm == "Sales")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
                    this.ReturnValue.Invno = (int) dgSearch.Rows[CurrentIndex].Cells[0].Value;
                }
                else if (SearchType == "SCHNAME" && ReturnForm == "CUST")
                
                {
                    //search on schname return code though
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();

                }else if (SearchType == "SCHNAME" && ReturnForm == "SALES")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();

                } else if (SearchType == "ORACLECODE" && ReturnForm == "CUST")
               
                {
                    //search on schname return code though
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();
                }else if (SearchType == "ORACLECODE" && ReturnForm == "SALES")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
                    this.ReturnValue.Invno = (int)dgSearch.Rows[CurrentIndex].Cells[3].Value;
                }
                else if (SearchType == "PRODUTNNO" && ReturnForm == "CUST")
                {
                    //search on schname return code though
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[3].Value.ToString();
                }
                else if (SearchType == "INVNO" && ReturnForm == "CUST")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[2].Value.ToString();
                }
                else if (SearchType == "FIRSTNAME" && ReturnForm == "CUST")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[3].Value.ToString();
                }
                else if (SearchType == "LASTNAME" && ReturnForm == "CUST")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[3].Value.ToString();
                }
                else if (SearchType == "ZIPCODE" && ReturnForm == "CUST")
                {
                    this.ReturnValue.Schcode = dgSearch.Rows[CurrentIndex].Cells[3].Value.ToString();
                }else if (SearchType == "EMAIL" && ReturnForm == "CUST")
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
                if (SearchType == "PRODUTNNO")
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
                txtSearch_KeyPress(sender, e);
            }
        }

        private void dgSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            char a =(char)13;
            KeyPressEventArgs ee = new KeyPressEventArgs(a);

            txtSearch_KeyPress(sender, ee);
        }
    }
   

}
