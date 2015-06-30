Imports VietBaIT.MultiLanguage
Public Class frm_Preview
    Dim RptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Private MustCreate As Boolean
    Public dsXML As New DataSet
    Public RType As String
    Public OE As Boolean
    Public bSetMargin As Boolean = False
    Public TopMargin, LeftMargin, BottomMargin, RightMargin As Integer
    Public ORow, ERow As DataRow
    Public margins As CrystalDecisions.Shared.PageMargins
    Public bCanhLe As Boolean = False
    Public mv_sNgayQT As String = String.Empty
    'bien nay dung de hien thi thong tin trinh ky
    'XuanDT them vao
    Dim mv_oNguoiKy As cls_SignInfor
    Dim mv_oRptText As CrystalDecisions.CrystalReports.Engine.TextObject
    Dim mv_oRptFieldObj As CrystalDecisions.CrystalReports.Engine.FieldObject
    Dim mv_oRptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim mv_oViewDoc As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Dim mv_oRptPara As CrystalDecisions.Shared.ParameterFields
    Dim mv_bNgayQToan As Boolean = True
    Dim mv_bSetContent As Boolean = True
    Dim mv_bAdded As Boolean = False
    Private Sub frm_Preview_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.P OrElse (e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.P) Then
            crptViewer.PrintReport()
            Return
        End If
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.S Then
            cmdExcel.PerformClick()
            Return
        End If
    End Sub

    Private Sub frm_Preview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            addTrinhKy_OnFormLoad()
            SetLanguage(globalModule.gv_sLanguageDisplay, Me, "prjBussiness", globalModule.gv_oSqlCnn)
        Catch ex As Exception
            SetLanguage(globalModule.gv_sLanguageDisplay, Me, "prjBussiness", globalModule.gv_oSqlCnn)
        End Try
    End Sub
    Public Sub Hide_Control()
        ' cmdTrinhKy.Visible = 
    End Sub
    Private Sub cmdTrinhKy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTrinhKy.Click
        'XuanDT Them ham nay vao
        addTrinhKy_OnButtonClick()
        addTrinhKy_OnFormLoad()
    End Sub

    Sub addTrinhKy_OnFormLoad()
        'Ham nay XuanDT them vao
        Try
            'doan gan cac bien: doan nay co the phai thay doi ten bien cho phu hop
            mv_oRptDoc = RptDoc
            mv_oViewDoc = Me.crptViewer
            'ket thuc doan gan bien
            mv_oRptFieldObj = mv_oRptDoc.ReportDefinition.ReportObjects.Item("Field150181")
            mv_oNguoiKy = New cls_SignInfor(mv_oRptDoc.ToString, "")
            'chkPrint_CheckedChanged(chkPrint, New System.EventArgs)
            If mv_oNguoiKy._TonTai Then
                mv_oNguoiKy.setValueToRPT(mv_oRptFieldObj)
                If mv_bSetContent Then
                    mv_oRptDoc.DataDefinition.FormulaFields.Item("Formula_1").Text = Chr(34) & Replace(mv_oNguoiKy.mv_NOI_DUNG, "#$X$#", Chr(34) & "&Chr(13)&" & Chr(34)) & Chr(34)
                Else
                    mv_oRptDoc.DataDefinition.FormulaFields.Item("Formula_1").Text = ""
                End If
                mv_oViewDoc.ReportSource = RptDoc
            Else
                mv_oNguoiKy = New cls_SignInfor(mv_oRptFieldObj, "", RptDoc.ToString, mv_oRptDoc.DataDefinition.FormulaFields.Item("Formula_1").Text)
            End If
        Catch ex As Exception
            mv_oRptText = Nothing
            'an nut tuy chon di
            Me.cmdTrinhKy.Visible = False
        End Try
    End Sub
    Private Sub ms_SetPositionForTextObj(ByVal pv_sName As String)
        Try
            Dim sv_oRptText As CrystalDecisions.CrystalReports.Engine.TextObject
            sv_oRptText = mv_oRptDoc.ReportDefinition.ReportObjects.Item(pv_sName)
            sv_oRptText.Top = mv_oRptFieldObj.Top + mv_oRptFieldObj.Height + 5
        Catch ex As Exception

        End Try
    End Sub
    Sub addTrinhKy_OnButtonClick()
        If mv_oRptFieldObj Is Nothing Then Exit Sub
        Try
            'Hien form de thay doi tuy chon ky

            Dim sv_fTuyChonKy As New frm_SignInfor()

            'sv_fTuyChonKy.ShowDialog()
            sv_fTuyChonKy.txtBaoCao.Text = Me.mv_oNguoiKy.mv_TEN_BIEUBC
            '   sv_fTuyChonKy.txtCoChu.Text = Me.mv_oNguoiKy.mv_CO_CHU.ToString

            ' sv_fTuyChonKy.txtKieuFont.Text = Me.mv_oNguoiKy.mv_KIEU_CHU
            ' #$X$# cua XuanDT, khong duoc doi
            sv_fTuyChonKy.txtNoiDungKy.Text = Me.mv_oNguoiKy.mv_NOI_DUNG.Replace("#$X$#", vbCrLf)
            'sv_fTuyChonKy.txtTenFont.Text = Me.mv_oNguoiKy.mv_FONT_CHU
            sv_fTuyChonKy.mv_sFontName = Me.mv_oNguoiKy.mv_FONT_CHU
            sv_fTuyChonKy.mv_sFontSize = Me.mv_oNguoiKy.mv_CO_CHU.ToString
            sv_fTuyChonKy.mv_sFontStyle = Me.mv_oNguoiKy.mv_KIEU_CHU
            sv_fTuyChonKy.ShowDialog()
            If sv_fTuyChonKy.mv_bChapNhan Then
                Me.mv_oNguoiKy.mv_TEN_BIEUBC = sv_fTuyChonKy.txtBaoCao.Text.Trim
                Me.mv_oNguoiKy.mv_CO_CHU = CInt(sv_fTuyChonKy.cboFontSize.SelectedItem.ToString)
                'Me.mv_oNguoiKy.mv_CHIEU_DAI = Val(sv_fTuyChonKy.txtDai.Text.Trim)
                Try
                    Me.mv_oNguoiKy.mv_KIEU_CHU = sv_fTuyChonKy.cboFontStyle.SelectedValue.ToString
                Catch ex As Exception
                    Me.mv_oNguoiKy.mv_KIEU_CHU = sv_fTuyChonKy.cboFontStyle.Text

                End Try

                If Not mv_bAdded Then
                    Me.mv_oNguoiKy.mv_NOI_DUNG = sv_fTuyChonKy.txtNoiDungKy.Text.Replace(vbCrLf, "#$X$#") & " "
                Else
                    Me.mv_oNguoiKy.mv_NOI_DUNG = sv_fTuyChonKy.txtNoiDungKy.Text.Replace(vbCrLf, "#$X$#").Substring(0, sv_fTuyChonKy.txtNoiDungKy.Text.Length - 1)
                End If
                'Me.mv_oNguoiKy.mv_CHIEU_RONG = Val(sv_fTuyChonKy.txtRong.Text.Trim)
                Me.mv_oNguoiKy.mv_FONT_CHU = sv_fTuyChonKy.cboFontName.SelectedItem.ToString
                'Me.mv_oNguoiKy.mv_TOADO_NGANG = Val(sv_fTuyChonKy.txtViTriX.Text.Trim)
                'Me.mv_oNguoiKy.mv_TOADO_DOC = Val(sv_fTuyChonKy.txtViTriY.Text.Trim)
                If sv_fTuyChonKy.chkGhiLai.Checked = True Then
                    Me.mv_oNguoiKy.updateRPTtoDB()
                End If
                mv_oNguoiKy.setValueToRPT(mv_oRptFieldObj)
                SetParamAgain(mv_oViewDoc.ParameterFieldInfo)
                If mv_bSetContent Then
                    mv_oRptDoc.DataDefinition.FormulaFields.Item("Formula_1").Text = Chr(34) & Replace(mv_oNguoiKy.mv_NOI_DUNG, "#$X$#", Chr(34) & "&Chr(13)&" & Chr(34)) & Chr(34)
                Else
                    mv_oRptDoc.DataDefinition.FormulaFields.Item("Formula_1").Text = ""
                End If
                'mv_oViewDoc.ReportSource = Nothing
                mv_oViewDoc.ReportSource = RptDoc
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CMIS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub SetParamAgain(ByVal p As CrystalDecisions.Shared.ParameterFields)
        Try
            Dim p0 As New CrystalDecisions.Shared.ParameterFields
            For i As Integer = 0 To p.Count - 1
                If p.Item(i).ParameterFieldName.ToUpper = "TXTNGUOIKY1" Then
                    RptDoc.SetParameterValue(p.Item(i).ParameterFieldName, mv_oNguoiKy.mv_NOI_DUNG)
                ElseIf p.Item(i).ParameterFieldName.ToUpper = "TXTNGAYQT" Then
                Else
                    RptDoc.SetParameterValue(p.Item(i).ParameterFieldName, CType(p.Item(i).CurrentValues(0), CrystalDecisions.Shared.ParameterDiscreteValue).Value)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Public Sub New(ByVal FormTitle As String, ByVal RptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument, Optional ByVal pv_bDisplayNgayQT As Boolean = True, Optional ByVal pv_bSetContent As Boolean = True)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        Me.Text = FormTitle
        Me.RptDoc = RptDoc
        '
        mv_bNgayQToan = pv_bDisplayNgayQT
        Me.crptViewer.ReportSource = Me.RptDoc
        cmdTrinhKy.Visible = pv_bSetContent
        mv_bSetContent = pv_bSetContent
        Me.crptViewer.ShowRefreshButton = True
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        cmdTrinhKy.Visible = True
        Me.crptViewer.ShowRefreshButton = True

    End Sub

    Private Sub crptViewer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles crptViewer.KeyDown

    End Sub


    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Dim sFileName As String = ""
        Try
            Dim SaveFileDlg As New SaveFileDialog
            SaveFileDlg.Title = "VietBaJSC-->Save to Excel file"
            SaveFileDlg.Filter = "Excel files|*.XLS"
            If SaveFileDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                sFileName = SaveFileDlg.FileName
                If sFileName.Contains(".XLS") Then
                Else
                    sFileName &= ".XLS"
                End If
                Me.Text = "Đang lưu dữ liệu ra file: " & sFileName
                RptDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, sFileName)
                Me.Text = "In dữ liệu"
                If globalModule.AcceptQuestion("Đã xuất dữ liệu thành công ra file Excel ở đường dẫn: " & sFileName & vbCrLf & "Bạn có muốn mở file Excel ra xem không?") Then
                    System.Diagnostics.Process.Start(sFileName)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class