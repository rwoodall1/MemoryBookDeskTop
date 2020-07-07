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
            this.txtBarCode = new System.Windows.Forms.MaskedTextBox();
            this.txtDateTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlQty = new System.Windows.Forms.Panel();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQtyToScan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblScanQty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.plnTracking = new System.Windows.Forms.Panel();
            this.txtTrackingNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlQty.SuspendLayout();
            this.plnTracking.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(17, 19);
            // 
            // txtBarCode
            // 
            this.txtBarCode.AsciiOnly = true;
            this.txtBarCode.Location = new System.Drawing.Point(169, 22);
            this.txtBarCode.Mask = ">LLL0000000CLL";
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(143, 20);
            this.txtBarCode.TabIndex = 1;
            this.txtBarCode.Leave += new System.EventHandler(this.txtBarCode_Leave);
            // 
            // txtDateTime
            // 
            this.txtDateTime.Location = new System.Drawing.Point(401, 22);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.ReadOnly = true;
            this.txtDateTime.Size = new System.Drawing.Size(143, 20);
            this.txtDateTime.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(318, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Date && Time";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(39, 22);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(124, 13);
            this.lbl1.TabIndex = 11;
            this.lbl1.Text = "Scan Book Bar code";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(293, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(199, 139);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 6;
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
            this.pnlQty.Location = new System.Drawing.Point(255, 48);
            this.pnlQty.Name = "pnlQty";
            this.pnlQty.Size = new System.Drawing.Size(299, 57);
            this.pnlQty.TabIndex = 25;
            this.pnlQty.Visible = false;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(227, 30);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(64, 20);
            this.txtLocation.TabIndex = 5;
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
            this.txtQtyToScan.TabIndex = 4;
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
            // plnTracking
            // 
            this.plnTracking.Controls.Add(this.txtWeight);
            this.plnTracking.Controls.Add(this.label5);
            this.plnTracking.Controls.Add(this.txtTrackingNo);
            this.plnTracking.Controls.Add(this.label13);
            this.plnTracking.Location = new System.Drawing.Point(93, 48);
            this.plnTracking.Name = "plnTracking";
            this.plnTracking.Size = new System.Drawing.Size(322, 57);
            this.plnTracking.TabIndex = 10006;
            this.plnTracking.Visible = false;
            this.plnTracking.Leave += new System.EventHandler(this.plnTracking_Leave);
            // 
            // txtTrackingNo
            // 
            this.txtTrackingNo.Location = new System.Drawing.Point(75, 3);
            this.txtTrackingNo.Name = "txtTrackingNo";
            this.txtTrackingNo.Size = new System.Drawing.Size(244, 20);
            this.txtTrackingNo.TabIndex = 2;
            this.txtTrackingNo.Leave += new System.EventHandler(this.txtTrackingNo_Leave);
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
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(76, 26);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(54, 20);
            this.txtWeight.TabIndex = 3;
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
            // frmMxBookBarScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(664, 174);
            this.Controls.Add(this.plnTracking);
            this.Controls.Add(this.pnlQty);
            this.Controls.Add(this.btnCancel);
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
            this.Controls.SetChildIndex(this.lbl1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtDateTime, 0);
            this.Controls.SetChildIndex(this.txtBarCode, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.pnlQty, 0);
            this.Controls.SetChildIndex(this.plnTracking, 0);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.pnlQty.ResumeLayout(false);
            this.pnlQty.PerformLayout();
            this.plnTracking.ResumeLayout(false);
            this.plnTracking.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtBarCode;
        private System.Windows.Forms.TextBox txtDateTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlQty;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQtyToScan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblScanQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel plnTracking;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTrackingNo;
        private System.Windows.Forms.Label label13;
    }
}
