using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BaseClass.Classes;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Mbc5.Forms.MemoryBook {
    public partial class frmSales : BaseClass.Base {
        public frmSales(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS"}, userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            }
           private UserPrincipal ApplicationUser { get; set; }
        

        }
    }
