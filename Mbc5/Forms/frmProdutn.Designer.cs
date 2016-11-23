namespace Mbc5.Forms.MemoryBook {
    partial class frmProdutn {
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
            System.Windows.Forms.Label companyLabel;
            System.Windows.Forms.Label invnoLabel;
            System.Windows.Forms.Label prodnoLabel;
            System.Windows.Forms.Label contryearLabel;
            this.tbProdutn = new System.Windows.Forms.TabControl();
            this.pg1 = new System.Windows.Forms.TabPage();
            this.pg2 = new System.Windows.Forms.TabPage();
            this.pg3 = new System.Windows.Forms.TabPage();
            this.pg4 = new System.Windows.Forms.TabPage();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblSchoolName = new System.Windows.Forms.Label();
            this.companyTextBox = new System.Windows.Forms.TextBox();
            this.invnoLabel1 = new System.Windows.Forms.Label();
            this.prodnoLabel1 = new System.Windows.Forms.Label();
            this.contryearLabel1 = new System.Windows.Forms.Label();
            this.allclrckCheckBox = new System.Windows.Forms.CheckBox();
            this.btnBookType = new System.Windows.Forms.Button();
            this.quotesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProdutn = new Mbc5.DataSets.dsProdutn();
            this.produtnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.custTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.custTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager();
            this.produtnTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.produtnTableAdapter();
            this.quotesTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.quotesTableAdapter();
            this.booktypeTextBox = new System.Windows.Forms.TextBox();
            this.bkmixedCheckBox = new System.Windows.Forms.CheckBox();
            companyLabel = new System.Windows.Forms.Label();
            invnoLabel = new System.Windows.Forms.Label();
            prodnoLabel = new System.Windows.Forms.Label();
            contryearLabel = new System.Windows.Forms.Label();
            this.tbProdutn.SuspendLayout();
            this.pg1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbProdutn
            // 
            this.tbProdutn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProdutn.Controls.Add(this.pg1);
            this.tbProdutn.Controls.Add(this.pg2);
            this.tbProdutn.Controls.Add(this.pg3);
            this.tbProdutn.Controls.Add(this.pg4);
            this.tbProdutn.Location = new System.Drawing.Point(0, 0);
            this.tbProdutn.Name = "tbProdutn";
            this.tbProdutn.SelectedIndex = 0;
            this.tbProdutn.Size = new System.Drawing.Size(1228, 731);
            this.tbProdutn.TabIndex = 0;
            // 
            // pg1
            // 
            this.pg1.AutoScroll = true;
            this.pg1.BackColor = System.Drawing.SystemColors.Control;
            this.pg1.Controls.Add(this.bkmixedCheckBox);
            this.pg1.Controls.Add(this.booktypeTextBox);
            this.pg1.Controls.Add(this.btnBookType);
            this.pg1.Controls.Add(this.allclrckCheckBox);
            this.pg1.Controls.Add(contryearLabel);
            this.pg1.Controls.Add(this.contryearLabel1);
            this.pg1.Controls.Add(prodnoLabel);
            this.pg1.Controls.Add(this.prodnoLabel1);
            this.pg1.Controls.Add(invnoLabel);
            this.pg1.Controls.Add(this.invnoLabel1);
            this.pg1.Controls.Add(companyLabel);
            this.pg1.Controls.Add(this.companyTextBox);
            this.pg1.Controls.Add(this.lblSchoolName);
            this.pg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pg1.Location = new System.Drawing.Point(4, 22);
            this.pg1.Name = "pg1";
            this.pg1.Padding = new System.Windows.Forms.Padding(3);
            this.pg1.Size = new System.Drawing.Size(1220, 705);
            this.pg1.TabIndex = 0;
            this.pg1.Text = "Production";
            // 
            // pg2
            // 
            this.pg2.AutoScroll = true;
            this.pg2.BackColor = System.Drawing.SystemColors.Control;
            this.pg2.Location = new System.Drawing.Point(4, 22);
            this.pg2.Name = "pg2";
            this.pg2.Size = new System.Drawing.Size(1220, 705);
            this.pg2.TabIndex = 2;
            this.pg2.Text = "WIP";
            // 
            // pg3
            // 
            this.pg3.AutoScroll = true;
            this.pg3.BackColor = System.Drawing.SystemColors.Control;
            this.pg3.Location = new System.Drawing.Point(4, 22);
            this.pg3.Name = "pg3";
            this.pg3.Padding = new System.Windows.Forms.Padding(3);
            this.pg3.Size = new System.Drawing.Size(1220, 705);
            this.pg3.TabIndex = 1;
            this.pg3.Text = "Special Covers";
            // 
            // pg4
            // 
            this.pg4.AutoScroll = true;
            this.pg4.BackColor = System.Drawing.SystemColors.Control;
            this.pg4.Location = new System.Drawing.Point(4, 22);
            this.pg4.Name = "pg4";
            this.pg4.Size = new System.Drawing.Size(1220, 705);
            this.pg4.TabIndex = 3;
            this.pg4.Text = "Color Pages";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblSchoolName
            // 
            this.lblSchoolName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schname", true));
            this.lblSchoolName.Location = new System.Drawing.Point(1187, 3);
            this.lblSchoolName.Name = "lblSchoolName";
            this.lblSchoolName.Size = new System.Drawing.Size(0, 0);
            this.lblSchoolName.TabIndex = 8;
            this.lblSchoolName.Text = "label1";
            // 
            // companyLabel
            // 
            companyLabel.AutoSize = true;
            companyLabel.Location = new System.Drawing.Point(10, 9);
            companyLabel.Name = "companyLabel";
            companyLabel.Size = new System.Drawing.Size(53, 13);
            companyLabel.TabIndex = 8;
            companyLabel.Text = "company:";
            // 
            // companyTextBox
            // 
            this.companyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "company", true));
            this.companyTextBox.Location = new System.Drawing.Point(69, 6);
            this.companyTextBox.Name = "companyTextBox";
            this.companyTextBox.ReadOnly = true;
            this.companyTextBox.Size = new System.Drawing.Size(49, 20);
            this.companyTextBox.TabIndex = 9;
            // 
            // invnoLabel
            // 
            invnoLabel.AutoSize = true;
            invnoLabel.Location = new System.Drawing.Point(325, 9);
            invnoLabel.Name = "invnoLabel";
            invnoLabel.Size = new System.Drawing.Size(36, 13);
            invnoLabel.TabIndex = 9;
            invnoLabel.Text = "invno:";
            // 
            // invnoLabel1
            // 
            this.invnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "invno", true));
            this.invnoLabel1.Location = new System.Drawing.Point(367, 9);
            this.invnoLabel1.Name = "invnoLabel1";
            this.invnoLabel1.Size = new System.Drawing.Size(100, 23);
            this.invnoLabel1.TabIndex = 10;
            this.invnoLabel1.Text = "label1";
            // 
            // prodnoLabel
            // 
            prodnoLabel.AutoSize = true;
            prodnoLabel.Location = new System.Drawing.Point(127, 9);
            prodnoLabel.Name = "prodnoLabel";
            prodnoLabel.Size = new System.Drawing.Size(43, 13);
            prodnoLabel.TabIndex = 10;
            prodnoLabel.Text = "prodno:";
            // 
            // prodnoLabel1
            // 
            this.prodnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "prodno", true));
            this.prodnoLabel1.Location = new System.Drawing.Point(176, 9);
            this.prodnoLabel1.Name = "prodnoLabel1";
            this.prodnoLabel1.Size = new System.Drawing.Size(100, 23);
            this.prodnoLabel1.TabIndex = 11;
            this.prodnoLabel1.Text = "label1";
            // 
            // contryearLabel
            // 
            contryearLabel.AutoSize = true;
            contryearLabel.Location = new System.Drawing.Point(534, 10);
            contryearLabel.Name = "contryearLabel";
            contryearLabel.Size = new System.Drawing.Size(54, 13);
            contryearLabel.TabIndex = 11;
            contryearLabel.Text = "contryear:";
            // 
            // contryearLabel1
            // 
            this.contryearLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "contryear", true));
            this.contryearLabel1.Location = new System.Drawing.Point(594, 10);
            this.contryearLabel1.Name = "contryearLabel1";
            this.contryearLabel1.Size = new System.Drawing.Size(100, 23);
            this.contryearLabel1.TabIndex = 12;
            this.contryearLabel1.Text = "label1";
            // 
            // allclrckCheckBox
            // 
            this.allclrckCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.quotesBindingSource, "allclrck", true));
            this.allclrckCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allclrckCheckBox.ForeColor = System.Drawing.Color.Red;
            this.allclrckCheckBox.Location = new System.Drawing.Point(1101, 5);
            this.allclrckCheckBox.Name = "allclrckCheckBox";
            this.allclrckCheckBox.Size = new System.Drawing.Size(113, 24);
            this.allclrckCheckBox.TabIndex = 13;
            this.allclrckCheckBox.Text = "All Color Book";
            this.allclrckCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnBookType
            // 
            this.btnBookType.Location = new System.Drawing.Point(13, 52);
            this.btnBookType.Name = "btnBookType";
            this.btnBookType.Size = new System.Drawing.Size(71, 23);
            this.btnBookType.TabIndex = 14;
            this.btnBookType.Text = "Book Type";
            this.btnBookType.UseVisualStyleBackColor = true;
            // 
            // quotesBindingSource
            // 
            this.quotesBindingSource.DataMember = "quotes";
            this.quotesBindingSource.DataSource = this.dsProdutn;
            // 
            // dsProdutn
            // 
            this.dsProdutn.DataSetName = "dsProdutn";
            this.dsProdutn.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // produtnBindingSource
            // 
            this.produtnBindingSource.DataMember = "produtn";
            this.produtnBindingSource.DataSource = this.dsProdutn;
            // 
            // custBindingSource
            // 
            this.custBindingSource.DataMember = "cust";
            this.custBindingSource.DataSource = this.dsProdutn;
            // 
            // custTableAdapter
            // 
            this.custTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.custTableAdapter = this.custTableAdapter;
            this.tableAdapterManager.produtnTableAdapter = this.produtnTableAdapter;
            this.tableAdapterManager.quotesTableAdapter = this.quotesTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // produtnTableAdapter
            // 
            this.produtnTableAdapter.ClearBeforeFill = true;
            // 
            // quotesTableAdapter
            // 
            this.quotesTableAdapter.ClearBeforeFill = true;
            // 
            // booktypeTextBox
            // 
            this.booktypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quotesBindingSource, "booktype", true));
            this.booktypeTextBox.Location = new System.Drawing.Point(90, 52);
            this.booktypeTextBox.Name = "booktypeTextBox";
            this.booktypeTextBox.Size = new System.Drawing.Size(53, 20);
            this.booktypeTextBox.TabIndex = 15;
            // 
            // bkmixedCheckBox
            // 
            this.bkmixedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.produtnBindingSource, "reorder", true));
            this.bkmixedCheckBox.Location = new System.Drawing.Point(689, 10);
            this.bkmixedCheckBox.Name = "bkmixedCheckBox";
            this.bkmixedCheckBox.Size = new System.Drawing.Size(66, 24);
            this.bkmixedCheckBox.TabIndex = 16;
            this.bkmixedCheckBox.Text = "Reorder";
            this.bkmixedCheckBox.UseVisualStyleBackColor = true;
            // 
            // frmProdutn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1234, 731);
            this.Controls.Add(this.tbProdutn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1250, 770);
            this.Name = "frmProdutn";
            this.Text = "Production";
            this.Load += new System.EventHandler(this.frmProdutn_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmProdutn_Paint);
            this.tbProdutn.ResumeLayout(false);
            this.pg1.ResumeLayout(false);
            this.pg1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.TabControl tbProdutn;
        private System.Windows.Forms.TabPage pg1;
        private System.Windows.Forms.TabPage pg3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage pg2;
        private System.Windows.Forms.TabPage pg4;
        private System.Windows.Forms.BindingSource custBindingSource;
        private DataSets.dsProdutn dsProdutn;
        private DataSets.dsProdutnTableAdapters.custTableAdapter custTableAdapter;
        private DataSets.dsProdutnTableAdapters.TableAdapterManager tableAdapterManager;
        private DataSets.dsProdutnTableAdapters.quotesTableAdapter quotesTableAdapter;
        private System.Windows.Forms.BindingSource quotesBindingSource;
        private DataSets.dsProdutnTableAdapters.produtnTableAdapter produtnTableAdapter;
        private System.Windows.Forms.BindingSource produtnBindingSource;
        private System.Windows.Forms.Label lblSchoolName;
        private System.Windows.Forms.TextBox companyTextBox;
        private System.Windows.Forms.Label prodnoLabel1;
        private System.Windows.Forms.Label invnoLabel1;
        private System.Windows.Forms.Label contryearLabel1;
        private System.Windows.Forms.Button btnBookType;
        private System.Windows.Forms.CheckBox allclrckCheckBox;
        private System.Windows.Forms.CheckBox bkmixedCheckBox;
        private System.Windows.Forms.TextBox booktypeTextBox;
        }
    }
