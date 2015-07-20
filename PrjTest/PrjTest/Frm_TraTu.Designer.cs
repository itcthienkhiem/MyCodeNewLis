namespace PrjTest
{
    partial class Frm_TraTu
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
            this.txtTiengViet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTiengAnh = new PrjTest.BetterTextbox();
            this.SuspendLayout();
            // 
            // txtTiengViet
            // 
            this.txtTiengViet.Location = new System.Drawing.Point(453, 81);
            this.txtTiengViet.Margin = new System.Windows.Forms.Padding(4);
            this.txtTiengViet.Name = "txtTiengViet";
            this.txtTiengViet.Size = new System.Drawing.Size(307, 26);
            this.txtTiengViet.TabIndex = 0;
            this.txtTiengViet.TextChanged += new System.EventHandler(this.txtTiengViet_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ tiếng anh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dịch tiếng việt:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "TRA TỪ  ANH - VIỆT";
            // 
            // txtTiengAnh
            // 
            this.txtTiengAnh.Location = new System.Drawing.Point(111, 81);
            this.txtTiengAnh.Margin = new System.Windows.Forms.Padding(4);
            this.txtTiengAnh.Name = "txtTiengAnh";
            this.txtTiengAnh.Size = new System.Drawing.Size(223, 26);
            this.txtTiengAnh.TabIndex = 4;
            this.txtTiengAnh.TextChanged += new System.EventHandler(this.txtTiengAnh_TextChanged);
            // 
            // Frm_TraTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 181);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTiengAnh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTiengViet);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_TraTu";
            this.ShowIcon = false;
            this.Text = "Chức năng tra từ điển Anh - Việt";
            this.Load += new System.EventHandler(this.Frm_TraTu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_TraTu_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_TraTu_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTiengViet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private PrjTest.BetterTextbox txtTiengAnh;
        private System.Windows.Forms.Label label1;
    }
}

