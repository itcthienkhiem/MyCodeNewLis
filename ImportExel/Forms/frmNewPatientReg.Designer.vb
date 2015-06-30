<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewPatientReg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewPatientReg))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox
        Me.txtPatient_ID = New Janus.Windows.GridEX.EditControls.EditBox
        Me.grpBirth = New Janus.Windows.EditControls.UIGroupBox
        Me.chkIsBirth = New Janus.Windows.EditControls.UICheckBox
        Me.pBirth = New System.Windows.Forms.Panel
        Me.txtAge = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtYearOfBirth = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.dtpDOB = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.chkDOB = New Janus.Windows.EditControls.UICheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtmDate = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cboLot = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboHosStatus = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblBHYT = New System.Windows.Forms.Label
        Me.txtInsuranceNum = New Janus.Windows.GridEX.EditControls.EditBox
        Me.cboObject = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtRoom = New Janus.Windows.GridEX.EditControls.EditBox
        Me.cboDepartment = New System.Windows.Forms.ComboBox
        Me.cboSex = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtBed = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDiagnostic = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblKhoa = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAddress = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtCMT = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPName = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPID = New Janus.Windows.GridEX.EditControls.EditBox
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.btnSaveAndReg = New Janus.Windows.EditControls.UIButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkCloseAfterInsert = New Janus.Windows.EditControls.UICheckBox
        Me.btnExit = New Janus.Windows.EditControls.UIButton
        Me.btnSave = New Janus.Windows.EditControls.UIButton
        Me.Panel1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.grpBirth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBirth.SuspendLayout()
        Me.pBirth.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UiGroupBox2)
        Me.Panel1.Controls.Add(Me.UiGroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(548, 533)
        Me.Panel1.TabIndex = 0
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtPatient_ID)
        Me.UiGroupBox2.Controls.Add(Me.grpBirth)
        Me.UiGroupBox2.Controls.Add(Me.dtmDate)
        Me.UiGroupBox2.Controls.Add(Me.cboLot)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.cboHosStatus)
        Me.UiGroupBox2.Controls.Add(Me.Label15)
        Me.UiGroupBox2.Controls.Add(Me.lblBHYT)
        Me.UiGroupBox2.Controls.Add(Me.txtInsuranceNum)
        Me.UiGroupBox2.Controls.Add(Me.cboObject)
        Me.UiGroupBox2.Controls.Add(Me.Label12)
        Me.UiGroupBox2.Controls.Add(Me.txtRoom)
        Me.UiGroupBox2.Controls.Add(Me.cboDepartment)
        Me.UiGroupBox2.Controls.Add(Me.cboSex)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Controls.Add(Me.txtBed)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.txtDiagnostic)
        Me.UiGroupBox2.Controls.Add(Me.lblKhoa)
        Me.UiGroupBox2.Controls.Add(Me.Label6)
        Me.UiGroupBox2.Controls.Add(Me.txtAddress)
        Me.UiGroupBox2.Controls.Add(Me.Label13)
        Me.UiGroupBox2.Controls.Add(Me.txtCMT)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.txtPName)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.txtPID)
        Me.UiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox2.Image = CType(resources.GetObject("UiGroupBox2.Image"), System.Drawing.Image)
        Me.UiGroupBox2.ImageSize = New System.Drawing.Size(24, 24)
        Me.UiGroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(548, 436)
        Me.UiGroupBox2.TabIndex = 0
        Me.UiGroupBox2.Text = "&Thông tin bệnh nhân"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtPatient_ID
        '
        Me.txtPatient_ID.Location = New System.Drawing.Point(207, 47)
        Me.txtPatient_ID.Name = "txtPatient_ID"
        Me.txtPatient_ID.Size = New System.Drawing.Size(55, 22)
        Me.txtPatient_ID.TabIndex = 94
        Me.txtPatient_ID.Visible = False
        '
        'grpBirth
        '
        Me.grpBirth.Controls.Add(Me.chkIsBirth)
        Me.grpBirth.Controls.Add(Me.pBirth)
        Me.grpBirth.Location = New System.Drawing.Point(20, 137)
        Me.grpBirth.Name = "grpBirth"
        Me.grpBirth.Size = New System.Drawing.Size(521, 54)
        Me.grpBirth.TabIndex = 4
        '
        'chkIsBirth
        '
        Me.chkIsBirth.BackColor = System.Drawing.SystemColors.Control
        Me.chkIsBirth.Checked = True
        Me.chkIsBirth.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsBirth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsBirth.ForeColor = System.Drawing.Color.Red
        Me.chkIsBirth.Location = New System.Drawing.Point(11, -6)
        Me.chkIsBirth.Name = "chkIsBirth"
        Me.chkIsBirth.Size = New System.Drawing.Size(168, 25)
        Me.chkIsBirth.TabIndex = 0
        Me.chkIsBirth.TabStop = False
        Me.chkIsBirth.Text = "&Nhập ngày tháng năm sinh"
        Me.chkIsBirth.ToolTipText = "Nếu bạn chọn thì sẽ có nhập được ngày tháng năm sinh hoặc năm sinh"
        '
        'pBirth
        '
        Me.pBirth.Controls.Add(Me.txtAge)
        Me.pBirth.Controls.Add(Me.txtYearOfBirth)
        Me.pBirth.Controls.Add(Me.dtpDOB)
        Me.pBirth.Controls.Add(Me.chkDOB)
        Me.pBirth.Controls.Add(Me.Label17)
        Me.pBirth.Controls.Add(Me.Label16)
        Me.pBirth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pBirth.Location = New System.Drawing.Point(3, 8)
        Me.pBirth.Name = "pBirth"
        Me.pBirth.Size = New System.Drawing.Size(515, 43)
        Me.pBirth.TabIndex = 0
        '
        'txtAge
        '
        Me.txtAge.DecimalDigits = 0
        Me.txtAge.Location = New System.Drawing.Point(452, 13)
        Me.txtAge.MaxLength = 4
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(60, 22)
        Me.txtAge.TabIndex = 1
        Me.txtAge.Text = "0"
        Me.txtAge.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtAge.Value = CType(0, Short)
        Me.txtAge.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        '
        'txtYearOfBirth
        '
        Me.txtYearOfBirth.DecimalDigits = 0
        Me.txtYearOfBirth.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtYearOfBirth.Location = New System.Drawing.Point(328, 14)
        Me.txtYearOfBirth.MaxLength = 4
        Me.txtYearOfBirth.Name = "txtYearOfBirth"
        Me.txtYearOfBirth.Size = New System.Drawing.Size(64, 22)
        Me.txtYearOfBirth.TabIndex = 0
        Me.txtYearOfBirth.Text = "0"
        Me.txtYearOfBirth.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtYearOfBirth.Value = CType(0, Short)
        Me.txtYearOfBirth.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        '
        'dtpDOB
        '
        Me.dtpDOB.CustomFormat = "dd/MM/yyyy"
        Me.dtpDOB.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom
        '
        '
        '
        Me.dtpDOB.DropDownCalendar.Name = ""
        Me.dtpDOB.Location = New System.Drawing.Point(107, 13)
        Me.dtpDOB.Name = "dtpDOB"
        Me.dtpDOB.Nullable = True
        Me.dtpDOB.ShowUpDown = True
        Me.dtpDOB.Size = New System.Drawing.Size(130, 22)
        Me.dtpDOB.TabIndex = 0
        Me.dtpDOB.TabStop = False
        '
        'chkDOB
        '
        Me.chkDOB.Location = New System.Drawing.Point(10, 12)
        Me.chkDOB.Name = "chkDOB"
        Me.chkDOB.Size = New System.Drawing.Size(82, 23)
        Me.chkDOB.TabIndex = 110
        Me.chkDOB.TabStop = False
        Me.chkDOB.Text = "Ngày sinh"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(411, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 16)
        Me.Label17.TabIndex = 109
        Me.Label17.Text = "&Tuổi"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(255, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 16)
        Me.Label16.TabIndex = 108
        Me.Label16.Text = "Năm sinh"
        '
        'dtmDate
        '
        Me.dtmDate.CustomFormat = "dd/MM/yyyy"
        Me.dtmDate.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom
        '
        '
        '
        Me.dtmDate.DropDownCalendar.Name = ""
        Me.dtmDate.Location = New System.Drawing.Point(132, 19)
        Me.dtmDate.Name = "dtmDate"
        Me.dtmDate.ShowUpDown = True
        Me.dtmDate.Size = New System.Drawing.Size(130, 22)
        Me.dtmDate.TabIndex = 14
        Me.dtmDate.TabStop = False
        '
        'cboLot
        '
        Me.cboLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLot.FormattingEnabled = True
        Me.cboLot.Location = New System.Drawing.Point(132, 406)
        Me.cboLot.Name = "cboLot"
        Me.cboLot.Size = New System.Drawing.Size(409, 24)
        Me.cboLot.TabIndex = 14
        Me.cboLot.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(74, 410)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 16)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "&Số lô"
        '
        'cboHosStatus
        '
        Me.cboHosStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHosStatus.FormattingEnabled = True
        Me.cboHosStatus.Items.AddRange(New Object() {"Ngoại Trú", "Nội Trú"})
        Me.cboHosStatus.Location = New System.Drawing.Point(403, 45)
        Me.cboHosStatus.Name = "cboHosStatus"
        Me.cboHosStatus.Size = New System.Drawing.Size(138, 24)
        Me.cboHosStatus.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(325, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 16)
        Me.Label15.TabIndex = 91
        Me.Label15.Text = "Trạng thái"
        '
        'lblBHYT
        '
        Me.lblBHYT.AutoSize = True
        Me.lblBHYT.Location = New System.Drawing.Point(274, 271)
        Me.lblBHYT.Name = "lblBHYT"
        Me.lblBHYT.Size = New System.Drawing.Size(63, 16)
        Me.lblBHYT.TabIndex = 90
        Me.lblBHYT.Text = "Số BHYT"
        '
        'txtInsuranceNum
        '
        Me.txtInsuranceNum.Location = New System.Drawing.Point(372, 268)
        Me.txtInsuranceNum.Name = "txtInsuranceNum"
        Me.txtInsuranceNum.Size = New System.Drawing.Size(169, 22)
        Me.txtInsuranceNum.TabIndex = 7
        '
        'cboObject
        '
        Me.cboObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObject.FormattingEnabled = True
        Me.cboObject.Location = New System.Drawing.Point(132, 267)
        Me.cboObject.Name = "cboObject"
        Me.cboObject.Size = New System.Drawing.Size(130, 24)
        Me.cboObject.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(38, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 16)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Ngày nhập"
        '
        'txtRoom
        '
        Me.txtRoom.Location = New System.Drawing.Point(132, 332)
        Me.txtRoom.Name = "txtRoom"
        Me.txtRoom.Size = New System.Drawing.Size(130, 22)
        Me.txtRoom.TabIndex = 9
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(132, 299)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(409, 24)
        Me.cboDepartment.TabIndex = 8
        '
        'cboSex
        '
        Me.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSex.FormattingEnabled = True
        Me.cboSex.Items.AddRange(New Object() {"Nam", "Nữ"})
        Me.cboSex.Location = New System.Drawing.Point(132, 103)
        Me.cboSex.Name = "cboSex"
        Me.cboSex.Size = New System.Drawing.Size(130, 24)
        Me.cboSex.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(349, 335)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "Giường"
        '
        'txtBed
        '
        Me.txtBed.Location = New System.Drawing.Point(411, 332)
        Me.txtBed.Name = "txtBed"
        Me.txtBed.Size = New System.Drawing.Size(130, 22)
        Me.txtBed.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(65, 335)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 16)
        Me.Label9.TabIndex = 87
        Me.Label9.Text = "Buồng"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(37, 373)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 16)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "Chẩn đoán"
        '
        'txtDiagnostic
        '
        Me.txtDiagnostic.Location = New System.Drawing.Point(132, 361)
        Me.txtDiagnostic.Multiline = True
        Me.txtDiagnostic.Name = "txtDiagnostic"
        Me.txtDiagnostic.Size = New System.Drawing.Size(409, 37)
        Me.txtDiagnostic.TabIndex = 11
        '
        'lblKhoa
        '
        Me.lblKhoa.AutoSize = True
        Me.lblKhoa.ForeColor = System.Drawing.Color.Red
        Me.lblKhoa.Location = New System.Drawing.Point(73, 303)
        Me.lblKhoa.Name = "lblKhoa"
        Me.lblKhoa.Size = New System.Drawing.Size(41, 16)
        Me.lblKhoa.TabIndex = 85
        Me.lblKhoa.Text = "Khoa"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(62, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 16)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Địa chỉ"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(132, 222)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(409, 37)
        Me.txtAddress.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(57, 199)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 16)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "Số CMT"
        '
        'txtCMT
        '
        Me.txtCMT.Location = New System.Drawing.Point(132, 196)
        Me.txtCMT.Name = "txtCMT"
        Me.txtCMT.Size = New System.Drawing.Size(130, 22)
        Me.txtCMT.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(51, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Giới tính"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(60, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Tên BN"
        '
        'txtPName
        '
        Me.txtPName.Location = New System.Drawing.Point(132, 77)
        Me.txtPName.Name = "txtPName"
        Me.txtPName.Size = New System.Drawing.Size(409, 22)
        Me.txtPName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(43, 271)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Đối tượng"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(84, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 16)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "PID "
        '
        'txtPID
        '
        Me.txtPID.Location = New System.Drawing.Point(132, 47)
        Me.txtPID.Name = "txtPID"
        Me.txtPID.Size = New System.Drawing.Size(130, 22)
        Me.txtPID.TabIndex = 0
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnSaveAndReg)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.chkCloseAfterInsert)
        Me.UiGroupBox1.Controls.Add(Me.btnExit)
        Me.UiGroupBox1.Controls.Add(Me.btnSave)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox1.Image = CType(resources.GetObject("UiGroupBox1.Image"), System.Drawing.Image)
        Me.UiGroupBox1.ImageSize = New System.Drawing.Size(24, 24)
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 436)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(548, 97)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.Text = "Chức năng"
        '
        'btnSaveAndReg
        '
        Me.btnSaveAndReg.Image = CType(resources.GetObject("btnSaveAndReg.Image"), System.Drawing.Image)
        Me.btnSaveAndReg.Location = New System.Drawing.Point(130, 52)
        Me.btnSaveAndReg.Name = "btnSaveAndReg"
        Me.btnSaveAndReg.Size = New System.Drawing.Size(192, 33)
        Me.btnSaveAndReg.TabIndex = 86
        Me.btnSaveAndReg.Text = "Ghi và đăng ký (ALT+S)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(279, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(266, 15)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "(*) Chữ màu đỏ là thông tin bắt buộc phải nhập!"
        '
        'chkCloseAfterInsert
        '
        Me.chkCloseAfterInsert.Location = New System.Drawing.Point(12, 19)
        Me.chkCloseAfterInsert.Name = "chkCloseAfterInsert"
        Me.chkCloseAfterInsert.Size = New System.Drawing.Size(187, 18)
        Me.chkCloseAfterInsert.TabIndex = 0
        Me.chkCloseAfterInsert.TabStop = False
        Me.chkCloseAfterInsert.Text = "Thoát sau khi thêm mới"
        Me.chkCloseAfterInsert.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(437, 52)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(97, 33)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Thoát (Esc)"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(328, 52)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(103, 33)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Ghi (Ctrl+S)"
        '
        'frmNewPatientReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 533)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewPatientReg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Thông tin bệnh nhân"
        Me.Panel1.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.grpBirth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBirth.ResumeLayout(False)
        Me.pBirth.ResumeLayout(False)
        Me.pBirth.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExit As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkCloseAfterInsert As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents btnSave As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cboLot As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboHosStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblBHYT As System.Windows.Forms.Label
    Friend WithEvents txtInsuranceNum As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cboObject As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtRoom As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cboDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents cboSex As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBed As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDiagnostic As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblKhoa As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCMT As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents dtmDate As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents grpBirth As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents chkIsBirth As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents pBirth As System.Windows.Forms.Panel
    Friend WithEvents txtAge As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtYearOfBirth As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents dtpDOB As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents chkDOB As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPatient_ID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSaveAndReg As Janus.Windows.EditControls.UIButton
End Class
