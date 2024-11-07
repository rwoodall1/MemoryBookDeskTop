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
using CsvHelper;
using System.IO;
using System.Diagnostics;
namespace Mbc5.Forms.MixBook
{
    public partial class frmNoScanReport : BaseClass.frmBase
    {
        public frmNoScanReport(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator","MBLead","MixBook" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        public UserPrincipal ApplicationUser { get; set; }

        private void frmWipReport_Load(object sender, EventArgs e)
        {
            SetColumns();
        
        }

      private List<WipReportModel> DataResult { get; set; }

        private void SetColumns()
        {
            if (rbCovers.Checked)
            {
                 dgScans.Columns["CoverPress"].Visible = true;//cd29        
                dgScans.Columns["CTrimming"].Visible = true;//43
                dgScans.Columns["OnBoards"].Visible = true;//37
                dgScans.Columns["CoverCart"].Visible = true;//37loc


                dgScans.Columns["WipPress"].Visible = false;//29 war
                dgScans.Columns["PTrimming"].Visible = false;//wd43
                dgScans.Columns["Binding"].Visible = false;//39
                dgScans.Columns["PressCart"].Visible = false;//39
                dgScans.Columns["CaseIn"].Visible = false;//49
                dgScans.Columns["Quality"].Visible = false;//50
            }
            else if (rbBooks.Checked)
            {
               

                dgScans.Columns["CoverPress"].Visible = false;//cd29        
                dgScans.Columns["CTrimming"].Visible = false;//43
                dgScans.Columns["OnBoards"].Visible = false;//37
                dgScans.Columns["CoverCart"].Visible = false;//37loc


                dgScans.Columns["WipPress"].Visible = true;//29 war
                dgScans.Columns["PTrimming"].Visible = true;//wd43
                dgScans.Columns["Binding"].Visible = true;//39
                dgScans.Columns["PressCart"].Visible = true;//39
                dgScans.Columns["CaseIn"].Visible = true;//49
                dgScans.Columns["Quality"].Visible = true;//50
            }
            LoadData();
        }
   private void LoadData()
        {
            
            if (rbBooks.Checked)
            {
               
                LoadBooks();
            }
            else if (rbCovers.Checked)
            {
                LoadCovers();
            }
          

            
      
        }
        private void LoadBooks()
        {
            var sqlClient1 = new SQLCustomClient();
            string cmdBook = @"Select 
             
                 MO.ShipName
                ,Convert(VARCHAR,Mo.OrderReceivedDate,22)AS OrderReceivedDate
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
                ,Case WHEN WI.Rmbto IS NULL THEN 'N'  ELSE  'Y' END AS IsBookRemake
                ,W.War
                ,CASE W.DescripId
                When 39 Then 'Binding'
                When 29 then 'WipPress'
                When 43 then 'PTrimming'
                When 50 then 'Quality'
                else ''
                End Scan
                from MixBookOrder MO 
                Left Join Produtn P On MO.Invno=P.Invno
                Left Join Wip WI ON MO.Invno=WI.Invno
                Left Join Covers C On MO.Invno=C.Invno
                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From CoverDetail  Where DescripId=37 ) CD37 On MO.Invno=CD37.Invno
                                        Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From CoverDetail  Where DescripId=29 ) CD29 On MO.Invno=CD29.Invno
                                        Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From CoverDetail  Where DescripId=43 ) CD43 On MO.Invno=CD43.Invno
                Left Join (Select WD.Invno,WD.DescripId,  Convert(VARCHAR,tmpWD.War,22)As War From
                (Select Invno, Max(war)As War From WipDetail Where DescripId=29 Or DescripId=39 Or DescripId=43 or DescripId=49 or DescripId=50 Group By Invno)tmpWD
                Inner Join WipDetail WD On WD.Invno=tmpWD.Invno and WD.War=tmpWD.War) W On Mo.Invno=W.invno
                Where  MO.MixbookOrderStatus !='Cancelled' and P.Kitrecvd IS NOT NULL AND P.Shpdate IS NULL  AND ((DateDiff(hour,MO.OrderReceivedDate,GETDATE())>23 AND W.War IS NULL ) OR DATEDIFF(hour,W.War,GETDate())>23)
                Order by W.War";
            sqlClient1.CommandText(cmdBook);
            var result = sqlClient1.SelectMany<NoBookScannedReportModel>();
            if (result.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Error getting covers not scanned data:" + result.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Error getting covers not scanned data, print cancelled.");
                return;
            }

            List<NoBookScannedReportModel> data = (List<NoBookScannedReportModel>)result.Data;
            bsData.DataSource = data;
            if (data == null)
            {
                lblRecCount.Text="0 Records";
            }
            else
            {
                lblRecCount.Text = data.Count.ToString() + " Records";
            }
           

        }
        private void LoadCovers()
        {
            
            var sqlClient1 = new SQLCustomClient();
            //OLD Do Not remove
            //string cmdBook = @"Select 
            //                                 MO.ShipName
            //                                ,Convert(VARCHAR,Mo.OrderReceivedDate,22)AS OrderReceivedDate
            //                                ,(Substring(LTRIM(RTRIM(Convert(varchar,MO.Invno))),1,7)+'   X'+Substring(LTRIM(RTRIM(Convert(varchar,MO.Invno))),8,Len(Convert(varchar,MO.Invno)-7)))AS Invno
            //                                ,MO.Copies
            //                                ,Mo.Pages
            //                                ,Convert(VARCHAR(10),MO.RequestedShipDate,101)AS RequestedShipDate
            //                                ,MO.Description
            //                                ,MO.Backing
            //                                ,P.Kitrecvd
            //                                ,WD29.War AS WipPress
            //                                ,COALESCE(WD43.War,'') As PTrimming
            //                                ,WD43.Mxblocation As PTrimLoc 
            //                                ,WD39.War AS Binding
            //                                ,WD39.MxbLocation AS PCart
            //                                ,WD49.War AS CaseIn
            //                                ,WD50.War AS Quality				                          
            //                                ,WD50.MxbLocation AS Location
            //                                ,Case When C1.Remake=1 Then 'Y' Else 'N' End IsCoverRemake

            //                                ,Case WHEN WI.Rmbto IS NULL THEN 'N'  ELSE  'Y' END AS IsBookRemake
            //                                ,C.War
            //                                ,CASE C.DescripId
            //                                When 29 Then 'CPress'
            //                                When 43 then 'CTrimming'
            //                                When 37 then 'OnBoards'

            //                                else ''
            //                                End Scan
            //                            from MixBookOrder MO 
            //                                Left Join Produtn P On MO.Invno=P.Invno
            //                                Left Join Wip WI ON MO.Invno=WI.Invno
            //                                Left Join Covers C1 On MO.Invno=C1.Invno

            //                                Left Join (Select CD.Invno,CD.DescripId,  Convert(VARCHAR,tmpCD.War,22)As War From
            //                                (Select Invno, Max(war)As War From CoverDetail Where DescripId=29 Or DescripId=37 Or DescripId=43  Group By Invno)tmpCD
            //                                Inner Join CoverDetail CD On CD.Invno=tmpCD.Invno and CD.War=tmpCD.War) C On Mo.Invno=C.invno


            //                                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War From WipDetail  Where DescripId=29  ) WD29 On MO.Invno=WD29.Invno
            //                                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail  Where DescripId=39) WD39 On MO.Invno=WD39.Invno
            //                                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail  Where DescripId=43 ) WD43 On MO.Invno=WD43.Invno
            //                                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War From WipDetail Where DescripId=49  ) WD49 On MO.Invno=WD49.Invno
            //                                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail Where DescripId=50  ) WD50 On MO.Invno=WD50.Invno
            //                            Where  MO.MixbookOrderStatus !='Cancelled' and P.Kitrecvd IS NOT NULL AND P.Shpdate IS NULL AND ((DateDiff(hour,MO.OrderReceivedDate,GETDATE())>23 AND C.War IS NULL ) OR DATEDIFF(hour,C.War,GETDate())>23)
            //                            Order by C.War";


            string cmdBook = @"Select 
                    MO.ShipName
                ,Convert(VARCHAR,Mo.OrderReceivedDate,22)AS OrderReceivedDate
                ,(Substring(LTRIM(RTRIM(Convert(varchar,MO.Invno))),1,7)+'   X'+Substring(LTRIM(RTRIM(Convert(varchar,MO.Invno))),8,Len(Convert(varchar,MO.Invno)-7)))AS Invno
                ,MO.Copies
                ,Mo.Pages
                ,Convert(VARCHAR(10),MO.RequestedShipDate,101)AS RequestedShipDate
                ,MO.Description
                ,MO.Backing
                ,P.Kitrecvd
                ,WD29.War AS WipPress
                ,COALESCE(WD43.War,'') As PTrimming
                ,WD43.Mxblocation As PTrimLoc 
                ,WD39.War AS Binding
                ,WD39.MxbLocation AS PCart
                ,WD49.War AS CaseIn
                ,WD50.War AS Quality				                          
                ,WD50.MxbLocation AS Location
                ,Case When C1.Remake=1 Then 'Y' Else 'N' End IsCoverRemake
              
                ,Case WHEN WI.Rmbto IS NULL THEN 'N'  ELSE  'Y' END AS IsBookRemake
                ,Case When C.War IS NOT NULL then C.war When C2.War Is Not Null then C2.War END As War
				,C.War AS CWAR
				,C2.War AS CWAR2
                ,CASE C.DescripId
                When 29 Then 'CPress'
                When 43 then 'CTrimming'
                When 37 then 'OnBoards'
               
                else ''
                End Scan
            from MixBookOrder MO 
                Left Join Produtn P On MO.Invno=P.Invno
                Left Join Wip WI ON MO.Invno=WI.Invno
                Left Join Covers C1 On MO.Invno=C1.Invno
			
                Left Join (Select CD.Invno,CD.DescripId,  Convert(VARCHAR,tmpCD.War,22)As War From
											
                (Select Invno, Max(war)As War From CoverDetail Where DescripId=29 Or DescripId=43    Group By Invno)tmpCD
										
                Inner Join CoverDetail CD On CD.Invno=tmpCD.Invno and CD.War=tmpCD.War) C On Mo.Invno=C.invno AND MO.Backing='HC'

				
				Left Join (Select CD.Invno,CD.DescripId,  Convert(VARCHAR,tmpCD.War,22)As War From
											
                (Select Invno, Max(war)As War From CoverDetail Where DescripId=29 Or DescripId=37    Group By Invno)tmpCD
										
                Inner Join CoverDetail CD On CD.Invno=tmpCD.Invno and CD.War=tmpCD.War) C2 On Mo.Invno=C2.invno AND MO.Backing='SC'


               
			   
			   Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War From WipDetail  Where DescripId=29  ) WD29 On MO.Invno=WD29.Invno

                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail  Where DescripId=39) WD39 On MO.Invno=WD39.Invno

                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail  Where DescripId=43 ) WD43 On MO.Invno=WD43.Invno

                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War From WipDetail Where DescripId=49  ) WD49 On MO.Invno=WD49.Invno

                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail Where DescripId=50  ) WD50 On MO.Invno=WD50.Invno
			
            Where  MO.MixbookOrderStatus !='Cancelled' and P.Kitrecvd IS NOT NULL AND P.Shpdate IS NULL AND 
			((MO.Backing='HC' And C.War IS NULL)OR(MO.Backing='SC' And C2.War IS NULL)) AND((DateDiff(hour,MO.OrderReceivedDate,GETDATE())>23 AND C.War IS NULL ) OR DATEDIFF(hour,C.War,GETDate())>23)
            Order by C.War";
            sqlClient1.CommandText(cmdBook);
            var result = sqlClient1.SelectMany<NoBookScannedReportModel>();
            if (result.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Error getting covers not scanned data:" + result.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Error getting covers not scanned data, print cancelled.");
                return;
            }

            List<NoBookScannedReportModel> data = (List<NoBookScannedReportModel>)result.Data;
            bsData.DataSource = data;
            if (data == null)
            {
                lblRecCount.Text = "0 Records";
            }
            else
            {
                lblRecCount.Text = data.Count.ToString() + " Records";
            }
            


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

            if (bsData.Count<1)
            {
                MbcMessageBox.Hand("There are no records to print.","No Records");
                return;
            }
            try
            {
                saveFileDialog1.Filter = "Comma Seperated Value|*.csv";
                if (rbBooks.Checked)
                {
                     saveFileDialog1.FileName = "BooksNotScanned.csv";
                }
                else
                {
                    saveFileDialog1.FileName = "CoversNotScanned.csv";
                }
               
                saveFileDialog1.ShowDialog();
                //using (var mem = new MemoryStream())
                using (var writer = new StreamWriter(saveFileDialog1.FileName))
                using (var csvWriter = new CsvWriter(writer))
                {
                    csvWriter.Configuration.Delimiter = ",";
                    //csvWriter.Configuration.HasHeaderRecord = true;
                    // csvWriter.Configuration.AutoMap<InqCountModel>();

                    //csvWriter.WriteHeader<InqCountModel>();
                    csvWriter.WriteRecords(bsData);

                    writer.Flush();

                    Process.Start(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error("Error creating file:" + ex.Message);
            }
        }

      

        private void rbBooks_CheckedChanged(object sender, EventArgs e)
        {
            SetColumns();
        }

        private void rbCovers_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void dgScans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgScans.CurrentCell.ColumnIndex.Equals(1))
                if (dgScans.CurrentCell != null && dgScans.CurrentCell.Value != null)
                {
                    int theClinetOrderId;
                    string _clientOrderId = dgScans.CurrentRow.Cells[1].Value.ToString().Substring(0,7);
                    if (int.TryParse(_clientOrderId, out theClinetOrderId))
                    {

                        frmMBOrders frmMBOrders = new frmMBOrders(this.ApplicationUser, theClinetOrderId);
                        frmMBOrders.MdiParent = this.MdiParent;
                        frmMBOrders.Show();
                        this.Cursor = Cursors.Default;
                    }
                }



        }
    }
    
}
