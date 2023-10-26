using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass;
using Mbc5.Classes;
using BindingModels;
using CsvHelper;
using System.IO;
using System.Diagnostics;
namespace Mbc5.Forms.Meridian
{
    public partial class frmMerBindingTime : BaseClass.frmBase
    {
        public frmMerBindingTime(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
            if (userPrincipal.UserName.ToUpper() == "SA" || userPrincipal.UserName.ToUpper() == "MARK" || userPrincipal.UserName.ToUpper() =="CHRIS")
            {
                btnDelete.Visible = true;
            }
        }
        private bool ValidateForm { get; set; } = false;
        private void btnSave_Click(object sender, EventArgs e)
        {
            ValidateForm = true;
            if (this.ValidateChildren())
            {
                if (Save())
                {
                    ValidateForm = false;
                    LoadData();
                    ClearFields();
                }
                ValidateForm = false;
            }
        }
        private void ClearFields()
        {
            cmbProduct.Text = "";
            cmbTask.Text = "";
            txtInitials.Text = "";
            txtQty.Text = "";
            txtTime.Text = "";
            txtDesc.Text = "";
        }
       new private bool Save()
        {
            var sqlQuery = new SQLCustomClient().CommandText("Insert INTO MerBindingWip (ProductType,Task,Initials,Time,Description,Quantity) Values(@ProductType,@Task,@Initials,@Time,@Description,@Quantity)");
            sqlQuery.AddParameter("@ProductType",cmbProduct.Text);
            sqlQuery.AddParameter("@Task",cmbTask.Text);
            sqlQuery.AddParameter("@Initials",txtInitials.Text);
            sqlQuery.AddParameter("@Time",txtTime.Text);
            sqlQuery.AddParameter("@Description",txtDesc.Text);
            sqlQuery.AddParameter("@Quantity",txtQty.Text);
            var result = sqlQuery.Insert();

            if (result.IsError)
            {
                Log.Error("Failed to insert MerBindingWip Data:" + result.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to Insert Data");
                return false;
            }
            return true;

        }
        private void LoadData()
        {
            var sqlQuery = new SQLCustomClient().CommandText("SELECT Top(200) Id,DateCreated,ProductType,Task,Initials,Time,Description,Quantity FROM MerBindingWip   Where Year(GETDate())=Year(DateCreated) Order By DateCreated Desc");
            var selectResult=sqlQuery.SelectMany<MerBindingWip>();
            if (selectResult.IsError)
            {
                Log.Error("Failed to retrieve MerBinding Wip Data");
                MbcMessageBox.Error("Failed to retrieve data.");
                return;
            }
            bsWipData.DataSource = null;
            bsWipData.DataSource =(List<MerBindingWip>)selectResult.Data;
        }
        private void DeleteRow()
        {
            var sqlQuery = new SQLCustomClient().CommandText("Delete FROM Where Id=@Id");
            sqlQuery.AddParameter("@Id",0);
           var result= sqlQuery.Delete();
            if (result.IsError)
            {
                MbcMessageBox.Error("Failed to delete record.");
                Log.Error("Failed to delete MerBindingWip record." + result.Errors[0].DeveloperMessage);
                return;
            }
            LoadData();
        }

        private void txtTime_Validating(object sender, CancelEventArgs e)
        {
            if (ValidateForm)
            {


                decimal vTime;
                errorProvider1.SetError(txtTime, "");
                if (!decimal.TryParse(txtTime.Text, out vTime))
                {
                    errorProvider1.SetError(txtTime, "Enter a valid numeric time.");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void txtQty_Validating(object sender, CancelEventArgs e)
        {
            //int vQty;
            //if (ValidateForm)
            //{
            //    errorProvider1.SetError(txtTime, "");
            //    if (!int.TryParse(txtQty.Text, out vQty))
            //    {
            //        errorProvider1.SetError(txtTime, "Enter a valid numeric quantity.");
            //        e.Cancel = true;
            //        return;
            //    }
            //}
        }

        private void txtInitials_Validating(object sender, CancelEventArgs e)
        {
            if (ValidateForm)
            {
                errorProvider1.SetError(txtTime, "");
                if (string.IsNullOrEmpty(txtInitials.Text))
                {
                    errorProvider1.SetError(txtTime, "Enter your initials");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void cmbProduct_Validating(object sender, CancelEventArgs e)
        {
            if (ValidateForm)
            {
                errorProvider1.SetError(cmbProduct, "");
                if (string.IsNullOrEmpty(cmbProduct.Text))
                {
                    errorProvider1.SetError(cmbProduct, "Select product type");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void cmbTask_Validating(object sender, CancelEventArgs e)
        {
            if (ValidateForm)
            {
                errorProvider1.SetError(cmbTask, "");
                if (string.IsNullOrEmpty(cmbTask.Text))
                {
                    errorProvider1.SetError(cmbTask, "Select a task");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void MerBindingTime_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      
            if (e.RowIndex == -1)
            {
                List<MerBindingWip> dataList = (List<MerBindingWip>) bsWipData.DataSource;
               
                switch (e.ColumnIndex)
                {
                    case 1:
                        bsWipData.DataSource = null;
                        if (dgData.Columns[e.ColumnIndex].HeaderText.Contains(".."))//desc
                        {
                            dataList.Sort((x1, x2) => x1.DateCreated.CompareTo(x2.DateCreated));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace("..", ".");
                        }
                        else
                        {
                            dataList.Sort((x1, x2) => x2.DateCreated.CompareTo(x1.DateCreated));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace(".", "..");
                        }
                       
                        bsWipData.DataSource = dataList;
                        break;
                    case 2:
                        bsWipData.DataSource = null;
                        if (dgData.Columns[e.ColumnIndex].HeaderText.Contains(".."))//desc
                        {
                            dataList.Sort((x1, x2) => x1.ProductType.CompareTo(x2.ProductType));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace("..", ".");
                        }
                        else
                        {
                            dataList.Sort((x1, x2) => x2.ProductType.CompareTo(x1.ProductType));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace(".", "..");
                        }

                        bsWipData.DataSource = dataList;
                        break;
                    case 3:
                        bsWipData.DataSource = null;
                        if (dgData.Columns[e.ColumnIndex].HeaderText.Contains(".."))//desc
                        {
                            dataList.Sort((x1, x2) => x1.Task.CompareTo(x2.Task));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace("..", ".");
                        }
                        else
                        {
                            dataList.Sort((x1, x2) => x2.Task.CompareTo(x1.Task));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace(".", "..");
                        }

                        bsWipData.DataSource = dataList;
                        break;
                    case 4:
                        bsWipData.DataSource = null;
                        if (dgData.Columns[e.ColumnIndex].HeaderText.Contains(".."))//desc
                        {
                            dataList.Sort((x1, x2) => x1.Quantity.CompareTo(x2.Quantity));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace("..", ".");
                        }
                        else
                        {
                            dataList.Sort((x1, x2) => x2.Quantity.CompareTo(x1.Quantity));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace(".", "..");
                        }

                        bsWipData.DataSource = dataList;
                        break;
                    case 5:
                        bsWipData.DataSource = null;
                        if (dgData.Columns[e.ColumnIndex].HeaderText.Contains(".."))//desc
                        {
                            dataList.Sort((x1, x2) => x1.Initials.CompareTo(x2.Initials));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace("..", ".");
                        }
                        else
                        {
                            dataList.Sort((x1, x2) => x2.Initials.CompareTo(x1.Initials));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace(".", "..");
                        }

                        bsWipData.DataSource = dataList;
                        break;
                    case 6:
                        bsWipData.DataSource = null;
                        if (dgData.Columns[e.ColumnIndex].HeaderText.Contains(".."))//desc
                        {
                            dataList.Sort((x1, x2) => x1.Time.CompareTo(x2.Time));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace("..", ".");
                        }
                        else
                        {
                            dataList.Sort((x1, x2) => x2.Time.CompareTo(x1.Time));
                            dgData.Columns[e.ColumnIndex].HeaderText = dgData.Columns[e.ColumnIndex].HeaderText.Replace(".", "..");
                        }

                        bsWipData.DataSource = dataList;
                        break;
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (bsWipData.Count == 0)
            {
                MbcMessageBox.Hand("There are no records to print.", "No Records");
                return;
            }
            var vData = (List<MerBindingWip>)bsWipData.DataSource;
            vData = vData.FindAll(x => x.DateCreated >= dtFrom.Value && x.DateCreated <= dtTo.Value);
            if (vData.Count < 1)
            {
                MbcMessageBox.Hand("There are no records to print.", "No Records");
                return;
            }
            
            
            try
            {
                saveFileDialog1.Filter = "Comma Seperated Value|*.csv";
                saveFileDialog1.FileName = "MeridianBindingReport.csv";
                saveFileDialog1.ShowDialog();
                //using (var mem = new MemoryStream())
                using (var writer = new StreamWriter(saveFileDialog1.FileName))
                using (var csvWriter = new CsvWriter(writer))
                {
                    csvWriter.Configuration.Delimiter = ",";
                    //csvWriter.Configuration.HasHeaderRecord = true;
                    // csvWriter.Configuration.AutoMap<InqCountModel>();

                    //csvWriter.WriteHeader<InqCountModel>();
                    csvWriter.WriteRecords(vData);

                    writer.Flush();

                    Process.Start(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error("Error creating file:" + ex.Message);
            }
        }
        private void Delete()
        {
            var curRow =(MerBindingWip)bsWipData.Current;
            var vId = curRow.Id;
            var sqlQuery = new SQLCustomClient().CommandText("Delete from MerBindingWip Where Id=@Id");
            sqlQuery.AddParameter("@Id", vId);
            var result = sqlQuery.Delete();
            if (result.IsError)
            {
                MbcMessageBox.Error("Failed to delete record.");
                Log.Error("Failed to delete record:" + result.Errors[0].DeveloperMessage);
                return;
            }
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
