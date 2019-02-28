using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mbc5.Forms.MemoryBook {
	public partial class frmReceivingCard : BaseClass.Forms.bTopBottom {
		public frmReceivingCard() {
			InitializeComponent();
		}

		private void rCardBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
			this.Validate();
			this.rCardBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.dsRcard);

		}

		private void frmReceivingCard_Load(object sender, EventArgs e) {
			// TODO: This line of code loads data into the 'dsRcard.RCard' table. You can move, or remove it, as needed.
			this.rCardTableAdapter.Fill(this.dsRcard.RCard);

		}

		private void kitReceivedDateDateTimePicker_ValueChanged(object sender, EventArgs e) {
			kitReceivedDateDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		

		private void guardteDateTimePicker_ValueChanged(object sender, EventArgs e) {
			guardteDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void deadlineDateTimePicker_ValueChanged(object sender, EventArgs e) {
			deadlineDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void estdateDateTimePicker_ValueChanged(object sender, EventArgs e) {
			estdateDateTimePicker.Format = DateTimePickerFormat.Short;
		}
	}
}
