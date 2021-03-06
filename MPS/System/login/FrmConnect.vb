Imports NetFwTypeLib
Imports System
Public Class FrmConnect
    Private WithEvents clsL As BLL.BLogin = BLL.BLogin.Instance
    Dim clsU As New VsoftBMS.Ulti.ClsUti
    Private WithEvents b As New BLL.BSecUser

#Region "Form"
    Dim IDLogin As String = ""
    Dim f_IsAdmin As Boolean = False
    Dim isSave As Boolean = False
    Public Overloads Function ShowDialog(ByVal ID As String) As Boolean
        IDLogin = ID
        'If Not CheckUser() Then Return ""
        Me.ShowDialog()
        Return isSave
    End Function

    Private Sub clsL__errorRaise(ByVal message As String) Handles clsL._errorRaise
        MsgBox(message, MsgBoxStyle.Critical)
    End Sub

    Private Sub FrmConnect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, UltraLabel1.Text)
        ModMain.BlueButton(btnSave)
        ModMain.GreenButton(btnExit)

        Me.txtPWD.Text = m_PWD
        Me.cmbSRV.Text = m_Srv
        Me.txtUID.Text = m_UID
        Me.cmbDB.Text = m_DB

        Dim sAddress As String = My.Settings.ArrAddressLan
        If sAddress <> "" Then
            Dim tb As New DataTable
            tb.Columns.Add("Name")
            tb.Columns.Add("IP")
            Dim arr() As String = sAddress.Split(";")
            For Each s As String In arr
                Dim aR() As String = s.Split("&")
                If aR.Length = 2 Then
                    Dim dr As DataRow = tb.NewRow
                    dr("Name") = aR(0)
                    dr("IP") = aR(1)
                    tb.Rows.Add(dr)
                End If
            Next
            cmbSRV.DataSource = tb
        End If
    End Sub

#End Region

#Region "SUBS"
    'kiem tra user co quyen quan tri kh
    Private Function CheckUser() As Boolean
        If IDLogin = "" Then
            ShowMsg("Phải nhập tên người dùng để phân quyền thông tin kết nối !", 1224)
            Return False
        End If
        Dim m As Model.MSecUser = b.getInfo(IDLogin)
        If m.UID = "" Then
            ShowMsg("Người dùng này không tồn tại !", 1225)
            Return False
        End If
        If m.isAdmin Then
            f_IsAdmin = True
        End If
        Return True
    End Function

    Private Sub SAVEADDRESS()
        Dim tb As DataTable = cmbSRV.DataSource
        If tb Is Nothing Then Exit Sub
        Dim s As String = ""
        For Each dr As DataRow In tb.Rows
            s += dr("Name") & "&" & dr("IP") & ";"
        Next
        My.Settings.ArrAddressLan = s
        My.Settings.Save()
    End Sub

    Public Sub SaveConnection(ByVal srv As String, ByVal UID As String, ByVal PWD As String, ByVal DB As String)
        clsL.setInfoConnect(srv, UID, PWD, DB)
        clsL.SaveConfig()
    End Sub

    'Enable firewall-------------------------------------------
    Public Function GetFwMgr() As NetFwTypeLib.INetFwMgr
        Dim oINetFwMgr As NetFwTypeLib.INetFwMgr
        Dim NetFwMgrObject As Object
        Dim NetFwMgrType As Type

        ' Use the COM CLSID to get the associated .NET System.Type
        NetFwMgrType = Type.GetTypeFromCLSID( _
         New Guid("{304CE942-6E39-40D8-943A-B913C40C9CD4}"))

        ' Create an instance of the object
        NetFwMgrObject = Activator.CreateInstance(NetFwMgrType)
        oINetFwMgr = NetFwMgrObject

        Return oINetFwMgr
    End Function

    ' Provides access to the firewall settings profile.
    Public Function GetProfile() As NetFwTypeLib.INetFwProfile

        Dim oINetPolicy As NetFwTypeLib.INetFwPolicy
        Dim oINetFwMgr As NetFwTypeLib.INetFwMgr

        oINetFwMgr = GetFwMgr()

        oINetPolicy = oINetFwMgr.LocalPolicy
        Return oINetPolicy.CurrentProfile

    End Function

    ' Enable windows firewall.
    Public Sub ActivateFirewall()
        Dim fwProfile As NetFwTypeLib.INetFwProfile
        fwProfile = GetProfile()
        fwProfile.FirewallEnabled = True
    End Sub

    ' Disable windows firewall.
    Public Sub DisableFirewall()
        Dim fwProfile As NetFwTypeLib.INetFwProfile
        fwProfile = GetProfile()
        fwProfile.FirewallEnabled = False
    End Sub

    ' Firewall state || False = Disabled - True = Enabled.
    Public Function FirewallEnabled() As Boolean
        Dim fwProfile As NetFwTypeLib.INetFwProfile
        fwProfile = GetProfile()
        Return fwProfile.FirewallEnabled
    End Function
    Private Sub FindServer()
        Try
            ModMain.ShowProcess()
            Dim i As Integer = 0
            Dim ist As System.Data.Sql.SqlDataSourceEnumerator = System.Data.Sql.SqlDataSourceEnumerator.Instance
            Dim tbInstance As DataTable = ist.GetDataSources()

            Dim tb As New DataTable
            tb.Columns.Add("Name")
            tb.Columns.Add("IP")

            If Not tbInstance Is Nothing Then
                For i = 0 To tbInstance.Rows.Count - 1
                    Dim Version As String = IsNull(tbInstance.Rows(i)("Version"), "")
                    Dim IsClustered As String = IsNull(tbInstance.Rows(i)("IsClustered"), "")
                    Dim ServerName As String = IsNull(tbInstance.Rows(i)("ServerName"), "")
                    Dim InstanceName As String = IsNull(tbInstance.Rows(i)("InstanceName"), "")

                    If ServerName <> "" Then
                        Dim dr As DataRow = tb.NewRow
                        Dim s As String = ServerName
                        If InstanceName <> "" Then
                            s += "\" & InstanceName
                        End If
                        dr("Name") = s
                        dr("IP") = HostName2IP(ServerName)
                        tb.Rows.Add(dr)
                    End If

                Next
            End If

            cmbSRV.DataSource = tb
            If Not cmbSRV.IsDroppedDown Then
                cmbSRV.ToggleDropdown()
            End If
            Me.SAVEADDRESS()
        Catch ex As Exception
            ShowMsg(ex.Message)
        Finally
            ModMain.HideProcess()
        End Try
    End Sub
    Private Sub LoadListDB()
        Dim sCNN As String = "data source=" & Me.cmbSRV.Text & ";initial catalog=master;user id =" & Me.txtUID.Text.Trim & ";password=" & Me.txtPWD.Text.Trim & ";"
        Dim tb As DataTable = clsL.getDataVsoft(sCNN)
        If tb Is Nothing Then Exit Sub
        cmbDB.DataSource = tb
        Dim DF() As DataRow = tb.Select("Name like '%MPS%'")
        If DF.Length > 0 Then
            cmbDB.Text = DF(0)("Name").ToString
        Else
            If cmbDB.Rows.Count > 0 Then cmbDB.Rows(0).Selected = True
        End If
    End Sub

#End Region

#Region "Button - link"

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub bntConnet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntConnect.Click
        If bntConnect.Text = "Hủy kết nối" Then
            cmbSRV.Enabled = True
            txtPWD.Enabled = True
            cmbDB.Enabled = False
            btnSave.Enabled = False
            bntConnect.Text = "Kết nối"
            Exit Sub
        End If

        clsL.setInfoConnect(Me.cmbSRV.Text, Me.txtUID.Text, Me.txtPWD.Text, "master")

        If clsL.TestConnect() Then
            btnSave.Enabled = True
            cmbDB.Enabled = True
            cmbSRV.Enabled = False
            txtPWD.Enabled = False
            bntConnect.Text = "Hủy kết nối"
            ShowMsgInfo("Đã kết nối thành công!")
        Else
            cmbDB.DataSource = Nothing
            cmbDB.Enabled = False
            btnSave.Enabled = False
            ShowMsg("Không thể kết nối đến Máy chủ.")
        End If
    End Sub

#End Region

    Private Sub txtPWD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPWD.KeyUp
        If e.KeyCode = Keys.Enter Then
            bntConnect.PerformClick()
        End If
    End Sub

    Private Sub SetEnableConnect()
        bntConnect.Enabled = IIf(txtUID.Text = "" OrElse txtPWD.Text = "", False, True)
    End Sub
    Private Sub txtUID_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUID.ValueChanged
        SetEnableConnect()
    End Sub
    Private Sub txtPWD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPWD.ValueChanged
        SetEnableConnect()
    End Sub

    Private Sub cmbSRV_EditorButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles cmbSRV.EditorButtonClick
        FindServer()
    End Sub

    
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If cmbDB.Text.Trim = "" Then
            ShowMsg("Cơ sở dữ liệu chưa được chọn !")
            cmbDB.Focus()
            Exit Sub
        End If
        SaveConnection(Me.cmbSRV.Text, Me.txtUID.Text, Me.txtPWD.Text, cmbDB.Text)
        m_DB = cmbDB.Text
        m_Srv = cmbSRV.Text
        m_UID = txtUID.Text
        m_PWD = txtPWD.Text
        m_FConnection = True

        isSave = True
        Me.Close()
    End Sub
End Class