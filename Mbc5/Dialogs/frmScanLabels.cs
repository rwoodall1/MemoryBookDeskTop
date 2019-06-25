using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BindingModels;
using BaseClass.Classes;
using BaseClass;
using Microsoft.Reporting.WinForms;
namespace Mbc5.Dialogs
{
    public partial class frmScanLabels :Form
    {
        public frmScanLabels()
        {
            InitializeComponent();
        }

        private void frmScanLabels_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Select Description,Id FROM WipDescriptions Where TableName=@TableName Order By Description");

            switch (comboBox1.Text)
            {
                case "COVERS":
                    sqlClient.AddParameter("@TableName", "COVERS");
                    break;
                case "END SHEETS":
                    sqlClient.AddParameter("@TableName", "ENDSHEET");
                    break;
                case "PARTIAL BOOK":
                    sqlClient.AddParameter("@TableName", "PARTIALBOOK");
                    break;
                case "PHOTOS ON CD":
                    sqlClient.AddParameter("@TableName", "PHOTOCD");
                    break;
                case "WIP":
                    sqlClient.AddParameter("@TableName", "WIP");
                    break;

            }
            var result = sqlClient.SelectMany<DepartmentLabel>();
            if (result.IsError)
            {
                MbcMessageBox.Error(result.Errors[0].ErrorMessage, "");
            }
            var cmbData = (List<DepartmentLabel>)result.Data;
            bsDescriptions.DataSource = cmbData;
            cmbDeptartment.DataSource = bsDescriptions;
            cmbDeptartment.DisplayMember = "Description";
            cmbDeptartment.ValueMember = "Id";

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            ReportParameter rp0 = new ReportParameter("Description",cmbDeptartment.Text);
            ReportParameter rp1 = new ReportParameter("Id", "*"+cmbDeptartment.SelectedValue.ToString()+"*");
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp0,rp1 });
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            try
            {
             reportViewer1.PrintDialog();
            }catch(Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
           
        }
    }
}
