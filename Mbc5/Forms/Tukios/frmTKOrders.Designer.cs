namespace Mbc5.Forms.Tukios
{
    partial class frmTKOrders
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
            System.Windows.Forms.Label orderStatusLabel;
            System.Windows.Forms.Label invnoLabel;
            System.Windows.Forms.Label dateShippedLabel;
            System.Windows.Forms.Label shipDateLabel;
            System.Windows.Forms.Label receiveDateLabel;
            System.Windows.Forms.Label orderIdLabel;
            System.Windows.Forms.Label shipZipLabel;
            System.Windows.Forms.Label shipStateLabel;
            System.Windows.Forms.Label shipCityLabel;
            System.Windows.Forms.Label shipAddr2Label;
            System.Windows.Forms.Label shipAddrLabel;
            System.Windows.Forms.Label shipNameLabel;
            System.Windows.Forms.Label coverStatusLabel;
            System.Windows.Forms.Label bookStatusLabel;
            System.Windows.Forms.Label jobPrintBatchLabel;
            System.Windows.Forms.Label requestedShipMethodLabel;
            System.Windows.Forms.Label groupIdLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTKOrders));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tableAdapterManager = new Mbc5.DataSets.MixBookOrdersTableAdapters.TableAdapterManager();
            this.statesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUp = new Mbc5.DataSets.LookUp();
            this.tukiosOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.prodticket = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.copiesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoverUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            this.BookUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tukiosOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsTukiosOrders = new Mbc5.DataSets.TukiosOrders();
            this.statesTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.statesTableAdapter();
            this.btnMixbookPkgList = new System.Windows.Forms.Button();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.groupIdLabel1 = new System.Windows.Forms.Label();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnRemoveOrder = new System.Windows.Forms.Button();
            this.jobPrintBatchLabel1 = new System.Windows.Forms.Label();
            this.btnEmailTrk = new System.Windows.Forms.Button();
            this.orderRePrintCheckBox = new System.Windows.Forms.CheckBox();
            this.btnHold = new System.Windows.Forms.Button();
            this.requestedShipMethodLabel1 = new System.Windows.Forms.Label();
            this.shipAddr2TextBox = new System.Windows.Forms.TextBox();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.lblDateShipped = new System.Windows.Forms.Label();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.trackingNumberTextBox = new System.Windows.Forms.TextBox();
            this.orderStatusLabel2 = new System.Windows.Forms.Label();
            this.invnoLabel1 = new System.Windows.Forms.Label();
            this.shipZipTextBox = new System.Windows.Forms.TextBox();
            this.shipCityTextBox = new System.Windows.Forms.TextBox();
            this.shipAddrTextBox = new System.Windows.Forms.TextBox();
            this.shipNameTextBox = new System.Windows.Forms.TextBox();
            this.schoutDateBox = new CustomControls.DateBox();
            this.receiveDateLabel1 = new System.Windows.Forms.Label();
            this.orderIdLabel1 = new System.Windows.Forms.Label();
            this.shipStateComboBox = new System.Windows.Forms.ComboBox();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDownloadFiles = new System.Windows.Forms.Button();
            this.btnRemake = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bookStatusLabel1 = new System.Windows.Forms.Label();
            this.cmdJobTicket = new System.Windows.Forms.Button();
            this.btnCvrRemake = new System.Windows.Forms.Button();
            this.btnBkRemake = new System.Windows.Forms.Button();
            this.pnlRemake = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tukiosOrderBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.itemIdToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.purgeStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tukiosOrderBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.lblCanceled = new System.Windows.Forms.Label();
            this.lblHold = new System.Windows.Forms.Label();
            this.tukiosOrderTableAdapter = new Mbc5.DataSets.TukiosOrdersTableAdapters.TukiosOrderTableAdapter();
            this.tableAdapterManager1 = new Mbc5.DataSets.TukiosOrdersTableAdapters.TableAdapterManager();
            this.JobTicketQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            notesLabel = new System.Windows.Forms.Label();
            weightLabel = new System.Windows.Forms.Label();
            trackingNumberLabel = new System.Windows.Forms.Label();
            orderStatusLabel = new System.Windows.Forms.Label();
            invnoLabel = new System.Windows.Forms.Label();
            dateShippedLabel = new System.Windows.Forms.Label();
            shipDateLabel = new System.Windows.Forms.Label();
            receiveDateLabel = new System.Windows.Forms.Label();
            orderIdLabel = new System.Windows.Forms.Label();
            shipZipLabel = new System.Windows.Forms.Label();
            shipStateLabel = new System.Windows.Forms.Label();
            shipCityLabel = new System.Windows.Forms.Label();
            shipAddr2Label = new System.Windows.Forms.Label();
            shipAddrLabel = new System.Windows.Forms.Label();
            shipNameLabel = new System.Windows.Forms.Label();
            coverStatusLabel = new System.Windows.Forms.Label();
            bookStatusLabel = new System.Windows.Forms.Label();
            jobPrintBatchLabel = new System.Windows.Forms.Label();
            requestedShipMethodLabel = new System.Windows.Forms.Label();
            groupIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tukiosOrderDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tukiosOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTukiosOrders)).BeginInit();
            this.pnlOrder.SuspendLayout();
            this.pnlRemake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tukiosOrderBindingNavigator)).BeginInit();
            this.tukiosOrderBindingNavigator.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JobTicketQueryBindingSource)).BeginInit();
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
            notesLabel.Location = new System.Drawing.Point(535, 172);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(38, 13);
            notesLabel.TabIndex = 332;
            notesLabel.Text = "Notes:";
            // 
            // weightLabel
            // 
            weightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            weightLabel.AutoSize = true;
            weightLabel.Location = new System.Drawing.Point(532, 145);
            weightLabel.Name = "weightLabel";
            weightLabel.Size = new System.Drawing.Size(41, 13);
            weightLabel.TabIndex = 329;
            weightLabel.Text = "Weight";
            // 
            // trackingNumberLabel
            // 
            trackingNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            trackingNumberLabel.AutoSize = true;
            trackingNumberLabel.Location = new System.Drawing.Point(484, 95);
            trackingNumberLabel.Name = "trackingNumberLabel";
            trackingNumberLabel.Size = new System.Drawing.Size(89, 13);
            trackingNumberLabel.TabIndex = 327;
            trackingNumberLabel.Text = "Tracking Number";
            // 
            // orderStatusLabel
            // 
            orderStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            orderStatusLabel.AutoSize = true;
            orderStatusLabel.Location = new System.Drawing.Point(888, 121);
            orderStatusLabel.Name = "orderStatusLabel";
            orderStatusLabel.Size = new System.Drawing.Size(66, 13);
            orderStatusLabel.TabIndex = 325;
            orderStatusLabel.Text = "Order Status";
            orderStatusLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tukiosOrderStatusLabel_MouseDoubleClick);
            // 
            // invnoLabel
            // 
            invnoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            invnoLabel.AutoSize = true;
            invnoLabel.Location = new System.Drawing.Point(892, 91);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(62, 13);
            invnoLabel.TabIndex = 323;
            invnoLabel.Text = "Invoice No.";
            // 
            // dateShippedLabel
            // 
            dateShippedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateShippedLabel.AutoSize = true;
            dateShippedLabel.Location = new System.Drawing.Point(501, 44);
            dateShippedLabel.Name = "dateShippedLabel";
            dateShippedLabel.Size = new System.Drawing.Size(72, 13);
            dateShippedLabel.TabIndex = 314;
            dateShippedLabel.Text = "Date Shipped";
            // 
            // shipDateLabel
            // 
            shipDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            shipDateLabel.AutoSize = true;
            shipDateLabel.Location = new System.Drawing.Point(464, 18);
            shipDateLabel.Name = "shipDateLabel";
            shipDateLabel.Size = new System.Drawing.Size(109, 13);
            shipDateLabel.TabIndex = 313;
            shipDateLabel.Text = "Requested Ship Date";
            // 
            // receiveDateLabel
            // 
            receiveDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            receiveDateLabel.AutoSize = true;
            receiveDateLabel.Location = new System.Drawing.Point(880, 65);
            receiveDateLabel.Name = "receiveDateLabel";
            receiveDateLabel.Size = new System.Drawing.Size(73, 13);
            receiveDateLabel.TabIndex = 310;
            receiveDateLabel.Text = "Receive Date";
            // 
            // orderIdLabel
            // 
            orderIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            orderIdLabel.AutoSize = true;
            orderIdLabel.Location = new System.Drawing.Point(908, 18);
            orderIdLabel.Name = "orderIdLabel";
            orderIdLabel.Size = new System.Drawing.Size(45, 13);
            orderIdLabel.TabIndex = 308;
            orderIdLabel.Text = "Order Id";
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
            // coverStatusLabel
            // 
            coverStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            coverStatusLabel.AutoSize = true;
            coverStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            coverStatusLabel.Location = new System.Drawing.Point(95, 682);
            coverStatusLabel.Name = "coverStatusLabel";
            coverStatusLabel.Size = new System.Drawing.Size(84, 13);
            coverStatusLabel.TabIndex = 10020;
            coverStatusLabel.Text = "Cover Status:";
            coverStatusLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.coverStatusLabel_MouseDoubleClick);
            // 
            // bookStatusLabel
            // 
            bookStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            bookStatusLabel.AutoSize = true;
            bookStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            bookStatusLabel.Location = new System.Drawing.Point(709, 682);
            bookStatusLabel.Name = "bookStatusLabel";
            bookStatusLabel.Size = new System.Drawing.Size(80, 13);
            bookStatusLabel.TabIndex = 10021;
            bookStatusLabel.Text = "Book Status:";
            bookStatusLabel.Click += new System.EventHandler(this.bookStatusLabel_Click);
            // 
            // jobPrintBatchLabel
            // 
            jobPrintBatchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            jobPrintBatchLabel.AutoSize = true;
            jobPrintBatchLabel.Location = new System.Drawing.Point(875, 155);
            jobPrintBatchLabel.Name = "jobPrintBatchLabel";
            jobPrintBatchLabel.Size = new System.Drawing.Size(79, 13);
            jobPrintBatchLabel.TabIndex = 337;
            jobPrintBatchLabel.Text = "Job Print Batch";
            // 
            // requestedShipMethodLabel
            // 
            requestedShipMethodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            requestedShipMethodLabel.AutoSize = true;
            requestedShipMethodLabel.Location = new System.Drawing.Point(447, 66);
            requestedShipMethodLabel.Name = "requestedShipMethodLabel";
            requestedShipMethodLabel.Size = new System.Drawing.Size(122, 13);
            requestedShipMethodLabel.TabIndex = 334;
            requestedShipMethodLabel.Text = "Requested Ship Method";
            // 
            // groupIdLabel
            // 
            groupIdLabel.AutoSize = true;
            groupIdLabel.Location = new System.Drawing.Point(903, 178);
            groupIdLabel.Name = "groupIdLabel";
            groupIdLabel.Size = new System.Drawing.Size(51, 13);
            groupIdLabel.TabIndex = 342;
            groupIdLabel.Text = "Group Id:";
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.MixBookOrderTableAdapter = null;
            this.tableAdapterManager.ShipCarriersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.MixBookOrdersTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
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
            // tukiosOrderDataGridView
            // 
            this.tukiosOrderDataGridView.AllowUserToAddRows = false;
            this.tukiosOrderDataGridView.AllowUserToDeleteRows = false;
            this.tukiosOrderDataGridView.AllowUserToOrderColumns = true;
            this.tukiosOrderDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tukiosOrderDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tukiosOrderDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tukiosOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tukiosOrderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodticket,
            this.dataGridViewTextBoxColumn1,
            this.ItemId,
            this.descriptionDataGridViewTextBoxColumn,
            this.copiesDataGridViewTextBoxColumn,
            this.pagesDataGridViewTextBoxColumn,
            this.CoverUrl,
            this.BookUrl});
            this.tukiosOrderDataGridView.DataSource = this.tukiosOrderBindingSource;
            this.tukiosOrderDataGridView.EnableHeadersVisualStyles = false;
            this.tukiosOrderDataGridView.Location = new System.Drawing.Point(85, 337);
            this.tukiosOrderDataGridView.Name = "tukiosOrderDataGridView";
            this.tukiosOrderDataGridView.ReadOnly = true;
            this.tukiosOrderDataGridView.RowHeadersWidth = 20;
            this.tukiosOrderDataGridView.Size = new System.Drawing.Size(1122, 340);
            this.tukiosOrderDataGridView.TabIndex = 131;
            this.tukiosOrderDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tukiosOrderDataGridView_CellContentClick);
            this.tukiosOrderDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tukiosOrderDataGridView_CellContentDoubleClick);
            this.tukiosOrderDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tukiosOrderDataGridView_CellFormatting);
            this.tukiosOrderDataGridView.Enter += new System.EventHandler(this.tukiosOrderDataGridView_Enter);
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Invno";
            this.dataGridViewTextBoxColumn1.HeaderText = "Invno";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // ItemId
            // 
            this.ItemId.DataPropertyName = "BookId";
            this.ItemId.HeaderText = "Item Id";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // copiesDataGridViewTextBoxColumn
            // 
            this.copiesDataGridViewTextBoxColumn.DataPropertyName = "Copies";
            this.copiesDataGridViewTextBoxColumn.HeaderText = "Copies";
            this.copiesDataGridViewTextBoxColumn.Name = "copiesDataGridViewTextBoxColumn";
            this.copiesDataGridViewTextBoxColumn.ReadOnly = true;
            this.copiesDataGridViewTextBoxColumn.Width = 60;
            // 
            // pagesDataGridViewTextBoxColumn
            // 
            this.pagesDataGridViewTextBoxColumn.DataPropertyName = "Pages";
            this.pagesDataGridViewTextBoxColumn.HeaderText = "Pages";
            this.pagesDataGridViewTextBoxColumn.Name = "pagesDataGridViewTextBoxColumn";
            this.pagesDataGridViewTextBoxColumn.ReadOnly = true;
            this.pagesDataGridViewTextBoxColumn.Width = 60;
            // 
            // CoverUrl
            // 
            this.CoverUrl.DataPropertyName = "CoverUrl";
            dataGridViewCellStyle2.Format = "Cover";
            dataGridViewCellStyle2.NullValue = null;
            this.CoverUrl.DefaultCellStyle = dataGridViewCellStyle2;
            this.CoverUrl.HeaderText = "Cover Url";
            this.CoverUrl.Name = "CoverUrl";
            this.CoverUrl.ReadOnly = true;
            this.CoverUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CoverUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CoverUrl.Text = "";
            // 
            // BookUrl
            // 
            this.BookUrl.DataPropertyName = "BookBlockURL";
            this.BookUrl.HeaderText = "Book Url";
            this.BookUrl.Name = "BookUrl";
            this.BookUrl.ReadOnly = true;
            this.BookUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BookUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BookUrl.Text = "";
            // 
            // tukiosOrderBindingSource
            // 
            this.tukiosOrderBindingSource.DataMember = "TukiosOrder";
            this.tukiosOrderBindingSource.DataSource = this.dsTukiosOrders;
            this.tukiosOrderBindingSource.PositionChanged += new System.EventHandler(this.tukiosOrderBindingSource_PositionChanged);
            // 
            // dsTukiosOrders
            // 
            this.dsTukiosOrders.DataSetName = "TukiosOrders";
            this.dsTukiosOrders.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // statesTableAdapter
            // 
            this.statesTableAdapter.ClearBeforeFill = true;
            // 
            // btnMixbookPkgList
            // 
            this.btnMixbookPkgList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMixbookPkgList.Location = new System.Drawing.Point(9, 3);
            this.btnMixbookPkgList.Name = "btnMixbookPkgList";
            this.btnMixbookPkgList.Size = new System.Drawing.Size(153, 23);
            this.btnMixbookPkgList.TabIndex = 300;
            this.btnMixbookPkgList.Text = "Print Tukios Pkg List";
            this.btnMixbookPkgList.UseVisualStyleBackColor = true;
            this.btnMixbookPkgList.Click += new System.EventHandler(this.btnTukiosPkgList_Click);
            // 
            // reportViewer2
            // 
            this.reportViewer2.DocumentMapWidth = 35;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.EnableExternalImages = true;
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
            this.pnlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrder.Controls.Add(groupIdLabel);
            this.pnlOrder.Controls.Add(this.groupIdLabel1);
            this.pnlOrder.Controls.Add(this.btnCancelOrder);
            this.pnlOrder.Controls.Add(this.btnRemoveOrder);
            this.pnlOrder.Controls.Add(this.jobPrintBatchLabel1);
            this.pnlOrder.Controls.Add(this.btnEmailTrk);
            this.pnlOrder.Controls.Add(jobPrintBatchLabel);
            this.pnlOrder.Controls.Add(this.orderRePrintCheckBox);
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
            this.pnlOrder.Controls.Add(this.orderStatusLabel2);
            this.pnlOrder.Controls.Add(orderStatusLabel);
            this.pnlOrder.Controls.Add(invnoLabel);
            this.pnlOrder.Controls.Add(this.invnoLabel1);
            this.pnlOrder.Controls.Add(this.shipZipTextBox);
            this.pnlOrder.Controls.Add(this.shipCityTextBox);
            this.pnlOrder.Controls.Add(this.shipAddrTextBox);
            this.pnlOrder.Controls.Add(this.shipNameTextBox);
            this.pnlOrder.Controls.Add(dateShippedLabel);
            this.pnlOrder.Controls.Add(shipDateLabel);
            this.pnlOrder.Controls.Add(this.schoutDateBox);
            this.pnlOrder.Controls.Add(receiveDateLabel);
            this.pnlOrder.Controls.Add(this.receiveDateLabel1);
            this.pnlOrder.Controls.Add(orderIdLabel);
            this.pnlOrder.Controls.Add(this.orderIdLabel1);
            this.pnlOrder.Controls.Add(shipZipLabel);
            this.pnlOrder.Controls.Add(shipStateLabel);
            this.pnlOrder.Controls.Add(this.shipStateComboBox);
            this.pnlOrder.Controls.Add(shipCityLabel);
            this.pnlOrder.Controls.Add(shipAddr2Label);
            this.pnlOrder.Controls.Add(shipAddrLabel);
            this.pnlOrder.Controls.Add(shipNameLabel);
            this.pnlOrder.Location = new System.Drawing.Point(52, 28);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1187, 273);
            this.pnlOrder.TabIndex = 10016;
            this.pnlOrder.EnabledChanged += new System.EventHandler(this.pnlOrder_EnabledChanged);
            // 
            // groupIdLabel1
            // 
            this.groupIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "GroupId", true));
            this.groupIdLabel1.Location = new System.Drawing.Point(960, 178);
            this.groupIdLabel1.Name = "groupIdLabel1";
            this.groupIdLabel1.Size = new System.Drawing.Size(100, 23);
            this.groupIdLabel1.TabIndex = 343;
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelOrder.ForeColor = System.Drawing.Color.Red;
            this.btnCancelOrder.Location = new System.Drawing.Point(16, 226);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(122, 27);
            this.btnCancelOrder.TabIndex = 342;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Visible = false;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnRemoveOrder
            // 
            this.btnRemoveOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveOrder.ForeColor = System.Drawing.Color.Red;
            this.btnRemoveOrder.Location = new System.Drawing.Point(10, 226);
            this.btnRemoveOrder.Name = "btnRemoveOrder";
            this.btnRemoveOrder.Size = new System.Drawing.Size(133, 27);
            this.btnRemoveOrder.TabIndex = 341;
            this.btnRemoveOrder.Text = "Remove Order";
            this.btnRemoveOrder.UseVisualStyleBackColor = false;
            this.btnRemoveOrder.Visible = false;
            this.btnRemoveOrder.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // jobPrintBatchLabel1
            // 
            this.jobPrintBatchLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jobPrintBatchLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "JobPrintBatch", true));
            this.jobPrintBatchLabel1.Location = new System.Drawing.Point(960, 155);
            this.jobPrintBatchLabel1.Name = "jobPrintBatchLabel1";
            this.jobPrintBatchLabel1.Size = new System.Drawing.Size(100, 23);
            this.jobPrintBatchLabel1.TabIndex = 340;
            // 
            // btnEmailTrk
            // 
            this.btnEmailTrk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmailTrk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEmailTrk.BackgroundImage")));
            this.btnEmailTrk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmailTrk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailTrk.Location = new System.Drawing.Point(831, 94);
            this.btnEmailTrk.Name = "btnEmailTrk";
            this.btnEmailTrk.Size = new System.Drawing.Size(20, 21);
            this.btnEmailTrk.TabIndex = 339;
            this.btnEmailTrk.Text = "::";
            this.toolTip1.SetToolTip(this.btnEmailTrk, "Email Tracking Numbers");
            this.btnEmailTrk.UseVisualStyleBackColor = true;
            this.btnEmailTrk.Visible = false;
            this.btnEmailTrk.Click += new System.EventHandler(this.btnEmailTrk_Click);
            // 
            // orderRePrintCheckBox
            // 
            this.orderRePrintCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tukiosOrderBindingSource, "OrderRePrint", true));
            this.orderRePrintCheckBox.Location = new System.Drawing.Point(108, 201);
            this.orderRePrintCheckBox.Name = "orderRePrintCheckBox";
            this.orderRePrintCheckBox.Size = new System.Drawing.Size(104, 24);
            this.orderRePrintCheckBox.TabIndex = 337;
            this.orderRePrintCheckBox.Text = "Order Is Reprint";
            this.orderRePrintCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnHold
            // 
            this.btnHold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHold.Location = new System.Drawing.Point(895, 243);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(92, 23);
            this.btnHold.TabIndex = 336;
            this.btnHold.Text = "Toggle Hold";
            this.toolTip1.SetToolTip(this.btnHold, "Place order on hold. Plant only.");
            this.btnHold.UseVisualStyleBackColor = true;
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // requestedShipMethodLabel1
            // 
            this.requestedShipMethodLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.requestedShipMethodLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "ShipMethod", true));
            this.requestedShipMethodLabel1.Location = new System.Drawing.Point(575, 66);
            this.requestedShipMethodLabel1.Name = "requestedShipMethodLabel1";
            this.requestedShipMethodLabel1.Size = new System.Drawing.Size(227, 23);
            this.requestedShipMethodLabel1.TabIndex = 335;
            this.requestedShipMethodLabel1.Text = "label1";
            // 
            // shipAddr2TextBox
            // 
            this.shipAddr2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "ShipAddr2", true));
            this.shipAddr2TextBox.Location = new System.Drawing.Point(108, 71);
            this.shipAddr2TextBox.Name = "shipAddr2TextBox";
            this.shipAddr2TextBox.Size = new System.Drawing.Size(251, 20);
            this.shipAddr2TextBox.TabIndex = 334;
            // 
            // notesTextBox
            // 
            this.notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "Notes", true));
            this.notesTextBox.Location = new System.Drawing.Point(575, 169);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(276, 74);
            this.notesTextBox.TabIndex = 333;
            // 
            // lblDateShipped
            // 
            this.lblDateShipped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateShipped.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "DateShipped", true));
            this.lblDateShipped.Location = new System.Drawing.Point(575, 45);
            this.lblDateShipped.Name = "lblDateShipped";
            this.lblDateShipped.Size = new System.Drawing.Size(192, 15);
            this.lblDateShipped.TabIndex = 331;
            // 
            // weightTextBox
            // 
            this.weightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weightTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "Weight", true));
            this.weightTextBox.Location = new System.Drawing.Point(575, 145);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(100, 20);
            this.weightTextBox.TabIndex = 330;
            // 
            // trackingNumberTextBox
            // 
            this.trackingNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackingNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "TrackingNumber", true));
            this.trackingNumberTextBox.Location = new System.Drawing.Point(575, 95);
            this.trackingNumberTextBox.MaxLength = 80000000;
            this.trackingNumberTextBox.Multiline = true;
            this.trackingNumberTextBox.Name = "trackingNumberTextBox";
            this.trackingNumberTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.trackingNumberTextBox.Size = new System.Drawing.Size(247, 44);
            this.trackingNumberTextBox.TabIndex = 328;
            // 
            // orderStatusLabel2
            // 
            this.orderStatusLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.orderStatusLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "TukiosOrderStatus", true));
            this.orderStatusLabel2.Location = new System.Drawing.Point(960, 113);
            this.orderStatusLabel2.Name = "orderStatusLabel2";
            this.orderStatusLabel2.Size = new System.Drawing.Size(216, 29);
            this.orderStatusLabel2.TabIndex = 326;
            // 
            // invnoLabel1
            // 
            this.invnoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "Invno", true));
            this.invnoLabel1.Location = new System.Drawing.Point(960, 91);
            this.invnoLabel1.Name = "invnoLabel1";
            this.invnoLabel1.Size = new System.Drawing.Size(100, 18);
            this.invnoLabel1.TabIndex = 324;
            // 
            // shipZipTextBox
            // 
            this.shipZipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "ShipZip", true));
            this.shipZipTextBox.Location = new System.Drawing.Point(108, 146);
            this.shipZipTextBox.Name = "shipZipTextBox";
            this.shipZipTextBox.Size = new System.Drawing.Size(126, 20);
            this.shipZipTextBox.TabIndex = 321;
            // 
            // shipCityTextBox
            // 
            this.shipCityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "ShipCity", true));
            this.shipCityTextBox.Location = new System.Drawing.Point(108, 96);
            this.shipCityTextBox.Name = "shipCityTextBox";
            this.shipCityTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipCityTextBox.TabIndex = 319;
            // 
            // shipAddrTextBox
            // 
            this.shipAddrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "ShipAddr", true));
            this.shipAddrTextBox.Location = new System.Drawing.Point(108, 44);
            this.shipAddrTextBox.Name = "shipAddrTextBox";
            this.shipAddrTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipAddrTextBox.TabIndex = 318;
            // 
            // shipNameTextBox
            // 
            this.shipNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "ShipName", true));
            this.shipNameTextBox.Location = new System.Drawing.Point(108, 18);
            this.shipNameTextBox.Name = "shipNameTextBox";
            this.shipNameTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipNameTextBox.TabIndex = 317;
            // 
            // schoutDateBox
            // 
            this.schoutDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.schoutDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.tukiosOrderBindingSource, "RequestedShipDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.schoutDateBox.Date = null;
            this.schoutDateBox.DateValue = null;
            this.schoutDateBox.Location = new System.Drawing.Point(575, 18);
            this.schoutDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.schoutDateBox.Name = "schoutDateBox";
            this.schoutDateBox.Size = new System.Drawing.Size(192, 20);
            this.schoutDateBox.TabIndex = 312;
            // 
            // receiveDateLabel1
            // 
            this.receiveDateLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.receiveDateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "OrderReceivedDate", true));
            this.receiveDateLabel1.Location = new System.Drawing.Point(960, 65);
            this.receiveDateLabel1.Name = "receiveDateLabel1";
            this.receiveDateLabel1.Size = new System.Drawing.Size(139, 23);
            this.receiveDateLabel1.TabIndex = 311;
            // 
            // orderIdLabel1
            // 
            this.orderIdLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.orderIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "ClientOrderId", true));
            this.orderIdLabel1.Location = new System.Drawing.Point(960, 18);
            this.orderIdLabel1.Name = "orderIdLabel1";
            this.orderIdLabel1.Size = new System.Drawing.Size(180, 39);
            this.orderIdLabel1.TabIndex = 309;
            // 
            // shipStateComboBox
            // 
            this.shipStateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tukiosOrderBindingSource, "ShipState", true));
            this.shipStateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tukiosOrderBindingSource, "ShipState", true));
            this.shipStateComboBox.DataSource = this.statesBindingSource;
            this.shipStateComboBox.DisplayMember = "Name";
            this.shipStateComboBox.FormattingEnabled = true;
            this.shipStateComboBox.Location = new System.Drawing.Point(108, 122);
            this.shipStateComboBox.Name = "shipStateComboBox";
            this.shipStateComboBox.Size = new System.Drawing.Size(126, 21);
            this.shipStateComboBox.TabIndex = 305;
            this.shipStateComboBox.ValueMember = "Abrev";
            // 
            // reportViewer3
            // 
            this.reportViewer3.DocumentMapWidth = 35;
            this.reportViewer3.LocalReport.EnableExternalImages = true;
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixbookJobTicketSingle.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(0, 443);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(92, 93);
            this.reportViewer3.TabIndex = 10024;
            this.reportViewer3.Visible = false;
            this.reportViewer3.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer3_RenderingComplete);
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
            this.btnDownloadFiles.Location = new System.Drawing.Point(870, 3);
            this.btnDownloadFiles.Name = "btnDownloadFiles";
            this.btnDownloadFiles.Size = new System.Drawing.Size(203, 23);
            this.btnDownloadFiles.TabIndex = 10018;
            this.btnDownloadFiles.Text = "Re - Download Files From Mixbook";
            this.toolTip1.SetToolTip(this.btnDownloadFiles, "Re download files, wait 15 minutes for results.");
            this.btnDownloadFiles.UseVisualStyleBackColor = true;
            this.btnDownloadFiles.Click += new System.EventHandler(this.btnDownloadFiles_Click);
            // 
            // btnRemake
            // 
            this.btnRemake.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemake.Location = new System.Drawing.Point(187, 3);
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
            // bookStatusLabel1
            // 
            this.bookStatusLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bookStatusLabel1.Location = new System.Drawing.Point(792, 682);
            this.bookStatusLabel1.Name = "bookStatusLabel1";
            this.bookStatusLabel1.Size = new System.Drawing.Size(100, 23);
            this.bookStatusLabel1.TabIndex = 10022;
            // 
            // cmdJobTicket
            // 
            this.cmdJobTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdJobTicket.Location = new System.Drawing.Point(358, 3);
            this.cmdJobTicket.Name = "cmdJobTicket";
            this.cmdJobTicket.Size = new System.Drawing.Size(153, 23);
            this.cmdJobTicket.TabIndex = 10023;
            this.cmdJobTicket.Text = "Print Job Ticket";
            this.cmdJobTicket.UseVisualStyleBackColor = true;
            this.cmdJobTicket.Click += new System.EventHandler(this.cmdJobTicket_Click);
            // 
            // btnCvrRemake
            // 
            this.btnCvrRemake.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCvrRemake.Location = new System.Drawing.Point(4, 2);
            this.btnCvrRemake.Name = "btnCvrRemake";
            this.btnCvrRemake.Size = new System.Drawing.Size(85, 23);
            this.btnCvrRemake.TabIndex = 10025;
            this.btnCvrRemake.Text = "Cvr Remake";
            this.btnCvrRemake.UseVisualStyleBackColor = true;
            this.btnCvrRemake.Click += new System.EventHandler(this.btnCvrRemake_Click);
            // 
            // btnBkRemake
            // 
            this.btnBkRemake.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBkRemake.Location = new System.Drawing.Point(93, 2);
            this.btnBkRemake.Name = "btnBkRemake";
            this.btnBkRemake.Size = new System.Drawing.Size(88, 23);
            this.btnBkRemake.TabIndex = 10026;
            this.btnBkRemake.Text = "Bk Remake";
            this.btnBkRemake.UseVisualStyleBackColor = true;
            this.btnBkRemake.Click += new System.EventHandler(this.btnBkRemake_Click);
            // 
            // pnlRemake
            // 
            this.pnlRemake.Controls.Add(this.btnBkRemake);
            this.pnlRemake.Controls.Add(this.btnCvrRemake);
            this.pnlRemake.Location = new System.Drawing.Point(517, 2);
            this.pnlRemake.Name = "pnlRemake";
            this.pnlRemake.Size = new System.Drawing.Size(183, 24);
            this.pnlRemake.TabIndex = 10025;
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
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
            // tukiosOrderBindingNavigatorSaveItem
            // 
            this.tukiosOrderBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tukiosOrderBindingNavigatorSaveItem.Image")));
            this.tukiosOrderBindingNavigatorSaveItem.Name = "tukiosOrderBindingNavigatorSaveItem";
            this.tukiosOrderBindingNavigatorSaveItem.Size = new System.Drawing.Size(54, 22);
            this.tukiosOrderBindingNavigatorSaveItem.Text = "Save ";
            this.tukiosOrderBindingNavigatorSaveItem.Click += new System.EventHandler(this.tukiosOrderBindingNavigatorSaveItem_Click_1);
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
            this.itemIdToolStripBtn.Size = new System.Drawing.Size(57, 22);
            this.itemIdToolStripBtn.Text = "Invno";
            this.itemIdToolStripBtn.Click += new System.EventHandler(this.itemIdToolStripBtn_Click);
            // 
            // purgeStripButton2
            // 
            this.purgeStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("purgeStripButton2.Image")));
            this.purgeStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.purgeStripButton2.Name = "purgeStripButton2";
            this.purgeStripButton2.Size = new System.Drawing.Size(58, 22);
            this.purgeStripButton2.Text = "Purge";
            this.purgeStripButton2.Click += new System.EventHandler(this.purgeStripButton2_Click);
            // 
            // tukiosOrderBindingNavigator
            // 
            this.tukiosOrderBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tukiosOrderBindingNavigator.BindingSource = this.tukiosOrderBindingSource;
            this.tukiosOrderBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tukiosOrderBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tukiosOrderBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.tukiosOrderBindingNavigatorSaveItem,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton1,
            this.itemIdToolStripBtn,
            this.purgeStripButton2});
            this.tukiosOrderBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tukiosOrderBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tukiosOrderBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tukiosOrderBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tukiosOrderBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tukiosOrderBindingNavigator.Name = "tukiosOrderBindingNavigator";
            this.tukiosOrderBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tukiosOrderBindingNavigator.Size = new System.Drawing.Size(1261, 25);
            this.tukiosOrderBindingNavigator.TabIndex = 1;
            this.tukiosOrderBindingNavigator.Text = "bindingNavigator1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton2.Text = "Group Id";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.Controls.Add(this.pnlRemake);
            this.pnlButtons.Controls.Add(this.btnMixbookPkgList);
            this.pnlButtons.Controls.Add(this.btnDownloadFiles);
            this.pnlButtons.Controls.Add(this.btnRemake);
            this.pnlButtons.Controls.Add(this.cmdJobTicket);
            this.pnlButtons.Location = new System.Drawing.Point(101, 300);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1106, 32);
            this.pnlButtons.TabIndex = 10025;
            // 
            // lblCanceled
            // 
            this.lblCanceled.AutoSize = true;
            this.lblCanceled.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCanceled.Font = new System.Drawing.Font("Lucida Sans Unicode", 32F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanceled.ForeColor = System.Drawing.Color.Red;
            this.lblCanceled.Location = new System.Drawing.Point(702, 559);
            this.lblCanceled.Name = "lblCanceled";
            this.lblCanceled.Size = new System.Drawing.Size(221, 53);
            this.lblCanceled.TabIndex = 10026;
            this.lblCanceled.Text = "Canceled";
            this.lblCanceled.Visible = false;
            // 
            // lblHold
            // 
            this.lblHold.AutoSize = true;
            this.lblHold.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblHold.Font = new System.Drawing.Font("Lucida Sans Unicode", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHold.ForeColor = System.Drawing.Color.Red;
            this.lblHold.Location = new System.Drawing.Point(492, 559);
            this.lblHold.Name = "lblHold";
            this.lblHold.Size = new System.Drawing.Size(194, 53);
            this.lblHold.TabIndex = 343;
            this.lblHold.Text = "On Hold";
            this.lblHold.Visible = false;
            // 
            // tukiosOrderTableAdapter
            // 
            this.tukiosOrderTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.TukiosOrderTableAdapter = this.tukiosOrderTableAdapter;
            this.tableAdapterManager1.UpdateOrder = Mbc5.DataSets.TukiosOrdersTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmTKOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1261, 711);
            this.Controls.Add(this.lblHold);
            this.Controls.Add(this.lblCanceled);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.reportViewer3);
            this.Controls.Add(bookStatusLabel);
            this.Controls.Add(this.bookStatusLabel1);
            this.Controls.Add(coverStatusLabel);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.tukiosOrderDataGridView);
            this.Controls.Add(this.tukiosOrderBindingNavigator);
            this.MaxNumForms = 2;
            this.MinimumSize = new System.Drawing.Size(1159, 630);
            this.Name = "frmTKOrders";
            this.Text = "Tukios Orders";
            this.Load += new System.EventHandler(this.frmTKOrders_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.tukiosOrderBindingNavigator, 0);
            this.Controls.SetChildIndex(this.tukiosOrderDataGridView, 0);
            this.Controls.SetChildIndex(this.reportViewer2, 0);
            this.Controls.SetChildIndex(this.pnlOrder, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(coverStatusLabel, 0);
            this.Controls.SetChildIndex(this.bookStatusLabel1, 0);
            this.Controls.SetChildIndex(bookStatusLabel, 0);
            this.Controls.SetChildIndex(this.reportViewer3, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblCanceled, 0);
            this.Controls.SetChildIndex(this.lblHold, 0);
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tukiosOrderDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tukiosOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTukiosOrders)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.pnlRemake.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tukiosOrderBindingNavigator)).EndInit();
            this.tukiosOrderBindingNavigator.ResumeLayout(false);
            this.tukiosOrderBindingNavigator.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.JobTicketQueryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataSets.MixBookOrdersTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView tukiosOrderDataGridView;
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
        private System.Windows.Forms.Label orderStatusLabel2;
        private System.Windows.Forms.Label invnoLabel1;
        private System.Windows.Forms.TextBox shipZipTextBox;
        private System.Windows.Forms.TextBox shipCityTextBox;
        private System.Windows.Forms.TextBox shipAddrTextBox;
        private System.Windows.Forms.TextBox shipNameTextBox;
        private CustomControls.DateBox schoutDateBox;
        private System.Windows.Forms.Label receiveDateLabel1;
        private System.Windows.Forms.Label orderIdLabel1;
        private System.Windows.Forms.ComboBox shipStateComboBox;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDownloadFiles;
        private System.Windows.Forms.Button btnRemake;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label bookStatusLabel1;
        private System.Windows.Forms.TextBox shipAddr2TextBox;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.Button cmdJobTicket;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.Button btnCvrRemake;
        private System.Windows.Forms.Button btnBkRemake;
        private System.Windows.Forms.Panel pnlRemake;
        private System.Windows.Forms.CheckBox orderRePrintCheckBox;
        private System.Windows.Forms.Button btnEmailTrk;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton tukiosOrderBindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton itemIdToolStripBtn;
        private System.Windows.Forms.ToolStripButton purgeStripButton2;
        private System.Windows.Forms.BindingNavigator tukiosOrderBindingNavigator;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Label jobPrintBatchLabel1;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnRemoveOrder;
        private System.Windows.Forms.Label lblCanceled;
        private System.Windows.Forms.Label lblHold;
        private DataSets.TukiosOrders dsTukiosOrders;
        private System.Windows.Forms.BindingSource tukiosOrderBindingSource;
        private DataSets.TukiosOrdersTableAdapters.TukiosOrderTableAdapter tukiosOrderTableAdapter;
        private DataSets.TukiosOrdersTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label requestedShipMethodLabel1;
        private System.Windows.Forms.DataGridViewLinkColumn prodticket;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn copiesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn CoverUrl;
        private System.Windows.Forms.DataGridViewLinkColumn BookUrl;
        private System.Windows.Forms.BindingSource JobTicketQueryBindingSource;
        private System.Windows.Forms.Label groupIdLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}
