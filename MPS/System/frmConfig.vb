Public Class frmConfig
    Private WithEvents b As BLL.B_ConfigProgram = BLL.B_ConfigProgram.Instance
    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        ShowMsg(messege)
    End Sub

    Private Sub frmConfig_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.S Then
                Me.Save()
            End If
        End If
    End Sub

    Private Sub frmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        Me.LoadInfo()
    End Sub
    Private Sub LoadInfo()
        Dim m = b.getInfo()
        txtCompanyName.Text = m.s_CompanyName
        txtAlias.Text = m.s_Alias
        txtTaxNo.Text = m.s_TaxNo
        txtAddress.Text = m.s_Address
        txtPhone.Text = m.s_Phone1
        txtPhone2.Text = m.s_Phone2
        txtEmail.Text = m.s_Email
        txtWebsite.Text = m.s_Website
        txtPathToSave.Text = m.PathToSave
        nudDeadLineAlert.Value = m.DeadLineAlert
        pic1.Image = ModMain.ConvertByteArrayToImage(m.im_Logo)
    End Sub
    Private Function setInfo() As Model.MConfigProgram
        Dim m As New Model.MConfigProgram
        m.s_CompanyName = txtCompanyName.Text
        m.s_Alias = txtAlias.Text
        m.s_TaxNo = txtTaxNo.Text
        m.s_Address = txtAddress.Text
        m.s_Phone1 = txtPhone.Text
        m.s_Phone2 = txtPhone2.Text
        m.s_Email = txtEmail.Text
        m.s_Website = txtWebsite.Text
        m.PathToSave = txtPathToSave.Text
        m.DeadLineAlert = CInt(nudDeadLineAlert.Value)
        If Not Me.pic1.Image Is Nothing Then
            m.im_Logo = ModMain.ConvertImageToByteArray(pic1.Image)
        Else
            m.im_Logo = Nothing
        End If
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MConfigProgram) As Boolean
        Return True
    End Function
    Public Sub Save()
        Dim m = Me.setInfo()
        If Not CheckOK(m) Then Exit Sub

        If b.UPDATEDB(m) Then
            ModMain.LoadVariablesGlobally()
            Me.Close()
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

    Private Sub txtPathToSave_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles txtPathToSave.EditorButtonClick
        Dim frm As New frmDirDevice
        Dim s As String = frm.ShowDialog(1)
        If s <> "" Then
            Me.txtPathToSave.Text = s
        End If
    End Sub

    Private Sub pic1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic1.DoubleClick
        ModMain.OpenImage(pic1)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ModMain.OpenImage(pic1)
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        pic1.Image = Nothing
    End Sub
End Class