Public Class B_BK_Restore_DB
    Private WithEvents cls As New DAL.DAL_BK_Restore_DB
    Event _errorRaise(ByVal messege As String)

    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Public Function getFileDir(ByVal Path As String) As DataTable
        Return cls.getFileDir(Path)
    End Function
    Public Function BackupDB(ByVal dbName As String, ByVal toFile As String) As Boolean
        Return cls.BackupDB(dbName, toFile)
    End Function
    
    Public Function RestoreDB(ByVal FileOrigin As String, ByVal dbName As String, ByVal fromFile As String, ByVal toFileData As String, ByVal toFileLog As String) As Boolean
        Return cls.RestoreDB(FileOrigin, dbName, fromFile, toFileData, toFileLog)
    End Function
    Public Function EnableCMDShell() As Boolean
        Return cls.EnableCMDShell
    End Function
    Public Function AttachDB(ByVal sFileName As String) As Boolean
        Return cls.AttachDB(sFileName)
    End Function
End Class
