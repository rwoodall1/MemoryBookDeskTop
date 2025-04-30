namespace Mbc5.Forms
{
    partial class frmBarScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBarScan));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.FullInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InvoiceDetailBindingModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InvoiceDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeptCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDateTime = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtInOut = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSchcode = new System.Windows.Forms.TextBox();
            this.txtCoverNumber = new System.Windows.Forms.TextBox();
            this.txtColorPageNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtExtraBooks = new System.Windows.Forms.TextBox();
            this.txtSchoolName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProdNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCopies = new System.Windows.Forms.TextBox();
            this.lblCopies = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPlates = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPlateNotes = new System.Windows.Forms.TextBox();
            this.cmbPlateReason = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPressNotes = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbPressReason = new System.Windows.Forms.ComboBox();
            this.txtSheets = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.chkShippedOrders = new System.Windows.Forms.CheckBox();
            this.btnDeadLineInfo = new System.Windows.Forms.Button();
            this.txtIntitials = new System.Windows.Forms.MaskedTextBox();
            this.txtBarCode = new System.Windows.Forms.MaskedTextBox();
            this.txtDept = new System.Windows.Forms.MaskedTextBox();
            this.lblPressNumber = new System.Windows.Forms.Label();
            this.txtPressNumber = new System.Windows.Forms.MaskedTextBox();
            this.pnlPressNumber = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BinderyLabelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FullMerInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.plnTracking = new System.Windows.Forms.Panel();
            this.txtTrackingNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblRef = new System.Windows.Forms.Label();
            this.txtRef = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FullInvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceDetailBindingModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceDetailBindingSource)).BeginInit();
            this.pnlPressNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinderyLabelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullMerInvoiceBindingSource)).BeginInit();
            this.plnTracking.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(22, 16);
            // 
            // FullInvoiceBindingSource
            // 
            this.FullInvoiceBindingSource.DataSource = typeof(BindingModels.FullInvoice);
            // 
            // InvoiceDetailBindingModelBindingSource
            // 
            this.InvoiceDetailBindingModelBindingSource.DataSource = typeof(BindingModels.InvoiceDetailBindingModel);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(58, 19);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(124, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Scan Book Bar code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scan Department Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time Spent on book";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Initials ( first,middle and last )";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Scan In/Out or To/From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Scan Department or Vendor";
            // 
            // txtDeptCode
            // 
            this.txtDeptCode.Location = new System.Drawing.Point(187, 47);
            this.txtDeptCode.Name = "txtDeptCode";
            this.txtDeptCode.Size = new System.Drawing.Size(64, 20);
            this.txtDeptCode.TabIndex = 1;
            this.txtDeptCode.Leave += new System.EventHandler(this.txtDeptCode_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(346, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Date && Time";
            // 
            // txtDateTime
            // 
            this.txtDateTime.Location = new System.Drawing.Point(429, 19);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.ReadOnly = true;
            this.txtDateTime.Size = new System.Drawing.Size(143, 20);
            this.txtDateTime.TabIndex = 9;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(187, 151);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(47, 20);
            this.txtTime.TabIndex = 3;
            // 
            // txtInOut
            // 
            this.txtInOut.Location = new System.Drawing.Point(187, 247);
            this.txtInOut.Name = "txtInOut";
            this.txtInOut.Size = new System.Drawing.Size(47, 20);
            this.txtInOut.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(71, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "School Code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(310, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Cover#";
            // 
            // txtSchcode
            // 
            this.txtSchcode.Location = new System.Drawing.Point(163, 74);
            this.txtSchcode.Name = "txtSchcode";
            this.txtSchcode.ReadOnly = true;
            this.txtSchcode.Size = new System.Drawing.Size(140, 20);
            this.txtSchcode.TabIndex = 1000;
            // 
            // txtCoverNumber
            // 
            this.txtCoverNumber.Location = new System.Drawing.Point(366, 74);
            this.txtCoverNumber.Name = "txtCoverNumber";
            this.txtCoverNumber.ReadOnly = true;
            this.txtCoverNumber.Size = new System.Drawing.Size(116, 20);
            this.txtCoverNumber.TabIndex = 10000;
            // 
            // txtColorPageNumber
            // 
            this.txtColorPageNumber.Location = new System.Drawing.Point(569, 74);
            this.txtColorPageNumber.Name = "txtColorPageNumber";
            this.txtColorPageNumber.ReadOnly = true;
            this.txtColorPageNumber.Size = new System.Drawing.Size(89, 20);
            this.txtColorPageNumber.TabIndex = 10000;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(486, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Color Page#";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(665, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Extra Books Quantity";
            this.label10.Visible = false;
            // 
            // txtExtraBooks
            // 
            this.txtExtraBooks.Location = new System.Drawing.Point(791, 74);
            this.txtExtraBooks.Name = "txtExtraBooks";
            this.txtExtraBooks.ReadOnly = true;
            this.txtExtraBooks.Size = new System.Drawing.Size(68, 20);
            this.txtExtraBooks.TabIndex = 1000;
            this.txtExtraBooks.Visible = false;
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.Location = new System.Drawing.Point(163, 100);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.ReadOnly = true;
            this.txtSchoolName.Size = new System.Drawing.Size(300, 20);
            this.txtSchoolName.TabIndex = 1000;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(68, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "School Name";
            // 
            // txtProdNumber
            // 
            this.txtProdNumber.Location = new System.Drawing.Point(161, 124);
            this.txtProdNumber.Name = "txtProdNumber";
            this.txtProdNumber.ReadOnly = true;
            this.txtProdNumber.Size = new System.Drawing.Size(163, 20);
            this.txtProdNumber.TabIndex = 10000;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(75, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Production#";
            // 
            // txtCopies
            // 
            this.txtCopies.Location = new System.Drawing.Point(187, 200);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(47, 20);
            this.txtCopies.TabIndex = 5;
            this.txtCopies.Visible = false;
            this.txtCopies.TextChanged += new System.EventHandler(this.txtCopies_TextChanged);
            // 
            // lblCopies
            // 
            this.lblCopies.AutoSize = true;
            this.lblCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopies.Location = new System.Drawing.Point(134, 200);
            this.lblCopies.Name = "lblCopies";
            this.lblCopies.Size = new System.Drawing.Size(45, 13);
            this.lblCopies.TabIndex = 27;
            this.lblCopies.Text = "Copies";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(14, 223);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(591, 17);
            this.label14.TabIndex = 29;
            this.label14.Text = "Check In/Out - Hold In/Out - Vendor To/From - ReMake In/Out - Bindery To/From";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(321, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(415, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BackColor = System.Drawing.Color.Blue;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(-1, 320);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(906, 6);
            this.label15.TabIndex = 32;
            this.label15.Text = "Production#";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(393, 340);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 19);
            this.label16.TabIndex = 33;
            this.label16.Text = "Record Waste";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Blue;
            this.label17.Location = new System.Drawing.Point(62, 388);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 17);
            this.label17.TabIndex = 34;
            this.label17.Text = "Plate";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Blue;
            this.label18.Location = new System.Drawing.Point(477, 388);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 17);
            this.label18.TabIndex = 35;
            this.label18.Text = "Press Room";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Blue;
            this.label19.Location = new System.Drawing.Point(31, 416);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 13);
            this.label19.TabIndex = 36;
            this.label19.Text = "#of Plates";
            // 
            // txtPlates
            // 
            this.txtPlates.Location = new System.Drawing.Point(99, 416);
            this.txtPlates.Name = "txtPlates";
            this.txtPlates.Size = new System.Drawing.Size(47, 20);
            this.txtPlates.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Blue;
            this.label20.Location = new System.Drawing.Point(44, 444);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "Reason";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Blue;
            this.label21.Location = new System.Drawing.Point(23, 465);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 13);
            this.label21.TabIndex = 39;
            this.label21.Text = "Plate Notes";
            // 
            // txtPlateNotes
            // 
            this.txtPlateNotes.Location = new System.Drawing.Point(31, 481);
            this.txtPlateNotes.Multiline = true;
            this.txtPlateNotes.Name = "txtPlateNotes";
            this.txtPlateNotes.Size = new System.Drawing.Size(294, 55);
            this.txtPlateNotes.TabIndex = 11;
            // 
            // cmbPlateReason
            // 
            this.cmbPlateReason.FormattingEnabled = true;
            this.cmbPlateReason.Location = new System.Drawing.Point(99, 444);
            this.cmbPlateReason.Name = "cmbPlateReason";
            this.cmbPlateReason.Size = new System.Drawing.Size(226, 21);
            this.cmbPlateReason.TabIndex = 10;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Blue;
            this.label22.Location = new System.Drawing.Point(440, 416);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 13);
            this.label22.TabIndex = 42;
            this.label22.Text = "#of Sheets";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Blue;
            this.label23.Location = new System.Drawing.Point(457, 444);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(50, 13);
            this.label23.TabIndex = 43;
            this.label23.Text = "Reason";
            // 
            // txtPressNotes
            // 
            this.txtPressNotes.Location = new System.Drawing.Point(443, 481);
            this.txtPressNotes.Multiline = true;
            this.txtPressNotes.Name = "txtPressNotes";
            this.txtPressNotes.Size = new System.Drawing.Size(325, 55);
            this.txtPressNotes.TabIndex = 14;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.Location = new System.Drawing.Point(434, 465);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(75, 13);
            this.label24.TabIndex = 44;
            this.label24.Text = "Press Notes";
            // 
            // cmbPressReason
            // 
            this.cmbPressReason.FormattingEnabled = true;
            this.cmbPressReason.Location = new System.Drawing.Point(518, 444);
            this.cmbPressReason.Name = "cmbPressReason";
            this.cmbPressReason.Size = new System.Drawing.Size(250, 21);
            this.cmbPressReason.TabIndex = 13;
            // 
            // txtSheets
            // 
            this.txtSheets.Location = new System.Drawing.Point(518, 416);
            this.txtSheets.Name = "txtSheets";
            this.txtSheets.Size = new System.Drawing.Size(47, 20);
            this.txtSheets.TabIndex = 12;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Red;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(653, 112);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(206, 70);
            this.label26.TabIndex = 49;
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Yellow;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(658, 116);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(197, 62);
            this.label27.TabIndex = 50;
            this.label27.Text = "After scanning, Please verify the School Name is CORRECT, before proceeding. If I" +
    "NCORRECT, scan again .";
            // 
            // chkShippedOrders
            // 
            this.chkShippedOrders.AutoSize = true;
            this.chkShippedOrders.Location = new System.Drawing.Point(429, 192);
            this.chkShippedOrders.Name = "chkShippedOrders";
            this.chkShippedOrders.Size = new System.Drawing.Size(209, 17);
            this.chkShippedOrders.TabIndex = 10;
            this.chkShippedOrders.Text = "Do not send order shipped email";
            this.chkShippedOrders.UseVisualStyleBackColor = true;
            // 
            // btnDeadLineInfo
            // 
            this.btnDeadLineInfo.AutoSize = true;
            this.btnDeadLineInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnDeadLineInfo.Image")));
            this.btnDeadLineInfo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeadLineInfo.Location = new System.Drawing.Point(589, 112);
            this.btnDeadLineInfo.Name = "btnDeadLineInfo";
            this.btnDeadLineInfo.Size = new System.Drawing.Size(33, 24);
            this.btnDeadLineInfo.TabIndex = 151;
            this.btnDeadLineInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeadLineInfo.UseVisualStyleBackColor = true;
            // 
            // txtIntitials
            // 
            this.txtIntitials.Location = new System.Drawing.Point(187, 177);
            this.txtIntitials.Mask = ">LLL";
            this.txtIntitials.Name = "txtIntitials";
            this.txtIntitials.Size = new System.Drawing.Size(34, 20);
            this.txtIntitials.TabIndex = 4;
            // 
            // txtBarCode
            // 
            this.txtBarCode.AsciiOnly = true;
            this.txtBarCode.Location = new System.Drawing.Point(188, 19);
            this.txtBarCode.Mask = ">LLL0000000CLL";
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(100, 20);
            this.txtBarCode.TabIndex = 0;
            this.txtBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarCode_KeyPress);
            this.txtBarCode.Leave += new System.EventHandler(this.txtBarCode_Leave);
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(187, 271);
            this.txtDept.Mask = ">LLLLLL";
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(47, 20);
            this.txtDept.TabIndex = 6;
            // 
            // lblPressNumber
            // 
            this.lblPressNumber.AutoSize = true;
            this.lblPressNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPressNumber.Location = new System.Drawing.Point(1, 2);
            this.lblPressNumber.Name = "lblPressNumber";
            this.lblPressNumber.Size = new System.Drawing.Size(46, 13);
            this.lblPressNumber.TabIndex = 155;
            this.lblPressNumber.Text = "Press#";
            // 
            // txtPressNumber
            // 
            this.txtPressNumber.AsciiOnly = true;
            this.txtPressNumber.Location = new System.Drawing.Point(44, 0);
            this.txtPressNumber.Mask = "0000000";
            this.txtPressNumber.Name = "txtPressNumber";
            this.txtPressNumber.Size = new System.Drawing.Size(61, 20);
            this.txtPressNumber.TabIndex = 2;
            this.txtPressNumber.ValidatingType = typeof(int);
            this.txtPressNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtPressNumber_Validating);
            // 
            // pnlPressNumber
            // 
            this.pnlPressNumber.Controls.Add(this.txtPressNumber);
            this.pnlPressNumber.Controls.Add(this.lblPressNumber);
            this.pnlPressNumber.Location = new System.Drawing.Point(270, 45);
            this.pnlPressNumber.Name = "pnlPressNumber";
            this.pnlPressNumber.Size = new System.Drawing.Size(109, 23);
            this.pnlPressNumber.TabIndex = 157;
            this.pnlPressNumber.Visible = false;
            this.pnlPressNumber.Validating += new System.ComponentModel.CancelEventHandler(this.pnlPressNumber_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 47;
            reportDataSource1.Name = "invoice";
            reportDataSource1.Value = this.FullInvoiceBindingSource;
            reportDataSource2.Name = "invoicedetail";
            reportDataSource2.Value = this.InvoiceDetailBindingModelBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.BarScanMemInvoice.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(822, 343);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(49, 56);
            this.reportViewer1.TabIndex = 158;
            this.reportViewer1.Visible = false;
            // 
            // BinderyLabelBindingSource
            // 
            this.BinderyLabelBindingSource.DataSource = typeof(BindingModels.BinderyLabel);
            // 
            // FullMerInvoiceBindingSource
            // 
            this.FullMerInvoiceBindingSource.DataSource = typeof(BindingModels.FullMerInvoice);
            // 
            // timer1
            // 
            this.timer1.Interval = 3500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // plnTracking
            // 
            this.plnTracking.Controls.Add(this.txtTrackingNo);
            this.plnTracking.Controls.Add(this.label13);
            this.plnTracking.Location = new System.Drawing.Point(382, 44);
            this.plnTracking.Name = "plnTracking";
            this.plnTracking.Size = new System.Drawing.Size(322, 26);
            this.plnTracking.TabIndex = 10001;
            this.plnTracking.Visible = false;
            // 
            // txtTrackingNo
            // 
            this.txtTrackingNo.Location = new System.Drawing.Point(75, 3);
            this.txtTrackingNo.Name = "txtTrackingNo";
            this.txtTrackingNo.Size = new System.Drawing.Size(244, 20);
            this.txtTrackingNo.TabIndex = 4;
            this.txtTrackingNo.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Tracking #";
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRef.Location = new System.Drawing.Point(474, 100);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(35, 13);
            this.lblRef.TabIndex = 10002;
            this.lblRef.Text = "Ref#";
            this.lblRef.Visible = false;
            // 
            // txtRef
            // 
            this.txtRef.Location = new System.Drawing.Point(514, 100);
            this.txtRef.Name = "txtRef";
            this.txtRef.ReadOnly = true;
            this.txtRef.Size = new System.Drawing.Size(49, 20);
            this.txtRef.TabIndex = 10003;
            this.txtRef.Visible = false;
            // 
            // frmBarScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(904, 555);
            this.Controls.Add(this.lblRef);
            this.Controls.Add(this.txtRef);
            this.Controls.Add(this.plnTracking);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pnlPressNumber);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.txtIntitials);
            this.Controls.Add(this.btnDeadLineInfo);
            this.Controls.Add(this.chkShippedOrders);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtSheets);
            this.Controls.Add(this.cmbPressReason);
            this.Controls.Add(this.txtPressNotes);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cmbPlateReason);
            this.Controls.Add(this.txtPlateNotes);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtPlates);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.lblCopies);
            this.Controls.Add(this.txtProdNumber);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSchoolName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtExtraBooks);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtColorPageNumber);
            this.Controls.Add(this.txtCoverNumber);
            this.Controls.Add(this.txtSchcode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInOut);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtDateTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDeptCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmBarScan";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmBarScan_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.lbl1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtDeptCode, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtDateTime, 0);
            this.Controls.SetChildIndex(this.txtTime, 0);
            this.Controls.SetChildIndex(this.txtInOut, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtSchcode, 0);
            this.Controls.SetChildIndex(this.txtCoverNumber, 0);
            this.Controls.SetChildIndex(this.txtColorPageNumber, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtExtraBooks, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtSchoolName, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtProdNumber, 0);
            this.Controls.SetChildIndex(this.lblCopies, 0);
            this.Controls.SetChildIndex(this.txtCopies, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.txtPlates, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.txtPlateNotes, 0);
            this.Controls.SetChildIndex(this.cmbPlateReason, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.label23, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.txtPressNotes, 0);
            this.Controls.SetChildIndex(this.cmbPressReason, 0);
            this.Controls.SetChildIndex(this.txtSheets, 0);
            this.Controls.SetChildIndex(this.label26, 0);
            this.Controls.SetChildIndex(this.label27, 0);
            this.Controls.SetChildIndex(this.chkShippedOrders, 0);
            this.Controls.SetChildIndex(this.btnDeadLineInfo, 0);
            this.Controls.SetChildIndex(this.txtIntitials, 0);
            this.Controls.SetChildIndex(this.txtBarCode, 0);
            this.Controls.SetChildIndex(this.txtDept, 0);
            this.Controls.SetChildIndex(this.pnlPressNumber, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.plnTracking, 0);
            this.Controls.SetChildIndex(this.txtRef, 0);
            this.Controls.SetChildIndex(this.lblRef, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FullInvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceDetailBindingModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceDetailBindingSource)).EndInit();
            this.pnlPressNumber.ResumeLayout(false);
            this.pnlPressNumber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinderyLabelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullMerInvoiceBindingSource)).EndInit();
            this.plnTracking.ResumeLayout(false);
            this.plnTracking.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeptCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDateTime;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtInOut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSchcode;
        private System.Windows.Forms.TextBox txtCoverNumber;
        private System.Windows.Forms.TextBox txtColorPageNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtExtraBooks;
        private System.Windows.Forms.TextBox txtSchoolName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProdNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCopies;
        private System.Windows.Forms.Label lblCopies;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtPlates;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtPlateNotes;
        private System.Windows.Forms.ComboBox cmbPlateReason;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtPressNotes;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbPressReason;
        private System.Windows.Forms.TextBox txtSheets;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox chkShippedOrders;
        private System.Windows.Forms.Button btnDeadLineInfo;
        private System.Windows.Forms.MaskedTextBox txtIntitials;
        private System.Windows.Forms.MaskedTextBox txtBarCode;
        private System.Windows.Forms.MaskedTextBox txtDept;
        private System.Windows.Forms.Label lblPressNumber;
        private System.Windows.Forms.MaskedTextBox txtPressNumber;
        private System.Windows.Forms.Panel pnlPressNumber;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource invoiceBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource InvoiceDetailBindingSource;
        private System.Windows.Forms.BindingSource BinderyLabelBindingSource;
        private System.Windows.Forms.BindingSource FullMerInvoiceBindingSource;
        private System.Windows.Forms.BindingSource FullInvoiceBindingSource;
        private System.Windows.Forms.BindingSource InvoiceDetailBindingModelBindingSource;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel plnTracking;
        private System.Windows.Forms.TextBox txtTrackingNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.TextBox txtRef;
    }
}
