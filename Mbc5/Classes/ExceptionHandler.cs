using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace Mbc5.Classes
{
   public static class ExceptionHandler
    {
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
                dataset.Merge(tempCustDataTable, true, MissingSchemaAction.Ignore);

            }
            return response;

        }
        public static DataSets.dsCust.custDataTable tempCustDataTable = new DataSets.dsCust.custDataTable();
        private static DataSets.dsCust.custRow GetCurrentRowInDB(DataSets.dsCust.custRow RowWithError)
        {
            DataSets.dsCustTableAdapters.custTableAdapter vTableAdapter = new DataSets.dsCustTableAdapters.custTableAdapter();

            try
            {
               
                vTableAdapter.Fill(tempCustDataTable, RowWithError.schcode);
            }
            catch (Exception ex)
            {

            }
            DataSets.dsCust.custRow currentRowInDb =
              (DataSets.dsCust.custRow)tempCustDataTable.Rows[0];

            return currentRowInDb;
        }
        private static string GetRowData(DataSets.dsCust.custRow curData, DataSets.dsCust.custRow vrow, DataRowVersion RowVersion)
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
        //EndCust
        //produtn
        public static DialogResult CreateMessage(DataSets.dsProdutn.produtnRow cr,ref DataSets.dsProdutn dataset)
        {          
           string msg= GetRowData(GetCurrentRowInDB(cr), cr, DataRowVersion.Default) + "\n \n" +
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
                dataset.Merge(tempProdutnDataTable, true, MissingSchemaAction.Ignore);
              
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
      }
}
