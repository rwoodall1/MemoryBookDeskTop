namespace Mbc5.Forms
{
	partial class frmEndSheet
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
			System.Windows.Forms.Label prodnoLabel;
			System.Windows.Forms.Label invnoLabel;
			System.Windows.Forms.Label clr1Label;
			System.Windows.Forms.Label clr2Label;
			System.Windows.Forms.Label clr3Label;
			System.Windows.Forms.Label clr4Label;
			System.Windows.Forms.Label clr5Label;
			System.Windows.Forms.Label clr6Label;
			System.Windows.Forms.Label perfbindLabel;
			System.Windows.Forms.Label spotclrLabel;
			System.Windows.Forms.Label csonholdLabel;
			System.Windows.Forms.Label csoffholdLabel;
			System.Windows.Forms.Label endstrecvLabel;
			System.Windows.Forms.Label reqstdcpyLabel;
			System.Windows.Forms.Label nopagesLabel;
			System.Windows.Forms.Label nocopiesLabel;
			System.Windows.Forms.Label frdescLabel;
			System.Windows.Forms.Label fldescLabel;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label prntsamLabel;
			System.Windows.Forms.Label reprntdteLabel;
			System.Windows.Forms.Label desorgdteLabel;
			System.Windows.Forms.Label persondestLabel;
			System.Windows.Forms.Label reasonLabel;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tbEndSheets = new System.Windows.Forms.TabControl();
			this.pgEndSheets = new System.Windows.Forms.TabPage();
			this.btnInvoiceSrch = new System.Windows.Forms.Button();
			this.txtInvoiceNoSrch = new System.Windows.Forms.TextBox();
			this.endsheetdetailDataGridView = new System.Windows.Forms.DataGridView();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.endsheetdetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dsEndSheet = new Mbc5.DataSets.dsEndSheet();
			this.reasonTextBox = new System.Windows.Forms.TextBox();
			this.endsheetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.persondestTextBox = new System.Windows.Forms.TextBox();
			this.reprnacpCheckBox = new System.Windows.Forms.CheckBox();
			this.acceptdCheckBox = new System.Windows.Forms.CheckBox();
			this.remakeCheckBox = new System.Windows.Forms.CheckBox();
			this.desorgdteDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.reprntdteDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.prntsamDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.otdtebkDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.otdtesentDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.dcdtebkDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.dcdtesentDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.lamdtebkDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.lamdtesentDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.prtdtebkDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.prtdtesentDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.othrvendTextBox = new System.Windows.Forms.TextBox();
			this.dcvendTextBox = new System.Windows.Forms.TextBox();
			this.lamvendTextBox = new System.Windows.Forms.TextBox();
			this.prtvendTextBox = new System.Windows.Forms.TextBox();
			this.diecutCheckBox = new System.Windows.Forms.CheckBox();
			this.produtnBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.othrCheckBox = new System.Windows.Forms.CheckBox();
			this.laminatedCheckBox = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.frcopiesTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.frdescTextBox = new System.Windows.Forms.TextBox();
			this.fldescTextBox = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.bkcopiesTextBox = new System.Windows.Forms.TextBox();
			this.bldescTextBox = new System.Windows.Forms.TextBox();
			this.brdescTextBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.invnoLabel2 = new System.Windows.Forms.Label();
			this.quotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.prodnoLabel2 = new System.Windows.Forms.Label();
			this.specinstTextBox = new System.Windows.Forms.TextBox();
			this.nopagesTextBox = new System.Windows.Forms.TextBox();
			this.prntsmpCheckBox = new System.Windows.Forms.CheckBox();
			this.reqstdcpyTextBox = new System.Windows.Forms.TextBox();
			this.endstrecvDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.endshtnoTextBox = new System.Windows.Forms.TextBox();
			this.csoffholdDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.csonholdDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.spotclrTextBox = new System.Windows.Forms.TextBox();
			this.perfbindTextBox = new System.Windows.Forms.TextBox();
			this.clr6TextBox = new System.Windows.Forms.TextBox();
			this.clr5TextBox = new System.Windows.Forms.TextBox();
			this.clr4TextBox = new System.Windows.Forms.TextBox();
			this.clr3TextBox = new System.Windows.Forms.TextBox();
			this.clr2TextBox = new System.Windows.Forms.TextBox();
			this.clr1TextBox = new System.Windows.Forms.TextBox();
			this.schcodeTextBox = new System.Windows.Forms.TextBox();
			this.schnameTextBox = new System.Windows.Forms.TextBox();
			this.Supplement = new System.Windows.Forms.TabPage();
			this.PreFlight = new System.Windows.Forms.TabPage();
			this.custTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.custTableAdapter();
			this.tableAdapterManager = new Mbc5.DataSets.dsEndSheetTableAdapters.TableAdapterManager();
			this.produtnTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.produtnTableAdapter();
			this.quotesTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.quotesTableAdapter();
			this.endsheetTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.endsheetTableAdapter();
			this.endsheetdetailTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.endsheetdetailTableAdapter();
			prodnoLabel = new System.Windows.Forms.Label();
			invnoLabel = new System.Windows.Forms.Label();
			clr1Label = new System.Windows.Forms.Label();
			clr2Label = new System.Windows.Forms.Label();
			clr3Label = new System.Windows.Forms.Label();
			clr4Label = new System.Windows.Forms.Label();
			clr5Label = new System.Windows.Forms.Label();
			clr6Label = new System.Windows.Forms.Label();
			perfbindLabel = new System.Windows.Forms.Label();
			spotclrLabel = new System.Windows.Forms.Label();
			csonholdLabel = new System.Windows.Forms.Label();
			csoffholdLabel = new System.Windows.Forms.Label();
			endstrecvLabel = new System.Windows.Forms.Label();
			reqstdcpyLabel = new System.Windows.Forms.Label();
			nopagesLabel = new System.Windows.Forms.Label();
			nocopiesLabel = new System.Windows.Forms.Label();
			frdescLabel = new System.Windows.Forms.Label();
			fldescLabel = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			prntsamLabel = new System.Windows.Forms.Label();
			reprntdteLabel = new System.Windows.Forms.Label();
			desorgdteLabel = new System.Windows.Forms.Label();
			persondestLabel = new System.Windows.Forms.Label();
			reasonLabel = new System.Windows.Forms.Label();
			this.tbEndSheets.SuspendLayout();
			this.pgEndSheets.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.endsheetdetailDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.endsheetdetailBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEndSheet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.endsheetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// prodnoLabel
			// 
			prodnoLabel.AutoSize = true;
			prodnoLabel.Location = new System.Drawing.Point(285, 7);
			prodnoLabel.Name = "prodnoLabel";
			prodnoLabel.Size = new System.Drawing.Size(41, 13);
			prodnoLabel.TabIndex = 4;
			prodnoLabel.Text = "Prod#";
			// 
			// invnoLabel
			// 
			invnoLabel.AutoSize = true;
			invnoLabel.Location = new System.Drawing.Point(423, 7);
			invnoLabel.Name = "invnoLabel";
			invnoLabel.Size = new System.Drawing.Size(57, 13);
			invnoLabel.TabIndex = 6;
			invnoLabel.Text = "Invoice#";
			// 
			// clr1Label
			// 
			clr1Label.AutoSize = true;
			clr1Label.Location = new System.Drawing.Point(13, 31);
			clr1Label.Name = "clr1Label";
			clr1Label.Size = new System.Drawing.Size(14, 13);
			clr1Label.TabIndex = 8;
			clr1Label.Text = "1";
			// 
			// clr2Label
			// 
			clr2Label.AutoSize = true;
			clr2Label.Location = new System.Drawing.Point(88, 31);
			clr2Label.Name = "clr2Label";
			clr2Label.Size = new System.Drawing.Size(14, 13);
			clr2Label.TabIndex = 10;
			clr2Label.Text = "2";
			// 
			// clr3Label
			// 
			clr3Label.AutoSize = true;
			clr3Label.Location = new System.Drawing.Point(160, 31);
			clr3Label.Name = "clr3Label";
			clr3Label.Size = new System.Drawing.Size(14, 13);
			clr3Label.TabIndex = 12;
			clr3Label.Text = "3";
			// 
			// clr4Label
			// 
			clr4Label.AutoSize = true;
			clr4Label.Location = new System.Drawing.Point(229, 31);
			clr4Label.Name = "clr4Label";
			clr4Label.Size = new System.Drawing.Size(14, 13);
			clr4Label.TabIndex = 14;
			clr4Label.Text = "4";
			// 
			// clr5Label
			// 
			clr5Label.AutoSize = true;
			clr5Label.Location = new System.Drawing.Point(297, 31);
			clr5Label.Name = "clr5Label";
			clr5Label.Size = new System.Drawing.Size(14, 13);
			clr5Label.TabIndex = 16;
			clr5Label.Text = "5";
			// 
			// clr6Label
			// 
			clr6Label.AutoSize = true;
			clr6Label.Location = new System.Drawing.Point(364, 31);
			clr6Label.Name = "clr6Label";
			clr6Label.Size = new System.Drawing.Size(14, 13);
			clr6Label.TabIndex = 18;
			clr6Label.Text = "6";
			// 
			// perfbindLabel
			// 
			perfbindLabel.AutoSize = true;
			perfbindLabel.Location = new System.Drawing.Point(435, 31);
			perfbindLabel.Name = "perfbindLabel";
			perfbindLabel.Size = new System.Drawing.Size(32, 13);
			perfbindLabel.TabIndex = 20;
			perfbindLabel.Text = "Bind";
			// 
			// spotclrLabel
			// 
			spotclrLabel.AutoSize = true;
			spotclrLabel.Location = new System.Drawing.Point(508, 31);
			spotclrLabel.Name = "spotclrLabel";
			spotclrLabel.Size = new System.Drawing.Size(66, 13);
			spotclrLabel.TabIndex = 22;
			spotclrLabel.Text = "#Spot Clrs";
			// 
			// csonholdLabel
			// 
			csonholdLabel.AutoSize = true;
			csonholdLabel.Location = new System.Drawing.Point(642, 31);
			csonholdLabel.Name = "csonholdLabel";
			csonholdLabel.Size = new System.Drawing.Size(73, 13);
			csonholdLabel.TabIndex = 24;
			csonholdLabel.Text = "CS On Hold";
			// 
			// csoffholdLabel
			// 
			csoffholdLabel.AutoSize = true;
			csoffholdLabel.Location = new System.Drawing.Point(641, 56);
			csoffholdLabel.Name = "csoffholdLabel";
			csoffholdLabel.Size = new System.Drawing.Size(74, 13);
			csoffholdLabel.TabIndex = 26;
			csoffholdLabel.Text = "CS Off Hold";
			// 
			// endstrecvLabel
			// 
			endstrecvLabel.AutoSize = true;
			endstrecvLabel.Location = new System.Drawing.Point(643, 83);
			endstrecvLabel.Name = "endstrecvLabel";
			endstrecvLabel.Size = new System.Drawing.Size(72, 13);
			endstrecvLabel.TabIndex = 30;
			endstrecvLabel.Text = "Recv. Date";
			// 
			// reqstdcpyLabel
			// 
			reqstdcpyLabel.AutoSize = true;
			reqstdcpyLabel.Location = new System.Drawing.Point(162, 56);
			reqstdcpyLabel.Name = "reqstdcpyLabel";
			reqstdcpyLabel.Size = new System.Drawing.Size(87, 13);
			reqstdcpyLabel.TabIndex = 32;
			reqstdcpyLabel.Text = "Rqst # Copies";
			// 
			// nopagesLabel
			// 
			nopagesLabel.AutoSize = true;
			nopagesLabel.Location = new System.Drawing.Point(324, 56);
			nopagesLabel.Name = "nopagesLabel";
			nopagesLabel.Size = new System.Drawing.Size(54, 13);
			nopagesLabel.TabIndex = 35;
			nopagesLabel.Text = "# Pages";
			// 
			// nocopiesLabel
			// 
			nocopiesLabel.AutoSize = true;
			nocopiesLabel.Location = new System.Drawing.Point(72, 37);
			nocopiesLabel.Name = "nocopiesLabel";
			nocopiesLabel.Size = new System.Drawing.Size(45, 13);
			nocopiesLabel.TabIndex = 39;
			nocopiesLabel.Text = "Copies";
			// 
			// frdescLabel
			// 
			frdescLabel.AutoSize = true;
			frdescLabel.Location = new System.Drawing.Point(12, 86);
			frdescLabel.Name = "frdescLabel";
			frdescLabel.Size = new System.Drawing.Size(105, 13);
			frdescLabel.TabIndex = 41;
			frdescLabel.Text = "Right Description";
			// 
			// fldescLabel
			// 
			fldescLabel.AutoSize = true;
			fldescLabel.Location = new System.Drawing.Point(20, 63);
			fldescLabel.Name = "fldescLabel";
			fldescLabel.Size = new System.Drawing.Size(97, 13);
			fldescLabel.TabIndex = 43;
			fldescLabel.Text = "Left Description";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(72, 43);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(45, 13);
			label3.TabIndex = 47;
			label3.Text = "Copies";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(20, 69);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(97, 13);
			label4.TabIndex = 51;
			label4.Text = "Left Description";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(12, 92);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(105, 13);
			label5.TabIndex = 52;
			label5.Text = "Right Description";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(19, 263);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(106, 13);
			label6.TabIndex = 53;
			label6.Text = "Spec Instructions";
			// 
			// prntsamLabel
			// 
			prntsamLabel.AutoSize = true;
			prntsamLabel.Location = new System.Drawing.Point(607, 338);
			prntsamLabel.Name = "prntsamLabel";
			prntsamLabel.Size = new System.Drawing.Size(98, 13);
			prntsamLabel.TabIndex = 83;
			prntsamLabel.Text = "Print Samp Sent";
			// 
			// reprntdteLabel
			// 
			reprntdteLabel.AutoSize = true;
			reprntdteLabel.Location = new System.Drawing.Point(626, 364);
			reprntdteLabel.Name = "reprntdteLabel";
			reprntdteLabel.Size = new System.Drawing.Size(79, 13);
			reprntdteLabel.TabIndex = 84;
			reprntdteLabel.Text = "Reprint Date";
			// 
			// desorgdteLabel
			// 
			desorgdteLabel.AutoSize = true;
			desorgdteLabel.Location = new System.Drawing.Point(579, 392);
			desorgdteLabel.Name = "desorgdteLabel";
			desorgdteLabel.Size = new System.Drawing.Size(126, 13);
			desorgdteLabel.TabIndex = 85;
			desorgdteLabel.Text = "Date Orig. Destroyed";
			// 
			// persondestLabel
			// 
			persondestLabel.AutoSize = true;
			persondestLabel.Location = new System.Drawing.Point(936, 384);
			persondestLabel.Name = "persondestLabel";
			persondestLabel.Size = new System.Drawing.Size(44, 13);
			persondestLabel.TabIndex = 89;
			persondestLabel.Text = "Initials";
			// 
			// reasonLabel
			// 
			reasonLabel.AutoSize = true;
			reasonLabel.Location = new System.Drawing.Point(751, 419);
			reasonLabel.Name = "reasonLabel";
			reasonLabel.Size = new System.Drawing.Size(50, 13);
			reasonLabel.TabIndex = 90;
			reasonLabel.Text = "Reason";
			// 
			// tbEndSheets
			// 
			this.tbEndSheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbEndSheets.Controls.Add(this.pgEndSheets);
			this.tbEndSheets.Controls.Add(this.Supplement);
			this.tbEndSheets.Controls.Add(this.PreFlight);
			this.tbEndSheets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbEndSheets.Location = new System.Drawing.Point(0, 0);
			this.tbEndSheets.Name = "tbEndSheets";
			this.tbEndSheets.SelectedIndex = 0;
			this.tbEndSheets.Size = new System.Drawing.Size(1230, 763);
			this.tbEndSheets.TabIndex = 0;
			// 
			// pgEndSheets
			// 
			this.pgEndSheets.AutoScroll = true;
			this.pgEndSheets.BackColor = System.Drawing.SystemColors.Control;
			this.pgEndSheets.Controls.Add(this.btnInvoiceSrch);
			this.pgEndSheets.Controls.Add(this.txtInvoiceNoSrch);
			this.pgEndSheets.Controls.Add(this.endsheetdetailDataGridView);
			this.pgEndSheets.Controls.Add(reasonLabel);
			this.pgEndSheets.Controls.Add(this.reasonTextBox);
			this.pgEndSheets.Controls.Add(persondestLabel);
			this.pgEndSheets.Controls.Add(this.persondestTextBox);
			this.pgEndSheets.Controls.Add(this.reprnacpCheckBox);
			this.pgEndSheets.Controls.Add(this.acceptdCheckBox);
			this.pgEndSheets.Controls.Add(this.remakeCheckBox);
			this.pgEndSheets.Controls.Add(desorgdteLabel);
			this.pgEndSheets.Controls.Add(this.desorgdteDateTimePicker);
			this.pgEndSheets.Controls.Add(reprntdteLabel);
			this.pgEndSheets.Controls.Add(this.reprntdteDateTimePicker);
			this.pgEndSheets.Controls.Add(prntsamLabel);
			this.pgEndSheets.Controls.Add(this.prntsamDateTimePicker);
			this.pgEndSheets.Controls.Add(this.otdtebkDateTimePicker);
			this.pgEndSheets.Controls.Add(this.otdtesentDateTimePicker);
			this.pgEndSheets.Controls.Add(this.dcdtebkDateTimePicker);
			this.pgEndSheets.Controls.Add(this.dcdtesentDateTimePicker);
			this.pgEndSheets.Controls.Add(this.lamdtebkDateTimePicker);
			this.pgEndSheets.Controls.Add(this.lamdtesentDateTimePicker);
			this.pgEndSheets.Controls.Add(this.prtdtebkDateTimePicker);
			this.pgEndSheets.Controls.Add(this.prtdtesentDateTimePicker);
			this.pgEndSheets.Controls.Add(this.othrvendTextBox);
			this.pgEndSheets.Controls.Add(this.dcvendTextBox);
			this.pgEndSheets.Controls.Add(this.lamvendTextBox);
			this.pgEndSheets.Controls.Add(this.prtvendTextBox);
			this.pgEndSheets.Controls.Add(this.diecutCheckBox);
			this.pgEndSheets.Controls.Add(this.othrCheckBox);
			this.pgEndSheets.Controls.Add(this.laminatedCheckBox);
			this.pgEndSheets.Controls.Add(this.label11);
			this.pgEndSheets.Controls.Add(this.label12);
			this.pgEndSheets.Controls.Add(this.label13);
			this.pgEndSheets.Controls.Add(this.label14);
			this.pgEndSheets.Controls.Add(this.label10);
			this.pgEndSheets.Controls.Add(this.label9);
			this.pgEndSheets.Controls.Add(this.label8);
			this.pgEndSheets.Controls.Add(this.label7);
			this.pgEndSheets.Controls.Add(this.groupBox2);
			this.pgEndSheets.Controls.Add(this.groupBox1);
			this.pgEndSheets.Controls.Add(this.button1);
			this.pgEndSheets.Controls.Add(this.invnoLabel2);
			this.pgEndSheets.Controls.Add(this.prodnoLabel2);
			this.pgEndSheets.Controls.Add(this.specinstTextBox);
			this.pgEndSheets.Controls.Add(label6);
			this.pgEndSheets.Controls.Add(nopagesLabel);
			this.pgEndSheets.Controls.Add(this.nopagesTextBox);
			this.pgEndSheets.Controls.Add(this.prntsmpCheckBox);
			this.pgEndSheets.Controls.Add(reqstdcpyLabel);
			this.pgEndSheets.Controls.Add(this.reqstdcpyTextBox);
			this.pgEndSheets.Controls.Add(endstrecvLabel);
			this.pgEndSheets.Controls.Add(this.endstrecvDateTimePicker);
			this.pgEndSheets.Controls.Add(this.endshtnoTextBox);
			this.pgEndSheets.Controls.Add(csoffholdLabel);
			this.pgEndSheets.Controls.Add(this.csoffholdDateTimePicker);
			this.pgEndSheets.Controls.Add(csonholdLabel);
			this.pgEndSheets.Controls.Add(this.csonholdDateTimePicker);
			this.pgEndSheets.Controls.Add(spotclrLabel);
			this.pgEndSheets.Controls.Add(this.spotclrTextBox);
			this.pgEndSheets.Controls.Add(perfbindLabel);
			this.pgEndSheets.Controls.Add(this.perfbindTextBox);
			this.pgEndSheets.Controls.Add(clr6Label);
			this.pgEndSheets.Controls.Add(this.clr6TextBox);
			this.pgEndSheets.Controls.Add(clr5Label);
			this.pgEndSheets.Controls.Add(this.clr5TextBox);
			this.pgEndSheets.Controls.Add(clr4Label);
			this.pgEndSheets.Controls.Add(this.clr4TextBox);
			this.pgEndSheets.Controls.Add(clr3Label);
			this.pgEndSheets.Controls.Add(this.clr3TextBox);
			this.pgEndSheets.Controls.Add(clr2Label);
			this.pgEndSheets.Controls.Add(this.clr2TextBox);
			this.pgEndSheets.Controls.Add(clr1Label);
			this.pgEndSheets.Controls.Add(this.clr1TextBox);
			this.pgEndSheets.Controls.Add(invnoLabel);
			this.pgEndSheets.Controls.Add(prodnoLabel);
			this.pgEndSheets.Controls.Add(this.schcodeTextBox);
			this.pgEndSheets.Controls.Add(this.schnameTextBox);
			this.pgEndSheets.Location = new System.Drawing.Point(4, 22);
			this.pgEndSheets.Name = "pgEndSheets";
			this.pgEndSheets.Padding = new System.Windows.Forms.Padding(3);
			this.pgEndSheets.Size = new System.Drawing.Size(1222, 737);
			this.pgEndSheets.TabIndex = 0;
			this.pgEndSheets.Text = "End Sheet";
			// 
			// btnInvoiceSrch
			// 
			this.btnInvoiceSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInvoiceSrch.Location = new System.Drawing.Point(997, 10);
			this.btnInvoiceSrch.Name = "btnInvoiceSrch";
			this.btnInvoiceSrch.Size = new System.Drawing.Size(109, 23);
			this.btnInvoiceSrch.TabIndex = 139;
			this.btnInvoiceSrch.Text = "Search Invoice#";
			this.btnInvoiceSrch.UseVisualStyleBackColor = true;
			this.btnInvoiceSrch.Click += new System.EventHandler(this.btnInvoiceSrch_Click);
			// 
			// txtInvoiceNoSrch
			// 
			this.txtInvoiceNoSrch.Location = new System.Drawing.Point(1111, 10);
			this.txtInvoiceNoSrch.Name = "txtInvoiceNoSrch";
			this.txtInvoiceNoSrch.Size = new System.Drawing.Size(105, 20);
			this.txtInvoiceNoSrch.TabIndex = 138;
			// 
			// endsheetdetailDataGridView
			// 
			this.endsheetdetailDataGridView.AllowUserToAddRows = false;
			this.endsheetdetailDataGridView.AllowUserToDeleteRows = false;
			this.endsheetdetailDataGridView.AllowUserToOrderColumns = true;
			this.endsheetdetailDataGridView.AutoGenerateColumns = false;
			this.endsheetdetailDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.endsheetdetailDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.endsheetdetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.endsheetdetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
			this.endsheetdetailDataGridView.DataSource = this.endsheetdetailBindingSource;
			this.endsheetdetailDataGridView.EnableHeadersVisualStyles = false;
			this.endsheetdetailDataGridView.Location = new System.Drawing.Point(78, 460);
			this.endsheetdetailDataGridView.Name = "endsheetdetailDataGridView";
			this.endsheetdetailDataGridView.RowHeadersVisible = false;
			this.endsheetdetailDataGridView.Size = new System.Drawing.Size(955, 220);
			this.endsheetdetailDataGridView.TabIndex = 91;
			// 
			// Description
			// 
			this.Description.DataPropertyName = "Description";
			this.Description.HeaderText = "Description";
			this.Description.Name = "Description";
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "war";
			this.dataGridViewTextBoxColumn2.HeaderText = "Actual";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "wdr";
			this.dataGridViewTextBoxColumn3.HeaderText = "Due";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "wtr";
			this.dataGridViewTextBoxColumn4.HeaderText = "Time";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "Invno";
			this.dataGridViewTextBoxColumn5.HeaderText = "Invno";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Visible = false;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "wir";
			this.dataGridViewTextBoxColumn6.HeaderText = "Initials";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.DataPropertyName = "Id";
			this.dataGridViewTextBoxColumn7.HeaderText = "Id";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Visible = false;
			// 
			// endsheetdetailBindingSource
			// 
			this.endsheetdetailBindingSource.DataMember = "endsheetdetail";
			this.endsheetdetailBindingSource.DataSource = this.dsEndSheet;
			// 
			// dsEndSheet
			// 
			this.dsEndSheet.DataSetName = "dsEndSheet";
			this.dsEndSheet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// reasonTextBox
			// 
			this.reasonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "reason", true));
			this.reasonTextBox.Location = new System.Drawing.Point(806, 416);
			this.reasonTextBox.Multiline = true;
			this.reasonTextBox.Name = "reasonTextBox";
			this.reasonTextBox.Size = new System.Drawing.Size(229, 38);
			this.reasonTextBox.TabIndex = 91;
			// 
			// endsheetBindingSource
			// 
			this.endsheetBindingSource.DataMember = "endsheet";
			this.endsheetBindingSource.DataSource = this.dsEndSheet;
			// 
			// persondestTextBox
			// 
			this.persondestTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "persondest", true));
			this.persondestTextBox.Location = new System.Drawing.Point(986, 384);
			this.persondestTextBox.Name = "persondestTextBox";
			this.persondestTextBox.Size = new System.Drawing.Size(49, 20);
			this.persondestTextBox.TabIndex = 90;
			// 
			// reprnacpCheckBox
			// 
			this.reprnacpCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.endsheetBindingSource, "reprnacp", true));
			this.reprnacpCheckBox.Location = new System.Drawing.Point(929, 360);
			this.reprnacpCheckBox.Name = "reprnacpCheckBox";
			this.reprnacpCheckBox.Size = new System.Drawing.Size(126, 24);
			this.reprnacpCheckBox.TabIndex = 89;
			this.reprnacpCheckBox.Text = "RePrnt Accpeted";
			this.reprnacpCheckBox.UseVisualStyleBackColor = true;
			// 
			// acceptdCheckBox
			// 
			this.acceptdCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.endsheetBindingSource, "acceptd", true));
			this.acceptdCheckBox.Location = new System.Drawing.Point(929, 339);
			this.acceptdCheckBox.Name = "acceptdCheckBox";
			this.acceptdCheckBox.Size = new System.Drawing.Size(104, 24);
			this.acceptdCheckBox.TabIndex = 88;
			this.acceptdCheckBox.Text = "Accepted";
			this.acceptdCheckBox.UseVisualStyleBackColor = true;
			// 
			// remakeCheckBox
			// 
			this.remakeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.endsheetBindingSource, "remake", true));
			this.remakeCheckBox.Location = new System.Drawing.Point(593, 409);
			this.remakeCheckBox.Name = "remakeCheckBox";
			this.remakeCheckBox.Size = new System.Drawing.Size(104, 24);
			this.remakeCheckBox.TabIndex = 87;
			this.remakeCheckBox.Text = "Remake";
			this.remakeCheckBox.UseVisualStyleBackColor = true;
			// 
			// desorgdteDateTimePicker
			// 
			this.desorgdteDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "desorgdte", true));
			this.desorgdteDateTimePicker.Location = new System.Drawing.Point(711, 390);
			this.desorgdteDateTimePicker.Name = "desorgdteDateTimePicker";
			this.desorgdteDateTimePicker.Size = new System.Drawing.Size(212, 20);
			this.desorgdteDateTimePicker.TabIndex = 86;
			// 
			// reprntdteDateTimePicker
			// 
			this.reprntdteDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "reprntdte", true));
			this.reprntdteDateTimePicker.Location = new System.Drawing.Point(711, 364);
			this.reprntdteDateTimePicker.Name = "reprntdteDateTimePicker";
			this.reprntdteDateTimePicker.Size = new System.Drawing.Size(212, 20);
			this.reprntdteDateTimePicker.TabIndex = 85;
			// 
			// prntsamDateTimePicker
			// 
			this.prntsamDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "prntsam", true));
			this.prntsamDateTimePicker.Location = new System.Drawing.Point(711, 338);
			this.prntsamDateTimePicker.Name = "prntsamDateTimePicker";
			this.prntsamDateTimePicker.Size = new System.Drawing.Size(212, 20);
			this.prntsamDateTimePicker.TabIndex = 84;
			// 
			// otdtebkDateTimePicker
			// 
			this.otdtebkDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "otdtebk", true));
			this.otdtebkDateTimePicker.Location = new System.Drawing.Point(360, 408);
			this.otdtebkDateTimePicker.Name = "otdtebkDateTimePicker";
			this.otdtebkDateTimePicker.Size = new System.Drawing.Size(213, 20);
			this.otdtebkDateTimePicker.TabIndex = 82;
			// 
			// otdtesentDateTimePicker
			// 
			this.otdtesentDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "otdtesent", true));
			this.otdtesentDateTimePicker.Location = new System.Drawing.Point(136, 408);
			this.otdtesentDateTimePicker.Name = "otdtesentDateTimePicker";
			this.otdtesentDateTimePicker.Size = new System.Drawing.Size(213, 20);
			this.otdtesentDateTimePicker.TabIndex = 81;
			// 
			// dcdtebkDateTimePicker
			// 
			this.dcdtebkDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "dcdtebk", true));
			this.dcdtebkDateTimePicker.Location = new System.Drawing.Point(360, 384);
			this.dcdtebkDateTimePicker.Name = "dcdtebkDateTimePicker";
			this.dcdtebkDateTimePicker.Size = new System.Drawing.Size(213, 20);
			this.dcdtebkDateTimePicker.TabIndex = 80;
			// 
			// dcdtesentDateTimePicker
			// 
			this.dcdtesentDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "dcdtesent", true));
			this.dcdtesentDateTimePicker.Location = new System.Drawing.Point(136, 384);
			this.dcdtesentDateTimePicker.Name = "dcdtesentDateTimePicker";
			this.dcdtesentDateTimePicker.Size = new System.Drawing.Size(213, 20);
			this.dcdtesentDateTimePicker.TabIndex = 79;
			// 
			// lamdtebkDateTimePicker
			// 
			this.lamdtebkDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "lamdtebk", true));
			this.lamdtebkDateTimePicker.Location = new System.Drawing.Point(360, 361);
			this.lamdtebkDateTimePicker.Name = "lamdtebkDateTimePicker";
			this.lamdtebkDateTimePicker.Size = new System.Drawing.Size(213, 20);
			this.lamdtebkDateTimePicker.TabIndex = 78;
			// 
			// lamdtesentDateTimePicker
			// 
			this.lamdtesentDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "lamdtesent", true));
			this.lamdtesentDateTimePicker.Location = new System.Drawing.Point(136, 361);
			this.lamdtesentDateTimePicker.Name = "lamdtesentDateTimePicker";
			this.lamdtesentDateTimePicker.Size = new System.Drawing.Size(213, 20);
			this.lamdtesentDateTimePicker.TabIndex = 77;
			// 
			// prtdtebkDateTimePicker
			// 
			this.prtdtebkDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "prtdtebk", true));
			this.prtdtebkDateTimePicker.Location = new System.Drawing.Point(360, 338);
			this.prtdtebkDateTimePicker.Name = "prtdtebkDateTimePicker";
			this.prtdtebkDateTimePicker.Size = new System.Drawing.Size(213, 20);
			this.prtdtebkDateTimePicker.TabIndex = 76;
			// 
			// prtdtesentDateTimePicker
			// 
			this.prtdtesentDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "prtdtesent", true));
			this.prtdtesentDateTimePicker.Location = new System.Drawing.Point(136, 338);
			this.prtdtesentDateTimePicker.Name = "prtdtesentDateTimePicker";
			this.prtdtesentDateTimePicker.Size = new System.Drawing.Size(213, 20);
			this.prtdtesentDateTimePicker.TabIndex = 75;
			// 
			// othrvendTextBox
			// 
			this.othrvendTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "othrvend", true));
			this.othrvendTextBox.Location = new System.Drawing.Point(88, 408);
			this.othrvendTextBox.Name = "othrvendTextBox";
			this.othrvendTextBox.Size = new System.Drawing.Size(37, 20);
			this.othrvendTextBox.TabIndex = 74;
			// 
			// dcvendTextBox
			// 
			this.dcvendTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "dcvend", true));
			this.dcvendTextBox.Location = new System.Drawing.Point(88, 384);
			this.dcvendTextBox.Name = "dcvendTextBox";
			this.dcvendTextBox.Size = new System.Drawing.Size(37, 20);
			this.dcvendTextBox.TabIndex = 73;
			// 
			// lamvendTextBox
			// 
			this.lamvendTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "lamvend", true));
			this.lamvendTextBox.Location = new System.Drawing.Point(88, 361);
			this.lamvendTextBox.Name = "lamvendTextBox";
			this.lamvendTextBox.Size = new System.Drawing.Size(37, 20);
			this.lamvendTextBox.TabIndex = 72;
			// 
			// prtvendTextBox
			// 
			this.prtvendTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "prtvend", true));
			this.prtvendTextBox.Location = new System.Drawing.Point(88, 338);
			this.prtvendTextBox.Name = "prtvendTextBox";
			this.prtvendTextBox.Size = new System.Drawing.Size(37, 20);
			this.prtvendTextBox.TabIndex = 71;
			// 
			// diecutCheckBox
			// 
			this.diecutCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.produtnBindingSource, "diecut", true));
			this.diecutCheckBox.Location = new System.Drawing.Point(63, 384);
			this.diecutCheckBox.Name = "diecutCheckBox";
			this.diecutCheckBox.Size = new System.Drawing.Size(17, 15);
			this.diecutCheckBox.TabIndex = 70;
			this.diecutCheckBox.UseVisualStyleBackColor = true;
			// 
			// produtnBindingSource
			// 
			this.produtnBindingSource.DataMember = "produtn";
			this.produtnBindingSource.DataSource = this.dsEndSheet;
			// 
			// othrCheckBox
			// 
			this.othrCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.endsheetBindingSource, "othr", true));
			this.othrCheckBox.Location = new System.Drawing.Point(63, 408);
			this.othrCheckBox.Name = "othrCheckBox";
			this.othrCheckBox.Size = new System.Drawing.Size(17, 13);
			this.othrCheckBox.TabIndex = 69;
			this.othrCheckBox.UseVisualStyleBackColor = true;
			// 
			// laminatedCheckBox
			// 
			this.laminatedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.produtnBindingSource, "laminated", true));
			this.laminatedCheckBox.Location = new System.Drawing.Point(63, 361);
			this.laminatedCheckBox.Name = "laminatedCheckBox";
			this.laminatedCheckBox.Size = new System.Drawing.Size(17, 19);
			this.laminatedCheckBox.TabIndex = 68;
			this.laminatedCheckBox.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(137, 319);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(60, 13);
			this.label11.TabIndex = 67;
			this.label11.Text = "DateSent";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(359, 319);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(67, 13);
			this.label12.TabIndex = 66;
			this.label12.Text = "Date Back";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(56, 319);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(30, 13);
			this.label13.TabIndex = 65;
			this.label13.Text = "Y/N";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(92, 319);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(36, 13);
			this.label14.TabIndex = 64;
			this.label14.Text = "Vend";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(24, 361);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(30, 13);
			this.label10.TabIndex = 63;
			this.label10.Text = "Lam";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(24, 384);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(30, 13);
			this.label9.TabIndex = 62;
			this.label9.Text = "D/C";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 408);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(38, 13);
			this.label8.TabIndex = 61;
			this.label8.Text = "Other";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(21, 338);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(33, 13);
			this.label7.TabIndex = 60;
			this.label7.Text = "Print";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.frcopiesTextBox);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(nocopiesLabel);
			this.groupBox2.Controls.Add(this.frdescTextBox);
			this.groupBox2.Controls.Add(frdescLabel);
			this.groupBox2.Controls.Add(this.fldescTextBox);
			this.groupBox2.Controls.Add(fldescLabel);
			this.groupBox2.Location = new System.Drawing.Point(16, 110);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(446, 142);
			this.groupBox2.TabIndex = 59;
			this.groupBox2.TabStop = false;
			// 
			// frcopiesTextBox
			// 
			this.frcopiesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "frcopies", true));
			this.frcopiesTextBox.Location = new System.Drawing.Point(124, 37);
			this.frcopiesTextBox.Name = "frcopiesTextBox";
			this.frcopiesTextBox.Size = new System.Drawing.Size(64, 20);
			this.frcopiesTextBox.TabIndex = 45;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(20, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 17);
			this.label1.TabIndex = 37;
			this.label1.Text = "Front End Sheet";
			// 
			// frdescTextBox
			// 
			this.frdescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "frdesc", true));
			this.frdescTextBox.Location = new System.Drawing.Point(124, 86);
			this.frdescTextBox.Name = "frdescTextBox";
			this.frdescTextBox.Size = new System.Drawing.Size(307, 20);
			this.frdescTextBox.TabIndex = 42;
			// 
			// fldescTextBox
			// 
			this.fldescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "fldesc", true));
			this.fldescTextBox.Location = new System.Drawing.Point(124, 63);
			this.fldescTextBox.Name = "fldescTextBox";
			this.fldescTextBox.Size = new System.Drawing.Size(307, 20);
			this.fldescTextBox.TabIndex = 44;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.bkcopiesTextBox);
			this.groupBox1.Controls.Add(label3);
			this.groupBox1.Controls.Add(this.bldescTextBox);
			this.groupBox1.Controls.Add(this.brdescTextBox);
			this.groupBox1.Controls.Add(label4);
			this.groupBox1.Controls.Add(label5);
			this.groupBox1.Location = new System.Drawing.Point(472, 110);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(446, 142);
			this.groupBox1.TabIndex = 58;
			this.groupBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(20, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 17);
			this.label2.TabIndex = 38;
			this.label2.Text = "Back End Sheet";
			// 
			// bkcopiesTextBox
			// 
			this.bkcopiesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "bkcopies", true));
			this.bkcopiesTextBox.Location = new System.Drawing.Point(121, 43);
			this.bkcopiesTextBox.Name = "bkcopiesTextBox";
			this.bkcopiesTextBox.Size = new System.Drawing.Size(64, 20);
			this.bkcopiesTextBox.TabIndex = 46;
			// 
			// bldescTextBox
			// 
			this.bldescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "bldesc", true));
			this.bldescTextBox.Location = new System.Drawing.Point(123, 69);
			this.bldescTextBox.Name = "bldescTextBox";
			this.bldescTextBox.Size = new System.Drawing.Size(307, 20);
			this.bldescTextBox.TabIndex = 48;
			// 
			// brdescTextBox
			// 
			this.brdescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "brdesc", true));
			this.brdescTextBox.Location = new System.Drawing.Point(123, 92);
			this.brdescTextBox.Name = "brdescTextBox";
			this.brdescTextBox.Size = new System.Drawing.Size(307, 20);
			this.brdescTextBox.TabIndex = 50;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(21, 56);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(60, 23);
			this.button1.TabIndex = 57;
			this.button1.Text = "Sheet #";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// invnoLabel2
			// 
			this.invnoLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "invno", true));
			this.invnoLabel2.Location = new System.Drawing.Point(486, 7);
			this.invnoLabel2.Name = "invnoLabel2";
			this.invnoLabel2.Size = new System.Drawing.Size(100, 23);
			this.invnoLabel2.TabIndex = 56;
			this.invnoLabel2.Text = "label7";
			// 
			// quotesBindingSource
			// 
			this.quotesBindingSource.DataMember = "cust_quotes";
			this.quotesBindingSource.DataSource = this.custBindingSource;
			// 
			// custBindingSource
			// 
			this.custBindingSource.DataMember = "cust";
			this.custBindingSource.DataSource = this.dsEndSheet;
			// 
			// prodnoLabel2
			// 
			this.prodnoLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "prodno", true));
			this.prodnoLabel2.Location = new System.Drawing.Point(332, 7);
			this.prodnoLabel2.Name = "prodnoLabel2";
			this.prodnoLabel2.Size = new System.Drawing.Size(84, 23);
			this.prodnoLabel2.TabIndex = 55;
			this.prodnoLabel2.Text = "label7";
			// 
			// specinstTextBox
			// 
			this.specinstTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "specinst", true));
			this.specinstTextBox.Location = new System.Drawing.Point(132, 263);
			this.specinstTextBox.Multiline = true;
			this.specinstTextBox.Name = "specinstTextBox";
			this.specinstTextBox.Size = new System.Drawing.Size(786, 41);
			this.specinstTextBox.TabIndex = 54;
			// 
			// nopagesTextBox
			// 
			this.nopagesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "nopages", true));
			this.nopagesTextBox.Location = new System.Drawing.Point(386, 56);
			this.nopagesTextBox.Name = "nopagesTextBox";
			this.nopagesTextBox.Size = new System.Drawing.Size(47, 20);
			this.nopagesTextBox.TabIndex = 36;
			// 
			// prntsmpCheckBox
			// 
			this.prntsmpCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.endsheetBindingSource, "prntsmp", true));
			this.prntsmpCheckBox.Location = new System.Drawing.Point(467, 56);
			this.prntsmpCheckBox.Name = "prntsmpCheckBox";
			this.prntsmpCheckBox.Size = new System.Drawing.Size(107, 24);
			this.prntsmpCheckBox.TabIndex = 35;
			this.prntsmpCheckBox.Text = "Permit Sample";
			this.prntsmpCheckBox.UseVisualStyleBackColor = true;
			// 
			// reqstdcpyTextBox
			// 
			this.reqstdcpyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "reqstdcpy", true));
			this.reqstdcpyTextBox.Location = new System.Drawing.Point(258, 56);
			this.reqstdcpyTextBox.Name = "reqstdcpyTextBox";
			this.reqstdcpyTextBox.Size = new System.Drawing.Size(53, 20);
			this.reqstdcpyTextBox.TabIndex = 33;
			// 
			// endstrecvDateTimePicker
			// 
			this.endstrecvDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "endstrecv", true));
			this.endstrecvDateTimePicker.Location = new System.Drawing.Point(719, 79);
			this.endstrecvDateTimePicker.Name = "endstrecvDateTimePicker";
			this.endstrecvDateTimePicker.Size = new System.Drawing.Size(211, 20);
			this.endstrecvDateTimePicker.TabIndex = 31;
			// 
			// endshtnoTextBox
			// 
			this.endshtnoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "endshtno", true));
			this.endshtnoTextBox.Location = new System.Drawing.Point(86, 56);
			this.endshtnoTextBox.Name = "endshtnoTextBox";
			this.endshtnoTextBox.Size = new System.Drawing.Size(67, 20);
			this.endshtnoTextBox.TabIndex = 29;
			// 
			// csoffholdDateTimePicker
			// 
			this.csoffholdDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "csoffhold", true));
			this.csoffholdDateTimePicker.Location = new System.Drawing.Point(719, 56);
			this.csoffholdDateTimePicker.Name = "csoffholdDateTimePicker";
			this.csoffholdDateTimePicker.Size = new System.Drawing.Size(211, 20);
			this.csoffholdDateTimePicker.TabIndex = 27;
			// 
			// csonholdDateTimePicker
			// 
			this.csonholdDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "csonhold", true));
			this.csonholdDateTimePicker.Location = new System.Drawing.Point(719, 31);
			this.csonholdDateTimePicker.Name = "csonholdDateTimePicker";
			this.csonholdDateTimePicker.Size = new System.Drawing.Size(211, 20);
			this.csonholdDateTimePicker.TabIndex = 25;
			// 
			// spotclrTextBox
			// 
			this.spotclrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "spotclr", true));
			this.spotclrTextBox.Location = new System.Drawing.Point(579, 31);
			this.spotclrTextBox.Name = "spotclrTextBox";
			this.spotclrTextBox.Size = new System.Drawing.Size(49, 20);
			this.spotclrTextBox.TabIndex = 23;
			// 
			// perfbindTextBox
			// 
			this.perfbindTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "perfbind", true));
			this.perfbindTextBox.Location = new System.Drawing.Point(467, 31);
			this.perfbindTextBox.Name = "perfbindTextBox";
			this.perfbindTextBox.Size = new System.Drawing.Size(32, 20);
			this.perfbindTextBox.TabIndex = 21;
			// 
			// clr6TextBox
			// 
			this.clr6TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr6", true));
			this.clr6TextBox.Location = new System.Drawing.Point(384, 31);
			this.clr6TextBox.Name = "clr6TextBox";
			this.clr6TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr6TextBox.TabIndex = 19;
			// 
			// clr5TextBox
			// 
			this.clr5TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr5", true));
			this.clr5TextBox.Location = new System.Drawing.Point(317, 31);
			this.clr5TextBox.Name = "clr5TextBox";
			this.clr5TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr5TextBox.TabIndex = 17;
			// 
			// clr4TextBox
			// 
			this.clr4TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr4", true));
			this.clr4TextBox.Location = new System.Drawing.Point(249, 31);
			this.clr4TextBox.Name = "clr4TextBox";
			this.clr4TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr4TextBox.TabIndex = 15;
			// 
			// clr3TextBox
			// 
			this.clr3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr3", true));
			this.clr3TextBox.Location = new System.Drawing.Point(180, 31);
			this.clr3TextBox.Name = "clr3TextBox";
			this.clr3TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr3TextBox.TabIndex = 13;
			// 
			// clr2TextBox
			// 
			this.clr2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr2", true));
			this.clr2TextBox.Location = new System.Drawing.Point(108, 31);
			this.clr2TextBox.Name = "clr2TextBox";
			this.clr2TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr2TextBox.TabIndex = 11;
			// 
			// clr1TextBox
			// 
			this.clr1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr1", true));
			this.clr1TextBox.Location = new System.Drawing.Point(33, 31);
			this.clr1TextBox.Name = "clr1TextBox";
			this.clr1TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr1TextBox.TabIndex = 9;
			// 
			// schcodeTextBox
			// 
			this.schcodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schcode", true));
			this.schcodeTextBox.Location = new System.Drawing.Point(13, 7);
			this.schcodeTextBox.Name = "schcodeTextBox";
			this.schcodeTextBox.Size = new System.Drawing.Size(68, 20);
			this.schcodeTextBox.TabIndex = 3;
			// 
			// schnameTextBox
			// 
			this.schnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schname", true));
			this.schnameTextBox.Location = new System.Drawing.Point(91, 7);
			this.schnameTextBox.Name = "schnameTextBox";
			this.schnameTextBox.Size = new System.Drawing.Size(188, 20);
			this.schnameTextBox.TabIndex = 1;
			// 
			// Supplement
			// 
			this.Supplement.BackColor = System.Drawing.SystemColors.Control;
			this.Supplement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Supplement.Location = new System.Drawing.Point(4, 22);
			this.Supplement.Name = "Supplement";
			this.Supplement.Padding = new System.Windows.Forms.Padding(3);
			this.Supplement.Size = new System.Drawing.Size(1222, 737);
			this.Supplement.TabIndex = 1;
			this.Supplement.Text = "Supplement";
			// 
			// PreFlight
			// 
			this.PreFlight.BackColor = System.Drawing.SystemColors.Control;
			this.PreFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PreFlight.Location = new System.Drawing.Point(4, 22);
			this.PreFlight.Name = "PreFlight";
			this.PreFlight.Size = new System.Drawing.Size(1222, 737);
			this.PreFlight.TabIndex = 2;
			this.PreFlight.Text = "PreFlight";
			// 
			// custTableAdapter
			// 
			this.custTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager
			// 
			this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager.custTableAdapter = this.custTableAdapter;
			this.tableAdapterManager.endsheetTableAdapter = null;
			this.tableAdapterManager.preflitTableAdapter = null;
			this.tableAdapterManager.produtnTableAdapter = null;
			this.tableAdapterManager.supplTableAdapter = null;
			this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsEndSheetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// produtnTableAdapter
			// 
			this.produtnTableAdapter.ClearBeforeFill = true;
			// 
			// quotesTableAdapter
			// 
			this.quotesTableAdapter.ClearBeforeFill = true;
			// 
			// endsheetTableAdapter
			// 
			this.endsheetTableAdapter.ClearBeforeFill = true;
			// 
			// endsheetdetailTableAdapter
			// 
			this.endsheetdetailTableAdapter.ClearBeforeFill = true;
			// 
			// frmEndSheet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1234, 764);
			this.Controls.Add(this.tbEndSheets);
			this.Name = "frmEndSheet";
			this.Text = "End Sheet/Supplements/Preflight";
			this.Load += new System.EventHandler(this.frmEndSheet_Load);
			this.tbEndSheets.ResumeLayout(false);
			this.pgEndSheets.ResumeLayout(false);
			this.pgEndSheets.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.endsheetdetailDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.endsheetdetailBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEndSheet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.endsheetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tbEndSheets;
		private System.Windows.Forms.TabPage pgEndSheets;
		private System.Windows.Forms.TabPage Supplement;
		private System.Windows.Forms.TabPage PreFlight;
		private DataSets.dsEndSheet dsEndSheet;
		private System.Windows.Forms.BindingSource custBindingSource;
		private DataSets.dsEndSheetTableAdapters.custTableAdapter custTableAdapter;
		private DataSets.dsEndSheetTableAdapters.TableAdapterManager tableAdapterManager;
		private System.Windows.Forms.TextBox schcodeTextBox;
		private System.Windows.Forms.TextBox schnameTextBox;
		private System.Windows.Forms.BindingSource produtnBindingSource;
		private DataSets.dsEndSheetTableAdapters.produtnTableAdapter produtnTableAdapter;
		private System.Windows.Forms.BindingSource quotesBindingSource;
		private DataSets.dsEndSheetTableAdapters.quotesTableAdapter quotesTableAdapter;
		private System.Windows.Forms.BindingSource endsheetBindingSource;
		private DataSets.dsEndSheetTableAdapters.endsheetTableAdapter endsheetTableAdapter;
		private System.Windows.Forms.TextBox clr6TextBox;
		private System.Windows.Forms.TextBox clr5TextBox;
		private System.Windows.Forms.TextBox clr4TextBox;
		private System.Windows.Forms.TextBox clr3TextBox;
		private System.Windows.Forms.TextBox clr2TextBox;
		private System.Windows.Forms.TextBox clr1TextBox;
		private System.Windows.Forms.TextBox perfbindTextBox;
		private System.Windows.Forms.TextBox spotclrTextBox;
		private System.Windows.Forms.TextBox reqstdcpyTextBox;
		private System.Windows.Forms.DateTimePicker endstrecvDateTimePicker;
		private System.Windows.Forms.TextBox endshtnoTextBox;
		private System.Windows.Forms.DateTimePicker csoffholdDateTimePicker;
		private System.Windows.Forms.DateTimePicker csonholdDateTimePicker;
		private System.Windows.Forms.CheckBox prntsmpCheckBox;
		private System.Windows.Forms.TextBox nopagesTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox fldescTextBox;
		private System.Windows.Forms.TextBox frdescTextBox;
		private System.Windows.Forms.Label invnoLabel2;
		private System.Windows.Forms.Label prodnoLabel2;
		private System.Windows.Forms.TextBox specinstTextBox;
		private System.Windows.Forms.TextBox brdescTextBox;
		private System.Windows.Forms.TextBox bldescTextBox;
		private System.Windows.Forms.TextBox bkcopiesTextBox;
		private System.Windows.Forms.TextBox frcopiesTextBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox othrCheckBox;
		private System.Windows.Forms.CheckBox laminatedCheckBox;
		private System.Windows.Forms.DateTimePicker otdtebkDateTimePicker;
		private System.Windows.Forms.DateTimePicker otdtesentDateTimePicker;
		private System.Windows.Forms.DateTimePicker dcdtebkDateTimePicker;
		private System.Windows.Forms.DateTimePicker dcdtesentDateTimePicker;
		private System.Windows.Forms.DateTimePicker lamdtebkDateTimePicker;
		private System.Windows.Forms.DateTimePicker lamdtesentDateTimePicker;
		private System.Windows.Forms.DateTimePicker prtdtebkDateTimePicker;
		private System.Windows.Forms.DateTimePicker prtdtesentDateTimePicker;
		private System.Windows.Forms.TextBox othrvendTextBox;
		private System.Windows.Forms.TextBox dcvendTextBox;
		private System.Windows.Forms.TextBox lamvendTextBox;
		private System.Windows.Forms.TextBox prtvendTextBox;
		private System.Windows.Forms.CheckBox diecutCheckBox;
		private System.Windows.Forms.TextBox reasonTextBox;
		private System.Windows.Forms.TextBox persondestTextBox;
		private System.Windows.Forms.CheckBox reprnacpCheckBox;
		private System.Windows.Forms.CheckBox acceptdCheckBox;
		private System.Windows.Forms.CheckBox remakeCheckBox;
		private System.Windows.Forms.DateTimePicker desorgdteDateTimePicker;
		private System.Windows.Forms.DateTimePicker reprntdteDateTimePicker;
		private System.Windows.Forms.DateTimePicker prntsamDateTimePicker;
		private System.Windows.Forms.BindingSource endsheetdetailBindingSource;
		private DataSets.dsEndSheetTableAdapters.endsheetdetailTableAdapter endsheetdetailTableAdapter;
		private System.Windows.Forms.DataGridView endsheetdetailDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.Button btnInvoiceSrch;
		private System.Windows.Forms.TextBox txtInvoiceNoSrch;
	}
}
