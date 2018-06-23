Public Class MEvent
    Private s_ID As String = ""
    Private s_UID As String = ""
    Private i_TypeID As Integer = 0
    Private s_Desc As String = ""
    Private dt_DayMonth As Date = Now
    Private s_Note As String = ""
    Private i_IDSort As Double = 0

    Property ID() As String
        Get
            Return s_ID
        End Get
        Set(ByVal value As String)
            s_ID = value
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
    Property TypeID() As Integer
        Get
            Return i_TypeID
        End Get
        Set(ByVal value As Integer)
            i_TypeID = value
        End Set
    End Property
    Property Desc() As String
        Get
            Return s_Desc
        End Get
        Set(ByVal value As String)
            s_Desc = value
        End Set
    End Property
    Property DayMonth() As Date
        Get
            Return dt_DayMonth
        End Get
        Set(ByVal value As Date)
            dt_DayMonth = value
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
    Property IDSort() As Double
        Get
            Return i_IDSort
        End Get
        Set(ByVal value As Double)
            i_IDSort = value
        End Set
    End Property

End Class
