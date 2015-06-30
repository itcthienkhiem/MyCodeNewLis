Imports prjBussiness.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDataControlSelectionByTestType
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataControlSelectionByTestType))
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.cboSortType = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBarcode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.imgAdminnistration = New System.Windows.Forms.ImageList(Me.components)
        Me.tabRegList = New System.Windows.Forms.TabControl
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cboSortType)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtBarcode)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(1067, 56)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Thông tin Test"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cboSortType
        '
        Me.cboSortType.AutoSize = True
        Me.cboSortType.Location = New System.Drawing.Point(302, 24)
        Me.cboSortType.Name = "cboSortType"
        Me.cboSortType.Size = New System.Drawing.Size(386, 20)
        Me.cboSortType.TabIndex = 10
        Me.cboSortType.Text = "Sắp xếp theo ABC (nút chỉ có tác dụng khi chạy lại form)"
        Me.cboSortType.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(694, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(282, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "(Ctrl+A: chọn tất cả - Ctrl+U: bỏ chọn tất cả)"
        '
        'txtBarcode
        '
        Me.txtBarcode.Enabled = False
        Me.txtBarcode.Location = New System.Drawing.Point(89, 22)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(150, 22)
        Me.txtBarcode.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Barcode:"
        '
        'imgAdminnistration
        '
        Me.imgAdminnistration.ImageStream = CType(resources.GetObject("imgAdminnistration.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgAdminnistration.TransparentColor = System.Drawing.Color.Transparent
        Me.imgAdminnistration.Images.SetKeyName(0, "kopeteavailable.png")
        Me.imgAdminnistration.Images.SetKeyName(1, "clean.png")
        Me.imgAdminnistration.Images.SetKeyName(2, "flag.png")
        '
        'tabRegList
        '
        Me.tabRegList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabRegList.Location = New System.Drawing.Point(0, 56)
        Me.tabRegList.Name = "tabRegList"
        Me.tabRegList.SelectedIndex = 0
        Me.tabRegList.Size = New System.Drawing.Size(1067, 434)
        Me.tabRegList.TabIndex = 3
        '
        'frmDataControlSelectionByTestType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 490)
        Me.Controls.Add(Me.tabRegList)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmDataControlSelectionByTestType"
        Me.Text = "Đăng ký chi tiết Test"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents imgAdminnistration As System.Windows.Forms.ImageList
    Friend WithEvents tabRegList As System.Windows.Forms.TabControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSortType As System.Windows.Forms.CheckBox
    Public WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Public WithEvents txtBarcode As System.Windows.Forms.TextBox
End Class