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
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label nopagesLabel1;
            System.Windows.Forms.Label nocopiesLabel1;
            System.Windows.Forms.Label recvdteLabel;
            System.Windows.Forms.Label duedateLabel;
            System.Windows.Forms.Label booktypeLabel;
            System.Windows.Forms.Label totsigsLabel;
            System.Windows.Forms.Label partmemoLabel;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label specinstLabel;
            System.Windows.Forms.Label customdescLabel;
            System.Windows.Forms.Label txtcolorLabel;
            System.Windows.Forms.Label bkcolorLabel;
            System.Windows.Forms.Label mascotnameLabel;
            System.Windows.Forms.Label mascotslogLabel;
            System.Windows.Forms.Label endstrecvLabel1;
            System.Windows.Forms.Label qtyLabel;
            System.Windows.Forms.Label numLabel;
            System.Windows.Forms.Label label37;
            System.Windows.Forms.Label label39;
            System.Windows.Forms.Label label34;
            System.Windows.Forms.Label label35;
            System.Windows.Forms.Label supnoLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbEndSheets = new System.Windows.Forms.TabControl();
            this.pgEndSheets = new System.Windows.Forms.TabPage();
            this.btnNewEndSheetScanRec = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnUpdateDates = new System.Windows.Forms.Button();
            this.btnAddEndSheetRecord = new System.Windows.Forms.Button();
            this.btnEndSheetTicket = new System.Windows.Forms.Button();
            this.desorgdteDateBox = new CustomControls.DateBox();
            this.endsheetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsEndSheet = new Mbc5.DataSets.dsEndSheet();
            this.reprntdteDateBox = new CustomControls.DateBox();
            this.prntsamDateBox = new CustomControls.DateBox();
            this.otdtebkDateBox = new CustomControls.DateBox();
            this.dcdtebkDateBox = new CustomControls.DateBox();
            this.lamdtebkDateBox = new CustomControls.DateBox();
            this.prtdtebkDateBox = new CustomControls.DateBox();
            this.otdtesentDateBox = new CustomControls.DateBox();
            this.dcdtesentDateBox = new CustomControls.DateBox();
            this.lamdtesentDateBox = new CustomControls.DateBox();
            this.prtdtesentDateBox = new CustomControls.DateBox();
            this.endstrecvDateBox = new CustomControls.DateBox();
            this.csoffholdDateBox = new CustomControls.DateBox();
            this.csonholdDateBox = new CustomControls.DateBox();
            this.laminatedTextBox = new System.Windows.Forms.TextBox();
            this.produtnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.endsheetdetailDataGridView = new System.Windows.Forms.DataGridView();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endsheetdetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reasonTextBox = new System.Windows.Forms.TextBox();
            this.persondestTextBox = new System.Windows.Forms.TextBox();
            this.reprnacpCheckBox = new System.Windows.Forms.CheckBox();
            this.acceptdCheckBox = new System.Windows.Forms.CheckBox();
            this.remakeCheckBox = new System.Windows.Forms.CheckBox();
            this.othrvendTextBox = new System.Windows.Forms.TextBox();
            this.dcvendTextBox = new System.Windows.Forms.TextBox();
            this.lamvendTextBox = new System.Windows.Forms.TextBox();
            this.prtvendTextBox = new System.Windows.Forms.TextBox();
            this.diecutCheckBox = new System.Windows.Forms.CheckBox();
            this.othrCheckBox = new System.Windows.Forms.CheckBox();
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
            this.invnoLabel2 = new System.Windows.Forms.Label();
            this.prodnoLabel2 = new System.Windows.Forms.Label();
            this.specinstTextBox = new System.Windows.Forms.TextBox();
            this.nopagesTextBox = new System.Windows.Forms.TextBox();
            this.prntsmpCheckBox = new System.Windows.Forms.CheckBox();
            this.reqstdcpyTextBox = new System.Windows.Forms.TextBox();
            this.endshtnoTextBox = new System.Windows.Forms.TextBox();
            this.spotclrTextBox = new System.Windows.Forms.TextBox();
            this.perfbindTextBox = new System.Windows.Forms.TextBox();
            this.clr6TextBox = new System.Windows.Forms.TextBox();
            this.clr5TextBox = new System.Windows.Forms.TextBox();
            this.clr4TextBox = new System.Windows.Forms.TextBox();
            this.clr3TextBox = new System.Windows.Forms.TextBox();
            this.clr2TextBox = new System.Windows.Forms.TextBox();
            this.clr1TextBox = new System.Windows.Forms.TextBox();
            this.txtSchname = new System.Windows.Forms.TextBox();
            this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Supplement = new System.Windows.Forms.TabPage();
            this.btnAddSupplScan = new System.Windows.Forms.Button();
            this.supnoLabel1 = new System.Windows.Forms.Label();
            this.supplBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nocopiesTextBox1 = new System.Windows.Forms.TextBox();
            this.btnUpdateSuppDates = new System.Windows.Forms.Button();
            this.btnAddSupp = new System.Windows.Forms.Button();
            this.btnPrintSuppTicket = new System.Windows.Forms.Button();
            this.duedateDateBox = new CustomControls.DateBox();
            this.recvdteDateBox = new CustomControls.DateBox();
            this.rmbfrmDateBox = new CustomControls.DateBox();
            this.rmbtoDateBox = new CustomControls.DateBox();
            this.frmbindDateBox = new CustomControls.DateBox();
            this.binddteDateBox = new CustomControls.DateBox();
            this.ioutDateBox = new CustomControls.DateBox();
            this.iinDateBox = new CustomControls.DateBox();
            this.label28 = new System.Windows.Forms.Label();
            this.quotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.suppdetailDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppdetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partmemoTextBox = new System.Windows.Forms.TextBox();
            this.totsigsTextBox = new System.Windows.Forms.TextBox();
            this.supplementsCheckBox = new System.Windows.Forms.CheckBox();
            this.oursuppCheckBox = new System.Windows.Forms.CheckBox();
            this.rmbtotTextBox = new System.Windows.Forms.TextBox();
            this.remaketypeComboBox = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tape_1CheckBox = new System.Windows.Forms.CheckBox();
            this.vendcdTextBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.iinitTextBox = new System.Windows.Forms.TextBox();
            this.ideptTextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.booktypeLabel1 = new System.Windows.Forms.Label();
            this.nocopiesTextBox = new System.Windows.Forms.TextBox();
            this.nopagesTextBox1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Banner = new System.Windows.Forms.TabPage();
            this.btnAddBannerWip = new System.Windows.Forms.Button();
            this.btnUpdateBannerDates = new System.Windows.Forms.Button();
            this.btnAddBanner = new System.Windows.Forms.Button();
            this.btnPrintBannerTicket = new System.Windows.Forms.Button();
            this.bannerdetailDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bannerdetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bannerrecvDateBox = new CustomControls.DateBox();
            this.bannerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.specinstTextBox1 = new System.Windows.Forms.TextBox();
            this.customdescTextBox = new System.Windows.Forms.TextBox();
            this.customCheckBox = new System.Windows.Forms.CheckBox();
            this.txtcolorComboBox = new System.Windows.Forms.ComboBox();
            this.bkcolorComboBox = new System.Windows.Forms.ComboBox();
            this.yrbksaleCheckBox = new System.Windows.Forms.CheckBox();
            this.mascotnameComboBox = new System.Windows.Forms.ComboBox();
            this.mascotslogTextBox = new System.Windows.Forms.TextBox();
            this.mascotCheckBox = new System.Windows.Forms.CheckBox();
            this.qtyTextBox = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numTextBox = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.preflitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.custTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.custTableAdapter();
            this.produtnTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.produtnTableAdapter();
            this.quotesTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.quotesTableAdapter();
            this.endsheetTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.endsheetTableAdapter();
            this.endsheetdetailTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.endsheetdetailTableAdapter();
            this.supplTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.supplTableAdapter();
            this.suppdetailTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.suppdetailTableAdapter();
            this.preflitTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.preflitTableAdapter();
            this.bannerTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.bannerTableAdapter();
            this.bannerdetailTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.bannerdetailTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsEndSheetTableAdapters.TableAdapterManager();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
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
            label16 = new System.Windows.Forms.Label();
            nopagesLabel1 = new System.Windows.Forms.Label();
            nocopiesLabel1 = new System.Windows.Forms.Label();
            recvdteLabel = new System.Windows.Forms.Label();
            duedateLabel = new System.Windows.Forms.Label();
            booktypeLabel = new System.Windows.Forms.Label();
            totsigsLabel = new System.Windows.Forms.Label();
            partmemoLabel = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            specinstLabel = new System.Windows.Forms.Label();
            customdescLabel = new System.Windows.Forms.Label();
            txtcolorLabel = new System.Windows.Forms.Label();
            bkcolorLabel = new System.Windows.Forms.Label();
            mascotnameLabel = new System.Windows.Forms.Label();
            mascotslogLabel = new System.Windows.Forms.Label();
            endstrecvLabel1 = new System.Windows.Forms.Label();
            qtyLabel = new System.Windows.Forms.Label();
            numLabel = new System.Windows.Forms.Label();
            label37 = new System.Windows.Forms.Label();
            label39 = new System.Windows.Forms.Label();
            label34 = new System.Windows.Forms.Label();
            label35 = new System.Windows.Forms.Label();
            supnoLabel = new System.Windows.Forms.Label();
            this.tbEndSheets.SuspendLayout();
            this.pgEndSheets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endsheetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEndSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endsheetdetailDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endsheetdetailBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
            this.Supplement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppdetailDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppdetailBindingSource)).BeginInit();
            this.Banner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerdetailDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bannerdetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bannerBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preflitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // prodnoLabel
            // 
            prodnoLabel.AutoSize = true;
            prodnoLabel.Location = new System.Drawing.Point(13, 3);
            prodnoLabel.Name = "prodnoLabel";
            prodnoLabel.Size = new System.Drawing.Size(41, 13);
            prodnoLabel.TabIndex = 4;
            prodnoLabel.Text = "Prod#";
            // 
            // invnoLabel
            // 
            invnoLabel.AutoSize = true;
            invnoLabel.Location = new System.Drawing.Point(151, 3);
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
            prntsamLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            prntsamLabel.AutoSize = true;
            prntsamLabel.Location = new System.Drawing.Point(514, 338);
            prntsamLabel.Name = "prntsamLabel";
            prntsamLabel.Size = new System.Drawing.Size(98, 13);
            prntsamLabel.TabIndex = 83;
            prntsamLabel.Text = "Print Samp Sent";
            // 
            // reprntdteLabel
            // 
            reprntdteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            reprntdteLabel.AutoSize = true;
            reprntdteLabel.Location = new System.Drawing.Point(533, 363);
            reprntdteLabel.Name = "reprntdteLabel";
            reprntdteLabel.Size = new System.Drawing.Size(79, 13);
            reprntdteLabel.TabIndex = 84;
            reprntdteLabel.Text = "Reprint Date";
            // 
            // desorgdteLabel
            // 
            desorgdteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            desorgdteLabel.AutoSize = true;
            desorgdteLabel.Location = new System.Drawing.Point(486, 392);
            desorgdteLabel.Name = "desorgdteLabel";
            desorgdteLabel.Size = new System.Drawing.Size(126, 13);
            desorgdteLabel.TabIndex = 85;
            desorgdteLabel.Text = "Date Orig. Destroyed";
            // 
            // persondestLabel
            // 
            persondestLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            persondestLabel.AutoSize = true;
            persondestLabel.Location = new System.Drawing.Point(843, 384);
            persondestLabel.Name = "persondestLabel";
            persondestLabel.Size = new System.Drawing.Size(44, 13);
            persondestLabel.TabIndex = 89;
            persondestLabel.Text = "Initials";
            // 
            // reasonLabel
            // 
            reasonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            reasonLabel.AutoSize = true;
            reasonLabel.Location = new System.Drawing.Point(658, 419);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Size = new System.Drawing.Size(50, 13);
            reasonLabel.TabIndex = 90;
            reasonLabel.Text = "Reason";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(17, 13);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(41, 13);
            label16.TabIndex = 56;
            label16.Text = "Prod#";
            // 
            // nopagesLabel1
            // 
            nopagesLabel1.AutoSize = true;
            nopagesLabel1.Location = new System.Drawing.Point(12, 32);
            nopagesLabel1.Name = "nopagesLabel1";
            nopagesLabel1.Size = new System.Drawing.Size(127, 13);
            nopagesLabel1.TabIndex = 57;
            nopagesLabel1.Text = "# of Pages Received";
            // 
            // nocopiesLabel1
            // 
            nocopiesLabel1.AutoSize = true;
            nocopiesLabel1.Location = new System.Drawing.Point(279, 32);
            nocopiesLabel1.Name = "nocopiesLabel1";
            nocopiesLabel1.Size = new System.Drawing.Size(57, 13);
            nocopiesLabel1.TabIndex = 58;
            nocopiesLabel1.Text = "# Copies";
            // 
            // recvdteLabel
            // 
            recvdteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            recvdteLabel.AutoSize = true;
            recvdteLabel.Location = new System.Drawing.Point(476, 32);
            recvdteLabel.Name = "recvdteLabel";
            recvdteLabel.Size = new System.Drawing.Size(95, 13);
            recvdteLabel.TabIndex = 59;
            recvdteLabel.Text = "Recievied Date";
            // 
            // duedateLabel
            // 
            duedateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            duedateLabel.AutoSize = true;
            duedateLabel.Location = new System.Drawing.Point(731, 32);
            duedateLabel.Name = "duedateLabel";
            duedateLabel.Size = new System.Drawing.Size(61, 13);
            duedateLabel.TabIndex = 60;
            duedateLabel.Text = "Due Date";
            // 
            // booktypeLabel
            // 
            booktypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            booktypeLabel.AutoSize = true;
            booktypeLabel.Location = new System.Drawing.Point(611, 6);
            booktypeLabel.Name = "booktypeLabel";
            booktypeLabel.Size = new System.Drawing.Size(68, 13);
            booktypeLabel.TabIndex = 61;
            booktypeLabel.Text = "Book Type";
            // 
            // totsigsLabel
            // 
            totsigsLabel.AutoSize = true;
            totsigsLabel.Location = new System.Drawing.Point(487, 193);
            totsigsLabel.Name = "totsigsLabel";
            totsigsLabel.Size = new System.Drawing.Size(43, 13);
            totsigsLabel.TabIndex = 90;
            totsigsLabel.Text = "# Sigs";
            // 
            // partmemoLabel
            // 
            partmemoLabel.AutoSize = true;
            partmemoLabel.Location = new System.Drawing.Point(127, 226);
            partmemoLabel.Name = "partmemoLabel";
            partmemoLabel.Size = new System.Drawing.Size(40, 13);
            partmemoLabel.TabIndex = 91;
            partmemoLabel.Text = "Memo";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(150, 13);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(57, 13);
            label29.TabIndex = 95;
            label29.Text = "Invoice#";
            // 
            // specinstLabel
            // 
            specinstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            specinstLabel.AutoSize = true;
            specinstLabel.Location = new System.Drawing.Point(1527, 278);
            specinstLabel.Name = "specinstLabel";
            specinstLabel.Size = new System.Drawing.Size(119, 13);
            specinstLabel.TabIndex = 145;
            specinstLabel.Text = "Special Instructions";
            // 
            // customdescLabel
            // 
            customdescLabel.AutoSize = true;
            customdescLabel.Location = new System.Drawing.Point(88, 281);
            customdescLabel.Name = "customdescLabel";
            customdescLabel.Size = new System.Drawing.Size(71, 13);
            customdescLabel.TabIndex = 143;
            customdescLabel.Text = "Description";
            // 
            // txtcolorLabel
            // 
            txtcolorLabel.AutoSize = true;
            txtcolorLabel.Location = new System.Drawing.Point(94, 221);
            txtcolorLabel.Name = "txtcolorLabel";
            txtcolorLabel.Size = new System.Drawing.Size(65, 13);
            txtcolorLabel.TabIndex = 140;
            txtcolorLabel.Text = "Text Color";
            // 
            // bkcolorLabel
            // 
            bkcolorLabel.AutoSize = true;
            bkcolorLabel.Location = new System.Drawing.Point(51, 194);
            bkcolorLabel.Name = "bkcolorLabel";
            bkcolorLabel.Size = new System.Drawing.Size(108, 13);
            bkcolorLabel.TabIndex = 138;
            bkcolorLabel.Text = "Background Color";
            // 
            // mascotnameLabel
            // 
            mascotnameLabel.AutoSize = true;
            mascotnameLabel.Location = new System.Drawing.Point(111, 140);
            mascotnameLabel.Name = "mascotnameLabel";
            mascotnameLabel.Size = new System.Drawing.Size(48, 13);
            mascotnameLabel.TabIndex = 135;
            mascotnameLabel.Text = "Mascot";
            // 
            // mascotslogLabel
            // 
            mascotslogLabel.AutoSize = true;
            mascotslogLabel.Location = new System.Drawing.Point(77, 114);
            mascotslogLabel.Name = "mascotslogLabel";
            mascotslogLabel.Size = new System.Drawing.Size(82, 13);
            mascotslogLabel.TabIndex = 133;
            mascotslogLabel.Text = "Home Of The";
            // 
            // endstrecvLabel1
            // 
            endstrecvLabel1.AutoSize = true;
            endstrecvLabel1.Location = new System.Drawing.Point(407, 61);
            endstrecvLabel1.Name = "endstrecvLabel1";
            endstrecvLabel1.Size = new System.Drawing.Size(85, 13);
            endstrecvLabel1.TabIndex = 130;
            endstrecvLabel1.Text = "Recieve Date";
            // 
            // qtyLabel
            // 
            qtyLabel.AutoSize = true;
            qtyLabel.Location = new System.Drawing.Point(218, 61);
            qtyLabel.Name = "qtyLabel";
            qtyLabel.Size = new System.Drawing.Size(54, 13);
            qtyLabel.TabIndex = 128;
            qtyLabel.Text = "Qunatity";
            // 
            // numLabel
            // 
            numLabel.AutoSize = true;
            numLabel.Location = new System.Drawing.Point(26, 61);
            numLabel.Name = "numLabel";
            numLabel.Size = new System.Drawing.Size(59, 13);
            numLabel.TabIndex = 124;
            numLabel.Text = "Banner #";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new System.Drawing.Point(144, 14);
            label37.Name = "label37";
            label37.Size = new System.Drawing.Size(57, 13);
            label37.TabIndex = 122;
            label37.Text = "Invoice#";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new System.Drawing.Point(11, 14);
            label39.Name = "label39";
            label39.Size = new System.Drawing.Size(41, 13);
            label39.TabIndex = 120;
            label39.Text = "Prod#";
            // 
            // label34
            // 
            label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label34.AutoSize = true;
            label34.Location = new System.Drawing.Point(535, 278);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(119, 13);
            label34.TabIndex = 148;
            label34.Text = "Special Instructions";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new System.Drawing.Point(19, 58);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(64, 13);
            label35.TabIndex = 147;
            label35.Text = "Sheet No.";
            // 
            // supnoLabel
            // 
            supnoLabel.AutoSize = true;
            supnoLabel.Location = new System.Drawing.Point(55, 55);
            supnoLabel.Name = "supnoLabel";
            supnoLabel.Size = new System.Drawing.Size(81, 13);
            supnoLabel.TabIndex = 158;
            supnoLabel.Text = "Supplement#";
            // 
            // tbEndSheets
            // 
            this.tbEndSheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEndSheets.Controls.Add(this.pgEndSheets);
            this.tbEndSheets.Controls.Add(this.Supplement);
            this.tbEndSheets.Controls.Add(this.Banner);
            this.tbEndSheets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEndSheets.Location = new System.Drawing.Point(0, 0);
            this.tbEndSheets.Name = "tbEndSheets";
            this.tbEndSheets.SelectedIndex = 0;
            this.tbEndSheets.Size = new System.Drawing.Size(1113, 740);
            this.tbEndSheets.TabIndex = 0;
            this.tbEndSheets.Visible = false;
            this.tbEndSheets.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbEndSheets_Deselecting);
            // 
            // pgEndSheets
            // 
            this.pgEndSheets.BackColor = System.Drawing.SystemColors.Control;
            this.pgEndSheets.Controls.Add(this.btnNewEndSheetScanRec);
            this.pgEndSheets.Controls.Add(this.reportViewer1);
            this.pgEndSheets.Controls.Add(this.btnUpdateDates);
            this.pgEndSheets.Controls.Add(this.btnAddEndSheetRecord);
            this.pgEndSheets.Controls.Add(this.btnEndSheetTicket);
            this.pgEndSheets.Controls.Add(this.desorgdteDateBox);
            this.pgEndSheets.Controls.Add(this.reprntdteDateBox);
            this.pgEndSheets.Controls.Add(this.prntsamDateBox);
            this.pgEndSheets.Controls.Add(this.otdtebkDateBox);
            this.pgEndSheets.Controls.Add(this.dcdtebkDateBox);
            this.pgEndSheets.Controls.Add(this.lamdtebkDateBox);
            this.pgEndSheets.Controls.Add(this.prtdtebkDateBox);
            this.pgEndSheets.Controls.Add(this.otdtesentDateBox);
            this.pgEndSheets.Controls.Add(this.dcdtesentDateBox);
            this.pgEndSheets.Controls.Add(this.lamdtesentDateBox);
            this.pgEndSheets.Controls.Add(this.prtdtesentDateBox);
            this.pgEndSheets.Controls.Add(this.endstrecvDateBox);
            this.pgEndSheets.Controls.Add(this.csoffholdDateBox);
            this.pgEndSheets.Controls.Add(this.csonholdDateBox);
            this.pgEndSheets.Controls.Add(label35);
            this.pgEndSheets.Controls.Add(this.laminatedTextBox);
            this.pgEndSheets.Controls.Add(this.endsheetdetailDataGridView);
            this.pgEndSheets.Controls.Add(reasonLabel);
            this.pgEndSheets.Controls.Add(this.reasonTextBox);
            this.pgEndSheets.Controls.Add(persondestLabel);
            this.pgEndSheets.Controls.Add(this.persondestTextBox);
            this.pgEndSheets.Controls.Add(this.reprnacpCheckBox);
            this.pgEndSheets.Controls.Add(this.acceptdCheckBox);
            this.pgEndSheets.Controls.Add(this.remakeCheckBox);
            this.pgEndSheets.Controls.Add(desorgdteLabel);
            this.pgEndSheets.Controls.Add(reprntdteLabel);
            this.pgEndSheets.Controls.Add(prntsamLabel);
            this.pgEndSheets.Controls.Add(this.othrvendTextBox);
            this.pgEndSheets.Controls.Add(this.dcvendTextBox);
            this.pgEndSheets.Controls.Add(this.lamvendTextBox);
            this.pgEndSheets.Controls.Add(this.prtvendTextBox);
            this.pgEndSheets.Controls.Add(this.diecutCheckBox);
            this.pgEndSheets.Controls.Add(this.othrCheckBox);
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
            this.pgEndSheets.Controls.Add(this.endshtnoTextBox);
            this.pgEndSheets.Controls.Add(csoffholdLabel);
            this.pgEndSheets.Controls.Add(csonholdLabel);
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
            this.pgEndSheets.Controls.Add(this.txtSchname);
            this.pgEndSheets.Location = new System.Drawing.Point(4, 22);
            this.pgEndSheets.Name = "pgEndSheets";
            this.pgEndSheets.Padding = new System.Windows.Forms.Padding(3);
            this.pgEndSheets.Size = new System.Drawing.Size(1105, 714);
            this.pgEndSheets.TabIndex = 0;
            this.pgEndSheets.Text = "End Sheet";
            // 
            // btnNewEndSheetScanRec
            // 
            this.btnNewEndSheetScanRec.Location = new System.Drawing.Point(32, 431);
            this.btnNewEndSheetScanRec.Name = "btnNewEndSheetScanRec";
            this.btnNewEndSheetScanRec.Size = new System.Drawing.Size(123, 23);
            this.btnNewEndSheetScanRec.TabIndex = 226;
            this.btnNewEndSheetScanRec.Text = "New Scan Record";
            this.btnNewEndSheetScanRec.UseVisualStyleBackColor = true;
            this.btnNewEndSheetScanRec.Click += new System.EventHandler(this.btnNewEndSheetScanRec_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 51;
            this.reportViewer1.Location = new System.Drawing.Point(953, 263);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(53, 57);
            this.reportViewer1.TabIndex = 160;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // btnUpdateDates
            // 
            this.btnUpdateDates.Location = new System.Drawing.Point(977, 78);
            this.btnUpdateDates.Name = "btnUpdateDates";
            this.btnUpdateDates.Size = new System.Drawing.Size(101, 23);
            this.btnUpdateDates.TabIndex = 154;
            this.btnUpdateDates.Text = "Update Dates";
            this.btnUpdateDates.UseVisualStyleBackColor = true;
            this.btnUpdateDates.Visible = false;
            this.btnUpdateDates.Click += new System.EventHandler(this.btnUpdateDates_Click);
            // 
            // btnAddEndSheetRecord
            // 
            this.btnAddEndSheetRecord.Location = new System.Drawing.Point(977, 21);
            this.btnAddEndSheetRecord.Name = "btnAddEndSheetRecord";
            this.btnAddEndSheetRecord.Size = new System.Drawing.Size(101, 23);
            this.btnAddEndSheetRecord.TabIndex = 153;
            this.btnAddEndSheetRecord.Text = "Add EndSheet";
            this.btnAddEndSheetRecord.UseVisualStyleBackColor = true;
            this.btnAddEndSheetRecord.Click += new System.EventHandler(this.btnAddEndSheetRecord_Click);
            // 
            // btnEndSheetTicket
            // 
            this.btnEndSheetTicket.Location = new System.Drawing.Point(977, 50);
            this.btnEndSheetTicket.Name = "btnEndSheetTicket";
            this.btnEndSheetTicket.Size = new System.Drawing.Size(101, 23);
            this.btnEndSheetTicket.TabIndex = 152;
            this.btnEndSheetTicket.Text = "Print Ticket";
            this.btnEndSheetTicket.UseVisualStyleBackColor = true;
            this.btnEndSheetTicket.Click += new System.EventHandler(this.btnEndSheetTicket_Click);
            // 
            // desorgdteDateBox
            // 
            this.desorgdteDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.desorgdteDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "desorgdte", true));
            this.desorgdteDateBox.Date = null;
            this.desorgdteDateBox.DateValue = null;
            this.desorgdteDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desorgdteDateBox.Location = new System.Drawing.Point(618, 389);
            this.desorgdteDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.desorgdteDateBox.Name = "desorgdteDateBox";
            this.desorgdteDateBox.Size = new System.Drawing.Size(133, 21);
            this.desorgdteDateBox.TabIndex = 53;
            // 
            // endsheetBindingSource
            // 
            this.endsheetBindingSource.DataMember = "endsheet";
            this.endsheetBindingSource.DataSource = this.dsEndSheet;
            // 
            // dsEndSheet
            // 
            this.dsEndSheet.DataSetName = "dsEndSheet";
            this.dsEndSheet.EnforceConstraints = false;
            this.dsEndSheet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reprntdteDateBox
            // 
            this.reprntdteDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reprntdteDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "reprntdte", true));
            this.reprntdteDateBox.Date = null;
            this.reprntdteDateBox.DateValue = null;
            this.reprntdteDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reprntdteDateBox.Location = new System.Drawing.Point(618, 363);
            this.reprntdteDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.reprntdteDateBox.Name = "reprntdteDateBox";
            this.reprntdteDateBox.Size = new System.Drawing.Size(133, 21);
            this.reprntdteDateBox.TabIndex = 151;
            // 
            // prntsamDateBox
            // 
            this.prntsamDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prntsamDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "prntsam", true));
            this.prntsamDateBox.Date = null;
            this.prntsamDateBox.DateValue = null;
            this.prntsamDateBox.Location = new System.Drawing.Point(618, 338);
            this.prntsamDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.prntsamDateBox.Name = "prntsamDateBox";
            this.prntsamDateBox.Size = new System.Drawing.Size(133, 21);
            this.prntsamDateBox.TabIndex = 150;
            // 
            // otdtebkDateBox
            // 
            this.otdtebkDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "otdtebk", true));
            this.otdtebkDateBox.Date = null;
            this.otdtebkDateBox.DateValue = null;
            this.otdtebkDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otdtebkDateBox.Location = new System.Drawing.Point(290, 409);
            this.otdtebkDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.otdtebkDateBox.Name = "otdtebkDateBox";
            this.otdtebkDateBox.Size = new System.Drawing.Size(133, 21);
            this.otdtebkDateBox.TabIndex = 149;
            // 
            // dcdtebkDateBox
            // 
            this.dcdtebkDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "dcdtebk", true));
            this.dcdtebkDateBox.Date = null;
            this.dcdtebkDateBox.DateValue = null;
            this.dcdtebkDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dcdtebkDateBox.Location = new System.Drawing.Point(290, 384);
            this.dcdtebkDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.dcdtebkDateBox.Name = "dcdtebkDateBox";
            this.dcdtebkDateBox.Size = new System.Drawing.Size(133, 21);
            this.dcdtebkDateBox.TabIndex = 53;
            // 
            // lamdtebkDateBox
            // 
            this.lamdtebkDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "lamdtebk", true));
            this.lamdtebkDateBox.Date = null;
            this.lamdtebkDateBox.DateValue = null;
            this.lamdtebkDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lamdtebkDateBox.Location = new System.Drawing.Point(290, 361);
            this.lamdtebkDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.lamdtebkDateBox.Name = "lamdtebkDateBox";
            this.lamdtebkDateBox.Size = new System.Drawing.Size(133, 21);
            this.lamdtebkDateBox.TabIndex = 53;
            // 
            // prtdtebkDateBox
            // 
            this.prtdtebkDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "prtdtebk", true));
            this.prtdtebkDateBox.Date = null;
            this.prtdtebkDateBox.DateValue = null;
            this.prtdtebkDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prtdtebkDateBox.Location = new System.Drawing.Point(290, 338);
            this.prtdtebkDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.prtdtebkDateBox.Name = "prtdtebkDateBox";
            this.prtdtebkDateBox.Size = new System.Drawing.Size(133, 21);
            this.prtdtebkDateBox.TabIndex = 53;
            // 
            // otdtesentDateBox
            // 
            this.otdtesentDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "otdtesent", true));
            this.otdtesentDateBox.Date = null;
            this.otdtesentDateBox.DateValue = null;
            this.otdtesentDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otdtesentDateBox.Location = new System.Drawing.Point(136, 409);
            this.otdtesentDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.otdtesentDateBox.Name = "otdtesentDateBox";
            this.otdtesentDateBox.Size = new System.Drawing.Size(133, 21);
            this.otdtesentDateBox.TabIndex = 148;
            // 
            // dcdtesentDateBox
            // 
            this.dcdtesentDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "dcdtesent", true));
            this.dcdtesentDateBox.Date = null;
            this.dcdtesentDateBox.DateValue = null;
            this.dcdtesentDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dcdtesentDateBox.Location = new System.Drawing.Point(136, 384);
            this.dcdtesentDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.dcdtesentDateBox.Name = "dcdtesentDateBox";
            this.dcdtesentDateBox.Size = new System.Drawing.Size(133, 21);
            this.dcdtesentDateBox.TabIndex = 53;
            // 
            // lamdtesentDateBox
            // 
            this.lamdtesentDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "lamdtesent", true));
            this.lamdtesentDateBox.Date = null;
            this.lamdtesentDateBox.DateValue = null;
            this.lamdtesentDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lamdtesentDateBox.Location = new System.Drawing.Point(136, 361);
            this.lamdtesentDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.lamdtesentDateBox.Name = "lamdtesentDateBox";
            this.lamdtesentDateBox.Size = new System.Drawing.Size(133, 21);
            this.lamdtesentDateBox.TabIndex = 53;
            // 
            // prtdtesentDateBox
            // 
            this.prtdtesentDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "prtdtesent", true));
            this.prtdtesentDateBox.Date = null;
            this.prtdtesentDateBox.DateValue = null;
            this.prtdtesentDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prtdtesentDateBox.Location = new System.Drawing.Point(136, 338);
            this.prtdtesentDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.prtdtesentDateBox.Name = "prtdtesentDateBox";
            this.prtdtesentDateBox.Size = new System.Drawing.Size(133, 21);
            this.prtdtesentDateBox.TabIndex = 53;
            // 
            // endstrecvDateBox
            // 
            this.endstrecvDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "endstrecv", true));
            this.endstrecvDateBox.Date = null;
            this.endstrecvDateBox.DateValue = null;
            this.endstrecvDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endstrecvDateBox.Location = new System.Drawing.Point(721, 82);
            this.endstrecvDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.endstrecvDateBox.Name = "endstrecvDateBox";
            this.endstrecvDateBox.Size = new System.Drawing.Size(133, 21);
            this.endstrecvDateBox.TabIndex = 53;
            // 
            // csoffholdDateBox
            // 
            this.csoffholdDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "csoffhold", true));
            this.csoffholdDateBox.Date = null;
            this.csoffholdDateBox.DateValue = null;
            this.csoffholdDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csoffholdDateBox.Location = new System.Drawing.Point(719, 55);
            this.csoffholdDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.csoffholdDateBox.Name = "csoffholdDateBox";
            this.csoffholdDateBox.Size = new System.Drawing.Size(133, 21);
            this.csoffholdDateBox.TabIndex = 53;
            // 
            // csonholdDateBox
            // 
            this.csonholdDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.endsheetBindingSource, "csonhold", true));
            this.csonholdDateBox.Date = null;
            this.csonholdDateBox.DateValue = null;
            this.csonholdDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csonholdDateBox.Location = new System.Drawing.Point(719, 30);
            this.csonholdDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.csonholdDateBox.Name = "csonholdDateBox";
            this.csonholdDateBox.Size = new System.Drawing.Size(133, 21);
            this.csonholdDateBox.TabIndex = 53;
            // 
            // laminatedTextBox
            // 
            this.laminatedTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.laminatedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "laminated", true));
            this.laminatedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laminatedTextBox.Location = new System.Drawing.Point(60, 361);
            this.laminatedTextBox.MaxLength = 1;
            this.laminatedTextBox.Name = "laminatedTextBox";
            this.laminatedTextBox.Size = new System.Drawing.Size(22, 20);
            this.laminatedTextBox.TabIndex = 146;
            // 
            // produtnBindingSource
            // 
            this.produtnBindingSource.DataMember = "produtn";
            this.produtnBindingSource.DataSource = this.dsEndSheet;
            // 
            // endsheetdetailDataGridView
            // 
            this.endsheetdetailDataGridView.AllowUserToAddRows = false;
            this.endsheetdetailDataGridView.AllowUserToDeleteRows = false;
            this.endsheetdetailDataGridView.AllowUserToOrderColumns = true;
            this.endsheetdetailDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endsheetdetailDataGridView.AutoGenerateColumns = false;
            this.endsheetdetailDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.endsheetdetailDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
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
            this.endsheetdetailDataGridView.Location = new System.Drawing.Point(22, 460);
            this.endsheetdetailDataGridView.Name = "endsheetdetailDataGridView";
            this.endsheetdetailDataGridView.RowHeadersVisible = false;
            this.endsheetdetailDataGridView.Size = new System.Drawing.Size(1042, 233);
            this.endsheetdetailDataGridView.TabIndex = 91;
            this.endsheetdetailDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.endsheetdetailDataGridView_CellDoubleClick);
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
            this.dataGridViewTextBoxColumn3.Visible = false;
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
            // reasonTextBox
            // 
            this.reasonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reasonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "reason", true));
            this.reasonTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reasonTextBox.Location = new System.Drawing.Point(713, 416);
            this.reasonTextBox.Multiline = true;
            this.reasonTextBox.Name = "reasonTextBox";
            this.reasonTextBox.Size = new System.Drawing.Size(229, 38);
            this.reasonTextBox.TabIndex = 91;
            // 
            // persondestTextBox
            // 
            this.persondestTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.persondestTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "persondest", true));
            this.persondestTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.persondestTextBox.Location = new System.Drawing.Point(893, 384);
            this.persondestTextBox.Name = "persondestTextBox";
            this.persondestTextBox.Size = new System.Drawing.Size(49, 20);
            this.persondestTextBox.TabIndex = 90;
            // 
            // reprnacpCheckBox
            // 
            this.reprnacpCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reprnacpCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.endsheetBindingSource, "reprnacp", true));
            this.reprnacpCheckBox.Location = new System.Drawing.Point(836, 360);
            this.reprnacpCheckBox.Name = "reprnacpCheckBox";
            this.reprnacpCheckBox.Size = new System.Drawing.Size(126, 24);
            this.reprnacpCheckBox.TabIndex = 89;
            this.reprnacpCheckBox.Text = "RePrnt Accpeted";
            this.reprnacpCheckBox.UseVisualStyleBackColor = true;
            // 
            // acceptdCheckBox
            // 
            this.acceptdCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptdCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.endsheetBindingSource, "acceptd", true));
            this.acceptdCheckBox.Location = new System.Drawing.Point(836, 339);
            this.acceptdCheckBox.Name = "acceptdCheckBox";
            this.acceptdCheckBox.Size = new System.Drawing.Size(104, 24);
            this.acceptdCheckBox.TabIndex = 88;
            this.acceptdCheckBox.Text = "Accepted";
            this.acceptdCheckBox.UseVisualStyleBackColor = true;
            // 
            // remakeCheckBox
            // 
            this.remakeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remakeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.endsheetBindingSource, "remake", true));
            this.remakeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remakeCheckBox.Location = new System.Drawing.Point(500, 409);
            this.remakeCheckBox.Name = "remakeCheckBox";
            this.remakeCheckBox.Size = new System.Drawing.Size(104, 24);
            this.remakeCheckBox.TabIndex = 87;
            this.remakeCheckBox.Text = "Remake";
            this.remakeCheckBox.UseVisualStyleBackColor = true;
            // 
            // othrvendTextBox
            // 
            this.othrvendTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "othrvend", true));
            this.othrvendTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.othrvendTextBox.Location = new System.Drawing.Point(88, 408);
            this.othrvendTextBox.Name = "othrvendTextBox";
            this.othrvendTextBox.Size = new System.Drawing.Size(37, 20);
            this.othrvendTextBox.TabIndex = 74;
            // 
            // dcvendTextBox
            // 
            this.dcvendTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "dcvend", true));
            this.dcvendTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dcvendTextBox.Location = new System.Drawing.Point(88, 384);
            this.dcvendTextBox.Name = "dcvendTextBox";
            this.dcvendTextBox.Size = new System.Drawing.Size(37, 20);
            this.dcvendTextBox.TabIndex = 73;
            // 
            // lamvendTextBox
            // 
            this.lamvendTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "lamvend", true));
            this.lamvendTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lamvendTextBox.Location = new System.Drawing.Point(88, 361);
            this.lamvendTextBox.Name = "lamvendTextBox";
            this.lamvendTextBox.Size = new System.Drawing.Size(37, 20);
            this.lamvendTextBox.TabIndex = 72;
            // 
            // prtvendTextBox
            // 
            this.prtvendTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "prtvend", true));
            this.prtvendTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prtvendTextBox.Location = new System.Drawing.Point(88, 338);
            this.prtvendTextBox.Name = "prtvendTextBox";
            this.prtvendTextBox.Size = new System.Drawing.Size(37, 20);
            this.prtvendTextBox.TabIndex = 71;
            // 
            // diecutCheckBox
            // 
            this.diecutCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.produtnBindingSource, "diecut", true));
            this.diecutCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diecutCheckBox.Location = new System.Drawing.Point(63, 384);
            this.diecutCheckBox.Name = "diecutCheckBox";
            this.diecutCheckBox.Size = new System.Drawing.Size(17, 15);
            this.diecutCheckBox.TabIndex = 70;
            this.diecutCheckBox.UseVisualStyleBackColor = true;
            // 
            // othrCheckBox
            // 
            this.othrCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.endsheetBindingSource, "othr", true));
            this.othrCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.othrCheckBox.Location = new System.Drawing.Point(63, 408);
            this.othrCheckBox.Name = "othrCheckBox";
            this.othrCheckBox.Size = new System.Drawing.Size(17, 13);
            this.othrCheckBox.TabIndex = 69;
            this.othrCheckBox.UseVisualStyleBackColor = true;
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
            this.label12.Location = new System.Drawing.Point(289, 319);
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
            this.frcopiesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frcopiesTextBox.Location = new System.Drawing.Point(124, 37);
            this.frcopiesTextBox.Name = "frcopiesTextBox";
            this.frcopiesTextBox.Size = new System.Drawing.Size(64, 20);
            this.frcopiesTextBox.TabIndex = 45;
            this.frcopiesTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.frcopiesTextBox_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Front End Sheet";
            // 
            // frdescTextBox
            // 
            this.frdescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "frdesc", true));
            this.frdescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frdescTextBox.Location = new System.Drawing.Point(124, 86);
            this.frdescTextBox.Name = "frdescTextBox";
            this.frdescTextBox.Size = new System.Drawing.Size(307, 20);
            this.frdescTextBox.TabIndex = 42;
            // 
            // fldescTextBox
            // 
            this.fldescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "fldesc", true));
            this.fldescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.groupBox1.Size = new System.Drawing.Size(614, 142);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "Back End Sheet";
            // 
            // bkcopiesTextBox
            // 
            this.bkcopiesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "bkcopies", true));
            this.bkcopiesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bkcopiesTextBox.Location = new System.Drawing.Point(121, 43);
            this.bkcopiesTextBox.Name = "bkcopiesTextBox";
            this.bkcopiesTextBox.Size = new System.Drawing.Size(64, 20);
            this.bkcopiesTextBox.TabIndex = 46;
            this.bkcopiesTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.bkcopiesTextBox_Validating);
            // 
            // bldescTextBox
            // 
            this.bldescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "bldesc", true));
            this.bldescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bldescTextBox.Location = new System.Drawing.Point(123, 69);
            this.bldescTextBox.Name = "bldescTextBox";
            this.bldescTextBox.Size = new System.Drawing.Size(307, 20);
            this.bldescTextBox.TabIndex = 48;
            // 
            // brdescTextBox
            // 
            this.brdescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "brdesc", true));
            this.brdescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brdescTextBox.Location = new System.Drawing.Point(123, 92);
            this.brdescTextBox.Name = "brdescTextBox";
            this.brdescTextBox.Size = new System.Drawing.Size(307, 20);
            this.brdescTextBox.TabIndex = 50;
            // 
            // invnoLabel2
            // 
            this.invnoLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "invno", true));
            this.invnoLabel2.Location = new System.Drawing.Point(214, 3);
            this.invnoLabel2.Name = "invnoLabel2";
            this.invnoLabel2.Size = new System.Drawing.Size(100, 23);
            this.invnoLabel2.TabIndex = 56;
            this.invnoLabel2.Text = "label7";
            // 
            // prodnoLabel2
            // 
            this.prodnoLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "prodno", true));
            this.prodnoLabel2.Location = new System.Drawing.Point(60, 3);
            this.prodnoLabel2.Name = "prodnoLabel2";
            this.prodnoLabel2.Size = new System.Drawing.Size(84, 23);
            this.prodnoLabel2.TabIndex = 55;
            this.prodnoLabel2.Text = "label7";
            // 
            // specinstTextBox
            // 
            this.specinstTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "specinst", true));
            this.specinstTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specinstTextBox.Location = new System.Drawing.Point(132, 263);
            this.specinstTextBox.Multiline = true;
            this.specinstTextBox.Name = "specinstTextBox";
            this.specinstTextBox.Size = new System.Drawing.Size(786, 41);
            this.specinstTextBox.TabIndex = 54;
            // 
            // nopagesTextBox
            // 
            this.nopagesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "nopages", true));
            this.nopagesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nopagesTextBox.Location = new System.Drawing.Point(386, 56);
            this.nopagesTextBox.Name = "nopagesTextBox";
            this.nopagesTextBox.Size = new System.Drawing.Size(47, 20);
            this.nopagesTextBox.TabIndex = 36;
            this.nopagesTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nopagesTextBox_Validating);
            // 
            // prntsmpCheckBox
            // 
            this.prntsmpCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.endsheetBindingSource, "prntsmp", true));
            this.prntsmpCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.reqstdcpyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reqstdcpyTextBox.Location = new System.Drawing.Point(258, 56);
            this.reqstdcpyTextBox.Name = "reqstdcpyTextBox";
            this.reqstdcpyTextBox.Size = new System.Drawing.Size(53, 20);
            this.reqstdcpyTextBox.TabIndex = 33;
            this.reqstdcpyTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.reqstdcpyTextBox_Validating);
            // 
            // endshtnoTextBox
            // 
            this.endshtnoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "endshtno", true));
            this.endshtnoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endshtnoTextBox.Location = new System.Drawing.Point(86, 56);
            this.endshtnoTextBox.Name = "endshtnoTextBox";
            this.endshtnoTextBox.Size = new System.Drawing.Size(67, 20);
            this.endshtnoTextBox.TabIndex = 29;
            // 
            // spotclrTextBox
            // 
            this.spotclrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "spotclr", true));
            this.spotclrTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spotclrTextBox.Location = new System.Drawing.Point(579, 31);
            this.spotclrTextBox.Name = "spotclrTextBox";
            this.spotclrTextBox.Size = new System.Drawing.Size(49, 20);
            this.spotclrTextBox.TabIndex = 23;
            // 
            // perfbindTextBox
            // 
            this.perfbindTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "perfbind", true));
            this.perfbindTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perfbindTextBox.Location = new System.Drawing.Point(467, 31);
            this.perfbindTextBox.Name = "perfbindTextBox";
            this.perfbindTextBox.Size = new System.Drawing.Size(32, 20);
            this.perfbindTextBox.TabIndex = 21;
            // 
            // clr6TextBox
            // 
            this.clr6TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr6", true));
            this.clr6TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clr6TextBox.Location = new System.Drawing.Point(384, 31);
            this.clr6TextBox.MaxLength = 15;
            this.clr6TextBox.Name = "clr6TextBox";
            this.clr6TextBox.Size = new System.Drawing.Size(45, 20);
            this.clr6TextBox.TabIndex = 19;
            // 
            // clr5TextBox
            // 
            this.clr5TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr5", true));
            this.clr5TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clr5TextBox.Location = new System.Drawing.Point(317, 31);
            this.clr5TextBox.MaxLength = 15;
            this.clr5TextBox.Name = "clr5TextBox";
            this.clr5TextBox.Size = new System.Drawing.Size(45, 20);
            this.clr5TextBox.TabIndex = 17;
            // 
            // clr4TextBox
            // 
            this.clr4TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr4", true));
            this.clr4TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clr4TextBox.Location = new System.Drawing.Point(249, 31);
            this.clr4TextBox.MaxLength = 15;
            this.clr4TextBox.Name = "clr4TextBox";
            this.clr4TextBox.Size = new System.Drawing.Size(45, 20);
            this.clr4TextBox.TabIndex = 15;
            // 
            // clr3TextBox
            // 
            this.clr3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr3", true));
            this.clr3TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clr3TextBox.Location = new System.Drawing.Point(180, 31);
            this.clr3TextBox.MaxLength = 15;
            this.clr3TextBox.Name = "clr3TextBox";
            this.clr3TextBox.Size = new System.Drawing.Size(45, 20);
            this.clr3TextBox.TabIndex = 13;
            // 
            // clr2TextBox
            // 
            this.clr2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr2", true));
            this.clr2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clr2TextBox.Location = new System.Drawing.Point(108, 31);
            this.clr2TextBox.MaxLength = 15;
            this.clr2TextBox.Name = "clr2TextBox";
            this.clr2TextBox.Size = new System.Drawing.Size(45, 20);
            this.clr2TextBox.TabIndex = 11;
            // 
            // clr1TextBox
            // 
            this.clr1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr1", true));
            this.clr1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clr1TextBox.Location = new System.Drawing.Point(33, 31);
            this.clr1TextBox.MaxLength = 15;
            this.clr1TextBox.Name = "clr1TextBox";
            this.clr1TextBox.Size = new System.Drawing.Size(45, 20);
            this.clr1TextBox.TabIndex = 9;
            // 
            // txtSchname
            // 
            this.txtSchname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schname", true));
            this.txtSchname.Location = new System.Drawing.Point(1197, 711);
            this.txtSchname.Name = "txtSchname";
            this.txtSchname.ReadOnly = true;
            this.txtSchname.Size = new System.Drawing.Size(1, 20);
            this.txtSchname.TabIndex = 1;
            // 
            // custBindingSource
            // 
            this.custBindingSource.DataMember = "cust";
            this.custBindingSource.DataSource = this.dsEndSheet;
            // 
            // Supplement
            // 
            this.Supplement.AutoScroll = true;
            this.Supplement.BackColor = System.Drawing.SystemColors.Control;
            this.Supplement.Controls.Add(this.btnAddSupplScan);
            this.Supplement.Controls.Add(supnoLabel);
            this.Supplement.Controls.Add(this.supnoLabel1);
            this.Supplement.Controls.Add(this.nocopiesTextBox1);
            this.Supplement.Controls.Add(this.btnUpdateSuppDates);
            this.Supplement.Controls.Add(this.btnAddSupp);
            this.Supplement.Controls.Add(this.btnPrintSuppTicket);
            this.Supplement.Controls.Add(this.duedateDateBox);
            this.Supplement.Controls.Add(this.recvdteDateBox);
            this.Supplement.Controls.Add(this.rmbfrmDateBox);
            this.Supplement.Controls.Add(this.rmbtoDateBox);
            this.Supplement.Controls.Add(this.frmbindDateBox);
            this.Supplement.Controls.Add(this.binddteDateBox);
            this.Supplement.Controls.Add(this.ioutDateBox);
            this.Supplement.Controls.Add(this.iinDateBox);
            this.Supplement.Controls.Add(this.label28);
            this.Supplement.Controls.Add(label29);
            this.Supplement.Controls.Add(this.suppdetailDataGridView);
            this.Supplement.Controls.Add(partmemoLabel);
            this.Supplement.Controls.Add(this.partmemoTextBox);
            this.Supplement.Controls.Add(totsigsLabel);
            this.Supplement.Controls.Add(this.totsigsTextBox);
            this.Supplement.Controls.Add(this.supplementsCheckBox);
            this.Supplement.Controls.Add(this.oursuppCheckBox);
            this.Supplement.Controls.Add(this.rmbtotTextBox);
            this.Supplement.Controls.Add(this.remaketypeComboBox);
            this.Supplement.Controls.Add(this.label27);
            this.Supplement.Controls.Add(this.label26);
            this.Supplement.Controls.Add(this.label25);
            this.Supplement.Controls.Add(this.label24);
            this.Supplement.Controls.Add(this.tape_1CheckBox);
            this.Supplement.Controls.Add(this.vendcdTextBox);
            this.Supplement.Controls.Add(this.label23);
            this.Supplement.Controls.Add(this.iinitTextBox);
            this.Supplement.Controls.Add(this.ideptTextBox);
            this.Supplement.Controls.Add(this.label22);
            this.Supplement.Controls.Add(this.label21);
            this.Supplement.Controls.Add(this.label20);
            this.Supplement.Controls.Add(this.label19);
            this.Supplement.Controls.Add(this.label18);
            this.Supplement.Controls.Add(this.label17);
            this.Supplement.Controls.Add(booktypeLabel);
            this.Supplement.Controls.Add(this.booktypeLabel1);
            this.Supplement.Controls.Add(duedateLabel);
            this.Supplement.Controls.Add(recvdteLabel);
            this.Supplement.Controls.Add(nocopiesLabel1);
            this.Supplement.Controls.Add(this.nocopiesTextBox);
            this.Supplement.Controls.Add(nopagesLabel1);
            this.Supplement.Controls.Add(this.nopagesTextBox1);
            this.Supplement.Controls.Add(this.label15);
            this.Supplement.Controls.Add(label16);
            this.Supplement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Supplement.Location = new System.Drawing.Point(4, 22);
            this.Supplement.Name = "Supplement";
            this.Supplement.Padding = new System.Windows.Forms.Padding(3);
            this.Supplement.Size = new System.Drawing.Size(1105, 714);
            this.Supplement.TabIndex = 1;
            this.Supplement.Text = "Supplement";
            // 
            // btnAddSupplScan
            // 
            this.btnAddSupplScan.Location = new System.Drawing.Point(67, 293);
            this.btnAddSupplScan.Name = "btnAddSupplScan";
            this.btnAddSupplScan.Size = new System.Drawing.Size(123, 23);
            this.btnAddSupplScan.TabIndex = 227;
            this.btnAddSupplScan.Text = "New Scan Record";
            this.btnAddSupplScan.UseVisualStyleBackColor = true;
            this.btnAddSupplScan.Click += new System.EventHandler(this.btnAddSupplScan_Click);
            // 
            // supnoLabel1
            // 
            this.supnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplBindingSource, "supno", true));
            this.supnoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supnoLabel1.Location = new System.Drawing.Point(142, 55);
            this.supnoLabel1.Name = "supnoLabel1";
            this.supnoLabel1.Size = new System.Drawing.Size(100, 23);
            this.supnoLabel1.TabIndex = 159;
            this.supnoLabel1.Text = "label30";
            // 
            // supplBindingSource
            // 
            this.supplBindingSource.DataMember = "suppl";
            this.supplBindingSource.DataSource = this.dsEndSheet;
            // 
            // nocopiesTextBox1
            // 
            this.nocopiesTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplBindingSource, "nocopies", true));
            this.nocopiesTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nocopiesTextBox1.Location = new System.Drawing.Point(342, 32);
            this.nocopiesTextBox1.Name = "nocopiesTextBox1";
            this.nocopiesTextBox1.Size = new System.Drawing.Size(100, 20);
            this.nocopiesTextBox1.TabIndex = 158;
            this.nocopiesTextBox1.Validating += new System.ComponentModel.CancelEventHandler(this.nocopiesTextBox1_Validating);
            // 
            // btnUpdateSuppDates
            // 
            this.btnUpdateSuppDates.Location = new System.Drawing.Point(988, 88);
            this.btnUpdateSuppDates.Name = "btnUpdateSuppDates";
            this.btnUpdateSuppDates.Size = new System.Drawing.Size(107, 23);
            this.btnUpdateSuppDates.TabIndex = 157;
            this.btnUpdateSuppDates.Text = "Update Dates";
            this.btnUpdateSuppDates.UseVisualStyleBackColor = true;
            this.btnUpdateSuppDates.Visible = false;
            this.btnUpdateSuppDates.Click += new System.EventHandler(this.btnUpdateSuppDates_Click);
            // 
            // btnAddSupp
            // 
            this.btnAddSupp.Location = new System.Drawing.Point(988, 31);
            this.btnAddSupp.Name = "btnAddSupp";
            this.btnAddSupp.Size = new System.Drawing.Size(107, 23);
            this.btnAddSupp.TabIndex = 156;
            this.btnAddSupp.Text = "Add Supplement";
            this.btnAddSupp.UseVisualStyleBackColor = true;
            this.btnAddSupp.Click += new System.EventHandler(this.btnAddSupp_Click);
            // 
            // btnPrintSuppTicket
            // 
            this.btnPrintSuppTicket.Location = new System.Drawing.Point(988, 60);
            this.btnPrintSuppTicket.Name = "btnPrintSuppTicket";
            this.btnPrintSuppTicket.Size = new System.Drawing.Size(107, 23);
            this.btnPrintSuppTicket.TabIndex = 155;
            this.btnPrintSuppTicket.Text = "Print Ticket";
            this.btnPrintSuppTicket.UseVisualStyleBackColor = true;
            this.btnPrintSuppTicket.Click += new System.EventHandler(this.btnPrintSuppTicket_Click);
            // 
            // duedateDateBox
            // 
            this.duedateDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.duedateDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.supplBindingSource, "duedate", true));
            this.duedateDateBox.Date = null;
            this.duedateDateBox.DateValue = null;
            this.duedateDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duedateDateBox.Location = new System.Drawing.Point(798, 32);
            this.duedateDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.duedateDateBox.Name = "duedateDateBox";
            this.duedateDateBox.Size = new System.Drawing.Size(133, 21);
            this.duedateDateBox.TabIndex = 108;
            // 
            // recvdteDateBox
            // 
            this.recvdteDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.recvdteDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.supplBindingSource, "recvdte", true));
            this.recvdteDateBox.Date = null;
            this.recvdteDateBox.DateValue = null;
            this.recvdteDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recvdteDateBox.Location = new System.Drawing.Point(595, 32);
            this.recvdteDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.recvdteDateBox.Name = "recvdteDateBox";
            this.recvdteDateBox.Size = new System.Drawing.Size(133, 21);
            this.recvdteDateBox.TabIndex = 107;
            // 
            // rmbfrmDateBox
            // 
            this.rmbfrmDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rmbfrmDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.supplBindingSource, "rmbfrm", true));
            this.rmbfrmDateBox.Date = null;
            this.rmbfrmDateBox.DateValue = null;
            this.rmbfrmDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rmbfrmDateBox.Location = new System.Drawing.Point(786, 161);
            this.rmbfrmDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.rmbfrmDateBox.Name = "rmbfrmDateBox";
            this.rmbfrmDateBox.Size = new System.Drawing.Size(133, 21);
            this.rmbfrmDateBox.TabIndex = 106;
            // 
            // rmbtoDateBox
            // 
            this.rmbtoDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rmbtoDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.supplBindingSource, "rmbto", true));
            this.rmbtoDateBox.Date = null;
            this.rmbtoDateBox.DateValue = null;
            this.rmbtoDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rmbtoDateBox.Location = new System.Drawing.Point(786, 106);
            this.rmbtoDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.rmbtoDateBox.Name = "rmbtoDateBox";
            this.rmbtoDateBox.Size = new System.Drawing.Size(133, 21);
            this.rmbtoDateBox.TabIndex = 105;
            // 
            // frmbindDateBox
            // 
            this.frmbindDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.supplBindingSource, "frmbind", true));
            this.frmbindDateBox.Date = null;
            this.frmbindDateBox.DateValue = null;
            this.frmbindDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmbindDateBox.Location = new System.Drawing.Point(276, 161);
            this.frmbindDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.frmbindDateBox.Name = "frmbindDateBox";
            this.frmbindDateBox.Size = new System.Drawing.Size(133, 21);
            this.frmbindDateBox.TabIndex = 104;
            // 
            // binddteDateBox
            // 
            this.binddteDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.supplBindingSource, "binddte", true));
            this.binddteDateBox.Date = null;
            this.binddteDateBox.DateValue = null;
            this.binddteDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.binddteDateBox.Location = new System.Drawing.Point(128, 161);
            this.binddteDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.binddteDateBox.Name = "binddteDateBox";
            this.binddteDateBox.Size = new System.Drawing.Size(133, 21);
            this.binddteDateBox.TabIndex = 103;
            // 
            // ioutDateBox
            // 
            this.ioutDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.supplBindingSource, "iout", true));
            this.ioutDateBox.Date = null;
            this.ioutDateBox.DateValue = null;
            this.ioutDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ioutDateBox.Location = new System.Drawing.Point(276, 133);
            this.ioutDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.ioutDateBox.Name = "ioutDateBox";
            this.ioutDateBox.Size = new System.Drawing.Size(133, 21);
            this.ioutDateBox.TabIndex = 102;
            // 
            // iinDateBox
            // 
            this.iinDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.supplBindingSource, "iin", true));
            this.iinDateBox.Date = null;
            this.iinDateBox.DateValue = null;
            this.iinDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iinDateBox.Location = new System.Drawing.Point(128, 133);
            this.iinDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.iinDateBox.Name = "iinDateBox";
            this.iinDateBox.Size = new System.Drawing.Size(133, 21);
            this.iinDateBox.TabIndex = 101;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "invno", true));
            this.label28.Location = new System.Drawing.Point(213, 13);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 13);
            this.label28.TabIndex = 96;
            this.label28.Text = "label7";
            // 
            // quotesBindingSource
            // 
            this.quotesBindingSource.DataMember = "cust_quotes";
            this.quotesBindingSource.DataSource = this.custBindingSource;
            // 
            // suppdetailDataGridView
            // 
            this.suppdetailDataGridView.AllowUserToAddRows = false;
            this.suppdetailDataGridView.AllowUserToDeleteRows = false;
            this.suppdetailDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suppdetailDataGridView.AutoGenerateColumns = false;
            this.suppdetailDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.suppdetailDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.suppdetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suppdetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            this.suppdetailDataGridView.DataSource = this.suppdetailBindingSource;
            this.suppdetailDataGridView.EnableHeadersVisualStyles = false;
            this.suppdetailDataGridView.Location = new System.Drawing.Point(67, 325);
            this.suppdetailDataGridView.Name = "suppdetailDataGridView";
            this.suppdetailDataGridView.RowHeadersVisible = false;
            this.suppdetailDataGridView.Size = new System.Drawing.Size(996, 361);
            this.suppdetailDataGridView.TabIndex = 92;
            this.suppdetailDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suppdetailDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn15.HeaderText = "Description";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "war";
            this.dataGridViewTextBoxColumn8.HeaderText = "Actual";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "wdr";
            this.dataGridViewTextBoxColumn9.HeaderText = "Due";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "wtr";
            this.dataGridViewTextBoxColumn10.HeaderText = "Time";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "invno";
            this.dataGridViewTextBoxColumn11.HeaderText = "invno";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "wir";
            this.dataGridViewTextBoxColumn12.HeaderText = "Initials";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn13.HeaderText = "id";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // suppdetailBindingSource
            // 
            this.suppdetailBindingSource.DataMember = "suppdetail";
            this.suppdetailBindingSource.DataSource = this.dsEndSheet;
            // 
            // partmemoTextBox
            // 
            this.partmemoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplBindingSource, "partmemo", true));
            this.partmemoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partmemoTextBox.Location = new System.Drawing.Point(174, 223);
            this.partmemoTextBox.Multiline = true;
            this.partmemoTextBox.Name = "partmemoTextBox";
            this.partmemoTextBox.Size = new System.Drawing.Size(481, 64);
            this.partmemoTextBox.TabIndex = 92;
            // 
            // totsigsTextBox
            // 
            this.totsigsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplBindingSource, "totsigs", true));
            this.totsigsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totsigsTextBox.Location = new System.Drawing.Point(536, 193);
            this.totsigsTextBox.Name = "totsigsTextBox";
            this.totsigsTextBox.Size = new System.Drawing.Size(100, 20);
            this.totsigsTextBox.TabIndex = 91;
            // 
            // supplementsCheckBox
            // 
            this.supplementsCheckBox.AutoSize = true;
            this.supplementsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.quotesBindingSource, "supplements", true));
            this.supplementsCheckBox.Location = new System.Drawing.Point(343, 193);
            this.supplementsCheckBox.Name = "supplementsCheckBox";
            this.supplementsCheckBox.Size = new System.Drawing.Size(145, 17);
            this.supplementsCheckBox.TabIndex = 90;
            this.supplementsCheckBox.Text = "My Story Supplement";
            this.supplementsCheckBox.UseVisualStyleBackColor = true;
            // 
            // oursuppCheckBox
            // 
            this.oursuppCheckBox.AutoSize = true;
            this.oursuppCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.quotesBindingSource, "oursupp", true));
            this.oursuppCheckBox.Location = new System.Drawing.Point(188, 193);
            this.oursuppCheckBox.Name = "oursuppCheckBox";
            this.oursuppCheckBox.Size = new System.Drawing.Size(149, 17);
            this.oursuppCheckBox.TabIndex = 89;
            this.oursuppCheckBox.Text = "Our Story Supplement";
            this.oursuppCheckBox.UseVisualStyleBackColor = true;
            // 
            // rmbtotTextBox
            // 
            this.rmbtotTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rmbtotTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplBindingSource, "rmbtot", true));
            this.rmbtotTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rmbtotTextBox.Location = new System.Drawing.Point(786, 193);
            this.rmbtotTextBox.Name = "rmbtotTextBox";
            this.rmbtotTextBox.Size = new System.Drawing.Size(100, 20);
            this.rmbtotTextBox.TabIndex = 88;
            // 
            // remaketypeComboBox
            // 
            this.remaketypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remaketypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplBindingSource, "remaketype", true));
            this.remaketypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remaketypeComboBox.FormattingEnabled = true;
            this.remaketypeComboBox.Location = new System.Drawing.Point(786, 133);
            this.remaketypeComboBox.Name = "remaketypeComboBox";
            this.remaketypeComboBox.Size = new System.Drawing.Size(215, 21);
            this.remaketypeComboBox.TabIndex = 86;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(655, 193);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(125, 13);
            this.label27.TabIndex = 84;
            this.label27.Text = "Total Book Remakes";
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(664, 161);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(116, 13);
            this.label26.TabIndex = 83;
            this.label26.Text = "From book Remake";
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(680, 133);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 13);
            this.label25.TabIndex = 82;
            this.label25.Text = "Type of Remake";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(676, 106);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 13);
            this.label24.TabIndex = 81;
            this.label24.Text = "To book Remake";
            // 
            // tape_1CheckBox
            // 
            this.tape_1CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.supplBindingSource, "tape_", true));
            this.tape_1CheckBox.Location = new System.Drawing.Point(125, 193);
            this.tape_1CheckBox.Name = "tape_1CheckBox";
            this.tape_1CheckBox.Size = new System.Drawing.Size(63, 17);
            this.tape_1CheckBox.TabIndex = 80;
            this.tape_1CheckBox.Text = "Tape";
            this.tape_1CheckBox.UseVisualStyleBackColor = true;
            // 
            // vendcdTextBox
            // 
            this.vendcdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplBindingSource, "vendcd", true));
            this.vendcdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendcdTextBox.Location = new System.Drawing.Point(507, 161);
            this.vendcdTextBox.Name = "vendcdTextBox";
            this.vendcdTextBox.Size = new System.Drawing.Size(36, 20);
            this.vendcdTextBox.TabIndex = 78;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(424, 161);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 13);
            this.label23.TabIndex = 77;
            this.label23.Text = "Print Vendor";
            // 
            // iinitTextBox
            // 
            this.iinitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplBindingSource, "iinit", true));
            this.iinitTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iinitTextBox.Location = new System.Drawing.Point(495, 133);
            this.iinitTextBox.Name = "iinitTextBox";
            this.iinitTextBox.Size = new System.Drawing.Size(49, 20);
            this.iinitTextBox.TabIndex = 74;
            // 
            // ideptTextBox
            // 
            this.ideptTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplBindingSource, "idept", true));
            this.ideptTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ideptTextBox.Location = new System.Drawing.Point(424, 133);
            this.ideptTextBox.Name = "ideptTextBox";
            this.ideptTextBox.Size = new System.Drawing.Size(62, 20);
            this.ideptTextBox.TabIndex = 73;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(125, 112);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(18, 13);
            this.label22.TabIndex = 70;
            this.label22.Text = "In";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(424, 112);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 13);
            this.label21.TabIndex = 69;
            this.label21.Text = "Dept";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(495, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(25, 13);
            this.label20.TabIndex = 68;
            this.label20.Text = "Init";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(276, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 13);
            this.label19.TabIndex = 67;
            this.label19.Text = "Out";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 161);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 13);
            this.label18.TabIndex = 66;
            this.label18.Text = "Date To Bindery";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(35, 133);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 13);
            this.label17.TabIndex = 65;
            this.label17.Text = "Check In/Out";
            // 
            // booktypeLabel1
            // 
            this.booktypeLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.booktypeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "booktype", true));
            this.booktypeLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.booktypeLabel1.Location = new System.Drawing.Point(680, 6);
            this.booktypeLabel1.Name = "booktypeLabel1";
            this.booktypeLabel1.Size = new System.Drawing.Size(100, 23);
            this.booktypeLabel1.TabIndex = 62;
            this.booktypeLabel1.Text = "label17";
            // 
            // nocopiesTextBox
            // 
            this.nocopiesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplBindingSource, "nocopies", true));
            this.nocopiesTextBox.Location = new System.Drawing.Point(602, 32);
            this.nocopiesTextBox.Name = "nocopiesTextBox";
            this.nocopiesTextBox.Size = new System.Drawing.Size(100, 20);
            this.nocopiesTextBox.TabIndex = 59;
            // 
            // nopagesTextBox1
            // 
            this.nopagesTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplBindingSource, "nopages", true));
            this.nopagesTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nopagesTextBox1.Location = new System.Drawing.Point(145, 32);
            this.nopagesTextBox1.Name = "nopagesTextBox1";
            this.nopagesTextBox1.Size = new System.Drawing.Size(100, 20);
            this.nopagesTextBox1.TabIndex = 58;
            this.nopagesTextBox1.Validating += new System.ComponentModel.CancelEventHandler(this.nopagesTextBox1_Validating);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "prodno", true));
            this.label15.Location = new System.Drawing.Point(64, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 57;
            this.label15.Text = "label7";
            // 
            // Banner
            // 
            this.Banner.AutoScroll = true;
            this.Banner.BackColor = System.Drawing.SystemColors.Control;
            this.Banner.Controls.Add(this.btnAddBannerWip);
            this.Banner.Controls.Add(this.btnUpdateBannerDates);
            this.Banner.Controls.Add(this.btnAddBanner);
            this.Banner.Controls.Add(this.btnPrintBannerTicket);
            this.Banner.Controls.Add(this.bannerdetailDataGridView);
            this.Banner.Controls.Add(this.bannerrecvDateBox);
            this.Banner.Controls.Add(label34);
            this.Banner.Controls.Add(this.textBox2);
            this.Banner.Controls.Add(this.button5);
            this.Banner.Controls.Add(specinstLabel);
            this.Banner.Controls.Add(this.specinstTextBox1);
            this.Banner.Controls.Add(customdescLabel);
            this.Banner.Controls.Add(this.customdescTextBox);
            this.Banner.Controls.Add(this.customCheckBox);
            this.Banner.Controls.Add(txtcolorLabel);
            this.Banner.Controls.Add(this.txtcolorComboBox);
            this.Banner.Controls.Add(bkcolorLabel);
            this.Banner.Controls.Add(this.bkcolorComboBox);
            this.Banner.Controls.Add(this.yrbksaleCheckBox);
            this.Banner.Controls.Add(mascotnameLabel);
            this.Banner.Controls.Add(this.mascotnameComboBox);
            this.Banner.Controls.Add(mascotslogLabel);
            this.Banner.Controls.Add(this.mascotslogTextBox);
            this.Banner.Controls.Add(this.mascotCheckBox);
            this.Banner.Controls.Add(endstrecvLabel1);
            this.Banner.Controls.Add(qtyLabel);
            this.Banner.Controls.Add(this.qtyTextBox);
            this.Banner.Controls.Add(this.button6);
            this.Banner.Controls.Add(this.textBox1);
            this.Banner.Controls.Add(numLabel);
            this.Banner.Controls.Add(this.numTextBox);
            this.Banner.Controls.Add(this.label36);
            this.Banner.Controls.Add(label37);
            this.Banner.Controls.Add(this.label38);
            this.Banner.Controls.Add(label39);
            this.Banner.Location = new System.Drawing.Point(4, 22);
            this.Banner.Name = "Banner";
            this.Banner.Padding = new System.Windows.Forms.Padding(3);
            this.Banner.Size = new System.Drawing.Size(1105, 714);
            this.Banner.TabIndex = 3;
            this.Banner.Text = "Banner";
            // 
            // btnAddBannerWip
            // 
            this.btnAddBannerWip.Location = new System.Drawing.Point(65, 351);
            this.btnAddBannerWip.Name = "btnAddBannerWip";
            this.btnAddBannerWip.Size = new System.Drawing.Size(123, 23);
            this.btnAddBannerWip.TabIndex = 228;
            this.btnAddBannerWip.Text = "New Scan Record";
            this.btnAddBannerWip.UseVisualStyleBackColor = true;
            this.btnAddBannerWip.Click += new System.EventHandler(this.btnAddBannerWip_Click);
            // 
            // btnUpdateBannerDates
            // 
            this.btnUpdateBannerDates.Location = new System.Drawing.Point(941, 71);
            this.btnUpdateBannerDates.Name = "btnUpdateBannerDates";
            this.btnUpdateBannerDates.Size = new System.Drawing.Size(107, 23);
            this.btnUpdateBannerDates.TabIndex = 160;
            this.btnUpdateBannerDates.Text = "Update Dates";
            this.btnUpdateBannerDates.UseVisualStyleBackColor = true;
            this.btnUpdateBannerDates.Visible = false;
            this.btnUpdateBannerDates.Click += new System.EventHandler(this.btnUpdateBannerDates_Click);
            // 
            // btnAddBanner
            // 
            this.btnAddBanner.Location = new System.Drawing.Point(941, 14);
            this.btnAddBanner.Name = "btnAddBanner";
            this.btnAddBanner.Size = new System.Drawing.Size(107, 23);
            this.btnAddBanner.TabIndex = 159;
            this.btnAddBanner.Text = "Add Banner";
            this.btnAddBanner.UseVisualStyleBackColor = true;
            this.btnAddBanner.Click += new System.EventHandler(this.btnAddBanner_Click);
            // 
            // btnPrintBannerTicket
            // 
            this.btnPrintBannerTicket.Location = new System.Drawing.Point(941, 43);
            this.btnPrintBannerTicket.Name = "btnPrintBannerTicket";
            this.btnPrintBannerTicket.Size = new System.Drawing.Size(107, 23);
            this.btnPrintBannerTicket.TabIndex = 158;
            this.btnPrintBannerTicket.Text = "Print Ticket";
            this.btnPrintBannerTicket.UseVisualStyleBackColor = true;
            this.btnPrintBannerTicket.Click += new System.EventHandler(this.btnPrintBannerTicket_Click);
            // 
            // bannerdetailDataGridView
            // 
            this.bannerdetailDataGridView.AllowUserToAddRows = false;
            this.bannerdetailDataGridView.AllowUserToDeleteRows = false;
            this.bannerdetailDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bannerdetailDataGridView.AutoGenerateColumns = false;
            this.bannerdetailDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bannerdetailDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.bannerdetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bannerdetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28});
            this.bannerdetailDataGridView.DataSource = this.bannerdetailBindingSource;
            this.bannerdetailDataGridView.EnableHeadersVisualStyles = false;
            this.bannerdetailDataGridView.Location = new System.Drawing.Point(61, 380);
            this.bannerdetailDataGridView.Name = "bannerdetailDataGridView";
            this.bannerdetailDataGridView.RowHeadersVisible = false;
            this.bannerdetailDataGridView.Size = new System.Drawing.Size(961, 327);
            this.bannerdetailDataGridView.TabIndex = 151;
            this.bannerdetailDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bannerdetailDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "war";
            this.dataGridViewTextBoxColumn23.HeaderText = "Actual";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "wdr";
            this.dataGridViewTextBoxColumn24.HeaderText = "Due";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.Visible = false;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "wtr";
            this.dataGridViewTextBoxColumn25.HeaderText = "Time";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "invno";
            this.dataGridViewTextBoxColumn26.HeaderText = "invno";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.Visible = false;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "wir";
            this.dataGridViewTextBoxColumn27.HeaderText = "Initials";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn28.HeaderText = "id";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            this.dataGridViewTextBoxColumn28.Visible = false;
            // 
            // bannerdetailBindingSource
            // 
            this.bannerdetailBindingSource.DataMember = "bannerdetail";
            this.bannerdetailBindingSource.DataSource = this.dsEndSheet;
            // 
            // bannerrecvDateBox
            // 
            this.bannerrecvDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.bannerBindingSource1, "endstrecv", true));
            this.bannerrecvDateBox.Date = null;
            this.bannerrecvDateBox.DateValue = null;
            this.bannerrecvDateBox.Location = new System.Drawing.Point(498, 61);
            this.bannerrecvDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.bannerrecvDateBox.Name = "bannerrecvDateBox";
            this.bannerrecvDateBox.Size = new System.Drawing.Size(133, 21);
            this.bannerrecvDateBox.TabIndex = 150;
            // 
            // bannerBindingSource1
            // 
            this.bannerBindingSource1.DataMember = "banner";
            this.bannerBindingSource1.DataSource = this.dsEndSheet;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(661, 278);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(361, 69);
            this.textBox2.TabIndex = 149;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(1928, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(180, 23);
            this.button5.TabIndex = 147;
            this.button5.Text = "Banner Production Ticket";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // specinstTextBox1
            // 
            this.specinstTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.specinstTextBox1.Location = new System.Drawing.Point(1653, 278);
            this.specinstTextBox1.Multiline = true;
            this.specinstTextBox1.Name = "specinstTextBox1";
            this.specinstTextBox1.Size = new System.Drawing.Size(361, 69);
            this.specinstTextBox1.TabIndex = 146;
            // 
            // customdescTextBox
            // 
            this.customdescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bannerBindingSource1, "customdesc", true));
            this.customdescTextBox.Location = new System.Drawing.Point(163, 278);
            this.customdescTextBox.Multiline = true;
            this.customdescTextBox.Name = "customdescTextBox";
            this.customdescTextBox.Size = new System.Drawing.Size(361, 60);
            this.customdescTextBox.TabIndex = 144;
            // 
            // customCheckBox
            // 
            this.customCheckBox.AutoSize = true;
            this.customCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bannerBindingSource1, "custom", true));
            this.customCheckBox.Location = new System.Drawing.Point(58, 251);
            this.customCheckBox.Name = "customCheckBox";
            this.customCheckBox.Size = new System.Drawing.Size(67, 17);
            this.customCheckBox.TabIndex = 142;
            this.customCheckBox.Text = "Custom";
            this.customCheckBox.UseVisualStyleBackColor = true;
            // 
            // txtcolorComboBox
            // 
            this.txtcolorComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bannerBindingSource1, "txtcolor", true));
            this.txtcolorComboBox.FormattingEnabled = true;
            this.txtcolorComboBox.Location = new System.Drawing.Point(163, 218);
            this.txtcolorComboBox.Name = "txtcolorComboBox";
            this.txtcolorComboBox.Size = new System.Drawing.Size(173, 21);
            this.txtcolorComboBox.TabIndex = 141;
            // 
            // bkcolorComboBox
            // 
            this.bkcolorComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bannerBindingSource1, "bkcolor", true));
            this.bkcolorComboBox.FormattingEnabled = true;
            this.bkcolorComboBox.Location = new System.Drawing.Point(163, 191);
            this.bkcolorComboBox.Name = "bkcolorComboBox";
            this.bkcolorComboBox.Size = new System.Drawing.Size(173, 21);
            this.bkcolorComboBox.TabIndex = 139;
            // 
            // yrbksaleCheckBox
            // 
            this.yrbksaleCheckBox.AutoSize = true;
            this.yrbksaleCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bannerBindingSource1, "yrbksale", true));
            this.yrbksaleCheckBox.Location = new System.Drawing.Point(58, 170);
            this.yrbksaleCheckBox.Name = "yrbksaleCheckBox";
            this.yrbksaleCheckBox.Size = new System.Drawing.Size(133, 17);
            this.yrbksaleCheckBox.TabIndex = 137;
            this.yrbksaleCheckBox.Text = "Yearbooks on Sale";
            this.yrbksaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // mascotnameComboBox
            // 
            this.mascotnameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bannerBindingSource1, "mascotname", true));
            this.mascotnameComboBox.FormattingEnabled = true;
            this.mascotnameComboBox.Location = new System.Drawing.Point(163, 137);
            this.mascotnameComboBox.MaxLength = 200;
            this.mascotnameComboBox.Name = "mascotnameComboBox";
            this.mascotnameComboBox.Size = new System.Drawing.Size(346, 21);
            this.mascotnameComboBox.TabIndex = 136;
            // 
            // mascotslogTextBox
            // 
            this.mascotslogTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bannerBindingSource1, "mascotslog", true));
            this.mascotslogTextBox.Location = new System.Drawing.Point(163, 111);
            this.mascotslogTextBox.MaxLength = 200;
            this.mascotslogTextBox.Name = "mascotslogTextBox";
            this.mascotslogTextBox.Size = new System.Drawing.Size(346, 20);
            this.mascotslogTextBox.TabIndex = 134;
            // 
            // mascotCheckBox
            // 
            this.mascotCheckBox.AutoSize = true;
            this.mascotCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bannerBindingSource1, "mascot", true));
            this.mascotCheckBox.Location = new System.Drawing.Point(58, 89);
            this.mascotCheckBox.Name = "mascotCheckBox";
            this.mascotCheckBox.Size = new System.Drawing.Size(67, 17);
            this.mascotCheckBox.TabIndex = 132;
            this.mascotCheckBox.Text = "Mascot";
            this.mascotCheckBox.UseVisualStyleBackColor = true;
            // 
            // qtyTextBox
            // 
            this.qtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bannerBindingSource1, "qty", true));
            this.qtyTextBox.Location = new System.Drawing.Point(275, 58);
            this.qtyTextBox.Name = "qtyTextBox";
            this.qtyTextBox.Size = new System.Drawing.Size(100, 20);
            this.qtyTextBox.TabIndex = 129;
            this.qtyTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.qtyTextBox_Validating);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(1432, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(71, 23);
            this.button6.TabIndex = 127;
            this.button6.Text = "Banner #";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(1513, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(84, 20);
            this.textBox1.TabIndex = 126;
            // 
            // numTextBox
            // 
            this.numTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bannerBindingSource1, "num", true));
            this.numTextBox.Location = new System.Drawing.Point(88, 58);
            this.numTextBox.Name = "numTextBox";
            this.numTextBox.Size = new System.Drawing.Size(100, 20);
            this.numTextBox.TabIndex = 125;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "invno", true));
            this.label36.Location = new System.Drawing.Point(207, 14);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(41, 13);
            this.label36.TabIndex = 123;
            this.label36.Text = "label7";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "prodno", true));
            this.label38.Location = new System.Drawing.Point(58, 14);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(41, 13);
            this.label38.TabIndex = 121;
            this.label38.Text = "label7";
            // 
            // preflitBindingSource
            // 
            this.preflitBindingSource.DataMember = "preflit";
            this.preflitBindingSource.DataSource = this.dsEndSheet;
            // 
            // custTableAdapter
            // 
            this.custTableAdapter.ClearBeforeFill = true;
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
            // supplTableAdapter
            // 
            this.supplTableAdapter.ClearBeforeFill = true;
            // 
            // suppdetailTableAdapter
            // 
            this.suppdetailTableAdapter.ClearBeforeFill = true;
            // 
            // preflitTableAdapter
            // 
            this.preflitTableAdapter.ClearBeforeFill = true;
            // 
            // bannerTableAdapter
            // 
            this.bannerTableAdapter.ClearBeforeFill = true;
            // 
            // bannerdetailTableAdapter
            // 
            this.bannerdetailTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.bannerdetailTableAdapter = null;
            this.tableAdapterManager.bannerTableAdapter = this.bannerTableAdapter;
            this.tableAdapterManager.custTableAdapter = this.custTableAdapter;
            this.tableAdapterManager.endsheetdetailTableAdapter = null;
            this.tableAdapterManager.endsheetTableAdapter = this.endsheetTableAdapter;
            this.tableAdapterManager.preflitTableAdapter = this.preflitTableAdapter;
            this.tableAdapterManager.produtnTableAdapter = this.produtnTableAdapter;
            this.tableAdapterManager.suppdetailTableAdapter = null;
            this.tableAdapterManager.supplTableAdapter = this.supplTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsEndSheetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmEndSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1125, 741);
            this.Controls.Add(this.tbEndSheets);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1141, 780);
            this.Name = "frmEndSheet";
            this.Text = "End Sheet/Supplements/Preflight";
            this.Activated += new System.EventHandler(this.frmEndSheet_Activated);
            this.Deactivate += new System.EventHandler(this.frmEndSheet_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEndSheet_FormClosing);
            this.Load += new System.EventHandler(this.frmEndSheet_Load);
            this.Shown += new System.EventHandler(this.frmEndSheet_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmEndSheet_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEndSheet_KeyPress);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.tbEndSheets, 0);
            this.tbEndSheets.ResumeLayout(false);
            this.pgEndSheets.ResumeLayout(false);
            this.pgEndSheets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endsheetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEndSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endsheetdetailDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endsheetdetailBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
            this.Supplement.ResumeLayout(false);
            this.Supplement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppdetailDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppdetailBindingSource)).EndInit();
            this.Banner.ResumeLayout(false);
            this.Banner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerdetailDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bannerdetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bannerBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preflitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tbEndSheets;
		private System.Windows.Forms.TabPage pgEndSheets;
		private System.Windows.Forms.TabPage Supplement;
		private DataSets.dsEndSheet dsEndSheet;
		private System.Windows.Forms.BindingSource custBindingSource;
		private DataSets.dsEndSheetTableAdapters.custTableAdapter custTableAdapter;
		private System.Windows.Forms.TextBox txtSchname;
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
		private System.Windows.Forms.TextBox endshtnoTextBox;
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
		private System.Windows.Forms.BindingSource endsheetdetailBindingSource;
		private DataSets.dsEndSheetTableAdapters.endsheetdetailTableAdapter endsheetdetailTableAdapter;
		private System.Windows.Forms.DataGridView endsheetdetailDataGridView;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.BindingSource supplBindingSource;
		private DataSets.dsEndSheetTableAdapters.supplTableAdapter supplTableAdapter;
		private System.Windows.Forms.Label booktypeLabel1;
		private System.Windows.Forms.TextBox nocopiesTextBox;
		private System.Windows.Forms.TextBox nopagesTextBox1;
		private System.Windows.Forms.TextBox iinitTextBox;
		private System.Windows.Forms.TextBox ideptTextBox;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox rmbtotTextBox;
		private System.Windows.Forms.ComboBox remaketypeComboBox;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.CheckBox tape_1CheckBox;
		private System.Windows.Forms.TextBox vendcdTextBox;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.CheckBox supplementsCheckBox;
		private System.Windows.Forms.CheckBox oursuppCheckBox;
		private System.Windows.Forms.TextBox totsigsTextBox;
		private System.Windows.Forms.TextBox partmemoTextBox;
		private System.Windows.Forms.BindingSource suppdetailBindingSource;
		private DataSets.dsEndSheetTableAdapters.suppdetailTableAdapter suppdetailTableAdapter;
		private System.Windows.Forms.DataGridView suppdetailDataGridView;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.BindingSource preflitBindingSource;
		private DataSets.dsEndSheetTableAdapters.preflitTableAdapter preflitTableAdapter;
		private System.Windows.Forms.TabPage Banner;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox specinstTextBox1;
		private System.Windows.Forms.TextBox customdescTextBox;
		private System.Windows.Forms.CheckBox customCheckBox;
		private System.Windows.Forms.ComboBox txtcolorComboBox;
		private System.Windows.Forms.ComboBox bkcolorComboBox;
		private System.Windows.Forms.CheckBox yrbksaleCheckBox;
		private System.Windows.Forms.ComboBox mascotnameComboBox;
		private System.Windows.Forms.TextBox mascotslogTextBox;
		private System.Windows.Forms.CheckBox mascotCheckBox;
		private System.Windows.Forms.TextBox qtyTextBox;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox numTextBox;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.BindingSource bannerBindingSource;
		private System.Windows.Forms.BindingSource bannerBindingSource1;
		private DataSets.dsEndSheetTableAdapters.bannerTableAdapter bannerTableAdapter;
		private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox laminatedTextBox;
        private CustomControls.DateBox otdtebkDateBox;
        private CustomControls.DateBox dcdtebkDateBox;
        private CustomControls.DateBox lamdtebkDateBox;
        private CustomControls.DateBox prtdtebkDateBox;
        private CustomControls.DateBox otdtesentDateBox;
        private CustomControls.DateBox dcdtesentDateBox;
        private CustomControls.DateBox lamdtesentDateBox;
        private CustomControls.DateBox prtdtesentDateBox;
        private CustomControls.DateBox endstrecvDateBox;
        private CustomControls.DateBox csoffholdDateBox;
        private CustomControls.DateBox csonholdDateBox;
        private CustomControls.DateBox desorgdteDateBox;
        private CustomControls.DateBox reprntdteDateBox;
        private CustomControls.DateBox prntsamDateBox;
        private CustomControls.DateBox duedateDateBox;
        private CustomControls.DateBox recvdteDateBox;
        private CustomControls.DateBox rmbfrmDateBox;
        private CustomControls.DateBox rmbtoDateBox;
        private CustomControls.DateBox frmbindDateBox;
        private CustomControls.DateBox binddteDateBox;
        private CustomControls.DateBox ioutDateBox;
        private CustomControls.DateBox iinDateBox;
        private CustomControls.DateBox bannerrecvDateBox;
        private System.Windows.Forms.BindingSource bannerdetailBindingSource;
        private DataSets.dsEndSheetTableAdapters.bannerdetailTableAdapter bannerdetailTableAdapter;
        private System.Windows.Forms.DataGridView bannerdetailDataGridView;
        private System.Windows.Forms.Button btnUpdateDates;
        private System.Windows.Forms.Button btnAddEndSheetRecord;
        private System.Windows.Forms.Button btnEndSheetTicket;
        private System.Windows.Forms.Button btnUpdateSuppDates;
        private System.Windows.Forms.Button btnAddSupp;
        private System.Windows.Forms.Button btnPrintSuppTicket;
        private System.Windows.Forms.Button btnUpdateBannerDates;
        private System.Windows.Forms.Button btnAddBanner;
        private System.Windows.Forms.Button btnPrintBannerTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox nocopiesTextBox1;
        private DataSets.dsEndSheetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label supnoLabel1;
        private System.Windows.Forms.Button btnNewEndSheetScanRec;
        private System.Windows.Forms.Button btnAddSupplScan;
        private System.Windows.Forms.Button btnAddBannerWip;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
