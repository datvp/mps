Public Class MFuncList
    Private i_ID As Integer = 0
    Private s_Name As String = ""
    Private i_Uplevel As Integer = 0
    Private b_valid As Boolean = True
    Private s_Note As String = ""

    Property ID() As Integer
        Get
            Return i_ID
        End Get
        Set(ByVal value As Integer)
            i_ID = value
        End Set
    End Property
    Property Name() As String
        Get
            Return s_Name
        End Get
        Set(ByVal value As String)
            s_Name = value
        End Set
    End Property
    Property Uplevel() As Integer
        Get
            Return i_Uplevel
        End Get
        Set(ByVal value As Integer)
            i_Uplevel = value
        End Set
    End Property
    Property valid() As Boolean
        Get
            Return b_valid
        End Get
        Set(ByVal value As Boolean)
            b_valid = value
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

End Class
