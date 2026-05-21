using BaseClass;
using BaseClass.Classes;
using BindingModels;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
namespace Mbc5.Forms.Tukios
{
    public partial class frmTukiosNoScanReport : BaseClass.frmBase
    {
        public frmTukiosNoScanReport(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MBLead", "MixBook" }, userPrincipal)
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
             
                 TO1.ShipName
                ,Convert(VARCHAR,TO1.OrderReceivedDate,22)AS OrderReceivedDate
                ,LTRIM(RTRIM(Convert(varchar,TO1.Invno)))AS Invno
            
                ,GroupId
                ,TO1.Copies
                ,TO1.Pages
                ,Convert(VARCHAR(10),TO1.RequestedShipDate,101)AS RequestedShipDate
                ,TO1.Description
                ,TO1.Backing
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
                from TukiosOrder TO1
                Left Join Produtn P On TO1.Invno=P.Invno
                Left Join Wip WI ON TO1.Invno=WI.Invno
                Left Join Covers C On TO1.Invno=C.Invno
                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From CoverDetail  Where DescripId=37 ) CD37 On TO1.Invno=CD37.Invno
                                        Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From CoverDetail  Where DescripId=29 ) CD29 On TO1.Invno=CD29.Invno
                                        Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From CoverDetail  Where DescripId=43 ) CD43 On TO1.Invno=CD43.Invno
                Left Join (Select WD.Invno,WD.DescripId,  Convert(VARCHAR,tmpWD.War,22)As War From
                (Select Invno, Max(war)As War From WipDetail Where DescripId=29 Or DescripId=39 Or DescripId=43 or DescripId=49 or DescripId=50 Group By Invno)tmpWD
                Inner Join WipDetail WD On WD.Invno=tmpWD.Invno and WD.War=tmpWD.War) W On TO1.Invno=W.invno
                Where  TO1.TukiosOrderStatus !='Cancelled' and P.Kitrecvd IS NOT NULL AND P.Shpdate IS NULL  AND ((DateDiff(hour,TO1.OrderReceivedDate,GETDATE())>23 AND W.War IS NULL ) OR DATEDIFF(hour,W.War,GETDate())>23)
                Order by TO1.GroupId,W.War";
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
        private void LoadCovers()
        {

            var sqlClient1 = new SQLCustomClient();



            string cmdBook = @"Select 
                    TO1.ShipName
                ,Convert(VARCHAR,TO1.OrderReceivedDate,22)AS OrderReceivedDate
                ,LTRIM(RTRIM(Convert(varchar,TO1.Invno)))AS Invno
                 ,GroupId                
                ,TO1.Copies
                ,TO1.Pages
                ,Convert(VARCHAR(10),TO1.RequestedShipDate,101)AS RequestedShipDate
                ,TO1.Description
                ,TO1.Backing
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
            from TukiosOrder TO1 
                Left Join Produtn P On TO1.Invno=P.Invno
                Left Join Wip WI ON TO1.Invno=WI.Invno
                Left Join Covers C1 On TO1.Invno=C1.Invno
			
                Left Join (Select CD.Invno,CD.DescripId,  Convert(VARCHAR,tmpCD.War,22)As War From
											
                (Select Invno, Max(war)As War From CoverDetail Where DescripId=29 Or DescripId=43    Group By Invno)tmpCD
										
                Inner Join CoverDetail CD On CD.Invno=tmpCD.Invno and CD.War=tmpCD.War) C On TO1.Invno=C.invno AND TO1.Backing='HC'

				
				Left Join (Select CD.Invno,CD.DescripId,  Convert(VARCHAR,tmpCD.War,22)As War From
											
                (Select Invno, Max(war)As War From CoverDetail Where DescripId=29 Or DescripId=37    Group By Invno)tmpCD
										
                Inner Join CoverDetail CD On CD.Invno=tmpCD.Invno and CD.War=tmpCD.War) C2 On TO1.Invno=C2.invno AND TO1.Backing='SC'


               
			   
			   Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War From WipDetail  Where DescripId=29  ) WD29 On TO1.Invno=WD29.Invno

                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail  Where DescripId=39) WD39 On TO1.Invno=WD39.Invno

                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail  Where DescripId=43 ) WD43 On TO1.Invno=WD43.Invno

                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War From WipDetail Where DescripId=49  ) WD49 On TO1.Invno=WD49.Invno

                Left Join (Select Invno,DescripId,Convert(VARCHAR,War,22)As War,MxbLocation From WipDetail Where DescripId=50  ) WD50 On TO1.Invno=WD50.Invno
			
            Where  TO1.TukiosOrderStatus !='Cancelled' and P.Kitrecvd IS NOT NULL AND P.Shpdate IS NULL AND 
			((TO1.Backing='HC' And C.War IS NULL)OR(TO1.Backing='SC' And C2.War IS NULL)) AND((DateDiff(hour,TO1.OrderReceivedDate,GETDATE())>23 AND C.War IS NULL ) OR DATEDIFF(hour,C.War,GETDate())>23)
            Order by TO1.GroupId,C.War";
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

            if (bsData.Count < 1)
            {
                MbcMessageBox.Hand("There are no records to print.", "No Records");
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
                    string theClinetOrderId = dgScans.CurrentRow.Cells[1].Value.ToString().Substring(0, 7);


                    frmTKOrders frmTkOrders = new frmTKOrders(this.ApplicationUser, theClinetOrderId);
                    frmTkOrders.MdiParent = this.MdiParent;
                    frmTkOrders.Show();
                    this.Cursor = Cursors.Default;

                }



        }
    }

}
