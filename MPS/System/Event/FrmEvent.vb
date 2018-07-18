Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinToolbars

Public Class FrmEvent
    Private WithEvents cls As BLL.BEvent = BLL.BEvent.Instance
    Dim clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Dim m_isLoad As Boolean = False

    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub

#Region "DIALOG-Chọn sự kiện từ danh mục khác"
    Private sSelect As String = ""
    Private fSelect As Boolean = False
    Public Overloads Function ShowDialog(ByVal f_Select As Boolean) As String
        fSelect = f_Select
        Me.ShowDialog()
        Return sSelect
    End Function


#End Region

#Region "FORM"
    Private Sub FrmEvent_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If m_isLoad Then
            LoadList()
            Grid.Focus()
        Else
            m_isLoad = True
            Grid.Focus()
        End If
    End Sub
    Private Sub FrmEvent_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If fSelect Then
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If

        Else 'khi xem danh sách từ danh mục khác thì không đươc thực hiện các chức năng này
            If e.KeyCode = Keys.F5 Then
                Me.LoadList()
            End If
            If e.KeyCode = Keys.Delete Then
                Me.T_DEL.PerformClick()
                'Me.DEL()
            End If
            If e.Control Then
                Select Case e.KeyCode
                    Case Keys.V
                        Me.T_Layout.PerformClick()
                    Case Keys.E
                        Me.T_Export.PerformClick()
                    Case Keys.A
                        Me.T_SelectAll.PerformClick()
                End Select

            End If

        End If
    End Sub
    Private Sub FrmEvent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me,UltraLabel1.Text)
        LabelStatus.Text = ModMain.m_strLableStatus
        Security()
        If Not fSelect Then
            Dim cboTime As ComboBoxTool = CType(tbManager.Toolbars("tool1").Tools("cboTime"), ComboBoxTool)
            Dim cboType As ComboBoxTool = CType(tbManager.Toolbars("tool1").Tools("cboType"), ComboBoxTool)
            cboTime.SelectedIndex = 1

            Dim tb As DataTable = cls.getListType
            If tb.Rows.Count > 0 Then
                For Each dr As DataRow In tb.Rows
                    If dr("i_ID") = 0 Then
                        cboType.ValueList.ValueListItems.Add(dr("i_ID"), m_SelectAll) ' clsLang.getLang(iLang, 2)
                    Else
                        cboType.ValueList.ValueListItems.Add(dr("i_ID"), dr("s_Name"))
                    End If
                Next
                cboType.SelectedIndex = 0
            End If

            LoadList()
        End If

    End Sub
#End Region

#Region "SUB"
    Private Sub Security()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 53)
        tbManager.Tools("btnDel").SharedProps.Enabled = m.D
        T_DEL.Enabled = m.D
    End Sub
    Private Sub LoadList()
        Dim cboTime As ComboBoxTool = CType(tbManager.Toolbars("tool1").Tools("cboTime"), ComboBoxTool)
        Dim cboType As ComboBoxTool = CType(tbManager.Toolbars("tool1").Tools("cboType"), ComboBoxTool)
        Dim tb As DataTable
        Dim str As String = ""

        If cboTime.SelectedIndex = 7 Then
            tb = cls.getList(cboTime.SelectedIndex, dtFrom.Value, dtTo.Value)
        Else
            tb = cls.getList(cboTime.SelectedIndex, Now, Now)
            If cboType.SelectedIndex <> -1 Then
                If cboType.SelectedIndex <> 0 Then
                    str = "i_TypeID=" & cboType.Value
                    tb.DefaultView.RowFilter = str
                End If

            End If

        End If

        If Not tb Is Nothing Then
            Grid.DataSource = tb
        End If
        'thêm
        'If Grid.Rows.Count > 0 Then
        '    Me.LabelStatus.Text = "Click phải chọn menu chức năng..."
        'End If
    End Sub
    Public Sub DEL()
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing OrElse r.Index = -1 Then Exit Sub

        Dim id As String = ""
        Dim name As String = ""

        Try
            If Grid.Selected.Rows.Count > 1 Then 'xóa nhiếu dòng
                Dim sMsgDel As String = m_PathDelFirst & Grid.Selected.Rows.Count & m_PathDelLast
                If ShowMsgYesNoCancel(sMsgDel, m_MsgCaption) <> Windows.Forms.DialogResult.Yes Then Exit Sub


                For i As Integer = 0 To Grid.Selected.Rows.Count - 1
                    id = Grid.Selected.Rows(i).Cells("s_ID").Value

                    If Not cls.DELETEDB(id) Then
                        'ShowMsg("Quá trình xóa sự kiện có lỗi. Kiểm tra và thực hiện lại !")
                        ShowMsg(m_DelErrorOneItems, m_MsgCaption)
                        LoadList()
                        Exit Sub
                    End If

                Next

            Else 'xóa 1 dòng
                id = r.Cells("s_ID").Value

                If ShowMsgYesNoCancel(m_MsgAskDel, m_MsgCaption) <> Windows.Forms.DialogResult.Yes Then Exit Sub

                If Not cls.DELETEDB(id) Then
                    ShowMsg(m_DelErrorOneItems, m_MsgCaption)
                    Exit Sub
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
        '    rp = cls.InitReport(Application.StartupPath & "\Reports\DanhMuc\rptQuocGia.rpt")
        '    cls.SetParameter(rp, ModMain.m_CompanyName, ModMain.m_CompanyAddress)

        '    Dim frm As New FrmReport
        '    frm.rpt.ReportSource = rp
        '    frm.Show()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub
    Public Sub SelectAll(ByVal gridName As Infragistics.Win.UltraWinGrid.UltraGrid)
        
        Dim r As Infragistics.Win.UltraWinGrid.UltraGridRow = gridName.ActiveRow
        If Not r Is Nothing Then
            If r.ParentRow Is Nothing Then
                If gridName.DataSource Is Nothing Then Exit Sub
                gridName.Selected.Rows.AddRange(CType(gridName.Rows.All, Infragistics.Win.UltraWinGrid.UltraGridRow()))
            Else
                Dim rParent As Infragistics.Win.UltraWinGrid.UltraGridRow = r.ParentRow
                For i As Integer = 0 To rParent.ChildBands.Count - 1
                    gridName.Selected.Rows.AddRange(CType(rParent.ChildBands(i).Rows.All, Infragistics.Win.UltraWinGrid.UltraGridRow()))
                Next
            End If
        End If

    End Sub

#End Region

#Region "GRID"
    Private Sub Grid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        If e.KeyCode = Keys.Delete Then
            Me.T_DEL.PerformClick()
        End If
    End Sub
    Private Sub Grid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grid.MouseDown
        If fSelect Then
            Exit Sub
        End If
        If e.Button <> Windows.Forms.MouseButtons.Right Then Exit Sub
        Dim r As UltraGridRow = Grid.ActiveRow
        Dim element As Infragistics.Win.UIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(New Point(e.X, e.Y))
        Dim result As UltraGridRow = element.GetContext(GetType(UltraGridRow))

        'thêm
        'If r Is Nothing Then
        '    Me.LabelStatus.Text = ""
        'ElseIf r.Index = -1 Then
        '    Me.LabelStatus.Text = ""
        'Else
        '    Me.LabelStatus.Text = "Click phải chọn menu chức năng..."
        'End If

        If result Is Nothing OrElse result.Index = -1 Then
            Exit Sub
        End If
        If Not result.IsDataRow Then
            Exit Sub
        End If

        If Not result.IsDataRow Then
            Exit Sub
        End If

        If Not Grid.Selected Is Nothing Then
            Grid.Selected.Rows.Clear()
        End If
        result.Activated = True
        r = result

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ctMenu.Show(Grid, New Point(e.X, e.Y))
        End If

    End Sub
#End Region

#Region "CONTEXT MENU"
    Private Sub T_DEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_DEL.Click
        DEL()
    End Sub
    Private Sub T_Layout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Layout.Click
        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, Grid, m_Lang)
        frm.ShowDialog()
    End Sub
    Private Sub T_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New VsoftBMS.Ulti.FrmFind(Grid, m_Lang)
        frm.ShowDialog()
    End Sub
    'Private Sub T_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.ViewReport()
    'End Sub
    Private Sub T_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Export.Click
        ExportExcel(Grid)
    End Sub


#End Region

    Private Sub tbManager_AfterToolCloseup(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolDropdownEventArgs) Handles tbManager.AfterToolCloseup
        Dim cboTime As ComboBoxTool = CType(tbManager.Toolbars("tool1").Tools("cboTime"), ComboBoxTool)
        Dim cboType As ComboBoxTool = CType(tbManager.Toolbars("tool1").Tools("cboType"), ComboBoxTool)
        Dim tb As New DataTable
        Dim str As String = ""
        If cboTime.SelectedIndex <> 7 Then
            tb = cls.getList(cboTime.SelectedIndex, Now, Now)
        End If

        Select Case e.Tool.Key
            Case "cboTime"

                If cboTime.SelectedIndex <> 7 Then
                    If cboType.SelectedIndex <> -1 Then
                        If cboType.SelectedIndex <> 0 Then
                            str = "i_TypeID=" & cboType.Value
                            tb.DefaultView.RowFilter = str
                        End If

                    End If

                Else
                    Dim frm As New FrmSelectTime(dtFrom.Value, dtTo.Value)
                    Dim isView As Boolean = False
                    frm.ShowDialog(dtFrom.Value, dtTo.Value, isView)
                    If isView Then
                        tb = cls.getList(cboTime.SelectedIndex, dtFrom.Value, dtTo.Value)
                    End If

                    If cboType.SelectedIndex <> -1 Then
                        If cboType.SelectedIndex <> 0 Then
                            str = "i_TypeID=" & cboType.Value
                            tb.DefaultView.RowFilter = str
                        End If

                    End If

                End If

                If Not tb Is Nothing Then
                    Grid.DataSource = tb
                End If

            Case "cboType"
                If cboTime.SelectedIndex = 7 Then
                    tb = cls.getList(cboTime.SelectedIndex, dtFrom.Value, dtTo.Value)
                End If

                If cboType.SelectedIndex <> -1 Then
                    If cboType.SelectedIndex <> 0 Then
                        str = "i_TypeID=" & cboType.Value
                        tb.DefaultView.RowFilter = str
                    End If

                End If

                If Not tb Is Nothing Then
                    Grid.DataSource = tb
                End If

        End Select

    End Sub
    Private Sub tbManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles tbManager.ToolClick
        Select Case e.Tool.Key
            Case "btnDEL"
                Me.T_DEL.PerformClick()
        End Select
    End Sub

    'Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
    '    Dim f As Form = Me.ParentForm
    '    Dim fChild As Form = f.ActiveMdiChild
    '    If Not fChild Is Nothing Then
    '        fChild.Close()
    '    End If
    'End Sub

    Private Sub cbTypeEvent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If cbTypeEvent.SelectedValue Is Nothing Then Exit Sub
        'If cbTypeEvent.SelectedIndex = 0 Then
        '    CType(Grid.DataSource, DataTable).DefaultView.RowFilter = Nothing
        'Else
        '    CType(Grid.DataSource, DataTable).DefaultView.RowFilter = "i_TypeID=" & Me.cbTypeEvent.SelectedValue

        'End If
    End Sub

    
    Private Sub T_SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_SelectAll.Click
        SelectAll(Grid)
    End Sub
    Dim fGrid As Boolean = False
    Private Sub Grid_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid.InitializeLayout
        If fGrid Then Exit Sub
        fGrid = True
        Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, Grid, m_Lang)
        Grid.DisplayLayout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
    End Sub

    Private Sub T_Refresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Refresh.Click
        Me.LoadList()
    End Sub
End Class