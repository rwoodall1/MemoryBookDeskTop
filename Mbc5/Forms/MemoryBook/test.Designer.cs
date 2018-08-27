namespace Mbc5.Forms.MemoryBook
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
            System.Windows.Forms.Label invnoLabel;
            System.Windows.Forms.Label prodnoLabel;
            System.Windows.Forms.Label nocopiesLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(test));
            System.Windows.Forms.Label schooltaxLabel;
            this.button1 = new System.Windows.Forms.Button();
            this.quotesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.quotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSales = new Mbc5.DataSets.dsSales();
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
            this.quotesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.fillToolStrip = new System.Windows.Forms.ToolStrip();
            this.schcodeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.schcodeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.invnoTextBox = new System.Windows.Forms.TextBox();
            this.prodnoTextBox = new System.Windows.Forms.TextBox();
            this.quotesTableAdapter = new Mbc5.DataSets.dsSalesTableAdapters.quotesTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager();
            this.nocopiesTextBox = new System.Windows.Forms.TextBox();
            this.schooltaxTextBox = new System.Windows.Forms.TextBox();
            invnoLabel = new System.Windows.Forms.Label();
            prodnoLabel = new System.Windows.Forms.Label();
            nocopiesLabel = new System.Windows.Forms.Label();
            schooltaxLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingNavigator)).BeginInit();
            this.quotesBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).BeginInit();
            this.fillToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // invnoLabel
            // 
            invnoLabel.AutoSize = true;
            invnoLabel.Location = new System.Drawing.Point(95, 142);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(36, 13);
            invnoLabel.TabIndex = 12;
            invnoLabel.Text = "invno:";
            // 
            // prodnoLabel
            // 
            prodnoLabel.AutoSize = true;
            prodnoLabel.Location = new System.Drawing.Point(341, 150);
            prodnoLabel.Name = "prodnoLabel";
            prodnoLabel.Size = new System.Drawing.Size(43, 13);
            prodnoLabel.TabIndex = 13;
            prodnoLabel.Text = "prodno:";
            // 
            // nocopiesLabel
            // 
            nocopiesLabel.AutoSize = true;
            nocopiesLabel.Location = new System.Drawing.Point(172, 295);
            nocopiesLabel.Name = "nocopiesLabel";
            nocopiesLabel.Size = new System.Drawing.Size(53, 13);
            nocopiesLabel.TabIndex = 14;
            nocopiesLabel.Text = "nocopies:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 41);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.quotesBindingNavigator.Size = new System.Drawing.Size(800, 25);
            this.quotesBindingNavigator.TabIndex = 11;
            this.quotesBindingNavigator.Text = "bindingNavigator1";
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
            // quotesBindingSource
            // 
            this.quotesBindingSource.DataMember = "quotes";
            this.quotesBindingSource.DataSource = this.dsSales;
            // 
            // dsSales
            // 
            this.dsSales.DataSetName = "dsSales";
            this.dsSales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // quotesBindingNavigatorSaveItem
            // 
            this.quotesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.quotesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("quotesBindingNavigatorSaveItem.Image")));
            this.quotesBindingNavigatorSaveItem.Name = "quotesBindingNavigatorSaveItem";
            this.quotesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.quotesBindingNavigatorSaveItem.Text = "Save Data";
            this.quotesBindingNavigatorSaveItem.Click += new System.EventHandler(this.quotesBindingNavigatorSaveItem_Click_1);
            // 
            // fillToolStrip
            // 
            this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schcodeToolStripLabel,
            this.schcodeToolStripTextBox,
            this.fillToolStripButton});
            this.fillToolStrip.Location = new System.Drawing.Point(0, 25);
            this.fillToolStrip.Name = "fillToolStrip";
            this.fillToolStrip.Size = new System.Drawing.Size(800, 25);
            this.fillToolStrip.TabIndex = 12;
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
            this.fillToolStripButton.Click += new System.EventHandler(this.fillToolStripButton_Click_1);
            // 
            // invnoTextBox
            // 
            this.invnoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "invno", true));
            this.invnoTextBox.Location = new System.Drawing.Point(137, 139);
            this.invnoTextBox.Name = "invnoTextBox";
            this.invnoTextBox.Size = new System.Drawing.Size(100, 20);
            this.invnoTextBox.TabIndex = 13;
            // 
            // prodnoTextBox
            // 
            this.prodnoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "prodno", true));
            this.prodnoTextBox.Location = new System.Drawing.Point(390, 147);
            this.prodnoTextBox.Name = "prodnoTextBox";
            this.prodnoTextBox.Size = new System.Drawing.Size(100, 20);
            this.prodnoTextBox.TabIndex = 14;
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
            // nocopiesTextBox
            // 
            this.nocopiesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "nocopies", true));
            this.nocopiesTextBox.Location = new System.Drawing.Point(231, 292);
            this.nocopiesTextBox.Name = "nocopiesTextBox";
            this.nocopiesTextBox.Size = new System.Drawing.Size(100, 20);
            this.nocopiesTextBox.TabIndex = 15;
            // 
            // schooltaxLabel
            // 
            schooltaxLabel.AutoSize = true;
            schooltaxLabel.Location = new System.Drawing.Point(213, 222);
            schooltaxLabel.Name = "schooltaxLabel";
            schooltaxLabel.Size = new System.Drawing.Size(55, 13);
            schooltaxLabel.TabIndex = 15;
            schooltaxLabel.Text = "schooltax:";
            // 
            // schooltaxTextBox
            // 
            this.schooltaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "schooltax", true));
            this.schooltaxTextBox.Location = new System.Drawing.Point(274, 219);
            this.schooltaxTextBox.Name = "schooltaxTextBox";
            this.schooltaxTextBox.Size = new System.Drawing.Size(100, 20);
            this.schooltaxTextBox.TabIndex = 16;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(schooltaxLabel);
            this.Controls.Add(this.schooltaxTextBox);
            this.Controls.Add(nocopiesLabel);
            this.Controls.Add(this.nocopiesTextBox);
            this.Controls.Add(prodnoLabel);
            this.Controls.Add(this.prodnoTextBox);
            this.Controls.Add(invnoLabel);
            this.Controls.Add(this.invnoTextBox);
            this.Controls.Add(this.fillToolStrip);
            this.Controls.Add(this.quotesBindingNavigator);
            this.Controls.Add(this.button1);
            this.Name = "test";
            this.Text = "test";
            this.Load += new System.EventHandler(this.test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingNavigator)).EndInit();
            this.quotesBindingNavigator.ResumeLayout(false);
            this.quotesBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).EndInit();
            this.fillToolStrip.ResumeLayout(false);
            this.fillToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.TextBox invnoTextBox;
        private System.Windows.Forms.TextBox prodnoTextBox;
        private System.Windows.Forms.TextBox nocopiesTextBox;
        private System.Windows.Forms.TextBox schooltaxTextBox;
    }
}