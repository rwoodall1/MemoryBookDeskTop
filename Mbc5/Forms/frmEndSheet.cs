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
using System.Threading.Tasks;
namespace Mbc5.Forms { 

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
            bannerdetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
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
						this.bannerBindingSource1.EndEdit();
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
                    endsheetdetailTableAdapter.Fill(dsEndSheet.endsheetdetail, Invno);
                  
                    supplTableAdapter.FillByInvno(dsEndSheet.suppl, Invno);
                    suppdetailTableAdapter.Fill(dsEndSheet.suppdetail, Invno);
                    preflitTableAdapter.FillByInvno(dsEndSheet.preflit, Invno);
                    bannerTableAdapter.Fill(dsEndSheet.banner, Invno);
                    bannerdetailTableAdapter.Fill(dsEndSheet.bannerdetail, Invno);
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
                        EnableControls(btnAddEndSheetRecord);

                    }
                    else {
                        EnableAllControls(this.tbEndSheets.TabPages[0]);
                        btnAddEndSheetRecord.Visible = false;
                    }


                    if (dsEndSheet.suppl.Count < 1)
                    {
                        DisableControls(this.tbEndSheets.TabPages[1]);
                         EnableControls(btnAddSupp);
                       
                    }
                    else {
                        EnableAllControls(this.tbEndSheets.TabPages[1]);
                        btnAddSupp.Visible = false;
                    }


                    if (dsEndSheet.preflit.Count < 1)
                    {
                        DisableControls(this.tbEndSheets.TabPages[2]);
                    }
                    else { EnableAllControls(this.tbEndSheets.TabPages[2]); }



                    if (dsEndSheet.banner.Count < 1)
                    {
                        DisableControls(this.tbEndSheets.TabPages[3]);
                        EnableControls(btnAddBanner);
                    }
                    else {
                        EnableAllControls(this.tbEndSheets.TabPages[3]);
                        btnAddBanner.Visible = false;
                    }


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
        private void frmEndSheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            //set KeyPriview to True first.
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.KeyChar = (char)Keys.Tab;
                SendKeys.Send(e.KeyChar.ToString());//send the keystroke to the form.
            }

            //if ((e.KeyChar == '\r'))
            //{
            //    e.KeyChar = '\t';
            //    SendKeys.Send(e.KeyChar.ToString());
            //}


        }
        private void btnAddEndSheetRecord_Click(object sender, EventArgs e)
        {
            var codeResult =  GetSupCode();
            if (codeResult.Result.IsError)
            {
                MbcMessageBox.Error("Failed to get end sheet number:" + codeResult.Result.Errors[0].ErrorMessage);
                return;
            }
            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"Insert Into EndSheet(Invno,Schcode,EndshtNo) Values(@Invno,@Schcode,@EndshtNo)");
            sqlQuery.AddParameter("@Invno",Invno);
            sqlQuery.AddParameter("@Schcode",Schcode);
            sqlQuery.AddParameter("@EndshtNo", codeResult.Result.Data);
            var insertResult= sqlQuery.Insert();
            if (insertResult.IsError)
            {
                MbcMessageBox.Error(insertResult.Errors[0].ErrorMessage);
                return;
            }
            Fill();
        }
        private async Task<ApiProcessingResult<int>> GetSupCode()
        {
            var processingResult = new ApiProcessingResult<int>();
            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"Select supcode from codecnt");
            var result = sqlQuery.SelectSingleColumn();
            if (result.IsError)
            {
                processingResult.IsError = true;
                processingResult.Errors = result.Errors;
                return processingResult;
            }
            int vCode = 0;
            if(int.TryParse(result.Data, out vCode))
            {
                processingResult.Data = vCode;
             
            }
            else
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to convert end sheet number to integer", "Failed to convert end sheet number to integer", ""));
                return processingResult;
            }
            sqlQuery.ClearParameters();
            sqlQuery.CommandText(@"Update codecnt Set supcode=@supcode");
            sqlQuery.AddParameter("@supcode", vCode + 1);
           var updateResult= sqlQuery.Update();
            if (updateResult.IsError)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to update CodeCnt Table.", "Failed to update CodeCnt Table.", ""));
                return processingResult;
            }

            return processingResult;
        }
       
        private void btnUpdateDates_Click(object sender, EventArgs e)
        {
           var result= UpdateEndsheetDates();
            if (result.Result.IsError)
            {
                MbcMessageBox.Error("Failed to update endsheet dates:" + result.Result.Errors[0].ErrorMessage);
            }
        }
        private async Task<ApiProcessingResult> UpdateEndsheetDates()
        {


            var processingResult = new ApiProcessingResult();

            var endSheetResult =SaveEndSheet();

            if (endSheetResult.IsError)
            {

                processingResult.IsError = true;
                processingResult.Errors = endSheetResult.Errors;
                return processingResult;
            }
            if (endstrecvDateBox.Date == null)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Recieved date is empty.", "Recieved date is empty.", ""));
                return processingResult;
            }
           

            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"Select * From EndSheetDat");
           
            var result = sqlQuery.Select<EndSheetDat>();
            if (result.IsError)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve EndSheet Dat,EndSheet update failed:" + result.Errors[0].ErrorMessage, "Failed to retrieve EndSheet,EndSheet update failed:" + result.Errors[0].ErrorMessage, ""));
                return processingResult;
            }

            var vDats = (EndSheetDat)result.Data;
            if (vDats == null)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve to find EndSheet update Dats.", "Failed to retrieve to find EndSheet update Dats.", ""));
                return processingResult;
            }
            int[] wCalc = new int[51];//0 based used 51 so I could keep element in line with line numbers 1=1 instead of 0=1
                                      //---------------------------------------------------------------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_1 != 0)
            {
                wCalc[1] = vDats.LWdr_1;
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[1]);
                var updateResult = await UpdateEndSheetDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[1] = vDats.LWdr_1;

                var updateResult = await UpdateEndSheetDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_2 != 0)
            {
                wCalc[2] = vDats.LWdr_2 + wCalc[1];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[2]);
                var updateResult = await UpdateEndSheetDetailCall(2, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[2] = vDats.LWdr_2 + wCalc[1];

                var updateResult = await UpdateEndSheetDetailCall(2, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_3 != 0)
            {
                wCalc[3] = vDats.LWdr_3 + wCalc[2];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[3]);
                var updateResult = await UpdateEndSheetDetailCall(3, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[3] = vDats.LWdr_3 + wCalc[2];

                var updateResult = await UpdateEndSheetDetailCall(3, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #3", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_4 != 0)
            {
                wCalc[4] = vDats.LWdr_4 + wCalc[3];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[4]);
                var updateResult = await UpdateEndSheetDetailCall(4, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[4] = vDats.LWdr_4 + wCalc[3];

                var updateResult = await UpdateEndSheetDetailCall(4, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_5 != 0)
            {
                wCalc[5] = vDats.LWdr_5 + wCalc[4];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[5]);
                var updateResult = await UpdateEndSheetDetailCall(5, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[5] = vDats.LWdr_5 + wCalc[4];

                var updateResult = await UpdateEndSheetDetailCall(5, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_6 != 0)
            {
                wCalc[6] = vDats.LWdr_6 + wCalc[5];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[6]);
                var updateResult = await UpdateEndSheetDetailCall(6, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[6] = vDats.LWdr_6 + wCalc[5];

                var updateResult = await UpdateEndSheetDetailCall(6, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_7 != 0)
            {
                wCalc[7] = vDats.LWdr_7 + wCalc[6];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[7]);
                var updateResult = await UpdateEndSheetDetailCall(7, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[7] = vDats.LWdr_7 + wCalc[6];

                var updateResult = await UpdateEndSheetDetailCall(7, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_8 != 0)
            {
                wCalc[8] = vDats.LWdr_8 + wCalc[7];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[8]);
                var updateResult = await UpdateEndSheetDetailCall(8, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[8] = vDats.LWdr_8 + wCalc[7];

                var updateResult = await UpdateEndSheetDetailCall(8, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_9 != 0)
            {
                wCalc[9] = vDats.LWdr_9 + wCalc[8];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[9]);
                var updateResult = await UpdateEndSheetDetailCall(9, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[9] = vDats.LWdr_9 + wCalc[8];

                var updateResult = await UpdateEndSheetDetailCall(9, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_10 != 0)
            {
                wCalc[10] = vDats.LWdr_10 + wCalc[9];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[10]);
                var updateResult = await UpdateEndSheetDetailCall(10, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[10] = vDats.LWdr_10 + wCalc[9];

                var updateResult = await UpdateEndSheetDetailCall(10, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_11 != 0)
            {
                wCalc[11] = vDats.LWdr_11 + wCalc[10];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[11]);
                var updateResult = await UpdateEndSheetDetailCall(11, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[11] = vDats.LWdr_11 + wCalc[10];

                var updateResult = await UpdateEndSheetDetailCall(11, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_12 != 0)
            {
                wCalc[12] = vDats.LWdr_12 + wCalc[11];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[12]);
                var updateResult = await UpdateEndSheetDetailCall(12, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[12] = vDats.LWdr_12 + wCalc[11];

                var updateResult = await UpdateEndSheetDetailCall(12, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_13 != 0)
            {
                wCalc[13] = vDats.LWdr_13 + wCalc[12];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[13]);
                var updateResult = await UpdateEndSheetDetailCall(13, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[13] = vDats.LWdr_13 + wCalc[12];

                var updateResult = await UpdateEndSheetDetailCall(13, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_14 != 0)
            {
                wCalc[14] = vDats.LWdr_14 + wCalc[13];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[14]);
                var updateResult = await UpdateEndSheetDetailCall(14, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[14] = vDats.LWdr_14 + wCalc[13];

                var updateResult = await UpdateEndSheetDetailCall(14, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_15 != 0)
            {
                wCalc[15] = vDats.LWdr_15 + wCalc[14];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[15]);
                var updateResult = await UpdateEndSheetDetailCall(15, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[15] = vDats.LWdr_15 + wCalc[14];

                var updateResult = await UpdateEndSheetDetailCall(15, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_16 != 0)
            {
                wCalc[16] = vDats.LWdr_16 + wCalc[15];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[16]);
                var updateResult = await UpdateEndSheetDetailCall(16, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[16] = vDats.LWdr_16 + wCalc[15];

                var updateResult = await UpdateEndSheetDetailCall(16, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_17 != 0)
            {
                wCalc[17] = vDats.LWdr_17 + wCalc[16];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[17]);
                var updateResult = await UpdateEndSheetDetailCall(17, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[17] = vDats.LWdr_17 + wCalc[16];

                var updateResult = await UpdateEndSheetDetailCall(17, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_18 != 0)
            {
                wCalc[18] = vDats.LWdr_18 + wCalc[17];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[18]);
                var updateResult = await UpdateEndSheetDetailCall(18, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[18] = vDats.LWdr_18 + wCalc[17];

                var updateResult = await UpdateEndSheetDetailCall(18, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_19 != 0)
            {
                wCalc[19] = vDats.LWdr_19 + wCalc[18];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[19]);
                var updateResult = await UpdateEndSheetDetailCall(19, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[19] = vDats.LWdr_19 + wCalc[18];

                var updateResult = await UpdateEndSheetDetailCall(19, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_20 != 0)
            {
                wCalc[20] = vDats.LWdr_20 + wCalc[19];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[20]);
                var updateResult = await UpdateEndSheetDetailCall(20, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[20] = vDats.LWdr_20 + wCalc[19];

                var updateResult = await UpdateEndSheetDetailCall(20, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_21 != 0)
            {
                wCalc[21] = vDats.LWdr_21 + wCalc[20];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[21]);
                var updateResult = await UpdateEndSheetDetailCall(21, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[21] = vDats.LWdr_21 + wCalc[20];

                var updateResult = await UpdateEndSheetDetailCall(21, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_22 != 0)
            {
                wCalc[22] = vDats.LWdr_22 + wCalc[21];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[22]);
                var updateResult = await UpdateEndSheetDetailCall(22, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[22] = vDats.LWdr_22 + wCalc[21];

                var updateResult = await UpdateEndSheetDetailCall(22, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_23 != 0)
            {
                wCalc[23] = vDats.LWdr_23 + wCalc[22];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[23]);
                var updateResult = await UpdateEndSheetDetailCall(23, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[23] = vDats.LWdr_23 + wCalc[22];

                var updateResult = await UpdateEndSheetDetailCall(23, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_24 != 0)
            {
                wCalc[24] = vDats.LWdr_24 + wCalc[23];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[24]);
                var updateResult = await UpdateEndSheetDetailCall(24, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[24] = vDats.LWdr_24 + wCalc[23];

                var updateResult = await UpdateEndSheetDetailCall(24, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_25 != 0)
            {
                wCalc[25] = vDats.LWdr_25 + wCalc[24];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[25]);
                var updateResult = await UpdateEndSheetDetailCall(25, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[25] = vDats.LWdr_25 + wCalc[24];

                var updateResult = await UpdateEndSheetDetailCall(25, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_26 != 0)
            {
                wCalc[26] = vDats.LWdr_26 + wCalc[25];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[26]);
                var updateResult = await UpdateEndSheetDetailCall(26, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[26] = vDats.LWdr_26 + wCalc[25];

                var updateResult = await UpdateEndSheetDetailCall(26, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_27 != 0)
            {
                wCalc[27] = vDats.LWdr_27 + wCalc[26];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[27]);
                var updateResult = await UpdateEndSheetDetailCall(27, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[27] = vDats.LWdr_27 + wCalc[26];

                var updateResult = await UpdateEndSheetDetailCall(27, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_28 != 0)
            {
                wCalc[28] = vDats.LWdr_28 + wCalc[27];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[28]);
                var updateResult = await UpdateEndSheetDetailCall(28, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[28] = vDats.LWdr_28 + wCalc[27];

                var updateResult = await UpdateEndSheetDetailCall(28, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_29 != 0)
            {
                wCalc[29] = vDats.LWdr_29 + wCalc[28];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[29]);
                var updateResult = await UpdateEndSheetDetailCall(29, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[29] = vDats.LWdr_29 + wCalc[28];

                var updateResult = await UpdateEndSheetDetailCall(29, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_30 != 0)
            {
                wCalc[30] = vDats.LWdr_30 + wCalc[29];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[30]);
                var updateResult = await UpdateEndSheetDetailCall(30, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[30] = vDats.LWdr_30 + wCalc[29];

                var updateResult = await UpdateEndSheetDetailCall(30, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_31 != 0)
            {
                wCalc[31] = vDats.LWdr_31 + wCalc[30];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[31]);
                var updateResult = await UpdateEndSheetDetailCall(31, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[31] = vDats.LWdr_31 + wCalc[30];

                var updateResult = await UpdateEndSheetDetailCall(31, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_32 != 0)
            {
                wCalc[32] = vDats.LWdr_32 + wCalc[31];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)endstrecvDateBox.DateValue, wCalc[32]);
                var updateResult = await UpdateEndSheetDetailCall(32, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[32] = vDats.LWdr_32 + wCalc[31];

                var updateResult = await UpdateEndSheetDetailCall(32, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_33 != 0)
            {
                wCalc[33] = vDats.LWdr_33 + wCalc[32];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[33]);
                var updateResult = await UpdateEndSheetDetailCall(33, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[33] = vDats.LWdr_33 + wCalc[32];

                var updateResult = await UpdateEndSheetDetailCall(33, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_34 != 0)
            {
                wCalc[34] = vDats.LWdr_34 + wCalc[33];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[34]);
                var updateResult = await UpdateEndSheetDetailCall(34, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[34] = vDats.LWdr_34 + wCalc[33];

                var updateResult = await UpdateEndSheetDetailCall(34, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_35 != 0)
            {
                wCalc[35] = vDats.LWdr_35 + wCalc[34];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[35]);
                var updateResult = await UpdateEndSheetDetailCall(35, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[35] = vDats.LWdr_35 + wCalc[34];

                var updateResult = await UpdateEndSheetDetailCall(35, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_36 != 0)
            {
                wCalc[36] = vDats.LWdr_36 + wCalc[35];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[36]);
                var updateResult = await UpdateEndSheetDetailCall(36, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[36] = vDats.LWdr_36 + wCalc[35];

                var updateResult = await UpdateEndSheetDetailCall(36, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_37 != 0)
            {
                wCalc[37] = vDats.LWdr_37 + wCalc[36];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[37]);
                var updateResult = await UpdateEndSheetDetailCall(37, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[37] = vDats.LWdr_37 + wCalc[36];

                var updateResult = await UpdateEndSheetDetailCall(37, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_38 != 0)
            {
                wCalc[38] = vDats.LWdr_38 + wCalc[37];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[38]);
                var updateResult = await UpdateEndSheetDetailCall(38, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[38] = vDats.LWdr_38 + wCalc[37];

                var updateResult = await UpdateEndSheetDetailCall(38, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_39 != 0)
            {
                wCalc[39] = vDats.LWdr_39 + wCalc[38];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[39]);
                var updateResult = await UpdateEndSheetDetailCall(39, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[39] = vDats.LWdr_39 + wCalc[38];

                var updateResult = await UpdateEndSheetDetailCall(39, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_40 != 0)
            {
                wCalc[40] = vDats.LWdr_40 + wCalc[39];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[40]);
                var updateResult = await UpdateEndSheetDetailCall(40, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[40] = vDats.LWdr_40 + wCalc[39];

                var updateResult = await UpdateEndSheetDetailCall(40, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_41 != 0)
            {
                wCalc[41] = vDats.LWdr_41 + wCalc[40];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[41]);
                var updateResult = await UpdateEndSheetDetailCall(41, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[41] = vDats.LWdr_41 + wCalc[40];

                var updateResult = await UpdateEndSheetDetailCall(41, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_42 != 0)
            {
                wCalc[42] = vDats.LWdr_42 + wCalc[41];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[42]);
                var updateResult = await UpdateEndSheetDetailCall(42, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[42] = vDats.LWdr_42 + wCalc[41];

                var updateResult = await UpdateEndSheetDetailCall(42, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_43 != 0)
            {
                wCalc[43] = vDats.LWdr_43 + wCalc[42];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[43]);
                var updateResult = await UpdateEndSheetDetailCall(43, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[43] = vDats.LWdr_43 + wCalc[42];

                var updateResult = await UpdateEndSheetDetailCall(43, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_44 != 0)
            {
                wCalc[44] = vDats.LWdr_44 + wCalc[43];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[44]);
                var updateResult = await UpdateEndSheetDetailCall(44, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[44] = vDats.LWdr_44 + wCalc[43];

                var updateResult = await UpdateEndSheetDetailCall(44, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }


            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_45 != 0)
            {
                wCalc[45] = vDats.LWdr_45 + wCalc[44];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[45]);
                var updateResult = await UpdateEndSheetDetailCall(45, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[45] = vDats.LWdr_45 + wCalc[44];

                var updateResult = await UpdateEndSheetDetailCall(45, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_46 != 0)
            {
                wCalc[46] = vDats.LWdr_46 + wCalc[45];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[46]);
                var updateResult = await UpdateEndSheetDetailCall(46, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[46] = vDats.LWdr_46 + wCalc[45];

                var updateResult = await UpdateEndSheetDetailCall(46, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_47 != 0)
            {
                wCalc[47] = vDats.LWdr_47 + wCalc[46];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[47]);
                var updateResult = await UpdateEndSheetDetailCall(47, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[47] = vDats.LWdr_47 + wCalc[46];

                var updateResult = await UpdateEndSheetDetailCall(47, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_48 != 0)
            {
                wCalc[48] = vDats.LWdr_48 + wCalc[47];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[48]);
                var updateResult = await UpdateEndSheetDetailCall(48, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[48] = vDats.LWdr_48 + wCalc[47];

                var updateResult = await UpdateEndSheetDetailCall(48, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_49 != 0)
            {
                wCalc[49] = vDats.LWdr_49 + wCalc[48];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[49]);
                var updateResult = await UpdateEndSheetDetailCall(49, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[49] = vDats.LWdr_49 + wCalc[48];

                var updateResult = await UpdateEndSheetDetailCall(49, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_50 != 0)
            {
                wCalc[50] = vDats.LWdr_50 + wCalc[49];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[50]);
                var updateResult = await UpdateEndSheetDetailCall(50, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[50] = vDats.LWdr_50 + wCalc[49];

                var updateResult = await UpdateEndSheetDetailCall(50, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            try
            {
                endsheetdetailTableAdapter.Fill(dsEndSheet.endsheetdetail, Invno);
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .MarkAsCritical()
                    .AddObject(ex)
                    .Submit();

                MbcMessageBox.Error("Failed to refill endsheet detail dataset:" + ex.Message);
            }
            return processingResult;



        }
        public async Task<ApiProcessingResult<bool>> UpdateEndSheetDetailCall(int vDescripId, DateTime? vWdr, string vInvno)
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
                    IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from endSheetDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='EndSheet')) 
                        Begin
                        INSERT INTO endSheetDetail (DescripID,Invno,Wdr,Schcode) VALUES((SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='EndSheet'),@Invno,@wdr,@Schcode);
                        END
			        ELSE
				        BEGIN
					        UPDATE endSheetDetail SET wdr=@wdr  WHERE Invno=@Invno AND DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='EndSheet')
				        END ";
            }
            else
            {
                commandText = @"
					        UPDATE endSheetDetail SET wdr = @wdr  WHERE Invno = @Invno AND DescripID = (SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='EndSheet')
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
        private void btnAddSupp_Click(object sender, EventArgs e)
        {
            var codeResult = GetSupCode();
            if (codeResult.Result.IsError)
            {
                MbcMessageBox.Error("Failed to get supplement number:" + codeResult.Result.Errors[0].ErrorMessage);
                return;
            }
            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"Insert Into Suppl(Invno,Schcode,SupNo) Values(@Invno,@Schcode,@SupNo)");
            sqlQuery.AddParameter("@Invno", Invno);
            sqlQuery.AddParameter("@Schcode", Schcode);
            sqlQuery.AddParameter("@SupNo", codeResult.Result.Data);
            var insertResult = sqlQuery.Insert();
            if (insertResult.IsError)
            {
                MbcMessageBox.Error(insertResult.Errors[0].ErrorMessage);
                return;
            }
            Fill();
        }

        private void btnUpdateSuppDates_Click(object sender, EventArgs e)
        {
            var result = UpdateSupplementDates();
            if (result.Result.IsError)
            {
                MbcMessageBox.Error("Failed to update supplement dates:" + result.Result.Errors[0].ErrorMessage);
            }
        }
        private async Task<ApiProcessingResult> UpdateSupplementDates()
        {


            var processingResult = new ApiProcessingResult();

            var supplementResult = SaveSupplement();

            if (supplementResult.IsError)
            {

                processingResult.IsError = true;
                processingResult.Errors = supplementResult.Errors;
                return processingResult;
            }
            if (recvdteDateBox.Date == null)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Recieved date is empty.", "Recieved date is empty.", ""));
                return processingResult;
            }


            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"Select * From SupplementDat");

            var result = sqlQuery.Select<SupplementDat>();
            if (result.IsError)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve Supplement Dat,Supplement update failed:" + result.Errors[0].ErrorMessage, "Failed to retrieve Supplement,Supplement update failed:" + result.Errors[0].ErrorMessage, ""));
                return processingResult;
            }

            var vDats = (SupplementDat)result.Data;
            if (vDats == null)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve to find Supplement update Dats.", "Failed to retrieve to find Supplement update Dats.", ""));
                return processingResult;
            }
            int[] wCalc = new int[51];//0 based used 51 so I could keep element in line with line numbers 1=1 instead of 0=1
                                      //---------------------------------------------------------------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_1 != 0)
            {
                wCalc[1] = vDats.LWdr_1;
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[1]);
                var updateResult = await UpdateSupplementDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[1] = vDats.LWdr_1;

                var updateResult = await UpdateSupplementDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_2 != 0)
            {
                wCalc[2] = vDats.LWdr_2 + wCalc[1];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[2]);
                var updateResult = await UpdateSupplementDetailCall(2, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[2] = vDats.LWdr_2 + wCalc[1];

                var updateResult = await UpdateSupplementDetailCall(2, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_3 != 0)
            {
                wCalc[3] = vDats.LWdr_3 + wCalc[2];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[3]);
                var updateResult = await UpdateSupplementDetailCall(3, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[3] = vDats.LWdr_3 + wCalc[2];

                var updateResult = await UpdateSupplementDetailCall(3, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #3", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_4 != 0)
            {
                wCalc[4] = vDats.LWdr_4 + wCalc[3];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[4]);
                var updateResult = await UpdateSupplementDetailCall(4, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[4] = vDats.LWdr_4 + wCalc[3];

                var updateResult = await UpdateSupplementDetailCall(4, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_5 != 0)
            {
                wCalc[5] = vDats.LWdr_5 + wCalc[4];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[5]);
                var updateResult = await UpdateSupplementDetailCall(5, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[5] = vDats.LWdr_5 + wCalc[4];

                var updateResult = await UpdateSupplementDetailCall(5, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_6 != 0)
            {
                wCalc[6] = vDats.LWdr_6 + wCalc[5];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[6]);
                var updateResult = await UpdateSupplementDetailCall(6, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[6] = vDats.LWdr_6 + wCalc[5];

                var updateResult = await UpdateSupplementDetailCall(6, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_7 != 0)
            {
                wCalc[7] = vDats.LWdr_7 + wCalc[6];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[7]);
                var updateResult = await UpdateSupplementDetailCall(7, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[7] = vDats.LWdr_7 + wCalc[6];

                var updateResult = await UpdateSupplementDetailCall(7, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_8 != 0)
            {
                wCalc[8] = vDats.LWdr_8 + wCalc[7];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[8]);
                var updateResult = await UpdateSupplementDetailCall(8, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[8] = vDats.LWdr_8 + wCalc[7];

                var updateResult = await UpdateSupplementDetailCall(8, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_9 != 0)
            {
                wCalc[9] = vDats.LWdr_9 + wCalc[8];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[9]);
                var updateResult = await UpdateSupplementDetailCall(9, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[9] = vDats.LWdr_9 + wCalc[8];

                var updateResult = await UpdateSupplementDetailCall(9, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_10 != 0)
            {
                wCalc[10] = vDats.LWdr_10 + wCalc[9];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[10]);
                var updateResult = await UpdateSupplementDetailCall(10, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[10] = vDats.LWdr_10 + wCalc[9];

                var updateResult = await UpdateSupplementDetailCall(10, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_11 != 0)
            {
                wCalc[11] = vDats.LWdr_11 + wCalc[10];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[11]);
                var updateResult = await UpdateSupplementDetailCall(11, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[11] = vDats.LWdr_11 + wCalc[10];

                var updateResult = await UpdateSupplementDetailCall(11, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_12 != 0)
            {
                wCalc[12] = vDats.LWdr_12 + wCalc[11];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[12]);
                var updateResult = await UpdateSupplementDetailCall(12, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[12] = vDats.LWdr_12 + wCalc[11];

                var updateResult = await UpdateSupplementDetailCall(12, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_13 != 0)
            {
                wCalc[13] = vDats.LWdr_13 + wCalc[12];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[13]);
                var updateResult = await UpdateSupplementDetailCall(13, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[13] = vDats.LWdr_13 + wCalc[12];

                var updateResult = await UpdateSupplementDetailCall(13, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_14 != 0)
            {
                wCalc[14] = vDats.LWdr_14 + wCalc[13];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[14]);
                var updateResult = await UpdateSupplementDetailCall(14, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[14] = vDats.LWdr_14 + wCalc[13];

                var updateResult = await UpdateSupplementDetailCall(14, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_15 != 0)
            {
                wCalc[15] = vDats.LWdr_15 + wCalc[14];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[15]);
                var updateResult = await UpdateSupplementDetailCall(15, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[15] = vDats.LWdr_15 + wCalc[14];

                var updateResult = await UpdateSupplementDetailCall(15, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_16 != 0)
            {
                wCalc[16] = vDats.LWdr_16 + wCalc[15];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[16]);
                var updateResult = await UpdateSupplementDetailCall(16, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[16] = vDats.LWdr_16 + wCalc[15];

                var updateResult = await UpdateSupplementDetailCall(16, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_17 != 0)
            {
                wCalc[17] = vDats.LWdr_17 + wCalc[16];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[17]);
                var updateResult = await UpdateSupplementDetailCall(17, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[17] = vDats.LWdr_17 + wCalc[16];

                var updateResult = await UpdateSupplementDetailCall(17, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_18 != 0)
            {
                wCalc[18] = vDats.LWdr_18 + wCalc[17];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[18]);
                var updateResult = await UpdateSupplementDetailCall(18, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[18] = vDats.LWdr_18 + wCalc[17];

                var updateResult = await UpdateSupplementDetailCall(18, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_19 != 0)
            {
                wCalc[19] = vDats.LWdr_19 + wCalc[18];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[19]);
                var updateResult = await UpdateSupplementDetailCall(19, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[19] = vDats.LWdr_19 + wCalc[18];

                var updateResult = await UpdateSupplementDetailCall(19, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_20 != 0)
            {
                wCalc[20] = vDats.LWdr_20 + wCalc[19];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[20]);
                var updateResult = await UpdateSupplementDetailCall(20, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[20] = vDats.LWdr_20 + wCalc[19];

                var updateResult = await UpdateSupplementDetailCall(20, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_21 != 0)
            {
                wCalc[21] = vDats.LWdr_21 + wCalc[20];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[21]);
                var updateResult = await UpdateSupplementDetailCall(21, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[21] = vDats.LWdr_21 + wCalc[20];

                var updateResult = await UpdateSupplementDetailCall(21, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_22 != 0)
            {
                wCalc[22] = vDats.LWdr_22 + wCalc[21];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[22]);
                var updateResult = await UpdateSupplementDetailCall(22, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[22] = vDats.LWdr_22 + wCalc[21];

                var updateResult = await UpdateSupplementDetailCall(22, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_23 != 0)
            {
                wCalc[23] = vDats.LWdr_23 + wCalc[22];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[23]);
                var updateResult = await UpdateSupplementDetailCall(23, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[23] = vDats.LWdr_23 + wCalc[22];

                var updateResult = await UpdateSupplementDetailCall(23, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_24 != 0)
            {
                wCalc[24] = vDats.LWdr_24 + wCalc[23];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[24]);
                var updateResult = await UpdateSupplementDetailCall(24, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[24] = vDats.LWdr_24 + wCalc[23];

                var updateResult = await UpdateSupplementDetailCall(24, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_25 != 0)
            {
                wCalc[25] = vDats.LWdr_25 + wCalc[24];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[25]);
                var updateResult = await UpdateSupplementDetailCall(25, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[25] = vDats.LWdr_25 + wCalc[24];

                var updateResult = await UpdateSupplementDetailCall(25, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_26 != 0)
            {
                wCalc[26] = vDats.LWdr_26 + wCalc[25];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[26]);
                var updateResult = await UpdateSupplementDetailCall(26, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[26] = vDats.LWdr_26 + wCalc[25];

                var updateResult = await UpdateSupplementDetailCall(26, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_27 != 0)
            {
                wCalc[27] = vDats.LWdr_27 + wCalc[26];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[27]);
                var updateResult = await UpdateSupplementDetailCall(27, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[27] = vDats.LWdr_27 + wCalc[26];

                var updateResult = await UpdateSupplementDetailCall(27, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_28 != 0)
            {
                wCalc[28] = vDats.LWdr_28 + wCalc[27];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[28]);
                var updateResult = await UpdateSupplementDetailCall(28, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[28] = vDats.LWdr_28 + wCalc[27];

                var updateResult = await UpdateSupplementDetailCall(28, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_29 != 0)
            {
                wCalc[29] = vDats.LWdr_29 + wCalc[28];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[29]);
                var updateResult = await UpdateSupplementDetailCall(29, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[29] = vDats.LWdr_29 + wCalc[28];

                var updateResult = await UpdateSupplementDetailCall(29, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_30 != 0)
            {
                wCalc[30] = vDats.LWdr_30 + wCalc[29];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[30]);
                var updateResult = await UpdateSupplementDetailCall(30, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[30] = vDats.LWdr_30 + wCalc[29];

                var updateResult = await UpdateSupplementDetailCall(30, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_31 != 0)
            {
                wCalc[31] = vDats.LWdr_31 + wCalc[30];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[31]);
                var updateResult = await UpdateSupplementDetailCall(31, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[31] = vDats.LWdr_31 + wCalc[30];

                var updateResult = await UpdateSupplementDetailCall(31, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_32 != 0)
            {
                wCalc[32] = vDats.LWdr_32 + wCalc[31];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)recvdteDateBox.DateValue, wCalc[32]);
                var updateResult = await UpdateSupplementDetailCall(32, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[32] = vDats.LWdr_32 + wCalc[31];

                var updateResult = await UpdateSupplementDetailCall(32, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_33 != 0)
            {
                wCalc[33] = vDats.LWdr_33 + wCalc[32];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[33]);
                var updateResult = await UpdateSupplementDetailCall(33, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[33] = vDats.LWdr_33 + wCalc[32];

                var updateResult = await UpdateSupplementDetailCall(33, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_34 != 0)
            {
                wCalc[34] = vDats.LWdr_34 + wCalc[33];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[34]);
                var updateResult = await UpdateSupplementDetailCall(34, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[34] = vDats.LWdr_34 + wCalc[33];

                var updateResult = await UpdateSupplementDetailCall(34, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_35 != 0)
            {
                wCalc[35] = vDats.LWdr_35 + wCalc[34];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[35]);
                var updateResult = await UpdateSupplementDetailCall(35, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[35] = vDats.LWdr_35 + wCalc[34];

                var updateResult = await UpdateSupplementDetailCall(35, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_36 != 0)
            {
                wCalc[36] = vDats.LWdr_36 + wCalc[35];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[36]);
                var updateResult = await UpdateSupplementDetailCall(36, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[36] = vDats.LWdr_36 + wCalc[35];

                var updateResult = await UpdateSupplementDetailCall(36, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_37 != 0)
            {
                wCalc[37] = vDats.LWdr_37 + wCalc[36];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[37]);
                var updateResult = await UpdateSupplementDetailCall(37, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[37] = vDats.LWdr_37 + wCalc[36];

                var updateResult = await UpdateSupplementDetailCall(37, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_38 != 0)
            {
                wCalc[38] = vDats.LWdr_38 + wCalc[37];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[38]);
                var updateResult = await UpdateSupplementDetailCall(38, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[38] = vDats.LWdr_38 + wCalc[37];

                var updateResult = await UpdateSupplementDetailCall(38, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_39 != 0)
            {
                wCalc[39] = vDats.LWdr_39 + wCalc[38];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[39]);
                var updateResult = await UpdateSupplementDetailCall(39, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[39] = vDats.LWdr_39 + wCalc[38];

                var updateResult = await UpdateSupplementDetailCall(39, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_40 != 0)
            {
                wCalc[40] = vDats.LWdr_40 + wCalc[39];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[40]);
                var updateResult = await UpdateSupplementDetailCall(40, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[40] = vDats.LWdr_40 + wCalc[39];

                var updateResult = await UpdateSupplementDetailCall(40, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_41 != 0)
            {
                wCalc[41] = vDats.LWdr_41 + wCalc[40];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[41]);
                var updateResult = await UpdateSupplementDetailCall(41, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[41] = vDats.LWdr_41 + wCalc[40];

                var updateResult = await UpdateSupplementDetailCall(41, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_42 != 0)
            {
                wCalc[42] = vDats.LWdr_42 + wCalc[41];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[42]);
                var updateResult = await UpdateSupplementDetailCall(42, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[42] = vDats.LWdr_42 + wCalc[41];

                var updateResult = await UpdateSupplementDetailCall(42, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_43 != 0)
            {
                wCalc[43] = vDats.LWdr_43 + wCalc[42];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[43]);
                var updateResult = await UpdateSupplementDetailCall(43, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[43] = vDats.LWdr_43 + wCalc[42];

                var updateResult = await UpdateSupplementDetailCall(43, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_44 != 0)
            {
                wCalc[44] = vDats.LWdr_44 + wCalc[43];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[44]);
                var updateResult = await UpdateSupplementDetailCall(44, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[44] = vDats.LWdr_44 + wCalc[43];

                var updateResult = await UpdateSupplementDetailCall(44, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }


            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_45 != 0)
            {
                wCalc[45] = vDats.LWdr_45 + wCalc[44];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[45]);
                var updateResult = await UpdateSupplementDetailCall(45, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[45] = vDats.LWdr_45 + wCalc[44];

                var updateResult = await UpdateSupplementDetailCall(45, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_46 != 0)
            {
                wCalc[46] = vDats.LWdr_46 + wCalc[45];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[46]);
                var updateResult = await UpdateSupplementDetailCall(46, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[46] = vDats.LWdr_46 + wCalc[45];

                var updateResult = await UpdateSupplementDetailCall(46, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_47 != 0)
            {
                wCalc[47] = vDats.LWdr_47 + wCalc[46];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[47]);
                var updateResult = await UpdateSupplementDetailCall(47, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[47] = vDats.LWdr_47 + wCalc[46];

                var updateResult = await UpdateSupplementDetailCall(47, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_48 != 0)
            {
                wCalc[48] = vDats.LWdr_48 + wCalc[47];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[48]);
                var updateResult = await UpdateSupplementDetailCall(48, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[48] = vDats.LWdr_48 + wCalc[47];

                var updateResult = await UpdateSupplementDetailCall(48, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_49 != 0)
            {
                wCalc[49] = vDats.LWdr_49 + wCalc[48];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)recvdteDateBox.DateValue, wCalc[49]);
                var updateResult = await UpdateSupplementDetailCall(49, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[49] = vDats.LWdr_49 + wCalc[48];

                var updateResult = await UpdateSupplementDetailCall(49, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_50 != 0)
            {
                wCalc[50] = vDats.LWdr_50 + wCalc[49];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[50]);
                var updateResult = await UpdateSupplementDetailCall(50, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[50] = vDats.LWdr_50 + wCalc[49];

                var updateResult = await UpdateSupplementDetailCall(50, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            try
            {
               suppdetailTableAdapter.Fill(dsEndSheet.suppdetail, Invno);
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .MarkAsCritical()
                    .AddObject(ex)
                    .Submit();

                MbcMessageBox.Error("Failed to refill supplement detail dataset:" + ex.Message);
            }
            return processingResult;



        }
        public async Task<ApiProcessingResult<bool>> UpdateSupplementDetailCall(int vDescripId, DateTime? vWdr, string vInvno)
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
                    IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from SuppDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='Supplements')) 
                        Begin
                        INSERT INTO SuppDetail (DescripID,Invno,Wdr,Schcode) VALUES((SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='Supplements'),@Invno,@wdr,@Schcode);
                        END
			        ELSE
				        BEGIN
					        UPDATE SuppDetail SET wdr=@wdr  WHERE Invno=@Invno AND DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='Supplements')
				        END ";
            }
            else
            {
                commandText = @"
					        UPDATE SuppDetail SET wdr = @wdr  WHERE Invno = @Invno AND DescripID = (SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='Supplements')
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

        private void btnAddBanner_Click(object sender, EventArgs e)
        {
            //var vcompany = ((DataRowView)produtnBindingSource.Current).Row["Company"].ToString().Trim();
            //if (vcompany=="MER")
            //{
            //    MbcMessageBox.Information("Banners are not available for Meridian");
            //    return;
            //}

            var codeResult = GetSupCode();
            if (codeResult.Result.IsError)
            {
                MbcMessageBox.Error("Failed to get banner number:" + codeResult.Result.Errors[0].ErrorMessage);
                return;
            }
            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"Insert Into Banner(Invno,Schcode,Num) Values(@Invno,@Schcode,@Num)");
            sqlQuery.AddParameter("@Invno", Invno);
            sqlQuery.AddParameter("@Schcode", Schcode);
            sqlQuery.AddParameter("@Num", codeResult.Result.Data);
            var insertResult = sqlQuery.Insert();
            if (insertResult.IsError)
            {
                MbcMessageBox.Error(insertResult.Errors[0].ErrorMessage);
                return;
            }
            Fill();
        }

        private void btnUpdateBannerDates_Click(object sender, EventArgs e)
        {
            var result = UpdateBannerDates();
            if (result.Result.IsError)
            {
                MbcMessageBox.Error("Failed to update banner dates:" + result.Result.Errors[0].ErrorMessage);
            }
        }
        private async Task<ApiProcessingResult> UpdateBannerDates()
        {


            var processingResult = new ApiProcessingResult();

            var bannerResult = SaveBanner();

            if (bannerResult.IsError)
            {

                processingResult.IsError = true;
                processingResult.Errors = bannerResult.Errors;
                return processingResult;
            }
            if (bannerrecvDateBox.Date == null)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Recieved date is empty.", "Recieved date is empty.", ""));
                return processingResult;
            }


            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"Select * From BannerDat");

            var result = sqlQuery.Select<BannerDat>();
            if (result.IsError)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve EndSheet Dat,EndSheet update failed:" + result.Errors[0].ErrorMessage, "Failed to retrieve EndSheet,EndSheet update failed:" + result.Errors[0].ErrorMessage, ""));
                return processingResult;
            }

            var vDats = (BannerDat)result.Data;
            if (vDats == null)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve to find EndSheet update Dats.", "Failed to retrieve to find EndSheet update Dats.", ""));
                return processingResult;
            }
            int[] wCalc = new int[51];//0 based used 51 so I could keep element in line with line numbers 1=1 instead of 0=1
                                      //---------------------------------------------------------------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_1 != 0)
            {
                wCalc[1] = vDats.LWdr_1;
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[1]);
                var updateResult = await UpdateEndSheetDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[1] = vDats.LWdr_1;

                var updateResult = await UpdateEndSheetDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_2 != 0)
            {
                wCalc[2] = vDats.LWdr_2 + wCalc[1];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[2]);
                var updateResult = await UpdateEndSheetDetailCall(2, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[2] = vDats.LWdr_2 + wCalc[1];

                var updateResult = await UpdateEndSheetDetailCall(2, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_3 != 0)
            {
                wCalc[3] = vDats.LWdr_3 + wCalc[2];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[3]);
                var updateResult = await UpdateEndSheetDetailCall(3, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[3] = vDats.LWdr_3 + wCalc[2];

                var updateResult = await UpdateEndSheetDetailCall(3, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #3", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_4 != 0)
            {
                wCalc[4] = vDats.LWdr_4 + wCalc[3];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[4]);
                var updateResult = await UpdateEndSheetDetailCall(4, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[4] = vDats.LWdr_4 + wCalc[3];

                var updateResult = await UpdateEndSheetDetailCall(4, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_5 != 0)
            {
                wCalc[5] = vDats.LWdr_5 + wCalc[4];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[5]);
                var updateResult = await UpdateEndSheetDetailCall(5, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[5] = vDats.LWdr_5 + wCalc[4];

                var updateResult = await UpdateEndSheetDetailCall(5, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_6 != 0)
            {
                wCalc[6] = vDats.LWdr_6 + wCalc[5];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[6]);
                var updateResult = await UpdateEndSheetDetailCall(6, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[6] = vDats.LWdr_6 + wCalc[5];

                var updateResult = await UpdateEndSheetDetailCall(6, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_7 != 0)
            {
                wCalc[7] = vDats.LWdr_7 + wCalc[6];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[7]);
                var updateResult = await UpdateEndSheetDetailCall(7, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[7] = vDats.LWdr_7 + wCalc[6];

                var updateResult = await UpdateEndSheetDetailCall(7, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_8 != 0)
            {
                wCalc[8] = vDats.LWdr_8 + wCalc[7];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[8]);
                var updateResult = await UpdateEndSheetDetailCall(8, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[8] = vDats.LWdr_8 + wCalc[7];

                var updateResult = await UpdateEndSheetDetailCall(8, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_9 != 0)
            {
                wCalc[9] = vDats.LWdr_9 + wCalc[8];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[9]);
                var updateResult = await UpdateEndSheetDetailCall(9, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[9] = vDats.LWdr_9 + wCalc[8];

                var updateResult = await UpdateEndSheetDetailCall(9, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_10 != 0)
            {
                wCalc[10] = vDats.LWdr_10 + wCalc[9];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[10]);
                var updateResult = await UpdateEndSheetDetailCall(10, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[10] = vDats.LWdr_10 + wCalc[9];

                var updateResult = await UpdateEndSheetDetailCall(10, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_11 != 0)
            {
                wCalc[11] = vDats.LWdr_11 + wCalc[10];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[11]);
                var updateResult = await UpdateEndSheetDetailCall(11, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[11] = vDats.LWdr_11 + wCalc[10];

                var updateResult = await UpdateEndSheetDetailCall(11, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_12 != 0)
            {
                wCalc[12] = vDats.LWdr_12 + wCalc[11];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[12]);
                var updateResult = await UpdateEndSheetDetailCall(12, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[12] = vDats.LWdr_12 + wCalc[11];

                var updateResult = await UpdateEndSheetDetailCall(12, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_13 != 0)
            {
                wCalc[13] = vDats.LWdr_13 + wCalc[12];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[13]);
                var updateResult = await UpdateEndSheetDetailCall(13, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[13] = vDats.LWdr_13 + wCalc[12];

                var updateResult = await UpdateEndSheetDetailCall(13, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_14 != 0)
            {
                wCalc[14] = vDats.LWdr_14 + wCalc[13];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[14]);
                var updateResult = await UpdateEndSheetDetailCall(14, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[14] = vDats.LWdr_14 + wCalc[13];

                var updateResult = await UpdateEndSheetDetailCall(14, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_15 != 0)
            {
                wCalc[15] = vDats.LWdr_15 + wCalc[14];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[15]);
                var updateResult = await UpdateEndSheetDetailCall(15, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[15] = vDats.LWdr_15 + wCalc[14];

                var updateResult = await UpdateEndSheetDetailCall(15, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_16 != 0)
            {
                wCalc[16] = vDats.LWdr_16 + wCalc[15];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[16]);
                var updateResult = await UpdateEndSheetDetailCall(16, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[16] = vDats.LWdr_16 + wCalc[15];

                var updateResult = await UpdateEndSheetDetailCall(16, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_17 != 0)
            {
                wCalc[17] = vDats.LWdr_17 + wCalc[16];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[17]);
                var updateResult = await UpdateEndSheetDetailCall(17, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[17] = vDats.LWdr_17 + wCalc[16];

                var updateResult = await UpdateEndSheetDetailCall(17, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_18 != 0)
            {
                wCalc[18] = vDats.LWdr_18 + wCalc[17];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[18]);
                var updateResult = await UpdateEndSheetDetailCall(18, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[18] = vDats.LWdr_18 + wCalc[17];

                var updateResult = await UpdateEndSheetDetailCall(18, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_19 != 0)
            {
                wCalc[19] = vDats.LWdr_19 + wCalc[18];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)bannerrecvDateBox.DateValue, wCalc[19]);
                var updateResult = await UpdateEndSheetDetailCall(19, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[19] = vDats.LWdr_19 + wCalc[18];

                var updateResult = await UpdateEndSheetDetailCall(19, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_20 != 0)
            {
                wCalc[20] = vDats.LWdr_20 + wCalc[19];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[20]);
                var updateResult = await UpdateEndSheetDetailCall(20, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[20] = vDats.LWdr_20 + wCalc[19];

                var updateResult = await UpdateEndSheetDetailCall(20, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_21 != 0)
            {
                wCalc[21] = vDats.LWdr_21 + wCalc[20];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[21]);
                var updateResult = await UpdateEndSheetDetailCall(21, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[21] = vDats.LWdr_21 + wCalc[20];

                var updateResult = await UpdateEndSheetDetailCall(21, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_22 != 0)
            {
                wCalc[22] = vDats.LWdr_22 + wCalc[21];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[22]);
                var updateResult = await UpdateEndSheetDetailCall(22, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[22] = vDats.LWdr_22 + wCalc[21];

                var updateResult = await UpdateEndSheetDetailCall(22, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_23 != 0)
            {
                wCalc[23] = vDats.LWdr_23 + wCalc[22];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[23]);
                var updateResult = await UpdateEndSheetDetailCall(23, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[23] = vDats.LWdr_23 + wCalc[22];

                var updateResult = await UpdateEndSheetDetailCall(23, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_24 != 0)
            {
                wCalc[24] = vDats.LWdr_24 + wCalc[23];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[24]);
                var updateResult = await UpdateEndSheetDetailCall(24, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[24] = vDats.LWdr_24 + wCalc[23];

                var updateResult = await UpdateEndSheetDetailCall(24, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_25 != 0)
            {
                wCalc[25] = vDats.LWdr_25 + wCalc[24];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[25]);
                var updateResult = await UpdateEndSheetDetailCall(25, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[25] = vDats.LWdr_25 + wCalc[24];

                var updateResult = await UpdateEndSheetDetailCall(25, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_26 != 0)
            {
                wCalc[26] = vDats.LWdr_26 + wCalc[25];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[26]);
                var updateResult = await UpdateEndSheetDetailCall(26, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[26] = vDats.LWdr_26 + wCalc[25];

                var updateResult = await UpdateEndSheetDetailCall(26, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_27 != 0)
            {
                wCalc[27] = vDats.LWdr_27 + wCalc[26];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[27]);
                var updateResult = await UpdateEndSheetDetailCall(27, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[27] = vDats.LWdr_27 + wCalc[26];

                var updateResult = await UpdateEndSheetDetailCall(27, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_28 != 0)
            {
                wCalc[28] = vDats.LWdr_28 + wCalc[27];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[28]);
                var updateResult = await UpdateEndSheetDetailCall(28, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[28] = vDats.LWdr_28 + wCalc[27];

                var updateResult = await UpdateEndSheetDetailCall(28, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_29 != 0)
            {
                wCalc[29] = vDats.LWdr_29 + wCalc[28];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[29]);
                var updateResult = await UpdateEndSheetDetailCall(29, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[29] = vDats.LWdr_29 + wCalc[28];

                var updateResult = await UpdateEndSheetDetailCall(29, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_30 != 0)
            {
                wCalc[30] = vDats.LWdr_30 + wCalc[29];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[30]);
                var updateResult = await UpdateEndSheetDetailCall(30, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[30] = vDats.LWdr_30 + wCalc[29];

                var updateResult = await UpdateEndSheetDetailCall(30, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_31 != 0)
            {
                wCalc[31] = vDats.LWdr_31 + wCalc[30];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[31]);
                var updateResult = await UpdateEndSheetDetailCall(31, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[31] = vDats.LWdr_31 + wCalc[30];

                var updateResult = await UpdateEndSheetDetailCall(31, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_32 != 0)
            {
                wCalc[32] = vDats.LWdr_32 + wCalc[31];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)endstrecvDateBox.DateValue, wCalc[32]);
                var updateResult = await UpdateEndSheetDetailCall(32, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[32] = vDats.LWdr_32 + wCalc[31];

                var updateResult = await UpdateEndSheetDetailCall(32, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_33 != 0)
            {
                wCalc[33] = vDats.LWdr_33 + wCalc[32];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[33]);
                var updateResult = await UpdateEndSheetDetailCall(33, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[33] = vDats.LWdr_33 + wCalc[32];

                var updateResult = await UpdateEndSheetDetailCall(33, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_34 != 0)
            {
                wCalc[34] = vDats.LWdr_34 + wCalc[33];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[34]);
                var updateResult = await UpdateEndSheetDetailCall(34, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[34] = vDats.LWdr_34 + wCalc[33];

                var updateResult = await UpdateEndSheetDetailCall(34, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_35 != 0)
            {
                wCalc[35] = vDats.LWdr_35 + wCalc[34];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[35]);
                var updateResult = await UpdateEndSheetDetailCall(35, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[35] = vDats.LWdr_35 + wCalc[34];

                var updateResult = await UpdateEndSheetDetailCall(35, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_36 != 0)
            {
                wCalc[36] = vDats.LWdr_36 + wCalc[35];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[36]);
                var updateResult = await UpdateEndSheetDetailCall(36, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[36] = vDats.LWdr_36 + wCalc[35];

                var updateResult = await UpdateEndSheetDetailCall(36, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_37 != 0)
            {
                wCalc[37] = vDats.LWdr_37 + wCalc[36];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[37]);
                var updateResult = await UpdateEndSheetDetailCall(37, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[37] = vDats.LWdr_37 + wCalc[36];

                var updateResult = await UpdateEndSheetDetailCall(37, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_38 != 0)
            {
                wCalc[38] = vDats.LWdr_38 + wCalc[37];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[38]);
                var updateResult = await UpdateEndSheetDetailCall(38, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[38] = vDats.LWdr_38 + wCalc[37];

                var updateResult = await UpdateEndSheetDetailCall(38, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_39 != 0)
            {
                wCalc[39] = vDats.LWdr_39 + wCalc[38];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[39]);
                var updateResult = await UpdateEndSheetDetailCall(39, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[39] = vDats.LWdr_39 + wCalc[38];

                var updateResult = await UpdateEndSheetDetailCall(39, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_40 != 0)
            {
                wCalc[40] = vDats.LWdr_40 + wCalc[39];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[40]);
                var updateResult = await UpdateEndSheetDetailCall(40, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[40] = vDats.LWdr_40 + wCalc[39];

                var updateResult = await UpdateEndSheetDetailCall(40, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_41 != 0)
            {
                wCalc[41] = vDats.LWdr_41 + wCalc[40];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[41]);
                var updateResult = await UpdateEndSheetDetailCall(41, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[41] = vDats.LWdr_41 + wCalc[40];

                var updateResult = await UpdateEndSheetDetailCall(41, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_42 != 0)
            {
                wCalc[42] = vDats.LWdr_42 + wCalc[41];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[42]);
                var updateResult = await UpdateEndSheetDetailCall(42, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[42] = vDats.LWdr_42 + wCalc[41];

                var updateResult = await UpdateEndSheetDetailCall(42, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_43 != 0)
            {
                wCalc[43] = vDats.LWdr_43 + wCalc[42];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[43]);
                var updateResult = await UpdateEndSheetDetailCall(43, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[43] = vDats.LWdr_43 + wCalc[42];

                var updateResult = await UpdateEndSheetDetailCall(43, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_44 != 0)
            {
                wCalc[44] = vDats.LWdr_44 + wCalc[43];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[44]);
                var updateResult = await UpdateEndSheetDetailCall(44, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[44] = vDats.LWdr_44 + wCalc[43];

                var updateResult = await UpdateEndSheetDetailCall(44, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }


            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_45 != 0)
            {
                wCalc[45] = vDats.LWdr_45 + wCalc[44];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[45]);
                var updateResult = await UpdateEndSheetDetailCall(45, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[45] = vDats.LWdr_45 + wCalc[44];

                var updateResult = await UpdateEndSheetDetailCall(45, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_46 != 0)
            {
                wCalc[46] = vDats.LWdr_46 + wCalc[45];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[46]);
                var updateResult = await UpdateEndSheetDetailCall(46, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[46] = vDats.LWdr_46 + wCalc[45];

                var updateResult = await UpdateEndSheetDetailCall(46, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_47 != 0)
            {
                wCalc[47] = vDats.LWdr_47 + wCalc[46];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[47]);
                var updateResult = await UpdateEndSheetDetailCall(47, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[47] = vDats.LWdr_47 + wCalc[46];

                var updateResult = await UpdateEndSheetDetailCall(47, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_48 != 0)
            {
                wCalc[48] = vDats.LWdr_48 + wCalc[47];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[48]);
                var updateResult = await UpdateEndSheetDetailCall(48, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[48] = vDats.LWdr_48 + wCalc[47];

                var updateResult = await UpdateEndSheetDetailCall(48, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_49 != 0)
            {
                wCalc[49] = vDats.LWdr_49 + wCalc[48];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[49]);
                var updateResult = await UpdateEndSheetDetailCall(49, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[49] = vDats.LWdr_49 + wCalc[48];

                var updateResult = await UpdateEndSheetDetailCall(49, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_50 != 0)
            {
                wCalc[50] = vDats.LWdr_50 + wCalc[49];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)endstrecvDateBox.DateValue, wCalc[50]);
                var updateResult = await UpdateEndSheetDetailCall(50, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[50] = vDats.LWdr_50 + wCalc[49];

                var updateResult = await UpdateEndSheetDetailCall(50, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            try
            {
                endsheetdetailTableAdapter.Fill(dsEndSheet.endsheetdetail, Invno);
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .MarkAsCritical()
                    .AddObject(ex)
                    .Submit();

                MbcMessageBox.Error("Failed to refill endsheet detail dataset:" + ex.Message);
            }
            return processingResult;



        }
        //nothing below
    }
}
