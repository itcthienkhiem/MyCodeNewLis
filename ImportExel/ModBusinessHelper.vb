Imports System.IO
Imports Lis.DAL
Imports System.Data.SqlClient
Imports SubSonic
Imports Vietbait
Imports Vietbait.Lablink.TestInformation.UI

Imports System.Text
Imports System.Runtime.InteropServices

Imports System.Reflection
Imports System.Drawing.Imaging
Module ModBusinessHelper

    Public AppPath As String = My.Application.Info.DirectoryPath + "\"
    Private gv_sConnString As String
    Private gv_sBranchID As String
    Private gv_sDBName As String
    Private gv_sDBAdrr As String
    Private Const gv_sAnnouncement As String = "Thông báo"
    Private ReadOnly privateConnection As SqlConnection = GetDBConnection()
    Public gv_sUID As String
    Public gv_sParentBranchName As String
    Public gv_sBranchName As String
    Public gv_sPhone As String
    Public gv_sAddress As String
#Region "Private Method"
    Dim fv_sSqlConstr = ""
    'Read from Config.xml
    Private Function bGetConfigInfor(ByVal ConfigFileName As String, ByRef pv_sUID As String, ByRef pv_sPWD As String, ByRef fv_sUID As String, ByRef fv_sPWD As String) As Boolean
        Dim fv_DS As New DataSet
        'Dim filepath = Apppath & "\Config.XML"
        Dim filepath = AppPath & "\" & ConfigFileName
        Try
            If File.Exists(filepath) Then
                ' Tiến hành đọc File cấu hình vào DataSet
                fv_DS.ReadXml(filepath)
                If fv_DS.Tables(0).Rows.Count > 0 Then
                    ' Đọc dữ liệu vào các biến toàn cục
                    'Địa chỉ máy chủ CSDL
                    gv_sDBAdrr = fv_DS.Tables(0).Rows(0)("SERVERADDRESS")
                    'Mã chi nhánh
                    gv_sBranchID = fv_DS.Tables(0).Rows(0)("BranchID")
                    'UID côngkhai
                    fv_sUID = fv_DS.Tables(0).Rows(0)("USERNAME")
                    'Mật khẩu công khai
                    fv_sPWD = fv_DS.Tables(0).Rows(0)("PASSWORD")
                    'Tên Cơ sở dữ liệu
                    gv_sDBName = fv_DS.Tables(0).Rows(0)("DATABASE_ID")
                    'Ngôn ngữ hiển thị

                    'Tiến hành kết nối bằng tài khoản công khai vừa đọc trong file Config để lấy về tài khoản đăng nhập CSDL
                    Dim fv_oSQLCon As SqlConnection
                    fv_sSqlConstr = "workstation id=" & gv_sDBAdrr & ";packet size=4096;data source=" & gv_sDBAdrr & ";persist security info=False;initial catalog=" & gv_sDBName & ";uid=" & fv_sUID & ";pwd=" & fv_sPWD
                    fv_oSQLCon = New SqlConnection(fv_sSqlConstr)
                    'Mở CSDL
                    Try
                        fv_oSQLCon.Open()
                    Catch SQLex As Exception
                        MessageBox.Show("Không đăng nhập được vào CSDL " & gv_sDBName & " bằng tài khoản công khai(UID=" & fv_sUID & ";PWD=" & fv_sPWD & "). Hãy cấu hình lại File Config.XML sau đó đăng nhập lại.", gv_sAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End Try
                    Try
                        '  GetSecretAccount(fv_oSQLCon, pv_sUID, pv_sPWD)
                    Catch ex As Exception
                        'Lấy tài khoản bí mật để đăng nhập CSDL
                        MessageBox.Show("Không đăng nhập được vào CSDL " & gv_sDBName & " bằng tài khoản bí mật. Hãy cấu hình lại File Config.XML sau đó đăng nhập lại.", gv_sAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End Try
                Else
                    'MessageBox.Show("Không có dữ liệu trong File cấu hình! Bạn hãy xem lại", gv_sAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Else
                MessageBox.Show("Không tồn tại File cấu hình có tên: Config.XML!", gv_sAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function
    ''' <summary>
    ''' Gets all test type list.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetAllTestTypeList() As DataTable
        Try
            Return New [Select]().From(TTestTypeList.Schema.Name).ExecuteDataSet().Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
    Public Function GetDBConnection(Optional ByVal ConfigFileName As String = "Config.xml") As SqlConnection
        Dim gv_WLConn As New SqlConnection
        'Dim sv_oEncrypt As New Encrypt.Encrypt("Rijndael")
        Dim sv_oEncrypt As New Encrypt("Rijndael")
        Dim UID As String = ""
        Dim PW As String = ""
        Dim fv_sUID As String
        Dim fv_sPWD As String
        If bGetConfigInfor(ConfigFileName, UID, PW, fv_sUID, fv_sPWD) Then
            ' Dim cnns As String = "workstation id=" & gv_sDBAdrr & ";packet size=4096;data source=" & gv_sDBAdrr & ";persist security info=False;initial catalog=" & gv_sDBName & ";uid=" & sv_oEncrypt.GiaiMa(UID) & ";pwd=" & sv_oEncrypt.GiaiMa(PW)

            gv_WLConn.ConnectionString = Cnns
            Try
                gv_WLConn.Open()
            Catch ex As Exception
                cnns = "workstation id=" & gv_sDBAdrr & ";packet size=4096;data source=" & gv_sDBAdrr & ";persist security info=False;initial catalog=" & gv_sDBName & ";uid=" & fv_sUID & ";pwd=" & fv_sPWD
                gv_WLConn.ConnectionString = cnns
                gv_WLConn.Open()
            End Try
        End If

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter("SELECT * FROM sys_ManagementUnit WHERE PK_sBranchID=N'" & gv_sBranchID & "'", gv_WLConn)
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                gv_sParentBranchName = sDBnull(dt.Rows(0)("sParentBranchName"))
                gv_sPhone = sDBnull(dt.Rows(0)("sPhone"))
                gv_sAddress = sDBnull(dt.Rows(0)("sAddress"))
                gv_sBranchName = sDBnull(dt.Rows(0)("sName"))
            End If
        Catch ex As Exception
            MsgBox("Không lấy được thông tin đơn vị quản lý " & vbCrLf & ex.Message)
        End Try

        Return gv_WLConn
    End Function

    Public Function GetDBConnectionString(Optional ByVal ConfigFileName As String = "Config.xml") As String
        Dim gv_WLConn As New SqlConnection
        'Dim sv_oEncrypt As New Encrypt.Encrypt("Rijndael")
        Dim sv_oEncrypt As New Encrypt("Rijndael")
        Dim UID As String = ""
        Dim PW As String = ""
        Dim fv_sUID As String
        Dim fv_sPWD As String
        Dim cnns As String
        If bGetConfigInfor(ConfigFileName, UID, PW, fv_sUID, fv_sPWD) Then
            cnns = "workstation id=" & gv_sDBAdrr & ";packet size=4096;data source=" & gv_sDBAdrr & ";persist security info=False;initial catalog=" & gv_sDBName & ";uid=" & sv_oEncrypt.GiaiMa(UID) & ";pwd=" & sv_oEncrypt.GiaiMa(PW)
            gv_WLConn.ConnectionString = cnns
            Try
                gv_WLConn.Open()
            Catch ex As Exception
                cnns = "workstation id=" & gv_sDBAdrr & ";packet size=4096;data source=" & gv_sDBAdrr & ";persist security info=False;initial catalog=" & gv_sDBName & ";uid=" & fv_sUID & ";pwd=" & fv_sPWD
                gv_WLConn.ConnectionString = cnns
                gv_WLConn.Open()
            End Try
        End If
        Return cnns
    End Function
   
    ''' <summary>
    ''' Trả về số thứ tự của Test trong bảng đăng ký
    ''' </summary>
    ''' <param name="testTypeId">The test type id.</param>
    ''' <returns></returns>
    Private Function GetIntOrder(ByVal testTypeId As Integer) As String
        Try
            Dim query = New [Select](TTestTypeList.Columns.IntOrder).Top("1").From(TTestTypeList.Schema.TableName).Where(TTestTypeList.Columns.TestTypeId).IsEqualTo(testTypeId).ExecuteScalar()
            Return String.Format("0{0}", query)
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Hàm kiểm tra xem một bệnh nhân đã đăng ký loại xét nghiệm nào đó hay chưa 
    ''' </summary>
    ''' <param name="patient">The patient.</param>
    ''' <param name="testtypeId">The testtype id.</param>
    ''' <returns>True:Nếu đã đăng ký False:Nếu chưa đăng ký</returns>
    Private Function TestInfoIsRegisted(ByVal patient As Integer, ByVal testtypeId As Integer) As Boolean
        Try
            Dim count As Integer = New [Select](TTestInfo.Columns.TestId).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.PatientId).IsEqualTo(patient).And(TTestInfo.Columns.TestTypeId).IsEqualTo(testtypeId).GetRecordCount()
            Return count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Tạo Barcode cho bệnh nhân
    ''' </summary>
    ''' <param name="patientId">The patient id.</param>
    ''' <param name="testTypeId">The test type id.</param>
    ''' <param name="intOrder">The int order.</param>
    ''' <param name="regDate">The reg date.</param>
    ''' <param name="barcodedigit">The barcodedigit.</param>
    ''' <returns></returns>
    Private Function GetBarcode(ByVal patientId As Integer, ByVal testTypeId As Integer, ByVal intOrder As String, ByVal regDate As DateTime) As String
        Try
            Dim vBarcode As String
            'Xử lý thêm cho JCLV (Nếu biến USEREGDATETOGENERATEBARCODE = 1 thì sử dụng ngày đăng ký để tạo barcode)
            If SysPara.UseRegDateToGenerateBarcode = 1 Then
                vBarcode = Convert.ToString(SPs.SpGetMaxBarcodeV2(testTypeId, patientId, 0, regDate.ToString("yyMMdd")).GetDataSet().Tables(0)(0)(0))
            Else
                vBarcode = Convert.ToString(SPs.SpGetMaxBarcodeV2(testTypeId, patientId, 0, "").GetDataSet().Tables(0)(0)(0))
            End If

            'Dim vBarcode As String = Convert.ToString(SPs.SpGetMaxBarcodeV2(testTypeId, patientId, 0, Utility.sDbnull(grdPatientList.GetValue("Barcode").ToString().Substring(0, 6), "")).GetDataSet().Tables(0)(0)(0))
            If vBarcode <> "-1" Then
                If IsNumeric(vBarcode) Then vBarcode = (Convert.ToInt64(vBarcode) + 1).ToString()
            End If

            If vBarcode.Length = 12 Then
                vBarcode = vBarcode.Remove(6, 2)
            End If
            If SysPara.BarcodeDigit = 12 Then
                If IsNumeric(vBarcode) Then vBarcode = vBarcode.Insert(6, intOrder)
            End If
            Return vBarcode
        Catch ex As Exception
            Return "-1"
        End Try
    End Function

    ''' <summary>
    ''' Inserts the test info.
    ''' </summary>
    ''' <param name="tesTypeId">The type id.</param>
    ''' <param name="patientId">The patient id.</param>
    ''' <param name="barcode">The barcode.</param>
    ''' <returns></returns>
    Public Function InsertTestInfo(ByVal tesTypeId As Integer, ByVal patientId As Integer, ByVal testDate As DateTime, ByVal barcode As String) As Boolean
        Try
            Dim counttest As DataTable = New [Select]().From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.PatientId).IsEqualTo(patientId).And(TTestInfo.Columns.TestTypeId).IsEqualTo(tesTypeId).ExecuteDataSet().Tables(0)
            If (counttest.Rows.Count <= 0) Then
                Dim obj As New TTestInfo
                obj.Barcode = barcode
                obj.PatientId = patientId
                obj.TestTypeId = tesTypeId
                obj.TestDate = testDate.Date
                obj.RequireDate = DateTime.Now
                obj.UpdateDate = DateTime.Now
                obj.UpdateUser = Utilities.gv_sUID
                obj.AssignId = -1
                obj.DiagnosticianId = -1
                obj.TestStatus = 0
                obj.IsNew = True
                obj.Save()
                Return True
            Else
                Dim update = New Update(TTestInfo.Schema.Name).Set(TTestInfo.Columns.Barcode).EqualTo(barcode).Set(TTestInfo.Columns.TestTypeId).EqualTo(tesTypeId).Set(TTestInfo.Columns.TestDate).EqualTo(testDate.Date).Set(TTestInfo.Columns.RequireDate).EqualTo(DateTime.Now).Set(TTestInfo.Columns.UpdateDate).EqualTo(DateTime.Now).Set(TTestInfo.Columns.UpdateUser).EqualTo(Utilities.gv_sUID).Where(TTestInfo.Columns.PatientId).IsEqualTo(patientId).Execute()
                Return True
            End If
        
        Catch ex As Exception
            'Try
            '    Dim obj As New TTestInfo
            '    obj.Barcode = barcode
            '    obj.PatientId = patientId
            '    obj.TestTypeId = tesTypeId
            '    obj.TestDate = testDate.Date
            '    obj.RequireDate = DateTime.Now
            '    obj.UpdateDate = DateTime.Now
            '    obj.AssignId = -1
            '    obj.DiagnosticianId = -1
            '    obj.TestStatus = 0
            '    obj.IsNew = True
            '    obj.Save()
            '    Return True
            'Catch ex2 As Exception
            '    Return False
            'End Try
            MsgBox("Loi Insert TestInfor " & vbCrLf & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Cập nhất đăng ký chi tiết. Nếu biến Save=true thì thêm mới
    ''' </summary>
    ''' <param name="testid">The testid.</param>
    ''' <param name="testDataId">The test data id.</param>
    ''' <param name="save">if set to <c>true</c> [save].</param>
    ''' <returns></returns>
    Public Function UpdateRegTestList(ByVal testid As Integer, ByVal testDataId As String, ByVal save As Boolean) As Boolean
        Try
            'Thêm mới đăng ký
            If save Then
                'Kiểm tra bản ghi xem đã tồn tại trong CSDL chưa
                Dim count = New SubSonic.Select(TRegList.Columns.TestId).From(TRegList.Schema.Name).Where(TRegList.Columns.TestId).IsEqualTo(testid).And(TRegList.Columns.TestDataId).IsEqualTo(testDataId).GetRecordCount()
                'Nếu đã tồn tại thì dừng luôn
                If count > 0 Then
                    Return True
                Else
                    Dim deviceId As Integer
                    Try
                        deviceId = New [Select](DDataControl.Columns.DeviceId).From(DDataControl.Schema.Name).Where( _
                            DDataControl.Columns.AliasName).IsEqualTo(testDataId).ExecuteScalar()
                    Catch ex As Exception
                        deviceId = -1
                    End Try


                    Dim reg As New TRegList
                    With reg
                        .IsNew = True
                        .TestId = testid
                        .AliasName = testDataId
                        .Barcode = GetBarcodeFromTestId(testid)
                        .ParaName = GetDataNameFromTestDataId(testDataId)
                        .Status = IIf(GetPrintStatusFromTestDataId(testDataId), 0, 1)
                        .DeviceId = deviceId
                        .TestDataId = testDataId
                        .Save()
                    End With
                    Return True
                End If
                'Xóa dữ liệu
            Else
                Dim query As SqlQuery = New Delete().From(TRegList.Schema.Name).Where(TRegList.Columns.TestId).IsEqualTo(testid).And(TRegList.Columns.TestDataId).IsEqualTo(testDataId)
                query.Execute()
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Public Method"

    ''' <summary>
    ''' Trả về trạng thái của một chi tiết:0-Chưa được đăng ký, 1:đã đăng ký, 2:đã có kết quả
    ''' </summary>
    ''' <param name="patient">The patient.</param>
    ''' <param name="testtypeId">The testtype id.</param>
    ''' <returns></returns>
    Public Function GetTestDetailStatus(ByVal testId As Integer, ByVal testDataId As String, ByVal pTestDataName As String) As Integer
        Try
            Dim result As Integer
            Dim count As Integer = New [Select](TRegList.Columns.TestRegDetailId).From(TRegList.Schema.Name).Where( _
                        TRegList.Columns.TestId).IsEqualTo(testId).And(TRegList.Columns.TestDataId).IsEqualTo( _
                            testDataId).ExecuteScalar()
            If count = 0 Then
                result = 0 'Xét nghiệm chưua được đăng ký
            Else
                result = 1 'Xét nghiệm đã được đăng ký.
            End If
            Dim tempStr As String = GetParaNameFromTestDataId(testDataId)

            count = New [Select]().From(TResultDetail.Schema.Name).Where(TResultDetail.Columns.TestId).IsEqualTo(testId).And( _
                    TResultDetail.Columns.ParaName).IsEqualTo(tempStr).GetRecordCount()

            If count > 0 Then result = 2

            Return result

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetParaNameFromTestDataId(ByVal testDataId As String) As Object
        Try
            Return New [Select](LStandardTest.Columns.DataName).From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.TestDataId).IsEqualTo(testDataId).ExecuteScalar()
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Hàm Tìm kiếm bệnh nhân
    ''' </summary>
    ''' <param name="pfromDate">Ngày bắt đầu</param>
    ''' <param name="pToDate">Ngày kết thúc</param>
    ''' <returns>Bảng dữ liệu: Lỗi trả về Nothing </returns>
    Public Function FindPatientFromDateToDate(ByVal pfromDate As DateTime, ByVal pToDate As DateTime) As DataTable
        Try
            Return SPs.SpGetPatientListByDate(pfromDate, pToDate).GetDataSet().Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Inserts the test info for patient.
    ''' </summary>
    ''' <param name="patientId">The patient id.</param>
    ''' <param name="testTypeId">The test type id.</param>
    ''' <param name="regDate">The reg date.</param>
    ''' <param name="barcode">The barcode.</param>
    ''' <param name="testId">The test id.</param>
    ''' <param name="messageOutput">The message output.</param>
    Public Sub InsertTestInfoForPatient(ByVal patientId As Integer, ByVal testTypeId As Integer, ByVal regDate As DateTime, ByRef barcode As String, _
                                   ByRef testId As Integer, ByRef messageOutput As String)
        Try
            Dim barcodedigit As Integer = SysPara.BarcodeDigit
            Dim autoGenerateBarcode As Integer = SysPara.AutoGenerateBarcode
            Dim intOrder As String = IIf(barcodedigit = 12, GetIntOrder(testTypeId), "")

            'If autoGenerateBarcode = 0 Then
            '    Dim frm As New frmInputBarcode
            '    frm.barcodeDigit = barcodedigit
            '    frm.intOrder = intOrder
            '    frm.ShowDialog()
            '    barcode = frm.txtBarcode.Text()
            '    If barcode = String.Empty Then
            '        Exit Sub
            '    End If
            ' Else
            'Lấy về Barcode đăng ký

            If SysPara.UseOneBarcodeForPatient Then
                If TestInfoIsRegisted(patientId, testTypeId) Then
                    messageOutput = "Test đã được đăng ký !"
                    Exit Sub
                Else
                    If barcode = "" Then barcode = GetBarcode(patientId, testTypeId, intOrder, regDate)
                End If
                'Else
                '    barcode = GetBarcode(patientId, testTypeId, intOrder, regDate)
                'End If

                If barcode = "-1" Then
                    messageOutput = "Test đã được đăng ký !"
                    barcode = String.Empty
                    Exit Sub
                End If
            End If

            If (barcode <> String.Empty) And (barcode <> "-1") Then
                If Not InsertTestInfo(testTypeId, patientId, regDate, barcode) Then Exit Sub
                testId = TTestInfo.CreateQuery().GetMax(TTestInfo.Columns.TestId)
            End If

        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Xác định một loại Test có phải là Test được đăng ký hai chiều hay không
    ''' </summary>
    ''' <param name="testTypeId">The test type id.</param>
    ''' <returns>
    '''   <c>true</c> if [is bi directional test] [the specified test type id]; otherwise, <c>false</c>.
    ''' </returns>
    Public Function IsBiDirectionalTest(ByVal testTypeId As Integer) As Boolean
        Try
            Dim dtBiDataControl = New [Select](DDataControl.Schema.Name & ".*", DDeviceList.Columns.TestTypeId).From(DDataControl.Schema.Name).InnerJoin(DDeviceList.DeviceIdColumn, DDataControl.DeviceIdColumn).Where(DDeviceList.Columns.Valid).IsEqualTo(1).And(DDeviceList.Columns.DeviceControl).IsEqualTo(1).And(DDeviceList.Columns.TestTypeId).IsEqualTo(testTypeId).OrderAsc(DDataControl.Columns.DataName).GetRecordCount()
            Return dtBiDataControl > 0
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Kiểm tra xem một loại xét nghiệm đã có kết quả chưa ?
    ''' </summary>
    ''' <param name="testId">The test id.</param>
    ''' <returns>
    '''   <c>true</c> if the specified test id has result; otherwise, <c>false</c>.
    ''' </returns>
    Public Function TestInfoHasResult(ByVal testId As String) As Boolean
        Try
            Return New [Select]().From(TResultDetail.Schema.Name).Where(TResultDetail.Columns.TestId).IsEqualTo(testId).GetRecordCount() > 0
        Catch ex As Exception
            Return True
        End Try
    End Function

    ''' <summary>
    ''' Xóa dữ liệu từ bảng
    ''' </summary>
    ''' <param name="sTableName">Bảng dữ liệu cần xóa</param>
    ''' <param name="sFieldName">Trường dữ liệu cần so sánh</param>
    ''' <param name="sValue">Giá trị so sánh</param>
    ''' <returns></returns>
    Public Function DeleteSubsonic(ByVal sTableName As TableSchema.Table, ByVal sFieldName As String, ByVal sValue As Integer) As Boolean
        Try
            Dim vQuery As Query = New Query(sTableName).WHERE(sFieldName, sValue)
            vQuery.QueryType = QueryType.Delete
            vQuery.Execute()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Trả về bảng đăng ký xét nghiệm của bệnh nhân
    ''' </summary>
    ''' <param name="patientId">The patient id.</param>
    ''' <param name="fromDate">From date.</param>
    ''' <param name="toDate">To date.</param>
    ''' <returns></returns>
    Public Function GetTestTypeandTReglistForPatient(ByVal patientId As Integer, ByVal fromDate As DateTime, ByVal toDate As DateTime) As DataTable
        Return SPs.SpGetTestTypeandTReglist(patientId, fromDate, toDate).GetDataSet().Tables(0)
    End Function
    Public Function GetpatientId(ByVal barcode As String) As Integer
        Dim PatientId = New [Select](TTestInfo.Columns.PatientId).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.Barcode).IsEqualTo(barcode.Trim()).ExecuteScalar()
        Try
            Return Convert.ToInt64(PatientId)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Hàm trả về TestID 
    ''' </summary>
    ''' <param name="barcode">The barcode.</param>
    ''' <param name="testtypeId">The testtype id.</param>
    ''' <returns></returns>
    Public Function GetTestIdFromBarcodeAndTestTypeId(ByVal patientId As String, ByVal testtypeId As String) As Integer
        Dim testId = New [Select](TTestInfo.Columns.TestId).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.PatientId).IsEqualTo(patientId).And(TTestInfo.Columns.TestTypeId).IsEqualTo(testtypeId).ExecuteScalar()
        Try
            Return Convert.ToInt32(testId)
        Catch ex As Exception
            Return -1
        End Try
    End Function
    'Public Function GetBarcodeFromPatientId(ByVal patientId As String) As String
    '    Dim barcode = New [Select](TTestInfo.Columns.Barcode).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.PatientId).IsEqualTo(patientId).ExecuteScalar()
    '    Try
    '        Return (barcode).ToString()
    '    Catch ex As Exception
    '        Return -1
    '    End Try
    'End Function
    Public Function GetTestIdFromPatientIdAndTestTypeId(ByVal patientId As String, ByVal testtypeId As String) As Integer
        Dim testId = New [Select](TTestInfo.Columns.TestId).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.PatientId).IsEqualTo(patientId).And(TTestInfo.Columns.TestTypeId).IsEqualTo(testtypeId).ExecuteScalar()
        Try
            Return Convert.ToInt32(testId)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Lấy về danh sách phòng ban
    ''' </summary>
    ''' <returns></returns>
    Public Function GetAllDepartment() As DataTable
        Try
            Dim dtDepartment As DataTable = New SubSonic.Select("*").From(LDepartment.Schema.Name).ExecuteDataSet.Tables(0)
            Dim dr As DataRow = dtDepartment.NewRow()
            dr(LDepartment.Columns.SName) = "----- Chọn -----"
            dr(LDepartment.Columns.Id) = -1
            dtDepartment.Rows.InsertAt(dr, 0)
            Return dtDepartment
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Lấy về danh sách các đối tượng
    ''' </summary>
    ''' <returns></returns>
    Public Function GetAllObjectType() As DataTable
        Try
            Return New SubSonic.Select("*").From("L_ObjectType").ExecuteDataSet.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the test type id from test id. Return -1 if has some Error
    ''' </summary>
    ''' <param name="testId">The test id.</param>
    ''' <returns></returns>
    Public Function GetTestTypeIdFromTestId(ByVal testId As Integer) As Integer
        Try
            Dim result = New SubSonic.Select(TTestInfo.Columns.TestTypeId).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.TestId).IsEqualTo(testId).ExecuteScalar()
            Return Convert.ToInt32(result)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Gets the test type name from test type id. Return Empty if has some error
    ''' </summary>
    ''' <param name="testTypeId">The test type id.</param>
    ''' <returns></returns>
    Public Function GetTestTypeNameFromTestTypeId(ByVal testTypeId As Integer) As String
        Try
            Dim result = New SubSonic.Select(TTestTypeList.Columns.TestTypeName).From(TTestTypeList.Schema.Name).Where(TTestTypeList.Columns.TestTypeId).IsEqualTo(testTypeId).ExecuteScalar()
            Return result.ToString()
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetPatientIdFromTestId(ByVal pTestId As Integer) As Integer
        Try
            Return New SubSonic.Select(TTestInfo.Columns.PatientId).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.TestId).IsEqualTo(pTestId).ExecuteScalar()
        Catch ex As Exception
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Lấy về danh sách các xét nghiệm hai chiều có thể thực hiện từ TestTypeId
    ''' </summary>
    ''' <param name="testTypeId">The test type id.</param>
    ''' <returns></returns>
    Public Function GetTestListFromTestTypeId(ByVal testTypeId As Integer, Optional ByVal sortByName As Boolean = True, Optional ByVal showPrintableTestOnly As Boolean = False) As DataTable
        Try
            Dim query As SqlQuery = New SubSonic.Select().From(LStandardTest.Schema.Name).Where(1).IsEqualTo(1)

            'Nếu TestTypeID khác -1 thì lấy theo biến truyền vào
            If testTypeId <> -1 Then query = query.And(LStandardTest.Columns.TestTypeId).IsEqualTo(testTypeId)

            'Nếu chỉ cho phép hiển thị các test được phép in ra
            If showPrintableTestOnly Then query = query.And(LStandardTest.Columns.DataPrint).IsEqualTo(1)

            query = IIf(sortByName, query.OrderAsc(LStandardTest.Columns.DataName), query.OrderAsc(LStandardTest.Columns.DataSequence))
            Return query.ExecuteDataSet().Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Gets the barcode from test id.
    ''' </summary>
    ''' <param name="testId">The test id.</param>
    ''' <returns></returns>
    Public Function GetBarcodeFromTestId(ByVal testId As Integer) As String
        Try
            Dim result = New SubSonic.Select(TTestInfo.Columns.Barcode).Top("1").From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.TestId).IsEqualTo(testId).ExecuteScalar()
            Return result.ToString()
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Gets the barcode from test id.
    ''' </summary>
    ''' <param name="testId">The test id.</param>
    ''' <returns></returns>
    Public Function GetBarcodeFromPatientAndTestTypeId(ByVal pPatientId As String, ByVal pTestTypeId As String) As String
        Dim barcode = _
                New [Select](TTestInfo.Columns.Barcode).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.PatientId). _
                IsEqualTo(pPatientId).And(TTestInfo.Columns.TestTypeId).IsEqualTo(pTestTypeId).ExecuteScalar()
        Try
            Return IIf(barcode Is Nothing, "-1", barcode)
        Catch ex As Exception
            Return "-1"
        End Try
    End Function

    ''' <summary>
    ''' Gets the barcode from test id.
    ''' </summary>
    ''' <param name="testId">The test id.</param>
    ''' <returns></returns>
    Public Function GetBarcodeFromPatientId(ByVal pPatientId As String) As String
        Dim barcode = _
                New [Select](TTestInfo.Columns.Barcode).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.PatientId). _
                IsEqualTo(pPatientId).ExecuteScalar()
        Try
            Return IIf(barcode Is Nothing, "-1", barcode)
        Catch ex As Exception
            Return "-1"
        End Try
    End Function


    Public Function GetDataNameFromTestDataId(ByVal testDataId As String) As String
        Try
            Dim result = New SubSonic.Select(LStandardTest.Columns.DataName).Top("1").From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.TestDataId).IsEqualTo(testDataId).ExecuteScalar()
            Return result.ToString()
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetPrintStatusFromTestDataId(ByVal testDataId As String) As Boolean
        Try
            Dim result = New SubSonic.Select(LStandardTest.Columns.DataPrint).Top("1").From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.TestDataId).IsEqualTo(testDataId).ExecuteScalar()
            Return result
        Catch ex As Exception
            Return True
        End Try
    End Function

    Public Function GetPatientIdFromBarcode(ByVal pBarcode As String)
        Try
            If (pBarcode.Length <= 5) Then
                Dim result = New SubSonic.Select(TTestInfo.Columns.PatientId, TTestInfo.Columns.Barcode).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.Barcode).Like("%" + pBarcode + "%").ExecuteScalar()
                If (result IsNot Nothing) Then
                    Return result.ToString()
                Else
                    Return "-1"
                End If
            Else
                Dim result = New SubSonic.Select(TTestInfo.Columns.PatientId).From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.Barcode).IsEqualTo(pBarcode).ExecuteScalar()
                If (result IsNot Nothing) Then
                    Return result.ToString()
                Else
                    Return "-1"
                End If
            End If

        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetTestTypeIdFromDescription(ByVal desc As String) As Int32
        Try
            Dim result As Integer
            result = New [Select](LStandardTest.Columns.TestTypeId).From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.TestDataId).IsEqualTo(desc).ExecuteScalar()
            Return result
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function GetAllLot() As DataTable
        Try
            Return New [Select](TblLot.Columns.Id).From(TblLot.Schema.Name).OrderDesc(TblLot.Columns.Id).ExecuteDataSet().Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Lấy toàn bộ kết quả từ một TestID
    ''' </summary>
    ''' <param name="testId">The test id.</param>
    ''' <returns></returns>
    Public Function GetTestResultFromTestId(ByVal testId As String) As DataTable
        Try
            Return _
                New [Select](TResultDetail.ParaNameColumn, TResultDetail.TestDataIdColumn).From(TResultDetail.Schema). _
                    Where(TResultDetail.Columns.TestId).IsEqualTo(testId).ExecuteDataSet().Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Lấy toàn bộ đăng ký từ TestID
    ''' </summary>
    ''' <param name="testId">The test id.</param>
    ''' <returns></returns>
    Public Function GetRegListFromTestId(ByVal testId As String) As DataTable
        Try
            Return _
                New [Select](TRegList.ParaNameColumn, TRegList.TestDataIdColumn).From(TRegList.Schema). _
                    Where(TRegList.Columns.TestId).IsEqualTo(testId).ExecuteDataSet().Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Gets the test type id from test code.
    ''' </summary>
    ''' <param name="pTestCode">The p test code.</param>
    ''' <returns></returns>
    Public Function GetTestTypeIdFromTestCode(ByVal pTestCode As String) As Integer
        Try
            Dim result As Integer
            result = New [Select](LStandardTest.Columns.TestTypeId).From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.TestDataId).IsEqualTo(pTestCode).ExecuteScalar()
            Return result
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function GetBarcode(ByVal pBarcodeDigit As Integer, ByVal pAllowSameTestTypeInday As Integer) As String

    End Function

    ''' <summary>
    ''' Lấy về danh sách thiết bị từ một loại xét nghiệm
    ''' </summary>
    ''' <param name="pTestTypeId">The p test type id.</param>
    ''' <returns></returns>
    Public Function GetDeviceListByTestTypeId(ByVal pTestTypeId As Integer) As DataTable
        Try
            Dim result As DataTable
            result = New [Select](DDeviceList.DeviceIdColumn, DDeviceList.DeviceNameColumn).From(DDeviceList.Schema).Where(DDeviceList.Columns.DeviceId).In( _
            New [Select](String.Format("DISTINCT({0})", DDataControl.Columns.DeviceId)).From(DDataControl.Schema.Name).LeftOuterJoin(LStandardTest.TestDataIdColumn, DDataControl.TestDataIdColumn).Where(LStandardTest.Columns.TestTypeId).IsEqualTo(pTestTypeId) _
            ).ExecuteDataSet().Tables(0)
            Return result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

End Module
