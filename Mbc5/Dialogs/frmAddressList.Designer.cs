namespace Mbc5.Dialogs
{
    partial class frmAddressList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddressList));
            this.dsUser = new Mbc5.DataSets.dsUser();
            this.mbcUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mbcUsersTableAdapter = new Mbc5.DataSets.dsUserTableAdapters.mbcUsersTableAdapter();
            this.mbcUsersDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btrnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dsUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mbcUsersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mbcUsersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dsUser
            // 
            this.dsUser.DataSetName = "dsUser";
            this.dsUser.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mbcUsersBindingSource
            // 
            this.mbcUsersBindingSource.DataMember = "mbcUsers";
            this.mbcUsersBindingSource.DataSource = this.dsUser;
            // 
            // mbcUsersTableAdapter
            // 
            this.mbcUsersTableAdapter.ClearBeforeFill = true;
            // 
            // mbcUsersDataGridView
            // 
            this.mbcUsersDataGridView.AllowUserToAddRows = false;
            this.mbcUsersDataGridView.AllowUserToDeleteRows = false;
            this.mbcUsersDataGridView.AllowUserToOrderColumns = true;
            this.mbcUsersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mbcUsersDataGridView.AutoGenerateColumns = false;
            this.mbcUsersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mbcUsersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mbcUsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mbcUsersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn6,
            this.EmailAddress});
            this.mbcUsersDataGridView.DataSource = this.mbcUsersBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mbcUsersDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.mbcUsersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.mbcUsersDataGridView.Name = "mbcUsersDataGridView";
            this.mbcUsersDataGridView.Size = new System.Drawing.Size(414, 311);
            this.mbcUsersDataGridView.TabIndex = 1;
            this.mbcUsersDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mbcUsersDataGridView_CellContentDoubleClick);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "LastName";
            this.dataGridViewTextBoxColumn7.HeaderText = "Last Name";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FirstName";
            this.dataGridViewTextBoxColumn6.HeaderText = "First Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // EmailAddress
            // 
            this.EmailAddress.DataPropertyName = "EmailAddress";
            this.EmailAddress.HeaderText = "Email Address";
            this.EmailAddress.Name = "EmailAddress";
            // 
            // btrnOk
            // 
            this.btrnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btrnOk.Location = new System.Drawing.Point(119, 366);
            this.btrnOk.Name = "btrnOk";
            this.btrnOk.Size = new System.Drawing.Size(75, 23);
            this.btrnOk.TabIndex = 2;
            this.btrnOk.Text = "Ok";
            this.btrnOk.UseVisualStyleBackColor = true;
            this.btrnOk.Click += new System.EventHandler(this.btrnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(219, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(12, 327);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(389, 20);
            this.txtAddress.TabIndex = 4;
            // 
            // frmAddressList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 404);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btrnOk);
            this.Controls.Add(this.mbcUsersDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddressList";
            this.Text = "Addresses";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAddressList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mbcUsersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mbcUsersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSets.dsUser dsUser;
        private System.Windows.Forms.BindingSource mbcUsersBindingSource;
        private DataSets.dsUserTableAdapters.mbcUsersTableAdapter mbcUsersTableAdapter;
        private System.Windows.Forms.DataGridView mbcUsersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailAddress;
        private System.Windows.Forms.Button btrnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAddress;
    }
}