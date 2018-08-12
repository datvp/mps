Imports System.Data.SqlClient
Imports System.ComponentModel
Imports VsoftBMS

Public Class DALSQL

    Private da As SqlDataAdapter
    Private cmd As SqlCommand
    Private strConn As String = System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectBMS")
    Private ser, db, uid, pass As String
    Event _error(ByVal message As String)
    Private msgerr As String = ""
    Private uti As New Ulti.ClsUti
    Private iCommandTimeOut As Integer = 1500

    Protected Function BeginTranstion() As Boolean
        Try
            If m_Transaction Is Nothing Then
                If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
                    Me.connectDB()
                End If
                If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                    m_Transaction = conn.BeginTransaction(IsolationLevel.Serializable)
                End If
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function
    Protected Function CommitTranstion() As Boolean
        Try
            If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open AndAlso Not m_Transaction Is Nothing Then
                m_Transaction.Commit()
                m_Transaction = Nothing
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function
    Protected Function RollbackTransction() As Boolean
        Try
            If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open AndAlso Not m_Transaction Is Nothing Then
                m_Transaction.Rollback()
                m_Transaction = Nothing
            End If
            Return True
        Catch ex As Exception

        End Try

    End Function
    Property msgError() As String
        Set(ByVal Value As String)
            msgerr = Value
        End Set
        Get
            Return msgerr
        End Get
    End Property
    Public Function KiemTraDLL() As Boolean

        Return True
    End Function
    Private m_isWriteLog As Boolean = True

    Property isWriteLog() As Boolean
        Get
            Return m_isWriteLog
        End Get
        Set(ByVal value As Boolean)
            m_isWriteLog = value
        End Set
    End Property
    Protected Function WriteLog(ByVal sError As String) As Boolean
        If Not m_isWriteLog Then
            Return True
        End If

        If Not Me.connectDB() Then
            Return False
        End If


        sError = sError.Replace("'", "''")
        If sError.Length > 4000 Then sError = sError.Substring(0, 3990)
        Dim sql As String = "Insert into PR_Events(i_TypeID,s_Desc)values(1,'" & sError & "')"
        cmd = New SqlCommand(sql, conn)
        cmd.CommandType = CommandType.Text
        cmd.CommandTimeout = iCommandTimeOut
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            conn.Close()
            msgerr = ex.Message
            RaiseEvent _error(ex.Message)
            Return False
        End Try

        conn.Close()
        Return True
    End Function

    Public Sub SaveConfig()
        Try
            Dim tb As New DataTable
            tb.Columns.Add("srv")
            tb.Columns.Add("uid")
            tb.Columns.Add("pwd")
            tb.Columns.Add("db")

            Dim dr As DataRow = tb.NewRow
            dr("srv") = Server
            dr("db") = Database
            dr("uid") = UserName
            dr("pwd") = uti.Encrypt1(Password)
            tb.Rows.Add(dr)
            tb.TableName = "ConfigConnect"
            Dim ds As New DataSet
            ds.Tables.Add(tb)
            ds.WriteXml(PathFileConfig)
            strConn = ""
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
#Region "constructor"
    Property PathFileConfig() As String
        Get
            Return sPathFileConfig
        End Get
        Set(ByVal value As String)
            sPathFileConfig = value
        End Set
    End Property
    Sub New()
        If PathFileConfig = "" Then
            PathFileConfig = System.Windows.Forms.Application.StartupPath & "\Config.dat"
        End If

        If My.Computer.FileSystem.FileExists(PathFileConfig) Then
            Dim ds As New DataSet
            Try
                ds.ReadXmlSchema(sPathFileConfig)
                ds.ReadXml(sPathFileConfig)
            Catch ex As Exception
                ds = Nothing
            End Try

            If ds Is Nothing Then
                Try
                    ds = New DataSet
                    Dim sContent As String = IO.File.ReadAllText(sPathFileConfig)
                    If sContent <> "" Then
                        Dim doc As New System.Xml.XmlDocument()
                        doc.LoadXml(sContent)
                        ds.ReadXml(New System.Xml.XmlNodeReader(doc))
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message & "(Bị lỗi đọc file '" & sPathFileConfig & "')", MsgBoxStyle.Critical)
                    ds = Nothing
                End Try

            End If

            If Not ds Is Nothing AndAlso ds.Tables.Contains("ConfigConnect") Then
                Dim tb As DataTable = ds.Tables("ConfigConnect")
                For Each dr As DataRow In tb.Rows
                    If tb.Columns.Contains("srv") Then
                        Server = IsNull(dr("srv"), "")
                    End If
                    If tb.Columns.Contains("db") Then
                        Database = IsNull(dr("db"), "")
                    End If
                    If tb.Columns.Contains("uid") Then
                        UserName = IsNull(dr("uid"), "")
                    End If
                    If tb.Columns.Contains("pwd") Then
                        Password = IsNull(dr("pwd"), "")
                        Password = uti.Decrypt1(Password)
                    End If
                Next
            End If
        End If

        If Server = "" Then
            Server = "(local)"
            If Database = "" Then Database = "POS"
            If UserName = "" Then UserName = "sa"
            If Password = "" Then Password = "123456"
            If TestConnectDB() Then
                SaveConfig()
            End If
        End If
    End Sub
#End Region

#Region "các thuộc tính"
    <Description("Thiết lập Chuỗi kết nối theo cách của bạn.")> _
    Property connectString() As String
        Get
            Return strConn
        End Get
        Set(ByVal value As String)
            strConn = value
        End Set
    End Property
    <Description("Thiết lập tên server mà bạn sẽ kết nối.")> _
        Property Server() As String
        Get
            Return ser
        End Get
        Set(ByVal value As String)
            ser = value
        End Set
    End Property

    <Description("Thiết lập database sẽ sử dụng.")> _
    Property Database() As String
        Get
            Return db
        End Get
        Set(ByVal value As String)
            db = value
        End Set
    End Property

    <Description("Tên dùng để kết nối đến server.")> _
    Property UserName() As String
        Get
            Return uid
        End Get
        Set(ByVal value As String)
            uid = value
        End Set
    End Property

    <Description("Password dung để kết nối với server.")> _
    Property Password() As String
        Get
            Return pass
        End Get
        Set(ByVal value As String)
            pass = value
        End Set
    End Property
    Property CommandTimeOut() As Integer
        Get
            Return iCommandTimeOut
        End Get
        Set(ByVal value As Integer)
            iCommandTimeOut = value
        End Set
    End Property

#End Region

#Region "lấy chuỗi kết nối"
    <Description("Lấy chuỗi kết nối.")> _
    Protected Function getConnectString() As String
        If Not strConn Is Nothing AndAlso strConn.Trim <> "" Then
            Return strConn
        End If

        If Server = "" Or Database = "" Then
            RaiseEvent _error("Không lấy được thông tin kết nối")
            Return ""
        End If

        Dim sCNN As String = String.Format("data source={0};initial catalog={1};user id ={2};password={3};", Server, Database, UserName, Password)

        Return sCNN
    End Function
#End Region

#Region "kết nối đến database"
    Protected Function connectDB() As Boolean

        Dim sCNN As String = ""
        Try
            sCNN = Me.getConnectString()
        Catch ex As Exception
            If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            Throw New Exception(ex.Message)
            Return False
        End Try

        Try
            If sCNN = "" Then Return False
            If m_Transaction Is Nothing Then
                conn = New SqlConnection(sCNN)
                conn.Open()
            End If


        Catch ex As SqlException
            If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            RaiseEvent _error(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Public Function TestConnectDB() As Boolean
        Try
            If Server = "" OrElse Database = "" OrElse UserName = "" Then Return False
            strConn = String.Format("data source={0};initial catalog={1};user id ={2};password={3};", Server, Database, UserName, Password)
            Dim cn As New SqlClient.SqlConnection(strConn)
            cn.Open()
            cn.Close()
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Function TestConnectDB(ByVal sConn As String) As Boolean
        Try
            Dim cn As New SqlClient.SqlConnection(sConn)
            cn.Open()
            cn.Close()
            Return True
        Catch ex As Exception
            RaiseEvent _error(ex.Message)
        End Try
        Return False

    End Function
    Protected Function getNewID() As String
        Dim sID As String = Guid.NewGuid.ToString
        Return sID
    End Function
    Protected Function getDateSrv() As Date
        Dim tb As DataTable = Me.getTableSQL("Select getDate() as D")
        Return tb.Rows(0)("D")
    End Function

    Protected Function execSQL(ByVal sConn As String, ByVal strSQL As String) As Boolean
        Dim cn As New SqlClient.SqlConnection(sConn)
        Try
            cn.Open()
        Catch ex As Exception
            msgerr = ex.Message
            RaiseEvent _error(ex.Message)
            Return False
        End Try


        cmd = New SqlCommand(strSQL, cn)
        cmd.CommandType = CommandType.Text
        cmd.CommandTimeout = iCommandTimeOut

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            cn.Close()
            msgerr = ex.Message
            Me.WriteLog(strSQL & ";(" & msgerr & ")")
            RaiseEvent _error(ex.Message)
            Return False
        End Try

        cn.Close()
        Return True
    End Function

    Protected Function getDatasetSQL(ByVal sConn As String, ByVal strSQL As String) As DataSet
        Dim ds As DataSet
        Dim cn As New SqlClient.SqlConnection(sConn)
        Try

            cn.Open()
        Catch ex As Exception
            msgerr = ex.Message
            RaiseEvent _error(ex.Message)
            Return Nothing
        End Try

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        cmd = New SqlCommand(strSQL, cn)
        cmd.CommandType = CommandType.Text
        cmd.CommandTimeout = iCommandTimeOut
        da = New SqlDataAdapter(cmd)

        Try
            ds = New DataSet
            da.Fill(ds)

        Catch ex As Exception
            cn.Close()
            msgerr = ex.Message
            Me.WriteLog(strSQL & ";(" & msgerr & ")")
            RaiseEvent _error(ex.Message)
            Return Nothing
        End Try

        cn.Close()

        Return ds
    End Function
#End Region

#Region "thao tác với dữ liệu bằng lệnh SQL"
    <Description("Lấy dataset dữ liệu bằng lệnh SQL.")> _
            Protected Function getDatasetSQL(ByVal strSQL As String) As DataSet
        Dim ds As DataSet
        Try
            If Not Me.connectDB() Then
                Return Nothing
            End If
        Catch ex As Exception
            msgerr = ex.Message
            RaiseEvent _error(ex.Message)
            Return Nothing
        End Try




        Try
            cmd = New SqlCommand(strSQL, conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = iCommandTimeOut
            If Not m_Transaction Is Nothing Then
                cmd.Transaction = m_Transaction
            End If
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds)

        Catch ex As Exception
            RollbackTransction()
            If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            msgerr = ex.Message
            Me.WriteLog(strSQL & ";(" & msgerr & ")")
            RaiseEvent _error(ex.Message)
            Return Nothing
        End Try

        If m_Transaction Is Nothing AndAlso Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Return ds
    End Function

    Protected Function getDatasetSQL(ByVal strSQL As String, ByVal ParamArray p() As SqlParameter) As DataSet
        Dim ds As DataSet
        Try
            If Not Me.connectDB() Then
                Return Nothing
            End If
        Catch ex As Exception
            msgerr = ex.Message
            RaiseEvent _error(ex.Message)
            Return Nothing
        End Try

        Try
            cmd = New SqlCommand(strSQL, conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = iCommandTimeOut
            If Not m_Transaction Is Nothing Then
                cmd.Transaction = m_Transaction
            End If
            For Each pa As SqlParameter In p
                If Not pa Is Nothing Then
                    cmd.Parameters.Add(pa)
                End If

            Next

            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds)

        Catch ex As Exception
            RollbackTransction()
            If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            msgerr = ex.Message
            Me.WriteLog(strSQL & ";(" & msgerr & ")")
            RaiseEvent _error(ex.Message)
            Return Nothing
        End Try

        If m_Transaction Is Nothing AndAlso Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Return ds
    End Function





    <Description("Lấy data table dữ liệu bằng lệnh SQL.")> _
            Protected Function getTableSQL(ByVal strSQL As String) As DataTable
        Dim tb As DataTable

        Try
            If Not Me.connectDB() Then
                Return Nothing
            End If
        Catch ex As Exception
            msgerr = ex.Message
            RaiseEvent _error(ex.Message)
            Return Nothing
        End Try




        Try
            cmd = New SqlCommand(strSQL, conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = iCommandTimeOut
            If Not m_Transaction Is Nothing Then
                cmd.Transaction = m_Transaction
            End If
            da = New SqlDataAdapter(cmd)
            tb = New DataTable
            da.Fill(tb)
        Catch ex As Exception

            RollbackTransction()
            If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            msgerr = ex.Message
            Me.WriteLog(strSQL & ";(" & msgerr & ")")
            RaiseEvent _error(ex.Message)
            Return Nothing
        End Try
        If m_Transaction Is Nothing AndAlso Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Return tb
    End Function


    <Description("Thực thi một câu lệnh SQL (update hoặc delete).")> _
    Protected Function execSQL(ByVal strSQL As String) As Boolean

        Try
            If Not Me.connectDB() Then
                Return False
            End If
        Catch ex As Exception
            msgerr = ex.Message
            RaiseEvent _error(ex.Message)
            Return False
        End Try

        Try
            cmd = New SqlCommand(strSQL, conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = iCommandTimeOut
            If Not m_Transaction Is Nothing Then
                cmd.Transaction = m_Transaction
            End If
            cmd.ExecuteNonQuery()
            'conn.Close()
        Catch ex As Exception
            RollbackTransction()
            If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            msgerr = ex.Message
            Me.WriteLog(strSQL & ";(" & msgerr & ")")
            RaiseEvent _error(ex.Message)
            Return False
        End Try

        If m_Transaction Is Nothing AndAlso Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Return True
    End Function

#End Region

#Region "sử dụng lệnh SQL có parameter"



    <Description("Thực thi một lệnh SQL có sử dụng các tham số. Các lệnh SQL được viết riêng")> _
    Protected Function execSQL(ByVal strSQL As String, ByVal ParamArray listParameter() As SqlParameter) As Boolean

        Try
            If Not Me.connectDB() Then
                Return False
            End If
            cmd = New SqlCommand(strSQL, conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = iCommandTimeOut
            If Not m_Transaction Is Nothing Then
                cmd.Transaction = m_Transaction
            End If
            For Each p As SqlParameter In listParameter
                If Not p Is Nothing Then
                    If Not IsDBNull(p.Value) Then
                        cmd.Parameters.Add(p)
                    Else
                        Dim ss As String = ""
                    End If

                End If
            Next
            cmd.ExecuteNonQuery()
            If m_Transaction Is Nothing AndAlso Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            Return True
        Catch ex As Exception
            RollbackTransction()
            If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            msgerr = ex.Message
            Me.WriteLog(strSQL & ";(" & msgerr & ")")
            RaiseEvent _error(ex.Message)
            Return False
        End Try


    End Function

    <Description("19/03/2009 DAT")> _
  Protected Function ExecuteQuery(ByVal strSQL As String, ByRef ds As DataSet, ByVal ParamArray listParameter() As SqlParameter) As Boolean

        Try
            If Not Me.connectDB() Then
                Return False
            End If
        Catch ex As Exception
            msgerr = ex.Message
            RaiseEvent _error(ex.Message)
            Return False
        End Try


        Try
            cmd = New SqlCommand(strSQL, conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = iCommandTimeOut
            If Not m_Transaction Is Nothing Then
                cmd.Transaction = m_Transaction
            End If
            For Each p As SqlParameter In listParameter
                If Not p Is Nothing Then
                    cmd.Parameters.Add(p)
                End If

            Next
            da = New SqlDataAdapter(cmd)
            da.Fill(ds)
            If m_Transaction Is Nothing AndAlso Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            Return True
        Catch ex As Exception
            RollbackTransction()
            If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            msgerr = ex.Message
            Me.WriteLog(strSQL & ";(" & msgerr & ")")
            RaiseEvent _error(ex.Message)
            Return False

        End Try


    End Function

    <Description("Lấy table = thực thi một lệnh SQL có sử dụng các tham số. Các lệnh SQL được viết riêng")> _
    Protected Function getTableSQL(ByVal strSQL As String, ByVal ParamArray listParameter() As SqlParameter) As DataTable
        Try
            If Not Me.connectDB() Then
                Return Nothing
            End If
        Catch ex As Exception
            msgerr = ex.Message
            RaiseEvent _error(ex.Message)
            Return Nothing
        End Try

        Dim tb As New DataTable
        Try
            cmd = New SqlCommand(strSQL, conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = iCommandTimeOut
            If Not m_Transaction Is Nothing Then
                cmd.Transaction = m_Transaction
            End If
            For Each p As SqlParameter In listParameter
                If Not p Is Nothing Then
                    cmd.Parameters.Add(p)
                End If
            Next

            da = New SqlDataAdapter(cmd)
            da.Fill(tb)
        Catch ex As Exception
            RollbackTransction()
            If Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            msgerr = ex.Message
            Me.WriteLog(strSQL & ";(" & msgerr & ")")
            RaiseEvent _error(ex.Message)
            Return Nothing
        End Try

        cmd.Dispose()
        da.Dispose()
        If m_Transaction Is Nothing AndAlso Not conn Is Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Return tb
    End Function


#End Region

    Public Function IsNull(ByVal Exp As Object, ByVal ExpReplace As Object) As Object
        If IsDBNull(Exp) Then
            Return ExpReplace
        Else
            Return Exp
        End If
    End Function

    Public Function getDateC(ByVal d_Date As Date) As String
        Dim d As String
        Dim m As String
        Dim y As String

        If d_Date.Day < 10 Then
            d = "0" & CStr(d_Date.Day)
        Else
            d = CStr(d_Date.Day)
        End If
        If d_Date.Month < 10 Then
            m = "0" & CStr(d_Date.Month)
        Else
            m = CStr(d_Date.Month)
        End If
        y = CStr(d_Date.Year).Substring(2, 2)

        Return d & m & y

    End Function
    Public Function getQueryDate(ByVal fromDate As Date, ByVal toDate As Date, ByVal ColDate As String) As String
        Dim strQueryDate As String = ""
        Dim sFormat As String = "yyyy-MM-dd"
        Dim sFrom As String = Format(fromDate, sFormat)
        Dim sTo As String = Format(toDate.AddDays(1), sFormat)
        strQueryDate = ColDate & ">='" & sFrom & "' AND " & ColDate & "<'" & sTo & "'"
        Return strQueryDate
    End Function
    ''' <summary>
    ''' truy vấn điều kiện filter theo chi nhánh
    ''' </summary>
    ''' <param name="branchId"></param>
    ''' <param name="colCompare"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getQueryBranch(ByVal branchId As String, ByVal colCompare As String) As String
        Dim str As String = "1=0"
        If branchId <> "-1" Then
            Dim tb = Me.getTableSQL("select s_ID from Ls_Stores where BranchId='" & branchId & "'") 'filter những phiếu cũ

            Dim storeIdArr As String = "'" & branchId & "'" 'gán mặc định để filter những phiếu mới

            If Not IsNothing(tb) AndAlso tb.Rows.Count > 0 Then
                For Each r As DataRow In tb.Rows
                    storeIdArr += ",'" & r(0).ToString & "'"
                Next
            End If
            str = colCompare & " in(" & storeIdArr & ")"
        Else
            'str = "Exists(select top 1 1 from Pr_FunRight_Ext where FuncID=" & colCompare & " and UID='" & m_UIDLogin & "' and R=1)"
            str = "1=1"
        End If

        Return str
    End Function

    Public Function StatusText(ByVal key As String) As String
        Select Case key
            Case "Signed"
                Return "Đã ký"
            Case "Waiting"
                Return "Đang chờ"
            Case "WaitingForApprove"
                Return "Chờ duyệt"
            Case "Accepted"
                Return "Đã duyệt"
            Case "Rejected"
                Return "Không duyệt"
            Case "Pending"
                Return "Tạm ngưng"
            Case "Inprogress"
                Return "Đang xử lý"
            Case "Completed"
                Return "Hoàn thành"
            Case "WaitForPay"
                Return "Chờ thanh toán"
            Case "Paid"
                Return "Đã thanh toán"
            Case Else
                Return ""
        End Select

        Return ""
    End Function
End Class


