Public Class frmMainContractorDetail
    Private WithEvents b As BLL.BMainContractors = BLL.BMainContractors.Instance
    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        ShowMsg(messege)
    End Sub

    Private MainContractorId As String = ""
    Public Overloads Function ShowDialog(ByVal MainContractorId As String) As String
        Me.MainContractorId = MainContractorId
        Me.ShowDialog()
        Return Me.MainContractorId
    End Function

    Private Sub frmMainContractorDetail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.S Then
                Me.Save()
            End If
        End If
    End Sub

    Private Sub frmMainContractorDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        If Me.MainContractorId <> "" Then
            Me.LoadInfo(MainContractorId)
        End If
    End Sub
    Private Sub ClearInfo()
        Dim m As New Model.MMainContractor
        txtId.Text = m.Id
        txtId.Enabled = True
        txtShortName.Text = m.ShortName
        txtCompany.Text = m.Company
        txtAddress.Text = m.Address
        txtPhone.Text = m.Phone
        txtEmail.Text = m.Email
        txtWebsite.Text = m.Website
        txtContactName.Text = m.ContactName
        txtContactEmail.Text = m.ContactEmail
        txtContactPhone.Text = m.ContactPhone
    End Sub
    Private Sub LoadInfo(ByVal MainContractorId As String)
        Dim m = b.getMainContractorDetailById(MainContractorId)
        If m.Id = "" Then Exit Sub
        txtId.Text = m.Id
        txtId.Enabled = False
        txtShortName.Text = m.ShortName
        txtCompany.Text = m.Company
        txtAddress.Text = m.Address
        txtPhone.Text = m.Phone
        txtEmail.Text = m.Email
        txtWebsite.Text = m.Website
        txtContactName.Text = m.ContactName
        txtContactEmail.Text = m.ContactEmail
        txtContactPhone.Text = m.ContactPhone
    End Sub
    Private Function setInfo() As Model.MMainContractor
        Dim m As New Model.MMainContractor
        m.id = txtId.Text
        m.ShortName = txtShortName.Text
        m.Company = txtCompany.Text
        m.Address = txtAddress.Text
        m.Phone = txtPhone.Text
        m.Email = txtEmail.Text
        m.Website = txtWebsite.Text
        m.ContactName = txtContactName.Text
        m.ContactEmail = txtContactEmail.Text
        m.ContactPhone = txtContactPhone.Text
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MMainContractor) As Boolean
        If m.id = "" Then
            ShowMsg("Nhập mã đơn vị")
            txtId.Focus()
            Return False
        End If

        If m.Company = "" Then
            ShowMsg("Nhập tên đơn vị")
            txtCompany.Focus()
            Return False
        End If
        Return True
    End Function
    Public Sub Save()
        Dim m = Me.setInfo()
        If Not CheckOK(m) Then Exit Sub

        If b.updateDB(m) Then
            If Me.MainContractorId <> "" Then
                Me.Close()
            Else
                Me.MainContractorId = m.Id
                Me.ClearInfo()
            End If
            ShowMsgInfo(m_MsgSaveSuccess)
        Else
            ShowMsg(m_SaveDataError)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.Save()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class