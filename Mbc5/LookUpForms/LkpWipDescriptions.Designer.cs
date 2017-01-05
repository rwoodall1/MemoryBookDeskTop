namespace Mbc5.LookUpForms
{
    partial class LkpWipDescriptions
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
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label tableNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LkpWipDescriptions));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dsProdutn = new Mbc5.DataSets.dsProdutn();
            this.wipDescriptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wipDescriptionsTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.WipDescriptionsTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager();
            this.wipDescriptionsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.wipDescriptionsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.wipDescriptionsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.tableNameComboBox = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.cmbFilterVal = new System.Windows.Forms.ToolStripComboBox();
            descriptionLabel = new System.Windows.Forms.Label();
            tableNameLabel = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingNavigator)).BeginInit();
            this.wipDescriptionsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Size = new System.Drawing.Size(517, 48);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.wipDescriptionsBindingNavigator);
            this.BottomPanel.Location = new System.Drawing.Point(0, 505);
            this.BottomPanel.Size = new System.Drawing.Size(517, 37);
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(24, 54);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 3;
            descriptionLabel.Text = "Description:";
            // 
            // tableNameLabel
            // 
            tableNameLabel.AutoSize = true;
            tableNameLabel.Location = new System.Drawing.Point(24, 80);
            tableNameLabel.Name = "tableNameLabel";
            tableNameLabel.Size = new System.Drawing.Size(68, 13);
            tableNameLabel.TabIndex = 5;
            tableNameLabel.Text = "Table Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "WIP/Cover Descriptions";
            // 
            // dsProdutn
            // 
            this.dsProdutn.DataSetName = "dsProdutn";
            this.dsProdutn.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wipDescriptionsBindingSource
            // 
            this.wipDescriptionsBindingSource.DataMember = "WipDescriptions";
            this.wipDescriptionsBindingSource.DataSource = this.dsProdutn;
            // 
            // wipDescriptionsTableAdapter
            // 
            this.wipDescriptionsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.coverdetailTableAdapter = null;
            this.tableAdapterManager.coversTableAdapter = null;
            this.tableAdapterManager.custTableAdapter = null;
            this.tableAdapterManager.produtnTableAdapter = null;
            this.tableAdapterManager.quotesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WipDescriptionsTableAdapter = this.wipDescriptionsTableAdapter;
            this.tableAdapterManager.WipDetailTableAdapter = null;
            this.tableAdapterManager.wipTableAdapter = null;
            // 
            // wipDescriptionsBindingNavigator
            // 
            this.wipDescriptionsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.wipDescriptionsBindingNavigator.BindingSource = this.wipDescriptionsBindingSource;
            this.wipDescriptionsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.wipDescriptionsBindingNavigator.DeleteItem = null;
            this.wipDescriptionsBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wipDescriptionsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.wipDescriptionsBindingNavigatorSaveItem,
            this.btnFilter,
            this.cmbFilterVal});
            this.wipDescriptionsBindingNavigator.Location = new System.Drawing.Point(0, 12);
            this.wipDescriptionsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.wipDescriptionsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.wipDescriptionsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.wipDescriptionsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.wipDescriptionsBindingNavigator.Name = "wipDescriptionsBindingNavigator";
            this.wipDescriptionsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.wipDescriptionsBindingNavigator.Size = new System.Drawing.Size(517, 25);
            this.wipDescriptionsBindingNavigator.TabIndex = 2;
            this.wipDescriptionsBindingNavigator.Text = "bindingNavigator1";
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
            // wipDescriptionsBindingNavigatorSaveItem
            // 
            this.wipDescriptionsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wipDescriptionsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("wipDescriptionsBindingNavigatorSaveItem.Image")));
            this.wipDescriptionsBindingNavigatorSaveItem.Name = "wipDescriptionsBindingNavigatorSaveItem";
            this.wipDescriptionsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.wipDescriptionsBindingNavigatorSaveItem.Text = "Save Data";
            this.wipDescriptionsBindingNavigatorSaveItem.Click += new System.EventHandler(this.wipDescriptionsBindingNavigatorSaveItem_Click);
            // 
            // wipDescriptionsDataGridView
            // 
            this.wipDescriptionsDataGridView.AllowUserToAddRows = false;
            this.wipDescriptionsDataGridView.AllowUserToDeleteRows = false;
            this.wipDescriptionsDataGridView.AutoGenerateColumns = false;
            this.wipDescriptionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wipDescriptionsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.wipDescriptionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wipDescriptionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.wipDescriptionsDataGridView.DataSource = this.wipDescriptionsBindingSource;
            this.wipDescriptionsDataGridView.EnableHeadersVisualStyles = false;
            this.wipDescriptionsDataGridView.Location = new System.Drawing.Point(24, 113);
            this.wipDescriptionsDataGridView.Name = "wipDescriptionsDataGridView";
            this.wipDescriptionsDataGridView.ReadOnly = true;
            this.wipDescriptionsDataGridView.Size = new System.Drawing.Size(463, 373);
            this.wipDescriptionsDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TableName";
            this.dataGridViewTextBoxColumn2.HeaderText = "TableName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn3.HeaderText = "Id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wipDescriptionsBindingSource, "Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(91, 54);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(285, 20);
            this.descriptionTextBox.TabIndex = 4;
            // 
            // tableNameComboBox
            // 
            this.tableNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wipDescriptionsBindingSource, "TableName", true));
            this.tableNameComboBox.FormattingEnabled = true;
            this.tableNameComboBox.Items.AddRange(new object[] {
            "Covers",
            "WIP"});
            this.tableNameComboBox.Location = new System.Drawing.Point(91, 80);
            this.tableNameComboBox.Name = "tableNameComboBox";
            this.tableNameComboBox.Size = new System.Drawing.Size(285, 21);
            this.tableNameComboBox.TabIndex = 7;
            // 
            // btnFilter
            // 
            this.btnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(68, 22);
            this.btnFilter.Text = "Table Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cmbFilterVal
            // 
            this.cmbFilterVal.Items.AddRange(new object[] {
            "",
            "Covers",
            "WIP"});
            this.cmbFilterVal.Name = "cmbFilterVal";
            this.cmbFilterVal.Size = new System.Drawing.Size(121, 25);
            // 
            // LkpWipDescriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(517, 542);
            this.Controls.Add(this.tableNameComboBox);
            this.Controls.Add(tableNameLabel);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.wipDescriptionsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LkpWipDescriptions";
            this.Text = "WIP/Cover Descriptions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LkpWipDescriptions_FormClosing);
            this.Load += new System.EventHandler(this.LkpWipDescriptions_Load);
            this.Controls.SetChildIndex(this.TopPanel, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.wipDescriptionsDataGridView, 0);
            this.Controls.SetChildIndex(this.descriptionTextBox, 0);
            this.Controls.SetChildIndex(descriptionLabel, 0);
            this.Controls.SetChildIndex(tableNameLabel, 0);
            this.Controls.SetChildIndex(this.tableNameComboBox, 0);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingNavigator)).EndInit();
            this.wipDescriptionsBindingNavigator.ResumeLayout(false);
            this.wipDescriptionsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DataSets.dsProdutn dsProdutn;
        private System.Windows.Forms.BindingSource wipDescriptionsBindingSource;
        private DataSets.dsProdutnTableAdapters.WipDescriptionsTableAdapter wipDescriptionsTableAdapter;
        private DataSets.dsProdutnTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator wipDescriptionsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton wipDescriptionsBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView wipDescriptionsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.ComboBox tableNameComboBox;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.ToolStripComboBox cmbFilterVal;
    }
}
