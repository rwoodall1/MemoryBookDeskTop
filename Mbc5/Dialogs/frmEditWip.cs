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
using BaseClass;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;
using Exceptionless;
using Mbc5.Forms;
using NLog;
using Mbc5.Classes;
namespace Mbc5.Dialogs
{
    public partial class frmEditWip : Form
    {
        public frmEditWip(int id, int invno,string schcode, frmMain mainfrm)
        {
            InitializeComponent();
            ID = id;
            Invno = invno;
            Schcode = schcode;
            frmMain =mainfrm;
            Log = LogManager.GetLogger(GetType().FullName);
        }
        public int ID { get; set; }
        public int Invno { get; set; }
        public string Schcode { get; set; }
        public bool Refill { get; set; }
        public frmMain frmMain { get; set; }
        protected Logger Log { get; set; }
        private void frmEditWip_Load(object sender, EventArgs e)
        {
            SetConnectionString();
            try
            {
                wipDescriptionsTableAdapter.Fill(dsProdutn.WipDescriptions, "WIP");
                wipDetailTableAdapter.EditFillBy(dsProdutn.WipDetail,Invno);
            }catch(Exception ex) {
                Log.Error("Error retrieving information EditWipDetail:" + ex.Message);
                MbcMessageBox.Error("Error retrieving information:" + ex.Message);
                this.Close();

            };
            if (ID != 0)
            {
                var pos = wipDetailBindingSource.Find("id", ID);
                if (pos > -1)
                {
                    wipDetailBindingSource.Position = pos;

                }
                else
                {
                    MessageBox.Show("Record was not found,first available record is showing.", "Wip Detail Record", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                wipDetailBindingSource.AddNew();
                txtInvno.Text = Invno.ToString();
                lblSchcode.Text = Schcode;
            }
            this.Text += "  " + "Schcode: " +Schcode + " / " +"Invoice: "+ Invno.ToString();
        }

        private void wipDetailBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.wipDetailBindingSource.EndEdit();
                try
                {
                    wipDetailTableAdapter.Update(dsProdutn.WipDetail);
                    Refill = true;
                    this.Close();
                }
                catch(Exception ex) {
                    Log.Error("Error retrieving information Saving EditWipDetail:" + ex.Message);
                    MbcMessageBox.Error("Failed to save record");
                };
                
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txtInvno.Text = Invno.ToString();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var result=MessageBox.Show("This will permentaly remove the record. Continue?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
               
				wipDetailTableAdapter.DeleteQuery(ID);
				wipDetailBindingSource.RemoveCurrent();
                Refill = true;
            }
     
        }

        private void frmEditWip_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Refill) { this.DialogResult = DialogResult.OK; } else { this.DialogResult = DialogResult.Cancel; ; }
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
        private void SetConnectionString()
        {
            try
            {
                this.wipDescriptionsTableAdapter.Connection.ConnectionString = ApplicationConfig.DefaultConnectionString;
                this.wipDetailTableAdapter.Connection.ConnectionString = ApplicationConfig.DefaultConnectionString;
          
            }
            catch (Exception ex)
            {
                Log.WithProperty("Property1", frmMain.ApplicationUser.UserName).Error(ex, "Failed to set Edit WipDetail connection strings");

            }
        }
    }
}
