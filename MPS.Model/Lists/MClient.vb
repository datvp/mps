Public Class MClient

    Private m_ClientId As String = ""
    Public Property ClientId() As String
        Get
            Return m_ClientId
        End Get
        Set(ByVal value As String)
            m_ClientId = value
        End Set
    End Property

    Private m_ClientName As String = ""
    Public Property ClientName() As String
        Get
            Return m_ClientName
        End Get
        Set(ByVal value As String)
            m_ClientName = value
        End Set
    End Property


    Private m_ShortName As String = ""
    Public Property ShortName() As String
        Get
            Return m_ShortName
        End Get
        Set(ByVal value As String)
            m_ShortName = value
        End Set
    End Property

    Private m_Address As String = ""
    Public Property Address() As String
        Get
            Return m_Address
        End Get
        Set(ByVal value As String)
            m_Address = value
        End Set
    End Property

    Private m_Phone As String = ""
    Public Property Phone() As String
        Get
            Return m_Phone
        End Get
        Set(ByVal value As String)
            m_Phone = value
        End Set
    End Property

    Private m_Email As String = ""
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(ByVal value As String)
            m_Email = value
        End Set
    End Property

    Private m_Website As String = ""
    Public Property Website() As String
        Get
            Return m_Website
        End Get
        Set(ByVal value As String)
            m_Website = value
        End Set
    End Property

    Private m_ContactName As String = ""
    Public Property ContactName() As String
        Get
            Return m_ContactName
        End Get
        Set(ByVal value As String)
            m_ContactName = value
        End Set
    End Property

    Private m_ContactPhone As String = ""
    Public Property ContactPhone() As String
        Get
            Return m_ContactPhone
        End Get
        Set(ByVal value As String)
            m_ContactPhone = value
        End Set
    End Property

    Private m_ContactEmail As String = ""
    Public Property ContactEmail() As String
        Get
            Return m_ContactEmail
        End Get
        Set(ByVal value As String)
            m_ContactEmail = value
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

    Private m_ClientGroupId As String = ""
    Public Property ClientGroupId() As String
        Get
            Return m_ClientGroupId
        End Get
        Set(ByVal value As String)
            m_ClientGroupId = value
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
    Public Property Status() As String
        Get
            Return m_Status
        End Get
        Set(ByVal value As String)
            m_Status = value
        End Set
    End Property

    Private m_UnitedId As String = ""
    ''' <summary>
    ''' mã đơn vị quản lý
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UnitedId() As String
        Get
            Return m_UnitedId
        End Get
        Set(ByVal value As String)
            m_UnitedId = value
        End Set
    End Property


End Class
