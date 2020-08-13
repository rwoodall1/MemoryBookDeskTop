using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass;
using BindingModels;
using Microsoft.Reporting.WinForms;
using Equin.ApplicationFramework;
namespace Mbc5.Forms.MixBook
{
    public partial class frmWipReport : BaseClass.frmBase
    {
        public frmWipReport(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        public UserPrincipal ApplicationUser { get; set; }

        private void frmWipReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

      
        private void LoadData()
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Select TOP 1400 MO.Invno
                                 ,MO.Copies,Mo.Pages,Mo.[Size]
                                 ,Mo.OrderReceivedDate
                                 ,MO.ClientOrderId
                                 ,MO.RequestedShipDate
                                 ,MO.Description
                                 ,P.Kitrecvd
                                  ,CD37.War AS OnBoards
                                 ,CD37.MxbLocation AS Location37
                                 ,CD43.War AS Trimming
                                 ,CD43.MxbLocation AS Location43
                                 ,WD29.War AS WipPress
                                 ,WD39.War AS Binding
                                 ,WD39.MxbLocation AS Location39
                                 ,WD49.War AS CaseIn
                                 ,WD50.War AS Quality
                                 ,WD50.MxbLocation AS Location50
                                 from MixBookOrder MO 
                                 Left Join Produtn P On MO.Invno=P.Invno
                                 Left Join (Select Invno,DescripId,War,MxbLocation From CoverDetail  Where DescripId=37 ) CD37 On MO.Invno=CD37.Invno
                                    Left Join (Select Invno,DescripId,War,MxbLocation From CoverDetail  Where DescripId=43  ) CD43 On MO.Invno=CD43.Invno
                                 Left Join (Select Invno,DescripId,War From WipDetail  Where DescripId=29  ) WD29 On MO.Invno=WD29.Invno
                                 Left Join (Select Invno,DescripId,War,MxbLocation From WipDetail  Where DescripId=39  ) WD39 On MO.Invno=WD39.Invno
                                 Left Join (Select Invno,DescripId,War From WipDetail Where DescripId=49  ) WD49 On MO.Invno=WD49.Invno
                                 Left Join (Select Invno,DescripId,War,MxbLocation From WipDetail Where DescripId=50  ) WD50 On MO.Invno=WD50.Invno
                                 Where  P.Kitrecvd IS NOT NULL AND P.Shpdate IS NULL Order By Mo.OrderReceivedDate,MO.ClientOrderId,MO.Invno,P.Kitrecvd");

            var orderResult = sqlClient.SelectMany<WipReportModel>();
            if (orderResult.IsError)
            {
                MbcMessageBox.Error("Failed to retrieve records:" + orderResult.Errors[0].DeveloperMessage);
                return;
            }
            var vOrders = (List<WipReportModel>)orderResult.Data;
            BindingListView<WipReportModel> vOrders1 = new BindingListView<WipReportModel>(vOrders);
            bsWip.DataSource = vOrders1;
            lblRecCount.Text = vOrders1.Count.ToString() + " Records";
      
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
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", bsWip));

            reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixbookWipReport.rdlc";
            this.reportViewer1.RefreshReport();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            

        }
    }
}
