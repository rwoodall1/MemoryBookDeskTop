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
            lblLastScan.Text = txtBarCode.Text;
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
                            SELECT M.ShipName,M.ClientOrderId,M.ItemId,M.JobId,M.Invno,M.Backing,M.ShipMethod,M.Copies As Quantity,P.ProdNo,C.Specovr
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
                                 WAR=@WAR, WIR=@WIR WHERE Invno=@Invno AND DescripID=@DescripID ");
                        var mxResult = sqlClient.Update();
                        if (mxResult.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
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
                            return;
                        }
                        ClearScan();
                        break;
                    case "BINDING":
                        //war is datetime
                        //wir is initials
                        if (string.IsNullOrEmpty(txtLocation.Text)&& MbxModel.Backing=="HC")
                        {
                            MbcMessageBox.Hand("Please enter a location.", "Enter Location");
                            return;
                        }
                        
                        vDeptCode = "39";
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR=@WAR,WIR = @WIR WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult1 = sqlClient.Update();
                        if (mxResult1.IsError) {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
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
                            return;
                        }
                        if (MbxModel.Backing == "HC") {
                            //Mark says orders will not be split on location so insert into one location
                            sqlClient.ClearParameters();
                            sqlClient.CommandText(@"Update Wipdetail Set MxbLocation=@Location Where Invno=@Invno And DescripID=@DescripID  ");
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.AddParameter("@DescripID", vDeptCode);
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
                                MbcMessageBox.Hand("Quantity scanned is " + QtyToScan + ". Click OK then enter new location to start over.", "Quantity");
                                QuantityScanned = 0;
                                lblScanQty.Text = QuantityScanned.ToString();
                            }
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
                                 WAR=@WAR,WIR =@WIR WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult2 = sqlClient.Update();
                        if (mxResult2.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
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
                            return;
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
                                 WAR=@WAR, WIR =@WIR WHERE Invno=@Invno AND DescripID=@DescripID ");



                        var mxResult3 = sqlClient.Update();
                        if (mxResult3.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
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
                            return;
                        }
                        ClearScan();
                        break;
                    case "SHIPPING":
                        //war is datetime
                        //wir is initials
                        int vWeight = 0;
                        int.TryParse(txtWeight.Text, out vWeight);
                        if (!int.TryParse(txtWeight.Text, out vWeight) || vWeight == 0)
                        {
                            MbcMessageBox.Information("Enter a valid numeric weight.");
                            return;
                        }
                        var a = this.Validate();
                        var b = this.ValidateChildren();
                        if (this.Validate())
                        {
                            vDeptCode = "40";
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR= @WAR, WIR =@WIR WHERE Invno=@Invno AND DescripID=@DescripID ");
                                        
                        var mxResult4 = sqlClient.Update();
                        if (mxResult4.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
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
                                return;
                        }
                            sqlClient.ClearParameters();
                            sqlClient.CommandText(@"UPDATE Produtn Set Shpdate=GETDATE() where Invno=@Invno");
                            sqlClient.AddParameter("@Invno", this.Invno);
                            
                            var produtnResult = sqlClient.Update();
                            if (produtnResult.IsError)
                            {
                                MbcMessageBox.Error("Failed to update shipdate on production screen.");

                            }

                            sqlClient.ClearParameters();

                        sqlClient.CommandText(@"UPDATE Mixbookorder Set TrackingNumber=@TrackingNumber,Weight=@Weight,MixbookOrderStatus='Shipped',DateShipped=GETDATE() where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@Weight", vWeight);
                        sqlClient.AddParameter("@TrackingNumber", txtTrackingNo.Text);
                        var trackingResult = sqlClient.Update();
                        if (trackingResult.IsError)
                        {
                            MbcMessageBox.Error("Failed to update tracking number in order screen.");

                        }
                            int weight = 0;
                            int.TryParse(txtWeight.Text, out weight);
                            var shipInfo = new ShippingNotificationInfo()
                            {
                                JobId = MbxModel.JobId,
                                ShipMethod = MbxModel.ShipMethod,
                                ItemId = MbxModel.ItemId,
                                Qty = MbxModel.Quantity,
                                TrackingNumber = txtTrackingNo.Text,
                                Weight = weight
                          };
                        txtBarCode.Focus();
                         NotifyMixbookOfShipment(shipInfo);
                    ClearScan();
                          
                        
                }
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
                            return;
                        }
                         vDeptCode = "37";
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                   
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update CoverDetail SET WAR= @WAR , WIR =@WIR   WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult = sqlClient.Update();
                        if (mxResult.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
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
                            return;
                        }
                        //Mark says orders will not be split on location so insert into one location
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update Coverdetail Set MxbLocation=@Location Where Invno=@Invno And DescripID=@DescripID  ");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
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
                        
                        vDeptCode = "43";
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update CoverDetail SET WAR= @WAR , WIR =@WIR   WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult1 = sqlClient.Update();
                        if (mxResult1.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
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
                            return;
                        }
                        //Mark says orders will not be split on location so insert into one location
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update Coverdetail Set MxbLocation=@Location Where Invno=@Invno And DescripID=@DescripID  ");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
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
                    case "PRESS":
                        vDeptCode = "29";
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update CoverDetail SET WAR= @WAR , WIR =@WIR   WHERE Invno=@Invno AND DescripID=@DescripID ");
                   
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
                            return;
                        }
                        vDeptCode = "38";
                        //war is datetime
                        //wir is initials
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
              
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update CoverDetail SET WAR= @WAR , WIR =@WIR   WHERE Invno=@Invno AND DescripID=@DescripID ");

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
                        sqlClient.CommandText(@"Update MixBookOrder Set MxbLocation=@Location Where Invno=@Invno");
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
            if (ApplicationUser.UserName == "onboard"|| ApplicationUser.UserName == "onboard2"|| ApplicationUser.UserName == "trimming" || ApplicationUser.UserName == "binding")
            {
                pnlQty.Visible = true;
            }else if (ApplicationUser.UserName == "shipping")
            {
                plnTracking.Visible = true;
            }
            else if (ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator" }))
            {
                pnlQty.Visible = true;
            };
               
            
        }

     

        private void plnTracking_Leave(object sender, EventArgs e)
        {
            if (this.ApplicationUser.UserName.ToUpper() != "shipping")
            {
                if (!string.IsNullOrEmpty(txtTrackingNo.Text) && !string.IsNullOrEmpty(txtWeight.Text)&& !string.IsNullOrEmpty(txtBarCode.Text)) {
                    MXBScan();
                    ClearScan();
                }
            }
        }

        private void txtTrackingNo_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtWeight_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtWeight, "");
            int vWeight=0;
            if (!int.TryParse(txtWeight.Text, out vWeight)||vWeight==0) {
                

                errorProvider1.SetError(txtWeight, "Please enter a  valid weight.");
                e.Cancel = true;
            }
        }

        private void txtTrackingNo_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtTrackingNo, "");
            if(string.IsNullOrEmpty(txtTrackingNo.Text)){
             

                errorProvider1.SetError(txtTrackingNo, "Please enter a  tracking number.");
                e.Cancel = true;
            }
           
        }

        public async Task<ApiProcessingResult> NotifyMixbookOfShipment(ShippingNotificationInfo model)
        {
            var processingResult = new ApiProcessingResult();
            var returnNotification = new MixbookNotification();
           
            returnNotification.Request.identifier =model.JobId;//needs to be set with jobid should always have one element
            returnNotification.Request.Status.occurredAt = DateTime.Now;
            returnNotification.Request.Status.Value = "Shipped";
            returnNotification.Request.Shipment[0].trackingNumber = model.TrackingNumber;
            returnNotification.Request.Shipment[0].shippedAt = DateTime.Now;
            returnNotification.Request.Shipment[0].method =model.ShipMethod;
            returnNotification.Request.Shipment[0].weight = model.Weight;
            returnNotification.Request.Shipment[0].Package[0].Item.identifier =model.ItemId;
            returnNotification.Request.Shipment[0].Package[0].Item.quantity =model.Qty;
            var vReturnNotification = Serialize.ToXml(returnNotification);

            var restServiceResult = await new RESTService().MakeRESTCall("POST", vReturnNotification);
            if (!restServiceResult.IsError)
            {
                if (restServiceResult.Data.APIResult.ToString().Contains("Success"))
                {
                    //if not set to notified scheduled task will try again
                    AddMbEventLog(model.JobId, "Shipped", "", vReturnNotification, true);
                }
                else
                {
                    AddMbEventLog(model.JobId, "Error", restServiceResult.Data.APIResult.ToString(), vReturnNotification, true);
                    var emailHelper = new EmailHelper();
                    emailHelper.SendEmail("Failed to notify mixbook of shipped order", "randy.woodall@jostens.com", null, restServiceResult.Data.APIResult.ToString(), EmailType.System);
                }


            }
            else
            {
                AddMbEventLog(model.JobId, "Error", "", vReturnNotification, false);
                var emailHelper = new EmailHelper();
                emailHelper.SendEmail("Failed to notify mixbook of shipped order", "randy.woodall@jostens.com", null, restServiceResult.Errors[0].ErrorMessage, EmailType.System);

            }
            return processingResult ;
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
                emailHelper.SendEmail("Failed to notify item shipped","randy.woodall@jostens.com", null, vBody,EmailType.System);
                return retval;
            }
            retval = sqlResult.Data;
            return retval;
        }

    }
}
