Imports System.Data.SqlClient
Imports lablinkhelper
Imports VietBaIT.MultiLanguage

Public Class FrmDepartmentTestReport

    Dim mappingFile As String = My.Application.Info.DirectoryPath & IO.Path.DirectorySeparatorChar & "_ExcellColumnsMap.txt"
    Dim statusGrp As Graphics

    Private Function GetUnitId() As Integer
        Try
            Dim stemp As String = cboDonVi.Text
            Return CInt(stemp.Split("-")(0))
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Sub FrmDepartmentTestReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            statusGrp = ProgressBar2.CreateGraphics()
            dtmTo.Value = Now.Date
            dtmFrom.Value = dtmTo.Value.AddDays(-5)
            LoadData()
            dtmFrom.Focus()
            SetLanguage(gv_sLanguageDisplay, Me, "prjBussiness", gv_oSqlCnn)
        Catch ex As Exception
            SetLanguage(gv_sLanguageDisplay, Me, "prjBussiness", gv_oSqlCnn)
        End Try

    End Sub

    Private Sub LoadData()
        Dim sv_Da As New SqlDataAdapter("SELECT TESTTYPE_ID AS ID,TESTTYPE_NAME AS sName FROM T_TEST_TYPE_LIST ORDER BY TESTTYPE_NAME ASC", gv_oSqlCnn)
        Dim sv_Dt As New DataTable
        Try
            sv_Da.Fill(sv_Dt)
            If sv_Dt.Rows.Count > 1 Then
                cboTestType.Items.Add("Tất cả")
                For Each dr As DataRow In sv_Dt.Rows
                    cboTestType.Items.Add(dr("ID") & "-" & dr("SNAME"))
                Next
            Else
                If sv_Dt.Rows.Count = 1 Then
                    cboTestType.Items.Add(sv_Dt.Rows(0)("ID") & "-" & sv_Dt.Rows(0)("SNAME"))
                End If
            End If
            If cboTestType.Items.Count > 0 Then
                cboTestType.SelectedIndex = 0
            End If
        Catch ex As Exception
            ShowErrMsg(ex.Message)
        End Try
    End Sub

    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click
        'ProgressBar2.Style = ProgressBarStyle.Marquee
        If dtmFrom.Value > dtmTo.Value Then
            ShowMsg("Từ ngày phải nhỏ hơn hoặc bằng đến ngày")
            dtmFrom.Focus()
            Return
        End If

        Try
            'B1: Lấy dữ liệu
            UpdateStatus("Lấy kết quả")
            Dim dtRawResult As DataTable = SpGetTestResultByDepartment()
            'Lấy dữ liệu kết quả

            'Nếu không tìm thấy dòng nào hoặc có lỗi trong quá trình nhận dữ liệu
            If (dtRawResult Is Nothing) AndAlso (dtRawResult.Rows.Count = 0) Then Exit Sub

            'B2: Đảo ngược bảng
            UpdateStatus("Xử lý kết quả")
            'dtResult = PivotTable.GetInversedDataTable(dtResult, "Para_Name", "Patient_ID", "Test_Result", "", False)
            'Dim dtResult As DataTable = PivotTable.GetInversedDataTable(dtRawResult, "Para_Name", "Barcode", "Test_Result", "", False)
            Dim dtResult As DataTable = lablinkhelper.PivotTable.GetInversedDataTable(dtRawResult, "Para_Name", "Barcode", "Test_Result", "", False)

            'Nếu Có lỗi trong quá trình nghịch đảo bảng dữ liệu
            If (dtResult Is Nothing) AndAlso (dtResult.Rows.Count = 0) Then Exit Sub
            dtResult.Columns.Add("Patient_ID")
            dtResult.Columns.Add("Test_Date")
            For Each row As DataRow In dtResult.Rows
                row("Patient_ID") = dtRawResult.Select("Barcode = '" & row("Barcode") & "'")(0)("Patient_ID")
                row("Test_Date") = dtRawResult.Select("Barcode = '" & row("Barcode") & "'")(0)("Test_Date")
            Next

            'B3: Tạo danh sách mã bệnh nhân
            Dim sPid As String = ""
            For Each dr As DataRow In dtResult.Rows
                If sPid = "" Then
                    sPid = dr("Patient_ID").ToString()
                Else
                    sPid = sPid & "," & dr("Patient_ID").ToString()
                End If
            Next
            sPid = "(" & sPid & ")"

            'B4: Lấy bảng thông tin bệnh nhân
            UpdateStatus("Lấy thông tin bệnh nhân")
            Dim dtPatient As DataTable = GetPatients(sPid)
            If (dtPatient Is Nothing) AndAlso (dtPatient.Rows.Count = 0) Then Exit Sub

            'B5: Ghép các bảng tạo ra report cuối cùng
            UpdateStatus("Ghép dữ liệu bệnh nhân và kết quả")
            Dim dtReport As DataTable = MergeData(dtPatient, dtResult, "Patient_ID")
            If (dtReport Is Nothing) AndAlso (dtReport.Rows.Count = 0) Then Exit Sub

            'lablinkhelper.Utilities.WriteDataTableToFile(dtReport, "C:\PatientReport.txt")
            Dim lastPath As String = My.Application.Info.DirectoryPath & IO.Path.DirectorySeparatorChar & "_Last_ColumnsMap.txt"
            IO.File.WriteAllText(lastPath, "")
            For Each col As DataColumn In dtReport.Columns
                IO.File.AppendAllText(lastPath, col.ColumnName.Trim.ToUpper & "|" & vbCrLf)
            Next

            UpdateStatus("Chọn File để lưu")
            Dim saveFile As New SaveFileDialog
            saveFile.Filter = String.Format("Excell File (*.xls)|*.xls")
            If saveFile.ShowDialog = DialogResult.OK Then
                'Xóa File
                Dim strSaveFilename As String = saveFile.FileName
                Try
                    IO.File.Delete(strSaveFilename)
                Catch ex As Exception
                End Try
                ExportDataTableToExcelFile(dtReport, strSaveFilename, False)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub

    Private Function GetPatients(ByVal sPid As String) As DataTable
        Try
            Dim sqllPatient As String
            Dim uId As Integer = GetUnitId()
            If uId = -1 Then
                sqllPatient = "SELECT lpi.Patient_ID, " & vbCrLf _
                              & "       lpi.PID, " & vbCrLf _
                              & "       lpi.Patient_Name, " & vbCrLf _
                              & "       lpi.[Address], " & vbCrLf _
                              & "       lpi.Age, " & vbCrLf _
                              & "       (SELECT lot.sName FROM L_ObjectType lot WHERE lot.ID = lpi.ObjectType) AS ObjectType, " & vbCrLf _
                              & "       lpi.YEAR_BIRTH AS YearBirth, " & vbCrLf _
                              & "       lpi.Insurance_Num AS InsuranceNum, " & vbCrLf _
                              & "       (CASE lpi.Sex  WHEN 0 THEN N'Nữ' " & vbCrLf _
                              & "       WHEN 1 THEN 'Nam' " & vbCrLf _
                              & "       END)as Sex        " & vbCrLf _
                              & "FROM   L_PATIENT_INFO lpi " & vbCrLf _
                              & "WHERE  lpi.Patient_ID IN" & sPid
            Else
                sqllPatient = "SELECT lpi.Patient_ID, " & vbCrLf _
                              & "       lpi.PID, " & vbCrLf _
                              & "       lu.UnitName, " & vbCrLf _
                              & "       lpi.Patient_Name, " & vbCrLf _
                              & "       lpi.[Address], " & vbCrLf _
                              & "       lpi.Age, " & vbCrLf _
                              & "       lpi.DATE_OF_BIRTH AS DateOfBirth, " & vbCrLf _
                              & "       lpi.YEAR_BIRTH AS YearBirth, " & vbCrLf _
                              & "       lpi.Insurance_Num AS InsuranceNum, " & vbCrLf _
                              & "       (CASE lpi.Sex  WHEN 0 THEN N'Nữ' " & vbCrLf _
                              & "       WHEN 1 THEN 'Nam' " & vbCrLf _
                              & "       END)as Sex        " & vbCrLf _
                              & "FROM   L_PATIENT_INFO lpi " & vbCrLf _
                              & "       LEFT JOIN L_Unit lu " & vbCrLf _
                              & "            ON  lpi.DepartmentID = lu.ID " & vbCrLf _
                              & "WHERE  lpi.Patient_ID IN (3458, 3457) " & vbCrLf _
                              & "       AND lpi.DepartmentID = " & uId
            End If
            Dim sv_Da As New SqlDataAdapter(sqllPatient, gv_oSqlCnn)
            Dim dtPatient As New DataTable("Patient")
            sv_Da.Fill(dtPatient)
            Return dtPatient
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình lấy thông tin bệnh nhân", vbOK, "Thông báo lỗi")
            Return Nothing
        End Try
    End Function

    Private Function GetPIDs(ByVal sBarcodes As String) As DataTable
        Try
            Dim sqllPatient As String
            sqllPatient = "SELECT DISTINCT Patient_ID " & vbCrLf _
                & "FROM   T_TEST_INFO tti " & vbCrLf _
                & "WHERE  tti.Barcode IN" & sBarcodes

            Dim sv_Da As New SqlDataAdapter(sqllPatient, gv_oSqlCnn)
            Dim dtPatient As New DataTable("Patient")
            sv_Da.Fill(dtPatient)
            Return dtPatient
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình lấy thông tin bệnh nhân", vbOK, "Thông báo lỗi")
            Return Nothing
        End Try
    End Function

    Private Function SpGetTestResultByDepartment() As DataTable
        Try
            Dim testtypeid As Integer = 0
            If cboTestType.Text.Trim.ToUpper = "Tất cả".ToUpper Then
                testtypeid = -1
            Else
                If IsNumeric(cboTestType.Text.Split("-")(0)) Then
                    testtypeid = CInt(cboTestType.Text.Split("-")(0))
                End If
            End If
            Dim unitId As Integer = GetUnitId()

            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter(cmd)
            With cmd
                .Connection = gv_oSqlCnn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sp_GetTestResultByDepartment"
                .Parameters.Add("@pTestDateFrom", SqlDbType.DateTime).Direction = ParameterDirection.Input
                .Parameters("@pTestDateFrom").Value = dtmFrom.Value
                .Parameters.Add("@pTestDateTo", SqlDbType.DateTime).Direction = ParameterDirection.Input
                .Parameters("@pTestDateTo").Value = dtmTo.Value
                .Parameters.Add("@pTestType_ID", SqlDbType.Int).Direction = ParameterDirection.Input
                .Parameters("@pTestType_ID").Value = testtypeid
                .Parameters.Add("@DepartmentID", SqlDbType.Int).Direction = ParameterDirection.Input
                .Parameters("@DepartmentID").Value = unitId
            End With
            Dim dtTempResult As New DataTable
            da.Fill(dtTempResult)
            Return dtTempResult
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình lấy kết quả bệnh nhân theo điều kiện chọn", vbOKOnly, "Thông báo lỗi")
            Return Nothing
        End Try
    End Function

    Private Function MergeData(ByVal tblA As DataTable, ByVal tblB As DataTable, ByVal sKey As String) As DataTable
        Try
            Dim tbl As DataTable
            Dim row As DataRow
            Dim newRow As DataRow
            Dim dv As DataView

            tbl = New DataTable
            dv = tblB.DefaultView

            For Each sColumnName As DataColumn In tblA.Columns
                If Not tbl.Columns.Contains(sColumnName.ColumnName) Then
                    tbl.Columns.Add(New DataColumn(sColumnName.ColumnName, sColumnName.DataType))
                End If
            Next
            For Each sColumnName As DataColumn In tblB.Columns
                If Not tbl.Columns.Contains(sColumnName.ColumnName) Then
                    tbl.Columns.Add(New DataColumn(sColumnName.ColumnName, sColumnName.DataType))
                End If
            Next

            For Each row In tblA.Rows
                newRow = tbl.NewRow
                For Each sColumnName As DataColumn In tblA.Columns
                    newRow(sColumnName.ColumnName) = row(sColumnName.ColumnName)
                Next
                dv.RowFilter = (sKey & " = " & row(sKey).ToString)
                If dv.Count = 1 Then
                    For Each sColumnName As DataColumn In tblB.Columns
                        newRow(sColumnName.ColumnName) = dv(0).Item(sColumnName.ColumnName)
                    Next
                End If
                tbl.Rows.Add(newRow)
            Next
            Return tbl
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình ghép dữ liệu", vbOKOnly, "Thông báo lỗi")
            Return Nothing
        End Try

    End Function

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Close()
    End Sub

    'Private Sub btnDanhMucDonVi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDanhMucDonVi.Click
    '    Dim oForm As New frm_DanhMucDonVi
    '    oForm.ShowDialog()
    '    If Not oForm.mv_bCancel Then
    '        If Not oForm.ds Is Nothing Then
    '            FillcboDonVi()
    '        End If
    '    End If
    'End Sub

#Region "Excell Region"

    Private Function StartExcel(Optional ByVal IsVisible As Boolean = True) As Microsoft.Office.Interop.Excel.Application
        Try
            Dim objExcel As New Microsoft.Office.Interop.Excel.Application
            objExcel.Visible = IsVisible
            Return objExcel
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub ForceExcelToQuit(ByVal objExcel As Microsoft.Office.Interop.Excel.Application)
        Try
            objExcel.Quit()
        Catch ex As Exception
        End Try
    End Sub

    Private Function TryToGetInteger(ByVal str As String) As Integer
        Try
            Return CInt(str)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Function CreateMappingCollection() As Hashtable
        Try
            Dim hs As New Hashtable
            Dim strMap As String() = IO.File.ReadAllLines(mappingFile)
            Dim s As String

            For Each s In strMap
                Try
                    Dim key As String
                    Dim value As Integer
                    key = s.Split("|")(0)
                    value = TryToGetInteger(s.Split("|")(1))
                    If Not hs.Contains(key) Then
                        hs.Add(key, value)
                    End If
                Catch ex As Exception
                    Continue For
                End Try
            Next
            Return hs
        Catch ex As Exception
            MsgBox("Lỗi khi đọc file Map:" & ex.ToString(), vbOK, "Thông báo lỗi")
            Return Nothing
        End Try
    End Function

    Private Sub UpdateStatus(ByVal str As String)
        ProgressBar2.Refresh()
        statusGrp.DrawString("                                                                                                   ", New Font("Arial", CType(8.25, Single), FontStyle.Regular), Brushes.Black, New PointF(0, ProgressBar2.Height / 2 - 7))
        statusGrp.DrawString(str, New Font("Arial", CType(8.25, Single), FontStyle.Regular), Brushes.Black, New PointF(ProgressBar2.Width / 4, ProgressBar2.Height / 2 - 7))
    End Sub

    Private Sub DataTableToExcelSheet(ByVal dt As DataTable, ByVal objSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal nStartRow As Integer, ByVal nStartCol As Integer)
        Try
            Dim hs As Hashtable = CreateMappingCollection()

            'Nếu không đọc được file Map thì thoát khỏi chương trình
            If hs Is Nothing Then Exit Sub

            Dim nRow As Integer, nCol As Integer
            Dim percent As Integer
            ProgressBar1.Maximum = dt.Rows.Count
            Dim colIndex As Integer = -1
            'Dim chartRange As Microsoft.Office.Interop.Excel.Range

            objSheet.Range("A1", "K1").Merge()

            Dim FromString As String = dtmFrom.Value.ToString("dd/MM/yyyy")
            Dim ToString As String = dtmTo.Value.ToString("dd/MM/yyyy")
            If FromString <> ToString Then
                objSheet.Cells(1, 1) = "Kết quả xét nghiệm từ ngày " & FromString & " đến ngày " & ToString
            Else
                objSheet.Cells(1, 1) = "Kết quả xét nghiệm ngày " & FromString
            End If

            objSheet.Range("A1", "HB" + (dt.Rows.Count - 1 + nStartRow).ToString()).BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic)
            Dim nRow2 As Integer = 0
            For nRow = 0 To dt.Rows.Count - 1
                'Fill STT
                If dt.Rows(nRow)("Barcode").ToString() = "" Then Continue For
                nRow2 = nRow2 + 1
                objSheet.Cells(nStartRow + nRow2 - 1, 1) = nRow2
                For nCol = 0 To dt.Columns.Count - 1
                    colIndex = hs(dt.Columns(nCol).ColumnName.Trim.ToUpper())
                    If colIndex > 0 Then
                        Dim s As String = dt.Rows(nRow).Item(nCol).ToString()
                        If s.Trim() <> "" Then
                            objSheet.Cells(nStartRow + nRow2 - 1, colIndex) = s
                            'Else
                            '    objSheet.Cells(nStartRow + nRow, colIndex).Interior.Color = 16777164
                        End If
                    End If
                Next nCol
                ProgressBar1.Value = nRow + 1
                percent = CType((CType(ProgressBar1.Value, Double) / CType(ProgressBar1.Maximum, Double)) * 100, Integer)
                ProgressBar1.CreateGraphics().DrawString(percent.ToString() + "%", New Font("Arial", CType(8.25, Single), FontStyle.Regular), Brushes.Black, New PointF(ProgressBar1.Width / 2 - 10, ProgressBar1.Height / 2 - 7))
            Next nRow
            ProgressBar1.Value = 0
            objSheet.Range("A5", "HD" + (dt.Rows.Count - 1 + nStartRow).ToString()).Columns.AutoFit()
            MsgBox("Ghi dữ liệu vào file excell thành công", vbOKOnly, "Thông Báo")
        Catch ex As Exception
            MsgBox("Lỗi khi ghi dữ liệu vào file excell", vbOKOnly, "Thông báo lỗi")
        End Try
    End Sub

    Private Function ExportDataTableToExcelFile(ByVal dt As DataTable, ByVal strSaveFilename As String, ByVal blnIsVisible As Boolean) As Boolean

        'B6: Khởi động Excell
        UpdateStatus("Khởi động Excell")
        Dim objExcel As Object
        objExcel = StartExcel(blnIsVisible)

        If objExcel Is Nothing Then
            MsgBox("Không khởi động được Excell trên máy trạm." & vbCrLf & "Cài đặt Excell trước khi sử dụng chức năng", vbOKOnly, "Thông báo lỗi")
            Exit Function
        Else
            Dim objWorkbook As Microsoft.Office.Interop.Excel.Workbook
            Dim objSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim strFileName As String
            Const jclvReporttemplate As String = "_ExcellReportTemplate.xls"
            strFileName = My.Application.Info.DirectoryPath & IO.Path.DirectorySeparatorChar & jclvReporttemplate
            If Not IO.File.Exists(strFileName) Then
                MsgBox("Không tìm thấy file Template: '" & vbCrLf & strFileName & "'", vbOKOnly, "Thông báo lỗi")
                Return False
            Else
                Try
                    Try
                        objWorkbook = objExcel.Workbooks.Add(strFileName)
                    Catch ex As Exception
                        MsgBox("Không load được file: '" & vbCrLf & strFileName & "'" & vbCrLf & ex.ToString(), vbOKOnly, "Thông báo lỗi")
                        Return False
                    End Try

                    Try
                        objSheet = objWorkbook.Sheets("report")
                    Catch ex As Exception
                        MsgBox("Không tìm thấy Sheet : 'report'", vbOKOnly, "Thông báo lỗi")
                        Return False
                    End Try
                    'B7: Xuất dữ liệu
                    UpdateStatus("Đang xuất dữ liệu")
                    DataTableToExcelSheet(dt, objSheet, 7, 1)
                    If blnIsVisible = False Then
                        objWorkbook.SaveAs(strSaveFilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault)
                        objWorkbook.Close(False)
                        objExcel.Quit()
                    End If
                Catch ex As Exception
                    If blnIsVisible Then MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error populating workbook")
                    ForceExcelToQuit(objExcel)
                End Try
            End If
        End If

        '' The excel is created and opened for insert value. We most close this excel using this system
        ''Dim pro() As Process = Process.GetProcessesByName("EXCEL")
        ''For Each i As Process In pro
        ''    i.Kill()
        ''Next
        'Try
        '    objExcel.Quit()
        'Catch ex As Exception

        'End Try
        Return True
    End Function

#End Region

    Private Sub FrmDepartmentTestReport_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then Dispose(True)
    End Sub
End Class