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

    Public Function RevenueByClientGroup(ByVal dtFrom As Date, ByVal dtTo As Date) As DataTable
        Return cls.RevenueByClientGroup(dtFrom, dtTo)
    End Function
    Public Function RevenueByProject(ByVal dtFrom As Date, ByVal dtTo As Date) As DataTable
        Return cls.RevenueByProject(dtFrom, dtTo)
    End Function
    Public Function RevenueByItem(ByVal dtFrom As Date, ByVal dtTo As Date) As DataTable
        Return cls.RevenueByItem(dtFrom, dtTo)
    End Function
    Public Function ReportByDate(ByVal dtFrom As Date, ByVal dtTo As Date) As Boolean
        Return cls.ReportByDate(dtFrom, dtTo)
    End Function
    ''' <summary>
    ''' tổng số nhà thầu phụ đang được thuê
    ''' </summary>
    ''' <param name="dtFrom"></param>
    ''' <param name="dtTo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReportSubContractorsByAssigned(ByVal dtFrom As Date, ByVal dtTo As Date) As DataTable
        Return cls.ReportSubContractorsByAssigned(dtFrom, dtTo)
    End Function
    ''' <summary>
    ''' Số lượng dự án mà 01 nhà thầu phụ đang thực hiện
    ''' </summary>
    ''' <param name="SubContractorId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReportContractsBySubContractorId(ByVal SubContractorId As String) As DataTable
        Return cls.ReportContractsBySubContractorId(SubContractorId)
    End Function

    ''' <summary>
    ''' báo cáo tình trạng nhiều hợp đồng
    ''' </summary>
    ''' <param name="dtFrom"></param>
    ''' <param name="dtTo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReportStatusOfContracts(ByVal dtFrom As Date, ByVal dtTo As Date) As DataTable
        Return cls.ReportStatusOfContracts(dtFrom, dtTo)
    End Function
End Class
