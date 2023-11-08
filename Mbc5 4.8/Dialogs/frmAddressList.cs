using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseClass.Classes;
using Mbc5.Forms;
using System.Configuration;
namespace Mbc5.Dialogs
{
    public partial class frmAddressList : Form
    {
        public frmAddressList()
        {
            InitializeComponent();
           
        }

        public string RetEmail { get; set; }

        private void frmAddressList_Load(object sender, EventArgs e)
        {
           
            string AppConnectionString = "";
            AppConnectionString = ConfigurationManager.AppSettings["Environment"].ToString() == "DEV" ? "Data Source = SedswjpSql01; Initial Catalog = Mbc5_demo; Persist Security Info =True;Trusted_Connection=True;" : "Data Source = SedswjpSql01; Initial Catalog = Mbc5; Persist Security Info =True;Trusted_Connection=True;";
            // TODO: This line of code loads data into the 'dsUser.mbcUsers' table. You can move, or remove it, as needed.
            this.mbcUsersTableAdapter.Connection.ConnectionString = AppConnectionString;
            this.mbcUsersTableAdapter.Fill(this.dsUser.mbcUsers);

        }

      

        private void mbcUsersDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = mbcUsersDataGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = mbcUsersDataGridView.Rows[selectedrowindex];

            string val = Convert.ToString(selectedRow.Cells["EmailAddress"].Value).Trim();
            if (string.IsNullOrEmpty(this.RetEmail))
            {
                this.RetEmail = val;
            }
            else
            {
                this.RetEmail = this.RetEmail + ";" +val;
            }
            this.txtAddress.Text = RetEmail;
        }

        private void btrnOk_Click(object sender, EventArgs e)
        {
            this.RetEmail = txtAddress.Text;//in the event they remove an address from the text box
             this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            RetEmail = "";
            this.Close();
        }
    }
}
