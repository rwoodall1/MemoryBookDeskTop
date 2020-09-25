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
using System.Diagnostics;
using Mbc5.Dialogs;
using System.Drawing.Printing;
using Microsoft.ReportingServices.RdlObjectModel;
using System.Net.Sockets;

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
        public string LabelPrinter { get; set; }
        public string Company { get; set; }
        public UserPrincipal ApplicationUser { get; set; }
        public MixBookBarScanModel MbxModel { get; set; }
        public int QuantityScanned { get; set; } = 0;
        public int PkgQuantity{get;set;}=0;
        public List<PackageData> PrintedPackageList { get; set; } = new List<PackageData>();
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
                this.Company = txtBarCode.Text.ToUpper().Substring(0, 3);
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
                            SELECT M.ShipName,M.ProdInOrder,M.ClientOrderId,M.PrintergyFile,M.ItemId,M.JobId,M.Invno,M.Backing,M.ShipMethod,M.CoverPreviewUrl,M.BookPreviewUrl,M.Copies As Quantity,P.ProdNo,C.Specovr,WD.MxbLocation AS BookLocation
                                From MixBookOrder M Left Join Produtn P ON M.Invno=P.Invno
                                Left Join Covers C ON M.Invno=C.Invno
                                Left Join WipDetail WD On M.Invno=WD.Invno AND WD.DescripId IN (Select TOP 1 DescripId From wipdetail where  COALESCE(mxbLocation,'')!='' AND Invno=M.Invno  Order by DescripId desc )Where M.Invno=@Invno";
                            sqlQuery.CommandText(cmdText);
                            sqlQuery.AddParameter("@Invno", Invno);
                            var result = sqlQuery.Select<MixBookBarScanModel>();
                            if (result.IsError)
                            {
                                MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (result.Data == null)
                            {
                                MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            MbxModel = (MixBookBarScanModel)result.Data;
                            //Not using right now
                            //if (MbxModel.Quantity > 1)
                            //{
                            //    PackageData record = this.PrintedPackageList.Find(x => x.Barcode == txtBarCode.Text);
                            //    if (record == null)
                            //    {
                            //        this.PrintedPackageList.Add(new PackageData()
                            //        {
                            //            Barcode = txtBarCode.Text,
                            //            Copies = MbxModel.Quantity,
                            //            Scanned = 0
                            //        });
                            //    }
                            //}
                           
                            lblBkLocation.Text = MbxModel.BookLocation;

                        
                            //txtSchcode.Text = MbxModel.JobId;
                            //txtSchoolName.Text = MbxModel.ShipName;
                            //txtCoverNumber.Text = MbxModel.Specovr;
                            //txtColorPageNumber.Text = "";
                            //txtProdNumber.Text = MbxModel.ProdNo;
                            txtDateTime.Text = DateTime.Now.ToString();
                            if (this.ApplicationUser.UserName.ToUpper() == "SHIPPING")
                            {
                                if (!string.IsNullOrEmpty(txtTrackingNo.Text) && !string.IsNullOrEmpty(txtWeight.Text))
                                {
                                    MXBScan();
                                    ClearScan();
                                }
                                txtTrackingNo.Focus();
                            }
                            else
                            {
                                MXBScan();
                                 ClearScan();
                            }

                            break;

                        }
                }
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error("An error has occured:" + ex.Message);
            }
        }
        private void ClearScan()
        {
                txtBarCode.Text = "";
                txtDateTime.Text = "";
                txtTrackingNo.Text = "";
                txtWeight.Text = "";
            chkRemake.Checked = false;

                MbxModel = null;
            txtBarCode.Focus();
            
        }

        private void MXBScan()
        {
            //to impersonate finish later
            //string currentUser = "";
            //if (!string.IsNullOrEmpty(txtImpersonate.Text))
            //{
            //    currentUser = txtImpersonate.Text.ToUpper() ;
            //}
            //else
            //{
            //    currentUser = ApplicationUser.UserName.ToUpper();
            //}
            if (chkRemake.Checked)
            {
                ScanRamake();
                return;
            }
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
                        vWIR = "PS";
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
                        vWIR = "BIN";
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
                        if (!chkPrToLabeler.Checked)
                        {
                            PrintDataMatrix(txtBarCode.Text, txtLocation.Text);
                        }
                        else
                        {
                            //Print to labeler
                            List<BookBlockLabel> listData = new List<BookBlockLabel>();
                            var vData = new BookBlockLabel() { Barcode ="*"+ txtBarCode.Text+"*", Location = txtLocation.Text };
                            listData.Add(vData);

                            reportViewer2.LocalReport.DataSources.Clear();
                            reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321MixbookBookBlock.rdlc";
                            reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("dsBookBlock", listData));
                            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN
                            dp.Export(true,reportViewer2.LocalReport,this.LabelPrinter);
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
                       
                            //if (MbxModel.Quantity == 1)//not using right now
                            //{
                            PrintPackingList(MbxModel.ClientOrderId);
                            //}else if (MbxModel.Quantity>1)
                            //{
                            //    PackageData record = this.PrintedPackageList.Find(x=>x.Barcode==txtBarCode.Text);
                            //    if (record == null)
                            //    {
                            //        return;
                            //    }
                            //    record.Scanned += 1;
                            //    if (record.Scanned==1)
                            //    {
                            //        PrintPackingList(MbxModel.ClientOrderId);
                            //    }
                            //    if (record.Scanned == record.Copies)
                            //    {
                            //        PrintedPackageList.Remove(record);
                            //    }
                            //}
                        
                        ClearScan();
                        
                        break;
                    case "CASEIN":
                        //war is datetime
                        //wir is initials
                        vDeptCode = "49";
                        vWIR = "CI";
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
                        vWIR = "QY";
                        string printeryPath =ConfigurationManager.AppSettings["PrintergyPath"].ToString();
                        try
                        {
                            if (!string.IsNullOrEmpty(MbxModel.PrintergyFile))
                            {
                               
                                var ac = printeryPath + "\\" + MbxModel.PrintergyFile;
                                Process.Start(printeryPath + "\\" + MbxModel.PrintergyFile);
                                //Process.Start(MbxModel.BookPreviewUrl);
                                var dialogResult = MessageBox.Show("Do images match the product?", "Quality Check", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                                if (dialogResult != DialogResult.Yes)
                                {

                                    MbcMessageBox.Exclamation("Contact a supervisor immediatly about the mismatch.");
                                    return;
                                }
                                else if (dialogResult == DialogResult.Yes)
                                {
                                    var processes = Process.GetProcessesByName("chrome");
                                    foreach (var process in processes)
                                    {
                                        process.Kill();

                                    }
                                }
                            }
                            else
                            {
                                MbcMessageBox.Hand("Preview file is missing. Contact a supervisor.", "Preview file is Missing");
                                return;
                            }
                        }catch(Exception ex)
                        {
                            MbcMessageBox.Error("An error has occurred:" + ex.Message);
                            return;
                        }

                        string location = "";
                        var frmQH = new frmquailtyHold();
                        DialogResult holdresult=frmQH.ShowDialog();
                        if (holdresult==DialogResult.Yes)
                        {
                            location = frmQH.Location;
                        }

                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.AddParameter("@MxbLocation", location);
                           
                            sqlClient.CommandText(@"Update WIPDetail SET
                                 WAR=@WAR, WIR =@WIR,MxbLocation=@MxbLocation WHERE Invno=@Invno AND DescripID=@DescripID");
                      
                        
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
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Select MO.Invno,WD.MxbLocation From MixbookOrder MO
                                                 Left Join WipDetail WD ON MO.Invno=WD.Invno AND WD.DescripId=50
                                                where  MO.ClientOrderId=@ClientOrderId");
                        sqlClient.AddParameter("@ClientOrderId", MbxModel.ClientOrderId);
                        var orderCheck=sqlClient.SelectMany<OrderChk>();
                        if (orderCheck.IsError)
                        {
                            MbcMessageBox.Error("Failed to check if order complete,please check manually.");
                        }
                        var data =(List<OrderChk>) orderCheck.Data;
                       
                        if(data!=null && data.Count > 1)
                        {
                            bool orderDone = true;
                            string strLoc = "";
                            foreach (var row in data)
                            {
                                
                                if (row.MxbLocation != null)
                                {
                                    strLoc += row.MxbLocation + " | ";
                                    
                                }
                                else
                                {
                                    orderDone = false;
                                    break;
                                }
                            }
                            if (orderDone)
                            {
                                lblBkLocation.Text = strLoc;
                                MbcMessageBox.Information("Order is complete, all items have been scanned. "+strLoc);
                                
                            }
                        }

                         
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
                            vWIR = "SH";
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
                        vWIR = "OB";
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
                        vWIR = "TR";
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
                        vWIR = "PS";
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
                        vWIR = "OB2";
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
        private void ScanRamake()
        {
            if (string.IsNullOrEmpty(txtReasonCode.Text))
            {
                MbcMessageBox.Stop("Scan a reason code","Reason Code");
                return;
            }
            string trkType = txtBarCode.Text.Substring(txtBarCode.Text.Length - 2, 2);
            var sqlClient = new SQLCustomClient();
            if (trkType == "SC"|| ApplicationUser.UserName.ToUpper()=="QUALITY")
            {
                sqlClient.CommandText(@"Delete From COVERDETAIL Where INVNO=@Invno");
                sqlClient.AddParameter("@Invno", this.Invno);
                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Failed to remove cover scans for this order. Try again or contact a supervisor.");
                    return;
                }
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"UPDATE COVERS SET  Reprntdte=GETDATE(),remake=1,persondest=@persondest,specinst=@Memo Where INVNO=@Invno");
                string vmemo = "Remake issued by:" + ApplicationUser.UserName.ToUpper();
                sqlClient.AddParameter("@Memo", vmemo);
                sqlClient.AddParameter("@persondest", ApplicationUser.UserName.ToUpper());
                sqlClient.AddParameter("@Invno", this.Invno);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    MbcMessageBox.Error("Failed to update cover reprint date.");
                    return;
                }
                if (ApplicationUser.UserName.ToUpper() == "QUALITY")
                {
                    sqlClient.ClearParameters();
                    sqlClient.CommandText(@"Delete From WIPDETAIL Where INVNO=@Invno");
                    sqlClient.AddParameter("@Invno", this.Invno);
                    var deleteResult1 = sqlClient.Delete();
                    if (deleteResult1.IsError)
                    {
                        MbcMessageBox.Error("Failed to remove wip scans for this order. Try again or contact a supervisor.");
                        return;
                    }
                    sqlClient.ClearParameters();
                    string vmemo1 = "Remake issued by:" + ApplicationUser.UserName.ToUpper();
                    sqlClient.CommandText(@"UPDATE WIP SET  RmbTo=GETDATE(),iinit=@iinit,WipMemo=@Memo Where INVNO=@Invno");
                    sqlClient.AddParameter("@iinit", ApplicationUser.UserName.ToUpper());
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@Memo", vmemo1);
                    var updateResult1 = sqlClient.Update();
                    if (updateResult.IsError)
                    {
                        MbcMessageBox.Error("Failed to update wip remake date.");
                        return;
                    }
                }
            
            }
            else if(trkType == "YB" )
            {
                sqlClient.CommandText(@"Delete From WIPDETAIL Where INVNO=@Invno");
                sqlClient.AddParameter("@Invno", this.Invno);
                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Failed to remove wip scans for this order. Try again or contact a supervisor.");
                    return;
                }
                sqlClient.ClearParameters();
                string vmemo = "Remake issued by:" + ApplicationUser.UserName.ToUpper();
                sqlClient.CommandText(@"UPDATE WIP SET  RmbTo=GETDATE(),iinit=@iinit,WipMemo=@Memo Where INVNO=@Invno");
                sqlClient.AddParameter("@iinit", ApplicationUser.UserName.ToUpper());
                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.AddParameter("@Memo", vmemo);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    MbcMessageBox.Error("Failed to update wip remake date.");
                    return;
                }
            }
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
                lblBkLoc.Visible = true;
                lblBkLocation.Visible = true;
                pnlQty.Visible = true;
                if (ApplicationUser.UserName == "binding") { chkPrToLabeler.Visible = true; }
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

       
        private void PrintPackingList(int vClientOrderId)
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Select MO.Invno,MO.ShipName,MO.ShipAddr,MO.ShipAddr2,MO.ShipCity,MO.ShipState,'*MXB'+CAST(MO.Invno AS varchar)+'YB*' AS BarCode
            ,MO.ShipZip,MO.OrderNumber,MO.ClientOrderId,MO.Copies,Mo.Pages,Mo.Description,Mo.ItemCode,MO.JobId,MO.ItemId, SC.ShipName AS ShipMethod,CD.MxbLocation AS CoverLocation
            FROM MixbookOrder MO
               Left Join ShipCarriers SC On MO.ShipMethod=SC.ShipAlias
                Left Join CoverDetail CD On MO.Invno=CD.Invno AND CD.DescripId IN (Select TOP 1 DescripId From coverdetail where  COALESCE(mxbLocation,'')!='' AND Invno=MO.Invno  Order by DescripId desc ) Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", vClientOrderId);
            var result=sqlClient.SelectMany<MixbookPackingSlip>();
            if (result.IsError|| result.Data==null)
            {
                MbcMessageBox.Error("Failed to retrieve order, packing slip could not be printed");
                return;
            }
         var packingSlipData=(List<MixbookPackingSlip>)result.Data;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookPkgList.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsMxPackingSlip", packingSlipData));
            reportViewer1.RefreshReport();
        }
        private void PrintDataMatrix(string vbarcode,string vlocation)
        {
            try
            {
                TcpClient client = new TcpClient("10.37.16.168", 10200);

                //byte[] escapeb = new byte[] { 0x1B, 0x43, 0x0D };
                //string escape = System.Text.Encoding.ASCII.GetString(escapeb);
                byte[] stxb = new byte[] { 0x02 };
                string stx = System.Text.Encoding.ASCII.GetString(stxb);
                byte[] crb = new byte[] { 0x0D };
                string cr = System.Text.Encoding.ASCII.GetString(crb);
                byte[] etxb = new byte[] { 0x03 };
                string etx = System.Text.Encoding.ASCII.GetString(etxb);
                byte[] templateb = Encoding.ASCII.GetBytes("TZmxb.00I;10");
                string template = System.Text.Encoding.ASCII.GetString(templateb);
                byte[] soh1b = new byte[] { 0x31, 0x01 };
                string soh1 = System.Text.Encoding.ASCII.GetString(soh1b);
                byte[] soh2b = new byte[] { 0x33, 0x01 };
                string soh2 = System.Text.Encoding.ASCII.GetString(soh2b);
                string location = vlocation;
                string barcode = vbarcode;
                string datas = stx + template + cr + soh1 + barcode + cr + soh2 + location + cr + etx;
                byte[] data = Encoding.ASCII.GetBytes(datas);
               NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                byte[] bytes = new byte[client.ReceiveBufferSize];

                // Read can return anything from 0 to numBytesToRead.
                // This method blocks until at least one byte is read.
                stream.Read(bytes, 0, (int)client.ReceiveBufferSize);

                // Returns the data received from the host to the console.
                string returndata = Encoding.UTF8.GetString(bytes);
                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            PrinterSettings printerName = new PrinterSettings();
            string printer = printerName.PrinterName;
            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            var result = dp.Export(reportViewer1.LocalReport, printer,false);

            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            Cursor.Current = Cursors.Default;
        }

        private void chkRemake_Click(object sender, EventArgs e)
        {
            if (chkRemake.Checked)
            {
                pnlQty.Visible = false;
                plnTracking.Visible = false;
                pnlRemake.Visible = true;
                txtReasonCode.Focus();
            }
            else
            {
                pnlRemake.Visible = false;
                if (ApplicationUser.UserName == "shipping")
                {
                    plnTracking.Visible = true;
                }
                else if (ApplicationUser.UserName == "onboard" || ApplicationUser.UserName == "onboard2" || ApplicationUser.UserName == "trimming" || ApplicationUser.UserName == "binding")
                {

                    pnlQty.Visible = true;
                }

            }
        }

        private void chkPrToLabeler_Click(object sender, EventArgs e)
        {
            if (chkPrToLabeler.Checked)
            {
                printDialog1.ShowDialog();
                LabelPrinter = printDialog1.PrinterSettings.PrinterName;
            }
            else
            {
                LabelPrinter = "";
            }
        }

        private void chkPrToLabeler_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnClearPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient client = new TcpClient("10.37.16.168", 10200);

                byte[] escapeb = new byte[] { 0x1B };
                string escape = System.Text.Encoding.ASCII.GetString(escapeb);
                byte[] stxb = new byte[] { 0x02 };
                string stx = System.Text.Encoding.ASCII.GetString(stxb);
                byte[] crb = new byte[] { 0x0D };
                string cr = System.Text.Encoding.ASCII.GetString(crb);
                byte[] etxb = new byte[] { 0x03 };
                string etx = System.Text.Encoding.ASCII.GetString(etxb);
                byte[] templateb = Encoding.ASCII.GetBytes("TZmxb.00I;10");
                string template = System.Text.Encoding.ASCII.GetString(templateb);
                byte[] soh1b = new byte[] { 0x31, 0x01 };
                string soh1 = System.Text.Encoding.ASCII.GetString(soh1b);
                byte[] soh2b = new byte[] { 0x33, 0x01 };
                string soh2 = System.Text.Encoding.ASCII.GetString(soh2b);
               
                string datas = stx + "CLR"+etx;
                byte[] data = Encoding.ASCII.GetBytes(datas);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                byte[] bytes = new byte[client.ReceiveBufferSize];

                // Read can return anything from 0 to numBytesToRead.
                // This method blocks until at least one byte is read.
                stream.Read(bytes, 0, (int)client.ReceiveBufferSize);

                // Returns the data received from the host to the console.
                string returndata = Encoding.UTF8.GetString(bytes);
                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintPackingList(3899710);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var a = 1;
            PrintPackingList(3905429);
            //PrintPackingList(3905432);
        }
    }
    public class PackageData
    {
        public string Barcode { get; set; }
        public int Copies { get; set; }
        public int Scanned { get; set; }
    }
}
