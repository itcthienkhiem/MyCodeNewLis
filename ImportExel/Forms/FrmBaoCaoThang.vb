Imports System.IO
Imports Vietbait.MultiLanguage
Imports VietBaIT.Lablink.Model

Public Class FrmBaoCaoThang

    Private Sub FrmBaoCaoThang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtmTo.Value = Now.Date
            dtmFrom.Focus()
            SetLanguage(gv_sLanguageDisplay, Me, "prjBussiness", gv_oSqlCnn)
        Catch ex As Exception
            SetLanguage(gv_sLanguageDisplay, Me, "prjBussiness", gv_oSqlCnn)
        End Try

    End Sub

    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdReport.Click
        'ProgressBar2.Style = ProgressBarStyle.Marquee
        If dtmFrom.Value.Date > dtmTo.Value.Date Then
            ShowMsg("Từ ngày phải nhỏ hơn hoặc bằng đến ngày")
            dtmFrom.Focus()
            Return
        End If

        Try
            grdDetail.ColumnAutoResize = False
            Cursor = Cursors.WaitCursor
            'B1: Lấy dữ liệu
            'UpdateStatus("Lấy kết quả")
            Dim dtRawResult As DataTable = SPs.YhhqBaoCaoXetNghiemTheoThang(dtmFrom.Value, dtmTo.Value).GetDataSet().Tables(0)

            'Lấy dữ liệu kết quả

            'Nếu không tìm thấy dòng nào hoặc có lỗi trong quá trình nhận dữ liệu
            If (dtRawResult Is Nothing) AndAlso (dtRawResult.Rows.Count = 0) Then Exit Sub

            'B2: Đảo ngược bảng
            'UpdateStatus("Xử lý kết quả")
            'Dim dtResult As DataTable = lablinkhelper.PivotTable.GetInversedDataTable(dtRawResult, "Khoa", "TenXetNghiem_Triso", "Tong", "", False)
            Dim dtResult As DataTable = RotateTable(dtRawResult)
            'Nếu Có lỗi trong quá trình nghịch đảo bảng dữ liệu
            If (dtResult Is Nothing) AndAlso (dtResult.Rows.Count = 0) Then Exit Sub
            dtResult.Columns.Add("Host_Status")
            dtResult.Columns.Add("ObjectType")

            For Each row As DataRow In dtResult.Rows
                If row(0).ToString().Contains("Nội Trú") Then row("Host_Status") = "Nội Trú"
                If row(0).ToString().Contains("Ngoại Trú") Then row("Host_Status") = "Ngoại Trú"
                If row(0).ToString().Contains("Bảo Hiểm") Then row("ObjectType") = "Bảo Hiểm"
                If row(0).ToString().Contains("Dịch Vụ") Then row("ObjectType") = "Dịch Vụ"
                If row(0).ToString().Contains("Quân/CS") Then row("ObjectType") = "Quân/CS"
            Next
            For Each row As DataRow In dtResult.Rows
                If VietBaIT.CommonLibrary.Utility.sDbnull(row("Host_Status").ToString(), "") = "" Then row("Host_Status") = "Tổng"
                If VietBaIT.CommonLibrary.Utility.sDbnull(row("ObjectType").ToString(), "") = "" Then row("ObjectType") = "Tổng"
            Next

            grdDetail.DataSource = dtResult
            grdDetail.MoveFirst()
            grdDetail.ColumnAutoResize = True
           
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Public Function RotateTable(ByVal dt As DataTable) As DataTable
        Dim table As New DataTable()
        table.Columns.Add("XXX")
        For i As Integer = 0 To dt.Rows.Count - 1
            table.Columns.Add(dt(i)(0).ToString())
        Next
        Dim r As DataRow = Nothing
        For k As Integer = 0 To dt.Columns.Count - 1
            r = table.NewRow()
            r(0) = dt.Columns(k).ToString()
            For j As Integer = 1 To dt.Rows.Count
                r(j) = dt.Rows(j - 1)(k)
            Next
            If k > 0 Then table.Rows.Add(r)
        Next

        Return table
    End Function

    Private Sub CmdCloseClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnExcel.Click
        Dim sw As Stream
        Try
            Dim sd As SaveFileDialog = New SaveFileDialog()
            sd.Filter = "Excel File (*.xls)|*.xls"
            If sd.ShowDialog() = DialogResult.OK Then
                sw = New FileStream(sd.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                grdDetailExporter.Export(sw)
            End If
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình xuất dữ liệu", MsgBoxStyle.OkOnly, "Thông Báo")
        Finally
            If Not (sw Is Nothing) Then
                sw.Flush()
                sw.Close()
                sw.Dispose()
            End If
        End Try
    End Sub
End Class