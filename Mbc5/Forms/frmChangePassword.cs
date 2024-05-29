using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Mbc5.Classes;
namespace Mbc5.Forms
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword(string userId,frmMain vfrmMain)
        {
            InitializeComponent();
            this.userId = userId;
            this.frmMain = vfrmMain;
        }
        private string userId { get; set; }
        private frmMain frmMain { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (txtpw1.Text.Trim() == txtpw2.Text.Trim())
            {
                if (string.IsNullOrEmpty(txtpw1.Text))
                {
                    errorProvider.SetError(txtpw1, "Password Required.");
                   return;
                }
                daPassWord.UpdateCommand.Parameters.Clear();
                daPassWord.UpdateCommand.Parameters.AddWithValue("@PassWord", txtpw1.Text);
                daPassWord.UpdateCommand.Parameters.AddWithValue("@ChangePassword", false);
                daPassWord.UpdateCommand.Parameters.AddWithValue("@Id", lblId.Text);
                this.Validate();
                bsChangePassword.EndEdit();
             
               daPassWord.Update(dsChangePassword);
                frmMain.ForcePasswordChange = false;
                MessageBox.Show("Password has been reset.","Password",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("The password does not match the confirmation password. Please try again.", "Password Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpw1.Text = "";
                txtpw2.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
             this.conn.ConnectionString = ApplicationConfig.DefaultConnectionString;
            daPassWord.SelectCommand.Parameters.Clear();
            daPassWord.SelectCommand.Parameters.AddWithValue("@id", userId);//this.userId
            daPassWord.Fill(dsChangePassword);
            string a = lblId.Text;

        }

        private void txtpw2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { btnSave_Click(sender, e); }
        }

       
    }
}
