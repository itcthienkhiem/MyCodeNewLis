<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmBiDataControlSelection_ListViewStyle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBiDataControlSelection_ListViewStyle))
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.btnConfig = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkShowGroup = New System.Windows.Forms.CheckBox
        Me.cboViewStyle = New System.Windows.Forms.ComboBox
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.txtAge = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPatientName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblRegCount = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBarcode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.imgAdminnistration = New System.Windows.Forms.ImageList(Me.components)
        Me.grbTestDetail = New System.Windows.Forms.GroupBox
        Me.grbFillter = New System.Windows.Forms.GroupBox
        Me.lblFillter = New System.Windows.Forms.Label
        Me.txtFillter = New System.Windows.Forms.TextBox
        Me.lstTestDetail = New BrightIdeasSoftware.DataListView
        Me.colData_Name = New BrightIdeasSoftware.OLVColumn
        Me.HighlightTextRenderer1 = New BrightIdeasSoftware.HighlightTextRenderer
        Me.colTestData_ID = New BrightIdeasSoftware.OLVColumn
        Me.colTestType_ID = New BrightIdeasSoftware.OLVColumn
        Me.colData_Sequence = New BrightIdeasSoftware.OLVColumn
        Me.colMeasure_Unit = New BrightIdeasSoftware.OLVColumn
        Me.colData_Point = New BrightIdeasSoftware.OLVColumn
        Me.colNormal_Level = New BrightIdeasSoftware.OLVColumn
        Me.colNormal_LevelW = New BrightIdeasSoftware.OLVColumn
        Me.colData_View = New BrightIdeasSoftware.OLVColumn
        Me.colData_Print = New BrightIdeasSoftware.OLVColumn
        Me.colDescription = New BrightIdeasSoftware.OLVColumn
        Me.coltestDetailStatus = New BrightIdeasSoftware.OLVColumn
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grbTestDetail.SuspendLayout()
        Me.grbFillter.SuspendLayout()
        CType(Me.lstTestDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnConfig)
        Me.UiGroupBox1.Controls.Add(Me.GroupBox1)
        Me.UiGroupBox1.Controls.Add(Me.btnSelectAll)
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
        Me.UiGroupBox1.Size = New System.Drawing.Size(910, 88)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Thông tin Test"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'btnConfig
        '
        Me.btnConfig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfig.Image = CType(resources.GetObject("btnConfig.Image"), System.Drawing.Image)
        Me.btnConfig.Location = New System.Drawing.Point(878, 12)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(26, 23)
        Me.btnConfig.TabIndex = 49
        Me.btnConfig.TabStop = False
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkShowGroup)
        Me.GroupBox1.Controls.Add(Me.cboViewStyle)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(610, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 48)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cấu hình hiển thị"
        '
        'chkShowGroup
        '
        Me.chkShowGroup.AutoSize = True
        Me.chkShowGroup.Checked = True
        Me.chkShowGroup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowGroup.Location = New System.Drawing.Point(10, 15)
        Me.chkShowGroup.Name = "chkShowGroup"
        Me.chkShowGroup.Size = New System.Drawing.Size(140, 19)
        Me.chkShowGroup.TabIndex = 12
        Me.chkShowGroup.TabStop = False
        Me.chkShowGroup.Text = "Hiển Thị Theo Nhóm"
        Me.chkShowGroup.UseVisualStyleBackColor = True
        '
        'cboViewStyle
        '
        Me.cboViewStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboViewStyle.FormattingEnabled = True
        Me.cboViewStyle.Items.AddRange(New Object() {"LargeIcon", "Details", "SmallIcon", "List", "Tile"})
        Me.cboViewStyle.Location = New System.Drawing.Point(173, 13)
        Me.cboViewStyle.Name = "cboViewStyle"
        Me.cboViewStyle.Size = New System.Drawing.Size(104, 23)
        Me.cboViewStyle.TabIndex = 11
        Me.cboViewStyle.TabStop = False
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(320, 17)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(126, 65)
        Me.btnSelectAll.TabIndex = 13
        Me.btnSelectAll.TabStop = False
        Me.btnSelectAll.Text = "Chọn Tất Cả (Ctrl+A)"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'txtAge
        '
        Me.txtAge.BackColor = System.Drawing.Color.White
        Me.txtAge.ForeColor = System.Drawing.Color.Black
        Me.txtAge.Location = New System.Drawing.Point(98, 39)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ReadOnly = True
        Me.txtAge.ShortcutsEnabled = False
        Me.txtAge.Size = New System.Drawing.Size(216, 22)
        Me.txtAge.TabIndex = 8
        Me.txtAge.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(53, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tuổi:"
        '
        'txtPatientName
        '
        Me.txtPatientName.BackColor = System.Drawing.Color.White
        Me.txtPatientName.ForeColor = System.Drawing.Color.Black
        Me.txtPatientName.Location = New System.Drawing.Point(98, 17)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.ReadOnly = True
        Me.txtPatientName.ShortcutsEnabled = False
        Me.txtPatientName.Size = New System.Drawing.Size(216, 22)
        Me.txtPatientName.TabIndex = 6
        Me.txtPatientName.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 20)
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
        Me.lblRegCount.Location = New System.Drawing.Point(582, 53)
        Me.lblRegCount.Name = "lblRegCount"
        Me.lblRegCount.Size = New System.Drawing.Size(26, 29)
        Me.lblRegCount.TabIndex = 4
        Me.lblRegCount.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(452, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Số test đã đăng ký:"
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.Color.White
        Me.txtBarcode.ForeColor = System.Drawing.Color.Black
        Me.txtBarcode.Location = New System.Drawing.Point(98, 61)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.ReadOnly = True
        Me.txtBarcode.ShortcutsEnabled = False
        Me.txtBarcode.Size = New System.Drawing.Size(216, 22)
        Me.txtBarcode.TabIndex = 2
        Me.txtBarcode.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Barcode:"
        '
        'imgAdminnistration
        '
        Me.imgAdminnistration.ImageStream = CType(resources.GetObject("imgAdminnistration.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgAdminnistration.TransparentColor = System.Drawing.Color.Transparent
        Me.imgAdminnistration.Images.SetKeyName(0, "check")
        Me.imgAdminnistration.Images.SetKeyName(1, "uncheck")
        Me.imgAdminnistration.Images.SetKeyName(2, "disable")
        '
        'grbTestDetail
        '
        Me.grbTestDetail.Controls.Add(Me.grbFillter)
        Me.grbTestDetail.Controls.Add(Me.lstTestDetail)
        Me.grbTestDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbTestDetail.Location = New System.Drawing.Point(0, 88)
        Me.grbTestDetail.Name = "grbTestDetail"
        Me.grbTestDetail.Size = New System.Drawing.Size(910, 355)
        Me.grbTestDetail.TabIndex = 1
        Me.grbTestDetail.TabStop = False
        Me.grbTestDetail.Text = "&Danh sách các xét nghiệm"
        '
        'grbFillter
        '
        Me.grbFillter.Controls.Add(Me.lblFillter)
        Me.grbFillter.Controls.Add(Me.txtFillter)
        Me.grbFillter.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbFillter.Location = New System.Drawing.Point(3, 18)
        Me.grbFillter.Name = "grbFillter"
        Me.grbFillter.Size = New System.Drawing.Size(904, 37)
        Me.grbFillter.TabIndex = 54
        Me.grbFillter.TabStop = False
        '
        'lblFillter
        '
        Me.lblFillter.AutoSize = True
        Me.lblFillter.Location = New System.Drawing.Point(8, 14)
        Me.lblFillter.Name = "lblFillter"
        Me.lblFillter.Size = New System.Drawing.Size(108, 16)
        Me.lblFillter.TabIndex = 53
        Me.lblFillter.Text = "Tìm Nhanh (F3):"
        '
        'txtFillter
        '
        Me.txtFillter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFillter.BackColor = System.Drawing.Color.White
        Me.txtFillter.ForeColor = System.Drawing.Color.Black
        Me.txtFillter.Location = New System.Drawing.Point(125, 12)
        Me.txtFillter.Name = "txtFillter"
        Me.txtFillter.ShortcutsEnabled = False
        Me.txtFillter.Size = New System.Drawing.Size(770, 22)
        Me.txtFillter.TabIndex = 52
        '
        'lstTestDetail
        '
        Me.lstTestDetail.AllColumns.Add(Me.colData_Name)
        Me.lstTestDetail.AllColumns.Add(Me.colTestData_ID)
        Me.lstTestDetail.AllColumns.Add(Me.colTestType_ID)
        Me.lstTestDetail.AllColumns.Add(Me.colData_Sequence)
        Me.lstTestDetail.AllColumns.Add(Me.colMeasure_Unit)
        Me.lstTestDetail.AllColumns.Add(Me.colData_Point)
        Me.lstTestDetail.AllColumns.Add(Me.colNormal_Level)
        Me.lstTestDetail.AllColumns.Add(Me.colNormal_LevelW)
        Me.lstTestDetail.AllColumns.Add(Me.colData_View)
        Me.lstTestDetail.AllColumns.Add(Me.colData_Print)
        Me.lstTestDetail.AllColumns.Add(Me.colDescription)
        Me.lstTestDetail.AllColumns.Add(Me.coltestDetailStatus)
        Me.lstTestDetail.AllowColumnReorder = True
        Me.lstTestDetail.AlternateRowBackColor = System.Drawing.Color.Gainsboro
        Me.lstTestDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstTestDetail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colData_Name, Me.colData_Sequence, Me.colMeasure_Unit, Me.colNormal_Level, Me.colNormal_LevelW, Me.coltestDetailStatus})
        Me.lstTestDetail.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstTestDetail.DataSource = Nothing
        Me.lstTestDetail.GridLines = True
        Me.lstTestDetail.HideSelection = False
        Me.lstTestDetail.LargeImageList = Me.imgAdminnistration
        Me.lstTestDetail.Location = New System.Drawing.Point(3, 55)
        Me.lstTestDetail.MultiSelect = False
        Me.lstTestDetail.Name = "lstTestDetail"
        Me.lstTestDetail.SelectAllOnControlA = False
        Me.lstTestDetail.ShowGroups = False
        Me.lstTestDetail.ShowItemCountOnGroups = True
        Me.lstTestDetail.Size = New System.Drawing.Size(904, 275)
        Me.lstTestDetail.SmallImageList = Me.imgAdminnistration
        Me.lstTestDetail.SpaceBetweenGroups = 2
        Me.lstTestDetail.TabIndex = 0
        Me.lstTestDetail.UseCompatibleStateImageBehavior = False
        Me.lstTestDetail.UseHotItem = True
        Me.lstTestDetail.View = System.Windows.Forms.View.Details
        '
        'colData_Name
        '
        Me.colData_Name.AspectName = "Data_Name"
        Me.colData_Name.HeaderImageKey = "kopeteavailable.png"
        Me.colData_Name.IsTileViewColumn = True
        Me.colData_Name.Renderer = Me.HighlightTextRenderer1
        Me.colData_Name.Sortable = False
        Me.colData_Name.Text = "Tên xét nghiệm"
        Me.colData_Name.UseInitialLetterForGroup = True
        Me.colData_Name.Width = 238
        Me.colData_Name.WordWrap = True
        '
        'HighlightTextRenderer1
        '
        Me.HighlightTextRenderer1.CanWrap = True
        Me.HighlightTextRenderer1.UseGdiTextRendering = False
        '
        'colTestData_ID
        '
        Me.colTestData_ID.AspectName = "TestData_ID"
        Me.colTestData_ID.DisplayIndex = 0
        Me.colTestData_ID.IsVisible = False
        Me.colTestData_ID.Text = "TestData_ID"
        Me.colTestData_ID.Width = 100
        '
        'colTestType_ID
        '
        Me.colTestType_ID.AspectName = "TestType_ID"
        Me.colTestType_ID.DisplayIndex = 1
        Me.colTestType_ID.IsVisible = False
        Me.colTestType_ID.Text = "TestType_ID"
        '
        'colData_Sequence
        '
        Me.colData_Sequence.AspectName = "Data_Sequence"
        Me.colData_Sequence.Text = "Số TT"
        Me.colData_Sequence.Width = 120
        '
        'colMeasure_Unit
        '
        Me.colMeasure_Unit.AspectName = "Measure_Unit"
        Me.colMeasure_Unit.IsTileViewColumn = True
        Me.colMeasure_Unit.Text = "Đơn vị"
        Me.colMeasure_Unit.Width = 100
        '
        'colData_Point
        '
        Me.colData_Point.AspectName = "Data_Point"
        Me.colData_Point.DisplayIndex = 3
        Me.colData_Point.IsVisible = False
        Me.colData_Point.Text = "Data_Point"
        '
        'colNormal_Level
        '
        Me.colNormal_Level.AspectName = "Normal_Level"
        Me.colNormal_Level.Text = "Mức BT Nam"
        Me.colNormal_Level.Width = 103
        '
        'colNormal_LevelW
        '
        Me.colNormal_LevelW.AspectName = "Normal_LevelW"
        Me.colNormal_LevelW.Text = "Mức BT Nữ"
        Me.colNormal_LevelW.Width = 129
        '
        'colData_View
        '
        Me.colData_View.AspectName = "Data_View"
        Me.colData_View.CheckBoxes = True
        Me.colData_View.DisplayIndex = 8
        Me.colData_View.IsVisible = False
        Me.colData_View.Text = "Data_View"
        '
        'colData_Print
        '
        Me.colData_Print.AspectName = "Data_Print"
        Me.colData_Print.CheckBoxes = True
        Me.colData_Print.DisplayIndex = 9
        Me.colData_Print.IsVisible = False
        Me.colData_Print.Text = "Data_Print"
        '
        'colDescription
        '
        Me.colDescription.AspectName = "Description"
        Me.colDescription.DisplayIndex = 10
        Me.colDescription.FillsFreeSpace = True
        Me.colDescription.IsVisible = False
        Me.colDescription.Text = "Description"
        '
        'coltestDetailStatus
        '
        Me.coltestDetailStatus.AspectName = "testDetailStatus"
        Me.coltestDetailStatus.GroupWithItemCountFormat = ""
        Me.coltestDetailStatus.GroupWithItemCountSingularFormat = ""
        Me.coltestDetailStatus.Text = "Trạng thái"
        Me.coltestDetailStatus.Width = 211
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 421)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(910, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Image = CType(resources.GetObject("ToolStripStatusLabel2.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(214, 17)
        Me.ToolStripStatusLabel2.Text = " - Xét nghiệm chưa được đăng ký     "
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Image = CType(resources.GetObject("ToolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(201, 17)
        Me.ToolStripStatusLabel1.Text = " - Xét nghiệm đã được đăng ký     "
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Image = CType(resources.GetObject("ToolStripStatusLabel3.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(169, 17)
        Me.ToolStripStatusLabel3.Text = " - Xét nghiệm đã có kết quả"
        '
        'frmBiDataControlSelection_ListViewStyle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 443)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grbTestDetail)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBiDataControlSelection_ListViewStyle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Đăng ký chi tiết Test"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grbTestDetail.ResumeLayout(False)
        Me.grbFillter.ResumeLayout(False)
        Me.grbFillter.PerformLayout()
        CType(Me.lstTestDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents imgAdminnistration As System.Windows.Forms.ImageList
    Friend WithEvents lblRegCount As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPatientName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grbTestDetail As System.Windows.Forms.GroupBox
    Friend WithEvents lstTestDetail As BrightIdeasSoftware.DataListView
    Friend WithEvents colTestData_ID As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colTestType_ID As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colData_Sequence As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colData_Name As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colMeasure_Unit As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colData_Point As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colNormal_Level As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colNormal_LevelW As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colData_View As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colData_Print As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colDescription As BrightIdeasSoftware.OLVColumn
    Private WithEvents cboViewStyle As System.Windows.Forms.ComboBox
    Private WithEvents chkShowGroup As System.Windows.Forms.CheckBox
    Friend WithEvents HighlightTextRenderer1 As BrightIdeasSoftware.HighlightTextRenderer
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents coltestDetailStatus As BrightIdeasSoftware.OLVColumn
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtFillter As System.Windows.Forms.TextBox
    Friend WithEvents grbFillter As System.Windows.Forms.GroupBox
    Friend WithEvents lblFillter As System.Windows.Forms.Label
End Class