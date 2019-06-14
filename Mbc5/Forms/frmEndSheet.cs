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
using BaseClass.Core;
using BaseClass;
namespace Mbc5.Forms
{
	public partial class frmEndSheet : BaseClass.frmBase, INotifyPropertyChanged
	{
		

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
			
		
		}
		#region Properties
		public void InvokePropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, e);
		}
		private UserPrincipal ApplicationUser { get; set; }
        private frmMain frmMain { get; set; }
        #endregion
        private void SetConnectionString()
        {
            frmMain frmMain = (frmMain)this.MdiParent;
            this.custTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.quotesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.bannerTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.produtnTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.endsheetdetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.endsheetTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.suppdetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.preflitTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
        }
        private void frmEndSheet_Load(object sender, EventArgs e)
		{
            this.frmMain = (frmMain)this.MdiParent;

            this.SetConnectionString();
            Fill();
		}


		#region Methods

		public override ApiProcessingResult<bool> Save()
		{
			var processingResult = new ApiProcessingResult<bool>();
			switch (tbEndSheets.SelectedIndex)
			{
				case 0:
                 
                    var endSheetResult=SaveEndSheet();
					if (endSheetResult.IsError) {
						MbcMessageBox.Error(endSheetResult.Errors[0].ErrorMessage, "");
						processingResult.IsError = true;
					} else {
                      
						MbcMessageBox.Exclamation("End sheet saved.", "Success");
                       
					}

					break;
				case 1:
					{
						var supplementResult = SaveSupplement();
						if (supplementResult.IsError) {
							MbcMessageBox.Error(supplementResult.Errors[0].ErrorMessage, "");
							processingResult.IsError = true;
						} else {
							MbcMessageBox.Exclamation("Supplement saved.", "Success");
						}
						
						break;
					}
				case 2:
					{
						var preFlightResult = SavePreFlight();
						if (preFlightResult.IsError) {
							MbcMessageBox.Error(preFlightResult.Errors[0].ErrorMessage, "");
							processingResult.IsError = true;
						} else {
							MbcMessageBox.Exclamation("PreFlight saved.", "Success");
						}
						
						break;
					}
				case 3:
					{
						var bannerResult = SaveBanner();
						if (bannerResult.IsError) {
							MbcMessageBox.Error(bannerResult.Errors[0].ErrorMessage, "");
							processingResult.IsError = true;
						} else {
							MbcMessageBox.Exclamation("Banner saved.", "Success");
						}
					
						break;
					}
			}
			return processingResult;
		}
		private bool SaveOrStop()
		{
			bool retval = true;
			switch (tbEndSheets.SelectedIndex)
			{
				case 0:
					var result = SaveEndSheet();
					if (result.IsError)
					{
						var dialogResult = MessageBox.Show("End Sheet record could not be saved:"+ result.Errors[0].ErrorMessage+" Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (dialogResult == DialogResult.No)
						{
							retval = false;

						}
					}
					break;

				case 1:
					var supplementResult = SaveSupplement();
					if (supplementResult.IsError)
					{
						var dialogResult1 = MessageBox.Show("Supplement record could not be saved:" + supplementResult.Errors[0].ErrorMessage + " Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (dialogResult1 == DialogResult.No)
						{
							retval = false;
						}
					}
					break;

				case 2:
					var bannerResult = SaveBanner();
					if (bannerResult.IsError)
					{
						var dialogResult2 = MessageBox.Show("Banner record could not be saved:" + bannerResult.Errors[0].ErrorMessage + " Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (dialogResult2 == DialogResult.No)
						{
							retval = false; ;
						}
					}
					break;
			}

			return retval;

		}
		public ApiProcessingResult<bool> SaveBanner()
		{
			var processingResult = new ApiProcessingResult<bool>();
			if (dsEndSheet.banner.Count > 0)
			{
				if (this.ValidateChildren(ValidationConstraints.Enabled))
				{
					try
					{
						this.bannerBindingSource.EndEdit();
						var a = bannerTableAdapter.Update(dsEndSheet.banner);
						//must refill so we get updated time stamp so concurrency is not thrown
						bannerTableAdapter.Fill(dsEndSheet.banner, Invno);
						
					}
					catch (Exception ex)
					{
						
						ex.ToExceptionless()
					   .SetMessage("Banner record failed to update:" + ex.Message)
					   .Submit();
						processingResult.IsError = true;
						processingResult.Errors.Add(new ApiProcessingError("Banner record failed to update:" + ex.Message, "Banner record failed to update:" + ex.Message, ""));
					}
				}
			}
			return processingResult;
		}
		public ApiProcessingResult<bool> SaveSupplement()
		{
			var processingResult = new ApiProcessingResult<bool>();
			if (dsEndSheet.suppl.Count > 0)
			{
				if (this.ValidateChildren(ValidationConstraints.Enabled))
				{
					try
					{
						this.supplBindingSource.EndEdit();
						var a = supplTableAdapter.Update(dsEndSheet.suppl);
						//must refill so we get updated time stamp so concurrency is not thrown
						supplTableAdapter.FillByInvno(dsEndSheet.suppl,Invno);
						
					}
					catch (Exception ex)
					{
						
						ex.ToExceptionless()
					   .SetMessage("Supplement record failed to update:" + ex.Message)
					   .Submit();
						processingResult.IsError = true;
						processingResult.Errors.Add(new ApiProcessingError("Supplement record failed to update:" + ex.Message, "Supplement record failed to update:" + ex.Message, ""));
					}
				}
			}
			return processingResult;
		}
		public ApiProcessingResult<bool> SaveEndSheet()
		{
			var processingResult = new ApiProcessingResult<bool>();
	
			if (dsEndSheet.endsheet.Count > 0)
			{
				if (this.ValidateChildren(ValidationConstraints.Enabled))
				{
					try
					{
						this.endsheetBindingSource.EndEdit();
						var a = endsheetTableAdapter.Update(dsEndSheet.endsheet);
						//must refill so we get updated time stamp so concurrency is not thrown
						
                        try
                        {
                            this.produtnBindingSource.EndEdit();
                            var b = produtnTableAdapter.Update(dsEndSheet.produtn);
                            //must refill so we get updated time stamp so concurrency is not thrown
                            
                        }catch(Exception ex)
                        {
                            ex.ToExceptionless()
                       .SetMessage("EndSheet record failed to update:" + ex.Message)
                       .Submit();
                            processingResult.IsError = true;
                            processingResult.Errors.Add(new ApiProcessingError("Production record failed to update: " + ex.Message, "Production record failed to update: " + ex.Message, ""));
                        }
                        endsheetTableAdapter.Fill(dsEndSheet.endsheet, Invno);
                        produtnTableAdapter.Fill(dsEndSheet.produtn, Invno);
                    }
					catch (Exception ex)
					{
								
						ex.ToExceptionless()
					   .SetMessage("EndSheet record failed to update:" + ex.Message)
					   .Submit();
						processingResult.IsError = true;
						processingResult.Errors.Add(new ApiProcessingError("EndSheet record failed to update: " + ex.Message,"EndSheet record failed to update: " + ex.Message,""));
					}
				}
			}
			return processingResult;
		}
		public ApiProcessingResult<bool> SavePreFlight()
		{
			var processingResult = new ApiProcessingResult<bool>();
		
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
					
					}
					catch (Exception ex)
					{
					
						
						ex.ToExceptionless()
					   .SetMessage("PreFlight record failed to update:" + ex.Message)
					   .Submit();
						processingResult.IsError = true;
						processingResult.Errors.Add(new ApiProcessingError("PreFlight record failed to update:" + ex.Message, "PreFlight record failed to update:" + ex.Message, ""));
					}
				}
			}
			return processingResult;
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
                try
                {
                    custTableAdapter.Fill(dsEndSheet.cust, Schcode);
                    quotesTableAdapter.Fill(dsEndSheet.quotes, Invno);
                    produtnTableAdapter.Fill(dsEndSheet.produtn, Invno);
                    endsheetTableAdapter.Fill(dsEndSheet.endsheet, Invno);
                    supplTableAdapter.FillByInvno(dsEndSheet.suppl, Invno);

                    preflitTableAdapter.FillByInvno(dsEndSheet.preflit, Invno);
                    bannerTableAdapter.Fill(dsEndSheet.banner, Invno);

                    if (dsEndSheet.cust.Count < 1)
                    {
                        //disable all tabs
                        DisableControls(this.tbEndSheets.TabPages[0]);
                        DisableControls(this.tbEndSheets.TabPages[1]);
                        DisableControls(this.tbEndSheets.TabPages[2]);
                        foreach (TabPage tab in tbEndSheets.TabPages)
                        {
                            DisableControls(tab);
                        }
                        
                    }


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
                        
                    }

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
                        
                    }
                    else { EnableAllControls(this); }


                    if (dsEndSheet.endsheet.Count < 1)
                    {
                        DisableControls(this.tbEndSheets.TabPages[0]);

                    }
                    else { EnableAllControls(this.tbEndSheets.TabPages[0]); }


                    if (dsEndSheet.suppl.Count < 1)
                    {
                        DisableControls(this.tbEndSheets.TabPages[1]);
                    }
                    else { EnableAllControls(this.tbEndSheets.TabPages[1]); }


                    if (dsEndSheet.preflit.Count < 1)
                    {
                        DisableControls(this.tbEndSheets.TabPages[2]);
                    }
                    else { EnableAllControls(this.tbEndSheets.TabPages[2]); }



                    if (dsEndSheet.banner.Count < 1)
                    {
                        DisableControls(this.tbEndSheets.TabPages[3]);
                    }
                    else { EnableAllControls(this.tbEndSheets.TabPages[3]); }


                }
                catch (Exception ex)
                {

                    MbcMessageBox.Error(ex.Message, "");

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
			predateDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void recvdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			recvdteDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void duedateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			duedateDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void iinDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			iinDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void ioutDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			ioutDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void binddteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			binddteDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void frmbindDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			frmbindDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void rmbtoDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			rmbtoDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void remaketypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void rmbfrmDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			rmbfrmDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void csonholdDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			csonholdDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void csoffholdDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			csoffholdDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void endstrecvDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			endstrecvDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void prtdtesentDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			prtdtesentDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void lamdtesentDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			lamdtesentDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void dcdtesentDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			dcdtesentDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void otdtesentDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			otdtesentDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void prtdtebkDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			prtdtebkDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void lamdtebkDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			lamdtebkDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void dcdtebkDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			dcdtebkDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void otdtebkDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			otdtebkDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void prntsamDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			prntsamDateTimePicker.Format = DateTimePickerFormat.Short;
		}


		private void reprntdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			reprntdteDateTimePicker.Format = DateTimePickerFormat.Short;
		}
		private void desorgdteDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			desorgdteDateTimePicker.Format = DateTimePickerFormat.Short;
		}





		#endregion

		private void tbEndSheets_Deselecting(object sender, TabControlCancelEventArgs e)
		{

		}

		private void frmEndSheet_FormClosing(object sender, FormClosingEventArgs e)
		{

		}

        private void frmEndSheet_Shown(object sender, EventArgs e)
        {
            tbEndSheets.Visible = true;
        }

        private void frmEndSheet_Activated(object sender, EventArgs e)
        {
            frmMain.ShowSearchButtons(this.Name);
        }

        private void frmEndSheet_Deactivate(object sender, EventArgs e)
        {
            frmMain.HideSearchButtons();
        }
        public override void SchCodeSearch()      
        {
            var saveResult = this.Save();
            if (saveResult.IsError)
            {

                return;
            }
            DataRowView currentrow = (DataRowView)custBindingSource.Current;
            var schcode = currentrow["schcode"].ToString();

            frmSearch frmSearch = new frmSearch("Schcode", "ENDSHEET", schcode);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    this.Invno = frmSearch.ReturnValue.Invno;
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }
                    this.Fill();

                    EnableAllControls(this);

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }


                this.Cursor = Cursors.Default;
            }



        }
        public override void SchnameSearch()
        {
            var saveResult = this.Save();
            if (saveResult.IsError)
            {

                return;
            }
            DataRowView currentrow = (DataRowView)custBindingSource.Current;
            var schname = currentrow["schname"].ToString();

            frmSearch frmSearch = new frmSearch("Schname", "ENDSHEET", schname);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    this.Invno = frmSearch.ReturnValue.Invno;
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }
                    this.Fill();
                    
                    EnableAllControls(this);

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }

                
                this.Cursor = Cursors.Default;
            }



        }
        public override void OracleCodeSearch()
        {
            var saveResult = this.Save();
            if (saveResult.IsError)
            {

                return;
            }
            DataRowView currentrow = (DataRowView)custBindingSource.Current;
            var oraclecode = currentrow["oraclecode"].ToString();

            frmSearch frmSearch = new frmSearch("OracleCode", "ENDSHEET", oraclecode);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    this.Invno = frmSearch.ReturnValue.Invno;
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }
                    this.Fill();
                   
                    EnableAllControls(this);

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
             
                this.Cursor = Cursors.Default;
            }
        }
        public override void InvoiceNumberSearch()
        {
            DataRowView currentrow = (DataRowView)endsheetBindingSource.Current;
            var invno = currentrow["invno"].ToString();
            var saveResult = this.Save();
            if (saveResult.IsError)
            {

                return;
            }
            

            frmSearch frmSearch = new frmSearch("INVNO", "ENDSHEET", invno);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    this.Invno = frmSearch.ReturnValue.Invno;
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }
                    this.Fill();
                   
                    EnableAllControls(this);

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
               this.Cursor = Cursors.Default;
            }
        }
        public override void JobNoSearch()
        {

            var saveResult = this.Save();
            if (saveResult.IsError)
            {

                return;
            }

            DataRowView currentrow = (DataRowView)endsheetBindingSource.Current;
            var invno = currentrow["invno"].ToString();


            frmSearch frmSearch = new frmSearch("JOBNO", "ENDSHEET", "");



            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    this.Invno = frmSearch.ReturnValue.Invno;
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }

                    this.Fill();
                  
                    EnableAllControls(this);

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                
                this.Cursor = Cursors.Default;
            }



            }

       



        //nothing below
    }
}
