Imports NetFwTypeLib
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Management
Imports Microsoft.Office.Interop
Imports System.Threading

Module ModMain
    Public m_MsgCaption As String = "ECM"
    Public m_PathDelFirst As String = "Xóa "
    Public m_MsgCloseApp As String = "Bạn chọn đóng chương trình?"
    Public m_PathDelLast As String = " dòng đang chọn?"
    Public m_DataRelation As String = "Có dữ liệu liên quan!"
    Public m_DelError As String = "Quá trình xóa bị lỗi!"
    Public m_MsgAskDel As String = "Có thật sự xóa dòng đang chọn?"
    Public m_MsgAskSaveBeforeExit As String = "Có lưu thông tin trước khi thoát ?"
    Public m_MsgSaveSuccess As String = "Đã lưu dữ liệu!"
    Public m_MsgNotPermitAddNew As String = "Người dùng không được cấp quyền thêm mới !"
    Public m_MsgNotAddNewCombo As String = "Bạn không được quyền thêm mới !"
    Public m_MsgNotPermitUseThisFun As String = "Người dùng không được cấp quyền chạy chức năng này !"
    Public m_DelErrorOneItems As String = "Quá trình xóa bị lỗi. Kiểm tra và thực hiện lại !"
    Public m_SaveDataError As String = "Quá trình lưu dữ liệu có lỗi. Kiểm tra và thực hiện lại !"
    Public m_DataErrorWarningQuestion As String = "Dữ liệu không hợp lệ. Bạn có muốn tiếp tục thực hiện import?"
    Public m_NoSelectedItemToImport As String = "Không có cột dữ liệu nào được chọn."
    Public m_DataInvalid As String = "Dữ liệu không hợp lệ."
    Public m_DataValid As String = "Dữ liệu hợp lệ!"
    Public m_Add As String = "Thêm"
    Public m_AddWithThreeDots As String = "Thêm ..."
    Public m_SelectAll As String = "Tất cả"
    Public m_Choose As String = "Chọn"
    Public m_Update As String = "Cập nhật"
    Public FormTitle As String = "CONTRACT MANAGER SOFTWARE FOR ENERGY PROJECT" '18.06.09 
    Public m_Version As String = ""

    Public m_Lang As Integer = 1
    Public fAskClose As Boolean = True
    Public m_FConnection As Boolean = False
    Public m_FLogin As Boolean = False
    Public m_Srv As String = ""
    Public m_UID As String = ""
    Public m_PWD As String = ""
    Public m_DB As String = ""
    Public m_UIDLogin As String = "" 'user đăng nhập
    Public m_LoginSystem As Boolean = False

    Public m_CPUID As String = ""
    Private m_FormatCurTemp As String = "#,##0"
    Private m_FormatCurNumber As String = "#,##0"
    Public m_strFormatCur As String = m_FormatCurTemp '& m_strDecCur 'định dạng tiền tệ
    Public m_strFormatNum As String = m_FormatCurNumber '& m_strDecNum 'định dạng số
    Public m_SysCur As String = "VND" 'định dạng đơn vị tiền tệ
    Public m_SysCurChar As String = "đồng" '26.11.09-doc tien bang chu
    Public m_strMyIPAddress As String = ""
    Public m_strLableStatus As String = "Click phải trên danh sách phiếu chọn menu chức năng ..."
    Public m_strLableList As String = "Click phải trên danh sách chọn menu chức năng ..."
    Public b_ItemClick As Boolean

    Public m_sysColor As Color = Color.White 'Color.FromArgb(255, 216, 228, 248)
    ''' <summary>
    ''' Tên nhân viên
    ''' </summary>
    ''' <remarks></remarks>
    Public m_EmpTitle As String = ""
    ''' <summary>
    ''' mã nhân viên
    ''' </summary>
    ''' <remarks></remarks>
    Public m_EmpLogin As String = "" 'dung de luu ma nhan vien khi nhan vien do login vao
    Public m_BranchId As String = ""
    Public m_BranchCode As String = ""
    Public m_BranchName As String = ""

    Public m_fDemo As Boolean = False
    Public m_RecordLimit As Integer = 50
    Public m_strMsgDemo As String = "Đây là phiên bản dùng thử, số lượng dữ liệu bị giới hạn."

    Public m_Logo As System.Drawing.Icon
    Public m_CancelIcon = Global.MPS.My.Resources.Resources.thoatct
    Public m_OkIcon = Global.MPS.My.Resources.Resources.check
    Public m_SaveIcon = Global.MPS.My.Resources.Resources.Luu
    Public m_SaveCloseIcon = Global.MPS.My.Resources.Resources.Luu_Thoat
    Public m_DeleteIcon = Global.MPS.My.Resources.Resources.del_32
    Public m_AddIcon = Global.MPS.My.Resources.Resources.add

    Public clsu As New VsoftBMS.Ulti.ClsUti
    Public mbc As Model.MConfigProgram
    Public m_AddColor As System.Drawing.Color = Color.FromArgb(234, 242, 251)
    Public m_AllowExportExcel As Boolean = False
    Private tbStatus As DataTable

    '<System.Runtime.InteropServices.DllImportAttribute("user32.dll")> _
    'Private Function DestroyIcon(ByVal handle As IntPtr) As Boolean
    'End Function

    Public Sub SetTitle(ByVal frm As Form, Optional ByVal title As String = "")
        frm.Text = IIf(title <> "", title, FormTitle)
        'frm.BackColor = ModMain.m_sysColor

        If m_Logo Is Nothing Then
            Dim bmp = My.Resources.globe
            Dim gp As Graphics
            gp = frm.CreateGraphics
            gp.DrawImage(bmp, 0, 0)
            Dim HIcon As IntPtr = bmp.GetHicon()
            m_Logo = System.Drawing.Icon.FromHandle(HIcon)
        End If

        frm.Icon = m_Logo
        'DestroyIcon(m_Logo.Handle)
    End Sub
    Public Function ReplaceSpecialCharacter(ByVal s As String) As String
        Dim st As String = ""
        For i As Integer = 1 To s.Length
            Dim ss As String = Mid(s, i, 1)
            If ss = "*" Or ss = "[" Or ss = "]" Or ss = "%" Then
                st += "[" & ss & "]"
            Else
                st += ss
            End If
        Next
        Return st
    End Function

    Public Sub FilterOwnerCombo(ByVal cbo As Infragistics.Win.UltraWinGrid.UltraCombo, Optional ByVal sParentFilter As String = "")
        Try
            If cbo.AutoEdit Then cbo.AutoEdit = False
            Dim sArr As String = ""
            For i As Integer = 0 To cbo.DisplayLayout.Bands(0).Columns.Count - 1
                If Not cbo.DisplayLayout.Bands(0).Columns(i).Hidden Then
                    If cbo.DisplayLayout.Bands(0).Columns(i).DataType.ToString = "System.String" Then
                        sArr += cbo.DisplayLayout.Bands(0).Columns(i).Key & ";"
                    End If
                End If
            Next

            Dim txt As TextBox = cbo.Textbox
            Dim tb As DataTable = cbo.DataSource
            If tb Is Nothing Then Exit Sub
            Dim s As String = cbo.Text
            If Not s Is Nothing Then
                s = Mid(s, 1, txt.SelectionStart)
            End If
            s = ReplaceSpecialCharacter(s)
            Dim sFilter As String = ""

            If sArr = "" Then
                sFilter = "[" & cbo.DisplayMember & "] like '%" & s.Replace("'", "''") & "%'"
            Else
                Dim a() As String = sArr.Split(";")
                For Each scol As String In a
                    If scol <> "" Then
                        sFilter += "[" & scol & "] like '%" & s.Replace("'", "''") & "%' OR "
                    End If
                Next
                If sFilter <> "" Then
                    sFilter = sFilter.Substring(0, sFilter.Length - 3).Trim
                End If
            End If

            If sParentFilter <> "" Then
                sFilter = sParentFilter & " And (" & sFilter & ")"
            End If

            Dim txt1 As TextBox = cbo.Textbox
            txt.SelectionStart = txt1.Text.Length

            tb.DefaultView.RowFilter = sFilter

        Catch ex As Exception

        End Try
    End Sub

    Public Sub FilterOwnerTextBox(ByVal cbo As Infragistics.Win.UltraWinGrid.UltraCombo, ByVal cbo1 As Infragistics.Win.UltraWinGrid.UltraCombo, ByVal Filter As String)
        Dim tb As DataTable = cbo.DataSource
        Dim tb1 As DataTable = cbo1.DataSource
        If tb Is Nothing Then Exit Sub
        Dim sFilter As String = ""
        Filter = ReplaceSpecialCharacter(Filter)
        sFilter = "s_Address like '%" & Filter.Replace("'", "''") & "%'"
        tb.DefaultView.RowFilter = sFilter
        tb1.DefaultView.RowFilter = sFilter
    End Sub

    Public Sub FilterOwnerCombo_CloseUp(ByVal cbo As Infragistics.Win.UltraWinGrid.UltraCombo, Optional ByVal sParentFilter As String = "")
        Dim tb As DataTable = cbo.DataSource
        If tb Is Nothing Then Exit Sub
        If sParentFilter <> "" Then
            tb.DefaultView.RowFilter = sParentFilter
        Else
            tb.DefaultView.RowFilter = Nothing
        End If
    End Sub
    Public Function HostName2IP(ByVal HostName As String) As String
        Try
            Dim ipEntry As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(HostName) '  System.Net.Dns.GetHostByName(HostName)
            Dim IpAddr() As System.Net.IPAddress = ipEntry.AddressList
            For Each ip As System.Net.IPAddress In IpAddr
                Dim s As String = ip.ToString
                Dim arrS() As String = s.Split(".")
                If arrS.Length = 4 Then
                    If IsNumeric(arrS(0)) And IsNumeric(arrS(1)) And IsNumeric(arrS(2)) And IsNumeric(arrS(3)) Then
                        Return s
                    End If
                End If
            Next
            If IpAddr.Length > 0 Then
                Return IpAddr(0).ToString
            End If
        Catch ex As Exception

        End Try
        Return ""
    End Function
    Public Sub TransparentAllControl(ByVal frm As Form)
        For i As Integer = 0 To frm.Controls.Count - 1
            FindCtl(frm.Controls(i))
        Next
    End Sub
    Private Sub FindCtl(ByVal ctr As Control)
        Try
            'If  Then

            'End If
            ctr.BackColor = Color.Transparent
        Catch ex As Exception

        End Try

        For i As Integer = 0 To ctr.Controls.Count - 1
            FindCtl(ctr.Controls(i))
        Next

    End Sub

    Public Sub LoadVariablesGlobally()
        Dim bCfg As BLL.B_ConfigProgram = BLL.B_ConfigProgram.Instance
        mbc = bCfg.getInfo()
        tbStatus = bCfg.getStatuses()
        Dim s1 As String = ""

        If IsNumeric(mbc.i_FormatCur) Then
            For i As Integer = 1 To CInt(mbc.i_FormatCur)
                s1 += "#"
            Next
        End If
        If s1 <> "" Then
            m_strFormatCur = m_FormatCurTemp & "." & s1
        End If

        Dim s2 As String = ""
        If IsNumeric(mbc.i_FormatNum) Then
            For i As Integer = 1 To CInt(mbc.i_FormatNum)
                s2 += "#"
            Next
        End If
        If s2 <> "" Then
            m_strFormatNum = m_FormatCurNumber & "." & s2
        End If
        m_EmpTitle = FormTitle
    End Sub

    Public Enum TypeEvents
        Syntax = 1
        List = 2
        'Begin = 3
        'Buy = 5
        Import = 4
        Curr = 6
        System = 7
        'PurchaseOrder = 8
        'Quote = 9
        Order = 10
        Store = 11
    End Enum
    Private Function CheckReg() As Boolean
        Return True
    End Function
    Private Function checkFirstRun() As Boolean
        Dim cls As New VsoftBMS.Ulti.ClsUti
        Dim s As String = cls.GetKeyInRegister("ISFIRSTRUN")
        If s = "" Then Return True
    End Function

    Private Function checkExitSQLDefautVsoft() As Boolean
        Dim clsL As BLL.BLogin = BLL.BLogin.Instance
        Dim sCNN As String = "data source=" & m_Srv & ";initial catalog=master;user id =sa;password=" & m_PWD & ";"
        Return clsL.TestConnect(sCNN)
    End Function

    Public Sub AddPortSQL()
        Dim icfMgr As INetFwMgr = Nothing
        Try
            Dim TicfMgr As Type = Type.GetTypeFromProgID("HNetCfg.FwMgr")
            icfMgr = DirectCast(Activator.CreateInstance(TicfMgr), INetFwMgr)
        Catch ex As Exception
            'ShowMsg(ex.Message,m_MsgCaption)
            Exit Sub
        End Try
        Try

            Dim profile As INetFwProfile
            Dim portClass As INetFwOpenPort
            Dim TportClass As Type = Type.GetTypeFromProgID("HNetCfg.FWOpenPort")
            portClass = DirectCast(Activator.CreateInstance(TportClass), INetFwOpenPort)
            ' Get the current profile 
            profile = icfMgr.LocalPolicy.CurrentProfile
            profile.ExceptionsNotAllowed = False

            ' Set the port properties 
            portClass.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL
            portClass.Enabled = True
            portClass.Name = "SQL_TCP"
            portClass.Port = 1433
            portClass.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP

            profile.GloballyOpenPorts.Add(portClass)

            portClass = DirectCast(Activator.CreateInstance(TportClass), INetFwOpenPort)
            portClass.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL
            portClass.Enabled = True
            portClass.Name = "SQL_UDP"
            portClass.Port = 1433
            portClass.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP

            profile.GloballyOpenPorts.Add(portClass)

            portClass = DirectCast(Activator.CreateInstance(TportClass), INetFwOpenPort)
            portClass.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL
            portClass.Enabled = True
            portClass.Name = "POS_UDP_CHAT"
            portClass.Port = 1172
            portClass.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP
            profile.GloballyOpenPorts.Add(portClass)

            portClass = DirectCast(Activator.CreateInstance(TportClass), INetFwOpenPort)
            portClass.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL
            portClass.Enabled = True
            portClass.Name = "POS_UDP_GET"
            portClass.Port = 1175
            portClass.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP
            profile.GloballyOpenPorts.Add(portClass)

            portClass = DirectCast(Activator.CreateInstance(TportClass), INetFwOpenPort)
            portClass.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL
            portClass.Enabled = True
            portClass.Name = "POS_UDP_SEND"
            portClass.Port = 1176
            portClass.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP
            profile.GloballyOpenPorts.Add(portClass)

            portClass = DirectCast(Activator.CreateInstance(TportClass), INetFwOpenPort)
            portClass.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL
            portClass.Enabled = True
            portClass.Name = "POS_CHECKKEY"
            portClass.Port = 1075
            portClass.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP
            profile.GloballyOpenPorts.Add(portClass)

            Exit Sub
        Catch ex As Exception
            'ShowMsg(ex.Message,m_MsgCaption)
        End Try

    End Sub


#Region "Show process"
    Private lockObject As New Object
    Private Sub InitProcess()
        SyncLock lockObject
            Dim frm As FrmProcess = FrmProcess.Instance
            frm.ShowDialog()
        End SyncLock
    End Sub
    Private thProcess As System.Threading.Thread
    Public Sub ShowProcess()
        Try
            thProcess = New System.Threading.Thread(AddressOf InitProcess)
            thProcess.Start()
        Catch ex As ThreadAbortException
            Thread.ResetAbort()
        End Try
    End Sub
    Public Sub HideProcess()
        Try
            thProcess.Abort()
        Catch ex As ThreadAbortException
            Thread.ResetAbort()
        End Try
    End Sub
#End Region


    Private Function getSerialNumber() As String
        Dim managementObjectSearcher = New Management.ManagementObjectSearcher("Select SerialNumber From Win32_BaseBoard")
        For Each managementObject In managementObjectSearcher.Get()
            Return managementObject("SerialNumber").ToString()
        Next
        Return ""
    End Function
    Private Function CheckNewVersion() As Boolean
        Try

            If Not My.Computer.Network.IsAvailable Then Return False
            If Not System.IO.File.Exists("AutoUpdate.exe") Then Return False

            Dim sSource As String = "http://download.vsoftgroup.com/AutoUpdate/uv100/ServerVersion.txt"
            If IO.File.Exists("LinkShare.txt") Then
                sSource = IO.File.ReadAllText("LinkShare.txt")
                If Not System.IO.File.Exists(sSource) Then Return False
            End If

            Dim sTmp As String = Application.StartupPath & "\TmpServerVersion.txt"

            Dim sLast As String = Application.StartupPath & "\ServerVersion.txt"
            Dim OLDVersion As Integer = 0
            Dim a() As String

            If IO.File.Exists(sLast) Then
                a = IO.File.ReadAllLines(sLast)
                If IsNumeric(a(0)) Then
                    OLDVersion = CInt(a(0))
                End If
            End If

            Dim wcl As New System.Net.WebClient
            wcl.DownloadFile(sSource, sTmp)
            If IO.File.Exists(sTmp) Then
                a = IO.File.ReadAllLines(sTmp)
            Else
                Return False
            End If


            Dim NewVersion As Integer = 0
            If IsNumeric(a(0)) Then
                NewVersion = CInt(a(0))
            End If
            Dim fAsk As Boolean = True
            If a.Length > 3 Then
                If IsNumeric(a(3)) AndAlso CInt(a(3)) <> 0 Then
                    fAsk = False
                End If
            End If
            If NewVersion <= OLDVersion Then
                If IO.File.Exists(sTmp) Then
                    IO.File.Delete(sTmp)
                End If
                Return False
            End If

            If Not fAsk Then
                ShowMsgInfo("Chương trình sẽ tự động nâng cấp phiên bản mới!", m_MsgCaption)
            Else
                If ShowMsgYesNo("Có bảng cập nhật mới,Bạn có muốn cập nhật chương trình tự động không?", m_MsgCaption) <> DialogResult.Yes Then
                    If IO.File.Exists(sTmp) Then
                        IO.File.Delete(sTmp)
                    End If
                    Return False
                End If
            End If

            Dim sApp As String = IO.Path.GetFileName(Application.ExecutablePath) ' Application.ProductName '"VsoftBMS.Desktop.exe"
            Dim startInfo As New ProcessStartInfo("AutoUpdate.exe")
            startInfo.Arguments = sApp
            Process.Start(startInfo)
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Public m_HDDSerial As String = ""
    Public m_PathKey As String = Application.StartupPath + "\SerialKey.ini"
    Public m_SerialKey As String = ""
    Public Const strLicense As String = "@v0$pH@t!D@T%iYcenxE@"
    Public Function IsRegistration() As Boolean
        If ModMain.m_SerialKey <> "" Then
            Dim str As String = clsu.Encrypt(ModMain.m_HDDSerial + strLicense)
            If str.Equals(ModMain.m_SerialKey) Then
                Return True
            End If
        End If
        Return False
    End Function
    Private Function getHddSerial() As String
        Dim hdd As String = ""
        Dim disk As New ManagementObject("Win32_LogicalDisk.DeviceID=""C:""")
        Dim diskPropertyA As PropertyData = disk.Properties("VolumeSerialNumber")
        hdd = diskPropertyA.Value.ToString()
        Return hdd
    End Function
    Sub Main()
        If m_fDemo Then
            FormTitle += "-Trial"
        End If
        'get version info
        Dim assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim fvi = FileVersionInfo.GetVersionInfo(assembly.Location)
        m_Version = fvi.FileVersion()

        'check key
        ModMain.m_HDDSerial = ModMain.getHddSerial()
        If System.IO.File.Exists(m_PathKey) Then
            ModMain.m_SerialKey = System.IO.File.ReadAllText(m_PathKey)
        End If
        If Not IsRegistration() Then
            Dim fr As New frmRegistration
            If Not fr.ShowDialog(True) Then
                Application.Exit()
                Exit Sub
            Else
                ModMain.m_HDDSerial = ModMain.getHddSerial()
                ModMain.m_SerialKey = System.IO.File.ReadAllText(m_PathKey)
            End If
        End If

        'show about
        'Dim frFlag As New frmFlash
        'frFlag.ShowDialog()

        'get connection
        Dim clsL As BLL.BLogin = BLL.BLogin.Instance
        clsL.getInfoConnect(m_Srv, m_UID, m_PWD, m_DB)

        m_FConnection = clsL.TestConnect()

        If Not m_FConnection Then
            Dim frmCnn As New FrmConnect
            frmCnn.ShowDialog()
        End If

        If Not m_FConnection Then
            Application.Exit()
            Exit Sub
        End If

        clsL.getInfoConnect(m_Srv, m_UID, m_PWD, m_DB)

        'show login form
        Dim frmL As New FrmLogin
        frmL.ShowDialog()

        If Not m_FLogin Then
            Application.Exit()
            Exit Sub
        End If

        'get cpu id
        m_CPUID = getSerialNumber()

        If m_CPUID Is Nothing Then
            Application.Exit()
            Exit Sub
        End If

        'get ip address
        m_strMyIPAddress = HostName2IP(My.Computer.Name)

        'add port sql
        AddPortSQL()

        Application.EnableVisualStyles()
        Application.DoEvents()

        Application.Run(New frmMain)
    End Sub

    Public Function IsNull(ByVal Exp As Object, ByVal ExpReplace As Object) As Object
        If IsDBNull(Exp) Then
            Return ExpReplace
        Else
            Return Exp
        End If
    End Function

    Private Exp As New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter

    Public Sub ExportExcel(ByVal Grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        If Grid Is Nothing Then Exit Sub
        If Grid.DataSource Is Nothing Then Exit Sub
        Dim OpenFileDialog1 As New SaveFileDialog
        OpenFileDialog1.Title = "Chọn file lưu trữ"
        OpenFileDialog1.Filter = "Excel Files(*.xls)|*.xls"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()
        Exp.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.TruncateData
        If dlg = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim sFilePath As String

        sFilePath = OpenFileDialog1.FileName
        If sFilePath = "" Then Exit Sub
        Try
            Exp.Export(Grid, sFilePath)
            ShowMsgInfo("Xuất file thành công!")
            Process.Start(sFilePath)
        Catch ex As Exception
            ShowMsg(ex.Message)
        End Try
    End Sub
    Public Sub ShowAlert(ByVal sms As String, ByVal err As String, Optional ByVal caption As String = "")
        Dim frm As New frmDialog
        frm.ShowDialog(sms, err, caption)
    End Sub
    Public Sub ShowMsg(ByVal sMsg As String, Optional ByVal sCaption As String = "")
        MessageBox.Show(sMsg, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Sub ShowMsgInfo(ByVal sMsg As String, Optional ByVal sCaption As String = "")
        MessageBox.Show(sMsg, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Function ShowMsgYesNoCancel(ByVal sMsg As String, ByVal sCaption As String) As Windows.Forms.DialogResult
        Return MessageBox.Show(sMsg, sCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    End Function
    Public Function ShowMsgYesNo(ByVal sMsg As String, Optional ByVal sCaption As String = "") As Windows.Forms.DialogResult
        Return MessageBox.Show(sMsg, sCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    End Function
    Public Function ShowMsgOKExclamation(ByVal sMsg As String, ByVal sCaption As String) As Windows.Forms.DialogResult
        Return MessageBox.Show(sMsg, sCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    End Function


    Public Function Message(ByVal Title As String, ByVal Content As String, ByVal Icon As Integer) As Boolean
        Dim frm As New VsoftBMS.Ulti.frmMsg
        Dim fSelect As Boolean = frm.ShowDialog(Title, Content, Icon)
        Return fSelect
    End Function

    Public Function ImportExcel() As DataTable
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = "Chọn file lưu trữ"
        OpenFileDialog1.Filter = "Excel Files(*.xls)|*.xls"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()
        Exp.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.TruncateData
        If dlg = Windows.Forms.DialogResult.Cancel Then
            Return Nothing
        End If
        Dim sFilePath As String

        sFilePath = OpenFileDialog1.FileName
        If sFilePath = "" Then Return Nothing
        Dim clsu As New VsoftBMS.Ulti.ClsUti
        Dim tb As DataTable = clsu.ImportDataFromExcel(sFilePath)
        Return tb

    End Function

    Public Function getDatechar(ByVal d_Date As DateTime) As String
        Dim clsL As BLL.BLogin = BLL.BLogin.Instance
        Return clsL.getDatechar(d_Date)
    End Function
    Public Function getSrvDate() As Date
        Dim cls As BLL.BLogin = BLL.BLogin.Instance
        Return cls.getSrvDate()
    End Function
    Public Function UpdateEvent(ByVal s_UID As String, ByVal s_Desc As String, ByVal i_TypeID As TypeEvents) As Boolean
        Dim cls As BLL.BEvent = BLL.BEvent.Instance
        Return cls.UPDATEDB(s_UID, s_Desc, i_TypeID)
    End Function
    Public Sub WriteLog(ByVal s_Desc As String, ByVal i_TypeID As TypeEvents)
        Dim cls As BLL.BEvent = BLL.BEvent.Instance
        cls.UPDATEDB(m_UIDLogin, s_Desc, i_TypeID)
    End Sub

    Public Function getPermitFunc(ByVal UID As String, ByVal FuncID As Integer) As Model.MFuncRight
        Dim m As New Model.MFuncRight
        If UID.ToLower <> "admin" Then
            Dim cls As BLL.BFuncRight = BLL.BFuncRight.Instance
            Dim tb As DataTable = cls.getFuncRight(UID, FuncID)
            m.A = tb.Rows(0)("A")
            m.U = tb.Rows(0)("U")
            m.D = tb.Rows(0)("D")
            m.R = tb.Rows(0)("R")
            m.FuncID = tb.Rows(0)("FuncID")
            m.UID = tb.Rows(0)("UID")
            m.IDSort = tb.Rows(0)("IDSort")
        Else
            m.A = True
            m.U = True
            m.D = True
            m.R = True
            m.FuncID = FuncID
            m.UID = UID
            m.IDSort = 0
        End If


        Return m
    End Function

    Public Function DateDiffM(ByVal Part As String, ByVal d1 As Date, ByVal d2 As Date) As Integer
        Dim clsL As BLL.BLogin = BLL.BLogin.Instance
        Return clsL.DateDiff(Part, d1, d2)
    End Function
    Public Sub SelectAll(ByVal gridName As Infragistics.Win.UltraWinGrid.UltraGrid)
        If gridName.DataSource Is Nothing Then Exit Sub
        Dim r As Infragistics.Win.UltraWinGrid.UltraGridRow = gridName.ActiveRow
        If Not r Is Nothing Then
            If r.ParentRow Is Nothing Then
                gridName.Selected.Rows.Clear()
                For Each it As Infragistics.Win.UltraWinGrid.UltraGridRow In gridName.Rows
                    If Not it.IsFilteredOut Then
                        it.Selected = True
                    End If
                Next
            Else
                Dim rParent As Infragistics.Win.UltraWinGrid.UltraGridRow = r.ParentRow
                For i As Integer = 0 To rParent.ChildBands.Count - 1
                    For Each it As Infragistics.Win.UltraWinGrid.UltraGridRow In rParent.ChildBands(i).Rows
                        If Not it.IsFilteredOut Then
                            it.Selected = True
                        End If
                    Next
                Next
            End If
        End If

    End Sub

    Public Sub GridKeyDown(ByVal Grid As UltraGrid, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = 37 Then 'Left
            Grid.PerformAction(UltraGridAction.PrevCell)
        End If

        If e.KeyCode = 39 Then 'Right
            Grid.PerformAction(UltraGridAction.NextCell)
        End If
        If e.KeyCode = 38 Then 'Up
            Dim c As UltraGridCell = Grid.ActiveCell
            If Not c Is Nothing AndAlso Not Grid.DisplayLayout.Bands(0).Columns(c.Column.Key).ValueList Is Nothing Then
                Exit Sub
            End If

            Grid.PerformAction(UltraGridAction.AboveCell)

        End If
        If e.KeyCode = 40 Then 'Down
            Dim c As UltraGridCell = Grid.ActiveCell
            If Not c Is Nothing AndAlso Not Grid.DisplayLayout.Bands(0).Columns(c.Column.Key).ValueList Is Nothing Then
                Exit Sub
            End If
            Grid.PerformAction(UltraGridAction.BelowCell)

        End If
        If e.KeyCode = 37 OrElse e.KeyCode = 38 OrElse e.KeyCode = 39 OrElse e.KeyCode = 40 Then
            Grid.PerformAction(UltraGridAction.EnterEditMode)
        End If

        If e.KeyCode = Keys.Enter Then
            Dim r As UltraGridRow = Grid.ActiveRow
            If r Is Nothing Then Exit Sub
            If r.Index = -1 Then Exit Sub
            If Grid.ActiveCell Is Nothing Then Exit Sub
            If r.IsAddRow Then r.Update()
            'Dim sCol As String = Grid.ActiveCell.Column.Key
            Dim fNext As Boolean = Grid.PerformAction(UltraGridAction.NextCell)
            If Not fNext Then
                Exit Sub
            End If

            Grid.PerformAction(UltraGridAction.EnterEditMode)

        ElseIf e.KeyCode <> 37 And e.KeyCode <> 38 And e.KeyCode <> 39 And e.KeyCode <> 40 And e.KeyCode <> Keys.Delete _
            And e.KeyCode <> Keys.F2 And e.KeyCode <> Keys.Escape And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.F9 Then
            If Grid.ActiveCell Is Nothing Then Exit Sub
            Grid.PerformAction(UltraGridAction.EnterEditMode)
        End If

    End Sub
    Public Sub GridKeyDown2(ByVal Grid As UltraGrid, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = 37 Then 'Left
            Grid.PerformAction(UltraGridAction.PrevCell)
        End If

        If e.KeyCode = 39 Then 'Right
            Grid.PerformAction(UltraGridAction.NextCell)
        End If
        If e.KeyCode = 38 Then 'Up
            Dim c As UltraGridCell = Grid.ActiveCell
            If Not c Is Nothing AndAlso Not Grid.DisplayLayout.Bands(0).Columns(c.Column.Key).ValueList Is Nothing Then
                Exit Sub
            End If
            Grid.PerformAction(UltraGridAction.AboveCell)
        End If
        If e.KeyCode = 40 Then 'Down
            Dim c As UltraGridCell = Grid.ActiveCell
            If Not c Is Nothing AndAlso Not Grid.DisplayLayout.Bands(0).Columns(c.Column.Key).ValueList Is Nothing Then
                Exit Sub
            End If
            Grid.PerformAction(UltraGridAction.BelowCell)
        End If
        If e.KeyCode = 37 OrElse e.KeyCode = 38 OrElse e.KeyCode = 39 OrElse e.KeyCode = 40 Then
            Grid.PerformAction(UltraGridAction.EnterEditMode)
        End If

        If e.KeyCode = Keys.Enter Then
            Dim r As UltraGridRow = Grid.ActiveRow
            If r Is Nothing Then Exit Sub
            If r.Index = -1 Then Exit Sub
            If Grid.ActiveCell Is Nothing Then Exit Sub
            If r.IsAddRow Then r.Update()
            Dim sCol As String = Grid.ActiveCell.Column.Key
            Dim fNext As Boolean = Grid.PerformAction(UltraGridAction.BelowCell)
            If Not fNext Then
                Exit Sub
            End If

            Grid.PerformAction(UltraGridAction.EnterEditMode)

        ElseIf e.KeyCode <> 37 And e.KeyCode <> 38 And e.KeyCode <> 39 And e.KeyCode <> 40 And e.KeyCode <> Keys.Delete _
            And e.KeyCode <> Keys.F2 And e.KeyCode <> Keys.Escape And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.F9 Then
            If Grid.ActiveCell Is Nothing Then Exit Sub
            Grid.PerformAction(UltraGridAction.EnterEditMode)
        End If

    End Sub
    Public Sub UltraCellChange(ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs)
        Try
            If e.Cell.Row.Index = -1 Then Exit Sub
            Dim c As String = e.Cell.Column.DataType.ToString
            Select Case c
                Case "System.Int64", "System.Int16", "System.Int32", "System.Double", "System.Single", "System.Decimal"
                    Dim s12321 As String = ""
                Case Else
                    Exit Sub
            End Select

            If e.Cell.Text = "" Then

                Exit Sub
            End If
            Dim str As String
            str = Mid(e.Cell.Text, 1, 1)
            If Trim(str) = "," Then
                str = Mid(e.Cell.Text, 2, Len(e.Cell.Text))
                e.Cell.Value = str
                Exit Sub
            End If
            Dim ind As Integer
            If Not IsNumeric(e.Cell.Text) Then
                If e.Cell.Text.Length > 1 Then
                    ind = e.Cell.SelStart
                    Dim s As String = e.Cell.Text.Substring(0, ind - 1)
                    Dim s1 As String = e.Cell.Text.Substring(ind)
                    s = s.Replace(",", String.Empty)
                    s1 = s1.Replace(",", String.Empty)
                    e.Cell.Value = s & s1
                    'keybd_event(Vb_End, 0, 0, 0)
                    If ind >= 0 Then
                        e.Cell.SelStart = ind
                    End If

                    Exit Sub
                End If
                e.Cell.Value = "0"
                Exit Sub
            End If
            ind = InStr(e.Cell.Text, ".")

            If ind = 0 Then
                ind = e.Cell.Text.Length - e.Cell.SelStart
                e.Cell.Value = Format(CDbl(e.Cell.Text), "#,##0")
                If ind >= 0 Then
                    e.Cell.SelStart = e.Cell.Text.Length - ind
                End If

            Else

                'Dim s As String = e.Cell.Text.Substring(0, ind - 1)
                'Dim s1 As String = e.Cell.Text.Substring(ind)
                'If s1 <> "" Then
                '    s = s.Replace(",", String.Empty)
                '    s = Format(CDbl(s), "#,##0")
                '    s1 = s1.Replace(",", String.Empty)
                '    s = s & "." & s1
                '    ind = e.Cell.Text.Length - e.Cell.SelStart
                '    e.Cell.Value = s
                '    If ind >= 0 Then
                '        e.Cell.SelStart = e.Cell.Text.Length - ind
                '    End If

                'End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SetTime(ByVal index As Integer, ByRef dtFrom As DateTimePicker, ByRef dtTo As DateTimePicker)
        If index = 8 Then
            dtFrom.Enabled = True
            dtTo.Enabled = True
        Else
            dtFrom.Enabled = False
            dtTo.Enabled = False
            Select Case index
                Case 0 ' hom nay
                    dtFrom.Value = Now
                    dtTo.Value = dtFrom.Value
                Case 1 'hom qua
                    dtFrom.Value = Now.AddDays(-1)
                    dtTo.Value = dtFrom.Value
                Case 2 'tuan nay
                    Dim ngay As Date = Now
                    Select Case ngay.DayOfWeek
                        Case DayOfWeek.Tuesday
                            ngay = ngay.AddDays(-1)
                        Case DayOfWeek.Wednesday
                            ngay = ngay.AddDays(-2)
                        Case DayOfWeek.Thursday
                            ngay = ngay.AddDays(-3)
                        Case DayOfWeek.Friday
                            ngay = ngay.AddDays(-4)
                        Case DayOfWeek.Saturday
                            ngay = ngay.AddDays(-5)
                        Case DayOfWeek.Sunday
                            ngay = ngay.AddDays(-6)
                    End Select
                    dtFrom.Value = ngay
                    dtTo.Value = ngay.AddDays(6)
                Case 3 'tuan truoc
                    Dim ngay As Date = Now
                    Select Case ngay.DayOfWeek
                        Case DayOfWeek.Tuesday
                            ngay = ngay.AddDays(-1)
                        Case DayOfWeek.Wednesday
                            ngay = ngay.AddDays(-2)
                        Case DayOfWeek.Thursday
                            ngay = ngay.AddDays(-3)
                        Case DayOfWeek.Friday
                            ngay = ngay.AddDays(-4)
                        Case DayOfWeek.Saturday
                            ngay = ngay.AddDays(-5)
                        Case DayOfWeek.Sunday
                            ngay = ngay.AddDays(-6)
                    End Select
                    dtTo.Value = ngay.AddDays(-1)
                    dtFrom.Value = ngay.AddDays(-7)
                Case 4 'thang nay
                    dtFrom.Value = Now.AddDays(-Now.Day + 1)
                    dtTo.Value = Now.AddMonths(1).AddDays(-Now.Day)
                Case 5 'thang truoc
                    dtTo.Value = Now.AddDays(-Now.Day)
                    dtFrom.Value = CDate(dtTo.Value.Year.ToString & "-" & dtTo.Value.Month.ToString & "-1")
                Case 6 'nam nay
                    dtFrom.Value = CDate(Now.Year.ToString & "-1-1")
                    dtTo.Value = CDate(Now.Year.ToString & "-12-31")
                Case 7 'nam truoc
                    dtFrom.Value = CDate((Now.Year - 1).ToString & "-1-1")
                    dtTo.Value = CDate((Now.Year - 1).ToString & "-12-31")
            End Select
        End If
    End Sub

    Public Function LoadBranch() As DataTable
        Dim db As BLL.B_Branchs = BLL.B_Branchs.Instance
        Dim tb As DataTable = db.getList()
        Return tb
    End Function
    Public Function LoadBranchByRight() As DataTable
        Dim db As BLL.B_Branchs = BLL.B_Branchs.Instance
        Dim tb As DataTable = db.getListByRight(m_UIDLogin)
        Return tb
    End Function

    ''' <summary>
    ''' load chi nhánh để check quyền tại mh login
    ''' </summary>
    ''' <param name="UID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getBranchByRightToExecute(ByVal UID As String) As DataTable
        Dim db As BLL.B_Branchs = BLL.B_Branchs.Instance
        Dim tb As DataTable = db.getListByRightToExecute(UID)
        Return tb
    End Function
    Public Sub RedButton(ByVal bt As Infragistics.Win.Misc.UltraButton, Optional ByVal ico As System.Drawing.Bitmap = Nothing)
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim cDefault As System.Drawing.Color = System.Drawing.Color.FromArgb(132, 40, 74)
        Dim cPressHot As System.Drawing.Color = System.Drawing.Color.FromArgb(214, 182, 194)
        Appearance37.BackColor = cDefault
        Appearance37.BackColor2 = cDefault
        Appearance37.BorderColor = cDefault
        Appearance37.BorderColor2 = System.Drawing.Color.Transparent
        Appearance37.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        If ico IsNot Nothing Then
            Appearance37.Image = ico
        End If
        bt.Appearance = Appearance37

        Appearance38.BackColor = cPressHot
        Appearance38.BackColor2 = cPressHot
        bt.HotTrackAppearance = Appearance38

        Appearance39.BackColor = cPressHot
        Appearance39.BackColor2 = cPressHot
        bt.PressedAppearance = Appearance39
        bt.Cursor = Cursors.Hand
    End Sub
    Public Sub GreenButton(ByVal bt As Infragistics.Win.Misc.UltraButton, Optional ByVal ico As System.Drawing.Bitmap = Nothing)
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim cDefault As System.Drawing.Color = System.Drawing.Color.FromArgb(118, 215, 108)
        Dim cPressHot As System.Drawing.Color = System.Drawing.Color.FromArgb(206, 241, 203)
        Appearance34.BackColor = cDefault
        Appearance34.BackColor2 = cDefault
        Appearance34.BorderColor = cDefault
        Appearance34.BorderColor2 = System.Drawing.Color.Transparent
        Appearance34.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        If ico IsNot Nothing Then
            Appearance34.Image = ico
        End If
        bt.Appearance = Appearance34

        Appearance35.BackColor = cPressHot
        Appearance35.BackColor2 = cPressHot
        bt.HotTrackAppearance = Appearance35

        Appearance36.BackColor = cPressHot
        Appearance36.BackColor2 = cPressHot
        bt.PressedAppearance = Appearance36
        bt.Cursor = Cursors.Hand
    End Sub
    Public Sub BlueButton(ByVal bt As Infragistics.Win.Misc.UltraButton, Optional ByVal ico As System.Drawing.Bitmap = Nothing)
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim cDefault As System.Drawing.Color = System.Drawing.Color.FromArgb(100, 151, 217)
        Dim cPressHot As System.Drawing.Color = System.Drawing.Color.FromArgb(202, 220, 242)
        Appearance34.BackColor = cDefault
        Appearance34.BackColor2 = cDefault
        Appearance34.BorderColor = cDefault
        Appearance34.BorderColor2 = System.Drawing.Color.Transparent
        Appearance34.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        If ico IsNot Nothing Then
            Appearance34.Image = ico
        End If
        bt.Appearance = Appearance34

        Appearance35.BackColor = cPressHot
        Appearance35.BackColor2 = cPressHot
        bt.HotTrackAppearance = Appearance35

        Appearance36.BackColor = cPressHot
        Appearance36.BackColor2 = cPressHot
        bt.PressedAppearance = Appearance36
        bt.Cursor = Cursors.Hand
    End Sub

    Public Function GenerateReportFilePath(ByVal filePath As String) As String
        Dim fileName = System.IO.Path.GetFileName(System.IO.Path.Combine(Application.StartupPath, filePath))
        Dim resultPath = System.IO.Path.Combine("\Reports", fileName)
        Return resultPath
    End Function

    Public Sub ChartToExcel(ByVal chart As Infragistics.Win.UltraWinChart.UltraChart)
        Try
            Dim xl As New Excel.Application
            Dim wb As Excel.Workbook = xl.Workbooks.Add
            Dim sheet As Excel.Worksheet = wb.Worksheets(1)
            sheet.Visible = Excel.XlSheetVisibility.xlSheetVisible

            'add the top title to the sheet as the header
            sheet.Range("A1").Value = chart.TitleTop.Text
            sheet.Range("A1").Font.Bold = True
            sheet.Range("A1").Font.Size = 14

            Dim dt As DataTable = CType(chart.Data.DataSource, DataTable)

            'output the headers.
            Dim intCol As Integer = 1
            For Each col As DataColumn In dt.Columns
                sheet.Cells(2, intCol) = col.ColumnName
                intCol += 1
            Next

            'Bold the headers.
            sheet.Range("A2:" & Chr(64 + intCol) & "2").Font.Bold = True
            sheet.Range("A2:" & Chr(64 + intCol) & "2").Font.Size = 12

            'start our data on row 3 of the worksheet.
            Dim intRow As Integer = 3
            For Each row As DataRow In dt.Rows
                intCol = 1
                For Each col As DataColumn In dt.Columns
                    sheet.Cells(intRow, intCol) = row.Item(col.ColumnName)
                    intCol += 1
                Next
                intRow += 1
            Next

            wb.Application.Visible = True

            Dim oChart As Excel.Chart
            'Dim xlsAxisCategory, xlsAxisValue As Excel.Axes
            Dim charts As Excel.ChartObjects = sheet.ChartObjects(Type.Missing)

            ' Adds a chart at x = 0, y = 0, 500 points wide and 300 tall.
            Dim chartObj As Excel.ChartObject = charts.Add(0, 0, 400, 300)
            oChart = chartObj.Chart

            Dim xlsSerie As Excel.SeriesCollection = oChart.SeriesCollection
            oChart.ChartType = Excel.XlChartType.xlLine
            'add 64 to intCol since ASCII A is 65 and then take the Chr() of it.BR>
            Dim chartRange As Excel.Range = sheet.Range("A1", Chr((intCol - 1) + 64) & intRow)
            oChart.SetSourceData(chartRange, Type.Missing)
            wb.Application.Visible = True

        Catch ex As Exception
            'ModMain.WriteLog(ex.Message, TypeEvents.Order)
        End Try

    End Sub

    Public Sub UltraTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim k As Short = Asc(e.KeyChar)
        If k <> 13 Then
            clsu.UltraTextBox_KeyPress(k, sender)
            If k = 0 Then
                e.Handled = True
            End If
        End If
    End Sub
    Public Sub UltraTextBox_LostFocus(ByVal sender As System.Object)
        clsu.UltraTextBox_LostFocus("", sender)
    End Sub
    Public Sub UltraTextBox_ValueChanged(ByVal sender As System.Object)
        clsu.UltraTextBox_Change("", sender)
    End Sub

    Public Function convertMoney(ByVal value As Double) As String
        Return clsu.convertMoney(value, m_SysCurChar)
    End Function

    Public Function StatusText(ByVal key As String) As String
        Dim status = ""
        If tbStatus Is Nothing OrElse key = "" Then Return status
        Dim found = tbStatus.Select("StateId='" + key + "'")
        If found IsNot Nothing Then
            status = found(0)(1).ToString()
        End If
        Return status
    End Function

    Public Sub OpenImage(ByVal PIM As Infragistics.Win.UltraWinEditors.UltraPictureBox)
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = "Chọn file"
        OpenFileDialog1.Filter = "Image Files(*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        Dim dlg As DialogResult = OpenFileDialog1.ShowDialog()

        If dlg = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim sFilePath As String

        sFilePath = OpenFileDialog1.FileName
        If sFilePath = "" Then Exit Sub
        If System.IO.File.Exists(sFilePath) = False Then
            Exit Sub
        End If
        Dim fs As IO.FileStream = New IO.FileStream(sFilePath, IO.FileMode.Open)
        Dim ArrByte As Byte() = New Byte(fs.Length) {}
        fs.Read(ArrByte, 0, fs.Length)
        fs.Close()
        Dim sm As New IO.MemoryStream(ArrByte)
        PIM.Image = Image.FromStream(sm)
        sm = Nothing
    End Sub

    Public Function ConvertByteArrayToImage(ByVal arrByte() As Byte) As Image
        If ArrByte Is Nothing Then Return Nothing
        Dim sm As New IO.MemoryStream(ArrByte)
        Return Image.FromStream(sm)
    End Function

    Public Function ConvertImageToByteArray(ByVal IM As Image) As Byte()
        Dim ms As New IO.MemoryStream
        IM.Save(ms, IM.RawFormat)
        Dim arrImage() As Byte = ms.GetBuffer
        ms.Close()
        Return arrImage
    End Function

    ''' <summary>
    ''' add thêm row cho combobox để thêm mới nhanh
    ''' </summary>
    ''' <param name="tb"></param>
    ''' <remarks></remarks>
    Public Sub AddNewRow(ByVal tb As DataTable)
        If tb Is Nothing Then Exit Sub
        Dim r As DataRow = tb.NewRow
        r(0) = ""
        r(1) = m_AddWithThreeDots
        tb.Rows.InsertAt(r, tb.Rows.Count)
    End Sub

    Public Sub PrintReport(ByVal path As String)
        Try
            ShowProcess()
            Dim fullPath = Application.StartupPath & path
            If Not System.IO.File.Exists(fullPath) Then
                ShowMsg("Không tìm thấy file: " & fullPath)
                Exit Sub
            End If

            Dim rp As New ReportDocument
            Dim clsrpt As New ClsReport
            rp = clsrpt.InitReport(fullPath)
            Dim frm As New FrmReport
            frm.rpt.ReportSource = rp
            frm.Show()
        Finally
            HideProcess()
        End Try
    End Sub
End Module
