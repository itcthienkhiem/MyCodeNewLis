Imports System.ComponentModel
Imports DevComponents.DotNetBar.Controls
Imports System.Windows.Forms
Imports System.IO
Imports Janus.Windows.GridEX
Imports System.Xml.Serialization
Imports VietBaIT.Lablink.Model
Imports VietBaIT.CommonLibrary

Public Class FrmPatientRegistration_L1_New

#Region "Myproperties"
    Public Class MyProperties
        Private _horizontalDistance As Integer
        Private _verticaldistance As Integer
        Private _DefaultPrinterName As String
        Private _autoClickSearchButton As Boolean
        private _linkUnlinkState as Boolean
        Private _autoLoadRegList as Boolean


        <Browsable(False), [ReadOnly](False), Category("UI Config"), Description("Vị trí của vạch kẻ ngang"), DisplayName("Horizontal Distance Value")> _
        Public Property HorizontalDistance() As Integer
            Get
                Return _horizontalDistance
            End Get
            Set(ByVal value As Integer)
                _horizontalDistance = value
            End Set
        End Property

        <Browsable(False), Category("UI Config"), Description("Vị trí của vạch kẻ dọc"), DisplayName("Vertical Distance Value")> _
        Public Property Verticaldistance() As Integer
            Get
                Return _verticaldistance
            End Get
            Set(ByVal value As Integer)
                _verticaldistance = value
            End Set
        End Property

        <Browsable(True), [ReadOnly](False), Category("UI Config"), Description("Chọn tên của máy in barcode mặc định"), DisplayName("Tên máy in mặc định")> _
        Public Property BarcodePrinterNameDefault() As String
            Get
                Return _DefaultPrinterName
            End Get
            Set(ByVal value As String)
                _DefaultPrinterName = value
            End Set
        End Property

        <Browsable(True), [ReadOnly](False), Category("UI Config"), Description("Tự động tìm kiếm sau khi nạp form"), DisplayName("Tự động tìm kiếm sau khi nạp form")> _
        Public Property AutoClickSearchButton() As Boolean
            Get
                Return _autoClickSearchButton
            End Get
            Set(ByVal value As Boolean)
                _autoClickSearchButton = value
            End Set
        End Property

        <Browsable(True), [ReadOnly](False), Category("UI Config"), Description("Tự động hiển thị form đăng ký chi tiết"), DisplayName("Tự động hiển thị form đăng ký chi tiết")> _
        Public Property AutoLoadRegList() As Boolean
            Get
                Return _autoLoadRegList
            End Get
            Set(ByVal value As Boolean)
                _autoLoadRegList = value
            End Set
        End Property

        <Browsable(false), [ReadOnly](False), Category("UI Config"), Description("Tự động tìm kiếm sau khi nạp form"), DisplayName("Tự động tìm kiếm sau khi nạp form")> _
        Public Property LinkUnlinkState() As Boolean
            Get
                Return _linkUnlinkState
            End Get
            Set(ByVal value As Boolean)
                _linkUnlinkState = value
            End Set
        End Property

        Public Sub New()
            _horizontalDistance = 700
            _verticaldistance = 127
            _DefaultPrinterName = ""
            _autoClickSearchButton = True
            _linkUnlinkState = false
            _autoLoadRegList = false
        End Sub

    End Class

    ''' <summary>
    ''' Loads the properties from XML config file.
    ''' </summary>
    Private Sub LoadProperties()
        Try
            Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(MyProperties))
            ' To read the file, create a FileStream.
            Dim myFileStream As FileStream = New FileStream(String.Format("{0}{1}.xml", ModBusinessHelper.AppPath, Me.Name), FileMode.Open)
            ' Call the Deserialize method and cast to the object type.
            _myProperties = CType(mySerializer.Deserialize(myFileStream), MyProperties)
            myFileStream.Close()
        Catch ex As Exception
            _myProperties = New MyProperties()
        End Try
    End Sub

    ''' <summary>
    ''' Saves the properties to XML file.
    ''' </summary>
    Private Sub SaveProperties()
        Dim myWriter As StreamWriter = New StreamWriter(String.Format("{0}{1}.xml", ModBusinessHelper.AppPath, Me.Name))
        Try
            Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(MyProperties))
            mySerializer.Serialize(myWriter, _myProperties)
        Catch ex As Exception
        Finally
            myWriter.Flush()
            myWriter.Close()
        End Try
    End Sub

#End Region

#Region "WarningBoxStatus"

    Private Class WarningBoxStatus
        Private m_BlinkStatus As Boolean
        Private m_DisplayText As String

        Public Sub New(ByVal displayText__1 As String, ByVal blinkStatus__2 As Boolean)
            DisplayText = displayText__1
            BlinkStatus = blinkStatus__2
        End Sub

        Public Property DisplayText() As String
            Get
                Return m_DisplayText
            End Get
            Set(ByVal value As String)
                m_DisplayText = value
            End Set
        End Property

        Public Property BlinkStatus() As Boolean
            Get
                Return m_BlinkStatus
            End Get
            Set(ByVal value As Boolean)
                m_BlinkStatus = value
            End Set
        End Property

    End Class

    Private Sub SetWarningStatus(ByVal status As WarningBoxStatus)
        lablinkhelper.Utilities.SetControlProperty(Warningmesage, "Text", status.DisplayText)
        If Not status.BlinkStatus Then
            Warningmesage.ColorScheme = eWarningBoxColorScheme.[Default]
        End If
        WarningBoxTimer.Enabled = status.BlinkStatus
    End Sub

#End Region

#Region "Attributes"
    ''' <summary>
    ''' =true: Đã khởi động form xong - =false: Đang khởi động form
    ''' </summary>
    Private _formLoaded As Boolean = False

    ''' <summary>
    ''' Biến quy đinh sắp xếp khi load Data Control
    ''' 0: Sắp xếp theo Data Seq
    ''' 1: Sắp xếp theo ABC
    ''' </summary>

    Dim _myProperties As MyProperties

#End Region

#Region "Private Method"

    Private Sub FillGrpDatePicker()
        Try
            ' Thêm các tùy chọn
            cboDate.Items.Add("Hôm nay")
            cboDate.Items.Add("Hôm qua")
            cboDate.Items.Add("Tùy Chọn")

            'Set giá trị mặc định cho datetimepicker
            dtpFromDate.Value = DateTime.Now
            dtpTodate.Value = DateTime.Now

            cboDate.SelectedIndex = 2

        Catch generatedExceptionName As Exception
            Throw
        End Try
    End Sub

    Private Sub GetTestTypeAndTRegList()
        Try
            If grdPatientList.CurrentRow IsNot Nothing Then
                Dim v_PatientId As Integer = Utility.Int32Dbnull(grdPatientList.CurrentRow.Cells("Patient_ID").Value, -1)
                Dim testTypeandTReglistForPatient As DataTable = GetTestTypeandTReglistForPatient(v_PatientId, dtpFromDate.Value, dtpTodate.Value)
                grdTestInfo.DataSource = testTypeandTReglistForPatient
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadTestTypeButton()
        Dim dtTestTypeList As DataTable = GetAllTestTypeList()
        Dim idx As Integer = 0

        dtTestTypeList.Columns.Add("Short_Key")
        dtTestTypeList.Columns.Add("Device_Control")

        For Each dr As DataRow In dtTestTypeList.Rows
            idx += 1
            dr("Short_Key") = "F" & idx
            dr("Device_Control") = IIf(IsBiDirectionalTest(CInt(dr("TestType_ID"))), 1, 0)
        Next

        grdTestTypeButton.DataSource = dtTestTypeList
        dtTestTypeList.AcceptChanges()
    End Sub

    Private Sub LoadFormPatientInfo(ByVal vAction As action)
        Try
            If vAction = action.Insert Or grdPatientList.RowCount Then
                Dim oForm As New frmNewPatientReg_NEW
                oForm.m_iAction = vAction
                If vAction <> VietBaIT.CommonLibrary.action.Insert Then
                    oForm.mv_DR = DirectCast(grdPatientList.DataSource, DataTable).Rows(grdPatientList.CurrentRow.RowIndex)
                End If
                if grdPatientList.DataSource Is nothing then grdPatientList.DataSource = ModBusinessHelper.FindPatientFromDateToDate(DateTime.Now,DateTime.Now).Clone()
                oForm.mv_ParentTable = DirectCast(grdPatientList.DataSource, DataTable)
                oForm.grdList = grdPatientList
                oForm.ShowDialog()
                ModifyCommand()
            End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadFrmRegList(ByVal testId As Integer)
        Try
            Dim frm As New frmBiDataControlSelection_ListViewStyle
            frm.action = 0
            frm.txtBarcode.Text = grdTestInfo.GetValue("Barcode")
            frm.txtPatientName.Text = grdPatientList.GetValue("Patient_Name")
            frm.txtAge.Text = Utility.sDbnull(grdPatientList.GetValue("Age"))
            frm.testId = testId
            frm.ShowDialog()
            GetTestTypeAndTRegList()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub ModifyCommand()
        Try
            cmdDelelePatient.Enabled = grdPatientList.CurrentRow IsNot Nothing

            If grdTestInfo.CurrentRow IsNot Nothing Then
                cmdRegList.Enabled = IsBiDirectionalTest(grdTestInfo.GetValue("TestType_ID"))
                btnPrintBarcode.Enabled = (grdTestInfo.CurrentRow.RowType = RowType.Record)
                cmdDelete.Enabled = (grdTestInfo.CurrentRow.RowType <> RowType.GroupHeader)
            Else
                cmdDelete.Enabled = False
                cmdRegList.Enabled = False
                btnPrintBarcode.Enabled = False
            End If
            cmdInPhieuXN.Enabled = grdTestInfo.RowCount > 0

        Catch ex As Exception

        End Try


    End Sub

   

    Private Sub PrintAllPatient(ByVal DTPrint As DataTable)
        Try
            ' Dim DTPrint As New DataTable
            If DTPrint.Rows.Count <= 0 Then
                Utility.ShowMsg("Không có bản ghi tìm thấy", "thông báo")
                Return
            End If

            Dim crpt = New JCLV_crpt_PHIEU_YEUCAU_XETNGHIEM_HANGLOAT()
            ' Dim crpt = globalModule.GetCrystalReport(vReportType)

            Dim oForm As New frm_Preview("In phiếu", crpt, False)
            'Utility.ResetProgressBarJanus(ProgressBar1, grdPatients.GetCheckedRows.Length, False)
            'DTPrint.DefaultView.Sort = "Barcode ASC"
            crpt.SetDataSource(DTPrint)
            'End If
            Dim ShowSubReport, ShowMainReport As Integer
            ShowSubReport = 0
            ShowMainReport = 1
            'End If
            crpt.DataDefinition.FormulaFields.Item("Formula_1").Text = Chr(34) & Replace("                Bác sĩ điều trị                                                                                         Trưởng phòng xét nghiệm", "#$X$#", Chr(34) & "&Chr(13)&" & Chr(34)) & Chr(34)
            crpt.SetParameterValue("ShowSubReport", ShowSubReport)
            crpt.SetParameterValue("ShowMainReport", ShowMainReport)

            crpt.SetParameterValue("ParentBranchName", gv_sParentBranchName)
            crpt.SetParameterValue("DMY", sGetCurrentDay)
            crpt.SetParameterValue("BranchName", gv_sBranchName)
            crpt.SetParameterValue("Address", gv_sAddress)
            crpt.SetParameterValue("sPhone", gv_sPhone)
            Try
                crpt.SetParameterValue("ShowTitle", gv_showTitleReport)
            Catch ex As Exception

            End Try
            crpt.SetParameterValue("sCurrentDate", Utility.GetFormatDateTime(DateTime.Now, "dd/MM/yyyy"))
            oForm.crptViewer.ReportSource = crpt

            oForm.ShowDialog()
            DefaultNow(Me)
            'End If
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Form Events handler"

    Private Sub FrmPatientRegistration_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            LoadProperties()

            LoadTestTypeButton()
            FillGrpDatePicker()

            SplitContainer1.SplitterDistance = _myProperties.HorizontalDistance
            SplitContainerMain.SplitterDistance = _myProperties.Verticaldistance

        Catch ex As Exception
            MessageBox.Show("Đề nghị kiểm tra lại đường mạng", "Thông báo")
            Me.Dispose()
        Finally
            _formLoaded = True
            If _myProperties.AutoClickSearchButton then cmdSearch.PerformClick()
            btnLinkUnlink.ImageIndex = iif(_myProperties.LinkUnlinkState,0,1)
            dtpFromDate.Focus()
        End Try

    End Sub

    Private Sub grdPatientList_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdPatientList.SelectionChanged
        GetTestTypeAndTRegList()
        Barcode.Data = Utility.sDbnull(grdPatientList.GetValue("Barcode"), "")
    End Sub

    Private Sub cboDate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboDate.SelectedIndexChanged

        Try
            Dim index As Integer = cboDate.SelectedIndex
            dtpFromDate.Enabled = (index = 2)
            dtpTodate.Enabled = (index = 2)
            If index = 0 Then
                dtpFromDate.Value = DateTime.Now
                dtpTodate.Value = dtpFromDate.Value
            ElseIf index = 1 Then
                dtpFromDate.Value = DateTime.Now.AddDays(-1)
                dtpTodate.Value = dtpFromDate.Value
            Else
                dtpFromDate.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grdTestTypeButton_ColumnButtonClick(ByVal sender As Object, ByVal e As ColumnActionEventArgs) Handles grdTestTypeButton.ColumnButtonClick
        Try
            If e.Column.Key = "TestType_Name" Then
                Dim testTypeId = grdTestTypeButton.GetValue("TestType_ID")
                Dim testTypeName = grdTestTypeButton.GetValue("TestType_Name")
                AddTestForCurrentPatient(testTypeId, testTypeName)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AddTestForCurrentPatient(ByVal testTypeId As Object, ByVal testTypeName As Object)

        Dim patientId As Integer = Convert.ToInt32((grdPatientList.CurrentRow.Cells("Patient_ID")).Value)
        Dim regDate As Date = Convert.ToDateTime(grdPatientList.GetValue("DateUpdate"))
        Dim barcodeOutput As String = Utility.sDbnull(grdPatientList.GetValue("Barcode"), "")
        Dim testId As Integer = 0
        Dim message As String
        InsertTestInfoForPatient(patientId, testTypeId, regDate, barcodeOutput, testId, message)
        SetWarningStatus(New WarningBoxStatus(message, True))
        If barcodeOutput = "" Then
            barcodeOutput = GetBarcodeFromPatientAndTestTypeId(patientId, testTypeId)
        End If
        Barcode.Data = barcodeOutput

        'Nếu đăng ký thành công (Có TestID <>0) thì thêm mới
        If testId <> 0 Then
            Dim dataSource As DataTable = DirectCast(grdTestInfo.DataSource, DataTable)
            Dim dr As DataRow = dataSource.NewRow()
            dr("Barcode") = barcodeOutput
            dr("TestType_ID") = testTypeId
            dr("TestType_Name") = testTypeName
            dr("Patient_ID") = patientId
            dr("Test_ID") = testId
            dataSource.Rows.Add(dr)
            grdPatientList.CurrentRow.Cells("Barcode").Value = barcodeOutput
        End If

        if not _myProperties.AutoLoadRegList then Exit Sub
        If IsBiDirectionalTest(testTypeId) Then
            Dim tempTestId = GetTestIdFromBarcodeAndTestTypeId(barcodeOutput, testTypeId)
            If tempTestId <> -1 Then
                LoadFrmRegList(tempTestId)
            Else
                SetWarningStatus(New WarningBoxStatus("Có lỗi trong quá trình lấy thông tin Test của bệnh nhân", True))
            End If
        End If
    End Sub

    Private Sub cmdRegList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegList.Click
        Try
            If grdPatientList Is Nothing Then Exit Sub
            If Not IsBiDirectionalTest(CInt(grdTestInfo.GetValue("TestType_ID"))) Then Exit Sub
            LoadFrmRegList(grdTestInfo.GetValue("Test_ID"))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdTestInfo_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles grdTestInfo.DoubleClick
        cmdRegList.PerformClick()
    End Sub

    Private Sub grdTestInfo_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdTestInfo.SelectionChanged
        ModifyCommand()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
        Try

            If Not Utility.AcceptQuestion("Thực hiện xóa " & grdTestInfo.GetValue("TestType_Name") & _
                                          " của bệnh nhân " & grdPatientList.GetValue("Patient_Name") & " ?", _
                                          "Thông báo", True) Then
                Return
            End If

            Dim testId As Integer = grdTestInfo.GetValue("Test_ID")

            If TestInfoHasResult(testId) Then
                SetWarningStatus(New WarningBoxStatus("Xét nghiệm đã có kết quả. Không thể thực hiện xóa !", False))
                Return
            End If

            DeleteSubsonic(TTestInfo.Schema, TTestInfo.Columns.TestId, testId)
            DeleteSubsonic(TRegList.Schema, TRegList.Columns.TestId, testId)

            For Each grdRow As GridEXRow In grdTestInfo.GetDataRows
                If grdRow.RowType = RowType.Record And grdRow.Cells("Test_ID").Value = testId Then
                    grdRow.Delete()
                End If
            Next
            grdTestInfo.UpdateData()
            grdTestInfo.Refresh()

            If grdTestInfo.RowCount <= 0 Then
                grdPatientList.CurrentRow.Cells(TTestInfo.Columns.Barcode).Value = String.Empty
            End If

            SetWarningStatus(New WarningBoxStatus("Xóa thành công !", True))

        Catch ex As Exception
            MessageBox.Show("Có lỗi trong quá trình xóa !", "Thông báo")
        End Try

    End Sub

    Private Sub cmdAddPatient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddPatient.Click
        LoadFormPatientInfo(action.Insert)
    End Sub

    Private Sub cmdUpdatePatient_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cmdUpdatePatient.Click
        LoadFormPatientInfo(action.Update)
    End Sub

    Private Sub grdPatientList_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles grdPatientList.DoubleClick

        LoadFormPatientInfo(action.Update)
    End Sub

    Private Sub FrmPatientRegistration_L1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
        Handles MyBase.KeyDown
        Try
            If e.Control And e.KeyCode = Keys.F Then
                cmdSearch.PerformClick()
            End If

            If e.Control And e.KeyCode = Keys.N Then
                cmdAddPatient.PerformClick()
            End If

            If e.Control And e.KeyCode = Keys.U Then
                cmdUpdatePatient.PerformClick()
            End If

            If e.Control And e.KeyCode = Keys.X Then
                cmdDelelePatient.PerformClick()
            End If

            If e.Control And e.KeyCode = Keys.B Then
                btnPrintBarcode.PerformClick()
            End If

            Select Case e.KeyCode
                Case Keys.Delete
                    cmdDelete.PerformClick()
                Case Keys.Escape
                    Dispose()
                Case Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12
                    Dim dr() As DataRow
                    dr = DirectCast(grdTestTypeButton.DataSource, DataTable).Select(String.Format("Short_Key='{0}'", e.KeyCode.ToString()))
                    If dr.GetLength(0) > 0 Then
                        AddTestForCurrentPatient(dr(0)("TestType_ID"), dr(0)("TestType_Name"))
                    End If
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdDelelePatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelelePatient.Click
        Try
            If grdPatientList.CurrentRow IsNot Nothing And grdTestInfo.CurrentRow Is Nothing Then
                If Utility.AcceptQuestion("Thực hiện xóa thông tin bệnh nhân " & grdPatientList.GetValue(LPatientInfo.Columns.PatientName), "Thông báo", True) Then
                    If DeleteSubsonic(LPatientInfo.Schema, LPatientInfo.Columns.PatientId, grdPatientList.GetValue(LPatientInfo.Columns.PatientId)) Then
                        grdPatientList.CurrentRow.Delete()
                        'grdPatientList.UpdateData()
                        ModifyCommand()
                    End If
                End If
            Else
                MessageBox.Show("Không được xóa. Bệnh nhân đã đăng ký test", "Thông báo")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdSearch.Click

        Try
            'Xóa trắng danh sách bệnh nhân
            grdPatientList.DataSource = Nothing
            Dim dtPatientList As DataTable

            dtPatientList = ModBusinessHelper.FindPatientFromDateToDate(dtpFromDate.Value, dtpTodate.Value)
            'Nếu trả về Null => Có lỗi
            If dtPatientList Is Nothing Then
                MessageBox.Show("Có lỗi trong quá trình tìm kiếm bệnh nhân")
                Return
            Else
                'Nếu không tìm thấy dữ liệu
                If dtPatientList.Rows.Count <= 0 Then
                    SetWarningStatus(New WarningBoxStatus("Không có kết bệnh nhân nào", True))
                    dtPatientList.Clear()
                    Barcode2.Data = "0000000000"
                Else
                    SetWarningStatus(New WarningBoxStatus(String.Format("Tìm thấy <b> {0} </b> Bệnh nhân", dtPatientList.Rows.Count), False))
                End If
                grdPatientList.DataSource = dtPatientList
                grdPatientList.Focus()
                ModifyCommand()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdInPhieuXN_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdInPhieuXN.Click
        Dim frm As New frm_JCLV_InPhieuYeuCau_XETNGHIEM()
        frm.p_Patient_ID = Utility.Int32Dbnull(grdPatientList.GetValue("Patient_ID"), -1)
        frm.ShowDialog()
    End Sub

    Private Sub btnPrintBarcode_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintBarcode.ButtonClick
        Try
            If Not (grdPatientList Is Nothing) Then
                Dim bInfo As New VietBaIT.BarCode.BarcodeInfo
                bInfo.BarcodeData = grdTestInfo.GetValue("Barcode").ToString
                bInfo.PatientName = Utility.sDbnull(grdPatientList.GetValue(LPatientInfo.Columns.PatientName), "")
                bInfo.InsuranceNum = Utility.sDbnull(grdPatientList.GetValue("Insurance_Num"), "")
                Dim YearOfBirth As String
                Dim DOB As String
                YearOfBirth = Utility.sDbnull(grdPatientList.GetValue("Year_Birth"))
                If String.IsNullOrEmpty(Utility.sDbnull(grdPatientList.GetValue(LPatientInfo.Columns.Dob), "")) Then
                    DOB = YearOfBirth
                Else
                    DOB = Utility.GetFormatDateTime(Convert.ToDateTime(grdPatientList.GetValue("DOB")), "dd/MM/yyyy")
                End If
                bInfo.Dob = DOB
                bInfo.Sex = Utility.Int32Dbnull(grdPatientList.GetValue("Sex_Id"), -1)
                bInfo.DisplayData = True
                bInfo.Department = Utility.sDbnull(grdPatientList.GetValue("Department_Name"))
                bInfo.Room = Utility.sDbnull(grdPatientList.GetValue("Room"))

                Dim PrintBarcode As VietBaIT.BarCode.PrintBarcode = New VietBaIT.BarCode.PrintBarcode
                PrintBarcode.PrintBarCode(_myProperties.BarcodePrinterNameDefault, bInfo)
            End If
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình in barcode xét nghiệm:" + vbCrLf + ex.ToString(), vbOKOnly, "Thông báo")
        End Try
    End Sub

    ''' <summary>
    ''' Nếu nút LINK được nhấn thì thay đổi cả hai giá trị cùng một lúc
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub dtpFromDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTodate.ValueChanged, dtpFromDate.ValueChanged
        If Not _formLoaded Then Return
        If btnLinkUnlink.ImageIndex = 1 Then
            Dim currentDtp As DateTimePicker = DirectCast(sender, DateTimePicker)
            If currentDtp.Name = "dtpFromDate" Then
                dtpTodate.Value = dtpFromDate.Value
            Else
                dtpFromDate.Value = dtpTodate.Value
            End If
        End If
    End Sub

    ''' <summary>
    ''' Ghi lại thông tin về kích thước của Splitter
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.SplitterEventArgs" /> instance containing the event data.</param>
    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        If Not _formLoaded Then Return
        _myProperties.HorizontalDistance = SplitContainer1.SplitterDistance
    End Sub

    ''' <summary>
    ''' Hàm xử lý in barcode hàng loạt
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click, ToolStripMenuItem3.Click, ToolStripMenuItem4.Click, ToolStripMenuItem5.Click, ToolStripMenuItem6.Click
        Dim obj As Windows.Forms.ToolStripMenuItem = sender
        PrintMultiBarcode(Convert.ToInt32(obj.Text) / 2)
    End Sub

    ''' <summary>
    ''' Hàm In barcode hàng loạt
    ''' </summary>
    ''' <param name="numberOfCopies">Số bản Copy</param>
    Private Sub PrintMultiBarcode(ByVal numberOfCopies As Integer)
        Try
            Dim grdrow() As GridEXRow = grdPatientList.GetCheckedRows()
            If grdrow.Count() = 0 Then
                MsgBox("Bạn chưa chọn bệnh nhân để in hàng loạt", vbOKOnly, "Thông báo")
            Else
                For Each row As GridEXRow In grdrow
                    Dim bInfo As New VietBaIT.BarCode.BarcodeInfo
                    bInfo.BarcodeData = Utility.sDbnull(row.Cells("barcode").Value, "")
                    bInfo.PatientName = Utility.sDbnull(row.Cells(LPatientInfo.Columns.PatientName).Value, "")
                    bInfo.InsuranceNum = Utility.sDbnull(row.Cells("Insurance_Num").Value, "")
                    'Utility.sDbnull(grdPatientList.GetValue("Insurance_Num"), "")
                    Dim YearOfBirth As String
                    Dim Dob As String
                    YearOfBirth = Utility.sDbnull(row.Cells("Year_Birth").Value, "")

                    If String.IsNullOrEmpty(Utility.sDbnull(grdPatientList.GetValue(LPatientInfo.Columns.Dob), "")) Then
                        Dob = YearOfBirth
                    Else
                        Dob = Utility.GetFormatDateTime(Convert.ToDateTime(Utility.sDbnull(row.Cells("DOB").Value, "")), "dd/MM/yyyy")
                    End If
                    bInfo.Dob = Dob
                    
                    bInfo.Sex = Utility.Int32Dbnull(row.Cells("Sex_id").Value, -1)
                    bInfo.DisplayData = True
                    bInfo.NumberOfCopies = numberOfCopies
                    Dim PrintBarcode As VietBaIT.BarCode.PrintBarcode = New VietBaIT.BarCode.PrintBarcode
                    PrintBarcode.PrintBarCode(_myProperties.BarcodePrinterNameDefault, bInfo)
                Next
            End If
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình in barcode xét nghiệm:" + vbCrLf + ex.ToString(), vbOKOnly, "Thông báo")
        End Try
    End Sub

    ''' <summary>
    ''' Hàm xử xử lý nút bấm link & unlink
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub btnLinkUnlink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinkUnlink.Click
        btnLinkUnlink.ImageIndex = IIf(btnLinkUnlink.ImageIndex = 0, 1, 0)
        _myProperties.LinkUnlinkState = btnLinkUnlink.ImageIndex = 0
        dtpFromDate.Focus()
    End Sub

    ''' <summary>
    ''' Hiển thị form cấu hình riêng
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ConfigMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigMenuItem.Click
        Dim f As New FrmSetting
        f.Text = Text
        f.PropertiesObject = _myProperties
        f.ShowDialog(Me)
        SaveProperties()
    End Sub

    Private Sub cmdExit_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.ButtonClick
        Dispose(True)
    End Sub

    Private Sub FrmPatientRegistration_L1_New_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SaveProperties()
    End Sub

    Private Sub SplitContainerMain_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainerMain.SplitterMoved
        If Not _formLoaded Then Return
        _myProperties.Verticaldistance = SplitContainerMain.SplitterDistance
    End Sub

    'hàm thực hiện in hàng loạt thông tin
    Private Sub cmdInPhieuHangLoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInPhieuHangLoat.Click
        If grdPatientList.GetCheckedRows().Length <= 0 Then
            Utility.ShowMsg("Bạn phải chọn một bản ghi thực hiện việc  in hàng loạt", "Thông báo", MessageBoxIcon.Warning)
            grdPatientList.Focus()
            Return
        End If
        Dim frm As New frm_JCLV_INPHIEU_YCAU_XN_HANGLOAT()
        frm.grdPatientList = grdPatientList
        frm.ShowDialog()
    End Sub

#End Region

    

   

   
End Class