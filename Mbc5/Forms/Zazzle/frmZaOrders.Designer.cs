namespace Mbc5.Forms.Zazzle
{
    partial class frmZaOrders
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
            System.Windows.Forms.Label notesLabel;
            System.Windows.Forms.Label weightLabel;
            System.Windows.Forms.Label trackingNumberLabel;
            System.Windows.Forms.Label invnoLabel;
            System.Windows.Forms.Label shipMethodLabel;
            System.Windows.Forms.Label dateShippedLabel;
            System.Windows.Forms.Label shipDateLabel;
            System.Windows.Forms.Label receiveDateLabel;
            System.Windows.Forms.Label orderIdLabel;
            System.Windows.Forms.Label phoneNumberLabel;
            System.Windows.Forms.Label shipZipLabel;
            System.Windows.Forms.Label shipStateLabel;
            System.Windows.Forms.Label shipCityLabel;
            System.Windows.Forms.Label shipAddr2Label;
            System.Windows.Forms.Label shipAddrLabel;
            System.Windows.Forms.Label shipNameLabel;
            System.Windows.Forms.Label requestedShipMethodLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZaOrders));
            this.statesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUp = new Mbc5.DataSets.LookUp();
            this.zazzleOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.prodticket = new System.Windows.Forms.DataGridViewLinkColumn();
            this.invnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attributesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numPerPackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reprintInstructionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zazzleOrderDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsZazzle = new Mbc5.DataSets.dsZazzle();
            this.statesTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.statesTableAdapter();
            this.btnMixbookPkgList = new System.Windows.Forms.Button();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.invnoLabel3 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.zazzleOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnHold = new System.Windows.Forms.Button();
            this.requestedShipMethodLabel1 = new System.Windows.Forms.Label();
            this.shipAddr2TextBox = new System.Windows.Forms.TextBox();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.lblDateShipped = new System.Windows.Forms.Label();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.trackingNumberTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.shipZipTextBox = new System.Windows.Forms.TextBox();
            this.shipCityTextBox = new System.Windows.Forms.TextBox();
            this.shipAddrTextBox = new System.Windows.Forms.TextBox();
            this.shipNameTextBox = new System.Windows.Forms.TextBox();
            this.shipMethodComboBox = new System.Windows.Forms.ComboBox();
            this.schoutDateBox = new CustomControls.DateBox();
            this.receiveDateLabel1 = new System.Windows.Forms.Label();
            this.orderIdLabel1 = new System.Windows.Forms.Label();
            this.shipStateComboBox = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDownloadFiles = new System.Windows.Forms.Button();
            this.btnRemake = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmdJobTicket = new System.Windows.Forms.Button();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.zazzleOrderTableAdapter = new Mbc5.DataSets.dsZazzleTableAdapters.ZazzleOrderTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsZazzleTableAdapters.TableAdapterManager();
            this.zazzleOrderBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mixBookOrderBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.itemIdToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.purgeStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.zazzleOrderDetailTableAdapter = new Mbc5.DataSets.dsZazzleTableAdapters.ZazzleOrderDetailTableAdapter();
            notesLabel = new System.Windows.Forms.Label();
            weightLabel = new System.Windows.Forms.Label();
            trackingNumberLabel = new System.Windows.Forms.Label();
            invnoLabel = new System.Windows.Forms.Label();
            shipMethodLabel = new System.Windows.Forms.Label();
            dateShippedLabel = new System.Windows.Forms.Label();
            shipDateLabel = new System.Windows.Forms.Label();
            receiveDateLabel = new System.Windows.Forms.Label();
            orderIdLabel = new System.Windows.Forms.Label();
            phoneNumberLabel = new System.Windows.Forms.Label();
            shipZipLabel = new System.Windows.Forms.Label();
            shipStateLabel = new System.Windows.Forms.Label();
            shipCityLabel = new System.Windows.Forms.Label();
            shipAddr2Label = new System.Windows.Forms.Label();
            shipAddrLabel = new System.Windows.Forms.Label();
            shipNameLabel = new System.Windows.Forms.Label();
            requestedShipMethodLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zazzleOrderDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zazzleOrderDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsZazzle)).BeginInit();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zazzleOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zazzleOrderBindingNavigator)).BeginInit();
            this.zazzleOrderBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Location = new System.Drawing.Point(1121, 12);
            this.basePanel.Size = new System.Drawing.Size(12, 14);
            // 
            // notesLabel
            // 
            notesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            notesLabel.AutoSize = true;
            notesLabel.Location = new System.Drawing.Point(525, 192);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(38, 13);
            notesLabel.TabIndex = 332;
            notesLabel.Text = "Notes:";
            // 
            // weightLabel
            // 
            weightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            weightLabel.AutoSize = true;
            weightLabel.Location = new System.Drawing.Point(522, 165);
            weightLabel.Name = "weightLabel";
            weightLabel.Size = new System.Drawing.Size(41, 13);
            weightLabel.TabIndex = 329;
            weightLabel.Text = "Weight";
            // 
            // trackingNumberLabel
            // 
            trackingNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            trackingNumberLabel.AutoSize = true;
            trackingNumberLabel.Location = new System.Drawing.Point(474, 115);
            trackingNumberLabel.Name = "trackingNumberLabel";
            trackingNumberLabel.Size = new System.Drawing.Size(89, 13);
            trackingNumberLabel.TabIndex = 327;
            trackingNumberLabel.Text = "Tracking Number";
            // 
            // invnoLabel
            // 
            invnoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            invnoLabel.AutoSize = true;
            invnoLabel.Location = new System.Drawing.Point(881, 70);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(62, 13);
            invnoLabel.TabIndex = 323;
            invnoLabel.Text = "Invoice No.";
            // 
            // shipMethodLabel
            // 
            shipMethodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            shipMethodLabel.AutoSize = true;
            shipMethodLabel.Location = new System.Drawing.Point(496, 62);
            shipMethodLabel.Name = "shipMethodLabel";
            shipMethodLabel.Size = new System.Drawing.Size(67, 13);
            shipMethodLabel.TabIndex = 315;
            shipMethodLabel.Text = "Ship Method";
            // 
            // dateShippedLabel
            // 
            dateShippedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateShippedLabel.AutoSize = true;
            dateShippedLabel.Location = new System.Drawing.Point(491, 44);
            dateShippedLabel.Name = "dateShippedLabel";
            dateShippedLabel.Size = new System.Drawing.Size(72, 13);
            dateShippedLabel.TabIndex = 314;
            dateShippedLabel.Text = "Date Shipped";
            // 
            // shipDateLabel
            // 
            shipDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            shipDateLabel.AutoSize = true;
            shipDateLabel.Location = new System.Drawing.Point(454, 18);
            shipDateLabel.Name = "shipDateLabel";
            shipDateLabel.Size = new System.Drawing.Size(109, 13);
            shipDateLabel.TabIndex = 313;
            shipDateLabel.Text = "Requested Ship Date";
            // 
            // receiveDateLabel
            // 
            receiveDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            receiveDateLabel.AutoSize = true;
            receiveDateLabel.Location = new System.Drawing.Point(870, 44);
            receiveDateLabel.Name = "receiveDateLabel";
            receiveDateLabel.Size = new System.Drawing.Size(73, 13);
            receiveDateLabel.TabIndex = 310;
            receiveDateLabel.Text = "Receive Date";
            // 
            // orderIdLabel
            // 
            orderIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            orderIdLabel.AutoSize = true;
            orderIdLabel.Location = new System.Drawing.Point(851, 18);
            orderIdLabel.Name = "orderIdLabel";
            orderIdLabel.Size = new System.Drawing.Size(92, 13);
            orderIdLabel.TabIndex = 308;
            orderIdLabel.Text = "Customer Order Id";
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new System.Drawing.Point(24, 175);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new System.Drawing.Size(78, 13);
            phoneNumberLabel.TabIndex = 307;
            phoneNumberLabel.Text = "Phone Number";
            // 
            // shipZipLabel
            // 
            shipZipLabel.AutoSize = true;
            shipZipLabel.Location = new System.Drawing.Point(36, 149);
            shipZipLabel.Name = "shipZipLabel";
            shipZipLabel.Size = new System.Drawing.Size(66, 13);
            shipZipLabel.TabIndex = 306;
            shipZipLabel.Text = "Shipping Zip";
            // 
            // shipStateLabel
            // 
            shipStateLabel.AutoSize = true;
            shipStateLabel.Location = new System.Drawing.Point(26, 122);
            shipStateLabel.Name = "shipStateLabel";
            shipStateLabel.Size = new System.Drawing.Size(76, 13);
            shipStateLabel.TabIndex = 304;
            shipStateLabel.Text = "Shipping State";
            // 
            // shipCityLabel
            // 
            shipCityLabel.AutoSize = true;
            shipCityLabel.Location = new System.Drawing.Point(34, 96);
            shipCityLabel.Name = "shipCityLabel";
            shipCityLabel.Size = new System.Drawing.Size(68, 13);
            shipCityLabel.TabIndex = 303;
            shipCityLabel.Text = "Shipping City";
            // 
            // shipAddr2Label
            // 
            shipAddr2Label.AutoSize = true;
            shipAddr2Label.Location = new System.Drawing.Point(7, 70);
            shipAddr2Label.Name = "shipAddr2Label";
            shipAddr2Label.Size = new System.Drawing.Size(95, 13);
            shipAddr2Label.TabIndex = 302;
            shipAddr2Label.Text = "Shipping Address2";
            // 
            // shipAddrLabel
            // 
            shipAddrLabel.AutoSize = true;
            shipAddrLabel.Location = new System.Drawing.Point(13, 44);
            shipAddrLabel.Name = "shipAddrLabel";
            shipAddrLabel.Size = new System.Drawing.Size(89, 13);
            shipAddrLabel.TabIndex = 301;
            shipAddrLabel.Text = "Shipping Address";
            // 
            // shipNameLabel
            // 
            shipNameLabel.AutoSize = true;
            shipNameLabel.Location = new System.Drawing.Point(23, 18);
            shipNameLabel.Name = "shipNameLabel";
            shipNameLabel.Size = new System.Drawing.Size(79, 13);
            shipNameLabel.TabIndex = 300;
            shipNameLabel.Text = "Shipping Name";
            // 
            // requestedShipMethodLabel
            // 
            requestedShipMethodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            requestedShipMethodLabel.AutoSize = true;
            requestedShipMethodLabel.Location = new System.Drawing.Point(436, 86);
            requestedShipMethodLabel.Name = "requestedShipMethodLabel";
            requestedShipMethodLabel.Size = new System.Drawing.Size(122, 13);
            requestedShipMethodLabel.TabIndex = 334;
            requestedShipMethodLabel.Text = "Requested Ship Method";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(67, 204);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(32, 13);
            emailLabel.TabIndex = 336;
            emailLabel.Text = "Email";
            // 
            // statesBindingSource
            // 
            this.statesBindingSource.DataMember = "states";
            this.statesBindingSource.DataSource = this.lookUp;
            // 
            // lookUp
            // 
            this.lookUp.DataSetName = "LookUp";
            this.lookUp.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // zazzleOrderDataGridView
            // 
            this.zazzleOrderDataGridView.AllowUserToAddRows = false;
            this.zazzleOrderDataGridView.AllowUserToDeleteRows = false;
            this.zazzleOrderDataGridView.AllowUserToOrderColumns = true;
            this.zazzleOrderDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zazzleOrderDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.zazzleOrderDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.zazzleOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zazzleOrderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodticket,
            this.invnoDataGridViewTextBoxColumn,
            this.orderIdDataGridViewTextBoxColumn,
            this.itemIdDataGridViewTextBoxColumn,
            this.itemTypeDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.attributesDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.numPerPackDataGridViewTextBoxColumn,
            this.reprintInstructionsDataGridViewTextBoxColumn,
            this.productsDataGridViewTextBoxColumn,
            this.productIdDataGridViewTextBoxColumn});
            this.zazzleOrderDataGridView.DataSource = this.zazzleOrderDetailBindingSource;
            this.zazzleOrderDataGridView.EnableHeadersVisualStyles = false;
            this.zazzleOrderDataGridView.Location = new System.Drawing.Point(85, 337);
            this.zazzleOrderDataGridView.Name = "zazzleOrderDataGridView";
            this.zazzleOrderDataGridView.ReadOnly = true;
            this.zazzleOrderDataGridView.RowHeadersWidth = 20;
            this.zazzleOrderDataGridView.Size = new System.Drawing.Size(1112, 275);
            this.zazzleOrderDataGridView.TabIndex = 131;
            this.zazzleOrderDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.zazzleOrderDataGridView_CellContentClick);
            this.zazzleOrderDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.zazzleOrderDataGridView_CellContentDoubleClick);
            this.zazzleOrderDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.mixBookOrderDataGridView_CellFormatting);
            this.zazzleOrderDataGridView.Enter += new System.EventHandler(this.zazzleOrderDataGridView_Enter);
            // 
            // prodticket
            // 
            this.prodticket.HeaderText = "";
            this.prodticket.Name = "prodticket";
            this.prodticket.ReadOnly = true;
            this.prodticket.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.prodticket.Text = "Print Ticket";
            this.prodticket.UseColumnTextForLinkValue = true;
            this.prodticket.Visible = false;
            this.prodticket.Width = 75;
            // 
            // invnoDataGridViewTextBoxColumn
            // 
            this.invnoDataGridViewTextBoxColumn.DataPropertyName = "Invno";
            this.invnoDataGridViewTextBoxColumn.HeaderText = "Invno";
            this.invnoDataGridViewTextBoxColumn.Name = "invnoDataGridViewTextBoxColumn";
            this.invnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.invnoDataGridViewTextBoxColumn.Width = 75;
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            this.orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.HeaderText = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            this.orderIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderIdDataGridViewTextBoxColumn.Width = 80;
            // 
            // itemIdDataGridViewTextBoxColumn
            // 
            this.itemIdDataGridViewTextBoxColumn.DataPropertyName = "ItemId";
            this.itemIdDataGridViewTextBoxColumn.HeaderText = "ItemId";
            this.itemIdDataGridViewTextBoxColumn.Name = "itemIdDataGridViewTextBoxColumn";
            this.itemIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIdDataGridViewTextBoxColumn.Width = 80;
            // 
            // itemTypeDataGridViewTextBoxColumn
            // 
            this.itemTypeDataGridViewTextBoxColumn.DataPropertyName = "ItemType";
            this.itemTypeDataGridViewTextBoxColumn.HeaderText = "ItemType";
            this.itemTypeDataGridViewTextBoxColumn.Name = "itemTypeDataGridViewTextBoxColumn";
            this.itemTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 70;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // attributesDataGridViewTextBoxColumn
            // 
            this.attributesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.attributesDataGridViewTextBoxColumn.DataPropertyName = "Attributes";
            this.attributesDataGridViewTextBoxColumn.HeaderText = "Attributes";
            this.attributesDataGridViewTextBoxColumn.Name = "attributesDataGridViewTextBoxColumn";
            this.attributesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numPerPackDataGridViewTextBoxColumn
            // 
            this.numPerPackDataGridViewTextBoxColumn.DataPropertyName = "NumPerPack";
            this.numPerPackDataGridViewTextBoxColumn.HeaderText = "NumPerPack";
            this.numPerPackDataGridViewTextBoxColumn.Name = "numPerPackDataGridViewTextBoxColumn";
            this.numPerPackDataGridViewTextBoxColumn.ReadOnly = true;
            this.numPerPackDataGridViewTextBoxColumn.Visible = false;
            // 
            // reprintInstructionsDataGridViewTextBoxColumn
            // 
            this.reprintInstructionsDataGridViewTextBoxColumn.DataPropertyName = "ReprintInstructions";
            this.reprintInstructionsDataGridViewTextBoxColumn.HeaderText = "ReprintInstructions";
            this.reprintInstructionsDataGridViewTextBoxColumn.Name = "reprintInstructionsDataGridViewTextBoxColumn";
            this.reprintInstructionsDataGridViewTextBoxColumn.ReadOnly = true;
            this.reprintInstructionsDataGridViewTextBoxColumn.Visible = false;
            // 
            // productsDataGridViewTextBoxColumn
            // 
            this.productsDataGridViewTextBoxColumn.DataPropertyName = "Products";
            this.productsDataGridViewTextBoxColumn.HeaderText = "Products";
            this.productsDataGridViewTextBoxColumn.Name = "productsDataGridViewTextBoxColumn";
            this.productsDataGridViewTextBoxColumn.ReadOnly = true;
            this.productsDataGridViewTextBoxColumn.Visible = false;
            // 
            // productIdDataGridViewTextBoxColumn
            // 
            this.productIdDataGridViewTextBoxColumn.DataPropertyName = "ProductId";
            this.productIdDataGridViewTextBoxColumn.HeaderText = "ProductId";
            this.productIdDataGridViewTextBoxColumn.Name = "productIdDataGridViewTextBoxColumn";
            this.productIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.productIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // zazzleOrderDetailBindingSource
            // 
            this.zazzleOrderDetailBindingSource.DataMember = "ZazzleOrderDetail";
            this.zazzleOrderDetailBindingSource.DataSource = this.dsZazzle;
            // 
            // dsZazzle
            // 
            this.dsZazzle.DataSetName = "dsZazzle";
            this.dsZazzle.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // statesTableAdapter
            // 
            this.statesTableAdapter.ClearBeforeFill = true;
            // 
            // btnMixbookPkgList
            // 
            this.btnMixbookPkgList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMixbookPkgList.Location = new System.Drawing.Point(98, 308);
            this.btnMixbookPkgList.Name = "btnMixbookPkgList";
            this.btnMixbookPkgList.Size = new System.Drawing.Size(153, 23);
            this.btnMixbookPkgList.TabIndex = 300;
            this.btnMixbookPkgList.Text = "Print Mixbook Pkg List";
            this.btnMixbookPkgList.UseVisualStyleBackColor = true;
            this.btnMixbookPkgList.Click += new System.EventHandler(this.btnMixbookPkgList_Click);
            // 
            // reportViewer2
            // 
            this.reportViewer2.DocumentMapWidth = 35;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookRemakeTicketSingle.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(9, 373);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(67, 46);
            this.reportViewer2.TabIndex = 10015;
            this.reportViewer2.Visible = false;
            this.reportViewer2.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer2_RenderingComplete);
            // 
            // pnlOrder
            // 
            this.pnlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrder.Controls.Add(this.invnoLabel3);
            this.pnlOrder.Controls.Add(emailLabel);
            this.pnlOrder.Controls.Add(this.emailTextBox);
            this.pnlOrder.Controls.Add(this.btnHold);
            this.pnlOrder.Controls.Add(requestedShipMethodLabel);
            this.pnlOrder.Controls.Add(this.requestedShipMethodLabel1);
            this.pnlOrder.Controls.Add(this.shipAddr2TextBox);
            this.pnlOrder.Controls.Add(notesLabel);
            this.pnlOrder.Controls.Add(this.notesTextBox);
            this.pnlOrder.Controls.Add(this.lblDateShipped);
            this.pnlOrder.Controls.Add(weightLabel);
            this.pnlOrder.Controls.Add(this.weightTextBox);
            this.pnlOrder.Controls.Add(trackingNumberLabel);
            this.pnlOrder.Controls.Add(this.trackingNumberTextBox);
            this.pnlOrder.Controls.Add(invnoLabel);
            this.pnlOrder.Controls.Add(this.phoneNumberTextBox);
            this.pnlOrder.Controls.Add(this.shipZipTextBox);
            this.pnlOrder.Controls.Add(this.shipCityTextBox);
            this.pnlOrder.Controls.Add(this.shipAddrTextBox);
            this.pnlOrder.Controls.Add(this.shipNameTextBox);
            this.pnlOrder.Controls.Add(shipMethodLabel);
            this.pnlOrder.Controls.Add(this.shipMethodComboBox);
            this.pnlOrder.Controls.Add(dateShippedLabel);
            this.pnlOrder.Controls.Add(shipDateLabel);
            this.pnlOrder.Controls.Add(this.schoutDateBox);
            this.pnlOrder.Controls.Add(receiveDateLabel);
            this.pnlOrder.Controls.Add(this.receiveDateLabel1);
            this.pnlOrder.Controls.Add(orderIdLabel);
            this.pnlOrder.Controls.Add(this.orderIdLabel1);
            this.pnlOrder.Controls.Add(phoneNumberLabel);
            this.pnlOrder.Controls.Add(shipZipLabel);
            this.pnlOrder.Controls.Add(shipStateLabel);
            this.pnlOrder.Controls.Add(this.shipStateComboBox);
            this.pnlOrder.Controls.Add(shipCityLabel);
            this.pnlOrder.Controls.Add(shipAddr2Label);
            this.pnlOrder.Controls.Add(shipAddrLabel);
            this.pnlOrder.Controls.Add(shipNameLabel);
            this.pnlOrder.Enabled = false;
            this.pnlOrder.Location = new System.Drawing.Point(52, 28);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1177, 267);
            this.pnlOrder.TabIndex = 10016;
            // 
            // invnoLabel3
            // 
            this.invnoLabel3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderDetailBindingSource, "Invno", true));
            this.invnoLabel3.Location = new System.Drawing.Point(953, 70);
            this.invnoLabel3.Name = "invnoLabel3";
            this.invnoLabel3.Size = new System.Drawing.Size(100, 18);
            this.invnoLabel3.TabIndex = 338;
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(108, 201);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(251, 20);
            this.emailTextBox.TabIndex = 337;
            // 
            // zazzleOrderBindingSource
            // 
            this.zazzleOrderBindingSource.DataMember = "ZazzleOrder";
            this.zazzleOrderBindingSource.DataSource = this.dsZazzle;
            this.zazzleOrderBindingSource.PositionChanged += new System.EventHandler(this.zazzleOrderBindingSource_PositionChanged);
            // 
            // btnHold
            // 
            this.btnHold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHold.Location = new System.Drawing.Point(851, 117);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(92, 23);
            this.btnHold.TabIndex = 336;
            this.btnHold.Text = "Toggle Hold";
            this.btnHold.UseVisualStyleBackColor = true;
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // requestedShipMethodLabel1
            // 
            this.requestedShipMethodLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.requestedShipMethodLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "DeliveryMethod", true));
            this.requestedShipMethodLabel1.Location = new System.Drawing.Point(569, 86);
            this.requestedShipMethodLabel1.Name = "requestedShipMethodLabel1";
            this.requestedShipMethodLabel1.Size = new System.Drawing.Size(227, 23);
            this.requestedShipMethodLabel1.TabIndex = 335;
            this.requestedShipMethodLabel1.Text = "label1";
            // 
            // shipAddr2TextBox
            // 
            this.shipAddr2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "ShipAddr2", true));
            this.shipAddr2TextBox.Location = new System.Drawing.Point(108, 71);
            this.shipAddr2TextBox.Name = "shipAddr2TextBox";
            this.shipAddr2TextBox.Size = new System.Drawing.Size(251, 20);
            this.shipAddr2TextBox.TabIndex = 334;
            // 
            // notesTextBox
            // 
            this.notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "Notes", true));
            this.notesTextBox.Location = new System.Drawing.Point(569, 189);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(334, 49);
            this.notesTextBox.TabIndex = 333;
            // 
            // lblDateShipped
            // 
            this.lblDateShipped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateShipped.Location = new System.Drawing.Point(569, 45);
            this.lblDateShipped.Name = "lblDateShipped";
            this.lblDateShipped.Size = new System.Drawing.Size(192, 15);
            this.lblDateShipped.TabIndex = 331;
            // 
            // weightTextBox
            // 
            this.weightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weightTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "Notes", true));
            this.weightTextBox.Location = new System.Drawing.Point(569, 165);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(100, 20);
            this.weightTextBox.TabIndex = 330;
            // 
            // trackingNumberTextBox
            // 
            this.trackingNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackingNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "TrackingNumber", true));
            this.trackingNumberTextBox.Location = new System.Drawing.Point(569, 115);
            this.trackingNumberTextBox.MaxLength = 500000;
            this.trackingNumberTextBox.Multiline = true;
            this.trackingNumberTextBox.Name = "trackingNumberTextBox";
            this.trackingNumberTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.trackingNumberTextBox.Size = new System.Drawing.Size(247, 44);
            this.trackingNumberTextBox.TabIndex = 328;
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "Phone", true));
            this.phoneNumberTextBox.Location = new System.Drawing.Point(108, 175);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(126, 20);
            this.phoneNumberTextBox.TabIndex = 322;
            // 
            // shipZipTextBox
            // 
            this.shipZipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "Zip", true));
            this.shipZipTextBox.Location = new System.Drawing.Point(108, 146);
            this.shipZipTextBox.Name = "shipZipTextBox";
            this.shipZipTextBox.Size = new System.Drawing.Size(126, 20);
            this.shipZipTextBox.TabIndex = 321;
            // 
            // shipCityTextBox
            // 
            this.shipCityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "City", true));
            this.shipCityTextBox.Location = new System.Drawing.Point(108, 96);
            this.shipCityTextBox.Name = "shipCityTextBox";
            this.shipCityTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipCityTextBox.TabIndex = 319;
            // 
            // shipAddrTextBox
            // 
            this.shipAddrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "ShipAddr1", true));
            this.shipAddrTextBox.Location = new System.Drawing.Point(108, 44);
            this.shipAddrTextBox.Name = "shipAddrTextBox";
            this.shipAddrTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipAddrTextBox.TabIndex = 318;
            // 
            // shipNameTextBox
            // 
            this.shipNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "Name", true));
            this.shipNameTextBox.Location = new System.Drawing.Point(108, 18);
            this.shipNameTextBox.Name = "shipNameTextBox";
            this.shipNameTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipNameTextBox.TabIndex = 317;
            // 
            // shipMethodComboBox
            // 
            this.shipMethodComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shipMethodComboBox.DisplayMember = "ShipAlias";
            this.shipMethodComboBox.FormattingEnabled = true;
            this.shipMethodComboBox.Location = new System.Drawing.Point(569, 62);
            this.shipMethodComboBox.Name = "shipMethodComboBox";
            this.shipMethodComboBox.Size = new System.Drawing.Size(227, 21);
            this.shipMethodComboBox.TabIndex = 316;
            this.shipMethodComboBox.ValueMember = "ShipAlias";
            // 
            // schoutDateBox
            // 
            this.schoutDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.schoutDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.zazzleOrderBindingSource, "ShipDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.schoutDateBox.Date = null;
            this.schoutDateBox.DateValue = null;
            this.schoutDateBox.Location = new System.Drawing.Point(569, 18);
            this.schoutDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.schoutDateBox.Name = "schoutDateBox";
            this.schoutDateBox.Size = new System.Drawing.Size(192, 20);
            this.schoutDateBox.TabIndex = 312;
            // 
            // receiveDateLabel1
            // 
            this.receiveDateLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.receiveDateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "OrderReceiveDate", true));
            this.receiveDateLabel1.Location = new System.Drawing.Point(953, 44);
            this.receiveDateLabel1.Name = "receiveDateLabel1";
            this.receiveDateLabel1.Size = new System.Drawing.Size(139, 23);
            this.receiveDateLabel1.TabIndex = 311;
            // 
            // orderIdLabel1
            // 
            this.orderIdLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.orderIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "OrderId", true));
            this.orderIdLabel1.Location = new System.Drawing.Point(953, 18);
            this.orderIdLabel1.Name = "orderIdLabel1";
            this.orderIdLabel1.Size = new System.Drawing.Size(100, 23);
            this.orderIdLabel1.TabIndex = 309;
            // 
            // shipStateComboBox
            // 
            this.shipStateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.zazzleOrderBindingSource, "State", true));
            this.shipStateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.zazzleOrderBindingSource, "State", true));
            this.shipStateComboBox.DataSource = this.statesBindingSource;
            this.shipStateComboBox.DisplayMember = "Name";
            this.shipStateComboBox.FormattingEnabled = true;
            this.shipStateComboBox.Location = new System.Drawing.Point(108, 122);
            this.shipStateComboBox.Name = "shipStateComboBox";
            this.shipStateComboBox.Size = new System.Drawing.Size(126, 21);
            this.shipStateComboBox.TabIndex = 305;
            this.shipStateComboBox.ValueMember = "Abrev";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(9, 31);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(37, 23);
            this.btnEdit.TabIndex = 10017;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDownloadFiles
            // 
            this.btnDownloadFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadFiles.Location = new System.Drawing.Point(961, 308);
            this.btnDownloadFiles.Name = "btnDownloadFiles";
            this.btnDownloadFiles.Size = new System.Drawing.Size(203, 23);
            this.btnDownloadFiles.TabIndex = 10018;
            this.btnDownloadFiles.Text = "Re - Download Files From Mixbook";
            this.btnDownloadFiles.UseVisualStyleBackColor = true;
            this.btnDownloadFiles.Click += new System.EventHandler(this.btnDownloadFiles_Click);
            // 
            // btnRemake
            // 
            this.btnRemake.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemake.Location = new System.Drawing.Point(276, 308);
            this.btnRemake.Name = "btnRemake";
            this.btnRemake.Size = new System.Drawing.Size(153, 23);
            this.btnRemake.TabIndex = 10019;
            this.btnRemake.Text = "Print Remake Ticket";
            this.btnRemake.UseVisualStyleBackColor = true;
            this.btnRemake.Click += new System.EventHandler(this.btnRemake_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 35;
            reportDataSource2.Name = "dsMxPackingSlip";
            reportDataSource2.Value = null;
            reportDataSource3.Name = "dsMixBookRemakeTkt";
            reportDataSource3.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookRemakeTkt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(9, 313);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(52, 54);
            this.reportViewer1.TabIndex = 10020;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // cmdJobTicket
            // 
            this.cmdJobTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdJobTicket.Location = new System.Drawing.Point(447, 308);
            this.cmdJobTicket.Name = "cmdJobTicket";
            this.cmdJobTicket.Size = new System.Drawing.Size(153, 23);
            this.cmdJobTicket.TabIndex = 10023;
            this.cmdJobTicket.Text = "Print Job Ticket";
            this.cmdJobTicket.UseVisualStyleBackColor = true;
            this.cmdJobTicket.Click += new System.EventHandler(this.cmdJobTicket_Click);
            // 
            // reportViewer3
            // 
            this.reportViewer3.DocumentMapWidth = 35;
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = null;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixbookJobTicketSingle.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(9, 425);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(63, 64);
            this.reportViewer3.TabIndex = 10024;
            this.reportViewer3.Visible = false;
            this.reportViewer3.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer3_RenderingComplete);
            // 
            // zazzleOrderTableAdapter
            // 
            this.zazzleOrderTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsZazzleTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.ZazzleOrderDetailTableAdapter = null;
            this.tableAdapterManager.ZazzleOrderTableAdapter = this.zazzleOrderTableAdapter;
            // 
            // zazzleOrderBindingNavigator
            // 
            this.zazzleOrderBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.zazzleOrderBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.zazzleOrderBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.zazzleOrderBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.mixBookOrderBindingNavigatorSaveItem,
            this.toolStripButton3,
            this.toolStripButton1,
            this.itemIdToolStripBtn,
            this.purgeStripButton2});
            this.zazzleOrderBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.zazzleOrderBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.zazzleOrderBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.zazzleOrderBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.zazzleOrderBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.zazzleOrderBindingNavigator.Name = "zazzleOrderBindingNavigator";
            this.zazzleOrderBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.zazzleOrderBindingNavigator.Size = new System.Drawing.Size(1251, 25);
            this.zazzleOrderBindingNavigator.TabIndex = 10025;
            this.zazzleOrderBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Enabled = false;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Enabled = false;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // mixBookOrderBindingNavigatorSaveItem
            // 
            this.mixBookOrderBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("mixBookOrderBindingNavigatorSaveItem.Image")));
            this.mixBookOrderBindingNavigatorSaveItem.Name = "mixBookOrderBindingNavigatorSaveItem";
            this.mixBookOrderBindingNavigatorSaveItem.Size = new System.Drawing.Size(54, 22);
            this.mixBookOrderBindingNavigatorSaveItem.Text = "Save ";
            this.mixBookOrderBindingNavigatorSaveItem.Click += new System.EventHandler(this.zazzleOrderBindingNavigatorSaveItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Mbc5.Properties.Resources.iconfinder_order_59488;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(70, 22);
            this.toolStripButton3.Text = "Order Id";
            this.toolStripButton3.ToolTipText = "Order Id";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripButton1.Text = "Ship Name";
            this.toolStripButton1.ToolTipText = "Name";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // itemIdToolStripBtn
            // 
            this.itemIdToolStripBtn.Image = ((System.Drawing.Image)(resources.GetObject("itemIdToolStripBtn.Image")));
            this.itemIdToolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itemIdToolStripBtn.Name = "itemIdToolStripBtn";
            this.itemIdToolStripBtn.Size = new System.Drawing.Size(64, 22);
            this.itemIdToolStripBtn.Text = "Item Id";
            // 
            // purgeStripButton2
            // 
            this.purgeStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("purgeStripButton2.Image")));
            this.purgeStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.purgeStripButton2.Name = "purgeStripButton2";
            this.purgeStripButton2.Size = new System.Drawing.Size(58, 22);
            this.purgeStripButton2.Text = "Purge";
            // 
            // zazzleOrderDetailTableAdapter
            // 
            this.zazzleOrderDetailTableAdapter.ClearBeforeFill = true;
            // 
            // frmZaOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1251, 646);
            this.Controls.Add(this.zazzleOrderBindingNavigator);
            this.Controls.Add(this.reportViewer3);
            this.Controls.Add(this.cmdJobTicket);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnRemake);
            this.Controls.Add(this.btnDownloadFiles);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.btnMixbookPkgList);
            this.Controls.Add(this.zazzleOrderDataGridView);
            this.MaxNumForms = 2;
            this.MinimumSize = new System.Drawing.Size(1191, 630);
            this.Name = "frmZaOrders";
            this.Text = "Zazzle Cust/Orders";
            this.Load += new System.EventHandler(this.MBOrders_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.zazzleOrderDataGridView, 0);
            this.Controls.SetChildIndex(this.btnMixbookPkgList, 0);
            this.Controls.SetChildIndex(this.reportViewer2, 0);
            this.Controls.SetChildIndex(this.pnlOrder, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDownloadFiles, 0);
            this.Controls.SetChildIndex(this.btnRemake, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.cmdJobTicket, 0);
            this.Controls.SetChildIndex(this.reportViewer3, 0);
            this.Controls.SetChildIndex(this.zazzleOrderBindingNavigator, 0);
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zazzleOrderDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zazzleOrderDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsZazzle)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zazzleOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zazzleOrderBindingNavigator)).EndInit();
            this.zazzleOrderBindingNavigator.ResumeLayout(false);
            this.zazzleOrderBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView zazzleOrderDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataSets.LookUp lookUp;
        private System.Windows.Forms.BindingSource statesBindingSource;
        private DataSets.LookUpTableAdapters.statesTableAdapter statesTableAdapter;
        private System.Windows.Forms.Button btnMixbookPkgList;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label lblDateShipped;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.TextBox trackingNumberTextBox;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.TextBox shipZipTextBox;
        private System.Windows.Forms.TextBox shipCityTextBox;
        private System.Windows.Forms.TextBox shipAddrTextBox;
        private System.Windows.Forms.TextBox shipNameTextBox;
        private System.Windows.Forms.ComboBox shipMethodComboBox;
        private CustomControls.DateBox schoutDateBox;
        private System.Windows.Forms.Label receiveDateLabel1;
        private System.Windows.Forms.Label orderIdLabel1;
        private System.Windows.Forms.ComboBox shipStateComboBox;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDownloadFiles;
        private System.Windows.Forms.Button btnRemake;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox shipAddr2TextBox;
        private System.Windows.Forms.Label requestedShipMethodLabel1;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.Button cmdJobTicket;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private DataSets.dsZazzle dsZazzle;
        private System.Windows.Forms.BindingSource zazzleOrderBindingSource;
        private DataSets.dsZazzleTableAdapters.ZazzleOrderTableAdapter zazzleOrderTableAdapter;
        private DataSets.dsZazzleTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.BindingNavigator zazzleOrderBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton mixBookOrderBindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton itemIdToolStripBtn;
        private System.Windows.Forms.ToolStripButton purgeStripButton2;
        private System.Windows.Forms.BindingSource zazzleOrderDetailBindingSource;
        private DataSets.dsZazzleTableAdapters.ZazzleOrderDetailTableAdapter zazzleOrderDetailTableAdapter;
        private System.Windows.Forms.Label invnoLabel3;
        private System.Windows.Forms.DataGridViewLinkColumn prodticket;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attributesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numPerPackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reprintInstructionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
    }
}
