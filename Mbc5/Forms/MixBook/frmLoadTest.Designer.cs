﻿namespace Mbc5.Forms.MemoryBook
{
    partial class frmLoadTest
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
            this.btnStart = new System.Windows.Forms.Button();
            this.bw1 = new System.ComponentModel.BackgroundWorker();
            this.lblresult = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.picbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(25, 23);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(117, 112);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblresult
            // 
            this.lblresult.AutoSize = true;
            this.lblresult.Location = new System.Drawing.Point(299, 50);
            this.lblresult.Name = "lblresult";
            this.lblresult.Size = new System.Drawing.Size(35, 13);
            this.lblresult.TabIndex = 2;
            this.lblresult.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Imag";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // picbox
            // 
            this.picbox.Location = new System.Drawing.Point(51, 275);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(435, 73);
            this.picbox.TabIndex = 4;
            this.picbox.TabStop = false;
            // 
            // frmLoadTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(719, 458);
            this.Controls.Add(this.picbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblresult);
            this.Controls.Add(this.btnStart);
            this.Name = "frmLoadTest";
            this.Text = "Mixbook Load Test";
            this.Load += new System.EventHandler(this.frmLoadTest_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.btnStart, 0);
            this.Controls.SetChildIndex(this.lblresult, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.picbox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.ComponentModel.BackgroundWorker bw1;
        private System.Windows.Forms.Label lblresult;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picbox;
    }
}
