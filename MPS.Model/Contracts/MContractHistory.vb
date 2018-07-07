Public Class MContractHistory

    Private m_ContractId As String
    Public Property ContractId() As String
        Get
            Return m_ContractId
        End Get
        Set(ByVal value As String)
            m_ContractId = value
        End Set
    End Property

    Private m_UserId As String
    Public Property UserId() As String
        Get
            Return m_UserId
        End Get
        Set(ByVal value As String)
            m_UserId = value
        End Set
    End Property

    Private m_Description As String
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set(ByVal value As String)
            m_Description = value
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
End Class
