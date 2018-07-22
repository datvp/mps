Public Class BSubContractors
    Private WithEvents cls As DAL.DAL_SubContractors = DAL.DAL_SubContractors.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Private Sub New()
    End Sub
    Private Shared obj As BSubContractors
    Public Shared ReadOnly Property Instance() As BSubContractors
        Get
            If obj Is Nothing Then
                obj = New BSubContractors
            End If
            Return obj
        End Get
    End Property
    Public Function isExist(ByVal ID As String) As Boolean
        Return cls.isExist(ID)
    End Function
    Public Function updateDB(ByVal m As Model.MSubContractor) As Boolean
        Return cls.updateDB(m)
    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function
    Public Function deleteDB(ByVal SubContractorId As String) As Boolean
        Return cls.deleteDB(SubContractorId)
    End Function
    Public Function getListSubContractors() As DataTable
        Return cls.getListSubContractors()
    End Function
    Public Function getSubContractorDetailById(ByVal SubContractorId As String) As Model.MSubContractor
        Return cls.getSubContractorDetailById(SubContractorId)
    End Function
End Class
