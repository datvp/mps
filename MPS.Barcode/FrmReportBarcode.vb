Public Class FrmReportBarcode

    Public s_File_Path As String = ""

    Private Sub FrmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = ModMain.m_sysColor
        'Me.Text = Formtitle
        'Me.Icon = My.Resources.VsoftBMS_logo
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Try
            Dim objProcess As Process = New System.Diagnostics.Process()
            objProcess.StartInfo.FileName = s_File_Path
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            objProcess.Start()

            'Wait until the process passes back an exit code 
            objProcess.WaitForExit()

            'Free resources associated with this process
            objProcess.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class