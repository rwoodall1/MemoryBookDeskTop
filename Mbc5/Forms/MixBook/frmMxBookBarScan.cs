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
using BaseClass.Core;
using Microsoft.Reporting.WinForms;
using System.IO;
using Mbc5.Classes;
using RESTModule;
using System.Threading.Tasks;
using Exceptionless;
using System.Configuration;

namespace Mbc5.Forms.MixBook
{
    public partial class frmMxBookBarScan : BaseClass.frmBase
    {
        public frmMxBookBarScan(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
            lblScanQty.Text = "0";
        }
        public string Company { get; set; }
       public UserPrincipal ApplicationUser { get; set; }      
       public MixBookBarScanModel MbxModel { get; set; }
        public int QuantityScanned { get; set; } = 0;
        private void txtBarCode_Leave(object sender, EventArgs e)
        {
            string vInvno = "";
            try
            {
                if (string.IsNullOrEmpty(txtBarCode.Text))
                {
                
                    return;
                }
                this.Company = txtBarCode.Text.Substring(0, 3);
                if (this.Company == "MXB")
                {
                    //expecting MXB1111111YB

                    vInvno = txtBarCode.Text.Substring(3, txtBarCode.Text.Length - 5);
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
                            //txtSchcode.Text = MbxModel.JobId;
                            //txtSchoolName.Text = MbxModel.ShipName;
                            //txtCoverNumber.Text = MbxModel.Specovr;
                            //txtColorPageNumber.Text = "";
                            //txtProdNumber.Text = MbxModel.ProdNo;
                              txtDateTime.Text = DateTime.Now.ToString();
                            if (this.ApplicationUser.UserName.ToUpper()!="SHIPPING")
                            {
                            MXBScan();
                            ClearScan();
                            }else if (this.ApplicationUser.UserName.ToUpper() == "SHIPPING")
                            {
                                if (!string.IsNullOrEmpty(txtTrackingNo.Text) && !string.IsNullOrEmpty(txtWeight.Text))
                                {
                                    MXBScan();
                                    ClearScan();
                                }
                                txtTrackingNo.Focus();
                            }
                           


                            break;

                        }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ClearScan()
        {
                txtBarCode.Text = "";
                txtDateTime.Text = "";
                txtTrackingNo.Text = "";
                txtWeight.Text = "";
                txtLocation.Text = "";
            MbxModel = null;
            txtBarCode.Focus();
            
        }

        private void MXBScan()
        {
            int QtyToScan = 0;
            try
            {
                int.TryParse(txtQtyToScan.Text, out QtyToScan);
            }
            catch { }

            //update record by login
            var sqlClient = new SQLCustomClient();
            string trkType = txtBarCode.Text.Substring(txtBarCode.Text.Length - 2, 2);
            string company = txtBarCode.Text.Substring(0, 3);
            DateTime vDateTime = DateTime.Now;
            string vWIR = "SYS";

            if (trkType == "YB")
            {
                string vDeptCode = "";
                //switch (this.ApplicationUser.UserName.ToUpper())
                switch (this.ApplicationUser.UserName.ToUpper())
                {

                    case "PRESS":
                        vDeptCode = "29";
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult = sqlClient.Update();
                        if (mxResult.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                          
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
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
                        ClearScan();
                        break;
                    case "BINDING":
                        //war is datetime
                        //wir is initials
                        vDeptCode = "39";
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult1 = sqlClient.Update();
                          if(mxResult1.IsError) {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        } 
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                    END
                                                    ");

                        var result = sqlClient.Insert();
                        if (result.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ClearScan();
                        break;
                    case "CASEIN":
                        //war is datetime
                        //wir is initials
                        vDeptCode = "49";
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                       
                        var mxResult2 = sqlClient.Update();
                        if (mxResult2.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                    END
                                                    ");

                        var result2 = sqlClient.Insert();
                        if (result2.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ClearScan();
                        break;
                    case "QUALITY":
                        //war is datetime
                        //wir is initials
                        vDeptCode = "50";
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult3 = sqlClient.Update();
                        if (mxResult3.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                    END
                                                    ");

                        var result3 = sqlClient.Insert();
                        if (result3.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ClearScan();
                        break;
                    case "SHIPPING":
                        //war is datetime
                        //wir is initials
                        int vWeight = 0;
                        int.TryParse(txtWeight.Text, out vWeight);
                        if (!int.TryParse(txtWeight.Text, out vWeight))
                        {
                            MbcMessageBox.Information("Enter a valid numeric weight.");
                            return;
                        }
                        vDeptCode = "40";
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult4 = sqlClient.Update();
                        if (mxResult4.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                    END
                                                    ");

                        var result4 = sqlClient.Insert();
                        if (result4.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        sqlClient.ClearParameters();
                       
                        sqlClient.CommandText(@"UPDATE Mixbookorder Set TrackingNumber=@TrackingNumber,Weight=@Weight where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@Weight",vWeight);
                        sqlClient.AddParameter("@TrackingNumber", txtTrackingNo.Text);
                        var trackingResult = sqlClient.Update();
                        if (trackingResult.IsError)
                        {
                            MbcMessageBox.Error("Failed to update tracking number in order screen.");
                        }
                        ClearScan();
                        break;
                    default:
                        MbcMessageBox.Stop("Login not found for scan.", "Missing Login");
                        break;
                }
            }
            else if (trkType == "SC")
            {
                string vDeptCode = "";
                switch (this.ApplicationUser.UserName.ToUpper())
                {
                    case "ONBOARD":
                        if (string.IsNullOrEmpty(txtLocation.Text))
                        {
                            MbcMessageBox.Hand("Please enter a location.","Enter Location");
                        }
                         vDeptCode = "37";
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update CoverDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult = sqlClient.Update();
                        if (mxResult.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO CoverDetail (DescripID,War,Wir,Invno,Jobno) VALUES(@DescripID,@WAR,@WIR,@Invno,@Jobno);
                                                    END
                                                    ");

                        var result = sqlClient.Insert();
                        if (result.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //Mark says orders will not be split on location so insert into one location
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixBookOrder Set Location=@Location Where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@Location", txtLocation.Text);
                        var locationresult = sqlClient.Update();
                        if (locationresult.IsError)
                        {
                            MbcMessageBox.Error("Failed to update location of order.");
                            ExceptionlessClient.Default.CreateLog("Failed to update location of order invno:" + Invno.ToString());
                        }
                        QuantityScanned += 1;
                        lblScanQty.Text = QuantityScanned.ToString();
                        if (QuantityScanned >= QtyToScan)
                        {
                            MbcMessageBox.Hand("Quantity scanned is "+ QtyToScan+". Click OK then enter new location to start over.","Quantity");
                            QuantityScanned = 0;
                            lblScanQty.Text = QuantityScanned.ToString();
                        }
                        ClearScan();
                        break;
                    case "TRIMMING":
                        if (string.IsNullOrEmpty(txtLocation.Text))
                        {
                            MbcMessageBox.Hand("Please enter a location.", "Enter Location");
                            ;
                        }
                        vDeptCode = "35";
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update CoverDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult1 = sqlClient.Update();
                        if (mxResult1.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
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
                        //Mark says orders will not be split on location so insert into one location
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixBookOrder Set Location=@Location Where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@Location", txtLocation.Text);
                        var locationresult1 = sqlClient.Update();
                        if (locationresult1.IsError)
                        {
                            MbcMessageBox.Error("Failed to update location of order.");
                            ExceptionlessClient.Default.CreateLog("Failed to update location of order invno:" + Invno.ToString());
                        }
                        QuantityScanned += 1;
                        lblScanQty.Text = QuantityScanned.ToString();
                        if (QuantityScanned >= QtyToScan)
                        {
                            MbcMessageBox.Hand("Quantity scanned is " + QtyToScan + ". Click OK then enter new location to start over.", "Quantity");
                            QuantityScanned = 0;
                            lblScanQty.Text = QuantityScanned.ToString();
                        }
                        ClearScan();
                        break;
                    case "PRESSCOVERS":
                        vDeptCode = "29";
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update CoverDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult2 = sqlClient.Update();
                        if (mxResult2.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO CoverDetail (DescripID,War,Wir,Invno,Jobno) VALUES(@DescripID,@WAR,@WIR,@Invno,@Jobno);
                                                    END
                                                    ");

                        var result2 = sqlClient.Insert();
                        if (result2.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ClearScan();
                        break;
                    case "ONBOARD2":
                        vDeptCode = "";
                        //war is datetime
                        //wir is initials
                        if (string.IsNullOrEmpty(txtLocation.Text))
                        {
                            MbcMessageBox.Hand("Please enter a location.", "Enter Location");
                            ;
                        }
                        vDeptCode = "38";
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update CoverDetail SET
                                 WAR=
                                        CASE When WAR IS NULL THEN @WAR ELSE WAR END                                 
                                    , WIR =
                                      CASE When WIR IS NULL THEN @WIR ELSE WIR END
                                      WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult4 = sqlClient.Update();
                        if (mxResult4.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO CoverDetail (DescripID,War,Wir,Invno,Jobno) VALUES(@DescripID,@WAR,@WIR,@Invno,@Jobno);
                                                    END
                                                    ");

                        var result4 = sqlClient.Insert();
                        if (result4.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //Mark says orders will not be split on location so insert into one location
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixBookOrder Set Location=@Location Where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@Location", txtLocation.Text);
                        var locationresult2 = sqlClient.Update();
                        if (locationresult2.IsError)
                        {
                            MbcMessageBox.Error("Failed to update location of order.");
                            ExceptionlessClient.Default.CreateLog("Failed to update location of order invno:" + Invno.ToString());
                        }
                        QuantityScanned += 1;
                        lblScanQty.Text = QuantityScanned.ToString();
                        if (QuantityScanned >= QtyToScan)
                        {
                            MbcMessageBox.Hand("Quantity scanned is " + QtyToScan + ". Click OK then enter new location to start over.", "Quantity");
                            QuantityScanned = 0;
                            lblScanQty.Text = QuantityScanned.ToString();
                        }
                        ClearScan();
                        break;
                    default:
                        MbcMessageBox.Stop("Login not found for scan.", "Missing Login");
                        break;
                }

            }
            ClearScan();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarCode.Text)) {
                txtBarCode_Leave(this.btnSave, null);
                }
        }

        private void frmMxBookBarScan_Load(object sender, EventArgs e)
        {
            txtQtyToScan.Text = "40"; //default
            if (ApplicationUser.UserName == "Onboard"|| ApplicationUser.UserName == "Onboard2")
            {
                pnlQty.Visible = true;
            }else if (ApplicationUser.UserName == "Shipping")
            {
                plnTracking.Visible = true;
            }
            else if (ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator" }))
            {
                pnlQty.Visible = true;
            };
               
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearScan();
        }

        private void plnTracking_Leave(object sender, EventArgs e)
        {
            if (this.ApplicationUser.UserName.ToUpper() != "SHIPPING")
            {
                if (!string.IsNullOrEmpty(txtTrackingNo.Text) && !string.IsNullOrEmpty(txtWeight.Text)&& !string.IsNullOrEmpty(txtBarCode.Text)) {
                    MXBScan();
                    ClearScan();
                }
            }
        }

        private void txtTrackingNo_Leave(object sender, EventArgs e)
        {
            txtWeight.Focus();
        }

        private void txtWeight_Validating(object sender, CancelEventArgs e)
        {
            int vWeight;
            if (!int.TryParse(txtWeight.Text, out vWeight)) {
                MbcMessageBox.Information("Enter a valid numeric weight.");
            }
        }
        //private void SetDept()
        //{
        //    switch (this.ApplicationUser.UserName.ToUpper())
        //    {
        //        case "SA":
        //            txtDeptCode.Text = "40";
        //            break;
        //    }
        //}
    }
}
