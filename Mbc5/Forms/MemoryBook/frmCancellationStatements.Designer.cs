namespace Mbc5.Forms.MemoryBook
{
    partial class frmCancellationStatements
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FullInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCust = new Mbc5.DataSets.dsCust();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.dgCancellations = new System.Windows.Forms.DataGridView();
            this.ToPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Collections = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCancel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCancellations = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager1 = new Mbc5.DataSets.dsCustTableAdapters.TableAdapterManager();
            this.dsSales = new Mbc5.DataSets.dsSales();
            this.custTableAdapter = new Mbc5.DataSets.dsCustTableAdapters.custTableAdapter();
            this.lblRecDte = new System.Windows.Forms.Label();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsInvoice = new Mbc5.DataSets.dsInvoice();
            this.invdetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymntBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bsTest = new System.Windows.Forms.BindingSource(this.components);
            this.invoiceTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.invoiceTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsInvoiceTableAdapters.TableAdapterManager();
            this.invdetailTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.invdetailTableAdapter();
            this.paymntTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.paymntTableAdapter();
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FullInvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCust)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCancellations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCancellations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invdetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymntBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTest)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.lblTitle);
            this.TopPanel.Size = new System.Drawing.Size(1127, 48);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.btnEmail);
            this.BottomPanel.Controls.Add(this.btnPrint);
            this.BottomPanel.Controls.Add(this.btnClear);
            this.BottomPanel.Controls.Add(this.btnSearch);
            this.BottomPanel.Location = new System.Drawing.Point(0, 422);
            this.BottomPanel.Size = new System.Drawing.Size(1127, 66);
            // 
            // FullInvoiceBindingSource
            // 
            this.FullInvoiceBindingSource.DataSource = typeof(BindingModels.FullInvoice);
            // 
            // custBindingSource
            // 
            this.custBindingSource.DataMember = "cust";
            this.custBindingSource.DataSource = this.dsCust;
            // 
            // dsCust
            // 
            this.dsCust.DataSetName = "dsCust";
            this.dsCust.EnforceConstraints = false;
            this.dsCust.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(404, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(334, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cancellation Statements";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(379, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(473, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear Search";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(569, 25);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print Invoices";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(667, 25);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(75, 23);
            this.btnEmail.TabIndex = 3;
            this.btnEmail.Text = "Email Invoices";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.button4_ClickAsync);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Controls.Add(this.chkPrint);
            this.panel1.Controls.Add(this.dgCancellations);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 323);
            this.panel1.TabIndex = 9;
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 35;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FullInvoiceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MultiMemInvoice.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(10, 390);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(51, 49);
            this.reportViewer1.TabIndex = 16;
            this.reportViewer1.Visible = false;
            this.reportViewer1.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportViewer1_ReportRefresh);
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            this.reportViewer1.ReportError += new Microsoft.Reporting.WinForms.ReportErrorEventHandler(this.reportViewer1_reportError);
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Checked = true;
            this.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint.Location = new System.Drawing.Point(20, 6);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(131, 17);
            this.chkPrint.TabIndex = 1;
            this.chkPrint.Text = "Check/UnCheck Print";
            this.chkPrint.UseVisualStyleBackColor = true;
            this.chkPrint.CheckedChanged += new System.EventHandler(this.chkPrint_CheckedChanged);
            // 
            // dgCancellations
            // 
            this.dgCancellations.AllowUserToAddRows = false;
            this.dgCancellations.AllowUserToDeleteRows = false;
            this.dgCancellations.AutoGenerateColumns = false;
            this.dgCancellations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCancellations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCancellations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCancellations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ToPrint,
            this.Collections,
            this.InvoiceNo,
            this.SchName,
            this.Schcode,
            this.Schemail,
            this.ContactEmail,
            this.colCancel,
            this.Balance});
            this.dgCancellations.DataSource = this.bsCancellations;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCancellations.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgCancellations.EnableHeadersVisualStyles = false;
            this.dgCancellations.Location = new System.Drawing.Point(29, 29);
            this.dgCancellations.Name = "dgCancellations";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCancellations.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgCancellations.RowHeadersVisible = false;
            this.dgCancellations.Size = new System.Drawing.Size(1096, 245);
            this.dgCancellations.TabIndex = 0;
            // 
            // ToPrint
            // 
            this.ToPrint.DataPropertyName = "ToPrint";
            this.ToPrint.HeaderText = "Print";
            this.ToPrint.Name = "ToPrint";
            // 
            // Collections
            // 
            this.Collections.DataPropertyName = "Holdpmt";
            this.Collections.HeaderText = "Collections";
            this.Collections.Name = "Collections";
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.DataPropertyName = "Invno";
            this.InvoiceNo.HeaderText = "Invoice #";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InvoiceNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SchName
            // 
            this.SchName.DataPropertyName = "Schname";
            this.SchName.HeaderText = "School Name";
            this.SchName.Name = "SchName";
            // 
            // Schcode
            // 
            this.Schcode.DataPropertyName = "Schname";
            this.Schcode.HeaderText = "School Code";
            this.Schcode.Name = "Schcode";
            // 
            // Schemail
            // 
            this.Schemail.DataPropertyName = "Schemail";
            this.Schemail.HeaderText = "School Email";
            this.Schemail.Name = "Schemail";
            // 
            // ContactEmail
            // 
            this.ContactEmail.DataPropertyName = "Contemail";
            this.ContactEmail.HeaderText = "Contact Email";
            this.ContactEmail.Name = "ContactEmail";
            // 
            // colCancel
            // 
            this.colCancel.DataPropertyName = "CancelDate";
            this.colCancel.HeaderText = "Cancel Date";
            this.colCancel.Name = "colCancel";
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Baldue";
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.custSearchTableAdapter = null;
            this.tableAdapterManager1.custTableAdapter = null;
            this.tableAdapterManager1.datecontTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = Mbc5.DataSets.dsCustTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dsSales
            // 
            this.dsSales.DataSetName = "dsSales";
            this.dsSales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // custTableAdapter
            // 
            this.custTableAdapter.ClearBeforeFill = true;
            // 
            // lblRecDte
            // 
            this.lblRecDte.AutoSize = true;
            this.lblRecDte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecDte.Location = new System.Drawing.Point(10, 58);
            this.lblRecDte.Name = "lblRecDte";
            this.lblRecDte.Size = new System.Drawing.Size(114, 13);
            this.lblRecDte.TabIndex = 12;
            this.lblRecDte.Text = "Cancel Date Between ";
            // 
            // dteStart
            // 
            this.dteStart.CustomFormat = "";
            this.dteStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteStart.Location = new System.Drawing.Point(124, 58);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(94, 20);
            this.dteStart.TabIndex = 13;
            // 
            // dteEnd
            // 
            this.dteEnd.CustomFormat = "";
            this.dteEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteEnd.Location = new System.Drawing.Point(263, 58);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(94, 20);
            this.dteEnd.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "and";
            // 
            // invoiceBindingSource
            // 
            this.invoiceBindingSource.DataMember = "invoice";
            this.invoiceBindingSource.DataSource = this.dsInvoice;
            // 
            // dsInvoice
            // 
            this.dsInvoice.DataSetName = "dsInvoice";
            this.dsInvoice.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // bsTest
            // 
            this.bsTest.DataMember = "invoice";
            this.bsTest.DataSource = this.dsInvoice;
            // 
            // invoiceTableAdapter
            // 
            this.invoiceTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.custTableAdapter = null;
            this.tableAdapterManager.invdetailTableAdapter = this.invdetailTableAdapter;
            this.tableAdapterManager.invoiceTableAdapter = this.invoiceTableAdapter;
            this.tableAdapterManager.paymntTableAdapter = this.paymntTableAdapter;
            this.tableAdapterManager.quotesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsInvoiceTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // invdetailTableAdapter
            // 
            this.invdetailTableAdapter.ClearBeforeFill = true;
            // 
            // paymntTableAdapter
            // 
            this.paymntTableAdapter.ClearBeforeFill = true;
            // 
            // frmCancellationStatements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1127, 488);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.lblRecDte);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCancellationStatements";
            this.Text = "Print MBC Invoice\'s";
            this.Activated += new System.EventHandler(this.frmInvoicInq_Activated);
            this.Load += new System.EventHandler(this.frmCancellationStatements_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblRecDte, 0);
            this.Controls.SetChildIndex(this.dteStart, 0);
            this.Controls.SetChildIndex(this.TopPanel, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dteEnd, 0);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FullInvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCust)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCancellations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCancellations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invdetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymntBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgCancellations;
        private System.Windows.Forms.BindingSource bsCancellations;
        private System.Windows.Forms.CheckBox chkPrint;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSets.dsInvoice dsInvoice;
        private System.Windows.Forms.BindingSource invoiceBindingSource;
        private DataSets.dsInvoiceTableAdapters.invoiceTableAdapter invoiceTableAdapter;
        private DataSets.dsInvoiceTableAdapters.TableAdapterManager tableAdapterManager;
        private DataSets.dsInvoiceTableAdapters.invdetailTableAdapter invdetailTableAdapter;
        private System.Windows.Forms.BindingSource invdetailBindingSource;
        private DataSets.dsInvoiceTableAdapters.paymntTableAdapter paymntTableAdapter;
        private System.Windows.Forms.BindingSource paymntBindingSource;
        private DataSets.dsCust dsCust;
        private DataSets.dsCustTableAdapters.TableAdapterManager tableAdapterManager1;
        private DataSets.dsSales dsSales;
        private System.Windows.Forms.BindingSource custBindingSource;
        private DataSets.dsCustTableAdapters.custTableAdapter custTableAdapter;
		private System.Windows.Forms.BindingSource bsTest;
		private System.Windows.Forms.BindingSource FullInvoiceBindingSource;
        private System.Windows.Forms.Label lblRecDte;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ToPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Collections;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schemail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label label1;
    }
}
