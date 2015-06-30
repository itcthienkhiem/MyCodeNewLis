namespace Lis.GiaoDien.Forms
{
    partial class frmPrintBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintBarcode));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.chk4so = new System.Windows.Forms.CheckBox();
            this.nmrTo = new System.Windows.Forms.NumericUpDown();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtXNid = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.cboPrinters = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.nmrFrom = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(354, 245);
            this.TabControl1.TabIndex = 104;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.nmrTo);
            this.TabPage1.Controls.Add(this.Label11);
            this.TabPage1.Controls.Add(this.Label5);
            this.TabPage1.Controls.Add(this.txtXNid);
            this.TabPage1.Controls.Add(this.cmdClose);
            this.TabPage1.Controls.Add(this.btnPrint);
            this.TabPage1.Controls.Add(this.Label3);
            this.TabPage1.Controls.Add(this.ProgressBar1);
            this.TabPage1.Controls.Add(this.cboPrinters);
            this.TabPage1.Controls.Add(this.Label7);
            this.TabPage1.Controls.Add(this.dtpNgay);
            this.TabPage1.Controls.Add(this.nmrFrom);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Controls.Add(this.chk4so);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(346, 219);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "In Barcode";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // chk4so
            // 
            this.chk4so.AutoSize = true;
            this.chk4so.Location = new System.Drawing.Point(127, 133);
            this.chk4so.Name = "chk4so";
            this.chk4so.Size = new System.Drawing.Size(89, 17);
            this.chk4so.TabIndex = 111;
            this.chk4so.Text = "Barcode 5 số";
            this.chk4so.UseVisualStyleBackColor = true;
            // 
            // nmrTo
            // 
            this.nmrTo.Location = new System.Drawing.Point(127, 104);
            this.nmrTo.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nmrTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrTo.Name = "nmrTo";
            this.nmrTo.Size = new System.Drawing.Size(105, 20);
            this.nmrTo.TabIndex = 4;
            this.nmrTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(16, 108);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(62, 13);
            this.Label11.TabIndex = 110;
            this.Label11.Text = "Số kết thúc";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(16, 32);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(40, 13);
            this.Label5.TabIndex = 101;
            this.Label5.Text = "Mã XN";
            this.Label5.Visible = false;
            // 
            // txtXNid
            // 
            this.txtXNid.Location = new System.Drawing.Point(127, 28);
            this.txtXNid.Name = "txtXNid";
            this.txtXNid.Size = new System.Drawing.Size(105, 20);
            this.txtXNid.TabIndex = 2;
            this.txtXNid.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(156, 156);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(132, 39);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "Thoát (Esc)";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(7, 156);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(143, 39);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "In Barcode (F1)";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(16, 14);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(38, 13);
            this.Label3.TabIndex = 100;
            this.Label3.Text = "Máy in";
            this.Label3.Visible = false;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgressBar1.Location = new System.Drawing.Point(3, 202);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(340, 14);
            this.ProgressBar1.TabIndex = 105;
            this.ProgressBar1.Visible = false;
            // 
            // cboPrinters
            // 
            this.cboPrinters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinters.FormattingEnabled = true;
            this.cboPrinters.Location = new System.Drawing.Point(127, 10);
            this.cboPrinters.Name = "cboPrinters";
            this.cboPrinters.Size = new System.Drawing.Size(197, 21);
            this.cboPrinters.TabIndex = 0;
            this.cboPrinters.Visible = false;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(16, 48);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(32, 13);
            this.Label7.TabIndex = 100;
            this.Label7.Text = "Ngày";
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(127, 44);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(105, 20);
            this.dtpNgay.TabIndex = 1;
            // 
            // nmrFrom
            // 
            this.nmrFrom.Location = new System.Drawing.Point(127, 70);
            this.nmrFrom.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nmrFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrFrom.Name = "nmrFrom";
            this.nmrFrom.Size = new System.Drawing.Size(105, 20);
            this.nmrFrom.TabIndex = 3;
            this.nmrFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 74);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(60, 13);
            this.Label1.TabIndex = 104;
            this.Label1.Text = "Số bắt đầu";
            // 
            // frmPrintBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 245);
            this.Controls.Add(this.TabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintBarcode";
            this.ShowIcon = false;
            this.Text = "Chức năng in barcode hàng loạt";
            this.Load += new System.EventHandler(this.frmPrintBarcode_Load);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrFrom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.NumericUpDown nmrTo;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtXNid;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.ComboBox cboPrinters;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.DateTimePicker dtpNgay;
        internal System.Windows.Forms.NumericUpDown nmrFrom;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.CheckBox chk4so;







    }
}