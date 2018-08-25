Public Class frmClientDetail
    Private WithEvents b As BLL.BClients = BLL.BClients.Instance
    Private bu As BLL.BUniteds = BLL.BUniteds.Instance
    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        ShowMsg(messege)
    End Sub

    Private clientId As String = ""
    Public Overloads Function ShowDialog(ByVal clientId As String) As String
        Me.clientId = clientId
        Me.ShowDialog()
        Return Me.clientId
    End Function

    Private Sub frmClientDetail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.S Then
                Me.Save()
            End If
        End If
    End Sub

    Private Sub frmClientDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        If Me.clientId = "" Then
            Me.LoadClientGroup()
            Me.LoadUnited()
        Else
            Me.LoadInfo(clientId)
        End If
    End Sub

    Private Sub LoadClientGroup()
        Dim tb = b.getListClientGroups()
        cboClientGroup.ValueMember = "ClientGroupId"
        cboClientGroup.DisplayMember = "ClientGroupName"
        cboClientGroup.DataSource = tb
        If cboClientGroup.DataSource IsNot Nothing Then
            If cboClientGroup.Rows.Count > 0 Then
                cboClientGroup.Rows(0).Activate()
            End If
        End If
    End Sub
    Private Sub LoadUnited()
        Dim tb = bu.getListUniteds()
        cboUnited.ValueMember = "UnitedId"
        cboUnited.DisplayMember = "UnitedName"
        cboUnited.DataSource = tb
    End Sub
    Private Sub ClearInfo()
        Dim m As New Model.MClient
        txtClientId.Text = m.ClientId
        txtClientId.Enabled = True
        txtShortName.Text = m.ShortName
        txtClientName.Text = m.ClientName
        txtAddress.Text = m.Address
        txtPhone.Text = m.Phone
        txtEmail.Text = m.Email
        txtWebsite.Text = m.Website
        txtContactName.Text = m.ContactName
        txtContactEmail.Text = m.ContactEmail
        txtContactPhone.Text = m.ContactPhone
    End Sub
    Private Sub LoadInfo(ByVal ClientId As String)
        Dim m = b.getClientDetailById(ClientId)
        If m.ClientId = "" Then Exit Sub
        Me.LoadClientGroup()
        Me.LoadUnited()
        txtClientId.Text = m.ClientId
        txtClientId.Enabled = False
        txtShortName.Text = m.ShortName
        txtClientName.Text = m.ClientName
        txtAddress.Text = m.Address
        txtPhone.Text = m.Phone
        txtEmail.Text = m.Email
        txtWebsite.Text = m.Website
        txtContactName.Text = m.ContactName
        txtContactEmail.Text = m.ContactEmail
        txtContactPhone.Text = m.ContactPhone
        cboClientGroup.Value = m.ClientGroupId
        cboUnited.Value = m.UnitedId
    End Sub
    Private Function setInfo() As Model.MClient
        Dim m As New Model.MClient
        m.ClientId = txtClientId.Text
        m.ShortName = txtShortName.Text
        m.ClientName = txtClientName.Text
        m.Address = txtAddress.Text
        m.Phone = txtPhone.Text
        m.Email = txtEmail.Text
        m.Website = txtWebsite.Text
        m.ContactName = txtContactName.Text
        m.ContactEmail = txtContactEmail.Text
        m.ContactPhone = txtContactPhone.Text
        If cboClientGroup.Value IsNot Nothing Then
            m.ClientGroupId = cboClientGroup.Value
        End If
        m.Status = "Active"
        If cboUnited.Value IsNot Nothing Then
            m.UnitedId = cboUnited.Value
        End If
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MClient) As Boolean
        If m.ClientId = "" Then
            ShowMsg("Nhập mã khách hàng")
            txtClientId.Focus()
            Return False
        End If

        If m.ClientName = "" Then
            ShowMsg("Nhập tên công ty")
            txtClientName.Focus()
            Return False
        End If

        If m.ClientGroupId = "" Then
            ShowMsg("Chọn phân nhóm")
            cboClientGroup.Focus()
            Return False
        End If

        Return True
    End Function
    Public Sub Save()
        Dim m = Me.setInfo()
        If Not CheckOK(m) Then Exit Sub

        If b.updateDB(m) Then
            If Me.clientId <> "" Then
                Me.Close()
            Else
                Me.clientId = m.ClientId
                Me.ClearInfo()
            End If
            ShowMsgInfo(m_MsgSaveSuccess)
        Else
            ShowMsg(m_SaveDataError)
        End If
    End Sub

    Private Sub cboClientGroup_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboClientGroup.InitializeLayout
        If Me.cboClientGroup.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("ClientGroupName").Hidden = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.Save()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub cboUnited_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboUnited.InitializeLayout
        If Me.cboUnited.DataSource Is Nothing Then Exit Sub
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("UnitedName").Hidden = False
    End Sub
End Class