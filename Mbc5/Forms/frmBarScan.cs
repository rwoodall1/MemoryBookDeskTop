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
            this.Company = txtBarCode.Text.Substring(0, 3);
            this.Invno = int.Parse(txtBarCode.Text.Substring(3,6));
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


            if (!string.IsNullOrEmpty(txtDeptCode.Text) && string.IsNullOrEmpty(txtDept.Text))
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
                                     ,WTR=@Wtr+WTR
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
                                     ,WTR=@Wtr+WTR
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

            }
           
            if (trkType == "SC")
            {

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
