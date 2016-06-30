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
            System.Windows.Forms.Label speccvrLabel;
            System.Windows.Forms.Label speceaLabel;
            System.Windows.Forms.Label foiladamtLabel;
            System.Windows.Forms.Label yrdiscountamtLabel;
            System.Windows.Forms.Label extrchgLabel;
            System.Windows.Forms.Label invnoLabel;
            System.Windows.Forms.Label dp1Label;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label sbtotLabel;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label dp3descLabel;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label msstanqtyLabel;
            System.Windows.Forms.Label persamountLabel;
            System.Windows.Forms.Label perstotalLabel;
            System.Windows.Forms.Label perscopiesLabel;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label fbkprcLabel;
            System.Windows.Forms.Label ftotprcLabel;
            System.Windows.Forms.Label cred_etcLabel;
            System.Windows.Forms.Label adjbefLabel;
            System.Windows.Forms.Label cred_etcLabel1;
            System.Windows.Forms.Label desc22Label;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label saletaxLabel;
            System.Windows.Forms.Label freebooksLabel;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label18;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabSales = new System.Windows.Forms.TabControl();
            this.pg1 = new System.Windows.Forms.TabPage();
            this.lblPriceEach = new System.Windows.Forms.Label();
            this.quotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSales = new Mbc5.DataSets.dsSales();
            this.button1 = new System.Windows.Forms.Button();
            this.lblBookTotal = new System.Windows.Forms.Label();
            this.lbladjbef = new System.Windows.Forms.Label();
            this.bnSales = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnCreateWIP = new System.Windows.Forms.Button();
            this.btnPrntInvoice = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnNoPayPo = new System.Windows.Forms.Button();
            this.btnPaymentNotRec = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtPOAmt = new System.Windows.Forms.TextBox();
            this.txtPayments = new System.Windows.Forms.TextBox();
            this.txtInvoSrch = new System.Windows.Forms.TextBox();
            this.txtPoSrch = new System.Windows.Forms.TextBox();
            this.btnInvSrch = new System.Windows.Forms.Button();
            this.btnPoSrch = new System.Windows.Forms.Button();
            this.invHstDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invHstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.freebooksTextBox = new System.Windows.Forms.TextBox();
            this.saletaxTextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtOtherChrg = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtOtherChrg2 = new System.Windows.Forms.TextBox();
            this.desc22TextBox = new System.Windows.Forms.TextBox();
            this.txtCredits2 = new System.Windows.Forms.TextBox();
            this.cred_etcTextBox = new System.Windows.Forms.TextBox();
            this.cred_etcTextBox1 = new System.Windows.Forms.TextBox();
            this.txtCredits = new System.Windows.Forms.TextBox();
            this.pnlTot = new System.Windows.Forms.Panel();
            this.lblFinalTotPrc = new System.Windows.Forms.Label();
            this.lblperstotal = new System.Windows.Forms.Label();
            this.lblDisc3 = new System.Windows.Forms.Label();
            this.lblMsTot = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbldisc2 = new System.Windows.Forms.Label();
            this.lbldisc1 = new System.Windows.Forms.Label();
            this.lblsubtot = new System.Windows.Forms.Label();
            this.txtDisc = new System.Windows.Forms.TextBox();
            this.txtFinalbookprc = new System.Windows.Forms.TextBox();
            this.dp1descComboBox = new System.Windows.Forms.ComboBox();
            this.txtNumtoPers = new System.Windows.Forms.TextBox();
            this.perscopiesTextBox = new System.Windows.Forms.TextBox();
            this.chkDc2 = new System.Windows.Forms.CheckBox();
            this.txtDp2 = new System.Windows.Forms.TextBox();
            this.persamountTextBox = new System.Windows.Forms.TextBox();
            this.txtDp3Desc = new System.Windows.Forms.TextBox();
            this.dp3ComboBox = new System.Windows.Forms.ComboBox();
            this.chkMsStandard = new System.Windows.Forms.CheckBox();
            this.txtMsQty = new System.Windows.Forms.TextBox();
            this.foilamtTextBox = new System.Windows.Forms.TextBox();
            this.pnlMiscDiscCred = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClrDesc = new System.Windows.Forms.TextBox();
            this.txtClrTot = new System.Windows.Forms.TextBox();
            this.txtMisc = new System.Windows.Forms.TextBox();
            this.txtMdesc = new System.Windows.Forms.TextBox();
            this.txtDesc1amt = new System.Windows.Forms.TextBox();
            this.txtDesc1 = new System.Windows.Forms.TextBox();
            this.txtDesc3tot = new System.Windows.Forms.TextBox();
            this.txtDesc3 = new System.Windows.Forms.TextBox();
            this.txtDesc4tot = new System.Windows.Forms.TextBox();
            this.txtDesc4 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSpeccvr = new System.Windows.Forms.Label();
            this.chkAllClr = new System.Windows.Forms.CheckBox();
            this.lblMLaminateAmt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLaminateAmt = new System.Windows.Forms.Label();
            this.txtnoClrPgs = new System.Windows.Forms.TextBox();
            this.chkGlossLam = new System.Windows.Forms.CheckBox();
            this.chkMLaminate = new System.Windows.Forms.CheckBox();
            this.inkclrComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClrNumber = new System.Windows.Forms.TextBox();
            this.txtCoverDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSpecCvrEa = new System.Windows.Forms.TextBox();
            this.txtFoilAd = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStoryAmt = new System.Windows.Forms.Label();
            this.lblYir = new System.Windows.Forms.Label();
            this.lblConvAmt = new System.Windows.Forms.Label();
            this.lblProfAmt = new System.Windows.Forms.Label();
            this.chkProfessional = new System.Windows.Forms.CheckBox();
            this.chkConv = new System.Windows.Forms.CheckBox();
            this.chkYir = new System.Windows.Forms.CheckBox();
            this.chkStory = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSaddleAmt = new System.Windows.Forms.Label();
            this.lblSpiralAmt = new System.Windows.Forms.Label();
            this.lblPerfbindAmt = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkPerfBind = new System.Windows.Forms.CheckBox();
            this.chkSpiral = new System.Windows.Forms.CheckBox();
            this.chkSaddlStitch = new System.Windows.Forms.CheckBox();
            this.pnlHard = new System.Windows.Forms.Panel();
            this.lblCaseamt = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkHardBack = new System.Windows.Forms.CheckBox();
            this.chkCaseBind = new System.Windows.Forms.CheckBox();
            this.lblHardbackAmt = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.txtExtChrg = new System.Windows.Forms.TextBox();
            this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbYrDiscountAmt = new System.Windows.Forms.ComboBox();
            this.chkPromo = new System.Windows.Forms.CheckBox();
            this.lblPCEach = new System.Windows.Forms.Label();
            this.lblPCTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPriceOverRide = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.booktypeTextBox = new System.Windows.Forms.TextBox();
            this.txtNocopies = new System.Windows.Forms.TextBox();
            this.dteQuote = new System.Windows.Forms.DateTimePicker();
            this.txtPoNum = new System.Windows.Forms.TextBox();
            this.txtBYear = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtNoPages = new System.Windows.Forms.TextBox();
            this.pg2 = new System.Windows.Forms.TabPage();
            this.quotesTableAdapter = new Mbc5.DataSets.dsSalesTableAdapters.quotesTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager();
            this.custTableAdapter = new Mbc5.DataSets.dsSalesTableAdapters.custTableAdapter();
            this.invHstTableAdapter = new Mbc5.DataSets.dsSalesTableAdapters.InvHstTableAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
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
            speccvrLabel = new System.Windows.Forms.Label();
            speceaLabel = new System.Windows.Forms.Label();
            foiladamtLabel = new System.Windows.Forms.Label();
            yrdiscountamtLabel = new System.Windows.Forms.Label();
            extrchgLabel = new System.Windows.Forms.Label();
            invnoLabel = new System.Windows.Forms.Label();
            dp1Label = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            sbtotLabel = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            dp3descLabel = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            msstanqtyLabel = new System.Windows.Forms.Label();
            persamountLabel = new System.Windows.Forms.Label();
            perstotalLabel = new System.Windows.Forms.Label();
            perscopiesLabel = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            fbkprcLabel = new System.Windows.Forms.Label();
            ftotprcLabel = new System.Windows.Forms.Label();
            cred_etcLabel = new System.Windows.Forms.Label();
            adjbefLabel = new System.Windows.Forms.Label();
            cred_etcLabel1 = new System.Windows.Forms.Label();
            desc22Label = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            saletaxLabel = new System.Windows.Forms.Label();
            freebooksLabel = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            this.tabSales.SuspendLayout();
            this.pg1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnSales)).BeginInit();
            this.bnSales.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invHstDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invHstBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.pnlTot.SuspendLayout();
            this.pnlMiscDiscCred.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlHard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // nopagesLabel
            // 
            nopagesLabel.AutoSize = true;
            nopagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nopagesLabel.Location = new System.Drawing.Point(143, 37);
            nopagesLabel.Name = "nopagesLabel";
            nopagesLabel.Size = new System.Drawing.Size(30, 13);
            nopagesLabel.TabIndex = 15;
            nopagesLabel.Text = "#Pg";
            // 
            // contryearLabel
            // 
            contryearLabel.AutoSize = true;
            contryearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contryearLabel.Location = new System.Drawing.Point(136, 8);
            contryearLabel.Name = "contryearLabel";
            contryearLabel.Size = new System.Drawing.Size(37, 13);
            contryearLabel.TabIndex = 1;
            contryearLabel.Text = "Year:";
            // 
            // bpyearLabel
            // 
            bpyearLabel.AutoSize = true;
            bpyearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            bpyearLabel.Location = new System.Drawing.Point(219, 8);
            bpyearLabel.Name = "bpyearLabel";
            bpyearLabel.Size = new System.Drawing.Size(102, 13);
            bpyearLabel.TabIndex = 3;
            bpyearLabel.Text = "Base Price Year:";
            // 
            // ponumLabel
            // 
            ponumLabel.AutoSize = true;
            ponumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ponumLabel.Location = new System.Drawing.Point(371, 8);
            ponumLabel.Name = "ponumLabel";
            ponumLabel.Size = new System.Drawing.Size(36, 13);
            ponumLabel.TabIndex = 5;
            ponumLabel.Text = "PO#:";
            // 
            // qtedateLabel
            // 
            qtedateLabel.AutoSize = true;
            qtedateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qtedateLabel.Location = new System.Drawing.Point(530, 8);
            qtedateLabel.Name = "qtedateLabel";
            qtedateLabel.Size = new System.Drawing.Size(76, 13);
            qtedateLabel.TabIndex = 24;
            qtedateLabel.Text = "Quote Date:";
            // 
            // nocopiesLabel
            // 
            nocopiesLabel.AutoSize = true;
            nocopiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nocopiesLabel.Location = new System.Drawing.Point(23, 37);
            nocopiesLabel.Name = "nocopiesLabel";
            nocopiesLabel.Size = new System.Drawing.Size(57, 13);
            nocopiesLabel.TabIndex = 13;
            nocopiesLabel.Text = "#Copies:";
            // 
            // booktypeLabel
            // 
            booktypeLabel.AutoSize = true;
            booktypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            booktypeLabel.Location = new System.Drawing.Point(14, 8);
            booktypeLabel.Name = "booktypeLabel";
            booktypeLabel.Size = new System.Drawing.Size(72, 13);
            booktypeLabel.TabIndex = 28;
            booktypeLabel.Text = "Book Type:";
            // 
            // sourceLabel
            // 
            sourceLabel.AutoSize = true;
            sourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sourceLabel.Location = new System.Drawing.Point(829, 8);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new System.Drawing.Size(51, 13);
            sourceLabel.TabIndex = 9;
            sourceLabel.Text = "Source:";
            // 
            // book_eaLabel
            // 
            book_eaLabel.AutoSize = true;
            book_eaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            book_eaLabel.Location = new System.Drawing.Point(240, 37);
            book_eaLabel.Name = "book_eaLabel";
            book_eaLabel.Size = new System.Drawing.Size(73, 13);
            book_eaLabel.TabIndex = 17;
            book_eaLabel.Text = "Price Each:";
            // 
            // book_priceLabel
            // 
            book_priceLabel.AutoSize = true;
            book_priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            book_priceLabel.Location = new System.Drawing.Point(588, 37);
            book_priceLabel.Name = "book_priceLabel";
            book_priceLabel.Size = new System.Drawing.Size(77, 13);
            book_priceLabel.TabIndex = 21;
            book_priceLabel.Text = "Book (total):";
            // 
            // prcorLabel
            // 
            prcorLabel.AutoSize = true;
            prcorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            prcorLabel.Location = new System.Drawing.Point(392, 37);
            prcorLabel.Name = "prcorLabel";
            prcorLabel.Size = new System.Drawing.Size(101, 13);
            prcorLabel.TabIndex = 19;
            prcorLabel.Text = "Price Over Ride:";
            // 
            // inkclrLabel
            // 
            inkclrLabel.AutoSize = true;
            inkclrLabel.Location = new System.Drawing.Point(35, 107);
            inkclrLabel.Name = "inkclrLabel";
            inkclrLabel.Size = new System.Drawing.Size(80, 13);
            inkclrLabel.TabIndex = 50;
            inkclrLabel.Text = "# Ink Colors:";
            // 
            // speccvrLabel
            // 
            speccvrLabel.AutoSize = true;
            speccvrLabel.Location = new System.Drawing.Point(17, 198);
            speccvrLabel.Name = "speccvrLabel";
            speccvrLabel.Size = new System.Drawing.Size(98, 13);
            speccvrLabel.TabIndex = 56;
            speccvrLabel.Text = "Spec. Cvr. Tot.:";
            // 
            // speceaLabel
            // 
            speceaLabel.AutoSize = true;
            speceaLabel.Location = new System.Drawing.Point(17, 176);
            speceaLabel.Name = "speceaLabel";
            speceaLabel.Size = new System.Drawing.Size(98, 13);
            speceaLabel.TabIndex = 58;
            speceaLabel.Text = "Spec. Cvr. Ea. :";
            // 
            // foiladamtLabel
            // 
            foiladamtLabel.AutoSize = true;
            foiladamtLabel.Location = new System.Drawing.Point(16, 220);
            foiladamtLabel.Name = "foiladamtLabel";
            foiladamtLabel.Size = new System.Drawing.Size(99, 13);
            foiladamtLabel.TabIndex = 60;
            foiladamtLabel.Text = "Foil (Additional):";
            // 
            // yrdiscountamtLabel
            // 
            yrdiscountamtLabel.AutoSize = true;
            yrdiscountamtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            yrdiscountamtLabel.Location = new System.Drawing.Point(791, 37);
            yrdiscountamtLabel.Name = "yrdiscountamtLabel";
            yrdiscountamtLabel.Size = new System.Drawing.Size(16, 13);
            yrdiscountamtLabel.TabIndex = 24;
            yrdiscountamtLabel.Text = "%";
            // 
            // extrchgLabel
            // 
            extrchgLabel.AutoSize = true;
            extrchgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            extrchgLabel.Location = new System.Drawing.Point(482, 269);
            extrchgLabel.Name = "extrchgLabel";
            extrchgLabel.Size = new System.Drawing.Size(90, 13);
            extrchgLabel.TabIndex = 87;
            extrchgLabel.Text = "Extra Charges:";
            // 
            // invnoLabel
            // 
            invnoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            invnoLabel.AutoSize = true;
            invnoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            invnoLabel.Location = new System.Drawing.Point(998, 8);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(90, 16);
            invnoLabel.TabIndex = 11;
            invnoLabel.Text = "Invoice No.:";
            // 
            // dp1Label
            // 
            dp1Label.AutoSize = true;
            dp1Label.Location = new System.Drawing.Point(69, 38);
            dp1Label.Name = "dp1Label";
            dp1Label.Size = new System.Drawing.Size(61, 13);
            dp1Label.TabIndex = 99;
            dp1Label.Text = "Discount:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(368, 38);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(16, 13);
            label11.TabIndex = 101;
            label11.Text = "%";
            // 
            // sbtotLabel
            // 
            sbtotLabel.AutoSize = true;
            sbtotLabel.Location = new System.Drawing.Point(385, 15);
            sbtotLabel.Name = "sbtotLabel";
            sbtotLabel.Size = new System.Drawing.Size(62, 13);
            sbtotLabel.TabIndex = 103;
            sbtotLabel.Text = "SubTotal:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(368, 61);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(16, 13);
            label12.TabIndex = 107;
            label12.Text = "%";
            // 
            // dp3descLabel
            // 
            dp3descLabel.AutoSize = true;
            dp3descLabel.Location = new System.Drawing.Point(69, 84);
            dp3descLabel.Name = "dp3descLabel";
            dp3descLabel.Size = new System.Drawing.Size(71, 13);
            dp3descLabel.TabIndex = 108;
            dp3descLabel.Text = "Other Disc:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(368, 84);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(16, 13);
            label13.TabIndex = 111;
            label13.Text = "%";
            // 
            // msstanqtyLabel
            // 
            msstanqtyLabel.AutoSize = true;
            msstanqtyLabel.Location = new System.Drawing.Point(352, 108);
            msstanqtyLabel.Name = "msstanqtyLabel";
            msstanqtyLabel.Size = new System.Drawing.Size(30, 13);
            msstanqtyLabel.TabIndex = 113;
            msstanqtyLabel.Text = "Qty:";
            // 
            // persamountLabel
            // 
            persamountLabel.AutoSize = true;
            persamountLabel.Location = new System.Drawing.Point(225, 129);
            persamountLabel.Name = "persamountLabel";
            persamountLabel.Size = new System.Drawing.Size(26, 13);
            persamountLabel.TabIndex = 117;
            persamountLabel.Text = "@$";
            // 
            // perstotalLabel
            // 
            perstotalLabel.AutoSize = true;
            perstotalLabel.Location = new System.Drawing.Point(404, 129);
            perstotalLabel.Name = "perstotalLabel";
            perstotalLabel.Size = new System.Drawing.Size(40, 13);
            perstotalLabel.TabIndex = 118;
            perstotalLabel.Text = "Total:";
            // 
            // perscopiesLabel
            // 
            perscopiesLabel.AutoSize = true;
            perscopiesLabel.Location = new System.Drawing.Point(63, 129);
            perscopiesLabel.Name = "perscopiesLabel";
            perscopiesLabel.Size = new System.Drawing.Size(105, 13);
            perscopiesLabel.TabIndex = 119;
            perscopiesLabel.Text = "Personalization #";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(158, 155);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(94, 13);
            label15.TabIndex = 121;
            label15.Text = "#to persoanlize";
            // 
            // fbkprcLabel
            // 
            fbkprcLabel.AutoSize = true;
            fbkprcLabel.Location = new System.Drawing.Point(51, 179);
            fbkprcLabel.Name = "fbkprcLabel";
            fbkprcLabel.Size = new System.Drawing.Size(104, 13);
            fbkprcLabel.TabIndex = 122;
            fbkprcLabel.Text = "Final Book Price:";
            // 
            // ftotprcLabel
            // 
            ftotprcLabel.AutoSize = true;
            ftotprcLabel.Location = new System.Drawing.Point(338, 182);
            ftotprcLabel.Name = "ftotprcLabel";
            ftotprcLabel.Size = new System.Drawing.Size(104, 13);
            ftotprcLabel.TabIndex = 123;
            ftotprcLabel.Text = "Final Book Total:";
            // 
            // cred_etcLabel
            // 
            cred_etcLabel.AutoSize = true;
            cred_etcLabel.Location = new System.Drawing.Point(33, 10);
            cred_etcLabel.Name = "cred_etcLabel";
            cred_etcLabel.Size = new System.Drawing.Size(50, 13);
            cred_etcLabel.TabIndex = 125;
            cred_etcLabel.Text = "Credits:";
            // 
            // adjbefLabel
            // 
            adjbefLabel.AutoSize = true;
            adjbefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            adjbefLabel.Location = new System.Drawing.Point(663, 491);
            adjbefLabel.Name = "adjbefLabel";
            adjbefLabel.Size = new System.Drawing.Size(137, 13);
            adjbefLabel.TabIndex = 127;
            adjbefLabel.Text = "Total (Including Credit)";
            // 
            // cred_etcLabel1
            // 
            cred_etcLabel1.AutoSize = true;
            cred_etcLabel1.Location = new System.Drawing.Point(26, 33);
            cred_etcLabel1.Name = "cred_etcLabel1";
            cred_etcLabel1.Size = new System.Drawing.Size(57, 13);
            cred_etcLabel1.TabIndex = 128;
            cred_etcLabel1.Text = "Credits2:";
            // 
            // desc22Label
            // 
            desc22Label.AutoSize = true;
            desc22Label.Location = new System.Drawing.Point(4, 78);
            desc22Label.Name = "desc22Label";
            desc22Label.Size = new System.Drawing.Size(79, 13);
            desc22Label.TabIndex = 130;
            desc22Label.Text = "Other Chg2.:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(11, 56);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(72, 13);
            label17.TabIndex = 133;
            label17.Text = "Other Chg.:";
            // 
            // saletaxLabel
            // 
            saletaxLabel.AutoSize = true;
            saletaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            saletaxLabel.Location = new System.Drawing.Point(678, 516);
            saletaxLabel.Name = "saletaxLabel";
            saletaxLabel.Size = new System.Drawing.Size(125, 13);
            saletaxLabel.TabIndex = 137;
            saletaxLabel.Text = "Sales Tax Received:";
            // 
            // freebooksLabel
            // 
            freebooksLabel.AutoSize = true;
            freebooksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            freebooksLabel.Location = new System.Drawing.Point(316, 580);
            freebooksLabel.Name = "freebooksLabel";
            freebooksLabel.Size = new System.Drawing.Size(135, 13);
            freebooksLabel.TabIndex = 138;
            freebooksLabel.Text = "Free Additional Books:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label16.Location = new System.Drawing.Point(655, 544);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(65, 13);
            label16.TabIndex = 144;
            label16.Text = "Payments:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label18.Location = new System.Drawing.Point(646, 567);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(74, 13);
            label18.TabIndex = 146;
            label18.Text = "PO Amount:";
            // 
            // tabSales
            // 
            this.tabSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSales.Controls.Add(this.pg1);
            this.tabSales.Controls.Add(this.pg2);
            this.tabSales.Location = new System.Drawing.Point(0, 0);
            this.tabSales.Name = "tabSales";
            this.tabSales.SelectedIndex = 0;
            this.tabSales.Size = new System.Drawing.Size(1233, 731);
            this.tabSales.TabIndex = 0;
            // 
            // pg1
            // 
            this.pg1.AutoScroll = true;
            this.pg1.BackColor = System.Drawing.SystemColors.Control;
            this.pg1.Controls.Add(this.lblPriceEach);
            this.pg1.Controls.Add(this.button1);
            this.pg1.Controls.Add(this.lblBookTotal);
            this.pg1.Controls.Add(this.lbladjbef);
            this.pg1.Controls.Add(this.bnSales);
            this.pg1.Controls.Add(this.panel6);
            this.pg1.Controls.Add(this.panel5);
            this.pg1.Controls.Add(label18);
            this.pg1.Controls.Add(this.txtPOAmt);
            this.pg1.Controls.Add(label16);
            this.pg1.Controls.Add(this.txtPayments);
            this.pg1.Controls.Add(this.txtInvoSrch);
            this.pg1.Controls.Add(this.txtPoSrch);
            this.pg1.Controls.Add(this.btnInvSrch);
            this.pg1.Controls.Add(this.btnPoSrch);
            this.pg1.Controls.Add(this.invHstDataGridView);
            this.pg1.Controls.Add(freebooksLabel);
            this.pg1.Controls.Add(this.freebooksTextBox);
            this.pg1.Controls.Add(saletaxLabel);
            this.pg1.Controls.Add(this.saletaxTextBox);
            this.pg1.Controls.Add(this.panel4);
            this.pg1.Controls.Add(adjbefLabel);
            this.pg1.Controls.Add(this.pnlTot);
            this.pg1.Controls.Add(this.pnlMiscDiscCred);
            this.pg1.Controls.Add(this.panel3);
            this.pg1.Controls.Add(this.panel2);
            this.pg1.Controls.Add(this.panel1);
            this.pg1.Controls.Add(this.pnlHard);
            this.pg1.Controls.Add(this.textBox3);
            this.pg1.Controls.Add(this.label7);
            this.pg1.Controls.Add(this.lblInvoice);
            this.pg1.Controls.Add(invnoLabel);
            this.pg1.Controls.Add(extrchgLabel);
            this.pg1.Controls.Add(this.txtExtChrg);
            this.pg1.Controls.Add(yrdiscountamtLabel);
            this.pg1.Controls.Add(this.cmbYrDiscountAmt);
            this.pg1.Controls.Add(this.chkPromo);
            this.pg1.Controls.Add(this.lblPCEach);
            this.pg1.Controls.Add(this.lblPCTotal);
            this.pg1.Controls.Add(this.label2);
            this.pg1.Controls.Add(this.label1);
            this.pg1.Controls.Add(prcorLabel);
            this.pg1.Controls.Add(this.txtPriceOverRide);
            this.pg1.Controls.Add(book_priceLabel);
            this.pg1.Controls.Add(book_eaLabel);
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
            this.pg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pg1.Location = new System.Drawing.Point(4, 22);
            this.pg1.Name = "pg1";
            this.pg1.Padding = new System.Windows.Forms.Padding(3);
            this.pg1.Size = new System.Drawing.Size(1225, 705);
            this.pg1.TabIndex = 0;
            this.pg1.Text = "Sales";
            // 
            // lblPriceEach
            // 
            this.lblPriceEach.AutoSize = true;
            this.lblPriceEach.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "book_ea", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.lblPriceEach.Location = new System.Drawing.Point(310, 37);
            this.lblPriceEach.Name = "lblPriceEach";
            this.lblPriceEach.Size = new System.Drawing.Size(41, 13);
            this.lblPriceEach.TabIndex = 18;
            this.lblPriceEach.Text = "label10";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(940, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 171;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblBookTotal
            // 
            this.lblBookTotal.AutoSize = true;
            this.lblBookTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "book_price", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.lblBookTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookTotal.Location = new System.Drawing.Point(661, 37);
            this.lblBookTotal.Name = "lblBookTotal";
            this.lblBookTotal.Size = new System.Drawing.Size(41, 13);
            this.lblBookTotal.TabIndex = 22;
            this.lblBookTotal.Text = "label21";
            // 
            // lbladjbef
            // 
            this.lbladjbef.AutoSize = true;
            this.lbladjbef.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "adjbef", true));
            this.lbladjbef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladjbef.Location = new System.Drawing.Point(806, 491);
            this.lbladjbef.Name = "lbladjbef";
            this.lbladjbef.Size = new System.Drawing.Size(41, 13);
            this.lbladjbef.TabIndex = 169;
            this.lbladjbef.Text = "label21";
            // 
            // bnSales
            // 
            this.bnSales.AddNewItem = null;
            this.bnSales.BindingSource = this.quotesBindingSource;
            this.bnSales.CountItem = this.bindingNavigatorCountItem;
            this.bnSales.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnSales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnSales.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bnSales.Location = new System.Drawing.Point(3, 677);
            this.bnSales.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnSales.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnSales.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnSales.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnSales.Name = "bnSales";
            this.bnSales.PositionItem = this.bindingNavigatorPositionItem;
            this.bnSales.Size = new System.Drawing.Size(1219, 25);
            this.bnSales.TabIndex = 156;
            this.bnSales.Text = "SaleNav";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnInvoice);
            this.panel6.Controls.Add(this.btnCreateWIP);
            this.panel6.Controls.Add(this.btnPrntInvoice);
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(903, 488);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(274, 96);
            this.panel6.TabIndex = 155;
            // 
            // btnInvoice
            // 
            this.btnInvoice.Location = new System.Drawing.Point(3, 6);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(156, 39);
            this.btnInvoice.TabIndex = 148;
            this.btnInvoice.Text = "Create/OverRide Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            // 
            // btnCreateWIP
            // 
            this.btnCreateWIP.Location = new System.Drawing.Point(105, 51);
            this.btnCreateWIP.Name = "btnCreateWIP";
            this.btnCreateWIP.Size = new System.Drawing.Size(101, 36);
            this.btnCreateWIP.TabIndex = 149;
            this.btnCreateWIP.Text = "Create/Update WIP";
            this.btnCreateWIP.UseVisualStyleBackColor = true;
            // 
            // btnPrntInvoice
            // 
            this.btnPrntInvoice.Location = new System.Drawing.Point(165, 6);
            this.btnPrntInvoice.Name = "btnPrntInvoice";
            this.btnPrntInvoice.Size = new System.Drawing.Size(101, 23);
            this.btnPrntInvoice.TabIndex = 150;
            this.btnPrntInvoice.Text = "Print Invoice";
            this.btnPrntInvoice.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnNoPayPo);
            this.panel5.Controls.Add(this.btnPaymentNotRec);
            this.panel5.Controls.Add(this.btnRemove);
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(856, 209);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(321, 85);
            this.panel5.TabIndex = 154;
            // 
            // btnNoPayPo
            // 
            this.btnNoPayPo.Location = new System.Drawing.Point(16, 16);
            this.btnNoPayPo.Name = "btnNoPayPo";
            this.btnNoPayPo.Size = new System.Drawing.Size(143, 23);
            this.btnNoPayPo.TabIndex = 151;
            this.btnNoPayPo.Text = "No Payment PO/Half";
            this.btnNoPayPo.UseVisualStyleBackColor = true;
            // 
            // btnPaymentNotRec
            // 
            this.btnPaymentNotRec.Location = new System.Drawing.Point(165, 16);
            this.btnPaymentNotRec.Name = "btnPaymentNotRec";
            this.btnPaymentNotRec.Size = new System.Drawing.Size(137, 23);
            this.btnPaymentNotRec.TabIndex = 152;
            this.btnPaymentNotRec.Text = "Payment Not Rec 5%";
            this.btnPaymentNotRec.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(96, 45);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(137, 23);
            this.btnRemove.TabIndex = 153;
            this.btnRemove.Text = "Removing 5%";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // txtPOAmt
            // 
            this.txtPOAmt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPOAmt.BackColor = System.Drawing.Color.Aqua;
            this.txtPOAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPOAmt.Location = new System.Drawing.Point(727, 564);
            this.txtPOAmt.Name = "txtPOAmt";
            this.txtPOAmt.ReadOnly = true;
            this.txtPOAmt.Size = new System.Drawing.Size(43, 20);
            this.txtPOAmt.TabIndex = 147;
            // 
            // txtPayments
            // 
            this.txtPayments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPayments.BackColor = System.Drawing.Color.Aqua;
            this.txtPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayments.Location = new System.Drawing.Point(727, 541);
            this.txtPayments.Name = "txtPayments";
            this.txtPayments.ReadOnly = true;
            this.txtPayments.Size = new System.Drawing.Size(43, 20);
            this.txtPayments.TabIndex = 145;
            // 
            // txtInvoSrch
            // 
            this.txtInvoSrch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoSrch.Location = new System.Drawing.Point(1061, 36);
            this.txtInvoSrch.MaxLength = 5;
            this.txtInvoSrch.Name = "txtInvoSrch";
            this.txtInvoSrch.Size = new System.Drawing.Size(106, 20);
            this.txtInvoSrch.TabIndex = 27;
            // 
            // txtPoSrch
            // 
            this.txtPoSrch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPoSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoSrch.Location = new System.Drawing.Point(1061, 59);
            this.txtPoSrch.Name = "txtPoSrch";
            this.txtPoSrch.Size = new System.Drawing.Size(106, 20);
            this.txtPoSrch.TabIndex = 29;
            // 
            // btnInvSrch
            // 
            this.btnInvSrch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvSrch.AutoSize = true;
            this.btnInvSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvSrch.Location = new System.Drawing.Point(945, 36);
            this.btnInvSrch.Name = "btnInvSrch";
            this.btnInvSrch.Size = new System.Drawing.Size(111, 23);
            this.btnInvSrch.TabIndex = 26;
            this.btnInvSrch.Text = "Invoice# Search";
            this.btnInvSrch.UseVisualStyleBackColor = true;
            this.btnInvSrch.Click += new System.EventHandler(this.btnInvSrch_Click);
            // 
            // btnPoSrch
            // 
            this.btnPoSrch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPoSrch.AutoSize = true;
            this.btnPoSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoSrch.Location = new System.Drawing.Point(970, 59);
            this.btnPoSrch.Name = "btnPoSrch";
            this.btnPoSrch.Size = new System.Drawing.Size(86, 23);
            this.btnPoSrch.TabIndex = 28;
            this.btnPoSrch.Text = "PO# Search";
            this.btnPoSrch.UseVisualStyleBackColor = true;
            // 
            // invHstDataGridView
            // 
            this.invHstDataGridView.AllowUserToDeleteRows = false;
            this.invHstDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invHstDataGridView.AutoGenerateColumns = false;
            this.invHstDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.invHstDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.invHstDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.invHstDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3});
            this.invHstDataGridView.DataSource = this.invHstBindingSource;
            this.invHstDataGridView.EnableHeadersVisualStyles = false;
            this.invHstDataGridView.Location = new System.Drawing.Point(856, 90);
            this.invHstDataGridView.Name = "invHstDataGridView";
            this.invHstDataGridView.ReadOnly = true;
            this.invHstDataGridView.Size = new System.Drawing.Size(321, 113);
            this.invHstDataGridView.TabIndex = 139;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "contryear";
            this.dataGridViewTextBoxColumn4.HeaderText = "Year";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 54;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "qtedate";
            this.dataGridViewTextBoxColumn2.HeaderText = "Sales Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 84;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "invno";
            this.dataGridViewTextBoxColumn1.HeaderText = "Invoice#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 74;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "baldue";
            this.dataGridViewTextBoxColumn3.HeaderText = "Balance Due";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 94;
            // 
            // invHstBindingSource
            // 
            this.invHstBindingSource.DataMember = "InvHst";
            this.invHstBindingSource.DataSource = this.dsSales;
            // 
            // freebooksTextBox
            // 
            this.freebooksTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "freebooks", true));
            this.freebooksTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freebooksTextBox.Location = new System.Drawing.Point(457, 580);
            this.freebooksTextBox.Name = "freebooksTextBox";
            this.freebooksTextBox.Size = new System.Drawing.Size(71, 20);
            this.freebooksTextBox.TabIndex = 139;
            // 
            // saletaxTextBox
            // 
            this.saletaxTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saletaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "saletax", true));
            this.saletaxTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saletaxTextBox.Location = new System.Drawing.Point(806, 513);
            this.saletaxTextBox.Name = "saletaxTextBox";
            this.saletaxTextBox.Size = new System.Drawing.Size(43, 20);
            this.saletaxTextBox.TabIndex = 138;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtOtherChrg);
            this.panel4.Controls.Add(label17);
            this.panel4.Controls.Add(this.textBox5);
            this.panel4.Controls.Add(this.txtOtherChrg2);
            this.panel4.Controls.Add(desc22Label);
            this.panel4.Controls.Add(this.desc22TextBox);
            this.panel4.Controls.Add(this.txtCredits2);
            this.panel4.Controls.Add(this.cred_etcTextBox);
            this.panel4.Controls.Add(cred_etcLabel1);
            this.panel4.Controls.Add(cred_etcLabel);
            this.panel4.Controls.Add(this.cred_etcTextBox1);
            this.panel4.Controls.Add(this.txtCredits);
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(548, 364);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(319, 119);
            this.panel4.TabIndex = 137;
            // 
            // txtOtherChrg
            // 
            this.txtOtherChrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOtherChrg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "adjaftr2", true));
            this.txtOtherChrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherChrg.Location = new System.Drawing.Point(230, 56);
            this.txtOtherChrg.Name = "txtOtherChrg";
            this.txtOtherChrg.Size = new System.Drawing.Size(70, 20);
            this.txtOtherChrg.TabIndex = 136;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "cred_etc2", true));
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(88, 56);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(136, 20);
            this.textBox5.TabIndex = 135;
            // 
            // txtOtherChrg2
            // 
            this.txtOtherChrg2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOtherChrg2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "desc22tot", true));
            this.txtOtherChrg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherChrg2.Location = new System.Drawing.Point(230, 78);
            this.txtOtherChrg2.Name = "txtOtherChrg2";
            this.txtOtherChrg2.Size = new System.Drawing.Size(70, 20);
            this.txtOtherChrg2.TabIndex = 132;
            // 
            // desc22TextBox
            // 
            this.desc22TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.desc22TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "desc22", true));
            this.desc22TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc22TextBox.Location = new System.Drawing.Point(88, 78);
            this.desc22TextBox.Name = "desc22TextBox";
            this.desc22TextBox.Size = new System.Drawing.Size(136, 20);
            this.desc22TextBox.TabIndex = 131;
            // 
            // txtCredits2
            // 
            this.txtCredits2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredits2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "adjaftr2", true));
            this.txtCredits2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredits2.Location = new System.Drawing.Point(230, 33);
            this.txtCredits2.Name = "txtCredits2";
            this.txtCredits2.Size = new System.Drawing.Size(70, 20);
            this.txtCredits2.TabIndex = 130;
            // 
            // cred_etcTextBox
            // 
            this.cred_etcTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cred_etcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "cred_etc", true));
            this.cred_etcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cred_etcTextBox.Location = new System.Drawing.Point(88, 10);
            this.cred_etcTextBox.Name = "cred_etcTextBox";
            this.cred_etcTextBox.Size = new System.Drawing.Size(136, 20);
            this.cred_etcTextBox.TabIndex = 126;
            // 
            // cred_etcTextBox1
            // 
            this.cred_etcTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cred_etcTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "cred_etc2", true));
            this.cred_etcTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cred_etcTextBox1.Location = new System.Drawing.Point(88, 33);
            this.cred_etcTextBox1.Name = "cred_etcTextBox1";
            this.cred_etcTextBox1.Size = new System.Drawing.Size(136, 20);
            this.cred_etcTextBox1.TabIndex = 129;
            // 
            // txtCredits
            // 
            this.txtCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredits.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "adjaftr", true));
            this.txtCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredits.Location = new System.Drawing.Point(230, 10);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.Size = new System.Drawing.Size(70, 20);
            this.txtCredits.TabIndex = 127;
            // 
            // pnlTot
            // 
            this.pnlTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTot.Controls.Add(this.lblFinalTotPrc);
            this.pnlTot.Controls.Add(this.lblperstotal);
            this.pnlTot.Controls.Add(this.lblDisc3);
            this.pnlTot.Controls.Add(this.lblMsTot);
            this.pnlTot.Controls.Add(this.label14);
            this.pnlTot.Controls.Add(this.lbldisc2);
            this.pnlTot.Controls.Add(ftotprcLabel);
            this.pnlTot.Controls.Add(this.lbldisc1);
            this.pnlTot.Controls.Add(dp1Label);
            this.pnlTot.Controls.Add(this.lblsubtot);
            this.pnlTot.Controls.Add(this.txtDisc);
            this.pnlTot.Controls.Add(fbkprcLabel);
            this.pnlTot.Controls.Add(label11);
            this.pnlTot.Controls.Add(this.txtFinalbookprc);
            this.pnlTot.Controls.Add(this.dp1descComboBox);
            this.pnlTot.Controls.Add(label15);
            this.pnlTot.Controls.Add(this.txtNumtoPers);
            this.pnlTot.Controls.Add(perscopiesLabel);
            this.pnlTot.Controls.Add(sbtotLabel);
            this.pnlTot.Controls.Add(this.perscopiesTextBox);
            this.pnlTot.Controls.Add(this.chkDc2);
            this.pnlTot.Controls.Add(perstotalLabel);
            this.pnlTot.Controls.Add(this.txtDp2);
            this.pnlTot.Controls.Add(label12);
            this.pnlTot.Controls.Add(persamountLabel);
            this.pnlTot.Controls.Add(this.persamountTextBox);
            this.pnlTot.Controls.Add(this.txtDp3Desc);
            this.pnlTot.Controls.Add(dp3descLabel);
            this.pnlTot.Controls.Add(this.dp3ComboBox);
            this.pnlTot.Controls.Add(label13);
            this.pnlTot.Controls.Add(msstanqtyLabel);
            this.pnlTot.Controls.Add(this.chkMsStandard);
            this.pnlTot.Controls.Add(this.txtMsQty);
            this.pnlTot.Controls.Add(this.foilamtTextBox);
            this.pnlTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTot.Location = new System.Drawing.Point(6, 364);
            this.pnlTot.Name = "pnlTot";
            this.pnlTot.Size = new System.Drawing.Size(520, 210);
            this.pnlTot.TabIndex = 125;
            // 
            // lblFinalTotPrc
            // 
            this.lblFinalTotPrc.AutoSize = true;
            this.lblFinalTotPrc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "ftotprc", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.lblFinalTotPrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalTotPrc.Location = new System.Drawing.Point(449, 182);
            this.lblFinalTotPrc.Name = "lblFinalTotPrc";
            this.lblFinalTotPrc.Size = new System.Drawing.Size(41, 13);
            this.lblFinalTotPrc.TabIndex = 169;
            this.lblFinalTotPrc.Text = "label21";
            // 
            // lblperstotal
            // 
            this.lblperstotal.AutoSize = true;
            this.lblperstotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "perstotal", true));
            this.lblperstotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblperstotal.Location = new System.Drawing.Point(449, 129);
            this.lblperstotal.Name = "lblperstotal";
            this.lblperstotal.Size = new System.Drawing.Size(41, 13);
            this.lblperstotal.TabIndex = 168;
            this.lblperstotal.Text = "label21";
            // 
            // lblDisc3
            // 
            this.lblDisc3.AutoSize = true;
            this.lblDisc3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "disc3", true));
            this.lblDisc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisc3.Location = new System.Drawing.Point(449, 87);
            this.lblDisc3.Name = "lblDisc3";
            this.lblDisc3.Size = new System.Drawing.Size(41, 13);
            this.lblDisc3.TabIndex = 167;
            this.lblDisc3.Text = "label21";
            // 
            // lblMsTot
            // 
            this.lblMsTot.AutoSize = true;
            this.lblMsTot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "msstandtot", true));
            this.lblMsTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsTot.Location = new System.Drawing.Point(449, 110);
            this.lblMsTot.Name = "lblMsTot";
            this.lblMsTot.Size = new System.Drawing.Size(41, 13);
            this.lblMsTot.TabIndex = 167;
            this.lblMsTot.Text = "label21";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(32, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(347, 13);
            this.label14.TabIndex = 117;
            this.label14.Text = "State is Hawaii, Alaska or Armed Forces ADD Shipping Chg.";
            // 
            // lbldisc2
            // 
            this.lbldisc2.AutoSize = true;
            this.lbldisc2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "disc2", true));
            this.lbldisc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldisc2.Location = new System.Drawing.Point(449, 64);
            this.lbldisc2.Name = "lbldisc2";
            this.lbldisc2.Size = new System.Drawing.Size(41, 13);
            this.lbldisc2.TabIndex = 166;
            this.lbldisc2.Text = "label21";
            // 
            // lbldisc1
            // 
            this.lbldisc1.AutoSize = true;
            this.lbldisc1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "disc1", true));
            this.lbldisc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldisc1.Location = new System.Drawing.Point(449, 41);
            this.lbldisc1.Name = "lbldisc1";
            this.lbldisc1.Size = new System.Drawing.Size(41, 13);
            this.lbldisc1.TabIndex = 165;
            this.lbldisc1.Text = "label21";
            // 
            // lblsubtot
            // 
            this.lblsubtot.AutoSize = true;
            this.lblsubtot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "sbtot", true));
            this.lblsubtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtot.Location = new System.Drawing.Point(446, 15);
            this.lblsubtot.Name = "lblsubtot";
            this.lblsubtot.Size = new System.Drawing.Size(41, 13);
            this.lblsubtot.TabIndex = 164;
            this.lblsubtot.Text = "label21";
            // 
            // txtDisc
            // 
            this.txtDisc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "dp1", true));
            this.txtDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisc.Location = new System.Drawing.Point(387, 38);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.Size = new System.Drawing.Size(57, 20);
            this.txtDisc.TabIndex = 100;
            this.txtDisc.Leave += new System.EventHandler(this.txtDisc_Leave);
            // 
            // txtFinalbookprc
            // 
            this.txtFinalbookprc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "fbkprc", true));
            this.txtFinalbookprc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinalbookprc.ForeColor = System.Drawing.Color.Red;
            this.txtFinalbookprc.Location = new System.Drawing.Point(161, 179);
            this.txtFinalbookprc.Name = "txtFinalbookprc";
            this.txtFinalbookprc.ReadOnly = true;
            this.txtFinalbookprc.Size = new System.Drawing.Size(65, 20);
            this.txtFinalbookprc.TabIndex = 123;
            // 
            // dp1descComboBox
            // 
            this.dp1descComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "dp1desc", true));
            this.dp1descComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dp1descComboBox.FormattingEnabled = true;
            this.dp1descComboBox.Location = new System.Drawing.Point(134, 38);
            this.dp1descComboBox.Name = "dp1descComboBox";
            this.dp1descComboBox.Size = new System.Drawing.Size(121, 21);
            this.dp1descComboBox.TabIndex = 102;
            // 
            // txtNumtoPers
            // 
            this.txtNumtoPers.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "perstotal", true));
            this.txtNumtoPers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumtoPers.Location = new System.Drawing.Point(257, 155);
            this.txtNumtoPers.Name = "txtNumtoPers";
            this.txtNumtoPers.Size = new System.Drawing.Size(53, 20);
            this.txtNumtoPers.TabIndex = 122;
            // 
            // perscopiesTextBox
            // 
            this.perscopiesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "perscopies", true));
            this.perscopiesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perscopiesTextBox.Location = new System.Drawing.Point(171, 129);
            this.perscopiesTextBox.Name = "perscopiesTextBox";
            this.perscopiesTextBox.Size = new System.Drawing.Size(41, 20);
            this.perscopiesTextBox.TabIndex = 120;
            this.perscopiesTextBox.Leave += new System.EventHandler(this.perscopiesTextBox_Leave);
            // 
            // chkDc2
            // 
            this.chkDc2.AutoSize = true;
            this.chkDc2.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "dc2", true));
            this.chkDc2.Location = new System.Drawing.Point(69, 61);
            this.chkDc2.Name = "chkDc2";
            this.chkDc2.Size = new System.Drawing.Size(182, 17);
            this.chkDc2.TabIndex = 105;
            this.chkDc2.Text = "Full pay w/page submission";
            this.chkDc2.UseVisualStyleBackColor = true;
            this.chkDc2.CheckedChanged += new System.EventHandler(this.chkDc2_CheckedChanged);
            // 
            // txtDp2
            // 
            this.txtDp2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "dp2", true));
            this.txtDp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDp2.Location = new System.Drawing.Point(387, 61);
            this.txtDp2.Name = "txtDp2";
            this.txtDp2.Size = new System.Drawing.Size(57, 20);
            this.txtDp2.TabIndex = 106;
            this.txtDp2.Leave += new System.EventHandler(this.txtDp2_Leave);
            // 
            // persamountTextBox
            // 
            this.persamountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "persamount", true));
            this.persamountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.persamountTextBox.Location = new System.Drawing.Point(257, 129);
            this.persamountTextBox.Name = "persamountTextBox";
            this.persamountTextBox.Size = new System.Drawing.Size(56, 20);
            this.persamountTextBox.TabIndex = 118;
            this.persamountTextBox.Leave += new System.EventHandler(this.persamountTextBox_Leave);
            // 
            // txtDp3Desc
            // 
            this.txtDp3Desc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "dp3desc", true));
            this.txtDp3Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDp3Desc.Location = new System.Drawing.Point(146, 84);
            this.txtDp3Desc.Name = "txtDp3Desc";
            this.txtDp3Desc.Size = new System.Drawing.Size(79, 20);
            this.txtDp3Desc.TabIndex = 109;
            // 
            // dp3ComboBox
            // 
            this.dp3ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "dp3", true));
            this.dp3ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dp3ComboBox.FormattingEnabled = true;
            this.dp3ComboBox.Items.AddRange(new object[] {
            ".000",
            ".005",
            ".010",
            ".015",
            ".020",
            ".025",
            ".030",
            ".035",
            ".040",
            ".045",
            ".050",
            ".055",
            ".060",
            ".065",
            ".070",
            ".075",
            ".080",
            ".085",
            ".090",
            ".100",
            ".105",
            ".110",
            ".115",
            ".120",
            ".125",
            ".130",
            ".135",
            ".140",
            ".145",
            ".150",
            ".155",
            ".160",
            ".165",
            ".170",
            ".175",
            ".180",
            ".185",
            ".190",
            ".195",
            ".200"});
            this.dp3ComboBox.Location = new System.Drawing.Point(386, 84);
            this.dp3ComboBox.Name = "dp3ComboBox";
            this.dp3ComboBox.Size = new System.Drawing.Size(58, 21);
            this.dp3ComboBox.TabIndex = 110;
            this.dp3ComboBox.Leave += new System.EventHandler(this.dp3ComboBox_Leave);
            // 
            // chkMsStandard
            // 
            this.chkMsStandard.AutoSize = true;
            this.chkMsStandard.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "foilck", true));
            this.chkMsStandard.Location = new System.Drawing.Point(69, 106);
            this.chkMsStandard.Name = "chkMsStandard";
            this.chkMsStandard.Size = new System.Drawing.Size(127, 17);
            this.chkMsStandard.TabIndex = 112;
            this.chkMsStandard.Text = "MS/Stan with/Pic";
            this.chkMsStandard.UseVisualStyleBackColor = true;
            this.chkMsStandard.Click += new System.EventHandler(this.chkMsStandard_Click);
            // 
            // txtMsQty
            // 
            this.txtMsQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "msstanqty", true));
            this.txtMsQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsQty.Location = new System.Drawing.Point(385, 106);
            this.txtMsQty.Name = "txtMsQty";
            this.txtMsQty.Size = new System.Drawing.Size(58, 20);
            this.txtMsQty.TabIndex = 114;
            this.txtMsQty.Leave += new System.EventHandler(this.txtMsQty_Leave);
            // 
            // foilamtTextBox
            // 
            this.foilamtTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "foilamt", true));
            this.foilamtTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foilamtTextBox.Location = new System.Drawing.Point(202, 106);
            this.foilamtTextBox.Name = "foilamtTextBox";
            this.foilamtTextBox.ReadOnly = true;
            this.foilamtTextBox.Size = new System.Drawing.Size(83, 20);
            this.foilamtTextBox.TabIndex = 113;
            // 
            // pnlMiscDiscCred
            // 
            this.pnlMiscDiscCred.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMiscDiscCred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMiscDiscCred.Controls.Add(this.label6);
            this.pnlMiscDiscCred.Controls.Add(this.txtClrDesc);
            this.pnlMiscDiscCred.Controls.Add(this.txtClrTot);
            this.pnlMiscDiscCred.Controls.Add(this.txtMisc);
            this.pnlMiscDiscCred.Controls.Add(this.txtMdesc);
            this.pnlMiscDiscCred.Controls.Add(this.txtDesc1amt);
            this.pnlMiscDiscCred.Controls.Add(this.txtDesc1);
            this.pnlMiscDiscCred.Controls.Add(this.txtDesc3tot);
            this.pnlMiscDiscCred.Controls.Add(this.txtDesc3);
            this.pnlMiscDiscCred.Controls.Add(this.txtDesc4tot);
            this.pnlMiscDiscCred.Controls.Add(this.txtDesc4);
            this.pnlMiscDiscCred.Location = new System.Drawing.Point(505, 90);
            this.pnlMiscDiscCred.Name = "pnlMiscDiscCred";
            this.pnlMiscDiscCred.Size = new System.Drawing.Size(338, 175);
            this.pnlMiscDiscCred.TabIndex = 99;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 9);
            this.label6.TabIndex = 92;
            this.label6.Text = "Misc Credits/Charges";
            // 
            // txtClrDesc
            // 
            this.txtClrDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClrDesc.BackColor = System.Drawing.Color.Aqua;
            this.txtClrDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "clrpgdesc", true));
            this.txtClrDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClrDesc.Location = new System.Drawing.Point(7, 32);
            this.txtClrDesc.Name = "txtClrDesc";
            this.txtClrDesc.Size = new System.Drawing.Size(259, 20);
            this.txtClrDesc.TabIndex = 68;
            // 
            // txtClrTot
            // 
            this.txtClrTot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClrTot.BackColor = System.Drawing.Color.Aqua;
            this.txtClrTot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "clrpgtot", true));
            this.txtClrTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClrTot.Location = new System.Drawing.Point(270, 32);
            this.txtClrTot.Name = "txtClrTot";
            this.txtClrTot.Size = new System.Drawing.Size(53, 20);
            this.txtClrTot.TabIndex = 70;
            this.txtClrTot.Leave += new System.EventHandler(this.txtClrTot_Leave);
            // 
            // txtMisc
            // 
            this.txtMisc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMisc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "misc", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.txtMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMisc.Location = new System.Drawing.Point(270, 55);
            this.txtMisc.Name = "txtMisc";
            this.txtMisc.Size = new System.Drawing.Size(53, 20);
            this.txtMisc.TabIndex = 74;
            this.txtMisc.Leave += new System.EventHandler(this.txtMisc_Leave);
            // 
            // txtMdesc
            // 
            this.txtMdesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMdesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "mdesc", true));
            this.txtMdesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMdesc.Location = new System.Drawing.Point(7, 55);
            this.txtMdesc.Name = "txtMdesc";
            this.txtMdesc.Size = new System.Drawing.Size(259, 20);
            this.txtMdesc.TabIndex = 72;
            // 
            // txtDesc1amt
            // 
            this.txtDesc1amt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc1amt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "desc1tot", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.txtDesc1amt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc1amt.Location = new System.Drawing.Point(270, 78);
            this.txtDesc1amt.Name = "txtDesc1amt";
            this.txtDesc1amt.Size = new System.Drawing.Size(53, 20);
            this.txtDesc1amt.TabIndex = 78;
            this.txtDesc1amt.Leave += new System.EventHandler(this.txtDesc1amt_Leave);
            // 
            // txtDesc1
            // 
            this.txtDesc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "desc1", true));
            this.txtDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc1.Location = new System.Drawing.Point(7, 78);
            this.txtDesc1.Name = "txtDesc1";
            this.txtDesc1.Size = new System.Drawing.Size(259, 20);
            this.txtDesc1.TabIndex = 76;
            // 
            // txtDesc3tot
            // 
            this.txtDesc3tot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc3tot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "desc3tot", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.txtDesc3tot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc3tot.Location = new System.Drawing.Point(270, 101);
            this.txtDesc3tot.Name = "txtDesc3tot";
            this.txtDesc3tot.Size = new System.Drawing.Size(53, 20);
            this.txtDesc3tot.TabIndex = 82;
            this.txtDesc3tot.Leave += new System.EventHandler(this.txtDesc3tot_Leave);
            // 
            // txtDesc3
            // 
            this.txtDesc3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "desc3", true));
            this.txtDesc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc3.Location = new System.Drawing.Point(7, 101);
            this.txtDesc3.Name = "txtDesc3";
            this.txtDesc3.Size = new System.Drawing.Size(259, 20);
            this.txtDesc3.TabIndex = 80;
            // 
            // txtDesc4tot
            // 
            this.txtDesc4tot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc4tot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "desc4tot", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.txtDesc4tot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc4tot.Location = new System.Drawing.Point(270, 125);
            this.txtDesc4tot.Name = "txtDesc4tot";
            this.txtDesc4tot.Size = new System.Drawing.Size(53, 20);
            this.txtDesc4tot.TabIndex = 86;
            this.txtDesc4tot.Leave += new System.EventHandler(this.txtDesc4tot_Leave);
            // 
            // txtDesc4
            // 
            this.txtDesc4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "desc4", true));
            this.txtDesc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc4.Location = new System.Drawing.Point(7, 125);
            this.txtDesc4.Name = "txtDesc4";
            this.txtDesc4.Size = new System.Drawing.Size(259, 20);
            this.txtDesc4.TabIndex = 84;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblSpeccvr);
            this.panel3.Controls.Add(this.chkAllClr);
            this.panel3.Controls.Add(this.lblMLaminateAmt);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblLaminateAmt);
            this.panel3.Controls.Add(this.txtnoClrPgs);
            this.panel3.Controls.Add(this.chkGlossLam);
            this.panel3.Controls.Add(this.chkMLaminate);
            this.panel3.Controls.Add(this.inkclrComboBox);
            this.panel3.Controls.Add(inkclrLabel);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtClrNumber);
            this.panel3.Controls.Add(this.txtCoverDesc);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(speccvrLabel);
            this.panel3.Controls.Add(this.txtSpecCvrEa);
            this.panel3.Controls.Add(speceaLabel);
            this.panel3.Controls.Add(this.txtFoilAd);
            this.panel3.Controls.Add(foiladamtLabel);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(272, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(195, 250);
            this.panel3.TabIndex = 98;
            // 
            // lblSpeccvr
            // 
            this.lblSpeccvr.AutoSize = true;
            this.lblSpeccvr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "speccvr", true));
            this.lblSpeccvr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeccvr.Location = new System.Drawing.Point(125, 201);
            this.lblSpeccvr.Name = "lblSpeccvr";
            this.lblSpeccvr.Size = new System.Drawing.Size(41, 13);
            this.lblSpeccvr.TabIndex = 165;
            this.lblSpeccvr.Text = "label10";
            // 
            // chkAllClr
            // 
            this.chkAllClr.AutoSize = true;
            this.chkAllClr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllClr.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "allclrck", true));
            this.chkAllClr.Location = new System.Drawing.Point(42, 17);
            this.chkAllClr.Name = "chkAllClr";
            this.chkAllClr.Size = new System.Drawing.Size(73, 17);
            this.chkAllClr.TabIndex = 43;
            this.chkAllClr.Text = "All Color";
            this.chkAllClr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllClr.UseVisualStyleBackColor = true;
            this.chkAllClr.Click += new System.EventHandler(this.chkAllClr_Click);
            // 
            // lblMLaminateAmt
            // 
            this.lblMLaminateAmt.AutoSize = true;
            this.lblMLaminateAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "mlaminationamt", true));
            this.lblMLaminateAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMLaminateAmt.Location = new System.Drawing.Point(119, 84);
            this.lblMLaminateAmt.Name = "lblMLaminateAmt";
            this.lblMLaminateAmt.Size = new System.Drawing.Size(41, 13);
            this.lblMLaminateAmt.TabIndex = 164;
            this.lblMLaminateAmt.Text = "label20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "# of Color Pages";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLaminateAmt
            // 
            this.lblLaminateAmt.AutoSize = true;
            this.lblLaminateAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "laminate", true));
            this.lblLaminateAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaminateAmt.Location = new System.Drawing.Point(121, 66);
            this.lblLaminateAmt.Name = "lblLaminateAmt";
            this.lblLaminateAmt.Size = new System.Drawing.Size(41, 13);
            this.lblLaminateAmt.TabIndex = 162;
            this.lblLaminateAmt.Text = "label20";
            // 
            // txtnoClrPgs
            // 
            this.txtnoClrPgs.BackColor = System.Drawing.Color.Aqua;
            this.txtnoClrPgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnoClrPgs.Location = new System.Drawing.Point(122, 39);
            this.txtnoClrPgs.Name = "txtnoClrPgs";
            this.txtnoClrPgs.Size = new System.Drawing.Size(53, 20);
            this.txtnoClrPgs.TabIndex = 46;
            // 
            // chkGlossLam
            // 
            this.chkGlossLam.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkGlossLam.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "layn", true));
            this.chkGlossLam.Location = new System.Drawing.Point(11, 61);
            this.chkGlossLam.Name = "chkGlossLam";
            this.chkGlossLam.Size = new System.Drawing.Size(104, 24);
            this.chkGlossLam.TabIndex = 47;
            this.chkGlossLam.Text = "Gloss Laminate";
            this.chkGlossLam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkGlossLam.UseVisualStyleBackColor = true;
            this.chkGlossLam.Click += new System.EventHandler(this.chkGlossLam_Click);
            // 
            // chkMLaminate
            // 
            this.chkMLaminate.AutoSize = true;
            this.chkMLaminate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMLaminate.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "mlamination", true));
            this.chkMLaminate.Location = new System.Drawing.Point(2, 84);
            this.chkMLaminate.Name = "chkMLaminate";
            this.chkMLaminate.Size = new System.Drawing.Size(113, 17);
            this.chkMLaminate.TabIndex = 50;
            this.chkMLaminate.Text = "Matte Laminate";
            this.chkMLaminate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMLaminate.UseVisualStyleBackColor = true;
            this.chkMLaminate.Click += new System.EventHandler(this.chkMLaminate_Click);
            // 
            // inkclrComboBox
            // 
            this.inkclrComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "inkclr", true));
            this.inkclrComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inkclrComboBox.FormattingEnabled = true;
            this.inkclrComboBox.Location = new System.Drawing.Point(122, 107);
            this.inkclrComboBox.Name = "inkclrComboBox";
            this.inkclrComboBox.Size = new System.Drawing.Size(53, 21);
            this.inkclrComboBox.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "# of Color";
            // 
            // txtClrNumber
            // 
            this.txtClrNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClrNumber.Location = new System.Drawing.Point(122, 131);
            this.txtClrNumber.Name = "txtClrNumber";
            this.txtClrNumber.Size = new System.Drawing.Size(53, 20);
            this.txtClrNumber.TabIndex = 54;
            // 
            // txtCoverDesc
            // 
            this.txtCoverDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoverDesc.Location = new System.Drawing.Point(122, 154);
            this.txtCoverDesc.Name = "txtCoverDesc";
            this.txtCoverDesc.Size = new System.Drawing.Size(53, 20);
            this.txtCoverDesc.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Cover Desc.:";
            // 
            // txtSpecCvrEa
            // 
            this.txtSpecCvrEa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "specea", true));
            this.txtSpecCvrEa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecCvrEa.Location = new System.Drawing.Point(122, 176);
            this.txtSpecCvrEa.Name = "txtSpecCvrEa";
            this.txtSpecCvrEa.Size = new System.Drawing.Size(53, 20);
            this.txtSpecCvrEa.TabIndex = 59;
            this.txtSpecCvrEa.Leave += new System.EventHandler(this.txtSpecCvrEa_Leave);
            // 
            // txtFoilAd
            // 
            this.txtFoilAd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "foiladamt", true));
            this.txtFoilAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFoilAd.Location = new System.Drawing.Point(122, 220);
            this.txtFoilAd.Name = "txtFoilAd";
            this.txtFoilAd.Size = new System.Drawing.Size(53, 20);
            this.txtFoilAd.TabIndex = 61;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblStoryAmt);
            this.panel2.Controls.Add(this.lblYir);
            this.panel2.Controls.Add(this.lblConvAmt);
            this.panel2.Controls.Add(this.lblProfAmt);
            this.panel2.Controls.Add(this.chkProfessional);
            this.panel2.Controls.Add(this.chkConv);
            this.panel2.Controls.Add(this.chkYir);
            this.panel2.Controls.Add(this.chkStory);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(11, 253);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 100);
            this.panel2.TabIndex = 97;
            // 
            // lblStoryAmt
            // 
            this.lblStoryAmt.AutoSize = true;
            this.lblStoryAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "storyamt", true));
            this.lblStoryAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoryAmt.Location = new System.Drawing.Point(152, 72);
            this.lblStoryAmt.Name = "lblStoryAmt";
            this.lblStoryAmt.Size = new System.Drawing.Size(41, 13);
            this.lblStoryAmt.TabIndex = 161;
            this.lblStoryAmt.Text = "label21";
            // 
            // lblYir
            // 
            this.lblYir.AutoSize = true;
            this.lblYir.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "insamt", true));
            this.lblYir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYir.Location = new System.Drawing.Point(152, 52);
            this.lblYir.Name = "lblYir";
            this.lblYir.Size = new System.Drawing.Size(41, 13);
            this.lblYir.TabIndex = 160;
            this.lblYir.Text = "label20";
            // 
            // lblConvAmt
            // 
            this.lblConvAmt.AutoSize = true;
            this.lblConvAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "conven", true));
            this.lblConvAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvAmt.Location = new System.Drawing.Point(152, 33);
            this.lblConvAmt.Name = "lblConvAmt";
            this.lblConvAmt.Size = new System.Drawing.Size(41, 13);
            this.lblConvAmt.TabIndex = 158;
            this.lblConvAmt.Text = "label20";
            // 
            // lblProfAmt
            // 
            this.lblProfAmt.AutoSize = true;
            this.lblProfAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "prof", true));
            this.lblProfAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfAmt.Location = new System.Drawing.Point(152, 11);
            this.lblProfAmt.Name = "lblProfAmt";
            this.lblProfAmt.Size = new System.Drawing.Size(41, 13);
            this.lblProfAmt.TabIndex = 159;
            this.lblProfAmt.Text = "label21";
            // 
            // chkProfessional
            // 
            this.chkProfessional.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkProfessional.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "pryn", true));
            this.chkProfessional.Location = new System.Drawing.Point(44, 9);
            this.chkProfessional.Name = "chkProfessional";
            this.chkProfessional.Size = new System.Drawing.Size(104, 17);
            this.chkProfessional.TabIndex = 12;
            this.chkProfessional.Text = "Professional";
            this.chkProfessional.UseVisualStyleBackColor = true;
            this.chkProfessional.Click += new System.EventHandler(this.chkProfessional_Click);
            // 
            // chkConv
            // 
            this.chkConv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkConv.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "coyn", true));
            this.chkConv.Location = new System.Drawing.Point(44, 27);
            this.chkConv.Name = "chkConv";
            this.chkConv.Size = new System.Drawing.Size(104, 24);
            this.chkConv.TabIndex = 14;
            this.chkConv.Text = "Convenient";
            this.chkConv.UseVisualStyleBackColor = true;
            this.chkConv.Click += new System.EventHandler(this.chkConv_Click);
            // 
            // chkYir
            // 
            this.chkYir.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkYir.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "insck", true));
            this.chkYir.Location = new System.Drawing.Point(44, 52);
            this.chkYir.Name = "chkYir";
            this.chkYir.Size = new System.Drawing.Size(104, 18);
            this.chkYir.TabIndex = 16;
            this.chkYir.Text = "YIR Standard";
            this.chkYir.UseVisualStyleBackColor = true;
            this.chkYir.Click += new System.EventHandler(this.chkYir_Click);
            // 
            // chkStory
            // 
            this.chkStory.AutoSize = true;
            this.chkStory.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkStory.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "story", true));
            this.chkStory.Location = new System.Drawing.Point(18, 70);
            this.chkStory.Name = "chkStory";
            this.chkStory.Size = new System.Drawing.Size(130, 17);
            this.chkStory.TabIndex = 63;
            this.chkStory.Text = "Our Story/MyStory";
            this.chkStory.UseVisualStyleBackColor = true;
            this.chkStory.Click += new System.EventHandler(this.chkStory_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblSaddleAmt);
            this.panel1.Controls.Add(this.lblSpiralAmt);
            this.panel1.Controls.Add(this.lblPerfbindAmt);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.chkPerfBind);
            this.panel1.Controls.Add(this.chkSpiral);
            this.panel1.Controls.Add(this.chkSaddlStitch);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 82);
            this.panel1.TabIndex = 96;
            // 
            // lblSaddleAmt
            // 
            this.lblSaddleAmt.AutoSize = true;
            this.lblSaddleAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "sdlstichamt", true));
            this.lblSaddleAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaddleAmt.Location = new System.Drawing.Point(153, 58);
            this.lblSaddleAmt.Name = "lblSaddleAmt";
            this.lblSaddleAmt.Size = new System.Drawing.Size(41, 13);
            this.lblSaddleAmt.TabIndex = 160;
            this.lblSaddleAmt.Text = "label22";
            // 
            // lblSpiralAmt
            // 
            this.lblSpiralAmt.AutoSize = true;
            this.lblSpiralAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "spiramt", true));
            this.lblSpiralAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpiralAmt.Location = new System.Drawing.Point(153, 39);
            this.lblSpiralAmt.Name = "lblSpiralAmt";
            this.lblSpiralAmt.Size = new System.Drawing.Size(41, 13);
            this.lblSpiralAmt.TabIndex = 161;
            this.lblSpiralAmt.Text = "label23";
            // 
            // lblPerfbindAmt
            // 
            this.lblPerfbindAmt.AutoSize = true;
            this.lblPerfbindAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "perfbind", true));
            this.lblPerfbindAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfbindAmt.Location = new System.Drawing.Point(153, 21);
            this.lblPerfbindAmt.Name = "lblPerfbindAmt";
            this.lblPerfbindAmt.Size = new System.Drawing.Size(41, 13);
            this.lblPerfbindAmt.TabIndex = 162;
            this.lblPerfbindAmt.Text = "label24";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 9);
            this.label9.TabIndex = 96;
            this.label9.Text = "Soft Cover Binding";
            // 
            // chkPerfBind
            // 
            this.chkPerfBind.AutoSize = true;
            this.chkPerfBind.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPerfBind.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "peyn", true));
            this.chkPerfBind.Location = new System.Drawing.Point(26, 19);
            this.chkPerfBind.Name = "chkPerfBind";
            this.chkPerfBind.Size = new System.Drawing.Size(122, 17);
            this.chkPerfBind.TabIndex = 6;
            this.chkPerfBind.Text = "Perfect Bind (40)";
            this.chkPerfBind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPerfBind.UseVisualStyleBackColor = true;
            this.chkPerfBind.Click += new System.EventHandler(this.chkPerfBind_Click);
            // 
            // chkSpiral
            // 
            this.chkSpiral.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSpiral.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "spirck", true));
            this.chkSpiral.Location = new System.Drawing.Point(44, 37);
            this.chkSpiral.Name = "chkSpiral";
            this.chkSpiral.Size = new System.Drawing.Size(104, 17);
            this.chkSpiral.TabIndex = 8;
            this.chkSpiral.Text = "Spiral";
            this.chkSpiral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSpiral.UseVisualStyleBackColor = true;
            this.chkSpiral.Click += new System.EventHandler(this.chkSpiral_Click);
            // 
            // chkSaddlStitch
            // 
            this.chkSaddlStitch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSaddlStitch.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "sdlstich", true));
            this.chkSaddlStitch.Location = new System.Drawing.Point(44, 56);
            this.chkSaddlStitch.Name = "chkSaddlStitch";
            this.chkSaddlStitch.Size = new System.Drawing.Size(104, 17);
            this.chkSaddlStitch.TabIndex = 10;
            this.chkSaddlStitch.Text = "Saddle Stitch";
            this.chkSaddlStitch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSaddlStitch.UseVisualStyleBackColor = true;
            this.chkSaddlStitch.Click += new System.EventHandler(this.chkSaddlStitch_Click);
            // 
            // pnlHard
            // 
            this.pnlHard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHard.Controls.Add(this.lblCaseamt);
            this.pnlHard.Controls.Add(this.label8);
            this.pnlHard.Controls.Add(this.chkHardBack);
            this.pnlHard.Controls.Add(this.chkCaseBind);
            this.pnlHard.Controls.Add(this.lblHardbackAmt);
            this.pnlHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlHard.Location = new System.Drawing.Point(9, 90);
            this.pnlHard.Name = "pnlHard";
            this.pnlHard.Size = new System.Drawing.Size(248, 73);
            this.pnlHard.TabIndex = 95;
            // 
            // lblCaseamt
            // 
            this.lblCaseamt.AutoSize = true;
            this.lblCaseamt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "caseamt", true));
            this.lblCaseamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaseamt.Location = new System.Drawing.Point(152, 44);
            this.lblCaseamt.Name = "lblCaseamt";
            this.lblCaseamt.Size = new System.Drawing.Size(41, 13);
            this.lblCaseamt.TabIndex = 163;
            this.lblCaseamt.Text = "label25";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 9);
            this.label8.TabIndex = 96;
            this.label8.Text = "Hard Cover Binding";
            // 
            // chkHardBack
            // 
            this.chkHardBack.AutoSize = true;
            this.chkHardBack.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHardBack.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "hdbky_n", true));
            this.chkHardBack.Location = new System.Drawing.Point(3, 23);
            this.chkHardBack.Name = "chkHardBack";
            this.chkHardBack.Size = new System.Drawing.Size(145, 17);
            this.chkHardBack.TabIndex = 1;
            this.chkHardBack.Text = "Hard Back (sewn 40)";
            this.chkHardBack.UseVisualStyleBackColor = true;
            this.chkHardBack.Click += new System.EventHandler(this.chkHardBack_Click);
            // 
            // chkCaseBind
            // 
            this.chkCaseBind.AutoSize = true;
            this.chkCaseBind.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCaseBind.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "casey_n", true));
            this.chkCaseBind.Location = new System.Drawing.Point(4, 42);
            this.chkCaseBind.Name = "chkCaseBind";
            this.chkCaseBind.Size = new System.Drawing.Size(144, 17);
            this.chkCaseBind.TabIndex = 4;
            this.chkCaseBind.Text = "Case Bind (glued 32)";
            this.chkCaseBind.UseVisualStyleBackColor = true;
            this.chkCaseBind.Click += new System.EventHandler(this.chkCaseBind_Click);
            // 
            // lblHardbackAmt
            // 
            this.lblHardbackAmt.AutoSize = true;
            this.lblHardbackAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "hardback", true));
            this.lblHardbackAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHardbackAmt.Location = new System.Drawing.Point(152, 25);
            this.lblHardbackAmt.Name = "lblHardbackAmt";
            this.lblHardbackAmt.Size = new System.Drawing.Size(41, 13);
            this.lblHardbackAmt.TabIndex = 157;
            this.lblHardbackAmt.Text = "label19";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(126, 62);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 20);
            this.textBox3.TabIndex = 94;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 93;
            this.label7.Text = "Spec Cvr Rqst  Copies";
            // 
            // lblInvoice
            // 
            this.lblInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "invno", true));
            this.lblInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoice.ForeColor = System.Drawing.Color.Blue;
            this.lblInvoice.Location = new System.Drawing.Point(1091, 8);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(45, 16);
            this.lblInvoice.TabIndex = 12;
            this.lblInvoice.Text = "label6";
            // 
            // txtExtChrg
            // 
            this.txtExtChrg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtChrg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "extrchg", true));
            this.txtExtChrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtChrg.Location = new System.Drawing.Point(574, 271);
            this.txtExtChrg.Multiline = true;
            this.txtExtChrg.Name = "txtExtChrg";
            this.txtExtChrg.Size = new System.Drawing.Size(269, 40);
            this.txtExtChrg.TabIndex = 88;
            // 
            // custBindingSource
            // 
            this.custBindingSource.DataMember = "cust";
            this.custBindingSource.DataSource = this.dsSales;
            // 
            // cmbYrDiscountAmt
            // 
            this.cmbYrDiscountAmt.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.quotesBindingSource, "yrdiscountamt", true));
            this.cmbYrDiscountAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYrDiscountAmt.FormattingEnabled = true;
            this.cmbYrDiscountAmt.Items.AddRange(new object[] {
            "",
            ".4025",
            ".3920"});
            this.cmbYrDiscountAmt.Location = new System.Drawing.Point(813, 37);
            this.cmbYrDiscountAmt.Name = "cmbYrDiscountAmt";
            this.cmbYrDiscountAmt.Size = new System.Drawing.Size(79, 21);
            this.cmbYrDiscountAmt.TabIndex = 25;
            this.cmbYrDiscountAmt.Leave += new System.EventHandler(this.cmbYrDiscountAmt_Leave);
            // 
            // chkPromo
            // 
            this.chkPromo.AutoSize = true;
            this.chkPromo.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "yrdiscount", true));
            this.chkPromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPromo.Location = new System.Drawing.Point(732, 37);
            this.chkPromo.Name = "chkPromo";
            this.chkPromo.Size = new System.Drawing.Size(61, 17);
            this.chkPromo.TabIndex = 23;
            this.chkPromo.Text = "Promo";
            this.chkPromo.UseVisualStyleBackColor = true;
            this.chkPromo.Click += new System.EventHandler(this.chkPromo_Click);
            // 
            // lblPCEach
            // 
            this.lblPCEach.AutoSize = true;
            this.lblPCEach.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPCEach.Location = new System.Drawing.Point(316, 64);
            this.lblPCEach.Name = "lblPCEach";
            this.lblPCEach.Size = new System.Drawing.Size(35, 13);
            this.lblPCEach.TabIndex = 41;
            this.lblPCEach.Text = "label3";
            // 
            // lblPCTotal
            // 
            this.lblPCTotal.AutoSize = true;
            this.lblPCTotal.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPCTotal.Location = new System.Drawing.Point(665, 64);
            this.lblPCTotal.Name = "lblPCTotal";
            this.lblPCTotal.Size = new System.Drawing.Size(35, 13);
            this.lblPCTotal.TabIndex = 40;
            this.lblPCTotal.Text = "label4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(563, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Total Prof/Conv:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(211, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Porf/Conv Each:";
            // 
            // txtPriceOverRide
            // 
            this.txtPriceOverRide.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "prcor", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.txtPriceOverRide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceOverRide.Location = new System.Drawing.Point(493, 37);
            this.txtPriceOverRide.Name = "txtPriceOverRide";
            this.txtPriceOverRide.Size = new System.Drawing.Size(57, 20);
            this.txtPriceOverRide.TabIndex = 20;
            this.txtPriceOverRide.Leave += new System.EventHandler(this.txtPriceOverRide_Leave);
            // 
            // txtSource
            // 
            this.txtSource.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "source", true));
            this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(886, 8);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(100, 20);
            this.txtSource.TabIndex = 10;
            // 
            // booktypeTextBox
            // 
            this.booktypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "booktype", true));
            this.booktypeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.booktypeTextBox.Location = new System.Drawing.Point(92, 8);
            this.booktypeTextBox.MaxLength = 4;
            this.booktypeTextBox.Name = "booktypeTextBox";
            this.booktypeTextBox.Size = new System.Drawing.Size(44, 20);
            this.booktypeTextBox.TabIndex = 0;
            // 
            // txtNocopies
            // 
            this.txtNocopies.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "nocopies", true));
            this.txtNocopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNocopies.Location = new System.Drawing.Point(86, 37);
            this.txtNocopies.MaxLength = 5;
            this.txtNocopies.Name = "txtNocopies";
            this.txtNocopies.Size = new System.Drawing.Size(39, 20);
            this.txtNocopies.TabIndex = 14;
            this.txtNocopies.Leave += new System.EventHandler(this.txtNocopies_Leave);
            // 
            // dteQuote
            // 
            this.dteQuote.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.quotesBindingSource, "qtedate", true));
            this.dteQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteQuote.Location = new System.Drawing.Point(612, 8);
            this.dteQuote.Name = "dteQuote";
            this.dteQuote.Size = new System.Drawing.Size(200, 20);
            this.dteQuote.TabIndex = 8;
            // 
            // txtPoNum
            // 
            this.txtPoNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "ponum", true));
            this.txtPoNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoNum.Location = new System.Drawing.Point(413, 8);
            this.txtPoNum.Name = "txtPoNum";
            this.txtPoNum.Size = new System.Drawing.Size(100, 20);
            this.txtPoNum.TabIndex = 7;
            // 
            // txtBYear
            // 
            this.txtBYear.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "bpyear", true));
            this.txtBYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBYear.Location = new System.Drawing.Point(327, 8);
            this.txtBYear.MaxLength = 2;
            this.txtBYear.Name = "txtBYear";
            this.txtBYear.Size = new System.Drawing.Size(31, 20);
            this.txtBYear.TabIndex = 4;
            this.txtBYear.Leave += new System.EventHandler(this.txtBYear_Leave);
            // 
            // txtYear
            // 
            this.txtYear.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "contryear", true));
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.Location = new System.Drawing.Point(177, 8);
            this.txtYear.MaxLength = 2;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(39, 20);
            this.txtYear.TabIndex = 2;
            // 
            // txtNoPages
            // 
            this.txtNoPages.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "nopages", true));
            this.txtNoPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoPages.Location = new System.Drawing.Point(177, 37);
            this.txtNoPages.MaxLength = 4;
            this.txtNoPages.Name = "txtNoPages";
            this.txtNoPages.Size = new System.Drawing.Size(37, 20);
            this.txtNoPages.TabIndex = 16;
            this.txtNoPages.Leave += new System.EventHandler(this.txtNoPages_Leave);
            // 
            // pg2
            // 
            this.pg2.BackColor = System.Drawing.SystemColors.Control;
            this.pg2.Location = new System.Drawing.Point(4, 22);
            this.pg2.Name = "pg2";
            this.pg2.Padding = new System.Windows.Forms.Padding(3);
            this.pg2.Size = new System.Drawing.Size(1225, 705);
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
            this.tableAdapterManager.InvHstTableAdapter = null;
            this.tableAdapterManager.quotesTableAdapter = this.quotesTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // custTableAdapter
            // 
            this.custTableAdapter.ClearBeforeFill = true;
            // 
            // invHstTableAdapter
            // 
            this.invHstTableAdapter.ClearBeforeFill = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1234, 731);
            this.Controls.Add(this.tabSales);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1250, 770);
            this.Name = "frmSales";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.frmSales_Load);
            this.tabSales.ResumeLayout(false);
            this.pg1.ResumeLayout(false);
            this.pg1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnSales)).EndInit();
            this.bnSales.ResumeLayout(false);
            this.bnSales.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.invHstDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invHstBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlTot.ResumeLayout(false);
            this.pnlTot.PerformLayout();
            this.pnlMiscDiscCred.ResumeLayout(false);
            this.pnlMiscDiscCred.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlHard.ResumeLayout(false);
            this.pnlHard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.CheckBox chkSaddlStitch;
        private System.Windows.Forms.CheckBox chkSpiral;
        private System.Windows.Forms.CheckBox chkPerfBind;
        private System.Windows.Forms.CheckBox chkCaseBind;
        private System.Windows.Forms.CheckBox chkHardBack;
        private System.Windows.Forms.CheckBox chkProfessional;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtNoPages;
        private System.Windows.Forms.CheckBox chkYir;
        private System.Windows.Forms.CheckBox chkConv;
        private System.Windows.Forms.TextBox booktypeTextBox;
        private System.Windows.Forms.TextBox txtNocopies;
        private System.Windows.Forms.DateTimePicker dteQuote;
        private System.Windows.Forms.TextBox txtPoNum;
        private System.Windows.Forms.TextBox txtBYear;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label lblPCEach;
        private System.Windows.Forms.Label lblPCTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPriceOverRide;
        private System.Windows.Forms.ComboBox inkclrComboBox;
        private System.Windows.Forms.CheckBox chkMLaminate;
        private System.Windows.Forms.CheckBox chkGlossLam;
        private System.Windows.Forms.TextBox txtnoClrPgs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAllClr;
        private System.Windows.Forms.TextBox txtClrNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDesc4tot;
        private System.Windows.Forms.TextBox txtDesc4;
        private System.Windows.Forms.TextBox txtDesc3tot;
        private System.Windows.Forms.TextBox txtDesc3;
        private System.Windows.Forms.TextBox txtDesc1amt;
        private System.Windows.Forms.TextBox txtDesc1;
        private System.Windows.Forms.TextBox txtMisc;
        private System.Windows.Forms.TextBox txtMdesc;
        private System.Windows.Forms.TextBox txtClrTot;
        private System.Windows.Forms.TextBox txtClrDesc;
        private System.Windows.Forms.ComboBox cmbYrDiscountAmt;
        private System.Windows.Forms.CheckBox chkPromo;
        private System.Windows.Forms.CheckBox chkStory;
        private System.Windows.Forms.TextBox txtFoilAd;
        private System.Windows.Forms.TextBox txtSpecCvrEa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCoverDesc;
        private System.Windows.Forms.BindingSource custBindingSource;
        private DataSets.dsSalesTableAdapters.custTableAdapter custTableAdapter;
        private System.Windows.Forms.TextBox txtExtChrg;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlHard;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlMiscDiscCred;
        private System.Windows.Forms.TextBox txtMsQty;
        private System.Windows.Forms.TextBox foilamtTextBox;
        private System.Windows.Forms.CheckBox chkMsStandard;
        private System.Windows.Forms.ComboBox dp3ComboBox;
        private System.Windows.Forms.TextBox txtDp3Desc;
        private System.Windows.Forms.TextBox txtDp2;
        private System.Windows.Forms.CheckBox chkDc2;
        private System.Windows.Forms.ComboBox dp1descComboBox;
        private System.Windows.Forms.TextBox txtDisc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNumtoPers;
        private System.Windows.Forms.TextBox perscopiesTextBox;
        private System.Windows.Forms.TextBox persamountTextBox;
        private System.Windows.Forms.TextBox txtFinalbookprc;
        private System.Windows.Forms.TextBox txtCredits;
        private System.Windows.Forms.TextBox cred_etcTextBox;
        private System.Windows.Forms.Panel pnlTot;
        private System.Windows.Forms.TextBox saletaxTextBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtOtherChrg;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtOtherChrg2;
        private System.Windows.Forms.TextBox desc22TextBox;
        private System.Windows.Forms.TextBox txtCredits2;
        private System.Windows.Forms.TextBox cred_etcTextBox1;
        private System.Windows.Forms.TextBox freebooksTextBox;
        private System.Windows.Forms.BindingSource invHstBindingSource;
        private DataSets.dsSalesTableAdapters.InvHstTableAdapter invHstTableAdapter;
        private System.Windows.Forms.TextBox txtInvoSrch;
        private System.Windows.Forms.TextBox txtPoSrch;
        private System.Windows.Forms.Button btnInvSrch;
        private System.Windows.Forms.Button btnPoSrch;
        private System.Windows.Forms.DataGridView invHstDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnCreateWIP;
        private System.Windows.Forms.Button btnPrntInvoice;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnNoPayPo;
        private System.Windows.Forms.Button btnPaymentNotRec;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtPOAmt;
        private System.Windows.Forms.TextBox txtPayments;
        private System.Windows.Forms.BindingNavigator bnSales;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.Label lblCaseamt;
        private System.Windows.Forms.Label lblPerfbindAmt;
        private System.Windows.Forms.Label lblSpiralAmt;
        private System.Windows.Forms.Label lblSaddleAmt;
        private System.Windows.Forms.Label lblProfAmt;
        private System.Windows.Forms.Label lblConvAmt;
        private System.Windows.Forms.Label lblHardbackAmt;
        private System.Windows.Forms.Label lblStoryAmt;
        private System.Windows.Forms.Label lblYir;
        private System.Windows.Forms.Label lblBookTotal;
        private System.Windows.Forms.Label lbladjbef;
        private System.Windows.Forms.Label lblperstotal;
        private System.Windows.Forms.Label lblDisc3;
        private System.Windows.Forms.Label lblMsTot;
        private System.Windows.Forms.Label lbldisc2;
        private System.Windows.Forms.Label lbldisc1;
        private System.Windows.Forms.Label lblsubtot;
        private System.Windows.Forms.Label lblMLaminateAmt;
        private System.Windows.Forms.Label lblLaminateAmt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPriceEach;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblSpeccvr;
        private System.Windows.Forms.Label lblFinalTotPrc;
    }
    }
