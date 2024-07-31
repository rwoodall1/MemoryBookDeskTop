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
using Mbc5.Classes;
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
           
            
            this.mbcUsersTableAdapter.Connection.ConnectionString = ApplicationConfig.DefaultConnectionString;
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
