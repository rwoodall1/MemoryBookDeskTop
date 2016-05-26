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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSales));
            this.tabSales = new System.Windows.Forms.TabControl();
            this.pg1 = new System.Windows.Forms.TabPage();
            this.pg2 = new System.Windows.Forms.TabPage();
            this.dsSales = new Mbc5.DataSets.dsSales();
            this.quotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quotesTableAdapter = new Mbc5.DataSets.dsSalesTableAdapters.quotesTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager();
            this.quotesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.quotesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.fillToolStrip = new System.Windows.Forms.ToolStrip();
            this.schcodeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.schcodeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.chkHardBack = new System.Windows.Forms.CheckBox();
            this.txtHardbackAmt = new System.Windows.Forms.TextBox();
            this.chkCaseBind = new System.Windows.Forms.CheckBox();
            this.txtCaseamt = new System.Windows.Forms.TextBox();
            this.chkPerfBind = new System.Windows.Forms.CheckBox();
            this.txtPerfbindAmt = new System.Windows.Forms.TextBox();
            this.chkSpiral = new System.Windows.Forms.CheckBox();
            this.txtSpiralAmt = new System.Windows.Forms.TextBox();
            this.chkSaddlStich = new System.Windows.Forms.CheckBox();
            this.sdlstichamtTextBox = new System.Windows.Forms.TextBox();
            this.tabSales.SuspendLayout();
            this.pg1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingNavigator)).BeginInit();
            this.quotesBindingNavigator.SuspendLayout();
            this.fillToolStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.pg1.Controls.Add(this.sdlstichamtTextBox);
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
            // pg2
            // 
            this.pg2.BackColor = System.Drawing.SystemColors.Control;
            this.pg2.Location = new System.Drawing.Point(4, 22);
            this.pg2.Name = "pg2";
            this.pg2.Padding = new System.Windows.Forms.Padding(3);
            this.pg2.Size = new System.Drawing.Size(192, 74);
            this.pg2.TabIndex = 1;
            this.pg2.Text = "Invoices";
            // 
            // dsSales
            // 
            this.dsSales.DataSetName = "dsSales";
            this.dsSales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quotesBindingSource
            // 
            this.quotesBindingSource.DataMember = "quotes";
            this.quotesBindingSource.DataSource = this.dsSales;
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
            // quotesBindingNavigator
            // 
            this.quotesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.quotesBindingNavigator.BindingSource = this.quotesBindingSource;
            this.quotesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.quotesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.quotesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.quotesBindingNavigatorSaveItem});
            this.quotesBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.quotesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.quotesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.quotesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.quotesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.quotesBindingNavigator.Name = "quotesBindingNavigator";
            this.quotesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.quotesBindingNavigator.Size = new System.Drawing.Size(1264, 25);
            this.quotesBindingNavigator.TabIndex = 1;
            this.quotesBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // quotesBindingNavigatorSaveItem
            // 
            this.quotesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.quotesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("quotesBindingNavigatorSaveItem.Image")));
            this.quotesBindingNavigatorSaveItem.Name = "quotesBindingNavigatorSaveItem";
            this.quotesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.quotesBindingNavigatorSaveItem.Text = "Save Data";
            this.quotesBindingNavigatorSaveItem.Click += new System.EventHandler(this.quotesBindingNavigatorSaveItem_Click);
            // 
            // fillToolStrip
            // 
            this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schcodeToolStripLabel,
            this.schcodeToolStripTextBox,
            this.fillToolStripButton});
            this.fillToolStrip.Location = new System.Drawing.Point(0, 25);
            this.fillToolStrip.Name = "fillToolStrip";
            this.fillToolStrip.Size = new System.Drawing.Size(1264, 25);
            this.fillToolStrip.TabIndex = 2;
            this.fillToolStrip.Text = "fillToolStrip";
            // 
            // schcodeToolStripLabel
            // 
            this.schcodeToolStripLabel.Name = "schcodeToolStripLabel";
            this.schcodeToolStripLabel.Size = new System.Drawing.Size(54, 22);
            this.schcodeToolStripLabel.Text = "schcode:";
            // 
            // schcodeToolStripTextBox
            // 
            this.schcodeToolStripTextBox.Name = "schcodeToolStripTextBox";
            this.schcodeToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // fillToolStripButton
            // 
            this.fillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillToolStripButton.Name = "fillToolStripButton";
            this.fillToolStripButton.Size = new System.Drawing.Size(26, 22);
            this.fillToolStripButton.Text = "Fill";
            this.fillToolStripButton.Click += new System.EventHandler(this.fillToolStripButton_Click);
            // 
            // chkHardBack
            // 
            this.chkHardBack.AutoSize = true;
            this.chkHardBack.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "hdbky_n", true));
            this.chkHardBack.Location = new System.Drawing.Point(54, 46);
            this.chkHardBack.Name = "chkHardBack";
            this.chkHardBack.Size = new System.Drawing.Size(145, 17);
            this.chkHardBack.TabIndex = 1;
            this.chkHardBack.Text = "Hard Back (sewn 40)";
            this.chkHardBack.UseVisualStyleBackColor = true;
            // 
            // txtHardbackAmt
            // 
            this.txtHardbackAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "hardback", true));
            this.txtHardbackAmt.Location = new System.Drawing.Point(202, 46);
            this.txtHardbackAmt.Name = "txtHardbackAmt";
            this.txtHardbackAmt.Size = new System.Drawing.Size(100, 20);
            this.txtHardbackAmt.TabIndex = 3;
            // 
            // chkCaseBind
            // 
            this.chkCaseBind.AutoSize = true;
            this.chkCaseBind.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "casey_n", true));
            this.chkCaseBind.Location = new System.Drawing.Point(54, 72);
            this.chkCaseBind.Name = "chkCaseBind";
            this.chkCaseBind.Size = new System.Drawing.Size(144, 17);
            this.chkCaseBind.TabIndex = 4;
            this.chkCaseBind.Text = "Case Bind (glued 32)";
            this.chkCaseBind.UseVisualStyleBackColor = true;
            // 
            // txtCaseamt
            // 
            this.txtCaseamt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "caseamt", true));
            this.txtCaseamt.Location = new System.Drawing.Point(202, 72);
            this.txtCaseamt.Name = "txtCaseamt";
            this.txtCaseamt.Size = new System.Drawing.Size(100, 20);
            this.txtCaseamt.TabIndex = 5;
            // 
            // chkPerfBind
            // 
            this.chkPerfBind.AutoSize = true;
            this.chkPerfBind.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "peyn", true));
            this.chkPerfBind.Location = new System.Drawing.Point(54, 95);
            this.chkPerfBind.Name = "chkPerfBind";
            this.chkPerfBind.Size = new System.Drawing.Size(122, 17);
            this.chkPerfBind.TabIndex = 6;
            this.chkPerfBind.Text = "Perfect Bind (40)";
            this.chkPerfBind.UseVisualStyleBackColor = true;
            // 
            // txtPerfbindAmt
            // 
            this.txtPerfbindAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "perfbind", true));
            this.txtPerfbindAmt.Location = new System.Drawing.Point(203, 97);
            this.txtPerfbindAmt.Name = "txtPerfbindAmt";
            this.txtPerfbindAmt.Size = new System.Drawing.Size(100, 20);
            this.txtPerfbindAmt.TabIndex = 7;
            // 
            // chkSpiral
            // 
            this.chkSpiral.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "spirck", true));
            this.chkSpiral.Location = new System.Drawing.Point(54, 121);
            this.chkSpiral.Name = "chkSpiral";
            this.chkSpiral.Size = new System.Drawing.Size(104, 24);
            this.chkSpiral.TabIndex = 8;
            this.chkSpiral.Text = "Spiral";
            this.chkSpiral.UseVisualStyleBackColor = true;
            // 
            // txtSpiralAmt
            // 
            this.txtSpiralAmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "spiramt", true));
            this.txtSpiralAmt.Location = new System.Drawing.Point(202, 123);
            this.txtSpiralAmt.Name = "txtSpiralAmt";
            this.txtSpiralAmt.Size = new System.Drawing.Size(100, 20);
            this.txtSpiralAmt.TabIndex = 9;
            // 
            // chkSaddlStich
            // 
            this.chkSaddlStich.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "sdlstich", true));
            this.chkSaddlStich.Location = new System.Drawing.Point(54, 155);
            this.chkSaddlStich.Name = "chkSaddlStich";
            this.chkSaddlStich.Size = new System.Drawing.Size(104, 24);
            this.chkSaddlStich.TabIndex = 10;
            this.chkSaddlStich.Text = "Saddle Stitch";
            this.chkSaddlStich.UseVisualStyleBackColor = true;
            // 
            // sdlstichamtTextBox
            // 
            this.sdlstichamtTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "sdlstichamt", true));
            this.sdlstichamtTextBox.Location = new System.Drawing.Point(202, 155);
            this.sdlstichamtTextBox.Name = "sdlstichamtTextBox";
            this.sdlstichamtTextBox.Size = new System.Drawing.Size(100, 20);
            this.sdlstichamtTextBox.TabIndex = 11;
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.fillToolStrip);
            this.Controls.Add(this.quotesBindingNavigator);
            this.Controls.Add(this.tabSales);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSales";
            this.Text = "Sales";
            this.tabSales.ResumeLayout(false);
            this.pg1.ResumeLayout(false);
            this.pg1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingNavigator)).EndInit();
            this.quotesBindingNavigator.ResumeLayout(false);
            this.quotesBindingNavigator.PerformLayout();
            this.fillToolStrip.ResumeLayout(false);
            this.fillToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TabControl tabSales;
        private System.Windows.Forms.TabPage pg1;
        private System.Windows.Forms.TabPage pg2;
        private DataSets.dsSales dsSales;
        private System.Windows.Forms.BindingSource quotesBindingSource;
        private DataSets.dsSalesTableAdapters.quotesTableAdapter quotesTableAdapter;
        private DataSets.dsSalesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator quotesBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton quotesBindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStrip fillToolStrip;
        private System.Windows.Forms.ToolStripLabel schcodeToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox schcodeToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
        private System.Windows.Forms.TextBox sdlstichamtTextBox;
        private System.Windows.Forms.CheckBox chkSaddlStich;
        private System.Windows.Forms.TextBox txtSpiralAmt;
        private System.Windows.Forms.CheckBox chkSpiral;
        private System.Windows.Forms.TextBox txtPerfbindAmt;
        private System.Windows.Forms.CheckBox chkPerfBind;
        private System.Windows.Forms.TextBox txtCaseamt;
        private System.Windows.Forms.CheckBox chkCaseBind;
        private System.Windows.Forms.TextBox txtHardbackAmt;
        private System.Windows.Forms.CheckBox chkHardBack;
        }
    }
