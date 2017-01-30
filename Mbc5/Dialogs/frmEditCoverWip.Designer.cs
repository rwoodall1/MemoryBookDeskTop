namespace Mbc5.Dialogs {
    partial class frmEditCoverWip {
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
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label warLabel;
            System.Windows.Forms.Label wdrLabel;
            System.Windows.Forms.Label wtrLabel;
            System.Windows.Forms.Label wirLabel;
            System.Windows.Forms.Label invnoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditCoverWip));
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label idLabel1;
            System.Windows.Forms.Label descriptionLabel1;
            this.coverDetailBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.coverdetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProdutn = new Mbc5.DataSets.dsProdutn();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.wipDetailBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.cmbDescription = new System.Windows.Forms.ComboBox();
            this.wipDescriptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.warDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.wdrDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.wtrTextBox = new System.Windows.Forms.TextBox();
            this.wirTextBox = new System.Windows.Forms.TextBox();
            this.txtInvno = new System.Windows.Forms.TextBox();
            this.tableAdapterManager = new Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager();
            this.wipDescriptionsTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.WipDescriptionsTableAdapter();
            this.coverdetailTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.coverdetailTableAdapter();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox1 = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            descriptionLabel = new System.Windows.Forms.Label();
            warLabel = new System.Windows.Forms.Label();
            wdrLabel = new System.Windows.Forms.Label();
            wtrLabel = new System.Windows.Forms.Label();
            wirLabel = new System.Windows.Forms.Label();
            invnoLabel = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            idLabel1 = new System.Windows.Forms.Label();
            descriptionLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.coverDetailBindingNavigator)).BeginInit();
            this.coverDetailBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverdetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descriptionLabel.Location = new System.Drawing.Point(23, 51);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(75, 13);
            descriptionLabel.TabIndex = 2;
            descriptionLabel.Text = "Description:";
            // 
            // warLabel
            // 
            warLabel.AutoSize = true;
            warLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            warLabel.Location = new System.Drawing.Point(55, 81);
            warLabel.Name = "warLabel";
            warLabel.Size = new System.Drawing.Size(43, 13);
            warLabel.TabIndex = 4;
            warLabel.Text = "Actual";
            // 
            // wdrLabel
            // 
            wdrLabel.AutoSize = true;
            wdrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            wdrLabel.Location = new System.Drawing.Point(68, 108);
            wdrLabel.Name = "wdrLabel";
            wdrLabel.Size = new System.Drawing.Size(30, 13);
            wdrLabel.TabIndex = 6;
            wdrLabel.Text = "Due";
            // 
            // wtrLabel
            // 
            wtrLabel.AutoSize = true;
            wtrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            wtrLabel.Location = new System.Drawing.Point(64, 136);
            wtrLabel.Name = "wtrLabel";
            wtrLabel.Size = new System.Drawing.Size(34, 13);
            wtrLabel.TabIndex = 8;
            wtrLabel.Text = "Time";
            // 
            // wirLabel
            // 
            wirLabel.AutoSize = true;
            wirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            wirLabel.Location = new System.Drawing.Point(54, 168);
            wirLabel.Name = "wirLabel";
            wirLabel.Size = new System.Drawing.Size(44, 13);
            wirLabel.TabIndex = 10;
            wirLabel.Text = "Initials";
            // 
            // invnoLabel
            // 
            invnoLabel.AutoSize = true;
            invnoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            invnoLabel.Location = new System.Drawing.Point(41, 197);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(57, 13);
            invnoLabel.TabIndex = 12;
            invnoLabel.Text = "Invoice#";
            // 
            // coverDetailBindingNavigator
            // 
            this.coverDetailBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.coverDetailBindingNavigator.BindingSource = this.coverdetailBindingSource;
            this.coverDetailBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.coverDetailBindingNavigator.DeleteItem = null;
            this.coverDetailBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.wipDetailBindingNavigatorSaveItem});
            this.coverDetailBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.coverDetailBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.coverDetailBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.coverDetailBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.coverDetailBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.coverDetailBindingNavigator.Name = "coverDetailBindingNavigator";
            this.coverDetailBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.coverDetailBindingNavigator.Size = new System.Drawing.Size(590, 25);
            this.coverDetailBindingNavigator.TabIndex = 0;
            this.coverDetailBindingNavigator.Text = "bindingNavigator1";
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
            // coverdetailBindingSource
            // 
            this.coverdetailBindingSource.DataMember = "coverdetail";
            this.coverdetailBindingSource.DataSource = this.dsProdutn;
            // 
            // dsProdutn
            // 
            this.dsProdutn.DataSetName = "dsProdutn";
            this.dsProdutn.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
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
            // wipDetailBindingNavigatorSaveItem
            // 
            this.wipDetailBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wipDetailBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("wipDetailBindingNavigatorSaveItem.Image")));
            this.wipDetailBindingNavigatorSaveItem.Name = "wipDetailBindingNavigatorSaveItem";
            this.wipDetailBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.wipDetailBindingNavigatorSaveItem.Text = "Save Data";
            this.wipDetailBindingNavigatorSaveItem.Click += new System.EventHandler(this.wipDetailBindingNavigatorSaveItem_Click);
            // 
            // cmbDescription
            // 
            this.cmbDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.coverdetailBindingSource, "Description", true));
            this.cmbDescription.DataSource = this.wipDescriptionsBindingSource;
            this.cmbDescription.DisplayMember = "Description";
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.Location = new System.Drawing.Point(105, 51);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.Size = new System.Drawing.Size(225, 21);
            this.cmbDescription.TabIndex = 3;
            this.cmbDescription.ValueMember = "Id";
            // 
            // wipDescriptionsBindingSource
            // 
            this.wipDescriptionsBindingSource.DataMember = "WipDescriptions";
            this.wipDescriptionsBindingSource.DataSource = this.dsProdutn;
            // 
            // warDateTimePicker
            // 
            this.warDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.coverdetailBindingSource, "war", true));
            this.warDateTimePicker.Location = new System.Drawing.Point(105, 81);
            this.warDateTimePicker.Name = "warDateTimePicker";
            this.warDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.warDateTimePicker.TabIndex = 5;
            // 
            // wdrDateTimePicker
            // 
            this.wdrDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.coverdetailBindingSource, "wdr", true));
            this.wdrDateTimePicker.Location = new System.Drawing.Point(105, 108);
            this.wdrDateTimePicker.Name = "wdrDateTimePicker";
            this.wdrDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.wdrDateTimePicker.TabIndex = 7;
            // 
            // wtrTextBox
            // 
            this.wtrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.coverdetailBindingSource, "wtr", true));
            this.wtrTextBox.Location = new System.Drawing.Point(105, 136);
            this.wtrTextBox.Name = "wtrTextBox";
            this.wtrTextBox.Size = new System.Drawing.Size(100, 20);
            this.wtrTextBox.TabIndex = 9;
            // 
            // wirTextBox
            // 
            this.wirTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.coverdetailBindingSource, "wir", true));
            this.wirTextBox.Location = new System.Drawing.Point(105, 168);
            this.wirTextBox.Name = "wirTextBox";
            this.wirTextBox.Size = new System.Drawing.Size(100, 20);
            this.wirTextBox.TabIndex = 11;
            // 
            // txtInvno
            // 
            this.txtInvno.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.coverdetailBindingSource, "Invno", true));
            this.txtInvno.Location = new System.Drawing.Point(105, 197);
            this.txtInvno.Name = "txtInvno";
            this.txtInvno.ReadOnly = true;
            this.txtInvno.Size = new System.Drawing.Size(100, 20);
            this.txtInvno.TabIndex = 13;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.coverdetailTableAdapter = null;
            this.tableAdapterManager.coversTableAdapter = null;
            this.tableAdapterManager.custTableAdapter = null;
            this.tableAdapterManager.produtnTableAdapter = null;
            this.tableAdapterManager.quotesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WipDescriptionsTableAdapter = null;
            this.tableAdapterManager.WipDetailTableAdapter = null;
            this.tableAdapterManager.wipTableAdapter = null;
            // 
            // wipDescriptionsTableAdapter
            // 
            this.wipDescriptionsTableAdapter.ClearBeforeFill = true;
            // 
            // coverdetailTableAdapter
            // 
            this.coverdetailTableAdapter.ClearBeforeFill = true;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(330, 225);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(18, 13);
            idLabel.TabIndex = 13;
            idLabel.Text = "id:";
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.coverdetailBindingSource, "id", true));
            this.idTextBox.Location = new System.Drawing.Point(354, 222);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 14;
            // 
            // idLabel1
            // 
            idLabel1.AutoSize = true;
            idLabel1.Location = new System.Drawing.Point(376, 193);
            idLabel1.Name = "idLabel1";
            idLabel1.Size = new System.Drawing.Size(19, 13);
            idLabel1.TabIndex = 15;
            idLabel1.Text = "Id:";
            // 
            // idTextBox1
            // 
            this.idTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wipDescriptionsBindingSource, "Id", true));
            this.idTextBox1.Location = new System.Drawing.Point(401, 190);
            this.idTextBox1.Name = "idTextBox1";
            this.idTextBox1.Size = new System.Drawing.Size(100, 20);
            this.idTextBox1.TabIndex = 16;
            // 
            // descriptionLabel1
            // 
            descriptionLabel1.AutoSize = true;
            descriptionLabel1.Location = new System.Drawing.Point(401, 166);
            descriptionLabel1.Name = "descriptionLabel1";
            descriptionLabel1.Size = new System.Drawing.Size(63, 13);
            descriptionLabel1.TabIndex = 17;
            descriptionLabel1.Text = "Description:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wipDescriptionsBindingSource, "Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(470, 163);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.descriptionTextBox.TabIndex = 18;
            // 
            // frmEditCoverWip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 262);
            this.Controls.Add(descriptionLabel1);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(idLabel1);
            this.Controls.Add(this.idTextBox1);
            this.Controls.Add(idLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(invnoLabel);
            this.Controls.Add(this.txtInvno);
            this.Controls.Add(wirLabel);
            this.Controls.Add(this.wirTextBox);
            this.Controls.Add(wtrLabel);
            this.Controls.Add(this.wtrTextBox);
            this.Controls.Add(wdrLabel);
            this.Controls.Add(this.wdrDateTimePicker);
            this.Controls.Add(warLabel);
            this.Controls.Add(this.warDateTimePicker);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(this.cmbDescription);
            this.Controls.Add(this.coverDetailBindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditCoverWip";
            this.Text = "WIP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditWip_FormClosing);
            this.Load += new System.EventHandler(this.frmEditWip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coverDetailBindingNavigator)).EndInit();
            this.coverDetailBindingNavigator.ResumeLayout(false);
            this.coverDetailBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverdetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private DataSets.dsProdutn dsProdutn;
        private DataSets.dsProdutnTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator coverDetailBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton wipDetailBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox cmbDescription;
        private System.Windows.Forms.DateTimePicker warDateTimePicker;
        private System.Windows.Forms.DateTimePicker wdrDateTimePicker;
        private System.Windows.Forms.TextBox wtrTextBox;
        private System.Windows.Forms.TextBox wirTextBox;
        private System.Windows.Forms.TextBox txtInvno;
        private System.Windows.Forms.BindingSource wipDescriptionsBindingSource;
        private DataSets.dsProdutnTableAdapters.WipDescriptionsTableAdapter wipDescriptionsTableAdapter;
        private System.Windows.Forms.BindingSource coverdetailBindingSource;
        private DataSets.dsProdutnTableAdapters.coverdetailTableAdapter coverdetailTableAdapter;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox idTextBox1;
        private System.Windows.Forms.TextBox descriptionTextBox;
        }
    }