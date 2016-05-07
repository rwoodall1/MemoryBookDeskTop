using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseClass.Classes;
using NLog;
using System.Data.SqlClient;
using System.Configuration;
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
            EmailHelper vEmail = new EmailHelper();
            string pwd = RandomPasswordGenerator.Generate();
            string msg = "Login with your user name and this password:" + pwd + ". Once you login you will have to change your password.";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
            SqlCommand cmd = new SqlCommand("Select Id,EmailAddress from mbcUsers  where EmailAddress=@EmailAddress", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);

            try
            {

                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    string vId = "";
                    while (rdr.Read())
                    { vId = rdr["id"].ToString(); }
                    cmd.Connection.Close();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "Update mbcUsers set Password=@Password,ChangePassword=@ChangePassword where Id=@Id";
                    cmd.Parameters.AddWithValue("@Password", pwd);
                    cmd.Parameters.AddWithValue("@Id", vId);
                    cmd.Parameters.AddWithValue("@ChangePassword", true);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    vEmail.SendEmail("Forgot Password", txtEmail.Text, "", msg, EmailType.System);

                    MessageBox.Show("Reset Email has been sent.", "Password", MessageBoxButtons.OK);
                    this.Hide();
                    login.Show();
                    this.Close();
                }
                else
                {
                    cmd.Connection.Close();
                    MessageBox.Show("The entered email address was not found. Enter a new email address or contact your supervisor.", "Password", MessageBoxButtons.OK);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending password email:" + ex.Message);
                Log.Error(ex, "Error sending forgot password email:" + ex.Message);
                Application.Exit();

            }
        }
    }
}
