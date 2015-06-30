Imports LIS.DAL
Imports VNS.Libs
Imports SubSonic
Imports VietBaIT.Lablink.Model
Imports VietBaIT.CommonLibrary
Imports System.Drawing.Imaging
Imports Microsoft.VisualBasic

Public Class frm_JCLV_InPhieuYeuCau_XETNGHIEM
    Private DTPrint As DataTable
    Public p_Patient_ID As Int32


    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub

    Private Sub frm_JCLV_InPhieuYeuCau_XETNGHIEM_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                cmdExit.PerformClick()
            Case Keys.F4, Keys.Enter
                cmdPrintPhieu.PerformClick()
        End Select
    End Sub

    Private Sub cmdPrintPhieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPhieu.Click
        Dim PHIEUTHU As Int32
        Dim sqlQuery As SqlQuery
        sqlQuery = New [Select](TblSystemParameter.Columns.SValue).From(TblSystemParameter.Schema).Where(TblSystemParameter.Columns.SName).IsEqualTo("PHIEUTHU")
        PHIEUTHU = Utility.Int32Dbnull(sqlQuery.ExecuteScalar(), 0)
        If PHIEUTHU = 1 Then
            PrintdataNew()
        Else
            Printdata()
        End If
    End Sub
    Private Sub ProcessData(ByRef DT As DataTable)

        If Not DT.Columns.Contains("BarcodeImg") Then
            DT.Columns.Add("BarcodeImg", GetType(Byte()))
        End If
        If Not DT.Columns.Contains("sSex") Then
            DT.Columns.Add("sSex", GetType(String))
        End If
        'If DT.Rows.Count > 0 Then
        '    Barcode1.Data = CType(sDBnull(DT.Rows(0)("Barcode"), "0000000000"), String)
        '    Barcode1.Image().Save(Application.StartupPath & "\Temp.jpg", ImageFormat.Jpeg)
        '    DT.Rows(0)("BarcodeImg") = bytGetImage(Application.StartupPath & "\Temp.jpg")
        'End If

        For Each dr As DataRow In DT.Rows
            Try
                Dim sBarcode As String = CType(sDBnull(dr("Barcode"), "0000000000"), String)
                'Barcode1.Image().Save(Application.StartupPath & "\Temp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                dr("BarcodeImg") = Utility.GenerateBarCode(Vietbait.BarCode.BarcodeInfo.CreateNewBarcode(sBarcode))
                ' bytGetImage(Application.StartupPath & "\Temp.jpg")
                dr("TESTTYPE_NAME") = dr("TESTTYPE_NAME").ToString.ToUpper
            Catch ex As Exception

            End Try

            dr("sSex") = IIf(dr("sex"), "Nam", "Nữ")

            'If dr("sex") Then
            '    dr("Normal_Level") = dr("Normal_Level")
            '    dr("sSex") = "Nam"
            'Else
            '    dr("Normal_Level") = dr("Normal_LevelW")
            '    dr("sSex") = "Nữ"
            'End If
            'If All Then
            '    dr("title") = "PHIẾU TRẢ LỜI KẾT QUẢ XÉT NGHIỆM"
            'Else
            '    dr("title") = "PHIẾU TRẢ LỜI KẾT QUẢ XÉT NGHIỆM " & cboTestType.Text.ToUpper
            'End If
            'dr("Testdate") = sGetDay(dtpTestDate.Value)
        Next
        DT.AcceptChanges()
        ' ProcessNormalResult(DT)
    End Sub
    Private Sub Printdata()
        Try
            Dim crpt As New frm_JCLV_InPhieuYeuCau_XETNGHIEM()
            Dim oForm As New frmPrintPreview("In kết yêu cầu xét nghiệm", crpt, True, True)
            'Utility.ResetProgressBarJanus(ProgressBar1, grdPatients.GetCheckedRows.Length, False)
            'DTPrint.DefaultView.Sort = "Barcode ASC"
            Dim sTestInfo As String = grdTestInfo.GetCheckedRows.Aggregate("-1", Function(current, GridRow) current + ("," + Utility.sDbnull(GridRow.Cells("Test_ID").Value, "-1")))
            DTPrint = SPs.JclvPhieuYeucauXetnghiem(p_Patient_ID, sTestInfo).GetDataSet().Tables(0)
            If DTPrint.Rows.Count <= 0 Then
                Utility.ShowMsg("Không tìm thấy thông tin ", "Thông báo")
                grdTestInfo.Focus()
                Return
            End If
            ''''''If Not DTPrint.Columns.Contains("BarcodeImg") Then
            ''''''    DTPrint.Columns.Add("BarcodeImg", GetType(Byte()))
            ''''''End If

            '''''''Dim arrImage As Byte() = GenerateBarCode(Barcode1)

            ''''''Dim dataBarcode As Byte() = Utility.GenerateBarCode(Barcode)
            ''''''For Each dr As DataRow In DTPrint.Rows
            ''''''    dr("BarcodeImg") = dataBarcode
            ''''''    'Barcode2.Data = dr("Barcode")
            ''''''Next
            ''''''DTPrint.AcceptChanges()

            ''''''If DTPrint.Columns.Contains("Normal_Level") Then ProcessData(DTPrint)

            ProcessData(DTPrint)

            crpt.SetDataSource(DTPrint)
            'End If
            Dim ShowSubReport, ShowMainReport As Integer
            ShowSubReport = 0
            ShowMainReport = 1
            'End If ShowTitile
            crpt.DataDefinition.FormulaFields.Item("Formula_1").Text = Chr(34) & Replace("                Bác sĩ điều trị                                                                                         Trưởng phòng xét nghiệm", "#$X$#", Chr(34) & "&Chr(13)&" & Chr(34)) & Chr(34)
            crpt.SetParameterValue("ShowSubReport", ShowSubReport)
            crpt.SetParameterValue("ShowMainReport", ShowMainReport)
            crpt.SetParameterValue("ParentBranchName", gv_sParentBranchName)
            crpt.SetParameterValue("DMY", sGetCurrentDay)
            crpt.SetParameterValue("BranchName", gv_sBranchName)
            crpt.SetParameterValue("Address", gv_sAddress)
            crpt.SetParameterValue("sPhone", gv_sPhone)

            Try
                crpt.SetParameterValue("ShowTitile", gv_showTitleReport)
            Catch ex As Exception
            End Try

            crpt.SetParameterValue("sCurrentDate", Utility.GetFormatDateTime(DateTime.Now, "dd/MM/yyyy"))
            oForm.crptViewer.ReportSource = crpt

            oForm.ShowDialog()

            'Dim cls_Reg As New lablinkhelper.clsRegistry
            'cls_Reg.SaveReg(2, "DVC_COMPANY", "APP_DVC", "PRJBUSSINESS_PRINTTOPAGE", _
            '                 IIf(chkPrintDirecttoPage.Checked, 1, 0))
            DefaultNow(Me)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PrintdataNew()
        Dim crpt As New Vietbait.Lablink.Reports.Reports.crpt_PHIEUTHU()

        Dim oForm As New VietBaIT.LABLink.Reports.frmPrintPreview("In PHIẾU THU", crpt, True, True)

        Dim sTestInfo As String = "-1"
        For Each GridRow As Janus.Windows.GridEX.GridEXRow In grdTestInfo.GetCheckedRows
            sTestInfo += "," + Utility.sDbnull(GridRow.Cells("Test_ID").Value, "-1")
        Next
        DTPrint = SPs.GetDataPHIEUTHU(p_Patient_ID, sTestInfo).GetDataSet().Tables(0)
        If DTPrint.Rows.Count <= 0 Then
            Utility.ShowMsg("Không tìm thấy thông tin ", "Thông báo")
            grdTestInfo.Focus()
            Return
        End If
        Dim itongtien As Int32
        Dim sMoney As New VietBaIT.CommonLibrary.MoneyByLetter()
        itongtien = Utility.Int32Dbnull(DTPrint.Compute("SUM(Price)", "1=1"))
        Utility.UpdateLogotoDatatable(DTPrint)
        DTPrint.AcceptChanges()
        crpt.SetDataSource(DTPrint)
        crpt.DataDefinition.FormulaFields.Item("Formula_1").Text = Chr(34) & _
                                                                    Replace( _
                                                                             "                Người thực hiện                                                                                         Trưởng phòng xét nghiệm", _
                                                                             "#$X$#", _
                                                                             Chr(34) & "&Chr(13)&" & Chr(34)) & _
                                                                    Chr(34)
        crpt.SetParameterValue("ParentBranchName", gv_sParentBranchName)
        crpt.SetParameterValue("BranchName", gv_sBranchName)
        crpt.SetParameterValue("Address", gv_sAddress)
        crpt.SetParameterValue("sPhone", gv_sPhone)
        crpt.SetParameterValue("sCurrentDate", "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString())
        crpt.SetParameterValue("BangChu", sMoney.sMoneyToLetter(itongtien.ToString()))
        oForm.crptViewer.ReportSource = crpt
        oForm.ShowDialog()

    End Sub
    Public Function Number2Text(ByVal sNumber As Int32) As String
        Dim mLen As Long, i As Long
        Dim mDigit As Long, mTemp As String
        Dim mNumText() As String

        mNumText = Split("không;một;hai;ba;bốn;năm;sáu;bảy;t ám;chín", ";")
        mLen = Len(sNumber)
        For i = 1 To mLen
            mDigit = Mid(sNumber, i, 1)
            mTemp = mTemp & " " & mNumText(mDigit)
            If (mLen = i) Then Exit For
            Select Case (mLen - i) Mod 9
                Case 0
                    mTemp = mTemp & " tỷ"
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                Case 6
                    mTemp = mTemp & " triệu"
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                Case 3
                    mTemp = mTemp & " nghìn"
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                Case Else
                    Select Case (mLen - i) Mod 3
                        Case 2
                            mTemp = mTemp & " trăm"
                        Case 1
                            mTemp = mTemp & " mươi"
                    End Select
            End Select
        Next
        'Loại bỏ trường hợp x00
        mTemp = Replace(mTemp, "không mươi không", "")
        'Loại bỏ trường hợp 00x
        mTemp = Replace(mTemp, "không mươi ", "linh ")
        'Loại bỏ trường hợp x0, x>=2
        mTemp = Replace(mTemp, "mươi không", "mươi")
        'Fix trường hợp 10
        mTemp = Replace(mTemp, "một mươi", "mười")
        'Fix trường hợp x4, x>=2
        mTemp = Replace(mTemp, "mươi bốn", "mươi tư")
        'Fix trường hợp x04 
        mTemp = Replace(mTemp, "linh bốn", "linh tư")
        'Fix trường hợp x5, x>=2
        mTemp = Replace(mTemp, "mươi năm", "mươi nhăm")
        'Fix trường hợp x1, x>=2
        mTemp = Replace(mTemp, "mươi một", "mươi mốt")
        'Fix trường hợp x15
        mTemp = Replace(mTemp, "mười năm", "mười lăm")
        'Bỏ ký tự space
        mTemp = Trim(mTemp)
        'Ucase ký tự đầu tiên
        Return mTemp
    End Function

    Private Sub grdTestInfo_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTestInfo.SelectionChanged
        'Barcode.Data = Utility.sDbnull(grdTestInfo.GetValue("BarCode"), "")
    End Sub

    Private Sub frm_JCLV_InPhieuYeuCau_XETNGHIEM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitalData()
    End Sub

    Private Sub InitalData()
        Dim m_dtDataTestInfo As DataTable
        Dim sqlQuery As SqlQuery
        sqlQuery = New SubSonic.Select("*,(select top 1 T.TestType_Name from T_TEST_TYPE_LIST T where T.TestType_ID=T_Test_Info.TestType_ID )as TestType_Name").From(TTestInfo.Schema).Where(TTestInfo.Columns.PatientId).IsEqualTo(p_Patient_ID)
        m_dtDataTestInfo = sqlQuery.ExecuteDataSet().Tables(0)
        grdTestInfo.DataSource = m_dtDataTestInfo
        grdTestInfo.MoveFirst()

        grdTestInfo.CheckAllRecords()
    End Sub
End Class