using BaseClass.Classes;
using Microsoft.Reporting.WinForms;
using System;

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
            if (this.Invno > 0)
            {

                this.jPIXOrdersTableAdapter.FillByInvno(this.dsJPIXOrders.JPIXOrders, this.Invno);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            try
            {
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", jPIXOrdersBindingSource));

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
    }
}

