using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using BaseClass.Classes;
using System.Data.Sql;
using Mbc5.Dialogs;
using System.Data.SqlClient;
using Mbc5.Classes;
using Mbc5.LookUpForms;
using BindingModels;
using Exceptionless;
using Exceptionless.Models;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace Mbc5.Forms
{
	public partial class frmEndSheet : BaseClass.frmBase,INotifyPropertyChanged
	{
		private static string _ConnectionString = ConfigurationManager.ConnectionStrings["Mbc"].ConnectionString;

		public event PropertyChangedEventHandler PropertyChanged;

		public frmEndSheet(UserPrincipal userPrincipal, int invno, string schcode) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
		{
			InitializeComponent();
			//this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			// this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ApplicationUser = userPrincipal;
			this.Invno = invno;
			this.Schcode = schcode;
		}
		public frmEndSheet(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
		{
			InitializeComponent();
			// this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			// this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ApplicationUser = userPrincipal;
			this.Invno = 0;
			this.Schcode = null;
			DisableControls(this.tbEndSheets.TabPages[0]);
			foreach (TabPage tab in tbEndSheets.TabPages)
			{
				DisableControls(tab);
			}
			EnableControls(this.txtInvoiceNoSrch);
			EnableControls(this.btnInvoiceSrch);
			EnableControls(this.txtsheetSrch);
			EnableControls(this.btnsheetSrch);
		}
		#region Properties
		public void InvokePropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, e);
		}
		private UserPrincipal ApplicationUser { get; set; }
		#endregion
		private void frmEndSheet_Load(object sender, EventArgs e)
		{
			Fill();
		}


		#region Methods

		public override bool Save()
		{
			bool retval = true;
			switch (tbEndSheets.SelectedIndex)
			{
				case 0:
					SaveEndSheet();

					break;
				case 1:
					{
						SaveSupplement();
						break;
					}
				case 2:
					{
						SavePreFlight();
						break;
					}			
			}
			return retval;
		}
		public bool SaveSupplement()
		{
			bool retval = true;
			if (dsEndSheet.suppl.Count > 0)
			{
				if (this.ValidateChildren(ValidationConstraints.Enabled))
				{
					try
					{
						this.supplBindingSource.EndEdit();
						var a = endsheetTableAdapter.Update(dsEndSheet.endsheet);
						//must refill so we get updated time stamp so concurrency is not thrown
						supplTableAdapter.Fill(dsEndSheet.suppl, Schcode);
						retval = true;
					}
					catch (Exception ex)
					{
						retval = false;
						MessageBox.Show("Supplement record failed to update:" + ex.Message);
						ex.ToExceptionless()
					   .SetMessage("Supplement record failed to update:" + ex.Message)
					   .Submit();
					}
				}
			}
			return retval;
		}
		public bool SaveEndSheet()
		{
			bool retval = true;
			if (dsEndSheet.endsheet.Count > 0)
			{
				if (this.ValidateChildren(ValidationConstraints.Enabled))
				{
					try
					{
						this.endsheetBindingSource.EndEdit();
						var a = endsheetTableAdapter.Update(dsEndSheet.endsheet);
						//must refill so we get updated time stamp so concurrency is not thrown
						endsheetTableAdapter.Fill(dsEndSheet.endsheet, Schcode);
						retval = true;
					}					
					catch (Exception ex)
					{
						retval = false;
						MessageBox.Show("Production record failed to update:" + ex.Message);
						ex.ToExceptionless()
					   .SetMessage("Production record failed to update:" + ex.Message)
					   .Submit();
					}
				}				
			}
			return retval;
		}
		public bool SavePreFlight()
		{
			bool retval = true;
			if (dsEndSheet.preflit.Count > 0)
			{
				if (this.ValidateChildren(ValidationConstraints.Enabled))
				{
					try
					{
						this.preflitBindingSource.EndEdit();
						var a = preflitTableAdapter.Update(dsEndSheet.preflit);
						//must refill so we get updated time stamp so concurrency is not thrown
						preflitTableAdapter.Fill(dsEndSheet.preflit, Schcode);
						retval = true;
					}
					catch (Exception ex)
					{
						retval = false;
						MessageBox.Show("PreFlight record failed to update:" + ex.Message);
						ex.ToExceptionless()
					   .SetMessage("PreFlight record failed to update:" + ex.Message)
					   .Submit();
					}
				}
			}
			return retval;
		}
		public override bool Add()
		{
			var sqlQuery = new SQLQuery();
			SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@Invno",this.Invno),
					 new SqlParameter("@Schcode",this.Schcode),
					};
			var strQuery = "";
			var pos = endsheetBindingSource.Find("invno", this.Invno);
			if (pos == -1)
			{		
				 strQuery = "INSERT INTO [dbo].[endsheet](Invno,Schcode)  VALUES (@Invno,@Schcode)";
				var endsheetResult = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters);
				if (endsheetResult != 1)
				{
					ExceptionlessClient.Default.CreateLog("Failed to insert endsheet record.")
						.AddTags("MemoryBook DestTop")
						.AddObject("Invoice#:" + Invno)
						.AddObject("Schcode:" + Schcode)
						.Submit();
					MessageBox.Show("Failed to insert endsheet record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
			}
		
		
			
			parameters = null;
			var pos2 = supplBindingSource.Find("invno", this.Invno);
			if (pos2 == -1)
			{
				 parameters = new SqlParameter[] {
					new SqlParameter("@Invno",this.Invno),
					 new SqlParameter("@Schcode",this.Schcode),

					};
				strQuery = "INSERT INTO [dbo].[suppl](Invno,Schcode)  VALUES (@Invno,@Schcode)";
			var supplResult = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters);
			if (supplResult != 1)
			{
				ExceptionlessClient.Default.CreateLog("Failed to insert endsheet record.")
					.AddTags("MemoryBook DestTop")
					.AddObject("Invoice#:" + Invno)
					.AddObject("Schcode:" + Schcode)
					.Submit();
				MessageBox.Show("Failed to insert supplement record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
			}
			parameters = null;
			var pos1 = preflitBindingSource.Find("invno", this.Invno);
			if (pos1 == -1)
			{                
		strQuery = "INSERT INTO [dbo].[preflit](Invno,Schcode)  VALUES (@Invno,@Schcode)";
				parameters = new SqlParameter[] {
					new SqlParameter("@Invno",this.Invno),
					 new SqlParameter("@Schcode",this.Schcode),

					};
				var priResult = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters);
				if (priResult != 1)
					{
						ExceptionlessClient.Default.CreateLog("Failed to insert endsheet record.")
							.AddTags("MemoryBook DestTop")
							.AddObject("Invoice#:" + Invno)
							.AddObject("Schcode:" + Schcode)
							.Submit();
						MessageBox.Show("Failed to insert priflit record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
			}
			return true;
		}
		private void Fill()
		{
			if (Schcode != null)
			{
				custTableAdapter.Fill(dsEndSheet.cust, Schcode);
				if(dsEndSheet.cust.Count < 1){
					//disable all tabs
					DisableControls(this.tbEndSheets.TabPages[0]);
					DisableControls(this.tbEndSheets.TabPages[1]);
					DisableControls(this.tbEndSheets.TabPages[2]);
					foreach (TabPage tab in tbEndSheets.TabPages)
					{
						DisableControls(tab);
					}
					EnableControls(this.txtInvoiceNoSrch);

					EnableControls(this.btnInvoiceSrch);
				}
				quotesTableAdapter.Fill(dsEndSheet.quotes, Schcode);
				if (dsEndSheet.quotes.Count < 1)
				{
					//disable all tabs
					DisableControls(this.tbEndSheets.TabPages[0]);
					DisableControls(this.tbEndSheets.TabPages[1]);
					DisableControls(this.tbEndSheets.TabPages[2]);
					foreach (TabPage tab in tbEndSheets.TabPages)
					{
						DisableControls(tab);
					}
					EnableControls(this.txtInvoiceNoSrch);

					EnableControls(this.btnInvoiceSrch);
				}
				produtnTableAdapter.Fill(dsEndSheet.produtn, Schcode);
				if (dsEndSheet.produtn.Count < 1)
				{
					//disable all tabs
					DisableControls(this.tbEndSheets.TabPages[0]);
					DisableControls(this.tbEndSheets.TabPages[1]);
					DisableControls(this.tbEndSheets.TabPages[2]);
					foreach (TabPage tab in tbEndSheets.TabPages)
					{
						DisableControls(tab);
					}
					EnableControls(this.txtInvoiceNoSrch);
					
					EnableControls(this.btnInvoiceSrch);
				}
				else { EnableAllControls(this); }

				endsheetTableAdapter.Fill(dsEndSheet.endsheet, Schcode);				
				if (dsEndSheet.endsheet.Count < 1)
				{
					DisableControls(this.tbEndSheets.TabPages[0]);
					
				}
				else { EnableAllControls(this.tbEndSheets.TabPages[0]); }

				supplTableAdapter.Fill(dsEndSheet.suppl , Schcode);
				if (dsEndSheet.suppl.Count < 1)
				{
					DisableControls(this.tbEndSheets.TabPages[1]);
				}
				else { EnableAllControls(this.tbEndSheets.TabPages[1]); }

				preflitTableAdapter.Fill(dsEndSheet.preflit, Schcode);
				if (dsEndSheet.preflit.Count < 1)
				{
					DisableControls(this.tbEndSheets.TabPages[2]);
				}
				else { EnableAllControls(this.tbEndSheets.TabPages[2]); }

			}





			if (Invno != 0)
			{
				var pos = endsheetBindingSource.Find("invno", this.Invno);
				if (pos > -1)
				{
					endsheetBindingSource.Position = pos;
				}
				else
				{
					DialogResult result=MessageBox.Show("End Sheet record was not found. For this invoice number ("+Invno+"), do you want to add one?", "Invoice#", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop);
					if (result == DialogResult.Yes)
					{
						if (Add())
						{
							Fill();
						}
					}
				}



			}


		}
		private void DisableControls(Control con)
		{
			foreach (Control c in con.Controls)
			{
				DisableControls(c);
			}
			con.Enabled = false;
		}
		private void EnableControls(Control con)
		{
			if (con != null)
			{
				con.Enabled = true;
				EnableControls(con.Parent);
			}
		}
		private void EnableAllControls(Control con)
		{
			foreach (Control c in con.Controls)
			{
				EnableAllControls(c);
			}
			con.Enabled = true;
		}


		#endregion

		private void btnInvoiceSrch_Click(object sender, EventArgs e)
		{
			switch (tbEndSheets.SelectedIndex)
			{
				case 0:
					if (!SaveEndSheet())
					{
						var result1 = MessageBox.Show("End sheet record could not be saved. Continue search?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result1 == DialogResult.No)
						{

							return;
						}
					}
					break;


			}

			var sqlQuery = new SQLQuery();
			string query = "Select invno,schcode from endsheet where invno=@invno";
			var parameters = new SqlParameter[] { new SqlParameter("@invno", txtInvoiceNoSrch.Text) };
			var result = sqlQuery.ExecuteReaderAsync(CommandType.Text, query, parameters);
			if (result.Rows.Count > 0)
			{
				Schcode = result.Rows[0]["schcode"].ToString();
				Invno = int.Parse(result.Rows[0]["invno"].ToString());// will always have a invno
				Fill();
			}
			else { MessageBox.Show("Record was not found.", "Invoice Number Search", MessageBoxButtons.OK, MessageBoxIcon.Information); }

		}

		private void frmEndSheet_Paint(object sender, PaintEventArgs e)
		{
			try { this.Text = "End Sheet/Supplements/Preflight-" + txtSchname.Text.Trim() + " (" + this.Schcode.Trim() + ")"; }
			catch
			{

			}
		}
		#region DateFormat
		private void predateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			predateDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void recvdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			recvdteDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void duedateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			duedateDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void iinDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			iinDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void ioutDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			ioutDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void binddteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			binddteDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void frmbindDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			frmbindDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void rmbtoDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			rmbtoDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void remaketypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void rmbfrmDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			rmbfrmDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void csonholdDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			csonholdDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void csoffholdDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			csoffholdDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void endstrecvDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			endstrecvDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void prtdtesentDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			prtdtesentDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void lamdtesentDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			lamdtesentDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void dcdtesentDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			dcdtesentDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void otdtesentDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			otdtesentDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void prtdtebkDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			prtdtebkDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void lamdtebkDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			lamdtebkDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void dcdtebkDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			dcdtebkDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void otdtebkDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			otdtebkDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void prntsamDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			prntsamDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		
		private void reprntdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			reprntdteDateTimePicker.Format = DateTimePickerFormat.Long;
		}
		private void desorgdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			desorgdteDateTimePicker.Format = DateTimePickerFormat.Long;
		}


		#endregion

		private void btnsheetSrch_Click(object sender, EventArgs e)
		{
			
					if (!SaveEndSheet())
					{
						var result1 = MessageBox.Show("End sheet record could not be saved. Continue search?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result1 == DialogResult.No)
						{
							return;
						}
					}


			var sqlQuery = new SQLQuery();
			string query = "Select endshtno,invno,schcode from endsheet where endshtno=@endshtno";
			var parameters = new SqlParameter[] { new SqlParameter("@endshtno", txtsheetSrch.Text) };
			var result = sqlQuery.ExecuteReaderAsync(CommandType.Text, query, parameters);
			if (result.Rows.Count > 0)
			{
				Schcode = result.Rows[0]["schcode"].ToString();
				Invno = int.Parse(result.Rows[0]["invno"].ToString());// will always have a invno
				Fill();
			}
			else { MessageBox.Show("Record was not found.", "End sheet Number Search", MessageBoxButtons.OK, MessageBoxIcon.Information); }
		}

		private void btnSupplSrch_Click(object sender, EventArgs e)
		{


			if (!SaveSupplement())
			{
				var result1 = MessageBox.Show("Supplement record could not be saved. Continue search?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result1 == DialogResult.No)
				{
					return;
				}
			}


			var sqlQuery = new SQLQuery();
			string query = "Select supno,invno,schcode from suppl where supno=@supno";
			var parameters = new SqlParameter[] { new SqlParameter("@supno",txtsupllSrch.Text) };
			var result = sqlQuery.ExecuteReaderAsync(CommandType.Text, query, parameters);
			if (result.Rows.Count > 0)
			{
				Schcode = result.Rows[0]["schcode"].ToString();
				Invno = int.Parse(result.Rows[0]["invno"].ToString());// will always have a invno
				Fill();
			}
			else { MessageBox.Show("Record was not found.", "Supplement Number Search", MessageBoxButtons.OK, MessageBoxIcon.Information); }
		}
	}
}
