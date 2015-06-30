Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports VietBaIT.MultiLanguage
Imports CrystalDecisions.Windows.Forms

Public Class frm_Department
    Public mv_bCancel As Boolean = True
    Public ds As New DataSet
    Public mv_sNewGroup As String = ""
    Public mv_bAdd As Boolean = True
    Private sTableName As String
    Private sField1Name As String
    Private sField2Name As String
    Private sField3Name As String
    Private sAnnouceField2 As String
    Private sAnnouceField2_1 As String
    Public bCallFromMenu As Boolean = True
    Private _Type As String
    Private sOldName As String = ""
    Private intOldSTT As Integer
    Public mv_DR As DataRow
    Public mv_sName As String = ""
    Public mv_ID As Integer = 0
    Private KeySTT As String = ""

    Private Sub frm_SourceList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cmdClose.Text.ToUpper = "Thoát".ToUpper AndAlso KeySTT.Trim <> "" Then
                Try
                    If Not bCallFromMenu Then
                        If grdList.RowCount > 0 Then
                            For i As Integer = 0 To grdList.RowCount - 1
                                If sDBnull(grdList.Item("STT", i).Value, "-100") = KeySTT Then
                                    mv_sName = sDBnull(grdList.Item("sName", i).Value.ToString)
                                    mv_ID = CInt(grdList.Item("ID", i).Value.ToString)
                                    mv_bCancel = False
                                    Me.Close()
                                    Return
                                End If
                            Next
                        End If
                    End If
                Catch ex As Exception
                End Try
                KeySTT = ""
            Else
                If grdList.RowCount > 0 Then
                    mv_sName = sDBnull(grdList.Item("sName", grdList.CurrentRow.Index).Value.ToString)
                    mv_ID = CInt(grdList.Item("ID", grdList.CurrentRow.Index).Value.ToString)
                    mv_bCancel = False
                    Me.Close()
                    Return
                End If
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            ProcessTabKey(True)
        End If
        If e.KeyCode = Keys.Escape Then cmdClose.PerformClick()
    End Sub
   
    Private Sub frm_Department_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If IsNumeric(e.KeyChar) Then
            KeySTT &= e.KeyChar.ToString
        End If
    End Sub

    Private Sub frm_DepartMent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            sTableName = "L_Department"
            sField1Name = "ID"
            sField2Name = "sNAME"
            sField3Name = "sDEsc"
            sAnnouceField2 = "Bạn phải nhập tên đơn vị"
            sAnnouceField2_1 = "Đã có đơn vị tên như vậy. Bạn nên nhập tên khác"
            Text = "Danh mục Đơn Vị"
            'SetLanguage(gv_sLanguageDisplay, Me, "prjBussiness", gv_oSqlCnn)
            LoadData()
            If Not bCallFromMenu Then
                grdList.TabStop = True
                grdList.TabIndex = 0
            End If
            'SetLanguage(gv_sLanguageDisplay, Me, "prjBussiness", gv_oSqlCnn)
        Catch ex As Exception
            'SetLanguage(gv_sLanguageDisplay, Me, "prjBussiness", gv_oSqlCnn)
        End Try
        
    End Sub

    Private Sub LoadData()
        Dim Da As New SqlDataAdapter("SELECT *,0 as STT FROM " & sTableName, gv_oSqlCnn)
        Try
            Da.Fill(ds, sTableName)
            changeData(ds.Tables(0))
            With grdList
                .AutoGenerateColumns = False
                .DataSource = ds.Tables(0).DefaultView
            End With
            If ds.Tables(0).Rows.Count > 0 Then
                cmdUpdate.Enabled = True
                cmdDel.Enabled = True
                cmdAdd.Focus()
            Else
                cmdUpdate.Enabled = False
                cmdDel.Enabled = False
                cmdAdd.Focus()
            End If
        Catch ex As Exception
            ShowErrMsg(ex.Message)
        End Try
    End Sub

    Sub changeData(ByRef Dt As DataTable)
        Dim i As Integer = 1
        For Each dr As DataRow In Dt.Rows
            dr("STT") = i
            i += 1
        Next
        Dt.AcceptChanges()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        mv_bAdd = True
        If cmdAdd.Text <> "Ghi" Then
            txtID.Text = getMaxID(sField1Name, sTableName).ToString
            txtName.Enabled = True
            txtDesc.Enabled = True
            '--------------------------------------
            txtName.Text = ""
            txtDesc.Text = ""
            '--------------------------------------
            cmdClose.Text = "Hủy"
            cmdAdd.Text = "Ghi"
            cmdUpdate.Enabled = False
            cmdDel.Enabled = False
            grdList.Enabled = False
            txtName.Focus()
        Else
            If UpdateData() Then
                txtName.Enabled = False
                txtDesc.Enabled = False
                grdList_CurrentCellChanged(grdList, e)
                cmdAdd.Text = "Thêm mới"
                cmdClose.Text = "Thoát"
                If ds.Tables(0).Rows.Count > 0 Then
                    cmdUpdate.Enabled = True
                    grdList.Enabled = True
                    cmdDel.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        If cmdClose.Text = "Hủy" Then
            txtName.Enabled = False
            txtDesc.Enabled = False
            grdList_CurrentCellChanged(grdList, e)
            cmdAdd.Enabled = True
            cmdAdd.Text = "Thêm mới"
            cmdUpdate.Text = "Sửa"
            cmdClose.Text = "Thoát"
            If ds.Tables(0).Rows.Count > 0 Then
                cmdUpdate.Enabled = True
                cmdDel.Enabled = True
                grdList.Enabled = True
                grdList.Focus()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        mv_bAdd = False
        If cmdUpdate.Text <> "Ghi" Then
            sOldName = txtName.Text.Trim
            txtName.Enabled = True
            txtDesc.Enabled = True
            '--------------------------------------
            cmdClose.Text = "Hủy"
            cmdUpdate.Text = "Ghi"
            cmdAdd.Enabled = False
            cmdDel.Enabled = False
            grdList.Enabled = False
            txtName.Focus()
        Else
            If UpdateData() Then
                txtName.Enabled = False
                txtDesc.Enabled = False
                grdList_CurrentCellChanged(grdList, e)
                cmdUpdate.Text = "Sửa"
                cmdClose.Text = "Thoát"
                cmdAdd.Enabled = True
                If ds.Tables(0).Rows.Count > 0 Then
                    cmdUpdate.Enabled = True
                    cmdDel.Enabled = True
                    grdList.Enabled = True
                End If
            End If
        End If
    End Sub
    Private Function UpdateData() As Boolean
        Dim sv_sSql As String
        Dim cmd As New SqlCommand
        If bCheckData() Then
            If mv_bAdd Then
                Dim sNewName As String = txtName.Text.Trim
                sv_sSql = "INSERT INTO " & sTableName & " VALUES(N'" & sNewName.Replace("'", "''") & "',N'" & CorrectValue(txtDesc.Text) & "')"
                With cmd
                    .CommandText = sv_sSql
                    .CommandType = CommandType.Text
                    .Connection = gv_oSqlCnn
                    .ExecuteNonQuery()
                End With
                Dim dr As DataRow = ds.Tables(0).NewRow
                With dr
                    .Item("STT") = grdList.RowCount + 1
                    .Item(sField1Name) = getExactlyMaxID(sField1Name, sTableName).ToString
                    .Item(sField2Name) = txtName.Text.Trim
                    .Item(sField3Name) = txtDesc.Text
                End With
                ds.Tables(0).Rows.Add(dr)
                ds.Tables(0).AcceptChanges()
                mv_bCancel = False
                MessageBox.Show("Đã thêm mới dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'Thực hiện đổi số TT
                Dim intRowAffected As Integer
                Dim sNewName As String = txtName.Text.Trim
                sv_sSql = "UPDATE  " & sTableName & " SET " & sField2Name & "=N'" & sNewName.Replace("'", "''") & "'," & sField3Name & "=N'" & CorrectValue(txtDesc.Text) & "' WHERE " & sField1Name & "=" & CInt(txtID.Text.Trim)
                With cmd
                    .CommandText = sv_sSql
                    .CommandType = CommandType.Text
                    .Connection = gv_oSqlCnn
                    intRowAffected = .ExecuteNonQuery()
                End With
                If intRowAffected > 0 Then
                    For Each dr As DataRow In ds.Tables(0).Rows
                        If dr(sField1Name) = CInt(txtID.Text.Trim) Then
                            dr(sField2Name) = txtName.Text.Trim
                            dr(sField3Name) = txtDesc.Text
                            Exit For
                        End If
                    Next
                    ds.Tables(0).AcceptChanges()
                    mv_bCancel = False
                    MessageBox.Show("Đã cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            Return True
        Else
            Return False
        End If
    End Function
    Private Function bCheckData() As Boolean
        If txtID.Text = "" Then
            Return False
            txtID.Focus()
        End If
        If txtName.Text = "" Then
            MessageBox.Show(sAnnouceField2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtName.Focus()
            Return False
        End If
        If bExistName(txtName.Text.Replace("'", "''").Trim) Then
            MessageBox.Show(sAnnouceField2_1, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtName.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function bExistName(ByVal pv_sName As String) As Boolean
        Try
            If mv_bAdd Then
            Else
                If sOldName.ToUpper.Equals(txtName.Text.Trim.ToUpper) Then
                    Return False
                End If
            End If
            Dim fv_sSql As String = "SELECT * FROM " & sTableName & " WHERE " & sField2Name & "=N'" & pv_sName & "'"
            Dim fv_da As New SqlDataAdapter(fv_sSql, gv_oSqlCnn)
            Dim fv_dt As New DataTable
            fv_da.Fill(fv_dt)
            If fv_dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub grdList_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.CurrentCellChanged
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                If grdList.CurrentRow.Index >= 0 Then
                    Dim _index As Integer = grdList.CurrentRow.Index
                    txtID.Text = grdList.Item("ID", _index).Value.ToString
                    txtName.Text = grdList.Item("sName", _index).Value.ToString
                    txtDesc.Text = grdList.Item("sDesc", _index).Value.ToString
                    'KeySTT = sDBnull(grdList.Item("STT", _index).Value, "-100")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        If ds.Tables(0).Rows.Count > 0 Then
            If grdList.CurrentRow.Index >= 0 Then
                If AcceptQuestion("Bạn có muốn xóa bản ghi có mã " & grdList.Item("ID", grdList.CurrentRow.Index).Value & "-" & grdList.Item("sName", grdList.CurrentRow.Index).Value) Then
                    DeleteData(grdList.Item("ID", grdList.CurrentRow.Index).Value)
                End If
            End If
        End If
    End Sub

    Private Sub DeleteData(ByVal pv_objValue As Object)
        Dim objDataService As New cls_List
        Dim sv_sErrMess As String = ""
        Dim bDelSuccess As Boolean = False

        sv_sErrMess = "Không được xóa dữ liệu này vì nó đã được sử dụng trong bảng khác. Đề nghị bạn kiểm tra lại"
        bDelSuccess = objDataService.bDeleteItem(sTableName, sField1Name, pv_objValue)
        Try
            If bDelSuccess Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    If dr(sField1Name) = pv_objValue Then
                        ds.Tables(0).Rows.Remove(dr)
                        Exit For
                    End If
                Next
            End If
            If ds.Tables(0).Rows.Count > 0 Then
                cmdUpdate.Enabled = True
                cmdDel.Enabled = True
                cmdAdd.Focus()
            Else
                cmdUpdate.Enabled = False
                cmdDel.Enabled = False
                cmdAdd.Focus()
            End If
        Catch ex As Exception
            ShowErrMsg(ex.Message)
        End Try

    End Sub
    Private Sub cmdGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ds.Tables(0).Rows.Count > 0 Then
            Try
                If grdList.CurrentRow.Index >= 0 Then
                    mv_DR = ds.Tables(0).Rows(grdList.CurrentRow.Index)
                    mv_bCancel = False
                    Me.Close()
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub grdList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdList.CellContentClick

    End Sub

    Private Sub grdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.DoubleClick
        Try
            If Not bCallFromMenu Then
                If grdList.RowCount > 0 Then
                    mv_sName = sDBnull(grdList.Item("sName", grdList.CurrentRow.Index).Value.ToString)
                    mv_ID = CInt(grdList.Item("ID", grdList.CurrentRow.Index).Value.ToString)
                    mv_bCancel = False
                    Me.Close()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdList.KeyDown
        Try
            'If e.KeyCode = Keys.Enter Then
            '    If Not bCallFromMenu Then
            '        If grdList.RowCount > 0 Then
            '            mv_sName = sDBnull(grdList.Item(1, grdList.CurrentRow.Index).Value.ToString)
            '            mv_ID = CInt(grdList.Item("ID", grdList.CurrentRow.Index).Value.ToString)
            '            mv_bCancel = False
            '            Me.Close()
            '        End If
            '    End If
            'End If
        Catch ex As Exception

        End Try
    End Sub
End Class