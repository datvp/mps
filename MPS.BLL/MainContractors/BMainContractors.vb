Public Class BMainContractors
    Private WithEvents cls As DAL.DAL_MainContractors = DAL.DAL_MainContractors.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Private Sub New()
    End Sub
    Private Shared obj As BMainContractors
    Public Shared ReadOnly Property Instance() As BMainContractors
        Get
            If obj Is Nothing Then
                obj = New BMainContractors
            End If
            Return obj
        End Get
    End Property
    Public Function isExist(ByVal ID As String) As Boolean
        Return cls.isExist(ID)
    End Function
    Public Function updateDB(ByVal m As Model.MMainContractor) As Boolean
        Return cls.updateDB(m)
    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function
    Public Function deleteDB(ByVal MainContractorId As String) As Boolean
        Return cls.deleteDB(MainContractorId)
    End Function
    Public Function getListMainContractors() As DataTable
        Return cls.getListMainContractors()
    End Function
    Public Function getMainContractorDetailById(ByVal MainContractorId As String) As Model.MMainContractor
        Return cls.getMainContractorDetailById(MainContractorId)
    End Function
End Class
