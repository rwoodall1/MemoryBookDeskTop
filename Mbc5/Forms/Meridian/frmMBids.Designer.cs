namespace Mbc5.Forms.Meridian {
    partial class frmMBids {
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
            System.Windows.Forms.Label sourceLabel;
            System.Windows.Forms.Label invnoLabel;
            System.Windows.Forms.Label bpyearLabel;
            System.Windows.Forms.Label contryearLabel;
            System.Windows.Forms.Label sfLabel;
            System.Windows.Forms.Label ponumLabel;
            System.Windows.Forms.Label schcodeLabel;
            System.Windows.Forms.Label qtedateLabel;
            System.Windows.Forms.Label orderDateLabel;
            System.Windows.Forms.Label schoolTaxRateLabel;
            System.Windows.Forms.Label fplntotLabel;
            System.Windows.Forms.Label salestxLabel;
            System.Windows.Forms.Label fplnprcLabel;
            System.Windows.Forms.Label adcdescLabel;
            System.Windows.Forms.Label shpphndlLabel;
            System.Windows.Forms.Label totoptionprcLabel;
            System.Windows.Forms.Label specprcLabel;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label desc4Label;
            System.Windows.Forms.Label desc2Label;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label impguidqtyLabel;
            System.Windows.Forms.Label typesetqtyLabel;
            System.Windows.Forms.Label wallchqtyLabel;
            System.Windows.Forms.Label duraglzqtyLabel;
            System.Windows.Forms.Label stttitpgqtyLabel;
            System.Windows.Forms.Label idpouchqtyLabel;
            System.Windows.Forms.Label vpbqtyLabel;
            System.Windows.Forms.Label vpaqtyLabel;
            System.Windows.Forms.Label bmarkqtyLabel;
            System.Windows.Forms.Label hallpqtyLabel;
            System.Windows.Forms.Label afterdisctotLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label desc1Label;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label dp1Label;
            System.Windows.Forms.Label cvrtotprcLabel;
            System.Windows.Forms.Label wghtLabel;
            System.Windows.Forms.Label basetotLabel1;
            System.Windows.Forms.Label basetotLabel;
            System.Windows.Forms.Label baseprcLabel;
            System.Windows.Forms.Label priceovrdLabel;
            System.Windows.Forms.Label nopagesLabel;
            System.Windows.Forms.Label qtytotLabel;
            System.Windows.Forms.Label qtystudLabel;
            System.Windows.Forms.Label qtyteacherLabel;
            System.Windows.Forms.Label sbtotLabel;
            System.Windows.Forms.Label mdescLabel;
            System.Windows.Forms.Label notesLabel;
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.MBidInvoiceDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mbidsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsMBids = new Mbc5.DataSets.dsMBids();
            this.contryearTextBox = new System.Windows.Forms.TextBox();
            this.txtBYear = new System.Windows.Forms.TextBox();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.prodcodeComboBox = new System.Windows.Forms.ComboBox();
            this.meridianProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUp = new Mbc5.DataSets.LookUp();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sfRadioButton = new System.Windows.Forms.RadioButton();
            this.lfRadioButton = new System.Windows.Forms.RadioButton();
            this.ponumTextBox = new System.Windows.Forms.TextBox();
            this.lblSchname = new System.Windows.Forms.Label();
            this.schcodeLabel1 = new System.Windows.Forms.Label();
            this.oaCheckBox = new System.Windows.Forms.CheckBox();
            this.qtedateDateTimePicker = new Mbc5.Classes.NullableDateTimePicker();
            this.orderDateDateTimePicker = new Mbc5.Classes.NullableDateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.chkPrntAsInvoice = new System.Windows.Forms.CheckBox();
            this.lblModifiedby = new System.Windows.Forms.Label();
            this.txtAdditionChrg = new System.Windows.Forms.TextBox();
            this.adcdescTextBox = new System.Windows.Forms.TextBox();
            this.btnPrnQuote = new System.Windows.Forms.Button();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.reOrderCheckBox = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotalOptions = new System.Windows.Forms.Label();
            this.lblSpecialCoverPrice = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTaxRate = new System.Windows.Forms.Label();
            this.lblFinalTotal = new System.Windows.Forms.Label();
            this.lblFinalPrice = new System.Windows.Forms.Label();
            this.lblAppUser = new System.Windows.Forms.Label();
            this.doNotChargeTaxCheckBox = new System.Windows.Forms.CheckBox();
            this.txtShipping = new System.Windows.Forms.TextBox();
            this.custpuCheckBox = new System.Windows.Forms.CheckBox();
            this.desc4TextBox1 = new System.Windows.Forms.TextBox();
            this.desc3TextBox1 = new System.Windows.Forms.TextBox();
            this.desc2TextBox1 = new System.Windows.Forms.TextBox();
            this.impquidprcTextBox = new System.Windows.Forms.TextBox();
            this.txtImpGuideQty = new System.Windows.Forms.TextBox();
            this.typesetprcTextBox = new System.Windows.Forms.TextBox();
            this.typesetqtyTextBox = new System.Windows.Forms.TextBox();
            this.wallchprcTextBox = new System.Windows.Forms.TextBox();
            this.wallchqtyTextBox = new System.Windows.Forms.TextBox();
            this.duraglzprcTextBox = new System.Windows.Forms.TextBox();
            this.duraglzqtyTextBox = new System.Windows.Forms.TextBox();
            this.stdttitpgprcTextBox = new System.Windows.Forms.TextBox();
            this.stttitpgqtyTextBox = new System.Windows.Forms.TextBox();
            this.idpouchprcTextBox = new System.Windows.Forms.TextBox();
            this.idpouchqtyTextBox = new System.Windows.Forms.TextBox();
            this.vpbprcTextBox = new System.Windows.Forms.TextBox();
            this.vpbqtyTextBox = new System.Windows.Forms.TextBox();
            this.vpprcTextBox = new System.Windows.Forms.TextBox();
            this.vpaqtyTextBox = new System.Windows.Forms.TextBox();
            this.bmarkprcTextBox = new System.Windows.Forms.TextBox();
            this.bmarkqtyTextBox = new System.Windows.Forms.TextBox();
            this.hallppriceTextBox = new System.Windows.Forms.TextBox();
            this.hallpqtyTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.afterdisctotLabel2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCoverPricetotal = new System.Windows.Forms.Label();
            this.lblSchtype = new System.Windows.Forms.Label();
            this.disc3CheckBox = new System.Windows.Forms.CheckBox();
            this.disc4CheckBox = new System.Windows.Forms.CheckBox();
            this.desc3amtTextBox = new System.Windows.Forms.TextBox();
            this.desc3TextBox = new System.Windows.Forms.TextBox();
            this.desc4amtTextBox = new System.Windows.Forms.TextBox();
            this.desc4TextBox = new System.Windows.Forms.TextBox();
            this.desc1amtTextBox1 = new System.Windows.Forms.TextBox();
            this.descamtTextBox = new System.Windows.Forms.TextBox();
            this.desc2TextBox = new System.Windows.Forms.TextBox();
            this.desc1TextBox = new System.Windows.Forms.TextBox();
            this.erldiscamtTextBox = new System.Windows.Forms.TextBox();
            this.dp1TextBox = new System.Windows.Forms.TextBox();
            this.hrdcpyprfCheckBox = new System.Windows.Forms.CheckBox();
            this.fourclrCheckBox = new System.Windows.Forms.CheckBox();
            this.coverapprdCheckBox = new System.Windows.Forms.CheckBox();
            this.threeclrCheckBox = new System.Windows.Forms.CheckBox();
            this.oneclrCheckBox = new System.Windows.Forms.CheckBox();
            this.twoclrCheckBox = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblsbtot = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblQtyTotal = new System.Windows.Forms.Label();
            this.lblTotalBasePrice = new System.Windows.Forms.Label();
            this.lblTeachBasePrice = new System.Windows.Forms.Label();
            this.lblBasePrice = new System.Windows.Forms.Label();
            this.wghtTextBox = new System.Windows.Forms.TextBox();
            this.chkJostens = new System.Windows.Forms.CheckBox();
            this.chkGeneric = new System.Windows.Forms.CheckBox();
            this.line = new System.Windows.Forms.Label();
            this.txtPriceOverRide = new System.Windows.Forms.TextBox();
            this.txtNoPages = new System.Windows.Forms.TextBox();
            this.txtQtyStudent = new System.Windows.Forms.TextBox();
            this.txtQtyTeacher = new System.Windows.Forms.TextBox();
            this.mdescTextBox = new System.Windows.Forms.TextBox();
            this.txtmisc = new System.Windows.Forms.TextBox();
            this.mbidsTableAdapter = new Mbc5.DataSets.dsMBidsTableAdapters.mbidsTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsMBidsTableAdapters.TableAdapterManager();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.meridianProductsTableAdapter = new Mbc5.DataSets.LookUpTableAdapters.MeridianProductsTableAdapter();
            this.tableAdapterManager1 = new Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager();
            this.idLabel1 = new System.Windows.Forms.Label();
            this.OnlineFlyerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            sourceLabel = new System.Windows.Forms.Label();
            invnoLabel = new System.Windows.Forms.Label();
            bpyearLabel = new System.Windows.Forms.Label();
            contryearLabel = new System.Windows.Forms.Label();
            sfLabel = new System.Windows.Forms.Label();
            ponumLabel = new System.Windows.Forms.Label();
            schcodeLabel = new System.Windows.Forms.Label();
            qtedateLabel = new System.Windows.Forms.Label();
            orderDateLabel = new System.Windows.Forms.Label();
            schoolTaxRateLabel = new System.Windows.Forms.Label();
            fplntotLabel = new System.Windows.Forms.Label();
            salestxLabel = new System.Windows.Forms.Label();
            fplnprcLabel = new System.Windows.Forms.Label();
            adcdescLabel = new System.Windows.Forms.Label();
            shpphndlLabel = new System.Windows.Forms.Label();
            totoptionprcLabel = new System.Windows.Forms.Label();
            specprcLabel = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            desc4Label = new System.Windows.Forms.Label();
            desc2Label = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            impguidqtyLabel = new System.Windows.Forms.Label();
            typesetqtyLabel = new System.Windows.Forms.Label();
            wallchqtyLabel = new System.Windows.Forms.Label();
            duraglzqtyLabel = new System.Windows.Forms.Label();
            stttitpgqtyLabel = new System.Windows.Forms.Label();
            idpouchqtyLabel = new System.Windows.Forms.Label();
            vpbqtyLabel = new System.Windows.Forms.Label();
            vpaqtyLabel = new System.Windows.Forms.Label();
            bmarkqtyLabel = new System.Windows.Forms.Label();
            hallpqtyLabel = new System.Windows.Forms.Label();
            afterdisctotLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            desc1Label = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dp1Label = new System.Windows.Forms.Label();
            cvrtotprcLabel = new System.Windows.Forms.Label();
            wghtLabel = new System.Windows.Forms.Label();
            basetotLabel1 = new System.Windows.Forms.Label();
            basetotLabel = new System.Windows.Forms.Label();
            baseprcLabel = new System.Windows.Forms.Label();
            priceovrdLabel = new System.Windows.Forms.Label();
            nopagesLabel = new System.Windows.Forms.Label();
            qtytotLabel = new System.Windows.Forms.Label();
            qtystudLabel = new System.Windows.Forms.Label();
            qtyteacherLabel = new System.Windows.Forms.Label();
            sbtotLabel = new System.Windows.Forms.Label();
            mdescLabel = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MBidInvoiceDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mbidsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMBids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meridianProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineFlyerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceLabel
            // 
            sourceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            sourceLabel.AutoSize = true;
            sourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sourceLabel.Location = new System.Drawing.Point(1024, 12);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new System.Drawing.Size(47, 13);
            sourceLabel.TabIndex = 214;
            sourceLabel.Text = "Source";
            // 
            // invnoLabel
            // 
            invnoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            invnoLabel.AutoSize = true;
            invnoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            invnoLabel.Location = new System.Drawing.Point(659, 37);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(33, 13);
            invnoLabel.TabIndex = 211;
            invnoLabel.Text = "Bid#";
            // 
            // bpyearLabel
            // 
            bpyearLabel.AutoSize = true;
            bpyearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            bpyearLabel.ForeColor = System.Drawing.Color.Red;
            bpyearLabel.Location = new System.Drawing.Point(452, 37);
            bpyearLabel.Name = "bpyearLabel";
            bpyearLabel.Size = new System.Drawing.Size(98, 13);
            bpyearLabel.TabIndex = 210;
            bpyearLabel.Text = "Base Price Year";
            // 
            // contryearLabel
            // 
            contryearLabel.AutoSize = true;
            contryearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contryearLabel.Location = new System.Drawing.Point(361, 37);
            contryearLabel.Name = "contryearLabel";
            contryearLabel.Size = new System.Drawing.Size(33, 13);
            contryearLabel.TabIndex = 209;
            contryearLabel.Text = "Year";
            // 
            // sfLabel
            // 
            sfLabel.AutoSize = true;
            sfLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sfLabel.Location = new System.Drawing.Point(13, 37);
            sfLabel.Name = "sfLabel";
            sfLabel.Size = new System.Drawing.Size(35, 13);
            sfLabel.TabIndex = 206;
            sfLabel.Text = "Type";
            // 
            // ponumLabel
            // 
            ponumLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            ponumLabel.AutoSize = true;
            ponumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ponumLabel.Location = new System.Drawing.Point(640, 12);
            ponumLabel.Name = "ponumLabel";
            ponumLabel.Size = new System.Drawing.Size(40, 13);
            ponumLabel.TabIndex = 201;
            ponumLabel.Text = "P.O.#";
            // 
            // schcodeLabel
            // 
            schcodeLabel.AutoSize = true;
            schcodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            schcodeLabel.Location = new System.Drawing.Point(12, 9);
            schcodeLabel.Name = "schcodeLabel";
            schcodeLabel.Size = new System.Drawing.Size(79, 13);
            schcodeLabel.TabIndex = 198;
            schcodeLabel.Text = "School Code";
            // 
            // qtedateLabel
            // 
            qtedateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            qtedateLabel.AutoSize = true;
            qtedateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qtedateLabel.Location = new System.Drawing.Point(788, 37);
            qtedateLabel.Name = "qtedateLabel";
            qtedateLabel.Size = new System.Drawing.Size(72, 13);
            qtedateLabel.TabIndex = 221;
            qtedateLabel.Text = "Quote Date";
            // 
            // orderDateLabel
            // 
            orderDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            orderDateLabel.AutoSize = true;
            orderDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            orderDateLabel.Location = new System.Drawing.Point(794, 12);
            orderDateLabel.Name = "orderDateLabel";
            orderDateLabel.Size = new System.Drawing.Size(69, 13);
            orderDateLabel.TabIndex = 222;
            orderDateLabel.Text = "Order Date";
            // 
            // schoolTaxRateLabel
            // 
            schoolTaxRateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            schoolTaxRateLabel.AutoSize = true;
            schoolTaxRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            schoolTaxRateLabel.Location = new System.Drawing.Point(927, 79);
            schoolTaxRateLabel.Name = "schoolTaxRateLabel";
            schoolTaxRateLabel.Size = new System.Drawing.Size(16, 13);
            schoolTaxRateLabel.TabIndex = 57;
            schoolTaxRateLabel.Text = "%";
            // 
            // fplntotLabel
            // 
            fplntotLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            fplntotLabel.AutoSize = true;
            fplntotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fplntotLabel.Location = new System.Drawing.Point(899, 102);
            fplntotLabel.Name = "fplntotLabel";
            fplntotLabel.Size = new System.Drawing.Size(114, 13);
            fplntotLabel.TabIndex = 54;
            fplntotLabel.Text = "Final Planner Total";
            // 
            // salestxLabel
            // 
            salestxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            salestxLabel.AutoSize = true;
            salestxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            salestxLabel.Location = new System.Drawing.Point(950, 79);
            salestxLabel.Name = "salestxLabel";
            salestxLabel.Size = new System.Drawing.Size(63, 13);
            salestxLabel.TabIndex = 52;
            salestxLabel.Text = "Sales Tax";
            // 
            // fplnprcLabel
            // 
            fplnprcLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            fplnprcLabel.AutoSize = true;
            fplnprcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fplnprcLabel.Location = new System.Drawing.Point(899, 54);
            fplnprcLabel.Name = "fplnprcLabel";
            fplnprcLabel.Size = new System.Drawing.Size(114, 13);
            fplnprcLabel.TabIndex = 50;
            fplnprcLabel.Text = "Final Planner Price";
            // 
            // adcdescLabel
            // 
            adcdescLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            adcdescLabel.AutoSize = true;
            adcdescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            adcdescLabel.Location = new System.Drawing.Point(689, 25);
            adcdescLabel.Name = "adcdescLabel";
            adcdescLabel.Size = new System.Drawing.Size(113, 13);
            adcdescLabel.TabIndex = 47;
            adcdescLabel.Text = "Additional Charges";
            // 
            // shpphndlLabel
            // 
            shpphndlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            shpphndlLabel.AutoSize = true;
            shpphndlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            shpphndlLabel.Location = new System.Drawing.Point(982, 2);
            shpphndlLabel.Name = "shpphndlLabel";
            shpphndlLabel.Size = new System.Drawing.Size(31, 13);
            shpphndlLabel.TabIndex = 45;
            shpphndlLabel.Text = "S&&H";
            // 
            // totoptionprcLabel
            // 
            totoptionprcLabel.AutoSize = true;
            totoptionprcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            totoptionprcLabel.Location = new System.Drawing.Point(270, 133);
            totoptionprcLabel.Name = "totoptionprcLabel";
            totoptionprcLabel.Size = new System.Drawing.Size(110, 13);
            totoptionprcLabel.TabIndex = 42;
            totoptionprcLabel.Text = "Total Option Price";
            // 
            // specprcLabel
            // 
            specprcLabel.AutoSize = true;
            specprcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            specprcLabel.Location = new System.Drawing.Point(268, 110);
            specprcLabel.Name = "specprcLabel";
            specprcLabel.Size = new System.Drawing.Size(112, 13);
            specprcLabel.TabIndex = 40;
            specprcLabel.Text = "Secial Cover Price";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(274, 56);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(74, 13);
            label8.TabIndex = 39;
            label8.Text = "Inside Back";
            // 
            // desc4Label
            // 
            desc4Label.AutoSize = true;
            desc4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            desc4Label.Location = new System.Drawing.Point(265, 79);
            desc4Label.Name = "desc4Label";
            desc4Label.Size = new System.Drawing.Size(83, 13);
            desc4Label.TabIndex = 37;
            desc4Label.Text = "Outside Back";
            // 
            // desc2Label
            // 
            desc2Label.AutoSize = true;
            desc2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            desc2Label.Location = new System.Drawing.Point(274, 28);
            desc2Label.Name = "desc2Label";
            desc2Label.Size = new System.Drawing.Size(74, 13);
            desc2Label.TabIndex = 34;
            desc2Label.Text = "Inside Front";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(383, 2);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(133, 13);
            label7.TabIndex = 34;
            label7.Text = "Special Cover Printing";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(178, 2);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(36, 13);
            label6.TabIndex = 33;
            label6.Text = "Price";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(140, 2);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(32, 13);
            label5.TabIndex = 32;
            label5.Text = "QTY";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(63, 2);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(71, 13);
            label4.TabIndex = 31;
            label4.Text = "Description";
            // 
            // impguidqtyLabel
            // 
            impguidqtyLabel.AutoSize = true;
            impguidqtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            impguidqtyLabel.Location = new System.Drawing.Point(2, 238);
            impguidqtyLabel.Name = "impguidqtyLabel";
            impguidqtyLabel.Size = new System.Drawing.Size(135, 13);
            impguidqtyLabel.TabIndex = 27;
            impguidqtyLabel.Text = "Implementation Guides";
            // 
            // typesetqtyLabel
            // 
            typesetqtyLabel.AutoSize = true;
            typesetqtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            typesetqtyLabel.Location = new System.Drawing.Point(17, 215);
            typesetqtyLabel.Name = "typesetqtyLabel";
            typesetqtyLabel.Size = new System.Drawing.Size(120, 13);
            typesetqtyLabel.TabIndex = 24;
            typesetqtyLabel.Text = "Typesetting Service";
            // 
            // wallchqtyLabel
            // 
            wallchqtyLabel.AutoSize = true;
            wallchqtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            wallchqtyLabel.Location = new System.Drawing.Point(5, 195);
            wallchqtyLabel.Name = "wallchqtyLabel";
            wallchqtyLabel.Size = new System.Drawing.Size(132, 13);
            wallchqtyLabel.TabIndex = 21;
            wallchqtyLabel.Text = "Elementary Wall Chart";
            // 
            // duraglzqtyLabel
            // 
            duraglzqtyLabel.AutoSize = true;
            duraglzqtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            duraglzqtyLabel.Location = new System.Drawing.Point(71, 169);
            duraglzqtyLabel.Name = "duraglzqtyLabel";
            duraglzqtyLabel.Size = new System.Drawing.Size(66, 13);
            duraglzqtyLabel.TabIndex = 18;
            duraglzqtyLabel.Text = "DuraGlaze";
            // 
            // stttitpgqtyLabel
            // 
            stttitpgqtyLabel.AutoSize = true;
            stttitpgqtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            stttitpgqtyLabel.Location = new System.Drawing.Point(17, 146);
            stttitpgqtyLabel.Name = "stttitpgqtyLabel";
            stttitpgqtyLabel.Size = new System.Drawing.Size(120, 13);
            stttitpgqtyLabel.TabIndex = 15;
            stttitpgqtyLabel.Text = "Standard Title Page";
            // 
            // idpouchqtyLabel
            // 
            idpouchqtyLabel.AutoSize = true;
            idpouchqtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idpouchqtyLabel.Location = new System.Drawing.Point(79, 126);
            idpouchqtyLabel.Name = "idpouchqtyLabel";
            idpouchqtyLabel.Size = new System.Drawing.Size(58, 13);
            idpouchqtyLabel.TabIndex = 12;
            idpouchqtyLabel.Text = "Id Pouch";
            // 
            // vpbqtyLabel
            // 
            vpbqtyLabel.AutoSize = true;
            vpbqtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            vpbqtyLabel.Location = new System.Drawing.Point(47, 99);
            vpbqtyLabel.Name = "vpbqtyLabel";
            vpbqtyLabel.Size = new System.Drawing.Size(90, 13);
            vpbqtyLabel.TabIndex = 9;
            vpbqtyLabel.Text = "Vinyl Pocket B";
            // 
            // vpaqtyLabel
            // 
            vpaqtyLabel.AutoSize = true;
            vpaqtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            vpaqtyLabel.Location = new System.Drawing.Point(47, 78);
            vpaqtyLabel.Name = "vpaqtyLabel";
            vpaqtyLabel.Size = new System.Drawing.Size(90, 13);
            vpaqtyLabel.TabIndex = 6;
            vpaqtyLabel.Text = "Vinyl Pocket A";
            // 
            // bmarkqtyLabel
            // 
            bmarkqtyLabel.AutoSize = true;
            bmarkqtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            bmarkqtyLabel.Location = new System.Drawing.Point(69, 51);
            bmarkqtyLabel.Name = "bmarkqtyLabel";
            bmarkqtyLabel.Size = new System.Drawing.Size(68, 13);
            bmarkqtyLabel.TabIndex = 3;
            bmarkqtyLabel.Text = "Book Mark";
            // 
            // hallpqtyLabel
            // 
            hallpqtyLabel.AutoSize = true;
            hallpqtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            hallpqtyLabel.Location = new System.Drawing.Point(77, 28);
            hallpqtyLabel.Name = "hallpqtyLabel";
            hallpqtyLabel.Size = new System.Drawing.Size(60, 13);
            hallpqtyLabel.TabIndex = 0;
            hallpqtyLabel.Text = "Hall Pass";
            // 
            // afterdisctotLabel
            // 
            afterdisctotLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            afterdisctotLabel.AutoSize = true;
            afterdisctotLabel.Location = new System.Drawing.Point(889, 132);
            afterdisctotLabel.Name = "afterdisctotLabel";
            afterdisctotLabel.Size = new System.Drawing.Size(122, 13);
            afterdisctotLabel.TabIndex = 46;
            afterdisctotLabel.Text = "After Disc Sub Total";
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(689, 64);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(109, 13);
            label3.TabIndex = 39;
            label3.Text = "Discount\\Charges";
            // 
            // desc1Label
            // 
            desc1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            desc1Label.AutoSize = true;
            desc1Label.Location = new System.Drawing.Point(689, 41);
            desc1Label.Name = "desc1Label";
            desc1Label.Size = new System.Drawing.Size(109, 13);
            desc1Label.TabIndex = 37;
            desc1Label.Text = "Discount\\Charges";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(863, 14);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 13);
            label2.TabIndex = 36;
            label2.Text = "Early Discount";
            // 
            // dp1Label
            // 
            dp1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dp1Label.AutoSize = true;
            dp1Label.Location = new System.Drawing.Point(956, 17);
            dp1Label.Name = "dp1Label";
            dp1Label.Size = new System.Drawing.Size(16, 13);
            dp1Label.TabIndex = 33;
            dp1Label.Text = "%";
            // 
            // cvrtotprcLabel
            // 
            cvrtotprcLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            cvrtotprcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cvrtotprcLabel.Location = new System.Drawing.Point(309, 14);
            cvrtotprcLabel.Name = "cvrtotprcLabel";
            cvrtotprcLabel.Size = new System.Drawing.Size(113, 22);
            cvrtotprcLabel.TabIndex = 32;
            cvrtotprcLabel.Text = "Cover Total Price";
            // 
            // wghtLabel
            // 
            wghtLabel.AutoSize = true;
            wghtLabel.Location = new System.Drawing.Point(495, 61);
            wghtLabel.Name = "wghtLabel";
            wghtLabel.Size = new System.Drawing.Size(47, 13);
            wghtLabel.TabIndex = 49;
            wghtLabel.Text = "Weight";
            // 
            // basetotLabel1
            // 
            basetotLabel1.AutoSize = true;
            basetotLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            basetotLabel1.Location = new System.Drawing.Point(326, 36);
            basetotLabel1.Name = "basetotLabel1";
            basetotLabel1.Size = new System.Drawing.Size(113, 13);
            basetotLabel1.TabIndex = 43;
            basetotLabel1.Text = "Teacher Plnr Price";
            // 
            // basetotLabel
            // 
            basetotLabel.AutoSize = true;
            basetotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            basetotLabel.Location = new System.Drawing.Point(338, 61);
            basetotLabel.Name = "basetotLabel";
            basetotLabel.Size = new System.Drawing.Size(101, 13);
            basetotLabel.TabIndex = 42;
            basetotLabel.Text = "Total Base Price";
            // 
            // baseprcLabel
            // 
            baseprcLabel.AutoSize = true;
            baseprcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            baseprcLabel.Location = new System.Drawing.Point(345, 16);
            baseprcLabel.Name = "baseprcLabel";
            baseprcLabel.Size = new System.Drawing.Size(94, 13);
            baseprcLabel.TabIndex = 41;
            baseprcLabel.Text = "Base Plnr Price";
            // 
            // priceovrdLabel
            // 
            priceovrdLabel.AutoSize = true;
            priceovrdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            priceovrdLabel.Location = new System.Drawing.Point(148, 61);
            priceovrdLabel.Name = "priceovrdLabel";
            priceovrdLabel.Size = new System.Drawing.Size(88, 13);
            priceovrdLabel.TabIndex = 40;
            priceovrdLabel.Text = "Price Override";
            // 
            // nopagesLabel
            // 
            nopagesLabel.AutoSize = true;
            nopagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nopagesLabel.Location = new System.Drawing.Point(166, 13);
            nopagesLabel.Name = "nopagesLabel";
            nopagesLabel.Size = new System.Drawing.Size(70, 13);
            nopagesLabel.TabIndex = 39;
            nopagesLabel.Text = "#Hnbk Pgs";
            // 
            // qtytotLabel
            // 
            qtytotLabel.AutoSize = true;
            qtytotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qtytotLabel.Location = new System.Drawing.Point(27, 61);
            qtytotLabel.Name = "qtytotLabel";
            qtytotLabel.Size = new System.Drawing.Size(59, 13);
            qtytotLabel.TabIndex = 38;
            qtytotLabel.Text = "Qty Total";
            // 
            // qtystudLabel
            // 
            qtystudLabel.AutoSize = true;
            qtystudLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qtystudLabel.Location = new System.Drawing.Point(12, 13);
            qtystudLabel.Name = "qtystudLabel";
            qtystudLabel.Size = new System.Drawing.Size(74, 13);
            qtystudLabel.TabIndex = 37;
            qtystudLabel.Text = "Qty Student";
            // 
            // qtyteacherLabel
            // 
            qtyteacherLabel.AutoSize = true;
            qtyteacherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qtyteacherLabel.Location = new System.Drawing.Point(9, 36);
            qtyteacherLabel.Name = "qtyteacherLabel";
            qtyteacherLabel.Size = new System.Drawing.Size(77, 13);
            qtyteacherLabel.TabIndex = 36;
            qtyteacherLabel.Text = "Qty Teacher";
            // 
            // sbtotLabel
            // 
            sbtotLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            sbtotLabel.AutoSize = true;
            sbtotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sbtotLabel.Location = new System.Drawing.Point(954, 42);
            sbtotLabel.Name = "sbtotLabel";
            sbtotLabel.Size = new System.Drawing.Size(62, 13);
            sbtotLabel.TabIndex = 35;
            sbtotLabel.Text = "Sub Total";
            // 
            // mdescLabel
            // 
            mdescLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            mdescLabel.AutoSize = true;
            mdescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mdescLabel.Location = new System.Drawing.Point(685, 16);
            mdescLabel.Name = "mdescLabel";
            mdescLabel.Size = new System.Drawing.Size(109, 13);
            mdescLabel.TabIndex = 33;
            mdescLabel.Text = "Discount\\Charges";
            // 
            // notesLabel
            // 
            notesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            notesLabel.AutoSize = true;
            notesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            notesLabel.Location = new System.Drawing.Point(658, 206);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(40, 13);
            notesLabel.TabIndex = 158;
            notesLabel.Text = "Notes";
            // 
            // MBidInvoiceDetailBindingSource
            // 
            this.MBidInvoiceDetailBindingSource.DataSource = typeof(BindingModels.MBidInvoiceDetail);
            // 
            // mbidsBindingSource
            // 
            this.mbidsBindingSource.DataMember = "mbids";
            this.mbidsBindingSource.DataSource = this.dsMBids;
            // 
            // dsMBids
            // 
            this.dsMBids.DataSetName = "dsMBids";
            this.dsMBids.EnforceConstraints = false;
            this.dsMBids.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contryearTextBox
            // 
            this.contryearTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "contryear", true));
            this.contryearTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contryearTextBox.Location = new System.Drawing.Point(400, 37);
            this.contryearTextBox.Name = "contryearTextBox";
            this.contryearTextBox.Size = new System.Drawing.Size(32, 20);
            this.contryearTextBox.TabIndex = 218;
            this.contryearTextBox.Leave += new System.EventHandler(this.contryearTextBox_Leave);
            this.contryearTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.contryearTextBox_Validating);
            // 
            // txtBYear
            // 
            this.txtBYear.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "bpyear", true));
            this.txtBYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBYear.Location = new System.Drawing.Point(556, 37);
            this.txtBYear.Name = "txtBYear";
            this.txtBYear.Size = new System.Drawing.Size(39, 20);
            this.txtBYear.TabIndex = 217;
            this.txtBYear.Leave += new System.EventHandler(this.txtBYear_Leave);
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "source", true));
            this.sourceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceTextBox.Location = new System.Drawing.Point(1077, 12);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(45, 20);
            this.sourceTextBox.TabIndex = 215;
            // 
            // prodcodeComboBox
            // 
            this.prodcodeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mbidsBindingSource, "prodcode", true));
            this.prodcodeComboBox.DataSource = this.meridianProductsBindingSource;
            this.prodcodeComboBox.DisplayMember = "Description";
            this.prodcodeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodcodeComboBox.FormattingEnabled = true;
            this.prodcodeComboBox.Location = new System.Drawing.Point(150, 37);
            this.prodcodeComboBox.Name = "prodcodeComboBox";
            this.prodcodeComboBox.Size = new System.Drawing.Size(199, 21);
            this.prodcodeComboBox.TabIndex = 208;
            this.prodcodeComboBox.ValueMember = "ProdCode";
            this.prodcodeComboBox.SelectionChangeCommitted += new System.EventHandler(this.prodcodeComboBox_SelectionChangeCommitted);
            // 
            // meridianProductsBindingSource
            // 
            this.meridianProductsBindingSource.DataMember = "MeridianProducts";
            this.meridianProductsBindingSource.DataSource = this.lookUp;
            // 
            // lookUp
            // 
            this.lookUp.DataSetName = "LookUp";
            this.lookUp.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.sfRadioButton);
            this.panel1.Controls.Add(this.lfRadioButton);
            this.panel1.Location = new System.Drawing.Point(46, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 25);
            this.panel1.TabIndex = 207;
            // 
            // sfRadioButton
            // 
            this.sfRadioButton.AutoCheck = false;
            this.sfRadioButton.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "sf", true));
            this.sfRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfRadioButton.Location = new System.Drawing.Point(49, 3);
            this.sfRadioButton.Name = "sfRadioButton";
            this.sfRadioButton.Size = new System.Drawing.Size(52, 19);
            this.sfRadioButton.TabIndex = 11;
            this.sfRadioButton.TabStop = true;
            this.sfRadioButton.Text = "SF";
            this.sfRadioButton.UseVisualStyleBackColor = true;
            // 
            // lfRadioButton
            // 
            this.lfRadioButton.AutoCheck = false;
            this.lfRadioButton.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "lf", true));
            this.lfRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lfRadioButton.Location = new System.Drawing.Point(3, 3);
            this.lfRadioButton.Name = "lfRadioButton";
            this.lfRadioButton.Size = new System.Drawing.Size(52, 19);
            this.lfRadioButton.TabIndex = 9;
            this.lfRadioButton.TabStop = true;
            this.lfRadioButton.Text = "LF";
            this.lfRadioButton.UseVisualStyleBackColor = true;
            // 
            // ponumTextBox
            // 
            this.ponumTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ponumTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "ponum", true));
            this.ponumTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ponumTextBox.Location = new System.Drawing.Point(681, 9);
            this.ponumTextBox.Name = "ponumTextBox";
            this.ponumTextBox.Size = new System.Drawing.Size(100, 20);
            this.ponumTextBox.TabIndex = 202;
            // 
            // lblSchname
            // 
            this.lblSchname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "schname", true));
            this.lblSchname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchname.Location = new System.Drawing.Point(155, 9);
            this.lblSchname.Name = "lblSchname";
            this.lblSchname.Size = new System.Drawing.Size(285, 23);
            this.lblSchname.TabIndex = 200;
            this.lblSchname.Text = "schname";
            // 
            // schcodeLabel1
            // 
            this.schcodeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "schcode", true));
            this.schcodeLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schcodeLabel1.Location = new System.Drawing.Point(97, 9);
            this.schcodeLabel1.Name = "schcodeLabel1";
            this.schcodeLabel1.Size = new System.Drawing.Size(100, 23);
            this.schcodeLabel1.TabIndex = 199;
            this.schcodeLabel1.Text = "schcode";
            // 
            // oaCheckBox
            // 
            this.oaCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "oa", true));
            this.oaCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oaCheckBox.Location = new System.Drawing.Point(506, 8);
            this.oaCheckBox.Name = "oaCheckBox";
            this.oaCheckBox.Size = new System.Drawing.Size(129, 24);
            this.oaCheckBox.TabIndex = 221;
            this.oaCheckBox.Text = "Order Agreement";
            this.oaCheckBox.UseVisualStyleBackColor = true;
            // 
            // qtedateDateTimePicker
            // 
            this.qtedateDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.qtedateDateTimePicker.CustomFormat = "\'\'";
            this.qtedateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mbidsBindingSource, "qtedate", true));
            this.qtedateDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtedateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.qtedateDateTimePicker.Location = new System.Drawing.Point(864, 37);
            this.qtedateDateTimePicker.Name = "qtedateDateTimePicker";
            this.qtedateDateTimePicker.Size = new System.Drawing.Size(130, 20);
            this.qtedateDateTimePicker.TabIndex = 222;
            this.qtedateDateTimePicker.Value = new System.DateTime(2019, 8, 8, 14, 47, 23, 190);
            this.qtedateDateTimePicker.ValueChanged += new System.EventHandler(this.qtedateDateTimePicker_ValueChanged);
            // 
            // orderDateDateTimePicker
            // 
            this.orderDateDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.orderDateDateTimePicker.CustomFormat = "\'\'";
            this.orderDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mbidsBindingSource, "OrderDate", true));
            this.orderDateDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.orderDateDateTimePicker.Location = new System.Drawing.Point(864, 8);
            this.orderDateDateTimePicker.Name = "orderDateDateTimePicker";
            this.orderDateDateTimePicker.Size = new System.Drawing.Size(130, 20);
            this.orderDateDateTimePicker.TabIndex = 223;
            this.orderDateDateTimePicker.Value = new System.DateTime(2019, 8, 8, 14, 47, 23, 187);
            this.orderDateDateTimePicker.ValueChanged += new System.EventHandler(this.orderDateDateTimePicker_ValueChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.reportViewer1);
            this.panel4.Controls.Add(this.chkPrntAsInvoice);
            this.panel4.Controls.Add(this.lblModifiedby);
            this.panel4.Controls.Add(this.txtAdditionChrg);
            this.panel4.Controls.Add(this.adcdescTextBox);
            this.panel4.Controls.Add(this.btnPrnQuote);
            this.panel4.Controls.Add(notesLabel);
            this.panel4.Controls.Add(this.notesTextBox);
            this.panel4.Controls.Add(this.reOrderCheckBox);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.lblTotalOptions);
            this.panel4.Controls.Add(this.lblSpecialCoverPrice);
            this.panel4.Controls.Add(this.lblTax);
            this.panel4.Controls.Add(this.lblTaxRate);
            this.panel4.Controls.Add(this.lblFinalTotal);
            this.panel4.Controls.Add(this.lblFinalPrice);
            this.panel4.Controls.Add(this.lblAppUser);
            this.panel4.Controls.Add(schoolTaxRateLabel);
            this.panel4.Controls.Add(this.doNotChargeTaxCheckBox);
            this.panel4.Controls.Add(fplntotLabel);
            this.panel4.Controls.Add(salestxLabel);
            this.panel4.Controls.Add(fplnprcLabel);
            this.panel4.Controls.Add(adcdescLabel);
            this.panel4.Controls.Add(shpphndlLabel);
            this.panel4.Controls.Add(this.txtShipping);
            this.panel4.Controls.Add(this.custpuCheckBox);
            this.panel4.Controls.Add(totoptionprcLabel);
            this.panel4.Controls.Add(specprcLabel);
            this.panel4.Controls.Add(label8);
            this.panel4.Controls.Add(desc4Label);
            this.panel4.Controls.Add(this.desc4TextBox1);
            this.panel4.Controls.Add(this.desc3TextBox1);
            this.panel4.Controls.Add(this.desc2TextBox1);
            this.panel4.Controls.Add(desc2Label);
            this.panel4.Controls.Add(label7);
            this.panel4.Controls.Add(label6);
            this.panel4.Controls.Add(label5);
            this.panel4.Controls.Add(label4);
            this.panel4.Controls.Add(this.impquidprcTextBox);
            this.panel4.Controls.Add(impguidqtyLabel);
            this.panel4.Controls.Add(this.txtImpGuideQty);
            this.panel4.Controls.Add(this.typesetprcTextBox);
            this.panel4.Controls.Add(typesetqtyLabel);
            this.panel4.Controls.Add(this.typesetqtyTextBox);
            this.panel4.Controls.Add(this.wallchprcTextBox);
            this.panel4.Controls.Add(wallchqtyLabel);
            this.panel4.Controls.Add(this.wallchqtyTextBox);
            this.panel4.Controls.Add(this.duraglzprcTextBox);
            this.panel4.Controls.Add(duraglzqtyLabel);
            this.panel4.Controls.Add(this.duraglzqtyTextBox);
            this.panel4.Controls.Add(this.stdttitpgprcTextBox);
            this.panel4.Controls.Add(stttitpgqtyLabel);
            this.panel4.Controls.Add(this.stttitpgqtyTextBox);
            this.panel4.Controls.Add(this.idpouchprcTextBox);
            this.panel4.Controls.Add(idpouchqtyLabel);
            this.panel4.Controls.Add(this.idpouchqtyTextBox);
            this.panel4.Controls.Add(this.vpbprcTextBox);
            this.panel4.Controls.Add(vpbqtyLabel);
            this.panel4.Controls.Add(this.vpbqtyTextBox);
            this.panel4.Controls.Add(this.vpprcTextBox);
            this.panel4.Controls.Add(vpaqtyLabel);
            this.panel4.Controls.Add(this.vpaqtyTextBox);
            this.panel4.Controls.Add(this.bmarkprcTextBox);
            this.panel4.Controls.Add(bmarkqtyLabel);
            this.panel4.Controls.Add(this.bmarkqtyTextBox);
            this.panel4.Controls.Add(this.hallppriceTextBox);
            this.panel4.Controls.Add(hallpqtyLabel);
            this.panel4.Controls.Add(this.hallpqtyTextBox);
            this.panel4.Location = new System.Drawing.Point(49, 321);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1082, 408);
            this.panel4.TabIndex = 226;
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "dsMeridianBidDetails";
            reportDataSource3.Value = this.MBidInvoiceDetailBindingSource;
            reportDataSource4.Name = "dsMBid";
            reportDataSource4.Value = this.mbidsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MeridianQuote.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(781, 277);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(150, 107);
            this.reportViewer1.TabIndex = 297;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // chkPrntAsInvoice
            // 
            this.chkPrntAsInvoice.AutoSize = true;
            this.chkPrntAsInvoice.Location = new System.Drawing.Point(911, 142);
            this.chkPrntAsInvoice.Name = "chkPrntAsInvoice";
            this.chkPrntAsInvoice.Size = new System.Drawing.Size(113, 17);
            this.chkPrntAsInvoice.TabIndex = 296;
            this.chkPrntAsInvoice.Text = "Prnt As Invoice";
            this.chkPrntAsInvoice.UseVisualStyleBackColor = true;
            // 
            // lblModifiedby
            // 
            this.lblModifiedby.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "ModifiedBy", true));
            this.lblModifiedby.Location = new System.Drawing.Point(5, 383);
            this.lblModifiedby.Name = "lblModifiedby";
            this.lblModifiedby.Size = new System.Drawing.Size(1, 1);
            this.lblModifiedby.TabIndex = 227;
            this.lblModifiedby.Text = "label1";
            // 
            // txtAdditionChrg
            // 
            this.txtAdditionChrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdditionChrg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "adcamt", true));
            this.txtAdditionChrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionChrg.Location = new System.Drawing.Point(1017, 25);
            this.txtAdditionChrg.Name = "txtAdditionChrg";
            this.txtAdditionChrg.Size = new System.Drawing.Size(52, 20);
            this.txtAdditionChrg.TabIndex = 164;
            this.txtAdditionChrg.Leave += new System.EventHandler(this.txtAdditionChrg_Leave);
            this.txtAdditionChrg.Validating += new System.ComponentModel.CancelEventHandler(this.txtAdditionChrg_Validating);
            // 
            // adcdescTextBox
            // 
            this.adcdescTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adcdescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "adcdesc", true));
            this.adcdescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adcdescTextBox.Location = new System.Drawing.Point(798, 25);
            this.adcdescTextBox.Name = "adcdescTextBox";
            this.adcdescTextBox.Size = new System.Drawing.Size(206, 20);
            this.adcdescTextBox.TabIndex = 163;
            // 
            // btnPrnQuote
            // 
            this.btnPrnQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrnQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrnQuote.Location = new System.Drawing.Point(911, 161);
            this.btnPrnQuote.Name = "btnPrnQuote";
            this.btnPrnQuote.Size = new System.Drawing.Size(103, 23);
            this.btnPrnQuote.TabIndex = 161;
            this.btnPrnQuote.Text = "Print Bid Quote";
            this.btnPrnQuote.UseVisualStyleBackColor = true;
            this.btnPrnQuote.Click += new System.EventHandler(this.btnPrnQuote_Click);
            // 
            // notesTextBox
            // 
            this.notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "notes", true));
            this.notesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notesTextBox.Location = new System.Drawing.Point(706, 203);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(346, 60);
            this.notesTextBox.TabIndex = 159;
            // 
            // reOrderCheckBox
            // 
            this.reOrderCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "ReOrder", true));
            this.reOrderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reOrderCheckBox.Location = new System.Drawing.Point(275, 156);
            this.reOrderCheckBox.Name = "reOrderCheckBox";
            this.reOrderCheckBox.Size = new System.Drawing.Size(77, 24);
            this.reOrderCheckBox.TabIndex = 158;
            this.reOrderCheckBox.Text = "Reorder";
            this.reOrderCheckBox.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(632, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1, 406);
            this.label13.TabIndex = 157;
            this.label13.Text = "label13";
            // 
            // lblTotalOptions
            // 
            this.lblTotalOptions.AutoSize = true;
            this.lblTotalOptions.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "totoptionprc", true));
            this.lblTotalOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOptions.Location = new System.Drawing.Point(389, 133);
            this.lblTotalOptions.Name = "lblTotalOptions";
            this.lblTotalOptions.Size = new System.Drawing.Size(41, 13);
            this.lblTotalOptions.TabIndex = 156;
            this.lblTotalOptions.Text = "label11";
            // 
            // lblSpecialCoverPrice
            // 
            this.lblSpecialCoverPrice.AutoSize = true;
            this.lblSpecialCoverPrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "specprc", true));
            this.lblSpecialCoverPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialCoverPrice.Location = new System.Drawing.Point(389, 110);
            this.lblSpecialCoverPrice.Name = "lblSpecialCoverPrice";
            this.lblSpecialCoverPrice.Size = new System.Drawing.Size(41, 13);
            this.lblSpecialCoverPrice.TabIndex = 155;
            this.lblSpecialCoverPrice.Text = "label10";
            // 
            // lblTax
            // 
            this.lblTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "salestx", true));
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(1017, 79);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(52, 13);
            this.lblTax.TabIndex = 154;
            this.lblTax.Text = "label10";
            // 
            // lblTaxRate
            // 
            this.lblTaxRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTaxRate.AutoSize = true;
            this.lblTaxRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "SchoolTaxRate", true));
            this.lblTaxRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxRate.Location = new System.Drawing.Point(890, 79);
            this.lblTaxRate.Name = "lblTaxRate";
            this.lblTaxRate.Size = new System.Drawing.Size(41, 13);
            this.lblTaxRate.TabIndex = 153;
            this.lblTaxRate.Text = "label10";
            this.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFinalTotal
            // 
            this.lblFinalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFinalTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "fplntot", true));
            this.lblFinalTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalTotal.Location = new System.Drawing.Point(1017, 102);
            this.lblFinalTotal.Name = "lblFinalTotal";
            this.lblFinalTotal.Size = new System.Drawing.Size(52, 13);
            this.lblFinalTotal.TabIndex = 152;
            this.lblFinalTotal.Text = "label9";
            // 
            // lblFinalPrice
            // 
            this.lblFinalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFinalPrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "fplnprc", true));
            this.lblFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalPrice.Location = new System.Drawing.Point(1017, 54);
            this.lblFinalPrice.Name = "lblFinalPrice";
            this.lblFinalPrice.Size = new System.Drawing.Size(52, 16);
            this.lblFinalPrice.TabIndex = 151;
            this.lblFinalPrice.Text = "label9";
            // 
            // lblAppUser
            // 
            this.lblAppUser.Location = new System.Drawing.Point(12, 267);
            this.lblAppUser.Name = "lblAppUser";
            this.lblAppUser.Size = new System.Drawing.Size(1, 1);
            this.lblAppUser.TabIndex = 25;
            this.lblAppUser.Text = "au";
            // 
            // doNotChargeTaxCheckBox
            // 
            this.doNotChargeTaxCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doNotChargeTaxCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "DoNotChargeTax", true));
            this.doNotChargeTaxCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doNotChargeTaxCheckBox.Location = new System.Drawing.Point(720, 79);
            this.doNotChargeTaxCheckBox.Name = "doNotChargeTaxCheckBox";
            this.doNotChargeTaxCheckBox.Size = new System.Drawing.Size(161, 16);
            this.doNotChargeTaxCheckBox.TabIndex = 57;
            this.doNotChargeTaxCheckBox.Text = "Do Not Calculate Taxes";
            this.doNotChargeTaxCheckBox.UseVisualStyleBackColor = true;
            this.doNotChargeTaxCheckBox.Click += new System.EventHandler(this.doNotChargeTaxCheckBox_Click);
            // 
            // txtShipping
            // 
            this.txtShipping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShipping.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "shpphndl", true));
            this.txtShipping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipping.Location = new System.Drawing.Point(1017, 2);
            this.txtShipping.Name = "txtShipping";
            this.txtShipping.Size = new System.Drawing.Size(52, 20);
            this.txtShipping.TabIndex = 46;
            this.txtShipping.Leave += new System.EventHandler(this.txtShipping_Leave);
            // 
            // custpuCheckBox
            // 
            this.custpuCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.custpuCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "custpu", true));
            this.custpuCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custpuCheckBox.Location = new System.Drawing.Point(861, 2);
            this.custpuCheckBox.Name = "custpuCheckBox";
            this.custpuCheckBox.Size = new System.Drawing.Size(104, 17);
            this.custpuCheckBox.TabIndex = 45;
            this.custpuCheckBox.Text = "Customer PU";
            this.custpuCheckBox.UseVisualStyleBackColor = true;
            // 
            // desc4TextBox1
            // 
            this.desc4TextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "cdesc4", true));
            this.desc4TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc4TextBox1.Location = new System.Drawing.Point(355, 79);
            this.desc4TextBox1.Name = "desc4TextBox1";
            this.desc4TextBox1.Size = new System.Drawing.Size(219, 20);
            this.desc4TextBox1.TabIndex = 38;
            this.desc4TextBox1.Leave += new System.EventHandler(this.desc4TextBox1_Leave);
            // 
            // desc3TextBox1
            // 
            this.desc3TextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "cdesc3", true));
            this.desc3TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc3TextBox1.Location = new System.Drawing.Point(355, 53);
            this.desc3TextBox1.Name = "desc3TextBox1";
            this.desc3TextBox1.Size = new System.Drawing.Size(219, 20);
            this.desc3TextBox1.TabIndex = 37;
            this.desc3TextBox1.Leave += new System.EventHandler(this.desc3TextBox1_Leave);
            // 
            // desc2TextBox1
            // 
            this.desc2TextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "cdesc2", true));
            this.desc2TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc2TextBox1.Location = new System.Drawing.Point(355, 28);
            this.desc2TextBox1.Name = "desc2TextBox1";
            this.desc2TextBox1.Size = new System.Drawing.Size(219, 20);
            this.desc2TextBox1.TabIndex = 36;
            this.desc2TextBox1.Leave += new System.EventHandler(this.desc2TextBox1_Leave);
            // 
            // impquidprcTextBox
            // 
            this.impquidprcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "impquidprc", true));
            this.impquidprcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.impquidprcTextBox.Location = new System.Drawing.Point(177, 238);
            this.impquidprcTextBox.Name = "impquidprcTextBox";
            this.impquidprcTextBox.ReadOnly = true;
            this.impquidprcTextBox.Size = new System.Drawing.Size(51, 20);
            this.impquidprcTextBox.TabIndex = 30;
            // 
            // txtImpGuideQty
            // 
            this.txtImpGuideQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "impguidqty", true));
            this.txtImpGuideQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpGuideQty.Location = new System.Drawing.Point(143, 238);
            this.txtImpGuideQty.Name = "txtImpGuideQty";
            this.txtImpGuideQty.ReadOnly = true;
            this.txtImpGuideQty.Size = new System.Drawing.Size(28, 20);
            this.txtImpGuideQty.TabIndex = 28;
            // 
            // typesetprcTextBox
            // 
            this.typesetprcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "typesetprc", true));
            this.typesetprcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typesetprcTextBox.Location = new System.Drawing.Point(177, 215);
            this.typesetprcTextBox.Name = "typesetprcTextBox";
            this.typesetprcTextBox.ReadOnly = true;
            this.typesetprcTextBox.Size = new System.Drawing.Size(51, 20);
            this.typesetprcTextBox.TabIndex = 27;
            // 
            // typesetqtyTextBox
            // 
            this.typesetqtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "typesetqty", true));
            this.typesetqtyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typesetqtyTextBox.Location = new System.Drawing.Point(143, 215);
            this.typesetqtyTextBox.Name = "typesetqtyTextBox";
            this.typesetqtyTextBox.Size = new System.Drawing.Size(28, 20);
            this.typesetqtyTextBox.TabIndex = 25;
            this.typesetqtyTextBox.Leave += new System.EventHandler(this.typesetqtyTextBox_Leave);
            // 
            // wallchprcTextBox
            // 
            this.wallchprcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "wallchprc", true));
            this.wallchprcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallchprcTextBox.Location = new System.Drawing.Point(177, 192);
            this.wallchprcTextBox.Name = "wallchprcTextBox";
            this.wallchprcTextBox.ReadOnly = true;
            this.wallchprcTextBox.Size = new System.Drawing.Size(51, 20);
            this.wallchprcTextBox.TabIndex = 24;
            // 
            // wallchqtyTextBox
            // 
            this.wallchqtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "wallchqty", true));
            this.wallchqtyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallchqtyTextBox.Location = new System.Drawing.Point(143, 192);
            this.wallchqtyTextBox.Name = "wallchqtyTextBox";
            this.wallchqtyTextBox.Size = new System.Drawing.Size(28, 20);
            this.wallchqtyTextBox.TabIndex = 22;
            this.wallchqtyTextBox.Leave += new System.EventHandler(this.wallchqtyTextBox_Leave);
            // 
            // duraglzprcTextBox
            // 
            this.duraglzprcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "duraglzprc", true));
            this.duraglzprcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duraglzprcTextBox.Location = new System.Drawing.Point(177, 169);
            this.duraglzprcTextBox.Name = "duraglzprcTextBox";
            this.duraglzprcTextBox.ReadOnly = true;
            this.duraglzprcTextBox.Size = new System.Drawing.Size(51, 20);
            this.duraglzprcTextBox.TabIndex = 21;
            // 
            // duraglzqtyTextBox
            // 
            this.duraglzqtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "duraglzqty", true));
            this.duraglzqtyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duraglzqtyTextBox.Location = new System.Drawing.Point(144, 172);
            this.duraglzqtyTextBox.Name = "duraglzqtyTextBox";
            this.duraglzqtyTextBox.Size = new System.Drawing.Size(28, 20);
            this.duraglzqtyTextBox.TabIndex = 19;
            this.duraglzqtyTextBox.Leave += new System.EventHandler(this.duraglzqtyTextBox_Leave);
            // 
            // stdttitpgprcTextBox
            // 
            this.stdttitpgprcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "stdttitpgprc", true));
            this.stdttitpgprcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stdttitpgprcTextBox.Location = new System.Drawing.Point(177, 146);
            this.stdttitpgprcTextBox.Name = "stdttitpgprcTextBox";
            this.stdttitpgprcTextBox.ReadOnly = true;
            this.stdttitpgprcTextBox.Size = new System.Drawing.Size(51, 20);
            this.stdttitpgprcTextBox.TabIndex = 18;
            // 
            // stttitpgqtyTextBox
            // 
            this.stttitpgqtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "stttitpgqty", true));
            this.stttitpgqtyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stttitpgqtyTextBox.Location = new System.Drawing.Point(143, 146);
            this.stttitpgqtyTextBox.Name = "stttitpgqtyTextBox";
            this.stttitpgqtyTextBox.Size = new System.Drawing.Size(28, 20);
            this.stttitpgqtyTextBox.TabIndex = 16;
            this.stttitpgqtyTextBox.Leave += new System.EventHandler(this.stttitpgqtyTextBox_Leave);
            // 
            // idpouchprcTextBox
            // 
            this.idpouchprcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "idpouchprc", true));
            this.idpouchprcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idpouchprcTextBox.Location = new System.Drawing.Point(177, 123);
            this.idpouchprcTextBox.Name = "idpouchprcTextBox";
            this.idpouchprcTextBox.ReadOnly = true;
            this.idpouchprcTextBox.Size = new System.Drawing.Size(51, 20);
            this.idpouchprcTextBox.TabIndex = 15;
            // 
            // idpouchqtyTextBox
            // 
            this.idpouchqtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "idpouchqty", true));
            this.idpouchqtyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idpouchqtyTextBox.Location = new System.Drawing.Point(143, 123);
            this.idpouchqtyTextBox.Name = "idpouchqtyTextBox";
            this.idpouchqtyTextBox.Size = new System.Drawing.Size(28, 20);
            this.idpouchqtyTextBox.TabIndex = 13;
            this.idpouchqtyTextBox.Leave += new System.EventHandler(this.idpouchqtyTextBox_Leave);
            // 
            // vpbprcTextBox
            // 
            this.vpbprcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "vpbprc", true));
            this.vpbprcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vpbprcTextBox.Location = new System.Drawing.Point(177, 99);
            this.vpbprcTextBox.Name = "vpbprcTextBox";
            this.vpbprcTextBox.ReadOnly = true;
            this.vpbprcTextBox.Size = new System.Drawing.Size(51, 20);
            this.vpbprcTextBox.TabIndex = 12;
            // 
            // vpbqtyTextBox
            // 
            this.vpbqtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "vpbqty", true));
            this.vpbqtyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vpbqtyTextBox.Location = new System.Drawing.Point(143, 99);
            this.vpbqtyTextBox.Name = "vpbqtyTextBox";
            this.vpbqtyTextBox.Size = new System.Drawing.Size(28, 20);
            this.vpbqtyTextBox.TabIndex = 10;
            this.vpbqtyTextBox.Leave += new System.EventHandler(this.vpbqtyTextBox_Leave);
            // 
            // vpprcTextBox
            // 
            this.vpprcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "vpprc", true));
            this.vpprcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vpprcTextBox.Location = new System.Drawing.Point(177, 75);
            this.vpprcTextBox.Name = "vpprcTextBox";
            this.vpprcTextBox.ReadOnly = true;
            this.vpprcTextBox.Size = new System.Drawing.Size(51, 20);
            this.vpprcTextBox.TabIndex = 9;
            // 
            // vpaqtyTextBox
            // 
            this.vpaqtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "vpaqty", true));
            this.vpaqtyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vpaqtyTextBox.Location = new System.Drawing.Point(143, 75);
            this.vpaqtyTextBox.Name = "vpaqtyTextBox";
            this.vpaqtyTextBox.Size = new System.Drawing.Size(28, 20);
            this.vpaqtyTextBox.TabIndex = 7;
            this.vpaqtyTextBox.Leave += new System.EventHandler(this.vpaqtyTextBox_Leave);
            // 
            // bmarkprcTextBox
            // 
            this.bmarkprcTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "bmarkprc", true));
            this.bmarkprcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bmarkprcTextBox.Location = new System.Drawing.Point(177, 51);
            this.bmarkprcTextBox.Name = "bmarkprcTextBox";
            this.bmarkprcTextBox.ReadOnly = true;
            this.bmarkprcTextBox.Size = new System.Drawing.Size(51, 20);
            this.bmarkprcTextBox.TabIndex = 6;
            // 
            // bmarkqtyTextBox
            // 
            this.bmarkqtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "bmarkqty", true));
            this.bmarkqtyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bmarkqtyTextBox.Location = new System.Drawing.Point(143, 51);
            this.bmarkqtyTextBox.Name = "bmarkqtyTextBox";
            this.bmarkqtyTextBox.Size = new System.Drawing.Size(28, 20);
            this.bmarkqtyTextBox.TabIndex = 4;
            this.bmarkqtyTextBox.Leave += new System.EventHandler(this.bmarkqtyTextBox_Leave);
            // 
            // hallppriceTextBox
            // 
            this.hallppriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "hallprice", true));
            this.hallppriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hallppriceTextBox.Location = new System.Drawing.Point(177, 28);
            this.hallppriceTextBox.Name = "hallppriceTextBox";
            this.hallppriceTextBox.ReadOnly = true;
            this.hallppriceTextBox.Size = new System.Drawing.Size(51, 20);
            this.hallppriceTextBox.TabIndex = 3;
            // 
            // hallpqtyTextBox
            // 
            this.hallpqtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "hallpqty", true));
            this.hallpqtyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hallpqtyTextBox.Location = new System.Drawing.Point(143, 28);
            this.hallpqtyTextBox.Name = "hallpqtyTextBox";
            this.hallpqtyTextBox.Size = new System.Drawing.Size(28, 20);
            this.hallpqtyTextBox.TabIndex = 1;
            this.hallpqtyTextBox.Leave += new System.EventHandler(this.hallpqtyTextBox_Leave);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.afterdisctotLabel2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lblCoverPricetotal);
            this.panel2.Controls.Add(this.lblSchtype);
            this.panel2.Controls.Add(this.disc3CheckBox);
            this.panel2.Controls.Add(this.disc4CheckBox);
            this.panel2.Controls.Add(afterdisctotLabel);
            this.panel2.Controls.Add(this.desc3amtTextBox);
            this.panel2.Controls.Add(this.desc3TextBox);
            this.panel2.Controls.Add(this.desc4amtTextBox);
            this.panel2.Controls.Add(this.desc4TextBox);
            this.panel2.Controls.Add(this.desc1amtTextBox1);
            this.panel2.Controls.Add(this.descamtTextBox);
            this.panel2.Controls.Add(this.desc2TextBox);
            this.panel2.Controls.Add(label3);
            this.panel2.Controls.Add(desc1Label);
            this.panel2.Controls.Add(this.desc1TextBox);
            this.panel2.Controls.Add(label2);
            this.panel2.Controls.Add(this.erldiscamtTextBox);
            this.panel2.Controls.Add(dp1Label);
            this.panel2.Controls.Add(this.dp1TextBox);
            this.panel2.Controls.Add(cvrtotprcLabel);
            this.panel2.Controls.Add(this.hrdcpyprfCheckBox);
            this.panel2.Controls.Add(this.fourclrCheckBox);
            this.panel2.Controls.Add(this.coverapprdCheckBox);
            this.panel2.Controls.Add(this.threeclrCheckBox);
            this.panel2.Controls.Add(this.oneclrCheckBox);
            this.panel2.Controls.Add(this.twoclrCheckBox);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(47, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 156);
            this.panel2.TabIndex = 225;
            // 
            // afterdisctotLabel2
            // 
            this.afterdisctotLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.afterdisctotLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "afterdisctot", true));
            this.afterdisctotLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afterdisctotLabel2.Location = new System.Drawing.Point(1019, 132);
            this.afterdisctotLabel2.Name = "afterdisctotLabel2";
            this.afterdisctotLabel2.Size = new System.Drawing.Size(52, 18);
            this.afterdisctotLabel2.TabIndex = 158;
            this.afterdisctotLabel2.Text = "label9";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(633, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1, 156);
            this.label12.TabIndex = 157;
            this.label12.Text = "label12";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(924, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 7);
            this.label10.TabIndex = 54;
            this.label10.Text = "Negative=Discount / Positive=Charge";
            // 
            // lblCoverPricetotal
            // 
            this.lblCoverPricetotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCoverPricetotal.AutoSize = true;
            this.lblCoverPricetotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "cvrtotprc", true));
            this.lblCoverPricetotal.Location = new System.Drawing.Point(416, 14);
            this.lblCoverPricetotal.Name = "lblCoverPricetotal";
            this.lblCoverPricetotal.Size = new System.Drawing.Size(41, 13);
            this.lblCoverPricetotal.TabIndex = 51;
            this.lblCoverPricetotal.Text = "label9";
            // 
            // lblSchtype
            // 
            this.lblSchtype.Location = new System.Drawing.Point(-1, 145);
            this.lblSchtype.Name = "lblSchtype";
            this.lblSchtype.Size = new System.Drawing.Size(1, 1);
            this.lblSchtype.TabIndex = 50;
            this.lblSchtype.Text = "label9";
            // 
            // disc3CheckBox
            // 
            this.disc3CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disc3CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "disc3", true));
            this.disc3CheckBox.Location = new System.Drawing.Point(666, 106);
            this.disc3CheckBox.Name = "disc3CheckBox";
            this.disc3CheckBox.Size = new System.Drawing.Size(134, 20);
            this.disc3CheckBox.TabIndex = 49;
            this.disc3CheckBox.Text = "25¢ off per planner";
            this.disc3CheckBox.UseVisualStyleBackColor = true;
            this.disc3CheckBox.Click += new System.EventHandler(this.disc3CheckBox_Click);
            // 
            // disc4CheckBox
            // 
            this.disc4CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disc4CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "disc4", true));
            this.disc4CheckBox.Location = new System.Drawing.Point(718, 85);
            this.disc4CheckBox.Name = "disc4CheckBox";
            this.disc4CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.disc4CheckBox.Size = new System.Drawing.Size(80, 15);
            this.disc4CheckBox.TabIndex = 48;
            this.disc4CheckBox.Text = "$100 Off";
            this.disc4CheckBox.UseVisualStyleBackColor = true;
            this.disc4CheckBox.Click += new System.EventHandler(this.disc4CheckBox_Click);
            // 
            // desc3amtTextBox
            // 
            this.desc3amtTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.desc3amtTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "desc3amt", true));
            this.desc3amtTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc3amtTextBox.Location = new System.Drawing.Point(1017, 106);
            this.desc3amtTextBox.Name = "desc3amtTextBox";
            this.desc3amtTextBox.Size = new System.Drawing.Size(52, 20);
            this.desc3amtTextBox.TabIndex = 46;
            this.desc3amtTextBox.Leave += new System.EventHandler(this.desc3amtTextBox_Leave);
            // 
            // desc3TextBox
            // 
            this.desc3TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.desc3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "desc3", true));
            this.desc3TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc3TextBox.Location = new System.Drawing.Point(808, 106);
            this.desc3TextBox.Name = "desc3TextBox";
            this.desc3TextBox.Size = new System.Drawing.Size(205, 20);
            this.desc3TextBox.TabIndex = 45;
            // 
            // desc4amtTextBox
            // 
            this.desc4amtTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.desc4amtTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "desc4amt", true));
            this.desc4amtTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc4amtTextBox.Location = new System.Drawing.Point(1017, 83);
            this.desc4amtTextBox.Name = "desc4amtTextBox";
            this.desc4amtTextBox.Size = new System.Drawing.Size(52, 20);
            this.desc4amtTextBox.TabIndex = 44;
            this.desc4amtTextBox.Leave += new System.EventHandler(this.desc4amtTextBox_Leave);
            // 
            // desc4TextBox
            // 
            this.desc4TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.desc4TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "desc4", true));
            this.desc4TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc4TextBox.Location = new System.Drawing.Point(808, 83);
            this.desc4TextBox.Name = "desc4TextBox";
            this.desc4TextBox.Size = new System.Drawing.Size(205, 20);
            this.desc4TextBox.TabIndex = 43;
            // 
            // desc1amtTextBox1
            // 
            this.desc1amtTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.desc1amtTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "desc1amt", true));
            this.desc1amtTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc1amtTextBox1.Location = new System.Drawing.Point(1017, 38);
            this.desc1amtTextBox1.Name = "desc1amtTextBox1";
            this.desc1amtTextBox1.Size = new System.Drawing.Size(52, 20);
            this.desc1amtTextBox1.TabIndex = 42;
            this.desc1amtTextBox1.Leave += new System.EventHandler(this.desc1amtTextBox1_Leave);
            // 
            // descamtTextBox
            // 
            this.descamtTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.descamtTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "descamt", true));
            this.descamtTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descamtTextBox.Location = new System.Drawing.Point(1017, 61);
            this.descamtTextBox.Name = "descamtTextBox";
            this.descamtTextBox.Size = new System.Drawing.Size(52, 20);
            this.descamtTextBox.TabIndex = 41;
            this.descamtTextBox.Leave += new System.EventHandler(this.descamtTextBox_Leave);
            // 
            // desc2TextBox
            // 
            this.desc2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.desc2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "desc2", true));
            this.desc2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc2TextBox.Location = new System.Drawing.Point(808, 61);
            this.desc2TextBox.Name = "desc2TextBox";
            this.desc2TextBox.Size = new System.Drawing.Size(205, 20);
            this.desc2TextBox.TabIndex = 40;
            // 
            // desc1TextBox
            // 
            this.desc1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.desc1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "desc1", true));
            this.desc1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc1TextBox.Location = new System.Drawing.Point(808, 38);
            this.desc1TextBox.Name = "desc1TextBox";
            this.desc1TextBox.Size = new System.Drawing.Size(205, 20);
            this.desc1TextBox.TabIndex = 38;
            // 
            // erldiscamtTextBox
            // 
            this.erldiscamtTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.erldiscamtTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "erldiscamt", true));
            this.erldiscamtTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erldiscamtTextBox.Location = new System.Drawing.Point(1017, 14);
            this.erldiscamtTextBox.Name = "erldiscamtTextBox";
            this.erldiscamtTextBox.ReadOnly = true;
            this.erldiscamtTextBox.Size = new System.Drawing.Size(52, 20);
            this.erldiscamtTextBox.TabIndex = 35;
            this.erldiscamtTextBox.Leave += new System.EventHandler(this.erldiscamtTextBox_Leave);
            // 
            // dp1TextBox
            // 
            this.dp1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dp1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "dp1", true));
            this.dp1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dp1TextBox.Location = new System.Drawing.Point(977, 14);
            this.dp1TextBox.Name = "dp1TextBox";
            this.dp1TextBox.Size = new System.Drawing.Size(36, 20);
            this.dp1TextBox.TabIndex = 34;
            this.dp1TextBox.Leave += new System.EventHandler(this.dp1TextBox_Leave);
            this.dp1TextBox.Validating += new System.ComponentModel.CancelEventHandler(this.dp1TextBox_Validating);
            // 
            // hrdcpyprfCheckBox
            // 
            this.hrdcpyprfCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hrdcpyprfCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "hrdcpyprf", true));
            this.hrdcpyprfCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hrdcpyprfCheckBox.Location = new System.Drawing.Point(174, 34);
            this.hrdcpyprfCheckBox.Name = "hrdcpyprfCheckBox";
            this.hrdcpyprfCheckBox.Size = new System.Drawing.Size(122, 24);
            this.hrdcpyprfCheckBox.TabIndex = 32;
            this.hrdcpyprfCheckBox.Text = "Hard Copy Proof";
            this.hrdcpyprfCheckBox.UseVisualStyleBackColor = true;
            // 
            // fourclrCheckBox
            // 
            this.fourclrCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "fourclr", true));
            this.fourclrCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fourclrCheckBox.Location = new System.Drawing.Point(8, 12);
            this.fourclrCheckBox.Name = "fourclrCheckBox";
            this.fourclrCheckBox.Size = new System.Drawing.Size(104, 24);
            this.fourclrCheckBox.TabIndex = 23;
            this.fourclrCheckBox.Text = "4-Color Cover";
            this.fourclrCheckBox.UseVisualStyleBackColor = true;
            this.fourclrCheckBox.Click += new System.EventHandler(this.fourclrCheckBox_Click);
            // 
            // coverapprdCheckBox
            // 
            this.coverapprdCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.coverapprdCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "coverapprd", true));
            this.coverapprdCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coverapprdCheckBox.Location = new System.Drawing.Point(174, 12);
            this.coverapprdCheckBox.Name = "coverapprdCheckBox";
            this.coverapprdCheckBox.Size = new System.Drawing.Size(129, 24);
            this.coverapprdCheckBox.TabIndex = 31;
            this.coverapprdCheckBox.Text = "Cover Approved";
            this.coverapprdCheckBox.UseVisualStyleBackColor = true;
            // 
            // threeclrCheckBox
            // 
            this.threeclrCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "threeclr", true));
            this.threeclrCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threeclrCheckBox.Location = new System.Drawing.Point(8, 34);
            this.threeclrCheckBox.Name = "threeclrCheckBox";
            this.threeclrCheckBox.Size = new System.Drawing.Size(104, 24);
            this.threeclrCheckBox.TabIndex = 25;
            this.threeclrCheckBox.Text = "3-Color Cover";
            this.threeclrCheckBox.UseVisualStyleBackColor = true;
            this.threeclrCheckBox.Click += new System.EventHandler(this.threeclrCheckBox_Click);
            // 
            // oneclrCheckBox
            // 
            this.oneclrCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "oneclr", true));
            this.oneclrCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneclrCheckBox.Location = new System.Drawing.Point(8, 83);
            this.oneclrCheckBox.Name = "oneclrCheckBox";
            this.oneclrCheckBox.Size = new System.Drawing.Size(104, 24);
            this.oneclrCheckBox.TabIndex = 29;
            this.oneclrCheckBox.Text = "1-Color Cover";
            this.oneclrCheckBox.UseVisualStyleBackColor = true;
            this.oneclrCheckBox.Click += new System.EventHandler(this.oneclrCheckBox_Click);
            // 
            // twoclrCheckBox
            // 
            this.twoclrCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "twoclr", true));
            this.twoclrCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoclrCheckBox.Location = new System.Drawing.Point(8, 59);
            this.twoclrCheckBox.Name = "twoclrCheckBox";
            this.twoclrCheckBox.Size = new System.Drawing.Size(104, 24);
            this.twoclrCheckBox.TabIndex = 27;
            this.twoclrCheckBox.Text = "2-Color Cover";
            this.twoclrCheckBox.UseVisualStyleBackColor = true;
            this.twoclrCheckBox.Click += new System.EventHandler(this.twoclrCheckBox_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblsbtot);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.lblQtyTotal);
            this.panel3.Controls.Add(this.lblTotalBasePrice);
            this.panel3.Controls.Add(this.lblTeachBasePrice);
            this.panel3.Controls.Add(this.lblBasePrice);
            this.panel3.Controls.Add(wghtLabel);
            this.panel3.Controls.Add(this.wghtTextBox);
            this.panel3.Controls.Add(this.chkJostens);
            this.panel3.Controls.Add(this.chkGeneric);
            this.panel3.Controls.Add(this.line);
            this.panel3.Controls.Add(basetotLabel1);
            this.panel3.Controls.Add(basetotLabel);
            this.panel3.Controls.Add(baseprcLabel);
            this.panel3.Controls.Add(priceovrdLabel);
            this.panel3.Controls.Add(this.txtPriceOverRide);
            this.panel3.Controls.Add(nopagesLabel);
            this.panel3.Controls.Add(this.txtNoPages);
            this.panel3.Controls.Add(qtytotLabel);
            this.panel3.Controls.Add(qtystudLabel);
            this.panel3.Controls.Add(this.txtQtyStudent);
            this.panel3.Controls.Add(qtyteacherLabel);
            this.panel3.Controls.Add(this.txtQtyTeacher);
            this.panel3.Controls.Add(sbtotLabel);
            this.panel3.Controls.Add(this.mdescTextBox);
            this.panel3.Controls.Add(mdescLabel);
            this.panel3.Controls.Add(this.txtmisc);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(46, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1085, 85);
            this.panel3.TabIndex = 224;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(634, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1, 83);
            this.label11.TabIndex = 156;
            this.label11.Text = "label11";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(441, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 1);
            this.label9.TabIndex = 155;
            // 
            // lblsbtot
            // 
            this.lblsbtot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsbtot.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "sbtot", true));
            this.lblsbtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsbtot.Location = new System.Drawing.Point(1020, 42);
            this.lblsbtot.Name = "lblsbtot";
            this.lblsbtot.Size = new System.Drawing.Size(57, 20);
            this.lblsbtot.TabIndex = 154;
            this.lblsbtot.Text = "sbtot";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(926, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 7);
            this.label14.TabIndex = 53;
            this.label14.Text = "Negative=Discount / Positive=Charge";
            // 
            // lblQtyTotal
            // 
            this.lblQtyTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "qtytot", true));
            this.lblQtyTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyTotal.Location = new System.Drawing.Point(89, 61);
            this.lblQtyTotal.Name = "lblQtyTotal";
            this.lblQtyTotal.Size = new System.Drawing.Size(51, 23);
            this.lblQtyTotal.TabIndex = 153;
            this.lblQtyTotal.Text = "label9";
            // 
            // lblTotalBasePrice
            // 
            this.lblTotalBasePrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "basetot", true));
            this.lblTotalBasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBasePrice.Location = new System.Drawing.Point(438, 61);
            this.lblTotalBasePrice.Name = "lblTotalBasePrice";
            this.lblTotalBasePrice.Size = new System.Drawing.Size(51, 19);
            this.lblTotalBasePrice.TabIndex = 152;
            this.lblTotalBasePrice.Text = "label9";
            // 
            // lblTeachBasePrice
            // 
            this.lblTeachBasePrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "TeBasePrc", true));
            this.lblTeachBasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeachBasePrice.Location = new System.Drawing.Point(438, 36);
            this.lblTeachBasePrice.Name = "lblTeachBasePrice";
            this.lblTeachBasePrice.Size = new System.Drawing.Size(33, 20);
            this.lblTeachBasePrice.TabIndex = 151;
            this.lblTeachBasePrice.Text = "label9";
            // 
            // lblBasePrice
            // 
            this.lblBasePrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "baseprc", true));
            this.lblBasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasePrice.Location = new System.Drawing.Point(437, 16);
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(33, 17);
            this.lblBasePrice.TabIndex = 51;
            this.lblBasePrice.Text = "label9";
            // 
            // wghtTextBox
            // 
            this.wghtTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "wght", true));
            this.wghtTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wghtTextBox.Location = new System.Drawing.Point(544, 61);
            this.wghtTextBox.Name = "wghtTextBox";
            this.wghtTextBox.Size = new System.Drawing.Size(44, 20);
            this.wghtTextBox.TabIndex = 50;
            this.wghtTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.wghtTextBox_Validating);
            // 
            // chkJostens
            // 
            this.chkJostens.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "jostens", true));
            this.chkJostens.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkJostens.Location = new System.Drawing.Point(492, 28);
            this.chkJostens.Name = "chkJostens";
            this.chkJostens.Size = new System.Drawing.Size(70, 24);
            this.chkJostens.TabIndex = 49;
            this.chkJostens.Text = "Jostens";
            this.chkJostens.UseVisualStyleBackColor = true;
            this.chkJostens.Click += new System.EventHandler(this.chkJostens_Click);
            // 
            // chkGeneric
            // 
            this.chkGeneric.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mbidsBindingSource, "generic", true));
            this.chkGeneric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGeneric.Location = new System.Drawing.Point(492, 9);
            this.chkGeneric.Name = "chkGeneric";
            this.chkGeneric.Size = new System.Drawing.Size(70, 24);
            this.chkGeneric.TabIndex = 48;
            this.chkGeneric.Text = "Generic";
            this.chkGeneric.UseVisualStyleBackColor = true;
            this.chkGeneric.Click += new System.EventHandler(this.chkGeneric_Click);
            // 
            // line
            // 
            this.line.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.line.Location = new System.Drawing.Point(89, 57);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(57, 1);
            this.line.TabIndex = 45;
            // 
            // txtPriceOverRide
            // 
            this.txtPriceOverRide.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "priceovrd", true));
            this.txtPriceOverRide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceOverRide.Location = new System.Drawing.Point(242, 61);
            this.txtPriceOverRide.Name = "txtPriceOverRide";
            this.txtPriceOverRide.Size = new System.Drawing.Size(32, 20);
            this.txtPriceOverRide.TabIndex = 41;
            this.txtPriceOverRide.Leave += new System.EventHandler(this.txtPriceOverRide_Leave);
            // 
            // txtNoPages
            // 
            this.txtNoPages.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "nopages", true));
            this.txtNoPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoPages.Location = new System.Drawing.Point(242, 13);
            this.txtNoPages.Name = "txtNoPages";
            this.txtNoPages.Size = new System.Drawing.Size(32, 20);
            this.txtNoPages.TabIndex = 40;
            this.txtNoPages.Leave += new System.EventHandler(this.txtNoPages_Leave);
            // 
            // txtQtyStudent
            // 
            this.txtQtyStudent.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "qtystud", true));
            this.txtQtyStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyStudent.Location = new System.Drawing.Point(92, 13);
            this.txtQtyStudent.Name = "txtQtyStudent";
            this.txtQtyStudent.Size = new System.Drawing.Size(47, 20);
            this.txtQtyStudent.TabIndex = 38;
            this.txtQtyStudent.Leave += new System.EventHandler(this.txtQtyStudent_Leave);
            this.txtQtyStudent.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtyStudent_Validating);
            // 
            // txtQtyTeacher
            // 
            this.txtQtyTeacher.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "qtyteacher", true));
            this.txtQtyTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyTeacher.Location = new System.Drawing.Point(92, 36);
            this.txtQtyTeacher.Name = "txtQtyTeacher";
            this.txtQtyTeacher.Size = new System.Drawing.Size(47, 20);
            this.txtQtyTeacher.TabIndex = 37;
            this.txtQtyTeacher.Leave += new System.EventHandler(this.txtQtyTeacher_Leave);
            // 
            // mdescTextBox
            // 
            this.mdescTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mdescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "mdesc", true));
            this.mdescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdescTextBox.Location = new System.Drawing.Point(811, 13);
            this.mdescTextBox.Name = "mdescTextBox";
            this.mdescTextBox.Size = new System.Drawing.Size(205, 20);
            this.mdescTextBox.TabIndex = 34;
            // 
            // txtmisc
            // 
            this.txtmisc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmisc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "misc", true));
            this.txtmisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmisc.Location = new System.Drawing.Point(1020, 13);
            this.txtmisc.Name = "txtmisc";
            this.txtmisc.Size = new System.Drawing.Size(52, 20);
            this.txtmisc.TabIndex = 35;
            this.txtmisc.Leave += new System.EventHandler(this.txtmisc_Leave);
            // 
            // mbidsTableAdapter
            // 
            this.mbidsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.mbidsTableAdapter = this.mbidsTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsMBidsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // meridianProductsTableAdapter
            // 
            this.meridianProductsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
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
            this.tableAdapterManager1.lkpSupplyItemsTableAdapter = null;
            this.tableAdapterManager1.lkpTypeContTableAdapter = null;
            this.tableAdapterManager1.lkTypeDataTableAdapter = null;
            this.tableAdapterManager1.MeridianProductsTableAdapter = this.meridianProductsTableAdapter;
            this.tableAdapterManager1.UpdateOrder = Mbc5.DataSets.LookUpTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // idLabel1
            // 
            this.idLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.idLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mbidsBindingSource, "Id", true));
            this.idLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel1.Location = new System.Drawing.Point(695, 37);
            this.idLabel1.Name = "idLabel1";
            this.idLabel1.Size = new System.Drawing.Size(87, 19);
            this.idLabel1.TabIndex = 162;
            this.idLabel1.Text = "id";
            // 
            // OnlineFlyerBindingSource
            // 
            this.OnlineFlyerBindingSource.DataSource = typeof(BindingModels.OnlineFlyer);
            // 
            // frmMBids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1143, 741);
            this.Controls.Add(this.idLabel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(orderDateLabel);
            this.Controls.Add(this.orderDateDateTimePicker);
            this.Controls.Add(qtedateLabel);
            this.Controls.Add(this.qtedateDateTimePicker);
            this.Controls.Add(this.oaCheckBox);
            this.Controls.Add(this.contryearTextBox);
            this.Controls.Add(this.txtBYear);
            this.Controls.Add(sourceLabel);
            this.Controls.Add(this.sourceTextBox);
            this.Controls.Add(invnoLabel);
            this.Controls.Add(bpyearLabel);
            this.Controls.Add(contryearLabel);
            this.Controls.Add(this.prodcodeComboBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(sfLabel);
            this.Controls.Add(ponumLabel);
            this.Controls.Add(this.ponumTextBox);
            this.Controls.Add(this.lblSchname);
            this.Controls.Add(schcodeLabel);
            this.Controls.Add(this.schcodeLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1123, 700);
            this.Name = "frmMBids";
            this.Text = "Bids";
            this.Activated += new System.EventHandler(this.frmMBids_Activated);
            this.Deactivate += new System.EventHandler(this.frmMBids_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMBids_FormClosing);
            this.Load += new System.EventHandler(this.frmMBids_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MBidInvoiceDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mbidsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMBids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meridianProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineFlyerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TextBox contryearTextBox;
        private System.Windows.Forms.TextBox txtBYear;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.ComboBox prodcodeComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton sfRadioButton;
        private System.Windows.Forms.RadioButton lfRadioButton;
        private System.Windows.Forms.TextBox ponumTextBox;
        private System.Windows.Forms.Label lblSchname;
        private System.Windows.Forms.Label schcodeLabel1;
        private DataSets.dsMBids dsMBids;
        private System.Windows.Forms.BindingSource mbidsBindingSource;
        private DataSets.dsMBidsTableAdapters.mbidsTableAdapter mbidsTableAdapter;
        private DataSets.dsMBidsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.CheckBox oaCheckBox;
        private Classes.NullableDateTimePicker qtedateDateTimePicker;
        private Classes.NullableDateTimePicker orderDateDateTimePicker;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTotalOptions;
        private System.Windows.Forms.Label lblSpecialCoverPrice;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTaxRate;
        private System.Windows.Forms.Label lblFinalTotal;
        private System.Windows.Forms.Label lblFinalPrice;
        private System.Windows.Forms.Label lblAppUser;
        private System.Windows.Forms.CheckBox doNotChargeTaxCheckBox;
        private System.Windows.Forms.TextBox txtShipping;
        private System.Windows.Forms.CheckBox custpuCheckBox;
        private System.Windows.Forms.TextBox desc4TextBox1;
        private System.Windows.Forms.TextBox desc3TextBox1;
        private System.Windows.Forms.TextBox desc2TextBox1;
        private System.Windows.Forms.TextBox impquidprcTextBox;
        private System.Windows.Forms.TextBox txtImpGuideQty;
        private System.Windows.Forms.TextBox typesetprcTextBox;
        private System.Windows.Forms.TextBox typesetqtyTextBox;
        private System.Windows.Forms.TextBox wallchprcTextBox;
        private System.Windows.Forms.TextBox wallchqtyTextBox;
        private System.Windows.Forms.TextBox duraglzprcTextBox;
        private System.Windows.Forms.TextBox duraglzqtyTextBox;
        private System.Windows.Forms.TextBox stdttitpgprcTextBox;
        private System.Windows.Forms.TextBox stttitpgqtyTextBox;
        private System.Windows.Forms.TextBox idpouchprcTextBox;
        private System.Windows.Forms.TextBox idpouchqtyTextBox;
        private System.Windows.Forms.TextBox vpbprcTextBox;
        private System.Windows.Forms.TextBox vpbqtyTextBox;
        private System.Windows.Forms.TextBox vpprcTextBox;
        private System.Windows.Forms.TextBox vpaqtyTextBox;
        private System.Windows.Forms.TextBox bmarkprcTextBox;
        private System.Windows.Forms.TextBox bmarkqtyTextBox;
        private System.Windows.Forms.TextBox hallppriceTextBox;
        private System.Windows.Forms.TextBox hallpqtyTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCoverPricetotal;
        private System.Windows.Forms.Label lblSchtype;
        private System.Windows.Forms.CheckBox disc3CheckBox;
        private System.Windows.Forms.CheckBox disc4CheckBox;
        private System.Windows.Forms.TextBox desc3amtTextBox;
        private System.Windows.Forms.TextBox desc3TextBox;
        private System.Windows.Forms.TextBox desc4amtTextBox;
        private System.Windows.Forms.TextBox desc4TextBox;
        private System.Windows.Forms.TextBox desc1amtTextBox1;
        private System.Windows.Forms.TextBox descamtTextBox;
        private System.Windows.Forms.TextBox desc2TextBox;
        private System.Windows.Forms.TextBox desc1TextBox;
        private System.Windows.Forms.TextBox erldiscamtTextBox;
        private System.Windows.Forms.TextBox dp1TextBox;
        private System.Windows.Forms.CheckBox hrdcpyprfCheckBox;
        private System.Windows.Forms.CheckBox fourclrCheckBox;
        private System.Windows.Forms.CheckBox coverapprdCheckBox;
        private System.Windows.Forms.CheckBox threeclrCheckBox;
        private System.Windows.Forms.CheckBox oneclrCheckBox;
        private System.Windows.Forms.CheckBox twoclrCheckBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblsbtot;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblQtyTotal;
        private System.Windows.Forms.Label lblTotalBasePrice;
        private System.Windows.Forms.Label lblTeachBasePrice;
        private System.Windows.Forms.Label lblBasePrice;
        private System.Windows.Forms.TextBox wghtTextBox;
        private System.Windows.Forms.CheckBox chkJostens;
        private System.Windows.Forms.CheckBox chkGeneric;
        private System.Windows.Forms.Label line;
        private System.Windows.Forms.TextBox txtPriceOverRide;
        private System.Windows.Forms.TextBox txtNoPages;
        private System.Windows.Forms.TextBox txtQtyStudent;
        private System.Windows.Forms.TextBox txtQtyTeacher;
        private System.Windows.Forms.TextBox mdescTextBox;
        private System.Windows.Forms.TextBox txtmisc;
        private System.Windows.Forms.CheckBox reOrderCheckBox;
        private System.Windows.Forms.Button btnPrnQuote;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DataSets.LookUp lookUp;
        private System.Windows.Forms.BindingSource meridianProductsBindingSource;
        private DataSets.LookUpTableAdapters.MeridianProductsTableAdapter meridianProductsTableAdapter;
        private DataSets.LookUpTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label idLabel1;
        private System.Windows.Forms.Label afterdisctotLabel2;
        private System.Windows.Forms.TextBox adcdescTextBox;
        private System.Windows.Forms.TextBox txtAdditionChrg;
        private System.Windows.Forms.Label lblModifiedby;
        private System.Windows.Forms.CheckBox chkPrntAsInvoice;
        private System.Windows.Forms.BindingSource MBidInvoiceDetailBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OnlineFlyerBindingSource;
    }
    }
