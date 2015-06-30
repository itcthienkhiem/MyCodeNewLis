<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrmPatientRegistration_L1_New
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPatientRegistration_L1_New))
        Dim grdTestTypeButton_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim grdTestInfo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim grdPatientList_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdAddPatient = New System.Windows.Forms.ToolStripButton()
        Me.cmdUpdatePatient = New System.Windows.Forms.ToolStripButton()
        Me.cmdRegList = New System.Windows.Forms.ToolStripButton()
        Me.btnPrintBarcode = New System.Windows.Forms.ToolStripSplitButton()
        Me.InBarcodeHàngLoạtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdDelete = New System.Windows.Forms.ToolStripButton()
        Me.cmdDelelePatient = New System.Windows.Forms.ToolStripButton()
        Me.cmdExit = New System.Windows.Forms.ToolStripSplitButton()
        Me.ConfigMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WarningBoxTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LinkUnlinkImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grdTestTypeButton = New Janus.Windows.GridEX.GridEX()
        Me.cmdInPhieuHangLoat = New Janus.Windows.EditControls.UIButton()
        Me.cmdInPhieuXN = New Janus.Windows.EditControls.UIButton()
        Me.grdTestInfo = New Janus.Windows.GridEX.GridEX()
        Me.Barcode = New Mabry.Windows.Forms.Barcode.Barcode()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New Janus.Windows.EditControls.UIProgressBar()
        Me.btnLinkUnlink = New System.Windows.Forms.Button()
        Me.cmdSearch = New Janus.Windows.EditControls.UIButton()
        Me.Warningmesage = New DevComponents.DotNetBar.Controls.WarningBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboDate = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpTodate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grdPatientList = New Janus.Windows.GridEX.GridEX()
        Me.Barcode2 = New Mabry.Windows.Forms.Barcode.Barcode()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdTestTypeButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTestInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdPatientList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdAddPatient, Me.cmdUpdatePatient, Me.cmdRegList, Me.btnPrintBarcode, Me.cmdDelete, Me.cmdDelelePatient, Me.cmdExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1074, 39)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdAddPatient
        '
        Me.cmdAddPatient.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddPatient.Image = CType(resources.GetObject("cmdAddPatient.Image"), System.Drawing.Image)
        Me.cmdAddPatient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdAddPatient.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddPatient.Name = "cmdAddPatient"
        Me.cmdAddPatient.Size = New System.Drawing.Size(140, 36)
        Me.cmdAddPatient.Text = "Thêm BN (Ctrl+N)"
        '
        'cmdUpdatePatient
        '
        Me.cmdUpdatePatient.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdatePatient.Image = CType(resources.GetObject("cmdUpdatePatient.Image"), System.Drawing.Image)
        Me.cmdUpdatePatient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdUpdatePatient.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdUpdatePatient.Name = "cmdUpdatePatient"
        Me.cmdUpdatePatient.Size = New System.Drawing.Size(158, 36)
        Me.cmdUpdatePatient.Text = "Cập nhật BN (Ctrl+U)"
        '
        'cmdRegList
        '
        Me.cmdRegList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRegList.Image = CType(resources.GetObject("cmdRegList.Image"), System.Drawing.Image)
        Me.cmdRegList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdRegList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRegList.Name = "cmdRegList"
        Me.cmdRegList.Size = New System.Drawing.Size(130, 36)
        Me.cmdRegList.Text = "Đăng ký chi tiết"
        '
        'btnPrintBarcode
        '
        Me.btnPrintBarcode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InBarcodeHàngLoạtToolStripMenuItem})
        Me.btnPrintBarcode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintBarcode.Image = CType(resources.GetObject("btnPrintBarcode.Image"), System.Drawing.Image)
        Me.btnPrintBarcode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPrintBarcode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrintBarcode.Name = "btnPrintBarcode"
        Me.btnPrintBarcode.Size = New System.Drawing.Size(176, 36)
        Me.btnPrintBarcode.Text = "In Barcode (Ctrl+B)"
        '
        'InBarcodeHàngLoạtToolStripMenuItem
        '
        Me.InBarcodeHàngLoạtToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6})
        Me.InBarcodeHàngLoạtToolStripMenuItem.Name = "InBarcodeHàngLoạtToolStripMenuItem"
        Me.InBarcodeHàngLoạtToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.InBarcodeHàngLoạtToolStripMenuItem.Text = "In barcode hàng loạt"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripMenuItem2.Text = "2"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripMenuItem3.Text = "4"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripMenuItem4.Text = "6"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripMenuItem5.Text = "8"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripMenuItem6.Text = "10"
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Image = CType(resources.GetObject("cmdDelete.Image"), System.Drawing.Image)
        Me.cmdDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(113, 36)
        Me.cmdDelete.Text = "Xóa XN (Del)"
        '
        'cmdDelelePatient
        '
        Me.cmdDelelePatient.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelelePatient.Image = CType(resources.GetObject("cmdDelelePatient.Image"), System.Drawing.Image)
        Me.cmdDelelePatient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdDelelePatient.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDelelePatient.Name = "cmdDelelePatient"
        Me.cmdDelelePatient.Size = New System.Drawing.Size(130, 36)
        Me.cmdDelelePatient.Text = "Xóa BN (Ctrl+X)"
        '
        'cmdExit
        '
        Me.cmdExit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigMenuItem})
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(119, 36)
        Me.cmdExit.Text = "Thoát (Esc)"
        '
        'ConfigMenuItem
        '
        Me.ConfigMenuItem.Image = CType(resources.GetObject("ConfigMenuItem.Image"), System.Drawing.Image)
        Me.ConfigMenuItem.Name = "ConfigMenuItem"
        Me.ConfigMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ConfigMenuItem.Text = "Cấu Hình"
        '
        'LinkUnlinkImageList
        '
        Me.LinkUnlinkImageList.ImageStream = CType(resources.GetObject("LinkUnlinkImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.LinkUnlinkImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.LinkUnlinkImageList.Images.SetKeyName(0, "Unlink-button.jpg")
        Me.LinkUnlinkImageList.Images.SetKeyName(1, "Link-button.jpg")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(4, 19)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdTestTypeButton)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdInPhieuHangLoat)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdInPhieuXN)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdTestInfo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Barcode)
        Me.SplitContainer1.Size = New System.Drawing.Size(292, 435)
        Me.SplitContainer1.SplitterDistance = 127
        Me.SplitContainer1.TabIndex = 0
        '
        'grdTestTypeButton
        '
        Me.grdTestTypeButton.ColumnAutoResize = True
        grdTestTypeButton_DesignTimeLayout.LayoutString = resources.GetString("grdTestTypeButton_DesignTimeLayout.LayoutString")
        Me.grdTestTypeButton.DesignTimeLayout = grdTestTypeButton_DesignTimeLayout
        Me.grdTestTypeButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTestTypeButton.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdTestTypeButton.GroupByBoxVisible = False
        Me.grdTestTypeButton.Location = New System.Drawing.Point(0, 0)
        Me.grdTestTypeButton.Name = "grdTestTypeButton"
        Me.grdTestTypeButton.Size = New System.Drawing.Size(292, 127)
        Me.grdTestTypeButton.TabIndex = 4
        '
        'cmdInPhieuHangLoat
        '
        Me.cmdInPhieuHangLoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdInPhieuHangLoat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInPhieuHangLoat.Image = CType(resources.GetObject("cmdInPhieuHangLoat.Image"), System.Drawing.Image)
        Me.cmdInPhieuHangLoat.Location = New System.Drawing.Point(148, 278)
        Me.cmdInPhieuHangLoat.Name = "cmdInPhieuHangLoat"
        Me.cmdInPhieuHangLoat.Size = New System.Drawing.Size(144, 26)
        Me.cmdInPhieuHangLoat.TabIndex = 6
        Me.cmdInPhieuHangLoat.Text = "&In phiếu hàng loạt"
        '
        'cmdInPhieuXN
        '
        Me.cmdInPhieuXN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdInPhieuXN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInPhieuXN.Image = CType(resources.GetObject("cmdInPhieuXN.Image"), System.Drawing.Image)
        Me.cmdInPhieuXN.Location = New System.Drawing.Point(3, 278)
        Me.cmdInPhieuXN.Name = "cmdInPhieuXN"
        Me.cmdInPhieuXN.Size = New System.Drawing.Size(144, 26)
        Me.cmdInPhieuXN.TabIndex = 0
        Me.cmdInPhieuXN.Text = "&In phiếu XN"
        '
        'grdTestInfo
        '
        Me.grdTestInfo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdTestInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdTestInfo.AutoEdit = True
        Me.grdTestInfo.AutomaticSort = False
        Me.grdTestInfo.ColumnAutoResize = True
        grdTestInfo_DesignTimeLayout.LayoutString = resources.GetString("grdTestInfo_DesignTimeLayout.LayoutString")
        Me.grdTestInfo.DesignTimeLayout = grdTestInfo_DesignTimeLayout
        Me.grdTestInfo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdTestInfo.GroupByBoxVisible = False
        Me.grdTestInfo.GroupTotalRowFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdTestInfo.GroupTotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.grdTestInfo.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdTestInfo.Location = New System.Drawing.Point(0, 4)
        Me.grdTestInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.grdTestInfo.Name = "grdTestInfo"
        Me.grdTestInfo.Size = New System.Drawing.Size(292, 275)
        Me.grdTestInfo.TabIndex = 4
        '
        'Barcode
        '
        Me.Barcode.BackColor = System.Drawing.Color.White
        Me.Barcode.BarColor = System.Drawing.Color.Black
        Me.Barcode.BarRatio = 2.0!
        Me.Barcode.Data = "0123456789"
        Me.Barcode.DataExtension = Nothing
        Me.Barcode.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Barcode.Location = New System.Drawing.Point(42, 72)
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Size = New System.Drawing.Size(222, 111)
        Me.Barcode.Symbology = Mabry.Windows.Forms.Barcode.Barcode.BarcodeSymbologies.Code128
        Me.Barcode.TabIndex = 5
        Me.Barcode.Text = "Barcode1"
        Me.Barcode.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.SplitContainer1)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(300, 458)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Thông tin xét nghiệm"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ProgressBar1)
        Me.GroupBox2.Controls.Add(Me.btnLinkUnlink)
        Me.GroupBox2.Controls.Add(Me.cmdSearch)
        Me.GroupBox2.Controls.Add(Me.Warningmesage)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboDate)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtpFromDate)
        Me.GroupBox2.Controls.Add(Me.dtpTodate)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(5, 20)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(760, 88)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(7, 70)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(746, 18)
        Me.ProgressBar1.TabIndex = 5
        Me.ProgressBar1.Visible = False
        '
        'btnLinkUnlink
        '
        Me.btnLinkUnlink.ImageIndex = 0
        Me.btnLinkUnlink.ImageList = Me.LinkUnlinkImageList
        Me.btnLinkUnlink.Location = New System.Drawing.Point(290, 15)
        Me.btnLinkUnlink.Name = "btnLinkUnlink"
        Me.btnLinkUnlink.Size = New System.Drawing.Size(26, 23)
        Me.btnLinkUnlink.TabIndex = 48
        Me.btnLinkUnlink.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch.Image = CType(resources.GetObject("cmdSearch.Image"), System.Drawing.Image)
        Me.cmdSearch.Location = New System.Drawing.Point(620, 16)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(133, 23)
        Me.cmdSearch.TabIndex = 47
        Me.cmdSearch.Text = "&Tìm kiếm(Ctrl+F)"
        '
        'Warningmesage
        '
        Me.Warningmesage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Warningmesage.BackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Warningmesage.CloseButtonVisible = False
        Me.Warningmesage.Image = CType(resources.GetObject("Warningmesage.Image"), System.Drawing.Image)
        Me.Warningmesage.Location = New System.Drawing.Point(8, 47)
        Me.Warningmesage.Name = "Warningmesage"
        Me.Warningmesage.OptionsButtonVisible = False
        Me.Warningmesage.Size = New System.Drawing.Size(745, 32)
        Me.Warningmesage.TabIndex = 46
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(317, 19)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 16)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Đến"
        '
        'cboDate
        '
        Me.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDate.Location = New System.Drawing.Point(8, 13)
        Me.cboDate.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDate.Name = "cboDate"
        Me.cboDate.Size = New System.Drawing.Size(119, 24)
        Me.cboDate.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(135, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 16)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Từ"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(168, 15)
        Me.dtpFromDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.ShowUpDown = True
        Me.dtpFromDate.Size = New System.Drawing.Size(115, 22)
        Me.dtpFromDate.TabIndex = 34
        '
        'dtpTodate
        '
        Me.dtpTodate.CustomFormat = "dd/MM/yyyy"
        Me.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTodate.Location = New System.Drawing.Point(351, 15)
        Me.dtpTodate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpTodate.Name = "dtpTodate"
        Me.dtpTodate.ShowUpDown = True
        Me.dtpTodate.Size = New System.Drawing.Size(137, 22)
        Me.dtpTodate.TabIndex = 36
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdPatientList)
        Me.GroupBox3.Controls.Add(Me.Barcode2)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(5, 108)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(760, 345)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Danh sách bệnh nhân"
        '
        'grdPatientList
        '
        Me.grdPatientList.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdPatientList.BuiltInTextsData = "<LocalizableData ID=""LocalizableStrings"" Collection=""true""><FilterRowInfoText>Lọc" & _
    " thông tin bệnh nhân</FilterRowInfoText></LocalizableData>"
        Me.grdPatientList.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        grdPatientList_DesignTimeLayout.LayoutString = resources.GetString("grdPatientList_DesignTimeLayout.LayoutString")
        Me.grdPatientList.DesignTimeLayout = grdPatientList_DesignTimeLayout
        Me.grdPatientList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPatientList.DynamicFiltering = True
        Me.grdPatientList.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdPatientList.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grdPatientList.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges
        Me.grdPatientList.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdPatientList.FrozenColumns = 3
        Me.grdPatientList.GroupByBoxVisible = False
        Me.grdPatientList.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdPatientList.Location = New System.Drawing.Point(4, 19)
        Me.grdPatientList.Margin = New System.Windows.Forms.Padding(4)
        Me.grdPatientList.Name = "grdPatientList"
        Me.grdPatientList.Size = New System.Drawing.Size(752, 322)
        Me.grdPatientList.TabIndex = 0
        '
        'Barcode2
        '
        Me.Barcode2.BackColor = System.Drawing.Color.White
        Me.Barcode2.BarColor = System.Drawing.Color.Black
        Me.Barcode2.BarRatio = 2.0!
        Me.Barcode2.Data = Nothing
        Me.Barcode2.DataExtension = Nothing
        Me.Barcode2.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Barcode2.Location = New System.Drawing.Point(242, 79)
        Me.Barcode2.Name = "Barcode2"
        Me.Barcode2.Size = New System.Drawing.Size(354, 219)
        Me.Barcode2.Symbology = Mabry.Windows.Forms.Barcode.Barcode.BarcodeSymbologies.Code128
        Me.Barcode2.TabIndex = 3
        Me.Barcode2.Text = "Barcode1"
        Me.Barcode2.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Size = New System.Drawing.Size(770, 458)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin tìm kiếm"
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.Location = New System.Drawing.Point(0, 39)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.Controls.Add(Me.GroupBox4)
        Me.SplitContainerMain.Size = New System.Drawing.Size(1074, 458)
        Me.SplitContainerMain.SplitterDistance = 770
        Me.SplitContainerMain.TabIndex = 32
        '
        'FrmPatientRegistration_L1_New
        '
        Me.AcceptButton = Me.cmdSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 497)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmPatientRegistration_L1_New"
        Me.Text = "ĐĂNG KÝ THÔNG TIN BỆNH NHÂN"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdTestTypeButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTestInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdPatientList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        Me.SplitContainerMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAddPatient As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents WarningBoxTimer As System.Windows.Forms.Timer
    Friend WithEvents cmdRegList As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdUpdatePatient As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdDelelePatient As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPrintBarcode As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents InBarcodeHàngLoạtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkUnlinkImageList As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdTestTypeButton As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdTestInfo As Janus.Windows.GridEX.GridEX
    Friend WithEvents Barcode As Mabry.Windows.Forms.Barcode.Barcode
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLinkUnlink As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As Janus.Windows.EditControls.UIButton
    Private WithEvents Warningmesage As DevComponents.DotNetBar.Controls.WarningBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboDate As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdPatientList As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdInPhieuXN As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdExit As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ConfigMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdInPhieuHangLoat As Janus.Windows.EditControls.UIButton
    Friend WithEvents ProgressBar1 As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents Barcode2 As Mabry.Windows.Forms.Barcode.Barcode
End Class