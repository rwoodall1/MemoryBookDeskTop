namespace Mbc5.Forms.MixBook
{
    partial class frmUsPsLabel
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlWeight = new System.Windows.Forms.Panel();
            this.rbLb = new System.Windows.Forms.RadioButton();
            this.rbOz = new System.Windows.Forms.RadioButton();
            this.lblShipPhone = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblShipZipCode = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblShipState = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblShipCity = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblShipAddr2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblShipAddr = new System.Windows.Forms.Label();
            this.lblAddrlbl = new System.Windows.Forms.Label();
            this.lblShpMethod = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblShipName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdummy = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlData.SuspendLayout();
            this.pnlWeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Size = new System.Drawing.Size(18, 17);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "USPS Label";
            // 
            // txtScan
            // 
            this.txtScan.Location = new System.Drawing.Point(141, 42);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(135, 20);
            this.txtScan.TabIndex = 1;
            this.txtScan.Leave += new System.EventHandler(this.txtScan_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Scan Shipment Bar Code";
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.pnlWeight);
            this.pnlData.Controls.Add(this.lblShipPhone);
            this.pnlData.Controls.Add(this.label7);
            this.pnlData.Controls.Add(this.btnPrint);
            this.pnlData.Controls.Add(this.comboBox2);
            this.pnlData.Controls.Add(this.txtWeight);
            this.pnlData.Controls.Add(this.label18);
            this.pnlData.Controls.Add(this.label19);
            this.pnlData.Controls.Add(this.txtLength);
            this.pnlData.Controls.Add(this.txtHeight);
            this.pnlData.Controls.Add(this.txtWidth);
            this.pnlData.Controls.Add(this.label15);
            this.pnlData.Controls.Add(this.label16);
            this.pnlData.Controls.Add(this.label17);
            this.pnlData.Controls.Add(this.label6);
            this.pnlData.Controls.Add(this.lblShipZipCode);
            this.pnlData.Controls.Add(this.label14);
            this.pnlData.Controls.Add(this.lblShipState);
            this.pnlData.Controls.Add(this.label12);
            this.pnlData.Controls.Add(this.lblShipCity);
            this.pnlData.Controls.Add(this.label10);
            this.pnlData.Controls.Add(this.lblShipAddr2);
            this.pnlData.Controls.Add(this.label8);
            this.pnlData.Controls.Add(this.lblShipAddr);
            this.pnlData.Controls.Add(this.lblAddrlbl);
            this.pnlData.Controls.Add(this.lblShpMethod);
            this.pnlData.Controls.Add(this.label4);
            this.pnlData.Controls.Add(this.lblShipName);
            this.pnlData.Controls.Add(this.label3);
            this.pnlData.Location = new System.Drawing.Point(12, 68);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(657, 380);
            this.pnlData.TabIndex = 10065;
            this.pnlData.Visible = false;
            // 
            // pnlWeight
            // 
            this.pnlWeight.Controls.Add(this.rbLb);
            this.pnlWeight.Controls.Add(this.rbOz);
            this.pnlWeight.Location = new System.Drawing.Point(429, 266);
            this.pnlWeight.Name = "pnlWeight";
            this.pnlWeight.Size = new System.Drawing.Size(54, 52);
            this.pnlWeight.TabIndex = 10091;
            // 
            // rbLb
            // 
            this.rbLb.AutoSize = true;
            this.rbLb.Location = new System.Drawing.Point(6, 29);
            this.rbLb.Name = "rbLb";
            this.rbLb.Size = new System.Drawing.Size(38, 17);
            this.rbLb.TabIndex = 10091;
            this.rbLb.Text = "LB";
            this.rbLb.UseVisualStyleBackColor = true;
            // 
            // rbOz
            // 
            this.rbOz.AutoSize = true;
            this.rbOz.Checked = true;
            this.rbOz.Location = new System.Drawing.Point(6, 6);
            this.rbOz.Name = "rbOz";
            this.rbOz.Size = new System.Drawing.Size(40, 17);
            this.rbOz.TabIndex = 10090;
            this.rbOz.TabStop = true;
            this.rbOz.Text = "OZ";
            this.rbOz.UseVisualStyleBackColor = true;
            // 
            // lblShipPhone
            // 
            this.lblShipPhone.AutoSize = true;
            this.lblShipPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblShipPhone.Location = new System.Drawing.Point(125, 185);
            this.lblShipPhone.Name = "lblShipPhone";
            this.lblShipPhone.Size = new System.Drawing.Size(0, 13);
            this.lblShipPhone.TabIndex = 10088;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(70, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 10087;
            this.label7.Text = "Phone";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(511, 343);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 23);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print Label";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Package",
            "Envelope",
            "Flat"});
            this.comboBox2.Location = new System.Drawing.Point(325, 239);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(199, 21);
            this.comboBox2.TabIndex = 7;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(325, 267);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(100, 20);
            this.txtWeight.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(272, 270);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 10086;
            this.label18.Text = "Weight";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(324, 209);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(143, 24);
            this.label19.TabIndex = 10085;
            this.label19.Text = "Package Type";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(119, 266);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 20);
            this.txtLength.TabIndex = 4;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(119, 292);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 5;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(119, 240);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(69, 296);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 10081;
            this.label15.Text = "Height";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(67, 270);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 10080;
            this.label16.Text = "Length";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(73, 244);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 10079;
            this.label17.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 24);
            this.label6.TabIndex = 10078;
            this.label6.Text = "Dimensions (inches)";
            // 
            // lblShipZipCode
            // 
            this.lblShipZipCode.AutoSize = true;
            this.lblShipZipCode.BackColor = System.Drawing.Color.Transparent;
            this.lblShipZipCode.Location = new System.Drawing.Point(125, 165);
            this.lblShipZipCode.Name = "lblShipZipCode";
            this.lblShipZipCode.Size = new System.Drawing.Size(0, 13);
            this.lblShipZipCode.TabIndex = 10077;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(26, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 10076;
            this.label14.Text = "Ship Zip Code";
            // 
            // lblShipState
            // 
            this.lblShipState.AutoSize = true;
            this.lblShipState.BackColor = System.Drawing.Color.Transparent;
            this.lblShipState.Location = new System.Drawing.Point(125, 140);
            this.lblShipState.Name = "lblShipState";
            this.lblShipState.Size = new System.Drawing.Size(0, 13);
            this.lblShipState.TabIndex = 10075;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(47, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 10074;
            this.label12.Text = "Ship State";
            // 
            // lblShipCity
            // 
            this.lblShipCity.AutoSize = true;
            this.lblShipCity.BackColor = System.Drawing.Color.Transparent;
            this.lblShipCity.Location = new System.Drawing.Point(125, 115);
            this.lblShipCity.Name = "lblShipCity";
            this.lblShipCity.Size = new System.Drawing.Size(0, 13);
            this.lblShipCity.TabIndex = 10073;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(56, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 10072;
            this.label10.Text = "Ship City";
            // 
            // lblShipAddr2
            // 
            this.lblShipAddr2.AutoSize = true;
            this.lblShipAddr2.BackColor = System.Drawing.Color.Transparent;
            this.lblShipAddr2.Location = new System.Drawing.Point(125, 91);
            this.lblShipAddr2.Name = "lblShipAddr2";
            this.lblShipAddr2.Size = new System.Drawing.Size(0, 13);
            this.lblShipAddr2.TabIndex = 10071;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 10070;
            this.label8.Text = "Ship Address 2";
            // 
            // lblShipAddr
            // 
            this.lblShipAddr.AutoSize = true;
            this.lblShipAddr.BackColor = System.Drawing.Color.Transparent;
            this.lblShipAddr.Location = new System.Drawing.Point(125, 69);
            this.lblShipAddr.Name = "lblShipAddr";
            this.lblShipAddr.Size = new System.Drawing.Size(0, 13);
            this.lblShipAddr.TabIndex = 10069;
            // 
            // lblAddrlbl
            // 
            this.lblAddrlbl.AutoSize = true;
            this.lblAddrlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddrlbl.Location = new System.Drawing.Point(32, 69);
            this.lblAddrlbl.Name = "lblAddrlbl";
            this.lblAddrlbl.Size = new System.Drawing.Size(81, 13);
            this.lblAddrlbl.TabIndex = 10068;
            this.lblAddrlbl.Text = "Ship Address";
            // 
            // lblShpMethod
            // 
            this.lblShpMethod.AutoSize = true;
            this.lblShpMethod.BackColor = System.Drawing.Color.LightYellow;
            this.lblShpMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShpMethod.Location = new System.Drawing.Point(160, 9);
            this.lblShpMethod.Name = "lblShpMethod";
            this.lblShpMethod.Size = new System.Drawing.Size(0, 24);
            this.lblShpMethod.TabIndex = 10067;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 24);
            this.label4.TabIndex = 10066;
            this.label4.Text = "Ship Method";
            // 
            // lblShipName
            // 
            this.lblShipName.AutoSize = true;
            this.lblShipName.BackColor = System.Drawing.Color.Transparent;
            this.lblShipName.Location = new System.Drawing.Point(125, 44);
            this.lblShipName.Name = "lblShipName";
            this.lblShipName.Size = new System.Drawing.Size(0, 13);
            this.lblShipName.TabIndex = 10065;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 10064;
            this.label3.Text = "Ship Name";
            // 
            // txtdummy
            // 
            this.txtdummy.Location = new System.Drawing.Point(282, 43);
            this.txtdummy.Name = "txtdummy";
            this.txtdummy.ReadOnly = true;
            this.txtdummy.Size = new System.Drawing.Size(1, 20);
            this.txtdummy.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(410, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 10093;
            this.button1.Text = "Print Label";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmUsPsLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(681, 460);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtdummy);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtScan);
            this.Controls.Add(this.label1);
            this.Name = "frmUsPsLabel";
            this.Load += new System.EventHandler(this.frmUsPsLabel_Load);
            this.Controls.SetChildIndex(this.basePanel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtScan, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.Controls.SetChildIndex(this.txtdummy, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.pnlWeight.ResumeLayout(false);
            this.pnlWeight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblShipZipCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblShipState;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblShipCity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblShipAddr2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblShipAddr;
        private System.Windows.Forms.Label lblAddrlbl;
        private System.Windows.Forms.Label lblShpMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblShipName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdummy;
        private System.Windows.Forms.Label lblShipPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlWeight;
        private System.Windows.Forms.RadioButton rbLb;
        private System.Windows.Forms.RadioButton rbOz;
        private System.Windows.Forms.Button button1;
    }
}
