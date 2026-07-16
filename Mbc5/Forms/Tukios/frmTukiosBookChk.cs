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
            if (string.IsNullOrEmpty(txtClientOrderId.Text))
            {
                txtempty.Select();
                return;
            }
            var sqlClient = new SQLCustomClient().CommandText(@"Select Invno from TukiosOrder Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", this.txtClientOrderId.Text);
            sqlClient.AddParameter("@TukiosOrderStatus", "In Process");
            var result = sqlClient.SelectMany<TukiosInvno>();
            if (result.IsError)
            {
                MbcMessageBox.Error("Error getting order information. Rescan Client Order ID");
                txtClientOrderId.Select();
                return;
            }
            InvnoInOrder = (List<TukiosInvno>)result.Data;
            if (InvnoInOrder == null || InvnoInOrder.Count == 0)
            {
                MbcMessageBox.Error("No order found with this Client Order ID");
                txtClientOrderId.Select();
                return;
            }


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



        }
        private void txtUPSLabel_Leave(object sender, System.EventArgs e)
        {

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
                        MessageBox.Show("Tukios notification success.");
                        MarkOrderShipped();
                        AddTukiosEventLog(OrderInfo.ClientOrderId, "Shipped", "", vReturnNotification, true);
                    }
                    else
                    {
                        string msg = restServiceResult.Data.APIResult.ToString();
                        AddTukiosEventLog(OrderInfo.ClientOrderId, "Shippped ERROR 2", msg, vReturnNotification, false);
                        var emailHelper = new EmailHelper();
                        string emailmsg = msg;
                        emailHelper.SendEmail("Failed to notify Tukios of shipped order:" + OrderInfo.ClientOrderId, "randy.woodall@jostens.com", null, msg, EmailType.System);
                        MbcMessageBox.Hand("Failed to notify Tukios of shipment, please rescan the item. If you don't succede place the package to the side and notify a supervisor.", "Error");
                    }


                }
                else
                {
                    AddTukiosEventLog(OrderInfo.ClientOrderId, "Shipped Error", "", vReturnNotification, false);
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
            txtClientOrderId.Select();
            return processingResult;
        }

        private void btnShipped_Click(object sender, EventArgs e)
        {
            if (InvnoInOrder == null || InvnoInOrder.Count == 0)
            {
                MessageBox.Show("There are no orders scanned to ship");
                txtClientOrderId.Select();
                return;
            }
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
        public string AddTukiosEventLog(string jobId, string status, string note, string notificationJson, bool notified)
        {
            var retval = "0";
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Insert Into TukiosEventLog (DateCreated,ModifiedDate,ClientOrderId,StatusChangedTo,Notified,Note,NotificationJSON) Values(GetDate(),GETDATE(),@JobId,@StatusChangedTo,@Notified,@Note,@NotificationJSON)");
            sqlClient.AddParameter("@Jobid", jobId);
            sqlClient.AddParameter("@StatusChangedTo", status);
            sqlClient.AddParameter("@Notified", notified);
            sqlClient.AddParameter("@Note", note);
            sqlClient.AddParameter("@NotificationJSON", notificationJson);
            var sqlResult = sqlClient.Insert();
            if (sqlResult.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("AddTukiosEventLog failure:" + sqlResult.Errors[0].DeveloperMessage);

                //var emailHelper = new EmailHelper();
                //string vBody = "Failed to insert values JobId:" + jobId + " StatusChangedTo:" + status + " Notified:" + notified + " Note:" + note;
                //emailHelper.SendEmail("Failed to insert event log", "randy.woodall@jostens.com", null, vBody, EmailType.System);
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

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetScreen();
            OrderInfo = null;
            InvnoInOrder = null;
            CurrentInvno = null;
        }

        private void txtUPSLabel_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                MessageBox.Show("Please scan book barcode");
                txtempty.Select();


            }
        }

        private void txtempty_Enter(object sender, EventArgs e)
        {
            var a = 1;
        }

        private void btnClear_MouseDown(object sender, MouseEventArgs e)
        {
            this.Clear();
        }
        public void Clear()
        {
            ResetOrderShipping();
            ResetScreen();
            OrderInfo = null;
            InvnoInOrder = null;
            CurrentInvno = null;
            lstInvno.Items.Clear();

        }

        private void txtUPSLabel_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string scannedLabel = txtUPSLabel.Text.Trim();
            if (string.IsNullOrEmpty(scannedLabel) || scannedLabel.Length < 18)
            {
                if (scannedLabel.Length < 18)
                {
                    var dialogResult = MessageBox.Show("Invalid Tracking Number, Do you wish to clear the screen?", "Error", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Clear();
                        txtClientOrderId.Select();
                        return;
                    }
                    else
                    {
                        txtUPSLabel.Select();
                        return;
                    }

                }




            }

            if (!string.IsNullOrWhiteSpace(scannedLabel) && OrderInfo.TrackingNumber.Contains(scannedLabel))
            {


                var recordToUpdate = InvnoInOrder.FirstOrDefault(x => x.Invno.ToString() == CurrentInvno);
                if (recordToUpdate != null)
                {

                    recordToUpdate.Checked = true;
                    txtBarcode.Clear();
                    txtUPSLabel.Clear();

                }
            }
            else
            {
                MessageBox.Show("Tracking number does not match recorded Tracking number for this order");
                txtUPSLabel.Select();
            }
        }

        private void txtBarcode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtClientOrderId.Text))
            {
                MessageBox.Show("Please scan a Client Order ID");
                txtClientOrderId.Select();
                return;


            }
            if (!string.IsNullOrEmpty(this.txtBarcode.Text))
            {




                CurrentInvno = this.txtBarcode.Text.Replace("TUK", "").Replace("YB", "").Replace("SC", "");
                var record = InvnoInOrder.FirstOrDefault(x => x.Invno.ToString() == CurrentInvno);
                if (record != null && record.Checked == true)
                {

                    MessageBox.Show("This book has already been checked and scanned once");
                    txtBarcode.Select();
                    return;

                }

                var sqlClient = new SQLCustomClient().CommandText(@"Select ClientOrderId,BookType,TrackingNumber,ShipNotification,Invno from TukiosOrder Where Invno=@Invno");
                sqlClient.AddParameter("@Invno", CurrentInvno);
                sqlClient.AddParameter("@ClientOrderId", txtClientOrderId.Text.Trim());
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
                    if (OrderInfo.ClientOrderId != txtClientOrderId.Text.Trim())
                    {
                        MessageBox.Show("STOP Book and Production Ticket do not Match. Abort Shipping");
                        Clear();
                        return;
                    }

                    if (string.IsNullOrEmpty(OrderInfo.TrackingNumber))
                    {
                        MessageBox.Show("Tracking number has not been entered for this book, abort shipping and scan book into MBC");
                        Clear();
                        return;
                    }
                    if (string.IsNullOrEmpty(OrderInfo.ShipNotification))
                    {
                        MessageBox.Show("Notification data was not found for this book, abort shipping");
                        Clear();
                        return;
                    }
                    lstInvno.Items.Add(CurrentInvno);

                }
                else //data null
                {
                    var dresult = MessageBox.Show("No order found with that invoice number,would you like to clear the scan?", "Error", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        this.Clear();
                        this.txtClientOrderId.Select();
                    }
                    else
                    {
                        this.txtBarcode.Select();
                    }

                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtBarcode.Text) && string.IsNullOrEmpty(txtUPSLabel.Text))
                {
                    btnShipped.Select();
                }
                else
                {
                    txtBarcode.Select();
                }
            }


        }
        public void MarkOrderShipped()
        {
            var sqlClient = new SQLCustomClient().CommandText(@"Update TukiosOrder Set TukiosOrderStatus=@BookStatus,DateShipped=GetDate(),BookStatus=@BookStatus Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", this.OrderInfo.ClientOrderId);
            sqlClient.AddParameter("@BookStatus", "Shipped");
            var result = sqlClient.Update();
            if (result.IsError)
            {
                MessageBox.Show("Failed to mark order in Database as shipped");
            }
            sqlClient.ClearParameters();
            sqlClient.CommandText(@"Update produtn Set shpdate=GETDATE() Where Invno=@Invno");
            foreach (var item in InvnoInOrder)
            {
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@Invno", item.Invno);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    MessageBox.Show("Failed to update production table for Invno:" + item.Invno.ToString());
                }
            }





        }
        public void ResetOrderShipping()
        {
            if (InvnoInOrder == null || InvnoInOrder.Count == 0)
            {
                return;
            }
            var sqlClient = new SQLCustomClient().CommandText(@"Update TukiosOrder Set TrackingNumber='',BookStatus=@BookStatus,TukiosOrderStatus=@TukiosOrderStatus Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", txtClientOrderId.Text.Trim());
            sqlClient.AddParameter("@BookStatus", "Quality");
            sqlClient.AddParameter("@TukiosOrderStatus", "In Process");
            var updateResult = sqlClient.Update();
            if (updateResult.IsError)
            {
                MessageBox.Show("Failed to reset Shipping");
            }
            sqlClient.ClearParameters();
            sqlClient.CommandText(@"Update produtn Set shpdate=NULL Where Invno=@Invno");
            foreach (var item in InvnoInOrder)
            {
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@Invno", item.Invno);
                var updateResult1 = sqlClient.Update();
                if (updateResult1.IsError)
                {
                    MessageBox.Show("Failed to update production table for Invno:" + item.Invno.ToString());
                    return;
                }
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Delete from  WipDetail where Invno=@Invno and DescripId=@DescripId");
                sqlClient.AddParameter("@Invno", item.Invno);
                sqlClient.AddParameter("@DescripId", 40);
                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MessageBox.Show("Failed to delete WipDetail for Invno:" + item.Invno.ToString());
                    return;
                }
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
}
