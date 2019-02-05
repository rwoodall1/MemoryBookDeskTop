using System;
using System.Threading.Tasks;
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
using BaseClass.Core;
using Mbc5.LookUpForms;
using BindingModels;
using Exceptionless;
using Exceptionless.Models;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Mbc5.Forms
{
	public partial class frmProdutn : BaseClass.frmBase, INotifyPropertyChanged
	{

		private bool startup = true;
		public frmProdutn(UserPrincipal userPrincipal, int invno, string schcode) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
		{
			InitializeComponent();
			//this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			// this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ApplicationUser = userPrincipal;
			this.Invno = invno;
			this.Schcode = schcode;

		}
		public frmProdutn(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
		{
			InitializeComponent();

			// this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			// this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ApplicationUser = userPrincipal;
			this.Invno = 0;
			this.Schcode = null;
			DisableControls(this.tbProdutn.TabPages[0]);
			foreach (TabPage tab in tbProdutn.TabPages)
			{
				DisableControls(tab);
			}
			EnableControls(this.txtSchCode);
			EnableControls(this.txtProdNoSrch);
			EnableControls(this.btnProdSrch);
			EnableControls(this.btnInvoiceSrch);

		}
		private void SetConnectionString()
		{
			frmMain frmMain = (frmMain)this.MdiParent;
			this.custTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.quotesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.produtnTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.ptbkbTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.partbkTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.wipgTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.wipTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.wipDetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.coverdetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.coversTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.lkTypeDataTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.lkpBackGroundTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.partbkTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.prtbkbdetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;

		}
		private void frmProdutn_Load(object sender, EventArgs e)
		{

			this.SetConnectionString();
			try
			{

				this.lkpBackGroundTableAdapter.Fill(this.lookUp.lkpBackGround);
				//LookUp Data
				this.lkTypeDataTableAdapter.Fill(this.lookUp.lkTypeData);

				Fill();
				SetShipLabel();
				SetEmail();
				CurrentProdNo = lblProdNo.Text;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}

		}

		#region "Properties"
		public void InvokePropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, e);
		}
		public event PropertyChangedEventHandler PropertyChanged;
		private UserPrincipal ApplicationUser { get; set; }
		private string CurrentCompany { get; set; }
		private string SchEmail { get; set; }
		private string ContactEmail { get; set; }
		private string BcontactEmail { get; set; }
		private string CcontactEmail { get; set; }
		private List<string> AllEmails { get; set; }
		private string CurrentProdNo { get; set; }
		#endregion
		#region "Methods"
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
		private void SetShipLabel()
		{
			var current = (DataRowView)produtnBindingSource.Current;
			if (current != null)
			{


				var shipdate = current["shpdate"].ToString();
				lblShipped.Visible = !String.IsNullOrEmpty(shipdate);
			}

		}
		private void SetEmail()
		{
			var current = (DataRowView)produtnBindingSource.Current;
			if (current == null)
			{
				return;
			}
			SchEmail = dsProdutn.cust.Rows[0].IsNull("schemail") ? null : dsProdutn.cust.Rows[0]["schemail"].ToString().Trim();
			ContactEmail = dsProdutn.cust.Rows[0].IsNull("contemail") ? null : dsProdutn.cust.Rows[0]["contemail"].ToString().Trim();
			BcontactEmail = dsProdutn.cust.Rows[0].IsNull("bcontemail") ? null : dsProdutn.cust.Rows[0]["bcontemail"].ToString().Trim();
			CcontactEmail = dsProdutn.cust.Rows[0].IsNull("ccontemail") ? null : dsProdutn.cust.Rows[0]["ccontemail"].ToString().Trim();
			var vAllEmails = new List<string>();
			if (!String.IsNullOrEmpty(SchEmail))
			{
				vAllEmails.Add(SchEmail);
			}
			if (!String.IsNullOrEmpty(ContactEmail))
			{
				vAllEmails.Add(ContactEmail);
			}
			if (!String.IsNullOrEmpty(BcontactEmail))
			{
				vAllEmails.Add(BcontactEmail);
			}

			if (!String.IsNullOrEmpty(CcontactEmail))
			{
				vAllEmails.Add(CcontactEmail);
			}
			AllEmails = vAllEmails;

		}

		//General
		private void SetCodeInvno()
		{
			if (quotesBindingSource.Count > 0)
			{
				DataRowView current = (DataRowView)quotesBindingSource.Current;
				this.Schcode = current["schcode"].ToString();
				this.Invno = Convert.ToInt32(current["invno"]);
			}
		}
		private void Fill()
		{
			if (Schcode != null)
			{
				custTableAdapter.Fill(dsProdutn.cust, Schcode);
				quotesTableAdapter.FillByInvno(dsProdutn.quotes, Invno);

				produtnTableAdapter.FillByInvno(dsProdutn.produtn, Invno);

				if (dsProdutn.produtn.Count < 1)
				{
					DisableControls(this.tbProdutn.TabPages[0]);
					foreach (TabPage tab in tbProdutn.TabPages)
					{
						DisableControls(tab);
					}
					EnableControls(this.txtSchCode);
					EnableControls(this.txtProdNoSrch);
					EnableControls(this.btnProdSrch);
					EnableControls(this.btnInvoiceSrch);
				}
				else { EnableAllControls(this); }
				coversTableAdapter.FillByInvno(dsProdutn.covers, Invno);
				//coversTableAdapter.Fill(dsProdutn.covers, this.Schcode);
				coverdetailTableAdapter.FillByInvno(dsProdutn.coverdetail, Invno);

				var row = (DataRowView)coversBindingSource1.Current;
				var a = row["specinst"].ToString();
				if (dsProdutn.covers.Count < 1)
				{
					DisableControls(this.tbProdutn.TabPages[2]);
				}
				else { EnableAllControls(this.tbProdutn.TabPages[2]); }
				wipTableAdapter.FillByInvno(dsProdutn.wip, Invno);
				wipDetailTableAdapter.FillBy(dsProdutn.WipDetail, Invno);
				if (dsProdutn.wip.Count < 1)
				{
					DisableControls(this.tbProdutn.TabPages[1]);
				}
				else { EnableAllControls(this.tbProdutn.TabPages[1]); }
				this.partbkTableAdapter.FillBy(dsProdutn.partbk, Invno);
				this.partBkDetailTableAdapter.FillBy(dsProdutn.PartBkDetail, Invno);
				if (dsProdutn.partbk.Count < 1)
				{
					DisableControls(this.tbProdutn.TabPages[4]);
				}
				else { EnableAllControls(this.tbProdutn.TabPages[4]); }

				ptbkbTableAdapter.FillBy(dsProdutn.ptbkb, Invno);
				prtbkbdetailTableAdapter.FillBy(dsProdutn.prtbkbdetail, Invno);
				if (dsProdutn.ptbkb.Count < 1)
				{
					DisableControls(this.tbProdutn.TabPages[5]);
				}
				else { EnableAllControls(this.tbProdutn.TabPages[5]); }


			}

			//        if (Invno != 0)
			//        {
			////var pos = produtnBindingSource.Find("invno", this.Invno);
			//var pos = quotesBindingSource.Find("invno", this.Invno);
			//var pos1 = produtnBindingSource.Find("invno", this.Invno);
			//if (pos > -1)
			//            {
			//                quotesBindingSource.Position = pos;
			//	produtnBindingSource.Position = pos1;

			// }
			//            else
			//            {
			//                MessageBox.Show("Production record was not found.", "Invoice#", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			//            }
			//        }

		}

		public override bool Save()
		{
			bool retval = true;
			switch (tbProdutn.SelectedIndex)
			{
				case 0:
					SaveProdutn();

					break;
				case 1:
					{
						SaveWip();
						SaveProdutn();//some produtn fiels are on wip tab so save
						break;
					}
				case 2:
					{
						SaveCovers();
						SaveProdutn();//some produtn fiels are on covers tab so save

						break;
					}

				case 3:

					break;
				case 4:
					SavePartBK();
					SaveProdutn();
					break;
				case 5:
					SavePtBkB();
					SaveProdutn();
					break;

			}
			return retval;
		}
		private bool SaveOrStop()
		{
			bool retval = true;
			switch (tbProdutn.SelectedIndex)
			{
				case 0:
					if (!SaveProdutn())
					{
						var result = MessageBox.Show("Production record could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result == DialogResult.No)
						{
							retval = false;

						}
					}
					break;

				case 1:
					if (!SaveWip())
					{
						var result = MessageBox.Show("Wip record could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result == DialogResult.No)
						{
							retval = false;
						}
					}
					break;

				case 2:
					if (!SaveCovers())
					{
						var result = MessageBox.Show("Cover record could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result == DialogResult.No)
						{
							retval = false; ;
						}
					}
					break;
				case 4:
					if (!SavePartBK())
					{
						var result = MessageBox.Show("Partial Book(A) could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result == DialogResult.No)
						{
							retval = false;
						}
					}
					break;

				case 5:
					if (!SavePtBkB())
					{
						var result = MessageBox.Show("Photos On CD record could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result == DialogResult.No)
						{
							retval = false;
						}
					}
					break;

				case 6:
					//if (!SavePtBkB())
					//{
					//	var result = MessageBox.Show("Photos On CD record could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					//	if (result == DialogResult.No)
					//	{
					//		e.Cancel = true;
					//		return;
					//	}
					//}
					break;
			}

			return retval;

		}
		private bool SavePartBK()
		{
			bool retval = false;
			if (dsProdutn.partbk.Count > 0)
			{
				if (this.ValidateChildren(ValidationConstraints.Enabled))
				{
					try
					{
						this.partbkBindingSource.EndEdit();
						var a = partbkTableAdapter.Update(dsProdutn.partbk);
						//must refill so we get updated time stamp so concurrency is not thrown
						partbkTableAdapter.FillBy(dsProdutn.partbk, Invno);
						retval = true;
					}
					catch (DBConcurrencyException dbex)
					{
						DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsProdutn.partbkRow)(dbex.Row), ref dsProdutn);
						if (result == DialogResult.Yes) { SavePartBK(); };
					}
					catch (Exception ex)
					{
						ex.ToExceptionless()
					   .SetMessage("Partial Book A record failed to update:" + ex.Message)
					   .Submit();
						retval = false;
					}
				}
			}
			else { retval = false; }

			return retval;
		}
		private bool SavePtBkB()
		{
			bool retval = false;
			if (dsProdutn.ptbkb.Count > 0)
			{
				if (this.ValidateChildren(ValidationConstraints.Enabled))
				{
					try
					{
						this.ptbkbBindingSource.EndEdit();
						var a = ptbkbTableAdapter.Update(dsProdutn.ptbkb);
						//must refill so we get updated time stamp so concurrency is not thrown
						ptbkbTableAdapter.FillBy(dsProdutn.ptbkb, Invno);
						retval = true;
					}
					catch (DBConcurrencyException dbex)
					{
						DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsProdutn.ptbkbRow)(dbex.Row), ref dsProdutn);
						if (result == DialogResult.Yes) { SavePtBkB(); };
					}
					catch (Exception ex)
					{
						ex.ToExceptionless()
					   .SetMessage("Photos On CD record failed to update:" + ex.Message)
					   .Submit();
						retval = false;
					}
				}
			}
			else { retval = false; }

			return retval;
		}
		private bool SaveProdutn()
		{
			bool retval = false;
			if (dsProdutn.produtn.Count > 0)
			{
				if (this.ValidateChildren(ValidationConstraints.Enabled))
				{
					try
					{

						this.produtnBindingSource.EndEdit();
						var a = produtnTableAdapter.Update(dsProdutn.produtn);
						//must refill so we get updated time stamp so concurrency is not thrown
						produtnTableAdapter.FillByInvno(dsProdutn.produtn, Invno);
						var aa = Invno;
						var pos = produtnBindingSource.Find("invno", this.Invno);
						if (pos > -1)
						{
							produtnBindingSource.Position = pos;

						}

						SetShipLabel();
						retval = true;

					}
					catch (DBConcurrencyException dbex)
					{
						DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsProdutn.produtnRow)(dbex.Row), ref dsProdutn);
						if (result == DialogResult.Yes) { SaveProdutn(); }
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
			else
			{
				retval = true;//no records just return
			}
			return retval;
		}
		private bool SaveWip()
		{
			bool retval = false;
			if (dsProdutn.wip.Count > 0)
			{

				//  if (this.Validate()) {
				try
				{
					this.wipBindingSource.EndEdit();
					var a = wipTableAdapter.Update(dsProdutn.wip);
					//must refill so we get updated time stamp so concurrency is not thrown
					wipTableAdapter.FillByInvno(dsProdutn.wip,Invno);
					retval = true;
				}
				catch (DBConcurrencyException ex1)
				{
					DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsProdutn.wipRow)(ex1.Row), ref dsProdutn);
					if (result == DialogResult.Yes) { SaveWip(); };
				}
				catch (Exception ex)
				{
					ex.ToExceptionless()
				   .SetMessage("WIP record failed to update:" + ex.Message)
				   .Submit();
					retval = false;
					MessageBox.Show("Wip record failed to update:" + ex.Message);
					;
				}
				// }
			}
			else { retval = false; }

			return retval;

		}
		private bool SaveCovers()
		{
			bool retval = false;
			if (dsProdutn.covers.Count > 0)
			{
				if (this.ValidateChildren(ValidationConstraints.Enabled))
				{
					try
					{
						this.coversBindingSource1.EndEdit();
						var a = coversTableAdapter.Update(dsProdutn.covers);
						//must refill so we get updated time stamp so concurrency is not thrown
						coversTableAdapter.FillByInvno(dsProdutn.covers, Invno);
						retval = true;
					}
					catch (DBConcurrencyException dbex)
					{
						DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsProdutn.coversRow)(dbex.Row), ref dsProdutn);
						if (result == DialogResult.Yes) { SaveCovers(); };
					}
					catch (Exception ex)
					{
						ex.ToExceptionless()
					   .SetMessage("Covers record failed to update:" + ex.Message)
					   .Submit();
						retval = false;
					}
				}
			}
			else { retval = false; }

			return retval;
		}
		public override bool Add()
		{
			MessageBox.Show("Add record is not available from the production screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			return true;
		}
		public override void Delete()
		{
			//switch (tabSales.SelectedIndex) {
			//    case 0:
			//    case 1:
			//            {
			//            DeleteSale();
			//            break;
			//            }
			//    case 2:
			//        DeleteInvoice();
			//        break;
			//    case 3:
			//        DeletePayment();
			//        break;

			//    }
		}
		public override void Cancel()
		{
			//CancelPayment();
			//quotesBindingSource.CancelEdit();
			//invdetailBindingSource.CancelEdit();
			//invoiceBindingSource.CancelEdit();
		}
		public void CoverSrch()
		{
			var pos = coversBindingSource1.Find("Specovr", txtspecov.Text);
			coversBindingSource1.Position = pos;

		}
		#endregion
		#region DatePickers
		private void prntsamDateTimePicker_ValueChanged(object sender, EventArgs e)
		{

			prntsamDateTimePicker.Format = DateTimePickerFormat.Long;

		}

		private void prtdtesentDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			prtdtesentDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void prtdtebkDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			prtdtebkDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void dcdtesentDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			dcdtesentDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void dcdtebkDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			dcdtebkDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void otdtesentDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			otdtesentDateTimePicker1.Format = DateTimePickerFormat.Long;
		}

		private void otdtebkDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			otdtebkDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void perslistdateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			perslistdateDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void lamdtesentDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			lamdtesentDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void reprntdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			reprntdteDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void desorgdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			desorgdteDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void screcvDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			screcvDateTimePicker1.Format = DateTimePickerFormat.Long;
		}
		private void rmbfrmDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			rmbfrmDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void rmbtoDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			rmbtoDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void ioutDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			ioutDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void frmbindDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			frmbindDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void iinDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			iinDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void binddteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			binddteDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void rmptoDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			rmptoDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void rmpfrmDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			rmpfrmDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void adduploaddateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			adduploaddateDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void dedayinDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			dedayinDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void dedayoutDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			dedayoutDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void screcvDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			screcvDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void cprecvDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			cprecvDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void ptrecvdDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			ptrecvdDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void ptbrcvdDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			ptbrcvdDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void kitrecvdDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			kitrecvdDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void toprodDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			toprodDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void tovendDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			tovendDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void warndateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			warndateDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void prshpdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			prshpdteDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void prmsdateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			prmsdateDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void shpdateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			shpdateDateTimePicker.Format = DateTimePickerFormat.Long;

		}

		private void cstsvcdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			dpCustomerServiceDate.Format = DateTimePickerFormat.Long;

		}

		private void comdateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			comdateDateTimePicker.Format = DateTimePickerFormat.Long;
		}
		#endregion
		private void frmProdutn_Paint(object sender, PaintEventArgs e)
		{

			try { this.Text = "Production-" + lblSchoolName.Text.Trim() + " (" + this.Schcode.Trim() + ")"; }
			catch
			{

			}
		}

		private void btnCalcDeadLine_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(dedayoutDateTimePicker.Value.ToString()))
			{
				int wks = 0;
				int days = 0;
				int.TryParse(txtWeeks.Text, out wks);
				int.TryParse(txtDays.Text, out days);


				var numDays = (wks * 5) + (days);
				var result = CalulateBusinessDay.BusDaySubtract(dedayoutDateTimePicker.Value, numDays);
				if (result != null)
				{
					dedayinDateTimePicker.Value = result;
				}
			}
			else { MessageBox.Show("Please enter a Deadline out Date."); }


		}

		private void btnCalCS_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(kitrecvdDateTimePicker.Value.ToString()))
			{
				int wks = 0;
				int days = 0;
				int.TryParse(txtWeeks.Text, out wks);
				int.TryParse(txtDays.Text, out days);


				var numDays = (wks * 5) + (days);
				var result = CalulateBusinessDay.BusDayAdd(kitrecvdDateTimePicker.Value, numDays);
				if (result != null)
				{
					dedayinDateTimePicker.Value = result;
				}
				txtCalcResult.Text = result.ToShortDateString();

			}
		}

		private void btnDeadLineInfo_Click(object sender, EventArgs e)
		{
			var emailHelper = new EmailHelper();
			string subject = this.Schcode + " " + lblSchoolName.Text.Trim() + " " + "Memorybook Deadlines";
			string body = "Here is your Memory Book deadline information.<br/><br/>Pages due in plant " + dedayinDateTimePicker.Value.ToShortDateString() + "<br/>Delivery date " + dedayoutDateTimePicker.Value.ToShortDateString();
			EmailType type = EmailType.Blank;
			if (CurrentCompany == "MBC")
			{
				type = EmailType.Mbc;
			}
			else if (CurrentCompany == "MER")
			{
				type = EmailType.Meridian;
			}

			emailHelper.SendOutLookEmail(subject, AllEmails, "", body, EmailType.Mbc);
		}

		private void btnEmailPw_Click(object sender, EventArgs e)
		{
			var emailHelper = new EmailHelper();
			string subject = this.Schcode + " " + lblSchoolName.Text.Trim() + " " + "Memorybook Online Access";
			string body = "Here is your Memory Book Online Access information.<br/>(Online account available the following business day by noon central time)<br/><br/>Job Number - " + txtjobno.Text + "<br/>Adviser User Name - Adviser<br/>Adviser Password - " + txtadvpw.Text + "<br/>Staff User Name - Staff <br/>Staff Password - " + txtstfpw.Text + "<br/><br/>Please note the passwords are case sensitive<br/>You can copy and paste the link below into a web browser to take you to the online website to enter your password information.<br/><br/>www.memoryebooks.com";
			EmailType type = EmailType.Blank;
			if (CurrentCompany == "MBC")
			{
				type = EmailType.Mbc;
			}
			else if (CurrentCompany == "MER")
			{
				type = EmailType.Meridian;
			}

			emailHelper.SendOutLookEmail(subject, this.AllEmails, "", body, type);
		}

		private void btnBinderyEmail_Click(object sender, EventArgs e)
		{
			var sqlQuery = new SQLQuery();
			var queryString = " Select cust.Schname,quotes.invno,produtn.ProdNo,produtn.NoPages,covers.reqstdcpy,produtn.CoverType,produtn.Diecut,produtn.CoilClr,produtn.prshpdte As ProjShpDate from cust inner join quotes on cust.schcode = quotes.schcode left join produtn on quotes.invno = produtn.invno left join covers on quotes.invno = covers.invno where cust.schcode = @Schcode and quotes.invno = @Invno";
			int vInvno = 0;
			int.TryParse(lblInvno.Text, out vInvno);
			SqlParameter[] parameters = new SqlParameter[] {
				 new SqlParameter("@Schcode",Schcode),
				 new SqlParameter("@Invno",vInvno)
			};
			List<BinderyInfo> result = (List<BinderyInfo>)sqlQuery.ExecuteReaderAsync<BinderyInfo>(CommandType.Text, queryString, parameters);
			if (result == null || result.Count < 1)
			{
				MessageBox.Show("Bindery information was not found.");
				return;
			}
			if (string.IsNullOrEmpty(result[0].Schname))
			{
				result[0].Schname = "";
			}

			if (string.IsNullOrEmpty(result[0].CoverType))
			{
				result[0].CoverType = "";
			}
			//<<<<<<< HEAD
			if (string.IsNullOrEmpty(result[0].CoilClr))
			{
				result[0].CoilClr = "";
				//=======

				//        private void FillWithInvno() {
				//            if (Invno != 0) {
				//                //coversTableAdapter.Fill(dsProdutn.covers,Invno);
				//                //coverdetailTableAdapter.Fill(dsProdutn.coverdetail, Invno);
				//                //if (dsProdutn.covers.Count < 1)
				//                //{
				//                //    DisableControls(specinstTextBox);                
				//                //}
				//                //else { EnableAllControls(this.tbProdutn.TabPages[2]); }


				//                wipTableAdapter.Fill(dsProdutn.wip,Invno);

				//                wipDetailTableAdapter.Fill(dsProdutn.WipDetail, Invno);
				//                if (dsProdutn.wip.Count < 1)
				//                {
				//                    var aa = this.tbProdutn.TabPages[3];
				//                    DisableControls(this.tbProdutn.TabPages[3]);

				//                }
				//                else {
				//                      EnableAllControls(this.tbProdutn.TabPages[3]);                    
				//                    }


				//            }
				//            }

				string vshipDate;
				if (result[0].ProjShpDate.Year < 1999)
				{
					vshipDate = "";
				}
				else { vshipDate = result[0].ProjShpDate.ToString(); }





				var body = "<strong>School Information<strong/><br/><br/>School Name " + result[0].Schname.Trim() + "<br/>Production No. " + result[0].ProdNo.Trim() + "<br/> No. of Pages " + result[0].NoPages + "<br/>Cover Type " + result[0].CoverType.Trim() + "<br/>Die Cut " + result[0].Diecut.ToString() + "<br/>Coil Color " + result[0].CoilClr.Trim() + "<br/>Projected Ship Date " + vshipDate;
				var subject = "Memory Book company Vendor Information";
				var emailHelper = new EmailHelper();
				EmailType type = EmailType.Blank;
				if (CurrentCompany == "MBC")
				{
					type = EmailType.Mbc;
				}
				else if (CurrentCompany == "MER")
				{
					type = EmailType.Meridian;
				}
				emailHelper.SendOutLookEmail(subject, "production@memorybook.com", "", body, type);


			}
		}
		private void btnUpdateJob_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(txtPerfbind.Text.Trim()))
			{
				MessageBox.Show("Please enter binding information before issueing a job number.");
				return;
			}
			var vInvno = 0;
			int.TryParse(lblInvno.Text, out vInvno);
			var sqlQuery = new SQLQuery();
			var queryString = "Select Top(1) quotes.invno,produtn.jobno from quotes inner join produtn on quotes.invno=produtn.invno  where quotes.schcode=@Schcode and quotes.invno<@Invno Order by Invno";
			SqlParameter[] parameters = new SqlParameter[] {
				 new SqlParameter("@Schcode",Schcode),
				 new SqlParameter("@Invno",vInvno)
			};

			var result = sqlQuery.ExecuteReaderAsync(CommandType.Text, queryString, parameters);
			if (result.Rows.Count > 0)
			{
				var oldJobNo = result.Rows[0]["jobno"].ToString();
				if (string.IsNullOrEmpty(oldJobNo.Trim()))
				{
					txtjobno.Text = "8" + lblProdNo.Text.Substring(1, 5);
				}
				else { txtjobno.Text = oldJobNo; }


			}
			else
			{
				txtjobno.Text = "8" + lblProdNo.Text.Substring(1, 5);

			}
			txtadvpw.Text = lblProdNo.Text.Substring(0, 6);
			txtstfpw.Text = dsProdutn.cust.Rows[0]["schstate"].ToString().Substring(0, 2) + lblcontryear.Text;



		}

		private void txtPerfbind_Leave(object sender, EventArgs e)
		{
			var row = (DataRowView)produtnBindingSource.Current;

			string prodno = lblProdNo.Text;
			switch (txtCompany.Text.ToUpper())
			{
				case "MBC":
					if (!String.IsNullOrEmpty(prodno.Substring(0, 2)))//has prodno
					{
						if (!String.IsNullOrEmpty(prodno))//letter changed not added
						{
							var vVal = prodno.Substring(0, 1);
							if (txtPerfbind.Text != vVal)
							{
								MessageBox.Show("Your Production Number (Binding) First Digit is not the same as this value... Press andy key to continue...It is being changed!", "Binding Type Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								if (txtPerfbind.Text == "C" || txtPerfbind.Text == "G" || txtPerfbind.Text == "K" || txtPerfbind.Text == "H" || txtPerfbind.Text == "P" || txtPerfbind.Text == "S" || txtPerfbind.Text == "M")
								{
									if (vVal == "C" || vVal == "G" || vVal == "K" || vVal == "H" || vVal == "P" || vVal == "S" || vVal == "M")
									{

										//replacing binding
										lblProdNo.Text = txtPerfbind.Text + lblProdNo.Text.Substring(1).Trim();

									}
									else
									{
										//adding binding

										lblProdNo.Text = txtPerfbind.Text + lblProdNo.Text.Trim();
										//need to replace quote prono at some time.


									}
								}
								else { MessageBox.Show("Unknow binding!", "Binding"); }

							}







						}//if2

					}//if 1
					break;
				case "MER":

					break;
			}

		}



		private void btnProdSrch_Click(object sender, EventArgs e)
		{
			switch (tbProdutn.SelectedIndex)
			{
				case 0:
					if (!SaveProdutn())
					{
						var result1 = MessageBox.Show("Production record could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result1 == DialogResult.No)
						{

							return;
						}
					}
					break;



			}



			var sqlQuery = new SQLQuery();
			string query = "Select prodno,invno,schcode from produtn where prodno=@prodno";
			var parameters = new SqlParameter[] { new SqlParameter("@prodno", txtProdNoSrch.Text) };
			var result = sqlQuery.ExecuteReaderAsync(CommandType.Text, query, parameters);
			if (result.Rows.Count > 0)
			{
				Schcode = result.Rows[0]["schcode"].ToString();
				Invno = int.Parse(result.Rows[0]["invno"].ToString());// will always have a invno
				Fill();
			}
			else { MessageBox.Show("Record was not found.", "Production Number Search", MessageBoxButtons.OK, MessageBoxIcon.Information); }
			frmProdutn_Paint(this, null);
		}

	

		private void wipDetailDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			DataRowView row = (DataRowView)wipDetailBindingSource.Current;
			int id = (int)row["id"];
			int invno = (int)row["invno"];
			frmEditWip frmeditWip = new frmEditWip(id, invno);
			var result = frmeditWip.ShowDialog();
			if (result == DialogResult.OK)
			{
				wipDetailTableAdapter.FillBy(dsProdutn.WipDetail, Invno);
			}
		}

		private void nocopiesTextBox1_Validating(object sender, CancelEventArgs e)
		{
			this.errorProvider1.SetError(nocopiesTextBox, "");
			int vInt;
			if (String.IsNullOrEmpty(nocopiesTextBox.Text))
			{ nocopiesTextBox.Text = "0"; }
			if (!String.IsNullOrEmpty(nocopiesTextBox.Text) && !int.TryParse(nocopiesTextBox.Text, out vInt))
			{

				this.errorProvider1.SetError(nocopiesTextBox, "Only numbers are allowed.");
				e.Cancel = true;
			}
		}

		private void totsigsTextBox_Validating(object sender, CancelEventArgs e)
		{
			this.errorProvider1.SetError(totsigsTextBox, "");
			int vInt;
			if (String.IsNullOrEmpty(totsigsTextBox.Text))
			{ totsigsTextBox.Text = "0"; }
			if (!String.IsNullOrEmpty(totsigsTextBox.Text) && !int.TryParse(totsigsTextBox.Text, out vInt))
			{

				this.errorProvider1.SetError(totsigsTextBox, "Only numbers are allowed.");
				e.Cancel = true;
			}
			else { e.Cancel = false; }
		}

		private void reqstdcpyTextBox_Validating(object sender, CancelEventArgs e)
		{
			this.errorProvider1.SetError(reqstdcpyTextBox, "");
			if (String.IsNullOrEmpty(reqstdcpyTextBox.Text))
			{
				reqstdcpyTextBox.Text = "0";
			}
			int vInt;
			if (!String.IsNullOrEmpty(reqstdcpyTextBox.Text) && !int.TryParse(reqstdcpyTextBox.Text, out vInt))
			{

				this.errorProvider1.SetError(reqstdcpyTextBox, "Only numbers are allowed.");
				e.Cancel = true;
			}
		}

		private void txtnoPlates_Validating(object sender, CancelEventArgs e)
		{
			this.errorProvider1.SetError(txtnoPlates, "");
			if (String.IsNullOrEmpty(txtnoPlates.Text))
			{ txtnoPlates.Text = "0"; }
			int vInt;
			if (!String.IsNullOrEmpty(txtnoPlates.Text) && !int.TryParse(txtnoPlates.Text, out vInt))
			{

				this.errorProvider1.SetError(txtnoPlates, "Only numbers are allowed.");
				e.Cancel = true;
			}
		}

		private void textBox7_Validating(object sender, CancelEventArgs e)
		{
			this.errorProvider1.SetError(textBox7, "");
			int vInt;
			if (!String.IsNullOrEmpty(textBox7.Text) && !int.TryParse(textBox7.Text, out vInt))
			{

				this.errorProvider1.SetError(textBox7, "Only numbers are allowed.");
				e.Cancel = true;
			}
		}

		private void btncoverSrch_Click(object sender, EventArgs e)
		{
			CoverSrch();
		}

		private void coverdetailDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			DataRowView row = (DataRowView)coverdetailBindingSource.Current;
			int id = (int)row["id"];
			int invno = (int)row["invno"];
			frmEditCoverWip frmeditCoverWip = new frmEditCoverWip(id, invno);
			var result = frmeditCoverWip.ShowDialog();
			if (result == DialogResult.OK)
			{
				wipDetailTableAdapter.FillBy(dsProdutn.WipDetail, Invno);
			}
		}

		private void partBkDetailDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			DataRowView row = (DataRowView)partBkDetailBindingSource.Current;
			int id = (int)row["id"];
			int invno = (int)row["invno"];
			frmEditCoverWip frmeditCoverWip = new frmEditCoverWip(id, invno);
			var result = frmeditCoverWip.ShowDialog();
			if (result == DialogResult.OK)
			{
				wipDetailTableAdapter.FillBy(dsProdutn.WipDetail, Invno);
			}
		}

		private void frmProdutn_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!SaveOrStop())
			{
				e.Cancel = true;

			}

		}
		private void tbProdutn_Deselecting(object sender, TabControlCancelEventArgs e)
		{

			if (!SaveOrStop())
			{
				e.Cancel = true;

			}
		}

		
		public async Task<ApiProcessingResult<bool>> UpdateWipDetailCall(int vDescripId, DateTime? vWdr, string vInvno)
		{
			var processingResult = new ApiProcessingResult<bool>();
			bool isUpdate = true;
			if (vWdr == null)
			{
				isUpdate = false;
			}
			var sqlClient = new SQLCustomClient();
			sqlClient.ClearParameters();
			sqlClient.AddParameter("@DescripID", vDescripId);
			sqlClient.AddParameter("@wdr", vWdr);
			sqlClient.AddParameter("@invno", vInvno);
			sqlClient.AddParameter("@Schcode", this.Schcode);
			var commandText = "";
			if (isUpdate)
			{
				commandText = @"
                         	IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                Begin
                                INSERT INTO WipDetail (DescripID,Invno,Wdr,Schcode) VALUES(@DescripID,@Invno,@wdr,@Schcode);
                                END
							ELSE
								BEGIN
									UPDATE WipDetail SET wdr=@wdr  WHERE Invno=@Invno AND DescripID=@DescripID
								END ";
			}
			else
			{
				//commandText=@"IF EXISTS(Select tmp.Invno, tmp.DescripID from WipDetail tmp WHERE tmp.Invno = @Invno and tmp.DescripID = @DescripID)
				//				Begin
				//			     UPDATE WipDetail SET wdr = @wdr  WHERE Invno = @Invno AND DescripID = @DescripID
				//				END";
				commandText = @"
						Delete FROM WipDetail  WHERE Invno = @Invno AND DescripID = @DescripID
							";
			}

			sqlClient.CommandText(commandText);
			var wipResult = sqlClient.Update();
			if (wipResult.IsError)
			{
				processingResult.IsError = true;
				processingResult.Data = false;
				return processingResult;

			}


			processingResult.IsError = false;
			processingResult.Data = true;
			return processingResult;
		}
		private void btnSchoolSearch_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtSchNamesrch.Text.Trim()))
			{
				return;
			}    
			
				//var records = this.custTableAdapter.FillBySchname(this.dsCust.cust,txtSchNamesrch.Text);
				var sqlQuery = new SQLQuery();
				var queryString = @"SELECT P.ProdNo,P.Invno, C.Schcode, C.Schname,C.Schcity,C.Schstate,C.Schzip 
							 FROM Cust C
								Left Join Quotes Q ON C.Schcode=Q.Schcode
								Left Join Produtn P On Q.Invno=P.Invno
                              WHERE P.Invno IS NOT NULL AND (C.Schname LIKE @Schname + '%')
                              ORDER BY Schname,Invno";
				SqlParameter[] parameters = new SqlParameter[] {
			   new SqlParameter("@Schname",txtSchNamesrch.Text.Trim())
			};
				var dataResult = sqlQuery.ExecuteReaderAsync<ProdutnSchoolNameSearchModel>(CommandType.Text, queryString, parameters);
				var records = (List<ProdutnSchoolNameSearchModel>)dataResult;
			if (records == null || records.Count < 1)
				{
				

					MessageBox.Show("No Records were found with this criteria.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (records.Count > 1)
				{
			
					//more than one record select which one you want

					this.Cursor = Cursors.AppStarting;
					
					frmProdutnSelctCust frmProdutnSelectCust = new frmProdutnSelctCust(records);
					DialogResult result = frmProdutnSelectCust.ShowDialog();
					this.Cursor = Cursors.Default;
					if (result != DialogResult.Cancel)
					{
					if (frmProdutnSelectCust.retval==0)
					{
						return;
					}
					this.Invno = frmProdutnSelectCust.retval;
					this.Fill();
					}
					
				}
				txtSchNamesrch.Text = "";
			    frmProdutn_Paint(this, null);
			
		}

		#region Validation
		private void laminatedTextBox_Validating(object sender, CancelEventArgs e)
		{

		}

		private void frmProdutn_Shown(object sender, EventArgs e)
		{
			//Leave here. This is put in to give dataset time to fill
			//ctrl are not bound until they are shown in tab https://stackoverflow.com/questions/3670694/loading-windows-form-with-over-200-controls
			this.tbProdutn.Visible = true;
		}

		private void mnCust_Click(object sender, EventArgs e)
		{
			LkpCustType frmLkpCust = new LkpCustType(this.ApplicationUser);
			this.Cursor = Cursors.AppStarting;
			frmLkpCust.MdiParent = this.ParentForm;
			frmLkpCust.Show();
			this.Cursor = Cursors.Default;
		}

		private void mnBackGround_Click(object sender, EventArgs e)
		{
			LkpBackGround frmLkpBackGround = new LkpBackGround(this.ApplicationUser);
			this.Cursor = Cursors.AppStarting;
			frmLkpBackGround.MdiParent = this.ParentForm;
			frmLkpBackGround.Show();
			this.Cursor = Cursors.Default;
		}

		private void mnType_Click(object sender, EventArgs e)
		{
			LkpTypeStyle frmLkpTypeStyle = new LkpTypeStyle(this.ApplicationUser);
			this.Cursor = Cursors.AppStarting;
			frmLkpTypeStyle.MdiParent = this.ParentForm;
			frmLkpTypeStyle.Show();
			this.Cursor = Cursors.Default;
		}

		private void vendcdComboBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (ApplicationUser.IsInRole("Administrator") || ApplicationUser.IsInRole("SA"))
			{
				if (e.Button == MouseButtons.Right)
				{
					addItemMenu.Items["mnType"].Visible = true;
					addItemMenu.Items["mnCust"].Visible = false;
					addItemMenu.Items["mnBackGround"].Visible = false;
					addItemMenu.Show(this, new Point(e.X, e.Y));
				}
			}
		}

		private void cstatComboBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (ApplicationUser.IsInRole("Administrator") || ApplicationUser.IsInRole("SA"))
			{
				if (e.Button == MouseButtons.Right)
				{
					addItemMenu.Items["mnType"].Visible = false;
					addItemMenu.Items["mnCust"].Visible = true;
					addItemMenu.Items["mnBackGround"].Visible = false;
					addItemMenu.Show(this, new Point(e.X, e.Y));
				}
			}
		}

		private void bkgrndComboBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (ApplicationUser.IsInRole("Administrator") || ApplicationUser.IsInRole("SA"))
			{
				if (e.Button == MouseButtons.Right)
				{
					addItemMenu.Items["mnType"].Visible = false;
					addItemMenu.Items["mnCust"].Visible = false;
					addItemMenu.Items["mnBackGround"].Visible = true;
					addItemMenu.Show(this, new Point(e.X, e.Y));
				}
			}
		}

		private void nopagesTextBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (ApplicationUser.IsInRole("Administrator") || ApplicationUser.IsInRole("SA"))
				{
					this.nopagesTextBox.ReadOnly = false;
				}
			}
		}

		private void nopagesTextBox_Leave(object sender, EventArgs e)
		{
			this.nopagesTextBox.ReadOnly = true;
		}

		private void nocopiesTextBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (ApplicationUser.IsInRole("Administrator") || ApplicationUser.IsInRole("SA"))
				{
					this.nocopiesTextBox.ReadOnly = false;
				}
			}
		}

		private void nocopiesTextBox_Leave(object sender, EventArgs e)
		{
			this.nocopiesTextBox.ReadOnly = true;
		}

		private void lblModifiedBy_Paint(object sender, PaintEventArgs e)
		{
			lblModifiedBy.Text = ApplicationUser.id;
		}

		private async Task<ApiProcessingResult<string>> WipUpdate()
		{
			this.Save();
			var processingResult = new ApiProcessingResult<string>();
			if (string.IsNullOrEmpty(dpCustomerServiceDate.Text))
			{
				processingResult.IsError = true;
				return processingResult;

			}
			var sqlClient = new SQLCustomClient();
			string commandText = "";
			if (bkStd.Checked)
			{
				commandText = @" Select * FROM WipDats Order BY bktype
                                ";

			} else if (bk9.Checked)
			{
				commandText = @" Select * FROM WipDat9 Order BY bktype
                                ";
			}
			else if (bk10.Checked)
			{
				commandText = @" Select * FROM WipDat10 Order BY bktype
                                ";
			}
			else if (bk11.Checked)
			{
				commandText = @" Select * FROM WipDat11 Order BY bktype";
			}
			else if (bk12.Checked)
			{
				commandText = @"Select * FROM WipDat12 Order BY bktype";
			}
			else if (bkHard.Checked)
			{
				commandText = @"Select * FROM WipDath Order BY bktype";
			}
			else if (bkCoil.Checked)
			{
				commandText = @"Select * FROM WipDatc Order BY bktype";
			}
			else if (bkAllClr.Checked)
			{
				commandText = @" Select * FROM WipDatal Order BY bktype";
			}
			else if (bkMilled.Checked)
			{
				commandText = @" Select * FROM WipDatmilled Order BY bktype";
			}
			else
			{
				commandText = @"Select * FROM WipDats Order BY bktype";
			};

			decimal[] wCalc = new decimal[50];
			sqlClient.CommandText(commandText);
			var result = sqlClient.SelectMany<WipDats>();
			if (result.IsError)
			{
				MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				processingResult.IsError = true;
				return processingResult;
			}
			if (result.Data == null)
			{
				processingResult.IsError = true;
				return processingResult;
			}
			var vWipsDats = (List<WipDats>)result.Data;
			string vBooktype = txtBookType.Text.Trim();

			WipDats vWhipDates = new WipDats();
			foreach (WipDats dat in vWipsDats)
			{
				if (dat.bktype == vBooktype)
				{
					vWhipDates = dat;
					break;
				}
			}
			DateTime custSvcDate = dpCustomerServiceDate.Value;
			if (vWhipDates.prmsdte != 0)
			{

				sqlClient.ClearParameters();
				sqlClient.AddParameter("@prmsdate", CalulateBusinessDay.PromiseDate(custSvcDate, vWhipDates.prmsdte));
				sqlClient.AddParameter("@invno", lblInvno.Text);
				commandText = @"
                        Update produtn Set prmsdate=@prmsdate WHERE invno=@invno
                        ";
				sqlClient.CommandText(commandText);
				var promiseDateResult = sqlClient.Update();
				if (promiseDateResult.IsError)
				{
					MessageBox.Show("Failed to update the promise date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}
			else
			{

				sqlClient.ClearParameters();

				sqlClient.AddParameter("@invno", lblInvno.Text);
				commandText = @"
                        Update produtn Set prmsdate=null WHERE invno=@invno
                        ";
				sqlClient.CommandText(commandText);
				var promiseDateResult = sqlClient.Update();
				if (promiseDateResult.IsError)
				{
					MessageBox.Show("Failed to update the promise date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}

			if (vWhipDates.l_dtoprod != 0) {
				sqlClient.ClearParameters();
				sqlClient.AddParameter("@dtoprod", CalulateBusinessDay.PromiseDate(custSvcDate, vWhipDates.l_dtoprod));
				sqlClient.AddParameter("@invno", lblInvno.Text);
				commandText = @"
                        Update WIP Set dtoprod=@dtoprod WHERE invno=@invno
                        ";
				sqlClient.CommandText(commandText);
				var toProdResult = sqlClient.Update();
				if (toProdResult.IsError)
				{
					MessageBox.Show("Failed to update wip To production date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				sqlClient.ClearParameters();

				sqlClient.AddParameter("@invno", lblInvno.Text);
				commandText = @"
                        Update WIP Set dtoprod=null WHERE invno=@invno
                        ";
				sqlClient.CommandText(commandText);
				var toProdResult = sqlClient.Update();
				if (toProdResult.IsError)
				{
					MessageBox.Show("Failed to update wip To production date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}
			if (vWhipDates.prshpdte != 0)
			{
				sqlClient.ClearParameters();
				sqlClient.AddParameter("@prshpdte", CalulateBusinessDay.PromiseDate(custSvcDate, vWhipDates.prshpdte));
				sqlClient.AddParameter("@invno", lblInvno.Text);
				commandText = @"
                        Update Produtn Set prshpdte=@prshpdte WHERE invno=@invno
                        ";
				sqlClient.CommandText(commandText);
				var preShipDateResult = sqlClient.Update();
				if (preShipDateResult.IsError)
				{
					MessageBox.Show("Failed to update the projected Ship Date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}


				var updateResult = await UpdateWipDetailCall(50, CalulateBusinessDay.PromiseDate(custSvcDate, vWhipDates.prshpdte), lblInvno.Text);

				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #50a", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}


			}
			else
			{
				sqlClient.ClearParameters();
				sqlClient.ClearParameters();
				sqlClient.AddParameter("@prshpdte", CalulateBusinessDay.PromiseDate(custSvcDate, vWhipDates.prshpdte));
				sqlClient.AddParameter("@invno", lblInvno.Text);

				commandText = @"
                         Update Produtn Set prshpdte=null WHERE invno=@invno
                        ";
				sqlClient.CommandText(commandText);
				var promiseDateResult = sqlClient.Update();
				if (promiseDateResult.IsError)
				{
					MessageBox.Show("Failed to update the Projected Ship Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}



				var updateResult = await UpdateWipDetailCall(50, CalulateBusinessDay.PromiseDate(custSvcDate, vWhipDates.prshpdte), lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Database error. #50a", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.wrndte != 0)
			{
				sqlClient.ClearParameters();
				sqlClient.AddParameter("@warndate", CalulateBusinessDay.PromiseDate(custSvcDate, vWhipDates.prshpdte));
				sqlClient.AddParameter("@invno", lblInvno.Text);

				commandText = @"
                        Update Produtn Set warndate =@warndate  WHERE invno=@invno
                        ";
				sqlClient.CommandText(commandText);
				var preShipDateResult = sqlClient.Update();
				if (preShipDateResult.IsError)
				{
					MessageBox.Show("Failed to update the Production Pre Ship Date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}
			else
			{
				sqlClient.ClearParameters();

				sqlClient.AddParameter("@invno", lblInvno.Text);
				commandText = @"
                         Update Produtn Set warndate =null WHERE invno=@invno
                        ";
				sqlClient.CommandText(commandText);
				var promiseDateResult = sqlClient.Update();
				if (promiseDateResult.IsError)
				{
					MessageBox.Show("Failed to update the wip Pre Ship Date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			DateTime? ProductionShipDate = CalulateBusinessDay.PromiseDate(custSvcDate, vWhipDates.prshpdte);
			if (ProductionShipDate == null)
			{
				processingResult.IsError = true;
				return processingResult;
			}
			wCalc[49] = vWhipDates.l_wdr49 + vWhipDates.prmsdte;

			if (vWhipDates.l_wdr49 != 0)
			{
				wCalc[48] = vWhipDates.l_wdr49 + wCalc[49];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[49], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(49, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #49", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[48] = vWhipDates.l_wdr49 + wCalc[49];

				var updateResult = await UpdateWipDetailCall(49, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #49", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}

			if (vWhipDates.l_wdr48 != 0)
			{
				wCalc[47] = vWhipDates.l_wdr48 + wCalc[48];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[48], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(48, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #48", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[47] = vWhipDates.l_wdr48 + wCalc[48];

				var updateResult = await UpdateWipDetailCall(48, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #48", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}
			if (vWhipDates.l_wdr47 != 0)
			{
				wCalc[46] = vWhipDates.l_wdr47 + wCalc[47];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[47], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(47, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #47", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[46] = vWhipDates.l_wdr47 + wCalc[47];

				var updateResult = await UpdateWipDetailCall(47, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #47", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}

			if (vWhipDates.l_wdr46 != 0)
			{
				wCalc[45] = vWhipDates.l_wdr46 + wCalc[46];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[46], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(46, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #46", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[45] = vWhipDates.l_wdr46 + wCalc[46];

				var updateResult = await UpdateWipDetailCall(46, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #46", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}
			if (vWhipDates.l_wdr45 != 0)
			{
				wCalc[44] = vWhipDates.l_wdr45 + wCalc[45];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[45], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(45, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #45", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[44] = vWhipDates.l_wdr45 + wCalc[45];

				var updateResult = await UpdateWipDetailCall(45, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #45", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}
			if (vWhipDates.l_wdr44 != 0)
			{
				wCalc[43] = vWhipDates.l_wdr44 + wCalc[4];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[44], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(44, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #44", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[43] = vWhipDates.l_wdr44 + wCalc[44];

				var updateResult = await UpdateWipDetailCall(44, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #44", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}

			if (vWhipDates.l_wdr43 != 0)
			{
				wCalc[42] = vWhipDates.l_wdr43 + wCalc[4];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[43], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(43, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #43", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[42] = vWhipDates.l_wdr43 + wCalc[43];

				var updateResult = await UpdateWipDetailCall(43, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #43", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}
			if (vWhipDates.l_wdr42 != 0)
			{
				wCalc[41] = vWhipDates.l_wdr42 + wCalc[4];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[42], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(42, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #42", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[41] = vWhipDates.l_wdr42 + wCalc[42];

				var updateResult = await UpdateWipDetailCall(42, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #42", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}

			if (vWhipDates.l_wdr41 != 0)
			{
				wCalc[40] = vWhipDates.l_wdr41 + wCalc[41];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[41], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(41, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #41", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[40] = vWhipDates.l_wdr41 + wCalc[41];

				var updateResult = await UpdateWipDetailCall(41, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #41", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}

			}

			if (vWhipDates.l_wdr40 != 0)
			{
				wCalc[39] = vWhipDates.l_wdr40 + wCalc[40];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[40], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(40, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[39] = vWhipDates.l_wdr40 + wCalc[40];

				var updateResult = await UpdateWipDetailCall(40, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr39 != 0)
			{
				wCalc[38] = vWhipDates.l_wdr39 + wCalc[39];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[39], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(39, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #39", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[38] = vWhipDates.l_wdr39 + wCalc[39];

				var updateResult = await UpdateWipDetailCall(39, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #39", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr38 != 0)
			{
				wCalc[37] = vWhipDates.l_wdr38 + wCalc[38];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[38], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(38, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #38", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[37] = vWhipDates.l_wdr38 + wCalc[38];

				var updateResult = await UpdateWipDetailCall(38, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #38", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr37 != 0)
			{
				wCalc[36] = vWhipDates.l_wdr37 + wCalc[37];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[37], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(37, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #37", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[36] = vWhipDates.l_wdr37 + wCalc[37];

				var updateResult = await UpdateWipDetailCall(37, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #37", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr36 != 0)
			{
				wCalc[35] = vWhipDates.l_wdr36 + wCalc[36];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[36], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(36, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #36", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[35] = vWhipDates.l_wdr36 + wCalc[36];

				var updateResult = await UpdateWipDetailCall(36, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #36", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr35 != 0)
			{
				wCalc[34] = vWhipDates.l_wdr35 + wCalc[35];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[35], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(35, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #35", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[34] = vWhipDates.l_wdr35 + wCalc[35];

				var updateResult = await UpdateWipDetailCall(35, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #35", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr34 != 0)
			{
				wCalc[33] = vWhipDates.l_wdr34 + wCalc[34];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[34], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(34, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #34", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[33] = vWhipDates.l_wdr34 + wCalc[34];

				var updateResult = await UpdateWipDetailCall(34, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #34", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr33 != 0)
			{
				wCalc[32] = vWhipDates.l_wdr33 + wCalc[33];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[33], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(33, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #33", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[32] = vWhipDates.l_wdr33 + wCalc[33];

				var updateResult = await UpdateWipDetailCall(33, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #33", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr32 != 0)
			{
				wCalc[31] = vWhipDates.l_wdr32 + wCalc[32];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[32], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(32, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #32", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[31] = vWhipDates.l_wdr32 + wCalc[32];

				var updateResult = await UpdateWipDetailCall(32, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #32", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr31 != 0)
			{
				wCalc[30] = vWhipDates.l_wdr31 + wCalc[31];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[31], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(31, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #31", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[30] = vWhipDates.l_wdr31 + wCalc[31];

				var updateResult = await UpdateWipDetailCall(31, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #31", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr30 != 0)
			{
				wCalc[29] = vWhipDates.l_wdr30 + wCalc[30];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[30], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(30, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #30", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[29] = vWhipDates.l_wdr30 + wCalc[30];

				var updateResult = await UpdateWipDetailCall(30, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #30", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr29 != 0)
			{
				wCalc[28] = vWhipDates.l_wdr29 + wCalc[29];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[29], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(29, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #29", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[28] = vWhipDates.l_wdr29 + wCalc[29];

				var updateResult = await UpdateWipDetailCall(29, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #29", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr28 != 0)
			{
				wCalc[27] = vWhipDates.l_wdr28 + wCalc[28];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[28], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(28, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #28", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[27] = vWhipDates.l_wdr28 + wCalc[28];

				var updateResult = await UpdateWipDetailCall(28, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #28", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr27 != 0)
			{
				wCalc[26] = vWhipDates.l_wdr27 + wCalc[27];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[27], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(27, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #27", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[26] = vWhipDates.l_wdr27 + wCalc[27];

				var updateResult = await UpdateWipDetailCall(27, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #27", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr26 != 0)
			{
				wCalc[25] = vWhipDates.l_wdr26 + wCalc[26];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[26], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(26, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #26", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[25] = vWhipDates.l_wdr26 + wCalc[26];

				var updateResult = await UpdateWipDetailCall(26, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #26", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr25 != 0)
			{
				wCalc[24] = vWhipDates.l_wdr25 + wCalc[25];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[25], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(25, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #25", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[24] = vWhipDates.l_wdr25 + wCalc[25];

				var updateResult = await UpdateWipDetailCall(25, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #25", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr24 != 0)
			{
				wCalc[23] = vWhipDates.l_wdr24 + wCalc[24];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[24], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(24, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #24", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[23] = vWhipDates.l_wdr24 + wCalc[24];

				var updateResult = await UpdateWipDetailCall(24, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #24", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr23 != 0)
			{
				wCalc[22] = vWhipDates.l_wdr23 + wCalc[23];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[23], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(23, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #23", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[22] = vWhipDates.l_wdr23 + wCalc[23];

				var updateResult = await UpdateWipDetailCall(23, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #23", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr22 != 0)
			{
				wCalc[21] = vWhipDates.l_wdr22 + wCalc[22];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[22], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(22, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #22", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[21] = vWhipDates.l_wdr22 + wCalc[22];

				var updateResult = await UpdateWipDetailCall(22, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #22", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr21 != 0)
			{
				wCalc[20] = vWhipDates.l_wdr21 + wCalc[21];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[21], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(21, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #21", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[20] = vWhipDates.l_wdr21 + wCalc[21];

				var updateResult = await UpdateWipDetailCall(21, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #21", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr20 != 0)
			{
				wCalc[19] = vWhipDates.l_wdr20 + wCalc[20];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[20], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(20, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[19] = vWhipDates.l_wdr20 + wCalc[20];

				var updateResult = await UpdateWipDetailCall(20, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr19 != 0)
			{
				wCalc[18] = vWhipDates.l_wdr19 + wCalc[19];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[19], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(19, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #19", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[18] = vWhipDates.l_wdr19 + wCalc[19];

				var updateResult = await UpdateWipDetailCall(19, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #19", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr18 != 0)
			{
				wCalc[17] = vWhipDates.l_wdr18 + wCalc[18];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[18], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(18, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #18", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[17] = vWhipDates.l_wdr18 + wCalc[18];

				var updateResult = await UpdateWipDetailCall(18, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #18", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr17 != 0)
			{
				wCalc[16] = vWhipDates.l_wdr17 + wCalc[17];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[17], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(17, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #17", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[16] = vWhipDates.l_wdr17 + wCalc[17];

				var updateResult = await UpdateWipDetailCall(17, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #17", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr16 != 0)
			{
				wCalc[15] = vWhipDates.l_wdr16 + wCalc[16];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[16], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(16, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #16", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[15] = vWhipDates.l_wdr16 + wCalc[16];

				var updateResult = await UpdateWipDetailCall(16, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #16", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr15 != 0)
			{
				wCalc[14] = vWhipDates.l_wdr15 + wCalc[15];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[15], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(15, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #15", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[15] = vWhipDates.l_wdr15 + wCalc[15];

				var updateResult = await UpdateWipDetailCall(15, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #15", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr14 != 0)
			{
				wCalc[13] = vWhipDates.l_wdr14 + wCalc[14];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[14], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(14, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #14", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[13] = vWhipDates.l_wdr14 + wCalc[14];

				var updateResult = await UpdateWipDetailCall(14, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #14", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr13 != 0)
			{
				wCalc[12] = vWhipDates.l_wdr13 + wCalc[13];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[13], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(13, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #13", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[12] = vWhipDates.l_wdr13 + wCalc[13];

				var updateResult = await UpdateWipDetailCall(13, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #13", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			if (vWhipDates.l_wdr12 != 0)
			{
				wCalc[11] = vWhipDates.l_wdr12 + wCalc[12];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[12], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(12, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #12", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[11] = vWhipDates.l_wdr12 + wCalc[12];

				var updateResult = await UpdateWipDetailCall(12, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #12", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr11 != 0)
			{
				wCalc[10] = vWhipDates.l_wdr11 + wCalc[11];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[11], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(11, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #11", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[10] = vWhipDates.l_wdr11 + wCalc[11];

				var updateResult = await UpdateWipDetailCall(11, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #11", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr10 != 0)
			{
				wCalc[9] = vWhipDates.l_wdr10 + wCalc[10];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[10], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(10, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[10] = vWhipDates.l_wdr10 + wCalc[10];

				var updateResult = await UpdateWipDetailCall(10, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr9 != 0)
			{
				wCalc[8] = vWhipDates.l_wdr9 + wCalc[9];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[9], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(9, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #9", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[8] = vWhipDates.l_wdr9 + wCalc[9];

				var updateResult = await UpdateWipDetailCall(9, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #9", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr8 != 0)
			{
				wCalc[7] = vWhipDates.l_wdr8 + wCalc[8];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[8], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(8, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #8", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[7] = vWhipDates.l_wdr8 + wCalc[8];

				var updateResult = await UpdateWipDetailCall(8, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #8", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr7 != 0)
			{
				wCalc[6] = vWhipDates.l_wdr7 + wCalc[7];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[7], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(7, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #7", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[6] = vWhipDates.l_wdr7 + wCalc[7];

				var updateResult = await UpdateWipDetailCall(7, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #7", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr6 != 0)
			{
				wCalc[5] = vWhipDates.l_wdr6 + wCalc[6];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[6], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(6, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[6] = vWhipDates.l_wdr6 + wCalc[6];

				var updateResult = await UpdateWipDetailCall(6, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr5 != 0)
			{
				wCalc[4] = vWhipDates.l_wdr5 + wCalc[5];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[5], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(5, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[4] = vWhipDates.l_wdr5 + wCalc[5];

				var updateResult = await UpdateWipDetailCall(5, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr4 != 0)
			{
				wCalc[3] = vWhipDates.l_wdr4 + wCalc[4];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[4], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(4, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[3] = vWhipDates.l_wdr4 + wCalc[4];

				var updateResult = await UpdateWipDetailCall(4, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr3 != 0)
			{
				wCalc[2] = vWhipDates.l_wdr3 + wCalc[3];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[3], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(3, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[2] = vWhipDates.l_wdr3 + wCalc[3];

				var updateResult = await UpdateWipDetailCall(3, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_wdr2 != 0)
			{
				wCalc[1] = vWhipDates.l_wdr2 + wCalc[2];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[2], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(2, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[1] = vWhipDates.l_wdr2 + wCalc[2];

				var updateResult = await UpdateWipDetailCall(2, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			if (vWhipDates.l_dwdr1 != 0)
			{
				wCalc[0] = vWhipDates.l_dwdr1 + wCalc[1];
				var vWdr = CalulateBusinessDay.PromiseDate(dpCustomerServiceDate.Value, ((int)Math.Round(wCalc[1], MidpointRounding.ToEven)));
				var updateResult = await UpdateWipDetailCall(1, vWdr, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}
			else
			{
				wCalc[0] = vWhipDates.l_dwdr1 + wCalc[1];

				var updateResult = await UpdateWipDetailCall(1, null, lblInvno.Text);
				if (updateResult.IsError)
				{
					MessageBox.Show("Datbase error. #1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					processingResult.IsError = true;
					return processingResult;
				}
			}

			this.Fill();
			processingResult.IsError = false;
			return processingResult;

		}
		private void dpCustomerServiceDate_Leave(object sender, EventArgs e)
		{
			WipUpdate();
		}

		private void laminatedTextBox_Leave(object sender, EventArgs e)
		{
			if (laminatedTextBox.Text != "M" && laminatedTextBox.Text != "N" && laminatedTextBox.Text != "G"&& laminatedTextBox.Text != "")
			{
				laminatedTextBox.Focus();
			}
		}

		private void txtSchNamesrch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				btnSchoolSearch_Click(sender, null);
			}
			
		}

		private void btnInvoiceSrch_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtSchCode.Text.Trim()))
			{
				return;
			}

			//var records = this.custTableAdapter.FillBySchname(this.dsCust.cust,txtSchNamesrch.Text);
			var sqlQuery = new SQLQuery();
			var queryString = @"SELECT P.ProdNo,P.Invno, C.Schcode, C.Schname,C.Schcity,C.Schstate,C.Schzip 
							 FROM Cust C
								Left Join Quotes Q ON C.Schcode=Q.Schcode
								Left Join Produtn P On Q.Invno=P.Invno
                              WHERE P.Invno IS NOT NULL AND (C.Schcode LIKE @Schcode + '%')
                              ORDER BY Schname,Invno";
			SqlParameter[] parameters = new SqlParameter[] {
			   new SqlParameter("@Schcode",txtSchCode.Text.Trim())
			};
			var dataResult = sqlQuery.ExecuteReaderAsync<ProdutnSchoolNameSearchModel>(CommandType.Text, queryString, parameters);
			var records = (List<ProdutnSchoolNameSearchModel>)dataResult;
			if (records == null || records.Count < 1)
			{


				MessageBox.Show("No Records were found with this criteria.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else if (records.Count >= 1)
			{

				//more than one record select which one you want

				this.Cursor = Cursors.AppStarting;

				frmProdutnSelctCust frmProdutnSelectCust = new frmProdutnSelctCust(records);
				DialogResult result = frmProdutnSelectCust.ShowDialog();
				this.Cursor = Cursors.Default;
				if (result != DialogResult.Cancel)
				{
					if (frmProdutnSelectCust.retval == 0)
					{
						return;
					}
					this.Invno = frmProdutnSelectCust.retval;
					this.Fill();
				}

			}
			txtSchNamesrch.Text = "";
			frmProdutn_Paint(this, null);

		}

		private void txtSchCode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				btnInvoiceSrch_Click(sender, null);
			}
		}




		#endregion

		//nothing below here  
	}
	public class BinderyInfo
	{
		public string Schname { get; set; }
		public string CoverType { get; set; }
		public string ProdNo { get; set; }
		public int NoPages { get; set; }
		public int NoCopies { get; set; }
		public bool Diecut { get; set; }
		public string CoilClr { get; set; }
		public DateTime ProjShpDate { get; set; }
	}
}


