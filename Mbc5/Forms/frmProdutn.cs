using System;
using CustomControls;
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
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Reflection;
using BaseClass;
using Mbc5.Forms.MemoryBook;
using System.Collections;
using System.Collections.Specialized;
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
	

		}
        private string CoverTicketPrinterName { get; set; }
       private string BinderyTicketPrinter { get; set; }
        private string BinderyLabelerPrinter { get; set; }
        private string AddressLabelerName { get; set; }
        private string CoverLabelerName { get; set; }
        public List<CoverDescriptions> CoverDescriptions { get; set; }
        public string Company { get; set; }
        public new frmMain frmMain { get; set; }
        private void SetConnectionString()
		{
			frmMain frmMain = (frmMain)this.MdiParent;
			this.invoiceCustTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.invoiceTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			this.invdetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
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
			partBkDetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
			vendorTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            reorderDetailTableAdapter.Connection.ConnectionString= frmMain.AppConnectionString;
            reOrderTableAdapter.Connection.ConnectionString= frmMain.AppConnectionString;
        }
		private void frmProdutn_Load(object sender, EventArgs e)
		{
            
            this.frmMain = (frmMain)this.MdiParent;
 			this.SetConnectionString();
			try
			{
              
                this.vendorTableAdapter.Fill(this.dsProdutn.vendor);
                this.lkpBackGroundTableAdapter.Fill(this.lookUp.lkpBackGround);
				//LookUp Data
				this.lkTypeDataTableAdapter.Fill(this.lookUp.lkTypeData);
				vendorTableAdapter.Fill(dsProdutn.vendor);
				
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
       private void SetPressDates()
        {
            var custSvcDate = cstsvcdteDateTimePicker.DateValue;
            if (vendcdComboBox1.SelectedValue==null||string.IsNullOrEmpty(vendcdComboBox1.SelectedValue.ToString().Trim()))
            {
                prshpdteDateTimePicker.Date = CalulateBusinessDay.BusDaySubtract((DateTime)custSvcDate, 6).ToShortDateString();
                dteWarnDate.Date = CalulateBusinessDay.BusDaySubtract((DateTime)prshpdteDateTimePicker.DateValue, 9).ToShortDateString();
                bindery4DateBox.Date = CalulateBusinessDay.BusDaySubtract((DateTime)prshpdteDateTimePicker.DateValue, 1).ToShortDateString();
                bindery3DateBox.Date = CalulateBusinessDay.BusDaySubtract((DateTime)bindery4DateBox.DateValue, 4).ToShortDateString();
                bindery2DateBox.Date = CalulateBusinessDay.BusDaySubtract((DateTime)bindery3DateBox.DateValue, 4).ToShortDateString();
                bindery1DateBox.Date = CalulateBusinessDay.BusDaySubtract((DateTime)bindery2DateBox.DateValue, 4).ToShortDateString();
                pressDateBox.Date = CalulateBusinessDay.BusDaySubtract((DateTime)bindery1DateBox.DateValue, 4).ToShortDateString();
                prePressDateBox.Date = CalulateBusinessDay.BusDaySubtract((DateTime)pressDateBox.DateValue, 5).ToShortDateString();               
            }
            else 
            {
                prshpdteDateTimePicker.Date = CalulateBusinessDay.BusDaySubtract((DateTime)custSvcDate, 6).ToShortDateString();
                dteWarnDate.Date = CalulateBusinessDay.BusDaySubtract((DateTime)prshpdteDateTimePicker.DateValue, 9).ToShortDateString();
                prePressDateBox.Date = CalulateBusinessDay.BusDaySubtract((DateTime)dteWarnDate.DateValue, 13).ToShortDateString();
                pressDateBox.Date = null;
                bindery1DateBox.Date = null;
                bindery2DateBox.Date = null;
                bindery3DateBox.Date = null;
                bindery4DateBox.Date = null;
                
                
               
            }


        }
        private async Task<ApiProcessingResult> UpdatePartialDates()
                {


                var processingResult = new ApiProcessingResult();

                var partialResult =SavePtBkB();

                if (partialResult.IsError)
                {

                processingResult.IsError = true;
                processingResult.Errors = partialResult.Errors;
                return processingResult;
                }
                if (partialRecvDate.Date == null)
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Recieved date is empty.", "Recieved date is empty.", ""));
                return processingResult;
                }
                if (string.IsNullOrEmpty(txtPartialBookType.Text))
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Book Type is empty.", "Book Type is empty.", ""));
                return processingResult;
                }

                var sqlQuery = new SQLCustomClient();
                sqlQuery.CommandText(@"Select * From PartialBkData Where BookType=@BookType");
                sqlQuery.AddParameter("@BookType", txtPhotoBookType.Text.ToString().ToUpper().Trim());
                var result = sqlQuery.Select<PartialbDat>();
                if (result.IsError)
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve Partial Book Update Information,Partial Book WIP update failed:" + result.Errors[0].ErrorMessage, "Failed to retrieve Partial Book Update Information,Partial Book WIP update failed:" + result.Errors[0].ErrorMessage, ""));
                return processingResult;
                }

                var vDats = (PartialbDat)result.Data;
                if (vDats == null)
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve Partial Book Update Information", "Failed to retrieve Partial Book Update Information", ""));
                return processingResult;
                }
                int[] wCalc = new int[51];//0 based used 51 so I could keep element in line with line numbers 1=1 instead of 0=1
                                        //---------------------------------------------------------------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr1 != 0)
                {
                wCalc[1] = vDats.L_dwdr1;
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[1]);
                var updateResult = await UpdatePartialBKDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[1] = vDats.L_dwdr1;

                var updateResult = await UpdatePtbKbDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr2 != 0)
                {
                wCalc[2] = vDats.L_dwdr2 + wCalc[1];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[2]);
                var updateResult = await UpdatePtbKbDetailCall(2, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[2] = vDats.L_dwdr2 + wCalc[1];

                var updateResult = await UpdatePtbKbDetailCall(2, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr3 != 0)
                {
                wCalc[3] = vDats.L_dwdr3 + wCalc[2];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[3]);
                var updateResult = await UpdatePtbKbDetailCall(3, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[3] = vDats.L_dwdr3 + wCalc[2];

                var updateResult = await UpdatePtbKbDetailCall(3, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #3", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr4 != 0)
                {
                wCalc[4] = vDats.L_dwdr4 + wCalc[3];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[4]);
                var updateResult = await UpdatePtbKbDetailCall(4, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[4] = vDats.L_dwdr4 + wCalc[3];

                var updateResult = await UpdatePtbKbDetailCall(4, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr5 != 0)
                {
                wCalc[5] = vDats.L_dwdr5 + wCalc[4];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[5]);
                var updateResult = await UpdatePtbKbDetailCall(5, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[5] = vDats.L_dwdr5 + wCalc[4];

                var updateResult = await UpdatePtbKbDetailCall(5, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr6 != 0)
                {
                wCalc[6] = vDats.L_dwdr6 + wCalc[5];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[6]);
                var updateResult = await UpdatePtbKbDetailCall(6, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[6] = vDats.L_dwdr6 + wCalc[5];

                var updateResult = await UpdatePtbKbDetailCall(6, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr7 != 0)
                {
                wCalc[7] = vDats.L_dwdr7 + wCalc[6];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[7]);
                var updateResult = await UpdatePtbKbDetailCall(7, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[7] = vDats.L_dwdr7 + wCalc[6];

                var updateResult = await UpdatePtbKbDetailCall(7, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr8 != 0)
                {
                wCalc[8] = vDats.L_dwdr8 + wCalc[7];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[8]);
                var updateResult = await UpdatePtbKbDetailCall(8, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[8] = vDats.L_dwdr8 + wCalc[7];

                var updateResult = await UpdatePtbKbDetailCall(8, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr9 != 0)
                {
                wCalc[9] = vDats.L_dwdr9 + wCalc[8];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[9]);
                var updateResult = await UpdatePtbKbDetailCall(9, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[9] = vDats.L_dwdr9 + wCalc[8];

                var updateResult = await UpdatePtbKbDetailCall(9, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr10 != 0)
                {
                wCalc[10] = vDats.L_dwdr10 + wCalc[9];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[10]);
                var updateResult = await UpdatePtbKbDetailCall(10, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[10] = vDats.L_dwdr10 + wCalc[9];

                var updateResult = await UpdatePtbKbDetailCall(10, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr11 != 0)
                {
                wCalc[11] = vDats.L_dwdr11 + wCalc[10];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[11]);
                var updateResult = await UpdatePtbKbDetailCall(11, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[11] = vDats.L_dwdr11 + wCalc[10];

                var updateResult = await UpdatePtbKbDetailCall(11, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr12 != 0)
                {
                wCalc[12] = vDats.L_dwdr12 + wCalc[11];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[12]);
                var updateResult = await UpdatePtbKbDetailCall(12, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[12] = vDats.L_dwdr12 + wCalc[11];

                var updateResult = await UpdatePtbKbDetailCall(12, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr13 != 0)
                {
                wCalc[13] = vDats.L_dwdr13 + wCalc[12];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[13]);
                var updateResult = await UpdatePtbKbDetailCall(13, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[13] = vDats.L_dwdr13 + wCalc[12];

                var updateResult = await UpdatePtbKbDetailCall(13, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr14 != 0)
                {
                wCalc[14] = vDats.L_dwdr14 + wCalc[13];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[14]);
                var updateResult = await UpdatePtbKbDetailCall(14, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[14] = vDats.L_dwdr14 + wCalc[13];

                var updateResult = await UpdatePtbKbDetailCall(14, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr15 != 0)
                {
                wCalc[15] = vDats.L_dwdr15 + wCalc[14];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[15]);
                var updateResult = await UpdatePtbKbDetailCall(15, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[15] = vDats.L_dwdr15 + wCalc[14];

                var updateResult = await UpdatePtbKbDetailCall(15, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr16 != 0)
                {
                wCalc[16] = vDats.L_dwdr16 + wCalc[15];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[16]);
                var updateResult = await UpdatePtbKbDetailCall(16, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[16] = vDats.L_dwdr16 + wCalc[15];

                var updateResult = await UpdatePtbKbDetailCall(16, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr17 != 0)
                {
                wCalc[17] = vDats.L_dwdr17 + wCalc[16];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[17]);
                var updateResult = await UpdatePtbKbDetailCall(17, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[17] = vDats.L_dwdr17 + wCalc[16];

                var updateResult = await UpdatePtbKbDetailCall(17, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr18 != 0)
                {
                wCalc[18] = vDats.L_dwdr18 + wCalc[17];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[18]);
                var updateResult = await UpdatePtbKbDetailCall(18, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[18] = vDats.L_dwdr18 + wCalc[17];

                var updateResult = await UpdatePtbKbDetailCall(18, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr19 != 0)
                {
                wCalc[19] = vDats.L_dwdr19 + wCalc[18];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[19]);
                var updateResult = await UpdatePtbKbDetailCall(19, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[19] = vDats.L_dwdr19 + wCalc[18];

                var updateResult = await UpdatePtbKbDetailCall(19, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr20 != 0)
                {
                wCalc[20] = vDats.L_dwdr20 + wCalc[19];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[20]);
                var updateResult = await UpdatePtbKbDetailCall(20, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[20] = vDats.L_dwdr20 + wCalc[19];

                var updateResult = await UpdatePtbKbDetailCall(20, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr21 != 0)
                {
                wCalc[21] = vDats.L_dwdr21 + wCalc[20];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[21]);
                var updateResult = await UpdatePtbKbDetailCall(21, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[21] = vDats.L_dwdr21 + wCalc[20];

                var updateResult = await UpdatePtbKbDetailCall(21, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr22 != 0)
                {
                wCalc[22] = vDats.L_dwdr22 + wCalc[21];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[22]);
                var updateResult = await UpdatePtbKbDetailCall(22, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[22] = vDats.L_dwdr22 + wCalc[21];

                var updateResult = await UpdatePtbKbDetailCall(22, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr23 != 0)
                {
                wCalc[23] = vDats.L_dwdr23 + wCalc[22];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[23]);
                var updateResult = await UpdatePtbKbDetailCall(23, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[23] = vDats.L_dwdr23 + wCalc[22];

                var updateResult = await UpdatePtbKbDetailCall(23, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr24 != 0)
                {
                wCalc[24] = vDats.L_dwdr24 + wCalc[23];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[24]);
                var updateResult = await UpdatePtbKbDetailCall(24, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[24] = vDats.L_dwdr24 + wCalc[23];

                var updateResult = await UpdatePtbKbDetailCall(24, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr25 != 0)
                {
                wCalc[25] = vDats.L_dwdr25 + wCalc[24];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[25]);
                var updateResult = await UpdatePtbKbDetailCall(25, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[25] = vDats.L_dwdr25 + wCalc[24];

                var updateResult = await UpdatePtbKbDetailCall(25, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr26 != 0)
                {
                wCalc[26] = vDats.L_dwdr26 + wCalc[25];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[26]);
                var updateResult = await UpdatePtbKbDetailCall(26, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[26] = vDats.L_dwdr26 + wCalc[25];

                var updateResult = await UpdatePtbKbDetailCall(26, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr27 != 0)
                {
                wCalc[27] = vDats.L_dwdr27 + wCalc[26];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[27]);
                var updateResult = await UpdatePtbKbDetailCall(27, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[27] = vDats.L_dwdr27 + wCalc[26];

                var updateResult = await UpdatePtbKbDetailCall(27, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr28 != 0)
                {
                wCalc[28] = vDats.L_dwdr28 + wCalc[27];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[28]);
                var updateResult = await UpdatePtbKbDetailCall(28, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[28] = vDats.L_dwdr28 + wCalc[27];

                var updateResult = await UpdatePtbKbDetailCall(28, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr29 != 0)
                {
                wCalc[29] = vDats.L_dwdr29 + wCalc[28];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[29]);
                var updateResult = await UpdatePtbKbDetailCall(29, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[29] = vDats.L_dwdr29 + wCalc[28];

                var updateResult = await UpdatePtbKbDetailCall(29, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr30 != 0)
                {
                wCalc[30] = vDats.L_dwdr30 + wCalc[29];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[30]);
                var updateResult = await UpdatePtbKbDetailCall(30, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[30] = vDats.L_dwdr30 + wCalc[29];

                var updateResult = await UpdatePtbKbDetailCall(30, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr31 != 0)
                {
                wCalc[31] = vDats.L_dwdr31 + wCalc[30];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[31]);
                var updateResult = await UpdatePtbKbDetailCall(31, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[31] = vDats.L_dwdr31 + wCalc[30];

                var updateResult = await UpdatePtbKbDetailCall(31, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr32 != 0)
                {
                wCalc[32] = vDats.L_dwdr32 + wCalc[31];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)partialRecvDate.DateValue, wCalc[32]);
                var updateResult = await UpdatePtbKbDetailCall(32, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[32] = vDats.L_dwdr32 + wCalc[31];

                var updateResult = await UpdatePtbKbDetailCall(32, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr33 != 0)
                {
                wCalc[33] = vDats.L_dwdr33 + wCalc[32];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[33]);
                var updateResult = await UpdatePtbKbDetailCall(33, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[33] = vDats.L_dwdr33 + wCalc[32];

                var updateResult = await UpdatePtbKbDetailCall(33, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr34 != 0)
                {
                wCalc[34] = vDats.L_dwdr34 + wCalc[33];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[34]);
                var updateResult = await UpdatePtbKbDetailCall(34, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[34] = vDats.L_dwdr34 + wCalc[33];

                var updateResult = await UpdatePtbKbDetailCall(34, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr35 != 0)
                {
                wCalc[35] = vDats.L_dwdr35 + wCalc[34];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[35]);
                var updateResult = await UpdatePtbKbDetailCall(35, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[35] = vDats.L_dwdr35 + wCalc[34];

                var updateResult = await UpdatePtbKbDetailCall(35, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr36 != 0)
                {
                wCalc[36] = vDats.L_dwdr36 + wCalc[35];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[36]);
                var updateResult = await UpdatePtbKbDetailCall(36, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[36] = vDats.L_dwdr36 + wCalc[35];

                var updateResult = await UpdatePtbKbDetailCall(36, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr37 != 0)
                {
                wCalc[37] = vDats.L_dwdr37 + wCalc[36];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[37]);
                var updateResult = await UpdatePtbKbDetailCall(37, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[37] = vDats.L_dwdr37 + wCalc[36];

                var updateResult = await UpdatePtbKbDetailCall(37, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr38 != 0)
                {
                wCalc[38] = vDats.L_dwdr38 + wCalc[37];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[38]);
                var updateResult = await UpdatePtbKbDetailCall(38, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[38] = vDats.L_dwdr38 + wCalc[37];

                var updateResult = await UpdatePtbKbDetailCall(38, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr39 != 0)
                {
                wCalc[39] = vDats.L_dwdr39 + wCalc[38];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[39]);
                var updateResult = await UpdatePtbKbDetailCall(39, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[39] = vDats.L_dwdr39 + wCalc[38];

                var updateResult = await UpdatePtbKbDetailCall(39, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr40 != 0)
                {
                wCalc[40] = vDats.L_dwdr40 + wCalc[39];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[40]);
                var updateResult = await UpdatePtbKbDetailCall(40, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[40] = vDats.L_dwdr40 + wCalc[39];

                var updateResult = await UpdatePtbKbDetailCall(40, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr41 != 0)
                {
                wCalc[41] = vDats.L_dwdr41 + wCalc[40];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[41]);
                var updateResult = await UpdatePtbKbDetailCall(41, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[41] = vDats.L_dwdr41 + wCalc[40];

                var updateResult = await UpdatePtbKbDetailCall(41, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr42 != 0)
                {
                wCalc[42] = vDats.L_dwdr42 + wCalc[41];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[42]);
                var updateResult = await UpdatePtbKbDetailCall(42, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[42] = vDats.L_dwdr42 + wCalc[41];

                var updateResult = await UpdatePtbKbDetailCall(42, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr43 != 0)
                {
                wCalc[43] = vDats.L_dwdr43 + wCalc[42];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[43]);
                var updateResult = await UpdatePtbKbDetailCall(43, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[43] = vDats.L_dwdr43 + wCalc[42];

                var updateResult = await UpdatePtbKbDetailCall(43, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr44 != 0)
                {
                wCalc[44] = vDats.L_dwdr44 + wCalc[43];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[44]);
                var updateResult = await UpdatePtbKbDetailCall(44, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[44] = vDats.L_dwdr44 + wCalc[43];

                var updateResult = await UpdatePtbKbDetailCall(44, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }


                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr45 != 0)
                {
                wCalc[45] = vDats.L_dwdr45 + wCalc[44];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[45]);
                var updateResult = await UpdatePtbKbDetailCall(45, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[45] = vDats.L_dwdr45 + wCalc[44];

                var updateResult = await UpdatePtbKbDetailCall(45, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr46 != 0)
                {
                wCalc[46] = vDats.L_dwdr46 + wCalc[45];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[46]);
                var updateResult = await UpdatePtbKbDetailCall(46, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[46] = vDats.L_dwdr46 + wCalc[45];

                var updateResult = await UpdatePtbKbDetailCall(46, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr47 != 0)
                {
                wCalc[47] = vDats.L_dwdr47 + wCalc[46];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[47]);
                var updateResult = await UpdatePtbKbDetailCall(47, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[47] = vDats.L_dwdr47 + wCalc[46];

                var updateResult = await UpdatePtbKbDetailCall(47, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr48 != 0)
                {
                wCalc[48] = vDats.L_dwdr48 + wCalc[47];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[48]);
                var updateResult = await UpdatePtbKbDetailCall(48, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[48] = vDats.L_dwdr48 + wCalc[47];

                var updateResult = await UpdatePtbKbDetailCall(48, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr49 != 0)
                {
                wCalc[49] = vDats.L_dwdr49 + wCalc[48];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[49]);
                var updateResult = await UpdatePtbKbDetailCall(49, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[49] = vDats.L_dwdr49 + wCalc[48];

                var updateResult = await UpdatePtbKbDetailCall(49, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.L_dwdr50 != 0)
                {
                wCalc[50] = vDats.L_dwdr50 + wCalc[48];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)partialRecvDate.DateValue, wCalc[50]);
                var updateResult = await UpdatePtbKbDetailCall(50, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[50] = vDats.L_dwdr50 + wCalc[48];

                var updateResult = await UpdatePtbKbDetailCall(50, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                try
                {
                partBkDetailTableAdapter.FillBy(dsProdutn.PartBkDetail, Invno);
                }
                catch (Exception ex)
                {
                ex.ToExceptionless()
                    .MarkAsCritical()
                    .AddObject(ex)
                    .Submit();

                MbcMessageBox.Error("Failed to refill Partial Book :" + ex.Message);
                }
                return processingResult;



                }
        private async Task<ApiProcessingResult> UpdatePhotoCD()
                {


                var processingResult = new ApiProcessingResult();

                var ptbkbResult = SavePtBkB();

                if (ptbkbResult.IsError)
                {

                processingResult.IsError = true;
                processingResult.Errors = ptbkbResult.Errors;
                return processingResult;
                }
                if (ptbrcvd.Date == null)
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Recieved date is empty.", "Recieved date is empty.", ""));
                return processingResult;
                }
                if (string.IsNullOrEmpty(txtPhotoBookType.Text))
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Book Type is empty.", "Book Type is empty.", ""));
                return processingResult;
                }

                var sqlQuery = new SQLCustomClient();
                sqlQuery.CommandText(@"Select * From PtbDat Where BookType=@BookType");
                sqlQuery.AddParameter("@BookType", txtPhotoBookType.Text.ToString().ToUpper().Trim());
                var result = sqlQuery.Select<PtbDat>();
                if (result.IsError)
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve Photo On CD Dat,Photo On CD update failed:" + result.Errors[0].ErrorMessage, "Failed to retrieve Photo On CD Dat,Photo On CD update failed:" + result.Errors[0].ErrorMessage, ""));
                return processingResult;
                }

                var vDats = (PtbDat)result.Data;
                if (vDats == null)
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve to find Photo On CD update Dats.", "Failed to retrieve to find Photo On CD update Dats.", ""));
                return processingResult;
                }
                int[] wCalc = new int[51];//0 based used 51 so I could keep element in line with line numbers 1=1 instead of 0=1
                                        //---------------------------------------------------------------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.LWdr_1 != 0)
                {
                wCalc[1] = vDats.LWdr_1;
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[1]);
                var updateResult = await UpdatePtbKbDetailCall(1, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(1, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[2]);
                var updateResult = await UpdatePtbKbDetailCall(2, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(2, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[3]);
                var updateResult = await UpdatePtbKbDetailCall(3, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(3, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[4]);
                var updateResult = await UpdatePtbKbDetailCall(4, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(4, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[5]);
                var updateResult = await UpdatePtbKbDetailCall(5, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(5, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[6]);
                var updateResult = await UpdatePtbKbDetailCall(6, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(6, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[7]);
                var updateResult = await UpdatePtbKbDetailCall(7, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(7, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[8]);
                var updateResult = await UpdatePtbKbDetailCall(8, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(8, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[9]);
                var updateResult = await UpdatePtbKbDetailCall(9, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(9, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[10]);
                var updateResult = await UpdatePtbKbDetailCall(10, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(10, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[11]);
                var updateResult = await UpdatePtbKbDetailCall(11, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(11, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[12]);
                var updateResult = await UpdatePtbKbDetailCall(12, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(12, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[13]);
                var updateResult = await UpdatePtbKbDetailCall(13, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(13, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[14]);
                var updateResult = await UpdatePtbKbDetailCall(14, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(14, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[15]);
                var updateResult = await UpdatePtbKbDetailCall(15, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(15, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[16]);
                var updateResult = await UpdatePtbKbDetailCall(16, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(16, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[17]);
                var updateResult = await UpdatePtbKbDetailCall(17, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(17, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[18]);
                var updateResult = await UpdatePtbKbDetailCall(18, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(18, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[19]);
                var updateResult = await UpdatePtbKbDetailCall(19, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(19, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[20]);
                var updateResult = await UpdatePtbKbDetailCall(20, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(20, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[21]);
                var updateResult = await UpdatePtbKbDetailCall(21, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(21, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[22]);
                var updateResult = await UpdatePtbKbDetailCall(22, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(22, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[23]);
                var updateResult = await UpdatePtbKbDetailCall(23, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(23, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[24]);
                var updateResult = await UpdatePtbKbDetailCall(24, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(24, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[25]);
                var updateResult = await UpdatePtbKbDetailCall(25, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(25, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[26]);
                var updateResult = await UpdatePtbKbDetailCall(26, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(26, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[27]);
                var updateResult = await UpdatePtbKbDetailCall(27, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(27, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[28]);
                var updateResult = await UpdatePtbKbDetailCall(28, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(28, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[29]);
                var updateResult = await UpdatePtbKbDetailCall(29, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(29, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[30]);
                var updateResult = await UpdatePtbKbDetailCall(30, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(30, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[31]);
                var updateResult = await UpdatePtbKbDetailCall(31, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(31, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)ptbrcvd.DateValue, wCalc[32]);
                var updateResult = await UpdatePtbKbDetailCall(32, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(32, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[33]);
                var updateResult = await UpdatePtbKbDetailCall(33, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(33, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[34]);
                var updateResult = await UpdatePtbKbDetailCall(34, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(34, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[35]);
                var updateResult = await UpdatePtbKbDetailCall(35, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(35, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[36]);
                var updateResult = await UpdatePtbKbDetailCall(36, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(36, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[37]);
                var updateResult = await UpdatePtbKbDetailCall(37, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(37, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[38]);
                var updateResult = await UpdatePtbKbDetailCall(38, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(38, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[39]);
                var updateResult = await UpdatePtbKbDetailCall(39, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(39, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[40]);
                var updateResult = await UpdatePtbKbDetailCall(40, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(40, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[41]);
                var updateResult = await UpdatePtbKbDetailCall(41, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(41, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[42]);
                var updateResult = await UpdatePtbKbDetailCall(42, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(42, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[43]);
                var updateResult = await UpdatePtbKbDetailCall(43, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(43, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[44]);
                var updateResult = await UpdatePtbKbDetailCall(44, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(44, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[45]);
                var updateResult = await UpdatePtbKbDetailCall(45, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(45, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[46]);
                var updateResult = await UpdatePtbKbDetailCall(46, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(46, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[47]);
                var updateResult = await UpdatePtbKbDetailCall(47, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(47, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[48]);
                var updateResult = await UpdatePtbKbDetailCall(48, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(48, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[49]);
                var updateResult = await UpdatePtbKbDetailCall(49, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(49, null, Invno.ToString());
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
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)ptbrcvd.DateValue, wCalc[50]);
                var updateResult = await UpdatePtbKbDetailCall(50, vWdr, Invno.ToString());
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

                var updateResult = await UpdatePtbKbDetailCall(50, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                try
                {
                prtbkbdetailTableAdapter.FillBy(dsProdutn.prtbkbdetail, Invno);
                }
                catch (Exception ex)
                {
                ex.ToExceptionless()
                    .MarkAsCritical()
                    .AddObject(ex)
                    .Submit();

                MbcMessageBox.Error("Failed to refill cover detail dataset:" + ex.Message);
                }
                return processingResult;



                }
        private async Task<ApiProcessingResult> UpdateReOrderDates()
                {


                var processingResult = new ApiProcessingResult();

                var reOrderResult = SaveReOrder();

                if (reOrderResult.IsError)
                {

                processingResult.IsError = true;
                processingResult.Errors = reOrderResult.Errors;
                return processingResult;
                }
                if (cstsvcdteDateTimePicker.Date == null)
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Customer Service Date is empty.", "Customer Service Date is empty.", ""));
                return processingResult;
                }
            var vCustServiceDate = cstsvcdteDateTimePicker.DateValue;
            if (string.IsNullOrEmpty(booktypeTextBox.Text.Trim()))
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Book Type is empty.", "Book Type is empty.", ""));
                return processingResult;
            }

            var sqlQuery = new SQLCustomClient();
                sqlQuery.CommandText(@"Select * From ReOrderDat Where BookType=@BookType");
                sqlQuery.AddParameter("@BookType", booktypeTextBox.Text.ToString().ToUpper().Trim());
                var result = sqlQuery.Select<ReorderDat>();
                if (result.IsError)
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve ReOrder Update Information,ReOrder update failed:" + result.Errors[0].ErrorMessage, "Failed to retrieve ReOrder Update Information,Special ReOrder update failed:" + result.Errors[0].ErrorMessage, ""));
                return processingResult;
                }

                var vDats = (ReorderDat)result.Data;
                if (vDats == null)
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve ReOrder update Dats.", "Failed to retrieve ReOrder update Dats.", ""));
                return processingResult;
                }
                int[] wCalc = new int[51];//0 based used 51 so I could keep element in line with line numbers 1=1 instead of 0=1
                                          //-------------------------------------------------
            sqlQuery.ClearParameters();
            //if (vDats.LWdr_50 != 0)
            // {
            wCalc[50] = vDats.LWdr_50 + vDats.LDateToProd;
            var vWdr1 = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[50]);
            var updateResult1 = await UpdateReOrderDetailCall(50, vWdr1, Invno.ToString());
            if (updateResult1.IsError)
            {

                processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                processingResult.IsError = true;
                return processingResult;
            }

            //}
            //else
            //{
            //wCalc[50] = vDats.LWdr_50 + wCalc[49];

            //var updateResult = await UpdateReOrderDetailCall(50, null, Invno.ToString());
            //if (updateResult.IsError)
            //{

            //    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

            //    processingResult.IsError = true;
            //    return processingResult;
            //}
            // }





            //---------------------------------------------------------------------------------------------------------
            sqlQuery.ClearParameters();
                if (vDats.LWdr_49 != 0)
                {
                wCalc[49] = vDats.LWdr_49+ wCalc[50];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[50]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[49] = vDats.LWdr_49 + wCalc[50];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_48 != 0)
            {
                wCalc[48] = vDats.LWdr_48 + wCalc[49];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[49]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[48] = vDats.LWdr_48 + wCalc[49];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_47 != 0)
            {
                wCalc[47] = vDats.LWdr_47 + wCalc[48];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[48]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[47] = vDats.LWdr_47 + wCalc[48];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_46 != 0)
            {
                wCalc[46] = vDats.LWdr_46 + wCalc[47];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[47]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[46] = vDats.LWdr_46 + wCalc[47];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_45 != 0)
            {
                wCalc[45] = vDats.LWdr_45 + wCalc[46];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[46]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[45] = vDats.LWdr_45 + wCalc[46];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_44 != 0)
            {
                wCalc[44] = vDats.LWdr_44 + wCalc[45];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[45]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[44] = vDats.LWdr_44 + wCalc[45];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_43 != 0)
            {
                wCalc[43] = vDats.LWdr_43 + wCalc[44];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[44]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[43] = vDats.LWdr_43 + wCalc[44];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_42 != 0)
            {
                wCalc[42] = vDats.LWdr_42 + wCalc[43];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[43]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[42] = vDats.LWdr_42 + wCalc[43];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_41 != 0)
            {
                wCalc[41] = vDats.LWdr_41 + wCalc[42];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[42]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[41] = vDats.LWdr_41 + wCalc[42];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_40 != 0)
            {
                wCalc[40] = vDats.LWdr_40 + wCalc[41];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[41]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[40] = vDats.LWdr_40 + wCalc[41];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_39 != 0)
            {
                wCalc[39] = vDats.LWdr_39 + wCalc[40];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[40]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[39] = vDats.LWdr_39 + wCalc[40];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_38 != 0)
            {
                wCalc[38] = vDats.LWdr_38 + wCalc[39];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[39]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[38] = vDats.LWdr_38 + wCalc[39];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_37 != 0)
            {
                wCalc[37] = vDats.LWdr_37 + wCalc[38];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[38]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[37] = vDats.LWdr_37 + wCalc[38];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_36 != 0)
            {
                wCalc[36] = vDats.LWdr_36 + wCalc[37];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[37]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[36] = vDats.LWdr_36 + wCalc[37];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_35 != 0)
            {
                wCalc[35] = vDats.LWdr_35 + wCalc[36];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[36]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[35] = vDats.LWdr_35 + wCalc[36];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_34 != 0)
            {
                wCalc[34] = vDats.LWdr_34 + wCalc[35];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[35]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[34] = vDats.LWdr_34 + wCalc[35];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_33 != 0)
            {
                wCalc[33] = vDats.LWdr_33 + wCalc[34];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[34]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[33] = vDats.LWdr_33 + wCalc[34];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_32 != 0)
            {
                wCalc[32] = vDats.LWdr_32 + wCalc[33];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[33]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[32] = vDats.LWdr_32 + wCalc[33];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_31 != 0)
            {
                wCalc[31] = vDats.LWdr_31 + wCalc[32];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[32]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[31] = vDats.LWdr_31 + wCalc[32];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_30 != 0)
            {
                wCalc[30] = vDats.LWdr_30 + wCalc[31];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[31]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[30] = vDats.LWdr_30 + wCalc[31];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_29 != 0)
            {
                wCalc[29] = vDats.LWdr_29 + wCalc[30];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[30]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[29] = vDats.LWdr_29 + wCalc[30];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_28 != 0)
            {
                wCalc[28] = vDats.LWdr_28 + wCalc[29];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[29]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[28] = vDats.LWdr_28 + wCalc[29];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_27 != 0)
            {
                wCalc[27] = vDats.LWdr_27 + wCalc[28];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[28]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[27] = vDats.LWdr_27 + wCalc[28];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_26 != 0)
            {
                wCalc[26] = vDats.LWdr_26 + wCalc[27];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[27]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[26] = vDats.LWdr_26 + wCalc[27];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_25 != 0)
            {
                wCalc[25] = vDats.LWdr_25 + wCalc[26];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[26]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[25] = vDats.LWdr_25 + wCalc[26];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_24 != 0)
            {
                wCalc[24] = vDats.LWdr_24 + wCalc[25];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[25]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[24] = vDats.LWdr_24 + wCalc[25];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_23 != 0)
            {
                wCalc[23] = vDats.LWdr_23 + wCalc[24];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[24]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[23] = vDats.LWdr_23 + wCalc[24];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_22 != 0)
            {
                wCalc[22] = vDats.LWdr_22 + wCalc[23];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[23]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[22] = vDats.LWdr_22 + wCalc[23];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_21 != 0)
            {
                wCalc[21] = vDats.LWdr_21 + wCalc[22];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[22]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[21] = vDats.LWdr_21 + wCalc[22];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_20 != 0)
            {
                wCalc[20] = vDats.LWdr_20 + wCalc[21];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[21]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[20] = vDats.LWdr_20 + wCalc[21];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_19 != 0)
            {
                wCalc[19] = vDats.LWdr_19 + wCalc[20];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[20]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[19] = vDats.LWdr_19 + wCalc[20];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_18 != 0)
            {
                wCalc[18] = vDats.LWdr_18 + wCalc[19];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[19]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[18] = vDats.LWdr_18 + wCalc[19];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_17 != 0)
            {
                wCalc[17] = vDats.LWdr_17 + wCalc[18];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[18]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[17] = vDats.LWdr_17 + wCalc[18];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_16 != 0)
            {
                wCalc[16] = vDats.LWdr_16 + wCalc[17];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[17]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[16] = vDats.LWdr_16 + wCalc[17];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_15 != 0)
            {
                wCalc[15] = vDats.LWdr_15 + wCalc[16];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[16]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[15] = vDats.LWdr_15 + wCalc[16];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_14 != 0)
            {
                wCalc[14] = vDats.LWdr_14 + wCalc[15];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[15]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[14] = vDats.LWdr_14 + wCalc[15];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_13 != 0)
            {
                wCalc[13] = vDats.LWdr_13 + wCalc[14];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[14]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[13] = vDats.LWdr_13 + wCalc[14];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_12 != 0)
            {
                wCalc[12] = vDats.LWdr_12 + wCalc[13];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[13]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[12] = vDats.LWdr_12 + wCalc[13];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_11 != 0)
            {
                wCalc[11] = vDats.LWdr_11 + wCalc[12];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[12]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[11] = vDats.LWdr_11 + wCalc[12];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_10 != 0)
            {
                wCalc[10] = vDats.LWdr_10 + wCalc[11];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[12]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[10] = vDats.LWdr_10 + wCalc[11];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_9 != 0)
            {
                wCalc[9] = vDats.LWdr_9 + wCalc[10];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[10]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[9] = vDats.LWdr_9 + wCalc[10];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_8 != 0)
            {
                wCalc[8] = vDats.LWdr_8 + wCalc[9];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[9]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[8] = vDats.LWdr_8 + wCalc[9];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_7 != 0)
            {
                wCalc[7] = vDats.LWdr_7 + wCalc[8];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[8]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[7] = vDats.LWdr_7 + wCalc[8];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_6 != 0)
            {
                wCalc[6] = vDats.LWdr_6 + wCalc[7];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[7]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[6] = vDats.LWdr_6 + wCalc[7];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------

            sqlQuery.ClearParameters();
            if (vDats.LWdr_5 != 0)
            {
                wCalc[5] = vDats.LWdr_5 + wCalc[6];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[6]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[5] = vDats.LWdr_5 + wCalc[6];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_4 != 0)
            {
                wCalc[4] = vDats.LWdr_4 + wCalc[5];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[5]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[4] = vDats.LWdr_4 + wCalc[5];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_3 != 0)
            {
                wCalc[3] = vDats.LWdr_3 + wCalc[4];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[4]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #3", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[3] = vDats.LWdr_3 + wCalc[4];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #3", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_2 != 0)
            {
                wCalc[2] = vDats.LWdr_2 + wCalc[3];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[3]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[2] = vDats.LWdr_2 + wCalc[3];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            sqlQuery.ClearParameters();
            if (vDats.LWdr_1 != 0)
            {
                wCalc[1] = vDats.LWdr_1 + wCalc[2];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)vCustServiceDate, wCalc[3]);
                var updateResult = await UpdateReOrderDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            else
            {
                wCalc[1] = vDats.LWdr_1 + wCalc[2];

                var updateResult = await UpdateReOrderDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            //-------------------------------------------------
            try
            {
                reorderDetailTableAdapter.Fill(dsProdutn.ReorderDetail, Invno);
                }
                catch (Exception ex)
                {
                ex.ToExceptionless()
                    .MarkAsCritical()
                    .AddObject(ex)
                    .Submit();

                MbcMessageBox.Error("Failed to refill reorder detail dataset:" + ex.Message);
                }
                return processingResult;



                }     
        public async Task<ApiProcessingResult<bool>> UpdateReOrderDetailCall(int vDescripId, DateTime? vWdr, string vInvno)
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
                            IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from ReOrderDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='ReOrder')) 
                                Begin
                                INSERT INTO ReOrderDetail (DescripID,Invno,Wdr,Schcode) VALUES((SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='ReOrder'),@Invno,@wdr,@Schcode);
                                END
			                ELSE
				                BEGIN
					                UPDATE ReOrderDetail SET wdr=@wdr  WHERE Invno=@Invno AND DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='ReOrder')
				                END ";
            }
            else
            {
                commandText = @"
					                UPDATE PartBkDetail SET wdr = @wdr  WHERE Invno = @Invno AND DescripID = (SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='PartialBook')
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
        public async Task<ApiProcessingResult<bool>> UpdatePartialBKDetailCall(int vDescripId, DateTime? vWdr, string vInvno)
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
                            IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from PartBkDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='PartialBook')) 
                                Begin
                                INSERT INTO PartBkDetail (DescripID,Invno,Wdr,Schcode) VALUES((SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='PartialBook'),@Invno,@wdr,@Schcode);
                                END
			                ELSE
				                BEGIN
					                UPDATE PartBkDetail SET wdr=@wdr  WHERE Invno=@Invno AND DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='PartialBook')
				                END ";
                }
                else
                {
                commandText = @"
					                UPDATE PartBkDetail SET wdr = @wdr  WHERE Invno = @Invno AND DescripID = (SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='PartialBook')
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
                    IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='WIP')) 
                        Begin
                        INSERT INTO WipDetail (DescripID,Invno,Wdr,Schcode) VALUES((SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='WIP'),@Invno,@wdr,@Schcode);
                        END
			        ELSE
				        BEGIN
					        UPDATE WipDetail SET wdr=@wdr  WHERE Invno=@Invno AND DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='WIP')
				        END ";
        }
        else
        {
        commandText = @"
					        UPDATE WipDetail SET wdr = @wdr  WHERE Invno = @Invno AND DescripID = (SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='WIP')
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
        public async Task<ApiProcessingResult<bool>> UpdatePtbKbDetailCall(int vDescripId, DateTime? vWdr, string vInvno)
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
                    IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from prtbkbdetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='PhotosCD')) 
                        Begin
                        INSERT INTO prtbkbdetail (DescripID,Invno,Wdr,Schcode) VALUES((SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='PhotosCD'),@Invno,@wdr,@Schcode);
                        END
			        ELSE
				        BEGIN
					        UPDATE prtbkbdetail SET wdr=@wdr  WHERE Invno=@Invno AND DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='PhotosCD')
				        END ";
        }
        else
        {
        commandText = @"
					        UPDATE prtbkbdetail SET wdr = @wdr  WHERE Invno = @Invno AND DescripID = (SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='PhotosCD')
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
        private async Task<ApiProcessingResult<bool>> UpdateWipCoverDetailCall(int vDescripId, DateTime? vWdr, string vInvno)
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
                    IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from CoverDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='COVERS')) 
                        Begin
                        INSERT INTO CoverDetail (DescripID,Invno,Wdr,Schcode) VALUES((SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='COVERS'),@Invno,@wdr,@Schcode);
                        END
			        ELSE
				        BEGIN
					        UPDATE CoverDetail SET wdr=@wdr  WHERE Invno=@Invno AND DescripID=(SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='COVERS')
				        END ";
        }
        else
        {
        commandText = @"
					        UPDATE CoverDetail SET wdr = @wdr  WHERE Invno = @Invno AND DescripID = (SELECT Id From WipDescriptions WHERE DescriptionId=@DescripID AND TableName='COVERS')
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
        private async Task<ApiProcessingResult<string>> UpdateCoverWip()
                {
                var processingResult = new ApiProcessingResult<string>();

                var coverResult = SaveCovers();

                if (coverResult.IsError)
                {

                processingResult.IsError = true;
                processingResult.Errors = coverResult.Errors;
                return processingResult;
                }
                if (ptbrcvd.Date == null)
                {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Recieved date is empty.", "Recieved date is empty.", ""));
                return processingResult;
                }
                var sqlQuery = new SQLCustomClient();
                sqlQuery.CommandText(@"Select * From ScWip");//only 1 record
                var result = sqlQuery.Select<SpecialCoverDats>();
                if (result.IsError)
                {

                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Failed to retrieve Special Cover Update Information,Special Cover WIP update failed:" + result.Errors[0].ErrorMessage, "Failed to retrieve Special Cover Update Information,Special Cover WIP update failed:" + result.Errors[0].ErrorMessage, ""));
                return processingResult;
                }
                var vDats = (SpecialCoverDats)result.Data;
                int[] wCalc = new int[51];//0 based used 51 so I could keep element in line with line numbers 1=1 instead of 0=1
                //---------------------------------------------------------------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr1 != 0)
                {
                wCalc[1] = vDats.l_wdr1;
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[1]);
                var updateResult = await UpdateWipCoverDetailCall(1, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[1] = vDats.l_wdr1;

                var updateResult = await UpdateWipCoverDetailCall(1, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #1", "Datbase error. #1", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr2 != 0)
                {
                wCalc[2] = vDats.l_wdr2 + wCalc[1];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[2]);
                var updateResult = await UpdateWipCoverDetailCall(2, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[2] = vDats.l_wdr2 + wCalc[1];

                var updateResult = await UpdateWipCoverDetailCall(2, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #2", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr3 != 0)
                {
                wCalc[3] = vDats.l_wdr3 + wCalc[2];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[3]);
                var updateResult = await UpdateWipCoverDetailCall(3, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #2", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[3] = vDats.l_wdr3 + wCalc[2];

                var updateResult = await UpdateWipCoverDetailCall(3, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #3", "Datbase error. #3", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr4 != 0)
                {
                wCalc[4] = vDats.l_wdr4 + wCalc[3];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[4]);
                var updateResult = await UpdateWipCoverDetailCall(4, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[4] = vDats.l_wdr4 + wCalc[3];

                var updateResult = await UpdateWipCoverDetailCall(4, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #4", "Datbase error. #4", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr5 != 0)
                {
                wCalc[5] = vDats.l_wdr5 + wCalc[4];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[5]);
                var updateResult = await UpdateWipCoverDetailCall(5, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[5] = vDats.l_wdr5 + wCalc[4];

                var updateResult = await UpdateWipCoverDetailCall(5, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #5", "Datbase error. #5", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr6 != 0)
                {
                wCalc[6] = vDats.l_wdr6 + wCalc[5];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[6]);
                var updateResult = await UpdateWipCoverDetailCall(6, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[6] = vDats.l_wdr6 + wCalc[5];

                var updateResult = await UpdateWipCoverDetailCall(6, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #6", "Datbase error. #6", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr7 != 0)
                {
                wCalc[7] = vDats.l_wdr7 + wCalc[6];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[7]);
                var updateResult = await UpdateWipCoverDetailCall(7, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[7] = vDats.l_wdr7 + wCalc[6];

                var updateResult = await UpdateWipCoverDetailCall(7, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #7", "Datbase error. #7", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr8 != 0)
                {
                wCalc[8] = vDats.l_wdr8 + wCalc[7];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[8]);
                var updateResult = await UpdateWipCoverDetailCall(8, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[8] = vDats.l_wdr8 + wCalc[7];

                var updateResult = await UpdateWipCoverDetailCall(8, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #8", "Datbase error. #8", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr9 != 0)
                {
                wCalc[9] = vDats.l_wdr9 + wCalc[8];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[9]);
                var updateResult = await UpdateWipCoverDetailCall(9, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[9] = vDats.l_wdr9 + wCalc[8];

                var updateResult = await UpdateWipCoverDetailCall(9, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #9", "Datbase error. #9", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr10 != 0)
                {
                wCalc[10] = vDats.l_wdr10 + wCalc[9];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[10]);
                var updateResult = await UpdateWipCoverDetailCall(10, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[10] = vDats.l_wdr10 + wCalc[9];

                var updateResult = await UpdateWipCoverDetailCall(10, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #10", "Datbase error. #10", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr11 != 0)
                {
                wCalc[11] = vDats.l_wdr11 + wCalc[10];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[11]);
                var updateResult = await UpdateWipCoverDetailCall(11, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[11] = vDats.l_wdr11 + wCalc[10];

                var updateResult = await UpdateWipCoverDetailCall(11, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #11", "Datbase error. #11", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr12 != 0)
                {
                wCalc[12] = vDats.l_wdr12 + wCalc[11];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[12]);
                var updateResult = await UpdateWipCoverDetailCall(12, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[12] = vDats.l_wdr12 + wCalc[11];

                var updateResult = await UpdateWipCoverDetailCall(12, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #12", "Datbase error. #12", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr13 != 0)
                {
                wCalc[13] = vDats.l_wdr13 + wCalc[12];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[13]);
                var updateResult = await UpdateWipCoverDetailCall(13, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[13] = vDats.l_wdr13 + wCalc[12];

                var updateResult = await UpdateWipCoverDetailCall(13, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #13", "Datbase error. #13", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr14 != 0)
                {
                wCalc[14] = vDats.l_wdr14 + wCalc[13];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[14]);
                var updateResult = await UpdateWipCoverDetailCall(14, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[14] = vDats.l_wdr14 + wCalc[13];

                var updateResult = await UpdateWipCoverDetailCall(14, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #14", "Datbase error. #14", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr15 != 0)
                {
                wCalc[15] = vDats.l_wdr15 + wCalc[14];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[15]);
                var updateResult = await UpdateWipCoverDetailCall(15, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[15] = vDats.l_wdr15 + wCalc[14];

                var updateResult = await UpdateWipCoverDetailCall(15, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #15", "Datbase error. #15", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr16 != 0)
                {
                wCalc[16] = vDats.l_wdr16 + wCalc[15];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[16]);
                var updateResult = await UpdateWipCoverDetailCall(16, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[16] = vDats.l_wdr16 + wCalc[15];

                var updateResult = await UpdateWipCoverDetailCall(16, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #16", "Datbase error. #16", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr17 != 0)
                {
                wCalc[17] = vDats.l_wdr17 + wCalc[16];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[17]);
                var updateResult = await UpdateWipCoverDetailCall(17, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[17] = vDats.l_wdr17 + wCalc[16];

                var updateResult = await UpdateWipCoverDetailCall(17, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #17", "Datbase error. #17", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr18 != 0)
                {
                wCalc[18] = vDats.l_wdr18 + wCalc[17];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[18]);
                var updateResult = await UpdateWipCoverDetailCall(18, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[18] = vDats.l_wdr18 + wCalc[17];

                var updateResult = await UpdateWipCoverDetailCall(18, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #18", "Datbase error. #18", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr19 != 0)
                {
                wCalc[19] = vDats.l_wdr19 + wCalc[18];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[19]);
                var updateResult = await UpdateWipCoverDetailCall(19, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[19] = vDats.l_wdr19 + wCalc[18];

                var updateResult = await UpdateWipCoverDetailCall(19, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #19", "Datbase error. #19", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr20 != 0)
                {
                wCalc[20] = vDats.l_wdr20 + wCalc[19];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[20]);
                var updateResult = await UpdateWipCoverDetailCall(20, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[20] = vDats.l_wdr20 + wCalc[19];

                var updateResult = await UpdateWipCoverDetailCall(20, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #20", "Datbase error. #20", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr21 != 0)
                {
                wCalc[21] = vDats.l_wdr21 + wCalc[20];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[21]);
                var updateResult = await UpdateWipCoverDetailCall(21, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[21] = vDats.l_wdr21 + wCalc[20];

                var updateResult = await UpdateWipCoverDetailCall(21, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #21", "Datbase error. #21", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr22 != 0)
                {
                wCalc[22] = vDats.l_wdr22 + wCalc[21];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[22]);
                var updateResult = await UpdateWipCoverDetailCall(22, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[22] = vDats.l_wdr22 + wCalc[21];

                var updateResult = await UpdateWipCoverDetailCall(22, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #22", "Datbase error. #22", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr23 != 0)
                {
                wCalc[23] = vDats.l_wdr23 + wCalc[22];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[23]);
                var updateResult = await UpdateWipCoverDetailCall(23, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[23] = vDats.l_wdr23 + wCalc[22];

                var updateResult = await UpdateWipCoverDetailCall(23, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #23", "Datbase error. #23", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr24 != 0)
                {
                wCalc[24] = vDats.l_wdr24 + wCalc[23];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[24]);
                var updateResult = await UpdateWipCoverDetailCall(24, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[24] = vDats.l_wdr24 + wCalc[23];

                var updateResult = await UpdateWipCoverDetailCall(24, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #24", "Datbase error. #24", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr25 != 0)
                {
                wCalc[25] = vDats.l_wdr25 + wCalc[24];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[25]);
                var updateResult = await UpdateWipCoverDetailCall(25, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[25] = vDats.l_wdr25 + wCalc[24];

                var updateResult = await UpdateWipCoverDetailCall(25, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #25", "Datbase error. #25", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr26 != 0)
                {
                wCalc[26] = vDats.l_wdr26 + wCalc[25];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[26]);
                var updateResult = await UpdateWipCoverDetailCall(26, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[26] = vDats.l_wdr26 + wCalc[25];

                var updateResult = await UpdateWipCoverDetailCall(26, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #26", "Datbase error. #26", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr27 != 0)
                {
                wCalc[27] = vDats.l_wdr27 + wCalc[26];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[27]);
                var updateResult = await UpdateWipCoverDetailCall(27, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[27] = vDats.l_wdr27 + wCalc[26];

                var updateResult = await UpdateWipCoverDetailCall(27, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #27", "Datbase error. #27", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr28 != 0)
                {
                wCalc[28] = vDats.l_wdr28 + wCalc[27];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[28]);
                var updateResult = await UpdateWipCoverDetailCall(28, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[28] = vDats.l_wdr28 + wCalc[27];

                var updateResult = await UpdateWipCoverDetailCall(28, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #28", "Datbase error. #28", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr29 != 0)
                {
                wCalc[29] = vDats.l_wdr29 + wCalc[28];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[29]);
                var updateResult = await UpdateWipCoverDetailCall(29, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[29] = vDats.l_wdr29 + wCalc[28];

                var updateResult = await UpdateWipCoverDetailCall(29, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #29", "Datbase error. #29", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr30 != 0)
                {
                wCalc[30] = vDats.l_wdr30 + wCalc[29];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[30]);
                var updateResult = await UpdateWipCoverDetailCall(30, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[30] = vDats.l_wdr30 + wCalc[29];

                var updateResult = await UpdateWipCoverDetailCall(30, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #30", "Datbase error. #30", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr31 != 0)
                {
                wCalc[31] = vDats.l_wdr31 + wCalc[30];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[31]);
                var updateResult = await UpdateWipCoverDetailCall(31, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[31] = vDats.l_wdr31 + wCalc[30];

                var updateResult = await UpdateWipCoverDetailCall(31, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #31", "Datbase error. #31", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr32 != 0)
                {
                wCalc[32] = vDats.l_wdr32 + wCalc[31];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)dbScRecvDate.DateValue, wCalc[32]);
                var updateResult = await UpdateWipCoverDetailCall(32, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[32] = vDats.l_wdr32 + wCalc[31];

                var updateResult = await UpdateWipCoverDetailCall(32, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #32", "Datbase error. #32", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr33 != 0)
                {
                wCalc[33] = vDats.l_wdr33 + wCalc[32];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[33]);
                var updateResult = await UpdateWipCoverDetailCall(33, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[33] = vDats.l_wdr33 + wCalc[32];

                var updateResult = await UpdateWipCoverDetailCall(33, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #33", "Datbase error. #33", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr34 != 0)
                {
                wCalc[34] = vDats.l_wdr34 + wCalc[33];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[34]);
                var updateResult = await UpdateWipCoverDetailCall(34, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[34] = vDats.l_wdr34 + wCalc[33];

                var updateResult = await UpdateWipCoverDetailCall(34, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #34", "Datbase error. #34", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr35 != 0)
                {
                wCalc[35] = vDats.l_wdr35 + wCalc[34];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[35]);
                var updateResult = await UpdateWipCoverDetailCall(35, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[35] = vDats.l_wdr35 + wCalc[34];

                var updateResult = await UpdateWipCoverDetailCall(35, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #35", "Datbase error. #35", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr36 != 0)
                {
                wCalc[36] = vDats.l_wdr36 + wCalc[35];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[36]);
                var updateResult = await UpdateWipCoverDetailCall(36, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[36] = vDats.l_wdr36 + wCalc[35];

                var updateResult = await UpdateWipCoverDetailCall(36, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #36", "Datbase error. #36", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr37 != 0)
                {
                wCalc[37] = vDats.l_wdr37 + wCalc[36];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[37]);
                var updateResult = await UpdateWipCoverDetailCall(37, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[37] = vDats.l_wdr37 + wCalc[36];

                var updateResult = await UpdateWipCoverDetailCall(37, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #37", "Datbase error. #37", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr38 != 0)
                {
                wCalc[38] = vDats.l_wdr38 + wCalc[37];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[38]);
                var updateResult = await UpdateWipCoverDetailCall(38, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[38] = vDats.l_wdr38 + wCalc[37];

                var updateResult = await UpdateWipCoverDetailCall(38, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #38", "Datbase error. #38", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr39 != 0)
                {
                wCalc[39] = vDats.l_wdr39 + wCalc[38];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[39]);
                var updateResult = await UpdateWipCoverDetailCall(39, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[39] = vDats.l_wdr39 + wCalc[38];

                var updateResult = await UpdateWipCoverDetailCall(39, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #39", "Datbase error. #39", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr40 != 0)
                {
                wCalc[40] = vDats.l_wdr40 + wCalc[39];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[40]);
                var updateResult = await UpdateWipCoverDetailCall(40, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[40] = vDats.l_wdr40 + wCalc[39];

                var updateResult = await UpdateWipCoverDetailCall(40, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #40", "Datbase error. #40", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr41 != 0)
                {
                wCalc[41] = vDats.l_wdr41 + wCalc[40];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[41]);
                var updateResult = await UpdateWipCoverDetailCall(41, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[41] = vDats.l_wdr41 + wCalc[40];

                var updateResult = await UpdateWipCoverDetailCall(41, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #41", "Datbase error. #41", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr42 != 0)
                {
                wCalc[42] = vDats.l_wdr42 + wCalc[41];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[42]);
                var updateResult = await UpdateWipCoverDetailCall(42, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[42] = vDats.l_wdr42 + wCalc[41];

                var updateResult = await UpdateWipCoverDetailCall(42, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #42", "Datbase error. #42", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr43 != 0)
                {
                wCalc[43] = vDats.l_wdr43 + wCalc[42];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[43]);
                var updateResult = await UpdateWipCoverDetailCall(43, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[43] = vDats.l_wdr43 + wCalc[42];

                var updateResult = await UpdateWipCoverDetailCall(43, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #43", "Datbase error. #43", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr44 != 0)
                {
                wCalc[44] = vDats.l_wdr44 + wCalc[43];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[44]);
                var updateResult = await UpdateWipCoverDetailCall(44, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[44] = vDats.l_wdr44 + wCalc[43];

                var updateResult = await UpdateWipCoverDetailCall(44, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #44", "Datbase error. #44", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }


                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr45 != 0)
                {
                wCalc[45] = vDats.l_wdr45 + wCalc[44];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[45]);
                var updateResult = await UpdateWipCoverDetailCall(45, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[45] = vDats.l_wdr45 + wCalc[44];

                var updateResult = await UpdateWipCoverDetailCall(45, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #45", "Datbase error. #45", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr46 != 0)
                {
                wCalc[46] = vDats.l_wdr46 + wCalc[45];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[46]);
                var updateResult = await UpdateWipCoverDetailCall(46, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[46] = vDats.l_wdr46 + wCalc[45];

                var updateResult = await UpdateWipCoverDetailCall(46, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #46", "Datbase error. #46", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr47 != 0)
                {
                wCalc[47] = vDats.l_wdr47 + wCalc[46];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[47]);
                var updateResult = await UpdateWipCoverDetailCall(47, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[47] = vDats.l_wdr47 + wCalc[46];

                var updateResult = await UpdateWipCoverDetailCall(47, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #47", "Datbase error. #47", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr48 != 0)
                {
                wCalc[48] = vDats.l_wdr48 + wCalc[47];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[48]);
                var updateResult = await UpdateWipCoverDetailCall(48, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[48] = vDats.l_wdr48 + wCalc[47];

                var updateResult = await UpdateWipCoverDetailCall(48, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #48", "Datbase error. #48", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr49 != 0)
                {
                wCalc[49] = vDats.l_wdr49 + wCalc[48];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[49]);
                var updateResult = await UpdateWipCoverDetailCall(49, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[49] = vDats.l_wdr49 + wCalc[48];

                var updateResult = await UpdateWipCoverDetailCall(49, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #49", "Datbase error. #49", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }

                //-------------------------------------------------
                sqlQuery.ClearParameters();
                if (vDats.l_wdr50 != 0)
                {
                wCalc[50] = vDats.l_wdr50 + wCalc[48];
                var vWdr = CalulateBusinessDay.BusDayAdd((DateTime)dbScRecvDate.DateValue, wCalc[50]);
                var updateResult = await UpdateWipCoverDetailCall(50, vWdr, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }

                }
                else
                {
                wCalc[50] = vDats.l_wdr50 + wCalc[48];

                var updateResult = await UpdateWipCoverDetailCall(50, null, Invno.ToString());
                if (updateResult.IsError)
                {

                    processingResult.Errors.Add(new ApiProcessingError("Datbase error. #50", "Datbase error. #50", ""));

                    processingResult.IsError = true;
                    return processingResult;
                }
                }
                try
                {
                coverdetailTableAdapter.FillByInvno(dsProdutn.coverdetail, Invno);
                }
                catch (Exception ex)
                {
                ex.ToExceptionless()
                    .MarkAsCritical()
                    .AddObject(ex)
                    .Submit();

                MbcMessageBox.Error("Failed to refill cover detail dataset:" + ex.Message);
                }
                return processingResult;

                }
        private void ShippingEmail()
		{
			var cMainPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var cPdfPath = cMainPath.Substring(0, cMainPath.IndexOf("Mbc5") + 4) + "\\tmp\\" + this.Invno.ToString() + ".pdf";
			try
			{
				var aa = this.invoiceTableAdapter.Fill(dsInvoice.invoice, this.Invno);
				var rr = this.invdetailTableAdapter.Fill(dsInvoice.invdetail, this.Invno);
				this.paymntTableAdapter.Fill(dsInvoice.paymnt,this.Invno);
				var aaaa = this.invoiceCustTableAdapter.Fill(dsCust.cust, this.Schcode);
				
				Warning[] warnings;
				string[] streamIds;
				string mimeType = string.Empty;
				string encoding = string.Empty;
				string extension = string.Empty;
				//string HIJRA_TODAY = "01/10/1435";
				// ReportParameter[] param = new ReportParameter[3];
				//param[0] = new ReportParameter("CUSTOMER_NUM", CUSTOMER_NUMTBX.Text);
				//param[1] = new ReportParameter("REF_CD", REF_CDTB.Text);
				//param[2] = new ReportParameter("HIJRA_TODAY", HIJRA_TODAY);

				byte[] bytes = this.reportViewer1.LocalReport.Render(
					"PDF",
					null,
					out mimeType,
					out encoding,
					out extension,
					out streamIds,
					out warnings);

				using (FileStream fs = new FileStream(cPdfPath, FileMode.Create))
				{
					fs.Write(bytes, 0, bytes.Length);
				}


			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to create invoice pdf.");
			}

			this.Cursor = Cursors.AppStarting;
			string body = @"<p>Your yearbooks have shipped so be looking for them shortly. 
							Thanks for a being a great customer and we look forward to working with you again next year.
							If you have already rebooked for next year, thank you! <p/><p>If you are not already rebooked, please 
							contact your Sales Consultant today at 1 - 800 - 247 - 1526. We appreciate your business and look
							forward to working with you next year to preserve your school's memories.<p/><p>  An invoice is attached for you.
						   If you are interested, we may have extra books available for you to purchase at your original cost per book, plus $12 for shipping. The shipping is a
							flat fee whether you order one extra book or all of them.<p/><p>		
							Please do not reply to this email.  If you have questions, please contact your Customer Service Representative.	<p/>

							<p>www.memorybook.com / <p>";




			string subj = "Your Planners have shipped!";
			var row =(DataRowView) custBindingSource.Current;
			string email =row["schemail"].ToString();
			var emailHelper = new EmailHelper();
			EmailType type = EmailType.Mbc;
			List<OutlookAttachemt> attachment = new List<OutlookAttachemt>();
			OutlookAttachemt att = new OutlookAttachemt() { Path = cPdfPath, Name = Invno.ToString()+".pdf" };
			attachment.Add(att);

			emailHelper.SendOutLookEmail(subj, email,"", body, type,attachment);
			this.Cursor = Cursors.Default;
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
			var current = (DataRowView)custBindingSource.Current;
            if (current == null)
			{
				return;
			}

            SchEmail = current.Row["schemail"].ToString(); 
			ContactEmail = current.Row["contemail"].ToString();            
			BcontactEmail = current.Row["bcontemail"].ToString();                    
			CcontactEmail = current.Row["ccontemail"].ToString();                         
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
        public void PrintYearBookLabel()
        {
            //put in check for nulls
            var vKitRecvd = ((DataRowView)this.produtnBindingSource.Current).Row["kitrecvd"].ToString();
            var vRecvCardSent = ((DataRowView)this.produtnBindingSource.Current).Row["reccardsent"].ToString();
            if (vRecvCardSent!="True")
            {
                MbcMessageBox.Information("A receiving card has not been sent for this customer.", "Receiving Card");
            }
            var vSchoolState= ((DataRowView)this.custBindingSource.Current).Row["schstate"].ToString().Trim();
            if (string.IsNullOrEmpty(vKitRecvd))
            {
                MbcMessageBox.Information("Kit received date must be entered before printing a label.", "");
                return;
            }

            reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321YearBookLabel.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsRCust", custBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsRQuotes", quotesBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsRProdutn", produtnBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsRWip", wipBindingSource));

            reportViewer1.RefreshReport();   
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
				try {
				custTableAdapter.Fill(dsProdutn.cust, Schcode);
				quotesTableAdapter.FillByInvno(dsProdutn.quotes, Invno);
				produtnTableAdapter.FillByInvno(dsProdutn.produtn, Invno);
                    Company = ((DataRowView)produtnBindingSource.Current).Row["Company"].ToString();

				}catch(Exception ex) {
                    var a = dsProdutn.Tables["cust"].GetErrors();
                    MbcMessageBox.Error(ex.Message, "");
				}

				if (dsProdutn.produtn.Count < 1)
				{
					DisableControls(this.tbProdutn.TabPages[0]);
					foreach (TabPage tab in tbProdutn.TabPages)
					{
						DisableControls(tab);
					}
					
				}
				else { EnableAllControls(this); }
				try {
					coversTableAdapter.FillByInvno(dsProdutn.covers, Invno);
					//coversTableAdapter.Fill(dsProdutn.covers, this.Schcode);
					coverdetailTableAdapter.FillByInvno(dsProdutn.coverdetail, Invno);
				} catch(Exception ex) {

					MbcMessageBox.Error(ex.Message, "");
					return;
				};
                var aaaa = coverdetailBindingSource .Count;

                if ((DataRowView)coversBindingSource1.Current != null)
                {
                    var row = (DataRowView)coversBindingSource1.Current;
                    var a = row["specinst"].ToString();
                    if (dsProdutn.covers.Count < 1)
                    {
                        DisableControls(this.tbProdutn.TabPages[2]);
                    }
                    else { EnableAllControls(this.tbProdutn.TabPages[2]); }
                }
				try {
					wipTableAdapter.FillByInvno(dsProdutn.wip, Invno);
                                     
					wipDetailTableAdapter.Fill(dsProdutn.WipDetail,"", Invno);
				} catch(Exception ex) {

					MbcMessageBox.Error(ex.Message, "");
					return;
				}
				
				if (dsProdutn.wip.Count < 1)
				{
					DisableControls(this.tbProdutn.TabPages[1]);
				}
				else { EnableAllControls(this.tbProdutn.TabPages[1]); }
				try {
					this.partbkTableAdapter.FillBy(dsProdutn.partbk, Invno);
					this.partBkDetailTableAdapter.FillBy(dsProdutn.PartBkDetail, Invno);
				}catch(Exception ex) {
					MbcMessageBox.Error(ex.Message, "");
					return;
				}
				
				if (dsProdutn.partbk.Count < 1)
				{
					DisableControls(this.tbProdutn.TabPages[4]);
                    btnAddPartial.Visible = true;
                    EnableControls(btnAddPartial);
                  
                }
				else { EnableAllControls(
                    this.tbProdutn.TabPages[4]);
                    btnAddPartial.Visible = false;
                }
				try         {
					ptbkbTableAdapter.FillBy(dsProdutn.ptbkb, Invno);
					prtbkbdetailTableAdapter.FillBy(dsProdutn.prtbkbdetail, Invno);
                    var a = prtbkbdetailBindingSource.Count;
				} catch (Exception ex) {
					MbcMessageBox.Error(ex.Message, "");
					return;
				}
				
				if (dsProdutn.ptbkb.Count < 1)
				{
					DisableControls(this.tbProdutn.TabPages[5]);
                    btnCDAdd.Visible = true;
                    EnableControls(btnCDAdd);
				}
				else {
                    EnableAllControls(this.tbProdutn.TabPages[5]);
                    btnCDAdd.Visible = false;
                }

                produtnBindingSource.ResetBindings(true);
			}
            try
            {
                reOrderTableAdapter.Fill(dsProdutn.ReOrder, Invno);
               reorderDetailTableAdapter.Fill(dsProdutn.ReorderDetail, Invno);
               
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message, "");
                return;
            }

            if (reOrderBindingSource.Count < 1)
            {
                DisableControls(this.tbProdutn.TabPages[6]);
                btnAddReorder.Visible  = true;
                EnableControls(btnAddReorder);
            }
            else
            {
                EnableAllControls(this.tbProdutn.TabPages[6]);
                btnAddReorder.Visible =false;
            }

            //disable deadline in if not empty and not admin
            if (!string.IsNullOrEmpty(kitrecvdDateTimePicker.Date))
            {
                
                var supRole = new StringCollection();
                    supRole.AddRange(new String[] {"SA","Administrator" });
               
                if (!this.ApplicationUser.IsInOneOfRoles(supRole))
                {
                    dedayoutDateBox.Enabled = false;
                }
                
            }
            btnMeridianTicket.Visible = this.Company == "MER";
            btnCoverTicket.Visible = this.Company == "MBC";
        }

       
        

		public override ApiProcessingResult<bool> Save()
		{
			var processingResult = new ApiProcessingResult<bool>();
			switch (tbProdutn.SelectedIndex)
			{
				case 0:
					var produtnResult = SaveProdutn();
                    

                    if (produtnResult.IsError) {
						MbcMessageBox.Error(produtnResult.Errors[0].ErrorMessage, "");
						processingResult = produtnResult;
					}

						break;
				case 1:
					{
						var wipResult = SaveWip();
						
						if (wipResult.IsError) {
							MbcMessageBox.Error(wipResult.Errors[0].ErrorMessage, "");
							processingResult = wipResult;
						}

						var produtnResult1 = SaveProdutn();
						if (produtnResult1.IsError) {
							MbcMessageBox.Error(produtnResult1.Errors[0].ErrorMessage, "");
							processingResult = produtnResult1;
						}
						break;
					}
				case 2:
					{
						var coverResult = SaveCovers();
						
						if (coverResult.IsError) {
							MbcMessageBox.Error(coverResult.Errors[0].ErrorMessage, "");
							processingResult = coverResult;
						}

						var produtnResult2 = SaveProdutn();
						if (produtnResult2.IsError) {
							MbcMessageBox.Error(produtnResult2.Errors[0].ErrorMessage, "");
							processingResult = produtnResult2;
						}
						break;
					}

				case 3:

					break;
				case 4:
					var partBkResult = SavePartBK();
				
					if (partBkResult.IsError) {
						MbcMessageBox.Error(partBkResult.Errors[0].ErrorMessage, "");
						processingResult = partBkResult;
					}

					var produtnResult3 = SaveProdutn();
					if (produtnResult3.IsError) {
						MbcMessageBox.Error(produtnResult3.Errors[0].ErrorMessage, "");
						processingResult = produtnResult3;
					}
				
				
					break;
				case 5:
					var ptBkBResult = SavePtBkB();
					
					if (ptBkBResult.IsError) {
						MbcMessageBox.Error(ptBkBResult.Errors[0].ErrorMessage, "");
						processingResult = ptBkBResult;
					}

					var produtnResult4 = SaveProdutn();
					if (produtnResult4.IsError) {
						MbcMessageBox.Error(produtnResult4.Errors[0].ErrorMessage, "");
						processingResult = produtnResult4;
					}
			
					break;
                case 6:
                    var reOrderResult =SaveReOrder();

                    if (reOrderResult.IsError)
                    {
                        MbcMessageBox.Error(reOrderResult.Errors[0].ErrorMessage, "");
                        processingResult = reOrderResult;
                    }

                    
                    break;
            }
			return processingResult;
		}
		private bool SaveOrStop()
		{
			bool retval = true;
			switch (tbProdutn.SelectedIndex)
			{
				case 0:
					var produtnResult = SaveProdutn();
					if (produtnResult.IsError)
					{
						var result = MessageBox.Show("Production record could not be saved"+produtnResult.Errors[0].ErrorMessage+" Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result == DialogResult.No)
						{
							retval = false;

						}
					}
					break;

				case 1:
					var wipResult = SaveWip();
					if (wipResult.IsError)
					{
						var result = MessageBox.Show("Wip record could not be saved:"+ wipResult.Errors[0].ErrorMessage + " Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result == DialogResult.No)
						{
							retval = false;
						}
					}
					break;

				case 2:
					var coverResult = SaveCovers();
					if (coverResult.IsError)
					{
						var result = MessageBox.Show("Cover record could not be saved:" + coverResult.Errors[0].ErrorMessage + " Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result == DialogResult.No)
						{
							retval = false; ;
						}
					}
					break;
				case 4:
					var partBkResult = SavePartBK();
					if (partBkResult.IsError)
					{
						var result = MessageBox.Show("Partial Book(A) could not be saved:" + partBkResult.Errors[0].ErrorMessage + " Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result == DialogResult.No)
						{
							retval = false;
						}
					}
					break;

				case 5:
					var ptBkBResult = SavePtBkB();
					if (ptBkBResult.IsError)
					{
						var result = MessageBox.Show("Photos On CD record could not be saved:" + ptBkBResult.Errors[0].ErrorMessage + " Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (result == DialogResult.No)
						{
							retval = false;
						}
					}
					break;

				case 6:
					
					break;
			}

			return retval;

		}
		private ApiProcessingResult<bool> SavePartBK()
		{
			var processintResult = new ApiProcessingResult<bool>();
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
						processintResult.IsError = true;
						processintResult.Errors.Add(new ApiProcessingError("Partial Book A record failed to update:" + ex.Message, "Partial Book A record failed to update:" + ex.Message,""))
;					}
				}
			}
			else {
				processintResult.IsError = true;
				processintResult.Errors.Add(new ApiProcessingError("PartBk record failed to update.", "PartBk record failed to update.", "")); }

			return processintResult;
		}
		private ApiProcessingResult<bool> SavePtBkB()
		{
			var processingResult = new ApiProcessingResult<bool>();
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
						processingResult.IsError = true;
						processingResult.Errors.Add(new ApiProcessingError("Photos On CD record failed to update:" + ex.Message, "Photos On CD record failed to update:" + ex.Message,""));
					}
				}
			}
			else {
				processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError("Photos On CD record failed to validate.", "Photos On CD record failed to validate.", ""));
			}

			return processingResult;
		}
		private ApiProcessingResult<bool> SaveProdutn()
		{
			var processingResult = new ApiProcessingResult<bool>();
           
            
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
					

					}
					catch (DBConcurrencyException dbex)
					{
						DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsProdutn.produtnRow)(dbex.Row), ref dsProdutn);
						if (result == DialogResult.Yes) { SaveProdutn(); }
					}
					catch (Exception ex)
					{
						
						
						ex.ToExceptionless()
					   .SetMessage("Production record failed to update:" + ex.Message)
					   .Submit();
						processingResult.IsError = true;
						processingResult.Errors.Add(new ApiProcessingError("Production record failed to update:" + ex.Message, "Production record failed to update:" + ex.Message,""));
					}
				} else {
					processingResult.IsError = true;
					processingResult.Errors.Add(new ApiProcessingError("Production record failed to validate.", "Production record failed to validate.",""));
				}
			}
			
			return processingResult;
		}
		private ApiProcessingResult<bool> SaveWip()
		{
			var processingResult = new ApiProcessingResult<bool>();
			if (dsProdutn.wip.Count > 0)
			{

				//  if (this.Validate()) {
				try
				{
					this.wipBindingSource.EndEdit();
					var a = wipTableAdapter.Update(dsProdutn.wip);
					//must refill so we get updated time stamp so concurrency is not thrown
					wipTableAdapter.FillByInvno(dsProdutn.wip,Invno);
					
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
					processingResult.IsError = true;
					processingResult.Errors.Add(new ApiProcessingError("Wip record failed to update:" + ex.Message, "Wip record failed to update:" + ex.Message, ""));
					
				}
				// }
			}
			else {
				processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError("Wip Record failed to validate.", "Wip Record failed to validate.", ""));
			}

			return processingResult;

		}
		private ApiProcessingResult<bool> SaveCovers()
		{
			var processingResult = new ApiProcessingResult<bool>();
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
						processingResult.IsError = true;
						processingResult.Errors.Add(new ApiProcessingError(ex.Message,ex.Message,""));
					}
				}
			}
			else {
                var a = dsProdutn.Tables["covers"].GetErrors();
                processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError("Cover record failed to validate", "Cover record failed to validate", ""));
			}

			return processingResult;
		}
        private ApiProcessingResult<bool> SaveReOrder()
        {
            var processingResult = new ApiProcessingResult<bool>();
            if (dsProdutn.ReOrder.Count > 0)
            {
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    try
                    {
                        this.reOrderBindingSource.EndEdit();
                    
                        var a = reOrderTableAdapter.Update(dsProdutn.ReOrder);
                        //must refill so we get updated time stamp so concurrency is not thrown
                        reOrderTableAdapter.Fill(dsProdutn.ReOrder, Invno);

                    }
                    catch (DBConcurrencyException dbex)
                    {
                        MbcMessageBox.Information("Another user has edited the reorder data since you have opened the record. Refresh your data and then apply your edits.");
                        DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsProdutn.coversRow)(dbex.Row), ref dsProdutn);
                        if (result == DialogResult.Yes) { SaveCovers(); };
                    }
                    catch (Exception ex)
                    {
                        ex.ToExceptionless()
                       .SetMessage("ReOrder record failed to update:" + ex.Message)
                       .Submit();
                        processingResult.IsError = true;
                        processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
                    }
                }
            }
            else
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("ReOrder record failed to validate", "ReOrder record failed to validate", ""));
            }

            return processingResult;
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
		
		private void frmProdutn_Paint(object sender, PaintEventArgs e)
		{

			try { this.Text = "Production-" + lblSchoolName.Text.Trim() + " (" + this.Schcode.Trim() + ")"; }
			catch
			{

			}
		}

		private void btnCalcDeadLine_Click(object sender, EventArgs e)
		{
            if (!String.IsNullOrEmpty(dedayinDateBox.Date))
            {
                int wks = 0;
                int days = 0;
                int.TryParse(txtWeeks.Text, out wks);
                int.TryParse(txtDays.Text, out days);


                var numDays = (wks * 5) + (days);
                if (dedayinDateBox.Date != null)
                {
                    var result = CalulateBusinessDay.BusDaySubtract((DateTime)dedayinDateBox.DateValue, numDays);
                    if (result != null)
                    {
                        dedayinDateBox.Date = result.ToShortDateString();
                    }
                }
            }
            else { MessageBox.Show("Please enter a Deadline out Date."); }


        }

		private void btnCalCS_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(kitrecvdDateTimePicker.Date))
			{
				int wks = 0;
				int days = 0;
				int.TryParse(txtWeeks.Text, out wks);
				int.TryParse(txtDays.Text, out days);


				var numDays = (wks * 5) + (days);
                DateTime vKitrecvd;
                if (kitrecvdDateTimePicker.Date != null)
                {
                     vKitrecvd = DateTime.Parse(kitrecvdDateTimePicker.Date);
                    var result = CalulateBusinessDay.BusDayAdd(vKitrecvd, numDays);
				  
                    cstsvcdteDateTimePicker.Date= result.ToShortDateString();
                    cstsvcdteDateTimePicker.Focus();

                }
				

			}
		}

		private void btnDeadLineInfo_Click(object sender, EventArgs e)
		{
			//var emailHelper = new EmailHelper();
			//string subject = this.Schcode + " " + lblSchoolName.Text.Trim() + " " + "Memorybook Deadlines";
			//string body = "Here is your Memory Book deadline information.<br/><br/>Pages due in plant " + ((DateTime)dedayinDateTimePicker.Value).ToShortDateString() + "<br/>Delivery date " +((DateTime) dedayoutDateTimePicker.Value).ToShortDateString();
			//EmailType type = EmailType.Blank;
			//if (CurrentCompany == "MBC")
			//{
			//	type = EmailType.Mbc;
			//}
			//else if (CurrentCompany == "MER")
			//{
			//	type = EmailType.Meridian;
			//}

			//emailHelper.SendOutLookEmail(subject, AllEmails, "", body, EmailType.Mbc);
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
								MessageBox.Show("Your Production Number (Binding) First Digit is not the same as this value... Press OK to continue...It is being changed!", "Binding Type Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

										lblProdNo.Text = txtPerfbind.Text + (lblProdNo.Text.Trim());
									


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
		//private void btnProdSrch_Click(object sender, EventArgs e)
		//{
		//	if (string.IsNullOrEmpty(txtProdNoSrch.Text))
		//	{
		//		return;
		//	}
		//	switch (tbProdutn.SelectedIndex)
		//	{
		//		case 0:
		//			var produtnResult = SaveProdutn();
		//			if (produtnResult.IsError)
		//			{
		//				var result1 = MessageBox.Show("Production record could not be saved:"+produtnResult.Errors[0].ErrorMessage+" Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
		//				if (result1 == DialogResult.No)
		//				{

		//					return;
		//				}
		//			}
		//			break;



		//	}

		//	var sqlQuery = new SQLQuery();
		//	string query = "Select prodno,invno,schcode from produtn where prodno=@prodno";
		//	var parameters = new SqlParameter[] { new SqlParameter("@prodno", txtProdNoSrch.Text) };
		//	var result = sqlQuery.ExecuteReaderAsync(CommandType.Text, query, parameters);
		//	if (result.Rows.Count > 0)
		//	{
		//		Schcode = result.Rows[0]["schcode"].ToString();
		//		Invno = int.Parse(result.Rows[0]["invno"].ToString());// will always have a invno
		//		Fill();
		//	}
		//	else { MessageBox.Show("Record was not found.", "Production Number Search", MessageBoxButtons.OK, MessageBoxIcon.Information); }
		//	frmProdutn_Paint(this, null);
		//}
        private void wipDetailDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			DataRowView row = (DataRowView)wipDetailBindingSource.Current;
			int id = (int)row["id"];
			int invno = (int)row["invno"];
			frmEditWip frmeditWip = new frmEditWip(id, invno);
			var result = frmeditWip.ShowDialog();
			if (result == DialogResult.OK)
			{
				//wipDetailTableAdapter.FillBy(dsProdutn.WipDetail, Invno);
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
				//wipDetailTableAdapter.FillBy(dsProdutn.WipDetail, Invno);
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
				//wipDetailTableAdapter.FillBy(dsProdutn.WipDetail, Invno);
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
      
		//private void btnSchoolSearch_Click(object sender, EventArgs e)
		//{
		//	if (string.IsNullOrEmpty(txtSchNamesrch.Text.Trim()))
		//	{
		//		return;
		//	}    
			
		//		//var records = this.custTableAdapter.FillBySchname(this.dsCust.cust,txtSchNamesrch.Text);
		//		var sqlQuery = new SQLQuery();
		//		var queryString = @"SELECT P.ProdNo,P.Invno, C.Schcode, C.Schname,C.Schcity,C.Schstate,C.Schzip 
		//					 FROM Cust C
		//						Left Join Quotes Q ON C.Schcode=Q.Schcode
		//						Left Join Produtn P On Q.Invno=P.Invno
  //                            WHERE P.Invno IS NOT NULL AND (C.Schname LIKE @Schname + '%')
  //                            ORDER BY Schname,Invno";
		//		SqlParameter[] parameters = new SqlParameter[] {
		//	   new SqlParameter("@Schname",txtSchNamesrch.Text.Trim())
		//	};
		//		var dataResult = sqlQuery.ExecuteReaderAsync<ProdutnSchoolNameSearchModel>(CommandType.Text, queryString, parameters);
		//		var records = (List<ProdutnSchoolNameSearchModel>)dataResult;
		//	if (records == null || records.Count < 1)
		//		{
				

		//			MessageBox.Show("No Records were found with this criteria.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//		}
		//		else if (records.Count > 1)
		//		{
			
		//			//more than one record select which one you want

		//			this.Cursor = Cursors.AppStarting;
					
		//			frmProdutnSelctCust frmProdutnSelectCust = new frmProdutnSelctCust(records);
		//			DialogResult result = frmProdutnSelectCust.ShowDialog();
		//			this.Cursor = Cursors.Default;
		//			if (result != DialogResult.Cancel)
		//			{
		//			if (frmProdutnSelectCust.retval==0)
		//			{
		//				return;
		//			}
		//			this.Invno = frmProdutnSelectCust.retval;
		//			this.Fill();
		//			}
					
		//		}
		//		txtSchNamesrch.Text = "";
		//	    frmProdutn_Paint(this, null);
			
		//}

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
            if (string.IsNullOrEmpty(cstsvcdteDateTimePicker.Date))
            {
                processingResult.Errors.Add(new ApiProcessingError("Customer Service Date is empty", "Customer Service Date is empty", ""));
                processingResult.IsError = true;
                return processingResult;

            }
           
            var sqlClient = new SQLCustomClient();
            sqlClient.ClearParameters();
            sqlClient.CommandText(@"SELECT ProdType,bktype As BookType,prmsdte AS PromiseDate,wrndte AS WarnDate,prshpdte As ProjectedShipDate
                                                  ,l_dtoprod,l_dwdr1,l_wdr2,l_wdr3,l_wdr4,l_wdr5,l_wdr6,l_wdr7,l_wdr8,l_wdr9,l_wdr10,l_wdr11,l_wdr12,l_wdr13
                                                  ,l_wdr14,l_wdr15,l_wdr16,l_wdr17,l_wdr18,l_wdr19,l_wdr20,l_wdr21,l_wdr22,l_wdr23,l_wdr24,l_wdr25,l_wdr26,l_wdr27
                                                  ,l_wdr28,l_wdr29,l_wdr30,l_wdr31,l_wdr32,l_wdr33,l_wdr34,l_wdr35,l_wdr36,l_wdr37,l_wdr38,l_wdr39,l_wdr40,l_wdr41
                                                  ,l_wdr42,l_wdr43,l_wdr44,l_wdr45,l_wdr46,l_wdr47,l_wdr48,l_wdr49,l_wdr50
                                                FROM WipDats
                                                 WHERE ProdType=@ProdType");
            var prodRow = (DataRowView)produtnBindingSource.Current;
            if (!prodRow.Row.IsNull("bkstd") && (bool)prodRow["bkstd"])
            {
                sqlClient.AddParameter("@ProdType", "Standard");

            }
            else if (!prodRow.Row.IsNull("bk9") && (bool)prodRow["bk9"])
            {
                sqlClient.AddParameter("@ProdType", "Bk9");
            }
            else if (!prodRow.Row.IsNull("bk10") && (bool)prodRow["bk10"])
            {
                sqlClient.AddParameter("@ProdType", "Bk10");
            }
            else if (!prodRow.Row.IsNull("bk11") && (bool)prodRow["bk11"])
            {
                sqlClient.AddParameter("@ProdType", "Bk11");
            }
            else if (!prodRow.Row.IsNull("bk12") && (bool)prodRow["bk12"])
            {
                sqlClient.AddParameter("@ProdType", "Bk12");
            }
            else if (!prodRow.Row.IsNull("bkhard") && (bool)prodRow["bkhard"])
            {
                sqlClient.AddParameter("@ProdType", "Hbk");
            }
            else if (!prodRow.Row.IsNull("bkcoil") && (bool)prodRow["bkcoil"])
            {
                sqlClient.AddParameter("@ProdType", "Cbk");
            }
            else if (!prodRow.Row.IsNull("allclrck") && (bool)prodRow["allclrck"])
            {
                sqlClient.AddParameter("@ProdType", "ClrBk");
            }
            else if (!prodRow.Row.IsNull("milled") && (bool)prodRow["milled"])
            {
                sqlClient.AddParameter("@ProdType", "MillBk");
            }
            else
            {
                //Standard
                sqlClient.AddParameter("@ProdType", "Standard");
            }
            var wipDatsResult = sqlClient.Select<WipDats>();
            if (wipDatsResult.IsError)
            {

                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("WIP not updated, error retrieving wipdats:" + wipDatsResult.Errors[0].ErrorMessage, "WIP not updated, error retrieving wipdats:" + wipDatsResult.Errors[0].ErrorMessage, ""));
                return processingResult;
            }
            var vWipDats = (WipDats)wipDatsResult.Data;
            decimal[] wCalc = new decimal[50];

            string vBooktype = txtBookType.Text.Trim();

            string commandText = "";
            DateTime? custSvcDate;
            if (cstsvcdteDateTimePicker.Date==null)
            {
                custSvcDate = null;
            }
            else
            {
                custSvcDate = DateTime.Parse(cstsvcdteDateTimePicker.Date);
            }
            if (vWipDats.PromiseDate != 0)
            {

                sqlClient.ClearParameters();
                sqlClient.AddParameter("@prmsdate", CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, vWipDats.PromiseDate));
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

            if (vWipDats.l_dtoprod != 0)
            {
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@dtoprod", CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, vWipDats.l_dtoprod));
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
            if (vWipDats.ProjectedShipDate != 0)
            {
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@prshpdte", CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, vWipDats.ProjectedShipDate));
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


                var updateResult = await UpdateWipDetailCall(50, CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, vWipDats.ProjectedShipDate), lblInvno.Text);

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
                sqlClient.AddParameter("@prshpdte", CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, vWipDats.ProjectedShipDate));
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



                var updateResult = await UpdateWipDetailCall(50, CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, vWipDats.ProjectedShipDate), lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Database error. #50a", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.WarnDate != 0)
            {
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@warndate", CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, vWipDats.WarnDate));
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

            DateTime? ProductionShipDate = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, vWipDats.PromiseDate);
            if (ProductionShipDate == null)
            {
                processingResult.IsError = true;
                return processingResult;
            }
            wCalc[49] = vWipDats.l_wdr49 + vWipDats.PromiseDate;

            if (vWipDats.l_wdr49 != 0)
            {
                wCalc[48] = vWipDats.l_wdr49 + wCalc[49];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[49], MidpointRounding.ToEven)));
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
                wCalc[48] = vWipDats.l_wdr49 + wCalc[49];

                var updateResult = await UpdateWipDetailCall(49, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #49", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }

            }

            if (vWipDats.l_wdr48 != 0)
            {
                wCalc[47] = vWipDats.l_wdr48 + wCalc[48];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[48], MidpointRounding.ToEven)));
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
                wCalc[47] = vWipDats.l_wdr48 + wCalc[48];

                var updateResult = await UpdateWipDetailCall(48, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #48", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            if (vWipDats.l_wdr47 != 0)
            {
                wCalc[46] = vWipDats.l_wdr47 + wCalc[47];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[47], MidpointRounding.ToEven)));
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
                wCalc[46] = vWipDats.l_wdr47 + wCalc[47];

                var updateResult = await UpdateWipDetailCall(47, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #47", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }

            }

            if (vWipDats.l_wdr46 != 0)
            {
                wCalc[45] = vWipDats.l_wdr46 + wCalc[46];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[46], MidpointRounding.ToEven)));
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
                wCalc[45] = vWipDats.l_wdr46 + wCalc[46];

                var updateResult = await UpdateWipDetailCall(46, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #46", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            if (vWipDats.l_wdr45 != 0)
            {
                wCalc[44] = vWipDats.l_wdr45 + wCalc[45];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[45], MidpointRounding.ToEven)));
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
                wCalc[44] = vWipDats.l_wdr45 + wCalc[45];

                var updateResult = await UpdateWipDetailCall(45, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #45", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            if (vWipDats.l_wdr44 != 0)
            {
                wCalc[43] = vWipDats.l_wdr44 + wCalc[4];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[44], MidpointRounding.ToEven)));
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
                wCalc[43] = vWipDats.l_wdr44 + wCalc[44];

                var updateResult = await UpdateWipDetailCall(44, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #44", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }

            }

            if (vWipDats.l_wdr43 != 0)
            {
                wCalc[42] = vWipDats.l_wdr43 + wCalc[4];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[43], MidpointRounding.ToEven)));
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
                wCalc[42] = vWipDats.l_wdr43 + wCalc[43];

                var updateResult = await UpdateWipDetailCall(43, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #43", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }

            }
            if (vWipDats.l_wdr42 != 0)
            {
                wCalc[41] = vWipDats.l_wdr42 + wCalc[4];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[42], MidpointRounding.ToEven)));
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
                wCalc[41] = vWipDats.l_wdr42 + wCalc[42];

                var updateResult = await UpdateWipDetailCall(42, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #42", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }

            }

            if (vWipDats.l_wdr41 != 0)
            {
                wCalc[40] = vWipDats.l_wdr41 + wCalc[41];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[41], MidpointRounding.ToEven)));
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
                wCalc[40] = vWipDats.l_wdr41 + wCalc[41];

                var updateResult = await UpdateWipDetailCall(41, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #41", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }

            }

            if (vWipDats.l_wdr40 != 0)
            {
                wCalc[39] = vWipDats.l_wdr40 + wCalc[40];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[40], MidpointRounding.ToEven)));
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
                wCalc[39] = vWipDats.l_wdr40 + wCalc[40];

                var updateResult = await UpdateWipDetailCall(40, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #40", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr39 != 0)
            {
                wCalc[38] = vWipDats.l_wdr39 + wCalc[39];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[39], MidpointRounding.ToEven)));
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
                wCalc[38] = vWipDats.l_wdr39 + wCalc[39];

                var updateResult = await UpdateWipDetailCall(39, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #39", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr38 != 0)
            {
                wCalc[37] = vWipDats.l_wdr38 + wCalc[38];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[38], MidpointRounding.ToEven)));
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
                wCalc[37] = vWipDats.l_wdr38 + wCalc[38];

                var updateResult = await UpdateWipDetailCall(38, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #38", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr37 != 0)
            {
                wCalc[36] = vWipDats.l_wdr37 + wCalc[37];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[37], MidpointRounding.ToEven)));
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
                wCalc[36] = vWipDats.l_wdr37 + wCalc[37];

                var updateResult = await UpdateWipDetailCall(37, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #37", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr36 != 0)
            {
                wCalc[35] = vWipDats.l_wdr36 + wCalc[36];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[36], MidpointRounding.ToEven)));
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
                wCalc[35] = vWipDats.l_wdr36 + wCalc[36];

                var updateResult = await UpdateWipDetailCall(36, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #36", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr35 != 0)
            {
                wCalc[34] = vWipDats.l_wdr35 + wCalc[35];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[35], MidpointRounding.ToEven)));
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
                wCalc[34] = vWipDats.l_wdr35 + wCalc[35];

                var updateResult = await UpdateWipDetailCall(35, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #35", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr34 != 0)
            {
                wCalc[33] = vWipDats.l_wdr34 + wCalc[34];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[34], MidpointRounding.ToEven)));
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
                wCalc[33] = vWipDats.l_wdr34 + wCalc[34];

                var updateResult = await UpdateWipDetailCall(34, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #34", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr33 != 0)
            {
                wCalc[32] = vWipDats.l_wdr33 + wCalc[33];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[33], MidpointRounding.ToEven)));
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
                wCalc[32] = vWipDats.l_wdr33 + wCalc[33];

                var updateResult = await UpdateWipDetailCall(33, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #33", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr32 != 0)
            {
                wCalc[31] = vWipDats.l_wdr32 + wCalc[32];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[32], MidpointRounding.ToEven)));
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
                wCalc[31] = vWipDats.l_wdr32 + wCalc[32];

                var updateResult = await UpdateWipDetailCall(32, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #32", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr31 != 0)
            {
                wCalc[30] = vWipDats.l_wdr31 + wCalc[31];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[31], MidpointRounding.ToEven)));
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
                wCalc[30] = vWipDats.l_wdr31 + wCalc[31];

                var updateResult = await UpdateWipDetailCall(31, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #31", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr30 != 0)
            {
                wCalc[29] = vWipDats.l_wdr30 + wCalc[30];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[30], MidpointRounding.ToEven)));
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
                wCalc[29] = vWipDats.l_wdr30 + wCalc[30];

                var updateResult = await UpdateWipDetailCall(30, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #30", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr29 != 0)
            {
                wCalc[28] = vWipDats.l_wdr29 + wCalc[29];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[29], MidpointRounding.ToEven)));
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
                wCalc[28] = vWipDats.l_wdr29 + wCalc[29];

                var updateResult = await UpdateWipDetailCall(29, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #29", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr28 != 0)
            {
                wCalc[27] = vWipDats.l_wdr28 + wCalc[28];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[28], MidpointRounding.ToEven)));
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
                wCalc[27] = vWipDats.l_wdr28 + wCalc[28];

                var updateResult = await UpdateWipDetailCall(28, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #28", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr27 != 0)
            {
                wCalc[26] = vWipDats.l_wdr27 + wCalc[27];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[27], MidpointRounding.ToEven)));
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
                wCalc[26] = vWipDats.l_wdr27 + wCalc[27];

                var updateResult = await UpdateWipDetailCall(27, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #27", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr26 != 0)
            {
                wCalc[25] = vWipDats.l_wdr26 + wCalc[26];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[26], MidpointRounding.ToEven)));
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
                wCalc[25] = vWipDats.l_wdr26 + wCalc[26];

                var updateResult = await UpdateWipDetailCall(26, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #26", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr25 != 0)
            {
                wCalc[24] = vWipDats.l_wdr25 + wCalc[25];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[25], MidpointRounding.ToEven)));
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
                wCalc[24] = vWipDats.l_wdr25 + wCalc[25];

                var updateResult = await UpdateWipDetailCall(25, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #25", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr24 != 0)
            {
                wCalc[23] = vWipDats.l_wdr24 + wCalc[24];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[24], MidpointRounding.ToEven)));
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
                wCalc[23] = vWipDats.l_wdr24 + wCalc[24];

                var updateResult = await UpdateWipDetailCall(24, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #24", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr23 != 0)
            {
                wCalc[22] = vWipDats.l_wdr23 + wCalc[23];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[23], MidpointRounding.ToEven)));
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
                wCalc[22] = vWipDats.l_wdr23 + wCalc[23];

                var updateResult = await UpdateWipDetailCall(23, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #23", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr22 != 0)
            {
                wCalc[21] = vWipDats.l_wdr22 + wCalc[22];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[22], MidpointRounding.ToEven)));
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
                wCalc[21] = vWipDats.l_wdr22 + wCalc[22];

                var updateResult = await UpdateWipDetailCall(22, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #22", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr21 != 0)
            {
                wCalc[20] = vWipDats.l_wdr21 + wCalc[21];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[21], MidpointRounding.ToEven)));
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
                wCalc[20] = vWipDats.l_wdr21 + wCalc[21];

                var updateResult = await UpdateWipDetailCall(21, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #21", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr20 != 0)
            {
                wCalc[19] = vWipDats.l_wdr20 + wCalc[20];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[20], MidpointRounding.ToEven)));
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
                wCalc[19] = vWipDats.l_wdr20 + wCalc[20];

                var updateResult = await UpdateWipDetailCall(20, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #20", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr19 != 0)
            {
                wCalc[18] = vWipDats.l_wdr19 + wCalc[19];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[19], MidpointRounding.ToEven)));
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
                wCalc[18] = vWipDats.l_wdr19 + wCalc[19];

                var updateResult = await UpdateWipDetailCall(19, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #19", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr18 != 0)
            {
                wCalc[17] = vWipDats.l_wdr18 + wCalc[18];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[18], MidpointRounding.ToEven)));
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
                wCalc[17] = vWipDats.l_wdr18 + wCalc[18];

                var updateResult = await UpdateWipDetailCall(18, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #18", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr17 != 0)
            {
                wCalc[16] = vWipDats.l_wdr17 + wCalc[17];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[17], MidpointRounding.ToEven)));
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
                wCalc[16] = vWipDats.l_wdr17 + wCalc[17];

                var updateResult = await UpdateWipDetailCall(17, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #17", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr16 != 0)
            {
                wCalc[15] = vWipDats.l_wdr16 + wCalc[16];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[16], MidpointRounding.ToEven)));
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
                wCalc[15] = vWipDats.l_wdr16 + wCalc[16];

                var updateResult = await UpdateWipDetailCall(16, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #16", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr15 != 0)
            {
                wCalc[14] = vWipDats.l_wdr15 + wCalc[15];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[15], MidpointRounding.ToEven)));
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
                wCalc[15] = vWipDats.l_wdr15 + wCalc[15];

                var updateResult = await UpdateWipDetailCall(15, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #15", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr14 != 0)
            {
                wCalc[13] = vWipDats.l_wdr14 + wCalc[14];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[14], MidpointRounding.ToEven)));
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
                wCalc[13] = vWipDats.l_wdr14 + wCalc[14];

                var updateResult = await UpdateWipDetailCall(14, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #14", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr13 != 0)
            {
                wCalc[12] = vWipDats.l_wdr13 + wCalc[13];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[13], MidpointRounding.ToEven)));
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
                wCalc[12] = vWipDats.l_wdr13 + wCalc[13];

                var updateResult = await UpdateWipDetailCall(13, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #13", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }
            if (vWipDats.l_wdr12 != 0)
            {
                wCalc[11] = vWipDats.l_wdr12 + wCalc[12];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[12], MidpointRounding.ToEven)));
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
                wCalc[11] = vWipDats.l_wdr12 + wCalc[12];

                var updateResult = await UpdateWipDetailCall(12, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #12", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr11 != 0)
            {
                wCalc[10] = vWipDats.l_wdr11 + wCalc[11];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[11], MidpointRounding.ToEven)));
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
                wCalc[10] = vWipDats.l_wdr11 + wCalc[11];

                var updateResult = await UpdateWipDetailCall(11, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #11", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr10 != 0)
            {
                wCalc[9] = vWipDats.l_wdr10 + wCalc[10];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[10], MidpointRounding.ToEven)));
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
                wCalc[10] = vWipDats.l_wdr10 + wCalc[10];

                var updateResult = await UpdateWipDetailCall(10, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr9 != 0)
            {
                wCalc[8] = vWipDats.l_wdr9 + wCalc[9];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[9], MidpointRounding.ToEven)));
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
                wCalc[8] = vWipDats.l_wdr9 + wCalc[9];

                var updateResult = await UpdateWipDetailCall(9, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #9", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr8 != 0)
            {
                wCalc[7] = vWipDats.l_wdr8 + wCalc[8];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[8], MidpointRounding.ToEven)));
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
                wCalc[7] = vWipDats.l_wdr8 + wCalc[8];

                var updateResult = await UpdateWipDetailCall(8, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #8", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr7 != 0)
            {
                wCalc[6] = vWipDats.l_wdr7 + wCalc[7];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[7], MidpointRounding.ToEven)));
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
                wCalc[6] = vWipDats.l_wdr7 + wCalc[7];

                var updateResult = await UpdateWipDetailCall(7, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #7", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr6 != 0)
            {
                wCalc[5] = vWipDats.l_wdr6 + wCalc[6];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[6], MidpointRounding.ToEven)));
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
                wCalc[6] = vWipDats.l_wdr6 + wCalc[6];

                var updateResult = await UpdateWipDetailCall(6, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr5 != 0)
            {
                wCalc[4] = vWipDats.l_wdr5 + wCalc[5];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[5], MidpointRounding.ToEven)));
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
                wCalc[4] = vWipDats.l_wdr5 + wCalc[5];

                var updateResult = await UpdateWipDetailCall(5, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr4 != 0)
            {
                wCalc[3] = vWipDats.l_wdr4 + wCalc[4];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[4], MidpointRounding.ToEven)));
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
                wCalc[3] = vWipDats.l_wdr4 + wCalc[4];

                var updateResult = await UpdateWipDetailCall(4, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr3 != 0)
            {
                wCalc[2] = vWipDats.l_wdr3 + wCalc[3];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[3], MidpointRounding.ToEven)));
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
                wCalc[2] = vWipDats.l_wdr3 + wCalc[3];

                var updateResult = await UpdateWipDetailCall(3, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_wdr2 != 0)
            {
                wCalc[1] = vWipDats.l_wdr2 + wCalc[2];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[2], MidpointRounding.ToEven)));
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
                wCalc[1] = vWipDats.l_wdr2 + wCalc[2];

                var updateResult = await UpdateWipDetailCall(2, null, lblInvno.Text);
                if (updateResult.IsError)
                {
                    MessageBox.Show("Datbase error. #2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    processingResult.IsError = true;
                    return processingResult;
                }
            }

            if (vWipDats.l_dwdr1 != 0)
            {
                wCalc[0] = vWipDats.l_dwdr1 + wCalc[1];
                var vWdr = CalulateBusinessDay.PromiseDate((DateTime)custSvcDate, ((int)Math.Round(wCalc[1], MidpointRounding.ToEven)));
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
                wCalc[0] = vWipDats.l_dwdr1 + wCalc[1];

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
            produtnBindingSource.EndEdit();
            var result = this.WipUpdate();
            if (result.Result.IsError)
            {
                MbcMessageBox.Error(result.Result.Errors[0].ErrorMessage, "");
            }
        }

		

		private void btnMbo_Click(object sender, EventArgs e)
		{
		//	if (string.IsNullOrEmpty(txtMbo.Text))
		//	{
		//		return;
		//	}
		//	switch (tbProdutn.SelectedIndex)
		//	{
		//		case 0:
		//			var produtnResult = SaveProdutn();
		//			if (produtnResult.IsError)
		//			{
		//				var result1 = MessageBox.Show("Production record could not be saved:"+produtnResult.Errors[0].ErrorMessage+ " Continue?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		//				if (result1 == DialogResult.No) {

		//					return;
		//				}
					
		//			}
		//			break;

		//	}

		//	var sqlQuery = new SQLQuery();
		//	string query = "Select prodno,invno,schcode from produtn where jobno=@jobno";
		//	var parameters = new SqlParameter[] { new SqlParameter("@jobno", txtMbo.Text) };
		//	var result = sqlQuery.ExecuteReaderAsync(CommandType.Text, query, parameters);
		//	if (result.Rows.Count > 0)
		//	{
		//		Schcode = result.Rows[0]["schcode"].ToString();
		//		Invno = int.Parse(result.Rows[0]["invno"].ToString());// will always have a invno
		//		Fill();
		//	}
		//	else
		//	{ MessageBox.Show("Record was not found.", "Production MBO Search", MessageBoxButtons.OK, MessageBoxIcon.Information); }
		//	frmProdutn_Paint(this, null);
		}

		private void btnPrntMbOnline_Click(object sender, EventArgs e)
		{

		}

		private void shpdateDateTimePicker_Leave(object sender, EventArgs e)
		{
			ShippingEmail();
		}

		private void covertypeTextBox_Leave(object sender, EventArgs e)
		{
			string vDescription = "";
			if (CoverDescriptions == null || CoverDescriptions.Count == 0)
			{
				if (!GetCoverDescriptions())
				{
					MessageBox.Show("Could not retrieve Cover Descriptions.");
					return;
				}
			}
				int vIndex = CoverDescriptions.FindIndex(s=>s.CoverType.ToUpper()==txtCoverType.Text.ToUpper());
			if (vIndex > 0)
			{
				vDescription = CoverDescriptions[vIndex].CoverDescription;
			}
				switch (txtCoverType.Text.ToUpper())
				{
					case "":
						{
							txtCoverDescription.Text = "";
							break;
						}
					case "SPE":
						{
							txtCoverDescription.Text = "Special Cover";
							break;
						}
					case "MSOS":
						{ txtCoverDescription.Text = "My Story/Our Story";
						break;
						}
						
					default:
						{
							txtCoverDescription.Text = vDescription;
							break;
						}		

				}
		}
		private bool GetCoverDescriptions()
		{
			var sqlClient = new SQLCustomClient();
			sqlClient.CommandText(@"Select CoverType,CoverDescription FROM CoverDescriptions Order By CoverType ");
			var result = sqlClient.SelectMany<CoverDescriptions>();
			if (result.IsError)
			{ return false; }
			else
			{
				CoverDescriptions = (List<CoverDescriptions>)result.Data;

				return true;
			}

		}

		

		private void btnspCoverEmail_Click(object sender, EventArgs e)
		{
			var emailList = new List<string>();
			DataRowView row =(DataRowView) custBindingSource.Current;
			string vState = row["schstate"].ToString().Trim();
			string vcontEmail = row["contemail"] != null ? row["contemail"].ToString().Trim() : "";
			string vBcontEmail = row["bcontemail"] != null ? row["bcontemail"].ToString().Trim() : "";
			string vCcontEmail = row["ccontemail"] != null ? row["ccontemail"].ToString().Trim() : "";
			if (!string.IsNullOrEmpty(vcontEmail))
			{
				emailList.Add(vcontEmail);
			}
			if (!string.IsNullOrEmpty(vBcontEmail))
			{
				emailList.Add(vBcontEmail);
			}
			if (!string.IsNullOrEmpty(vCcontEmail))
			{
				emailList.Add(vCcontEmail);
			}
			var emailHelper = new EmailHelper();
			string subject = "Cover upload Site (account available the following business day by noon central time)";
			string body = @"Submission is easy: Go to the website https://ftp.memorybook.com <br /><br />
							<strong>Login:</strong>  <br />User Name: " + Schcode + @"m <br />
							Password:" + vState + @"65301<br /><br /><br />
			           Once logged in, drag and drop your files into the window. Please be sure to include a word document if you have additional instructions for your cover.";

		
			emailHelper.SendOutLookEmail(subject, emailList, "", body, EmailType.Mbc);
		}

		private void btnStandarCoverEmail_Click(object sender, EventArgs e)
		{
			var emailList = new List<string>();
			DataRowView custRow = (DataRowView)custBindingSource.Current;
			DataRowView prodRow = (DataRowView)produtnBindingSource.Current;
			string vSchname = custRow["schname"].ToString().Trim();
			string vJobNo= prodRow["jobno"]!=null ?prodRow["jobno"].ToString().Trim():"";
			string vcontEmail = custRow["contemail"]!=null?custRow["contemail"].ToString().Trim():"";
			string vBcontEmail = custRow["bcontemail"]!=null?custRow["bcontemail"].ToString().Trim():"";
			string vCcontEmail= custRow["ccontemail"]!=null? custRow["ccontemail"].ToString().Trim():"";
			if (!string.IsNullOrEmpty(vcontEmail))
			{
				emailList.Add(vcontEmail);
			}
			if (!string.IsNullOrEmpty(vBcontEmail))
			{
				emailList.Add(vBcontEmail);
			}
			if (!string.IsNullOrEmpty(vCcontEmail))
			{
				emailList.Add(vCcontEmail);
			}
			var emailHelper = new EmailHelper();
			string subject = Schcode + " " + vSchname + " Center Login Information https://coverorders.memorybook.com/login";
			string body = @"Order Center Login (Online account available the following business day by noon central time)<br /><br /> 
						Ordering is easy:  Go to the website https://coverorders.memorybook.com/login <br /><br /> 
						<strong>Login:</strong>  <br />User Name: "+ vJobNo +@"<br />
						Password: Adviser  <br /><br />
						<strong>Ordering your cover:</strong> <br /> &nbsp;&nbsp;•Select Yearbook covers  <br />&nbsp;&nbsp; •Choose cover type <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a. Standard cover  
						<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b. Customizable Standard covers (11 covers you can choose <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors and add a mascot)<br/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c. NEW Mascot Standard Covers, customizable with color <br/>  
						<br />Overprinting is available at no charge on standard covers with regular text size, color and font if information is submitted by November 15th.  Other modifications will be an additional charge. <br /><br />  
						<strong>Ordering Yearbook Promotional Materials </strong><br />Please note there are 4 customizable options: you can customize take home envelopes, hall posters and last chance fliers. If you are signed up for online parent pay you can create your fliers.<br />  
						&nbsp;&nbsp;•Select the yearbook promotional materials option<br />&nbsp;&nbsp;•Select the materials you would like to order<br />&nbsp;&nbsp;•Select the quantity and add to cart<br />  
						&nbsp;&nbsp;•Proceed to checkout <br /><br />
						Step by step instructions for all of the Order Center options can be found at http://www.memorybook.com/documents/standard_covers_online.pdf ";

			
			emailHelper.SendOutLookEmail(subject, emailList, "", body, EmailType.Mbc);
		}

		private void btnRecvHistory_Click(object sender, EventArgs e) {
			
				this.Cursor = Cursors.AppStarting;
				frmReceivingCard frmReceivingCard = new frmReceivingCard(this.ApplicationUser,this.Schcode,this.Invno);
				frmReceivingCard.MdiParent = this.MdiParent;
				frmReceivingCard.Show();
				this.Cursor = Cursors.Default;
			
		}

		private void laminatedTextBox_Leave(object sender, EventArgs e) {
			if (laminatedTextBox.Text != "M" && laminatedTextBox.Text != "N" && laminatedTextBox.Text != "G" && laminatedTextBox.Text != "") {
				laminatedTextBox.Focus();
			}
		}

        private void frmProdutn_Activated(object sender, EventArgs e)
        {
            try { frmMain.ShowSearchButtons(this.Name); } catch { }
        }

        private void frmProdutn_Deactivate(object sender, EventArgs e)
        {
            try { frmMain.HideSearchButtons(); } catch { }
        }

        #endregion
        public override void SchCodeSearch()
        {

            var produtnResult = SaveProdutn();
            if (produtnResult.IsError)
            {
                var result1 = MessageBox.Show("Production record could not be saved:" + produtnResult.Errors[0].ErrorMessage + " Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No)
                {

                    return;
                }
            }



            var currentSchool = this.Schcode;
           
            frmSearch frmSearch = new frmSearch("Schcode", "PRODUCTION", Schcode);

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
                    
                    Fill();
                    DataRowView current = (DataRowView)produtnBindingSource.Current;

                    this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
                    this.Schcode = current["Schcode"].ToString();
                }
			
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
             this.Cursor = Cursors.Default;
            frmProdutn_Paint(this, null);
            
            }

        }
        public override void SchnameSearch()
        {
            var produtnResult = SaveProdutn();
            if (produtnResult.IsError)
            {
                var result1 = MessageBox.Show("Production record could not be saved:" + produtnResult.Errors[0].ErrorMessage + " Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No)
                {

                    return;
                }
            }

            DataRowView currentrow = (DataRowView)custBindingSource.Current;
            var Schname = currentrow["schname"].ToString();
            frmSearch frmSearch = new frmSearch("Schname", "PRODUCTION", Schname);

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

                    Fill();
                    DataRowView current = (DataRowView)produtnBindingSource.Current;

                    this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
                    this.Schcode = current["Schcode"].ToString();
                }

                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                this.Cursor = Cursors.Default;
                frmProdutn_Paint(this, null);

            }
        }
        public override void OracleCodeSearch()
        {
           
            var produtnResult = SaveProdutn();
            if (produtnResult.IsError)
            {
                var result1 = MessageBox.Show("Production record could not be saved:" + produtnResult.Errors[0].ErrorMessage + " Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No)
                {

                    return;
                }
            }

            DataRowView currentrow = (DataRowView)custBindingSource.Current;
            var oraclecode = currentrow["oraclecode"].ToString();

            frmSearch frmSearch = new frmSearch("OracleCode", "PRODUCTION", oraclecode);

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

                    Fill();
                    DataRowView current = (DataRowView)produtnBindingSource.Current;

                    this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
                    this.Schcode = current["Schcode"].ToString();
                }

                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                this.Cursor = Cursors.Default;
                frmProdutn_Paint(this, null);

            }



        }
        public override void InvoiceNumberSearch()
        {

    
                var produtnResult = SaveProdutn();
            if (produtnResult.IsError)
            {
                var result1 = MessageBox.Show("Production record could not be saved:" + produtnResult.Errors[0].ErrorMessage + " Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No)
                {

                    return;
                }
            }

            DataRowView currentrow = (DataRowView)produtnBindingSource.Current;
            var invno = "";
            if (currentrow != null)
            {
                invno = currentrow["invno"].ToString();
            }

            frmSearch frmSearch = new frmSearch("INVNO", "PRODUCTION", invno);

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

                    Fill();
                    DataRowView current = (DataRowView)produtnBindingSource.Current;

                    this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
                    this.Schcode = current["Schcode"].ToString();
                }

                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                this.Cursor = Cursors.Default;
                frmProdutn_Paint(this, null);

            }



        }
        public override void ProdutnNoSearch()
        {

            var produtnResult = SaveProdutn();
            if (produtnResult.IsError)
            {
                var result1 = MessageBox.Show("Production record could not be saved:" + produtnResult.Errors[0].ErrorMessage + " Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No)
                {

                    return;
                }
            }

            DataRowView currentrow = (DataRowView)produtnBindingSource.Current;
            var prodno = currentrow["prodno"].ToString();

            frmSearch frmSearch = new frmSearch("PRODNO", "PRODUCTION", prodno);

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

                    Fill();
                    DataRowView current = (DataRowView)produtnBindingSource.Current;

                    this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
                    this.Schcode = current["Schcode"].ToString();
                }

                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                this.Cursor = Cursors.Default;
                frmProdutn_Paint(this, null);

            }



        }
		public override void JobNoSearch() {

			var produtnResult = SaveProdutn();
			if (produtnResult.IsError) {
				var result1 = MessageBox.Show("Production record could not be saved:" + produtnResult.Errors[0].ErrorMessage + " Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result1 == DialogResult.No) {

					return;
				}
			}

			DataRowView currentrow = (DataRowView)produtnBindingSource.Current;
            string jobno = "";
            try {
			 jobno = currentrow["jobno"].ToString();
            }
            catch (Exception ex)
            {

            }
			frmSearch frmSearch = new frmSearch("JOBNO", "PRODUCTION", jobno);

			var result = frmSearch.ShowDialog();
			if (result == DialogResult.OK) {
				//values preserved after close

				try {
					this.Invno = frmSearch.ReturnValue.Invno;
					this.Schcode = frmSearch.ReturnValue.Schcode;
					if (string.IsNullOrEmpty(Schcode)) {
						MbcMessageBox.Hand("A search value was not returned", "Error");
						return;
					}

					Fill();
					DataRowView current = (DataRowView)produtnBindingSource.Current;

					this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
					this.Schcode = current["Schcode"].ToString();
				} catch (Exception ex) {
					MbcMessageBox.Error(ex.Message, "Error");
					return;

				}
				this.Cursor = Cursors.Default;
				frmProdutn_Paint(this, null);

			}



		}

        

        private void dedmadeTextBox_Leave(object sender, EventArgs e)
        {



            if (dedmadeTextBox.Text=="Y")
            {
              
                var result=  this.WipUpdate();
                if (result.Result.IsError)
                {
                    MbcMessageBox.Error(result.Result.Errors[0].ErrorMessage, "");
                }
            }
        }

        private void btnBkDue_Click(object sender, EventArgs e)
        {
            var emailList = new List<string>();
            DataRowView custRow = (DataRowView)custBindingSource.Current;
            DataRowView prodRow = (DataRowView)produtnBindingSource.Current;
            string vDedayOut = "";
            string vDedayIn = "";
           string vPin ="";
            DateTime vdate;
            if (!prodRow.Row.IsNull("dedayout"))
            {
                     vdate=(DateTime)prodRow["dedayout"];
                vDedayOut = vdate.ToString("d");
            }
            if (!prodRow.Row.IsNull("dedayin"))
            {
                 vdate = (DateTime)prodRow["dedayin"];
                vDedayIn = vdate.ToString("d");
            }
            if (!custRow.Row.IsNull("PIN"))
            {
                vPin = ((DataRowView)custBindingSource.Current).Row["pin"].ToString();
            }
         
            string vNoPages = ((DataRowView)quotesBindingSource.Current).Row["nopages"].ToString();
            string vNoCopies= ((DataRowView)quotesBindingSource.Current).Row["nocopies"].ToString();
            
            string vCsName= ((DataRowView)custBindingSource.Current).Row["csname"].ToString().Trim();
            string vCsEmail= ((DataRowView)custBindingSource.Current).Row["csemail"].ToString().Trim();
            string vcontEmail = custRow["contemail"] != null ? custRow["contemail"].ToString().Trim() : "";
            string vBcontEmail = custRow["bcontemail"] != null ? custRow["bcontemail"].ToString().Trim() : "";
            string vCcontEmail = custRow["ccontemail"] != null ? custRow["ccontemail"].ToString().Trim() : "";
            if (!string.IsNullOrEmpty(vcontEmail))
            {
                emailList.Add(vcontEmail);
            }
            if (!string.IsNullOrEmpty(vBcontEmail))
            {
                emailList.Add(vBcontEmail);
            }
            if (!string.IsNullOrEmpty(vCcontEmail))
            {
                emailList.Add(vCcontEmail);
            }
            var emailHelper = new EmailHelper();
            string subject = "Memory Book Deadline Reminder";
                    string body = @"The deadline for submitting your yearbook pages is right around the corner.
                                    In order to ensure delivery of your books by "+ vDedayOut+ ", please submit " +
                                    "your pages by " + vDedayIn + "." + " According to our records, your order is for "
                                    + vNoPages + " pages and " + vNoCopies + " yearbooks. If this is not correct, please" +
                                    " call 1-800-247-1526 or respond to this e-mail with any changes you may have. Payment is" +
                                    " due upon receipt of invoice; to be issued within a week of page submission. Payments may" +
                                    " be made online https://pay.memorybook.com/school (School Code:" + Schcode+ " and PIN:" 
                                    + vPin + " will be needed) or by mailing a check to: <br/><strong>Memory Book Company " +
                                    "<br/>304 Curry Drive  <br/>Sedalia, MO 65301</strong> <br/><br/>Once your pages are here and " +
                                    "your book has entered production you will receive an email, this will confirm your order and " +
                                    "delivery date.<br/><br/>" + vCsName + "<br/>" + vCsEmail;


            emailHelper.SendOutLookEmail(subject, emailList, "", body, EmailType.Mbc);
        }

        private void frmProdutn_KeyPress(object sender, KeyPressEventArgs e)
        {
            //set KeyPriview to True first.
            //if (e.KeyChar == (char)Keys.Enter)
            //    e.KeyChar = (char)Keys.Tab;
            //SendKeys.Send(e.KeyChar.ToString());//send the keystroke to the form.
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WipUpdate();
        }

        private void btnUpdateWip_Click(object sender, EventArgs e)
        {
            var result = this.WipUpdate();
            if (result.Result.IsError)
            {
                MbcMessageBox.Error(result.Result.Errors[0].ErrorMessage, "");
            }
        }

        private void btnRecvLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnCoverTicket_Click(object sender, EventArgs e)
        {
            if (Company == "MBC") {
               var dResult= MessageBox.Show("Do you want the single sheet version?", "Cover Ticket Version",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dResult ==DialogResult.Yes) { PrintCoverTicketDiminished(); } else { PrintCoverTicket(); }


            }
            if (Company == "MER")
            {

            }

        }
        private void PrintCoverTicketDiminished()
        {
            var drCover = (DataRowView)coversBindingSource1.Current;
            var drCust = (DataRowView)custBindingSource.Current;
            var drProd = (DataRowView)produtnBindingSource.Current;
            var vReqCopy = drCover.Row.IsNull("ReqstdCpy") ? 0 : (int)drCover.Row["ReqstdCpy"];
            var vLaminated =  drProd.Row["laminated"].ToString();
            if (vReqCopy == 0)
            {
                MbcMessageBox.Information("Please enter the number of  requested copies before printing.");
                return;
            }
            if (vLaminated=="Y")
            {
                MbcMessageBox.Information("Lamination value must be M,N or G.");
                return;
            }

            try
            {
                var cvrData = new SpecialCoverTicket()
                {
                    Schcode = Schcode,
                    Schname = drCust.Row["Schname"].ToString().Trim(),
                    PrtVend = drCover.Row["PrtVend"].ToString().Trim(),
                    Invno = drProd.Row.IsNull("Invno") ? 0 : (int)drProd.Row["Invno"],
                    BarCode = "*MBC0" + Invno.ToString().Trim() + "SC*",
                    Prodno = drProd.Row["ProdNo"].ToString().Trim(),
                    ContrYear = drCust.Row["ContrYear"].ToString().Trim(),
                    CvrStock = drCover.Row["CvrStock"].ToString().Trim(),
                    Bind = drProd.Row["PerfBind"].ToString().Trim(),
                    SpecCover = drProd.Row["SpecCover"].ToString().Trim(),
                    ScRecv = drProd.Row["ScRecv"].ToString(),
                    ReqstdCpy = drCover.Row.IsNull("ReqstdCpy") ? 0 : (int)drCover.Row["ReqstdCpy"],
                    NoPages = drProd.Row.IsNull("ProdNoPages") ? 0 : (int)drProd.Row["ProdNoPages"],
                    SchoolColors = drCust.Row["schcolors"].ToString().Trim(),
                    IndivName = drProd.Row.IsNull("IndivName") ? false : (bool)drProd.Row["IndivName"],
                    Foiling = drProd.Row.IsNull("Foiling") ? false : (bool)drProd.Row["Foiling"],
                    Laminated = drProd.Row["laminated"].ToString()
                    
                };
                CoverTicketBindingSource.DataSource = cvrData;
                reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.SpecialCoverTicket3rd.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsSpecCvr", CoverTicketBindingSource));
              

            }
            catch (Exception ex) {
                ex.ToExceptionless()
                    .AddObject(ex)
                    .MarkAsCritical()
                    .Submit();
                MbcMessageBox.Error(ex.Message);
                    };
  
            
            try
            {

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message, "");
            }
        }
        private void PrintCoverTicket()
        {
            var drCover = (DataRowView)coversBindingSource1.Current;
            var drCust = (DataRowView)custBindingSource.Current;
            var drProd = (DataRowView)produtnBindingSource.Current;
            var vReqCopy = drCover.Row.IsNull("ReqstdCpy") ? 0 : (int)drCover.Row["ReqstdCpy"];
            var vLaminated = drProd.Row["laminated"].ToString();
            if (vReqCopy == 0)
            {
                MbcMessageBox.Information("Please enter the number of  requested copies before printing.");
                return;
            }
            if (vLaminated == "Y")
            {
                MbcMessageBox.Information("Lamination value must be M,N or G.");
                return;
            }

            try
            {
                var cvrData = new SpecialCoverTicket()
                {
                    Schcode = Schcode,
                    Schname = drCust.Row["Schname"].ToString().Trim(),
                    PrtVend = drCover.Row["PrtVend"].ToString().Trim(),
                    Invno = drProd.Row.IsNull("Invno") ? 0 : (int)drProd.Row["Invno"],
                    BarCode = "*MBC0" + Invno.ToString().Trim() + "SC*",
                    Prodno = drProd.Row["ProdNo"].ToString().Trim(),
                    ContrYear = drCust.Row["ContrYear"].ToString().Trim(),
                    CvrStock = drCover.Row["CvrStock"].ToString().Trim(),
                    Bind = drProd.Row["PerfBind"].ToString().Trim(),
                    Colors = drProd.Row["Colors"].ToString().Trim(),
                    Clr1 = drCover.Row["Clr1"].ToString().Trim(),
                    Clr2 = drCover.Row["Clr2"].ToString().Trim(),
                    Clr3 = drCover.Row["Clr3"].ToString().Trim(),
                    Clr4 = drCover.Row["Clr4"].ToString().Trim(),
                    SpecCover = drProd.Row["SpecCover"].ToString().Trim(),
                    ScRecv = drProd.Row["ScRecv"].ToString(),
                    Laminated = drProd.Row["laminated"].ToString(),
                    ReqstdCpy = drCover.Row.IsNull("ReqstdCpy") ? 0 : (int)drCover.Row["ReqstdCpy"],
                    NoPages = drProd.Row.IsNull("ProdNoPages") ? 0 : (int)drProd.Row["ProdNoPages"],
                    Desc = drCover.Row["Desc"].ToString().Trim(),
                    Desc2 = drCover.Row["Desc2"].ToString().Trim(),
                    Desc3 = drCover.Row["Desc3"].ToString().Trim(),
                    Desc4 = drCover.Row["Desc4"].ToString().Trim(),
                    CoverDesc = drProd.Row["CoverDesc"].ToString().Trim(),
                    Scname = drProd.Row.IsNull("scname") ? false : (bool)drProd.Row["scname"],
                    Yr = drProd.Row.IsNull("Yr") ? false : (bool)drProd.Row["Yr"],
                    IndivName = drProd.Row.IsNull("IndivName") ? false : (bool)drProd.Row["IndivName"],
                    Icon = drProd.Row.IsNull("Icon") ? false : (bool)drProd.Row["Icon"],
                    MK = drProd.Row.IsNull("MK") ? false : (bool)drProd.Row["MK"],
                    SchoolColors = drCust.Row["schcolors"].ToString().Trim(),
                    TypeSet = drCover.Row.IsNull("TypeSet") ? false : (bool)drCover.Row["TypeSet"],
                    IndivPic = drProd.Row.IsNull("IndivPic") ? false : (bool)drProd.Row["IndivPic"],
                    Emailed = drCover.Row.IsNull("Emailed") ? false : (bool)drCover.Row["Emailed"],
                    NumToPerso = drProd.Row.IsNull("numtopersonalize") ? 0 : (int)drProd.Row["numtopersonalize"],
                    Foiling = drProd.Row.IsNull("Foiling") ? false : (bool)drProd.Row["Foiling"],
                    Front = drCover.Row["Front"].ToString().Trim(),
                    FoilClr = drProd.Row["FoilClr"].ToString().Trim(),
                    Spine = drCover.Row["Spine"].ToString().Trim(),
                    Mascot = drCover.Row["Mascot"].ToString().Trim(),
                    CustSubmtx = drCover.Row.IsNull("CustSubmtx") ? false : (bool)drCover.Row["CustSubmtx"],
                    SpecInst = drCover.Row["SpecInst"].ToString().Trim()

                };
                CoverTicketBindingSource.DataSource = cvrData;
               
                reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.SpecialCoverTicket.rdlc";
                reportViewer2.LocalReport.DataSources.Clear();
                reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DsSpecCvr", CoverTicketBindingSource));
                reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("dsCoverDetail", coverdetailBindingSource));
                reportViewer3.LocalReport.DataSources.Clear();
                reportViewer3.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.SpecialCoverTicket3rd.rdlc";
                reportViewer3.LocalReport.DataSources.Clear();
                reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("DsSpecCvr", CoverTicketBindingSource));
                reportViewerAddress.LocalReport.DataSources.Clear();
                reportViewerAddress.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", custBindingSource));
                reportViewerCover.LocalReport.DataSources.Clear();
                reportViewerCover.LocalReport.DataSources.Add(new ReportDataSource("dsCust", custBindingSource));
                reportViewerCover.LocalReport.DataSources.Add(new ReportDataSource("dsProd", produtnBindingSource));
                reportViewerCover.LocalReport.DataSources.Add(new ReportDataSource("dsCovers", coversBindingSource1));
                reportViewerCover.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321CoverLabel.rdlc";
                
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .AddObject(ex)
                    .MarkAsCritical()
                    .Submit();
                MbcMessageBox.Error(ex.Message);
            };


            try
            {
                MbcMessageBox.Information("Select a printer to print cover ticket.");
                printDialog1.ShowDialog();
                CoverTicketPrinterName = printDialog1.PrinterSettings.PrinterName;
                MbcMessageBox.Information("Choose a printer for Address Labels.");
                printDialog1.ShowDialog();
                    AddressLabelerName = printDialog1.PrinterSettings.PrinterName;
                MbcMessageBox.Information("Choose a printer for Cover Labels.");
                printDialog1.ShowDialog();
                CoverLabelerName = printDialog1.PrinterSettings.PrinterName;
                this.reportViewer2.RefreshReport();
                this.reportViewer3.RefreshReport();
                reportViewerAddress.RefreshReport();
                reportViewerCover.RefreshReport();
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message, "");
            }
        }
        
        private void btnAddPhotoCd_Click(object sender, EventArgs e)
        {
            var sqlQuery = new SQLCustomClient();
            
            sqlQuery.AddParameter("@Invno",Invno);
            sqlQuery.ClearParameters();
            sqlQuery.CommandText(@"INSERT INTO PtBkb (Invno,Schcode,Company,BookType)Values(@Invno,@Schcode,@Company,@BookType)");
            sqlQuery.AddParameter("@Invno",Invno);
            sqlQuery.AddParameter("@Schcode",Schcode);
            sqlQuery.AddParameter("@BookType", ((DataRowView)quotesBindingSource.Current).Row["BookType"].ToString());
            sqlQuery.AddParameter("@Company", txtCompany.Text);
   
           var insertResult=sqlQuery.Insert();
            if (insertResult.IsError)
            {
                MbcMessageBox.Error("Failed to instert Photo On CD Record:" + insertResult.Errors[0].ErrorMessage);
            }
            try
            {
                ptbkbTableAdapter.FillBy(dsProdutn.ptbkb, Invno);
                prtbkbdetailTableAdapter.FillBy(dsProdutn.prtbkbdetail, Invno);
                btnCDAdd.Visible = false;
                EnableAllControls(this.tbProdutn.TabPages[5]);
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message, "");
                return;
            }
        }

       

        private void cstsvcdteDateTimePicker_Leave(object sender, EventArgs e)
        {
            produtnBindingSource.EndEdit();
            var result = this.WipUpdate();
            if (result.Result.IsError)
            {
                MbcMessageBox.Error(result.Result.Errors[0].ErrorMessage, "");
            }
        }

        

        private void shpdateDateTimePicker_Leave_1(object sender, EventArgs e)
        {
            ShippingEmail();
        }

        private void cstsvcdteDateTimePicker_Leave_1(object sender, EventArgs e)
        {
            SetPressDates();
            //var result = this.WipUpdate();
            //if (result.Result.IsError)
            //{
            //    MbcMessageBox.Error(result.Result.Errors[0].ErrorMessage, "");
            //}
        }

        private void btnMeridianTicket_Click(object sender, EventArgs e)
        {
            var sqlQuery = new SQLCustomClient();
            string cmdText = @"
                            Select 
							C.Schcode,
							C.Schname,
							C.SchColors AS SchoolColors,
							Q.Invno,
							Q.prodcode,     
                                P.Prodno,
						
								P.CoverType,
								P.SpecCover,
								P.CoverDesc,
								P.NoPages,
								P.Laminated,
								CV.CvrStock,
								IIF(Q.sf=1,'SF','LF')AS PlannerType,P.TypeStyle,
								CV.Mascot,
                                CV.Clr1,CV.Clr2,CV.Clr3,CV.Clr4,
					            CV.[Desc],
								CV.Desc1a,CV.Desc2,CV.Desc3,CV.Desc4,CV.CustSubmtx,
								P.ScRecv,
								CV.SpBack,
								CV.ReqstdCpy,
								P.Prfreq,
                                Cv.CvrStock,
								CV.Specinst,
								P.SpecCover,
								CASE
                                    WHEN Q.prodcode  ='HSP' THEN 'HS'
                                    WHEN Q.ProdCode='MSP' THEN 'MS'
                                    WHEN Q.ProdCode='ELSP' THEN 'ELEM'
                                    WHEN Q.ProdCode='PRISP' THEN 'PRIM'
                                    WHEN Q.ProdCode='LTE' THEN 'LTE'
                                    WHEN Q.ProdCode='STE' THEN 'STE'
                                END AS Schtype  
								
                            FROM MCust C 
                            LEFT JOIN MQuotes Q ON C.Schcode=Q.Schcode
                            LEFT JOIN Produtn P ON Q.Invno=P.Invno
                            LEFT JOIN Covers CV ON Q.Invno=CV.Invno
                            WHERE Q.Invno=@Invno
                            ";
            sqlQuery.CommandText(cmdText);
            sqlQuery.AddParameter("@Invno", Invno);
            var queryResult = sqlQuery.Select<MeridianCoverTicket>();
            if (queryResult.IsError)
            {
                MbcMessageBox.Error(queryResult.Errors[0].ErrorMessage);
                ExceptionlessClient.Default.CreateLog("Meridian Cover Ticket Error")
                    .AddObject(queryResult)
                    .Submit();
                return;
                
            }
            var queryData=(MeridianCoverTicket)queryResult.Data;
            mcoverTicketBindingSource.DataSource = queryData;
            mcoverReportViewer.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MeridianCoverTicket.rdlc";
            mcoverReportViewer.LocalReport.DataSources.Clear();
            mcoverReportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsMCover", mcoverTicketBindingSource));
           mcoverReportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsCoverDetail", coverdetailBindingSource));
           
            mcoverReportViewer.RefreshReport();

        }

        private void btnCvrUpdate_Click(object sender, EventArgs e)
        {
            var result=UpdateCoverWip();
            if (result.Result.IsError)
            {
                MbcMessageBox.Error("Failed to update cover WIP: " + result.Result.Errors[0].ErrorMessage);
            }
        }
        
        private void btnBindery_Click(object sender, EventArgs e)
        {

            if (Company != "MBC")
            {

                return;
            }
            var result=PrintBindery();
      
            if (result.Result.IsError)
            {
                MbcMessageBox.Information(result.Result.Errors[0].ErrorMessage);
            }

        }
        private async Task<ApiProcessingResult> PrintBindery()
        {
            var processingResult = new ApiProcessingResult() { IsError = false };

            var ticketResult = await PrintBinderyTicket();

            if (ticketResult.IsError)
            {
                processingResult.IsError = true;
                processingResult.Errors = ticketResult.Errors;
                return processingResult;
            }
            var labelResult = await PrintBinderyLabel();
            if (labelResult.IsError)
            {
                
                processingResult.IsError = true;
                processingResult.Errors = labelResult.Errors;
                return processingResult;
            }

            return processingResult;
        }
        private async Task<ApiProcessingResult> PrintBinderyTicket()
        {
            var processingResult = new ApiProcessingResult() { IsError = false };

            reportViewerBinderyTicket.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.BinderySC.rdlc";
            reportViewerBinderyTicket.LocalReport.DataSources.Clear();
            reportViewerBinderyTicket.LocalReport.DataSources.Add(new ReportDataSource("dsCover", coversBindingSource1));
            reportViewerBinderyTicket.LocalReport.DataSources.Add(new ReportDataSource("dsProdutn", produtnBindingSource));
            reportViewerBinderyTicket.LocalReport.DataSources.Add(new ReportDataSource("dsCust", custBindingSource));
            MbcMessageBox.Hand("Choose a printer for bindery ticket.", "Ticket Printer");
            printDialog1.ShowDialog();
            this.BinderyTicketPrinter= printDialog1.PrinterSettings.PrinterName;
            this.reportViewerBinderyTicket.RefreshReport();

            return processingResult;

        }
        private async Task<ApiProcessingResult> PrintBinderyLabel()
        {
            var processingResult = new ApiProcessingResult() { IsError = false };

            var drCovers = (DataRowView)coversBindingSource1.Current;
            var drCust = (DataRowView)custBindingSource.Current;
            var drProdutn = (DataRowView)produtnBindingSource.Current;
            var vSchname = drCust.Row["Schname"].ToString();
            var vBarCode = "*" + drProdutn.Row["Jobno"].ToString() + "C*";
            var vJobNo = drProdutn.Row["Jobno"].ToString();
            var vBinding = drProdutn.Row["PerfBind"].ToString();
            var tmpQuantity = (int)drCovers.Row["reqstdcpy"];
            var vQuantity = vBinding == "S" || vBinding == "P" ? tmpQuantity + 30 : tmpQuantity + 40;

            var numLabelsResult =await GetNumberOfBinderyLabels();
            if (numLabelsResult.IsError) {
                processingResult.IsError = true;
                processingResult.Errors = numLabelsResult.Errors;
                return processingResult;
            }

            int numLabelsToPrint = numLabelsResult.Data;


            var vLabelList = new List<BinderyLabel>();
            for (int i = 0; i < numLabelsToPrint + 2; i++)
            {
                var labelData = new BinderyLabel()
                {
                    Schname = vSchname,
                    BarCode = vBarCode,
                    JobNo = vJobNo,
                    Binding = vBinding,
                    Quantity = vQuantity,
                    LabelTotal = numLabelsToPrint,
                    CurrentLabel = i+1
                };

                vLabelList.Add(labelData);
            }
            binderyLabelBindingSource.DataSource = vLabelList;

            reportViewerBinderyLabel.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321BinderySCLabel.rdlc";
            reportViewerBinderyLabel.LocalReport.DataSources.Clear();
            reportViewerBinderyLabel.LocalReport.DataSources.Add(new ReportDataSource("dsBinderyLabel", binderyLabelBindingSource.DataSource));
            MbcMessageBox.Hand("Choose a printer for bindery labels.", "Label Printer");
            printDialog1.ShowDialog();
            this.BinderyLabelerPrinter = printDialog1.PrinterSettings.PrinterName;

            this.reportViewerBinderyLabel.RefreshReport();

            return processingResult;

        }
        private async Task<ApiProcessingResult<int>> GetNumberOfBinderyLabels()
        {
            var processingResult = new ApiProcessingResult<int>();
            string value = "";
            if (InputBox.Show("No. Labels", "Enter number of labels needed.", ref value) != DialogResult.OK)
            {

                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Action cancelled by user.", "Action cancelled by user.", ""));
                return processingResult;
            }
            int numLabelsToPrint = 0;
            if (!int.TryParse(value, out numLabelsToPrint))
            {

                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Return value needs to be an integer.", "Return value needs to be an integer.", ""));
                return processingResult;
            }
            processingResult.Data = numLabelsToPrint;
            return processingResult;
        }

            private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            try { reportViewer1.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }

           

        }
        private void reportViewer2_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {

            ////For printing cover ticket long form only main form
            

            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            var result = dp.Export(reportViewer2.LocalReport, CoverTicketPrinterName, 2);
          
            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void reportViewer3_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            //Short cover ticket
            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN
            
            var result = dp.Export(reportViewer3.LocalReport, CoverTicketPrinterName, 1);
           

            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void reportViewerAddress_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            //Address Labels 
           

            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            var result = dp.Export(reportViewerAddress.LocalReport, AddressLabelerName, 1);

            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void reportViewerCover_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            ///Cover Labelse
           // reportViewerCover.PrintDialog();

            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            var result = dp.Export(reportViewerCover.LocalReport, CoverLabelerName, 1,true);

            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string value = "";
            if (InputBox.Show("No. Labels", "Enter number of labels needed.", ref value) != DialogResult.OK)
            {
                MbcMessageBox.Information("Action cancelled by user.");
                return;
            }
            int numLabelsToPrint = 0;
            if (!int.TryParse(value, out numLabelsToPrint))
            {
                MbcMessageBox.Error("Return value needs to be an integer.");
                return;
            }
            var drCovers = (DataRowView)coversBindingSource1.Current;
            var drCust = (DataRowView)custBindingSource.Current;
            var drProdutn = (DataRowView)produtnBindingSource.Current;
            var vSchname = drCust.Row["Schname"].ToString().Trim();
            var vBarCode = "*" + drProdutn.Row["Jobno"].ToString() + "C*";
            var vJobNo = drProdutn.Row["Jobno"].ToString();
            var vBinding = drProdutn.Row["PerfBind"].ToString();
            var tmpQuantity = (int)drCovers.Row["reqstdcpy"];
            var vQuantity = vBinding == "S" || vBinding == "P" ? tmpQuantity + 30 : tmpQuantity + 40;
     
            if (!int.TryParse(value, out numLabelsToPrint))
            {
                MbcMessageBox.Error("Return value needs to be an integer.");
                return;
            }
            var vLabelList = new List<BinderyLabel>();
            for (int i = 0; i < (numLabelsToPrint + 2); i++)
            {
                var labelData = new BinderyLabel()
                {
                    Schname = vSchname,
                    BarCode = vBarCode,
                    JobNo = vJobNo,
                    Binding = vBinding,
                    Quantity = vQuantity,
                    LabelTotal = numLabelsToPrint,
                    CurrentLabel=i+1
                };

                vLabelList.Add(labelData);
            }
            binderyLabelBindingSource.DataSource = vLabelList;
            reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321BinderySCLabel.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsBinderyLabel", binderyLabelBindingSource.DataSource));
         
            this.reportViewer1.RefreshReport();
        }

        

        private void reportViewerBindery_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
           

            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            var result = dp.Export(reportViewerBinderyTicket.LocalReport,this.BinderyTicketPrinter, false);

            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void reportViewerBinderyLabel_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
           

            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            var result = dp.Export(reportViewerBinderyLabel.LocalReport, BinderyLabelerPrinter, true);

            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCDTicket_Click(object sender, EventArgs e)
        {
           
            reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.PhotoOnCDTicket.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsProdutn", produtnBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsSales", quotesBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsPtbKb",ptbkbBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCust", custBindingSource));
            reportViewer1.RefreshReport();
        }

        private void btnCDDate_Click(object sender, EventArgs e)
        {
            var result = UpdatePhotoCD();
            if (result.Result.IsError)
            {
                MbcMessageBox.Error(result.Result.Errors[0].ErrorMessage);
            }
            
        }
        

        private void btnAddPartial_Click(object sender, EventArgs e)
        {
           var vBooktype= ((DataRowView)quotesBindingSource.Current).Row["BookType"].ToString();
            var sqlQuery = new SQLCustomClient();
           
            sqlQuery.AddParameter("@Invno", Invno);
            sqlQuery.ClearParameters();
            sqlQuery.CommandText(@"INSERT INTO PartBk (Invno,Schcode,Company,BookType) Values(@Invno,@Schcode,@Company,@BookType)");
            sqlQuery.AddParameter("@Invno", Invno);
            sqlQuery.AddParameter("@Schcode", Schcode);
            sqlQuery.AddParameter("@BookType", "MBO");
            sqlQuery.AddParameter("@Company", txtCompany.Text);
         
            var insertResult = sqlQuery.Insert();
            if (insertResult.IsError)
            {
                MbcMessageBox.Error("Failed to instert Partial Book Record:" + insertResult.Errors[0].ErrorMessage);
                return;
            }
            try
            {
                partbkTableAdapter.FillBy(dsProdutn.partbk, Invno);
                prtbkbdetailTableAdapter.FillBy(dsProdutn.prtbkbdetail, Invno);
                btnAddPartial.Visible = false;
                EnableAllControls(this.tbProdutn.TabPages[4]);
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message, "");
                return;
            }
        }

        private void btnUpdatePartialDates_Click(object sender, EventArgs e)
        {
            var result = UpdatePartialDates();
            if (result.Result.IsError)
            {
                MbcMessageBox.Error(result.Result.Errors[0].ErrorMessage);
            }
        }

        private void btnPartialProdTicket_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.PartialBookTicket.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsProdutn", produtnBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsSales", quotesBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsPartBk", partbkBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCust", custBindingSource));
            reportViewer1.RefreshReport();
        }

        private void btnAddReorder_Click(object sender, EventArgs e)
        {
            var sqlQuery = new SQLCustomClient();

            sqlQuery.AddParameter("@Invno", Invno);
            sqlQuery.ClearParameters();
            sqlQuery.CommandText(@"INSERT INTO ReOrder (Invno,Schcode,Company,BookType)Values(@Invno,@Schcode,@Company,@BookType)");
            sqlQuery.AddParameter("@Invno", Invno);
            sqlQuery.AddParameter("@Schcode", Schcode);
            sqlQuery.AddParameter("@BookType", ((DataRowView)quotesBindingSource.Current).Row["BookType"].ToString());
            sqlQuery.AddParameter("@Company", txtCompany.Text);

            var insertResult = sqlQuery.Insert();
            if (insertResult.IsError)
            {
                MbcMessageBox.Error("Failed to instert ReOrder Record:" + insertResult.Errors[0].ErrorMessage);
                return;
            }
            try
            {
                reOrderTableAdapter.Fill(dsProdutn.ReOrder, Invno);
              reorderDetailTableAdapter.Fill(dsProdutn.ReorderDetail, Invno);
                btnAddReorder.Visible = false;
                EnableAllControls(this.tbProdutn.TabPages[6]);
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message, "");
                return;
            }
        }

        private void btnReorderChangeDates_Click(object sender, EventArgs e)
        {
            var result = UpdateReOrderDates();
            if (result.Result.IsError)
            {
                MbcMessageBox.Error(result.Result.Errors[0].ErrorMessage);
            }
        }

        private void pg7_Click(object sender, EventArgs e)
        {

        }

        private void btnReorderTicket_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.ReOrderTicket.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsProdutn", produtnBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsSales", quotesBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsReOrder", reOrderBindingSource));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCust", custBindingSource));
            reportViewer1.RefreshReport();
        }

        private void dedayoutDateBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dedayoutDateBox.Date))
            {
                var result = CalulateBusinessDay.BusinessDay((DateTime)dedayoutDateBox.DateValue);
                if(result.ToShortDateString()!= dedayoutDateBox.Date)
                {
                    dedayoutDateBox.Date = result.ToShortDateString();
                    MbcMessageBox.Information("Dead Line Out Date is a holiday or weekend! The next available date has been entered.");
                }
            }
         
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCalcResult_Leave(object sender, EventArgs e)
        {
          
        }

        private void dateBox1_Load(object sender, EventArgs e)
        {

        }

        private void txtCalcResult_Leave_1(object sender, EventArgs e)
        {
            SetPressDates();
        }

        
        private void mcoverReportViewer_RenderingComplete_1(object sender, RenderingCompleteEventArgs e)
        {
                try { mcoverReportViewer.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
        }






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


