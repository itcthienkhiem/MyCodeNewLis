<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SignInfor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SignInfor))
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkGhiLai = New System.Windows.Forms.CheckBox
        Me.txtNoiDungKy = New System.Windows.Forms.TextBox
        Me.cboFontSize = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboFontName = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBaoCao = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdQuit = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cboFontStyle = New Janus.Windows.EditControls.UIComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cboFontStyle)
        Me.GroupBox1.Controls.Add(Me.chkGhiLai)
        Me.GroupBox1.Controls.Add(Me.txtNoiDungKy)
        Me.GroupBox1.Controls.Add(Me.cboFontSize)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboFontName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtBaoCao)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 272)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkGhiLai
        '
        Me.chkGhiLai.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkGhiLai.AutoSize = True
        Me.chkGhiLai.Checked = True
        Me.chkGhiLai.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGhiLai.Location = New System.Drawing.Point(105, 247)
        Me.chkGhiLai.Name = "chkGhiLai"
        Me.chkGhiLai.Size = New System.Drawing.Size(166, 19)
        Me.chkGhiLai.TabIndex = 1
        Me.chkGhiLai.TabStop = False
        Me.chkGhiLai.Text = "Ghi lại cho lần dùng sau?"
        Me.chkGhiLai.UseVisualStyleBackColor = True
        '
        'txtNoiDungKy
        '
        Me.txtNoiDungKy.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiDungKy.Location = New System.Drawing.Point(105, 102)
        Me.txtNoiDungKy.Multiline = True
        Me.txtNoiDungKy.Name = "txtNoiDungKy"
        Me.txtNoiDungKy.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNoiDungKy.Size = New System.Drawing.Size(443, 139)
        Me.txtNoiDungKy.TabIndex = 4
        Me.txtNoiDungKy.WordWrap = False
        '
        'cboFontSize
        '
        Me.cboFontSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFontSize.FormattingEnabled = True
        Me.cboFontSize.Location = New System.Drawing.Point(377, 71)
        Me.cboFontSize.Name = "cboFontSize"
        Me.cboFontSize.Size = New System.Drawing.Size(171, 23)
        Me.cboFontSize.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(323, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Cỡ chữ"
        '
        'cboFontName
        '
        Me.cboFontName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFontName.FormattingEnabled = True
        Me.cboFontName.Location = New System.Drawing.Point(105, 40)
        Me.cboFontName.Name = "cboFontName"
        Me.cboFontName.Size = New System.Drawing.Size(443, 23)
        Me.cboFontName.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tên báo cáo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Kiểu chữ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Font chữ"
        '
        'txtBaoCao
        '
        Me.txtBaoCao.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBaoCao.Location = New System.Drawing.Point(105, 13)
        Me.txtBaoCao.Name = "txtBaoCao"
        Me.txtBaoCao.Size = New System.Drawing.Size(443, 21)
        Me.txtBaoCao.TabIndex = 0
        Me.txtBaoCao.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tên báo cáo"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(66, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(510, 49)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "TÙY BIẾN TRÌNH KÝ CHO CÁC BÁO CÁO"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(190, 338)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(102, 30)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "Chấp nhận"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdQuit
        '
        Me.cmdQuit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdQuit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdQuit.Location = New System.Drawing.Point(298, 338)
        Me.cmdQuit.Name = "cmdQuit"
        Me.cmdQuit.Size = New System.Drawing.Size(102, 30)
        Me.cmdQuit.TabIndex = 5
        Me.cmdQuit.Text = "Thoát"
        Me.cmdQuit.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 50)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'cboFontStyle
        '
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.IsSeparator = False
        UiComboBoxItem1.Text = "Chữ đậm"
        UiComboBoxItem1.Value = "Chữ đậm"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.IsSeparator = False
        UiComboBoxItem2.Text = "Chữ nghiêng"
        UiComboBoxItem2.Value = "Chữ nghiêng"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.IsSeparator = False
        UiComboBoxItem3.Text = "Bình thường"
        UiComboBoxItem3.Value = "Bình thường"
        Me.cboFontStyle.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3})
        Me.cboFontStyle.Location = New System.Drawing.Point(105, 70)
        Me.cboFontStyle.Name = "cboFontStyle"
        Me.cboFontStyle.Size = New System.Drawing.Size(212, 21)
        Me.cboFontStyle.TabIndex = 8
        Me.cboFontStyle.Text = "Chữ đậm"
        '
        'frm_SignInfor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 383)
        Me.Controls.Add(Me.cmdQuit)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_SignInfor"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thông tin trình ký"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoiDungKy As System.Windows.Forms.TextBox
    Friend WithEvents cboFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboFontName As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBaoCao As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkGhiLai As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdQuit As System.Windows.Forms.Button
    Friend WithEvents cboFontStyle As Janus.Windows.EditControls.UIComboBox
End Class
