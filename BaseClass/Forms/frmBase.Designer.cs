namespace BaseClass
{
    partial class frmBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.basePanel = new BaseClass.Classes.TransparentPanel(this.components);
            this.workingLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.basePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.basePanel.Controls.Add(this.workingLabel);
            this.basePanel.Controls.Add(this.pictureBox1);
            this.basePanel.Location = new System.Drawing.Point(3, 1);
            this.basePanel.Name = "basePanel";
            this.basePanel.Size = new System.Drawing.Size(32, 26);
            this.basePanel.TabIndex = 0;
            this.basePanel.Visible = false;
            this.basePanel.VisibleChanged += new System.EventHandler(this.basePanel_VisibleChanged);
            // 
            // workingLabel
            // 
            this.workingLabel.AutoSize = true;
            this.workingLabel.BackColor = System.Drawing.Color.Transparent;
            this.workingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workingLabel.ForeColor = System.Drawing.Color.Blue;
            this.workingLabel.Location = new System.Drawing.Point(502, 342);
            this.workingLabel.Name = "workingLabel";
            this.workingLabel.Size = new System.Drawing.Size(130, 29);
            this.workingLabel.TabIndex = 1;
            this.workingLabel.Text = "Working...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(645, 342);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 29);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 706);
            this.Controls.Add(this.basePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Base_FormClosed);
            this.Load += new System.EventHandler(this.Base_Load);
            this.basePanel.ResumeLayout(false);
            this.basePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label workingLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        protected Classes.TransparentPanel basePanel;
    }
}