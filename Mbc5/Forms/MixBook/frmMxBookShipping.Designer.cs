namespace Mbc5.Forms.MixBook
{
    partial class frmMxBookShipping
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
            this.lblBkLoc = new System.Windows.Forms.Label();
            this.lblBkLocation = new System.Windows.Forms.Label();
            this.chkRemake = new System.Windows.Forms.CheckBox();
            this.lbllastscanlbl = new System.Windows.Forms.Label();
            this.lblLastScan = new System.Windows.Forms.Label();
            this.txtDateTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.plnTracking = new System.Windows.Forms.Panel();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTrackingNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientIdLookup = new System.Windows.Forms.TextBox();
            this.txtItemBarcode = new System.Windows.Forms.TextBox();
            this.custDataGridView = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qcontractyear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QInvno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsItems = new System.Windows.Forms.BindingSource(this.components);
            this.plnTracking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(20, 22);
            // 
            // lblBkLoc
            // 
            this.lblBkLoc.AutoSize = true;
            this.lblBkLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBkLoc.Location = new System.Drawing.Point(312, 14);
            this.lblBkLoc.Name = "lblBkLoc";
            this.lblBkLoc.Size = new System.Drawing.Size(165, 17);
            this.lblBkLoc.TabIndex = 10025;
            this.lblBkLoc.Text = "Last Scan Book Location";
            this.lblBkLoc.Visible = false;
            // 
            // lblBkLocation
            // 
            this.lblBkLocation.AutoSize = true;
            this.lblBkLocation.BackColor = System.Drawing.Color.Gold;
            this.lblBkLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBkLocation.Location = new System.Drawing.Point(484, 14);
            this.lblBkLocation.Name = "lblBkLocation";
            this.lblBkLocation.Size = new System.Drawing.Size(0, 17);
            this.lblBkLocation.TabIndex = 10024;
            // 
            // chkRemake
            // 
            this.chkRemake.AutoSize = true;
            this.chkRemake.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRemake.Location = new System.Drawing.Point(579, 50);
            this.chkRemake.Name = "chkRemake";
            this.chkRemake.Size = new System.Drawing.Size(79, 20);
            this.chkRemake.TabIndex = 10018;
            this.chkRemake.Text = "Remake";
            this.chkRemake.UseVisualStyleBackColor = true;
            // 
            // lbllastscanlbl
            // 
            this.lbllastscanlbl.AutoSize = true;
            this.lbllastscanlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllastscanlbl.Location = new System.Drawing.Point(38, 18);
            this.lbllastscanlbl.Name = "lbllastscanlbl";
            this.lbllastscanlbl.Size = new System.Drawing.Size(71, 17);
            this.lbllastscanlbl.TabIndex = 10023;
            this.lbllastscanlbl.Text = "Last Scan";
            // 
            // lblLastScan
            // 
            this.lblLastScan.AutoSize = true;
            this.lblLastScan.BackColor = System.Drawing.Color.Gold;
            this.lblLastScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastScan.Location = new System.Drawing.Point(111, 18);
            this.lblLastScan.Name = "lblLastScan";
            this.lblLastScan.Size = new System.Drawing.Size(0, 17);
            this.lblLastScan.TabIndex = 10022;
            // 
            // txtDateTime
            // 
            this.txtDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTime.Location = new System.Drawing.Point(430, 51);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.ReadOnly = true;
            this.txtDateTime.Size = new System.Drawing.Size(143, 22);
            this.txtDateTime.TabIndex = 10021;
            this.txtDateTime.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(347, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 10020;
            this.label6.Text = "Date && Time";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(38, 51);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(158, 16);
            this.lbl1.TabIndex = 10019;
            this.lbl1.Text = "Scan Shipment Bar Code";
            // 
            // plnTracking
            // 
            this.plnTracking.Controls.Add(this.txtWeight);
            this.plnTracking.Controls.Add(this.label5);
            this.plnTracking.Controls.Add(this.txtTrackingNo);
            this.plnTracking.Controls.Add(this.label13);
            this.plnTracking.Location = new System.Drawing.Point(41, 79);
            this.plnTracking.Name = "plnTracking";
            this.plnTracking.Size = new System.Drawing.Size(374, 57);
            this.plnTracking.TabIndex = 10026;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(76, 26);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(54, 20);
            this.txtWeight.TabIndex = 5;
            this.txtWeight.DoubleClick += new System.EventHandler(this.txtWeight_DoubleClick);
            this.txtWeight.Leave += new System.EventHandler(this.txtWeight_Leave);
            this.txtWeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtWeight_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Weight";
            // 
            // txtTrackingNo
            // 
            this.txtTrackingNo.Location = new System.Drawing.Point(75, 3);
            this.txtTrackingNo.Name = "txtTrackingNo";
            this.txtTrackingNo.Size = new System.Drawing.Size(201, 20);
            this.txtTrackingNo.TabIndex = 4;
            this.txtTrackingNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtTrackingNo_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Tracking #";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 10028;
            this.label1.Text = "Scan Item Bar Code";
            // 
            // txtClientIdLookup
            // 
            this.txtClientIdLookup.Location = new System.Drawing.Point(193, 53);
            this.txtClientIdLookup.Name = "txtClientIdLookup";
            this.txtClientIdLookup.Size = new System.Drawing.Size(124, 20);
            this.txtClientIdLookup.TabIndex = 10030;
            this.txtClientIdLookup.Leave += new System.EventHandler(this.txtClientIdLookup_Leave);
            // 
            // txtItemBarcode
            // 
            this.txtItemBarcode.Location = new System.Drawing.Point(162, 160);
            this.txtItemBarcode.Name = "txtItemBarcode";
            this.txtItemBarcode.Size = new System.Drawing.Size(124, 20);
            this.txtItemBarcode.TabIndex = 10031;
            this.txtItemBarcode.Leave += new System.EventHandler(this.txtItemBarcode_Leave);
            // 
            // custDataGridView
            // 
            this.custDataGridView.AllowUserToAddRows = false;
            this.custDataGridView.AllowUserToDeleteRows = false;
            this.custDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.custDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.custDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.custDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.custDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Quantity,
            this.qcontractyear,
            this.QInvno});
            this.custDataGridView.EnableHeadersVisualStyles = false;
            this.custDataGridView.Location = new System.Drawing.Point(24, 186);
            this.custDataGridView.Name = "custDataGridView";
            this.custDataGridView.ReadOnly = true;
            this.custDataGridView.Size = new System.Drawing.Size(717, 103);
            this.custDataGridView.TabIndex = 10032;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Qty";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // qcontractyear
            // 
            this.qcontractyear.DataPropertyName = "ItemId";
            this.qcontractyear.HeaderText = "Item";
            this.qcontractyear.Name = "qcontractyear";
            this.qcontractyear.ReadOnly = true;
            // 
            // QInvno
            // 
            this.QInvno.DataPropertyName = "Description";
            this.QInvno.HeaderText = "Desc";
            this.QInvno.Name = "QInvno";
            this.QInvno.ReadOnly = true;
            // 
            // frmMxBookShipping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(786, 438);
            this.Controls.Add(this.custDataGridView);
            this.Controls.Add(this.txtItemBarcode);
            this.Controls.Add(this.txtClientIdLookup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plnTracking);
            this.Controls.Add(this.lblBkLoc);
            this.Controls.Add(this.lblBkLocation);
            this.Controls.Add(this.chkRemake);
            this.Controls.Add(this.lbllastscanlbl);
            this.Controls.Add(this.lblLastScan);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl1);
            this.Name = "frmMxBookShipping";
            this.Text = "Mixbook Shipping";
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.lbl1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtDateTime, 0);
            this.Controls.SetChildIndex(this.lblLastScan, 0);
            this.Controls.SetChildIndex(this.lbllastscanlbl, 0);
            this.Controls.SetChildIndex(this.chkRemake, 0);
            this.Controls.SetChildIndex(this.lblBkLocation, 0);
            this.Controls.SetChildIndex(this.lblBkLoc, 0);
            this.Controls.SetChildIndex(this.plnTracking, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtClientIdLookup, 0);
            this.Controls.SetChildIndex(this.txtItemBarcode, 0);
            this.Controls.SetChildIndex(this.custDataGridView, 0);
            this.plnTracking.ResumeLayout(false);
            this.plnTracking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBkLoc;
        private System.Windows.Forms.Label lblBkLocation;
        private System.Windows.Forms.CheckBox chkRemake;
        private System.Windows.Forms.Label lbllastscanlbl;
        private System.Windows.Forms.Label lblLastScan;
        private System.Windows.Forms.TextBox txtDateTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Panel plnTracking;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTrackingNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientIdLookup;
        private System.Windows.Forms.TextBox txtItemBarcode;
        private System.Windows.Forms.DataGridView custDataGridView;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn qcontractyear;
        private System.Windows.Forms.DataGridViewTextBoxColumn QInvno;
        private System.Windows.Forms.BindingSource bsItems;
    }
}
