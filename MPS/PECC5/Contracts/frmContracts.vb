Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinGrid
Public Class frmContracts
    Private WithEvents cls As BLL.BContracts = BLL.BContracts.Instance
    Private clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Private fselect As Boolean = False
    Private Sselect As String = ""
    Private fFinish As Boolean = False
    Private isClickedOnCollaps As Boolean = False
    Private fPageLoad As Boolean = False
    Private WithEvents cboDateFilter As ComboBoxTool

    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        ShowMsg(messege)
    End Sub

#Region "Form "

    Public Overloads Function ShowDialog(ByVal f As Boolean) As String
        fselect = f
        Me.ShowDialog()
        Return Sselect
    End Function

    Private Sub frmContracts_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Loadlist()
    End Sub

    Private Sub frmContracts_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.DateFilter = cboDateFilter.SelectedIndex
        My.Settings.Save()
    End Sub


    Private Sub frmContracts_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Delete And Toolbars.Tools("btnDel").SharedProps.Enabled = True Then
            T_DEL.PerformClick()
        End If

        If e.KeyCode = Keys.F5 Then
            T_Refresh.PerformClick()
        End If
        If e.KeyCode = Keys.F6 And Toolbars.Tools("btnEdit").SharedProps.Enabled = True Then
            T_Edit.PerformClick()
        End If
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.T And Toolbars.Tools("btnAdd").SharedProps.Enabled = True
                    Me.ADDNew()
                Case Keys.V
                    T_Layout.PerformClick()
                Case Keys.E
                    T_Export.PerformClick()
                Case Keys.A
                    T_SelectAll.PerformClick()
                Case Keys.P
                    Me.PrintBill()
            End Select
        End If
    End Sub

    Private Sub frmContracts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        LabelBottom.Text = ModMain.m_strLableList
        cboOperatorPer.SelectedIndex = 0
        cboOperatorLength.SelectedIndex = 0
        csFilter.ToggleState()
        cboDateFilter = CType(Toolbars.Tools("cboDateFilter"), ComboBoxTool)
        cboDateFilter.SelectedIndex = My.Settings.DateFilter

        Me.Loadlist()
        Me.Security()
        fPageLoad = True
    End Sub

#End Region

#Region "Sub "
    Private f_SecE As Boolean = False
    Private f_SecA As Boolean = False
    Private f_SecD As Boolean = False
    Private isAllowApprove As Boolean
    Private Sub Security()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 25)

        f_SecE = m.U
        f_SecA = m.A
        f_SecD = m.D
        Me.Toolbars.Tools("btnAdd").SharedProps.Enabled = f_SecA
        Me.Toolbars.Tools("btnEdit").SharedProps.Enabled = f_SecE
        Me.Toolbars.Tools("btnDel").SharedProps.Enabled = f_SecD

        isAllowApprove = ModMain.getPermitFunc(ModMain.m_UIDLogin, 26).R
    End Sub

    Private Sub FindItem(ByVal rParent As Infragistics.Win.UltraWinGrid.UltraGridRow, ByVal ColName As String, ByVal Value As String)
        If fFinish Then Exit Sub
        For i As Integer = 0 To rParent.ChildBands.Count - 1
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In rParent.ChildBands(i).Rows
                If Not r.ChildBands Is Nothing Then
                    FindItem(r, ColName, Value)
                Else
                    If r.Cells(ColName).Value = Value Then
                        rParent.ExpandAll()
                        r.Activated = True
                        fFinish = True
                        Exit Sub
                    End If
                End If
            Next
        Next

    End Sub

    Private Sub Loadlist(Optional ByVal s_ID As String = "")
        If csFilter.IsCollapsed Then
            Grid.DataSource = cls.getListContracts(ModMain.m_BranchId, cboDateFilter.SelectedIndex)
        Else
            If txtPerformance.Text = "" Then txtPerformance.Text = "0"
            If txtLength.Text = "" Then txtLength.Text = "0"
            Grid.DataSource = cls.getListContractsByFilter(ModMain.m_BranchId, CInt(txtPerformance.Text), cboOperatorPer.Text, CInt(txtLength.Text), cboOperatorLength.Text)
        End If

        If s_ID <> "" Then
            If Grid.Rows.Count > 0 Then
                For i As Integer = 0 To Grid.Rows.Count - 1
                    Dim r As UltraGridRow = Grid.Rows(i)
                    If r.ChildBands Is Nothing Then
                        If r.Cells("ContractId").Value = s_ID Then
                            r.Activated = True
                            Exit Sub
                        End If
                    Else
                        FindItem(r, "ContractId", s_ID)
                        If fFinish Then
                            r.ExpandAll()
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If

    End Sub
    
    Private Sub ADDNew()
        ModMain.ShowProcess()
        Dim frm As New frmContractDetail
        Dim result = frm.ShowDialog("")
        If result <> "" Then
            Me.Loadlist(result)
        End If
    End Sub
   

    Private Sub Edit()
        ModMain.ShowProcess()
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub
        If Not r.ChildBands Is Nothing Then Exit Sub
        Dim frm As New frmContractDetail
        Dim result = frm.ShowDialog(r.Cells("ContractId").Value)
        If result <> "" Then
            Me.Loadlist(result)
            For i As Integer = 0 To Grid.Rows.Count - 1
                If Grid.Rows(i).Cells("ContractId").Value.ToString = result Then
                    Grid.Rows(i).Selected = True
                    Grid.Rows(i).Activated = True
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Function DeleteDetail(ByVal id As String) As Boolean
        If Not cls.isDelete(id) Then
            ShowMsg(m_DataRelation)
            Return False
        End If
        Return cls.deleteDB(id)
    End Function
    Public Sub DEL()
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing OrElse r.Index = -1 Then Exit Sub

        Dim id As String = ""
        Dim name As String = ""

        Try
            If Grid.Selected.Rows.Count > 1 Then
                If ShowMsgYesNo(m_MsgAskDel, m_MsgCaption) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If

                For i As Integer = 0 To Grid.Selected.Rows.Count - 1
                    id = Grid.Selected.Rows(i).Cells("ContractId").Value
                    name = Grid.Selected.Rows(i).Cells("ContractName").Value

                    If Not Me.DeleteDetail(id) Then
                        Exit For
                    End If
                Next
            Else 'xóa 1 dòng
                id = r.Cells("ContractId").Value
                name = r.Cells("ContractName").Value

                If ShowMsgYesNo(m_MsgAskDel, m_MsgCaption) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If

                If Not Me.DeleteDetail(id) Then
                    Me.Loadlist(id)
                    Exit Sub
                End If
            End If

            Me.Loadlist()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub approve(ByVal status As String)
        Dim r As UltraGridRow = Grid.ActiveRow
        If r IsNot Nothing AndAlso r.Index <> -1 Then
            Dim contractId = r.Cells("ContractId").Value
            Dim ok = cls.updateStatus(contractId, status, ModMain.m_UIDLogin)
            If ok Then
                ShowMsgInfo(m_MsgSaveSuccess)
                Me.Loadlist(contractId)
            Else
                ShowMsg(m_SaveDataError)
            End If
        End If
    End Sub

    Private Sub PrintBill()
        Try
            ModMain.ShowProcess()
            Dim r As UltraGridRow = Grid.ActiveRow
            If r Is Nothing Then Exit Sub
            If r.Index = -1 Then Exit Sub
            If Not r.ChildBands Is Nothing Then Exit Sub

            Dim contractId = r.Cells("ContractId").Value

            Dim fullPath = Application.StartupPath & "\Reports\StatusOfContract.rpt"
            If Not System.IO.File.Exists(fullPath) Then
                ShowMsg("Không tìm thấy file: " & fullPath)
                Exit Sub
            End If

            Dim rp As New ReportDocument
            Dim clsrpt As New ClsReport
            rp = clsrpt.InitReport(Application.StartupPath & "\Reports\StatusOfContract.rpt")
            clsrpt.SetParameter(rp, contractId)
            Dim frm As New FrmReport
            frm.rpt.ReportSource = rp
            frm.Show()
        Finally
            ModMain.HideProcess()
        End Try
    End Sub
#End Region

#Region "Toolbar "
    Private Sub Toolbars_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles Toolbars.ToolClick
        Select Case e.Tool.Key
            Case "btnAdd"
                Me.ADDNew()
            Case "btnEdit"
                Me.Edit()
            Case "btnDel"
                Me.DEL()
            Case "btnRefresh"
                Me.Loadlist()
            Case "btnFilter"
                If isClickedOnCollaps Then Exit Select
                csFilter.ToggleState()
        End Select
    End Sub
#End Region

#Region "Grid "
    Dim fGrid As Boolean = False
    Private Sub Grid_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid.InitializeLayout
        If fGrid Then Exit Sub
        fGrid = True
        Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, Grid, m_Lang)

    End Sub

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub

        Dim fExit As Boolean = False
        Grid_MouseDown(sender, e, fExit)
        If fExit = True Then Exit Sub

        If fselect Then
            Sselect = r.Cells("ContractId").Value
            Me.Close()
            Exit Sub
        End If

        If f_SecE Then
            Me.Edit()
        End If
    End Sub

    Private Sub Grid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, Optional ByRef fExit As Boolean = False) Handles Grid.MouseDown
        T_Add.Enabled = f_SecA
        T_Edit.Enabled = f_SecE
        T_DEL.Enabled = f_SecD
        T_Refresh.Enabled = True
        T_SelectAll.Enabled = True
        T_Layout.Enabled = True
        T_Export.Enabled = ModMain.m_AllowExportExcel

        T_UpdateStatus.Enabled = Me.isAllowApprove

        T_StatusSigned.Enabled = True
        T_StatusInprogress.Enabled = True
        T_StatusCompleted.Enabled = True
        T_StatusPending.Enabled = True

        T_StatusSigned.Image = Nothing
        T_StatusInprogress.Image = Nothing
        T_StatusCompleted.Image = Nothing
        T_StatusPending.Image = Nothing

        Dim r As UltraGridRow = Grid.ActiveRow

        Dim element As Infragistics.Win.UIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(New Point(e.X, e.Y))
        If element Is Nothing Then Exit Sub
        Dim result As UltraGridRow = element.GetContext(GetType(UltraGridRow))
        If e.Button <> Windows.Forms.MouseButtons.Right Then
            If result Is Nothing Then
                fExit = True
                Exit Sub
            End If
            If result.Index = -1 Then fExit = True
            Exit Sub
        End If
        If result Is Nothing OrElse result.Index = -1 Then
            fExit = True
            T_Edit.Enabled = False
            T_DEL.Enabled = False
            T_SelectAll.Enabled = False
            T_Export.Enabled = False
            T_StatusSigned.Enabled = False
            T_StatusInprogress.Enabled = False
            T_StatusCompleted.Enabled = False
            T_StatusPending.Enabled = False
        Else
            If Not result.IsDataRow Then
                Exit Sub
            End If
            result.Activated = True
            r = result
            Dim status = result.Cells("ContractState").Value.ToString
            Select Case status
                Case Statuses.Signed
                    T_StatusSigned.Enabled = False
                    T_StatusSigned.Image = ModMain.m_OkIcon
                Case Statuses.Inprogress
                    T_StatusInprogress.Enabled = False
                    T_StatusInprogress.Image = ModMain.m_OkIcon
                Case Statuses.Completed
                    T_StatusCompleted.Enabled = False
                    T_StatusCompleted.Image = ModMain.m_OkIcon
                Case Statuses.Pending
                    T_StatusPending.Enabled = False
                    T_StatusPending.Image = ModMain.m_OkIcon
            End Select
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ctMenu.Show(Grid, New Point(e.X, e.Y))
        End If
    End Sub

#End Region

#Region "Context menu"
    Private Sub T_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Add.Click
        Me.ADDNew()
    End Sub
    Private Sub T_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Edit.Click
        Me.Edit()
    End Sub
    Private Sub T_DEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_DEL.Click
        Me.DEL()
    End Sub

    Private Sub T_Layout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Layout.Click
        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, Grid, m_Lang)
        frm.ShowDialog()
    End Sub

    Private Sub T_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New VsoftBMS.Ulti.FrmFind(Grid, m_Lang)
        frm.ShowDialog()
    End Sub

    Private Sub T_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Export.Click
        ExportExcel(Grid)
    End Sub

    Private Sub T_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Refresh.Click
        Me.Loadlist()
    End Sub

    Private Sub T_SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_SelectAll.Click
        SelectAll(Grid)
    End Sub

    Private Sub T_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Print.Click
        Me.PrintBill()
    End Sub

    Private Sub T_StatusSigned_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_StatusSigned.Click
        Me.approve(Statuses.Signed)
    End Sub

    Private Sub T_StatusInprogress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_StatusInprogress.Click
        Me.approve(Statuses.Inprogress)
    End Sub

    Private Sub T_StatusCompleted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_StatusCompleted.Click
        Me.approve(Statuses.Completed)
    End Sub

    Private Sub T_StatusPending_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_StatusPending.Click
        Me.approve(Statuses.Pending)
    End Sub
#End Region

#Region "Textbox"
    Private Sub txtPerformance_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPerformance.KeyPress
        ModMain.UltraTextBox_KeyPress(sender, e)
    End Sub

    Private Sub txtPerformance_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPerformance.Leave
        ModMain.UltraTextBox_LostFocus(sender)
    End Sub

    Private Sub txtPerformance_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPerformance.ValueChanged
        ModMain.UltraTextBox_ValueChanged(sender)
    End Sub

    Private Sub txtLength_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLength.KeyPress
        ModMain.UltraTextBox_KeyPress(sender, e)
    End Sub

    Private Sub txtLength_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLength.Leave
        ModMain.UltraTextBox_LostFocus(sender)
    End Sub

    Private Sub txtLength_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLength.ValueChanged
        ModMain.UltraTextBox_ValueChanged(sender)
    End Sub
#End Region

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.Loadlist()
    End Sub

    Private Sub csFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csFilter.Click
        isClickedOnCollaps = True
        Dim btn As StateButtonTool = DirectCast(Toolbars.Tools("btnFilter"), StateButtonTool)
        btn.Checked = Not csFilter.IsCollapsed
        isClickedOnCollaps = False
    End Sub

    Private Sub cboDateFilter_AfterToolCloseup(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolDropdownEventArgs) Handles cboDateFilter.AfterToolCloseup
        If fPageLoad Then
            Me.Loadlist()
        End If
    End Sub

  
End Class