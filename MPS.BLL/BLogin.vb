Public Class BLogin
    Private Sub New()
    End Sub
    Private Shared obj As BLogin
    Public Shared ReadOnly Property Instance() As BLogin
        Get
            If obj Is Nothing Then
                obj = New BLogin
            End If
            Return obj
        End Get
    End Property
    Dim WithEvents cls As DAL.DALLogin = DAL.DALLogin.Instance
    Event _errorRaise(ByVal message As String)

    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Public Function TestConnect() As Boolean
        Return cls.TestConnectDB
    End Function

    Public Function TestConnect(ByVal sCnn As String) As Boolean
        Return cls.TestConnectDB(sCnn)
    End Function
    Public Function getUnikeyIDfromDB() As Integer
        Return cls.getUnikeyIDfromDB
    End Function
    Public Function getUser(ByVal UID As String) As DataTable
        Return cls.getUser(UID)
    End Function
    Public Function getUser_Login(ByVal UID As String) As DataTable
        Return cls.getUser_Login(UID)
    End Function
    Public Sub SaveConfig()
        cls.SaveConfig()
    End Sub
    Public Sub getInfoConnect(ByRef s_srv As String, ByRef s_uid As String, ByRef s_pwd As String, ByRef s_db As String)
        s_srv = cls.Server
        s_uid = cls.UserName
        s_pwd = cls.Password
        s_db = cls.Database
    End Sub
    Public Sub setInfoConnect(ByVal s_srv As String, ByVal s_uid As String, ByVal s_pwd As String, ByVal s_db As String)
        cls.Server = s_srv
        cls.UserName = s_uid
        cls.Password = s_pwd
        cls.Database = s_db
    End Sub

    Public Function getDatechar(ByVal d_Date As Date) As String
        Return cls.regetDatechar(d_Date)
    End Function
    Public Function getSrvDate() As Date
        Return cls.getSrvDate()
    End Function
    Public Function getDataVsoft(ByVal sCNN As String) As DataTable
        Return cls.getDataVsoft(sCNN)
    End Function
    Public Function CheckDataVsoft(ByVal DBNAME As String, ByVal sCNN As String) As Boolean
        Return cls.CheckDataVsoft(DBNAME, sCNN)
    End Function

    Public Function DetachDB(ByVal DBNAME As String, ByVal sCNN As String) As Boolean
        Return cls.DetachDB(DBNAME, sCNN)
    End Function
    Public Function UpDateComputerLogin(ByVal HostName As String, ByVal IPAddress As String, ByVal Valid As Boolean) As Boolean
        Return cls.UpDateComputerLogin(HostName, IPAddress, Valid)
    End Function
    Public Function getListComputerLogin() As DataTable
        Return cls.getListComputerLogin
    End Function

    Public Function DateDiff(ByVal Part As String, ByVal d1 As Date, ByVal d2 As Date) As Integer
        Return cls.DateDiff(Part, d1, d2)
    End Function
    Public Function CheckUpdateVersion(ByVal nByte As Integer) As Boolean
        Return cls.CheckUpdateVersion(nByte)
    End Function
    Public Function UpdateVersion(ByVal nByte As Integer) As Boolean
        Return cls.UpdateVersion(nByte)
    End Function
End Class
