Imports Infragistics.Win.UltraWinGrid.ExcelExport

Public Class frmDashboard
    Dim clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Dim b As BLL.BPublic = BLL.BPublic.Instance

    Private Sub frmDashboard_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F5 Then
            LoadChart()
        End If
    End Sub

    Private Sub frmDashboard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me, "Dashboard")
        LoadChart()
    End Sub
    Public Sub LoadChart()
        Me.Cursor = Cursors.WaitCursor

        'Tổng doanh thu theo mốc thời gian
        Dim tb = b.getChartByItem()
        ChartByItem.Data.DataSource = tb
        ChartByItem.Data.DataBind()

        ChartBySubContractor.Data.DataSource = tb
        ChartBySubContractor.Data.DataBind()

        'doanh thu theo nhóm kh
        ChartByClientGroup.Data.DataSource = b.getChartByClientGroup()
        ChartByClientGroup.Data.DataBind()

        'doanh thu theo dự án
        ChartByProject.Data.DataSource = b.getChartByProject()
        ChartByProject.Data.DataBind()

        'Tổng hợp các Hợp đồng sắp hết hạn
        GridProduct.DataSource = b.getListDeadlineContracts(90) ' trong 90 ngày

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TotalSaleChart_ChartDataClicked(ByVal sender As System.Object, ByVal e As Infragistics.UltraChart.Shared.Events.ChartDataEventArgs) Handles ChartByItem.ChartDataClicked
        'Dim val = e.DataValue
        'Dim ngay = e.RowLabel
        'Dim dtDate = CDate(Now.Year.ToString & "-" & Now.Month.ToString & "-" & ngay)
        'Dim frm As New frmDashboardDetail
        'frm.ShowDialog(dtDate)
        'ShowMsg(val.ToString())
        'ModMain.ChartToExcel(TotalSaleChart)
    End Sub
    Dim fGrid As Boolean = False
    Private Sub GridProduct_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridProduct.InitializeLayout
        If fGrid Then Exit Sub
        fGrid = True
        clsuf.FormatGridFromDB(Me.Name, GridProduct, m_Lang)
        GridProduct.DisplayLayout.Override.RowAppearance.BorderColor = Color.White
        GridProduct.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White
    End Sub

    Private Sub GridProduct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridProduct.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, GridProduct, m_Lang)
                frm.ShowDialog()
            End If
        End If
    End Sub
End Class