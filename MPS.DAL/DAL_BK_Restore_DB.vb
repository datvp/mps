Imports System.Data.SqlClient

Public Class DAL_BK_Restore_DB
    Inherits DALSQL
    'Dim sql As String = "Exec sp_GetIndexOrder @dayMonth"
    Public Function EnableCMDShell() As Boolean
        Dim sql As String = ""
        sql = "EXEC master.dbo.sp_configure 'show advanced options', 1"
        sql += " RECONFIGURE"
        sql += " EXEC master.dbo.sp_configure 'xp_cmdshell', 1"
        sql += " RECONFIGURE"
        Return execSQL(sql)

    End Function
    Public Function getFileDir(ByVal Path As String) As DataTable
        Dim sql As String = "Exec xp_cmdshell @Path"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@Path", Path)
        Dim tb As DataTable = getTableSQL(sql, p)
        If tb Is Nothing Then
            If Not EnableCMDShell() Then
                Return Nothing
            Else
                tb = ReGetFileDir(Path)
            End If
        End If
        Return tb

    End Function
    Public Function ReGetFileDir(ByVal Path As String) As DataTable
        Dim sql As String = "Exec xp_cmdshell @Path"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@Path", Path)
        Dim tb As DataTable = getTableSQL(sql, p)
        Return tb
    End Function
    Public Function BackupDB(ByVal dbName As String, ByVal toFile As String) As Boolean
        Dim sql As String = "BACKUP DATABASE [" & dbName.Replace("'", "''") & "] TO  DISK = N'" & toFile.Replace("'", "''") & "' WITH NOFORMAT,"
        sql += " INIT, NAME = N'" & dbName.Replace("'", "''") & "-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"
        Return Me.execSQL(sql)
    End Function
    Private Function KillUser(ByVal dbName As String) As Boolean

        Dim tb As DataTable = getTableSQL("exec sp_who")
        Dim sql As String = ""

        For Each dr As DataRow In tb.Rows
            If Trim(IsNull(dr("dbname"), "")).ToLower = Trim(dbName).ToLower Then
                sql += " Kill " & dr("spID")
            End If
        Next
        If sql <> "" Then
            If Not Me.execSQL(sql) Then
                Return False
            End If
        End If

        Return True
    End Function
    Public Function RestoreDB(ByVal FileOrigin As String, ByVal dbName As String, ByVal fromFile As String, ByVal toFileData As String, ByVal toFileLog As String) As Boolean
        Dim sDB As String = Me.Database
        Me.Database = "master"
        Me.isWriteLog = False
        If Not KillUser(dbName) Then
            Me.Database = sDB
            Me.isWriteLog = True
            Return False
        End If

        Dim sql As String = ""
        sql = "RESTORE DATABASE [" & dbName.Replace("'", "''") & "] FROM  DISK = '" & fromFile.Replace("'", "''") & "' WITH  FILE = 1, "
        sql += " MOVE N'" & FileOrigin & "' TO '" & toFileData.Replace("'", "''") & "',  MOVE N'" & FileOrigin & "_log' TO '" & toFileLog.Replace("'", "''") & "', "
        sql += " NOUNLOAD, REPLACE, STATS = 10"

        Dim fOK As Boolean = Me.execSQL(sql)
        Me.Database = sDB
        Me.isWriteLog = True

        Return fOK
    End Function

    Public strError As String = ""
    Dim strDB As String = ""
    Public Function AttachDB(ByVal sFileName As String) As Boolean
        Try
            strError = ""

            'Dim sCnnMaster As String = Me.getConnectString
            Dim sCnnMaster As String = "data source=" & Me.Server & ";initial catalog=master;user id =" & Me.UserName & ";password=" & Me.Password & ";"

            Dim sql As String = ""
            Dim sDB As String = ""
            Dim arrS() As String = sFileName.Split("\")
            If arrS.Length = 0 Then Return False
            sDB = arrS(arrS.Length - 1)
            sDB = sDB.Replace("'", String.Empty)
            Dim ind As Integer = sDB.LastIndexOf(".")

            sDB = sDB.Substring(0, ind)
            Me.isWriteLog = False
            Dim stmpDB As String = Me.Database
            Me.Database = "master"
            If Not KillUser(sDB) Then
                Me.Database = stmpDB
                Me.isWriteLog = True
                Return False
            End If

            Dim tb As DataTable = getTableSQL("Select * from master.sys.databases where [Name]=N'" & sDB.Replace("'", "''") & "'")
            If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then

                sql = "EXEC master.dbo.sp_detach_db @dbname = N'" & tb.Rows(0)("Name") & "', @keepfulltextindexfile=N'true'"
                If Not execSQL(sCnnMaster, sql) Then
                    Me.Database = stmpDB
                    Return False
                End If
                'MsgBox("Database :" & sDB & " đã được tồi tại ", MsgBoxStyle.Critical)
                'Return False
            End If

            'dang nhap bang ket noi window authentication
            Dim sCnnWindow As String = "Server=" & Me.Server & ";Database=master;Trusted_Connection=Yes;"
            If TestConnectDB(sCnnWindow) Then
                sql = "CREATE DATABASE [" & sDB & "] ON ( FILENAME = N'" & sFileName.Replace("'", "''") & "' ) FOR ATTACH"
                If execSQL(sCnnWindow, sql) Then
                    sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                    execSQL(sCnnWindow, sql)
                    strDB = sDB
                    Me.Database = stmpDB
                    Return True
                End If

                sql = "CREATE DATABASE [" & sDB & "] ON ( FILENAME = N'" & sFileName.Replace("'", "''") & "' ) FOR ATTACH_REBUILD_LOG"
                If execSQL(sCnnWindow, sql) Then
                    sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                    execSQL(sCnnWindow, sql)
                    strDB = sDB
                    Me.Database = stmpDB
                    Return True
                Else
                    ind = sFileName.LastIndexOf("\")
                    If ind <> -1 Then
                        Dim sFileLog As String = sFileName.Substring(0, ind) & "\"
                        sFileLog += sDB & "_LOG.LDF"

                        sql = "CREATE DATABASE [" & sDB & "] ON ( FILENAME = N'" & sFileName.Replace("'", "''") & "' ),"
                        sql += " ( FILENAME = N'" & sFileLog.Replace("'", "''") & "' ) FOR ATTACH"
                        If execSQL(sCnnWindow, sql) Then
                            sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                            execSQL(sCnnWindow, sql)
                            strDB = sDB
                            Me.Database = stmpDB
                            Return True
                        End If
                    End If

                    sql = "EXEC sp_attach_single_file_db @dbname ='" & sDB & "', @physname=N'" & sFileName.Replace("'", "''") & "'"
                    If execSQL(sCnnWindow, sql) Then
                        sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                        execSQL(sCnnWindow, sql)
                        strDB = sDB
                        Me.Database = stmpDB
                        Return True
                    End If

                End If
            End If


            'Dang nhap bang user sa
            sql = "CREATE DATABASE [" & sDB & "] ON ( FILENAME = N'" & sFileName.Replace("'", "''") & "' ) FOR ATTACH"
            If execSQL(sCnnMaster, sql) Then
                sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                execSQL(sCnnMaster, sql)
                strDB = sDB
                Me.Database = stmpDB
                Return True
            End If

            sql = "CREATE DATABASE [" & sDB & "] ON ( FILENAME = N'" & sFileName.Replace("'", "''") & "' ) FOR ATTACH_REBUILD_LOG"
            If execSQL(sCnnMaster, sql) Then
                sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                execSQL(sCnnMaster, sql)
                strDB = sDB
                Me.Database = stmpDB
                Return True
            Else
                ind = sFileName.LastIndexOf("\")
                If ind <> -1 Then
                    Dim sFileLog As String = sFileName.Substring(0, ind) & "\"
                    sFileLog += sDB & "_LOG.LDF"

                    sql = "CREATE DATABASE [" & sDB & "] ON ( FILENAME = N'" & sFileName.Replace("'", "''") & "' ),"
                    sql += " ( FILENAME = N'" & sFileLog.Replace("'", "''") & "' ) FOR ATTACH"
                    If execSQL(sCnnMaster, sql) Then
                        sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                        execSQL(sCnnMaster, sql)
                        strDB = sDB
                        Me.Database = stmpDB
                        Return True
                    End If
                End If

                sql = "EXEC sp_attach_single_file_db @dbname ='" & sDB & "', @physname=N'" & sFileName.Replace("'", "''") & "'"
                If execSQL(sCnnMaster, sql) Then
                    sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                    execSQL(sCnnMaster, sql)
                    strDB = sDB
                    Me.Database = stmpDB
                    Return True
                End If

            End If

            'dang nhap bang ket noi window authentication
            If TestConnectDB(sCnnWindow) Then
                sql = "CREATE DATABASE [" & sDB & "] ON ( FILENAME = N'" & sFileName.Replace("'", "''") & "' ) FOR ATTACH"
                If execSQL(sCnnWindow, sql) Then
                    sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                    execSQL(sCnnWindow, sql)
                    strDB = sDB
                    Me.Database = stmpDB
                    Return True
                End If

                sql = "CREATE DATABASE [" & sDB & "] ON ( FILENAME = N'" & sFileName.Replace("'", "''") & "' ) FOR ATTACH_REBUILD_LOG"
                If execSQL(sCnnWindow, sql) Then
                    sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                    execSQL(sCnnWindow, sql)
                    strDB = sDB
                    Me.Database = stmpDB
                    Return True
                Else
                    ind = sFileName.LastIndexOf("\")
                    If ind <> -1 Then
                        Dim sFileLog As String = sFileName.Substring(0, ind) & "\"
                        sFileLog += sDB & "_LOG.LDF"

                        sql = "CREATE DATABASE [" & sDB & "] ON ( FILENAME = N'" & sFileName.Replace("'", "''") & "' ),"
                        sql += " ( FILENAME = N'" & sFileLog.Replace("'", "''") & "' ) FOR ATTACH"
                        If execSQL(sCnnWindow, sql) Then
                            sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                            execSQL(sCnnWindow, sql)
                            strDB = sDB
                            Me.Database = stmpDB
                            Return True
                        End If
                    End If

                    sql = "EXEC sp_attach_single_file_db @dbname ='" & sDB & "', @physname=N'" & sFileName.Replace("'", "''") & "'"
                    If execSQL(sCnnWindow, sql) Then
                        sql = "if not exists (select name from master.sys.databases sd where name = N'" & sDB & "' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [DBVO].dbo.sp_changedbowner @loginame=N'sa', @map=false"
                        execSQL(sCnnWindow, sql)
                        strDB = sDB
                        Me.Database = stmpDB
                        Return True
                    End If

                End If
            End If

            Me.Database = stmpDB

        Catch ex As Exception

        End Try

    End Function

End Class
