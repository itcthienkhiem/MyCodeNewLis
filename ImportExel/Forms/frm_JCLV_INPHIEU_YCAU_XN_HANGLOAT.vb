Imports VietBaIT.Lablink.Model
Imports VietBaIT.CommonLibrary
Imports SubSonic


Public Class frm_JCLV_INPHIEU_YCAU_XN_HANGLOAT

    Public grdPatientList As Janus.Windows.GridEX.GridEX

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frm_JCLV_INPHIEU_YCAU_XN_HANGLOAT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then cmdExit.PerformClick()
        If e.KeyCode = Keys.F4 Then cmdPrintPhieu.PerformClick()
    End Sub
    'hàm thực hiện cho phép in báo cáo hàng loạt thông tin của phiếu
    Private Sub cmdPrintPhieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPhieu.Click
        Dim DTPrint As DataTable
        Dim Patient_ID As Int32
        Dim m_dtPhieuXN As DataTable
        If grdPatientList.GetCheckedRows.Length <= 0 Then
            Utility.ShowMsg("Bạn phải thực hiện chọn bệnh nhân trên lưới rùi, thực hiện in phiếu xét nghiệm", "Thông báo", MessageBoxIcon.Warning)
            grdPatientList.Focus()
            Return
        End If
        m_dtPhieuXN = SPs.JclvPhieuYeucauXetnghiemHangloat(-1).GetDataSet().Tables(0).Clone()
        Utility.ResetProgressBarJanus(ProgressBar1, grdPatientList.GetCheckedRows.Length, True)
        For Each gridEXRow As Janus.Windows.GridEX.GridEXRow In grdPatientList.GetCheckedRows

            Patient_ID = Utility.Int32Dbnull(gridEXRow.Cells("Patient_ID").Value, Int32.MinValue)
            DTPrint = SPs.JclvPhieuYeucauXetnghiemHangloat(Patient_ID).GetDataSet().Tables(0)
            For Each dr As DataRow In DTPrint.Rows
                m_dtPhieuXN.ImportRow(dr)
            Next
            ProgressBar1.Value += 1
            m_dtPhieuXN.AcceptChanges()
        Next
        Utility.ResetProgressBarJanus(ProgressBar1, grdPatientList.GetCheckedRows.Length, False)
        ProcessData_INHANGLOAT(m_dtPhieuXN)
        PrintAllPatient(m_dtPhieuXN)
    End Sub
    Private Sub ProcessData_INHANGLOAT(ByRef DT As DataTable)

        If Not DT.Columns.Contains("BarcodeImg") Then
            DT.Columns.Add("BarcodeImg", GetType(Byte()))
        End If
        If Not DT.Columns.Contains("sSex") Then
            DT.Columns.Add("sSex", GetType(String))
        End If

        For Each dr As DataRow In DT.Rows
            Try
                dr("BarcodeImg") = Utility.GenerateBarCode(VietBaIT.BarCode.BarcodeInfo.CreateNewBarcode(CType(sDBnull(dr("Barcode"), "0000000000"), String)))
                dr("TESTTYPE_NAME") = dr("TESTTYPE_NAME").ToString.ToUpper
                dr("PID") = dr("Barcode").ToString
            Catch ex As Exception

            End Try
        Next
        DT.AcceptChanges()

    End Sub
   
    Private Sub PrintAllPatient(ByVal DTPrint As DataTable)
        Try
            ' Dim DTPrint As New DataTable
            If DTPrint.Rows.Count <= 0 Then
                Utility.ShowMsg("Không có bản ghi tìm thấy", "thông báo")
                Return
            End If
            If (radThongTinBenhNhan.Checked) Then
                For Each dr As DataRow In DTPrint.Rows
                    dr("TESTTYPE_NAME") = String.Empty

                    dr("Para_Name") = String.Empty
                Next

                DTPrint.AcceptChanges()
            End If
            Dim crpt = New JCLV_crpt_PHIEU_YEUCAU_XETNGHIEM_HANGLOAT()
            ' Dim crpt = globalModule.GetCrystalReport(vReportType)

            Dim oForm As New frm_Preview("In phiếu", crpt, False)
            'Utility.ResetProgressBarJanus(ProgressBar1, grdPatients.GetCheckedRows.Length, False)
            'DTPrint.DefaultView.Sort = "Barcode ASC"
            crpt.SetDataSource(DTPrint)
            'End If
            Dim ShowSubReport, ShowMainReport As Integer
            ShowSubReport = 0
            ShowMainReport = 1
            'End If
            crpt.DataDefinition.FormulaFields.Item("Formula_1").Text = Chr(34) & Replace("                Bác sĩ điều trị                                                                                         Trưởng phòng xét nghiệm", "#$X$#", Chr(34) & "&Chr(13)&" & Chr(34)) & Chr(34)
            crpt.SetParameterValue("ShowSubReport", ShowSubReport)
            crpt.SetParameterValue("ShowMainReport", ShowMainReport)

            crpt.SetParameterValue("ParentBranchName", gv_sParentBranchName)
            crpt.SetParameterValue("DMY", sGetCurrentDay)
            crpt.SetParameterValue("BranchName", gv_sBranchName)
            crpt.SetParameterValue("Address", gv_sAddress)
            crpt.SetParameterValue("sPhone", gv_sPhone)
            Try
                crpt.SetParameterValue("ShowTitle", gv_showTitleReport)
            Catch ex As Exception

            End Try
            crpt.SetParameterValue("sCurrentDate", Utility.GetFormatDateTime(DateTime.Now, "dd/MM/yyyy"))
            oForm.crptViewer.ReportSource = crpt

            oForm.ShowDialog()
            DefaultNow(Me)
            'End If
        Catch ex As Exception

        End Try
    End Sub

   Private Sub frm_JCLV_INPHIEU_YCAU_XN_HANGLOAT_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Dispose(True)
            Case Keys.Enter
                cmdPrintPhieu.PerformClick()
        End Select
    End Sub
End Class