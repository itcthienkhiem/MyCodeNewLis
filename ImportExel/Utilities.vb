Imports System.Data.SqlClient
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Reflection
Imports System.Drawing.Imaging

Public Class Utilities

#Region "Attibuties"
    Private Shared gv_sConnString As String
    Private Shared gv_sBranchID As String
    Private Shared gv_sDBName As String
    Private Shared gv_sDBAdrr As String
    Private Shared ReadOnly Apppath As String = My.Application.Info.DirectoryPath
    Private Const gv_sAnnouncement As String = "Thông báo"
    Private Shared ReadOnly privateConnection As SqlConnection = GetDBConnection()
    Public Shared gv_sUID As String
    Public Shared gv_sParentBranchName As String
    Public Shared gv_sBranchName As String
    Public Shared gv_sPhone As String
    Public Shared gv_sAddress As String

#End Region

#Region "Private method"

    Public Shared Function GetFieldValue(ByVal pv_sTableName As String, ByVal pv_sFieldName As String, ByVal pv_sCondition As String) As Object
        Dim fv_sSql As String = ""
        fv_sSql = "SELECT " & pv_sFieldName & " FROM " & pv_sTableName & " WHERE " & pv_sCondition
        Dim DA As New SqlDataAdapter(fv_sSql, privateConnection)
        Dim DT As New DataTable
        Try
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                Return DT.Rows(0)(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Shared Function GetDatatable(ByVal pv_sTableName As String, ByVal pv_sCondition As String) As Object
        Dim fv_sSql As String = ""
        fv_sSql = "SELECT * FROM " & pv_sTableName & " WHERE " & pv_sCondition
        Dim methodConnection = Utilities.GetDBConnection
        Dim DA As New SqlDataAdapter(fv_sSql, methodConnection)
        Dim DT As New DataTable
        Try
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                Return DT
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            methodConnection.Dispose()
            DT.Dispose()
            DA.Dispose()
            methodConnection = Nothing
            DT = Nothing
            DA = Nothing

        End Try


    End Function

    Public Shared Function GetMaxCode(ByVal pv_sTableName As String, ByVal pv_sColumnName As String, ByVal yymmdd As String) As String
        Try
            Dim fv_sSql As String = "select max(Right(" & pv_sColumnName & ",4)) from " & pv_sTableName & " where LEN(BARCODE)>9 AND LEFT(barcode+'000000',6)='" & yymmdd & "'"
            Dim DA As New SqlDataAdapter(fv_sSql, privateConnection)
            Dim DT As New DataTable
            DA.Fill(DT)
            If (DT.Rows.Count > 0) And (IsNumeric(DT.Rows(0)(0))) Then
                Return CInt(DT.Rows(0)(0)) + 1
            Else
                Return 1
            End If


        Catch ex As Exception
            Return -1
        End Try

    End Function

#End Region

#Region "Public Method"

    Public Shared Function spGetBarcode(ByVal pBarcode As String) As String

        Try
            pBarcode = CInt(pBarcode).ToString
            If pBarcode.Length > 4 Then
            Else
                pBarcode = pBarcode.PadLeft(4, "0")
            End If
            Return pBarcode
        Catch ex As Exception
            If pBarcode.Length > 4 Then
                pBarcode = pBarcode.Substring(pBarcode.Length - 4, 4)
            Else
                pBarcode = pBarcode.PadLeft(4, "0")
            End If
            Return pBarcode
        End Try

    End Function

    Public Shared Function GetDeviceIdFromPortId(ByVal pPortID As Integer) As Integer
        Dim result As Integer = -1

        Try
            result = GetFieldValue("D_DEVICE_LIST", "Device_ID", "Port_ID = " & pPortID)
            Return result
        Catch ex As Exception
            Return -1
        End Try

    End Function

    'Lay thong tin ve ma loai XN de xay dung barcode
    Public Shared Function spGetintOder(ByVal pTestTypeID As Int16) As String

        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        Dim ad As SqlDataAdapter
        Try
            Try
                If privateConnection.State <> ConnectionState.Open Then privateConnection.Open()
            Catch ex As Exception
                File.AppendAllText("D:\LOG\DB_Connection_Error.txt", Now.ToString & "     spGetintOder" & vbCrLf)
                Return String.Empty
            End Try

            With cmd
                .Connection = privateConnection
                .CommandType = CommandType.Text
                .CommandText = "SELECT intOrder From T_TEST_TYPE_LIST WHERE TESTTYPE_ID = " & pTestTypeID.ToString
            End With

            ad = New SqlDataAdapter(cmd)
            ad.Fill(dt)

            If dt.Rows.Count <= 0 Then
                Return "00"
            Else
                Return Format(dt.Rows(0).Item(0), "0#")
            End If
        Catch ex As Exception
            File.AppendAllText("D:\LOG\DB_Connection_Error.txt", Now.ToString & "     spGetintOder - - - Lỗi khác" & vbCrLf)
        Finally
            cmd.Dispose()
            dt.Dispose()
            ad.Dispose()
        End Try

    End Function

    Public Shared Function Bodau(ByVal s As String) As String
        Dim sb As System.Text.StringBuilder
        sb = New StringBuilder()
        s = s.Trim()
        If s = "" Then Return ""
        For Each ch As Char In s
            If (ch >= "A" And ch <= "Z") Or (ch >= "a" And ch <= "z") Or (ch = " ") Then
                sb.Append(ch)
                Continue For
            Else
                Select Case ch
                    Case "â", "ă", "ấ", "ầ", "ậ", "ẫ", "ẩ", "ắ", "ằ", "ẵ", "ẳ", "ặ", "á", "à", "ả", "ã", "ạ"
                        sb.Append("a")
                        Continue For
                    Case "Â", "Ă", "Ấ", "Ầ", "Ậ", "Ẫ", "Ẩ", "Ắ", "Ằ", "Ẵ", "Ẳ", "Ặ", "Á", "À", "Ả", "Ã", "Ạ"
                        sb.Append("A")
                        Continue For
                    Case "ó", "ò", "ỏ", "õ", "ọ", "ô", "ố", "ồ", "ổ", "ỗ", "ộ", "ơ", "ớ", "ờ", "ợ", "ở", "ỡ"
                        sb.Append("o")
                        Continue For
                    Case "Ó", "Ò", "Ỏ", "Õ", "Ọ", "Ô", "Ố", "Ồ", "Ổ", "Ỗ", "Ộ", "Ơ", "Ớ", "Ờ", "Ợ", "Ở", "Ỡ"
                        sb.Append("O")
                        Continue For
                    Case "ư", "ứ", "ừ", "ự", "ử", "ữ", "ù", "ú", "ủ", "ũ", "ụ"
                        sb.Append("u")
                        Continue For
                    Case "Ư", "Ứ", "Ừ", "Ự", "Ử", "Ữ", "Ù", "Ú", "Ủ", "Ũ", "Ụ"
                        sb.Append("U")
                        Continue For
                    Case "ê", "ế", "ề", "ệ", "ể", "ễ", "è", "é", "ẻ", "ẽ", "ẹ"
                        sb.Append("e")
                        Continue For
                    Case "Ê", "Ế", "Ề", "Ệ", "Ể", "Ễ", "È", "É", "Ẻ", "Ẽ", "Ẹ"
                        sb.Append("E")
                        Continue For
                    Case "í", "ì", "ị", "ỉ", "ĩ"
                        sb.Append("i")
                        Continue For
                    Case "Í", "Ì", "Ỉ", "Ĩ", "Ị"
                        sb.Append("I")
                        Continue For
                    Case "ý", "ỳ", "ỵ", "ỷ", "ỹ"
                        sb.Append("y")
                        Continue For
                    Case "Ý", "Ỳ", "Ỵ", "Ỷ", "Ỹ"
                        sb.Append("Y")
                        Continue For
                    Case "đ"
                        sb.Append("d")
                        Continue For
                    Case "Đ"
                        sb.Append("D")
                        Continue For
                    Case Else
                        Continue For
                End Select
            End If
        Next
        Return sb.ToString
    End Function

    Public Shared Sub ProcessNormalResult(ByRef dt As DataTable, Optional ByVal testResult As String = "Test_result", Optional ByVal normalLevel As String = "Normal_Level", Optional ByVal lowValue As Object = "L", Optional ByVal hightValue As Object = "H", Optional ByVal normalValue As Object = "-", Optional ByVal flag As String = "Note", Optional ByVal forVd As Boolean = False)
        Try
            Dim min, max As Double
            Dim normal As String
            Dim arrResultWithLetters As New ArrayList
            arrResultWithLetters.Add("NE")
            arrResultWithLetters.Add("POS")

            If Not dt.Columns.Contains(flag) Then
                dt.Columns.Add(flag)
            End If

            For Each dr As DataRow In dt.Rows
                'Todo: Check cho Việt Đức
                If (forVd) Then
                    Dim s As String = dr("Test_Name").ToString().ToUpper()
                    If (Not s.Contains("HIV")) And (Not s.Contains("HCV")) And (Not s.Contains("HBS")) Then
                        Continue For
                    End If
                End If
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
                    Dim rawResult As String = dr(testResult).ToString()

                    If rawResult.Contains("-") Then
                        rawResult = rawResult.Split("-")(0)
                    End If

                    rawResult = rawResult.Replace("≤", "<=")
                    rawResult = rawResult.Replace("≥", ">=")
                    If rawResult = ">1000" Then rawResult = ">1000"
                    While rawResult.IndexOf(" ") > 0
                        rawResult = rawResult.Replace(" ", "")
                    End While
                    If String.IsNullOrEmpty(rawResult) Or String.IsNullOrEmpty(normal) Or (rawResult.ToString().Trim().ToUpper() = normal.ToUpper()) Then
                        dr(flag) = ""
                        Continue For
                    ElseIf normal.ToUpper().StartsWith("NEG") Or normal.ToUpper().StartsWith("Âm") Or normal.ToUpper().StartsWith("Am") Then
                        Dim b1 As Boolean = rawResult.StartsWith("ÂM")
                        Dim b2 As Boolean = rawResult.StartsWith("AM")
                        Dim b3 As Boolean = rawResult.StartsWith("NEG")
                        If b1 Or b2 Or b3 Then
                            dr(flag) = normalValue
                        Else
                            dr(flag) = hightValue
                        End If

                    ElseIf normal.ToUpper().StartsWith("POS") Or normal.ToUpper().StartsWith("DƯƠ") Or normal.ToUpper().StartsWith("DUO") Then
                        Dim b1 As Boolean = rawResult.StartsWith("POS")
                        Dim b2 As Boolean = rawResult.StartsWith("DƯƠ")
                        Dim b3 As Boolean = rawResult.StartsWith("DUO")
                        If b1 Or b2 Or b3 Then
                            dr(flag) = normalValue
                        Else
                            dr(flag) = lowValue
                        End If

                    ElseIf IsNumeric(rawResult) Then
processnumber:          dr(flag) = normalValue
                        Dim tempResult As Double = CDbl(rawResult)

                        If normal.IndexOf("-") > 0 Then
                            Dim arrstr As String()
                            arrstr = normal.Split("-")
                            min = CDbl(arrstr(0))
                            max = CDbl(arrstr(1))
                            Dim b1 As Boolean = tempResult >= min
                            Dim b2 As Boolean = tempResult <= max
                            If Not b1 Then dr(flag) = lowValue
                            If Not b2 Then dr(flag) = hightValue

                        ElseIf normal.IndexOf("<=") >= 0 Then
                            min = Double.MinValue
                            max = CDbl(normal.Substring(2))
                            Dim b1 As Boolean = tempResult >= min
                            Dim b2 As Boolean = tempResult <= max
                            If Not b1 Then dr(flag) = lowValue
                            If Not b2 Then dr(flag) = hightValue
                        ElseIf normal.IndexOf(">=") >= 0 Then
                            max = Double.MaxValue
                            min = CDbl(normal.Substring(2))
                            Dim b1 As Boolean = tempResult >= min
                            Dim b2 As Boolean = tempResult <= max
                            If Not b1 Then dr(flag) = lowValue
                            If Not b2 Then dr(flag) = hightValue
                            ''Truong hop chi co can tren
                        ElseIf normal.IndexOf("<") >= 0 Then
                            min = Double.MinValue
                            max = CDbl(normal.Substring(1))
                            Dim b1 As Boolean = tempResult > min
                            Dim b2 As Boolean = tempResult < max
                            If Not b1 Then dr(flag) = lowValue
                            If Not b2 Then dr(flag) = hightValue
                            ''Truong hop chi co can tren
                        ElseIf normal.IndexOf(">") >= 0 Then
                            max = Double.MaxValue
                            min = CDbl(normal.Substring(1))
                            Dim b1 As Boolean = tempResult > min
                            Dim b2 As Boolean = tempResult < max
                            If Not b1 Then dr(flag) = lowValue
                            If Not b2 Then dr(flag) = hightValue
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
                        '    dr(flag) = hight
                        'Else
                        '    dr(flag) = ""
                        'End If
                        Dim strTempResultString = rawResult.ToString.Trim.ToUpper
                        Dim b1 As Boolean = strTempResultString.StartsWith("ÂM")
                        Dim b2 As Boolean = strTempResultString.StartsWith("AM")
                        Dim b3 As Boolean = strTempResultString.StartsWith("NEG")
                        If b1 Or b2 Or b3 Then
                            dr(flag) = normal
                        Else
                            dr(flag) = hightValue
                        End If

                        If ((strTempResultString = "-") Or (strTempResultString = "±") Or (strTempResultString = "+") Or (strTempResultString = "+-")) And (strTempResultString <> normal) Then dr(flag) = hightValue

                    End If
                Catch ex As Exception
                    dr(flag) = " "
                    Continue For
                End Try
            Next


        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "UI"
    Private Delegate Sub SetControlPropertyDelegate(ByVal control As Control, ByVal propertyName As String, ByVal propertyValue As Object)

    Public Shared Sub SetControlProperty(ByVal control As Control, ByVal propertyName As String, ByVal propertyValue As Object)
        If control.InvokeRequired Then
            control.Invoke(New SetControlPropertyDelegate(AddressOf SetControlProperty), New Object() {control, propertyName, propertyValue})
        Else
            control.[GetType]().InvokeMember(propertyName, BindingFlags.SetProperty, Nothing, control, New Object() {propertyValue})
        End If
    End Sub

    Public Shared Sub GridviewRowPostPaint(ByVal sender As Object, ByVal e As DataGridViewRowPostPaintEventArgs)
        Try
            Dim gridViewX As DataGridView
            gridViewX = TryCast(sender, DataGridView)

            Dim strRowNumber As String = (e.RowIndex + 1).ToString()

            If gridViewX IsNot Nothing Then
                While strRowNumber.Length < gridViewX.RowCount.ToString().Length
                    strRowNumber = "0" & strRowNumber
                End While

                Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, gridViewX.Font)

                If gridViewX.RowHeadersWidth < CInt(size.Width + 20) Then
                    gridViewX.RowHeadersWidth = CInt(size.Width + 20)
                End If
                Dim b As Brush = SystemBrushes.ControlText
                e.Graphics.DrawString(strRowNumber, gridViewX.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Ghi toàn bộ nội dung của datatable ra file text
    ''' </summary>
    ''' <param name="dt">Data Table cần ghi</param>
    ''' <param name="outputFilePath">Đường dẫn đến file cần ghi</param>
    Public Shared Sub WriteDataTableToFile(ByVal dt As DataTable, ByVal outputFilePath As String, Optional ByVal append As Boolean = False)
        Try
            Const lablinkQueryLog As String = "D:\LABLink Query Log"

            If Not Directory.Exists(lablinkQueryLog) Then
                Directory.CreateDirectory(lablinkQueryLog)
            End If
            If outputFilePath.IndexOf(":\") < 0 Then
                outputFilePath = lablinkQueryLog + "\" + outputFilePath
            End If

            Dim maxLengths As Integer() = New Integer(dt.Columns.Count - 1) {}
            For i As Integer = 0 To dt.Columns.Count - 1
                maxLengths(i) = dt.Columns(i).ColumnName.Length
                For Each row As DataRow In dt.Rows
                    If Not row.IsNull(i) Then
                        Dim length As Integer = row(i).ToString().Length
                        If length > maxLengths(i) Then
                            maxLengths(i) = length
                        End If
                    End If
                Next
            Next

            Using sw As New StreamWriter(outputFilePath, append)
                For i As Integer = 0 To dt.Columns.Count - 1
                    sw.Write(dt.Columns(i).ColumnName.PadRight(maxLengths(i) + 2) + vbTab)
                Next
                sw.WriteLine()
                For Each row As DataRow In dt.Rows
                    For i As Integer = 0 To dt.Columns.Count - 1
                        If Not row.IsNull(i) Then
                            sw.Write(row(i).ToString().PadRight(maxLengths(i) + 2) + vbTab)
                        Else
                            sw.Write(New String(" "c, maxLengths(i) + 2) + vbTab)
                        End If
                    Next
                    sw.WriteLine()
                Next
                sw.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Delegate to invoke a specific method on the control thread-safely.
    ''' </summary>
    ''' <param name="control">Control on which to invoke the method</param>
    ''' <param name="methodName">Method to be invoked</param>
    ''' <param name="paramValues">Method parameters</param>
    ''' <returns>Value returned by the invoked method</returns>
    Private Delegate Function MethodInvoker(ByVal control As Control, ByVal methodName As String, ByVal paramValues As Object()) As Object

    ''' <summary>
    ''' Delegate to get a property value on the control thread-safely.
    ''' </summary>
    ''' <param name="control">Control on which to GET the property value</param>
    ''' <param name="propertyName">Property name</param>
    ''' <return>Property value</return>
    Private Delegate Function PropertyGetInvoker(ByVal control As Control, ByVal propertyName As String) As Object

    ''' <summary>
    ''' Delegate to set a property value on the control thread-safely.
    ''' </summary>
    ''' <param name="control">Control on which to SET the property value</param>
    ''' <param name="propertyName">Property name</param>
    ''' <param name="value">New property value</param>
    Private Delegate Sub PropertySetInvoker(ByVal control As Control, ByVal propertyName As String, ByVal value As Object)

    ''' <summary>
    ''' Invoke a specific method on the control thread-safely.
    ''' </summary>
    ''' <param name="control">Control on which to invoke the method</param>
    ''' <param name="methodName">Method to be invoked</param>
    ''' <param name="paramValues">Method parameters</param>
    ''' <return>Value returned by the invoked method</return>
    Public Shared Function InvokeMethod(ByVal control As Control, ByVal methodName As String, ByVal ParamArray paramValues As Object()) As Object
        If control IsNot Nothing AndAlso Not String.IsNullOrEmpty(methodName) Then
            If control.InvokeRequired Then
                Return control.Invoke(New MethodInvoker(AddressOf InvokeMethod), control, methodName, paramValues)
            Else
                Dim methodInfo As MethodInfo = Nothing

                If paramValues IsNot Nothing AndAlso paramValues.Length > 0 Then
                    Dim types As Type() = New Type(paramValues.Length - 1) {}
                    For i As Integer = 0 To paramValues.Length - 1
                        If paramValues(i) IsNot Nothing Then
                            types(i) = paramValues(i).[GetType]()
                        End If
                    Next
                    methodInfo = control.[GetType]().GetMethod(methodName, types)
                Else
                    methodInfo = control.[GetType]().GetMethod(methodName)
                End If

                If methodInfo IsNot Nothing Then
                    Return methodInfo.Invoke(control, paramValues)
                Else
                    Throw New InvalidOperationException()
                End If
            End If
        Else
            Throw New ArgumentNullException()
        End If
    End Function

    ''' <summary>
    ''' Get a PropertyInfo object associated with a specific property on the control.
    ''' </summary>
    ''' <param name="control">Control</param>
    ''' <param name="propertyName">Property name</param>
    ''' <return>A PropertyInfo object associated with 
    ''' 'propertyName' on specified 'control'</return>
    Private Shared Function GetProperty(ByVal control As Control, ByVal propertyName As String) As PropertyInfo
        If control IsNot Nothing AndAlso Not String.IsNullOrEmpty(propertyName) Then
            Dim propertyInfo As PropertyInfo = control.[GetType]().GetProperty(propertyName)
            If propertyInfo Is Nothing Then
                Throw New Exception(control.[GetType]().ToString() & " does not contain '" & propertyName & "' property.")
            End If

            Return propertyInfo
        Else
            Throw New ArgumentNullException()
        End If
    End Function

    ''' <summary>
    ''' Set a property value on the control thread-safely.
    ''' </summary>
    ''' <param name="control">Control on which to SET the property value</param>
    ''' <param name="propertyName">Property name</param>
    ''' <param name="value">New property value</param>
    Public Shared Sub SetPropertyValue(ByVal control As Control, ByVal propertyName As String, ByVal value As Object)
        If control IsNot Nothing AndAlso Not String.IsNullOrEmpty(propertyName) Then
            If control.InvokeRequired Then
                control.Invoke(New PropertySetInvoker(AddressOf SetPropertyValue), control, propertyName, value)
            Else
                Dim propertyInfo As PropertyInfo = GetProperty(control, propertyName)
                If propertyInfo IsNot Nothing Then
                    If propertyInfo.CanWrite Then
                        propertyInfo.SetValue(control, value, Nothing)
                    Else
                        Throw New Exception(control.[GetType]().ToString() & "." & propertyName & " is read-only property.")
                    End If
                End If
            End If
        Else
            Throw New ArgumentNullException()
        End If
    End Sub

    ''' <summary>
    ''' Get a property value on the control thread-safely.
    ''' </summary>
    ''' <param name="control">Control on which to GET the property value</param>
    ''' <param name="propertyName">Property name</param>
    ''' <return>Property value</return>
    Public Shared Function GetPropertyValue(ByVal control As Control, ByVal propertyName As String) As Object
        If control IsNot Nothing AndAlso Not String.IsNullOrEmpty(propertyName) Then
            If control.InvokeRequired Then
                Return control.Invoke(New PropertyGetInvoker(AddressOf GetPropertyValue), control, propertyName)
            Else
                Dim propertyInfo As PropertyInfo = GetProperty(control, propertyName)
                If propertyInfo IsNot Nothing Then
                    If propertyInfo.CanRead Then
                        Return propertyInfo.GetValue(control, Nothing)
                    Else
                        Throw New Exception(control.[GetType]().ToString() & "." & propertyName & " is write-only property.")
                    End If
                End If
                Return Nothing
            End If
        Else
            Throw New ArgumentNullException()
        End If
    End Function

#End Region

#Region "Get Data Base connection"
    ' Get DB connection
    Public Shared Function GetDBConnection(Optional ByVal ConfigFileName As String = "Config.xml") As SqlConnection
        Dim gv_WLConn As New SqlConnection
        'Dim sv_oEncrypt As New Encrypt.Encrypt("Rijndael")
        Dim sv_oEncrypt As New Encrypt("Rijndael")
        Dim UID As String = ""
        Dim PW As String = ""
        Dim fv_sUID As String
        Dim fv_sPWD As String
        If bGetConfigInfor(ConfigFileName, UID, PW, fv_sUID, fv_sPWD) Then
            Dim cnns As String = "workstation id=" & gv_sDBAdrr & ";packet size=4096;data source=" & gv_sDBAdrr & ";persist security info=False;initial catalog=" & gv_sDBName & ";uid=" & sv_oEncrypt.GiaiMa(UID) & ";pwd=" & sv_oEncrypt.GiaiMa(PW)
            gv_WLConn.ConnectionString = cnns
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
   
    Public Shared Function sDBnull(ByVal pv_obj As Object, Optional ByVal Reval As String = "") As String
        If IsDBNull(pv_obj) Or IsNothing(pv_obj) Then
            Return Reval
        Else
            Return pv_obj.ToString
        End If
    End Function

    Public Shared Function GetDBConnectionString(Optional ByVal ConfigFileName As String = "Config.xml") As String
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

    'Read from Config.xml
    Private Shared Function bGetConfigInfor(ByVal ConfigFileName As String, ByRef pv_sUID As String, ByRef pv_sPWD As String, ByRef fv_sUID As String, ByRef fv_sPWD As String) As Boolean
        Dim fv_DS As New DataSet
        'Dim filepath = Apppath & "\Config.XML"
        Dim filepath = Apppath & "\" & ConfigFileName
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
                    Dim fv_sSqlConstr = "workstation id=" & gv_sDBAdrr & ";packet size=4096;data source=" & gv_sDBAdrr & ";persist security info=False;initial catalog=" & gv_sDBName & ";uid=" & fv_sUID & ";pwd=" & fv_sPWD
                    fv_oSQLCon = New SqlConnection(fv_sSqlConstr)
                    'Mở CSDL
                    Try
                        fv_oSQLCon.Open()
                    Catch SQLex As Exception
                        MessageBox.Show("Không đăng nhập được vào CSDL " & gv_sDBName & " bằng tài khoản công khai(UID=" & fv_sUID & ";PWD=" & fv_sPWD & "). Hãy cấu hình lại File Config.XML sau đó đăng nhập lại.", gv_sAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End Try
                    Try
                        GetSecretAccount(fv_oSQLCon, pv_sUID, pv_sPWD)
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

    'Get login information
    Private Shared Sub GetSecretAccount(ByVal pv_Conn As SqlConnection, ByRef pv_sUID As String, ByRef pv_sPWD As String)
        Dim sv_Ds As New DataSet
        Dim sv_DA As SqlDataAdapter
        Try
            sv_DA = New SqlDataAdapter("SELECT * FROM TBL_SECURITY", pv_Conn)
            sv_DA.Fill(sv_Ds, "TBL_SECURITY")
            If sv_Ds.Tables(0).Rows.Count > 0 Then
                pv_sUID = sv_Ds.Tables(0).Rows(0)("sUID")
                pv_sPWD = sv_Ds.Tables(0).Rows(0)("sPWD")
            Else
                'MsgBox.Show("Không tồn tại tài khoản đăng nhập trong bảng TBL_SECURITY! Đề nghị với DBAdmin tạo tài khoản đăng nhập trong bảng đó.", gv_sAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            'MessageBox.Show("Bạn cần gán lại quyền truy cập vào bảng TBL_SECURITY cho tài khoản công khai! Đề nghị với DBAdmin thực hiện công việc này bằng tiện ích CreateUser.exe", gv_sAnnouncement, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Shared Sub GetConfigFromXml(ByRef serveraddress As String, ByRef databaseID As String, ByRef username As String, ByRef password As String, ByRef branchID As String)

        Dim fvDs As New DataSet
        Dim filepath = Apppath & "\Config.XML"
        'Dim filepath = Apppath & "\" & ConfigFileName
        fvDs.ReadXml(filepath)
        If fvDs.Tables(0).Rows.Count > 0 Then
            ' Đọc dữ liệu vào các biến toàn cục
            'Địa chỉ máy chủ CSDL
            serveraddress = fvDs.Tables(0).Rows(0)("SERVERADDRESS")
            'Mã chi nhánh
            branchID = fvDs.Tables(0).Rows(0)("BranchID")
            'UID côngkhai
            username = fvDs.Tables(0).Rows(0)("USERNAME")
            'Mật khẩu công khai
            password = fvDs.Tables(0).Rows(0)("PASSWORD")
            'Tên Cơ sở dữ liệu
            databaseID = fvDs.Tables(0).Rows(0)("DATABASE_ID")
            'Ngôn ngữ hiển thị
        End If
    End Sub

#End Region

#Region "Data Base Utilities"
    Private Const SQL_NEED_DATA As Integer = 99
    Private Const SQL_SUCCESS As Integer = 0

    <DllImport("odbc32.dll", SetLastError:=True)> _
    Private Shared Function SQLAllocConnect(ByVal hEnv As Integer, ByRef phdbc As Integer) As Short
    End Function

    <DllImport("odbc32.dll", SetLastError:=True)> _
    Private Shared Function SQLAllocEnv(ByRef phenv As Integer) As Short
    End Function

    <DllImport("odbc32.dll", SetLastError:=True)> _
    Private Shared Function SQLBrowseConnect(ByVal hdbc As Integer, ByVal inConnectionString As String, ByVal stringLength1 As Short, ByVal outConnectionString As StringBuilder, ByVal stringLength2 As Short, ByRef stringLengt2hPtr As Short) As Short
    End Function

    <DllImport("odbc32.dll", SetLastError:=True)> _
    Private Shared Function SQLDisconnect(ByVal hdbc As Integer) As Short
    End Function

    <DllImport("odbc32.dll", SetLastError:=True)> _
    Private Shared Function SQLFreeEnv(ByVal henv As Integer) As Short
    End Function

    <DllImport("odbc32.dll", SetLastError:=True)> _
    Private Shared Function SQLFreeConnect(ByVal hdbc As Integer) As Short
    End Function

    Public Shared Function GetAvailableServers() As String()
        Dim servers As String() = Nothing
        Dim henv As Integer = 0
        Dim hdbc As Integer = 0
        SQLAllocEnv(henv)
        SQLAllocConnect(henv, hdbc)
        Dim connectionString As String = "DRIVER=SQL Server"
        '10k should be way enough
        Dim outString As New StringBuilder(10000)
        Dim realLength As Short = 0
        Dim rc As Short = SQLBrowseConnect(hdbc, connectionString, CShort(connectionString.Length), outString, CShort(outString.Capacity + 1), realLength)
        If rc = SQL_SUCCESS OrElse rc = SQL_NEED_DATA Then
            Dim serverString As String = outString.ToString()
            Dim i As Integer = serverString.ToLower().IndexOf("server={") + 8
            Dim pos As Integer = serverString.IndexOf("}"c, i)
            serverString = serverString.Substring(i, pos - i)
            servers = serverString.Split(","c)
        End If
        SQLDisconnect(hdbc)
        SQLFreeConnect(hdbc)
        SQLFreeEnv(henv)
        Return servers
    End Function

    Public Shared Function GetDatabases(ByVal serverName As String, ByVal integratedSecurity As Boolean, ByVal userName As String, ByVal password As String) As String()
        Dim connectionString As String = "initial catalog=master; Data Source=" & serverName & ";" & (If(integratedSecurity, "integrated security=SSPI;", "user id=" & userName & "; password=" & password & ";")) & "pooling=false"
        Dim adapter As New SqlDataAdapter("SELECT name FROM dbo.sysdatabases ORDER BY name", connectionString)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)
        Dim j As Integer = dataTable.Rows.Count
        Dim databases As String() = New String(j - 1) {}
        For i As Integer = 0 To j - 1
            databases(i) = DirectCast(dataTable.Rows(i)("name"), String)
        Next
        dataTable.Dispose()
        adapter.Dispose()
        Return databases
    End Function

    Public Shared Function GetCollations(ByVal serverName As String, ByVal integratedSecurity As Boolean, ByVal userName As String, ByVal password As String) As String()
        Dim collations As String() = Nothing
        Try
            Dim connectionString As String = "initial catalog=master; Data Source=" & serverName & ";" & (If(integratedSecurity, "integrated security=SSPI;", "user id=" & userName & "; password=" & password & ";")) & "pooling=false"
            Using adapter As New SqlDataAdapter("select name From ::fn_helpcollations() order by name", connectionString)
                Using dataTable As New DataTable()
                    adapter.Fill(dataTable)
                    Dim j As Integer = dataTable.Rows.Count
                    collations = New String(j - 1) {}
                    For i As Integer = 0 To j - 1
                        collations(i) = DirectCast(dataTable.Rows(i)("name"), String)
                    Next
                End Using
            End Using
        Catch
        End Try
        Return collations
    End Function

#End Region

#Region "Tham số hệ thống"

    Public Shared Sub UpdateLogotoDatatable(ByRef dataTable As DataTable)
        Try
            If Not dataTable.Columns.Contains("LOGO") Then
                dataTable.Columns.Add("LOGO", GetType(Byte()))
            End If
            Dim byteArray As Byte() = ConvertImageToByteArray(Image.FromFile(Application.StartupPath + "\logo\logo.jpg"), ImageFormat.Jpeg)
            For Each dr As DataRow In dataTable.Rows
                dr("LOGO") = byteArray
            Next
            dataTable.AcceptChanges()
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Function ConvertImageToByteArray(ByVal imageToConvert As System.Drawing.Image, ByVal formatOfImage As ImageFormat) As Byte()
        Dim Ret As Byte() = Nothing
        Try
            Using ms As New MemoryStream()
                imageToConvert.Save(ms, formatOfImage)
                Ret = ms.ToArray()
            End Using
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return Ret

    End Function

    Public Shared Function GetParameterValue(ByVal parameterName As String) As String
        Dim result$ = ""
        Try
            Dim obj As Object = GetFieldValue("sys_SystemParameters", "sValue", "sName = N'" & parameterName & "'")
            result = CInt(obj)
        Catch ex As Exception
            result = ""
        End Try
        Return result
    End Function

    Public Shared Function GetSysDate() As Date
        Try
            If privateConnection.State = ConnectionState.Closed Then privateConnection.Open()
            Dim DA As New SqlDataAdapter("select GETDATE() AS sysDateTime ", privateConnection)
            Dim DT As New DataTable
            DA.Fill(DT)
            Return Convert.ToDateTime(DT.Rows(0)("sysDateTime"))
        Catch ex As Exception
            Return Now.Date
        End Try
    End Function

    Public Shared Function GetKTBarcode() As Integer
        Dim strvalue$ = GetParameterValue("KTBARCODE")
        Try
            Return CInt(strvalue)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function BarcodeDigit() As Integer

        Try
            Dim strvalue$ = GetParameterValue("BARCODEDIGIT")
            Return CInt(strvalue)
        Catch ex As Exception
            Return 10
        End Try
    End Function

    Public Shared Function IsNormalResult() As Integer
        Try
            Dim strvalue$ = GetParameterValue("IsNormalResult")
            Return CInt(strvalue)
        Catch ex As Exception
            Return 1
        End Try
    End Function

    Public Shared Function AutoGenerateBarcode() As Integer

        Try
            Dim strvalue$ = GetParameterValue("AUTOGENERATEBARCODE")
            Return CInt(strvalue)
        Catch ex As Exception
            Return 1
        End Try
    End Function

    Public Shared Function GetReportType() As Integer
        Dim strvalue$ = GetParameterValue("REPORTTYPE")
        Try
            Return CInt(strvalue)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function GetReportTypePrintAll() As Integer
        Dim strvalue$ = GetParameterValue("REPORTTYPEPRINTALL")
        Try
            Return CInt(strvalue)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function GetReportType2() As Integer
        Dim strvalue$ = GetParameterValue("REPORTTYPE_2")
        Try
            Return CInt(strvalue)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Lấy về tham số hệ thống RUNWITHLABLINKSERVICE.
    ''' </summary>
    ''' <returns>True: Nếu chạy cùng LABLink Service (=1)</returns>
    Public Shared Function GetRunWithLablinkService() As Boolean
        Dim strvalue$ = GetParameterValue("RUNWITHLABLINKSERVICE")
        Try
            If strvalue = "1" Then Return True
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "CheckSum Method"
    Public Shared Function GetCheckSumValue(ByVal frame As String) As String
        Dim checksum As String = "00"
        Dim sumOfChars As Integer = 0
        Dim complete As Boolean = False

        'take each byte in the string and add the values
        For idx As Integer = 0 To frame.Length - 1
            Dim byteVal As Integer = Convert.ToInt32(frame(idx))
            Select Case byteVal
                Case 2 'STX
                    sumOfChars = 0
                    Exit Select
                Case 3, 23 ' ETX,ETB
                    sumOfChars += byteVal
                    complete = True
                    Exit Select
                Case Else
                    sumOfChars += byteVal
                    Exit Select
            End Select

            If complete Then
                Exit For
            End If
        Next

        If sumOfChars > 0 Then
            'hex value mod 256 is checksum, return as hex value in upper case
            checksum = Convert.ToString(sumOfChars Mod 256, 16).ToUpper()
        End If
        'if checksum is only 1 char then prepend a 0
        Return (If(checksum.Length = 1, "0" & checksum, checksum))
    End Function
#End Region

#Region "Convert Array To DataTable"
    Public Shared Function ConvertToDataTable(ByVal result As String(,)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Data_name")
        dt.Columns.Add("Result")
        dt.Columns.Add("Measure_Unit")
        dt.Columns.Add("Normal_Level")
        dt.Columns.Add("Normal_LevelW")
        dt.Columns.Add("Data_Sequence")

        For j As Integer = 0 To result.GetLength(1) - 1
            Dim dr As DataRow = dt.NewRow
            For i As Integer = 0 To result.GetLength(0) - 1
                Try
                    dr(i) = result(i, j)
                Catch ex As Exception
                End Try
            Next i
            dt.Rows.Add(dr)
        Next j
        Return dt
    End Function
#End Region

    public Shared Function GetInversedDataTable(ByVal table As DataTable, ByVal columnX As String,
                                                ByVal columnY As String, ByVal columnZ As String, ByVal nullValue As String, ByVal sumValues As Boolean) As DataTable
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
                   ' returnTable.Columns.Add(columnXTemp + "_IsNormal")
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
                                   ' drReturn(rowColumnTitle + "_IsNormal") = dr("note")
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

End Class

