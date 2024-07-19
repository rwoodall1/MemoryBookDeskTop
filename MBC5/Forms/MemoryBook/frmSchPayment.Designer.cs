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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.bsSchPayments = new System.Windows.Forms.BindingSource(this.components);
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbReconciled = new System.Windows.Forms.RadioButton();
            this.rbUnreconciled = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgSchPay = new System.Windows.Forms.DataGridView();
            this.ToPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Collections = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCancel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.bsSchPayments)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSchPay)).BeginInit();
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
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuery.Location = new System.Drawing.Point(298, 394);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "Run Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCopy.Location = new System.Drawing.Point(407, 394);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(99, 23);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Copy To Excel";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
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
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
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
            this.rbReconciled.CheckedChanged += new System.EventHandler(this.rbReconciled_CheckedChanged);
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
            this.rbUnreconciled.CheckedChanged += new System.EventHandler(this.rbUnreconciled_CheckedChanged);
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
            // dgSchPay
            // 
            this.dgSchPay.AllowUserToAddRows = false;
            this.dgSchPay.AllowUserToDeleteRows = false;
            this.dgSchPay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSchPay.AutoGenerateColumns = false;
            this.dgSchPay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSchPay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgSchPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSchPay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ToPrint,
            this.Collections,
            this.Schcode,
            this.InvoiceNo,
            this.colCancel,
            this.Schemail,
            this.ContactEmail,
            this.Balance,
            this.Column7});
            this.dgSchPay.DataSource = this.bsSchPayments;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSchPay.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgSchPay.EnableHeadersVisualStyles = false;
            this.dgSchPay.Location = new System.Drawing.Point(12, 85);
            this.dgSchPay.Name = "dgSchPay";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSchPay.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgSchPay.RowHeadersVisible = false;
            this.dgSchPay.Size = new System.Drawing.Size(749, 288);
            this.dgSchPay.TabIndex = 13;
            this.dgSchPay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSchPay_CellClick);
            this.dgSchPay.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSchPay_CellContentClick);
            this.dgSchPay.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSchPay_CellLeave);
            this.dgSchPay.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgSchPay_CellMouseUp);
            this.dgSchPay.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgSchPay_DataError);
            // 
            // ToPrint
            // 
            this.ToPrint.DataPropertyName = "Reconciled";
            this.ToPrint.HeaderText = "Reconciled";
            this.ToPrint.Name = "ToPrint";
            // 
            // Collections
            // 
            this.Collections.DataPropertyName = "Schname";
            this.Collections.HeaderText = "Name";
            this.Collections.Name = "Collections";
            this.Collections.ReadOnly = true;
            this.Collections.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Collections.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Schcode
            // 
            this.Schcode.DataPropertyName = "Schcode";
            this.Schcode.HeaderText = "School Code";
            this.Schcode.Name = "Schcode";
            this.Schcode.ReadOnly = true;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.DataPropertyName = "PONumber";
            this.InvoiceNo.HeaderText = "PO/Invoice";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            this.InvoiceNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InvoiceNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCancel
            // 
            this.colCancel.DataPropertyName = "PayDate";
            this.colCancel.HeaderText = "Date Paid";
            this.colCancel.Name = "colCancel";
            this.colCancel.ReadOnly = true;
            // 
            // Schemail
            // 
            this.Schemail.DataPropertyName = "Amount";
            this.Schemail.HeaderText = "Amount";
            this.Schemail.Name = "Schemail";
            this.Schemail.ReadOnly = true;
            // 
            // ContactEmail
            // 
            this.ContactEmail.DataPropertyName = "CardType";
            this.ContactEmail.HeaderText = "Card Type";
            this.ContactEmail.Name = "ContactEmail";
            this.ContactEmail.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "CardNumber";
            this.Balance.HeaderText = "Card #";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Id";
            this.Column7.HeaderText = "Id";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // frmSchPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(804, 438);
            this.Controls.Add(this.dgSchPay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFromDate);
            this.MinimumSize = new System.Drawing.Size(820, 477);
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
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgSchPay, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsSchPayments)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSchPay)).EndInit();
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
        private System.Windows.Forms.BindingSource bsSchPayments;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbReconciled;
        private System.Windows.Forms.RadioButton rbUnreconciled;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgSchPay;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ToPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Collections;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schemail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
