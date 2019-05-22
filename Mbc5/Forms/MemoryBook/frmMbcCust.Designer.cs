using System.Drawing.Printing;

namespace Mbc5.Forms.MemoryBook {
    partial class frmMbcCust
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
			System.Windows.Forms.Label contryearLabel;
			System.Windows.Forms.Label csrepLabel;
			System.Windows.Forms.Label junsnoLabel;
			System.Windows.Forms.Label contaddrLabel;
			System.Windows.Forms.Label contaddr2Label;
			System.Windows.Forms.Label contstateLabel;
			System.Windows.Forms.Label contzipLabel;
			System.Windows.Forms.Label contphnwrkLabel;
			System.Windows.Forms.Label contfaxLabel;
			System.Windows.Forms.Label contemailLabel;
			System.Windows.Forms.Label contfnameLabel;
			System.Windows.Forms.Label contlnameLabel;
			System.Windows.Forms.Label contphnhomLabel;
			System.Windows.Forms.Label positionLabel;
			System.Windows.Forms.Label lblEmail;
			System.Windows.Forms.Label lblFax;
			System.Windows.Forms.Label schoutLabel;
			System.Windows.Forms.Label spcinstLabel;
			System.Windows.Forms.Label extrchgLabel;
			System.Windows.Forms.Label schcolorsLabel;
			System.Windows.Forms.Label lblCategory;
			System.Windows.Forms.Label norebookreasonLabel;
			System.Windows.Forms.Label prevpublisherLabel;
			System.Windows.Forms.Label newpublisherLabel;
			System.Windows.Forms.Label clrpg_intLabel;
			System.Windows.Forms.Label enrollmentLabel;
			System.Windows.Forms.Label schphoneLabel;
			System.Windows.Forms.Label schaddrLabel;
			System.Windows.Forms.Label schzipLabel;
			System.Windows.Forms.Label schstateLabel;
			System.Windows.Forms.Label schaddr2Label;
			System.Windows.Forms.Label schcityLabel;
			System.Windows.Forms.Label dedayoutLabel;
			System.Windows.Forms.Label dedayinLabel;
			System.Windows.Forms.Label lblBookType;
			System.Windows.Forms.Label shiptocontLabel;
			System.Windows.Forms.Label yb_sthLabel;
			System.Windows.Forms.Label lblInterOffice;
			System.Windows.Forms.Label oraclecodeLabel;
			System.Windows.Forms.Label contdateLabel;
			System.Windows.Forms.Label sourdateLabel;
			System.Windows.Forms.Label initcontLabel;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label7;
			System.Windows.Forms.Label label8;
			System.Windows.Forms.Label label9;
			System.Windows.Forms.Label label10;
			System.Windows.Forms.Label label11;
			System.Windows.Forms.Label label12;
			System.Windows.Forms.Label label13;
			System.Windows.Forms.Label label26;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label18;
			System.Windows.Forms.Label label19;
			System.Windows.Forms.Label label24;
			System.Windows.Forms.Label label29;
			System.Windows.Forms.Label label30;
			System.Windows.Forms.Label label31;
			System.Windows.Forms.Label label32;
			System.Windows.Forms.Label label33;
			System.Windows.Forms.Label label34;
			System.Windows.Forms.Label statusLabel;
			System.Windows.Forms.Label stageLabel;
			System.Windows.Forms.Label leadsourceLabel;
			System.Windows.Forms.Label leadnameLabel;
			System.Windows.Forms.Label firstDaySchoolLabel;
			System.Windows.Forms.Label csrep2Label;
			System.Windows.Forms.Label jobnoLabel;
			System.Windows.Forms.Label advpwLabel;
			System.Windows.Forms.Label stfpwLabel;
			System.Windows.Forms.Label xeldateLabel;
			System.Windows.Forms.Label rbdateLabel;
			System.Windows.Forms.Label contcityLabel;
			System.Windows.Forms.Label bcontcityLabel;
			System.Windows.Forms.Label ccontcityLabel;
			System.Windows.Forms.Label taxExemptionReceivedLabel;
			System.Windows.Forms.Label stageLabel1;
			System.Windows.Forms.Label gradesLabel;
			System.Windows.Forms.Label enrollmentLabel1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMbcCust));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.ProdutnTicketModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ProductionCheckListBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.CustTab = new System.Windows.Forms.TabControl();
			this.pg1 = new System.Windows.Forms.TabPage();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.enrollmentTextBox = new System.Windows.Forms.TextBox();
			this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dsCust = new Mbc5.DataSets.dsCust();
			this.gradesComboBox = new System.Windows.Forms.ComboBox();
			this.blkwhiteCheckBox = new System.Windows.Forms.CheckBox();
			this.allcolorCheckBox = new System.Windows.Forms.CheckBox();
			this.stageComboBox1 = new System.Windows.Forms.ComboBox();
			this.taxExemptionReceivedDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.notTaxExemptCheckBox = new System.Windows.Forms.CheckBox();
			this.rbdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.xeldateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.stfpwLabel1 = new System.Windows.Forms.Label();
			this.advpwLabel1 = new System.Windows.Forms.Label();
			this.jobnoLabel1 = new System.Windows.Forms.Label();
			this.firstDaySchoolDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.leadnameComboBox = new System.Windows.Forms.ComboBox();
			this.addItemMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.AddLeadSource = new System.Windows.Forms.ToolStripMenuItem();
			this.AddLeadName = new System.Windows.Forms.ToolStripMenuItem();
			this.lkpLeadNameBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.leadsourceComboBox = new System.Windows.Forms.ComboBox();
			this.lkpLeadSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.isTaxExemptCheckBox = new System.Windows.Forms.CheckBox();
			this.statusComboBox = new System.Windows.Forms.ComboBox();
			this.electronicoptions = new System.Windows.Forms.ComboBox();
			this.electronickitCheckBox = new System.Windows.Forms.CheckBox();
			this.txtSchname = new System.Windows.Forms.TextBox();
			this.cmbState = new System.Windows.Forms.ComboBox();
			this.statesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.lookUp = new Mbc5.DataSets.LookUp();
			this.oraclecodeTextBox = new System.Windows.Forms.TextBox();
			this.contryearTextBox = new System.Windows.Forms.TextBox();
			this.initcontDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.sourdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.contdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.junsnoTextBox = new System.Windows.Forms.TextBox();
			this.txtSchColors = new System.Windows.Forms.TextBox();
			this.txtFax = new System.Windows.Forms.TextBox();
			this.txtCsRep = new System.Windows.Forms.TextBox();
			this.lblSchName = new System.Windows.Forms.Label();
			this.schoutDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.cmbSchCategory = new System.Windows.Forms.ComboBox();
			this.lkpschtypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.cmbNoRebook = new System.Windows.Forms.ComboBox();
			this.lkpNoRebookBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.cmbPrevPublisher = new System.Windows.Forms.ComboBox();
			this.lkpPrevPubBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.multiyearCheckBox = new System.Windows.Forms.CheckBox();
			this.txtPhotographer = new System.Windows.Forms.TextBox();
			this.multiyearComboBox = new System.Windows.Forms.ComboBox();
			this.lkpMultiYearOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.clrpg_intTextBox = new System.Windows.Forms.TextBox();
			this.schuploadingCheckBox = new System.Windows.Forms.CheckBox();
			this.sprinfoCheckBox = new System.Windows.Forms.CheckBox();
			this.fallinfoCheckBox = new System.Windows.Forms.CheckBox();
			this.clspicCheckBox = new System.Windows.Forms.CheckBox();
			this.springbreakTextBox = new System.Windows.Forms.TextBox();
			this.txtWebsite = new System.Windows.Forms.TextBox();
			this.btnWebsite = new System.Windows.Forms.Button();
			this.txtSchEmail = new System.Windows.Forms.TextBox();
			this.txtaddress = new System.Windows.Forms.TextBox();
			this.txtSchPhone = new System.Windows.Forms.TextBox();
			this.txtZip = new System.Windows.Forms.TextBox();
			this.txtAddress2 = new System.Windows.Forms.TextBox();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.btnProdTckt = new System.Windows.Forms.Button();
			this.btnProdChk = new System.Windows.Forms.Button();
			this.csrep2TextBox = new System.Windows.Forms.TextBox();
			this.stageComboBox = new System.Windows.Forms.ComboBox();
			this.dedayoutLabel2 = new System.Windows.Forms.Label();
			this.dedayinLabel2 = new System.Windows.Forms.Label();
			this.lblInvno = new System.Windows.Forms.Label();
			this.btnSchoolEmail = new System.Windows.Forms.Button();
			this.nodirectmailCheckBox = new System.Windows.Forms.CheckBox();
			this.nomktemailCheckBox = new System.Windows.Forms.CheckBox();
			this.custDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn105 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.qcontractyear = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.QInvno = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn108 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn111 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtBookType = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.spcinstTextBox = new System.Windows.Forms.TextBox();
			this.shiptocontTextBox = new System.Windows.Forms.TextBox();
			this.extrchgTextBox = new System.Windows.Forms.TextBox();
			this.btnInterOffice = new System.Windows.Forms.Button();
			this.yb_sthTextBox = new System.Windows.Forms.TextBox();
			this.inofficeTextBox = new System.Windows.Forms.TextBox();
			this.pnlHead = new System.Windows.Forms.Panel();
			this.btnNewCustomer = new System.Windows.Forms.Button();
			this.lblSchcodeVal = new System.Windows.Forms.Label();
			this.pg2 = new System.Windows.Forms.TabPage();
			this.ccontcityTextBox = new System.Windows.Forms.TextBox();
			this.bcontcityTextBox = new System.Windows.Forms.TextBox();
			this.contcityTextBox = new System.Windows.Forms.TextBox();
			this.comboBox5 = new System.Windows.Forms.ComboBox();
			this.contpstnBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
			this.comboBox6 = new System.Windows.Forms.ComboBox();
			this.statesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.txtContact3Email = new System.Windows.Forms.TextBox();
			this.btnEmailContac3 = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.btnEmailCont2 = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.contpstnBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.statesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.txtBContFname = new System.Windows.Forms.TextBox();
			this.txtContact2Email = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.btnEmailContact = new System.Windows.Forms.Button();
			this.label28 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.lblSeperator1 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.contpstnBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.contphnhomTextBox = new System.Windows.Forms.TextBox();
			this.contlnameTextBox = new System.Windows.Forms.TextBox();
			this.contfnameTextBox = new System.Windows.Forms.TextBox();
			this.txtContactEmail = new System.Windows.Forms.TextBox();
			this.contfaxTextBox = new System.Windows.Forms.TextBox();
			this.contphnwrkTextBox = new System.Windows.Forms.TextBox();
			this.contzipTextBox = new System.Windows.Forms.TextBox();
			this.contaddr2TextBox = new System.Windows.Forms.TextBox();
			this.contaddrTextBox = new System.Windows.Forms.TextBox();
			this.pg3 = new System.Windows.Forms.TabPage();
			this.chkMktComplete = new System.Windows.Forms.CheckBox();
			this.btnSaveMktLog = new System.Windows.Forms.Button();
			this.btnSaveTeleLog = new System.Windows.Forms.Button();
			this.lblSchcode = new System.Windows.Forms.Label();
			this.btnAddMarketLog = new System.Windows.Forms.Button();
			this.btnAddLog = new System.Windows.Forms.Button();
			this.lblMarketing = new System.Windows.Forms.Label();
			this.mktinfoDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.lkpMktReferenceBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.lkpPromotionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mktinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dsMktInfo = new Mbc5.DataSets.dsMktInfo();
			this.txtReason = new System.Windows.Forms.TextBox();
			this.datecontBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.commentListBox = new System.Windows.Forms.ListBox();
			this.lkpCommentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.datecontDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.datecont = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.initial = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.lkpTypeContBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.lblTeleSchname = new System.Windows.Forms.Label();
			this.custTableAdapter = new Mbc5.DataSets.dsCustTableAdapters.custTableAdapter();
			this.tableAdapterManager = new Mbc5.DataSets.dsCustTableAdapters.TableAdapterManager();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.statesTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.statesTableAdapter();
			this.tableAdapterManager1 = new Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.mktinfoTableAdapter = new Mbc5.DataSets.dsMktInfoTableAdapters.mktinfoTableAdapter();
			this.tableAdapterManager2 = new Mbc5.DataSets.dsMktInfoTableAdapters.TableAdapterManager();
			this.lkpPromotionsTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpPromotionsTableAdapter();
			this.lkpCommentsTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpCommentsTableAdapter();
			this.lkpTypeContTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpTypeContTableAdapter();
			this.lkpMktReferenceTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpMktReferenceTableAdapter();
			this.contpstnTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.contpstnTableAdapter();
			this.dsDateCont = new Mbc5.DataSets.dsDateCont();
			this.tableAdapterManager3 = new Mbc5.DataSets.dsDateContTableAdapters.TableAdapterManager();
			this.datecontTableAdapter = new Mbc5.DataSets.dsCustTableAdapters.datecontTableAdapter();
			this.datecontBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.txtModifiedBy = new System.Windows.Forms.TextBox();
			this.lkpNoRebookTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpNoRebookTableAdapter();
			this.lkpPrevPubTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpPrevPubTableAdapter();
			this.lkpMultiYearOptionsTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpMultiYearOptionsTableAdapter();
			this.lkpschtypeTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpschtypeTableAdapter();
			this.custSearchBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.custSearchTableAdapter = new Mbc5.DataSets.dsCustTableAdapters.custSearchTableAdapter();
			this.lkpLeadNameTableAdapter = new Mbc5.DataSets.dsCustTableAdapters.lkpLeadNameTableAdapter();
			this.lkpLeadSourceTableAdapter = new Mbc5.DataSets.dsCustTableAdapters.lkpLeadSourceTableAdapter();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.reportViewerCheckList = new Microsoft.Reporting.WinForms.ReportViewer();
			contryearLabel = new System.Windows.Forms.Label();
			csrepLabel = new System.Windows.Forms.Label();
			junsnoLabel = new System.Windows.Forms.Label();
			contaddrLabel = new System.Windows.Forms.Label();
			contaddr2Label = new System.Windows.Forms.Label();
			contstateLabel = new System.Windows.Forms.Label();
			contzipLabel = new System.Windows.Forms.Label();
			contphnwrkLabel = new System.Windows.Forms.Label();
			contfaxLabel = new System.Windows.Forms.Label();
			contemailLabel = new System.Windows.Forms.Label();
			contfnameLabel = new System.Windows.Forms.Label();
			contlnameLabel = new System.Windows.Forms.Label();
			contphnhomLabel = new System.Windows.Forms.Label();
			positionLabel = new System.Windows.Forms.Label();
			lblEmail = new System.Windows.Forms.Label();
			lblFax = new System.Windows.Forms.Label();
			schoutLabel = new System.Windows.Forms.Label();
			spcinstLabel = new System.Windows.Forms.Label();
			extrchgLabel = new System.Windows.Forms.Label();
			schcolorsLabel = new System.Windows.Forms.Label();
			lblCategory = new System.Windows.Forms.Label();
			norebookreasonLabel = new System.Windows.Forms.Label();
			prevpublisherLabel = new System.Windows.Forms.Label();
			newpublisherLabel = new System.Windows.Forms.Label();
			clrpg_intLabel = new System.Windows.Forms.Label();
			enrollmentLabel = new System.Windows.Forms.Label();
			schphoneLabel = new System.Windows.Forms.Label();
			schaddrLabel = new System.Windows.Forms.Label();
			schzipLabel = new System.Windows.Forms.Label();
			schstateLabel = new System.Windows.Forms.Label();
			schaddr2Label = new System.Windows.Forms.Label();
			schcityLabel = new System.Windows.Forms.Label();
			dedayoutLabel = new System.Windows.Forms.Label();
			dedayinLabel = new System.Windows.Forms.Label();
			lblBookType = new System.Windows.Forms.Label();
			shiptocontLabel = new System.Windows.Forms.Label();
			yb_sthLabel = new System.Windows.Forms.Label();
			lblInterOffice = new System.Windows.Forms.Label();
			oraclecodeLabel = new System.Windows.Forms.Label();
			contdateLabel = new System.Windows.Forms.Label();
			sourdateLabel = new System.Windows.Forms.Label();
			initcontLabel = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			label31 = new System.Windows.Forms.Label();
			label32 = new System.Windows.Forms.Label();
			label33 = new System.Windows.Forms.Label();
			label34 = new System.Windows.Forms.Label();
			statusLabel = new System.Windows.Forms.Label();
			stageLabel = new System.Windows.Forms.Label();
			leadsourceLabel = new System.Windows.Forms.Label();
			leadnameLabel = new System.Windows.Forms.Label();
			firstDaySchoolLabel = new System.Windows.Forms.Label();
			csrep2Label = new System.Windows.Forms.Label();
			jobnoLabel = new System.Windows.Forms.Label();
			advpwLabel = new System.Windows.Forms.Label();
			stfpwLabel = new System.Windows.Forms.Label();
			xeldateLabel = new System.Windows.Forms.Label();
			rbdateLabel = new System.Windows.Forms.Label();
			contcityLabel = new System.Windows.Forms.Label();
			bcontcityLabel = new System.Windows.Forms.Label();
			ccontcityLabel = new System.Windows.Forms.Label();
			taxExemptionReceivedLabel = new System.Windows.Forms.Label();
			stageLabel1 = new System.Windows.Forms.Label();
			gradesLabel = new System.Windows.Forms.Label();
			enrollmentLabel1 = new System.Windows.Forms.Label();
			this.BottomPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ProdutnTicketModelBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ProductionCheckListBindingSource)).BeginInit();
			this.CustTab.SuspendLayout();
			this.pg1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCust)).BeginInit();
			this.addItemMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lkpLeadNameBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpLeadSourceBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lookUp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpschtypeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpNoRebookBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpPrevPubBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpMultiYearOptionsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).BeginInit();
			this.pnlHead.SuspendLayout();
			this.pg2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.contpstnBindingSource2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statesBindingSource2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.contpstnBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statesBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.contpstnBindingSource)).BeginInit();
			this.pg3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mktinfoDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpMktReferenceBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpPromotionsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mktinfoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsMktInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datecontBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpCommentsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datecontDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpTypeContBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsDateCont)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datecontBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.custSearchBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// TopPanel
			// 
			this.TopPanel.Size = new System.Drawing.Size(1234, 10);
			// 
			// BottomPanel
			// 
			this.BottomPanel.Controls.Add(this.reportViewerCheckList);
			this.BottomPanel.Controls.Add(this.reportViewer1);
			this.BottomPanel.Controls.Add(this.txtModifiedBy);
			this.BottomPanel.Location = new System.Drawing.Point(0, 693);
			this.BottomPanel.Size = new System.Drawing.Size(1234, 38);
			// 
			// contryearLabel
			// 
			contryearLabel.AutoSize = true;
			contryearLabel.Location = new System.Drawing.Point(513, 8);
			contryearLabel.Name = "contryearLabel";
			contryearLabel.Size = new System.Drawing.Size(32, 13);
			contryearLabel.TabIndex = 71;
			contryearLabel.Text = "Year:";
			// 
			// csrepLabel
			// 
			csrepLabel.AutoSize = true;
			csrepLabel.Location = new System.Drawing.Point(2, 5);
			csrepLabel.Name = "csrepLabel";
			csrepLabel.Size = new System.Drawing.Size(69, 13);
			csrepLabel.TabIndex = 4;
			csrepLabel.Text = "Service Rep:";
			// 
			// junsnoLabel
			// 
			junsnoLabel.AutoSize = true;
			junsnoLabel.Location = new System.Drawing.Point(145, 8);
			junsnoLabel.Name = "junsnoLabel";
			junsnoLabel.Size = new System.Drawing.Size(45, 13);
			junsnoLabel.TabIndex = 9;
			junsnoLabel.Text = "JUNS#:";
			// 
			// contaddrLabel
			// 
			contaddrLabel.AutoSize = true;
			contaddrLabel.Location = new System.Drawing.Point(28, 55);
			contaddrLabel.Name = "contaddrLabel";
			contaddrLabel.Size = new System.Drawing.Size(48, 13);
			contaddrLabel.TabIndex = 0;
			contaddrLabel.Text = "Address:";
			// 
			// contaddr2Label
			// 
			contaddr2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			contaddr2Label.AutoSize = true;
			contaddr2Label.Location = new System.Drawing.Point(371, 55);
			contaddr2Label.Name = "contaddr2Label";
			contaddr2Label.Size = new System.Drawing.Size(54, 13);
			contaddr2Label.TabIndex = 2;
			contaddr2Label.Text = "Address2:";
			// 
			// contstateLabel
			// 
			contstateLabel.AutoSize = true;
			contstateLabel.Location = new System.Drawing.Point(41, 108);
			contstateLabel.Name = "contstateLabel";
			contstateLabel.Size = new System.Drawing.Size(35, 13);
			contstateLabel.TabIndex = 4;
			contstateLabel.Text = "State:";
			// 
			// contzipLabel
			// 
			contzipLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			contzipLabel.AutoSize = true;
			contzipLabel.Location = new System.Drawing.Point(400, 81);
			contzipLabel.Name = "contzipLabel";
			contzipLabel.Size = new System.Drawing.Size(25, 13);
			contzipLabel.TabIndex = 6;
			contzipLabel.Text = "Zip:";
			// 
			// contphnwrkLabel
			// 
			contphnwrkLabel.AutoSize = true;
			contphnwrkLabel.Location = new System.Drawing.Point(6, 135);
			contphnwrkLabel.Name = "contphnwrkLabel";
			contphnwrkLabel.Size = new System.Drawing.Size(70, 13);
			contphnwrkLabel.TabIndex = 8;
			contphnwrkLabel.Text = "Work Phone:";
			// 
			// contfaxLabel
			// 
			contfaxLabel.AutoSize = true;
			contfaxLabel.Location = new System.Drawing.Point(353, 134);
			contfaxLabel.Name = "contfaxLabel";
			contfaxLabel.Size = new System.Drawing.Size(61, 13);
			contfaxLabel.TabIndex = 10;
			contfaxLabel.Text = "Cell Phone:";
			// 
			// contemailLabel
			// 
			contemailLabel.AutoSize = true;
			contemailLabel.Location = new System.Drawing.Point(384, 165);
			contemailLabel.Name = "contemailLabel";
			contemailLabel.Size = new System.Drawing.Size(35, 13);
			contemailLabel.TabIndex = 12;
			contemailLabel.Text = "Email:";
			// 
			// contfnameLabel
			// 
			contfnameLabel.AutoSize = true;
			contfnameLabel.Location = new System.Drawing.Point(16, 29);
			contfnameLabel.Name = "contfnameLabel";
			contfnameLabel.Size = new System.Drawing.Size(60, 13);
			contfnameLabel.TabIndex = 14;
			contfnameLabel.Text = "First Name:";
			// 
			// contlnameLabel
			// 
			contlnameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			contlnameLabel.AutoSize = true;
			contlnameLabel.Location = new System.Drawing.Point(364, 29);
			contlnameLabel.Name = "contlnameLabel";
			contlnameLabel.Size = new System.Drawing.Size(61, 13);
			contlnameLabel.TabIndex = 16;
			contlnameLabel.Text = "Last Name:";
			// 
			// contphnhomLabel
			// 
			contphnhomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			contphnhomLabel.AutoSize = true;
			contphnhomLabel.Location = new System.Drawing.Point(353, 108);
			contphnhomLabel.Name = "contphnhomLabel";
			contphnhomLabel.Size = new System.Drawing.Size(72, 13);
			contphnhomLabel.TabIndex = 18;
			contphnhomLabel.Text = "Home Phone:";
			// 
			// positionLabel
			// 
			positionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			positionLabel.AutoSize = true;
			positionLabel.Location = new System.Drawing.Point(40, 161);
			positionLabel.Name = "positionLabel";
			positionLabel.Size = new System.Drawing.Size(47, 13);
			positionLabel.TabIndex = 20;
			positionLabel.Text = "Position:";
			// 
			// lblEmail
			// 
			lblEmail.AutoSize = true;
			lblEmail.Location = new System.Drawing.Point(54, 207);
			lblEmail.Name = "lblEmail";
			lblEmail.Size = new System.Drawing.Size(35, 13);
			lblEmail.TabIndex = 93;
			lblEmail.Text = "Email:";
			// 
			// lblFax
			// 
			lblFax.AutoSize = true;
			lblFax.Location = new System.Drawing.Point(390, 182);
			lblFax.Name = "lblFax";
			lblFax.Size = new System.Drawing.Size(27, 13);
			lblFax.TabIndex = 90;
			lblFax.Text = "Fax:";
			// 
			// schoutLabel
			// 
			schoutLabel.AutoSize = true;
			schoutLabel.Location = new System.Drawing.Point(336, 61);
			schoutLabel.Name = "schoutLabel";
			schoutLabel.Size = new System.Drawing.Size(52, 13);
			schoutLabel.TabIndex = 23;
			schoutLabel.Text = "Last Day:";
			// 
			// spcinstLabel
			// 
			spcinstLabel.AutoSize = true;
			spcinstLabel.Location = new System.Drawing.Point(8, 260);
			spcinstLabel.Name = "spcinstLabel";
			spcinstLabel.Size = new System.Drawing.Size(92, 13);
			spcinstLabel.TabIndex = 43;
			spcinstLabel.Text = "Production Notes:";
			// 
			// extrchgLabel
			// 
			extrchgLabel.AutoSize = true;
			extrchgLabel.Location = new System.Drawing.Point(25, 193);
			extrchgLabel.Name = "extrchgLabel";
			extrchgLabel.Size = new System.Drawing.Size(76, 13);
			extrchgLabel.TabIndex = 41;
			extrchgLabel.Text = "Extra Charges:";
			// 
			// schcolorsLabel
			// 
			schcolorsLabel.AutoSize = true;
			schcolorsLabel.Location = new System.Drawing.Point(262, 375);
			schcolorsLabel.Name = "schcolorsLabel";
			schcolorsLabel.Size = new System.Drawing.Size(75, 13);
			schcolorsLabel.TabIndex = 27;
			schcolorsLabel.Text = "School Colors:";
			// 
			// lblCategory
			// 
			lblCategory.AutoSize = true;
			lblCategory.Location = new System.Drawing.Point(249, 351);
			lblCategory.Name = "lblCategory";
			lblCategory.Size = new System.Drawing.Size(88, 13);
			lblCategory.TabIndex = 24;
			lblCategory.Text = "School Category:";
			// 
			// norebookreasonLabel
			// 
			norebookreasonLabel.AutoSize = true;
			norebookreasonLabel.Location = new System.Drawing.Point(19, 296);
			norebookreasonLabel.Name = "norebookreasonLabel";
			norebookreasonLabel.Size = new System.Drawing.Size(80, 13);
			norebookreasonLabel.TabIndex = 12;
			norebookreasonLabel.Text = "Not Rebooked:";
			// 
			// prevpublisherLabel
			// 
			prevpublisherLabel.AutoSize = true;
			prevpublisherLabel.Location = new System.Drawing.Point(24, 325);
			prevpublisherLabel.Name = "prevpublisherLabel";
			prevpublisherLabel.Size = new System.Drawing.Size(75, 13);
			prevpublisherLabel.TabIndex = 20;
			prevpublisherLabel.Text = "Prev Publisher";
			// 
			// newpublisherLabel
			// 
			newpublisherLabel.AutoSize = true;
			newpublisherLabel.Location = new System.Drawing.Point(263, 325);
			newpublisherLabel.Name = "newpublisherLabel";
			newpublisherLabel.Size = new System.Drawing.Size(74, 13);
			newpublisherLabel.TabIndex = 22;
			newpublisherLabel.Text = "Photographer:";
			// 
			// clrpg_intLabel
			// 
			clrpg_intLabel.AutoSize = true;
			clrpg_intLabel.Location = new System.Drawing.Point(349, 303);
			clrpg_intLabel.Name = "clrpg_intLabel";
			clrpg_intLabel.Size = new System.Drawing.Size(36, 13);
			clrpg_intLabel.TabIndex = 22;
			clrpg_intLabel.Text = "Prints:";
			// 
			// enrollmentLabel
			// 
			enrollmentLabel.AutoSize = true;
			enrollmentLabel.Location = new System.Drawing.Point(28, 271);
			enrollmentLabel.Name = "enrollmentLabel";
			enrollmentLabel.Size = new System.Drawing.Size(71, 13);
			enrollmentLabel.TabIndex = 59;
			enrollmentLabel.Text = "Spring Break:";
			// 
			// schphoneLabel
			// 
			schphoneLabel.AutoSize = true;
			schphoneLabel.Location = new System.Drawing.Point(202, 181);
			schphoneLabel.Name = "schphoneLabel";
			schphoneLabel.Size = new System.Drawing.Size(41, 13);
			schphoneLabel.TabIndex = 42;
			schphoneLabel.Text = "Phone:";
			// 
			// schaddrLabel
			// 
			schaddrLabel.AutoSize = true;
			schaddrLabel.Location = new System.Drawing.Point(3, 129);
			schaddrLabel.Name = "schaddrLabel";
			schaddrLabel.Size = new System.Drawing.Size(48, 13);
			schaddrLabel.TabIndex = 32;
			schaddrLabel.Text = "Address:";
			// 
			// schzipLabel
			// 
			schzipLabel.AutoSize = true;
			schzipLabel.Location = new System.Drawing.Point(26, 181);
			schzipLabel.Name = "schzipLabel";
			schzipLabel.Size = new System.Drawing.Size(25, 13);
			schzipLabel.TabIndex = 40;
			schzipLabel.Text = "Zip:";
			// 
			// schstateLabel
			// 
			schstateLabel.AutoSize = true;
			schstateLabel.Location = new System.Drawing.Point(267, 155);
			schstateLabel.Name = "schstateLabel";
			schstateLabel.Size = new System.Drawing.Size(35, 13);
			schstateLabel.TabIndex = 38;
			schstateLabel.Text = "State:";
			// 
			// schaddr2Label
			// 
			schaddr2Label.AutoSize = true;
			schaddr2Label.Location = new System.Drawing.Point(248, 129);
			schaddr2Label.Name = "schaddr2Label";
			schaddr2Label.Size = new System.Drawing.Size(54, 13);
			schaddr2Label.TabIndex = 34;
			schaddr2Label.Text = "Address2:";
			// 
			// schcityLabel
			// 
			schcityLabel.AutoSize = true;
			schcityLabel.Location = new System.Drawing.Point(24, 155);
			schcityLabel.Name = "schcityLabel";
			schcityLabel.Size = new System.Drawing.Size(27, 13);
			schcityLabel.TabIndex = 36;
			schcityLabel.Text = "City:";
			// 
			// dedayoutLabel
			// 
			dedayoutLabel.AutoSize = true;
			dedayoutLabel.Location = new System.Drawing.Point(101, 69);
			dedayoutLabel.Name = "dedayoutLabel";
			dedayoutLabel.Size = new System.Drawing.Size(79, 13);
			dedayoutLabel.TabIndex = 11;
			dedayoutLabel.Text = "Dead Line Out:";
			// 
			// dedayinLabel
			// 
			dedayinLabel.AutoSize = true;
			dedayinLabel.Location = new System.Drawing.Point(109, 46);
			dedayinLabel.Name = "dedayinLabel";
			dedayinLabel.Size = new System.Drawing.Size(71, 13);
			dedayinLabel.TabIndex = 5;
			dedayinLabel.Text = "Dead Line In:";
			// 
			// lblBookType
			// 
			lblBookType.AutoSize = true;
			lblBookType.Location = new System.Drawing.Point(469, 5);
			lblBookType.Name = "lblBookType";
			lblBookType.Size = new System.Drawing.Size(62, 13);
			lblBookType.TabIndex = 2;
			lblBookType.Text = "Book Type:";
			// 
			// shiptocontLabel
			// 
			shiptocontLabel.AutoSize = true;
			shiptocontLabel.Location = new System.Drawing.Point(13, 92);
			shiptocontLabel.Name = "shiptocontLabel";
			shiptocontLabel.Size = new System.Drawing.Size(36, 13);
			shiptocontLabel.TabIndex = 13;
			shiptocontLabel.Text = "Other:";
			// 
			// yb_sthLabel
			// 
			yb_sthLabel.AutoSize = true;
			yb_sthLabel.Location = new System.Drawing.Point(20, 67);
			yb_sthLabel.Name = "yb_sthLabel";
			yb_sthLabel.Size = new System.Drawing.Size(29, 13);
			yb_sthLabel.TabIndex = 9;
			yb_sthLabel.Text = "Y/B:";
			// 
			// lblInterOffice
			// 
			lblInterOffice.AutoSize = true;
			lblInterOffice.Location = new System.Drawing.Point(35, 120);
			lblInterOffice.Name = "lblInterOffice";
			lblInterOffice.Size = new System.Drawing.Size(62, 13);
			lblInterOffice.TabIndex = 38;
			lblInterOffice.Text = "Inter Office:";
			// 
			// oraclecodeLabel
			// 
			oraclecodeLabel.AutoSize = true;
			oraclecodeLabel.Location = new System.Drawing.Point(297, 8);
			oraclecodeLabel.Name = "oraclecodeLabel";
			oraclecodeLabel.Size = new System.Drawing.Size(66, 13);
			oraclecodeLabel.TabIndex = 93;
			oraclecodeLabel.Text = "Oracle Code";
			// 
			// contdateLabel
			// 
			contdateLabel.AutoSize = true;
			contdateLabel.Location = new System.Drawing.Point(19, 78);
			contdateLabel.Name = "contdateLabel";
			contdateLabel.Size = new System.Drawing.Size(75, 13);
			contdateLabel.TabIndex = 96;
			contdateLabel.Text = "Booking Date:";
			// 
			// sourdateLabel
			// 
			sourdateLabel.AutoSize = true;
			sourdateLabel.Location = new System.Drawing.Point(52, 55);
			sourdateLabel.Name = "sourdateLabel";
			sourdateLabel.Size = new System.Drawing.Size(42, 13);
			sourdateLabel.TabIndex = 96;
			sourdateLabel.Text = "Sample";
			// 
			// initcontLabel
			// 
			initcontLabel.AutoSize = true;
			initcontLabel.Location = new System.Drawing.Point(50, 31);
			initcontLabel.Name = "initcontLabel";
			initcontLabel.Size = new System.Drawing.Size(44, 13);
			initcontLabel.TabIndex = 97;
			initcontLabel.Text = "Contact";
			// 
			// label3
			// 
			label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(33, 369);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(47, 13);
			label3.TabIndex = 120;
			label3.Text = "Position:";
			// 
			// label4
			// 
			label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(353, 316);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(72, 13);
			label4.TabIndex = 119;
			label4.Text = "Home Phone:";
			// 
			// label5
			// 
			label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(364, 238);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(61, 13);
			label5.TabIndex = 118;
			label5.Text = "Last Name:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(20, 238);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(60, 13);
			label6.TabIndex = 117;
			label6.Text = "First Name:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(384, 373);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(35, 13);
			label7.TabIndex = 116;
			label7.Text = "Email:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(358, 344);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(61, 13);
			label8.TabIndex = 115;
			label8.Text = "Cell Phone:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(10, 344);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(70, 13);
			label9.TabIndex = 114;
			label9.Text = "Work Phone:";
			// 
			// label10
			// 
			label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(400, 289);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(25, 13);
			label10.TabIndex = 113;
			label10.Text = "Zip:";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(45, 316);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(35, 13);
			label11.TabIndex = 112;
			label11.Text = "State:";
			// 
			// label12
			// 
			label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(371, 264);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(54, 13);
			label12.TabIndex = 111;
			label12.Text = "Address2:";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(32, 264);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(48, 13);
			label13.TabIndex = 110;
			label13.Text = "Address:";
			// 
			// label26
			// 
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(384, 573);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(35, 13);
			label26.TabIndex = 184;
			label26.Text = "Email:";
			// 
			// label2
			// 
			label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(29, 570);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(47, 13);
			label2.TabIndex = 248;
			label2.Text = "Position:";
			// 
			// label18
			// 
			label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(353, 517);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(72, 13);
			label18.TabIndex = 247;
			label18.Text = "Home Phone:";
			// 
			// label19
			// 
			label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(364, 438);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(61, 13);
			label19.TabIndex = 246;
			label19.Text = "Last Name:";
			// 
			// label24
			// 
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(16, 437);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(60, 13);
			label24.TabIndex = 245;
			label24.Text = "First Name:";
			// 
			// label29
			// 
			label29.AutoSize = true;
			label29.Location = new System.Drawing.Point(358, 543);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(61, 13);
			label29.TabIndex = 244;
			label29.Text = "Cell Phone:";
			// 
			// label30
			// 
			label30.AutoSize = true;
			label30.Location = new System.Drawing.Point(6, 543);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(70, 13);
			label30.TabIndex = 243;
			label30.Text = "Work Phone:";
			// 
			// label31
			// 
			label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label31.AutoSize = true;
			label31.Location = new System.Drawing.Point(400, 490);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(25, 13);
			label31.TabIndex = 242;
			label31.Text = "Zip:";
			// 
			// label32
			// 
			label32.AutoSize = true;
			label32.Location = new System.Drawing.Point(41, 514);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(35, 13);
			label32.TabIndex = 241;
			label32.Text = "State:";
			// 
			// label33
			// 
			label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label33.AutoSize = true;
			label33.Location = new System.Drawing.Point(371, 464);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(54, 13);
			label33.TabIndex = 240;
			label33.Text = "Address2:";
			// 
			// label34
			// 
			label34.AutoSize = true;
			label34.Location = new System.Drawing.Point(28, 463);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(48, 13);
			label34.TabIndex = 239;
			label34.Text = "Address:";
			// 
			// statusLabel
			// 
			statusLabel.AutoSize = true;
			statusLabel.Location = new System.Drawing.Point(201, 37);
			statusLabel.Name = "statusLabel";
			statusLabel.Size = new System.Drawing.Size(40, 13);
			statusLabel.TabIndex = 103;
			statusLabel.Text = "Status:";
			// 
			// stageLabel
			// 
			stageLabel.AutoSize = true;
			stageLabel.Location = new System.Drawing.Point(97, 96);
			stageLabel.Name = "stageLabel";
			stageLabel.Size = new System.Drawing.Size(46, 13);
			stageLabel.TabIndex = 45;
			stageLabel.Text = "Staging:";
			// 
			// leadsourceLabel
			// 
			leadsourceLabel.AutoSize = true;
			leadsourceLabel.Location = new System.Drawing.Point(21, 400);
			leadsourceLabel.Name = "leadsourceLabel";
			leadsourceLabel.Size = new System.Drawing.Size(71, 13);
			leadsourceLabel.TabIndex = 106;
			leadsourceLabel.Text = "Lead Source:";
			// 
			// leadnameLabel
			// 
			leadnameLabel.AutoSize = true;
			leadnameLabel.Location = new System.Drawing.Point(272, 400);
			leadnameLabel.Name = "leadnameLabel";
			leadnameLabel.Size = new System.Drawing.Size(65, 13);
			leadnameLabel.TabIndex = 107;
			leadnameLabel.Text = "Lead Name:";
			// 
			// firstDaySchoolLabel
			// 
			firstDaySchoolLabel.AutoSize = true;
			firstDaySchoolLabel.Location = new System.Drawing.Point(190, 61);
			firstDaySchoolLabel.Name = "firstDaySchoolLabel";
			firstDaySchoolLabel.Size = new System.Drawing.Size(51, 13);
			firstDaySchoolLabel.TabIndex = 108;
			firstDaySchoolLabel.Text = "First Day:";
			// 
			// csrep2Label
			// 
			csrep2Label.AutoSize = true;
			csrep2Label.Location = new System.Drawing.Point(12, 8);
			csrep2Label.Name = "csrep2Label";
			csrep2Label.Size = new System.Drawing.Size(59, 13);
			csrep2Label.TabIndex = 109;
			csrep2Label.Text = "Sales Rep:";
			// 
			// jobnoLabel
			// 
			jobnoLabel.AutoSize = true;
			jobnoLabel.Location = new System.Drawing.Point(52, 483);
			jobnoLabel.Name = "jobnoLabel";
			jobnoLabel.Size = new System.Drawing.Size(47, 13);
			jobnoLabel.TabIndex = 109;
			jobnoLabel.Text = "Job No.:";
			// 
			// advpwLabel
			// 
			advpwLabel.AutoSize = true;
			advpwLabel.Location = new System.Drawing.Point(5, 506);
			advpwLabel.Name = "advpwLabel";
			advpwLabel.Size = new System.Drawing.Size(94, 13);
			advpwLabel.TabIndex = 110;
			advpwLabel.Text = "Advisor Password:";
			// 
			// stfpwLabel
			// 
			stfpwLabel.AutoSize = true;
			stfpwLabel.Location = new System.Drawing.Point(18, 531);
			stfpwLabel.Name = "stfpwLabel";
			stfpwLabel.Size = new System.Drawing.Size(81, 13);
			stfpwLabel.TabIndex = 111;
			stfpwLabel.Text = "Staff Password:";
			// 
			// xeldateLabel
			// 
			xeldateLabel.AutoSize = true;
			xeldateLabel.Location = new System.Drawing.Point(257, 486);
			xeldateLabel.Name = "xeldateLabel";
			xeldateLabel.Size = new System.Drawing.Size(69, 13);
			xeldateLabel.TabIndex = 112;
			xeldateLabel.Text = "Cancel Date:";
			// 
			// rbdateLabel
			// 
			rbdateLabel.AutoSize = true;
			rbdateLabel.Location = new System.Drawing.Point(225, 512);
			rbdateLabel.Name = "rbdateLabel";
			rbdateLabel.Size = new System.Drawing.Size(101, 13);
			rbdateLabel.TabIndex = 113;
			rbdateLabel.Text = "Cancel Fee Recv\'d:";
			// 
			// contcityLabel
			// 
			contcityLabel.AutoSize = true;
			contcityLabel.Location = new System.Drawing.Point(49, 79);
			contcityLabel.Name = "contcityLabel";
			contcityLabel.Size = new System.Drawing.Size(27, 13);
			contcityLabel.TabIndex = 248;
			contcityLabel.Text = "City:";
			// 
			// bcontcityLabel
			// 
			bcontcityLabel.AutoSize = true;
			bcontcityLabel.Location = new System.Drawing.Point(53, 289);
			bcontcityLabel.Name = "bcontcityLabel";
			bcontcityLabel.Size = new System.Drawing.Size(27, 13);
			bcontcityLabel.TabIndex = 249;
			bcontcityLabel.Text = "City:";
			// 
			// ccontcityLabel
			// 
			ccontcityLabel.AutoSize = true;
			ccontcityLabel.Location = new System.Drawing.Point(49, 490);
			ccontcityLabel.Name = "ccontcityLabel";
			ccontcityLabel.Size = new System.Drawing.Size(27, 13);
			ccontcityLabel.TabIndex = 250;
			ccontcityLabel.Text = "City:";
			// 
			// taxExemptionReceivedLabel
			// 
			taxExemptionReceivedLabel.AutoSize = true;
			taxExemptionReceivedLabel.Location = new System.Drawing.Point(197, 556);
			taxExemptionReceivedLabel.Name = "taxExemptionReceivedLabel";
			taxExemptionReceivedLabel.Size = new System.Drawing.Size(129, 13);
			taxExemptionReceivedLabel.TabIndex = 115;
			taxExemptionReceivedLabel.Text = "Tax Exemption Received:";
			// 
			// stageLabel1
			// 
			stageLabel1.AutoSize = true;
			stageLabel1.Location = new System.Drawing.Point(53, 248);
			stageLabel1.Name = "stageLabel1";
			stageLabel1.Size = new System.Drawing.Size(46, 13);
			stageLabel1.TabIndex = 117;
			stageLabel1.Text = "Staging:";
			// 
			// gradesLabel
			// 
			gradesLabel.AutoSize = true;
			gradesLabel.Location = new System.Drawing.Point(269, 427);
			gradesLabel.Name = "gradesLabel";
			gradesLabel.Size = new System.Drawing.Size(68, 13);
			gradesLabel.TabIndex = 120;
			gradesLabel.Text = "Grade Level:";
			// 
			// enrollmentLabel1
			// 
			enrollmentLabel1.AutoSize = true;
			enrollmentLabel1.Location = new System.Drawing.Point(61, 427);
			enrollmentLabel1.Name = "enrollmentLabel1";
			enrollmentLabel1.Size = new System.Drawing.Size(36, 13);
			enrollmentLabel1.TabIndex = 121;
			enrollmentLabel1.Text = "Enroll:";
			// 
			// ProdutnTicketModelBindingSource
			// 
			this.ProdutnTicketModelBindingSource.DataSource = typeof(BindingModels.ProdutnTicketModel);
			// 
			// CustTab
			// 
			this.CustTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CustTab.Controls.Add(this.pg1);
			this.CustTab.Controls.Add(this.pg2);
			this.CustTab.Controls.Add(this.pg3);
			this.CustTab.Location = new System.Drawing.Point(0, 20);
			this.CustTab.Name = "CustTab";
			this.CustTab.SelectedIndex = 0;
			this.CustTab.Size = new System.Drawing.Size(1234, 670);
			this.CustTab.TabIndex = 0;
			// 
			// pg1
			// 
			this.pg1.AutoScroll = true;
			this.pg1.BackColor = System.Drawing.Color.Transparent;
			this.pg1.Controls.Add(this.splitContainer);
			this.pg1.Controls.Add(this.pnlHead);
			this.pg1.Location = new System.Drawing.Point(4, 22);
			this.pg1.Margin = new System.Windows.Forms.Padding(2);
			this.pg1.Name = "pg1";
			this.pg1.Padding = new System.Windows.Forms.Padding(3);
			this.pg1.Size = new System.Drawing.Size(1226, 644);
			this.pg1.TabIndex = 0;
			this.pg1.Text = "School";
			this.pg1.Enter += new System.EventHandler(this.pg1_Enter);
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.Location = new System.Drawing.Point(2, 45);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.AutoScroll = true;
			this.splitContainer.Panel1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer.Panel1.Controls.Add(enrollmentLabel1);
			this.splitContainer.Panel1.Controls.Add(this.enrollmentTextBox);
			this.splitContainer.Panel1.Controls.Add(gradesLabel);
			this.splitContainer.Panel1.Controls.Add(this.gradesComboBox);
			this.splitContainer.Panel1.Controls.Add(this.blkwhiteCheckBox);
			this.splitContainer.Panel1.Controls.Add(this.allcolorCheckBox);
			this.splitContainer.Panel1.Controls.Add(stageLabel1);
			this.splitContainer.Panel1.Controls.Add(this.stageComboBox1);
			this.splitContainer.Panel1.Controls.Add(this.taxExemptionReceivedDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(this.notTaxExemptCheckBox);
			this.splitContainer.Panel1.Controls.Add(taxExemptionReceivedLabel);
			this.splitContainer.Panel1.Controls.Add(rbdateLabel);
			this.splitContainer.Panel1.Controls.Add(this.rbdateDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(xeldateLabel);
			this.splitContainer.Panel1.Controls.Add(this.xeldateDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(stfpwLabel);
			this.splitContainer.Panel1.Controls.Add(this.stfpwLabel1);
			this.splitContainer.Panel1.Controls.Add(advpwLabel);
			this.splitContainer.Panel1.Controls.Add(this.advpwLabel1);
			this.splitContainer.Panel1.Controls.Add(jobnoLabel);
			this.splitContainer.Panel1.Controls.Add(this.jobnoLabel1);
			this.splitContainer.Panel1.Controls.Add(firstDaySchoolLabel);
			this.splitContainer.Panel1.Controls.Add(this.firstDaySchoolDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(leadnameLabel);
			this.splitContainer.Panel1.Controls.Add(this.leadnameComboBox);
			this.splitContainer.Panel1.Controls.Add(leadsourceLabel);
			this.splitContainer.Panel1.Controls.Add(this.leadsourceComboBox);
			this.splitContainer.Panel1.Controls.Add(this.isTaxExemptCheckBox);
			this.splitContainer.Panel1.Controls.Add(statusLabel);
			this.splitContainer.Panel1.Controls.Add(this.statusComboBox);
			this.splitContainer.Panel1.Controls.Add(this.electronicoptions);
			this.splitContainer.Panel1.Controls.Add(this.electronickitCheckBox);
			this.splitContainer.Panel1.Controls.Add(this.txtSchname);
			this.splitContainer.Panel1.Controls.Add(this.cmbState);
			this.splitContainer.Panel1.Controls.Add(this.oraclecodeTextBox);
			this.splitContainer.Panel1.Controls.Add(this.contryearTextBox);
			this.splitContainer.Panel1.Controls.Add(initcontLabel);
			this.splitContainer.Panel1.Controls.Add(this.initcontDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(sourdateLabel);
			this.splitContainer.Panel1.Controls.Add(this.sourdateDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(contdateLabel);
			this.splitContainer.Panel1.Controls.Add(this.contdateDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(oraclecodeLabel);
			this.splitContainer.Panel1.Controls.Add(contryearLabel);
			this.splitContainer.Panel1.Controls.Add(junsnoLabel);
			this.splitContainer.Panel1.Controls.Add(this.junsnoTextBox);
			this.splitContainer.Panel1.Controls.Add(lblEmail);
			this.splitContainer.Panel1.Controls.Add(this.txtSchColors);
			this.splitContainer.Panel1.Controls.Add(this.txtFax);
			this.splitContainer.Panel1.Controls.Add(lblFax);
			this.splitContainer.Panel1.Controls.Add(csrepLabel);
			this.splitContainer.Panel1.Controls.Add(this.txtCsRep);
			this.splitContainer.Panel1.Controls.Add(this.lblSchName);
			this.splitContainer.Panel1.Controls.Add(schoutLabel);
			this.splitContainer.Panel1.Controls.Add(this.schoutDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(schcolorsLabel);
			this.splitContainer.Panel1.Controls.Add(this.cmbSchCategory);
			this.splitContainer.Panel1.Controls.Add(this.cmbNoRebook);
			this.splitContainer.Panel1.Controls.Add(this.cmbPrevPublisher);
			this.splitContainer.Panel1.Controls.Add(lblCategory);
			this.splitContainer.Panel1.Controls.Add(this.multiyearCheckBox);
			this.splitContainer.Panel1.Controls.Add(norebookreasonLabel);
			this.splitContainer.Panel1.Controls.Add(prevpublisherLabel);
			this.splitContainer.Panel1.Controls.Add(newpublisherLabel);
			this.splitContainer.Panel1.Controls.Add(this.txtPhotographer);
			this.splitContainer.Panel1.Controls.Add(this.multiyearComboBox);
			this.splitContainer.Panel1.Controls.Add(clrpg_intLabel);
			this.splitContainer.Panel1.Controls.Add(this.clrpg_intTextBox);
			this.splitContainer.Panel1.Controls.Add(this.schuploadingCheckBox);
			this.splitContainer.Panel1.Controls.Add(this.sprinfoCheckBox);
			this.splitContainer.Panel1.Controls.Add(this.fallinfoCheckBox);
			this.splitContainer.Panel1.Controls.Add(this.clspicCheckBox);
			this.splitContainer.Panel1.Controls.Add(enrollmentLabel);
			this.splitContainer.Panel1.Controls.Add(this.springbreakTextBox);
			this.splitContainer.Panel1.Controls.Add(this.txtWebsite);
			this.splitContainer.Panel1.Controls.Add(this.btnWebsite);
			this.splitContainer.Panel1.Controls.Add(this.txtSchEmail);
			this.splitContainer.Panel1.Controls.Add(this.txtaddress);
			this.splitContainer.Panel1.Controls.Add(this.txtSchPhone);
			this.splitContainer.Panel1.Controls.Add(schphoneLabel);
			this.splitContainer.Panel1.Controls.Add(schaddrLabel);
			this.splitContainer.Panel1.Controls.Add(this.txtZip);
			this.splitContainer.Panel1.Controls.Add(schzipLabel);
			this.splitContainer.Panel1.Controls.Add(schstateLabel);
			this.splitContainer.Panel1.Controls.Add(this.txtAddress2);
			this.splitContainer.Panel1.Controls.Add(schaddr2Label);
			this.splitContainer.Panel1.Controls.Add(schcityLabel);
			this.splitContainer.Panel1.Controls.Add(this.txtCity);
			this.splitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer_Panel1_Paint);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.AutoScroll = true;
			this.splitContainer.Panel2.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer.Panel2.Controls.Add(this.btnProdTckt);
			this.splitContainer.Panel2.Controls.Add(csrep2Label);
			this.splitContainer.Panel2.Controls.Add(this.btnProdChk);
			this.splitContainer.Panel2.Controls.Add(this.csrep2TextBox);
			this.splitContainer.Panel2.Controls.Add(stageLabel);
			this.splitContainer.Panel2.Controls.Add(this.stageComboBox);
			this.splitContainer.Panel2.Controls.Add(this.dedayoutLabel2);
			this.splitContainer.Panel2.Controls.Add(this.dedayinLabel2);
			this.splitContainer.Panel2.Controls.Add(this.lblInvno);
			this.splitContainer.Panel2.Controls.Add(this.btnSchoolEmail);
			this.splitContainer.Panel2.Controls.Add(lblInterOffice);
			this.splitContainer.Panel2.Controls.Add(this.nodirectmailCheckBox);
			this.splitContainer.Panel2.Controls.Add(this.nomktemailCheckBox);
			this.splitContainer.Panel2.Controls.Add(this.custDataGridView);
			this.splitContainer.Panel2.Controls.Add(dedayoutLabel);
			this.splitContainer.Panel2.Controls.Add(dedayinLabel);
			this.splitContainer.Panel2.Controls.Add(lblBookType);
			this.splitContainer.Panel2.Controls.Add(spcinstLabel);
			this.splitContainer.Panel2.Controls.Add(this.txtBookType);
			this.splitContainer.Panel2.Controls.Add(this.label1);
			this.splitContainer.Panel2.Controls.Add(this.spcinstTextBox);
			this.splitContainer.Panel2.Controls.Add(shiptocontLabel);
			this.splitContainer.Panel2.Controls.Add(extrchgLabel);
			this.splitContainer.Panel2.Controls.Add(this.shiptocontTextBox);
			this.splitContainer.Panel2.Controls.Add(this.extrchgTextBox);
			this.splitContainer.Panel2.Controls.Add(yb_sthLabel);
			this.splitContainer.Panel2.Controls.Add(this.btnInterOffice);
			this.splitContainer.Panel2.Controls.Add(this.yb_sthTextBox);
			this.splitContainer.Panel2.Controls.Add(this.inofficeTextBox);
			this.splitContainer.Size = new System.Drawing.Size(1221, 596);
			this.splitContainer.SplitterDistance = 598;
			this.splitContainer.SplitterWidth = 2;
			this.splitContainer.TabIndex = 65;
			// 
			// enrollmentTextBox
			// 
			this.enrollmentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "enrollment", true));
			this.enrollmentTextBox.Location = new System.Drawing.Point(99, 427);
			this.enrollmentTextBox.Name = "enrollmentTextBox";
			this.enrollmentTextBox.Size = new System.Drawing.Size(80, 20);
			this.enrollmentTextBox.TabIndex = 122;
			// 
			// custBindingSource
			// 
			this.custBindingSource.DataMember = "cust";
			this.custBindingSource.DataSource = this.dsCust;
			// 
			// dsCust
			// 
			this.dsCust.DataSetName = "dsCust";
			this.dsCust.EnforceConstraints = false;
			this.dsCust.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// gradesComboBox
			// 
			this.gradesComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "grades", true));
			this.gradesComboBox.FormattingEnabled = true;
			this.gradesComboBox.Location = new System.Drawing.Point(339, 427);
			this.gradesComboBox.Name = "gradesComboBox";
			this.gradesComboBox.Size = new System.Drawing.Size(121, 21);
			this.gradesComboBox.TabIndex = 121;
			// 
			// blkwhiteCheckBox
			// 
			this.blkwhiteCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "blkwhite", true));
			this.blkwhiteCheckBox.Location = new System.Drawing.Point(393, 282);
			this.blkwhiteCheckBox.Name = "blkwhiteCheckBox";
			this.blkwhiteCheckBox.Size = new System.Drawing.Size(104, 21);
			this.blkwhiteCheckBox.TabIndex = 120;
			this.blkwhiteCheckBox.Text = "Black/White?";
			this.blkwhiteCheckBox.UseVisualStyleBackColor = true;
			// 
			// allcolorCheckBox
			// 
			this.allcolorCheckBox.AutoSize = true;
			this.allcolorCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "allcolor", true));
			this.allcolorCheckBox.Location = new System.Drawing.Point(393, 267);
			this.allcolorCheckBox.Name = "allcolorCheckBox";
			this.allcolorCheckBox.Size = new System.Drawing.Size(70, 17);
			this.allcolorCheckBox.TabIndex = 119;
			this.allcolorCheckBox.Text = "All Color?";
			this.allcolorCheckBox.UseVisualStyleBackColor = true;
			// 
			// stageComboBox1
			// 
			this.stageComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "stage", true));
			this.stageComboBox1.FormattingEnabled = true;
			this.stageComboBox1.Location = new System.Drawing.Point(99, 245);
			this.stageComboBox1.Name = "stageComboBox1";
			this.stageComboBox1.Size = new System.Drawing.Size(141, 21);
			this.stageComboBox1.TabIndex = 118;
			// 
			// taxExemptionReceivedDateTimePicker
			// 
			this.taxExemptionReceivedDateTimePicker.CustomFormat = "\'\'";
			this.taxExemptionReceivedDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.custBindingSource, "TaxExemptionReceived", true));
			this.taxExemptionReceivedDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.taxExemptionReceivedDateTimePicker.Location = new System.Drawing.Point(332, 556);
			this.taxExemptionReceivedDateTimePicker.Name = "taxExemptionReceivedDateTimePicker";
			this.taxExemptionReceivedDateTimePicker.Size = new System.Drawing.Size(85, 20);
			this.taxExemptionReceivedDateTimePicker.TabIndex = 117;
			this.taxExemptionReceivedDateTimePicker.ValueChanged += new System.EventHandler(this.taxExemptionReceivedDateTimePicker_ValueChanged);
			// 
			// notTaxExemptCheckBox
			// 
			this.notTaxExemptCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "NotTaxExempt", true));
			this.notTaxExemptCheckBox.Location = new System.Drawing.Point(413, 532);
			this.notTaxExemptCheckBox.Name = "notTaxExemptCheckBox";
			this.notTaxExemptCheckBox.Size = new System.Drawing.Size(104, 24);
			this.notTaxExemptCheckBox.TabIndex = 116;
			this.notTaxExemptCheckBox.Text = "Not Tax Exempt";
			this.notTaxExemptCheckBox.UseVisualStyleBackColor = true;
			// 
			// rbdateDateTimePicker
			// 
			this.rbdateDateTimePicker.CustomFormat = "\'\'";
			this.rbdateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.custBindingSource, "rbdate", true));
			this.rbdateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.rbdateDateTimePicker.Location = new System.Drawing.Point(332, 512);
			this.rbdateDateTimePicker.Name = "rbdateDateTimePicker";
			this.rbdateDateTimePicker.Size = new System.Drawing.Size(85, 20);
			this.rbdateDateTimePicker.TabIndex = 114;
			this.rbdateDateTimePicker.ValueChanged += new System.EventHandler(this.rbdateDateTimePicker_ValueChanged);
			// 
			// xeldateDateTimePicker
			// 
			this.xeldateDateTimePicker.CustomFormat = "\'\'";
			this.xeldateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.custBindingSource, "xeldate", true));
			this.xeldateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.xeldateDateTimePicker.Location = new System.Drawing.Point(332, 486);
			this.xeldateDateTimePicker.Name = "xeldateDateTimePicker";
			this.xeldateDateTimePicker.Size = new System.Drawing.Size(85, 20);
			this.xeldateDateTimePicker.TabIndex = 113;
			this.xeldateDateTimePicker.ValueChanged += new System.EventHandler(this.xeldateDateTimePicker_ValueChanged);
			// 
			// stfpwLabel1
			// 
			this.stfpwLabel1.AutoSize = true;
			this.stfpwLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "stfpw", true));
			this.stfpwLabel1.Location = new System.Drawing.Point(102, 531);
			this.stfpwLabel1.Name = "stfpwLabel1";
			this.stfpwLabel1.Size = new System.Drawing.Size(0, 13);
			this.stfpwLabel1.TabIndex = 112;
			// 
			// advpwLabel1
			// 
			this.advpwLabel1.AutoSize = true;
			this.advpwLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "advpw", true));
			this.advpwLabel1.Location = new System.Drawing.Point(102, 506);
			this.advpwLabel1.Name = "advpwLabel1";
			this.advpwLabel1.Size = new System.Drawing.Size(0, 13);
			this.advpwLabel1.TabIndex = 111;
			// 
			// jobnoLabel1
			// 
			this.jobnoLabel1.AutoSize = true;
			this.jobnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "jobno", true));
			this.jobnoLabel1.Location = new System.Drawing.Point(102, 483);
			this.jobnoLabel1.Name = "jobnoLabel1";
			this.jobnoLabel1.Size = new System.Drawing.Size(0, 13);
			this.jobnoLabel1.TabIndex = 110;
			// 
			// firstDaySchoolDateTimePicker
			// 
			this.firstDaySchoolDateTimePicker.CustomFormat = "\'\'";
			this.firstDaySchoolDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.custBindingSource, "FirstDaySchool", true));
			this.firstDaySchoolDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.firstDaySchoolDateTimePicker.Location = new System.Drawing.Point(245, 61);
			this.firstDaySchoolDateTimePicker.Name = "firstDaySchoolDateTimePicker";
			this.firstDaySchoolDateTimePicker.Size = new System.Drawing.Size(85, 20);
			this.firstDaySchoolDateTimePicker.TabIndex = 109;
			this.firstDaySchoolDateTimePicker.ValueChanged += new System.EventHandler(this.firstDaySchoolDateTimePicker_ValueChanged);
			// 
			// leadnameComboBox
			// 
			this.leadnameComboBox.ContextMenuStrip = this.addItemMenu;
			this.leadnameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "leadname", true));
			this.leadnameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "leadname", true));
			this.leadnameComboBox.DataSource = this.lkpLeadNameBindingSource;
			this.leadnameComboBox.DisplayMember = "Name";
			this.leadnameComboBox.FormattingEnabled = true;
			this.leadnameComboBox.Location = new System.Drawing.Point(339, 400);
			this.leadnameComboBox.Name = "leadnameComboBox";
			this.leadnameComboBox.Size = new System.Drawing.Size(197, 21);
			this.leadnameComboBox.TabIndex = 108;
			this.leadnameComboBox.ValueMember = "Name";
			this.leadnameComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leadnameComboBox_MouseDown);
			// 
			// addItemMenu
			// 
			this.addItemMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddLeadSource,
            this.AddLeadName});
			this.addItemMenu.Name = "addItemMenu";
			this.addItemMenu.Size = new System.Drawing.Size(124, 48);
			// 
			// AddLeadSource
			// 
			this.AddLeadSource.Name = "AddLeadSource";
			this.AddLeadSource.Size = new System.Drawing.Size(123, 22);
			this.AddLeadSource.Text = "Add Item";
			this.AddLeadSource.Click += new System.EventHandler(this.AddLeadSource_Click);
			// 
			// AddLeadName
			// 
			this.AddLeadName.Name = "AddLeadName";
			this.AddLeadName.Size = new System.Drawing.Size(123, 22);
			this.AddLeadName.Text = "Add Item";
			this.AddLeadName.Click += new System.EventHandler(this.AddLeadName_Click);
			// 
			// lkpLeadNameBindingSource
			// 
			this.lkpLeadNameBindingSource.DataMember = "lkpLeadName";
			this.lkpLeadNameBindingSource.DataSource = this.dsCust;
			// 
			// leadsourceComboBox
			// 
			this.leadsourceComboBox.ContextMenuStrip = this.addItemMenu;
			this.leadsourceComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "leadsource", true));
			this.leadsourceComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "leadsource", true));
			this.leadsourceComboBox.DataSource = this.lkpLeadSourceBindingSource;
			this.leadsourceComboBox.DisplayMember = "Name";
			this.leadsourceComboBox.FormattingEnabled = true;
			this.leadsourceComboBox.Location = new System.Drawing.Point(100, 400);
			this.leadsourceComboBox.Name = "leadsourceComboBox";
			this.leadsourceComboBox.Size = new System.Drawing.Size(143, 21);
			this.leadsourceComboBox.TabIndex = 107;
			this.leadsourceComboBox.ValueMember = "Name";
			this.leadsourceComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leadsourceComboBox_MouseDown);
			// 
			// lkpLeadSourceBindingSource
			// 
			this.lkpLeadSourceBindingSource.DataMember = "lkpLeadSource";
			this.lkpLeadSourceBindingSource.DataSource = this.dsCust;
			// 
			// isTaxExemptCheckBox
			// 
			this.isTaxExemptCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "IsTaxExempt", true));
			this.isTaxExemptCheckBox.Location = new System.Drawing.Point(332, 532);
			this.isTaxExemptCheckBox.Name = "isTaxExemptCheckBox";
			this.isTaxExemptCheckBox.Size = new System.Drawing.Size(104, 24);
			this.isTaxExemptCheckBox.TabIndex = 106;
			this.isTaxExemptCheckBox.Text = "Tax Exempt";
			this.isTaxExemptCheckBox.UseVisualStyleBackColor = true;
			// 
			// statusComboBox
			// 
			this.statusComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "status", true));
			this.statusComboBox.FormattingEnabled = true;
			this.statusComboBox.Items.AddRange(new object[] {
            "Prospect",
            "Renewed",
            "Deleted",
            "Canceled",
            "Unrenewed",
            "New"});
			this.statusComboBox.Location = new System.Drawing.Point(245, 34);
			this.statusComboBox.Name = "statusComboBox";
			this.statusComboBox.Size = new System.Drawing.Size(203, 21);
			this.statusComboBox.TabIndex = 104;
			// 
			// electronicoptions
			// 
			this.electronicoptions.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "electronickitoptions", true));
			this.electronicoptions.FormattingEnabled = true;
			this.electronicoptions.Items.AddRange(new object[] {
            "2018",
            "2017",
            "2016"});
			this.electronicoptions.Location = new System.Drawing.Point(99, 375);
			this.electronicoptions.Name = "electronicoptions";
			this.electronicoptions.Size = new System.Drawing.Size(141, 21);
			this.electronicoptions.TabIndex = 103;
			// 
			// electronickitCheckBox
			// 
			this.electronickitCheckBox.AutoSize = true;
			this.electronickitCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "electronickit", true));
			this.electronickitCheckBox.Location = new System.Drawing.Point(11, 375);
			this.electronickitCheckBox.Name = "electronickitCheckBox";
			this.electronickitCheckBox.Size = new System.Drawing.Size(88, 17);
			this.electronickitCheckBox.TabIndex = 102;
			this.electronickitCheckBox.Text = "Electronic Kit";
			this.electronickitCheckBox.UseVisualStyleBackColor = true;
			// 
			// txtSchname
			// 
			this.txtSchname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schname", true));
			this.txtSchname.Location = new System.Drawing.Point(92, 102);
			this.txtSchname.Name = "txtSchname";
			this.txtSchname.ReadOnly = true;
			this.txtSchname.Size = new System.Drawing.Size(325, 20);
			this.txtSchname.TabIndex = 101;
			this.txtSchname.DoubleClick += new System.EventHandler(this.txtSchname_DoubleClick_1);
			// 
			// cmbState
			// 
			this.cmbState.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "schstate", true));
			this.cmbState.DataSource = this.statesBindingSource;
			this.cmbState.DisplayMember = "Name";
			this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbState.FormattingEnabled = true;
			this.cmbState.Location = new System.Drawing.Point(308, 152);
			this.cmbState.Name = "cmbState";
			this.cmbState.Size = new System.Drawing.Size(208, 21);
			this.cmbState.TabIndex = 100;
			this.cmbState.ValueMember = "Abrev";
			// 
			// statesBindingSource
			// 
			this.statesBindingSource.DataMember = "states";
			this.statesBindingSource.DataSource = this.lookUp;
			// 
			// lookUp
			// 
			this.lookUp.DataSetName = "LookUp";
			this.lookUp.EnforceConstraints = false;
			this.lookUp.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// oraclecodeTextBox
			// 
			this.oraclecodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "oraclecode", true));
			this.oraclecodeTextBox.Location = new System.Drawing.Point(369, 8);
			this.oraclecodeTextBox.Name = "oraclecodeTextBox";
			this.oraclecodeTextBox.Size = new System.Drawing.Size(100, 20);
			this.oraclecodeTextBox.TabIndex = 94;
			// 
			// contryearTextBox
			// 
			this.contryearTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contryear", true));
			this.contryearTextBox.Location = new System.Drawing.Point(547, 9);
			this.contryearTextBox.Name = "contryearTextBox";
			this.contryearTextBox.Size = new System.Drawing.Size(49, 20);
			this.contryearTextBox.TabIndex = 99;
			// 
			// initcontDateTimePicker
			// 
			this.initcontDateTimePicker.CustomFormat = "\'\'";
			this.initcontDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.custBindingSource, "initcont", true));
			this.initcontDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.initcontDateTimePicker.Location = new System.Drawing.Point(103, 31);
			this.initcontDateTimePicker.Name = "initcontDateTimePicker";
			this.initcontDateTimePicker.Size = new System.Drawing.Size(85, 20);
			this.initcontDateTimePicker.TabIndex = 98;
			this.initcontDateTimePicker.ValueChanged += new System.EventHandler(this.initcontDateTimePicker_ValueChanged);
			// 
			// sourdateDateTimePicker
			// 
			this.sourdateDateTimePicker.CustomFormat = "\'\'";
			this.sourdateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.custBindingSource, "sourdate", true));
			this.sourdateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.sourdateDateTimePicker.Location = new System.Drawing.Point(103, 55);
			this.sourdateDateTimePicker.Name = "sourdateDateTimePicker";
			this.sourdateDateTimePicker.Size = new System.Drawing.Size(85, 20);
			this.sourdateDateTimePicker.TabIndex = 97;
			this.sourdateDateTimePicker.ValueChanged += new System.EventHandler(this.sourdateDateTimePicker_ValueChanged);
			// 
			// contdateDateTimePicker
			// 
			this.contdateDateTimePicker.CustomFormat = "\'\'";
			this.contdateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.custBindingSource, "contdate", true));
			this.contdateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.contdateDateTimePicker.Location = new System.Drawing.Point(103, 78);
			this.contdateDateTimePicker.Name = "contdateDateTimePicker";
			this.contdateDateTimePicker.Size = new System.Drawing.Size(85, 20);
			this.contdateDateTimePicker.TabIndex = 95;
			this.contdateDateTimePicker.CloseUp += new System.EventHandler(this.contdateDateTimePicker_CloseUp);
			this.contdateDateTimePicker.ValueChanged += new System.EventHandler(this.contdateDateTimePicker_ValueChanged_1);
			// 
			// junsnoTextBox
			// 
			this.junsnoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "junsno", true));
			this.junsnoTextBox.Location = new System.Drawing.Point(192, 5);
			this.junsnoTextBox.MaxLength = 10;
			this.junsnoTextBox.Name = "junsnoTextBox";
			this.junsnoTextBox.Size = new System.Drawing.Size(100, 20);
			this.junsnoTextBox.TabIndex = 4;
			// 
			// txtSchColors
			// 
			this.txtSchColors.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schcolors", true));
			this.txtSchColors.Location = new System.Drawing.Point(339, 375);
			this.txtSchColors.Name = "txtSchColors";
			this.txtSchColors.Size = new System.Drawing.Size(197, 20);
			this.txtSchColors.TabIndex = 28;
			// 
			// txtFax
			// 
			this.txtFax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schfax", true));
			this.txtFax.Location = new System.Drawing.Point(420, 182);
			this.txtFax.MaxLength = 25;
			this.txtFax.Name = "txtFax";
			this.txtFax.Size = new System.Drawing.Size(95, 20);
			this.txtFax.TabIndex = 8;
			// 
			// txtCsRep
			// 
			this.txtCsRep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCsRep.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "csrep", true));
			this.txtCsRep.Location = new System.Drawing.Point(72, 5);
			this.txtCsRep.MaxLength = 3;
			this.txtCsRep.Name = "txtCsRep";
			this.txtCsRep.Size = new System.Drawing.Size(54, 20);
			this.txtCsRep.TabIndex = 2;
			// 
			// lblSchName
			// 
			this.lblSchName.AutoSize = true;
			this.lblSchName.Location = new System.Drawing.Point(10, 102);
			this.lblSchName.Name = "lblSchName";
			this.lblSchName.Size = new System.Drawing.Size(74, 13);
			this.lblSchName.TabIndex = 86;
			this.lblSchName.Text = "School Name:";
			// 
			// schoutDateTimePicker
			// 
			this.schoutDateTimePicker.CustomFormat = "\'\'";
			this.schoutDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.custBindingSource, "schout", true));
			this.schoutDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.schoutDateTimePicker.Location = new System.Drawing.Point(392, 61);
			this.schoutDateTimePicker.Name = "schoutDateTimePicker";
			this.schoutDateTimePicker.Size = new System.Drawing.Size(85, 20);
			this.schoutDateTimePicker.TabIndex = 18;
			this.schoutDateTimePicker.ValueChanged += new System.EventHandler(this.schoutDateTimePicker_ValueChanged);
			// 
			// cmbSchCategory
			// 
			this.cmbSchCategory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "sal", true));
			this.cmbSchCategory.DataSource = this.lkpschtypeBindingSource;
			this.cmbSchCategory.DisplayMember = "Type";
			this.cmbSchCategory.FormattingEnabled = true;
			this.cmbSchCategory.Location = new System.Drawing.Point(339, 351);
			this.cmbSchCategory.Name = "cmbSchCategory";
			this.cmbSchCategory.Size = new System.Drawing.Size(197, 21);
			this.cmbSchCategory.TabIndex = 25;
			// 
			// lkpschtypeBindingSource
			// 
			this.lkpschtypeBindingSource.DataMember = "lkpschtype";
			this.lkpschtypeBindingSource.DataSource = this.lookUp;
			// 
			// cmbNoRebook
			// 
			this.cmbNoRebook.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "norebookreason", true));
			this.cmbNoRebook.DataSource = this.lkpNoRebookBindingSource;
			this.cmbNoRebook.DisplayMember = "descripiton";
			this.cmbNoRebook.FormattingEnabled = true;
			this.cmbNoRebook.Location = new System.Drawing.Point(99, 297);
			this.cmbNoRebook.Name = "cmbNoRebook";
			this.cmbNoRebook.Size = new System.Drawing.Size(141, 21);
			this.cmbNoRebook.TabIndex = 13;
			// 
			// lkpNoRebookBindingSource
			// 
			this.lkpNoRebookBindingSource.DataMember = "lkpNoRebook";
			this.lkpNoRebookBindingSource.DataSource = this.lookUp;
			// 
			// cmbPrevPublisher
			// 
			this.cmbPrevPublisher.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "prevpublisher", true));
			this.cmbPrevPublisher.DataSource = this.lkpPrevPubBindingSource;
			this.cmbPrevPublisher.DisplayMember = "Name";
			this.cmbPrevPublisher.FormattingEnabled = true;
			this.cmbPrevPublisher.Location = new System.Drawing.Point(99, 325);
			this.cmbPrevPublisher.Name = "cmbPrevPublisher";
			this.cmbPrevPublisher.Size = new System.Drawing.Size(141, 21);
			this.cmbPrevPublisher.TabIndex = 17;
			// 
			// lkpPrevPubBindingSource
			// 
			this.lkpPrevPubBindingSource.DataMember = "lkpPrevPub";
			this.lkpPrevPubBindingSource.DataSource = this.lookUp;
			// 
			// multiyearCheckBox
			// 
			this.multiyearCheckBox.AutoSize = true;
			this.multiyearCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "multiyear", true));
			this.multiyearCheckBox.Location = new System.Drawing.Point(29, 351);
			this.multiyearCheckBox.Name = "multiyearCheckBox";
			this.multiyearCheckBox.Size = new System.Drawing.Size(70, 17);
			this.multiyearCheckBox.TabIndex = 26;
			this.multiyearCheckBox.Text = "MultiYear";
			this.multiyearCheckBox.UseVisualStyleBackColor = true;
			// 
			// txtPhotographer
			// 
			this.txtPhotographer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "photographer", true));
			this.txtPhotographer.Location = new System.Drawing.Point(339, 325);
			this.txtPhotographer.MaxLength = 45;
			this.txtPhotographer.Name = "txtPhotographer";
			this.txtPhotographer.Size = new System.Drawing.Size(197, 20);
			this.txtPhotographer.TabIndex = 21;
			// 
			// multiyearComboBox
			// 
			this.multiyearComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "multiyear", true));
			this.multiyearComboBox.DataSource = this.lkpMultiYearOptionsBindingSource;
			this.multiyearComboBox.DisplayMember = "Name";
			this.multiyearComboBox.FormattingEnabled = true;
			this.multiyearComboBox.Location = new System.Drawing.Point(99, 351);
			this.multiyearComboBox.Name = "multiyearComboBox";
			this.multiyearComboBox.Size = new System.Drawing.Size(141, 21);
			this.multiyearComboBox.TabIndex = 20;
			// 
			// lkpMultiYearOptionsBindingSource
			// 
			this.lkpMultiYearOptionsBindingSource.DataMember = "lkpMultiYearOptions";
			this.lkpMultiYearOptionsBindingSource.DataSource = this.lookUp;
			// 
			// clrpg_intTextBox
			// 
			this.clrpg_intTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "clrpg_int", true));
			this.clrpg_intTextBox.Location = new System.Drawing.Point(393, 303);
			this.clrpg_intTextBox.MaxLength = 1;
			this.clrpg_intTextBox.Name = "clrpg_intTextBox";
			this.clrpg_intTextBox.Size = new System.Drawing.Size(29, 20);
			this.clrpg_intTextBox.TabIndex = 19;
			// 
			// schuploadingCheckBox
			// 
			this.schuploadingCheckBox.AutoSize = true;
			this.schuploadingCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "schuploading", true));
			this.schuploadingCheckBox.Location = new System.Drawing.Point(395, 246);
			this.schuploadingCheckBox.Name = "schuploadingCheckBox";
			this.schuploadingCheckBox.Size = new System.Drawing.Size(121, 17);
			this.schuploadingCheckBox.TabIndex = 16;
			this.schuploadingCheckBox.Text = "School Is Uploading";
			this.schuploadingCheckBox.UseVisualStyleBackColor = true;
			// 
			// sprinfoCheckBox
			// 
			this.sprinfoCheckBox.AutoSize = true;
			this.sprinfoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "sprinfo", true));
			this.sprinfoCheckBox.Location = new System.Drawing.Point(279, 282);
			this.sprinfoCheckBox.Name = "sprinfoCheckBox";
			this.sprinfoCheckBox.Size = new System.Drawing.Size(71, 17);
			this.sprinfoCheckBox.TabIndex = 18;
			this.sprinfoCheckBox.Text = "CP online";
			this.sprinfoCheckBox.UseVisualStyleBackColor = true;
			// 
			// fallinfoCheckBox
			// 
			this.fallinfoCheckBox.AutoSize = true;
			this.fallinfoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "fallinfo", true));
			this.fallinfoCheckBox.Location = new System.Drawing.Point(279, 266);
			this.fallinfoCheckBox.Name = "fallinfoCheckBox";
			this.fallinfoCheckBox.Size = new System.Drawing.Size(93, 17);
			this.fallinfoCheckBox.TabIndex = 14;
			this.fallinfoCheckBox.Text = "CP Alternative";
			this.fallinfoCheckBox.UseVisualStyleBackColor = true;
			// 
			// clspicCheckBox
			// 
			this.clspicCheckBox.AutoSize = true;
			this.clspicCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "clspic", true));
			this.clspicCheckBox.Location = new System.Drawing.Point(279, 246);
			this.clspicCheckBox.Name = "clspicCheckBox";
			this.clspicCheckBox.Size = new System.Drawing.Size(109, 17);
			this.clspicCheckBox.TabIndex = 10;
			this.clspicCheckBox.Text = "Class Pic\'s on CD";
			this.clspicCheckBox.UseVisualStyleBackColor = true;
			// 
			// springbreakTextBox
			// 
			this.springbreakTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "sprngbrk", true));
			this.springbreakTextBox.Location = new System.Drawing.Point(99, 272);
			this.springbreakTextBox.MaxLength = 25;
			this.springbreakTextBox.Name = "springbreakTextBox";
			this.springbreakTextBox.Size = new System.Drawing.Size(141, 20);
			this.springbreakTextBox.TabIndex = 11;
			// 
			// txtWebsite
			// 
			this.txtWebsite.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "website", true));
			this.txtWebsite.Location = new System.Drawing.Point(366, 208);
			this.txtWebsite.MaxLength = 60;
			this.txtWebsite.Name = "txtWebsite";
			this.txtWebsite.Size = new System.Drawing.Size(188, 20);
			this.txtWebsite.TabIndex = 10;
			// 
			// btnWebsite
			// 
			this.btnWebsite.AutoSize = true;
			this.btnWebsite.Location = new System.Drawing.Point(285, 206);
			this.btnWebsite.Name = "btnWebsite";
			this.btnWebsite.Size = new System.Drawing.Size(80, 23);
			this.btnWebsite.TabIndex = 7;
			this.btnWebsite.Text = "Website";
			this.btnWebsite.UseVisualStyleBackColor = true;
			this.btnWebsite.Click += new System.EventHandler(this.btnWebsite_Click_1);
			// 
			// txtSchEmail
			// 
			this.txtSchEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schemail", true));
			this.txtSchEmail.Location = new System.Drawing.Point(91, 207);
			this.txtSchEmail.MaxLength = 80;
			this.txtSchEmail.Name = "txtSchEmail";
			this.txtSchEmail.Size = new System.Drawing.Size(188, 20);
			this.txtSchEmail.TabIndex = 9;
			// 
			// txtaddress
			// 
			this.txtaddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schaddr", true));
			this.txtaddress.Location = new System.Drawing.Point(57, 129);
			this.txtaddress.MaxLength = 35;
			this.txtaddress.Name = "txtaddress";
			this.txtaddress.Size = new System.Drawing.Size(183, 20);
			this.txtaddress.TabIndex = 3;
			// 
			// txtSchPhone
			// 
			this.txtSchPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schphone", true));
			this.txtSchPhone.Location = new System.Drawing.Point(245, 181);
			this.txtSchPhone.MaxLength = 25;
			this.txtSchPhone.Name = "txtSchPhone";
			this.txtSchPhone.Size = new System.Drawing.Size(95, 20);
			this.txtSchPhone.TabIndex = 7;
			// 
			// txtZip
			// 
			this.txtZip.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schzip", true));
			this.txtZip.Location = new System.Drawing.Point(57, 181);
			this.txtZip.MaxLength = 10;
			this.txtZip.Name = "txtZip";
			this.txtZip.Size = new System.Drawing.Size(45, 20);
			this.txtZip.TabIndex = 41;
			// 
			// txtAddress2
			// 
			this.txtAddress2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schaddr2", true));
			this.txtAddress2.Location = new System.Drawing.Point(308, 129);
			this.txtAddress2.MaxLength = 35;
			this.txtAddress2.Name = "txtAddress2";
			this.txtAddress2.Size = new System.Drawing.Size(207, 20);
			this.txtAddress2.TabIndex = 4;
			// 
			// txtCity
			// 
			this.txtCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schcity", true));
			this.txtCity.Location = new System.Drawing.Point(57, 155);
			this.txtCity.MaxLength = 21;
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(183, 20);
			this.txtCity.TabIndex = 5;
			// 
			// btnProdTckt
			// 
			this.btnProdTckt.Location = new System.Drawing.Point(487, 286);
			this.btnProdTckt.Name = "btnProdTckt";
			this.btnProdTckt.Size = new System.Drawing.Size(123, 23);
			this.btnProdTckt.TabIndex = 111;
			this.btnProdTckt.Text = "Production Ticket";
			this.btnProdTckt.UseVisualStyleBackColor = true;
			this.btnProdTckt.Click += new System.EventHandler(this.btnProdTckt_Click);
			// 
			// btnProdChk
			// 
			this.btnProdChk.Location = new System.Drawing.Point(515, 315);
			this.btnProdChk.Name = "btnProdChk";
			this.btnProdChk.Size = new System.Drawing.Size(95, 23);
			this.btnProdChk.TabIndex = 47;
			this.btnProdChk.Text = "Prod Chk List";
			this.btnProdChk.UseVisualStyleBackColor = true;
			this.btnProdChk.Click += new System.EventHandler(this.btnProdChk_Click);
			// 
			// csrep2TextBox
			// 
			this.csrep2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "csrep2", true));
			this.csrep2TextBox.Location = new System.Drawing.Point(72, 5);
			this.csrep2TextBox.Name = "csrep2TextBox";
			this.csrep2TextBox.Size = new System.Drawing.Size(55, 20);
			this.csrep2TextBox.TabIndex = 110;
			// 
			// stageComboBox
			// 
			this.stageComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "stage", true));
			this.stageComboBox.FormattingEnabled = true;
			this.stageComboBox.Items.AddRange(new object[] {
            "Qualify",
            "Discover",
            "Advance",
            "Close",
            "Submitted",
            "Lost"});
			this.stageComboBox.Location = new System.Drawing.Point(144, 93);
			this.stageComboBox.Name = "stageComboBox";
			this.stageComboBox.Size = new System.Drawing.Size(172, 21);
			this.stageComboBox.TabIndex = 46;
			// 
			// dedayoutLabel2
			// 
			this.dedayoutLabel2.AutoSize = true;
			this.dedayoutLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "dedayout", true));
			this.dedayoutLabel2.Location = new System.Drawing.Point(186, 69);
			this.dedayoutLabel2.Name = "dedayoutLabel2";
			this.dedayoutLabel2.Size = new System.Drawing.Size(0, 13);
			this.dedayoutLabel2.TabIndex = 45;
			// 
			// dedayinLabel2
			// 
			this.dedayinLabel2.AutoSize = true;
			this.dedayinLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "dedayin", true));
			this.dedayinLabel2.Location = new System.Drawing.Point(186, 46);
			this.dedayinLabel2.Name = "dedayinLabel2";
			this.dedayinLabel2.Size = new System.Drawing.Size(0, 13);
			this.dedayinLabel2.TabIndex = 44;
			// 
			// lblInvno
			// 
			this.lblInvno.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "QInvno", true));
			this.lblInvno.ForeColor = System.Drawing.SystemColors.Control;
			this.lblInvno.Location = new System.Drawing.Point(25, 323);
			this.lblInvno.Name = "lblInvno";
			this.lblInvno.Size = new System.Drawing.Size(50, 15);
			this.lblInvno.TabIndex = 15;
			this.lblInvno.Text = "label29";
			this.lblInvno.TextChanged += new System.EventHandler(this.lblInvno_TextChanged);
			// 
			// btnSchoolEmail
			// 
			this.btnSchoolEmail.AutoSize = true;
			this.btnSchoolEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnSchoolEmail.Image")));
			this.btnSchoolEmail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnSchoolEmail.Location = new System.Drawing.Point(411, 46);
			this.btnSchoolEmail.Name = "btnSchoolEmail";
			this.btnSchoolEmail.Size = new System.Drawing.Size(94, 43);
			this.btnSchoolEmail.TabIndex = 4;
			this.btnSchoolEmail.Text = "Email To School";
			this.btnSchoolEmail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnSchoolEmail.UseVisualStyleBackColor = true;
			this.btnSchoolEmail.Click += new System.EventHandler(this.btnSchoolEmail_Click);
			// 
			// nodirectmailCheckBox
			// 
			this.nodirectmailCheckBox.AutoSize = true;
			this.nodirectmailCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "nodirectmail", true));
			this.nodirectmailCheckBox.Location = new System.Drawing.Point(354, 5);
			this.nodirectmailCheckBox.Name = "nodirectmailCheckBox";
			this.nodirectmailCheckBox.Size = new System.Drawing.Size(93, 17);
			this.nodirectmailCheckBox.TabIndex = 0;
			this.nodirectmailCheckBox.Text = "No Direct Mail";
			this.nodirectmailCheckBox.UseVisualStyleBackColor = true;
			// 
			// nomktemailCheckBox
			// 
			this.nomktemailCheckBox.AutoSize = true;
			this.nomktemailCheckBox.Checked = true;
			this.nomktemailCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nomktemailCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "nomktemail", true));
			this.nomktemailCheckBox.Location = new System.Drawing.Point(225, 5);
			this.nomktemailCheckBox.Name = "nomktemailCheckBox";
			this.nomktemailCheckBox.Size = new System.Drawing.Size(118, 17);
			this.nomktemailCheckBox.TabIndex = 0;
			this.nomktemailCheckBox.Text = "No Marketing Email";
			this.nomktemailCheckBox.UseVisualStyleBackColor = true;
			// 
			// custDataGridView
			// 
			this.custDataGridView.AllowUserToAddRows = false;
			this.custDataGridView.AllowUserToDeleteRows = false;
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
            this.dataGridViewTextBoxColumn105,
            this.qcontractyear,
            this.QInvno,
            this.dataGridViewTextBoxColumn108,
            this.dataGridViewTextBoxColumn111});
			this.custDataGridView.DataSource = this.custBindingSource;
			this.custDataGridView.EnableHeadersVisualStyles = false;
			this.custDataGridView.Location = new System.Drawing.Point(14, 345);
			this.custDataGridView.Name = "custDataGridView";
			this.custDataGridView.ReadOnly = true;
			this.custDataGridView.Size = new System.Drawing.Size(596, 220);
			this.custDataGridView.TabIndex = 5;
			this.custDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.custDataGridView_CellDoubleClick);
			this.custDataGridView.Enter += new System.EventHandler(this.custDataGridView_Enter);
			this.custDataGridView.Leave += new System.EventHandler(this.custDataGridView_Leave);
			// 
			// dataGridViewTextBoxColumn105
			// 
			this.dataGridViewTextBoxColumn105.DataPropertyName = "booktype";
			this.dataGridViewTextBoxColumn105.HeaderText = "Book Type";
			this.dataGridViewTextBoxColumn105.Name = "dataGridViewTextBoxColumn105";
			this.dataGridViewTextBoxColumn105.ReadOnly = true;
			// 
			// qcontractyear
			// 
			this.qcontractyear.DataPropertyName = "Qyear";
			this.qcontractyear.HeaderText = "Year";
			this.qcontractyear.Name = "qcontractyear";
			this.qcontractyear.ReadOnly = true;
			// 
			// QInvno
			// 
			this.QInvno.DataPropertyName = "QInvno";
			this.QInvno.HeaderText = "Invoice#";
			this.QInvno.Name = "QInvno";
			this.QInvno.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn108
			// 
			this.dataGridViewTextBoxColumn108.DataPropertyName = "prodno";
			this.dataGridViewTextBoxColumn108.HeaderText = "Prod No#";
			this.dataGridViewTextBoxColumn108.Name = "dataGridViewTextBoxColumn108";
			this.dataGridViewTextBoxColumn108.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn111
			// 
			this.dataGridViewTextBoxColumn111.DataPropertyName = "kitrecvd";
			dataGridViewCellStyle2.Format = "d";
			dataGridViewCellStyle2.NullValue = null;
			this.dataGridViewTextBoxColumn111.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewTextBoxColumn111.HeaderText = "Kit Recvd Date";
			this.dataGridViewTextBoxColumn111.Name = "dataGridViewTextBoxColumn111";
			this.dataGridViewTextBoxColumn111.ReadOnly = true;
			// 
			// txtBookType
			// 
			this.txtBookType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "booktype", true));
			this.txtBookType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBookType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.txtBookType.Location = new System.Drawing.Point(537, 5);
			this.txtBookType.MaxLength = 4;
			this.txtBookType.Name = "txtBookType";
			this.txtBookType.ReadOnly = true;
			this.txtBookType.Size = new System.Drawing.Size(57, 20);
			this.txtBookType.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Ship to Home?";
			// 
			// spcinstTextBox
			// 
			this.spcinstTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "spcinst", true));
			this.spcinstTextBox.Location = new System.Drawing.Point(106, 260);
			this.spcinstTextBox.Multiline = true;
			this.spcinstTextBox.Name = "spcinstTextBox";
			this.spcinstTextBox.Size = new System.Drawing.Size(341, 58);
			this.spcinstTextBox.TabIndex = 31;
			// 
			// shiptocontTextBox
			// 
			this.shiptocontTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.shiptocontTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "shiptocont", true));
			this.shiptocontTextBox.Location = new System.Drawing.Point(51, 92);
			this.shiptocontTextBox.MaxLength = 1;
			this.shiptocontTextBox.Name = "shiptocontTextBox";
			this.shiptocontTextBox.Size = new System.Drawing.Size(31, 20);
			this.shiptocontTextBox.TabIndex = 14;
			// 
			// extrchgTextBox
			// 
			this.extrchgTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "extrchg", true));
			this.extrchgTextBox.Location = new System.Drawing.Point(107, 193);
			this.extrchgTextBox.Multiline = true;
			this.extrchgTextBox.Name = "extrchgTextBox";
			this.extrchgTextBox.Size = new System.Drawing.Size(341, 58);
			this.extrchgTextBox.TabIndex = 30;
			// 
			// btnInterOffice
			// 
			this.btnInterOffice.AutoSize = true;
			this.btnInterOffice.Image = ((System.Drawing.Image)(resources.GetObject("btnInterOffice.Image")));
			this.btnInterOffice.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnInterOffice.Location = new System.Drawing.Point(446, 120);
			this.btnInterOffice.Name = "btnInterOffice";
			this.btnInterOffice.Size = new System.Drawing.Size(36, 25);
			this.btnInterOffice.TabIndex = 40;
			this.btnInterOffice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnInterOffice.UseVisualStyleBackColor = true;
			this.btnInterOffice.Click += new System.EventHandler(this.btnInterOffice_Click);
			// 
			// yb_sthTextBox
			// 
			this.yb_sthTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.yb_sthTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "yb_sth", true));
			this.yb_sthTextBox.Location = new System.Drawing.Point(51, 67);
			this.yb_sthTextBox.MaxLength = 1;
			this.yb_sthTextBox.Name = "yb_sthTextBox";
			this.yb_sthTextBox.Size = new System.Drawing.Size(31, 20);
			this.yb_sthTextBox.TabIndex = 10;
			// 
			// inofficeTextBox
			// 
			this.inofficeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "inoffice", true));
			this.inofficeTextBox.Location = new System.Drawing.Point(108, 120);
			this.inofficeTextBox.Multiline = true;
			this.inofficeTextBox.Name = "inofficeTextBox";
			this.inofficeTextBox.Size = new System.Drawing.Size(338, 62);
			this.inofficeTextBox.TabIndex = 29;
			// 
			// pnlHead
			// 
			this.pnlHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlHead.Controls.Add(this.btnNewCustomer);
			this.pnlHead.Controls.Add(this.lblSchcodeVal);
			this.pnlHead.Location = new System.Drawing.Point(0, 0);
			this.pnlHead.Name = "pnlHead";
			this.pnlHead.Size = new System.Drawing.Size(1226, 30);
			this.pnlHead.TabIndex = 64;
			// 
			// btnNewCustomer
			// 
			this.btnNewCustomer.AutoSize = true;
			this.btnNewCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnNewCustomer.Image")));
			this.btnNewCustomer.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.btnNewCustomer.Location = new System.Drawing.Point(1060, 3);
			this.btnNewCustomer.Name = "btnNewCustomer";
			this.btnNewCustomer.Size = new System.Drawing.Size(159, 23);
			this.btnNewCustomer.TabIndex = 9;
			this.btnNewCustomer.Text = "New Customer Email";
			this.btnNewCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnNewCustomer.UseVisualStyleBackColor = true;
			this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
			// 
			// lblSchcodeVal
			// 
			this.lblSchcodeVal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schcode", true));
			this.lblSchcodeVal.Location = new System.Drawing.Point(980, 6);
			this.lblSchcodeVal.Name = "lblSchcodeVal";
			this.lblSchcodeVal.Size = new System.Drawing.Size(1, 1);
			this.lblSchcodeVal.TabIndex = 105;
			this.lblSchcodeVal.Text = "label29";
			// 
			// pg2
			// 
			this.pg2.BackColor = System.Drawing.SystemColors.Control;
			this.pg2.Controls.Add(ccontcityLabel);
			this.pg2.Controls.Add(this.ccontcityTextBox);
			this.pg2.Controls.Add(bcontcityLabel);
			this.pg2.Controls.Add(this.bcontcityTextBox);
			this.pg2.Controls.Add(contcityLabel);
			this.pg2.Controls.Add(this.contcityTextBox);
			this.pg2.Controls.Add(this.comboBox5);
			this.pg2.Controls.Add(this.comboBox6);
			this.pg2.Controls.Add(label2);
			this.pg2.Controls.Add(label18);
			this.pg2.Controls.Add(this.textBox3);
			this.pg2.Controls.Add(label19);
			this.pg2.Controls.Add(this.textBox4);
			this.pg2.Controls.Add(label24);
			this.pg2.Controls.Add(this.textBox10);
			this.pg2.Controls.Add(label29);
			this.pg2.Controls.Add(this.textBox12);
			this.pg2.Controls.Add(label30);
			this.pg2.Controls.Add(this.textBox13);
			this.pg2.Controls.Add(label31);
			this.pg2.Controls.Add(this.textBox14);
			this.pg2.Controls.Add(label32);
			this.pg2.Controls.Add(label33);
			this.pg2.Controls.Add(this.textBox15);
			this.pg2.Controls.Add(label34);
			this.pg2.Controls.Add(this.textBox16);
			this.pg2.Controls.Add(label26);
			this.pg2.Controls.Add(this.txtContact3Email);
			this.pg2.Controls.Add(this.btnEmailContac3);
			this.pg2.Controls.Add(this.label16);
			this.pg2.Controls.Add(this.btnEmailCont2);
			this.pg2.Controls.Add(this.label15);
			this.pg2.Controls.Add(this.comboBox3);
			this.pg2.Controls.Add(this.comboBox4);
			this.pg2.Controls.Add(label3);
			this.pg2.Controls.Add(label4);
			this.pg2.Controls.Add(this.textBox1);
			this.pg2.Controls.Add(label5);
			this.pg2.Controls.Add(this.textBox2);
			this.pg2.Controls.Add(label6);
			this.pg2.Controls.Add(this.txtBContFname);
			this.pg2.Controls.Add(label7);
			this.pg2.Controls.Add(this.txtContact2Email);
			this.pg2.Controls.Add(label8);
			this.pg2.Controls.Add(this.textBox5);
			this.pg2.Controls.Add(label9);
			this.pg2.Controls.Add(this.textBox6);
			this.pg2.Controls.Add(label10);
			this.pg2.Controls.Add(this.textBox7);
			this.pg2.Controls.Add(label11);
			this.pg2.Controls.Add(label12);
			this.pg2.Controls.Add(this.textBox8);
			this.pg2.Controls.Add(label13);
			this.pg2.Controls.Add(this.textBox9);
			this.pg2.Controls.Add(this.label17);
			this.pg2.Controls.Add(this.btnEmailContact);
			this.pg2.Controls.Add(this.label28);
			this.pg2.Controls.Add(this.label14);
			this.pg2.Controls.Add(this.lblSeperator1);
			this.pg2.Controls.Add(this.comboBox2);
			this.pg2.Controls.Add(this.comboBox1);
			this.pg2.Controls.Add(positionLabel);
			this.pg2.Controls.Add(contphnhomLabel);
			this.pg2.Controls.Add(this.contphnhomTextBox);
			this.pg2.Controls.Add(contlnameLabel);
			this.pg2.Controls.Add(this.contlnameTextBox);
			this.pg2.Controls.Add(contfnameLabel);
			this.pg2.Controls.Add(this.contfnameTextBox);
			this.pg2.Controls.Add(contemailLabel);
			this.pg2.Controls.Add(this.txtContactEmail);
			this.pg2.Controls.Add(contfaxLabel);
			this.pg2.Controls.Add(this.contfaxTextBox);
			this.pg2.Controls.Add(contphnwrkLabel);
			this.pg2.Controls.Add(this.contphnwrkTextBox);
			this.pg2.Controls.Add(contzipLabel);
			this.pg2.Controls.Add(this.contzipTextBox);
			this.pg2.Controls.Add(contstateLabel);
			this.pg2.Controls.Add(contaddr2Label);
			this.pg2.Controls.Add(this.contaddr2TextBox);
			this.pg2.Controls.Add(contaddrLabel);
			this.pg2.Controls.Add(this.contaddrTextBox);
			this.pg2.Location = new System.Drawing.Point(4, 22);
			this.pg2.Name = "pg2";
			this.pg2.Padding = new System.Windows.Forms.Padding(3);
			this.pg2.Size = new System.Drawing.Size(1226, 644);
			this.pg2.TabIndex = 1;
			this.pg2.Text = "Contacts";
			// 
			// ccontcityTextBox
			// 
			this.ccontcityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "ccontcity", true));
			this.ccontcityTextBox.Location = new System.Drawing.Point(91, 487);
			this.ccontcityTextBox.Name = "ccontcityTextBox";
			this.ccontcityTextBox.Size = new System.Drawing.Size(232, 20);
			this.ccontcityTextBox.TabIndex = 251;
			// 
			// bcontcityTextBox
			// 
			this.bcontcityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontcity", true));
			this.bcontcityTextBox.Location = new System.Drawing.Point(91, 289);
			this.bcontcityTextBox.Name = "bcontcityTextBox";
			this.bcontcityTextBox.Size = new System.Drawing.Size(232, 20);
			this.bcontcityTextBox.TabIndex = 250;
			// 
			// contcityTextBox
			// 
			this.contcityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contcity", true));
			this.contcityTextBox.Location = new System.Drawing.Point(91, 79);
			this.contcityTextBox.Name = "contcityTextBox";
			this.contcityTextBox.Size = new System.Drawing.Size(232, 20);
			this.contcityTextBox.TabIndex = 249;
			// 
			// comboBox5
			// 
			this.comboBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox5.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "cposition", true));
			this.comboBox5.DataSource = this.contpstnBindingSource2;
			this.comboBox5.DisplayMember = "Position";
			this.comboBox5.FormattingEnabled = true;
			this.comboBox5.Location = new System.Drawing.Point(91, 570);
			this.comboBox5.Name = "comboBox5";
			this.comboBox5.Size = new System.Drawing.Size(232, 21);
			this.comboBox5.TabIndex = 238;
			this.comboBox5.ValueMember = "Position";
			// 
			// contpstnBindingSource2
			// 
			this.contpstnBindingSource2.DataMember = "contpstn";
			this.contpstnBindingSource2.DataSource = this.lookUp;
			// 
			// comboBox6
			// 
			this.comboBox6.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "ccontstate", true));
			this.comboBox6.DataSource = this.statesBindingSource2;
			this.comboBox6.DisplayMember = "Name";
			this.comboBox6.FormattingEnabled = true;
			this.comboBox6.Location = new System.Drawing.Point(91, 514);
			this.comboBox6.Name = "comboBox6";
			this.comboBox6.Size = new System.Drawing.Size(232, 21);
			this.comboBox6.TabIndex = 233;
			this.comboBox6.ValueMember = "Abrev";
			// 
			// statesBindingSource2
			// 
			this.statesBindingSource2.DataMember = "states";
			this.statesBindingSource2.DataSource = this.lookUp;
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "ccontphnhom", true));
			this.textBox3.Location = new System.Drawing.Point(429, 517);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(232, 20);
			this.textBox3.TabIndex = 236;
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "ccontlname", true));
			this.textBox4.Location = new System.Drawing.Point(429, 438);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(232, 20);
			this.textBox4.TabIndex = 230;
			// 
			// textBox10
			// 
			this.textBox10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "ccontfname", true));
			this.textBox10.Location = new System.Drawing.Point(91, 437);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(232, 20);
			this.textBox10.TabIndex = 229;
			// 
			// textBox12
			// 
			this.textBox12.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "ccontfax", true));
			this.textBox12.Location = new System.Drawing.Point(429, 543);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(232, 20);
			this.textBox12.TabIndex = 237;
			// 
			// textBox13
			// 
			this.textBox13.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontphnwrk", true));
			this.textBox13.Location = new System.Drawing.Point(91, 543);
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(232, 20);
			this.textBox13.TabIndex = 235;
			// 
			// textBox14
			// 
			this.textBox14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox14.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "ccontzip", true));
			this.textBox14.Location = new System.Drawing.Point(429, 490);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(232, 20);
			this.textBox14.TabIndex = 234;
			// 
			// textBox15
			// 
			this.textBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox15.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "ccontaddr2", true));
			this.textBox15.Location = new System.Drawing.Point(429, 464);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(232, 20);
			this.textBox15.TabIndex = 232;
			// 
			// textBox16
			// 
			this.textBox16.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "ccontaddr", true));
			this.textBox16.Location = new System.Drawing.Point(91, 463);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(232, 20);
			this.textBox16.TabIndex = 231;
			// 
			// txtContact3Email
			// 
			this.txtContact3Email.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "ccontemail", true));
			this.txtContact3Email.Location = new System.Drawing.Point(429, 570);
			this.txtContact3Email.Name = "txtContact3Email";
			this.txtContact3Email.Size = new System.Drawing.Size(232, 20);
			this.txtContact3Email.TabIndex = 177;
			// 
			// btnEmailContac3
			// 
			this.btnEmailContac3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnEmailContac3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEmailContac3.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailContac3.Image")));
			this.btnEmailContac3.Location = new System.Drawing.Point(24, 410);
			this.btnEmailContac3.Name = "btnEmailContac3";
			this.btnEmailContac3.Size = new System.Drawing.Size(34, 23);
			this.btnEmailContac3.TabIndex = 144;
			this.btnEmailContac3.UseVisualStyleBackColor = true;
			this.btnEmailContac3.Click += new System.EventHandler(this.btnEmailContac3_Click_1);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(87, 410);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(97, 24);
			this.label16.TabIndex = 143;
			this.label16.Text = "Contact 3";
			// 
			// btnEmailCont2
			// 
			this.btnEmailCont2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnEmailCont2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEmailCont2.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailCont2.Image")));
			this.btnEmailCont2.Location = new System.Drawing.Point(24, 213);
			this.btnEmailCont2.Name = "btnEmailCont2";
			this.btnEmailCont2.Size = new System.Drawing.Size(34, 23);
			this.btnEmailCont2.TabIndex = 122;
			this.btnEmailCont2.UseVisualStyleBackColor = true;
			this.btnEmailCont2.Click += new System.EventHandler(this.btnEmailCont2_Click_1);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(87, 210);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(97, 24);
			this.label15.TabIndex = 121;
			this.label15.Text = "Contact 2";
			// 
			// comboBox3
			// 
			this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "bposition", true));
			this.comboBox3.DataSource = this.contpstnBindingSource1;
			this.comboBox3.DisplayMember = "Position";
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(91, 369);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(232, 21);
			this.comboBox3.TabIndex = 108;
			this.comboBox3.ValueMember = "Position";
			// 
			// contpstnBindingSource1
			// 
			this.contpstnBindingSource1.DataMember = "contpstn";
			this.contpstnBindingSource1.DataSource = this.lookUp;
			// 
			// comboBox4
			// 
			this.comboBox4.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "bcontstate", true));
			this.comboBox4.DataSource = this.statesBindingSource1;
			this.comboBox4.DisplayMember = "Name";
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Location = new System.Drawing.Point(91, 316);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(232, 21);
			this.comboBox4.TabIndex = 103;
			this.comboBox4.ValueMember = "Abrev";
			// 
			// statesBindingSource1
			// 
			this.statesBindingSource1.DataMember = "states";
			this.statesBindingSource1.DataSource = this.lookUp;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontphnhom", true));
			this.textBox1.Location = new System.Drawing.Point(429, 316);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(232, 20);
			this.textBox1.TabIndex = 106;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontlname", true));
			this.textBox2.Location = new System.Drawing.Point(429, 238);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(232, 20);
			this.textBox2.TabIndex = 100;
			// 
			// txtBContFname
			// 
			this.txtBContFname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontfname", true));
			this.txtBContFname.Location = new System.Drawing.Point(91, 238);
			this.txtBContFname.Name = "txtBContFname";
			this.txtBContFname.Size = new System.Drawing.Size(232, 20);
			this.txtBContFname.TabIndex = 99;
			// 
			// txtContact2Email
			// 
			this.txtContact2Email.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontemail", true));
			this.txtContact2Email.Location = new System.Drawing.Point(429, 370);
			this.txtContact2Email.Name = "txtContact2Email";
			this.txtContact2Email.Size = new System.Drawing.Size(232, 20);
			this.txtContact2Email.TabIndex = 109;
			// 
			// textBox5
			// 
			this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontfax", true));
			this.textBox5.Location = new System.Drawing.Point(429, 344);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(232, 20);
			this.textBox5.TabIndex = 107;
			// 
			// textBox6
			// 
			this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontphnwrk", true));
			this.textBox6.Location = new System.Drawing.Point(91, 344);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(232, 20);
			this.textBox6.TabIndex = 105;
			// 
			// textBox7
			// 
			this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontzip", true));
			this.textBox7.Location = new System.Drawing.Point(429, 289);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(232, 20);
			this.textBox7.TabIndex = 104;
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontaddr2", true));
			this.textBox8.Location = new System.Drawing.Point(429, 264);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(232, 20);
			this.textBox8.TabIndex = 102;
			// 
			// textBox9
			// 
			this.textBox9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontaddr", true));
			this.textBox9.Location = new System.Drawing.Point(91, 264);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(232, 20);
			this.textBox9.TabIndex = 101;
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label17.Location = new System.Drawing.Point(24, 601);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(1182, 3);
			this.label17.TabIndex = 76;
			// 
			// btnEmailContact
			// 
			this.btnEmailContact.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnEmailContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEmailContact.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailContact.Image")));
			this.btnEmailContact.Location = new System.Drawing.Point(23, 4);
			this.btnEmailContact.Name = "btnEmailContact";
			this.btnEmailContact.Size = new System.Drawing.Size(34, 23);
			this.btnEmailContact.TabIndex = 73;
			this.btnEmailContact.UseVisualStyleBackColor = true;
			this.btnEmailContact.Click += new System.EventHandler(this.btnEmailContact_Click);
			// 
			// label28
			// 
			this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label28.Location = new System.Drawing.Point(24, 399);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(1182, 3);
			this.label28.TabIndex = 49;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(87, 3);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(80, 24);
			this.label14.TabIndex = 47;
			this.label14.Text = "Contact";
			// 
			// lblSeperator1
			// 
			this.lblSeperator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSeperator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblSeperator1.Location = new System.Drawing.Point(24, 198);
			this.lblSeperator1.Name = "lblSeperator1";
			this.lblSeperator1.Size = new System.Drawing.Size(1182, 3);
			this.lblSeperator1.TabIndex = 24;
			// 
			// comboBox2
			// 
			this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "position", true));
			this.comboBox2.DataSource = this.contpstnBindingSource;
			this.comboBox2.DisplayMember = "Position";
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(91, 161);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(232, 21);
			this.comboBox2.TabIndex = 9;
			this.comboBox2.ValueMember = "Position";
			// 
			// contpstnBindingSource
			// 
			this.contpstnBindingSource.DataMember = "contpstn";
			this.contpstnBindingSource.DataSource = this.lookUp;
			// 
			// comboBox1
			// 
			this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "contstate", true));
			this.comboBox1.DataSource = this.statesBindingSource;
			this.comboBox1.DisplayMember = "Name";
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(91, 108);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(232, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.ValueMember = "Abrev";
			// 
			// contphnhomTextBox
			// 
			this.contphnhomTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.contphnhomTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contphnhom", true));
			this.contphnhomTextBox.Location = new System.Drawing.Point(429, 108);
			this.contphnhomTextBox.Name = "contphnhomTextBox";
			this.contphnhomTextBox.Size = new System.Drawing.Size(232, 20);
			this.contphnhomTextBox.TabIndex = 7;
			// 
			// contlnameTextBox
			// 
			this.contlnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.contlnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contlname", true));
			this.contlnameTextBox.Location = new System.Drawing.Point(429, 29);
			this.contlnameTextBox.Name = "contlnameTextBox";
			this.contlnameTextBox.Size = new System.Drawing.Size(232, 20);
			this.contlnameTextBox.TabIndex = 1;
			// 
			// contfnameTextBox
			// 
			this.contfnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contfname", true));
			this.contfnameTextBox.Location = new System.Drawing.Point(91, 29);
			this.contfnameTextBox.Name = "contfnameTextBox";
			this.contfnameTextBox.Size = new System.Drawing.Size(232, 20);
			this.contfnameTextBox.TabIndex = 0;
			// 
			// txtContactEmail
			// 
			this.txtContactEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contemail", true));
			this.txtContactEmail.Location = new System.Drawing.Point(429, 162);
			this.txtContactEmail.Name = "txtContactEmail";
			this.txtContactEmail.Size = new System.Drawing.Size(232, 20);
			this.txtContactEmail.TabIndex = 10;
			// 
			// contfaxTextBox
			// 
			this.contfaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contfax", true));
			this.contfaxTextBox.Location = new System.Drawing.Point(429, 134);
			this.contfaxTextBox.Name = "contfaxTextBox";
			this.contfaxTextBox.Size = new System.Drawing.Size(232, 20);
			this.contfaxTextBox.TabIndex = 8;
			// 
			// contphnwrkTextBox
			// 
			this.contphnwrkTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contphnwrk", true));
			this.contphnwrkTextBox.Location = new System.Drawing.Point(91, 135);
			this.contphnwrkTextBox.Name = "contphnwrkTextBox";
			this.contphnwrkTextBox.Size = new System.Drawing.Size(232, 20);
			this.contphnwrkTextBox.TabIndex = 6;
			// 
			// contzipTextBox
			// 
			this.contzipTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.contzipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contzip", true));
			this.contzipTextBox.Location = new System.Drawing.Point(429, 81);
			this.contzipTextBox.Name = "contzipTextBox";
			this.contzipTextBox.Size = new System.Drawing.Size(232, 20);
			this.contzipTextBox.TabIndex = 5;
			// 
			// contaddr2TextBox
			// 
			this.contaddr2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.contaddr2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contaddr2", true));
			this.contaddr2TextBox.Location = new System.Drawing.Point(429, 55);
			this.contaddr2TextBox.Name = "contaddr2TextBox";
			this.contaddr2TextBox.Size = new System.Drawing.Size(232, 20);
			this.contaddr2TextBox.TabIndex = 3;
			// 
			// contaddrTextBox
			// 
			this.contaddrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contaddr", true));
			this.contaddrTextBox.Location = new System.Drawing.Point(91, 55);
			this.contaddrTextBox.Name = "contaddrTextBox";
			this.contaddrTextBox.Size = new System.Drawing.Size(232, 20);
			this.contaddrTextBox.TabIndex = 2;
			// 
			// pg3
			// 
			this.pg3.AutoScroll = true;
			this.pg3.BackColor = System.Drawing.SystemColors.Control;
			this.pg3.Controls.Add(this.chkMktComplete);
			this.pg3.Controls.Add(this.btnSaveMktLog);
			this.pg3.Controls.Add(this.btnSaveTeleLog);
			this.pg3.Controls.Add(this.lblSchcode);
			this.pg3.Controls.Add(this.btnAddMarketLog);
			this.pg3.Controls.Add(this.btnAddLog);
			this.pg3.Controls.Add(this.lblMarketing);
			this.pg3.Controls.Add(this.mktinfoDataGridView);
			this.pg3.Controls.Add(this.txtReason);
			this.pg3.Controls.Add(this.commentListBox);
			this.pg3.Controls.Add(this.datecontDataGridView);
			this.pg3.Controls.Add(this.lblTeleSchname);
			this.pg3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pg3.Location = new System.Drawing.Point(4, 22);
			this.pg3.Name = "pg3";
			this.pg3.Size = new System.Drawing.Size(1226, 644);
			this.pg3.TabIndex = 2;
			this.pg3.Text = "Telephone";
			this.pg3.Leave += new System.EventHandler(this.pg3_Leave);
			// 
			// chkMktComplete
			// 
			this.chkMktComplete.AutoSize = true;
			this.chkMktComplete.Location = new System.Drawing.Point(952, 381);
			this.chkMktComplete.Name = "chkMktComplete";
			this.chkMktComplete.Size = new System.Drawing.Size(181, 17);
			this.chkMktComplete.TabIndex = 8;
			this.chkMktComplete.Text = "Marketing Information Completed";
			this.chkMktComplete.UseVisualStyleBackColor = true;
			// 
			// btnSaveMktLog
			// 
			this.btnSaveMktLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSaveMktLog.Location = new System.Drawing.Point(179, 375);
			this.btnSaveMktLog.Name = "btnSaveMktLog";
			this.btnSaveMktLog.Size = new System.Drawing.Size(75, 23);
			this.btnSaveMktLog.TabIndex = 7;
			this.btnSaveMktLog.Text = "Save";
			this.btnSaveMktLog.UseVisualStyleBackColor = true;
			this.btnSaveMktLog.Click += new System.EventHandler(this.btnSaveMktLog_Click);
			// 
			// btnSaveTeleLog
			// 
			this.btnSaveTeleLog.Location = new System.Drawing.Point(179, 138);
			this.btnSaveTeleLog.Name = "btnSaveTeleLog";
			this.btnSaveTeleLog.Size = new System.Drawing.Size(75, 23);
			this.btnSaveTeleLog.TabIndex = 4;
			this.btnSaveTeleLog.Text = "Save";
			this.btnSaveTeleLog.UseVisualStyleBackColor = true;
			this.btnSaveTeleLog.Click += new System.EventHandler(this.btnSaveTeleLog_Click);
			// 
			// lblSchcode
			// 
			this.lblSchcode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schcode", true));
			this.lblSchcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSchcode.Location = new System.Drawing.Point(101, 25);
			this.lblSchcode.Name = "lblSchcode";
			this.lblSchcode.Size = new System.Drawing.Size(120, 53);
			this.lblSchcode.TabIndex = 8;
			this.lblSchcode.Text = "test";
			// 
			// btnAddMarketLog
			// 
			this.btnAddMarketLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddMarketLog.Location = new System.Drawing.Point(46, 375);
			this.btnAddMarketLog.Name = "btnAddMarketLog";
			this.btnAddMarketLog.Size = new System.Drawing.Size(127, 23);
			this.btnAddMarketLog.TabIndex = 5;
			this.btnAddMarketLog.Text = "Add Marketing Log";
			this.btnAddMarketLog.UseVisualStyleBackColor = true;
			this.btnAddMarketLog.Click += new System.EventHandler(this.btnAddMarketLog_Click);
			// 
			// btnAddLog
			// 
			this.btnAddLog.Location = new System.Drawing.Point(46, 138);
			this.btnAddLog.Name = "btnAddLog";
			this.btnAddLog.Size = new System.Drawing.Size(127, 23);
			this.btnAddLog.TabIndex = 2;
			this.btnAddLog.Text = "Add Telephone Log";
			this.btnAddLog.UseVisualStyleBackColor = true;
			this.btnAddLog.Click += new System.EventHandler(this.btnAddLog_Click);
			// 
			// lblMarketing
			// 
			this.lblMarketing.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.lblMarketing.AutoSize = true;
			this.lblMarketing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMarketing.Location = new System.Drawing.Point(438, 363);
			this.lblMarketing.Name = "lblMarketing";
			this.lblMarketing.Size = new System.Drawing.Size(189, 24);
			this.lblMarketing.TabIndex = 5;
			this.lblMarketing.Text = "Marketing Information";
			// 
			// mktinfoDataGridView
			// 
			this.mktinfoDataGridView.AllowUserToAddRows = false;
			this.mktinfoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mktinfoDataGridView.AutoGenerateColumns = false;
			this.mktinfoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.mktinfoDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.mktinfoDataGridView.CausesValidation = false;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.RoyalBlue;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.mktinfoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.mktinfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.mktinfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn13});
			this.mktinfoDataGridView.DataSource = this.mktinfoBindingSource;
			this.mktinfoDataGridView.EnableHeadersVisualStyles = false;
			this.mktinfoDataGridView.Location = new System.Drawing.Point(46, 404);
			this.mktinfoDataGridView.Name = "mktinfoDataGridView";
			this.mktinfoDataGridView.Size = new System.Drawing.Size(1087, 156);
			this.mktinfoDataGridView.TabIndex = 6;
			this.mktinfoDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.mktinfoDataGridView_DataError);
			// 
			// dataGridViewTextBoxColumn15
			// 
			this.dataGridViewTextBoxColumn15.DataPropertyName = "refered";
			this.dataGridViewTextBoxColumn15.DataSource = this.lkpMktReferenceBindingSource;
			this.dataGridViewTextBoxColumn15.DisplayMember = "Name";
			this.dataGridViewTextBoxColumn15.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			this.dataGridViewTextBoxColumn15.HeaderText = "Reference";
			this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// lkpMktReferenceBindingSource
			// 
			this.lkpMktReferenceBindingSource.DataMember = "lkpMktReference";
			this.lkpMktReferenceBindingSource.DataSource = this.lookUp;
			// 
			// dataGridViewTextBoxColumn14
			// 
			this.dataGridViewTextBoxColumn14.DataPropertyName = "promo";
			this.dataGridViewTextBoxColumn14.DataSource = this.lkpPromotionsBindingSource;
			this.dataGridViewTextBoxColumn14.DisplayMember = "Promo";
			this.dataGridViewTextBoxColumn14.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			this.dataGridViewTextBoxColumn14.HeaderText = "Promotion Code";
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// lkpPromotionsBindingSource
			// 
			this.lkpPromotionsBindingSource.DataMember = "lkpPromotions";
			this.lkpPromotionsBindingSource.DataSource = this.lookUp;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "ddate";
			this.dataGridViewTextBoxColumn1.HeaderText = "Date";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			// 
			// dataGridViewTextBoxColumn11
			// 
			this.dataGridViewTextBoxColumn11.DataPropertyName = "initial";
			this.dataGridViewTextBoxColumn11.HeaderText = "Intials";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			// 
			// dataGridViewTextBoxColumn13
			// 
			this.dataGridViewTextBoxColumn13.DataPropertyName = "note";
			this.dataGridViewTextBoxColumn13.HeaderText = "Notes";
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			// 
			// mktinfoBindingSource
			// 
			this.mktinfoBindingSource.DataMember = "mktinfo";
			this.mktinfoBindingSource.DataSource = this.dsMktInfo;
			// 
			// dsMktInfo
			// 
			this.dsMktInfo.DataSetName = "dsMktInfo";
			this.dsMktInfo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// txtReason
			// 
			this.txtReason.CausesValidation = false;
			this.txtReason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "reason", true));
			this.txtReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtReason.Location = new System.Drawing.Point(372, 60);
			this.txtReason.Multiline = true;
			this.txtReason.Name = "txtReason";
			this.txtReason.Size = new System.Drawing.Size(338, 32);
			this.txtReason.TabIndex = 1;
			this.txtReason.Leave += new System.EventHandler(this.txtReason_Leave);
			// 
			// datecontBindingSource
			// 
			this.datecontBindingSource.DataMember = "datecont";
			this.datecontBindingSource.DataSource = this.dsCust;
			// 
			// commentListBox
			// 
			this.commentListBox.CausesValidation = false;
			this.commentListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.lkpCommentsBindingSource, "Comment", true));
			this.commentListBox.DataSource = this.lkpCommentsBindingSource;
			this.commentListBox.DisplayMember = "Comment";
			this.commentListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.commentListBox.FormattingEnabled = true;
			this.commentListBox.Location = new System.Drawing.Point(731, 60);
			this.commentListBox.Name = "commentListBox";
			this.commentListBox.Size = new System.Drawing.Size(399, 95);
			this.commentListBox.TabIndex = 0;
			this.commentListBox.DoubleClick += new System.EventHandler(this.commentListBox_DoubleClick);
			// 
			// lkpCommentsBindingSource
			// 
			this.lkpCommentsBindingSource.DataMember = "lkpComments";
			this.lkpCommentsBindingSource.DataSource = this.lookUp;
			// 
			// datecontDataGridView
			// 
			this.datecontDataGridView.AllowUserToAddRows = false;
			this.datecontDataGridView.AllowUserToDeleteRows = false;
			this.datecontDataGridView.AllowUserToOrderColumns = true;
			this.datecontDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.datecontDataGridView.AutoGenerateColumns = false;
			this.datecontDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.datecontDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.datecontDataGridView.CausesValidation = false;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.RoyalBlue;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.datecontDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.datecontDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.datecontDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn3,
            this.id,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn10,
            this.datecont,
            this.dataGridViewTextBoxColumn3,
            this.initial,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
			this.datecontDataGridView.DataSource = this.datecontBindingSource;
			this.datecontDataGridView.EnableHeadersVisualStyles = false;
			this.datecontDataGridView.Location = new System.Drawing.Point(46, 167);
			this.datecontDataGridView.Name = "datecontDataGridView";
			this.datecontDataGridView.Size = new System.Drawing.Size(1087, 190);
			this.datecontDataGridView.TabIndex = 3;
			this.datecontDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datecontDataGridView_CellDoubleClick);
			this.datecontDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.datecontDataGridView_DataError);
			// 
			// dataGridViewCheckBoxColumn3
			// 
			this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.dataGridViewCheckBoxColumn3.DataPropertyName = "techcall";
			this.dataGridViewCheckBoxColumn3.HeaderText = "Tech Call";
			this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
			this.dataGridViewCheckBoxColumn3.Width = 58;
			// 
			// id
			// 
			this.id.DataPropertyName = "id";
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.Visible = false;
			// 
			// dataGridViewCheckBoxColumn1
			// 
			this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.dataGridViewCheckBoxColumn1.DataPropertyName = "callcont";
			this.dataGridViewCheckBoxColumn1.HeaderText = "Call";
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn1.Width = 30;
			// 
			// dataGridViewTextBoxColumn10
			// 
			this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.dataGridViewTextBoxColumn10.DataPropertyName = "priority";
			this.dataGridViewTextBoxColumn10.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			this.dataGridViewTextBoxColumn10.HeaderText = "Pri";
			this.dataGridViewTextBoxColumn10.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn10.Width = 44;
			// 
			// datecont
			// 
			this.datecont.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.datecont.DataPropertyName = "datecont";
			this.datecont.HeaderText = "Date";
			this.datecont.Name = "datecont";
			this.datecont.ReadOnly = true;
			this.datecont.Width = 55;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "reason";
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewTextBoxColumn3.HeaderText = "Reason";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn3.Width = 69;
			// 
			// initial
			// 
			this.initial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.initial.DataPropertyName = "initial";
			this.initial.HeaderText = "Initials";
			this.initial.Name = "initial";
			this.initial.Width = 61;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.dataGridViewTextBoxColumn9.DataPropertyName = "calltime";
			this.dataGridViewTextBoxColumn9.HeaderText = "Call Time";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.Width = 69;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.dataGridViewTextBoxColumn7.DataPropertyName = "nxtdays";
			this.dataGridViewTextBoxColumn7.HeaderText = "Contact (Days)";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.Width = 94;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "nxtdate";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.NullValue = " / / ";
			this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewTextBoxColumn8.HeaderText = "Next Date";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.Width = 74;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "contact";
			this.dataGridViewTextBoxColumn5.HeaderText = "Contact";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "typecont";
			this.dataGridViewTextBoxColumn6.DataSource = this.lkpTypeContBindingSource;
			this.dataGridViewTextBoxColumn6.DisplayMember = "Name";
			this.dataGridViewTextBoxColumn6.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			this.dataGridViewTextBoxColumn6.HeaderText = "Type Cont";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn6.ValueMember = "Name";
			// 
			// lkpTypeContBindingSource
			// 
			this.lkpTypeContBindingSource.DataMember = "lkpTypeCont";
			this.lkpTypeContBindingSource.DataSource = this.lookUp;
			// 
			// lblTeleSchname
			// 
			this.lblTeleSchname.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblTeleSchname.AutoSize = true;
			this.lblTeleSchname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schname", true));
			this.lblTeleSchname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTeleSchname.Location = new System.Drawing.Point(569, 14);
			this.lblTeleSchname.Name = "lblTeleSchname";
			this.lblTeleSchname.Size = new System.Drawing.Size(88, 24);
			this.lblTeleSchname.TabIndex = 0;
			this.lblTeleSchname.Text = "schname";
			// 
			// custTableAdapter
			// 
			this.custTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager
			// 
			this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager.Connection = null;
			this.tableAdapterManager.custSearchTableAdapter = null;
			this.tableAdapterManager.custTableAdapter = null;
			this.tableAdapterManager.datecontTableAdapter = null;
			this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsCustTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// statesTableAdapter
			// 
			this.statesTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager1
			// 
			this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager1.Connection = null;
			this.tableAdapterManager1.contpstnTableAdapter = null;
			this.tableAdapterManager1.lkpBackGroundTableAdapter = null;
			this.tableAdapterManager1.lkpCommentsTableAdapter = null;
			this.tableAdapterManager1.lkpCustTypeTableAdapter = null;
			this.tableAdapterManager1.lkpLeadNameTableAdapter = null;
			this.tableAdapterManager1.lkpLeadSourceTableAdapter = null;
			this.tableAdapterManager1.lkpMktReferenceTableAdapter = null;
			this.tableAdapterManager1.lkpMultiYearOptionsTableAdapter = null;
			this.tableAdapterManager1.lkpNoRebookTableAdapter = null;
			this.tableAdapterManager1.lkpPrevPubTableAdapter = null;
			this.tableAdapterManager1.lkpPromotionsTableAdapter = null;
			this.tableAdapterManager1.lkpschtypeTableAdapter = null;
			this.tableAdapterManager1.lkpTypeContTableAdapter = null;
			this.tableAdapterManager1.lkTypeDataTableAdapter = null;
			this.tableAdapterManager1.UpdateOrder = Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// mktinfoTableAdapter
			// 
			this.mktinfoTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager2
			// 
			this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager2.mktinfoTableAdapter = this.mktinfoTableAdapter;
			this.tableAdapterManager2.UpdateOrder = Mbc5.DataSets.dsMktInfoTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// lkpPromotionsTableAdapter
			// 
			this.lkpPromotionsTableAdapter.ClearBeforeFill = true;
			// 
			// lkpCommentsTableAdapter
			// 
			this.lkpCommentsTableAdapter.ClearBeforeFill = true;
			// 
			// lkpTypeContTableAdapter
			// 
			this.lkpTypeContTableAdapter.ClearBeforeFill = true;
			// 
			// lkpMktReferenceTableAdapter
			// 
			this.lkpMktReferenceTableAdapter.ClearBeforeFill = true;
			// 
			// contpstnTableAdapter
			// 
			this.contpstnTableAdapter.ClearBeforeFill = true;
			// 
			// dsDateCont
			// 
			this.dsDateCont.DataSetName = "dsDateCont";
			this.dsDateCont.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// tableAdapterManager3
			// 
			this.tableAdapterManager3.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager3.Connection = null;
			this.tableAdapterManager3.datecontTableAdapter = null;
			this.tableAdapterManager3.UpdateOrder = Mbc5.DataSets.dsDateContTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// datecontTableAdapter
			// 
			this.datecontTableAdapter.ClearBeforeFill = true;
			// 
			// datecontBindingSource1
			// 
			this.datecontBindingSource1.DataMember = "datecont";
			this.datecontBindingSource1.DataSource = this.dsDateCont;
			// 
			// txtModifiedBy
			// 
			this.txtModifiedBy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "ModifiedBy", true));
			this.txtModifiedBy.Enabled = false;
			this.txtModifiedBy.Location = new System.Drawing.Point(1219, 15);
			this.txtModifiedBy.Name = "txtModifiedBy";
			this.txtModifiedBy.Size = new System.Drawing.Size(1, 20);
			this.txtModifiedBy.TabIndex = 17;
			// 
			// lkpNoRebookTableAdapter
			// 
			this.lkpNoRebookTableAdapter.ClearBeforeFill = true;
			// 
			// lkpPrevPubTableAdapter
			// 
			this.lkpPrevPubTableAdapter.ClearBeforeFill = true;
			// 
			// lkpMultiYearOptionsTableAdapter
			// 
			this.lkpMultiYearOptionsTableAdapter.ClearBeforeFill = true;
			// 
			// lkpschtypeTableAdapter
			// 
			this.lkpschtypeTableAdapter.ClearBeforeFill = true;
			// 
			// custSearchBindingSource
			// 
			this.custSearchBindingSource.DataMember = "custSearch";
			this.custSearchBindingSource.DataSource = this.dsCust;
			// 
			// custSearchTableAdapter
			// 
			this.custSearchTableAdapter.ClearBeforeFill = true;
			// 
			// lkpLeadNameTableAdapter
			// 
			this.lkpLeadNameTableAdapter.ClearBeforeFill = true;
			// 
			// lkpLeadSourceTableAdapter
			// 
			this.lkpLeadSourceTableAdapter.ClearBeforeFill = true;
			// 
			// reportViewer1
			// 
			this.reportViewer1.DocumentMapWidth = 48;
			reportDataSource2.Name = "dsRptProdutn";
			reportDataSource2.Value = this.ProdutnTicketModelBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.ProdutnTicket.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(583, -22);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(68, 82);
			this.reportViewer1.TabIndex = 287;
			this.reportViewer1.Visible = false;
			this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
			// 
			// reportViewerCheckList
			// 
			this.reportViewerCheckList.DocumentMapWidth = 48;
			reportDataSource1.Name = "dsProdChkList";
			reportDataSource1.Value = this.ProductionCheckListBindingSource;
			this.reportViewerCheckList.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewerCheckList.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.ProdCheckList.rdlc";
			this.reportViewerCheckList.Location = new System.Drawing.Point(665, -22);
			this.reportViewerCheckList.Name = "reportViewerCheckList";
			this.reportViewerCheckList.ServerReport.BearerToken = null;
			this.reportViewerCheckList.Size = new System.Drawing.Size(68, 82);
			this.reportViewerCheckList.TabIndex = 288;
			this.reportViewerCheckList.Visible = false;
			this.reportViewerCheckList.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewerCheckList_RenderingComplete);
			// 
			// frmMbcCust
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1234, 731);
			this.Controls.Add(this.CustTab);
			this.MinimumSize = new System.Drawing.Size(1250, 770);
			this.Name = "frmMbcCust";
			this.Text = "MBC Customers";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMbcCust_FormClosing);
			this.Load += new System.EventHandler(this.frmMbcCust_Load);
			this.Shown += new System.EventHandler(this.frmMbcCust_Shown);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMbcCust_Paint);
			this.Controls.SetChildIndex(this.CustTab, 0);
			this.Controls.SetChildIndex(this.TopPanel, 0);
			this.Controls.SetChildIndex(this.BottomPanel, 0);
			this.BottomPanel.ResumeLayout(false);
			this.BottomPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ProdutnTicketModelBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ProductionCheckListBindingSource)).EndInit();
			this.CustTab.ResumeLayout(false);
			this.pg1.ResumeLayout(false);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCust)).EndInit();
			this.addItemMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lkpLeadNameBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpLeadSourceBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lookUp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpschtypeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpNoRebookBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpPrevPubBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpMultiYearOptionsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).EndInit();
			this.pnlHead.ResumeLayout(false);
			this.pnlHead.PerformLayout();
			this.pg2.ResumeLayout(false);
			this.pg2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.contpstnBindingSource2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statesBindingSource2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.contpstnBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statesBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.contpstnBindingSource)).EndInit();
			this.pg3.ResumeLayout(false);
			this.pg3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mktinfoDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpMktReferenceBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpPromotionsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mktinfoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsMktInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datecontBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpCommentsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datecontDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpTypeContBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsDateCont)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datecontBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.custSearchBindingSource)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl CustTab;
        private System.Windows.Forms.TabPage pg1;
        private System.Windows.Forms.TabPage pg2;
        private DataSets.dsCust dsCust;
        private DataSets.dsCustTableAdapters.custTableAdapter custTableAdapter;
        private System.Windows.Forms.BindingSource custBindingSource;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.TextBox txtCsRep;
        private DataSets.dsCustTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox junsnoTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DataSets.LookUp lookUp;
        private System.Windows.Forms.BindingSource statesBindingSource;
        private DataSets.LookUpTableAdapters.statesTableAdapter statesTableAdapter;
        private DataSets.LookUpTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox contphnhomTextBox;
        private System.Windows.Forms.TextBox contlnameTextBox;
        private System.Windows.Forms.TextBox contfnameTextBox;
        private System.Windows.Forms.TextBox txtContactEmail;
        private System.Windows.Forms.TextBox contfaxTextBox;
        private System.Windows.Forms.TextBox contphnwrkTextBox;
        private System.Windows.Forms.TextBox contzipTextBox;
        private System.Windows.Forms.TextBox contaddr2TextBox;
        private System.Windows.Forms.TextBox contaddrTextBox;
        private System.Windows.Forms.Label lblSeperator1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.BindingSource contpstnBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox txtSchColors;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblSchName;
        private System.Windows.Forms.DateTimePicker schoutDateTimePicker;
        private System.Windows.Forms.TextBox spcinstTextBox;
        private System.Windows.Forms.TextBox extrchgTextBox;
        private System.Windows.Forms.Button btnInterOffice;
        private System.Windows.Forms.TextBox inofficeTextBox;
        private System.Windows.Forms.ComboBox cmbSchCategory;
        private System.Windows.Forms.ComboBox cmbNoRebook;
        private System.Windows.Forms.ComboBox cmbPrevPublisher;
        private System.Windows.Forms.CheckBox multiyearCheckBox;
        private System.Windows.Forms.TextBox txtPhotographer;
        private System.Windows.Forms.ComboBox multiyearComboBox;
        private System.Windows.Forms.TextBox clrpg_intTextBox;
        private System.Windows.Forms.CheckBox schuploadingCheckBox;
        private System.Windows.Forms.CheckBox sprinfoCheckBox;
        private System.Windows.Forms.CheckBox fallinfoCheckBox;
        private System.Windows.Forms.CheckBox clspicCheckBox;
        private System.Windows.Forms.TextBox springbreakTextBox;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Button btnWebsite;
        private System.Windows.Forms.TextBox txtSchEmail;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtSchPhone;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.DataGridView custDataGridView;
        private System.Windows.Forms.TextBox txtBookType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox shiptocontTextBox;
        private System.Windows.Forms.TextBox yb_sthTextBox;
        private System.Windows.Forms.CheckBox nodirectmailCheckBox;
        private System.Windows.Forms.CheckBox nomktemailCheckBox;
        private System.Windows.Forms.Button btnEmailContact;
        private System.Windows.Forms.Button btnSchoolEmail;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage pg3;
        private System.Windows.Forms.Label lblTeleSchname;
        private System.Windows.Forms.BindingSource datecontBindingSource;
        private System.Windows.Forms.DataGridView datecontDataGridView;
        private System.Windows.Forms.BindingSource lkpTypeContBindingSource;
        private System.Windows.Forms.BindingSource lkpCommentsBindingSource;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.ListBox commentListBox;
        private DataSets.dsMktInfo dsMktInfo;
        private System.Windows.Forms.BindingSource mktinfoBindingSource;
        private DataSets.dsMktInfoTableAdapters.mktinfoTableAdapter mktinfoTableAdapter;
        private DataSets.dsMktInfoTableAdapters.TableAdapterManager tableAdapterManager2;
        private System.Windows.Forms.DataGridView mktinfoDataGridView;
        private System.Windows.Forms.BindingSource lkpMktReferenceBindingSource;
        private System.Windows.Forms.BindingSource lkpPromotionsBindingSource;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataSets.LookUpTableAdapters.lkpPromotionsTableAdapter lkpPromotionsTableAdapter;
        private DataSets.LookUpTableAdapters.lkpCommentsTableAdapter lkpCommentsTableAdapter;
        private DataSets.LookUpTableAdapters.lkpTypeContTableAdapter lkpTypeContTableAdapter;
        private DataSets.LookUpTableAdapters.lkpMktReferenceTableAdapter lkpMktReferenceTableAdapter;
        private DataSets.LookUpTableAdapters.contpstnTableAdapter contpstnTableAdapter;
        private DataSets.dsDateCont dsDateCont;
        private DataSets.dsDateContTableAdapters.TableAdapterManager tableAdapterManager3;
        private DataSets.dsCustTableAdapters.datecontTableAdapter datecontTableAdapter;
        private System.Windows.Forms.Button btnAddMarketLog;
        private System.Windows.Forms.Button btnAddLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label lblSchcode;
        private System.Windows.Forms.Button btnSaveMktLog;
        private System.Windows.Forms.Button btnSaveTeleLog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn datecont;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn initial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource datecontBindingSource1;
        private System.Windows.Forms.CheckBox chkMktComplete;
        private System.Windows.Forms.Label lblInvno;
		private System.Windows.Forms.TextBox txtModifiedBy;
		private System.Windows.Forms.DateTimePicker initcontDateTimePicker;
		private System.Windows.Forms.DateTimePicker sourdateDateTimePicker;
		private System.Windows.Forms.DateTimePicker contdateDateTimePicker;
		private System.Windows.Forms.Label dedayoutLabel2;
		private System.Windows.Forms.Label dedayinLabel2;
		private System.Windows.Forms.Button btnNewCustomer;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn106;
		private System.Windows.Forms.TextBox contryearTextBox;
        private System.Windows.Forms.BindingSource lkpNoRebookBindingSource;
        private DataSets.LookUpTableAdapters.lkpNoRebookTableAdapter lkpNoRebookTableAdapter;
        private System.Windows.Forms.BindingSource lkpPrevPubBindingSource;
        private DataSets.LookUpTableAdapters.lkpPrevPubTableAdapter lkpPrevPubTableAdapter;
        private System.Windows.Forms.BindingSource lkpMultiYearOptionsBindingSource;
        private DataSets.LookUpTableAdapters.lkpMultiYearOptionsTableAdapter lkpMultiYearOptionsTableAdapter;
        private System.Windows.Forms.BindingSource lkpschtypeBindingSource;
        private DataSets.LookUpTableAdapters.lkpschtypeTableAdapter lkpschtypeTableAdapter;
        private System.Windows.Forms.BindingSource custSearchBindingSource;
        private DataSets.dsCustTableAdapters.custSearchTableAdapter custSearchTableAdapter;
        private System.Windows.Forms.TextBox oraclecodeTextBox;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.TextBox txtSchname;
        private System.Windows.Forms.BindingSource contpstnBindingSource2;
        private System.Windows.Forms.BindingSource statesBindingSource2;
        private System.Windows.Forms.BindingSource contpstnBindingSource1;
        private System.Windows.Forms.BindingSource statesBindingSource1;
        private System.Windows.Forms.Button btnEmailCont2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtBContFname;
        private System.Windows.Forms.TextBox txtContact2Email;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button btnEmailContac3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtContact3Email;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.ComboBox electronicoptions;
        private System.Windows.Forms.CheckBox electronickitCheckBox;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label lblSchcodeVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn107;
        private System.Windows.Forms.CheckBox isTaxExemptCheckBox;
        private System.Windows.Forms.ComboBox stageComboBox;
        private System.Windows.Forms.ComboBox leadnameComboBox;
        private System.Windows.Forms.ComboBox leadsourceComboBox;
        private System.Windows.Forms.Button btnProdChk;
        private System.Windows.Forms.BindingSource lkpLeadNameBindingSource;
        private DataSets.dsCustTableAdapters.lkpLeadNameTableAdapter lkpLeadNameTableAdapter;
        private System.Windows.Forms.BindingSource lkpLeadSourceBindingSource;
        private DataSets.dsCustTableAdapters.lkpLeadSourceTableAdapter lkpLeadSourceTableAdapter;
        private System.Windows.Forms.DateTimePicker firstDaySchoolDateTimePicker;
        private System.Windows.Forms.TextBox csrep2TextBox;
        private System.Windows.Forms.Label stfpwLabel1;
        private System.Windows.Forms.Label advpwLabel1;
        private System.Windows.Forms.Label jobnoLabel1;
        private System.Windows.Forms.DateTimePicker rbdateDateTimePicker;
        private System.Windows.Forms.DateTimePicker xeldateDateTimePicker;
        private System.Windows.Forms.Button btnProdTckt;
        private System.Windows.Forms.BindingSource ProdutnTicketModelBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProductionCheckListBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerCheckList;
        private System.Windows.Forms.TextBox ccontcityTextBox;
        private System.Windows.Forms.TextBox bcontcityTextBox;
        private System.Windows.Forms.TextBox contcityTextBox;
        private System.Windows.Forms.ContextMenuStrip addItemMenu;
        private System.Windows.Forms.ToolStripMenuItem AddLeadSource;
        private System.Windows.Forms.ToolStripMenuItem AddLeadName;
		private System.Windows.Forms.DateTimePicker taxExemptionReceivedDateTimePicker;
		private System.Windows.Forms.CheckBox notTaxExemptCheckBox;
		private System.Windows.Forms.CheckBox blkwhiteCheckBox;
		private System.Windows.Forms.CheckBox allcolorCheckBox;
		private System.Windows.Forms.ComboBox stageComboBox1;
		private System.Windows.Forms.TextBox enrollmentTextBox;
		private System.Windows.Forms.ComboBox gradesComboBox;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn105;
		private System.Windows.Forms.DataGridViewTextBoxColumn qcontractyear;
		private System.Windows.Forms.DataGridViewTextBoxColumn QInvno;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn108;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn111;
	}
}
