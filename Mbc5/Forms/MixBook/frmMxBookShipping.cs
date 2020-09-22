using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mbc5.Classes;
using BaseClass;
using System.Media;
using BaseClass.Classes;
using BindingModels;

namespace Mbc5.Forms.MixBook
{
    public partial class frmMxBookShipping : BaseClass.frmBase
    {
        public frmMxBookShipping(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        public UserPrincipal ApplicationUser { get; set; }




    }
}
