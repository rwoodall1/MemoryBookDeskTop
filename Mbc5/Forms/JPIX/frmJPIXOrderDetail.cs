using BaseClass;
using BaseClass.Classes;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;

namespace Mbc5.Forms.JPIX
{
    public partial class frmJPIXOrderDetail : BaseClass.frmBase
    {
        public frmJPIXOrderDetail(UserPrincipal userPrincipal, int invno) : base(new string[] { "SA", "Administrator", "MixBook", "BARCODE", "MBLead" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
            this.Invno = invno;
        }

        public frmMain frmMain { get; set; }
        public UserPrincipal ApplicationUser { get; set; }


        private void frmJPIXOrderDetail_Load(object sender, EventArgs e)
        {
            this.Fill();
        }
        private void Fill()
        {
            if (this.Invno > 0)
            {

                this.jPIXOrdersTableAdapter.FillByInvno(this.dsJPIXOrders.JPIXOrders, this.Invno);
                if (jPIXOrdersBindingSource.Count == 0)
                {
                    MbcMessageBox.Information("No records found for this invoice number.", "No Records Found");
                }
                this.Invno = (int)((DataRowView)jPIXOrdersBindingSource.Current).Row["Invno"];
                this.Schcode = (string)((DataRowView)jPIXOrdersBindingSource.Current).Row["OracleCode"];

            }
            else
            {
                this.jPIXOrdersTableAdapter.FillAll(this.dsJPIXOrders.JPIXOrders);
                this.Invno = (int)((DataRowView)jPIXOrdersBindingSource.Current).Row["Invno"];
                this.Schcode = (string)((DataRowView)jPIXOrdersBindingSource.Current).Row["OracleCode"];
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            var curRecPos = jPIXOrdersBindingSource.Position;
            var dt = ((DataRowView)jPIXOrdersBindingSource.Current).DataView.ToTable();
            var tmpdt = dt.Clone();

            tmpdt.ImportRow(dt.Rows[curRecPos]);
            try
            {
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", tmpdt));

                reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.JPIXJobTicketSingle.rdlc";
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            try
            {

                reportViewer1.PrintDialog();
            }
            catch (Exception ex)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("PrintJPIXJobTicketSingle" + ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int _invno = 0;
            try
            {
                if (!string.IsNullOrEmpty(txtSearch.Text) && int.TryParse(txtSearch.Text, out _invno))
                {

                    var rec = jPIXOrdersBindingSource.Find("Invno", txtSearch.Text);
                    if (rec != -1)
                    {
                        jPIXOrdersBindingSource.Position = rec;
                        this.Invno = (int)((DataRowView)jPIXOrdersBindingSource.Current).Row["Invno"];
                        this.Schcode = (string)((DataRowView)jPIXOrdersBindingSource.Current).Row["OracleCode"];
                    }
                    else
                    {
                        MbcMessageBox.Hand("No records found for this invoice number.", "No Records Found");
                    }



                }
            }
            catch (Exception ex) { }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            jPIXOrdersBindingSource.EndEdit();
            this.jPIXOrdersTableAdapter.Update(this.dsJPIXOrders.JPIXOrders);
        }
    }
}

