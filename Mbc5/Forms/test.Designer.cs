namespace Mbc5.Forms
{
    partial class test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(test));
            System.Windows.Forms.Label schnameLabel;
            System.Windows.Forms.Label schcodeLabel;
            System.Windows.Forms.Label contryearLabel;
            this.dsSales = new Mbc5.DataSets.dsSales();
            this.quotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quotesTableAdapter = new Mbc5.DataSets.dsSalesTableAdapters.quotesTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager();
            this.quotesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.quotesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.fillToolStrip = new System.Windows.Forms.ToolStrip();
            this.schcodeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.schcodeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.schnameTextBox = new System.Windows.Forms.TextBox();
            this.schcodeTextBox = new System.Windows.Forms.TextBox();
            this.contryearTextBox = new System.Windows.Forms.TextBox();
            schnameLabel = new System.Windows.Forms.Label();
            schcodeLabel = new System.Windows.Forms.Label();
            contryearLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingNavigator)).BeginInit();
            this.quotesBindingNavigator.SuspendLayout();
            this.fillToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsSales
            // 
            this.dsSales.DataSetName = "dsSales";
            this.dsSales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quotesBindingSource
            // 
            this.quotesBindingSource.DataMember = "quotes";
            this.quotesBindingSource.DataSource = this.dsSales;
            // 
            // quotesTableAdapter
            // 
            this.quotesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.custTableAdapter = null;
            this.tableAdapterManager.InvHstTableAdapter = null;
            this.tableAdapterManager.quotesTableAdapter = this.quotesTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // quotesBindingNavigator
            // 
            this.quotesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.quotesBindingNavigator.BindingSource = this.quotesBindingSource;
            this.quotesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.quotesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.quotesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.quotesBindingNavigatorSaveItem});
            this.quotesBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.quotesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.quotesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.quotesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.quotesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.quotesBindingNavigator.Name = "quotesBindingNavigator";
            this.quotesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.quotesBindingNavigator.Size = new System.Drawing.Size(1215, 25);
            this.quotesBindingNavigator.TabIndex = 0;
            this.quotesBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 15);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // quotesBindingNavigatorSaveItem
            // 
            this.quotesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.quotesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("quotesBindingNavigatorSaveItem.Image")));
            this.quotesBindingNavigatorSaveItem.Name = "quotesBindingNavigatorSaveItem";
            this.quotesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 20);
            this.quotesBindingNavigatorSaveItem.Text = "Save Data";
            this.quotesBindingNavigatorSaveItem.Click += new System.EventHandler(this.quotesBindingNavigatorSaveItem_Click);
            // 
            // fillToolStrip
            // 
            this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schcodeToolStripLabel,
            this.schcodeToolStripTextBox,
            this.fillToolStripButton});
            this.fillToolStrip.Location = new System.Drawing.Point(0, 25);
            this.fillToolStrip.Name = "fillToolStrip";
            this.fillToolStrip.Size = new System.Drawing.Size(1215, 25);
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
            this.schcodeToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // fillToolStripButton
            // 
            this.fillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillToolStripButton.Name = "fillToolStripButton";
            this.fillToolStripButton.Size = new System.Drawing.Size(26, 19);
            this.fillToolStripButton.Text = "Fill";
            this.fillToolStripButton.Click += new System.EventHandler(this.fillToolStripButton_Click);
            // 
            // schnameLabel
            // 
            schnameLabel.AutoSize = true;
            schnameLabel.Location = new System.Drawing.Point(60, 84);
            schnameLabel.Name = "schnameLabel";
            schnameLabel.Size = new System.Drawing.Size(53, 13);
            schnameLabel.TabIndex = 2;
            schnameLabel.Text = "schname:";
            // 
            // schnameTextBox
            // 
            this.schnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "schname", true));
            this.schnameTextBox.Location = new System.Drawing.Point(119, 81);
            this.schnameTextBox.Name = "schnameTextBox";
            this.schnameTextBox.Size = new System.Drawing.Size(100, 20);
            this.schnameTextBox.TabIndex = 3;
            // 
            // schcodeLabel
            // 
            schcodeLabel.AutoSize = true;
            schcodeLabel.Location = new System.Drawing.Point(420, 83);
            schcodeLabel.Name = "schcodeLabel";
            schcodeLabel.Size = new System.Drawing.Size(51, 13);
            schcodeLabel.TabIndex = 4;
            schcodeLabel.Text = "schcode:";
            // 
            // schcodeTextBox
            // 
            this.schcodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "schcode", true));
            this.schcodeTextBox.Location = new System.Drawing.Point(477, 80);
            this.schcodeTextBox.Name = "schcodeTextBox";
            this.schcodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.schcodeTextBox.TabIndex = 5;
            // 
            // contryearLabel
            // 
            contryearLabel.AutoSize = true;
            contryearLabel.Location = new System.Drawing.Point(714, 89);
            contryearLabel.Name = "contryearLabel";
            contryearLabel.Size = new System.Drawing.Size(54, 13);
            contryearLabel.TabIndex = 6;
            contryearLabel.Text = "contryear:";
            // 
            // contryearTextBox
            // 
            this.contryearTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "contryear", true));
            this.contryearTextBox.Location = new System.Drawing.Point(774, 86);
            this.contryearTextBox.Name = "contryearTextBox";
            this.contryearTextBox.Size = new System.Drawing.Size(100, 20);
            this.contryearTextBox.TabIndex = 7;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 402);
            this.Controls.Add(contryearLabel);
            this.Controls.Add(this.contryearTextBox);
            this.Controls.Add(schcodeLabel);
            this.Controls.Add(this.schcodeTextBox);
            this.Controls.Add(schnameLabel);
            this.Controls.Add(this.schnameTextBox);
            this.Controls.Add(this.fillToolStrip);
            this.Controls.Add(this.quotesBindingNavigator);
            this.Name = "test";
            this.Text = "test";
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingNavigator)).EndInit();
            this.quotesBindingNavigator.ResumeLayout(false);
            this.quotesBindingNavigator.PerformLayout();
            this.fillToolStrip.ResumeLayout(false);
            this.fillToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSets.dsSales dsSales;
        private System.Windows.Forms.BindingSource quotesBindingSource;
        private DataSets.dsSalesTableAdapters.quotesTableAdapter quotesTableAdapter;
        private DataSets.dsSalesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator quotesBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton quotesBindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStrip fillToolStrip;
        private System.Windows.Forms.ToolStripLabel schcodeToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox schcodeToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
        private System.Windows.Forms.TextBox schnameTextBox;
        private System.Windows.Forms.TextBox schcodeTextBox;
        private System.Windows.Forms.TextBox contryearTextBox;
    }
}