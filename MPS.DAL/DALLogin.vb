Imports System.Data.SqlClient
Public Class DALLogin
    Inherits DALSQL

    Private Sub New()
    End Sub
    Private Shared obj As DALLogin
    Public Shared ReadOnly Property Instance() As DALLogin
        Get
            If obj Is Nothing Then
                obj = New DALLogin
            End If
            Return obj
        End Get
    End Property

    Public Function getUnikeyIDfromDB() As Integer
        Dim tb As DataTable = getTableSQL("Select * from sysvsoft where [ID]=2")
        If Not tb Is Nothing Then
            If tb.Rows.Count > 0 Then
                If IsNumeric(tb.Rows(0)("Note")) Then
                    Return CInt(tb.Rows(0)("Note"))
                End If
            End If
        End If
        Return -1
    End Function
    Public Function getURLHQ() As String
        Dim tb As DataTable = getTableSQL("Select isnull(URLHQ,'') as URL from tblConfig")
        If Not tb Is Nothing Then
            If tb.Rows.Count > 0 Then
                Return tb.Rows(0)("URL")
            End If
        End If
        Return ""
    End Function

    Public Function getStoreID() As String
        Dim tb As DataTable = getTableSQL("Select isnull(StoreID,'') as URL from tblConfig")
        If Not tb Is Nothing Then
            If tb.Rows.Count > 0 Then
                Return tb.Rows(0)("URL")
            End If
        End If
        Return ""
    End Function

    Public Function getUser(ByVal UID As String) As DataTable
        m_UIDLogin = UID
        Dim sql As String = ""
        sql += "Select top 1 ls.*,le.* from Ls_User ls left join ls_Employees le on ls.s_Employee_ID=le.s_ID where s_UID=@UID and b_Valid=1"
        Return Me.getTableSQL(sql, New SqlParameter("@UID", UID))
    End Function

    Public Function getUser_Login(ByVal UID As String) As DataTable
        Dim sql As String = ""
        sql += "select le.* "
        sql += " from Ls_User ls left join ls_Employees le on ls.s_Employee_ID=le.s_ID"
        sql += " where ls.s_UID=@UID"

        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@UID", UID)

        Return Me.getTableSQL(sql, p)

    End Function

    Public Function CheckDataVsoft(ByVal DBNAME As String, ByVal sCNN As String) As Boolean
        connectString = sCNN
        isWriteLog = False
        Dim sql = "Select count(*) as C from [" & DBNAME.Replace("'", "''") & "].dbo.sysobjects where xtype='U' and [name]='sysvsoft'"
        
        Dim tb As DataTable = Me.getTableSQL(sql)
        If Not tb Is Nothing Then
            If tb.Rows(0)("c") > 0 Then
                connectString = ""
                isWriteLog = True
                Return True
            End If
        End If
        isWriteLog = True
        connectString = ""
        Return False
    End Function
    Public Function getDataVsoft(ByVal sCNN As String) As DataTable
        Try
            connectString = sCNN
            Dim sql = "Select [name] from master.dbo.sysdatabases where [Name] not in ('master','model','msdb','tempdb') Order by [Name]"
            Dim tb As DataTable = Me.getTableSQL(sql)
            connectString = ""
            Return tb
        Catch ex As Exception
            Dim ss As String = ex.Message
        End Try
        Return Nothing
    End Function
    Private Sub test()
        Dim sql As String = "Exec sp_test @ii output,@aa,@ba"

        Dim a As String = "ccc"
        Dim b As Boolean = False
        Dim i As Integer = 0
        Dim p(2) As SqlParameter
        p(2) = New SqlParameter("@ii", i)
        p(2).Direction = ParameterDirection.Output

        p(1) = New SqlParameter("@aa", a)
        p(0) = New SqlParameter("@ba", b)

        If Me.execSQL(sql, p) Then
            i = p(2).Value
        End If

    End Sub
    Public Function regetDatechar(ByVal d_Date As Date) As String
        Return Me.getDateC(d_Date)
    End Function
    Public Function getSrvDate() As Date
        Return Me.getDateSrv()
    End Function
    Public Function DetachDB(ByVal DBNAME As String, ByVal sCNN As String) As Boolean
        Dim tb = getTableSQL("exec sp_who")
        Dim sql As String = ""

        For Each dr As DataRow In tb.Rows
            If Trim(IsNull(dr("dbname"), "")).ToLower = Trim(DBNAME).ToLower Then
                sql += " Kill " & dr("spID")
            End If
        Next
        If sql <> "" Then
            If Not Me.execSQL(sCNN, sql) Then
                connectString = ""
                Return False
            End If
        End If

        sql = "EXEC master.dbo.sp_detach_db @dbname = N'" & DBNAME.Replace("'", "''") & "'"
        connectString = ""
        Return execSQL(sCNN, sql)
    End Function
    Public Function UpDateComputerLogin(ByVal HostName As String, ByVal IPAddress As String, ByVal Valid As Boolean) As Boolean
        Dim tb As DataTable = Me.getTableSQL("Select * from tblComputerLogin where IPAddress=N'" & IPAddress.Replace("'", "''") & "'")
        Dim sql As String = ""
        Dim p(2) As SqlParameter
        p(0) = New SqlParameter("@HostName", HostName)
        p(1) = New SqlParameter("@IPAddress", IPAddress)
        p(2) = New SqlParameter("@Valid", Valid)
        Dim isAdd As Boolean = True
        If tb Is Nothing Then Exit Function
        If tb.Rows.Count > 0 Then isAdd = False
        sql = "Delete from tblComputerLogin where datediff(day,dt_Login,getdate())>0 "
        If isAdd Then
            sql += " Insert into tblComputerLogin([HostName],[IPAddress],[dt_Login],[Valid])values(@HostName,@IPAddress,getdate(),@Valid)"
        Else
            If Valid Then
                sql += " Update tblComputerLogin set [HostName]=@HostName,[Valid]=@Valid,dt_Login=getdate(),dt_Out=null where IPAddress=@IPAddress"
            Else
                sql += " Update tblComputerLogin set [HostName]=@HostName,[Valid]=@Valid,dt_Out=getdate() where IPAddress=@IPAddress"
            End If
        End If
        Return execSQL(sql, p)
    End Function
    Public Function getListComputerLogin() As DataTable
        Dim tb As DataTable = Me.getTableSQL("Select cast(1 as bit) as isSelect,* from tblComputerLogin")
        Return tb
    End Function

    Public Function DateDiff(ByVal Part As String, ByVal d1 As Date, ByVal d2 As Date) As Integer
        Dim p(2) As SqlParameter
        p(0) = New SqlParameter("@d1", d1)
        p(1) = New SqlParameter("@d2", d2)
        Dim sql As String = "Select Datediff(" & Part & ",@d1,@d2) as n"
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If Not tb Is Nothing Then
            Return tb.Rows(0)("n")
        Else
            Return 0
        End If

    End Function
    Public Function CheckUpdateVersion(ByVal nByte As Integer) As Boolean
        Dim sql As String = "Select count(*) as C from sysobjects where xtype='U' and [name]='tbVersion'"
        Dim tb As DataTable = getTableSQL(sql)
        If Not tb Is Nothing AndAlso tb.Rows(0)("C") = 0 Then
            sql = "Create table tbVersion([ID] int identity(1,1),dtUpdate smallDatetime default(getdate()),lByte int,Note nvarchar(255))"
            If Not execSQL(sql) Then Return False
            sql = "Insert into tbVersion(dtUpdate,lByte,Note) values(getdate(),0,'')"
            If Not execSQL(sql) Then Return False
        End If
        sql = "Select top 1 isnull(lByte,0) as n from tbVersion Order by [ID] desc "
        tb = getTableSQL(sql)
        If Not tb Is Nothing AndAlso tb.Rows.Count = 1 Then
            If tb.Rows(0)("n") <> nByte Then
                Return True
            Else
                Return False
            End If
        End If
        Return True
    End Function
    Public Function UpdateVersion(ByVal nByte As Integer) As Boolean
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@nByte", nByte)
        Dim sql As String = "Select count(*) as C from sysobjects where xtype='U' and [name]='tbVersion'"
        Dim tb As DataTable = getTableSQL(sql)
        If Not tb Is Nothing AndAlso tb.Rows(0)("C") = 0 Then
            sql = "Create table tbVersion([ID] int identity(1,1),dtUpdate smallDatetime default(getdate()),lByte int,Note nvarchar(255))"
            If Not execSQL(sql) Then Return False
            sql = "Insert into tbVersion(dtUpdate,lByte,Note) values(getdate(),0,'')"
            If Not execSQL(sql) Then Return False
        End If
        sql = " if (Select count(*)as C from tbVersion)=0"
        sql += " Insert into tbVersion(dtUpdate,lByte,Note) values(getdate(),@nByte,N'Update database')"
        sql += " else"
        sql += " Update tbVersion set dtUpdate=getdate(),lByte=@nByte,Note=N'Update database'"
        Return execSQL(sql, p)
    End Function
    Public Function CheckDLL() As Boolean
        Return Me.KiemTraDLL
    End Function
End Class
