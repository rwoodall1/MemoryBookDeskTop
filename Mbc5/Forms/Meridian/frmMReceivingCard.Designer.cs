namespace Mbc5.Forms.MemoryBook {
	partial class frmMReceivingCard {
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
            System.Windows.Forms.Label kitReceivedDateLabel;
            System.Windows.Forms.Label guardteLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label contractYearLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMReceivingCard));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            this.rCardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRcard = new Mbc5.DataSets.dsRcard();
            this.schnameLabel1 = new System.Windows.Forms.Label();
            this.ck1CheckBox = new System.Windows.Forms.CheckBox();
            this.ck2CheckBox = new System.Windows.Forms.CheckBox();
            this.ck3CheckBox = new System.Windows.Forms.CheckBox();
            this.paymentsTextBox = new System.Windows.Forms.TextBox();
            this.ck4CheckBox = new System.Windows.Forms.CheckBox();
            this.baldueTextBox = new System.Windows.Forms.TextBox();
            this.ck8CheckBox = new System.Windows.Forms.CheckBox();
            this.coverDescTextBox = new System.Windows.Forms.TextBox();
            this.hdbky_nCheckBox = new System.Windows.Forms.CheckBox();
            this.casey_nCheckBox = new System.Windows.Forms.CheckBox();
            this.spirckCheckBox = new System.Windows.Forms.CheckBox();
            this.perfBindCheckBox = new System.Windows.Forms.CheckBox();
            this.sdlStichCheckBox = new System.Windows.Forms.CheckBox();
            this.allClrckCheckBox = new System.Windows.Forms.CheckBox();
            this.clrpgckCheckBox = new System.Windows.Forms.CheckBox();
            this.appCheckBox = new System.Windows.Forms.CheckBox();
            this.comckCheckBox = new System.Windows.Forms.CheckBox();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.add1TextBox = new System.Windows.Forms.TextBox();
            this.add2TextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.zipTextBox = new System.Windows.Forms.TextBox();
            this.noPayRecvTextBox = new System.Windows.Forms.TextBox();
            this.idLabel1 = new System.Windows.Forms.Label();
            this.dateCreatedLabel1 = new System.Windows.Forms.Label();
            this.bnRcard = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.contractYearLabel1 = new System.Windows.Forms.Label();
            this.invnoLabel1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.deadlineLabel1 = new System.Windows.Forms.Label();
            this.kitreceivedDateLabel2 = new System.Windows.Forms.Label();
            this.guardteDateBox = new CustomControls.DateBox();
            this.estDateDateBox = new CustomControls.DateBox();
            this.lblSchcode = new System.Windows.Forms.Label();
            this.rCardTableAdapter = new Mbc5.DataSets.dsRcardTableAdapters.RCardTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsRcardTableAdapters.TableAdapterManager();
            this.txtPlannerType = new System.Windows.Forms.TextBox();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.txtStudentCopies = new System.Windows.Forms.TextBox();
            this.txtTeachersCopies = new System.Windows.Forms.TextBox();
            this.txtTotalCopies = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            kitReceivedDateLabel = new System.Windows.Forms.Label();
            guardteLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            contractYearLabel = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rCardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRcard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnRcard)).BeginInit();
            this.bnRcard.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.label9);
            this.TopPanel.Controls.Add(this.invnoLabel1);
            this.TopPanel.Controls.Add(contractYearLabel);
            this.TopPanel.Controls.Add(this.contractYearLabel1);
            this.TopPanel.Controls.Add(dateCreatedLabel);
            this.TopPanel.Controls.Add(this.dateCreatedLabel1);
            this.TopPanel.Controls.Add(idLabel);
            this.TopPanel.Controls.Add(this.idLabel1);
            this.TopPanel.Controls.Add(this.schnameLabel1);
            this.TopPanel.Size = new System.Drawing.Size(862, 56);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Location = new System.Drawing.Point(0, 766);
            this.BottomPanel.Size = new System.Drawing.Size(862, 10);
            // 
            // kitReceivedDateLabel
            // 
            kitReceivedDateLabel.AutoSize = true;
            kitReceivedDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            kitReceivedDateLabel.Location = new System.Drawing.Point(23, 62);
            kitReceivedDateLabel.Name = "kitReceivedDateLabel";
            kitReceivedDateLabel.Size = new System.Drawing.Size(141, 13);
            kitReceivedDateLabel.TabIndex = 2;
            kitReceivedDateLabel.Text = "We receive your planner on ";
            // 
            // guardteLabel
            // 
            guardteLabel.AutoSize = true;
            guardteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            guardteLabel.Location = new System.Drawing.Point(226, 92);
            guardteLabel.Name = "guardteLabel";
            guardteLabel.Size = new System.Drawing.Size(159, 13);
            guardteLabel.TabIndex = 5;
            guardteLabel.Text = "Your guaranteed delivery date is";
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(234, 115);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(279, 18);
            label1.TabIndex = 10;
            label1.Text = "You missed your deadline so this will alter your delivery. ";
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(23, 141);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(252, 18);
            label2.TabIndex = 11;
            label2.Text = " Your ESTIMATED (not guaranteed) delivery date is";
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(23, 167);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(528, 36);
            label3.TabIndex = 16;
            label3.Text = "Should youl require less than the published production schedules, the order is su" +
    "bject to an expediting/overtime fee if production time is available.  ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(23, 461);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(187, 13);
            label7.TabIndex = 35;
            label7.Text = "You also chose these custom features";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(23, 629);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(128, 13);
            label8.TabIndex = 64;
            label8.Text = "Planner Shipping Address";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(555, 9);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(57, 13);
            idLabel.TabIndex = 1;
            idLabel.Text = "Card No.";
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(527, 33);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(86, 13);
            dateCreatedLabel.TabIndex = 3;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // contractYearLabel
            // 
            contractYearLabel.AutoSize = true;
            contractYearLabel.Location = new System.Drawing.Point(18, 9);
            contractYearLabel.Name = "contractYearLabel";
            contractYearLabel.Size = new System.Drawing.Size(33, 13);
            contractYearLabel.TabIndex = 5;
            contractYearLabel.Text = "Year";
            // 
            // rCardBindingSource
            // 
            this.rCardBindingSource.DataMember = "RCard";
            this.rCardBindingSource.DataSource = this.dsRcard;
            // 
            // dsRcard
            // 
            this.dsRcard.DataSetName = "dsRcard";
            this.dsRcard.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // schnameLabel1
            // 
            this.schnameLabel1.AutoSize = true;
            this.schnameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Schname", true));
            this.schnameLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schnameLabel1.Location = new System.Drawing.Point(256, 23);
            this.schnameLabel1.Name = "schnameLabel1";
            this.schnameLabel1.Size = new System.Drawing.Size(105, 26);
            this.schnameLabel1.TabIndex = 1;
            this.schnameLabel1.Text = "Schname";
            // 
            // ck1CheckBox
            // 
            this.ck1CheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ck1CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "Ck1", true));
            this.ck1CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck1CheckBox.Location = new System.Drawing.Point(23, 90);
            this.ck1CheckBox.Name = "ck1CheckBox";
            this.ck1CheckBox.Size = new System.Drawing.Size(193, 16);
            this.ck1CheckBox.TabIndex = 5;
            this.ck1CheckBox.Text = "Your planner arrived on schedule ";
            this.ck1CheckBox.UseVisualStyleBackColor = true;
            // 
            // ck2CheckBox
            // 
            this.ck2CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "Ck2", true));
            this.ck2CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck2CheckBox.Location = new System.Drawing.Point(23, 115);
            this.ck2CheckBox.Name = "ck2CheckBox";
            this.ck2CheckBox.Size = new System.Drawing.Size(121, 20);
            this.ck2CheckBox.TabIndex = 8;
            this.ck2CheckBox.Text = "Your deadline was";
            this.ck2CheckBox.UseVisualStyleBackColor = true;
            // 
            // ck3CheckBox
            // 
            this.ck3CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "Ck3", true));
            this.ck3CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck3CheckBox.Location = new System.Drawing.Point(23, 202);
            this.ck3CheckBox.Name = "ck3CheckBox";
            this.ck3CheckBox.Size = new System.Drawing.Size(148, 20);
            this.ck3CheckBox.TabIndex = 20;
            this.ck3CheckBox.Text = "We received payment of";
            this.ck3CheckBox.UseVisualStyleBackColor = true;
            // 
            // paymentsTextBox
            // 
            this.paymentsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Payments", true));
            this.paymentsTextBox.Location = new System.Drawing.Point(163, 202);
            this.paymentsTextBox.Name = "paymentsTextBox";
            this.paymentsTextBox.Size = new System.Drawing.Size(77, 20);
            this.paymentsTextBox.TabIndex = 21;
            // 
            // ck4CheckBox
            // 
            this.ck4CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "Ck4", true));
            this.ck4CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck4CheckBox.Location = new System.Drawing.Point(23, 227);
            this.ck4CheckBox.Name = "ck4CheckBox";
            this.ck4CheckBox.Size = new System.Drawing.Size(104, 15);
            this.ck4CheckBox.TabIndex = 22;
            this.ck4CheckBox.Text = "Your balance is";
            this.ck4CheckBox.UseVisualStyleBackColor = true;
            // 
            // baldueTextBox
            // 
            this.baldueTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Baldue", true));
            this.baldueTextBox.Location = new System.Drawing.Point(126, 224);
            this.baldueTextBox.Name = "baldueTextBox";
            this.baldueTextBox.Size = new System.Drawing.Size(75, 20);
            this.baldueTextBox.TabIndex = 23;
            // 
            // ck8CheckBox
            // 
            this.ck8CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "Ck8", true));
            this.ck8CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck8CheckBox.Location = new System.Drawing.Point(23, 303);
            this.ck8CheckBox.Name = "ck8CheckBox";
            this.ck8CheckBox.Size = new System.Drawing.Size(183, 19);
            this.ck8CheckBox.TabIndex = 33;
            this.ck8CheckBox.Text = "The cover option you chose was ";
            this.ck8CheckBox.UseVisualStyleBackColor = true;
            // 
            // coverDescTextBox
            // 
            this.coverDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "CoverDesc", true));
            this.coverDescTextBox.Location = new System.Drawing.Point(204, 302);
            this.coverDescTextBox.Name = "coverDescTextBox";
            this.coverDescTextBox.Size = new System.Drawing.Size(320, 20);
            this.coverDescTextBox.TabIndex = 34;
            // 
            // hdbky_nCheckBox
            // 
            this.hdbky_nCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "HallPass", true));
            this.hdbky_nCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdbky_nCheckBox.Location = new System.Drawing.Point(30, 477);
            this.hdbky_nCheckBox.Name = "hdbky_nCheckBox";
            this.hdbky_nCheckBox.Size = new System.Drawing.Size(104, 19);
            this.hdbky_nCheckBox.TabIndex = 36;
            this.hdbky_nCheckBox.Text = "Hall Pass";
            this.hdbky_nCheckBox.UseVisualStyleBackColor = true;
            // 
            // casey_nCheckBox
            // 
            this.casey_nCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "BookMark", true));
            this.casey_nCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.casey_nCheckBox.Location = new System.Drawing.Point(30, 498);
            this.casey_nCheckBox.Name = "casey_nCheckBox";
            this.casey_nCheckBox.Size = new System.Drawing.Size(104, 19);
            this.casey_nCheckBox.TabIndex = 37;
            this.casey_nCheckBox.Text = "Book Mark";
            this.casey_nCheckBox.UseVisualStyleBackColor = true;
            // 
            // spirckCheckBox
            // 
            this.spirckCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "VPA", true));
            this.spirckCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spirckCheckBox.Location = new System.Drawing.Point(30, 517);
            this.spirckCheckBox.Name = "spirckCheckBox";
            this.spirckCheckBox.Size = new System.Drawing.Size(104, 19);
            this.spirckCheckBox.TabIndex = 39;
            this.spirckCheckBox.Text = "Viny Pocket A";
            this.spirckCheckBox.UseVisualStyleBackColor = true;
            // 
            // perfBindCheckBox
            // 
            this.perfBindCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "VPB", true));
            this.perfBindCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perfBindCheckBox.Location = new System.Drawing.Point(30, 534);
            this.perfBindCheckBox.Name = "perfBindCheckBox";
            this.perfBindCheckBox.Size = new System.Drawing.Size(104, 19);
            this.perfBindCheckBox.TabIndex = 41;
            this.perfBindCheckBox.Text = "Viny Pocket B";
            this.perfBindCheckBox.UseVisualStyleBackColor = true;
            // 
            // sdlStichCheckBox
            // 
            this.sdlStichCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "IdPouch", true));
            this.sdlStichCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sdlStichCheckBox.Location = new System.Drawing.Point(156, 477);
            this.sdlStichCheckBox.Name = "sdlStichCheckBox";
            this.sdlStichCheckBox.Size = new System.Drawing.Size(104, 19);
            this.sdlStichCheckBox.TabIndex = 43;
            this.sdlStichCheckBox.Text = "Id Pouch";
            this.sdlStichCheckBox.UseVisualStyleBackColor = true;
            // 
            // allClrckCheckBox
            // 
            this.allClrckCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "StdPg", true));
            this.allClrckCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allClrckCheckBox.Location = new System.Drawing.Point(156, 498);
            this.allClrckCheckBox.Name = "allClrckCheckBox";
            this.allClrckCheckBox.Size = new System.Drawing.Size(104, 19);
            this.allClrckCheckBox.TabIndex = 45;
            this.allClrckCheckBox.Text = "Standard Title Page";
            this.allClrckCheckBox.UseVisualStyleBackColor = true;
            // 
            // clrpgckCheckBox
            // 
            this.clrpgckCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "DuraGlz", true));
            this.clrpgckCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clrpgckCheckBox.Location = new System.Drawing.Point(156, 517);
            this.clrpgckCheckBox.Name = "clrpgckCheckBox";
            this.clrpgckCheckBox.Size = new System.Drawing.Size(104, 19);
            this.clrpgckCheckBox.TabIndex = 47;
            this.clrpgckCheckBox.Text = "DuraGlaze Cover";
            this.clrpgckCheckBox.UseVisualStyleBackColor = true;
            // 
            // appCheckBox
            // 
            this.appCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "Wallch", true));
            this.appCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appCheckBox.Location = new System.Drawing.Point(156, 537);
            this.appCheckBox.Name = "appCheckBox";
            this.appCheckBox.Size = new System.Drawing.Size(104, 19);
            this.appCheckBox.TabIndex = 49;
            this.appCheckBox.Text = "Wall Chart";
            this.appCheckBox.UseVisualStyleBackColor = true;
            // 
            // comckCheckBox
            // 
            this.comckCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "Comck", true));
            this.comckCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comckCheckBox.Location = new System.Drawing.Point(31, 559);
            this.comckCheckBox.Name = "comckCheckBox";
            this.comckCheckBox.Size = new System.Drawing.Size(76, 24);
            this.comckCheckBox.TabIndex = 62;
            this.comckCheckBox.Text = "Comments";
            this.comckCheckBox.UseVisualStyleBackColor = true;
            // 
            // commentTextBox
            // 
            this.commentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Comment", true));
            this.commentTextBox.Location = new System.Drawing.Point(105, 563);
            this.commentTextBox.Multiline = true;
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commentTextBox.Size = new System.Drawing.Size(410, 54);
            this.commentTextBox.TabIndex = 63;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(164, 629);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(226, 20);
            this.nameTextBox.TabIndex = 65;
            // 
            // add1TextBox
            // 
            this.add1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Add1", true));
            this.add1TextBox.Location = new System.Drawing.Point(164, 655);
            this.add1TextBox.Name = "add1TextBox";
            this.add1TextBox.Size = new System.Drawing.Size(226, 20);
            this.add1TextBox.TabIndex = 67;
            // 
            // add2TextBox
            // 
            this.add2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Add2", true));
            this.add2TextBox.Location = new System.Drawing.Point(164, 679);
            this.add2TextBox.Name = "add2TextBox";
            this.add2TextBox.Size = new System.Drawing.Size(226, 20);
            this.add2TextBox.TabIndex = 68;
            // 
            // cityTextBox
            // 
            this.cityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "City", true));
            this.cityTextBox.Location = new System.Drawing.Point(164, 704);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(77, 20);
            this.cityTextBox.TabIndex = 69;
            // 
            // stateTextBox
            // 
            this.stateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "State", true));
            this.stateTextBox.Location = new System.Drawing.Point(247, 705);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(32, 20);
            this.stateTextBox.TabIndex = 70;
            // 
            // zipTextBox
            // 
            this.zipTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Zip", true));
            this.zipTextBox.Location = new System.Drawing.Point(285, 704);
            this.zipTextBox.Name = "zipTextBox";
            this.zipTextBox.Size = new System.Drawing.Size(77, 20);
            this.zipTextBox.TabIndex = 71;
            // 
            // noPayRecvTextBox
            // 
            this.noPayRecvTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "NoPayRecv", true));
            this.noPayRecvTextBox.Location = new System.Drawing.Point(23, 790);
            this.noPayRecvTextBox.Multiline = true;
            this.noPayRecvTextBox.Name = "noPayRecvTextBox";
            this.noPayRecvTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.noPayRecvTextBox.Size = new System.Drawing.Size(516, 55);
            this.noPayRecvTextBox.TabIndex = 72;
            // 
            // idLabel1
            // 
            this.idLabel1.AutoSize = true;
            this.idLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Id", true));
            this.idLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel1.Location = new System.Drawing.Point(615, 9);
            this.idLabel1.Name = "idLabel1";
            this.idLabel1.Size = new System.Drawing.Size(15, 13);
            this.idLabel1.TabIndex = 2;
            this.idLabel1.Text = "id";
            // 
            // dateCreatedLabel1
            // 
            this.dateCreatedLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "DateCreated", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.dateCreatedLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCreatedLabel1.Location = new System.Drawing.Point(619, 33);
            this.dateCreatedLabel1.Name = "dateCreatedLabel1";
            this.dateCreatedLabel1.Size = new System.Drawing.Size(100, 13);
            this.dateCreatedLabel1.TabIndex = 4;
            this.dateCreatedLabel1.Text = "datecreated";
            // 
            // bnRcard
            // 
            this.bnRcard.AddNewItem = null;
            this.bnRcard.BindingSource = this.rCardBindingSource;
            this.bnRcard.CountItem = this.bindingNavigatorCountItem;
            this.bnRcard.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnRcard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnRcard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripButton4,
            this.toolStripButton2,
            this.bindingNavigatorDeleteItem,
            this.toolStripButton3,
            this.toolStripButton1});
            this.bnRcard.Location = new System.Drawing.Point(0, 776);
            this.bnRcard.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnRcard.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnRcard.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnRcard.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnRcard.Name = "bnRcard";
            this.bnRcard.PositionItem = this.bindingNavigatorPositionItem;
            this.bnRcard.Size = new System.Drawing.Size(862, 25);
            this.bnRcard.TabIndex = 73;
            this.bnRcard.Text = "bindingNavigator1";
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
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
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
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_ClickAsync);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // contractYearLabel1
            // 
            this.contractYearLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "ContractYear", true));
            this.contractYearLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contractYearLabel1.Location = new System.Drawing.Point(49, 9);
            this.contractYearLabel1.Name = "contractYearLabel1";
            this.contractYearLabel1.Size = new System.Drawing.Size(42, 13);
            this.contractYearLabel1.TabIndex = 6;
            this.contractYearLabel1.Text = "label9";
            // 
            // invnoLabel1
            // 
            this.invnoLabel1.AutoSize = true;
            this.invnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Invno", true));
            this.invnoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invnoLabel1.Location = new System.Drawing.Point(74, 33);
            this.invnoLabel1.Name = "invnoLabel1";
            this.invnoLabel1.Size = new System.Drawing.Size(35, 13);
            this.invnoLabel1.TabIndex = 8;
            this.invnoLabel1.Text = "label9";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Invoice#";
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 35;
            reportDataSource5.Name = "dsReceivingCard";
            reportDataSource5.Value = this.rCardBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.ReceivingCard.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(656, 658);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(113, 66);
            this.reportViewer1.TabIndex = 74;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // deadlineLabel1
            // 
            this.deadlineLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Deadline", true));
            this.deadlineLabel1.Location = new System.Drawing.Point(132, 118);
            this.deadlineLabel1.Name = "deadlineLabel1";
            this.deadlineLabel1.Size = new System.Drawing.Size(100, 23);
            this.deadlineLabel1.TabIndex = 76;
            this.deadlineLabel1.Text = "label10";
            // 
            // kitreceivedDateLabel2
            // 
            this.kitreceivedDateLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "KitreceivedDate", true));
            this.kitreceivedDateLabel2.Location = new System.Drawing.Point(164, 63);
            this.kitreceivedDateLabel2.Name = "kitreceivedDateLabel2";
            this.kitreceivedDateLabel2.Size = new System.Drawing.Size(123, 23);
            this.kitreceivedDateLabel2.TabIndex = 78;
            this.kitreceivedDateLabel2.Text = "label10";
            // 
            // guardteDateBox
            // 
            this.guardteDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.rCardBindingSource, "Guardte", true));
            this.guardteDateBox.Date = null;
            this.guardteDateBox.DateValue = null;
            this.guardteDateBox.Location = new System.Drawing.Point(391, 91);
            this.guardteDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.guardteDateBox.Name = "guardteDateBox";
            this.guardteDateBox.Size = new System.Drawing.Size(133, 21);
            this.guardteDateBox.TabIndex = 79;
            // 
            // estDateDateBox
            // 
            this.estDateDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.rCardBindingSource, "EstDate", true));
            this.estDateDateBox.Date = null;
            this.estDateDateBox.DateValue = null;
            this.estDateDateBox.Location = new System.Drawing.Point(279, 138);
            this.estDateDateBox.MinimumSize = new System.Drawing.Size(133, 20);
            this.estDateDateBox.Name = "estDateDateBox";
            this.estDateDateBox.Size = new System.Drawing.Size(133, 21);
            this.estDateDateBox.TabIndex = 80;
            // 
            // lblSchcode
            // 
            this.lblSchcode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Schcode", true));
            this.lblSchcode.Location = new System.Drawing.Point(829, 59);
            this.lblSchcode.Name = "lblSchcode";
            this.lblSchcode.Size = new System.Drawing.Size(1, 1);
            this.lblSchcode.TabIndex = 82;
            this.lblSchcode.Text = "schcode";
            // 
            // rCardTableAdapter
            // 
            this.rCardTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.RCardTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsRcardTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // txtPlannerType
            // 
            this.txtPlannerType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "SchType", true));
            this.txtPlannerType.Location = new System.Drawing.Point(149, 249);
            this.txtPlannerType.Name = "txtPlannerType";
            this.txtPlannerType.Size = new System.Drawing.Size(160, 20);
            this.txtPlannerType.TabIndex = 83;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(32, 278);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(221, 13);
            label4.TabIndex = 84;
            label4.Text = "Our records show you ordered a planner with ";
            // 
            // txtPages
            // 
            this.txtPages.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "NoPages", true));
            this.txtPages.Location = new System.Drawing.Point(253, 274);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(34, 20);
            this.txtPages.TabIndex = 85;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(293, 278);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(76, 13);
            label6.TabIndex = 86;
            label6.Text = "custom pages.";
            // 
            // txtStudentCopies
            // 
            this.txtStudentCopies.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "QtyStud", true));
            this.txtStudentCopies.Location = new System.Drawing.Point(375, 274);
            this.txtStudentCopies.Name = "txtStudentCopies";
            this.txtStudentCopies.Size = new System.Drawing.Size(30, 20);
            this.txtStudentCopies.TabIndex = 87;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(411, 278);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(102, 13);
            label10.TabIndex = 88;
            label10.Text = "Student copies and ";
            // 
            // txtTeachersCopies
            // 
            this.txtTeachersCopies.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "QtyTeacher", true));
            this.txtTeachersCopies.Location = new System.Drawing.Point(513, 274);
            this.txtTeachersCopies.Name = "txtTeachersCopies";
            this.txtTeachersCopies.Size = new System.Drawing.Size(30, 20);
            this.txtTeachersCopies.TabIndex = 89;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(549, 278);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(147, 13);
            label11.TabIndex = 90;
            label11.Text = "Teacher copies with a total of";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.Location = new System.Drawing.Point(731, 278);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(38, 13);
            label12.TabIndex = 91;
            label12.Text = "copies";
            // 
            // txtTotalCopies
            // 
            this.txtTotalCopies.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "NoCopies", true));
            this.txtTotalCopies.Location = new System.Drawing.Point(697, 274);
            this.txtTotalCopies.Name = "txtTotalCopies";
            this.txtTotalCopies.Size = new System.Drawing.Size(30, 20);
            this.txtTotalCopies.TabIndex = 92;
            // 
            // checkBox1
            // 
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "IsFrontCvr", true));
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(23, 329);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 19);
            this.checkBox1.TabIndex = 93;
            this.checkBox1.Text = "Front";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "IsInside", true));
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(23, 377);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(81, 19);
            this.checkBox2.TabIndex = 94;
            this.checkBox2.Text = "Front Inside";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "IsInsbkcvr", true));
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(23, 403);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(85, 19);
            this.checkBox3.TabIndex = 95;
            this.checkBox3.Text = "Inside Back";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "IsBack", true));
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.Location = new System.Drawing.Point(23, 429);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(57, 19);
            this.checkBox4.TabIndex = 96;
            this.checkBox4.Text = "Back";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Frontcvr", true));
            this.textBox1.Location = new System.Drawing.Point(106, 328);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(320, 20);
            this.textBox1.TabIndex = 97;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Frontcvr2", true));
            this.textBox2.Location = new System.Drawing.Point(106, 351);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(320, 20);
            this.textBox2.TabIndex = 98;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "FrontCvin", true));
            this.textBox3.Location = new System.Drawing.Point(106, 377);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(320, 20);
            this.textBox3.TabIndex = 99;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "BackCvrin", true));
            this.textBox4.Location = new System.Drawing.Point(106, 403);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(320, 20);
            this.textBox4.TabIndex = 100;
            // 
            // textBox5
            // 
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rCardBindingSource, "Back", true));
            this.textBox5.Location = new System.Drawing.Point(106, 429);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(320, 20);
            this.textBox5.TabIndex = 101;
            // 
            // checkBox5
            // 
            this.checkBox5.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.rCardBindingSource, "Ck5", true));
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox5.Location = new System.Drawing.Point(23, 250);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(120, 18);
            this.checkBox5.TabIndex = 102;
            this.checkBox5.Text = "Your planner type is";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // frmMReceivingCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(862, 801);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtTotalCopies);
            this.Controls.Add(label12);
            this.Controls.Add(label11);
            this.Controls.Add(this.txtTeachersCopies);
            this.Controls.Add(label10);
            this.Controls.Add(this.txtStudentCopies);
            this.Controls.Add(label6);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(label4);
            this.Controls.Add(this.txtPlannerType);
            this.Controls.Add(this.lblSchcode);
            this.Controls.Add(this.estDateDateBox);
            this.Controls.Add(this.guardteDateBox);
            this.Controls.Add(this.kitreceivedDateLabel2);
            this.Controls.Add(this.deadlineLabel1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.bnRcard);
            this.Controls.Add(this.noPayRecvTextBox);
            this.Controls.Add(this.zipTextBox);
            this.Controls.Add(this.stateTextBox);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.add2TextBox);
            this.Controls.Add(this.add1TextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(label8);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.comckCheckBox);
            this.Controls.Add(this.appCheckBox);
            this.Controls.Add(this.clrpgckCheckBox);
            this.Controls.Add(this.allClrckCheckBox);
            this.Controls.Add(this.sdlStichCheckBox);
            this.Controls.Add(this.perfBindCheckBox);
            this.Controls.Add(this.spirckCheckBox);
            this.Controls.Add(this.casey_nCheckBox);
            this.Controls.Add(this.hdbky_nCheckBox);
            this.Controls.Add(label7);
            this.Controls.Add(this.coverDescTextBox);
            this.Controls.Add(this.ck8CheckBox);
            this.Controls.Add(this.baldueTextBox);
            this.Controls.Add(this.ck4CheckBox);
            this.Controls.Add(this.paymentsTextBox);
            this.Controls.Add(this.ck3CheckBox);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.ck2CheckBox);
            this.Controls.Add(guardteLabel);
            this.Controls.Add(this.ck1CheckBox);
            this.Controls.Add(kitReceivedDateLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMReceivingCard";
            this.Text = "Meridian Receiving Card";
            this.Load += new System.EventHandler(this.frmReceivingCard_Load);
            this.Controls.SetChildIndex(kitReceivedDateLabel, 0);
            this.Controls.SetChildIndex(this.ck1CheckBox, 0);
            this.Controls.SetChildIndex(guardteLabel, 0);
            this.Controls.SetChildIndex(this.ck2CheckBox, 0);
            this.Controls.SetChildIndex(label1, 0);
            this.Controls.SetChildIndex(label2, 0);
            this.Controls.SetChildIndex(label3, 0);
            this.Controls.SetChildIndex(this.ck3CheckBox, 0);
            this.Controls.SetChildIndex(this.paymentsTextBox, 0);
            this.Controls.SetChildIndex(this.ck4CheckBox, 0);
            this.Controls.SetChildIndex(this.baldueTextBox, 0);
            this.Controls.SetChildIndex(this.ck8CheckBox, 0);
            this.Controls.SetChildIndex(this.coverDescTextBox, 0);
            this.Controls.SetChildIndex(label7, 0);
            this.Controls.SetChildIndex(this.hdbky_nCheckBox, 0);
            this.Controls.SetChildIndex(this.casey_nCheckBox, 0);
            this.Controls.SetChildIndex(this.spirckCheckBox, 0);
            this.Controls.SetChildIndex(this.perfBindCheckBox, 0);
            this.Controls.SetChildIndex(this.sdlStichCheckBox, 0);
            this.Controls.SetChildIndex(this.allClrckCheckBox, 0);
            this.Controls.SetChildIndex(this.clrpgckCheckBox, 0);
            this.Controls.SetChildIndex(this.appCheckBox, 0);
            this.Controls.SetChildIndex(this.comckCheckBox, 0);
            this.Controls.SetChildIndex(this.commentTextBox, 0);
            this.Controls.SetChildIndex(label8, 0);
            this.Controls.SetChildIndex(this.nameTextBox, 0);
            this.Controls.SetChildIndex(this.add1TextBox, 0);
            this.Controls.SetChildIndex(this.add2TextBox, 0);
            this.Controls.SetChildIndex(this.cityTextBox, 0);
            this.Controls.SetChildIndex(this.stateTextBox, 0);
            this.Controls.SetChildIndex(this.zipTextBox, 0);
            this.Controls.SetChildIndex(this.noPayRecvTextBox, 0);
            this.Controls.SetChildIndex(this.bnRcard, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.deadlineLabel1, 0);
            this.Controls.SetChildIndex(this.kitreceivedDateLabel2, 0);
            this.Controls.SetChildIndex(this.guardteDateBox, 0);
            this.Controls.SetChildIndex(this.estDateDateBox, 0);
            this.Controls.SetChildIndex(this.lblSchcode, 0);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.TopPanel, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.txtPlannerType, 0);
            this.Controls.SetChildIndex(label4, 0);
            this.Controls.SetChildIndex(this.txtPages, 0);
            this.Controls.SetChildIndex(label6, 0);
            this.Controls.SetChildIndex(this.txtStudentCopies, 0);
            this.Controls.SetChildIndex(label10, 0);
            this.Controls.SetChildIndex(this.txtTeachersCopies, 0);
            this.Controls.SetChildIndex(label11, 0);
            this.Controls.SetChildIndex(label12, 0);
            this.Controls.SetChildIndex(this.txtTotalCopies, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.checkBox2, 0);
            this.Controls.SetChildIndex(this.checkBox3, 0);
            this.Controls.SetChildIndex(this.checkBox4, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.textBox3, 0);
            this.Controls.SetChildIndex(this.textBox4, 0);
            this.Controls.SetChildIndex(this.textBox5, 0);
            this.Controls.SetChildIndex(this.checkBox5, 0);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rCardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRcard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnRcard)).EndInit();
            this.bnRcard.ResumeLayout(false);
            this.bnRcard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private DataSets.dsRcard dsRcard;
		private System.Windows.Forms.BindingSource rCardBindingSource;
		private DataSets.dsRcardTableAdapters.RCardTableAdapter rCardTableAdapter;
		private DataSets.dsRcardTableAdapters.TableAdapterManager tableAdapterManager;
		private System.Windows.Forms.Label schnameLabel1;
		
		private System.Windows.Forms.CheckBox ck1CheckBox;
		private System.Windows.Forms.CheckBox ck2CheckBox;
		private System.Windows.Forms.CheckBox ck3CheckBox;
		private System.Windows.Forms.TextBox paymentsTextBox;
		private System.Windows.Forms.CheckBox ck4CheckBox;
		private System.Windows.Forms.TextBox baldueTextBox;
		private System.Windows.Forms.CheckBox ck8CheckBox;
		private System.Windows.Forms.TextBox coverDescTextBox;
		private System.Windows.Forms.CheckBox hdbky_nCheckBox;
		private System.Windows.Forms.CheckBox casey_nCheckBox;
		private System.Windows.Forms.CheckBox spirckCheckBox;
		private System.Windows.Forms.CheckBox perfBindCheckBox;
		private System.Windows.Forms.CheckBox sdlStichCheckBox;
		private System.Windows.Forms.CheckBox allClrckCheckBox;
		private System.Windows.Forms.CheckBox clrpgckCheckBox;
		private System.Windows.Forms.CheckBox appCheckBox;
		private System.Windows.Forms.CheckBox comckCheckBox;
		private System.Windows.Forms.TextBox commentTextBox;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.TextBox add1TextBox;
		private System.Windows.Forms.TextBox add2TextBox;
		private System.Windows.Forms.TextBox cityTextBox;
		private System.Windows.Forms.TextBox stateTextBox;
		private System.Windows.Forms.TextBox zipTextBox;
		private System.Windows.Forms.TextBox noPayRecvTextBox;
		private System.Windows.Forms.Label idLabel1;
		private System.Windows.Forms.Label dateCreatedLabel1;
		private System.Windows.Forms.BindingNavigator bnRcard;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.Label contractYearLabel1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
		private System.Windows.Forms.Label invnoLabel1;
		private System.Windows.Forms.Label label9;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label deadlineLabel1;
        private System.Windows.Forms.Label kitreceivedDateLabel2;
        private CustomControls.DateBox guardteDateBox;
        private CustomControls.DateBox estDateDateBox;
        private System.Windows.Forms.Label lblSchcode;
        private System.Windows.Forms.TextBox txtPlannerType;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.TextBox txtStudentCopies;
        private System.Windows.Forms.TextBox txtTeachersCopies;
        private System.Windows.Forms.TextBox txtTotalCopies;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckBox checkBox5;
    }
}
