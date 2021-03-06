Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTree
Public Class FrmFuncRight
    Private WithEvents cls As BLL.BFuncRight = BLL.BFuncRight.Instance
    Dim clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Private WithEvents clsUser As New BLL.BSecUser
    Private WithEvents clsgroupUser As New BLL.BGroupUser
    Dim ID_G_U As String = ""
    Dim IDGroup As String = ""
    'Dim Str As String = ""
#Region "Form "

    Private Sub clsgroupUser__errorRaise(ByVal messege As String) Handles clsgroupUser._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub

    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub
    Private Sub clsUser__errorRaise(ByVal messege As String) Handles clsUser._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub


    Private Sub FrmFuncRight_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F2 Then mnu_Add.PerformClick()
        If e.KeyCode = Keys.F5 Then mnuRefresh.PerformClick()
        If e.KeyCode = Keys.Delete Then
            T_Del.PerformClick()
        End If
        If e.Control = True Then
            Select Case e.KeyCode
                Case Keys.T
                    T_Add.PerformClick()
                Case Keys.X
                    T_view.PerformClick()
            End Select
        End If
    End Sub


    Private Sub FrmFuncRight_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Splitter1.BackColor = ModMain.m_sysColor
        ModMain.SetTitle(Me,UltraLabel1.Text)
        LoadTreeview()

        LoadFunc(ModMain.m_UIDLogin.Trim.ToLower.ToString)
        TV.ExpandAll()
        Dim f As Boolean = False
        For i As Integer = 0 To TV.Nodes.Count - 1
            Dim T As UltraTreeNode = TV.Nodes.Item(i)
            For j As Integer = 0 To T.Nodes.Count - 1
                If T.Nodes.Item(j).ToString.ToLower = ModMain.m_UIDLogin.Trim.ToLower Then
                    Dim r As UltraTreeNode = T.Nodes.Item(j)
                    r.Selected = True
                    TV.ActiveNode = r
                    '  Str = TV.ActiveNode.DataKey.ToString
                    f = True
                    Exit For
                End If
            Next
            If f Then
                Exit For
            End If
        Next

        Security()

    End Sub

    Private Sub Reload(ByVal UserID As String)
        LoadTreeview()
        Dim f As Boolean = False
        For i As Integer = 0 To TV.Nodes.Count - 1
            Dim T As UltraTreeNode = TV.Nodes.Item(i)
            For j As Integer = 0 To T.Nodes.Count - 1
                If T.Nodes.Item(j).ToString.ToLower = UserID.Trim.ToLower Then
                    Dim r As UltraTreeNode = T.Nodes.Item(j)
                    r.Selected = True
                    TV.ActiveNode = r
                    f = True
                    Exit For
                End If
            Next
            If f Then
                Exit For
            End If
        Next
        TV.ExpandAll()
    End Sub
#End Region

#Region "Sub"
    
    Private Sub Security()
        Dim mi As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 17)
        mnu_Add.Enabled = mi.U
    End Sub
    Private Sub LoadFunc(ByVal UID As String)
        Dim ds As DataSet = cls.getFuncRight(UID, False)
        Grid.DataSource = ds
    End Sub
    Private Sub Save()
        Dim r As UltraTreeNode = TV.ActiveNode
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub
        If r.Parent Is Nothing Then
            If r.Nodes.Count = 0 Then
                ShowMsg("Không có người dùng nào thuộc nhóm này!", 104)
                Exit Sub
            End If
            If Not SaveRight(r.DataKey.ToString) Then
                ShowMsg("Lưu dữ liệu bị lỗi !")
                Exit Sub
            End If
            For i As Integer = 0 To r.Nodes.Count - 1
                Dim T As UltraTreeNode = r.Nodes.Item(i)
                If Not SaveRight(T.DataKey.ToString) Then
                    ShowMsg("Lưu dữ liệu bị lỗi !")
                    Exit Sub
                End If
            Next
        Else
            If Not SaveRight(r.DataKey.ToString) Then
                ShowMsg("Lưu dữ liệu bị lỗi !")
                Exit Sub
            End If
        End If
        ShowMsgInfo("Đã lưu dữ liệu !", 10)

    End Sub
    Public Function SaveRight(ByVal UID As String) As Boolean
        If Not cls.DeleteDB(UID) Then
            Return False
        End If
        For Each r As UltraGridRow In Grid.Rows
            Dim m As New Model.MFuncRight
            m.A = IsNull(r.Cells("A").Value, False)
            m.D = IsNull(r.Cells("D").Value, False)
            m.FuncID = IsNull(r.Cells("i_ID").Value, 0)
            m.IDSort = IsNull(r.Cells("IDSort").Value, 0)
            m.R = IsNull(r.Cells("R").Value, False)
            m.U = IsNull(r.Cells("U").Value, False)
            m.sFuncID = IsNull(r.Cells("sFunID").Value, "")
            m.UID = UID
            If Not cls.UPDATEDB(m) Then
                Exit Function
            Else
                m = New Model.MFuncRight
                For Each rChild As Infragistics.Win.UltraWinGrid.UltraGridRow In r.ChildBands(0).Rows
                    m.A = IsNull(rChild.Cells("A").Value, False)
                    m.D = IsNull(rChild.Cells("D").Value, False)
                    m.FuncID = IsNull(rChild.Cells("i_ID").Value, 0)
                    m.IDSort = IsNull(rChild.Cells("IDSort").Value, 0)
                    m.R = IsNull(rChild.Cells("R").Value, False)
                    m.U = IsNull(rChild.Cells("U").Value, False)
                    m.sFuncID = IsNull(rChild.Cells("sFunID").Value, "")
                    m.UID = UID
                    If Not cls.UPDATEDB(m) Then
                        Exit Function
                    End If
                Next
            End If
        Next
        Return True
    End Function
    'thêm mới người dùng
    Private Sub AddUser()
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 47) 'lấy quyền của User
        If ModMain.m_UIDLogin.Trim.ToLower <> "admin" Then
            Dim mUser As Model.MSecUser = clsUser.getInfo(ModMain.m_UIDLogin)
            If Not m.A Then
                ShowMsg("Người dùng không được cấp quyền thêm mới", 43)
                Exit Sub
            End If
        End If
        Dim frm As New FrmNewUser
        Dim UID As String = frm.ShowDialog(ID_G_U)
        If UID <> "" Then
            Reload(UID)
        End If
    End Sub

    'Xem / hiệu chỉnh
    Private Sub EditUser()
        Dim r As UltraTreeNode = TV.ActiveNode
        If r Is Nothing Then Exit Sub
        If r.Parent Is Nothing Then Exit Sub
        Dim GroupEdit As String = ""
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 47) 'lấy quyền của User
        Dim frm As New FrmNewUser
        If ModMain.m_UIDLogin.Trim.ToLower <> "admin" Then
            frm.btnSave.Enabled = m.U
            frm.LinklalthaydoiMK.Visible = m.U
            If ID_G_U = ModMain.m_UIDLogin Then
                frm.btnSave.Enabled = True
                frm.LinklalthaydoiMK.Visible = True
            End If
        End If
        frm.LoadInfo(ID_G_U)

        Dim Edit As String = frm.ShowDialog(GroupEdit)
        If Edit <> "" And GroupEdit <> IDGroup Then
            Reload(Edit)
        End If

    End Sub

    Private Sub Del()
        Dim r As UltraTreeNode = TV.ActiveNode
        If r Is Nothing Then Exit Sub
        If r.Parent Is Nothing Then Exit Sub

        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, 47) 'lấy quyền của User
        If Not m.D Then
            ShowMsg("Người dùng không được cấp quyền chạy chức năng này !", 43)
            Exit Sub
        End If
        If ID_G_U.Trim.ToLower = "admin" Then
            ShowMsg("Không được xóa người dùng Admin !", 106)
            Exit Sub
        End If
        If ModMain.m_UIDLogin.Trim.ToLower = ID_G_U.Trim.ToLower Then
            ShowMsg("Người dùng đang được sử dụng !", 107)
            Exit Sub
        End If
        If ShowMsgYesNo(m_MsgAskDel, m_MsgCaption) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        If Not clsUser.DeleteDB(ID_G_U) Then
            ShowMsg(m_DelError, m_MsgCaption)
            Exit Sub
        End If
        Reload(ModMain.m_UIDLogin)
    End Sub

    Private Sub FormatLangGrid()
        clsuf.FormatGridFromDB(Me.Name, Grid, m_Lang)
        Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        Dim sName As String = "s_Name"
        
        For k As Integer = 0 To Grid.DisplayLayout.Bands.Count - 1

            Grid.DisplayLayout.Bands(k).Columns(sName).Hidden = False
            Grid.DisplayLayout.Bands(k).Columns(sName).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            Grid.DisplayLayout.Bands(k).Columns(sName).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            Grid.DisplayLayout.Bands(k).Columns(sName).Header.VisiblePosition = 0
            Grid.DisplayLayout.Bands(k).Columns(sName).Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left
            Grid.DisplayLayout.Bands(k).Columns(sName).Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle

            Grid.DisplayLayout.Bands(k).Columns(sName).CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

            Grid.DisplayLayout.Bands(k).Columns("R").Hidden = False
            Grid.DisplayLayout.Bands(k).Columns("R").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            Grid.DisplayLayout.Bands(k).Columns("R").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            Grid.DisplayLayout.Bands(k).Columns("R").Header.VisiblePosition = 1
            Grid.DisplayLayout.Bands(k).Columns("R").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
            Grid.DisplayLayout.Bands(k).Columns("R").Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle

            Grid.DisplayLayout.Bands(k).Columns("R").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText

            Grid.DisplayLayout.Bands(k).Columns("A").Hidden = False
            Grid.DisplayLayout.Bands(k).Columns("A").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            Grid.DisplayLayout.Bands(k).Columns("A").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            Grid.DisplayLayout.Bands(k).Columns("A").Header.VisiblePosition = 2
            Grid.DisplayLayout.Bands(k).Columns("A").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
            Grid.DisplayLayout.Bands(k).Columns("A").Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle

            Grid.DisplayLayout.Bands(k).Columns("A").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText

            Grid.DisplayLayout.Bands(k).Columns("U").Hidden = False
            Grid.DisplayLayout.Bands(k).Columns("U").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            Grid.DisplayLayout.Bands(k).Columns("U").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            Grid.DisplayLayout.Bands(k).Columns("U").Header.VisiblePosition = 3
            Grid.DisplayLayout.Bands(k).Columns("U").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
            Grid.DisplayLayout.Bands(k).Columns("U").Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle

            Grid.DisplayLayout.Bands(k).Columns("U").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText

            Grid.DisplayLayout.Bands(k).Columns("D").Hidden = False
            Grid.DisplayLayout.Bands(k).Columns("D").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            Grid.DisplayLayout.Bands(k).Columns("D").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            Grid.DisplayLayout.Bands(k).Columns("D").Header.VisiblePosition = 4
            Grid.DisplayLayout.Bands(k).Columns("D").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
            Grid.DisplayLayout.Bands(k).Columns("D").Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle
            Grid.DisplayLayout.Bands(k).Columns("D").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Next

    End Sub

#End Region

#Region "Grid "

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Dim fExit As Boolean = False
        Grid_MouseDown(sender, e, fExit)
        If fExit = True Then Exit Sub

        If Grid.ActiveRow Is Nothing Then Exit Sub
        If Grid.ActiveRow.ChildBands IsNot Nothing Then
            If Grid.ActiveRow.IsExpanded = True Then
                Grid.ActiveRow.CollapseAll()
            Else
                Grid.ActiveRow.ExpandAll()
            End If
        End If
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.F Then
                Dim frm As New VsoftBMS.Ulti.FrmFind(Grid, m_Lang)
                frm.ShowDialog()
            End If
        End If

        If e.Control And e.KeyCode = Keys.Z Then
            Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, Grid, m_Lang)
            frm.ShowDialog()
        End If
    End Sub

    Private Sub GridUser_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles GridUser.AfterSelectChange
        Dim r As UltraGridRow = GridUser.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub
        Dim sUser As String = ""
        If r.ParentRow Is Nothing Then
            sUser = r.Cells("s_ID").Value
        Else
            sUser = r.Cells("s_UID").Value
        End If
        LoadFunc(sUser)
    End Sub
    Private Sub GridUser_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridUser.InitializeLayout
        If GridUser.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands("Group").Columns.Count - 1
            e.Layout.Bands("Group").Columns(i).Hidden = True
        Next

        e.Layout.Bands("Group").Columns("s_Group_Name").Hidden = False
        e.Layout.Bands("Group").Columns("s_Group_Name").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
        e.Layout.Bands("Group").Columns("s_Group_Name").Header.Caption = "Nhóm"

        For i As Integer = 0 To e.Layout.Bands("Child").Columns.Count - 1
            e.Layout.Bands("Child").Columns(i).Hidden = True
        Next

        e.Layout.Bands("Child").Columns("s_UID").Hidden = False
        e.Layout.Bands("Child").Columns("s_UID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
        e.Layout.Bands("Child").Columns("s_UID").Header.Caption = "Người dùng"

        e.Layout.Rows.ExpandAll(True)
    End Sub
    Private Sub Grid_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid.CellChange
        Dim r As Infragistics.Win.UltraWinGrid.UltraGridRow = Grid.ActiveRow
        If r.Band.Key.Trim.ToUpper = "tbParent".ToUpper Then
            If r.ChildBands.Count > 0 Then
                e.Cell.Row.Update()
                Dim ss As String = e.Cell.Column.Key
                For Each rChild As Infragistics.Win.UltraWinGrid.UltraGridRow In r.ChildBands(0).Rows
                    rChild.Cells(ss).Value = e.Cell.Value
                    rChild.Update()
                Next
            End If
        Else
            r.Update()
        End If
        ' TV.ActiveNode.DataKey = Str
    End Sub
    Private Sub Grid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, Optional ByRef fExit As Boolean = False) Handles Grid.MouseDown
        Dim element As Infragistics.Win.UIElement = Grid.DisplayLayout.UIElement.ElementFromPoint(e.Location)
        If element Is Nothing Then Exit Sub
        Dim result As UltraGridRow = element.GetContext(GetType(UltraGridRow))

        If result Is Nothing OrElse Not result.IsDataRow OrElse result.Index = -1 Then
            fExit = True
        End If
        ' TV.ActiveNode.DataKey = Str
    End Sub
    Dim fGrid As Boolean = False
    Private Sub Grid_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid.InitializeLayout
        If fGrid Then Exit Sub
        fGrid = True
        FormatLangGrid()
    End Sub

#End Region

#Region "Menu"

    Private Sub mnu_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Add.Click
        Save()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Not m_LoginSystem Then
            Dim f As New FrmPWDSystem
            f.ShowDialog()
        End If
        If m_LoginSystem Then
            Dim frm As New FrmSecFunlist
            frm.ShowDialog()
        End If

    End Sub

    Private Sub T_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Add.Click
        AddUser()
    End Sub

    Private Sub T_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_view.Click
        EditUser()
    End Sub
    Private Sub T_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Del.Click
        Del()
    End Sub
    Private Sub mnuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefresh.Click
        Dim n As UltraTreeNode = TV.ActiveNode
        If n Is Nothing Then
            Me.Reload(n.DataKey)
        Else
            Me.Reload(m_UIDLogin)
        End If

    End Sub
#End Region

#Region "Tree"
    '25/5/09
    Private Sub LoadTreeview()
        Dim tbGroup As DataTable = clsgroupUser.Getlist 'danh sách nhóm
        Dim tbUser As New DataTable

        TV.Nodes.Clear()
        For i As Integer = 0 To tbGroup.Rows.Count - 1
            Dim node As New UltraTreeNode

            node.Text = tbGroup.Rows(i)("s_Group_Name")
            node.Override.NodeAppearance.Image = Me.ImageList1.Images(0)
            node.DataKey = tbGroup.Rows(i)("s_ID")
            tbUser = clsUser.getListUser(tbGroup.Rows(i)("s_ID"))

            For j As Integer = 0 To tbUser.Rows.Count - 1
                Dim nodecon As New UltraTreeNode
                nodecon.Override.NodeAppearance.Image = Me.ImageList1.Images(1)
                nodecon.Text = tbUser.Rows(j)("s_UID")
                nodecon.DataKey = tbUser.Rows(j)("s_UID")
                node.Nodes.Add(nodecon)
            Next

            TV.Nodes.Add(node)
        Next

    End Sub

    Private Sub TV_AfterActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs) Handles TV.AfterActivate
        LoadFunc(e.TreeNode.DataKey.ToString)
    End Sub

    Private Sub TV_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TV.MouseDown
        Me.T_Del.Enabled = True
        Me.T_view.Enabled = True
        Me.T_Add.Enabled = True

        Dim element As Infragistics.Win.UIElement = TV.UIElement.ElementFromPoint(New Point(e.X, e.Y))
        Dim r As UltraTreeNode = element.GetContext(GetType(UltraTreeNode))

        If r Is Nothing Then Exit Sub

        r.Selected = True
        TV.ActiveNode = r
        ID_G_U = r.DataKey


        If e.Button = Windows.Forms.MouseButtons.Right Then
            If r.Parent Is Nothing Then
                Me.T_Del.Enabled = False
                Me.T_view.Enabled = False
            Else
                IDGroup = r.Parent.DataKey 'lấy mã nhóm dùng để hiệu chỉnh
                Me.T_Add.Enabled = False
            End If
            ctMenuUser.Show(TV, New Point(e.X, e.Y))
        End If
    End Sub

#End Region

End Class