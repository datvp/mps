Public Class BClients
    Private WithEvents cls As DAL.DAL_Clients = DAL.DAL_Clients.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Private Sub New()
    End Sub
    Private Shared obj As BClients
    Public Shared ReadOnly Property Instance() As BClients
        Get
            If obj Is Nothing Then
                obj = New BClients
            End If
            Return obj
        End Get
    End Property
    Public Function isExist(ByVal ID As String) As Boolean
        Return cls.isExist(ID)
    End Function
    Public Function updateDB(ByVal m As Model.MClient) As Boolean
        Return cls.updateDB(m)
    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function
    Public Function deleteDB(ByVal ClientId As String) As Boolean
        Return cls.deleteDB(ClientId)
    End Function
    Public Function getListClients() As DataTable
        Return cls.getListClients()
    End Function
    Public Function getClientDetailById(ByVal ClientId As String) As Model.MClient
        Return cls.getClientDetailById(ClientId)
    End Function
    Public Function getListClientGroups() As DataTable
        Return cls.getListClientGroups()
    End Function
End Class
