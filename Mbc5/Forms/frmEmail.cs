using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using BaseClass.Classes;
namespace Mbc5.Forms
{
    public partial class frmEmail : BaseClass.Forms.bTopBottom
    {
        public frmEmail(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
        {
            InitializeComponent();
            ApplicationUser = userPrincipal;
        }
        public frmEmail(UserPrincipal userPrincipal,string ToAddress,string Subject,string Msg) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
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
    }
}
