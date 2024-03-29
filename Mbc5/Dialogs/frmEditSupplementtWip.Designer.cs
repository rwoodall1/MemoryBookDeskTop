﻿namespace Mbc5.Dialogs
{
    partial class frmEditSupplementtWip
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
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label warLabel;
            System.Windows.Forms.Label wdrLabel;
            System.Windows.Forms.Label wtrLabel;
            System.Windows.Forms.Label wirLabel;
            System.Windows.Forms.Label invnoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditSupplementtWip));
            this.wipDetailBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
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
            this.dsEndSheet = new Mbc5.DataSets.dsEndSheet();
            this.wipDescriptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProdutn = new Mbc5.DataSets.dsProdutn();
            this.wtrTextBox = new System.Windows.Forms.TextBox();
            this.wirTextBox = new System.Windows.Forms.TextBox();
            this.txtInvno = new System.Windows.Forms.TextBox();
            this.wdrDateBox = new CustomControls.DateBox();
            this.warDateBox = new CustomControls.DateBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblSchcode = new System.Windows.Forms.Label();
            this.wipDescriptionsTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.WipDescriptionsTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsEndSheetTableAdapters.TableAdapterManager();
            this.suppdetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.suppdetailTableAdapter = new Mbc5.DataSets.dsEndSheetTableAdapters.suppdetailTableAdapter();
            descriptionLabel = new System.Windows.Forms.Label();
            warLabel = new System.Windows.Forms.Label();
            wdrLabel = new System.Windows.Forms.Label();
            wtrLabel = new System.Windows.Forms.Label();
            wirLabel = new System.Windows.Forms.Label();
            invnoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wipDetailBindingNavigator)).BeginInit();
            this.wipDetailBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsEndSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppdetailBindingSource)).BeginInit();
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
            // wipDetailBindingNavigator
            // 
            this.wipDetailBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.wipDetailBindingNavigator.BindingSource = this.suppdetailBindingSource;
            this.wipDetailBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.wipDetailBindingNavigator.DeleteItem = null;
            this.wipDetailBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.wipDetailBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.wipDetailBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.wipDetailBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.wipDetailBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.wipDetailBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.wipDetailBindingNavigator.Name = "wipDetailBindingNavigator";
            this.wipDetailBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.wipDetailBindingNavigator.Size = new System.Drawing.Size(390, 25);
            this.wipDetailBindingNavigator.TabIndex = 0;
            this.wipDetailBindingNavigator.Text = "bindingNavigator1";
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
            this.cmbDescription.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.suppdetailBindingSource, "DescripId", true));
            this.cmbDescription.DataSource = this.wipDescriptionsBindingSource;
            this.cmbDescription.DisplayMember = "Description";
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.Location = new System.Drawing.Point(105, 51);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.Size = new System.Drawing.Size(225, 21);
            this.cmbDescription.TabIndex = 0;
            this.cmbDescription.ValueMember = "Id";
            // 
            // dsEndSheet
            // 
            this.dsEndSheet.DataSetName = "dsEndSheet";
            this.dsEndSheet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wipDescriptionsBindingSource
            // 
            this.wipDescriptionsBindingSource.DataMember = "WipDescriptions";
            this.wipDescriptionsBindingSource.DataSource = this.dsProdutn;
            // 
            // dsProdutn
            // 
            this.dsProdutn.DataSetName = "dsProdutn";
            this.dsProdutn.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wtrTextBox
            // 
            this.wtrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.suppdetailBindingSource, "wtr", true));
            this.wtrTextBox.Location = new System.Drawing.Point(105, 136);
            this.wtrTextBox.Name = "wtrTextBox";
            this.wtrTextBox.Size = new System.Drawing.Size(100, 20);
            this.wtrTextBox.TabIndex = 3;
            this.wtrTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.wtrTextBox_Validating);
            // 
            // wirTextBox
            // 
            this.wirTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.suppdetailBindingSource, "wir", true));
            this.wirTextBox.Location = new System.Drawing.Point(105, 168);
            this.wirTextBox.Name = "wirTextBox";
            this.wirTextBox.Size = new System.Drawing.Size(100, 20);
            this.wirTextBox.TabIndex = 4;
            this.wirTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.wirTextBox_Validating);
            // 
            // txtInvno
            // 
            this.txtInvno.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.suppdetailBindingSource, "invno", true));
            this.txtInvno.Location = new System.Drawing.Point(105, 197);
            this.txtInvno.Name = "txtInvno";
            this.txtInvno.ReadOnly = true;
            this.txtInvno.Size = new System.Drawing.Size(100, 20);
            this.txtInvno.TabIndex = 5;
            // 
            // wdrDateBox
            // 
            this.wdrDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.suppdetailBindingSource, "wdr", true));
            this.wdrDateBox.Date = null;
            this.wdrDateBox.DateValue = null;
            this.wdrDateBox.Location = new System.Drawing.Point(105, 108);
            this.wdrDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.wdrDateBox.Name = "wdrDateBox";
            this.wdrDateBox.Size = new System.Drawing.Size(114, 21);
            this.wdrDateBox.TabIndex = 2;
            // 
            // warDateBox
            // 
            this.warDateBox.DataBindings.Add(new System.Windows.Forms.Binding("Date", this.suppdetailBindingSource, "war", true));
            this.warDateBox.Date = null;
            this.warDateBox.DateValue = null;
            this.warDateBox.Location = new System.Drawing.Point(104, 78);
            this.warDateBox.MinimumSize = new System.Drawing.Size(114, 20);
            this.warDateBox.Name = "warDateBox";
            this.warDateBox.Size = new System.Drawing.Size(114, 21);
            this.warDateBox.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblSchcode
            // 
            this.lblSchcode.Location = new System.Drawing.Point(-2, 245);
            this.lblSchcode.Name = "lblSchcode";
            this.lblSchcode.Size = new System.Drawing.Size(1, 1);
            this.lblSchcode.TabIndex = 16;
            this.lblSchcode.Text = "label1";
            // 
            // wipDescriptionsTableAdapter
            // 
            this.wipDescriptionsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.bannerTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.custTableAdapter = null;
            this.tableAdapterManager.endsheetdetailTableAdapter = null;
            this.tableAdapterManager.endsheetTableAdapter = null;
            this.tableAdapterManager.preflitTableAdapter = null;
            this.tableAdapterManager.produtnTableAdapter = null;
            this.tableAdapterManager.suppdetailTableAdapter = null;
            this.tableAdapterManager.supplTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsEndSheetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // suppdetailBindingSource
            // 
            this.suppdetailBindingSource.DataMember = "suppdetail";
            this.suppdetailBindingSource.DataSource = this.dsEndSheet;
            // 
            // suppdetailTableAdapter
            // 
            this.suppdetailTableAdapter.ClearBeforeFill = true;
            // 
            // frmEditSupplementtWip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 283);
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
            this.Controls.Add(this.cmbDescription);
            this.Controls.Add(this.wipDetailBindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditSupplementtWip";
            this.Text = "Supplement WIP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditWip_FormClosing);
            this.Load += new System.EventHandler(this.frmEditWip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wipDetailBindingNavigator)).EndInit();
            this.wipDetailBindingNavigator.ResumeLayout(false);
            this.wipDetailBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsEndSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wipDescriptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppdetailBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingNavigator wipDetailBindingNavigator;
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

        private System.Windows.Forms.TextBox wtrTextBox;
        private System.Windows.Forms.TextBox wirTextBox;
        private System.Windows.Forms.TextBox txtInvno;
        private System.Windows.Forms.BindingSource wipDescriptionsBindingSource;
        private DataSets.dsProdutnTableAdapters.WipDescriptionsTableAdapter wipDescriptionsTableAdapter;
        private CustomControls.DateBox wdrDateBox;
        private CustomControls.DateBox warDateBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblSchcode;
        private DataSets.dsProdutn dsProdutn;
        private DataSets.dsEndSheet dsEndSheet;
        private DataSets.dsEndSheetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource suppdetailBindingSource;
        private DataSets.dsEndSheetTableAdapters.suppdetailTableAdapter suppdetailTableAdapter;
    }
}