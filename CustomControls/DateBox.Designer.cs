namespace CustomControls
{
    partial class DateBox
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateBox));
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.txtbox = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtp
            // 
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp.Location = new System.Drawing.Point(0, 0);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(92, 20);
            this.dtp.TabIndex = 0;
            this.dtp.Visible = false;
            this.dtp.CloseUp += new System.EventHandler(this.dtp_CloseUp);
            // 
            // txtbox
            // 
            this.txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtbox.Location = new System.Drawing.Point(0, 0);
            this.txtbox.MinimumSize = new System.Drawing.Size(73, 20);
            this.txtbox.Name = "txtbox";
            this.txtbox.ReadOnly = true;
            this.txtbox.Size = new System.Drawing.Size(73, 20);
            this.txtbox.TabIndex = 2;
            this.txtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbox_KeyDown);
            // 
            // btn
            // 
            this.btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn.Image = ((System.Drawing.Image)(resources.GetObject("btn.Image")));
            this.btn.Location = new System.Drawing.Point(73, 0);
            this.btn.MinimumSize = new System.Drawing.Size(23, 20);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(23, 21);
            this.btn.TabIndex = 3;
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // DateBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn);
            this.Controls.Add(this.txtbox);
            this.Controls.Add(this.dtp);
            this.MinimumSize = new System.Drawing.Size(96, 21);
            this.Name = "DateBox";
            this.Size = new System.Drawing.Size(96, 21);
          
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.TextBox txtbox;
        private System.Windows.Forms.Button btn;
    }
}
