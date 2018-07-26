Public Class MContractPayment

    Private m_DelItem As String
    Public Property DelItem() As String
        Get
            Return m_DelItem
        End Get
        Set(ByVal value As String)
            m_DelItem = value
        End Set
    End Property

    Private m_ContractId As String = ""
    Public Property ContractId() As String
        Get
            Return m_ContractId
        End Get
        Set(ByVal value As String)
            m_ContractId = value
        End Set
    End Property

    Private m_PaymentId As String = ""
    Public Property PaymentId() As String
        Get
            Return m_PaymentId
        End Get
        Set(ByVal value As String)
            m_PaymentId = value
        End Set
    End Property

    Private m_PaymentName As String = ""
    Public Property PaymentName() As String
        Get
            Return m_PaymentName
        End Get
        Set(ByVal value As String)
            m_PaymentName = value
        End Set
    End Property

    Private m_PaymentTotal As Double = 0
    Public Property PaymentTotal() As Double
        Get
            Return m_PaymentTotal
        End Get
        Set(ByVal value As Double)
            m_PaymentTotal = value
        End Set
    End Property

    Private m_PaymentDate As Date = CDate("2000-1-1")
    Public Property PaymentDate() As Date
        Get
            Return m_PaymentDate
        End Get
        Set(ByVal value As Date)
            m_PaymentDate = value
        End Set
    End Property

    Private m_PaymentStatus As String = ""
    Public Property PaymentStatus() As String
        Get
            Return m_PaymentStatus
        End Get
        Set(ByVal value As String)
            m_PaymentStatus = value
        End Set
    End Property
End Class
