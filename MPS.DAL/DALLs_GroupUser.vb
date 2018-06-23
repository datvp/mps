Imports System.Data.SqlClient
Public Class DALLs_GroupUser
    Inherits DALSQL
    'load danh sách nhóm người sử dụng
    Public Function Getlist() As DataTable
        Dim sql As String = "exec sp_getList_GroupUser"
        Return Me.getTableSQL(sql)
    End Function
    'Load số thứ tự lớn nhất
    Public Function GetMaxOrdinal() As Integer
        Dim Ordinal As Integer = 0
        Dim ds As New DataTable
        Dim sql As String
        sql = "select max(i_Ordinal) as i_Ordinal from Ls_GroupUser"
        ds = Me.getTableSQL(sql)
        If Not ds Is Nothing Then
            If ds.Rows.Count > 0 Then
                Ordinal = IsNull(ds.Rows(0)("i_Ordinal"), 0)
            End If
        End If
        Return Ordinal
    End Function
    'kiểm tra trùng mã
    Public Function CheckDulicate(ByVal idkh As String, ByVal id As String) As Boolean
        Dim sql As String = "Exec sp_CheckDulicate_GroupUser @idkh,@id"

        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@idkh", idkh)
        p(1) = New SqlParameter("@id", id)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb Is Nothing Then Return False
        If tb.Rows(0)("c") > 0 Then
            Return True
        End If
    End Function
    'kiểm tra trùng tên
    Public Function CheckDulicateName(ByVal name As String, ByVal id As String) As Boolean
        Dim sql As String = "Exec sp_CheckDulicate_GroupUserName @name,@id"

        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@name", name)
        p(1) = New SqlParameter("@id", id)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb Is Nothing Then Return False
        If tb.Rows(0)("c") > 0 Then
            Return True
        End If
    End Function
    'thêm mới - hiệu chỉnh
    Public Function UPDATEDB(ByVal m As Model.MLS_GroupUser) As Boolean
        Try
            Dim sql As String
            sql = "exec Insert_Update_LS_GroupUser @id,@idkh,@name,@note,@orderno"
            Dim p(4) As SqlParameter
            p(0) = New SqlParameter("@id", m.s_ID)
            p(1) = New SqlParameter("@idkh", m.s_Group_ID)
            p(2) = New SqlParameter("@name", m.s_Group_Name)
            p(3) = New SqlParameter("@note", m.s_note)
            p(4) = New SqlParameter("@orderno", m.i_Ordinal)
            Me.getTableSQL(sql, p)
            Return True
        Catch
            Return False
        End Try
    End Function
    'lấy thông tin nhóm người sử dụng
    Public Function getInfo(ByVal ID As String) As Model.MLS_GroupUser
        Dim m As New Model.MLS_GroupUser
        Dim sql As String
        sql = "Exec sp_getInfo_GroupUser @s_ID"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@s_ID", ID)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If Not tb Is Nothing Then
            If tb.Rows.Count > 0 Then
                m.s_ID = IsNull(tb.Rows(0)("s_ID"), "")
                m.s_Group_ID = IsNull(tb.Rows(0)("s_Group_ID"), "")
                m.s_Group_Name = IsNull(tb.Rows(0)("s_Group_Name"), "")
                m.s_Note = IsNull(tb.Rows(0)("s_Note"), "")
                m.i_Ordinal = IsNull(tb.Rows(0)("i_Ordinal"), 0)
            End If
        End If
        Return m
    End Function
    'kiểm tra xóa
    Public Function CheckDelete(ByVal ID As String) As Boolean
        Dim sql As String = "Exec sp_CheckDelete_GroupUser @ID"

        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb Is Nothing Then Return False
        For Each dr As DataRow In tb.Rows
            If dr("c") > 0 Then
                Return True
            Else
                Return False
            End If
        Next
    End Function
    'xóa nhóm người dùng
    Public Function DELETEDB(ByVal ID As String) As Boolean

        Dim sql As String = "Exec sp_Delete_GroupUser @ID"

        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        Return Me.execSQL(sql, p)

    End Function
End Class
