Public Class frmSubContractorDetail
    Private WithEvents b As BLL.BSubContractors = BLL.BSubContractors.Instance
    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        ShowMsg(messege)
    End Sub

    Private SubContractorId As String = ""
    Public Overloads Function ShowDialog(ByVal SubContractorId As String) As String
        Me.SubContractorId = SubContractorId
        Me.ShowDialog()
        Return Me.SubContractorId
    End Function

    Private Sub frmSubContractorDetail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.S Then
                Me.Save()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub frmSubContractorDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        If Me.SubContractorId <> "" Then
            Me.LoadInfo(SubContractorId)
        End If
    End Sub

    Private Sub ClearInfo()
        Dim m As New Model.MSubContractor
        txtSubContractorId.Text = m.SubContractorId
        txtSubContractorId.Enabled = True
        txtShortName.Text = m.ShortName
        txtSubContractorName.Text = m.SubContractorName
        txtAddress.Text = m.Address
        txtPhone.Text = m.Phone
        txtEmail.Text = m.Email
        txtContactName.Text = m.ContactName
        txtContactEmail.Text = m.ContactEmail
        txtContactPhone.Text = m.ContactPhone
        txtNote.Text = m.Note
    End Sub
    Private Sub LoadInfo(ByVal SubContractorId As String)
        Dim m = b.getSubContractorDetailById(SubContractorId)
        If m.SubContractorId = "" Then Exit Sub
        txtSubContractorId.Text = m.SubContractorId
        txtSubContractorId.Enabled = False
        txtShortName.Text = m.ShortName
        txtSubContractorName.Text = m.SubContractorName
        txtAddress.Text = m.Address
        txtPhone.Text = m.Phone
        txtEmail.Text = m.Email
        txtContactName.Text = m.ContactName
        txtContactEmail.Text = m.ContactEmail
        txtContactPhone.Text = m.ContactPhone
        txtNote.Text = m.Note
    End Sub
    Private Function setInfo() As Model.MSubContractor
        Dim m As New Model.MSubContractor
        m.SubContractorId = txtSubContractorId.Text
        m.ShortName = txtShortName.Text
        m.SubContractorName = txtSubContractorName.Text
        m.Address = txtAddress.Text
        m.Phone = txtPhone.Text
        m.Email = txtEmail.Text
        m.ContactName = txtContactName.Text
        m.ContactEmail = txtContactEmail.Text
        m.ContactPhone = txtContactPhone.Text
        m.Note = txtNote.Text
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MSubContractor) As Boolean
        If m.SubContractorId = "" Then
            ShowMsg("Nhập mã nhà thầu phụ")
            txtSubContractorId.Focus()
            Return False
        End If

        If m.SubContractorName = "" Then
            ShowMsg("Nhập tên công ty")
            txtSubContractorName.Focus()
            Return False
        End If

        Return True
    End Function
    Public Sub Save()
        Dim m = Me.setInfo()
        If Not CheckOK(m) Then Exit Sub

        If b.updateDB(m) Then
            If Me.SubContractorId <> "" Then
                Me.Close()
            Else
                Me.SubContractorId = m.SubContractorId
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