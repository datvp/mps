Public Class BPublic
    Private WithEvents cls As DAL.DAL_Public = DAL.DAL_Public.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub New()
    End Sub
    Private Shared obj As BPublic
    Public Shared ReadOnly Property Instance() As BPublic
        Get
            If obj Is Nothing Then
                obj = New BPublic
            End If
            Return obj
        End Get
    End Property
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub
    Public Function getServerDate() As Date
        Return cls.getServerDate
    End Function

    Public Function getChart_TotalSale(ByVal thang As Date) As DataTable
        Return cls.getChart_TotalSale(thang)
    End Function
    ''' <summary>
    ''' doanh số theo trạng thái hợp đồng
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getChart_StateSale() As DataTable
        Return cls.getChart_StateSale()
    End Function

    ''' <summary>
    ''' tổng hợp các hợp đồng sắp hết hạn
    ''' </summary>
    ''' <param name="deadline">số ngày hết hạn so với ngày hiện tại</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getListDeadlineContracts(ByVal deadline As Integer) As DataTable
        Return cls.getListDeadlineContracts(deadline)
    End Function
    Public Function getChartByProject() As DataTable
        Return cls.getChartByProject()
    End Function

    Public Function getListReports() As DataTable
        Return cls.getListReports()
    End Function
End Class
