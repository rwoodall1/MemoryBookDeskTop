namespace Mbc5.Reports
{
    partial class ReportTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsInvoice = new Mbc5.DataSets.dsInvoice();
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invdetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymntBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.custTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.custTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsInvoiceTableAdapters.TableAdapterManager();
            this.invoiceTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.invoiceTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.invdetailTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.invdetailTableAdapter();
            this.paymntTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.paymntTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invdetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymntBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // custBindingSource
            // 
            this.custBindingSource.DataMember = "cust";
            this.custBindingSource.DataSource = this.dsInvoice;
            // 
            // dsInvoice
            // 
            this.dsInvoice.DataSetName = "dsInvoice";
            this.dsInvoice.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // invoiceBindingSource
            // 
            this.invoiceBindingSource.DataMember = "invoice";
            this.invoiceBindingSource.DataSource = this.dsInvoice;
            // 
            // invdetailBindingSource
            // 
            this.invdetailBindingSource.DataMember = "invdetail";
            this.invdetailBindingSource.DataSource = this.dsInvoice;
            // 
            // paymntBindingSource
            // 
            this.paymntBindingSource.DataMember = "paymnt";
            this.paymntBindingSource.DataSource = this.dsInvoice;
            // 
            // custTableAdapter
            // 
            this.custTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.custTableAdapter = this.custTableAdapter;
            this.tableAdapterManager.invdetailTableAdapter = null;
            this.tableAdapterManager.invoiceTableAdapter = this.invoiceTableAdapter;
            this.tableAdapterManager.paymntTableAdapter = null;
            this.tableAdapterManager.quotesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsInvoiceTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // invoiceTableAdapter
            // 
            this.invoiceTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bindingSource1;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.custBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 30);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(813, 432);
            this.reportViewer1.TabIndex = 6;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // invdetailTableAdapter
            // 
            this.invdetailTableAdapter.ClearBeforeFill = true;
            // 
            // paymntTableAdapter
            // 
            this.paymntTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ReportTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 506);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportTest";
            this.Text = "ReportTest";
            this.Load += new System.EventHandler(this.ReportTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invdetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymntBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataSets.dsInvoice dsInvoice;
        private System.Windows.Forms.BindingSource custBindingSource;
        private DataSets.dsInvoiceTableAdapters.custTableAdapter custTableAdapter;
        private DataSets.dsInvoiceTableAdapters.TableAdapterManager tableAdapterManager;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSets.dsInvoiceTableAdapters.invoiceTableAdapter invoiceTableAdapter;
        private System.Windows.Forms.BindingSource invoiceBindingSource;
        private System.Windows.Forms.BindingSource invdetailBindingSource;
        private DataSets.dsInvoiceTableAdapters.invdetailTableAdapter invdetailTableAdapter;
        private System.Windows.Forms.BindingSource paymntBindingSource;
        private DataSets.dsInvoiceTableAdapters.paymntTableAdapter paymntTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}