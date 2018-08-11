Public Class frmBKData
    Private WithEvents cls As BLL.B_BK_Restore_DB = BLL.B_BK_Restore_DB.Instance
    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub
#Region "From"

    Private Sub frmBKData_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtFileBK.Focus()
    End Sub

    Private Sub frmBKData_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmBKData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnApply)
        ModMain.GreenButton(btnCancel)
        Me.Security()
        UltraGroupBox2.Focus()
        txtFileBK.Focus()
    End Sub

#End Region

#Region "Sub"
    Private f_SecA As Boolean = False
    Private f_SecE As Boolean = False
    Private f_secD As Boolean = False
    Private Sub Security()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 13)
        If Not m.R Then
            ShowMsgInfo("Người dùng không được cấp quyền chạy chức năng này !")
            Me.Close()
            Exit Sub
        End If

        f_SecA = m.A
        f_SecE = m.U
        f_secD = m.D
        If Not f_SecA And Not f_SecE And Not f_secD Then
            Me.btnApply.Enabled = False
        End If
    End Sub
#End Region
#Region "Button "

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If txtFileBK.Text.Trim = "" Then
            ShowMsg("Bạn chưa nhập tên file.")
            txtFileBK.Focus()
            Exit Sub
        End If
        Me.Commit()
    End Sub

    Private Sub Commit()
        ModMain.ShowProcess()

        If cls.BackupDB(ModMain.m_DB, txtFileBK.Text) Then
            ModMain.UpdateEvent(ModMain.m_UIDLogin, "Thực hiện dự phòng dữ liệu.", TypeEvents.System)
            ShowMsgInfo("Đã thực hiện dự phòng dữ liệu!")
        Else
            ShowMsg("Thao tác thực hiện bị lỗi.")
        End If

        ModMain.HideProcess()

    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region

    Private Sub txtFileBK_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles txtFileBK.EditorButtonClick
        Dim frm As New frmDirDevice
        Dim s As String = frm.ShowDialog(0)
        If s <> "" Then
            Me.txtFileBK.Text = s
        End If
    End Sub
End Class