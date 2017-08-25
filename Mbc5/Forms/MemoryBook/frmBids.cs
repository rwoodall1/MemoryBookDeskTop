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
    public partial class frmBids : BaseClass.frmBase {
        public frmBids(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS"}, userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            }
        public frmBids(UserPrincipal userPrincipal,string schcode) : base(new string[] { "SA","Administrator","MbcCS" },userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Schcode = schcode;

        }
        private UserPrincipal ApplicationUser { get; set; }

		private void bidsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			this.Validate();
			this.bidsBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.dsBids);

		}

        private void frmBids_Load(object sender, EventArgs e)
        {
            this.bidsTableAdapter.Fill(this.dsBids.bids, this.Schcode);
        }

        private void frmBids_Load_1(object sender, EventArgs e)
        {
            this.custTableAdapter.Fill(this.dsBids.cust,this.Schcode);
            this.bidsTableAdapter.Fill(this.dsBids.bids, this.Schcode);
        }

        private void txtOtherChrg2_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkMsStandard_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtOtherChrg_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
