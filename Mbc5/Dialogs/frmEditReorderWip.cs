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
    public partial class frmEditReorderWip : Form {
        public frmEditReorderWip(int id,int invno,string schcode) {
            InitializeComponent();
            ID = id;
            Invno = invno;
            Schcode = schcode;
            }
        public int ID { get; set; }
        public int Invno { get; set; }
        public bool Refill { get; set; }
        public string Schcode { get; set; }
        
        private void frmEditPrtBkWip_Load(object sender,EventArgs e) {
            
            string AppConnectionString = "";
            AppConnectionString = ConfigurationManager.AppSettings["Environment"].ToString() == "DEV" ? "Data Source = sedswjpsql02; Initial Catalog = Mbc5_demo; Persist Security Info =True;Trusted_Connection=True;" : "Data Source = sedswjpsql02; Initial Catalog = Mbc5; Persist Security Info =True;Trusted_Connection=True;";

            this.wipDescriptionsTableAdapter.Connection.ConnectionString = AppConnectionString;
            wipDescriptionsTableAdapter.Fill(dsProdutn.WipDescriptions, "PhotosCD");
            reorderDetailTableAdapter.EditFillBy(dsProdutn.ReorderDetail, Invno);
     
          
            if (ID != 0)
            {
                try
                {
                    var pos =reorderDetailBindingSource.Find("id", ID);
                    if (pos > -1)
                    {
                        reorderDetailBindingSource.Position = pos;

                    }
                    else
                    {
                        MessageBox.Show("Record was not found,first available record is showing.", "Reorder Detail Record", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (Exception ex) { };

            }
            else
            {
                reorderDetailBindingSource.AddNew();
                txtInvno.Text = Invno.ToString();
                lblSchcode.Text = Schcode;
            }
            this.Text +="  "+ Schcode + "/" + Invno.ToString();
        }

       
        private void frmEditPrtBkWip_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Refill) { this.DialogResult = DialogResult.OK; } else { this.DialogResult = DialogResult.Cancel; }
        }

        private void wipDetailBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                try
                {
                    this.reorderDetailBindingSource.EndEdit();
                    reorderDetailTableAdapter.Update(dsProdutn.ReorderDetail);
                    Refill = true;
                }
                catch (Exception ex) { }
            }
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("This will permentaly remove the record. Continue?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                reorderDetailTableAdapter.Delete(ID);
                 reorderDetailBindingSource.RemoveCurrent();
                Refill = true;
            }
        }

        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            txtInvno.Text = Invno.ToString();
            lblSchcode.Text = Schcode;
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
