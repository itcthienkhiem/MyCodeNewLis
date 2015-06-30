Imports DevComponents.DotNetBar.Controls
Imports System.Windows.Forms
Imports Janus.Windows.GridEX
Imports System.Reflection
Imports System.Data.SqlClient
Imports VietBaIT.Lablink.Model
Imports SubSonic
Imports VietBaIT.CommonLibrary
Imports VietBaIT.Lablink.LoadEnvironments

Public Class frmTestDetail_V2

#Region "Attribute"

    Private reportType, reportType2 As Integer

    Private _rowFilter As String = "1=1"

    Private actionResult As ActionResult = actionResult.[Error]

    Private mv_DTPatientInfor As DataTable
    Private m_dtResultDetail As New DataTable()
    Private m_dtTestInfo As New DataTable()

    Private currentTestTypeId As Integer

    ''' <summary>
    ''' File Config để lưu biến _sortType
    ''' </summary>
    ReadOnly _sConfigFileName = "frmPatientRegistration_L1.txt"

    ''' <summary>
    ''' Biến quy đinh sắp xếp khi load Data Control
    ''' 0: Sắp xếp theo Data Seq
    ''' 1: Sắp xếp theo ABC
    ''' </summary>
    Dim _sortType As Integer = 0


#End Region

#Region "Private Methol"


    ' Hàm load ngày
    Private Sub FillGrpDatePicker()
        Try
            ' Thêm các tùy chọn
            cboDate.Items.Add("Hôm nay")
            cboDate.Items.Add("Hôm qua")
            cboDate.Items.Add("Tùy Chọn")

            'Set giá trị mặc định cho datetimepicker
            dtpTestDateFrom.Value = DateTime.Now
            dtpTestDateTo.Value = DateTime.Now

            cboDate.SelectedIndex = 2

        Catch generatedExceptionName As Exception
            Throw
        End Try
    End Sub

    Private Sub SetStatusMessage()
        Select Case actionResult
            Case actionResult.Success

                Utility.ShowMsg("Bạn thực hiện cập nhập dữ liệu thành công")
                Exit Select
            Case actionResult.[Error]
                Utility.ShowMsg("Lỗi trong quá trình cập nhập")
                Exit Select
        End Select
    End Sub

    'Hàm fill data vào combobox
    Private Sub FillSexCombobox()
        cboSex.DataSource = Nothing
        cboSex.Items.Clear()

        Dim dt = New DataTable()
        dt.Columns.Add("ValueItem")
        dt.Columns.Add("DisplayItem")

        Dim dr As DataRow = dt.NewRow()
        dr(0) = -1
        dr(1) = ""
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = 1
        dr(1) = "Nam"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = 0
        dr(1) = "Nữ"
        dt.Rows.Add(dr)

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
            SetAllCheckedBoxTrue(clbTestType)
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
            cmdXoaCheck.Enabled = grdResultDetail.RowCount > 0
        Catch ex As Exception

        End Try

    End Sub

    Private Class WarningBoxStatus
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

        Private m_DisplayText As String

        Public Property BlinkStatus() As Boolean
            Get
                Return m_BlinkStatus
            End Get
            Set(ByVal value As Boolean)
                m_BlinkStatus = value
            End Set
        End Property

        Private m_BlinkStatus As Boolean
    End Class

    Private Sub SetWarningStatus(ByVal status As WarningBoxStatus)
        lablinkhelper.Utilities.SetControlProperty(Warningmesage, "Text", status.DisplayText)
        If Not status.BlinkStatus Then
            Warningmesage.ColorScheme = eWarningBoxColorScheme.[Default]
        End If
        WarningBoxTimer.Enabled = status.BlinkStatus
    End Sub

    Private Sub DisplaySearchInfo1()
        Try
            If mv_DTPatientInfor IsNot Nothing Then
                If mv_DTPatientInfor.Rows.Count = 0 Then
                    SetWarningStatus( _
                                      New WarningBoxStatus("Không có kết bệnh nhân nào thỏa mãn điều kiện tìm kiếm", _
                                                            True))
                Else
                    SetWarningStatus( _
                                      New WarningBoxStatus( _
                                                            String.Format("Tìm thấy <b> {0} </b> Bệnh nhân", _
                                                                           mv_DTPatientInfor.Rows.Count), False))
                End If

                If Not mv_DTPatientInfor.Columns.Contains("NumberOfTest") Then
                    mv_DTPatientInfor.Columns.Add("NumberOfTest", GetType(String))
                End If
                For Each dr As DataRow In mv_DTPatientInfor.Rows
                    dr("NumberOfTest") = dr("TestHasResult").ToString + "/" + dr("TotalTest").ToString
                Next

                grdPatients.DataSource = mv_DTPatientInfor
                grdPatients.MoveFirst()
                'mv_DTPatientInfor.AcceptChanges()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetAllCheckedBoxTrue(ByVal clb As CheckedListBox)
        Try
            Const sFileName As String = "defaultTestTypechecked.txt"
            Dim allTestTypeId() As String

            If IO.File.Exists(sFileName) Then
                Dim tempstring As String() = IO.File.ReadAllLines(sFileName)
                If tempstring.Length > 0 Then
                    allTestTypeId = tempstring(0).Split(",")
                End If
            Else
                IO.File.WriteAllText(sFileName, "-1")
            End If

            If allTestTypeId.Contains("-1") Or allTestTypeId.Count() = 0 Then
                For i As Integer = 0 To clb.Items.Count - 1
                    clb.SetItemChecked(i, True)
                Next i
            Else
                For i As Integer = 0 To PreloadedLists.TestType.Rows.Count - 1
                    If allTestTypeId.Any(Function(s) s.Trim() = PreloadedLists.TestType.Rows(i)("TestType_id").ToString().Trim()) Then
                        clb.SetItemChecked(i, True)
                    End If
                Next i
            End If
        Catch ex As Exception
            For i As Integer = 0 To clb.Items.Count - 1
                clb.SetItemChecked(i, True)
            Next i
        End Try

    End Sub

    Private Function GetIdString(ByVal dt As DataTable, ByVal clb As CheckedListBox, ByVal colID As String) As String
        Try
            Dim testIdString As String = String.Empty
            For i As Integer = 0 To clb.Items.Count - 1
                If clb.GetItemChecked(i) Then
                    testIdString += dt.Rows(i)(colID).ToString + ","
                End If
            Next
            If testIdString.EndsWith(",") Then
                testIdString = testIdString.Remove(testIdString.Length - 1)
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

    Private Sub GetPatientInfo()
        Try
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
            Dim vSex As Integer = Convert.ToInt32(GetControlPropertyThreadSafe(cboSex, "SelectedValue"))
            Dim vTestTypeId As String = GetIdString(PreloadedLists.TestType, clbTestType, "TestType_ID")
            Dim vBarcode As String = IIf(txtBarcode.Text.Trim = "", "NOTHING", txtBarcode.Text.Trim)
            Dim vPid As String = IIf(txtPID.Text.Trim = "", "NOTHING", txtPID.Text.Trim)
            Dim vName As String = IIf(txtName.Text.Trim = "", "NOTHING", txtName.Text.Trim)

            mv_DTPatientInfor = SPs.SpGetTestInforForPatientXNV3(dtpTestDateFrom.Value, dtpTestDateTo.Value, vTestTypeId, vBarcode, _
                                                  vPid, vName, vAge, vSex).GetDataSet().Tables(0)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BindTestInfo(ByVal v_PatientId As Integer, ByVal testTypeId As String)
        Dim ds As New DataSet
        ds = SPs.SpGetTestInfoByPatientIDV2(v_PatientId, testTypeId, dtpTestDateFrom.Value.ToString, dtpTestDateTo.Value.ToString).GetDataSet()

        m_dtTestInfo = ds.Tables(0)
        m_dtResultDetail = ds.Tables(1)
        'RemoveHandler grdTestInfo.SelectionChanged, AddressOf grdTestInfo_SelectionChanged
        'If Not bHasLoaded Then
        grdResultDetail.DataSource = m_dtResultDetail
        grdTestInfo.DataSource = m_dtTestInfo
        'End If
        'm_dtResultDetail.AcceptChanges()
        'm_dtTestInfo.AcceptChanges()
        'AddHandler grdTestInfo.SelectionChanged, AddressOf grdTestInfo_SelectionChanged


    End Sub


    Private Function PrintTestResult(ByVal vPatientId As Integer, ByVal vTestTypeId As String, _
                                      ByVal vTestId As String) _
        As DataTable
        Try
            Return SPs.SpGetTestResultForPrintV2(vPatientId, vTestTypeId, vTestId).GetDataSet().Tables(0)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Delegate Function GetControlPropertyThreadSafeDelegate _
        (ByVal control As Control, ByVal propertyName As String) As Object

    Private Delegate Sub SetControlPropertyThreadSafeDelegate _
        (ByVal control As Control, ByVal propertyName As String, ByVal propertyValue As Object)

    Private Shared Function GetControlPropertyThreadSafe(ByVal control As Control, ByVal propertyName As String) _
        As Object
        'object result = null;
        If control.InvokeRequired Then
            Return _
                control.Invoke(New GetControlPropertyThreadSafeDelegate(AddressOf GetControlPropertyThreadSafe), _
                                New Object() {control, propertyName})
        Else
            Return _
                control.[GetType]().InvokeMember(propertyName, BindingFlags.GetProperty, Nothing, control, Nothing)
        End If
        'return result;
    End Function

#End Region


    Private Sub frmTestDetail_New_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            If IO.File.Exists(_sConfigFileName) Then
                _sortType = Utility.Int32Dbnull(IO.File.ReadAllLines(_sConfigFileName)(0), 0)
            Else
                IO.File.WriteAllText(_sConfigFileName, "0")
            End If

            cboDate.Focus()
            FillGrpDatePicker()
            FillSexCombobox()
            FillTestTypeList()
            LoadReportType()

            currentTestTypeId = PreloadedLists.TestType(0)(TTestTypeList.Columns.TestTypeId)

            ModifyCommand()
            cmdSearch.PerformClick()



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Thông báo")
            Me.Dispose()
        End Try
    End Sub
    'hàm thực hiện việc ẩn hiện thông tin của các nút in phiếu
    Private Sub LoadReportType()
        reportType = SysPara.ReportType
        reportType2 = SysPara.ReportType2
        cmd_InPhieu_XetNghiem_TongHop.Visible = reportType >= 0
        cmd_InPhieu_XetNghiem.Visible = reportType2 >= 0
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
        PerformSearch()
    End Sub

    Private Sub PerformSearch()
        Try
            GetPatientInfo()
            DisplaySearchInfo1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub grdPatients_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdPatients.SelectionChanged

        Try
            If grdPatients.CurrentRow IsNot Nothing Then
                Dim testIdString As String = GetIdString(PreloadedLists.TestType, clbTestType, "TestTYpe_ID")
                If grdTestInfo.CurrentRow IsNot Nothing Then
                    currentTestTypeId = grdTestInfo.GetValue(TTestTypeList.Columns.TestTypeId)
                End If
                BindTestInfo(Utility.Int32Dbnull(grdPatients.CurrentRow.Cells("Patient_ID").Value, -1), testIdString)
                ProcessNormalResult(m_dtResultDetail)
                IsNormalResult(m_dtResultDetail)
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

    Private Sub MoveToCurrentTestTypeRow()
        Try
            Dim idx As Integer = -1
            For i As Integer = 0 To grdTestInfo.RowCount
                If grdTestInfo.GetRow(i).Cells(TTestTypeList.Columns.TestTypeId).Value = currentTestTypeId Then
                    idx = i
                    Exit For
                End If
            Next
            If idx = -1 Then
                grdTestInfo.MoveToRowIndex(0)
            Else
                grdTestInfo.MoveToRowIndex(idx)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UpdateData(ByRef DT As DataTable)
        Dim vResult As String = "Test_result"
        Dim alias_Name As String = "Alias_Name"
        Dim iCount As Int16
        Dim stramtinh As String = "AM TINH"
        Dim strduongtinh As String = "DUONG TINH"
        Dim Anti As String = "Anti - HCV"
        Dim HBsag As String = "HBsag"
        Dim HIV As String = "HIV"
        Dim JudgeH As String
        Dim JudgeL As String

        For Each dr As DataRow In DT.Rows

            dr("Test_result") = dr("Test_result") '& " " & sDBnull(dr("Measure_Unit"))
            dr("Normal_Level") = dr("Normal_Level")
            dr("Normal_LevelW") = dr("Normal_LevelW") '& " " & sDBnull(dr("Measure_Unit"))

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
                    ''truong hop nam trong khonang co can tren va can duoi
                    If String.IsNullOrEmpty(dr(testResult)) Or String.IsNullOrEmpty(normal) Then
                        dr(binhthuong) = ""
                    ElseIf IsNumeric(dr(testResult)) Then
                        dr(binhthuong) = ""
                        Dim tempResult As Double = CDbl(dr(testResult))
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
                    Else
                        ''Truong hop cua Negative va positive
                        ''Dim b As Boolean = (dr(testResult).ToString.Trim.ToUpper.IndexOf(arrResultWithLetters(0)) >= 0)
                        Dim b1 As Boolean = dr(testResult).ToString.Trim.ToUpper.IndexOf("DƯƠ") >= 0
                        Dim b2 As Boolean = dr(testResult).ToString.Trim.ToUpper.IndexOf("DUO") >= 0
                        Dim b3 As Boolean = dr(testResult).ToString.Trim.ToUpper.IndexOf("POS") >= 0
                        If b1 Or b2 Or b3 Then
                            dr(binhthuong) = hight
                        Else
                            dr(binhthuong) = ""
                        End If

                    End If
                Catch ex As Exception
                    dr(binhthuong) = " "
                    Continue For
                End Try
            Next
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


                Dim dtForPrinting As New DataTable
                dtForPrinting = PrintTestResult(patientId, strSelectedTestType, testId)
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


                ' crpt.SetParameterValue("BSThucHien", VietBaIT.CommonLibrary.globalVariables.Doctors)
                'crpt.SetParameterValue("PhongXN", VietBaIT.CommonLibrary.globalVariables.AssName)
                'thực hiện in phiếu xét nghiệm cho JCLV
                If vReportType = 4 Then
                    UpdateData(dtForPrinting)
                    crpt.SetParameterValue("sCurrentDate", Utility.GetFormatDateTime(DateTime.Now, "dd/MM/yyyy"))
                    crpt.SetParameterValue("DMY", sGetCurrentDay)
                End If
                If vReportType = 2 Then
                    crpt.SetParameterValue("sCurrentDate", VietBaIT.CommonLibrary.Utility.FormatDateTime(Date.Now))
                End If

                If Not Quick Then
                    'Dim objForm As New frmPrintPreview("In kết quả xét nghiệm", crpt, True, True)
                    Dim objForm As New VietBaIT.LABLink.Reports.frmPrintPreview("In kết quả xét nghiệm", crpt, True, True)
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

                Dim dtForPrinting As New DataTable
                dtForPrinting = PrintTestResult(patientId, strSelectedTestType, testId)
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
                
                'thực hiện in phiếu xét nghiệm cho JCLV
                If vReportType = 4 Then
                    UpdateData(dtForPrinting)
                    crpt.SetParameterValue("sCurrentDate", Utility.GetFormatDateTime(DateTime.Now, "dd/MM/yyyy"))
                    crpt.SetParameterValue("DMY", sGetCurrentDay)
                End If
                If vReportType = 2 Then
                    crpt.SetParameterValue("sCurrentDate", VietBaIT.CommonLibrary.Utility.FormatDateTime(Date.Now))
                End If

                If Not Quick Then
                    'Dim objForm As New frmPrintPreview("In kết quả xét nghiệm", crpt, True, True)
                    Dim objForm As New VietBaIT.LABLink.Reports.frmPrintPreview("In kết quả xét nghiệm", crpt, True, True)

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

    Private Sub IsNormalResult(ByRef dt As DataTable)
        Try
            For Each dr As DataRow In dt.Rows
                dr("binhthuong") = IIf(dr("Note").ToString().Trim() = "", 0, 1)
            Next
        Catch ex As Exception


        End Try
    End Sub

    Private Sub UpdatePrintStatus(ByVal strTestId As String)
        Try

            Call _
                New Update(TResultDetail.Schema).Set(TResultDetail.Columns.ParaStatus).EqualTo(1).Where( _
                                                                                                            TResultDetail _
                                                                                                               . _
                                                                                                               Columns _
                                                                                                               . _
                                                                                                               TestId) _
                    .In(Utility.FromStringToArrayList(strTestId)).Execute()
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

    Private Sub grdTestInfo_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles grdTestInfo.SelectionChanged
        Try
            _rowFilter = "1=2"
            Barcode2.Visible = Not String.IsNullOrEmpty(Utility.sDbnull(grdTestInfo.GetValue(TTestInfo.Columns.Barcode), ""))

            If grdTestInfo.CurrentRow IsNot Nothing Then
                _rowFilter = "Test_ID=" & Utility.Int32Dbnull(grdTestInfo.CurrentRow.Cells("Test_ID").Value, -1)

                Barcode2.Data = Utility.sDbnull(grdTestInfo.GetValue(TTestInfo.Columns.Barcode), "")
            End If
            m_dtResultDetail.DefaultView.RowFilter = _rowFilter
            'IsNormalResult(m_dtResultDetail)
            m_dtResultDetail.AcceptChanges()
            ModifyCommand()
            btnRegData.PerformClick()
        Catch ex As Exception
        End Try
    End Sub

    Private Function UpdateResultDetail(ByVal testDetail_id As Int32, ByVal test_ID As Integer, ByVal testtype_ID As Integer, ByVal patientId As Integer, _
                                 ByVal pv_Barcode As String, _
                                 ByVal pv_ParaName As String, ByVal pv_DataSequence As Integer, _
                                 ByVal pv_intPrint As Boolean, ByVal pv_sResult As String, _
                                 ByVal pv_sMeasureUnit As String, ByVal pv_NormalLevel As String, _
                                 ByVal pv_NormalLevelW As String) As Int32
        Try
            Dim rc As Integer
            rc = _
                SPs.SpAddResultDetailV2(test_ID, patientId, grdTestInfo.GetValue("Test_Date").ToString, pv_sResult, _
                                         pv_NormalLevel, pv_ParaName, "", _
                                         pv_Barcode, testtype_ID, pv_DataSequence, pv_sMeasureUnit, pv_intPrint, _
                                         pv_NormalLevelW).Execute()
            If testDetail_id < 0 Then
                testDetail_id = Utility.Int32Dbnull(TResultDetail.CreateQuery().WHERE(TResultDetail.Columns.TestId, test_ID).WHERE(TResultDetail.Columns.ParaName, pv_ParaName). _
                        GetMax(TResultDetail.Columns.TestDetailId), -1)
            End If
            Return testDetail_id
        Catch ex As Exception
            Utility.ShowMsg(ex.Message)
            Return -1
        End Try
    End Function

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
                Dim frm As frmDataControlSelectionByTestType = New frmDataControlSelectionByTestType
                frm.dtDataControl = PreloadedLists.DataControl
                frm.sortType = _sortType
                frm.dtRegList = m_dtResultDetail
                frm.testId = grdTestInfo.GetValue("Test_ID")
                frm.txtBarcode.Text = grdTestInfo.GetValue("Barcode")
                frm.testType_ID = grdTestInfo.GetValue("TestType_ID")
                frm.UiGroupBox1.Text = grdTestInfo.GetValue("TestType_Name")
                frm.patient_Id = grdPatients.GetValue("Patient_ID")
                frm.drDeviceList = _
                    PreloadedLists.Device.Select(DDeviceList.Columns.TestTypeId & "=" & grdTestInfo.GetValue("TestType_ID"))
                frm.ShowDialog()
                ModifyCommand()
                m_dtResultDetail = frm.dtRegList
                m_dtResultDetail.AcceptChanges()
                _sortType = frm.sortType
                IO.File.WriteAllText(_sConfigFileName, _sortType)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdEscape_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEscape.Click
        Me.Dispose(True)
    End Sub
    'hàm thực hiện việc in thông tin của in phiếu kết quả xét nghiệm
    '
    Private Sub cmdINPHIEU_XETNGHIEM_Click(ByVal sender As Object, ByVal e As EventArgs)
        INPHIEU_XETNGHIEM_TONGHOP(reportType, True)
    End Sub

    Private Sub cmdAddPatient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddPatient.Click
        Try
            If mv_DTPatientInfor.Rows.Count > 0 Then
                Dim oForm As New FrmPatientRegistration_L1
                oForm.m_iAction = 2
                oForm.mv_DR = mv_DTPatientInfor.Rows(grdPatients.CurrentRow.RowIndex)
                oForm.ShowDialog()
                mv_DTPatientInfor.AcceptChanges()
            Else


            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPrintSetting_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'Dim frm As New frmPrintSetting
            'frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsmAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsmAddDetail.Click
        btnParaEntry.PerformClick()
    End Sub

    Private Sub tsmDelDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsmDelDetail.Click
        DeleteTestDetail()
    End Sub

    Private Sub DeleteTestDetail()
        Try
            If grdResultDetail.CurrentRow Is Nothing Then
                SetWarningStatus(New WarningBoxStatus("Xét nghiệm không có kết quả xóa !", True))
                Exit Sub
            End If

            If Utility.AcceptQuestion("Thưc hiện xóa thông số " & grdResultDetail.GetValue("Para_Name"), "", True) _
                Then
                If Utility.Int32Dbnull(grdResultDetail.GetValue("TestDetail_ID"), -1) > 0 Then
                    TResultDetail.Delete(grdResultDetail.GetValue("TestDetail_ID"))
                End If

                RemoveHandler grdResultDetail.CellEdited, AddressOf grdResultDetail_CellEdited
                grdResultDetail.CurrentRow.Delete()
                AddHandler grdResultDetail.CellEdited, AddressOf grdResultDetail_CellEdited

                grdResultDetail.UpdateData()
                grdResultDetail.Refresh()
                m_dtResultDetail.AcceptChanges()

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
            'grdTestInfo.Refresh()
            'm_dtTestInfo.AcceptChanges()

            Dim testHasResultCount As Integer = 0
            For Each dr As DataRow In m_dtTestInfo.Rows
                If dr("ResultPrint_Status") > 0 Then
                    testHasResultCount += 1

                End If
            Next

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
            'grdPatients.Refresh()
            'mv_DTPatientInfor.AcceptChanges()
        Catch ex As Exception

        End Try
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

                newDr("TestDetail_ID") = UpdateResultDetail(-1, newDr("Test_ID"), newDr("TestType_ID"), newDr("Patient_ID"), newDr("Barcode"), _
                            newDr("Para_Name"), _
                            newDr("Data_Sequence"), True, newDr("Test_Result"), newDr("Measure_Unit"), _
                            newDr("Normal_Level"), newDr("Normal_LevelW"))

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

    Private Sub UiButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExpandPanel.Click
        Try
            If Not SplitContainer1.Panel1Collapsed Then
                SplitContainer1.Panel1Collapsed = True
                Select Case cboDate.SelectedIndex
                    Case 0, 1
                        btnExpandPanel.Text += ": " & cboDate.SelectedItem.ToString().ToUpper()
                    Case Else
                        btnExpandPanel.Text += ": " & dtpTestDateFrom.Value.ToShortDateString() & " đến " & _
                                               dtpTestDateTo.Value.ToShortDateString()
                End Select
            Else
                SplitContainer1.Panel1Collapsed = False
                btnExpandPanel.Text = btnExpandPanel.Tag
            End If
            'SplitContainer1.Panel1Collapsed = IIf(SplitContainer1.Panel1Collapsed, False, True)
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
                    PerformSearch()
                Case Keys.Escape
                    cmdEscape.PerformClick()
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
            Dim dataSequence As Object
            Try
                dataSequence = New [Select](LStandardTest.Columns.DataSequence).From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.DataName).IsEqualTo(Utility.sDbnull(grdResultDetail.GetValue("Para_NAME"))).ExecuteScalar()
            Catch ex As Exception
                dataSequence = 100
            End Try
            grdResultDetail.CurrentRow.Cells("TestDetail_ID").Value = UpdateResultDetail(Utility.Int32Dbnull(grdResultDetail.GetValue("TestDetail_ID"), -1), _
                        Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID")), _
                        Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID")), _
                        Utility.Int32Dbnull(grdTestInfo.GetValue("Patient_ID")), _
                        Utility.sDbnull(grdTestInfo.GetValue("Barcode")), _
                        Utility.sDbnull(grdResultDetail.GetValue("Para_NAME")), dataSequence, _
                        Utility.sDbnull(grdResultDetail.GetValue("PrintData").ToString), _
                        Utility.sDbnull(grdResultDetail.GetValue("Test_Result")), _
                        Utility.sDbnull(grdResultDetail.GetValue("Measure_Unit")), _
                        Utility.sDbnull(grdResultDetail.GetValue("Normal_Level")), _
                        Utility.sDbnull(grdResultDetail.GetValue("Normal_LevelW")))
            grdResultDetail.UpdateData()
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

    Private Sub btnRegData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegData.Click
        Try
            If grdTestInfo.CurrentRow IsNot Nothing Then
                Dim para_name As New ArrayList
                For Each gridExRow As GridEXRow In grdResultDetail.GetDataRows
                    para_name.Add(gridExRow.Cells(TResultDetail.Columns.ParaName).Value)
                Next
                'Dim dt As DataTable = SPs.SpGetRegListByBarcodeAndTestType(grdTestInfo.GetValue(TTestInfo.Columns.Barcode), _
                '    Utility.Int32Dbnull(grdTestInfo.GetValue(TTestInfo.Columns.TestTypeId), -1)).GetDataSet().Tables(0)
                Dim dt As DataTable = SPs.SpGetRegListByBarcodeAndTestID(grdTestInfo.GetValue(TTestInfo.Columns.Barcode), _
                    Utility.Int32Dbnull(grdTestInfo.GetValue(TTestInfo.Columns.TestId), -1)).GetDataSet().Tables(0)
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
                        newRow(TResultDetail.Columns.TestTypeId) = grdTestInfo.GetValue(TTestInfo.Columns.TestTypeId)
                        newRow(TResultDetail.Columns.DataSequence) = dr(DDataControl.Columns.DataSequence)
                        newRow(TResultDetail.Columns.PrintData) = dr(DDataControl.Columns.DataPrint)
                        newRow(TResultDetail.Columns.MeasureUnit) = dr(DDataControl.Columns.MeasureUnit)
                        newRow(TResultDetail.Columns.NormalLevel) = dr(DDataControl.Columns.NormalLevel)
                        newRow(TResultDetail.Columns.NormalLevelW) = dr(DDataControl.Columns.NormalLevelW)
                        newRow(TResultDetail.Columns.TestDetailId) = -1
                        m_dtResultDetail.Rows.Add(newRow)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmd_InPhieu_XetNghiem_TongHop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_InPhieu_XetNghiem_TongHop.Click
        INPHIEU_XETNGHIEM_TONGHOP(reportType, False)
    End Sub

    Private Sub cmd_InPhieu_XetNghiem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_InPhieu_XetNghiem.Click
        INPHIEU_XETNGHIEM(reportType2, False)
    End Sub

    'thực hiện việc xóa thông tin của bản ghi đang chọn
    Private Sub cmdXoaCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXoaCheck.Click
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
                GridEX.Delete()
                grdResultDetail.UpdateData()
                grdResultDetail.Refresh()
            Next
            m_dtResultDetail.AcceptChanges()
        End If
        ModifyCommand()
    End Sub

    Private Sub grdTestInfo_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTestInfo.SizeChanged

    End Sub

    Private Sub grdPatients_ApplyingFilter(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdPatients.ApplyingFilter
        ModifyCommand()

    End Sub

  
    'hàm thực hiện in kết quả hàng loạt
    Private Sub cmdInHangLoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInHangLoat.Click
        'Dim reportType As Integer = intGetReportType()
        'gv_TestTypeDetailReport = intGetTestTypeID()
        If grdPatients.GetCheckedRows.Length <= 0 Then
            Utility.ShowMsg("Bạn phải thực hiện chọn bệnh nhân trên lưới rùi, thực hiện in phiếu xét nghiệm", "Thông báo", MessageBoxIcon.Warning)
            grdPatients.Focus()
            Return
        End If
        PrintAllPatient(reportType)
    End Sub
    Private Sub PrintAllPatient(ByVal vReportType As Integer)
        Try
            Dim DTPrint As New DataTable
            'Dim m_dtPrint As New DataTable
            Dim vTestTypeId As String = GetIdString(PreloadedLists.TestType, clbTestType, "TestType_ID")

            DTPrint = SPs.JclvGetTestResultForPrintV2FromDateToDate(-100, vTestTypeId, dtpTestDateFrom.Text, dtpTestDateTo.Text).GetDataSet().Tables(0)
            ProcessData(DTPrint)
            Dim m_dtResultDetail As DataTable
            Utility.ResetProgressBarJanus(ProgressBar1, grdPatients.GetCheckedRows.Length, True)
            For Each gridRow As Janus.Windows.GridEX.GridEXRow In grdPatients.GetCheckedRows
                Dim Patient_ID = Utility.Int32Dbnull(gridRow.Cells("Patient_ID").Value, -1)
                m_dtResultDetail = SPs.JclvGetTestResultForPrintV2FromDateToDate(Patient_ID, vTestTypeId, dtpTestDateFrom.Text, dtpTestDateTo.Text).GetDataSet().Tables(0)
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
            Utility.ResetProgressBarJanus(ProgressBar1, grdPatients.GetCheckedRows.Length, False)
            Dim crpt = New JCLV_crpt_DetailTestReport_ALLFromDateToDateAllPatient
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

            'Dim cls_Reg As New lablinkhelper.clsRegistry
            'cls_Reg.SaveReg(2, "DVC_COMPANY", "APP_DVC", "PRJBUSSINESS_PRINTTOPAGE", _
            '                 IIf(chkPrintDirecttoPage.Checked, 1, 0))
            DefaultNow(Me)
            'End If
        Catch ex As Exception

        End Try

    End Sub
    Public Sub ProcessData(ByRef DT As DataTable, ByRef _barcode As Mabry.Windows.Forms.Barcode.Barcode, ByRef All As Boolean)
        'Dim bc As BarcodeProfessional = New BarcodeProfessional
        ''We're going to use Code 128 Barcode Symbology
        'bc.Symbology = Symbology.Code128
        'bc.Text = ""
        'bc.QuietZoneWidth = 0
        'bc.ForeColor = Color.FromArgb(0, 116, 232)
        ''Now, generate and fill barcode images

        'We're going to encode the ID column
        Const JudgeH As String = "High"
        Const JudgeL As String = "Low"
        For Each dr As DataRow In DT.Rows

            '----------------------------------------
            'Thêm cột đánh giá (Judge) cho JCLV và Thái hà
            If IsNumeric(dr("Test_result")) Then
                If dr("Normal_Level").ToString.Contains("-") Then
                    Dim spl() As String = dr("Normal_Level").ToString.Split("-")
                    If IsNumeric(spl(0)) And IsNumeric(spl(1)) Then
                        dr("Hight") = spl(1)
                        dr("_Low1") = spl(0)
                        If CDbl(dr("Test_result")) < CDbl(dr("_Low1")) Then
                            dr("Note") = JudgeL
                        End If
                        If CDbl(dr("Test_result")) > CDbl(dr("Hight")) Then
                            dr("Note") = JudgeH
                        End If
                    Else
                        dr("Note") = " "
                    End If
                ElseIf dr("Normal_Level").ToString.Contains(">") OrElse dr("Normal_Level").ToString.Contains("<") Then
                    Dim spl() As String
                    If dr("Normal_Level").ToString.Contains(">") Then
                        spl = dr("Normal_Level").ToString.Split(">")
                        If IsNumeric(spl(1)) Then
                            dr("Hight") = spl(1)
                            dr("_Low1") = spl(1)
                            If CDbl(dr("Test_result")) <= CDbl(spl(1)) Then
                                dr("Note") = JudgeL
                            Else
                                dr("Note") = " "
                            End If
                        Else
                            dr("Note") = " "
                        End If

                    Else
                        spl = dr("Normal_Level").ToString.Split("<")
                        If IsNumeric(spl(1)) Then
                            dr("Hight") = spl(1)
                            dr("_Low1") = spl(1)
                            If CDbl(dr("Test_result")) >= CDbl(spl(1)) Then
                                dr("Note") = JudgeH
                            Else
                                dr("Note") = " "
                            End If
                        Else
                            dr("Note") = " "
                        End If
                    End If
                ElseIf dr("Normal_Level").ToString.Contains(">=") OrElse dr("Normal_Level").ToString.Contains("<=") Then
                    Dim spl() As String
                    If dr("Normal_Level").ToString.Contains(">=") Then
                        spl = dr("Normal_Level").ToString.Split(">=")
                        If IsNumeric(spl(1)) Then
                            dr("Hight") = spl(1)
                            dr("_Low1") = spl(1)
                            If CDbl(dr("Test_result")) < CDbl(spl(1)) Then
                                dr("Note") = JudgeL
                            Else
                                dr("Note") = " "
                            End If
                        Else
                            dr("Note") = " "
                        End If

                    Else
                        spl = dr("Normal_Level").ToString.Split("<=")
                        If IsNumeric(spl(1)) Then
                            dr("Hight") = spl(1)
                            dr("_Low1") = spl(1)
                            If CDbl(dr("Test_result")) > CDbl(spl(1)) Then
                                dr("Note") = JudgeH
                            Else
                                dr("Note") = " "
                            End If
                        Else
                            dr("Note") = " "
                        End If
                    End If
                ElseIf dr("Normal_Level").ToString.Contains("≤") OrElse dr("Normal_Level").ToString.Contains("≥") Then
                    Dim spl() As String
                    If dr("Normal_Level").ToString.Contains("≥") Then
                        spl = dr("Normal_Level").ToString.Split("≥")
                        If IsNumeric(spl(1)) Then
                            dr("Hight") = spl(1)
                            dr("_Low1") = spl(1)
                            If CDbl(dr("Test_result")) < CDbl(spl(1)) Then
                                dr("Note") = JudgeL
                            Else
                                dr("Note") = " "
                            End If
                        Else
                            dr("Note") = " "
                        End If

                    Else
                        spl = dr("Normal_Level").ToString.Split("≤")
                        If IsNumeric(spl(1)) Then
                            dr("Hight") = spl(1)
                            dr("_Low1") = spl(1)
                            If CDbl(dr("Test_result")) > CDbl(spl(1)) Then
                                dr("Note") = JudgeH
                            Else
                                dr("Note") = " "
                            End If
                        Else
                            dr("Note") = " "
                        End If
                    End If
                Else
                    If IsNumeric(dr("Normal_Level")) Then
                        If CDbl(dr("Test_result")) < CDbl(dr("Normal_Level")) Then
                            dr("Note") = JudgeL
                        Else
                            dr("Note") = JudgeH
                        End If
                    End If
                End If

            End If
            If dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("ÂM TÍNH") Or dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("(-)") Or dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("-") Then
                dr("Note") = " "
                dr("_Low1") = "Âm tính"
            End If
            If dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("DƯƠNG TÍNH") Or dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("(+)") Or dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("+") Then
                dr("Note") = " "
                dr("_Low1") = "Dương tính"
            End If

            Try
                _barcode.Data = CType(sDBnull(dr("Barcode"), "0000000000"), String)
                _barcode.Image().Save(Application.StartupPath & "\Temp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                dr("BarcodeImg") = bytGetImage(Application.StartupPath & "\Temp.jpg")
                dr("TESTTYPE_NAME") = dr("TESTTYPE_NAME").ToString.ToUpper
                dr("Description") = GetFieldValue("D_DATA_CONTROL", "Description", "Data_Name = N'" & dr("Para_Name") & "'")
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
    End Sub
    Public Function GetDataForPrint(ByRef DT As dsTestResultPrint.dtTestResultDataTable, _
                                  ByVal patientID As Integer, ByVal TesttypeID As String, _
                                  ByVal FromDate As Date, ByVal ToDate As Date) As Boolean
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter(cmd)
        Try
            With cmd
                .Connection = gv_oSqlCnn
                .CommandType = CommandType.StoredProcedure
                '.CommandText = "sp_GetTestResultForPrintFromDateToDate"
                .CommandText = "JCLV_GetTestResultForPrintV2FromDateToDate"
                ' .CommandText = "sp_GetTestResultForPrint"
                .Parameters.Add("@PatientID", SqlDbType.Int).Direction = ParameterDirection.Input
                .Parameters("@PatientID").Value = patientID

                .Parameters.Add("@TestTypeID", SqlDbType.Int).Direction = ParameterDirection.Input
                .Parameters("@TestTypeID").Value = TesttypeID

                .Parameters.Add("@Fromdate", SqlDbType.NVarChar).Direction = ParameterDirection.Input
                .Parameters("@Fromdate").Value = FromDate.ToString

                .Parameters.Add("@Todate", SqlDbType.NVarChar).Direction = ParameterDirection.Input
                .Parameters("@Todate").Value = ToDate.ToString
                .ExecuteNonQuery()
            End With
            da.Fill(DT)
            '' DT = SPs.JclvGetTestResultForPrintV2FromDateToDate(patientID, TesttypeID, FromDate, ToDate).GetDataSet().Tables(0)

            Return True
        Catch ex As Exception
            'DefaultNow(Me)
            MessageBox.Show("Lỗi khi lấy dữ liệu " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function
    Private Function arrGetTestDay(ByVal Patient_ID As Integer) As ArrayList
        Dim ReArr As New ArrayList
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter(cmd)
        Dim fv_DT As New DataTable
        Dim vTestTypeId As String = GetIdString(PreloadedLists.TestType, clbTestType, "TestType_ID")
        Try
            'With cmd
            '    .Connection = gv_oSqlCnn
            '    .CommandType = CommandType.StoredProcedure
            '    .CommandText = "spGetTestDayOfPatient"
            '    .Parameters.Add("@pTestDateFrom", SqlDbType.NVarChar).Direction = ParameterDirection.Input
            '    .Parameters("@pTestDateFrom").Value = dtpTestDateFrom.Value

            '    .Parameters.Add("@TestType_ID", SqlDbType.Int).Direction = ParameterDirection.Input
            '    .Parameters("@TestType_ID").Value = Utility.Int32Dbnull(cbo)
            '    .Parameters.Add("@Patient_ID", SqlDbType.Int).Direction = ParameterDirection.Input
            '    .Parameters("@Patient_ID").Value = Patient_ID

            '    .Parameters.Add("@pTestDateTo", SqlDbType.NVarChar).Direction = ParameterDirection.Input
            '    .Parameters("@pTestDateTo").Value = dtpTestDateTo.Value
            '    .ExecuteNonQuery()
            'End With
            'da.Fill(fv_DT)
            fv_DT = SPs.JclvSpGetTestDayOfPatient(dtpTestDateFrom.Text, dtpTestDateTo.Text, vTestTypeId, Patient_ID).GetDataSet().Tables(0)
            If fv_DT.Rows.Count > 0 Then
                For Each dr As DataRow In fv_DT.Rows
                    ReArr.Add(dr("TestType_ID") & "-" & dr("Test_Name") & ":" & dr("Test_date"))
                Next
            Else
            End If
            Return ReArr
        Catch ex As Exception
            Return ReArr
        End Try

    End Function
    Private Function GetDataForPrint1(ByRef DT As dsTestResult.TestResultDataTable, ByVal patientID As Integer, _
                                      ByVal TesttypeID As Integer, ByVal testdate As String, ByVal All As Boolean) _
       As Boolean
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter(cmd)
        Try
            With cmd
                .Connection = gv_oSqlCnn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sp_GetTestResultForPrintV2"
                .Parameters.Add("@PatientID", SqlDbType.Int).Direction = ParameterDirection.Input
                .Parameters("@PatientID").Value = patientID

                .Parameters.Add("@TestTypeID", SqlDbType.Int).Direction = ParameterDirection.Input
                .Parameters("@TestTypeID").Value = TesttypeID

                .Parameters.Add("@Test_date", SqlDbType.NVarChar).Direction = ParameterDirection.Input
                .Parameters("@Test_date").Value = testdate
                .ExecuteNonQuery()
            End With
            da.Fill(DT)
            'DT = SPs.SpGetTestResultForPrintV2(patientID, TesttypeID, testdate).GetDataSet().Tables(0)
            Return True
        Catch ex As Exception
            DefaultNow(Me)
            MessageBox.Show("Lỗi khi lấy dữ liệu " & ex.Message, "Thông báo", MessageBoxButtons.OK, _
                             MessageBoxIcon.Information)
            Return False
        End Try
    End Function
    Private Sub ProcessData(ByRef DT As DataTable)
       
        If Not DT.Columns.Contains("BarcodeImg") Then
            DT.Columns.Add("BarcodeImg", GetType(Byte()))
        End If
        If Not DT.Columns.Contains("sSex") Then
            DT.Columns.Add("sSex", GetType(String))
        End If
        'If DT.Rows.Count > 0 Then
        '    Barcode1.Data = CType(sDBnull(DT.Rows(0)("Barcode"), "0000000000"), String)
        '    Barcode1.Image().Save(Application.StartupPath & "\Temp.jpg", ImageFormat.Jpeg)
        '    DT.Rows(0)("BarcodeImg") = bytGetImage(Application.StartupPath & "\Temp.jpg")
        'End If

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
            'If IsNumeric(dr("Test_result")) Then
            '    If dr("Normal_Level").ToString.Contains("-") Then
            '        Dim spl() As String = dr("Normal_Level").ToString.Split("-")
            '        If IsNumeric(spl(0)) And IsNumeric(spl(1)) Then
            '            dr("Hight") = spl(1)
            '            dr("_Low") = spl(0)
            '        End If
            '    End If
            '    If CDbl(dr("Test_result")) < CDbl(dr("_Low")) Then
            '        dr("Note") = "Nhỏ"
            '    End If
            '    If CDbl(dr("Test_result")) > CDbl(dr("Hight")) Then
            '        dr("Note") = "Tăng"
            '    End If
            'End If
            'If dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("ÂM TÍNH") Or dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("(-)") Or dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("-") Then
            '    dr("_Low") = "Âm tính"
            'End If
            'If dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("DƯƠNG TÍNH") Or dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("(+)") Or dr("TEST_RESULT").ToString.Trim.ToUpper.Equals("+") Then
            '    dr("_Low") = "Dương tính"
            'End If
            If dr("sex") Then
                dr("Normal_Level") = dr("Normal_Level")
                dr("sSex") = "Nam"
            Else
                dr("Normal_Level") = dr("Normal_LevelW")
                dr("sSex") = "Nữ"
            End If
            'If All Then
            '    dr("title") = "PHIẾU TRẢ LỜI KẾT QUẢ XÉT NGHIỆM"
            'Else
            '    dr("title") = "PHIẾU TRẢ LỜI KẾT QUẢ XÉT NGHIỆM " & cboTestType.Text.ToUpper
            'End If
            'dr("Testdate") = sGetDay(dtpTestDate.Value)
        Next
        DT.AcceptChanges()
        ProcessNormalResult(DT)
    End Sub

    Private Sub chkHasResult_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHasResult.CheckedChanged
        For Each GridEX As Janus.Windows.GridEX.GridEXRow In grdPatients.GetDataRows
            If GridEX.RowType = RowType.Record Then
                GridEX.IsChecked = False
            End If
        Next
        For Each GridEX As Janus.Windows.GridEX.GridEXRow In grdPatients.GetDataRows
            If GridEX.RowType = RowType.Record Then
                If Utility.Int32Dbnull(GridEX.Cells("TestHasResult").Value, 0) >= 1 Then
                    GridEX.IsChecked = True
                End If
            End If
        Next
    End Sub

    Private Sub ChọnTấtCảToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChọnTấtCảToolStripMenuItem.Click
        For i As Integer = 0 To clbTestType.Items.Count - 1
            clbTestType.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub HủyChọnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HủyChọnToolStripMenuItem.Click
        For i As Integer = 0 To clbTestType.Items.Count - 1
            clbTestType.SetItemChecked(i, False)
        Next
    End Sub
End Class