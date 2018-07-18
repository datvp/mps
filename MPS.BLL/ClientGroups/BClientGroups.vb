Public Class BClientGroups
    Private WithEvents cls As DAL.DAL_ClientGroups = DAL.DAL_ClientGroups.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Private Sub New()
    End Sub
    Private Shared obj As BClientGroups
    Public Shared ReadOnly Property Instance() As BClientGroups
        Get
            If obj Is Nothing Then
                obj = New BClientGroups
            End If
            Return obj
        End Get
    End Property
    Public Function isExist(ByVal ID As String) As Boolean
        Return cls.isExist(ID)
    End Function
    Public Function updateDB(ByVal m As Model.MClientGroup) As Boolean
        Return cls.updateDB(m)
    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function
    Public Function deleteDB(ByVal ClientGroupId As String) As Boolean
        Return cls.deleteDB(ClientGroupId)
    End Function
    Public Function getClientGroupDetailById(ByVal ClientGroupId As String) As Model.MClientGroup
        Return cls.getClientGroupDetailById(ClientGroupId)
    End Function
    Public Function getListClientGroups() As DataTable
        Return cls.getListClientGroups()
    End Function
End Class
