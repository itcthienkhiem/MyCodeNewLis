<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportFromExcel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImportFromExcel))
        Me.stStatus = New System.Windows.Forms.StatusStrip()
        Me.lbPath = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cboKeepOldResult = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dtpImportDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSheet = New System.Windows.Forms.ComboBox()
        Me.cmdOpen = New System.Windows.Forms.Button()
        Me.cmdUpdateToDB = New System.Windows.Forms.Button()
        Me.grdDataImported = New System.Windows.Forms.DataGridView()
        Me.cmdImport = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rdUncheckTest = New System.Windows.Forms.RadioButton()
        Me.rdChonTest = New System.Windows.Forms.RadioButton()
        Me.rddangky = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpInputDate = New System.Windows.Forms.DateTimePicker()
        Me.cboObjType = New System.Windows.Forms.ComboBox()
        Me.cmdImportList = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboUnit = New System.Windows.Forms.ComboBox()
        Me.chkUnit = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.grdTestDetail = New System.Windows.Forms.DataGridView()
        Me.clDetailCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clDeviceID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clAlias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clSequence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbSelection = New System.Windows.Forms.GroupBox()
        Me.rbReverse = New System.Windows.Forms.RadioButton()
        Me.rbCheckAll = New System.Windows.Forms.RadioButton()
        Me.grbLot = New System.Windows.Forms.GroupBox()
        Me.cboLot = New System.Windows.Forms.ComboBox()
        Me.ckLot = New System.Windows.Forms.CheckBox()
        Me.grbListTestType = New System.Windows.Forms.GroupBox()
        Me.grdTestType = New System.Windows.Forms.DataGridView()
        Me.clTypeCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clTestTypeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clTestTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbListPatient = New System.Windows.Forms.GroupBox()
        Me.grdListPatient = New System.Windows.Forms.DataGridView()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.grbExtent = New System.Windows.Forms.GroupBox()
        Me.rbUpperAll = New System.Windows.Forms.RadioButton()
        Me.ckInsible = New System.Windows.Forms.CheckBox()
        Me.rbUpperCaption = New System.Windows.Forms.RadioButton()
        Me.ckRemoveSign = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpen = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbSheet = New System.Windows.Forms.ToolStripLabel()
        Me.sheetsToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cmdImportListUpdate = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.grdListPatientUpdate = New System.Windows.Forms.DataGridView()
        Me.btnInsertUpdate = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtFileNameUpdate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSheetUpdate = New System.Windows.Forms.ComboBox()
        Me.btnOpenFileUpdate = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.stStatus.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdDataImported, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grdTestDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbSelection.SuspendLayout()
        Me.grbLot.SuspendLayout()
        Me.grbListTestType.SuspendLayout()
        CType(Me.grdTestType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbListPatient.SuspendLayout()
        CType(Me.grdListPatient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbExtent.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.grdListPatientUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'stStatus
        '
        Me.stStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbPath, Me.lbStatus, Me.ToolStripProgressBar1})
        Me.stStatus.Location = New System.Drawing.Point(0, 627)
        Me.stStatus.Name = "stStatus"
        Me.stStatus.Size = New System.Drawing.Size(1004, 22)
        Me.stStatus.TabIndex = 1
        Me.stStatus.Text = "StatusStrip1"
        '
        'lbPath
        '
        Me.lbPath.Name = "lbPath"
        Me.lbPath.Size = New System.Drawing.Size(0, 17)
        '
        'lbStatus
        '
        Me.lbStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lbStatus.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripProgressBar1.RightToLeftLayout = True
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox7)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.cmdUpdateToDB)
        Me.TabPage2.Controls.Add(Me.grdDataImported)
        Me.TabPage2.Controls.Add(Me.cmdImport)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(996, 601)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Nhập kết quả từ file Excel"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cboKeepOldResult)
        Me.GroupBox7.Location = New System.Drawing.Point(693, 6)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(227, 65)
        Me.GroupBox7.TabIndex = 21
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Tùy chọn cập nhật dữ liệu"
        '
        'cboKeepOldResult
        '
        Me.cboKeepOldResult.AutoSize = True
        Me.cboKeepOldResult.Checked = True
        Me.cboKeepOldResult.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cboKeepOldResult.Location = New System.Drawing.Point(7, 21)
        Me.cboKeepOldResult.Name = "cboKeepOldResult"
        Me.cboKeepOldResult.Size = New System.Drawing.Size(213, 17)
        Me.cboKeepOldResult.TabIndex = 0
        Me.cboKeepOldResult.Text = "Không cập nhật các test đã có kết quả"
        Me.cboKeepOldResult.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtpImportDate)
        Me.GroupBox5.Location = New System.Drawing.Point(477, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(210, 65)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Ngày Đăng Ký"
        '
        'dtpImportDate
        '
        Me.dtpImportDate.Location = New System.Drawing.Point(6, 19)
        Me.dtpImportDate.Name = "dtpImportDate"
        Me.dtpImportDate.Size = New System.Drawing.Size(197, 20)
        Me.dtpImportDate.TabIndex = 8
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtFileName)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cboSheet)
        Me.GroupBox3.Controls.Add(Me.cmdOpen)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(463, 65)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        '
        'txtFileName
        '
        Me.txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileName.Location = New System.Drawing.Point(92, 13)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(363, 20)
        Me.txtFileName.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Chọn sheet:"
        '
        'cboSheet
        '
        Me.cboSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSheet.FormattingEnabled = True
        Me.cboSheet.Location = New System.Drawing.Point(92, 38)
        Me.cboSheet.Name = "cboSheet"
        Me.cboSheet.Size = New System.Drawing.Size(121, 21)
        Me.cboSheet.TabIndex = 12
        '
        'cmdOpen
        '
        Me.cmdOpen.Image = CType(resources.GetObject("cmdOpen.Image"), System.Drawing.Image)
        Me.cmdOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOpen.Location = New System.Drawing.Point(6, 11)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(80, 23)
        Me.cmdOpen.TabIndex = 11
        Me.cmdOpen.Text = "Mở file"
        Me.cmdOpen.UseVisualStyleBackColor = True
        '
        'cmdUpdateToDB
        '
        Me.cmdUpdateToDB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateToDB.Location = New System.Drawing.Point(878, 555)
        Me.cmdUpdateToDB.Name = "cmdUpdateToDB"
        Me.cmdUpdateToDB.Size = New System.Drawing.Size(110, 23)
        Me.cmdUpdateToDB.TabIndex = 9
        Me.cmdUpdateToDB.Text = "Cập nhật kết quả"
        Me.cmdUpdateToDB.UseVisualStyleBackColor = True
        '
        'grdDataImported
        '
        Me.grdDataImported.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDataImported.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grdDataImported.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDataImported.Location = New System.Drawing.Point(6, 77)
        Me.grdDataImported.Name = "grdDataImported"
        Me.grdDataImported.Size = New System.Drawing.Size(982, 472)
        Me.grdDataImported.TabIndex = 5
        '
        'cmdImport
        '
        Me.cmdImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdImport.Location = New System.Drawing.Point(725, 555)
        Me.cmdImport.Name = "cmdImport"
        Me.cmdImport.Size = New System.Drawing.Size(147, 23)
        Me.cmdImport.TabIndex = 6
        Me.cmdImport.Text = "Nhập dữ liệu từ file Excell"
        Me.cmdImport.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1004, 627)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.rddangky)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.cboObjType)
        Me.TabPage1.Controls.Add(Me.cmdImportList)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.grbSelection)
        Me.TabPage1.Controls.Add(Me.grbLot)
        Me.TabPage1.Controls.Add(Me.grbListTestType)
        Me.TabPage1.Controls.Add(Me.grbListPatient)
        Me.TabPage1.Controls.Add(Me.btnInsert)
        Me.TabPage1.Controls.Add(Me.grbExtent)
        Me.TabPage1.Controls.Add(Me.ToolStrip1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(996, 601)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Nhập danh sách bệnh nhân từ file Excel"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.rdUncheckTest)
        Me.GroupBox6.Controls.Add(Me.rdChonTest)
        Me.GroupBox6.Location = New System.Drawing.Point(470, 40)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(194, 34)
        Me.GroupBox6.TabIndex = 34
        Me.GroupBox6.TabStop = False
        '
        'rdUncheckTest
        '
        Me.rdUncheckTest.AutoSize = True
        Me.rdUncheckTest.Location = New System.Drawing.Point(98, 11)
        Me.rdUncheckTest.Name = "rdUncheckTest"
        Me.rdUncheckTest.Size = New System.Drawing.Size(72, 17)
        Me.rdUncheckTest.TabIndex = 1
        Me.rdUncheckTest.TabStop = True
        Me.rdUncheckTest.Text = "Đảo chọn"
        Me.rdUncheckTest.UseVisualStyleBackColor = True
        '
        'rdChonTest
        '
        Me.rdChonTest.AutoSize = True
        Me.rdChonTest.Location = New System.Drawing.Point(7, 11)
        Me.rdChonTest.Name = "rdChonTest"
        Me.rdChonTest.Size = New System.Drawing.Size(65, 17)
        Me.rdChonTest.TabIndex = 0
        Me.rdChonTest.TabStop = True
        Me.rdChonTest.Text = "Chọn tất"
        Me.rdChonTest.UseVisualStyleBackColor = True
        '
        'rddangky
        '
        Me.rddangky.AutoSize = True
        Me.rddangky.Location = New System.Drawing.Point(477, 7)
        Me.rddangky.Name = "rddangky"
        Me.rddangky.Size = New System.Drawing.Size(100, 17)
        Me.rddangky.TabIndex = 33
        Me.rddangky.TabStop = True
        Me.rddangky.Text = "Check Đăng Ký"
        Me.rddangky.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpInputDate)
        Me.GroupBox1.Location = New System.Drawing.Point(531, 547)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(148, 38)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'dtpInputDate
        '
        Me.dtpInputDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpInputDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInputDate.Location = New System.Drawing.Point(28, 12)
        Me.dtpInputDate.Name = "dtpInputDate"
        Me.dtpInputDate.Size = New System.Drawing.Size(114, 20)
        Me.dtpInputDate.TabIndex = 0
        '
        'cboObjType
        '
        Me.cboObjType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObjType.FormattingEnabled = True
        Me.cboObjType.Location = New System.Drawing.Point(336, 3)
        Me.cboObjType.Name = "cboObjType"
        Me.cboObjType.Size = New System.Drawing.Size(121, 21)
        Me.cboObjType.TabIndex = 31
        '
        'cmdImportList
        '
        Me.cmdImportList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdImportList.Enabled = False
        Me.cmdImportList.Image = CType(resources.GetObject("cmdImportList.Image"), System.Drawing.Image)
        Me.cmdImportList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdImportList.Location = New System.Drawing.Point(701, 551)
        Me.cmdImportList.Name = "cmdImportList"
        Me.cmdImportList.Size = New System.Drawing.Size(149, 30)
        Me.cmdImportList.TabIndex = 30
        Me.cmdImportList.Text = "Nạp dữ liệu từ file Excel"
        Me.cmdImportList.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdImportList.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cboUnit)
        Me.GroupBox2.Controls.Add(Me.chkUnit)
        Me.GroupBox2.Location = New System.Drawing.Point(321, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(143, 36)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        '
        'cboUnit
        '
        Me.cboUnit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.FormattingEnabled = True
        Me.cboUnit.Location = New System.Drawing.Point(69, 10)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(68, 21)
        Me.cboUnit.TabIndex = 1
        Me.cboUnit.Visible = False
        '
        'chkUnit
        '
        Me.chkUnit.AutoSize = True
        Me.chkUnit.Enabled = False
        Me.chkUnit.Location = New System.Drawing.Point(6, 12)
        Me.chkUnit.Name = "chkUnit"
        Me.chkUnit.Size = New System.Drawing.Size(57, 17)
        Me.chkUnit.TabIndex = 0
        Me.chkUnit.Text = "Đơn vị"
        Me.chkUnit.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.grdTestDetail)
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.Location = New System.Drawing.Point(304, 75)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(684, 177)
        Me.GroupBox4.TabIndex = 26
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Chi tiết xét nghiệm"
        '
        'grdTestDetail
        '
        Me.grdTestDetail.AllowUserToAddRows = False
        Me.grdTestDetail.AllowUserToDeleteRows = False
        Me.grdTestDetail.AllowUserToResizeColumns = False
        Me.grdTestDetail.AllowUserToResizeRows = False
        Me.grdTestDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdTestDetail.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grdTestDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clDetailCheck, Me.clDeviceID, Me.clAlias, Me.clData, Me.clLevel, Me.clUnit, Me.clSequence})
        Me.grdTestDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTestDetail.Enabled = False
        Me.grdTestDetail.Location = New System.Drawing.Point(3, 16)
        Me.grdTestDetail.Name = "grdTestDetail"
        Me.grdTestDetail.RowHeadersVisible = False
        Me.grdTestDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdTestDetail.Size = New System.Drawing.Size(678, 158)
        Me.grdTestDetail.TabIndex = 0
        Me.grdTestDetail.VirtualMode = True
        '
        'clDetailCheck
        '
        Me.clDetailCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clDetailCheck.DataPropertyName = "Check"
        Me.clDetailCheck.FalseValue = "False"
        Me.clDetailCheck.FillWeight = 126.9036!
        Me.clDetailCheck.HeaderText = "Chọn"
        Me.clDetailCheck.Name = "clDetailCheck"
        Me.clDetailCheck.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clDetailCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clDetailCheck.TrueValue = "True"
        Me.clDetailCheck.Width = 50
        '
        'clDeviceID
        '
        Me.clDeviceID.DataPropertyName = "Device_ID"
        Me.clDeviceID.HeaderText = "Device ID"
        Me.clDeviceID.Name = "clDeviceID"
        Me.clDeviceID.Visible = False
        '
        'clAlias
        '
        Me.clAlias.DataPropertyName = "TestData_ID"
        Me.clAlias.FillWeight = 93.27411!
        Me.clAlias.HeaderText = "Tên viết tắt"
        Me.clAlias.Name = "clAlias"
        '
        'clData
        '
        Me.clData.DataPropertyName = "Data_Name"
        Me.clData.FillWeight = 93.27411!
        Me.clData.HeaderText = "Tên XN"
        Me.clData.Name = "clData"
        '
        'clLevel
        '
        Me.clLevel.DataPropertyName = "Normal_Level"
        Me.clLevel.FillWeight = 93.27411!
        Me.clLevel.HeaderText = "Mức bình thường"
        Me.clLevel.Name = "clLevel"
        '
        'clUnit
        '
        Me.clUnit.DataPropertyName = "Measure_Unit"
        Me.clUnit.FillWeight = 93.27411!
        Me.clUnit.HeaderText = "Đơn vị đo"
        Me.clUnit.Name = "clUnit"
        '
        'clSequence
        '
        Me.clSequence.DataPropertyName = "Data_Sequence"
        Me.clSequence.HeaderText = "Sequence"
        Me.clSequence.Name = "clSequence"
        Me.clSequence.Visible = False
        '
        'grbSelection
        '
        Me.grbSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbSelection.Controls.Add(Me.rbReverse)
        Me.grbSelection.Controls.Add(Me.rbCheckAll)
        Me.grbSelection.Enabled = False
        Me.grbSelection.Location = New System.Drawing.Point(204, 513)
        Me.grbSelection.Name = "grbSelection"
        Me.grbSelection.Size = New System.Drawing.Size(194, 34)
        Me.grbSelection.TabIndex = 24
        Me.grbSelection.TabStop = False
        '
        'rbReverse
        '
        Me.rbReverse.AutoSize = True
        Me.rbReverse.Location = New System.Drawing.Point(98, 11)
        Me.rbReverse.Name = "rbReverse"
        Me.rbReverse.Size = New System.Drawing.Size(72, 17)
        Me.rbReverse.TabIndex = 1
        Me.rbReverse.TabStop = True
        Me.rbReverse.Text = "Đảo chọn"
        Me.rbReverse.UseVisualStyleBackColor = True
        '
        'rbCheckAll
        '
        Me.rbCheckAll.AutoSize = True
        Me.rbCheckAll.Location = New System.Drawing.Point(7, 11)
        Me.rbCheckAll.Name = "rbCheckAll"
        Me.rbCheckAll.Size = New System.Drawing.Size(65, 17)
        Me.rbCheckAll.TabIndex = 0
        Me.rbCheckAll.TabStop = True
        Me.rbCheckAll.Text = "Chọn tất"
        Me.rbCheckAll.UseVisualStyleBackColor = True
        '
        'grbLot
        '
        Me.grbLot.Controls.Add(Me.cboLot)
        Me.grbLot.Controls.Add(Me.ckLot)
        Me.grbLot.Enabled = False
        Me.grbLot.Location = New System.Drawing.Point(9, 38)
        Me.grbLot.Name = "grbLot"
        Me.grbLot.Size = New System.Drawing.Size(289, 36)
        Me.grbLot.TabIndex = 20
        Me.grbLot.TabStop = False
        Me.grbLot.Visible = False
        '
        'cboLot
        '
        Me.cboLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLot.FormattingEnabled = True
        Me.cboLot.Location = New System.Drawing.Point(147, 11)
        Me.cboLot.Name = "cboLot"
        Me.cboLot.Size = New System.Drawing.Size(121, 21)
        Me.cboLot.TabIndex = 14
        Me.cboLot.Visible = False
        '
        'ckLot
        '
        Me.ckLot.AutoSize = True
        Me.ckLot.Location = New System.Drawing.Point(6, 12)
        Me.ckLot.Name = "ckLot"
        Me.ckLot.Size = New System.Drawing.Size(132, 17)
        Me.ckLot.TabIndex = 13
        Me.ckLot.Text = "Cập nhật vào lô đã có"
        Me.ckLot.UseVisualStyleBackColor = True
        '
        'grbListTestType
        '
        Me.grbListTestType.Controls.Add(Me.grdTestType)
        Me.grbListTestType.Enabled = False
        Me.grbListTestType.Location = New System.Drawing.Point(6, 75)
        Me.grbListTestType.Name = "grbListTestType"
        Me.grbListTestType.Size = New System.Drawing.Size(295, 177)
        Me.grbListTestType.TabIndex = 22
        Me.grbListTestType.TabStop = False
        Me.grbListTestType.Text = "Loại xét nghiệm"
        '
        'grdTestType
        '
        Me.grdTestType.AllowUserToAddRows = False
        Me.grdTestType.AllowUserToDeleteRows = False
        Me.grdTestType.AllowUserToResizeColumns = False
        Me.grdTestType.AllowUserToResizeRows = False
        Me.grdTestType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdTestType.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.grdTestType.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clTypeCheck, Me.clTestTypeName, Me.clTestTypeID})
        Me.grdTestType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTestType.Enabled = False
        Me.grdTestType.Location = New System.Drawing.Point(3, 16)
        Me.grdTestType.MultiSelect = False
        Me.grdTestType.Name = "grdTestType"
        Me.grdTestType.RowHeadersVisible = False
        Me.grdTestType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdTestType.Size = New System.Drawing.Size(289, 158)
        Me.grdTestType.TabIndex = 0
        '
        'clTypeCheck
        '
        Me.clTypeCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clTypeCheck.DataPropertyName = "Check"
        Me.clTypeCheck.FalseValue = "False"
        Me.clTypeCheck.HeaderText = "Chọn"
        Me.clTypeCheck.MinimumWidth = 50
        Me.clTypeCheck.Name = "clTypeCheck"
        Me.clTypeCheck.TrueValue = "True"
        Me.clTypeCheck.Width = 50
        '
        'clTestTypeName
        '
        Me.clTestTypeName.DataPropertyName = "TestType_Name"
        Me.clTestTypeName.HeaderText = "Loại xét nghiệm"
        Me.clTestTypeName.Name = "clTestTypeName"
        Me.clTestTypeName.ReadOnly = True
        '
        'clTestTypeID
        '
        Me.clTestTypeID.DataPropertyName = "TestType_ID"
        Me.clTestTypeID.HeaderText = "ID"
        Me.clTestTypeID.Name = "clTestTypeID"
        Me.clTestTypeID.Visible = False
        '
        'grbListPatient
        '
        Me.grbListPatient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbListPatient.Controls.Add(Me.grdListPatient)
        Me.grbListPatient.Location = New System.Drawing.Point(6, 258)
        Me.grbListPatient.Name = "grbListPatient"
        Me.grbListPatient.Size = New System.Drawing.Size(982, 254)
        Me.grbListPatient.TabIndex = 21
        Me.grbListPatient.TabStop = False
        Me.grbListPatient.Text = "Danh sách bệnh nhân"
        '
        'grdListPatient
        '
        Me.grdListPatient.AllowUserToAddRows = False
        Me.grdListPatient.AllowUserToDeleteRows = False
        Me.grdListPatient.AllowUserToResizeRows = False
        Me.grdListPatient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdListPatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdListPatient.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grdListPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdListPatient.Location = New System.Drawing.Point(3, 16)
        Me.grdListPatient.MultiSelect = False
        Me.grdListPatient.Name = "grdListPatient"
        Me.grdListPatient.RowHeadersVisible = False
        Me.grdListPatient.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.grdListPatient.Size = New System.Drawing.Size(976, 229)
        Me.grdListPatient.TabIndex = 4
        Me.grdListPatient.VirtualMode = True
        '
        'btnInsert
        '
        Me.btnInsert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsert.Image = CType(resources.GetObject("btnInsert.Image"), System.Drawing.Image)
        Me.btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInsert.Location = New System.Drawing.Point(856, 551)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(121, 30)
        Me.btnInsert.TabIndex = 27
        Me.btnInsert.Text = "Cập nhật dữ liệu"
        Me.btnInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'grbExtent
        '
        Me.grbExtent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbExtent.Controls.Add(Me.rbUpperAll)
        Me.grbExtent.Controls.Add(Me.ckInsible)
        Me.grbExtent.Controls.Add(Me.rbUpperCaption)
        Me.grbExtent.Controls.Add(Me.ckRemoveSign)
        Me.grbExtent.Enabled = False
        Me.grbExtent.Location = New System.Drawing.Point(404, 513)
        Me.grbExtent.Name = "grbExtent"
        Me.grbExtent.Size = New System.Drawing.Size(584, 34)
        Me.grbExtent.TabIndex = 25
        Me.grbExtent.TabStop = False
        '
        'rbUpperAll
        '
        Me.rbUpperAll.AutoSize = True
        Me.rbUpperAll.Location = New System.Drawing.Point(470, 10)
        Me.rbUpperAll.Name = "rbUpperAll"
        Me.rbUpperAll.Size = New System.Drawing.Size(103, 17)
        Me.rbUpperAll.TabIndex = 15
        Me.rbUpperAll.Text = "Viết hoa toàn bộ"
        Me.rbUpperAll.UseVisualStyleBackColor = True
        '
        'ckInsible
        '
        Me.ckInsible.AutoSize = True
        Me.ckInsible.Location = New System.Drawing.Point(22, 11)
        Me.ckInsible.Name = "ckInsible"
        Me.ckInsible.Size = New System.Drawing.Size(197, 17)
        Me.ckInsible.TabIndex = 12
        Me.ckInsible.Text = "Tự động ẩn bệnh nhân đã cập nhật"
        Me.ckInsible.UseVisualStyleBackColor = True
        '
        'rbUpperCaption
        '
        Me.rbUpperCaption.AutoSize = True
        Me.rbUpperCaption.Checked = True
        Me.rbUpperCaption.Location = New System.Drawing.Point(366, 10)
        Me.rbUpperCaption.Name = "rbUpperCaption"
        Me.rbUpperCaption.Size = New System.Drawing.Size(98, 17)
        Me.rbUpperCaption.TabIndex = 14
        Me.rbUpperCaption.TabStop = True
        Me.rbUpperCaption.Text = "Viết hoa đầu từ"
        Me.rbUpperCaption.UseVisualStyleBackColor = True
        '
        'ckRemoveSign
        '
        Me.ckRemoveSign.AutoSize = True
        Me.ckRemoveSign.Location = New System.Drawing.Point(252, 11)
        Me.ckRemoveSign.Name = "ckRemoveSign"
        Me.ckRemoveSign.Size = New System.Drawing.Size(103, 17)
        Me.ckRemoveSign.TabIndex = 11
        Me.ckRemoveSign.Text = "Tự động bỏ dấu"
        Me.ckRemoveSign.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpen, Me.ToolStripSeparator1, Me.lbSheet, Me.sheetsToolStripComboBox, Me.ToolStripSeparator2, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(990, 25)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpen
        '
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(62, 22)
        Me.btnOpen.Text = "Mở file"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lbSheet
        '
        Me.lbSheet.Name = "lbSheet"
        Me.lbSheet.Size = New System.Drawing.Size(44, 22)
        Me.lbSheet.Text = "Sheet:"
        '
        'sheetsToolStripComboBox
        '
        Me.sheetsToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sheetsToolStripComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.sheetsToolStripComboBox.Name = "sheetsToolStripComboBox"
        Me.sheetsToolStripComboBox.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripLabel1.Text = "Loại đối tượng:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cmdImportListUpdate)
        Me.TabPage3.Controls.Add(Me.GroupBox9)
        Me.TabPage3.Controls.Add(Me.btnInsertUpdate)
        Me.TabPage3.Controls.Add(Me.GroupBox8)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(996, 601)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cập nhật thông tin bệnh nhân"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cmdImportListUpdate
        '
        Me.cmdImportListUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdImportListUpdate.Location = New System.Drawing.Point(706, 565)
        Me.cmdImportListUpdate.Name = "cmdImportListUpdate"
        Me.cmdImportListUpdate.Size = New System.Drawing.Size(147, 30)
        Me.cmdImportListUpdate.TabIndex = 33
        Me.cmdImportListUpdate.Text = "&Nhập dữ liệu từ file Excel"
        Me.cmdImportListUpdate.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox9.Controls.Add(Me.grdListPatientUpdate)
        Me.GroupBox9.Location = New System.Drawing.Point(8, 53)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(982, 481)
        Me.GroupBox9.TabIndex = 31
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Danh sách bệnh nhân"
        '
        'grdListPatientUpdate
        '
        Me.grdListPatientUpdate.AllowUserToAddRows = False
        Me.grdListPatientUpdate.AllowUserToDeleteRows = False
        Me.grdListPatientUpdate.AllowUserToResizeRows = False
        Me.grdListPatientUpdate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdListPatientUpdate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdListPatientUpdate.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grdListPatientUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdListPatientUpdate.Location = New System.Drawing.Point(3, 16)
        Me.grdListPatientUpdate.MultiSelect = False
        Me.grdListPatientUpdate.Name = "grdListPatientUpdate"
        Me.grdListPatientUpdate.RowHeadersVisible = False
        Me.grdListPatientUpdate.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.grdListPatientUpdate.Size = New System.Drawing.Size(976, 456)
        Me.grdListPatientUpdate.TabIndex = 4
        Me.grdListPatientUpdate.VirtualMode = True
        '
        'btnInsertUpdate
        '
        Me.btnInsertUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertUpdate.Location = New System.Drawing.Point(874, 565)
        Me.btnInsertUpdate.Name = "btnInsertUpdate"
        Me.btnInsertUpdate.Size = New System.Drawing.Size(117, 30)
        Me.btnInsertUpdate.TabIndex = 32
        Me.btnInsertUpdate.Text = "&Cập nhật dữ liệu"
        Me.btnInsertUpdate.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.txtFileNameUpdate)
        Me.GroupBox8.Controls.Add(Me.Label3)
        Me.GroupBox8.Controls.Add(Me.cboSheetUpdate)
        Me.GroupBox8.Controls.Add(Me.btnOpenFileUpdate)
        Me.GroupBox8.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(980, 44)
        Me.GroupBox8.TabIndex = 20
        Me.GroupBox8.TabStop = False
        '
        'txtFileNameUpdate
        '
        Me.txtFileNameUpdate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileNameUpdate.Location = New System.Drawing.Point(92, 13)
        Me.txtFileNameUpdate.Name = "txtFileNameUpdate"
        Me.txtFileNameUpdate.Size = New System.Drawing.Size(438, 20)
        Me.txtFileNameUpdate.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(536, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Chọn sheet:"
        '
        'cboSheetUpdate
        '
        Me.cboSheetUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSheetUpdate.FormattingEnabled = True
        Me.cboSheetUpdate.Location = New System.Drawing.Point(606, 11)
        Me.cboSheetUpdate.Name = "cboSheetUpdate"
        Me.cboSheetUpdate.Size = New System.Drawing.Size(121, 21)
        Me.cboSheetUpdate.TabIndex = 12
        '
        'btnOpenFileUpdate
        '
        Me.btnOpenFileUpdate.Image = CType(resources.GetObject("btnOpenFileUpdate.Image"), System.Drawing.Image)
        Me.btnOpenFileUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOpenFileUpdate.Location = New System.Drawing.Point(6, 11)
        Me.btnOpenFileUpdate.Name = "btnOpenFileUpdate"
        Me.btnOpenFileUpdate.Size = New System.Drawing.Size(80, 23)
        Me.btnOpenFileUpdate.TabIndex = 11
        Me.btnOpenFileUpdate.Text = "Mở file"
        Me.btnOpenFileUpdate.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 607)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1004, 20)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 107
        Me.ProgressBar1.Visible = False
        '
        'FrmImportFromExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 649)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.stStatus)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmImportFromExcel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Đồng bộ dữ liệu từ file Excel"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.stStatus.ResumeLayout(False)
        Me.stStatus.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdDataImported, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.grdTestDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbSelection.ResumeLayout(False)
        Me.grbSelection.PerformLayout()
        Me.grbLot.ResumeLayout(False)
        Me.grbLot.PerformLayout()
        Me.grbListTestType.ResumeLayout(False)
        CType(Me.grdTestType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbListPatient.ResumeLayout(False)
        CType(Me.grdListPatient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbExtent.ResumeLayout(False)
        Me.grbExtent.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        CType(Me.grdListPatientUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lbPath As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSheet As System.Windows.Forms.ComboBox
    Friend WithEvents cmdUpdateToDB As System.Windows.Forms.Button
    Friend WithEvents dtpImportDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdDataImported As System.Windows.Forms.DataGridView
    Friend WithEvents cmdImport As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents grdTestDetail As System.Windows.Forms.DataGridView
    Friend WithEvents grbSelection As System.Windows.Forms.GroupBox
    Friend WithEvents grbLot As System.Windows.Forms.GroupBox
    Friend WithEvents cboLot As System.Windows.Forms.ComboBox
    Friend WithEvents ckLot As System.Windows.Forms.CheckBox
    Friend WithEvents grbListTestType As System.Windows.Forms.GroupBox
    Friend WithEvents grdTestType As System.Windows.Forms.DataGridView
    Friend WithEvents clTypeCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clTestTypeName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clTestTypeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grbListPatient As System.Windows.Forms.GroupBox
    Friend WithEvents grdListPatient As System.Windows.Forms.DataGridView
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents grbExtent As System.Windows.Forms.GroupBox
    Friend WithEvents rbUpperAll As System.Windows.Forms.RadioButton
    Friend WithEvents ckInsible As System.Windows.Forms.CheckBox
    Friend WithEvents rbUpperCaption As System.Windows.Forms.RadioButton
    Friend WithEvents ckRemoveSign As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbSheet As System.Windows.Forms.ToolStripLabel
    Friend WithEvents sheetsToolStripComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboUnit As System.Windows.Forms.ComboBox
    Friend WithEvents chkUnit As System.Windows.Forms.CheckBox
    Friend WithEvents cmdImportList As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents cmdOpen As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbReverse As System.Windows.Forms.RadioButton
    Friend WithEvents rbCheckAll As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboObjType As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cboKeepOldResult As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFileNameUpdate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSheetUpdate As System.Windows.Forms.ComboBox
    Friend WithEvents btnOpenFileUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdImportListUpdate As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents grdListPatientUpdate As System.Windows.Forms.DataGridView
    Friend WithEvents btnInsertUpdate As System.Windows.Forms.Button
    Friend WithEvents clDetailCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clDeviceID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clAlias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clData As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clSequence As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpInputDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents rddangky As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents rdUncheckTest As System.Windows.Forms.RadioButton
    Friend WithEvents rdChonTest As System.Windows.Forms.RadioButton
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
