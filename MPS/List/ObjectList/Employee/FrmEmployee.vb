Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinGrid

Public Class FrmEmployee
    Private WithEvents cls As BLL.BEmployees = BLL.BEmployees.Instance
    Dim clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Private fFinish As Boolean = False

    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub

#Region "DIALOG"

    Private sSelect As String = ""
    Private fSelect As Boolean = False
    Public Overloads Function ShowDialog(ByVal f_Select As Boolean) As String
        fSelect = f_Select
        Me.ShowDialog()
        'sSelect = Me.txtSID.Text
        Return sSelect
    End Function
#End Region

#Region " Form "

    Private Sub FrmEmployee_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'clsuf.SaveInfoFormatUltraGrid(Me.Name, Grid, False, iLang)
    End Sub

    Private Sub FrmEmployee_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F3 Then
            Dim frm As New VsoftBMS.Ulti.FrmFind(Grid, m_Lang)
            frm.ShowDialog()
        End If

        If fSelect Then
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End If

        If e.KeyCode = Keys.F5 Then Me.T_Refresh.PerformClick()

        If e.KeyCode = Keys.Delete Then

            T_DEL.PerformClick()
        End If
        If e.KeyCode = Keys.F6 And tbManager.Tools("btnEdit").SharedProps.Enabled = True Then
            Me.Edit()
        End If

        If e.Control Then
            Select Case e.KeyCode
                Case Keys.T
                    Me.T_Add.PerformClick()
                    'Case Keys.H
                    '    Me.Edit()
                Case Keys.X
                    ' Me.View()
                    T_ViewEdit.PerformClick()
                Case Keys.V
                    Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, Grid, m_Lang)
                    frm.ShowDialog()
                Case Keys.E
                    ExportExcel(Grid)
                Case Keys.A
                    Me.T_SelectAll.PerformClick()
            End Select
        End If
    End Sub

    Private Sub FrmEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, UltraLabel1.Text)
        LabelBottom.Text = ModMain.m_strLableList
        Security()
        LoadList()
    End Sub

    Private Sub FrmImports_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        If Me.Text.Contains("rm") Then
            Me.LoadList()
        End If
    End Sub


#End Region

#Region "MENUs"
    Private Sub mnu_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AddNew()
    End Sub

    Private Sub mnu_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Edit()
    End Sub

    Private Sub mnu_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DEL()
    End Sub

    Private Sub mnu_layout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, Grid, m_Lang)
        frm.ShowDialog()
    End Sub

    Private Sub TìmKiếmToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim frm As New VsoftBMS.Ulti.FrmFind(Grid, m_Lang)
        frm.ShowDialog()
    End Sub

    Private Sub ExportToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ExportExcel(Grid)
    End Sub

#End Region

#Region "Sub "

    Private f_SecE As Boolean = False
    Private f_SecA As Boolean = False
    Private f_SecD As Boolean = False

    Private Sub Security()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 27)
        f_SecE = m.U
        f_SecA = m.A
        f_SecD = m.D

        tbManager.Tools("btnAdd").SharedProps.Enabled = f_SecA
        tbManager.Tools("btnEdit").SharedProps.Enabled = f_SecE
        tbManager.Tools("btnDel").SharedProps.Enabled = f_SecD

        T_Add.Enabled = f_SecA
        T_DEL.Enabled = f_SecD
        T_ViewEdit.Enabled = f_SecE

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
    Private Sub LoadList()
        Dim s_ID As String = ""
        If Not Grid.DataSource Is Nothing Then
            If Not Grid.ActiveRow Is Nothing Then
                If Grid.ActiveRow.Index <> -1 And Not Grid.ActiveRow.Cells Is Nothing Then
                    s_ID = Grid.ActiveRow.Cells("s_ID").Value
                End If
            End If
        End If

        'fSelect

        Dim tb As DataTable = cls.getList()
        If tb Is Nothing Then Exit Sub
        If fSelect Then
            Me.tbManager.Visible = False
            T_DEL.Visible = False
            tb.DefaultView.RowFilter = "dt_Holidays is null"
        End If
        Me.Grid.DataSource = tb

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

        'If Grid.Rows.Count > 0 Then Me.LabelBottom.Text = "Click phải chọn menu chức năng..."

    End Sub

    Private Sub AddNew()
        Dim frm As New FrmNewEmployee
        Dim sEdit As String = frm.ShowDialog(False)
        If sEdit <> "" Then
            LoadList()
        End If
    End Sub
    Public Sub DEL()
        If fSelect Then 'Ko cho phep xoa khi chon danh sach
            Exit Sub
        End If
        'SỬA LẠI :18-12-2008
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing OrElse r.Index = -1 Then Exit Sub
        Dim id As String = ""
        Dim idchar As String = ""
        Dim name As String = ""

        Try
            If Grid.Selected.Rows.Count > 1 Then 'xóa nhiếu dòng
                Dim sMsgDel As String = m_PathDelFirst & Grid.Selected.Rows.Count & m_PathDelLast
                If ShowMsgYesNoCancel(sMsgDel, m_MsgCaption) <> Windows.Forms.DialogResult.Yes Then Exit Sub

                For i As Integer = 0 To Grid.Selected.Rows.Count - 1
                    id = Grid.Selected.Rows(i).Cells("s_ID").Value
                    idchar = Grid.Selected.Rows(i).Cells("s_Employee_ID").Value
                    name = Grid.Selected.Rows(i).Cells("s_Name").Value

                    If Not cls.isDelete(id) Then
                        ShowMsg(m_DataRelation, m_MsgCaption)
                        Exit For
                    End If
                    If Not cls.DELETEDB(id) Then
                        ShowMsg(m_DelError, m_MsgCaption)
                        Exit For
                    Else
                        ModMain.UpdateEvent(ModMain.m_UIDLogin, "Xóa nhân viên có mã '" & idchar & "'", TypeEvents.List)
                    End If
                Next

            Else 'xóa 1 dòng
                id = r.Cells("s_ID").Value
                idchar = r.Cells("s_Employee_ID").Value
                name = r.Cells("s_Name").Value

                If Not cls.isDelete(id) Then
                    ShowMsg(m_DataRelation, m_MsgCaption)
                    Exit Sub
                End If
                If ShowMsgYesNoCancel(m_MsgAskDel, m_MsgCaption) <> Windows.Forms.DialogResult.Yes Then Exit Sub

                If Not cls.DELETEDB(id) Then
                    ShowMsg(m_DelError, m_MsgCaption)
                    Exit Sub
                Else
                    ModMain.UpdateEvent(ModMain.m_UIDLogin, "Xóa nhân viên có mã '" & idchar & "'", TypeEvents.List)
                End If

            End If

            LoadList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Edit()

        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing OrElse r.Index = -1 Then
            Exit Sub
        End If

        Dim frm As New FrmNewEmployee
        frm.LoadInfo(r.Cells("s_ID").Value)
        Dim sEdit = frm.ShowDialog(True)
        If sEdit <> "" Then
            LoadList()
        End If

    End Sub

    Private Sub View()
        Try
            Dim r As UltraGridRow = Grid.ActiveRow
            If r Is Nothing OrElse r.Index = -1 Then Exit Sub

            Dim frm As New FrmNewEmployee
            frm.LoadInfo(r.Cells("s_ID").Value)
            frm.tbManager.Tools("btnSaveClose").SharedProps.Visible = False
            frm.tbManager.Tools("btnSave").SharedProps.Enabled = False
            frm.tbManager.Tools("btnEdit").SharedProps.Visible = True
            frm.tbManager.Tools("btnFirst").SharedProps.Visible = True
            frm.tbManager.Tools("btnPre").SharedProps.Visible = True
            frm.tbManager.Tools("btnNext").SharedProps.Visible = True
            frm.tbManager.Tools("btnLast").SharedProps.Visible = True
            Dim str As String = frm.ShowDialog(True)

            If str <> "" Then
                LoadList()
            End If

        Catch ex As Exception

        End Try

    End Sub
    'REPORT*******
    Private Sub ViewReport()
        Dim rp As New ReportDocument
        Dim cls As New ClsReport
        rp = cls.InitReport(Application.StartupPath & "\Reports\rptNhanVien.rpt")
        cls.SetParameter(rp, ModMain.m_CompanyName, ModMain.m_CompanyAddress)

        Dim frm As New FrmReport
        frm.rpt.ReportSource = rp
        frm.Show()
    End Sub
#End Region

#Region " Grid "

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim fExit As Boolean = False
        Grid_MouseDown(sender, e, fExit)
        If fExit = True Then Exit Sub

        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing OrElse r.Index = -1 Then
            Exit Sub
        End If
        If fSelect Then
            sSelect = r.Cells("s_ID").Value
            Me.Close()
            Exit Sub
        End If
        Me.View() '27.05.09
        'Edit()
    End Sub

    Dim fGrid As Boolean = False
    Private Sub Grid_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid.InitializeLayout
        If fGrid Then Exit Sub
        fGrid = True

        Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, Grid, m_Lang)

    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyUp
        'If e.KeyCode = Keys.Delete Then
        '    Me.DEL()
        'End If
        If e.Control Then
            If e.KeyCode = Keys.F Then
                Dim frm As New VsoftBMS.Ulti.FrmFind(Grid, m_Lang)
                frm.ShowDialog()
            End If
        End If
        '20/04/2009
        If e.KeyCode = Keys.Apps Then Me.MenuStrip1.Show(500, 500)
    End Sub

    Private Sub Grid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, Optional ByRef fExit As Boolean = False) Handles Grid.MouseDown
        T_Add.Enabled = f_SecA
        T_ViewEdit.Enabled = True
        T_DEL.Enabled = f_SecD
        T_Refresh.Enabled = True
        T_SelectAll.Enabled = True
        T_Layout.Enabled = True
        T_Export.Enabled = True
        Dim element As Infragistics.Win.UIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(e.Location)
        Dim result As UltraGridRow = element.GetContext(GetType(UltraGridRow))

        If result Is Nothing OrElse Not result.IsDataRow OrElse result.Index = -1 Then
            fExit = True
            T_ViewEdit.Enabled = False
            T_DEL.Enabled = False
            If Grid.Rows.Count < 1 Then
                T_SelectAll.Enabled = False
                T_Export.Enabled = False
            End If
        Else
            result.Activated = True
            result.Selected = True
        End If
        If e.Button <> Windows.Forms.MouseButtons.Right Then Exit Sub
        Me.MenuStrip1.Show(Grid, New Point(e.X, e.Y))
    End Sub
#End Region

#Region "Tool "

    Private Sub InToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewReport()
    End Sub

    Private Sub tbManager_ToolClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles tbManager.ToolClick
        Select Case e.Tool.Key
            Case "btnAdd"
                Me.AddNew()
            Case "btnDel"
                Me.DEL()
            Case "btnEdit"
                Me.Edit()
        End Select
    End Sub

#End Region

#Region "CONTEXT MENUTRIP*********"

    Private Sub T_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Add.Click
        Me.AddNew()
    End Sub

    Private Sub T_ViewEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_ViewEdit.Click
        Me.View()
        'Me.Edit()
    End Sub


    Private Sub T_DEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_DEL.Click
        Me.DEL()
    End Sub

    Private Sub InToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ViewReport()
    End Sub

    Private Sub TìmKiếmToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New VsoftBMS.Ulti.FrmFind(Grid, m_Lang)
        frm.ShowDialog()
    End Sub

    Private Sub XuấtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Export.Click
        ExportExcel(Grid)
    End Sub
    Private Sub NhaptuExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New frmImportDatas
        'Dim fOK As Boolean = frm.ShowDialog("Employee")
        'If fOK Then
        '    Me.LoadList()
        'End If
    End Sub

    Private Sub T_SelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_SelectAll.Click
        SelectAll(Grid)
    End Sub
    Private Sub T_Refresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Refresh.Click
        Me.LoadList()
    End Sub
    Private Sub ĐiềuChỉnhHiểnThịToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Layout.Click
        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, Grid, m_Lang)
        frm.ShowDialog()
    End Sub
#End Region
End Class