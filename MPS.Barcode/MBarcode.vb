Public Class MBarcode
    Private s_ProductID As String = ""
    Private s_ProductName As String = ""
    Private m_Price As Double = 0
    Private m_CreateDate As Date = Now
    Private m_V1 As String = ""
    Private m_V2 As String = ""
    Private m_V3 As String = ""

    Property ProductID() As String
        Get
            Return s_ProductID
        End Get
        Set(ByVal value As String)
            s_ProductID = value
        End Set
    End Property
    Property ProductName() As String
        Get
            Return s_ProductName
        End Get
        Set(ByVal value As String)
            s_ProductName = value
        End Set
    End Property
    Property Price() As Double
        Get
            Return m_Price
        End Get
        Set(ByVal value As Double)
            m_Price = value
        End Set
    End Property
    Property CreateDate() As Date
        Get
            Return m_CreateDate
        End Get
        Set(ByVal value As Date)
            m_CreateDate = value
        End Set
    End Property
    Property V1() As String
        Get
            Return m_V1
        End Get
        Set(ByVal value As String)
            m_V1 = value
        End Set
    End Property
    Property V2() As String
        Get
            Return m_V2
        End Get
        Set(ByVal value As String)
            m_V2 = value
        End Set
    End Property
    Property V3() As String
        Get
            Return m_V3
        End Get
        Set(ByVal value As String)
            m_V3 = value
        End Set
    End Property

End Class

