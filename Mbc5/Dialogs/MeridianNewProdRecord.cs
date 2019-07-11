using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseClass;
using BaseClass.Classes;
using System.Data.SqlClient;
using Exceptionless;
namespace Mbc5.Dialogs
{
    public partial class MeridianNewProdRecord : Form
    {
        public MeridianNewProdRecord()
        {
            InitializeComponent();
        }
        public string retProdNo { get; set; } = "0";

        private void btnReOrder_Click(object sender, EventArgs e)
        {
            retProdNo = txtOldProdNo.Text;
            if (string.IsNullOrEmpty(retProdNo)||retProdNo.Length<12)
            {
                MbcMessageBox.Hand("Please enter a 12 character Production Number.", "Reorder");
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            string vProdNo=GetProdNo();
            if (!string.IsNullOrEmpty(vProdNo))
            {
                this.DialogResult = DialogResult.OK;
                this.retProdNo = vProdNo;
                this.Close();
            }
            
        }
        public string GetProdNo()
        {
            var sqlQuery = new SQLQuery();
      
            SqlParameter[] parameters = new SqlParameter[] { };
            var strQuery = "Select * from prodnum";
            var result = sqlQuery.ExecuteReaderAsync(CommandType.Text, strQuery, parameters);
            int? prodNum = null;
            try
            {
                prodNum = Convert.ToInt32(result.Rows[0]["lstprodno"]);
                strQuery = "Update Prodnum Set lstprodno=@lstprodno";
                SqlParameter[] parameters1 = new SqlParameter[] { new SqlParameter("@lstprodno", (prodNum + 1)) };
                var result1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters1);
                if (result1 != 1)
                {
                    ExceptionlessClient.Default.CreateLog("Error updating Prodnum table with new value.")
                         .AddTags("New prod number error.")
                         .Submit();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error getting the production number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ex.ToExceptionless()
                  .AddTags("MeridianWindows")
                  .SetMessage("Error getting production number.")
                  .Submit();
                return "";

            }
            string vprodNum ="M"+ prodNum.ToString();

            return vprodNum;

        }
    }
}
