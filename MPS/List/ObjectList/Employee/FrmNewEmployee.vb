Imports Infragistics.Win.UltraWinGrid
Imports System.IO
Imports Infragistics.Win.FormattedLinkLabel
Imports Infragistics.Win.UltraWinToolbars

Public Class FrmNewEmployee
    Dim clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Dim clsu As New VsoftBMS.Ulti.clsUti
    Private WithEvents b As BLL.BEmployees = BLL.BEmployees.Instance
    Private WithEvents clsP As BLL.BPublic = BLL.BPublic.Instance

    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub

    Private showDAL As Boolean = False
    Private keySelect As String = ""
    Public Overloads Function ShowDialog(ByVal f As Boolean) As String
        showDAL = f
        Me.ShowDialog()
        Return keySelect
    End Function

#Region "FROM"
    Private Sub FrmNewEmployee_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If txtEmployeeID.Enabled = False Then
            txtEmployeeName.Focus()
        Else
            txtEmployeeID.Focus()
        End If
    End Sub

    Private Sub FrmNewEmployee_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.tbManager.Tools("btnSave").SharedProps.Enabled = False Then Exit Sub
        Dim m1 As Model.MLS_Employees = setInfo()
        Dim ask As Boolean = False
        If txtSID.Text <> "" Then
            Dim m2 As Model.MLS_Employees = b.getInfo(txtSID.Text)
            If compareObjectEdit(m1, m2) Then
                ask = True
            End If
        Else
            If compareObjectEdit(m1, Nothing) Then
                ask = True
            End If
        End If
        If ask Then
            Dim re As DialogResult = ShowMsgYesNoCancel(m_MsgAskSaveBeforeExit, m_MsgCaption)
            Select Case re
                Case Windows.Forms.DialogResult.Yes
                    If Not Save() Then
                        e.Cancel = True
                    End If
                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub FrmNewEmployee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If Me.tbManager.Tools("btnSave").SharedProps.Enabled = True Then
            If e.KeyCode = Keys.F2 Then
                If Save() Then
                    If txtOrdinal.Text = "0" Then
                        Me.ClearInfo()
                    Else
                        Me.Close()
                    End If
                    ShowMsgInfo(m_MsgSaveSuccess, m_MsgCaption)
                End If
            End If
        End If
        If Me.tbManager.Tools("btnSaveClose").SharedProps.Visible = True Then
            If e.KeyCode = Keys.F4 Then 'luu va thoat
                If Save() Then
                    Me.ClearInfo()
                    Me.Close()
                    ShowMsgInfo(m_MsgSaveSuccess, m_MsgCaption)
                End If
            End If
        End If

        If Me.tbManager.Tools("btnEdit").SharedProps.Visible = True Then
            If Me.tbManager.Tools("btnEdit").SharedProps.Enabled = True Then
                If e.KeyCode = Keys.F6 Then
                    Me.tbManager.Tools("btnSave").SharedProps.Enabled = True
                    Me.tbManager.Tools("btnEdit").SharedProps.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub FrmNewEmployee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        If txtSID.Text = "" Then '26.05.09
            Me.LoadCombo()
            Me.cboCur1.Text = ModMain.m_SysCur
            Me.cboCur2.Text = ModMain.m_SysCur
            Me.cboCur1.ReadOnly = True
            Me.cboCur2.ReadOnly = True
            If cboPosition.Rows.Count >= 2 Then cboPosition.Rows(1).Selected = True
        End If
        Security()
    End Sub

#End Region

#Region "SUB"
    Private f_SecA As Boolean = False
    Private f_SecE As Boolean = False

    Private Sub Security()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 27)

        f_SecA = m.A
        f_SecE = m.U
        If Not f_SecA And Not f_SecE Then
            Me.tbManager.Tools("btnSave").SharedProps.Enabled = False
        End If
        Me.tbManager.Tools("btnEdit").SharedProps.Enabled = f_SecE
    End Sub

    Private Sub ClearInfo()
        Me.txtOrdinal.Text = "0"
        Me.txtSID.Text = ""
        Me.txtEmployeeID.Text = ""
        Me.txtEmployeeName.Text = ""
        Me.chActive.Checked = True
        Me.cboPosition.Value = Nothing
        Me.pic1.Image = Nothing
        Me.dtDOB.Value = Nothing
        Me.dtDaysToWork.Value = Nothing
        Me.txtAddress.Text = ""
        Me.txtPhone1.Text = ""
        Me.txtPhone2.Text = ""
        Me.txtEmail.Text = ""
        Me.chHoliday.Checked = False
        Me.dtHolidays.Value = Nothing
        Me.txtReason.Text = ""
        Me.txtBasicSalary.Text = 0
        Me.txtNofDay.Text = 0
        Me.txtSalaryOf.Text = 0
        Me.txtNote.Text = ""
        txtAccountID.Text = ""
        Me.chDS.Checked = False
        chkCTV.Checked = False
        cboReferrer.Value = Nothing

        If txtEmployeeID.Enabled = False Then
            txtEmployeeName.Focus()
        Else
            txtEmployeeID.Focus()
        End If
    End Sub

    Private Sub LoadCombo()
        Dim tb As DataTable = b.getListReferrer(txtSID.Text)
        cboReferrer.ValueMember = "s_ID"
        cboReferrer.DisplayMember = "s_Name"
        cboReferrer.DataSource = tb
    End Sub

    Public Sub LoadInfo(ByVal SID As String)
        Me.LoadCombo() '26.05.09
        Dim obj As Model.MLS_Employees = b.getInfo(SID)
        If obj Is Nothing Then Exit Sub
        If obj.s_ID = "" Then
            Exit Sub
        End If

        Dim sText As String = ""


        Me.txtSID.Text = obj.s_ID
        Me.txtEmployeeID.Text = obj.s_Employee_ID
        Me.txtEmployeeName.Text = obj.s_Name
        Me.txtAddress.Text = obj.s_Address
        Me.txtPhone1.Text = obj.s_Phone1
        Me.txtPhone2.Text = obj.s_Phone2
        Me.txtOrdinal.Text = obj.i_Ordinal
        Me.txtNote.Text = obj.s_Note
        '26.05.09
        Me.txtEmail.Text = obj.s_Email
        If obj.i_Position <> 0 Then
            Me.cboPosition.Value = obj.i_Position
        End If

        If obj.b_Sex = True Then
            Me.radMale.Checked = obj.b_Sex
        Else
            Me.radFemale.Checked = Not obj.b_Sex
        End If
        Me.pic1.Image = Me.toImage(obj.im_Photo)

        If CStr(Format(obj.dt_DOB, "ddMMyyyy")) = "01011900" Then
            Me.dtDOB.Text = ""
        Else
            Me.dtDOB.Value = obj.dt_DOB
        End If

        If CStr(Format(obj.dt_DaysToWork, "ddMMyyyy")) = "01011900" Then
            Me.dtDaysToWork.Text = ""
        Else
            Me.dtDaysToWork.Value = obj.dt_DaysToWork
        End If

        If CStr(Format(obj.dt_Holidays, "ddMMyyyy")) = "01011900" Then
            Me.dtHolidays.Text = ""
        Else
            Me.dtHolidays.Value = obj.dt_Holidays
            Me.chHoliday.Checked = True
        End If

        Me.txtReason.Text = obj.s_Reason

        Me.txtNofDay.Text = Format(obj.i_NofDay, ModMain.m_strFormatCur)
        If obj.m_BasicSalary > 0 Then
            Me.txtBasicSalary.Text = Format(CDbl(obj.m_BasicSalary), ModMain.m_strFormatCur)
            radBasicSalary.Checked = True
            Me.txtSalaryOf.Text = 0
        Else
            Me.txtBasicSalary.Text = 0
            radSalaryOf.Checked = True
            Me.txtSalaryOf.Text = Format(CDbl(obj.m_SalaryOf), ModMain.m_strFormatCur)
        End If

        Me.cboCur1.Text = ModMain.m_SysCur '05.06.09
        Me.cboCur2.Text = ModMain.m_SysCur
        Me.cboCur1.ReadOnly = True
        Me.cboCur2.ReadOnly = True

        Me.chActive.Checked = obj.b_IsActive
        Me.txtCreator.Text = obj.s_UserCreate
        Me.txtEditor.Text = obj.s_UserEdit
        Me.txtDateCreate.Text = obj.dt_Create.ToString
        Me.txtDateEdit.Text = obj.dt_LastUpdate.ToString
        Me.chDS.Checked = obj.b_IsSales
        If obj.dt_Holidays.Year <> 1900 Then
            dtHolidays.Value = obj.dt_Holidays
            chHoliday.Checked = True
        End If
        cboBank.Value = obj.s_Bank_ID
        txtAccountID.Text = obj.s_AccountID

        chkCTV.Checked = obj.IsCTV
        cboReferrer.Value = obj.ReferrerId


        Me.tbManager.Tools("btnSaveClose").SharedProps.Visible = False

    End Sub

    Private Function toImage(ByVal ArrByte() As Byte) As Image
        If ArrByte Is Nothing Then Return Nothing
        Dim sm As New MemoryStream(ArrByte)
        Return Image.FromStream(sm)
    End Function

    Private Sub OpenImage(ByVal PIM As Infragistics.Win.UltraWinEditors.UltraPictureBox)
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = "Chọn file nội dung"
        OpenFileDialog1.Filter = "Image Files(*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()

        If dlg = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim sFilePath As String

        sFilePath = OpenFileDialog1.FileName
        If sFilePath = "" Then Exit Sub
        If System.IO.File.Exists(sFilePath) = False Then
            Exit Sub
        End If
        Dim fs As FileStream = New FileStream(sFilePath, FileMode.Open)
        Dim ArrByte As Byte() = New Byte(fs.Length) {}
        fs.Read(ArrByte, 0, fs.Length)
        fs.Close()
        Dim sm As New MemoryStream(ArrByte)
        PIM.Image = Image.FromStream(sm)
        sm = Nothing

    End Sub

    Private Function getArrByte(ByVal IM As Image) As Byte()
        Dim ms As New MemoryStream
        IM.Save(ms, IM.RawFormat)
        Dim arrImage() As Byte = ms.GetBuffer
        ms.Close()
        Return arrImage
    End Function

    Private Sub OpenImage2(ByVal PIM As Infragistics.Win.UltraWinEditors.UltraPictureBox)
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = "Chọn file nội dung"
        OpenFileDialog1.Filter = "Image Files(*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()

        If dlg = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim sFilePath As String

        sFilePath = OpenFileDialog1.FileName
        If sFilePath = "" Then Exit Sub
        If System.IO.File.Exists(sFilePath) = False Then
            Exit Sub
        End If
        Dim fs As FileStream = New FileStream(sFilePath, FileMode.Open)
        Dim ArrByte As Byte() = New Byte(fs.Length) {}
        fs.Read(ArrByte, 0, fs.Length)
        fs.Close()
        Dim sm As New MemoryStream(ArrByte)
        PIM.Image = Image.FromStream(sm)
        sm = Nothing
    End Sub
#End Region

#Region "FUNCTION"

    Private Function setInfo() As Model.MLS_Employees
        Dim m As New Model.MLS_Employees

        m.s_ID = txtSID.Text
        m.s_Employee_ID = Me.txtEmployeeID.Text.Trim
        m.s_Name = txtEmployeeName.Text
        m.s_Phone1 = txtPhone1.Text
        m.s_Phone2 = txtPhone2.Text
        m.s_Address = txtAddress.Text
        m.s_Note = Me.txtNote.Text
        m.s_Email = Me.txtEmail.Text  '26.05.09->tu day xuong duoi
        If Not Me.cboPosition.Value Is Nothing Then
            m.i_Position = Me.cboPosition.Value
        End If
        If Not Me.cboBank.Value Is Nothing Then
            m.s_Bank_ID = Me.cboBank.Value
        End If
        m.s_AccountID = txtAccountID.Text
        m.b_Sex = Me.radMale.Checked

        If Not Me.pic1.Image Is Nothing Then
            m.im_Photo = getArrByte(pic1.Image)
        Else
            m.im_Photo = Nothing
        End If

        If Not Me.dtDOB.Value Is Nothing Then
            m.dt_DOB = Me.dtDOB.Value
        Else
            m.dt_DOB = IIf(Me.dtDOB.Value Is Nothing, "1/1/1900", Me.dtDOB.Value)
        End If

        If Not Me.dtDaysToWork.Value Is Nothing Then
            m.dt_DaysToWork = Me.dtDaysToWork.Value
        Else
            m.dt_DaysToWork = IIf(Me.dtDaysToWork.Value Is Nothing, "1/1/1900", Me.dtDaysToWork.Value)
        End If
        If chHoliday.Checked Then
            If Not Me.dtHolidays.Value Is Nothing Then
                m.dt_Holidays = Me.dtHolidays.Value
            Else
                m.dt_Holidays = CDate("1900-1-1")
            End If
        Else
            m.dt_Holidays = CDate("1900-1-1")
        End If


        m.s_Reason = Me.txtReason.Text
        If txtBasicSalary.Text = "" Then txtBasicSalary.Text = 0
        If txtSalaryOf.Text = "" Then txtSalaryOf.Text = 0
        If txtNofDay.Text = "" Then txtNofDay.Text = 0

        If Me.radBasicSalary.Checked = True Then
            m.m_BasicSalary = CDbl(Me.txtBasicSalary.Text)
        End If

        If Me.radSalaryOf.Checked = True Then
            m.m_SalaryOf = CDbl(Me.txtSalaryOf.Text)
        End If
        m.i_NofDay = CInt(Me.txtNofDay.Text)

        If Not Me.cboCur1.Value Is Nothing Then
            m.s_Currency1 = Me.cboCur1.Value
        End If

        If Not Me.cboCur2.Value Is Nothing Then
            m.s_Currency2 = Me.cboCur2.Value
        End If
        m.b_IsSales = Me.chDS.Checked

        m.b_IsActive = True
        m.s_UserCreate = ModMain.m_UIDLogin
        m.s_UserEdit = ModMain.m_UIDLogin
        m.IsCTV = chkCTV.Checked
        If m.IsCTV Then
            m.ReferrerId = cboReferrer.Value
        End If
        Return m
    End Function

    Private Function CheckOK() As Boolean
        If txtEmployeeID.Text.Trim = "" Then
            ShowMsg("Nhập mã nhân viên!", 164)
            txtEmployeeID.Focus()
            Return False
        Else
            If b.CheckDulicate(txtEmployeeID.Text, txtSID.Text) Then
                ShowMsg("Mã nhân viên bị trùng!", 165)
                txtEmployeeID.Focus()
                Return False
            End If
        End If
        If txtEmployeeName.Text.Trim = "" Then
            ShowMsg("Nhập tên nhân viên!", 166)
            txtEmployeeName.Focus()
            Return False
        End If

        If Me.cboPosition.SelectedRow Is Nothing AndAlso cboPosition.Text.Trim <> "" Then
            ShowMsg("Dữ liệu không hợp lệ.", 167)
            Me.cboPosition.Select()
            Return False
        End If
        If Me.cboPosition.SelectedRow Is Nothing Then
            ShowMsg("Chưa chọn chức vụ", 168)
            cboPosition.Focus()
            Return False
        End If

        If Not CompareValidDate(dtDOB, dtDaysToWork) Then
            ShowMsg("Ngày vào làm không hợp lệ !", 170)
            dtDaysToWork.Focus()
            dtDaysToWork.SelectAll()
            Return False
        End If

        If Not Me.cboBank.SelectedRow Is Nothing AndAlso cboBank.Text.Trim <> "" AndAlso cboBank.Text.Trim <> "0" Then
            If txtAccountID.Text.Trim = "" Then
                ShowMsg("Chưa nhập số tài khoản ngân hàng !", 894)
                txtAccountID.Focus()
                Return False
            End If
        End If

        '05/09/09n --van cho nghi du cophat sinh nghiep vu
        'If chHoliday.Checked Then
        '    If b.CheckHoliday(txtSID.Text) Then
        '        ShowMsg("Nhân viên này còn phụ trách khách hàng hoặc nhà cung cấp! Không thể Check nghỉ việc.")
        '        Return False
        '    End If
        'End If

        If chHoliday.Checked Then
            If dtHolidays.Value Is Nothing Then
                ShowMsg("Nhập thông tin ngày nghỉ việc", 172)
                dtHolidays.Focus()
                Return False
            End If
        End If


        'If Me.radBasicSalary.Checked Then
        '    If CDbl(Me.txtBasicSalary.Text) <= 0 Then
        '        ShowMsg("Lương căn bản phải có giá trị lớn hơn 0")
        '        txtBasicSalary.Focus()
        '        Return False
        '    End If
        'Else
        '    If CDbl(Me.txtSalaryOf.Text) <= 0 Then
        '        ShowMsg("Lương ca phải có giá trị lớn hơn 0")
        '        txtSalaryOf.Focus()
        '        Return False
        '    End If
        'End If

        If txtOrdinal.Text = "" Or Not IsNumeric(txtOrdinal.Text) Then txtOrdinal.Text = "0"

        If chkCTV.Checked Then
            If cboReferrer.Value Is Nothing Then
                ShowMsg("Chưa chọn nhân viên liên kết.")
                cboReferrer.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    'Thao180809
    Public Function CompareValidDate(ByVal fromDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor, ByVal toDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor) As Boolean
        If DateDiff(DateInterval.Year, toDate.Value, fromDate.Value, FirstDayOfWeek.System, FirstWeekOfYear.System) >= 0 Then
            Return False
        Else
            If DateDiff(DateInterval.Month, toDate.Value, fromDate.Value, FirstDayOfWeek.System, FirstWeekOfYear.System) >= 0 Then
                Return False
            Else
                If DateDiff(DateInterval.Day, toDate.Value, fromDate.Value, FirstDayOfWeek.System, FirstWeekOfYear.System) > 0 Then
                    Return False
                End If
            End If
        End If

        Return True
    End Function
    Public Function Save() As Boolean
        If Not CheckOK() Then Return False
        Dim m As Model.MLS_Employees = Me.setInfo()
        Dim strEvent As String = ""
        If m.s_ID = "" Then 'Them moi
           strEvent = "Thêm mới nhân viên có mã '" & m.s_Employee_ID & "'"
        Else 'Hieu chinh
            strEvent = "Hiệu chỉnh nhân viên có mã '" & m.s_Employee_ID & "'"
        End If
        If b.UPDATEDB(m) Then
            ModMain.UpdateEvent(ModMain.m_UIDLogin, strEvent, TypeEvents.List)
            keySelect = m.s_ID
            Return True
        End If

    End Function

    Private Function compareObjectEdit(ByVal m1 As Model.MLS_Employees, ByVal m2 As Model.MLS_Employees) As Boolean
        If Not m2 Is Nothing Then 'Hieu chinh
            If m1.s_ID <> m2.s_ID Then
                Return True
            End If
            If m1.s_Employee_ID <> m2.s_Employee_ID Then
                Return True
            End If
            If m1.s_Name <> m2.s_Name Then '2.12.08
                Return True
            End If
            If m1.s_Phone1 <> m2.s_Phone1 Then
                Return True
            End If
            If m1.s_Phone2 <> m2.s_Phone2 Then '9.12.08
                Return True
            End If
            If m1.s_Address <> m2.s_Address Then
                Return True
            End If
            If m1.s_Note <> m2.s_Note Then
                Return True
            End If
            If m1.i_Position <> m2.i_Position Then
                Return True
            End If
            If m1.b_Sex <> m2.b_Sex Then
                Return True
            End If
            If m1.b_IsSales <> m2.b_IsSales Then
                Return True
            End If
            If m1.b_IsActive <> m2.b_IsActive Then
                Return True
            End If
            If m1.s_Reason <> m2.s_Reason Then
                Return True
            End If
            If m1.dt_DOB <> m2.dt_DOB Then
                Return True
            End If
            If m1.dt_DaysToWork <> m2.dt_DaysToWork Then
                Return True
            End If
            If m1.dt_Holidays <> m2.dt_Holidays Then
                Return True
            End If
            If m1.i_NofDay <> m2.i_NofDay Then
                Return True
            End If
            If m1.m_BasicSalary <> m2.m_BasicSalary Then
                Return True
            End If
            If m1.m_SalaryOf <> m2.m_SalaryOf Then
                Return True
            End If
        Else 'kiem tra moi
            If m1.s_ID <> "" Then
                Return True
            End If

            'If m1.s_Employee_ID <> "" Then '2.12.08
            '    Return True
            'End If

            If m1.s_Name <> "" Then '9.12.08
                Return True
            End If

            If m1.s_Phone1 <> "" Then
                Return True
            End If
            If m1.s_Phone2 <> "" Then
                Return True
            End If
            If m1.s_Address <> "" Then
                Return True
            End If
            If m1.s_Note <> "" Then
                Return True
            End If

        End If
        Return False
    End Function

#End Region

#Region "tab 002"
    'Private Sub AddNew_002()
    '    Dim frm As New frmNewEmployeeDiscount
    '    frm.LoadInfo("", txtSID.Text)

    '    Dim sEdit As String = frm.ShowDialog(False)
    '    If sEdit <> "" Then
    '        loadGrid002()
    '    End If
    'End Sub

    'Private Sub Edit_002()
    '    Dim r As UltraGridRow = Grid002.ActiveRow
    '    If r Is Nothing OrElse r.Index = -1 Then
    '        Exit Sub
    '    End If
    '    Dim frm As New frmNewEmployeeDiscount
    '    frm.LoadInfo(r.Cells("s_ID").Value, r.Cells("s_Employee_ID").Value)

    '    Dim sEdit = frm.ShowDialog(True)
    '    If sEdit <> "" Then
    '        loadGrid002()
    '        For i As Integer = 0 To Grid002.Rows.Count - 1
    '            If Grid002.Rows(i).Cells("s_ID").Value = sEdit Then
    '                Grid002.Rows(i).Selected = True
    '                Grid002.Rows(i).Activated = True
    '                Exit For
    '            End If
    '        Next
    '    End If

    'End Sub

    'Public Sub Del_002()
    '    Dim r As UltraGridRow = Grid002.ActiveRow
    '    If r Is Nothing OrElse r.Index = -1 Then
    '        Exit Sub
    '    End If
    '    'If bEmpDiscount.CheckDel(r.Cells("s_ID").Value) Then
    '    '    ShowMsg("Đợt chiết khấu này đang có thông tin chi tiết.")
    '    '    Exit Sub
    '    'End If
    '    If MessageBox.Show("Có thật sự xóa đợt chiết khấu: " & r.Cells("s_Name").Value & " có mã số là " & r.Cells("s_ID").Value & "?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> Windows.Forms.DialogResult.Yes Then
    '        Exit Sub
    '    End If

    '    If bEmpDiscount.DELETEDB(r.Cells("s_ID").Value) Then
    '        loadGrid002()
    '    End If
    'End Sub

    'Private Sub T_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Add.Click
    '    AddNew_002()
    'End Sub

    'Private Sub T_DEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_DEL.Click
    '    Del_002()
    'End Sub

    'Private Sub T_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Edit.Click
    '    Edit_002()
    'End Sub


    'Private Sub T_Layout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Layout.Click
    '    Dim frm As New Ulti.FrmFormatUltraGrid(Me.Name, Grid002)
    '    frm.ShowDialog()
    'End Sub

    'Private Sub Grid002_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid002.DoubleClick
    '    Edit_002()
    'End Sub
#End Region

#Region "Tab control"
    Private Sub txtEmployeeID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmployeeID.KeyPress
        If e.KeyChar = Chr(13) Then
            ' Me.chActive.Focus()
            Me.txtEmployeeName.Focus()
        End If
    End Sub

    Private Sub chHoliday_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chHoliday.CheckedChanged, chDS.CheckedChanged
        If Me.chHoliday.Checked = True Then
            Me.lblDateHoliday.Enabled = True
            Me.lblReason.Enabled = True
            Me.dtHolidays.ReadOnly = False
            Me.txtReason.ReadOnly = False
            Me.dtHolidays.Appearance.BackColor = Nothing
            Me.txtReason.Appearance.BackColor = Nothing
            Me.dtHolidays.Focus()
        Else
            Me.lblDateHoliday.Enabled = False
            Me.lblReason.Enabled = False
            Me.dtHolidays.ReadOnly = True
            Me.txtReason.ReadOnly = True
            Me.dtHolidays.Appearance.BackColor = Color.Transparent
            Me.txtReason.Appearance.BackColor = Color.Transparent
            Me.dtHolidays.Value = Nothing
            Me.txtReason.Text = ""
        End If
    End Sub
    Private Sub chActive_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chActive.KeyDown
        If e.KeyCode = Keys.Space Then
            If Me.chActive.Checked = False Then
                Me.chActive.Checked = True
            Else
                Me.chActive.Checked = False
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            Me.txtEmployeeName.Focus()
        End If
    End Sub
    Private Sub txtEmployeeName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmployeeName.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cboPosition.Focus()
        End If
    End Sub
    Private Sub cboPosition_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPosition.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.radMale.Select()
        End If
    End Sub
    Private Sub radMale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles radMale.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtDOB.Focus()
        End If
    End Sub
    Private Sub radFemale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles radFemale.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtDOB.Focus()
        End If
    End Sub
    Private Sub dtDOB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtDOB.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.dtDaysToWork.Focus()
        End If
    End Sub

    Private Sub dtDaysToWork_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtDaysToWork.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboBank.Focus()
        End If
    End Sub

    Private Sub cboBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtAccountID.Focus()
        End If
    End Sub

    Private Sub txtAccountID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccountID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtAddress.Focus()
        End If
    End Sub

    Private Sub txtAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        If e.KeyChar = Chr(13) Then
            txtPhone1.Focus()
        End If
    End Sub

    Private Sub txtPhone1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPhone1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPhone2.Focus()
        End If
    End Sub

    Private Sub txtPhone1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhone1.KeyPress
        Dim k As Short = Asc(e.KeyChar)
        If k <> 13 Then
            clsu.UltraTextBox_KeyPress(k, Me.txtPhone1)
            If k = 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPhone2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPhone2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtEmail.Focus()
        End If
    End Sub

    Private Sub txtPhone2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhone2.KeyPress
        Dim k As Short = Asc(e.KeyChar)
        If k <> 13 Then
            clsu.UltraTextBox_KeyPress(k, Me.txtPhone2)
            If k = 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtEmail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.chHoliday.Select()
        End If
    End Sub
    Private Sub chHoliday_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chHoliday.KeyDown, chDS.KeyDown
        If e.KeyCode = Keys.Space Then
            If Me.chHoliday.Checked = False Then
                Me.chHoliday.Checked = True
            Else
                Me.chHoliday.Checked = False
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If chHoliday.Checked = True Then
                Me.dtHolidays.Focus()
            Else
                Me.radBasicSalary.Select()
            End If
        End If
    End Sub

    Private Sub radBasicSalary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles radBasicSalary.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBasicSalary.Focus()
        End If
    End Sub

    Private Sub dtHolidays_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtHolidays.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtReason.Focus()
        End If
    End Sub
    Private Sub txtReason_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReason.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtBasicSalary.Focus()
        End If
    End Sub
    Private Sub txtBasicSalary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBasicSalary.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cboCur1.Focus()
        End If
    End Sub
    Private Sub cboCur1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCur1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If CDbl(txtBasicSalary.Text) = 0 Then
                'Me.txtNofDay.Focus()
                radSalaryOf.Select()
            End If

        End If
    End Sub

    Private Sub radSalaryOf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles radSalaryOf.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSalaryOf.Focus()
        End If
    End Sub
    'Private Sub txtNofDay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNofDay.KeyDown
    'If e.KeyCode = Keys.Enter Then
    '    'Me.txtSalaryOf.Focus()
    '        Me.UltraTabControl1.SelectedTab.Key = "001"
    'End If
    ' End Sub
    Private Sub txtSalaryOf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSalaryOf.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cboCur2.Focus()
        End If
    End Sub
    Private Sub cboCur2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCur2.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Me.UltraTabControl1.SelectedTab.Key = "001"
            txtNofDay.Focus()
        End If
    End Sub
#End Region

#Region "tbManager" '26.05.09
    Private Sub tbManager_ToolClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles tbManager.ToolClick
        Select Case e.Tool.Key
            Case "btnFirst"
                Dim IDSort As Double = CDbl(Me.txtOrdinal.Text)
                Dim s_ID As String = b.getIDItem(IDSort, 0)
                If s_ID <> "" Then
                    Me.ClearInfo()
                    Me.LoadInfo(s_ID)
                End If
                If Me.tbManager.Tools("btnSave").SharedProps.Enabled = True Then
                    If Me.tbManager.Tools("btnEdit").SharedProps.Visible = False Then
                        Me.tbManager.Tools("btnEdit").SharedProps.Visible = True
                    End If
                    Me.tbManager.Tools("btnEdit").SharedProps.Enabled = True
                    Me.tbManager.Tools("btnSave").SharedProps.Enabled = False
                End If
            Case "btnPre"
                Dim IDSort As Double = CDbl(Me.txtOrdinal.Text)
                Dim s_ID As String = b.getIDItem(IDSort, 1)
                If s_ID <> "" Then
                    Me.ClearInfo()
                    Me.LoadInfo(s_ID)
                End If
                If Me.tbManager.Tools("btnSave").SharedProps.Enabled = True Then
                    If Me.tbManager.Tools("btnEdit").SharedProps.Visible = False Then
                        Me.tbManager.Tools("btnEdit").SharedProps.Visible = True
                    End If
                    Me.tbManager.Tools("btnEdit").SharedProps.Enabled = True
                    Me.tbManager.Tools("btnSave").SharedProps.Enabled = False
                End If
            Case "btnNext"
                Dim IDSort As Double = CDbl(Me.txtOrdinal.Text)
                Dim s_ID As String = b.getIDItem(IDSort, 2)
                If s_ID <> "" Then
                    Me.ClearInfo()
                    Me.LoadInfo(s_ID)
                End If
                If Me.tbManager.Tools("btnSave").SharedProps.Enabled = True Then
                    If Me.tbManager.Tools("btnEdit").SharedProps.Visible = False Then
                        Me.tbManager.Tools("btnEdit").SharedProps.Visible = True
                    End If
                    Me.tbManager.Tools("btnEdit").SharedProps.Enabled = True
                    Me.tbManager.Tools("btnSave").SharedProps.Enabled = False
                End If
            Case "btnLast"
                Dim IDSort As Double = CDbl(Me.txtOrdinal.Text)
                Dim s_ID As String = b.getIDItem(IDSort, 3)
                If s_ID <> "" Then
                    Me.ClearInfo()
                    Me.LoadInfo(s_ID)
                End If
                If Me.tbManager.Tools("btnSave").SharedProps.Enabled = True Then
                    If Me.tbManager.Tools("btnEdit").SharedProps.Visible = False Then
                        Me.tbManager.Tools("btnEdit").SharedProps.Visible = True
                    End If
                    Me.tbManager.Tools("btnEdit").SharedProps.Enabled = True
                    Me.tbManager.Tools("btnSave").SharedProps.Enabled = False
                End If
            Case "btnSaveClose"
                If Save() Then
                    Me.ClearInfo()
                    Me.Close()
                    ShowMsgInfo(m_MsgSaveSuccess, m_MsgCaption)
                End If
            Case "btnSave"
                If Save() Then
                    If txtOrdinal.Text = "0" Then
                        Me.ClearInfo()
                    Else
                        Me.Close()
                    End If
                    ShowMsgInfo(m_MsgSaveSuccess, m_MsgCaption)
                End If
            Case "btnClose"
                Me.Close()
            Case "btnEdit"
                Me.tbManager.Tools("btnSave").SharedProps.Enabled = True
                Me.tbManager.Tools("btnEdit").SharedProps.Enabled = False
        End Select
    End Sub
#End Region

#Region "tbTool"
    Private Sub tbTool_ToolClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles tbTool.ToolClick
        Select Case e.Tool.Key
            Case "Bold"
                Me.txtNote.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleBold)

            Case "Italic"
                Me.txtNote.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleItalics)

            Case "Underline"
                Me.txtNote.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleUnderline)

            Case "Left", "Center", "Right", "Justify"
                Me.txtNote.EditInfo.ApplyStyle("Text-align: " + e.Tool.Key, True)
        End Select

    End Sub

    Private Sub tbTool_ToolValueChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolEventArgs) Handles tbTool.ToolValueChanged
        Select Case e.Tool.Key
            Case "FontName"
                Dim fontName As String = CType(e.Tool, FontListTool).Text
                Me.txtNote.EditInfo.ApplyStyle("Font-family: " + fontName, False)

            Case "FontColor"
                Me.ApplyFontForeColor()

            Case "FontSize"
                Dim selectedSize As String = CType(e.Tool, ComboBoxTool).Value.ToString()
                Me.txtNote.EditInfo.ApplyStyle("Font-size: " + selectedSize, False)
        End Select
        Me.txtNote.Focus()
    End Sub

    Private Sub ApplyFontForeColor() '
        Dim fontColor As Color = CType(Me.tbTool.Tools("FontColor"), PopupColorPickerTool).SelectedColor
        Dim hexColor As String = System.Drawing.ColorTranslator.ToHtml(fontColor)
        Me.txtNote.EditInfo.ApplyStyle("Color: " + hexColor, False)
        Me.txtNote.EditInfo.ApplyStyle("Border-color: " + hexColor, False)
    End Sub
#End Region

#Region "Combo"
    Private Sub cboPosition_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPosition.AfterCloseUp
     
    End Sub

    Private Sub cboPosition_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboPosition.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("s_Name").Hidden = False
        If cboPosition.Rows.Count > 0 Then
            cboPosition.Rows(0).Appearance.BackColor = Color.LightCyan
        End If
        cboPosition.DisplayLayout.Bands(0).Columns("s_Name").PerformAutoResize(ColumnAutoSizeMode.AllRowsInBand)

    End Sub

    Private Sub cboCur1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCur1.InitializeLayout
        If Me.cboCur1.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("IDKH_s").Hidden = False
        e.Layout.Bands(0).Columns("s_Name").Width = 100
        e.Layout.Bands(0).Columns("s_Name").Hidden = False
        If cboCur1.Rows.Count > 0 Then
            cboCur1.Rows(0).Appearance.BackColor = Color.LightCyan
        End If
        cboCur1.DisplayLayout.Bands(0).Columns("IDKH_s").PerformAutoResize(ColumnAutoSizeMode.AllRowsInBand)
        cboCur1.DisplayLayout.Bands(0).Columns("s_Name").PerformAutoResize(ColumnAutoSizeMode.AllRowsInBand)

    End Sub
    Private Sub cboCur1_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCur1.AfterCloseUp
    End Sub

    Private Sub cboCur2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCur2.InitializeLayout
        If Me.cboCur2.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("IDKH_s").Hidden = False
        e.Layout.Bands(0).Columns("s_Name").Width = 100
        e.Layout.Bands(0).Columns("s_Name").Hidden = False
        If cboCur2.Rows.Count > 0 Then
            cboCur2.Rows(0).Appearance.BackColor = Color.LightCyan
        End If
        cboCur2.DisplayLayout.Bands(0).Columns("IDKH_s").PerformAutoResize(ColumnAutoSizeMode.AllRowsInBand)
        cboCur2.DisplayLayout.Bands(0).Columns("s_Name").PerformAutoResize(ColumnAutoSizeMode.AllRowsInBand)


    End Sub

    Private Sub cboCur2_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCur2.AfterCloseUp
    End Sub
    Private Sub cboBank_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboBank.InitializeLayout
        If Me.cboBank.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next

        Dim k As Integer = 0
        e.Layout.Bands(0).Columns("s_Bank_ID").Header.VisiblePosition = k
        e.Layout.Bands(0).Columns("s_Bank_ID").Hidden = False
        k += 1
        e.Layout.Bands(0).Columns("s_Name").Header.VisiblePosition = k
        e.Layout.Bands(0).Columns("s_Name").Hidden = False

        e.Layout.Bands(0).Columns("s_Bank_ID").PerformAutoResize(ColumnAutoSizeMode.AllRowsInBand)
        e.Layout.Bands(0).Columns("s_Name").PerformAutoResize(ColumnAutoSizeMode.AllRowsInBand)
    End Sub

    Private Sub cboBank_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBank.Validated
        If Me.cboBank.SelectedRow Is Nothing AndAlso Me.cboBank.Text.Trim <> "" Then
            cboBank.Focus()
        End If
    End Sub

#End Region

#Region "PictureBox"
    Private Sub pic1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic1.DoubleClick
        OpenImage(pic1)
    End Sub
#End Region

#Region "Format Textbox"

    Private Sub txtBasicSalary_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBasicSalary.KeyPress
        Dim k As Short = Asc(e.KeyChar)
        clsu.UltraTextBox_KeyPress(k, Me.txtBasicSalary)
        If k = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtBasicSalary_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBasicSalary.Leave
        clsu.UltraTextBox_LostFocus(ModMain.m_strFormatCur, txtBasicSalary)
    End Sub

    Private Sub txtBasicSalary_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBasicSalary.ValueChanged
        clsu.UltraTextBox_Change(ModMain.m_strFormatCur, Me.txtBasicSalary)

    End Sub

    Private Sub txtSalaryOf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalaryOf.KeyPress
        Dim k As Short = Asc(e.KeyChar)
        clsu.UltraTextBox_KeyPress(k, Me.txtSalaryOf)
        If k = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSalaryOf_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalaryOf.Leave
        clsu.UltraTextBox_LostFocus(ModMain.m_strFormatCur, txtSalaryOf)
    End Sub

    Private Sub txtSalaryOf_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalaryOf.ValueChanged
        clsu.UltraTextBox_Change(ModMain.m_strFormatCur, Me.txtSalaryOf)

    End Sub

    Private Sub txtNofDay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNofDay.KeyDown
        If e.KeyCode = Keys.Enter Then
            chDS.Focus()
        End If
    End Sub

    Private Sub txtNofDay_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNofDay.KeyPress
        Dim k As Short = Asc(e.KeyChar)
        clsu.UltraTextBox_KeyPress(k, Me.txtNofDay)
        If k = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNofDay_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNofDay.ValueChanged
        clsu.UltraTextBox_Change(ModMain.m_strFormatCur, Me.txtNofDay)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        OpenImage2(pic1)
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        pic1.Image = Nothing
    End Sub
#End Region

#Region "Context menu"
    Private Sub T_AddPic1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_AddPic1.Click
        OpenImage(pic1)
    End Sub

    Private Sub T_DeletePic1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_DeletePic1.Click
        pic1.Image = Nothing
    End Sub
#End Region

#Region "RadionButton"
    Private Sub cboPosition_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPosition.Validated
        If Me.cboPosition.SelectedRow Is Nothing AndAlso Me.cboPosition.Text.Trim <> "" Then
            cboPosition.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub radBasicSalary_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radBasicSalary.CheckedChanged
        If radBasicSalary.Checked = True Then
            Me.txtBasicSalary.ReadOnly = False
            Me.txtBasicSalary.Appearance.BackColor = Nothing
            Me.txtSalaryOf.ReadOnly = True
            Me.txtSalaryOf.Text = 0
            Me.txtSalaryOf.Appearance.BackColor = Color.Transparent
        Else
            Me.txtBasicSalary.ReadOnly = True
            Me.txtBasicSalary.Text = 0
            Me.txtBasicSalary.Appearance.BackColor = Color.Transparent
            Me.txtSalaryOf.ReadOnly = False
            Me.txtSalaryOf.Appearance.BackColor = Nothing
        End If
    End Sub
#End Region

    Private Sub cboReferrer_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboReferrer.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("s_Name").Hidden = False
        cboReferrer.DisplayLayout.Bands(0).Columns("s_Name").PerformAutoResize(ColumnAutoSizeMode.AllRowsInBand)
    End Sub

    Private Sub chkCTV_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCTV.CheckedChanged
        cboReferrer.Enabled = chkCTV.Checked
    End Sub
End Class