Public Class frmConfirm
    Private b As BLL.BLogin = BLL.BLogin.Instance
    Dim clsU As New VsoftBMS.Ulti.ClsUti
    Dim fOK As Boolean = False
    Public Overloads Function ShowDialog(ByVal userLogin As String) As Boolean
        txtUser.Text = userLogin
        Me.ShowDialog()
        Return fOK
    End Function

    Dim i As Integer = 0
    Private Sub Confirm()
        Dim tb As DataTable = b.getUser(txtUser.Text.Trim)
        If tb Is Nothing Then
            Exit Sub
        ElseIf tb.Rows.Count = 0 Then
            Exit Sub
        Else
            Dim sPWD As String = txtPass.Text
            sPWD = clsU.Encrypt(sPWD)
            If tb.Rows(0)("s_PWD") = sPWD Then
                fOK = True
                Me.Close()
            Else
                ShowMsg("Mật khẩu không đúng!", "")
                txtPass.Focus()
                i += 1
                If i = 3 Then
                    Me.Close()
                End If
            End If
            txtPass.SelectAll()
        End If
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Confirm()
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmConfirm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Confirm()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmPWDSystem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me)
        ModMain.BlueButton(btnOK, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        Me.txtUser.Select()
    End Sub

End Class