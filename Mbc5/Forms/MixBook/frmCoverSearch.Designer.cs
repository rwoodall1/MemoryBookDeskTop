namespace Mbc5.Forms.MixBook
{
    partial class frmCoverSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCoverLocationResult = new System.Windows.Forms.Label();
            this.lblStatusData = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtS = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(17, 18);
            this.basePanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarcode.Location = new System.Drawing.Point(131, 42);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(264, 20);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cover Location";
            // 
            // lblCoverLocationResult
            // 
            this.lblCoverLocationResult.AutoSize = true;
            this.lblCoverLocationResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoverLocationResult.Location = new System.Drawing.Point(131, 81);
            this.lblCoverLocationResult.Name = "lblCoverLocationResult";
            this.lblCoverLocationResult.Size = new System.Drawing.Size(0, 13);
            this.lblCoverLocationResult.TabIndex = 4;
            // 
            // lblStatusData
            // 
            this.lblStatusData.AutoSize = true;
            this.lblStatusData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusData.Location = new System.Drawing.Point(131, 103);
            this.lblStatusData.Name = "lblStatusData";
            this.lblStatusData.Size = new System.Drawing.Size(0, 13);
            this.lblStatusData.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(44, 103);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Order Status";
            // 
            // txtS
            // 
            this.txtS.Location = new System.Drawing.Point(411, 43);
            this.txtS.Name = "txtS";
            this.txtS.Size = new System.Drawing.Size(1, 20);
            this.txtS.TabIndex = 2;
            this.txtS.Enter += new System.EventHandler(this.txtS_Enter);
            // 
            // frmCoverSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(489, 227);
            this.Controls.Add(this.txtS);
            this.Controls.Add(this.lblStatusData);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCoverLocationResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label1);
            this.Name = "frmCoverSearch";
            this.Text = " ";
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblCoverLocationResult, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.lblStatusData, 0);
            this.Controls.SetChildIndex(this.txtS, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCoverLocationResult;
        private System.Windows.Forms.Label lblStatusData;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtS;
    }
}
