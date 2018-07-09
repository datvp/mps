Public Class frmNewBranch

    Dim clsu As New VsoftBMS.Ulti.clsUti
    Private WithEvents b As BLL.B_Branchs = BLL.B_Branchs.Instance

    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub

#Region "ShowDialog"
    Private showDAL As Boolean = False
    Private keySelect As String = ""
    Public Overloads Function ShowDialog(ByVal fEdit As Boolean) As String
        showDAL = fEdit
        Me.ShowDialog()
        Return keySelect
    End Function

#End Region

#Region "FORM"
    Private Sub FrmNewBranch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtBranch_ID.Focus()
    End Sub
    Private Sub FrmNewBranch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim m1 As Model.MLs_Branchs = setInfo()
        Dim ask As Boolean = False
        If txtSID.Text <> "" Then
            Dim m2 As Model.MLs_Branchs = b.getInfo(txtSID.Text)
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
                    If Not SAVE() Then
                        e.Cancel = True
                    End If
                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub FrmNewBranch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnSave.PerformClick()
        End If
        If e.KeyCode = Keys.F4 Then
            btnSaveClose.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmNewBranch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, UltraLabel1.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.RedButton(btnSaveClose, ModMain.m_SaveCloseIcon)
        ModMain.GreenButton(btnClose, ModMain.m_CancelIcon)
        If txtIDSort.Text = "0" Then
            If showDAL Then
                btnSaveClose.Visible = False
            End If

        End If
        Security()
    End Sub

#End Region

#Region "SUB"
    Private f_SecE As Boolean = False
    Private f_SecA As Boolean = False
    Private f_SecD As Boolean = False

    Private Sub Security()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 12)

        f_SecE = m.U
        f_SecA = m.A
        f_SecD = m.D
        If Not f_SecA And Not f_SecE Then
            Me.btnSave.Enabled = False
            Me.btnSaveClose.Enabled = False
        End If
    End Sub
    Private Sub ClearInfo()
        txtIDSort.Text = "0"
        txtSID.Text = ""
        txtBranch_ID.Text = ""
        txtName.Text = ""
        txtAddress.Text = ""
        txtPhone.Text = ""
        txtNote.Text = ""

        txtBranch_ID.Focus()
    End Sub
    Public Sub LoadInfo(ByVal SID As String)
        Dim m As Model.MLs_Branchs = b.getInfo(SID)
        If m.s_ID = "" Then Exit Sub

        txtIDSort.Text = m.i_Ordinal
        txtSID.Text = m.s_ID
        Me.txtBranch_ID.Text = m.s_Branch_ID
        txtName.Text = m.s_Name
        txtAddress.Text = m.s_Address
        txtPhone.Text = m.s_Phone
        Me.txtNote.Text = m.s_Note
        btnSaveClose.Visible = False
    End Sub
#End Region

#Region "FUNCTION"
    Private Function compareObjectEdit(ByVal m1 As Model.MLs_Branchs, ByVal m2 As Model.MLs_Branchs) As Boolean
        If Not m2 Is Nothing Then 'Hieu chinh
            'If m1.i_Ordinal <> m2.i_Ordinal Then '2.12.08
            '    Return True
            'End If
            'If m1.s_ID <> m2.s_ID Then
            '    Return True
            'End If
            If m1.s_Branch_ID <> m2.s_Branch_ID Then
                Return True
            End If
            If m1.s_Name <> m2.s_Name Then '9.12.08
                Return True
            End If
            If m1.s_Phone <> m2.s_Phone Then
                Return True
            End If
            If m1.s_Address <> m2.s_Address Then
                Return True
            End If
            If m1.s_Note <> m2.s_Note Then
                Return True
            End If

        Else 'kiem tra moi
            'If m1.s_ID <> "" Then
            '    Return True
            'End If
            If m1.s_Branch_ID <> "" Then '2.12.08
                Return True
            End If
            If m1.s_Name <> "" Then
                Return True
            End If
            If m1.s_Address <> "" Then
                Return True
            End If
            If m1.s_Phone <> "" Then
                Return True
            End If
            If m1.s_Note <> "" Then '9.12.08
                Return True
            End If
        End If
        Return False

    End Function
    Private Function setInfo() As Model.MLs_Branchs
        Dim m As New Model.MLs_Branchs

        ' m.i_Ordinal = CInt(txtIDSort.Text)
        m.s_ID = txtSID.Text
        m.s_Branch_ID = Me.txtBranch_ID.Text.Trim
        m.s_Name = txtName.Text
        m.s_Address = Me.txtAddress.Text.Trim
        m.s_Phone = Me.txtPhone.Text.Trim
        m.s_Note = Me.txtNote.Text

        Return m
    End Function
    Private Function CheckOK() As Boolean
        If txtBranch_ID.Text.Trim = "" Then
            ShowMsg("Nhập mã chi nhánh !", 152)
            txtBranch_ID.Focus()
            Return False
        Else
            If b.CheckDulicate(txtBranch_ID.Text, txtSID.Text) Then
                ShowMsg("Mã chi nhánh đã tồn tại !", 153)
                txtBranch_ID.Focus()
                Return False
            End If
        End If

        If txtName.Text.Trim = "" Then
            ShowMsg("Nhập tên chi nhánh !", 154)
            txtBranch_ID.Focus()
            Return False
        End If

        If txtIDSort.Text = "" Or Not IsNumeric(txtIDSort.Text) Then txtIDSort.Text = "0"
        Return True
    End Function
    Private Function SAVE() As Boolean

        If Not CheckOK() Then
            Exit Function
        End If

        Dim m As Model.MLs_Branchs = Me.setInfo()
        Dim strEvent As String = ""
        If m.s_ID = "" Then 'Them moi
            strEvent = "Thêm mới chi nhánh hàng có mã '" & m.s_Branch_ID & "'"
        Else 'Hieu chinh
            strEvent = "Hiệu chỉnh chi nhánh hàng có mã '" & m.s_Branch_ID & "'"
        End If

        If b.UPDATEDB(m) Then
            ModMain.UpdateEvent(ModMain.m_UIDLogin, strEvent, TypeEvents.List)
            keySelect = m.s_ID
            ' set quyen mac dinh chi nhánh cac chi nhánh hang
            Dim cf As New BLL.BFuncRight
            cf.SetFuncBranch("")
            Return True
        End If

    End Function
#End Region

#Region "BUTTON"
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If SAVE() Then
            If Me.txtIDSort.Text = "0" Then
                ShowMsgInfo(m_MsgSaveSuccess)
                Me.ClearInfo()
                If showDAL Then
                    Me.Close()
                End If

            Else
                ShowMsgInfo(m_MsgSaveSuccess)
                Me.Close()
            End If

        End If
    End Sub
    Private Sub btnSaveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveClose.Click
        If SAVE() Then
            Me.ClearInfo() 'Nếu chi nhánh có thì nó chạy vao FormClosing
            Me.Close()
            ShowMsgInfo(m_MsgSaveSuccess)
        End If
    End Sub


#End Region

#Region "ORDER TAB & FORMAT CONTROL"
    Private Sub txtBranch_ID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBranch_ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtName.Focus()
        End If
    End Sub
    Private Sub txtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAddress.Focus()
        End If
    End Sub
   
    Private Sub txtPhone_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPhone.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNote.Focus()
        End If
    End Sub
#End Region

    Private Sub txtPhone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhone.KeyPress
        Dim k As Short = Asc(e.KeyChar)
        If k <> 13 Then
            clsu.UltraTextBox_KeyPress(k, Me.txtPhone)
            If k = 0 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class