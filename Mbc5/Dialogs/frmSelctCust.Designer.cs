namespace Mbc5.Dialogs {
    partial class frmSelctCust {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.datagrid = new System.Windows.Forms.DataGridView();
			this.schcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
			this.SuspendLayout();
			// 
			// datagrid
			// 
			this.datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.schcode,
            this.Column1,
            this.City,
            this.State});
			this.datagrid.EnableHeadersVisualStyles = false;
			this.datagrid.Location = new System.Drawing.Point(1, 36);
			this.datagrid.Name = "datagrid";
			this.datagrid.Size = new System.Drawing.Size(625, 150);
			this.datagrid.TabIndex = 0;
			this.datagrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_CellDoubleClick);
			// 
			// schcode
			// 
			this.schcode.DataPropertyName = "schcode";
			this.schcode.HeaderText = "Code";
			this.schcode.Name = "schcode";
			this.schcode.ReadOnly = true;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "schname";
			this.Column1.HeaderText = "Name";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// City
			// 
			this.City.DataPropertyName = "schcity";
			this.City.HeaderText = "City";
			this.City.Name = "City";
			this.City.ReadOnly = true;
			// 
			// State
			// 
			this.State.DataPropertyName = "schstate";
			this.State.HeaderText = "State";
			this.State.Name = "State";
			this.State.ReadOnly = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(626, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "More than one school with this name was located. Please double click the one you " +
    "want.";
			// 
			// frmSelctCust
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 187);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.datagrid);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSelctCust";
			this.Text = "Select School";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn schcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.Label label1;
        }
    }