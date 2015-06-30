<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JCLV_frm_Lot_Test_Registration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JCLV_frm_Lot_Test_Registration))
        Dim grdPatientList_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdTestDetail_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grdTestType_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.prgbPatients = New Janus.Windows.EditControls.UIProgressBar
        Me.cboLot = New System.Windows.Forms.ComboBox
        Me.btnLoadPatientList = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label15 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grdPatientList = New Janus.Windows.GridEX.GridEX
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.grdTestDetail = New Janus.Windows.GridEX.GridEX
        Me.grbListTestType = New System.Windows.Forms.GroupBox
        Me.grdTestType = New Janus.Windows.GridEX.GridEX
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.cboDeleteAllOldReg = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPatientList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grdTestDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbListTestType.SuspendLayout()
        CType(Me.grdTestType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.prgbPatients)
        Me.Panel1.Controls.Add(Me.cboLot)
        Me.Panel1.Controls.Add(Me.btnLoadPatientList)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1149, 98)
        Me.Panel1.TabIndex = 6
        '
        'prgbPatients
        '
        Me.prgbPatients.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgbPatients.Location = New System.Drawing.Point(713, 67)
        Me.prgbPatients.Maximum = 0
        Me.prgbPatients.Name = "prgbPatients"
        Me.prgbPatients.ShowPercentage = True
        Me.prgbPatients.Size = New System.Drawing.Size(432, 20)
        Me.prgbPatients.TabIndex = 39
        Me.prgbPatients.Visible = False
        '
        'cboLot
        '
        Me.cboLot.FormattingEnabled = True
        Me.cboLot.Location = New System.Drawing.Point(67, 66)
        Me.cboLot.Name = "cboLot"
        Me.cboLot.Size = New System.Drawing.Size(71, 21)
        Me.cboLot.TabIndex = 38
        '
        'btnLoadPatientList
        '
        Me.btnLoadPatientList.Image = CType(resources.GetObject("btnLoadPatientList.Image"), System.Drawing.Image)
        Me.btnLoadPatientList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoadPatientList.Location = New System.Drawing.Point(144, 65)
        Me.btnLoadPatientList.Name = "btnLoadPatientList"
        Me.btnLoadPatientList.Size = New System.Drawing.Size(123, 25)
        Me.btnLoadPatientList.TabIndex = 4
        Me.btnLoadPatientList.Text = "&Lấy danh sách"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Chọn Lô:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Location = New System.Drawing.Point(4, 54)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1147, 2)
        Me.GroupBox6.TabIndex = 35
        Me.GroupBox6.TabStop = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Linen
        Me.Panel7.Controls.Add(Me.Label15)
        Me.Panel7.Controls.Add(Me.PictureBox1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1149, 55)
        Me.Panel7.TabIndex = 34
        '
        'Label15
        '
        Me.Label15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.Linen
        Me.Label15.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(79, -1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(1058, 34)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "ĐĂNG KÝ XÉT NGHIỆM CHO BỆNH NHÂN THEO LÔ"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Linen
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(18, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(61, 49)
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Location = New System.Drawing.Point(2, 93)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1147, 2)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.grdPatientList)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 105)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(413, 326)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Danh sách bệnh nhân"
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
        Me.grdPatientList.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grdPatientList.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges
        Me.grdPatientList.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdPatientList.GroupByBoxVisible = False
        Me.grdPatientList.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdPatientList.Location = New System.Drawing.Point(4, 17)
        Me.grdPatientList.Margin = New System.Windows.Forms.Padding(4)
        Me.grdPatientList.Name = "grdPatientList"
        Me.grdPatientList.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition
        Me.grdPatientList.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdPatientList.Size = New System.Drawing.Size(405, 305)
        Me.grdPatientList.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.grdTestDetail)
        Me.GroupBox4.Location = New System.Drawing.Point(652, 152)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(493, 279)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Chi tiết xét nghiệm"
        '
        'grdTestDetail
        '
        Me.grdTestDetail.ColumnAutoResize = True
        grdTestDetail_DesignTimeLayout.LayoutString = resources.GetString("grdTestDetail_DesignTimeLayout.LayoutString")
        Me.grdTestDetail.DesignTimeLayout = grdTestDetail_DesignTimeLayout
        Me.grdTestDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTestDetail.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTestDetail.GroupByBoxVisible = False
        Me.grdTestDetail.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.grdTestDetail.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdTestDetail.Location = New System.Drawing.Point(3, 16)
        Me.grdTestDetail.Name = "grdTestDetail"
        Me.grdTestDetail.Size = New System.Drawing.Size(487, 260)
        Me.grdTestDetail.TabIndex = 30
        '
        'grbListTestType
        '
        Me.grbListTestType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grbListTestType.Controls.Add(Me.grdTestType)
        Me.grbListTestType.Location = New System.Drawing.Point(424, 112)
        Me.grbListTestType.Name = "grbListTestType"
        Me.grbListTestType.Size = New System.Drawing.Size(222, 323)
        Me.grbListTestType.TabIndex = 27
        Me.grbListTestType.TabStop = False
        Me.grbListTestType.Text = "Loại xét nghiệm"
        '
        'grdTestType
        '
        Me.grdTestType.ColumnAutoResize = True
        grdTestType_DesignTimeLayout.LayoutString = resources.GetString("grdTestType_DesignTimeLayout.LayoutString")
        Me.grdTestType.DesignTimeLayout = grdTestType_DesignTimeLayout
        Me.grdTestType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTestType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTestType.GroupByBoxVisible = False
        Me.grdTestType.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.grdTestType.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdTestType.Location = New System.Drawing.Point(3, 16)
        Me.grdTestType.Name = "grdTestType"
        Me.grdTestType.Size = New System.Drawing.Size(216, 304)
        Me.grdTestType.TabIndex = 29
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(1004, 128)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(141, 25)
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Text = "&Ghi Đăng Ký"
        '
        'cboDeleteAllOldReg
        '
        Me.cboDeleteAllOldReg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDeleteAllOldReg.AutoSize = True
        Me.cboDeleteAllOldReg.Location = New System.Drawing.Point(1004, 104)
        Me.cboDeleteAllOldReg.Name = "cboDeleteAllOldReg"
        Me.cboDeleteAllOldReg.Size = New System.Drawing.Size(141, 17)
        Me.cboDeleteAllOldReg.TabIndex = 30
        Me.cboDeleteAllOldReg.Text = "Xóa hết các đăng ký cũ"
        Me.cboDeleteAllOldReg.UseVisualStyleBackColor = True
        '
        'JCLV_frm_Lot_Test_Registration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 438)
        Me.Controls.Add(Me.cboDeleteAllOldReg)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grbListTestType)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "JCLV_frm_Lot_Test_Registration"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Đăng ký XN cho bệnh nhân theo Lô"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdPatientList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.grdTestDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbListTestType.ResumeLayout(False)
        CType(Me.grdTestType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoadPatientList As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdPatientList As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents grbListTestType As System.Windows.Forms.GroupBox
    Friend WithEvents cboLot As System.Windows.Forms.ComboBox
    Friend WithEvents grdTestType As Janus.Windows.GridEX.GridEX
    Friend WithEvents grdTestDetail As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents prgbPatients As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents cboDeleteAllOldReg As System.Windows.Forms.CheckBox
End Class
