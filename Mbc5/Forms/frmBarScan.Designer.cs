namespace Mbc5.Forms.MixBook
{
    partial class frmBarScan
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
            this.txtBarCode = new System.Windows.Forms.MaskedTextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlRemake = new System.Windows.Forms.Panel();
            this.pnlQtyInner = new System.Windows.Forms.Panel();
            this.txtRemakeQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReasonCode = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblLastScan = new System.Windows.Forms.Label();
            this.lbllastscanlbl = new System.Windows.Forms.Label();
            this.chkRemake = new System.Windows.Forms.CheckBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.chkPrToLabeler = new System.Windows.Forms.CheckBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnClearPrinter = new System.Windows.Forms.Button();
            this.pnlBookLocation = new System.Windows.Forms.Panel();
            this.lblBkLocation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHoldLocation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlHoldLocation = new System.Windows.Forms.Panel();
            this.cmbLogin = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlImpersonate = new System.Windows.Forms.Panel();
            this.txtTrackingNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlTracking = new System.Windows.Forms.Panel();
            this.pnlQty = new System.Windows.Forms.Panel();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQtyToScan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblScanQty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlRemake.SuspendLayout();
            this.pnlQtyInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlBookLocation.SuspendLayout();
            this.pnlHoldLocation.SuspendLayout();
            this.pnlImpersonate.SuspendLayout();
            this.pnlTracking.SuspendLayout();
            this.pnlQty.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(17, 19);
            // 
            // txtBarCode
            // 
            this.txtBarCode.AsciiOnly = true;
            this.txtBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarCode.Location = new System.Drawing.Point(169, 40);
            this.txtBarCode.Mask = ">LLL0000000CCLL";
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(143, 22);
            this.txtBarCode.TabIndex = 0;
            this.txtBarCode.Leave += new System.EventHandler(this.txtBarCode_Leave);
            this.txtBarCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtBarCode_Validating);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(39, 40);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(131, 16);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Scan Book Bar code";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(84, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlRemake
            // 
            this.pnlRemake.Controls.Add(this.pnlQtyInner);
            this.pnlRemake.Controls.Add(this.label7);
            this.pnlRemake.Controls.Add(this.txtReasonCode);
            this.pnlRemake.Location = new System.Drawing.Point(102, 96);
            this.pnlRemake.Name = "pnlRemake";
            this.pnlRemake.Size = new System.Drawing.Size(235, 66);
            this.pnlRemake.TabIndex = 10018;
            this.pnlRemake.Visible = false;
            // 
            // pnlQtyInner
            // 
            this.pnlQtyInner.Controls.Add(this.txtRemakeQty);
            this.pnlQtyInner.Controls.Add(this.label10);
            this.pnlQtyInner.Location = new System.Drawing.Point(3, 27);
            this.pnlQtyInner.Name = "pnlQtyInner";
            this.pnlQtyInner.Size = new System.Drawing.Size(217, 29);
            this.pnlQtyInner.TabIndex = 10020;
            // 
            // txtRemakeQty
            // 
            this.txtRemakeQty.Location = new System.Drawing.Point(112, 4);
            this.txtRemakeQty.MaxLength = 3;
            this.txtRemakeQty.Name = "txtRemakeQty";
            this.txtRemakeQty.Size = new System.Drawing.Size(100, 20);
            this.txtRemakeQty.TabIndex = 10020;
            this.txtRemakeQty.Text = "0";
            this.txtRemakeQty.Leave += new System.EventHandler(this.txtRemakeQty_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 10021;
            this.label10.Text = "QTY To Remake";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 10018;
            this.label7.Text = "Reason Code";
            // 
            // txtReasonCode
            // 
            this.txtReasonCode.Location = new System.Drawing.Point(114, 1);
            this.txtReasonCode.MaxLength = 2;
            this.txtReasonCode.Name = "txtReasonCode";
            this.txtReasonCode.Size = new System.Drawing.Size(100, 20);
            this.txtReasonCode.TabIndex = 2;
            this.txtReasonCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtReasonCode_KeyUp);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblLastScan
            // 
            this.lblLastScan.AutoSize = true;
            this.lblLastScan.BackColor = System.Drawing.Color.Gold;
            this.lblLastScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastScan.Location = new System.Drawing.Point(112, 7);
            this.lblLastScan.Name = "lblLastScan";
            this.lblLastScan.Size = new System.Drawing.Size(0, 17);
            this.lblLastScan.TabIndex = 10007;
            // 
            // lbllastscanlbl
            // 
            this.lbllastscanlbl.AutoSize = true;
            this.lbllastscanlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllastscanlbl.Location = new System.Drawing.Point(39, 7);
            this.lbllastscanlbl.Name = "lbllastscanlbl";
            this.lbllastscanlbl.Size = new System.Drawing.Size(71, 17);
            this.lbllastscanlbl.TabIndex = 10008;
            this.lbllastscanlbl.Text = "Last Scan";
            // 
            // chkRemake
            // 
            this.chkRemake.AutoSize = true;
            this.chkRemake.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRemake.Location = new System.Drawing.Point(559, 39);
            this.chkRemake.Name = "chkRemake";
            this.chkRemake.Size = new System.Drawing.Size(78, 20);
            this.chkRemake.TabIndex = 0;
            this.chkRemake.Text = "Remake";
            this.chkRemake.UseVisualStyleBackColor = true;
            this.chkRemake.CheckedChanged += new System.EventHandler(this.chkRemake_CheckedChanged);
            this.chkRemake.Click += new System.EventHandler(this.chkRemake_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 35;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookPkgList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 178);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(70, 41);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // chkPrToLabeler
            // 
            this.chkPrToLabeler.AutoSize = true;
            this.chkPrToLabeler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrToLabeler.Location = new System.Drawing.Point(559, 60);
            this.chkPrToLabeler.Name = "chkPrToLabeler";
            this.chkPrToLabeler.Size = new System.Drawing.Size(118, 20);
            this.chkPrToLabeler.TabIndex = 2;
            this.chkPrToLabeler.Text = "Prnt To Labeler";
            this.chkPrToLabeler.UseVisualStyleBackColor = true;
            this.chkPrToLabeler.Visible = false;
            this.chkPrToLabeler.CheckedChanged += new System.EventHandler(this.chkPrToLabeler_CheckedChanged);
            this.chkPrToLabeler.Click += new System.EventHandler(this.chkPrToLabeler_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.DocumentMapWidth = 35;
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookPkgList.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 125);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(67, 46);
            this.reportViewer2.TabIndex = 10020;
            this.reportViewer2.Visible = false;
            // 
            // btnClearPrinter
            // 
            this.btnClearPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPrinter.Location = new System.Drawing.Point(187, 200);
            this.btnClearPrinter.Name = "btnClearPrinter";
            this.btnClearPrinter.Size = new System.Drawing.Size(87, 23);
            this.btnClearPrinter.TabIndex = 10021;
            this.btnClearPrinter.TabStop = false;
            this.btnClearPrinter.Text = "Clear Printer";
            this.btnClearPrinter.UseVisualStyleBackColor = true;
            this.btnClearPrinter.Visible = false;
            this.btnClearPrinter.Click += new System.EventHandler(this.btnClearPrinter_Click);
            // 
            // pnlBookLocation
            // 
            this.pnlBookLocation.Controls.Add(this.lblBkLocation);
            this.pnlBookLocation.Controls.Add(this.label1);
            this.pnlBookLocation.Location = new System.Drawing.Point(385, 4);
            this.pnlBookLocation.Name = "pnlBookLocation";
            this.pnlBookLocation.Size = new System.Drawing.Size(265, 29);
            this.pnlBookLocation.TabIndex = 10023;
            this.pnlBookLocation.Visible = false;
            this.pnlBookLocation.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBookLocation_Paint);
            // 
            // lblBkLocation
            // 
            this.lblBkLocation.AutoSize = true;
            this.lblBkLocation.BackColor = System.Drawing.Color.Gold;
            this.lblBkLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBkLocation.Location = new System.Drawing.Point(157, 6);
            this.lblBkLocation.Name = "lblBkLocation";
            this.lblBkLocation.Size = new System.Drawing.Size(0, 17);
            this.lblBkLocation.TabIndex = 10016;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last Scan Book Location:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblHoldLocation
            // 
            this.lblHoldLocation.AutoSize = true;
            this.lblHoldLocation.Location = new System.Drawing.Point(91, 5);
            this.lblHoldLocation.Name = "lblHoldLocation";
            this.lblHoldLocation.Size = new System.Drawing.Size(0, 13);
            this.lblHoldLocation.TabIndex = 10024;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 10025;
            this.label8.Text = "Hold Location";
            // 
            // pnlHoldLocation
            // 
            this.pnlHoldLocation.Controls.Add(this.label8);
            this.pnlHoldLocation.Controls.Add(this.lblHoldLocation);
            this.pnlHoldLocation.Location = new System.Drawing.Point(511, 159);
            this.pnlHoldLocation.Name = "pnlHoldLocation";
            this.pnlHoldLocation.Size = new System.Drawing.Size(160, 30);
            this.pnlHoldLocation.TabIndex = 10026;
            this.pnlHoldLocation.Visible = false;
            // 
            // cmbLogin
            // 
            this.cmbLogin.FormattingEnabled = true;
            this.cmbLogin.Items.AddRange(new object[] {
            " ",
            "PRESS",
            "BINDING",
            "TRIMMING",
            "ONBOARD",
            "QUALITY",
            "SHIPPING"});
            this.cmbLogin.Location = new System.Drawing.Point(82, 6);
            this.cmbLogin.Name = "cmbLogin";
            this.cmbLogin.Size = new System.Drawing.Size(169, 21);
            this.cmbLogin.TabIndex = 10027;
            this.cmbLogin.SelectedValueChanged += new System.EventHandler(this.cmbLogin_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(2, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 10028;
            this.label9.Text = "Impersonate";
            // 
            // pnlImpersonate
            // 
            this.pnlImpersonate.Controls.Add(this.cmbLogin);
            this.pnlImpersonate.Controls.Add(this.label9);
            this.pnlImpersonate.Location = new System.Drawing.Point(385, 192);
            this.pnlImpersonate.Name = "pnlImpersonate";
            this.pnlImpersonate.Size = new System.Drawing.Size(286, 31);
            this.pnlImpersonate.TabIndex = 10029;
            this.pnlImpersonate.Visible = false;
            // 
            // txtTrackingNumber
            // 
            this.txtTrackingNumber.Location = new System.Drawing.Point(81, 2);
            this.txtTrackingNumber.Name = "txtTrackingNumber";
            this.txtTrackingNumber.Size = new System.Drawing.Size(294, 20);
            this.txtTrackingNumber.TabIndex = 10030;
            this.txtTrackingNumber.Leave += new System.EventHandler(this.txtTrackingNumber_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 10031;
            this.label5.Text = "Tracking #";
            // 
            // pnlTracking
            // 
            this.pnlTracking.Controls.Add(this.txtTrackingNumber);
            this.pnlTracking.Controls.Add(this.label5);
            this.pnlTracking.Location = new System.Drawing.Point(42, 65);
            this.pnlTracking.Name = "pnlTracking";
            this.pnlTracking.Size = new System.Drawing.Size(388, 25);
            this.pnlTracking.TabIndex = 10032;
            this.pnlTracking.Visible = false;
            // 
            // pnlQty
            // 
            this.pnlQty.Controls.Add(this.txtLocation);
            this.pnlQty.Controls.Add(this.label4);
            this.pnlQty.Controls.Add(this.txtQtyToScan);
            this.pnlQty.Controls.Add(this.label3);
            this.pnlQty.Controls.Add(this.lblScanQty);
            this.pnlQty.Controls.Add(this.label2);
            this.pnlQty.Location = new System.Drawing.Point(372, 93);
            this.pnlQty.Name = "pnlQty";
            this.pnlQty.Size = new System.Drawing.Size(299, 57);
            this.pnlQty.TabIndex = 10033;
            this.pnlQty.Visible = false;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(227, 30);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(64, 20);
            this.txtLocation.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(165, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Location";
            // 
            // txtQtyToScan
            // 
            this.txtQtyToScan.Location = new System.Drawing.Point(227, 4);
            this.txtQtyToScan.Name = "txtQtyToScan";
            this.txtQtyToScan.Size = new System.Drawing.Size(64, 20);
            this.txtQtyToScan.TabIndex = 2;
            this.txtQtyToScan.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(147, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Qty to Scan";
            this.label3.Visible = false;
            // 
            // lblScanQty
            // 
            this.lblScanQty.AutoSize = true;
            this.lblScanQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanQty.Location = new System.Drawing.Point(124, 4);
            this.lblScanQty.Name = "lblScanQty";
            this.lblScanQty.Size = new System.Drawing.Size(14, 13);
            this.lblScanQty.TabIndex = 26;
            this.lblScanQty.Text = "0";
            this.lblScanQty.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Quantity Scanned";
            this.label2.Visible = false;
            // 
            // frmBarScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(691, 242);
            this.Controls.Add(this.pnlQty);
            this.Controls.Add(this.pnlTracking);
            this.Controls.Add(this.pnlImpersonate);
            this.Controls.Add(this.pnlHoldLocation);
            this.Controls.Add(this.pnlBookLocation);
            this.Controls.Add(this.btnClearPrinter);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.chkPrToLabeler);
            this.Controls.Add(this.pnlRemake);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.chkRemake);
            this.Controls.Add(this.lbllastscanlbl);
            this.Controls.Add(this.lblLastScan);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.lbl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBarScan";
            this.Text = "Barcode Scan Form";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMxBookBarScan_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.lbl1, 0);
            this.Controls.SetChildIndex(this.txtBarCode, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.lblLastScan, 0);
            this.Controls.SetChildIndex(this.lbllastscanlbl, 0);
            this.Controls.SetChildIndex(this.chkRemake, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.pnlRemake, 0);
            this.Controls.SetChildIndex(this.chkPrToLabeler, 0);
            this.Controls.SetChildIndex(this.reportViewer2, 0);
            this.Controls.SetChildIndex(this.btnClearPrinter, 0);
            this.Controls.SetChildIndex(this.pnlBookLocation, 0);
            this.Controls.SetChildIndex(this.pnlHoldLocation, 0);
            this.Controls.SetChildIndex(this.pnlImpersonate, 0);
            this.Controls.SetChildIndex(this.pnlTracking, 0);
            this.Controls.SetChildIndex(this.pnlQty, 0);
            this.pnlRemake.ResumeLayout(false);
            this.pnlRemake.PerformLayout();
            this.pnlQtyInner.ResumeLayout(false);
            this.pnlQtyInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlBookLocation.ResumeLayout(false);
            this.pnlBookLocation.PerformLayout();
            this.pnlHoldLocation.ResumeLayout(false);
            this.pnlHoldLocation.PerformLayout();
            this.pnlImpersonate.ResumeLayout(false);
            this.pnlImpersonate.PerformLayout();
            this.pnlTracking.ResumeLayout(false);
            this.pnlTracking.PerformLayout();
            this.pnlQty.ResumeLayout(false);
            this.pnlQty.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtBarCode;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbllastscanlbl;
        private System.Windows.Forms.Label lblLastScan;
        private System.Windows.Forms.CheckBox chkRemake;
        private System.Windows.Forms.Panel pnlRemake;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReasonCode;
        private System.Windows.Forms.CheckBox chkPrToLabeler;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnClearPrinter;
        private System.Windows.Forms.Panel pnlBookLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHoldLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbLogin;
        private System.Windows.Forms.Panel pnlImpersonate;
        private System.Windows.Forms.Panel pnlQtyInner;
        private System.Windows.Forms.TextBox txtRemakeQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlTracking;
        private System.Windows.Forms.TextBox txtTrackingNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlQty;
        public System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQtyToScan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblScanQty;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblHoldLocation;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        public System.Windows.Forms.Label lblBkLocation;
    }
}
