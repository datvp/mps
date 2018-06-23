Public Class MFuncRight
    Private s_UID As String = ""
    Private i_FuncID As Integer = 0
    Private b_R As Boolean = False
    Private b_U As Boolean = False
    Private b_A As Boolean = False
    Private b_D As Boolean = False
    Private i_IDSort As Integer = 0
    Private m_sFuncID As String
    Property sFuncID() As String
        Get
            Return m_sFuncID
        End Get
        Set(ByVal value As String)
            m_sFuncID = value
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
    Property FuncID() As Integer
        Get
            Return i_FuncID
        End Get
        Set(ByVal value As Integer)
            i_FuncID = value
        End Set
    End Property
    Property R() As Boolean
        Get
            Return b_R
        End Get
        Set(ByVal value As Boolean)
            b_R = value
        End Set
    End Property
    Property U() As Boolean
        Get
            Return b_U
        End Get
        Set(ByVal value As Boolean)
            b_U = value
        End Set
    End Property
    Property A() As Boolean
        Get
            Return b_A
        End Get
        Set(ByVal value As Boolean)
            b_A = value
        End Set
    End Property
    Property D() As Boolean
        Get
            Return b_D
        End Get
        Set(ByVal value As Boolean)
            b_D = value
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
End Class
