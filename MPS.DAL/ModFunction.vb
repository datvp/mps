Module ModFunction
    Public conn As SqlClient.SqlConnection
    Public m_Transaction As Data.SqlClient.SqlTransaction = Nothing

    Public sPathFileConfig As String = ""
    Private AddNew As String = "Thêm mới"
    Private SelectAll As String = "Tất cả"
    Public m_UIDLogin As String = ""
    Private IsLoadLang As Boolean = False
    ReadOnly Property m_AddNew() As String
        Get
            Return AddNew
        End Get
    End Property
    ReadOnly Property m_SelectAll() As String
        Get
            Return SelectAll
        End Get
    End Property

End Module
