Public Class B_ConfigProgram
    Private WithEvents cls As New DAL.DAL_ConfigProgram
    Event _errorRaise(ByVal messege As String)
    Private Sub New()
    End Sub
    Private Shared obj As B_ConfigProgram
    Public Shared ReadOnly Property Instance() As B_ConfigProgram
        Get
            If obj Is Nothing Then
                obj = New B_ConfigProgram
            End If
            Return obj
        End Get
    End Property
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Public Function UPDATEDB(ByVal m As Model.MConfigProgram) As Boolean
        Return cls.UPDATEDB(m)
    End Function
    Public Function DELETEDB() As Boolean
        Return cls.DELETEDB()
    End Function
    Public Function UpdateConfigReport(ByVal tb As DataTable) As Boolean
        Return cls.UpdateConfigReport(tb)
    End Function
    Public Function GetConfigReport() As DataTable
        Return cls.GetConfigReport
    End Function
    Public Function getInfo() As Model.MConfigProgram
        Return cls.getInfo()
    End Function
   
End Class
