namespace Mbc5.Forms {
	partial class test {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.button1 = new System.Windows.Forms.Button();
			this.dsInvoice = new Mbc5.DataSets.dsInvoice();
			this.invoiceTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.invoiceTableAdapter();
			this.invdetailTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.invdetailTableAdapter();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.FullInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dsInvoice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FullInvoiceBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 403);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(111, 54);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dsInvoice
			// 
			this.dsInvoice.DataSetName = "dsInvoice";
			this.dsInvoice.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// invoiceTableAdapter
			// 
			this.invoiceTableAdapter.ClearBeforeFill = true;
			// 
			// invdetailTableAdapter
			// 
			this.invdetailTableAdapter.ClearBeforeFill = true;
			// 
			// reportViewer1
			// 
			this.reportViewer1.DocumentMapWidth = 35;
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = this.FullInvoiceBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.test.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(125, 44);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(890, 413);
			this.reportViewer1.TabIndex = 17;
			this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
			this.reportViewer1.ReportError += new Microsoft.Reporting.WinForms.ReportErrorEventHandler(this.reportViewer1_ReportError);
			// 
			// FullInvoiceBindingSource
			// 
			this.FullInvoiceBindingSource.DataSource = typeof(BindingModels.FullInvoice);
			// 
			// test
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1163, 660);
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.button1);
			this.Name = "test";
			this.Text = "test";
			this.Load += new System.EventHandler(this.test_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsInvoice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FullInvoiceBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private DataSets.dsInvoice dsInvoice;
		private DataSets.dsInvoiceTableAdapters.invoiceTableAdapter invoiceTableAdapter;
		private DataSets.dsInvoiceTableAdapters.invdetailTableAdapter invdetailTableAdapter;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.BindingSource FullInvoiceBindingSource;
	}
}