namespace Mbc5.Forms.MixBook
{
    partial class frmWipReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bsWip = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet1 = new System.Data.DataSet();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ShipName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Backing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoverPress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trimming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookRemake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTrimming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shpCarrier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(29, 28);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShipName,
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Backing,
            this.CoverPress,
            this.Trimming,
            this.Column10,
            this.Column11,
            this.BookRemake,
            this.Column14,
            this.PTrimming,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.shpCarrier});
            this.dataGridView1.DataSource = this.bsWip;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1172, 518);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(15, 51);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(117, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Print Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 65;
            this.reportViewer1.Location = new System.Drawing.Point(1058, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(67, 64);
            this.reportViewer1.TabIndex = 4;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // lblRecCount
            // 
            this.lblRecCount.AutoSize = true;
            this.lblRecCount.Location = new System.Drawing.Point(401, 56);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(0, 13);
            this.lblRecCount.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(650, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "RequestDate Equal to or less than";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(835, 45);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // ShipName
            // 
            this.ShipName.DataPropertyName = "ShipName";
            this.ShipName.HeaderText = "Name";
            this.ShipName.Name = "ShipName";
            this.ShipName.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Invno";
            this.Column1.HeaderText = "Invno";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Copies";
            this.Column2.HeaderText = "Copies";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "OrderReceivedDate";
            this.Column5.HeaderText = "OrderReceivedDate";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "RequestedShipDate";
            this.Column7.HeaderText = "RequestedShipDate";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Description";
            this.Column8.HeaderText = "Description";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Backing
            // 
            this.Backing.DataPropertyName = "Backing";
            this.Backing.HeaderText = "Backing";
            this.Backing.Name = "Backing";
            this.Backing.ReadOnly = true;
            // 
            // CoverPress
            // 
            this.CoverPress.DataPropertyName = "CPress";
            this.CoverPress.HeaderText = "CoverPress";
            this.CoverPress.Name = "CoverPress";
            this.CoverPress.ReadOnly = true;
            // 
            // Trimming
            // 
            this.Trimming.DataPropertyName = "CTrimming";
            this.Trimming.HeaderText = "CTrim";
            this.Trimming.Name = "Trimming";
            this.Trimming.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "OnBoards";
            this.Column10.HeaderText = "OnBoards";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "CCart";
            this.Column11.HeaderText = "CoverCart";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // BookRemake
            // 
            this.BookRemake.DataPropertyName = "IsBookRemake";
            this.BookRemake.HeaderText = "IsBookRemake";
            this.BookRemake.Name = "BookRemake";
            this.BookRemake.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "WipPress";
            this.Column14.HeaderText = "WipPress";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // PTrimming
            // 
            this.PTrimming.DataPropertyName = "PTrimming";
            this.PTrimming.HeaderText = "PTrim";
            this.PTrimming.Name = "PTrimming";
            this.PTrimming.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "Binding";
            this.Column15.HeaderText = "Binding";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "Location39";
            this.Column16.HeaderText = "PressCart";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "CaseIn";
            this.Column17.HeaderText = "CaseIn";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "Quality";
            this.Column18.HeaderText = "Quality";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            // 
            // shpCarrier
            // 
            this.shpCarrier.DataPropertyName = "ShipCarrier";
            this.shpCarrier.HeaderText = "Ship Carrier";
            this.shpCarrier.Name = "shpCarrier";
            this.shpCarrier.ReadOnly = true;
            // 
            // frmWipReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1196, 626);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblRecCount);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmWipReport";
            this.Text = "Mixbook WIP Report";
            this.Load += new System.EventHandler(this.frmWipReport_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.lblRecCount, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bsWip;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Backing;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoverPress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trimming;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookRemake;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTrimming;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn shpCarrier;
    }
}
