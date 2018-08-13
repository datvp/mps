Public Class BContracts
    Private WithEvents cls As DAL.DAL_Contracts = DAL.DAL_Contracts.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Private Sub New()
    End Sub
    Private Shared obj As BContracts
    Public Shared ReadOnly Property Instance() As BContracts
        Get
            If obj Is Nothing Then
                obj = New BContracts
            End If
            Return obj
        End Get
    End Property
    Public Function isExist(ByVal ID As String) As Boolean
        Return cls.isExist(ID)
    End Function
    Public Function updateDB(ByVal m As Model.MContract) As Boolean
        Return cls.updateDB(m)
    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function
    Public Function deleteDB(ByVal ContractId As String) As Boolean
        Return cls.deleteDB(ContractId)
    End Function
    Public Function getListContracts(ByVal branchId As String, ByVal dateFilter As Integer) As DataTable
        Return cls.getListContracts(branchId, dateFilter)
    End Function
    Public Function getListAllContractId(ByVal branchId As String) As DataTable
        Return cls.getListAllContractId(branchId)
    End Function
    Public Function getListContractsByFilter(ByVal branchId As String, ByVal perform As Integer, ByVal operatorPerform As String, ByVal length As Integer, ByVal operatorLength As String) As DataTable
        Return cls.getListContractsByFilter(branchId, perform, operatorPerform, length, operatorLength)
    End Function
    Public Function getContractDetailById(ByVal ContractId As String) As Model.MContract
        Return cls.getContractDetailById(ContractId)
    End Function
    Public Function updateStatus(ByVal contractId As String, ByVal status As String, ByVal userId As String) As Boolean
        Return cls.updateStatus(contractId, status, userId)
    End Function

#Region "get details"
    ''' <summary>
    ''' get ds các hạng mục công việc
    ''' </summary>
    ''' <param name="contractId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getContractDetails(ByVal contractId As String) As IList(Of Model.MContractDetail)
        Return cls.getContractDetails(contractId)
    End Function
    ''' <summary>
    ''' get ds nhà thầu phụ
    ''' </summary>
    ''' <param name="contractId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSubContractors(ByVal contractId As String) As IList(Of Model.MContract_SubContractor)
        Return cls.getSubContractors(contractId)
    End Function
    ''' <summary>
    ''' get ds phụ lục hợp đồng
    ''' </summary>
    ''' <param name="contractId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSubContracts(ByVal contractId As String) As IList(Of Model.MSubContract)
        Return cls.getSubContracts(contractId)
    End Function
    ''' <summary>
    ''' get ds file đính kèm
    ''' </summary>
    ''' <param name="contractId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getAttachFiles(ByVal contractId As String) As IList(Of Model.MAttachFileContract)
        Return cls.getAttachFiles(contractId)
    End Function
    ''' <summary>
    ''' get ds nghiệm thu
    ''' </summary>
    ''' <param name="contractId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getContractPayments(ByVal contractId As String) As IList(Of Model.MContractPayment)
        Return cls.getContractPayments(contractId)
    End Function
    ''' <summary>
    ''' get ds các khoản chi
    ''' </summary>
    ''' <param name="contractId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getContractRefunds(ByVal contractId As String) As IList(Of Model.MContractRefund)
        Return cls.getContractRefunds(contractId)
    End Function
    ''' <summary>
    ''' get ds chi tiết các hạng mục nghiệm thu
    ''' </summary>
    ''' <param name="contractId"></param>
    ''' <param name="paymentId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getContractPaymentDetails(ByVal contractId As String, ByVal paymentId As String) As IList(Of Model.MContractPaymentDetail)
        Return cls.getContractPaymentDetails(contractId, paymentId)
    End Function
#End Region
End Class
