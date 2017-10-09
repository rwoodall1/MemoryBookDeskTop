namespace Mbc5.Reports
{
    partial class ReportTest
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.dsCust = new Mbc5.DataSets.dsCust();
            this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.custTableAdapter = new Mbc5.DataSets.dsCustTableAdapters.custTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsCustTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.dsCust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1007, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(809, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dsCust
            // 
            this.dsCust.DataSetName = "dsCust";
            this.dsCust.EnforceConstraints = false;
            this.dsCust.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // custBindingSource
            // 
            this.custBindingSource.DataMember = "cust";
            this.custBindingSource.DataSource = this.dsCust;
            // 
            // custTableAdapter
            // 
            this.custTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.custSearchTableAdapter = null;
            this.tableAdapterManager.custTableAdapter = this.custTableAdapter;
            this.tableAdapterManager.datecontTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Mbc5.DataSets.dsCustTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ReportTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 419);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportTest";
            this.Text = "ReportTest";
            this.Load += new System.EventHandler(this.ReportTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsCust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button1;
        private DataSets.dsCust dsCust;
        private System.Windows.Forms.BindingSource custBindingSource;
        private DataSets.dsCustTableAdapters.custTableAdapter custTableAdapter;
        private DataSets.dsCustTableAdapters.TableAdapterManager tableAdapterManager;
    }
}