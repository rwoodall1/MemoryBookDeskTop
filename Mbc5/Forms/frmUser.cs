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

using System.Data.SqlClient;
using Mbc5.Classes;
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

        #endregion
        private void SetConnectionString()
        {
            frmMain frmMain = (frmMain)this.MdiParent;
            this.rolesTableAdapter.Connection.ConnectionString = ApplicationConfig.DefaultConnectionString;
            this.mbcUsersTableAdapter.Connection.ConnectionString = ApplicationConfig.DefaultConnectionString;
         
            
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            this.SetConnectionString();
            // TODO: This line of code loads data into the 'dsRoles.roles' table. You can move, or remove it, as needed.
            this.rolesTableAdapter.Fill(this.dsRoles.roles);


            // TODO: This line of code loads data into the 'dsUser.mbcUsers' table. You can move, or remove it, as needed.
            this.mbcUsersTableAdapter.Fill(this.dsUser.mbcUsers);
    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NewUser = false;
            setEdit(false);
            this.Cancel();
        }
        public override void Cancel()
        {
            bsUser.CancelEdit();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           

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
                  mbcUsersTableAdapter.Insert(viD,txtUserName.Text,pwd,cmbRole.SelectedValue.ToString(),txtEmail.Text,txtFirstName.Text,txtLastName.Text,true);
                   var _emailHelper = new EmailHelper();
                   

                    string body = "<h1> Your Temporary Password </h1><p> Login in with "+ txtUserName.Text +" as user name and " + pwd + " as your password.Once you are logged in you will be required to change your password.</p> ";
                    try {
                        if(_emailHelper.SendEmail("Your temporary password.", txtEmail.Text,"",body,EmailType.System))
                        {
                            MessageBox.Show("Password email sent.","Email",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to send password email:" + ex.Message);
                        Log.Error(ex, "Failed to send password email:" + ex.Message);
                        return;
                    }
                    
                    setEdit(false);
                    NewUser =false;
                    //reload
                    this.mbcUsersTableAdapter.Fill(this.dsUser.mbcUsers);
                }
                else {
                    this.bsUser.EndEdit();
                    var a=mbcUsersTableAdapter.Update(dsUser);
                   
                }
                setEdit(false);
                NewUser = false;

                //reload
                this.mbcUsersTableAdapter.Fill(this.dsUser.mbcUsers);
            }
            catch (DBConcurrencyException ex1)
            {
                string errmsg = "Concurrency violation" + Environment.NewLine + (string)ex1.Row.ItemArray[0];
                Log.Error(ex1, ex1.Message);
                MessageBox.Show(errmsg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Record faild to update:" + ex.Message);
               Log.Error(ex, "Record faild to update:" + ex.Message);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            var userId = ((DataRowView)bsUser.Current).Row["id"].ToString();

            frmChangePassword frmPassword = new frmChangePassword(userId,(frmMain)this.MdiParent);

            frmPassword.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var row =(DataRowView) bsUser.Current;
            row.Delete();
            mbcUsersTableAdapter.Update(dsUser);

        }
    }
}
