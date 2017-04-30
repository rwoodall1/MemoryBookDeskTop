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
			System.Windows.Forms.Label label18;
			System.Windows.Forms.Label label19;
			System.Windows.Forms.Label label20;
			System.Windows.Forms.Label label21;
			System.Windows.Forms.Label label22;
			System.Windows.Forms.Label label23;
			System.Windows.Forms.Label label24;
			System.Windows.Forms.Label label25;
			System.Windows.Forms.Label label26;
			System.Windows.Forms.Label label27;
			System.Windows.Forms.Label lblEmail;
			System.Windows.Forms.Label lblFax;
			System.Windows.Forms.Label schoutLabel;
			System.Windows.Forms.Label spcinstLabel;
			System.Windows.Forms.Label extrchgLabel;
			System.Windows.Forms.Label schcolorsLabel;
			System.Windows.Forms.Label lblCategory;
			System.Windows.Forms.Label gradesLabel;
			System.Windows.Forms.Label norebookreasonLabel;
			System.Windows.Forms.Label prevpublisherLabel;
			System.Windows.Forms.Label enrollmentLabel1;
			System.Windows.Forms.Label newpublisherLabel1;
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
			System.Windows.Forms.Label contmemoLabel;
			System.Windows.Forms.Label oraclecodeLabel;
			System.Windows.Forms.Label contdateLabel;
			System.Windows.Forms.Label sourdateLabel;
			System.Windows.Forms.Label initcontLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMbcCust));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.CustTab = new System.Windows.Forms.TabControl();
			this.pg1 = new System.Windows.Forms.TabPage();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.initcontDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dsCust = new Mbc5.DataSets.dsCust();
			this.sourdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.contdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.oraclecodeTextBox = new System.Windows.Forms.TextBox();
			this.contryearTextBox = new System.Windows.Forms.TextBox();
			this.txtSchname = new System.Windows.Forms.TextBox();
			this.lblSchcodeVal = new System.Windows.Forms.Label();
			this.junsnoTextBox = new System.Windows.Forms.TextBox();
			this.txtSchColors = new System.Windows.Forms.TextBox();
			this.txtFax = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCsRep = new System.Windows.Forms.TextBox();
			this.lblSchName = new System.Windows.Forms.Label();
			this.schoutDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.cmbSchCategory = new System.Windows.Forms.ComboBox();
			this.cmbNoRebook = new System.Windows.Forms.ComboBox();
			this.cmbPrevPublisher = new System.Windows.Forms.ComboBox();
			this.cmbNewPublisher = new System.Windows.Forms.ComboBox();
			this.multiyearCheckBox = new System.Windows.Forms.CheckBox();
			this.gradesTextBox = new System.Windows.Forms.TextBox();
			this.enrollmentTextBox = new System.Windows.Forms.TextBox();
			this.txtPhotographer = new System.Windows.Forms.TextBox();
			this.multiyearComboBox = new System.Windows.Forms.ComboBox();
			this.clrpg_intTextBox = new System.Windows.Forms.TextBox();
			this.schuploadingCheckBox = new System.Windows.Forms.CheckBox();
			this.blkwhiteCheckBox = new System.Windows.Forms.CheckBox();
			this.allcolorCheckBox = new System.Windows.Forms.CheckBox();
			this.sprinfoCheckBox = new System.Windows.Forms.CheckBox();
			this.fallinfoCheckBox = new System.Windows.Forms.CheckBox();
			this.clspicCheckBox = new System.Windows.Forms.CheckBox();
			this.springbreakTextBox = new System.Windows.Forms.TextBox();
			this.txtWebsite = new System.Windows.Forms.TextBox();
			this.btnWebsite = new System.Windows.Forms.Button();
			this.txtSchEmail = new System.Windows.Forms.TextBox();
			this.cmbState = new System.Windows.Forms.ComboBox();
			this.statesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.lookUp = new Mbc5.DataSets.LookUp();
			this.txtaddress = new System.Windows.Forms.TextBox();
			this.txtSchPhone = new System.Windows.Forms.TextBox();
			this.txtZip = new System.Windows.Forms.TextBox();
			this.txtAddress2 = new System.Windows.Forms.TextBox();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.lblInvno = new System.Windows.Forms.Label();
			this.btnSchoolEmail = new System.Windows.Forms.Button();
			this.nodirectmailCheckBox = new System.Windows.Forms.CheckBox();
			this.nomktemailCheckBox = new System.Windows.Forms.CheckBox();
			this.custDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn105 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn106 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn107 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.btnOracleSrch = new System.Windows.Forms.Button();
			this.txtOracleCodeSrch = new System.Windows.Forms.TextBox();
			this.btnSchoolSearch = new System.Windows.Forms.Button();
			this.txtSchNamesrch = new System.Windows.Forms.TextBox();
			this.btnSchoolCode = new System.Windows.Forms.Button();
			this.txtSchCodesrch = new System.Windows.Forms.TextBox();
			this.pg2 = new System.Windows.Forms.TabPage();
			this.contmemoTextBox = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.btnEmailContac3 = new System.Windows.Forms.Button();
			this.btnEmailCont2 = new System.Windows.Forms.Button();
			this.btnEmailContact = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.comboBox6 = new System.Windows.Forms.ComboBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.txtContact3Email = new System.Windows.Forms.TextBox();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.txtBContFname = new System.Windows.Forms.TextBox();
			this.txtContact2Email = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
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
			this.dedayinLabel2 = new System.Windows.Forms.Label();
			this.dedayoutLabel2 = new System.Windows.Forms.Label();
			this.btnNewCustomer = new System.Windows.Forms.Button();
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
			label18 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			lblEmail = new System.Windows.Forms.Label();
			lblFax = new System.Windows.Forms.Label();
			schoutLabel = new System.Windows.Forms.Label();
			spcinstLabel = new System.Windows.Forms.Label();
			extrchgLabel = new System.Windows.Forms.Label();
			schcolorsLabel = new System.Windows.Forms.Label();
			lblCategory = new System.Windows.Forms.Label();
			gradesLabel = new System.Windows.Forms.Label();
			norebookreasonLabel = new System.Windows.Forms.Label();
			prevpublisherLabel = new System.Windows.Forms.Label();
			enrollmentLabel1 = new System.Windows.Forms.Label();
			newpublisherLabel1 = new System.Windows.Forms.Label();
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
			contmemoLabel = new System.Windows.Forms.Label();
			oraclecodeLabel = new System.Windows.Forms.Label();
			contdateLabel = new System.Windows.Forms.Label();
			sourdateLabel = new System.Windows.Forms.Label();
			initcontLabel = new System.Windows.Forms.Label();
			this.BottomPanel.SuspendLayout();
			this.CustTab.SuspendLayout();
			this.pg1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCust)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lookUp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).BeginInit();
			this.pnlHead.SuspendLayout();
			this.pg2.SuspendLayout();
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
			this.SuspendLayout();
			// 
			// TopPanel
			// 
			this.TopPanel.Size = new System.Drawing.Size(1234, 10);
			// 
			// BottomPanel
			// 
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
			contaddrLabel.Location = new System.Drawing.Point(33, 55);
			contaddrLabel.Name = "contaddrLabel";
			contaddrLabel.Size = new System.Drawing.Size(48, 13);
			contaddrLabel.TabIndex = 0;
			contaddrLabel.Text = "Address:";
			// 
			// contaddr2Label
			// 
			contaddr2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			contaddr2Label.AutoSize = true;
			contaddr2Label.Location = new System.Drawing.Point(327, 55);
			contaddr2Label.Name = "contaddr2Label";
			contaddr2Label.Size = new System.Drawing.Size(54, 13);
			contaddr2Label.TabIndex = 2;
			contaddr2Label.Text = "Address2:";
			// 
			// contstateLabel
			// 
			contstateLabel.AutoSize = true;
			contstateLabel.Location = new System.Drawing.Point(46, 81);
			contstateLabel.Name = "contstateLabel";
			contstateLabel.Size = new System.Drawing.Size(35, 13);
			contstateLabel.TabIndex = 4;
			contstateLabel.Text = "State:";
			// 
			// contzipLabel
			// 
			contzipLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			contzipLabel.AutoSize = true;
			contzipLabel.Location = new System.Drawing.Point(356, 81);
			contzipLabel.Name = "contzipLabel";
			contzipLabel.Size = new System.Drawing.Size(25, 13);
			contzipLabel.TabIndex = 6;
			contzipLabel.Text = "Zip:";
			// 
			// contphnwrkLabel
			// 
			contphnwrkLabel.AutoSize = true;
			contphnwrkLabel.Location = new System.Drawing.Point(11, 108);
			contphnwrkLabel.Name = "contphnwrkLabel";
			contphnwrkLabel.Size = new System.Drawing.Size(70, 13);
			contphnwrkLabel.TabIndex = 8;
			contphnwrkLabel.Text = "Work Phone:";
			// 
			// contfaxLabel
			// 
			contfaxLabel.AutoSize = true;
			contfaxLabel.Location = new System.Drawing.Point(20, 134);
			contfaxLabel.Name = "contfaxLabel";
			contfaxLabel.Size = new System.Drawing.Size(61, 13);
			contfaxLabel.TabIndex = 10;
			contfaxLabel.Text = "Cell Phone:";
			// 
			// contemailLabel
			// 
			contemailLabel.AutoSize = true;
			contemailLabel.Location = new System.Drawing.Point(46, 163);
			contemailLabel.Name = "contemailLabel";
			contemailLabel.Size = new System.Drawing.Size(35, 13);
			contemailLabel.TabIndex = 12;
			contemailLabel.Text = "Email:";
			// 
			// contfnameLabel
			// 
			contfnameLabel.AutoSize = true;
			contfnameLabel.Location = new System.Drawing.Point(21, 29);
			contfnameLabel.Name = "contfnameLabel";
			contfnameLabel.Size = new System.Drawing.Size(60, 13);
			contfnameLabel.TabIndex = 14;
			contfnameLabel.Text = "First Name:";
			// 
			// contlnameLabel
			// 
			contlnameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			contlnameLabel.AutoSize = true;
			contlnameLabel.Location = new System.Drawing.Point(320, 29);
			contlnameLabel.Name = "contlnameLabel";
			contlnameLabel.Size = new System.Drawing.Size(61, 13);
			contlnameLabel.TabIndex = 16;
			contlnameLabel.Text = "Last Name:";
			// 
			// contphnhomLabel
			// 
			contphnhomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			contphnhomLabel.AutoSize = true;
			contphnhomLabel.Location = new System.Drawing.Point(309, 108);
			contphnhomLabel.Name = "contphnhomLabel";
			contphnhomLabel.Size = new System.Drawing.Size(72, 13);
			contphnhomLabel.TabIndex = 18;
			contphnhomLabel.Text = "Home Phone:";
			// 
			// positionLabel
			// 
			positionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			positionLabel.AutoSize = true;
			positionLabel.Location = new System.Drawing.Point(334, 134);
			positionLabel.Name = "positionLabel";
			positionLabel.Size = new System.Drawing.Size(47, 13);
			positionLabel.TabIndex = 20;
			positionLabel.Text = "Position:";
			// 
			// label3
			// 
			label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(334, 335);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(47, 13);
			label3.TabIndex = 44;
			label3.Text = "Position:";
			// 
			// label4
			// 
			label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(309, 309);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(72, 13);
			label4.TabIndex = 42;
			label4.Text = "Home Phone:";
			// 
			// label5
			// 
			label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(320, 230);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(61, 13);
			label5.TabIndex = 40;
			label5.Text = "Last Name:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(21, 230);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(60, 13);
			label6.TabIndex = 38;
			label6.Text = "First Name:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(46, 364);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(35, 13);
			label7.TabIndex = 36;
			label7.Text = "Email:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(20, 335);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(61, 13);
			label8.TabIndex = 34;
			label8.Text = "Cell Phone:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(11, 309);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(70, 13);
			label9.TabIndex = 32;
			label9.Text = "Work Phone:";
			// 
			// label10
			// 
			label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(356, 282);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(25, 13);
			label10.TabIndex = 30;
			label10.Text = "Zip:";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(46, 282);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(35, 13);
			label11.TabIndex = 29;
			label11.Text = "State:";
			// 
			// label12
			// 
			label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(327, 256);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(54, 13);
			label12.TabIndex = 27;
			label12.Text = "Address2:";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(33, 256);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(48, 13);
			label13.TabIndex = 25;
			label13.Text = "Address:";
			// 
			// label18
			// 
			label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(309, 515);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(72, 13);
			label18.TabIndex = 67;
			label18.Text = "Home Phone:";
			// 
			// label19
			// 
			label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(320, 436);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(61, 13);
			label19.TabIndex = 65;
			label19.Text = "Last Name:";
			// 
			// label20
			// 
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(21, 436);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(60, 13);
			label20.TabIndex = 63;
			label20.Text = "First Name:";
			// 
			// label21
			// 
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(46, 570);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(35, 13);
			label21.TabIndex = 61;
			label21.Text = "Email:";
			// 
			// label22
			// 
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(20, 541);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(61, 13);
			label22.TabIndex = 59;
			label22.Text = "Cell Phone:";
			// 
			// label23
			// 
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(11, 515);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(70, 13);
			label23.TabIndex = 57;
			label23.Text = "Work Phone:";
			// 
			// label24
			// 
			label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(356, 488);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(25, 13);
			label24.TabIndex = 55;
			label24.Text = "Zip:";
			// 
			// label25
			// 
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(46, 488);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(35, 13);
			label25.TabIndex = 54;
			label25.Text = "State:";
			// 
			// label26
			// 
			label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(327, 462);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(54, 13);
			label26.TabIndex = 52;
			label26.Text = "Address2:";
			// 
			// label27
			// 
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(33, 462);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(48, 13);
			label27.TabIndex = 50;
			label27.Text = "Address:";
			// 
			// lblEmail
			// 
			lblEmail.AutoSize = true;
			lblEmail.Location = new System.Drawing.Point(54, 202);
			lblEmail.Name = "lblEmail";
			lblEmail.Size = new System.Drawing.Size(35, 13);
			lblEmail.TabIndex = 93;
			lblEmail.Text = "Email:";
			// 
			// lblFax
			// 
			lblFax.AutoSize = true;
			lblFax.Location = new System.Drawing.Point(390, 177);
			lblFax.Name = "lblFax";
			lblFax.Size = new System.Drawing.Size(27, 13);
			lblFax.TabIndex = 90;
			lblFax.Text = "Fax:";
			// 
			// schoutLabel
			// 
			schoutLabel.AutoSize = true;
			schoutLabel.Location = new System.Drawing.Point(343, 333);
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
			schcolorsLabel.Location = new System.Drawing.Point(256, 417);
			schcolorsLabel.Name = "schcolorsLabel";
			schcolorsLabel.Size = new System.Drawing.Size(75, 13);
			schcolorsLabel.TabIndex = 27;
			schcolorsLabel.Text = "School Colors:";
			// 
			// lblCategory
			// 
			lblCategory.AutoSize = true;
			lblCategory.Location = new System.Drawing.Point(243, 392);
			lblCategory.Name = "lblCategory";
			lblCategory.Size = new System.Drawing.Size(88, 13);
			lblCategory.TabIndex = 24;
			lblCategory.Text = "School Category:";
			// 
			// gradesLabel
			// 
			gradesLabel.AutoSize = true;
			gradesLabel.Location = new System.Drawing.Point(47, 417);
			gradesLabel.Name = "gradesLabel";
			gradesLabel.Size = new System.Drawing.Size(44, 13);
			gradesLabel.TabIndex = 34;
			gradesLabel.Text = "Grades:";
			// 
			// norebookreasonLabel
			// 
			norebookreasonLabel.AutoSize = true;
			norebookreasonLabel.Location = new System.Drawing.Point(11, 272);
			norebookreasonLabel.Name = "norebookreasonLabel";
			norebookreasonLabel.Size = new System.Drawing.Size(80, 13);
			norebookreasonLabel.TabIndex = 12;
			norebookreasonLabel.Text = "Not Rebooked:";
			// 
			// prevpublisherLabel
			// 
			prevpublisherLabel.AutoSize = true;
			prevpublisherLabel.Location = new System.Drawing.Point(16, 332);
			prevpublisherLabel.Name = "prevpublisherLabel";
			prevpublisherLabel.Size = new System.Drawing.Size(75, 13);
			prevpublisherLabel.TabIndex = 20;
			prevpublisherLabel.Text = "Prev Publisher";
			// 
			// enrollmentLabel1
			// 
			enrollmentLabel1.AutoSize = true;
			enrollmentLabel1.Location = new System.Drawing.Point(32, 392);
			enrollmentLabel1.Name = "enrollmentLabel1";
			enrollmentLabel1.Size = new System.Drawing.Size(59, 13);
			enrollmentLabel1.TabIndex = 30;
			enrollmentLabel1.Text = "Enrollment:";
			// 
			// newpublisherLabel1
			// 
			newpublisherLabel1.AutoSize = true;
			newpublisherLabel1.Location = new System.Drawing.Point(13, 299);
			newpublisherLabel1.Name = "newpublisherLabel1";
			newpublisherLabel1.Size = new System.Drawing.Size(78, 13);
			newpublisherLabel1.TabIndex = 16;
			newpublisherLabel1.Text = "New Publisher:";
			// 
			// newpublisherLabel
			// 
			newpublisherLabel.AutoSize = true;
			newpublisherLabel.Location = new System.Drawing.Point(257, 364);
			newpublisherLabel.Name = "newpublisherLabel";
			newpublisherLabel.Size = new System.Drawing.Size(74, 13);
			newpublisherLabel.TabIndex = 22;
			newpublisherLabel.Text = "Photographer:";
			// 
			// clrpg_intLabel
			// 
			clrpg_intLabel.AutoSize = true;
			clrpg_intLabel.Location = new System.Drawing.Point(256, 332);
			clrpg_intLabel.Name = "clrpg_intLabel";
			clrpg_intLabel.Size = new System.Drawing.Size(36, 13);
			clrpg_intLabel.TabIndex = 22;
			clrpg_intLabel.Text = "Prints:";
			// 
			// enrollmentLabel
			// 
			enrollmentLabel.AutoSize = true;
			enrollmentLabel.Location = new System.Drawing.Point(20, 241);
			enrollmentLabel.Name = "enrollmentLabel";
			enrollmentLabel.Size = new System.Drawing.Size(71, 13);
			enrollmentLabel.TabIndex = 59;
			enrollmentLabel.Text = "Spring Break:";
			// 
			// schphoneLabel
			// 
			schphoneLabel.AutoSize = true;
			schphoneLabel.Location = new System.Drawing.Point(202, 176);
			schphoneLabel.Name = "schphoneLabel";
			schphoneLabel.Size = new System.Drawing.Size(41, 13);
			schphoneLabel.TabIndex = 42;
			schphoneLabel.Text = "Phone:";
			// 
			// schaddrLabel
			// 
			schaddrLabel.AutoSize = true;
			schaddrLabel.Location = new System.Drawing.Point(3, 124);
			schaddrLabel.Name = "schaddrLabel";
			schaddrLabel.Size = new System.Drawing.Size(48, 13);
			schaddrLabel.TabIndex = 32;
			schaddrLabel.Text = "Address:";
			// 
			// schzipLabel
			// 
			schzipLabel.AutoSize = true;
			schzipLabel.Location = new System.Drawing.Point(26, 176);
			schzipLabel.Name = "schzipLabel";
			schzipLabel.Size = new System.Drawing.Size(25, 13);
			schzipLabel.TabIndex = 40;
			schzipLabel.Text = "Zip:";
			// 
			// schstateLabel
			// 
			schstateLabel.AutoSize = true;
			schstateLabel.Location = new System.Drawing.Point(267, 150);
			schstateLabel.Name = "schstateLabel";
			schstateLabel.Size = new System.Drawing.Size(35, 13);
			schstateLabel.TabIndex = 38;
			schstateLabel.Text = "State:";
			// 
			// schaddr2Label
			// 
			schaddr2Label.AutoSize = true;
			schaddr2Label.Location = new System.Drawing.Point(248, 124);
			schaddr2Label.Name = "schaddr2Label";
			schaddr2Label.Size = new System.Drawing.Size(54, 13);
			schaddr2Label.TabIndex = 34;
			schaddr2Label.Text = "Address2:";
			// 
			// schcityLabel
			// 
			schcityLabel.AutoSize = true;
			schcityLabel.Location = new System.Drawing.Point(24, 150);
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
			// contmemoLabel
			// 
			contmemoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			contmemoLabel.AutoSize = true;
			contmemoLabel.Location = new System.Drawing.Point(46, 580);
			contmemoLabel.Name = "contmemoLabel";
			contmemoLabel.Size = new System.Drawing.Size(39, 13);
			contmemoLabel.TabIndex = 76;
			contmemoLabel.Text = "Memo:";
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
			contdateLabel.Location = new System.Drawing.Point(20, 35);
			contdateLabel.Name = "contdateLabel";
			contdateLabel.Size = new System.Drawing.Size(70, 13);
			contdateLabel.TabIndex = 96;
			contdateLabel.Text = "ContactDate:";
			// 
			// sourdateLabel
			// 
			sourdateLabel.AutoSize = true;
			sourdateLabel.Location = new System.Drawing.Point(297, 39);
			sourdateLabel.Name = "sourdateLabel";
			sourdateLabel.Size = new System.Drawing.Size(42, 13);
			sourdateLabel.TabIndex = 96;
			sourdateLabel.Text = "Sample";
			// 
			// initcontLabel
			// 
			initcontLabel.AutoSize = true;
			initcontLabel.Location = new System.Drawing.Point(19, 61);
			initcontLabel.Name = "initcontLabel";
			initcontLabel.Size = new System.Drawing.Size(71, 13);
			initcontLabel.TabIndex = 97;
			initcontLabel.Text = "Initial Contact";
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
			this.splitContainer.Panel1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer.Panel1.Controls.Add(initcontLabel);
			this.splitContainer.Panel1.Controls.Add(this.initcontDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(sourdateLabel);
			this.splitContainer.Panel1.Controls.Add(this.sourdateDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(contdateLabel);
			this.splitContainer.Panel1.Controls.Add(this.contdateDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(oraclecodeLabel);
			this.splitContainer.Panel1.Controls.Add(this.oraclecodeTextBox);
			this.splitContainer.Panel1.Controls.Add(contryearLabel);
			this.splitContainer.Panel1.Controls.Add(junsnoLabel);
			this.splitContainer.Panel1.Controls.Add(this.contryearTextBox);
			this.splitContainer.Panel1.Controls.Add(this.txtSchname);
			this.splitContainer.Panel1.Controls.Add(this.lblSchcodeVal);
			this.splitContainer.Panel1.Controls.Add(this.junsnoTextBox);
			this.splitContainer.Panel1.Controls.Add(lblEmail);
			this.splitContainer.Panel1.Controls.Add(this.txtSchColors);
			this.splitContainer.Panel1.Controls.Add(this.txtFax);
			this.splitContainer.Panel1.Controls.Add(lblFax);
			this.splitContainer.Panel1.Controls.Add(csrepLabel);
			this.splitContainer.Panel1.Controls.Add(this.label2);
			this.splitContainer.Panel1.Controls.Add(this.txtCsRep);
			this.splitContainer.Panel1.Controls.Add(this.lblSchName);
			this.splitContainer.Panel1.Controls.Add(schoutLabel);
			this.splitContainer.Panel1.Controls.Add(this.schoutDateTimePicker);
			this.splitContainer.Panel1.Controls.Add(schcolorsLabel);
			this.splitContainer.Panel1.Controls.Add(this.cmbSchCategory);
			this.splitContainer.Panel1.Controls.Add(this.cmbNoRebook);
			this.splitContainer.Panel1.Controls.Add(this.cmbPrevPublisher);
			this.splitContainer.Panel1.Controls.Add(lblCategory);
			this.splitContainer.Panel1.Controls.Add(this.cmbNewPublisher);
			this.splitContainer.Panel1.Controls.Add(this.multiyearCheckBox);
			this.splitContainer.Panel1.Controls.Add(gradesLabel);
			this.splitContainer.Panel1.Controls.Add(norebookreasonLabel);
			this.splitContainer.Panel1.Controls.Add(this.gradesTextBox);
			this.splitContainer.Panel1.Controls.Add(prevpublisherLabel);
			this.splitContainer.Panel1.Controls.Add(enrollmentLabel1);
			this.splitContainer.Panel1.Controls.Add(newpublisherLabel1);
			this.splitContainer.Panel1.Controls.Add(this.enrollmentTextBox);
			this.splitContainer.Panel1.Controls.Add(newpublisherLabel);
			this.splitContainer.Panel1.Controls.Add(this.txtPhotographer);
			this.splitContainer.Panel1.Controls.Add(this.multiyearComboBox);
			this.splitContainer.Panel1.Controls.Add(clrpg_intLabel);
			this.splitContainer.Panel1.Controls.Add(this.clrpg_intTextBox);
			this.splitContainer.Panel1.Controls.Add(this.schuploadingCheckBox);
			this.splitContainer.Panel1.Controls.Add(this.blkwhiteCheckBox);
			this.splitContainer.Panel1.Controls.Add(this.allcolorCheckBox);
			this.splitContainer.Panel1.Controls.Add(this.sprinfoCheckBox);
			this.splitContainer.Panel1.Controls.Add(this.fallinfoCheckBox);
			this.splitContainer.Panel1.Controls.Add(this.clspicCheckBox);
			this.splitContainer.Panel1.Controls.Add(enrollmentLabel);
			this.splitContainer.Panel1.Controls.Add(this.springbreakTextBox);
			this.splitContainer.Panel1.Controls.Add(this.txtWebsite);
			this.splitContainer.Panel1.Controls.Add(this.btnWebsite);
			this.splitContainer.Panel1.Controls.Add(this.txtSchEmail);
			this.splitContainer.Panel1.Controls.Add(this.cmbState);
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
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.BackColor = System.Drawing.Color.Transparent;
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
			this.splitContainer.Size = new System.Drawing.Size(1223, 593);
			this.splitContainer.SplitterDistance = 599;
			this.splitContainer.SplitterWidth = 2;
			this.splitContainer.TabIndex = 65;
			// 
			// initcontDateTimePicker
			// 
			this.initcontDateTimePicker.CustomFormat = "\'\'";
			this.initcontDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.custBindingSource, "initcont", true));
			this.initcontDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.initcontDateTimePicker.Location = new System.Drawing.Point(92, 61);
			this.initcontDateTimePicker.Name = "initcontDateTimePicker";
			this.initcontDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.initcontDateTimePicker.TabIndex = 98;
			this.initcontDateTimePicker.ValueChanged += new System.EventHandler(this.initcontDateTimePicker_ValueChanged);
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
			// sourdateDateTimePicker
			// 
			this.sourdateDateTimePicker.CustomFormat = "\'\'";
			this.sourdateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.custBindingSource, "sourdate", true));
			this.sourdateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.sourdateDateTimePicker.Location = new System.Drawing.Point(354, 35);
			this.sourdateDateTimePicker.Name = "sourdateDateTimePicker";
			this.sourdateDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.sourdateDateTimePicker.TabIndex = 97;
			this.sourdateDateTimePicker.ValueChanged += new System.EventHandler(this.sourdateDateTimePicker_ValueChanged);
			// 
			// contdateDateTimePicker
			// 
			this.contdateDateTimePicker.CustomFormat = "\'\'";
			this.contdateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.custBindingSource, "contdate", true));
			this.contdateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.contdateDateTimePicker.Location = new System.Drawing.Point(92, 35);
			this.contdateDateTimePicker.Name = "contdateDateTimePicker";
			this.contdateDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.contdateDateTimePicker.TabIndex = 95;
			this.contdateDateTimePicker.ValueChanged += new System.EventHandler(this.contdateDateTimePicker_ValueChanged_1);
			// 
			// oraclecodeTextBox
			// 
			this.oraclecodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "oraclecode", true));
			this.oraclecodeTextBox.Location = new System.Drawing.Point(366, 5);
			this.oraclecodeTextBox.Name = "oraclecodeTextBox";
			this.oraclecodeTextBox.Size = new System.Drawing.Size(100, 20);
			this.oraclecodeTextBox.TabIndex = 94;
			// 
			// contryearTextBox
			// 
			this.contryearTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contryear", true));
			this.contryearTextBox.Location = new System.Drawing.Point(551, 8);
			this.contryearTextBox.MaxLength = 2;
			this.contryearTextBox.Name = "contryearTextBox";
			this.contryearTextBox.Size = new System.Drawing.Size(45, 20);
			this.contryearTextBox.TabIndex = 5;
			// 
			// txtSchname
			// 
			this.txtSchname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schname", true));
			this.txtSchname.Location = new System.Drawing.Point(83, 92);
			this.txtSchname.Name = "txtSchname";
			this.txtSchname.ReadOnly = true;
			this.txtSchname.Size = new System.Drawing.Size(249, 20);
			this.txtSchname.TabIndex = 0;
			this.txtSchname.DoubleClick += new System.EventHandler(this.txtSchname_DoubleClick);
			// 
			// lblSchcodeVal
			// 
			this.lblSchcodeVal.AutoSize = true;
			this.lblSchcodeVal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schcode", true));
			this.lblSchcodeVal.Location = new System.Drawing.Point(412, 92);
			this.lblSchcodeVal.Name = "lblSchcodeVal";
			this.lblSchcodeVal.Size = new System.Drawing.Size(41, 13);
			this.lblSchcodeVal.TabIndex = 2;
			this.lblSchcodeVal.Text = "label29";
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
			this.txtSchColors.Location = new System.Drawing.Point(334, 417);
			this.txtSchColors.Name = "txtSchColors";
			this.txtSchColors.Size = new System.Drawing.Size(182, 20);
			this.txtSchColors.TabIndex = 28;
			// 
			// txtFax
			// 
			this.txtFax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schfax", true));
			this.txtFax.Location = new System.Drawing.Point(420, 177);
			this.txtFax.MaxLength = 25;
			this.txtFax.Name = "txtFax";
			this.txtFax.Size = new System.Drawing.Size(95, 20);
			this.txtFax.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(341, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "School Code:";
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
			this.txtCsRep.Validating += new System.ComponentModel.CancelEventHandler(this.txtCsRep_Validating);
			this.txtCsRep.Validated += new System.EventHandler(this.txtCsRep_Validated);
			// 
			// lblSchName
			// 
			this.lblSchName.AutoSize = true;
			this.lblSchName.Location = new System.Drawing.Point(10, 92);
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
			this.schoutDateTimePicker.Location = new System.Drawing.Point(395, 329);
			this.schoutDateTimePicker.Name = "schoutDateTimePicker";
			this.schoutDateTimePicker.Size = new System.Drawing.Size(184, 20);
			this.schoutDateTimePicker.TabIndex = 18;
			this.schoutDateTimePicker.ValueChanged += new System.EventHandler(this.schoutDateTimePicker_ValueChanged);
			// 
			// cmbSchCategory
			// 
			this.cmbSchCategory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "sal", true));
			this.cmbSchCategory.FormattingEnabled = true;
			this.cmbSchCategory.Location = new System.Drawing.Point(334, 392);
			this.cmbSchCategory.Name = "cmbSchCategory";
			this.cmbSchCategory.Size = new System.Drawing.Size(182, 21);
			this.cmbSchCategory.TabIndex = 25;
			// 
			// cmbNoRebook
			// 
			this.cmbNoRebook.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "norebookreason", true));
			this.cmbNoRebook.FormattingEnabled = true;
			this.cmbNoRebook.Location = new System.Drawing.Point(97, 272);
			this.cmbNoRebook.Name = "cmbNoRebook";
			this.cmbNoRebook.Size = new System.Drawing.Size(139, 21);
			this.cmbNoRebook.TabIndex = 13;
			// 
			// cmbPrevPublisher
			// 
			this.cmbPrevPublisher.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "prevpublisher", true));
			this.cmbPrevPublisher.FormattingEnabled = true;
			this.cmbPrevPublisher.Location = new System.Drawing.Point(95, 332);
			this.cmbPrevPublisher.Name = "cmbPrevPublisher";
			this.cmbPrevPublisher.Size = new System.Drawing.Size(139, 21);
			this.cmbPrevPublisher.TabIndex = 17;
			// 
			// cmbNewPublisher
			// 
			this.cmbNewPublisher.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "newpublisher", true));
			this.cmbNewPublisher.FormattingEnabled = true;
			this.cmbNewPublisher.Location = new System.Drawing.Point(97, 299);
			this.cmbNewPublisher.Name = "cmbNewPublisher";
			this.cmbNewPublisher.Size = new System.Drawing.Size(139, 21);
			this.cmbNewPublisher.TabIndex = 15;
			// 
			// multiyearCheckBox
			// 
			this.multiyearCheckBox.AutoSize = true;
			this.multiyearCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "multiyear", true));
			this.multiyearCheckBox.Location = new System.Drawing.Point(21, 363);
			this.multiyearCheckBox.Name = "multiyearCheckBox";
			this.multiyearCheckBox.Size = new System.Drawing.Size(70, 17);
			this.multiyearCheckBox.TabIndex = 26;
			this.multiyearCheckBox.Text = "MultiYear";
			this.multiyearCheckBox.UseVisualStyleBackColor = true;
			// 
			// gradesTextBox
			// 
			this.gradesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "grades", true));
			this.gradesTextBox.Location = new System.Drawing.Point(95, 417);
			this.gradesTextBox.MaxLength = 16;
			this.gradesTextBox.Name = "gradesTextBox";
			this.gradesTextBox.Size = new System.Drawing.Size(139, 20);
			this.gradesTextBox.TabIndex = 26;
			// 
			// enrollmentTextBox
			// 
			this.enrollmentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "enrollment", true));
			this.enrollmentTextBox.Location = new System.Drawing.Point(97, 392);
			this.enrollmentTextBox.MaxLength = 5;
			this.enrollmentTextBox.Name = "enrollmentTextBox";
			this.enrollmentTextBox.Size = new System.Drawing.Size(137, 20);
			this.enrollmentTextBox.TabIndex = 23;
			// 
			// txtPhotographer
			// 
			this.txtPhotographer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "photographer", true));
			this.txtPhotographer.Location = new System.Drawing.Point(334, 364);
			this.txtPhotographer.MaxLength = 45;
			this.txtPhotographer.Name = "txtPhotographer";
			this.txtPhotographer.Size = new System.Drawing.Size(182, 20);
			this.txtPhotographer.TabIndex = 21;
			// 
			// multiyearComboBox
			// 
			this.multiyearComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "multiyear", true));
			this.multiyearComboBox.FormattingEnabled = true;
			this.multiyearComboBox.Location = new System.Drawing.Point(97, 363);
			this.multiyearComboBox.Name = "multiyearComboBox";
			this.multiyearComboBox.Size = new System.Drawing.Size(139, 21);
			this.multiyearComboBox.TabIndex = 20;
			// 
			// clrpg_intTextBox
			// 
			this.clrpg_intTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "clrpg_int", true));
			this.clrpg_intTextBox.Location = new System.Drawing.Point(300, 329);
			this.clrpg_intTextBox.MaxLength = 1;
			this.clrpg_intTextBox.Name = "clrpg_intTextBox";
			this.clrpg_intTextBox.Size = new System.Drawing.Size(29, 20);
			this.clrpg_intTextBox.TabIndex = 19;
			// 
			// schuploadingCheckBox
			// 
			this.schuploadingCheckBox.AutoSize = true;
			this.schuploadingCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "schuploading", true));
			this.schuploadingCheckBox.Location = new System.Drawing.Point(395, 299);
			this.schuploadingCheckBox.Name = "schuploadingCheckBox";
			this.schuploadingCheckBox.Size = new System.Drawing.Size(121, 17);
			this.schuploadingCheckBox.TabIndex = 16;
			this.schuploadingCheckBox.Text = "School Is Uploading";
			this.schuploadingCheckBox.UseVisualStyleBackColor = true;
			// 
			// blkwhiteCheckBox
			// 
			this.blkwhiteCheckBox.AutoSize = true;
			this.blkwhiteCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "blkwhite", true));
			this.blkwhiteCheckBox.Location = new System.Drawing.Point(395, 272);
			this.blkwhiteCheckBox.Name = "blkwhiteCheckBox";
			this.blkwhiteCheckBox.Size = new System.Drawing.Size(86, 17);
			this.blkwhiteCheckBox.TabIndex = 14;
			this.blkwhiteCheckBox.Text = "Black/White";
			this.blkwhiteCheckBox.UseVisualStyleBackColor = true;
			// 
			// allcolorCheckBox
			// 
			this.allcolorCheckBox.AutoSize = true;
			this.allcolorCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "allcolor", true));
			this.allcolorCheckBox.Location = new System.Drawing.Point(395, 241);
			this.allcolorCheckBox.Name = "allcolorCheckBox";
			this.allcolorCheckBox.Size = new System.Drawing.Size(64, 17);
			this.allcolorCheckBox.TabIndex = 12;
			this.allcolorCheckBox.Text = "All Color";
			this.allcolorCheckBox.UseVisualStyleBackColor = true;
			// 
			// sprinfoCheckBox
			// 
			this.sprinfoCheckBox.AutoSize = true;
			this.sprinfoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.custBindingSource, "sprinfo", true));
			this.sprinfoCheckBox.Location = new System.Drawing.Point(279, 299);
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
			this.fallinfoCheckBox.Location = new System.Drawing.Point(279, 272);
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
			this.clspicCheckBox.Location = new System.Drawing.Point(279, 241);
			this.clspicCheckBox.Name = "clspicCheckBox";
			this.clspicCheckBox.Size = new System.Drawing.Size(109, 17);
			this.clspicCheckBox.TabIndex = 10;
			this.clspicCheckBox.Text = "Class Pic\'s on CD";
			this.clspicCheckBox.UseVisualStyleBackColor = true;
			// 
			// springbreakTextBox
			// 
			this.springbreakTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "sprngbrk", true));
			this.springbreakTextBox.Location = new System.Drawing.Point(97, 241);
			this.springbreakTextBox.MaxLength = 25;
			this.springbreakTextBox.Name = "springbreakTextBox";
			this.springbreakTextBox.Size = new System.Drawing.Size(139, 20);
			this.springbreakTextBox.TabIndex = 11;
			// 
			// txtWebsite
			// 
			this.txtWebsite.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "website", true));
			this.txtWebsite.Location = new System.Drawing.Point(366, 203);
			this.txtWebsite.MaxLength = 60;
			this.txtWebsite.Name = "txtWebsite";
			this.txtWebsite.Size = new System.Drawing.Size(188, 20);
			this.txtWebsite.TabIndex = 10;
			// 
			// btnWebsite
			// 
			this.btnWebsite.AutoSize = true;
			this.btnWebsite.Location = new System.Drawing.Point(285, 201);
			this.btnWebsite.Name = "btnWebsite";
			this.btnWebsite.Size = new System.Drawing.Size(80, 23);
			this.btnWebsite.TabIndex = 7;
			this.btnWebsite.Text = "Website";
			this.btnWebsite.UseVisualStyleBackColor = true;
			// 
			// txtSchEmail
			// 
			this.txtSchEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schemail", true));
			this.txtSchEmail.Location = new System.Drawing.Point(91, 202);
			this.txtSchEmail.MaxLength = 80;
			this.txtSchEmail.Name = "txtSchEmail";
			this.txtSchEmail.Size = new System.Drawing.Size(188, 20);
			this.txtSchEmail.TabIndex = 9;
			// 
			// cmbState
			// 
			this.cmbState.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.statesBindingSource, "Name", true));
			this.cmbState.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "schstate", true));
			this.cmbState.DataSource = this.statesBindingSource;
			this.cmbState.DisplayMember = "Name";
			this.cmbState.FormattingEnabled = true;
			this.cmbState.Location = new System.Drawing.Point(309, 148);
			this.cmbState.Name = "cmbState";
			this.cmbState.Size = new System.Drawing.Size(206, 21);
			this.cmbState.TabIndex = 6;
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
			// txtaddress
			// 
			this.txtaddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schaddr", true));
			this.txtaddress.Location = new System.Drawing.Point(57, 124);
			this.txtaddress.MaxLength = 35;
			this.txtaddress.Name = "txtaddress";
			this.txtaddress.Size = new System.Drawing.Size(183, 20);
			this.txtaddress.TabIndex = 3;
			// 
			// txtSchPhone
			// 
			this.txtSchPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schphone", true));
			this.txtSchPhone.Location = new System.Drawing.Point(245, 176);
			this.txtSchPhone.MaxLength = 25;
			this.txtSchPhone.Name = "txtSchPhone";
			this.txtSchPhone.Size = new System.Drawing.Size(95, 20);
			this.txtSchPhone.TabIndex = 7;
			// 
			// txtZip
			// 
			this.txtZip.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schzip", true));
			this.txtZip.Location = new System.Drawing.Point(57, 176);
			this.txtZip.MaxLength = 10;
			this.txtZip.Name = "txtZip";
			this.txtZip.Size = new System.Drawing.Size(45, 20);
			this.txtZip.TabIndex = 41;
			// 
			// txtAddress2
			// 
			this.txtAddress2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schaddr2", true));
			this.txtAddress2.Location = new System.Drawing.Point(308, 124);
			this.txtAddress2.MaxLength = 35;
			this.txtAddress2.Name = "txtAddress2";
			this.txtAddress2.Size = new System.Drawing.Size(207, 20);
			this.txtAddress2.TabIndex = 4;
			// 
			// txtCity
			// 
			this.txtCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schcity", true));
			this.txtCity.Location = new System.Drawing.Point(57, 150);
			this.txtCity.MaxLength = 21;
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(183, 20);
			this.txtCity.TabIndex = 5;
			// 
			// lblInvno
			// 
			this.lblInvno.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "invno", true));
			this.lblInvno.ForeColor = System.Drawing.SystemColors.Control;
			this.lblInvno.Location = new System.Drawing.Point(24, 336);
			this.lblInvno.Name = "lblInvno";
			this.lblInvno.Size = new System.Drawing.Size(1, 1);
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
            this.dataGridViewTextBoxColumn106,
            this.dataGridViewTextBoxColumn107,
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
			this.custDataGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.custDataGridView_RowHeaderMouseDoubleClick);
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
			// dataGridViewTextBoxColumn106
			// 
			this.dataGridViewTextBoxColumn106.DataPropertyName = "Qyear";
			this.dataGridViewTextBoxColumn106.HeaderText = "Year";
			this.dataGridViewTextBoxColumn106.Name = "dataGridViewTextBoxColumn106";
			this.dataGridViewTextBoxColumn106.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn107
			// 
			this.dataGridViewTextBoxColumn107.DataPropertyName = "invno";
			this.dataGridViewTextBoxColumn107.HeaderText = "Invoice#";
			this.dataGridViewTextBoxColumn107.Name = "dataGridViewTextBoxColumn107";
			this.dataGridViewTextBoxColumn107.ReadOnly = true;
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
			this.pnlHead.Controls.Add(this.btnOracleSrch);
			this.pnlHead.Controls.Add(this.txtOracleCodeSrch);
			this.pnlHead.Controls.Add(this.btnSchoolSearch);
			this.pnlHead.Controls.Add(this.txtSchNamesrch);
			this.pnlHead.Controls.Add(this.btnSchoolCode);
			this.pnlHead.Controls.Add(this.txtSchCodesrch);
			this.pnlHead.Location = new System.Drawing.Point(0, 0);
			this.pnlHead.Name = "pnlHead";
			this.pnlHead.Size = new System.Drawing.Size(1226, 38);
			this.pnlHead.TabIndex = 64;
			// 
			// btnOracleSrch
			// 
			this.btnOracleSrch.Location = new System.Drawing.Point(501, 7);
			this.btnOracleSrch.Name = "btnOracleSrch";
			this.btnOracleSrch.Size = new System.Drawing.Size(75, 23);
			this.btnOracleSrch.TabIndex = 8;
			this.btnOracleSrch.Text = "Oracle Code ";
			this.btnOracleSrch.UseVisualStyleBackColor = true;
			this.btnOracleSrch.Click += new System.EventHandler(this.btnOracleSrch_Click);
			// 
			// txtOracleCodeSrch
			// 
			this.txtOracleCodeSrch.Location = new System.Drawing.Point(582, 7);
			this.txtOracleCodeSrch.MaxLength = 6;
			this.txtOracleCodeSrch.Name = "txtOracleCodeSrch";
			this.txtOracleCodeSrch.Size = new System.Drawing.Size(82, 20);
			this.txtOracleCodeSrch.TabIndex = 7;
			// 
			// btnSchoolSearch
			// 
			this.btnSchoolSearch.Location = new System.Drawing.Point(3, 8);
			this.btnSchoolSearch.Name = "btnSchoolSearch";
			this.btnSchoolSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSchoolSearch.TabIndex = 0;
			this.btnSchoolSearch.Text = "School";
			this.btnSchoolSearch.UseVisualStyleBackColor = true;
			this.btnSchoolSearch.Click += new System.EventHandler(this.btnSchoolSearch_Click);
			// 
			// txtSchNamesrch
			// 
			this.txtSchNamesrch.Location = new System.Drawing.Point(84, 8);
			this.txtSchNamesrch.MaxLength = 34;
			this.txtSchNamesrch.Name = "txtSchNamesrch";
			this.txtSchNamesrch.Size = new System.Drawing.Size(230, 20);
			this.txtSchNamesrch.TabIndex = 0;
			// 
			// btnSchoolCode
			// 
			this.btnSchoolCode.Location = new System.Drawing.Point(333, 8);
			this.btnSchoolCode.Name = "btnSchoolCode";
			this.btnSchoolCode.Size = new System.Drawing.Size(75, 23);
			this.btnSchoolCode.TabIndex = 2;
			this.btnSchoolCode.Text = "Code";
			this.btnSchoolCode.UseVisualStyleBackColor = true;
			this.btnSchoolCode.Click += new System.EventHandler(this.btnSchoolCode_Click);
			// 
			// txtSchCodesrch
			// 
			this.txtSchCodesrch.Location = new System.Drawing.Point(414, 8);
			this.txtSchCodesrch.MaxLength = 6;
			this.txtSchCodesrch.Name = "txtSchCodesrch";
			this.txtSchCodesrch.Size = new System.Drawing.Size(69, 20);
			this.txtSchCodesrch.TabIndex = 1;
			// 
			// pg2
			// 
			this.pg2.BackColor = System.Drawing.SystemColors.Control;
			this.pg2.Controls.Add(contmemoLabel);
			this.pg2.Controls.Add(this.contmemoTextBox);
			this.pg2.Controls.Add(this.label17);
			this.pg2.Controls.Add(this.btnEmailContac3);
			this.pg2.Controls.Add(this.btnEmailCont2);
			this.pg2.Controls.Add(this.btnEmailContact);
			this.pg2.Controls.Add(this.label16);
			this.pg2.Controls.Add(this.comboBox6);
			this.pg2.Controls.Add(label18);
			this.pg2.Controls.Add(this.textBox3);
			this.pg2.Controls.Add(label19);
			this.pg2.Controls.Add(this.textBox10);
			this.pg2.Controls.Add(label20);
			this.pg2.Controls.Add(this.textBox11);
			this.pg2.Controls.Add(label21);
			this.pg2.Controls.Add(this.txtContact3Email);
			this.pg2.Controls.Add(label22);
			this.pg2.Controls.Add(this.textBox13);
			this.pg2.Controls.Add(label23);
			this.pg2.Controls.Add(this.textBox14);
			this.pg2.Controls.Add(label24);
			this.pg2.Controls.Add(this.textBox15);
			this.pg2.Controls.Add(label25);
			this.pg2.Controls.Add(label26);
			this.pg2.Controls.Add(this.textBox16);
			this.pg2.Controls.Add(label27);
			this.pg2.Controls.Add(this.textBox17);
			this.pg2.Controls.Add(this.label28);
			this.pg2.Controls.Add(this.label15);
			this.pg2.Controls.Add(this.label14);
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
			// contmemoTextBox
			// 
			this.contmemoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.contmemoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contmemo", true));
			this.contmemoTextBox.Location = new System.Drawing.Point(91, 580);
			this.contmemoTextBox.Multiline = true;
			this.contmemoTextBox.Name = "contmemoTextBox";
			this.contmemoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.contmemoTextBox.Size = new System.Drawing.Size(575, 42);
			this.contmemoTextBox.TabIndex = 32;
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label17.Location = new System.Drawing.Point(-23, 601);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(1182, 3);
			this.label17.TabIndex = 76;
			// 
			// btnEmailContac3
			// 
			this.btnEmailContac3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnEmailContac3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEmailContac3.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailContac3.Image")));
			this.btnEmailContac3.Location = new System.Drawing.Point(24, 405);
			this.btnEmailContac3.Name = "btnEmailContac3";
			this.btnEmailContac3.Size = new System.Drawing.Size(34, 23);
			this.btnEmailContac3.TabIndex = 75;
			this.btnEmailContac3.UseVisualStyleBackColor = true;
			this.btnEmailContac3.Click += new System.EventHandler(this.btnEmailContac3_Click);
			// 
			// btnEmailCont2
			// 
			this.btnEmailCont2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnEmailCont2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEmailCont2.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailCont2.Image")));
			this.btnEmailCont2.Location = new System.Drawing.Point(24, 206);
			this.btnEmailCont2.Name = "btnEmailCont2";
			this.btnEmailCont2.Size = new System.Drawing.Size(34, 23);
			this.btnEmailCont2.TabIndex = 74;
			this.btnEmailCont2.UseVisualStyleBackColor = true;
			this.btnEmailCont2.Click += new System.EventHandler(this.btnEmailCont2_Click);
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
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(87, 405);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(97, 24);
			this.label16.TabIndex = 72;
			this.label16.Text = "Contact 3";
			// 
			// comboBox6
			// 
			this.comboBox6.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "ccontstate", true));
			this.comboBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.statesBindingSource, "Name", true));
			this.comboBox6.DataSource = this.statesBindingSource;
			this.comboBox6.DisplayMember = "Name";
			this.comboBox6.FormattingEnabled = true;
			this.comboBox6.Location = new System.Drawing.Point(91, 488);
			this.comboBox6.Name = "comboBox6";
			this.comboBox6.Size = new System.Drawing.Size(232, 21);
			this.comboBox6.TabIndex = 26;
			this.comboBox6.ValueMember = "Abrev";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontphnhom", true));
			this.textBox3.Location = new System.Drawing.Point(385, 515);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(232, 20);
			this.textBox3.TabIndex = 29;
			// 
			// textBox10
			// 
			this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontlname", true));
			this.textBox10.Location = new System.Drawing.Point(385, 436);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(232, 20);
			this.textBox10.TabIndex = 23;
			// 
			// textBox11
			// 
			this.textBox11.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontfname", true));
			this.textBox11.Location = new System.Drawing.Point(91, 436);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(232, 20);
			this.textBox11.TabIndex = 22;
			// 
			// txtContact3Email
			// 
			this.txtContact3Email.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontemail", true));
			this.txtContact3Email.Location = new System.Drawing.Point(91, 567);
			this.txtContact3Email.Name = "txtContact3Email";
			this.txtContact3Email.Size = new System.Drawing.Size(328, 20);
			this.txtContact3Email.TabIndex = 31;
			// 
			// textBox13
			// 
			this.textBox13.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontfax", true));
			this.textBox13.Location = new System.Drawing.Point(91, 541);
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(232, 20);
			this.textBox13.TabIndex = 30;
			// 
			// textBox14
			// 
			this.textBox14.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontphnwrk", true));
			this.textBox14.Location = new System.Drawing.Point(91, 515);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(232, 20);
			this.textBox14.TabIndex = 28;
			// 
			// textBox15
			// 
			this.textBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox15.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontzip", true));
			this.textBox15.Location = new System.Drawing.Point(385, 488);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(232, 20);
			this.textBox15.TabIndex = 27;
			// 
			// textBox16
			// 
			this.textBox16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox16.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontaddr2", true));
			this.textBox16.Location = new System.Drawing.Point(385, 462);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(232, 20);
			this.textBox16.TabIndex = 25;
			// 
			// textBox17
			// 
			this.textBox17.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontaddr", true));
			this.textBox17.Location = new System.Drawing.Point(91, 462);
			this.textBox17.Name = "textBox17";
			this.textBox17.Size = new System.Drawing.Size(232, 20);
			this.textBox17.TabIndex = 24;
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
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(87, 203);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(97, 24);
			this.label15.TabIndex = 48;
			this.label15.Text = "Contact 2";
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
			// comboBox3
			// 
			this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "bposition", true));
			this.comboBox3.DisplayMember = "Position";
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(385, 335);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(232, 21);
			this.comboBox3.TabIndex = 20;
			this.comboBox3.ValueMember = "Position";
			// 
			// comboBox4
			// 
			this.comboBox4.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.custBindingSource, "bcontstate", true));
			this.comboBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.statesBindingSource, "Name", true));
			this.comboBox4.DataSource = this.statesBindingSource;
			this.comboBox4.DisplayMember = "Name";
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Location = new System.Drawing.Point(91, 282);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(232, 21);
			this.comboBox4.TabIndex = 15;
			this.comboBox4.ValueMember = "Abrev";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontphnhom", true));
			this.textBox1.Location = new System.Drawing.Point(385, 309);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(232, 20);
			this.textBox1.TabIndex = 18;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontlname", true));
			this.textBox2.Location = new System.Drawing.Point(385, 230);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(232, 20);
			this.textBox2.TabIndex = 12;
			// 
			// txtBContFname
			// 
			this.txtBContFname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontfname", true));
			this.txtBContFname.Location = new System.Drawing.Point(91, 230);
			this.txtBContFname.Name = "txtBContFname";
			this.txtBContFname.Size = new System.Drawing.Size(232, 20);
			this.txtBContFname.TabIndex = 11;
			// 
			// txtContact2Email
			// 
			this.txtContact2Email.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontemail", true));
			this.txtContact2Email.Location = new System.Drawing.Point(91, 361);
			this.txtContact2Email.Name = "txtContact2Email";
			this.txtContact2Email.Size = new System.Drawing.Size(328, 20);
			this.txtContact2Email.TabIndex = 21;
			// 
			// textBox5
			// 
			this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontfax", true));
			this.textBox5.Location = new System.Drawing.Point(91, 335);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(232, 20);
			this.textBox5.TabIndex = 19;
			// 
			// textBox6
			// 
			this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontphnwrk", true));
			this.textBox6.Location = new System.Drawing.Point(91, 309);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(232, 20);
			this.textBox6.TabIndex = 17;
			// 
			// textBox7
			// 
			this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontzip", true));
			this.textBox7.Location = new System.Drawing.Point(385, 282);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(232, 20);
			this.textBox7.TabIndex = 16;
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontaddr2", true));
			this.textBox8.Location = new System.Drawing.Point(385, 256);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(232, 20);
			this.textBox8.TabIndex = 14;
			// 
			// textBox9
			// 
			this.textBox9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "bcontaddr", true));
			this.textBox9.Location = new System.Drawing.Point(91, 256);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(232, 20);
			this.textBox9.TabIndex = 13;
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
			this.comboBox2.Location = new System.Drawing.Point(385, 134);
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
			this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.statesBindingSource, "Name", true));
			this.comboBox1.DataSource = this.statesBindingSource;
			this.comboBox1.DisplayMember = "Name";
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(91, 81);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(232, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.ValueMember = "Abrev";
			// 
			// contphnhomTextBox
			// 
			this.contphnhomTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.contphnhomTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contphnhom", true));
			this.contphnhomTextBox.Location = new System.Drawing.Point(385, 108);
			this.contphnhomTextBox.Name = "contphnhomTextBox";
			this.contphnhomTextBox.Size = new System.Drawing.Size(232, 20);
			this.contphnhomTextBox.TabIndex = 7;
			// 
			// contlnameTextBox
			// 
			this.contlnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.contlnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contlname", true));
			this.contlnameTextBox.Location = new System.Drawing.Point(385, 29);
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
			this.txtContactEmail.Location = new System.Drawing.Point(91, 160);
			this.txtContactEmail.Name = "txtContactEmail";
			this.txtContactEmail.Size = new System.Drawing.Size(328, 20);
			this.txtContactEmail.TabIndex = 10;
			// 
			// contfaxTextBox
			// 
			this.contfaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contfax", true));
			this.contfaxTextBox.Location = new System.Drawing.Point(91, 134);
			this.contfaxTextBox.Name = "contfaxTextBox";
			this.contfaxTextBox.Size = new System.Drawing.Size(232, 20);
			this.contfaxTextBox.TabIndex = 8;
			// 
			// contphnwrkTextBox
			// 
			this.contphnwrkTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contphnwrk", true));
			this.contphnwrkTextBox.Location = new System.Drawing.Point(91, 108);
			this.contphnwrkTextBox.Name = "contphnwrkTextBox";
			this.contphnwrkTextBox.Size = new System.Drawing.Size(232, 20);
			this.contphnwrkTextBox.TabIndex = 6;
			// 
			// contzipTextBox
			// 
			this.contzipTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.contzipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contzip", true));
			this.contzipTextBox.Location = new System.Drawing.Point(385, 81);
			this.contzipTextBox.Name = "contzipTextBox";
			this.contzipTextBox.Size = new System.Drawing.Size(232, 20);
			this.contzipTextBox.TabIndex = 5;
			// 
			// contaddr2TextBox
			// 
			this.contaddr2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.contaddr2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "contaddr2", true));
			this.contaddr2TextBox.Location = new System.Drawing.Point(385, 55);
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
			this.lblSchcode.AutoSize = true;
			this.lblSchcode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schcode", true));
			this.lblSchcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSchcode.Location = new System.Drawing.Point(8, 0);
			this.lblSchcode.Name = "lblSchcode";
			this.lblSchcode.Size = new System.Drawing.Size(21, 24);
			this.lblSchcode.TabIndex = 8;
			this.lblSchcode.Text = "1";
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
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.mktinfoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
			this.txtReason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "reason", true));
			this.txtReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtReason.Location = new System.Drawing.Point(405, 60);
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
			this.commentListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.lkpCommentsBindingSource, "Comment", true));
			this.commentListBox.DataSource = this.lkpCommentsBindingSource;
			this.commentListBox.DisplayMember = "Comment";
			this.commentListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.commentListBox.FormattingEnabled = true;
			this.commentListBox.Location = new System.Drawing.Point(764, 60);
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
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.RoyalBlue;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.datecontDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
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
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.NullValue = " / / ";
			this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle5;
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
			this.tableAdapterManager1.contpstnTableAdapter = null;
			this.tableAdapterManager1.lkpBackGroundTableAdapter = null;
			this.tableAdapterManager1.lkpCommentsTableAdapter = null;
			this.tableAdapterManager1.LkpDdiscntTableAdapter = null;
			this.tableAdapterManager1.lkpMktReferenceTableAdapter = null;
			this.tableAdapterManager1.lkpPromotionsTableAdapter = null;
			this.tableAdapterManager1.lkpTypeContTableAdapter = null;
			this.tableAdapterManager1.lkTypeDataTableAdapter = null;
			this.tableAdapterManager1.statesTableAdapter = this.statesTableAdapter;
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
			// dedayinLabel2
			// 
			this.dedayinLabel2.AutoSize = true;
			this.dedayinLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "dedayin", true));
			this.dedayinLabel2.Location = new System.Drawing.Point(186, 46);
			this.dedayinLabel2.Name = "dedayinLabel2";
			this.dedayinLabel2.Size = new System.Drawing.Size(0, 13);
			this.dedayinLabel2.TabIndex = 44;
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
			// btnNewCustomer
			// 
			this.btnNewCustomer.AutoSize = true;
			this.btnNewCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnNewCustomer.Image")));
			this.btnNewCustomer.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.btnNewCustomer.Location = new System.Drawing.Point(1060, 6);
			this.btnNewCustomer.Name = "btnNewCustomer";
			this.btnNewCustomer.Size = new System.Drawing.Size(159, 23);
			this.btnNewCustomer.TabIndex = 9;
			this.btnNewCustomer.Text = "New Customer Email";
			this.btnNewCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnNewCustomer.UseVisualStyleBackColor = true;
			this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
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
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMbcCust_Paint);
			this.Controls.SetChildIndex(this.CustTab, 0);
			this.Controls.SetChildIndex(this.TopPanel, 0);
			this.Controls.SetChildIndex(this.BottomPanel, 0);
			this.BottomPanel.ResumeLayout(false);
			this.BottomPanel.PerformLayout();
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
			((System.ComponentModel.ISupportInitialize)(this.statesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lookUp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.custDataGridView)).EndInit();
			this.pnlHead.ResumeLayout(false);
			this.pnlHead.PerformLayout();
			this.pg2.ResumeLayout(false);
			this.pg2.PerformLayout();
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
        private System.Windows.Forms.TextBox contryearTextBox;
        private System.Windows.Forms.TextBox txtCsRep;
        private System.Windows.Forms.Button btnSchoolSearch;
        private System.Windows.Forms.TextBox txtSchNamesrch;
        private System.Windows.Forms.Button btnSchoolCode;
        private System.Windows.Forms.TextBox txtSchCodesrch;
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
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
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
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox txtContact3Email;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.BindingSource contpstnBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox txtSchColors;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSchName;
        private System.Windows.Forms.DateTimePicker schoutDateTimePicker;
        private System.Windows.Forms.TextBox spcinstTextBox;
        private System.Windows.Forms.TextBox extrchgTextBox;
        private System.Windows.Forms.Button btnInterOffice;
        private System.Windows.Forms.TextBox inofficeTextBox;
        private System.Windows.Forms.ComboBox cmbSchCategory;
        private System.Windows.Forms.ComboBox cmbNoRebook;
        private System.Windows.Forms.ComboBox cmbPrevPublisher;
        private System.Windows.Forms.ComboBox cmbNewPublisher;
        private System.Windows.Forms.CheckBox multiyearCheckBox;
        private System.Windows.Forms.TextBox gradesTextBox;
        private System.Windows.Forms.TextBox enrollmentTextBox;
        private System.Windows.Forms.TextBox txtPhotographer;
        private System.Windows.Forms.ComboBox multiyearComboBox;
        private System.Windows.Forms.TextBox clrpg_intTextBox;
        private System.Windows.Forms.CheckBox schuploadingCheckBox;
        private System.Windows.Forms.CheckBox blkwhiteCheckBox;
        private System.Windows.Forms.CheckBox allcolorCheckBox;
        private System.Windows.Forms.CheckBox sprinfoCheckBox;
        private System.Windows.Forms.CheckBox fallinfoCheckBox;
        private System.Windows.Forms.CheckBox clspicCheckBox;
        private System.Windows.Forms.TextBox springbreakTextBox;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Button btnWebsite;
        private System.Windows.Forms.TextBox txtSchEmail;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtSchPhone;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.DataGridView custDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn105;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn106;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn107;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn108;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn111;
        private System.Windows.Forms.TextBox txtBookType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox shiptocontTextBox;
        private System.Windows.Forms.TextBox yb_sthTextBox;
        private System.Windows.Forms.CheckBox nodirectmailCheckBox;
        private System.Windows.Forms.CheckBox nomktemailCheckBox;
        private System.Windows.Forms.Button btnEmailContac3;
        private System.Windows.Forms.Button btnEmailCont2;
        private System.Windows.Forms.Button btnEmailContact;
        private System.Windows.Forms.Button btnSchoolEmail;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox contmemoTextBox;
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
     
        private System.Windows.Forms.Label lblSchcodeVal;
        private System.Windows.Forms.TextBox txtSchname;
		private System.Windows.Forms.TextBox txtModifiedBy;
		private System.Windows.Forms.DateTimePicker initcontDateTimePicker;
		private System.Windows.Forms.DateTimePicker sourdateDateTimePicker;
		private System.Windows.Forms.DateTimePicker contdateDateTimePicker;
		private System.Windows.Forms.TextBox oraclecodeTextBox;
		private System.Windows.Forms.Button btnOracleSrch;
		private System.Windows.Forms.TextBox txtOracleCodeSrch;
		private System.Windows.Forms.Label dedayoutLabel2;
		private System.Windows.Forms.Label dedayinLabel2;
		private System.Windows.Forms.Button btnNewCustomer;
	}
}
