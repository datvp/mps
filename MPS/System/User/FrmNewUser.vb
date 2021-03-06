Public Class FrmNewUser
    Dim clsu As New VsoftBMS.Ulti.ClsUti
    Private WithEvents b As New BLL.BSecUser
    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub

    Private showDAL As Boolean = False
    Private keySelect As String = ""
    Private s_Group_ID As String = ""
    Private s_Employees_ID As String = ""

#Region "Form "
    Public Overloads Function ShowDialog(ByVal f As Boolean) As String
        showDAL = f
        Me.ShowDialog()
        Return keySelect
    End Function

    Public Overloads Function ShowDialog(ByRef IDGroup As String) As String
        cboGroupUser.Value = IDGroup
        Me.ShowDialog()
        IDGroup = s_Group_ID 'cboGroupUser.Value
        Return keySelect
    End Function

    Private Sub FrmNewUser_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtUID.Focus()
    End Sub

    Private Sub FrmNewUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btnSave.Enabled = False Then Exit Sub
        Dim m1 As Model.MSecUser = setInfo()
        Dim ask As Boolean = False
        If txtUID.Text <> "" Then
            Dim m2 As Model.MSecUser = b.getInfo(txtUID.Text)
            If compareObjectEdit(m1, m2) Then
                ask = True
            End If
        Else
            If compareObjectEdit(m1, Nothing) Then
                ask = True
            End If
        End If
        If ask Then
            Dim re As DialogResult = ShowMsgYesNoCancel(m_MsgAskSaveBeforeExit, 2)
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

    Private Sub FrmNewUser_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.F2 Then btnSave.PerformClick()
        If e.KeyCode = Keys.F4 Then btnSaveClose.PerformClick()
        If e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub FrmNewUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me,UltraLabel1.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.RedButton(btnSaveClose, ModMain.m_SaveCloseIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)

        If txtIDSort.Text <> "0" Then
            If s_Group_ID <> "" Then
                cboGroupUser.Value = s_Group_ID
            End If

            If s_Employees_ID <> "" Then
                cboEmployees.Value = s_Employees_ID
            End If
        Else
            LoadCombo()
            'load mat dinh
            If cboGroupUser.Value = "" Then
                If cboGroupUser.Rows.Count >= 2 Then cboGroupUser.Rows(1).Selected = True
            End If
            If cboEmployees.Rows.Count >= 2 Then cboEmployees.Rows(1).Selected = True
        End If

        Security()
    End Sub

#End Region

#Region "Sub "

    Private Sub LoadCombo()
        'nhóm người dùng
        cboGroupUser.DisplayMember = "s_Group_Name"
        cboGroupUser.ValueMember = "s_ID"
        cboGroupUser.DataSource = b.getListGroupUser
        If cboGroupUser Is Nothing Then
            cboGroupUser.Value = ""
        End If


        'nhân viên
        cboEmployees.DisplayMember = "s_Name"
        cboEmployees.ValueMember = "S_ID"
        cboEmployees.DataSource = b.getListEmployees
        If cboEmployees.Value Is Nothing Then
            cboEmployees.Value = ""
        End If
    End Sub

    Private Function setInfo() As Model.MSecUser
        Dim m As New Model.MSecUser
        m.UID = Me.txtUID.Text.Trim
        m.IDSort = CInt(txtIDSort.Text)
        m.isAdmin = ChAdmin.Checked
        m.Note = txtNote.Text
        m.GroupUser = cboGroupUser.Value
        m.Employees = cboEmployees.Value
        m.PWD = Helper.Encrypt(txtPWD.Text.Trim)
        m.Valid = ChValid.Checked
        Return m
    End Function

    Private Sub ClearInfo()
        txtIDSort.Text = "0"
        txtUID.Text = ""
        txtPWD.Text = ""
        txtConfirm.Text = ""
        cboGroupUser.Value = ""
        cboEmployees.Value = ""
        ChValid.Checked = True
        ChAdmin.Checked = False
        txtPWD.ReadOnly = False
        txtConfirm.ReadOnly = False
        LinklalthaydoiMK.Visible = False
        txtNote.Text = ""
        ChAdmin.Enabled = True
        ChAdmin.Checked = False
        txtUID.Focus()
    End Sub

    Private Function compareObjectEdit(ByVal m1 As Model.MSecUser, ByVal m2 As Model.MSecUser) As Boolean
        If Not m2 Is Nothing Then 'Hieu chinh
            If m1.UID <> m2.UID Then
                Return True
            End If
            'If m1.IDSort <> m2.IDSort Then
            '    Return True
            'End If
            If m1.isAdmin <> m2.isAdmin Then '9.12.08
                Return True
            End If
            If m1.Note <> m2.Note Then '9.12.08
                Return True
            End If
            'If m1.PWD <> m2.PWD Then '2.12.08
            '    Return True
            'End If
            If m1.Valid <> m2.Valid Then
                Return True
            End If
            'If m1.GroupUser <> m2.GroupUser Then
            '    Return True
            'End If
            If m1.Employees <> m2.Employees Then
                Return True
            End If
        Else 'kiem tra moi
            If m1.UID <> "" Then
                Return True
            End If

            If m1.IDSort <> 0 Then '2.12.08
                Return True
            End If

            'If m1.PWD <> "" Then '9.12.08
            '    Return True
            'End If

            If m1.isAdmin <> False Then '9.12.08
                Return True
            End If

            If m1.Valid <> True Then
                Return True
            End If
            If m1.Note.Trim <> "" Then '9.12.08
                Return True
            End If
            'If Not m1.GroupUser Is Nothing And m1.GroupUser <> "" And m1.GroupUser <> "-1" Then
            '    Return True
            'End If

            'If Not m1.Employees Is Nothing And m1.Employees <> "" And m1.Employees <> "-1" Then
            '    Return True
            'End If
        End If
        Return False
    End Function

    Private Sub Security()
        If ModMain.m_UIDLogin.Trim.ToLower <> "admin" Then
            'kiem tra thong tin user dang dang nhap ctrinh
            'neu la user k co quyen quan tri->dung
            'neu la user co quyen quan tri
            '===co quyen hieu chinh nguoi dung khac
            '===neu hieu chinh chính minh->khong duoc chinh thong tin hieu luc va quan tri

            Dim mUser As Model.MSecUser = b.getInfo(ModMain.m_UIDLogin)
            If Not mUser.isAdmin Then ' ng dung ko co quyen quan tri: dung
                Me.ChAdmin.Checked = False
                Me.ChAdmin.Enabled = False
            End If
        End If
    End Sub

    Public Sub LoadInfo(ByVal UID As String)
        Dim m As Model.MSecUser = b.getInfo(UID)
        If m.UID = "" Then Exit Sub
        LoadCombo()
        txtUID.Text = m.UID
        txtIDSort.Text = m.IDSort
        If UID = ModMain.m_UIDLogin Then
            If m.isAdmin Then
                ChValid.Enabled = False
                ChAdmin.Enabled = False
            Else
                ChValid.Enabled = True
            End If
        End If
        ChAdmin.Checked = m.isAdmin
        ChValid.Checked = m.Valid
        txtNote.Text = m.Note
        txtPWD.Text = Helper.Decrypt(m.PWD)
        txtConfirm.Text = txtPWD.Text
        s_Group_ID = m.GroupUser
        s_Employees_ID = m.Employees
        cboGroupUser.Value = m.GroupUser
        Dim tbEm As DataTable = cboEmployees.DataSource
        Dim DFF() As DataRow = tbEm.Select("s_ID='" & m.Employees.Replace("'", "''") & "'")
        If DFF.Length > 0 Then
            If Not IsDBNull(DFF(0)("dt_Holidays")) Then
                DFF(0)("dt_Holidays") = DBNull.Value
            End If
        End If
        cboEmployees.Value = m.Employees
        txtPWD.ReadOnly = True
        txtConfirm.ReadOnly = True
        LinklalthaydoiMK.Visible = True

        btnSaveClose.Visible = False '02.10.08
    End Sub

    Public Function Save() As Boolean
        If Not CheckOK() Then
            Exit Function
        End If
        Dim m As New Model.MSecUser
        m.UID = Me.txtUID.Text.Trim
        m.IDSort = CInt(txtIDSort.Text)
        m.isAdmin = ChAdmin.Checked
        m.Note = Me.txtNote.Text
        If cboGroupUser.Value IsNot Nothing Then
            m.GroupUser = cboGroupUser.Value
        End If
        If cboEmployees.Value IsNot Nothing Then
            m.Employees = cboEmployees.Value
        End If

        If m.IDSort = 0 Then
            m.PWD = clsu.Encrypt(txtPWD.Text)
        Else
            m.PWD = txtPWD.Text
        End If

        m.Valid = ChValid.Checked
        Dim strEvent As String = ""
        If m.IDSort = 0 Then
            strEvent = "Thêm mới người dùng có mã " & m.UID
        Else
            strEvent = "Hiệu chỉnh người dùng có mã " & m.UID
        End If
        If b.UPDATEDB(m) Then
            ModMain.UpdateEvent(ModMain.m_UIDLogin, strEvent, TypeEvents.System)
            keySelect = m.UID
            Return True
        Else
            ShowMsg(m_SaveDataError, m_MsgCaption)
            Return False
        End If
    End Function

    Private Function CheckOK() As Boolean

        If cboGroupUser.Value Is Nothing Or cboGroupUser.Value = "" Or cboGroupUser.Value = "-1" Then
            ShowMsg("Chọn nhóm người dùng", 143)
            cboGroupUser.Focus()
            Return False
        End If
        If cboEmployees.Value Is Nothing Or cboEmployees.Value = "" Or cboEmployees.Value = "-1" Then
            ShowMsg("Chọn nhân viên", 144)
            cboEmployees.Focus()
            Return False
        End If

        If txtUID.Text.Trim = "" Then
            ShowMsg("Nhập tên người dùng !", 142)
            txtUID.Focus()
            Return False
        End If
        If txtPWD.Text <> txtConfirm.Text Then
            ShowMsg("Mật khẩu xác nhận không chính xác !", 141)
            txtConfirm.Focus()
            Return False
        End If
        If txtIDSort.Text = "" Or Not IsNumeric(txtIDSort.Text) Then txtIDSort.Text = "0"

        If b.CheckDulicate(txtUID.Text, CInt(txtIDSort.Text)) Then
            ShowMsg("Tên người dùng đã tồn tại !", 140)
            txtUID.Focus()
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Button "

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Save() Then
            If Me.txtIDSort.Text = "0" Then
                s_Group_ID = cboGroupUser.Value
                Me.ClearInfo()
                ShowMsgInfo(m_MsgSaveSuccess)
            Else
                s_Group_ID = cboGroupUser.Value
                ShowMsgInfo(m_MsgSaveSuccess)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnSaveClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveClose.Click
        If Save() Then
            s_Group_ID = cboGroupUser.Value
            Me.Close()
            ShowMsgInfo(m_MsgSaveSuccess)
        End If
    End Sub

#End Region

#Region "Textbox - checkbox- combobox - Linklable"

    Private Sub txtUID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUID.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPWD.Focus()
        End If
    End Sub

    Private Sub txtPWD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPWD.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtConfirm.Focus()
        End If
    End Sub

    Private Sub txtConfirm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConfirm.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboGroupUser.Focus()
        End If
    End Sub
    Private Sub cboGroupUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboGroupUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboEmployees.Focus()
        End If
    End Sub
    Private Sub cboEmployees_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEmployees.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNote.Focus()
        End If
    End Sub

    'Private Sub txtNote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNote.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        ChValid.Focus()
    '    End If
    'End Sub

    Private Sub ChValid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChValid.KeyDown
        If e.KeyCode = Keys.Enter Then
            ChAdmin.Focus()
        End If
    End Sub

    Private Sub ChAdmin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChAdmin.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub LinklalthaydoiMK_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinklalthaydoiMK.LinkClicked
        Dim frm As New FrmChangePWD(txtUID.Text)
        frm.ShowDialog()
    End Sub

    Private Sub cboGroupUser_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGroupUser.AfterCloseUp
        If cboGroupUser.Value Is Nothing Then Exit Sub
        If cboGroupUser.Value = "" Then Exit Sub

        If cboGroupUser.Value = "-1" Then
            Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 44)
            If Not m.A Then
                ShowMsg("Người dùng không được cấp quyền thêm mới!", 8)
                Exit Sub
            End If

            Dim frm As New FrmNewGroupUser
            Dim sSelect As String = frm.ShowDialog(True)

            If sSelect <> "" Then
                cboGroupUser.DataSource = b.getListGroupUser
                cboGroupUser.Value = sSelect
            Else
                cboGroupUser.Value = Nothing
            End If
        End If

    End Sub

    Private Sub cboGroupUser_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboGroupUser.InitializeLayout
        If cboGroupUser.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next

        e.Layout.Bands(0).Columns("s_Group_ID").Hidden = False
        e.Layout.Bands(0).Columns("s_Group_Name").Hidden = False
        If cboGroupUser.Rows.Count > 0 Then
            cboGroupUser.Rows(0).Appearance.BackColor = Color.LightCyan
        End If
    End Sub

    Private Sub cboEmployees_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmployees.Validated
        If cboEmployees.SelectedRow Is Nothing Then
            If cboEmployees.Text <> Nothing Then
                ShowMsg("Nhân viên này không tồn tại", 139)
                cboEmployees.Value = ""
                cboEmployees.Focus()
            End If
        End If
    End Sub
    Private Sub cboEmployees_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmployees.AfterCloseUp
        If cboEmployees.Value Is Nothing Then Exit Sub
        If cboEmployees.Value = "" Then Exit Sub

        If cboEmployees.Value = "-1" Then
            Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 27)
            If Not m.A Then
                ShowMsg("Người dùng không được cấp quyền thêm mới!", 8)
                Exit Sub
            End If

            Dim frm As New FrmNewEmployee
            Dim sSelect As String = frm.ShowDialog(True)

            If sSelect <> "" Then
                cboEmployees.DataSource = b.getListEmployees()
                cboEmployees.Value = sSelect
            Else
                cboEmployees.Value = ""
            End If
        End If
    End Sub

    Private Sub cboEmployees_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboEmployees.InitializeLayout
        If cboEmployees.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next

        e.Layout.Bands(0).Columns("s_Employee_ID").Hidden = False
        e.Layout.Bands(0).Columns("s_Name").Hidden = False
        If cboEmployees.Rows.Count > 0 Then
            cboEmployees.Rows(0).Appearance.BackColor = Color.LightCyan
        End If
    End Sub

    Private Sub LinklblGroupUser_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinklblGroupUser.LinkClicked
        If cboGroupUser.Rows.Count = 0 Then Exit Sub
        Dim frm As New FrmGroupUser
        frm.Toolbars.Visible = False
        frm.ctMenu.Items("T_DEL").Visible = False
        Dim sSelect As String = frm.ShowDialog(True)
        If Not cboGroupUser.IsItemInList() Then
            cboGroupUser.Value = ""
        End If
        If sSelect <> "" Then
            cboGroupUser.DataSource = b.getListGroupUser
            cboGroupUser.Value = sSelect
        End If
    End Sub

    Private Sub LinklblEmployees_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinklblEmployees.LinkClicked
        If cboEmployees.Rows.Count = 0 Then Exit Sub
        Dim frm As New FrmEmployee
        frm.tbManager.Visible = False
        frm.MenuStrip1.Items("T_DEL").Visible = False
        Dim sSelect As String = frm.ShowDialog(True)
        ' LoadCombo()
        If Not cboEmployees.IsItemInList Then
            cboEmployees.Value = ""
        End If
        If sSelect <> "" Then
            Dim DF() As DataRow = CType(cboEmployees.DataSource, DataTable).Select("s_ID='" & sSelect.Replace("'", "''") & "'")
            If DF.Length = 0 Then
                Me.cboEmployees.DataSource = b.getListEmployees()
            End If
            Me.cboEmployees.Value = sSelect
        End If
    End Sub
#End Region

    
End Class