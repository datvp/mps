Public Class MConfigProgram
    Private m_i_ID As Integer = 0
    Private m_s_CompanyName As String = ""
    Private m_s_Initials As String = ""
    Private m_im_Logo As Byte()
    Private m_s_TaxNo As String = ""
    Private m_s_Account As String = ""
    Private m_s_Address As String = ""
    Private m_s_Phone1 As String = ""
    Private m_s_Phone2 As String = ""
    Private m_s_Fax As String = ""
    Private m_s_Email As String = ""
    Private m_s_Website As String = ""
    Private m_i_ConfigID As Integer = 1 'không thay đổi
    Private m_i_FormatCur As Integer = 0
    Private m_i_FormatNum As Integer = 0
    Private m_s_SysCur As String = ""
    Private m_s_SysCurChar As String = "" '26.11.09-doc tien bang chu
    Private m_b_SysDiscountBeforeTax As Boolean = False
    Private m_b_SysCommission As Boolean = False
    Private m_b_isTrackPurchaseOrder As Boolean = False
    Private m_b_CheckInstock As Boolean = False
    Private m_s_MethodHH As String = ""
    Private m_s_MethodCL As String = ""
    Private m_s_MethodTU As String = ""
    Private m_s_MethodImport As String = ""
    Private m_s_MethodOrder As String = ""
    Private m_s_KeySysCur As String = ""
    '07/09 cau hinh bao cao
    Private m_b_ShowLogo As Boolean = False
    Private m_b_ShowName As Boolean = False
    Private m_b_ShowAdd As Boolean = False
    Private m_b_ShowPhoneFax As Boolean = False
    Private m_b_ShowEmailWeb As Boolean = False
    Private m_b_isEDiscount As Boolean = False
    Private m_b_isEProgressive As Boolean = False
    Private m_i_Countprint As Integer = 1 '9/11/09
    Private m_b_ApplyPrice As Boolean = False
    Private m_b_PriceObject As Boolean = False
    Private m_b_Method As Boolean = False
    Private m_b_EmployLogin As Boolean = False
    Private m_b_PriceLevel_Order As Boolean = False
    Private m_b_Purchase As Boolean = False
    Private m_s_TransCurrInc As String = ""
    Private m_s_TransCurrOut As String = ""
    Private m_s_ThuTamUng As String = ""
    Private m_isSendHQ As Boolean = False
    Private m_URLHQ As String = ""
    Private m_StoreID As String = ""
    Private m_b_PriceObGroup As Boolean = False
    Private m_b_isMultiStore As Boolean = False '26.05.10-xuat hang tu nhieu kho
    Private m_b_isCheckBeforeTurnOut As Boolean = False '27.05.10-kiem tra hang phat sinh mua truoc khi xuat tra
    Private m_i_ShowForm As Integer = 0
    Private m_i_Prepayment As Boolean = False
    Private m_i_TimeAlertDown As Integer = 5
    Private m_nCharTax As Integer = 5, m_symbolTax As String = ""
    Private m_IsPriceVAT As Boolean = False
    Private m_s_iItem As String = ""
    Private m_b_ChooseTypePrint As Boolean = False 'lua chon cach in
    Private m_i_QtyPrint As Integer = 0
    Private m_IsView As Boolean = True
    Private m_i_NumColExchange As Integer = 2
    Private m_s_MethodExchange As String = "*"
    Private m_nRow As Integer = 13
    Private m_VatDefault As Double = 10
    Private m_AutoCheckHQ As Boolean = True
    Private m_m_LimitRevenue As Double = 0
    Private _kytunhandien As String = ""
    Private _kytusoluong As Integer = 0
    Private _Quidoisoluong As Double = 1
    Private _sokytumahang As Integer = 0

    Private _PortWeight As String = "COM1"
    Public Property PortWeight() As String
        Get
            Return _PortWeight
        End Get
        Set(ByVal value As String)
            _PortWeight = value
        End Set
    End Property

    Private _BaudRate As Integer = 9600
    Public Property BaudRate() As Integer
        Get
            Return _BaudRate
        End Get
        Set(ByVal value As Integer)
            _BaudRate = value
        End Set
    End Property
    Property sokytumahang() As Integer
        Get
            Return _sokytumahang
        End Get
        Set(ByVal value As Integer)
            _sokytumahang = value
        End Set
    End Property
    Property kytunhandien() As String
        Get
            Return _kytunhandien
        End Get
        Set(ByVal value As String)
            _kytunhandien = value
        End Set
    End Property
    Property sokytusoluong() As Integer
        Get
            Return _kytusoluong
        End Get
        Set(ByVal value As Integer)
            _kytusoluong = value
        End Set
    End Property
    Property Quidoisoluong() As Double
        Get
            Return _Quidoisoluong
        End Get
        Set(ByVal value As Double)
            _Quidoisoluong = value
        End Set
    End Property
    Property m_LimitRevenue() As Double
        Get
            Return m_m_LimitRevenue
        End Get
        Set(ByVal value As Double)
            m_m_LimitRevenue = value
        End Set
    End Property

    Property AutoCheckHQ() As Boolean
        Get
            Return m_AutoCheckHQ
        End Get
        Set(ByVal value As Boolean)
            m_AutoCheckHQ = value
        End Set
    End Property
    Property VATDefault() As Double
        Get
            Return m_VatDefault
        End Get
        Set(ByVal value As Double)
            m_VatDefault = value
        End Set
    End Property

    Property nRow() As Integer
        Get
            Return m_nRow
        End Get
        Set(ByVal value As Integer)
            m_nRow = value
        End Set
    End Property
    Property i_NumColExchange() As Integer
        Get
            Return m_i_NumColExchange
        End Get
        Set(ByVal value As Integer)
            m_i_NumColExchange = value
        End Set
    End Property
    Property s_MethodExchange() As String
        Get
            Return m_s_MethodExchange
        End Get
        Set(ByVal value As String)
            m_s_MethodExchange = value
        End Set
    End Property
    Property IsView() As Boolean
        Get
            Return m_IsView
        End Get
        Set(ByVal value As Boolean)
            m_IsView = value
        End Set
    End Property
    Property s_iItem() As String
        Get
            Return m_s_iItem
        End Get
        Set(ByVal value As String)
            m_s_iItem = value
        End Set
    End Property
    Property b_ChooseTypePrint() As Boolean
        Get
            Return m_b_ChooseTypePrint
        End Get
        Set(ByVal value As Boolean)
            m_b_ChooseTypePrint = value
        End Set
    End Property
    Property i_QtyPrint() As Integer
        Get
            Return m_i_QtyPrint
        End Get
        Set(ByVal value As Integer)
            m_i_QtyPrint = value
        End Set
    End Property
    Property IsPriceVAT() As Boolean
        Get
            Return m_IsPriceVAT
        End Get
        Set(ByVal value As Boolean)
            m_IsPriceVAT = value
        End Set
    End Property
    Property nCharTax() As Integer
        Get
            nCharTax = m_nCharTax
        End Get
        Set(ByVal value As Integer)
            m_nCharTax = value
        End Set
    End Property
    Property symbolTax() As String
        Get
            Return m_symbolTax
        End Get
        Set(ByVal value As String)
            m_symbolTax = value
        End Set
    End Property
    Property i_TimeAlertDown() As Integer
        Get
            Return m_i_TimeAlertDown
        End Get
        Set(ByVal value As Integer)
            m_i_TimeAlertDown = value
        End Set
    End Property
    Property i_Prepayment() As Boolean
        Get
            Return m_i_Prepayment
        End Get
        Set(ByVal value As Boolean)
            m_i_Prepayment = value
        End Set
    End Property
    Property i_ShowForm() As Integer
        Get
            Return m_i_ShowForm
        End Get
        Set(ByVal value As Integer)
            m_i_ShowForm = value
        End Set
    End Property

    Property b_isCheckBeforeTurnOut() As Boolean
        Get
            Return m_b_isCheckBeforeTurnOut
        End Get
        Set(ByVal value As Boolean)
            m_b_isCheckBeforeTurnOut = value
        End Set
    End Property
    Property b_isMultiStore() As Boolean
        Get
            Return m_b_isMultiStore
        End Get
        Set(ByVal value As Boolean)
            m_b_isMultiStore = value
        End Set
    End Property

    Property b_PriceObGroup() As Boolean
        Get
            Return m_b_PriceObGroup
        End Get
        Set(ByVal value As Boolean)
            m_b_PriceObGroup = value
        End Set
    End Property

    Property isSendHQ() As Boolean
        Get
            Return m_isSendHQ
        End Get
        Set(ByVal value As Boolean)
            m_isSendHQ = value
        End Set
    End Property

    Property URLHQ() As String
        Get
            Return m_URLHQ
        End Get
        Set(ByVal value As String)
            m_URLHQ = value
        End Set
    End Property
    Property StoreID() As String
        Get
            Return m_StoreID
        End Get
        Set(ByVal value As String)
            m_StoreID = value
        End Set
    End Property

    Property s_TransCurrInc() As String
        Get
            Return m_s_TransCurrInc
        End Get
        Set(ByVal value As String)
            m_s_TransCurrInc = value
        End Set
    End Property
    Property s_TransCurrOut() As String
        Get
            Return m_s_TransCurrOut
        End Get
        Set(ByVal value As String)
            m_s_TransCurrOut = value
        End Set
    End Property
    Property s_ThuTamUng() As String
        Get
            Return m_s_ThuTamUng
        End Get
        Set(ByVal value As String)
            m_s_ThuTamUng = value
        End Set
    End Property
    Property s_SysCurChar() As String
        Get
            Return m_s_SysCurChar
        End Get
        Set(ByVal value As String)
            m_s_SysCurChar = value
        End Set
    End Property
    Property s_KeySysCur() As String
        Get
            Return m_s_KeySysCur
        End Get
        Set(ByVal value As String)
            m_s_KeySysCur = value
        End Set
    End Property
    Property i_ID() As Integer
        Get
            Return m_i_ID
        End Get
        Set(ByVal value As Integer)
            m_i_ID = value
        End Set
    End Property
    Property s_CompanyName() As String
        Get
            Return m_s_CompanyName
        End Get
        Set(ByVal value As String)
            m_s_CompanyName = value
        End Set
    End Property
    Property s_Initials() As String
        Get
            Return m_s_Initials
        End Get
        Set(ByVal value As String)
            m_s_Initials = value
        End Set
    End Property
    Property im_Logo() As Byte()
        Get
            Return m_im_Logo
        End Get
        Set(ByVal value As Byte())
            m_im_Logo = value
        End Set
    End Property
    Property s_TaxNo() As String
        Get
            Return m_s_TaxNo
        End Get
        Set(ByVal value As String)
            m_s_TaxNo = value
        End Set
    End Property
    Property s_Account() As String
        Get
            Return m_s_Account
        End Get
        Set(ByVal value As String)
            m_s_Account = value
        End Set
    End Property
    Property s_Address() As String
        Get
            Return m_s_Address
        End Get
        Set(ByVal value As String)
            m_s_Address = value
        End Set
    End Property
    Property s_Phone1() As String
        Get
            Return m_s_Phone1
        End Get
        Set(ByVal value As String)
            m_s_Phone1 = value
        End Set
    End Property
    Property s_Phone2() As String
        Get
            Return m_s_Phone2
        End Get
        Set(ByVal value As String)
            m_s_Phone2 = value
        End Set
    End Property
    Property s_Fax() As String
        Get
            Return m_s_Fax
        End Get
        Set(ByVal value As String)
            m_s_Fax = value
        End Set
    End Property
    Property s_Email() As String
        Get
            Return m_s_Email
        End Get
        Set(ByVal value As String)
            m_s_Email = value
        End Set
    End Property
    Property s_Website() As String
        Get
            Return m_s_Website
        End Get
        Set(ByVal value As String)
            m_s_Website = value
        End Set
    End Property
    ''' <summary>
    ''' Lưu giữ 1:dùng màn hình POS cho bán hàng, 0 là mặc định màn hình thường
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property i_ConfigID() As Integer
        Get
            Return m_i_ConfigID
        End Get
        Set(ByVal value As Integer)
            m_i_ConfigID = value
        End Set
    End Property
    Property i_FormatCur() As Integer
        Get
            Return m_i_FormatCur
        End Get
        Set(ByVal value As Integer)
            m_i_FormatCur = value
        End Set
    End Property
    Property i_FormatNum() As Integer
        Get
            Return m_i_FormatNum
        End Get
        Set(ByVal value As Integer)
            m_i_FormatNum = value
        End Set
    End Property
    Property s_SysCur() As String
        Get
            Return m_s_SysCur
        End Get
        Set(ByVal value As String)
            m_s_SysCur = value
        End Set
    End Property
    Property b_SysDiscountBeforeTax() As Boolean
        Get
            Return m_b_SysDiscountBeforeTax
        End Get
        Set(ByVal value As Boolean)
            m_b_SysDiscountBeforeTax = value
        End Set
    End Property
    Property b_SysCommission() As Boolean
        Get
            Return m_b_SysCommission
        End Get
        Set(ByVal value As Boolean)
            m_b_SysCommission = value
        End Set
    End Property
    Property b_isTrackPurchaseOrder() As Boolean
        Get
            Return m_b_isTrackPurchaseOrder
        End Get
        Set(ByVal value As Boolean)
            m_b_isTrackPurchaseOrder = value
        End Set
    End Property
    Property b_CheckInstock() As Boolean
        Get
            Return m_b_CheckInstock
        End Get
        Set(ByVal value As Boolean)
            m_b_CheckInstock = value
        End Set
    End Property
    Property s_MethodHH() As String
        Get
            Return m_s_MethodHH
        End Get
        Set(ByVal value As String)
            m_s_MethodHH = value
        End Set
    End Property
    Property s_MethodCL() As String
        Get
            Return m_s_MethodCL
        End Get
        Set(ByVal value As String)
            m_s_MethodCL = value
        End Set
    End Property
    Property s_MethodTU() As String
        Get
            Return m_s_MethodTU
        End Get
        Set(ByVal value As String)
            m_s_MethodTU = value
        End Set
    End Property
    Property s_MethodImport() As String
        Get
            Return m_s_MethodImport
        End Get
        Set(ByVal value As String)
            m_s_MethodImport = value
        End Set
    End Property
    Property s_MethodOrder() As String
        Get
            Return m_s_MethodOrder
        End Get
        Set(ByVal value As String)
            m_s_MethodOrder = value
        End Set
    End Property
    '07/09/09 cau hinh report

    Property b_ShowLogo() As Boolean
        Get
            Return m_b_ShowLogo
        End Get
        Set(ByVal value As Boolean)
            m_b_ShowLogo = value
        End Set
    End Property
    Property b_ShowName() As Boolean
        Get
            Return m_b_ShowName
        End Get
        Set(ByVal value As Boolean)
            m_b_ShowName = value
        End Set
    End Property
    Property b_ShowAdd() As Boolean
        Get
            Return m_b_ShowAdd
        End Get
        Set(ByVal value As Boolean)
            m_b_ShowAdd = value
        End Set
    End Property
    Property b_ShowPhoneFax() As Boolean
        Get
            Return m_b_ShowPhoneFax
        End Get
        Set(ByVal value As Boolean)
            m_b_ShowPhoneFax = value
        End Set
    End Property
    Property b_ShowEmailWeb() As Boolean
        Get
            Return m_b_ShowEmailWeb
        End Get
        Set(ByVal value As Boolean)
            m_b_ShowEmailWeb = value
        End Set
    End Property
    Property b_isEDiscount() As Boolean        Get            Return m_b_isEDiscount        End Get        Set(ByVal value As Boolean)            m_b_isEDiscount = value        End Set    End Property    Property b_isEProgressive() As Boolean        Get            Return m_b_isEProgressive        End Get        Set(ByVal value As Boolean)            m_b_isEProgressive = value        End Set    End Property    Property i_Countprint() As Integer
        Get
            Return m_i_Countprint
        End Get
        Set(ByVal value As Integer)
            m_i_Countprint = value
        End Set
    End Property
    Property b_ApplyPrice() As Boolean
        Get
            Return m_b_ApplyPrice
        End Get
        Set(ByVal value As Boolean)
            m_b_ApplyPrice = value
        End Set
    End Property
    ''' <summary>
    ''' True: áp dụng mức giá theo khách hàng
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property b_PriceObject() As Boolean
        Get
            Return m_b_PriceObject
        End Get
        Set(ByVal value As Boolean)
            m_b_PriceObject = value
        End Set
    End Property
    Property b_Method() As Boolean
        Get
            Return m_b_Method
        End Get
        Set(ByVal value As Boolean)
            m_b_Method = value
        End Set
    End Property
    Property b_EmployLogin() As Boolean
        Get
            Return m_b_EmployLogin
        End Get
        Set(ByVal value As Boolean)
            m_b_EmployLogin = value
        End Set
    End Property
    Property b_PriceLevel_Order() As Boolean
        Get
            Return m_b_PriceLevel_Order
        End Get
        Set(ByVal value As Boolean)
            m_b_PriceLevel_Order = value
        End Set
    End Property
    Property b_Purchase() As Boolean
        Get
            Return m_b_Purchase
        End Get
        Set(ByVal value As Boolean)
            m_b_Purchase = value
        End Set
    End Property

    Private m_SmsContent As String = ""
    ''' <summary>
    ''' soạn nội dung tin nhắn gửi
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SmsContent() As String
        Get
            Return m_SmsContent
        End Get
        Set(ByVal value As String)
            m_SmsContent = value
        End Set
    End Property


End Class
