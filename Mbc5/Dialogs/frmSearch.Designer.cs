namespace Mbc5.Forms.MemoryBook {
	partial class frmSearch {
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
			this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.custTableAdapter = new Mbc5.DataSets.dsSalesTableAdapters.custTableAdapter();
			this.tableAdapterManager = new Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager();
			this.button1 = new System.Windows.Forms.Button();
			this.dgSearch = new System.Windows.Forms.DataGridView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSearch)).BeginInit();
			this.SuspendLayout();
			// 
			// custTableAdapter
			// 
			this.custTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager
			// 
			this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager.custTableAdapter = this.custTableAdapter;
			this.tableAdapterManager.InvHstTableAdapter = null;
			this.tableAdapterManager.quotesTableAdapter = null;
			this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsSalesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(84, 40);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// dgSearch
			// 
			this.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgSearch.Location = new System.Drawing.Point(12, 141);
			this.dgSearch.Name = "dgSearch";
			this.dgSearch.Size = new System.Drawing.Size(295, 216);
			this.dgSearch.TabIndex = 1;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 115);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(119, 20);
			this.textBox1.TabIndex = 2;
			// 
			// frmSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.dgSearch);
			this.Controls.Add(this.button1);
			this.Name = "frmSearch";
			this.Text = "test";
			this.Load += new System.EventHandler(this.frmSearch_Load);
			((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSearch)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn56;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn59;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn62;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn63;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn8;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn64;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn10;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn11;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn65;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn66;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn67;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn69;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn70;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn71;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn72;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn73;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn74;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn75;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn76;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn77;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn12;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn13;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn79;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn14;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn15;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn80;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn16;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn81;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn82;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn83;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn84;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn85;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn86;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn87;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn88;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn89;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn90;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn91;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn92;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn93;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn94;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn95;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn96;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn17;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn97;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn98;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn99;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn100;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn18;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn101;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn102;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn103;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn104;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn106;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn107;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn108;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn19;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn109;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn110;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn111;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn20;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn112;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn113;
		private System.Windows.Forms.BindingSource custBindingSource;
		private DataSets.dsSalesTableAdapters.custTableAdapter custTableAdapter;
		private DataSets.dsSalesTableAdapters.TableAdapterManager tableAdapterManager;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dgSearch;
		private System.Windows.Forms.TextBox textBox1;
	}
}