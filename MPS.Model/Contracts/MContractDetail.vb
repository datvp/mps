Public Class MContractDetail

    Private m_DelItem As String
    ''' <summary>
    ''' nút xóa item
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DelItem() As String
        Get
            Return m_DelItem
        End Get
        Set(ByVal value As String)
            m_DelItem = value
        End Set
    End Property


    Private m_ContractId As String = ""
    Public Property ContractId() As String
        Get
            Return m_ContractId
        End Get
        Set(ByVal value As String)
            m_ContractId = value
        End Set
    End Property

    Private m_ItemId As String = ""
    Public Property ItemId() As String
        Get
            Return m_ItemId
        End Get
        Set(ByVal value As String)
            m_ItemId = value
        End Set
    End Property

    Private m_ItemName As String = ""
    Public Property ItemName() As String
        Get
            Return m_ItemName
        End Get
        Set(ByVal value As String)
            m_ItemName = value
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

    Private m_Status As String = ""
    ''' <summary>
    ''' trạng thái của hạng mục: Pending/Completed
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Status() As String
        Get
            Return m_Status
        End Get
        Set(ByVal value As String)
            m_Status = value
        End Set
    End Property

    Private m_StatusDesc As String = ""
    ''' <summary>
    ''' description for Status: only view not save
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StatusDesc() As String
        Get
            Return m_StatusDesc
        End Get
        Set(ByVal value As String)
            m_StatusDesc = value
        End Set
    End Property


    Private m_ItemValue As Double = 0
    ''' <summary>
    ''' chi phí cho hạng mục
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ItemValue() As Double
        Get
            Return m_ItemValue
        End Get
        Set(ByVal value As Double)
            m_ItemValue = value
        End Set
    End Property


    Private m_SubContractorId As String = ""
    ''' <summary>
    ''' Mã nhà thầu phụ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubContractorId() As String
        Get
            Return m_SubContractorId
        End Get
        Set(ByVal value As String)
            m_SubContractorId = value
        End Set
    End Property

    Private m_SubContractorName As String = ""
    ''' <summary>
    ''' Tên nhà thầu phụ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubContractorName() As String
        Get
            Return m_SubContractorName
        End Get
        Set(ByVal value As String)
            m_SubContractorName = value
        End Set
    End Property


    Private m_Fee As Double = 0
    ''' <summary>
    ''' chi phí thuê nhà thầu
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Fee() As Double
        Get
            Return m_Fee
        End Get
        Set(ByVal value As Double)
            m_Fee = value
        End Set
    End Property


End Class
