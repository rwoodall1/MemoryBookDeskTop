namespace Mbc5.Forms.MixBook
{
    partial class frmNoScanReport
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
            this.dgScans = new System.Windows.Forms.DataGridView();
            this.bsData = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet1 = new System.Data.DataSet();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.rbBooks = new System.Windows.Forms.RadioButton();
            this.rbCovers = new System.Windows.Forms.RadioButton();
            this.ShipName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Backing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookRemake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coverRemake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoverPress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTrimming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnBoards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoverCart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WipPress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTrimming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Binding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PressCart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgScans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(29, 28);
            // 
            // dgScans
            // 
            this.dgScans.AllowUserToAddRows = false;
            this.dgScans.AllowUserToDeleteRows = false;
            this.dgScans.AllowUserToOrderColumns = true;
            this.dgScans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgScans.AutoGenerateColumns = false;
            this.dgScans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgScans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgScans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgScans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShipName,
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Backing,
            this.BookRemake,
            this.coverRemake,
            this.WarDate,
            this.Scan,
            this.CoverPress,
            this.CTrimming,
            this.OnBoards,
            this.CoverCart,
            this.WipPress,
            this.PTrimming,
            this.Binding,
            this.PressCart,
            this.CaseIn,
            this.Quality});
            this.dgScans.DataSource = this.bsData;
            this.dgScans.EnableHeadersVisualStyles = false;
            this.dgScans.Location = new System.Drawing.Point(12, 76);
            this.dgScans.Name = "dgScans";
            this.dgScans.ReadOnly = true;
            this.dgScans.RowHeadersVisible = false;
            this.dgScans.Size = new System.Drawing.Size(1172, 518);
            this.dgScans.TabIndex = 1;
            this.dgScans.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgScans_CellContentClick);
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
            this.lblRecCount.Location = new System.Drawing.Point(605, 52);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(34, 13);
            this.lblRecCount.TabIndex = 5;
            this.lblRecCount.Text = "count";
            // 
            // rbBooks
            // 
            this.rbBooks.AutoSize = true;
            this.rbBooks.Checked = true;
            this.rbBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBooks.Location = new System.Drawing.Point(248, 50);
            this.rbBooks.Name = "rbBooks";
            this.rbBooks.Size = new System.Drawing.Size(133, 17);
            this.rbBooks.TabIndex = 6;
            this.rbBooks.TabStop = true;
            this.rbBooks.Text = "Check Book Scans";
            this.rbBooks.UseVisualStyleBackColor = true;
            this.rbBooks.CheckedChanged += new System.EventHandler(this.rbBooks_CheckedChanged);
            // 
            // rbCovers
            // 
            this.rbCovers.AutoSize = true;
            this.rbCovers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCovers.Location = new System.Drawing.Point(387, 50);
            this.rbCovers.Name = "rbCovers";
            this.rbCovers.Size = new System.Drawing.Size(137, 17);
            this.rbCovers.TabIndex = 7;
            this.rbCovers.Text = "Check Cover Scans";
            this.rbCovers.UseVisualStyleBackColor = true;
            this.rbCovers.CheckedChanged += new System.EventHandler(this.rbCovers_CheckedChanged);
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
            // BookRemake
            // 
            this.BookRemake.DataPropertyName = "IsBookRemake";
            this.BookRemake.HeaderText = "IsBookRemake";
            this.BookRemake.Name = "BookRemake";
            this.BookRemake.ReadOnly = true;
            // 
            // coverRemake
            // 
            this.coverRemake.DataPropertyName = "IsCoverRemake";
            this.coverRemake.HeaderText = "IsCoverRemake";
            this.coverRemake.Name = "coverRemake";
            this.coverRemake.ReadOnly = true;
            // 
            // WarDate
            // 
            this.WarDate.DataPropertyName = "War";
            this.WarDate.HeaderText = "Last Scan";
            this.WarDate.Name = "WarDate";
            this.WarDate.ReadOnly = true;
            // 
            // Scan
            // 
            this.Scan.DataPropertyName = "Scan";
            this.Scan.HeaderText = "Scan";
            this.Scan.Name = "Scan";
            this.Scan.ReadOnly = true;
            // 
            // CoverPress
            // 
            this.CoverPress.DataPropertyName = "CPress";
            this.CoverPress.HeaderText = "CoverPress";
            this.CoverPress.Name = "CoverPress";
            this.CoverPress.ReadOnly = true;
            // 
            // CTrimming
            // 
            this.CTrimming.DataPropertyName = "CTrimming";
            this.CTrimming.HeaderText = "CTrim";
            this.CTrimming.Name = "CTrimming";
            this.CTrimming.ReadOnly = true;
            // 
            // OnBoards
            // 
            this.OnBoards.DataPropertyName = "OnBoards";
            this.OnBoards.HeaderText = "OnBoards";
            this.OnBoards.Name = "OnBoards";
            this.OnBoards.ReadOnly = true;
            // 
            // CoverCart
            // 
            this.CoverCart.DataPropertyName = "CCart";
            this.CoverCart.HeaderText = "CoverCart";
            this.CoverCart.Name = "CoverCart";
            this.CoverCart.ReadOnly = true;
            // 
            // WipPress
            // 
            this.WipPress.DataPropertyName = "WipPress";
            this.WipPress.HeaderText = "WipPress";
            this.WipPress.Name = "WipPress";
            this.WipPress.ReadOnly = true;
            // 
            // PTrimming
            // 
            this.PTrimming.DataPropertyName = "PTrimming";
            this.PTrimming.HeaderText = "PTrim";
            this.PTrimming.Name = "PTrimming";
            this.PTrimming.ReadOnly = true;
            // 
            // Binding
            // 
            this.Binding.DataPropertyName = "Binding";
            this.Binding.HeaderText = "Binding";
            this.Binding.Name = "Binding";
            this.Binding.ReadOnly = true;
            // 
            // PressCart
            // 
            this.PressCart.DataPropertyName = "Location39";
            this.PressCart.HeaderText = "PressCart";
            this.PressCart.Name = "PressCart";
            this.PressCart.ReadOnly = true;
            // 
            // CaseIn
            // 
            this.CaseIn.DataPropertyName = "CaseIn";
            this.CaseIn.HeaderText = "CaseIn";
            this.CaseIn.Name = "CaseIn";
            this.CaseIn.ReadOnly = true;
            // 
            // Quality
            // 
            this.Quality.DataPropertyName = "Qaulity";
            this.Quality.HeaderText = "Quality";
            this.Quality.Name = "Quality";
            this.Quality.ReadOnly = true;
            // 
            // frmNoScanReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1196, 626);
            this.Controls.Add(this.rbCovers);
            this.Controls.Add(this.rbBooks);
            this.Controls.Add(this.lblRecCount);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgScans);
            this.Name = "frmNoScanReport";
            this.Text = "Mixbook No Scan Report";
            this.Load += new System.EventHandler(this.frmWipReport_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.dgScans, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.lblRecCount, 0);
            this.Controls.SetChildIndex(this.rbBooks, 0);
            this.Controls.SetChildIndex(this.rbCovers, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgScans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgScans;
        private System.Windows.Forms.BindingSource bsData;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton rbBooks;
        private System.Windows.Forms.RadioButton rbCovers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Backing;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookRemake;
        private System.Windows.Forms.DataGridViewTextBoxColumn coverRemake;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoverPress;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTrimming;
        private System.Windows.Forms.DataGridViewTextBoxColumn OnBoards;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoverCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn WipPress;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTrimming;
        private System.Windows.Forms.DataGridViewTextBoxColumn Binding;
        private System.Windows.Forms.DataGridViewTextBoxColumn PressCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quality;
    }
}
