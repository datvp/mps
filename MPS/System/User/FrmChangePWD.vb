Public Class FrmChangePWD
    Private s_UID As String = ""
    Private WithEvents cls As New BLL.BSecUser

    Sub New(ByVal UID As String)
        Me.InitializeComponent()
        s_UID = UID
    End Sub
    Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub

    Private Sub FrmChangePWD_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtUID.Focus()
    End Sub

    Private Sub FrmChangePWD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        'sua ngay 27/03/2009
        If e.KeyCode = Keys.F2 Then btnSave.PerformClick()
    End Sub

    Private Sub FrmChangePWD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, UltraLabel1.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveCloseIcon)
        ModMain.RedButton(btnReset)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)

        If m_UIDLogin.Trim.ToLower = "admin" Then
            Me.btnReset.Visible = True
            txtUID.ReadOnly = False
        Else
            Me.btnReset.Visible = False
        End If
        txtUID.Text = s_UID
        UltraGroupBox2.Focus()
        txtUID.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtUID.Text = "" Then
            ShowMsg("Không có thông tin người dùng !", 114)
            Exit Sub
        End If
        Dim m As Model.MSecUser = cls.getInfo(txtUID.Text)
        If m.IDSort = 0 Then
            ShowMsg("Thông tin người dùng không chính xác !", 1251)
            Exit Sub
        End If
        If Helper.Encrypt(txtPWDOld.Text) <> m.PWD Then
            ShowMsg("Mật khẩu cũ không chính xác!", 1252)
            txtPWDOld.Focus()
            Exit Sub
        End If
        If txtPWD.Text <> txtConfirm.Text Then
            ShowMsg("Mật khẩu xác nhận không chính xác!", 141)
            txtConfirm.Focus()
            Exit Sub
        End If

        If cls.ChangePWD(txtUID.Text, Helper.Encrypt(txtPWD.Text.Trim)) Then
            ModMain.UpdateEvent(ModMain.m_UIDLogin, "Người dùng " & txtUID.Text & " thay đổi password.", TypeEvents.System)
            Me.Close()
        End If
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Dim clsL As BLL.BLogin = BLL.BLogin.Instance
        Dim tb As DataTable = clsL.getUser(Me.txtUID.Text)
        If tb.Rows.Count = 0 Then
            ShowMsg("Tên đăng nhập không hợp lệ !", 101)
            Exit Sub
        End If

        If ShowMsgYesNoCancel("Bạn có thật sự muốn reset lại mật khẩu người dùng : " & txtUID.Text & "?", 118) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
        End If
        Dim sP = InputBox("Nhập mật khẩu mới", "Nhap lai mat khau", "1")
        If sP Is Nothing OrElse sP = "" Then
            Exit Sub
        End If

        If cls.ChangePWD(txtUID.Text, Helper.Encrypt(sP)) Then
            ShowMsgInfo("Mật khẩu đã được Reset !", 121)
            Me.Close()
        End If
    End Sub

    Private Sub txtUID_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUID.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPWDOld.Focus()
        End If
    End Sub

    Private Sub txtPWDOld_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPWDOld.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPWD.Focus()
        End If
    End Sub

    Private Sub txtPWD_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPWD.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtConfirm.Focus()
        End If
    End Sub

    Private Sub txtConfirm_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConfirm.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
End Class