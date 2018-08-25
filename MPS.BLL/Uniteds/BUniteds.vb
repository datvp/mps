Public Class BUniteds
    Private WithEvents cls As DAL.DAL_Uniteds = DAL.DAL_Uniteds.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Private Sub New()
    End Sub
    Private Shared obj As BUniteds
    Public Shared ReadOnly Property Instance() As BUniteds
        Get
            If obj Is Nothing Then
                obj = New BUniteds
            End If
            Return obj
        End Get
    End Property
    Public Function isExist(ByVal ID As String) As Boolean
        Return cls.isExist(ID)
    End Function
    Public Function updateDB(ByVal m As Model.MUnited) As Boolean
        Return cls.updateDB(m)
    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function
    Public Function deleteDB(ByVal UnitedId As String) As Boolean
        Return cls.deleteDB(UnitedId)
    End Function
    Public Function getListUniteds() As DataTable
        Return cls.getListUniteds()
    End Function
    Public Function getUnitedDetailById(ByVal UnitedId As String) As Model.MUnited
        Return cls.getUnitedDetailById(UnitedId)
    End Function
End Class
