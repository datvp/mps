Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinGrid
Imports System.IO
Imports Infragistics.Win

Public Class frmTotalReports
    Private WithEvents cls As BLL.B_Report = BLL.B_Report.Instance
    Private b As BLL.BPublic = BLL.BPublic.Instance
    Private clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Private bc As BLL.BContracts = BLL.BContracts.Instance
    Private bs As BLL.BSubContractors = BLL.BSubContractors.Instance
    Private tbContractId As DataTable = Nothing
    Private tbSubContractors As DataTable = Nothing
    Private rp As New ReportDocument
    Private clsrpt As New ClsReport

    Private Sub LoadSubContractors()
        If tbSubContractors Is Nothing Then tbSubContractors = bs.getListSubContractors()
        cboBranch.DisplayMember = "SubContractorName"
        cboBranch.ValueMember = "SubContractorId"
        cboBranch.DataSource = tbSubContractors
    End Sub
    Private Sub LoadContracts()
        If tbContractId Is Nothing Then tbContractId = bc.getListAllContractId(ModMain.m_BranchId)
        cboBranch.DisplayMember = "ContractId"
        cboBranch.ValueMember = "ContractId"
        cboBranch.DataSource = tbContractId
    End Sub
    Private Sub GetListReports()
        lstFunc.DisplayMember = "Name"
        lstFunc.ValueMember = "ID"
        lstFunc.DataSource = b.getListReports()
    End Sub
    Private Sub ViewData()
        Try
            If lstFunc.SelectedValue Is Nothing Then Exit Sub
            ModMain.ShowProcess()
            Select Case lstFunc.SelectedValue
                Case 4 'theo nhóm KH
                    fByClientGroup = False
                    Grid.DataSource = cls.RevenueByClientGroup(dtFrom.Value, dtTo.Value)
                Case 6 'theo project
                    fByProject = False
                    Grid.DataSource = cls.RevenueByProject(dtFrom.Value, dtTo.Value)
                Case 7 'theo thời gian
                    fByYear = False
                    Grid.DataSource = cls.RevenueByYear()
                Case 9 'theo hạng mục
                    fByItem = False
                    Grid.DataSource = cls.RevenueByItem(dtFrom.Value, dtTo.Value)
                Case 12 ' Tổng số Nhà thầu phụ đang được thuê
                    fByAssigned = False
                    Grid.DataSource = cls.ReportSubContractorsByAssigned(dtFrom.Value, dtTo.Value)
                Case 13 ' Số lượng dự án mà 01 nhà thầu phụ đang thực hiện
                    If cboBranch.Value Is Nothing Then
                        ShowMsg("Bạn chưa chọn nhà thầu.")
                        cboBranch.Focus()
                        Exit Select
                    End If
                    fBySubContractorId = False
                    Grid.DataSource = cls.ReportContractsBySubContractorId(cboBranch.Value)
                Case 15 ' báo cáo tình trạng của 1 hợp đồng
                    If cboBranch.Value Is Nothing Then
                        ShowMsg("Bạn chưa chọn hợp đồng.")
                        cboBranch.Focus()
                        Exit Select
                    End If
                    Grid.DataSource = Nothing
                    Dim contractId As String = cboBranch.Value
                    Dim tb = lstFunc.DataSource
                    Dim DF() As DataRow = tb.Select("ID=15")
                    Dim pathReport = ""
                    If DF.Length > 0 Then
                        pathReport = IsNull(DF(0)("PathFile"), "")
                    End If
                    If pathReport = "" Then Exit Select
                    rp = clsrpt.InitReport(Application.StartupPath & pathReport)
                    clsrpt.SetParameter(rp, contractId)
                    Dim frm As New FrmReport
                    frm.rpt.ReportSource = rp
                    frm.Show()
                Case 16 'Báo cáo Tình trạng nhiều hợp đồng
                    fByStatusContracts = False
                    Grid.DataSource = cls.ReportStatusOfContracts(dtFrom.Value, dtTo.Value)
            End Select
        Catch ex As Exception
            ShowMsg(ex.Message)
        Finally
            ModMain.HideProcess()
        End Try
    End Sub

    Private Sub frmTotalReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnView, ModMain.m_OkIcon)
        Me.GetListReports()
        cboTime.SelectedIndex = 0
    End Sub
    Dim fByClientGroup, fByProject, fByItem, fByAssigned, fBySubContractorId, fByStatusContracts, fByYear As Boolean
    Private Sub Grid_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid.InitializeLayout
        Grid.DisplayLayout.Bands(0).Columns(0).MergedCellEvaluationType = MergedCellEvaluationType.MergeSameText
        Grid.DisplayLayout.Bands(0).Columns(0).MergedCellStyle = MergedCellStyle.Always

        Select Case lstFunc.SelectedValue
            Case 4 ' theo nhóm kh
                If fByClientGroup Then Exit Sub
                fByClientGroup = True
                clsuf.FormatGridFromDB(Me.Name + "ByClientGroup", Grid, m_Lang)
            Case 6 ' theo dự án công trình
                If fByProject Then Exit Sub
                fByProject = True
                clsuf.FormatGridFromDB(Me.Name + "ByProject", Grid, m_Lang)
            Case 7 ' theo thời gian
                If fByYear Then Exit Sub
                fByYear = True
                clsuf.FormatGridFromDB(Me.Name + "ByYear", Grid, m_Lang)
            Case 9 ' theo hạng mục
                If fByItem Then Exit Sub
                fByItem = True
                clsuf.FormatGridFromDB(Me.Name + "ByItem", Grid, m_Lang)
            Case 12 ' Tổng số Nhà thầu phụ đang được thuê
                If fByAssigned Then Exit Sub
                fByAssigned = True
                clsuf.FormatGridFromDB(Me.Name + "ByAssigned", Grid, m_Lang)
            Case 13 ' Số lượng dự án mà 01 nhà thầu phụ đang thực hiện
                If fBySubContractorId Then Exit Sub
                fBySubContractorId = True
                clsuf.FormatGridFromDB(Me.Name + "BySubContractorId", Grid, m_Lang)
            Case 16 'Báo cáo Tình trạng nhiều hợp đồng
                If fByStatusContracts Then Exit Sub
                fByStatusContracts = True
                clsuf.FormatGridFromDB(Me.Name + "ByStatusContracts", Grid, m_Lang)
        End Select

    End Sub

    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        ShowMsg(messege)
    End Sub

    Private Sub Grid_InitializePrintPreview(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintPreviewEventArgs) Handles Grid.InitializePrintPreview
        e.PrintDocument.DefaultPageSettings.Landscape = True
        ' Set the zomm level to 100 % in the print preview.
        e.PrintPreviewSettings.Zoom = 1.0

        ' Set the location and size of the print preview dialog.
        e.PrintPreviewSettings.DialogLeft = SystemInformation.WorkingArea.X
        e.PrintPreviewSettings.DialogTop = SystemInformation.WorkingArea.Y
        e.PrintPreviewSettings.DialogWidth = SystemInformation.WorkingArea.Width
        e.PrintPreviewSettings.DialogHeight = SystemInformation.WorkingArea.Height

        ' Horizontally fit everything in a signle page.
        e.DefaultLogicalPageLayoutInfo.FitWidthToPages = 1

        Dim title = lstFunc.Text
        If lstFunc.SelectedValue = 7 Then ' theo thời gian
        Else
            title += vbCrLf & "Từ: " & dtFrom.Value.ToString("dd/MM/yyyy") & " đến: " & dtTo.Value.ToString("dd/MM/yyyy")
        End If
        ' Set up the header and the footer.
        e.DefaultLogicalPageLayoutInfo.PageHeader = title
        e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 80
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.Bold = DefaultableBoolean.True
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = HAlign.Center
        e.DefaultLogicalPageLayoutInfo.PageHeaderBorderStyle = UIElementBorderStyle.Solid

        ' Use <#> token in the string to designate page numbers.
        e.DefaultLogicalPageLayoutInfo.PageFooter = "Page <#>."
        e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = HAlign.Right
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.FontData.Italic = DefaultableBoolean.True
        e.DefaultLogicalPageLayoutInfo.PageFooterBorderStyle = UIElementBorderStyle.Solid

        ' Set the ClippingOverride to Yes.
        e.DefaultLogicalPageLayoutInfo.ClippingOverride = ClippingOverride.Yes

        ' Set the document name through the PrintDocument which returns a PrintDocument object.
        e.PrintDocument.DocumentName = "Document Name"
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Select Case lstFunc.SelectedValue
                    Case 4 ' theo nhóm kh
                        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name + "ByClientGroup", Grid, m_Lang)
                        frm.ShowDialog()
                    Case 6 ' theo dự án công trình
                        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name + "ByProject", Grid, m_Lang)
                        frm.ShowDialog()
                    Case 7 ' theo thời gian
                        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name + "ByYear", Grid, m_Lang)
                        frm.ShowDialog()
                    Case 9 ' theo hạng mục
                        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name + "ByItem", Grid, m_Lang)
                        frm.ShowDialog()
                    Case 12 ' Tổng số Nhà thầu phụ đang được thuê
                        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name + "ByAssigned", Grid, m_Lang)
                        frm.ShowDialog()
                    Case 13 ' Số lượng dự án mà 01 nhà thầu phụ đang thực hiện
                        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name + "BySubContractorId", Grid, m_Lang)
                        frm.ShowDialog()
                    Case 16 'Báo cáo Tình trạng nhiều hợp đồng
                        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name + "ByStatusContracts", Grid, m_Lang)
                        frm.ShowDialog()
                End Select

            End If
        End If

    End Sub

    Private Sub Grid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grid.MouseDown
        T_ExportExcel.Enabled = True
        T_Print.Enabled = True

        Dim r As UltraGridRow = Grid.ActiveRow

        Dim element As Infragistics.Win.UIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(New Point(e.X, e.Y))
        If element Is Nothing Then Exit Sub
        Dim result As UltraGridRow = element.GetContext(GetType(UltraGridRow))
        If result Is Nothing OrElse result.Index = -1 Then
            T_ExportExcel.Enabled = False
            T_Print.Enabled = False
        Else
            If Not result.IsDataRow Then
                Exit Sub
            End If
            result.Activated = True
            r = result
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ctMenu.Show(Grid, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub T_ExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_ExportExcel.Click
        ModMain.ExportExcel(Grid)
    End Sub

    Private Sub T_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Print.Click
        Grid.PrintPreview()
    End Sub

    Private Sub cboTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTime.SelectedIndexChanged
        ModMain.SetTime(cboTime.SelectedIndex, dtFrom, dtTo)
    End Sub

    Private Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        Me.ViewData()
    End Sub

    Private Sub cboBranch_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboBranch.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next

        Select Case lstFunc.SelectedValue
            Case 7 ' Tổng doanh thu theo Mốc thời gian
            Case 13 'Số lượng dự án mà 01 nhà thầu phụ đang thực hiện
                e.Layout.Bands(0).Columns("SubContractorId").Hidden = False
                e.Layout.Bands(0).Columns("SubContractorId").Width = 50
                e.Layout.Bands(0).Columns("SubContractorName").Hidden = False
            Case 15 'Báo cáo Tình trạng cụ thể 01 hợp đồng
                e.Layout.Bands(0).Columns("ContractId").Hidden = False
        End Select
    End Sub

    Private Sub lstFunc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFunc.SelectedIndexChanged
        lblBranch.Visible = False
        cboBranch.Visible = False
        cboTime.Enabled = True

        Select Case lstFunc.SelectedValue
            Case 7 ' Tổng doanh thu theo Mốc thời gian
                cboTime.Enabled = False
            Case 13 'Số lượng dự án mà 01 nhà thầu phụ đang thực hiện
                cboTime.Enabled = False
                lblBranch.Visible = True
                cboBranch.Visible = True
                lblBranch.Text = "Nhà thầu"
                Me.LoadSubContractors()
            Case 15 'Báo cáo Tình trạng cụ thể 01 hợp đồng
                cboTime.Enabled = False
                lblBranch.Visible = True
                cboBranch.Visible = True
                lblBranch.Text = "Hợp đồng"
                Me.LoadContracts()
        End Select
    End Sub
End Class