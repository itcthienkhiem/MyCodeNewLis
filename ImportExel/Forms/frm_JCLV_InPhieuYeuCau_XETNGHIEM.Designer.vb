<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_JCLV_InPhieuYeuCau_XETNGHIEM
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
        Dim grdTestInfo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_JCLV_InPhieuYeuCau_XETNGHIEM))
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.grdTestInfo = New Janus.Windows.GridEX.GridEX
        Me.cmdPrintPhieu = New Janus.Windows.EditControls.UIButton
        Me.cmdExit = New Janus.Windows.EditControls.UIButton
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.grdTestInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.grdTestInfo)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Image = CType(resources.GetObject("UiGroupBox1.Image"), System.Drawing.Image)
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(360, 240)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "&Thông tin xét nghiệm"
        '
        'grdTestInfo
        '
        grdTestInfo_DesignTimeLayout.LayoutString = resources.GetString("grdTestInfo_DesignTimeLayout.LayoutString")
        Me.grdTestInfo.DesignTimeLayout = grdTestInfo_DesignTimeLayout
        Me.grdTestInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTestInfo.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None
        Me.grdTestInfo.GroupByBoxVisible = False
        Me.grdTestInfo.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdTestInfo.Location = New System.Drawing.Point(3, 18)
        Me.grdTestInfo.Name = "grdTestInfo"
        Me.grdTestInfo.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdTestInfo.Size = New System.Drawing.Size(354, 219)
        Me.grdTestInfo.TabIndex = 0
        '
        'cmdPrintPhieu
        '
        Me.cmdPrintPhieu.Image = CType(resources.GetObject("cmdPrintPhieu.Image"), System.Drawing.Image)
        Me.cmdPrintPhieu.Location = New System.Drawing.Point(74, 246)
        Me.cmdPrintPhieu.Name = "cmdPrintPhieu"
        Me.cmdPrintPhieu.Size = New System.Drawing.Size(100, 23)
        Me.cmdPrintPhieu.TabIndex = 1
        Me.cmdPrintPhieu.Text = "In phiếu(F4)"
        '
        'cmdExit
        '
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.Location = New System.Drawing.Point(180, 246)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(91, 23)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "&Thoát(Esc)"
        '
        'frm_JCLV_InPhieuYeuCau_XETNGHIEM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 275)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrintPhieu)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frm_JCLV_InPhieuYeuCau_XETNGHIEM"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "In phiếu Yêu cầu xét nghiệm"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.grdTestInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents grdTestInfo As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmdPrintPhieu As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdExit As Janus.Windows.EditControls.UIButton
End Class
