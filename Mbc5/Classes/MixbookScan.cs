using BaseClass;
using BaseClass.Classes;
using BaseClass.Core;
using BindingModels;
using Mbc5.Dialogs;
using Mbc5.Forms.MixBook;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
namespace Mbc5.Classes
{
    public class MixBookScan : IScan
    {
        public MixBookScan(UserPrincipal userPrincipal)
        {
            Log = LogManager.GetLogger(GetType().FullName);
            // Constructor logic if needed
            ApplicationUser = userPrincipal;
        }
        protected MXBScanData data { get; set; }
        public UserPrincipal ApplicationUser { get; set; }
        string Invno { get; set; }
        protected Logger Log { get; set; }
        private MXBScanData scanData { get; set; }
        private frmBarScan Scanform { get; set; }
        private static readonly string _matrixPrinterA = ConfigurationManager.AppSettings["MatrixPrinterA"].ToString();
        private static readonly string _matrixPrinterB = ConfigurationManager.AppSettings["MatrixPrinterB"].ToString();
        private MixBookBarScanModel MbxModel { get; set; }

        public bool Scan(ScanData model)
        {
            this.data = model.MxbScanData;
            this.Scanform = (frmBarScan)data.ScanForm;
            this.scanData = data;
            string vInvno = "";
            if (data.Barcode.Length == 12)
            {
                vInvno = data.Barcode.Substring(3, data.Barcode.Length - 5);
            }
            else if (data.Barcode.Length == 11)
            {
                vInvno = data.Barcode.Substring(4, data.Barcode.Length - 4);
            }
            else
            {
                MbcMessageBox.Error("Scan code is not in correct format");
                return false;
            }
            this.Invno = vInvno;
            int parsedInvno = 0;
            var parseResult = int.TryParse(vInvno, out parsedInvno);

            if (!parseResult)
            {
                MbcMessageBox.Information("Invalid scan code");
                return false;
            }
            //////////////////////Check if order exists
            //////////////////// var sqlQuery = new SQLCustomClient();
            //////////////////// string cmdText = @"
            ////////////////////                                 SELECT M.ShipName,M.ProdInOrder,(Select Max(ProdInOrder) from MixbookOrder where ClientOrderId=M.ClientOrderId)AS NumProducts,M.ClientOrderId,M.PrintergyFile,M.ItemId,M.JobId,M.Invno,M.Backing,M.ShipMethod,M.CoverPreviewUrl,M.BookPreviewUrl,M.Copies As Quantity,P.ProdNo,
            ////////////////////                                 M.MixbookOrderStatus,C.Specovr,WD.MxbLocation AS BookLocation
            ////////////////////                                 From MixBookOrder M Left Join Produtn P ON M.Invno=P.Invno
            ////////////////////                                 Left Join Covers C ON M.Invno=C.Invno
            ////////////////////                                 Left Join WipDetail WD On M.Invno=WD.Invno AND WD.DescripId IN (Select TOP 1 DescripId From wipdetail where  COALESCE(mxbLocation,'')!='' AND Invno=M.Invno  Order by DescripId desc )Where M.Invno=@Invno";
            //////////////////// sqlQuery.CommandText(cmdText);
            //////////////////// sqlQuery.AddParameter("@Invno",vInvno);
            //////////////////// var result = sqlQuery.Select<MixBookBarScanModel>();
            //////////////////// if (result.IsError)
            //////////////////// {
            ////////////////////     MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////////////////////     Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retieve order for scan:" + result.Errors[0].DeveloperMessage);
            ////////////////////     return false;
            //////////////////// }
            //////////////////// if (result.Data == null)
            //////////////////// {
            ////////////////////     MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ////////////////////     return false;
            //////////////////// }
            ////////////////////var MbxModel = (MixBookBarScanModel)result.Data;
            //////////////////// if (MbxModel.MixbookOrderStatus != null && MbxModel.MixbookOrderStatus.Trim().ToUpper() == "CANCELLED" || MbxModel.MixbookOrderStatus != null && MbxModel.MixbookOrderStatus.Trim().ToUpper() == "SHIPPED")
            //////////////////// {
            ////////////////////     if (this.ApplicationUser.UserName.ToUpper() != "TRIMMING")
            ////////////////////     {
            ////////////////////         MbcMessageBox.Information("This order has been " + MbxModel.MixbookOrderStatus.ToUpper());

            ////////////////////         return false;
            ////////////////////     }
            //////////////////// }
            //////////////////// lblBkLocation.Text = MbxModel.BookLocation;
            //////////////////// txtDateTime.Text = DateTime.Now.ToString();





            ////to impersonate finish later
            string currentUser = GetDepartmentInitials(data.Department.DeptCode);

            if (data.Remake.Remake)
            {
                return ScanRemake();

            }

            int QtyToScan = 0;
            try
            {
                int.TryParse(data.Remake.RemakeQty, out QtyToScan);
            }
            catch { }
            ////update record by login
            var sqlClient = new SQLCustomClient();
            string trkType = data.Barcode.Substring(data.Barcode.Length - 2, 2);
            string company = data.Barcode.Substring(0, 3);
            DateTime vDateTime = DateTime.Now;
            string vWIR = "SYS";
            if (!ScanCheck(parsedInvno, currentUser, trkType))
            {
                return false;
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

                            return false;
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
                            return false;
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
                            return false;
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set BookStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "Press");
                        sqlClient.Update();

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
                            return false;
                        }
                        if (sqlResult.Data != "0")
                        {


                            var dialogResult = MessageBox.Show("There is already a scan for this login, do you want to overwrite the scan with this one?", "Duplicate Scan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.No)
                            {

                                MbcMessageBox.Information("Scanned has been cancelled.");
                                return true;
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
                            return false;
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
                            return false;
                        }

                        //Mark says orders will not be split on location so insert into one location
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update Wipdetail Set MxbLocation=@Location Where Invno=@Invno And DescripID=@DescripID  ");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@DescripID", vDeptCode);
                        sqlClient.AddParameter("@Location", Scanform.txtLocation.Text);
                        var locationresult1 = sqlClient.Update();
                        if (locationresult1.IsError)
                        {
                            MbcMessageBox.Error("Failed to update location of order.");

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

                        sqlClient.AddParameter("@CurrentBookLoc", Scanform.txtLocation.Text);
                        var orderLocResult2 = sqlClient.Update();
                        if (orderLocResult2.IsError)
                        {
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update location in order tabel of order invno:" + Invno.ToString());
                        }

                        sqlClient.ClearParameters();

                        sqlClient.CommandText(@"Update MixbookOrder Set BookStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "Trimming");

                        var result111 = sqlClient.Update();

                        break;
                    case "BINDING2":
                        //war is datetime
                        //wir is initials

                        if (string.IsNullOrEmpty(Scanform.txtLocation.Text) && MbxModel.Backing == "HC")
                        {
                            MbcMessageBox.Hand("Please enter a location.", "Enter Location");
                            return false;
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
                            return false;
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
                            return false;
                        }

                        if (MbxModel.Backing == "HC")
                        {
                            //string _Location = txtLocation.Text + this.Invno.ToString().Substring(1, 7) + "   X" + this.Invno.ToString().Substring(7, this.Invno.ToString().Length - 7);
                            string _Location = "   X" + this.Invno.ToString().Substring(7, this.Invno.ToString().Length - 7);
                            if (ConfigurationManager.AppSettings["Environment"].ToString() != "DEV")
                            {

                                if (!this.scanData.PrintToLabeler)
                                {
                                    PrintDataMatrix(this.scanData.Barcode, _Location);//
                                }
                                else
                                {
                                    //Print to labeler
                                    List<BookBlockLabel> listData = new List<BookBlockLabel>();
                                    var vData = new BookBlockLabel() { Barcode = "*" + this.scanData.Barcode + "*", Location = _Location };//
                                    listData.Add(vData);
                                    this.Scanform.reportViewer2.LocalReport.DataSources.Clear();
                                    this.Scanform.reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321MixbookBookBlock.rdlc";
                                    this.Scanform.reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("dsBookBlock", listData));
                                    DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN
                                    dp.Export(true, this.Scanform.reportViewer2.LocalReport, Scanform.LabelPrinter);
                                }
                            }
                            //Mark says orders will not be split on location so insert into one location
                            sqlClient.ClearParameters();
                            sqlClient.CommandText(@"Update Wipdetail Set MxbLocation=@Location Where Invno=@Invno And DescripID=@DescripID  ");
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.AddParameter("@DescripID", vDeptCode);
                            sqlClient.AddParameter("@Location", Scanform.txtLocation.Text);
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
                        sqlClient.AddParameter("@CurrentBookLoc", Scanform.txtLocation.Text);
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

                        break;

                    case "BINDING":
                        //war is datetime
                        //wir is initials
                        if (string.IsNullOrEmpty(Scanform.txtLocation.Text) && MbxModel.Backing == "HC")
                        {
                            MbcMessageBox.Hand("Please enter a location.", "Enter Location");
                            return false;
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
                            return false;
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

                        var result123 = sqlClient.Insert();
                        if (result123.IsError)
                        {
                            MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert scan.", result123.Errors[0].DeveloperMessage);
                            return false;
                        }

                        if (MbxModel.Backing == "HC")
                        {
                            string _Location = "   X" + this.Invno.ToString().Substring(7, this.Invno.ToString().Length - 7);
                            if (ConfigurationManager.AppSettings["Environment"].ToString() != "DEV")
                            {

                                if (!this.scanData.PrintToLabeler)
                                {
                                    PrintDataMatrix(this.scanData.Barcode, _Location);
                                }
                                else
                                {
                                    //Print to labeler
                                    List<BookBlockLabel> listData = new List<BookBlockLabel>();
                                    var vData = new BookBlockLabel() { Barcode = "*" + scanData.Barcode + "*", Location = Scanform.txtLocation.Text };
                                    listData.Add(vData);
                                    this.Scanform.reportViewer2.LocalReport.DataSources.Clear();
                                    this.Scanform.reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321MixbookBookBlock.rdlc";
                                    this.Scanform.reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("dsBookBlock", listData));
                                    DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN
                                    dp.Export(true, this.Scanform.reportViewer2.LocalReport, Scanform.LabelPrinter);
                                }
                            }
                            //Mark says orders will not be split on location so insert into one location
                            sqlClient.ClearParameters();
                            sqlClient.CommandText(@"Update Wipdetail Set MxbLocation=@Location Where Invno=@Invno And DescripID=@DescripID  ");
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.AddParameter("@DescripID", vDeptCode);
                            sqlClient.AddParameter("@Location", Scanform.txtLocation.Text);
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
                        sqlClient.AddParameter("@CurrentBookLoc", Scanform.txtLocation.Text); //this.Scanform.txtLocation
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
                            return false;
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
                            return false;
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set BookStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "Casein");
                        sqlClient.Update();

                        break;
                    case "QUALITY":
                        Scanform.lblHoldLocation.Text = "";//clear last scan
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
                                return false;
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

                                    Scanform.lblHoldLocation.Text = holdLocation;
                                }
                                else
                                {
                                    Scanform.lblHoldLocation.Text = "";
                                }
                            }
                        }


                        string printeryPath = ConfigurationManager.AppSettings["PrintergyPath"].ToString();
                        //try
                        //{
                        //    if (!string.IsNullOrEmpty(MbxModel.PrintergyFile))
                        //    {

                        //        Process.Start(MbxModel.BookPreviewUrl);
                        //        Process.Start(MbxModel.CoverPreviewUrl);
                        //        var dialogResult = MessageBox.Show("Do images match the product?", "Quality Check", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                        //        if (dialogResult != DialogResult.Yes)
                        //        {
                        //            MbcMessageBox.Exclamation("Contact a supervisor immediatly about the mismatch.");
                        //            return;
                        //        }
                        //        else if (dialogResult == DialogResult.Yes)
                        //        {
                        //            var processes = Process.GetProcessesByName("chrome");
                        //            foreach (var process in processes)
                        //            {
                        //                process.Kill();
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        MbcMessageBox.Hand("Preview file is missing. Contact a supervisor.", "Preview file is Missing");
                        //        return;
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    MbcMessageBox.Error("An error has occurred:" + ex.Message);
                        //    Log.Warn("An error has occurred:" + ex.Message + " | Model:" + JsonConvert.SerializeObject(MbxModel));
                        //    lblHoldLocation.Text = "";
                        //    return;
                        //}
                        string location = "";
                        if (MbxModel.NumProducts > 1)
                        {
                            var frmQH = new frmquailtyHold(MbxModel.NumProducts, Scanform.lblHoldLocation.Text);
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
                            return false;
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
                            return false;
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
                            return false;
                        }
                        var orderData = (List<OrderChk>)orderCheck.Data;

                        if (orderData != null && orderData.Count > 1)
                        {
                            bool orderDone = true;
                            string strLoc = "";
                            foreach (var row in orderData)
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

                                this.Scanform.lblBkLocation.Text = strLoc;
                                var printResult = MessageBox.Show("Order is complete, all items have been scanned. Would you like to print a packing slip? " + strLoc, "Order Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    ;
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

                        sqlClient.AddParameter("@Invno", this.Invno);
                        var remakeResult = sqlClient.Select<RemakeChk>();
                        if (remakeResult.IsError)
                        {
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(remakeResult.Errors[0].DeveloperMessage);
                            //go on we are not stopping the process
                        }
                        var remakeData = (RemakeChk)remakeResult.Data;
                        //msg num of remakes
                        if (remakeData != null && remakeData.Remake && remakeData.FullRemake > 1)
                        {
                            if (MbxModel.Quantity > 1)
                            {
                                MbcMessageBox.Information("THIS IS A REMAKE: You should have " + remakeData.FullRemake.ToString() + "remake copies in this order");
                            }
                        }
                        else
                        {
                            if (MbxModel.Quantity > 1)
                            {
                                MbcMessageBox.Information("You should have " + MbxModel.Quantity.ToString() + " copies in this order");
                            }
                        }

                        string input = Interaction.InputBox("Qty in Order:" + MbxModel.Quantity.ToString(), "Assign Cover Location", "Enter A Location");
                        string updateLocation = input;
                        if (string.IsNullOrEmpty(input))
                        {
                            MbcMessageBox.Information("Scan has been canceled.");
                            return false;
                        }
                        if (input.Length > 2)
                        {
                            MbcMessageBox.Information("Invalid location, please enter another location. Scan has been canceled.", "Invalid Location");
                            return false;
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
                            return false;
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
                            return false;
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set CurrentCoverLoc=@CurrentCoverLoc Where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@CurrentCoverLoc", updateLocation);
                        var orderLocResult = sqlClient.Update();
                        if (orderLocResult.IsError)
                        {
                            Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update cover location in order tabel of order invno:" + Invno.ToString() + " Input:" + updateLocation + " | " + JsonConvert.SerializeObject(orderLocResult));
                        }
                        sqlClient.ClearParameters();
                        sqlClient.CommandText(@"Update MixbookOrder Set CoverStatus=@BookStatus where Invno=@Invno");
                        sqlClient.AddParameter("@Invno", this.Invno);
                        sqlClient.AddParameter("@BookStatus", "OnBoard");
                        sqlClient.Update();

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
                            return false;
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
                            return false;
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

                        break;
                    case "PRESS":
                        vDeptCode = "29";
                        vWIR = "PS";
                        //war is datetime
                        //wir is initials
                        if (!WipCheck(vDeptCode, "SC"))
                        {

                            return false;
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

                        break;
                    default:
                        MbcMessageBox.Stop("Login not found for scan.", "Missing Login");
                        break;
                }
            }



            return true;
        }

        public bool ScanRemake()
        {
            return true; // Placeholder return value, implement logic as needed
        }
        public void AddEventLog(string jobId, string status, string note, string notificationXML, bool notified)
        {

        }
        public void AddMbEventLog(string jobId, string status, string note, string notificationXML, bool notified)
        {

            //var sqlClient = new SQLCustomClient();
            //sqlClient.CommandText(@"Insert Into MixBookEventLog (JobId,DateCreated,ModifiedDate,StatusChangedTo,Notified,Note,NotificationXML) Values(@JobId,GetDate(),GETDATE(),@StatusChangedTo,@Notified,@Note,@NotificationXML)");
            //sqlClient.AddParameter("@Jobid", jobId);
            //sqlClient.AddParameter("@StatusChangedTo", status);
            //sqlClient.AddParameter("@Notified", notified);
            //sqlClient.AddParameter("@Note", note);
            //sqlClient.AddParameter("@NotificationXML", notificationXML);
            //var sqlResult = sqlClient.Insert();
            //if (sqlResult.IsError)
            //{
            //    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(sqlResult.Errors[0].DeveloperMessage);
            //    var emailHelper = new EmailHelper();
            //    string vBody = "Failed to insert values JobId:" + jobId + " StatusChangedTo:" + status + " Notified:" + notified + " Note:" + note;
            //    emailHelper.SendEmail("Failed to notify item shipped", "randy.woodall@jostens.com", null, vBody, EmailType.System);
            //    return retval;
            //}
            //retval = sqlResult.Data;

        }
        public bool ScanCheck(int invno, string login, string type)
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
        public bool WipCheck(string vDeptCode)
        {
            return WipCheck(vDeptCode, "");
        }
        public bool WipCheck(string vDeptCode, string type)
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
                    if (countResult.Data != "" && countResult.Data != "0")
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

        protected string GetDepartmentInitials(string _deptCode)
        {
            string vIntitials = string.Empty;
            switch (_deptCode)
            {
                case "40":
                    vIntitials = "SHP";
                    break;
                case "29":
                    vIntitials = "PS";
                    break;

            }
            return vIntitials;
        }

        //public async Task<ApiProcessingResult> NotifyMixbookOfShipment(ShippingNotificationInfo model)
        //{
        //    var processingResult = new ApiProcessingResult();
        //    var returnNotification = new MixbookNotification();

        //    returnNotification.Request.identifier = model.JobId;//needs to be set with jobid should always have one element
        //    returnNotification.Request.Status.occurredAt = DateTime.Now;
        //    returnNotification.Request.Status.Value = "Shipped";
        //    returnNotification.Request.Shipment[0].trackingNumber = model.TrackingNumber;
        //    returnNotification.Request.Shipment[0].shippedAt = DateTime.Now;
        //    returnNotification.Request.Shipment[0].method = model.ShipMethod;
        //    returnNotification.Request.Shipment[0].weight = model.Weight;
        //    returnNotification.Request.Shipment[0].Package[0].Item.identifier = model.ItemId;
        //    returnNotification.Request.Shipment[0].Package[0].Item.quantity = model.Qty;
        //    var vReturnNotification = Serialize.ToXml(returnNotification);

        //    var restServiceResult = await new RESTService().MakeRESTCall("POST", vReturnNotification);
        //    if (!restServiceResult.IsError)
        //    {
        //        if (restServiceResult.Data.APIResult.ToString().Contains("Success"))
        //        {
        //            //if not set to notified scheduled task will try again
        //            AddMbEventLog(model.JobId, "Shipped", "", vReturnNotification, true);
        //        }
        //        else
        //        {
        //            AddMbEventLog(model.JobId, "Error", restServiceResult.Data.APIResult.ToString(), vReturnNotification, true);
        //            var emailHelper = new EmailHelper();
        //            emailHelper.SendEmail("Failed to notify mixbook of shipped order", "randy.woodall@jostens.com", null, restServiceResult.Data.APIResult.ToString(), EmailType.System);
        //        }
        //    }
        //    else
        //    {
        //        AddMbEventLog(model.JobId, "Error", "", vReturnNotification, false);
        //        var emailHelper = new EmailHelper();
        //        emailHelper.SendEmail("Failed to notify mixbook of shipped order", "randy.woodall@jostens.com", null, restServiceResult.Errors[0].ErrorMessage, EmailType.System);
        //    }
        //    return processingResult;
        //}

        private void PrintDataMatrix(string vbarcode, string vlocation)
        {
            string ip = "";

            if (this.ApplicationUser.UserName == "binding")
            {
                ip = _matrixPrinterA;

            }
            else if (this.ApplicationUser.UserName == "binding2")
            {
                ip = _matrixPrinterB;

            }

            try
            {
                TcpClient client = new TcpClient(ip, 10200);

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

            this.Scanform.reportViewer1.LocalReport.DataSources.Clear();
            this.Scanform.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookPkgList.rdlc";
            this.Scanform.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsMxPackingSlip", packingSlipData));
            this.Scanform.reportViewer1.LocalReport.EnableExternalImages = true;
            this.Scanform.reportViewer1.RefreshReport();
        }
    }
}