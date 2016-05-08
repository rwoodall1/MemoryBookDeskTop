using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BaseClass.Classes;
namespace Mbc5.Forms
{
    public partial class frmMbcCust : BaseClass.Forms.bTopBottom
    {
        public frmMbcCust(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS"}, userPrincipal)
        {
            InitializeComponent();
        }

        private void frmMbcCust_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCust.cust' table. You can move, or remove it, as needed.
            this.custTableAdapter.Fill(this.dsCust.cust,"038752");

        }
    }
}
