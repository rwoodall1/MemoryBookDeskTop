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
namespace Mbc5.Dialogs
{
    public partial class frmEditCoverWip : Form
    {
        public frmEditCoverWip(int id, int invno,string schcode)
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
        private void frmEditWip_Load(object sender, EventArgs e)
        {
            var Environment = ConfigurationManager.AppSettings["Environment"].ToString();
            string AppConnectionString = "";
            if (Environment == "DEV")
            {
                AppConnectionString = "Data Source=192.168.1.101; Initial Catalog=Mbc5; User Id=sa;password=Briggitte1; Connect Timeout=5";
            }
            else if (Environment == "PROD") { AppConnectionString = "Data Source=10.37.32.49;Initial Catalog=Mbc5;User Id = MbcUser; password = 3l3phant1; Connect Timeout=5"; }
            
            this.wipDescriptionsTableAdapter.Connection.ConnectionString = AppConnectionString;
            this.coverdetailTableAdapter.Connection.ConnectionString = AppConnectionString;
            wipDescriptionsTableAdapter.Fill(dsProdutn.WipDescriptions, "Covers");
            var sqlQuery = new SQLCustomClient();
                sqlQuery.CommandText(@"
                    Select DescripId,War,Wdr,Wtr,Wir,Invno,Id,Schcode Where Invno=@Invno
                    ");
            sqlQuery.AddParameter("@Invno", Invno);
            var queryResult = sqlQuery.SelectMany<CoverDetail>();
            if (queryResult.IsError)
            {
                MbcMessageBox.Error("Failed to select Cover Detail Records:"+queryResult.Errors[0].ErrorMessage);
                return;
            }
            var vData =(List<CoverDetail>) queryResult.Data;
            coverdetailBindingSource.DataSource = vData;
            if (ID != 0)
            {
                var pos = coverdetailBindingSource.Find("id", ID);
                if (pos > -1)
                {
                    coverdetailBindingSource.Position = pos;

                }
                else
                {
                    MessageBox.Show("Record was not found,first available record is showing.", "Wip Detail Record", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
               

            }
        }

        private void wipDetailBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            
            else { MessageBox.Show("Record Saved."); }
            Refill = true;
        }
        private void Update() {
           // var vRow =(int)((DataRowView)coverdetailBindingSource.Current).Row["Id"];
     
            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"
                Update CoverDetail Set DescripId=@DescripId ,War=@War, Wdr=@Wdr,Wtr=@Wtr,Wir=@Wir Where Id=@Id
                ");
            sqlQuery.AddParameter("@DescripId",);
            sqlQuery.AddParameter("@War", warDateBox.DateValue);
            sqlQuery.AddParameter("@Wdr", wdrDateBox.DateValue);
            sqlQuery.AddParameter("@Wtr",decimal.Parse(wtrTextBox.Text.Trim()));
            sqlQuery.AddParameter("@Wir", wirTextBox.Text.Trim());
            sqlQuery.AddParameter("@Id", (int)((DataRowView)coverdetailBindingSource.Current).Row["Id"]);
           var updateResult= sqlQuery.Update();
            if (updateResult.IsError)
            {
                MbcMessageBox.Error("Failed to update record:" + updateResult.Errors[0].ErrorMessage);
                return;
            }


        }
        private void Insert()
        {
            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"
                Insert Into CoverDetail (DescripId,War, Wdr,Wtr,Wir,Schcode,Invno) Values(@DescripId,@War,@Wdr,@Wtr,@Wir,@Schcode,@Schcode);
                ");
            sqlQuery.AddParameter("@DescripId",);
            sqlQuery.AddParameter("@War", warDateBox.DateValue);
            sqlQuery.AddParameter("@Wdr", wdrDateBox.DateValue);
            sqlQuery.AddParameter("@Wtr", decimal.Parse(wtrTextBox.Text.Trim()));
            sqlQuery.AddParameter("@Wir", wirTextBox.Text.Trim());
            sqlQuery.AddParameter("@Invno", Invno);
            sqlQuery.AddParameter("@Schcode", Schcode);
            var updateResult = sqlQuery.Update();
            if (updateResult.IsError)
            {
                MbcMessageBox.Error("Failed to update record:" + updateResult.Errors[0].ErrorMessage);
                return;
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
           
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var result=MessageBox.Show("This will permentaly remove the record. Continue?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
               coverdetailTableAdapter.Delete(ID);
               coverdetailBindingSource.RemoveCurrent();
                Refill = true;
            }
     
        }

        private void frmEditWip_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Refill) { this.DialogResult = DialogResult.OK; } else { this.DialogResult = DialogResult.Cancel; ; }
        }

       
        }
}
