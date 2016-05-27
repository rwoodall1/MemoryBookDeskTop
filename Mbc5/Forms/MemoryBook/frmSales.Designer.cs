namespace Mbc5.Forms.MemoryBook {
    partial class frmSales {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nopagesLabel;
            System.Windows.Forms.Label contryearLabel;
            System.Windows.Forms.Label bpyearLabel;
            System.Windows.Forms.Label ponumLabel;
            System.Windows.Forms.Label qtedateLabel;
            System.Windows.Forms.Label nocopiesLabel;
            System.Windows.Forms.Label booktypeLabel;
            System.Windows.Forms.Label sourceLabel;
            System.Windows.Forms.Label book_eaLabel;
            System.Windows.Forms.Label book_priceLabel;
            System.Windows.Forms.Label prcorLabel;
            System.Windows.Forms.Label inkclrLabel;
            this.tabSales = new System.Windows.Forms.TabControl();
            this.pg1 = new System.Windows.Forms.TabPage();
            this.lblPCEach = new System.Windows.Forms.Label();
            this.lblPCTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.prcorTextBox = new System.Windows.Forms.TextBox();
            this.quotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSales = new Mbc5.DataSets.dsSales();
            this.txtBookTotal = new System.Windows.Forms.TextBox();
            this.book_eaTextBox = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.booktypeTextBox = new System.Windows.Forms.TextBox();
            this.txtNocopies = new System.Windows.Forms.TextBox();
            this.dteQuote = new System.Windows.Forms.DateTimePicker();
            this.txtPoNum = new System.Windows.Forms.TextBox();
            this.txtBYear = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtNoPages = new System.Windows.Forms.TextBox();
            this.txtYir = new System.Windows.Forms.TextBox();
            this.chkYir = new System.Windows.Forms.CheckBox();
            this.txtConvAmt = new System.Windows.Forms.TextBox();
            this.chkConv = new System.Windows.Forms.CheckBox();
            this.txtProfAmt = new System.Windows.Forms.TextBox();
            this.chkProfessional = new System.Windows.Forms.CheckBox();
            this.txtSaddleAmt = new System.Windows.Forms.TextBox();
            this.chkSaddlStich = new System.Windows.Forms.CheckBox();
            this.txtSpiralAmt = new System.Windows.Forms.TextBox();
            this.chkSpiral = new System.Windows.Forms.CheckBox();
            this.txtPerfbindAmt = new System.Windows.Forms.TextBox();
            this.chkPerfBind = new System.Windows.Forms.CheckBox();
            this.txtCaseamt = new System.Windows.Forms.TextBox();
            this.chkCaseBind = new System.Windows.Forms.CheckBox();
            this.txtHardbackAmt = new System.Windows.Forms.TextBox();
            this.chkHardBack = new System.Windows.Forms.CheckBox();
            this.pg2 = new System.Windows.Forms.TabPage();
            this.quotesTableAdapter = new Mbc5.DataSets.dsSalesTableAdapters.quotesTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager();
            this.chkAllClr = new System.Windows.Forms.CheckBox();
            this.txtAllClrAmt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkGlossLam = new System.Windows.Forms.CheckBox();
            this.txtLaminateAmt = new System.Windows.Forms.TextBox();
            this.txtLaminate = new System.Windows.Forms.TextBox();
            this.chkMLaminate = new System.Windows.Forms.CheckBox();
            this.inkclrComboBox = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            nopagesLabel = new System.Windows.Forms.Label();
            contryearLabel = new System.Windows.Forms.Label();
            bpyearLabel = new System.Windows.Forms.Label();
            ponumLabel = new System.Windows.Forms.Label();
            qtedateLabel = new System.Windows.Forms.Label();
            nocopiesLabel = new System.Windows.Forms.Label();
            booktypeLabel = new System.Windows.Forms.Label();
            sourceLabel = new System.Windows.Forms.Label();
            book_eaLabel = new System.Windows.Forms.Label();
            book_priceLabel = new System.Windows.Forms.Label();
            prcorLabel = new System.Windows.Forms.Label();
            inkclrLabel = new System.Windows.Forms.Label();
            this.tabSales.SuspendLayout();
            this.pg1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).BeginInit();
            this.SuspendLayout();
            // 
            // nopagesLabel
            // 
            nopagesLabel.AutoSize = true;
            nopagesLabel.Location = new System.Drawing.Point(152, 74);
            nopagesLabel.Name = "nopagesLabel";
            nopagesLabel.Size = new System.Drawing.Size(30, 13);
            nopagesLabel.TabIndex = 17;
            nopagesLabel.Text = "#Pg";
            // 
            // contryearLabel
            // 
            contryearLabel.AutoSize = true;
            contryearLabel.Location = new System.Drawing.Point(134, 44);
            contryearLabel.Name = "contryearLabel";
            contryearLabel.Size = new System.Drawing.Size(37, 13);
            contryearLabel.TabIndex = 18;
            contryearLabel.Text = "Year:";
            // 
            // bpyearLabel
            // 
            bpyearLabel.AutoSize = true;
            bpyearLabel.Location = new System.Drawing.Point(219, 44);
            bpyearLabel.Name = "bpyearLabel";
            bpyearLabel.Size = new System.Drawing.Size(102, 13);
            bpyearLabel.TabIndex = 20;
            bpyearLabel.Text = "Base Price Year:";
            // 
            // ponumLabel
            // 
            ponumLabel.AutoSize = true;
            ponumLabel.Location = new System.Drawing.Point(371, 44);
            ponumLabel.Name = "ponumLabel";
            ponumLabel.Size = new System.Drawing.Size(36, 13);
            ponumLabel.TabIndex = 22;
            ponumLabel.Text = "PO#:";
            // 
            // qtedateLabel
            // 
            qtedateLabel.AutoSize = true;
            qtedateLabel.Location = new System.Drawing.Point(530, 44);
            qtedateLabel.Name = "qtedateLabel";
            qtedateLabel.Size = new System.Drawing.Size(76, 13);
            qtedateLabel.TabIndex = 24;
            qtedateLabel.Text = "Quote Date:";
            // 
            // nocopiesLabel
            // 
            nocopiesLabel.AutoSize = true;
            nocopiesLabel.Location = new System.Drawing.Point(23, 74);
            nocopiesLabel.Name = "nocopiesLabel";
            nocopiesLabel.Size = new System.Drawing.Size(57, 13);
            nocopiesLabel.TabIndex = 26;
            nocopiesLabel.Text = "#Copies:";
            // 
            // booktypeLabel
            // 
            booktypeLabel.AutoSize = true;
            booktypeLabel.Location = new System.Drawing.Point(14, 44);
            booktypeLabel.Name = "booktypeLabel";
            booktypeLabel.Size = new System.Drawing.Size(72, 13);
            booktypeLabel.TabIndex = 28;
            booktypeLabel.Text = "Book Type:";
            // 
            // sourceLabel
            // 
            sourceLabel.AutoSize = true;
            sourceLabel.Location = new System.Drawing.Point(829, 44);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new System.Drawing.Size(51, 13);
            sourceLabel.TabIndex = 30;
            sourceLabel.Text = "Source:";
            // 
            // book_eaLabel
            // 
            book_eaLabel.AutoSize = true;
            book_eaLabel.Location = new System.Drawing.Point(239, 74);
            book_eaLabel.Name = "book_eaLabel";
            book_eaLabel.Size = new System.Drawing.Size(73, 13);
            book_eaLabel.TabIndex = 32;
            book_eaLabel.Text = "Price Each:";
            // 
            // book_priceLabel
            // 
            book_priceLabel.AutoSize = true;
            book_priceLabel.Location = new System.Drawing.Point(397, 74);
            book_priceLabel.Name = "book_priceLabel";
            book_priceLabel.Size = new System.Drawing.Size(77, 13);
            book_priceLabel.TabIndex = 34;
            book_priceLabel.Text = "Book (total):";
            // 
            // prcorLabel
            // 
            prcorLabel.AutoSize = true;
            prcorLabel.Location = new System.Drawing.Point(209, 99);
            prcorLabel.Name = "prcorLabel";
            prcorLabel.Size = new System.Drawing.Size(101, 13);
            prcorLabel.TabIndex = 36;
            prcorLabel.Text = "Price Over Ride:";
            // 
            // tabSales
            // 
            this.tabSales.Controls.Add(this.pg1);
            this.tabSales.Controls.Add(this.pg2);
            this.tabSales.Location = new System.Drawing.Point(0, 0);
            this.tabSales.Name = "tabSales";
            this.tabSales.SelectedIndex = 0;
            this.tabSales.Size = new System.Drawing.Size(1263, 762);
            this.tabSales.TabIndex = 0;
            // 
            // pg1
            // 
            this.pg1.BackColor = System.Drawing.SystemColors.Control;
            this.pg1.Controls.Add(this.textBox2);
            this.pg1.Controls.Add(this.label4);
            this.pg1.Controls.Add(this.inkclrComboBox);
            this.pg1.Controls.Add(inkclrLabel);
            this.pg1.Controls.Add(this.chkMLaminate);
            this.pg1.Controls.Add(this.txtLaminate);
            this.pg1.Controls.Add(this.txtLaminateAmt);
            this.pg1.Controls.Add(this.chkGlossLam);
            this.pg1.Controls.Add(this.textBox1);
            this.pg1.Controls.Add(this.label3);
            this.pg1.Controls.Add(this.txtAllClrAmt);
            this.pg1.Controls.Add(this.chkAllClr);
            this.pg1.Controls.Add(this.lblPCEach);
            this.pg1.Controls.Add(this.lblPCTotal);
            this.pg1.Controls.Add(this.label2);
            this.pg1.Controls.Add(this.label1);
            this.pg1.Controls.Add(prcorLabel);
            this.pg1.Controls.Add(this.prcorTextBox);
            this.pg1.Controls.Add(book_priceLabel);
            this.pg1.Controls.Add(this.txtBookTotal);
            this.pg1.Controls.Add(book_eaLabel);
            this.pg1.Controls.Add(this.book_eaTextBox);
            this.pg1.Controls.Add(sourceLabel);
            this.pg1.Controls.Add(this.txtSource);
            this.pg1.Controls.Add(booktypeLabel);
            this.pg1.Controls.Add(this.booktypeTextBox);
            this.pg1.Controls.Add(nocopiesLabel);
            this.pg1.Controls.Add(this.txtNocopies);
            this.pg1.Controls.Add(qtedateLabel);
            this.pg1.Controls.Add(this.dteQuote);
            this.pg1.Controls.Add(ponumLabel);
            this.pg1.Controls.Add(this.txtPoNum);
            this.pg1.Controls.Add(bpyearLabel);
            this.pg1.Controls.Add(this.txtBYear);
            this.pg1.Controls.Add(contryearLabel);
            this.pg1.Controls.Add(this.txtYear);
            this.pg1.Controls.Add(nopagesLabel);
            this.pg1.Controls.Add(this.txtNoPages);
            this.pg1.Controls.Add(this.txtYir);
            this.pg1.Controls.Add(this.chkYir);
            this.pg1.Controls.Add(this.txtConvAmt);
            this.pg1.Controls.Add(this.chkConv);
            this.pg1.Controls.Add(this.txtProfAmt);
            this.pg1.Controls.Add(this.chkProfessional);
            this.pg1.Controls.Add(this.txtSaddleAmt);
            this.pg1.Controls.Add(this.chkSaddlStich);
            this.pg1.Controls.Add(this.txtSpiralAmt);
            this.pg1.Controls.Add(this.chkSpiral);
            this.pg1.Controls.Add(this.txtPerfbindAmt);
            this.pg1.Controls.Add(this.chkPerfBind);
            this.pg1.Controls.Add(this.txtCaseamt);
            this.pg1.Controls.Add(this.chkCaseBind);
            this.pg1.Controls.Add(this.txtHardbackAmt);
            this.pg1.Controls.Add(this.chkHardBack);
            this.pg1.Location = new System.Drawing.Point(4, 22);
            this.pg1.Name = "pg1";
            this.pg1.Padding = new System.Windows.Forms.Padding(3);
            this.pg1.Size = new System.Drawing.Size(1255, 736);
            this.pg1.TabIndex = 0;
            this.pg1.Text = "Sales";
            // 
            // lblPCEach
            // 
            this.lblPCEach.AutoSize = true;
            this.lblPCEach.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPCEach.Location = new System.Drawing.Point(692, 74);
            this.lblPCEach.Name = "lblPCEach";
            this.lblPCEach.Size = new System.Drawing.Size(41, 13);
            this.lblPCEach.TabIndex = 41;
            this.lblPCEach.Text = "label3";
            // 
            // lblPCTotal
            // 
            this.lblPCTotal.AutoSize = true;
            this.lblPCTotal.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPCTotal.Location = new System.Drawing.Point(850, 74);
            this.lblPCTotal.Name = "lblPCTotal";
            this.lblPCTotal.Size = new System.Drawing.Size(41, 13);
            this.lblPCTotal.TabIndex = 40;
            this.lblPCTotal.Text = "label4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(749, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Total Prof/Conv:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(591, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Porf/Conv Each:";
            // 
            // prcorTextBox
            // 
            this.prcorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "prcor", true));
            this.prcorTextBox.Location = new System.Drawing.Point(316, 99);
            this.prcorTextBox.Name = "prcorTextBox";
            this.prcorTextBox.Size = new System.Drawing.Size(69, 20);
            this.prcorTextBox.TabIndex = 37;
            // 
            // quotesBindingSource
            // 
            this.quotesBindingSource.DataMember = "quotes";
            this.quotesBindingSource.DataSource = this.dsSales;
            // 
            // dsSales
            // 
            this.dsSales.DataSetName = "dsSales";
            this.dsSales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtBookTotal
            // 
            this.txtBookTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "book_price", true));
            this.txtBookTotal.Location = new System.Drawing.Point(474, 74);
            this.txtBookTotal.Name = "txtBookTotal";
            this.txtBookTotal.Size = new System.Drawing.Size(100, 20);
            this.txtBookTotal.TabIndex = 35;
            // 
            // book_eaTextBox
            // 
            this.book_eaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "book_ea", true));
            this.book_eaTextBox.Location = new System.Drawing.Point(316, 74);
            this.book_eaTextBox.Name = "book_eaTextBox";
            this.book_eaTextBox.Size = new System.Drawing.Size(69, 20);
            this.book_eaTextBox.TabIndex = 33;
            // 
            // txtSource
            // 
            this.txtSource.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "source", true));
            this.txtSource.Location = new System.Drawing.Point(886, 44);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(100, 20);
            this.txtSource.TabIndex = 31;
            // 
            // booktypeTextBox
            // 
            this.booktypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "booktype", true));
            this.booktypeTextBox.Location = new System.Drawing.Point(92, 44);
            this.booktypeTextBox.MaxLength = 4;
            this.booktypeTextBox.Name = "booktypeTextBox";
            this.booktypeTextBox.Size = new System.Drawing.Size(44, 20);
            this.booktypeTextBox.TabIndex = 29;
            // 
            // txtNocopies
            // 
            this.txtNocopies.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "nocopies", true));
            this.txtNocopies.Location = new System.Drawing.Point(86, 74);
            this.txtNocopies.MaxLength = 5;
            this.txtNocopies.Name = "txtNocopies";
            this.txtNocopies.Size = new System.Drawing.Size(50, 20);
            this.txtNocopies.TabIndex = 27;
            // 
            // dteQuote
            // 
            this.dteQuote.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.quotesBindingSource, "qtedate", true));
            this.dteQuote.Location = new System.Drawing.Point(612, 44);
            this.dteQuote.Name = "dteQuote";
            this.dteQuote.Size = new System.Drawing.Size(200, 20);
            this.dteQuote.TabIndex = 25;
            // 
            // txtPoNum
            // 
            this.txtPoNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "ponum", true));
            this.txtPoNum.Location = new System.Drawing.Point(413, 44);
            this.txtPoNum.Name = "txtPoNum";
            this.txtPoNum.Size = new System.Drawing.Size(100, 20);
            this.txtPoNum.TabIndex = 23;
            // 
            // txtBYear
            // 
            this.txtBYear.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "bpyear", true));
            this.txtBYear.Location = new System.Drawing.Point(327, 44);
            this.txtBYear.MaxLength = 2;
            this.txtBYear.Name = "txtBYear";
            this.txtBYear.Size = new System.Drawing.Size(31, 20);
            this.txtBYear.TabIndex = 21;
            // 
            // txtYear
            // 
            this.txtYear.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "contryear", true));
            this.txtYear.Location = new System.Drawing.Point(177, 44);
            this.txtYear.MaxLength = 2;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(39, 20);
            this.txtYear.TabIndex = 19;
            this.txtYear.TextChanged += new System.EventHandler(this.contryearTextBox_TextChanged);
            // 
            // txtNoPages
            // 
            this.txtNoPages.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "nopages", true));
            this.txtNoPages.Location = new System.Drawing.Point(186, 74);
            this.txtNoPages.MaxLength = 4;
            this.txtNoPages.Name = "txtNoPages";
            this.txtNoPages.Size = new System.Drawing.Size(37, 20);
            this.txtNoPages.TabIndex = 18;
            // 
            // txtYir
            // 
            this.txtYir.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "insamt", true));
            this.txtYir.Location = new System.Drawing.Point(196, 569);
            this.txtYir.Name = "txtYir";
            this.txtYir.Size = new System.Drawing.Size(100, 20);
            this.txtYir.TabIndex = 17;
            // 
            // chkYir
            // 
            this.chkYir.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkYir.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "insck", true));
            this.chkYir.Location = new System.Drawing.Point(76, 569);
            this.chkYir.Name = "chkYir";
            this.chkYir.Size = new System.Drawing.Size(104, 24);
            this.chkYir.TabIndex = 16;
            this.chkYir.Text = "YIR Standard";
            this.chkYir.UseVisualStyleBackColor = true;
            // 
            // txtConvAmt
            // 
            this.txtConvAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "conven", true));
            this.txtConvAmt.Location = new System.Drawing.Point(196, 539);
            this.txtConvAmt.Name = "txtConvAmt";
            this.txtConvAmt.Size = new System.Drawing.Size(100, 20);
            this.txtConvAmt.TabIndex = 15;
            // 
            // chkConv
            // 
            this.chkConv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkConv.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "coyn", true));
            this.chkConv.Location = new System.Drawing.Point(76, 539);
            this.chkConv.Name = "chkConv";
            this.chkConv.Size = new System.Drawing.Size(104, 24);
            this.chkConv.TabIndex = 14;
            this.chkConv.Text = "Convenient";
            this.chkConv.UseVisualStyleBackColor = true;
            // 
            // txtProfAmt
            // 
            this.txtProfAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "prof", true));
            this.txtProfAmt.Location = new System.Drawing.Point(196, 510);
            this.txtProfAmt.Name = "txtProfAmt";
            this.txtProfAmt.Size = new System.Drawing.Size(100, 20);
            this.txtProfAmt.TabIndex = 13;
            // 
            // chkProfessional
            // 
            this.chkProfessional.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkProfessional.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "pryn", true));
            this.chkProfessional.Location = new System.Drawing.Point(76, 508);
            this.chkProfessional.Name = "chkProfessional";
            this.chkProfessional.Size = new System.Drawing.Size(104, 24);
            this.chkProfessional.TabIndex = 12;
            this.chkProfessional.Text = "Professional";
            this.chkProfessional.UseVisualStyleBackColor = true;
            // 
            // txtSaddleAmt
            // 
            this.txtSaddleAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "sdlstichamt", true));
            this.txtSaddleAmt.Location = new System.Drawing.Point(196, 478);
            this.txtSaddleAmt.Name = "txtSaddleAmt";
            this.txtSaddleAmt.Size = new System.Drawing.Size(100, 20);
            this.txtSaddleAmt.TabIndex = 11;
            // 
            // chkSaddlStich
            // 
            this.chkSaddlStich.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSaddlStich.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "sdlstich", true));
            this.chkSaddlStich.Location = new System.Drawing.Point(76, 478);
            this.chkSaddlStich.Name = "chkSaddlStich";
            this.chkSaddlStich.Size = new System.Drawing.Size(104, 24);
            this.chkSaddlStich.TabIndex = 10;
            this.chkSaddlStich.Text = "Saddle Stitch";
            this.chkSaddlStich.UseVisualStyleBackColor = true;
            // 
            // txtSpiralAmt
            // 
            this.txtSpiralAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "spiramt", true));
            this.txtSpiralAmt.Location = new System.Drawing.Point(196, 446);
            this.txtSpiralAmt.Name = "txtSpiralAmt";
            this.txtSpiralAmt.Size = new System.Drawing.Size(100, 20);
            this.txtSpiralAmt.TabIndex = 9;
            // 
            // chkSpiral
            // 
            this.chkSpiral.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSpiral.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "spirck", true));
            this.chkSpiral.Location = new System.Drawing.Point(76, 444);
            this.chkSpiral.Name = "chkSpiral";
            this.chkSpiral.Size = new System.Drawing.Size(104, 24);
            this.chkSpiral.TabIndex = 8;
            this.chkSpiral.Text = "Spiral";
            this.chkSpiral.UseVisualStyleBackColor = true;
            // 
            // txtPerfbindAmt
            // 
            this.txtPerfbindAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "perfbind", true));
            this.txtPerfbindAmt.Location = new System.Drawing.Point(196, 420);
            this.txtPerfbindAmt.Name = "txtPerfbindAmt";
            this.txtPerfbindAmt.Size = new System.Drawing.Size(100, 20);
            this.txtPerfbindAmt.TabIndex = 7;
            // 
            // chkPerfBind
            // 
            this.chkPerfBind.AutoSize = true;
            this.chkPerfBind.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPerfBind.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "peyn", true));
            this.chkPerfBind.Location = new System.Drawing.Point(58, 418);
            this.chkPerfBind.Name = "chkPerfBind";
            this.chkPerfBind.Size = new System.Drawing.Size(122, 17);
            this.chkPerfBind.TabIndex = 6;
            this.chkPerfBind.Text = "Perfect Bind (40)";
            this.chkPerfBind.UseVisualStyleBackColor = true;
            // 
            // txtCaseamt
            // 
            this.txtCaseamt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "caseamt", true));
            this.txtCaseamt.Location = new System.Drawing.Point(196, 395);
            this.txtCaseamt.Name = "txtCaseamt";
            this.txtCaseamt.Size = new System.Drawing.Size(100, 20);
            this.txtCaseamt.TabIndex = 5;
            // 
            // chkCaseBind
            // 
            this.chkCaseBind.AutoSize = true;
            this.chkCaseBind.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCaseBind.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "casey_n", true));
            this.chkCaseBind.Location = new System.Drawing.Point(36, 395);
            this.chkCaseBind.Name = "chkCaseBind";
            this.chkCaseBind.Size = new System.Drawing.Size(144, 17);
            this.chkCaseBind.TabIndex = 4;
            this.chkCaseBind.Text = "Case Bind (glued 32)";
            this.chkCaseBind.UseVisualStyleBackColor = true;
            // 
            // txtHardbackAmt
            // 
            this.txtHardbackAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "hardback", true));
            this.txtHardbackAmt.Location = new System.Drawing.Point(196, 369);
            this.txtHardbackAmt.Name = "txtHardbackAmt";
            this.txtHardbackAmt.Size = new System.Drawing.Size(100, 20);
            this.txtHardbackAmt.TabIndex = 3;
            // 
            // chkHardBack
            // 
            this.chkHardBack.AutoSize = true;
            this.chkHardBack.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHardBack.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "hdbky_n", true));
            this.chkHardBack.Location = new System.Drawing.Point(35, 369);
            this.chkHardBack.Name = "chkHardBack";
            this.chkHardBack.Size = new System.Drawing.Size(145, 17);
            this.chkHardBack.TabIndex = 1;
            this.chkHardBack.Text = "Hard Back (sewn 40)";
            this.chkHardBack.UseVisualStyleBackColor = true;
            // 
            // pg2
            // 
            this.pg2.BackColor = System.Drawing.SystemColors.Control;
            this.pg2.Location = new System.Drawing.Point(4, 22);
            this.pg2.Name = "pg2";
            this.pg2.Padding = new System.Windows.Forms.Padding(3);
            this.pg2.Size = new System.Drawing.Size(1255, 736);
            this.pg2.TabIndex = 1;
            this.pg2.Text = "Invoices";
            // 
            // quotesTableAdapter
            // 
            this.quotesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.custTableAdapter = null;
            this.tableAdapterManager.quotesTableAdapter = this.quotesTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // chkAllClr
            // 
            this.chkAllClr.AutoSize = true;
            this.chkAllClr.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "allclrck", true));
            this.chkAllClr.Location = new System.Drawing.Point(507, 360);
            this.chkAllClr.Name = "chkAllClr";
            this.chkAllClr.Size = new System.Drawing.Size(73, 17);
            this.chkAllClr.TabIndex = 43;
            this.chkAllClr.Text = "All Color";
            this.chkAllClr.UseVisualStyleBackColor = true;
            // 
            // txtAllClrAmt
            // 
            this.txtAllClrAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "allclramt", true));
            this.txtAllClrAmt.Location = new System.Drawing.Point(586, 358);
            this.txtAllClrAmt.Name = "txtAllClrAmt";
            this.txtAllClrAmt.Size = new System.Drawing.Size(100, 20);
            this.txtAllClrAmt.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "# of Color Pages";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(586, 396);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 46;
            // 
            // chkGlossLam
            // 
            this.chkGlossLam.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "layn", true));
            this.chkGlossLam.Location = new System.Drawing.Point(485, 432);
            this.chkGlossLam.Name = "chkGlossLam";
            this.chkGlossLam.Size = new System.Drawing.Size(104, 24);
            this.chkGlossLam.TabIndex = 47;
            this.chkGlossLam.Text = "Gloss Laminate";
            this.chkGlossLam.UseVisualStyleBackColor = true;
            // 
            // txtLaminateAmt
            // 
            this.txtLaminateAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "laminate", true));
            this.txtLaminateAmt.Location = new System.Drawing.Point(564, 432);
            this.txtLaminateAmt.Name = "txtLaminateAmt";
            this.txtLaminateAmt.Size = new System.Drawing.Size(100, 20);
            this.txtLaminateAmt.TabIndex = 48;
            // 
            // txtLaminate
            // 
            this.txtLaminate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "mlaminationamt", true));
            this.txtLaminate.Location = new System.Drawing.Point(594, 464);
            this.txtLaminate.Name = "txtLaminate";
            this.txtLaminate.Size = new System.Drawing.Size(100, 20);
            this.txtLaminate.TabIndex = 49;
            // 
            // chkMLaminate
            // 
            this.chkMLaminate.AutoSize = true;
            this.chkMLaminate.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "mlamination", true));
            this.chkMLaminate.Location = new System.Drawing.Point(474, 462);
            this.chkMLaminate.Name = "chkMLaminate";
            this.chkMLaminate.Size = new System.Drawing.Size(113, 17);
            this.chkMLaminate.TabIndex = 50;
            this.chkMLaminate.Text = "Matte Laminate";
            this.chkMLaminate.UseVisualStyleBackColor = true;
            // 
            // inkclrLabel
            // 
            inkclrLabel.AutoSize = true;
            inkclrLabel.Location = new System.Drawing.Point(480, 509);
            inkclrLabel.Name = "inkclrLabel";
            inkclrLabel.Size = new System.Drawing.Size(80, 13);
            inkclrLabel.TabIndex = 50;
            inkclrLabel.Text = "# Ink Colors:";
            // 
            // inkclrComboBox
            // 
            this.inkclrComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "inkclr", true));
            this.inkclrComboBox.FormattingEnabled = true;
            this.inkclrComboBox.Location = new System.Drawing.Point(566, 510);
            this.inkclrComboBox.Name = "inkclrComboBox";
            this.inkclrComboBox.Size = new System.Drawing.Size(98, 21);
            this.inkclrComboBox.TabIndex = 52;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(546, 543);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(477, 546);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "# of Color";
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.tabSales);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSales";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.frmSales_Load);
            this.tabSales.ResumeLayout(false);
            this.pg1.ResumeLayout(false);
            this.pg1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.TabControl tabSales;
        private System.Windows.Forms.TabPage pg1;
        private System.Windows.Forms.TabPage pg2;
        private DataSets.dsSales dsSales;
        private System.Windows.Forms.BindingSource quotesBindingSource;
        private DataSets.dsSalesTableAdapters.quotesTableAdapter quotesTableAdapter;
        private DataSets.dsSalesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox txtSaddleAmt;
        private System.Windows.Forms.CheckBox chkSaddlStich;
        private System.Windows.Forms.TextBox txtSpiralAmt;
        private System.Windows.Forms.CheckBox chkSpiral;
        private System.Windows.Forms.TextBox txtPerfbindAmt;
        private System.Windows.Forms.CheckBox chkPerfBind;
        private System.Windows.Forms.TextBox txtCaseamt;
        private System.Windows.Forms.CheckBox chkCaseBind;
        private System.Windows.Forms.TextBox txtHardbackAmt;
        private System.Windows.Forms.CheckBox chkHardBack;
        private System.Windows.Forms.TextBox txtProfAmt;
        private System.Windows.Forms.CheckBox chkProfessional;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtNoPages;
        private System.Windows.Forms.TextBox txtYir;
        private System.Windows.Forms.CheckBox chkYir;
        private System.Windows.Forms.TextBox txtConvAmt;
        private System.Windows.Forms.CheckBox chkConv;
        private System.Windows.Forms.TextBox booktypeTextBox;
        private System.Windows.Forms.TextBox txtNocopies;
        private System.Windows.Forms.DateTimePicker dteQuote;
        private System.Windows.Forms.TextBox txtPoNum;
        private System.Windows.Forms.TextBox txtBYear;
        private System.Windows.Forms.TextBox txtBookTotal;
        private System.Windows.Forms.TextBox book_eaTextBox;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label lblPCEach;
        private System.Windows.Forms.Label lblPCTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox prcorTextBox;
        private System.Windows.Forms.ComboBox inkclrComboBox;
        private System.Windows.Forms.CheckBox chkMLaminate;
        private System.Windows.Forms.TextBox txtLaminate;
        private System.Windows.Forms.TextBox txtLaminateAmt;
        private System.Windows.Forms.CheckBox chkGlossLam;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAllClrAmt;
        private System.Windows.Forms.CheckBox chkAllClr;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
    }
