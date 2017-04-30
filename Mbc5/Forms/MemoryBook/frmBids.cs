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
           private UserPrincipal ApplicationUser { get; set; }

		private void lblSchoolName_Paint(object sender, PaintEventArgs e)
		{

		}

		private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
		{

		}

		private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
		{

		}

		private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
		{

		}

		private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
		{

		}

		private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
		{

		}

		private void bidsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			this.Validate();
			this.bidsBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.dsBids);

		}

		private void frmBids_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'dsBids.bids' table. You can move, or remove it, as needed.
			this.bidsTableAdapter.Fill(this.dsBids.bids);

		}
	}
    }
