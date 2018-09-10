Public Class MClientGroup

    Private m_ClientGroupId As String = ""
    Public Property ClientGroupId() As String
        Get
            Return m_ClientGroupId
        End Get
        Set(ByVal value As String)
            m_ClientGroupId = value
        End Set
    End Property

    Private m_ClientGroupName As String = ""
    Public Property ClientGroupName() As String
        Get
            Return m_ClientGroupName
        End Get
        Set(ByVal value As String)
            m_ClientGroupName = value
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
