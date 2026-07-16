namespace Mbc5.Forms.Tukios
{
    partial class frmTukiosBookChk
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
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.bsDescriptions = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUPSLabel = new System.Windows.Forms.TextBox();
            this.btnShipped = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClientOrderId = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtempty = new System.Windows.Forms.TextBox();
            this.lstInvno = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsDescriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(22, 16);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(12, 71);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(339, 20);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.Enter += new System.EventHandler(this.txtBarcode_Enter);
            this.txtBarcode.Validating += new System.ComponentModel.CancelEventHandler(this.txtBarcode_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Book Barcode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "UPS Label";
            // 
            // txtUPSLabel
            // 
            this.txtUPSLabel.Location = new System.Drawing.Point(12, 123);
            this.txtUPSLabel.Name = "txtUPSLabel";
            this.txtUPSLabel.Size = new System.Drawing.Size(339, 20);
            this.txtUPSLabel.TabIndex = 2;
            this.txtUPSLabel.Enter += new System.EventHandler(this.txtUPSLabel_Enter);
            this.txtUPSLabel.Validating += new System.ComponentModel.CancelEventHandler(this.txtUPSLabel_Validating);
            // 
            // btnShipped
            // 
            this.btnShipped.Location = new System.Drawing.Point(100, 170);
            this.btnShipped.Name = "btnShipped";
            this.btnShipped.Size = new System.Drawing.Size(108, 23);
            this.btnShipped.TabIndex = 5;
            this.btnShipped.TabStop = false;
            this.btnShipped.Text = "Mark Shipped";
            this.btnShipped.UseVisualStyleBackColor = true;
            this.btnShipped.Click += new System.EventHandler(this.btnShipped_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Client Order Id";
            // 
            // txtClientOrderId
            // 
            this.txtClientOrderId.Location = new System.Drawing.Point(12, 23);
            this.txtClientOrderId.Name = "txtClientOrderId";
            this.txtClientOrderId.Size = new System.Drawing.Size(339, 20);
            this.txtClientOrderId.TabIndex = 1;
            this.txtClientOrderId.TabStop = false;
            this.txtClientOrderId.Leave += new System.EventHandler(this.txtClientOrderId_Leave);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(100, 199);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear Check";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClear_MouseDown);
            // 
            // txtempty
            // 
            this.txtempty.Location = new System.Drawing.Point(343, 206);
            this.txtempty.Name = "txtempty";
            this.txtempty.Size = new System.Drawing.Size(1, 20);
            this.txtempty.TabIndex = 4;
            this.txtempty.TabStop = false;
            this.txtempty.Enter += new System.EventHandler(this.txtempty_Enter);
            // 
            // lstInvno
            // 
            this.lstInvno.BackColor = System.Drawing.SystemColors.Control;
            this.lstInvno.FormattingEnabled = true;
            this.lstInvno.Location = new System.Drawing.Point(369, 23);
            this.lstInvno.Name = "lstInvno";
            this.lstInvno.Size = new System.Drawing.Size(189, 147);
            this.lstInvno.TabIndex = 7;
            // 
            // frmTukiosBookChk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(566, 248);
            this.Controls.Add(this.lstInvno);
            this.Controls.Add(this.txtempty);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClientOrderId);
            this.Controls.Add(this.btnShipped);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUPSLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTukiosBookChk";
            this.Text = "Shipping Check";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmTukiosBookChk_Load);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtUPSLabel, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnShipped, 0);
            this.Controls.SetChildIndex(this.txtClientOrderId, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.txtempty, 0);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.lstInvno, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsDescriptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bsDescriptions;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUPSLabel;
        private System.Windows.Forms.Button btnShipped;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClientOrderId;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtempty;
        private System.Windows.Forms.ListBox lstInvno;
    }
}
