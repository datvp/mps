Public Class frmFlash
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

    Private Sub frmFlash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me)
        lblVersion.Text = "v." + m_Version
        Timer1.Interval = 3000
        Timer1.Start()
    End Sub
End Class