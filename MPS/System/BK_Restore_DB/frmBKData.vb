Public Class frmBKData
    Private WithEvents cls As New BLL.B_BK_Restore_DB
    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub
    Private frmPro As New FrmProcess
    Private thread As Threading.Thread
    Private Sub ShowProgress(ByVal strTitle As String)
        If frmPro Is Nothing Then frmPro = New FrmProcess
        frmPro.Owner = Me
        frmPro.StartPosition = FormStartPosition.CenterScreen
        frmPro.Title = strTitle
        frmPro.Show()
        frmPro.Refresh()
    End Sub
    Private Sub ProgressRefresh()
        Try
            While Not thread Is Nothing AndAlso thread.ThreadState = Threading.ThreadState.Running
                If Not frmPro Is Nothing Then
                    frmPro.Refresh()
                    Threading.Thread.Sleep(200)
                End If
            End While
        Catch ex As Exception

        End Try
    End Sub
#Region "From"

    Private Sub frmBKData_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtFileBK.Focus()
    End Sub

    Private Sub frmBKData_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.Control Then
            If e.KeyCode = Keys.L Then
                FormatLang()
            End If
        End If
    End Sub

    Private Sub frmBKData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, UltraLabel1.Text)
        ModMain.BlueButton(btnApply)
        ModMain.GreenButton(btnCancel)
        Me.Security()
        UltraGroupBox2.Focus()
        txtFileBK.Focus()
        If m_Lang <> 1 Then
            LoadLang(m_Lang)
        End If
    End Sub

#End Region

#Region "Sub"
    Private f_SecA As Boolean = False
    Private f_SecE As Boolean = False
    Private f_secD As Boolean = False
    Private Sub Security()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 45)
        If Not m.R Then
            ' ShowMsg(m_MsgNotPermitUseThisFun, m_MsgCaption)
            ShowMsgInfoMultiLang("Người dùng không được cấp quyền chạy chức năng này !", 43)
            Me.Close()
            Exit Sub
        End If

        'f_SecA = m.A
        'f_SecE = m.U
        'f_secD = m.D
        'If Not f_SecA And Not f_SecE And Not f_secD Then
        '    Me.btnApply.Enabled = False
        'End If
    End Sub

    Private Sub LoadLang(ByVal lang As Integer)
        clsLang.FormatLang(lang, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Me)
    End Sub

    Private Sub FormatLang()
      
    End Sub
#End Region
#Region "Button "

    Private Sub btnBrown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrown.Click
        Dim frm As New frmDirDevice
        Dim s As String = frm.ShowDialog(0)
        If s <> "" Then
            Me.txtFileBK.Text = s
        End If
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If txtFileBK.Text = "" Then
            'ShowMsg("Chọn file dữ liệu backup")
            ShowMsgMultiLang("Chọn file dữ liệu backup", 49)
            Exit Sub
        End If
        Commit()
    End Sub

    Private Sub Commit()
        ShowProgress(TextMultiLang(m_Lang, "Đang thực hiện ...", 50))
        thread = New Threading.Thread(AddressOf ProgressRefresh)
        thread.Start()
        If cls.BackupDB(ModMain.m_DB, txtFileBK.Text) Then
            If m_Lang = 1 Then
                ModMain.UpdateEvent(ModMain.m_UIDLogin, "Thực hiện dự phòng dữ liệu.", TypeEvents.System)
            Else
                ModMain.UpdateEvent(ModMain.m_UIDLogin, TextMultiLang(m_Lang, "Thực hiện dự phòng dữ liệu.", 51), TypeEvents.System)
            End If

            ShowMsgInfoMultiLang("Đã thực hiện dự phòng dữ liệu!", 52)
            m_isBackupDB = True
        Else

            ShowMsgMultiLang("Thao tác thực hiện bị lỗi, xin vui lòng gọi tới số :08-38623060 để chúng tôi hổ trợ bạn !", 53)
        End If
        If Not frmPro Is Nothing Then frmPro.Close()
        frmPro = Nothing
        If Not thread Is Nothing Then
            thread.Abort()
            thread = Nothing
        End If

    End Sub
    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region

End Class