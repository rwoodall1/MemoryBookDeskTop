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
            return true; // Placeholder return value, implement logic as needed
        }
        public void ScanRemake()
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
