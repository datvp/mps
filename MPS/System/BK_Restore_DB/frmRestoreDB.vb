Public Class frmRestoreDB
    Private WithEvents cls As BLL.B_BK_Restore_DB = BLL.B_BK_Restore_DB.Instance
    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub

#Region "From "

    Private Sub frmRestoreDB_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmRestoreDB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me, UltraLabel1.Text)
        ModMain.BlueButton(btnApply)
        ModMain.GreenButton(btnCancel)
        Me.Security()
    End Sub

#End Region

#Region "Sub"
    Private f_SecA As Boolean = False
    Private f_SecE As Boolean = False
    Private f_secD As Boolean = False
    Private Sub Security()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 14)
        If Not m.R Then
            ShowMsg(m_MsgNotPermitUseThisFun, m_MsgCaption)
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
#End Region
#Region "Choose "

    Private Sub btnBrown1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrown1.Click
        Dim frm As New frmDirDevice
        Dim s As String = frm.ShowDialog(0)
        If s <> "" Then
            Me.txtFileBK.Text = s
        End If
    End Sub

    Private Sub btnBrown2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrown2.Click
        Dim frm As New frmDirDevice
        Dim s As String = frm.ShowDialog(1)
        If s <> "" Then
            Me.txtdirData.Text = s
        End If
    End Sub

#End Region

#Region "Button"

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If Me.RBK.Checked Then
            If txtdirData.Text = "" Then
                ShowMsg("Chọn thư mục chứa dữ liệu", 58)
                Exit Sub
            End If
        End If

        If txtFileBK.Text = "" Then
            ShowMsg("Chọn file dữ liệu backup", 49)
            Exit Sub
        End If
        If ShowMsgYesNo("Có thật sự phục hồi dữ liệu ?", 59) <> MsgBoxResult.Yes Then Exit Sub
        Dim sData As String = txtdirData.Text & "\" & ModMain.m_DB & ".mdf"
        Dim sLog As String = txtdirData.Text & "\" & ModMain.m_DB & "_LOG.ldf"
        sData = sData.Replace("\\", "\")
        sLog = sLog.Replace("\\", "\")
        If Me.RBK.Checked Then
            CommitRestore(sData, sLog)
        Else
            If cls.AttachDB(txtFileBK.Text) Then
                ModMain.UpdateEvent(ModMain.m_UIDLogin, "Thực hiện phục hồi dữ liệu ngày " & Format(Now, "dd/MM/yyyy"), TypeEvents.System)
                ShowMsgInfo("Dữ liệu đã được phục hồi !", 56)
            Else
                ShowMsg("Không thực hiện phục hồi được, xin vui lòng gọi tới số :0903.721.721 để chúng tôi hỗ trợ bạn !", 57)
            End If
        End If

    End Sub

    


    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region
    Private Sub CommitRestore(ByVal sData As String, ByVal sLog As String)
        ModMain.ShowProcess()
        If cls.RestoreDB("MPS", ModMain.m_DB, txtFileBK.Text, sData, sLog) Then
            ModMain.UpdateEvent(ModMain.m_UIDLogin, "Thực hiện phục hồi dữ liệu ngày " & Format(Now, "dd/MM/yyyy"), TypeEvents.System)
            ShowMsgInfo("Dữ liệu đã được phục hồi !")
        Else
            ShowMsg("Không thực hiện phục hồi được.")
        End If

        ModMain.HideProcess()
    End Sub

    Private Sub RBK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBK.CheckedChanged
        txtdirData.Enabled = RBK.Checked
        btnBrown2.Enabled = RBK.Checked
    End Sub
End Class