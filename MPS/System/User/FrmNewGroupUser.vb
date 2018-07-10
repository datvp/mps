Public Class FrmNewGroupUser
    Dim clsu As New VsoftBMS.Ulti.clsUti
    Private WithEvents b As New BLL.BGroupUser


#Region "Form "
    Dim SID As String = ""
    Private fEdit As Boolean = False
    Private sSelect As String = ""

    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub

    Public Overloads Function ShowDialog(ByVal f As Boolean) As String
        fEdit = f
        Me.ShowDialog()
        Return sSelect
    End Function

    Private Sub FrmNewGroupUser_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtSID.Focus()
    End Sub

    Private Sub FrmNewGroupUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim m1 As Model.MLS_GroupUser = Setinfo()
        Dim ask As Boolean = False
        If txtSID.Text <> "" Then
            Dim m2 As Model.MLS_GroupUser = b.getInfo(SID)
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
                    If Not SAVE() Then
                        e.Cancel = True
                    End If
                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub FrmNewGroupUser_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F2 Then
            Me.btnSave.PerformClick()
        End If

        If e.KeyCode = Keys.F4 Then
            btnSaveClose.PerformClick()
        End If
    End Sub

    Private Sub FrmNewGroupUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me, UltraLabel1.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.RedButton(btnSaveClose, ModMain.m_SaveCloseIcon)
        ModMain.GreenButton(btnClose, ModMain.m_CancelIcon)

        If SID = "" Then
            txtOrderNo.Text = b.GetMaxOrdinal() + 1
        End If
    End Sub

#End Region

#Region "Sub "
    'kiểm tra thông tin trước khi đóng
    Private Function compareObjectEdit(ByVal m1 As Model.MLS_GroupUser, ByVal m2 As Model.MLS_GroupUser) As Boolean
        If Not m2 Is Nothing Then 'Hieu chinh
            If m1.s_Group_ID <> m2.s_Group_ID Then
                Return True
            End If
            If m1.s_Group_Name <> m2.s_Group_Name Then
                Return True
            End If
            If m1.s_note <> m2.s_note Then
                Return True
            End If
        Else 'kiem tra moi
            If m1.s_Group_ID <> "" Then
                Return True
            End If
            If m1.s_Group_Name <> "" Then
                Return True
            End If
            If m1.s_note.Trim <> "" Then
                Return True
            End If
        End If

        Return False
    End Function

    Private Function Setinfo() As Model.MLS_GroupUser
        Dim m As New Model.MLS_GroupUser
        m.s_ID = SID
        m.s_Group_ID = txtSID.Text
        m.s_Group_Name = txtName.Text
        m.s_note = txtNote.Text
        m.i_Ordinal = IIf(txtOrderNo.Text.Trim = "", 0, txtOrderNo.Text)
        Return m
    End Function
    Private Sub ClearInfo()
        Me.SID = ""
        Me.txtSID.Text = ""
        Me.txtOrderNo.Text = ""
        Me.txtName.Text = ""
        Me.txtNote.Text = ""
        Me.txtSID.Focus()
        txtOrderNo.Text = b.GetMaxOrdinal() + 1
    End Sub

    Public Sub Loadinfo(ByVal id As String)
        Dim m As Model.MLS_GroupUser = b.getInfo(id)
        SID = id
        txtSID.Text = m.s_Group_ID
        txtName.Text = m.s_Group_Name
        txtNote.Text = m.s_note
        txtOrderNo.Text = m.i_Ordinal
       
        Me.btnSaveClose.Visible = False '02.10.08
    End Sub

    Private Function CheckOK() As Boolean
        If txtSID.Text.Trim = "" Then
            ShowMsg("Nhập mã nhóm người dùng !", 126)
            txtSID.Focus()
            Return False
        Else
            If b.CheckDulicate(txtSID.Text, Me.SID) Then
                ShowMsg("Mã nhóm người dùng đã tồn tại!", 127)
                txtSID.Focus()
                Return False
            End If
        End If

        If txtName.Text.Trim = "" Then
            ShowMsg("Nhập tên nhóm người dùng !", 128)
            txtName.Focus()
            Return False
        Else
            If b.CheckDulicateName(txtName.Text, Me.SID) Then
                ShowMsg("Tên nhóm người dùng đã tồn tại!", 129)
                txtName.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Function SAVE() As Boolean
        If Not CheckOK() Then Exit Function
        Dim m As Model.MLS_GroupUser = Me.Setinfo()
        Dim strEvent As String = ""
        If m.s_ID = "" Then
            strEvent = "Thêm mới nhóm người dùng có mã " & m.s_Group_ID
        Else
            strEvent = "Hiệu chỉnh nhóm người dùng có mã " & m.s_Group_ID
        End If
        If b.UPDATEDB(m) Then
            ModMain.UpdateEvent(ModMain.m_UIDLogin, strEvent, TypeEvents.System)
            sSelect = m.s_ID
            Return True
        Else
            ShowMsg(m_SaveDataError, m_MsgCaption)
            Return False
        End If
    End Function
#End Region

#Region "Button "

    Private Sub btnSaveClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveClose.Click
        If SAVE() Then
            ShowMsgInfo(m_MsgSaveSuccess, m_MsgCaption)
            Me.ClearInfo()
            Me.Close()
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If SAVE() Then
            ShowMsgInfo(m_MsgSaveSuccess, m_MsgCaption)
            Me.ClearInfo()
            If fEdit Then
                Me.Close()
            End If
        End If
    End Sub
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region

#Region "Text"
    Private Sub txtSID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSID.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOrderNo.Focus()
        End If
    End Sub
    Private Sub txtOrderNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrderNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtName.Focus()
        End If
    End Sub

    Private Sub txtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNote.Focus()
        End If
    End Sub
    'Private Sub txtNote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNote.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        btnSave.Focus()
    '    End If
    'End Sub


    Private Sub txtOrderNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrderNo.KeyPress
        Dim k As Short = Asc(e.KeyChar)
        If k <> 13 Then
            clsu.UltraTextBox_KeyPress(k, Me.txtOrderNo)
            If k = 0 Then
                e.Handled = True
            End If
        End If
    End Sub

#End Region

End Class