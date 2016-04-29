namespace Mbc5.Forms
{
    partial class frmChangePassword
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
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.dsChangePassword = new Mbc5.DataSets.dsChangePassword();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtpw2 = new System.Windows.Forms.TextBox();
            this.txtpw1 = new System.Windows.Forms.TextBox();
            this.bsChangePassword = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.conn = new System.Data.SqlClient.SqlConnection();
            this.daPassWord = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mbcUsersTableAdapter = new Mbc5.DataSets.dsChangePasswordTableAdapters.mbcUsersTableAdapter();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsChangePassword)).BeginInit();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsChangePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.lblId);
            this.BottomPanel.Controls.Add(this.btnCancel);
            this.BottomPanel.Controls.Add(this.btnSave);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 162);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(408, 51);
            this.BottomPanel.TabIndex = 3;
            // 
            // lblId
            // 
            this.lblId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsChangePassword, "mbcUsers.id", true));
            this.lblId.Location = new System.Drawing.Point(8, 29);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(1, 1);
            this.lblId.TabIndex = 4;
            // 
            // dsChangePassword
            // 
            this.dsChangePassword.DataSetName = "dsChangePassword";
            this.dsChangePassword.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(408, 48);
            this.TopPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Change Password";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsChangePassword, "mbcUsers.Name", true));
            this.lblName.Location = new System.Drawing.Point(182, 62);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 13);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "lblName";
            // 
            // txtpw2
            // 
            this.txtpw2.Location = new System.Drawing.Point(143, 121);
            this.txtpw2.Name = "txtpw2";
            this.txtpw2.Size = new System.Drawing.Size(220, 20);
            this.txtpw2.TabIndex = 1;
            this.txtpw2.UseSystemPasswordChar = true;
            this.txtpw2.WordWrap = false;
            this.txtpw2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpw2_KeyPress);
            // 
            // txtpw1
            // 
            this.txtpw1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsChangePassword, "PassWord", true));
            this.txtpw1.Location = new System.Drawing.Point(143, 85);
            this.txtpw1.Name = "txtpw1";
            this.txtpw1.Size = new System.Drawing.Size(220, 20);
            this.txtpw1.TabIndex = 0;
            this.txtpw1.UseSystemPasswordChar = true;
            this.txtpw1.WordWrap = false;
            // 
            // bsChangePassword
            // 
            this.bsChangePassword.DataMember = "mbcUsers";
            this.bsChangePassword.DataSource = this.dsChangePassword;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Confirm Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // conn
            // 
            this.conn.ConnectionString = "Data Source=192.168.1.101;Initial Catalog=Mbc5;Persist Security Info=True;User ID" +
    "=sa;Password=Briggitte1";
            this.conn.FireInfoMessageEventOnUserErrors = false;
            // 
            // daPassWord
            // 
            this.daPassWord.DeleteCommand = this.sqlDeleteCommand1;
            this.daPassWord.InsertCommand = this.sqlInsertCommand1;
            this.daPassWord.SelectCommand = this.sqlSelectCommand1;
            this.daPassWord.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "mbcUsers", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("PassWord", "PassWord"),
                        new System.Data.Common.DataColumnMapping("UserName", "UserName"),
                        new System.Data.Common.DataColumnMapping("id", "id")})});
            this.daPassWord.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "DELETE FROM [mbcUsers] WHERE (([PassWord] = @Original_PassWord) AND ([UserName] =" +
    " @Original_UserName) AND ([id] = @Original_id))";
            this.sqlDeleteCommand1.Connection = this.conn;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_PassWord", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PassWord", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UserName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_id", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = "INSERT INTO mbcUsers\r\n                         (PassWord, ChangePassword)\r\nVALUES" +
    "        (@PassWord,@ChangePassword); \r\nSELECT PassWord, UserName, id FROM mbcUse" +
    "rs WHERE (id = @id)";
            this.sqlInsertCommand1.Connection = this.conn;
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT        id, RTRIM(FirstName) + \'  \' + RTRIM(LastName) AS Name\r\nFROM        " +
    "    mbcUsers\r\nWHERE        (id = @id)";
            this.sqlSelectCommand1.Connection = this.conn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.NVarChar, 128, "id")});
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = "UPDATE       mbcUsers\r\nSET                PassWord = @PassWord, ChangePassword = " +
    "@ChangePassword\r\nWHERE        (id = @Id);     \r\nSELECT PassWord, UserName, id FR" +
    "OM mbcUsers WHERE (id = @id)";
            this.sqlUpdateCommand1.Connection = this.conn;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@PassWord", System.Data.SqlDbType.NVarChar, 50, "PassWord"),
            new System.Data.SqlClient.SqlParameter("@ChangePassword", System.Data.SqlDbType.Bit, 1, "ChangePassword"),
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.NVarChar, 128, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.NVarChar, 128, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 500;
            this.errorProvider.ContainerControl = this;
            // 
            // mbcUsersTableAdapter
            // 
            this.mbcUsersTableAdapter.ClearBeforeFill = true;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 213);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtpw2);
            this.Controls.Add(this.txtpw1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsChangePassword)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsChangePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel BottomPanel;
        protected System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtpw2;
        private System.Windows.Forms.TextBox txtpw1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Data.SqlClient.SqlConnection conn;
        private System.Data.SqlClient.SqlDataAdapter daPassWord;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private DataSets.dsChangePassword dsChangePassword;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bsChangePassword;
        private DataSets.dsChangePasswordTableAdapters.mbcUsersTableAdapter mbcUsersTableAdapter;
    }
}