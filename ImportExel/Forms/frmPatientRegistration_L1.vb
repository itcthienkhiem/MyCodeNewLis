Imports LIS.DAL
Imports DevComponents.DotNetBar.Controls
Imports System.Windows.Forms
Imports Janus.Windows.GridEX
Imports SubSonic
Imports VNS.Libs;

Public Class FrmPatientRegistration_L1

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

#End Region

#Region "Attributes"

    Public m_iAction As Integer
    Public mv_DR As DataRow
    Private barcodedigit As Integer
    Private autoGenerateBarcode As Integer
    Private dtPatientList As DataTable
    Public dtRegTest As DataTable
    Private dtDeviceList As DataTable
    Private dtTestTypeList As DataTable
    Private dtTestTypeandTRegList As DataTable
    Private dtBiDataControl As DataTable
    Private dtObjectType As DataTable
    Private dtDepartment As DataTable
    Private dtTestGroupList, dtTestGroupDetail As DataTable

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

#Region "Form Events handler"

    Private Sub grdPatientList_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) _
       Handles grdPatientList.SelectionChanged
        GetTestTypeAndTRegList()
        Barcode.Data = Utility.sDbnull(grdPatientList.GetValue("Barcode"), "")
    End Sub

    Private Sub FrmPatientRegistration_L1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            If IO.File.Exists(_sConfigFileName) Then
                _sortType = Utility.Int32Dbnull(IO.File.ReadAllLines(_sConfigFileName)(0), 0)
            Else
                IO.File.WriteAllText(_sConfigFileName, "0")
            End If

            autoGenerateBarcode = _
                New [Select]().From(SysSystemParameter.Schema.Name).Where(SysSystemParameter.Columns.SName). _
                    IsEqualTo("AUTOGENERATEBARCODE").ExecuteDataSet().Tables(0)(0)(SysSystemParameter.Columns.SValue)
            barcodedigit = _
                New [Select]().From(SysSystemParameter.Schema.Name).Where(SysSystemParameter.Columns.SName). _
                    IsEqualTo("BARCODEDIGIT").ExecuteDataSet().Tables(0)(0)(SysSystemParameter.Columns.SValue)

            'LoadBiDataControl()
            LoadTestTypeButton()
            FillGrpDatePicker()
            LoadBiDataControl()
            LoadDeviceList()
            LoadDepartmentList()
            LoadTestGroup()

            dtObjectType = New SubSonic.Select("*").From("L_ObjectType").ExecuteDataSet.Tables(0)

            cmdSearch.PerformClick()
            Const sFileName As String = "ConfigSplitterDistance.txt"
            If IO.File.Exists(sFileName) Then
                Dim sSplitterDistance As Integer
                sSplitterDistance = Utility.Int32Dbnull(System.IO.File.ReadAllLines(sFileName)(0), 215)
                SplitContainer1.SplitterDistance = sSplitterDistance
            Else
                IO.File.WriteAllText(sFileName, "215")
            End If


        Catch ex As Exception
            MessageBox.Show("Đề nghị kiểm tra lại đường mạng", "Thông báo")
            Me.Dispose()
        End Try

    End Sub

    Private Sub cboDate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
       Handles cboDate.SelectedIndexChanged
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

    Private Sub cmdExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdExit.Click
        Dispose(True)
    End Sub

    Private Sub grdTestTypeButton_ColumnButtonClick(ByVal sender As Object, ByVal e As ColumnActionEventArgs) Handles grdTestTypeButton.ColumnButtonClick
        Try
            If e.Column.Key = "TestType_Name" Then
                ProcessAddTest(grdTestTypeButton.GetValue("TestType_ID"), grdTestTypeButton.GetValue("TestType_Name"))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdRegList_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cmdRegList.Click
        Try
            If grdPatientList IsNot Nothing Then
                If IsBiDirectional(CInt(grdTestInfo.GetValue("TestType_ID"))) = 1 Then
                    LoadFrmRegList(CInt(grdTestInfo.GetValue("TestType_ID")), grdTestInfo.GetValue("TestType_Name"), grdTestInfo.GetValue("Test_ID"))
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdTestInfo_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles grdTestInfo.DoubleClick
        cmdRegList.PerformClick()
    End Sub

    Private Sub grdTestInfo_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles grdTestInfo.SelectionChanged
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

            If HasResult(testId) Then
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
            dtTestTypeandTRegList.AcceptChanges()

            If dtTestTypeandTRegList.Rows.Count <= 0 Then
                grdPatientList.CurrentRow.Cells(TTestInfo.Columns.Barcode).Value = String.Empty
                'grdPatientList.UpdateData()
            End If

            SetWarningStatus(New WarningBoxStatus("Xóa thành công !", True))

        Catch ex As Exception

            MessageBox.Show("Có lỗi trong quá trình xóa !", "Thông báo")
        End Try

    End Sub

    Private Sub cmdAddPatient_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cmdAddPatient.Click

        LoadFormPatientInfo(action.Insert)

    End Sub

    Private Sub cmdUpdatePatient_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cmdUpdatePatient.Click
        LoadFormPatientInfo(action.Update)
    End Sub

    Private Sub grdPatientList_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
        Handles grdPatientList.DoubleClick
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
                    cmdExit.PerformClick()
                Case Keys.F1
                    If dtTestTypeList.Rows.Count > 0 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(0).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(0).Cells("TestType_Name").Value)
                    End If
                Case Keys.F2
                    If dtTestTypeList.Rows.Count > 1 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(1).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(1).Cells("TestType_Name").Value)
                    End If
                Case Keys.F3
                    If dtTestTypeList.Rows.Count > 2 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(2).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(2).Cells("TestType_Name").Value)
                    End If
                Case Keys.F4
                    If dtTestTypeList.Rows.Count > 3 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(3).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(3).Cells("TestType_Name").Value)
                    End If
                Case Keys.F5
                    If dtTestTypeList.Rows.Count > 4 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(4).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(4).Cells("TestType_Name").Value)
                    End If
                Case Keys.F6
                    If dtTestTypeList.Rows.Count > 5 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(5).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(5).Cells("TestType_Name").Value)
                    End If
                Case Keys.F7
                    If dtTestTypeList.Rows.Count > 6 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(6).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(6).Cells("TestType_Name").Value)
                    End If
                Case Keys.F8
                    If dtTestTypeList.Rows.Count > 7 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(7).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(7).Cells("TestType_Name").Value)
                    End If
                Case Keys.F9
                    If dtTestTypeList.Rows.Count > 8 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(8).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(8).Cells("TestType_Name").Value)
                    End If
                Case Keys.F10
                    If dtTestTypeList.Rows.Count > 9 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(9).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(9).Cells("TestType_Name").Value)
                    End If
                Case Keys.F11
                    If dtTestTypeList.Rows.Count > 10 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(10).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(10).Cells("TestType_Name").Value)
                    End If
                Case Keys.F12
                    If dtTestTypeList.Rows.Count > 11 Then
                        ProcessAddTest(grdTestTypeButton.GetRows(11).Cells("TestType_ID").Value, _
                                        grdTestTypeButton.GetRows(11).Cells("TestType_Name").Value)
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
        SearchPatient()
        DisplaySearchInfo()
    End Sub

    Private Sub cmdInPhieuXN_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdInPhieuXN.Click
        'Dim frm As New frm_JCLV_InPhieuYeuCau_XETNGHIEM()
        'frm.p_Patient_ID = Utility.Int32Dbnull(grdPatientList.GetValue("Patient_ID"), -1)
        'frm.ShowDialog()
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
                PrintBarcode.PrintBarCode(bInfo)
            End If
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình in barcode xét nghiệm:" + vbCrLf + ex.ToString(), vbOKOnly, "Thông báo")
        End Try
    End Sub

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

    Private Sub SetWarningStatus(ByVal status As WarningBoxStatus)
        lablinkhelper.Utilities.SetControlProperty(Warningmesage, "Text", status.DisplayText)
        If Not status.BlinkStatus Then
            Warningmesage.ColorScheme = eWarningBoxColorScheme.[Default]
        End If
        WarningBoxTimer.Enabled = status.BlinkStatus
    End Sub

    Private Sub DisplaySearchInfo()
        Try
            If dtPatientList IsNot Nothing Then
                If dtPatientList.Rows.Count = 0 Then
                    SetWarningStatus(New WarningBoxStatus("Không có kết bệnh nhân nào", True))
                Else
                    SetWarningStatus(New WarningBoxStatus(String.Format("Tìm thấy <b> {0} </b> Bệnh nhân", dtPatientList.Rows.Count), False))
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SearchPatient()
        Try
            dtPatientList = SPs.SpGetPatientListByDate(dtpFromDate.Value, dtpTodate.Value).GetDataSet().Tables(0)
            If dtPatientList.Rows.Count <= 0 Then
                dtPatientList.Clear()
                Barcode2.Data = "0000000000"
            End If
            grdPatientList.DataSource = dtPatientList
            grdPatientList.Focus()
            ModifyCommand()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetTestTypeAndTRegList()
        Try
            If grdPatientList.CurrentRow IsNot Nothing Then
                Dim v_PatientId As Integer = Utility.Int32Dbnull(grdPatientList.CurrentRow.Cells("Patient_ID").Value, -1)
                dtTestTypeandTRegList = SPs.SpGetTestTypeandTReglist(v_PatientId, dtpFromDate.Value, dtpTodate.Value).GetDataSet().Tables(0)
                grdTestInfo.DataSource = dtTestTypeandTRegList
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadTestTypeButton()

        dtTestTypeList = New [Select]("*").From(TTestTypeList.Schema.Name).ExecuteDataSet().Tables(0)
        Dim idx As Integer = 0

        dtTestTypeList.Columns.Add("Short_Key")
        dtTestTypeList.Columns.Add("Device_Control")

        For Each dr As DataRow In dtTestTypeList.Rows
            idx += 1
            dr("Short_Key") = "F" & idx
            dr("Device_Control") = IsBiDirectional(CInt(dr("TestType_ID")))
        Next
        grdTestTypeButton.DataSource = dtTestTypeList

        dtTestTypeList.AcceptChanges()

    End Sub

    Private Sub LoadTestGroup()
        dtTestGroupList = New SubSonic.Select().From(TTestgroupList.Schema.Name).ExecuteDataSet.Tables(0)
        dtTestGroupDetail = New SubSonic.Select(TTestgroupDtl.Schema.Name & ".*", DDataControl.Columns.AliasName, DDataControl.Columns.DeviceId).From(TTestgroupDtl.Schema.Name).InnerJoin(DDataControl.DataControlIdColumn, TTestgroupDtl.DataControlIdColumn).ExecuteDataSet.Tables(0)
    End Sub

    Private Sub LoadDepartmentList()
        dtDepartment = New SubSonic.Select("*").From(LDepartment.Schema.Name).ExecuteDataSet.Tables(0)
        Dim dr As DataRow = dtDepartment.NewRow()
        dr(LDepartment.Columns.SName) = "----- Chọn -----"
        dr(LDepartment.Columns.Id) = -1

        dtDepartment.Rows.InsertAt(dr, 0)
    End Sub

    Private Sub LoadBiDataControl()
        'Sắp xếp theo tên nếu có setup
        'Nếu SortType = 1 thì sắp xếp theo ABC
        If _sortType = 1 Then
            dtBiDataControl = New [Select](DDataControl.Schema.Name & ".*", DDeviceList.Columns.TestTypeId).From(DDataControl.Schema.Name).InnerJoin(DDeviceList.DeviceIdColumn, DDataControl.DeviceIdColumn).Where(DDeviceList.Columns.Valid).IsEqualTo(1).And(DDeviceList.Columns.DeviceControl).IsEqualTo(1).OrderAsc(DDataControl.Columns.DataName).ExecuteDataSet().Tables(0)
        Else
            dtBiDataControl = New [Select](DDataControl.Schema.Name & ".*", DDeviceList.Columns.TestTypeId).From(DDataControl.Schema.Name).InnerJoin(DDeviceList.DeviceIdColumn, DDataControl.DeviceIdColumn).Where(DDeviceList.Columns.Valid).IsEqualTo(1).And(DDeviceList.Columns.DeviceControl).IsEqualTo(1).OrderAsc(DDataControl.Columns.DataSequence).ExecuteDataSet().Tables(0)
        End If


    End Sub

    Private Sub LoadDeviceList()
        dtDeviceList = _
            New [Select]().From(DDeviceList.Schema.Name).Where(DDeviceList.Columns.Valid).IsEqualTo(1). _
                ExecuteDataSet().Tables(0)

    End Sub

    Private Sub LoadFormPatientInfo(ByVal vAction As action)

        Try
            If vAction = action.Insert Or dtPatientList.Rows.Count > 0 Then
                Dim oForm As New frmNewPatientReg
                oForm.m_iAction = vAction
                If vAction <> action.Insert Then
                    oForm.mv_DR = dtPatientList.Rows(grdPatientList.CurrentRow.RowIndex)
                End If
                oForm.mv_ParentTable = dtPatientList
                oForm.grdList = grdPatientList
                oForm.dtDepartment = dtDepartment
                oForm.dtObjectType = dtObjectType
                oForm.ShowDialog()
                'dtPatientList.AcceptChanges()
                ModifyCommand()
            End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ProcessAddTest(ByVal testTypeId As Integer, ByVal testTypeName As String)
        Try
            If grdPatientList.CurrentRow Is Nothing Or grdTestTypeButton.CurrentRow Is Nothing Then
                Return
            End If

            Dim barcode As String = String.Empty
            Dim intOrder As String = ""

            If barcodedigit = 12 Then
                intOrder = Strings.Right("00" & dtTestTypeList.Select(TTestTypeList.Columns.TestTypeId & "=" & testTypeId)(0)(TTestTypeList.Columns.IntOrder).ToString, 2)
            End If

            'If grdTestInfo.RowCount > 0 Then
            '    barcode = GetBarcode4TestType(testTypeId, intOrder)
            '    If barcode = "-1" Then
            '        SetWarningStatus(New WarningBoxStatus("Test đã được đăng ký", True))
            '    End If
            'Else

            If autoGenerateBarcode = 0 Then
                Dim frm As New frmInputBarcode
                frm.barcodeDigit = barcodedigit
                frm.intOrder = intOrder
                frm.ShowDialog()
                barcode = frm.txtBarcode.Text()
                If barcode = String.Empty Then
                    SetWarningStatus(New WarningBoxStatus("Barcode chưa được nhập. Thưc hiện lại !", True))
                    Exit Sub
                End If

            Else
                'Lấy về Barcode đăng ký

                If VietBaIT.LABLink.LoadEnvironments.SysPara.UseOneBarcodeForPatient Then
                    If dtTestTypeandTRegList.Select("TestType_id=" & testTypeId).Any() Then
                        SetWarningStatus(New WarningBoxStatus("Test đã được đăng ký !", True))
                        barcode = String.Empty
                    Else
                        barcode = Utility.sDbnull(grdPatientList.GetValue("Barcode"), "")
                        If barcode = "" Then
                            barcode = GetBarcode(grdPatientList.GetValue(LPatientInfo.Columns.PatientId), testTypeId, intOrder)
                        End If
                    End If
                Else
                    barcode = GetBarcode(grdPatientList.GetValue(LPatientInfo.Columns.PatientId), testTypeId, intOrder)
                End If

                If barcode = "-1" Then
                    SetWarningStatus(New WarningBoxStatus("Test đã được đăng ký !", True))
                    barcode = String.Empty
                End If
            End If

            If barcode <> String.Empty Then
                Dim patientId As Integer = Convert.ToInt32((grdPatientList.CurrentRow.Cells("Patient_ID")).Value)
                If Not InsertTestInfo(testTypeId, patientId, barcode) Then Exit Sub
                Dim dr As DataRow = dtTestTypeandTRegList.NewRow()
                dr("Barcode") = barcode
                dr("TestType_ID") = testTypeId
                dr("TestType_Name") = testTypeName
                dr("Patient_ID") = patientId

                dr("Test_ID") = TTestInfo.CreateQuery().GetMax(TTestInfo.Columns.TestId)

                dtTestTypeandTRegList.Rows.Add(dr)

                grdPatientList.CurrentRow.Cells("Barcode").Value = barcode
                'grdPatientList.UpdateData()
            End If
            If IsBiDirectional(testTypeId) Then
                LoadFrmRegList(testTypeId, testTypeName, GetTestId(testTypeId))
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadFrmRegList(ByVal testType_ID As Integer, ByVal testType_Name As String, ByVal testId As Integer)
        Try
            Dim frm As New frmBiDataControlSelection
            frm.dtBiDataControl = dtBiDataControl
            frm.txtBarcode.Text = grdTestInfo.GetValue("Barcode")
            frm.txtPatientName.Text = grdPatientList.GetValue("Patient_Name")
            frm.txtAge.Text = Utility.sDbnull(grdPatientList.GetValue("Age"))
            frm.testId = testId
            frm.testypeId = testType_ID
            frm.UiGroupBox1.Text = testType_Name
            frm.dtTestTypeandTRegList = dtTestTypeandTRegList
            frm.arrDeviceList = dtDeviceList.Select(DDeviceList.Columns.TestTypeId & "=" & testType_ID)
            frm.dtTestGroupList = dtTestGroupList
            frm.dtTestGroupDetail = dtTestGroupDetail
            frm.sortType = _sortType
            frm.ShowDialog()
            _sortType = frm.sortType
            IO.File.WriteAllText(_sConfigFileName, _sortType)
            LoadBiDataControl()
            GetTestTypeAndTRegList()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ModifyCommand()
        Try
            cmdDelelePatient.Enabled = grdPatientList.CurrentRow IsNot Nothing

            If grdTestInfo.CurrentRow IsNot Nothing Then
                If IsBiDirectional(grdTestInfo.GetValue("TestType_ID")) = 1 Then
                    cmdRegList.Enabled = True
                Else
                    cmdRegList.Enabled = False
                End If
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

    Private Function DeleteSubsonic(ByVal sTableName As TableSchema.Table, ByVal sFieldName As String, ByVal sValue As Integer) As Boolean
        Try
            Dim vQuery As Query = New Query(sTableName).WHERE(sFieldName, sValue)
            vQuery.QueryType = QueryType.Delete
            vQuery.Execute()
            Return True
        Catch ex As Exception
            MessageBox.Show("Có lỗi trong quá trình xóa", "Thông báo")
            Return False
        End Try

    End Function

    Private Function HasResult(ByVal testId As String) As Boolean
        Try

            Dim _
                dt As DataTable = _
                    New [Select]().From(TResultDetail.Schema.Name).Where(TResultDetail.Columns.TestId).IsEqualTo( _
                                                                                                                    testId) _
                    .ExecuteDataSet().Tables(0)
            Return dt.Rows.Count > 0
        Catch ex As Exception
            Return True
        End Try


    End Function

    Private Function IsBiDirectional(ByVal testTypeId As Integer) As Integer
        Try
            If dtBiDataControl.Select("TestType_ID=" & testTypeId).GetLength(0) > 0 Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception

        End Try

    End Function

    Private Function GetBarcode(ByVal patientId As Integer, ByVal testTypeId As Integer, ByVal intOrder As String) As String
        Try
            Dim vBarcode As String
            Dim regDate As DateTime
            regDate = Convert.ToDateTime(grdPatientList.GetValue("DateUpdate"))

            'Xử lý thêm cho JCLV (Nếu biến USEREGDATETOGENERATEBARCODE = 1 thì sử dụng ngày đăng ký để tạo barcode)
            If VietBaIT.LABLink.LoadEnvironments.SysPara.UseRegDateToGenerateBarcode = 1 Then
                vBarcode = Convert.ToString(SPs.SpGetMaxBarcodeV2(testTypeId, patientId, VietBaIT.Lablink.LoadEnvironments.SysPara.AllowSameTestTypeInDay, regDate.ToString("yyMMdd")).GetDataSet().Tables(0)(0)(0))
            Else
                vBarcode = Convert.ToString(SPs.SpGetMaxBarcodeV2(testTypeId, patientId, VietBaIT.Lablink.LoadEnvironments.SysPara.AllowSameTestTypeInDay, "").GetDataSet().Tables(0)(0)(0))
            End If

            'Dim vBarcode As String = Convert.ToString(SPs.SpGetMaxBarcodeV2(testTypeId, patientId, 0, Utility.sDbnull(grdPatientList.GetValue("Barcode").ToString().Substring(0, 6), "")).GetDataSet().Tables(0)(0)(0))
            If vBarcode <> "-1" Then
                vBarcode = (Convert.ToInt64(vBarcode) + 1).ToString()
            End If

            If vBarcode.Length = 12 Then
                vBarcode = vBarcode.Remove(6, 2)
            End If
            If barcodedigit = 12 Then
                vBarcode = vBarcode.Insert(6, intOrder)
            End If
            Barcode.Data = vBarcode
            Return vBarcode
        Catch ex As Exception
            Return "-1"
        End Try

    End Function

    Private Function InsertTestInfo(ByVal typeId As Integer, ByVal patientId As Integer, ByVal barcode As String) As Boolean
        Try
            'dim count as integer = new subsonic.Select().From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.TestTypeId).IsEqualTo(typeId).And(TTestInfo.Columns.PatientId).IsEqualTo(patientId)


            Dim obj As New TTestInfo
            obj.Barcode = barcode
            obj.PatientId = patientId
            obj.TestTypeId = typeId
            Dim vDate As Date = lablinkhelper.Utilities.GetSysDate()
            obj.TestDate = vDate
            obj.RequireDate = vDate
            obj.AssignId = -1
            obj.DiagnosticianId = -1
            obj.TestStatus = 0
            obj.UpdateDate = DateTime.Now
            obj.UpdateUser = LabLink.globalModule.gv_sUID
            obj.IsNew = True
            obj.Save()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function GetTestId(ByVal testTypeId As Integer) As Integer
        Try
            For Each dr As DataRow In dtTestTypeandTRegList.Rows
                If Utility.Int32Dbnull(dr("TestType_ID"), -1) = testTypeId Then
                    Return dr("Test_ID")
                End If
            Next
            Return -1
        Catch ex As Exception

        End Try

    End Function

#End Region

    
    Private Sub InBarcodeHàngLoạtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InBarcodeHàngLoạtToolStripMenuItem.Click
        Dim grdrow() As Janus.Windows.GridEX.GridEXRow = grdPatientList.GetCheckedRows()
        'Dim f As New FrmInBarCodeHangLoat
        'f.grdrow = grdrow
        'f.ShowDialog(Me)

    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click, ToolStripMenuItem3.Click, ToolStripMenuItem4.Click, ToolStripMenuItem5.Click, ToolStripMenuItem6.Click
        Dim obj As System.Windows.Forms.ToolStripMenuItem = sender
        PrintMultiBarcode(Convert.ToInt32(obj.Text) / 2)
    End Sub

    Private Sub PrintMultiBarcode(ByVal numberOfCopies As Integer)
        Try

            Dim grdrow() As GridEXRow = grdPatientList.GetCheckedRows()
            For Each row As GridEXRow In grdrow
                Dim bInfo As New VietBaIT.BarCode.BarcodeInfo
                bInfo.BarcodeData = Utility.sDbnull(row.Cells("barcode").Value, "")
                bInfo.PatientName = Utility.sDbnull(row.Cells(LPatientInfo.Columns.PatientName).Value, "")
                bInfo.InsuranceNum = Utility.sDbnull(row.Cells("Insurance_Num").Value, "")
                'Utility.sDbnull(grdPatientList.GetValue("Insurance_Num"), "")
                Dim YearOfBirth As String
                Dim DOB As String
                YearOfBirth = Utility.sDbnull(row.Cells("Year_Birth").Value, "")
                If String.IsNullOrEmpty(Utility.sDbnull(grdPatientList.GetValue(LPatientInfo.Columns.Dob), "")) Then
                    DOB = YearOfBirth
                Else
                    DOB = Utility.GetFormatDateTime(Convert.ToDateTime(Utility.sDbnull(row.Cells("DOB").Value, "")), "dd/MM/yyyy")
                End If
                bInfo.Dob = DOB
                bInfo.Sex = Utility.Int32Dbnull(row.Cells("Sex_id").Value, -1)
                bInfo.DisplayData = True
                bInfo.NumberOfCopies = numberOfCopies

                Dim PrintBarcode As VietBaIT.BarCode.PrintBarcode = New VietBaIT.BarCode.PrintBarcode
                PrintBarcode.PrintBarCode(bInfo)
            Next


        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình in barcode xét nghiệm:" + vbCrLf + ex.ToString(), vbOKOnly, "Thông báo")
        End Try
    End Sub
    
End Class