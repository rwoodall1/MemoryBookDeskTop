namespace Mbc5.Forms.MemoryBook
{
    partial class frmInvoicInq
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblShipdate = new System.Windows.Forms.Label();
            this.dtShipDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgAddressErrors = new System.Windows.Forms.DataGridView();
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddressErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.lblTitle);
            this.TopPanel.Size = new System.Drawing.Size(1120, 48);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.button4);
            this.BottomPanel.Controls.Add(this.button3);
            this.BottomPanel.Controls.Add(this.button2);
            this.BottomPanel.Controls.Add(this.btnSearch);
            this.BottomPanel.Location = new System.Drawing.Point(0, 546);
            this.BottomPanel.Size = new System.Drawing.Size(1120, 75);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(498, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(125, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Invoices";
            // 
            // lblShipdate
            // 
            this.lblShipdate.AutoSize = true;
            this.lblShipdate.Location = new System.Drawing.Point(15, 64);
            this.lblShipdate.Name = "lblShipdate";
            this.lblShipdate.Size = new System.Drawing.Size(54, 13);
            this.lblShipdate.TabIndex = 2;
            this.lblShipdate.Text = "Ship Date";
            // 
            // dtShipDate
            // 
            this.dtShipDate.CustomFormat = "\'\'";
            this.dtShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtShipDate.Location = new System.Drawing.Point(75, 64);
            this.dtShipDate.Name = "dtShipDate";
            this.dtShipDate.Size = new System.Drawing.Size(200, 20);
            this.dtShipDate.TabIndex = 3;
            this.dtShipDate.ValueChanged += new System.EventHandler(this.dtShipDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(281, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "(Filter=Ship Date Not Blank and Balance >0.00)";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(379, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(473, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Clear Search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(569, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Print Invoices";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(667, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Email Invoices";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dgAddressErrors
            // 
            this.dgAddressErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAddressErrors.Location = new System.Drawing.Point(62, 128);
            this.dgAddressErrors.Name = "dgAddressErrors";
            this.dgAddressErrors.Size = new System.Drawing.Size(913, 150);
            this.dgAddressErrors.TabIndex = 5;
            // 
            // frmInvoicInq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1120, 621);
            this.Controls.Add(this.dgAddressErrors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtShipDate);
            this.Controls.Add(this.lblShipdate);
            this.Name = "frmInvoicInq";
            this.Text = "Print MBC Invoice\'s";
            this.Controls.SetChildIndex(this.TopPanel, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.lblShipdate, 0);
            this.Controls.SetChildIndex(this.dtShipDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgAddressErrors, 0);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAddressErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblShipdate;
        private System.Windows.Forms.DateTimePicker dtShipDate;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgAddressErrors;
    }
}
