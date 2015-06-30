<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_JCLV_INPHIEU_YCAU_XN_HANGLOAT
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_JCLV_INPHIEU_YCAU_XN_HANGLOAT))
        Me.cmdExit = New Janus.Windows.EditControls.UIButton
        Me.cmdPrintPhieu = New Janus.Windows.EditControls.UIButton
        Me.radThongTinXN = New Janus.Windows.EditControls.UIRadioButton
        Me.radThongTinBenhNhan = New Janus.Windows.EditControls.UIRadioButton
        Me.ProgressBar1 = New Janus.Windows.EditControls.UIProgressBar
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.Location = New System.Drawing.Point(178, 72)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(91, 23)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "&Thoát(Esc)"
        '
        'cmdPrintPhieu
        '
        Me.cmdPrintPhieu.Image = CType(resources.GetObject("cmdPrintPhieu.Image"), System.Drawing.Image)
        Me.cmdPrintPhieu.Location = New System.Drawing.Point(72, 72)
        Me.cmdPrintPhieu.Name = "cmdPrintPhieu"
        Me.cmdPrintPhieu.Size = New System.Drawing.Size(100, 23)
        Me.cmdPrintPhieu.TabIndex = 3
        Me.cmdPrintPhieu.Text = "In phiếu(F4)"
        '
        'radThongTinXN
        '
        Me.radThongTinXN.Checked = True
        Me.radThongTinXN.Location = New System.Drawing.Point(42, 36)
        Me.radThongTinXN.Name = "radThongTinXN"
        Me.radThongTinXN.Size = New System.Drawing.Size(149, 22)
        Me.radThongTinXN.TabIndex = 5
        Me.radThongTinXN.TabStop = True
        Me.radThongTinXN.Text = "&In chi tiết xét nghiệm"
        '
        'radThongTinBenhNhan
        '
        Me.radThongTinBenhNhan.Location = New System.Drawing.Point(172, 36)
        Me.radThongTinBenhNhan.Name = "radThongTinBenhNhan"
        Me.radThongTinBenhNhan.Size = New System.Drawing.Size(149, 22)
        Me.radThongTinBenhNhan.TabIndex = 6
        Me.radThongTinBenhNhan.Text = "&In thông tin bệnh nhân"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 0)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.ShowPercentage = True
        Me.ProgressBar1.Size = New System.Drawing.Size(334, 30)
        Me.ProgressBar1.TabIndex = 7
        Me.ProgressBar1.Visible = False
        '
        'frm_JCLV_INPHIEU_YCAU_XN_HANGLOAT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 103)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.radThongTinBenhNhan)
        Me.Controls.Add(Me.radThongTinXN)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrintPhieu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_JCLV_INPHIEU_YCAU_XN_HANGLOAT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "In phiếu xét nghiệm hàng loạt"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExit As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdPrintPhieu As Janus.Windows.EditControls.UIButton
    Friend WithEvents radThongTinXN As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents radThongTinBenhNhan As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents ProgressBar1 As Janus.Windows.EditControls.UIProgressBar
End Class
