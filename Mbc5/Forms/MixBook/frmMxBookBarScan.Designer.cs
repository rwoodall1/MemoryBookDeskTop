namespace Mbc5.Forms.MixBook
{
    partial class frmMxBookBarScan
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
            this.txtDateTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlQty = new System.Windows.Forms.Panel();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQtyToScan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblScanQty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlRemake = new System.Windows.Forms.Panel();
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemakeQty = new System.Windows.Forms.TextBox();
            this.pnlQty.SuspendLayout();
            this.pnlRemake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlBookLocation.SuspendLayout();
            this.pnlHoldLocation.SuspendLayout();
            this.pnlImpersonate.SuspendLayout();
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
            // txtDateTime
            // 
            this.txtDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTime.Location = new System.Drawing.Point(401, 40);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.ReadOnly = true;
            this.txtDateTime.Size = new System.Drawing.Size(143, 22);
            this.txtDateTime.TabIndex = 15;
            this.txtDateTime.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(318, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Date && Time";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(39, 40);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(132, 16);
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
            // pnlQty
            // 
            this.pnlQty.Controls.Add(this.txtLocation);
            this.pnlQty.Controls.Add(this.label4);
            this.pnlQty.Controls.Add(this.txtQtyToScan);
            this.pnlQty.Controls.Add(this.label3);
            this.pnlQty.Controls.Add(this.lblScanQty);
            this.pnlQty.Controls.Add(this.label2);
            this.pnlQty.Location = new System.Drawing.Point(373, 96);
            this.pnlQty.Name = "pnlQty";
            this.pnlQty.Size = new System.Drawing.Size(299, 57);
            this.pnlQty.TabIndex = 2;
            this.pnlQty.Visible = false;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(227, 30);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(64, 20);
            this.txtLocation.TabIndex = 3;
            this.txtLocation.Validating += new System.ComponentModel.CancelEventHandler(this.txtLocation_Validating);
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
            // 
            // pnlRemake
            // 
            this.pnlRemake.Controls.Add(this.txtRemakeQty);
            this.pnlRemake.Controls.Add(this.label5);
            this.pnlRemake.Controls.Add(this.label7);
            this.pnlRemake.Controls.Add(this.txtReasonCode);
            this.pnlRemake.Location = new System.Drawing.Point(100, 80);
            this.pnlRemake.Name = "pnlRemake";
            this.pnlRemake.Size = new System.Drawing.Size(235, 66);
            this.pnlRemake.TabIndex = 10018;
            this.pnlRemake.Visible = false;
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
            this.txtReasonCode.TabIndex = 3;
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
            this.chkRemake.Size = new System.Drawing.Size(79, 20);
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
            this.reportViewer1.Location = new System.Drawing.Point(27, 73);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(67, 46);
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
            this.chkPrToLabeler.Size = new System.Drawing.Size(119, 20);
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
            this.btnClearPrinter.Location = new System.Drawing.Point(186, 200);
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
            "QUALITY"});
            this.cmbLogin.Location = new System.Drawing.Point(82, 6);
            this.cmbLogin.Name = "cmbLogin";
            this.cmbLogin.Size = new System.Drawing.Size(169, 21);
            this.cmbLogin.TabIndex = 10027;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 10019;
            this.label5.Text = "QTY To Remake";
            // 
            // txtRemakeQty
            // 
            this.txtRemakeQty.Location = new System.Drawing.Point(113, 30);
            this.txtRemakeQty.MaxLength = 3;
            this.txtRemakeQty.Name = "txtRemakeQty";
            this.txtRemakeQty.Size = new System.Drawing.Size(100, 20);
            this.txtRemakeQty.TabIndex = 10020;
            this.txtRemakeQty.Text = "1";
            // 
            // frmMxBookBarScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(691, 253);
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
            this.Controls.Add(this.pnlQty);
            this.Controls.Add(this.lblLastScan);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMxBookBarScan";
            this.Text = "Mixbook Scan Form";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMxBookBarScan_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.lbl1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtDateTime, 0);
            this.Controls.SetChildIndex(this.txtBarCode, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.lblLastScan, 0);
            this.Controls.SetChildIndex(this.pnlQty, 0);
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
            this.pnlQty.ResumeLayout(false);
            this.pnlQty.PerformLayout();
            this.pnlRemake.ResumeLayout(false);
            this.pnlRemake.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlBookLocation.ResumeLayout(false);
            this.pnlBookLocation.PerformLayout();
            this.pnlHoldLocation.ResumeLayout(false);
            this.pnlHoldLocation.PerformLayout();
            this.pnlImpersonate.ResumeLayout(false);
            this.pnlImpersonate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtBarCode;
        private System.Windows.Forms.TextBox txtDateTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlQty;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQtyToScan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblScanQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbllastscanlbl;
        private System.Windows.Forms.Label lblLastScan;
        private System.Windows.Forms.CheckBox chkRemake;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel pnlRemake;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReasonCode;
        private System.Windows.Forms.CheckBox chkPrToLabeler;
        private System.Windows.Forms.PrintDialog printDialog1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.Button btnClearPrinter;
        private System.Windows.Forms.Panel pnlBookLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBkLocation;
        private System.Windows.Forms.Panel pnlHoldLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblHoldLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbLogin;
        private System.Windows.Forms.Panel pnlImpersonate;
        private System.Windows.Forms.TextBox txtRemakeQty;
        private System.Windows.Forms.Label label5;
    }
}
