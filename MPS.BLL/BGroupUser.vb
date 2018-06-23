Public Class BGroupUser
    Private WithEvents cls As New DAL.DALLs_GroupUser
    Event _errorRaise(ByVal messege As String)

    'load danh sách nhóm người sử dụng
    Public Function Getlist() As DataTable
        Return cls.Getlist()
    End Function
    'Load số thứ tự lớn nhất
    Public Function GetMaxOrdinal() As Integer
        Return cls.GetMaxOrdinal()
    End Function
    'kiểm tra trùng mã
    Public Function CheckDulicate(ByVal idkh As String, ByVal id As String) As Boolean
        Return cls.CheckDulicate(idkh, id)
    End Function
    'kiểm tra trùng tên
    Public Function CheckDulicateName(ByVal name As String, ByVal id As String) As Boolean
        Return cls.CheckDulicateName(name, id)
    End Function
    'thêm mới - hiệu chỉnh
    Public Function UPDATEDB(ByVal m As Model.MLS_GroupUser) As Boolean
        Return cls.UPDATEDB(m)
    End Function
    'lấy thông tin nhóm người sử dụng
    Public Function getInfo(ByVal ID As String) As Model.MLS_GroupUser
        Return cls.getInfo(ID)
    End Function
    'kiểm tra xóa
    Public Function CheckDelete(ByVal ID As String) As Boolean
        Return cls.CheckDelete(ID)
    End Function
    'xóa nhóm người dùng
    Public Function DELETEDB(ByVal ID As String) As Boolean
        Return cls.DELETEDB(ID)
    End Function
End Class
