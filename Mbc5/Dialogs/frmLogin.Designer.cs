namespace Mbc5.Dialogs
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lblpassword = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.btnForgotPassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(2, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(292, 80);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnForgotPassword);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.txtusername);
            this.panel1.Controls.Add(this.txtpassword);
            this.panel1.Controls.Add(this.lblpassword);
            this.panel1.Controls.Add(this.lblusername);
            this.panel1.Location = new System.Drawing.Point(300, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 190);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(126, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(46, 121);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(17, 36);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(220, 20);
            this.txtusername.TabIndex = 0;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(13, 87);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(220, 20);
            this.txtpassword.TabIndex = 1;
            this.txtpassword.UseSystemPasswordChar = true;
            this.txtpassword.WordWrap = false;
            this.txtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpassword_KeyPress);
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Location = new System.Drawing.Point(17, 71);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(53, 13);
            this.lblpassword.TabIndex = 1;
            this.lblpassword.Text = "&Passwerd";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Location = new System.Drawing.Point(17, 20);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(60, 13);
            this.lblusername.TabIndex = 0;
            this.lblusername.Text = "&User Name";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccess.Location = new System.Drawing.Point(6, 122);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(267, 29);
            this.lblSuccess.TabIndex = 2;
            this.lblSuccess.Text = "Login was successful!";
            this.lblSuccess.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbLoading
            // 
            this.pbLoading.Image = ((System.Drawing.Image)(resources.GetObject("pbLoading.Image")));
            this.pbLoading.Location = new System.Drawing.Point(86, 88);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(37, 37);
            this.pbLoading.TabIndex = 3;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // btnForgotPassword
            // 
            this.btnForgotPassword.Location = new System.Drawing.Point(74, 150);
            this.btnForgotPassword.Name = "btnForgotPassword";
            this.btnForgotPassword.Size = new System.Drawing.Size(99, 23);
            this.btnForgotPassword.TabIndex = 4;
            this.btnForgotPassword.Text = "&Forgot Password";
            this.btnForgotPassword.UseVisualStyleBackColor = true;
            this.btnForgotPassword.Click += new System.EventHandler(this.btnForgotPassword_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 203);
            this.ControlBox = false;
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Button btnForgotPassword;
    }
}