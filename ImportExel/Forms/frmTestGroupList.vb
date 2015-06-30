Imports System.Windows.Forms
Imports SubSonic
Imports Vietbait.Lablink.Model
Imports VietBaIT.CommonLibrary



Public Class frmTestGroupList

    Private dtTestGroup, dtDeviceList, dtDataControl As DataTable


    Private Sub frmTestGroupList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadTestGroupList()
            LoadDeviceList()
        Catch ex As Exception
            MessageBox.Show("Lỗi khởi tạo form", "Thông báo")
        End Try

    End Sub

    Private Sub LoadDeviceList()
        dtDeviceList = New SubSonic.Select().From(DDeviceList.Schema.Name).ExecuteDataSet.Tables(0)
        cboDeviceList.DataSource = dtDeviceList
        cboDeviceList.ValueMember = DDeviceList.Columns.DeviceId
        cboDeviceList.DisplayMember = DDeviceList.Columns.DeviceName
        cboDeviceList.SelectedIndex = 0
    End Sub

    Private Sub LoadTestGroupList()
        dtTestGroup = New SubSonic.Select(TTestgroupList.Schema.Name & ".*", DDeviceList.Columns.DeviceName).From(TTestgroupList.Schema.Name).InnerJoin(DDeviceList.DeviceIdColumn, TTestgroupList.DeviceIdColumn).ExecuteDataSet.Tables(0)
        grdTestGroupList.DataSource = dtTestGroup
    End Sub

    Private Sub grdTestGroupList_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTestGroupList.SelectionChanged
        Try
            Dim deviceId As Integer = grdTestGroupList.GetValue(TTestgroupList.Columns.DeviceId)
            dtDataControl = SPs.SpGetTestGroupByDeviceID(deviceId, grdTestGroupList.GetValue(TTestgroupList.Columns.TestGroupId)).GetDataSet.Tables(0)
            grdTestGroupRelation.DataSource = dtDataControl

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmTestGroupList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select



    End Sub


    Private Sub btnAddTestGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTestGroup.Click
        If txtTestGroupName.Text Is Nothing Then
            MessageBox.Show("Nhập tên nhóm", "Thông báo")
            txtTestGroupName.Focus()
            txtTestGroupName.SelectAll()
        Else
            Dim obj As New TTestgroupList
            obj.DeviceId = cboDeviceList.SelectedValue
            obj.TestGroupName = txtTestGroupName.Text
            obj.IsNew = True
            obj.Save()

            Dim dr As DataRow = dtTestGroup.NewRow
            dr(TTestgroupList.Columns.DeviceId) = cboDeviceList.SelectedValue
            dr(DDeviceList.Columns.DeviceName) = cboDeviceList.Text
            dr(TTestgroupList.Columns.TestGroupName) = txtTestGroupName.Text
            dr(TTestgroupList.Columns.TestGroupId) = TTestgroupList.CreateQuery().GetMax(TTestgroupList.Columns.TestGroupId)

            dtTestGroup.Rows.Add(dr)
            dtTestGroup.AcceptChanges()
            grdTestGroupList.MoveLast()

        End If
    End Sub

    Private Sub grdTestGroupRelation_CellValueChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTestGroupRelation.CellValueChanged
        Try
            If grdTestGroupRelation.GetValue("CHON") = 1 Then
                Dim obj As New TTestgroupDtl
                obj.TestGroupId = Utility.Int32Dbnull(grdTestGroupList.GetValue(TTestgroupList.Columns.TestGroupId), -1)
                obj.DataControlId = Utility.Int32Dbnull(grdTestGroupRelation.GetValue(DDataControl.Columns.DataControlId), -1)
                obj.IsNew = True
                obj.Save()
            Else
                Dim vQuery As SubSonic.Query = TTestgroupDtl.CreateQuery
                vQuery.QueryType = QueryType.Delete
                vQuery.WHERE(TTestgroupDtl.Columns.TestGroupId, grdTestGroupList.GetValue(TTestgroupList.Columns.TestGroupId)).WHERE(TTestgroupDtl.Columns.DataControlId, grdTestGroupRelation.GetValue(TTestgroupDtl.Columns.DataControlId))
                vQuery.Execute()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelTestGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelTestGroup.Click
        Try
            If grdTestGroupList.CurrentRow IsNot Nothing Then
                If Utility.AcceptQuestion("Xóa nhóm " & grdTestGroupList.GetValue(TTestgroupList.Columns.TestGroupName), "Thông báo", True) Then
                    Dim vQuery As SubSonic.Query
                    vQuery = TTestgroupDtl.CreateQuery()
                    vQuery.QueryType = QueryType.Delete
                    vQuery.WHERE(TTestgroupDtl.Columns.TestGroupId, grdTestGroupList.GetValue(TTestgroupList.Columns.TestGroupId))
                    vQuery.Execute()

                    vQuery = TTestgroupList.CreateQuery()
                    vQuery.QueryType = QueryType.Delete
                    vQuery.WHERE(TTestgroupList.Columns.TestGroupId, grdTestGroupList.GetValue(TTestgroupList.Columns.TestGroupId))
                    vQuery.Execute()

                    grdTestGroupList.CurrentRow.Delete()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub grdTestGroupList_CellEdited(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grdTestGroupList.CellEdited
        Try
            Dim record As Integer
            record = New SubSonic.Update(TTestgroupList.Schema.Name).Set(TTestgroupList.Columns.TestGroupName).EqualTo(grdTestGroupList.GetValue(TTestgroupList.Columns.TestGroupName)). _
            Where(TTestgroupList.Columns.TestGroupId).IsEqualTo(Utility.Int32Dbnull(grdTestGroupList.GetValue(TTestgroupList.Columns.TestGroupId), -1)).Execute()

        Catch ex As Exception

        End Try
    End Sub
End Class