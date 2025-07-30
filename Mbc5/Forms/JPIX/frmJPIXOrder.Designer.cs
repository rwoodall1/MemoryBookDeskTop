namespace Mbc5.Forms.JPIX
{
    partial class frmJPIXOrder
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.jPIXOrdersDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.RequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OracleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jPIXOrdersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsJPIXOrders = new Mbc5.dsJPIXOrders();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.btnPrntProd = new System.Windows.Forms.Button();
            this.jPIXOrdersTableAdapter = new Mbc5.dsJPIXOrdersTableAdapters.JPIXOrdersTableAdapter();
            this.tableAdapterManager = new Mbc5.dsJPIXOrdersTableAdapters.TableAdapterManager();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.jPIXOrdersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPIXOrdersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsJPIXOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Location = new System.Drawing.Point(1076, 12);
            this.basePanel.Size = new System.Drawing.Size(94, 19);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(-118, 151);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(37, 23);
            this.btnEdit.TabIndex = 10019;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // jPIXOrdersDataGridView
            // 
            this.jPIXOrdersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jPIXOrdersDataGridView.AutoGenerateColumns = false;
            this.jPIXOrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jPIXOrdersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn15,
            this.RequestId,
            this.dataGridViewTextBoxColumn2,
            this.DateReceived,
            this.OracleCode,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn7});
            this.jPIXOrdersDataGridView.DataSource = this.jPIXOrdersBindingSource;
            this.jPIXOrdersDataGridView.Location = new System.Drawing.Point(3, 45);
            this.jPIXOrdersDataGridView.Name = "jPIXOrdersDataGridView";
            this.jPIXOrdersDataGridView.Size = new System.Drawing.Size(1167, 474);
            this.jPIXOrdersDataGridView.TabIndex = 10019;
            this.jPIXOrdersDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jPIXOrdersDataGridView_CellClick);
            this.jPIXOrdersDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jPIXOrdersDataGridView_CellDoubleClick);
            this.jPIXOrdersDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.jPIXOrdersDataGridView_RowEnter);
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Invno";
            this.dataGridViewTextBoxColumn15.HeaderText = "Invoice#";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn15.Width = 74;
            // 
            // RequestId
            // 
            this.RequestId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.RequestId.DataPropertyName = "RequestId";
            this.RequestId.HeaderText = "Request";
            this.RequestId.Name = "RequestId";
            this.RequestId.Width = 72;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NeedsByDate";
            this.dataGridViewTextBoxColumn2.HeaderText = "Ship By Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // DateReceived
            // 
            this.DateReceived.DataPropertyName = "DateReceived";
            this.DateReceived.HeaderText = "DateReceived";
            this.DateReceived.Name = "DateReceived";
            // 
            // OracleCode
            // 
            this.OracleCode.DataPropertyName = "OracleCode";
            this.OracleCode.HeaderText = "OracleCode";
            this.OracleCode.Name = "OracleCode";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Document";
            this.dataGridViewTextBoxColumn1.FillWeight = 200F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Document";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ProductType";
            this.dataGridViewTextBoxColumn3.HeaderText = "Product Type";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ShipToContact";
            this.dataGridViewTextBoxColumn5.HeaderText = "Ship Contact";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ShipToCustomerName";
            this.dataGridViewTextBoxColumn6.FillWeight = 150F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Customer Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Reference";
            this.dataGridViewTextBoxColumn14.HeaderText = "Reference";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 82;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "OracleCode";
            this.dataGridViewTextBoxColumn7.HeaderText = "OracleCode";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // jPIXOrdersBindingSource
            // 
            this.jPIXOrdersBindingSource.DataMember = "JPIXOrders";
            this.jPIXOrdersBindingSource.DataSource = this.dsJPIXOrders;
            // 
            // dsJPIXOrders
            // 
            this.dsJPIXOrders.DataSetName = "dsJPIXOrders";
            this.dsJPIXOrders.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblRecCount
            // 
            this.lblRecCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecCount.AutoSize = true;
            this.lblRecCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecCount.Location = new System.Drawing.Point(504, 522);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(130, 13);
            this.lblRecCount.TabIndex = 10020;
            this.lblRecCount.Text = "No Records Available";
            // 
            // btnPrntProd
            // 
            this.btnPrntProd.Location = new System.Drawing.Point(12, 8);
            this.btnPrntProd.Name = "btnPrntProd";
            this.btnPrntProd.Size = new System.Drawing.Size(128, 23);
            this.btnPrntProd.TabIndex = 10022;
            this.btnPrntProd.Text = "Print Produtin Ticket";
            this.btnPrntProd.UseVisualStyleBackColor = true;
            this.btnPrntProd.Click += new System.EventHandler(this.btnPrntProd_Click);
            // 
            // jPIXOrdersTableAdapter
            // 
            this.jPIXOrdersTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.JPIXOrdersTableAdapter = this.jPIXOrdersTableAdapter;
            this.tableAdapterManager.UpdateOrder = Mbc5.dsJPIXOrdersTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 35;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.JPIXJobTicketQuery.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 396);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(156, 102);
            this.reportViewer1.TabIndex = 10023;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // frmJPIXOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1172, 554);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnPrntProd);
            this.Controls.Add(this.lblRecCount);
            this.Controls.Add(this.jPIXOrdersDataGridView);
            this.Controls.Add(this.btnEdit);
            this.Name = "frmJPIXOrder";
            this.Text = "JPIX Flyer Orders";
            this.Load += new System.EventHandler(this.frmJPIXOrder_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.jPIXOrdersDataGridView, 0);
            this.Controls.SetChildIndex(this.lblRecCount, 0);
            this.Controls.SetChildIndex(this.btnPrntProd, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.jPIXOrdersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jPIXOrdersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsJPIXOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private dsJPIXOrders dsJPIXOrders;
        private System.Windows.Forms.BindingSource jPIXOrdersBindingSource;
        private dsJPIXOrdersTableAdapters.JPIXOrdersTableAdapter jPIXOrdersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn productTypeDataGridViewTextBoxColumn;
        private dsJPIXOrdersTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView jPIXOrdersDataGridView;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.Button btnPrntProd;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn OracleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}
