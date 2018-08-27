Public Class frmItemDetail
    Private WithEvents b As BLL.BItems = BLL.BItems.Instance
    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        ShowMsg(messege)
    End Sub

    Private itemId As String = ""
    Public Overloads Function ShowDialog(ByVal itemId As String) As String
        Me.itemId = itemId
        Me.ShowDialog()
        Return Me.itemId
    End Function
    Private Sub frm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.S Then
                Me.Save()
            End If
        End If
    End Sub
    Private Sub frmItemDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        Me.LoadInfo(itemId)
    End Sub
    Private Sub ClearInfo()
        Dim m As New Model.MItem
        txtItemId.Text = m.ItemId
        txtItemId.Enabled = True
        txtItemName.Text = m.ItemName
        txtNote.Text = m.Note
    End Sub
    Private Sub LoadInfo(ByVal ItemId As String)
        Dim m = b.getItemDetailById(ItemId)
        If m.ItemId = "" Then Exit Sub
        txtItemId.Text = m.ItemId
        txtItemId.Enabled = False
        txtItemName.Text = m.ItemName
        txtNote.Text = m.Note
    End Sub
    Private Function setInfo() As Model.MItem
        Dim m As New Model.MItem
        m.ItemId = txtItemId.Text
        m.ItemName = txtItemName.Text
        m.Note = txtNote.Text
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MItem) As Boolean
        If m.ItemId = "" Then
            ShowMsg("Nhập mã hạng mục")
            txtItemId.Focus()
            Return False
        End If

        If m.ItemName = "" Then
            ShowMsg("Nhập tên hạng mục")
            txtItemName.Focus()
            Return False
        End If

        Return True
    End Function
    Public Sub Save()
        Dim m = Me.setInfo()
        If Not CheckOK(m) Then Exit Sub

        If b.updateDB(m) Then
            If Me.itemId <> "" Then
                Me.Close()
            Else
                Me.itemId = m.ItemId
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