Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinGrid
Public Class frmBranch
    Private WithEvents cls As BLL.B_Branchs = BLL.B_Branchs.Instance
    Dim clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Dim m_isLoad As Boolean = False
    Private fFinish As Boolean = False

    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub

#Region "DIALOG-30.12.08-Chọn chi nhánh hàng từ danh mục khác"
    Private sSelect As String = ""
    Private fSelect As Boolean = False
    Public Overloads Function ShowDialog(ByVal f_Select As Boolean) As String
        fSelect = f_Select
        Me.ShowDialog()
        Return sSelect
    End Function
#End Region

#Region "FORM"

    Private Sub FrmBranch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then 'tìm kiếm
            Me.T_Search.PerformClick()
        End If
        If e.KeyCode = Keys.F5 Then
            Me.T_Refresh.PerformClick()
        End If
        If fSelect Then
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End If
        '   Else 'khi xem danh sách từ danh mục khác thì không đươc thực hiện các chức năng này

        If e.KeyCode = Keys.Delete Then
            Me.T_DEL.PerformClick()
        End If
        If e.KeyCode = Keys.F6 Then
            Me.T_Edit.PerformClick()
        End If
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.T
                    Me.T_Add.PerformClick()
                    'Case Keys.H
                    '    Me.T_Edit.PerformClick()
                Case Keys.V
                    Me.T_Layout.PerformClick()
                Case Keys.E
                    Me.T_Export.PerformClick()
                Case Keys.P '18/05/2009
                    Me.T_Print.PerformClick()
                Case Keys.A
                    Me.T_SelectAll.PerformClick()
            End Select

        End If

        '  End If
    End Sub

    Private Sub FrmBranch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me,UltraLabel1.Text)
        LabelBottom.Text = ModMain.m_strLableList
        LoadList()

        Security()
    End Sub

    Private Sub FrmBranch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        If Me.Text.Contains("rm") Then
            Me.LoadList()
        End If
    End Sub

#End Region

#Region "SUB"
    Private f_SecE As Boolean = False
    Private f_SecA As Boolean = False
    Private f_SecD As Boolean = False

    Private Sub Security()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 12)

        f_SecE = m.U
        f_SecA = m.A
        f_SecD = m.D

        tbManager.Tools("btnAdd").SharedProps.Enabled = f_SecA
        tbManager.Tools("btnEdit").SharedProps.Enabled = f_SecE
        tbManager.Tools("btnDel").SharedProps.Enabled = f_SecD

        T_Add.Enabled = f_SecA
        T_DEL.Enabled = f_SecD
        T_Edit.Enabled = f_SecE

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
                        'Grid.DataSource = b.getListImportDetail(r.Cells(ColName).Value)
                        fFinish = True
                        Exit Sub
                    End If
                End If
            Next
        Next

    End Sub
    Private Sub LoadList()
        Dim s_ID As String = ""
        If Not Grid.DataSource Is Nothing Then
            If Not Grid.ActiveRow Is Nothing Then
                If Grid.ActiveRow.Index <> -1 And Not Grid.ActiveRow.Cells Is Nothing Then
                    s_ID = Grid.ActiveRow.Cells("s_ID").Value
                End If
            End If
        End If

        Me.Grid.DataSource = cls.getList()

        If s_ID <> "" Then
            If Grid.Rows.Count > 0 Then
                For i As Integer = 0 To Grid.Rows.Count - 1
                    Dim r As UltraGridRow = Grid.Rows(i)
                    If r.ChildBands Is Nothing Then
                        If r.Cells("s_ID").Value = s_ID Then
                            r.Activated = True
                            Exit Sub
                        End If

                    Else
                        FindItem(r, "s_ID", s_ID)

                        If fFinish Then
                            r.ExpandAll()
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If

    End Sub
    Public Sub ADDNew()
        Dim frm As New frmNewBranch
        Dim sID As String = frm.ShowDialog(False)
        If sID <> "" Then
            LoadList()
        End If
    End Sub
    Private Sub Edit()
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub
        If Not r.ChildBands Is Nothing Then Exit Sub
        If fSelect Then
            sSelect = r.Cells("s_ID").Value
            Me.Close()
        Else
            Dim frm As New frmNewBranch
            frm.LoadInfo(r.Cells("s_ID").Value)
            Dim sID As String = frm.ShowDialog(True)
            If sID <> "" Then
                LoadList()
            End If
        End If

    End Sub
    Public Sub DEL()
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing OrElse r.Index = -1 Then Exit Sub
        If r.IsGroupByRow Then Exit Sub
        Dim id As String = ""
        Dim idchar As String = ""
        Dim name As String = ""

        Try
            If Grid.Selected.Rows.Count > 1 Then
                If MessageBox.Show("Xóa " & Grid.Selected.Rows.Count & " dòng đang chọn ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If

                For i As Integer = 0 To Grid.Selected.Rows.Count - 1
                    id = Grid.Selected.Rows(i).Cells("s_ID").Value
                    idchar = Grid.Selected.Rows(i).Cells("s_Branch_ID").Value
                    name = Grid.Selected.Rows(i).Cells("s_Name").Value

                    If cls.checkDelete(id) Then
                        If MessageBox.Show("Có dữ liệu liên quan đến chi nhánh hàng " & name & " có mã là " & idchar & ", tiếp tục hay dừng lại ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            LoadList()
                            Exit Sub
                        End If

                    Else
                        If Not cls.DELETEDB(id) Then
                            Dim s As String = ""
                            If m_Lang = 1 Then
                                ShowMsg("Quá trình xóa chi nhánh hàng " & name & " có mã là " & idchar & " có lỗi. Kiểm tra và thực hiện lại !", m_MsgCaption)
                            Else
                                ShowMsg(m_DelError, m_MsgCaption)
                            End If

                            LoadList()
                            Exit Sub
                        Else
                            ModMain.UpdateEvent(ModMain.m_UIDLogin, "Xóa chi nhánh hàng có mã '" & idchar & "'", TypeEvents.List)
                        End If
                    End If
                Next
            Else 'xóa 1 dòng
                id = r.Cells("s_ID").Value
                idchar = r.Cells("s_Branch_ID").Value
                name = r.Cells("s_Name").Value

                If cls.checkDelete(id) Then
                    ShowMsg("Có dữ liệu liên quan đến chi nhánh hàng " & name & " có mã là " & idchar & " !", m_MsgCaption)
                    Exit Sub
                End If

                If ShowMsgYesNoCancel(m_MsgAskDel, m_MsgCaption) <> Windows.Forms.DialogResult.Yes Then Exit Sub

                If Not cls.DELETEDB(id) Then
                    If m_Lang = 1 Then
                        ShowMsg("Quá trình xóa chi nhánh hàng " & name & " có mã là " & idchar & " có lỗi. Kiểm tra và thực hiện lại !", m_MsgCaption)
                    Else
                        ShowMsg(m_DelError, m_MsgCaption)
                    End If

                    Exit Sub
                Else
                    ModMain.UpdateEvent(ModMain.m_UIDLogin, "Xóa chi nhánh hàng có mã '" & idchar & "'", TypeEvents.List)
                End If

            End If

            LoadList()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ViewReport()
        'Dim rp As New ReportDocument
        'Dim cls As New ClsReport

        'Try
        '    rp = cls.InitReport(Application.StartupPath & "\Reports\rptchi nhánhHang.rpt")
        '    cls.SetParameter(rp, ModMain.m_CompanyName, ModMain.m_CompanyAddress)

        '    Dim frm As New FrmReport
        '    frm.rpt.ReportSource = rp
        '    frm.Show()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
#End Region

#Region "GRID"
    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim fExit As Boolean = False
        Grid_MouseDown(sender, e, fExit)
        If fExit = True Then Exit Sub

        Me.T_Edit.PerformClick()
    End Sub

    Private Sub Grid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        If e.KeyCode = Keys.Delete Then
            Me.T_DEL.PerformClick()
        End If
        '20/04/2009
        If e.KeyCode = Keys.Apps Then Me.ctMenu.Show(500, 500)
    End Sub

    Private Sub Grid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, Optional ByRef fExit As Boolean = False) Handles Grid.MouseDown

        T_Add.Enabled = f_SecA
        T_Edit.Enabled = f_SecE
        T_DEL.Enabled = f_SecD
        T_Refresh.Enabled = True
        T_SelectAll.Enabled = True
        T_Layout.Enabled = True
        T_Search.Enabled = True
        T_Print.Enabled = True
        T_Export.Enabled = True

        Dim element As Infragistics.Win.UIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(New Point(e.X, e.Y))
        Dim result As UltraGridRow = element.GetContext(GetType(UltraGridRow))

        If result Is Nothing OrElse Not result.IsDataRow OrElse result.Index = -1 Then
            fExit = True
            T_Edit.Enabled = False
            T_DEL.Enabled = False
            If Grid.Rows.Count < 1 Then
                T_SelectAll.Enabled = False
                T_Export.Enabled = False
                T_Search.Enabled = False
                T_Print.Enabled = False
            End If
            If e.Button <> Windows.Forms.MouseButtons.Right Then Exit Sub
        Else
            If e.Button <> Windows.Forms.MouseButtons.Right Then Exit Sub
            result.Activated = True
            result.Selected = True
        End If

        ctMenu.Show(Grid, New Point(e.X, e.Y))
    End Sub

    Dim fGrid As Boolean = False
    Private Sub Grid_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid.InitializeLayout
        If fGrid Then Exit Sub
        fGrid = True

        Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, Grid, m_Lang)

    End Sub

#End Region

#Region "CONTEXT MENU"
    Private Sub T_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Add.Click
        ADDNew()
    End Sub
    Private Sub T_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Edit.Click
        Edit()
    End Sub
    Private Sub T_DEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_DEL.Click
        DEL()
    End Sub
    Private Sub T_Layout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Layout.Click
        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, Grid, m_Lang)
        frm.ShowDialog()
    End Sub
    Private Sub T_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Search.Click
        Dim frm As New VsoftBMS.Ulti.FrmFind(Grid, m_Lang)
        frm.ShowDialog()
    End Sub
    Private Sub T_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Print.Click
        Me.ViewReport()
    End Sub
    Private Sub T_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Export.Click
        ExportExcel(Grid)
    End Sub
    '20/05/2009dat
    Private Sub T_SelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_SelectAll.Click
        SelectAll(Grid)
    End Sub

    Private Sub T_Refresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Refresh.Click
        Me.LoadList()
    End Sub

#End Region

#Region "tbManager"
    Private Sub tbManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles tbManager.ToolClick
        Select Case e.Tool.Key
            Case "btnAdd"
                Me.T_Add.PerformClick()
            Case "btnEdit"
                Me.T_Edit.PerformClick()
            Case "btnDel"
                Me.T_DEL.PerformClick()
        End Select
    End Sub

#End Region


End Class