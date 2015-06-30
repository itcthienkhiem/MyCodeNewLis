Imports VietBaIT.MultiLanguage
Public Class frm_ChooseTestDate
    Public test_date As String = Now.Date.ToShortDateString
    Public mv_bCancel As Boolean = True
    Public TestType_ID As Integer = -3
    Public ArrDate As ArrayList
    Public PrintInvoice As Boolean = False

    Private Sub frm_ChooseServiceForPayment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                cmdOK.PerformClick()
            Case Keys.Escape
                cmdCancel.PerformClick()
        End Select
    End Sub
    Private Sub frm_ChooseServiceForPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 0 To ArrDate.Count - 1
            cboRegType.Items.Add(ArrDate(i))
            test_date = ArrDate(i).Split(":")(ArrDate(i).Split(":").GetLength(0) - 1)
        Next
        If PrintInvoice Then cboRegType.Items.Add("Tất cả")
        If cboRegType.Items.Count > 0 Then
            cboRegType.SelectedIndex = 0
            cmdOK.Enabled = True
            cboRegType.Focus()
        Else
            cmdOK.Enabled = False
        End If
        SetLanguage(gv_sLanguageDisplay, Me, "prjBussiness", gv_oSqlCnn)
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        mv_bCancel = False
        Try
            If cboRegType.Text.ToUpper = "Tất cả".ToUpper Then
                TestType_ID = -3
            Else
                test_date = cboRegType.Text.Split(":")(cboRegType.Text.Split(":").GetLength(0) - 1)
                TestType_ID = cboRegType.Text.Split("-")(0)
            End If
        Catch ex As Exception
        End Try
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        mv_bCancel = True
        Me.Close()
    End Sub
End Class