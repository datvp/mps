Imports System.Data.SqlClient
Public Class DAL_ProjectTypes
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_ProjectTypes
    Public Shared ReadOnly Property Instance() As DAL_ProjectTypes
        Get
            If obj Is Nothing Then
                obj = New DAL_ProjectTypes
            End If
            Return obj
        End Get
    End Property

    Public Function isExist(ByVal ID As String) As Boolean
        Dim sql = "Select ProjectTypeId from ProjectTypes where ProjectTypeId=@ID"
        Dim tb = getTableSQL(sql, New SqlParameter("@ID", ID))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function updateDB(ByVal m As Model.MProjectType) As Boolean
        Dim sql = ""

        If isExist(m.ProjectTypeId) Then
            sql = "Update ProjectTypes set ProjectTypeName=@ProjectTypeName,Note=@Note,UpdatedAt=getdate()"
            sql += " where ProjectTypeId=@ProjectTypeId"
        Else
            sql = "Insert into ProjectTypes(ProjectTypeId,ProjectTypeName,Note,CreatedAt)"
            sql += "values(@ProjectTypeId,@ProjectTypeName,@Note,getdate())"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(2) As SqlParameter
        p(0) = New SqlParameter("@ProjectTypeId", m.ProjectTypeId)
        p(1) = New SqlParameter("@ProjectTypeName", m.ProjectTypeName)
        p(2) = New SqlParameter("@Note", m.Note)
        Return execSQL(sql, p)
    End Function

    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk = True
        Dim sql = "select count(*)as C from Projects where ProjectTypeId=@ProjectTypeId"

        Dim tb = Me.getTableSQL(sql, New SqlParameter("@ProjectTypeId", ID))
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

    Public Function deleteDB(ByVal ProjectTypeId As String) As Boolean
        If Not isDelete(ProjectTypeId) Then
            Return False
        End If
        Dim sql = "Delete from ProjectTypes where ProjectTypeId=@ProjectTypeId"
        Return Me.execSQL(sql, New SqlParameter("@ProjectTypeId", ProjectTypeId))
    End Function

    Public Function getListProjectTypes() As DataTable
        Dim sql As String = "Select * from ProjectTypes order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function

    Public Function getProjectTypeDetailById(ByVal ProjectTypeId As String) As Model.MProjectType
        Dim m As New Model.MProjectType
        Dim sql = "select * from ProjectTypes where ProjectTypeId=@ProjectTypeId"
        Dim tb = getTableSQL(sql, New SqlParameter("@ProjectTypeId", ProjectTypeId))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.ProjectTypeId = IsNull(tb.Rows(0)("ProjectTypeId"), "")
            m.ProjectTypeName = IsNull(tb.Rows(0)("ProjectTypeName"), "")
            m.Note = IsNull(tb.Rows(0)("Note"), "")
        End If
        Return m
    End Function
End Class
