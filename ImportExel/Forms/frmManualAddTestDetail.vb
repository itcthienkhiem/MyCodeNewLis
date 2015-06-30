Imports System.Windows.Forms

Public Class FrmManualAddTestDetail
    Public m_cancel As Boolean

    Private Sub frmManualAddTestDetail_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                m_cancel = True
                Me.Close()
            Case Keys.Enter
                ProcessTabKey(True)
        End Select
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtPara_Name.Text) Then
            MessageBox.Show("Chưa nhập tên thông số", "Thông báo")
            Return
        End If
        m_cancel = False
        Me.Close()
    End Sub

End Class