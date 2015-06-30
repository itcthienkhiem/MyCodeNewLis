Imports System.ComponentModel
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Drawing
Imports VietBaIT.CommonLibrary

Public Class frmDataControlSelectionByTestType
#Region "Attributes"
    Public dtDataControl As DataTable
    Public drDeviceList() As DataRow
    Public barcode As String
    Public testId As Integer
    Public patient_Id As Integer
    Public testType_ID As Integer
    Public dtRegList As DataTable
    Public sortType As Integer

#End Region

    Private Sub frmBiDataControlSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboSortType.Checked = sortType = 1
        AddTabRegList()
    End Sub

    Private Sub AddTabRegList()

        For Each dr As DataRow In drDeviceList
            Dim myTabPage As New TabPage()
            myTabPage.Text = dr("Device_Name")
            myTabPage.Tag = dr("Device_ID")

            Dim myFlowLayout As New FlowLayoutPanel
            myFlowLayout.Dock = DockStyle.Fill
            myFlowLayout.AutoScroll = True
            myTabPage.Controls.Add(myFlowLayout)
            tabRegList.TabPages.Add(myTabPage)

            If sortType = 1 Then
                dtDataControl.DefaultView.Sort = "Data_Name ASC"
                For Each dr1 As DataRowView In dtDataControl.DefaultView
                    If dr("Device_ID") = dr1("Device_ID") Then
                        Dim regdata As Janus.Windows.EditControls.UIButton = New Janus.Windows.EditControls.UIButton
                        regdata.Text = dr1("Data_Name").ToString()

                        regdata.BackColor = Color.WhiteSmoke
                        regdata.Size = New Size(150, 50)
                        regdata.ImageSize = New Size(32, 32)
                        regdata.Margin = New Padding(10, 10, 10, 10)
                        regdata.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.Center
                        regdata.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
                        regdata.ImageList = imgAdminnistration

                        Dim testDetail_ID = AlreadyRegistered(dr1("TestType_ID"), dr1("Data_Name"))
                        regdata.Tag = testDetail_ID
                        Select Case testDetail_ID
                            Case -1
                                'Đã chọn
                                regdata.ImageIndex = 1
                            Case 0
                                'Chưa chọn
                                regdata.ImageIndex = 0
                            Case Else
                                'Đã có KQ
                                regdata.ImageIndex = 2
                        End Select
                        AddHandler regdata.Click, AddressOf _click
                        myFlowLayout.Controls.Add(regdata)
                    End If
                Next

            Else
                For Each dr1 As DataRow In dtDataControl.Rows
                    If dr("Device_ID") = dr1("Device_ID") Then
                        Dim regdata As Janus.Windows.EditControls.UIButton = New Janus.Windows.EditControls.UIButton
                        regdata.Text = dr1("Data_Name").ToString()

                        regdata.BackColor = Color.WhiteSmoke
                        regdata.Size = New Size(150, 50)
                        regdata.ImageSize = New Size(32, 32)
                        regdata.Margin = New Padding(10, 10, 10, 10)
                        regdata.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.Center
                        regdata.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
                        regdata.ImageList = imgAdminnistration

                        Dim testDetail_ID = AlreadyRegistered(dr1("TestType_ID"), dr1("Data_Name"))
                        regdata.Tag = testDetail_ID
                        Select Case testDetail_ID
                            Case -1
                                'Đã chọn
                                regdata.ImageIndex = 1
                            Case 0
                                'Chưa chọn
                                regdata.ImageIndex = 0
                            Case Else
                                'Đã có KQ
                                regdata.ImageIndex = 2
                        End Select
                        AddHandler regdata.Click, AddressOf _click
                        myFlowLayout.Controls.Add(regdata)
                    End If
                Next
            End If


        Next

    End Sub

    Private Function AlreadyRegistered(ByVal testTypeId As String, ByVal paraName As String) As Integer
        For Each dr As DataRow In dtRegList.Rows
            If Utility.Int32Dbnull(dr("Test_ID"), -1) = testId And dr("TestType_ID").ToString = testTypeId And dr("Para_Name").ToString = paraName Then
                Return dr("TestDetail_ID")  'Da co KQ trong DB
            End If
        Next
        Return 0 'Chua dang ky
    End Function

    Sub _click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim obj As Janus.Windows.EditControls.UIButton = sender
            Dim idx As Integer = GetRowFromDtRegList(obj.Tag, obj.Text)
            Select Case obj.ImageIndex
                Case 0
                    Dim newDr As DataRow = dtRegList.NewRow()
                    newDr("Barcode") = txtBarcode.Text
                    newDr("CHON") = 1
                    newDr("TestDetail_ID") = -1
                    newDr("Test_Date") = lablinkhelper.Utilities.GetSysDate() 'globalVariables.SysDate
                    newDr("Para_Name") = obj.Text
                    newDr("Test_ID") = testId
                    newDr("Patient_ID") = patient_Id
                    newDr("TestType_ID") = testType_ID
                    newDr("Test_Result") = ""

                    For Each dr As DataRow In dtDataControl.Rows
                        If dr("Device_ID").ToString = tabRegList.SelectedTab.Tag And dr("Data_Name") = obj.Text Then
                            newDr("Normal_Level") = Utility.sDbnull(dr("Normal_Level"), "")
                            newDr("Normal_LevelW") = Utility.sDbnull(dr("Normal_LevelW"), "")
                            newDr("PrintData") = Utility.sDbnull(dr("Data_Print"), "")
                            newDr("Measure_Unit") = Utility.sDbnull(dr("Measure_Unit"), "")
                            newDr("Data_Sequence") = Utility.sDbnull(dr("Data_Sequence"), "")
                            Exit For

                        End If
                    Next
                    dtRegList.Rows.Add(newDr)
                    obj.ImageIndex = 1
                Case 1
                    obj.ImageIndex = 0
                    dtRegList.Rows.RemoveAt(idx)
                Case 2
                    MessageBox.Show("Test đã có kết quả. Không được xóa.", "Thông báo")

                    'If Utility.AcceptQuestion("Test đã có kết quả. Tiếp tục hủy ?", "", True) Then
                    '    Dim sqlCmd As SqlCommand = New SqlCommand("DELETE FROM T_RESULT_DETAIL WHERE TestDetail_ID=" & obj.Tag, gv_oSqlCnn)
                    '    sqlCmd.ExecuteNonQuery()
                    '    dtRegList.Rows.RemoveAt(idx)
                    '    obj.ImageIndex = 0
                    'End If

            End Select


        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình thực hiện")
        End Try

    End Sub

    Private Function GetRowFromDtRegList(ByVal testDetailId As Integer, ByVal paraName As String) As Integer
        For i As Integer = 0 To dtRegList.Rows.Count() - 1
            If Utility.Int32Dbnull(dtRegList.Rows(i)("Test_ID"), -1) = testId And dtRegList.Rows(i)("TestType_ID") = testType_ID And dtRegList.Rows(i)("Para_Name") = paraName Then
                Return i
            End If
        Next

        Return -1
    End Function

    Private Sub frmBiDataControlSelection_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.A
                    ClickAllTestButton(0)
                Case Keys.U
                    ClickAllTestButton(1)
            End Select
        End If

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub ClickAllTestButton(ByVal imageIndex As Integer)
        Try
            Dim myFlowLayout As New FlowLayoutPanel
            myFlowLayout = tabRegList.SelectedTab.GetNextControl(tabRegList.SelectedTab, True)
            For Each obj As Object In myFlowLayout.Controls
                Dim regdata As Janus.Windows.EditControls.UIButton = obj
                If regdata.ImageIndex = imageIndex Then
                    regdata.PerformClick()
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub
  
    Private Sub cboSortType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSortType.CheckedChanged
        sortType = IIf(cboSortType.Checked, 1, 0)
    End Sub
End Class