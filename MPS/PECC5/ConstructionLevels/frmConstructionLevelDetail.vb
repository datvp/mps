Public Class frmConstructionLevelDetail
    Private WithEvents b As BLL.BConstructionLevels = BLL.BConstructionLevels.Instance
    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        ShowMsg(messege)
    End Sub

    Private ConstructionLevelId As String = ""
    Public Overloads Function ShowDialog(ByVal ConstructionLevelId As String) As String
        Me.ConstructionLevelId = ConstructionLevelId
        Me.ShowDialog()
        Return Me.ConstructionLevelId
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
    Private Sub frmConstructionLevelDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        Me.LoadInfo(ConstructionLevelId)
    End Sub
    Private Sub ClearInfo()
        Dim m As New Model.MConstructionLevel
        txtConstructionLevelId.Text = m.ConstructionLevelId
        txtConstructionLevelId.Enabled = True
        txtConstructionLevelName.Text = m.ConstructionLevelName
        txtNote.Text = m.Note
    End Sub
    Private Sub LoadInfo(ByVal ConstructionLevelId As String)
        Dim m = b.getConstructionLevelDetailById(ConstructionLevelId)
        If m.ConstructionLevelId = "" Then Exit Sub
        txtConstructionLevelId.Text = m.ConstructionLevelId
        txtConstructionLevelId.Enabled = False
        txtConstructionLevelName.Text = m.ConstructionLevelName
        txtNote.Text = m.Note
    End Sub
    Private Function setInfo() As Model.MConstructionLevel
        Dim m As New Model.MConstructionLevel
        m.ConstructionLevelId = txtConstructionLevelId.Text
        m.ConstructionLevelName = txtConstructionLevelName.Text
        m.Note = txtNote.Text
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MConstructionLevel) As Boolean
        If m.ConstructionLevelId = "" Then
            ShowMsg("Nhập mã phân cấp")
            txtConstructionLevelId.Focus()
            Return False
        End If

        'Add new -> check duplicate id
        If Me.ConstructionLevelId = "" Then
            If b.isExist(m.ConstructionLevelId) Then
                ShowMsg("Mã bị trùng, vui lòng nhập mã khác.")
                txtConstructionLevelId.Focus()
                Return False
            End If
        End If

        If m.ConstructionLevelName = "" Then
            ShowMsg("Nhập tên phân cấp")
            txtConstructionLevelName.Focus()
            Return False
        End If

        Return True
    End Function
    Public Sub Save()
        Dim m = Me.setInfo()
        If Not CheckOK(m) Then Exit Sub

        If b.updateDB(m) Then
            If Me.ConstructionLevelId <> "" Then
                Me.Close()
            Else
                Me.ConstructionLevelId = m.ConstructionLevelId
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