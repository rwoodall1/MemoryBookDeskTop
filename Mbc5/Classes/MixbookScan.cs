using BaseClass.Classes;
using BindingModels;
namespace Mbc5.Classes
{
    public class MixBookScan : IScan
    {
        public MixBookScan(UserPrincipal userPrincipal)
        {
            // Constructor logic if needed
            ApplicationUser = userPrincipal;
        }
        public UserPrincipal ApplicationUser { get; set; }
        public bool Scan(ScanData data)
        {
            //string cmdText = @"
            //                                SELECT M.ShipName,M.ProdInOrder,(Select Max(ProdInOrder) from MixbookOrder where ClientOrderId=M.ClientOrderId)AS NumProducts,M.ClientOrderId,M.PrintergyFile,M.ItemId,M.JobId,M.Invno,M.Backing,M.ShipMethod,M.CoverPreviewUrl,M.BookPreviewUrl,M.Copies As Quantity,P.ProdNo,
            //                                M.MixbookOrderStatus,C.Specovr,WD.MxbLocation AS BookLocation
            //                                From MixBookOrder M Left Join Produtn P ON M.Invno=P.Invno
            //                                Left Join Covers C ON M.Invno=C.Invno
            //                                Left Join WipDetail WD On M.Invno=WD.Invno AND WD.DescripId IN (Select TOP 1 DescripId From wipdetail where  COALESCE(mxbLocation,'')!='' AND Invno=M.Invno  Order by DescripId desc )Where M.Invno=@Invno";
            //sqlQuery.CommandText(cmdText);
            //sqlQuery.AddParameter("@Invno", Invno);
            //var result = sqlQuery.Select<MixBookBarScanModel>();
            //if (result.IsError)
            //{
            //    MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retieve order for scan:" + result.Errors[0].DeveloperMessage);
            //    return;
            //}
            //if (result.Data == null)
            //{
            //    MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    return;
            //}
            //MbxModel = (MixBookBarScanModel)result.Data;
            //if (MbxModel.MixbookOrderStatus != null && MbxModel.MixbookOrderStatus.Trim().ToUpper() == "CANCELLED" || MbxModel.MixbookOrderStatus != null && MbxModel.MixbookOrderStatus.Trim().ToUpper() == "SHIPPED")
            //{
            //    if (this.ApplicationUser.UserName.ToUpper() != "TRIMMING")
            //    {
            //        MbcMessageBox.Information("This order has been " + MbxModel.MixbookOrderStatus.ToUpper());
            //        ClearScan();
            //        return;
            //    }
            //}
            //lblBkLocation.Text = MbxModel.BookLocation;
            //txtDateTime.Text = DateTime.Now.ToString();
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
    }
}
