using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mbc5.Dialogs;
using BaseClass.Classes;
using NLog;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
namespace Mbc5.Forms
{
    public partial class frmFogotPassword : Form
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();
        frmLogin login { get; set; }
        public frmFogotPassword(frmLogin frmLogin)
        {
            InitializeComponent();
            this.login = frmLogin;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSendPassword_Click(object sender, EventArgs e)
        {
            //var Environment = ConfigurationManager.AppSettings["Environment"].ToString();
            //string AppConnectionString = "";
            //if (Environment == "DEV")
            //{
            //    AppConnectionString = "Data Source = Sedswbpsql01; Initial Catalog = Mbc5_demo; Persist Security Info = True; Trusted_Connection = True; ";
            //    this.Text = "Environment:" + Environment + "    Mbc5";
            //}
            //else if (Environment == "PROD") { AppConnectionString = "Data Source=Sedswbpsql01;Initial Catalog=Mbc5; Persist Security Info =True;Trusted_Connection=True;"; }

            EmailHelper vEmail = new EmailHelper();
            string pwd = RandomPasswordGenerator.Generate();
            string msg = "Login with your user name and this password:" + pwd + ". Once you login you will have to change your password.";

            var sqlClient = new SQLCustomClient().CommandText("Select Id,EmailAddress from mbcUsers  where EmailAddress=@EmailAddress");
            sqlClient.AddParameter("@EmailAddress", txtUserName.Text);
            var userResult = sqlClient.Select<ForgotPasswordUser>();
            if(userResult.IsError )
            {
                MessageBox.Show("There was an error retrieving your account:" + userResult.Errors[0].ErrorMessage);
                Log.Error("There was an error retrieving your account:" + userResult.Errors[0].ErrorMessage);
                return;

            }
            var user =(ForgotPasswordUser) userResult.Data;
            if(user == null)
            {
                MessageBox.Show("The entered user name was not found. Enter a new user name or contact your supervisor.", "Password", MessageBoxButtons.OK);
                return;
            }

            sqlClient.ClearParameters();
            sqlClient.CommandText("Update mbcUsers set Password=@Password,ChangePassword=@ChangePassword where Id=@Id");
            sqlClient.AddParameter("@Password", pwd);
            sqlClient.AddParameter("@Id", user.Id);
            sqlClient.AddParameter("@ChangePassword", true);
            var updateResult = sqlClient.Update();
            if (updateResult.IsError)
            {
                Log.Error("Error updating password:" + updateResult.Errors[0].ErrorMessage);
                MessageBox.Show("Error updating password:" + updateResult.Errors[0].ErrorMessage);
                return;
            }

            if (vEmail.SendEmail("Forgot Password",user.EmailAddress, "", msg, EmailType.System))
            {
                MessageBox.Show("Reset Email has been sent.", "Password", MessageBoxButtons.OK);
                this.Hide();
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error sending password email" );
               
                Application.Exit();
            }
        }
    }
    public class ForgotPasswordUser { 
    
        public string Id { get; set; }
       public string EmailAddress { get; set; }
    }

}
