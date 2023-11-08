namespace Mbc5.Forms
{
    partial class frmInqCount
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inqEndDate = new System.Windows.Forms.DateTimePicker();
            this.inqStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contStartDate = new System.Windows.Forms.DateTimePicker();
            this.contEndDate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContryear = new System.Windows.Forms.TextBox();
            this.chkInquiry = new System.Windows.Forms.CheckBox();
            this.chkContact = new System.Windows.Forms.CheckBox();
            this.pnlContact = new System.Windows.Forms.Panel();
            this.pnlInquiry = new System.Windows.Forms.Panel();
            this.chkOutPut = new System.Windows.Forms.CheckBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBindingSource)).BeginInit();
            this.pnlContact.SuspendLayout();
            this.pnlInquiry.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Location = new System.Drawing.Point(35, -35);
            // 
            // inqEndDate
            // 
            this.inqEndDate.CustomFormat = "";
            this.inqEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inqEndDate.Location = new System.Drawing.Point(88, 37);
            this.inqEndDate.Name = "inqEndDate";
            this.inqEndDate.Size = new System.Drawing.Size(113, 20);
            this.inqEndDate.TabIndex = 3;
            // 
            // inqStartDate
            // 
            this.inqStartDate.CustomFormat = "";
            this.inqStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inqStartDate.Location = new System.Drawing.Point(88, 3);
            this.inqStartDate.Name = "inqStartDate";
            this.inqStartDate.Size = new System.Drawing.Size(113, 20);
            this.inqStartDate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Begin Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "End Date Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "End Date Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Begin Date";
            // 
            // contStartDate
            // 
            this.contStartDate.CustomFormat = "";
            this.contStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.contStartDate.Location = new System.Drawing.Point(86, 3);
            this.contStartDate.Name = "contStartDate";
            this.contStartDate.Size = new System.Drawing.Size(113, 20);
            this.contStartDate.TabIndex = 10;
            // 
            // contEndDate
            // 
            this.contEndDate.CustomFormat = "";
            this.contEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.contEndDate.Location = new System.Drawing.Point(86, 37);
            this.contEndDate.Name = "contEndDate";
            this.contEndDate.Size = new System.Drawing.Size(113, 20);
            this.contEndDate.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Run Query";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Contrac Year is not";
            // 
            // txtContryear
            // 
            this.txtContryear.Location = new System.Drawing.Point(122, 12);
            this.txtContryear.MaxLength = 2;
            this.txtContryear.Name = "txtContryear";
            this.txtContryear.Size = new System.Drawing.Size(32, 20);
            this.txtContryear.TabIndex = 13;
            // 
            // chkInquiry
            // 
            this.chkInquiry.AutoSize = true;
            this.chkInquiry.Location = new System.Drawing.Point(41, 56);
            this.chkInquiry.Name = "chkInquiry";
            this.chkInquiry.Size = new System.Drawing.Size(181, 17);
            this.chkInquiry.TabIndex = 14;
            this.chkInquiry.Text = "Use Customer Inuiry Date Range";
            this.chkInquiry.UseVisualStyleBackColor = true;
            this.chkInquiry.CheckedChanged += new System.EventHandler(this.chkInquiry_CheckedChanged);
            // 
            // chkContact
            // 
            this.chkContact.AutoSize = true;
            this.chkContact.Location = new System.Drawing.Point(41, 164);
            this.chkContact.Name = "chkContact";
            this.chkContact.Size = new System.Drawing.Size(193, 17);
            this.chkContact.TabIndex = 15;
            this.chkContact.Text = "Use Customer Contact Date Range";
            this.chkContact.UseVisualStyleBackColor = true;
            this.chkContact.CheckedChanged += new System.EventHandler(this.chkContact_CheckedChanged);
            // 
            // pnlContact
            // 
            this.pnlContact.Controls.Add(this.contEndDate);
            this.pnlContact.Controls.Add(this.label6);
            this.pnlContact.Controls.Add(this.label5);
            this.pnlContact.Controls.Add(this.contStartDate);
            this.pnlContact.Enabled = false;
            this.pnlContact.Location = new System.Drawing.Point(62, 188);
            this.pnlContact.Name = "pnlContact";
            this.pnlContact.Size = new System.Drawing.Size(207, 60);
            this.pnlContact.TabIndex = 16;
            // 
            // pnlInquiry
            // 
            this.pnlInquiry.Controls.Add(this.inqStartDate);
            this.pnlInquiry.Controls.Add(this.inqEndDate);
            this.pnlInquiry.Controls.Add(this.label3);
            this.pnlInquiry.Controls.Add(this.label4);
            this.pnlInquiry.Enabled = false;
            this.pnlInquiry.Location = new System.Drawing.Point(62, 79);
            this.pnlInquiry.Name = "pnlInquiry";
            this.pnlInquiry.Size = new System.Drawing.Size(206, 65);
            this.pnlInquiry.TabIndex = 17;
            // 
            // chkOutPut
            // 
            this.chkOutPut.AutoSize = true;
            this.chkOutPut.Location = new System.Drawing.Point(23, 262);
            this.chkOutPut.Name = "chkOutPut";
            this.chkOutPut.Size = new System.Drawing.Size(107, 17);
            this.chkOutPut.TabIndex = 18;
            this.chkOutPut.Text = "Out Put To Excel";
            this.chkOutPut.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 53;
            reportDataSource1.Name = "dsInq";
            reportDataSource1.Value = this.ReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MbcInqReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(337, 196);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(55, 49);
            this.reportViewer1.TabIndex = 19;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "Save To Excel File";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmInqCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(433, 426);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.chkOutPut);
            this.Controls.Add(this.pnlInquiry);
            this.Controls.Add(this.pnlContact);
            this.Controls.Add(this.chkContact);
            this.Controls.Add(this.chkInquiry);
            this.Controls.Add(this.txtContryear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInqCount";
            this.Text = "Inqiry Count";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmInqCount_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtContryear, 0);
            this.Controls.SetChildIndex(this.chkInquiry, 0);
            this.Controls.SetChildIndex(this.chkContact, 0);
            this.Controls.SetChildIndex(this.pnlContact, 0);
            this.Controls.SetChildIndex(this.pnlInquiry, 0);
            this.Controls.SetChildIndex(this.chkOutPut, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ReportBindingSource)).EndInit();
            this.pnlContact.ResumeLayout(false);
            this.pnlContact.PerformLayout();
            this.pnlInquiry.ResumeLayout(false);
            this.pnlInquiry.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker inqEndDate;
        private System.Windows.Forms.DateTimePicker inqStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker contStartDate;
        private System.Windows.Forms.DateTimePicker contEndDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContryear;
        private System.Windows.Forms.CheckBox chkInquiry;
        private System.Windows.Forms.CheckBox chkContact;
        private System.Windows.Forms.Panel pnlContact;
        private System.Windows.Forms.Panel pnlInquiry;
        private System.Windows.Forms.CheckBox chkOutPut;
        private System.Windows.Forms.BindingSource ReportBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
