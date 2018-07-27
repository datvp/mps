Public Class B_Report
    Private WithEvents cls As Reports.DAL_Report = Reports.DAL_Report.Instance
    Event _errorRaise(ByVal messege As String)

    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Private Sub New()
    End Sub
    Private Shared obj As B_Report
    Public Shared ReadOnly Property Instance() As B_Report
        Get
            If obj Is Nothing Then
                obj = New B_Report
            End If
            Return obj
        End Get
    End Property
End Class
