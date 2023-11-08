namespace Mbc5.Dialogs
{
    partial class MeridianNewProdRecord
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
            this.btnNewProd = new System.Windows.Forms.Button();
            this.btnReOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldProdNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNewProd
            // 
            this.btnNewProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProd.Location = new System.Drawing.Point(16, 12);
            this.btnNewProd.Name = "btnNewProd";
            this.btnNewProd.Size = new System.Drawing.Size(117, 23);
            this.btnNewProd.TabIndex = 0;
            this.btnNewProd.Text = "New Production#";
            this.btnNewProd.UseVisualStyleBackColor = true;
            this.btnNewProd.Click += new System.EventHandler(this.btnNewProd_Click);
            // 
            // btnReOrder
            // 
            this.btnReOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReOrder.Location = new System.Drawing.Point(58, 41);
            this.btnReOrder.Name = "btnReOrder";
            this.btnReOrder.Size = new System.Drawing.Size(75, 23);
            this.btnReOrder.TabIndex = 1;
            this.btnReOrder.Text = "Reorder";
            this.btnReOrder.UseVisualStyleBackColor = true;
            this.btnReOrder.Click += new System.EventHandler(this.btnReOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Production #";
            // 
            // txtOldProdNo
            // 
            this.txtOldProdNo.Location = new System.Drawing.Point(225, 41);
            this.txtOldProdNo.MaxLength = 12;
            this.txtOldProdNo.Name = "txtOldProdNo";
            this.txtOldProdNo.Size = new System.Drawing.Size(180, 20);
            this.txtOldProdNo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 50);
            this.label2.TabIndex = 4;
            this.label2.Text = "Caution! The production number entered must be exactly 12 characters long and sta" +
    "rt with an \'M\' !";
            // 
            // MeridianNewProdRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 152);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOldProdNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReOrder);
            this.Controls.Add(this.btnNewProd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MeridianNewProdRecord";
            this.Text = "New Meridian Production Record";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewProd;
        private System.Windows.Forms.Button btnReOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOldProdNo;
        private System.Windows.Forms.Label label2;
    }
}