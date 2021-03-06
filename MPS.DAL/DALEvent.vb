Imports System.Data.SqlClient
Public Class DALEvent
    Inherits DALSQL

    Private Sub New()
    End Sub
    Private Shared obj As DALEvent
    Public Shared ReadOnly Property Instance() As DALEvent
        Get
            If obj Is Nothing Then
                obj = New DALEvent
            End If
            Return obj
        End Get
    End Property

    'THÊM MỚI-HIỆU CHỈNH SỰ KIỆN**************
    Public Function UPDATEDB(ByVal m As Model.MEvent) As Boolean
        Dim p(6) As SqlParameter
        p(0) = New SqlParameter("@ID", m.ID)
        p(1) = New SqlParameter("@DayMonth", m.DayMonth)
        p(2) = New SqlParameter("@Note", m.Note)
        p(3) = New SqlParameter("@Desc", m.Desc)
        p(4) = New SqlParameter("@IDSort", m.IDSort)
        p(5) = New SqlParameter("@TypeID", m.TypeID)
        p(6) = New SqlParameter("@UID", m.UID)
        Dim sql As String = ""
        If m.ID = "" Then
            sql = "Insert into PR_EVents(s_UID,i_TypeID,s_Desc,s_Note) values(@UID,@TypeID,@Desc,@Note)"
        Else
            sql = "Update PR_EVents set s_UID=@UID,i_TypeID=@TypeID,s_Desc=@Desc,s_Note=@Note where s_ID=@ID"
        End If
        Return Me.execSQL(sql, p)
    End Function

    'XÓA SỰ KIỆN*****************
    Public Function DELETEDB(ByVal ID As String) As Boolean
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        Dim sql As String = "Exec sp_DeleteEvent @ID"
        Return Me.execSQL(sql, p)
    End Function

    'LOAD DANH SÁCH SỰ KIỆN***********
    Public Function getList(ByVal cseTime As Integer, ByVal fromDate As Date, ByVal toDate As Date) As DataTable '2.2.09-Minh Tâm
        '20.11.08
        Dim sql As String = "exec [sp_getList_Case_Event] @caseTime,@fromDate,@toDate "
        Dim p(2) As SqlParameter
        p(0) = New SqlParameter("@fromDate", fromDate)
        p(1) = New SqlParameter("@toDate", toDate)
        p(2) = New SqlParameter("@caseTime", cseTime)

        Return Me.getTableSQL(sql, p)

    End Function
    'Public Function getList(ByVal fromDate As Date, ByVal toDate As Date) As DataTable
    '    Dim p(1) As SqlParameter
    '    p(0) = New SqlParameter("@fromDate", fromDate)
    '    p(1) = New SqlParameter("@toDate", toDate)
    '    Dim sql As String = "exec sp_getListEvent @fromDate,@toDate"

    '    Return Me.getTableSQL(sql, p)
    'End Function

    'LOAD DANH SÁCH LOẠI SỰ KIỆN
    Public Function getListType() As DataTable
       
        Dim sql As String = "" ' "Exec sp_getListEventType"
        sql = "Select * from Ls_TypeEvents where i_ID not in (3,5,8,9) Order by i_ID asc"

        Dim tb As DataTable = Me.getTableSQL(sql)
        Dim drN As DataRow = tb.NewRow
        drN("i_ID") = 0
        drN("s_Name") = m_SelectAll
        drN("s_Note") = ""
        tb.Rows.InsertAt(drN, 0)
        Return tb
    End Function

    'LOAD THÔNG TIN CHI TIẾT SỰ KIỆN***********
    Public Function getInfo(ByVal ID As String) As Model.MEvent
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        Dim sql As String = "Exec sp_getInfoEvent @ID"
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        Dim m As New Model.MEvent
        If Not tb Is Nothing Then
            If tb.Rows.Count > 0 Then
                m.ID = tb.Rows(0)("i_ID")
                m.DayMonth = tb.Rows(0)("s_Name")
                m.Desc = tb.Rows(0)("s_Desc")
                m.IDSort = IsNull(tb.Rows(0)("i_IDSort"), 0)
                m.Note = IsNull(tb.Rows(0)("s_Note"), "")
                m.TypeID = IsNull(tb.Rows(0)(" i_TypeID"), 0)
                m.UID = IsNull(tb.Rows(0)(" s_UID"), "")
            End If
        End If
        Return m
    End Function
End Class
