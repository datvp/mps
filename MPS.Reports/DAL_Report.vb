Imports System.Data.SqlClient
Imports MPS.DAL
Public Class DAL_Report
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_Report
    Public Shared ReadOnly Property Instance() As DAL_Report
        Get
            If obj Is Nothing Then
                obj = New DAL_Report
            End If
            Return obj
        End Get
    End Property
End Class
