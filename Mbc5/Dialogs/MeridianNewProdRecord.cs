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

            var sqlClient = new SQLCustomClient().CommandText( "Select * from prodnum");  
            var selectResult = sqlClient.SelectSingleColumn();
            if (selectResult.IsError)
            {
                MessageBox.Show("There was an error getting the production number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "0";

            }

                string prodNum = selectResult.Data;
               int newProdNum = Convert.ToInt32(prodNum) + 1;
               sqlClient.ClearParameters();
            sqlClient.CommandText("Update Prodnum Set lstprodno=@lstprodno");
            sqlClient.AddParameter("@lstprodno", newProdNum);
            var updateResult=sqlClient.Update();
            if(updateResult.IsError)
            {
                MessageBox.Show("There was an error updating the production number table to new production number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             
            }
            
            
            string vprodNum =prodNum;

            return vprodNum;

        }
    }
}
