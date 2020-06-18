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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using BindingModels;
using BaseClass;
using Exceptionless;
using Mbc5.Forms;
namespace Mbc5.Dialogs
{
    public partial class frmEditBannerWip : Form
    {
        public frmEditBannerWip(int id, int invno,string schcode)
        {
            InitializeComponent();
            ID = id;
            Invno = invno;
            Schcode = schcode;
        }
        public int ID { get; set; }
        public int Invno { get; set; }
        public string Schcode { get; set; }
        public bool Refill { get; set; }
        public frmMain frmMain { get; set; }
        private void frmEditWip_Load(object sender, EventArgs e)
        {

            var Environment = ConfigurationManager.AppSettings["Environment"].ToString();
            string AppConnectionString = "";
            if (Environment == "DEV")
            {
                AppConnectionString = "Data Source=10.37.32.49;Initial Catalog=Mbc5_demo;Persist Security Info=True;User ID=mbcuser_demo;Password=F8GFxAtT9Hpzbnck";
            }
            else if (Environment == "PROD") { AppConnectionString = "Data Source=10.37.32.49;Initial Catalog=;Persist Security Info=True;User ID=mbcuser_demo;Password=F8GFxAtT9Hpzbnck"; }
            try
            {
                this.wipDescriptionsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
                    this.bannerdetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
                wipDescriptionsTableAdapter.Fill(dsProdutn.WipDescriptions, "Banners");
                bannerdetailTableAdapter.Fill(dsEndSheet.bannerdetail,Invno);
            }
            catch(Exception ex)
            {
                ex.ToExceptionless()
                    .AddObject(ex)
                    .Submit();
                MbcMessageBox.Error("Error retrieving information:" + ex.Message);
                this.Close();
                return;
            }
           

            if (ID != 0)
            {
                try
                {
                    var pos = bannerdetailBindingSource.Find("Id", ID);
                    if (pos > -1)
                    {
                        bannerdetailBindingSource.Position = pos;

                    }
                    else
                    {
                        MessageBox.Show("Record was not found,first available record is showing.", "Baner Wip Detail Record", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }catch(Exception ex) { };

            }
            else
            {
                bannerdetailBindingSource.AddNew();
                txtInvno.Text = Invno.ToString() ;
                lblSchcode.Text = Schcode;
            }


            this.Text += "  " + Schcode + "/" + Invno.ToString();
        }

        private void wipDetailBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                bannerdetailBindingSource.EndEdit();
                var a = bannerdetailTableAdapter.Update(dsEndSheet.bannerdetail);
                Refill = true;
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
           
              bannerdetailBindingSource.RemoveCurrent();
                bannerdetailTableAdapter.Update(dsEndSheet.bannerdetail);
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

    }
}
