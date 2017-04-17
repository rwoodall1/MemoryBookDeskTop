namespace Mbc5.Forms
{
	partial class EndSheet
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
			System.Windows.Forms.Label schnameLabel;
			System.Windows.Forms.Label schcodeLabel;
			System.Windows.Forms.Label prodnoLabel;
			System.Windows.Forms.Label invnoLabel;
			System.Windows.Forms.Label clr1Label;
			System.Windows.Forms.Label clr2Label;
			System.Windows.Forms.Label clr3Label;
			System.Windows.Forms.Label clr4Label;
			System.Windows.Forms.Label clr5Label;
			System.Windows.Forms.Label clr6Label;
			System.Windows.Forms.Label perfbindLabel;
			System.Windows.Forms.Label spotclrLabel;
			System.Windows.Forms.Label csonholdLabel;
			System.Windows.Forms.Label csoffholdLabel;
			System.Windows.Forms.Label endshtnoLabel;
			System.Windows.Forms.Label endstrecvLabel;
			System.Windows.Forms.Label reqstdcpyLabel;
			this.TabCtrl = new System.Windows.Forms.TabControl();
			this.EndSheets = new System.Windows.Forms.TabPage();
			this.Supplement = new System.Windows.Forms.TabPage();
			this.PreFlight = new System.Windows.Forms.TabPage();
			this.schnameTextBox = new System.Windows.Forms.TextBox();
			this.schcodeTextBox = new System.Windows.Forms.TextBox();
			this.prodnoTextBox = new System.Windows.Forms.TextBox();
			this.quotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.invnoTextBox = new System.Windows.Forms.TextBox();
			this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dsEndSheet = new Mbc5.DataSets.dsEndSheet();
			this.produtnBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.custTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.custTableAdapter();
			this.tableAdapterManager = new Mbc5.DataSets.dsEndSheetTableAdapters.TableAdapterManager();
			this.produtnTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.produtnTableAdapter();
			this.quotesTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.quotesTableAdapter();
			this.endsheetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.endsheetTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.endsheetTableAdapter();
			this.clr1TextBox = new System.Windows.Forms.TextBox();
			this.clr2TextBox = new System.Windows.Forms.TextBox();
			this.clr3TextBox = new System.Windows.Forms.TextBox();
			this.clr4TextBox = new System.Windows.Forms.TextBox();
			this.clr5TextBox = new System.Windows.Forms.TextBox();
			this.clr6TextBox = new System.Windows.Forms.TextBox();
			this.perfbindTextBox = new System.Windows.Forms.TextBox();
			this.spotclrTextBox = new System.Windows.Forms.TextBox();
			this.csonholdDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.csoffholdDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.endshtnoTextBox = new System.Windows.Forms.TextBox();
			this.endstrecvDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.reqstdcpyTextBox = new System.Windows.Forms.TextBox();
			schnameLabel = new System.Windows.Forms.Label();
			schcodeLabel = new System.Windows.Forms.Label();
			prodnoLabel = new System.Windows.Forms.Label();
			invnoLabel = new System.Windows.Forms.Label();
			clr1Label = new System.Windows.Forms.Label();
			clr2Label = new System.Windows.Forms.Label();
			clr3Label = new System.Windows.Forms.Label();
			clr4Label = new System.Windows.Forms.Label();
			clr5Label = new System.Windows.Forms.Label();
			clr6Label = new System.Windows.Forms.Label();
			perfbindLabel = new System.Windows.Forms.Label();
			spotclrLabel = new System.Windows.Forms.Label();
			csonholdLabel = new System.Windows.Forms.Label();
			csoffholdLabel = new System.Windows.Forms.Label();
			endshtnoLabel = new System.Windows.Forms.Label();
			endstrecvLabel = new System.Windows.Forms.Label();
			reqstdcpyLabel = new System.Windows.Forms.Label();
			this.TabCtrl.SuspendLayout();
			this.EndSheets.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEndSheet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.endsheetBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// TabCtrl
			// 
			this.TabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabCtrl.Controls.Add(this.EndSheets);
			this.TabCtrl.Controls.Add(this.Supplement);
			this.TabCtrl.Controls.Add(this.PreFlight);
			this.TabCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TabCtrl.Location = new System.Drawing.Point(0, 0);
			this.TabCtrl.Name = "TabCtrl";
			this.TabCtrl.SelectedIndex = 0;
			this.TabCtrl.Size = new System.Drawing.Size(1230, 763);
			this.TabCtrl.TabIndex = 0;
			// 
			// EndSheets
			// 
			this.EndSheets.BackColor = System.Drawing.SystemColors.Control;
			this.EndSheets.Controls.Add(reqstdcpyLabel);
			this.EndSheets.Controls.Add(this.reqstdcpyTextBox);
			this.EndSheets.Controls.Add(endstrecvLabel);
			this.EndSheets.Controls.Add(this.endstrecvDateTimePicker);
			this.EndSheets.Controls.Add(endshtnoLabel);
			this.EndSheets.Controls.Add(this.endshtnoTextBox);
			this.EndSheets.Controls.Add(csoffholdLabel);
			this.EndSheets.Controls.Add(this.csoffholdDateTimePicker);
			this.EndSheets.Controls.Add(csonholdLabel);
			this.EndSheets.Controls.Add(this.csonholdDateTimePicker);
			this.EndSheets.Controls.Add(spotclrLabel);
			this.EndSheets.Controls.Add(this.spotclrTextBox);
			this.EndSheets.Controls.Add(perfbindLabel);
			this.EndSheets.Controls.Add(this.perfbindTextBox);
			this.EndSheets.Controls.Add(clr6Label);
			this.EndSheets.Controls.Add(this.clr6TextBox);
			this.EndSheets.Controls.Add(clr5Label);
			this.EndSheets.Controls.Add(this.clr5TextBox);
			this.EndSheets.Controls.Add(clr4Label);
			this.EndSheets.Controls.Add(this.clr4TextBox);
			this.EndSheets.Controls.Add(clr3Label);
			this.EndSheets.Controls.Add(this.clr3TextBox);
			this.EndSheets.Controls.Add(clr2Label);
			this.EndSheets.Controls.Add(this.clr2TextBox);
			this.EndSheets.Controls.Add(clr1Label);
			this.EndSheets.Controls.Add(this.clr1TextBox);
			this.EndSheets.Controls.Add(invnoLabel);
			this.EndSheets.Controls.Add(this.invnoTextBox);
			this.EndSheets.Controls.Add(prodnoLabel);
			this.EndSheets.Controls.Add(this.prodnoTextBox);
			this.EndSheets.Controls.Add(schcodeLabel);
			this.EndSheets.Controls.Add(this.schcodeTextBox);
			this.EndSheets.Controls.Add(schnameLabel);
			this.EndSheets.Controls.Add(this.schnameTextBox);
			this.EndSheets.Location = new System.Drawing.Point(4, 22);
			this.EndSheets.Name = "EndSheets";
			this.EndSheets.Padding = new System.Windows.Forms.Padding(3);
			this.EndSheets.Size = new System.Drawing.Size(1222, 737);
			this.EndSheets.TabIndex = 0;
			this.EndSheets.Text = "End Sheet";
			this.EndSheets.Click += new System.EventHandler(this.EndSheets_Click);
			// 
			// Supplement
			// 
			this.Supplement.BackColor = System.Drawing.SystemColors.Control;
			this.Supplement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Supplement.Location = new System.Drawing.Point(4, 22);
			this.Supplement.Name = "Supplement";
			this.Supplement.Padding = new System.Windows.Forms.Padding(3);
			this.Supplement.Size = new System.Drawing.Size(1222, 737);
			this.Supplement.TabIndex = 1;
			this.Supplement.Text = "Supplement";
			// 
			// PreFlight
			// 
			this.PreFlight.BackColor = System.Drawing.SystemColors.Control;
			this.PreFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PreFlight.Location = new System.Drawing.Point(4, 22);
			this.PreFlight.Name = "PreFlight";
			this.PreFlight.Size = new System.Drawing.Size(1222, 737);
			this.PreFlight.TabIndex = 2;
			this.PreFlight.Text = "PreFlight";
			// 
			// schnameLabel
			// 
			schnameLabel.AutoSize = true;
			schnameLabel.Location = new System.Drawing.Point(194, 17);
			schnameLabel.Name = "schnameLabel";
			schnameLabel.Size = new System.Drawing.Size(61, 13);
			schnameLabel.TabIndex = 0;
			schnameLabel.Text = "schname:";
			// 
			// schnameTextBox
			// 
			this.schnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schname", true));
			this.schnameTextBox.Location = new System.Drawing.Point(261, 17);
			this.schnameTextBox.Name = "schnameTextBox";
			this.schnameTextBox.Size = new System.Drawing.Size(100, 20);
			this.schnameTextBox.TabIndex = 1;
			// 
			// schcodeLabel
			// 
			schcodeLabel.AutoSize = true;
			schcodeLabel.Location = new System.Drawing.Point(22, 22);
			schcodeLabel.Name = "schcodeLabel";
			schcodeLabel.Size = new System.Drawing.Size(59, 13);
			schcodeLabel.TabIndex = 2;
			schcodeLabel.Text = "schcode:";
			// 
			// schcodeTextBox
			// 
			this.schcodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schcode", true));
			this.schcodeTextBox.Location = new System.Drawing.Point(87, 19);
			this.schcodeTextBox.Name = "schcodeTextBox";
			this.schcodeTextBox.Size = new System.Drawing.Size(100, 20);
			this.schcodeTextBox.TabIndex = 3;
			// 
			// prodnoLabel
			// 
			prodnoLabel.AutoSize = true;
			prodnoLabel.Location = new System.Drawing.Point(397, 27);
			prodnoLabel.Name = "prodnoLabel";
			prodnoLabel.Size = new System.Drawing.Size(50, 13);
			prodnoLabel.TabIndex = 4;
			prodnoLabel.Text = "prodno:";
			// 
			// prodnoTextBox
			// 
			this.prodnoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "prodno", true));
			this.prodnoTextBox.Location = new System.Drawing.Point(453, 24);
			this.prodnoTextBox.Name = "prodnoTextBox";
			this.prodnoTextBox.Size = new System.Drawing.Size(100, 20);
			this.prodnoTextBox.TabIndex = 5;
			// 
			// quotesBindingSource
			// 
			this.quotesBindingSource.DataMember = "cust_quotes";
			this.quotesBindingSource.DataSource = this.custBindingSource;
			// 
			// invnoLabel
			// 
			invnoLabel.AutoSize = true;
			invnoLabel.Location = new System.Drawing.Point(643, 31);
			invnoLabel.Name = "invnoLabel";
			invnoLabel.Size = new System.Drawing.Size(42, 13);
			invnoLabel.TabIndex = 6;
			invnoLabel.Text = "invno:";
			// 
			// invnoTextBox
			// 
			this.invnoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "invno", true));
			this.invnoTextBox.Location = new System.Drawing.Point(691, 28);
			this.invnoTextBox.Name = "invnoTextBox";
			this.invnoTextBox.Size = new System.Drawing.Size(100, 20);
			this.invnoTextBox.TabIndex = 7;
			// 
			// custBindingSource
			// 
			this.custBindingSource.DataMember = "cust";
			this.custBindingSource.DataSource = this.dsEndSheet;
			// 
			// dsEndSheet
			// 
			this.dsEndSheet.DataSetName = "dsEndSheet";
			this.dsEndSheet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// produtnBindingSource
			// 
			this.produtnBindingSource.DataMember = "produtn";
			this.produtnBindingSource.DataSource = this.dsEndSheet;
			// 
			// custTableAdapter
			// 
			this.custTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager
			// 
			this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager.custTableAdapter = this.custTableAdapter;
			this.tableAdapterManager.produtnTableAdapter = null;
			this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsEndSheetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// produtnTableAdapter
			// 
			this.produtnTableAdapter.ClearBeforeFill = true;
			// 
			// quotesTableAdapter
			// 
			this.quotesTableAdapter.ClearBeforeFill = true;
			// 
			// endsheetBindingSource
			// 
			this.endsheetBindingSource.DataMember = "endsheet";
			this.endsheetBindingSource.DataSource = this.dsEndSheet;
			// 
			// endsheetTableAdapter
			// 
			this.endsheetTableAdapter.ClearBeforeFill = true;
			// 
			// clr1Label
			// 
			clr1Label.AutoSize = true;
			clr1Label.Location = new System.Drawing.Point(67, 59);
			clr1Label.Name = "clr1Label";
			clr1Label.Size = new System.Drawing.Size(14, 13);
			clr1Label.TabIndex = 8;
			clr1Label.Text = "1";
			// 
			// clr1TextBox
			// 
			this.clr1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr1", true));
			this.clr1TextBox.Location = new System.Drawing.Point(87, 59);
			this.clr1TextBox.Name = "clr1TextBox";
			this.clr1TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr1TextBox.TabIndex = 9;
			// 
			// clr2Label
			// 
			clr2Label.AutoSize = true;
			clr2Label.Location = new System.Drawing.Point(142, 59);
			clr2Label.Name = "clr2Label";
			clr2Label.Size = new System.Drawing.Size(14, 13);
			clr2Label.TabIndex = 10;
			clr2Label.Text = "2";
			// 
			// clr2TextBox
			// 
			this.clr2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr2", true));
			this.clr2TextBox.Location = new System.Drawing.Point(162, 59);
			this.clr2TextBox.Name = "clr2TextBox";
			this.clr2TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr2TextBox.TabIndex = 11;
			// 
			// clr3Label
			// 
			clr3Label.AutoSize = true;
			clr3Label.Location = new System.Drawing.Point(214, 59);
			clr3Label.Name = "clr3Label";
			clr3Label.Size = new System.Drawing.Size(14, 13);
			clr3Label.TabIndex = 12;
			clr3Label.Text = "3";
			// 
			// clr3TextBox
			// 
			this.clr3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr3", true));
			this.clr3TextBox.Location = new System.Drawing.Point(234, 59);
			this.clr3TextBox.Name = "clr3TextBox";
			this.clr3TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr3TextBox.TabIndex = 13;
			// 
			// clr4Label
			// 
			clr4Label.AutoSize = true;
			clr4Label.Location = new System.Drawing.Point(283, 59);
			clr4Label.Name = "clr4Label";
			clr4Label.Size = new System.Drawing.Size(14, 13);
			clr4Label.TabIndex = 14;
			clr4Label.Text = "4";
			// 
			// clr4TextBox
			// 
			this.clr4TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr4", true));
			this.clr4TextBox.Location = new System.Drawing.Point(303, 59);
			this.clr4TextBox.Name = "clr4TextBox";
			this.clr4TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr4TextBox.TabIndex = 15;
			// 
			// clr5Label
			// 
			clr5Label.AutoSize = true;
			clr5Label.Location = new System.Drawing.Point(351, 59);
			clr5Label.Name = "clr5Label";
			clr5Label.Size = new System.Drawing.Size(14, 13);
			clr5Label.TabIndex = 16;
			clr5Label.Text = "5";
			// 
			// clr5TextBox
			// 
			this.clr5TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr5", true));
			this.clr5TextBox.Location = new System.Drawing.Point(371, 59);
			this.clr5TextBox.Name = "clr5TextBox";
			this.clr5TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr5TextBox.TabIndex = 17;
			// 
			// clr6Label
			// 
			clr6Label.AutoSize = true;
			clr6Label.Location = new System.Drawing.Point(418, 59);
			clr6Label.Name = "clr6Label";
			clr6Label.Size = new System.Drawing.Size(14, 13);
			clr6Label.TabIndex = 18;
			clr6Label.Text = "6";
			// 
			// clr6TextBox
			// 
			this.clr6TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "clr6", true));
			this.clr6TextBox.Location = new System.Drawing.Point(438, 59);
			this.clr6TextBox.Name = "clr6TextBox";
			this.clr6TextBox.Size = new System.Drawing.Size(45, 20);
			this.clr6TextBox.TabIndex = 19;
			// 
			// perfbindLabel
			// 
			perfbindLabel.AutoSize = true;
			perfbindLabel.Location = new System.Drawing.Point(489, 62);
			perfbindLabel.Name = "perfbindLabel";
			perfbindLabel.Size = new System.Drawing.Size(32, 13);
			perfbindLabel.TabIndex = 20;
			perfbindLabel.Text = "Bind";
			// 
			// perfbindTextBox
			// 
			this.perfbindTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "perfbind", true));
			this.perfbindTextBox.Location = new System.Drawing.Point(521, 62);
			this.perfbindTextBox.Name = "perfbindTextBox";
			this.perfbindTextBox.Size = new System.Drawing.Size(32, 20);
			this.perfbindTextBox.TabIndex = 21;
			// 
			// spotclrLabel
			// 
			spotclrLabel.AutoSize = true;
			spotclrLabel.Location = new System.Drawing.Point(562, 65);
			spotclrLabel.Name = "spotclrLabel";
			spotclrLabel.Size = new System.Drawing.Size(66, 13);
			spotclrLabel.TabIndex = 22;
			spotclrLabel.Text = "#Spot Clrs";
			// 
			// spotclrTextBox
			// 
			this.spotclrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "spotclr", true));
			this.spotclrTextBox.Location = new System.Drawing.Point(633, 62);
			this.spotclrTextBox.Name = "spotclrTextBox";
			this.spotclrTextBox.Size = new System.Drawing.Size(49, 20);
			this.spotclrTextBox.TabIndex = 23;
			// 
			// csonholdLabel
			// 
			csonholdLabel.AutoSize = true;
			csonholdLabel.Location = new System.Drawing.Point(823, 71);
			csonholdLabel.Name = "csonholdLabel";
			csonholdLabel.Size = new System.Drawing.Size(73, 13);
			csonholdLabel.TabIndex = 24;
			csonholdLabel.Text = "CS On Hold";
			// 
			// csonholdDateTimePicker
			// 
			this.csonholdDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "csonhold", true));
			this.csonholdDateTimePicker.Location = new System.Drawing.Point(903, 67);
			this.csonholdDateTimePicker.Name = "csonholdDateTimePicker";
			this.csonholdDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.csonholdDateTimePicker.TabIndex = 25;
			// 
			// csoffholdLabel
			// 
			csoffholdLabel.AutoSize = true;
			csoffholdLabel.Location = new System.Drawing.Point(822, 97);
			csoffholdLabel.Name = "csoffholdLabel";
			csoffholdLabel.Size = new System.Drawing.Size(74, 13);
			csoffholdLabel.TabIndex = 26;
			csoffholdLabel.Text = "CS Off Hold";
			// 
			// csoffholdDateTimePicker
			// 
			this.csoffholdDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "csoffhold", true));
			this.csoffholdDateTimePicker.Location = new System.Drawing.Point(903, 93);
			this.csoffholdDateTimePicker.Name = "csoffholdDateTimePicker";
			this.csoffholdDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.csoffholdDateTimePicker.TabIndex = 27;
			// 
			// endshtnoLabel
			// 
			endshtnoLabel.AutoSize = true;
			endshtnoLabel.Location = new System.Drawing.Point(38, 100);
			endshtnoLabel.Name = "endshtnoLabel";
			endshtnoLabel.Size = new System.Drawing.Size(63, 13);
			endshtnoLabel.TabIndex = 28;
			endshtnoLabel.Text = "endshtno:";
			// 
			// endshtnoTextBox
			// 
			this.endshtnoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "endshtno", true));
			this.endshtnoTextBox.Location = new System.Drawing.Point(107, 97);
			this.endshtnoTextBox.Name = "endshtnoTextBox";
			this.endshtnoTextBox.Size = new System.Drawing.Size(67, 20);
			this.endshtnoTextBox.TabIndex = 29;
			// 
			// endstrecvLabel
			// 
			endstrecvLabel.AutoSize = true;
			endstrecvLabel.Location = new System.Drawing.Point(188, 98);
			endstrecvLabel.Name = "endstrecvLabel";
			endstrecvLabel.Size = new System.Drawing.Size(72, 13);
			endstrecvLabel.TabIndex = 30;
			endstrecvLabel.Text = "Recv. Date";
			// 
			// endstrecvDateTimePicker
			// 
			this.endstrecvDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.endsheetBindingSource, "endstrecv", true));
			this.endstrecvDateTimePicker.Location = new System.Drawing.Point(261, 94);
			this.endstrecvDateTimePicker.Name = "endstrecvDateTimePicker";
			this.endstrecvDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.endstrecvDateTimePicker.TabIndex = 31;
			// 
			// reqstdcpyLabel
			// 
			reqstdcpyLabel.AutoSize = true;
			reqstdcpyLabel.Location = new System.Drawing.Point(519, 103);
			reqstdcpyLabel.Name = "reqstdcpyLabel";
			reqstdcpyLabel.Size = new System.Drawing.Size(87, 13);
			reqstdcpyLabel.TabIndex = 32;
			reqstdcpyLabel.Text = "Rqst # Copies";
			// 
			// reqstdcpyTextBox
			// 
			this.reqstdcpyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.endsheetBindingSource, "reqstdcpy", true));
			this.reqstdcpyTextBox.Location = new System.Drawing.Point(615, 100);
			this.reqstdcpyTextBox.Name = "reqstdcpyTextBox";
			this.reqstdcpyTextBox.Size = new System.Drawing.Size(53, 20);
			this.reqstdcpyTextBox.TabIndex = 33;
			// 
			// EndSheet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1234, 764);
			this.Controls.Add(this.TabCtrl);
			this.Name = "EndSheet";
			this.Text = "End Sheet/Supplements/Preflight";
			this.Load += new System.EventHandler(this.EndSheet_Load);
			this.TabCtrl.ResumeLayout(false);
			this.EndSheets.ResumeLayout(false);
			this.EndSheets.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEndSheet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.endsheetBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl TabCtrl;
		private System.Windows.Forms.TabPage EndSheets;
		private System.Windows.Forms.TabPage Supplement;
		private System.Windows.Forms.TabPage PreFlight;
		private DataSets.dsEndSheet dsEndSheet;
		private System.Windows.Forms.BindingSource custBindingSource;
		private DataSets.dsEndSheetTableAdapters.custTableAdapter custTableAdapter;
		private DataSets.dsEndSheetTableAdapters.TableAdapterManager tableAdapterManager;
		private System.Windows.Forms.TextBox schcodeTextBox;
		private System.Windows.Forms.TextBox schnameTextBox;
		private System.Windows.Forms.BindingSource produtnBindingSource;
		private DataSets.dsEndSheetTableAdapters.produtnTableAdapter produtnTableAdapter;
		private System.Windows.Forms.TextBox prodnoTextBox;
		private System.Windows.Forms.BindingSource quotesBindingSource;
		private DataSets.dsEndSheetTableAdapters.quotesTableAdapter quotesTableAdapter;
		private System.Windows.Forms.TextBox invnoTextBox;
		private System.Windows.Forms.BindingSource endsheetBindingSource;
		private DataSets.dsEndSheetTableAdapters.endsheetTableAdapter endsheetTableAdapter;
		private System.Windows.Forms.TextBox clr6TextBox;
		private System.Windows.Forms.TextBox clr5TextBox;
		private System.Windows.Forms.TextBox clr4TextBox;
		private System.Windows.Forms.TextBox clr3TextBox;
		private System.Windows.Forms.TextBox clr2TextBox;
		private System.Windows.Forms.TextBox clr1TextBox;
		private System.Windows.Forms.TextBox perfbindTextBox;
		private System.Windows.Forms.TextBox spotclrTextBox;
		private System.Windows.Forms.TextBox reqstdcpyTextBox;
		private System.Windows.Forms.DateTimePicker endstrecvDateTimePicker;
		private System.Windows.Forms.TextBox endshtnoTextBox;
		private System.Windows.Forms.DateTimePicker csoffholdDateTimePicker;
		private System.Windows.Forms.DateTimePicker csonholdDateTimePicker;
	}
}
