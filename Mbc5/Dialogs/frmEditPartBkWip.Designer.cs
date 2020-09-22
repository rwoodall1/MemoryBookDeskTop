namespace Mbc5.Dialogs {
    partial class frmEditPartBkWip {
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
            System.Windows.Forms.Label invnoLabel;
            System.Windows.Forms.Label wirLabel;
            System.Windows.Forms.Label wtrLabel;
            System.Windows.Forms.Label wdrLabel;
            System.Windows.Forms.Label warLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPartBkWip));
            this.dsProdutn = new Mbc5.DataSets.dsProdutn();
            this.partBkDetailTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.PartBkDetailTableAdapter();
            this.wipDescriptionsTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.WipDescriptionsTableAdapter();
            this.partBkDetailBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.partBkDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.partBkDetailBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.txtInvno = new System.Windows.Forms.TextBox();
            this.wirTextBox = new System.Windows.Forms.TextBox();
            this.wtrTextBox = new System.Windows.Forms.TextBox();
            this.cmbDescription = new System.Windows.Forms.ComboBox();
            this.wipDescriptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wdrDateBox = new CustomControls.DateBox();
            this.warDateBox = new CustomControls.DateBox();
            this.lblSchcode = new System.Windows.Forms.Label();
            this.tableAdapterManager = new Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            invnoLabel = new System.Windows.Forms.Label();
            wirLabel = new System.Windows.Forms.Label();
            wtrLabel = new System.Windows.Forms.Label();
            wdrLabel = new System.Windows.Forms.Label();
            warLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBkDetailBindingNavigator)).BeginInit();
            this.partBkDetailBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partBkDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // invnoLabel
            // 
            invnoLabel.AutoSize = true;
            invnoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            invnoLabel.Location = new System.Drawing.Point(39, 195);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(57, 13);
            invnoLabel.TabIndex = 24;
            invnoLabel.Text = "Invoice#";
            // 
            // wirLabel
            // 
            wirLabel.AutoSize = true;
            wirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            wirLabel.Location = new System.Drawing.Point(52, 166);
            wirLabel.Name = "wirLabel";
            wirLabel.Size = new System.Drawing.Size(44, 13);
            wirLabel.TabIndex = 22;
            wirLabel.Text = "Initials";
            // 
            // wtrLabel
            // 
            wtrLabel.AutoSize = true;
            wtrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            wtrLabel.Location = new System.Drawing.Point(62, 134);
            wtrLabel.Name = "wtrLabel";
            wtrLabel.Size = new System.Drawing.Size(34, 13);
            wtrLabel.TabIndex = 20;
            wtrLabel.Text = "Time";
            // 
            // wdrLabel
            // 
            wdrLabel.AutoSize = true;
            wdrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            wdrLabel.Location = new System.Drawing.Point(66, 106);
            wdrLabel.Name = "wdrLabel";
            wdrLabel.Size = new System.Drawing.Size(30, 13);
            wdrLabel.TabIndex = 18;
            wdrLabel.Text = "Due";
            // 
            // warLabel
            // 
            warLabel.AutoSize = true;
            warLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            warLabel.Location = new System.Drawing.Point(53, 79);
            warLabel.Name = "warLabel";
            warLabel.Size = new System.Drawing.Size(43, 13);
            warLabel.TabIndex = 16;
            warLabel.Text = "Actual";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descriptionLabel.Location = new System.Drawing.Point(21, 49);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(75, 13);
            descriptionLabel.TabIndex = 14;
            descriptionLabel.Text = "Description:";
            // 
            // dsProdutn
            // 
            this.dsProdutn.DataSetName = "dsProdutn";
            this.dsProdutn.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // partBkDetailTableAdapter
            // 
            this.partBkDetailTableAdapter.ClearBeforeFill = true;
            // 
            // wipDescriptionsTableAdapter
            // 
            this.wipDescriptionsTableAdapter.ClearBeforeFill = true;
            // 
            // partBkDetailBindingNavigator
            // 
            this.partBkDetailBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.partBkDetailBindingNavigator.BindingSource = this.partBkDetailBindingSource;
            this.partBkDetailBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.partBkDetailBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.partBkDetailBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.partBkDetailBindingNavigatorSaveItem});
            this.partBkDetailBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.partBkDetailBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.partBkDetailBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.partBkDetailBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.partBkDetailBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.partBkDetailBindingNavigator.Name = "partBkDetailBindingNavigator";
            this.partBkDetailBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.partBkDetailBindingNavigator.Size = new System.Drawing.Size(470, 25);
            this.partBkDetailBindingNavigator.TabIndex = 0;
            this.partBkDetailBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // partBkDetailBindingSource
            // 
            this.partBkDetailBindingSource.DataMember = "PartBkDetail";
            this.partBkDetailBindingSource.DataSource = this.dsProdutn;
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
            // partBkDetailBindingNavigatorSaveItem
            // 
            this.partBkDetailBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.partBkDetailBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("partBkDetailBindingNavigatorSaveItem.Image")));
            this.partBkDetailBindingNavigatorSaveItem.Name = "partBkDetailBindingNavigatorSaveItem";
            this.partBkDetailBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.partBkDetailBindingNavigatorSaveItem.Text = "Save Data";
            this.partBkDetailBindingNavigatorSaveItem.Click += new System.EventHandler(this.partBkDetailBindingNavigatorSaveItem_Click);
            // 
            // txtInvno
            // 
            this.txtInvno.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partBkDetailBindingSource, "Invno", true));
            this.txtInvno.Location = new System.Drawing.Point(103, 195);
            this.txtInvno.Name = "txtInvno";
            this.txtInvno.ReadOnly = true;
            this.txtInvno.Size = new System.Drawing.Size(100, 20);
            this.txtInvno.TabIndex = 25;
            // 
            // wirTextBox
            // 
            this.wirTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partBkDetailBindingSource, "Wir", true));
            this.wirTextBox.Location = new System.Drawing.Point(103, 166);
            this.wirTextBox.Name = "wirTextBox";
            this.wirTextBox.Size = new System.Drawing.Size(100, 20);
            this.wirTextBox.TabIndex = 23;
            this.wirTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.wirTextBox_Validating);
            // 
            // wtrTextBox
            // 
            this.wtrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partBkDetailBindingSource, "Wtr", true));
            this.wtrTextBox.Location = new System.Drawing.Point(103, 134);
            this.wtrTextBox.Name = "wtrTextBox";
            this.wtrTextBox.Size = new System.Drawing.Size(100, 20);
            this.wtrTextBox.TabIndex = 21;
            this.wtrTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.wtrTextBox_Validating);
            // 
            // cmbDescription
            // 
            this.cmbDescription.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.partBkDetailBindingSource, "DescripId", true));
            this.cmbDescription.DataSource = this.wipDescriptionsBindingSource;
            this.cmbDescription.DisplayMember = "Description";
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.Location = new System.Drawing.Point(103, 49);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.Size = new System.Drawing.Size(225, 21);
            this.cmbDescription.TabIndex = 15;
            this.cmbDescription.ValueMember = "Id";
            // 
            // wipDescriptionsBindingSource
            // 
            this.wipDescriptionsBindingSource.DataMember = "WipDescriptions";
            this.wipDescriptionsBindingSource.DataSource = this.dsProdutn;
            // 
            // wdrDateBox
            // 
            this.wdrDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.partBkDetailBindingSource, "Wdr", true));
            this.wdrDateBox.Date = null;
            this.wdrDateBox.DateValue = null;
            this.wdrDateBox.Location = new System.Drawing.Point(103, 107);
            this.wdrDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.wdrDateBox.Name = "wdrDateBox";
            this.wdrDateBox.Size = new System.Drawing.Size(114, 21);
            this.wdrDateBox.TabIndex = 26;
            // 
            // warDateBox
            // 
            this.warDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.partBkDetailBindingSource, "War", true));
            this.warDateBox.Date = null;
            this.warDateBox.DateValue = null;
            this.warDateBox.Location = new System.Drawing.Point(103, 79);
            this.warDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.warDateBox.Name = "warDateBox";
            this.warDateBox.Size = new System.Drawing.Size(114, 21);
            this.warDateBox.TabIndex = 27;
            // 
            // lblSchcode
            // 
            this.lblSchcode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partBkDetailBindingSource, "Schcode", true));
            this.lblSchcode.Location = new System.Drawing.Point(21, 208);
            this.lblSchcode.Name = "lblSchcode";
            this.lblSchcode.Size = new System.Drawing.Size(1, 1);
            this.lblSchcode.TabIndex = 28;
            this.lblSchcode.Text = "label1";
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.coverdetailTableAdapter = null;
            this.tableAdapterManager.coversTableAdapter = null;
            this.tableAdapterManager.custTableAdapter = null;
            this.tableAdapterManager.mcustTableAdapter = null;
            this.tableAdapterManager.PartBkDetailTableAdapter = null;
            this.tableAdapterManager.partbkTableAdapter = null;
            this.tableAdapterManager.produtnTableAdapter = null;
            this.tableAdapterManager.prtbkbdetailTableAdapter = null;
            this.tableAdapterManager.ptbkbTableAdapter = null;
            this.tableAdapterManager.quotesTableAdapter = null;
            this.tableAdapterManager.ReorderDetailTableAdapter = null;
            this.tableAdapterManager.ReOrderTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WipDescriptionsTableAdapter = null;
            this.tableAdapterManager.WipDetailTableAdapter = null;
            this.tableAdapterManager.wipTableAdapter = null;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmEditPartBkWip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 242);
            this.Controls.Add(this.cmbDescription);
            this.Controls.Add(this.lblSchcode);
            this.Controls.Add(this.warDateBox);
            this.Controls.Add(this.wdrDateBox);
            this.Controls.Add(invnoLabel);
            this.Controls.Add(this.txtInvno);
            this.Controls.Add(wirLabel);
            this.Controls.Add(this.wirTextBox);
            this.Controls.Add(wtrLabel);
            this.Controls.Add(this.wtrTextBox);
            this.Controls.Add(wdrLabel);
            this.Controls.Add(warLabel);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(this.partBkDetailBindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmEditPartBkWip";
            this.Text = "Partial Bk Wip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditPartBkWip_FormClosing);
            this.Load += new System.EventHandler(this.frmEditPartBkWip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBkDetailBindingNavigator)).EndInit();
            this.partBkDetailBindingNavigator.ResumeLayout(false);
            this.partBkDetailBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partBkDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private DataSets.dsProdutn dsProdutn;
        private System.Windows.Forms.BindingSource partBkDetailBindingSource;
        private DataSets.dsProdutnTableAdapters.PartBkDetailTableAdapter partBkDetailTableAdapter;
        private DataSets.dsProdutnTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator partBkDetailBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton partBkDetailBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox txtInvno;
        private System.Windows.Forms.TextBox wirTextBox;
        private System.Windows.Forms.TextBox wtrTextBox;
       
        private System.Windows.Forms.ComboBox cmbDescription;
        private DataSets.dsProdutnTableAdapters.WipDescriptionsTableAdapter wipDescriptionsTableAdapter;
        private System.Windows.Forms.BindingSource wipDescriptionsBindingSource;
        private CustomControls.DateBox wdrDateBox;
        private CustomControls.DateBox warDateBox;
        private System.Windows.Forms.Label lblSchcode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
    }