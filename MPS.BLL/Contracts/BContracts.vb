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
    Public Function getListContracts() As DataTable
        Return cls.getListContracts()
    End Function
    Public Function getContractDetailById(ByVal ContractId As String) As Model.MContract
        Return cls.getContractDetailById(ContractId)
    End Function
    Public Function updateStatus(ByVal contractId As String, ByVal status As String, ByVal userId As String) As Boolean
        Return cls.updateStatus(contractId, status, userId)
    End Function
End Class
