Imports Janus.Windows.GridEX
Imports SubSonic
Imports VietBaIT.Lablink.Model
Imports VietBaIT.CommonLibrary


Public Class JCLV_frm_Lot_Test_Registration

#Region "Attributes"
    Private _tblDataConTrol As New DataTable
#End Region

#Region "Private Method"

    'Nạp toàn bộ lô
    Private Sub LoadcboLot()
        Dim dtLot As DataTable = ModBusinessHelper.GetAllLot()
        
        cboLot.DataSource = dtLot
        cboLot.DisplayMember = "ID"
        cboLot.ValueMember = "ID"
    End Sub

    'Nạp toàn danh sách các loại xét nghiệm
    Private Sub LoadTestTypeList()
        grdTestType.DataSource = GetAllTestTypeList()
    End Sub

    'Nạp toàn danh sách các mã điều khiển
    Private Sub LoadDataControl()
        Try
            'Dim sqlquery As SqlQuery
            'sqlquery = New [Select](String.Format("0 as [Check],{0}.*, (SELECT TOP 1 ddl.[TestType_ID] FROM [dbo].[D_DEVICE_LIST] ddl WHERE [ddl].[Device_ID] = {0}.[Device_ID]) AS TestType_id ", DDataControl.Schema.Name)).From(DDataControl.Schema.Name)
            _tblDataConTrol = ModBusinessHelper.GetTestListFromTestTypeId(-1)
            If Not _tblDataConTrol.Columns.Contains("Check") Then _tblDataConTrol.Columns.Add("Check", GetType(Boolean))
            For Each dr As DataRow In _tblDataConTrol.Rows
                dr("Check") = False
            Next
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình nạp mã điều khiển thiết bị:" + vbCrLf + ex.ToString(), vbOKOnly, "Thông báo")
        End Try
    End Sub

    'Private Sub LoadDeviceToCboDevice(ByVal paramTestTypeId As Integer)
    '    Dim dt As DataTable
    '    Dim sqlquery As SqlQuery
    '    sqlquery = New [Select]().From(DDeviceList.Schema.Name).Where(DDeviceList.Columns.DeviceControl).IsEqualTo(1).And(DDeviceList.Columns.TestTypeId).IsEqualTo(paramTestTypeId)
    '    dt = sqlquery.ExecuteDataSet().Tables(0)
    '    With cboDevices
    '        .DataSource = dt
    '        .DisplayMember = DDeviceList.Columns.DeviceName
    '        .ValueMember = DDeviceList.Columns.DeviceId
    '    End With
    'End Sub

    'Private Function InsertTestInfo(ByVal typeId As Integer, ByVal patientId As Integer, ByVal barcode As String) As Boolean
    '    Try
    '        Dim obj As New TTestInfo
    '        obj.Barcode = barcode
    '        obj.PatientId = patientId
    '        obj.TestTypeId = typeId
    '        Dim vDate As Date = lablinkhelper.Utilities.GetSysDate()
    '        obj.TestDate = vDate
    '        obj.RequireDate = vDate
    '        obj.AssignId = -1
    '        obj.DiagnosticianId = -1
    '        obj.TestStatus = 0
    '        obj.IsNew = True
    '        obj.Save()
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

#End Region

    Private Sub JCLV_frm_Lot_Test_Registration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Nạp toàn bộ lô
        LoadcboLot()

        'Nạp toàn bộ loại xét nghiệm
        LoadTestTypeList()

        'Nạp toàn danh sách các mã điều khiển
        LoadDataControl()
    End Sub

    Private Sub btnLoadPatientList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPatientList.Click
        Try
            Dim dt As DataTable
            Dim sqlquery As SqlQuery
            sqlquery = New [Select]("L_Patient_info.*,(SELECT TOP 1 [tti].[Barcode] FROM [dbo].[T_TEST_INFO] tti WHERE [tti].[Patient_ID] = [dbo].[L_PATIENT_INFO].[Patient_ID]) AS Barcode").From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.LotID).IsEqualTo(cboLot.Text).OrderAsc("Barcode")
            dt = sqlquery.ExecuteDataSet().Tables(0)
            grdPatientList.DataSource = dt
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình nạp dữ liệu bệnh nhân:" + vbCrLf + ex.ToString(), vbOKOnly, "Thông báo")
        End Try
    End Sub

    Private Sub grdTestType_CellValueChanged(ByVal sender As System.Object, ByVal e As ColumnActionEventArgs) Handles grdTestType.CellValueChanged
        grdTestType_SelectionChanged(sender, New EventArgs())
    End Sub

    Private Sub grdTestType_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTestType.SelectionChanged
        'If grdTestType.CurrentRow Is Nothing Then
        '    Exit Sub
        'End If
        'Dim index As Integer
        'index = IIf(grdTestType.CurrentRow.IsChecked, grdTestType.GetValue("TestType_ID"), -1)
        'cboDevices_SelectedValueChanged(sender, e)
        Try
            If grdTestType.CurrentRow Is Nothing Then Exit Sub
            grdTestDetail.DataSource = Nothing
            Dim index As Integer
            index = IIf(grdTestType.CurrentRow.IsChecked, grdTestType.GetValue("TestType_ID"), -1)
            If ModBusinessHelper.IsBiDirectionalTest(index) Then
                _tblDataConTrol.DefaultView.RowFilter = String.Format("TestType_ID = {0}", index)
                grdTestDetail.DataSource = _tblDataConTrol.DefaultView
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub cboDevices_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If _tblDataConTrol.Rows.Count > 0 Then
    '            _tblDataConTrol.DefaultView.RowFilter = String.Format("{0}={1}", DDataControl.Columns.DeviceId, VietBaIT.CommonLibrary.Utility.Int32Dbnull(cboDevices.SelectedValue, -1))
    '            grdTestDetail.DataSource = _tblDataConTrol.DefaultView
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Có lỗi trong quá trình nạp dữ liệu điều khiển:" + vbCrLf + ex.ToString(), vbOKOnly, "Thông báo")
    '    End Try
    'End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            prgbPatients.Value = 0
            prgbPatients.Visible = True
            prgbPatients.Minimum = 0
            prgbPatients.Maximum = grdPatientList.GetCheckedRows().Length

            'Nếu chưa chọn dòng nào thì thoát
            If prgbPatients.Maximum.Equals(0) Then
                MsgBox("Bạn chưa chọn bệnh nhân nào", vbOKOnly, "Thông báo")
                grdPatientList.Focus()
                Return
            End If

            If grdTestType.GetCheckedRows().Length.Equals(0) Then
                MsgBox("Bạn chưa chọn loại xét nghiệm nào", vbOKOnly, "Thông báo")
                grdTestType.Focus()
                Return
            End If

            Cursor = Cursors.WaitCursor
            'Duyệt theo các dòng được chọn
            For Each drPatient As GridEXRow In grdPatientList.GetCheckedRows()
                prgbPatients.Value = prgbPatients.Value + 1
                Dim patientId As Integer = Utility.Int32Dbnull(drPatient.Cells("Patient_ID").Value, -1)
                Dim barcode As String = Utility.sDbnull(drPatient.Cells("Barcode").Value)

                If String.IsNullOrEmpty(barcode) Or patientId.Equals(-1) Then Continue For

                'Xóa tất cả các đăng ký của bệnh nhân nếu chọn
                If cboDeleteAllOldReg.Checked Then
                    Dim sqlquery As SqlQuery
                    'Xóa bảng T_reglist
                    sqlquery = New Delete().From(TRegList.Schema).Where(TRegList.Columns.TestId).In(New [Select](TTestInfo.Columns.TestId).From(TTestInfo.Schema).Where(TTestInfo.Columns.PatientId).IsEqualTo(patientId))
                    sqlquery.Execute()
                    'Xóa bảng T_TestInfo
                    sqlquery = New Delete().From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.PatientId).IsEqualTo(patientId)
                    sqlquery.Execute()
                End If


                'Insert vào bảng T_TestInfo
                For Each drTest As GridEXRow In grdTestType.GetCheckedRows()
                    Dim testTypeId As Integer = drTest.Cells("TestType_ID").Value
                    Dim testDate As DateTime = drPatient.Cells("DateUpdate").Value
                    Dim testId As Integer
                    Dim sqlquery As SqlQuery
                    sqlquery = New [Select](TTestInfo.Columns.TestId).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.TestTypeId).IsEqualTo(testTypeId).And(TTestInfo.Columns.PatientId).IsEqualTo(patientId).And(TTestInfo.Columns.Barcode).IsEqualTo(barcode)
                    Dim tempTestId As Integer = Utility.Int32Dbnull(sqlquery.ExecuteScalar(), Integer.MinValue)

                    'Nếu tìm thấy thì không thêm mà gán trực tiếp
                    If tempTestId <> Integer.MinValue Then
                        testId = tempTestId
                    Else
                        'Insert dữ liệu vào T_TestInfo
                        ModBusinessHelper.InsertTestInfo(testTypeId, patientId, testDate, barcode)
                        'Get max test_id
                        testId = TTestInfo.CreateQuery().GetMax(TTestInfo.Columns.TestId)
                    End If

                    'Insert dữ liệu vào T_RegList
                    _tblDataConTrol.DefaultView.RowFilter = String.Format("({0}={1}) AND ({2}={3})", "Check", "1", "TestType_id", testTypeId.ToString())
                    For Each drTestDetail As DataRowView In _tblDataConTrol.DefaultView
                        'Dim sp As StoredProcedure
                        'sp = SPs.SpCreateRegList(testId, Convert.ToDecimal(drTestDetail("Device_ID")), barcode, drTestDetail("Alias_Name"), drTestDetail("Data_Name"), 1)
                        'sp.Execute()
                        UpdateRegTestList(testId, drTestDetail("TestData_ID"), 1)
                    Next
                Next
                drPatient.IsChecked = False
            Next
            MsgBox("Cập nhật đăng ký xét nghiệm thành công", vbOKOnly, "Thông báo")
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình cập nhật dữ liệu:" + vbCrLf + ex.ToString(), vbOKOnly, "Thông báo")
        Finally
            Cursor = Cursors.Default
            prgbPatients.Visible = False
            prgbPatients.Minimum = 0
            prgbPatients.Maximum = 0
        End Try
    End Sub

    Private Sub JCLV_frm_Lot_Test_Registration_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Dispose(True)
        End Select
    End Sub
End Class