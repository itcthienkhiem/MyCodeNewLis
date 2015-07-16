Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports LIS.DAL
Imports VNS.Libs
Imports Utilities

Imports SubSonic

Class FrmImportFromExcel

    Private Const ResultBeginColumn As Integer = 5

#Region "Attributes"

    Public workSheetNames() As String
    Public workSheetNames_1() As String
    Public workSheetNames_2() As String
    Public fileName As String
    Private connectionString, connStr, connStrUpdate As String
    Private tblTestTypeList As New DataTable
    Private _tblPatientList As New DataTable
    Private _tblPatientListUpdate As New DataTable
    Private tblDataConTrol As New DataTable
    Private _tblPatientList1 As New DataTable
    Private _tblPatientList2 As New DataTable
    Private _tblResultDisplay As New DataTable
    Private _tblObjType As New DataTable
    Private arrTestType As New Hashtable
    Private arrTestOrder As New Hashtable
    Private arrTestParaRow As New Hashtable
    Dim methodConnection As SqlConnection
#End Region

#Region "Contructor"

    Private Sub frmLoadExcel_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try


        Catch ex As Exception

        Finally
            tblDataConTrol.Dispose()
            tblDataConTrol = Nothing

            tblTestTypeList.Dispose()
            tblTestTypeList = Nothing

            _tblPatientList.Dispose()
            _tblPatientList = Nothing
            _tblObjType.Dispose()
            _tblObjType = Nothing

        End Try


    End Sub

    Private Sub FillDonVi()
        Dim sql As String
        sql = "SELECT * FROM L_Department"
        Dim conn As SqlConnection = Utilities.GetDBConnection()
        Dim sv_Da As New SqlDataAdapter(sql, conn)
        Dim sv_Dt As New DataTable
        Try
            sv_Da.Fill(sv_Dt)
            DataBinding.BindDataCombox(cboUnit, sv_Dt, "ID", "sName", "--- Chọn ---")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillLOT()
        Dim sql As String
        sql = "SELECT * FROM tbl_Lot l ORDER BY l.ID desc"

        Dim sv_Da As New SqlDataAdapter(sql, gv_oSqlCnn)
        Dim sv_Dt As New DataTable
        Try
            sv_Da.Fill(sv_Dt)
            cboLot.DataSource = sv_Dt
            cboLot.DisplayMember = "ID"
            cboLot.ValueMember = "ID"
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Load lại đối tượng vào combobox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadObjType(ByVal pTable As DataTable, ByVal combo As ComboBox)
        Dim conn As SqlConnection = Utilities.GetDBConnection()
        Dim sqlAdapter As New SqlDataAdapter("SELECT ID,sName FROM L_ObjectType", conn)
        Dim dr As DataRow
        Try
            dr = pTable.NewRow()
            sqlAdapter.Fill(pTable)
            pTable.Rows.InsertAt(dr, 0)
            dr(0) = "0"
            dr(1) = "--------------"
            If pTable.Rows.Count > 0 Then

                combo.DataSource = pTable
                combo.DisplayMember = "sName"
                combo.ValueMember = "ID"
                combo.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        Finally
            conn.Dispose()
            sqlAdapter.Dispose()
        End Try
    End Sub

    Private Sub frmLoadExcel_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        TabControl1.TabPages.Remove(TabPage3)
        TabControl1.TabPages.Remove(TabPage2)
        grdTestType.AutoGenerateColumns = False
        grdTestDetail.AutoGenerateColumns = False
        LoadObjType(_tblObjType, cboObjType)
        LoadTestType()
        FillDonVi()
        FillLOT()
        GetDDataControl()
        grbLot.Enabled = False
        grbExtent.Enabled = False
        grbSelection.Enabled = False
        btnInsert.Enabled = False
        stStatus.Items(0).Alignment = ToolStripItemAlignment.Left
        stStatus.Items(1).Alignment = ToolStripItemAlignment.Right
        lbStatus.TextAlign = ContentAlignment.MiddleCenter

        tblDataConTrol = ModBusinessHelper.GetTestListFromTestTypeId(-1)
        If Not tblDataConTrol.Columns.Contains("Check") Then tblDataConTrol.Columns.Add("Check", GetType(Boolean))
        For Each dr As DataRow In tblDataConTrol.Rows
            dr("Check") = False
        Next

    End Sub

#End Region

#Region "Private Method"
    ''' <summary>
    ''' Hàm lấy về mã lô từ CSDL
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetLot() As DataTable
        Dim tblLotIdList As New DataTable
        Dim sqlAdapter As SqlDataAdapter

        Try

            sqlAdapter = New SqlDataAdapter("SELECT ID FROM tbl_Lot Order By ID DESC", gv_oSqlCnn)
            sqlAdapter.Fill(tblLotIdList)
            gv_oSqlCnn.Close()
            Return tblLotIdList
        Catch ex As Exception
            Return Nothing
        Finally
            sqlAdapter.Dispose()
            sqlAdapter = Nothing
        End Try

    End Function

    ''' <summary>
    ''' Hàm lấy thông tin của file excel
    ''' </summary>
    ''' <param name="isOpenXmlFormat">boolean</param>
    ''' <remarks></remarks>
    Public Function OpenExcelFile(ByVal _fileName As String, ByRef cnnstr As String) As String()
        'open the excel file using OLEDB
        Dim _conn As OleDbConnection
        Dim dataSet As DataTable
        Dim _workSheet As String()
        Dim namefile As String()
        namefile = fileName.Split(New Char() {"."})

        Try
            If (namefile(1).ToString() = "xlsx") Then


                cnnstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & _fileName & _
                                   ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"
            Else
                cnnstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & _fileName & "; Extended Properties=""Excel 12.0 Xml;HDR=Yes;IMEX=1"";"

            End If

            _conn = New OleDbConnection(cnnstr)
            _conn.Open()

            dataSet = _conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            _workSheet = New [String](dataSet.Rows.Count - 1) {}
            Dim i As Integer = 0
            For Each row As DataRow In dataSet.Rows
                _workSheet(i) = row("TABLE_NAME").ToString()
                i += 1
            Next

            Return _workSheet
        Catch ex As Exception
            MessageBox.Show("File excel:" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, _
                           MessageBoxIcon.Error)
        Finally
            dataSet.Dispose()
            dataSet = Nothing
            _conn.Close()
            _conn.Dispose()
            _conn = Nothing
            _workSheet = Nothing
        End Try
    End Function

    ''' <summary>
    ''' Kiểm tra xem trường nhập vào
    ''' </summary>
    ''' <param name="sex">string</param>
    ''' <returns>string</returns>
    ''' <remarks></remarks>
    Private Function GetSex(ByVal sex As String) As String

        If sex.ToLower = "nữ" Or sex.ToLower = "female" And Not Char.IsNumber(sex) Then
            sex = "0"
     
            'ElseIf sex.ToLower = ("Khac") Or sex.ToLower = ("khac") Then
            '    sex = "1"
        ElseIf Not Char.IsNumber(sex) Then
            sex = "1"
        Else


            Return sex
        End If
        Return sex
    End Function

    ''' <summary>
    ''' Lấy thông tin của từng sheet
    ''' </summary>
    ''' <param name="worksheetName">tên của sheet</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetWorksheet(ByVal connString As String, ByVal worksheetName As String) As DataTable
        Dim con As OleDbConnection = New OleDbConnection(connString)
        Dim cmd As OleDbDataAdapter = New OleDbDataAdapter("select * from [" & worksheetName & "]", con)

        con.Open()

        Dim excelDataSet As DataSet = New DataSet()

        cmd.Fill(excelDataSet)
        con.Close()
        Dim tempTable As DataTable = excelDataSet.Tables(0)

        Dim dt As New DataTable

        For Each colName As DataColumn In tempTable.Columns
            dt.Columns.Add(colName.ColumnName, GetType(String))
        Next

        For i As Integer = 0 To tempTable.Rows.Count - 1
            Dim dr As DataRow = dt.NewRow
            For j As Integer = 0 To tempTable.Columns.Count - 1
                Try
                    dr(j) = tempTable.Rows(i)(j).ToString
                Catch ex As Exception
                    dr(j) = ""
                End Try
            Next j
            dt.Rows.Add(dr)
        Next i
        Return dt
    End Function

    ''' <summary>
    ''' Hàm đăng ký thêm lô bệnh nhân
    ''' </summary>
    ''' <param name="orderform">Nhập bất kỳ kiểu Integer</param>
    ''' <param name="orderto">Nhập bất kỳ kiểu Integer</param>
    ''' <param name="dateinput">Ngày hiện lại</param>
    ''' <param name="Obj">Đối tượng</param>
    ''' <param name="sex">Giới tính, string</param>
    ''' <param name="addr">Địa chỉ</param>
    ''' <returns>none</returns>
    ''' <remarks></remarks>
    Private Function InsertLOTID(ByVal orderform As Integer, ByVal orderto As Integer, ByVal dateinput As DateTime, _
                                  ByVal Obj As String, ByVal sex As String, ByVal addr As String)
        Const insertSql As String = _
                      "INSERT INTO dbo.tbl_Lot(OrderFrom, OrderTo, DateInput, [Object], Sex, [Address])VALUES(@from,@to,@date,@obj,@sex,@addr)"

        Dim insertcmd As New SqlCommand(insertSql, gv_oSqlCnn)
        Try

            With insertcmd
                .Parameters.Add("@from", SqlDbType.Int).Value = orderform
                .Parameters.Add("@to", SqlDbType.Int).Value = orderto
                .Parameters.Add("@date", SqlDbType.DateTime).Value = dateinput.Date
                .Parameters.Add("@obj", SqlDbType.NVarChar).Value = Obj
                .Parameters.Add("@sex", SqlDbType.NVarChar).Value = sex
                .Parameters.Add("@addr", SqlDbType.NVarChar).Value = addr
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        Finally
            insertcmd.Dispose()
        End Try

    End Function

    ''' <summary>
    ''' Insert bn từ excel vào csdl
    ''' </summary>
    ''' <param name="pid">mã bn</param>
    ''' <param name="name">tên</param>
    ''' <param name="addr">địa chỉ</param>
    ''' <param name="birth">ngày sinh</param>
    ''' <param name="sex">giới tính</param>
    ''' <param name="diag">chỉ định</param>
    ''' <remarks></remarks>
    ''' string patientId, string patientName, string diachi, bool? pSex, int pAge, int pYearOfBirth, DateTime testdate
    Private Function InsertPatientInfo(ByVal pid As String, ByVal name As String, ByVal addr As String, _
                                   ByVal sex As Boolean?, ByVal birth As Integer, ByVal DOB As String, _
                                   ByVal testdate As DateTime, ByVal lotid As Integer, ByVal insuranse As String, _
                                   ByVal Diagnostic As String, ByVal nghenghiep As String, ByVal chucvu As String, ByVal canlamsangid As String) As Int64

        Dim Patient_ID As Int64

        Try
            Dim count As Int32
            '  count = New [Select]().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.Pid).IsEqualTo(pid).GetRecordCount()
            '  Dim PatientInfo As New LPatientInfo()
            Dim PatientInfo As DataTable = New [Select]().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.Pid).IsEqualTo(Utility.sDbnull(pid)).ExecuteDataSet().Tables(0)
            ''   If (PatientInfo.Pid <> pid) Then
            If (PatientInfo.Rows.Count <= 0) Then
                Dim lp As New LPatientInfo
                lp.Pid = pid
                lp.PatientName = name
                lp.Address = addr
                If birth = -1 Then
                    lp.YearBirth = Nothing
                Else
                    lp.YearBirth = birth
                End If

                If IsDate(DOB) Then
                    lp.Dob = DOB
                Else
                    lp.Dob = Nothing
                End If
                lp.Sex = sex
                lp.Diagnostic = Diagnostic
                lp.DepartmentID = Utility.Int16Dbnull(cboUnit.SelectedValue)
                lp.ObjectType = Utility.Int16Dbnull(cboObjType.SelectedValue)
                lp.InsuranceNum = insuranse
                lp.LotID = lotid
                lp.Dateupdate = testdate
                lp.ChucVu = chucvu
                lp.NgheNghiep = nghenghiep
                lp.DepartmentName = Utility.Int16Dbnull(cboUnit.SelectedText)
                lp.CanLamSangId = Utility.Int16Dbnull(canlamsangid)
                lp.IsNew = True
                lp.Save()
                Patient_ID = getExactlyMaxID()

                If IsNumeric(Patient_ID) Then
                    Return Patient_ID
                Else
                    Return -1
                End If
            Else
                '  DB.Update().From(LPatientInfo.Schema.Name).Set(LPatientInfo.Columns.Pid).EqualTo(pid).Set(LPatientInfo.Columns.PatientName).EqualTo(name).Set(LPatientInfo.Columns.Address).EqualTo(addr).Set(LPatientInfo.Columns.Dob).EqualTo(DOB)
                Patient_ID = Utility.Int32Dbnull(PatientInfo.Rows(0)("Patient_ID"))
                Dim departmentId = Utility.Int16Dbnull(cboUnit.SelectedValue)
                Dim DepartmentName = Utility.Int16Dbnull(cboUnit.SelectedText)
                Dim update = New Update(LPatientInfo.Schema.Name).Set(LPatientInfo.Columns.CanLamSangId).EqualTo(Utility.Int16Dbnull(canlamsangid)).Set(LPatientInfo.Columns.Pid).EqualTo(pid).Set(LPatientInfo.Columns.ObjectType).EqualTo(Utility.Int16Dbnull(cboObjType.SelectedValue)).Set(LPatientInfo.Columns.PatientName).EqualTo(name).Set(LPatientInfo.Columns.Address).EqualTo(addr).Set(LPatientInfo.Columns.Sex).EqualTo(sex).Set(LPatientInfo.Columns.YearBirth).EqualTo(birth).Set(LPatientInfo.Columns.Dob).EqualTo(DOB).Set(LPatientInfo.Columns.Diagnostic).EqualTo(Diagnostic).Set(LPatientInfo.Columns.InsuranceNum).EqualTo(insuranse).Set(LPatientInfo.Columns.NgheNghiep).EqualTo(nghenghiep).Set(LPatientInfo.Columns.ChucVu).EqualTo(chucvu).Set(LPatientInfo.Columns.Dateupdate).EqualTo(testdate).Set(LPatientInfo.Columns.DepartmentID).EqualTo(departmentId).Set(LPatientInfo.Columns.DepartmentName).EqualTo(DepartmentName).Where(LPatientInfo.Columns.PatientId).IsEqualTo(Patient_ID).Execute()

                If IsNumeric(Patient_ID) Then
                    Return Patient_ID
                Else
                    Return -1
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Public Function getExactlyMaxID() As Integer
        Dim fv_dt As New DataTable
        'Dim fv_da As New SqlDataAdapter("SELECT MAX(" & pv_sFieldName & ") FROM " & pv_sTableName, gv_WLConn)
        Try
            fv_dt = New [Select](LPatientInfo.Columns.PatientId).From(LPatientInfo.Schema.Name).OrderDesc(LPatientInfo.Columns.PatientId).ExecuteDataSet().Tables(0)
            If fv_dt.Rows.Count > 0 Then
                Return IIf(IsDBNull(fv_dt.Rows(0)(0)), 0, fv_dt.Rows(0)(0))
            Else
                Return 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function
    Private Sub InsertTestInfor(ByVal testTypeId As Integer, ByVal patientId As Integer, ByVal barCode As String, _
                                 ByVal testDate As DateTime)

        Dim sqlcmd As New SqlCommand
        Try
            With sqlcmd
                .Connection = gv_oSqlCnn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "MEDLIS_INSERT_TESTINFOR"
                .Parameters.Add("TestType_ID", SqlDbType.Int).Direction = ParameterDirection.Input
                .Parameters("TestType_ID").Value = testTypeId
                .Parameters.Add("Patient_ID", SqlDbType.Int).Direction = ParameterDirection.Input
                .Parameters("Patient_ID").Value = patientId
                .Parameters.Add("Barcode", SqlDbType.NVarChar).Direction = ParameterDirection.Input
                .Parameters("Barcode").Value = barCode
                .Parameters.Add("Test_Date", SqlDbType.NVarChar).Direction = ParameterDirection.Input
                .Parameters("Test_Date").Value = testDate.ToString("dd/MM/yyyy")

                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        Finally
            sqlcmd.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Hàm Lấy mã barcode lớn nhất
    ''' </summary>
    ''' <param name="testDate">Ngày</param>
    ''' <returns>Số nguyên</returns>
    ''' <remarks></remarks>
    Private Function GetMaxBarcode(ByVal testDate As DateTime) As Integer
        Dim sqlcmd As New SqlCommand
        Dim conn As SqlConnection = GetDBConnection()

        Dim da As New SqlDataAdapter
        Dim dtTable As New DataTable
        Dim id As String
        Try
            With sqlcmd
                .Connection = conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spGetMaxBarcode"
                .Parameters.Add("@yymmdd", SqlDbType.NVarChar).Direction = ParameterDirection.Input
                .Parameters("@yymmdd").Value = testDate.ToString("yyMMdd")
                .ExecuteNonQuery()
            End With
            da.SelectCommand = sqlcmd
            da.Fill(dtTable)
            id = dtTable.Rows(0).Item(0).ToString
            If String.IsNullOrEmpty(id) Then
                Return 0
            ElseIf (Convert.ToInt32(id) = -1) Then
                Return 0
            Else
                Return Convert.ToInt32(id)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            conn.Dispose()
            conn = Nothing
            sqlcmd.Dispose()
            sqlcmd = Nothing
            dtTable.Dispose()
            dtTable = Nothing

        End Try
    End Function

    ''' <summary>
    ''' Hàm lấy Patient_ID lớn nhất
    ''' </summary>
    ''' <param name="pid">pid</param>
    ''' <returns>trả về 1 nếu ko tìm thấy, trả về Patient_ID nếu tìm thấy </returns>
    ''' <remarks></remarks>
    Private Function GetMaxPatientId(ByVal pid As String) As Integer
        Dim conn As SqlConnection = GetDBConnection()

        Dim da As _
                New SqlDataAdapter("SELECT MAX (Patient_ID) FROM dbo.L_PATIENT_INFO WHERE PID ='" + pid + "'", _
                                    conn)
        Dim ta As New DataTable
        Try
            da.Fill(ta)
            Dim int As Integer

            If ta.Rows.Count > 0 Then
                int = ta.Rows(0).Item(0).ToString()
            Else
                int = 1
            End If
            Return int
        Catch ex As Exception
            Throw ex
        Finally
            conn.Dispose()
            conn = Nothing
            da.Dispose()
            da = Nothing
            ta.Dispose()
            ta = Nothing
        End Try
    End Function

    ''' <summary>
    ''' Hàm lấy mã lô lớn nhất
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMaxLOTID() As Integer
        Dim conn As SqlConnection = GetDBConnection()

        Dim da As New SqlDataAdapter("SELECT MAX(ID) FROM tbl_Lot", conn)
        Dim ta As New DataTable
        Try
            da.Fill(ta)
            Dim int As Integer

            If ta.Rows.Count > 0 Then
                int = ta.Rows(0).Item(0).ToString()
            End If
            Return int
        Catch ex As Exception
            Throw ex
        Finally
            conn.Dispose()
            conn = Nothing
            da.Dispose()
            da = Nothing
            ta.Dispose()
            ta = Nothing
        End Try
    End Function

    ''' <summary>
    ''' Hàm lấy IntOder
    ''' </summary>
    ''' <param name="testtypeId">testtypeId</param>
    ''' <returns>Số nguyên</returns>
    ''' <remarks></remarks>
    Private Function GetIntOrder(ByVal testtypeId As String) As Integer
        Dim conn As SqlConnection = GetDBConnection()

        Dim _
            da As _
                New SqlDataAdapter("SELECT intOrder FROM T_TEST_TYPE_LIST WHERE TestType_ID='" + testtypeId + "'", _
                                    gv_oSqlCnn)
        Dim dtTable As New DataTable
        Dim intOder As Integer
        Try
            da.Fill(dtTable)

            If dtTable.Rows.Count > 0 Then
                intOder = dtTable.Rows(0).Item(0).ToString
            Else
                intOder = 0
            End If
            Return intOder
        Catch ex As Exception
            Throw ex
        Finally
            conn.Dispose()
            conn = Nothing
            da.Dispose()
            da = Nothing
            dtTable.Dispose()
            dtTable = Nothing
        End Try

    End Function

    ''' <summary>
    ''' Hàm sinh mã barcode cho bảng T_Test_Info
    ''' </summary>
    ''' <param name="patientId">mã bn</param>
    ''' <param name="testtypeId">mã loại test</param>
    ''' <param name="testDate">ngày</param>
    ''' <returns>Barcode, string</returns>
    ''' <remarks></remarks>
    'Private Function GetBarcodeForTestInfo(ByVal patientId As String, ByVal testtypeId As Integer, _
    '                                        ByVal testDate As DateTime) As String
    '    'Hàm này chỉnh sửa theo hàm GetGroupType() trong form frm_TestInforV2        
    '    Dim maxBarcode As Integer = GetMaxBarcode(testDate)
    '    Dim intOrder As String = GetIntOrder(testtypeId)
    '    Dim barcode As String

    '    Try



    '        barcode = testDate.ToString("yyMMdd") + VB6.Right("00" + intOrder, 2) + _
    '                  VB6.Right("0000" + (maxBarcode + 1).ToString, 4)


    '        Return barcode
    '    Catch ex As Exception
    '        barcode = testDate.ToString("yyMMdd") + _
    '                  VB6.Right("00" + intOrder, 2 + VB6.Right("0000" + (maxBarcode + 1).ToString, 4))
    '    End Try
    'End Function



    ''' <summary>
    ''' Hàm lấy về loại xét nghiệm, đổ vào grdTestType
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadTestType()
        grdTestType.DataSource = Nothing

        Try

            tblTestTypeList = GetAllTestTypeList()
            If tblTestTypeList Is Nothing Then Return

            If tblTestTypeList.Rows.Count > 0 Then

                If Not tblTestTypeList.Columns.Contains("Check") Then
                    tblTestTypeList.Columns.Add("Check")
                End If

                For Each dr As DataRow In tblTestTypeList.Rows
                    dr("Check") = False
                Next
                tblTestTypeList.AcceptChanges()


                grdTestType.DataSource = tblTestTypeList

            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub




    ''' <summary>
    ''' Hàm điều khiển sự kiện bỏ dấu và viết hoa
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcessMapping()
        Try

            If _tblPatientList.Rows.Count < 6 Then
                Return
            End If

            ''Đoạn xử lý bỏ dấu
            Dim stateOneTable As DataTable = _tblPatientList
            If ckRemoveSign.Checked Then
                For Each dr As DataRow In stateOneTable.Rows
                    If Not String.IsNullOrEmpty(dr("Patient_Name")) Then
                        dr("Patient_Name") = Utility.Bodau(dr("Patient_Name"))
                    End If
                Next
                grdListPatient.DataSource = stateOneTable
            Else
                grdListPatient.DataSource = _tblPatientList
            End If
            Dim strArr() As String
            Dim strResult As New StringBuilder
            Dim stateTwoTable As DataTable = grdListPatient.DataSource
            If rbUpperAll.Checked Then
                ''Đoạn xử lý viết hoa toàn bộ
                For Each dr As DataRow In stateTwoTable.Rows
                    If Not String.IsNullOrEmpty(dr("Patient_Name")) Then
                        dr("Patient_Name") = dr("Patient_Name").ToString().ToUpper()
                    End If
                Next
                grdListPatient.DataSource = stateTwoTable
            Else
                ''Đoạn xử lý viết hoa đầu từ
                For Each dr As DataRow In stateTwoTable.Rows
                    strArr = dr("Patient_Name").ToString().Split(" ")
                    For i As Integer = 0 To strArr.Length - 1
                        strArr(i) = Char.ToUpper(strArr(i)(0)) + strArr(i).Substring(1) + " "
                        strResult.Append(strArr(i))
                    Next
                    dr("Patient_Name") = strResult.ToString().Trim()
                    strResult.Remove(0, strResult.Length)
                Next
                grdListPatient.DataSource = stateTwoTable
            End If

        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Hàm lấy năm từ dataTable
    ''' </summary>
    ''' <param name="paramDatatable">DataTable</param>
    ''' <returns>DataTable</returns>
    ''' <remarks>Hàm tiến hành substring lấy năm hoặc convert double to datetime dạng string</remarks>
    'Private Function ValidateDatetime(ByVal paramDatatable As DataTable) As DataTable
    '    Dim str As String
    '    Try
    '        If paramDatatable.Rows.Count > 0 Then
    '            For Each dr As DataRow In paramDatatable.Rows
    '                If String.IsNullOrEmpty(dr("DOB")) Then
    '                    dr("DOB") = "19000101"
    '                    dr("Age") = "0"
    '                Else

    '                    ''Nếu cột hiện đủ dd/MM/yyyy thì tiến hành cắt chuỗi
    '                    If dr("DOB") Then
    '                        str = dr("DOB").ToString().Substring(dr("DOB").ToString().Length - 4)
    '                    End If
    '                    ''Nếu chuyển thành dạng double thì convert
    '                    If dr("DOB").ToString().Length = 5 Then
    '                        str = DateTime.FromOADate(Convert.ToDouble(dr("DOB"))).Year.ToString()
    '                    End If
    '                    dr("DOB") = str

    '                End If

    '                ''Nếu cột Year ko rỗng và khônng null và đồng thời cột Age chưa có giá trị
    '                If (Not String.IsNullOrEmpty(dr("DOB")) AndAlso Char.IsNumber(dr("DOB").ToString())) AndAlso String.IsNullOrEmpty(dr("Age")) Then
    '                    dr("Age") = Date.Now.Year - dr("DOB")

    '                    ''Nếu cột Age ko rỗng, ko null và là số
    '                ElseIf Not String.IsNullOrEmpty(dr("Age")) AndAlso Char.IsNumber(dr("Age").ToString()) Then
    '                    dr("DOB") = Date.Now.Year - dr("Age")
    '                End If
    '            Next
    '        End If
    '        Return paramDatatable
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    Private Function ValidateInput() As Boolean
        Try
            grdListPatient.EndEdit()
            Dim flag As Boolean
            For i As Integer = 0 To grdListPatient.Rows.Count - 1
                ''Bắt lỗi PID           
                If String.IsNullOrEmpty(grdListPatient.Rows(i).Cells(2).Value) Or Not Char.IsNumber(grdListPatient.Rows(i).Cells(2).Value) Then
                    grdListPatient.Rows(i).Cells(2).Style.BackColor = Color.Red
                    flag = False
                    lbStatus.Visible = True
                Else
                    grdListPatient.Rows(i).Cells(2).Style.BackColor = Color.White
                    flag = True
                    lbStatus.Visible = False
                End If

                ''Bắt lỗi tên
                If DBNull.Value.Equals(grdListPatient.Rows(i).Cells(3)) Then
                    grdListPatient.Rows(i).Cells(3).Value = ""
                End If
                If String.IsNullOrEmpty(grdListPatient.Rows(i).Cells(3).Value) Then
                    grdListPatient.Rows(i).Cells(3).Style.BackColor = Color.Red
                    flag = False
                    lbStatus.Visible = True
                Else
                    grdListPatient.Rows(i).Cells(3).Style.BackColor = Color.White
                    lbStatus.Visible = False
                    flag = True
                End If

                ''Bắt năm sinh
                If DBNull.Value.Equals(grdListPatient.Rows(i).Cells(4)) Then
                    grdListPatient.Rows(i).Cells(4).Value = ""
                End If
                If String.IsNullOrEmpty(grdListPatient.Rows(i).Cells(4).Value) Or Not Char.IsNumber(grdListPatient.Rows(i).Cells(4).Value) Then
                    grdListPatient.Rows(i).Cells(4).Style.BackColor = Color.Red
                    flag = False
                    lbStatus.Visible = True
                Else
                    grdListPatient.Rows(i).Cells(4).Style.BackColor = Color.White
                    lbStatus.Visible = False
                    flag = True
                End If

                ''Bắt tuổi
                If DBNull.Value.Equals(grdListPatient.Rows(i).Cells(5)) Then
                    grdListPatient.Rows(i).Cells(5).Value = ""
                End If
                If String.IsNullOrEmpty(grdListPatient.Rows(i).Cells(5).Value) Or Not Char.IsNumber(grdListPatient.Rows(i).Cells(5).Value) Then
                    grdListPatient.Rows(i).Cells(5).Style.BackColor = Color.Red
                    flag = False
                    lbStatus.Visible = True
                Else
                    grdListPatient.Rows(i).Cells(5).Style.BackColor = Color.White
                    lbStatus.Visible = False
                    flag = True
                End If

                ''Bắt địa chỉ
                If DBNull.Value.Equals(grdListPatient.Rows(i).Cells(6)) Then
                    grdListPatient.Rows(i).Cells(6).Value = ""
                End If
                If String.IsNullOrEmpty(grdListPatient.Rows(i).Cells(6).Value) Then
                    grdListPatient.Rows(i).Cells(6).Style.BackColor = Color.Red
                    flag = False
                    lbStatus.Visible = True
                Else
                    grdListPatient.Rows(i).Cells(6).Style.BackColor = Color.White
                    lbStatus.Visible = False
                    flag = True
                End If

                If DBNull.Value.Equals(grdListPatient.Rows(i).Cells(7)) Then
                    grdListPatient.Rows(i).Cells(7).Value = ""
                End If

                If DBNull.Value.Equals(grdListPatient.Rows(i).Cells(8)) Then
                    grdListPatient.Rows(i).Cells(8).Value = ""
                End If
            Next
            Return flag
        Catch ex As Exception

        End Try

    End Function

    'Private Sub LoadLotCbo()
    '    Dim tblLotIdList As DataTable
    '    tblLotIdList = GetLot()

    '    If tblLotIdList.Rows.Count > 0 Then
    '        cboLot.DataSource = tblLotIdList
    '        cboLot.DisplayMember = "ID"
    '        cboLot.ValueMember = "ID"
    '        cboLot.SelectedIndex = 0
    '        cboLot.Enabled = True
    '    End If
    'End Sub

    Private Sub GetDDataControl()
        'Dim cmd As New SqlCommand

        'If gv_oSqlCnn.State = ConnectionState.Closed Then
        '    gv_oSqlCnn.Open()
        'End If

        'With cmd
        '    .Connection = gv_oSqlCnn
        '    .CommandType = CommandType.Text

        '    Dim sql As String
        '    sql = "SELECT ddc.Device_ID, " & vbCrLf _
        '        & "       ddc.Data_Name, " & vbCrLf _
        '        & "       ddc.Alias_Name, " & vbCrLf _
        '        & "       ddc.Measure_Unit, " & vbCrLf _
        '        & "       ddc.Normal_Level, " & vbCrLf _
        '        & "       ddc.Data_Sequence, " & vbCrLf _
        '        & "       ddl.TestType_ID " & vbCrLf _
        '        & "FROM   D_DATA_CONTROL ddc " & vbCrLf _
        '        & "LEFT JOIN D_DEVICE_LIST ddl ON ddl.Device_ID = ddc.Device_ID " & vbCrLf _
        '        & "ORDER BY " & vbCrLf _
        '        & "       Data_Sequence"
        '    .CommandText = sql
        '    '.CommandText = "SELECT Device_ID, Data_Name, Alias_Name, Measure_Unit, Normal_Level, Data_Sequence FROM D_DATA_CONTROL ORDER BY Data_Sequence"
        '    .ExecuteScalar()
        'End With
        'Dim sqlAdapter As New SqlDataAdapter
        'sqlAdapter.SelectCommand = cmd

        'If tblDataConTrol.Rows.Count > 0 Then
        '    tblDataConTrol.Clear()
        'End If
        'sqlAdapter.Fill(tblDataConTrol)
        tblDataConTrol = New [Select]().From(LStandardTest.Schema.Name).ExecuteDataSet().Tables(0)
        If Not tblDataConTrol.Columns.Contains("Check") Then
            tblDataConTrol.Columns.Add("Check", Type.GetType("System.Boolean"))
            tblDataConTrol.Columns("Check").SetOrdinal(0)
        End If
        For Each dr As DataRow In tblDataConTrol.Rows
            dr("Check") = False
        Next
        'tblDataConTrol.DefaultView.RowFilter = "Device_ID='" + cboDevices.SelectedValue.ToString() + "'"
        grdTestDetail.DataSource = tblDataConTrol.DefaultView
    End Sub
#End Region

#Region "Generated Events"

    Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOpen.Click
        Try
            Dim objOpenFileDialog As New OpenFileDialog
            objOpenFileDialog.Filter = _
                "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx|All Files (*.*)|*.*"
            objOpenFileDialog.FilterIndex = 1

            If objOpenFileDialog.ShowDialog() = DialogResult.OK Then
                fileName = objOpenFileDialog.FileName
            Else
                Return
            End If


            workSheetNames = OpenExcelFile(fileName, connectionString)

            sheetsToolStripComboBox.Items.Clear()
            Dim sheetName As String
            For Each sheetName In workSheetNames
                sheetsToolStripComboBox.Items.Add(sheetName)
            Next
            sheetsToolStripComboBox.SelectedIndex = -1


            lbStatus.Text = "Select sheet to load data."
            lbPath.Text = fileName
        Catch ex As Exception
            MessageBox.Show("File excel không hợp lệ hoặc File đang được mở bởi chương trình khác" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, _
                             MessageBoxIcon.Error)
        End Try


    End Sub

    Private Function ChangeHeaderTable(ByVal paramTable As DataTable, ByVal update As Boolean) As DataTable

        If Not update Then
            Try
                ''Đổi Header Column về mặc định
                If paramTable.Columns.Count >= 9 Then
                    If Not paramTable.Columns.Contains("STT") Then
                        paramTable.Columns(0).ColumnName = "STT"
                    End If
                    If Not paramTable.Columns.Contains("PID") Then
                        paramTable.Columns(1).ColumnName = "PID"
                    End If
                    If Not paramTable.Columns.Contains("Patient_Name") Then
                        paramTable.Columns(2).ColumnName = "Patient_Name"
                    End If
                    If Not paramTable.Columns.Contains("DOB") Then
                        paramTable.Columns(3).ColumnName = "DOB"
                    End If
                    If Not paramTable.Columns.Contains("Sex") Then
                        paramTable.Columns(4).ColumnName = "Sex"
                    End If
                    If Not paramTable.Columns.Contains("NgayVaoCongTy") Then
                        paramTable.Columns(5).ColumnName = "NgayVaoCongTy"
                    End If
                    If Not paramTable.Columns.Contains("Address") Then
                        paramTable.Columns(6).ColumnName = "Address"
                    End If

                    If Not paramTable.Columns.Contains("BoPhan") Then
                        paramTable.Columns(7).ColumnName = "BoPhan"
                    End If
                    If Not paramTable.Columns.Contains("PhanXuong") Then
                        paramTable.Columns(8).ColumnName = "PhanXuong"
                    End If
                    If Not paramTable.Columns.Contains("DonVi") Then
                        paramTable.Columns(9).ColumnName = "DonVi"
                    End If
                    If Not paramTable.Columns.Contains("Diagnostic") Then
                        paramTable.Columns(10).ColumnName = "Diagnostic"
                    End If
                    If Not paramTable.Columns.Contains("Barcode") Then
                        paramTable.Columns(11).ColumnName = "Barcode"
                    End If
                   
                End If

                ''Chèn cột PID vào datatable
                If Not paramTable.Columns.Contains("PID") Then
                    Dim dc As New DataColumn("PID")
                    paramTable.Columns.Add(dc)
                    dc.SetOrdinal(1)
                End If
                If Not paramTable.Columns.Contains("Age") Then
                    Dim dc As New DataColumn("Age")
                    paramTable.Columns.Add(dc)
                    dc.SetOrdinal(10)
                End If
                If Not paramTable.Columns.Contains("NameNoSign") Then
                    paramTable.Columns.Add("NameNoSign")
                    paramTable.Columns("NameNoSign").SetOrdinal(1)
                End If
                If Not paramTable.Columns.Contains("Status") Then
                    paramTable.Columns.Add("Status")

                End If
                If Not paramTable.Columns.Contains("YearBirth") Then
                    paramTable.Columns.Add("YearBirth")
                End If

                If Not paramTable.Columns.Contains("Check") Then
                    paramTable.Columns.Add("Check", Type.GetType("System.Boolean"))
                    paramTable.Columns("Check").SetOrdinal(0)
                End If

                'paramTable = ValidateDatetime(paramTable)

                Return paramTable
            Catch ex As Exception

            End Try
        Else
            Try
                ''Đổi Header Column về mặc định
                'If paramTable.Columns.Count > 5 Then

                '    If Not paramTable.Columns.Contains("Barcode") Then
                '        paramTable.Columns(0).ColumnName = "Barcode"
                '    End If
                '    If Not paramTable.Columns.Contains("Address") Then
                '        paramTable.Columns(1).ColumnName = "Address"
                '    End If
                '    If Not paramTable.Columns.Contains("DOB") Then
                '        paramTable.Columns(2).ColumnName = "DOB"
                '    End If
                '    'If Not paramTable.Columns.Contains("Age") Then
                '    '    paramTable.Columns(3).ColumnName = "Age"
                '    'End If
                '    If Not paramTable.Columns.Contains("Sex") Then
                '        paramTable.Columns(3).ColumnName = "Sex"
                '    End If
                '    If Not paramTable.Columns.Contains("Diagnostic") Then
                '        paramTable.Columns(4).ColumnName = "Diagnostic"
                '    End If
                '    If Not paramTable.Columns.Contains("Employee_Code") Then
                '        paramTable.Columns(5).ColumnName = "Employee_Code"
                '    End If
                'End If

                ''Chèn cột PID vào datatable
                If Not paramTable.Columns.Contains("PID") Then
                    Dim dc As New DataColumn("PID")
                    paramTable.Columns.Add(dc)
                    dc.SetOrdinal(1)

                End If
                If Not paramTable.Columns.Contains("Age") Then
                    Dim dc As New DataColumn("Age")
                    paramTable.Columns.Add(dc)
                    dc.SetOrdinal(10)
                End If
                If Not paramTable.Columns.Contains("NameNoSign") Then
                    paramTable.Columns.Add("NameNoSign")
                    paramTable.Columns("NameNoSign").SetOrdinal(1)
                End If
                If Not paramTable.Columns.Contains("Status") Then
                    paramTable.Columns.Add("Status")

                End If
                If Not paramTable.Columns.Contains("YearBirth") Then
                    paramTable.Columns.Add("YearBirth")

                End If

                If Not paramTable.Columns.Contains("Check") Then
                    paramTable.Columns.Add("Check", Type.GetType("System.Boolean"))
                    paramTable.Columns("Check").SetOrdinal(0)
                End If
                Return paramTable
            Catch ex As Exception

            End Try
        End If
    End Function

    Private Function MappingTable(ByVal paramTable As DataTable) As DataTable
        Dim resultTable As New DataTable
        Dim dColumn As DataColumn

    End Function

    Private Sub ValidateImportedData(ByRef paramTable As DataTable, ByVal bList As Boolean, ByVal update As Boolean)
        If Not update Then
            Dim patientId As Integer = 0
            Try
                ProgressBar1.Visible = True
                ProgressBar1.Value = 1

                ProgressBar1.Minimum = 0
                ProgressBar1.Maximum = paramTable.Rows.Count
                ProgressBar1.Step = 1
                For Each dr As DataRow In paramTable.Rows
                    dr("Check") = True
                    ' If ProgressBar1.Value <= paramTable.Rows.Count Then
                    If bList Then
                        If Not String.IsNullOrEmpty(dr("Patient_Name")) Then
                            Dim totalWidth As Integer = 0
                            If paramTable.Rows.Count >= 100000 Then
                                totalWidth = 4
                            ElseIf paramTable.Rows.Count >= 1000 Then
                                totalWidth = 3
                            ElseIf paramTable.Rows.Count >= 10 Then
                                totalWidth = 2
                            Else
                                totalWidth = 1
                            End If
                            'dr("PID") = GetPID(patientId.ToString().PadLeft(totalWidth, "0"))
                            dr("PID") = dr("PID")
                            'GetPID(patientId.ToString().PadLeft(totalWidth, "0"))
                            patientId += 1
                        End If
                        'If IsNumeric(dr("DOB")) Then
                        '    dr("DOB") = dr("DOB").ToString
                        'End If
                        If Not (Utility.sDbnull(dr("DOB")).Contains("/") And String.IsNullOrEmpty(dr("DOB").ToString) And (dr("DOB").ToString) = "") Then
                            Dim dob = Utility.sDbnull(dr("DOB")).Trim()
                            If (dob = "" Or dob.Contains("#N/A")) Then
                                dr("DOB") = DateTime.Now.ToString("dd/MM/yyyy")
                            Else
                                Dim ngay = dob.Substring(6, 2)
                                Dim thang = dob.Substring(4, 2)
                                Dim nam = dob.Substring(0, 4)
                                Dim NgaySinh = ngay + "/" + thang + "/" + nam
                                dr("DOB") = NgaySinh
                            End If
                        End If

                        If (Utility.sDbnull(dr("Sex")) = "" Or Utility.sDbnull(dr("Sex")).Contains("#N/A")) Then
                            dr("Sex") = "Khac"
                        End If
                        If Not (Utility.sDbnull(dr("NgayVaoCongTy")).Contains("/") And String.IsNullOrEmpty(dr("NgayVaoCongTy").ToString) And (Utility.sDbnull(dr("NgayVaoCongTy"))) = "") Then
                            Dim ngayvaocty = Utility.sDbnull(dr("NgayVaoCongTy")).Trim()
                            If (ngayvaocty = "" Or ngayvaocty.Contains("#N/A")) Then
                                dr("NgayVaoCongTy") = DateTime.Now.ToString("dd/MM/yyyy")
                            Else
                                Dim ngay = ngayvaocty.Substring(6, 2)
                                Dim thang = ngayvaocty.Substring(4, 2)
                                Dim nam = ngayvaocty.Substring(0, 4)
                                Dim DemThang = ngay + "/" + thang + "/" + nam
                                dr("NgayVaoCongTy") = DemThang
                            End If

                        End If
                        If String.IsNullOrEmpty(dr("DOB").ToString) Then
                            dr("DOB") = ""
                            dr("YearBirth") = ""
                            dr("Age") = ""
                            '_return = False

                        ElseIf IsDBnullOrNothing(dr("Age")) Then
                            Try
                                If IsNumeric(dr("DOB")) Then
                                    dr("Age") = Convert.ToString(Now.Year - Convert.ToInt16(dr("DOB").ToString))
                                    dr("YearBirth") = dr("DOB")
                                    dr("DOB") = ""
                                    dr("Check") = True
                                ElseIf IsDate(dr("DOB")) Then
                                    dr("DOB") = dr("DOB").ToString.Substring(0, 10)
                                    dr("YearBirth") = dr("DOB").ToString.Substring(6, 4)
                                    dr("Age") = Convert.ToString(Now.Year - Convert.ToInt16(Convert.ToInt16(dr("DOB").ToString.Substring(6, 4))))
                                    dr("Check") = True
                                Else
                                    dr("YearBirth") = ""
                                    dr("Age") = ""
                                End If
                            Catch ex As Exception
                                dr("Age") = ""
                                dr("YearBirth") = ""
                                dr("Check") = False
                            End Try
                        End If
                        dr("NameNoSign") = Utility.Bodau(dr("Patient_Name"))
                        'ProgressBar1.PerformStep()
                        'ProgressBar1.Value += 1
                    End If
                    '  End If
                Next

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            paramTable.Columns("PID").ReadOnly = True
            'Trường hợp Update thông tin bệnh nhân
        Else
            Try
                ToolStripProgressBar1.Value = 0
                ToolStripProgressBar1.Maximum = paramTable.Rows.Count
                For Each dr As DataRow In paramTable.Rows
                    dr("Check") = True
                    If bList Then
                        If Not String.IsNullOrEmpty(dr("Patient_Name")) Then
                            Dim totalWidth As Integer = 0
                            If paramTable.Rows.Count >= 1000 Then
                                totalWidth = 4
                            ElseIf paramTable.Rows.Count >= 100 Then
                                totalWidth = 3
                            ElseIf paramTable.Rows.Count >= 10 Then
                                totalWidth = 2
                            Else
                                totalWidth = 1
                            End If
                            dr("PID") = dr("PID")
                        End If
                        'If IsNumeric(dr("DOB")) Then
                        '    dr("DOB") = dr("DOB").ToString
                        'End If
                        If String.IsNullOrEmpty(dr("DOB").ToString) Then
                            dr("DOB") = ""
                            dr("YearBirth") = ""
                            dr("Age") = ""
                            '_return = False
                        ElseIf IsDBnullOrNothing(dr("Age")) Then
                            Try
                                If IsNumeric(dr("DOB")) Then
                                    dr("Age") = Convert.ToString(Now.Year - Convert.ToInt16(dr("DOB").ToString))
                                    dr("YearBirth") = dr("DOB")
                                    dr("DOB") = ""
                                    dr("Check") = True
                                ElseIf IsDate(dr("DOB")) Then
                                    dr("DOB") = dr("DOB").ToString.Substring(0, 10)
                                    dr("YearBirth") = dr("DOB").ToString.Substring(6, 4)
                                    dr("Age") = Convert.ToString(Now.Year - Convert.ToInt16(Convert.ToInt16(dr("DOB").ToString.Substring(6, 4))))
                                    dr("Check") = True
                                Else
                                    dr("YearBirth") = ""
                                    dr("Age") = ""
                                End If
                            Catch ex As Exception
                                dr("Age") = ""
                                dr("YearBirth") = ""
                                dr("Check") = False
                            End Try
                        End If
                        dr("NameNoSign") = Utility.Bodau(dr("Patient_Name"))
                    End If
                    ToolStripProgressBar1.Value += 1
                Next

                ToolStripProgressBar1.Visible = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
        ProgressBar1.Visible = False
    End Sub

    Private Sub sheetsToolStripComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles sheetsToolStripComboBox.SelectedIndexChanged



    End Sub

#End Region

    Private Sub ckRemoveSign_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckRemoveSign.CheckedChanged
        If grdListPatient.RowCount = 0 Then
            Return
        End If

        If ckRemoveSign.Checked Then
            grdListPatient.Columns("NameNoSign").Width = grdListPatient.Columns("Patient_Name").Width
            grdListPatient.Columns("Patient_Name").Visible = False
            grdListPatient.Columns("NameNoSign").Visible = True
        Else
            grdListPatient.Columns("Patient_Name").Width = grdListPatient.Columns("NameNoSign").Width
            grdListPatient.Columns("Patient_Name").Visible = True
            grdListPatient.Columns("NameNoSign").Visible = False

        End If
    End Sub

    Private Sub rbUpperCaption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUpperCaption.CheckedChanged
        If grdListPatient.RowCount <= 0 Then
            Return
        End If
        If rbUpperAll.Checked Then
            ''Đoạn xử lý viết hoa toàn bộ
            For i As Integer = 0 To grdListPatient.Rows.Count - 1
                grdListPatient.Rows(i).Cells("Patient_Name").Value = grdListPatient.Rows(i).Cells("Patient_Name").Value.ToString().ToUpper()
                grdListPatient.Rows(i).Cells("NameNoSign").Value = grdListPatient.Rows(i).Cells("NameNoSign").Value.ToString().ToUpper()
            Next i
        Else
            ''Đoạn xử lý viết hoa đầu từ
            Dim strArr() As String
            Dim strResult As New StringBuilder
            For index As Integer = 0 To grdListPatient.Rows.Count - 1
                strArr = grdListPatient.Rows(index).Cells("Patient_Name").Value.ToString().Split(" ")
                For i As Integer = 0 To strArr.Length - 1
                    strArr(i) = Char.ToUpper(strArr(i)(0)) + strArr(i).Substring(1).ToLower() + " "
                    strResult.Append(strArr(i))
                Next
                grdListPatient.Rows(index).Cells("Patient_Name").Value = strResult.ToString().Trim()
                strResult.Remove(0, strResult.Length)

                strArr = grdListPatient.Rows(index).Cells("NameNoSign").Value.ToString().Split(" ")
                For i As Integer = 0 To strArr.Length - 1
                    strArr(i) = Char.ToUpper(strArr(i)(0)) + strArr(i).Substring(1).ToLower() + " "
                    strResult.Append(strArr(i))
                Next
                grdListPatient.Rows(index).Cells("NameNoSign").Value = strResult.ToString().Trim()
                strResult.Remove(0, strResult.Length)
            Next
        End If
        ValidateInput()
        _tblPatientList.AcceptChanges()
    End Sub

    Private Sub ckLot_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckLot.CheckedChanged
        cboLot.Visible = ckLot.Checked
    End Sub

    Private Sub grdTestType_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTestType.SelectionChanged
        Try
            If grdTestType.CurrentRow Is Nothing Then Exit Sub
            grdTestDetail.DataSource = Nothing
            Dim index As Integer
            index = grdTestType.CurrentRow.Cells("clTestTypeID").Value
            ' If ModBusinessHelper.IsBiDirectionalTest(index) Then
            tblDataConTrol.DefaultView.RowFilter = String.Format("TestType_ID = {0}", index)
            tblDataConTrol.DefaultView.Sort = "Data_Sequence ASC"
            grdTestDetail.DataSource = tblDataConTrol.DefaultView
            '  End If
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub grdTestType_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTestType.CellClick
    '    If grdTestType.CurrentRow Is Nothing Then
    '        Exit Sub
    '    End If
    '    grdTestType.CurrentRow.Cells("clTypeCheck").Value = Not grdTestType.CurrentRow.Cells("clTypeCheck").Value
    'End Sub

    Private Sub rbCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCheckAll.Click

        If rbCheckAll.Checked Then
            For Each dr As DataRow In _tblPatientList.Rows
                dr("Check") = True
            Next
        End If

    End Sub

    Private Function GetTestID(ByVal Patient_ID As Integer, ByVal testtype_ID As Integer, ByVal sDate As DateTime)
        Dim sqlAdapter As New SqlDataAdapter("SELECT * FROM T_TEST_INFO WHERE PATIENT_ID=" & Patient_ID & " AND TESTTYPE_ID=" & testtype_ID & " AND TEST_DATE ='" + sDate.Date.ToString("yyyy-MM-dd") + "'", gv_oSqlCnn)
        Dim sqlTable As New DataTable
        Dim intResult As Integer
        Try
            sqlAdapter.Fill(sqlTable)
            If sqlTable.Rows.Count > 0 Then
                intResult = sqlTable.Rows(0)("TEST_ID")
            Else
                intResult = -1
            End If
            Return intResult

        Catch ex As Exception
            Utility.ShowMsgBox(ex.Message)
        End Try
    End Function

    Public Function InsertTRegList(ByVal pBarcode As String, _
                                      ByVal pTestID As Int64, _
                                      ByVal pAlias_Name As String, _
                                      ByVal pPara_Name As String, _
                                      ByVal pSave As Boolean, _
                                        ByVal pDeviceID As Int32)
        Dim cmd As New SqlCommand
        Try
            With cmd
                .Connection = gv_oSqlCnn
                .CommandText = "spCreateRegList"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("pBarcode", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                .Parameters("pBarcode").Value = pBarcode
                .Parameters.Add("pTestID", SqlDbType.BigInt).Direction = ParameterDirection.Input
                .Parameters("pTestID").Value = pTestID
                .Parameters.Add("pAlias_Name", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                .Parameters("pAlias_Name").Value = pAlias_Name
                .Parameters.Add("pPara_Name", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Input
                .Parameters("pPara_Name").Value = pPara_Name
                .Parameters.Add("pSave", SqlDbType.Bit).Direction = ParameterDirection.Input
                .Parameters("pSave").Value = pSave
                .Parameters.Add("pDeviceID", SqlDbType.Decimal).Direction = ParameterDirection.Input
                .Parameters("pDeviceID").Value = pDeviceID
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
            'Finally
            '    cmd.Connection.Close()
            '    cmd.Connection.Dispose()
            '    cmd.Connection = Nothing
            '    cmd.Dispose()
            '    cmd = Nothing
        End Try

    End Function

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim testType As Integer
            Dim outbarcode As String = String.Empty
            Dim testID As Integer
            Dim patientId As Integer
            Dim retry As Byte = 0
            Dim name As String
            Dim lotid As Integer
            If (rddangky.Checked) Then
                If tblTestTypeList.Select("Check='True'").Length <= 0 Then
                    MessageBox.Show("Bạn chưa chọn loại xét nghiệm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                ''Nếu cập nhật lô thì lấy mã lô
                'If ckLot.Checked Then
                '    lotid = cboLot.Text
                'Else
                '    ''Không thì Đăng ký lô mới rồi lấy mã lô
                '    InsertLOTID(1, grdListPatient.Rows.Count, dtpInputDate.Value.Date, cboObjType.Text, _
                '             grdListPatient.Rows(0).Cells("Sex").Value.ToString, _
                '             grdListPatient.Rows(0).Cells("Address").Value.ToString)
                '    lotid = GetMaxLOTID()
                'End If
                ProgressBar1.Visible = True
                ProgressBar1.Minimum = 0
                ProgressBar1.Value = 0
                ProgressBar1.Step = 1
                ProgressBar1.Maximum = _tblPatientList.Rows.Count
                For Each dr As DataRow In _tblPatientList.Rows
                    If dr("Check") = True Then
                        If grdListPatient.Columns("Patient_Name").Visible = True Then
                            name = dr("Patient_Name")
                        Else
                            name = dr("NameNoSign")
                        End If
                        retry = 0
                        Do
                            Dim pid As Object = Utility.sDbnull(dr("PID"))
                            Dim addr As Object = Utility.sDbnull(dr("Address"))
                            Dim sex As String = Utility.sDbnull(GetSex(dr("Sex")))
                            Dim birth As Object
                            If (String.IsNullOrEmpty(Utility.sDbnull(dr("YearBirth")))) Then
                                birth = Utility.Int16Dbnull(dr("Age"))
                            Else
                                birth = Utility.Int16Dbnull(dr("YearBirth"))
                            End If
                            Dim nghenghiep As String = Utility.sDbnull(dr("PhanXuong"))
                            Dim Donvi As String = Utility.sDbnull(dr("DonVi"))
                            Dim chucvu As String = Utility.sDbnull(dr("BoPhan"))
                            Dim idcanlamsang As String = Utility.sDbnull(dr("STT")).Trim()
                            Dim TuoiNghe As String = Utility.sDbnull(dr("NgayVaoCongTy"))
                            'Dim tinhtuoinghe= 
                            Dim TimeSpan As TimeSpan = DateTime.Parse(DateTime.Now) - DateTime.Parse(TuoiNghe)
                            Dim tinhtuoinghe As Integer = Math.Round(TimeSpan.TotalDays) / 30
                            Dim dob As Object = dr("DOB")
                            patientId = InsertPatientInfo(pid, name, addr, sex, birth, dob, dtpInputDate.Value.Date, lotid, tinhtuoinghe, dr("Diagnostic"), nghenghiep, chucvu, idcanlamsang)
                            dr("Check") = False
                        Loop Until (patientId <> -1) Or (++retry > 5)
                        If retry > 5 Then
                            dr("Status") = "Lỗi insert BN!"
                            Continue For
                        End If

                        For Each drTestType As DataRow In tblTestTypeList.Rows
                            If drTestType("Check") = True Then
                                testType = Convert.ToInt32(drTestType("TestType_ID"))
                                Dim strmessage As String
                                outbarcode = GetBarcodeFromPatientId(patientId)
                                If (outbarcode = "-1") Then
                                    outbarcode = dr("barcode")
                                End If
                                'outbarcode = dr("barcode")
                                InsertTestInfoForPatient(patientId, testType, dtpInputDate.Value, outbarcode, testID, strmessage)
                                'tblDataConTrol.DefaultView.RowFilter = "TestType_id = " & testType

                                For Each drTestDetail As DataRow In tblDataConTrol.Rows
                                    If (drTestDetail("Check") = True) And (drTestDetail("TestType_id") = testType) Then
                                        'InsertTRegList(outbarcode, testID, drTestDetail("Alias_Name"), drTestDetail("Data_Name"), 1, drTestDetail("Device_ID"))
                                        UpdateRegTestList(testID, drTestDetail("TestData_ID"), True)
                                    End If
                                Next
                            End If
                        Next
                        dr("Status") = "Updated"
                        ProgressBar1.PerformStep()
                        ' ProgressBar1.Value += 1
                    End If

                Next
                _tblPatientList.AcceptChanges()
                'ToolStripProgressBar1.Visible = False
                MessageBox.Show("Bạn đã Insert thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ProgressBar1.Visible = False
            Else
                ProgressBar1.Visible = True
                ProgressBar1.Minimum = 0
                ProgressBar1.Value = 0
                ProgressBar1.Step = 1
                ProgressBar1.Maximum = _tblPatientList.Rows.Count
                For Each dr As DataRow In _tblPatientList.Rows
                    If dr("Check") = True Then
                        If grdListPatient.Columns("Patient_Name").Visible = True Then
                            name = dr("Patient_Name")
                        Else
                            name = dr("NameNoSign")
                        End If
                        retry = 0
                        Do
                            Dim pid As Object = Utility.sDbnull(dr("PID"))
                            Dim addr As Object = Utility.sDbnull(dr("Address"))
                            Dim sex As String = Utility.sDbnull(GetSex(dr("Sex")))
                            Dim birth As Object
                            If (String.IsNullOrEmpty(Utility.sDbnull(dr("YearBirth")))) Then
                                birth = Utility.Int16Dbnull(dr("Age"))
                            Else
                                birth = Utility.Int16Dbnull(dr("YearBirth"))
                            End If
                            Dim nghenghiep As String = Utility.sDbnull(dr("PhanXuong"))
                            Dim Donvi As String = Utility.sDbnull(dr("DonVi"))
                            Dim chucvu As String = Utility.sDbnull(dr("BoPhan"))
                            Dim idcanlamsang As String = Utility.sDbnull(dr("STT")).Trim()
                            Dim TuoiNghe As String = Utility.sDbnull(dr("NgayVaoCongTy"))
                            'Dim tinhtuoinghe= 
                            Dim TimeSpan As TimeSpan = DateTime.Parse(DateTime.Now) - DateTime.Parse(TuoiNghe)
                            Dim tinhtuoinghe As Integer = Math.Round(TimeSpan.TotalDays) / 30
                            Dim dob As Object = dr("DOB")
                            patientId = InsertPatientInfo(pid, name, addr, sex, birth, dob, dtpInputDate.Value.Date, lotid, tinhtuoinghe, dr("Diagnostic"), nghenghiep, chucvu, idcanlamsang)
                            dr("Check") = False
                        Loop Until (patientId <> -1) Or (++retry > 5)
                        If retry > 5 Then
                            dr("Status") = "Lỗi insert BN!"
                            Continue For
                        End If

                        'For Each drTestType As DataRow In tblTestTypeList.Rows
                        '    If drTestType("Check") = True Then
                        '        testType = Convert.ToInt32(drTestType("TestType_ID"))
                        '        Dim strmessage As String
                        '        outbarcode = GetBarcodeFromPatientId(patientId)
                        '        If (outbarcode = "-1") Then
                        '            outbarcode = dr("barcode")
                        '        End If

                        '        'outbarcode = dr("barcode")
                        '        InsertTestInfoForPatient(patientId, testType, dtpInputDate.Value, outbarcode, testID, strmessage)

                        '        'tblDataConTrol.DefaultView.RowFilter = "TestType_id = " & testType

                        '        For Each drTestDetail As DataRow In tblDataConTrol.Rows
                        '            If (drTestDetail("Check") = True) And (drTestDetail("TestType_id") = testType) Then
                        '                'InsertTRegList(outbarcode, testID, drTestDetail("Alias_Name"), drTestDetail("Data_Name"), 1, drTestDetail("Device_ID"))
                        '                UpdateRegTestList(testID, drTestDetail("TestData_ID"), True)
                        '            End If
                        '        Next
                        '    End If
                        'Next
                        dr("Status") = "Updated"
                        ProgressBar1.PerformStep()
                        '  ProgressBar1.Value += 1
                    End If

                Next
                _tblPatientList.AcceptChanges()
                'ToolStripProgressBar1.Visible = False
                MessageBox.Show("Bạn đã Insert thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
          
            'Dim name As String
            'Dim lotid As Integer
            ''Nếu cập nhật lô thì lấy mã lô
            'If ckLot.Checked Then
            '    lotid = cboLot.Text
            'Else
            '    ''Không thì Đăng ký lô mới rồi lấy mã lô
            '    InsertLOTID(1, grdListPatient.Rows.Count, dtpInputDate.Value.Date, cboObjType.Text, _
            '             grdListPatient.Rows(0).Cells("Sex").Value.ToString, _
            '             grdListPatient.Rows(0).Cells("Address").Value.ToString)
            '    lotid = GetMaxLOTID()
            'End If
                    'If _tblPatientList.Select("Status='Updated'").Length = _tblPatientList.Rows.Count Then
            '    Dim dlgResult As DialogResult = MessageBox.Show("Đã cập nhật toàn bộ bệnh nhân." + vbCrLf + "Bạn có muốn tiếp tục không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            '    If dlgResult = DialogResult.Yes Then
            '        'tblDataConTrol.Clear()
            '        _tblPatientList.Clear()
            '        'tblTestTypeList.Clear()
            '        sheetsToolStripComboBox.Items.Clear()
            '        btnOpen.PerformClick()
            '    End If
            'Else
            '    ToolStripProgressBar1.Visible = False
            '    MessageBox.Show("Bạn đã cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra!" + vbCrLf + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            For Each dr As DataRow In tblDataConTrol.Rows
                dr("Check") = False
            Next
            ckLot.Checked = True
            ProgressBar1.Visible = False
        End Try
    End Sub

    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.Click
        Try
            Dim objOpenFileDialog As New OpenFileDialog
            objOpenFileDialog.Filter = _
                "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx|All Files (*.*)|*.*"
            objOpenFileDialog.FilterIndex = 1

            If objOpenFileDialog.ShowDialog() = DialogResult.OK Then
                txtFileName.Text = objOpenFileDialog.FileName
            Else
                Return
            End If
            workSheetNames_1 = OpenExcelFile(txtFileName.Text, connStr)
            cboSheet.Items.Clear()

            Dim sheetName As String
            For Each sheetName In workSheetNames_1
                cboSheet.Items.Add(sheetName)
            Next

            cboSheet.SelectedIndex = -1
            _tblResultDisplay.Clear()

            lbStatus.Text = "Select sheet to load data."

        Catch ex As Exception
            MessageBox.Show("File excel không hợp lệ hoặc File đang được mở bởi chương trình khác", "Lỗi", MessageBoxButtons.OK, _
                             MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ChangeHeaderResultTable(ByVal paramTable As DataTable) As Boolean

        Try
            If paramTable.Columns.Count > 5 Then
                If Not File.Exists(Application.StartupPath & "\JCLV_ImportResultConfig.txt") Then
                    File.Create(Application.StartupPath & "\JCLV_ImportResultConfig.txt")
                    File.WriteAllText(Application.StartupPath & "\JCLV_ImportResultConfig.txt", "JCLV_ID" & vbCrLf & _
                                        "Employee_Code" & vbCrLf & "Patient_Name" & vbCrLf & "DOB" & vbCrLf & "Sex" & vbCrLf)
                End If

                Dim _config As String() = File.ReadAllLines(Application.StartupPath & "\JCLV_ImportResultConfig.txt")


                If _config.Length = 0 Then
                    MsgBox("Không có dữ liệu trong file JCLV_ImportResultConfig.txt ", vbOK, "Thông báo")
                    Exit Function
                End If

                For i As Byte = 0 To _config.Length - 1
                    paramTable.Columns(i).ColumnName = _config(i)
                Next i

                'Chèn cột PID vào datatable
                If Not paramTable.Columns.Contains("PID") Then
                    Dim dc As New DataColumn("PID")
                    paramTable.Columns.Add(dc)
                    dc.SetOrdinal(0)
                End If

                If Not paramTable.Columns.Contains("Age") Then
                    Dim dc As New DataColumn("Age")
                    paramTable.Columns.Add(dc)
                    dc.SetOrdinal(5)
                End If
                If Not paramTable.Columns.Contains("NameNoSign") Then
                    paramTable.Columns.Add("NameNoSign")
                    paramTable.Columns("NameNoSign").SetOrdinal(3)
                End If

                If Not paramTable.Columns.Contains("YearBirth") Then
                    paramTable.Columns.Add("YearBirth")

                End If

                If Not paramTable.Columns.Contains("Check") Then
                    paramTable.Columns.Add("Check", Type.GetType("System.Boolean"))
                    paramTable.Columns("Check").SetOrdinal(0)
                End If

                If Not paramTable.Columns.Contains("Status") Then
                    paramTable.Columns.Add("Status")
                End If

            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub cmdImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImport.Click
        Dim i As Integer
        If cboSheet.SelectedItem Is Nothing Then
            Return
        End If
        Try
            _tblPatientList1 = New DataTable

            lbStatus.Text = "Loading.."
            _tblPatientList1 = GetWorksheet(connStr, cboSheet.SelectedItem.ToString())
            _tblResultDisplay = _tblPatientList1.Copy()

            For i = ResultBeginColumn To _tblPatientList1.Columns.Count - 1
                Dim testcode As String = _tblPatientList1.Columns(i).ColumnName
                'Dim _temptbl As DataTable =  Utilities.GetDatatable("D_DATA_CONTROL", "Description='" & testcode & "'")
                Dim _temptbl As DataTable = New [Select]().From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.Description).IsEqualTo(testcode).ExecuteDataSet().Tables(0)
                If IsDBnullOrNothing(_temptbl) Or (_temptbl.Rows.Count = 0) Then
                    If MsgBox("Không có XN mã: " & testcode & vbCrLf & "Tiếp tục tải dữ liệu?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Thông báo") = MsgBoxResult.No Then
                        txtFileName.Text = String.Empty
                        connStr = String.Empty
                        _tblResultDisplay.Clear()
                        _tblResultDisplay.AcceptChanges()
                        _tblPatientList1.Dispose()
                        _tblPatientList1 = Nothing
                        Exit Sub
                    End If
                    Continue For
                End If

                Dim _temprow As DataRow = _temptbl.Rows(0)
                If Not arrTestParaRow.Contains(testcode) Then arrTestParaRow.Add(testcode, _temprow)
                _tblResultDisplay.Columns(testcode).ColumnName = _temprow("Data_Name")
                Dim testtype = GetTestTypeIdFromTestCode(testcode)
                If Not arrTestType.Contains(testcode) Then arrTestType.Add(testcode, testtype)
                If Not arrTestOrder.Contains(testtype) Then arrTestOrder.Add(testtype, Utilities.spGetintOder(testtype))
            Next i

            ChangeHeaderResultTable(_tblResultDisplay)
            ValidateImportedData(_tblResultDisplay, False, False)

            grdDataImported.DataSource = _tblResultDisplay
            grdDataImported.Columns("PID").Visible = False
            grdDataImported.Columns("Age").Visible = False
            grdDataImported.Columns("YearBirth").Visible = False
            grdDataImported.Columns("NameNoSign").Visible = False
            lbStatus.Text = "Tổng số: " & _tblPatientList1.Rows.Count.ToString & " bệnh nhân"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdUpdateToDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateToDB.Click
        Dim pTestDate As DateTime = dtpImportDate.Value.Date
        Try

            methodConnection = Utilities.GetDBConnection
            ToolStripProgressBar1.Value = 0
            ToolStripProgressBar1.Maximum = _tblPatientList1.Rows.Count - 1
            For drcount As Integer = 0 To _tblPatientList1.Rows.Count - 1
                Dim dr As DataRow = _tblPatientList1.Rows(drcount)
                Dim testcode As String
                For i As Byte = ResultBeginColumn To _tblPatientList1.Columns.Count - 1
                    testcode = _tblPatientList1.Columns(i).ColumnName
                    If Not arrTestType.Contains(testcode) Then Continue For
                    Dim testType = GetTestTypeIdFromDescription(testcode)
                    Dim outbarcode = pTestDate.ToString("yyMMdd") & arrTestOrder(testType) & Utilities.spGetBarcode(dr("JCLV ID"))
                    Dim patientId = GetPatientIdFromBarcode(outbarcode)

                    If String.IsNullOrEmpty(Utility.sDbnull(patientId)) Then Continue For

                    Dim pTestId = GetTestIdFromBarcodeAndTestTypeId(outbarcode, testType)

                    If String.IsNullOrEmpty(Utility.sDbnull(pTestId)) Then Continue For
                    Dim testrow As DataRow = arrTestParaRow(testcode)

                    ' Tiến hành import dữ liệu
                    Dim pDataSeq As Object = testrow("Data_Sequence")
                    Dim pParaName As Object = testrow("Data_Name")
                    Dim pMeasureUnit As Object = testrow("Measure_Unit")
                    Dim pTestResult As Object = dr(testcode)
                    Dim pNormalLevel As Object = testrow("Normal_Level")
                    Dim pNormalLevelW As Object = testrow("Normal_LevelW")

                    'Kiểm tra nếu kết quả mới là trắng hoặc rỗng thì không insert vào DB
                    If String.IsNullOrEmpty(pTestResult.ToString()) Then Continue For
                    'Nếu barcode này đã có kết quả thì bỏ qua trong trường hợp check vào tùy chọn
                    If pParaName.ToString().StartsWith("Đường máu") Then Debug.WriteLine("Đường Máu")
                    If cboKeepOldResult.Checked Then
                        Dim pDetailId = Utilities.GetFieldValue("T_RESULT_DETAIL", "TestDetail_ID", "Barcode='" & outbarcode & "' AND Para_Name = N'" & pParaName & "'")
                        If Not String.IsNullOrEmpty(Utility.sDbnull(pDetailId)) Then Continue For
                    End If
                    spInsertUpdateResult(pTestId, patientId, testType, "", pTestDate, pDataSeq, outbarcode, pParaName, pTestResult, pMeasureUnit, pNormalLevel, pNormalLevelW)
                Next i
                _tblResultDisplay.Rows(drcount)("Status") = "Đã cập nhật"
                ToolStripProgressBar1.Value = drcount
            Next drcount
            lbStatus.Text = "Đã cập nhật xong!"
            MessageBox.Show("Bạn đã cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        Finally
            methodConnection.Dispose()
            methodConnection = Nothing
        End Try
    End Sub

    Private Function spInsertUpdateResult(ByVal pTestID As Int64, _
                            ByVal pPatientID As Int64, _
                            ByVal pTestTypeID As Int16, _
                            ByVal pTestSeq As String, _
                            ByVal pTestDate As String, _
                            ByVal pDataSeq As Int16, _
                            ByVal pBarcode As String, _
                            ByVal pParaName As String, _
                            ByVal pTestResult As String, _
                            ByVal pMeasureUnit As String, _
                            ByVal pNormalLevel As String, _
                            ByVal pNormalLevelW As String) As Boolean

        Dim cmd As New SqlCommand

        Try
            Try
                If methodConnection.State <> ConnectionState.Open Then methodConnection.Open()
            Catch ex As Exception
                File.AppendAllText("D:\LOG\DB_Connection_Error.txt", Now.ToString & "     spInsertResult" & vbCrLf)
                Return False
            End Try

            Dim dt As New DataTable
            dt.Columns.Add("CommandText")
            dt.Columns.Add("pTest_ID")
            dt.Columns.Add("pPatient_ID")
            dt.Columns.Add("pTestType_ID")
            dt.Columns.Add("pTestSeq")
            dt.Columns.Add("pTestDate")
            dt.Columns.Add("pDataSeq")
            dt.Columns.Add("pBarcode")
            dt.Columns.Add("pParaName")
            dt.Columns.Add("pTestResult")
            dt.Columns.Add("pMeasureUnit")
            dt.Columns.Add("pNormalLevel")
            dt.Columns.Add("pNormalLevelW")
            Dim dr As DataRow = dt.NewRow

            With cmd
                .Connection = methodConnection
                .CommandText = "spInsertUpdateTestResult"
                .CommandType = CommandType.StoredProcedure
                dr(0) = "spInsertUpdateTestResult"

                .Parameters.Add("pTest_ID", SqlDbType.BigInt).Direction = ParameterDirection.Input
                .Parameters("pTest_ID").Value = pTestID
                dr(1) = pTestID.ToString

                .Parameters.Add("pPatient_ID", SqlDbType.BigInt).Direction = ParameterDirection.Input
                .Parameters("pPatient_ID").Value = pPatientID
                dr(2) = pPatientID.ToString

                .Parameters.Add("pTestType_ID", SqlDbType.Int).Direction = ParameterDirection.Input
                .Parameters("pTestType_ID").Value = pTestTypeID
                dr(3) = pTestTypeID.ToString


                .Parameters.Add("pTestSeq", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Input
                .Parameters("pTestSeq").Value = " " 'pTestSeq
                dr(4) = .Parameters("pTestSeq").Value.ToString


                .Parameters.Add("pTestDate", SqlDbType.NVarChar, 15).Direction = ParameterDirection.Input
                .Parameters("pTestDate").Value = pTestDate
                dr(5) = pTestDate.ToString

                .Parameters.Add("pDataSeq", SqlDbType.Int).Direction = ParameterDirection.Input
                .Parameters("pDataSeq").Value = pDataSeq
                dr(6) = pDataSeq.ToString


                .Parameters.Add("pBarcode", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Input
                .Parameters("pBarcode").Value = pBarcode
                dr(7) = pBarcode.ToString

                .Parameters.Add("pParaName", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Input
                .Parameters("pParaName").Value = pParaName
                dr(8) = pParaName.ToString


                .Parameters.Add("pTestResult", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Input
                .Parameters("pTestResult").Value = pTestResult
                dr(9) = pTestResult.ToString

                .Parameters.Add("pMeasureUnit", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Input
                .Parameters("pMeasureUnit").Value = IIf(pMeasureUnit Is Nothing, " ", pMeasureUnit)
                dr(10) = .Parameters("pMeasureUnit").Value.ToString

                .Parameters.Add("pNormalLevel", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Input
                .Parameters("pNormalLevel").Value = IIf(pNormalLevel Is Nothing, " ", pNormalLevel)
                dr(11) = .Parameters("pNormalLevel").Value.ToString


                .Parameters.Add("pNormalLevelW", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Input
                .Parameters("pNormalLevelW").Value = IIf(pNormalLevelW Is Nothing, " ", pNormalLevelW)

                .Parameters.Add("pPortNum", SqlDbType.Int).Direction = ParameterDirection.Input
                .Parameters("pPortNum").Value = DBNull.Value

                dr(12) = .Parameters("pNormalLevelW").Value.ToString

                dt.Rows.Add(dr)
                dt.NewRow()
                dt.NewRow()

                Utilities.WriteDataTableToFile(dt, "C:\LOG\" & Now.ToString("dd-MM-yyyy hh-mm") & "-" & pBarcode & ".txt", True)


                .ExecuteNonQuery()
            End With
            Return True
        Catch ex As Exception
            File.AppendAllText("D:\LOG\DB_Connection_Error.txt", Now.ToString & "     spInsertUpdateTestResult - - - Lỗi Khác" & vbCrLf & ex.Message & vbCrLf _
                               & pTestDate & vbCrLf _
                               & pBarcode & vbCrLf _
                               & pParaName & vbCrLf _
                               & pTestResult & vbCrLf)
            Return False
        Finally
            'methodConnection.Dispose()
            cmd.Dispose()
        End Try

    End Function

    Private Sub chkUnit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnit.CheckedChanged
        If chkUnit.Checked = True Then
            cboUnit.Visible = True
            FillDonVi()
        Else
            cboUnit.Visible = False
        End If
    End Sub

    Private Sub cmdImportList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImportList.Click
        If sheetsToolStripComboBox.SelectedItem Is Nothing Then
            Return
        End If
        Try

            If _tblPatientList.Columns.Count > 4 Then
                _tblPatientList.Clear()
            End If
            _tblPatientList = GetWorksheet(connectionString, sheetsToolStripComboBox.SelectedItem.ToString())
            lbStatus.Text = "Loading.."
            If _tblPatientList.Columns.Count <= 2 Then
                grdListPatient.DataSource = Nothing
                btnInsert.Enabled = False
                Return
            End If
            ChangeHeaderTable(_tblPatientList, False)
            ValidateImportedData(_tblPatientList, True, False)
            grdListPatient.DataSource = _tblPatientList
            If grdListPatient.Columns.Contains("NameNoSign") Then
                grdListPatient.Columns("NameNoSign").Visible = False
            End If
            If grdListPatient.Columns.Contains("YearBirth") Then
                grdListPatient.Columns("YearBirth").Visible = False
            End If
            If grdListPatient.Columns.Contains("Patient_Name") Then
                grdListPatient.Columns("Patient_Name").Visible = True
            End If
            ckRemoveSign.Checked = False
            rbUpperAll.Checked = False


            rbCheckAll.Checked = True
            ckLot.Checked = False

            If grdListPatient.Rows.Count > 0 Then
                GroupBox1.Enabled = True
                GroupBox2.Enabled = True
                GroupBox3.Enabled = True
                GroupBox4.Enabled = True
                GroupBox5.Enabled = True
                grbListPatient.Enabled = True
                grbListTestType.Enabled = True
                cboObjType.Enabled = True
                grbLot.Enabled = True
                grbExtent.Enabled = True
                grbSelection.Enabled = True
                grdTestType.Enabled = True
                grdTestDetail.Enabled = True

                btnInsert.Enabled = True
            Else
                GroupBox1.Enabled = False
                GroupBox2.Enabled = False
                GroupBox3.Enabled = False
                GroupBox4.Enabled = False
                GroupBox5.Enabled = False
                grbListPatient.Enabled = False
                grbListTestType.Enabled = False
                cboObjType.Enabled = False
                grbLot.Enabled = False
                grbExtent.Enabled = False
                grbSelection.Enabled = False
                grdTestType.Enabled = False
                grdTestDetail.Enabled = False
                btnInsert.Enabled = False
            End If
            cmdImportList.Enabled = False

            chkUnit.Enabled = True
            lbStatus.Text = "Tổng số: " & _tblPatientList.Rows.Count.ToString & " bệnh nhân"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sheetsToolStripComboBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sheetsToolStripComboBox.Click
        cmdImportList.Enabled = True
    End Sub

    Private Sub rbReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReverse.CheckedChanged
        If _tblPatientList.Rows.Count <= 0 Then
            Exit Sub
        End If

        For Each dr As DataRow In _tblPatientList.Rows
            dr("Check") = dr("Check") <> True
        Next
        _tblPatientList.AcceptChanges()

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cmdImportList.PerformClick()
    End Sub

    Private Sub btnOpenFileUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFileUpdate.Click
        Try
            Dim objOpenFileDialog As New OpenFileDialog
            objOpenFileDialog.Filter = _
                "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx|All Files (*.*)|*.*"
            objOpenFileDialog.FilterIndex = 1

            If objOpenFileDialog.ShowDialog() = DialogResult.OK Then
                txtFileNameUpdate.Text = objOpenFileDialog.FileName
            Else
                Return
            End If
            workSheetNames_2 = OpenExcelFile(txtFileNameUpdate.Text, connStrUpdate)
            cboSheetUpdate.Items.Clear()

            Dim sheetName As String
            For Each sheetName In workSheetNames_2
                cboSheetUpdate.Items.Add(sheetName)
            Next

            cboSheetUpdate.SelectedIndex = -1
            _tblPatientList2.Clear()

            lbStatus.Text = "Select sheet to load data."

        Catch ex As Exception
            MessageBox.Show("File excel không hợp lệ hoặc File đang được mở bởi chương trình khác", "Lỗi", MessageBoxButtons.OK, _
                             MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdImportListUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImportListUpdate.Click
        If cboSheetUpdate.SelectedItem Is Nothing Then
            Return
        End If

        Try
            If _tblPatientListUpdate.Columns.Count > 4 Then
                _tblPatientListUpdate.Clear()
            End If
            _tblPatientListUpdate = GetWorksheet(connStrUpdate, cboSheetUpdate.SelectedItem.ToString())

            If _tblPatientListUpdate.Columns.Count <= 2 Then
                grdListPatientUpdate.DataSource = Nothing
                Return
            End If
            _tblPatientListUpdate.Columns("Năm Sinh").ColumnName = "DOB"
            ChangeHeaderTable(_tblPatientListUpdate, True)
            ValidateImportedData(_tblPatientListUpdate, True, True)

            For Each dr As DataRow In _tblPatientListUpdate.Rows
                dr("PID") = ModBusinessHelper.GetPatientIdFromBarcode(dr("Barcode").ToString().Trim())
                If String.IsNullOrEmpty(dr("DOB").ToString) Then
                    dr("DOB") = ""
                    dr("YearBirth") = ""
                    dr("Age") = ""
                    '_return = False
                ElseIf IsDBnullOrNothing(dr("Age")) Then
                    Try
                        If IsNumeric(dr("DOB")) Then
                            dr("Age") = Convert.ToString(Now.Year - Convert.ToInt16(dr("DOB").ToString))
                            dr("YearBirth") = dr("DOB")
                            dr("DOB") = ""
                            dr("Check") = True
                        ElseIf IsDate(dr("DOB")) Then
                            dr("DOB") = dr("DOB").ToString.Substring(0, 10)
                            dr("YearBirth") = dr("DOB").ToString.Substring(6, 4)
                            dr("Age") = Convert.ToString(Now.Year - Convert.ToInt16(Convert.ToInt16(dr("DOB").ToString.Substring(6, 4))))
                            dr("Check") = True
                        Else
                            dr("YearBirth") = ""
                            dr("Age") = ""
                        End If
                    Catch ex As Exception
                        dr("Age") = ""
                        dr("YearBirth") = ""
                        dr("Check") = False
                    End Try
                End If

                dr("check") = IIf(String.IsNullOrEmpty(Utility.sDbnull(dr("PID")).Trim()), 0, 1)
            Next

            grdListPatientUpdate.DataSource = _tblPatientListUpdate
            If grdListPatientUpdate.Columns.Contains("NameNoSign") Then
                grdListPatientUpdate.Columns("NameNoSign").Visible = False
            End If
            If grdListPatientUpdate.Columns.Contains("YearBirth") Then
                grdListPatientUpdate.Columns("YearBirth").Visible = False
            End If
            If grdListPatientUpdate.Columns.Contains("Patient_Name") Then
                grdListPatientUpdate.Columns("Patient_Name").Visible = True
            End If

            'Xử lý chọn


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnInsertUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertUpdate.Click

        For Each dr As DataGridViewRow In grdListPatientUpdate.Rows
            On Error Resume Next

            If Not dr.Cells("check").Value Then Continue For

            Dim pid As Integer

            pid = Convert.ToInt32(Utility.sDbnull(dr.Cells(1).Value))
            If pid <= 0 Then Continue For

            Dim patientName As String
            Dim address As String
            Dim strdob As String
            Dim sex As Boolean
            Dim diagnostic As String
            Dim insuranceNum As String
            Dim stryearbirth As String

            patientName = Utility.sDbnull(dr.Cells(4).Value)
            address = Utility.sDbnull(dr.Cells(6).Value)

            strdob = Utility.sDbnull(dr.Cells(7).Value)
            sex = IIf(Utility.sDbnull(dr.Cells(8).Value).ToUpper() = "NAM", 1, 0)
            diagnostic = Utility.sDbnull(dr.Cells(9).Value)
            insuranceNum = Utility.sDbnull(dr.Cells(10).Value)
            stryearbirth = Utility.sDbnull(dr.Cells(12).Value)
            Dim p As New LPatientInfo(pid)
            p.IsNew = False
            If Not String.IsNullOrEmpty(patientName) Then p.PatientName = patientName
            p.Address = address
            If Not String.IsNullOrEmpty(strdob) Then p.Dob = ConvertDate(strdob)
            p.Sex = sex
            p.Diagnostic = diagnostic
            p.InsuranceNum = insuranceNum
            If Not String.IsNullOrEmpty(stryearbirth) Then p.YearBirth = Convert.ToInt32(stryearbirth)
            p.Save()
            dr.Cells("Status").Value = "Updated"
            dr.Cells("check").Value = False
        Next
        MsgBox("Cập nhật dữ liệu thành công", vbOKOnly, "Thông Báo")
    End Sub

    Private Sub FrmImportFromExcel_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Dispose(True)
        End Select
    End Sub

    Private Sub rdUncheckTest_CheckedChanged(sender As Object, e As EventArgs) Handles rdUncheckTest.CheckedChanged
        If tblDataConTrol.Rows.Count <= 0 Then
            Exit Sub
        End If

        For Each dr As DataRow In tblDataConTrol.Rows
            dr("Check") = dr("Check") <> True
        Next
        tblDataConTrol.AcceptChanges()
    End Sub

    Private Sub rdChonTest_CheckedChanged(sender As Object, e As EventArgs) Handles rdChonTest.CheckedChanged
        If rbCheckAll.Checked Then
            For Each dr As DataRow In tblDataConTrol.Rows
                dr("Check") = True
            Next
        End If
    End Sub
End Class