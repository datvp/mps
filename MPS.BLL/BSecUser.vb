Public Class BSecUser
    Private WithEvents cls As New DAL.DALSecUser
    Event _errorRaise(ByVal messege As String)

    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Public Function getList() As DataTable
        Return cls.getList
    End Function
    '25/5/09
    Public Function getListUser(ByVal IDGroup As String) As DataTable
        Return cls.getListUser(IDGroup)
    End Function
    Public Function UPDATEDB(ByVal m As Model.MSecUser) As Boolean
        Return cls.UPDATEDB(m)
    End Function
    Public Function CheckDulicate(ByVal UID As String, ByVal IDSort As Integer) As Boolean
        Return cls.CheckDulicate(UID, IDSort)
    End Function
    Public Function DeleteDB(ByVal UID As String) As Boolean
        Return cls.DeleteDB(UID)
    End Function
    Public Function ChangePWD(ByVal UID As String, ByVal PWD As String) As Boolean
        Return cls.ChangePWD(UID, PWD)
    End Function

    Public Function getInfo(ByVal UID As String) As Model.MSecUser
        Return cls.getInfo(UID)
    End Function
    'Lấy thông tin nhóm người dùng
    Public Function getListGroupUser() As DataTable
        Return cls.getListGroupUser()
    End Function
    'Lấy thông tin nhân viên
    Public Function getListEmployees() As DataTable
        Return cls.getListEmployees()
    End Function
End Class
