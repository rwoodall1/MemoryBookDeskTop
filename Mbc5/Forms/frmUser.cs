using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using BaseClass.Classes;
using NLog;
namespace Mbc5.Forms
{
    public partial class frmUser : BaseClass.Forms.bTopSide
    {
       
        public frmUser(UserPrincipal userPrincipal): base(new string[] { "SA", "Administrator"},userPrincipal )
        {
            InitializeComponent();
        }

    


        #region "Properties"
        private bool NewUser { get; set; }
        private bool editMode { get; set; } = false;
        #endregion

        #region "Functions"
        private bool ValidationCheck()
        {
            bool retval = true;
            errorProvider.Clear();
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider.SetError(txtUserName, "User Name Required.");
                retval = false;
            }
           
           if (string.IsNullOrEmpty(txtFirstName.Text)) {
                errorProvider.SetError(txtFirstName, "First Name Required.");
                retval = false;
            }
           
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, "Last Name Required.");
                retval = false;
            }
            
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Email Required.");
                retval = false;
            }

            //if (string.IsNullOrEmpty(cmbRole.SelectedValue.ToString()))
            //{
            //    errorProvider.SetError(cmbRole, "Role Required.");
            //    retval = false;
            //}
          
            return retval;           
        }
        private void setEdit(bool mode)
        {
           
            editMode = mode;
            txtUserName.Enabled = mode;
            txtFirstName.Enabled = mode;
            txtLastName.Enabled = mode;
            txtEmail.Enabled = mode;
            cmbRole.Enabled = mode;
        }
        private void FindUser(string lastName)
        {
            int result = bsUser.Find("LastName", lastName);
            if (result >= 0)
            {
                bsUser.Position = result;

            }
            else {
                MessageBox.Show("Record not found!", "Search", MessageBoxButtons.OK);
                 }
        }
        private void NewRec()
        {
            NewUser = true;
            DataRowView newrow = (DataRowView) bsUser.AddNew();
            //bsUser.Position = bsUser.Count;
        }
        private void SendPassword(string passWord)
        {
            SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["smtpServer"]);

            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["mailUserName"],
               ConfigurationManager.AppSettings["mailPassword"]);



            MailMessage message = new MailMessage();
            message.Sender = new MailAddress(ConfigurationManager.AppSettings["passwordResetFromMail"],
               "Memory Book System Administrator");
            message.From = new MailAddress(ConfigurationManager.AppSettings["passwordResetFromMail"],
               "Memory Book System Administrator");

            message.To.Add(new MailAddress("aperson1@example.com",
               "Recipient Number 1"));


            message.Subject = "Your temporary password.";
            message.Body = "<h1>Your Temporary Password</h1>< p >Login in with your email address as user name and " + passWord + "as your password. Once you are logged in you will be required to change your password.</ p > ";

            message.IsBodyHtml = true;
            try {smtp.Send(message); } catch (Exception ex)
            { this.Log.Error(ex,"Failed to send password reset email."); }
            MessageBox.Show("Failed to send password reset email.", "Password", MessageBoxButtons.OK);
           }
   
    #endregion

        private void frmUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsRoles.roles' table. You can move, or remove it, as needed.
            this.rolesTableAdapter.Fill(this.dsRoles.roles);

            rolesTableAdapter.Fill(dsRoles.roles);//table adapter calls clear first
            dsUser.Clear();
            daUser.Fill(dsUser);
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NewUser = false;
            setEdit(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            var valCheck = ValidationCheck();
            if (!valCheck)
            { return; }

            setEdit(false);
            this.Validate();
            this.bsUser.EndEdit();
            try
            {
                
                if (NewUser)
                {
                    string viD = Guid.NewGuid().ToString();
                    string pwd =RandomPasswordGenerator.Generate();//tmp password
                    daUser.InsertCommand.Parameters.RemoveAt("@id");
                    daUser.InsertCommand.Parameters.AddWithValue("@id", viD);
                    daUser.InsertCommand.Parameters.RemoveAt("@PassWord");
                    daUser.InsertCommand.Parameters.AddWithValue("@PassWord", pwd);
                    daUser.InsertCommand.Parameters.RemoveAt("@ChangePasword");
                    daUser.InsertCommand.Parameters.AddWithValue("@ChangePassword", true);
                    daUser.Update(dsUser);
                    SendPassword(pwd);
                    NewUser =false;
                }
                else { daUser.Update(dsUser); }
                NewUser = false;
            }
            catch (DBConcurrencyException ex1)
            {
                string errmsg = "Concurrency violation" + Environment.NewLine + (string)ex1.Row.ItemArray[0];
                this.Log.Error(ex1, ex1.Message);
                MessageBox.Show(errmsg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Record faild to update:" + ex.Message);
                this.Log.Error(ex, "Record faild to update:" + ex.Message);
            }
          
        }
      
        private void btnEdit_Click(object sender, EventArgs e)
        {
            NewUser = false;
            setEdit(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            setEdit(true);
         
            NewRec();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindUser(txtSearch.Text); 
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { FindUser(txtSearch.Text); }
        }
    }
}
