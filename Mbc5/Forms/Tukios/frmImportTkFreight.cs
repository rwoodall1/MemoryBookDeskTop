using BaseClass;
using BaseClass.Classes;
using BindingModels;
using CsvHelper;
using NLog.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mbc5.Forms.Tukios
{
    public partial class frmImportTkFreight : BaseClass.frmBase
    {
       
        public frmImportTkFreight(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "Tukios", "BARCODE", "MBLead" }, userPrincipal)
        {
            InitializeComponent();
        }
        public List<TukiosFreight> TKFreight = new List<TukiosFreight>();   
        private void btnLoad_Click(object sender, EventArgs e)
        {
            TKFreight.Clear();
            bsData.Clear();
            dataGridView1.DataSource = bsData;

            lblCount.Text = "" ;
            lblSum.Text = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int numRecs = openFileDialog1.FileNames.Count();
                for (int i = 0; i < numRecs; i++)
                {
                    textBox1.Text = openFileDialog1.FileNames[i];

                    var config = new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
                    {
                        MissingFieldFound = null,

                    };
                    string tmpTrackingNumber = "";
                    var badRecords = new List<TukiosBadRec>();
                    try
                    {
                        using (var reader = new StreamReader(textBox1.Text))
                        using (var csv = new CsvReader(reader, config))
                        {

                            var records = new List<TukiosFreight>();
                           
                            csv.Read();
                            csv.ReadHeader();

                            while (csv.Read())
                            {
                                tmpTrackingNumber = csv.GetField("Customer IMPb");//K
                                var tmpFreight = csv.GetField("UPSMI");//R
                                var tmpCostCenter = csv.GetField("Cost Center Name");//F
                                var pieceId= csv.GetField("Piece ID");
                                if ( tmpTrackingNumber!=null && tmpTrackingNumber.Length > 5)
                                {
                                    decimal _freight = 0;
                                    if (!decimal.TryParse(tmpFreight, out _freight))
                                    {
                                       MbcMessageBox.Error(tmpTrackingNumber + " has an invalid freight value: " + tmpFreight);
                                        var _rec = new TukiosBadRec()
                                        {
                                            TrackingNumber = tmpTrackingNumber,
                                            Freight = tmpFreight,
                                            CostCenter = tmpCostCenter,
                                            PieceId = pieceId
                                        };
                                        badRecords.Add(_rec);
                                        continue;
                                    }
                                    var record = new TukiosFreight
                                    {

                                        TrackingNumber = tmpTrackingNumber,
                                        Freight = _freight+3,
                                        CostCenter = tmpCostCenter,
                                        PieceId=pieceId
                                    };
                                   
                                        records.Add(record);
                                }
                                else
                                {
                                    var _rec = new TukiosBadRec()
                                    {
                                        TrackingNumber = tmpTrackingNumber,
                                        Freight = tmpFreight,
                                        CostCenter = tmpCostCenter,
                                        PieceId = pieceId
                                    };
                                    badRecords.Add(_rec);
                                }
                                }
                            TKFreight.AddRange(records);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to import data:" + ex.Message);
                        return;
                    }

            
                    using (var writer = new StreamWriter("c:\\temp\\BadCSVRecords.csv"))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(badRecords);
                    }


                }
                if (TKFreight.Count > 0)
                {
                  
                    bsData.DataSource = TKFreight;
                    dataGridView1.DataSource = bsData;
                
                    lblCount.Text = "Count: " + TKFreight.Count.ToString();
                    lblSum.Text = TKFreight.Sum(x => x.Freight).ToString("C");
                    MessageBox.Show("Data Loaded, ready to be saved!");
                }
                else
                {
                    MessageBox.Show("No records loaded");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             var notUpdated = new List<TukiosBadRec>();
            var sqlClient = new SQLCustomClient().CommandText(@"
                Update TukiosOrder Set Freight = @Freight Where TrackingNumber LIKE @TrackingNumber
                ");
            foreach (var item in TKFreight)
            {
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@TrackingNumber", "%" + item.TrackingNumber + "%");
                sqlClient.AddParameter("@Freight", item.Freight);
                var result = sqlClient.Update();
                if (result.IsError)
                {
                    MessageBox.Show("Failed to update record: " + item.TrackingNumber + " Error: " + result.Errors[0].DeveloperMessage);
                    var _rec = new TukiosBadRec()
                    {
                        TrackingNumber = item.TrackingNumber,
                        Freight = item.Freight.ToString(),
                        CostCenter = item.CostCenter,
                        PieceId = item.PieceId
                    };

                    notUpdated.Add(_rec);
                    continue;
                }
                if (result.Data==0)
                {
                   // MessageBox.Show("Failed to update record not found: " + item.TrackingNumber);
                    var _rec = new TukiosBadRec()
                    {
                        TrackingNumber = item.TrackingNumber,
                        Freight =item.Freight.ToString(),
                        CostCenter = item.CostCenter,
                        PieceId = item.PieceId
                    };
                  
                    notUpdated.Add(_rec);
                    
                }
            }
         
            using (var writer = new StreamWriter("c:\\temp\\NotUpdated.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(notUpdated);
            }
            MbcMessageBox.Information("Import complete");
        }





        //end of class
    }
  
    
}
