using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mbc5.Forms
{
	public partial class EndSheet : BaseClass.frmBase
	{
		public EndSheet()
		{
			InitializeComponent();
		}

		private void btnInvoiceSrch_Click(object sender, EventArgs e)
		{

		}

		private void btnProdSrch_Click(object sender, EventArgs e)
		{

		}

		private void comdateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void cstsvcdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void btnEmailPw_Click(object sender, EventArgs e)
		{

		}

		private void btnUpdateJob_Click(object sender, EventArgs e)
		{

		}

		private void btnCalCS_Click(object sender, EventArgs e)
		{

		}

		private void kitrecvdDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void toprodDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void tovendDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void warndateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void prshpdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void prmsdateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void shpdateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void cprecvDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void ptbrcvdDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void ptrecvdDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void txtPerfbind_Leave(object sender, EventArgs e)
		{

		}

		private void screcvDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void btnDeadLineInfo_Click(object sender, EventArgs e)
		{

		}

		private void adduploaddateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void dedayoutDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void dedayinDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

		}

		private void btnCalcDeadLine_Click(object sender, EventArgs e)
		{

		}

		private void btnBinderyEmail_Click(object sender, EventArgs e)
		{

		}

		private void custBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			this.Validate();
			this.custBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.dsEndSheet);

		}

		private void EndSheet_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'dsEndSheet.endsheet' table. You can move, or remove it, as needed.
			this.endsheetTableAdapter.Fill(this.dsEndSheet.endsheet);
			// TODO: This line of code loads data into the 'dsEndSheet.quotes' table. You can move, or remove it, as needed.
			this.quotesTableAdapter.Fill(this.dsEndSheet.quotes);
			// TODO: This line of code loads data into the 'dsEndSheet.produtn' table. You can move, or remove it, as needed.
			this.produtnTableAdapter.Fill(this.dsEndSheet.produtn);
			// TODO: This line of code loads data into the 'dsEndSheet.cust' table. You can move, or remove it, as needed.
			this.custTableAdapter.Fill(this.dsEndSheet.cust);

		}

		private void EndSheets_Click(object sender, EventArgs e)
		{

		}
	}
}
