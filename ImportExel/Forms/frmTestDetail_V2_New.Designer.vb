<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmTestDetail_V2_New
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTestDetail_V2_New))
        Dim grdTestInfo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim grdResultDetail_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim grdPatients_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmd_InPhieu_XetNghiem_TongHop = New System.Windows.Forms.ToolStripSplitButton()
        Me.cmd_InPhieu_XetNghiem = New System.Windows.Forms.ToolStripSplitButton()
        Me.cmdAddPatient = New System.Windows.Forms.ToolStripButton()
        Me.btnParaEntry = New System.Windows.Forms.ToolStripButton()
        Me.btnRegData = New System.Windows.Forms.ToolStripButton()
        Me.cmdEscape = New System.Windows.Forms.ToolStripSplitButton()
        Me.ConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmdSearch = New Janus.Windows.EditControls.UIButton()
        Me.Barcode2 = New Mabry.Windows.Forms.Barcode.Barcode()
        Me.Barcode1 = New Mabry.Windows.Forms.Barcode.Barcode()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtPID = New System.Windows.Forms.TextBox()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.cboSex = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.clbTestType = New System.Windows.Forms.CheckedListBox()
        Me.cmsTestTypeList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChọnTấtCảToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HủyChọnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.SplitContainerResult = New System.Windows.Forms.SplitContainer()
        Me.grdTestInfo = New Janus.Windows.GridEX.GridEX()
        Me.cmsTestIdList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.grdResultDetail = New Janus.Windows.GridEX.GridEX()
        Me.cmsResultDetail = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmAddDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmManualAddDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDelDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdXoaCheck = New Janus.Windows.EditControls.UIButton()
        Me.WarningBoxTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btnExpandPanel = New Janus.Windows.EditControls.UIButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grbDateSelector = New System.Windows.Forms.GroupBox()
        Me.btnLinkUnlink = New System.Windows.Forms.Button()
        Me.LinkUnlinkImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.dtpTestDateTo = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.dtpTestDateFrom = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboDate = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Warningmesage = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.grdPatients = New Janus.Windows.GridEX.GridEX()
        Me.cmsPatients = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ProgressBar1 = New Janus.Windows.EditControls.UIProgressBar()
        Me.chkHasResult = New Janus.Windows.EditControls.UICheckBox()
        Me.cmdInHangLoat = New Janus.Windows.EditControls.UIButton()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.cmsTestTypeList.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SplitContainerResult.Panel1.SuspendLayout()
        Me.SplitContainerResult.Panel2.SuspendLayout()
        Me.SplitContainerResult.SuspendLayout()
        CType(Me.grdTestInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsTestIdList.SuspendLayout()
        CType(Me.grdResultDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsResultDetail.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grbDateSelector.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.grdPatients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPatients.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_InPhieu_XetNghiem_TongHop, Me.cmd_InPhieu_XetNghiem, Me.cmdAddPatient, Me.btnParaEntry, Me.btnRegData, Me.cmdEscape})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1000, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmd_InPhieu_XetNghiem_TongHop
        '
        Me.cmd_InPhieu_XetNghiem_TongHop.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_InPhieu_XetNghiem_TongHop.Image = CType(resources.GetObject("cmd_InPhieu_XetNghiem_TongHop.Image"), System.Drawing.Image)
        Me.cmd_InPhieu_XetNghiem_TongHop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmd_InPhieu_XetNghiem_TongHop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmd_InPhieu_XetNghiem_TongHop.Name = "cmd_InPhieu_XetNghiem_TongHop"
        Me.cmd_InPhieu_XetNghiem_TongHop.Size = New System.Drawing.Size(150, 36)
        Me.cmd_InPhieu_XetNghiem_TongHop.Text = "In Phiếu XN (F4)"
        '
        'cmd_InPhieu_XetNghiem
        '
        Me.cmd_InPhieu_XetNghiem.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_InPhieu_XetNghiem.Image = CType(resources.GetObject("cmd_InPhieu_XetNghiem.Image"), System.Drawing.Image)
        Me.cmd_InPhieu_XetNghiem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmd_InPhieu_XetNghiem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmd_InPhieu_XetNghiem.Name = "cmd_InPhieu_XetNghiem"
        Me.cmd_InPhieu_XetNghiem.Size = New System.Drawing.Size(183, 36)
        Me.cmd_InPhieu_XetNghiem.Text = "In XN Đang Chọn (F5)"
        '
        'cmdAddPatient
        '
        Me.cmdAddPatient.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddPatient.Image = CType(resources.GetObject("cmdAddPatient.Image"), System.Drawing.Image)
        Me.cmdAddPatient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdAddPatient.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddPatient.Name = "cmdAddPatient"
        Me.cmdAddPatient.Size = New System.Drawing.Size(153, 36)
        Me.cmdAddPatient.Text = "Thêm BN (Ctrl+N)"
        Me.cmdAddPatient.Visible = False
        '
        'btnParaEntry
        '
        Me.btnParaEntry.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnParaEntry.Image = CType(resources.GetObject("btnParaEntry.Image"), System.Drawing.Image)
        Me.btnParaEntry.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnParaEntry.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnParaEntry.Name = "btnParaEntry"
        Me.btnParaEntry.Size = New System.Drawing.Size(154, 36)
        Me.btnParaEntry.Text = "Thêm KQ (Ctrl+K)"
        '
        'btnRegData
        '
        Me.btnRegData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegData.Image = CType(resources.GetObject("btnRegData.Image"), System.Drawing.Image)
        Me.btnRegData.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnRegData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRegData.Name = "btnRegData"
        Me.btnRegData.Size = New System.Drawing.Size(174, 36)
        Me.btnRegData.Text = "Lấy Đăng Ký (Ctrl+L)"
        '
        'cmdEscape
        '
        Me.cmdEscape.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigToolStripMenuItem})
        Me.cmdEscape.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEscape.Image = CType(resources.GetObject("cmdEscape.Image"), System.Drawing.Image)
        Me.cmdEscape.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdEscape.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdEscape.Name = "cmdEscape"
        Me.cmdEscape.Size = New System.Drawing.Size(121, 36)
        Me.cmdEscape.Text = "Thoát(Esc)"
        '
        'ConfigToolStripMenuItem
        '
        Me.ConfigToolStripMenuItem.Image = CType(resources.GetObject("ConfigToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConfigToolStripMenuItem.Name = "ConfigToolStripMenuItem"
        Me.ConfigToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.ConfigToolStripMenuItem.Text = "Cấu Hình"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmdSearch)
        Me.GroupBox5.Controls.Add(Me.Barcode2)
        Me.GroupBox5.Controls.Add(Me.Barcode1)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox5.Location = New System.Drawing.Point(800, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(200, 160)
        Me.GroupBox5.TabIndex = 35
        Me.GroupBox5.TabStop = False
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch.Image = CType(resources.GetObject("cmdSearch.Image"), System.Drawing.Image)
        Me.cmdSearch.Location = New System.Drawing.Point(8, 17)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(180, 47)
        Me.cmdSearch.TabIndex = 35
        Me.cmdSearch.Text = "&Tìm kiếm(F3)"
        Me.cmdSearch.ToolTipText = "Tìm kiếm thông tin bệnh nhân hoặc nhấn phím tắt F3"
        '
        'Barcode2
        '
        Me.Barcode2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Barcode2.BackColor = System.Drawing.Color.White
        Me.Barcode2.BarColor = System.Drawing.Color.Black
        Me.Barcode2.BarRatio = 2.0!
        Me.Barcode2.Data = "20070530010002"
        Me.Barcode2.DataExtension = Nothing
        Me.Barcode2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Barcode2.Location = New System.Drawing.Point(8, 80)
        Me.Barcode2.Name = "Barcode2"
        Me.Barcode2.Size = New System.Drawing.Size(174, 74)
        Me.Barcode2.Symbology = Mabry.Windows.Forms.Barcode.Barcode.BarcodeSymbologies.Code128
        Me.Barcode2.TabIndex = 29
        Me.Barcode2.Text = "Barcode2"
        Me.Barcode2.Visible = False
        '
        'Barcode1
        '
        Me.Barcode1.BackColor = System.Drawing.Color.White
        Me.Barcode1.BarColor = System.Drawing.Color.Black
        Me.Barcode1.BarRatio = 2.0!
        Me.Barcode1.Data = "0000000000"
        Me.Barcode1.DataExtension = Nothing
        Me.Barcode1.Location = New System.Drawing.Point(8, 71)
        Me.Barcode1.Name = "Barcode1"
        Me.Barcode1.Size = New System.Drawing.Size(140, 82)
        Me.Barcode1.Symbology = Mabry.Windows.Forms.Barcode.Barcode.BarcodeSymbologies.Code128
        Me.Barcode1.TabIndex = 34
        Me.Barcode1.Text = "Barcode1"
        Me.Barcode1.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txtBarcode)
        Me.GroupBox4.Controls.Add(Me.txtName)
        Me.GroupBox4.Controls.Add(Me.txtPID)
        Me.GroupBox4.Controls.Add(Me.txtAge)
        Me.GroupBox4.Controls.Add(Me.cboSex)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox4.Location = New System.Drawing.Point(429, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(371, 160)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Thông Tin Bệnh Nhân"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.Location = New System.Drawing.Point(6, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 21)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Họ tên"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.Location = New System.Drawing.Point(6, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Tuổi"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.Location = New System.Drawing.Point(6, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 23)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "PID"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.Location = New System.Drawing.Point(6, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 19)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Barcode:"
        '
        'txtBarcode
        '
        Me.txtBarcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBarcode.Location = New System.Drawing.Point(81, 121)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(284, 22)
        Me.txtBarcode.TabIndex = 5
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(81, 25)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(284, 22)
        Me.txtName.TabIndex = 0
        '
        'txtPID
        '
        Me.txtPID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPID.Location = New System.Drawing.Point(81, 89)
        Me.txtPID.Name = "txtPID"
        Me.txtPID.Size = New System.Drawing.Size(284, 22)
        Me.txtPID.TabIndex = 4
        '
        'txtAge
        '
        Me.txtAge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAge.Location = New System.Drawing.Point(81, 57)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(95, 22)
        Me.txtAge.TabIndex = 1
        '
        'cboSex
        '
        Me.cboSex.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSex.Location = New System.Drawing.Point(262, 56)
        Me.cboSex.Name = "cboSex"
        Me.cboSex.Size = New System.Drawing.Size(103, 24)
        Me.cboSex.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(182, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 19)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Giới tính:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.clbTestType)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(200, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(229, 116)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Loại Xét Nghiệm"
        '
        'clbTestType
        '
        Me.clbTestType.ContextMenuStrip = Me.cmsTestTypeList
        Me.clbTestType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbTestType.FormattingEnabled = True
        Me.clbTestType.Location = New System.Drawing.Point(3, 18)
        Me.clbTestType.Name = "clbTestType"
        Me.clbTestType.Size = New System.Drawing.Size(223, 95)
        Me.clbTestType.TabIndex = 0
        '
        'cmsTestTypeList
        '
        Me.cmsTestTypeList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChọnTấtCảToolStripMenuItem, Me.HủyChọnToolStripMenuItem})
        Me.cmsTestTypeList.Name = "cmsTestTypeList"
        Me.cmsTestTypeList.Size = New System.Drawing.Size(136, 48)
        '
        'ChọnTấtCảToolStripMenuItem
        '
        Me.ChọnTấtCảToolStripMenuItem.Image = CType(resources.GetObject("ChọnTấtCảToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChọnTấtCảToolStripMenuItem.Name = "ChọnTấtCảToolStripMenuItem"
        Me.ChọnTấtCảToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ChọnTấtCảToolStripMenuItem.Text = "Chọn tất cả"
        '
        'HủyChọnToolStripMenuItem
        '
        Me.HủyChọnToolStripMenuItem.Image = CType(resources.GetObject("HủyChọnToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HủyChọnToolStripMenuItem.Name = "HủyChọnToolStripMenuItem"
        Me.HủyChọnToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.HủyChọnToolStripMenuItem.Text = "Hủy Chọn"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.SplitContainerResult)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(518, 259)
        Me.GroupBox8.TabIndex = 32
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Kết quả xét nghiệm"
        '
        'SplitContainerResult
        '
        Me.SplitContainerResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerResult.Location = New System.Drawing.Point(3, 17)
        Me.SplitContainerResult.Name = "SplitContainerResult"
        Me.SplitContainerResult.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerResult.Panel1
        '
        Me.SplitContainerResult.Panel1.Controls.Add(Me.grdTestInfo)
        '
        'SplitContainerResult.Panel2
        '
        Me.SplitContainerResult.Panel2.Controls.Add(Me.grdResultDetail)
        Me.SplitContainerResult.Size = New System.Drawing.Size(512, 239)
        Me.SplitContainerResult.SplitterDistance = 76
        Me.SplitContainerResult.TabIndex = 0
        '
        'grdTestInfo
        '
        Me.grdTestInfo.ColumnAutoResize = True
        Me.grdTestInfo.ContextMenuStrip = Me.cmsTestIdList
        grdTestInfo_DesignTimeLayout.LayoutString = resources.GetString("grdTestInfo_DesignTimeLayout.LayoutString")
        Me.grdTestInfo.DesignTimeLayout = grdTestInfo_DesignTimeLayout
        Me.grdTestInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTestInfo.FocusCellFormatStyle.BackColor = System.Drawing.SystemColors.Control
        Me.grdTestInfo.FocusCellFormatStyle.BackColorGradient = System.Drawing.SystemColors.Control
        Me.grdTestInfo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTestInfo.FrozenColumns = 2
        Me.grdTestInfo.GroupByBoxVisible = False
        Me.grdTestInfo.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdTestInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdTestInfo.Name = "grdTestInfo"
        Me.grdTestInfo.Size = New System.Drawing.Size(512, 76)
        Me.grdTestInfo.TabIndex = 0
        '
        'cmsTestIdList
        '
        Me.cmsTestIdList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.cmsTestIdList.Name = "cmsTestTypeList"
        Me.cmsTestIdList.Size = New System.Drawing.Size(136, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(135, 22)
        Me.ToolStripMenuItem1.Text = "Chọn tất cả"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(135, 22)
        Me.ToolStripMenuItem2.Text = "Hủy Chọn"
        '
        'grdResultDetail
        '
        Me.grdResultDetail.AutomaticSort = False
        Me.grdResultDetail.BuiltInTextsData = "<LocalizableData ID=""LocalizableStrings"" Collection=""true""><RecordNavigator>Số lư" & _
    "ợng:| Of</RecordNavigator></LocalizableData>"
        Me.grdResultDetail.ContextMenuStrip = Me.cmsResultDetail
        grdResultDetail_DesignTimeLayout.LayoutString = resources.GetString("grdResultDetail_DesignTimeLayout.LayoutString")
        Me.grdResultDetail.DesignTimeLayout = grdResultDetail_DesignTimeLayout
        Me.grdResultDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdResultDetail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grdResultDetail.GroupByBoxVisible = False
        Me.grdResultDetail.Location = New System.Drawing.Point(0, 0)
        Me.grdResultDetail.Name = "grdResultDetail"
        Me.grdResultDetail.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Blue
        Me.grdResultDetail.Office2007CustomColor = System.Drawing.SystemColors.Highlight
        Me.grdResultDetail.RecordNavigator = True
        Me.grdResultDetail.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition
        Me.grdResultDetail.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdResultDetail.Size = New System.Drawing.Size(512, 159)
        Me.grdResultDetail.TabIndex = 1
        Me.grdResultDetail.TotalRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grdResultDetail.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        '
        'cmsResultDetail
        '
        Me.cmsResultDetail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsResultDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAddDetail, Me.tsmManualAddDetail, Me.tsmDelDetail})
        Me.cmsResultDetail.Name = "cms"
        Me.cmsResultDetail.Size = New System.Drawing.Size(261, 70)
        '
        'tsmAddDetail
        '
        Me.tsmAddDetail.Image = CType(resources.GetObject("tsmAddDetail.Image"), System.Drawing.Image)
        Me.tsmAddDetail.Name = "tsmAddDetail"
        Me.tsmAddDetail.ShortcutKeyDisplayString = "Ctrl+K"
        Me.tsmAddDetail.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.K), System.Windows.Forms.Keys)
        Me.tsmAddDetail.Size = New System.Drawing.Size(260, 22)
        Me.tsmAddDetail.Text = "Thêm thông số chuẩn"
        '
        'tsmManualAddDetail
        '
        Me.tsmManualAddDetail.Image = CType(resources.GetObject("tsmManualAddDetail.Image"), System.Drawing.Image)
        Me.tsmManualAddDetail.Name = "tsmManualAddDetail"
        Me.tsmManualAddDetail.ShortcutKeyDisplayString = "Ctrl+M"
        Me.tsmManualAddDetail.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.tsmManualAddDetail.Size = New System.Drawing.Size(260, 22)
        Me.tsmManualAddDetail.Text = "Thêm thông số mới"
        '
        'tsmDelDetail
        '
        Me.tsmDelDetail.Image = CType(resources.GetObject("tsmDelDetail.Image"), System.Drawing.Image)
        Me.tsmDelDetail.Name = "tsmDelDetail"
        Me.tsmDelDetail.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.tsmDelDetail.Size = New System.Drawing.Size(260, 22)
        Me.tsmDelDetail.Text = "Xóa KQ"
        '
        'cmdXoaCheck
        '
        Me.cmdXoaCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdXoaCheck.Enabled = False
        Me.cmdXoaCheck.Image = CType(resources.GetObject("cmdXoaCheck.Image"), System.Drawing.Image)
        Me.cmdXoaCheck.Location = New System.Drawing.Point(879, 24)
        Me.cmdXoaCheck.Name = "cmdXoaCheck"
        Me.cmdXoaCheck.Size = New System.Drawing.Size(118, 27)
        Me.cmdXoaCheck.TabIndex = 0
        Me.cmdXoaCheck.Text = "Xóa kết quả"
        Me.cmdXoaCheck.ToolTipText = "Xóa thông tin kết quả trên lưới (Bạn phải chọn một bản ghi thực hiện xóa)"
        '
        'btnExpandPanel
        '
        Me.btnExpandPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnExpandPanel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpandPanel.Location = New System.Drawing.Point(0, 39)
        Me.btnExpandPanel.Name = "btnExpandPanel"
        Me.btnExpandPanel.Size = New System.Drawing.Size(1000, 30)
        Me.btnExpandPanel.TabIndex = 1
        Me.btnExpandPanel.Tag = "Thông Tin Tìm Kiếm"
        Me.btnExpandPanel.Text = "Thông Tin Tìm Kiếm"
        Me.btnExpandPanel.ToolTipText = "Ctrl+E"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 69)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grbDateSelector)
        Me.SplitContainer1.Panel1.Controls.Add(Me.UiGroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox5)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainerMain)
        Me.SplitContainer1.Panel2.Controls.Add(Me.UiGroupBox3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1000, 479)
        Me.SplitContainer1.SplitterDistance = 160
        Me.SplitContainer1.TabIndex = 35
        '
        'grbDateSelector
        '
        Me.grbDateSelector.Controls.Add(Me.btnLinkUnlink)
        Me.grbDateSelector.Controls.Add(Me.dtpTestDateTo)
        Me.grbDateSelector.Controls.Add(Me.dtpTestDateFrom)
        Me.grbDateSelector.Controls.Add(Me.Label8)
        Me.grbDateSelector.Controls.Add(Me.cboDate)
        Me.grbDateSelector.Controls.Add(Me.Label1)
        Me.grbDateSelector.Dock = System.Windows.Forms.DockStyle.Left
        Me.grbDateSelector.Location = New System.Drawing.Point(0, 0)
        Me.grbDateSelector.Name = "grbDateSelector"
        Me.grbDateSelector.Size = New System.Drawing.Size(200, 116)
        Me.grbDateSelector.TabIndex = 2
        Me.grbDateSelector.TabStop = False
        Me.grbDateSelector.Text = "Ngày"
        '
        'btnLinkUnlink
        '
        Me.btnLinkUnlink.ImageIndex = 0
        Me.btnLinkUnlink.ImageList = Me.LinkUnlinkImageList
        Me.btnLinkUnlink.Location = New System.Drawing.Point(6, 68)
        Me.btnLinkUnlink.Name = "btnLinkUnlink"
        Me.btnLinkUnlink.Size = New System.Drawing.Size(26, 23)
        Me.btnLinkUnlink.TabIndex = 49
        Me.btnLinkUnlink.UseVisualStyleBackColor = True
        '
        'LinkUnlinkImageList
        '
        Me.LinkUnlinkImageList.ImageStream = CType(resources.GetObject("LinkUnlinkImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.LinkUnlinkImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.LinkUnlinkImageList.Images.SetKeyName(0, "Unlink-button.jpg")
        Me.LinkUnlinkImageList.Images.SetKeyName(1, "Link-button.jpg")
        '
        'dtpTestDateTo
        '
        Me.dtpTestDateTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpTestDateTo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom
        '
        '
        '
        Me.dtpTestDateTo.DropDownCalendar.Name = ""
        Me.dtpTestDateTo.Location = New System.Drawing.Point(62, 89)
        Me.dtpTestDateTo.Name = "dtpTestDateTo"
        Me.dtpTestDateTo.ShowUpDown = True
        Me.dtpTestDateTo.Size = New System.Drawing.Size(132, 22)
        Me.dtpTestDateTo.TabIndex = 34
        '
        'dtpTestDateFrom
        '
        Me.dtpTestDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpTestDateFrom.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom
        '
        '
        '
        Me.dtpTestDateFrom.DropDownCalendar.Name = ""
        Me.dtpTestDateFrom.Location = New System.Drawing.Point(62, 51)
        Me.dtpTestDateFrom.Name = "dtpTestDateFrom"
        Me.dtpTestDateFrom.ShowUpDown = True
        Me.dtpTestDateFrom.Size = New System.Drawing.Size(132, 22)
        Me.dtpTestDateFrom.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(6, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 20)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "&Đến"
        '
        'cboDate
        '
        Me.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDate.Location = New System.Drawing.Point(7, 20)
        Me.cboDate.Name = "cboDate"
        Me.cboDate.Size = New System.Drawing.Size(187, 24)
        Me.cboDate.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(6, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "&Từ "
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Warningmesage)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 116)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(429, 44)
        Me.UiGroupBox1.TabIndex = 36
        '
        'Warningmesage
        '
        Me.Warningmesage.BackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Warningmesage.CloseButtonVisible = False
        Me.Warningmesage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Warningmesage.Image = CType(resources.GetObject("Warningmesage.Image"), System.Drawing.Image)
        Me.Warningmesage.Location = New System.Drawing.Point(3, 8)
        Me.Warningmesage.Name = "Warningmesage"
        Me.Warningmesage.OptionsButtonVisible = False
        Me.Warningmesage.Size = New System.Drawing.Size(423, 33)
        Me.Warningmesage.TabIndex = 0
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.GroupBox7)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.Controls.Add(Me.GroupBox8)
        Me.SplitContainerMain.Size = New System.Drawing.Size(1000, 259)
        Me.SplitContainerMain.SplitterDistance = 478
        Me.SplitContainerMain.TabIndex = 36
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.grdPatients)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(478, 259)
        Me.GroupBox7.TabIndex = 35
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Danh sách bệnh nhân"
        '
        'grdPatients
        '
        Me.grdPatients.AllowDrop = True
        Me.grdPatients.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdPatients.BuiltInTextsData = "<LocalizableData ID=""LocalizableStrings"" Collection=""true""><RecordNavigator>Số lư" & _
    "ợng: | Of</RecordNavigator><FilterRowInfoText>Lọc thông tin bệnh nhân</FilterRow" & _
    "InfoText></LocalizableData>"
        Me.grdPatients.ContextMenuStrip = Me.cmsPatients
        grdPatients_DesignTimeLayout.LayoutString = resources.GetString("grdPatients_DesignTimeLayout.LayoutString")
        Me.grdPatients.DesignTimeLayout = grdPatients_DesignTimeLayout
        Me.grdPatients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPatients.DynamicFiltering = True
        Me.grdPatients.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdPatients.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.grdPatients.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grdPatients.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges
        Me.grdPatients.FocusCellFormatStyle.BackColor = System.Drawing.SystemColors.Highlight
        Me.grdPatients.FocusCellFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight
        Me.grdPatients.FocusCellFormatStyle.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdPatients.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grdPatients.GroupByBoxVisible = False
        Me.grdPatients.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdPatients.Location = New System.Drawing.Point(3, 17)
        Me.grdPatients.Name = "grdPatients"
        Me.grdPatients.RecordNavigator = True
        Me.grdPatients.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition
        Me.grdPatients.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPatients.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPatients.Size = New System.Drawing.Size(472, 239)
        Me.grdPatients.TabIndex = 0
        '
        'cmsPatients
        '
        Me.cmsPatients.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmRefresh})
        Me.cmsPatients.Name = "cmsPatients"
        Me.cmsPatients.Size = New System.Drawing.Size(226, 26)
        '
        'tsmRefresh
        '
        Me.tsmRefresh.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsmRefresh.Image = CType(resources.GetObject("tsmRefresh.Image"), System.Drawing.Image)
        Me.tsmRefresh.Name = "tsmRefresh"
        Me.tsmRefresh.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.tsmRefresh.Size = New System.Drawing.Size(225, 22)
        Me.tsmRefresh.Text = "Lấy lại thông tin"
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.cmdXoaCheck)
        Me.UiGroupBox3.Controls.Add(Me.ProgressBar1)
        Me.UiGroupBox3.Controls.Add(Me.chkHasResult)
        Me.UiGroupBox3.Controls.Add(Me.cmdInHangLoat)
        Me.UiGroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox3.Location = New System.Drawing.Point(0, 259)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(1000, 56)
        Me.UiGroupBox3.TabIndex = 33
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 8)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(994, 15)
        Me.ProgressBar1.TabIndex = 4
        Me.ProgressBar1.Visible = False
        '
        'chkHasResult
        '
        Me.chkHasResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHasResult.ForeColor = System.Drawing.Color.Red
        Me.chkHasResult.Location = New System.Drawing.Point(160, 24)
        Me.chkHasResult.Name = "chkHasResult"
        Me.chkHasResult.Size = New System.Drawing.Size(141, 23)
        Me.chkHasResult.TabIndex = 3
        Me.chkHasResult.Text = "&Bệnh nhân có KQ"
        '
        'cmdInHangLoat
        '
        Me.cmdInHangLoat.Image = CType(resources.GetObject("cmdInHangLoat.Image"), System.Drawing.Image)
        Me.cmdInHangLoat.Location = New System.Drawing.Point(3, 24)
        Me.cmdInHangLoat.Name = "cmdInHangLoat"
        Me.cmdInHangLoat.Size = New System.Drawing.Size(152, 28)
        Me.cmdInHangLoat.TabIndex = 1
        Me.cmdInHangLoat.Text = "&In kết quả"
        Me.cmdInHangLoat.ToolTipText = "In kết quả của bệnh nhân hàng loạt, chọn những bệnh nhân đã có kết quả thực hiện " & _
    "in phiếu xét nghiệm"
        '
        'frmTestDetail_V2_New
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 548)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btnExpandPanel)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmTestDetail_V2_New"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CẬP NHẬT TRA CỨU KẾT QUẢ XÉT NGHIỆM"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.cmsTestTypeList.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.SplitContainerResult.Panel1.ResumeLayout(False)
        Me.SplitContainerResult.Panel2.ResumeLayout(False)
        Me.SplitContainerResult.ResumeLayout(False)
        CType(Me.grdTestInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsTestIdList.ResumeLayout(False)
        CType(Me.grdResultDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsResultDetail.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.grbDateSelector.ResumeLayout(False)
        Me.grbDateSelector.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        Me.SplitContainerMain.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.grdPatients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPatients.ResumeLayout(False)
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Barcode2 As Mabry.Windows.Forms.Barcode.Barcode
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtPID As System.Windows.Forms.TextBox
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents cboSex As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddPatient As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnParaEntry As System.Windows.Forms.ToolStripButton
    Friend WithEvents clbTestType As System.Windows.Forms.CheckedListBox
    Friend WithEvents grdTestInfo As Janus.Windows.GridEX.GridEX
    Friend WithEvents WarningBoxTimer As System.Windows.Forms.Timer
    Private WithEvents Warningmesage As DevComponents.DotNetBar.Controls.WarningBox
    Friend WithEvents Barcode1 As Mabry.Windows.Forms.Barcode.Barcode
    Friend WithEvents cmd_InPhieu_XetNghiem_TongHop As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents cmsResultDetail As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmAddDetail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmManualAddDetail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDelDetail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExpandPanel As Janus.Windows.EditControls.UIButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grbDateSelector As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboDate As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmsPatients As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRegData As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmd_InPhieu_XetNghiem As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents cmdXoaCheck As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents grdPatients As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmdInHangLoat As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkHasResult As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ProgressBar1 As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents cmdSearch As Janus.Windows.EditControls.UIButton
    Friend WithEvents dtpTestDateTo As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents dtpTestDateFrom As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cmsTestTypeList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChọnTấtCảToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HủyChọnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents grdResultDetail As Janus.Windows.GridEX.GridEX
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerResult As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdEscape As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkUnlinkImageList As System.Windows.Forms.ImageList
    Friend WithEvents btnLinkUnlink As System.Windows.Forms.Button
    Friend WithEvents cmsTestIdList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
End Class