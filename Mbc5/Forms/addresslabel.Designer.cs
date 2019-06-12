namespace Mbc5.Forms
{
    partial class addresslabel
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
            System.Windows.Forms.Label schcodeLabel;
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.button1 = new System.Windows.Forms.Button();
            this.dsCust = new Mbc5.DataSets.dsCust();
            this.custBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.custTableAdapter = new Mbc5.DataSets.dsCustTableAdapters.custTableAdapter();
            this.tableAdapterManager = new Mbc5.DataSets.dsCustTableAdapters.TableAdapterManager();
            this.schcodeTextBox = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            schcodeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsCust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // schcodeLabel
            // 
            schcodeLabel.AutoSize = true;
            schcodeLabel.Location = new System.Drawing.Point(313, 8);
            schcodeLabel.Name = "schcodeLabel";
            schcodeLabel.Size = new System.Drawing.Size(51, 13);
            schcodeLabel.TabIndex = 19;
            schcodeLabel.Text = "schcode:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
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
            // schcodeTextBox
            // 
            this.schcodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.custBindingSource, "schcode", true));
            this.schcodeTextBox.Location = new System.Drawing.Point(370, 5);
            this.schcodeTextBox.Name = "schcodeTextBox";
            this.schcodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.schcodeTextBox.TabIndex = 20;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.custBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.AddressLabel.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(120, 113);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(527, 246);
            this.reportViewer1.TabIndex = 21;
            // 
            // addresslabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 472);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(schcodeLabel);
            this.Controls.Add(this.schcodeTextBox);
            this.Controls.Add(this.button1);
            this.Name = "addresslabel";
            this.Text = "addresslabel";
            this.Load += new System.EventHandler(this.addresslabel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsCust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private DataSets.dsCust dsCust;
        private System.Windows.Forms.BindingSource custBindingSource;
        private DataSets.dsCustTableAdapters.custTableAdapter custTableAdapter;
        private DataSets.dsCustTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox schcodeTextBox;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}