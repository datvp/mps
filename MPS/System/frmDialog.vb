Public Class frmDialog
    Public Overloads Sub showDialog(ByVal sms As String, ByVal err As String, Optional ByVal caption As String = "")
        lblMsg.Text = sms
        lblErr.Text = err
        Me.Text = caption
        Me.ShowDialog()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        If Me.Height = 252 Then
            Me.Height = 139
            btnDetail.Text = "Chi tiết>>"
        Else
            Me.Height = 252
            btnDetail.Text = "<<Chi tiết"
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class