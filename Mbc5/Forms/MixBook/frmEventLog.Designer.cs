namespace Mbc5.Forms.MixBook
{
    partial class frmEventLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.txtClientOrderId = new System.Windows.Forms.TextBox();
            this.binderyLabelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mixbookEventLogModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mixbookEventLogModelDataGridView = new System.Windows.Forms.DataGridView();
            this.jobIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusChangedToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifiedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtXml = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.binderyLabelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixbookEventLogModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixbookEventLogModelDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(25, 19);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(221, 17);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 1;
            this.btnRetrieve.Text = "Retrieve Data";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // txtClientOrderId
            // 
            this.txtClientOrderId.Location = new System.Drawing.Point(97, 17);
            this.txtClientOrderId.MaxLength = 7;
            this.txtClientOrderId.Name = "txtClientOrderId";
            this.txtClientOrderId.Size = new System.Drawing.Size(115, 20);
            this.txtClientOrderId.TabIndex = 2;
            // 
            // binderyLabelBindingSource
            // 
            this.binderyLabelBindingSource.DataSource = typeof(BindingModels.BinderyLabel);
            // 
            // mixbookEventLogModelBindingSource
            // 
            this.mixbookEventLogModelBindingSource.DataSource = typeof(BindingModels.MixbookEventLogModel);
            // 
            // mixbookEventLogModelDataGridView
            // 
            this.mixbookEventLogModelDataGridView.AllowUserToAddRows = false;
            this.mixbookEventLogModelDataGridView.AllowUserToDeleteRows = false;
            this.mixbookEventLogModelDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mixbookEventLogModelDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mixbookEventLogModelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mixbookEventLogModelDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jobIdDataGridViewTextBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.statusChangedToDataGridViewTextBoxColumn,
            this.notifiedDataGridViewCheckBoxColumn});
            this.mixbookEventLogModelDataGridView.DataSource = this.mixbookEventLogModelBindingSource;
            this.mixbookEventLogModelDataGridView.EnableHeadersVisualStyles = false;
            this.mixbookEventLogModelDataGridView.Location = new System.Drawing.Point(24, 51);
            this.mixbookEventLogModelDataGridView.Name = "mixbookEventLogModelDataGridView";
            this.mixbookEventLogModelDataGridView.ReadOnly = true;
            this.mixbookEventLogModelDataGridView.Size = new System.Drawing.Size(517, 271);
            this.mixbookEventLogModelDataGridView.TabIndex = 3;
            // 
            // jobIdDataGridViewTextBoxColumn
            // 
            this.jobIdDataGridViewTextBoxColumn.DataPropertyName = "JobId";
            this.jobIdDataGridViewTextBoxColumn.HeaderText = "JobId";
            this.jobIdDataGridViewTextBoxColumn.Name = "jobIdDataGridViewTextBoxColumn";
            this.jobIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusChangedToDataGridViewTextBoxColumn
            // 
            this.statusChangedToDataGridViewTextBoxColumn.DataPropertyName = "StatusChangedTo";
            this.statusChangedToDataGridViewTextBoxColumn.HeaderText = "StatusChangedTo";
            this.statusChangedToDataGridViewTextBoxColumn.Name = "statusChangedToDataGridViewTextBoxColumn";
            this.statusChangedToDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusChangedToDataGridViewTextBoxColumn.Width = 175;
            // 
            // notifiedDataGridViewCheckBoxColumn
            // 
            this.notifiedDataGridViewCheckBoxColumn.DataPropertyName = "Notified";
            this.notifiedDataGridViewCheckBoxColumn.HeaderText = "Notified";
            this.notifiedDataGridViewCheckBoxColumn.Name = "notifiedDataGridViewCheckBoxColumn";
            this.notifiedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // txtXml
            // 
            this.txtXml.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixbookEventLogModelBindingSource, "NotificationXML", true));
            this.txtXml.Location = new System.Drawing.Point(24, 343);
            this.txtXml.Multiline = true;
            this.txtXml.Name = "txtXml";
            this.txtXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtXml.Size = new System.Drawing.Size(517, 245);
            this.txtXml.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "XML";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Order Id";
            // 
            // frmEventLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(588, 600);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXml);
            this.Controls.Add(this.mixbookEventLogModelDataGridView);
            this.Controls.Add(this.txtClientOrderId);
            this.Controls.Add(this.btnRetrieve);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEventLog";
            this.Text = "Event Logs";
            this.Load += new System.EventHandler(this.frmEventLog_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.btnRetrieve, 0);
            this.Controls.SetChildIndex(this.txtClientOrderId, 0);
            this.Controls.SetChildIndex(this.mixbookEventLogModelDataGridView, 0);
            this.Controls.SetChildIndex(this.txtXml, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.binderyLabelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixbookEventLogModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixbookEventLogModelDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.TextBox txtClientOrderId;
        private System.Windows.Forms.BindingSource binderyLabelBindingSource;
        private System.Windows.Forms.BindingSource mixbookEventLogModelBindingSource;
        private System.Windows.Forms.DataGridView mixbookEventLogModelDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusChangedToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn notifiedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.TextBox txtXml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
