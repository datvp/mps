Public Class frmDirDevice
    Private WithEvents cls As New BLL.B_BK_Restore_DB
    Private Sub cls__errorRaise(ByVal messege As String) Handles cls._errorRaise
        MsgBox(messege, MsgBoxStyle.Critical)
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private sSelect As String = ""
    Private iCase As Integer = 0
    Public Overloads Function ShowDialog(ByVal nCase As Integer) As String
        iCase = nCase
        Me.ShowDialog()
        Return sSelect
    End Function

    Private Sub InitTreeView()
        TV.Nodes.Clear()
        TV.ImageList = Me.ImageList1
        Dim i As Integer

        i = 67
        While i < 97
            Dim Drive As String
            Drive = Chr(i)
            Dim tb As DataTable = cls.getFileDir("Dir " & Drive & ":\")
            If tb Is Nothing Then Exit Sub

            If tb.Rows.Count > 2 Then
                Dim node As New TreeNode
                node.Tag = Drive & ":\"
                node.Text = Drive
                node.ImageIndex = 0
                TV.Nodes.Add(node)
                'node = Nothing
            End If
            i = i + 1
        End While
       
    End Sub
    Private Sub FileOrFolder(ByVal strSource As String, ByRef file As String, ByRef IsFile As Integer)
        Try
            Dim ind As Integer
            ind = InStr(1, strSource, "<DIR>", vbTextCompare)
            If ind <> 0 Then
                file = Trim(Mid(strSource, ind + 5, Len(strSource)))
                IsFile = 2
                Exit Sub
            Else
                Dim i As Integer
                Dim s As String
                For i = 18 To Len(strSource)
                    s = Mid(strSource, i, 1)
                Next
                file = Trim(Mid(strSource, 40, Len(strSource) - 39))
                IsFile = 1
            End If
        Catch ex As Exception
            IsFile = -1
            file = ""
        End Try
    End Sub

    Private Sub TV_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TV.DoubleClick

        Dim node As New TreeNode
        node = TV.SelectedNode
        If node Is Nothing Then
            Exit Sub
        End If
        If node.ImageIndex = 3 Then
            Choose()
            Exit Sub
        End If
        If node.GetNodeCount(True) > 0 Then
            TV.SelectedNode.Expand()
            Exit Sub
        End If
        Dim strPath As String = node.Tag
        Dim tb As DataTable = cls.getFileDir("Dir " & strPath)

        Dim i, IsFile As Integer
        IsFile = 0
        Dim strFile As String = ""
        For i = 7 To tb.Rows.Count - 3
            Dim nodeNew As New TreeNode
            FileOrFolder(tb.Rows(i)(0), strFile, IsFile)
            If IsFile = 2 Then 'Folder
                nodeNew.Tag = node.Tag & """" & strFile & """\"
                nodeNew.Text = strFile
                nodeNew.ImageIndex = 1
                nodeNew.SelectedImageIndex = 2
            Else
                If IsFile = 1 Then
                    nodeNew.Tag = strFile
                    nodeNew.Text = strFile
                    nodeNew.ImageIndex = 3
                    nodeNew.SelectedImageIndex = 3

                End If
            End If
            If IsFile <> -1 Then
                If IsFile = 1 And iCase <> 0 Then
                Else

                    TV.SelectedNode.Nodes.Add(nodeNew)
                End If

            End If
            nodeNew = Nothing
        Next

        TV.SelectedNode.Expand()
    End Sub

    Private Sub TV_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV.AfterSelect
        If e.Node.ImageIndex = 0 Or e.Node.ImageIndex = 1 Then
            lbTemp.Text = CStr(e.Node.Tag).Trim.Replace("""", "")

        End If
        If e.Node.ImageIndex = 3 Then
            txtFile.Text = e.Node.Text.Trim.Replace("""", "")
        End If
        Lb.Text = lbTemp.Text & txtFile.Text
    End Sub

    Private Sub txtFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFile.TextChanged
        lb.Text = lbTemp.Text & txtFile.Text
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        Choose()
    End Sub
    Public Sub Choose()
        If iCase = 0 Then
            If txtFile.Text = "" Then
                ShowMsg("Nhập tên file!", 1430)
                Exit Sub
            End If
        End If
        If Lb.Text = "" Then
            ShowMsg("Chọn thư mục chứa dữ liệu!", 58)
            Exit Sub
        End If

        sSelect = Lb.Text
        Close()
    End Sub

    Private Sub frmDirDevice_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmDirDevice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me)
        ModMain.BlueButton(btnChoose)
        ModMain.GreenButton(btnCancel)
        cls.EnableCMDShell()
        Lb.Text = ""
        lbTemp.Text = ""
        If iCase <> 0 Then
            Me.txtFile.ReadOnly = True
        End If
        Me.InitTreeView()
    End Sub
End Class