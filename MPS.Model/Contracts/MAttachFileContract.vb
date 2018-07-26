Public Class MAttachFileContract
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


    Private m_OpenFile As String = "Open"
    Public Property OpenFile() As String
        Get
            Return m_OpenFile
        End Get
        Set(ByVal value As String)
            m_OpenFile = value
        End Set
    End Property

    Private m_ContractId As String
    Public Property ContractId() As String
        Get
            Return m_ContractId
        End Get
        Set(ByVal value As String)
            m_ContractId = value
        End Set
    End Property

    Private m_FileId As String
    Public Property FileId() As String
        Get
            Return m_FileId
        End Get
        Set(ByVal value As String)
            m_FileId = value
        End Set
    End Property

    Private m_FileName As String
    Public Property FileName() As String
        Get
            Return m_FileName
        End Get
        Set(ByVal value As String)
            m_FileName = value
        End Set
    End Property

    Private m_FilePath As String
    Public Property FilePath() As String
        Get
            Return m_FilePath
        End Get
        Set(ByVal value As String)
            m_FilePath = value
        End Set
    End Property

    Private m_FileType As String
    Public Property FileType() As String
        Get
            Return m_FileType
        End Get
        Set(ByVal value As String)
            m_FileType = value
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
