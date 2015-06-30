Imports System.Windows.Forms
Imports BrightIdeasSoftware
Imports System.ComponentModel
Imports System.IO
Imports System.Xml.Serialization
Imports VietBaIT.CommonLibrary

Public Class frmBiDataControlSelection_ListViewStyle

#Region "Myproperties"

    Dim _myProperties As MyProperties

    Public Class MyProperties
        Public Sub New()
            _sortByName = True
            _viewStyle = 0
            _showGroup = False
            _showPrintableTestOnly = False
            _autoCleanFillterF3Press = False
        End Sub

        Private _sortByName As Boolean
        Private _viewStyle As Integer
        Private _showGroup As Boolean
        Private _showPrintableTestOnly As Boolean
        Private _autoCleanFillterF3Press As Boolean

        <Browsable(True), [ReadOnly](False), Category("UI Config"), Description("Sắp xếp các test theo tên hiển thị"), DisplayName("Sort By Name")> _
        Public Property SortByName() As Boolean
            Get
                Return _sortByName
            End Get
            Set(ByVal value As Boolean)
                _sortByName = value
            End Set
        End Property

        <Browsable(True), [ReadOnly](False), Category("UI Config"), Description("Chỉ hiển thị các test cho phép hiển thị"), DisplayName("Chỉ hiển thị các test cho phép hiển thị")> _
       Public Property ShowPrintableTestOnly() As Boolean
            Get
                Return _showPrintableTestOnly
            End Get
            Set(ByVal value As Boolean)
                _showPrintableTestOnly = value
            End Set
        End Property

        <Browsable(True), [ReadOnly](False), Category("UI Config"), Description("Xóa trắng ô nhập liệu khi nhấn F3"), DisplayName("Xóa trắng ô nhập liệu khi nhấn F3")> _
       Public Property AutoCleanFillterF3Press() As Boolean
            Get
                Return _autoCleanFillterF3Press
            End Get
            Set(ByVal value As Boolean)
                _autoCleanFillterF3Press = value
            End Set
        End Property

        <Browsable(False), [ReadOnly](False), Category("UI Config"), Description("Lưu trạng thái hiển thị"), DisplayName("ViewStyleValue")> _
        Public Property ViewStyle() As Integer
            Get
                Return _viewStyle
            End Get
            Set(ByVal value As Integer)
                _viewStyle = value
            End Set
        End Property

        <Browsable(False), [ReadOnly](False), Category("UI Config"), Description("Hiển thị theo nhóm"), DisplayName("ShowGroup")> _
        Public Property ShowGroup() As Boolean
            Get
                Return _showGroup
            End Get
            Set(ByVal value As Boolean)
                _showGroup = value
            End Set
        End Property

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

#Region "Attributes"

    ''' <summary>
    ''' 0:Thêm xét nghiệm, 1: Thêm kết quả
    ''' </summary>
    Public action As Integer
    Public dtRegList As DataTable
    Dim testypeId As Integer
    Private dtBiDataControl As DataTable
    Public testId As Integer
    Public sortType As Integer
    Private regCount As Integer = 0
    Private isLoaded As Boolean = False
    Private Const ColTestDetailStatusName As String = "testDetailStatus"
    Private Const ColRealNormal As String = "realNormal"
    Private currentindex = 0
    Private _isSelectAll = False

    ''' <summary>
    ''' Bảng lưu các kết quả đã có của bệnh nhân
    ''' </summary>
    Private _tempPatientsResult As DataTable
    ''' <summary>
    ''' Bảng lưu các đăng ký của bệnh nhân
    ''' </summary>
    Private _tempPatientReg As DataTable

    ''' <summary>
    ''' Bảng lưu các thiết bị của loại xét nghiệm đang chọn
    ''' </summary>
    Private _tblDevice As DataTable

#End Region

#Region "Delegate Function for List"

    Private Function CheckImageGetter(ByVal x As Object) As Object
        Dim obj As DataRowView = x
        Select Case obj.Row.Item(ColTestDetailStatusName)
            Case 0
                Return "uncheck"
            Case 1
                Return "check"
            Case 2
                Return "disable"
        End Select
    End Function

    Private Function StatusGetter(ByVal x As Object) As Object
        Dim obj As DataRowView = x
        Select Case obj.Row.Item(ColTestDetailStatusName)
            Case 0
                Return "Chưa đăng ký"
            Case 1
                Return "Đã đăng ký và chưa có kết quả"
            Case 2
                Return "Đã đăng ký và đã có kết quả"
        End Select
    End Function

    'Private Function coltestDetailStatusGroupKeyGetter(ByVal x As Object) As Object
    '    Dim obj As DataRowView = x
    '    Return obj.Row.Item(ColTestDetailStatusName)
    'End Function

#End Region

#Region "Private Method"

    Private Sub checkTestIsRegisted()
        Try
            If Not dtBiDataControl.Columns.Contains(ColTestDetailStatusName) Then dtBiDataControl.Columns.Add(ColTestDetailStatusName)
            If Not dtBiDataControl.Columns.Contains(ColRealNormal) Then dtBiDataControl.Columns.Add(ColRealNormal)

            For Each dr As DataRow In dtBiDataControl.Rows
                Dim tempint As Integer = GetTestDetailStatus(Utility.sDbnull(dr("TestData_ID")), Utility.sDbnull(dr("Data_Name")))
                dr(ColTestDetailStatusName) = tempint
                regCount = regCount + IIf(tempint = 1 Or tempint = 2, 1, 0)
                If action = 1 Then
                    Dim count As Integer = dtRegList.Select(String.Format("Para_Name = '{0}' And Test_ID = {1}", dr.Item("Data_Name"), testId)).Length
                    If count > 0 Then
                        If dr(ColTestDetailStatusName) <> 2 Then dr(ColTestDetailStatusName) = 1
                    Else
                        If dr(ColTestDetailStatusName) <> 2 Then dr(ColTestDetailStatusName) = 0
                    End If
                End If
            Next
            lblRegCount.Text = regCount
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Trả về trạng thái của một chi tiết:0-Chưa được đăng ký, 1:đã đăng ký, 2:đã có kết quả
    ''' </summary>
    ''' <param name="patient">The patient.</param>
    ''' <param name="testtypeId">The testtype id.</param>
    ''' <returns></returns>
    Public Function GetTestDetailStatus(ByVal testDataId As String, ByVal pTestDataName As String) As Integer
        Try
            Dim result, count As Integer
            'Tìm trong bảng kết quả
            count = _tempPatientsResult.Select(String.Format("Para_Name = '{0}'", pTestDataName)).Length
            'Nếu có trong bảng kết quả trả về 2
            If count > 0 Then
                result = 2
            Else 'Nếu chưa có trong bảng kết quả thì tìm trong bảng đăng ký
                count = _tempPatientReg.Select(String.Format("TestData_ID = '{0}'", testDataId)).Length
                result = IIf(count > 0, 1, 0)
            End If
            Return result
        Catch ex As Exception
            Return 0
        End Try
    End Function


#End Region

    Private Sub frmBiDataControlSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadProperties()
            'Lấy về testTypeId
            testypeId = GetTestTypeIdFromTestId(testId)

            colData_Name.ImageGetter = New ImageGetterDelegate(AddressOf CheckImageGetter)
            coltestDetailStatus.AspectGetter = New AspectGetterDelegate(AddressOf StatusGetter)
            coltestDetailStatus.GroupWithItemCountFormat = "Có ({1} Test) {0}"
            coltestDetailStatus.GroupWithItemCountSingularFormat = "Có ({1} Test) {0}"
            'coltestDetailStatus.GroupKeyGetter = New GroupKeyGetterDelegate(AddressOf coltestDetailStatusGroupKeyGetter)

            _tempPatientsResult = GetTestResultFromTestId(testId)
            _tempPatientReg = GetRegListFromTestId(testId)
            _tblDevice = GetDeviceListByTestTypeId(testypeId)

            UiGroupBox1.Text = GetTestTypeNameFromTestTypeId(testypeId)
            dtBiDataControl = GetTestListFromTestTypeId(testypeId, _myProperties.SortByName, _myProperties.ShowPrintableTestOnly)
            checkTestIsRegisted()
            lstTestDetail.DataSource = dtBiDataControl.DefaultView
            isLoaded = True
            cboViewStyle.SelectedIndex = _myProperties.ViewStyle

            If chkShowGroup.Checked = _myProperties.ShowGroup Then
                isLoaded = False
                chkShowGroup.Checked = Not chkShowGroup.Checked
                isLoaded = True
            End If
            chkShowGroup.Checked = _myProperties.ShowGroup

            currentindex = 1

            Dim rbd = New RowBorderDecoration()
            rbd.BorderPen = New Pen(Color.SeaGreen, 2)
            rbd.FillBrush = Nothing
            rbd.CornerRounding = 4.0F
            Dim hotItemStyle2 = New HotItemStyle()
            hotItemStyle2.Decoration = rbd
            lstTestDetail.HotItemStyle = hotItemStyle2

        Catch ex As Exception

        Finally
            txtFillter.Focus()
        End Try
    End Sub

    Private Sub frmBiDataControlSelection_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Close()
            Case Keys.F3
                If _myProperties.AutoCleanFillterF3Press Then
                    txtFillter.Text = ""
                Else
                    txtFillter.SelectAll()
                End If
                txtFillter.Focus()
        End Select
        If e.Control And (e.KeyCode = Keys.A) Then
            btnSelectAll.PerformClick()
        End If
        If e.Alt Then
            If (e.KeyCode = Keys.N) Then
                lstTestDetail.SelectedIndex = lstTestDetail.SelectedIndex + 1
            ElseIf e.KeyCode = Keys.P Then
                lstTestDetail.SelectedIndex = lstTestDetail.SelectedIndex - 1
            End If
        End If
    End Sub

    Private Sub cboViewStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboViewStyle.SelectedIndexChanged
        If Not isLoaded Then Return

        Select Case cboViewStyle.SelectedIndex
            Case 0
                lstTestDetail.View = View.LargeIcon
            Case 1
                lstTestDetail.View = View.Details
            Case 2
                lstTestDetail.View = View.SmallIcon
            Case 3
                lstTestDetail.View = View.List
            Case 4
                lstTestDetail.View = View.Tile
        End Select
        _myProperties.ViewStyle = lstTestDetail.View
        lstTestDetail.Focus()
    End Sub

    Private Sub chkShowGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowGroup.CheckedChanged
        If Not isLoaded Then Return
        If chkShowGroup.Checked And lstTestDetail.View = View.List Then
            chkShowGroup.Checked = False
        Else
            If chkShowGroup.Checked Then
                lstTestDetail.Sort(coltestDetailStatus, SortOrder.Ascending)
                lstTestDetail.ShowGroups = True
                lstTestDetail.BuildList()
            Else
                If Not _myProperties.SortByName Then lstTestDetail.Sort(colData_Sequence, SortOrder.Ascending)
                lstTestDetail.ShowGroups = False
                lstTestDetail.BuildList()
            End If
        End If
        _myProperties.ShowGroup = chkShowGroup.Checked
        lstTestDetail.Focus()
    End Sub

    Private Sub lstTestDetail_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstTestDetail.MouseUp
        If e.Button = MouseButtons.Left And e.Clicks = 1 Then
            If lstTestDetail.SelectedObjects.Count <> 0 Then
                Dim obj As DataRowView = lstTestDetail.SelectedObjects(0)
                If obj.Row.Item(ColTestDetailStatusName) <> 2 Then
                    Dim registed As Integer = IIf(obj.Row.Item(ColTestDetailStatusName) = 1, 0, 1)
                    obj.Row.Item(ColTestDetailStatusName) = registed
                    regCount += IIf(registed, 1, -1)
                    If action = 0 Then
                        If Not UpdateRegTestList(testId, obj.Row.Item("TestData_ID"), registed) Then
                            MsgBox("Có lỗi trong quá trình thực hiện")
                        End If
                    ElseIf action = 1 Then
                        'todo:Thêm hoặc xóa xét nghiệm
                        If Not UpdateTempResult(testId, obj.Row, registed) Then
                            MsgBox("Có lỗi trong quá trình thực hiện")
                        End If
                    End If
                    lblRegCount.Text = regCount
                    If lstTestDetail.ShowGroups Then lstTestDetail.BuildGroups()
                End If
            End If
        End If
    End Sub

    Private Sub lstTestDetail_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstTestDetail.KeyDown
        If (e.KeyCode = Keys.Space) Or (e.KeyCode = Keys.Enter) Then
            If lstTestDetail.SelectedObjects.Count <> 0 Then
                Dim obj As DataRowView = lstTestDetail.SelectedObjects(0)
                If obj.Row.Item(ColTestDetailStatusName) <> 2 Then
                    Dim registed As Integer = IIf(obj.Row.Item(ColTestDetailStatusName) = 1, 0, 1)
                    obj.Row.Item(ColTestDetailStatusName) = registed
                    regCount += IIf(registed, 1, -1)
                    If action = 0 Then
                        If Not UpdateRegTestList(testId, obj.Row.Item("TestData_ID"), registed) Then
                            MsgBox("Có lỗi trong quá trình thực hiện")
                        End If
                    ElseIf action = 1 Then
                        'todo:Thêm hoặc xóa xét nghiệm
                        If Not UpdateTempResult(testId, obj.Row, registed) Then
                            MsgBox("Có lỗi trong quá trình thực hiện")
                        End If
                    End If
                    lblRegCount.Text = regCount
                    If lstTestDetail.ShowGroups Then lstTestDetail.BuildGroups()
                End If
            End If
        End If
        
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        If Not _isSelectAll Then
            Try
                regCount = 0
                For Each obj As OLVListItem In lstTestDetail.Items
                    If obj.RowObject.row.item(ColTestDetailStatusName) <> 2 Then
                        If action = 0 Then
                            If Not UpdateRegTestList(testId, obj.RowObject.row.item("TestData_ID"), 1) Then
                                MsgBox("Có lỗi trong quá trình thực hiện")
                            Else
                                obj.RowObject.row.item(ColTestDetailStatusName) = 1
                                regCount += 1
                            End If
                        ElseIf action = 1 Then
                            If Not UpdateTempResult(testId, obj.RowObject.row, 1) Then
                                MsgBox("Có lỗi trong quá trình thực hiện")
                            Else
                                obj.RowObject.row.item(ColTestDetailStatusName) = 1
                                regCount += 1
                            End If
                        End If
                    Else
                        regCount += 1
                    End If
                Next
                lblRegCount.Text = regCount
                _isSelectAll = True
                btnSelectAll.Text = "Hủy Chọn Tất Cả (Ctrl+A)"
                If lstTestDetail.ShowGroups Then lstTestDetail.BuildGroups()
            Catch ex As Exception

            End Try
        Else

            regCount = 0
            For Each obj As OLVListItem In lstTestDetail.Items
                If obj.RowObject.row.item(ColTestDetailStatusName) <> 2 Then
                    If action = 0 Then
                        If Not UpdateRegTestList(testId, obj.RowObject.row.item("TestData_ID"), 0) Then
                            MsgBox("Có lỗi trong quá trình thực hiện")
                        Else
                            obj.RowObject.row.item(ColTestDetailStatusName) = 0
                        End If
                    ElseIf action = 1 Then
                        If Not UpdateTempResult(testId, obj.RowObject.row, 0) Then
                            MsgBox("Có lỗi trong quá trình thực hiện")
                        Else
                            obj.RowObject.row.item(ColTestDetailStatusName) = 0
                        End If
                    End If
                Else
                    regCount += 1
                End If
            Next
            lblRegCount.Text = regCount
            If lstTestDetail.ShowGroups Then lstTestDetail.BuildGroups()
            _isSelectAll = False
            btnSelectAll.Text = "Chọn Tất Cả (Ctrl+A)"
        End If
        

    End Sub

    Private Function UpdateTempResult(ByVal ptestid As Integer, ByVal dr As DataRow, ByVal psave As Boolean) As Boolean
        Try
            Dim drs2() As DataRow = dtRegList.Select(String.Format("Para_Name = '{0}' And Test_ID = {1}", dr.Item("Data_Name"), ptestid))
            If psave Then
                'todo:Thêm kết quả mới vào bảng xét nghiệm
                If drs2.GetLength(0) = 0 Then
                    Dim patient_id = GetPatientIdFromTestId(testId)
                    Dim newDr As DataRow = dtRegList.NewRow()
                    newDr("Barcode") = txtBarcode.Text
                    newDr("CHON") = 1
                    newDr("TestDetail_ID") = -1
                    newDr("Test_Date") = lablinkhelper.Utilities.GetSysDate() 'globalVariables.SysDate
                    newDr("Para_Name") = dr.Item("Data_Name")
                    newDr("Test_ID") = testId
                    newDr("Patient_ID") = patient_id
                    newDr("TestType_ID") = testypeId
                    newDr("Test_Result") = ""
                    newDr("Normal_Level") = Utility.sDbnull(dr("Normal_Level"), "")
                    newDr("Normal_LevelW") = Utility.sDbnull(dr("Normal_LevelW"), "")
                    newDr("PrintData") = Utility.sDbnull(dr("Data_Print"), "")
                    newDr("Measure_Unit") = Utility.sDbnull(dr("Measure_Unit"), "")
                    currentindex = currentindex - 1
                    newDr("Data_Sequence") = Utility.Int32Dbnull(dr("Data_Sequence"), 0)
                    dtRegList.Rows.InsertAt(newDr, 0)
                End If
                Return True
            Else
                If drs2.GetLength(0) > 0 Then
                    drs2(0).Delete()
                End If
                Return True
            End If
        Catch ex As Exception
            Return False
        Finally
            dtRegList.AcceptChanges()
        End Try

    End Function

    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        Dim f As New FrmSetting
        f.Text = Text
        f.PropertiesObject = _myProperties
        f.ShowDialog(Me)
        SaveProperties()
    End Sub

    Private Sub frmBiDataControlSelection_ListViewStyle_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SaveProperties()
    End Sub
    
    Private Sub txtFillter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFillter.TextChanged
        dtBiDataControl.DefaultView.RowFilter = String.Format("Data_Name like '%{0}%'", txtFillter.Text)
        lstTestDetail.SelectedIndex = 0
    End Sub

    Private Sub txtFillter_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFillter.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                lstTestDetail_KeyDown(lstTestDetail, New System.Windows.Forms.KeyEventArgs(Keys.Enter))
                txtFillter.Text = ""
                frmBiDataControlSelection_KeyUp(Me, New System.Windows.Forms.KeyEventArgs(Keys.F3))
        End Select
        
        

    End Sub
End Class