Imports System.Data.SqlClient
Public Class DAL_ConstructionLevels
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_ConstructionLevels
    Public Shared ReadOnly Property Instance() As DAL_ConstructionLevels
        Get
            If obj Is Nothing Then
                obj = New DAL_ConstructionLevels
            End If
            Return obj
        End Get
    End Property

    Public Function isExist(ByVal ID As String) As Boolean
        Dim sql = "Select ConstructionLevelId from ConstructionLevels where ConstructionLevelId=@ID"
        Dim tb = getTableSQL(sql, New SqlParameter("@ID", ID))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function updateDB(ByVal m As Model.MConstructionLevel) As Boolean
        Dim sql = ""

        If isExist(m.ConstructionLevelId) Then
            sql = "Update ConstructionLevels set ConstructionLevelName=@ConstructionLevelName,Note=@Note,UpdatedAt=getdate()"
            sql += " where ConstructionLevelId=@ConstructionLevelId"
        Else
            sql = "Insert into ConstructionLevels(ConstructionLevelId,ConstructionLevelName,Note,CreatedAt)"
            sql += "values(@ConstructionLevelId,@ConstructionLevelName,@Note,getdate())"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(2) As SqlParameter
        p(0) = New SqlParameter("@ConstructionLevelId", m.ConstructionLevelId)
        p(1) = New SqlParameter("@ConstructionLevelName", m.ConstructionLevelName)
        p(2) = New SqlParameter("@Note", m.Note)
        Return execSQL(sql, p)
    End Function

    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk = True
        Dim sql = "select count(*)as C from Projects where ConstructionLevelId=@ConstructionLevelId"

        Dim tb = Me.getTableSQL(sql, New SqlParameter("@ConstructionLevelId", ID))
        If tb IsNot Nothing Then
            For Each r As DataRow In tb.Rows
                If r("C") > 0 Then
                    isOk = False
                    Exit For
                End If
            Next
        End If

        Return isOk
    End Function

    Public Function deleteDB(ByVal ConstructionLevelId As String) As Boolean
        If Not isDelete(ConstructionLevelId) Then
            Return False
        End If
        Dim sql = "Delete from ConstructionLevels where ConstructionLevelId=@ConstructionLevelId"
        Return Me.execSQL(sql, New SqlParameter("@ConstructionLevelId", ConstructionLevelId))
    End Function

    Public Function getListConstructionLevels() As DataTable
        Dim sql As String = "Select * from ConstructionLevels order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function

    Public Function getConstructionLevelDetailById(ByVal ConstructionLevelId As String) As Model.MConstructionLevel
        Dim m As New Model.MConstructionLevel
        Dim sql = "select * from ConstructionLevels where ConstructionLevelId=@ConstructionLevelId"
        Dim tb = getTableSQL(sql, New SqlParameter("@ConstructionLevelId", ConstructionLevelId))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.ConstructionLevelId = IsNull(tb.Rows(0)("ConstructionLevelId"), "")
            m.ConstructionLevelName = IsNull(tb.Rows(0)("ConstructionLevelName"), "")
            m.Note = IsNull(tb.Rows(0)("Note"), "")
        End If
        Return m
    End Function
End Class
