Public Class MSecUser
    Private s_UID As String = ""
    Private b_Valid As Boolean = False
    Private dt_CreateDate As Date = Now
    Private s_PWD As String = ""
    Private s_Note As String = ""
    Private i_IDSort As Integer = 0
    Private b_isAdmin As Boolean = False
    '19-5-09
    Private s_GroupUser As String = ""
    Private s_Employees As String = ""

    Private m_isViewAllBranch As Boolean
    ''' <summary>
    ''' true: chỉ xem báo cáo Chi nhánh là Tất cả (ko xem chi tiết từng kho)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property isViewAllBranch() As Boolean
        Get
            Return m_isViewAllBranch
        End Get
        Set(ByVal value As Boolean)
            m_isViewAllBranch = value
        End Set
    End Property

    Private m_isViewAllStore As Boolean
    ''' <summary>
    ''' true: chỉ xem báo cáo Kho là Tất cả (ko xem chi tiết từng kho)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property isViewAllStore() As Boolean
        Get
            Return m_isViewAllStore
        End Get
        Set(ByVal value As Boolean)
            m_isViewAllStore = value
        End Set
    End Property



    Property GroupUser() As String
        Get
            Return s_GroupUser
        End Get
        Set(ByVal value As String)
            s_GroupUser = value
        End Set
    End Property
    Property Employees() As String
        Get
            Return s_Employees
        End Get
        Set(ByVal value As String)
            s_Employees = value
        End Set
    End Property

    Property UID() As String
        Get
            Return s_UID
        End Get
        Set(ByVal value As String)
            s_UID = value
        End Set
    End Property
    Property Valid() As Boolean
        Get
            Return b_Valid
        End Get
        Set(ByVal value As Boolean)
            b_Valid = value
        End Set
    End Property
    Property CreateDate() As Date
        Get
            Return dt_CreateDate
        End Get
        Set(ByVal value As Date)
            dt_CreateDate = value
        End Set
    End Property
    Property PWD() As String
        Get
            Return s_PWD
        End Get
        Set(ByVal value As String)
            s_PWD = value
        End Set
    End Property
    Property Note() As String
        Get
            Return s_Note
        End Get
        Set(ByVal value As String)
            s_Note = value
        End Set
    End Property
    Property IDSort() As Integer
        Get
            Return i_IDSort
        End Get
        Set(ByVal value As Integer)
            i_IDSort = value
        End Set
    End Property
    Property isAdmin() As Boolean
        Get
            Return b_isAdmin
        End Get
        Set(ByVal value As Boolean)
            b_isAdmin = value
        End Set
    End Property

End Class
