Public Class MProject

    Private m_ProjectId As String = ""
    Public Property ProjectId() As String
        Get
            Return m_ProjectId
        End Get
        Set(ByVal value As String)
            m_ProjectId = value
        End Set
    End Property

    Private m_ProjectName As String = ""
    Public Property ProjectName() As String
        Get
            Return m_ProjectName
        End Get
        Set(ByVal value As String)
            m_ProjectName = value
        End Set
    End Property

    Private m_ProjectTypeId As String = ""
    Public Property ProjectTypeId() As String
        Get
            Return m_ProjectTypeId
        End Get
        Set(ByVal value As String)
            m_ProjectTypeId = value
        End Set
    End Property

    Private m_Performance As Integer = 0
    Public Property Performance() As Integer
        Get
            Return m_Performance
        End Get
        Set(ByVal value As Integer)
            m_Performance = value
        End Set
    End Property

    Private m_Length As Integer = 0
    Public Property Length() As Integer
        Get
            Return m_Length
        End Get
        Set(ByVal value As Integer)
            m_Length = value
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

    Private m_ProjectGroupId As String = ""
    Public Property ProjectGroupId() As String
        Get
            Return m_ProjectGroupId
        End Get
        Set(ByVal value As String)
            m_ProjectGroupId = value
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

    Private m_ConstructionLevelId As String = ""
    Public Property ConstructionLevelId() As String
        Get
            Return m_ConstructionLevelId
        End Get
        Set(ByVal value As String)
            m_ConstructionLevelId = value
        End Set
    End Property

    Private m_PerformanceUnit As String = ""
    Public Property PerformanceUnit() As String
        Get
            Return m_PerformanceUnit
        End Get
        Set(ByVal value As String)
            m_PerformanceUnit = value
        End Set
    End Property

    Private m_LengthUnit As String = ""
    Public Property LengthUnit() As String
        Get
            Return m_LengthUnit
        End Get
        Set(ByVal value As String)
            m_LengthUnit = value
        End Set
    End Property

    Private m_ClientId As String = ""
    Public Property ClientId() As String
        Get
            Return m_ClientId
        End Get
        Set(ByVal value As String)
            m_ClientId = value
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

    Private m_Status As String = ""
    Public Property Status() As String
        Get
            Return m_Status
        End Get
        Set(ByVal value As String)
            m_Status = value
        End Set
    End Property

End Class
