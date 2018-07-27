Public Class BProjects
    Private WithEvents cls As DAL.DAL_Projects = DAL.DAL_Projects.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Private Sub New()
    End Sub
    Private Shared obj As BProjects
    Public Shared ReadOnly Property Instance() As BProjects
        Get
            If obj Is Nothing Then
                obj = New BProjects
            End If
            Return obj
        End Get
    End Property
    Public Function isExist(ByVal ID As String) As Boolean
        Return cls.isExist(ID)
    End Function
    Public Function updateDB(ByVal m As Model.MProject) As Boolean
        Return cls.updateDB(m)
    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function
    Public Function deleteDB(ByVal ProjectId As String) As Boolean
        Return cls.deleteDB(ProjectId)
    End Function
    Public Function getListProjects(ByVal branchId As String) As DataTable
        Return cls.getListProjects(branchId)
    End Function
    Public Function getProjectDetailById(ByVal ProjectId As String) As Model.MProject
        Return cls.getProjectDetailById(ProjectId)
    End Function
    Public Function getListProjectGroups() As DataTable
        Return cls.getListProjectGroups()
    End Function
    Public Function getListProjectTypes() As DataTable
        Return cls.getListProjectTypes()
    End Function
    Public Function getListConstructionLevels() As DataTable
        Return cls.getListConstructionLevels()
    End Function
    Public Function getListPerformanceUnit() As DataTable
        Return cls.getListPerformanceUnit()
    End Function
    Public Function getListLengthUnit() As DataTable
        Return cls.getListLengthUnit()
    End Function
End Class
