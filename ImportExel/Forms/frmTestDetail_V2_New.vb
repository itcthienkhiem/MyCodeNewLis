Imports System.ComponentModel
Imports System.IO
Imports Janus.Windows.CalendarCombo
Imports DevComponents.DotNetBar.Controls
Imports lablinkhelper
Imports SubSonic
Imports Vietbait.Lablink.Model
Imports VietBaIT.CommonLibrary
Imports Janus.Windows.GridEX
Imports System.Xml.Serialization
Imports VietBaIT.LABLink.LoadEnvironments
Imports frmPrintPreview = VietBaIT.LABLink.Reports.frmPrintPreview

Public Class frmTestDetail_V2_New

#Region "Error Handler"

    Private Event OnError (ByVal strMessage As String, ByVal ex As Exception)

    Private Sub OnErrorHanlder (ByVal strMessage As String, ByVal ex As Exception)
        MsgBox (strMessage, MsgBoxStyle.Critical And MsgBoxStyle.OkOnly, "Thông Báo")
    End Sub

#End Region

#Region "Myproperties"

    <Serializable()> _
    Public Class MyProperties
        Private _mainDisctance As Integer
        Private _testResultDistance As Integer
        Private _saveLinkUnlinkState As Boolean
        Private _linkUnlinkState As Boolean
        Private _automaticLoadRegList As Boolean
        Private _autoClickSearchButton As Boolean
        Private _allowUserEditResult As Boolean
        Private _printAllPatientsReportType As String

        <Browsable (True), [ReadOnly] (False), Category ("UI Config"), _
            Description ("Cho phép người sử dụng hiệu chỉnh kết quả \nThêm kết quả mới\nCập nhật kết quả cũ"), _
            DisplayName ("Cho phép hiệu chỉnh kết quả")> _
        Public Property AllowUserEditResult() As Boolean
            Get
                Return _allowUserEditResult
            End Get
            Set (ByVal value As Boolean)
                _allowUserEditResult = value
            End Set
        End Property

        <Browsable (True), [ReadOnly] (False), Category ("UI Config"), Description ("Tự động tìm kiếm sau khi nạp form"), _
            DisplayName ("Tự động tìm kiếm sau khi nạp form")> _
        Public Property AutoClickSearchButton() As Boolean
            Get
                Return _autoClickSearchButton
            End Get
            Set (ByVal value As Boolean)
                _autoClickSearchButton = value
            End Set
        End Property

        <Browsable (True), [ReadOnly] (False), Category ("UI Config"), Description ("Tự động nạp các XN đăng ký"), _
            DisplayName ("Tự động lấy đăng ký XN")> _
        Public Property AutomaticLoadRegList() As Boolean
            Get
                Return _automaticLoadRegList
            End Get
            Set (ByVal value As Boolean)
                _automaticLoadRegList = value
            End Set
        End Property

        <Browsable (False), [ReadOnly] (False), Category ("UI Config"), Description ("Vị trí của vạch kẻ ngang"), _
            DisplayName ("Horizontal Distance Value")> _
        Public Property LinkUnlinkState() As Boolean
            Get
                Return _linkUnlinkState
            End Get
            Set (ByVal value As Boolean)
                _linkUnlinkState = value
            End Set
        End Property

        <Browsable (False), [ReadOnly] (False), Category ("UI Config"), Description ("Vị trí của vạch kẻ ngang"), _
            DisplayName ("Horizontal Distance Value")> _
        Public Property MainDisctance() As Integer
            Get
                Return _mainDisctance
            End Get
            Set (ByVal value As Integer)
                _mainDisctance = value
            End Set
        End Property

        <Browsable (True), [ReadOnly] (False), Category ("UI Config"), Description ("Mã báo cáo in hàng loạt"), _
            DisplayName ("Mã báo cáo in hàng loạt")> _
        Public Property PrintAllPatientsReportType() As String
            Get
                Return _printAllPatientsReportType
            End Get
            Set (ByVal value As String)
                _printAllPatientsReportType = value
            End Set
        End Property

        <Browsable (False), [ReadOnly] (False), Category ("UI Config"), Description ("Vị trí của vạch kẻ dọc"), _
            DisplayName ("Vertical Distance Value")> _
        Public Property TestResultDistance() As Integer
            Get
                Return _testResultDistance
            End Get
            Set (ByVal value As Integer)
                _testResultDistance = value
            End Set
        End Property

        <Browsable (True), [ReadOnly] (False), Category ("UI Config"), _
            Description ("Lưu trạng thái của nút giữa fromDate và ToDate"), _
            DisplayName ("Lưu trạng thái của nút giữa fromDate và ToDate")> _
        Public Property SaveLinkUnlinkState() As Boolean
            Get
                Return _saveLinkUnlinkState
            End Get
            Set (ByVal value As Boolean)
                _saveLinkUnlinkState = value
            End Set
        End Property

        Public Sub New()
            _mainDisctance = 490
            _testResultDistance = 74
            _saveLinkUnlinkState = False
            _automaticLoadRegList = False
            _autoClickSearchButton = False
            _allowUserEditResult = True
            _printAllPatientsReportType = String.Empty
        End Sub
    End Class

    ''' <summary>
    ''' Loads the properties from XML config file.
    ''' </summary>
    Private Sub LoadProperties()
        Dim myFileStream As FileStream = New FileStream (String.Format ("{0}{1}.xml", AppPath, Me.Name), FileMode.Open)
        Try
            Dim mySerializer As XmlSerializer = New XmlSerializer (GetType (MyProperties))
            _myProperties = CType (mySerializer.Deserialize (myFileStream), MyProperties)
            If _myProperties Is Nothing Then _myProperties = New MyProperties()
        Catch ex As Exception
            _myProperties = New MyProperties()
        Finally
            myFileStream.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Saves the properties to XML file.
    ''' </summary>
    Private Sub SaveProperties()
        Dim myWriter As StreamWriter = New StreamWriter (String.Format ("{0}{1}.xml", AppPath, Me.Name))
        Try
            Dim mySerializer As XmlSerializer = New XmlSerializer (GetType (MyProperties))
            mySerializer.Serialize (myWriter, _myProperties)
        Catch ex As Exception
            RaiseEvent OnError ("Có lỗi trong quá trình lưu cấu hình", ex)
        Finally
            myWriter.Flush()
            myWriter.Close()
        End Try

    End Sub

#End Region

#Region "Attribute"

    Private reportType, reportType2 As Integer
    Private _rowFilter As String = "1=1"
    Private mv_DTPatientInfor As DataTable
    Private m_dtResultDetail As New DataTable()
    Private m_dtTestInfo As New DataTable()

    Private currentTestTypeId As Integer

    Dim issearching As Boolean = False

    ''' <summary>
    ''' Biến lưu cấu hình riêng của form
    ''' </summary>
    Dim _myProperties As MyProperties

    ''' <summary>
    ''' =true: Đã khởi động form xong - =false: Đang khởi động form
    ''' </summary>
    Private _formLoaded As Boolean = False

#End Region

#Region "Private Methol"

    ' Hàm load ngày
    Private Sub FillGrpDatePicker()
        Try
            ' Thêm các tùy chọn
            cboDate.Items.Add ("Hôm nay")
            cboDate.Items.Add ("Hôm qua")
            cboDate.Items.Add ("Tùy Chọn")

            'Set giá trị mặc định cho datetimepicker
            dtpTestDateFrom.Value = DateTime.Now
            dtpTestDateTo.Value = DateTime.Now

            cboDate.SelectedIndex = 2

        Catch generatedExceptionName As Exception
            Throw
        End Try
    End Sub

    'Hàm fill data vào combobox
    Private Sub FillSexCombobox()
        cboSex.DataSource = Nothing
        cboSex.Items.Clear()

        Dim dt = New DataTable()
        dt.Columns.Add ("ValueItem")
        dt.Columns.Add ("DisplayItem")

        Dim dr As DataRow = dt.NewRow()
        dr (0) = - 1
        dr (1) = ""
        dt.Rows.Add (dr)

        dr = dt.NewRow()
        dr (0) = 1
        dr (1) = "Nam"
        dt.Rows.Add (dr)

        dr = dt.NewRow()
        dr (0) = 0
        dr (1) = "Nữ"
        dt.Rows.Add (dr)

        cboSex.DataSource = dt
        cboSex.DisplayMember = "DisplayItem"
        cboSex.ValueMember = "ValueItem"

        cboSex.SelectedIndex = 0
    End Sub

    Private Sub FillTestTypeList()
        Try
            'Xóa trắng Checklistbox

            clbTestType.DataSource = Nothing
            clbTestType.Items.Clear()
            DataBinding.BindData(clbTestType, PreloadedLists.TestType, "TestType_ID", "TestType_Name")
            'clbTestType.DataSource = PreloadedLists.TestType
            SetAllCheckedBoxTrue (clbTestType)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'hàm thực hiện việc trạng thái các nút khi di chuyển trên lưới
    Private Sub ModifyCommand()
        Try
            'btnPrintQuick.Enabled = grdTestInfo.RowCount > 0
            cmd_InPhieu_XetNghiem.Enabled = grdTestInfo.RowCount > 0
            cmd_InPhieu_XetNghiem_TongHop.Enabled = grdTestInfo.RowCount > 0
            cmd_InPhieu_XetNghiem.Enabled = grdTestInfo.RowCount > 0
            grdTestInfo.Enabled = grdPatients.RowCount > 0
            grdResultDetail.Enabled = grdPatients.RowCount > 0
            'cmdXoaCheck.Enabled = (grdResultDetail.RowCount > 0) And (grdResultDetail.GetCheckedRows().Count() > 0)
        Catch ex As Exception

        End Try

    End Sub

    Private Class WarningBoxStatus
        Public Sub New (ByVal displayText__1 As String, ByVal blinkStatus__2 As Boolean)
            DisplayText = displayText__1
            BlinkStatus = blinkStatus__2
        End Sub

        Public Property DisplayText() As String
            Get
                Return m_DisplayText
            End Get
            Set (ByVal value As String)
                m_DisplayText = value
            End Set
        End Property

        Private m_DisplayText As String

        Public Property BlinkStatus() As Boolean
            Get
                Return m_BlinkStatus
            End Get
            Set (ByVal value As Boolean)
                m_BlinkStatus = value
            End Set
        End Property

        Private m_BlinkStatus As Boolean
    End Class

    Private Sub SetWarningStatus (ByVal status As WarningBoxStatus)
        lablinkhelper.Utilities.SetControlProperty(Warningmesage, "Text", status.DisplayText)
        If Not status.BlinkStatus Then
            Warningmesage.ColorScheme = eWarningBoxColorScheme.[Default]
        End If
        WarningBoxTimer.Enabled = status.BlinkStatus
    End Sub

    Private Sub SetAllCheckedBoxTrue (ByVal clb As CheckedListBox)
        Try
            Const sFileName As String = "defaultTestTypechecked.txt"
            Dim allTestTypeId() As String

            If File.Exists (sFileName) Then
                Dim tempstring As String() = File.ReadAllLines (sFileName)
                If tempstring.Length > 0 Then
                    allTestTypeId = tempstring (0).Split (",")
                End If
            Else
                File.WriteAllText (sFileName, "-1")
            End If

            If allTestTypeId.Contains ("-1") Or allTestTypeId.Count() = 0 Then
                For i As Integer = 0 To clb.Items.Count - 1
                    clb.SetItemChecked (i, True)
                Next i
            Else
                For i As Integer = 0 To PreloadedLists.TestType.Rows.Count - 1
                    If _
                        allTestTypeId.Any(Function(s) s.Trim() = PreloadedLists.TestType.Rows(i)("TestType_id").ToString().Trim()) Then
                        clb.SetItemChecked(i, True)
                    End If
                Next
            End If
        Catch ex As Exception
            For i As Integer = 0 To clb.Items.Count - 1
                clb.SetItemChecked (i, True)
            Next i
        End Try

    End Sub

    Private Function GetIdString (ByVal dt As DataTable, ByVal clb As CheckedListBox, ByVal colID As String) As String
        Try
            Dim testIdString As String = String.Empty
            For i As Integer = 0 To clb.Items.Count - 1
                If clb.GetItemChecked (i) Then
                    testIdString += dt.Rows (i) (colID).ToString + ","
                End If
            Next
            If testIdString.EndsWith (",") Then
                testIdString = testIdString.Remove (testIdString.Length - 1)
            End If
            If testIdString = String.Empty Then
                Return "-3"
            Else
                Return testIdString
            End If
        Catch generatedExceptionName As Exception
            Throw
        End Try
    End Function

    Private Sub BindTestInfo (ByVal v_PatientId As Integer, ByVal testTypeId As String)
        Dim _
            ds As DataSet = _
                SPs.SpGetTestInfoByPatientIDV2 (v_PatientId, testTypeId, dtpTestDateFrom.Value.ToString, _
                                                dtpTestDateTo.Value.ToString).GetDataSet()

        m_dtTestInfo = ds.Tables (0)
        m_dtResultDetail = ds.Tables (1)
        grdResultDetail.DataSource = m_dtResultDetail

        ProcessNormalResult (m_dtResultDetail)
        IsNormalResult (m_dtResultDetail)
        grdTestInfo.DataSource = m_dtTestInfo

    End Sub

    Private Function PrintTestResult (ByVal vPatientId As Integer, ByVal vTestTypeId As String, ByVal vTestId As String) _
        As DataTable
        Try
            Return SPs.SpGetTestResultForPrintV2 (vPatientId, vTestTypeId, vTestId).GetDataSet().Tables (0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Hàm thực hiện việc ẩn hiện thông tin của các nút in phiếu
    ''' </summary>
    Private Sub LoadReportType()
        reportType = SysPara.ReportType
        reportType2 = SysPara.ReportType2
        cmd_InPhieu_XetNghiem_TongHop.Visible = reportType >= 0
        cmd_InPhieu_XetNghiem.Visible = reportType2 >= 0
    End Sub

    Private Sub MoveToCurrentTestTypeRow()
        Try
            Dim idx As Integer = - 1
            For i As Integer = 0 To grdTestInfo.RowCount
                If grdTestInfo.GetRow (i).Cells (TTestTypeList.Columns.TestTypeId).Value = currentTestTypeId Then
                    idx = i
                    Exit For
                End If
            Next
            If idx = - 1 Then
                grdTestInfo.MoveToRowIndex (0)
            Else
                grdTestInfo.MoveToRowIndex (idx)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub IsNormalResult (ByRef dt As DataTable)
        Try
            For Each dr As DataRow In dt.Rows
                dr ("binhthuong") = IIf (dr ("Note").ToString().Trim() = "", 0, 1)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UpdateData (ByRef DT As DataTable)
        For Each dr As DataRow In DT.Rows
            dr ("Test_result") = dr ("Test_result")
            dr ("Normal_Level") = dr ("Normal_Level")
            dr ("Normal_LevelW") = dr ("Normal_LevelW")
        Next
        DT.AcceptChanges()
    End Sub

    Private Sub ProcessNormalResult(ByRef dt As DataTable)
        Try
            Dim min, max As Double
            Dim normal As String
            Const low As String = "Low"
            Const hight As String = "High"
            Const binhthuong As String = "note"
            Const testResult As String = "Test_result"
            Dim normalLevel As String = "Normal_Level"
            Dim arrResultWithLetters As New ArrayList
            arrResultWithLetters.Add("NE")
            arrResultWithLetters.Add("POS")

            Try
                If dt(0)("sSex").ToString().ToUpper() <> "NAM" Then
                    normalLevel = "Normal_LevelW"
                End If
            Catch ex As Exception
                If Not grdPatients.GetValue("SexId") Then normalLevel = "Normal_LevelW"
            End Try

            'dt.Columns.Add(binhthuong, System.Type.GetType("System.Int32"))
            If Not dt.Columns.Contains(binhthuong) Then
                dt.Columns.Add(binhthuong, GetType(String))
            End If

            'dt.Columns.Add(binhthuong, System.Type.GetType("System.Int32"))
            If Not dt.Columns.Contains("binhthuong") Then
                dt.Columns.Add("binhthuong", GetType(String))
            End If

            For Each dr As DataRow In dt.Rows

                normal = dr(normalLevel).ToString().Trim()
                If normal = "" Then Continue For
                normal = normal.Replace("≤", "<=")
                normal = normal.Replace("≥", ">=")

                While normal.IndexOf(" ") > 0
                    normal = normal.Replace(" ", "")
                End While

                While normal.IndexOf(",") > 0
                    normal = normal.Replace(",", ".")
                End While

                Try
                    Dim tempNormal As Integer = Convert.ToInt32(normal)
                    normal = String.Format("{0}-{0}", normal)
                Catch ex As Exception

                End Try

                Try
                    ''truong hop nam trong khonang co can tren va can duoi
                    Dim rawResult As Object = dr(testResult).ToString()
                    rawResult = rawResult.Replace("≤", "<=")
                    rawResult = rawResult.Replace("≥", ">=")
                    If rawResult = ">1000" Then rawResult = ">1000"
                    While rawResult.IndexOf(" ") > 0
                        rawResult = rawResult.Replace(" ", "")
                    End While
                    If _
                        String.IsNullOrEmpty(rawResult) Or String.IsNullOrEmpty(normal) Or _
                        (rawResult.ToString().Trim().ToUpper() = normal.ToUpper()) Then
                        dr(binhthuong) = ""
                        Continue For
                    ElseIf _
                        normal.ToUpper().StartsWith("NEG") Or normal.ToUpper().StartsWith("Âm") Or _
                        normal.ToUpper().StartsWith("Am") Then
                        Dim b1 As Boolean = rawResult.StartsWith("ÂM")
                        Dim b2 As Boolean = rawResult.StartsWith("AM")
                        Dim b3 As Boolean = rawResult.StartsWith("NEG")
                        If b1 Or b2 Or b3 Then
                            dr(binhthuong) = ""
                        Else
                            dr(binhthuong) = hight
                        End If
                    ElseIf _
                        normal.ToUpper().StartsWith("POS") Or normal.ToUpper().StartsWith("DƯƠ") Or _
                        normal.ToUpper().StartsWith("DUO") Then
                        Dim b1 As Boolean = rawResult.StartsWith("POS")
                        Dim b2 As Boolean = rawResult.StartsWith("DƯƠ")
                        Dim b3 As Boolean = rawResult.StartsWith("DUO")
                        If b1 Or b2 Or b3 Then
                            dr(binhthuong) = ""
                        Else
                            dr(binhthuong) = low
                        End If

                    ElseIf IsNumeric(rawResult) Then
processnumber:          dr(binhthuong) = ""
                        Dim tempResult As Double = CDbl(rawResult)

                        If normal.IndexOf("-") > 0 Then
                            Dim arrstr As String()
                            arrstr = normal.Split("-")
                            min = CDbl(arrstr(0))
                            max = CDbl(arrstr(1))
                            Dim b1 As Boolean = tempResult >= min
                            Dim b2 As Boolean = tempResult <= max
                            If Not b1 Then dr(binhthuong) = low
                            If Not b2 Then dr(binhthuong) = hight

                        ElseIf normal.IndexOf("<=") >= 0 Then
                            min = Double.MinValue
                            max = CDbl(normal.Substring(2))
                            Dim b1 As Boolean = tempResult >= min
                            Dim b2 As Boolean = tempResult <= max
                            If Not b1 Then dr(binhthuong) = low
                            If Not b2 Then dr(binhthuong) = hight
                        ElseIf normal.IndexOf(">=") >= 0 Then
                            max = Double.MaxValue
                            min = CDbl(normal.Substring(2))
                            Dim b1 As Boolean = tempResult >= min
                            Dim b2 As Boolean = tempResult <= max
                            If Not b1 Then dr(binhthuong) = low
                            If Not b2 Then dr(binhthuong) = hight
                            ''Truong hop chi co can tren
                        ElseIf normal.IndexOf("<") >= 0 Then
                            min = Double.MinValue
                            max = CDbl(normal.Substring(1))
                            Dim b1 As Boolean = tempResult > min
                            Dim b2 As Boolean = tempResult < max
                            If Not b1 Then dr(binhthuong) = low
                            If Not b2 Then dr(binhthuong) = hight
                            ''Truong hop chi co can tren
                        ElseIf normal.IndexOf(">") >= 0 Then
                            max = Double.MaxValue
                            min = CDbl(normal.Substring(1))
                            Dim b1 As Boolean = tempResult > min
                            Dim b2 As Boolean = tempResult < max
                            If Not b1 Then dr(binhthuong) = low
                            If Not b2 Then dr(binhthuong) = hight
                        End If
                    ElseIf (rawResult.ToString().IndexOf(">=") >= 0) Or (rawResult.ToString().IndexOf("<=") >= 0) Then
                        rawResult = rawResult.Replace(">=", "")
                        rawResult = rawResult.Replace("<=", "")
                        If IsNumeric(rawResult) Then GoTo processnumber
                    ElseIf (rawResult.ToString().IndexOf(">") >= 0) Or (rawResult.ToString().IndexOf("<") >= 0) Then
                        rawResult = rawResult.Replace(">", "")
                        rawResult = rawResult.Replace("<", "")
                        If IsNumeric(rawResult) Then GoTo processnumber
                    Else
                        ''Truong hop cua Negative va positive
                        ''Dim b As Boolean = (dr(testResult).ToString.Trim.ToUpper.IndexOf(arrResultWithLetters(0)) >= 0)
                        'Dim b1 As Boolean = dr(testResult).ToString.Trim.ToUpper.IndexOf("DƯƠ") >= 0
                        'Dim b2 As Boolean = dr(testResult).ToString.Trim.ToUpper.IndexOf("DUO") >= 0
                        'Dim b3 As Boolean = dr(testResult).ToString.Trim.ToUpper.IndexOf("POS") >= 0
                        'If b1 Or b2 Or b3 Then
                        '    dr(binhthuong) = hight
                        'Else
                        '    dr(binhthuong) = ""
                        'End If
                        Dim strTempResultString = rawResult.ToString.Trim.ToUpper
                        Dim b1 As Boolean = strTempResultString.StartsWith("ÂM")
                        Dim b2 As Boolean = strTempResultString.StartsWith("AM")
                        Dim b3 As Boolean = strTempResultString.StartsWith("NEG")
                        If b1 Or b2 Or b3 Then
                            dr(binhthuong) = ""
                        Else
                            dr(binhthuong) = hight
                        End If

                        If _
                            ((strTempResultString = "-") Or (strTempResultString = "±") Or (strTempResultString = "+") Or _
                             (strTempResultString = "+-")) And (strTempResultString <> normal) Then _
                            dr(binhthuong) = hight

                    End If
                Catch ex As Exception
                    dr(binhthuong) = " "
                    Continue For
                End Try
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UpdatePrintStatus(ByVal strTestId As String)
        Try
            Call _
                New Update(TResultDetail.Schema).Set(TResultDetail.Columns.ParaStatus).EqualTo(1).Where( _
                                                                                                            TResultDetail _
                                                                                                               .Columns. _
                                                                                                               TestId). _
                    In(Utility.FromStringToArrayList(strTestId)).Execute()
            ModifyPrintStatus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ModifyPrintStatus()
        Try
            Dim patientPrintStatus As Boolean = False
            For Each dr As DataRow In m_dtTestInfo.Rows
                If dr("CHON") = 1 And dr("ResultPrint_Status") = 1 Then
                    dr("ResultPrint_Status") = 2
                    patientPrintStatus = True
                End If
            Next

            m_dtTestInfo.AcceptChanges()
            If patientPrintStatus Then
                grdPatients.CurrentRow.Cells("ResultPrint_Status").Value = 2
                grdPatients.CurrentRow.Cells("Print_Status").Value = 1
                grdPatients.UpdateData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetTestDetailSource()

        Dim tempdt As DataTable
        tempdt = m_dtResultDetail.Clone()
        tempdt.Clear()
        For Each dr As DataRowView In m_dtResultDetail.DefaultView
            If Not String.IsNullOrEmpty(Utility.sDbnull(dr("Para_Name"), "")) Then tempdt.ImportRow(dr.Row)
        Next

        grdResultDetail.DataSource = tempdt
    End Sub

    Private Function UpdateResultDetail(ByVal testDetail_id As Int32, ByVal test_ID As Integer, _
                                         ByVal testtype_ID As Integer, ByVal patientId As Integer, _
                                         ByVal pv_Barcode As String, _
                                         ByVal pv_ParaName As String, ByVal pv_DataSequence As Integer, _
                                         ByVal pv_intPrint As Boolean, ByVal pv_sResult As String, _
                                         ByVal pv_sMeasureUnit As String, ByVal pv_NormalLevel As String, _
                                         ByVal pv_NormalLevelW As String) As Int32
        Try
            SPs.SpAddResultDetailV2(test_ID, patientId, grdTestInfo.GetValue("Test_Date").ToString, pv_sResult, _
                                     pv_NormalLevel, pv_ParaName, "", _
                                     pv_Barcode, testtype_ID, pv_DataSequence, pv_sMeasureUnit, pv_intPrint, _
                                     pv_NormalLevelW).Execute()
            If testDetail_id < 0 Then
                testDetail_id = _
                    Utility.Int32Dbnull( _
                                         TResultDetail.CreateQuery().WHERE(TResultDetail.Columns.TestId, test_ID).WHERE( _
                                                                                                                          TResultDetail _
                                                                                                                             . _
                                                                                                                             Columns _
                                                                                                                             . _
                                                                                                                             ParaName, _
                                                                                                                          pv_ParaName) _
                                            . _
                                            GetMax(TResultDetail.Columns.TestDetailId), -1)
            End If
            Return testDetail_id
        Catch ex As Exception
            Utility.ShowMsg(ex.Message)
            Return -1
        End Try
    End Function

    Private Sub DeleteTestDetail()
        Try
            If grdResultDetail.CurrentRow Is Nothing Then
                SetWarningStatus(New WarningBoxStatus("Xét nghiệm không có kết quả xóa !", True))
                Exit Sub
            End If

            If Utility.AcceptQuestion("Thưc hiện xóa thông số " & grdResultDetail.GetValue("Para_Name"), "", True) _
                Then
                Dim testDetail_id As Integer = Utility.Int32Dbnull(grdResultDetail.GetValue("TestDetail_ID"), -1)
                If testDetail_id > 0 Then
                    TResultDetail.Delete(testDetail_id)
                End If

                RemoveHandler grdResultDetail.CellEdited, AddressOf grdResultDetail_CellEdited
                grdResultDetail.CurrentRow.Delete()
                Dim _
                    dataRow() As DataRow = _
                        m_dtResultDetail.Select(String.Format("TestDetail_ID = {0}", testDetail_id))
                dataRow(0).Delete()
                m_dtResultDetail.AcceptChanges()
                SetTestDetailSource()
                AddHandler grdResultDetail.CellEdited, AddressOf grdResultDetail_CellEdited

                grdResultDetail.UpdateData()
                grdResultDetail.Refresh()


                ModifyStatus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ModifyStatus()
        Try
            If grdResultDetail.CurrentRow Is Nothing Then
                grdTestInfo.CurrentRow.Cells("ResultPrint_Status").Value = 0
            Else
                If grdTestInfo.CurrentRow.Cells("ResultPrint_Status").Value = 0 Then
                    grdTestInfo.CurrentRow.Cells("ResultPrint_Status").Value = 1
                End If

            End If
            grdTestInfo.UpdateData()

            Dim _
                testHasResultCount As Integer = _
                    m_dtTestInfo.Rows.Cast(Of DataRow)().Count(Function(dr) dr("ResultPrint_Status") > 0)

            If testHasResultCount = 0 Then
                grdPatients.CurrentRow.Cells("ResultPrint_Status").Value = 0
                grdPatients.CurrentRow.Cells("Print_Status").Value = 0
            Else
                If grdPatients.CurrentRow.Cells("ResultPrint_Status").Value = 0 Then
                    grdPatients.CurrentRow.Cells("ResultPrint_Status").Value = 1
                End If

            End If

            Dim strArr() As String = grdPatients.GetValue("NumberOfTest").ToString.Split("/")
            strArr(0) = testHasResultCount.ToString()
            grdPatients.CurrentRow.Cells("NumberOfTest").Value = strArr(0) + "/" + strArr(1)

            grdPatients.UpdateData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub INPHIEU_XETNGHIEM_TONGHOP(ByVal vReportType As Integer, ByVal Quick As Boolean)
        Try

            If grdPatients.CurrentRow IsNot Nothing Then
                If m_dtTestInfo.[Select]("CHON=1").GetLength(0) <= 0 Then
                    Utility.ShowMsg("Bạn phải chọn một bản ghi thực hiện in phiếu", "Thông báo")
                    grdTestInfo.Focus()
                    Return
                End If

                Dim strSelectedTestType As String
                If vReportType = 17 Then
                    strSelectedTestType = grdTestInfo.GetValue("TestType_ID").ToString()
                Else
                    strSelectedTestType = Utility.GetCheckedID(m_dtTestInfo, "CHON=1", "TestType_ID")
                End If

                Dim patientId As Integer = Utility.Int32Dbnull(grdPatients.CurrentRow.Cells("Patient_ID").Value, -1)

                grdTestInfo.UpdateData()
                Dim testId As String = Utility.GetCheckedID(m_dtTestInfo, "CHON=1", "Test_ID")


                Dim dtForPrinting As DataTable = PrintTestResult(patientId, strSelectedTestType, testId)

                If dtForPrinting.Rows.Count <= 0 Then
                    SetWarningStatus(New WarningBoxStatus("Không có kết quả để in", True))
                    Exit Sub
                End If

                If Not dtForPrinting.Columns.Contains("BarcodeImg") Then
                    dtForPrinting.Columns.Add("BarcodeImg", GetType(Byte()))
                End If

                ProcessNormalResult(dtForPrinting)

                Dim dataBarcode As Byte() = Utility.GenerateBarCode(Barcode2)
                For Each dr As DataRow In dtForPrinting.Rows
                    dr("BarcodeImg") = dataBarcode
                Next
                dtForPrinting.AcceptChanges()

                Dim crpt = GetCrystalReport(vReportType)
                ' Kiểm tra thông số kết quả bất thường thì sẽ bôi đậm trong phiếu in kq cho lão khoa
                If SysPara.IsNormalResult = 1 Then
                    IsNormalResult(dtForPrinting)
                End If
                'lablinkhelper.Utilities.UpdateLogotoDatatable(dtForPrinting)
                Utility.UpdateLogotoDatatable(dtForPrinting)
                crpt.SetDataSource(dtForPrinting)
                crpt.DataDefinition.FormulaFields.Item("Formula_1").Text = " "
                'crpt.SetDataSource(_testAllResult);
                crpt.SetParameterValue("ShowSubReport", 1)
                crpt.SetParameterValue("ShowMainReport", 0)
                crpt.SetParameterValue("ParentBranchName", gv_sParentBranchName)
                crpt.SetParameterValue("BranchName", gv_sBranchName)
                crpt.SetParameterValue("Address", gv_sAddress)
                crpt.SetParameterValue("sPhone", gv_sPhone)
                Try
                    crpt.SetParameterValue("ShowTitle", gv_showTitleReport)
                Catch ex As Exception

                End Try

                'thực hiện in phiếu xét nghiệm cho JCLV
                If vReportType = 4 Then
                    UpdateData(dtForPrinting)
                    crpt.SetParameterValue("sCurrentDate", Utility.GetFormatDateTime(DateTime.Now, "dd/MM/yyyy"))
                    crpt.SetParameterValue("DMY", sGetCurrentDay)
                End If
                If vReportType = 2 Then
                    crpt.SetParameterValue("sCurrentDate", Utility.FormatDateTime(Date.Now))
                End If

                If Not Quick Then
                    'Dim objForm As New frmPrintPreview("In kết quả xét nghiệm", crpt, True, True)
                    Dim objForm As New frmPrintPreview("In kết quả xét nghiệm", crpt, True, True)
                    objForm.crptViewer.ReportSource = crpt
                    objForm.ShowDialog()
                    objForm.Dispose()
                Else
                    'objForm.crptViewer.ReportSource = crpt;
                    crpt.PrintToPrinter(1, False, 0, 0)
                End If
                UpdatePrintStatus(testId)
            Else
                SetWarningStatus(New WarningBoxStatus("Không có bệnh nhân", True))
            End If
        Catch ex As Exception
            SetWarningStatus(New WarningBoxStatus(ex.Message, True))
        End Try
    End Sub

    'hàm thực hiện in phiếu xet nghiệm tưng cái một
    Private Sub INPHIEU_XETNGHIEM(ByVal vReportType As Integer, ByVal Quick As Boolean)
        Try

            If grdPatients.CurrentRow IsNot Nothing Then
                If m_dtTestInfo.[Select]("CHON=1").GetLength(0) <= 0 Then
                    Utility.ShowMsg("Bạn phải chọn một bản ghi thực hiện in phiếu", "Thông báo")
                    grdTestInfo.Focus()
                    Return
                End If

                Dim strSelectedTestType As String
                If vReportType = 17 Then
                    strSelectedTestType = grdTestInfo.GetValue("TestType_ID").ToString()
                Else
                    strSelectedTestType = Utility.GetCheckedID(m_dtTestInfo, "CHON=1", "TestType_ID")
                End If

                Dim patientId As Integer = Utility.Int32Dbnull(grdPatients.CurrentRow.Cells("Patient_ID").Value, -1)

                grdTestInfo.UpdateData()
                Dim testId As String = Utility.sDbnull(grdTestInfo.GetValue("Test_ID"), "-1")

                Dim dtForPrinting As DataTable = PrintTestResult(patientId, strSelectedTestType, testId)
                If dtForPrinting.Rows.Count <= 0 Then
                    SetWarningStatus(New WarningBoxStatus("Không có kết quả để in", True))
                    Exit Sub
                End If

                ProcessNormalResult(dtForPrinting)

                If Not dtForPrinting.Columns.Contains("BarcodeImg") Then
                    dtForPrinting.Columns.Add("BarcodeImg", GetType(Byte()))
                End If

                Dim dataBarcode As Byte() = Utility.GenerateBarCode(Barcode2)
                For Each dr As DataRow In dtForPrinting.Rows
                    dr("BarcodeImg") = dataBarcode
                    'Barcode2.Data = dr("Barcode")
                Next

                dtForPrinting.AcceptChanges()

                Dim crpt = GetCrystalReport(vReportType)
                ' Kiểm tra thông số kết quả bất thường thì sẽ bôi đậm trong phiếu in kq cho lão khoa
                If SysPara.IsNormalResult = 1 Then
                    IsNormalResult(dtForPrinting)
                End If

                'lablinkhelper.Utilities.UpdateLogotoDatatable(dtForPrinting)
                Utility.UpdateLogotoDatatable(dtForPrinting)
                crpt.SetDataSource(dtForPrinting)
                crpt.DataDefinition.FormulaFields.Item("Formula_1").Text = " "
                crpt.SetParameterValue("ShowSubReport", 1)
                crpt.SetParameterValue("ShowMainReport", 0)
                crpt.SetParameterValue("ParentBranchName", gv_sParentBranchName)
                crpt.SetParameterValue("BranchName", gv_sBranchName)
                crpt.SetParameterValue("Address", gv_sAddress)
                crpt.SetParameterValue("sPhone", gv_sPhone)

                Try
                    crpt.SetParameterValue("ShowTitle", gv_showTitleReport)
                Catch ex As Exception

                End Try

                Try
                    crpt.SetParameterValue("sHotPhone", gv_sHotPhone)
                Catch ex As Exception

                End Try

                'thực hiện in phiếu xét nghiệm cho JCLV
                If vReportType = 4 Then
                    UpdateData(dtForPrinting)
                    crpt.SetParameterValue("sCurrentDate", Utility.GetFormatDateTime(DateTime.Now, "dd/MM/yyyy"))
                    crpt.SetParameterValue("DMY", sGetCurrentDay)
                End If
                If vReportType = 2 Then
                    crpt.SetParameterValue("sCurrentDate", Utility.FormatDateTime(Date.Now))
                End If

                If Not Quick Then
                    'Dim objForm As New frmPrintPreview("In kết quả xét nghiệm", crpt, True, True)
                    Dim objForm As New frmPrintPreview("In kết quả xét nghiệm", crpt, True, True)

                    objForm.crptViewer.ReportSource = crpt
                    objForm.ShowDialog()
                    objForm.Dispose()
                Else
                    'objForm.crptViewer.ReportSource = crpt;
                    crpt.PrintToPrinter(1, False, 0, 0)
                End If
                'mv_DTPatientInfor.AcceptChanges()
                'Utility.DefaultNow(Me)
                UpdatePrintStatus(testId)

            Else
                SetWarningStatus(New WarningBoxStatus("Không có bệnh nhân", True))
            End If

        Catch ex As Exception

            SetWarningStatus(New WarningBoxStatus(ex.Message, True))
        End Try
    End Sub

    ''' <summary>
    ''' In kết quả hàng loạt trên lưới
    ''' </summary>
    Private Sub PrintAllPatient()
        Try
            Dim DTPrint As New DataTable
            'Xử lý trong trường hợp in hàng loạt

            Dim vTestTypeId As String = GetIdString(PreloadedLists.TestType, clbTestType, "TestType_ID")

            DTPrint = _
                SPs.JclvGetTestResultForPrintV2FromDateToDate(Int32.MinValue, vTestTypeId, dtpTestDateFrom.Text, _
                                                               dtpTestDateTo.Text).GetDataSet().Tables(0)
            ProcessData(DTPrint)
            Dim m_dtResultDetail As DataTable
            Dim Patient_ID
            Utility.ResetProgressBarJanus(ProgressBar1, grdPatients.GetCheckedRows.Length, True)
            If grdPatients.GetCheckedRows.Count() > 0 Then
                For Each gridRow As GridEXRow In grdPatients.GetCheckedRows
                    Patient_ID = Utility.Int32Dbnull(gridRow.Cells("Patient_ID").Value, -1)
                    m_dtResultDetail = _
                        SPs.JclvGetTestResultForPrintV2FromDateToDate(Patient_ID, vTestTypeId, dtpTestDateFrom.Text, _
                                                                       dtpTestDateTo.Text).GetDataSet().Tables(0)
                    If (m_dtResultDetail.Rows.Count > 0) Then
                        ProcessData(m_dtResultDetail)
                        For Each dr As DataRow In m_dtResultDetail.Rows
                            DTPrint.ImportRow(dr)
                        Next
                        DTPrint.AcceptChanges()
                    End If
                    ProgressBar1.Value += 1
                Next
                If DTPrint.Rows.Count <= 0 Then
                    Utility.ShowMsg("Không có bản ghi tìm thấy", "thông báo")
                    Return
                End If
            Else
                Patient_ID = Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"), -1)
                Dim strSelectedTestType As String = Utility.GetCheckedID(m_dtTestInfo, "CHON=1", "TestType_ID")
                Dim testId As String = Utility.GetCheckedID(m_dtTestInfo, "CHON=1", "Test_ID")
                DTPrint = PrintTestResult(Patient_ID, strSelectedTestType, testId)
                If DTPrint.Rows.Count <= 0 Then
                    SetWarningStatus(New WarningBoxStatus("Không có kết quả để in", True))
                    Exit Sub
                End If

                If Not DTPrint.Columns.Contains("BarcodeImg") Then
                    DTPrint.Columns.Add("BarcodeImg", GetType(Byte()))
                End If

                ProcessNormalResult(DTPrint)

                Dim dataBarcode As Byte() = Utility.GenerateBarCode(Barcode2)
                For Each dr As DataRow In DTPrint.Rows
                    dr("BarcodeImg") = dataBarcode
                Next
                Utility.UpdateLogotoDatatable(DTPrint)
                DTPrint.AcceptChanges()
            End If

            Utility.ResetProgressBarJanus(ProgressBar1, grdPatients.GetCheckedRows.Length, False)

            'Report
            Dim crpt
            Select Case _myProperties.PrintAllPatientsReportType
                Case "NHTD"
                    crpt = New NHTD_crpt_PrintMultiPatients
                Case "UONGBI"
                    crpt = New UONGBI_crpt_DetailTestReport_ALLFromDateToDateAllPatient
                Case "TRUCKHE"
                    crpt = New TrucKhe2_crpt_DetailTestReport_ALL
                Case Else
                    crpt = New JCLV_crpt_DetailTestReport_ALLFromDateToDateAllPatient
            End Select


            ' Dim crpt = globalModule.GetCrystalReport(vReportType)

            Dim oForm As New frm_Preview("In kết quả xét nghiệm", crpt, False)
            'Utility.ResetProgressBarJanus(ProgressBar1, grdPatients.GetCheckedRows.Length, False)
            'DTPrint.DefaultView.Sort = "Barcode ASC"
            crpt.SetDataSource(DTPrint)
            'End If
            Dim ShowSubReport, ShowMainReport As Integer
            ShowSubReport = 0
            ShowMainReport = 1
            'End If
            crpt.DataDefinition.FormulaFields.Item("Formula_1").Text = Chr(34) & _
                                                                        Replace( _
                                                                                 "                Bác sĩ điều trị                                                                                         Trưởng phòng xét nghiệm", _
                                                                                 "#$X$#", _
                                                                                 Chr(34) & "&Chr(13)&" & Chr(34)) & _
                                                                        Chr(34)
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
            Try
                crpt.SetParameterValue("sCurrentDate", Utility.GetFormatDateTime(DateTime.Now, "dd/MM/yyyy"))
            Catch ex As Exception
            End Try
            Try
                crpt.SetParameterValue("sCurrentDateTime", _
                                        Utility.GetFormatDateTime(DateTime.Now, "dd/MM/yyyy HH:mm:ss"))
            Catch ex As Exception
            End Try
            Try
                crpt.SetParameterValue("sHotPhone", gv_sHotPhone)
            Catch ex As Exception
            End Try

            oForm.crptViewer.ReportSource = crpt

            oForm.ShowDialog()
            DefaultNow(Me)
            'End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ProcessData(ByRef DT As DataTable)

        If Not DT.Columns.Contains("BarcodeImg") Then
            DT.Columns.Add("BarcodeImg", GetType(Byte()))
        End If
        If Not DT.Columns.Contains("sSex") Then
            DT.Columns.Add("sSex", GetType(String))
        End If

        For Each dr As DataRow In DT.Rows
            Try
                Barcode1.Data = CType(sDBnull(dr("Barcode"), "0000000000"), String)
                'Barcode1.Image().Save(Application.StartupPath & "\Temp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                dr("BarcodeImg") = Utility.GenerateBarCode(Barcode1)
                ' bytGetImage(Application.StartupPath & "\Temp.jpg")
                dr("TESTTYPE_NAME") = dr("TESTTYPE_NAME").ToString.ToUpper
                dr("PID") = dr("Barcode").ToString
            Catch ex As Exception

            End Try

            If dr("sex") Then
                dr("Normal_Level") = dr("Normal_Level")
                dr("sSex") = "Nam"
            Else
                dr("Normal_Level") = dr("Normal_LevelW")
                dr("sSex") = "Nữ"
            End If

        Next
        DT.AcceptChanges()
        ProcessNormalResult(DT)
    End Sub

#End Region

    Private Sub frmTestDetail_New_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            AddHandler OnError, AddressOf OnErrorHanlder

            'Load Myproperties
            LoadProperties()

            'Nạp các biến cấu hình
            SplitContainerMain.SplitterDistance = _myProperties.MainDisctance
            SplitContainerResult.SplitterDistance = _myProperties.TestResultDistance
            If _myProperties.SaveLinkUnlinkState Then _
                btnLinkUnlink.ImageIndex = IIf(_myProperties.LinkUnlinkState, 1, 0)
            cboDate.Focus()
            FillGrpDatePicker()
            FillSexCombobox()
            FillTestTypeList()
            LoadReportType()

            currentTestTypeId = PreloadedLists.TestType(0)(TTestTypeList.Columns.TestTypeId)

            ModifyCommand()

            If _myProperties.AutoClickSearchButton Then cmdSearch.PerformClick()

            If Not _myProperties.AllowUserEditResult Then
                grdResultDetail.RootTable.Columns("Test_Result").Selectable = False
                grdResultDetail.ContextMenuStrip = Nothing
            End If


        Catch ex As Exception
            RaiseEvent OnError("Lỗi trong quá trình khởi động form", ex)
            Dispose()
        Finally
            _formLoaded = True
        End Try

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
        Try
            'Gán cờ báo đang tìm kiếm
            issearching = True

            'Tìm kiếm bn
            Dim vAge As Integer = 0
            If txtAge.Text.Trim = "" Then
                vAge = 0
            Else
                If IsNumeric(txtAge.Text.Trim) Then
                    vAge = CInt(txtAge.Text.Trim)
                Else
                    txtAge.Focus()
                    Return
                End If
            End If
            'Dim vSex As Integer = Convert.ToInt32(GetControlPropertyThreadSafe(cboSex, "SelectedValue"))
            Dim vSex As Integer = Convert.ToInt32(lablinkhelper.Utilities.GetPropertyValue(cboSex, "SelectedValue"))
            Dim vTestTypeId As String = GetIdString(PreloadedLists.TestType, clbTestType, "TestType_ID")
            Dim vBarcode As String = IIf(txtBarcode.Text.Trim = "", "NOTHING", txtBarcode.Text.Trim)
            Dim vPid As String = IIf(txtPID.Text.Trim = "", "NOTHING", txtPID.Text.Trim)
            Dim vName As String = IIf(txtName.Text.Trim = "", "NOTHING", txtName.Text.Trim)

            mv_DTPatientInfor = _
                SPs.SpGetTestInforForPatientXNV3(dtpTestDateFrom.Value, dtpTestDateTo.Value, vTestTypeId, vBarcode, _
                                                  vPid, vName, vAge, vSex).GetDataSet().Tables(0)

            If mv_DTPatientInfor IsNot Nothing Then
                SetWarningStatus( _
                                  IIf(mv_DTPatientInfor.Rows.Count = 0, _
                                       New WarningBoxStatus("Không có kết bệnh nhân nào thỏa mãn điều kiện tìm kiếm", _
                                                             True), _
                                       New WarningBoxStatus( _
                                                             String.Format("Tìm thấy <b> {0} </b> Bệnh nhân", _
                                                                            mv_DTPatientInfor.Rows.Count), False)))

                'Nếu chưa tồn tại cột thì gán
                If Not mv_DTPatientInfor.Columns.Contains("NumberOfTest") Then _
                    mv_DTPatientInfor.Columns.Add("NumberOfTest", GetType(String))

                For Each dr As DataRow In mv_DTPatientInfor.Rows
                    dr("NumberOfTest") = String.Format("{0}/{1}", dr("TestHasResult"), dr("TotalTest"))
                Next

                grdPatients.DataSource = mv_DTPatientInfor
                issearching = False
                If mv_DTPatientInfor.Rows.Count > 1 Then grdPatients.MoveFirst()
                grdPatients_SelectionChanged(grdPatients, New EventArgs())
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            issearching = False
        End Try

    End Sub

    Private Sub grdPatients_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles grdPatients.SelectionChanged
        If issearching Then Return
        Try
            If grdPatients.CurrentRow IsNot Nothing Then
                Dim testIdString As String = GetIdString(PreloadedLists.TestType, clbTestType, "TestTYpe_ID")
                If grdTestInfo.CurrentRow IsNot Nothing Then
                    currentTestTypeId = grdTestInfo.GetValue(TTestTypeList.Columns.TestTypeId)
                End If
                BindTestInfo(Utility.Int32Dbnull(grdPatients.CurrentRow.Cells("Patient_ID").Value, -1), testIdString)

                MoveToCurrentTestTypeRow()
                ModifyCommand()
            Else
                m_dtTestInfo.Clear()
                m_dtTestInfo.AcceptChanges()
                m_dtResultDetail.Clear()
                m_dtResultDetail.AcceptChanges()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdTestInfo_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles grdTestInfo.SelectionChanged
        Try
            If grdTestInfo.CurrentRow IsNot Nothing Then
                Barcode2.Visible = _
                    Not String.IsNullOrEmpty(Utility.sDbnull(grdTestInfo.GetValue(TTestInfo.Columns.Barcode), ""))
                _rowFilter = "Test_ID=" & Utility.Int32Dbnull(grdTestInfo.CurrentRow.Cells("Test_ID").Value, -1)
                Barcode2.Data = Utility.sDbnull(grdTestInfo.GetValue(TTestInfo.Columns.Barcode), "")
            End If
            m_dtResultDetail.DefaultView.RowFilter = _rowFilter
            ModifyCommand()
            If _myProperties.AutomaticLoadRegList Then btnRegData.PerformClick()

            If m_dtResultDetail.Select(String.Format("{0} and Test_Result = ''", _rowFilter)).Count <> 0 Then
                'Janus.Windows.GridEX.GridEXSortKey()
                m_dtResultDetail.DefaultView.Sort = "Test_Result ASC"
            Else
                m_dtResultDetail.DefaultView.Sort = "Data_Sequence ASC"
            End If
            'm_dtResultDetail.AcceptChanges()
            SetTestDetailSource()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboDate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cboDate.SelectedIndexChanged
        Try
            Dim index As Integer = cboDate.SelectedIndex
            dtpTestDateFrom.Enabled = (index = 2)
            dtpTestDateTo.Enabled = (index = 2)
            If index = 0 Then
                dtpTestDateFrom.Value = DateTime.Now
                dtpTestDateTo.Value = dtpTestDateFrom.Value
            ElseIf index = 1 Then
                dtpTestDateFrom.Value = DateTime.Now.AddDays(-1)
                dtpTestDateTo.Value = dtpTestDateFrom.Value
            Else
                dtpTestDateFrom.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnParaEntry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnParaEntry.Click
        Try
            If grdTestInfo.CurrentRow IsNot Nothing And grdTestInfo.CurrentRow IsNot Nothing Then
                Dim frm As frmBiDataControlSelection_ListViewStyle = New frmBiDataControlSelection_ListViewStyle
                'Thêm Kết quả
                frm.action = 1
                frm.dtRegList = m_dtResultDetail
                frm.testId = grdTestInfo.GetValue("Test_ID")
                frm.txtBarcode.Text = grdTestInfo.GetValue("Barcode")
                frm.UiGroupBox1.Text = grdTestInfo.GetValue("TestType_Name")
                frm.ShowDialog()
                ModifyCommand()
                m_dtResultDetail.AcceptChanges()
                SetTestDetailSource()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdAddPatient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddPatient.Click
        'Try
        '    If mv_DTPatientInfor.Rows.Count > 0 Then
        '        Dim oForm As New FrmPatientRegistration_L1_New
        '        oForm.m_iAction = 2
        '        oForm.mv_DR = mv_DTPatientInfor.Rows(grdPatients.CurrentRow.RowIndex)
        '        oForm.ShowDialog()
        '        mv_DTPatientInfor.AcceptChanges()
        '    Else


        '    End If

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub tsmAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsmAddDetail.Click
        btnParaEntry.PerformClick()
    End Sub

    Private Sub tsmDelDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsmDelDetail.Click
        DeleteTestDetail()
    End Sub

    Private Sub tsmManualAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles tsmManualAddDetail.Click

        Dim frm As New FrmManualAddTestDetail
        Try
            frm.ShowDialog()
            If frm.m_cancel = False Then
                Dim newDr As DataRow = m_dtResultDetail.NewRow()
                newDr("CHON") = 1
                newDr("Barcode") = grdTestInfo.GetValue("Barcode")
                newDr("Test_Date") = lablinkhelper.Utilities.GetSysDate()
                'newDr("Test_Date") = SPs.gets
                newDr("Para_Name") = frm.txtPara_Name.Text
                newDr("Test_ID") = grdTestInfo.GetValue("Test_ID")
                newDr("Patient_ID") = grdTestInfo.GetValue("Patient_ID")
                newDr("TestType_ID") = grdTestInfo.GetValue("TestType_ID")
                newDr("Test_Result") = frm.txtTest_Result.Text
                newDr("Normal_Level") = frm.txtNormal_Level.Text
                newDr("Normal_LevelW") = frm.txtNormal_LevelW.Text
                newDr("PrintData") = 1
                newDr("Measure_Unit") = frm.txtMeasure_Unit.Text
                newDr("Data_Sequence") = 999

                newDr("TestDetail_ID") = _
                    UpdateResultDetail(-1, newDr("Test_ID"), newDr("TestType_ID"), newDr("Patient_ID"), _
                                        newDr("Barcode"), newDr("Para_Name"), newDr("Data_Sequence"), True, _
                                        newDr("Test_Result"), newDr("Measure_Unit"), newDr("Normal_Level"), _
                                        newDr("Normal_LevelW"))

                m_dtResultDetail.Rows.Add(newDr)
                m_dtResultDetail.AcceptChanges()
            End If
        Catch ex As Exception

        Finally
            frm.Dispose()
        End Try

    End Sub

    Private Sub grdResultDetail_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) _
        Handles grdResultDetail.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.Delete
                    DeleteTestDetail()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExpandPanel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExpandPanel.Click
        Try
            If Not SplitContainer1.Panel1Collapsed Then
                SplitContainer1.Panel1Collapsed = True
                Select Case cboDate.SelectedIndex
                    Case 0, 1
                        btnExpandPanel.Text += String.Format(": {0}", cboDate.SelectedItem.ToString().ToUpper())
                    Case Else
                        btnExpandPanel.Text += _
                            String.Format(": {0} đến {1}", dtpTestDateFrom.Value.ToShortDateString(), _
                                           dtpTestDateTo.Value.ToShortDateString())
                End Select
            Else
                SplitContainer1.Panel1Collapsed = False
                btnExpandPanel.Text = btnExpandPanel.Tag
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmTestDetail_V2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.Control Then
                Select Case e.KeyCode
                    Case Keys.K
                        btnParaEntry.PerformClick()
                    Case Keys.E
                        btnExpandPanel.PerformClick()
                    Case Keys.L
                        btnRegData.PerformClick()
                End Select
                Exit Sub
            End If
            Select Case e.KeyCode
                Case Keys.F3
                    cmdSearch.PerformClick()
                Case Keys.Escape
                    Dispose()
                Case Keys.F4
                    cmd_InPhieu_XetNghiem_TongHop.PerformClick()
                Case Keys.F5
                    cmd_InPhieu_XetNghiem.PerformClick()

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdResultDetail_CellEdited(ByVal sender As Object, ByVal e As ColumnActionEventArgs) _
        Handles grdResultDetail.CellEdited
        Try
            If grdTestInfo.CurrentRow Is Nothing Or grdResultDetail.CurrentRow Is Nothing Then Return
            If String.IsNullOrEmpty(Utility.sDbnull(grdResultDetail.GetValue("Test_Result"))) Then Return
            Dim _
                resultDetail As Integer = _
                    UpdateResultDetail(Utility.Int32Dbnull(grdResultDetail.GetValue("TestDetail_ID"), -1), _
                                        Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID")), _
                                        Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID")), _
                                        Utility.Int32Dbnull(grdTestInfo.GetValue("Patient_ID")), _
                                        Utility.sDbnull(grdTestInfo.GetValue("Barcode")), _
                                        Utility.sDbnull(grdResultDetail.GetValue("Para_NAME")), _
                                        Utility.sDbnull(grdResultDetail.GetValue("Data_Sequence")), _
                                        Utility.sDbnull(grdResultDetail.GetValue("PrintData").ToString), _
                                        Utility.sDbnull(grdResultDetail.GetValue("Test_Result")), _
                                        Utility.sDbnull(grdResultDetail.GetValue("Measure_Unit")), _
                                        Utility.sDbnull(grdResultDetail.GetValue("Normal_Level")), _
                                        Utility.sDbnull(grdResultDetail.GetValue("Normal_LevelW")))
            grdResultDetail.CurrentRow.Cells("TestDetail_ID").Value = resultDetail

            Dim _
                row As DataRow = _
                    m_dtResultDetail.Select(String.Format("Para_NAME = '{0}'", grdResultDetail.GetValue("Para_NAME")))( _
                                                                                                                           0)
            row("Test_Result") = grdResultDetail.GetValue("Test_Result")
            row("TestDetail_ID") = resultDetail

            grdResultDetail.UpdateData()
            m_dtResultDetail.AcceptChanges()
            grdResultDetail.Refresh()
            ProcessNormalResult(m_dtResultDetail)
            IsNormalResult(m_dtResultDetail)
            m_dtResultDetail.AcceptChanges()
            ModifyStatus()

        Catch ex As Exception
            Utility.ShowMsg("Có lỗi trong quá trình lưu kết quả", "Thông báo")
        End Try
    End Sub

    Private Sub tsmRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsmRefresh.Click
        grdPatients_SelectionChanged(sender, e)
    End Sub

    Private Sub btnRegData_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegData.Click
        Try
            If grdTestInfo.CurrentRow IsNot Nothing Then
                Dim para_name As New ArrayList
                For Each gridExRow As GridEXRow In grdResultDetail.GetDataRows
                    para_name.Add(gridExRow.Cells(TResultDetail.Columns.ParaName).Value)
                Next

                Dim _
                    dt As DataTable = _
                        SPs.SpGetRegListByBarcodeAndTestID(grdTestInfo.GetValue(TTestInfo.Columns.Barcode), _
                                                            Utility.Int32Dbnull( _
                                                                                 grdTestInfo.GetValue( _
                                                                                                       TTestInfo.Columns _
                                                                                                          .TestId), -1)) _
                        .GetDataSet().Tables(0)
                If dt.Rows.Count <= 0 Then
                    'MessageBox.Show("Xét nghiệm không có đăng ký chi tiết", "Thông báo")
                    SetWarningStatus(New WarningBoxStatus("Xét nghiệm không có đăng ký chi tiết", True))
                    Exit Sub
                End If
                For Each dr As DataRow In dt.Rows
                    If Not para_name.Contains(dr(DDataControl.Columns.DataName).ToString()) Then
                        Dim newRow As DataRow = m_dtResultDetail.NewRow()
                        newRow(TResultDetail.Columns.ParaName) = dr(DDataControl.Columns.DataName).ToString()
                        newRow(TResultDetail.Columns.TestId) = grdTestInfo.GetValue(TTestInfo.Columns.TestId)
                        Dim strFilter As String = String.Empty
                        strFilter += String.Format("{0} = {1} And {2} = '{3}'", TResultDetail.Columns.TestId, _
                                                    grdTestInfo.GetValue(TTestInfo.Columns.TestId), _
                                                    TResultDetail.Columns.ParaName, _
                                                    dr(DDataControl.Columns.DataName).ToString())
                        If m_dtResultDetail.Select(strFilter).Length > 0 Then Continue For
                        newRow(TResultDetail.Columns.TestTypeId) = grdTestInfo.GetValue(TTestInfo.Columns.TestTypeId)
                        newRow(TResultDetail.Columns.DataSequence) = dr(DDataControl.Columns.DataSequence)
                        newRow(TResultDetail.Columns.PrintData) = dr(DDataControl.Columns.DataPrint)
                        newRow(TResultDetail.Columns.MeasureUnit) = dr(DDataControl.Columns.MeasureUnit)
                        newRow(TResultDetail.Columns.NormalLevel) = dr(DDataControl.Columns.NormalLevel)
                        newRow(TResultDetail.Columns.NormalLevelW) = dr(DDataControl.Columns.NormalLevelW)
                        newRow(TResultDetail.Columns.TestDetailId) = -1

                        m_dtResultDetail.Rows.Add(newRow)
                        'End If
                    End If
                Next
            End If
            SetTestDetailSource()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmd_InPhieu_XetNghiem_TongHop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd_InPhieu_XetNghiem_TongHop.Click
        PrintAllPatient()
    End Sub

    Private Sub cmd_InPhieu_XetNghiem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cmd_InPhieu_XetNghiem.Click
        INPHIEU_XETNGHIEM(reportType2, False)
    End Sub

    'thực hiện việc xóa thông tin của bản ghi đang chọn
    Private Sub cmdXoaCheck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdXoaCheck.Click
        If Not _myProperties.AllowUserEditResult Then Exit Sub

        If grdResultDetail.GetCheckedRows().Length <= 0 Then
            Utility.ShowMsg("Bạn phải chọn một bản ghi thực hiện xóa thông tin của bản ghi kết quả", "Thông báo")
            grdResultDetail.Focus()
            Return
        End If
        If Utility.AcceptQuestion("Bạn có muốn xóa thông tin của bản ghi đã chọn ", "Thông báo", True) Then
            For Each GridEX As GridEXRow In grdResultDetail.GetCheckedRows
                Dim v_TestResult_ID As Long = -1
                v_TestResult_ID = Utility.Int64Dbnull(GridEX.Cells("TestDetail_ID").Value, -1)
                TResultDetail.Delete(v_TestResult_ID)
                Dim dataSource As DataTable = DirectCast(grdResultDetail.DataSource, DataTable)
                dataSource.Rows.Remove(dataSource.Select(String.Format("TestDetail_ID = {0}", v_TestResult_ID))(0))
                GridEX.Delete()
                grdResultDetail.UpdateData()
                grdResultDetail.Refresh()
            Next
            m_dtResultDetail.AcceptChanges()
        End If
        ModifyCommand()
        'SetTestDetailSource()
    End Sub

    Private Sub grdPatients_ApplyingFilter(ByVal sender As Object, ByVal e As CancelEventArgs) _
        Handles grdPatients.ApplyingFilter
        ModifyCommand()
    End Sub

    'hàm thực hiện in kết quả hàng loạt
    Private Sub cmdInHangLoat_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInHangLoat.Click
        PrintAllPatient()
    End Sub

    Private Sub chkHasResult_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles chkHasResult.CheckedChanged
        For Each GridEX As GridEXRow In From GridEX1 In grdPatients.GetDataRows Where GridEX1.RowType = RowType.Record
            GridEX.IsChecked = False
        Next
        For Each GridEX As GridEXRow In _
            From GridEX1 In grdPatients.GetDataRows Where GridEX1.RowType = RowType.Record _
                Where Utility.Int32Dbnull(GridEX1.Cells("TestHasResult").Value, 0) >= 1
            GridEX.IsChecked = True
        Next
    End Sub

    Private Sub ChọnTấtCảToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ChọnTấtCảToolStripMenuItem.Click
        For i As Integer = 0 To clbTestType.Items.Count - 1
            clbTestType.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub HủyChọnToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles HủyChọnToolStripMenuItem.Click
        For i As Integer = 0 To clbTestType.Items.Count - 1
            clbTestType.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub grdTestInfo_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles grdTestInfo.DoubleClick
        btnParaEntry.PerformClick()
    End Sub

    Private Sub frmTestDetail_V2_New_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
        Handles MyBase.FormClosing
        SaveProperties()
    End Sub

    Private Sub cmdEscape_ButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEscape.ButtonClick
        Me.Dispose(True)
    End Sub

    Private Sub ConfigToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ConfigToolStripMenuItem.Click
        Dim f As New FrmSetting
        f.Text = Text
        f.PropertiesObject = _myProperties
        f.ShowDialog(Me)
        SaveProperties()
    End Sub

    Private Sub SplitContainerMain_SplitterMoved(ByVal sender As Object, ByVal e As SplitterEventArgs) _
        Handles SplitContainerMain.SplitterMoved
        If Not _formLoaded Then Return
        _myProperties.MainDisctance = SplitContainerMain.SplitterDistance
    End Sub

    Private Sub SplitContainerResult_SplitterMoved(ByVal sender As Object, ByVal e As SplitterEventArgs) _
        Handles SplitContainerResult.SplitterMoved
        If Not _formLoaded Then Return
        _myProperties.TestResultDistance = SplitContainerResult.SplitterDistance
    End Sub

    Private Sub btnLinkUnlink_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLinkUnlink.Click
        btnLinkUnlink.ImageIndex = IIf(btnLinkUnlink.ImageIndex = 0, 1, 0)
        If _myProperties.SaveLinkUnlinkState Then
            _myProperties.LinkUnlinkState = (btnLinkUnlink.ImageIndex = 1)
        End If
        dtpTestDateFrom.Focus()
    End Sub

    Private Sub dtpTestDateFrom_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles dtpTestDateFrom.ValueChanged, dtpTestDateTo.ValueChanged
        If Not _formLoaded Then Return
        If btnLinkUnlink.ImageIndex = 1 Then
            Dim currentDtp As CalendarCombo = DirectCast(sender, CalendarCombo)
            If currentDtp.Name = "dtpTestDateFrom" Then
                dtpTestDateTo.Value = dtpTestDateFrom.Value
            Else
                dtpTestDateFrom.Value = dtpTestDateTo.Value
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem1.Click
        For Each dr As DataRow In m_dtTestInfo.Rows
            dr("Chon") = 1
        Next
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem2.Click
        For Each dr As DataRow In m_dtTestInfo.Rows
            dr("Chon") = 0
        Next
    End Sub

    Private Sub grdTestInfo_CellValueChanged(ByVal sender As Object, ByVal e As ColumnActionEventArgs) _
        Handles grdTestInfo.CellValueChanged
        grdTestInfo.UpdateData()
    End Sub

    Private Sub grdResultDetail_CellValueChanged(ByVal sender As Object, ByVal e As ColumnActionEventArgs) _
        Handles grdResultDetail.CellValueChanged, grdResultDetail.ColumnHeaderClick
        If (e.Column.Key = "CHON") Then
            cmdXoaCheck.Enabled = grdResultDetail.GetCheckedRows().Count() > 0
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtBarcode.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            cmdSearch.PerformClick()
        End If

    End Sub

    Private Sub txtName_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtName.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            cmdSearch.PerformClick()
        End If
    End Sub

    Private Sub cmd_InPhieu_XetNghiem_TongHop_ButtonClick(sender As Object, e As EventArgs) Handles cmd_InPhieu_XetNghiem_TongHop.ButtonClick

    End Sub

    Private Sub cmd_InPhieu_XetNghiem_ButtonClick(sender As Object, e As EventArgs) Handles cmd_InPhieu_XetNghiem.ButtonClick

    End Sub
End Class