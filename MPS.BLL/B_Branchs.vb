Public Class B_Branchs
    Private Sub New()

    End Sub
    Private Shared obj As B_Branchs
    Public Shared ReadOnly Property Instance() As B_Branchs
        Get
            If obj Is Nothing Then
                obj = New B_Branchs
            End If
            Return obj
        End Get
    End Property
    Private WithEvents cls As DAL.DALLs_Branchs = DAL.DALLs_Branchs.Instance
    Event _errorRaise(ByVal messege As String)

    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub
    Public Function UPDATEDB(ByVal m As Model.MLs_Branchs) As Boolean

        Return cls.UPDATEDB(m)

    End Function
    Public Function DELETEDB(ByVal ID As String) As Boolean
        Return cls.DELETEDB(ID)

    End Function

    Public Function getList() As DataTable
        Return cls.getList()
    End Function
    Public Function getListByRight(ByVal UID As String) As DataTable
        Return cls.getListByRight(UID)
    End Function
    ''' <summary>
    ''' lấy ds chi nhánh để thực hiện nghiệp vụ (load tại mh login)
    ''' </summary>
    ''' <param name="UID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getListByRightToExecute(ByVal UID As String) As DataTable
        Return cls.getListByRightToExecute(UID)
    End Function
    Public Function getInfo(ByVal ID As String) As Model.MLs_Branchs
        Return cls.getInfo(ID)
    End Function

    Public Function CheckDulicate(ByVal IDNew As String, ByVal s_ID As String) As Boolean
        Return cls.CheckDulicate(IDNew, s_ID)
    End Function


    'KIỂM TRA TRƯỚC KHI XÓA HÀNG HÓA*******

    Public Function isDelete(ByVal ID As String) As Boolean
        Return cls.isDelete(ID)
    End Function
    Public Function getCode(ByVal CodeID As String) As String
        Return cls.getCode(CodeID)
    End Function
End Class
