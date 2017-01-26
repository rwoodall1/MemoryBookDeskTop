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
        public static string CreateMessage(DataSets.dsProdutn.produtnRow cr)
        {
           
           string msg= GetRowData(GetCurrentRowInDB(cr), cr, DataRowVersion.Default) + "\n \n" +
             "Do you still want to update the database with the proposed value?";
            //dataset.Merge(tempProdutnDataTable,true,MissingSchemaAction.Ignore);
            return msg;
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
       
      }
}
