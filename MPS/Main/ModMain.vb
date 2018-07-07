Imports NetFwTypeLib
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Management
Imports Microsoft.Office.Interop

Module ModMain
    Public m_IsSMS As Boolean = False

    Public m_IsViewAllBranch As Boolean = False
    Public m_IsViewAllStore As Boolean = False
    Public m_BranchId As String = ""
    Public m_BranchCode As String = ""
    Public m_BranchName As String = ""
    Public m_MsgCaption As String = "Thông báo"
    Public m_PathDelFirst As String = "Xóa "
    Public m_MsgCloseApp As String = "Bạn chọn đóng chương trình?"
    Public m_PathDelLast As String = " dòng đang chọn?"
    Public m_DataRelation As String = "Có dữ liệu liên quan!"
    Public m_DelError As String = "Quá trình xóa bị lỗi!"
    Public m_MsgAskDel As String = "Có thật sự xóa dòng đang chọn?"
    Public m_MsgAskSaveBeforeExit As String = "Có lưu thông tin trước khi thoát ?"
    Public m_MsgSaveSuccess As String = "Đã lưu dữ liệu!"
    Public m_MsgCreateInMonth As String = "Bạn chỉ được tạo phiếu trong tháng."
    Public m_MsgNotPermitLimitDay As String = "Bạn chỉ được cấp quyền xem đến ngày: "
    Public m_MsgViewInDay As String = "Bạn chỉ được phép xem trong ngày."
    Public m_MsgView10Day As String = "Bạn chỉ được phép xem trong 10 ngày."
    Public m_MsgView30Day As String = "Bạn chỉ được phép xem trong 30 ngày."
    Public m_MsgView60Day As String = "Bạn chỉ được phép xem trong 60 ngày."
    Public m_MsgView90Day As String = "Bạn chỉ được phép xem trong 90 ngày."
    Public m_MsgView420Day As String = "Bạn chỉ được phép xem trong 420 ngày."
    Public m_MsgViewCurrentMonth As String = "Bạn chỉ được phép xem trong tháng hiện tại."
    Public m_MsgDayError As String = "Thời gian trên máy không đúng với thời gian trên Máy chủ"

    Public m_MsgNotPermitAddNew As String = "Người dùng không được cấp quyền thêm mới !"
    Public m_MsgNotAddNewCombo As String = "Bạn không được quyền thêm mới !"
    Public m_MsgNotPermitUseThisFun As String = "Người dùng không được cấp quyền chạy chức năng này !"
    Public m_DelErrorOneItems As String = "Quá trình xóa bị lỗi. Kiểm tra và thực hiện lại !"
    Public m_SaveDataError As String = "Quá trình lưu dữ liệu có lỗi. Kiểm tra và thực hiện lại !"
    Public m_PaymentOutcome As String = "Chi công nợ"
    Public m_PaymentIncome As String = "Thu công nợ"
    Public m_AddNew As String = "Thêm mới"
    Public m_LangUnit As String = "Đơn vị tính"
    Public m_LangUnitExchange As String = "Tỉ lệ quy đổi"
    Public m_SelectAll As String = "Tất cả"
    Public m_Lang As Integer = 1
    Public clsLang As clsFormatLang

    Public UnikeyID As Integer = 0
    ''' <summary>
    ''' 0: mặc định,1: thao tác nhanh
    ''' </summary>
    ''' <remarks></remarks>
    Public i_keyEnter As Integer = 0
    Public b_IsMemberGroup As Boolean = True
    Public iTimeAlert As Integer = 5
    Public f_RefreshPurchase As Boolean = False
    ''' <summary>
    ''' True: có VAT(dùng cho bảng Offline)
    ''' </summary>
    ''' <remarks></remarks>
    Public m_IsBillVAT As Boolean = True

    '---------------------
    Public fAskClose As Boolean = True
    Public m_nCheckKey As Integer = 1 '0 : key binh thuong; 1 : Key theo safenet
    Public FormTitle As String = "CONTRACT MANAGER SOFTWARE FOR ENERGY PROJECT" '18.06.09 
    Public m_Version As String = ""
    Public m_sModuleID As String = "" '18.06.09 
    Public isExist As Boolean = False '15.06.09
    Public m_FConnection As Boolean = False
    Public m_FLogin As Boolean = False
    Public m_Srv As String = ""
    Public m_UID As String = ""
    Public m_PWD As String = ""
    Public m_DB As String = ""
    Public m_UIDLogin As String = "" 'user đăng nhập
    Public m_LoginSystem As Boolean = False
    Public m_isBackupDB As Boolean = False 'ko dung ; su dung kiem tra da bakup chua khi thu hien ket so
    Public m_CPUID As String = ""
    Public m_CompanyName As String = ""
    Public m_CompanyAddress As String = ""
    Public m_Companyphone As String = ""
    Public m_TaxNo As String = "" 'ma so thue cong ty 
    '---------------------
    Private m_FormatCurTemp As String = "#,##0"
    Private m_FormatCurNumber As String = "#,##0"
    Public m_strFormatCur As String = m_FormatCurTemp '& m_strDecCur 'định dạng tiền tệ
    Public m_strFormatNum As String = m_FormatCurNumber '& m_strDecNum 'định dạng số
    Public m_SysCur As String = "VND" 'định dạng đơn vị tiền tệ
    Public m_KeySysCur As String = "" ' ma don vi tien te
    Public m_SysCurChar As String = "đồng" '26.11.09-doc tien bang chu
    '---------------------
    Public m_SysDiscountBeforeTax As Boolean = True 'tính chiết khấu trước thuế/sau thuế
    Public m_SysDiscountProduct As Boolean = True '10.11.08-tính chiết khấu hàng
    Public m_isTrackPurchaseOrder As Boolean = False '11.12.08-không theo dõi đơn đặt hàng/ngược lại
    Public m_CheckInstock As Boolean = True 'Cho phep xuat hang am hay ko ; Lay tu thong tin cau hinh he thong 
    Public m_s_PayTermHH As String = "" ' chi hoa hồng
    Public m_s_PayTermCL As String = "" ' chi lương
    Public m_s_PayTermTU As String = "" ' chi tạm ứng
    Public m_s_ThuTamUng As String = "" 'Thu tạm ứng
    Public m_s_PayImport As String = "" ' nhâp dieu chinh 
    Public m_s_PayOrder As String = "" ' xuat dieu chinh
    Public m_s_TransCurrInc As String = "" 'Phương thức Thu luân chuyển
    Public m_s_TransCurrOut As String = "" 'Phương thức Chi luân chuyển
    Public m_SysCommissionBeforeDiscount As Boolean = True '10.11.08-Truớc giảm giá
    Public m_isAllowOrderOver As Boolean = False '18.01.10- cau hinh cho phep xuat, nhap vuot, mac dinh la k cho
    Public m_isMultiStore As Boolean = False '26.05.10-cho phep xuat hang tu nhieu kho
    Public m_b_isCheckBeforeTurnOut As Boolean = False '27.05.10-kiem tra hang nhap mua truoc khi xuat tra
    Public m_isEmptyList As Integer = 0 '30.08.10-tuy chon load danh sach hang hoa tren man hinh nghiep vu
    '=====m_isEmptyList=0: load danh sach hang hoa theo cau hinh (nhom hang theo setting/mac dinh nhom dau tien trong danh sach nhom)
    '=====m_isEmptyList=1: load danh sach hang hoa co 0 dong du lieu vi nhom hien thi gia tri null
    'Public m_TempEmpty As Integer = 0

    '---------------------
    Public m_RecordLimit As Integer = 50
    Public m_strMsgDemo As String = "Đây là phiên bản dùng thử, số lượng dữ liệu bị giới hạn."
    Public m_bIsBarcode As Boolean = True
    Public m_strMsgRei As String = ""
    Public m_strMyIPAddress As String = ""
    Public sAddressServer As String = ""
    Public m_strLableStatus As String = "Click phải trên danh sách phiếu chọn menu chức năng ..."
    Public m_strLableList As String = "Click phải trên danh sách chọn menu chức năng ..."
    Public m_strLabelStatusSingle As String = "Click phải chọn Xem chi tiết hàng hóa"
    Public m_strLabelStatusSingleBuy As String = "Click phải chọn Xem | Thêm hàng hóa"
    Public m_strChooseProductTip As String = "Double click chọn hàng"
    Public b_money As Boolean
    Public b_ItemClick As Boolean
    Public m_b_isEDiscount As Boolean = False
    Public m_b_isEProgressive As Boolean = False
    Public m_i_NumColExchange As Integer = 2 'so cot toi thieu cho cong thuc qui doi
    Public m_s_MethodExchange As String = "*" 'cong thuc mac dinh cho CT qui doi

    Public m_DateUpdateDB As Date = CDate("2009-12-11") 'thay doi file UpdateDB.sql ngay nao thi Ghi vao day ngay do
    Public m_NoteDB As String = "Nâng cấp dữ liệu" 'Ghi chu khi thay doi file UpdateDB.sql
    '---------------------
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
    Public m_CheckPurchase As Boolean = False
    Public m_LimitRevenue As Double = 100000 'doanh so dinh muc ~ 1đ

    Public m_CheckKey As Boolean = False
    Public m_ChoPhepXuatExcel As Boolean = False
    Public m_ChoPhepTaoPhieuKhacNgay As Boolean = False
    Public m_ChoPhepTaoPhieuTrongThang As Boolean = False
    Public m_ChoPhepThayDoiSoPhieu As Boolean = False
    ''' <summary>
    ''' True: cho phép thay đổi giá bán
    ''' </summary>
    ''' <remarks></remarks>
    Public m_ChoPhepSuaGiaBan As Boolean = False
    Public m_IsSendCode As Boolean = False
    ''' <summary>
    ''' true: load hình ảnh của hàng hóa
    ''' </summary>
    ''' <remarks></remarks>
    Public m_isLoadImageProduct As Boolean = True
    Public m_Logo As System.Drawing.Icon
    Public m_fDemo As Boolean = False
    Public m_Dashboard As frmDashboard
    Public m_CancelIcon = Global.MPS.My.Resources.Resources.thoatct
    Public m_OkIcon = Global.MPS.My.Resources.Resources.check
    Public m_SaveIcon = Global.MPS.My.Resources.Resources.Luu

    <System.Runtime.InteropServices.DllImportAttribute("user32.dll")> _
    Private Function DestroyIcon(ByVal handle As IntPtr) As Boolean
    End Function
    Public Sub SetTitle(ByVal frm As Form, Optional ByVal title As String = "")
        frm.Text = IIf(title <> "", title, FormTitle)
        frm.BackColor = ModMain.m_sysColor

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

    Public Sub FilterOwnerComboOld(ByVal cbo As Infragistics.Win.UltraWinGrid.UltraCombo, Optional ByVal sParentFilter As String = "")
        Try

            If cbo.AutoEdit Then cbo.AutoEdit = False
            Dim txt As TextBox = cbo.Textbox
            Dim tb As DataTable = cbo.DataSource
            If tb Is Nothing Then Exit Sub
            Dim s As String = cbo.Text
            If Not s Is Nothing Then
                s = Mid(s, 1, txt.SelectionStart)
            End If
            s = ReplaceSpecialCharacter(s)
            Dim sCol As String = cbo.DisplayMember
            Dim sFilter As String = "[" & sCol & "] like '%" & s.Replace("'", "''") & "%'"
            If sParentFilter <> "" Then
                sFilter += " And " & sParentFilter
            End If
            tb.DefaultView.RowFilter = sFilter
        Catch ex As Exception

        End Try
    End Sub
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
                sFilter = sParentFilter & " And (" & sFilter & ")" ' Thảo thay dòng trên bằng dòng này
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

    Public Sub SendMessageSRV(ByVal sMsg As String, ByVal sServer As String)
        Dim srv As New getDataSocket.Vsoft.Server
        srv.Protocol = Net.Sockets.ProtocolType.Udp
        srv.ClientPort = 1176
        srv.Encode = getDataSocket.Vsoft.EncodingType.Unicode
        Try
            srv.ClientAddress = Net.IPAddress.Parse(sServer)
            srv.SendMessage(sMsg)
        Catch ex As Exception

        End Try
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
    Public mbc As Model.MConfigProgram
    Public tbConfigReport As DataTable


    ''' <summary>
    ''' Tuy chon thoi gian de loc danh sach nghiep vu
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum OptionTime
        TatCa = 0
        Ngay90 = 1
        Ngay60 = 2
        Ngay30 = 3
        Ngay10 = 4
        Ngay1 = 5
        Thang1 = 6
        Ngay420 = 7
    End Enum

    ''' <summary>
    ''' xem
    ''' </summary>
    ''' <remarks></remarks>
    Public m_isView As OptionTime = OptionTime.TatCa
    ''' <summary>
    ''' tao moi phieu trong ngay
    ''' </summary>
    ''' <remarks></remarks>
    Public m_isAddInDay As Boolean = False

    Public m_dtFrom As Date = CDate("1900-1-1")
    Public m_dtTo As Date = CDate("1900-1-1")
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadFunRightByTime()
        If m_UIDLogin.ToLower <> "admin" Then
            m_isAddInDay = getPermitFunc(m_UIDLogin, 118).R
        End If

        Dim m_Tatca As Model.MFuncRight = getPermitFunc(m_UIDLogin, 117)
        Dim m_90ngay As Model.MFuncRight = getPermitFunc(m_UIDLogin, 116)
        Dim m_60ngay As Model.MFuncRight = getPermitFunc(m_UIDLogin, 115)
        Dim m_30ngay As Model.MFuncRight = getPermitFunc(m_UIDLogin, 114)
        Dim m_10ngay As Model.MFuncRight = getPermitFunc(m_UIDLogin, 113)
        Dim m_1ngay As Model.MFuncRight = getPermitFunc(m_UIDLogin, 112)
        Dim m_1thang As Model.MFuncRight = getPermitFunc(m_UIDLogin, 119)
        Dim m_420ngay As Model.MFuncRight = getPermitFunc(m_UIDLogin, 121)

        If Not m_Tatca.R Then
            If Not m_420ngay.R Then
                If Not m_90ngay.R Then
                    If Not m_60ngay.R Then
                        If Not m_30ngay.R Then
                            If Not m_1thang.R Then
                                If Not m_10ngay.R Then
                                    If m_1ngay.R Then
                                        m_isView = OptionTime.Ngay1
                                        m_dtTo = Now
                                        m_dtFrom = m_dtTo
                                    End If
                                Else
                                    m_isView = OptionTime.Ngay10
                                    m_dtTo = Now
                                    m_dtFrom = m_dtTo.AddDays(-10)
                                End If
                            Else
                                m_isView = OptionTime.Thang1
                                m_dtFrom = Now.AddDays(-Now.Day + 1)
                                m_dtTo = m_dtFrom.AddMonths(1).AddDays(-1)
                            End If
                        Else
                            m_isView = OptionTime.Ngay30
                            m_dtTo = Now
                            m_dtFrom = m_dtTo.AddMonths(-1)
                        End If
                    Else
                        m_isView = OptionTime.Ngay60
                        m_dtTo = Now
                        m_dtFrom = m_dtTo.AddMonths(-2)
                    End If
                Else
                    m_isView = OptionTime.Ngay90
                    m_dtTo = Now
                    m_dtFrom = m_dtTo.AddMonths(-3)
                End If
            Else
                m_isView = OptionTime.Ngay420
                m_dtTo = Now
                m_dtFrom = m_dtTo.AddDays(-420)
            End If
        Else
            m_isView = OptionTime.TatCa
            m_dtTo = CDate("1900-1-1")
            m_dtFrom = CDate("1900-1-1")
        End If
    End Sub
    Public Sub LoadVariablesGlobally()
        Dim bCfg As BLL.B_ConfigProgram = BLL.B_ConfigProgram.Instance
        Dim m As Model.MConfigProgram = bCfg.getInfo()
        tbConfigReport = bCfg.GetConfigReport
        mbc = m
        Dim s1 As String = ""

        If IsNumeric(m.i_FormatCur) Then
            For i As Integer = 1 To CInt(m.i_FormatCur)
                s1 += "#"
            Next
        End If
        If s1 <> "" Then
            m_strFormatCur = m_FormatCurTemp & "." & s1
        End If

        Dim s2 As String = ""
        If IsNumeric(m.i_FormatNum) Then
            For i As Integer = 1 To CInt(m.i_FormatNum)
                s2 += "#"
            Next
        End If
        If s2 <> "" Then
            m_strFormatNum = m_FormatCurNumber & "." & s2
        End If
        m_SysCur = m.s_SysCur
        m_KeySysCur = m.s_KeySysCur
        If m.s_SysCurChar = "" Then '26.11.09
            Select Case m_SysCur
                Case "VND"
                    m_SysCurChar = "đồng chẵn"
                Case "USD"
                    m_SysCurChar = "đô la"
            End Select
        Else
            m_SysCurChar = m.s_SysCurChar
        End If
        m_LimitRevenue = m.m_LimitRevenue
        m_SysDiscountBeforeTax = m.b_SysDiscountBeforeTax
        m_SysCommissionBeforeDiscount = m.b_SysCommission
        m_SysDiscountProduct = True 'bỏ tính chiet khau hang
        m_isTrackPurchaseOrder = m.b_isTrackPurchaseOrder
        m_CheckInstock = m.b_CheckInstock
        m_CompanyName = m.s_CompanyName
        m_CompanyAddress = m.s_Address
        m_s_PayTermHH = m.s_MethodHH
        m_s_PayTermCL = m.s_MethodCL
        m_s_PayTermTU = m.s_MethodTU
        m_s_ThuTamUng = m.s_ThuTamUng
        m_s_PayImport = m.s_MethodImport
        m_s_PayOrder = m.s_MethodOrder
        m_b_isEDiscount = m.b_isEDiscount
        m_b_isEProgressive = m.b_isEProgressive
        m_CheckPurchase = m.b_Purchase
        m_s_TransCurrInc = m.s_TransCurrInc
        m_s_TransCurrOut = m.s_TransCurrOut
        m_TaxNo = m.s_TaxNo.Trim

        If m.s_Phone2 <> "" Then
            m_Companyphone = m.s_Phone1 & " - " & m.s_Phone2
        Else
            m_Companyphone = m.s_Phone1
        End If
        m_isMultiStore = m.b_isMultiStore '26.05.10
        m_b_isCheckBeforeTurnOut = m.b_isCheckBeforeTurnOut '27.05.10
        m_isEmptyList = m.i_ShowForm
        iTimeAlert = m.i_TimeAlertDown
        i_keyEnter = My.Settings.KeyEnter
        b_IsMemberGroup = My.Settings.IsMemberGroup
        m_i_NumColExchange = m.i_NumColExchange
        m_s_MethodExchange = m.s_MethodExchange
        m_EmpTitle = FormTitle
    End Sub

    Public Structure InfoDebtObject
        Public TotalIncome As Double
        Public TotalOutcome As Double
        Public Over_1_30 As Double
        Public Over_31_60 As Double
        Public Over_61_90 As Double
        Public Over_90 As Double
        Public Trade_Month As Double
        Public Trade_Year As Double
        Public Trade_Last_Year As Double
        Public Trade_All As Double
    End Structure
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

    Public Sub UPdateColorSystem()
        Dim cls As New VsoftBMS.Ulti.ClsUti
        cls.CreateKeyInRegister("COLORSYS.A", m_sysColor.A.ToString)
        cls.CreateKeyInRegister("COLORSYS.R", m_sysColor.R.ToString)
        cls.CreateKeyInRegister("COLORSYS.G", m_sysColor.G.ToString)
        cls.CreateKeyInRegister("COLORSYS.B", m_sysColor.B.ToString)
    End Sub
    Public Sub LoadColorSystem()
        'Dim cls As New VsoftBMS.Ulti.ClsUti
        'Dim A As String = cls.GetKeyInRegister("COLORSYS.A")

        'If A <> "" Then
        '    Dim R As String = cls.GetKeyInRegister("COLORSYS.R")
        '    Dim G As String = cls.GetKeyInRegister("COLORSYS.G")
        '    Dim B As String = cls.GetKeyInRegister("COLORSYS.B")
        '    m_sysColor = Color.FromArgb(CInt(A), CInt(R), CInt(G), CInt(B))
        'Else
        '    m_sysColor = Color.FromArgb(255, 216, 228, 248)
        '    UPdateColorSystem()
        'End If
    End Sub
#Region "Kiem tra va udpate DB"
    Private fr As New FrmProcess
    Private thread As Threading.Thread
    Private Sub ShowProgress(ByVal strTitle As String)
        If fr Is Nothing Then fr = New FrmProcess
        'frm.Owner = Me
        fr.StartPosition = FormStartPosition.CenterScreen
        fr.Title = strTitle
        fr.Show()
        fr.Refresh()
    End Sub
    Private Sub ProgressRefresh()
        Try
            While Not thread Is Nothing AndAlso thread.ThreadState = Threading.ThreadState.Running
                If Not fr Is Nothing Then
                    fr.Refresh()
                    Threading.Thread.Sleep(200)
                End If
            End While
        Catch ex As Exception

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
            Dim clsu As New VsoftBMS.Ulti.ClsUti
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

        'set multi language
        clsLang = New clsFormatLang
        If m_Lang <> 1 Then
            Infragistics.Win.DrawUtility.UseGDIPlusTextRendering = False
            m_MsgCaption = clsLang.getLang(m_Lang, 5)
            m_PathDelFirst = clsLang.getLang(m_Lang, 11) & " "
            m_PathDelLast = clsLang.getLang(m_Lang, 12)

            m_DataRelation = clsLang.getLang(m_Lang, 22)
            m_DelError = clsLang.getLang(m_Lang, 858)
            m_MsgAskDel = clsLang.getLang(m_Lang, 84)
            m_MsgAskSaveBeforeExit = clsLang.getLang(m_Lang, 2)
            m_MsgSaveSuccess = clsLang.getLang(m_Lang, 10)
            m_MsgNotPermitAddNew = clsLang.getLang(m_Lang, 8)
            m_MsgNotAddNewCombo = clsLang.getLang(m_Lang, 1336)
            m_MsgNotPermitUseThisFun = clsLang.getLang(m_Lang, 43)
            m_DelErrorOneItems = clsLang.getLang(m_Lang, 1017)
            m_SaveDataError = clsLang.getLang(m_Lang, 310)

            m_PaymentOutcome = clsLang.getLang(m_Lang, 696)
            m_PaymentIncome = clsLang.getLang(m_Lang, 668)
            m_AddNew = clsLang.getLang(m_Lang, 1)

            m_SelectAll = clsLang.getLang(m_Lang, 379)

            m_LangUnit = clsLang.getLang(m_Lang, 698)
            m_LangUnitExchange = clsLang.getLang(m_Lang, 1494)
        End If

        'load system color
        LoadColorSystem()

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
        Dim frm As New frmMain
        Application.Run(frm)
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
            ShowMsgInfoMultiLang("Xuất file thành công!", 1162)
            Dim p As New Process
            Process.Start(sFilePath)
        Catch ex As Exception

        End Try
    End Sub
    'Public Sub ShowMsg(ByVal sMsg As String, Optional ByVal sCaption As String = "Thông báo")
    '    MessageBox.Show(sMsg, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    'End Sub

    'Public Sub ShowMsgInfo(ByVal sMsg As String, Optional ByVal sCaption As String = "Thông báo")
    '    MessageBox.Show(sMsg, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
    'End Sub

    'Public Function ShowMsgYesNoCancel(ByVal sMsg As String, Optional ByVal sCaption As String = "Thông báo") As Windows.Forms.DialogResult
    '    Return MessageBox.Show(sMsg, sCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    'End Function
    'Public Function ShowMsgYesNo(ByVal sMsg As String, Optional ByVal sCaption As String = "Thông báo") As Windows.Forms.DialogResult
    '    Return MessageBox.Show(sMsg, sCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    'End Function
    'Public Function ShowMsgOKExclamation(ByVal sMsg As String, Optional ByVal sCaption As String = "Thông báo") As Windows.Forms.DialogResult
    '    Return MessageBox.Show(sMsg, sCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    'End Function
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
    Public Function ShowMsgYesNo(ByVal sMsg As String, ByVal sCaption As String) As Windows.Forms.DialogResult
        Return MessageBox.Show(sMsg, sCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    End Function
    Public Function ShowMsgOKExclamation(ByVal sMsg As String, ByVal sCaption As String) As Windows.Forms.DialogResult
        Return MessageBox.Show(sMsg, sCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    End Function

    'ShowMsgOKExclamation
    'Thao:21.07.11
    Public Function TextMultiLang(ByVal iLang As Integer, ByVal TextVN As String, ByVal IDTextEN As Integer) As String
        Dim str As String = ""
        If iLang = 1 Then
            str = TextVN
        Else
            str = clsLang.getLang(iLang, IDTextEN)
        End If

        Return str
    End Function
    'Thao:21.07.11
    Public Sub ShowMsgInfoMultiLang(ByVal MsgVN As String, ByVal IDMsgEN As Integer)
        If m_Lang = 1 Then
            ShowMsgInfo(MsgVN, m_MsgCaption)
        Else
            ShowMsgInfo(clsLang.getLang(m_Lang, IDMsgEN), m_MsgCaption)
        End If
    End Sub

    Public Sub ShowMsgMultiLang(ByVal MsgVN As String, ByVal IDMsgEN As Integer)
        If m_Lang = 1 Then
            ShowMsg(MsgVN, m_MsgCaption)
        Else
            ShowMsg(clsLang.getLang(m_Lang, IDMsgEN), m_MsgCaption)
        End If
    End Sub
    Public Function ShowMsgMultiLangYesNoCancel(ByVal MsgVN As String, ByVal ID As Integer) As Windows.Forms.DialogResult
        If m_Lang = 1 Then
            Return MessageBox.Show(MsgVN, m_MsgCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Else
            Return MessageBox.Show(clsLang.getLang(m_Lang, ID), m_MsgCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        End If

    End Function
    Public Function ShowMsgMultiLangYesNo(ByVal MsgVN As String, ByVal ID As Integer) As Windows.Forms.DialogResult
        If m_Lang = 1 Then
            Return MessageBox.Show(MsgVN, m_MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Else
            Return MessageBox.Show(clsLang.getLang(m_Lang, ID), m_MsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        End If

    End Function
    '14/04/2009
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
    Public Function getInfoDebtObject(ByVal Object_ID As String, ByVal isCustomer As Boolean) As InfoDebtObject
        Dim clsP As BLL.BPublic = BLL.BPublic.Instance
        Dim tb As DataTable = clsP.getInfoDebtObject(Object_ID, isCustomer)
        Dim info As New InfoDebtObject
        With info
            .Over_1_30 = tb.Rows(0)("Over 1-30")
            .Over_31_60 = tb.Rows(0)("Over 31-60")
            .Over_61_90 = tb.Rows(0)("Over 61-90")
            .Over_90 = tb.Rows(0)("Over 90")
            .TotalIncome = tb.Rows(0)("TotalIncome")
            .TotalOutcome = tb.Rows(0)("TotalOutcome")
            .Trade_All = tb.Rows(0)("Trade All")
            .Trade_Last_Year = tb.Rows(0)("Trade Last Year")
            .Trade_Month = tb.Rows(0)("Trade Month")
            .Trade_Year = tb.Rows(0)("Trade Year")
        End With
        Return info
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
        Dim cls As New BLL.BEvent
        Return cls.UPDATEDB(s_UID, s_Desc, i_TypeID)
    End Function
    Public Sub WriteLog(ByVal s_Desc As String, ByVal i_TypeID As TypeEvents)
        Dim cls As New BLL.BEvent
        cls.UPDATEDB(m_UIDLogin, s_Desc, i_TypeID)
    End Sub

    Public Function getPermitStore(ByVal UID As String, ByVal store_ID As String) As Model.MFuncRight
        Dim m As New Model.MFuncRight
        Dim cls As New BLL.BFuncRight

        If UID.ToLower <> "admin" Then
            Dim tb As DataTable = cls.getFuncRightStore(UID, store_ID)
            If tb Is Nothing Then Return m
            m.A = tb.Rows(0)("A")
            m.U = tb.Rows(0)("U")
            m.D = tb.Rows(0)("D")
            m.R = tb.Rows(0)("R")
            m.FuncID = 0
            m.sFuncID = tb.Rows(0)("FuncID")
            m.UID = tb.Rows(0)("UID")
            m.IDSort = tb.Rows(0)("IDSort")
        Else
            m.A = True
            m.U = True
            m.D = True
            m.R = True
            m.FuncID = 0
            m.sFuncID = 0
            m.UID = UID
            m.IDSort = 0
        End If

        Return m
    End Function

    Public Function getPermitFunc(ByVal UID As String, ByVal FuncID As Integer) As Model.MFuncRight
        Dim m As New Model.MFuncRight
        If UID.ToLower <> "admin" Then
            Dim cls As New BLL.BFuncRight
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

    'ham filter danh sach hang hoa
    Public Sub FilterProduct(ByVal GridProduct As UltraGrid, ByVal txtBarcode As UltraTextEditor, ByVal txtFind1 As UltraTextEditor, ByVal txtFind2 As UltraTextEditor, _
                              ByVal RProductName As Boolean, ByVal fTextChange As Boolean)

        Dim tb As DataTable = GridProduct.DataSource
        If tb Is Nothing Then Exit Sub
        Dim s As String = "", st As String = ""

        Dim sBarcode As String = ""
        If Not m_bIsBarcode And txtBarcode.Text <> "" And fTextChange Then
            Dim ind As Integer = txtBarcode.SelectionStart
            sBarcode = txtBarcode.Text.Substring(0, ind)
            sBarcode = ReplaceSpecialCharacter(sBarcode)
            If sBarcode <> "" Then
                st = "s_Product_ID like '" & sBarcode.Replace("'", "''") & "%'"
                st += " or iTemCode like '" & sBarcode.Replace("'", "''") & "%'"
            End If
        End If

        s = ReplaceSpecialCharacter(txtFind1.Text).Trim.Replace("'", "''")
        If txtFind1.Text <> "" Then
            If RProductName Then
                If st = "" Then
                    st = "s_Name like '%" & s & "%'"
                Else
                    st += " and s_Name like '%" & s & "%'"
                End If
            Else
                If st = "" Then
                    st = "s_Product_ID like '%" & s & "%'"
                    st += " or iTemCode like '%" & s & "%'"
                Else
                    st += " and s_Product_ID like '%" & s & "%'"
                    st += " or iTemCode like '%" & s & "%'"
                End If
            End If

        End If
        s = ReplaceSpecialCharacter(txtFind2.Text).Trim.Replace("'", "''")
        If txtFind2.Visible And txtFind2.Text <> "" Then
            If st = "" Then
                st = "s_Name like '%" & s & "%'"
            Else
                st += " and s_Name like '%" & s & "%'"
            End If
        End If

        If st <> "" Then
            tb.DefaultView.RowFilter = st
        Else
            tb.DefaultView.RowFilter = Nothing
        End If

        If GridProduct.Rows.Count > 0 Then
            GridProduct.Rows(0).Activate()
            If Not m_bIsBarcode And fTextChange Then
                txtBarcode.Text = GridProduct.Rows(0).Cells("s_Product_ID").Value
                'If sBarcode.Length < txtBarcode.Text.Length Then
                txtBarcode.SelectionStart = sBarcode.Length
                txtBarcode.SelectionLength = txtBarcode.Text.Length
                'End If
            End If
        Else
            If Not fTextChange Then
                txtBarcode.Text = ""
            End If
        End If
    End Sub
    'ham tinh thue+CK

    Public Sub SubTotalVAT_Dis(ByVal iLock As Integer, ByVal iKeyTax As Integer, ByVal txtTotalDiscount As UltraTextEditor, ByVal txtPercent As UltraTextEditor, ByVal txtMPercent As UltraTextEditor, _
                                ByVal cboTax As UltraComboEditor, ByVal txtTotalTax As UltraTextEditor, ByVal txtEndTotal As UltraTextEditor)
        Dim total As Decimal = 0
        Dim tienhang As Double = 0
        If IsNumeric(txtTotalDiscount.Text) Then
            tienhang = CDbl(txtTotalDiscount.Text)
        End If
        total = tienhang
        Dim dis As Double = 0
        Dim vat As Double = 0

        If ModMain.m_SysDiscountBeforeTax Then 'tính chiết khấu trưoc thuế
            If iLock = 1 Then 'nhap % CK
                dis = CDbl(txtPercent.Text) / 100
                txtMPercent.Text = Format(total * dis, ModMain.m_strFormatCur)
            Else 'nhap CK
                If total <> 0 Then
                    txtPercent.Text = Format(CDbl(txtMPercent.Text) * 100 / total, "#,##0.###")
                Else
                    txtPercent.Text = 0 : txtMPercent.Text = 0
                End If
            End If

            total -= CDbl(txtMPercent.Text)

            If iKeyTax = 1 Then 'nhap tax %
                If IsNumeric(cboTax.Text) Then
                    vat = CDbl(cboTax.Text) / 100
                End If
                txtTotalTax.Text = Format(total * vat, ModMain.m_strFormatCur)
            Else
                If total <> 0 Then
                    cboTax.Value = Format(CDbl(txtTotalTax.Text) * 100 / total, "#,##0.###")
                Else
                    cboTax.SelectedIndex = 0 : txtTotalTax.Text = 0
                End If
            End If
        Else 'tinh thue truoc CK
            If iKeyTax = 1 Then 'nhap tax %
                If IsNumeric(cboTax.Text) Then
                    vat = CDbl(cboTax.Text) / 100
                End If
                txtTotalTax.Text = Format(total * vat, ModMain.m_strFormatCur)
            Else
                If total <> 0 Then
                    cboTax.Value = Format(CDbl(txtTotalTax.Text) * 100 / total, "#,##0.###")
                Else
                    cboTax.SelectedIndex = 0 : txtTotalTax.Text = 0
                End If
            End If

            total += CDbl(txtTotalTax.Text)

            If iLock = 1 Then 'nhap % CK
                dis = CDbl(txtPercent.Text) / 100
                txtMPercent.Text = Format(total * dis, ModMain.m_strFormatCur)
            Else 'nhap CK
                If total <> 0 Then
                    txtPercent.Text = Format(CDbl(txtMPercent.Text) * 100 / total, "#,##0.###")
                Else
                    txtPercent.Text = 0 : txtMPercent.Text = 0
                End If
            End If
        End If

        txtEndTotal.Text = Format((tienhang + CDbl(txtTotalTax.Text) - CDbl(txtMPercent.Text)), ModMain.m_strFormatCur)

    End Sub

#Region "Ultility"
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

#End Region
    Public Enum FilterObject
        ALL = 0
        Customer = 1
        Supplier = 2
    End Enum
    Public Enum AddNewRowObject
        None = 0
        AddNew_ALL = 1
        AddNew_New = 2
    End Enum
    Public Function ExecuteDelete(ByVal iType As Integer, ByVal id As String) As Boolean
        Dim cls As BLL.BPublic = BLL.BPublic.Instance

    End Function

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

    Public Enum OptionAddOrNew
        None = 0
        AddNew = 1
        SelectAll = 2
    End Enum
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
    Public Function LoadBranchWithAll() As DataTable
        Dim db As BLL.B_Branchs = BLL.B_Branchs.Instance
        Dim tb As DataTable = db.getList()
        If Not IsNothing(tb) Then
            Dim r = tb.NewRow
            r("s_ID") = ""
            r("s_Name") = m_SelectAll
            tb.Rows.InsertAt(r, 0)
        End If
        Return tb
    End Function
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
    Public Function LoadBranchByRightWithAll() As DataTable
        Dim uid = m_UIDLogin
        If ModMain.m_IsViewAllBranch Then 't/h quyền Chỉ xem Tất cả(xóa chi tiết ds chi nhánh, chỉ load 1 dòng Tất cả)
            uid = "m_IsViewAllBranch" 'gán 1 giá trị nào đó
        End If
        Dim db As BLL.B_Branchs = BLL.B_Branchs.Instance
        Dim tb As DataTable = db.getListByRight(uid)
        If Not IsNothing(tb) Then
            Dim r = tb.NewRow
            r("s_ID") = "-1"
            r("s_Name") = m_SelectAll
            tb.Rows.InsertAt(r, 0)
        End If
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
    ''' <summary>
    ''' In bill phieu xuat hang
    ''' </summary>
    ''' <param name="orderId">ma phieu XBH</param>
    ''' <remarks></remarks>
    Public Sub PrintOrder(ByVal orderId As String)
        Try
            Dim path = Application.StartupPath & "\Reports\rptBill.rpt"
            If Not System.IO.File.Exists(path) Then
                ShowMsg("Không tìm thấy mẫu in." & vbCrLf & path)
                Exit Sub
            End If
            Dim clsrpt As New ClsReport
            Dim rp As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            rp = clsrpt.InitReport(path)
            If rp IsNot Nothing Then
                clsrpt.SetParameter(rp, ModMain.m_SysCur, orderId, mbc.i_FormatCur, mbc.i_FormatNum)
                For i As Integer = 1 To mbc.i_Countprint
                    rp.PrintToPrinter(1, False, 0, 0)
                Next
            End If
        Catch ex As Exception
            ModMain.WriteLog(ex.Message, TypeEvents.Order)
        End Try
    End Sub
    ''' <summary>
    ''' In bill phieu xuat hang
    ''' </summary>
    ''' <param name="orderId">ma phieu XBH</param>
    ''' <remarks></remarks>
    Public Sub PrintOrderTemp(ByVal orderId As String)
        Try
            Dim path = Application.StartupPath & "\Reports\rptBillTemp.rpt"
            If Not System.IO.File.Exists(path) Then
                ShowMsg("Không tìm thấy mẫu in." & vbCrLf & path)
                Exit Sub
            End If
            Dim clsrpt As New ClsReport
            Dim rp As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            rp = clsrpt.InitReport(path)
            If rp IsNot Nothing Then
                clsrpt.SetParameter(rp, ModMain.m_SysCur, orderId, mbc.i_FormatCur, mbc.i_FormatNum)
                rp.PrintToPrinter(1, False, 0, 0)
                'Sound.PlayWaveFile(Sound.TypeSound.transaction_complete)
            End If
        Catch ex As Exception
            ModMain.WriteLog(ex.Message, TypeEvents.Order)
        End Try
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
            ModMain.WriteLog(ex.Message, TypeEvents.Order)
        End Try

    End Sub
End Module
