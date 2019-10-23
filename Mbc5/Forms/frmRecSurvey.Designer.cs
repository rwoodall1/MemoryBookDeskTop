namespace Mbc5.Forms
{
    partial class frmRecSurvey
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
            System.Windows.Forms.Label schcodeLabel;
            System.Windows.Forms.Label schnameLabel;
            System.Windows.Forms.Label invnoLabel;
            System.Windows.Forms.Label contryearLabel;
            System.Windows.Forms.Label prodnoLabel;
            System.Windows.Forms.Label recv1Label;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label numpgsLabel;
            System.Windows.Forms.Label schoutLabel;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label16;
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.page1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.booktypeTextBox = new System.Windows.Forms.TextBox();
            this.tagcolorTextBox = new System.Windows.Forms.TextBox();
            this.schoutDateBox = new CustomControls.DateBox();
            this.numpgsTextBox = new System.Windows.Forms.TextBox();
            this.hndredCheckBox = new System.Windows.Forms.CheckBox();
            this.recv4memoTextBox = new System.Windows.Forms.TextBox();
            this.recv3memoTextBox = new System.Windows.Forms.TextBox();
            this.recv2memoTextBox = new System.Windows.Forms.TextBox();
            this.bkcs4DateBox = new CustomControls.DateBox();
            this.tocs4DateBox = new CustomControls.DateBox();
            this.bkcs3DateBox = new CustomControls.DateBox();
            this.tocs3DateBox = new CustomControls.DateBox();
            this.bkcs2DateBox = new CustomControls.DateBox();
            this.tocs2DateBox = new CustomControls.DateBox();
            this.recv4TextBox = new System.Windows.Forms.TextBox();
            this.recv3TextBox = new System.Windows.Forms.TextBox();
            this.recv2TextBox = new System.Windows.Forms.TextBox();
            this.recvmemoTextBox = new System.Windows.Forms.TextBox();
            this.bkcsDateBox = new CustomControls.DateBox();
            this.tocsDateBox = new CustomControls.DateBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.recv1TextBox = new System.Windows.Forms.TextBox();
            this.prodnoLabel1 = new System.Windows.Forms.Label();
            this.contryearLabel1 = new System.Windows.Forms.Label();
            this.invnoLabel1 = new System.Windows.Forms.Label();
            this.schnameLabel1 = new System.Windows.Forms.Label();
            this.schcodeLabel1 = new System.Windows.Forms.Label();
            this.page2 = new System.Windows.Forms.TabPage();
            this.recv2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsReceiving = new Mbc5.DataSets.dsReceiving();
            this.recv2TableAdapter = new Mbc5.DataSets.dsReceivingTableAdapters.recv2TableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsReceivingTableAdapters.TableAdapterManager();
            schcodeLabel = new System.Windows.Forms.Label();
            schnameLabel = new System.Windows.Forms.Label();
            invnoLabel = new System.Windows.Forms.Label();
            contryearLabel = new System.Windows.Forms.Label();
            prodnoLabel = new System.Windows.Forms.Label();
            recv1Label = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            numpgsLabel = new System.Windows.Forms.Label();
            schoutLabel = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.page1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recv2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReceiving)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Location = new System.Drawing.Point(-169, -112);
            // 
            // schcodeLabel
            // 
            schcodeLabel.AutoSize = true;
            schcodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            schcodeLabel.Location = new System.Drawing.Point(25, 21);
            schcodeLabel.Name = "schcodeLabel";
            schcodeLabel.Size = new System.Drawing.Size(79, 13);
            schcodeLabel.TabIndex = 0;
            schcodeLabel.Text = "School Code";
            // 
            // schnameLabel
            // 
            schnameLabel.AutoSize = true;
            schnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            schnameLabel.Location = new System.Drawing.Point(190, 21);
            schnameLabel.Name = "schnameLabel";
            schnameLabel.Size = new System.Drawing.Size(82, 13);
            schnameLabel.TabIndex = 2;
            schnameLabel.Text = "School Name";
            // 
            // invnoLabel
            // 
            invnoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            invnoLabel.AutoSize = true;
            invnoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            invnoLabel.Location = new System.Drawing.Point(527, 21);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(57, 13);
            invnoLabel.TabIndex = 4;
            invnoLabel.Text = "Invoice#";
            // 
            // contryearLabel
            // 
            contryearLabel.AutoSize = true;
            contryearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contryearLabel.Location = new System.Drawing.Point(71, 47);
            contryearLabel.Name = "contryearLabel";
            contryearLabel.Size = new System.Drawing.Size(33, 13);
            contryearLabel.TabIndex = 6;
            contryearLabel.Text = "Year";
            // 
            // prodnoLabel
            // 
            prodnoLabel.AutoSize = true;
            prodnoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            prodnoLabel.Location = new System.Drawing.Point(209, 47);
            prodnoLabel.Name = "prodnoLabel";
            prodnoLabel.Size = new System.Drawing.Size(61, 13);
            prodnoLabel.TabIndex = 8;
            prodnoLabel.Text = "Prod. No.";
            // 
            // recv1Label
            // 
            recv1Label.AutoSize = true;
            recv1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            recv1Label.Location = new System.Drawing.Point(31, 81);
            recv1Label.Name = "recv1Label";
            recv1Label.Size = new System.Drawing.Size(14, 13);
            recv1Label.TabIndex = 10;
            recv1Label.Text = "1";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(31, 149);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(14, 13);
            label9.TabIndex = 24;
            label9.Text = "2";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(31, 220);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(14, 13);
            label10.TabIndex = 25;
            label10.Text = "3";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(31, 295);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(14, 13);
            label11.TabIndex = 26;
            label11.Text = "4";
            // 
            // numpgsLabel
            // 
            numpgsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            numpgsLabel.AutoSize = true;
            numpgsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numpgsLabel.Location = new System.Drawing.Point(703, 101);
            numpgsLabel.Name = "numpgsLabel";
            numpgsLabel.Size = new System.Drawing.Size(89, 13);
            numpgsLabel.TabIndex = 39;
            numpgsLabel.Text = "Number Pages";
            // 
            // schoutLabel
            // 
            schoutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            schoutLabel.AutoSize = true;
            schoutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            schoutLabel.Location = new System.Drawing.Point(790, 121);
            schoutLabel.Name = "schoutLabel";
            schoutLabel.Size = new System.Drawing.Size(57, 13);
            schoutLabel.TabIndex = 41;
            schoutLabel.Text = "Last Day";
            // 
            // label15
            // 
            label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label15.Location = new System.Drawing.Point(671, 150);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(68, 13);
            label15.TabIndex = 46;
            label15.Text = "Book Type";
            // 
            // label16
            // 
            label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label16.Location = new System.Drawing.Point(677, 172);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(62, 13);
            label16.TabIndex = 47;
            label16.Text = "Tag Color";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.page1);
            this.tabControl1.Controls.Add(this.page2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(897, 481);
            this.tabControl1.TabIndex = 1;
            // 
            // page1
            // 
            this.page1.AutoScroll = true;
            this.page1.BackColor = System.Drawing.SystemColors.Control;
            this.page1.Controls.Add(this.button1);
            this.page1.Controls.Add(this.booktypeTextBox);
            this.page1.Controls.Add(this.tagcolorTextBox);
            this.page1.Controls.Add(label16);
            this.page1.Controls.Add(label15);
            this.page1.Controls.Add(schoutLabel);
            this.page1.Controls.Add(this.schoutDateBox);
            this.page1.Controls.Add(numpgsLabel);
            this.page1.Controls.Add(this.numpgsTextBox);
            this.page1.Controls.Add(this.hndredCheckBox);
            this.page1.Controls.Add(this.recv4memoTextBox);
            this.page1.Controls.Add(this.recv3memoTextBox);
            this.page1.Controls.Add(this.recv2memoTextBox);
            this.page1.Controls.Add(this.bkcs4DateBox);
            this.page1.Controls.Add(this.tocs4DateBox);
            this.page1.Controls.Add(this.bkcs3DateBox);
            this.page1.Controls.Add(this.tocs3DateBox);
            this.page1.Controls.Add(this.bkcs2DateBox);
            this.page1.Controls.Add(this.tocs2DateBox);
            this.page1.Controls.Add(this.recv4TextBox);
            this.page1.Controls.Add(this.recv3TextBox);
            this.page1.Controls.Add(this.recv2TextBox);
            this.page1.Controls.Add(label11);
            this.page1.Controls.Add(label10);
            this.page1.Controls.Add(label9);
            this.page1.Controls.Add(this.recvmemoTextBox);
            this.page1.Controls.Add(this.bkcsDateBox);
            this.page1.Controls.Add(this.tocsDateBox);
            this.page1.Controls.Add(this.label7);
            this.page1.Controls.Add(this.label8);
            this.page1.Controls.Add(this.label5);
            this.page1.Controls.Add(this.label6);
            this.page1.Controls.Add(this.label3);
            this.page1.Controls.Add(this.label4);
            this.page1.Controls.Add(this.label2);
            this.page1.Controls.Add(this.label1);
            this.page1.Controls.Add(recv1Label);
            this.page1.Controls.Add(this.recv1TextBox);
            this.page1.Controls.Add(prodnoLabel);
            this.page1.Controls.Add(this.prodnoLabel1);
            this.page1.Controls.Add(contryearLabel);
            this.page1.Controls.Add(this.contryearLabel1);
            this.page1.Controls.Add(invnoLabel);
            this.page1.Controls.Add(this.invnoLabel1);
            this.page1.Controls.Add(schnameLabel);
            this.page1.Controls.Add(this.schnameLabel1);
            this.page1.Controls.Add(schcodeLabel);
            this.page1.Controls.Add(this.schcodeLabel1);
            this.page1.Location = new System.Drawing.Point(4, 22);
            this.page1.Name = "page1";
            this.page1.Padding = new System.Windows.Forms.Padding(3);
            this.page1.Size = new System.Drawing.Size(889, 455);
            this.page1.TabIndex = 0;
            this.page1.Text = "Receiving";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(672, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 30);
            this.button1.TabIndex = 57;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // booktypeTextBox
            // 
            this.booktypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.booktypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "booktype", true));
            this.booktypeTextBox.Location = new System.Drawing.Point(737, 146);
            this.booktypeTextBox.Name = "booktypeTextBox";
            this.booktypeTextBox.Size = new System.Drawing.Size(32, 20);
            this.booktypeTextBox.TabIndex = 53;
            // 
            // tagcolorTextBox
            // 
            this.tagcolorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tagcolorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "tagcolor", true));
            this.tagcolorTextBox.Location = new System.Drawing.Point(737, 168);
            this.tagcolorTextBox.Name = "tagcolorTextBox";
            this.tagcolorTextBox.Size = new System.Drawing.Size(43, 20);
            this.tagcolorTextBox.TabIndex = 52;
            // 
            // schoutDateBox
            // 
            this.schoutDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.schoutDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.recv2BindingSource, "schout", true));
            this.schoutDateBox.Date = null;
            this.schoutDateBox.DateValue = null;
            this.schoutDateBox.Location = new System.Drawing.Point(673, 121);
            this.schoutDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.schoutDateBox.Name = "schoutDateBox";
            this.schoutDateBox.Size = new System.Drawing.Size(114, 21);
            this.schoutDateBox.TabIndex = 42;
            // 
            // numpgsTextBox
            // 
            this.numpgsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numpgsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "numpgs", true));
            this.numpgsTextBox.Location = new System.Drawing.Point(672, 98);
            this.numpgsTextBox.Name = "numpgsTextBox";
            this.numpgsTextBox.Size = new System.Drawing.Size(25, 20);
            this.numpgsTextBox.TabIndex = 40;
            // 
            // hndredCheckBox
            // 
            this.hndredCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hndredCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.recv2BindingSource, "hndred", true));
            this.hndredCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hndredCheckBox.Location = new System.Drawing.Point(673, 78);
            this.hndredCheckBox.Name = "hndredCheckBox";
            this.hndredCheckBox.Size = new System.Drawing.Size(56, 24);
            this.hndredCheckBox.TabIndex = 39;
            this.hndredCheckBox.Text = "100%";
            this.hndredCheckBox.UseVisualStyleBackColor = true;
            // 
            // recv4memoTextBox
            // 
            this.recv4memoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recv4memoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "recv4memo", true));
            this.recv4memoTextBox.Location = new System.Drawing.Point(251, 292);
            this.recv4memoTextBox.Multiline = true;
            this.recv4memoTextBox.Name = "recv4memoTextBox";
            this.recv4memoTextBox.Size = new System.Drawing.Size(406, 68);
            this.recv4memoTextBox.TabIndex = 38;
            // 
            // recv3memoTextBox
            // 
            this.recv3memoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recv3memoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "recv3memo", true));
            this.recv3memoTextBox.Location = new System.Drawing.Point(251, 220);
            this.recv3memoTextBox.Multiline = true;
            this.recv3memoTextBox.Name = "recv3memoTextBox";
            this.recv3memoTextBox.Size = new System.Drawing.Size(406, 68);
            this.recv3memoTextBox.TabIndex = 37;
            // 
            // recv2memoTextBox
            // 
            this.recv2memoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recv2memoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "recv2memo", true));
            this.recv2memoTextBox.Location = new System.Drawing.Point(251, 149);
            this.recv2memoTextBox.Multiline = true;
            this.recv2memoTextBox.Name = "recv2memoTextBox";
            this.recv2memoTextBox.Size = new System.Drawing.Size(406, 68);
            this.recv2memoTextBox.TabIndex = 36;
            // 
            // bkcs4DateBox
            // 
            this.bkcs4DateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.recv2BindingSource, "bkcs4", true));
            this.bkcs4DateBox.Date = null;
            this.bkcs4DateBox.DateValue = null;
            this.bkcs4DateBox.Location = new System.Drawing.Point(120, 336);
            this.bkcs4DateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.bkcs4DateBox.Name = "bkcs4DateBox";
            this.bkcs4DateBox.Size = new System.Drawing.Size(114, 21);
            this.bkcs4DateBox.TabIndex = 35;
            // 
            // tocs4DateBox
            // 
            this.tocs4DateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.recv2BindingSource, "tocs4", true));
            this.tocs4DateBox.Date = null;
            this.tocs4DateBox.DateValue = null;
            this.tocs4DateBox.Location = new System.Drawing.Point(120, 313);
            this.tocs4DateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.tocs4DateBox.Name = "tocs4DateBox";
            this.tocs4DateBox.Size = new System.Drawing.Size(114, 21);
            this.tocs4DateBox.TabIndex = 34;
            // 
            // bkcs3DateBox
            // 
            this.bkcs3DateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.recv2BindingSource, "bkcs3", true));
            this.bkcs3DateBox.Date = null;
            this.bkcs3DateBox.DateValue = null;
            this.bkcs3DateBox.Location = new System.Drawing.Point(120, 269);
            this.bkcs3DateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.bkcs3DateBox.Name = "bkcs3DateBox";
            this.bkcs3DateBox.Size = new System.Drawing.Size(114, 21);
            this.bkcs3DateBox.TabIndex = 33;
            // 
            // tocs3DateBox
            // 
            this.tocs3DateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.recv2BindingSource, "tocs3", true));
            this.tocs3DateBox.Date = null;
            this.tocs3DateBox.DateValue = null;
            this.tocs3DateBox.Location = new System.Drawing.Point(120, 247);
            this.tocs3DateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.tocs3DateBox.Name = "tocs3DateBox";
            this.tocs3DateBox.Size = new System.Drawing.Size(114, 21);
            this.tocs3DateBox.TabIndex = 32;
            // 
            // bkcs2DateBox
            // 
            this.bkcs2DateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.recv2BindingSource, "bkcs2", true));
            this.bkcs2DateBox.Date = null;
            this.bkcs2DateBox.DateValue = null;
            this.bkcs2DateBox.Location = new System.Drawing.Point(120, 195);
            this.bkcs2DateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.bkcs2DateBox.Name = "bkcs2DateBox";
            this.bkcs2DateBox.Size = new System.Drawing.Size(114, 21);
            this.bkcs2DateBox.TabIndex = 31;
            // 
            // tocs2DateBox
            // 
            this.tocs2DateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.recv2BindingSource, "tocs2", true));
            this.tocs2DateBox.Date = null;
            this.tocs2DateBox.DateValue = null;
            this.tocs2DateBox.Location = new System.Drawing.Point(120, 173);
            this.tocs2DateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.tocs2DateBox.Name = "tocs2DateBox";
            this.tocs2DateBox.Size = new System.Drawing.Size(114, 21);
            this.tocs2DateBox.TabIndex = 30;
            // 
            // recv4TextBox
            // 
            this.recv4TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "recv4", true));
            this.recv4TextBox.Location = new System.Drawing.Point(48, 292);
            this.recv4TextBox.Name = "recv4TextBox";
            this.recv4TextBox.Size = new System.Drawing.Size(27, 20);
            this.recv4TextBox.TabIndex = 29;
            // 
            // recv3TextBox
            // 
            this.recv3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "recv3", true));
            this.recv3TextBox.Location = new System.Drawing.Point(48, 220);
            this.recv3TextBox.Name = "recv3TextBox";
            this.recv3TextBox.Size = new System.Drawing.Size(27, 20);
            this.recv3TextBox.TabIndex = 28;
            // 
            // recv2TextBox
            // 
            this.recv2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "recv2", true));
            this.recv2TextBox.Location = new System.Drawing.Point(48, 149);
            this.recv2TextBox.Name = "recv2TextBox";
            this.recv2TextBox.Size = new System.Drawing.Size(27, 20);
            this.recv2TextBox.TabIndex = 27;
            // 
            // recvmemoTextBox
            // 
            this.recvmemoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recvmemoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "recvmemo", true));
            this.recvmemoTextBox.Location = new System.Drawing.Point(251, 78);
            this.recvmemoTextBox.Multiline = true;
            this.recvmemoTextBox.Name = "recvmemoTextBox";
            this.recvmemoTextBox.Size = new System.Drawing.Size(406, 68);
            this.recvmemoTextBox.TabIndex = 23;
            // 
            // bkcsDateBox
            // 
            this.bkcsDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.recv2BindingSource, "bkcs", true));
            this.bkcsDateBox.Date = null;
            this.bkcsDateBox.DateValue = null;
            this.bkcsDateBox.Location = new System.Drawing.Point(120, 123);
            this.bkcsDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.bkcsDateBox.Name = "bkcsDateBox";
            this.bkcsDateBox.Size = new System.Drawing.Size(114, 21);
            this.bkcsDateBox.TabIndex = 22;
            // 
            // tocsDateBox
            // 
            this.tocsDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.recv2BindingSource, "tocs", true));
            this.tocsDateBox.Date = null;
            this.tocsDateBox.DateValue = null;
            this.tocsDateBox.Location = new System.Drawing.Point(120, 101);
            this.tocsDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.tocsDateBox.Name = "tocsDateBox";
            this.tocsDateBox.Size = new System.Drawing.Size(114, 21);
            this.tocsDateBox.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Back from CS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(46, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Date to CS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Back from CS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Date to CS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Back from CS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Date to CS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Back from CS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Date to CS";
            // 
            // recv1TextBox
            // 
            this.recv1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "recv1", true));
            this.recv1TextBox.Location = new System.Drawing.Point(48, 78);
            this.recv1TextBox.Name = "recv1TextBox";
            this.recv1TextBox.Size = new System.Drawing.Size(27, 20);
            this.recv1TextBox.TabIndex = 11;
            // 
            // prodnoLabel1
            // 
            this.prodnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "prodno", true));
            this.prodnoLabel1.Location = new System.Drawing.Point(281, 47);
            this.prodnoLabel1.Name = "prodnoLabel1";
            this.prodnoLabel1.Size = new System.Drawing.Size(133, 13);
            this.prodnoLabel1.TabIndex = 9;
            this.prodnoLabel1.Text = "label1";
            // 
            // contryearLabel1
            // 
            this.contryearLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "contryear", true));
            this.contryearLabel1.Location = new System.Drawing.Point(107, 47);
            this.contryearLabel1.Name = "contryearLabel1";
            this.contryearLabel1.Size = new System.Drawing.Size(58, 13);
            this.contryearLabel1.TabIndex = 7;
            this.contryearLabel1.Text = "label1";
            // 
            // invnoLabel1
            // 
            this.invnoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "invno", true));
            this.invnoLabel1.Location = new System.Drawing.Point(584, 21);
            this.invnoLabel1.Name = "invnoLabel1";
            this.invnoLabel1.Size = new System.Drawing.Size(100, 13);
            this.invnoLabel1.TabIndex = 5;
            this.invnoLabel1.Text = "label1";
            // 
            // schnameLabel1
            // 
            this.schnameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "schname", true));
            this.schnameLabel1.Location = new System.Drawing.Point(281, 21);
            this.schnameLabel1.Name = "schnameLabel1";
            this.schnameLabel1.Size = new System.Drawing.Size(237, 13);
            this.schnameLabel1.TabIndex = 3;
            this.schnameLabel1.Text = "label1";
            // 
            // schcodeLabel1
            // 
            this.schcodeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recv2BindingSource, "schcode", true));
            this.schcodeLabel1.Location = new System.Drawing.Point(107, 21);
            this.schcodeLabel1.Name = "schcodeLabel1";
            this.schcodeLabel1.Size = new System.Drawing.Size(70, 13);
            this.schcodeLabel1.TabIndex = 1;
            this.schcodeLabel1.Text = "label1";
            // 
            // page2
            // 
            this.page2.BackColor = System.Drawing.SystemColors.Control;
            this.page2.Location = new System.Drawing.Point(4, 22);
            this.page2.Name = "page2";
            this.page2.Padding = new System.Windows.Forms.Padding(3);
            this.page2.Size = new System.Drawing.Size(889, 455);
            this.page2.TabIndex = 1;
            this.page2.Text = "Problems/Compensations";
            // 
            // recv2BindingSource
            // 
            this.recv2BindingSource.DataMember = "recv2";
            this.recv2BindingSource.DataSource = this.dsReceiving;
            // 
            // dsReceiving
            // 
            this.dsReceiving.DataSetName = "dsReceiving";
            this.dsReceiving.EnforceConstraints = false;
            this.dsReceiving.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recv2TableAdapter
            // 
            this.recv2TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.recv2TableAdapter = this.recv2TableAdapter;
            this.tableAdapterManager.surv2TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsReceivingTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmRecSurvey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(897, 481);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(913, 520);
            this.Name = "frmRecSurvey";
            this.Text = "Receiving-Survey-Compensation";
            this.Load += new System.EventHandler(this.frmRecSurvey_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.page1.ResumeLayout(false);
            this.page1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recv2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReceiving)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage page1;
        private System.Windows.Forms.TabPage page2;
        private DataSets.dsReceiving dsReceiving;
        private System.Windows.Forms.BindingSource recv2BindingSource;
        private DataSets.dsReceivingTableAdapters.recv2TableAdapter recv2TableAdapter;
        private DataSets.dsReceivingTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label invnoLabel1;
        private System.Windows.Forms.Label schnameLabel1;
        private System.Windows.Forms.Label schcodeLabel1;
        private System.Windows.Forms.Label contryearLabel1;
        private System.Windows.Forms.Label prodnoLabel1;
        private System.Windows.Forms.TextBox tagcolorTextBox;
        private CustomControls.DateBox schoutDateBox;
        private System.Windows.Forms.TextBox numpgsTextBox;
        private System.Windows.Forms.CheckBox hndredCheckBox;
        private System.Windows.Forms.TextBox recv4memoTextBox;
        private System.Windows.Forms.TextBox recv3memoTextBox;
        private System.Windows.Forms.TextBox recv2memoTextBox;
        private CustomControls.DateBox bkcs4DateBox;
        private CustomControls.DateBox tocs4DateBox;
        private CustomControls.DateBox bkcs3DateBox;
        private CustomControls.DateBox tocs3DateBox;
        private CustomControls.DateBox bkcs2DateBox;
        private CustomControls.DateBox tocs2DateBox;
        private System.Windows.Forms.TextBox recv4TextBox;
        private System.Windows.Forms.TextBox recv3TextBox;
        private System.Windows.Forms.TextBox recv2TextBox;
        private System.Windows.Forms.TextBox recvmemoTextBox;
        private CustomControls.DateBox bkcsDateBox;
        private CustomControls.DateBox tocsDateBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox recv1TextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox booktypeTextBox;
    }
}
