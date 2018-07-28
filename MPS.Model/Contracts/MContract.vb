Public Class MContract

    Private m_ContractId As String = ""
    ''' <summary>
    ''' Mã số hợp đồng
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractId() As String
        Get
            Return m_ContractId
        End Get
        Set(ByVal value As String)
            m_ContractId = value
        End Set
    End Property


    Private m_ContractName As String = ""
    ''' <summary>
    ''' Tên gói thầu
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractName() As String
        Get
            Return m_ContractName
        End Get
        Set(ByVal value As String)
            m_ContractName = value
        End Set
    End Property


    Private m_ContractValue As Double = 0
    ''' <summary>
    ''' Giá trị hợp đồng (VNĐ)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractValue() As Double
        Get
            Return m_ContractValue
        End Get
        Set(ByVal value As Double)
            m_ContractValue = value
        End Set
    End Property


    Private m_ContractDate As Date = CDate("2000-1-1")
    ''' <summary>
    ''' Ngày ký
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractDate() As Date
        Get
            Return m_ContractDate
        End Get
        Set(ByVal value As Date)
            m_ContractDate = value
        End Set
    End Property


    Private m_ContractDeadLine As Date = CDate("2000-1-1")
    ''' <summary>
    ''' Ngày hết hạn
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractDeadLine() As Date
        Get
            Return m_ContractDeadLine
        End Get
        Set(ByVal value As Date)
            m_ContractDeadLine = value
        End Set
    End Property


    Private m_ProjectId As String = ""
    ''' <summary>
    ''' Mã dự án
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ProjectId() As String
        Get
            Return m_ProjectId
        End Get
        Set(ByVal value As String)
            m_ProjectId = value
        End Set
    End Property


    Private m_MainContractorId As String = ""
    ''' <summary>
    ''' nhà thầu chính
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MainContractorId() As String
        Get
            Return m_MainContractorId
        End Get
        Set(ByVal value As String)
            m_MainContractorId = value
        End Set
    End Property

    Private m_ContractLevelId As String = ""
    ''' <summary>
    ''' mã phân cấp hợp đồng
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractLevelId() As String
        Get
            Return m_ContractLevelId
        End Get
        Set(ByVal value As String)
            m_ContractLevelId = value
        End Set
    End Property



    Private m_ContractState As String = ""
    ''' <summary>
    ''' Trạng thái hợp đồng
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractState() As String
        Get
            Return m_ContractState
        End Get
        Set(ByVal value As String)
            m_ContractState = value
        End Set
    End Property


    Private m_SubContracts As String = ""
    ''' <summary>
    ''' danh sách phụ lục hợp đồng (nếu có)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubContracts() As String
        Get
            Return m_SubContracts
        End Get
        Set(ByVal value As String)
            m_SubContracts = value
        End Set
    End Property


    Private m_Note As String = ""
    Public Property Note() As String
        Get
            Return m_Note
        End Get
        Set(ByVal value As String)
            m_Note = value
        End Set
    End Property


    Private m_CreatedAt As Date = CDate("2000-1-1")
    Public Property CreatedAt() As Date
        Get
            Return m_CreatedAt
        End Get
        Set(ByVal value As Date)
            m_CreatedAt = value
        End Set
    End Property


    Private m_UpdatedAt As Date = CDate("2000-1-1")
    Public Property UpdatedAt() As Date
        Get
            Return m_UpdatedAt
        End Get
        Set(ByVal value As Date)
            m_UpdatedAt = value
        End Set
    End Property


    Private m_Reason As String = ""
    ''' <summary>
    ''' lý do từ chối ko duyệt
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Reason() As String
        Get
            Return m_Reason
        End Get
        Set(ByVal value As String)
            m_Reason = value
        End Set
    End Property


    Private m_DeadlineExt As Date = CDate("2000-1-1")
    ''' <summary>
    ''' ngày gia hạn thêm ở phụ lục (nếu có)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeadlineExt() As Date
        Get
            Return m_DeadlineExt
        End Get
        Set(ByVal value As Date)
            m_DeadlineExt = value
        End Set
    End Property



    Private m_arrContractDetail As IList(Of MContractDetail) = New List(Of MContractDetail)
    ''' <summary>
    ''' ds nội dung hợp đồng
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property arrContractDetail() As IList(Of MContractDetail)
        Get
            Return m_arrContractDetail
        End Get
        Set(ByVal value As IList(Of MContractDetail))
            m_arrContractDetail = value
        End Set
    End Property

    Private m_arrSubContract As IList(Of MSubContract) = New List(Of MSubContract)
    ''' <summary>
    ''' ds phụ lục hợp đồng
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property arrSubContract() As IList(Of MSubContract)
        Get
            Return m_arrSubContract
        End Get
        Set(ByVal value As IList(Of MSubContract))
            m_arrSubContract = value
        End Set
    End Property

    Private m_arrFile As IList(Of MAttachFileContract) = New List(Of MAttachFileContract)
    ''' <summary>
    ''' ds tập tin đính kèm
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property arrFile() As IList(Of MAttachFileContract)
        Get
            Return m_arrFile
        End Get
        Set(ByVal value As IList(Of MAttachFileContract))
            m_arrFile = value
        End Set
    End Property

    Private m_arrHistory As IList(Of MContractHistory) = New List(Of MContractHistory)
    ''' <summary>
    ''' ds lịch sử hợp đồng
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property arrHistory() As IList(Of MContractHistory)
        Get
            Return m_arrHistory
        End Get
        Set(ByVal value As IList(Of MContractHistory))
            m_arrHistory = value
        End Set
    End Property

    Private m_arrSubContractor As IList(Of MContract_SubContractor) = New List(Of MContract_SubContractor)
    ''' <summary>
    ''' ds lịch sử hợp đồng
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property arrSubContractor() As IList(Of MContract_SubContractor)
        Get
            Return m_arrSubContractor
        End Get
        Set(ByVal value As IList(Of MContract_SubContractor))
            m_arrSubContractor = value
        End Set
    End Property

    Private m_arrPayment As IList(Of MContractPayment) = New List(Of MContractPayment)
    ''' <summary>
    ''' ds các đợt thanh toán
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property arrPayment() As IList(Of MContractPayment)
        Get
            Return m_arrPayment
        End Get
        Set(ByVal value As IList(Of MContractPayment))
            m_arrPayment = value
        End Set
    End Property


    Private m_BranchId As String = ""
    ''' <summary>
    ''' Mã chi nhánh
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BranchId() As String
        Get
            Return m_BranchId
        End Get
        Set(ByVal value As String)
            m_BranchId = value
        End Set
    End Property

    Private m_Paid As Double = 0
    ''' <summary>
    ''' tổng tiền đã thanh toán
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Paid() As Double
        Get
            Return m_Paid
        End Get
        Set(ByVal value As Double)
            m_Paid = value
        End Set
    End Property
End Class
