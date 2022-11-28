namespace Mbc5.Forms.MixBook
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            System.Windows.Forms.Label shipAddr2Label;
            this.mixBookOrders = new Mbc5.DataSets.MixBookOrders();
            this.mixBookOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mixBookOrderTableAdapter = new Mbc5.DataSets.MixBookOrdersTableAdapters.MixBookOrderTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.MixBookOrdersTableAdapters.TableAdapterManager();
            this.mixBookOrderBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.fillToolStrip = new System.Windows.Forms.ToolStrip();
            this.clientOrderIdToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.clientOrderIdToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.shipNameTextBox = new System.Windows.Forms.TextBox();
            this.shipAddrTextBox = new System.Windows.Forms.TextBox();
            this.shipAddr2TextBox = new System.Windows.Forms.TextBox();
            shipNameLabel = new System.Windows.Forms.Label();
            shipAddrLabel = new System.Windows.Forms.Label();
            shipAddr2Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingNavigator)).BeginInit();
            this.mixBookOrderBindingNavigator.SuspendLayout();
            this.fillToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // shipNameLabel
            // 
            shipNameLabel.AutoSize = true;
            shipNameLabel.Location = new System.Drawing.Point(55, 52);
            shipNameLabel.Name = "shipNameLabel";
            shipNameLabel.Size = new System.Drawing.Size(62, 13);
            shipNameLabel.TabIndex = 2;
            shipNameLabel.Text = "Ship Name:";
            // 
            // shipAddrLabel
            // 
            shipAddrLabel.AutoSize = true;
            shipAddrLabel.Location = new System.Drawing.Point(90, 132);
            shipAddrLabel.Name = "shipAddrLabel";
            shipAddrLabel.Size = new System.Drawing.Size(56, 13);
            shipAddrLabel.TabIndex = 4;
            shipAddrLabel.Text = "Ship Addr:";
            // 
            // mixBookOrders
            // 
            this.mixBookOrders.DataSetName = "MixBookOrders";
            this.mixBookOrders.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mixBookOrderBindingSource
            // 
            this.mixBookOrderBindingSource.DataMember = "MixBookOrder";
            this.mixBookOrderBindingSource.DataSource = this.mixBookOrders;
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
            this.mixBookOrderBindingNavigatorSaveItem});
            this.mixBookOrderBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.mixBookOrderBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.mixBookOrderBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.mixBookOrderBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.mixBookOrderBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.mixBookOrderBindingNavigator.Name = "mixBookOrderBindingNavigator";
            this.mixBookOrderBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.mixBookOrderBindingNavigator.Size = new System.Drawing.Size(812, 25);
            this.mixBookOrderBindingNavigator.TabIndex = 0;
            this.mixBookOrderBindingNavigator.Text = "bindingNavigator1";
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
            this.mixBookOrderBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mixBookOrderBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("mixBookOrderBindingNavigatorSaveItem.Image")));
            this.mixBookOrderBindingNavigatorSaveItem.Name = "mixBookOrderBindingNavigatorSaveItem";
            this.mixBookOrderBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.mixBookOrderBindingNavigatorSaveItem.Text = "Save Data";
            this.mixBookOrderBindingNavigatorSaveItem.Click += new System.EventHandler(this.mixBookOrderBindingNavigatorSaveItem_Click);
            // 
            // fillToolStrip
            // 
            this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientOrderIdToolStripLabel,
            this.clientOrderIdToolStripTextBox,
            this.fillToolStripButton});
            this.fillToolStrip.Location = new System.Drawing.Point(0, 25);
            this.fillToolStrip.Name = "fillToolStrip";
            this.fillToolStrip.Size = new System.Drawing.Size(812, 25);
            this.fillToolStrip.TabIndex = 1;
            this.fillToolStrip.Text = "fillToolStrip";
            // 
            // clientOrderIdToolStripLabel
            // 
            this.clientOrderIdToolStripLabel.Name = "clientOrderIdToolStripLabel";
            this.clientOrderIdToolStripLabel.Size = new System.Drawing.Size(81, 22);
            this.clientOrderIdToolStripLabel.Text = "ClientOrderId:";
            // 
            // clientOrderIdToolStripTextBox
            // 
            this.clientOrderIdToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clientOrderIdToolStripTextBox.Name = "clientOrderIdToolStripTextBox";
            this.clientOrderIdToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // fillToolStripButton
            // 
            this.fillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillToolStripButton.Name = "fillToolStripButton";
            this.fillToolStripButton.Size = new System.Drawing.Size(26, 22);
            this.fillToolStripButton.Text = "Fill";
            this.fillToolStripButton.Click += new System.EventHandler(this.fillToolStripButton_Click);
            // 
            // shipNameTextBox
            // 
            this.shipNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipName", true));
            this.shipNameTextBox.Location = new System.Drawing.Point(123, 49);
            this.shipNameTextBox.Name = "shipNameTextBox";
            this.shipNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.shipNameTextBox.TabIndex = 3;
            // 
            // shipAddrTextBox
            // 
            this.shipAddrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipAddr", true));
            this.shipAddrTextBox.Location = new System.Drawing.Point(152, 129);
            this.shipAddrTextBox.Name = "shipAddrTextBox";
            this.shipAddrTextBox.Size = new System.Drawing.Size(100, 20);
            this.shipAddrTextBox.TabIndex = 5;
            // 
            // shipAddr2Label
            // 
            shipAddr2Label.AutoSize = true;
            shipAddr2Label.Location = new System.Drawing.Point(60, 310);
            shipAddr2Label.Name = "shipAddr2Label";
            shipAddr2Label.Size = new System.Drawing.Size(62, 13);
            shipAddr2Label.TabIndex = 6;
            shipAddr2Label.Text = "Ship Addr2:";
            // 
            // shipAddr2TextBox
            // 
            this.shipAddr2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixBookOrderBindingSource, "ShipAddr2", true));
            this.shipAddr2TextBox.Location = new System.Drawing.Point(128, 307);
            this.shipAddr2TextBox.Name = "shipAddr2TextBox";
            this.shipAddr2TextBox.Size = new System.Drawing.Size(100, 20);
            this.shipAddr2TextBox.TabIndex = 7;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 485);
            this.Controls.Add(shipAddr2Label);
            this.Controls.Add(this.shipAddr2TextBox);
            this.Controls.Add(shipAddrLabel);
            this.Controls.Add(this.shipAddrTextBox);
            this.Controls.Add(shipNameLabel);
            this.Controls.Add(this.shipNameTextBox);
            this.Controls.Add(this.fillToolStrip);
            this.Controls.Add(this.mixBookOrderBindingNavigator);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixBookOrderBindingNavigator)).EndInit();
            this.mixBookOrderBindingNavigator.ResumeLayout(false);
            this.mixBookOrderBindingNavigator.PerformLayout();
            this.fillToolStrip.ResumeLayout(false);
            this.fillToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSets.MixBookOrders mixBookOrders;
        private System.Windows.Forms.BindingSource mixBookOrderBindingSource;
        private DataSets.MixBookOrdersTableAdapters.MixBookOrderTableAdapter mixBookOrderTableAdapter;
        private DataSets.MixBookOrdersTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator mixBookOrderBindingNavigator;
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
        private System.Windows.Forms.ToolStrip fillToolStrip;
        private System.Windows.Forms.ToolStripLabel clientOrderIdToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox clientOrderIdToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
        private System.Windows.Forms.TextBox shipNameTextBox;
        private System.Windows.Forms.TextBox shipAddrTextBox;
        private System.Windows.Forms.TextBox shipAddr2TextBox;
    }
}