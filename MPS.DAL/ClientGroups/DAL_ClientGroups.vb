Imports System.Data.SqlClient
Public Class DAL_ClientGroups
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_ClientGroups
    Public Shared ReadOnly Property Instance() As DAL_ClientGroups
        Get
            If obj Is Nothing Then
                obj = New DAL_ClientGroups
            End If
            Return obj
        End Get
    End Property

    Public Function isExist(ByVal ID As String) As Boolean
        Dim sql = "Select ClientGroupId from ClientGroups where ClientGroupId=@ID"
        Dim tb = getTableSQL(sql, New SqlParameter("@ID", ID))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function updateDB(ByVal m As Model.MClientGroup) As Boolean
        Dim sql = ""

        If isExist(m.ClientGroupId) Then
            sql = "Update ClientGroups set ClientGroupName=@ClientGroupName,Note=@Note,UpdatedAt=getdate()"
            sql += " where ClientGroupId=@ClientGroupId"
        Else
            sql = "Insert into ClientGroups(ClientGroupId,ClientGroupName,Note,CreatedAt)"
            sql += "values(@ClientGroupId,@ClientGroupName,@Note,getdate())"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(2) As SqlParameter
        p(0) = New SqlParameter("@ClientGroupId", m.ClientGroupId)
        p(1) = New SqlParameter("@ClientGroupName", m.ClientGroupName)
        p(2) = New SqlParameter("@Note", m.Note)
        Return execSQL(sql, p)
    End Function

    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk = True
        Dim sql = "select count(*)as C from Clients where ClientGroupId=@ClientGroupId"

        Dim tb = Me.getTableSQL(sql, New SqlParameter("@ClientGroupId", ID))
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

    Public Function deleteDB(ByVal ClientGroupId As String) As Boolean
        If Not isDelete(ClientGroupId) Then
            Return False
        End If
        Dim sql = "Delete from ClientGroups where ClientGroupId=@ClientGroupId"
        Return Me.execSQL(sql, New SqlParameter("@ClientGroupId", ClientGroupId))
    End Function

    Public Function getListClientGroups() As DataTable
        Dim sql As String = "Select * from ClientGroups order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function

    Public Function getClientGroupDetailById(ByVal ClientGroupId As String) As Model.MClientGroup
        Dim m As New Model.MClientGroup
        Dim sql = "select * from ClientGroups where ClientGroupId=@ClientGroupId"
        Dim tb = getTableSQL(sql, New SqlParameter("@ClientGroupId", ClientGroupId))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.ClientGroupId = IsNull(tb.Rows(0)("ClientGroupId"), "")
            m.ClientGroupName = IsNull(tb.Rows(0)("ClientGroupName"), "")
            m.Note = IsNull(tb.Rows(0)("Note"), "")
        End If
        Return m
    End Function
End Class
