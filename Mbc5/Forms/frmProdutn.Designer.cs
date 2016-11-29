namespace Mbc5.Forms.MemoryBook {
    partial class frmProdutn {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label companyLabel;
            System.Windows.Forms.Label invnoLabel;
            System.Windows.Forms.Label prodnoLabel;
            System.Windows.Forms.Label contryearLabel;
            System.Windows.Forms.Label lblTypeStyle;
            System.Windows.Forms.Label cstatLabel;
            System.Windows.Forms.Label bkgrndLabel;
            System.Windows.Forms.Label nopagesLabel;
            System.Windows.Forms.Label nocopiesLabel;
            System.Windows.Forms.Label adduploaddateLabel;
            System.Windows.Forms.Label dedayinLabel;
            System.Windows.Forms.Label dedayoutLabel;
            System.Windows.Forms.Label dedmadeLabel;
            System.Windows.Forms.Label lblfoilclr;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdutn));
            System.Windows.Forms.Label covertypeLabel;
            System.Windows.Forms.Label coverdescLabel;
            System.Windows.Forms.Label screcvLabel;
            System.Windows.Forms.Label colorsLabel;
            System.Windows.Forms.Label diecutLabel;
            System.Windows.Forms.Label dcdesc1Label;
            this.tbProdutn = new System.Windows.Forms.TabControl();
            this.pg1 = new System.Windows.Forms.TabPage();
            this.bkmixedCheckBox = new System.Windows.Forms.CheckBox();
            this.produtnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProdutn = new Mbc5.DataSets.dsProdutn();
            this.booktypeTextBox = new System.Windows.Forms.TextBox();
            this.quotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBookType = new System.Windows.Forms.Button();
            this.allclrckCheckBox = new System.Windows.Forms.CheckBox();
            this.contryearLabel1 = new System.Windows.Forms.Label();
            this.prodnoLabel1 = new System.Windows.Forms.Label();
            this.invnoLabel1 = new System.Windows.Forms.Label();
            this.companyTextBox = new System.Windows.Forms.TextBox();
            this.lblSchoolName = new System.Windows.Forms.Label();
            this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pg2 = new System.Windows.Forms.TabPage();
            this.pg3 = new System.Windows.Forms.TabPage();
            this.pg4 = new System.Windows.Forms.TabPage();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.custTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.custTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager();
            this.produtnTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.produtnTableAdapter();
            this.quotesTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.quotesTableAdapter();
            this.vendcdComboBox = new System.Windows.Forms.ComboBox();
            this.cstatComboBox = new System.Windows.Forms.ComboBox();
            this.bkgrndComboBox = new System.Windows.Forms.ComboBox();
            this.nocopiesTextBox = new System.Windows.Forms.TextBox();
            this.nopagesTextBox = new System.Windows.Forms.TextBox();
            this.adduploaddateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnCalcDeadLine = new System.Windows.Forms.Button();
            this.dedayinDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dedayoutDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dedmadeTextBox = new System.Windows.Forms.TextBox();
            this.listrecdCheckBox = new System.Windows.Forms.CheckBox();
            this.persnlzCheckBox = new System.Windows.Forms.CheckBox();
            this.cmbfoilclr = new System.Windows.Forms.ComboBox();
            this.btnEmailProdForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.covertypeTextBox = new System.Windows.Forms.TextBox();
            this.coverdescTextBox = new System.Windows.Forms.TextBox();
            this.screcvDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.colorsTextBox = new System.Windows.Forms.TextBox();
            this.diecutTextBox = new System.Windows.Forms.TextBox();
            this.dcdesc1TextBox = new System.Windows.Forms.TextBox();
            companyLabel = new System.Windows.Forms.Label();
            invnoLabel = new System.Windows.Forms.Label();
            prodnoLabel = new System.Windows.Forms.Label();
            contryearLabel = new System.Windows.Forms.Label();
            lblTypeStyle = new System.Windows.Forms.Label();
            cstatLabel = new System.Windows.Forms.Label();
            bkgrndLabel = new System.Windows.Forms.Label();
            nopagesLabel = new System.Windows.Forms.Label();
            nocopiesLabel = new System.Windows.Forms.Label();
            adduploaddateLabel = new System.Windows.Forms.Label();
            dedayinLabel = new System.Windows.Forms.Label();
            dedayoutLabel = new System.Windows.Forms.Label();
            dedmadeLabel = new System.Windows.Forms.Label();
            lblfoilclr = new System.Windows.Forms.Label();
            covertypeLabel = new System.Windows.Forms.Label();
            coverdescLabel = new System.Windows.Forms.Label();
            screcvLabel = new System.Windows.Forms.Label();
            colorsLabel = new System.Windows.Forms.Label();
            diecutLabel = new System.Windows.Forms.Label();
            dcdesc1Label = new System.Windows.Forms.Label();
            this.tbProdutn.SuspendLayout();
            this.pg1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // companyLabel
            // 
            companyLabel.AutoSize = true;
            companyLabel.Location = new System.Drawing.Point(10, 9);
            companyLabel.Name = "companyLabel";
            companyLabel.Size = new System.Drawing.Size(53, 13);
            companyLabel.TabIndex = 8;
            companyLabel.Text = "company:";
            // 
            // invnoLabel
            // 
            invnoLabel.AutoSize = true;
            invnoLabel.Location = new System.Drawing.Point(325, 9);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(36, 13);
            invnoLabel.TabIndex = 9;
            invnoLabel.Text = "invno:";
            // 
            // prodnoLabel
            // 
            prodnoLabel.AutoSize = true;
            prodnoLabel.Location = new System.Drawing.Point(127, 9);
            prodnoLabel.Name = "prodnoLabel";
            prodnoLabel.Size = new System.Drawing.Size(43, 13);
            prodnoLabel.TabIndex = 10;
            prodnoLabel.Text = "prodno:";
            // 
            // contryearLabel
            // 
            contryearLabel.AutoSize = true;
            contryearLabel.Location = new System.Drawing.Point(534, 10);
            contryearLabel.Name = "contryearLabel";
            contryearLabel.Size = new System.Drawing.Size(54, 13);
            contryearLabel.TabIndex = 11;
            contryearLabel.Text = "contryear:";
            // 
            // tbProdutn
            // 
            this.tbProdutn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProdutn.Controls.Add(this.pg1);
            this.tbProdutn.Controls.Add(this.pg2);
            this.tbProdutn.Controls.Add(this.pg3);
            this.tbProdutn.Controls.Add(this.pg4);
            this.tbProdutn.Location = new System.Drawing.Point(0, 0);
            this.tbProdutn.Name = "tbProdutn";
            this.tbProdutn.SelectedIndex = 0;
            this.tbProdutn.Size = new System.Drawing.Size(1228, 731);
            this.tbProdutn.TabIndex = 0;
            // 
            // pg1
            // 
            this.pg1.AutoScroll = true;
            this.pg1.BackColor = System.Drawing.SystemColors.Control;
            this.pg1.Controls.Add(dcdesc1Label);
            this.pg1.Controls.Add(this.dcdesc1TextBox);
            this.pg1.Controls.Add(diecutLabel);
            this.pg1.Controls.Add(this.diecutTextBox);
            this.pg1.Controls.Add(colorsLabel);
            this.pg1.Controls.Add(this.colorsTextBox);
            this.pg1.Controls.Add(screcvLabel);
            this.pg1.Controls.Add(this.screcvDateTimePicker);
            this.pg1.Controls.Add(coverdescLabel);
            this.pg1.Controls.Add(this.coverdescTextBox);
            this.pg1.Controls.Add(covertypeLabel);
            this.pg1.Controls.Add(this.covertypeTextBox);
            this.pg1.Controls.Add(this.label2);
            this.pg1.Controls.Add(this.label1);
            this.pg1.Controls.Add(this.btnEmailProdForm);
            this.pg1.Controls.Add(lblfoilclr);
            this.pg1.Controls.Add(this.cmbfoilclr);
            this.pg1.Controls.Add(this.persnlzCheckBox);
            this.pg1.Controls.Add(this.listrecdCheckBox);
            this.pg1.Controls.Add(dedmadeLabel);
            this.pg1.Controls.Add(this.dedmadeTextBox);
            this.pg1.Controls.Add(dedayoutLabel);
            this.pg1.Controls.Add(this.dedayoutDateTimePicker);
            this.pg1.Controls.Add(dedayinLabel);
            this.pg1.Controls.Add(this.dedayinDateTimePicker);
            this.pg1.Controls.Add(this.btnCalcDeadLine);
            this.pg1.Controls.Add(adduploaddateLabel);
            this.pg1.Controls.Add(this.adduploaddateDateTimePicker);
            this.pg1.Controls.Add(nocopiesLabel);
            this.pg1.Controls.Add(this.nocopiesTextBox);
            this.pg1.Controls.Add(nopagesLabel);
            this.pg1.Controls.Add(this.nopagesTextBox);
            this.pg1.Controls.Add(bkgrndLabel);
            this.pg1.Controls.Add(this.bkgrndComboBox);
            this.pg1.Controls.Add(cstatLabel);
            this.pg1.Controls.Add(this.cstatComboBox);
            this.pg1.Controls.Add(lblTypeStyle);
            this.pg1.Controls.Add(this.vendcdComboBox);
            this.pg1.Controls.Add(this.bkmixedCheckBox);
            this.pg1.Controls.Add(this.booktypeTextBox);
            this.pg1.Controls.Add(this.btnBookType);
            this.pg1.Controls.Add(this.allclrckCheckBox);
            this.pg1.Controls.Add(contryearLabel);
            this.pg1.Controls.Add(this.contryearLabel1);
            this.pg1.Controls.Add(prodnoLabel);
            this.pg1.Controls.Add(this.prodnoLabel1);
            this.pg1.Controls.Add(invnoLabel);
            this.pg1.Controls.Add(this.invnoLabel1);
            this.pg1.Controls.Add(companyLabel);
            this.pg1.Controls.Add(this.companyTextBox);
            this.pg1.Controls.Add(this.lblSchoolName);
            this.pg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pg1.Location = new System.Drawing.Point(4, 22);
            this.pg1.Name = "pg1";
            this.pg1.Padding = new System.Windows.Forms.Padding(3);
            this.pg1.Size = new System.Drawing.Size(1220, 705);
            this.pg1.TabIndex = 0;
            this.pg1.Text = "Production";
            this.pg1.Click += new System.EventHandler(this.pg1_Click);
            // 
            // bkmixedCheckBox
            // 
            this.bkmixedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.produtnBindingSource, "reorder", true));
            this.bkmixedCheckBox.Location = new System.Drawing.Point(689, 10);
            this.bkmixedCheckBox.Name = "bkmixedCheckBox";
            this.bkmixedCheckBox.Size = new System.Drawing.Size(66, 24);
            this.bkmixedCheckBox.TabIndex = 16;
            this.bkmixedCheckBox.Text = "Reorder";
            this.bkmixedCheckBox.UseVisualStyleBackColor = true;
            // 
            // produtnBindingSource
            // 
            this.produtnBindingSource.DataMember = "produtn";
            this.produtnBindingSource.DataSource = this.dsProdutn;
            // 
            // dsProdutn
            // 
            this.dsProdutn.DataSetName = "dsProdutn";
            this.dsProdutn.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // booktypeTextBox
            // 
            this.booktypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "booktype", true));
            this.booktypeTextBox.Location = new System.Drawing.Point(90, 52);
            this.booktypeTextBox.Name = "booktypeTextBox";
            this.booktypeTextBox.Size = new System.Drawing.Size(53, 20);
            this.booktypeTextBox.TabIndex = 15;
            // 
            // quotesBindingSource
            // 
            this.quotesBindingSource.DataMember = "quotes";
            this.quotesBindingSource.DataSource = this.dsProdutn;
            // 
            // btnBookType
            // 
            this.btnBookType.Location = new System.Drawing.Point(13, 52);
            this.btnBookType.Name = "btnBookType";
            this.btnBookType.Size = new System.Drawing.Size(71, 23);
            this.btnBookType.TabIndex = 14;
            this.btnBookType.Text = "Book Type";
            this.btnBookType.UseVisualStyleBackColor = true;
            // 
            // allclrckCheckBox
            // 
            this.allclrckCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "allclrck", true));
            this.allclrckCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allclrckCheckBox.ForeColor = System.Drawing.Color.Red;
            this.allclrckCheckBox.Location = new System.Drawing.Point(1101, 5);
            this.allclrckCheckBox.Name = "allclrckCheckBox";
            this.allclrckCheckBox.Size = new System.Drawing.Size(113, 24);
            this.allclrckCheckBox.TabIndex = 13;
            this.allclrckCheckBox.Text = "All Color Book";
            this.allclrckCheckBox.UseVisualStyleBackColor = true;
            // 
            // contryearLabel1
            // 
            this.contryearLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "contryear", true));
            this.contryearLabel1.Location = new System.Drawing.Point(594, 10);
            this.contryearLabel1.Name = "contryearLabel1";
            this.contryearLabel1.Size = new System.Drawing.Size(100, 23);
            this.contryearLabel1.TabIndex = 12;
            this.contryearLabel1.Text = "label1";
            // 
            // prodnoLabel1
            // 
            this.prodnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "prodno", true));
            this.prodnoLabel1.Location = new System.Drawing.Point(176, 9);
            this.prodnoLabel1.Name = "prodnoLabel1";
            this.prodnoLabel1.Size = new System.Drawing.Size(100, 23);
            this.prodnoLabel1.TabIndex = 11;
            this.prodnoLabel1.Text = "label1";
            // 
            // invnoLabel1
            // 
            this.invnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "invno", true));
            this.invnoLabel1.Location = new System.Drawing.Point(367, 9);
            this.invnoLabel1.Name = "invnoLabel1";
            this.invnoLabel1.Size = new System.Drawing.Size(100, 23);
            this.invnoLabel1.TabIndex = 10;
            this.invnoLabel1.Text = "label1";
            // 
            // companyTextBox
            // 
            this.companyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "company", true));
            this.companyTextBox.Location = new System.Drawing.Point(69, 6);
            this.companyTextBox.Name = "companyTextBox";
            this.companyTextBox.ReadOnly = true;
            this.companyTextBox.Size = new System.Drawing.Size(49, 20);
            this.companyTextBox.TabIndex = 9;
            // 
            // lblSchoolName
            // 
            this.lblSchoolName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schname", true));
            this.lblSchoolName.Location = new System.Drawing.Point(1187, 3);
            this.lblSchoolName.Name = "lblSchoolName";
            this.lblSchoolName.Size = new System.Drawing.Size(0, 0);
            this.lblSchoolName.TabIndex = 8;
            this.lblSchoolName.Text = "label1";
            // 
            // custBindingSource
            // 
            this.custBindingSource.DataMember = "cust";
            this.custBindingSource.DataSource = this.dsProdutn;
            // 
            // pg2
            // 
            this.pg2.AutoScroll = true;
            this.pg2.BackColor = System.Drawing.SystemColors.Control;
            this.pg2.Location = new System.Drawing.Point(4, 22);
            this.pg2.Name = "pg2";
            this.pg2.Size = new System.Drawing.Size(1220, 705);
            this.pg2.TabIndex = 2;
            this.pg2.Text = "WIP";
            // 
            // pg3
            // 
            this.pg3.AutoScroll = true;
            this.pg3.BackColor = System.Drawing.SystemColors.Control;
            this.pg3.Location = new System.Drawing.Point(4, 22);
            this.pg3.Name = "pg3";
            this.pg3.Padding = new System.Windows.Forms.Padding(3);
            this.pg3.Size = new System.Drawing.Size(1220, 705);
            this.pg3.TabIndex = 1;
            this.pg3.Text = "Special Covers";
            // 
            // pg4
            // 
            this.pg4.AutoScroll = true;
            this.pg4.BackColor = System.Drawing.SystemColors.Control;
            this.pg4.Location = new System.Drawing.Point(4, 22);
            this.pg4.Name = "pg4";
            this.pg4.Size = new System.Drawing.Size(1220, 705);
            this.pg4.TabIndex = 3;
            this.pg4.Text = "Color Pages";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // custTableAdapter
            // 
            this.custTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.custTableAdapter = this.custTableAdapter;
            this.tableAdapterManager.produtnTableAdapter = this.produtnTableAdapter;
            this.tableAdapterManager.quotesTableAdapter = this.quotesTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // produtnTableAdapter
            // 
            this.produtnTableAdapter.ClearBeforeFill = true;
            // 
            // quotesTableAdapter
            // 
            this.quotesTableAdapter.ClearBeforeFill = true;
            // 
            // lblTypeStyle
            // 
            lblTypeStyle.AutoSize = true;
            lblTypeStyle.Location = new System.Drawing.Point(25, 114);
            lblTypeStyle.Name = "lblTypeStyle";
            lblTypeStyle.Size = new System.Drawing.Size(57, 13);
            lblTypeStyle.TabIndex = 16;
            lblTypeStyle.Text = "Type Style";
            // 
            // vendcdComboBox
            // 
            this.vendcdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "typestyle", true));
            this.vendcdComboBox.FormattingEnabled = true;
            this.vendcdComboBox.Location = new System.Drawing.Point(90, 111);
            this.vendcdComboBox.Name = "vendcdComboBox";
            this.vendcdComboBox.Size = new System.Drawing.Size(121, 21);
            this.vendcdComboBox.TabIndex = 17;
            // 
            // cstatLabel
            // 
            cstatLabel.AutoSize = true;
            cstatLabel.Location = new System.Drawing.Point(12, 152);
            cstatLabel.Name = "cstatLabel";
            cstatLabel.Size = new System.Drawing.Size(104, 13);
            cstatLabel.TabIndex = 17;
            cstatLabel.Text = "Rbk/Past/New Cust";
            // 
            // cstatComboBox
            // 
            this.cstatComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "cstat", true));
            this.cstatComboBox.FormattingEnabled = true;
            this.cstatComboBox.Location = new System.Drawing.Point(121, 149);
            this.cstatComboBox.Name = "cstatComboBox";
            this.cstatComboBox.Size = new System.Drawing.Size(121, 21);
            this.cstatComboBox.TabIndex = 18;
            // 
            // bkgrndLabel
            // 
            bkgrndLabel.AutoSize = true;
            bkgrndLabel.Location = new System.Drawing.Point(48, 179);
            bkgrndLabel.Name = "bkgrndLabel";
            bkgrndLabel.Size = new System.Drawing.Size(70, 13);
            bkgrndLabel.TabIndex = 18;
            bkgrndLabel.Text = "Back Ground";
            // 
            // bkgrndComboBox
            // 
            this.bkgrndComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "bkgrnd", true));
            this.bkgrndComboBox.FormattingEnabled = true;
            this.bkgrndComboBox.Location = new System.Drawing.Point(121, 176);
            this.bkgrndComboBox.Name = "bkgrndComboBox";
            this.bkgrndComboBox.Size = new System.Drawing.Size(121, 21);
            this.bkgrndComboBox.TabIndex = 19;
            // 
            // nopagesLabel
            // 
            nopagesLabel.AutoSize = true;
            nopagesLabel.Location = new System.Drawing.Point(64, 206);
            nopagesLabel.Name = "nopagesLabel";
            nopagesLabel.Size = new System.Drawing.Size(57, 13);
            nopagesLabel.TabIndex = 19;
            nopagesLabel.Text = "No. Pages";
            // 
            // nocopiesLabel
            // 
            nocopiesLabel.AutoSize = true;
            nocopiesLabel.Location = new System.Drawing.Point(62, 232);
            nocopiesLabel.Name = "nocopiesLabel";
            nocopiesLabel.Size = new System.Drawing.Size(59, 13);
            nocopiesLabel.TabIndex = 21;
            nocopiesLabel.Text = "No. Copies";
            // 
            // nocopiesTextBox
            // 
            this.nocopiesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "nocopies", true));
            this.nocopiesTextBox.Location = new System.Drawing.Point(121, 229);
            this.nocopiesTextBox.Name = "nocopiesTextBox";
            this.nocopiesTextBox.ReadOnly = true;
            this.nocopiesTextBox.Size = new System.Drawing.Size(100, 20);
            this.nocopiesTextBox.TabIndex = 22;
            // 
            // nopagesTextBox
            // 
            this.nopagesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "nopages", true));
            this.nopagesTextBox.Location = new System.Drawing.Point(121, 203);
            this.nopagesTextBox.Name = "nopagesTextBox";
            this.nopagesTextBox.ReadOnly = true;
            this.nopagesTextBox.Size = new System.Drawing.Size(100, 20);
            this.nopagesTextBox.TabIndex = 20;
            // 
            // adduploaddateLabel
            // 
            adduploaddateLabel.AutoSize = true;
            adduploaddateLabel.Location = new System.Drawing.Point(34, 259);
            adduploaddateLabel.Name = "adduploaddateLabel";
            adduploaddateLabel.Size = new System.Drawing.Size(83, 13);
            adduploaddateLabel.TabIndex = 23;
            adduploaddateLabel.Text = "Ad Upload Date";
            // 
            // adduploaddateDateTimePicker
            // 
            this.adduploaddateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.produtnBindingSource, "adduploaddate", true));
            this.adduploaddateDateTimePicker.Location = new System.Drawing.Point(121, 255);
            this.adduploaddateDateTimePicker.Name = "adduploaddateDateTimePicker";
            this.adduploaddateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.adduploaddateDateTimePicker.TabIndex = 24;
            // 
            // btnCalcDeadLine
            // 
            this.btnCalcDeadLine.Location = new System.Drawing.Point(51, 294);
            this.btnCalcDeadLine.Name = "btnCalcDeadLine";
            this.btnCalcDeadLine.Size = new System.Drawing.Size(97, 23);
            this.btnCalcDeadLine.TabIndex = 25;
            this.btnCalcDeadLine.Text = "Calc Deadline In";
            this.btnCalcDeadLine.UseVisualStyleBackColor = true;
            // 
            // dedayinLabel
            // 
            dedayinLabel.AutoSize = true;
            dedayinLabel.Location = new System.Drawing.Point(26, 334);
            dedayinLabel.Name = "dedayinLabel";
            dedayinLabel.Size = new System.Drawing.Size(83, 13);
            dedayinLabel.TabIndex = 26;
            dedayinLabel.Text = "Deadline Day In";
            // 
            // dedayinDateTimePicker
            // 
            this.dedayinDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.produtnBindingSource, "dedayin", true));
            this.dedayinDateTimePicker.Location = new System.Drawing.Point(115, 334);
            this.dedayinDateTimePicker.Name = "dedayinDateTimePicker";
            this.dedayinDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dedayinDateTimePicker.TabIndex = 27;
            // 
            // dedayoutLabel
            // 
            dedayoutLabel.AutoSize = true;
            dedayoutLabel.Location = new System.Drawing.Point(19, 360);
            dedayoutLabel.Name = "dedayoutLabel";
            dedayoutLabel.Size = new System.Drawing.Size(91, 13);
            dedayoutLabel.TabIndex = 28;
            dedayoutLabel.Text = "Deadline Day Out";
            // 
            // dedayoutDateTimePicker
            // 
            this.dedayoutDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.produtnBindingSource, "dedayout", true));
            this.dedayoutDateTimePicker.Location = new System.Drawing.Point(115, 360);
            this.dedayoutDateTimePicker.Name = "dedayoutDateTimePicker";
            this.dedayoutDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dedayoutDateTimePicker.TabIndex = 29;
            // 
            // dedmadeLabel
            // 
            dedmadeLabel.AutoSize = true;
            dedmadeLabel.Location = new System.Drawing.Point(24, 386);
            dedmadeLabel.Name = "dedmadeLabel";
            dedmadeLabel.Size = new System.Drawing.Size(79, 13);
            dedmadeLabel.TabIndex = 30;
            dedmadeLabel.Text = "Deadline Made";
            // 
            // dedmadeTextBox
            // 
            this.dedmadeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "dedmade", true));
            this.dedmadeTextBox.Location = new System.Drawing.Point(106, 386);
            this.dedmadeTextBox.Name = "dedmadeTextBox";
            this.dedmadeTextBox.Size = new System.Drawing.Size(42, 20);
            this.dedmadeTextBox.TabIndex = 31;
            // 
            // listrecdCheckBox
            // 
            this.listrecdCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.produtnBindingSource, "listrecd", true));
            this.listrecdCheckBox.Location = new System.Drawing.Point(39, 412);
            this.listrecdCheckBox.Name = "listrecdCheckBox";
            this.listrecdCheckBox.Size = new System.Drawing.Size(104, 24);
            this.listrecdCheckBox.TabIndex = 33;
            this.listrecdCheckBox.Text = "List Recvd";
            this.listrecdCheckBox.UseVisualStyleBackColor = true;
            // 
            // persnlzCheckBox
            // 
            this.persnlzCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.produtnBindingSource, "persnlz", true));
            this.persnlzCheckBox.Location = new System.Drawing.Point(44, 442);
            this.persnlzCheckBox.Name = "persnlzCheckBox";
            this.persnlzCheckBox.Size = new System.Drawing.Size(104, 24);
            this.persnlzCheckBox.TabIndex = 34;
            this.persnlzCheckBox.Text = "Personalization";
            this.persnlzCheckBox.UseVisualStyleBackColor = true;
            // 
            // lblfoilclr
            // 
            lblfoilclr.AutoSize = true;
            lblfoilclr.Location = new System.Drawing.Point(32, 472);
            lblfoilclr.Name = "lblfoilclr";
            lblfoilclr.Size = new System.Drawing.Size(31, 13);
            lblfoilclr.TabIndex = 35;
            lblfoilclr.Text = "Color";
            // 
            // cmbfoilclr
            // 
            this.cmbfoilclr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "foilclr", true));
            this.cmbfoilclr.FormattingEnabled = true;
            this.cmbfoilclr.Location = new System.Drawing.Point(69, 472);
            this.cmbfoilclr.Name = "cmbfoilclr";
            this.cmbfoilclr.Size = new System.Drawing.Size(121, 21);
            this.cmbfoilclr.TabIndex = 36;
            // 
            // btnEmailProdForm
            // 
            this.btnEmailProdForm.AutoSize = true;
            this.btnEmailProdForm.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailProdForm.Image")));
            this.btnEmailProdForm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmailProdForm.Location = new System.Drawing.Point(51, 513);
            this.btnEmailProdForm.Name = "btnEmailProdForm";
            this.btnEmailProdForm.Size = new System.Drawing.Size(93, 38);
            this.btnEmailProdForm.TabIndex = 38;
            this.btnEmailProdForm.Text = "Email Prod Form";
            this.btnEmailProdForm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmailProdForm.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "boo type a";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "booktype b";
            // 
            // covertypeLabel
            // 
            covertypeLabel.AutoSize = true;
            covertypeLabel.Location = new System.Drawing.Point(367, 57);
            covertypeLabel.Name = "covertypeLabel";
            covertypeLabel.Size = new System.Drawing.Size(62, 13);
            covertypeLabel.TabIndex = 40;
            covertypeLabel.Text = "Cover Type";
            // 
            // covertypeTextBox
            // 
            this.covertypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "covertype", true));
            this.covertypeTextBox.Location = new System.Drawing.Point(439, 54);
            this.covertypeTextBox.Name = "covertypeTextBox";
            this.covertypeTextBox.Size = new System.Drawing.Size(100, 20);
            this.covertypeTextBox.TabIndex = 41;
            // 
            // coverdescLabel
            // 
            coverdescLabel.AutoSize = true;
            coverdescLabel.Location = new System.Drawing.Point(338, 83);
            coverdescLabel.Name = "coverdescLabel";
            coverdescLabel.Size = new System.Drawing.Size(91, 13);
            coverdescLabel.TabIndex = 41;
            coverdescLabel.Text = "Cover Description";
            // 
            // coverdescTextBox
            // 
            this.coverdescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "coverdesc", true));
            this.coverdescTextBox.Location = new System.Drawing.Point(439, 80);
            this.coverdescTextBox.Name = "coverdescTextBox";
            this.coverdescTextBox.Size = new System.Drawing.Size(100, 20);
            this.coverdescTextBox.TabIndex = 42;
            // 
            // screcvLabel
            // 
            screcvLabel.AutoSize = true;
            screcvLabel.Location = new System.Drawing.Point(333, 111);
            screcvLabel.Name = "screcvLabel";
            screcvLabel.Size = new System.Drawing.Size(96, 13);
            screcvLabel.TabIndex = 43;
            screcvLabel.Text = "Special Cvr Recvd";
            // 
            // screcvDateTimePicker
            // 
            this.screcvDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.produtnBindingSource, "screcv", true));
            this.screcvDateTimePicker.Location = new System.Drawing.Point(439, 106);
            this.screcvDateTimePicker.Name = "screcvDateTimePicker";
            this.screcvDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.screcvDateTimePicker.TabIndex = 44;
            // 
            // colorsLabel
            // 
            colorsLabel.AutoSize = true;
            colorsLabel.Location = new System.Drawing.Point(373, 132);
            colorsLabel.Name = "colorsLabel";
            colorsLabel.Size = new System.Drawing.Size(58, 13);
            colorsLabel.TabIndex = 45;
            colorsLabel.Text = "# of Colors";
            // 
            // colorsTextBox
            // 
            this.colorsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "colors", true));
            this.colorsTextBox.Location = new System.Drawing.Point(437, 132);
            this.colorsTextBox.Name = "colorsTextBox";
            this.colorsTextBox.Size = new System.Drawing.Size(100, 20);
            this.colorsTextBox.TabIndex = 46;
            // 
            // diecutLabel
            // 
            diecutLabel.AutoSize = true;
            diecutLabel.Location = new System.Drawing.Point(385, 161);
            diecutLabel.Name = "diecutLabel";
            diecutLabel.Size = new System.Drawing.Size(42, 13);
            diecutLabel.TabIndex = 47;
            diecutLabel.Text = "Die Cut";
            // 
            // diecutTextBox
            // 
            this.diecutTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "diecut", true));
            this.diecutTextBox.Location = new System.Drawing.Point(437, 158);
            this.diecutTextBox.Name = "diecutTextBox";
            this.diecutTextBox.Size = new System.Drawing.Size(100, 20);
            this.diecutTextBox.TabIndex = 48;
            // 
            // dcdesc1Label
            // 
            dcdesc1Label.AutoSize = true;
            dcdesc1Label.Location = new System.Drawing.Point(414, 184);
            dcdesc1Label.Name = "dcdesc1Label";
            dcdesc1Label.Size = new System.Drawing.Size(28, 13);
            dcdesc1Label.TabIndex = 49;
            dcdesc1Label.Text = "DC1";
            // 
            // dcdesc1TextBox
            // 
            this.dcdesc1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "dcdesc1", true));
            this.dcdesc1TextBox.Location = new System.Drawing.Point(439, 184);
            this.dcdesc1TextBox.Name = "dcdesc1TextBox";
            this.dcdesc1TextBox.Size = new System.Drawing.Size(100, 20);
            this.dcdesc1TextBox.TabIndex = 50;
            // 
            // frmProdutn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1234, 731);
            this.Controls.Add(this.tbProdutn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1250, 770);
            this.Name = "frmProdutn";
            this.Text = "Production";
            this.Load += new System.EventHandler(this.frmProdutn_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmProdutn_Paint);
            this.tbProdutn.ResumeLayout(false);
            this.pg1.ResumeLayout(false);
            this.pg1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.TabControl tbProdutn;
        private System.Windows.Forms.TabPage pg1;
        private System.Windows.Forms.TabPage pg3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage pg2;
        private System.Windows.Forms.TabPage pg4;
        private System.Windows.Forms.BindingSource custBindingSource;
        private DataSets.dsProdutn dsProdutn;
        private DataSets.dsProdutnTableAdapters.custTableAdapter custTableAdapter;
        private DataSets.dsProdutnTableAdapters.TableAdapterManager tableAdapterManager;
        private DataSets.dsProdutnTableAdapters.quotesTableAdapter quotesTableAdapter;
        private System.Windows.Forms.BindingSource quotesBindingSource;
        private DataSets.dsProdutnTableAdapters.produtnTableAdapter produtnTableAdapter;
        private System.Windows.Forms.BindingSource produtnBindingSource;
        private System.Windows.Forms.Label lblSchoolName;
        private System.Windows.Forms.TextBox companyTextBox;
        private System.Windows.Forms.Label prodnoLabel1;
        private System.Windows.Forms.Label invnoLabel1;
        private System.Windows.Forms.Label contryearLabel1;
        private System.Windows.Forms.Button btnBookType;
        private System.Windows.Forms.CheckBox allclrckCheckBox;
        private System.Windows.Forms.CheckBox bkmixedCheckBox;
        private System.Windows.Forms.TextBox booktypeTextBox;
        private System.Windows.Forms.Button btnCalcDeadLine;
        private System.Windows.Forms.DateTimePicker adduploaddateDateTimePicker;
        private System.Windows.Forms.TextBox nocopiesTextBox;
        private System.Windows.Forms.TextBox nopagesTextBox;
        private System.Windows.Forms.ComboBox bkgrndComboBox;
        private System.Windows.Forms.ComboBox cstatComboBox;
        private System.Windows.Forms.ComboBox vendcdComboBox;
        private System.Windows.Forms.ComboBox cmbfoilclr;
        private System.Windows.Forms.CheckBox persnlzCheckBox;
        private System.Windows.Forms.CheckBox listrecdCheckBox;
        private System.Windows.Forms.TextBox dedmadeTextBox;
        private System.Windows.Forms.DateTimePicker dedayoutDateTimePicker;
        private System.Windows.Forms.DateTimePicker dedayinDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEmailProdForm;
        private System.Windows.Forms.TextBox coverdescTextBox;
        private System.Windows.Forms.TextBox covertypeTextBox;
        private System.Windows.Forms.TextBox colorsTextBox;
        private System.Windows.Forms.DateTimePicker screcvDateTimePicker;
        private System.Windows.Forms.TextBox dcdesc1TextBox;
        private System.Windows.Forms.TextBox diecutTextBox;
        }
    }
