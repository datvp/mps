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

    Public Function getChartByItem() As DataTable
        Return cls.getChartByItem()
    End Function
  
    Public Function getChartByClientGroup() As DataTable
        Return cls.getChartByClientGroup()
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
    Public Function getListRevenueByYear() As DataTable
        Return cls.getListRevenueByYear()
    End Function
End Class
