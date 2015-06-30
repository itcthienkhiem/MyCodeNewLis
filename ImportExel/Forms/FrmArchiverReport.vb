Imports System.Text
Imports VietBaIT.Lablink.Model
Imports SubSonic

Public Class FrmArchiverReport

    Private Sub btnPrintReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintReport.Click
        Try
            Dim crpt As New VietBaIT.LABLink.Reports.Reports.crpt_BaoCaoLuu()
            Dim oForm As New VietBaIT.LABLink.Reports.frmPrintPreview("In kết yêu cầu xét nghiệm", crpt, True, True)

            Dim dt As New DataTable
            dt.Columns.Add("TenBN")
            dt.Columns.Add("KetQuaXN")

            Dim sw1 As Stopwatch = Stopwatch.StartNew()

            Dim dtRawResult As DataTable
            dtRawResult = New [Select](LPatientInfo.PatientIdColumn, LPatientInfo.PatientNameColumn, TResultDetail.BarcodeColumn, TResultDetail.TestTypeIdColumn _
                                       , TTestTypeList.TestTypeNameColumn, TResultDetail.ParaNameColumn, TResultDetail.TestResultColumn, TResultDetail.DataSequenceColumn _
                                       ).From(TResultDetail.Schema).LeftOuterJoin(LPatientInfo.PatientIdColumn, TResultDetail.PatientIdColumn).LeftOuterJoin(TTestTypeList.TestTypeIdColumn, TResultDetail.TestTypeIdColumn).Where(TResultDetail.Columns.TestDate).IsBetweenAnd(dtpFromDate.Value.Date, dtpTodate.Value.Date.AddDays(1).AddMilliseconds(-10)).OrderAsc(TResultDetail.PatientIdColumn.QualifiedName, TResultDetail.TestTypeIdColumn.QualifiedName, TResultDetail.Columns.DataSequence).ExecuteDataSet().Tables(0)

            sw1.Stop()
            Debug.WriteLine(String.Format("Time to get raw data: {0} miliseconds", sw1.Elapsed.TotalMilliseconds))

            ''''''Dim htPatients As New Hashtable
            ''''''Dim htTestTypeName As New Hashtable

            ''''''Dim sw2 As Stopwatch = Stopwatch.StartNew()

            ''''''For Each dv As DataRow In dtRawResult.Rows
            ''''''    Dim key As String = dv(TTestTypeList.Columns.TestTypeName)
            ''''''    If Not htTestTypeName.Contains(key) Then htTestTypeName.Add(key, key)
            ''''''    key = dv(LPatientInfo.Columns.PatientId)
            ''''''    If Not htPatients.Contains(key) Then htPatients.Add(key, key)
            ''''''Next

            ''''''sw2.Stop()
            ''''''Debug.WriteLine(String.Format("Time to Get disctint PatientId and TestTypeId hastable: {0} miliseconds", sw2.Elapsed.TotalMilliseconds))

            ''''''Dim sw3 As Stopwatch = Stopwatch.StartNew()
            ''''''For Each patientId As String In htPatients.Values
            ''''''    Dim patientName As String = dtRawResult.Select(String.Format("{0}={1}", LPatientInfo.Columns.PatientId, patientId))(0)(LPatientInfo.Columns.PatientName)
            ''''''    Dim patientResult As New StringBuilder

            ''''''    Dim patientFilter As String = String.Format("{0}={1}", LPatientInfo.Columns.PatientId, patientId)
            ''''''    For Each testTypeName As String In htTestTypeName.Values

            ''''''        Dim testTypeFilter As String = String.Format("{0}='{1}'", TTestTypeList.Columns.TestTypeName, testTypeName)
            ''''''        dtRawResult.DefaultView.RowFilter = String.Format("{0} And {1} ", patientFilter, testTypeFilter)
            ''''''        If dtRawResult.DefaultView.Count > 0 Then
            ''''''            patientResult.AppendLine()
            ''''''            patientResult.Append(String.Format("</p><b>{0}</b>: ", testTypeName.ToUpper()))
            ''''''            'patientResult.Append(String.Format("{0}:", testTypeName.ToUpper()))
            ''''''            For Each view As DataRowView In dtRawResult.DefaultView
            ''''''                patientResult.Append(String.Format("{0}:{1}, ", view(TResultDetail.Columns.ParaName), view(TResultDetail.Columns.TestResult)))
            ''''''            Next
            ''''''            patientResult.Remove(patientResult.Length - 2, 1)
            ''''''        Else
            ''''''            Continue For
            ''''''        End If
            ''''''    Next
            ''''''    dt.Rows.Add(patientName, patientResult.ToString().Trim())
            ''''''Next

            ''''''sw3.Stop()
            ''''''Debug.WriteLine("Time to fill data to report data table: " & sw3.Elapsed.TotalSeconds & " Seconds")

            Dim sw3 As Stopwatch = Stopwatch.StartNew()
            Dim patientResult As New StringBuilder
           

            dtRawResult.Rows.InsertAt(dtRawResult.NewRow(), 0)
            dtRawResult.Rows(0)("Patient_ID") = dtRawResult.Rows(1)("Patient_ID")
            dtRawResult.Rows.Add(dtRawResult.NewRow)
            For i As Integer = 1 To dtRawResult.Rows.Count - 1
                If (dtRawResult.Rows(i)("Patient_ID").ToString() <> dtRawResult.Rows(i - 1)("Patient_ID").ToString()) Then
                    patientResult.Remove(patientResult.Length - 2, 1)
                    dt.Rows.Add(dtRawResult.Rows(i - 1)("Patient_Name"), patientResult.ToString())
                    patientResult = New StringBuilder
                End If
                If (dtRawResult.Rows(i)("TestType_ID").ToString() <> dtRawResult.Rows(i - 1)("TestType_ID").ToString()) Or (dtRawResult.Rows(i)("Patient_ID").ToString() <> dtRawResult.Rows(i - 1)("Patient_ID").ToString()) Then
                    patientResult.Append(String.Format("</p><b>{0}</b>: ", VietBaIT.CommonLibrary.Utility.sDbnull(dtRawResult.Rows(i)("TestType_Name")).ToUpper()))
                End If
                patientResult.Append(String.Format("{0}:{1}, ", VietBaIT.CommonLibrary.Utility.sDbnull(dtRawResult.Rows(i)("Para_Name")), VietBaIT.CommonLibrary.Utility.sDbnull(dtRawResult.Rows(i)("Test_result"))))
            Next

            'For i As Integer = 0 To dtRawResult.Rows.Count - 1
            '    dr = dtRawResult.Rows(i)
            '    If i = 0 Then
            '        currPatientId = dr("Patient_ID")
            '        prevPatientName = dr("Patient_Name")

            '    else If currPatientId <> lastPatientId Then
            '    lastPatientId = currPatientId
            '    'If prevPatientName <> "" Then
            '    dt.Rows.Add(prevPatientName, patientResult.ToString())
            '    patientResult = New StringBuilder()
            '        prevPatientName = 
            '    currTestTeypeId = ""
            '    'lastTestTypeId = ""
            '    'End If
            '    'prevPatientName = dr("Patient_Name")
            '    End If

            '    If currTestTeypeId <> lastTestTypeId Then
            '        lastTestTypeId = currTestTeypeId
            '        patientResult.Append(String.Format("</p><b>{0}</b>: ", dr("TestType_Name").ToUpper()))
            '    Else
            '        patientResult.Append(String.Format("{0}:{1}, ", dr("Para_Name"), dr("Test_result")))
            '    End If

            'Next

            '''''For Each dr As DataRow In dtRawResult.Rows
            '''''    currPatientId = dr("Patient_ID")
            '''''    currTestTeypeId = dr("TestType_ID")

            '''''    If currPatientId <> lastPatientId Then
            '''''        lastPatientId = currPatientId
            '''''        'If prevPatientName <> "" Then
            '''''        dt.Rows.Add(prevPatientName, patientResult.ToString())
            '''''        patientResult = New StringBuilder()
            '''''        prevPatientName = dr("Patient_Name")
            '''''        currTestTeypeId = ""
            '''''        'lastTestTypeId = ""
            '''''        'End If
            '''''        'prevPatientName = dr("Patient_Name")
            '''''    End If

            '''''    If currTestTeypeId <> lastTestTypeId Then
            '''''        lastTestTypeId = currTestTeypeId
            '''''        patientResult.Append(String.Format("</p><b>{0}</b>: ", dr("TestType_Name").ToUpper()))
            '''''    Else
            '''''        patientResult.Append(String.Format("{0}:{1}, ", dr("Para_Name"), dr("Test_result")))
            '''''    End If


            '''''Next
            
            sw3.Stop()
            Debug.WriteLine("Time to fill data to report data table: " & sw3.Elapsed.TotalSeconds & " Seconds")

            dt.AcceptChanges()
            crpt.SetDataSource(dt)
            crpt.DataDefinition.FormulaFields.Item("Formula_1").Text = Chr(34) & Replace("                Bác sĩ điều trị                                                                                         Trưởng phòng xét nghiệm", "#$X$#", Chr(34) & "&Chr(13)&" & Chr(34)) & Chr(34)
            Dim s As String
            If dtpFromDate.Value.Date = dtpTodate.Value.Date Then
                s = "Xét nghiệm ngày " & dtpFromDate.Value.ToString("dd/MM/yyyy")
            Else
                s = String.Format("Xét nghiệm từ ngày {0} đến ngày {1}", dtpFromDate.Value.ToString("dd/MM/yyyy"), dtpTodate.Value.ToString("dd/MM/yyyy"))
            End If
            crpt.SetParameterValue("sFromDateToDate", s)
            crpt.SetParameterValue("ParentBranchName", gv_sParentBranchName)
            crpt.SetParameterValue("BranchName", gv_sBranchName)
            crpt.SetParameterValue("Address", gv_sAddress)
            crpt.SetParameterValue("sPhone", gv_sPhone)
            oForm.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FrmArchiverReport_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then Dispose(True)
    End Sub
End Class