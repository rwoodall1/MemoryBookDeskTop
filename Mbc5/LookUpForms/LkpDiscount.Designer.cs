namespace Mbc5.LookUpForms
{
    partial class LkpDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LkpDiscount));
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lookUp = new Mbc5.DataSets.LookUp();
            this.lkpDdiscntBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lkpDdiscntTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.LkpDdiscntTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager();
            this.lkpDdiscntBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.lkpDdiscntBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.lkpDdiscntDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDdiscntBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDdiscntBindingNavigator)).BeginInit();
            this.lkpDdiscntBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDdiscntDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.lblDiscount);
            this.TopPanel.Size = new System.Drawing.Size(381, 48);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Location = new System.Drawing.Point(0, 635);
            this.BottomPanel.Size = new System.Drawing.Size(381, 1);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(83, 9);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(170, 29);
            this.lblDiscount.TabIndex = 0;
            this.lblDiscount.Text = "Discount Items";
            // 
            // lookUp
            // 
            this.lookUp.DataSetName = "LookUp";
            this.lookUp.EnforceConstraints = false;
            this.lookUp.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lkpDdiscntBindingSource
            // 
            this.lkpDdiscntBindingSource.DataMember = "LkpDdiscnt";
            this.lkpDdiscntBindingSource.DataSource = this.lookUp;
            // 
            // lkpDdiscntTableAdapter
            // 
            this.lkpDdiscntTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.contpstnTableAdapter = null;
            this.tableAdapterManager.lkpCommentsTableAdapter = null;
            this.tableAdapterManager.LkpDdiscntTableAdapter = this.lkpDdiscntTableAdapter;
            this.tableAdapterManager.lkpMktReferenceTableAdapter = null;
            this.tableAdapterManager.lkpPromotionsTableAdapter = null;
            this.tableAdapterManager.lkpTypeContTableAdapter = null;
            this.tableAdapterManager.statesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lkpDdiscntBindingNavigator
            // 
            this.lkpDdiscntBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.lkpDdiscntBindingNavigator.BindingSource = this.lkpDdiscntBindingSource;
            this.lkpDdiscntBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.lkpDdiscntBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.lkpDdiscntBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lkpDdiscntBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.lkpDdiscntBindingNavigatorSaveItem});
            this.lkpDdiscntBindingNavigator.Location = new System.Drawing.Point(0, 610);
            this.lkpDdiscntBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.lkpDdiscntBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.lkpDdiscntBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.lkpDdiscntBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.lkpDdiscntBindingNavigator.Name = "lkpDdiscntBindingNavigator";
            this.lkpDdiscntBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.lkpDdiscntBindingNavigator.Size = new System.Drawing.Size(381, 25);
            this.lkpDdiscntBindingNavigator.TabIndex = 2;
            this.lkpDdiscntBindingNavigator.Text = "bindingNavigator1";
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
            // lkpDdiscntBindingNavigatorSaveItem
            // 
            this.lkpDdiscntBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lkpDdiscntBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("lkpDdiscntBindingNavigatorSaveItem.Image")));
            this.lkpDdiscntBindingNavigatorSaveItem.Name = "lkpDdiscntBindingNavigatorSaveItem";
            this.lkpDdiscntBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.lkpDdiscntBindingNavigatorSaveItem.Text = "Save Data";
            this.lkpDdiscntBindingNavigatorSaveItem.Click += new System.EventHandler(this.lkpDdiscntBindingNavigatorSaveItem_Click);
            // 
            // lkpDdiscntDataGridView
            // 
            this.lkpDdiscntDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpDdiscntDataGridView.AutoGenerateColumns = false;
            this.lkpDdiscntDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lkpDdiscntDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.lkpDdiscntDataGridView.DataSource = this.lkpDdiscntBindingSource;
            this.lkpDdiscntDataGridView.Location = new System.Drawing.Point(0, 54);
            this.lkpDdiscntDataGridView.Name = "lkpDdiscntDataGridView";
            this.lkpDdiscntDataGridView.Size = new System.Drawing.Size(377, 545);
            this.lkpDdiscntDataGridView.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "discntdesc";
            this.dataGridViewTextBoxColumn1.HeaderText = "Discount Item";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // LkpDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(381, 636);
            this.Controls.Add(this.lkpDdiscntDataGridView);
            this.Controls.Add(this.lkpDdiscntBindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(16, 39);
            this.Name = "LkpDiscount";
            this.Text = "Discount Items";
            this.Load += new System.EventHandler(this.LkpDiscount_Load);
            this.Controls.SetChildIndex(this.TopPanel, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.lkpDdiscntBindingNavigator, 0);
            this.Controls.SetChildIndex(this.lkpDdiscntDataGridView, 0);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDdiscntBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDdiscntBindingNavigator)).EndInit();
            this.lkpDdiscntBindingNavigator.ResumeLayout(false);
            this.lkpDdiscntBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDdiscntDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDiscount;
        private DataSets.LookUp lookUp;
        private System.Windows.Forms.BindingSource lkpDdiscntBindingSource;
        private DataSets.LookUpTableAdapters.LkpDdiscntTableAdapter lkpDdiscntTableAdapter;
        private DataSets.LookUpTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator lkpDdiscntBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton lkpDdiscntBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView lkpDdiscntDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
