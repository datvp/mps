Public Class BEmployees
    Private WithEvents cls As New DAL.DALLS_Employees
    Event _errorRaise(ByVal messege As String)
    Private Sub New()
    End Sub
    Private Shared obj As BEmployees
    Public Shared ReadOnly Property Instance() As BEmployees
        Get
            If obj Is Nothing Then
                obj = New BEmployees
            End If
            Return obj
        End Get
    End Property
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub
    Public Function UPDATEDB_HQ(ByVal m As Model.MLS_Employees, ByVal isUpdateCodeSystem As Boolean) As Boolean
        Return cls.UPDATEDB_HQ(m, isUpdateCodeSystem)
    End Function
    Public Function UPDATEDB(ByVal m As Model.MLS_Employees) As Boolean
        Return cls.UPDATEDB(m)
    End Function
    Public Function CheckDulicate(ByVal ID As String, ByVal s_ID As String) As Boolean
        Return cls.CheckDulicate(ID, s_ID)

    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function

    Public Function DELETEDB(ByVal ID As String) As Boolean
        Return cls.DELETEDB(ID)
    End Function

    Public Function getList() As DataTable
        Return cls.getList
    End Function
    Public Function getItemUpload(ByVal ID As String) As DataTable
        Return cls.getItemUpload(ID)
    End Function

    Public Function getList(ByVal dayMonth As Date) As DataTable
        Return cls.getList(dayMonth)
    End Function
    Public Function getListReferrer(ByVal empId As String) As DataTable
        Return cls.getListReferrer(empId)
    End Function
    Public Function getListCTV(ByVal empId As String) As DataTable
        Return cls.getListCTV(empId)
    End Function
    Public Function getInfo(ByVal ID As String) As Model.MLS_Employees
        Return cls.getInfo(ID)
    End Function

    'LẤY MÃ HÀNG THEO ĐIỀU KIỆN DUYỆT: ĐẦU, CUỐI, TRƯỚC ĐÓ, KẾ TIẾP
    Public Function getIDItem(ByVal IDSort As Double, ByVal nCase As Integer) As String
        Return cls.getIDItem(IDSort, nCase)
    End Function
    Public Function getCode(ByVal CodeID As String) As String
        Return cls.getCode(CodeID)
    End Function
    '05/09/09 kiem tra neu nhan vien con phu trach khach hang thi kh cho nghi viec
    Public Function CheckHoliday(ByVal s_ID As String) As Boolean
        Return cls.CheckHoliday(s_ID)
    End Function

#Region "TASK RELATION-27.08.2010"
    Public Function getListEmpforTask() As DataTable
        'load danh sach nhan vien bo sung chuc nang them moi
        'vi tri su dung: cac danh muc, nghiep vu co lien quan
        Dim tb As DataTable = cls.getList

        Return tb
    End Function

#End Region

    Public Function countItem() As Integer
        Return cls.countItem
    End Function
End Class