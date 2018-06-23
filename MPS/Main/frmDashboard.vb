Imports Infragistics.Win.UltraWinGrid.ExcelExport

Public Class frmDashboard
    Dim clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
#Region "SUB NEW"
    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Shared obj As frmDashboard
    Public Shared ReadOnly Property Instance() As frmDashboard
        Get
            If obj Is Nothing Then
                obj = New frmDashboard
            End If
            Return obj
        End Get
    End Property
#End Region
    Private Sub frmDashboard_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F5 Then
            LoadChart()
        End If
    End Sub

    Private Sub frmDashboard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me, "Tình hình kinh doanh tổng quan")
        grpTotalSaleChart.Text += " tháng " & Now.ToString("MM/yyyy")
        LoadChart()
    End Sub
    Public Sub LoadChart()
        'Dim tb = b.getChart_TotalSale(Now)
        'TotalSaleChart.Data.DataSource = tb
        'TotalSaleChart.Data.DataBind()

        'HourSaleChart.Data.DataSource = b.getChart_HourSale()
        'HourSaleChart.Data.DataBind()

        'GroupItemSaleChart.Data.DataSource = b.getChart_ProductGroup()
        'GroupItemSaleChart.Data.DataBind()

        'Dim gtban = b.getGiaTriBan() ' ĐÃ CÓ GIẢM GIÁ
        'Dim slg = b.getSoHoaDon()
        'Dim giamgia = b.getGiamGia()
        'Dim giavon = b.getGiaVonHangBan()
        'lblGiaTriBan.Text = Format(gtban + giamgia, ModMain.m_strFormatCur)
        'lblSoHoaDon.Text = slg
        'lblGiamGia.Text = Format(giamgia, ModMain.m_strFormatCur)
        'lblPhaiThu.Text = Format(gtban, ModMain.m_strFormatCur)
        'lblDoanhSo.Text = lblPhaiThu.Text
        'lblGiaVon.Text = Format(giavon, ModMain.m_strFormatCur)
        'lblTienThuVe.Text = lblDoanhSo.Text
        'lblLoiNhuan.Text = Format(gtban - giavon, ModMain.m_strFormatCur)

        ''mua - bán trong ngày
        'GridProduct.DataSource = b.getListItemSaleByDate(Now)
        'If GridProduct.DataSource IsNot Nothing Then
        '    For Each r In GridProduct.Rows
        '        Dim mnv = r.Cells("MaNghiepVu").Value
        '        If mnv.Equals("<--") Then
        '            r.CellAppearance.ForeColor = Color.Red
        '        Else
        '            r.CellAppearance.ForeColor = Color.Blue
        '        End If
        '    Next
        'End If
    End Sub

    Private Sub TotalSaleChart_ChartDataClicked(ByVal sender As System.Object, ByVal e As Infragistics.UltraChart.Shared.Events.ChartDataEventArgs) Handles TotalSaleChart.ChartDataClicked
        Dim val = e.DataValue
        Dim ngay = e.RowLabel
        Dim dtDate = CDate(Now.Year.ToString & "-" & Now.Month.ToString & "-" & ngay)
        Dim frm As New frmDashboardDetail
        frm.ShowDialog(dtDate)
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