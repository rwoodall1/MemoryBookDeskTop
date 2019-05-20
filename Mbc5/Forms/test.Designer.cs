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
			this.FullInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dsInvoice = new Mbc5.DataSets.dsInvoice();
			this.invoiceTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.invoiceTableAdapter();
			this.invdetailTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.invdetailTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.FullInvoiceBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsInvoice)).BeginInit();
			this.SuspendLayout();
			// 
			// FullInvoiceBindingSource
			// 
			this.FullInvoiceBindingSource.DataSource = typeof(BindingModels.FullInvoice);
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
			// test
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1163, 660);
			this.Name = "test";
			this.Text = "test";
			this.Load += new System.EventHandler(this.test_Load);
			((System.ComponentModel.ISupportInitialize)(this.FullInvoiceBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsInvoice)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private DataSets.dsInvoice dsInvoice;
		private DataSets.dsInvoiceTableAdapters.invoiceTableAdapter invoiceTableAdapter;
		private DataSets.dsInvoiceTableAdapters.invdetailTableAdapter invdetailTableAdapter;
		private System.Windows.Forms.BindingSource FullInvoiceBindingSource;
	}
}