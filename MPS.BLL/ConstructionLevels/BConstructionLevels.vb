Public Class BConstructionLevels
    Private WithEvents cls As DAL.DAL_ConstructionLevels = DAL.DAL_ConstructionLevels.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Private Sub New()
    End Sub
    Private Shared obj As BConstructionLevels
    Public Shared ReadOnly Property Instance() As BConstructionLevels
        Get
            If obj Is Nothing Then
                obj = New BConstructionLevels
            End If
            Return obj
        End Get
    End Property
    Public Function isExist(ByVal ID As String) As Boolean
        Return cls.isExist(ID)
    End Function
    Public Function updateDB(ByVal m As Model.MConstructionLevel) As Boolean
        Return cls.updateDB(m)
    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function
    Public Function deleteDB(ByVal ConstructionLevelId As String) As Boolean
        Return cls.deleteDB(ConstructionLevelId)
    End Function
    Public Function getConstructionLevelDetailById(ByVal ConstructionLevelId As String) As Model.MConstructionLevel
        Return cls.getConstructionLevelDetailById(ConstructionLevelId)
    End Function
    Public Function getListConstructionLevels() As DataTable
        Return cls.getListConstructionLevels()
    End Function
End Class
