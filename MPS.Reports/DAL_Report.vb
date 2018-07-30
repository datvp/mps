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

    Public Function RevenueByClientGroup(ByVal dtFrom As Date, ByVal dtTo As Date) As DataTable
        Dim sql = "Exec sp_ReportRevenueByClientGroup @dtFrom,@dtTo"
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@dtFrom", dtFrom)
        p(1) = New SqlParameter("@dtTo", dtTo)
        Return getTableSQL(sql, p)
    End Function
    Public Function RevenueByProject(ByVal dtFrom As Date, ByVal dtTo As Date) As DataTable
        Dim sql = "Exec sp_ReportRevenueByProject @dtFrom,@dtTo"
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@dtFrom", dtFrom)
        p(1) = New SqlParameter("@dtTo", dtTo)
        Return getTableSQL(sql, p)
    End Function
    Public Function RevenueByItem(ByVal dtFrom As Date, ByVal dtTo As Date) As DataTable
        Dim sql = "Exec sp_ReportRevenueByItem @dtFrom,@dtTo"
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@dtFrom", dtFrom)
        p(1) = New SqlParameter("@dtTo", dtTo)
        Return getTableSQL(sql, p)
    End Function
End Class
