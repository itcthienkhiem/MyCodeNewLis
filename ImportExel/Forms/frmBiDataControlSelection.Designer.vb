<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmBiDataControlSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBiDataControlSelection))
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.cboSortType = New System.Windows.Forms.CheckBox
        Me.txtAge = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPatientName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblRegCount = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBarcode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.imgAdminnistration = New System.Windows.Forms.ImageList(Me.components)
        Me.tabRegList = New System.Windows.Forms.TabControl
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.cboSortType)
        Me.UiGroupBox1.Controls.Add(Me.txtAge)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.txtPatientName)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.lblRegCount)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtBarcode)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(996, 88)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Thông tin Test"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cboSortType
        '
        Me.cboSortType.AutoSize = True
        Me.cboSortType.Location = New System.Drawing.Point(309, 46)
        Me.cboSortType.Name = "cboSortType"
        Me.cboSortType.Size = New System.Drawing.Size(386, 20)
        Me.cboSortType.TabIndex = 9
        Me.cboSortType.Text = "Sắp xếp theo ABC (nút chỉ có tác dụng khi chạy lại form)"
        Me.cboSortType.UseVisualStyleBackColor = True
        '
        'txtAge
        '
        Me.txtAge.Enabled = False
        Me.txtAge.Location = New System.Drawing.Point(345, 20)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(85, 22)
        Me.txtAge.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(306, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tuổi:"
        '
        'txtPatientName
        '
        Me.txtPatientName.Enabled = False
        Me.txtPatientName.Location = New System.Drawing.Point(97, 23)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.Size = New System.Drawing.Size(191, 22)
        Me.txtPatientName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Họ và tên:"
        '
        'lblRegCount
        '
        Me.lblRegCount.AutoSize = True
        Me.lblRegCount.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegCount.ForeColor = System.Drawing.Color.Red
        Me.lblRegCount.Location = New System.Drawing.Point(594, 16)
        Me.lblRegCount.Name = "lblRegCount"
        Me.lblRegCount.Size = New System.Drawing.Size(26, 29)
        Me.lblRegCount.TabIndex = 4
        Me.lblRegCount.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(464, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Số test đã đăng ký:"
        '
        'txtBarcode
        '
        Me.txtBarcode.Enabled = False
        Me.txtBarcode.Location = New System.Drawing.Point(97, 51)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(191, 22)
        Me.txtBarcode.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 54)
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
        '
        'tabRegList
        '
        Me.tabRegList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabRegList.Location = New System.Drawing.Point(0, 88)
        Me.tabRegList.Name = "tabRegList"
        Me.tabRegList.SelectedIndex = 0
        Me.tabRegList.Size = New System.Drawing.Size(996, 419)
        Me.tabRegList.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(306, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(317, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "(Ctrl+A: Chọn Tất Cả      -----      Ctrl+U: Hủy Chọn)"
        '
        'frmBiDataControlSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 507)
        Me.Controls.Add(Me.tabRegList)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBiDataControlSelection"
        Me.Text = "Đăng ký chi tiết Test"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents imgAdminnistration As System.Windows.Forms.ImageList
    Friend WithEvents tabRegList As System.Windows.Forms.TabControl
    Friend WithEvents lblRegCount As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPatientName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSortType As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class