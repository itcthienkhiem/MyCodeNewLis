Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports lablinkhelper
Imports VietBaIT.MultiLanguage

Public Class JCLV_frm_DepartmentTestReport

    Dim mappingFile As String = My.Application.Info.DirectoryPath & IO.Path.DirectorySeparatorChar & "JCLV_ColumnsMap.txt"
    Dim statusGrp As Graphics
    
    Private Sub FillDonVi()
        Dim sql As String
        sql = "SELECT * FROM L_Department"

        Dim sv_Da As New SqlDataAdapter(sql, gv_oSqlCnn)
        Dim sv_Dt As New DataTable
        Try
            sv_Da.Fill(sv_Dt)
            VietBaIT.CommonLibrary.DataBinding.BindDataCombox(cboDonVi, sv_Dt, "ID", "sName", "--- Chọn ---")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub JCLV_frm_DepartmentTestReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            statusGrp = ProgressBar2.CreateGraphics()
            FillDonVi()
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

            'B1.1 xử lý giá trị trung bình
            ProcessNormalResult(dtRawResult)

            'B2: Đảo ngược bảng
            UpdateStatus("Xử lý kết quả")
            'dtResult = PivotTable.GetInversedDataTable(dtResult, "Para_Name", "Patient_ID", "Test_Result", "", False)
            Dim dtResult As DataTable = GetInversedDataTable(dtRawResult, "Para_Name", "Barcode", "Test_Result", "", False)

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
            Dim lastPath As String = My.Application.Info.DirectoryPath & IO.Path.DirectorySeparatorChar & "_Last_JCLV_ColumnsMap.txt"
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
            Dim uId As Integer = cboDonVi.SelectedValue
            If uId = -1 Then
                sqllPatient = "SELECT lpi.Patient_ID, " & vbCrLf _
                    & "       lpi.PID, " & vbCrLf _
                    & "       ld.sName as UnitName, " & vbCrLf _
                    & "       lpi.Patient_Name, " & vbCrLf _
                    & "       lpi.[Address], " & vbCrLf _
                    & "       YEAR(GETDATE())- lpi.YEAR_BIRTH as AGE, " & vbCrLf _
                    & "       lpi.DOB AS DateOfBirth, " & vbCrLf _
                    & "       lpi.YEAR_BIRTH AS YearBirth, " & vbCrLf _
                    & "       lpi.Insurance_Num AS InsuranceNum, " & vbCrLf _
                    & "       CONVERT([nvarchar],lpi.DateUpdate,103) AS DateUpdate, " & vbCrLf _
                    & "       (CASE lpi.Sex WHEN 0 THEN N'Nữ' WHEN 1 THEN 'Nam' END) AS Sex " & vbCrLf _
                    & "FROM   L_PATIENT_INFO lpi " & vbCrLf _
                    & "       LEFT JOIN L_Department ld " & vbCrLf _
                    & "            ON  lpi.DepartmentID = ld.ID" & vbCrLf _
                    & "WHERE  lpi.Patient_ID IN" & sPid

            Else
                sqllPatient = "SELECT lpi.Patient_ID, " & vbCrLf _
                    & "       lpi.PID, " & vbCrLf _
                    & "       ld.sName as UnitName, " & vbCrLf _
                    & "       lpi.Patient_Name, " & vbCrLf _
                    & "       lpi.[Address], " & vbCrLf _
                    & "       YEAR(GETDATE())- lpi.YEAR_BIRTH as AGE, " & vbCrLf _
                    & "       lpi.DOB AS DateOfBirth, " & vbCrLf _
                    & "       lpi.YEAR_BIRTH AS YearBirth, " & vbCrLf _
                    & "       lpi.Insurance_Num AS InsuranceNum, " & vbCrLf _
                    & "       CONVERT([nvarchar],lpi.DateUpdate,103) AS DateUpdate, " & vbCrLf _
                    & "       (CASE lpi.Sex WHEN 0 THEN N'Nữ' WHEN 1 THEN 'Nam' END) AS Sex " & vbCrLf _
                    & "FROM   L_PATIENT_INFO lpi " & vbCrLf _
                    & "       LEFT JOIN L_Department ld " & vbCrLf _
                    & "            ON  lpi.DepartmentID = ld.ID" & vbCrLf _
                    & "WHERE  lpi.Patient_ID IN" & sPid & vbCrLf _
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
            Dim unitId As Integer = cboDonVi.SelectedValue

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
                    If sColumnName.ColumnName = "DateOfBirth" Then
                        tbl.Columns.Add(New DataColumn(sColumnName.ColumnName, GetType(String)))
                    Else
                        tbl.Columns.Add(New DataColumn(sColumnName.ColumnName, sColumnName.DataType))
                    End If

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

            For Each dr As DataRow In tbl.Rows
                If dr("DateOfBirth").ToString() <> "" Then
                    dr("DateOfBirth") = Convert.ToDateTime(dr("DateOfBirth")).ToString("dd/MM/yyyy")
                End If
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

    Private Sub btnDanhMucDonVi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDanhMucDonVi.Click
        Dim oForm As New frm_Department
        oForm.ShowDialog()
        If Not oForm.mv_bCancel Then
            If Not oForm.ds Is Nothing Then
                FillDonVi()
            End If
        End If
    End Sub

    Private Sub ProcessNormalResult(ByRef dt As DataTable)
        Try
            Dim min, max As Double
            Dim normal As String
            Dim normalLevel As String = "Normal_Level"
            Const low As String = "L"
            Const hight As String = "H"
            Const binhthuong As String = "Note"
            Const testResult As String = "Test_result"
            Dim arrResultWithLetters As New ArrayList
            arrResultWithLetters.Add("NE")
            arrResultWithLetters.Add("POS")

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
                    If String.IsNullOrEmpty(rawResult) Or String.IsNullOrEmpty(normal) Or (rawResult.ToString().Trim().ToUpper() = normal.ToUpper()) Then
                        dr(binhthuong) = ""
                        Continue For
                    ElseIf normal.ToUpper().StartsWith("NEG") Or normal.ToUpper().StartsWith("Âm") Or normal.ToUpper().StartsWith("Am") Then
                        Dim b1 As Boolean = rawResult.StartsWith("ÂM")
                        Dim b2 As Boolean = rawResult.StartsWith("AM")
                        Dim b3 As Boolean = rawResult.StartsWith("NEG")
                        If b1 Or b2 Or b3 Then
                            dr(binhthuong) = ""
                        Else
                            dr(binhthuong) = hight
                        End If

                    ElseIf normal.ToUpper().StartsWith("POS") Or normal.ToUpper().StartsWith("DƯƠ") Or normal.ToUpper().StartsWith("DUO") Then
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

                        If ((strTempResultString = "-") Or (strTempResultString = "±") Or (strTempResultString = "+") Or (strTempResultString = "+-")) And (strTempResultString <> normal) Then dr(binhthuong) = hight

                    End If
                Catch ex As Exception
                    dr(binhthuong) = " "
                    Continue For
                End Try
            Next


        Catch ex As Exception
        End Try
    End Sub

    Private Function GetInversedDataTable(ByVal table As DataTable, ByVal columnX As String, ByVal columnY As String, ByVal columnZ As String, ByVal nullValue As String, ByVal sumValues As Boolean) As DataTable
        'Create a DataTable to Return
        Try
            Dim returnTable As New DataTable()
            If columnX = "" Then
                columnX = table.Columns(0).ColumnName
            End If
            'Add a Column at the beginning of the table
            returnTable.Columns.Add(columnY)
            'Read all DISTINCT values from columnX Column in the provided DataTale
            Dim columnXValues As New List(Of String)()
            For Each dr As DataRow In table.Rows
                Dim columnXTemp As String = dr(columnX).ToString()
                If Not columnXValues.Contains(columnXTemp) Then
                    'Read each row value, if it's different from others provided, add to the list of values and creates a new Column with its value.
                    columnXValues.Add(columnXTemp)
                    returnTable.Columns.Add(columnXTemp)
                    returnTable.Columns.Add(columnXTemp + "_IsNormal")
                End If
            Next
            'Verify if Y and Z Axis columns re provided
            If columnY <> "" AndAlso columnZ <> "" Then
                'Read DISTINCT Values for Y Axis Column
                Dim columnYValues As New List(Of String)()
                For Each dr As DataRow In table.Rows
                    If Not columnYValues.Contains(dr(columnY).ToString()) Then
                        columnYValues.Add(dr(columnY).ToString())
                    End If
                Next
                'Loop all Column Y Distinct Value
                For Each columnYValue As String In columnYValues
                    'Creates a new Row
                    Dim drReturn As DataRow = returnTable.NewRow()
                    drReturn(0) = columnYValue
                    'foreach column Y value, The rows are selected distincted
                    Dim rows As DataRow() = table.[Select](columnY & "='" & columnYValue.Replace("'", "''") & "'")
                    'Read each row to fill the DataTable
                    For Each dr As DataRow In rows
                        Dim rowColumnTitle As String = dr(columnX).ToString()
                        'Read each column to fill the DataTable
                        For Each dc As DataColumn In returnTable.Columns
                            If dc.ColumnName = rowColumnTitle Then
                                'If Sum of Values is True it try to perform a Sum
                                'If sum is not possible due to value types, the value displayed is the last one read
                                If sumValues Then
                                    Try
                                        drReturn(rowColumnTitle) = Convert.ToDecimal(drReturn(rowColumnTitle)) + Convert.ToDecimal(dr(columnZ))
                                    Catch
                                        drReturn(rowColumnTitle) = dr(columnZ)
                                    End Try
                                Else
                                    drReturn(rowColumnTitle) = dr(columnZ)
                                    drReturn(rowColumnTitle + "_IsNormal") = dr("note")
                                End If
                            End If
                        Next
                    Next
                    returnTable.Rows.Add(drReturn)
                Next
            Else
                Throw New Exception("The columns to perform inversion are not provided")
            End If

            'if a nullValue is provided, fill the datable with it
            If nullValue <> "" Then
                For Each dr As DataRow In returnTable.Rows
                    For Each dc As DataColumn In returnTable.Columns
                        If dr(dc.ColumnName).ToString() = "" Then
                            dr(dc.ColumnName) = nullValue
                        End If
                    Next
                Next
            End If
            Return returnTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

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
            objSheet.Range("A1", "HT" + (dt.Rows.Count - 1 + nStartRow).ToString()).BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic)
            Dim nRow2 As Integer = 0
            For nRow = 0 To dt.Rows.Count - 1
                'Fill STT
                If dt.Rows(nRow)("Barcode").ToString() = "" Then Continue For
                nRow2 = nRow2 + 1
                objSheet.Cells(nStartRow + nRow2 - 1, 1) = nRow2
                For nCol = 0 To dt.Columns.Count - 1
                    Dim columnName As String = dt.Columns(nCol).ColumnName.Trim.ToUpper()
                    If Not columnName.EndsWith("_ISNORMAL") Then
                        colIndex = hs(columnName)
                        If colIndex > 0 Then
                            If colIndex = 44 Then colIndex = 44
                            Dim s As String = dt.Rows(nRow).Item(nCol).ToString().Trim()
                            If s <> "" Then
                                objSheet.Cells(nStartRow + nRow2 - 1, colIndex) = s
                                If colIndex >= 11 Then
                                    Dim toString1 = dt.Rows(nRow).Item(nCol + 1).ToString().Trim()
                                    If toString1 <> "" Then
                                        objSheet.Cells(nStartRow + nRow2 - 1, colIndex + 1) = toString1
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next nCol
                ProgressBar1.Value = nRow + 1
                percent = CType((CType(ProgressBar1.Value, Double) / CType(ProgressBar1.Maximum, Double)) * 100, Integer)
                ProgressBar1.CreateGraphics().DrawString(percent.ToString() + "%", New Font("Arial", CType(8.25, Single), FontStyle.Regular), Brushes.Black, New PointF(ProgressBar1.Width / 2 - 10, ProgressBar1.Height / 2 - 7))
            Next nRow
            ProgressBar1.Value = 0
            objSheet.Range("A5", "HB" + (dt.Rows.Count - 1 + nStartRow).ToString()).Columns.AutoFit()
            MsgBox("Ghi dữ liệu vào file excell thành công", vbOKOnly, "Thông Báo")
        Catch ex As Exception
            MsgBox("Lỗi khi ghi dữ liệu vào file excell", vbOKOnly, "Thông báo lỗi")
        End Try
    End Sub

    Private Function ExportDataTableToExcelFile(ByVal dt As DataTable, ByVal strSaveFilename As String, ByVal blnIsVisible As Boolean) As Boolean
        'Ghi lại Log
        Utilities.WriteDataTableToFile(dt, My.Application.Info.DirectoryPath & IO.Path.DirectorySeparatorChar & "_Last_JCLV_Data.txt")

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
            Const jclvReporttemplate As String = "JCLV-ReportTemplate.xls"
            strFileName = My.Application.Info.DirectoryPath & IO.Path.DirectorySeparatorChar & jclvReporttemplate
            If Not IO.File.Exists(strFileName) Then
                MsgBox("Không tìm thấy file Template: 'JCLV-ReportTemplate.xls'", vbOKOnly, "Thông báo lỗi")
                Return False
            Else
                Try
                    Try
                        objWorkbook = objExcel.Workbooks.Add(strFileName)
                    Catch ex As Exception
                        MsgBox("Không load được file: 'JCLV-ReportTemplate.xls'", vbOKOnly, "Thông báo lỗi")
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
        'Dim pro() As Process = Process.GetProcessesByName("EXCEL")
        'For Each i As Process In pro
        '    i.Kill()
        'Next
        Return True
    End Function

#End Region

    Private Sub JCLV_frm_DepartmentTestReport_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape then Dispose(true)
    End Sub
End Class