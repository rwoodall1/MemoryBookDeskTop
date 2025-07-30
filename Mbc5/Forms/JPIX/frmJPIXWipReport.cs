using BaseClass;
using BaseClass.Classes;
using BindingModels;
using CsvHelper;
using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mbc5.Forms.JPIX
{
    public partial class frmJPIXWipReport : BaseClass.frmBase
    {
        public frmJPIXWipReport(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MBLead", "MixBook" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        public UserPrincipal ApplicationUser { get; set; }

        private void frmWipReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private List<JPIXWipReportModel> DataResult { get; set; }


        private void LoadData()
        {
            var sqlClient = new SQLCustomClient();
            string cmd = @"Select 
                    JO.ShipToCustomerName								
                    ,JO.Invno
                    ,JO.Quantity 
                    ,Convert(VARCHAR(10),JO.NeedsByDate,101)NeedByDate
                    ,Convert(VARCHAR(10),JO.NeedsByDate,101)ProjectedShipDate
                    ,JO.ProductType AS Description
                    ,JO.OracleCode
                    ,JO.OrderStatus
                    ,Convert(VARCHAR,JO.DateReceived,22)AS OrderReceivedDate
                    ,P.Kitrecvd
                    ,WD29.War AS WipPress
                    ,WD40.War AS Shipped
                    from JPIXOrders JO                               
                    Left Join Produtn P On JO.Invno=P.Invno
                    Left Join Wip W ON JO.Invno=W.Invno                              
                    Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War From WipDetail  Where DescripId=29  ) WD29 On JO.Invno=WD29.Invno                               
                    Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War From WipDetail Where DescripId=40  ) WD40 On JO.Invno=WD40.Invno                                
                    Where  JO.OrderStatus !='Cancelled' and P.Kitrecvd IS NOT NULL AND P.Shpdate IS NULL Order By Jo.DateReceived,JO.Invno,P.Kitrecvd";
            sqlClient.CommandText(cmd);
            var orderResult = sqlClient.SelectMany<JPIXWipReportModel>();
            if (orderResult.IsError)
            {
                MbcMessageBox.Error("Failed to retrieve records:" + orderResult.Errors[0].DeveloperMessage);
                return;
            }
            var vOrders = (List<JPIXWipReportModel>)orderResult.Data;
            this.DataResult = vOrders;
            BindingListView<JPIXWipReportModel> vOrders1 = new BindingListView<JPIXWipReportModel>(vOrders);
            bsWip.DataSource = vOrders1;
            lblRecCount.Text = vOrders1.Count.ToString() + " Records";
            var vcopies = vOrders1.Sum(a => a.Quantity);
            lblcopycnt.Text = vcopies.ToString() + " Total Copies";

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void reportViewer1_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            try { reportViewer1.PrintDialog(); } catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", bsWip));

            //reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.JPIXFlyerWipReport.rdlc";
            //this.reportViewer1.RefreshReport();

            if (bsWip.Count < 1)
            {
                MbcMessageBox.Hand("There are no records to print.", "No Records");
                return;
            }
            try
            {
                saveFileDialog1.Filter = "Comma Seperated Value|*.csv";
                saveFileDialog1.FileName = "JPIXFlyerWipReport.csv";
                saveFileDialog1.ShowDialog();
                //using (var mem = new MemoryStream())
                using (var writer = new StreamWriter(saveFileDialog1.FileName))
                using (var csvWriter = new CsvWriter(writer))
                {
                    csvWriter.Configuration.Delimiter = ",";
                    //csvWriter.Configuration.HasHeaderRecord = true;
                    // csvWriter.Configuration.AutoMap<InqCountModel>();

                    //csvWriter.WriteHeader<InqCountModel>();
                    csvWriter.WriteRecords(this.DataResult);

                    writer.Flush();

                    Process.Start(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error("Error creating file:" + ex.Message);
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(2))
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    int theClinetOrderId;
                    string _clientOrderId = dataGridView1.CurrentRow.Cells[0].Value.ToString().Replace("*", "");
                    if (int.TryParse(_clientOrderId, out theClinetOrderId))
                    {

                        //frmMBOrders frmMBOrders = new frmMBOrders(this.ApplicationUser, theClinetOrderId);
                        //frmMBOrders.MdiParent = this.MdiParent;
                        //frmMBOrders.Show();
                        //this.Cursor = Cursors.Default;
                    }
                }



        }
    }
}
