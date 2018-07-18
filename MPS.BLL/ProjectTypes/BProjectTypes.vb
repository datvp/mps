Public Class BProjectTypes
    Private WithEvents cls As DAL.DAL_ProjectTypes = DAL.DAL_ProjectTypes.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Private Sub New()
    End Sub
    Private Shared obj As BProjectTypes
    Public Shared ReadOnly Property Instance() As BProjectTypes
        Get
            If obj Is Nothing Then
                obj = New BProjectTypes
            End If
            Return obj
        End Get
    End Property
    Public Function isExist(ByVal ID As String) As Boolean
        Return cls.isExist(ID)
    End Function
    Public Function updateDB(ByVal m As Model.MProjectType) As Boolean
        Return cls.updateDB(m)
    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function
    Public Function deleteDB(ByVal ProjectTypeId As String) As Boolean
        Return cls.deleteDB(ProjectTypeId)
    End Function
    Public Function getProjectTypeDetailById(ByVal ProjectTypeId As String) As Model.MProjectType
        Return cls.getProjectTypeDetailById(ProjectTypeId)
    End Function
    Public Function getListProjectTypes() As DataTable
        Return cls.getListProjectTypes()
    End Function
End Class
