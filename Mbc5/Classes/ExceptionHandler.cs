using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Exceptionless;
namespace Mbc5.Classes
{
   public static class ExceptionHandler
    {
        #region Cust
        //Cust
        public static DialogResult CreateMessage(DataSets.dsCust.custRow cr, ref DataSets.dsCust dataset)
        {
            string msg = GetRowData(GetCurrentRowInDB(cr), cr, DataRowVersion.Default) + "\n \n" +
              "Do you still want to update the database with the proposed value?";
            DialogResult response = MessageBox.Show(msg, "Concurrency Exception", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
            if (response == DialogResult.Yes)
            {
                //keeps form data
                dataset.Merge(tempCustDataTable, true, MissingSchemaAction.Ignore);
            }
            else
            {
                //keeps data on server
                dataset.Merge(tempCustDataTable);
                MessageBox.Show("Update was canceled.","Update",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            return response;

        }
        public static DataSets.dsCust.custDataTable tempCustDataTable = new DataSets.dsCust.custDataTable();
        private static DataSets.dsCust.custRow GetCurrentRowInDB(DataSets.dsCust.custRow RowWithError)
        {
            DataSets.dsCustTableAdapters.custTableAdapter vTableAdapter = new DataSets.dsCustTableAdapters.custTableAdapter();
            DataSets.dsCust.custRow currentRowInDb=null ;
            try
            {
                
                vTableAdapter.ConcurrencyFill(tempCustDataTable,RowWithError.schcode);
                currentRowInDb =(DataSets.dsCust.custRow)tempCustDataTable.Rows[0];

               
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .SetMessage("Concurrency Error")
                    .Submit();
            }
            return currentRowInDb;
        }
        private static string GetRowData(DataSets.dsCust.custRow curData, DataSets.dsCust.custRow vrow, DataRowVersion RowVersion)
        {
            //string rowData = "";
                string columnDataDefault = "";
                string columnDataOriginal = "";
                string columnDataCurrent = "";
                string badColumns = "There was a concurrency violation.";
            if (curData != null)
            {
               
                for (int i = 0; i < vrow.ItemArray.Length; i++)
                {
                    columnDataDefault = tempCustDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Default].ToString().Trim();
                    columnDataOriginal = tempCustDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Original].ToString().Trim();
                    columnDataCurrent = tempCustDataTable.Columns[i].ColumnName.ToString() + ":" + curData[i, DataRowVersion.Current].ToString().Trim();
                    if (columnDataDefault != columnDataOriginal || columnDataDefault != columnDataCurrent)
                    {
                        badColumns = badColumns + "(Your Data:" + columnDataDefault + ")   (Original Data:" + columnDataOriginal + ")    (Data On Server:" + columnDataCurrent + "\n \n";
                    }

                }
            }
            return badColumns;
        }
        //EndCust
        #endregion
        #region Bids
        public static DialogResult CreateMessage(DataSets.dsBids.bidsRow cr1, ref DataSets.dsBids dataset)
        {
            string msg = GetRowData(GetCurrentRowInDB(cr1), cr1, DataRowVersion.Default) + "\n \n" +
              "Do you still want to update the database with the proposed value?";
            DialogResult response = MessageBox.Show(msg, "Concurrency Exception", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
            if (response == DialogResult.Yes)
            {
                //keeps form data
                dataset.Merge(tempBidsDataTable, true, MissingSchemaAction.Ignore);
            }
            else
            {
                //keeps data on server
                dataset.Merge(tempBidsDataTable);
                MessageBox.Show("Update was canceled.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return response;

        }
        public static DataSets.dsBids.bidsDataTable tempBidsDataTable = new DataSets.dsBids.bidsDataTable();
        private static DataSets.dsBids.bidsRow GetCurrentRowInDB(DataSets.dsBids.bidsRow RowWithError)
        {
            DataSets.dsBidsTableAdapters.bidsTableAdapter vTableAdapter = new DataSets.dsBidsTableAdapters.bidsTableAdapter();

            try
            {

                vTableAdapter.FillById(tempBidsDataTable, RowWithError.Id);
            }
            catch (Exception ex)
            {

            }
            DataSets.dsBids.bidsRow currentRowInDb =
              (DataSets.dsBids.bidsRow)tempBidsDataTable.Rows[0];

            return currentRowInDb;
        }
        private static string GetRowData(DataSets.dsBids.bidsRow curData, DataSets.dsBids.bidsRow vrow, DataRowVersion RowVersion)
        {
            //string rowData = "";
            string columnDataDefault = "";
            string columnDataOriginal = "";
            string columnDataCurrent = "";
            string badColumns = "";
            for (int i = 0; i < vrow.ItemArray.Length; i++)
            {
                columnDataDefault = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Default].ToString().Trim();
                columnDataOriginal = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Original].ToString().Trim();
                columnDataCurrent = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + curData[i, DataRowVersion.Current].ToString().Trim();
                if (columnDataDefault != columnDataOriginal || columnDataDefault != columnDataCurrent)
                {
                    badColumns = badColumns + "(Your Data:" + columnDataDefault + ")   (Original Data:" + columnDataOriginal + ")    (Data On Server:" + columnDataCurrent + "\n \n";
                }

            }

            return badColumns;
        }

        #endregion
        #region Quotes
        public static DialogResult CreateMessage(DataSets.dsSales.quotesRow cr1,ref DataSets.dsSales dataset) {
            string msg = GetRowData(GetCurrentRowInDB(cr1),cr1,DataRowVersion.Default) + "\n \n" +
              "Do you still want to update the database with the proposed value?";
            DialogResult response = MessageBox.Show(msg,"Concurrency Exception",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Hand);
            if (response == DialogResult.Yes) {
                //keeps form data
                dataset.Merge(tempQuotesDataTable,true,MissingSchemaAction.Ignore);
                } else {
                //keeps data on server
                dataset.Merge(tempQuotesDataTable);
                MessageBox.Show("Update was canceled.","Update",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            return response;

            }
        public static DataSets.dsSales.quotesDataTable tempQuotesDataTable = new DataSets.dsSales.quotesDataTable();
        private static DataSets.dsSales.quotesRow GetCurrentRowInDB(DataSets.dsSales.quotesRow RowWithError) {
            DataSets.dsSalesTableAdapters.quotesTableAdapter vTableAdapter = new DataSets.dsSalesTableAdapters.quotesTableAdapter();

            try {

                vTableAdapter.FillByInvno(tempQuotesDataTable,RowWithError.invno);
                } catch (Exception ex) {

                }
            DataSets.dsSales.quotesRow currentRowInDb =
              (DataSets.dsSales.quotesRow)tempQuotesDataTable.Rows[0];

            return currentRowInDb;
            }
        private static string GetRowData(DataSets.dsSales.quotesRow curData,DataSets.dsSales.quotesRow vrow,DataRowVersion RowVersion) {
            //string rowData = "";
            string columnDataDefault = "";
            string columnDataOriginal = "";
            string columnDataCurrent = "";
            string badColumns = "";
            for (int i = 0; i < vrow.ItemArray.Length; i++) {
                columnDataDefault = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i,DataRowVersion.Default].ToString().Trim();
                columnDataOriginal = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i,DataRowVersion.Original].ToString().Trim();
                columnDataCurrent = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + curData[i,DataRowVersion.Current].ToString().Trim();
                if (columnDataDefault != columnDataOriginal || columnDataDefault != columnDataCurrent) {
                    badColumns = badColumns + "(Your Data:" + columnDataDefault + ")   (Original Data:" + columnDataOriginal + ")    (Data On Server:" + columnDataCurrent + "\n \n";
                    }

                }

            return badColumns;
            }

        #endregion
        #region Produtn
        //produtn
        public static DialogResult CreateMessage(DataSets.dsProdutn.produtnRow cr2,ref DataSets.dsProdutn dataset)
        {          
           string msg= GetRowData(GetCurrentRowInDB(cr2), cr2, DataRowVersion.Default) + "\n \n" +
             "Do you still want to update the database with the proposed value?";
            DialogResult response=MessageBox.Show(msg,"Concurrency Exception",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Hand);
            if (response == DialogResult.Yes)
            {
                //keeps form data
                dataset.Merge(tempProdutnDataTable,true,MissingSchemaAction.Ignore);
            }
            else
            {
                //keeps data on server
                dataset.Merge(tempProdutnDataTable);
                MessageBox.Show("Update was canceled.","Update",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            return response;
          
        }
        public static DataSets.dsProdutn.produtnDataTable tempProdutnDataTable = new DataSets.dsProdutn.produtnDataTable();
        private static DataSets.dsProdutn.produtnRow GetCurrentRowInDB(DataSets.dsProdutn.produtnRow RowWithError)
        {
            DataSets.dsProdutnTableAdapters.produtnTableAdapter vTableAdapter = new DataSets.dsProdutnTableAdapters.produtnTableAdapter();

            try
            {
                vTableAdapter.FillByInvno(tempProdutnDataTable, RowWithError.invno);
            }
            catch (Exception ex)
            {

            }
            DataSets.dsProdutn.produtnRow currentRowInDb =
              (DataSets.dsProdutn.produtnRow)tempProdutnDataTable.Rows[0];

            return currentRowInDb;
        }
        private static string GetRowData(DataSets.dsProdutn.produtnRow curData, DataSets.dsProdutn.produtnRow vrow, DataRowVersion RowVersion)
        {
            //string rowData = "";
            string columnDataDefault = "";
            string columnDataOriginal = "";
            string columnDataCurrent = "";
            string badColumns = "";
            for (int i = 0; i < vrow.ItemArray.Length; i++)
            {
                columnDataDefault = tempProdutnDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Default].ToString().Trim();
                columnDataOriginal = tempProdutnDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Original].ToString().Trim();
                columnDataCurrent = tempProdutnDataTable.Columns[i].ColumnName.ToString() + ":" + curData[i, DataRowVersion.Current].ToString().Trim();
                if (columnDataDefault != columnDataOriginal || columnDataDefault != columnDataCurrent)
                {
                    badColumns = badColumns + "(Your Data:" + columnDataDefault + ")   (Original Data:" + columnDataOriginal + ")    (Data On Server:" + columnDataCurrent + "\n \n";
                }

            }
           
            return badColumns;
        }
        //Endprodutn
        #endregion
        #region Covers
   
        public static DialogResult CreateMessage(DataSets.dsProdutn.coversRow cr3,ref DataSets.dsProdutn dataset) {
            string msg = GetRowData(GetCurrentRowInDB(cr3),cr3,DataRowVersion.Default) + "\n \n" +
              "Do you still want to update the database with the proposed value?";
            DialogResult response = MessageBox.Show(msg,"Concurrency Exception",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Hand);
            if (response == DialogResult.Yes) {
                //keeps form data
                dataset.Merge(tempCoversDataTable,true,MissingSchemaAction.Ignore);
                } else {
                //keeps data on server
                dataset.Merge(tempCoversDataTable);
                MessageBox.Show("Update was canceled.","Update",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            return response;

            }
        public static DataSets.dsProdutn.coversDataTable tempCoversDataTable = new DataSets.dsProdutn.coversDataTable();
        private static DataSets.dsProdutn.coversRow GetCurrentRowInDB(DataSets.dsProdutn.coversRow RowWithError) {
            DataSets.dsProdutnTableAdapters.coversTableAdapter vTableAdapter = new DataSets.dsProdutnTableAdapters.coversTableAdapter();

            try {

                vTableAdapter.FillByInvno(tempCoversDataTable,RowWithError.invno);
                } catch (Exception ex) {

                }
            DataSets.dsProdutn.coversRow currentRowInDb =
              (DataSets.dsProdutn.coversRow)tempQuotesDataTable.Rows[0];

            return currentRowInDb;
            }
        private static string GetRowData(DataSets.dsProdutn.coversRow curData,DataSets.dsProdutn.coversRow vrow,DataRowVersion RowVersion) {
            //string rowData = "";
            string columnDataDefault = "";
            string columnDataOriginal = "";
            string columnDataCurrent = "";
            string badColumns = "";
            for (int i = 0; i < vrow.ItemArray.Length; i++) {
                columnDataDefault = tempCoversDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i,DataRowVersion.Default].ToString().Trim();
                columnDataOriginal = tempCoversDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i,DataRowVersion.Original].ToString().Trim();
                columnDataCurrent = tempCoversDataTable.Columns[i].ColumnName.ToString() + ":" + curData[i,DataRowVersion.Current].ToString().Trim();
                if (columnDataDefault != columnDataOriginal || columnDataDefault != columnDataCurrent) {
                    badColumns = badColumns + "(Your Data:" + columnDataDefault + ")   (Original Data:" + columnDataOriginal + ")    (Data On Server:" + columnDataCurrent + "\n \n";
                    }

                }

            return badColumns;
            }
        #endregion
        #region Wip
        public static DialogResult CreateMessage(DataSets.dsProdutn.wipRow cr4,ref DataSets.dsProdutn dataset) {
            string msg = GetRowData(GetCurrentRowInDB(cr4),cr4,DataRowVersion.Default) + "\n \n" +
              "Do you still want to update the database with the proposed value?";
            DialogResult response = MessageBox.Show(msg,"Concurrency Exception",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Hand);
            if (response == DialogResult.Yes) {
                //keeps form data
                dataset.Merge(tempWipDataTable,true,MissingSchemaAction.Ignore);
                } else {
                //keeps data on server
                dataset.Merge(tempWipDataTable);
                MessageBox.Show("Update was canceled.","Update",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            return response;

            }
        public static DataSets.dsProdutn.wipDataTable tempWipDataTable = new DataSets.dsProdutn.wipDataTable();
        private static DataSets.dsProdutn.wipRow GetCurrentRowInDB(DataSets.dsProdutn.wipRow RowWithError) {
            DataSets.dsProdutnTableAdapters.wipTableAdapter vTableAdapter = new DataSets.dsProdutnTableAdapters.wipTableAdapter();

            try {

                vTableAdapter.FillByInvno(tempWipDataTable,RowWithError.invno);
                } catch (Exception ex) {

                }
            DataSets.dsProdutn.wipRow currentRowInDb =
              (DataSets.dsProdutn.wipRow)tempQuotesDataTable.Rows[0];

            return currentRowInDb;
            }
        private static string GetRowData(DataSets.dsProdutn.wipRow curData,DataSets.dsProdutn.wipRow vrow,DataRowVersion RowVersion) {
            //string rowData = "";
            string columnDataDefault = "";
            string columnDataOriginal = "";
            string columnDataCurrent = "";
            string badColumns = "";
            for (int i = 0; i < vrow.ItemArray.Length; i++) {
                columnDataDefault = tempWipDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i,DataRowVersion.Default].ToString().Trim();
                columnDataOriginal = tempWipDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i,DataRowVersion.Original].ToString().Trim();
                columnDataCurrent = tempWipDataTable.Columns[i].ColumnName.ToString() + ":" + curData[i,DataRowVersion.Current].ToString().Trim();
                if (columnDataDefault != columnDataOriginal || columnDataDefault != columnDataCurrent) {
                    badColumns = badColumns + "(Your Data:" + columnDataDefault + ")   (Original Data:" + columnDataOriginal + ")    (Data On Server:" + columnDataCurrent + "\n \n";
                    }

                }
            return badColumns;
            }
        #endregion
        #region PartBK
        public static DialogResult CreateMessage(DataSets.dsProdutn.partbkRow cr,ref DataSets.dsProdutn dataset) {
            string msg = GetRowData(GetCurrentRowInDB(cr),cr,DataRowVersion.Default) + "\n \n" +
              "Do you still want to update the database with the proposed value?";
            DialogResult response = MessageBox.Show(msg,"Concurrency Exception",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Hand);
            if (response == DialogResult.Yes) {
                //keeps form data
                dataset.Merge(tempCustDataTable,true,MissingSchemaAction.Ignore);
                } else {
                //keeps data on server
                dataset.Merge(tempCustDataTable);
                MessageBox.Show("Update was canceled.","Update",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            return response;

            }
        public static DataSets.dsProdutn.partbkDataTable tempPartBKDataTable = new DataSets.dsProdutn.partbkDataTable();
        private static DataSets.dsProdutn.partbkRow GetCurrentRowInDB(DataSets.dsProdutn.partbkRow RowWithError) {
            DataSets.dsProdutnTableAdapters.partbkTableAdapter vTableAdapter = new DataSets.dsProdutnTableAdapters.partbkTableAdapter();

            try {

                vTableAdapter.Fill(tempPartBKDataTable,RowWithError.schcode);
                } catch (Exception ex) {

                }
            DataSets.dsProdutn.partbkRow currentRowInDb =
              (DataSets.dsProdutn.partbkRow)tempCustDataTable.Rows[0];

            return currentRowInDb;
            }
        private static string GetRowData(DataSets.dsProdutn.partbkRow curData,DataSets.dsProdutn.partbkRow vrow,DataRowVersion RowVersion) {
            //string rowData = "";
            string columnDataDefault = "";
            string columnDataOriginal = "";
            string columnDataCurrent = "";
            string badColumns = "";
            for (int i = 0; i < vrow.ItemArray.Length; i++) {
                columnDataDefault = tempCustDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i,DataRowVersion.Default].ToString().Trim();
                columnDataOriginal = tempCustDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i,DataRowVersion.Original].ToString().Trim();
                columnDataCurrent = tempCustDataTable.Columns[i].ColumnName.ToString() + ":" + curData[i,DataRowVersion.Current].ToString().Trim();
                if (columnDataDefault != columnDataOriginal || columnDataDefault != columnDataCurrent) {
                    badColumns = badColumns + "(Your Data:" + columnDataDefault + ")   (Original Data:" + columnDataOriginal + ")    (Data On Server:" + columnDataCurrent + "\n \n";
                    }

                }

            return badColumns;
            }


		#endregion
		#region PtBKB
		public static DialogResult CreateMessage(DataSets.dsProdutn.ptbkbRow cr, ref DataSets.dsProdutn dataset)
		{
			string msg = GetRowData(GetCurrentRowInDB(cr), cr, DataRowVersion.Default) + "\n \n" +
			  "Do you still want to update the database with the proposed value?";
			DialogResult response = MessageBox.Show(msg, "Concurrency Exception", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
			if (response == DialogResult.Yes)
			{
				//keeps form data
				dataset.Merge(tempCustDataTable, true, MissingSchemaAction.Ignore);
			}
			else
			{
				//keeps data on server
				dataset.Merge(tempCustDataTable);
				MessageBox.Show("Update was canceled.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return response;

		}
		public static DataSets.dsProdutn.ptbkbDataTable tempPtBKBDataTable = new DataSets.dsProdutn.ptbkbDataTable();
		private static DataSets.dsProdutn.ptbkbRow GetCurrentRowInDB(DataSets.dsProdutn.ptbkbRow RowWithError)
		{
			DataSets.dsProdutnTableAdapters.ptbkbTableAdapter vTableAdapter = new DataSets.dsProdutnTableAdapters.ptbkbTableAdapter();

			try
			{

				vTableAdapter.Fill(tempPtBKBDataTable, RowWithError.schcode);
			}
			catch (Exception ex)
			{

			}
			DataSets.dsProdutn.ptbkbRow currentRowInDb =
			  (DataSets.dsProdutn.ptbkbRow)tempCustDataTable.Rows[0];

			return currentRowInDb;
		}
		private static string GetRowData(DataSets.dsProdutn.ptbkbRow curData, DataSets.dsProdutn.ptbkbRow vrow, DataRowVersion RowVersion)
		{
			//string rowData = "";
			string columnDataDefault = "";
			string columnDataOriginal = "";
			string columnDataCurrent = "";
			string badColumns = "";
			for (int i = 0; i < vrow.ItemArray.Length; i++)
			{
				columnDataDefault = tempCustDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Default].ToString().Trim();
				columnDataOriginal = tempCustDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Original].ToString().Trim();
				columnDataCurrent = tempCustDataTable.Columns[i].ColumnName.ToString() + ":" + curData[i, DataRowVersion.Current].ToString().Trim();
				if (columnDataDefault != columnDataOriginal || columnDataDefault != columnDataCurrent)
				{
					badColumns = badColumns + "(Your Data:" + columnDataDefault + ")   (Original Data:" + columnDataOriginal + ")    (Data On Server:" + columnDataCurrent + "\n \n";
				}

			}

			return badColumns;
		}


		#endregion
		#region EndSheet
		public static DialogResult CreateMessage(DataSets.dsEndSheet.endsheetRow cr1, ref DataSets.dsEndSheet dataset)
		{
			string msg = GetRowData(GetCurrentRowInDB(cr1), cr1, DataRowVersion.Default) + "\n \n" +
			  "Do you still want to update the database with the proposed value?";
			DialogResult response = MessageBox.Show(msg, "Concurrency Exception", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
			if (response == DialogResult.Yes)
			{
				//keeps form data
				dataset.Merge(tempEndSheetDataTable, true, MissingSchemaAction.Ignore);
			}
			else
			{
				//keeps data on server
				dataset.Merge(tempEndSheetDataTable);
				MessageBox.Show("Update was canceled.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return response;

		}
		public static DataSets.dsEndSheet.endsheetDataTable tempEndSheetDataTable = new DataSets.dsEndSheet.endsheetDataTable();
		private static DataSets.dsEndSheet.endsheetRow GetCurrentRowInDB(DataSets.dsEndSheet.endsheetRow RowWithError)
		{
			DataSets.dsEndSheetTableAdapters.endsheetTableAdapter vTableAdapter = new DataSets.dsEndSheetTableAdapters.endsheetTableAdapter();

			try
			{

				vTableAdapter.FillByInvno(tempEndSheetDataTable, RowWithError.invno);
			}
			catch (Exception ex)
			{

			}
			DataSets.dsEndSheet.endsheetRow currentRowInDb =
			  (DataSets.dsEndSheet.endsheetRow)tempEndSheetDataTable.Rows[0];

			return currentRowInDb;
		}
		private static string GetRowData(DataSets.dsEndSheet.endsheetRow curData, DataSets.dsEndSheet.endsheetRow vrow, DataRowVersion RowVersion)
		{
			//string rowData = "";
			string columnDataDefault = "";
			string columnDataOriginal = "";
			string columnDataCurrent = "";
			string badColumns = "";
			for (int i = 0; i < vrow.ItemArray.Length; i++)
			{
				columnDataDefault = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Default].ToString().Trim();
				columnDataOriginal = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Original].ToString().Trim();
				columnDataCurrent = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + curData[i, DataRowVersion.Current].ToString().Trim();
				if (columnDataDefault != columnDataOriginal || columnDataDefault != columnDataCurrent)
				{
					badColumns = badColumns + "(Your Data:" + columnDataDefault + ")   (Original Data:" + columnDataOriginal + ")    (Data On Server:" + columnDataCurrent + "\n \n";
				}

			}

			return badColumns;
		}

		#endregion
		#region Supplement
		public static DialogResult CreateMessage(DataSets.dsEndSheet.supplRow cr1, ref DataSets.dsEndSheet dataset)
		{
			string msg = GetRowData(GetCurrentRowInDB(cr1), cr1, DataRowVersion.Default) + "\n \n" +
			  "Do you still want to update the database with the proposed value?";
			DialogResult response = MessageBox.Show(msg, "Concurrency Exception", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
			if (response == DialogResult.Yes)
			{
				//keeps form data
				dataset.Merge(tempsupplDataTable, true, MissingSchemaAction.Ignore);
			}
			else
			{
				//keeps data on server
				dataset.Merge(tempsupplDataTable);
				MessageBox.Show("Update was canceled.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return response;

		}
		public static DataSets.dsEndSheet.supplDataTable tempsupplDataTable = new DataSets.dsEndSheet.supplDataTable();
		private static DataSets.dsEndSheet.supplRow GetCurrentRowInDB(DataSets.dsEndSheet.supplRow RowWithError)
		{
			DataSets.dsEndSheetTableAdapters.supplTableAdapter vTableAdapter = new DataSets.dsEndSheetTableAdapters.supplTableAdapter();

			try
			{

				vTableAdapter.FillByInvno(tempsupplDataTable, RowWithError.invno);
			}
			catch (Exception ex)
			{

			}
			DataSets.dsEndSheet.supplRow currentRowInDb =
			  (DataSets.dsEndSheet.supplRow)tempQuotesDataTable.Rows[0];

			return currentRowInDb;
		}
		private static string GetRowData(DataSets.dsEndSheet.supplRow curData, DataSets.dsEndSheet.supplRow vrow, DataRowVersion RowVersion)
		{
			//string rowData = "";
			string columnDataDefault = "";
			string columnDataOriginal = "";
			string columnDataCurrent = "";
			string badColumns = "";
			for (int i = 0; i < vrow.ItemArray.Length; i++)
			{
				columnDataDefault = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Default].ToString().Trim();
				columnDataOriginal = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Original].ToString().Trim();
				columnDataCurrent = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + curData[i, DataRowVersion.Current].ToString().Trim();
				if (columnDataDefault != columnDataOriginal || columnDataDefault != columnDataCurrent)
				{
					badColumns = badColumns + "(Your Data:" + columnDataDefault + ")   (Original Data:" + columnDataOriginal + ")    (Data On Server:" + columnDataCurrent + "\n \n";
				}

			}

			return badColumns;
		}

		#endregion
		#region Preflit
		public static DialogResult CreateMessage(DataSets.dsEndSheet.preflitRow cr1, ref DataSets.dsEndSheet dataset)
		{
			string msg = GetRowData(GetCurrentRowInDB(cr1), cr1, DataRowVersion.Default) + "\n \n" +
			  "Do you still want to update the database with the proposed value?";
			DialogResult response = MessageBox.Show(msg, "Concurrency Exception", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
			if (response == DialogResult.Yes)
			{
				//keeps form data
				dataset.Merge(temppreflitlDataTable, true, MissingSchemaAction.Ignore);
			}
			else
			{
				//keeps data on server
				dataset.Merge(temppreflitlDataTable);
				MessageBox.Show("Update was canceled.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return response;

		}
		public static DataSets.dsEndSheet.preflitDataTable temppreflitlDataTable = new DataSets.dsEndSheet.preflitDataTable();
		private static DataSets.dsEndSheet.preflitRow GetCurrentRowInDB(DataSets.dsEndSheet.preflitRow RowWithError)
		{
			DataSets.dsEndSheetTableAdapters.preflitTableAdapter vTableAdapter = new DataSets.dsEndSheetTableAdapters.preflitTableAdapter();

			try
			{

				vTableAdapter.FillByInvno(temppreflitlDataTable, RowWithError.invno);
			}
			catch (Exception ex)
			{

			}
			DataSets.dsEndSheet.preflitRow currentRowInDb =
			  (DataSets.dsEndSheet.preflitRow)temppreflitlDataTable.Rows[0];

			return currentRowInDb;
		}
		private static string GetRowData(DataSets.dsEndSheet.preflitRow curData, DataSets.dsEndSheet.preflitRow vrow, DataRowVersion RowVersion)
		{
			//string rowData = "";
			string columnDataDefault = "";
			string columnDataOriginal = "";
			string columnDataCurrent = "";
			string badColumns = "";
			for (int i = 0; i < vrow.ItemArray.Length; i++)
			{
				columnDataDefault = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Default].ToString().Trim();
				columnDataOriginal = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + vrow[i, DataRowVersion.Original].ToString().Trim();
				columnDataCurrent = tempQuotesDataTable.Columns[i].ColumnName.ToString() + ":" + curData[i, DataRowVersion.Current].ToString().Trim();
				if (columnDataDefault != columnDataOriginal || columnDataDefault != columnDataCurrent)
				{
					badColumns = badColumns + "(Your Data:" + columnDataDefault + ")   (Original Data:" + columnDataOriginal + ")    (Data On Server:" + columnDataCurrent + "\n \n";
				}

			}

			return badColumns;
		}

		#endregion

	}
}
