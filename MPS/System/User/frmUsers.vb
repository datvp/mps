Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinGrid
Public Class frmUsers
    Private WithEvents cls As New BLL.BSecUser
    Private WithEvents clsFun As BLL.BFuncRight = BLL.BFuncRight.Instance
    Dim clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Dim mUser As Model.MSecUser
    Private fFinish As Boolean = False

    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub


#Region "FORM***********"

    Private Sub FrmSecUserTest_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        LoadList()
    End Sub

    Private Sub FrmSecUserTest_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F3 Then
            Dim frm As New VsoftBMS.Ulti.FrmFind(Grid, m_Lang)
            frm.ShowDialog()
        End If

        If e.KeyCode = Keys.F5 Then
            T_Refresh.PerformClick()
        End If
        If e.KeyCode = Keys.Delete Then
            Me.DEL()
        End If
        If e.KeyCode = Keys.F6 Then
            T_Edit.PerformClick()
        End If
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.T
                    T_Add.PerformClick()
                    'Me.ADDNew()
                    'Case Keys.H
                    '    Me.Edit()
                Case Keys.V
                    Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, Grid, m_lang)
                    frm.ShowDialog()
                Case Keys.E
                    ExportExcel(Grid)
                Case Keys.P
                    ViewReport()
            End Select
        End If

    End Sub

    Private Sub FrmSecUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, UltraLabel1.Text)
        LabelBottom.Text = ModMain.m_strLableList
        LoadList()
        clsuf.FormatGridFromDB(Me.Name, Grid)
        Security()
    End Sub

#End Region


#Region "SUB************** "
    Private f_SecE As Boolean = False
    Private f_SecA As Boolean = False
    Private f_SecD As Boolean = False
    Private Sub Security()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 15)
        f_SecA = m.A
        f_SecD = m.D
        f_SecE = m.U

        If ModMain.m_UIDLogin.Trim.ToLower <> "admin" Then
            'kiem tra nguoi dung co quyen quan tri
            'neu co->gan true het
            'nguoc lai->gan theo phan quyen

            mUser = cls.getInfo(ModMain.m_UIDLogin)
            If mUser.isAdmin Then
                Me.tbManager.Tools("btnAdd").SharedProps.Enabled = True
                Me.tbManager.Tools("btnDel").SharedProps.Enabled = True
                Me.tbManager.Tools("btnEdit").SharedProps.Enabled = True

                Me.T_Add.Enabled = True
                Me.T_DEL.Enabled = True
                Me.T_Edit.Enabled = True
            Else ' ng lai theo phan quyen
                Me.tbManager.Tools("btnAdd").SharedProps.Enabled = f_SecA
                Me.tbManager.Tools("btnDel").SharedProps.Enabled = f_SecD
                Me.tbManager.Tools("btnEdit").SharedProps.Enabled = f_SecE

                Me.T_Add.Enabled = f_SecA
                Me.T_DEL.Enabled = f_SecD
                Me.T_Edit.Enabled = f_SecE
            End If
        End If
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
                    s_ID = Grid.ActiveRow.Cells("s_UID").Value
                End If
            End If
        End If

        Me.Grid.DataSource = cls.getList

        Dim tb As DataTable = Grid.DataSource

        If ModMain.m_UIDLogin.Trim.ToLower <> "admin" Then
            Dim mUser As Model.MSecUser = cls.getInfo(ModMain.m_UIDLogin)
            If Not mUser.isAdmin Then
                tb.DefaultView.RowFilter = "s_UID='" & ModMain.m_UIDLogin.Replace("'", "''") & "'"
            End If
        End If

        If s_ID <> "" Then
            If Grid.Rows.Count > 0 Then
                For i As Integer = 0 To Grid.Rows.Count - 1
                    Dim r As UltraGridRow = Grid.Rows(i)
                    If r.ChildBands Is Nothing Then
                        If r.Cells("s_UID").Value = s_ID Then
                            r.Activated = True
                            Exit Sub
                        End If

                    Else
                        FindItem(r, "s_UID", s_ID)

                        If fFinish Then
                            r.ExpandAll()
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If


        ' Me.Grid.DataSource = tb
        'If Grid.Rows.Count > 0 Then
        '    Me.LabelBottom.Text = "Click phải chọn menu chức năng..."
        'End If
    End Sub

    Public Sub ADDNew()
        Dim IDGroup As String = ""
        Dim frm As New FrmNewUser
        Dim sEdit As String = frm.ShowDialog(IDGroup)
        If sEdit <> "" Then
            LoadList()
            'cấp quyền cho User mới theo nhóm
            Dim frmFun As New FrmFuncRight
            frmFun.Grid.DataSource = clsFun.getFuncRight(IDGroup)
            frmFun.SaveRight(sEdit)
        End If
        'frm.ShowDialog()
    End Sub
    Public Sub DEL()

        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing OrElse r.Index = -1 Then Exit Sub
        Dim id As String = ""

        Try
            If Grid.Selected.Rows.Count > 1 Then 'xóa nhiếu dòng
                Dim sMsgDel As String = m_PathDelFirst & Grid.Selected.Rows.Count & m_PathDelLast
                If ShowMsgYesNoCancel(sMsgDel, m_MsgCaption) <> Windows.Forms.DialogResult.Yes Then Exit Sub


                For i As Integer = 0 To Grid.Selected.Rows.Count - 1
                    id = Grid.Selected.Rows(i).Cells("s_UID").Value

                    If id.Trim.ToLower = "admin" Then
                        ShowMsg("Tài khoản quản trị, không thể xóa.")
                        Exit Sub
                    End If
                    If ModMain.m_UIDLogin.Trim.ToLower = id.Trim.ToLower Then
                        ShowMsg("Người dùng đang được sử dụng, không thể xóa.")
                        Exit Sub
                    End If
                    If Not cls.DeleteDB(id) Then
                        ShowMsg(m_DelErrorOneItems & "('" & id & ")", m_MsgCaption)
                        LoadList()
                        Exit Sub
                    Else
                        ModMain.UpdateEvent(ModMain.m_UIDLogin, "Xóa người dùng có mã " & id, TypeEvents.System)
                    End If
                Next

            Else 'xóa 1 dòng
                id = r.Cells("s_UID").Value

                If id.Trim.ToLower = "admin" Then
                    ShowMsg("Tài khoản quản trị, không thể xóa.")
                    Exit Sub
                End If
                If ModMain.m_UIDLogin.Trim.ToLower = id.Trim.ToLower Then
                    ShowMsg("Người dùng đang được sử dụng, không thể xóa.")
                    Exit Sub
                End If
                If ShowMsgYesNo("Có xóa người dùng đang chọn ?", m_MsgCaption) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If

                If Not cls.DeleteDB(id) Then
                    '"Quá trình xóa người dùng " & id & " có lỗi. Kiểm tra và thực hiện lại !"
                    ShowMsg(m_DelErrorOneItems & "('" & id & "')", m_MsgCaption)
                    LoadList()
                    Exit Sub
                Else
                    ModMain.UpdateEvent(ModMain.m_UIDLogin, "Xóa người dùng có mã " & id, TypeEvents.System)
                End If
            End If

            LoadList()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Edit()
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub
        Dim IDGroup As String = ""
        If Not r.ChildBands Is Nothing Then Exit Sub
        Dim frm As New FrmNewUser
        frm.LoadInfo(r.Cells("s_UID").Value)
        If r.Cells("s_UID").Value.ToString.Trim.ToLower = "admin" Then
            frm.txtUID.ReadOnly = True
            frm.ChAdmin.Checked = True
            frm.ChAdmin.Enabled = False
            frm.ChValid.Enabled = False
            frm.ChValid.Checked = True
        End If
        Dim sEdit As String = frm.ShowDialog(IDGroup)
        If sEdit <> "" Then

            ''cập nhập lại quyền người dùng khi hiệu chỉnh
            'Dim frmFun As New FrmFuncRight
            'clsFun.DeleteDB(r.Cells("s_UID").Value)
            'frmFun.Grid.DataSource = clsFun.getFuncRight(IDGroup, ModMain.m_sVesion.ToLower)
            'frmFun.SaveRight(sEdit)
            '-----------------
            LoadList()
            For i As Integer = 0 To Grid.Rows.Count - 1
                If Grid.Rows(i).Cells("s_UID").Value = sEdit Then
                    Grid.Rows(i).Selected = True
                    Grid.Rows(i).Activated = True
                    Exit For
                End If
            Next
        End If
        'frm.ShowDialog()
    End Sub
#End Region

#Region "GRID************* "

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim fExit As Boolean = False
        Grid_MouseDown(sender, e, fExit)
        If fExit = True Then Exit Sub
        Edit()
    End Sub

    Private Sub Grid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, Optional ByRef fExit As Boolean = False) Handles Grid.MouseDown
        T_Add.Enabled = f_SecA
        If ModMain.m_UIDLogin.Trim.ToLower <> "admin" Then
            T_Edit.Enabled = True
        End If
        T_DEL.Enabled = f_SecD
        T_Refresh.Enabled = True
        T_SelectAll.Enabled = True
        T_Layout.Enabled = True
        T_Export.Enabled = ModMain.m_AllowExportExcel

        Dim r As UltraGridRow = Grid.ActiveRow '19.12.08
        Dim element As Infragistics.Win.UIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(e.Location)
        If element Is Nothing Then Exit Sub
        Dim result As UltraGridRow = element.GetContext(GetType(UltraGridRow))
        If e.Button <> Windows.Forms.MouseButtons.Right Then
            If Not Grid.Selected Is Nothing AndAlso Grid.Selected.Rows.Count > 1 Then
                Grid.Selected.Rows.Clear()
            End If
            If result Is Nothing Then
                fExit = True
                Exit Sub
            End If
            If result.Index = -1 Then fExit = True
            Exit Sub
        End If

        '--------- 2/7
        If result Is Nothing OrElse result.Index = -1 Then
            fExit = True
            T_Edit.Enabled = False
            T_DEL.Enabled = False
            If Grid.Rows.Count < 1 Then
                T_SelectAll.Enabled = False
                T_Export.Enabled = False
            End If
        Else
            If Not result.IsDataRow Then
                Exit Sub
            End If

            If Not Grid.Selected Is Nothing Then
                Grid.Selected.Rows.Clear()
            End If
            result.Activated = True
            r = result

        End If
        '-------

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.ctMenu.Show(Grid, New Point(e.X, e.Y))
        End If

    End Sub

#End Region

#Region "CONTEXT MENUTRIP********* "


    Private Sub T_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Add.Click
        ADDNew()
    End Sub
    Private Sub T_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Edit.Click
        Edit()
    End Sub

    Private Sub T_DEL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_DEL.Click
        DEL()
    End Sub
    Private Sub TìmKiếmToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New VsoftBMS.Ulti.FrmFind(Grid, m_Lang)
        frm.ShowDialog()
    End Sub
    Private Sub T_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Refresh.Click
        LoadList()
    End Sub

    Private Sub T_SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_SelectAll.Click
        SelectAll(Grid)
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyUp


        'If e.Control Then
        '    If e.KeyCode = Keys.F Then
        '        Dim frm As New VsoftBMS.Ulti.FrmFind(Grid,m_Lang)
        '        frm.ShowDialog()
        '    End If
        'End If
    End Sub


    Private Sub ĐiềuChỉnhHiểnThịToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Layout.Click
        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, Grid, m_Lang)
        frm.ShowDialog()
    End Sub

    Private Sub ViewReport()
        Dim rp As New ReportDocument
        Dim cls As New ClsReport
        rp = cls.InitReport(Application.StartupPath & "\Reports\DanhMuc\rptNguoiDung.rpt")
        cls.SetParameter(rp, mbc.s_CompanyName, mbc.s_Address)

        Dim frm As New FrmReport
        frm.rpt.ReportSource = rp
        frm.Show()
    End Sub

    Private Sub T_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ViewReport()
    End Sub

    Private Sub XuatraExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Export.Click
        ExportExcel(Grid)
    End Sub
    Private Sub tbManager_ToolClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles tbManager.ToolClick
        Select Case e.Tool.Key
            Case "btnAdd"
                Me.ADDNew()
            Case "btnEdit"
                Me.Edit()
            Case "btnDel"
                Me.DEL()
            Case "btnRefresh"
                Me.LoadList()
        End Select
    End Sub

    Private Sub Grid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        If e.KeyCode = Keys.Delete Then
            Me.DEL()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As Form = Me.ParentForm
        Dim fChild As Form = f.ActiveMdiChild
        If Not fChild Is Nothing Then
            fChild.Close()
        End If
    End Sub

    Private Sub ctMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctMenu.Opening

    End Sub

#End Region
    Dim fGrid As Boolean = False
    Private Sub Grid_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid.InitializeLayout
        If fGrid Then Exit Sub
        fGrid = True
        Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, Grid, m_Lang)

    End Sub
End Class