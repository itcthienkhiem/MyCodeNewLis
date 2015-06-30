<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDepartmentTestReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDepartmentTestReport))
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnDanhMucDonVi = New System.Windows.Forms.Button
        Me.cboDonVi = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboTestType = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtmTo = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtmFrom = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDepartID = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cmdReport = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(66, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(327, 60)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "XUẤT DỮ LIỆU RA FILE EXCELL"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDanhMucDonVi)
        Me.GroupBox1.Controls.Add(Me.cboDonVi)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cboTestType)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtmTo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtmFrom)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(387, 103)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnDanhMucDonVi
        '
        Me.btnDanhMucDonVi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDanhMucDonVi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDanhMucDonVi.Image = CType(resources.GetObject("btnDanhMucDonVi.Image"), System.Drawing.Image)
        Me.btnDanhMucDonVi.Location = New System.Drawing.Point(357, 71)
        Me.btnDanhMucDonVi.Name = "btnDanhMucDonVi"
        Me.btnDanhMucDonVi.Size = New System.Drawing.Size(24, 23)
        Me.btnDanhMucDonVi.TabIndex = 136
        Me.btnDanhMucDonVi.TabStop = False
        Me.btnDanhMucDonVi.UseVisualStyleBackColor = True
        Me.btnDanhMucDonVi.Visible = False
        '
        'cboDonVi
        '
        Me.cboDonVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDonVi.Location = New System.Drawing.Point(110, 71)
        Me.cboDonVi.Name = "cboDonVi"
        Me.cboDonVi.Size = New System.Drawing.Size(241, 21)
        Me.cboDonVi.TabIndex = 134
        Me.cboDonVi.TabStop = False
        Me.cboDonVi.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(65, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 135
        Me.Label10.Text = "Đơn Vị"
        Me.Label10.Visible = False
        '
        'cboTestType
        '
        Me.cboTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTestType.FormattingEnabled = True
        Me.cboTestType.Location = New System.Drawing.Point(110, 47)
        Me.cboTestType.Name = "cboTestType"
        Me.cboTestType.Size = New System.Drawing.Size(271, 21)
        Me.cboTestType.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Loại xét nghiệm"
        '
        'dtmTo
        '
        Me.dtmTo.CustomFormat = "dd/MM/yyyy"
        Me.dtmTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtmTo.Location = New System.Drawing.Point(277, 22)
        Me.dtmTo.Name = "dtmTo"
        Me.dtmTo.ShowUpDown = True
        Me.dtmTo.Size = New System.Drawing.Size(103, 20)
        Me.dtmTo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(214, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "đến ngày"
        '
        'dtmFrom
        '
        Me.dtmFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtmFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtmFrom.Location = New System.Drawing.Point(110, 22)
        Me.dtmFrom.Name = "dtmFrom"
        Me.dtmFrom.ShowUpDown = True
        Me.dtmFrom.Size = New System.Drawing.Size(98, 20)
        Me.dtmFrom.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Từ ngày"
        '
        'txtDepartID
        '
        Me.txtDepartID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDepartID.Location = New System.Drawing.Point(15, 133)
        Me.txtDepartID.MaxLength = 50
        Me.txtDepartID.Name = "txtDepartID"
        Me.txtDepartID.ReadOnly = True
        Me.txtDepartID.Size = New System.Drawing.Size(219, 20)
        Me.txtDepartID.TabIndex = 19
        Me.txtDepartID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'cmdReport
        '
        Me.cmdReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReport.Image = CType(resources.GetObject("cmdReport.Image"), System.Drawing.Image)
        Me.cmdReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdReport.Location = New System.Drawing.Point(87, 222)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(117, 33)
        Me.cmdReport.TabIndex = 3
        Me.cmdReport.Text = "&Xuất Dữ Liệu"
        Me.cmdReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdReport.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdClose.Location = New System.Drawing.Point(221, 222)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(99, 33)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "&Thoát(Esc)"
        Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 202)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(387, 15)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 20
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(6, 173)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(387, 23)
        Me.ProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar2.TabIndex = 21
        '
        'FrmDepartmentTestReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 262)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtDepartID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDepartmentTestReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Xuất dữ liệu ra file Excell"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTestType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtmTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtmFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDepartID As System.Windows.Forms.TextBox
    Friend WithEvents btnDanhMucDonVi As System.Windows.Forms.Button
    Friend WithEvents cboDonVi As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
End Class
