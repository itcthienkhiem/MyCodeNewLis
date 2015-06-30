Imports System.Data.SqlClient
Imports System.IO
Imports VietBaIT.MultiLanguage

Public Class NHTD_BaoCaoXetNghiemTheoKhoa

    Private Sub NHTD_BaoCaoXetNghiemTheoKhoa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Dim dtRawResult As DataTable = spGetRegTestFromDateToDate(dtmFrom.Value.ToString("dd/MM/yyyy"), dtmTo.Value.ToString("dd/MM/yyyy"))
            'Lấy dữ liệu kết quả

            'Nếu không tìm thấy dòng nào hoặc có lỗi trong quá trình nhận dữ liệu
            If (dtRawResult Is Nothing) AndAlso (dtRawResult.Rows.Count = 0) Then Exit Sub

            'B2: Đảo ngược bảng
            'UpdateStatus("Xử lý kết quả")
            Dim dtResult As DataTable = lablinkhelper.PivotTable.GetInversedDataTable(dtRawResult, "Khoa", "TenXetNghiem_Triso", "Tong", "", False)

            'Nếu Có lỗi trong quá trình nghịch đảo bảng dữ liệu
            If (dtResult Is Nothing) AndAlso (dtResult.Rows.Count = 0) Then Exit Sub
            dtResult.Columns.Add("Tổng")
            dtResult.Columns.Add("TenXetNghiem")

            For Each row As DataRow In dtResult.Rows

                Dim tong As Integer = 0
                For i As Integer = 1 To dtResult.Columns.Count - 2
                    tong += VietBaIT.CommonLibrary.Utility.Int32Dbnull(row(i), 0)
                Next
                row("Tổng") = tong
                row("TenXetNghiem") = dtRawResult.Select("TenXetNghiem_TriSo = '" & row("TenXetNghiem_TriSo").ToString.Replace("'", "''") & "'")(0)("TenXetNghiem")
            Next

            'Todo: Remove all col
            For i As Integer = 2 To grdDetail.RootTable.Columns.Count - 1
                Dim tempcol As Janus.Windows.GridEX.GridEXColumn
                tempcol = grdDetail.RootTable.Columns(2)
                If tempcol.Visible Then grdDetail.RootTable.Columns.Remove(tempcol)
            Next i

            For i As Integer = 1 To dtResult.Columns.Count - 2
                Dim columnName As String = dtResult.Columns(i).ColumnName
                Dim tempcol As New Janus.Windows.GridEX.GridEXColumn(columnName)
                If Not grdDetail.RootTable.Columns.Contains(tempcol) Then grdDetail.RootTable.Columns.Add(tempcol)
            Next i

            grdDetail.RootTable.Columns(grdDetail.RootTable.Columns.Count - 1).CellStyle.BackColor = Color.BurlyWood
            grdDetail.DataSource = dtResult
            grdDetail.MoveFirst()
            grdDetail.ColumnAutoResize = True

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Function spGetRegTestFromDateToDate(ByVal pFromDate As String, ByVal pToDate As String) As DataTable
        Try
            Dim sql As String
            sql = "SELECT P.*, " & vbCrLf _
                & "       ISNULL( " & vbCrLf _
                & "           (SELECT TOP 1 lme.Alias_Name " & vbCrLf _
                & "           FROM   L_Mapping_EMAC lme " & vbCrLf _
                & "           WHERE  lme.ID_KetNoi = P.IDXetNghiem_HIS " & vbCrLf _
                & "                  AND lme.Type_Map = 'LOAIXN_HIS'),'Khác' " & vbCrLf _
                & "       ) AS 'TenXetNghiem' " & vbCrLf _
                & "        " & vbCrLf _
                & "FROM   ( " & vbCrLf _
                & "           SELECT UPPER(hp.Khoa) AS KHOA, " & vbCrLf _
                & "                  hr.TenXetNghiem_TriSo, " & vbCrLf _
                & "                  hr.IDXetNghiem_HIS, " & vbCrLf _
                & "                  COUNT(hr.TenXetNghiem_TriSo) AS 'Tong' " & vbCrLf _
                & "           FROM   tbl_HISLIS_Patients hp " & vbCrLf _
                & "                  LEFT JOIN tbl_HISLIS_REG hr " & vbCrLf _
                & "                       ON  hr.SoPhieuChiDinh = hp.SoPhieuChiDinh  " & vbCrLf _
                & "           WHERE  hr.TenXetNghiem_TriSo IS NOT NULL " & vbCrLf _
                & "                  AND dbo.trunc(CONVERT(DATETIME, hp.NgayNhan, 103)) BETWEEN dbo.trunc(CONVERT(DATETIME, '" & pFromDate & "', 103))  " & vbCrLf _
                & "                      AND dbo.trunc(CONVERT(DATETIME, '" & pToDate & "', 103)) " & vbCrLf _
                & "           GROUP BY " & vbCrLf _
                & "                  hp.Khoa, " & vbCrLf _
                & "                  hr.TenXetNghiem_TriSo, " & vbCrLf _
                & "                  hr.IDXetNghiem_HIS " & vbCrLf _
                & "            " & vbCrLf _
                & "       ) AS P " & vbCrLf _
                & "       ORDER BY " & vbCrLf _
                & "                  P.Khoa, " & vbCrLf _
                & "                  P.TenXetNghiem_TriSo"

            Dim svDa As New SqlDataAdapter(sql, gv_oSqlCnn)
            Dim dtResult As New DataTable("Result")
            svDa.Fill(dtResult)
            Return dtResult
        Catch ex As Exception
            MsgBox("Có lỗi trong quá trình lấy thông tin bệnh nhân", vbOK, "Thông báo lỗi")
            Return Nothing
        End Try
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