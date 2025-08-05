using BaseClass;
using BaseClass.Classes;
using BindingModels;
using NLog;
using System;
using System.Windows.Forms;
namespace Mbc5.Classes
{
    public class JPIXScan : IScan
    {
        public JPIXScan(UserPrincipal userPrincipal)
        {
            Log = LogManager.GetLogger(GetType().FullName);
            this.ApplicationUser = userPrincipal;
            // Constructor logic if needed
        }
        UserPrincipal ApplicationUser { get; set; }
        string Invno { get; set; }
        protected Logger Log { get; set; }
        //public void Scan(string _barcode,string _deptCode, string _custId = "",string _trackingNumber="", string _datetime, bool _remake = false, bool _prntToLabeler = false, int _reasoncode = 0, int _remakeQty = 0)
        public bool Scan(ScanData data)
        {
            if (data == null || string.IsNullOrEmpty(data.Barcode) || string.IsNullOrEmpty(data.Department.DeptCode))
            {

                MbcMessageBox.Error("Invalid scan data provided.");
                return false;
            }

            //string vInitials = this.GetDepartmentInitials(data.Department.DeptCode);
            //if (string.IsNullOrEmpty(vInitials))
            //{
            //    MbcMessageBox.Error("Invalid department code provided. Please check the department code and try again.");
            //    return;
            //}
            try
            {
                this.Invno = data.Barcode.Substring(3);
            }
            catch
            {
                MbcMessageBox.Error("Invalid barcode format. Please ensure the barcode is correct and try again.");
                return false;
            }



            decimal vWtr = data.Department.AutoTime;


            var vWIR = data.Department.Initials;
            var sqlClient = new SQLCustomClient();
            string company = data.Barcode.Substring(0, 3);
            sqlClient.ClearParameters();
            sqlClient.CommandText(@"Select OracleCode from JPIXOrders where Invno=@Invno");
            sqlClient.AddParameter("@Invno", this.Invno);
            var oracleCodeResult = sqlClient.SelectSingleColumn();
            if (oracleCodeResult.IsError)
            {
                Log.Error(oracleCodeResult.Errors[0].DeveloperMessage + "Invno:" + this.Invno);
                MbcMessageBox.Error("Failed to retrieve Oracle code for the order.");
                return false;
            }
            string vOracleCode = oracleCodeResult.Data;
            if (data.Remake.Remake)
            {
                var retval = ScanRemake();
                return retval;
            }
            else
            {

                switch (data.Department.DeptCode)
                {
                    case "40":
                        {
                            //shipped
                            sqlClient.ClearParameters();
                            sqlClient.CommandText(@"Update Produtn Set ShpDate=@ShpDate Where Invno=@Invno");
                            sqlClient.AddParameter("@ShpDate", DateTime.Now);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            var produtnUpdateResult = sqlClient.Update();
                            if (produtnUpdateResult.IsError)
                            {
                                Log.Error(produtnUpdateResult.Errors[0].DeveloperMessage + "ShpDate:" + DateTime.Now.ToString() + "|Invno:" + this.Invno);
                                MbcMessageBox.Error("Failed to update production with shipped date.");
                            }
                            //UPDATE FIRST_________________________________________________________________________________
                            sqlClient.ClearParameters();
                            //war is datetime
                            //wir is initials
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.AddParameter("@DescripID", data.Department.DeptCode);
                            sqlClient.AddParameter("@WAR", DateTime.Now);
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
                                Log.Error("Failed to Update WipDetal:" + result.Errors[0].DeveloperMessage);
                                MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            //INSERT_____________________________________________________________________________________________________________________________
                            sqlClient.ClearParameters();
                            sqlClient.ReturnSqlIdentityId(true);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.AddParameter("@DescripID", data.Department.DeptCode);
                            sqlClient.AddParameter("@WAR", DateTime.Now);
                            sqlClient.AddParameter("@WIR", vWIR);
                            sqlClient.AddParameter("@Wtr", vWtr);
                            sqlClient.AddParameter("@SchcodeCode", "1");
                            sqlClient.AddParameter("@OracleCode", vOracleCode);
                            sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                        Begin
                                        INSERT INTO WipDetail (DescripID,War,Wtr,Wir,Invno,OracleCode,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@OracleCode,@SchcodeCode);
                                        END
                                        ");

                            var result1 = sqlClient.Insert();
                            if (result1.IsError)
                            {
                                Log.Error("Failed to insert WipDetail:" + result1.Errors[0].DeveloperMessage);
                                MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            //_____________________________
                            sqlClient.ClearParameters();
                            sqlClient.CommandText(@"Update JPIXOrders Set DateShipped=@ShippedDate,TrackingNumber=@TrackingNumber,OrderStatus='Shipped' where Invno=@Invno");
                            sqlClient.AddParameter("@ShippedDate", DateTime.Now);
                            sqlClient.AddParameter("@TrackingNumber", data.TrackingNumber.Trim());
                            sqlClient.AddParameter("@Invno", this.Invno);
                            var updateOrderResult = sqlClient.Update();
                            if (updateOrderResult.IsError)
                            {
                                Log.Error("Failed to update JpixOrders:" + updateOrderResult.Errors[0].DeveloperMessage);
                                MessageBox.Show("Failed to update order status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            break;
                        }
                    case "29":
                        {

                            //UPDATE FIRST_________________________________________________________________________________
                            sqlClient.ClearParameters();
                            //war is datetime
                            //wir is initials
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.AddParameter("@DescripID", data.Department.DeptCode);
                            sqlClient.AddParameter("@WAR", DateTime.Now);
                            sqlClient.AddParameter("@WIR", vWIR);
                            sqlClient.AddParameter("@Wtr", vWtr);

                            sqlClient.AddParameter("@OracleCode", vOracleCode);
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
                                Log.Error("Failed to Update WipDetal:" + result.Errors[0].DeveloperMessage);
                                MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            //INSERT_____________________________________________________________________________________________________________________________
                            sqlClient.ClearParameters();
                            sqlClient.ReturnSqlIdentityId(true);
                            sqlClient.AddParameter("@Invno", this.Invno);
                            sqlClient.AddParameter("@DescripID", data.Department.DeptCode);
                            sqlClient.AddParameter("@WAR", DateTime.Now);
                            sqlClient.AddParameter("@WIR", vWIR);
                            sqlClient.AddParameter("@Wtr", vWtr);
                            sqlClient.AddParameter("@Schcode", 1);

                            sqlClient.AddParameter("@OracleCode", vOracleCode);
                            sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                        Begin
                                        INSERT INTO WipDetail (DescripID,War,Wtr,Wir,Invno,OracleCode,Schcode) VALUES(@DescripID,@WAR,@Wtr,@WIR,@Invno,@OracleCode,@Schcode);
                                        END
                                        ");

                            var result1 = sqlClient.Insert();
                            if (result1.IsError)
                            {
                                Log.Error("Failed to insert WipDetail:" + result1.Errors[0].DeveloperMessage);
                                MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            //_____________________________
                            sqlClient.ClearParameters();
                            sqlClient.CommandText(@"Update JPIXOrders Set OrderStatus='Press' where Invno=@Invno");
                            sqlClient.AddParameter("@Invno", this.Invno);
                            var updateOrderResult = sqlClient.Update();
                            if (updateOrderResult.IsError)
                            {
                                Log.Error(updateOrderResult.Errors[0].DeveloperMessage);
                                MessageBox.Show("Failed to update order status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            break;
                        }
                    default:
                        {

                            MbcMessageBox.Error("Department code not recognized for JPIX scan. Please contact support.");
                            { return false; }
                        }

                }
                //AddEventLog();
                return true;
            }
        }
        public bool ScanRemake()
        {
            MbcMessageBox.Information("Contact you supervisor for remake processing.");
            return true;
        }
        public void AddEventLog(string jobId, string status, string note, string notificationXML, bool notified)
        {
            //PUT this in a new event table seperate from mixbook event log

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
            //    return;
            //}



        }
        public bool ScanCheck(int invno, string login, string type)
        {
            return true; // Placeholder return value, implement logic as needed
        }
        public bool WipCheck(string vDeptCode)
        {
            return true; // Placeholder return value, implement logic as needed
        }
        public bool WipCheck(string vDeptCode, string type)
        {
            return true; // Placeholder return value, implement logic as needed
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
    }
}
