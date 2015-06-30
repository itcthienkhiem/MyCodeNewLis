Imports System.Windows.Forms
Imports System.Drawing
Imports VB6 = Microsoft.VisualBasic.Strings
Imports VietBaIT.Lablink.Model

Public Class frmInputBarcode
#Region "Attribute"
    Public barcodeDigit As Integer = 10
    Public intOrder As String = ""
    Private _cancel As Boolean = True

#End Region



    Private Sub frmInputBarcode_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                BarcodeProcess()
        End Select

    End Sub

    Private Sub BarcodeProcess()

        BarcodeFinalize()
        If BarcodeExist() Then
            'MessageBox.Show("Barcode tồn tại. Mời nhập lại.", "Thông báo")
            Me.Text = "Barcode tồn tại. Mời nhập lại."
            shakeMe()
            txtBarcode.Focus()
            txtBarcode.SelectAll()
            _cancel = True
        Else
            _cancel = False
            Me.Close()
        End If

    End Sub

    Private Function BarcodeExist() As Boolean
        Try
            Dim dt As New DataTable
            dt = New SubSonic.Select().Top("1").From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.Barcode).IsEqualTo(txtBarcode.Text).ExecuteDataSet().Tables(0)

            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function

    Private Sub BarcodeFinalize()
        If txtBarcode.Text.Length() <= 4 Then
            txtBarcode.Text = Vietbait.CommonLibrary.Utility.GetYYMMDD(lablinkhelper.Utilities.GetSysDate) & intOrder & VB6.Right("0000" & txtBarcode.Text, 4)
        End If
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If _cancel Then
            txtBarcode.Text = ""
        End If
    End Sub

    Private Sub shakeMe()
        Dim myLoc As Point, myLocDef As Point
        myLocDef = Me.Location
        myLoc = Me.Location
        For i As Integer = 0 To 50
            For x As Integer = 0 To 4
                Select Case x
                    Case 0
                        myLoc.X = myLocDef.X + 10
                    Case 1
                        myLoc.X = myLocDef.X - 10
                    Case 2
                        myLoc.Y = myLocDef.Y - 10
                    Case 3
                        myLoc.Y = myLocDef.Y + 10
                    Case 4
                        myLoc = myLocDef
                End Select
                Me.Location = myLoc
                Me.Refresh()
            Next
        Next
        Me.Location = myLocDef
        Me.Refresh()
    End Sub
End Class