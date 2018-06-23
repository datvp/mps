Public Class frmDashboardDetail
    'Dim b As BLL.BOrder = BLL.BOrder.Instance
    Dim _ngay As Date = CDate("1900-1-1")
    Public Overloads Sub ShowDialog(ByVal ngay As Date)
        _ngay = ngay
        Me.ShowDialog()
    End Sub
    Private Sub frmDashboardDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me)
        If _ngay.Year <> 1900 Then
            grpChart.Text = grpChart.Text & " " & _ngay.ToString("dd/MM/yyyy")
            'Dim tb = b.getTinhHinhKinhDoanhTrongNgay(m_CPUID, _ngay)
            'If tb IsNot Nothing AndAlso tb.Rows.Count >= 9 Then
            '    lblTongSoPhieu.Text = tb.Rows(0)("Des").ToString
            '    lblSoPhieuCuoi.Text = tb.Rows(1)("Des").ToString
            '    lblTongTienBanHang.Text = Format(CDbl(tb.Rows(2)("Des")), m_strFormatCur)
            '    lblTongGiamGia.Text = Format(CDbl(tb.Rows(3)("Des")), m_strFormatCur)
            '    lblTongTienTraHang.Text = Format(CDbl(tb.Rows(4)("Des")), m_strFormatCur)
            '    lblTongTien.Text = Format(CDbl(tb.Rows(5)("Des")), m_strFormatCur)
            '    lblTongThu.Text = Format(CDbl(tb.Rows(6)("Des")), m_strFormatCur)
            '    lblTongCongNo.Text = Format(CDbl(tb.Rows(7)("Des")), m_strFormatCur)
            '    lblTongChi.Text = Format(CDbl(tb.Rows(8)("Des")), m_strFormatCur)
            'End If
        End If
    End Sub
End Class