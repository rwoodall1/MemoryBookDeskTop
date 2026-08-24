using BaseClass;
using BaseClass.Classes;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BindingModels;
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
                    try
                    {
                        using (var reader = new StreamReader(textBox1.Text))
                        using (var csv = new CsvReader(reader, config))
                        {

                            var records = new List<TukiosFreight>();
                            //start reading at 4th line.
                            csv.Read();
                            csv.ReadHeader();

                            while (csv.Read())
                            {
                                tmpTrackingNumber = csv.GetField("Customer IMPb");
                                var tmpFreight = csv.GetField("UPSMI");
                                var tmpCostCenter = csv.GetField("Cost Center Name");
                                if (tmpCostCenter.ToUpper() == "TUKIOS" && tmpTrackingNumber.Length > 5)
                                {
                                    decimal _freight = 0;
                                    if (!decimal.TryParse(tmpFreight, out _freight))
                                    {
                                       MbcMessageBox.Error(tmpTrackingNumber + " has an invalid freight value: " + tmpFreight);
                                    }
                                    var record = new TukiosFreight
                                    {

                                        TrackingNumber = tmpTrackingNumber,
                                        Freight = _freight,
                                        CostCenter = tmpCostCenter
                                    };
                                   
                                        records.Add(record);
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
                }
            }
            MbcMessageBox.Information("Import complete");
        }





        //end of class
    }
    
    }
