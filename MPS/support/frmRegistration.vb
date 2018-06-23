Public Class frmRegistration
    Dim ok As Boolean = False
    Public Overloads Function ShowDialog(ByVal f As Boolean) As Boolean
        Me.ShowDialog()
        Return ok
    End Function

    Private Sub frmRegistration_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOk.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me)
        txtID.Text = ModMain.m_HDDSerial
        txtGenegateCode.Text = ModMain.m_SerialKey
    End Sub
    Private Function SaveSerialKey() As Boolean
        Try
            Dim key As String = txtGenegateCode.Text
            System.IO.File.WriteAllText(ModMain.m_PathKey, key)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Me.SaveSerialKey() Then
            ModMain.m_SerialKey = txtGenegateCode.Text.Trim
            If ModMain.IsRegistration() Then
                ok = True
                ShowMsgInfo("Kích hoạt thành công!", m_MsgCaption)
                Me.Close()
            Else
                ok = False
                lblSMS.Text = "Serial Key không hợp lệ."
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        ok = False
        Me.Close()
    End Sub

End Class