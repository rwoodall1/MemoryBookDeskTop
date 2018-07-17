using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BindingModels;
using BaseClass.Classes;
namespace Mbc5.Forms
{
    public partial class frmBarScan : BaseClass.frmBase
    {
        public frmBarScan(UserPrincipal userPrincipal):base(new string[] { },userPrincipal)
        {
            InitializeComponent();
        }
        string Company { get; set; }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string company = txtBarCode.Text.Substring(0, 3);
            //Insert prodtrk here
            if (company == "MBC"){
                MbScan();
            }
         
        }

        private void txtDeptCode_Leave(object sender, EventArgs e)
        {
            if (txtBarCode.Text.Length<10)
            {
                return;
            }
            string trkType = txtBarCode.Text.Substring(9, 2);
            switch (trkType)
            {
                case "YB":
                    switch (txtDeptCode.Text)
                    {
                        case "WAR29":
                            {
                                txtIntitials.Mask = ">LLLLLLL";
                                break;
                            }
                        case "WAR32":
                            {
                                txtIntitials.Mask = ">LLLLLLL";
                                break;
                            }
                        case "WAR33":
                            {
                                txtIntitials.Mask = ">LLLLLLL";
                                break;
                            }
                        case "WAR34":
                            {
                                txtIntitials.Mask = ">LLLLLLL";
                                break;
                            }
                        case "WAR35":
                            {
                                txtIntitials.Mask = ">LLLLLLL";
                                break;
                            }
                        case "WAR36":
                            {
                                txtIntitials.Mask = ">LLLLLLL";
                                break;
                            }
                        case "WAR37":
                            {
                                txtIntitials.Mask = ">LLLLLLL";
                                break;
                            }
                        case "WAR38":
                            { txtIntitials.Mask = ">LLLLLLL";
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
                                txtIntitials.Mask = ">####";
                                break;
                            }
                        case "LAM2":
                            {
                                txtIntitials.Mask = ">####";
                                break;
                            }
                        case "WAR29":
                            {
                                txtIntitials.Mask = ">####";
                                break;
                            }
                        case "WAR37":
                            {
                                txtIntitials.Mask = ">####";
                                break;
                            }
                        default:
                            {
                                txtIntitials.Mask = ">LLL";
                                break;
                            }
                    }
                            break;

                    

            }
        }

        private void txtBarCode1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBarCode_Leave(object sender, EventArgs e)
        {
            if (txtBarCode.Text.Length >= 6)
            {
                this.Company = txtBarCode.Text.Substring(0, 3);
                this.Invno = int.Parse(txtBarCode.Text.Substring(3, 6));
            }
            else { MessageBox.Show("Invalid scan code");
                return; }
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
                        sqlQuery.AddParameter("@Invno",Invno);
                       var result = sqlQuery.Select<MbcBarScanModel>();
                        var model=(MbcBarScanModel)result;

                        if (result == null)
                        {
                            MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        txtSchcode.Text = model.SchCode;
                        txtSchoolName.Text = model.Schname;
                        txtCoverNumber.Text =model.Specovr ;
                        txtColorPageNumber.Text=model.CpNum;
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
        #region "Methods"
        private void MbScan()
        {
            string trkType = txtBarCode.Text.Substring(9, 2);
            string company = txtBarCode.Text.Substring(0, 3);
            var vDateTime = DateTime.Now;
          
            decimal vWtr = 0;
            var vDeptCode = int.Parse(txtDeptCode.Text);
            var vWIR = txtIntitials.Text;
            try { vWtr = decimal.Parse(txtTime.Text); } catch { };
            try { vDateTime = DateTime.Parse(txtDateTime.Text); } catch { };
            var sqlClient = new SQLCustomClient();


            if (!string.IsNullOrEmpty(txtDeptCode.Text) && !string.IsNullOrEmpty(txtDept.Text))
            {
                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.CommandText(@"Select C.Schname,C.Schcode,P.NoPages,P.NoCopies,P.Invno,P.Perfbind,P.VendCd FROM Cust C
                                        Left Join Quotes Q ON C.Schcode=Q.Schcode
                                        Left Join Produtn P On Q.Invno=P.Invno                   
                                        WHERE Q.Invno=@Invno");

                //    sqlClient.AddParameter("@Des1", "Yearbook Printing Cost");

                //    sqlClient.CommandText(@"Insert INTO Voucher (Invno,NoPages,NoCopies,PerfBind,Des1,Schname,) Values(@Invno,@NoPages,@NoCoies,@PerfBind,@Des1,@Schname));
                    return;
            }


                if (trkType=="YB")
            {
                switch (vDeptCode)
                {
                    //May have to change this id.
                    //PROD
                    case 1012:
                        {
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.AddParameter("@ToProd", vDateTime);
                            sqlClient.CommandText(@"Update Produtn SET ToPro=@ToProd Where Invno=@Invno");
                            sqlClient.Update();
                            
                            break;
                        }
                    case 1000:
                        {
                            //war 41
                            //war is datetime
                            //wir is initials
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.AddParameter("@DescripID", vDeptCode);
                            sqlClient.AddParameter("@WAR", vDateTime);
                            sqlClient.AddParameter("@WIR", vWIR);
                            sqlClient.AddParameter("@Wtr", vWtr);
                            sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                            sqlClient.CommandText(@"Update WIPDetail SET
                                 
                                      WAR= @WAR                                
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                     ,WTR=@Wtr+COALESCE(WTR,0)
                                WHERE Invno=@Invno AND DescripID=@DescripID ");
                            var result = sqlClient.Update();
                            sqlClient.ClearParamters();
                            sqlClient.ReturnSqlIdentityID(true);
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
                            sqlClient.AddParameter("@WIR",vWIR);
                            sqlClient.AddParameter("@Wtr", vWtr);
                            sqlClient.AddParameter("@Schcode", txtSchcode.Text);
                            sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                     ,WTR=@Wtr+COALESCE(WTR,0)
                                WHERE Invno=@Invno AND DescripID=@DescripID ");
                            var result=sqlClient.Update();
                            sqlClient.ClearParamters();
                            sqlClient.ReturnSqlIdentityID(true);
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
                            if (vDeptCode==555)
                            {
                                MessageBox.Show("need function to email shipped data");
                                //shipped email

                            }

                            break;
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
                switch (vDeptCode)
                {
                    //May have to change this id.
                    //cover detail
                    case 1012:
                        {
                            MessageBox.Show("Function not found.");
                            //toprod
                            //sqlClient.AddParameter("@Invno", this.Invno);
                            //sqlClient.AddParameter("@Press", vDateTime);
                            //sqlClient.CommandText(@"Update Covers SET a.press=@Press, Where Invno=@Invno");
                            //sqlClient.Update();

                            break;
                        }
                    case 1000:
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
                            var result = sqlClient.Update();
                            break;
                        }
                    case 1022:
                        { //CODE FOR LAM2 OR CASE
                            //war 41
                            //war is datetime
                            //wir is initials
                           
                            string vInit = "";
                            if (txtIntitials.Text.Length>=8) {
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
                            var result = sqlClient.Update();
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
                            var result = sqlClient.Update();
                            sqlClient.ClearParamters();
                            sqlClient.ReturnSqlIdentityID(true);
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
                            var result1 = sqlClient.Insert();

                            break;
                        }
                            
                     }
                bool runUpdate = false;
                switch (txtInOut.Text.Trim())
                {
                    case "TOV":
                        {
                            DateTime vPrtdtesent=DateTime.Now;
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
                    sqlClient.Update();
                }

                 }

            
            
            if (trkType == "ED")
            {

            }
            if (trkType == "BN")
            {

            }
            if (trkType == "PA")
            {

            }
            if (trkType == "PB")
            {

            }
            if (trkType == "SP")
            {

            }
            if (trkType == "GS")
            {

            }

        }

        #endregion
    }
}
