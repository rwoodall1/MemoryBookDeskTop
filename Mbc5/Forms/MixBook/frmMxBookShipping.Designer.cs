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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.txtClientIdLookup = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bsItems = new System.Windows.Forms.BindingSource(this.components);
            this.btnShip = new System.Windows.Forms.Button();
            this.btnItemReset = new System.Windows.Forms.Button();
            this.btnShipmentReset = new System.Windows.Forms.Button();
            this.btnEnamble = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblShpName = new System.Windows.Forms.Label();
            this.lblShpMethod = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.custDataGridView = new System.Windows.Forms.DataGridView();
            this.Invno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qcontractyear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QInvno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemBarcode = new System.Windows.Forms.TextBox();
            this.btnAddPkg = new System.Windows.Forms.Button();
            this.plnTracking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(20, 22);
            this.basePanel.TabIndex = 5;
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
            this.chkRemake.Location = new System.Drawing.Point(630, 50);
            this.chkRemake.Name = "chkRemake";
            this.chkRemake.Size = new System.Drawing.Size(79, 20);
            this.chkRemake.TabIndex = 11;
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
            this.txtDateTime.Location = new System.Drawing.Point(481, 51);
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
            this.label6.Location = new System.Drawing.Point(398, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 10020;
            this.label6.Text = "Date && Time";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(1, 4);
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
            this.plnTracking.Controls.Add(this.txtClientIdLookup);
            this.plnTracking.Controls.Add(this.lbl1);
            this.plnTracking.Location = new System.Drawing.Point(38, 51);
            this.plnTracking.Name = "plnTracking";
            this.plnTracking.Size = new System.Drawing.Size(339, 82);
            this.plnTracking.TabIndex = 0;
            this.plnTracking.EnabledChanged += new System.EventHandler(this.plnTracking_EnabledChanged);
            this.plnTracking.Leave += new System.EventHandler(this.plnTracking_Leave);
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(76, 59);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(54, 20);
            this.txtWeight.TabIndex = 3;
            this.txtWeight.DoubleClick += new System.EventHandler(this.txtWeight_DoubleClick);
            this.txtWeight.Leave += new System.EventHandler(this.txtWeight_Leave);
            this.txtWeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtWeight_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Weight";
            // 
            // txtTrackingNo
            // 
            this.txtTrackingNo.Location = new System.Drawing.Point(75, 36);
            this.txtTrackingNo.Name = "txtTrackingNo";
            this.txtTrackingNo.Size = new System.Drawing.Size(220, 20);
            this.txtTrackingNo.TabIndex = 2;
            this.txtTrackingNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtTrackingNo_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Tracking #";
            // 
            // txtClientIdLookup
            // 
            this.txtClientIdLookup.Location = new System.Drawing.Point(160, 4);
            this.txtClientIdLookup.Name = "txtClientIdLookup";
            this.txtClientIdLookup.Size = new System.Drawing.Size(135, 20);
            this.txtClientIdLookup.TabIndex = 1;
            this.txtClientIdLookup.Leave += new System.EventHandler(this.txtClientIdLookup_Leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnShip
            // 
            this.btnShip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShip.Location = new System.Drawing.Point(37, 339);
            this.btnShip.Name = "btnShip";
            this.btnShip.Size = new System.Drawing.Size(121, 34);
            this.btnShip.TabIndex = 7;
            this.btnShip.Text = "Mark As Shipped";
            this.btnShip.UseVisualStyleBackColor = true;
            this.btnShip.Click += new System.EventHandler(this.btnShip_Click);
            // 
            // btnItemReset
            // 
            this.btnItemReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnItemReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemReset.Location = new System.Drawing.Point(487, 339);
            this.btnItemReset.Name = "btnItemReset";
            this.btnItemReset.Size = new System.Drawing.Size(121, 34);
            this.btnItemReset.TabIndex = 8;
            this.btnItemReset.Text = "Reset Items";
            this.btnItemReset.UseVisualStyleBackColor = true;
            this.btnItemReset.Click += new System.EventHandler(this.btnItemReset_Click);
            // 
            // btnShipmentReset
            // 
            this.btnShipmentReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShipmentReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShipmentReset.Location = new System.Drawing.Point(615, 339);
            this.btnShipmentReset.Name = "btnShipmentReset";
            this.btnShipmentReset.Size = new System.Drawing.Size(121, 34);
            this.btnShipmentReset.TabIndex = 9;
            this.btnShipmentReset.Text = "Clear All Shipments";
            this.btnShipmentReset.UseVisualStyleBackColor = true;
            this.btnShipmentReset.Click += new System.EventHandler(this.btnShipmentReset_Click);
            // 
            // btnEnamble
            // 
            this.btnEnamble.Location = new System.Drawing.Point(16, 52);
            this.btnEnamble.Name = "btnEnamble";
            this.btnEnamble.Size = new System.Drawing.Size(17, 23);
            this.btnEnamble.TabIndex = 10;
            this.btnEnamble.Text = ":";
            this.btnEnamble.UseVisualStyleBackColor = true;
            this.btnEnamble.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(469, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 10033;
            this.label2.Text = "Ship Name";
            // 
            // lblShpName
            // 
            this.lblShpName.AutoSize = true;
            this.lblShpName.BackColor = System.Drawing.Color.LightYellow;
            this.lblShpName.Location = new System.Drawing.Point(548, 94);
            this.lblShpName.Name = "lblShpName";
            this.lblShpName.Size = new System.Drawing.Size(0, 13);
            this.lblShpName.TabIndex = 10034;
            // 
            // lblShpMethod
            // 
            this.lblShpMethod.AutoSize = true;
            this.lblShpMethod.BackColor = System.Drawing.Color.LightYellow;
            this.lblShpMethod.Location = new System.Drawing.Point(548, 111);
            this.lblShpMethod.Name = "lblShpMethod";
            this.lblShpMethod.Size = new System.Drawing.Size(0, 13);
            this.lblShpMethod.TabIndex = 10036;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(459, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 10035;
            this.label4.Text = "Ship Method";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Controls.Add(this.txt1);
            this.pnlGrid.Controls.Add(this.custDataGridView);
            this.pnlGrid.Controls.Add(this.label1);
            this.pnlGrid.Controls.Add(this.txtItemBarcode);
            this.pnlGrid.Enabled = false;
            this.pnlGrid.Location = new System.Drawing.Point(37, 136);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(709, 179);
            this.pnlGrid.TabIndex = 10037;
            // 
            // txt1
            // 
            this.txt1.BackColor = System.Drawing.SystemColors.Control;
            this.txt1.Location = new System.Drawing.Point(285, 9);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(1, 20);
            this.txt1.TabIndex = 5;
            this.txt1.Enter += new System.EventHandler(this.txt1_Enter);
            // 
            // custDataGridView
            // 
            this.custDataGridView.AllowUserToAddRows = false;
            this.custDataGridView.AllowUserToDeleteRows = false;
            this.custDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.custDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.custDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.custDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.custDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Invno,
            this.Quantity,
            this.qcontractyear,
            this.QInvno});
            this.custDataGridView.EnableHeadersVisualStyles = false;
            this.custDataGridView.Location = new System.Drawing.Point(10, 37);
            this.custDataGridView.Name = "custDataGridView";
            this.custDataGridView.ReadOnly = true;
            this.custDataGridView.Size = new System.Drawing.Size(689, 139);
            this.custDataGridView.TabIndex = 6;
            this.custDataGridView.TabStop = false;
            // 
            // Invno
            // 
            this.Invno.DataPropertyName = "Invno";
            this.Invno.FillWeight = 35.61034F;
            this.Invno.HeaderText = "Invo";
            this.Invno.Name = "Invno";
            this.Invno.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.FillWeight = 28.91615F;
            this.Quantity.HeaderText = "Qty";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // qcontractyear
            // 
            this.qcontractyear.DataPropertyName = "ItemId";
            this.qcontractyear.FillWeight = 35F;
            this.qcontractyear.HeaderText = "Item";
            this.qcontractyear.Name = "qcontractyear";
            this.qcontractyear.ReadOnly = true;
            // 
            // QInvno
            // 
            this.QInvno.DataPropertyName = "Description";
            this.QInvno.FillWeight = 81.66639F;
            this.QInvno.HeaderText = "Desc";
            this.QInvno.Name = "QInvno";
            this.QInvno.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 10030;
            this.label1.Text = "Scan Item Bar Code";
            // 
            // txtItemBarcode
            // 
            this.txtItemBarcode.Location = new System.Drawing.Point(152, 11);
            this.txtItemBarcode.Name = "txtItemBarcode";
            this.txtItemBarcode.Size = new System.Drawing.Size(124, 20);
            this.txtItemBarcode.TabIndex = 4;
            this.txtItemBarcode.Leave += new System.EventHandler(this.txtItemBarcode_Leave);
            this.txtItemBarcode.Validating += new System.ComponentModel.CancelEventHandler(this.txtItemBarcode_Validating);
            // 
            // btnAddPkg
            // 
            this.btnAddPkg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddPkg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPkg.Location = new System.Drawing.Point(174, 339);
            this.btnAddPkg.Name = "btnAddPkg";
            this.btnAddPkg.Size = new System.Drawing.Size(121, 34);
            this.btnAddPkg.TabIndex = 10038;
            this.btnAddPkg.Text = "Add Package To Shipment";
            this.btnAddPkg.UseVisualStyleBackColor = true;
            this.btnAddPkg.Click += new System.EventHandler(this.btnAddPkg_Click);
            // 
            // frmMxBookShipping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(758, 411);
            this.Controls.Add(this.btnAddPkg);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblShpMethod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblShpName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnamble);
            this.Controls.Add(this.btnShipmentReset);
            this.Controls.Add(this.btnItemReset);
            this.Controls.Add(this.btnShip);
            this.Controls.Add(this.plnTracking);
            this.Controls.Add(this.lblBkLoc);
            this.Controls.Add(this.lblBkLocation);
            this.Controls.Add(this.chkRemake);
            this.Controls.Add(this.lbllastscanlbl);
            this.Controls.Add(this.lblLastScan);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.label6);
            this.MinimumSize = new System.Drawing.Size(774, 450);
            this.Name = "frmMxBookShipping";
            this.Text = "Mixbook Shipping";
            this.Load += new System.EventHandler(this.frmMxBookShipping_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtDateTime, 0);
            this.Controls.SetChildIndex(this.lblLastScan, 0);
            this.Controls.SetChildIndex(this.lbllastscanlbl, 0);
            this.Controls.SetChildIndex(this.chkRemake, 0);
            this.Controls.SetChildIndex(this.lblBkLocation, 0);
            this.Controls.SetChildIndex(this.lblBkLoc, 0);
            this.Controls.SetChildIndex(this.plnTracking, 0);
            this.Controls.SetChildIndex(this.btnShip, 0);
            this.Controls.SetChildIndex(this.btnItemReset, 0);
            this.Controls.SetChildIndex(this.btnShipmentReset, 0);
            this.Controls.SetChildIndex(this.btnEnamble, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblShpName, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblShpMethod, 0);
            this.Controls.SetChildIndex(this.pnlGrid, 0);
            this.Controls.SetChildIndex(this.btnAddPkg, 0);
            this.plnTracking.ResumeLayout(false);
            this.plnTracking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).EndInit();
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
        private System.Windows.Forms.TextBox txtClientIdLookup;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource bsItems;
        private System.Windows.Forms.Button btnShipmentReset;
        private System.Windows.Forms.Button btnItemReset;
        private System.Windows.Forms.Button btnShip;
        private System.Windows.Forms.Button btnEnamble;
        private System.Windows.Forms.Label lblShpName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblShpMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.DataGridView custDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn qcontractyear;
        private System.Windows.Forms.DataGridViewTextBoxColumn QInvno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemBarcode;
        private System.Windows.Forms.Button btnAddPkg;
    }
}
