﻿using System;
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
		private void AddEndSheet()
		{
			var sqlQuery = new SQLQuery();
		
			SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@Invno",this.Invno),
					 new SqlParameter("@Schcode",this.Schcode),
					
					};
			var strQuery = "INSERT INTO [dbo].[endsheet](Invno,Schcode)  VALUES (@Invno,@Schcode,@Contryear)";
			var endsheetResult = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters);
			if (endsheetResult != 1)
			{
				ExceptionlessClient.Default.CreateLog("Failed to insert endsheet record.")
					.AddTags("MemoryBook DestTop")
					.AddObject("Invoice#:" + Invno)
					.AddObject("Schcode:" + Schcode)
					.Submit();
				MessageBox.Show("Failed to insert endsheet record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				
					
				return;
			}
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
				return;
			}
			strQuery = "INSERT INTO [dbo].[priflit](Invno,Schcode)  VALUES (@Invno,@Schcode)";
			var priResult = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters);
			if (priResult != 1)
			{
				ExceptionlessClient.Default.CreateLog("Failed to insert endsheet record.")
					.AddTags("MemoryBook DestTop")
					.AddObject("Invoice#:" + Invno)
					.AddObject("Schcode:" + Schcode)
					.Submit();
				MessageBox.Show("Failed to insert priflit record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}



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
						AddEndSheet();
						Fill();

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

		private void label22_Click(object sender, EventArgs e)
		{

		}

		private void fillToolStripButton_Click(object sender, EventArgs e)
		{
			try
			{
				this.suppdetailTableAdapter.Fill(this.dsEndSheet.suppdetail, schcodeToolStripTextBox.Text);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}

		}
	}
}
