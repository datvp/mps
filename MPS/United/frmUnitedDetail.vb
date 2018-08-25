Public Class frmUnitedDetail
    Private WithEvents b As BLL.BUniteds = BLL.BUniteds.Instance
    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        ShowMsg(messege)
    End Sub

    Private UnitedId As String = ""
    Public Overloads Function ShowDialog(ByVal UnitedId As String) As String
        Me.UnitedId = UnitedId
        Me.ShowDialog()
        Return Me.UnitedId
    End Function

    Private Sub frmUnitedDetail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.S Then
                Me.Save()
            End If
        End If
    End Sub

    Private Sub frmUnitedDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        If Me.UnitedId <> "" Then
            Me.LoadInfo(UnitedId)
        End If
    End Sub
    Private Sub ClearInfo()
        Dim m As New Model.MUnited
        txtUnitedId.Text = m.UnitedId
        txtUnitedId.Enabled = True
        txtShortName.Text = m.ShortName
        txtUnitedName.Text = m.UnitedName
        txtAddress.Text = m.Address
        txtPhone.Text = m.Phone
        txtEmail.Text = m.Email
        txtWebsite.Text = m.Website
        txtContactName.Text = m.ContactName
        txtContactEmail.Text = m.ContactEmail
        txtContactPhone.Text = m.ContactPhone
        txtNote.Text = m.Note
    End Sub
    Private Sub LoadInfo(ByVal UnitedId As String)
        Dim m = b.getUnitedDetailById(UnitedId)
        If m.UnitedId = "" Then Exit Sub
        txtUnitedId.Text = m.UnitedId
        txtUnitedId.Enabled = False
        txtShortName.Text = m.ShortName
        txtUnitedName.Text = m.UnitedName
        txtAddress.Text = m.Address
        txtPhone.Text = m.Phone
        txtEmail.Text = m.Email
        txtWebsite.Text = m.Website
        txtContactName.Text = m.ContactName
        txtContactEmail.Text = m.ContactEmail
        txtContactPhone.Text = m.ContactPhone
        txtNote.Text = m.Note
    End Sub
    Private Function setInfo() As Model.MUnited
        Dim m As New Model.MUnited
        m.UnitedId = txtUnitedId.Text
        m.ShortName = txtShortName.Text
        m.UnitedName = txtUnitedName.Text
        m.Address = txtAddress.Text
        m.Phone = txtPhone.Text
        m.Email = txtEmail.Text
        m.Website = txtWebsite.Text
        m.ContactName = txtContactName.Text
        m.ContactEmail = txtContactEmail.Text
        m.ContactPhone = txtContactPhone.Text
        m.Note = txtNote.Text
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MUnited) As Boolean
        If m.UnitedId = "" Then
            ShowMsg("Nhập mã đơn vị")
            txtUnitedId.Focus()
            Return False
        End If

        If m.UnitedName = "" Then
            ShowMsg("Nhập tên đơn vị")
            txtUnitedName.Focus()
            Return False
        End If
        Return True
    End Function
    Public Sub Save()
        Dim m = Me.setInfo()
        If Not CheckOK(m) Then Exit Sub

        If b.updateDB(m) Then
            If Me.UnitedId <> "" Then
                Me.Close()
            Else
                Me.UnitedId = m.UnitedId
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