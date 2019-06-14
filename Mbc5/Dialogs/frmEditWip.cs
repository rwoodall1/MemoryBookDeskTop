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
using System.Configuration;
using System.Data.SqlClient;
namespace Mbc5.Dialogs
{
    public partial class frmEditWip : Form
    {
        public frmEditWip(int id, int invno)
        {
            InitializeComponent();
            ID = id;
            Invno = invno;
        }
        public int ID { get; set; }
        public int Invno { get; set; }
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
            this.wipDetailTableAdapter.Connection.ConnectionString = AppConnectionString;

            wipDescriptionsTableAdapter.Fill(dsProdutn.WipDescriptions, "WIP");
           // wipDetailTableAdapter.FillBy(dsProdutn.WipDetail, Invno);
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

        private void wipDetailBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wipDetailBindingSource.EndEdit();
            DataRowView row = (DataRowView)wipDetailBindingSource.Current;           
            int descid = (int)cmbDescription.SelectedValue;
			DateTime war=DateTime.Now;
			if (row["War"]!=null)
			{
				try
				{war =(DateTime)row["War"]  ; }catch(Exception ec)
				{
					return;
				}
				
			}
			
			
			

           DateTime? wdr =  row["Wdr"]!=null?(DateTime?)row["Wdr"]:null;
           decimal wtr = (decimal)row["Wtr"];
           string wir = row["Wir"].ToString();
            int invno = (int)row["Invno"];
            int id = (int)row["id"];
            SQLQuery sqlQuery = new SQLQuery();
            var cmdtxt = "UPDATE WipDetail SET DescripId = @DescripId,War =@War,Wdr =@Wdr,Wtr =@Wtr,Wir =@Wir,Invno =@Invno WHERE Id=@Id";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@DescripId",descid),
                new SqlParameter("@War",war),
                new SqlParameter("@Wdr",wdr),
                new SqlParameter("@Wtr",wtr),
                new SqlParameter("@Wir",wir),
                new SqlParameter("@Invno",invno),
                new SqlParameter("@Id",id)

            };
            var result=sqlQuery.ExecuteNonQueryAsync(CommandType.Text, cmdtxt, parameters);
            if (result ==-1)
            {
                MessageBox.Show("There was an error updating record. The record was not saved.");
            }
            else { MessageBox.Show("Record Saved."); }
            Refill = true;
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

    }
}
