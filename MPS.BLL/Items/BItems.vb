Public Class BItems
    Private WithEvents cls As DAL.DAL_Items = DAL.DAL_Items.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    Private Sub New()
    End Sub
    Private Shared obj As BItems
    Public Shared ReadOnly Property Instance() As BItems
        Get
            If obj Is Nothing Then
                obj = New BItems
            End If
            Return obj
        End Get
    End Property
    Public Function isExist(ByVal ID As String) As Boolean
        Return cls.isExist(ID)
    End Function
    Public Function updateDB(ByVal m As Model.MItem) As Boolean
        Return cls.updateDB(m)
    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function
    Public Function deleteDB(ByVal ItemId As String) As Boolean
        Return cls.deleteDB(ItemId)
    End Function
    Public Function getItemDetailById(ByVal ItemId As String) As Model.MItem
        Return cls.getItemDetailById(ItemId)
    End Function
    Public Function getListItems() As DataTable
        Return cls.getListItems()
    End Function
End Class
