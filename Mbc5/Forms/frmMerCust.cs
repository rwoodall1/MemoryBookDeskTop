using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using System.Data.Sql;
namespace Mbc5.Forms {
    public partial class frmMerCust : BaseClass.Forms.bTopBottom {
        public frmMerCust(UserPrincipal userPrincipal) : base(new string[] { "SA","Administrator","MerCS" },userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            }
        private UserPrincipal ApplicationUser { get; set; }
        }
    }
