using BaseClass;
using BaseClass.Classes;
using BaseClass.Core;
using BindingModels;
using Mbc5.Classes;
using RESTModule;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mbc5.Forms.Tukios
{
    public partial class frmTukiosBookChk : BaseClass.frmBase
    {
        public frmTukiosBookChk(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;

        }
        public TukiosChkData OrderInfo { get; set; }
        public List<TukiosInvno> InvnoInOrder { get; set; }
        public UserPrincipal ApplicationUser { get; set; }
        public string CurrentInvno { get; set; }

        private void frmTukiosBookChk_Load(object sender, System.EventArgs e)
        {
            this.txtClientOrderId.Select();
        }
        private void txtClientOrderId_Leave(object sender, EventArgs e)
        {
            var sqlClient = new SQLCustomClient().CommandText(@"Select Invno from TukiosOrder Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", this.txtClientOrderId.Text);
            var result = sqlClient.SelectMany<TukiosInvno>();
            if (result.IsError)
            {
                MbcMessageBox.Error("Error getting order information. Rescan Client Order ID");
                txtClientOrderId.Select();
                return;
            }
            InvnoInOrder = (List<TukiosInvno>)result.Data;
            this.txtClientOrderId.Enabled = false;
        }
        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtClientOrderId.Text))
            {
                MessageBox.Show("Please scan a Client Order ID");
                this.txtClientOrderId.Select();

            }
        }

        private void txtBarcode_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtClientOrderId.Text))
            {
                MessageBox.Show("Please scan a Client Order ID");
                this.txtClientOrderId.Select();
                return;

            }
            CurrentInvno = this.txtBarcode.Text.Replace("TUK", "").Replace("YB", "");

            var sqlClient = new SQLCustomClient().CommandText(@"Select ClientOrderId,BookType,TrackingNumber,ShipNotification,Invno from TukiosOrder Where Invno=@Invno");
            sqlClient.AddParameter("@Invno", CurrentInvno);
            var result = sqlClient.Select<TukiosChkData>();
            if (result.IsError)
            {
                MessageBox.Show("Failed to retrieve order");
                this.txtBarcode.Select();
                return;
            }
            if (result.Data != null)
            {
                this.OrderInfo = (TukiosChkData)result.Data;
                if (string.IsNullOrEmpty(OrderInfo.TrackingNumber))
                {
                    MessageBox.Show("Tracking number has not been entered, abort shipping");
                    return;
                }
                if (string.IsNullOrEmpty(OrderInfo.ShipNotification))
                {
                    MessageBox.Show("Notification data was not found, abort shipping");
                    return;
                }


            }
            else //data null
            {
                MessageBox.Show("No order found with that invoice number");

                this.txtBarcode.Select();
            }



        }
        private void txtUPSLabel_Leave(object sender, System.EventArgs e)
        {
            if (OrderInfo.TrackingNumber.Contains(txtUPSLabel.Text))
            {


                var recordToUpdate = InvnoInOrder.FirstOrDefault(x => x.Invno.ToString() == CurrentInvno);
                if (recordToUpdate != null)
                {

                    recordToUpdate.Checked = true;
                    txtBarcode.Clear();
                    txtUPSLabel.Clear();
                    //txtBarcode.Select();
                }
            }
            else
            {
                MessageBox.Show("Tracking number does not match order");
                this.txtUPSLabel.Select();
            }
        }
        public async Task<ApiProcessingResult> NotifyTukiosOfShipment()
        {
            var processingResult = new ApiProcessingResult();
            foreach (var item in InvnoInOrder)
            {
                if (!item.Checked)
                {
                    MessageBox.Show("Not all items in the order have been checked, please check all items before marking as shipped");
                    processingResult.IsError = true;

                    return processingResult;
                }
            }

            string vReturnNotification = OrderInfo.ShipNotification;
            try
            {

                string endpoint;
                if (OrderInfo.BookType.ToUpper() == "PHOTO")
                {

                    endpoint = ConfigurationManager.AppSettings["TukiosEPPhoto"].ToString();
                }
                else
                {
                    endpoint = ConfigurationManager.AppSettings["TukiosEPFuneral"].ToString();
                }
                string AccessKey = ConfigurationManager.AppSettings["TukiosApiKey"].ToString();
                string curDate = DateTime.UtcNow.ToString();
                string accessString = curDate + "|" + AccessKey;
                string headerValue = Encryptor.Encrypt(accessString, ConfigurationManager.AppSettings["TukiosPassPhrase"].ToString(), true);

                var headers = new List<RESTModule.Header>()
                {
                    new RESTModule.Header()
                    {
                       Key="Authorize",
                       Value=headerValue

                    },

                };

                var restServiceResult = await new RESTService(endpoint).MakeRESTCall("POST", vReturnNotification, headers, null, "application/json");
                var response = JsonSerializer.Deserialize<TukiosResponse>(restServiceResult.Data.APIResult.ToString());
                if (!restServiceResult.IsError)
                {
                    if (response.success == true)
                    {
                        //if not set to notified scheduled task will try again
                        AddMbEventLog(OrderInfo.ClientOrderId, "Shipped", "", vReturnNotification, true);
                    }
                    else
                    {
                        string msg = restServiceResult.Data.APIResult.ToString();
                        AddMbEventLog(OrderInfo.ClientOrderId, "Shippped ERROR 2", msg, vReturnNotification, false);
                        var emailHelper = new EmailHelper();
                        string emailmsg = msg;
                        emailHelper.SendEmail("Failed to notify Tukios of shipped order:" + OrderInfo.ClientOrderId, "randy.woodall@jostens.com", null, msg, EmailType.System);
                        MbcMessageBox.Hand("Failed to notify Tukios of shipment, please rescan the item. If you don't succede place the package to the side and notify a supervisor.", "Error");
                    }


                }
                else
                {
                    AddMbEventLog(OrderInfo.ClientOrderId, "Shipped Error", "", vReturnNotification, false);
                    var emailHelper = new EmailHelper();
                    emailHelper.SendEmail("Failed to notify Tukios of shipped order:" + OrderInfo.ClientOrderId, "randy.woodall@jostens.com", null, restServiceResult.Errors[0].ErrorMessage, EmailType.System);
                    MbcMessageBox.Hand("Failed to notify Tukios of shipment, please rescan the item. If you don't succede place the package to the side and notify a supervisor.", "Error");
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error notifying tukios of ClientOrderId " + OrderInfo.ClientOrderId + " shipment:" + ex.Message);
                MbcMessageBox.Error("Error notifying tukios of shipment:" + ex.Message);
                processingResult.IsError = true;

                return processingResult;

            }


            OrderInfo = null;
            InvnoInOrder = null;
            CurrentInvno = null;
            ResetScreen();
            return processingResult;
        }

        private void btnShipped_Click(object sender, EventArgs e)
        {
            foreach (var item in InvnoInOrder)
            {
                if (!item.Checked)
                {
                    MessageBox.Show("Not all items in the order have been checked, please check all items before marking as shipped");
                    return;
                }
            }
            this.NotifyTukiosOfShipment();

        }
        public string AddMbEventLog(string jobId, string status, string note, string notificationXML, bool notified)
        {
            var retval = "0";
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Insert Into TukiosEventLog (DateCreated,ModifiedDate,StatusChangedTo,Notified,Note,NotificationJSON) Values(@JobId,GetDate(),GETDATE(),@StatusChangedTo,@Notified,@Note,@NotificationXML)");
            sqlClient.AddParameter("@Jobid", jobId);
            sqlClient.AddParameter("@StatusChangedTo", status);
            sqlClient.AddParameter("@Notified", notified);
            sqlClient.AddParameter("@Note", note);
            sqlClient.AddParameter("@NotificationJSON", notificationXML);
            var sqlResult = sqlClient.Insert();
            if (sqlResult.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("AddMbEventLog failure:" + sqlResult.Errors[0].DeveloperMessage);

                var emailHelper = new EmailHelper();
                string vBody = "Failed to insert values JobId:" + jobId + " StatusChangedTo:" + status + " Notified:" + notified + " Note:" + note;
                emailHelper.SendEmail("Failed to notify item shipped", "randy.woodall@jostens.com", null, vBody, EmailType.System);
                return retval;
            }
            retval = sqlResult.Data;
            return retval;
        }
        private void ResetScreen()
        {
            this.txtBarcode.Text = "";
            this.txtClientOrderId.Text = "";
            this.txtClientOrderId.Enabled = true;
            this.txtUPSLabel.Text = "";
            this.OrderInfo = null;
            this.InvnoInOrder = null;
            this.CurrentInvno = null;
            this.txtClientOrderId.Select();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetScreen();
            OrderInfo = null;
            InvnoInOrder = null;
            CurrentInvno = null;
        }
    }
    public class TukiosChkData
    {
        public string ClientOrderId { get; set; }
        public string BookType { get; set; }
        public int Invno { get; set; }
        public string TrackingNumber { get; set; }
        public string ShipNotification { get; set; }
    }
    public class TukiosInvno
    {
        public int Invno { get; set; }
        public bool Checked { get; set; }
    }

}
