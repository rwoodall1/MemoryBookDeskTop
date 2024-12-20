﻿using System;
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
using CsvHelper;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace Mbc5.Forms.MixBook
{
    public partial class frmWipReport : BaseClass.frmBase
    {
        public frmWipReport(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator","MBLead", "MixBook" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        public UserPrincipal ApplicationUser { get; set; }

        private void frmWipReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

      private List<WipReportModel> DataResult { get; set; }


   private void LoadData()
        {
            var sqlClient = new SQLCustomClient();
      string cmd= @"Select 
                                    MO.ShipName									
									,(Substring(LTRIM(RTRIM(Convert(varchar,MO.Invno))),1,7)+'   X'+Substring(LTRIM(RTRIM(Convert(varchar,MO.Invno))),8,Len(Convert(varchar,MO.Invno)-7)))AS Invno
									,MO.Copies
									,Mo.Pages
									,Convert(VARCHAR(10),MO.RequestedShipDate,101)AS RequestedShipDate
									,MO.Description
									,MO.Backing
                                 	,P.Kitrecvd
                                    ,Case When C.Remake=1 Then 'Y' Else 'N' End IsCoverRemake
									,CD29.War AS CPress
									,CD29.MxbLocation AS Location29
									,CD43.War As CTrimming
									,CD43.MxbLocation AS CTrimLoc
									,COALESCE(CD37.War,'') AS OnBoards
									,CD37.MxbLocation AS CCart
                                    ,Case WHEN W.Rmbto IS NULL THEN 'N'  ELSE  'Y' END AS IsBookRemake
									,WD29.War AS WipPress
									,COALESCE(WD43.War,'') As PTrimming
									,WD43.Mxblocation As PTrimLoc 
									,WD39.War AS Binding
									,WD39.MxbLocation AS PCart
									,WD49.War AS CaseIn
									,WD50.War AS Quality				                          
									,WD50.MxbLocation AS Location
                                    ,Convert(VARCHAR,Mo.OrderReceivedDate,22)AS OrderReceivedDate
                                    ,'*MXB'+CAST(MO.Invno as varchar)+'SC*' AS SCBarcode
                                    ,'*MXB'+CAST(MO.Invno as varchar)+'YB*' AS YBBarcode
                                    ,SH.Carrier As ShipCarrier
                                    ,'*'+CAST(MO.ClientOrderId AS varchar)+'*' AS ClientOrderId
                                 from MixBookOrder MO 
                                 Left Join ShipCarriers SH On MO.ShipMethod=SH.ShipAlias
                                 Left Join Produtn P On MO.Invno=P.Invno
                                 Left Join Wip W ON MO.Invno=W.Invno
                                 Left Join Covers C On MO.Invno=C.Invno
                                 Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From CoverDetail  Where DescripId=37 ) CD37 On MO.Invno=CD37.Invno
                                 Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From CoverDetail  Where DescripId=29 ) CD29 On MO.Invno=CD29.Invno
                                 Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From CoverDetail  Where DescripId=43 ) CD43 On MO.Invno=CD43.Invno
                                 Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War From WipDetail  Where DescripId=29  ) WD29 On MO.Invno=WD29.Invno
                                 Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail  Where DescripId=39) WD39 On MO.Invno=WD39.Invno
                                 Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail  Where DescripId=43 ) WD43 On MO.Invno=WD43.Invno
                                 Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War From WipDetail Where DescripId=49  ) WD49 On MO.Invno=WD49.Invno
                                 Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail Where DescripId=50  ) WD50 On MO.Invno=WD50.Invno
                                 Where  MO.MixbookOrderStatus !='Cancelled' and P.Kitrecvd IS NOT NULL AND P.Shpdate IS NULL Order By Mo.OrderReceivedDate,MO.ClientOrderId,MO.Invno,P.Kitrecvd";
            sqlClient.CommandText(cmd);
       var orderResult = sqlClient.SelectMany<WipReportModel>();
            if (orderResult.IsError)
            {
                MbcMessageBox.Error("Failed to retrieve records:" + orderResult.Errors[0].DeveloperMessage);
                return;
            }
            var vOrders = (List<WipReportModel>)orderResult.Data;
            this.DataResult = vOrders;
            BindingListView<WipReportModel> vOrders1 = new BindingListView<WipReportModel>(vOrders);
            bsWip.DataSource = vOrders1;
            lblRecCount.Text = vOrders1.Count.ToString() + " Records";
            var vcopies = vOrders1.Sum(a => a.Copies);
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

            //reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixbookWipReport.rdlc";
            //this.reportViewer1.RefreshReport();

            if (bsWip.Count<1)
            {
                MbcMessageBox.Hand("There are no records to print.","No Records");
                return;
            }
            try
            {
                saveFileDialog1.Filter = "Comma Seperated Value|*.csv";
                saveFileDialog1.FileName = "WipReport.csv";
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
                  string _clientOrderId= dataGridView1.CurrentRow.Cells[0].Value.ToString().Replace("*","");
                    if (int.TryParse(_clientOrderId, out theClinetOrderId)) { 
                    
                    frmMBOrders frmMBOrders = new frmMBOrders(this.ApplicationUser, theClinetOrderId);
                    frmMBOrders.MdiParent = this.MdiParent;
                    frmMBOrders.Show();
                    this.Cursor = Cursors.Default;}
                }
           
         
            
        }
    }
}
