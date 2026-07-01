using BaseClass;
using BaseClass.Classes;
using BaseClass.Core;
using BindingModels;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mbc5.Forms.Tukios
{
    public partial class frmTukiosUPSImport : frmBase
    {
        public frmTukiosUPSImport(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "Tukios", "BARCODE", "MBLead" }, userPrincipal)
        {
            InitializeComponent();
        }
        private List<UPSInvoceData> UPSLineItems = new List<UPSInvoceData>();
        private void btnLoad_Click(object sender, EventArgs e)
        {
            UPSLineItems.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int numRecs = openFileDialog1.FileNames.Count();
                var config = new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = null,
                    BadDataFound = null
                };
                for (int i = 0; i < numRecs; i++)
                {
                    txtFiles.Text = openFileDialog1.FileNames[i];


                    try
                    {
                        using (var reader = new StreamReader(txtFiles.Text))
                        using (var csv = new CsvReader(reader, config))
                        {


                            while (csv.Read())
                            {

                                UPSInvoceData invoiceData = new UPSInvoceData()
                                {

                                    RunDate = DateTime.Now,
                                    AccountNumber = csv.GetField(2),
                                    CustRef = csv.GetField(15),//Tukios Number
                                    ShipmentRef = csv.GetField(16),//Tukios clientId
                                    ShipmentTotal = Convert.ToDecimal(csv.GetField(52))
                                };
                                if (invoiceData.CustRef == "22222")//or what ever number is Tukios number 22222 is for testing only
                                {
                                    UPSLineItems.Add(invoiceData);//only add if Tukios
                                }
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (UPSLineItems.Count > 0)
                    {
                        var groupedSums = UPSLineItems
                        .GroupBy(s => s.ShipmentRef) // Group by the 'Product' property
                        .Select(g => new
                        {
                            ShipmentRef = g.Key,       // The key is the value you grouped by (e.g., "Laptop")
                            ShipmentTotal = g.Sum(s => s.ShipmentTotal) // Sum the 'Quantity' for each group

                        });
                        groupedSums = groupedSums.Where(a => a.ShipmentTotal > 0);
                        var currentData = groupedSums.ToList();
                        bsData.DataSource = currentData;
                        if (currentData.Count() == 0)
                        {
                            MessageBox.Show("No records found");
                        }


                        txtFiles.Clear();
                    }
                    else
                    {
                        MessageBox.Show("No records found");


                        txtFiles.Clear();
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UPSLineItems.Clear();

            txtFiles.Clear();
            bsData.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveToTable();
        }
        private async Task<ApiProcessingResult> SaveToTable()
        {
            var processingResult = new ApiProcessingResult();
            var dataList = (System.Collections.IEnumerable)bsData.DataSource;
            foreach (dynamic item in dataList)
            {
                UPSInvoceData data = new UPSInvoceData()
                {
                    RunDate = DateTime.Now,
                    ShipmentRef = item.ShipmentRef,
                    ShipmentTotal = item.ShipmentTotal
                };

                var result = await SaveRecord(data);

                if (result.IsError)
                {


                    MbcMessageBox.Error("Error saving record with ShipmentRef: " + item.ShipmentRef + " Import has been canceled, correct the error and run the import again.");

                    return processingResult;

                }
            }
            UPSLineItems.Clear();

            txtFiles.Clear();
            bsData.Clear();
            MbcMessageBox.Exclamation("Data has been imported!");
            return processingResult;

        }
        private async Task<ApiProcessingResult> SaveRecord(UPSInvoceData record)
        {
            var processingResult = new ApiProcessingResult();
            var sqlClient = new SQLCustomClient();
            string cmd = @"
        IF EXISTS (SELECT 1 FROM TukiosShipping WHERE ClientOrderId = @ShipmentRef)
        BEGIN
            UPDATE TukiosShipping 
            SET DateCreated = @RunDate, 
                Cost = @ShipmentTotal
            WHERE ClientOrderId = @ShipmentRef
        END
        ELSE
        BEGIN
            INSERT INTO TukiosShipping ( ClientOrderId, Cost) 
            VALUES ( @ShipmentRef, @ShipmentTotal)
        END";
            sqlClient.CommandText(cmd)
                .AddParameter("@RunDate", DateTime.Now)
             .AddParameter("@ShipmentRef", record.ShipmentRef)
            .AddParameter("@ShipmentTotal", record.ShipmentTotal);

            var result = sqlClient.Update();
            if (result.IsError)
            {
                processingResult.IsError = true;
                processingResult.Errors = result.Errors;

            }
            return processingResult;
        }
    }
}
