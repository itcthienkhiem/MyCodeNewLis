Imports System.Windows.Forms
Imports System.Drawing
Imports Vietbait.Lablink.Model


Public Class frmBiDataControlSelection_New

#Region "Attributes"

    Private dtBiDataControl As DataTable
    Public testId As Integer
    Private testypeId As Integer
    Public sortType As Integer
    Private regCount As Integer = 0
    Private myButtonSize, myImageSize As Size
    Private myPaddingSize As Padding
    Private myButtonBackColor As Color

#End Region

    Private Sub frmBiDataControlSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        testypeId = ModBusinessHelper.GetTestTypeIdFromTestId(testId)
        UiGroupBox1.Text = ModBusinessHelper.GetTestTypeNameFromTestTypeId(testypeId)
        dtBiDataControl = GetTestListFromTestTypeId(testypeId)
        cboSortType.Checked = sortType = 1
        myButtonSize = New Size(145, 50)
        myImageSize = New Size(32, 32)
        myPaddingSize = New Padding(10, 10, 10, 10)
        myButtonBackColor = Color.WhiteSmoke
        AddTabRegList()
    End Sub

    Private Sub AddTabRegList()
        Try

            Dim mySplitContaner As New SplitContainer

            Dim myTestGroupFlowLayout As New FlowLayoutPanel
            myTestGroupFlowLayout.Dock = DockStyle.Fill
            myTestGroupFlowLayout.AutoScroll = True
            Dim myGroupBox As New Janus.Windows.EditControls.UIGroupBox
            myGroupBox.Dock = DockStyle.Fill
            myGroupBox.Text = "Nhóm xét nghiệm"
            myGroupBox.Controls.Add(myTestGroupFlowLayout)
            mySplitContaner.Panel1.Controls.Add(myGroupBox)

            Dim myRegListFlowLayout As New FlowLayoutPanel
            myRegListFlowLayout.Dock = DockStyle.Fill
            myRegListFlowLayout.AutoScroll = True
            mySplitContaner.Panel2.Controls.Add(myRegListFlowLayout)

            mySplitContaner.Dock = DockStyle.Fill
            'mySplitContaner.MinimumSize = New Size(0, 0)
            mySplitContaner.Panel1MinSize = 0
            mySplitContaner.SplitterDistance = 19

            grbTestDetail.Controls.Add(mySplitContaner)

            'For Each dr2 As DataRow In dtTestGroupList.Rows
            '    If Vietbait.CommonLibrary.Utility.DecimaltoDbnull(dr2(TTestgroupList.Columns.DeviceId), -1) = dr(DDeviceList.Columns.DeviceId) Then
            '        Dim btnTestGroup As Janus.Windows.EditControls.UIButton = New Janus.Windows.EditControls.UIButton
            '        btnTestGroup.Text = dr2(TTestgroupList.Columns.TestGroupName).ToString()
            '        btnTestGroup.Tag = dr2(TTestgroupList.Columns.TestGroupId).ToString()
            '        btnTestGroup.BackColor = myButtonBackColor
            '        btnTestGroup.Size = myButtonSize
            '        btnTestGroup.ImageSize = myImageSize
            '        btnTestGroup.Margin = myPaddingSize

            '        AddHandler btnTestGroup.Click, AddressOf TestGroupButtonClick
            '        myTestGroupFlowLayout.Controls.Add(btnTestGroup)
            '    End If
            'Next


            For Each dr1 As DataRow In dtBiDataControl.Rows

                Dim btnRegData As Janus.Windows.EditControls.UIButton = New Janus.Windows.EditControls.UIButton
                btnRegData.Text = dr1("Data_Name").ToString()
                Dim testDataId As String = dr1("TestData_ID").ToString()
                btnRegData.Tag = testDataId
                btnRegData.BackColor = myButtonBackColor
                btnRegData.Size = myButtonSize
                btnRegData.ImageSize = myImageSize
                btnRegData.Margin = myPaddingSize
                btnRegData.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.Center
                btnRegData.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
                btnRegData.ImageList = imgAdminnistration
                If ModBusinessHelper.GetTestDetailStatus(testId, testDataId) Then
                    btnRegData.ImageIndex = 1
                    regCount += 1
                Else
                    btnRegData.ImageIndex = 0
                End If
                AddHandler btnRegData.Click, AddressOf RegButtonClick
                myRegListFlowLayout.Controls.Add(btnRegData)
            Next
            lblRegCount.Text = regCount
        Catch ex As Exception
        End Try
    End Sub


    ''' <summary>
    ''' Điều khiển sự kiện Click trên nút bấm đăng ký xét nghiệm
    ''' </summary>
    ''' <param name="sender">The sender.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub RegButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'Lấy về đối tượng gọi hàm
            Dim obj As Janus.Windows.EditControls.UIButton = sender

            'Đặt biến lưu trạng thái đăng ký của xét nghiệm
            Dim testIsNotRegisted As Boolean = obj.ImageIndex = 0

            If Not UpdateRegTestList(testId, obj.Tag, testIsNotRegisted) Then
                MsgBox("Có lỗi trong quá trình thực hiện")
            End If
            obj.ImageIndex = IIf(testIsNotRegisted, 1, 0)
            regCount = regCount + IIf(testIsNotRegisted, 1, -1)
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
    End Sub

    Private Sub cboSortType_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cboSortType.CheckedChanged
        'Thay đổi kiểu sắp xếp
        sortType = IIf(cboSortType.Checked, 1, 0)
    End Sub
End Class