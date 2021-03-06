Public Class FrmLogin
    Private clsL As BLL.BLogin = BLL.BLogin.Instance
    Dim isLock As Boolean = False

    Public Overloads Sub ShowDialog(ByVal isLock As Boolean)
        Me.isLock = isLock
        Me.ShowDialog()
    End Sub

    Private Sub FrmLogin_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If Me.isLock Then
            Exit Sub
        End If
        If e.Control Then
            If e.KeyCode = Keys.F12 Then
                LinklblTTKN.Visible = Not LinklblTTKN.Visible
            End If
        Else
            If e.KeyCode = Keys.Enter Then
                Me.Login()
            End If
        End If
    End Sub
    Private Sub LoadBranch()
        Dim tb As DataTable = ModMain.LoadBranch()
        cboBranch.ValueMember = "s_ID"
        cboBranch.DisplayMember = "s_Name"
        cboBranch.DataSource = tb
        If cboBranch.DataSource IsNot Nothing AndAlso cboBranch.Rows.Count > 0 Then
            cboBranch.Rows(0).Activate()
        End If
    End Sub
    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me)
        ModMain.BlueButton(btnAccept, ModMain.m_OkIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)

        Me.LoadBranch()

        If Me.isLock Then
            txtUID.Text = My.Settings.UID
            CloseButton.Disable(Me)
            btnExit.Enabled = False
            cboBranch.Enabled = False
            txtPWD.Text = ""
            txtPWD.Focus()
        Else
            ChMem.Checked = My.Settings.isRem
            If ChMem.Checked Then
                txtUID.Text = My.Settings.UID
                txtPWD.Text = Helper.Decrypt(My.Settings.PWD)
            End If
            btnAccept.Focus()
        End If
    End Sub

    Private Sub LinklblTTKN_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinklblTTKN.LinkClicked
        Dim frm As New FrmConnect
        Dim isSave = frm.ShowDialog(txtUID.Text.Trim)
        If isSave Then
            LoadBranch()
        End If
    End Sub
    Private Sub Login()
        Dim uid As String = txtUID.Text

        Dim tb As DataTable = clsL.getUser(uid)
        If tb Is Nothing Then
            ShowMsg("Không kiểm tra được thông tin.")
            Exit Sub
        End If
        If tb.Rows.Count = 0 Then
            ShowMsg("Tên đăng nhập không tồn tại.")
            Exit Sub
        End If

        If txtPWD.Text.Trim = "" Then
            ShowMsg("Bạn chưa nhập mật khẩu.")
            txtPWD.Focus()
            Exit Sub
        End If

        If cboBranch.Value Is Nothing Then
            ShowMsg("Bạn chưa chọn Chi nhánh.")
            cboBranch.Focus()
            Exit Sub
        End If

        Dim sPWD = Helper.Encrypt(txtPWD.Text.Trim)
        If sPWD = "" Then
            Exit Sub
        End If

        Dim strPwd = tb.Rows(0)("s_PWD").ToString()
        If strPwd <> sPWD Then
            ShowMsg("Mật khẩu không hợp lệ !")
            Exit Sub
        End If


        Dim branchId As String = cboBranch.Value
        Dim branchCode As String = cboBranch.ActiveRow.Cells("s_Branch_ID").Value
        Dim branchName As String = cboBranch.Text

        If uid.ToLower <> "admin" Then
            Dim tbBranch = ModMain.getBranchByRightToExecute(uid)
            If tbBranch IsNot Nothing Then
                Dim f() = tbBranch.Select("s_ID='" & branchId & "'")
                If f.Length = 0 Then
                    ShowMsg("Bạn không được cấp quyền truy cập chi nhánh: " & branchName & " này.")
                    cboBranch.Focus()
                    Exit Sub
                End If
            End If
        End If

        Dim hostName = My.Computer.Name
        clsL.UpDateComputerLogin(hostName, ModMain.HostName2IP(hostName), True)

        ModMain.m_BranchId = branchId
        ModMain.m_BranchCode = branchCode
        ModMain.m_BranchName = branchName
        ModMain.m_UIDLogin = uid
        ModMain.m_FLogin = True
        ModMain.m_EmpTitle = IsNull(tb.Rows(0)("s_Name"), "")
        ModMain.m_EmpLogin = IsNull(tb.Rows(0)("s_ID"), "")
        ModMain.LoadVariablesGlobally()

        ModMain.m_AllowExportExcel = ModMain.getPermitFunc(ModMain.m_UIDLogin, 19).R

        My.Settings.isRem = ChMem.Checked
        My.Settings.UID = m_UIDLogin
        My.Settings.PWD = sPWD
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        Me.Login()
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If Me.isLock Then
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub cboBranch_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboBranch.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("s_Name").Hidden = False
    End Sub

    Private Sub txtPWD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPWD.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.Login()
        End If
    End Sub

    Private Sub txtUID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUID.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtPWD.Focus()
        End If
    End Sub
End Class