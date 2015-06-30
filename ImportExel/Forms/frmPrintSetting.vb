Imports System.IO

Namespace LABLink1_V2
    Public Class frmPrintSetting
        Dim _printer() As String
        Dim _SettingFile As String = "PrinterSetting.txt"

        Private Sub frmPrintSetting_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
            Select Case e.KeyCode
                Case Keys.Escape
                    Me.Close()
            End Select
        End Sub

        Private Sub frmPrintSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            LoadFileSetting()
            LoadPrintSetting()

        End Sub


        Private Sub LoadPrintSetting()
            If Printing.PrinterSettings.InstalledPrinters.Count > 0 Then
                For Each strPrinter As String In Printing.PrinterSettings.InstalledPrinters
                    Me.cboPrinter.Items.Add(strPrinter)
                Next
            End If
            If cboPrinter.Items.Count > CInt(_printer(0)) Then
                cboPrinter.SelectedIndex = CInt(_printer(0))
            Else
                cboPrinter.SelectedIndex = 0
            End If
            chkPrintByTestType.CheckState = CInt(_printer(1))
        End Sub

        Private Sub LoadFileSetting()

            If File.Exists(_SettingFile) Then
                _printer = File.ReadAllLines(_SettingFile)
            Else
                ReDim _printer(2)
                _printer(0) = "0"
                'Vị trí máy in
                _printer(1) = "1"
                'In theo từng test xét nghiệm

                File.WriteAllLines(_SettingFile, _printer)
            End If
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Try
                _printer(0) = cboPrinter.SelectedIndex()
                _printer(1) = chkPrintByTestType.CheckState()
                File.WriteAllLines(_SettingFile, _printer)
                MessageBox.Show("Lưu cấu hình thành công !", "Thông báo")
            Catch ex As Exception
                MessageBox.Show(e.ToString, "Thông báo")
            End Try
        End Sub
    End Class
End Namespace