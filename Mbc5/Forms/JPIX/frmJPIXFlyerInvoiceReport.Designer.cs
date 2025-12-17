namespace Mbc5.Forms.MixBook
{
    partial class frmJPIXFlyerInvoiceReport
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Invno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestedShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsData = new System.Windows.Forms.BindingSource(this.components);
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.btnMarkInvoiced = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(19, 19);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(272, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date Shipped From";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date Shipped To";
            // 
            // dtFrom
            // 
            this.dtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(135, 469);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(115, 20);
            this.dtFrom.TabIndex = 4;
            this.dtFrom.Value = new System.DateTime(2025, 7, 15, 0, 0, 0, 0);
            // 
            // dtTo
            // 
            this.dtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(135, 494);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(115, 20);
            this.dtTo.TabIndex = 5;
            this.dtTo.Value = new System.DateTime(2025, 7, 17, 0, 0, 0, 0);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Invno,
            this.Name,
            this.RequestedShipDate,
            this.ShipDate,
            this.orderStatus});
            this.dataGridView1.DataSource = this.bsData;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(875, 417);
            this.dataGridView1.TabIndex = 6;
            // 
            // Invno
            // 
            this.Invno.DataPropertyName = "Invno";
            this.Invno.HeaderText = "Invno";
            this.Invno.Name = "Invno";
            // 
            // Name
            // 
            this.Name.DataPropertyName = "ShipToCustomerName";
            this.Name.HeaderText = "Ship Name";
            this.Name.Name = "Name";
            // 
            // RequestedShipDate
            // 
            this.RequestedShipDate.DataPropertyName = "ProjectedShipDate";
            this.RequestedShipDate.HeaderText = "Proj Ship Date";
            this.RequestedShipDate.Name = "RequestedShipDate";
            this.RequestedShipDate.Width = 150;
            // 
            // ShipDate
            // 
            this.ShipDate.DataPropertyName = "DateShipped";
            this.ShipDate.HeaderText = "Ship Date";
            this.ShipDate.Name = "ShipDate";
            this.ShipDate.Width = 150;
            // 
            // orderStatus
            // 
            this.orderStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.orderStatus.DataPropertyName = "OrderStatus";
            this.orderStatus.HeaderText = "Status";
            this.orderStatus.Name = "orderStatus";
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.Location = new System.Drawing.Point(362, 472);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(84, 23);
            this.btnPrintReport.TabIndex = 7;
            this.btnPrintReport.Text = "Print CSV";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnMarkInvoiced
            // 
            this.btnMarkInvoiced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMarkInvoiced.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkInvoiced.Location = new System.Drawing.Point(452, 473);
            this.btnMarkInvoiced.Name = "btnMarkInvoiced";
            this.btnMarkInvoiced.Size = new System.Drawing.Size(103, 23);
            this.btnMarkInvoiced.TabIndex = 8;
            this.btnMarkInvoiced.Text = "Mark Invoiced";
            this.btnMarkInvoiced.UseVisualStyleBackColor = true;
            this.btnMarkInvoiced.Click += new System.EventHandler(this.btnMarkInvoiced_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(145, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Number Records";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(248, 421);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(10, 13);
            this.lblRecords.TabIndex = 10;
            this.lblRecords.Text = ".";
            // 
            // frmJPIXFlyerInvoiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(875, 528);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMarkInvoiced);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
          
            this.Text = "JPIX Invoice Report";
            this.Load += new System.EventHandler(this.frmMxInvoiceReport_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtFrom, 0);
            this.Controls.SetChildIndex(this.dtTo, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnPrintReport, 0);
            this.Controls.SetChildIndex(this.btnMarkInvoiced, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblRecords, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bsData;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Button btnMarkInvoiced;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestedShipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStatus;
    }
}
