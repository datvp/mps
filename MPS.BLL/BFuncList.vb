Public Class BFuncList

    Private WithEvents cls As New DAL.DALFuncList
    Event _errorRaise(ByVal messege As String)

    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    'THÊM MỚI, HIỆU CHỈNH CHỨC NĂNG NGHIỆP VỤ**********
    Public Function UPDATEDB(ByVal m As Model.MFuncList, ByVal isUpdate As Boolean) As Boolean
        Return cls.UPDATEDB(m, isUpdate)
    End Function

    'XÓA CHỨC NĂNG NGHIỆP VỤ***********
    Public Function DELETEDB(ByVal ID As Integer) As Boolean
        Return cls.DELETEDB(ID)
    End Function

    'LOAD DANH SÁCH CHỨC NĂNG*****************
    Public Function getList(ByVal nCase As Integer) As DataTable
        Return cls.getList(nCase)
    End Function

    'LOAD DANH SACH CHỨC NĂNG CÓ RELATION**************
    Public Function getList() As DataSet
        Return cls.getList()
    End Function

    'LẤY THÔNG TIN CHI TIẾT CHỨC NĂNG************
    Public Function getInfo(ByVal ID As Integer) As Model.MFuncList
        Return cls.getInfo(ID)
    End Function

    Public Function CheckDul(ByVal ID As Double) As Boolean
        Return cls.CheckDul(ID)
    End Function

    Public Function getNextID() As Double
        Return cls.getNextID
    End Function

End Class
