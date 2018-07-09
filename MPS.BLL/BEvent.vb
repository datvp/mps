Public Class BEvent
    Private Sub New()
    End Sub
    Private Shared obj As BEvent
    Public Shared ReadOnly Property Instance() As BEvent
        Get
            If obj Is Nothing Then
                obj = New BEvent
            End If
            Return obj
        End Get
    End Property

    Private WithEvents cls As DAL.DALEvent = DAL.DALEvent.Instance
    Event _errorRaise(ByVal messege As String)

    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub

    'THÊM MỚI-HIỆU CHỈNH SỰ KIỆN**************
    Public Function UPDATEDB(ByVal UID As String, ByVal Desc As String, ByVal IDType As Integer) As Boolean
        Dim m As New Model.MEvent
        m.UID = UID
        m.Desc = Desc
        m.TypeID = IDType
        Return cls.UPDATEDB(m)
    End Function

    'XÓA SỰ KIỆN*****************
    Public Function DELETEDB(ByVal ID As String) As Boolean
        Return cls.DELETEDB(ID)
    End Function

    'LOAD DANH SÁCH SỰ KIỆN***********
    Public Function getList(ByVal cseTime As Integer, ByVal fromDate As Date, ByVal toDate As Date) As DataTable
        Return cls.getList(cseTime, fromDate, toDate)
    End Function

    'LOAD THÔNG TIN CHI TIẾT SỰ KIỆN***********
    Public Function getInfo(ByVal ID As String) As Model.MEvent
        Return cls.getInfo(ID)
    End Function

    'LOAD DANH SÁCH LOẠI SỰ KIỆN
    Public Function getListType() As DataTable
        Return cls.getListType
    End Function
End Class
