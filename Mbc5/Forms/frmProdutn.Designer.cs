namespace Mbc5.Forms {
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
            System.Windows.Forms.Label prodnoLabel;
            this.tabProdutn = new System.Windows.Forms.TabControl();
            this.pg1 = new System.Windows.Forms.TabPage();
            this.pg2 = new System.Windows.Forms.TabPage();
            this.dsProdutn = new Mbc5.DataSets.dsProdutn();
            this.produtnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtnTableAdapter = new Mbc5.DataSets.dsProdutnTableAdapters.produtnTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager();
            this.fillToolStrip = new System.Windows.Forms.ToolStrip();
            this.schcodeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.schcodeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.prodnoLabel1 = new System.Windows.Forms.Label();
            prodnoLabel = new System.Windows.Forms.Label();
            this.tabProdutn.SuspendLayout();
            this.pg1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).BeginInit();
            this.fillToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabProdutn
            // 
            this.tabProdutn.Controls.Add(this.pg1);
            this.tabProdutn.Controls.Add(this.pg2);
            this.tabProdutn.Location = new System.Drawing.Point(0, 0);
            this.tabProdutn.Name = "tabProdutn";
            this.tabProdutn.SelectedIndex = 0;
            this.tabProdutn.Size = new System.Drawing.Size(1229, 759);
            this.tabProdutn.TabIndex = 0;
            // 
            // pg1
            // 
            this.pg1.BackColor = System.Drawing.SystemColors.Control;
            this.pg1.Controls.Add(prodnoLabel);
            this.pg1.Controls.Add(this.prodnoLabel1);
            this.pg1.Location = new System.Drawing.Point(4, 22);
            this.pg1.Name = "pg1";
            this.pg1.Padding = new System.Windows.Forms.Padding(3);
            this.pg1.Size = new System.Drawing.Size(1221, 733);
            this.pg1.TabIndex = 0;
            this.pg1.Text = "Production";
            // 
            // pg2
            // 
            this.pg2.BackColor = System.Drawing.SystemColors.Control;
            this.pg2.Location = new System.Drawing.Point(4, 22);
            this.pg2.Name = "pg2";
            this.pg2.Padding = new System.Windows.Forms.Padding(3);
            this.pg2.Size = new System.Drawing.Size(1221, 733);
            this.pg2.TabIndex = 1;
            this.pg2.Text = "WIP";
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
            // produtnTableAdapter
            // 
            this.produtnTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.produtnTableAdapter = this.produtnTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsProdutnTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // fillToolStrip
            // 
            this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schcodeToolStripLabel,
            this.schcodeToolStripTextBox,
            this.fillToolStripButton});
            this.fillToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillToolStrip.Name = "fillToolStrip";
            this.fillToolStrip.Size = new System.Drawing.Size(1234, 25);
            this.fillToolStrip.TabIndex = 2;
            this.fillToolStrip.Text = "fillToolStrip";
            // 
            // schcodeToolStripLabel
            // 
            this.schcodeToolStripLabel.Name = "schcodeToolStripLabel";
            this.schcodeToolStripLabel.Size = new System.Drawing.Size(55, 22);
            this.schcodeToolStripLabel.Text = "Schcode:";
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
            // prodnoLabel
            // 
            prodnoLabel.AutoSize = true;
            prodnoLabel.Location = new System.Drawing.Point(15, 14);
            prodnoLabel.Name = "prodnoLabel";
            prodnoLabel.Size = new System.Drawing.Size(43, 13);
            prodnoLabel.TabIndex = 0;
            prodnoLabel.Text = "prodno:";
            // 
            // prodnoLabel1
            // 
            this.prodnoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtnBindingSource, "prodno", true));
            this.prodnoLabel1.Location = new System.Drawing.Point(64, 14);
            this.prodnoLabel1.Name = "prodnoLabel1";
            this.prodnoLabel1.Size = new System.Drawing.Size(100, 23);
            this.prodnoLabel1.TabIndex = 1;
            this.prodnoLabel1.Text = "label1";
            // 
            // frmProdutn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1234, 761);
            this.Controls.Add(this.fillToolStrip);
            this.Controls.Add(this.tabProdutn);
            this.Name = "frmProdutn";
            this.Text = "Production";
            this.tabProdutn.ResumeLayout(false);
            this.pg1.ResumeLayout(false);
            this.pg1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtnBindingSource)).EndInit();
            this.fillToolStrip.ResumeLayout(false);
            this.fillToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TabControl tabProdutn;
        private System.Windows.Forms.TabPage pg1;
        private System.Windows.Forms.TabPage pg2;
        private DataSets.dsProdutn dsProdutn;
        private System.Windows.Forms.BindingSource produtnBindingSource;
        private DataSets.dsProdutnTableAdapters.produtnTableAdapter produtnTableAdapter;
        private DataSets.dsProdutnTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ToolStrip fillToolStrip;
        private System.Windows.Forms.ToolStripLabel schcodeToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox schcodeToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
        private System.Windows.Forms.Label prodnoLabel1;
        }
    }
