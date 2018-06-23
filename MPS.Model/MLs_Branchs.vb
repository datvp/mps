Public Class MLs_Branchs
    Private m_s_ID As String = ""
    Private m_s_Branch_ID As String = ""
    Private m_s_Name As String = ""
    Private m_s_Address As String = ""
    Private m_s_Phone As String = ""
    Private m_s_Note As String = ""
    Private m_i_Ordinal As Decimal = 0
    Property s_ID() As String
        Get
            Return m_s_ID
        End Get
        Set(ByVal value As String)
            m_s_ID = value
        End Set
    End Property
    Property s_Branch_ID() As String
        Get
            Return m_s_Branch_ID
        End Get
        Set(ByVal value As String)
            m_s_Branch_ID = value
        End Set
    End Property
    Property s_Name() As String
        Get
            Return m_s_Name
        End Get
        Set(ByVal value As String)
            m_s_Name = value
        End Set
    End Property
    Property s_Address() As String
        Get
            Return m_s_Address
        End Get
        Set(ByVal value As String)
            m_s_Address = value
        End Set
    End Property
    Property s_Phone() As String
        Get
            Return m_s_Phone
        End Get
        Set(ByVal value As String)
            m_s_Phone = value
        End Set
    End Property
    Property s_Note() As String
        Get
            Return m_s_Note
        End Get
        Set(ByVal value As String)
            m_s_Note = value
        End Set
    End Property
    Property i_Ordinal() As Decimal
        Get
            Return m_i_Ordinal
        End Get
        Set(ByVal value As Decimal)
            m_i_Ordinal = value
        End Set
    End Property

End Class

