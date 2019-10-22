namespace Mbc5.Forms
{
    partial class frmPayments
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
            this.rdMemorybook = new System.Windows.Forms.RadioButton();
            this.rdMeridian = new System.Windows.Forms.RadioButton();
            this.lblPaymentdate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dbPaymentDate = new CustomControls.DateBox();
            this.paymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Prnt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.payDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Controls.Add(this.rdMeridian);
            this.TopPanel.Controls.Add(this.rdMemorybook);
            this.TopPanel.Size = new System.Drawing.Size(939, 66);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.button3);
            this.BottomPanel.Controls.Add(this.button2);
            this.BottomPanel.Controls.Add(this.button1);
            this.BottomPanel.Location = new System.Drawing.Point(0, 399);
            this.BottomPanel.Size = new System.Drawing.Size(939, 51);
            // 
            // basePanel
            // 
            this.basePanel.Location = new System.Drawing.Point(895, 54);
            this.basePanel.Size = new System.Drawing.Size(32, 27);
            // 
            // rdMemorybook
            // 
            this.rdMemorybook.AutoSize = true;
            this.rdMemorybook.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMemorybook.Location = new System.Drawing.Point(12, 12);
            this.rdMemorybook.Name = "rdMemorybook";
            this.rdMemorybook.Size = new System.Drawing.Size(96, 17);
            this.rdMemorybook.TabIndex = 0;
            this.rdMemorybook.TabStop = true;
            this.rdMemorybook.Text = "Memorybook";
            this.rdMemorybook.UseVisualStyleBackColor = true;
            this.rdMemorybook.CheckedChanged += new System.EventHandler(this.rdMemorybook_CheckedChanged);
            // 
            // rdMeridian
            // 
            this.rdMeridian.AutoSize = true;
            this.rdMeridian.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMeridian.Location = new System.Drawing.Point(12, 35);
            this.rdMeridian.Name = "rdMeridian";
            this.rdMeridian.Size = new System.Drawing.Size(73, 17);
            this.rdMeridian.TabIndex = 1;
            this.rdMeridian.TabStop = true;
            this.rdMeridian.Text = "Meridian";
            this.rdMeridian.UseVisualStyleBackColor = true;
            this.rdMeridian.CheckedChanged += new System.EventHandler(this.rdMeridian_CheckedChanged);
            // 
            // lblPaymentdate
            // 
            this.lblPaymentdate.AutoSize = true;
            this.lblPaymentdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentdate.Location = new System.Drawing.Point(32, 78);
            this.lblPaymentdate.Name = "lblPaymentdate";
            this.lblPaymentdate.Size = new System.Drawing.Size(86, 13);
            this.lblPaymentdate.TabIndex = 44;
            this.lblPaymentdate.Text = "Payment Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(365, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 29);
            this.label1.TabIndex = 45;
            this.label1.Text = "Payment Query";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Prnt,
            this.payDate,
            this.Invno,
            this.paymnt,
            this.Schcode,
            this.schname,
            this.schemail,
            this.contemail});
            this.dataGridView1.DataSource = this.paymentBindingSource;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(35, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(892, 292);
            this.dataGridView1.TabIndex = 45;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run Query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Clear List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(503, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Email Receipt Notice";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dbPaymentDate
            // 
            this.dbPaymentDate.Date = null;
            this.dbPaymentDate.DateValue = null;
            this.dbPaymentDate.Location = new System.Drawing.Point(124, 74);
            this.dbPaymentDate.MinimumSize = new System.Drawing.Size(114, 20);
            this.dbPaymentDate.Name = "dbPaymentDate";
            this.dbPaymentDate.Size = new System.Drawing.Size(127, 21);
            this.dbPaymentDate.TabIndex = 142;
           
            // 
            // Prnt
            // 
            this.Prnt.DataPropertyName = "print";
            this.Prnt.HeaderText = "Print";
            this.Prnt.Name = "Prnt";
            this.Prnt.ReadOnly = true;
            this.Prnt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Prnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Prnt.Width = 33;
            // 
            // payDate
            // 
            this.payDate.DataPropertyName = "PmtDate";
            this.payDate.HeaderText = "Date";
            this.payDate.Name = "payDate";
            this.payDate.ReadOnly = true;
            this.payDate.Width = 68;
            // 
            // Invno
            // 
            this.Invno.DataPropertyName = "Invno";
            this.Invno.HeaderText = "Invoice No.";
            this.Invno.Name = "Invno";
            this.Invno.ReadOnly = true;
            this.Invno.Width = 75;
            // 
            // paymnt
            // 
            this.paymnt.DataPropertyName = "Payment";
            this.paymnt.HeaderText = "Payment Amount";
            this.paymnt.Name = "paymnt";
            this.paymnt.ReadOnly = true;
            this.paymnt.Width = 75;
            // 
            // Schcode
            // 
            this.Schcode.DataPropertyName = "SchCode";
            this.Schcode.HeaderText = "School Code";
            this.Schcode.Name = "Schcode";
            this.Schcode.ReadOnly = true;
            this.Schcode.Width = 75;
            // 
            // schname
            // 
            this.schname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.schname.DataPropertyName = "SchName";
            this.schname.FillWeight = 150F;
            this.schname.HeaderText = "School Name";
            this.schname.Name = "schname";
            this.schname.ReadOnly = true;
            // 
            // schemail
            // 
            this.schemail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.schemail.DataPropertyName = "Schemail";
            this.schemail.FillWeight = 150F;
            this.schemail.HeaderText = "School Email";
            this.schemail.Name = "schemail";
            this.schemail.ReadOnly = true;
            // 
            // contemail
            // 
            this.contemail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.contemail.DataPropertyName = "contEmail";
            this.contemail.FillWeight = 150F;
            this.contemail.HeaderText = "Contact Email";
            this.contemail.Name = "contemail";
            this.contemail.ReadOnly = true;
            // 
            // frmPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(939, 450);
            this.Controls.Add(this.dbPaymentDate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblPaymentdate);
            this.Name = "frmPayments";
            this.Text = "Payments Made";
            this.Load += new System.EventHandler(this.frmPayments_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.TopPanel, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.lblPaymentdate, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.dbPaymentDate, 0);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdMeridian;
        private System.Windows.Forms.RadioButton rdMemorybook;
        private System.Windows.Forms.Label lblPaymentdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CustomControls.DateBox dbPaymentDate;
        private System.Windows.Forms.BindingSource paymentBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Prnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn payDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invno;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn schname;
        private System.Windows.Forms.DataGridViewTextBoxColumn schemail;
        private System.Windows.Forms.DataGridViewTextBoxColumn contemail;
    }
}
