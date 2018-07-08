Public Class MSubContracts

    Private m_ContractId As String
    Public Property ContractId() As String
        Get
            Return m_ContractId
        End Get
        Set(ByVal value As String)
            m_ContractId = value
        End Set
    End Property

    Private m_SubContractId As String
    Public Property SubContractId() As String
        Get
            Return m_SubContractId
        End Get
        Set(ByVal value As String)
            m_SubContractId = value
        End Set
    End Property


    Private m_SubContractName As String
    Public Property SubContractName() As String
        Get
            Return m_SubContractName
        End Get
        Set(ByVal value As String)
            m_SubContractName = value
        End Set
    End Property

    Private m_SubContractDate As String
    Public Property SubContractDate() As String
        Get
            Return m_SubContractDate
        End Get
        Set(ByVal value As String)
            m_SubContractDate = value
        End Set
    End Property

    Private m_SubContractValue As String
    Public Property SubContractValue() As String
        Get
            Return m_SubContractValue
        End Get
        Set(ByVal value As String)
            m_SubContractValue = value
        End Set
    End Property

    Private m_SubContractDeadLine As String
    Public Property SubContractDeadLine() As String
        Get
            Return m_SubContractDeadLine
        End Get
        Set(ByVal value As String)
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
End Class
