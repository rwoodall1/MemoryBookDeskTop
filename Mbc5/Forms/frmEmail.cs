using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using BaseClass.Classes;
using System.Net.Mime;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Mbc5.Dialogs;
namespace Mbc5.Forms
{
    public partial class frmEmail : BaseClass.Forms.bTopBottom
    {
        public frmEmail(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
        {
            InitializeComponent();
            ApplicationUser = userPrincipal;
        }
        public frmEmail(UserPrincipal userPrincipal, string ToAddress, string Subject, string Msg) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
        {
            InitializeComponent();
            ApplicationUser = userPrincipal;
            txtTo.Text = ToAddress;
            txtSubject.Text = Subject;
            txtMsg.Text = Msg;
        }
        private UserPrincipal ApplicationUser { get; set; }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            txtFrom.Text = this.ApplicationUser.Email;


        }
        private void SendEmail()
        {
            var smtpClient = new SmtpClient();
          
            var mailMessage = new MailMessage
            {
                Subject = txtSubject.Text,
                Body = txtMsg.Text,
                IsBodyHtml = true
            };
       
            if (!string.IsNullOrEmpty(txtCc.Text))
            {
                mailMessage.CC.Add(new MailAddress(txtCc.Text));
            }
            if (!string.IsNullOrEmpty(txtBcc.Text))
            {
                mailMessage.CC.Add(new MailAddress(txtBcc.Text));
            }
            if (!string.IsNullOrEmpty(txtAttachment.Text))
            {
                try
                {
                    Attachment attachment = new Attachment(txtAttachment.Text);
                    mailMessage.Attachments.Add(attachment);
                }
                catch (Exception ex)
                {
                    Log.Error("Failed to attach file to email:" + ex.Message);
                    MessageBox.Show("Failed to attach file to email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            mailMessage.From = new MailAddress(txtFrom.Text.Trim());
            mailMessage.To.Add(txtTo.Text.Trim());
            try
            {
                smtpClient.Send(mailMessage);
                LogEmail();
                this.Close();

            }
            catch (Exception ex)
            {
                Log.Error("Failed to send email:" + ex.Message);
                MessageBox.Show("Failed to send email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LogEmail()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
            string sql = "INSERT INTO EmailLogs (Id,ToEmail,FromId,FromEmail,Subject,Msg) VALUES(@Id,@ToEmail,@FromId,@FromEmail,@Subject,@Msg);";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", Guid.NewGuid().ToString());
            cmd.Parameters.AddWithValue("@ToEmail", txtTo.Text);
            cmd.Parameters.AddWithValue("@FromEmail", txtFrom.Text);
            cmd.Parameters.AddWithValue("@FromId", this.ApplicationUser.id);
            cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
            cmd.Parameters.AddWithValue("@Msg", txtMsg.Text);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Log.Error("Failed to log email:" + ex.Message);
                //go on we are not stopping the program for this
            }
            finally { cmd.Connection.Close(); }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void txtAttachment_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txtAttachment.Text = openFileDialog1.FileName;
            }
        }

        private void btnAddressTo_Click(object sender, EventArgs e)
        {
            frmAddressList AddrList = new frmAddressList();
           var result=AddrList.ShowDialog();
            if (result == DialogResult.OK)
            {
                string vEmail = AddrList.RetEmail; //values preserved after close
                if (string.IsNullOrEmpty(txtTo.Text))
                {
                    txtTo.Text = vEmail;
                }
                else
                {
                   txtTo.Text = txtTo.Text+";"+ vEmail;
                }
                
            }
        }

        private void btnAddressCc_Click(object sender, EventArgs e)
        {
            frmAddressList AddrList = new frmAddressList();
            var result = AddrList.ShowDialog();
            if (result == DialogResult.OK)
            {
                string vEmail = AddrList.RetEmail; //values preserved after close
                if (string.IsNullOrEmpty(txtCc.Text))
                {
                    txtCc.Text = vEmail;
                }
                else
                {
                    txtCc.Text = txtCc.Text + ";" + vEmail;
                }

            }
        }

        private void btnAddressBcc_Click(object sender, EventArgs e)
        {
            frmAddressList AddrList = new frmAddressList();
            var result = AddrList.ShowDialog();
            if (result == DialogResult.OK)
            {
                string vEmail = AddrList.RetEmail; //values preserved after close
                if (string.IsNullOrEmpty(txtBcc.Text))
                {
                    txtBcc.Text = vEmail;
                }
                else
                {
                    txtBcc.Text = txtBcc.Text + ";" + vEmail;
                }

            }
        }
    }
}
