namespace Mbc5.Forms.MemoryBook {
    partial class frmBids {
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
            System.Windows.Forms.Label yrdiscountamtLabel;
            System.Windows.Forms.Label foiladamtLabel;
            System.Windows.Forms.Label speceaLabel;
            System.Windows.Forms.Label speccvrLabel;
            System.Windows.Forms.Label inkclrLabel;
            System.Windows.Forms.Label extrchgLabel;
            System.Windows.Forms.Label adjbefLabel;
            System.Windows.Forms.Label cred_etcLabel;
            System.Windows.Forms.Label cred_etcLabel1;
            System.Windows.Forms.Label desc22Label;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label saletaxLabel;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label msstanqtyLabel;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label dp3descLabel;
            System.Windows.Forms.Label persamountLabel;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label perstotalLabel;
            System.Windows.Forms.Label perscopiesLabel;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label fbkprcLabel;
            System.Windows.Forms.Label dp1Label;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label lblIconCopies;
            System.Windows.Forms.Label freebooksLabel;
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label sbtotLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBids));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBids = new Mbc5.DataSets.dsBids();
            this.bidsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BidInvoiceDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bidsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
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
            this.bidsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pgBids = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnPrntQuote = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.schooltaxrateLabel1 = new System.Windows.Forms.Label();
            this.lblfilnalsubtotal = new System.Windows.Forms.Label();
            this.donotchargeschoolsalestaxCheckBox = new System.Windows.Forms.CheckBox();
            this.lblSalesTax = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtfreebooks = new System.Windows.Forms.TextBox();
            this.txtPOAmt = new System.Windows.Forms.TextBox();
            this.txtPayments = new System.Windows.Forms.TextBox();
            this.txtExtChrg = new System.Windows.Forms.TextBox();
            this.txtPriceOverRide = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.booktypeTextBox = new System.Windows.Forms.TextBox();
            this.txtNocopies = new System.Windows.Forms.TextBox();
            this.txtPoNum = new System.Windows.Forms.TextBox();
            this.txtBYear = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtNoPages = new System.Windows.Forms.TextBox();
            this.pnlTot = new System.Windows.Forms.Panel();
            this.lblIconTot = new System.Windows.Forms.Label();
            this.lblMsTot = new System.Windows.Forms.Label();
            this.otherdiscamt = new System.Windows.Forms.Label();
            this.lbldisc2amount = new System.Windows.Forms.Label();
            this.lbldisc1amount = new System.Windows.Forms.Label();
            this.lblsubtot = new System.Windows.Forms.Label();
            this.txtIconCopies = new System.Windows.Forms.TextBox();
            this.txtIconamt = new System.Windows.Forms.TextBox();
            this.lblperstotal = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
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
            this.lbladjbef = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtOtherChrg = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtOtherChrg2 = new System.Windows.Forms.TextBox();
            this.desc22TextBox = new System.Windows.Forms.TextBox();
            this.txtCredits2 = new System.Windows.Forms.TextBox();
            this.cred_etcTextBox = new System.Windows.Forms.TextBox();
            this.cred_etcTextBox1 = new System.Windows.Forms.TextBox();
            this.txtCredits = new System.Windows.Forms.TextBox();
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
            this.allclramtTextBox = new System.Windows.Forms.TextBox();
            this.lblSpeccvrtot = new System.Windows.Forms.Label();
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
            this.lblYir = new System.Windows.Forms.Label();
            this.lblConvAmt = new System.Windows.Forms.Label();
            this.lblProfAmt = new System.Windows.Forms.Label();
            this.chkProfessional = new System.Windows.Forms.CheckBox();
            this.chkConv = new System.Windows.Forms.CheckBox();
            this.chkYir = new System.Windows.Forms.CheckBox();
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
            this.lblProftotalPrc = new System.Windows.Forms.Label();
            this.lblprofprice = new System.Windows.Forms.Label();
            this.lblPriceEach = new System.Windows.Forms.Label();
            this.lblBookTotal = new System.Windows.Forms.Label();
            this.cmbYrDiscountAmt = new System.Windows.Forms.ComboBox();
            this.chkPromo = new System.Windows.Forms.CheckBox();
            this.lblPCEach = new System.Windows.Forms.Label();
            this.lblPCTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dteQuote = new System.Windows.Forms.DateTimePicker();
            this.tabBids = new System.Windows.Forms.TabControl();
            this.bidsTableAdapter = new Mbc5.DataSets.dsBidsTableAdapters.bidsTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsBidsTableAdapters.TableAdapterManager();
            this.custTableAdapter = new Mbc5.DataSets.dsBidsTableAdapters.custTableAdapter();
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
            yrdiscountamtLabel = new System.Windows.Forms.Label();
            foiladamtLabel = new System.Windows.Forms.Label();
            speceaLabel = new System.Windows.Forms.Label();
            speccvrLabel = new System.Windows.Forms.Label();
            inkclrLabel = new System.Windows.Forms.Label();
            extrchgLabel = new System.Windows.Forms.Label();
            adjbefLabel = new System.Windows.Forms.Label();
            cred_etcLabel = new System.Windows.Forms.Label();
            cred_etcLabel1 = new System.Windows.Forms.Label();
            desc22Label = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            saletaxLabel = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            msstanqtyLabel = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            dp3descLabel = new System.Windows.Forms.Label();
            persamountLabel = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            perstotalLabel = new System.Windows.Forms.Label();
            perscopiesLabel = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            fbkprcLabel = new System.Windows.Forms.Label();
            dp1Label = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            lblIconCopies = new System.Windows.Forms.Label();
            freebooksLabel = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            sbtotLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bidsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BidInvoiceDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bidsBindingNavigator)).BeginInit();
            this.bidsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pgBids.SuspendLayout();
            this.pnlTot.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlMiscDiscCred.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlHard.SuspendLayout();
            this.tabBids.SuspendLayout();
            this.SuspendLayout();
            // 
            // nopagesLabel
            // 
            nopagesLabel.AutoSize = true;
            nopagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nopagesLabel.Location = new System.Drawing.Point(159, 60);
            nopagesLabel.Name = "nopagesLabel";
            nopagesLabel.Size = new System.Drawing.Size(30, 13);
            nopagesLabel.TabIndex = 202;
            nopagesLabel.Text = "#Pg";
            // 
            // contryearLabel
            // 
            contryearLabel.AutoSize = true;
            contryearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contryearLabel.Location = new System.Drawing.Point(152, 31);
            contryearLabel.Name = "contryearLabel";
            contryearLabel.Size = new System.Drawing.Size(37, 13);
            contryearLabel.TabIndex = 177;
            contryearLabel.Text = "Year:";
            // 
            // bpyearLabel
            // 
            bpyearLabel.AutoSize = true;
            bpyearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            bpyearLabel.Location = new System.Drawing.Point(235, 31);
            bpyearLabel.Name = "bpyearLabel";
            bpyearLabel.Size = new System.Drawing.Size(102, 13);
            bpyearLabel.TabIndex = 182;
            bpyearLabel.Text = "Base Price Year:";
            // 
            // ponumLabel
            // 
            ponumLabel.AutoSize = true;
            ponumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ponumLabel.Location = new System.Drawing.Point(387, 31);
            ponumLabel.Name = "ponumLabel";
            ponumLabel.Size = new System.Drawing.Size(36, 13);
            ponumLabel.TabIndex = 184;
            ponumLabel.Text = "PO#:";
            // 
            // qtedateLabel
            // 
            qtedateLabel.AutoSize = true;
            qtedateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qtedateLabel.Location = new System.Drawing.Point(546, 31);
            qtedateLabel.Name = "qtedateLabel";
            qtedateLabel.Size = new System.Drawing.Size(76, 13);
            qtedateLabel.TabIndex = 210;
            qtedateLabel.Text = "Quote Date:";
            // 
            // nocopiesLabel
            // 
            nocopiesLabel.AutoSize = true;
            nocopiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nocopiesLabel.Location = new System.Drawing.Point(39, 60);
            nocopiesLabel.Name = "nocopiesLabel";
            nocopiesLabel.Size = new System.Drawing.Size(57, 13);
            nocopiesLabel.TabIndex = 198;
            nocopiesLabel.Text = "#Copies:";
            // 
            // booktypeLabel
            // 
            booktypeLabel.AutoSize = true;
            booktypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            booktypeLabel.Location = new System.Drawing.Point(30, 31);
            booktypeLabel.Name = "booktypeLabel";
            booktypeLabel.Size = new System.Drawing.Size(72, 13);
            booktypeLabel.TabIndex = 213;
            booktypeLabel.Text = "Book Type:";
            // 
            // sourceLabel
            // 
            sourceLabel.AutoSize = true;
            sourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sourceLabel.Location = new System.Drawing.Point(845, 31);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new System.Drawing.Size(51, 13);
            sourceLabel.TabIndex = 190;
            sourceLabel.Text = "Source:";
            // 
            // book_eaLabel
            // 
            book_eaLabel.AutoSize = true;
            book_eaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            book_eaLabel.Location = new System.Drawing.Point(252, 59);
            book_eaLabel.Name = "book_eaLabel";
            book_eaLabel.Size = new System.Drawing.Size(73, 13);
            book_eaLabel.TabIndex = 204;
            book_eaLabel.Text = "Price Each:";
            // 
            // book_priceLabel
            // 
            book_priceLabel.AutoSize = true;
            book_priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            book_priceLabel.Location = new System.Drawing.Point(604, 60);
            book_priceLabel.Name = "book_priceLabel";
            book_priceLabel.Size = new System.Drawing.Size(77, 13);
            book_priceLabel.TabIndex = 207;
            book_priceLabel.Text = "Book (total):";
            // 
            // prcorLabel
            // 
            prcorLabel.AutoSize = true;
            prcorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            prcorLabel.Location = new System.Drawing.Point(408, 60);
            prcorLabel.Name = "prcorLabel";
            prcorLabel.Size = new System.Drawing.Size(101, 13);
            prcorLabel.TabIndex = 206;
            prcorLabel.Text = "Price Over Ride:";
            // 
            // yrdiscountamtLabel
            // 
            yrdiscountamtLabel.AutoSize = true;
            yrdiscountamtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            yrdiscountamtLabel.Location = new System.Drawing.Point(807, 60);
            yrdiscountamtLabel.Name = "yrdiscountamtLabel";
            yrdiscountamtLabel.Size = new System.Drawing.Size(16, 13);
            yrdiscountamtLabel.TabIndex = 209;
            yrdiscountamtLabel.Text = "%";
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
            // speceaLabel
            // 
            speceaLabel.AutoSize = true;
            speceaLabel.Location = new System.Drawing.Point(17, 176);
            speceaLabel.Name = "speceaLabel";
            speceaLabel.Size = new System.Drawing.Size(98, 13);
            speceaLabel.TabIndex = 58;
            speceaLabel.Text = "Spec. Cvr. Ea. :";
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
            // inkclrLabel
            // 
            inkclrLabel.AutoSize = true;
            inkclrLabel.Location = new System.Drawing.Point(35, 107);
            inkclrLabel.Name = "inkclrLabel";
            inkclrLabel.Size = new System.Drawing.Size(80, 13);
            inkclrLabel.TabIndex = 50;
            inkclrLabel.Text = "# Ink Colors:";
            // 
            // extrchgLabel
            // 
            extrchgLabel.AutoSize = true;
            extrchgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            extrchgLabel.Location = new System.Drawing.Point(497, 290);
            extrchgLabel.Name = "extrchgLabel";
            extrchgLabel.Size = new System.Drawing.Size(90, 13);
            extrchgLabel.TabIndex = 260;
            extrchgLabel.Text = "Extra Charges:";
            // 
            // adjbefLabel
            // 
            adjbefLabel.AutoSize = true;
            adjbefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            adjbefLabel.Location = new System.Drawing.Point(694, 557);
            adjbefLabel.Name = "adjbefLabel";
            adjbefLabel.Size = new System.Drawing.Size(137, 13);
            adjbefLabel.TabIndex = 266;
            adjbefLabel.Text = "Total (Including Credit)";
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
            saletaxLabel.Location = new System.Drawing.Point(76, 619);
            saletaxLabel.Name = "saletaxLabel";
            saletaxLabel.Size = new System.Drawing.Size(125, 13);
            saletaxLabel.TabIndex = 267;
            saletaxLabel.Text = "Sales Tax Received:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label16.Location = new System.Drawing.Point(53, 647);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(65, 13);
            label16.TabIndex = 269;
            label16.Text = "Payments:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label18.Location = new System.Drawing.Point(44, 670);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(74, 13);
            label18.TabIndex = 270;
            label18.Text = "PO Amount:";
            // 
            // msstanqtyLabel
            // 
            msstanqtyLabel.AutoSize = true;
            msstanqtyLabel.Location = new System.Drawing.Point(294, 108);
            msstanqtyLabel.Name = "msstanqtyLabel";
            msstanqtyLabel.Size = new System.Drawing.Size(30, 13);
            msstanqtyLabel.TabIndex = 14;
            msstanqtyLabel.Text = "Qty:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(310, 84);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(16, 13);
            label13.TabIndex = 111;
            label13.Text = "%";
            // 
            // dp3descLabel
            // 
            dp3descLabel.AutoSize = true;
            dp3descLabel.Location = new System.Drawing.Point(69, 84);
            dp3descLabel.Name = "dp3descLabel";
            dp3descLabel.Size = new System.Drawing.Size(71, 13);
            dp3descLabel.TabIndex = 8;
            dp3descLabel.Text = "Other Disc:";
            // 
            // persamountLabel
            // 
            persamountLabel.AutoSize = true;
            persamountLabel.Location = new System.Drawing.Point(225, 129);
            persamountLabel.Name = "persamountLabel";
            persamountLabel.Size = new System.Drawing.Size(26, 13);
            persamountLabel.TabIndex = 19;
            persamountLabel.Text = "@$";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(310, 61);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(16, 13);
            label12.TabIndex = 107;
            label12.Text = "%";
            // 
            // perstotalLabel
            // 
            perstotalLabel.AutoSize = true;
            perstotalLabel.Location = new System.Drawing.Point(346, 129);
            perstotalLabel.Name = "perstotalLabel";
            perstotalLabel.Size = new System.Drawing.Size(40, 13);
            perstotalLabel.TabIndex = 21;
            perstotalLabel.Text = "Total:";
            // 
            // perscopiesLabel
            // 
            perscopiesLabel.AutoSize = true;
            perscopiesLabel.Location = new System.Drawing.Point(63, 129);
            perscopiesLabel.Name = "perscopiesLabel";
            perscopiesLabel.Size = new System.Drawing.Size(105, 13);
            perscopiesLabel.TabIndex = 17;
            perscopiesLabel.Text = "Personalization #";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(158, 175);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(94, 13);
            label15.TabIndex = 30;
            label15.Text = "#to persoanlize";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(310, 38);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(16, 13);
            label11.TabIndex = 101;
            label11.Text = "%";
            // 
            // fbkprcLabel
            // 
            fbkprcLabel.AutoSize = true;
            fbkprcLabel.Location = new System.Drawing.Point(51, 196);
            fbkprcLabel.Name = "fbkprcLabel";
            fbkprcLabel.Size = new System.Drawing.Size(104, 13);
            fbkprcLabel.TabIndex = 32;
            fbkprcLabel.Text = "Final Book Price:";
            // 
            // dp1Label
            // 
            dp1Label.AutoSize = true;
            dp1Label.Location = new System.Drawing.Point(69, 38);
            dp1Label.Name = "dp1Label";
            dp1Label.Size = new System.Drawing.Size(61, 13);
            dp1Label.TabIndex = 1;
            dp1Label.Text = "Discount:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(225, 151);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(26, 13);
            label21.TabIndex = 26;
            label21.Text = "@$";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(346, 151);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(40, 13);
            label20.TabIndex = 28;
            label20.Text = "Total:";
            // 
            // lblIconCopies
            // 
            lblIconCopies.AutoSize = true;
            lblIconCopies.Location = new System.Drawing.Point(120, 151);
            lblIconCopies.Name = "lblIconCopies";
            lblIconCopies.Size = new System.Drawing.Size(44, 13);
            lblIconCopies.TabIndex = 24;
            lblIconCopies.Text = "Icon #";
            // 
            // freebooksLabel
            // 
            freebooksLabel.AutoSize = true;
            freebooksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            freebooksLabel.Location = new System.Drawing.Point(262, 618);
            freebooksLabel.Name = "freebooksLabel";
            freebooksLabel.Size = new System.Drawing.Size(135, 13);
            freebooksLabel.TabIndex = 273;
            freebooksLabel.Text = "Free Additional Books:";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(1017, 31);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(41, 13);
            idLabel.TabIndex = 273;
            idLabel.Text = "Bid #:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label19.Location = new System.Drawing.Point(716, 515);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(115, 13);
            label19.TabIndex = 276;
            label19.Text = "Total Before Taxes";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label23.Location = new System.Drawing.Point(803, 535);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(28, 13);
            label23.TabIndex = 278;
            label23.Text = "Tax";
            // 
            // sbtotLabel
            // 
            sbtotLabel.AutoSize = true;
            sbtotLabel.Location = new System.Drawing.Point(395, 8);
            sbtotLabel.Name = "sbtotLabel";
            sbtotLabel.Size = new System.Drawing.Size(62, 13);
            sbtotLabel.TabIndex = 117;
            sbtotLabel.Text = "Sub Total";
            // 
            // custBindingSource
            // 
            this.custBindingSource.DataMember = "cust";
            this.custBindingSource.DataSource = this.dsBids;
            // 
            // dsBids
            // 
            this.dsBids.DataSetName = "dsBids";
            this.dsBids.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bidsBindingSource
            // 
            this.bidsBindingSource.AllowNew = true;
            this.bidsBindingSource.DataMember = "bids";
            this.bidsBindingSource.DataSource = this.dsBids;
            // 
            // BidInvoiceDetailBindingSource
            // 
            this.BidInvoiceDetailBindingSource.DataSource = typeof(BindingModels.BidInvoiceDetail);
            // 
            // bidsBindingNavigator
            // 
            this.bidsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bidsBindingNavigator.BindingSource = this.bidsBindingSource;
            this.bidsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bidsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bidsBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bidsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorDeleteItem,
            this.bidsBindingNavigatorSaveItem});
            this.bidsBindingNavigator.Location = new System.Drawing.Point(0, 736);
            this.bidsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bidsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bidsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bidsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bidsBindingNavigator.Name = "bidsBindingNavigator";
            this.bidsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bidsBindingNavigator.Size = new System.Drawing.Size(1264, 25);
            this.bidsBindingNavigator.TabIndex = 1;
            this.bidsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
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
            // bidsBindingNavigatorSaveItem
            // 
            this.bidsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bidsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bidsBindingNavigatorSaveItem.Image")));
            this.bidsBindingNavigatorSaveItem.Name = "bidsBindingNavigatorSaveItem";
            this.bidsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.bidsBindingNavigatorSaveItem.Text = "Save Data";
            this.bidsBindingNavigatorSaveItem.Click += new System.EventHandler(this.bidsBindingNavigatorSaveItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pgBids
            // 
            this.pgBids.AutoScroll = true;
            this.pgBids.BackColor = System.Drawing.SystemColors.Control;
            this.pgBids.Controls.Add(this.reportViewer1);
            this.pgBids.Controls.Add(this.btnPrntQuote);
            this.pgBids.Controls.Add(this.label10);
            this.pgBids.Controls.Add(this.schooltaxrateLabel1);
            this.pgBids.Controls.Add(this.lblfilnalsubtotal);
            this.pgBids.Controls.Add(this.donotchargeschoolsalestaxCheckBox);
            this.pgBids.Controls.Add(this.lblSalesTax);
            this.pgBids.Controls.Add(label23);
            this.pgBids.Controls.Add(label19);
            this.pgBids.Controls.Add(idLabel);
            this.pgBids.Controls.Add(this.lblId);
            this.pgBids.Controls.Add(freebooksLabel);
            this.pgBids.Controls.Add(this.txtfreebooks);
            this.pgBids.Controls.Add(this.txtPOAmt);
            this.pgBids.Controls.Add(this.txtPayments);
            this.pgBids.Controls.Add(this.txtExtChrg);
            this.pgBids.Controls.Add(this.txtPriceOverRide);
            this.pgBids.Controls.Add(this.txtSource);
            this.pgBids.Controls.Add(this.booktypeTextBox);
            this.pgBids.Controls.Add(this.txtNocopies);
            this.pgBids.Controls.Add(this.txtPoNum);
            this.pgBids.Controls.Add(this.txtBYear);
            this.pgBids.Controls.Add(this.txtYear);
            this.pgBids.Controls.Add(this.txtNoPages);
            this.pgBids.Controls.Add(this.pnlTot);
            this.pgBids.Controls.Add(this.lbladjbef);
            this.pgBids.Controls.Add(label18);
            this.pgBids.Controls.Add(label16);
            this.pgBids.Controls.Add(saletaxLabel);
            this.pgBids.Controls.Add(this.panel4);
            this.pgBids.Controls.Add(adjbefLabel);
            this.pgBids.Controls.Add(this.pnlMiscDiscCred);
            this.pgBids.Controls.Add(extrchgLabel);
            this.pgBids.Controls.Add(this.panel3);
            this.pgBids.Controls.Add(this.panel2);
            this.pgBids.Controls.Add(this.panel1);
            this.pgBids.Controls.Add(this.pnlHard);
            this.pgBids.Controls.Add(this.lblProftotalPrc);
            this.pgBids.Controls.Add(this.lblprofprice);
            this.pgBids.Controls.Add(this.lblPriceEach);
            this.pgBids.Controls.Add(this.lblBookTotal);
            this.pgBids.Controls.Add(yrdiscountamtLabel);
            this.pgBids.Controls.Add(this.cmbYrDiscountAmt);
            this.pgBids.Controls.Add(this.chkPromo);
            this.pgBids.Controls.Add(this.lblPCEach);
            this.pgBids.Controls.Add(this.lblPCTotal);
            this.pgBids.Controls.Add(this.label2);
            this.pgBids.Controls.Add(this.label1);
            this.pgBids.Controls.Add(prcorLabel);
            this.pgBids.Controls.Add(book_priceLabel);
            this.pgBids.Controls.Add(book_eaLabel);
            this.pgBids.Controls.Add(sourceLabel);
            this.pgBids.Controls.Add(booktypeLabel);
            this.pgBids.Controls.Add(nocopiesLabel);
            this.pgBids.Controls.Add(qtedateLabel);
            this.pgBids.Controls.Add(this.dteQuote);
            this.pgBids.Controls.Add(ponumLabel);
            this.pgBids.Controls.Add(bpyearLabel);
            this.pgBids.Controls.Add(contryearLabel);
            this.pgBids.Controls.Add(nopagesLabel);
            this.pgBids.Location = new System.Drawing.Point(4, 22);
            this.pgBids.Name = "pgBids";
            this.pgBids.Padding = new System.Windows.Forms.Padding(3);
            this.pgBids.Size = new System.Drawing.Size(1220, 705);
            this.pgBids.TabIndex = 0;
            this.pgBids.Text = "Bids";
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 98;
            reportDataSource4.Name = "dsCust";
            reportDataSource4.Value = this.custBindingSource;
            reportDataSource5.Name = "dsBidValues";
            reportDataSource5.Value = this.bidsBindingSource;
            reportDataSource6.Name = "detailbid";
            reportDataSource6.Value = this.BidInvoiceDetailBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.BidQuoteTest.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1034, 430);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(100, 231);
            this.reportViewer1.TabIndex = 286;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // btnPrntQuote
            // 
            this.btnPrntQuote.Location = new System.Drawing.Point(1020, 111);
            this.btnPrntQuote.Name = "btnPrntQuote";
            this.btnPrntQuote.Size = new System.Drawing.Size(100, 23);
            this.btnPrntQuote.TabIndex = 285;
            this.btnPrntQuote.Text = "Print Quote";
            this.btnPrntQuote.UseVisualStyleBackColor = true;
            this.btnPrntQuote.Click += new System.EventHandler(this.btnPrntQuote_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(755, 538);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 284;
            this.label10.Text = "%";
            // 
            // schooltaxrateLabel1
            // 
            this.schooltaxrateLabel1.AutoSize = true;
            this.schooltaxrateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "schooltaxrate", true));
            this.schooltaxrateLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schooltaxrateLabel1.Location = new System.Drawing.Point(717, 537);
            this.schooltaxrateLabel1.Name = "schooltaxrateLabel1";
            this.schooltaxrateLabel1.Size = new System.Drawing.Size(41, 13);
            this.schooltaxrateLabel1.TabIndex = 283;
            this.schooltaxrateLabel1.Text = "label10";
            // 
            // lblfilnalsubtotal
            // 
            this.lblfilnalsubtotal.AutoSize = true;
            this.lblfilnalsubtotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "subtotal", true));
            this.lblfilnalsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfilnalsubtotal.Location = new System.Drawing.Point(836, 515);
            this.lblfilnalsubtotal.Name = "lblfilnalsubtotal";
            this.lblfilnalsubtotal.Size = new System.Drawing.Size(41, 13);
            this.lblfilnalsubtotal.TabIndex = 282;
            this.lblfilnalsubtotal.Text = "label10";
            // 
            // donotchargeschoolsalestaxCheckBox
            // 
            this.donotchargeschoolsalestaxCheckBox.AutoSize = true;
            this.donotchargeschoolsalestaxCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "donotchargeschoolsalestax", true));
            this.donotchargeschoolsalestaxCheckBox.Location = new System.Drawing.Point(563, 537);
            this.donotchargeschoolsalestaxCheckBox.Name = "donotchargeschoolsalestaxCheckBox";
            this.donotchargeschoolsalestaxCheckBox.Size = new System.Drawing.Size(148, 17);
            this.donotchargeschoolsalestaxCheckBox.TabIndex = 281;
            this.donotchargeschoolsalestaxCheckBox.Text = "Do Not Calculate Tax";
            this.donotchargeschoolsalestaxCheckBox.UseVisualStyleBackColor = true;
            this.donotchargeschoolsalestaxCheckBox.CheckedChanged += new System.EventHandler(this.donotchargeschoolsalestaxCheckBox_CheckedChanged);
            // 
            // lblSalesTax
            // 
            this.lblSalesTax.AutoSize = true;
            this.lblSalesTax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "schooltax", true));
            this.lblSalesTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesTax.Location = new System.Drawing.Point(836, 535);
            this.lblSalesTax.Name = "lblSalesTax";
            this.lblSalesTax.Size = new System.Drawing.Size(41, 13);
            this.lblSalesTax.TabIndex = 279;
            this.lblSalesTax.Text = "label24";
            // 
            // lblId
            // 
            this.lblId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "Id", true));
            this.lblId.Location = new System.Drawing.Point(1060, 31);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(100, 20);
            this.lblId.TabIndex = 274;
            this.lblId.Text = "000";
            // 
            // txtfreebooks
            // 
            this.txtfreebooks.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "freebooks", true));
            this.txtfreebooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfreebooks.Location = new System.Drawing.Point(403, 618);
            this.txtfreebooks.Name = "txtfreebooks";
            this.txtfreebooks.Size = new System.Drawing.Size(71, 20);
            this.txtfreebooks.TabIndex = 271;
            // 
            // txtPOAmt
            // 
            this.txtPOAmt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPOAmt.BackColor = System.Drawing.Color.Aqua;
            this.txtPOAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPOAmt.Location = new System.Drawing.Point(125, 667);
            this.txtPOAmt.Name = "txtPOAmt";
            this.txtPOAmt.ReadOnly = true;
            this.txtPOAmt.Size = new System.Drawing.Size(0, 20);
            this.txtPOAmt.TabIndex = 265;
            // 
            // txtPayments
            // 
            this.txtPayments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPayments.BackColor = System.Drawing.Color.Aqua;
            this.txtPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayments.Location = new System.Drawing.Point(125, 644);
            this.txtPayments.Name = "txtPayments";
            this.txtPayments.ReadOnly = true;
            this.txtPayments.Size = new System.Drawing.Size(0, 20);
            this.txtPayments.TabIndex = 264;
            // 
            // txtExtChrg
            // 
            this.txtExtChrg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtChrg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "extrchg", true));
            this.txtExtChrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtChrg.Location = new System.Drawing.Point(589, 292);
            this.txtExtChrg.MaxLength = 100;
            this.txtExtChrg.Multiline = true;
            this.txtExtChrg.Name = "txtExtChrg";
            this.txtExtChrg.ReadOnly = true;
            this.txtExtChrg.Size = new System.Drawing.Size(172, 40);
            this.txtExtChrg.TabIndex = 259;
            // 
            // txtPriceOverRide
            // 
            this.txtPriceOverRide.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "prcor", true));
            this.txtPriceOverRide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceOverRide.Location = new System.Drawing.Point(509, 60);
            this.txtPriceOverRide.Name = "txtPriceOverRide";
            this.txtPriceOverRide.Size = new System.Drawing.Size(57, 20);
            this.txtPriceOverRide.TabIndex = 185;
            this.txtPriceOverRide.Leave += new System.EventHandler(this.txtPriceOverRide_Leave);
            // 
            // txtSource
            // 
            this.txtSource.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "source", true));
            this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(902, 31);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(100, 20);
            this.txtSource.TabIndex = 192;
            // 
            // booktypeTextBox
            // 
            this.booktypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "booktype", true));
            this.booktypeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.booktypeTextBox.Location = new System.Drawing.Point(108, 31);
            this.booktypeTextBox.MaxLength = 4;
            this.booktypeTextBox.Name = "booktypeTextBox";
            this.booktypeTextBox.Size = new System.Drawing.Size(44, 20);
            this.booktypeTextBox.TabIndex = 176;
            // 
            // txtNocopies
            // 
            this.txtNocopies.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "nocopies", true));
            this.txtNocopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNocopies.Location = new System.Drawing.Point(102, 60);
            this.txtNocopies.MaxLength = 5;
            this.txtNocopies.Name = "txtNocopies";
            this.txtNocopies.Size = new System.Drawing.Size(39, 20);
            this.txtNocopies.TabIndex = 180;
            this.txtNocopies.Leave += new System.EventHandler(this.txtNocopies_Leave);
            // 
            // txtPoNum
            // 
            this.txtPoNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "ponum", true));
            this.txtPoNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoNum.Location = new System.Drawing.Point(429, 31);
            this.txtPoNum.MaxLength = 25;
            this.txtPoNum.Name = "txtPoNum";
            this.txtPoNum.Size = new System.Drawing.Size(100, 20);
            this.txtPoNum.TabIndex = 178;
            // 
            // txtBYear
            // 
            this.txtBYear.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "bpyear", true));
            this.txtBYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBYear.Location = new System.Drawing.Point(343, 31);
            this.txtBYear.MaxLength = 2;
            this.txtBYear.Name = "txtBYear";
            this.txtBYear.Size = new System.Drawing.Size(31, 20);
            this.txtBYear.TabIndex = 175;
            this.txtBYear.Leave += new System.EventHandler(this.txtBYear_Leave);
            // 
            // txtYear
            // 
            this.txtYear.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "contryear", true));
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.Location = new System.Drawing.Point(193, 31);
            this.txtYear.MaxLength = 3;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(39, 20);
            this.txtYear.TabIndex = 179;
            // 
            // txtNoPages
            // 
            this.txtNoPages.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "nopages", true));
            this.txtNoPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoPages.Location = new System.Drawing.Point(193, 60);
            this.txtNoPages.MaxLength = 4;
            this.txtNoPages.Name = "txtNoPages";
            this.txtNoPages.Size = new System.Drawing.Size(37, 20);
            this.txtNoPages.TabIndex = 181;
            this.txtNoPages.Leave += new System.EventHandler(this.txtNoPages_Leave);
            // 
            // pnlTot
            // 
            this.pnlTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTot.Controls.Add(this.lblIconTot);
            this.pnlTot.Controls.Add(this.lblMsTot);
            this.pnlTot.Controls.Add(this.otherdiscamt);
            this.pnlTot.Controls.Add(this.lbldisc2amount);
            this.pnlTot.Controls.Add(this.lbldisc1amount);
            this.pnlTot.Controls.Add(sbtotLabel);
            this.pnlTot.Controls.Add(this.lblsubtot);
            this.pnlTot.Controls.Add(lblIconCopies);
            this.pnlTot.Controls.Add(this.txtIconCopies);
            this.pnlTot.Controls.Add(label20);
            this.pnlTot.Controls.Add(label21);
            this.pnlTot.Controls.Add(this.txtIconamt);
            this.pnlTot.Controls.Add(this.lblperstotal);
            this.pnlTot.Controls.Add(this.label14);
            this.pnlTot.Controls.Add(dp1Label);
            this.pnlTot.Controls.Add(this.txtDisc);
            this.pnlTot.Controls.Add(fbkprcLabel);
            this.pnlTot.Controls.Add(label11);
            this.pnlTot.Controls.Add(this.txtFinalbookprc);
            this.pnlTot.Controls.Add(this.dp1descComboBox);
            this.pnlTot.Controls.Add(label15);
            this.pnlTot.Controls.Add(this.txtNumtoPers);
            this.pnlTot.Controls.Add(perscopiesLabel);
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
            this.pnlTot.Location = new System.Drawing.Point(23, 390);
            this.pnlTot.Name = "pnlTot";
            this.pnlTot.Size = new System.Drawing.Size(520, 254);
            this.pnlTot.TabIndex = 272;
            // 
            // lblIconTot
            // 
            this.lblIconTot.AutoSize = true;
            this.lblIconTot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "icontotal", true));
            this.lblIconTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconTot.Location = new System.Drawing.Point(388, 151);
            this.lblIconTot.Name = "lblIconTot";
            this.lblIconTot.Size = new System.Drawing.Size(0, 13);
            this.lblIconTot.TabIndex = 125;
            // 
            // lblMsTot
            // 
            this.lblMsTot.AutoSize = true;
            this.lblMsTot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "msstandtot", true));
            this.lblMsTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsTot.Location = new System.Drawing.Point(389, 110);
            this.lblMsTot.Name = "lblMsTot";
            this.lblMsTot.Size = new System.Drawing.Size(41, 13);
            this.lblMsTot.TabIndex = 124;
            this.lblMsTot.Text = "label25";
            // 
            // otherdiscamt
            // 
            this.otherdiscamt.AutoSize = true;
            this.otherdiscamt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "disc3", true));
            this.otherdiscamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otherdiscamt.Location = new System.Drawing.Point(389, 88);
            this.otherdiscamt.Name = "otherdiscamt";
            this.otherdiscamt.Size = new System.Drawing.Size(41, 13);
            this.otherdiscamt.TabIndex = 122;
            this.otherdiscamt.Text = "label24";
            // 
            // lbldisc2amount
            // 
            this.lbldisc2amount.AutoSize = true;
            this.lbldisc2amount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "disc2", true));
            this.lbldisc2amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldisc2amount.Location = new System.Drawing.Point(389, 60);
            this.lbldisc2amount.Name = "lbldisc2amount";
            this.lbldisc2amount.Size = new System.Drawing.Size(41, 13);
            this.lbldisc2amount.TabIndex = 121;
            this.lbldisc2amount.Text = "label22";
            // 
            // lbldisc1amount
            // 
            this.lbldisc1amount.AutoSize = true;
            this.lbldisc1amount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "disc1", true));
            this.lbldisc1amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldisc1amount.Location = new System.Drawing.Point(389, 39);
            this.lbldisc1amount.Name = "lbldisc1amount";
            this.lbldisc1amount.Size = new System.Drawing.Size(41, 13);
            this.lbldisc1amount.TabIndex = 120;
            this.lbldisc1amount.Text = "label22";
            // 
            // lblsubtot
            // 
            this.lblsubtot.AutoSize = true;
            this.lblsubtot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "sbtot", true));
            this.lblsubtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtot.Location = new System.Drawing.Point(458, 8);
            this.lblsubtot.Name = "lblsubtot";
            this.lblsubtot.Size = new System.Drawing.Size(41, 13);
            this.lblsubtot.TabIndex = 118;
            this.lblsubtot.Text = "label10";
            // 
            // txtIconCopies
            // 
            this.txtIconCopies.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "iconcopies", true));
            this.txtIconCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIconCopies.Location = new System.Drawing.Point(171, 151);
            this.txtIconCopies.Name = "txtIconCopies";
            this.txtIconCopies.Size = new System.Drawing.Size(41, 20);
            this.txtIconCopies.TabIndex = 25;
            this.txtIconCopies.Leave += new System.EventHandler(this.txtIconCopies_Leave);
            // 
            // txtIconamt
            // 
            this.txtIconamt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "iconamt", true));
            this.txtIconamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIconamt.Location = new System.Drawing.Point(257, 151);
            this.txtIconamt.Name = "txtIconamt";
            this.txtIconamt.Size = new System.Drawing.Size(56, 20);
            this.txtIconamt.TabIndex = 27;
            this.txtIconamt.Leave += new System.EventHandler(this.txtIconamt_Leave);
            // 
            // lblperstotal
            // 
            this.lblperstotal.AutoSize = true;
            this.lblperstotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "perstotal", true));
            this.lblperstotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblperstotal.Location = new System.Drawing.Point(389, 130);
            this.lblperstotal.Name = "lblperstotal";
            this.lblperstotal.Size = new System.Drawing.Size(0, 13);
            this.lblperstotal.TabIndex = 22;
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
            // txtDisc
            // 
            this.txtDisc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "dp1", true));
            this.txtDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisc.Location = new System.Drawing.Point(329, 38);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.Size = new System.Drawing.Size(57, 20);
            this.txtDisc.TabIndex = 3;
            this.txtDisc.Leave += new System.EventHandler(this.txtDisc_Leave);
            // 
            // txtFinalbookprc
            // 
            this.txtFinalbookprc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "fbkprc", true));
            this.txtFinalbookprc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinalbookprc.ForeColor = System.Drawing.Color.Red;
            this.txtFinalbookprc.Location = new System.Drawing.Point(161, 196);
            this.txtFinalbookprc.Name = "txtFinalbookprc";
            this.txtFinalbookprc.ReadOnly = true;
            this.txtFinalbookprc.Size = new System.Drawing.Size(65, 20);
            this.txtFinalbookprc.TabIndex = 33;
            // 
            // dp1descComboBox
            // 
            this.dp1descComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "dp1desc", true));
            this.dp1descComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dp1descComboBox.FormattingEnabled = true;
            this.dp1descComboBox.Items.AddRange(new object[] {
            "test"});
            this.dp1descComboBox.Location = new System.Drawing.Point(134, 38);
            this.dp1descComboBox.Name = "dp1descComboBox";
            this.dp1descComboBox.Size = new System.Drawing.Size(121, 21);
            this.dp1descComboBox.TabIndex = 2;
            // 
            // txtNumtoPers
            // 
            this.txtNumtoPers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumtoPers.Location = new System.Drawing.Point(257, 175);
            this.txtNumtoPers.Name = "txtNumtoPers";
            this.txtNumtoPers.Size = new System.Drawing.Size(56, 20);
            this.txtNumtoPers.TabIndex = 31;
            // 
            // perscopiesTextBox
            // 
            this.perscopiesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "perscopies", true));
            this.perscopiesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perscopiesTextBox.Location = new System.Drawing.Point(171, 129);
            this.perscopiesTextBox.Name = "perscopiesTextBox";
            this.perscopiesTextBox.Size = new System.Drawing.Size(41, 20);
            this.perscopiesTextBox.TabIndex = 18;
            this.perscopiesTextBox.TextChanged += new System.EventHandler(this.perscopiesTextBox_TextChanged);
            this.perscopiesTextBox.Leave += new System.EventHandler(this.perscopiesTextBox_Leave);
            // 
            // chkDc2
            // 
            this.chkDc2.AutoSize = true;
            this.chkDc2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "dc2", true));
            this.chkDc2.Location = new System.Drawing.Point(69, 61);
            this.chkDc2.Name = "chkDc2";
            this.chkDc2.Size = new System.Drawing.Size(182, 17);
            this.chkDc2.TabIndex = 5;
            this.chkDc2.Text = "Full pay w/page submission";
            this.chkDc2.UseVisualStyleBackColor = true;
            this.chkDc2.CheckedChanged += new System.EventHandler(this.chkDc2_CheckedChanged);
            this.chkDc2.Click += new System.EventHandler(this.chkDc2_Click);
            // 
            // txtDp2
            // 
            this.txtDp2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "dp2", true));
            this.txtDp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDp2.Location = new System.Drawing.Point(329, 61);
            this.txtDp2.Name = "txtDp2";
            this.txtDp2.Size = new System.Drawing.Size(57, 20);
            this.txtDp2.TabIndex = 6;
            this.txtDp2.Leave += new System.EventHandler(this.txtDp2_Leave);
            // 
            // persamountTextBox
            // 
            this.persamountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "perstotal", true));
            this.persamountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.persamountTextBox.Location = new System.Drawing.Point(257, 129);
            this.persamountTextBox.Name = "persamountTextBox";
            this.persamountTextBox.Size = new System.Drawing.Size(56, 20);
            this.persamountTextBox.TabIndex = 20;
            this.persamountTextBox.Leave += new System.EventHandler(this.persamountTextBox_Leave);
            // 
            // txtDp3Desc
            // 
            this.txtDp3Desc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "dp3desc", true));
            this.txtDp3Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDp3Desc.Location = new System.Drawing.Point(146, 84);
            this.txtDp3Desc.MaxLength = 40;
            this.txtDp3Desc.Name = "txtDp3Desc";
            this.txtDp3Desc.Size = new System.Drawing.Size(79, 20);
            this.txtDp3Desc.TabIndex = 9;
            // 
            // dp3ComboBox
            // 
            this.dp3ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "dp3", true));
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
            this.dp3ComboBox.Location = new System.Drawing.Point(328, 84);
            this.dp3ComboBox.Name = "dp3ComboBox";
            this.dp3ComboBox.Size = new System.Drawing.Size(58, 21);
            this.dp3ComboBox.TabIndex = 10;
            this.dp3ComboBox.Leave += new System.EventHandler(this.dp3ComboBox_Leave);
            // 
            // chkMsStandard
            // 
            this.chkMsStandard.AutoSize = true;
            this.chkMsStandard.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "foilck", true));
            this.chkMsStandard.Location = new System.Drawing.Point(69, 106);
            this.chkMsStandard.Name = "chkMsStandard";
            this.chkMsStandard.Size = new System.Drawing.Size(127, 17);
            this.chkMsStandard.TabIndex = 12;
            this.chkMsStandard.Text = "MS/Stan with/Pic";
            this.chkMsStandard.UseVisualStyleBackColor = true;
            this.chkMsStandard.CheckedChanged += new System.EventHandler(this.chkMsStandard_CheckedChanged);
            // 
            // txtMsQty
            // 
            this.txtMsQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "msstanqty", true));
            this.txtMsQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsQty.Location = new System.Drawing.Point(327, 106);
            this.txtMsQty.Name = "txtMsQty";
            this.txtMsQty.Size = new System.Drawing.Size(58, 20);
            this.txtMsQty.TabIndex = 15;
            this.txtMsQty.Leave += new System.EventHandler(this.txtMsQty_Leave);
            // 
            // foilamtTextBox
            // 
            this.foilamtTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "foilamt", true));
            this.foilamtTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foilamtTextBox.Location = new System.Drawing.Point(202, 106);
            this.foilamtTextBox.Name = "foilamtTextBox";
            this.foilamtTextBox.Size = new System.Drawing.Size(83, 20);
            this.foilamtTextBox.TabIndex = 13;
            this.foilamtTextBox.Leave += new System.EventHandler(this.foilamtTextBox_Leave);
            // 
            // lbladjbef
            // 
            this.lbladjbef.AutoSize = true;
            this.lbladjbef.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "adjbef", true));
            this.lbladjbef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladjbef.Location = new System.Drawing.Point(836, 557);
            this.lbladjbef.Name = "lbladjbef";
            this.lbladjbef.Size = new System.Drawing.Size(41, 13);
            this.lbladjbef.TabIndex = 262;
            this.lbladjbef.Text = "label21";
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
            this.panel4.Location = new System.Drawing.Point(549, 390);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(222, 119);
            this.panel4.TabIndex = 268;
            // 
            // txtOtherChrg
            // 
            this.txtOtherChrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOtherChrg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "desc2tot", true));
            this.txtOtherChrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherChrg.Location = new System.Drawing.Point(236, 56);
            this.txtOtherChrg.Name = "txtOtherChrg";
            this.txtOtherChrg.Size = new System.Drawing.Size(70, 20);
            this.txtOtherChrg.TabIndex = 5;
            this.txtOtherChrg.Leave += new System.EventHandler(this.txtOtherChrg_Leave);
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "desc2", true));
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(88, 56);
            this.textBox5.MaxLength = 40;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(142, 20);
            this.textBox5.TabIndex = 4;
            // 
            // txtOtherChrg2
            // 
            this.txtOtherChrg2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOtherChrg2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "desc22tot", true));
            this.txtOtherChrg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherChrg2.Location = new System.Drawing.Point(236, 78);
            this.txtOtherChrg2.Name = "txtOtherChrg2";
            this.txtOtherChrg2.Size = new System.Drawing.Size(70, 20);
            this.txtOtherChrg2.TabIndex = 7;
            this.txtOtherChrg2.Leave += new System.EventHandler(this.txtOtherChrg2_Leave);
            // 
            // desc22TextBox
            // 
            this.desc22TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.desc22TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "desc22", true));
            this.desc22TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc22TextBox.Location = new System.Drawing.Point(88, 78);
            this.desc22TextBox.MaxLength = 40;
            this.desc22TextBox.Name = "desc22TextBox";
            this.desc22TextBox.Size = new System.Drawing.Size(142, 20);
            this.desc22TextBox.TabIndex = 6;
            // 
            // txtCredits2
            // 
            this.txtCredits2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredits2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "adjaftr2", true));
            this.txtCredits2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredits2.Location = new System.Drawing.Point(236, 33);
            this.txtCredits2.Name = "txtCredits2";
            this.txtCredits2.Size = new System.Drawing.Size(70, 20);
            this.txtCredits2.TabIndex = 3;
            this.txtCredits2.Leave += new System.EventHandler(this.txtCredits2_Leave);
            // 
            // cred_etcTextBox
            // 
            this.cred_etcTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cred_etcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "cred_etc", true));
            this.cred_etcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cred_etcTextBox.Location = new System.Drawing.Point(88, 10);
            this.cred_etcTextBox.MaxLength = 40;
            this.cred_etcTextBox.Name = "cred_etcTextBox";
            this.cred_etcTextBox.Size = new System.Drawing.Size(142, 20);
            this.cred_etcTextBox.TabIndex = 0;
            // 
            // cred_etcTextBox1
            // 
            this.cred_etcTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cred_etcTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "cred_etc2", true));
            this.cred_etcTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cred_etcTextBox1.Location = new System.Drawing.Point(88, 33);
            this.cred_etcTextBox1.MaxLength = 40;
            this.cred_etcTextBox1.Name = "cred_etcTextBox1";
            this.cred_etcTextBox1.Size = new System.Drawing.Size(142, 20);
            this.cred_etcTextBox1.TabIndex = 2;
            // 
            // txtCredits
            // 
            this.txtCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredits.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "adjaftr", true));
            this.txtCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredits.Location = new System.Drawing.Point(236, 10);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.Size = new System.Drawing.Size(70, 20);
            this.txtCredits.TabIndex = 1;
            this.txtCredits.Leave += new System.EventHandler(this.txtCredits_Leave);
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
            this.pnlMiscDiscCred.Location = new System.Drawing.Point(520, 111);
            this.pnlMiscDiscCred.Name = "pnlMiscDiscCred";
            this.pnlMiscDiscCred.Size = new System.Drawing.Size(241, 175);
            this.pnlMiscDiscCred.TabIndex = 261;
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
            this.txtClrDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "clrpgdesc", true));
            this.txtClrDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClrDesc.Location = new System.Drawing.Point(7, 32);
            this.txtClrDesc.MaxLength = 40;
            this.txtClrDesc.Name = "txtClrDesc";
            this.txtClrDesc.Size = new System.Drawing.Size(265, 20);
            this.txtClrDesc.TabIndex = 0;
            // 
            // txtClrTot
            // 
            this.txtClrTot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClrTot.BackColor = System.Drawing.Color.Aqua;
            this.txtClrTot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "clrpgtot", true));
            this.txtClrTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClrTot.Location = new System.Drawing.Point(276, 32);
            this.txtClrTot.Name = "txtClrTot";
            this.txtClrTot.Size = new System.Drawing.Size(53, 20);
            this.txtClrTot.TabIndex = 1;
            this.txtClrTot.Leave += new System.EventHandler(this.txtClrTot_Leave);
            // 
            // txtMisc
            // 
            this.txtMisc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMisc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "misc", true));
            this.txtMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMisc.Location = new System.Drawing.Point(276, 55);
            this.txtMisc.Name = "txtMisc";
            this.txtMisc.Size = new System.Drawing.Size(53, 20);
            this.txtMisc.TabIndex = 3;
            this.txtMisc.Leave += new System.EventHandler(this.txtMisc_Leave);
            // 
            // txtMdesc
            // 
            this.txtMdesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMdesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "mdesc", true));
            this.txtMdesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMdesc.Location = new System.Drawing.Point(7, 55);
            this.txtMdesc.MaxLength = 40;
            this.txtMdesc.Name = "txtMdesc";
            this.txtMdesc.Size = new System.Drawing.Size(265, 20);
            this.txtMdesc.TabIndex = 2;
            // 
            // txtDesc1amt
            // 
            this.txtDesc1amt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc1amt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "desc1tot", true));
            this.txtDesc1amt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc1amt.Location = new System.Drawing.Point(276, 78);
            this.txtDesc1amt.Name = "txtDesc1amt";
            this.txtDesc1amt.Size = new System.Drawing.Size(53, 20);
            this.txtDesc1amt.TabIndex = 5;
            this.txtDesc1amt.Leave += new System.EventHandler(this.txtDesc1amt_Leave);
            // 
            // txtDesc1
            // 
            this.txtDesc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "desc1", true));
            this.txtDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc1.Location = new System.Drawing.Point(7, 78);
            this.txtDesc1.MaxLength = 40;
            this.txtDesc1.Name = "txtDesc1";
            this.txtDesc1.Size = new System.Drawing.Size(265, 20);
            this.txtDesc1.TabIndex = 4;
            // 
            // txtDesc3tot
            // 
            this.txtDesc3tot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc3tot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "desc3tot", true));
            this.txtDesc3tot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc3tot.Location = new System.Drawing.Point(276, 101);
            this.txtDesc3tot.Name = "txtDesc3tot";
            this.txtDesc3tot.Size = new System.Drawing.Size(53, 20);
            this.txtDesc3tot.TabIndex = 7;
            this.txtDesc3tot.Leave += new System.EventHandler(this.txtDesc3tot_Leave);
            // 
            // txtDesc3
            // 
            this.txtDesc3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "desc3", true));
            this.txtDesc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc3.Location = new System.Drawing.Point(7, 101);
            this.txtDesc3.MaxLength = 40;
            this.txtDesc3.Name = "txtDesc3";
            this.txtDesc3.Size = new System.Drawing.Size(265, 20);
            this.txtDesc3.TabIndex = 6;
            // 
            // txtDesc4tot
            // 
            this.txtDesc4tot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc4tot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "desc4tot", true));
            this.txtDesc4tot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc4tot.Location = new System.Drawing.Point(276, 125);
            this.txtDesc4tot.Name = "txtDesc4tot";
            this.txtDesc4tot.Size = new System.Drawing.Size(53, 20);
            this.txtDesc4tot.TabIndex = 9;
            this.txtDesc4tot.Leave += new System.EventHandler(this.txtDesc4tot_Leave);
            // 
            // txtDesc4
            // 
            this.txtDesc4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "desc4", true));
            this.txtDesc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc4.Location = new System.Drawing.Point(7, 125);
            this.txtDesc4.MaxLength = 40;
            this.txtDesc4.Name = "txtDesc4";
            this.txtDesc4.Size = new System.Drawing.Size(265, 20);
            this.txtDesc4.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.allclramtTextBox);
            this.panel3.Controls.Add(this.lblSpeccvrtot);
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
            this.panel3.Location = new System.Drawing.Point(290, 111);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(201, 262);
            this.panel3.TabIndex = 258;
            // 
            // allclramtTextBox
            // 
            this.allclramtTextBox.Location = new System.Drawing.Point(121, 14);
            this.allclramtTextBox.Name = "allclramtTextBox";
            this.allclramtTextBox.Size = new System.Drawing.Size(55, 20);
            this.allclramtTextBox.TabIndex = 165;
            // 
            // lblSpeccvrtot
            // 
            this.lblSpeccvrtot.AutoSize = true;
            this.lblSpeccvrtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeccvrtot.Location = new System.Drawing.Point(125, 201);
            this.lblSpeccvrtot.Name = "lblSpeccvrtot";
            this.lblSpeccvrtot.Size = new System.Drawing.Size(0, 13);
            this.lblSpeccvrtot.TabIndex = 6;
            // 
            // chkAllClr
            // 
            this.chkAllClr.AutoSize = true;
            this.chkAllClr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllClr.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "allclrck", true));
            this.chkAllClr.Location = new System.Drawing.Point(42, 17);
            this.chkAllClr.Name = "chkAllClr";
            this.chkAllClr.Size = new System.Drawing.Size(73, 17);
            this.chkAllClr.TabIndex = 0;
            this.chkAllClr.Text = "All Color";
            this.chkAllClr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllClr.UseVisualStyleBackColor = true;
            this.chkAllClr.CheckedChanged += new System.EventHandler(this.chkAllClr_CheckedChanged);
            // 
            // lblMLaminateAmt
            // 
            this.lblMLaminateAmt.AutoSize = true;
            this.lblMLaminateAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMLaminateAmt.Location = new System.Drawing.Point(119, 84);
            this.lblMLaminateAmt.Name = "lblMLaminateAmt";
            this.lblMLaminateAmt.Size = new System.Drawing.Size(0, 13);
            this.lblMLaminateAmt.TabIndex = 164;
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
            this.lblLaminateAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaminateAmt.Location = new System.Drawing.Point(121, 66);
            this.lblLaminateAmt.Name = "lblLaminateAmt";
            this.lblLaminateAmt.Size = new System.Drawing.Size(0, 13);
            this.lblLaminateAmt.TabIndex = 162;
            // 
            // txtnoClrPgs
            // 
            this.txtnoClrPgs.BackColor = System.Drawing.Color.Aqua;
            this.txtnoClrPgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnoClrPgs.Location = new System.Drawing.Point(122, 39);
            this.txtnoClrPgs.Name = "txtnoClrPgs";
            this.txtnoClrPgs.Size = new System.Drawing.Size(53, 20);
            this.txtnoClrPgs.TabIndex = 1;
            // 
            // chkGlossLam
            // 
            this.chkGlossLam.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkGlossLam.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "layn", true));
            this.chkGlossLam.Location = new System.Drawing.Point(11, 61);
            this.chkGlossLam.Name = "chkGlossLam";
            this.chkGlossLam.Size = new System.Drawing.Size(104, 24);
            this.chkGlossLam.TabIndex = 2;
            this.chkGlossLam.Text = "Gloss Laminate";
            this.chkGlossLam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkGlossLam.UseVisualStyleBackColor = true;
            this.chkGlossLam.CheckedChanged += new System.EventHandler(this.chkGlossLam_CheckedChanged);
            // 
            // chkMLaminate
            // 
            this.chkMLaminate.AutoSize = true;
            this.chkMLaminate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMLaminate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "mlamination", true));
            this.chkMLaminate.Location = new System.Drawing.Point(2, 84);
            this.chkMLaminate.Name = "chkMLaminate";
            this.chkMLaminate.Size = new System.Drawing.Size(113, 17);
            this.chkMLaminate.TabIndex = 3;
            this.chkMLaminate.Text = "Matte Laminate";
            this.chkMLaminate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMLaminate.UseVisualStyleBackColor = true;
            this.chkMLaminate.CheckedChanged += new System.EventHandler(this.chkMLaminate_CheckedChanged);
            // 
            // inkclrComboBox
            // 
            this.inkclrComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "inkclr", true));
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
            this.txtCoverDesc.TabIndex = 4;
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
            this.txtSpecCvrEa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "specea", true));
            this.txtSpecCvrEa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecCvrEa.Location = new System.Drawing.Point(122, 176);
            this.txtSpecCvrEa.Name = "txtSpecCvrEa";
            this.txtSpecCvrEa.Size = new System.Drawing.Size(53, 20);
            this.txtSpecCvrEa.TabIndex = 5;
            // 
            // txtFoilAd
            // 
            this.txtFoilAd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "foiladamt", true));
            this.txtFoilAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFoilAd.Location = new System.Drawing.Point(122, 220);
            this.txtFoilAd.Name = "txtFoilAd";
            this.txtFoilAd.Size = new System.Drawing.Size(53, 20);
            this.txtFoilAd.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblYir);
            this.panel2.Controls.Add(this.lblConvAmt);
            this.panel2.Controls.Add(this.lblProfAmt);
            this.panel2.Controls.Add(this.chkProfessional);
            this.panel2.Controls.Add(this.chkConv);
            this.panel2.Controls.Add(this.chkYir);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(25, 276);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 85);
            this.panel2.TabIndex = 257;
            // 
            // lblYir
            // 
            this.lblYir.AutoSize = true;
            this.lblYir.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "insamt", true));
            this.lblYir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYir.Location = new System.Drawing.Point(152, 52);
            this.lblYir.Name = "lblYir";
            this.lblYir.Size = new System.Drawing.Size(28, 13);
            this.lblYir.TabIndex = 160;
            this.lblYir.Text = "0.00";
            // 
            // lblConvAmt
            // 
            this.lblConvAmt.AutoSize = true;
            this.lblConvAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "conven", true));
            this.lblConvAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvAmt.Location = new System.Drawing.Point(152, 33);
            this.lblConvAmt.Name = "lblConvAmt";
            this.lblConvAmt.Size = new System.Drawing.Size(28, 13);
            this.lblConvAmt.TabIndex = 158;
            this.lblConvAmt.Text = "0.00";
            // 
            // lblProfAmt
            // 
            this.lblProfAmt.AutoSize = true;
            this.lblProfAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "prof", true));
            this.lblProfAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfAmt.Location = new System.Drawing.Point(152, 11);
            this.lblProfAmt.Name = "lblProfAmt";
            this.lblProfAmt.Size = new System.Drawing.Size(28, 13);
            this.lblProfAmt.TabIndex = 159;
            this.lblProfAmt.Text = "0.00";
            // 
            // chkProfessional
            // 
            this.chkProfessional.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkProfessional.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "pryn", true));
            this.chkProfessional.Location = new System.Drawing.Point(44, 9);
            this.chkProfessional.Name = "chkProfessional";
            this.chkProfessional.Size = new System.Drawing.Size(104, 17);
            this.chkProfessional.TabIndex = 0;
            this.chkProfessional.Text = "Professional";
            this.chkProfessional.UseVisualStyleBackColor = true;
            this.chkProfessional.Click += new System.EventHandler(this.chkProfessional_Click);
            // 
            // chkConv
            // 
            this.chkConv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkConv.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "coyn", true));
            this.chkConv.Location = new System.Drawing.Point(44, 27);
            this.chkConv.Name = "chkConv";
            this.chkConv.Size = new System.Drawing.Size(104, 24);
            this.chkConv.TabIndex = 1;
            this.chkConv.Text = "Convenient";
            this.chkConv.UseVisualStyleBackColor = true;
            this.chkConv.Click += new System.EventHandler(this.chkConv_Click);
            // 
            // chkYir
            // 
            this.chkYir.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkYir.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "insck", true));
            this.chkYir.Location = new System.Drawing.Point(44, 52);
            this.chkYir.Name = "chkYir";
            this.chkYir.Size = new System.Drawing.Size(104, 18);
            this.chkYir.TabIndex = 2;
            this.chkYir.Text = "Flashbax";
            this.chkYir.UseVisualStyleBackColor = true;
            this.chkYir.Click += new System.EventHandler(this.chkYir_Click);
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
            this.panel1.Location = new System.Drawing.Point(24, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 82);
            this.panel1.TabIndex = 254;
            // 
            // lblSaddleAmt
            // 
            this.lblSaddleAmt.AutoSize = true;
            this.lblSaddleAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "sdlstichamt", true));
            this.lblSaddleAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaddleAmt.Location = new System.Drawing.Point(153, 58);
            this.lblSaddleAmt.Name = "lblSaddleAmt";
            this.lblSaddleAmt.Size = new System.Drawing.Size(28, 13);
            this.lblSaddleAmt.TabIndex = 160;
            this.lblSaddleAmt.Text = "0.00";
            // 
            // lblSpiralAmt
            // 
            this.lblSpiralAmt.AutoSize = true;
            this.lblSpiralAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "spiramt", true));
            this.lblSpiralAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpiralAmt.Location = new System.Drawing.Point(153, 39);
            this.lblSpiralAmt.Name = "lblSpiralAmt";
            this.lblSpiralAmt.Size = new System.Drawing.Size(28, 13);
            this.lblSpiralAmt.TabIndex = 161;
            this.lblSpiralAmt.Text = "0.00";
            // 
            // lblPerfbindAmt
            // 
            this.lblPerfbindAmt.AutoSize = true;
            this.lblPerfbindAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "perfbind", true));
            this.lblPerfbindAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfbindAmt.Location = new System.Drawing.Point(153, 21);
            this.lblPerfbindAmt.Name = "lblPerfbindAmt";
            this.lblPerfbindAmt.Size = new System.Drawing.Size(28, 13);
            this.lblPerfbindAmt.TabIndex = 162;
            this.lblPerfbindAmt.Text = "0.00";
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
            this.chkPerfBind.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "peyn", true));
            this.chkPerfBind.Location = new System.Drawing.Point(27, 19);
            this.chkPerfBind.Name = "chkPerfBind";
            this.chkPerfBind.Size = new System.Drawing.Size(122, 17);
            this.chkPerfBind.TabIndex = 0;
            this.chkPerfBind.Text = "Perfect Bind (40)";
            this.chkPerfBind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPerfBind.UseVisualStyleBackColor = true;
            this.chkPerfBind.Click += new System.EventHandler(this.chkPerfBind_Click);
            // 
            // chkSpiral
            // 
            this.chkSpiral.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSpiral.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "spirck", true));
            this.chkSpiral.Location = new System.Drawing.Point(45, 37);
            this.chkSpiral.Name = "chkSpiral";
            this.chkSpiral.Size = new System.Drawing.Size(104, 17);
            this.chkSpiral.TabIndex = 1;
            this.chkSpiral.Text = "Spiral";
            this.chkSpiral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSpiral.UseVisualStyleBackColor = true;
            this.chkSpiral.Click += new System.EventHandler(this.chkSpiral_Click);
            // 
            // chkSaddlStitch
            // 
            this.chkSaddlStitch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSaddlStitch.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "sdlstich", true));
            this.chkSaddlStitch.Location = new System.Drawing.Point(45, 56);
            this.chkSaddlStitch.Name = "chkSaddlStitch";
            this.chkSaddlStitch.Size = new System.Drawing.Size(104, 17);
            this.chkSaddlStitch.TabIndex = 2;
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
            this.pnlHard.Location = new System.Drawing.Point(25, 111);
            this.pnlHard.Name = "pnlHard";
            this.pnlHard.Size = new System.Drawing.Size(248, 73);
            this.pnlHard.TabIndex = 253;
            // 
            // lblCaseamt
            // 
            this.lblCaseamt.AutoSize = true;
            this.lblCaseamt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "caseamt", true));
            this.lblCaseamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaseamt.Location = new System.Drawing.Point(152, 44);
            this.lblCaseamt.Name = "lblCaseamt";
            this.lblCaseamt.Size = new System.Drawing.Size(28, 13);
            this.lblCaseamt.TabIndex = 163;
            this.lblCaseamt.Text = "0.00";
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
            this.chkHardBack.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "hdbky_n", true));
            this.chkHardBack.Location = new System.Drawing.Point(4, 23);
            this.chkHardBack.Name = "chkHardBack";
            this.chkHardBack.Size = new System.Drawing.Size(145, 17);
            this.chkHardBack.TabIndex = 0;
            this.chkHardBack.Text = "Hard Back (sewn 40)";
            this.chkHardBack.UseVisualStyleBackColor = true;
            this.chkHardBack.Click += new System.EventHandler(this.chkHardBack_Click);
            // 
            // chkCaseBind
            // 
            this.chkCaseBind.AutoSize = true;
            this.chkCaseBind.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCaseBind.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "casey_n", true));
            this.chkCaseBind.Location = new System.Drawing.Point(5, 42);
            this.chkCaseBind.Name = "chkCaseBind";
            this.chkCaseBind.Size = new System.Drawing.Size(144, 17);
            this.chkCaseBind.TabIndex = 1;
            this.chkCaseBind.Text = "Case Bind (glued 32)";
            this.chkCaseBind.UseVisualStyleBackColor = true;
            this.chkCaseBind.CheckedChanged += new System.EventHandler(this.chkCaseBind_CheckedChanged);
            // 
            // lblHardbackAmt
            // 
            this.lblHardbackAmt.AutoSize = true;
            this.lblHardbackAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "hardback", true));
            this.lblHardbackAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHardbackAmt.Location = new System.Drawing.Point(152, 25);
            this.lblHardbackAmt.Name = "lblHardbackAmt";
            this.lblHardbackAmt.Size = new System.Drawing.Size(28, 13);
            this.lblHardbackAmt.TabIndex = 157;
            this.lblHardbackAmt.Text = "0.00";
            // 
            // lblProftotalPrc
            // 
            this.lblProftotalPrc.AutoSize = true;
            this.lblProftotalPrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProftotalPrc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblProftotalPrc.Location = new System.Drawing.Point(680, 87);
            this.lblProftotalPrc.Name = "lblProftotalPrc";
            this.lblProftotalPrc.Size = new System.Drawing.Size(32, 13);
            this.lblProftotalPrc.TabIndex = 235;
            this.lblProftotalPrc.Text = "0.00";
            // 
            // lblprofprice
            // 
            this.lblprofprice.AutoSize = true;
            this.lblprofprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprofprice.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblprofprice.Location = new System.Drawing.Point(328, 87);
            this.lblprofprice.Name = "lblprofprice";
            this.lblprofprice.Size = new System.Drawing.Size(32, 13);
            this.lblprofprice.TabIndex = 193;
            this.lblprofprice.Text = "0.00";
            // 
            // lblPriceEach
            // 
            this.lblPriceEach.AutoSize = true;
            this.lblPriceEach.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "book_ea", true));
            this.lblPriceEach.Location = new System.Drawing.Point(326, 60);
            this.lblPriceEach.Name = "lblPriceEach";
            this.lblPriceEach.Size = new System.Drawing.Size(32, 13);
            this.lblPriceEach.TabIndex = 183;
            this.lblPriceEach.Text = "0.00";
            // 
            // lblBookTotal
            // 
            this.lblBookTotal.AutoSize = true;
            this.lblBookTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bidsBindingSource, "book_price", true));
            this.lblBookTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookTotal.Location = new System.Drawing.Point(680, 60);
            this.lblBookTotal.Name = "lblBookTotal";
            this.lblBookTotal.Size = new System.Drawing.Size(28, 13);
            this.lblBookTotal.TabIndex = 186;
            this.lblBookTotal.Text = "0.00";
            // 
            // cmbYrDiscountAmt
            // 
            this.cmbYrDiscountAmt.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bidsBindingSource, "yrdiscountamt", true));
            this.cmbYrDiscountAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYrDiscountAmt.FormattingEnabled = true;
            this.cmbYrDiscountAmt.Items.AddRange(new object[] {
            "",
            ".4025",
            ".3920"});
            this.cmbYrDiscountAmt.Location = new System.Drawing.Point(829, 60);
            this.cmbYrDiscountAmt.Name = "cmbYrDiscountAmt";
            this.cmbYrDiscountAmt.Size = new System.Drawing.Size(79, 21);
            this.cmbYrDiscountAmt.TabIndex = 187;
            this.cmbYrDiscountAmt.SelectedIndexChanged += new System.EventHandler(this.cmbYrDiscountAmt_SelectedIndexChanged);
            // 
            // chkPromo
            // 
            this.chkPromo.AutoSize = true;
            this.chkPromo.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bidsBindingSource, "yrdiscount", true));
            this.chkPromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPromo.Location = new System.Drawing.Point(748, 60);
            this.chkPromo.Name = "chkPromo";
            this.chkPromo.Size = new System.Drawing.Size(61, 17);
            this.chkPromo.TabIndex = 208;
            this.chkPromo.Text = "Promo";
            this.chkPromo.UseVisualStyleBackColor = true;
            this.chkPromo.Click += new System.EventHandler(this.chkPromo_Click);
            // 
            // lblPCEach
            // 
            this.lblPCEach.AutoSize = true;
            this.lblPCEach.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPCEach.Location = new System.Drawing.Point(332, 87);
            this.lblPCEach.Name = "lblPCEach";
            this.lblPCEach.Size = new System.Drawing.Size(0, 13);
            this.lblPCEach.TabIndex = 217;
            // 
            // lblPCTotal
            // 
            this.lblPCTotal.AutoSize = true;
            this.lblPCTotal.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPCTotal.Location = new System.Drawing.Point(681, 87);
            this.lblPCTotal.Name = "lblPCTotal";
            this.lblPCTotal.Size = new System.Drawing.Size(0, 13);
            this.lblPCTotal.TabIndex = 216;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(579, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 215;
            this.label2.Text = "Total Prof/Conv:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(227, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 214;
            this.label1.Text = "Porf/Conv Each:";
            // 
            // dteQuote
            // 
            this.dteQuote.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bidsBindingSource, "qtedate", true));
            this.dteQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteQuote.Location = new System.Drawing.Point(628, 31);
            this.dteQuote.Name = "dteQuote";
            this.dteQuote.Size = new System.Drawing.Size(200, 20);
            this.dteQuote.TabIndex = 188;
            // 
            // tabBids
            // 
            this.tabBids.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBids.Controls.Add(this.pgBids);
            this.tabBids.Location = new System.Drawing.Point(0, 0);
            this.tabBids.Name = "tabBids";
            this.tabBids.SelectedIndex = 0;
            this.tabBids.Size = new System.Drawing.Size(1228, 731);
            this.tabBids.TabIndex = 0;
            // 
            // bidsTableAdapter
            // 
            this.bidsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.bidsTableAdapter = this.bidsTableAdapter;
            this.tableAdapterManager.custTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsBidsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // custTableAdapter
            // 
            this.custTableAdapter.ClearBeforeFill = true;
            // 
            // frmBids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.bidsBindingNavigator);
            this.Controls.Add(this.tabBids);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBids";
            this.Text = "Bids";
            this.Load += new System.EventHandler(this.frmBids_Load_1);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmBids_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bidsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BidInvoiceDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bidsBindingNavigator)).EndInit();
            this.bidsBindingNavigator.ResumeLayout(false);
            this.bidsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pgBids.ResumeLayout(false);
            this.pgBids.PerformLayout();
            this.pnlTot.ResumeLayout(false);
            this.pnlTot.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
            this.tabBids.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

		#endregion
		private System.Windows.Forms.BindingSource bidsBindingSource;
		private DataSets.dsBidsTableAdapters.bidsTableAdapter bidsTableAdapter;
		private DataSets.dsBidsTableAdapters.TableAdapterManager tableAdapterManager;
		private System.Windows.Forms.BindingNavigator bidsBindingNavigator;
		private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
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
		private System.Windows.Forms.ToolStripButton bidsBindingNavigatorSaveItem;
        private System.Windows.Forms.BindingSource custBindingSource;
        private DataSets.dsBidsTableAdapters.custTableAdapter custTableAdapter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabBids;
        private System.Windows.Forms.TabPage pgBids;
        private System.Windows.Forms.TextBox txtfreebooks;
        private System.Windows.Forms.TextBox txtPOAmt;
        private System.Windows.Forms.TextBox txtPayments;
        private System.Windows.Forms.TextBox txtExtChrg;
        private System.Windows.Forms.TextBox txtPriceOverRide;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox booktypeTextBox;
        private System.Windows.Forms.TextBox txtNocopies;
        private System.Windows.Forms.TextBox txtPoNum;
        private System.Windows.Forms.TextBox txtBYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtNoPages;
        private System.Windows.Forms.Panel pnlTot;
        private System.Windows.Forms.TextBox txtIconCopies;
        private System.Windows.Forms.TextBox txtIconamt;
        private System.Windows.Forms.Label lblperstotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDisc;
        private System.Windows.Forms.TextBox txtFinalbookprc;
        private System.Windows.Forms.ComboBox dp1descComboBox;
        private System.Windows.Forms.TextBox txtNumtoPers;
        private System.Windows.Forms.TextBox perscopiesTextBox;
        private System.Windows.Forms.CheckBox chkDc2;
        private System.Windows.Forms.TextBox txtDp2;
        private System.Windows.Forms.TextBox persamountTextBox;
        private System.Windows.Forms.TextBox txtDp3Desc;
        private System.Windows.Forms.ComboBox dp3ComboBox;
        private System.Windows.Forms.CheckBox chkMsStandard;
        private System.Windows.Forms.TextBox txtMsQty;
        private System.Windows.Forms.TextBox foilamtTextBox;
        private System.Windows.Forms.Label lbladjbef;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtOtherChrg;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtOtherChrg2;
        private System.Windows.Forms.TextBox desc22TextBox;
        private System.Windows.Forms.TextBox txtCredits2;
        private System.Windows.Forms.TextBox cred_etcTextBox;
        private System.Windows.Forms.TextBox cred_etcTextBox1;
        private System.Windows.Forms.TextBox txtCredits;
        private System.Windows.Forms.Panel pnlMiscDiscCred;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClrDesc;
        private System.Windows.Forms.TextBox txtClrTot;
        private System.Windows.Forms.TextBox txtMisc;
        private System.Windows.Forms.TextBox txtMdesc;
        private System.Windows.Forms.TextBox txtDesc1amt;
        private System.Windows.Forms.TextBox txtDesc1;
        private System.Windows.Forms.TextBox txtDesc3tot;
        private System.Windows.Forms.TextBox txtDesc3;
        private System.Windows.Forms.TextBox txtDesc4tot;
        private System.Windows.Forms.TextBox txtDesc4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSpeccvrtot;
        private System.Windows.Forms.CheckBox chkAllClr;
        private System.Windows.Forms.Label lblMLaminateAmt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLaminateAmt;
        private System.Windows.Forms.TextBox txtnoClrPgs;
        private System.Windows.Forms.CheckBox chkGlossLam;
        private System.Windows.Forms.CheckBox chkMLaminate;
        private System.Windows.Forms.ComboBox inkclrComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClrNumber;
        private System.Windows.Forms.TextBox txtCoverDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSpecCvrEa;
        private System.Windows.Forms.TextBox txtFoilAd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblYir;
        private System.Windows.Forms.Label lblConvAmt;
        private System.Windows.Forms.Label lblProfAmt;
        private System.Windows.Forms.CheckBox chkProfessional;
        private System.Windows.Forms.CheckBox chkConv;
        private System.Windows.Forms.CheckBox chkYir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSaddleAmt;
        private System.Windows.Forms.Label lblSpiralAmt;
        private System.Windows.Forms.Label lblPerfbindAmt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkPerfBind;
        private System.Windows.Forms.CheckBox chkSpiral;
        private System.Windows.Forms.CheckBox chkSaddlStitch;
        private System.Windows.Forms.Panel pnlHard;
        private System.Windows.Forms.Label lblCaseamt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkHardBack;
        private System.Windows.Forms.CheckBox chkCaseBind;
        private System.Windows.Forms.Label lblHardbackAmt;
        private System.Windows.Forms.Label lblProftotalPrc;
        private System.Windows.Forms.Label lblprofprice;
        private System.Windows.Forms.Label lblPriceEach;
        private System.Windows.Forms.Label lblBookTotal;
        private System.Windows.Forms.ComboBox cmbYrDiscountAmt;
        private System.Windows.Forms.CheckBox chkPromo;
        private System.Windows.Forms.Label lblPCEach;
        private System.Windows.Forms.Label lblPCTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dteQuote;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblSalesTax;
        private System.Windows.Forms.CheckBox donotchargeschoolsalestaxCheckBox;
        private System.Windows.Forms.Label lblfilnalsubtotal;
        private System.Windows.Forms.Label lblsubtot;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label schooltaxrateLabel1;
        private System.Windows.Forms.Label lblMsTot;
        private System.Windows.Forms.Label otherdiscamt;
        private System.Windows.Forms.Label lbldisc2amount;
        private System.Windows.Forms.Label lbldisc1amount;
        private System.Windows.Forms.Label lblIconTot;
        private System.Windows.Forms.Button btnPrntQuote;
        private DataSets.dsBids dsBids;
        private System.Windows.Forms.TextBox allclramtTextBox;
        private System.Windows.Forms.BindingSource BidInvoiceDetailBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
    }
