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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMBOrders));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dsmixBookOrders = new Mbc5.DataSets.MixBookOrders();
            this.mixBookOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mixBookOrderTableAdapter = new Mbc5.DataSets.MixBookOrdersTableAdapters.MixBookOrderTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.MixBookOrdersTableAdapters.TableAdapterManager();
            this.shipNameTextBox = new System.Windows.Forms.TextBox();
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
            this.shipAddrTextBox = new System.Windows.Forms.TextBox();
            this.shipAddr2TextBox = new System.Windows.Forms.TextBox();
            this.shipCityTextBox = new System.Windows.Forms.TextBox();
            this.shipStateComboBox = new System.Windows.Forms.ComboBox();
            this.statesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUp = new Mbc5.DataSets.LookUp();
            this.shipZipTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.orderIdLabel1 = new System.Windows.Forms.Label();
            this.receiveDateLabel1 = new System.Windows.Forms.Label();
            this.schoutDateBox = new CustomControls.DateBox();
            this.dateBox1 = new CustomControls.DateBox();
            this.shipMethodComboBox = new System.Windows.Forms.ComboBox();
            this.mixBookOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statesTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.statesTableAdapter();
            this.tableAdapterManager1 = new Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager();
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
            ((System.ComponentModel.ISupportInitialize)(this.dsmixBookOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingNavigator)).BeginInit();
            this.mixBookOrderBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).BeginInit();
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
            shipAddr2Label.Location = new System.Drawing.Point(61, 104);
            shipAddr2Label.Name = "shipAddr2Label";
            shipAddr2Label.Size = new System.Drawing.Size(89, 13);
            shipAddr2Label.TabIndex = 6;
            shipAddr2Label.Text = "Shipping Address";
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
            orderIdLabel.Location = new System.Drawing.Point(553, 52);
            orderIdLabel.Name = "orderIdLabel";
            orderIdLabel.Size = new System.Drawing.Size(45, 13);
            orderIdLabel.TabIndex = 16;
            orderIdLabel.Text = "Order Id";
            // 
            // receiveDateLabel
            // 
            receiveDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            receiveDateLabel.AutoSize = true;
            receiveDateLabel.Location = new System.Drawing.Point(525, 71);
            receiveDateLabel.Name = "receiveDateLabel";
            receiveDateLabel.Size = new System.Drawing.Size(73, 13);
            receiveDateLabel.TabIndex = 18;
            receiveDateLabel.Text = "Receive Date";
            // 
            // shipDateLabel
            // 
            shipDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            shipDateLabel.AutoSize = true;
            shipDateLabel.Location = new System.Drawing.Point(544, 97);
            shipDateLabel.Name = "shipDateLabel";
            shipDateLabel.Size = new System.Drawing.Size(54, 13);
            shipDateLabel.TabIndex = 129;
            shipDateLabel.Text = "Ship Date";
            // 
            // dateShippedLabel
            // 
            dateShippedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateShippedLabel.AutoSize = true;
            dateShippedLabel.Location = new System.Drawing.Point(526, 123);
            dateShippedLabel.Name = "dateShippedLabel";
            dateShippedLabel.Size = new System.Drawing.Size(72, 13);
            dateShippedLabel.TabIndex = 129;
            dateShippedLabel.Text = "Date Shipped";
            // 
            // shipMethodLabel
            // 
            shipMethodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            shipMethodLabel.AutoSize = true;
            shipMethodLabel.Location = new System.Drawing.Point(528, 152);
            shipMethodLabel.Name = "shipMethodLabel";
            shipMethodLabel.Size = new System.Drawing.Size(70, 13);
            shipMethodLabel.TabIndex = 130;
            shipMethodLabel.Text = "Ship Method:";
            // 
            // dsmixBookOrders
            // 
            this.dsmixBookOrders.DataSetName = "MixBookOrders";
            this.dsmixBookOrders.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mixBookOrderBindingSource
            // 
            this.mixBookOrderBindingSource.DataMember = "MixBookOrder";
            this.mixBookOrderBindingSource.DataSource = this.dsmixBookOrders;
            this.mixBookOrderBindingSource.PositionChanged += new System.EventHandler(this.mixBookOrderBindingSource_PositionChanged);
            // 
            // mixBookOrderTableAdapter
            // 
            this.mixBookOrderTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.MixBookOrderTableAdapter = this.mixBookOrderTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.MixBookOrdersTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // shipNameTextBox
            // 
            this.shipNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipName", true));
            this.shipNameTextBox.Location = new System.Drawing.Point(152, 49);
            this.shipNameTextBox.Name = "shipNameTextBox";
            this.shipNameTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipNameTextBox.TabIndex = 4;
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
            this.toolStripButton1});
            this.mixBookOrderBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.mixBookOrderBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.mixBookOrderBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.mixBookOrderBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.mixBookOrderBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.mixBookOrderBindingNavigator.Name = "mixBookOrderBindingNavigator";
            this.mixBookOrderBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.mixBookOrderBindingNavigator.Size = new System.Drawing.Size(810, 25);
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
            this.toolStripButton1.Image = global::Mbc5.Properties.Resources.Name;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripButton1.Text = "Ship Name";
            this.toolStripButton1.ToolTipText = "Name";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // shipAddrTextBox
            // 
            this.shipAddrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipAddr", true));
            this.shipAddrTextBox.Location = new System.Drawing.Point(152, 75);
            this.shipAddrTextBox.Name = "shipAddrTextBox";
            this.shipAddrTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipAddrTextBox.TabIndex = 5;
            // 
            // shipAddr2TextBox
            // 
            this.shipAddr2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipAddr2", true));
            this.shipAddr2TextBox.Location = new System.Drawing.Point(152, 101);
            this.shipAddr2TextBox.Name = "shipAddr2TextBox";
            this.shipAddr2TextBox.Size = new System.Drawing.Size(251, 20);
            this.shipAddr2TextBox.TabIndex = 7;
            // 
            // shipCityTextBox
            // 
            this.shipCityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipCity", true));
            this.shipCityTextBox.Location = new System.Drawing.Point(152, 127);
            this.shipCityTextBox.Name = "shipCityTextBox";
            this.shipCityTextBox.Size = new System.Drawing.Size(251, 20);
            this.shipCityTextBox.TabIndex = 9;
            // 
            // shipStateComboBox
            // 
            this.shipStateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipState", true));
            this.shipStateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mixBookOrderBindingSource, "ShipState", true));
            this.shipStateComboBox.DataSource = this.statesBindingSource;
            this.shipStateComboBox.DisplayMember = "Name";
            this.shipStateComboBox.FormattingEnabled = true;
            this.shipStateComboBox.Location = new System.Drawing.Point(152, 153);
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
            // shipZipTextBox
            // 
            this.shipZipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipZip", true));
            this.shipZipTextBox.Location = new System.Drawing.Point(152, 180);
            this.shipZipTextBox.Name = "shipZipTextBox";
            this.shipZipTextBox.Size = new System.Drawing.Size(126, 20);
            this.shipZipTextBox.TabIndex = 13;
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "PhoneNumber", true));
            this.phoneNumberTextBox.Location = new System.Drawing.Point(152, 206);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(126, 20);
            this.phoneNumberTextBox.TabIndex = 15;
            // 
            // orderIdLabel1
            // 
            this.orderIdLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.orderIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "OrderId", true));
            this.orderIdLabel1.Location = new System.Drawing.Point(604, 52);
            this.orderIdLabel1.Name = "orderIdLabel1";
            this.orderIdLabel1.Size = new System.Drawing.Size(100, 23);
            this.orderIdLabel1.TabIndex = 17;
            this.orderIdLabel1.Text = "label1";
            // 
            // receiveDateLabel1
            // 
            this.receiveDateLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.receiveDateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ReceiveDate", true));
            this.receiveDateLabel1.Location = new System.Drawing.Point(604, 71);
            this.receiveDateLabel1.Name = "receiveDateLabel1";
            this.receiveDateLabel1.Size = new System.Drawing.Size(100, 23);
            this.receiveDateLabel1.TabIndex = 19;
            this.receiveDateLabel1.Text = "label1";
            // 
            // schoutDateBox
            // 
            this.schoutDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.schoutDateBox.Date = null;
            this.schoutDateBox.DateValue = null;
            this.schoutDateBox.Location = new System.Drawing.Point(604, 97);
            this.schoutDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.schoutDateBox.Name = "schoutDateBox";
            this.schoutDateBox.Size = new System.Drawing.Size(114, 20);
            this.schoutDateBox.TabIndex = 129;
            // 
            // dateBox1
            // 
            this.dateBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBox1.Date = null;
            this.dateBox1.DateValue = null;
            this.dateBox1.Location = new System.Drawing.Point(604, 123);
            this.dateBox1.MinimumSize = new System.Drawing.Size(114, 20);
            this.dateBox1.Name = "dateBox1";
            this.dateBox1.Size = new System.Drawing.Size(114, 20);
            this.dateBox1.TabIndex = 130;
            // 
            // shipMethodComboBox
            // 
            this.shipMethodComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shipMethodComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipMethod", true));
            this.shipMethodComboBox.FormattingEnabled = true;
            this.shipMethodComboBox.Location = new System.Drawing.Point(604, 149);
            this.shipMethodComboBox.Name = "shipMethodComboBox";
            this.shipMethodComboBox.Size = new System.Drawing.Size(121, 21);
            this.shipMethodComboBox.TabIndex = 131;
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
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.mixBookOrderDataGridView.DataSource = this.mixBookOrderBindingSource;
            this.mixBookOrderDataGridView.EnableHeadersVisualStyles = false;
            this.mixBookOrderDataGridView.Location = new System.Drawing.Point(85, 253);
            this.mixBookOrderDataGridView.Name = "mixBookOrderDataGridView";
            this.mixBookOrderDataGridView.ReadOnly = true;
            this.mixBookOrderDataGridView.Size = new System.Drawing.Size(640, 220);
            this.mixBookOrderDataGridView.TabIndex = 131;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Invno";
            this.dataGridViewTextBoxColumn1.HeaderText = "Invno";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Job";
            this.dataGridViewTextBoxColumn3.FillWeight = 88.02047F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Job";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 157;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ItemCode";
            this.dataGridViewTextBoxColumn6.FillWeight = 88.02047F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Item Code";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 156;
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
            // frmMBOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(810, 591);
            this.Controls.Add(this.mixBookOrderDataGridView);
            this.Controls.Add(shipMethodLabel);
            this.Controls.Add(this.shipMethodComboBox);
            this.Controls.Add(this.dateBox1);
            this.Controls.Add(dateShippedLabel);
            this.Controls.Add(shipDateLabel);
            this.Controls.Add(this.schoutDateBox);
            this.Controls.Add(receiveDateLabel);
            this.Controls.Add(this.receiveDateLabel1);
            this.Controls.Add(orderIdLabel);
            this.Controls.Add(this.orderIdLabel1);
            this.Controls.Add(phoneNumberLabel);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(shipZipLabel);
            this.Controls.Add(this.shipZipTextBox);
            this.Controls.Add(shipStateLabel);
            this.Controls.Add(this.shipStateComboBox);
            this.Controls.Add(shipCityLabel);
            this.Controls.Add(this.shipCityTextBox);
            this.Controls.Add(shipAddr2Label);
            this.Controls.Add(this.shipAddr2TextBox);
            this.Controls.Add(shipAddrLabel);
            this.Controls.Add(this.shipAddrTextBox);
            this.Controls.Add(shipNameLabel);
            this.Controls.Add(this.shipNameTextBox);
            this.Controls.Add(this.mixBookOrderBindingNavigator);
            this.MinimumSize = new System.Drawing.Size(826, 630);
            this.Name = "frmMBOrders";
            this.Text = "Mix Book Cust/Orders";
            this.Load += new System.EventHandler(this.MBOrders_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.mixBookOrderBindingNavigator, 0);
            this.Controls.SetChildIndex(this.shipNameTextBox, 0);
            this.Controls.SetChildIndex(shipNameLabel, 0);
            this.Controls.SetChildIndex(this.shipAddrTextBox, 0);
            this.Controls.SetChildIndex(shipAddrLabel, 0);
            this.Controls.SetChildIndex(this.shipAddr2TextBox, 0);
            this.Controls.SetChildIndex(shipAddr2Label, 0);
            this.Controls.SetChildIndex(this.shipCityTextBox, 0);
            this.Controls.SetChildIndex(shipCityLabel, 0);
            this.Controls.SetChildIndex(this.shipStateComboBox, 0);
            this.Controls.SetChildIndex(shipStateLabel, 0);
            this.Controls.SetChildIndex(this.shipZipTextBox, 0);
            this.Controls.SetChildIndex(shipZipLabel, 0);
            this.Controls.SetChildIndex(this.phoneNumberTextBox, 0);
            this.Controls.SetChildIndex(phoneNumberLabel, 0);
            this.Controls.SetChildIndex(this.orderIdLabel1, 0);
            this.Controls.SetChildIndex(orderIdLabel, 0);
            this.Controls.SetChildIndex(this.receiveDateLabel1, 0);
            this.Controls.SetChildIndex(receiveDateLabel, 0);
            this.Controls.SetChildIndex(this.schoutDateBox, 0);
            this.Controls.SetChildIndex(shipDateLabel, 0);
            this.Controls.SetChildIndex(dateShippedLabel, 0);
            this.Controls.SetChildIndex(this.dateBox1, 0);
            this.Controls.SetChildIndex(this.shipMethodComboBox, 0);
            this.Controls.SetChildIndex(shipMethodLabel, 0);
            this.Controls.SetChildIndex(this.mixBookOrderDataGridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsmixBookOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingNavigator)).EndInit();
            this.mixBookOrderBindingNavigator.ResumeLayout(false);
            this.mixBookOrderBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSets.MixBookOrders dsmixBookOrders;
        private System.Windows.Forms.BindingSource mixBookOrderBindingSource;
        private DataSets.MixBookOrdersTableAdapters.MixBookOrderTableAdapter mixBookOrderTableAdapter;
        private DataSets.MixBookOrdersTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox shipNameTextBox;
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
        private System.Windows.Forms.TextBox shipAddrTextBox;
        private System.Windows.Forms.TextBox shipAddr2TextBox;
        private System.Windows.Forms.TextBox shipCityTextBox;
        private System.Windows.Forms.ComboBox shipStateComboBox;
        private System.Windows.Forms.TextBox shipZipTextBox;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.Label orderIdLabel1;
        private System.Windows.Forms.Label receiveDateLabel1;
        private CustomControls.DateBox schoutDateBox;
        private CustomControls.DateBox dateBox1;
        private System.Windows.Forms.ComboBox shipMethodComboBox;
        private System.Windows.Forms.DataGridView mixBookOrderDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataSets.LookUp lookUp;
        private System.Windows.Forms.BindingSource statesBindingSource;
        private DataSets.LookUpTableAdapters.statesTableAdapter statesTableAdapter;
        private DataSets.LookUpTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}
