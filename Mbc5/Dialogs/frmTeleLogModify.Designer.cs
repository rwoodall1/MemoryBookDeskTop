namespace Mbc5.Dialogs
{
    partial class frmTeleLogModify
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
            System.Windows.Forms.Label initialLabel;
            System.Windows.Forms.Label typecontLabel;
            System.Windows.Forms.Label nxtdateLabel;
            System.Windows.Forms.Label nxtdaysLabel;
            System.Windows.Forms.Label calltimeLabel;
            System.Windows.Forms.Label reasonLabel;
            System.Windows.Forms.Label priorityLabel;
            System.Windows.Forms.Label contactLabel;
            System.Windows.Forms.Label datecontLabel;
            System.Windows.Forms.Label ddateLabel;
            System.Windows.Forms.Label initialLabel1;
            System.Windows.Forms.Label noteLabel;
            System.Windows.Forms.Label promoLabel;
            System.Windows.Forms.Label referedLabel;
            this.dsDateCont = new Mbc5.DataSets.dsDateCont();
            this.datecontBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datecontTableAdapter = new Mbc5.DataSets.dsDateContTableAdapters.datecontTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsDateContTableAdapters.TableAdapterManager();
            this.initialLabel2 = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TabControl();
            this.pg1 = new System.Windows.Forms.TabPage();
            this.reasonTextBox = new System.Windows.Forms.TextBox();
            this.callTimeTextBox = new System.Windows.Forms.TextBox();
            this.cmbReasons = new System.Windows.Forms.ComboBox();
            this.datecontLabel2 = new System.Windows.Forms.Label();
            this.typecontComboBox = new System.Windows.Forms.ComboBox();
            this.lkpTypeContBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUp = new Mbc5.DataSets.LookUp();
            this.nxtdaysComboBox = new System.Windows.Forms.ComboBox();
            this.techcallCheckBox = new System.Windows.Forms.CheckBox();
            this.callcontCheckBox = new System.Windows.Forms.CheckBox();
            this.nxtdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.pg2 = new System.Windows.Forms.TabPage();
            this.btnCreateMktLog = new System.Windows.Forms.Button();
            this.initialLabel3 = new System.Windows.Forms.Label();
            this.mktinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lkpPromotionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lkpMktReferenceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ddateLabel1 = new System.Windows.Forms.Label();
            this.dsMktInfo = new Mbc5.DataSets.dsMktInfo();
            this.tableAdapterManager1 = new Mbc5.DataSets.dsMktInfoTableAdapters.TableAdapterManager();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lkpPromotionsTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpPromotionsTableAdapter();
            this.tableAdapterManager2 = new Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager();
            this.lkpMktReferenceTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpMktReferenceTableAdapter();
            this.lkpTypeContTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpTypeContTableAdapter();
            this.lblHeader = new System.Windows.Forms.Label();
            this.telephonLogRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave1 = new System.Windows.Forms.Button();
            this.btnCancel1 = new System.Windows.Forms.Button();
            this.chkbypassMkt = new System.Windows.Forms.CheckBox();
            this.pnlMkt = new System.Windows.Forms.Panel();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.promoComboBox = new System.Windows.Forms.ComboBox();
            this.referedComboBox = new System.Windows.Forms.ComboBox();
            initialLabel = new System.Windows.Forms.Label();
            typecontLabel = new System.Windows.Forms.Label();
            nxtdateLabel = new System.Windows.Forms.Label();
            nxtdaysLabel = new System.Windows.Forms.Label();
            calltimeLabel = new System.Windows.Forms.Label();
            reasonLabel = new System.Windows.Forms.Label();
            priorityLabel = new System.Windows.Forms.Label();
            contactLabel = new System.Windows.Forms.Label();
            datecontLabel = new System.Windows.Forms.Label();
            ddateLabel = new System.Windows.Forms.Label();
            initialLabel1 = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            promoLabel = new System.Windows.Forms.Label();
            referedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsDateCont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datecontBindingSource)).BeginInit();
            this.tbLog.SuspendLayout();
            this.pg1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTypeContBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).BeginInit();
            this.pg2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mktinfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPromotionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMktReferenceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMktInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephonLogRecordBindingSource)).BeginInit();
            this.pnlMkt.SuspendLayout();
            this.SuspendLayout();
            // 
            // initialLabel
            // 
            initialLabel.AutoSize = true;
            initialLabel.Location = new System.Drawing.Point(409, 29);
            initialLabel.Name = "initialLabel";
            initialLabel.Size = new System.Drawing.Size(36, 13);
            initialLabel.TabIndex = 12;
            initialLabel.Text = "Initials";
            // 
            // typecontLabel
            // 
            typecontLabel.AutoSize = true;
            typecontLabel.Location = new System.Drawing.Point(13, 143);
            typecontLabel.Name = "typecontLabel";
            typecontLabel.Size = new System.Drawing.Size(71, 13);
            typecontLabel.TabIndex = 41;
            typecontLabel.Text = "Type Contact";
            // 
            // nxtdateLabel
            // 
            nxtdateLabel.AutoSize = true;
            nxtdateLabel.Location = new System.Drawing.Point(29, 90);
            nxtdateLabel.Name = "nxtdateLabel";
            nxtdateLabel.Size = new System.Drawing.Size(55, 13);
            nxtdateLabel.TabIndex = 39;
            nxtdateLabel.Text = "Next Date";
            // 
            // nxtdaysLabel
            // 
            nxtdaysLabel.AutoSize = true;
            nxtdaysLabel.Location = new System.Drawing.Point(9, 63);
            nxtdaysLabel.Name = "nxtdaysLabel";
            nxtdaysLabel.Size = new System.Drawing.Size(75, 13);
            nxtdaysLabel.TabIndex = 38;
            nxtdaysLabel.Text = "Contact (days)";
            // 
            // calltimeLabel
            // 
            calltimeLabel.AutoSize = true;
            calltimeLabel.Location = new System.Drawing.Point(329, 147);
            calltimeLabel.Name = "calltimeLabel";
            calltimeLabel.Size = new System.Drawing.Size(50, 13);
            calltimeLabel.TabIndex = 36;
            calltimeLabel.Text = "Call Time";
            // 
            // reasonLabel
            // 
            reasonLabel.AutoSize = true;
            reasonLabel.Location = new System.Drawing.Point(40, 204);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Size = new System.Drawing.Size(44, 13);
            reasonLabel.TabIndex = 34;
            reasonLabel.Text = "Reason";
            // 
            // priorityLabel
            // 
            priorityLabel.AutoSize = true;
            priorityLabel.Location = new System.Drawing.Point(46, 36);
            priorityLabel.Name = "priorityLabel";
            priorityLabel.Size = new System.Drawing.Size(38, 13);
            priorityLabel.TabIndex = 31;
            priorityLabel.Text = "Priority";
            // 
            // contactLabel
            // 
            contactLabel.AutoSize = true;
            contactLabel.Location = new System.Drawing.Point(40, 115);
            contactLabel.Name = "contactLabel";
            contactLabel.Size = new System.Drawing.Size(44, 13);
            contactLabel.TabIndex = 29;
            contactLabel.Text = "Contact";
            // 
            // datecontLabel
            // 
            datecontLabel.AutoSize = true;
            datecontLabel.Location = new System.Drawing.Point(415, 8);
            datecontLabel.Name = "datecontLabel";
            datecontLabel.Size = new System.Drawing.Size(30, 13);
            datecontLabel.TabIndex = 47;
            datecontLabel.Text = "Date";
            // 
            // ddateLabel
            // 
            ddateLabel.AutoSize = true;
            ddateLabel.Location = new System.Drawing.Point(421, 3);
            ddateLabel.Name = "ddateLabel";
            ddateLabel.Size = new System.Drawing.Size(30, 13);
            ddateLabel.TabIndex = 0;
            ddateLabel.Text = "Date";
            // 
            // initialLabel1
            // 
            initialLabel1.AutoSize = true;
            initialLabel1.Location = new System.Drawing.Point(415, 26);
            initialLabel1.Name = "initialLabel1";
            initialLabel1.Size = new System.Drawing.Size(36, 13);
            initialLabel1.TabIndex = 25;
            initialLabel1.Text = "Initials";
            // 
            // dsDateCont
            // 
            this.dsDateCont.DataSetName = "dsDateCont";
            this.dsDateCont.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // datecontBindingSource
            // 
            this.datecontBindingSource.DataSource = typeof(BindingModels.TelephonLogRecord);
            // 
            // datecontTableAdapter
            // 
            this.datecontTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.datecontTableAdapter = this.datecontTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsDateContTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // initialLabel2
            // 
            this.initialLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "Initial", true));
            this.initialLabel2.Location = new System.Drawing.Point(451, 29);
            this.initialLabel2.Name = "initialLabel2";
            this.initialLabel2.Size = new System.Drawing.Size(39, 20);
            this.initialLabel2.TabIndex = 25;
            this.initialLabel2.Text = "label1";
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Controls.Add(this.pg1);
            this.tbLog.Controls.Add(this.pg2);
            this.tbLog.Location = new System.Drawing.Point(0, 49);
            this.tbLog.Name = "tbLog";
            this.tbLog.SelectedIndex = 0;
            this.tbLog.Size = new System.Drawing.Size(540, 416);
            this.tbLog.TabIndex = 2;
         
            // 
            // pg1
            // 
            this.pg1.AutoScroll = true;
            this.pg1.BackColor = System.Drawing.SystemColors.Control;
            this.pg1.Controls.Add(this.reasonTextBox);
            this.pg1.Controls.Add(this.callTimeTextBox);
            this.pg1.Controls.Add(this.cmbReasons);
            this.pg1.Controls.Add(this.datecontLabel2);
            this.pg1.Controls.Add(datecontLabel);
            this.pg1.Controls.Add(this.initialLabel2);
            this.pg1.Controls.Add(initialLabel);
            this.pg1.Controls.Add(this.typecontComboBox);
            this.pg1.Controls.Add(this.nxtdaysComboBox);
            this.pg1.Controls.Add(this.techcallCheckBox);
            this.pg1.Controls.Add(this.callcontCheckBox);
            this.pg1.Controls.Add(typecontLabel);
            this.pg1.Controls.Add(nxtdateLabel);
            this.pg1.Controls.Add(this.nxtdateDateTimePicker);
            this.pg1.Controls.Add(nxtdaysLabel);
            this.pg1.Controls.Add(calltimeLabel);
            this.pg1.Controls.Add(reasonLabel);
            this.pg1.Controls.Add(priorityLabel);
            this.pg1.Controls.Add(this.priorityComboBox);
            this.pg1.Controls.Add(contactLabel);
            this.pg1.Controls.Add(this.contactTextBox);
            this.pg1.Location = new System.Drawing.Point(4, 22);
            this.pg1.Name = "pg1";
            this.pg1.Padding = new System.Windows.Forms.Padding(3);
            this.pg1.Size = new System.Drawing.Size(532, 390);
            this.pg1.TabIndex = 0;
            this.pg1.Text = "Telephone";
            // 
            // reasonTextBox
            // 
            this.reasonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "Reason", true));
            this.reasonTextBox.Location = new System.Drawing.Point(95, 204);
            this.reasonTextBox.Multiline = true;
            this.reasonTextBox.Name = "reasonTextBox";
            this.reasonTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reasonTextBox.Size = new System.Drawing.Size(395, 180);
            this.reasonTextBox.TabIndex = 53;
            // 
            // callTimeTextBox
            // 
            this.callTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "CallTime", true));
            this.callTimeTextBox.Location = new System.Drawing.Point(385, 147);
            this.callTimeTextBox.Name = "callTimeTextBox";
            this.callTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.callTimeTextBox.TabIndex = 52;
            // 
            // cmbReasons
            // 
            this.cmbReasons.FormattingEnabled = true;
            this.cmbReasons.Items.AddRange(new object[] {
            " ",
            "BUSINESS AGREEMENT SENT ",
            "INQ QUOTE",
            "MBO",
            "OCC",
            "OPY",
            "PSPA",
            "QUOTE SENT",
            "REFUND REQUESTED",
            "RENEWAL REC\'D",
            "RENEWAL SENT",
            "SAMPLE SENT"});
            this.cmbReasons.Location = new System.Drawing.Point(95, 175);
            this.cmbReasons.Name = "cmbReasons";
            this.cmbReasons.Size = new System.Drawing.Size(395, 21);
            this.cmbReasons.TabIndex = 51;
            this.cmbReasons.SelectedValueChanged += new System.EventHandler(this.cmbReasons_SelectedValueChanged);
            // 
            // datecontLabel2
            // 
            this.datecontLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "Datecont", true));
            this.datecontLabel2.Location = new System.Drawing.Point(451, 8);
            this.datecontLabel2.Name = "datecontLabel2";
            this.datecontLabel2.Size = new System.Drawing.Size(73, 21);
            this.datecontLabel2.TabIndex = 48;
            this.datecontLabel2.Text = "label1";
            // 
            // typecontComboBox
            // 
            this.typecontComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.datecontBindingSource, "TypeCont", true));
            this.typecontComboBox.DataSource = this.lkpTypeContBindingSource;
            this.typecontComboBox.DisplayMember = "Name";
            this.typecontComboBox.FormattingEnabled = true;
            this.typecontComboBox.Location = new System.Drawing.Point(95, 143);
            this.typecontComboBox.Name = "typecontComboBox";
            this.typecontComboBox.Size = new System.Drawing.Size(180, 21);
            this.typecontComboBox.TabIndex = 46;
            this.typecontComboBox.ValueMember = "Name";
            // 
            // lkpTypeContBindingSource
            // 
            this.lkpTypeContBindingSource.DataMember = "lkpTypeCont";
            this.lkpTypeContBindingSource.DataSource = this.lookUp;
            // 
            // lookUp
            // 
            this.lookUp.DataSetName = "LookUp";
            this.lookUp.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nxtdaysComboBox
            // 
            this.nxtdaysComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.datecontBindingSource, "NxtDays", true));
            this.nxtdaysComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "NxtDays", true));
            this.nxtdaysComboBox.FormattingEnabled = true;
            this.nxtdaysComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "14",
            "21",
            "30",
            "45",
            "60",
            "90"});
            this.nxtdaysComboBox.Location = new System.Drawing.Point(95, 59);
            this.nxtdaysComboBox.Name = "nxtdaysComboBox";
            this.nxtdaysComboBox.Size = new System.Drawing.Size(68, 21);
            this.nxtdaysComboBox.TabIndex = 45;
            // 
            // techcallCheckBox
            // 
            this.techcallCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.datecontBindingSource, "TechCall", true));
            this.techcallCheckBox.Location = new System.Drawing.Point(9, 3);
            this.techcallCheckBox.Name = "techcallCheckBox";
            this.techcallCheckBox.Size = new System.Drawing.Size(88, 24);
            this.techcallCheckBox.TabIndex = 43;
            this.techcallCheckBox.Text = "Tech Call";
            this.techcallCheckBox.UseVisualStyleBackColor = true;
            // 
            // callcontCheckBox
            // 
            this.callcontCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.datecontBindingSource, "CallCont", true));
            this.callcontCheckBox.Location = new System.Drawing.Point(82, 3);
            this.callcontCheckBox.Name = "callcontCheckBox";
            this.callcontCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.callcontCheckBox.Size = new System.Drawing.Size(57, 24);
            this.callcontCheckBox.TabIndex = 42;
            this.callcontCheckBox.Text = "Call";
            this.callcontCheckBox.UseVisualStyleBackColor = true;
            // 
            // nxtdateDateTimePicker
            // 
            this.nxtdateDateTimePicker.CustomFormat = "\'\'";
            this.nxtdateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.datecontBindingSource, "NxtDate", true));
            this.nxtdateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nxtdateDateTimePicker.Location = new System.Drawing.Point(95, 86);
            this.nxtdateDateTimePicker.Name = "nxtdateDateTimePicker";
            this.nxtdateDateTimePicker.Size = new System.Drawing.Size(126, 20);
            this.nxtdateDateTimePicker.TabIndex = 40;
            this.nxtdateDateTimePicker.ValueChanged += new System.EventHandler(this.nxtdateDateTimePicker_ValueChanged);
            // 
            // priorityComboBox
            // 
            this.priorityComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.datecontBindingSource, "Priority", true));
            this.priorityComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "Priority", true));
            this.priorityComboBox.FormattingEnabled = true;
            this.priorityComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.priorityComboBox.Location = new System.Drawing.Point(95, 33);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(53, 21);
            this.priorityComboBox.TabIndex = 32;
            // 
            // contactTextBox
            // 
            this.contactTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "Contact", true));
            this.contactTextBox.Location = new System.Drawing.Point(95, 112);
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new System.Drawing.Size(126, 20);
            this.contactTextBox.TabIndex = 30;
            // 
            // pg2
            // 
            this.pg2.AutoScroll = true;
            this.pg2.BackColor = System.Drawing.SystemColors.Control;
            this.pg2.Controls.Add(this.pnlMkt);
            this.pg2.Controls.Add(this.btnCreateMktLog);
            this.pg2.Controls.Add(initialLabel1);
            this.pg2.Controls.Add(this.initialLabel3);
            this.pg2.Controls.Add(ddateLabel);
            this.pg2.Controls.Add(this.ddateLabel1);
            this.pg2.Location = new System.Drawing.Point(4, 22);
            this.pg2.Name = "pg2";
            this.pg2.Padding = new System.Windows.Forms.Padding(3);
            this.pg2.Size = new System.Drawing.Size(532, 390);
            this.pg2.TabIndex = 1;
            this.pg2.Text = "Marketing";
            // 
            // btnCreateMktLog
            // 
            this.btnCreateMktLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateMktLog.Location = new System.Drawing.Point(8, 6);
            this.btnCreateMktLog.Name = "btnCreateMktLog";
            this.btnCreateMktLog.Size = new System.Drawing.Size(134, 23);
            this.btnCreateMktLog.TabIndex = 27;
            this.btnCreateMktLog.Text = "Create New Mkt Log";
            this.btnCreateMktLog.UseVisualStyleBackColor = true;
            this.btnCreateMktLog.Click += new System.EventHandler(this.btnCreateMktLog_Click);
            // 
            // initialLabel3
            // 
            this.initialLabel3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mktinfoBindingSource, "initial", true));
            this.initialLabel3.Location = new System.Drawing.Point(454, 26);
            this.initialLabel3.Name = "initialLabel3";
            this.initialLabel3.Size = new System.Drawing.Size(70, 23);
            this.initialLabel3.TabIndex = 26;
            this.initialLabel3.Text = "label1";
            // 
            // lkpPromotionsBindingSource
            // 
            this.lkpPromotionsBindingSource.DataMember = "lkpPromotions";
            this.lkpPromotionsBindingSource.DataSource = this.lookUp;
            // 
            // lkpMktReferenceBindingSource
            // 
            this.lkpMktReferenceBindingSource.DataMember = "lkpMktReference";
            this.lkpMktReferenceBindingSource.DataSource = this.lookUp;
            // 
            // ddateLabel1
            // 
            this.ddateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mktinfoBindingSource, "ddate", true));
            this.ddateLabel1.Location = new System.Drawing.Point(454, 3);
            this.ddateLabel1.Name = "ddateLabel1";
            this.ddateLabel1.Size = new System.Drawing.Size(70, 23);
            this.ddateLabel1.TabIndex = 1;
            this.ddateLabel1.Text = "label1";
            // 
            // dsMktInfo
            // 
            this.dsMktInfo.DataSetName = "dsMktInfo";
            this.dsMktInfo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.mktinfoTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = Mbc5.DataSets.dsMktInfoTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(173, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(271, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lkpPromotionsTableAdapter
            // 
            this.lkpPromotionsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.contpstnTableAdapter = null;
            this.tableAdapterManager2.lkpBackGroundTableAdapter = null;
            this.tableAdapterManager2.lkpCommentsTableAdapter = null;
            this.tableAdapterManager2.lkpCustTypeTableAdapter = null;
            this.tableAdapterManager2.lkpLeadNameTableAdapter = null;
            this.tableAdapterManager2.lkpLeadSourceTableAdapter = null;
            this.tableAdapterManager2.lkpMktReferenceTableAdapter = this.lkpMktReferenceTableAdapter;
            this.tableAdapterManager2.lkpMultiYearOptionsTableAdapter = null;
            this.tableAdapterManager2.lkpNoRebookTableAdapter = null;
            this.tableAdapterManager2.lkpPrevPubTableAdapter = null;
            this.tableAdapterManager2.lkpPromotionsTableAdapter = this.lkpPromotionsTableAdapter;
            this.tableAdapterManager2.lkpschtypeTableAdapter = null;
            this.tableAdapterManager2.lkpTypeContTableAdapter = this.lkpTypeContTableAdapter;
            this.tableAdapterManager2.lkTypeDataTableAdapter = null;
            this.tableAdapterManager2.UpdateOrder = Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lkpMktReferenceTableAdapter
            // 
            this.lkpMktReferenceTableAdapter.ClearBeforeFill = true;
            // 
            // lkpTypeContTableAdapter
            // 
            this.lkpTypeContTableAdapter.ClearBeforeFill = true;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(4, 4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(511, 34);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // telephonLogRecordBindingSource
            // 
            this.telephonLogRecordBindingSource.DataSource = typeof(BindingModels.TelephonLogRecord);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(242, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(57, 20);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "label1";
            // 
            // btnSave1
            // 
            this.btnSave1.Location = new System.Drawing.Point(192, 466);
            this.btnSave1.Name = "btnSave1";
            this.btnSave1.Size = new System.Drawing.Size(75, 23);
            this.btnSave1.TabIndex = 4;
            this.btnSave1.Text = "Save";
            this.btnSave1.UseVisualStyleBackColor = true;
            this.btnSave1.Click += new System.EventHandler(this.btnSave1_Click);
            // 
            // btnCancel1
            // 
            this.btnCancel1.Location = new System.Drawing.Point(274, 466);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(75, 23);
            this.btnCancel1.TabIndex = 5;
            this.btnCancel1.Text = "Cancel";
            this.btnCancel1.UseVisualStyleBackColor = true;
            this.btnCancel1.Click += new System.EventHandler(this.btnCancel1_Click);
            // 
            // chkbypassMkt
            // 
            this.chkbypassMkt.AutoSize = true;
            this.chkbypassMkt.Location = new System.Drawing.Point(355, 470);
            this.chkbypassMkt.Name = "chkbypassMkt";
            this.chkbypassMkt.Size = new System.Drawing.Size(181, 17);
            this.chkbypassMkt.TabIndex = 51;
            this.chkbypassMkt.Text = "Marketing Information Completed";
            this.chkbypassMkt.UseVisualStyleBackColor = true;
            // 
            // pnlMkt
            // 
            this.pnlMkt.Controls.Add(noteLabel);
            this.pnlMkt.Controls.Add(this.noteTextBox);
            this.pnlMkt.Controls.Add(promoLabel);
            this.pnlMkt.Controls.Add(this.promoComboBox);
            this.pnlMkt.Controls.Add(referedLabel);
            this.pnlMkt.Controls.Add(this.referedComboBox);
            this.pnlMkt.Enabled = false;
            this.pnlMkt.Location = new System.Drawing.Point(23, 52);
            this.pnlMkt.Name = "pnlMkt";
            this.pnlMkt.Size = new System.Drawing.Size(501, 332);
            this.pnlMkt.TabIndex = 28;
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(65, 76);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(30, 13);
            noteLabel.TabIndex = 12;
            noteLabel.Text = "Note";
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mktinfoBindingSource, "note", true));
            this.noteTextBox.Location = new System.Drawing.Point(101, 76);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(351, 137);
            this.noteTextBox.TabIndex = 13;
            // 
            // promoLabel
            // 
            promoLabel.AutoSize = true;
            promoLabel.Location = new System.Drawing.Point(13, 49);
            promoLabel.Name = "promoLabel";
            promoLabel.Size = new System.Drawing.Size(82, 13);
            promoLabel.TabIndex = 10;
            promoLabel.Text = "Promotion Code";
            // 
            // promoComboBox
            // 
            this.promoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mktinfoBindingSource, "promo", true));
            this.promoComboBox.DataSource = this.lkpPromotionsBindingSource;
            this.promoComboBox.DisplayMember = "Promo";
            this.promoComboBox.FormattingEnabled = true;
            this.promoComboBox.Location = new System.Drawing.Point(101, 49);
            this.promoComboBox.Name = "promoComboBox";
            this.promoComboBox.Size = new System.Drawing.Size(121, 21);
            this.promoComboBox.TabIndex = 11;
            this.promoComboBox.ValueMember = "Promo";
            // 
            // referedLabel
            // 
            referedLabel.AutoSize = true;
            referedLabel.Location = new System.Drawing.Point(38, 22);
            referedLabel.Name = "referedLabel";
            referedLabel.Size = new System.Drawing.Size(57, 13);
            referedLabel.TabIndex = 8;
            referedLabel.Text = "Reference";
            // 
            // referedComboBox
            // 
            this.referedComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mktinfoBindingSource, "refered", true));
            this.referedComboBox.DataSource = this.lkpMktReferenceBindingSource;
            this.referedComboBox.DisplayMember = "Name";
            this.referedComboBox.FormattingEnabled = true;
            this.referedComboBox.Location = new System.Drawing.Point(101, 22);
            this.referedComboBox.Name = "referedComboBox";
            this.referedComboBox.Size = new System.Drawing.Size(121, 21);
            this.referedComboBox.TabIndex = 9;
            this.referedComboBox.ValueMember = "Name";
            // 
            // frmTeleLogModify
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(540, 499);
            this.Controls.Add(this.chkbypassMkt);
            this.Controls.Add(this.btnCancel1);
            this.Controls.Add(this.btnSave1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tbLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTeleLogModify";
            this.Text = " Log";
            this.Load += new System.EventHandler(this.frmTeleLogModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsDateCont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datecontBindingSource)).EndInit();
            this.tbLog.ResumeLayout(false);
            this.pg1.ResumeLayout(false);
            this.pg1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTypeContBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).EndInit();
            this.pg2.ResumeLayout(false);
            this.pg2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mktinfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPromotionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMktReferenceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMktInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telephonLogRecordBindingSource)).EndInit();
            this.pnlMkt.ResumeLayout(false);
            this.pnlMkt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSets.dsDateCont dsDateCont;
        private System.Windows.Forms.BindingSource datecontBindingSource;
        private DataSets.dsDateContTableAdapters.datecontTableAdapter datecontTableAdapter;
        private DataSets.dsDateContTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label initialLabel2;
        private System.Windows.Forms.TabControl tbLog;
        private System.Windows.Forms.TabPage pg1;
        private System.Windows.Forms.Label datecontLabel2;
        private System.Windows.Forms.ComboBox typecontComboBox;
        private System.Windows.Forms.ComboBox nxtdaysComboBox;
        private System.Windows.Forms.CheckBox techcallCheckBox;
        private System.Windows.Forms.CheckBox callcontCheckBox;
        private System.Windows.Forms.DateTimePicker nxtdateDateTimePicker;
        private System.Windows.Forms.ComboBox priorityComboBox;
        private System.Windows.Forms.TextBox contactTextBox;
        private System.Windows.Forms.TabPage pg2;
        private DataSets.dsMktInfo dsMktInfo;
        private System.Windows.Forms.BindingSource mktinfoBindingSource;
        private DataSets.dsMktInfoTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label initialLabel3;
        private System.Windows.Forms.Label ddateLabel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private DataSets.LookUp lookUp;
        private System.Windows.Forms.BindingSource lkpPromotionsBindingSource;
        private DataSets.LookUpTableAdapters.lkpPromotionsTableAdapter lkpPromotionsTableAdapter;
        private DataSets.LookUpTableAdapters.TableAdapterManager tableAdapterManager2;
        private DataSets.LookUpTableAdapters.lkpTypeContTableAdapter lkpTypeContTableAdapter;
        private System.Windows.Forms.BindingSource lkpTypeContBindingSource;
        private DataSets.LookUpTableAdapters.lkpMktReferenceTableAdapter lkpMktReferenceTableAdapter;
        private System.Windows.Forms.BindingSource lkpMktReferenceBindingSource;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.BindingSource telephonLogRecordBindingSource;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbReasons;
        private System.Windows.Forms.Button btnSave1;
        private System.Windows.Forms.Button btnCancel1;
        private System.Windows.Forms.TextBox callTimeTextBox;
        private System.Windows.Forms.TextBox reasonTextBox;
        private System.Windows.Forms.CheckBox chkbypassMkt;
        private System.Windows.Forms.Button btnCreateMktLog;
        private System.Windows.Forms.Panel pnlMkt;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.ComboBox promoComboBox;
        private System.Windows.Forms.ComboBox referedComboBox;
    }
}
