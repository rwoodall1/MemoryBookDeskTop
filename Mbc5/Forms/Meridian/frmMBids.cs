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

namespace Mbc5.Forms.Meridian {
    public partial class frmMBids : BaseClass.frmBase {
        public frmMBids(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS"}, userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            }
           private UserPrincipal ApplicationUser { get; set; }

     
        

        private void qtedateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            qtedateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void orderDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            orderDateDateTimePicker.Format = DateTimePickerFormat.Short;
        }
    }
    }
