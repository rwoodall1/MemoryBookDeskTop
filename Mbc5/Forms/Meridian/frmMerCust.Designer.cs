namespace Mbc5.Forms.Meridian {
    partial class frmMerCust {
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
            this.merCustTab = new System.Windows.Forms.TabControl();
            this.pg1 = new System.Windows.Forms.TabPage();
            this.pg2 = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.merCustTab.SuspendLayout();
            this.pg1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Size = new System.Drawing.Size(1264, 10);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Location = new System.Drawing.Point(0, 710);
            this.BottomPanel.Size = new System.Drawing.Size(1264, 51);
            // 
            // merCustTab
            // 
            this.merCustTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.merCustTab.Controls.Add(this.pg1);
            this.merCustTab.Controls.Add(this.pg2);
            this.merCustTab.Location = new System.Drawing.Point(0, 0);
            this.merCustTab.Name = "merCustTab";
            this.merCustTab.SelectedIndex = 0;
            this.merCustTab.Size = new System.Drawing.Size(1260, 704);
            this.merCustTab.TabIndex = 2;
            // 
            // pg1
            // 
            this.pg1.BackColor = System.Drawing.SystemColors.Control;
            this.pg1.Controls.Add(this.splitContainer);
            this.pg1.Location = new System.Drawing.Point(4, 22);
            this.pg1.Name = "pg1";
            this.pg1.Padding = new System.Windows.Forms.Padding(3);
            this.pg1.Size = new System.Drawing.Size(1252, 678);
            this.pg1.TabIndex = 0;
            this.pg1.Text = "School";
            // 
            // pg2
            // 
            this.pg2.BackColor = System.Drawing.SystemColors.Control;
            this.pg2.Location = new System.Drawing.Point(4, 22);
            this.pg2.Name = "pg2";
            this.pg2.Padding = new System.Windows.Forms.Padding(3);
            this.pg2.Size = new System.Drawing.Size(1252, 678);
            this.pg2.TabIndex = 1;
            this.pg2.Text = "Addresses";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.Transparent;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer.Size = new System.Drawing.Size(1252, 672);
            this.splitContainer.SplitterDistance = 633;
            this.splitContainer.TabIndex = 19;
            // 
            // frmMerCust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.merCustTab);
            this.Name = "frmMerCust";
            this.Text = "Meridian Customers";
            this.Controls.SetChildIndex(this.TopPanel, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.merCustTab, 0);
            this.merCustTab.ResumeLayout(false);
            this.pg1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.TabControl merCustTab;
        private System.Windows.Forms.TabPage pg1;
        private System.Windows.Forms.TabPage pg2;
        private System.Windows.Forms.SplitContainer splitContainer;
        }
    }
