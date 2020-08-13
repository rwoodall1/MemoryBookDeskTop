﻿namespace Mbc5.Forms.MixBook
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
            System.Windows.Forms.Label shipNameLabel;
            System.Windows.Forms.Label shipAddrLabel;
            System.Windows.Forms.Label shipAddr2Label;
            System.Windows.Forms.Label shipCityLabel;
            System.Windows.Forms.Label shipStateLabel;
            System.Windows.Forms.Label shipZipLabel;
            System.Windows.Forms.Label phoneNumberLabel;
            System.Windows.Forms.Label orderIdLabel;
            System.Windows.Forms.Label receiveDateLabel;
            System.Windows.Forms.Label shipDateLabel;
            System.Windows.Forms.Label dateShippedLabel;
            System.Windows.Forms.Label shipMethodLabel;
            System.Windows.Forms.Label invnoLabel;
            System.Windows.Forms.Label mixbookOrderStatusLabel;
            System.Windows.Forms.Label trackingNumberLabel;
            System.Windows.Forms.Label weightLabel;
            System.Windows.Forms.Label notesLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMBOrders));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
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
            this.shipStateComboBox = new System.Windows.Forms.ComboBox();
            this.statesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUp = new Mbc5.DataSets.LookUp();
            this.orderIdLabel1 = new System.Windows.Forms.Label();
            this.receiveDateLabel1 = new System.Windows.Forms.Label();
            this.schoutDateBox = new CustomControls.DateBox();
            this.shipMethodComboBox = new System.Windows.Forms.ComboBox();
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
            this.shipNameTextBox = new System.Windows.Forms.TextBox();
            this.shipAddrTextBox = new System.Windows.Forms.TextBox();
            this.shipCityTextBox = new System.Windows.Forms.TextBox();
            this.shipAddr2TextBox = new System.Windows.Forms.TextBox();
            this.shipZipTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.invnoLabel1 = new System.Windows.Forms.Label();
            this.shipCarriersTableAdapter = new Mbc5.DataSets.MixBookOrdersTableAdapters.ShipCarriersTableAdapter();
            this.mixbookOrderStatusLabel2 = new System.Windows.Forms.Label();
            this.trackingNumberTextBox = new System.Windows.Forms.TextBox();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.lblDateShipped = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.btnMixbookPkgList = new System.Windows.Forms.Button();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            shipNameLabel = new System.Windows.Forms.Label();
            shipAddrLabel = new System.Windows.Forms.Label();
            shipAddr2Label = new System.Windows.Forms.Label();
            shipCityLabel = new System.Windows.Forms.Label();
            shipStateLabel = new System.Windows.Forms.Label();
            shipZipLabel = new System.Windows.Forms.Label();
            phoneNumberLabel = new System.Windows.Forms.Label();
            orderIdLabel = new System.Windows.Forms.Label();
            receiveDateLabel = new System.Windows.Forms.Label();
            shipDateLabel = new System.Windows.Forms.Label();
            dateShippedLabel = new System.Windows.Forms.Label();
            shipMethodLabel = new System.Windows.Forms.Label();
            invnoLabel = new System.Windows.Forms.Label();
            mixbookOrderStatusLabel = new System.Windows.Forms.Label();
            trackingNumberLabel = new System.Windows.Forms.Label();
            weightLabel = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsmixBookOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingNavigator)).BeginInit();
            this.mixBookOrderBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipCarriersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Location = new System.Drawing.Point(1121, 12);
            this.basePanel.Size = new System.Drawing.Size(12, 14);
            // 
            // shipNameLabel
            // 
            shipNameLabel.AutoSize = true;
            shipNameLabel.Location = new System.Drawing.Point(71, 52);
            shipNameLabel.Name = "shipNameLabel";
            shipNameLabel.Size = new System.Drawing.Size(79, 13);
            shipNameLabel.TabIndex = 3;
            shipNameLabel.Text = "Shipping Name";
            // 
            // shipAddrLabel
            // 
            shipAddrLabel.AutoSize = true;
            shipAddrLabel.Location = new System.Drawing.Point(61, 78);
            shipAddrLabel.Name = "shipAddrLabel";
            shipAddrLabel.Size = new System.Drawing.Size(89, 13);
            shipAddrLabel.TabIndex = 4;
            shipAddrLabel.Text = "Shipping Address";
            // 
            // shipAddr2Label
            // 
            shipAddr2Label.AutoSize = true;
            shipAddr2Label.Location = new System.Drawing.Point(55, 104);
            shipAddr2Label.Name = "shipAddr2Label";
            shipAddr2Label.Size = new System.Drawing.Size(95, 13);
            shipAddr2Label.TabIndex = 6;
            shipAddr2Label.Text = "Shipping Address2";
            // 
            // shipCityLabel
            // 
            shipCityLabel.AutoSize = true;
            shipCityLabel.Location = new System.Drawing.Point(82, 130);
            shipCityLabel.Name = "shipCityLabel";
            shipCityLabel.Size = new System.Drawing.Size(68, 13);
            shipCityLabel.TabIndex = 8;
            shipCityLabel.Text = "Shipping City";
            // 
            // shipStateLabel
            // 
            shipStateLabel.AutoSize = true;
            shipStateLabel.Location = new System.Drawing.Point(74, 156);
            shipStateLabel.Name = "shipStateLabel";
            shipStateLabel.Size = new System.Drawing.Size(76, 13);
            shipStateLabel.TabIndex = 10;
            shipStateLabel.Text = "Shipping State";
            // 
            // shipZipLabel
            // 
            shipZipLabel.AutoSize = true;
            shipZipLabel.Location = new System.Drawing.Point(84, 183);
            shipZipLabel.Name = "shipZipLabel";
            shipZipLabel.Size = new System.Drawing.Size(66, 13);
            shipZipLabel.TabIndex = 12;
            shipZipLabel.Text = "Shipping Zip";
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new System.Drawing.Point(72, 209);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new System.Drawing.Size(78, 13);
            phoneNumberLabel.TabIndex = 14;
            phoneNumberLabel.Text = "Phone Number";
            // 
            // orderIdLabel
            // 
            orderIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            orderIdLabel.AutoSize = true;
            orderIdLabel.Location = new System.Drawing.Point(820, 52);
            orderIdLabel.Name = "orderIdLabel";
            orderIdLabel.Size = new System.Drawing.Size(45, 13);
            orderIdLabel.TabIndex = 16;
            orderIdLabel.Text = "Order Id";
            // 
            // receiveDateLabel
            // 
            receiveDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            receiveDateLabel.AutoSize = true;
            receiveDateLabel.Location = new System.Drawing.Point(792, 78);
            receiveDateLabel.Name = "receiveDateLabel";
            receiveDateLabel.Size = new System.Drawing.Size(73, 13);
            receiveDateLabel.TabIndex = 18;
            receiveDateLabel.Text = "Receive Date";
            // 
            // shipDateLabel
            // 
            shipDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            shipDateLabel.AutoSize = true;
            shipDateLabel.Location = new System.Drawing.Point(416, 52);
            shipDateLabel.Name = "shipDateLabel";
            shipDateLabel.Size = new System.Drawing.Size(109, 13);
            shipDateLabel.TabIndex = 129;
            shipDateLabel.Text = "Requested Ship Date";
            // 
            // dateShippedLabel
            // 
            dateShippedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateShippedLabel.AutoSize = true;
            dateShippedLabel.Location = new System.Drawing.Point(453, 78);
            dateShippedLabel.Name = "dateShippedLabel";
            dateShippedLabel.Size = new System.Drawing.Size(72, 13);
            dateShippedLabel.TabIndex = 129;
            dateShippedLabel.Text = "Date Shipped";
            // 
            // shipMethodLabel
            // 
            shipMethodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            shipMethodLabel.AutoSize = true;
            shipMethodLabel.Location = new System.Drawing.Point(458, 104);
            shipMethodLabel.Name = "shipMethodLabel";
            shipMethodLabel.Size = new System.Drawing.Size(67, 13);
            shipMethodLabel.TabIndex = 130;
            shipMethodLabel.Text = "Ship Method";
            // 
            // invnoLabel
            // 
            invnoLabel.AutoSize = true;
            invnoLabel.Location = new System.Drawing.Point(803, 104);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(62, 13);
            invnoLabel.TabIndex = 293;
            invnoLabel.Text = "Invoice No.";
            // 
            // mixbookOrderStatusLabel
            // 
            mixbookOrderStatusLabel.AutoSize = true;
            mixbookOrderStatusLabel.Location = new System.Drawing.Point(756, 134);
            mixbookOrderStatusLabel.Name = "mixbookOrderStatusLabel";
            mixbookOrderStatusLabel.Size = new System.Drawing.Size(109, 13);
            mixbookOrderStatusLabel.TabIndex = 294;
            mixbookOrderStatusLabel.Text = "Mixbook Order Status";
            // 
            // trackingNumberLabel
            // 
            trackingNumberLabel.AutoSize = true;
            trackingNumberLabel.Location = new System.Drawing.Point(436, 130);
            trackingNumberLabel.Name = "trackingNumberLabel";
            trackingNumberLabel.Size = new System.Drawing.Size(89, 13);
            trackingNumberLabel.TabIndex = 295;
            trackingNumberLabel.Text = "Tracking Number";
            // 
            // weightLabel
            // 
            weightLabel.AutoSize = true;
            weightLabel.Location = new System.Drawing.Point(484, 156);
            weightLabel.Name = "weightLabel";
            weightLabel.Size = new System.Drawing.Size(41, 13);
            weightLabel.TabIndex = 296;
            weightLabel.Text = "Weight";
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
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new System.Drawing.Point(487, 183);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(38, 13);
            notesLabel.TabIndex = 298;
            notesLabel.Text = "Notes:";
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
            this.itemIdToolStripBtn});
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
            // shipStateComboBox
            // 
            this.shipStateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipState", true));
            this.shipStateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mixBookOrderBindingSource, "ShipState", true));
            this.shipStateComboBox.DataSource = this.statesBindingSource;
            this.shipStateComboBox.DisplayMember = "Name";
            this.shipStateComboBox.FormattingEnabled = true;
            this.shipStateComboBox.Location = new System.Drawing.Point(156, 156);
            this.shipStateComboBox.Name = "shipStateComboBox";
            this.shipStateComboBox.Size = new System.Drawing.Size(126, 21);
            this.shipStateComboBox.TabIndex = 11;
            this.shipStateComboBox.ValueMember = "Abrev";
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
            // orderIdLabel1
            // 
            this.orderIdLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.orderIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ClientOrderId", true));
            this.orderIdLabel1.Location = new System.Drawing.Point(875, 52);
            this.orderIdLabel1.Name = "orderIdLabel1";
            this.orderIdLabel1.Size = new System.Drawing.Size(100, 23);
            this.orderIdLabel1.TabIndex = 17;
            // 
            // receiveDateLabel1
            // 
            this.receiveDateLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.receiveDateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "OrderReceivedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.receiveDateLabel1.Location = new System.Drawing.Point(875, 78);
            this.receiveDateLabel1.Name = "receiveDateLabel1";
            this.receiveDateLabel1.Size = new System.Drawing.Size(139, 23);
            this.receiveDateLabel1.TabIndex = 19;
            // 
            // schoutDateBox
            // 
            this.schoutDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.schoutDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.mixBookOrderBindingSource, "RequestedShipDate", true));
            this.schoutDateBox.Date = null;
            this.schoutDateBox.DateValue = null;
            this.schoutDateBox.Location = new System.Drawing.Point(531, 52);
            this.schoutDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.schoutDateBox.Name = "schoutDateBox";
            this.schoutDateBox.Size = new System.Drawing.Size(192, 20);
            this.schoutDateBox.TabIndex = 129;
            // 
            // shipMethodComboBox
            // 
            this.shipMethodComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shipMethodComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mixBookOrderBindingSource, "ShipMethod", true));
            this.shipMethodComboBox.DataSource = this.shipCarriersBindingSource;
            this.shipMethodComboBox.DisplayMember = "ShipName";
            this.shipMethodComboBox.FormattingEnabled = true;
            this.shipMethodComboBox.Location = new System.Drawing.Point(531, 104);
            this.shipMethodComboBox.Name = "shipMethodComboBox";
            this.shipMethodComboBox.Size = new System.Drawing.Size(227, 21);
            this.shipMethodComboBox.TabIndex = 131;
            this.shipMethodComboBox.ValueMember = "ShipAlias";
            this.shipMethodComboBox.DropDown += new System.EventHandler(this.shipMethodComboBox_DropDown);
            this.shipMethodComboBox.SelectedValueChanged += new System.EventHandler(this.shipMethodComboBox_SelectedValueChanged);
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mixBookOrderDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.Format = "Cover";
            dataGridViewCellStyle8.NullValue = null;
            this.CoverUrl.DefaultCellStyle = dataGridViewCellStyle8;
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
            this.tableAdapterManager1.UpdateOrder = Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // shipNameTextBox
            // 
            this.shipNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipName", true));
            this.shipNameTextBox.Location = new System.Drawing.Point(156, 52);
            this.shipNameTextBox.Name = "shipNameTextBox";
            this.shipNameTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipNameTextBox.TabIndex = 132;
            // 
            // shipAddrTextBox
            // 
            this.shipAddrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipAddr", true));
            this.shipAddrTextBox.Location = new System.Drawing.Point(156, 78);
            this.shipAddrTextBox.Name = "shipAddrTextBox";
            this.shipAddrTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipAddrTextBox.TabIndex = 133;
            // 
            // shipCityTextBox
            // 
            this.shipCityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipCity", true));
            this.shipCityTextBox.Location = new System.Drawing.Point(156, 130);
            this.shipCityTextBox.Name = "shipCityTextBox";
            this.shipCityTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipCityTextBox.TabIndex = 134;
            // 
            // shipAddr2TextBox
            // 
            this.shipAddr2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipAddr2", true));
            this.shipAddr2TextBox.Location = new System.Drawing.Point(156, 104);
            this.shipAddr2TextBox.Name = "shipAddr2TextBox";
            this.shipAddr2TextBox.Size = new System.Drawing.Size(251, 20);
            this.shipAddr2TextBox.TabIndex = 135;
            // 
            // shipZipTextBox
            // 
            this.shipZipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipZip", true));
            this.shipZipTextBox.Location = new System.Drawing.Point(156, 180);
            this.shipZipTextBox.Name = "shipZipTextBox";
            this.shipZipTextBox.Size = new System.Drawing.Size(126, 20);
            this.shipZipTextBox.TabIndex = 136;
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "PhoneNumber", true));
            this.phoneNumberTextBox.Location = new System.Drawing.Point(156, 209);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(126, 20);
            this.phoneNumberTextBox.TabIndex = 137;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 27);
            this.button1.TabIndex = 138;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 45;
            reportDataSource4.Name = "DsOrder";
            reportDataSource4.Value = this.mixBookOrderBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookPkgList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 253);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(76, 95);
            this.reportViewer1.TabIndex = 293;
            this.reportViewer1.Visible = false;
            // 
            // invnoLabel1
            // 
            this.invnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "Invno", true));
            this.invnoLabel1.Location = new System.Drawing.Point(875, 104);
            this.invnoLabel1.Name = "invnoLabel1";
            this.invnoLabel1.Size = new System.Drawing.Size(100, 18);
            this.invnoLabel1.TabIndex = 294;
            // 
            // shipCarriersTableAdapter
            // 
            this.shipCarriersTableAdapter.ClearBeforeFill = true;
            // 
            // mixbookOrderStatusLabel2
            // 
            this.mixbookOrderStatusLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "MixbookOrderStatus", true));
            this.mixbookOrderStatusLabel2.Location = new System.Drawing.Point(875, 134);
            this.mixbookOrderStatusLabel2.Name = "mixbookOrderStatusLabel2";
            this.mixbookOrderStatusLabel2.Size = new System.Drawing.Size(228, 29);
            this.mixbookOrderStatusLabel2.TabIndex = 295;
            // 
            // trackingNumberTextBox
            // 
            this.trackingNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "TrackingNumber", true));
            this.trackingNumberTextBox.Location = new System.Drawing.Point(531, 130);
            this.trackingNumberTextBox.Name = "trackingNumberTextBox";
            this.trackingNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.trackingNumberTextBox.TabIndex = 296;
            // 
            // weightTextBox
            // 
            this.weightTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "Weight", true));
            this.weightTextBox.Location = new System.Drawing.Point(531, 156);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(100, 20);
            this.weightTextBox.TabIndex = 297;
            // 
            // lblDateShipped
            // 
            this.lblDateShipped.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "DateShipped", true));
            this.lblDateShipped.Location = new System.Drawing.Point(531, 78);
            this.lblDateShipped.Name = "lblDateShipped";
            this.lblDateShipped.Size = new System.Drawing.Size(192, 23);
            this.lblDateShipped.TabIndex = 298;
            // 
            // notesTextBox
            // 
            this.notesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "Notes", true));
            this.notesTextBox.Location = new System.Drawing.Point(531, 180);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(334, 49);
            this.notesTextBox.TabIndex = 299;
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
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookPkgList.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(9, 373);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(67, 46);
            this.reportViewer2.TabIndex = 10015;
            this.reportViewer2.Visible = false;
            this.reportViewer2.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer2_RenderingComplete);
            // 
            // frmMBOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1153, 591);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.btnMixbookPkgList);
            this.Controls.Add(notesLabel);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.lblDateShipped);
            this.Controls.Add(weightLabel);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(trackingNumberLabel);
            this.Controls.Add(this.trackingNumberTextBox);
            this.Controls.Add(this.mixbookOrderStatusLabel2);
            this.Controls.Add(mixbookOrderStatusLabel);
            this.Controls.Add(invnoLabel);
            this.Controls.Add(this.invnoLabel1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(this.shipZipTextBox);
            this.Controls.Add(this.shipAddr2TextBox);
            this.Controls.Add(this.shipCityTextBox);
            this.Controls.Add(this.shipAddrTextBox);
            this.Controls.Add(this.shipNameTextBox);
            this.Controls.Add(this.mixBookOrderDataGridView);
            this.Controls.Add(shipMethodLabel);
            this.Controls.Add(this.shipMethodComboBox);
            this.Controls.Add(dateShippedLabel);
            this.Controls.Add(shipDateLabel);
            this.Controls.Add(this.schoutDateBox);
            this.Controls.Add(receiveDateLabel);
            this.Controls.Add(this.receiveDateLabel1);
            this.Controls.Add(orderIdLabel);
            this.Controls.Add(this.orderIdLabel1);
            this.Controls.Add(phoneNumberLabel);
            this.Controls.Add(shipZipLabel);
            this.Controls.Add(shipStateLabel);
            this.Controls.Add(this.shipStateComboBox);
            this.Controls.Add(shipCityLabel);
            this.Controls.Add(shipAddr2Label);
            this.Controls.Add(shipAddrLabel);
            this.Controls.Add(shipNameLabel);
            this.Controls.Add(this.mixBookOrderBindingNavigator);
            this.MinimumSize = new System.Drawing.Size(1000, 630);
            this.Name = "frmMBOrders";
            this.Text = "Mix Book Cust/Orders";
            this.Load += new System.EventHandler(this.MBOrders_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.mixBookOrderBindingNavigator, 0);
            this.Controls.SetChildIndex(shipNameLabel, 0);
            this.Controls.SetChildIndex(shipAddrLabel, 0);
            this.Controls.SetChildIndex(shipAddr2Label, 0);
            this.Controls.SetChildIndex(shipCityLabel, 0);
            this.Controls.SetChildIndex(this.shipStateComboBox, 0);
            this.Controls.SetChildIndex(shipStateLabel, 0);
            this.Controls.SetChildIndex(shipZipLabel, 0);
            this.Controls.SetChildIndex(phoneNumberLabel, 0);
            this.Controls.SetChildIndex(this.orderIdLabel1, 0);
            this.Controls.SetChildIndex(orderIdLabel, 0);
            this.Controls.SetChildIndex(this.receiveDateLabel1, 0);
            this.Controls.SetChildIndex(receiveDateLabel, 0);
            this.Controls.SetChildIndex(this.schoutDateBox, 0);
            this.Controls.SetChildIndex(shipDateLabel, 0);
            this.Controls.SetChildIndex(dateShippedLabel, 0);
            this.Controls.SetChildIndex(this.shipMethodComboBox, 0);
            this.Controls.SetChildIndex(shipMethodLabel, 0);
            this.Controls.SetChildIndex(this.mixBookOrderDataGridView, 0);
            this.Controls.SetChildIndex(this.shipNameTextBox, 0);
            this.Controls.SetChildIndex(this.shipAddrTextBox, 0);
            this.Controls.SetChildIndex(this.shipCityTextBox, 0);
            this.Controls.SetChildIndex(this.shipAddr2TextBox, 0);
            this.Controls.SetChildIndex(this.shipZipTextBox, 0);
            this.Controls.SetChildIndex(this.phoneNumberTextBox, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.invnoLabel1, 0);
            this.Controls.SetChildIndex(invnoLabel, 0);
            this.Controls.SetChildIndex(mixbookOrderStatusLabel, 0);
            this.Controls.SetChildIndex(this.mixbookOrderStatusLabel2, 0);
            this.Controls.SetChildIndex(this.trackingNumberTextBox, 0);
            this.Controls.SetChildIndex(trackingNumberLabel, 0);
            this.Controls.SetChildIndex(this.weightTextBox, 0);
            this.Controls.SetChildIndex(weightLabel, 0);
            this.Controls.SetChildIndex(this.lblDateShipped, 0);
            this.Controls.SetChildIndex(this.notesTextBox, 0);
            this.Controls.SetChildIndex(notesLabel, 0);
            this.Controls.SetChildIndex(this.btnMixbookPkgList, 0);
            this.Controls.SetChildIndex(this.reportViewer2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsmixBookOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingNavigator)).EndInit();
            this.mixBookOrderBindingNavigator.ResumeLayout(false);
            this.mixBookOrderBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipCarriersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderDataGridView)).EndInit();
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
        private System.Windows.Forms.ComboBox shipStateComboBox;
        private System.Windows.Forms.Label orderIdLabel1;
        private System.Windows.Forms.Label receiveDateLabel1;
        private CustomControls.DateBox schoutDateBox;
        private System.Windows.Forms.ComboBox shipMethodComboBox;
        private System.Windows.Forms.DataGridView mixBookOrderDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataSets.LookUp lookUp;
        private System.Windows.Forms.BindingSource statesBindingSource;
        private DataSets.LookUpTableAdapters.statesTableAdapter statesTableAdapter;
        private DataSets.LookUpTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.TextBox shipNameTextBox;
        private System.Windows.Forms.TextBox shipAddrTextBox;
        private System.Windows.Forms.TextBox shipCityTextBox;
        private System.Windows.Forms.TextBox shipAddr2TextBox;
        private System.Windows.Forms.TextBox shipZipTextBox;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label invnoLabel1;
        private System.Windows.Forms.BindingSource shipCarriersBindingSource;
        private DataSets.MixBookOrdersTableAdapters.ShipCarriersTableAdapter shipCarriersTableAdapter;
        private System.Windows.Forms.Label mixbookOrderStatusLabel2;
        private System.Windows.Forms.TextBox trackingNumberTextBox;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.Label lblDateShipped;
        private System.Windows.Forms.ToolStripButton itemIdToolStripBtn;
        private System.Windows.Forms.DataGridViewLinkColumn prodticket;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewLinkColumn CoverUrl;
        private System.Windows.Forms.DataGridViewLinkColumn BookUrl;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Button btnMixbookPkgList;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}
