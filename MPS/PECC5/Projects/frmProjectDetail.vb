Imports Infragistics.Win.UltraWinGrid

Public Class frmProjectDetail
    Private WithEvents b As BLL.BProjects = BLL.BProjects.Instance
    Private bClient As BLL.BClients = BLL.BClients.Instance

    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        ShowMsg(messege)
    End Sub

    Private projectId As String = ""
    Public Overloads Function ShowDialog(ByVal projectId As String) As String
        Me.projectId = projectId
        Me.ShowDialog()
        Return Me.projectId
    End Function
    Private Sub frm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.S Then
                Me.Save()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub
    Private Sub frmProjectDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        If Me.projectId = "" Then
            Me.LoadComboBox()
        Else
            Me.LoadInfo(Me.projectId)
        End If
    End Sub
    Private Sub LoadProjectGroups()
        Dim tb = b.getListProjectGroups()
        cboProjectGroup.ValueMember = "ProjectGroupId"
        cboProjectGroup.DisplayMember = "ProjectGroupName"
        cboProjectGroup.DataSource = tb
        If cboProjectGroup.DataSource IsNot Nothing Then
            If cboProjectGroup.Rows.Count > 0 Then
                cboProjectGroup.Rows(0).Activate()
            End If
        End If
    End Sub
    Dim isAddProjectType As Boolean
    Private Sub LoadProjectTypes()
        Dim tbType = b.getListProjectTypes()
        Dim m = ModMain.getPermitFunc(ModMain.m_UIDLogin, 10)
        isAddProjectType = m.A
        If m.A Then
            ModMain.AddNewRow(tbType)
        End If
        cboProjectType.ValueMember = "ProjectTypeId"
        cboProjectType.DisplayMember = "ProjectTypeName"
        cboProjectType.DataSource = tbType
        If cboProjectType.DataSource IsNot Nothing Then
            If cboProjectType.Rows.Count > 0 Then
                cboProjectType.Rows(0).Activate()
            End If
        End If
    End Sub
    Private Sub LoadComboBox()
        Me.LoadProjectGroups()
        Me.LoadProjectTypes()
        Me.LoadConstructionLevels()
        Me.LoadClients()

        Dim tbPerformUnit = b.getListPerformanceUnit()
        cboPerformUnit.ValueMember = "Id"
        cboPerformUnit.DisplayMember = "Id"
        cboPerformUnit.DataSource = tbPerformUnit
        If cboPerformUnit.DataSource IsNot Nothing Then
            If cboPerformUnit.Rows.Count > 0 Then
                cboPerformUnit.Rows(0).Activate()
            End If
        End If

        Dim tbLengthUnit = b.getListLengthUnit()
        cboLengthUnit.ValueMember = "Id"
        cboLengthUnit.DisplayMember = "Id"
        cboLengthUnit.DataSource = tbLengthUnit
        If cboLengthUnit.DataSource IsNot Nothing Then
            If cboLengthUnit.Rows.Count > 0 Then
                cboLengthUnit.Rows(0).Activate()
            End If
        End If

    End Sub
    Dim isAddConstructionLevel As Boolean
    Private Sub LoadConstructionLevels()
        Dim tbLevel = b.getListConstructionLevels()
        Dim m = ModMain.getPermitFunc(ModMain.m_UIDLogin, 27)
        isAddConstructionLevel = m.A
        If m.A Then
            ModMain.AddNewRow(tbLevel)
        End If
        cboConstructionLevel.ValueMember = "ConstructionLevelId"
        cboConstructionLevel.DisplayMember = "ConstructionLevelName"
        cboConstructionLevel.DataSource = tbLevel
        If cboConstructionLevel.DataSource IsNot Nothing Then
            If cboConstructionLevel.Rows.Count > 0 Then
                cboConstructionLevel.Rows(0).Activate()
            End If
        End If
    End Sub
    Dim isAddClient As Boolean
    Private Sub LoadClients()
        Dim tbClient = bClient.getListClients()
        Dim m = ModMain.getPermitFunc(ModMain.m_UIDLogin, 6)
        isAddClient = m.A
        If m.A Then
            ModMain.AddNewRow(tbClient)
        End If
        cboClient.ValueMember = "ClientId"
        cboClient.DisplayMember = "ClientName"
        cboClient.DataSource = tbClient
    End Sub
    Private Sub ClearInfo()
        Dim m As New Model.MProject
        txtProjectId.Text = m.ProjectId
        txtProjectId.Enabled = True
        txtProjectName.Text = m.ProjectName
        txtPerformance.Text = "0"
        txtLength.Text = "0"
        txtNote.Text = m.Note
    End Sub
    Private Sub LoadInfo(ByVal ProjectId As String)
        Dim m = b.getProjectDetailById(ProjectId)
        If m.ProjectId = "" Then Exit Sub
        Me.LoadComboBox()
        txtProjectId.Text = m.ProjectId
        txtProjectId.Enabled = False
        txtProjectName.Text = m.ProjectName
        cboProjectType.Value = m.ProjectTypeId
        cboProjectGroup.Value = m.ProjectGroupId
        cboConstructionLevel.Value = m.ConstructionLevelId
        cboClient.Value = m.ClientId
        txtPerformance.Text = m.Performance
        cboPerformUnit.Value = m.PerformanceUnit
        txtLength.Text = m.Length
        cboLengthUnit.Value = m.LengthUnit
        txtNote.Text = m.Note

    End Sub
    Private Function setInfo() As Model.MProject
        Dim m As New Model.MProject
        m.BranchId = ModMain.m_BranchId
        m.ProjectId = txtProjectId.Text
        m.ProjectName = txtProjectName.Text
        If cboProjectType.Value IsNot Nothing Then
            m.ProjectTypeId = cboProjectType.Value
        End If
        If cboProjectGroup.Value IsNot Nothing Then
            m.ProjectGroupId = cboProjectGroup.Value
        End If
        If cboConstructionLevel.Value IsNot Nothing Then
            m.ConstructionLevelId = cboConstructionLevel.Value
        End If
        If cboClient.Value IsNot Nothing Then
            m.ClientId = cboClient.Value
        End If
        m.Performance = CInt(txtPerformance.Text)
        If cboPerformUnit.Value IsNot Nothing Then
            m.PerformanceUnit = cboPerformUnit.Value
        End If
        m.Length = CInt(txtLength.Text)
        If cboLengthUnit.Value IsNot Nothing Then
            m.LengthUnit = cboLengthUnit.Value
        End If
        m.Note = txtNote.Text
        m.Status = Statuses.Active
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MProject) As Boolean
        If m.ProjectId = "" Then
            ShowMsg("Nhập mã số dự án")
            txtProjectId.Focus()
            Return False
        End If

        If m.ProjectName = "" Then
            ShowMsg("Nhập tên dự án")
            txtProjectName.Focus()
            Return False
        End If

        If m.ProjectGroupId = "" Then
            ShowMsg("Chọn nhóm dự án")
            cboProjectGroup.Focus()
            Return False
        End If

        If m.ProjectTypeId = "" Then
            ShowMsg("Chọn phân loại")
            cboProjectType.Focus()
            Return False
        End If
        If m.ConstructionLevelId = "" Then
            ShowMsg("Chọn phân cấp công trình")
            cboConstructionLevel.Focus()
            Return False
        End If
        If m.ClientId = "" Then
            ShowMsg("Chọn khách hàng")
            cboClient.Focus()
            Return False
        End If
        If m.PerformanceUnit = "" Then
            ShowMsg("Chọn đơn vị công suất lắp đặt")
            cboPerformUnit.Focus()
            Return False
        End If
        If m.LengthUnit = "" Then
            ShowMsg("Chọn đơn vị chiều dài đấu nối")
            cboLengthUnit.Focus()
            Return False
        End If


        Return True
    End Function
    Public Sub Save()
        Dim m = Me.setInfo()
        If Not CheckOK(m) Then Exit Sub

        If b.updateDB(m) Then
            If Me.projectId <> "" Then
                Me.Close()
            Else
                Me.projectId = m.ProjectId
                Me.ClearInfo()
            End If
            ShowMsgInfo(m_MsgSaveSuccess)
        Else
            ShowMsg(m_SaveDataError)
        End If
    End Sub

    Private Sub cboProjectGroup_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboProjectGroup.InitializeLayout
        If Me.cboProjectGroup.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("ProjectGroupName").Hidden = False
    End Sub

    Private Sub cboProjectType_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProjectType.AfterCloseUp
        Dim cbo As UltraCombo = sender
        ModMain.FilterOwnerCombo_CloseUp(cbo, "")
        If cbo.Value Is Nothing Then Exit Sub
        If cbo.Value = "" Then
            Dim frm As New frmProjectTypeDetail
            Dim result = frm.ShowDialog("")
            If result <> "" Then
                Me.LoadProjectTypes()
                cboProjectType.Value = result
            Else
                cboProjectType.Value = Nothing
            End If
        End If
    End Sub
    Private Sub cboProjectType_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboProjectType.InitializeLayout
        If Me.cboProjectType.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("ProjectTypeName").Hidden = False
        If isAddProjectType AndAlso cboProjectType.Rows.Count > 0 Then
            With cboProjectType.Rows(cboProjectType.Rows.Count - 1)
                .Appearance.BackColor = ModMain.m_AddColor
                .Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            End With
        End If
    End Sub

    Private Sub cboConstructionLevel_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConstructionLevel.AfterCloseUp
        Dim cbo As UltraCombo = sender
        ModMain.FilterOwnerCombo_CloseUp(cbo, "")
        If cbo.Value Is Nothing Then Exit Sub
        If cbo.Value = "" Then
            Dim frm As New frmConstructionLevelDetail
            Dim result = frm.ShowDialog("")
            If result <> "" Then
                Me.LoadConstructionLevels()
                cboConstructionLevel.Value = result
            Else
                cboConstructionLevel.Value = Nothing
            End If
        End If
    End Sub
    Private Sub cboConstructionLevel_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboConstructionLevel.InitializeLayout
        If Me.cboConstructionLevel.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("ConstructionLevelName").Hidden = False

        If isAddConstructionLevel AndAlso cboConstructionLevel.Rows.Count > 0 Then
            With cboConstructionLevel.Rows(cboConstructionLevel.Rows.Count - 1)
                .Appearance.BackColor = ModMain.m_AddColor
                .Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            End With
        End If
    End Sub
    Private Sub cboPerformUnit_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboPerformUnit.InitializeLayout
        If Me.cboPerformUnit.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("Id").Hidden = False
    End Sub
    Private Sub cboLengthUnit_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboLengthUnit.InitializeLayout
        If Me.cboLengthUnit.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("Id").Hidden = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.Save()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

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

    Private Sub cboClient_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClient.AfterCloseUp
        Dim cbo As UltraCombo = sender
        ModMain.FilterOwnerCombo_CloseUp(cbo, "")
        If cbo.Value Is Nothing Then Exit Sub
        If cbo.Value = "" Then
            Dim frm As New frmClientDetail
            Dim result = frm.ShowDialog("")
            If result <> "" Then
                Me.LoadClients()
                cboClient.Value = result
            Else
                cboClient.Value = Nothing
            End If
        End If
    End Sub

    Private Sub cboClient_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboClient.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("ClientName").Hidden = False
        If isAddClient AndAlso cboClient.Rows.Count > 0 Then
            With cboClient.Rows(cboClient.Rows.Count - 1)
                .Appearance.BackColor = ModMain.m_AddColor
                .Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            End With
        End If
    End Sub

    Private Sub cboClient_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboClient.KeyUp
        Dim cbo As UltraCombo = sender
        If e.KeyCode = Keys.Escape Then
            cbo.Text = ""
            FilterOwnerCombo(cbo, "")
            If cbo.IsDroppedDown Then
                cbo.ToggleDropdown()
            End If
            Exit Sub
        End If

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            If cbo.IsDroppedDown Then
                cbo.ToggleDropdown()
            End If
            txtPerformance.Focus()
            Exit Sub
        End If

        If Not cbo.IsDroppedDown Then
            cbo.ToggleDropdown()
            Dim txt = cbo.Textbox
            txt.SelectionStart = txt.Text.Length
        End If

        Select Case e.KeyCode
            Case Keys.Back, Keys.Delete
                FilterOwnerCombo(cbo, "")
            Case Keys.Left, Keys.Right, Keys.Down, Keys.Up, Keys.End, Keys.Home
                Exit Sub
            Case Else
                FilterOwnerCombo(cbo, "")
        End Select
    End Sub
End Class