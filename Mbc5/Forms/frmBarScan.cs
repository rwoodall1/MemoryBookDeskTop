using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BindingModels;
using BaseClass.Classes;
using BaseClass;
namespace Mbc5.Forms
{
    public partial class frmBarScan : BaseClass.frmBase
    {
        public frmBarScan(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
        }
        string Company { get; set; }
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
            if (company == "MBC") {
                MbScan();
            }

        }

        private void txtDeptCode_Leave(object sender, EventArgs e)
        {
            if (txtBarCode.Text.Length < 10)
            {
                return;
            }
            string trkType = txtBarCode.Text.Substring(txtBarCode.Text.Length-2, 2);
            
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
                            { txtIntitials.Mask = ">LLL####";
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
              try {
                this.Company = txtBarCode.Text.Substring(0, 3);
                if (txtBarCode.Text.Length == 12||txtBarCode.Text.Length == 11)
                {
                    vInvno = txtBarCode.Text.Substring(4, txtBarCode.Text.Length -6);
                }
                
                else
                {
                    MbcMessageBox.Error("Scan code is not in correct format");
                    return;
                }
         
                int parsedInvno = 0;
              
                var parseResult= int.TryParse(vInvno,out parsedInvno);
                this.Invno = parsedInvno;
           if(!parseResult)
           { MessageBox.Show("Invalid scan code");
                return;
            }
            var sqlQuery = new SQLCustomClient();
            switch (this.Company)
            {
                case "MBC":
                    {
                        string cmdText = @"
                        SELECT C.Schname,C.SchCode,C.SchEmail,C.ContEmail,CV.Specovr,P.ProdNo,W.CpNum,Q.Invno
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
                        var model = (MbcBarScanModel)result.Data;

                        if (result == null)
                        {
                            MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        txtSchcode.Text = model.SchCode;
                        txtSchoolName.Text = model.Schname;
                        txtCoverNumber.Text = model.Specovr;
                        txtColorPageNumber.Text = model.CpNum;
                        txtProdNumber.Text = model.ProdNo;
                        txtDateTime.Text = DateTime.Now.ToString();

                        break;
                    }
                case "MER":
                    {

                        break;
                    }

            }
            }
            catch (Exception ex) { };
        }
        #region "Methods"
        private void MbScan()
        {
            int vDeptCode = 0;
            string trkType = txtBarCode.Text.Substring(txtBarCode.Text.Length-2, 2);
            string company = txtBarCode.Text.Substring(0, 3);
            var vDateTime = DateTime.Now;

            decimal vWtr = 0;
            int.TryParse(txtDeptCode.Text, out vDeptCode);
            var vWIR = txtIntitials.Text;
            try { vWtr = decimal.Parse(txtTime.Text); } catch { };
            try { vDateTime = DateTime.Parse(txtDateTime.Text); } catch { };
            var sqlClient = new SQLCustomClient();


            if (trkType == "YB")
            {
                if (vDeptCode != 0) {
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
                                }catch(Exception ex)
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

                                //sqlClient.ClearParameters();
                                //sqlClient.AddParameter("@Invno", this.Invno);
                                //sqlClient.AddParameter("@DescripID", vDeptCode);
                                //sqlClient.AddParameter("@WAR",DBNull.Value);
                                //sqlClient.AddParameter("@WIR","");
                                //sqlClient.AddParameter("@Wtr", 0);
                                //sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                                //sqlClient.CommandText(@" UPDATE WipDetail Set War=@WAR,Wir=@WIR,Wtr=@Wtr  Where Invno=@Invno AND DescripID=42
                                //                    ");
                                //try {var updateResult = sqlClient.Update(); }catch(Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
                                
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
                                    MessageBox.Show("need function to email shipped data");
                                    //shipped email

                                }

                                break;
                            }

                    }
                } else {
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
                            sqlClient.AddParameter("@HDept",txtDept.Text);
                            sqlClient.AddParameter("@HInit",txtIntitials.Text);
                            sqlClient.AddParameter("@HOut",vDateTime);
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
                    if (runUpdate) {
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
                try { var result1 = sqlClient.Insert(); } catch (Exception ex)
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
                                sqlClient.AddParameter("@Invno",this.Invno);
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
            cmbPressReason.SelectedValue ="";

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
     
    }

    }

