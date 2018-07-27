Public Class BFuncRight
    Private WithEvents cls As DAL.DALFuncRight = DAL.DALFuncRight.Instance
    Event _errorRaise(ByVal messege As String)

    Private Sub New()
    End Sub
    Private Shared obj As BFuncRight
    Public Shared ReadOnly Property Instance() As BFuncRight
        Get
            If obj Is Nothing Then
                obj = New BFuncRight
            End If
            Return obj
        End Get
    End Property

    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub
    Public Function getListCounter(ByVal UID As String) As DataTable
        Return cls.getListCounter(UID)
    End Function
    'THÊM MỚI-HIỆU CHỈNH CẤP QUYỀN THEO CHỨC NĂNG NGHIỆP VỤ***********
    Public Function UPDATEDB(ByVal m As Model.MFuncRight) As Boolean
        Return cls.UPDATEDB(m)
    End Function

    'LOAD THÔNG TIN CHI TIẾT CẤP QUYỀN THEO NGƯỜI DÙNG***********
    Public Function getFuncRight(ByVal UID As String) As DataSet
        Return cls.getFuncRight(UID)
    End Function

    'LOAD THÔNG TIN CHI TIẾT CẤP QUYỀN THEO NGƯỜI DÙNG PHAN BIET SMS ***********
    Public Function getFuncRight(ByVal UID As String, ByVal isSMS As Boolean) As DataSet
        Return cls.getFuncRight(UID, isSMS)
    End Function

    Public Function DeleteDB(ByVal UID As String) As Boolean
        Return cls.DeleteDB(UID)
    End Function
    Public Function getFuncRight(ByVal UID As String, ByVal FuncID As Double) As DataTable
        Return cls.getFuncRight(UID, FuncID)
    End Function
    Public Function getFuncRightStore(ByVal UID As String, ByVal Store_ID As String) As DataTable
        Return cls.getFuncRightStore(UID, Store_ID)
    End Function
    Public Function getStoreOfUser(ByVal UID As String) As DataTable
        Return cls.getStoreOfUser(UID)
    End Function
    '25/01/2010 mac dinh set phan quyen cac kho =True cho tat ca user
    Public Function SetFuncStore(ByVal User As String) As Boolean
        Return cls.SetFuncStore(User)
    End Function
    Public Function SetFuncBranch(ByVal User As String) As Boolean
        Return cls.SetFuncBranch(User)
    End Function
End Class
