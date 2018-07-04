Public Class MContract

    Private m_ContractId As String = ""
    ''' <summary>
    ''' Mã số hợp đồng
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractId() As String
        Get
            Return m_ContractId
        End Get
        Set(ByVal value As String)
            m_ContractId = value
        End Set
    End Property


    Private m_ContractName As String = ""
    ''' <summary>
    ''' Tên gói thầu
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractName() As String
        Get
            Return m_ContractName
        End Get
        Set(ByVal value As String)
            m_ContractName = value
        End Set
    End Property


    Private m_ContractValue As Double = 0
    ''' <summary>
    ''' Giá trị hợp đồng (VNĐ)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractValue() As Double
        Get
            Return m_ContractValue
        End Get
        Set(ByVal value As Double)
            m_ContractValue = value
        End Set
    End Property


    Private m_ContractDate As Date = CDate("2000-1-1")
    ''' <summary>
    ''' Ngày ký
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractDate() As Date
        Get
            Return m_ContractDate
        End Get
        Set(ByVal value As Date)
            m_ContractDate = value
        End Set
    End Property


    Private m_ContractDeadLine As Date = CDate("2000-1-1")
    ''' <summary>
    ''' Ngày hết hạn
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractDeadLine() As Date
        Get
            Return m_ContractDeadLine
        End Get
        Set(ByVal value As Date)
            m_ContractDeadLine = value
        End Set
    End Property


    Private m_ProjectId As String = ""
    ''' <summary>
    ''' Mã dự án
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ProjectId() As String
        Get
            Return m_ProjectId
        End Get
        Set(ByVal value As String)
            m_ProjectId = value
        End Set
    End Property


    Private m_ContractState As String = ""
    ''' <summary>
    ''' Trạng thái hợp đồng
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContractState() As String
        Get
            Return m_ContractState
        End Get
        Set(ByVal value As String)
            m_ContractState = value
        End Set
    End Property


    Private m_SubContracts As String = ""
    ''' <summary>
    ''' danh sách phụ lục hợp đồng (nếu có)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubContracts() As String
        Get
            Return m_SubContracts
        End Get
        Set(ByVal value As String)
            m_SubContracts = value
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
End Class
