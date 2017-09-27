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
using Exceptionless;
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
           
        }
        private void SendPassword(string passWord,string toEmail)
        {
            SmtpClient smtp = new SmtpClient(Properties.Settings.Default.smtpServer);
               smtp.Credentials = new NetworkCredential(Properties.Settings.Default.mailUserName,
               Properties.Settings.Default.mailPassword);
              MailMessage message = new MailMessage();
              //message.Sender = new MailAddress(Properties.Settings.Default.fromMail,
              // "Memory Book System Administrator");
            message.From = new MailAddress(Properties.Settings.Default.fromMail,
               "Memory Book System Administrator");

            message.To.Add(new MailAddress(toEmail));


            message.Subject = "Your temporary password.";
            message.Body = "<h1>Your Temporary Password</h1>< p >Login in with your email address as user name and " + passWord + "as your password. Once you are logged in you will be required to change your password.</ p > ";

            message.IsBodyHtml = true;
            try {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
                this.Log.Error(ex,"Failed to send password email.");
              MessageBox.Show("Failed to send password  email.", "Password", MessageBoxButtons.OK);
            }
          
           }
   
    #endregion

        private void frmUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsUser.mbcUsers' table. You can move, or remove it, as needed.
            this.mbcUsersTableAdapter.Fill(this.dsUser.mbcUsers);
            // TODO: This line of code loads data into the 'dsRoles.roles' table. You can move, or remove it, as needed.
            this.rolesTableAdapter.Fill(this.dsRoles.roles);
        
         
           
          
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NewUser = false;
            setEdit(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblId.Text= Guid.NewGuid().ToString();

            var valCheck = ValidationCheck();
            if (!valCheck)
            { return; }

           
            this.Validate();
           
            try
            {
                
                if (NewUser)
                {
                    string viD = Guid.NewGuid().ToString();
                    string pwd =RandomPasswordGenerator.Generate();//tmp password
                 
                    //daUser.InsertCommand.Parameters.RemoveAt("@id");
                    //daUser.InsertCommand.Parameters.AddWithValue("@id", viD);
                    //daUser.InsertCommand.Parameters.RemoveAt("@PassWord");
                    //daUser.InsertCommand.Parameters.AddWithValue("@PassWord", pwd);
                    //daUser.InsertCommand.Parameters.RemoveAt("@ChangePasword");
                    //daUser.InsertCommand.Parameters.AddWithValue("@ChangePassword", true);
                    mbcUsersTableAdapter.Insert(viD,txtUserName.Text,pwd,cmbRole.SelectedValue.ToString(),txtEmail.Text,txtFirstName.Text,txtLastName.Text,true);
                    try {SendPassword(pwd, txtEmail.Text); }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to send password email:" + ex.Message);
                        this.Log.Error(ex, "Failed to send password email:" + ex.Message);
                        return;
                    }
                    
                    setEdit(false);
                    NewUser =false;
                }
                else {
                    this.bsUser.EndEdit();
                    mbcUsersTableAdapter.Update(dsUser); }
                setEdit(false);
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
