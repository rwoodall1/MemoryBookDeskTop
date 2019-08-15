namespace Mbc5.Forms.MemoryBook
{
    partial class frmInvoicInq
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FullInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCust = new Mbc5.DataSets.dsCust();
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsInvoice = new Mbc5.DataSets.dsInvoice();
            this.invdetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymntBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlError = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgAddressErrors = new System.Windows.Forms.DataGridView();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.dgInvoices = new System.Windows.Forms.DataGridView();
            this.bsInvoices = new System.Windows.Forms.BindingSource(this.components);
            this.bsTest = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager1 = new Mbc5.DataSets.dsCustTableAdapters.TableAdapterManager();
            this.dsSales = new Mbc5.DataSets.dsSales();
            this.custTableAdapter = new Mbc5.DataSets.dsCustTableAdapters.custTableAdapter();
            this.invoiceTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.invoiceTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsInvoiceTableAdapters.TableAdapterManager();
            this.invdetailTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.invdetailTableAdapter();
            this.paymntTableAdapter = new Mbc5.DataSets.dsInvoiceTableAdapters.paymntTableAdapter();
            this.rdStatement = new System.Windows.Forms.RadioButton();
            this.rdReceived = new System.Windows.Forms.RadioButton();
            this.lblRecDte = new System.Windows.Forms.Label();
            this.dteRecvDte = new System.Windows.Forms.DateTimePicker();
            this.ToPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Collections = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FullInvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invdetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymntBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddressErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.lblTitle);
            this.TopPanel.Size = new System.Drawing.Size(1133, 48);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.button4);
            this.BottomPanel.Controls.Add(this.button3);
            this.BottomPanel.Controls.Add(this.button2);
            this.BottomPanel.Controls.Add(this.btnSearch);
            this.BottomPanel.Location = new System.Drawing.Point(0, 422);
            this.BottomPanel.Size = new System.Drawing.Size(1133, 66);
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
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(498, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(125, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Invoices";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(260, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "(Filter=Ship Date Not Blank and Balance >0.00)";
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(473, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Clear Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(569, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Print Invoices";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(667, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Email Invoices";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_ClickAsync);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pnlError);
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Controls.Add(this.chkPrint);
            this.panel1.Controls.Add(this.dgInvoices);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 304);
            this.panel1.TabIndex = 9;
            // 
            // pnlError
            // 
            this.pnlError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlError.Controls.Add(this.label2);
            this.pnlError.Controls.Add(this.dgAddressErrors);
            this.pnlError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlError.Location = new System.Drawing.Point(261, 58);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(663, 189);
            this.pnlError.TabIndex = 17;
            this.pnlError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(649, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "The following sales records have customer information errors in them and need inv" +
    "oice over rides done on them before you can proceed.";
            // 
            // dgAddressErrors
            // 
            this.dgAddressErrors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAddressErrors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgAddressErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAddressErrors.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgAddressErrors.EnableHeadersVisualStyles = false;
            this.dgAddressErrors.Location = new System.Drawing.Point(60, 21);
            this.dgAddressErrors.Name = "dgAddressErrors";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAddressErrors.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgAddressErrors.Size = new System.Drawing.Size(486, 150);
            this.dgAddressErrors.TabIndex = 9;
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 35;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.FullInvoiceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
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
            // dgInvoices
            // 
            this.dgInvoices.AllowUserToAddRows = false;
            this.dgInvoices.AllowUserToDeleteRows = false;
            this.dgInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgInvoices.AutoGenerateColumns = false;
            this.dgInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ToPrint,
            this.Collections,
            this.InvoiceNo,
            this.Shpdate,
            this.SchName,
            this.Schcode,
            this.Schemail,
            this.ContactEmail,
            this.Balance});
            this.dgInvoices.DataSource = this.bsInvoices;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgInvoices.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgInvoices.EnableHeadersVisualStyles = false;
            this.dgInvoices.Location = new System.Drawing.Point(29, 29);
            this.dgInvoices.Name = "dgInvoices";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInvoices.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgInvoices.RowHeadersVisible = false;
            this.dgInvoices.Size = new System.Drawing.Size(1096, 245);
            this.dgInvoices.TabIndex = 0;
            // 
            // bsTest
            // 
            this.bsTest.DataMember = "invoice";
            this.bsTest.DataSource = this.dsInvoice;
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
            // rdStatement
            // 
            this.rdStatement.AutoSize = true;
            this.rdStatement.Checked = true;
            this.rdStatement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStatement.Location = new System.Drawing.Point(23, 52);
            this.rdStatement.Name = "rdStatement";
            this.rdStatement.Size = new System.Drawing.Size(73, 17);
            this.rdStatement.TabIndex = 10;
            this.rdStatement.TabStop = true;
            this.rdStatement.Text = "Statement";
            this.rdStatement.UseVisualStyleBackColor = true;
            // 
            // rdReceived
            // 
            this.rdReceived.AutoSize = true;
            this.rdReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdReceived.Location = new System.Drawing.Point(23, 70);
            this.rdReceived.Name = "rdReceived";
            this.rdReceived.Size = new System.Drawing.Size(99, 17);
            this.rdReceived.TabIndex = 11;
            this.rdReceived.TabStop = true;
            this.rdReceived.Text = "Book Received";
            this.rdReceived.UseVisualStyleBackColor = true;
            this.rdReceived.CheckedChanged += new System.EventHandler(this.rdReceived_CheckedChanged);
            // 
            // lblRecDte
            // 
            this.lblRecDte.AutoSize = true;
            this.lblRecDte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecDte.Location = new System.Drawing.Point(28, 90);
            this.lblRecDte.Name = "lblRecDte";
            this.lblRecDte.Size = new System.Drawing.Size(79, 13);
            this.lblRecDte.TabIndex = 12;
            this.lblRecDte.Text = "Received Date";
            this.lblRecDte.Visible = false;
            // 
            // dteRecvDte
            // 
            this.dteRecvDte.CustomFormat = "";
            this.dteRecvDte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteRecvDte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteRecvDte.Location = new System.Drawing.Point(112, 90);
            this.dteRecvDte.Name = "dteRecvDte";
            this.dteRecvDte.Size = new System.Drawing.Size(94, 20);
            this.dteRecvDte.TabIndex = 13;
            this.dteRecvDte.Visible = false;
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
            // Shpdate
            // 
            this.Shpdate.DataPropertyName = "ShpDate";
            this.Shpdate.HeaderText = "Ship Date";
            this.Shpdate.Name = "Shpdate";
            // 
            // SchName
            // 
            this.SchName.DataPropertyName = "Schname";
            this.SchName.HeaderText = "School Name";
            this.SchName.Name = "SchName";
            // 
            // Schcode
            // 
            this.Schcode.DataPropertyName = "Schcode";
            this.Schcode.HeaderText = "School Code";
            this.Schcode.Name = "Schcode";
            // 
            // Schemail
            // 
            this.Schemail.DataPropertyName = "InvoiceEmail1";
            this.Schemail.HeaderText = "Email 1";
            this.Schemail.Name = "Schemail";
            // 
            // ContactEmail
            // 
            this.ContactEmail.DataPropertyName = "InvoiceEmail2";
            this.ContactEmail.HeaderText = "Email 2";
            this.ContactEmail.Name = "ContactEmail";
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Baldue";
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            // 
            // frmInvoicInq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1133, 488);
            this.Controls.Add(this.dteRecvDte);
            this.Controls.Add(this.lblRecDte);
            this.Controls.Add(this.rdReceived);
            this.Controls.Add(this.rdStatement);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1149, 527);
            this.Name = "frmInvoicInq";
            this.Text = "Print MBC Invoice\'s";
            this.Activated += new System.EventHandler(this.frmInvoicInq_Activated);
            this.Load += new System.EventHandler(this.frmInvoicInq_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.rdStatement, 0);
            this.Controls.SetChildIndex(this.rdReceived, 0);
            this.Controls.SetChildIndex(this.lblRecDte, 0);
            this.Controls.SetChildIndex(this.dteRecvDte, 0);
            this.Controls.SetChildIndex(this.TopPanel, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FullInvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invdetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymntBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlError.ResumeLayout(false);
            this.pnlError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddressErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgInvoices;
        private System.Windows.Forms.BindingSource bsInvoices;
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
        private System.Windows.Forms.RadioButton rdStatement;
        private System.Windows.Forms.RadioButton rdReceived;
        private System.Windows.Forms.Label lblRecDte;
        private System.Windows.Forms.DateTimePicker dteRecvDte;
        private System.Windows.Forms.Panel pnlError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgAddressErrors;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ToPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Collections;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schemail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
    }
}
