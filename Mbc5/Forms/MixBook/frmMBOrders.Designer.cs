namespace Mbc5.Forms.MixBook
{
    partial class frmMBOrders
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
            System.Windows.Forms.Label mixbookOrderStatusLabel;
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
            System.Windows.Forms.Label coverStatusLabel;
            System.Windows.Forms.Label bookStatusLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMBOrders));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.MixbookPackingSlipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MixbookRemakeTicketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mixBookOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsmixBookOrders = new Mbc5.DataSets.MixBookOrders();
            this.mixBookOrderTableAdapter = new Mbc5.DataSets.MixBookOrdersTableAdapters.MixBookOrderTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.MixBookOrdersTableAdapters.TableAdapterManager();
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
            this.mixBookOrderBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.mixBookOrderBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.itemIdToolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.purgeStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.statesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUp = new Mbc5.DataSets.LookUp();
            this.shipCarriersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mixBookOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.prodticket = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoverUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            this.BookUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            this.statesTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.statesTableAdapter();
            this.tableAdapterManager1 = new Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager();
            this.shipCarriersTableAdapter = new Mbc5.DataSets.MixBookOrdersTableAdapters.ShipCarriersTableAdapter();
            this.btnMixbookPkgList = new System.Windows.Forms.Button();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.lblDateShipped = new System.Windows.Forms.Label();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.trackingNumberTextBox = new System.Windows.Forms.TextBox();
            this.mixbookOrderStatusLabel2 = new System.Windows.Forms.Label();
            this.invnoLabel1 = new System.Windows.Forms.Label();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.shipZipTextBox = new System.Windows.Forms.TextBox();
            this.shipAddr2TextBox = new System.Windows.Forms.TextBox();
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
            this.MixbookRemakeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coverStatusLabel1 = new System.Windows.Forms.Label();
            this.bookStatusLabel1 = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            weightLabel = new System.Windows.Forms.Label();
            trackingNumberLabel = new System.Windows.Forms.Label();
            mixbookOrderStatusLabel = new System.Windows.Forms.Label();
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
            coverStatusLabel = new System.Windows.Forms.Label();
            bookStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MixbookPackingSlipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixbookRemakeTicketBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsmixBookOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingNavigator)).BeginInit();
            this.mixBookOrderBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipCarriersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderDataGridView)).BeginInit();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MixbookRemakeBindingSource)).BeginInit();
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
            notesLabel.Location = new System.Drawing.Point(460, 149);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(38, 13);
            notesLabel.TabIndex = 332;
            notesLabel.Text = "Notes:";
            // 
            // weightLabel
            // 
            weightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            weightLabel.AutoSize = true;
            weightLabel.Location = new System.Drawing.Point(457, 122);
            weightLabel.Name = "weightLabel";
            weightLabel.Size = new System.Drawing.Size(41, 13);
            weightLabel.TabIndex = 329;
            weightLabel.Text = "Weight";
            // 
            // trackingNumberLabel
            // 
            trackingNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            trackingNumberLabel.AutoSize = true;
            trackingNumberLabel.Location = new System.Drawing.Point(409, 96);
            trackingNumberLabel.Name = "trackingNumberLabel";
            trackingNumberLabel.Size = new System.Drawing.Size(89, 13);
            trackingNumberLabel.TabIndex = 327;
            trackingNumberLabel.Text = "Tracking Number";
            // 
            // mixbookOrderStatusLabel
            // 
            mixbookOrderStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            mixbookOrderStatusLabel.AutoSize = true;
            mixbookOrderStatusLabel.Location = new System.Drawing.Point(736, 100);
            mixbookOrderStatusLabel.Name = "mixbookOrderStatusLabel";
            mixbookOrderStatusLabel.Size = new System.Drawing.Size(109, 13);
            mixbookOrderStatusLabel.TabIndex = 325;
            mixbookOrderStatusLabel.Text = "Mixbook Order Status";
            // 
            // invnoLabel
            // 
            invnoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            invnoLabel.AutoSize = true;
            invnoLabel.Location = new System.Drawing.Point(783, 70);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(62, 13);
            invnoLabel.TabIndex = 323;
            invnoLabel.Text = "Invoice No.";
            // 
            // shipMethodLabel
            // 
            shipMethodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            shipMethodLabel.AutoSize = true;
            shipMethodLabel.Location = new System.Drawing.Point(431, 70);
            shipMethodLabel.Name = "shipMethodLabel";
            shipMethodLabel.Size = new System.Drawing.Size(67, 13);
            shipMethodLabel.TabIndex = 315;
            shipMethodLabel.Text = "Ship Method";
            // 
            // dateShippedLabel
            // 
            dateShippedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateShippedLabel.AutoSize = true;
            dateShippedLabel.Location = new System.Drawing.Point(426, 44);
            dateShippedLabel.Name = "dateShippedLabel";
            dateShippedLabel.Size = new System.Drawing.Size(72, 13);
            dateShippedLabel.TabIndex = 314;
            dateShippedLabel.Text = "Date Shipped";
            // 
            // shipDateLabel
            // 
            shipDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            shipDateLabel.AutoSize = true;
            shipDateLabel.Location = new System.Drawing.Point(389, 18);
            shipDateLabel.Name = "shipDateLabel";
            shipDateLabel.Size = new System.Drawing.Size(109, 13);
            shipDateLabel.TabIndex = 313;
            shipDateLabel.Text = "Requested Ship Date";
            // 
            // receiveDateLabel
            // 
            receiveDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            receiveDateLabel.AutoSize = true;
            receiveDateLabel.Location = new System.Drawing.Point(772, 44);
            receiveDateLabel.Name = "receiveDateLabel";
            receiveDateLabel.Size = new System.Drawing.Size(73, 13);
            receiveDateLabel.TabIndex = 310;
            receiveDateLabel.Text = "Receive Date";
            // 
            // orderIdLabel
            // 
            orderIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            orderIdLabel.AutoSize = true;
            orderIdLabel.Location = new System.Drawing.Point(800, 18);
            orderIdLabel.Name = "orderIdLabel";
            orderIdLabel.Size = new System.Drawing.Size(45, 13);
            orderIdLabel.TabIndex = 308;
            orderIdLabel.Text = "Order Id";
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
            // MixbookPackingSlipBindingSource
            // 
            this.MixbookPackingSlipBindingSource.DataSource = typeof(BindingModels.MixbookPackingSlip);
            // 
            // MixbookRemakeTicketBindingSource
            // 
            this.MixbookRemakeTicketBindingSource.DataSource = typeof(BindingModels.MixbookRemakeTicket);
            // 
            // coverStatusLabel
            // 
            coverStatusLabel.AutoSize = true;
            coverStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            coverStatusLabel.Location = new System.Drawing.Point(95, 505);
            coverStatusLabel.Name = "coverStatusLabel";
            coverStatusLabel.Size = new System.Drawing.Size(84, 13);
            coverStatusLabel.TabIndex = 10020;
            coverStatusLabel.Text = "Cover Status:";
            // 
            // bookStatusLabel
            // 
            bookStatusLabel.AutoSize = true;
            bookStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            bookStatusLabel.Location = new System.Drawing.Point(709, 505);
            bookStatusLabel.Name = "bookStatusLabel";
            bookStatusLabel.Size = new System.Drawing.Size(80, 13);
            bookStatusLabel.TabIndex = 10021;
            bookStatusLabel.Text = "Book Status:";
            // 
            // mixBookOrderBindingSource
            // 
            this.mixBookOrderBindingSource.DataMember = "MixBookOrder";
            this.mixBookOrderBindingSource.DataSource = this.dsmixBookOrders;
            this.mixBookOrderBindingSource.PositionChanged += new System.EventHandler(this.mixBookOrderBindingSource_PositionChanged);
            // 
            // dsmixBookOrders
            // 
            this.dsmixBookOrders.DataSetName = "MixBookOrders";
            this.dsmixBookOrders.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mixBookOrderTableAdapter
            // 
            this.mixBookOrderTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.MixBookOrderTableAdapter = this.mixBookOrderTableAdapter;
            this.tableAdapterManager.ShipCarriersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.MixBookOrdersTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
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
            // mixBookOrderBindingNavigatorSaveItem
            // 
            this.mixBookOrderBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("mixBookOrderBindingNavigatorSaveItem.Image")));
            this.mixBookOrderBindingNavigatorSaveItem.Name = "mixBookOrderBindingNavigatorSaveItem";
            this.mixBookOrderBindingNavigatorSaveItem.Size = new System.Drawing.Size(54, 22);
            this.mixBookOrderBindingNavigatorSaveItem.Text = "Save ";
            this.mixBookOrderBindingNavigatorSaveItem.Click += new System.EventHandler(this.mixBookOrderBindingNavigatorSaveItem_Click);
            // 
            // mixBookOrderBindingNavigator
            // 
            this.mixBookOrderBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.mixBookOrderBindingNavigator.BindingSource = this.mixBookOrderBindingSource;
            this.mixBookOrderBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.mixBookOrderBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.mixBookOrderBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.mixBookOrderBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.mixBookOrderBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.mixBookOrderBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.mixBookOrderBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.mixBookOrderBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.mixBookOrderBindingNavigator.Name = "mixBookOrderBindingNavigator";
            this.mixBookOrderBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.mixBookOrderBindingNavigator.Size = new System.Drawing.Size(1153, 25);
            this.mixBookOrderBindingNavigator.TabIndex = 1;
            this.mixBookOrderBindingNavigator.Text = "bindingNavigator1";
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
            // shipCarriersBindingSource
            // 
            this.shipCarriersBindingSource.DataMember = "ShipCarriers";
            this.shipCarriersBindingSource.DataSource = this.dsmixBookOrders;
            // 
            // mixBookOrderDataGridView
            // 
            this.mixBookOrderDataGridView.AllowUserToAddRows = false;
            this.mixBookOrderDataGridView.AllowUserToDeleteRows = false;
            this.mixBookOrderDataGridView.AllowUserToOrderColumns = true;
            this.mixBookOrderDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mixBookOrderDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mixBookOrderDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mixBookOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mixBookOrderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prodticket,
            this.dataGridViewTextBoxColumn1,
            this.ItemId,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.CoverUrl,
            this.BookUrl});
            this.mixBookOrderDataGridView.DataSource = this.mixBookOrderBindingSource;
            this.mixBookOrderDataGridView.EnableHeadersVisualStyles = false;
            this.mixBookOrderDataGridView.Location = new System.Drawing.Point(85, 272);
            this.mixBookOrderDataGridView.Name = "mixBookOrderDataGridView";
            this.mixBookOrderDataGridView.ReadOnly = true;
            this.mixBookOrderDataGridView.RowHeadersWidth = 20;
            this.mixBookOrderDataGridView.Size = new System.Drawing.Size(1014, 220);
            this.mixBookOrderDataGridView.TabIndex = 131;
            this.mixBookOrderDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mixBookOrderDataGridView_CellContentClick);
            this.mixBookOrderDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mixBookOrderDataGridView_CellContentDoubleClick);
            this.mixBookOrderDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.mixBookOrderDataGridView_CellFormatting);
            this.mixBookOrderDataGridView.Enter += new System.EventHandler(this.mixBookOrderDataGridView_Enter);
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
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.HeaderText = "Item Id";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn5.FillWeight = 88.02047F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Description";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Copies";
            this.dataGridViewTextBoxColumn7.FillWeight = 109.035F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Copies";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Pages";
            this.dataGridViewTextBoxColumn8.FillWeight = 126.9036F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Pages";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // CoverUrl
            // 
            this.CoverUrl.DataPropertyName = "CoverPreviewUrl";
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
            this.BookUrl.DataPropertyName = "BookPreviewUrl";
            this.BookUrl.HeaderText = "Book Url";
            this.BookUrl.Name = "BookUrl";
            this.BookUrl.ReadOnly = true;
            this.BookUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BookUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BookUrl.Text = "";
            // 
            // statesTableAdapter
            // 
            this.statesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.contpstnTableAdapter = null;
            this.tableAdapterManager1.lkpBackGroundTableAdapter = null;
            this.tableAdapterManager1.lkpCommentsTableAdapter = null;
            this.tableAdapterManager1.lkpCoverStockTableAdapter = null;
            this.tableAdapterManager1.lkpCustTypeTableAdapter = null;
            this.tableAdapterManager1.lkpDiscountTableAdapter = null;
            this.tableAdapterManager1.lkpJosNameTableAdapter = null;
            this.tableAdapterManager1.lkpLeadNameTableAdapter = null;
            this.tableAdapterManager1.lkpLeadSourceTableAdapter = null;
            this.tableAdapterManager1.lkpMascotTableAdapter = null;
            this.tableAdapterManager1.lkpMktReferenceTableAdapter = null;
            this.tableAdapterManager1.lkpMultiYearOptionsTableAdapter = null;
            this.tableAdapterManager1.lkpNoRebookTableAdapter = null;
            this.tableAdapterManager1.lkpPrevPubTableAdapter = null;
            this.tableAdapterManager1.lkpPromotionsTableAdapter = null;
            this.tableAdapterManager1.lkpschtypeTableAdapter = null;
            this.tableAdapterManager1.lkpSupplyItemsTableAdapter = null;
            this.tableAdapterManager1.lkpTypeContTableAdapter = null;
            this.tableAdapterManager1.lkTypeDataTableAdapter = null;
            this.tableAdapterManager1.MeridianProductsTableAdapter = null;
            this.tableAdapterManager1.RemakeReasonsTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // shipCarriersTableAdapter
            // 
            this.shipCarriersTableAdapter.ClearBeforeFill = true;
            // 
            // btnMixbookPkgList
            // 
            this.btnMixbookPkgList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMixbookPkgList.Location = new System.Drawing.Point(85, 244);
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
            reportDataSource1.Name = "dsMxPackingSlip";
            reportDataSource1.Value = this.MixbookPackingSlipBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookPkgList.rdlc";
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
            this.pnlOrder.Controls.Add(notesLabel);
            this.pnlOrder.Controls.Add(this.notesTextBox);
            this.pnlOrder.Controls.Add(this.lblDateShipped);
            this.pnlOrder.Controls.Add(weightLabel);
            this.pnlOrder.Controls.Add(this.weightTextBox);
            this.pnlOrder.Controls.Add(trackingNumberLabel);
            this.pnlOrder.Controls.Add(this.trackingNumberTextBox);
            this.pnlOrder.Controls.Add(this.mixbookOrderStatusLabel2);
            this.pnlOrder.Controls.Add(mixbookOrderStatusLabel);
            this.pnlOrder.Controls.Add(invnoLabel);
            this.pnlOrder.Controls.Add(this.invnoLabel1);
            this.pnlOrder.Controls.Add(this.phoneNumberTextBox);
            this.pnlOrder.Controls.Add(this.shipZipTextBox);
            this.pnlOrder.Controls.Add(this.shipAddr2TextBox);
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
            this.pnlOrder.Location = new System.Drawing.Point(47, 28);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1079, 212);
            this.pnlOrder.TabIndex = 10016;
            // 
            // notesTextBox
            // 
            this.notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "Notes", true));
            this.notesTextBox.Location = new System.Drawing.Point(504, 146);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(334, 49);
            this.notesTextBox.TabIndex = 333;
            // 
            // lblDateShipped
            // 
            this.lblDateShipped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateShipped.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "DateShipped", true));
            this.lblDateShipped.Location = new System.Drawing.Point(504, 44);
            this.lblDateShipped.Name = "lblDateShipped";
            this.lblDateShipped.Size = new System.Drawing.Size(192, 23);
            this.lblDateShipped.TabIndex = 331;
            // 
            // weightTextBox
            // 
            this.weightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weightTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "Weight", true));
            this.weightTextBox.Location = new System.Drawing.Point(504, 122);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(100, 20);
            this.weightTextBox.TabIndex = 330;
            // 
            // trackingNumberTextBox
            // 
            this.trackingNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackingNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "TrackingNumber", true));
            this.trackingNumberTextBox.Location = new System.Drawing.Point(504, 96);
            this.trackingNumberTextBox.Name = "trackingNumberTextBox";
            this.trackingNumberTextBox.Size = new System.Drawing.Size(226, 20);
            this.trackingNumberTextBox.TabIndex = 328;
            // 
            // mixbookOrderStatusLabel2
            // 
            this.mixbookOrderStatusLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mixbookOrderStatusLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "MixbookOrderStatus", true));
            this.mixbookOrderStatusLabel2.Location = new System.Drawing.Point(855, 100);
            this.mixbookOrderStatusLabel2.Name = "mixbookOrderStatusLabel2";
            this.mixbookOrderStatusLabel2.Size = new System.Drawing.Size(216, 29);
            this.mixbookOrderStatusLabel2.TabIndex = 326;
            // 
            // invnoLabel1
            // 
            this.invnoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "Invno", true));
            this.invnoLabel1.Location = new System.Drawing.Point(855, 70);
            this.invnoLabel1.Name = "invnoLabel1";
            this.invnoLabel1.Size = new System.Drawing.Size(100, 18);
            this.invnoLabel1.TabIndex = 324;
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "PhoneNumber", true));
            this.phoneNumberTextBox.Location = new System.Drawing.Point(108, 175);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(126, 20);
            this.phoneNumberTextBox.TabIndex = 322;
            // 
            // shipZipTextBox
            // 
            this.shipZipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipZip", true));
            this.shipZipTextBox.Location = new System.Drawing.Point(108, 146);
            this.shipZipTextBox.Name = "shipZipTextBox";
            this.shipZipTextBox.Size = new System.Drawing.Size(126, 20);
            this.shipZipTextBox.TabIndex = 321;
            // 
            // shipAddr2TextBox
            // 
            this.shipAddr2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipAddr2", true));
            this.shipAddr2TextBox.Location = new System.Drawing.Point(108, 70);
            this.shipAddr2TextBox.Name = "shipAddr2TextBox";
            this.shipAddr2TextBox.Size = new System.Drawing.Size(251, 20);
            this.shipAddr2TextBox.TabIndex = 320;
            // 
            // shipCityTextBox
            // 
            this.shipCityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipCity", true));
            this.shipCityTextBox.Location = new System.Drawing.Point(108, 96);
            this.shipCityTextBox.Name = "shipCityTextBox";
            this.shipCityTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipCityTextBox.TabIndex = 319;
            // 
            // shipAddrTextBox
            // 
            this.shipAddrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipAddr", true));
            this.shipAddrTextBox.Location = new System.Drawing.Point(108, 44);
            this.shipAddrTextBox.Name = "shipAddrTextBox";
            this.shipAddrTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipAddrTextBox.TabIndex = 318;
            // 
            // shipNameTextBox
            // 
            this.shipNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipName", true));
            this.shipNameTextBox.Location = new System.Drawing.Point(108, 18);
            this.shipNameTextBox.Name = "shipNameTextBox";
            this.shipNameTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipNameTextBox.TabIndex = 317;
            // 
            // shipMethodComboBox
            // 
            this.shipMethodComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shipMethodComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mixBookOrderBindingSource, "ShipMethod", true));
            this.shipMethodComboBox.DataSource = this.shipCarriersBindingSource;
            this.shipMethodComboBox.DisplayMember = "ShipName";
            this.shipMethodComboBox.FormattingEnabled = true;
            this.shipMethodComboBox.Location = new System.Drawing.Point(504, 70);
            this.shipMethodComboBox.Name = "shipMethodComboBox";
            this.shipMethodComboBox.Size = new System.Drawing.Size(227, 21);
            this.shipMethodComboBox.TabIndex = 316;
            this.shipMethodComboBox.ValueMember = "ShipAlias";
            // 
            // schoutDateBox
            // 
            this.schoutDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.schoutDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.mixBookOrderBindingSource, "RequestedShipDate", true));
            this.schoutDateBox.Date = null;
            this.schoutDateBox.DateValue = null;
            this.schoutDateBox.Location = new System.Drawing.Point(504, 18);
            this.schoutDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.schoutDateBox.Name = "schoutDateBox";
            this.schoutDateBox.Size = new System.Drawing.Size(192, 20);
            this.schoutDateBox.TabIndex = 312;
            // 
            // receiveDateLabel1
            // 
            this.receiveDateLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.receiveDateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "OrderReceivedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.receiveDateLabel1.Location = new System.Drawing.Point(855, 44);
            this.receiveDateLabel1.Name = "receiveDateLabel1";
            this.receiveDateLabel1.Size = new System.Drawing.Size(139, 23);
            this.receiveDateLabel1.TabIndex = 311;
            // 
            // orderIdLabel1
            // 
            this.orderIdLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.orderIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ClientOrderId", true));
            this.orderIdLabel1.Location = new System.Drawing.Point(855, 18);
            this.orderIdLabel1.Name = "orderIdLabel1";
            this.orderIdLabel1.Size = new System.Drawing.Size(100, 23);
            this.orderIdLabel1.TabIndex = 309;
            // 
            // shipStateComboBox
            // 
            this.shipStateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipState", true));
            this.shipStateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mixBookOrderBindingSource, "ShipState", true));
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
            this.btnDownloadFiles.Location = new System.Drawing.Point(863, 244);
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
            this.btnRemake.Location = new System.Drawing.Point(248, 244);
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
            reportDataSource2.Value = this.MixbookPackingSlipBindingSource;
            reportDataSource3.Name = "dsMixBookRemakeTkt";
            reportDataSource3.Value = this.MixbookRemakeTicketBindingSource;
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
            // MixbookRemakeBindingSource
            // 
            this.MixbookRemakeBindingSource.DataSource = typeof(BindingModels.MixbookRemakeTicket);
            // 
            // coverStatusLabel1
            // 
            this.coverStatusLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "CoverStatus", true));
            this.coverStatusLabel1.Location = new System.Drawing.Point(180, 505);
            this.coverStatusLabel1.Name = "coverStatusLabel1";
            this.coverStatusLabel1.Size = new System.Drawing.Size(100, 23);
            this.coverStatusLabel1.TabIndex = 10021;
            // 
            // bookStatusLabel1
            // 
            this.bookStatusLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "BookStatus", true));
            this.bookStatusLabel1.Location = new System.Drawing.Point(792, 505);
            this.bookStatusLabel1.Name = "bookStatusLabel1";
            this.bookStatusLabel1.Size = new System.Drawing.Size(100, 23);
            this.bookStatusLabel1.TabIndex = 10022;
            // 
            // frmMBOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1153, 591);
            this.Controls.Add(bookStatusLabel);
            this.Controls.Add(this.bookStatusLabel1);
            this.Controls.Add(coverStatusLabel);
            this.Controls.Add(this.coverStatusLabel1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnRemake);
            this.Controls.Add(this.btnDownloadFiles);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.btnMixbookPkgList);
            this.Controls.Add(this.mixBookOrderDataGridView);
            this.Controls.Add(this.mixBookOrderBindingNavigator);
            this.MinimumSize = new System.Drawing.Size(1159, 630);
            this.Name = "frmMBOrders";
            this.Text = "Mix Book Cust/Orders";
            this.Load += new System.EventHandler(this.MBOrders_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.mixBookOrderBindingNavigator, 0);
            this.Controls.SetChildIndex(this.mixBookOrderDataGridView, 0);
            this.Controls.SetChildIndex(this.btnMixbookPkgList, 0);
            this.Controls.SetChildIndex(this.reportViewer2, 0);
            this.Controls.SetChildIndex(this.pnlOrder, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDownloadFiles, 0);
            this.Controls.SetChildIndex(this.btnRemake, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.coverStatusLabel1, 0);
            this.Controls.SetChildIndex(coverStatusLabel, 0);
            this.Controls.SetChildIndex(this.bookStatusLabel1, 0);
            this.Controls.SetChildIndex(bookStatusLabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.MixbookPackingSlipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MixbookRemakeTicketBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsmixBookOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingNavigator)).EndInit();
            this.mixBookOrderBindingNavigator.ResumeLayout(false);
            this.mixBookOrderBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipCarriersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderDataGridView)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MixbookRemakeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSets.MixBookOrders dsmixBookOrders;
        private System.Windows.Forms.BindingSource mixBookOrderBindingSource;
        private DataSets.MixBookOrdersTableAdapters.MixBookOrderTableAdapter mixBookOrderTableAdapter;
        private DataSets.MixBookOrdersTableAdapters.TableAdapterManager tableAdapterManager;
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
        private System.Windows.Forms.ToolStripButton mixBookOrderBindingNavigatorSaveItem;
        private System.Windows.Forms.BindingNavigator mixBookOrderBindingNavigator;
        private System.Windows.Forms.DataGridView mixBookOrderDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataSets.LookUp lookUp;
        private System.Windows.Forms.BindingSource statesBindingSource;
        private DataSets.LookUpTableAdapters.statesTableAdapter statesTableAdapter;
        private DataSets.LookUpTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.BindingSource shipCarriersBindingSource;
        private DataSets.MixBookOrdersTableAdapters.ShipCarriersTableAdapter shipCarriersTableAdapter;
        private System.Windows.Forms.ToolStripButton itemIdToolStripBtn;
        private System.Windows.Forms.DataGridViewLinkColumn prodticket;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewLinkColumn CoverUrl;
        private System.Windows.Forms.DataGridViewLinkColumn BookUrl;
        private System.Windows.Forms.Button btnMixbookPkgList;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label lblDateShipped;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.TextBox trackingNumberTextBox;
        private System.Windows.Forms.Label mixbookOrderStatusLabel2;
        private System.Windows.Forms.Label invnoLabel1;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.TextBox shipZipTextBox;
        private System.Windows.Forms.TextBox shipAddr2TextBox;
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
        private System.Windows.Forms.BindingSource MixbookPackingSlipBindingSource;
        private System.Windows.Forms.BindingSource MixbookRemakeBindingSource;
        private System.Windows.Forms.BindingSource MixbookRemakeTicketBindingSource;
        private System.Windows.Forms.ToolStripButton purgeStripButton2;
        private System.Windows.Forms.Label coverStatusLabel1;
        private System.Windows.Forms.Label bookStatusLabel1;
    }
}
