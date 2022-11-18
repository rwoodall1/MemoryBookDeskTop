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
using Microsoft.VisualBasic;
using Newtonsoft.Json;
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
        private static readonly string _matrixPrinterA=ConfigurationManager.AppSettings["MatrixPrinterA"].ToString();
        private static readonly string _matrixPrinterB = ConfigurationManager.AppSettings["MatrixPrinterB"].ToString();
        public string LabelPrinter { get; set; }
        public string Company { get; set; }
        public UserPrincipal ApplicationUser { get; set; }
        public MixBookBarScanModel MbxModel { get; set; }
        public int QuantityScanned { get; set; } = 0;
        public int PkgQuantity { get; set; } = 0;
        public List<PackageData> PrintedPackageList { get; set; } = new List<PackageData>();
        private void frmMxBookBarScan_Load(object sender, EventArgs e)
        {
            txtQtyToScan.Text = "40"; //default
            if (ApplicationUser.UserName.ToUpper() == "ONBOARD" || ApplicationUser.UserName.ToUpper() == "TRIMMING" || ApplicationUser.UserName.ToUpper() == "BINDING"|| ApplicationUser.UserName.ToUpper() == "BINDING2")
            {
                if (ApplicationUser.UserName.ToUpper() == "BINDING"|| ApplicationUser.UserName.ToUpper() == "BINDING2")
                {
                    chkPrToLabeler.Visible = true;
                    btnClearPrinter.Visible = true;
                    pnlQty.Visible = true;
                    pnlBookLocation.Visible = true;
                }
                if (ApplicationUser.UserName.ToUpper() == "ONBOARD")
                {
                    pnlQty.Visible = false;
                    pnlBookLocation.Visible = true;
                }
                if (ApplicationUser.UserName.ToUpper() == "TRIMMING")
                {
                    //pnlQty.Visible = true;
                    //pnlBookLocation.Visible = true;
                }

            }
            else if (ApplicationUser.UserName.ToUpper() == "QUALITY")
            {
                pnlHoldLocation.Visible = true;
            }
            else if (ApplicationUser.IsInOneOfRoles(new List<string>() { "SA", "Administrator" }))
            {
                pnlQty.Visible = true;
                pnlImpersonate.Visible = true;
            };
        }
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
                            vInvno = txtBarCode.Text.Substring(3, txtBarCode.Text.Length - 5);
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
                                            SELECT M.ShipName,M.ProdInOrder,(Select Max(ProdInOrder) from MixbookOrder where ClientOrderId=M.ClientOrderId)AS NumProducts,M.ClientOrderId,M.PrintergyFile,M.ItemId,M.JobId,M.Invno,M.Backing,M.ShipMethod,M.CoverPreviewUrl,M.BookPreviewUrl,M.Copies As Quantity,P.ProdNo,
                                            M.MixbookOrderStatus,C.Specovr,WD.MxbLocation AS BookLocation
                                            From MixBookOrder M Left Join Produtn P ON M.Invno=P.Invno
                                            Left Join Covers C ON M.Invno=C.Invno
                                            Left Join WipDetail WD On M.Invno=WD.Invno AND WD.DescripId IN (Select TOP 1 DescripId From wipdetail where  COALESCE(mxbLocation,'')!='' AND Invno=M.Invno  Order by DescripId desc )Where M.Invno=@Invno";
                                sqlQuery.CommandText(cmdText);
                                sqlQuery.AddParameter("@Invno", Invno);
                                var result = sqlQuery.Select<MixBookBarScanModel>();
                                if (result.IsError)
                                {
                                    MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retieve order for scan:" + result.Errors[0].DeveloperMessage);
                                    return;
                                }
                                if (result.Data == null)
                                {
                                    MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return;
                                }
                                MbxModel = (MixBookBarScanModel)result.Data;
                                if (MbxModel.MixbookOrderStatus != null && MbxModel.MixbookOrderStatus.Trim().ToUpper() == "CANCELLED" || MbxModel.MixbookOrderStatus != null && MbxModel.MixbookOrderStatus.Trim().ToUpper() == "SHIPPED")
                                {
                                if (this.ApplicationUser.UserName.ToUpper() !="TRIMMING") {
                                    MbcMessageBox.Information("This order has been " + MbxModel.MixbookOrderStatus.ToUpper());
                                    ClearScan();
                                    return;
                                }
                                }
                                lblBkLocation.Text = MbxModel.BookLocation;
                                txtDateTime.Text = DateTime.Now.ToString();
                                MXBScan();
                                ClearScan();
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error("An error has occured:" + ex.Message + " Stack: "+ ex.StackTrace);
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("An error has occured:" + ex.Message);
                    ClearScan();
            }
            
        }
        private void ClearScan()
        {
            txtBarCode.Text = "";
            txtDateTime.Text = "";

            chkRemake.Checked = false;

            MbxModel = null;
            txtBarCode.Focus();
        }
        private void MXBScan()
        {
            //to impersonate finish later
            string currentUser = "";
            if (!string.IsNullOrEmpty(cmbLogin.Text))
            {
                currentUser = cmbLogin.Text;
            }
            else
            {
                currentUser = ApplicationUser.UserName.ToUpper();
            }
            if (chkRemake.Checked)
            {
                ScanRemake(currentUser);
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
            if (!ScanCheck(this.Invno, currentUser, trkType))
            {
                return;
            }
            if (trkType == "YB")
            {
                string vDeptCode = "";
                switch (currentUser)
                {

                    case "PRESS":
                        vDeptCode = "29";
                        vWIR = "PS";
                        //war is datetime
                        //wir is initials
                        //check if scan exist stop if it does per tf
                        if (!WipCheck(vDeptCode, "YB"))
                        {
                           
                            return;
                        }
                        sqlClient.ClearParameters();
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
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update scan.", mxResult.Errors[0].DeveloperMessage);
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
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert scan.", result1.Errors[0].DeveloperMessage);
                            return;
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set BookStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "Press");
                        sqlClient.Update();
                        ClearScan();
                        break;
                    case "TRIMMING":

                        vDeptCode = "43";
                        vWIR = "TR";
                        if (!WipCheck(vDeptCode, "YB"))
                        {
                            
                            //return; do not check for duplicate
                        }
                      
                        string cmd = "Select Count(Invno) AS NumRec from WipDetail where DescripId=@DescripId AND Invno=@Invno";


                        sqlClient.CommandText(cmd);
                        sqlClient.AddParameter("@Invno", Invno);
                        sqlClient.AddParameter("@DescripId", "43");
                        var sqlResult = sqlClient.SelectSingleColumn();
                        if (sqlResult.IsError)
                        {
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retrieve scan for trim scan check:" + sqlResult.Errors[0].DeveloperMessage);
                            MbcMessageBox.Error("Failed to retrieve scan for trim scan check:" + sqlResult.Errors[0].DeveloperMessage);
                            return;
                        }
                        if (sqlResult.Data != "0")
                        {


                            var dialogResult = MessageBox.Show("There is already a scan for this login, do you want to overwrite the scan with this one?", "Duplicate Scan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.No)
                            {

                                MbcMessageBox.Information("Scanned has been cancelled.");
                                return;
                            }
                        }

                        //war is datetime
                        //wir is initials

                        sqlClient.ClearParameters();
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update WipDetail SET WAR= @WAR , WIR =@WIR   WHERE Invno=@Invno AND DescripID=@DescripID ");
                        var mxResult11 = sqlClient.Update();
                        if (mxResult11.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update scan." + mxResult11.Errors[0].DeveloperMessage);
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
                                                    INSERT INTO WipDetail (DescripID,War,Wir,Invno,Jobno) VALUES(@DescripID,@WAR,@WIR,@Invno,@Jobno);
                                                    END
                                                    ");

                        var result11 = sqlClient.Insert();
                        if (result11.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert scan." + result11.Errors[0].DeveloperMessage);
                            return;
                        }
                        //Mark says orders will not be split on location so insert into one location
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update Wipdetail Set MxbLocation=@Location Where Invno=@Invno And DescripID=@DescripID  ");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@Location", txtLocation.Text);
                        var locationresult1 = sqlClient.Update();
                        if (locationresult1.IsError)
                        {
                            MbcMessageBox.Error("Failed to update location of order.");
                            ExceptionlessClient.Default.CreateLog("Failed to update location of book invno:" + Invno.ToString());
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update location of book invno:" + Invno.ToString());
                        }
                        //QuantityScanned += 1; took out per tf
                        //lblScanQty.Text = QuantityScanned.ToString();
                        //if (QuantityScanned >= QtyToScan)
                        //{
                        //    MbcMessageBox.Hand("Quantity scanned is " + QtyToScan + ". Click OK then enter new location to start over.", "Quantity");
                        //    QuantityScanned = 0;
                        //    lblScanQty.Text = QuantityScanned.ToString();
                        //}

                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set CurrentBookLoc=@CurrentBookLoc Where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@CurrentBookLoc", txtLocation.Text);
                        var orderLocResult2 = sqlClient.Update();
                        if (orderLocResult2.IsError)
                        {
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update location in order tabel of order invno:" + Invno.ToString());
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set BookStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "Trimming");
                        sqlClient.Update();
                        ClearScan();
                        break;
                    case "BINDING2":
                        //war is datetime
                        //wir is initials
                        if (string.IsNullOrEmpty(txtLocation.Text) && MbxModel.Backing == "HC")
                        {
                            MbcMessageBox.Hand("Please enter a location.", "Enter Location");
                            return;
                        }
                        vDeptCode = "39";
                        vWIR = "BIN";
                        WipCheck(vDeptCode);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update WIPDetail SET
                                                WAR=@WAR,WIR = @WIR WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult1 = sqlClient.Update();
                        if (mxResult1.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to upate scan.", mxResult1.Errors[0].DeveloperMessage);
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
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert scan.", result.Errors[0].DeveloperMessage);
                            return;
                        }

                        if (MbxModel.Backing == "HC")
                        {
                            if (ConfigurationManager.AppSettings["Environment"].ToString() != "DEV")
                            {
                                if (!chkPrToLabeler.Checked)
                                {
                                    PrintDataMatrix(txtBarCode.Text,txtLocation.Text );//
                                }
                                else
                                {
                                    //Print to labeler
                                    List<BookBlockLabel> listData = new List<BookBlockLabel>();
                                    var vData = new BookBlockLabel() { Barcode = "*" + txtBarCode.Text + "*", Location =txtLocation.Text  };//
                                    listData.Add(vData);
                                    reportViewer2.LocalReport.DataSources.Clear();
                                    reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321MixbookBookBlock.rdlc";
                                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("dsBookBlock", listData));
                                    DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN
                                    dp.Export(true, reportViewer2.LocalReport, this.LabelPrinter);
                                }
                            }
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

                                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update location of order invno:" + Invno.ToString());
                            }
                            //QuantityScanned += 1; took out per tf
                            //lblScanQty.Text = QuantityScanned.ToString();

                            //if (QuantityScanned >= QtyToScan)
                            //{
                            //    MbcMessageBox.Hand("Quantity scanned is " + QtyToScan + ". Click OK then enter new location to start over.", "Quantity");
                            //    QuantityScanned = 0;
                            //    lblScanQty.Text = QuantityScanned.ToString();
                            //}
                        }

                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set CurrentBookLoc=@CurrentBookLoc Where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@CurrentBookLoc", txtLocation.Text);
                        var orderLocResult1 = sqlClient.Update();
                        if (orderLocResult1.IsError)
                        {
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update location in order tabel of order invno:" + Invno.ToString());
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set BookStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "Binding");
                        sqlClient.Update();
                        ClearScan();
                        break;

                    case "BINDING":
                        //war is datetime
                        //wir is initials
                        if (string.IsNullOrEmpty(txtLocation.Text) && MbxModel.Backing == "HC")
                        {
                            MbcMessageBox.Hand("Please enter a location.", "Enter Location");
                            return;
                        }
                        vDeptCode = "39";
                        vWIR = "BIN";
                        WipCheck(vDeptCode);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.CommandText(@"Update WIPDetail SET
                                                WAR=@WAR,WIR = @WIR WHERE Invno=@Invno AND DescripID=@DescripID ");

                        var mxResult111 = sqlClient.Update();
                        if (mxResult111.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to upate scan.", mxResult111.Errors[0].DeveloperMessage);
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

                        var result111 = sqlClient.Insert();
                        if (result111.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert scan.", result111.Errors[0].DeveloperMessage);
                            return;
                        }
                        
                        if (MbxModel.Backing == "HC")
                        {
                            if (ConfigurationManager.AppSettings["Environment"].ToString() != "DEV")
                            {
                                if (!chkPrToLabeler.Checked)
                                {
                                    PrintDataMatrix(txtBarCode.Text, txtLocation.Text);
                                }
                                else
                                {
                                    //Print to labeler
                                    List<BookBlockLabel> listData = new List<BookBlockLabel>();
                                    var vData = new BookBlockLabel() { Barcode = "*" + txtBarCode.Text + "*", Location = txtLocation.Text };
                                    listData.Add(vData);
                                    reportViewer2.LocalReport.DataSources.Clear();
                                    reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321MixbookBookBlock.rdlc";
                                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("dsBookBlock", listData));
                                    DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN
                                    dp.Export(true, reportViewer2.LocalReport, this.LabelPrinter);
                                }
                            }
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

                                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update location of order invno:" + Invno.ToString());
                            }
                            //QuantityScanned += 1; took out per tf
                            //lblScanQty.Text = QuantityScanned.ToString();

                            //if (QuantityScanned >= QtyToScan)
                            //{
                            //    MbcMessageBox.Hand("Quantity scanned is " + QtyToScan + ". Click OK then enter new location to start over.", "Quantity");
                            //    QuantityScanned = 0;
                            //    lblScanQty.Text = QuantityScanned.ToString();
                            //}
                        }

                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set CurrentBookLoc=@CurrentBookLoc Where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@CurrentBookLoc", txtLocation.Text);
                        var orderLocResult11 = sqlClient.Update();
                        if (orderLocResult11.IsError)
                        {
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update location in order tabel of order invno:" + Invno.ToString());
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set BookStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "Binding");
                        sqlClient.Update();
                        ClearScan();
                        break;
                    case "CASEIN":
                        //war is datetime
                        //wir is initials
                        vDeptCode = "49";
                        WipCheck(vDeptCode);
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
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update scan:" + mxResult2.Errors[0].DeveloperMessage);
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
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert scan:" + result2.Errors[0].DeveloperMessage);
                            return;
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set BookStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "Casein");
                        sqlClient.Update();
                        ClearScan();
                        break;
                    case "QUALITY":
                        lblHoldLocation.Text = "";//clear last scan
                        //war is datetime
                        //wir is initials
                        //PrintPackingList(MbxModel.ClientOrderId);
                        vDeptCode = "50";
                        vWIR = "QY";
                        int ScannedProducts = 0;
                        string holdLocation = "";
                        sqlClient.ClearParameters();
                        sqlClient.AddParameter("@Invno", Invno);
                        sqlClient.CommandText(@"Select MixbookOrderStatus from MixbookOrder Where Invno=@Invno AND MixbookOrderStatus='Shipped'  ");
                        var shipCheckResult = sqlClient.SelectSingleColumn();
                        if (!shipCheckResult.IsError)
                        {
                            if (shipCheckResult.Data != null && shipCheckResult.Data != "")
                            {
                                MbcMessageBox.Error("This item has been marked as shipped. Notify supervisor, it could be a duplicate order.");
                                return;
                            }
                        }
                        //Check for child item on hold
                        sqlClient.ClearParameters();
                        sqlClient.AddParameter("@ClientOrderId", MbxModel.ClientOrderId);
                        sqlClient.CommandText(@"Select MO.ClientOrderId,MO.Invno,WD.MxbLocation,WD.DescripId 
                                                FROM MixbookOrder MO Left Join WipDetail WD On MO.Invno=WD.invno
                                                Where   WD.DescripId=50 AND ClientOrderId=@ClientOrderId");

                        var holdCheckResult = sqlClient.SelectMany<SiblingCheck>();

                        if (!holdCheckResult.IsError)
                        {
                            var vData = (List<SiblingCheck>)holdCheckResult.Data;
                            //ScannedProducts = vData.Count==null?0:vData.Count;
                            if (holdCheckResult.Data != null && vData.Count > 0)
                            {
                                var recsWithLocations = vData.FindAll(a => a.MxbLocation != null && a.MxbLocation != "");
                                if (recsWithLocations.Count > 0)
                                {
                                    holdLocation = string.IsNullOrEmpty(recsWithLocations[0].MxbLocation) ? "" : recsWithLocations[0].MxbLocation;

                                    lblHoldLocation.Text = holdLocation;
                                }
                                else
                                {
                                    lblHoldLocation.Text = "";
                                }
                            }
                        }
                        string printeryPath = ConfigurationManager.AppSettings["PrintergyPath"].ToString();
                        try
                        {
                            if (!string.IsNullOrEmpty(MbxModel.PrintergyFile))
                            {
                                //var ac = printeryPath + "\\" + MbxModel.PrintergyFile;
                                //Process.Start(printeryPath + "\\" + MbxModel.PrintergyFile);
                                Process.Start(MbxModel.BookPreviewUrl);
                                Process.Start(MbxModel.CoverPreviewUrl);
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
                        }
                        catch (Exception ex)
                        {
                            MbcMessageBox.Error("An error has occurred:" + ex.Message);
                            Log.Warn("An error has occurred:" + ex.Message+" | Model:"+ JsonConvert.SerializeObject(MbxModel));
                            lblHoldLocation.Text = "";
                            return;
                        }
                        string location = "";
                        if (MbxModel.NumProducts > 1)
                        {
                            var frmQH = new frmquailtyHold(MbxModel.NumProducts, lblHoldLocation.Text);
                            DialogResult holdresult = frmQH.ShowDialog();
                            if (holdresult == DialogResult.Yes)
                            {
                                location = frmQH.Location;
                                sqlClient.ClearParameters();
                                sqlClient.CommandText(@"Update MixbookOrder Set CurrentBookLoc=@CurrentBookLoc,CurrentCoverLoc=@CurrentCoverLoc Where Invno=@Invno");
                                sqlClient.AddParameter("@Invno", this.Invno);
                                sqlClient.AddParameter("@CurrentBookLoc", location);
                                sqlClient.AddParameter("@CurrentCoverLoc", location);
                                var orderLocResult = sqlClient.Update();
                                if (orderLocResult.IsError)
                                {
                                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update location in order tabel of order invno:" + Invno.ToString());
                                }
                            }
                            
                        }
                        else { PrintPackingList(MbxModel.ClientOrderId); }
                        sqlClient.ClearParameters();
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
                            MessageBox.Show("Failed to update scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update scan." + mxResult3.Errors[0].DeveloperMessage);
                            return;
                        }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.AddParameter("@MxbLocation", location);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO WipDetail (DescripID,War,Wir,MxbLocation,Invno) VALUES(@DescripID,@WAR,@WIR,@MxbLocation,@Invno);
                                                    END
                                                    ");

                        var result3 = sqlClient.Insert();
                        if (result3.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert scan." + result3.Errors[0].DeveloperMessage);
                            return;
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Select MO.Invno,WD.MxbLocation From MixbookOrder MO
                                                Left Join WipDetail WD ON MO.Invno=WD.Invno AND WD.DescripId=50
                                                where  MO.ClientOrderId=@ClientOrderId");
                        sqlClient.AddParameter("@ClientOrderId", MbxModel.ClientOrderId);
                        var orderCheck = sqlClient.SelectMany<OrderChk>();
                        if (orderCheck.IsError)
                        {
                            MbcMessageBox.Error("Failed to check if order complete,please check manually.");
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to check if order complete:" + orderCheck.Errors[0].DeveloperMessage);
                            return;
                        }
                        var data = (List<OrderChk>)orderCheck.Data;

                        if (data != null && data.Count > 1)
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
                                var printResult=MessageBox.Show("Order is complete, all items have been scanned. Would you like to print a packing slip? " + strLoc,"Order Complete",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                                if (printResult == DialogResult.Yes)
                                {
                                    PrintPackingList(MbxModel.ClientOrderId);
                                }
                            }
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set BookStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "Quality");
                        sqlClient.Update();
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
                switch (currentUser)
                {
                    case "ONBOARD":
                        vDeptCode = "37";
                        vWIR = "OB";
                        if (!WipCheck(vDeptCode, "SC"))
                        {

                            //return;
                        }

                        //msg if quality remake

                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Select FullRemake,Remake
                                                from Covers C 
                                                Where C.Invno=@Invno And Remake = 1 ");
                                                  
                        sqlClient.AddParameter("@Invno", MbxModel.Invno);
                        var remakeResult = sqlClient.Select<RemakeChk>();
                        if (remakeResult.IsError)
                        {
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(remakeResult.Errors[0].DeveloperMessage);
                           //go on we are not stopping the process
                        }
                        var remakeData =(RemakeChk) remakeResult.Data;
                        //msg num of remakes
                        if ( remakeData!=null && remakeData.Remake && remakeData.FullRemake>1)
                        {
                            if (MbxModel.Quantity > 1)
                            {
                                MbcMessageBox.Information("THIS IS A REMAKE: You should have " + remakeData.FullRemake.ToString() + "remake copies in this order");
                            }
                        }
                        else {
                            if (MbxModel.Quantity > 1)
                            {
                                MbcMessageBox.Information("You should have " + MbxModel.Quantity.ToString() + " copies in this order");
                            }
                        }
                       
                        string input = Interaction.InputBox("Qty in Order:"+ MbxModel.Quantity.ToString(), "Assign Cover Location", "Enter A Location");
                           string updateLocation = input;
                            if (string.IsNullOrEmpty(input))
                            {
                                MbcMessageBox.Information("Scan has been canceled.");
                                return;
                            }
                            if (input.Length > 2)
                            {
                                MbcMessageBox.Information("Invalid location, please enter another location. Scan has been canceled.", "Invalid Location");
                                return;
                            }
                       
                        //war is datetime
                        //wir is initials
                        sqlClient.ClearParameters();
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.AddParameter("@Location", updateLocation);
                        sqlClient.CommandText(@"Update CoverDetail SET WAR= @WAR , WIR =@WIR,MxbLocation=@Location  WHERE Invno=@Invno AND DescripID=@DescripID ");
                        var mxResult = sqlClient.Update();
                        if (mxResult.IsError)
                        {
                            MessageBox.Show("Failed to update scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update scan:" + mxResult.Errors[0].DeveloperMessage);
                            return;
                        }
                        sqlClient.ClearParameters();
                        sqlClient.ReturnSqlIdentityId(true);
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@WAR", vDateTime);
                        sqlClient.AddParameter("@WIR", vWIR);
                        sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                        sqlClient.AddParameter("@Location", updateLocation);
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                    Begin
                                                    INSERT INTO CoverDetail (DescripID,War,Wir,Invno,Jobno,MxbLocation) VALUES(@DescripID,@WAR,@WIR,@Invno,@Jobno,@Location);
                                                    END
                                                    ");

                        var result = sqlClient.Insert();
                        if (result.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert scan:" + result.Errors[0].DeveloperMessage);
                            return;
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set CurrentCoverLoc=@CurrentCoverLoc Where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@CurrentCoverLoc", updateLocation);
                        var orderLocResult = sqlClient.Update();
                        if (orderLocResult.IsError)
                        {
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update cover location in order tabel of order invno:" + Invno.ToString()+" Input:"+ updateLocation + " | "+JsonConvert.SerializeObject(orderLocResult));
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set CoverStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "OnBoard");
                        sqlClient.Update();
                       
                        ClearScan();
                        break;
                    case "TRIMMING":
                        vDeptCode = "43";
                        vWIR = "TR";
                        //war is datetime
                        //wir is initials
                        if (!WipCheck(vDeptCode, "SC"))
                        {
                        
                            //return;
                        }
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
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update scan:" + mxResult1.Errors[0].DeveloperMessage);
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
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert scan:" + result1.Errors[0].DeveloperMessage);
                            return;
                        }
                        //took out per tf
                        //QuantityScanned += 1;
                        //lblScanQty.Text = QuantityScanned.ToString();
                        //if (QuantityScanned >= QtyToScan)
                        //{
                        //    MbcMessageBox.Hand("Quantity scanned is " + QtyToScan + ". Click OK then enter new location to start over.", "Quantity");
                        //    QuantityScanned = 0;
                        //    lblScanQty.Text = QuantityScanned.ToString();
                        //}
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set CoverStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "Trimming");
                        sqlClient.Update();
                        ClearScan();
                        break;
                    case "PRESS":
                        vDeptCode = "29";
                        vWIR = "PS";
                        //war is datetime
                        //wir is initials
                        if (!WipCheck(vDeptCode, "SC"))
                        {
                          
                            return;
                        }
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
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update scan:" + mxResult2.Errors[0].DeveloperMessage);
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
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert scan:" + result2.Errors[0].DeveloperMessage);
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set CoverStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "Press");
                        sqlClient.Update();
                        ClearScan();
                        break;
                    default:
                        MbcMessageBox.Stop("Login not found for scan.", "Missing Login");
                        break;
                }
            }
            ClearScan();
        }
        private void ScanRemake(string currentUser)
        {

            if (string.IsNullOrEmpty(txtReasonCode.Text))
            {
                MbcMessageBox.Stop("Scan a reason code", "Reason Code");
                return;
            }
            if (txtReasonCode.Text.Length > 2)
            {
                MbcMessageBox.Stop("Invalid Reason Code", "Reason Code");
                return;
            }
            int vReason = 0;
            if (!int.TryParse(txtReasonCode.Text, out vReason))
            {
                MbcMessageBox.Error("Invalid reason code.");
                return;
            }

            int vRemakeQuantity =this.MbxModel.Quantity ;
            //if (ApplicationUser.UserName.ToUpper() == "QUALITY")
            //{
                if (string.IsNullOrEmpty(txtRemakeQty.Text))
                {
                    MbcMessageBox.Stop("Enter a quantity", "Quantity");
                    return;
                }
              
                if (!int.TryParse(txtRemakeQty.Text, out vRemakeQuantity))
                {
                    MbcMessageBox.Error("Invalid Quantity");
                    return;
                }
                if (vRemakeQuantity == 0)
                {
                    MbcMessageBox.Error("Quantity can not be zero");
                    return;
                }
           // }
            string trkType = txtBarCode.Text.Substring(txtBarCode.Text.Length - 2, 2);
            var sqlClient = new SQLCustomClient();
            if (currentUser == "QUALITY")
            {
                sqlClient.CommandText(@"Delete From COVERDETAIL Where INVNO=@Invno");
                sqlClient.AddParameter("@Invno", this.Invno);
                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Failed to remove cover scans for this order. Try again or contact a supervisor.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to remove cover scans for this order. Try again or contact a supervisor." + deleteResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"UPDATE COVERS SET  Reprntdte=GETDATE()
                                    ,remake=1
                                    ,FullRemake=@FullRemake
                                    ,RemakeReason=@RemakeReason
                                    ,persondest=@persondest
                                    ,specinst=@Memo +' | ' + CONVERT(varchar(max),COALESCE(specinst,'')) Where INVNO=@Invno");
                string vmemo = "Remake issued by:" + ApplicationUser.UserName.ToUpper() + " on " + DateTime.Now.ToString();
                sqlClient.AddParameter("@Memo", vmemo);
                sqlClient.AddParameter("FullRemake", vRemakeQuantity);
                sqlClient.AddParameter("@persondest", ApplicationUser.UserName.ToUpper());
                sqlClient.AddParameter("@Invno", this.Invno);
                if (vReason == 0)
                {
                    MbcMessageBox.Error("Invalid reason code.");
                    return;
                }

                sqlClient.AddParameter("@RemakeReason", vReason);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    MbcMessageBox.Error("Failed to update cover reprint date.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update cover reprint date:" + updateResult.Errors[0].DeveloperMessage);
                    return;
                }

                //Wip
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Delete From WIPDETAIL Where INVNO=@Invno");
                sqlClient.AddParameter("@Invno", this.Invno);
                var deleteResult1 = sqlClient.Delete();
                if (deleteResult1.IsError)
                {
                    MbcMessageBox.Error("Failed to remove wip scans for this order. Try again or contact a supervisor.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to remove wip scans for this order:" + deleteResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                string vmemo1 = "Remake issued by:" + ApplicationUser.UserName.ToUpper() + " on " + DateTime.Now.ToString();
                sqlClient.CommandText(@"UPDATE WIP SET  RmbTo=GETDATE(),iinit=@iinit,Rmbtot=@RmbTot,WipMemo= @Memo +' | ' + Convert(nvarchar(max),COALESCE(WipMemo,'')),RemakeReason=@RemakeReason Where INVNO=@Invno");
                sqlClient.AddParameter("@iinit", ApplicationUser.UserName.ToUpper());
                sqlClient.AddParameter("@RmbTot", vRemakeQuantity);
                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.AddParameter("@Memo", vmemo1);
                if (vReason == 0)
                {
                    MbcMessageBox.Error("Invalid reason code.");
                    return;
                }
                sqlClient.AddParameter("@RemakeReason", vReason);
                var updateResult1 = sqlClient.Update();
                if (updateResult1.IsError)
                {
                    MbcMessageBox.Error("Failed to update wip remake date.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update wip remake date:" + updateResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Update MixbookOrder SET CoverStatus='',BookStatus='',CurrentBookLoc='',CurrentCoverLoc='',RemakeTicketPrinted=0 where Invno=@Invno");
                sqlClient.AddParameter("@Invno", Invno);
                var result22=sqlClient.Update();
                if(result22.IsError)
                {
                    MbcMessageBox.Error("Failed to update Order remake data.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update Mixbook Order Remake Data Q:" + result22.Errors[0].DeveloperMessage);
                    return;
                }
            }
            else if (trkType == "SC")
            {
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Delete From COVERDETAIL Where INVNO=@Invno");
                sqlClient.AddParameter("@Invno", this.Invno);

                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Failed to remove cover scans for this order. Try again or contact a supervisor.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to remove cover scans for this order. Try again or contact a supervisor." + deleteResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"UPDATE COVERS SET  Reprntdte=GETDATE(),FullRemake=@FullRemake,remake=1,RemakeReason=@RemakeReason,persondest=@persondest,specinst=@Memo +' | ' + Convert(nvarchar(max),COALESCE(specinst,''))  Where INVNO=@Invno");
                string vmemo = "Remake issued by:" + ApplicationUser.UserName.ToUpper() + " on " + DateTime.Now.ToString();
                sqlClient.AddParameter("@Memo", vmemo);
                sqlClient.AddParameter("FullRemake", vRemakeQuantity);
                sqlClient.AddParameter("@persondest", ApplicationUser.UserName.ToUpper());
                sqlClient.AddParameter("@Invno", this.Invno);
                if (vReason == 0)
                {
                    MbcMessageBox.Error("Invalid reason code.");
                    return;
                }
                sqlClient.AddParameter("@RemakeReason", vReason);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    MbcMessageBox.Error("Failed to update cover reprint date.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update cover reprint date:" + updateResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Update MixbookOrder SET CoverStatus='',CurrentCoverLoc='' where Invno=@Invno");
                sqlClient.AddParameter("@Invno", Invno);
                var updateResult11=sqlClient.Update();
                if (updateResult11.IsError)
                {
                    MbcMessageBox.Error("Failed to update Order remake data.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update Mixbook Order Remake Data SC:" + updateResult11.Errors[0].DeveloperMessage);
                    return;
                }
                txtReasonCode.Text = "";

            }
            else if (trkType == "YB")
            {
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Delete From WIPDETAIL Where INVNO=@Invno");
                sqlClient.AddParameter("@Invno", this.Invno);
                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Failed to remove wip scans for this order. Try again or contact a supervisor.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to remove wip scans for this order:" + deleteResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                string vmemo = "Remake issued by:" + ApplicationUser.UserName.ToUpper() + " on " + DateTime.Now.ToString(); 
                sqlClient.CommandText(@"UPDATE WIP SET  RmbTo=GETDATE(),RmbTot=@RmbTot,iinit=@iinit,RemakeReason=@RemakeReason,WipMemo=@Memo + ' | ' + Convert(nvarchar(max),COALESCE(WipMemo,' '))   Where INVNO=@Invno");
                sqlClient.AddParameter("@iinit", ApplicationUser.UserName.ToUpper());
                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.AddParameter("@RmbTot", vRemakeQuantity);
                sqlClient.AddParameter("@Memo", vmemo);
                if (vReason == 0)
                {
                    MbcMessageBox.Error("Invalid reason code.");
                    return;
                }
                sqlClient.AddParameter("@RemakeReason", vReason);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    MbcMessageBox.Error("Failed to update wip remake date.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update wip remake date:" + updateResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Update MixbookOrder SET BookStatus='',CurrentBookLoc='',RemakeTicketPrinted=0 where Invno=@Invno");
                sqlClient.AddParameter("@Invno", Invno);
                var updateResul1t=sqlClient.Update();
                if (updateResul1t.IsError)
                {
                    MbcMessageBox.Error("Failed to update Order remake data.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update Mixbook Order Remake Data YB:" + updateResul1t.Errors[0].DeveloperMessage);
                    return;
                }

            }
            txtRemakeQty.Text = "0";
            txtReasonCode.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarCode.Text))
            {
                txtBarCode_Leave(this.btnSave, null);
            }
        }
        public async Task<ApiProcessingResult> NotifyMixbookOfShipment(ShippingNotificationInfo model)
        {
            var processingResult = new ApiProcessingResult();
            var returnNotification = new MixbookNotification();

            returnNotification.Request.identifier = model.JobId;//needs to be set with jobid should always have one element
            returnNotification.Request.Status.occurredAt = DateTime.Now;
            returnNotification.Request.Status.Value = "Shipped";
            returnNotification.Request.Shipment[0].trackingNumber = model.TrackingNumber;
            returnNotification.Request.Shipment[0].shippedAt = DateTime.Now;
            returnNotification.Request.Shipment[0].method = model.ShipMethod;
            returnNotification.Request.Shipment[0].weight = model.Weight;
            returnNotification.Request.Shipment[0].Package[0].Item.identifier = model.ItemId;
            returnNotification.Request.Shipment[0].Package[0].Item.quantity = model.Qty;
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
            return processingResult;
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
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(sqlResult.Errors[0].DeveloperMessage);
                var emailHelper = new EmailHelper();
                string vBody = "Failed to insert values JobId:" + jobId + " StatusChangedTo:" + status + " Notified:" + notified + " Note:" + note;
                emailHelper.SendEmail("Failed to notify item shipped", "randy.woodall@jostens.com", null, vBody, EmailType.System);
                return retval;
            }
            retval = sqlResult.Data;
            return retval;
        }
        private void PrintPackingList(int vClientOrderId)
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Select MO.Invno,MO.ShipName,MO.ShipAddr,MO.ShipAddr2,MO.ShipCity,MO.ShipState,'*MXB'+CAST(MO.Invno AS varchar)+'YB*' AS BarCode,MO.CoverPreviewUrl
                                    ,MO.ShipZip,MO.OrderNumber,MO.ClientOrderId,MO.Copies,Mo.Pages,Mo.Description,Mo.ItemCode,MO.JobId,MO.ItemId, SC.ShipName AS ShipMethod,SC.Carrier,CD.MxbLocation AS CoverLocation,WD.MxbLocation As BookLocation
                                    FROM MixbookOrder MO
                                    Left Join ShipCarriers SC On MO.ShipMethod=SC.ShipAlias
                                    Left Join CoverDetail CD On MO.Invno=CD.Invno AND CD.DescripId IN (Select TOP 1 DescripId From coverdetail where  COALESCE(mxbLocation,'')!='' AND Invno=MO.Invno  Order by DescripId desc )
                                    Left Join WipDetail WD On MO.Invno=WD.Invno AND WD.DescripId IN (Select TOP 1 DescripId From wipdetail where  COALESCE(mxbLocation,'')!='' AND Invno=MO.Invno  Order by DescripId desc ) 
                                    Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", vClientOrderId);
            var result = sqlClient.SelectMany<MixbookPackingSlip>();
            if (result.IsError || result.Data == null)
            {
                MbcMessageBox.Error("Failed to retrieve order, packing slip could not be printed");
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retrieve order, packing slip could not be printed:" + result.Errors[0].DeveloperMessage);
                return;
            }
            var packingSlipData = (List<MixbookPackingSlip>)result.Data;
            
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookPkgList.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsMxPackingSlip", packingSlipData));
            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.RefreshReport();
        }
        private void PrintDataMatrix(string vbarcode, string vlocation)
        {
            string ip="";
            
            if (this.ApplicationUser.UserName == "binding")
            {
                 ip = _matrixPrinterA;

            }
            else if(this.ApplicationUser.UserName == "binding2")
            {
                ip = _matrixPrinterB;
           
            }
          
            try
            {
                TcpClient client = new TcpClient(ip,10200);

                //byte[] escapeb = new byte[] { 0x1B, 0x43, 0x0D };
                //string escape = System.Text.Encoding.ASCII.GetString(escapeb);
                byte[] stxb = new byte[] { 0x02 };
                string stx = System.Text.Encoding.ASCII.GetString(stxb);
                byte[] crb = new byte[] { 0x0D };
                string cr = System.Text.Encoding.ASCII.GetString(crb);
                byte[] etxb = new byte[] { 0x03 };
                string etx = System.Text.Encoding.ASCII.GetString(etxb);
                byte[] templateb = Encoding.ASCII.GetBytes("TZmxb.00I;10");
                string template = System.Text.Encoding.ASCII.GetString(templateb); //if different printer be sure to change templates
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
                
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to print DataMatrix Label");
            }
        }
        private bool ScanCheck(int invno, string login,string type)
        {
           
            bool retval = true;
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Select MixbookOrderStatus  FROM MixbookOrder Where Invno=@Invno ");
            sqlClient.AddParameter("@Invno", invno);
            var result = sqlClient.SelectSingleColumn();
            if (result.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retrieve order status for scan:" + result.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to retrieve order status for scan:" + result.Errors[0].DeveloperMessage);
                retval = false;
                return retval;
            }
            string vStatus = result.Data;
            if (vStatus == "Cancelled" || vStatus == "Hold" || vStatus == "Shipped")
            {
                if (ApplicationUser.UserName.ToUpper() != "TRIMMING")
                {
                    MbcMessageBox.Hand("Order status is " + vStatus + " Contact your supervisor. Scan is cancelled.", "Order Status Error");
                    retval = false;
                    return retval;
                }
            }

         
            return retval;
        }
        private bool WipCheck(string vDeptCode)
        {
            return WipCheck(vDeptCode, "");
        }
        private bool WipCheck(string vDeptCode, string type)
        {

            var sqlClient = new SQLCustomClient();
            bool retval = true;
            ApiProcessingResult<string> countResult = new ApiProcessingResult<string>() { Data = "" };
            if (type == "YB")
            {
                sqlClient.ClearParameters();
                sqlClient.CommandText("Select Count(Invno) FROM WipDetail WHERE Invno=@Invno AND DescripID=@DescripID");
                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.AddParameter("@DescripID", vDeptCode);
                countResult = sqlClient.SelectSingleColumn();
                if (countResult.IsError)
                {
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to check for " + vDeptCode + " scan:" + countResult.Errors[0].DeveloperMessage);
                    MbcMessageBox.Error("Failed to check for duplicate record");
                    return false;
                }
            }
            if (type == "SC")
            {
                sqlClient.ClearParameters();
                sqlClient.CommandText("Select Count(Invno) FROM CoverDetail WHERE Invno=@Invno AND DescripID=@DescripID");
                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.AddParameter("@DescripID", vDeptCode);
                countResult = sqlClient.SelectSingleColumn();
                if (countResult.IsError)
                {
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to check for " + vDeptCode + " scan:" + countResult.Errors[0].DeveloperMessage);
                    MbcMessageBox.Error("Failed to check for duplicate record");
                    return false;
                }
            }
            switch (vDeptCode)
            {
                case "29":
                    if (countResult.Data != "" && countResult.Data != "0" )
                    {
                        MbcMessageBox.Hand("This record may have already been scanned, check for duplicate.", "Duplicate Scan");
                        return false;
                    }
                    break;
                case "43":
                    //if (countResult.Data != "" && countResult.Data != "0")
                    //{
                    //    MbcMessageBox.Hand("This record may have already been scanned, check for duplicate.", "Duplicate Scan");
                    //    return false;
                    //}
                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", "29");
                    sqlClient.AddParameter("@WAR", DateTime.Now);
                    sqlClient.AddParameter("@WIR", "SYS");
                    sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                    if (type == "YB")
                    {
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                Begin
                                                INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                END
                                                ");
                                                                    }
                    else if (type == "SC")
                    {
                        sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                Begin
                                                INSERT INTO CoverDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                END
                                                ");

                    }

                    var result13 = sqlClient.Insert();
                    if (result13.IsError)
                    {

                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert corrective scan.", result13.Errors[0].DeveloperMessage);

                    }
                    break;
                case "37":
                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", "29");
                    sqlClient.AddParameter("@WAR", DateTime.Now);
                    sqlClient.AddParameter("@WIR", "SYS");
                    sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                Begin
                                                INSERT INTO CoverDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                END
                                                ");

                    var result1111 = sqlClient.Insert();
                    if (result1111.IsError)
                    {

                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert corrective scan.", result1111.Errors[0].DeveloperMessage);

                    }
                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", "43");
                    sqlClient.AddParameter("@WAR", DateTime.Now);
                    sqlClient.AddParameter("@WIR", "SYS");
                    sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                Begin
                                                INSERT INTO CoverDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                END
                                                ");

                    var result111 = sqlClient.Insert();
                    if (result111.IsError)
                    {

                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert corrective scan.", result111.Errors[0].DeveloperMessage);

                    }




                    break;
                case "39":
                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", "29");
                    sqlClient.AddParameter("@WAR", DateTime.Now);
                    sqlClient.AddParameter("@WIR", "SYS");
                    sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                Begin
                                                INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                END
                                                ");

                    var result1 = sqlClient.Insert();
                    if (result1.IsError)
                    {

                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert corrective scan.", result1.Errors[0].DeveloperMessage);

                    }
                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", "43");
                    sqlClient.AddParameter("@WAR", DateTime.Now);
                    sqlClient.AddParameter("@WIR", "SYS");
                    sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                Begin
                                                INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                END
                                                ");

                    var result11 = sqlClient.Insert();
                    if (result11.IsError)
                    {
                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert corrective scan.", result11.Errors[0].DeveloperMessage);
                    }
                    break;
                case "49":
                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", "29");
                    sqlClient.AddParameter("@WAR", DateTime.Now);
                    sqlClient.AddParameter("@WIR", "SYS");
                    sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                Begin
                                                INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                END
                                                ");
                    var result12 = sqlClient.Insert();
                    if (result12.IsError)
                    {

                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert corrective scan.", result12.Errors[0].DeveloperMessage);

                    }
                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", "43");
                    sqlClient.AddParameter("@WAR", DateTime.Now);
                    sqlClient.AddParameter("@WIR", "SYS");
                    sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                            Begin
                                            INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                            END
                                            ");

                    var result112 = sqlClient.Insert();
                    if (result112.IsError)
                    {

                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert corrective scan.", result112.Errors[0].DeveloperMessage);

                    }
                    sqlClient.ClearParameters();
                    sqlClient.ReturnSqlIdentityId(true);
                    sqlClient.AddParameter("@Invno", this.Invno);
                    sqlClient.AddParameter("@DescripID", "39");
                    sqlClient.AddParameter("@WAR", DateTime.Now);
                    sqlClient.AddParameter("@WIR", "SYS");
                    sqlClient.AddParameter("@Jobno", MbxModel.JobId);
                    sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                            Begin
                                            INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                            END
                                            ");

                    var result1123 = sqlClient.Insert();
                    if (result1123.IsError)
                    {

                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert corrective scan.", result1123.Errors[0].DeveloperMessage);

                    }
                    break;
            }
            return retval;
        }
        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            PrinterSettings printerName = new PrinterSettings();
            string printer = printerName.PrinterName;
            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            var result = dp.Export(reportViewer1.LocalReport, printer, 2, false);
            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Cursor.Current = Cursors.Default;
        }
        private void chkRemake_Click(object sender, EventArgs e)
        {
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

                string datas = stx + "CLR" + etx;
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
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to print DataMatrix code");
            }
        }

        private void chkRemake_CheckedChanged(object sender, EventArgs e)
        {
            string currentUser = "";
            if (!string.IsNullOrEmpty(cmbLogin.Text))
            {
                currentUser = cmbLogin.Text;
            }
            else
            {
                currentUser = ApplicationUser.UserName.ToUpper();
            }
            if (chkRemake.Checked)
            {
               
                pnlQty.Visible = false;
                pnlRemake.Visible = true;
                //if (currentUser == "QUALITY")
                //{
                    pnlQtyInner.Visible = true;
                //}
                //else { pnlQtyInner.Visible = false; } per tf 11-17-22
                txtReasonCode.Focus();
            
            }
            else
            {
                
                pnlRemake.Visible = false;

                if (currentUser == "BINDING"|| currentUser == "TRIMMING"|| currentUser == "BINDING2" )
                {

                    pnlQty.Visible = true;
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtLocation_Validating(object sender, CancelEventArgs e)
        {
            if (txtLocation.Text.Length > 3)
            {
                MbcMessageBox.Error("Invalid Location,Please re-enter Location");
                e.Cancel = true;
            }
        }

        private void txtBarCode_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void txtReasonCode_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtReasonCode.TextLength >= 2)
            //{
            //    txtRemakeQty.Focus();
              
            //}
        }

        private void txtRemakeQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13 ||e.KeyChar==9) {
                txtBarCode.Focus();
            }
        }

        private void txtRemakeQty_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab) 
            {
               
                e.IsInputKey = true;
            }
        }

        
    }
    public class PackageData
    {
        public string Barcode { get; set; }
        public int Copies { get; set; }
        public int Scanned { get; set; }
    }
}
