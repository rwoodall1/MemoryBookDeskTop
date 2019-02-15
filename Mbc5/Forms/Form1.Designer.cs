namespace Mbc5.Forms
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.dsSales = new Mbc5.DataSets.dsSales();
			this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.custTableAdapter = new Mbc5.DataSets.dsSalesTableAdapters.custTableAdapter();
			this.tableAdapterManager = new Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager();
			this.custBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
			this.custBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
			this.fillToolStrip = new System.Windows.Forms.ToolStrip();
			this.schcodeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.schcodeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.custDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn59 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn62 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn63 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn11 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn65 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn66 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn67 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn68 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn69 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn72 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn73 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn74 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn75 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn76 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn77 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn78 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn12 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn13 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn79 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn14 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewCheckBoxColumn15 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn16 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn81 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn82 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn83 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn84 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn85 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn86 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn87 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn88 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn89 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn90 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn91 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn92 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn93 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn94 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn95 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn96 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn17 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn97 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn98 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn99 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn18 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn101 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn102 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn103 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn105 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn106 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn107 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn108 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn19 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn109 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn110 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn111 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn20 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn112 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn113 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dsCust = new Mbc5.DataSets.dsCust();
			this.custBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.custTableAdapter1 = new Mbc5.DataSets.dsCustTableAdapters.custTableAdapter();
			this.tableAdapterManager1 = new Mbc5.DataSets.dsCustTableAdapters.TableAdapterManager();
			this.fillToolStrip1 = new System.Windows.Forms.ToolStrip();
			this.schcodeToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.schcodeToolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.fillToolStripButton1 = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.dsSales)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.custBindingNavigator)).BeginInit();
			this.custBindingNavigator.SuspendLayout();
			this.fillToolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCust)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource1)).BeginInit();
			this.fillToolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dsSales
			// 
			this.dsSales.DataSetName = "dsSales";
			this.dsSales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// custBindingSource
			// 
			this.custBindingSource.DataMember = "cust";
			this.custBindingSource.DataSource = this.dsSales;
			// 
			// custTableAdapter
			// 
			this.custTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager
			// 
			this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager.custTableAdapter = this.custTableAdapter;
			this.tableAdapterManager.InvHstTableAdapter = null;
			this.tableAdapterManager.quotesTableAdapter = null;
			this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// custBindingNavigator
			// 
			this.custBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
			this.custBindingNavigator.BindingSource = this.custBindingSource;
			this.custBindingNavigator.CountItem = this.bindingNavigatorCountItem;
			this.custBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
			this.custBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.custBindingNavigatorSaveItem});
			this.custBindingNavigator.Location = new System.Drawing.Point(0, 0);
			this.custBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.custBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.custBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.custBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.custBindingNavigator.Name = "custBindingNavigator";
			this.custBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
			this.custBindingNavigator.Size = new System.Drawing.Size(1098, 25);
			this.custBindingNavigator.TabIndex = 0;
			this.custBindingNavigator.Text = "bindingNavigator1";
			// 
			// bindingNavigatorAddNewItem
			// 
			this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
			// custBindingNavigatorSaveItem
			// 
			this.custBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.custBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("custBindingNavigatorSaveItem.Image")));
			this.custBindingNavigatorSaveItem.Name = "custBindingNavigatorSaveItem";
			this.custBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
			this.custBindingNavigatorSaveItem.Text = "Save Data";
			this.custBindingNavigatorSaveItem.Click += new System.EventHandler(this.custBindingNavigatorSaveItem_Click);
			// 
			// fillToolStrip
			// 
			this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schcodeToolStripLabel,
            this.schcodeToolStripTextBox,
            this.fillToolStripButton});
			this.fillToolStrip.Location = new System.Drawing.Point(0, 25);
			this.fillToolStrip.Name = "fillToolStrip";
			this.fillToolStrip.Size = new System.Drawing.Size(1098, 25);
			this.fillToolStrip.TabIndex = 1;
			this.fillToolStrip.Text = "fillToolStrip";
			// 
			// schcodeToolStripLabel
			// 
			this.schcodeToolStripLabel.Name = "schcodeToolStripLabel";
			this.schcodeToolStripLabel.Size = new System.Drawing.Size(54, 22);
			this.schcodeToolStripLabel.Text = "schcode:";
			// 
			// schcodeToolStripTextBox
			// 
			this.schcodeToolStripTextBox.Name = "schcodeToolStripTextBox";
			this.schcodeToolStripTextBox.Size = new System.Drawing.Size(100, 25);
			// 
			// fillToolStripButton
			// 
			this.fillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.fillToolStripButton.Name = "fillToolStripButton";
			this.fillToolStripButton.Size = new System.Drawing.Size(26, 22);
			this.fillToolStripButton.Text = "Fill";
			this.fillToolStripButton.Click += new System.EventHandler(this.fillToolStripButton_Click);
			// 
			// custDataGridView
			// 
			this.custDataGridView.AutoGenerateColumns = false;
			this.custDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.custDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn34,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn36,
            this.dataGridViewTextBoxColumn37,
            this.dataGridViewTextBoxColumn38,
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn40,
            this.dataGridViewTextBoxColumn41,
            this.dataGridViewTextBoxColumn42,
            this.dataGridViewTextBoxColumn43,
            this.dataGridViewTextBoxColumn44,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn45,
            this.dataGridViewTextBoxColumn46,
            this.dataGridViewTextBoxColumn47,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn48,
            this.dataGridViewTextBoxColumn49,
            this.dataGridViewCheckBoxColumn3,
            this.dataGridViewTextBoxColumn50,
            this.dataGridViewCheckBoxColumn4,
            this.dataGridViewTextBoxColumn51,
            this.dataGridViewTextBoxColumn52,
            this.dataGridViewTextBoxColumn53,
            this.dataGridViewTextBoxColumn54,
            this.dataGridViewTextBoxColumn55,
            this.dataGridViewTextBoxColumn56,
            this.dataGridViewTextBoxColumn57,
            this.dataGridViewTextBoxColumn58,
            this.dataGridViewTextBoxColumn59,
            this.dataGridViewTextBoxColumn60,
            this.dataGridViewCheckBoxColumn5,
            this.dataGridViewTextBoxColumn61,
            this.dataGridViewTextBoxColumn62,
            this.dataGridViewCheckBoxColumn6,
            this.dataGridViewCheckBoxColumn7,
            this.dataGridViewTextBoxColumn63,
            this.dataGridViewCheckBoxColumn8,
            this.dataGridViewCheckBoxColumn9,
            this.dataGridViewTextBoxColumn64,
            this.dataGridViewCheckBoxColumn10,
            this.dataGridViewCheckBoxColumn11,
            this.dataGridViewTextBoxColumn65,
            this.dataGridViewTextBoxColumn66,
            this.dataGridViewTextBoxColumn67,
            this.dataGridViewTextBoxColumn68,
            this.dataGridViewTextBoxColumn69,
            this.dataGridViewTextBoxColumn70,
            this.dataGridViewTextBoxColumn71,
            this.dataGridViewTextBoxColumn72,
            this.dataGridViewTextBoxColumn73,
            this.dataGridViewTextBoxColumn74,
            this.dataGridViewTextBoxColumn75,
            this.dataGridViewTextBoxColumn76,
            this.dataGridViewTextBoxColumn77,
            this.dataGridViewTextBoxColumn78,
            this.dataGridViewCheckBoxColumn12,
            this.dataGridViewCheckBoxColumn13,
            this.dataGridViewTextBoxColumn79,
            this.dataGridViewCheckBoxColumn14,
            this.dataGridViewCheckBoxColumn15,
            this.dataGridViewTextBoxColumn80,
            this.dataGridViewCheckBoxColumn16,
            this.dataGridViewTextBoxColumn81,
            this.dataGridViewTextBoxColumn82,
            this.dataGridViewTextBoxColumn83,
            this.dataGridViewTextBoxColumn84,
            this.dataGridViewTextBoxColumn85,
            this.dataGridViewTextBoxColumn86,
            this.dataGridViewTextBoxColumn87,
            this.dataGridViewTextBoxColumn88,
            this.dataGridViewTextBoxColumn89,
            this.dataGridViewTextBoxColumn90,
            this.dataGridViewTextBoxColumn91,
            this.dataGridViewTextBoxColumn92,
            this.dataGridViewTextBoxColumn93,
            this.dataGridViewTextBoxColumn94,
            this.dataGridViewTextBoxColumn95,
            this.dataGridViewTextBoxColumn96,
            this.dataGridViewCheckBoxColumn17,
            this.dataGridViewTextBoxColumn97,
            this.dataGridViewTextBoxColumn98,
            this.dataGridViewTextBoxColumn99,
            this.dataGridViewTextBoxColumn100,
            this.dataGridViewCheckBoxColumn18,
            this.dataGridViewTextBoxColumn101,
            this.dataGridViewTextBoxColumn102,
            this.dataGridViewTextBoxColumn103,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn105,
            this.dataGridViewTextBoxColumn106,
            this.dataGridViewTextBoxColumn107,
            this.dataGridViewTextBoxColumn108,
            this.dataGridViewCheckBoxColumn19,
            this.dataGridViewTextBoxColumn109,
            this.dataGridViewTextBoxColumn110,
            this.dataGridViewTextBoxColumn111,
            this.dataGridViewCheckBoxColumn20,
            this.dataGridViewTextBoxColumn112,
            this.dataGridViewTextBoxColumn113});
			this.custDataGridView.DataSource = this.custBindingSource;
			this.custDataGridView.Location = new System.Drawing.Point(78, 71);
			this.custDataGridView.Name = "custDataGridView";
			this.custDataGridView.Size = new System.Drawing.Size(300, 220);
			this.custDataGridView.TabIndex = 2;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "schcode";
			this.dataGridViewTextBoxColumn1.HeaderText = "schcode";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "contryear";
			this.dataGridViewTextBoxColumn2.HeaderText = "contryear";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "cstatus";
			this.dataGridViewTextBoxColumn3.HeaderText = "cstatus";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "source";
			this.dataGridViewTextBoxColumn4.HeaderText = "source";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "sourdate";
			this.dataGridViewTextBoxColumn5.HeaderText = "sourdate";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "secsource";
			this.dataGridViewTextBoxColumn6.HeaderText = "secsource";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.DataPropertyName = "contdate";
			this.dataGridViewTextBoxColumn7.HeaderText = "contdate";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.DataPropertyName = "origsour";
			this.dataGridViewTextBoxColumn8.HeaderText = "origsour";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.DataPropertyName = "origyear";
			this.dataGridViewTextBoxColumn9.HeaderText = "origyear";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			// 
			// dataGridViewTextBoxColumn10
			// 
			this.dataGridViewTextBoxColumn10.DataPropertyName = "rebook";
			this.dataGridViewTextBoxColumn10.HeaderText = "rebook";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			// 
			// dataGridViewTextBoxColumn11
			// 
			this.dataGridViewTextBoxColumn11.DataPropertyName = "rebookdte";
			this.dataGridViewTextBoxColumn11.HeaderText = "rebookdte";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			// 
			// dataGridViewTextBoxColumn12
			// 
			this.dataGridViewTextBoxColumn12.DataPropertyName = "refby";
			this.dataGridViewTextBoxColumn12.HeaderText = "refby";
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			// 
			// dataGridViewTextBoxColumn13
			// 
			this.dataGridViewTextBoxColumn13.DataPropertyName = "enrollment";
			this.dataGridViewTextBoxColumn13.HeaderText = "enrollment";
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			// 
			// dataGridViewTextBoxColumn14
			// 
			this.dataGridViewTextBoxColumn14.DataPropertyName = "grades";
			this.dataGridViewTextBoxColumn14.HeaderText = "grades";
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			// 
			// dataGridViewTextBoxColumn15
			// 
			this.dataGridViewTextBoxColumn15.DataPropertyName = "sal";
			this.dataGridViewTextBoxColumn15.HeaderText = "sal";
			this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			// 
			// dataGridViewTextBoxColumn16
			// 
			this.dataGridViewTextBoxColumn16.DataPropertyName = "schaddr";
			this.dataGridViewTextBoxColumn16.HeaderText = "schaddr";
			this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
			// 
			// dataGridViewTextBoxColumn17
			// 
			this.dataGridViewTextBoxColumn17.DataPropertyName = "schaddr2";
			this.dataGridViewTextBoxColumn17.HeaderText = "schaddr2";
			this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
			// 
			// dataGridViewTextBoxColumn18
			// 
			this.dataGridViewTextBoxColumn18.DataPropertyName = "schcity";
			this.dataGridViewTextBoxColumn18.HeaderText = "schcity";
			this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
			// 
			// dataGridViewTextBoxColumn19
			// 
			this.dataGridViewTextBoxColumn19.DataPropertyName = "schstate";
			this.dataGridViewTextBoxColumn19.HeaderText = "schstate";
			this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
			// 
			// dataGridViewTextBoxColumn20
			// 
			this.dataGridViewTextBoxColumn20.DataPropertyName = "schzip";
			this.dataGridViewTextBoxColumn20.HeaderText = "schzip";
			this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
			// 
			// dataGridViewTextBoxColumn21
			// 
			this.dataGridViewTextBoxColumn21.DataPropertyName = "schphone";
			this.dataGridViewTextBoxColumn21.HeaderText = "schphone";
			this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
			// 
			// dataGridViewTextBoxColumn22
			// 
			this.dataGridViewTextBoxColumn22.DataPropertyName = "schfax";
			this.dataGridViewTextBoxColumn22.HeaderText = "schfax";
			this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
			// 
			// dataGridViewTextBoxColumn23
			// 
			this.dataGridViewTextBoxColumn23.DataPropertyName = "schemail";
			this.dataGridViewTextBoxColumn23.HeaderText = "schemail";
			this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
			// 
			// dataGridViewTextBoxColumn24
			// 
			this.dataGridViewTextBoxColumn24.DataPropertyName = "sprngbrk";
			this.dataGridViewTextBoxColumn24.HeaderText = "sprngbrk";
			this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
			// 
			// dataGridViewTextBoxColumn25
			// 
			this.dataGridViewTextBoxColumn25.DataPropertyName = "schout";
			this.dataGridViewTextBoxColumn25.HeaderText = "schout";
			this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
			// 
			// dataGridViewTextBoxColumn26
			// 
			this.dataGridViewTextBoxColumn26.DataPropertyName = "contmemo";
			this.dataGridViewTextBoxColumn26.HeaderText = "contmemo";
			this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
			// 
			// dataGridViewTextBoxColumn27
			// 
			this.dataGridViewTextBoxColumn27.DataPropertyName = "position";
			this.dataGridViewTextBoxColumn27.HeaderText = "position";
			this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
			// 
			// dataGridViewTextBoxColumn28
			// 
			this.dataGridViewTextBoxColumn28.DataPropertyName = "gender";
			this.dataGridViewTextBoxColumn28.HeaderText = "gender";
			this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
			// 
			// dataGridViewTextBoxColumn29
			// 
			this.dataGridViewTextBoxColumn29.DataPropertyName = "contfname";
			this.dataGridViewTextBoxColumn29.HeaderText = "contfname";
			this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
			// 
			// dataGridViewTextBoxColumn30
			// 
			this.dataGridViewTextBoxColumn30.DataPropertyName = "contlname";
			this.dataGridViewTextBoxColumn30.HeaderText = "contlname";
			this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
			// 
			// dataGridViewTextBoxColumn31
			// 
			this.dataGridViewTextBoxColumn31.DataPropertyName = "newfname";
			this.dataGridViewTextBoxColumn31.HeaderText = "newfname";
			this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
			// 
			// dataGridViewTextBoxColumn32
			// 
			this.dataGridViewTextBoxColumn32.DataPropertyName = "newlname";
			this.dataGridViewTextBoxColumn32.HeaderText = "newlname";
			this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
			// 
			// dataGridViewTextBoxColumn33
			// 
			this.dataGridViewTextBoxColumn33.DataPropertyName = "yb_sth";
			this.dataGridViewTextBoxColumn33.HeaderText = "yb_sth";
			this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
			// 
			// dataGridViewTextBoxColumn34
			// 
			this.dataGridViewTextBoxColumn34.DataPropertyName = "shiptocont";
			this.dataGridViewTextBoxColumn34.HeaderText = "shiptocont";
			this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
			// 
			// dataGridViewTextBoxColumn35
			// 
			this.dataGridViewTextBoxColumn35.DataPropertyName = "contaddr";
			this.dataGridViewTextBoxColumn35.HeaderText = "contaddr";
			this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
			// 
			// dataGridViewTextBoxColumn36
			// 
			this.dataGridViewTextBoxColumn36.DataPropertyName = "contaddr2";
			this.dataGridViewTextBoxColumn36.HeaderText = "contaddr2";
			this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
			// 
			// dataGridViewTextBoxColumn37
			// 
			this.dataGridViewTextBoxColumn37.DataPropertyName = "contcity";
			this.dataGridViewTextBoxColumn37.HeaderText = "contcity";
			this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
			// 
			// dataGridViewTextBoxColumn38
			// 
			this.dataGridViewTextBoxColumn38.DataPropertyName = "contstate";
			this.dataGridViewTextBoxColumn38.HeaderText = "contstate";
			this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
			// 
			// dataGridViewTextBoxColumn39
			// 
			this.dataGridViewTextBoxColumn39.DataPropertyName = "contzip";
			this.dataGridViewTextBoxColumn39.HeaderText = "contzip";
			this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
			// 
			// dataGridViewTextBoxColumn40
			// 
			this.dataGridViewTextBoxColumn40.DataPropertyName = "contphnhom";
			this.dataGridViewTextBoxColumn40.HeaderText = "contphnhom";
			this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
			// 
			// dataGridViewTextBoxColumn41
			// 
			this.dataGridViewTextBoxColumn41.DataPropertyName = "contphnwrk";
			this.dataGridViewTextBoxColumn41.HeaderText = "contphnwrk";
			this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
			// 
			// dataGridViewTextBoxColumn42
			// 
			this.dataGridViewTextBoxColumn42.DataPropertyName = "contfax";
			this.dataGridViewTextBoxColumn42.HeaderText = "contfax";
			this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
			// 
			// dataGridViewTextBoxColumn43
			// 
			this.dataGridViewTextBoxColumn43.DataPropertyName = "contemail";
			this.dataGridViewTextBoxColumn43.HeaderText = "contemail";
			this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
			// 
			// dataGridViewTextBoxColumn44
			// 
			this.dataGridViewTextBoxColumn44.DataPropertyName = "booktype";
			this.dataGridViewTextBoxColumn44.HeaderText = "booktype";
			this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
			// 
			// dataGridViewCheckBoxColumn1
			// 
			this.dataGridViewCheckBoxColumn1.DataPropertyName = "vcrsent";
			this.dataGridViewCheckBoxColumn1.HeaderText = "vcrsent";
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			// 
			// dataGridViewTextBoxColumn45
			// 
			this.dataGridViewTextBoxColumn45.DataPropertyName = "sigfopf";
			this.dataGridViewTextBoxColumn45.HeaderText = "sigfopf";
			this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
			// 
			// dataGridViewTextBoxColumn46
			// 
			this.dataGridViewTextBoxColumn46.DataPropertyName = "envflyer";
			this.dataGridViewTextBoxColumn46.HeaderText = "envflyer";
			this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
			// 
			// dataGridViewTextBoxColumn47
			// 
			this.dataGridViewTextBoxColumn47.DataPropertyName = "marketing";
			this.dataGridViewTextBoxColumn47.HeaderText = "marketing";
			this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
			// 
			// dataGridViewCheckBoxColumn2
			// 
			this.dataGridViewCheckBoxColumn2.DataPropertyName = "yearrnd";
			this.dataGridViewCheckBoxColumn2.HeaderText = "yearrnd";
			this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
			// 
			// dataGridViewTextBoxColumn48
			// 
			this.dataGridViewTextBoxColumn48.DataPropertyName = "clrpg_int";
			this.dataGridViewTextBoxColumn48.HeaderText = "clrpg_int";
			this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
			// 
			// dataGridViewTextBoxColumn49
			// 
			this.dataGridViewTextBoxColumn49.DataPropertyName = "shipmemo";
			this.dataGridViewTextBoxColumn49.HeaderText = "shipmemo";
			this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
			// 
			// dataGridViewCheckBoxColumn3
			// 
			this.dataGridViewCheckBoxColumn3.DataPropertyName = "schclosed";
			this.dataGridViewCheckBoxColumn3.HeaderText = "schclosed";
			this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
			// 
			// dataGridViewTextBoxColumn50
			// 
			this.dataGridViewTextBoxColumn50.DataPropertyName = "inoffice";
			this.dataGridViewTextBoxColumn50.HeaderText = "inoffice";
			this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
			// 
			// dataGridViewCheckBoxColumn4
			// 
			this.dataGridViewCheckBoxColumn4.DataPropertyName = "digintrst";
			this.dataGridViewCheckBoxColumn4.HeaderText = "digintrst";
			this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
			// 
			// dataGridViewTextBoxColumn51
			// 
			this.dataGridViewTextBoxColumn51.DataPropertyName = "svcode1";
			this.dataGridViewTextBoxColumn51.HeaderText = "svcode1";
			this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
			// 
			// dataGridViewTextBoxColumn52
			// 
			this.dataGridViewTextBoxColumn52.DataPropertyName = "svdesc1";
			this.dataGridViewTextBoxColumn52.HeaderText = "svdesc1";
			this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
			// 
			// dataGridViewTextBoxColumn53
			// 
			this.dataGridViewTextBoxColumn53.DataPropertyName = "svcode2";
			this.dataGridViewTextBoxColumn53.HeaderText = "svcode2";
			this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
			// 
			// dataGridViewTextBoxColumn54
			// 
			this.dataGridViewTextBoxColumn54.DataPropertyName = "svdesc2";
			this.dataGridViewTextBoxColumn54.HeaderText = "svdesc2";
			this.dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
			// 
			// dataGridViewTextBoxColumn55
			// 
			this.dataGridViewTextBoxColumn55.DataPropertyName = "spcinst";
			this.dataGridViewTextBoxColumn55.HeaderText = "spcinst";
			this.dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
			// 
			// dataGridViewTextBoxColumn56
			// 
			this.dataGridViewTextBoxColumn56.DataPropertyName = "lastcont";
			this.dataGridViewTextBoxColumn56.HeaderText = "lastcont";
			this.dataGridViewTextBoxColumn56.Name = "dataGridViewTextBoxColumn56";
			// 
			// dataGridViewTextBoxColumn57
			// 
			this.dataGridViewTextBoxColumn57.DataPropertyName = "nextcont";
			this.dataGridViewTextBoxColumn57.HeaderText = "nextcont";
			this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
			// 
			// dataGridViewTextBoxColumn58
			// 
			this.dataGridViewTextBoxColumn58.DataPropertyName = "csrep";
			this.dataGridViewTextBoxColumn58.HeaderText = "csrep";
			this.dataGridViewTextBoxColumn58.Name = "dataGridViewTextBoxColumn58";
			// 
			// dataGridViewTextBoxColumn59
			// 
			this.dataGridViewTextBoxColumn59.DataPropertyName = "cstat";
			this.dataGridViewTextBoxColumn59.HeaderText = "cstat";
			this.dataGridViewTextBoxColumn59.Name = "dataGridViewTextBoxColumn59";
			// 
			// dataGridViewTextBoxColumn60
			// 
			this.dataGridViewTextBoxColumn60.DataPropertyName = "xeldate";
			this.dataGridViewTextBoxColumn60.HeaderText = "xeldate";
			this.dataGridViewTextBoxColumn60.Name = "dataGridViewTextBoxColumn60";
			// 
			// dataGridViewCheckBoxColumn5
			// 
			this.dataGridViewCheckBoxColumn5.DataPropertyName = "allcolor";
			this.dataGridViewCheckBoxColumn5.HeaderText = "allcolor";
			this.dataGridViewCheckBoxColumn5.Name = "dataGridViewCheckBoxColumn5";
			// 
			// dataGridViewTextBoxColumn61
			// 
			this.dataGridViewTextBoxColumn61.DataPropertyName = "rbinit";
			this.dataGridViewTextBoxColumn61.HeaderText = "rbinit";
			this.dataGridViewTextBoxColumn61.Name = "dataGridViewTextBoxColumn61";
			// 
			// dataGridViewTextBoxColumn62
			// 
			this.dataGridViewTextBoxColumn62.DataPropertyName = "rbdate";
			this.dataGridViewTextBoxColumn62.HeaderText = "rbdate";
			this.dataGridViewTextBoxColumn62.Name = "dataGridViewTextBoxColumn62";
			// 
			// dataGridViewCheckBoxColumn6
			// 
			this.dataGridViewCheckBoxColumn6.DataPropertyName = "clspic";
			this.dataGridViewCheckBoxColumn6.HeaderText = "clspic";
			this.dataGridViewCheckBoxColumn6.Name = "dataGridViewCheckBoxColumn6";
			// 
			// dataGridViewCheckBoxColumn7
			// 
			this.dataGridViewCheckBoxColumn7.DataPropertyName = "magic";
			this.dataGridViewCheckBoxColumn7.HeaderText = "magic";
			this.dataGridViewCheckBoxColumn7.Name = "dataGridViewCheckBoxColumn7";
			// 
			// dataGridViewTextBoxColumn63
			// 
			this.dataGridViewTextBoxColumn63.DataPropertyName = "extrchg";
			this.dataGridViewTextBoxColumn63.HeaderText = "extrchg";
			this.dataGridViewTextBoxColumn63.Name = "dataGridViewTextBoxColumn63";
			// 
			// dataGridViewCheckBoxColumn8
			// 
			this.dataGridViewCheckBoxColumn8.DataPropertyName = "sprinfo";
			this.dataGridViewCheckBoxColumn8.HeaderText = "sprinfo";
			this.dataGridViewCheckBoxColumn8.Name = "dataGridViewCheckBoxColumn8";
			// 
			// dataGridViewCheckBoxColumn9
			// 
			this.dataGridViewCheckBoxColumn9.DataPropertyName = "fallinfo";
			this.dataGridViewCheckBoxColumn9.HeaderText = "fallinfo";
			this.dataGridViewCheckBoxColumn9.Name = "dataGridViewCheckBoxColumn9";
			// 
			// dataGridViewTextBoxColumn64
			// 
			this.dataGridViewTextBoxColumn64.DataPropertyName = "initcont";
			this.dataGridViewTextBoxColumn64.HeaderText = "initcont";
			this.dataGridViewTextBoxColumn64.Name = "dataGridViewTextBoxColumn64";
			// 
			// dataGridViewCheckBoxColumn10
			// 
			this.dataGridViewCheckBoxColumn10.DataPropertyName = "highsp";
			this.dataGridViewCheckBoxColumn10.HeaderText = "highsp";
			this.dataGridViewCheckBoxColumn10.Name = "dataGridViewCheckBoxColumn10";
			// 
			// dataGridViewCheckBoxColumn11
			// 
			this.dataGridViewCheckBoxColumn11.DataPropertyName = "slownone";
			this.dataGridViewCheckBoxColumn11.HeaderText = "slownone";
			this.dataGridViewCheckBoxColumn11.Name = "dataGridViewCheckBoxColumn11";
			// 
			// dataGridViewTextBoxColumn65
			// 
			this.dataGridViewTextBoxColumn65.DataPropertyName = "pcmac";
			this.dataGridViewTextBoxColumn65.HeaderText = "pcmac";
			this.dataGridViewTextBoxColumn65.Name = "dataGridViewTextBoxColumn65";
			// 
			// dataGridViewTextBoxColumn66
			// 
			this.dataGridViewTextBoxColumn66.DataPropertyName = "junsno";
			this.dataGridViewTextBoxColumn66.HeaderText = "junsno";
			this.dataGridViewTextBoxColumn66.Name = "dataGridViewTextBoxColumn66";
			// 
			// dataGridViewTextBoxColumn67
			// 
			this.dataGridViewTextBoxColumn67.DataPropertyName = "bcontfname";
			this.dataGridViewTextBoxColumn67.HeaderText = "bcontfname";
			this.dataGridViewTextBoxColumn67.Name = "dataGridViewTextBoxColumn67";
			// 
			// dataGridViewTextBoxColumn68
			// 
			this.dataGridViewTextBoxColumn68.DataPropertyName = "bcontlname";
			this.dataGridViewTextBoxColumn68.HeaderText = "bcontlname";
			this.dataGridViewTextBoxColumn68.Name = "dataGridViewTextBoxColumn68";
			// 
			// dataGridViewTextBoxColumn69
			// 
			this.dataGridViewTextBoxColumn69.DataPropertyName = "bcontaddr";
			this.dataGridViewTextBoxColumn69.HeaderText = "bcontaddr";
			this.dataGridViewTextBoxColumn69.Name = "dataGridViewTextBoxColumn69";
			// 
			// dataGridViewTextBoxColumn70
			// 
			this.dataGridViewTextBoxColumn70.DataPropertyName = "bcontaddr2";
			this.dataGridViewTextBoxColumn70.HeaderText = "bcontaddr2";
			this.dataGridViewTextBoxColumn70.Name = "dataGridViewTextBoxColumn70";
			// 
			// dataGridViewTextBoxColumn71
			// 
			this.dataGridViewTextBoxColumn71.DataPropertyName = "bcontcity";
			this.dataGridViewTextBoxColumn71.HeaderText = "bcontcity";
			this.dataGridViewTextBoxColumn71.Name = "dataGridViewTextBoxColumn71";
			// 
			// dataGridViewTextBoxColumn72
			// 
			this.dataGridViewTextBoxColumn72.DataPropertyName = "bcontstate";
			this.dataGridViewTextBoxColumn72.HeaderText = "bcontstate";
			this.dataGridViewTextBoxColumn72.Name = "dataGridViewTextBoxColumn72";
			// 
			// dataGridViewTextBoxColumn73
			// 
			this.dataGridViewTextBoxColumn73.DataPropertyName = "bcontzip";
			this.dataGridViewTextBoxColumn73.HeaderText = "bcontzip";
			this.dataGridViewTextBoxColumn73.Name = "dataGridViewTextBoxColumn73";
			// 
			// dataGridViewTextBoxColumn74
			// 
			this.dataGridViewTextBoxColumn74.DataPropertyName = "bcontphnhom";
			this.dataGridViewTextBoxColumn74.HeaderText = "bcontphnhom";
			this.dataGridViewTextBoxColumn74.Name = "dataGridViewTextBoxColumn74";
			// 
			// dataGridViewTextBoxColumn75
			// 
			this.dataGridViewTextBoxColumn75.DataPropertyName = "bcontphnwrk";
			this.dataGridViewTextBoxColumn75.HeaderText = "bcontphnwrk";
			this.dataGridViewTextBoxColumn75.Name = "dataGridViewTextBoxColumn75";
			// 
			// dataGridViewTextBoxColumn76
			// 
			this.dataGridViewTextBoxColumn76.DataPropertyName = "bcontfax";
			this.dataGridViewTextBoxColumn76.HeaderText = "bcontfax";
			this.dataGridViewTextBoxColumn76.Name = "dataGridViewTextBoxColumn76";
			// 
			// dataGridViewTextBoxColumn77
			// 
			this.dataGridViewTextBoxColumn77.DataPropertyName = "bcontemail";
			this.dataGridViewTextBoxColumn77.HeaderText = "bcontemail";
			this.dataGridViewTextBoxColumn77.Name = "dataGridViewTextBoxColumn77";
			// 
			// dataGridViewTextBoxColumn78
			// 
			this.dataGridViewTextBoxColumn78.DataPropertyName = "multiyroptions";
			this.dataGridViewTextBoxColumn78.HeaderText = "multiyroptions";
			this.dataGridViewTextBoxColumn78.Name = "dataGridViewTextBoxColumn78";
			// 
			// dataGridViewCheckBoxColumn12
			// 
			this.dataGridViewCheckBoxColumn12.DataPropertyName = "multiyear";
			this.dataGridViewCheckBoxColumn12.HeaderText = "multiyear";
			this.dataGridViewCheckBoxColumn12.Name = "dataGridViewCheckBoxColumn12";
			// 
			// dataGridViewCheckBoxColumn13
			// 
			this.dataGridViewCheckBoxColumn13.DataPropertyName = "schuploading";
			this.dataGridViewCheckBoxColumn13.HeaderText = "schuploading";
			this.dataGridViewCheckBoxColumn13.Name = "dataGridViewCheckBoxColumn13";
			// 
			// dataGridViewTextBoxColumn79
			// 
			this.dataGridViewTextBoxColumn79.DataPropertyName = "website";
			this.dataGridViewTextBoxColumn79.HeaderText = "website";
			this.dataGridViewTextBoxColumn79.Name = "dataGridViewTextBoxColumn79";
			// 
			// dataGridViewCheckBoxColumn14
			// 
			this.dataGridViewCheckBoxColumn14.DataPropertyName = "nomktemail";
			this.dataGridViewCheckBoxColumn14.HeaderText = "nomktemail";
			this.dataGridViewCheckBoxColumn14.Name = "dataGridViewCheckBoxColumn14";
			// 
			// dataGridViewCheckBoxColumn15
			// 
			this.dataGridViewCheckBoxColumn15.DataPropertyName = "nodirectmail";
			this.dataGridViewCheckBoxColumn15.HeaderText = "nodirectmail";
			this.dataGridViewCheckBoxColumn15.Name = "dataGridViewCheckBoxColumn15";
			// 
			// dataGridViewTextBoxColumn80
			// 
			this.dataGridViewTextBoxColumn80.DataPropertyName = "bposition";
			this.dataGridViewTextBoxColumn80.HeaderText = "bposition";
			this.dataGridViewTextBoxColumn80.Name = "dataGridViewTextBoxColumn80";
			// 
			// dataGridViewCheckBoxColumn16
			// 
			this.dataGridViewCheckBoxColumn16.DataPropertyName = "blkwhite";
			this.dataGridViewCheckBoxColumn16.HeaderText = "blkwhite";
			this.dataGridViewCheckBoxColumn16.Name = "dataGridViewCheckBoxColumn16";
			// 
			// dataGridViewTextBoxColumn81
			// 
			this.dataGridViewTextBoxColumn81.DataPropertyName = "mbconlinepassword";
			this.dataGridViewTextBoxColumn81.HeaderText = "mbconlinepassword";
			this.dataGridViewTextBoxColumn81.Name = "dataGridViewTextBoxColumn81";
			// 
			// dataGridViewTextBoxColumn82
			// 
			this.dataGridViewTextBoxColumn82.DataPropertyName = "ccontfname";
			this.dataGridViewTextBoxColumn82.HeaderText = "ccontfname";
			this.dataGridViewTextBoxColumn82.Name = "dataGridViewTextBoxColumn82";
			// 
			// dataGridViewTextBoxColumn83
			// 
			this.dataGridViewTextBoxColumn83.DataPropertyName = "ccontlname";
			this.dataGridViewTextBoxColumn83.HeaderText = "ccontlname";
			this.dataGridViewTextBoxColumn83.Name = "dataGridViewTextBoxColumn83";
			// 
			// dataGridViewTextBoxColumn84
			// 
			this.dataGridViewTextBoxColumn84.DataPropertyName = "ccontaddr";
			this.dataGridViewTextBoxColumn84.HeaderText = "ccontaddr";
			this.dataGridViewTextBoxColumn84.Name = "dataGridViewTextBoxColumn84";
			// 
			// dataGridViewTextBoxColumn85
			// 
			this.dataGridViewTextBoxColumn85.DataPropertyName = "ccontaddr2";
			this.dataGridViewTextBoxColumn85.HeaderText = "ccontaddr2";
			this.dataGridViewTextBoxColumn85.Name = "dataGridViewTextBoxColumn85";
			// 
			// dataGridViewTextBoxColumn86
			// 
			this.dataGridViewTextBoxColumn86.DataPropertyName = "ccontcity";
			this.dataGridViewTextBoxColumn86.HeaderText = "ccontcity";
			this.dataGridViewTextBoxColumn86.Name = "dataGridViewTextBoxColumn86";
			// 
			// dataGridViewTextBoxColumn87
			// 
			this.dataGridViewTextBoxColumn87.DataPropertyName = "ccontstate";
			this.dataGridViewTextBoxColumn87.HeaderText = "ccontstate";
			this.dataGridViewTextBoxColumn87.Name = "dataGridViewTextBoxColumn87";
			// 
			// dataGridViewTextBoxColumn88
			// 
			this.dataGridViewTextBoxColumn88.DataPropertyName = "ccontzip";
			this.dataGridViewTextBoxColumn88.HeaderText = "ccontzip";
			this.dataGridViewTextBoxColumn88.Name = "dataGridViewTextBoxColumn88";
			// 
			// dataGridViewTextBoxColumn89
			// 
			this.dataGridViewTextBoxColumn89.DataPropertyName = "ccontphnhom";
			this.dataGridViewTextBoxColumn89.HeaderText = "ccontphnhom";
			this.dataGridViewTextBoxColumn89.Name = "dataGridViewTextBoxColumn89";
			// 
			// dataGridViewTextBoxColumn90
			// 
			this.dataGridViewTextBoxColumn90.DataPropertyName = "ccontphnwork";
			this.dataGridViewTextBoxColumn90.HeaderText = "ccontphnwork";
			this.dataGridViewTextBoxColumn90.Name = "dataGridViewTextBoxColumn90";
			// 
			// dataGridViewTextBoxColumn91
			// 
			this.dataGridViewTextBoxColumn91.DataPropertyName = "ccontfax";
			this.dataGridViewTextBoxColumn91.HeaderText = "ccontfax";
			this.dataGridViewTextBoxColumn91.Name = "dataGridViewTextBoxColumn91";
			// 
			// dataGridViewTextBoxColumn92
			// 
			this.dataGridViewTextBoxColumn92.DataPropertyName = "ccontemail";
			this.dataGridViewTextBoxColumn92.HeaderText = "ccontemail";
			this.dataGridViewTextBoxColumn92.Name = "dataGridViewTextBoxColumn92";
			// 
			// dataGridViewTextBoxColumn93
			// 
			this.dataGridViewTextBoxColumn93.DataPropertyName = "norebookreason";
			this.dataGridViewTextBoxColumn93.HeaderText = "norebookreason";
			this.dataGridViewTextBoxColumn93.Name = "dataGridViewTextBoxColumn93";
			// 
			// dataGridViewTextBoxColumn94
			// 
			this.dataGridViewTextBoxColumn94.DataPropertyName = "newpublisher";
			this.dataGridViewTextBoxColumn94.HeaderText = "newpublisher";
			this.dataGridViewTextBoxColumn94.Name = "dataGridViewTextBoxColumn94";
			// 
			// dataGridViewTextBoxColumn95
			// 
			this.dataGridViewTextBoxColumn95.DataPropertyName = "csrep2";
			this.dataGridViewTextBoxColumn95.HeaderText = "csrep2";
			this.dataGridViewTextBoxColumn95.Name = "dataGridViewTextBoxColumn95";
			// 
			// dataGridViewTextBoxColumn96
			// 
			this.dataGridViewTextBoxColumn96.DataPropertyName = "schcolors";
			this.dataGridViewTextBoxColumn96.HeaderText = "schcolors";
			this.dataGridViewTextBoxColumn96.Name = "dataGridViewTextBoxColumn96";
			// 
			// dataGridViewCheckBoxColumn17
			// 
			this.dataGridViewCheckBoxColumn17.DataPropertyName = "keeppswd";
			this.dataGridViewCheckBoxColumn17.HeaderText = "keeppswd";
			this.dataGridViewCheckBoxColumn17.Name = "dataGridViewCheckBoxColumn17";
			// 
			// dataGridViewTextBoxColumn97
			// 
			this.dataGridViewTextBoxColumn97.DataPropertyName = "leadsource";
			this.dataGridViewTextBoxColumn97.HeaderText = "leadsource";
			this.dataGridViewTextBoxColumn97.Name = "dataGridViewTextBoxColumn97";
			// 
			// dataGridViewTextBoxColumn98
			// 
			this.dataGridViewTextBoxColumn98.DataPropertyName = "leadsname";
			this.dataGridViewTextBoxColumn98.HeaderText = "leadsname";
			this.dataGridViewTextBoxColumn98.Name = "dataGridViewTextBoxColumn98";
			// 
			// dataGridViewTextBoxColumn99
			// 
			this.dataGridViewTextBoxColumn99.DataPropertyName = "prevpublisher";
			this.dataGridViewTextBoxColumn99.HeaderText = "prevpublisher";
			this.dataGridViewTextBoxColumn99.Name = "dataGridViewTextBoxColumn99";
			// 
			// dataGridViewTextBoxColumn100
			// 
			this.dataGridViewTextBoxColumn100.DataPropertyName = "leadname";
			this.dataGridViewTextBoxColumn100.HeaderText = "leadname";
			this.dataGridViewTextBoxColumn100.Name = "dataGridViewTextBoxColumn100";
			// 
			// dataGridViewCheckBoxColumn18
			// 
			this.dataGridViewCheckBoxColumn18.DataPropertyName = "isDeleted";
			this.dataGridViewCheckBoxColumn18.HeaderText = "isDeleted";
			this.dataGridViewCheckBoxColumn18.Name = "dataGridViewCheckBoxColumn18";
			// 
			// dataGridViewTextBoxColumn101
			// 
			this.dataGridViewTextBoxColumn101.DataPropertyName = "photographer";
			this.dataGridViewTextBoxColumn101.HeaderText = "photographer";
			this.dataGridViewTextBoxColumn101.Name = "dataGridViewTextBoxColumn101";
			// 
			// dataGridViewTextBoxColumn102
			// 
			this.dataGridViewTextBoxColumn102.DataPropertyName = "DateCreated";
			this.dataGridViewTextBoxColumn102.HeaderText = "DateCreated";
			this.dataGridViewTextBoxColumn102.Name = "dataGridViewTextBoxColumn102";
			// 
			// dataGridViewTextBoxColumn103
			// 
			this.dataGridViewTextBoxColumn103.DataPropertyName = "DateModified";
			this.dataGridViewTextBoxColumn103.HeaderText = "DateModified";
			this.dataGridViewTextBoxColumn103.Name = "dataGridViewTextBoxColumn103";
			// 
			// dataGridViewImageColumn1
			// 
			this.dataGridViewImageColumn1.DataPropertyName = "TimeStamp";
			this.dataGridViewImageColumn1.HeaderText = "TimeStamp";
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn105
			// 
			this.dataGridViewTextBoxColumn105.DataPropertyName = "schname";
			this.dataGridViewTextBoxColumn105.HeaderText = "schname";
			this.dataGridViewTextBoxColumn105.Name = "dataGridViewTextBoxColumn105";
			// 
			// dataGridViewTextBoxColumn106
			// 
			this.dataGridViewTextBoxColumn106.DataPropertyName = "ModifiedBy";
			this.dataGridViewTextBoxColumn106.HeaderText = "ModifiedBy";
			this.dataGridViewTextBoxColumn106.Name = "dataGridViewTextBoxColumn106";
			// 
			// dataGridViewTextBoxColumn107
			// 
			this.dataGridViewTextBoxColumn107.DataPropertyName = "oraclecode";
			this.dataGridViewTextBoxColumn107.HeaderText = "oraclecode";
			this.dataGridViewTextBoxColumn107.Name = "dataGridViewTextBoxColumn107";
			// 
			// dataGridViewTextBoxColumn108
			// 
			this.dataGridViewTextBoxColumn108.DataPropertyName = "cposition";
			this.dataGridViewTextBoxColumn108.HeaderText = "cposition";
			this.dataGridViewTextBoxColumn108.Name = "dataGridViewTextBoxColumn108";
			// 
			// dataGridViewCheckBoxColumn19
			// 
			this.dataGridViewCheckBoxColumn19.DataPropertyName = "electronickit";
			this.dataGridViewCheckBoxColumn19.HeaderText = "electronickit";
			this.dataGridViewCheckBoxColumn19.Name = "dataGridViewCheckBoxColumn19";
			// 
			// dataGridViewTextBoxColumn109
			// 
			this.dataGridViewTextBoxColumn109.DataPropertyName = "electronickitoptions";
			this.dataGridViewTextBoxColumn109.HeaderText = "electronickitoptions";
			this.dataGridViewTextBoxColumn109.Name = "dataGridViewTextBoxColumn109";
			// 
			// dataGridViewTextBoxColumn110
			// 
			this.dataGridViewTextBoxColumn110.DataPropertyName = "status";
			this.dataGridViewTextBoxColumn110.HeaderText = "status";
			this.dataGridViewTextBoxColumn110.Name = "dataGridViewTextBoxColumn110";
			// 
			// dataGridViewTextBoxColumn111
			// 
			this.dataGridViewTextBoxColumn111.DataPropertyName = "taxexemptionexpirationdate";
			this.dataGridViewTextBoxColumn111.HeaderText = "taxexemptionexpirationdate";
			this.dataGridViewTextBoxColumn111.Name = "dataGridViewTextBoxColumn111";
			// 
			// dataGridViewCheckBoxColumn20
			// 
			this.dataGridViewCheckBoxColumn20.DataPropertyName = "IsTaxExempt";
			this.dataGridViewCheckBoxColumn20.HeaderText = "IsTaxExempt";
			this.dataGridViewCheckBoxColumn20.Name = "dataGridViewCheckBoxColumn20";
			// 
			// dataGridViewTextBoxColumn112
			// 
			this.dataGridViewTextBoxColumn112.DataPropertyName = "stage";
			this.dataGridViewTextBoxColumn112.HeaderText = "stage";
			this.dataGridViewTextBoxColumn112.Name = "dataGridViewTextBoxColumn112";
			// 
			// dataGridViewTextBoxColumn113
			// 
			this.dataGridViewTextBoxColumn113.DataPropertyName = "FirstDaySchool";
			this.dataGridViewTextBoxColumn113.HeaderText = "FirstDaySchool";
			this.dataGridViewTextBoxColumn113.Name = "dataGridViewTextBoxColumn113";
			// 
			// dsCust
			// 
			this.dsCust.DataSetName = "dsCust";
			this.dsCust.EnforceConstraints = false;
			this.dsCust.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// custBindingSource1
			// 
			this.custBindingSource1.DataMember = "cust";
			this.custBindingSource1.DataSource = this.dsCust;
			// 
			// custTableAdapter1
			// 
			this.custTableAdapter1.ClearBeforeFill = true;
			// 
			// tableAdapterManager1
			// 
			this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager1.custSearchTableAdapter = null;
		
			this.tableAdapterManager1.datecontTableAdapter = null;
			this.tableAdapterManager1.UpdateOrder = Mbc5.DataSets.dsCustTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// fillToolStrip1
			// 
			this.fillToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schcodeToolStripLabel1,
            this.schcodeToolStripTextBox1,
            this.fillToolStripButton1});
			this.fillToolStrip1.Location = new System.Drawing.Point(0, 50);
			this.fillToolStrip1.Name = "fillToolStrip1";
			this.fillToolStrip1.Size = new System.Drawing.Size(1098, 25);
			this.fillToolStrip1.TabIndex = 3;
			this.fillToolStrip1.Text = "fillToolStrip1";
			// 
			// schcodeToolStripLabel1
			// 
			this.schcodeToolStripLabel1.Name = "schcodeToolStripLabel1";
			this.schcodeToolStripLabel1.Size = new System.Drawing.Size(54, 22);
			this.schcodeToolStripLabel1.Text = "schcode:";
			// 
			// schcodeToolStripTextBox1
			// 
			this.schcodeToolStripTextBox1.Name = "schcodeToolStripTextBox1";
			this.schcodeToolStripTextBox1.Size = new System.Drawing.Size(100, 25);
			// 
			// fillToolStripButton1
			// 
			this.fillToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.fillToolStripButton1.Name = "fillToolStripButton1";
			this.fillToolStripButton1.Size = new System.Drawing.Size(26, 22);
			this.fillToolStripButton1.Text = "Fill";
			this.fillToolStripButton1.Click += new System.EventHandler(this.fillToolStripButton1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1098, 448);
			this.Controls.Add(this.fillToolStrip1);
			this.Controls.Add(this.custDataGridView);
			this.Controls.Add(this.fillToolStrip);
			this.Controls.Add(this.custBindingNavigator);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dsSales)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.custBindingNavigator)).EndInit();
			this.custBindingNavigator.ResumeLayout(false);
			this.custBindingNavigator.PerformLayout();
			this.fillToolStrip.ResumeLayout(false);
			this.fillToolStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCust)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource1)).EndInit();
			this.fillToolStrip1.ResumeLayout(false);
			this.fillToolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DataSets.dsSales dsSales;
        private System.Windows.Forms.BindingSource custBindingSource;
        private DataSets.dsSalesTableAdapters.custTableAdapter custTableAdapter;
        private DataSets.dsSalesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator custBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton custBindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStrip fillToolStrip;
        private System.Windows.Forms.ToolStripLabel schcodeToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox schcodeToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
        private System.Windows.Forms.DataGridView custDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn56;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn59;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn62;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn63;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn64;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn65;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn66;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn67;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn69;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn70;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn71;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn72;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn73;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn74;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn75;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn76;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn77;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn12;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn79;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn80;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn81;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn82;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn83;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn84;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn85;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn86;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn87;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn88;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn89;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn90;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn91;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn92;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn93;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn94;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn95;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn96;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn97;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn98;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn99;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn100;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn101;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn102;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn103;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn104;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn105;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn106;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn107;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn108;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn109;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn110;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn111;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn112;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn113;
		private DataSets.dsCust dsCust;
		private System.Windows.Forms.BindingSource custBindingSource1;
		private DataSets.dsCustTableAdapters.custTableAdapter custTableAdapter1;
		private DataSets.dsCustTableAdapters.TableAdapterManager tableAdapterManager1;
		private System.Windows.Forms.ToolStrip fillToolStrip1;
		private System.Windows.Forms.ToolStripLabel schcodeToolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox schcodeToolStripTextBox1;
		private System.Windows.Forms.ToolStripButton fillToolStripButton1;
	}
}