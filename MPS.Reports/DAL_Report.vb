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
    Public Function ReportByDate(ByVal dtFrom As Date, ByVal dtTo As Date) As Boolean
        If Not execSQL("Delete from ReportTemp") Then
            Return False
        End If
        Dim sql = "Exec sp_ReportByDate @dtFrom,@dtTo"
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@dtFrom", dtFrom)
        p(1) = New SqlParameter("@dtTo", dtTo)
        Dim tb = getTableSQL(sql, p)
        If Not IsNothing(tb) Then
            sql = "Insert into ReportTemp(ProjectName,ContractName,Note,Thu,Chi,DKThu,DKChi)"
            sql += "values(@ProjectName,@ContractName,@Note,@Thu,@Chi,@DKThu,@DKChi)"
            For Each r As DataRow In tb.Rows
                Dim pm(6) As SqlParameter
                pm(0) = New SqlParameter("@ProjectName", r("ProjectName"))
                pm(1) = New SqlParameter("@ContractName", r("ContractName"))
                pm(2) = New SqlParameter("@Note", r("Note"))
                pm(3) = New SqlParameter("@Thu", CDbl(r("Thu")))
                pm(4) = New SqlParameter("@Chi", CDbl(r("Chi")))
                pm(5) = New SqlParameter("@DKThu", CDbl(r("DuKienThu")))
                pm(6) = New SqlParameter("@DKChi", CDbl(r("DuKienChi")))
                If Not Me.execSQL(sql, pm) Then
                    Return False
                End If
            Next
        End If
        Return True
    End Function
    ''' <summary>
    ''' tổng số nhà thầu phụ đang được thuê
    ''' </summary>
    ''' <param name="dtFrom"></param>
    ''' <param name="dtTo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReportSubContractorsByAssigned(ByVal dtFrom As Date, ByVal dtTo As Date) As DataTable
        Dim sql = "Exec sp_ReportSubContractorsByAssigned @dtFrom,@dtTo"
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@dtFrom", dtFrom)
        p(1) = New SqlParameter("@dtTo", dtTo)
        Return getTableSQL(sql, p)
    End Function

    ''' <summary>
    ''' Số lượng dự án mà 01 nhà thầu phụ đang thực hiện
    ''' </summary>
    ''' <param name="SubContractorId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReportContractsBySubContractorId(ByVal SubContractorId As String) As DataTable
        Dim sql = "Exec sp_ReportContractsBySubContractorId @SubContractorId"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@SubContractorId", SubContractorId)
        Return getTableSQL(sql, p)
    End Function

    ''' <summary>
    ''' báo cáo tình trạng nhiều hợp đồng
    ''' </summary>
    ''' <param name="dtFrom"></param>
    ''' <param name="dtTo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReportStatusOfContracts(ByVal dtFrom As Date, ByVal dtTo As Date) As DataTable
        Dim sql = "Exec sp_ReportStatusOfContracts @dtFrom,@dtTo"
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@dtFrom", dtFrom)
        p(1) = New SqlParameter("@dtTo", dtTo)
        Return getTableSQL(sql, p)
    End Function
End Class
