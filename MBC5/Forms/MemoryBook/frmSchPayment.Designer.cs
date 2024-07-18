namespace Mbc5.Forms.MemoryBook
{
    partial class frmSchPayment
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
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.custDataGridView = new System.Windows.Forms.DataGridView();
            this.qcontractyear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QInvno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsSchPayments = new System.Windows.Forms.BindingSource(this.components);
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbReconciled = new System.Windows.Forms.RadioButton();
            this.rbUnreconciled = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSchPayments)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(45, 19);
            // 
            // dtFromDate
            // 
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(152, 43);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(110, 20);
            this.dtFromDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pay Date Between";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "and";
            // 
            // dtToDate
            // 
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(305, 43);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(110, 20);
            this.dtToDate.TabIndex = 3;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuery.Location = new System.Drawing.Point(168, 394);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "Run Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Location = new System.Drawing.Point(277, 394);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(99, 23);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Copy To Excel";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // custDataGridView
            // 
            this.custDataGridView.AllowUserToAddRows = false;
            this.custDataGridView.AllowUserToDeleteRows = false;
            this.custDataGridView.AllowUserToOrderColumns = true;
            this.custDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.custDataGridView.AutoGenerateColumns = false;
            this.custDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.custDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.custDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.custDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qcontractyear,
            this.QInvno,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.custDataGridView.DataSource = this.bsSchPayments;
            this.custDataGridView.EnableHeadersVisualStyles = false;
            this.custDataGridView.Location = new System.Drawing.Point(40, 80);
            this.custDataGridView.Name = "custDataGridView";
            this.custDataGridView.ReadOnly = true;
            this.custDataGridView.Size = new System.Drawing.Size(840, 294);
            this.custDataGridView.TabIndex = 8;
            // 
            // qcontractyear
            // 
            this.qcontractyear.DataPropertyName = "Reconciled";
            this.qcontractyear.HeaderText = "Reconciled";
            this.qcontractyear.Name = "qcontractyear";
            this.qcontractyear.ReadOnly = true;
            // 
            // QInvno
            // 
            this.QInvno.DataPropertyName = "Schname";
            this.QInvno.HeaderText = "Name";
            this.QInvno.Name = "QInvno";
            this.QInvno.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Schcode";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "PO/Invoice";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Date Paid";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Amount";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Card Type";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Card #";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(3, 3);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(79, 17);
            this.rbAll.TabIndex = 9;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All Records";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbReconciled
            // 
            this.rbReconciled.AutoSize = true;
            this.rbReconciled.Location = new System.Drawing.Point(94, 3);
            this.rbReconciled.Name = "rbReconciled";
            this.rbReconciled.Size = new System.Drawing.Size(79, 17);
            this.rbReconciled.TabIndex = 10;
            this.rbReconciled.Text = "Reconciled";
            this.rbReconciled.UseVisualStyleBackColor = true;
            // 
            // rbUnreconciled
            // 
            this.rbUnreconciled.AutoSize = true;
            this.rbUnreconciled.Location = new System.Drawing.Point(185, 3);
            this.rbUnreconciled.Name = "rbUnreconciled";
            this.rbUnreconciled.Size = new System.Drawing.Size(93, 17);
            this.rbUnreconciled.TabIndex = 11;
            this.rbUnreconciled.Text = "UnReconciled";
            this.rbUnreconciled.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbAll);
            this.panel1.Controls.Add(this.rbUnreconciled);
            this.panel1.Controls.Add(this.rbReconciled);
            this.panel1.Location = new System.Drawing.Point(445, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 27);
            this.panel1.TabIndex = 12;
            // 
            // frmSchPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(998, 438);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.custDataGridView);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFromDate);
            this.Name = "frmSchPayment";
            this.Text = "Online School Payments";
            this.Load += new System.EventHandler(this.frmSchPayment_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.dtFromDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtToDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnQuery, 0);
            this.Controls.SetChildIndex(this.btnCopy, 0);
            this.Controls.SetChildIndex(this.custDataGridView, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSchPayments)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.DataGridView custDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn qcontractyear;
        private System.Windows.Forms.DataGridViewTextBoxColumn QInvno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.BindingSource bsSchPayments;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbReconciled;
        private System.Windows.Forms.RadioButton rbUnreconciled;
        private System.Windows.Forms.Panel panel1;
    }
}
