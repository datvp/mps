Public Class frmClientGroupDetail
    Private WithEvents b As BLL.BClientGroups = BLL.BClientGroups.Instance
    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        ShowMsg(messege)
    End Sub

    Private clientGroupId As String = ""
    Public Overloads Function ShowDialog(ByVal clientGroupId As String) As String
        Me.clientGroupId = clientGroupId
        Me.ShowDialog()
        Return Me.clientGroupId
    End Function
    Private Sub frm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.S Then
                Me.Save()
            End If
        End If
    End Sub
    Private Sub frmClientGroupDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        Me.LoadInfo(clientGroupId)
    End Sub
    Private Sub ClearInfo()
        Dim m As New Model.MItem
        txtClientGroupId.Text = m.ItemId
        txtClientGroupId.Enabled = True
        txtClientGroupName.Text = m.ItemName
        txtNote.Text = m.Note
    End Sub
    Private Sub LoadInfo(ByVal clientGroupId As String)
        Dim m = b.getClientGroupDetailById(clientGroupId)
        If m.ClientGroupId = "" Then Exit Sub
        txtClientGroupId.Text = m.ClientGroupId
        txtClientGroupId.Enabled = False
        txtClientGroupName.Text = m.ClientGroupName
        txtNote.Text = m.Note
    End Sub
    Private Function setInfo() As Model.MClientGroup
        Dim m As New Model.MClientGroup
        m.ClientGroupId = txtClientGroupId.Text
        m.ClientGroupName = txtClientGroupName.Text
        m.Note = txtNote.Text
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MClientGroup) As Boolean
        If m.ClientGroupId = "" Then
            ShowMsg("Nhập mã nhóm khách hàng")
            txtClientGroupId.Focus()
            Return False
        End If

        If m.ClientGroupName = "" Then
            ShowMsg("Nhập tên nhóm khách hàng")
            txtClientGroupName.Focus()
            Return False
        End If

        Return True
    End Function
    Public Sub Save()
        Dim m = Me.setInfo()
        If Not CheckOK(m) Then Exit Sub

        If b.updateDB(m) Then
            If Me.clientGroupId <> "" Then
                Me.Close()
            Else
                Me.clientGroupId = m.ClientGroupId
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