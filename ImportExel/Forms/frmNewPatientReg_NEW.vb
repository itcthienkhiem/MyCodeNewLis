Imports System.Windows.Forms
Imports lablinkhelper
Imports VietBaIT.LABLink.LoadEnvironments
Imports SubSonic
Imports VietBaIT.LABLink.Model
Imports VietBaIT.CommonLibrary
Imports Janus.Windows.GridEX

Public Class frmNewPatientReg_NEW

    Public dtDepartment As DataTable = ModBusinessHelper.GetAllDepartment()
    Public dtObjectType As DataTable = ModBusinessHelper.GetAllObjectType()
    Private pv_CurrentYear As Integer = Now.Year
    'Public mv_bCancel As Boolean = True

    Public mv_ParentTable As DataTable

    Public grdList As GridEX
    Public m_iAction As action
    'Public mv_FormType As Integer = 1

    Public mv_DR As DataRow
    Private errDate As Date = lablinkhelper.Utilities.GetSysDate()

    'Public mv_bAdd As Boolean = True

    Private Sub FillSexCombobox()
        cboSex.DataSource = Nothing
        cboSex.Items.Clear()

        Dim dt = New DataTable()
        dt.Columns.Add("ValueItem")
        dt.Columns.Add("DisplayItem")

        Dim dr As DataRow = dt.NewRow()
        'dr(0) = -1
        'dr(1) = ""
        'dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = 1
        dr(1) = "Nam"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = 0
        dr(1) = "Nữ"
        dt.Rows.Add(dr)

        cboSex.DataSource = dt
        cboSex.DisplayMember = "DisplayItem"
        cboSex.ValueMember = "ValueItem"

        cboSex.SelectedIndex = 0
    End Sub

    Dim sFileName = "frmNewPatientReg.txt"

    Private Sub frmNewPatientReg_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try

            'Dim arrStr() As String = {IIf(chkIsBirth.Checked, 1, 0)}

            If System.IO.File.Exists(sFileName) Then
                chkIsBirth.Checked = IIf(System.IO.File.ReadAllLines(sFileName)(0) = "1", True, False)
                chkDOB.Checked = IIf(System.IO.File.ReadAllLines(sFileName)(1) = "1", True, False)
                dtpDOB.Enabled = chkDOB.Checked
            Else
                System.IO.File.WriteAllText(sFileName, IIf(chkIsBirth.Checked, 1, 0))
            End If
            cboHosStatus.SelectedIndex = 0
            FillSexCombobox()

            DataBinding.BindData(cboDepartment, dtDepartment, LDepartment.Columns.Id, LDepartment.Columns.SName)
            Try
                cboDepartment.SelectedIndex = 0
            Catch ex As Exception

            End Try
            DataBinding.BindData(cboObject, dtObjectType, "ID", "sName")
            InitalData()
            Dim cls_Reg As New lablinkhelper.clsRegistry
            Dim Index As Integer = Utility.Int32Dbnull(cls_Reg.GetReg(2, "DVC_COMPANY", "APP_DVC", "PRJBUSSINESS_OBJECTTYPE"), -1)
            If cboObject.Items.Count - 1 >= Index Then cboObject.SelectedIndex = Index
            Dim bCheck As Integer = Utility.Int32Dbnull(cls_Reg.GetReg(2, "DVC_COMPANY", "APP_DVC", "PRJBUSSINESS_CLOSEAFTERINSERT"), -1)
            chkCloseAfterInsert.Checked = bCheck = 1
            'chkDOB.Checked = Utility.Int32Dbnull(cls_Reg.GetReg(2, "DVC_COMPANY", "APP_DVC", "PRJBUSSINESS_DOB"), -1) = 1
            'chkDOB_CheckedChanged(sender, e)
            txtYearOfBirth.Value = pv_CurrentYear
            Select Case m_iAction
                Case action.Insert
                    txtPID.Text = Utility.GetYYYYMMDDHHMMSS(lablinkhelper.Utilities.GetSysDate())
                Case action.Update
                    LoadData()
            End Select

            txtPName.Focus()
            txtPName.SelectAll()
            If SysPara.BarcodeType = "JCLV" Then
                lblBHYT.Text = "Mã nhân viên"
                lblKhoa.Text = "Đơn vị"
            Else
                lblBHYT.Text = "Mã bệnh nhân"
            End If
        Catch ex As Exception
            Utility.ShowMsg(String.Format("Lỗi trong quá trình khởi tạo {0}", ex.ToString))
            Me.Dispose()
        End Try
    End Sub

    Private Sub InitalData()
        Dim sqlQuery As SqlQuery
        sqlQuery = New SubSonic.Select("ID,convert(varchar(20),ID)as sID").From(TblLot.Schema.Name).OrderAsc(TblLot.Columns.Id)
        Dim dt As DataTable = sqlQuery.ExecuteDataSet().Tables(0)
        DataBinding.BindDataCombox(cboLot, dt, "ID", "sID", "---Chọn số lô---")
    End Sub

    Private Sub LoadData()
        Try
            If Not mv_DR Is Nothing Then
                txtPID.Enabled = (m_iAction = 1)
                txtPID.Text = Utility.sDbnull(mv_DR("PID"))
                txtPatient_ID.Text = Utility.sDbnull(mv_DR("Patient_ID"))

                txtPName.Text = Utility.sDbnull(mv_DR("Patient_Name"))
                'txtAge.Text = sDBnull (mv_DR ("age"))
                Dim objPatient As LPatientInfo = LPatientInfo.FetchByID(Utility.Int32Dbnull(txtPatient_ID.Text, -1))
                If Not (objPatient Is Nothing) Then
                    If Not String.IsNullOrEmpty(Utility.sDbnull(objPatient.YearBirth, "")) Then

                        chkIsBirth.Checked = True
                        If objPatient.Dob.HasValue Then
                            chkDOB.Checked = True
                            dtpDOB.Value = Utility.sDbnull(mv_DR(LPatientInfo.Columns.Dob), errDate)
                        Else
                            chkDOB.Checked = False
                        End If

                        txtYearOfBirth.Value = mv_DR(LPatientInfo.Columns.YearBirth)
                    Else
                        chkIsBirth.Checked = False
                    End If

                End If

                txtInsuranceNum.Text = Utility.sDbnull(mv_DR("Insurance_Num"))
                txtAddress.Text = Utility.sDbnull(mv_DR("address"))
                txtDiagnostic.Text = Utility.sDbnull(mv_DR("Diagnostic"))
                txtCMT.Text = Utility.sDbnull(mv_DR("IdentifyNum"))
                'cboHosStatus.SelectedIndex = sDBnull(mv_DR("HosStatus"))

                txtRoom.Text = Utility.sDbnull(mv_DR("Room"))
                txtBed.Text = Utility.sDbnull(mv_DR("Bed"))
                dtmDate.Text = Utility.sDbnull(mv_DR(LPatientInfo.Columns.Dateupdate))

                cboSex.SelectedValue = Utility.Int32Dbnull(mv_DR("Sex"), -1)
                cboDepartment.SelectedValue = Utility.Int32Dbnull(mv_DR("DepartmentID"), -1)
                cboObject.SelectedValue = Utility.Int32Dbnull(mv_DR("ObjectType"), -1)
                cboHosStatus.SelectedIndex = Utility.Int32Dbnull(mv_DR(LPatientInfo.Columns.HosStatus), 0)
                cboLot.SelectedIndex = Utility.GetSelectedIndex(cboLot, Utility.sDbnull(mv_DR("LotID"), "-1"))
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi trong quá trình nhận thông tin bệnh nhân", "Thông báo")
        End Try
    End Sub

    Private Function FindIndexComboBox(ByVal dt As DataTable, ByVal sValue As String, ByVal sFIeldName As String, Optional ByVal result As Integer = -1) As Integer
        Try
            For i As Integer = 0 To dt.Rows.Count
                If dt.Rows(i)(sFIeldName).ToString = sValue Then
                    Return i
                End If
            Next
            Return result
        Catch ex As Exception
            Return result
        End Try
    End Function

    Private Function VLookUp(ByVal dt As DataTable, ByVal sValue As String, ByVal sFIeldName As String, _
                              ByVal sFieldValue As String, Optional ByVal errValue As Integer = -1) As Integer
        Try
            Dim result As Integer = errValue
            For Each dr As DataRow In dt.Rows
                If dr(sFIeldName).ToString = sValue Then
                    result = dr(sFieldValue)
                End If
            Next
            Return result
        Catch ex As Exception
            Return errValue
        End Try
    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If Not bCheckData() Then Return
            Dim cls_Reg As New clsRegistry
            cls_Reg.SaveReg(2, "DVC_COMPANY", "APP_DVC", "PRJBUSSINESS_OBJECTTYPE", cboObject.SelectedIndex)
            cls_Reg.SaveReg(2, "DVC_COMPANY", "APP_DVC", "PRJBUSSINESS_CLOSEAFTERINSERT", _
                             IIf(chkCloseAfterInsert.Checked, 1, 0))
            cls_Reg.SaveReg(2, "DVC_COMPANY", "APP_DVC", "PRJBUSSINESS_DOB", IIf(chkDOB.Checked, 1, 0))
            Select Case m_iAction
                Case action.Insert 'Add Patient
                    If AddPatient() Then
                        'mv_bCancel = False
                        InsertIntoDataTableAndDataGrid()
                        If chkCloseAfterInsert.Checked Then
                            Close()
                        Else
                            txtPID.Text = Utility.GetYYYYMMDDHHMMSS(lablinkhelper.Utilities.GetSysDate())
                            dtmDate.Value = Date.Now.ToString
                            txtPName.Clear()
                            txtBed.Clear()
                            txtRoom.Clear()
                            txtInsuranceNum.Clear()
                            txtCMT.Clear()
                            txtDiagnostic.Clear()
                            txtAddress.Clear()
                            txtPName.Focus()
                        End If
                    End If
                Case action.Update 'Edit patient info
                    If EditPatientInfo() Then
                        'mv_bCancel = False
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Function bCheckData() As Boolean
        If txtPID.Text.Trim = "" Then
            MessageBox.Show("Bạn phải nhập Barcode", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPID.Focus()
            Return False
        End If
        If txtPName.Text.Trim = "" Then
            MessageBox.Show("Bạn phải nhập tên bệnh nhân", "Thông báo", MessageBoxButtons.OK, _
                             MessageBoxIcon.Warning)
            txtPName.Focus()
            Return False
        End If
        If cboObject.Items.Count <= 0 Then
            Utility.ShowMsg("Bạn phải nhập danh mục loại đối tượng dịch vụ")
            Return False
        End If
        If chkIsBirth.Checked Then
            If chkDOB.Checked Then
                If Utility.CompareToDate(dtpDOB.Text, lablinkhelper.Utilities.GetSysDate.Date.ToString) Then
                    Utility.ShowMsg("Ngày sinh không được lớn hơn ngày hiện tại,Yêu cầu nhập lại", "Thông báo", MessageBoxIcon.Warning)
                    dtpDOB.Focus()
                    Return False
                End If
                'Return False
            Else
                If Utility.Int32Dbnull(txtYearOfBirth.Text, -1) > lablinkhelper.Utilities.GetSysDate().Year Then
                    Utility.ShowMsg("Năm sinh của bệnh nhân không lớn hơn năm hiện tại", "Thông báo", MessageBoxIcon.Warning)
                    txtYearOfBirth.Focus()
                    Return False
                End If
                If (Utility.Int32Dbnull(txtYearOfBirth.Text, -1)) <= 0 Then
                    Utility.ShowMsg("Năm sinh của bệnh nhân không thể lưu số âm hoặc =0", "Thông báo", MessageBoxIcon.Warning)
                    txtYearOfBirth.Focus()
                    Return False
                End If
                If Utility.Int32Dbnull(txtAge.Text, -1) < 0 Then
                    Utility.ShowMsg("Tuổi của bệnh nhân không thể lưu số âm", "Thông báo", MessageBoxIcon.Warning)
                    txtAge.Focus()
                    Return False
                End If

            End If
        End If


        'If txtAge.Text.Trim <> "" Then
        '    If Not IsNumeric(txtAge.Text) Then
        '        MessageBox.Show("Tuổi bệnh nhân phải là chữ số", "Thông báo", MessageBoxButtons.OK,
        '                        MessageBoxIcon.Information)
        '        txtAge.Focus()
        '        Return False
        '    End If
        '    If txtYear.Text.Trim = "" Then
        '        MessageBox.Show("Bạn phải nhập  năm sinh của bệnh nhân", "Thông báo", MessageBoxButtons.OK,
        '                        MessageBoxIcon.Information)
        '        txtYear.Focus()
        '        Return False
        '    End If
        '    If Not IsNumeric(txtYear.Text) Then
        '        MessageBox.Show("Năm sinh của bệnh nhân phải là chữ số", "Thông báo", MessageBoxButtons.OK,
        '                        MessageBoxIcon.Information)
        '        txtYear.Focus()
        '        Return False
        '    End If
        'End If
        Return True
    End Function

    Private Function checkDOB() As Boolean
        Try

            If txtAge.Value < 0 Or txtYearOfBirth.Value < errDate.Year Then
                Return False
            End If

            Return True
            'If cint(arrDOB(2)) Then
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function AddPatient() As Boolean
        Try
            Dim obj As New LPatientInfo
            obj.Pid = txtPID.Text
            obj.PatientName = txtPName.Text
            obj.Address = txtAddress.Text
            If chkIsBirth.Checked Then
                If chkDOB.Checked Then
                    obj.Dob = dtpDOB.Value
                    obj.YearBirth = dtpDOB.Value.Year
                Else
                    'obj.Dob = Nothing
                    obj.YearBirth = CInt(txtYearOfBirth.Text)
                End If
            End If

            'obj.Age = pv_CurrentYear - obj.YearBirth + 1
            obj.HosStatus = cboHosStatus.SelectedIndex
            obj.LotID = Utility.Int32Dbnull(cboLot.SelectedValue, -1)
            obj.Sex = CInt(cboSex.SelectedValue)
            obj.Diagnostic = txtDiagnostic.Text
            obj.IdentifyNum = txtCMT.Text
            obj.InsuranceNum = txtInsuranceNum.Text
            obj.DepartmentID = cboDepartment.SelectedValue
            obj.Room = txtRoom.Text
            obj.Bed = txtBed.Text
            obj.Dateupdate = New DateTime(dtmDate.Value.Year, dtmDate.Value.Month, dtmDate.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            obj.ObjectType = CInt(cboObject.SelectedValue)
            obj.IsNew = True
            obj.Save()
            'SPs.PatientInfoInsert(txtPID.Text, txtPName.Text, txtAddress.Text, txtAge.Text, txtYear.Text, _
            '                       CInt(cboSex.SelectedValue), txtDiagnostic.Text, txtCMT.Text, _
            '                       txtInsuranceNum.Text, cboDepartment.SelectedValue, txtRoom.Text, txtBed.Text, _
            '                       dtmDate.Value, cboObject.SelectedValue, SqlDbType.Int).Execute()
            Return True
        Catch ex As Exception
            MessageBox.Show("Có lỗi trong quá trình lưu kết quả", "Thông báo")
            Return False
        End Try
    End Function

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmNewPatientReg_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.PerformClick()
        End If
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Sub InsertIntoDataTableAndDataGrid()
        Try
            'If mv_FormType = 1 Then

            Dim dr As DataRow
            dr = mv_ParentTable.NewRow
            If mv_ParentTable.Columns.Contains("Barcode") Then
                dr("Barcode") = ""
            End If
            dr("Patient_ID") = New [Select](Aggregate.Max(LPatientInfo.Columns.PatientId)).From(LPatientInfo.Schema.Name).ExecuteDataSet().Tables(0)(0)(0)
            PatientInfo2Datarow(dr)
            mv_ParentTable.Rows.InsertAt(dr, 0)
            'mv_ParentTable.AcceptChanges()
            'Dim grdRow As Janus.Windows.GridEX.GridEXRow

            grdList.MoveFirst()

            'Else
            'mv_ParentTable.Rows.Add(mv_DR)
            ''GotoPatient(CStr(m_iID))
            'mv_DR = mv_ParentTable.NewRow

            'End If
        Catch ex As Exception
            MessageBox.Show("Có lỗi trong quá trình thực hiện")
        End Try
    End Sub

    Private Function EditPatientInfo() As Boolean

        Try
            Dim record As Int32
            'Dim DOB As Date
            'Dim canConvertDOB As Boolean = False
            'Try
            '    DOB = Utility.ConvertDate(txtYear.Text)
            '    canConvertDOB = True
            'Catch ex As Exception

            'End Try

            If chkDOB.Checked Then
                record = _
                    New Update(LPatientInfo.Schema.TableName).Set(LPatientInfo.Columns.PatientName).EqualTo(txtPName.Text). _
                        Set(LPatientInfo.Columns.Address).EqualTo(txtAddress.Text). _
                        Set(LPatientInfo.Columns.InsuranceNum).EqualTo(txtInsuranceNum.Text). _
                        Set(LPatientInfo.Columns.Sex).EqualTo(CInt(cboSex.SelectedValue)). _
                        Set(LPatientInfo.Columns.ObjectType).EqualTo(cboObject.SelectedValue). _
                        Set(LPatientInfo.Columns.Diagnostic).EqualTo(txtDiagnostic.Text). _
                        Set(LPatientInfo.Columns.DepartmentID).EqualTo(cboDepartment.SelectedValue). _
                        Set(LPatientInfo.Columns.Room).EqualTo(txtRoom.Text). _
                        Set(LPatientInfo.Columns.Bed).EqualTo(txtBed.Text). _
                        Set(LPatientInfo.Columns.IdentifyNum).EqualTo(txtCMT.Text). _
                        Set(LPatientInfo.Columns.LotID).EqualTo(CInt(cboLot.SelectedValue)). _
                        Set(LPatientInfo.Columns.HosStatus).EqualTo(CInt(cboHosStatus.SelectedIndex)). _
                        Set(LPatientInfo.Columns.Dob).EqualTo(IIf(chkIsBirth.Checked, dtpDOB.Value.Date, DBNull.Value)). _
                        Set(LPatientInfo.Columns.YearBirth).EqualTo(IIf(chkIsBirth.Checked, dtpDOB.Value.Year, DBNull.Value)). _
                Where(LPatientInfo.Columns.PatientId).IsEqualTo(mv_DR(LPatientInfo.Columns.PatientId)).Execute()
            Else
                record = _
                    New Update(LPatientInfo.Schema.TableName).Set(LPatientInfo.Columns.PatientName).EqualTo(txtPName.Text). _
                        Set(LPatientInfo.Columns.Address).EqualTo(txtAddress.Text). _
                        Set(LPatientInfo.Columns.InsuranceNum).EqualTo(txtInsuranceNum.Text). _
                        Set(LPatientInfo.Columns.Sex).EqualTo(CInt(cboSex.SelectedValue)). _
                        Set(LPatientInfo.Columns.ObjectType).EqualTo(cboObject.SelectedValue). _
                        Set(LPatientInfo.Columns.Diagnostic).EqualTo(txtDiagnostic.Text). _
                        Set(LPatientInfo.Columns.DepartmentID).EqualTo(cboDepartment.SelectedValue). _
                        Set(LPatientInfo.Columns.Room).EqualTo(txtRoom.Text). _
                        Set(LPatientInfo.Columns.Bed).EqualTo(txtBed.Text). _
                        Set(LPatientInfo.Columns.IdentifyNum).EqualTo(txtCMT.Text). _
                        Set(LPatientInfo.Columns.LotID).EqualTo(CInt(cboLot.SelectedValue)). _
                        Set(LPatientInfo.Columns.HosStatus).EqualTo(CInt(cboHosStatus.SelectedIndex)). _
                        Set(LPatientInfo.Columns.Dob).EqualTo(DBNull.Value). _
                        Set(LPatientInfo.Columns.YearBirth).EqualTo(IIf(chkIsBirth.Checked, Utility.Int32Dbnull(txtYearOfBirth.Text, 0), DBNull.Value)). _
                        Where(LPatientInfo.Columns.PatientId).IsEqualTo(mv_DR(LPatientInfo.Columns.PatientId)).Execute
            End If
            If Not mv_DR Is Nothing Then
                PatientInfo2Datarow(mv_DR)
                mv_DR.AcceptChanges()
            End If
            'MessageBox.Show("Cập nhật bệnh nhân thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Thông báo")
            Return False
        End Try
    End Function

    Private Sub PatientInfo2Datarow(ByRef dr As DataRow)
        Try
            dr("PID") = txtPID.Text
            dr("Patient_Name") = txtPName.Text

            If chkIsBirth.Checked Then
                dr("Age") = CInt(txtAge.Text)
                dr("Year_Birth") = CInt(txtYearOfBirth.Text)
                If chkDOB.Checked Then
                    dr(LPatientInfo.Columns.Dob) = dtpDOB.Value.Date
                Else
                    dr(LPatientInfo.Columns.Dob) = DBNull.Value
                End If
            Else
                dr("Age") = DBNull.Value
                dr("Year_Birth") = DBNull.Value
            End If
            dr("Sex") = CInt(cboSex.SelectedValue)
            dr("sexName") = cboSex.Text
            dr("ObjectType") = Utility.Int32Dbnull(cboObject.SelectedValue, -1)
            dr("ObjectType_Name") = Utility.sDbnull(cboObject.Text, "")
            dr("Diagnostic") = txtDiagnostic.Text
            dr("IdentifyNum") = txtCMT.Text
            dr("Insurance_Num") = Utility.sDbnull(txtInsuranceNum.Text)
            dr("address") = txtAddress.Text
            dr("Department_Name") = IIf(cboDepartment.SelectedValue = -1, "", cboDepartment.Text)
            dr("DepartmentID") = Utility.sDbnull(cboDepartment.SelectedValue, -1)
            dr("Room") = txtRoom.Text.Trim
            dr("Bed") = txtBed.Text.Trim
            dr("DateUpdate") = dtmDate.Text
            dr("LotID") = Utility.Int32Dbnull(cboLot.SelectedValue, -1)

        Catch ex As Exception
            MessageBox.Show("Có lỗi trong quá trình thực hiện", "Thông báo")
        End Try
    End Sub


    Private Sub dtpDOB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDOB.ValueChanged
        Try

            RemoveHandler txtAge.ValueChanged, AddressOf txtAge_ValueChanged
            txtYearOfBirth.Value = dtpDOB.Value.Year
            AddHandler txtAge.ValueChanged, AddressOf txtAge_ValueChanged

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtYearOfBirth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYearOfBirth.ValueChanged
        Try
            RemoveHandler txtAge.TextChanged, AddressOf txtAge_ValueChanged
            ' SysPara.BarcodeType="JCLV"
            txtAge.Value = pv_CurrentYear - txtYearOfBirth.Value
            AddHandler txtAge.TextChanged, AddressOf txtAge_ValueChanged
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAge_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAge.ValueChanged
        Try
            RemoveHandler txtYearOfBirth.TextChanged, AddressOf txtYearOfBirth_ValueChanged
            txtYearOfBirth.Value = pv_CurrentYear - txtAge.Value
            AddHandler txtYearOfBirth.TextChanged, AddressOf txtYearOfBirth_ValueChanged
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkDOB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDOB.CheckedChanged
        dtpDOB.Enabled = chkDOB.Checked
        txtYearOfBirth.Enabled = Not chkDOB.Checked
        txtAge.Enabled = Not chkDOB.Checked
        If chkDOB.Checked Then
            dtpDOB.Focus()
        Else
            txtYearOfBirth.Focus()

        End If
        Try
            If m_iAction = action.Insert Then
                Dim arrStr() As String = {IIf(chkIsBirth.Checked, 1, 0), IIf(chkDOB.Checked, 1, 0)}

                If System.IO.File.Exists(sFileName) Then
                    System.IO.File.WriteAllLines(sFileName, arrStr)
                Else
                    System.IO.File.WriteAllText(sFileName, IIf(chkIsBirth.Checked, 1, 0))
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub UiGroupBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiGroupBox2.Click

    End Sub

    Private Sub chkIsBirth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsBirth.CheckedChanged
        pBirth.Enabled = chkIsBirth.Checked
        Try
            If m_iAction = action.Insert Then
                Dim arrStr() As String = {IIf(chkIsBirth.Checked, 1, 0), IIf(chkDOB.Checked, 1, 0)}

                If IO.File.Exists(sFileName) Then
                    IO.File.WriteAllLines(sFileName, arrStr)
                Else
                    IO.File.WriteAllText(sFileName, IIf(chkIsBirth.Checked, 1, 0))
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub txtAge_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAge.KeyPress
        Utility.OnlyDigit(e)
    End Sub

    Private Sub txtYearOfBirth_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYearOfBirth.KeyPress
        Utility.OnlyDigit(e)
    End Sub
End Class