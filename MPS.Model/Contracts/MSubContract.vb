Public Class MSubContract
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

    Private m_SubContractId As String = ""
    Public Property SubContractId() As String
        Get
            Return m_SubContractId
        End Get
        Set(ByVal value As String)
            m_SubContractId = value
        End Set
    End Property

    Private m_SubContractValue As Double = 0
    Public Property SubContractValue() As Double
        Get
            Return m_SubContractValue
        End Get
        Set(ByVal value As Double)
            m_SubContractValue = value
        End Set
    End Property
    Private m_SubContractDate As Date = CDate("2000-1-1")
    ''' <summary>
    ''' ngày ký phụ lục
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubContractDate() As Date
        Get
            Return m_SubContractDate
        End Get
        Set(ByVal value As Date)
            m_SubContractDate = value
        End Set
    End Property
    Private m_SubContractDeadLine As Date = CDate("2000-1-1")
    Public Property SubContractDeadLine() As Date
        Get
            Return m_SubContractDeadLine
        End Get
        Set(ByVal value As Date)
            m_SubContractDeadLine = value
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

    Private m_Note As String = ""
    ''' <summary>
    ''' nội dung phụ lục hợp đồng
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Note() As String
        Get
            Return m_Note
        End Get
        Set(ByVal value As String)
            m_Note = value
        End Set
    End Property


End Class
