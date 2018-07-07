Public Class frmMain

#Region "Declare"
    Dim value As Boolean = False
    Dim vitri As Integer = -1
    Dim strFormShowDialog As String = ""
    Dim sUID As String = ""
    Dim cls As BLL.BPublic = BLL.BPublic.Instance
    Dim Add As Boolean = False
    Dim fRec As Boolean = False
#End Region

#Region "Form event"
    Private Sub frmMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If components IsNot Nothing Then
            components.Dispose()
        End If
        Me.Dispose()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If fAskClose Then
            If ShowMsgYesNo(m_MsgCloseApp, m_MsgCaption) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        Dim clsL As BLL.BLogin = BLL.BLogin.Instance
        Dim HostName As String = My.Computer.Name
        Dim IPAddress As String = m_strMyIPAddress
        clsL.UpDateComputerLogin(HostName, IPAddress, False)
        SendMessageSRV(m_strMyIPAddress & ";out", sAddressServer)
        e.Cancel = False
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ModMain.SetTitle(Me)
        Me.WindowState = FormWindowState.Maximized

        'load dashboard
        ShowForm(ModMain.m_Dashboard)
    End Sub
    Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        UltraStatusBar1.Panels("Branch").Text = "Company: " & ModMain.m_BranchName
        UltraStatusBar1.Panels("SRV").Text = "Server: " & ModMain.m_Srv
        UltraStatusBar1.Panels("UserName").Text = "User: " & ModMain.m_UIDLogin
        UltraStatusBar1.Panels("DB").Text = "Database : " & ModMain.m_DB
        tbManager.Ribbon.Caption = FormTitle + " | " + m_Version
        Dim f As Form = Me.ActiveMdiChild

        If f Is Nothing Then Exit Sub
        If strFormShowDialog.ToLower = f.Name.ToLower Then
            'f.Text = f.Name & Now.ToString
            strFormShowDialog = ""
        End If
    End Sub
    Private Sub frmMain_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
        Dim f As Form = Me.ActiveMdiChild
        If Not f Is Nothing Then
            SetStatusFirst_Last(f.Name, Me)
        End If
    End Sub
#End Region

#Region "Common Function "

    Private Function CheckExistFormShow(ByVal formName As String) As Form
        For Each f As Form In Me.MdiChildren
            If formName.Trim.ToLower = f.Name.Trim.ToLower Then
                Return f
            End If
        Next
        Return Nothing
    End Function
    Private Function CheckSecurity(ByVal FuncID As Integer, ByRef add As Boolean) As Boolean
        Dim m As Model.MFuncRight = ModMain.getPermitFunc(ModMain.m_UIDLogin, FuncID)
        add = m.A
        Return m.R
    End Function

    Public Sub ShowForm(ByVal formChild As Form)
        For Each f As Form In Me.MdiChildren
            If formChild.Name.Trim.ToLower = f.Name.Trim.ToLower Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        Try
            formChild.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            formChild.MdiParent = Me
            formChild.Show()
            formChild.Dock = DockStyle.Fill

        Catch ex As Exception
            formChild.Dispose()
        End Try

    End Sub

    Private Sub SetStatusFirst_Last(ByVal NameformChild As String, ByVal formMain As Form)
        Dim l As Integer = getLenChild(formMain)

        If l < 2 Then
            Exit Sub
        End If

        Dim i As Integer = 0

        For Each f As Form In formMain.MdiChildren
            If NameformChild.Trim.ToLower = f.Name.Trim.ToLower Then
                If i = l - 1 Then
                    If l > 1 Then
                    End If
                Else
                    If i = 0 Then
                        If l > 1 Then
                        End If
                    Else
                        If l > 1 Then
                        End If
                    End If
                End If
                Exit Sub
            End If
            i += 1
        Next
    End Sub

    Private Function getLenChild(ByVal formMain As Form) As Integer
        Dim c As Integer = 0
        For Each f As Form In formMain.MdiChildren
            If Not f.Disposing Then
                c += 1
            End If
        Next
        Return c
    End Function

#End Region

#Region "Toolbar manager"
    Private Sub tbManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles tbManager.ToolClick
        Select Case e.Tool.Key
            Case "Dashboard"
                ShowForm(ModMain.m_Dashboard)
            Case "Projects"
                Dim frm As New frmProjects
                ShowForm(frm)
            Case "Contracts"
                Dim frm As New frmContracts
                ShowForm(frm)
                'Case "chinhanh"
                '    If Not CheckSecurity(12, Add) Then
                '        ShowMsg(m_MsgNotPermitUseThisFun, m_MsgCaption)
                '        Exit Sub
                '    End If
                '    Dim frm As New frmBranch
                '    ShowForm(frm)
                'Case "nguonkhachhang"
                '    Dim frm As New frmNguonKH
                '    frm.ShowDialog()
            Case "btnLogin"
                Dim frm As New frmContractDetail
                frm.ShowDialog()

                'While Not Me.ActiveMdiChild Is Nothing
                '    Me.ActiveMdiChild.Close()
                'End While
                'Dim frm As New FrmLogin
                'frm.ShowDialog(True)

                'Me.Text = FormTitle
                'Case "btnConfix"
                '    If Not CheckSecurity(87, Add) Then
                '        ShowMsg(m_MsgNotPermitUseThisFun, m_MsgCaption)
                '        Exit Sub
                '    End If
                '    Dim frm As New frmConfigProgram
                '    frm.ShowDialog()
            Case "btnEven"
                If Not CheckSecurity(53, Add) Then
                    ShowMsg(m_MsgNotPermitUseThisFun, m_MsgCaption)
                    Exit Sub
                End If
                Dim frm As New FrmEvent
                ShowForm(frm)
            Case "btnSLDP"
                If Not CheckSecurity(45, Add) Then
                    ShowMsg(m_MsgNotPermitUseThisFun, m_MsgCaption)
                    Exit Sub
                End If
                Dim frm As New frmBKData
                frm.ShowDialog()
            Case "btnPHDL"
                If Not CheckSecurity(46, Add) Then
                    ShowMsg(m_MsgNotPermitUseThisFun, m_MsgCaption)
                    Exit Sub
                End If
                Dim frm As New frmRestoreDB
                frm.ShowDialog()
            Case "btnExit"
                Me.Close()
        End Select
    End Sub

#End Region

End Class