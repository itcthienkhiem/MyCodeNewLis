Imports System.Windows.Forms
Imports System.Drawing
Imports Vietbait.Lablink.Model


Public Class frmBiDataControlSelection
#Region "Attributes"
    Public dtBiDataControl As DataTable
    Public barcode As String
    Public testId As Integer
    Public testypeId As Integer
    Public dtTestTypeandTRegList As DataTable
    Public arrDeviceList() As DataRow
    Public dtTestGroupList, dtTestGroupDetail As DataTable
    Public sortType As Integer
    Private regCount As Integer = 0
    Private myButtonSize, myImageSize As Size
    Private myPaddingSize As Padding
    Private myButtonBackColor As Color
    Private btnRegCollection() As Janus.Windows.EditControls.UIButton
    Dim myRegListFlowLayout As New FlowLayoutPanel

#End Region

    Private Sub frmBiDataControlSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboSortType.Checked = sortType = 1
        myButtonSize = New Size(145, 50)
        myImageSize = New Size(32, 32)
        myPaddingSize = New Padding(10, 10, 10, 10)
        myButtonBackColor = Color.WhiteSmoke
        AddTabRegList()
    End Sub

    Private Sub AddTabRegList()
        'Dim frm As New FrmPatientRegistration_L1
        'frm._testTypeiD = testypeId
        'If gv_oSqlCnn.State = ConnectionState.Closed Then gv_oSqlCnn.Open()
        'Dim da As New SqlDataAdapter("SELECT * FROM D_DEVICE_LIST ddl WHERE ddl.TestType_ID=" & testypeId, gv_oSqlCnn)
        'Dim dt As New DataTable
        'da.Fill(dt)
        Try
            For Each dr As DataRow In arrDeviceList
                Dim mySplitContaner As New SplitContainer
                Dim myTabPage As New TabPage()
                myTabPage.Text = dr("Device_Name")
                myTabPage.Tag = dr("Device_ID")

                Dim myTestGroupFlowLayout As New FlowLayoutPanel
                myTestGroupFlowLayout.Dock = DockStyle.Fill
                myTestGroupFlowLayout.AutoScroll = True
                Dim myGroupBox As New Janus.Windows.EditControls.UIGroupBox
                myGroupBox.Dock = DockStyle.Fill
                myGroupBox.Text = "Nhóm xét nghiệm"
                myGroupBox.Controls.Add(myTestGroupFlowLayout)
                mySplitContaner.Panel1.Controls.Add(myGroupBox)


                myRegListFlowLayout.Dock = DockStyle.Fill
                myRegListFlowLayout.AutoScroll = True
                mySplitContaner.Panel2.Controls.Add(myRegListFlowLayout)

                mySplitContaner.Dock = DockStyle.Fill
                'mySplitContaner.MinimumSize = New Size(0, 0)
                mySplitContaner.Panel1MinSize = 0
                mySplitContaner.SplitterDistance = 19
                'myTabPage.Controls.Add(myFlowLayout)

                myTabPage.Controls.Add(mySplitContaner)
                tabRegList.TabPages.Add(myTabPage)



                For Each dr2 As DataRow In dtTestGroupList.Rows
                    If Vietbait.CommonLibrary.Utility.DecimaltoDbnull(dr2(TTestgroupList.Columns.DeviceId), -1) = dr(DDeviceList.Columns.DeviceId) Then
                        Dim btnTestGroup As Janus.Windows.EditControls.UIButton = New Janus.Windows.EditControls.UIButton
                        btnTestGroup.Text = dr2(TTestgroupList.Columns.TestGroupName).ToString()
                        btnTestGroup.Tag = dr2(TTestgroupList.Columns.TestGroupId).ToString()
                        btnTestGroup.BackColor = myButtonBackColor
                        btnTestGroup.Size = myButtonSize
                        btnTestGroup.ImageSize = myImageSize
                        btnTestGroup.Margin = myPaddingSize

                        AddHandler btnTestGroup.Click, AddressOf TestGroupButtonClick
                        myTestGroupFlowLayout.Controls.Add(btnTestGroup)
                    End If
                Next


                For Each dr1 As DataRow In dtBiDataControl.Rows
                    If dr("Device_ID") = dr1("Device_ID") Then
                        Dim btnRegData As Janus.Windows.EditControls.UIButton = New Janus.Windows.EditControls.UIButton
                        btnRegData.Text = dr1("Data_Name").ToString()
                        btnRegData.Tag = dr1("Alias_Name").ToString()
                        btnRegData.BackColor = myButtonBackColor
                        btnRegData.Size = myButtonSize
                        btnRegData.ImageSize = myImageSize
                        btnRegData.Margin = myPaddingSize
                        btnRegData.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.Center
                        btnRegData.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
                        btnRegData.ImageList = imgAdminnistration

                        If AlreadyRegistered(dr("Device_ID"), dr1("Alias_Name")) Then
                            btnRegData.ImageIndex = 1
                            regCount += 1
                        Else
                            btnRegData.ImageIndex = 0
                        End If

                        AddHandler btnRegData.Click, AddressOf _click
                        myRegListFlowLayout.Controls.Add(btnRegData)
                    End If
                Next
            Next
            lblRegCount.Text = regCount
        Catch ex As Exception
        End Try
    End Sub

    Private Function AlreadyRegistered(ByVal deviceId As String, ByVal aliasName As String) As Boolean
        If dtTestTypeandTRegList Is Nothing Then
            Return False
        End If

        Return dtTestTypeandTRegList.Rows.Cast(Of DataRow)().Any(Function(dr) dr("Barcode").ToString() = txtBarcode.Text And dr("Device_ID").ToString = deviceId And dr("Alias_Name").ToString = aliasName)
       
    End Function

    Private Function SaveRegTestList(ByVal pBarcode As String, _
                                  ByVal pTestID As Int64, _
                                  ByVal pAlias_Name As String, _
                                  ByVal pPara_Name As String, _
                                  ByVal pSaveorDelete As Boolean, _
                                    ByVal pDeviceID As Int16) As Boolean
        Try
            Vietbait.Lablink.Model.SPs.SpCreateRegList(pTestID, pDeviceID, pBarcode, pAlias_Name, pPara_Name, pSaveorDelete).Execute()
            Return (True)
        Catch ex As Exception
            Return False
        End Try

    End Function

    Sub TestGroupButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim obj As Janus.Windows.EditControls.UIButton = sender
            Dim mySplitContaner As New SplitContainer
            mySplitContaner = tabRegList.SelectedTab.Controls(0)
            Dim myRegListFlowLayout As FlowLayoutPanel
            myRegListFlowLayout = mySplitContaner.Panel2.Controls(0)
            For Each dr As DataRow In dtTestGroupDetail.Rows
                If dr(TTestgroupDtl.Columns.TestGroupId) = obj.Tag Then
                    For i As Integer = 0 To myRegListFlowLayout.Controls.Count - 1
                        Dim btnRegData As Janus.Windows.EditControls.UIButton = myRegListFlowLayout.Controls(i)
                        If btnRegData.Tag = dr(DDataControl.Columns.AliasName) And btnRegData.ImageIndex = 0 Then
                            btnRegData.PerformClick()
                        End If
                    Next
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub _click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim obj As Janus.Windows.EditControls.UIButton = sender
            If obj.ImageIndex = 0 Then
                If Not SaveRegTestList(txtBarcode.Text, testId, obj.Tag, obj.Text, 1, CInt(tabRegList.SelectedTab.Tag)) Then
                    MsgBox("Có lỗi trong quá trình thực hiện")
                    Return
                End If

                obj.ImageIndex = 1
                regCount += 1
                'obj.Image = imgAdminnistration.Images(1)
            Else
                If Not SaveRegTestList(txtBarcode.Text, testId, obj.Tag, obj.Text, 0, CInt(tabRegList.SelectedTab.Tag)) Then
                    MsgBox("Có lỗi trong quá trình thực hiện")
                    Return
                End If

                obj.ImageIndex = 0
                regCount -= 1
                'obj.Image = Nothing
            End If

            lblRegCount.Text = regCount
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình thực hiện")
        End Try

    End Sub

    Private Sub frmBiDataControlSelection_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Close()
        End Select

        If e.Control And (e.KeyCode = Keys.A) Then
            For Each obj As Janus.Windows.EditControls.UIButton In myRegListFlowLayout.Controls
                SaveRegTestList(txtBarcode.Text, testId, obj.Tag, obj.Text, 1, CInt(tabRegList.SelectedTab.Tag))
                obj.ImageIndex = 1
            Next
            regCount = myRegListFlowLayout.Controls.Count
            lblRegCount.Text = regCount
        End If

        If e.Control And (e.KeyCode = Keys.U) Then
            For Each obj As Janus.Windows.EditControls.UIButton In myRegListFlowLayout.Controls
                SaveRegTestList(txtBarcode.Text, testId, obj.Tag, obj.Text, 0, CInt(tabRegList.SelectedTab.Tag))
                obj.ImageIndex = 0
            Next
            regCount = 0
            lblRegCount.Text = regCount
        End If
    End Sub

    Private Sub cboSortType_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cboSortType.CheckedChanged
        'Thay đổi kiểu sắp xếp
        sortType = IIf(cboSortType.Checked, 1, 0)
    End Sub
End Class