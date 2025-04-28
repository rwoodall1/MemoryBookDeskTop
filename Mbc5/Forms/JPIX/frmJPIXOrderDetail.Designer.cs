namespace Mbc5.Forms.JPIX
{
    partial class frmJPIXOrderDetail
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
            System.Windows.Forms.Label shipToPostalCodeLabel;
            System.Windows.Forms.Label shipToStateOrProvinceLabel;
            System.Windows.Forms.Label shipToCityLabel;
            System.Windows.Forms.Label shipToAddress2Label;
            System.Windows.Forms.Label shipToAddress1Label;
            System.Windows.Forms.Label shipToContactLabel;
            System.Windows.Forms.Label shipToCustomerNameLabel;
            System.Windows.Forms.Label requestIdLabel;
            System.Windows.Forms.Label dateShippedLabel;
            System.Windows.Forms.Label dateReceivedLabel;
            System.Windows.Forms.Label invnoLabel;
            System.Windows.Forms.Label referenceLabel;
            System.Windows.Forms.Label oracleCodeLabel;
            System.Windows.Forms.Label notesLabel;
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dsJPIXOrders = new Mbc5.dsJPIXOrders();
            this.jPIXOrdersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jPIXOrdersTableAdapter = new Mbc5.dsJPIXOrdersTableAdapters.JPIXOrdersTableAdapter();
            this.tableAdapterManager = new Mbc5.dsJPIXOrdersTableAdapters.TableAdapterManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shipToPostalCodeTextBox = new System.Windows.Forms.TextBox();
            this.shipToStateOrProvinceComboBox = new System.Windows.Forms.ComboBox();
            this.shipToCityTextBox = new System.Windows.Forms.TextBox();
            this.shipToAddress2TextBox = new System.Windows.Forms.TextBox();
            this.shipToAddress1TextBox = new System.Windows.Forms.TextBox();
            this.shipToContactTextBox = new System.Windows.Forms.TextBox();
            this.shipToCustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.isCanceledCheckBox = new System.Windows.Forms.CheckBox();
            this.requestIdLabel1 = new System.Windows.Forms.Label();
            this.dateShippedLabel1 = new System.Windows.Forms.Label();
            this.dateReceivedLabel1 = new System.Windows.Forms.Label();
            this.invnoLabel1 = new System.Windows.Forms.Label();
            this.referenceLabel1 = new System.Windows.Forms.Label();
            this.oracleCodeLabel1 = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            shipToPostalCodeLabel = new System.Windows.Forms.Label();
            shipToStateOrProvinceLabel = new System.Windows.Forms.Label();
            shipToCityLabel = new System.Windows.Forms.Label();
            shipToAddress2Label = new System.Windows.Forms.Label();
            shipToAddress1Label = new System.Windows.Forms.Label();
            shipToContactLabel = new System.Windows.Forms.Label();
            shipToCustomerNameLabel = new System.Windows.Forms.Label();
            requestIdLabel = new System.Windows.Forms.Label();
            dateShippedLabel = new System.Windows.Forms.Label();
            dateReceivedLabel = new System.Windows.Forms.Label();
            invnoLabel = new System.Windows.Forms.Label();
            referenceLabel = new System.Windows.Forms.Label();
            oracleCodeLabel = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsJPIXOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPIXOrdersBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Location = new System.Drawing.Point(4, 1);
            this.basePanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.basePanel.Size = new System.Drawing.Size(110, 23);
            // 
            // workingLabel
            // 
            this.workingLabel.Location = new System.Drawing.Point(4, 4);
            this.workingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // shipToPostalCodeLabel
            // 
            shipToPostalCodeLabel.AutoSize = true;
            shipToPostalCodeLabel.Location = new System.Drawing.Point(38, 169);
            shipToPostalCodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            shipToPostalCodeLabel.Name = "shipToPostalCodeLabel";
            shipToPostalCodeLabel.Size = new System.Drawing.Size(83, 13);
            shipToPostalCodeLabel.TabIndex = 28;
            shipToPostalCodeLabel.Text = " Postal Code:";
            // 
            // shipToStateOrProvinceLabel
            // 
            shipToStateOrProvinceLabel.AutoSize = true;
            shipToStateOrProvinceLabel.Location = new System.Drawing.Point(76, 142);
            shipToStateOrProvinceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            shipToStateOrProvinceLabel.Name = "shipToStateOrProvinceLabel";
            shipToStateOrProvinceLabel.Size = new System.Drawing.Size(45, 13);
            shipToStateOrProvinceLabel.TabIndex = 26;
            shipToStateOrProvinceLabel.Text = " State:";
            // 
            // shipToCityLabel
            // 
            shipToCityLabel.AutoSize = true;
            shipToCityLabel.Location = new System.Drawing.Point(89, 116);
            shipToCityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            shipToCityLabel.Name = "shipToCityLabel";
            shipToCityLabel.Size = new System.Drawing.Size(32, 13);
            shipToCityLabel.TabIndex = 24;
            shipToCityLabel.Text = "City:";
            // 
            // shipToAddress2Label
            // 
            shipToAddress2Label.AutoSize = true;
            shipToAddress2Label.Location = new System.Drawing.Point(58, 90);
            shipToAddress2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            shipToAddress2Label.Name = "shipToAddress2Label";
            shipToAddress2Label.Size = new System.Drawing.Size(63, 13);
            shipToAddress2Label.TabIndex = 22;
            shipToAddress2Label.Text = "Address2:";
            // 
            // shipToAddress1Label
            // 
            shipToAddress1Label.AutoSize = true;
            shipToAddress1Label.Location = new System.Drawing.Point(61, 64);
            shipToAddress1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            shipToAddress1Label.Name = "shipToAddress1Label";
            shipToAddress1Label.Size = new System.Drawing.Size(60, 13);
            shipToAddress1Label.TabIndex = 20;
            shipToAddress1Label.Text = " Address:";
            // 
            // shipToContactLabel
            // 
            shipToContactLabel.AutoSize = true;
            shipToContactLabel.Location = new System.Drawing.Point(26, 38);
            shipToContactLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            shipToContactLabel.Name = "shipToContactLabel";
            shipToContactLabel.Size = new System.Drawing.Size(95, 13);
            shipToContactLabel.TabIndex = 18;
            shipToContactLabel.Text = " Contact Name:";
            // 
            // shipToCustomerNameLabel
            // 
            shipToCustomerNameLabel.AutoSize = true;
            shipToCustomerNameLabel.Location = new System.Drawing.Point(22, 12);
            shipToCustomerNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            shipToCustomerNameLabel.Name = "shipToCustomerNameLabel";
            shipToCustomerNameLabel.Size = new System.Drawing.Size(99, 13);
            shipToCustomerNameLabel.TabIndex = 16;
            shipToCustomerNameLabel.Text = "Customer Name:";
            // 
            // requestIdLabel
            // 
            requestIdLabel.AutoSize = true;
            requestIdLabel.Location = new System.Drawing.Point(28, 140);
            requestIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            requestIdLabel.Name = "requestIdLabel";
            requestIdLabel.Size = new System.Drawing.Size(73, 13);
            requestIdLabel.TabIndex = 38;
            requestIdLabel.Text = "Request Id:";
            // 
            // dateShippedLabel
            // 
            dateShippedLabel.AutoSize = true;
            dateShippedLabel.Location = new System.Drawing.Point(13, 114);
            dateShippedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dateShippedLabel.Name = "dateShippedLabel";
            dateShippedLabel.Size = new System.Drawing.Size(88, 13);
            dateShippedLabel.TabIndex = 36;
            dateShippedLabel.Text = "Date Shipped:";
            // 
            // dateReceivedLabel
            // 
            dateReceivedLabel.AutoSize = true;
            dateReceivedLabel.Location = new System.Drawing.Point(5, 88);
            dateReceivedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dateReceivedLabel.Name = "dateReceivedLabel";
            dateReceivedLabel.Size = new System.Drawing.Size(96, 13);
            dateReceivedLabel.TabIndex = 34;
            dateReceivedLabel.Text = "Date Received:";
            // 
            // invnoLabel
            // 
            invnoLabel.AutoSize = true;
            invnoLabel.Location = new System.Drawing.Point(40, 62);
            invnoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(61, 13);
            invnoLabel.TabIndex = 32;
            invnoLabel.Text = "Invoice#:";
            // 
            // referenceLabel
            // 
            referenceLabel.AutoSize = true;
            referenceLabel.Location = new System.Drawing.Point(31, 36);
            referenceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            referenceLabel.Name = "referenceLabel";
            referenceLabel.Size = new System.Drawing.Size(70, 13);
            referenceLabel.TabIndex = 30;
            referenceLabel.Text = "Reference:";
            // 
            // oracleCodeLabel
            // 
            oracleCodeLabel.AutoSize = true;
            oracleCodeLabel.Location = new System.Drawing.Point(20, 10);
            oracleCodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            oracleCodeLabel.Name = "oracleCodeLabel";
            oracleCodeLabel.Size = new System.Drawing.Size(81, 13);
            oracleCodeLabel.TabIndex = 28;
            oracleCodeLabel.Text = "Oracle Code:";
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new System.Drawing.Point(20, 273);
            notesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(44, 13);
            notesLabel.TabIndex = 29;
            notesLabel.Text = "Notes:";
            // 
            // dsJPIXOrders
            // 
            this.dsJPIXOrders.DataSetName = "dsJPIXOrders";
            this.dsJPIXOrders.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jPIXOrdersBindingSource
            // 
            this.jPIXOrdersBindingSource.DataMember = "JPIXOrders";
            this.jPIXOrdersBindingSource.DataSource = this.dsJPIXOrders;
            // 
            // jPIXOrdersTableAdapter
            // 
            this.jPIXOrdersTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.JPIXOrdersTableAdapter = this.jPIXOrdersTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.dsJPIXOrdersTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(shipToPostalCodeLabel);
            this.panel1.Controls.Add(this.shipToPostalCodeTextBox);
            this.panel1.Controls.Add(shipToStateOrProvinceLabel);
            this.panel1.Controls.Add(this.shipToStateOrProvinceComboBox);
            this.panel1.Controls.Add(shipToCityLabel);
            this.panel1.Controls.Add(this.shipToCityTextBox);
            this.panel1.Controls.Add(shipToAddress2Label);
            this.panel1.Controls.Add(this.shipToAddress2TextBox);
            this.panel1.Controls.Add(shipToAddress1Label);
            this.panel1.Controls.Add(this.shipToAddress1TextBox);
            this.panel1.Controls.Add(shipToContactLabel);
            this.panel1.Controls.Add(this.shipToContactTextBox);
            this.panel1.Controls.Add(shipToCustomerNameLabel);
            this.panel1.Controls.Add(this.shipToCustomerNameTextBox);
            this.panel1.Location = new System.Drawing.Point(14, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 205);
            this.panel1.TabIndex = 28;
            // 
            // shipToPostalCodeTextBox
            // 
            this.shipToPostalCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "ShipToPostalCode", true));
            this.shipToPostalCodeTextBox.Location = new System.Drawing.Point(124, 166);
            this.shipToPostalCodeTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.shipToPostalCodeTextBox.Name = "shipToPostalCodeTextBox";
            this.shipToPostalCodeTextBox.Size = new System.Drawing.Size(401, 20);
            this.shipToPostalCodeTextBox.TabIndex = 29;
            // 
            // shipToStateOrProvinceComboBox
            // 
            this.shipToStateOrProvinceComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "ShipToStateOrProvince", true));
            this.shipToStateOrProvinceComboBox.FormattingEnabled = true;
            this.shipToStateOrProvinceComboBox.Location = new System.Drawing.Point(124, 138);
            this.shipToStateOrProvinceComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.shipToStateOrProvinceComboBox.Name = "shipToStateOrProvinceComboBox";
            this.shipToStateOrProvinceComboBox.Size = new System.Drawing.Size(401, 21);
            this.shipToStateOrProvinceComboBox.TabIndex = 27;
            // 
            // shipToCityTextBox
            // 
            this.shipToCityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "ShipToCity", true));
            this.shipToCityTextBox.Location = new System.Drawing.Point(124, 112);
            this.shipToCityTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.shipToCityTextBox.Name = "shipToCityTextBox";
            this.shipToCityTextBox.Size = new System.Drawing.Size(401, 20);
            this.shipToCityTextBox.TabIndex = 25;
            // 
            // shipToAddress2TextBox
            // 
            this.shipToAddress2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "ShipToAddress2", true));
            this.shipToAddress2TextBox.Location = new System.Drawing.Point(124, 86);
            this.shipToAddress2TextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.shipToAddress2TextBox.Name = "shipToAddress2TextBox";
            this.shipToAddress2TextBox.Size = new System.Drawing.Size(401, 20);
            this.shipToAddress2TextBox.TabIndex = 23;
            // 
            // shipToAddress1TextBox
            // 
            this.shipToAddress1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "ShipToAddress1", true));
            this.shipToAddress1TextBox.Location = new System.Drawing.Point(124, 60);
            this.shipToAddress1TextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.shipToAddress1TextBox.Name = "shipToAddress1TextBox";
            this.shipToAddress1TextBox.Size = new System.Drawing.Size(401, 20);
            this.shipToAddress1TextBox.TabIndex = 21;
            // 
            // shipToContactTextBox
            // 
            this.shipToContactTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "ShipToContact", true));
            this.shipToContactTextBox.Location = new System.Drawing.Point(124, 34);
            this.shipToContactTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.shipToContactTextBox.Name = "shipToContactTextBox";
            this.shipToContactTextBox.Size = new System.Drawing.Size(401, 20);
            this.shipToContactTextBox.TabIndex = 19;
            // 
            // shipToCustomerNameTextBox
            // 
            this.shipToCustomerNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "ShipToCustomerName", true));
            this.shipToCustomerNameTextBox.Location = new System.Drawing.Point(124, 8);
            this.shipToCustomerNameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.shipToCustomerNameTextBox.Name = "shipToCustomerNameTextBox";
            this.shipToCustomerNameTextBox.Size = new System.Drawing.Size(401, 20);
            this.shipToCustomerNameTextBox.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.isCanceledCheckBox);
            this.panel2.Controls.Add(requestIdLabel);
            this.panel2.Controls.Add(this.requestIdLabel1);
            this.panel2.Controls.Add(dateShippedLabel);
            this.panel2.Controls.Add(this.dateShippedLabel1);
            this.panel2.Controls.Add(dateReceivedLabel);
            this.panel2.Controls.Add(this.dateReceivedLabel1);
            this.panel2.Controls.Add(invnoLabel);
            this.panel2.Controls.Add(this.invnoLabel1);
            this.panel2.Controls.Add(referenceLabel);
            this.panel2.Controls.Add(this.referenceLabel1);
            this.panel2.Controls.Add(oracleCodeLabel);
            this.panel2.Controls.Add(this.oracleCodeLabel1);
            this.panel2.Location = new System.Drawing.Point(743, 52);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 205);
            this.panel2.TabIndex = 29;
            // 
            // isCanceledCheckBox
            // 
            this.isCanceledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.jPIXOrdersBindingSource, "IsCanceled", true));
            this.isCanceledCheckBox.Location = new System.Drawing.Point(26, 164);
            this.isCanceledCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.isCanceledCheckBox.Name = "isCanceledCheckBox";
            this.isCanceledCheckBox.Size = new System.Drawing.Size(121, 24);
            this.isCanceledCheckBox.TabIndex = 40;
            this.isCanceledCheckBox.Text = "Cancelled";
            this.isCanceledCheckBox.UseVisualStyleBackColor = true;
            // 
            // requestIdLabel1
            // 
            this.requestIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "RequestId", true));
            this.requestIdLabel1.Location = new System.Drawing.Point(107, 140);
            this.requestIdLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.requestIdLabel1.Name = "requestIdLabel1";
            this.requestIdLabel1.Size = new System.Drawing.Size(117, 23);
            this.requestIdLabel1.TabIndex = 39;
            this.requestIdLabel1.Text = "label1";
            // 
            // dateShippedLabel1
            // 
            this.dateShippedLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "DateShipped", true));
            this.dateShippedLabel1.Location = new System.Drawing.Point(107, 114);
            this.dateShippedLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateShippedLabel1.Name = "dateShippedLabel1";
            this.dateShippedLabel1.Size = new System.Drawing.Size(117, 23);
            this.dateShippedLabel1.TabIndex = 37;
            this.dateShippedLabel1.Text = "label1";
            // 
            // dateReceivedLabel1
            // 
            this.dateReceivedLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "DateReceived", true));
            this.dateReceivedLabel1.Location = new System.Drawing.Point(107, 88);
            this.dateReceivedLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateReceivedLabel1.Name = "dateReceivedLabel1";
            this.dateReceivedLabel1.Size = new System.Drawing.Size(117, 23);
            this.dateReceivedLabel1.TabIndex = 35;
            this.dateReceivedLabel1.Text = "label1";
            // 
            // invnoLabel1
            // 
            this.invnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "Invno", true));
            this.invnoLabel1.Location = new System.Drawing.Point(107, 62);
            this.invnoLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.invnoLabel1.Name = "invnoLabel1";
            this.invnoLabel1.Size = new System.Drawing.Size(117, 23);
            this.invnoLabel1.TabIndex = 33;
            this.invnoLabel1.Text = "label1";
            // 
            // referenceLabel1
            // 
            this.referenceLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "Reference", true));
            this.referenceLabel1.Location = new System.Drawing.Point(107, 36);
            this.referenceLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.referenceLabel1.Name = "referenceLabel1";
            this.referenceLabel1.Size = new System.Drawing.Size(117, 23);
            this.referenceLabel1.TabIndex = 31;
            this.referenceLabel1.Text = "label1";
            // 
            // oracleCodeLabel1
            // 
            this.oracleCodeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "OracleCode", true));
            this.oracleCodeLabel1.Location = new System.Drawing.Point(107, 10);
            this.oracleCodeLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oracleCodeLabel1.Name = "oracleCodeLabel1";
            this.oracleCodeLabel1.Size = new System.Drawing.Size(117, 23);
            this.oracleCodeLabel1.TabIndex = 29;
            this.oracleCodeLabel1.Text = "label1";
            // 
            // notesTextBox
            // 
            this.notesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jPIXOrdersBindingSource, "Notes", true));
            this.notesTextBox.Location = new System.Drawing.Point(71, 270);
            this.notesTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(534, 64);
            this.notesTextBox.TabIndex = 30;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Print Production Ticket";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.DataBindings.Add(new System.Windows.Forms.Binding("Url", this.jPIXOrdersBindingSource, "Document", true));
            this.webBrowser1.Location = new System.Drawing.Point(727, 270);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(240, 319);
            this.webBrowser1.TabIndex = 33;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 35;
            reportDataSource1.Name = "dsMxPackingSlip";
            reportDataSource1.Value = null;
            reportDataSource2.Name = "dsMixBookRemakeTkt";
            reportDataSource2.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookRemakeTkt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(37, 440);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(117, 169);
            this.reportViewer1.TabIndex = 10021;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // frmJPIXOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1127, 612);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button1);
            this.Controls.Add(notesLabel);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmJPIXOrderDetail";
            this.Text = "JPIX Order";
            this.Load += new System.EventHandler(this.frmJPIXOrderDetail_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.notesTextBox, 0);
            this.Controls.SetChildIndex(notesLabel, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.webBrowser1, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsJPIXOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPIXOrdersBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dsJPIXOrders dsJPIXOrders;
        private System.Windows.Forms.BindingSource jPIXOrdersBindingSource;
        private dsJPIXOrdersTableAdapters.JPIXOrdersTableAdapter jPIXOrdersTableAdapter;
        private dsJPIXOrdersTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox shipToPostalCodeTextBox;
        private System.Windows.Forms.ComboBox shipToStateOrProvinceComboBox;
        private System.Windows.Forms.TextBox shipToCityTextBox;
        private System.Windows.Forms.TextBox shipToAddress2TextBox;
        private System.Windows.Forms.TextBox shipToAddress1TextBox;
        private System.Windows.Forms.TextBox shipToContactTextBox;
        private System.Windows.Forms.TextBox shipToCustomerNameTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label requestIdLabel1;
        private System.Windows.Forms.Label dateShippedLabel1;
        private System.Windows.Forms.Label dateReceivedLabel1;
        private System.Windows.Forms.Label invnoLabel1;
        private System.Windows.Forms.Label referenceLabel1;
        private System.Windows.Forms.Label oracleCodeLabel1;
        private System.Windows.Forms.CheckBox isCanceledCheckBox;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
