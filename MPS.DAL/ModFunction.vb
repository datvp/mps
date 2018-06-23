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
            If Not IsLoadLang Then LoadLang()
            Return AddNew
        End Get
    End Property
    ReadOnly Property m_SelectAll() As String
        Get
            If Not IsLoadLang Then LoadLang()
            Return SelectAll
        End Get
    End Property
    Private Sub LoadLang()
        If Not IsLoadLang Then
            Dim m_Lang As Integer = 1
            If System.IO.File.Exists("Lang.txt") Then
                Dim sLang As String = System.IO.File.ReadAllText("Lang.txt")
                If sLang <> "" AndAlso IsNumeric(sLang) Then
                    m_Lang = CInt(sLang)
                End If
            End If
            If m_Lang <> 1 Then
                Dim ds As DataSet = OpenDataSetAccess("Select * from tblMultiMsg where (IDMsg=1 OR IDMsg=379) AND LangID=" & m_Lang.ToString)
                If Not ds Is Nothing Then
                    For Each dr As DataRow In ds.Tables(0).Rows
                        Select Case dr("IDMsg")
                            Case 1
                                AddNew = dr("Msg").ToString
                            Case 379
                                SelectAll = dr("Msg").ToString
                        End Select
                    Next
                End If
            End If

            IsLoadLang = True
        End If

    End Sub
   
    Private Function OpenDataSetAccess(ByVal strSQL As String) As DataSet

        Dim strCnn As String
        Dim fileName As String = "Lang.mdb"
        If Not System.IO.File.Exists(fileName) Then
            Return Nothing
        End If
        strCnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & fileName & ";Jet OLEDB:Database Password=2010;Mode=ReadWrite|Share Deny None;Persist Security Info=False"
        Dim cn As New System.Data.OleDb.OleDbConnection(strCnn)
        Try
            cn.Open()
        Catch ex As Exception
            Return Nothing
        End Try
        Dim da As New System.Data.OleDb.OleDbDataAdapter(strSQL, cn)
        da.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet
        Try
            da.Fill(ds)
            cn.Close()
        Catch e As Exception
            cn.Close()
            Return Nothing
        End Try
        cn.Close()

        Return ds
    End Function

End Module
