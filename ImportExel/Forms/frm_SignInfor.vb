Imports VietBaIT.MultiLanguage
Public Class frm_SignInfor
    Public mv_bChapNhan As Boolean = False
    Public mv_sFontName As String
    Public mv_sFontStyle As String
    Public mv_sFontSize As String
    Private Sub cmdQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuit.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'thuc hien lay gia tri
        mv_bChapNhan = True
        Me.Close()
    End Sub
    Private Sub GetFontList()
        Try
            For Each s As FontFamily In FontFamily.Families
                cboFontName.Items.Add(s.Name)
            Next
            For i As Integer = 6 To 72
                cboFontSize.Items.Add(i.ToString)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetFontInfor(ByVal pv_sFontName As String, ByVal pv_sFontStyple As String, ByVal pv_sFontSize As String)
        Dim sv_bFound As Boolean = False
        Try
            For i As Integer = 0 To cboFontName.Items.Count - 1
                If cboFontName.Items(i).ToString.Trim.ToUpper.Equals(pv_sFontName.Trim.ToUpper) Then
                    cboFontName.SelectedIndex = i
                    sv_bFound = True
                    Exit For
                End If
            Next
            If Not sv_bFound Then cboFontName.Text = "Arial"
            sv_bFound = False

            'For i As Integer = 0 To cboFontStyle.Items.Count - 1
            '    If cboFontStyle.Items(i).ToString.Trim.ToUpper.Equals(pv_sFontStyple.Trim.ToUpper) Then
            '        cboFontStyle.SelectedIndex = i
            '        sv_bFound = True
            '        Exit For
            '    End If
            'Next
            cboFontStyle.SelectedValue = pv_sFontStyple.Trim
            If Not sv_bFound Then cboFontStyle.SelectedIndex = 2
            sv_bFound = False
            For i As Integer = 0 To cboFontSize.Items.Count - 1
                If cboFontSize.Items(i).ToString.Trim.ToUpper.Equals(pv_sFontSize.Trim.ToUpper) Then
                    cboFontSize.SelectedIndex = i
                    sv_bFound = True
                    Exit For
                End If
            Next
            If Not sv_bFound Then cboFontSize.Text = "8"
            sv_bFound = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_RegInfor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GetFontList()
            SetFontInfor(mv_sFontName, mv_sFontStyle, mv_sFontSize)
            txtBaoCao.Enabled = False
            txtBaoCao.BackColor = Color.WhiteSmoke
            SetLanguage(globalModule.gv_sLanguageDisplay, Me, "prjBussiness", globalModule.gv_oSqlCnn)
        Catch ex As Exception
            SetLanguage(globalModule.gv_sLanguageDisplay, Me, "prjBussiness", globalModule.gv_oSqlCnn)
        End Try

    End Sub
End Class