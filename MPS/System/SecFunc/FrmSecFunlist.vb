Imports Infragistics.Win.UltraWinGrid
Public Class FrmSecFunlist
    Private WithEvents cls As New BLL.BFuncList
    Dim clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid

    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub
    '22/04/2009
    Private Sub FrmSecFunlist_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F2 Then Me.bntSave.PerformClick()
        If e.KeyCode = Keys.Delete Then Me.btnDelete.PerformClick()
        If e.Control Then
            If e.KeyCode = Keys.V Then Me.btnEditScreen.PerformClick()
        End If

    End Sub

    Private Sub FrmSecFunlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = ModMain.m_sysColor
        Me.Text = Formtitle
        Me.Icon = My.Resources.VsoftBMS_logo
        LoadGroup()
        Me.Grid.DataSource = cls.getList()
        clsuf.FormatGridFromDB(Me.Name, Grid, m_Lang)
        txtID.Text = cls.getNextID
    End Sub

    Private Sub LoadGroup()
        Dim tb As DataTable = cls.getList(1)
        Dim dr As DataRow = tb.NewRow
        dr("i_ID") = 0
        dr("s_Name") = "None"
        tb.Rows.InsertAt(dr, 0)
        cmbLevel.ValueMember = "i_ID"
        cmbLevel.DisplayMember = "s_Name"
        Me.cmbLevel.DataSource = tb

    End Sub
    Public Sub DEL()
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub

        If ShowMsgYesNoCancel(m_MsgAskDel, m_MsgCaption) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
        End If
        If cls.DELETEDB(r.Cells("i_ID").Value) Then
            Grid.DataSource = cls.getList
        End If
    End Sub
    Private Sub Edit()
        Dim r As UltraGridRow = Grid.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub
        Dim m As Model.MFuncList = cls.getInfo(r.Cells("i_ID").Value)
        If m.ID <> 0 Then
            ChUpdate.Checked = True
            txtID.Text = m.ID
            txtID.Enabled = False
            txtName.Text = m.Name
            chValid.Checked = m.valid
            cmbLevel.SelectedValue = m.Uplevel
        End If
    End Sub

    Private Sub btnEditScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditScreen.Click
        Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, Grid, m_lang)
        frm.ShowDialog()

    End Sub
    Private Sub bntSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntSave.Click
        If txtName.Text.Trim = "" Then
            ShowMsg("Nhập tên chức năng !", 111)
            txtName.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtID.Text) Then
            ShowMsg("Giá trị không hợp lệ !", 112)
            txtID.Focus()
            Exit Sub
        End If

        If txtID.Text = "" Then txtID.Text = "0"
        If Not ChUpdate.Checked Then
            If cls.CheckDul(CDbl(txtID.Text)) Then
                txtID.Focus()
                ShowMsg("ID bị trùng !", 113)
                Exit Sub
            End If
        End If
        Dim m As New Model.MFuncList
        m.ID = CInt(txtID.Text)
        m.Name = txtName.Text.Trim
        m.Uplevel = cmbLevel.SelectedValue
        m.valid = chValid.Checked
        If cls.UPDATEDB(m, ChUpdate.Checked) Then
            txtID.Text = cls.getNextID
            txtID.Enabled = True
            ChUpdate.Checked = False

            txtName.Text = ""
            chValid.Checked = True
            If m.Uplevel = 0 Then
                LoadGroup()
            End If
            Me.Grid.DataSource = cls.getList()
            txtName.Focus()
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Me.DEL()
    End Sub

    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        Me.Edit()
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

   
    Private Sub Grid_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid.InitializeLayout
        Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
    End Sub
End Class