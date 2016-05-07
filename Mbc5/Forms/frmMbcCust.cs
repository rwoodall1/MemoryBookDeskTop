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
    }
}
