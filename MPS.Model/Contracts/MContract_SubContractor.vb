Public Class MContract_SubContractor
    Private m_DelItem As String = ""
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

    Private m_SubContractorId As String = ""
    Public Property SubContractorId() As String
        Get
            Return m_SubContractorId
        End Get
        Set(ByVal value As String)
            m_SubContractorId = value
        End Set
    End Property

    Private m_SubContractorName As String = ""
    Public Property SubContractorName() As String
        Get
            Return m_SubContractorName
        End Get
        Set(ByVal value As String)
            m_SubContractorName = value
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

End Class
