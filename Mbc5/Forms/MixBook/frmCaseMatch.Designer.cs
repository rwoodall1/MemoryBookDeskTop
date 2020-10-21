namespace Mbc5.Forms.MixBook
{
    partial class frmCaseMatch
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.chkRemoveScan = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(29, 25);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(24, 84);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(248, 407);
            this.listBox1.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(70, 52);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(130, 29);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Cover List";
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Location = new System.Drawing.Point(407, 52);
            this.Button2.Margin = new System.Windows.Forms.Padding(4);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(238, 121);
            this.Button2.TabIndex = 8;
            this.Button2.Text = "Scan Covers";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button5
            // 
            this.Button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button5.Location = new System.Drawing.Point(337, 191);
            this.Button5.Margin = new System.Windows.Forms.Padding(4);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(165, 121);
            this.Button5.TabIndex = 10;
            this.Button5.TabStop = false;
            this.Button5.Text = "Remove First Cover";
            this.Button5.UseVisualStyleBackColor = true;
            this.Button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // Button4
            // 
            this.Button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button4.Location = new System.Drawing.Point(517, 191);
            this.Button4.Margin = new System.Windows.Forms.Padding(4);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(165, 121);
            this.Button4.TabIndex = 9;
            this.Button4.TabStop = false;
            this.Button4.Text = "Remove Last Cover";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button3.Location = new System.Drawing.Point(389, 336);
            this.Button3.Margin = new System.Windows.Forms.Padding(4);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(238, 122);
            this.Button3.TabIndex = 11;
            this.Button3.Text = "Scan Book Blocks";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // TextBox1
            // 
            this.TextBox1.AcceptsReturn = true;
            this.TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox1.Location = new System.Drawing.Point(317, 476);
            this.TextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ShortcutsEnabled = false;
            this.TextBox1.Size = new System.Drawing.Size(345, 28);
            this.TextBox1.TabIndex = 12;
            this.TextBox1.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // chkRemoveScan
            // 
            this.chkRemoveScan.AutoSize = true;
            this.chkRemoveScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRemoveScan.Location = new System.Drawing.Point(317, 511);
            this.chkRemoveScan.Name = "chkRemoveScan";
            this.chkRemoveScan.Size = new System.Drawing.Size(105, 17);
            this.chkRemoveScan.TabIndex = 13;
            this.chkRemoveScan.Text = "Remove Scan";
            this.chkRemoveScan.UseVisualStyleBackColor = true;
            // 
            // frmCaseMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(764, 614);
            this.Controls.Add(this.chkRemoveScan);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCaseMatch";
            this.Text = "Case Make Matcher";
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.listBox1, 0);
            this.Controls.SetChildIndex(this.Label1, 0);
            this.Controls.SetChildIndex(this.Button2, 0);
            this.Controls.SetChildIndex(this.Button4, 0);
            this.Controls.SetChildIndex(this.Button5, 0);
            this.Controls.SetChildIndex(this.Button3, 0);
            this.Controls.SetChildIndex(this.TextBox1, 0);
            this.Controls.SetChildIndex(this.chkRemoveScan, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.CheckBox chkRemoveScan;
    }
}
