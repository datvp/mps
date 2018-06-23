Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmReport
    Public s_File_Path As String = ""

    Private Sub FrmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me)
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Try
            Dim rp As ReportDocument = rpt.ReportSource
            If rp Is Nothing Then Exit Sub
            Dim sPath As String = rp.FilePath
            Dim p As New Process
            Process.Start(sPath)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rp As ReportDocument = rpt.ReportSource
        If rp Is Nothing Then Exit Sub
        Try
            rp.PrintToPrinter(0, False, 1, 0)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class