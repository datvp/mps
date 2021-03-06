﻿Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinGrid
Public Class frmUnited
    Private WithEvents cls As BLL.BUniteds = BLL.BUniteds.Instance
    Dim clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Dim fselect As Boolean = False
    Dim Sselect As String = ""
    Private fFinish As Boolean = False


#Region "Form "

    Public Overloads Function ShowDialog(ByVal f As Boolean) As String
        fselect = f
        Me.ShowDialog()
        Return Sselect
    End Function

    Private Sub frmUniteds_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Loadlist()
    End Sub


    Private Sub frmUniteds_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Delete And Toolbars.Tools("btnDel").SharedProps.Enabled = True Then
            ' DEL()
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
                    'Case Keys.H
                    '    Me.Edit()
                Case Keys.V
                    T_Layout.PerformClick()
                Case Keys.E
                    T_Export.PerformClick()
                Case Keys.A
                    T_SelectAll.PerformClick()
                Case Keys.I
                    T_ImportExcel.PerformClick()
            End Select
        End If
    End Sub

    Private Sub frmUniteds_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        LabelBottom.Text = ModMain.m_strLableList
        Me.Loadlist()
        Me.Security()
    End Sub

#End Region

#Region "Sub "
    Private f_SecE As Boolean = False
    Private f_SecA As Boolean = False
    Private f_SecD As Boolean = False

    Private Sub Security()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 28)

        f_SecE = m.U
        f_SecA = m.A
        f_SecD = m.D
        Me.Toolbars.Tools("btnAdd").SharedProps.Enabled = f_SecA
        Me.Toolbars.Tools("btnEdit").SharedProps.Enabled = f_SecE
        Me.Toolbars.Tools("btnDel").SharedProps.Enabled = f_SecD
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

    Private Sub Loadlist()
        Dim s_ID As String = ""
        If Not Grid.DataSource Is Nothing Then
            If Not Grid.ActiveRow Is Nothing Then
                If Grid.ActiveRow.Index <> -1 And Not Grid.ActiveRow.Cells Is Nothing Then
                    s_ID = Grid.ActiveRow.Cells("UnitedId").Value
                End If
            End If
        End If

        Grid.DataSource = cls.getListUniteds()

        If s_ID <> "" Then
            If Grid.Rows.Count > 0 Then
                For i As Integer = 0 To Grid.Rows.Count - 1
                    Dim r As UltraGridRow = Grid.Rows(i)
                    If r.ChildBands Is Nothing Then
                        If r.Cells("UnitedId").Value = s_ID Then
                            r.Activated = True
                            Exit Sub
                        End If
                    Else
                        FindItem(r, "UnitedId", s_ID)
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
        Dim frm As New frmUnitedDetail
        Dim result = frm.ShowDialog("")
        If result <> "" Then
            Me.Loadlist()
        End If
    End Sub

    Private Sub Edit()
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub
        If Not r.ChildBands Is Nothing Then Exit Sub
        Dim frm As New frmUnitedDetail
        Dim result = frm.ShowDialog(r.Cells("UnitedId").Value)
        If result <> "" Then
            Me.Loadlist()
            For i As Integer = 0 To Grid.Rows.Count - 1
                If Grid.Rows(i).Cells("UnitedId").Value.ToString = result Then
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
                    id = Grid.Selected.Rows(i).Cells("UnitedId").Value
                    name = Grid.Selected.Rows(i).Cells("UnitedName").Value

                    If Not Me.DeleteDetail(id) Then
                        Exit For
                    End If
                Next
            Else 'xóa 1 dòng
                id = r.Cells("UnitedId").Value
                name = r.Cells("UnitedName").Value

                If ShowMsgYesNo(m_MsgAskDel, m_MsgCaption) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If

                If Not Me.DeleteDetail(id) Then
                    Loadlist()
                    Exit Sub
                End If
            End If

            Me.Loadlist()
        Catch ex As Exception
            MsgBox(ex.Message)
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
            Sselect = r.Cells("UnitedId").Value
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

            result.Activated = True
            r = result

        End If
        '-------

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
#End Region

    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        ShowMsg(messege)
    End Sub

    Private Sub T_ImportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_ImportExcel.Click
        Dim frm As New frmImportDatas
        Dim ok = frm.ShowDialog(Me.Name, lblTitle.Text)
        If ok Then
            Me.Loadlist()
        End If
    End Sub
End Class