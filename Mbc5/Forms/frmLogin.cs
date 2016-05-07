using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Principal;
using BaseClass.Classes;
using BaseClass;
namespace Mbc5.Forms
{
    public partial class frmLogin : Form
    {
        public int NumTry { get; set; } = 0;
        public frmMain frmMain { get; set; }
        public frmLogin()
        {

        }
        public frmLogin(frmMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)

        {
            this.pbLoading.Visible = true;
           

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
            string cPassword = this.txtpassword.Text;
            string cUser = this.txtusername.Text;




            SqlCommand cmd = new SqlCommand("SELECT dbo.roles.name as RoleName, dbo.roles.rank, dbo.mbcUsers.id, dbo.mbcUsers.UserName,dbo.mbcUsers.PassWord, dbo.mbcUsers.roldid, dbo.mbcUsers.EmailAddress, dbo.mbcUsers.FirstName, dbo.mbcUsers.LastName, dbo.mbcUsers.ChangePassword FROM dbo.mbcUsers INNER JOIN dbo.user_role ON dbo.mbcUsers.id = dbo.user_role.userid INNER JOIN dbo.roles ON dbo.user_role.roleid = dbo.roles.id WHERE(dbo.mbcUsers.PassWord = @password) AND(dbo.mbcUsers.UserName = @username)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@username", cUser);
            cmd.Parameters.AddWithValue("@password", cPassword);
            GenericIdentity vApplicationUser = new GenericIdentity(cUser);

            List<string> vroles = new List<string>();

            try
            {

                bool vChangePassword = false;
                string vPassword = null;
                string vId = null;
                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    vPassword = rdr["password"].ToString();
                    vId = rdr["id"].ToString();
                    vChangePassword = rdr.IsDBNull(rdr.GetOrdinal("changepassword")) ? false: (bool)rdr["changepassword"];
                    string vUsername = rdr["username"].ToString();
                    vroles.Add(rdr["RoleName"].ToString().Trim());

                }
                if (vPassword == cPassword)
                {
                    this.panel1.Visible = false;
                    this.pbLoading.Visible = false;
                    this.lblSuccess.Visible = true;
                    frmMain.Text = "Mbc5/User:" + cUser;
                    frmMain.WindowState = FormWindowState.Maximized;
                    frmMain.ForcePasswordChange = vChangePassword;
                    this.timer1.Enabled = true;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                    return;
                };

                var arrayrole = vroles.ToArray();
                UserPrincipal userPrincipal = new UserPrincipal(vApplicationUser, arrayrole);
                userPrincipal.id = vId;
                userPrincipal.UserName = cUser;
                userPrincipal.Roles = arrayrole.ToList();
                frmMain.ApplicationUser = userPrincipal;

            }
          
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                return;

            }
            finally { cmd.Connection.Close(); }

            this.DialogResult = DialogResult.OK;

        }

private void timer1_Tick(object sender, EventArgs e)
{

    this.Close();
    frmMain.Show();
}

private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
{
    if (e.KeyChar == 13)
    { btnLogin_Click(sender, e); }
}

private void btnCancel_Click(object sender, EventArgs e)
{
    this.DialogResult = DialogResult.Cancel;
    this.Close();
}

private void btnForgotPassword_Click(object sender, EventArgs e)
{
            
                frmFogotPassword form = new frmFogotPassword(this);
                this.Hide();
               
                form.ShowDialog();
               
          
            
}
    }
}
