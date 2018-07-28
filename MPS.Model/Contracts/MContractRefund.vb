Public Class MContractRefund

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

    Private m_RefundId As String = ""
    Public Property RefundId() As String
        Get
            Return m_RefundId
        End Get
        Set(ByVal value As String)
            m_RefundId = value
        End Set
    End Property

    Private m_RefundName As String = ""
    Public Property RefundName() As String
        Get
            Return m_RefundName
        End Get
        Set(ByVal value As String)
            m_RefundName = value
        End Set
    End Property

    Private m_RefundTotal As Double = 0
    Public Property RefundTotal() As Double
        Get
            Return m_RefundTotal
        End Get
        Set(ByVal value As Double)
            m_RefundTotal = value
        End Set
    End Property

    Private m_RefundDate As Date
    Public Property RefundDate() As Date
        Get
            Return m_RefundDate
        End Get
        Set(ByVal value As Date)
            m_RefundDate = value
        End Set
    End Property

    Private m_RefundStatus As String = ""
    Public Property RefundStatus() As String
        Get
            Return m_RefundStatus
        End Get
        Set(ByVal value As String)
            m_RefundStatus = value
        End Set
    End Property

    Private m_SubContractorId As String = ""
    Public Property SubContractorId() As String
        Get
            Return m_SubContractorId
        End Get
        Set(ByVal value As String)
            m_SubContractorId = value
        End Set
    End Property

    Private m_SubContractorName As String = ""
    ''' <summary>
    ''' Tên nhà thầu phụ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubContractorName() As String
        Get
            Return m_SubContractorName
        End Get
        Set(ByVal value As String)
            m_SubContractorName = value
        End Set
    End Property

    Private m_StatusDesc As String = ""
    ''' <summary>
    ''' description for Status: only view not save
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StatusDesc() As String
        Get
            Return m_StatusDesc
        End Get
        Set(ByVal value As String)
            m_StatusDesc = value
        End Set
    End Property
End Class
