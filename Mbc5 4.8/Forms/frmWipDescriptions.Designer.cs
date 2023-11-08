namespace Mbc5.Forms
{
    partial class frmWipDescriptions
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
            System.Windows.Forms.Label tableNameLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dsProdutn = new Mbc5.DataSets.dsProdutn();
            this.wipDescriptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wipDescriptionsTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.WipDescriptionsTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager();
            this.cmbTableName = new System.Windows.Forms.ComboBox();
            this.bsTableNames = new System.Windows.Forms.BindingSource(this.components);
            this.dsProdutn1 = new Mbc5.DataSets.dsProdutn();
            this.wipDescriptionsDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tableNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTableNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Location = new System.Drawing.Point(-341, -68);
            this.basePanel.Size = new System.Drawing.Size(15, 16);
            // 
            // tableNameLabel
            // 
            tableNameLabel.AutoSize = true;
            tableNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tableNameLabel.Location = new System.Drawing.Point(41, 19);
            tableNameLabel.Name = "tableNameLabel";
            tableNameLabel.Size = new System.Drawing.Size(75, 13);
            tableNameLabel.TabIndex = 3;
            tableNameLabel.Text = "Table Name";
            // 
            // dsProdutn
            // 
            this.dsProdutn.DataSetName = "dsProdutn";
            this.dsProdutn.EnforceConstraints = false;
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
            this.tableAdapterManager.mcustTableAdapter = null;
            this.tableAdapterManager.PartBkDetailTableAdapter = null;
            this.tableAdapterManager.partbkTableAdapter = null;
            this.tableAdapterManager.produtnTableAdapter = null;
            this.tableAdapterManager.prtbkbdetailTableAdapter = null;
            this.tableAdapterManager.ptbkbTableAdapter = null;
            this.tableAdapterManager.quotesTableAdapter = null;
            this.tableAdapterManager.ReorderDetailTableAdapter = null;
            this.tableAdapterManager.ReOrderTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WipDescriptionsTableAdapter = this.wipDescriptionsTableAdapter;
            this.tableAdapterManager.WipDetailTableAdapter = null;
            this.tableAdapterManager.wipTableAdapter = null;
            // 
            // cmbTableName
            // 
            this.cmbTableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wipDescriptionsBindingSource, "TableName", true));
            this.cmbTableName.DataSource = this.bsTableNames;
            this.cmbTableName.DisplayMember = "TableName";
            this.cmbTableName.FormattingEnabled = true;
            this.cmbTableName.Location = new System.Drawing.Point(131, 19);
            this.cmbTableName.Name = "cmbTableName";
            this.cmbTableName.Size = new System.Drawing.Size(210, 21);
            this.cmbTableName.TabIndex = 4;
            this.cmbTableName.ValueMember = "TableName";
            this.cmbTableName.SelectionChangeCommitted += new System.EventHandler(this.tableNameComboBox_SelectionChangeCommitted);
            // 
            // bsTableNames
            // 
            this.bsTableNames.DataMember = "WipDescriptions";
            this.bsTableNames.DataSource = this.dsProdutn1;
            // 
            // dsProdutn1
            // 
            this.dsProdutn1.DataSetName = "dsProdutn";
            this.dsProdutn1.EnforceConstraints = false;
            this.dsProdutn1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wipDescriptionsDataGridView
            // 
            this.wipDescriptionsDataGridView.AllowUserToAddRows = false;
            this.wipDescriptionsDataGridView.AllowUserToDeleteRows = false;
            this.wipDescriptionsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wipDescriptionsDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wipDescriptionsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.wipDescriptionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wipDescriptionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.DescriptionId,
            this.dataGridViewTextBoxColumn3});
            this.wipDescriptionsDataGridView.DataSource = this.wipDescriptionsBindingSource;
            this.wipDescriptionsDataGridView.EnableHeadersVisualStyles = false;
            this.wipDescriptionsDataGridView.Location = new System.Drawing.Point(0, 109);
            this.wipDescriptionsDataGridView.Name = "wipDescriptionsDataGridView";
            this.wipDescriptionsDataGridView.Size = new System.Drawing.Size(556, 457);
            this.wipDescriptionsDataGridView.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(373, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // DescriptionId
            // 
            this.DescriptionId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DescriptionId.DataPropertyName = "DescriptionId";
            this.DescriptionId.HeaderText = "Description Id";
            this.DescriptionId.Name = "DescriptionId";
            this.DescriptionId.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn3.HeaderText = "Rec Id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // frmWipDescriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(559, 569);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wipDescriptionsDataGridView);
            this.Controls.Add(tableNameLabel);
            this.Controls.Add(this.cmbTableName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWipDescriptions";
            this.Text = "WIP Descriptions";
            this.Load += new System.EventHandler(this.WipDescriptions_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.cmbTableName, 0);
            this.Controls.SetChildIndex(tableNameLabel, 0);
            this.Controls.SetChildIndex(this.wipDescriptionsDataGridView, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTableNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSets.dsProdutn dsProdutn;
        private System.Windows.Forms.BindingSource wipDescriptionsBindingSource;
        private DataSets.dsProdutnTableAdapters.WipDescriptionsTableAdapter wipDescriptionsTableAdapter;
        private DataSets.dsProdutnTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbTableName;
        private System.Windows.Forms.DataGridView wipDescriptionsDataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bsTableNames;
        private DataSets.dsProdutn dsProdutn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}
