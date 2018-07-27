Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinGrid
Imports System.IO
Public Class frmTotalReports
    Private WithEvents cls As BLL.B_Report = BLL.B_Report.Instance
    Dim b As BLL.BPublic = BLL.BPublic.Instance

    Private Sub GetListReports()
        lstFunc.DisplayMember = "Name"
        lstFunc.ValueMember = "ID"

        Dim tb As DataTable = b.getListReports()
        If Not IsNothing(tb) Then
            lstFunc.DataSource = tb
        End If
    End Sub
    Private Sub ViewCrystalReport()
        If lstFunc.SelectedValue Is Nothing Then Exit Sub
        Dim rp As New ReportDocument
        Dim clsrpt As New ClsReport
        Dim s_FileReport As String = ""
        Dim tb = lstFunc.DataSource
        Dim DF() As DataRow = tb.Select("ID=" & lstFunc.SelectedValue)
        If DF.Length > 0 Then
            s_FileReport = IsNull(DF(0)("PathFile"), "")
        End If

        Select Case lstFunc.SelectedValue
            Case 3015 'stock account
                'Dim ok = cls.rptStockAccount(ModMain.m_CPUID, dtFrom.Value, dtTo.Value)
                'If Not ok Then
                '    Exit Sub
                'End If
                'rp = clsrpt.InitReport(Application.StartupPath & s_FileReport)
                'clsrpt.SetParameter(rp, m_CPUID, Format(dtFrom.Value, "yyyy-MM-dd"), Format(dtTo.Value, "yyyy-MM-dd"), mbc.i_FormatNum)
            Case 1001 'thẻ kho
                'tb = cls.rptStoreCard(m_CPUID, Store_ID, cmbProduct.Value, dtFrom.Value, dtTo.Value, cmbUnitExt.ActiveRow.Cells("Exchange").Value, cmbUnitExt.ActiveRow.Cells("s_Unit").Value, branchId)

                'rp = clsrpt.InitReport(Application.StartupPath & s_FileReport)
                'clsrpt.SetParameter(rp, Format(dtFrom.Value, "yyyy-MM-dd"), Format(dtTo.Value, "yyyy-MM-dd"), _
                '                    proName, proID, m_CPUID, mbc.i_FormatNum, mbc.i_FormatCur, branchName)

        End Select

        Try
            Dim frm As New FrmReport
            frm.rpt.ReportSource = rp
            frm.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmTotalReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnView, ModMain.m_OkIcon)
        ModMain.GreenButton(btnExportExcel)
        Me.GetListReports()
    End Sub

    Private Sub Grid_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid.InitializeLayout

    End Sub

    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        ShowMsg(messege)
    End Sub
End Class