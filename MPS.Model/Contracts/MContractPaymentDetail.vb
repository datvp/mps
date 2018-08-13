Public Class MContractPaymentDetail
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

    Private m_ItemId As String = ""
    ''' <summary>
    ''' mã hạng mục nghiệm thu
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ItemId() As String
        Get
            Return m_ItemId
        End Get
        Set(ByVal value As String)
            m_ItemId = value
        End Set
    End Property

    Private m_ItemName As String = ""
    ''' <summary>
    ''' hạng mục nghiệm thu
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ItemName() As String
        Get
            Return m_ItemName
        End Get
        Set(ByVal value As String)
            m_ItemName = value
        End Set
    End Property

    Private m_PaidValue As Double = 0
    ''' <summary>
    ''' giá trị nghiệm thu
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PaidValue() As Double
        Get
            Return m_PaidValue
        End Get
        Set(ByVal value As Double)
            m_PaidValue = value
        End Set
    End Property
End Class
