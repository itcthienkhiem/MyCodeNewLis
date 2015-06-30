namespace CreateLicenseKeyLIS
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dtpHetHan = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.pnlSplit = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtSplit4 = new System.Windows.Forms.TextBox();
            this.txtSplit3 = new System.Windows.Forms.TextBox();
            this.txtSplit2 = new System.Windows.Forms.TextBox();
            this.txtSplit1 = new System.Windows.Forms.TextBox();
            this.txtRegister = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblExpires = new System.Windows.Forms.Label();
            this.lblRegStatus = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpHetHan
            // 
            this.dtpHetHan.Location = new System.Drawing.Point(137, 7);
            this.dtpHetHan.Name = "dtpHetHan";
            this.dtpHetHan.Size = new System.Drawing.Size(200, 20);
            this.dtpHetHan.TabIndex = 84;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(241, 149);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 41);
            this.btnClose.TabIndex = 89;
            this.btnClose.Text = "   &Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(140, 149);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 41);
            this.btnSave.TabIndex = 88;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblHeading.ForeColor = System.Drawing.Color.Black;
            this.lblHeading.Location = new System.Drawing.Point(12, 40);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(89, 18);
            this.lblHeading.TabIndex = 85;
            this.lblHeading.Text = "Key Serial";
            // 
            // pnlSplit
            // 
            this.pnlSplit.Controls.Add(this.Label3);
            this.pnlSplit.Controls.Add(this.Label2);
            this.pnlSplit.Controls.Add(this.Label1);
            this.pnlSplit.Controls.Add(this.txtSplit4);
            this.pnlSplit.Controls.Add(this.txtSplit3);
            this.pnlSplit.Controls.Add(this.txtSplit2);
            this.pnlSplit.Controls.Add(this.txtSplit1);
            this.pnlSplit.Location = new System.Drawing.Point(137, 33);
            this.pnlSplit.Name = "pnlSplit";
            this.pnlSplit.Size = new System.Drawing.Size(262, 41);
            this.pnlSplit.TabIndex = 87;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(181, 12);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(10, 13);
            this.Label3.TabIndex = 83;
            this.Label3.Text = "-";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(117, 12);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(10, 13);
            this.Label2.TabIndex = 82;
            this.Label2.Text = "-";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(53, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(10, 13);
            this.Label1.TabIndex = 81;
            this.Label1.Text = "-";
            // 
            // txtSplit4
            // 
            this.txtSplit4.Location = new System.Drawing.Point(196, 10);
            this.txtSplit4.Name = "txtSplit4";
            this.txtSplit4.Size = new System.Drawing.Size(48, 20);
            this.txtSplit4.TabIndex = 25;
            this.txtSplit4.Text = "PQRST";
            this.txtSplit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSplit4.TextChanged += new System.EventHandler(this.txtSplit_TextChanged);
            // 
            // txtSplit3
            // 
            this.txtSplit3.Location = new System.Drawing.Point(131, 10);
            this.txtSplit3.Name = "txtSplit3";
            this.txtSplit3.Size = new System.Drawing.Size(48, 20);
            this.txtSplit3.TabIndex = 24;
            this.txtSplit3.Text = "KLMNO";
            this.txtSplit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSplit3.TextChanged += new System.EventHandler(this.txtSplit_TextChanged);
            // 
            // txtSplit2
            // 
            this.txtSplit2.Location = new System.Drawing.Point(67, 10);
            this.txtSplit2.Name = "txtSplit2";
            this.txtSplit2.Size = new System.Drawing.Size(48, 20);
            this.txtSplit2.TabIndex = 23;
            this.txtSplit2.Text = "FGHIJ";
            this.txtSplit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSplit2.TextChanged += new System.EventHandler(this.txtSplit_TextChanged);
            // 
            // txtSplit1
            // 
            this.txtSplit1.Location = new System.Drawing.Point(3, 10);
            this.txtSplit1.Name = "txtSplit1";
            this.txtSplit1.Size = new System.Drawing.Size(48, 20);
            this.txtSplit1.TabIndex = 22;
            this.txtSplit1.Text = "ABCDE";
            this.txtSplit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSplit1.TextChanged += new System.EventHandler(this.txtSplit_TextChanged);
            // 
            // txtRegister
            // 
            this.txtRegister.Location = new System.Drawing.Point(137, 80);
            this.txtRegister.Name = "txtRegister";
            this.txtRegister.Size = new System.Drawing.Size(259, 20);
            this.txtRegister.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 18);
            this.label4.TabIndex = 90;
            this.label4.Text = "Ngày đăng ký";
            // 
            // lblExpires
            // 
            this.lblExpires.AutoSize = true;
            this.lblExpires.Location = new System.Drawing.Point(13, 96);
            this.lblExpires.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpires.Name = "lblExpires";
            this.lblExpires.Size = new System.Drawing.Size(39, 13);
            this.lblExpires.TabIndex = 92;
            this.lblExpires.Text = "Label1";
            // 
            // lblRegStatus
            // 
            this.lblRegStatus.AutoSize = true;
            this.lblRegStatus.Location = new System.Drawing.Point(13, 80);
            this.lblRegStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegStatus.Name = "lblRegStatus";
            this.lblRegStatus.Size = new System.Drawing.Size(39, 13);
            this.lblRegStatus.TabIndex = 91;
            this.lblRegStatus.Text = "Label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 20);
            this.textBox1.TabIndex = 93;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 214);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblExpires);
            this.Controls.Add(this.lblRegStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.pnlSplit);
            this.Controls.Add(this.txtRegister);
            this.Controls.Add(this.dtpHetHan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Key ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlSplit.ResumeLayout(false);
            this.pnlSplit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpHetHan;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Panel pnlSplit;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtSplit4;
        private System.Windows.Forms.TextBox txtSplit3;
        private System.Windows.Forms.TextBox txtSplit2;
        private System.Windows.Forms.TextBox txtSplit1;
        private System.Windows.Forms.TextBox txtRegister;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblExpires;
        private System.Windows.Forms.Label lblRegStatus;
        private System.Windows.Forms.TextBox textBox1;
    }
}

