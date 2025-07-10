using BaseClass;
using BaseClass.Classes;
using BaseClass.Core;
using BindingModels;
using Exceptionless;
using Mbc5.Classes;
using Microsoft.Reporting.WinForms;
using RESTModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mbc5.Forms
{
    public partial class frmBarScan : BaseClass.frmBase
    {
        public frmBarScan(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {

            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        string Company { get; set; }
        UserPrincipal ApplicationUser { get; set; }
        MbcBarScanModel MbcModel { get; set; }
        MerBarScanModel MerModel { get; set; }
        MixBookBarScanModel MbxModel { get; set; }
        JPIXBarScanModel JPIXModel { get; set; }
        private void SetConnectionString()
        {
            frmMain frmMain = (frmMain)this.MdiParent;

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(txtDeptCode.Text) && !string.IsNullOrEmpty(txtDept.Text))
            {
                MbcMessageBox.Hand("You can scan either Item 2 or Item 6, NOT both. Please RE-SCAN.", "One Department per Scan");
                return;
            }
            string company = txtBarCode.Text.Substring(0, 3);
            //Insert prodtrk here
            if (company == "MBC" && this.Validate())
            {
                MbcScan();
            }
            if (company == "MER" && this.Validate())
            {
                MerScan();
            }
            if (company == "JPX" && this.Validate())
            {
                txtRef.Visible = false;
                lblRef.Visible = false;
                JPXScan();
            }

        }

        private void txtDeptCode_Leave(object sender, EventArgs e)
        {
            pnlPressNumber.Visible = false;
            if (txtBarCode.Text.Length < 10)
            {
                return;
            }
            string trkType = txtBarCode.Text.Substring(txtBarCode.Text.Length - 2, 2);

            switch (trkType)
            {
                case "YB":
                    switch (txtDeptCode.Text.Trim())
                    {
                        case "29":
                            {
                                lblCopies.Visible = true;
                                txtCopies.Visible = true;
                                txtIntitials.Mask = ">LLL####";
                                pnlPressNumber.Visible = true;
                                break;
                            }
                        case "32":
                            {
                                txtIntitials.Mask = ">LLL####";
                                break;
                            }
                        case "33":
                            {
                                txtIntitials.Mask = ">LLL####";
                                break;
                            }
                        case "34":
                            {
                                txtIntitials.Mask = ">LLL####";
                                break;
                            }
                        case "35":
                            {
                                txtIntitials.Mask = ">LLL####";
                                break;
                            }
                        case "36":
                            {
                                txtIntitials.Mask = ">LLL####";
                                break;
                            }
                        case "37":
                            {
                                txtIntitials.Mask = ">LLL####";
                                break;
                            }
                        case "38":
                            {
                                txtIntitials.Mask = ">LLL####";
                                break;
                            }
                        default:
                            {
                                txtIntitials.Mask = ">LLL";
                                break;
                            }

                    }
                    break;

                case "SC":
                    switch (txtDeptCode.Text)
                    {
                        case "LAM1":
                            {
                                lblCopies.Visible = true;
                                txtCopies.Visible = true;
                                txtIntitials.Mask = ">LLL####";
                                break;
                            }
                        case "LAM2":
                            {
                                txtIntitials.Mask = ">LLL####";
                                break;
                            }
                        case "29":
                            {
                                txtIntitials.Mask = ">LLL####";
                                pnlPressNumber.Visible = true;
                                break;
                            }
                        case "37":
                            {
                                txtIntitials.Mask = ">LLL####";
                                break;
                            }
                        default:
                            {
                                txtIntitials.Mask = ">LLL";
                                break;
                            }
                    }
                    break;
                default:
                    txtIntitials.Mask = ">LLL";
                    break;


            }
        }

        private void txtBarCode1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBarCode_Leave(object sender, EventArgs e)
        {
            string vInvno = "";
            try
            {
                this.Company = txtBarCode.Text.Substring(0, 3);
                if (this.Company == "MXB")
                {
                    //expecting MXB1111111YB

                    vInvno = txtBarCode.Text.Substring(3, txtBarCode.Text.Length - 5);
                }
                else if (this.Company == "JPX")
                {
                    vInvno = txtBarCode.Text.Substring(3);
                    txtRef.Visible = true;
                    lblRef.Visible = true;
                }
                else
                {
                    if (txtBarCode.Text.Length == 12)
                    {
                        vInvno = txtBarCode.Text.Substring(4, txtBarCode.Text.Length - 6);
                    }
                    else if (txtBarCode.Text.Length == 11)
                    {
                        vInvno = txtBarCode.Text.Substring(4, txtBarCode.Text.Length - 4);
                    }

                    else
                    {
                        MbcMessageBox.Error("Scan code is not in correct format");
                        return;
                    }
                }

                int parsedInvno = 0;

                var parseResult = int.TryParse(vInvno, out parsedInvno);
                this.Invno = parsedInvno;
                if (!parseResult)
                {
                    MessageBox.Show("Invalid scan code");
                    return;
                }
                var sqlQuery = new SQLCustomClient();
                switch (this.Company)
                {
                    case "MBC":
                        {
                            string cmdText = @"
                        SELECT C.Schname,C.SchCode,RTrim(LTrim(C.SchEmail))As SchEmail,RTRim(LTrim(C.ContEmail))AS ContEmail,RTrim(LTrim(C.BContEmail))As BContEmail,RTrim(LTrim(C.CContEmail))AS CContEmail,CV.Specovr,P.ProdNo,W.CpNum,Q.Invno
                            From Cust C
                            Left Join Quotes Q On C.Schcode=Q.Schcode
                            Left Join Covers CV On Q.Invno=CV.Invno
                            Left Join Produtn P On Q.Invno=P.Invno
                            Left Join Wipg W On Q.Invno=W.Invno
                            Where Q.Invno=@Invno
                          ";
                            sqlQuery.CommandText(cmdText);
                            sqlQuery.AddParameter("@Invno", Invno);
                            var result = sqlQuery.Select<MbcBarScanModel>();
                            if (result.IsError)
                            {
                                MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            MbcModel = (MbcBarScanModel)result.Data;

                            if (result.Data == null)
                            {
                                MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            txtSchcode.Text = MbcModel.SchCode;
                            txtSchoolName.Text = MbcModel.Schname;
                            txtCoverNumber.Text = MbcModel.Specovr;
                            txtColorPageNumber.Text = MbcModel.CpNum;
                            txtProdNumber.Text = MbcModel.ProdNo;
                            txtDateTime.Text = DateTime.Now.ToString();

                            break;
                        }
                    case "MER":
                        {
                            string cmdText = @"
                        SELECT C.Schname,C.SchCode,RTrim(LTrim(C.SchEmail))AS SchEmail,RTrim(LTrim(C.ContEmail))AS ContEmail,RTrim(LTrim(C.BContEmail))AS BContEmail,CV.Specovr,P.ProdNo,Q.Invno
                            From MCust C
                            Left Join MQuotes Q On C.Schcode=Q.Schcode
                            Left Join Covers CV On Q.Invno=CV.Invno
                            Left Join Produtn P On Q.Invno=P.Invno
                           
                            Where Q.Invno=@Invno
                          ";
                            sqlQuery.CommandText(cmdText);
                            sqlQuery.AddParameter("@Invno", Invno);
                            var result = sqlQuery.Select<MerBarScanModel>();
                            if (result.IsError)
                            {
                                MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            MerModel = (MerBarScanModel)result.Data;

                            if (result.Data == null)
                            {
                                MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            txtSchcode.Text = MerModel.SchCode;
                            txtSchoolName.Text = MerModel.Schname;
                            txtCoverNumber.Text = MerModel.Specovr;
                            txtColorPageNumber.Text = "";
                            txtProdNumber.Text = MerModel.ProdNo;
                            txtDateTime.Text = DateTime.Now.ToString();
                            break;
                        }

                    case "JPX":
                        {
                            string cmdText = @"
                            SELECT JO.ShipToCustomerName,JO.OracleCode,JO.Reference,JO.Invno,JO.Quantity,P.ProdNo
                                From JPIXOrders JO Left Join Produtn P ON JO.Invno=P.Invno 
                                Where JO.Invno=@Invno
                              ";
                            sqlQuery.CommandText(cmdText);
                            sqlQuery.AddParameter("@Invno", Invno);
                            var result = sqlQuery.Select<JPIXBarScanModel>();
                            if (result.IsError)
                            {
                                MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            JPIXModel = (JPIXBarScanModel)result.Data;

                            if (result.Data == null)
                            {
                                MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            txtSchcode.Text = JPIXModel.OracleCode;
                            txtSchoolName.Text = JPIXModel.ShipToCustomerName;
                            txtProdNumber.Text = JPIXModel.ProdNo;
                            txtDateTime.Text = DateTime.Now.ToString();
                            txtRef.Text = JPIXModel.Reference.ToString();


                            break;

                        }
                    case "MXB":
                        {
                            string cmdText = @"
                            SELECT M.ShipName,M.ClientOrderId,M.ItemId,M.JobId,M.Invno,M.ShipMethod,M.Copies As Quantity,P.ProdNo,C.Specovr
                                From MixBookOrder M Left Join Produtn P ON M.Invno=P.Invno Left Join Covers C ON M.Invno=C.Invno
                                Where M.Invno=@Invno
                              ";
                            sqlQuery.CommandText(cmdText);
                            sqlQuery.AddParameter("@Invno", Invno);
                            var result = sqlQuery.Select<MixBookBarScanModel>();
                            if (result.IsError)
                            {
                                MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            MbxModel = (MixBookBarScanModel)result.Data;

                            if (result.Data == null)
                            {
                                MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            txtSchcode.Text = MbxModel.JobId;
                            txtSchoolName.Text = MbxModel.ShipName;
                            txtCoverNumber.Text = MbxModel.Specovr;
                            txtColorPageNumber.Text = "";
                            txtProdNumber.Text = MbxModel.ProdNo;
                            txtDateTime.Text = DateTime.Now.ToString();

                            if (this.ApplicationUser.UserName.ToUpper() != "Shipping")
                            {
                                this.Enabled = false;
                                timer1.Start();
                            }
                            else if (this.ApplicationUser.UserName.ToUpper() == "Shipping")
                            {
                                this.plnTracking.Visible = true;
                                this.txtTrackingNo.Focus();
                            }


                            break;

                        }

                }
            }

            catch (Exception ex) { }
            ;
        }
        #region "Methods"
        private void MbcScan()
        {
            int vDeptCode = 0;
            string trkType = txtBarCode.Text.Substring(txtBarCode.Text.Length - 2, 2);
            string company = txtBarCode.Text.Substring(0, 3);
            var vDateTime = DateTime.Now;

            decimal vWtr = 0;
            int.TryParse(txtDeptCode.Text, out vDeptCode);
            var vWIR = txtIntitials.Text;
            try { vWtr = decimal.Parse(txtTime.Text); } catch { }
            ;
            try { vDateTime = DateTime.Parse(txtDateTime.Text); } catch { }
            ;
            var sqlClient = new SQLCustomClient();


            if (trkType == "YB")
            {
                if (vDeptCode != 0)
                {
                    switch (vDeptCode.ToString())
                    {
                        //May have to change this id.
                        //ToPROD
                        case "51":
                            {
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@ToProd", vDateTime);
                                sqlClient.CommandText(@"Update Produtn SET ToPro=@ToProd Where Invno=@Invno");

                                try
                                {
                                    var result12 = sqlClient.Update();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                sqlClient.ClearParameters();
                                sqlClient.AddParameter("@i_toprod", vWIR);
                                sqlClient.AddParameter("@t_toprod", vWtr);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"UPDATE Wip Set i_toprod=@i_toprod,t_toprod=t_toprod+@t_toprod where Invno=@Invno");
                                try
                                {
                                    sqlClient.Update();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                break;
                            }
                        case "41":
                            {

                                //on hold
                                //war 41
                                //war is datetime
                                //wir is initials
                                //over write war
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", 0);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@"Update WIPDetail SET
                                 
                                      WAR= @WAR                                
                                    , WIR =@WIR
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                     ,WTR=@Wtr+COALESCE(WTR,0)
                                WHERE Invno=@Invno AND DescripID=@DescripID ");
                                var result = sqlClient.Update();
                                sqlClient.ClearParameters();
                                sqlClient.ReturnSqlIdentityId(true);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO WipDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                                    END
                                                    ");
                                var result1 = sqlClient.Insert();



                                break;
                            }
                        default:
                            {
                                //war is datetime
                                //wir is initials
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                     ,WTR=@Wtr+COALESCE(WTR,0)
                                WHERE Invno=@Invno AND DescripID=@DescripID ");
                                try { var result = sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                sqlClient.ClearParameters();
                                sqlClient.ReturnSqlIdentityId(true);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO WipDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                                    END
                                                    ");

                                var result1 = sqlClient.Insert();
                                if (result1.IsError)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                if (vDeptCode == 40)//40 is ship in wip derscr wiptable
                                {
                                    sqlClient.ClearParameters();
                                    sqlClient.CommandText(@"Update produtn SET produtn.shpdate=@Shpdate where Invno=@Invno");
                                    sqlClient.AddParameter("@Invno", Invno);
                                    sqlClient.AddParameter("Shpdate", vDateTime);
                                    var shpdateResult = sqlClient.Update();
                                    if (shpdateResult.IsError)
                                    {
                                        MbcMessageBox.Error(shpdateResult.Errors[0].ErrorMessage);
                                        return;
                                    }
                                    ShippedEmail("MBC");

                                }
                                if (vDeptCode.ToString() == "29")
                                {
                                    sqlClient.CommandText(@"Update Wip Set PressNumber=@PressNumber where Invno=@Invno");
                                    sqlClient.ClearParameters();
                                    sqlClient.AddParameter("@PressNumber", txtPressNumber.Text);
                                    sqlClient.AddParameter("@Invno", Invno);
                                    var war29Update = sqlClient.Update();
                                    if (war29Update.IsError)
                                    {
                                        MbcMessageBox.Error("Failed to update press number");
                                        return;
                                    }

                                }

                                break;
                            }

                    }
                }
                else
                {
                    bool runUpdate = false;
                    switch (txtInOut.Text)
                    {
                        case "HIN":
                            sqlClient.AddParameter("@HIN", vDateTime);
                            sqlClient.AddParameter("@HDept", txtDept.Text);
                            sqlClient.AddParameter("@HInit", txtIntitials.Text);
                            sqlClient.AddParameter("@HOut", null);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET hin=@HIN,hdept=@HDept,hinit=@Hinit,hout=@Hout  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "HOT":
                            sqlClient.AddParameter("@HDept", txtDept.Text);
                            sqlClient.AddParameter("@HInit", txtIntitials.Text);
                            sqlClient.AddParameter("@HOut", vDateTime);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET hdept=@HDept,hinit=@Hinit,hout=@Hout  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "TOV":
                            sqlClient.AddParameter("@tovend", vDateTime);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE Produtn SET tovend =@tovend  WHERE Invno=@Invno");
                            try { sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            MessageBox.Show("This function is obsolete, contact your supervisor if you feel this is not correct.");
                            //VFP code was refrerencing fields that did not exist. Figure it was not being used or would have heard about it. Second part of code has been omitted here.
                            //VFP code:sele vendor
                            //set order to vendcd
                            //mdept = alltrim(m.deptvend)
                            //seek mdept
                            //if found()
                            //repl wip.dfrmvend with m.datio2 + vendor.vchrno
                            //endif
                            runUpdate = true;
                            break;
                        case "FRB":
                            sqlClient.AddParameter("@binddte ", vDateTime);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET binddte=@binddte  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "FRV":
                            sqlClient.AddParameter("@afrmvend", vDateTime);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET afrmvend=@afrmvend  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "TOB":
                            sqlClient.AddParameter("@frmbind", vDateTime);
                            sqlClient.AddParameter("@bindvend", txtDept.Text);
                            sqlClient.AddParameter("@binddte", null);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET frmbind=@frmbind,bindvend=@bindvend,binddte=@binddte WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "ICI":
                            sqlClient.AddParameter("@iin", vDateTime);
                            sqlClient.AddParameter("@idept", txtDept.Text);
                            sqlClient.AddParameter("@iinit", txtIntitials.Text);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET iin =@iin,idept=@idept,iinit=@iinit  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "ICO":
                            sqlClient.AddParameter("@iout", vDateTime);
                            sqlClient.AddParameter("@iin", null);
                            sqlClient.AddParameter("@idept", txtDept.Text);
                            sqlClient.AddParameter("@iinit", txtIntitials.Text);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET iin =@iin,idept=@idept,iout=@iout,iinit=@iinit  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "TBK":
                            sqlClient.AddParameter("@rmbto", vDateTime);
                            sqlClient.AddParameter("@rmbfrm", null);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET rmbto=@rmbto,rmbfrm=@rmbfrm  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "FBK":

                            sqlClient.AddParameter("@rmbfrm", null);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET rmbfrm=@rmbfrm  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;

                        case "TPK":
                            sqlClient.AddParameter("@rmbto", vDateTime);
                            sqlClient.AddParameter("@rmbfrm", null);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET rmbto=@rmbto,rmbfrm=@rmbfrm  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "FPK":

                            sqlClient.AddParameter("@rmbfrm", vDateTime);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET rmbfrm=@rmbfrm  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;

                    }
                    if (runUpdate)
                    {
                        try { sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }

            }
            if (trkType == "CP")
            {
                MessageBox.Show("Under Construction");
                //switch (vDeptCode)
                //{
                //    //May have to change this id.
                //    //PROD
                //    case 1012:
                //        {
                //            sqlClient.AddParameter("@Invno", this.Invno);
                //            sqlClient.AddParameter("@ToProd", vDateTime);
                //            sqlClient.CommandText(@"Update WIPG SET ToPro=@ToProd Where Invno=@Invno");
                //            sqlClient.Update();

                //            break;
                //        }
                //    case 1000:
                //        { //CODE FOR LAM1 OR CASE
                //          //war 41
                //          //war is datetime
                //          //wir is initials

                //            //                           case alltrim(m.department) == 'LAM1'

                //            //       replace covers.lamdtesent with date()

                //            //       IF !EMPTY(ALLTRIM(covers.lamvend))

                //            //       ncopies = VAL(covers.lamvend)

                //            //       ELSE
                //            //       ncopies = 0

                //            //       ENDIF
                //            //       nval = ncopies + VAL(thisform.txtcopies.Value)

                //            //       cval = ALLTRIM(STR(nval))

                //            //       replace covers.lamvend WITH cval && lamvend is now being used as number of copies but is a character field.
                //            //* !*replace produtn.laminated WITH thisform.txtlamtype.value
                //            //replace covers.laminit WITH thisform.txtinit.value

                //            //       thisform.txtcopies.Visible =.f.
                //            //       thisform.txtcopies.Value = ""

                //            //       thisform.lblcopies.Visible =.f.


                //            //Case alltrim(m.department)== 'LAM2'

                //            //replace covers.lamdtebk with date()

                //            //replace covers.lamvend with substr(m.t_init, 4, 4)

                //            sqlClient.AddParameter("@lamdtesent", DateTime.Now);
                //            sqlClient.AddParameter("@init", txtIntitials.Text.Trim());
                //            int vCopies = 0;
                //            int.TryParse(txtCopies.Text, out vCopies);
                //            sqlClient.AddParameter("@lamcopies", vCopies);

                //            sqlClient.AddParameter("@DescripID", vDeptCode);
                //            sqlClient.AddParameter("@WAR", vDateTime);
                //            sqlClient.AddParameter("@WIR", vWIR);
                //            sqlClient.AddParameter("@Wtr", vWtr);
                //            sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                //            sqlClient.CommandText(@"Update Covers SET
                //                     lamdtesent=GETDATE(),
                //                      laminit=@init, 
                //                      lamcopies=COALESCE(lamcopies,0) +@lamcopies

                //                WHERE Invno=@Invno AND DescripID=@DescripID ");
                //            var result = sqlClient.Update();
                //            sqlClient.ClearParamters();
                //            sqlClient.ReturnSqlIdentityID(true);
                //            sqlClient.AddParameter("@Invno", this.Invno);
                //            sqlClient.AddParameter("@DescripID", vDeptCode);
                //            sqlClient.AddParameter("@WAR", vDateTime);
                //            sqlClient.AddParameter("@WIR", vWIR);
                //            sqlClient.AddParameter("@Wtr", vWtr);
                //            sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                //            sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                //                                    Begin
                //                                    INSERT INTO CoverDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                //                                    END
                //                                    ");
                //            var result1 = sqlClient.Insert();
                //            break;
                //        }
                //    default:
                //        {
                //            //war is datetime
                //            //wir is initials
                //            sqlClient.AddParameter("@Invno", this.Invno);
                //            sqlClient.AddParameter("@DescripID", vDeptCode);
                //            sqlClient.AddParameter("@WAR", vDateTime);
                //            sqlClient.AddParameter("@WIR", vWIR);
                //            sqlClient.AddParameter("@Wtr", vWtr);
                //            sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                //            sqlClient.CommandText(@"Update CoverDetail SET
                //                 WAR=
                //                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                //                    , WIR =
                //                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                //                     ,WTR=@Wtr+COALESCE(WTR,0)
                //                WHERE Invno=@Invno AND DescripID=@DescripID ");
                //            var result = sqlClient.Update();
                //            sqlClient.ClearParamters();
                //            sqlClient.ReturnSqlIdentityID(true);
                //            sqlClient.AddParameter("@Invno", this.Invno);
                //            sqlClient.AddParameter("@DescripID", vDeptCode);
                //            sqlClient.AddParameter("@WAR", vDateTime);
                //            sqlClient.AddParameter("@WIR", vWIR);
                //            sqlClient.AddParameter("@Wtr", vWtr);
                //            sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                //            sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                //                                    Begin
                //                                    INSERT INTO CoverDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                //                                    END
                //                                    ");
                //            var result1 = sqlClient.Insert();

                //            break;
                //        }

                //}
            }
            if (trkType == "SC")
            {
                if (vDeptCode != 0)
                {
                    switch (vDeptCode.ToString())
                    {
                        //May have to change this id.
                        //cover detail
                        case "1012":
                            {
                                MessageBox.Show("Function not found.");
                                //toprod
                                //sqlClient.AddParameter("@Invno", this.Invno);
                                //sqlClient.AddParameter("@Press", vDateTime);
                                //sqlClient.CommandText(@"Update Covers SET a.press=@Press, Where Invno=@Invno");
                                //sqlClient.Update();

                                break;
                            }
                        case "1000":
                            { //CODE FOR LAM1 OR CASE
                              //war 41
                              //war is datetime
                              //wir is initials
                                sqlClient.AddParameter("@lamdtesent", DateTime.Now);
                                sqlClient.AddParameter("@init", txtIntitials.Text.Trim());
                                int vCopies = 0;
                                int.TryParse(txtCopies.Text, out vCopies);
                                sqlClient.AddParameter("@lamcopies", vCopies);

                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@"Update Covers SET
                                                        lamdtesent=GETDATE(),
                                                        laminit=@init, 
                                                        lamcopies=COALESCE(lamcopies,0) +@lamcopies    
                                                        WHERE Invno=@Invno");

                                try
                                {
                                    var result = sqlClient.Update();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                                break;
                            }
                        case "1022":
                            { //CODE FOR LAM2 OR CASE
                              //war 41
                              //war is datetime
                              //wir is initials

                                string vInit = "";
                                if (txtIntitials.Text.Length >= 8)
                                {
                                    vInit = txtIntitials.Text.Substring(3, 4);
                                }
                                sqlClient.AddParameter("@lamvend", vInit);
                                int vCopies = 0;
                                int.TryParse(txtCopies.Text, out vCopies);
                                sqlClient.AddParameter("@lamcopies", vCopies);

                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@"Update Covers SET
                                                        lamdtebk =GETDATE(),
                                                        lamvend =@lamvend, 
                                                    WHERE Invno=@Invno");
                                try
                                {
                                    var result = sqlClient.Update();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }



                        default:
                            {
                                //war is datetime
                                //wir is initials
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@"Update CoverDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                     ,WTR=@Wtr+COALESCE(WTR,0)
                                WHERE Invno=@Invno AND DescripID=@DescripID ");
                                try
                                {
                                    var result = sqlClient.Update();
                                    if (result.IsError)
                                    {
                                        MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch (Exception ex)
                                {

                                }

                                sqlClient.ClearParameters();
                                sqlClient.ReturnSqlIdentityId(true);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO CoverDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                                    END
                                                    ");

                                try
                                {
                                    var result1 = sqlClient.Insert();
                                    if (result1.IsError)
                                    {
                                        MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                if (vDeptCode.ToString() == "29")
                                {
                                    sqlClient.CommandText(@"Update Covers Set PressNumber=@PressNumber where Invno=@Invno");
                                    sqlClient.ClearParameters();
                                    sqlClient.AddParameter("@PressNumber", txtPressNumber.Text);
                                    sqlClient.AddParameter("@Invno", Invno);
                                    var war29Update = sqlClient.Update();
                                    if (war29Update.IsError)
                                    {
                                        MbcMessageBox.Error("Failed to update press number");
                                        return;
                                    }

                                }
                                break;
                            }

                    }
                    ClearScan();
                }
                else
                {
                    bool runUpdate = false;
                    switch (txtInOut.Text.Trim())
                    {
                        case "TOV":
                            {
                                DateTime vPrtdtesent = DateTime.Now;
                                DateTime.TryParse(txtDateTime.Text, out vPrtdtesent);
                                sqlClient.AddParameter("@prtdtesent", vPrtdtesent);
                                sqlClient.AddParameter("@prtvend", txtDept.Text);

                                sqlClient.CommandText(@"Update Covers SET
                                                        prtdtesent=@prtdtesent,
                                                        prtvend=@lamvend, 
                                                    WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }
                        case "FRV":
                            {
                                DateTime vPrtdtebk = DateTime.Now;
                                DateTime.TryParse(txtDateTime.Text, out vPrtdtebk);
                                sqlClient.AddParameter("@prtdtebk", vPrtdtebk);
                                sqlClient.CommandText(@"Update Covers SET
                                                        prtdtebk =@prtdtebk,
                                                    WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }
                        case "FBK":
                            {
                                DateTime vReprntdte = DateTime.Now;
                                DateTime.TryParse(txtDateTime.Text, out vReprntdte);
                                sqlClient.AddParameter("@reprntdte", vReprntdte);
                                sqlClient.CommandText(@"Update Covers SET
                                                        reprntdte=@reprntdte,
                                                    WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }

                    }
                    if (runUpdate)
                    {
                        try
                        {
                            sqlClient.Update();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            if (trkType == "ED")
            {
                //war is datetime
                //wir is initials
                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.AddParameter("@DescripID", vDeptCode);
                sqlClient.AddParameter("@WAR", vDateTime);
                sqlClient.AddParameter("@WIR", vWIR);
                sqlClient.AddParameter("@Wtr", vWtr);
                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                sqlClient.CommandText(@"Update EndSheetDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                     ,WTR=@Wtr+COALESCE(WTR,0)
                                WHERE Invno=@Invno AND DescripID=@DescripID ");
                try { var result = sqlClient.Update(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                sqlClient.ClearParameters();
                sqlClient.ReturnSqlIdentityId(true);
                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.AddParameter("@DescripID", vDeptCode);
                sqlClient.AddParameter("@WAR", vDateTime);
                sqlClient.AddParameter("@WIR", vWIR);
                sqlClient.AddParameter("@Wtr", vWtr);
                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from EndSheetDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO EndSheetDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                                    END
                                                    ");
                try { var result1 = sqlClient.Insert(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (trkType == "BN")
            {


                // war is datetime
                //wir is initials
                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.AddParameter("@DescripID", vDeptCode);
                sqlClient.AddParameter("@WAR", vDateTime);
                sqlClient.AddParameter("@WIR", vWIR);
                sqlClient.AddParameter("@Wtr", vWtr);
                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                sqlClient.CommandText(@"Update BannerDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                     ,WTR=@Wtr+COALESCE(WTR,0)
                                WHERE Invno=@Invno AND DescripID=@DescripID ");
                try { var result = sqlClient.Update(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                sqlClient.ClearParameters();
                sqlClient.ReturnSqlIdentityId(true);

                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.AddParameter("@DescripID", vDeptCode);
                sqlClient.AddParameter("@WAR", vDateTime);
                sqlClient.AddParameter("@WIR", vWIR);
                sqlClient.AddParameter("@Wtr", vWtr);
                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from BannerDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO BannerDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                                    END
                                                    ");
                try { var result1 = sqlClient.Insert(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (trkType == "PA")
            {
                if (vDeptCode != 0)
                {
                    // war is datetime
                    //wir is initials
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", vDeptCode);
                    sqlClient.AddParameter("@WAR", vDateTime);
                    sqlClient.AddParameter("@WIR", vWIR);
                    sqlClient.AddParameter("@Wtr", vWtr);
                    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                    sqlClient.CommandText(@"Update PartBKDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                     ,WTR=@Wtr+COALESCE(WTR,0)
                                WHERE Invno=@Invno AND DescripID=@DescripID ");
                    try { var result = sqlClient.Update(); }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", vDeptCode);
                    sqlClient.AddParameter("@WAR", vDateTime);
                    sqlClient.AddParameter("@WIR", vWIR);
                    sqlClient.AddParameter("@Wtr", vWtr);
                    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from PartBKDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO PartBKDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                                    END
                                                    ");
                    try { var result1 = sqlClient.Insert(); }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    bool runUpdate = false;
                    switch (txtInOut.Text.Trim())
                    {
                        case "ICI":
                            {

                                sqlClient.AddParameter("@iin", txtInOut.Text);
                                sqlClient.AddParameter("@idept", txtDept.Text);
                                sqlClient.AddParameter("@iinit", txtIntitials.Text);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"Update partbk SET
                                                        iin=@iin,
                                                        idept=@idept, 
                                                        iinit=@iinit
                                                    WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }
                        case "ICO":
                            {
                                sqlClient.AddParameter("@iout", vDateTime);
                                sqlClient.AddParameter("@iin", null);
                                sqlClient.AddParameter("@idept", txtDept.Text);
                                sqlClient.AddParameter("@iinit", txtIntitials.Text);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"Update partbk SET
                                                        iin=@iin,
                                                        idept=@idept,
                                                        iout=@iout,
                                                        iinit=@iinit
                                                    WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }


                    }
                    if (runUpdate)
                    {
                        try
                        {
                            sqlClient.Update();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            if (trkType == "PB")
            {
                if (vDeptCode != 0)
                {
                    switch (vDeptCode.ToString())
                    {
                        //May have to change this id.
                        //ToPROD
                        case "1012":
                            {


                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@patoprod", vDateTime);
                                sqlClient.AddParameter("@pitoprod", txtIntitials.Text);
                                sqlClient.AddParameter("@pttoprod", txtTime.Text);
                                sqlClient.CommandText(@"Update ptbkb SET patoprod=@patoprod,pitoprod=@pitoprod,pttoprod=@pttoprod Where Invno=@Invno");

                                try
                                {
                                    var result = sqlClient.Update();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }
                        default:
                            {
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@"Update prtbkbdetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                     ,WTR=@Wtr+COALESCE(WTR,0)
                                WHERE Invno=@Invno AND DescripID=@DescripID ");
                                try { var result = sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                sqlClient.ClearParameters();
                                sqlClient.ReturnSqlIdentityId(true);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from prtbkbdetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO prtbkbdetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                                    END
                                                    ");
                                try { var result1 = sqlClient.Insert(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                break;
                            }
                    }
                }
                else
                {
                    bool runUpdate = false;
                    switch (txtInOut.Text.Trim())
                    {
                        case "ICI":
                            {

                                sqlClient.AddParameter("@iin", txtInOut.Text);
                                sqlClient.AddParameter("@idept", txtDept.Text);
                                sqlClient.AddParameter("@iinit", txtIntitials.Text);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"Update ptbkb SET
                                                        iin=@iin,
                                                        idept=@idept, 
                                                        iinit=@iinit
                                                    WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }
                        case "ICO":
                            {
                                sqlClient.AddParameter("@iout", vDateTime);
                                sqlClient.AddParameter("@iin", null);
                                sqlClient.AddParameter("@idept", txtDept.Text);
                                sqlClient.AddParameter("@iinit", txtIntitials.Text);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"Update ptbkb SET
                                                        iin=@iin,
                                                        idept=@idept,
                                                        iout=@iout,
                                                        iinit=@iinit
                                                    WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }


                    }
                    if (runUpdate)
                    {
                        try
                        {
                            sqlClient.Update();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            if (trkType == "SP")
            {
                if (vDeptCode != 0)
                {

                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", vDeptCode);
                    sqlClient.AddParameter("@WAR", vDateTime);
                    sqlClient.AddParameter("@WIR", vWIR);
                    sqlClient.AddParameter("@Wtr", vWtr);
                    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                    sqlClient.CommandText(@"Update suppdetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                     ,WTR=@Wtr+COALESCE(WTR,0)
                                WHERE Invno=@Invno AND DescripID=@DescripID ");
                    try { var result = sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", vDeptCode);
                    sqlClient.AddParameter("@WAR", vDateTime);
                    sqlClient.AddParameter("@WIR", vWIR);
                    sqlClient.AddParameter("@Wtr", vWtr);
                    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from suppdetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO suppdetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                                    END
                                                    ");
                    try { var result1 = sqlClient.Insert(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
                else
                {
                    bool runUpdate = false;
                    switch (txtInOut.Text.Trim())
                    {
                        case "ICI":
                            {

                                sqlClient.AddParameter("@iin", vDateTime);
                                sqlClient.AddParameter("@bindvend", txtDept.Text);
                                sqlClient.AddParameter("@idept", txtDept.Text);
                                sqlClient.AddParameter("@iinit", txtIntitials.Text);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"Update suppl SET
                                                        iin=@iin,
                                                        bindvend=@bindvend,
                                                        idept=@idept, 
                                                        iinit=@iinit
                                                    WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }
                        case "ICO":
                            {
                                sqlClient.AddParameter("@iout", vDateTime);
                                sqlClient.AddParameter("@iin", null);
                                sqlClient.AddParameter("@idept", txtDept.Text);
                                sqlClient.AddParameter("@bindvend", txtDept.Text);
                                sqlClient.AddParameter("@iinit", txtIntitials.Text);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"Update suppl SET
                                                        iin=@iin,
                                                        idept=@idept,
                                                        iout=@iout,
                                                        bindvend=@bindvend,
                                                        iinit=@iinit
                                                    WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }


                    }
                    if (runUpdate)
                    {
                        try
                        {
                            sqlClient.Update();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }




            }
            if (trkType == "GS")
            {
                if (vDeptCode != 0)
                {

                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", vDeptCode);
                    sqlClient.AddParameter("@WAR", vDateTime);
                    sqlClient.AddParameter("@WIR", vWIR);
                    sqlClient.AddParameter("@Wtr", vWtr);
                    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                    sqlClient.CommandText(@"Update grshtdetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                     ,WTR=@Wtr+COALESCE(WTR,0)
                                WHERE Invno=@Invno AND DescripID=@DescripID ");
                    try { var result = sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", vDeptCode);
                    sqlClient.AddParameter("@WAR", vDateTime);
                    sqlClient.AddParameter("@WIR", vWIR);
                    sqlClient.AddParameter("@Wtr", vWtr);
                    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from grshtdetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO grshtdetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                                    END
                                                    ");
                    try { var result1 = sqlClient.Insert(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
                else
                {
                    bool runUpdate = false;
                    switch (txtInOut.Text.Trim())
                    {
                        case "ICI":
                            {

                                sqlClient.AddParameter("@iin", vDateTime);
                                sqlClient.AddParameter("@idept", txtDept.Text);
                                sqlClient.AddParameter("@iinit", txtIntitials.Text);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"Update grsht SET
                                                        iin=@iin,
                                                        idept=@idept, 
                                                        iinit=@iinit
                                                    WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }
                        case "ICO":
                            {
                                sqlClient.AddParameter("@iout", vDateTime);
                                sqlClient.AddParameter("@iin", null);
                                sqlClient.AddParameter("@idept", txtDept.Text);
                                sqlClient.AddParameter("@iinit", txtIntitials.Text);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"Update grsht SET
                                                        iin=@iin,
                                                        idept=@idept,
                                                        iout=@iout,
                                                        iinit=@iinit
                                                    WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }


                    }
                    if (runUpdate)
                    {
                        try
                        {
                            sqlClient.Update();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }


            }

            pnlPressNumber.Visible = false;
            MbcModel = null;
            ClearScan();
        }
        private void MerScan()
        {

            int vDeptCode = 0;
            string trkType = txtBarCode.Text.Substring(txtBarCode.Text.Length - 2, 2);
            string company = txtBarCode.Text.Substring(0, 3);
            var vDateTime = DateTime.Now;

            decimal vWtr = 0;
            int.TryParse(txtDeptCode.Text, out vDeptCode);
            var vWIR = txtIntitials.Text;
            try { vWtr = decimal.Parse(txtTime.Text); } catch { }
            ;
            try { vDateTime = DateTime.Parse(txtDateTime.Text); } catch { }
            ;
            var sqlClient = new SQLCustomClient();


            if (trkType == "YB")
            {
                if (vDeptCode != 0)
                {
                    switch (vDeptCode.ToString())
                    {
                        //May have to change this id.
                        //ToPROD
                        case "51":
                            {
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@ToProd", vDateTime);
                                sqlClient.CommandText(@"Update Produtn SET ToPro=@ToProd Where Invno=@Invno");

                                try
                                {
                                    var result12 = sqlClient.Update();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                sqlClient.ClearParameters();
                                sqlClient.AddParameter("@i_toprod", vWIR);
                                sqlClient.AddParameter("@t_toprod", vWtr);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"UPDATE Wip Set i_toprod=@i_toprod,t_toprod=t_toprod+@t_toprod where Invno=@Invno");
                                try
                                {
                                    sqlClient.Update();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                break;
                            }

                        default:
                            {
                                //war is datetime
                                //wir is initials
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@"Update WIPDetail SET
                        WAR=
                            CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                        , WIR =
                            CASE When WIR IS NULL THEN @WIR ELSE WIR END
                            ,WTR=@Wtr+COALESCE(WTR,0)
                    WHERE Invno=@Invno AND DescripID=@DescripID ");
                                try { var result = sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                sqlClient.ClearParameters();
                                sqlClient.ReturnSqlIdentityId(true);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                        Begin
                                        INSERT INTO WipDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                        END
                                        ");

                                var result1 = sqlClient.Insert();
                                if (result1.IsError)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                if (vDeptCode == 40)
                                {
                                    sqlClient.ClearParameters();
                                    sqlClient.CommandText(@"Update produtn SET produtn.shpdate= @Shpdate where Invno=@Invno");
                                    sqlClient.AddParameter("@Invno", Invno);
                                    sqlClient.AddParameter("Shpdate", vDateTime);
                                    var shpdateResult = sqlClient.Update();

                                    if (shpdateResult.IsError)
                                    {
                                        MbcMessageBox.Error(shpdateResult.Errors[0].ErrorMessage);
                                        return;
                                    }
                                    ShippedEmail("MER");

                                }
                                if (vDeptCode.ToString() == "29")
                                {
                                    sqlClient.CommandText(@"Update Wip Set PressNumber=@PressNumber where Invno=@Invno");
                                    sqlClient.ClearParameters();
                                    sqlClient.AddParameter("@PressNumber", txtPressNumber.Text);
                                    sqlClient.AddParameter("@Invno", Invno);
                                    var war29Update = sqlClient.Update();
                                    if (war29Update.IsError)
                                    {
                                        MbcMessageBox.Error("Failed to update press number");
                                        return;
                                    }

                                }

                                break;
                            }

                    }
                }
                else
                {
                    bool runUpdate = false;
                    switch (txtInOut.Text)
                    {
                        case "HIN":
                            sqlClient.AddParameter("@HIN", vDateTime);
                            sqlClient.AddParameter("@HDept", txtDept.Text);
                            sqlClient.AddParameter("@HInit", txtIntitials.Text);
                            sqlClient.AddParameter("@HOut", null);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET hin=@HIN,hdept=@HDept,hinit=@Hinit,hout=@Hout  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "HOT":
                            sqlClient.AddParameter("@HDept", txtDept.Text);
                            sqlClient.AddParameter("@HInit", txtIntitials.Text);
                            sqlClient.AddParameter("@HOut", vDateTime);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET hdept=@HDept,hinit=@Hinit,hout=@Hout  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "TOV":
                            sqlClient.AddParameter("@tovend", vDateTime);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE Produtn SET tovend =@tovend  WHERE Invno=@Invno");
                            try { sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            MessageBox.Show("This function is obsolete, contact your supervisor if you feel this is not correct.");
                            //VFP code was refrerencing fields that did not exist. Figure it was not being used or would have heard about it. Second part of code has been omitted here.
                            //VFP code:sele vendor
                            //set order to vendcd
                            //mdept = alltrim(m.deptvend)
                            //seek mdept
                            //if found()
                            //repl wip.dfrmvend with m.datio2 + vendor.vchrno
                            //endif
                            runUpdate = true;
                            break;
                        case "FRB":
                            sqlClient.AddParameter("@binddte ", vDateTime);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET binddte=@binddte  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "FRV":
                            sqlClient.AddParameter("@afrmvend", vDateTime);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET afrmvend=@afrmvend  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "TOB":
                            sqlClient.AddParameter("@frmbind", vDateTime);
                            sqlClient.AddParameter("@bindvend", txtDept.Text);
                            sqlClient.AddParameter("@binddte", null);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET frmbind=@frmbind,bindvend=@bindvend,binddte=@binddte WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "ICI":
                            sqlClient.AddParameter("@iin", vDateTime);
                            sqlClient.AddParameter("@idept", txtDept.Text);
                            sqlClient.AddParameter("@iinit", txtIntitials.Text);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET iin =@iin,idept=@idept,iinit=@iinit  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "ICO":
                            sqlClient.AddParameter("@iout", vDateTime);
                            sqlClient.AddParameter("@iin", null);
                            sqlClient.AddParameter("@idept", txtDept.Text);
                            sqlClient.AddParameter("@iinit", txtIntitials.Text);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET iin =@iin,idept=@idept,iout=@iout,iinit=@iinit  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "TBK":
                            sqlClient.AddParameter("@rmbto", vDateTime);
                            sqlClient.AddParameter("@rmbfrm", null);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET rmbto=@rmbto,rmbfrm=@rmbfrm  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "FBK":

                            sqlClient.AddParameter("@rmbfrm", null);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET rmbfrm=@rmbfrm  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;

                        case "TPK":
                            sqlClient.AddParameter("@rmbto", vDateTime);
                            sqlClient.AddParameter("@rmbfrm", null);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET rmbto=@rmbto,rmbfrm=@rmbfrm  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;
                        case "FPK":

                            sqlClient.AddParameter("@rmbfrm", vDateTime);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.CommandText(@"UPDATE WIP SET rmbfrm=@rmbfrm  WHERE Invno=@Invno");
                            runUpdate = true;
                            break;

                    }
                    if (runUpdate)
                    {
                        try { sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }

            }

            if (trkType == "SC")
            {
                if (vDeptCode != 0)
                {
                    switch (vDeptCode.ToString())
                    {
                        //May have to change this id.
                        //cover detail
                        case "1012":
                            {
                                MessageBox.Show("Function not found.");
                                //toprod
                                //sqlClient.AddParameter("@Invno", this.Invno);
                                //sqlClient.AddParameter("@Press", vDateTime);
                                //sqlClient.CommandText(@"Update Covers SET a.press=@Press, Where Invno=@Invno");
                                //sqlClient.Update();

                                break;
                            }
                        case "1000":
                            { //CODE FOR LAM1 OR CASE
                              //war 41
                              //war is datetime
                              //wir is initials
                                sqlClient.AddParameter("@lamdtesent", DateTime.Now);
                                sqlClient.AddParameter("@init", txtIntitials.Text.Trim());
                                int vCopies = 0;
                                int.TryParse(txtCopies.Text, out vCopies);
                                sqlClient.AddParameter("@lamcopies", vCopies);

                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@"Update Covers SET
                                            lamdtesent=GETDATE(),
                                            laminit=@init, 
                                            lamcopies=COALESCE(lamcopies,0) +@lamcopies    
                                            WHERE Invno=@Invno");

                                try
                                {
                                    var result = sqlClient.Update();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                                break;
                            }
                        case "1022":
                            { //CODE FOR LAM2 OR CASE
                              //war 41
                              //war is datetime
                              //wir is initials

                                string vInit = "";
                                if (txtIntitials.Text.Length >= 8)
                                {
                                    vInit = txtIntitials.Text.Substring(3, 4);
                                }
                                sqlClient.AddParameter("@lamvend", vInit);
                                int vCopies = 0;
                                int.TryParse(txtCopies.Text, out vCopies);
                                sqlClient.AddParameter("@lamcopies", vCopies);

                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@"Update Covers SET
                                            lamdtebk =GETDATE(),
                                            lamvend =@lamvend, 
                                        WHERE Invno=@Invno");
                                try
                                {
                                    var result = sqlClient.Update();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }



                        default:
                            {
                                //war is datetime
                                //wir is initials
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@"Update CoverDetail SET
                        WAR=
                            CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                        , WIR =
                            CASE When WIR IS NULL THEN @WIR ELSE WIR END
                            ,WTR=@Wtr+COALESCE(WTR,0)
                    WHERE Invno=@Invno AND DescripID=@DescripID ");
                                try
                                {
                                    var result = sqlClient.Update();
                                    if (result.IsError)
                                    {
                                        MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch (Exception ex)
                                {

                                }

                                sqlClient.ClearParameters();
                                sqlClient.ReturnSqlIdentityId(true);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@DescripID", vDeptCode);
                                sqlClient.AddParameter("@WAR", vDateTime);
                                sqlClient.AddParameter("@WIR", vWIR);
                                sqlClient.AddParameter("@Wtr", vWtr);
                                sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                        Begin
                                        INSERT INTO CoverDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                        END
                                        ");

                                try
                                {
                                    var result1 = sqlClient.Insert();
                                    if (result1.IsError)
                                    {
                                        MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                if (vDeptCode.ToString() == "29")
                                {
                                    sqlClient.CommandText(@"Update Covers Set PressNumber=@PressNumber where Invno=@Invno");
                                    sqlClient.ClearParameters();
                                    sqlClient.AddParameter("@PressNumber", txtPressNumber.Text);
                                    sqlClient.AddParameter("@Invno", Invno);
                                    var war29Update = sqlClient.Update();
                                    if (war29Update.IsError)
                                    {
                                        MbcMessageBox.Error("Failed to update press number");
                                        return;
                                    }

                                }
                                break;
                            }

                    }
                    ClearScan();
                }
                else
                {
                    bool runUpdate = false;
                    switch (txtInOut.Text.Trim())
                    {
                        case "TOV":
                            {
                                DateTime vPrtdtesent = DateTime.Now;
                                DateTime.TryParse(txtDateTime.Text, out vPrtdtesent);
                                sqlClient.AddParameter("@prtdtesent", vPrtdtesent);
                                sqlClient.AddParameter("@prtvend", txtDept.Text);

                                sqlClient.CommandText(@"Update Covers SET
                                            prtdtesent=@prtdtesent,
                                            prtvend=@lamvend, 
                                        WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }
                        case "FRV":
                            {
                                DateTime vPrtdtebk = DateTime.Now;
                                DateTime.TryParse(txtDateTime.Text, out vPrtdtebk);
                                sqlClient.AddParameter("@prtdtebk", vPrtdtebk);
                                sqlClient.CommandText(@"Update Covers SET
                                            prtdtebk =@prtdtebk,
                                        WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }
                        case "FBK":
                            {
                                DateTime vReprntdte = DateTime.Now;
                                DateTime.TryParse(txtDateTime.Text, out vReprntdte);
                                sqlClient.AddParameter("@reprntdte", vReprntdte);
                                sqlClient.CommandText(@"Update Covers SET
                                            reprntdte=@reprntdte,
                                        WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }

                    }
                    if (runUpdate)
                    {
                        try
                        {
                            sqlClient.Update();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            //reorder
            if (trkType == "GS")
            {
                if (vDeptCode != 0)
                {

                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", vDeptCode);
                    sqlClient.AddParameter("@WAR", vDateTime);
                    sqlClient.AddParameter("@WIR", vWIR);
                    sqlClient.AddParameter("@Wtr", vWtr);
                    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                    sqlClient.CommandText(@"Update grshtdetail SET
                        WAR=
                            CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                        , WIR =
                            CASE When WIR IS NULL THEN @WIR ELSE WIR END
                            ,WTR=@Wtr+COALESCE(WTR,0)
                    WHERE Invno=@Invno AND DescripID=@DescripID ");
                    try { var result = sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", vDeptCode);
                    sqlClient.AddParameter("@WAR", vDateTime);
                    sqlClient.AddParameter("@WIR", vWIR);
                    sqlClient.AddParameter("@Wtr", vWtr);
                    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from grshtdetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                        Begin
                                        INSERT INTO grshtdetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
                                        END
                                        ");
                    try { var result1 = sqlClient.Insert(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
                else
                {
                    bool runUpdate = false;
                    switch (txtInOut.Text.Trim())
                    {
                        case "ICI":
                            {

                                sqlClient.AddParameter("@iin", vDateTime);
                                sqlClient.AddParameter("@idept", txtDept.Text);
                                sqlClient.AddParameter("@iinit", txtIntitials.Text);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"Update grsht SET
                                            iin=@iin,
                                            idept=@idept, 
                                            iinit=@iinit
                                        WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }
                        case "ICO":
                            {
                                sqlClient.AddParameter("@iout", vDateTime);
                                sqlClient.AddParameter("@iin", null);
                                sqlClient.AddParameter("@idept", txtDept.Text);
                                sqlClient.AddParameter("@iinit", txtIntitials.Text);
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.CommandText(@"Update grsht SET
                                            iin=@iin,
                                            idept=@idept,
                                            iout=@iout,
                                            iinit=@iinit
                                        WHERE Invno=@Invno");
                                runUpdate = true;
                                break;
                            }


                    }
                    if (runUpdate)
                    {
                        try
                        {
                            sqlClient.Update();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }


            }



            //if (trkType == "SP")
            //{
            //    if (vDeptCode != 0)
            //    {

            //        sqlClient.AddParameter("@Invno", this.Invno);
            //        sqlClient.AddParameter("@DescripID", vDeptCode);
            //        sqlClient.AddParameter("@WAR", vDateTime);
            //        sqlClient.AddParameter("@WIR", vWIR);
            //        sqlClient.AddParameter("@Wtr", vWtr);
            //        sqlClient.AddParameter("@Schcode", txtSchcode.Text);
            //        sqlClient.CommandText(@"Update suppdetail SET
            //                     WAR=
            //                            CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
            //                        , WIR =
            //                          CASE When WIR IS NULL THEN @WIR ELSE WIR END
            //                         ,WTR=@Wtr+COALESCE(WTR,0)
            //                    WHERE Invno=@Invno AND DescripID=@DescripID ");
            //        try { var result = sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //        sqlClient.ClearParameters();
            //        sqlClient.ReturnSqlIdentityId(true);
            //        sqlClient.AddParameter("@Invno", this.Invno);
            //        sqlClient.AddParameter("@DescripID", vDeptCode);
            //        sqlClient.AddParameter("@WAR", vDateTime);
            //        sqlClient.AddParameter("@WIR", vWIR);
            //        sqlClient.AddParameter("@Wtr", vWtr);
            //        sqlClient.AddParameter("@Schcode", txtSchcode.Text);
            //        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from suppdetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
            //                                        Begin
            //                                        INSERT INTO suppdetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
            //                                        END
            //                                        ");
            //        try { var result1 = sqlClient.Insert(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            //    }
            //    else
            //    {
            //        bool runUpdate = false;
            //        switch (txtInOut.Text.Trim())
            //        {
            //            case "ICI":
            //                {

            //                    sqlClient.AddParameter("@iin", vDateTime);
            //                    sqlClient.AddParameter("@bindvend", txtDept.Text);
            //                    sqlClient.AddParameter("@idept", txtDept.Text);
            //                    sqlClient.AddParameter("@iinit", txtIntitials.Text);
            //                    sqlClient.AddParameter("@Invno", this.Invno);
            //                    sqlClient.CommandText(@"Update suppl SET
            //                                            iin=@iin,
            //                                            bindvend=@bindvend,
            //                                            idept=@idept, 
            //                                            iinit=@iinit
            //                                        WHERE Invno=@Invno");
            //                    runUpdate = true;
            //                    break;
            //                }
            //            case "ICO":
            //                {
            //                    sqlClient.AddParameter("@iout", vDateTime);
            //                    sqlClient.AddParameter("@iin", null);
            //                    sqlClient.AddParameter("@idept", txtDept.Text);
            //                    sqlClient.AddParameter("@bindvend", txtDept.Text);
            //                    sqlClient.AddParameter("@iinit", txtIntitials.Text);
            //                    sqlClient.AddParameter("@Invno", this.Invno);
            //                    sqlClient.CommandText(@"Update suppl SET
            //                                            iin=@iin,
            //                                            idept=@idept,
            //                                            iout=@iout,
            //                                            bindvend=@bindvend,
            //                                            iinit=@iinit
            //                                        WHERE Invno=@Invno");
            //                    runUpdate = true;
            //                    break;
            //                }


            //        }
            //        if (runUpdate)
            //        {
            //            try
            //            {
            //                sqlClient.Update();
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }




            //}

            //if (trkType == "ED")
            //{
            //    //war is datetime
            //    //wir is initials
            //    sqlClient.AddParameter("@Invno", this.Invno);
            //    sqlClient.AddParameter("@DescripID", vDeptCode);
            //    sqlClient.AddParameter("@WAR", vDateTime);
            //    sqlClient.AddParameter("@WIR", vWIR);
            //    sqlClient.AddParameter("@Wtr", vWtr);
            //    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
            //    sqlClient.CommandText(@"Update EndSheetDetail SET
            //                 WAR=
            //                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
            //                    , WIR =
            //                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
            //                     ,WTR=@Wtr+COALESCE(WTR,0)
            //                WHERE Invno=@Invno AND DescripID=@DescripID ");
            //    try { var result = sqlClient.Update(); }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //    sqlClient.ClearParameters();
            //    sqlClient.ReturnSqlIdentityId(true);
            //    sqlClient.AddParameter("@Invno", this.Invno);
            //    sqlClient.AddParameter("@DescripID", vDeptCode);
            //    sqlClient.AddParameter("@WAR", vDateTime);
            //    sqlClient.AddParameter("@WIR", vWIR);
            //    sqlClient.AddParameter("@Wtr", vWtr);
            //    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
            //    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from EndSheetDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
            //                                    Begin
            //                                    INSERT INTO EndSheetDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
            //                                    END
            //                                    ");
            //    try { var result1 = sqlClient.Insert(); }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //if (trkType == "BN")
            //{
            //    // war is datetime
            //    //wir is initials
            //    sqlClient.AddParameter("@Invno", this.Invno);
            //    sqlClient.AddParameter("@DescripID", vDeptCode);
            //    sqlClient.AddParameter("@WAR", vDateTime);
            //    sqlClient.AddParameter("@WIR", vWIR);
            //    sqlClient.AddParameter("@Wtr", vWtr);
            //    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
            //    sqlClient.CommandText(@"Update BannerDetail SET
            //                 WAR=
            //                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
            //                    , WIR =
            //                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
            //                     ,WTR=@Wtr+COALESCE(WTR,0)
            //                WHERE Invno=@Invno AND DescripID=@DescripID ");
            //    try { var result = sqlClient.Update(); }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //    sqlClient.ClearParameters();
            //    sqlClient.ReturnSqlIdentityId(true);

            //    sqlClient.AddParameter("@Invno", this.Invno);
            //    sqlClient.AddParameter("@DescripID", vDeptCode);
            //    sqlClient.AddParameter("@WAR", vDateTime);
            //    sqlClient.AddParameter("@WIR", vWIR);
            //    sqlClient.AddParameter("@Wtr", vWtr);
            //    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
            //    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from BannerDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
            //                                    Begin
            //                                    INSERT INTO BannerDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
            //                                    END
            //                                    ");
            //    try { var result1 = sqlClient.Insert(); }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //if (trkType == "PA")
            //{
            //    if (vDeptCode != 0)
            //    {
            //        // war is datetime
            //        //wir is initials
            //        sqlClient.AddParameter("@Invno", this.Invno);
            //        sqlClient.AddParameter("@DescripID", vDeptCode);
            //        sqlClient.AddParameter("@WAR", vDateTime);
            //        sqlClient.AddParameter("@WIR", vWIR);
            //        sqlClient.AddParameter("@Wtr", vWtr);
            //        sqlClient.AddParameter("@Schcode", txtSchcode.Text);
            //        sqlClient.CommandText(@"Update PartBKDetail SET
            //                 WAR=
            //                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
            //                    , WIR =
            //                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
            //                     ,WTR=@Wtr+COALESCE(WTR,0)
            //                WHERE Invno=@Invno AND DescripID=@DescripID ");
            //        try { var result = sqlClient.Update(); }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //        sqlClient.ClearParameters();
            //        sqlClient.ReturnSqlIdentityId(true);
            //        sqlClient.AddParameter("@Invno", this.Invno);
            //        sqlClient.AddParameter("@DescripID", vDeptCode);
            //        sqlClient.AddParameter("@WAR", vDateTime);
            //        sqlClient.AddParameter("@WIR", vWIR);
            //        sqlClient.AddParameter("@Wtr", vWtr);
            //        sqlClient.AddParameter("@Schcode", txtSchcode.Text);
            //        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from PartBKDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
            //                                    Begin
            //                                    INSERT INTO PartBKDetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
            //                                    END
            //                                    ");
            //        try { var result1 = sqlClient.Insert(); }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        bool runUpdate = false;
            //        switch (txtInOut.Text.Trim())
            //        {
            //            case "ICI":
            //                {

            //                    sqlClient.AddParameter("@iin", txtInOut.Text);
            //                    sqlClient.AddParameter("@idept", txtDept.Text);
            //                    sqlClient.AddParameter("@iinit", txtIntitials.Text);
            //                    sqlClient.AddParameter("@Invno", this.Invno);
            //                    sqlClient.CommandText(@"Update partbk SET
            //                                        iin=@iin,
            //                                        idept=@idept, 
            //                                        iinit=@iinit
            //                                    WHERE Invno=@Invno");
            //                    runUpdate = true;
            //                    break;
            //                }
            //            case "ICO":
            //                {
            //                    sqlClient.AddParameter("@iout", vDateTime);
            //                    sqlClient.AddParameter("@iin", null);
            //                    sqlClient.AddParameter("@idept", txtDept.Text);
            //                    sqlClient.AddParameter("@iinit", txtIntitials.Text);
            //                    sqlClient.AddParameter("@Invno", this.Invno);
            //                    sqlClient.CommandText(@"Update partbk SET
            //                                        iin=@iin,
            //                                        idept=@idept,
            //                                        iout=@iout,
            //                                        iinit=@iinit
            //                                    WHERE Invno=@Invno");
            //                    runUpdate = true;
            //                    break;
            //                }


            //        }
            //        if (runUpdate)
            //        {
            //            try
            //            {
            //                sqlClient.Update();
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //}
            //if (trkType == "PB")
            //{
            //    if (vDeptCode != 0)
            //    {
            //        switch (vDeptCode.ToString())
            //        {
            //            //May have to change this id.
            //            //ToPROD
            //            case "1012":
            //                {


            //                    sqlClient.AddParameter("@Invno", this.Invno);
            //                    sqlClient.AddParameter("@patoprod", vDateTime);
            //                    sqlClient.AddParameter("@pitoprod", txtIntitials.Text);
            //                    sqlClient.AddParameter("@pttoprod", txtTime.Text);
            //                    sqlClient.CommandText(@"Update ptbkb SET patoprod=@patoprod,pitoprod=@pitoprod,pttoprod=@pttoprod Where Invno=@Invno");

            //                    try
            //                    {
            //                        var result = sqlClient.Update();
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    }

            //                    break;
            //                }
            //            default:
            //                {
            //                    sqlClient.AddParameter("@Invno", this.Invno);
            //                    sqlClient.AddParameter("@DescripID", vDeptCode);
            //                    sqlClient.AddParameter("@WAR", vDateTime);
            //                    sqlClient.AddParameter("@WIR", vWIR);
            //                    sqlClient.AddParameter("@Wtr", vWtr);
            //                    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
            //                    sqlClient.CommandText(@"Update prtbkbdetail SET
            //                 WAR=
            //                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
            //                    , WIR =
            //                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
            //                     ,WTR=@Wtr+COALESCE(WTR,0)
            //                WHERE Invno=@Invno AND DescripID=@DescripID ");
            //                    try { var result = sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //                    sqlClient.ClearParameters();
            //                    sqlClient.ReturnSqlIdentityId(true);
            //                    sqlClient.AddParameter("@Invno", this.Invno);
            //                    sqlClient.AddParameter("@DescripID", vDeptCode);
            //                    sqlClient.AddParameter("@WAR", vDateTime);
            //                    sqlClient.AddParameter("@WIR", vWIR);
            //                    sqlClient.AddParameter("@Wtr", vWtr);
            //                    sqlClient.AddParameter("@Schcode", txtSchcode.Text);
            //                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from prtbkbdetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
            //                                    Begin
            //                                    INSERT INTO prtbkbdetail (DescripID,War,Wtr,Wir,Invno,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@Schcode);
            //                                    END
            //                                    ");
            //                    try { var result1 = sqlClient.Insert(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //                    break;
            //                }
            //        }
            //    }
            //    else
            //    {
            //        bool runUpdate = false;
            //        switch (txtInOut.Text.Trim())
            //        {
            //            case "ICI":
            //                {

            //                    sqlClient.AddParameter("@iin", txtInOut.Text);
            //                    sqlClient.AddParameter("@idept", txtDept.Text);
            //                    sqlClient.AddParameter("@iinit", txtIntitials.Text);
            //                    sqlClient.AddParameter("@Invno", this.Invno);
            //                    sqlClient.CommandText(@"Update ptbkb SET
            //                                        iin=@iin,
            //                                        idept=@idept, 
            //                                        iinit=@iinit
            //                                    WHERE Invno=@Invno");
            //                    runUpdate = true;
            //                    break;
            //                }
            //            case "ICO":
            //                {
            //                    sqlClient.AddParameter("@iout", vDateTime);
            //                    sqlClient.AddParameter("@iin", null);
            //                    sqlClient.AddParameter("@idept", txtDept.Text);
            //                    sqlClient.AddParameter("@iinit", txtIntitials.Text);
            //                    sqlClient.AddParameter("@Invno", this.Invno);
            //                    sqlClient.CommandText(@"Update ptbkb SET
            //                                        iin=@iin,
            //                                        idept=@idept,
            //                                        iout=@iout,
            //                                        iinit=@iinit
            //                                    WHERE Invno=@Invno");
            //                    runUpdate = true;
            //                    break;
            //                }


            //        }
            //        if (runUpdate)
            //        {
            //            try
            //            {
            //                sqlClient.Update();
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }

            //}


            MerModel = null;
            pnlPressNumber.Visible = false;
            ClearScan();


        }
        private void MXBScan()
        {
            //update record by login
            var sqlClient = new SQLCustomClient();
            string trkType = txtBarCode.Text.Substring(txtBarCode.Text.Length - 2, 2);
            string company = txtBarCode.Text.Substring(0, 3);
            DateTime vDateTime = DateTime.Now;
            string vWIR = "SYS";

            if (trkType == "YB")
            {
                string vDeptCode = "";
                switch (this.ApplicationUser.UserName.ToUpper())
                // switch ("Shipping")
                {

                    case "SA":

                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);

                        sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                        try { var mxResult = sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);

                        sqlClient.AddParameter("@Jobno", txtSchcode.Text);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                    END
                                                    ");

                        var result1 = sqlClient.Insert();
                        if (result1.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Shipping":
                        vDeptCode = "40";
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);//ship
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);

                        sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                        try { var mxResult = sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);

                        sqlClient.AddParameter("@Jobno", txtSchcode.Text);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                    END
                                                    ");

                        var resultShip = sqlClient.Insert();
                        if (resultShip.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        sqlClient.ClearParameters();
                        var vWeight = GetWeight();
                        sqlClient.CommandText(@"Update MixbookOrder Set Dateshipped=@DateShipped,TrackingNumber=@TrackingNumber,Weight=@Weight,MixbookOrderStatus='Shipped' where Invno=@Invno");
                        sqlClient.AddParameter("@Dateshipped", DateTime.Now);
                        sqlClient.AddParameter("@TrackingNumber", txtTrackingNo.Text.Trim());
                        sqlClient.AddParameter("@Invno", MbxModel.Invno);
                        sqlClient.AddParameter("@Weight", vWeight);
                        var orderUpdateResult = sqlClient.Update();
                        if (orderUpdateResult.IsError)
                        {
                            MbcMessageBox.Error("Failed to update Mixbook order with tracking number.");
                            return;

                        }
                        //We do not do anything with the result. If it fails it will be handled on the REST Service
                        var notificationResult = SendShippingNotification(vWeight);


                        break;
                }
            }
            else if (trkType == "SC")
            {
                switch (this.ApplicationUser.UserName.ToUpper())
                {
                    case "SA":
                        var vDeptCode = "22";
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", txtSchcode.Text);//we use jobn for mixbook.
                        sqlClient.CommandText(@"Update CoverDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                        try { var mxResult = sqlClient.Update(); } catch (Exception ex) { MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);

                        sqlClient.AddParameter("@Jobno", txtSchcode.Text);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO CoverDetail (DescripID,War,Wir,Invno,Jobno) VALUES(@DescripID,@WAR,@WIR,@Invno,@Jobno);
                                                    END
                                                    ");

                        var result1 = sqlClient.Insert();
                        if (result1.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }

            }
            ClearScan();
        }
        private void JPXScan()
        {
            int vDeptCode = 0;
            int.TryParse(txtDeptCode.Text, out vDeptCode);
            var vDateTime = DateTime.Now;
            try { vDateTime = DateTime.Parse(txtDateTime.Text); } catch { }
            ;
            decimal vWtr = 0;
            try { vWtr = decimal.Parse(txtTime.Text); } catch { }
            ;
            var vWIR = txtIntitials.Text;
            var sqlClient = new SQLCustomClient();
            string company = txtBarCode.Text.Substring(0, 3);
            switch (vDeptCode.ToString())
            {
                case "36":
                    {
                        //shipped
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update Produtn Set ShpDate=@ShpDate Where Invno=@Invno");
                        sqlClient.AddParameter("@ShpDate", vDateTime);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        var produtnUpdateResult = sqlClient.Update();
                        if (produtnUpdateResult.IsError)
                        {
                            MbcMessageBox.Error("Failed to update production with shipped date.");
                        }
                        //UPDATE FIRST_________________________________________________________________________________
                        sqlClient.ClearParameters();
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Wtr", vWtr);

                        sqlClient.AddParameter("@OracleCode", txtSchcode.Text);
                        sqlClient.CommandText(@"Update WIPDetail SET
                        WAR=
                            CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                        , WIR =
                            CASE When WIR IS NULL THEN @WIR ELSE WIR END
                            ,WTR=@Wtr+COALESCE(WTR,0)
                    WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var result = sqlClient.Update();
                        if (result.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //INSERT_____________________________________________________________________________________________________________________________
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Wtr", vWtr);

                        sqlClient.AddParameter("@OracleCode", txtSchcode.Text);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                        Begin
                                        INSERT INTO WipDetail (DescripID,War,Wtr,Wir,Invno,OracleCode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@OracleCode);
                                        END
                                        ");

                        var result1 = sqlClient.Insert();
                        if (result1.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //_____________________________
                        break;
                    }
                case "29":
                    {

                        //UPDATE FIRST_________________________________________________________________________________
                        sqlClient.ClearParameters();
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Wtr", vWtr);

                        sqlClient.AddParameter("@OracleCode", txtSchcode.Text);
                        sqlClient.CommandText(@"Update WIPDetail SET
                        WAR=
                            CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                        , WIR =
                            CASE When WIR IS NULL THEN @WIR ELSE WIR END
                            ,WTR=@Wtr+COALESCE(WTR,0)
                    WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var result = sqlClient.Update();
                        if (result.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //INSERT_____________________________________________________________________________________________________________________________
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Wtr", vWtr);

                        sqlClient.AddParameter("@OracleCode", txtSchcode.Text);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                        Begin
                                        INSERT INTO WipDetail (DescripID,War,Wtr,Wir,Invno,OracleCode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@OracleCode);
                                        END
                                        ");

                        var result1 = sqlClient.Insert();
                        if (result1.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //_____________________________
                        break;
                    }
                default:
                    {

                        //UPDATE FIRST_________________________________________________________________________________
                        sqlClient.ClearParameters();
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Wtr", vWtr);

                        sqlClient.CommandText(@"Update WIPDetail SET
                        WAR=
                            CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                        , WIR =
                            CASE When WIR IS NULL THEN @WIR ELSE WIR END
                            ,WTR=@Wtr+COALESCE(WTR,0)
                    WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var result = sqlClient.Update();
                        if (result.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //INSERT_____________________________________________________________________________________________________________________________
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Wtr", vWtr);


                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                        Begin
                                        INSERT INTO WipDetail (DescripID,War,Wtr,Wir,Invno) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno);
                                        END
                                        ");

                        var result1 = sqlClient.Insert();
                        if (result1.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //_____________________________----------------------------______________________________________________________________________________________________________
                        break;
                    }
            }

            ClearScan();

        }
        private void ClearScan()
        {
            txtBarCode.Text = "";
            txtDateTime.Text = "";
            txtDeptCode.Text = "";
            txtPressNumber.Text = "";
            txtSchcode.Text = "";
            txtCoverNumber.Text = "";
            txtColorPageNumber.Text = "";
            txtExtraBooks.Text = "";
            txtSchoolName.Text = "";
            txtProdNumber.Text = "";
            txtTime.Text = "";
            txtIntitials.Text = "";
            chkShippedOrders.Checked = false;
            txtInOut.Text = "";
            txtDept.Text = "";
            txtPlates.Text = "";
            txtSheets.Text = "";
            txtPlateNotes.Text = "";
            txtPressNotes.Text = "";
            cmbPlateReason.SelectedValue = "";
            cmbPressReason.SelectedValue = "";
            this.plnTracking.Visible = false;
            pnlPressNumber.Visible = false;
            MbxModel = null;
            txtTrackingNo.Text = "";

        }
        #endregion

        private void frmBarScan_Activated(object sender, EventArgs e)
        {
            var frmMain = (frmMain)this.MdiParent;
            frmMain.HideSearchButtons();
        }

        private void txtCopies_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblCopies.Visible = false;
            txtCopies.Visible = false;
        }

        private void txtPressNumber_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtPressNumber, "");
            if (string.IsNullOrEmpty(txtPressNumber.Text))
            {
                errorProvider1.SetError(pnlPressNumber, "Press number required");
                e.Cancel = true;
            }

        }

        private void pnlPressNumber_Validating(object sender, CancelEventArgs e)
        {

        }
        private void ShippedEmail(string company)
        {
            List<string> vAddresses = new List<string>();
            var vAttachment = new OutlookAttachemt();
            var vAttachmentList = new List<OutlookAttachemt>();
            var sqlClient = new SQLCustomClient();
            var emailHelper = new EmailHelper();
            string vSubject = "";
            string vBody = "";
            EmailType vType = EmailType.Mbc;
            if (company == "MBC")
            {
                if (!string.IsNullOrEmpty(MbcModel.SchEmail))
                {
                    vAddresses.Add(MbcModel.SchEmail);
                }
                if (!string.IsNullOrEmpty(MbcModel.ContEmail))
                {
                    vAddresses.Add(MbcModel.ContEmail.Trim());
                }
                if (!string.IsNullOrEmpty(MbcModel.BContEmail))
                {
                    vAddresses.Add(MbcModel.BContEmail.Trim());
                }

                if (!string.IsNullOrEmpty(MbcModel.CContEmail))
                {
                    vAddresses.Add(MbcModel.CContEmail.Trim());
                }

                if (vAddresses.Count == 0)
                {
                    MbcMessageBox.Error("There are no shipping email addresses to sent invoie to.");
                    return;
                }
                var attachementResult = CreatekPdf(company, Invno.ToString());
                if (attachementResult.IsError)
                {
                    MbcMessageBox.Error("Invoice attachement could not be created:" + attachementResult.Errors[0].ErrorMessage + "Email can not be sent.");
                    return;
                }

                vAttachment.Path = attachementResult.Data;

                vAttachmentList.Add(vAttachment);
                vSubject = "Your yearbooks have shipped!";
                vBody = @"Your yearbooks have shipped so be looking for them shortly. Thanks for a being a great customer and we look forward to working with you
                          again next year. <br/>If you have already rebooked for next year, thank you! If you are not already rebooked, please contact your Sales Consultant
                           today at <b>1-800-247-1526</b>.<br/> We appreciate your business and look forward to working with you next year to preserve your school's memories.
                           An invoice is attached for you. If you are interested, we may have extra books available for you to purchase at your original cost per book,  
                           plus $12 for shipping.<br/> The shipping is a flat fee whether you order one extra book or all of them. Please do not reply to this email.
                           If you have questions, please contact your Customer Service Representative. <br/><a href=www.memorybook.com><font color=blue>Memorybook</font> </a> ";


            }
            if (company == "MER")
            {
                if (!string.IsNullOrEmpty(MerModel.SchEmail))
                {
                    vAddresses.Add(MerModel.SchEmail);
                }
                if (!string.IsNullOrEmpty(MerModel.ContEmail))
                {
                    vAddresses.Add(MerModel.ContEmail.Trim());
                }
                if (!string.IsNullOrEmpty(MerModel.BContEmail))
                {
                    vAddresses.Add(MerModel.BContEmail.Trim());
                }

                if (vAddresses.Count == 0)
                {
                    MbcMessageBox.Error("There are no shipping email addresses to sent invoie to.");
                    return;
                }
                var attachementResult = CreatekPdf(company, Invno.ToString());
                if (attachementResult.IsError)
                {
                    MbcMessageBox.Error("Invoice attachement could not be created:" + attachementResult.Errors[0].ErrorMessage + "Email can not be sent.");
                    return;
                }
                vAttachment.Path = attachementResult.Data;

                vAttachmentList.Add(vAttachment);
                vType = EmailType.Meridian;
                vSubject = "Your planners have shipped!";
                vBody = @"Please do not reply to this email. <br/>
                        Your planners have shipped! If you need additional planners, call <b>1-888-724-8512</b> to reorder more at a great price with fast delivery.</br>
                    Plus, don’t forget to renew your order for next year at http://www.meridianplanners.com/business-agreement. Thank you for your business and we look forward to working with you again.";
            }
            emailHelper.SendEmail(vSubject, vAddresses, null, vBody, vType, vAttachmentList);

        }
        private ApiProcessingResult<string> CreatekPdf(string Company, string vInvno)
        {

            var processingResult = new ApiProcessingResult<string>();

            var sqlClient = new SQLCustomClient();
            if (Company == "MBC")
            {
                var invoiceCmd = @"SELECT I.SchName,I.SchCode,I.schaddr AS SchAddress,I.SchCity,I.SchZip As ZipCode,I.SchState,I.ContFName AS ContactFirstName,
				I.ContLname AS ContactLastName,I.nocopies AS NumberCopies,I.nopages AS NumberPages,
				I.Freebooks,I.Laminate,I.allclrck AS AllColor,I.contryear AS ContractYear,I.Payments,I.Ponum As PoNumber,
				I.Invno,I.Baldue,I.BeforeTaxTotal,I.SalesTax,I.Invtot,qtedate AS QuoteDate           
				FROM Invoice I
			    Where I.Invno =@Invno";
                var invoiceDetailCmd = @"Select ID.descr ,ID.price,ID.discpercent FROM InvDetail ID Where ID.Invno =@Invno ";
                sqlClient.CommandText(invoiceCmd);
                sqlClient.AddParameter("@Invno", vInvno);
                var result = sqlClient.Select<FullInvoice>();
                if (result.IsError)
                {
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError(result.Errors[0].ErrorMessage, result.Errors[0].ErrorMessage, ""));
                    return processingResult;
                }
                if (result.Data == null)
                {
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError("An invoice for this school could not be found.", "An invoice for this school could not be found.", ""));
                    return processingResult;
                }
                var InvoiceData = result.Data;
                invoiceBindingSource.DataSource = InvoiceData;
                sqlClient.ClearParameters();
                sqlClient.CommandText(invoiceDetailCmd);
                sqlClient.AddParameter("@Invno", vInvno);
                var detailResult = sqlClient.SelectMany<InvoiceDetailBindingModel>();
                if (detailResult.IsError)
                {
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError(detailResult.Errors[0].ErrorMessage, detailResult.Errors[0].ErrorMessage, ""));
                    return processingResult;
                }
                var InvoiceDetailData = detailResult.Data;
                InvoiceDetailBindingSource.DataSource = InvoiceDetailData;
                //report viewer is already set to correct report and datasource here. In Meridian in needs changed
                reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.BarScanMemInvoice.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("invoice", invoiceBindingSource));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("invoicedetail", InvoiceDetailBindingSource));

            }
            else if (Company == "MER")
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.BarScanMerInvoicerdlc.rdlc";
                // reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.test1.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("invoice", invoiceBindingSource));

                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("invoicedetails", InvoiceDetailBindingSource));




                sqlClient.ClearParameters();
                var invoiceCmd = @"SELECT I.InvName,I.SchCode,I.InvAddr ,I.InvAddr2,I.InvCity,I.InvState,I.InvZip,I.ShpName,I.ShpAddr,I.ShpAddr2,I.ShpCity,I.ShpState,I.ShpZip,
                                I.InvNotes,I.ShpDate,I.PoNum,I.Contryear,I.QteDate,I.Invno,I.FplnPrc,I.SubTotal,I.SalesTax,I.ShpHandling,I.FplnTot,
                                I.Payments,I.BalDue,I.QtyStudent,I.QtyTeacher,I.SchType,I.NoPages,I.Generic,I.BasePrc,I.TeBasePrc
			                    FROM MERInvoice I
			                    Where I.Invno =@Invno";

                var invoiceDetailCmd = @"Select ID.Quantity ,ID.Descr,ID.UnitPrice,ID.Amount FROM MerInvDetail ID Where ID.Invno =@Invno ";
                sqlClient.CommandText(invoiceCmd);
                sqlClient.AddParameter("@Invno", vInvno);
                var result = sqlClient.Select<FullMerInvoice>();
                if (result.IsError)
                {
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError(result.Errors[0].ErrorMessage, result.Errors[0].ErrorMessage, ""));
                    return processingResult;
                }
                if (result.Data == null)
                {
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError("An invoice for this school could not be found.", "An invoice for this school could not be found.", ""));
                    return processingResult;
                }
                var InvoiceData = result.Data;

                invoiceBindingSource.DataSource = InvoiceData;
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@Invno", vInvno);
                sqlClient.CommandText(invoiceDetailCmd);
                var detailResult = sqlClient.SelectMany<MerInvoiceDetails>();
                if (detailResult.IsError)
                {
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError(detailResult.Errors[0].ErrorMessage, detailResult.Errors[0].ErrorMessage, ""));
                    return processingResult;
                }
                var InvoiceDetailData = detailResult.Data;
                InvoiceDetailBindingSource.DataSource = InvoiceDetailData;



            }



            //https://stackoverflow.com/questions/2684221/creating-a-pdf-from-a-rdlc-report-in-the-background

            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            //string HIJRA_TODAY = "01/10/1435";
            // ReportParameter[] param = new ReportParameter[3];
            //param[0] = new ReportParameter("CUSTOMER_NUM", CUSTOMER_NUMTBX.Text);
            //param[1] = new ReportParameter("REF_CD", REF_CDTB.Text);
            //param[2] = new ReportParameter("HIJRA_TODAY", HIJRA_TODAY);
            try
            {
                this.reportViewer1.LocalReport.Refresh();
                byte[] bytes = this.reportViewer1.LocalReport.Render(
                "PDF",
                null,
                out mimeType,
                out encoding,
                out extension,
                out streamIds,
                out warnings

               );
                var vPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                var newPath = vPath.Substring(0, vPath.IndexOf("Mbc5") + 4) + "\\tmp\\" + vInvno + ".pdf";
                using (FileStream fs = new FileStream(newPath, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Dispose();
                }
                processingResult.Data = newPath;
            }
            catch (Exception ex)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
            }
            return processingResult;
        }

        private void frmBarScan_Load(object sender, EventArgs e)
        {



        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            MXBScan();
            ClearScan();
            this.Enabled = true;
        }
        public async Task<bool> SendShippingNotification(decimal vWeight)
        {


            //build notification model
            var returnNotification = new MixbookNotification();

            returnNotification.Request.identifier = MbxModel.JobId;//neeeds to be set with jobid
            returnNotification.Request.Status.occurredAt = DateTime.Now;
            returnNotification.Request.Status.Value = "Shipped";

            returnNotification.Request.Shipment[0].trackingNumber = txtTrackingNo.Text.Trim();
            returnNotification.Request.Shipment[0].shippedAt = DateTime.Now;
            returnNotification.Request.Shipment[0].method = MbxModel.ShipMethod;
            returnNotification.Request.Shipment[0].weight = vWeight;
            returnNotification.Request.Shipment[0].Package[0].Item.identifier = MbxModel.ItemId;
            returnNotification.Request.Shipment[0].Package[0].Item.quantity = MbxModel.Quantity;
            //send post
            var vReturnNotification1 = Serialize.ToXml(returnNotification);
            var restServiceResult = await new RESTService().MakeRESTCall("POST", vReturnNotification1);
            if (restServiceResult.Data.APIResult.ToString().Contains("Success"))
            {
                //check return and handle
                AddMbEventLog(MbxModel.JobId, "Shipped", "Notification Succeded", vReturnNotification1, true);
                return true;
            }
            else { return false; }

        }
        public string AddMbEventLog(string jobId, string status, string note, string notificationXML, bool notified)
        {
            var retval = "0";
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Insert Into MixBookEventLog (JobId,DateCreated,ModifiedDate,StatusChangedTo,Notified,Note,NotificationXML) Values(@JobId,GetDate(),GETDATE(),@StatusChangedTo,@Notified,@Note,@NotificationXML)");
            sqlClient.AddParameter("@Jobid", jobId);
            sqlClient.AddParameter("@StatusChangedTo", status);
            sqlClient.AddParameter("@Notified", notified);
            sqlClient.AddParameter("@Note", note);
            sqlClient.AddParameter("@NotificationXML", notificationXML);
            var sqlResult = sqlClient.Insert();
            if (sqlResult.IsError)
            {

                ExceptionlessClient.Default.CreateLog("AddMbEventLog failure")
                .AddObject(sqlResult)
                .MarkAsCritical()
                .Submit();
                var emailHelper = new EmailHelper();
                string vBody = "Failed to insert values JobId:" + jobId + " StatusChangedTo:" + status + " Notified:" + notified + " Note:" + note;
                emailHelper.SendEmail("AddMbEventLog", ConfigurationManager.AppSettings["SystemEmailAddress"].ToString(), null, vBody, EmailType.System);
                return retval;
            }
            retval = sqlResult.Data;
            return retval;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            MXBScan();
            ClearScan();
        }
        private decimal GetWeight()
        {
            //place holder until I figure out for sure how to get the weight. IF we have a chart to go off I may put the weigth in when the order comes in
            return 0;
        }
    }

}

