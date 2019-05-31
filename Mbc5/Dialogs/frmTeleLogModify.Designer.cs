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
            System.Windows.Forms.Label referedLabel;
            System.Windows.Forms.Label promoLabel;
            System.Windows.Forms.Label noteLabel;
            this.dsDateCont = new Mbc5.DataSets.dsDateCont();
            this.datecontBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datecontTableAdapter = new Mbc5.DataSets.dsDateContTableAdapters.datecontTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsDateContTableAdapters.TableAdapterManager();
            this.initialLabel2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pg1 = new System.Windows.Forms.TabPage();
            this.datecontLabel2 = new System.Windows.Forms.Label();
            this.typecontComboBox = new System.Windows.Forms.ComboBox();
            this.lkpTypeContBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUp = new Mbc5.DataSets.LookUp();
            this.nxtdaysComboBox = new System.Windows.Forms.ComboBox();
            this.techcallCheckBox = new System.Windows.Forms.CheckBox();
            this.callcontCheckBox = new System.Windows.Forms.CheckBox();
            this.nxtdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.calltimeTextBox = new System.Windows.Forms.TextBox();
            this.reasonTextBox = new System.Windows.Forms.TextBox();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.pg2 = new System.Windows.Forms.TabPage();
            this.chkMktComplete = new System.Windows.Forms.CheckBox();
            this.initialLabel3 = new System.Windows.Forms.Label();
            this.mktinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.promoComboBox = new System.Windows.Forms.ComboBox();
            this.lkpPromotionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.referedComboBox = new System.Windows.Forms.ComboBox();
            this.lkpMktReferenceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ddateLabel1 = new System.Windows.Forms.Label();
            this.dsMktInfo = new Mbc5.DataSets.dsMktInfo();
            this.mktinfoTableAdapter = new Mbc5.DataSets.dsMktInfoTableAdapters.mktinfoTableAdapter();
            this.tableAdapterManager1 = new Mbc5.DataSets.dsMktInfoTableAdapters.TableAdapterManager();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lkpPromotionsTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpPromotionsTableAdapter();
            this.tableAdapterManager2 = new Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager();
            this.lkpMktReferenceTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpMktReferenceTableAdapter();
            this.lkpTypeContTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.lkpTypeContTableAdapter();
            this.lblHeader = new System.Windows.Forms.Label();
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
            referedLabel = new System.Windows.Forms.Label();
            promoLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDateCont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datecontBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.pg1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTypeContBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).BeginInit();
            this.pg2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mktinfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPromotionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMktReferenceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMktInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.lblHeader);
            this.TopPanel.Size = new System.Drawing.Size(519, 43);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.btnCancel);
            this.BottomPanel.Controls.Add(this.btnSave);
            this.BottomPanel.Location = new System.Drawing.Point(0, 498);
            this.BottomPanel.Size = new System.Drawing.Size(519, 51);
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
            reasonLabel.Location = new System.Drawing.Point(40, 173);
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
            // referedLabel
            // 
            referedLabel.AutoSize = true;
            referedLabel.Location = new System.Drawing.Point(43, 81);
            referedLabel.Name = "referedLabel";
            referedLabel.Size = new System.Drawing.Size(57, 13);
            referedLabel.TabIndex = 2;
            referedLabel.Text = "Reference";
            // 
            // promoLabel
            // 
            promoLabel.AutoSize = true;
            promoLabel.Location = new System.Drawing.Point(18, 108);
            promoLabel.Name = "promoLabel";
            promoLabel.Size = new System.Drawing.Size(82, 13);
            promoLabel.TabIndex = 4;
            promoLabel.Text = "Promotion Code";
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(70, 135);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(30, 13);
            noteLabel.TabIndex = 6;
            noteLabel.Text = "Note";
            // 
            // dsDateCont
            // 
            this.dsDateCont.DataSetName = "dsDateCont";
            this.dsDateCont.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // datecontBindingSource
            // 
            this.datecontBindingSource.DataMember = "datecont";
            this.datecontBindingSource.DataSource = this.dsDateCont;
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
            this.initialLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "initial", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "G"));
            this.initialLabel2.Location = new System.Drawing.Point(451, 29);
            this.initialLabel2.Name = "initialLabel2";
            this.initialLabel2.Size = new System.Drawing.Size(80, 13);
            this.initialLabel2.TabIndex = 25;
            this.initialLabel2.Text = "label1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.pg1);
            this.tabControl1.Controls.Add(this.pg2);
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(519, 443);
            this.tabControl1.TabIndex = 2;
            // 
            // pg1
            // 
            this.pg1.AutoScroll = true;
            this.pg1.BackColor = System.Drawing.SystemColors.Control;
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
            this.pg1.Controls.Add(this.calltimeTextBox);
            this.pg1.Controls.Add(reasonLabel);
            this.pg1.Controls.Add(this.reasonTextBox);
            this.pg1.Controls.Add(priorityLabel);
            this.pg1.Controls.Add(this.priorityComboBox);
            this.pg1.Controls.Add(contactLabel);
            this.pg1.Controls.Add(this.contactTextBox);
            this.pg1.Location = new System.Drawing.Point(4, 22);
            this.pg1.Name = "pg1";
            this.pg1.Padding = new System.Windows.Forms.Padding(3);
            this.pg1.Size = new System.Drawing.Size(511, 417);
            this.pg1.TabIndex = 0;
            this.pg1.Text = "Telephone";
            // 
            // datecontLabel2
            // 
            this.datecontLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "datecont", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.datecontLabel2.Location = new System.Drawing.Point(451, 8);
            this.datecontLabel2.Name = "datecontLabel2";
            this.datecontLabel2.Size = new System.Drawing.Size(100, 21);
            this.datecontLabel2.TabIndex = 48;
            this.datecontLabel2.Text = "label1";
            // 
            // typecontComboBox
            // 
            this.typecontComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "typecont", true));
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
            this.nxtdaysComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "nxtdays", true));
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
            this.nxtdaysComboBox.Size = new System.Drawing.Size(53, 21);
            this.nxtdaysComboBox.TabIndex = 45;
            // 
            // techcallCheckBox
            // 
            this.techcallCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.datecontBindingSource, "techcall", true));
            this.techcallCheckBox.Location = new System.Drawing.Point(9, 3);
            this.techcallCheckBox.Name = "techcallCheckBox";
            this.techcallCheckBox.Size = new System.Drawing.Size(88, 24);
            this.techcallCheckBox.TabIndex = 43;
            this.techcallCheckBox.Text = "Tech Call";
            this.techcallCheckBox.UseVisualStyleBackColor = true;
            // 
            // callcontCheckBox
            // 
            this.callcontCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.datecontBindingSource, "callcont", true));
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
            this.nxtdateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.datecontBindingSource, "nxtdate", true));
            this.nxtdateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nxtdateDateTimePicker.Location = new System.Drawing.Point(95, 86);
            this.nxtdateDateTimePicker.Name = "nxtdateDateTimePicker";
            this.nxtdateDateTimePicker.Size = new System.Drawing.Size(126, 20);
            this.nxtdateDateTimePicker.TabIndex = 40;
            // 
            // calltimeTextBox
            // 
            this.calltimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "calltime", true));
            this.calltimeTextBox.Location = new System.Drawing.Point(390, 144);
            this.calltimeTextBox.Name = "calltimeTextBox";
            this.calltimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.calltimeTextBox.TabIndex = 37;
            // 
            // reasonTextBox
            // 
            this.reasonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "reason", true));
            this.reasonTextBox.Location = new System.Drawing.Point(95, 170);
            this.reasonTextBox.Multiline = true;
            this.reasonTextBox.Name = "reasonTextBox";
            this.reasonTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reasonTextBox.Size = new System.Drawing.Size(395, 219);
            this.reasonTextBox.TabIndex = 35;
            // 
            // priorityComboBox
            // 
            this.priorityComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "priority", true));
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
            this.contactTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datecontBindingSource, "contact", true));
            this.contactTextBox.Location = new System.Drawing.Point(95, 112);
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new System.Drawing.Size(100, 20);
            this.contactTextBox.TabIndex = 30;
            // 
            // pg2
            // 
            this.pg2.AutoScroll = true;
            this.pg2.BackColor = System.Drawing.SystemColors.Control;
            this.pg2.Controls.Add(this.chkMktComplete);
            this.pg2.Controls.Add(initialLabel1);
            this.pg2.Controls.Add(noteLabel);
            this.pg2.Controls.Add(this.initialLabel3);
            this.pg2.Controls.Add(this.noteTextBox);
            this.pg2.Controls.Add(promoLabel);
            this.pg2.Controls.Add(this.promoComboBox);
            this.pg2.Controls.Add(referedLabel);
            this.pg2.Controls.Add(this.referedComboBox);
            this.pg2.Controls.Add(ddateLabel);
            this.pg2.Controls.Add(this.ddateLabel1);
            this.pg2.Location = new System.Drawing.Point(4, 22);
            this.pg2.Name = "pg2";
            this.pg2.Padding = new System.Windows.Forms.Padding(3);
            this.pg2.Size = new System.Drawing.Size(511, 417);
            this.pg2.TabIndex = 1;
            this.pg2.Text = "Marketing";
            // 
            // chkMktComplete
            // 
            this.chkMktComplete.AutoSize = true;
            this.chkMktComplete.Location = new System.Drawing.Point(8, 9);
            this.chkMktComplete.Name = "chkMktComplete";
            this.chkMktComplete.Size = new System.Drawing.Size(181, 17);
            this.chkMktComplete.TabIndex = 27;
            this.chkMktComplete.Text = "Marketing Information Completed";
            this.chkMktComplete.UseVisualStyleBackColor = true;
            // 
            // initialLabel3
            // 
            this.initialLabel3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mktinfoBindingSource, "initial", true));
            this.initialLabel3.Location = new System.Drawing.Point(454, 26);
            this.initialLabel3.Name = "initialLabel3";
            this.initialLabel3.Size = new System.Drawing.Size(100, 23);
            this.initialLabel3.TabIndex = 26;
            this.initialLabel3.Text = "label1";
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mktinfoBindingSource, "note", true));
            this.noteTextBox.Location = new System.Drawing.Point(106, 135);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(351, 137);
            this.noteTextBox.TabIndex = 7;
            // 
            // promoComboBox
            // 
            this.promoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mktinfoBindingSource, "promo", true));
            this.promoComboBox.DataSource = this.lkpPromotionsBindingSource;
            this.promoComboBox.DisplayMember = "Promo";
            this.promoComboBox.FormattingEnabled = true;
            this.promoComboBox.Location = new System.Drawing.Point(106, 108);
            this.promoComboBox.Name = "promoComboBox";
            this.promoComboBox.Size = new System.Drawing.Size(121, 21);
            this.promoComboBox.TabIndex = 5;
            this.promoComboBox.ValueMember = "Promo";
            // 
            // lkpPromotionsBindingSource
            // 
            this.lkpPromotionsBindingSource.DataMember = "lkpPromotions";
            this.lkpPromotionsBindingSource.DataSource = this.lookUp;
            // 
            // referedComboBox
            // 
            this.referedComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mktinfoBindingSource, "refered", true));
            this.referedComboBox.DataSource = this.lkpMktReferenceBindingSource;
            this.referedComboBox.DisplayMember = "Name";
            this.referedComboBox.FormattingEnabled = true;
            this.referedComboBox.Location = new System.Drawing.Point(106, 81);
            this.referedComboBox.Name = "referedComboBox";
            this.referedComboBox.Size = new System.Drawing.Size(121, 21);
            this.referedComboBox.TabIndex = 3;
            this.referedComboBox.ValueMember = "Name";
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
            this.ddateLabel1.Size = new System.Drawing.Size(100, 23);
            this.ddateLabel1.TabIndex = 1;
            this.ddateLabel1.Text = "label1";
            // 
            // dsMktInfo
            // 
            this.dsMktInfo.DataSetName = "dsMktInfo";
            this.dsMktInfo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mktinfoTableAdapter
            // 
            this.mktinfoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.mktinfoTableAdapter = this.mktinfoTableAdapter;
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // frmTeleLogModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(519, 549);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTeleLogModify";
            this.Text = " Log";
            this.Load += new System.EventHandler(this.frmTeleLogModify_Load);
            this.Controls.SetChildIndex(this.TopPanel, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.TopPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsDateCont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datecontBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
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
            this.ResumeLayout(false);

        }

        #endregion

        private DataSets.dsDateCont dsDateCont;
        private System.Windows.Forms.BindingSource datecontBindingSource;
        private DataSets.dsDateContTableAdapters.datecontTableAdapter datecontTableAdapter;
        private DataSets.dsDateContTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label initialLabel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pg1;
        private System.Windows.Forms.Label datecontLabel2;
        private System.Windows.Forms.ComboBox typecontComboBox;
        private System.Windows.Forms.ComboBox nxtdaysComboBox;
        private System.Windows.Forms.CheckBox techcallCheckBox;
        private System.Windows.Forms.CheckBox callcontCheckBox;
        private System.Windows.Forms.DateTimePicker nxtdateDateTimePicker;
        private System.Windows.Forms.TextBox calltimeTextBox;
        private System.Windows.Forms.TextBox reasonTextBox;
        private System.Windows.Forms.ComboBox priorityComboBox;
        private System.Windows.Forms.TextBox contactTextBox;
        private System.Windows.Forms.TabPage pg2;
        private DataSets.dsMktInfo dsMktInfo;
        private System.Windows.Forms.BindingSource mktinfoBindingSource;
        private DataSets.dsMktInfoTableAdapters.mktinfoTableAdapter mktinfoTableAdapter;
        private DataSets.dsMktInfoTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label initialLabel3;
        private System.Windows.Forms.Label ddateLabel1;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.ComboBox promoComboBox;
        private System.Windows.Forms.ComboBox referedComboBox;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkMktComplete;
        private DataSets.LookUp lookUp;
        private System.Windows.Forms.BindingSource lkpPromotionsBindingSource;
        private DataSets.LookUpTableAdapters.lkpPromotionsTableAdapter lkpPromotionsTableAdapter;
        private DataSets.LookUpTableAdapters.TableAdapterManager tableAdapterManager2;
        private DataSets.LookUpTableAdapters.lkpTypeContTableAdapter lkpTypeContTableAdapter;
        private System.Windows.Forms.BindingSource lkpTypeContBindingSource;
        private DataSets.LookUpTableAdapters.lkpMktReferenceTableAdapter lkpMktReferenceTableAdapter;
        private System.Windows.Forms.BindingSource lkpMktReferenceBindingSource;
        private System.Windows.Forms.Label lblHeader;
    }
}
