using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace Mbc5.Dialogs {
    public partial class frmEditPartBkWip : Form {
        public frmEditPartBkWip(int id,int invno,string schcode) {
            InitializeComponent();
            ID = id;
            Invno = invno;
            Schcode = schcode;
            }
        public int ID { get; set; }
        public int Invno { get; set; }
        public bool Refill { get; set; }
        public string Schcode { get; set; }
        
        private void frmEditPartBkWip_Load(object sender,EventArgs e) {
            var Environment = ConfigurationManager.AppSettings["Environment"].ToString();
            string AppConnectionString = "";
            if (Environment == "DEV")
            {
                AppConnectionString = "Data Source=192.168.1.101; Initial Catalog=Mbc5; User Id=sa;password=Briggitte1; Connect Timeout=5";
            }
            else if (Environment == "PROD") { AppConnectionString = "Data Source=10.37.32.49;Initial Catalog=Mbc5;User Id = MbcUser; password = 3l3phant1; Connect Timeout=5"; }

            this.wipDescriptionsTableAdapter.Connection.ConnectionString = AppConnectionString;
            wipDescriptionsTableAdapter.Fill(dsProdutn.WipDescriptions, "PartialBook");
            this.partBkDetailTableAdapter.EditFillBy(this.dsProdutn.PartBkDetail,Invno);
          
            if (ID != 0)
            {
                try
                {
                    var pos = partBkDetailBindingSource.Find("id", ID);
                    if (pos > -1)
                    {
                        partBkDetailBindingSource.Position = pos;

                    }
                    else
                    {
                        MessageBox.Show("Record was not found,first available record is showing.", "Partial BK Detail Record", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (Exception ex) { };

            }
            else
            {
                partBkDetailBindingSource.AddNew();
                txtInvno.Text = Invno.ToString();
                lblSchcode.Text = Schcode;
            }
            this.Text += "  " + Schcode + "/" + Invno.ToString();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txtInvno.Text = Invno.ToString();
            lblSchcode.Text = Schcode;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("This will permentaly remove the record. Continue?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                partBkDetailTableAdapter.Delete(ID);
                partBkDetailBindingSource.RemoveCurrent();
                Refill = true;
            }
        }
        private void partBkDetailBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                try
                {
                    this.partBkDetailBindingSource.EndEdit();
                    partBkDetailTableAdapter.Update(this.dsProdutn);
                    Refill = true;
                }
                catch(Exception ex) { }
            }
         

        }

        private void frmEditPartBkWip_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Refill) { this.DialogResult = DialogResult.OK; } else { this.DialogResult = DialogResult.Cancel;  }
        }

        private void wtrTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(wtrTextBox, "");
            decimal vInt;
            if (String.IsNullOrEmpty(wtrTextBox.Text))
            {
                this.errorProvider1.SetError(wtrTextBox, "Enter time.");
                e.Cancel = true;
            }

            if (!String.IsNullOrEmpty(wtrTextBox.Text) && !decimal.TryParse(wtrTextBox.Text, out vInt))
            {

                this.errorProvider1.SetError(wtrTextBox, "Only numbers are allowed.");
                e.Cancel = true;
            }
        }

      
        private void wirTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(wirTextBox, "");

            if (String.IsNullOrEmpty(wirTextBox.Text))
            {
                this.errorProvider1.SetError(wirTextBox, "Enter your initials");
                e.Cancel = true;
            }
        }
    }
}
