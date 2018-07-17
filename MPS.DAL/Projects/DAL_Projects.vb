Imports System.Data.SqlClient
Public Class DAL_Projects
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_Projects
    Public Shared ReadOnly Property Instance() As DAL_Projects
        Get
            If obj Is Nothing Then
                obj = New DAL_Projects
            End If
            Return obj
        End Get
    End Property

    Public Function isExist(ByVal ID As String) As Boolean
        Dim sql = "Select ProjectId from Projects where ProjectId=@ID"
        Dim tb = getTableSQL(sql, New SqlParameter("@ID", ID))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function updateDB(ByVal m As Model.MProject) As Boolean
        Dim sql = ""

        If isExist(m.ProjectId) Then
            sql = "Update Projects set ProjectName=@ProjectName,ProjectTypeId=@ProjectTypeId,ProjectGroupId=@ProjectGroupId"
            sql += ",ConstructionLevelId=@ConstructionLevelId,Performance=@Performance,Length=@Length,Note=@Note"
            sql += ",PerformanceUnit=@PerformanceUnit,LengthUnit=@LengthUnit,UpdatedAt=getdate() where ProjectId=@ProjectId"
        Else
            sql = "Insert into Projects(ProjectId,ProjectName,ProjectTypeId,ProjectGroupId,ConstructionLevelId,Performance,Length,Note,PerformanceUnit,LengthUnit,CreatedAt)"
            sql += "values(@ProjectId,@ProjectName,@ProjectTypeId,@ProjectGroupId,@ConstructionLevelId,@Performance,@Length,@Note,@PerformanceUnit,@LengthUnit,getdate())"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(9) As SqlParameter
        p(0) = New SqlParameter("@ProjectId", m.ProjectId)
        p(1) = New SqlParameter("@ProjectName", m.ProjectName)
        p(2) = New SqlParameter("@ProjectTypeId", m.ProjectTypeId)
        p(3) = New SqlParameter("@ProjectGroupId", m.ProjectGroupId)
        p(4) = New SqlParameter("@ConstructionLevelId", m.ConstructionLevelId)
        p(5) = New SqlParameter("@Performance", m.Performance)
        p(6) = New SqlParameter("@Length", m.Length)
        p(7) = New SqlParameter("@Note", m.Note)
        p(8) = New SqlParameter("@PerformanceUnit", m.PerformanceUnit)        p(9) = New SqlParameter("@LengthUnit", m.LengthUnit)
        Return execSQL(sql, p)
    End Function

    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk As Boolean = True
        'Dim sql As String = "Exec sp_CheckDelete_Employees @s_ID"

        'Dim p(0) As SqlParameter
        'p(0) = New SqlParameter("@s_ID", ID)
        'Dim tb As DataTable = Me.getTableSQL(sql, p)
        'If tb Is Nothing Then Return False
        'For Each r As DataRow In tb.Rows
        '    If r("C") > 0 Then
        '        isOk = False
        '        Exit For
        '    End If
        'Next
        Return isOk
    End Function

    Public Function deleteDB(ByVal ProjectId As String) As Boolean
        If Not isDelete(ProjectId) Then
            Return False
        End If
        Dim sql = "Delete from Projects where ProjectId=@ProjectId"
        Return Me.execSQL(sql, New SqlParameter("@ProjectId", ProjectId))
    End Function

    Public Function getListProjects() As DataTable
        Dim sql As String = "Select p.*, t.ProjectTypeName, g.ProjectGroupName, c.ConstructionLevelName from Projects p"
        sql += " left join ProjectTypes t on p.ProjectTypeId=t.ProjectTypeId"
        sql += " left join ProjectGroups g on p.ProjectGroupId=g.ProjectGroupId"
        sql += " left join ConstructionLevels c on p.ConstructionLevelId=c.ConstructionLevelId"
        sql += " order by p.CreatedAt"
        Return Me.getTableSQL(sql)
    End Function

    Public Function getProjectDetailById(ByVal ProjectId As String) As Model.MProject
        Dim m As New Model.MProject
        Dim sql = "select * from Projects where ProjectId=@ProjectId"
        Dim tb = getTableSQL(sql, New SqlParameter("@ProjectId", ProjectId))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.ProjectId = IsNull(tb.Rows(0)("ProjectId"), "")
            m.ProjectName = IsNull(tb.Rows(0)("ProjectName"), "")
            m.ProjectTypeId = IsNull(tb.Rows(0)("ProjectTypeId"), "")
            m.ProjectGroupId = IsNull(tb.Rows(0)("ProjectGroupId"), "")
            m.ConstructionLevelId = IsNull(tb.Rows(0)("ConstructionLevelId"), "")
            m.Performance = IsNull(tb.Rows(0)("Performance"), "")
            m.PerformanceUnit = IsNull(tb.Rows(0)("PerformanceUnit"), "")
            m.Length = IsNull(tb.Rows(0)("Length"), "")
            m.LengthUnit = IsNull(tb.Rows(0)("LengthUnit"), "")
            m.Note = IsNull(tb.Rows(0)("Note"), "")
        End If
        Return m
    End Function

    Public Function getListProjectGroups() As DataTable
        Dim sql As String = "Select * from ProjectGroups order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function
    Public Function getListProjectTypes() As DataTable
        Dim sql As String = "Select * from ProjectTypes order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function
    Public Function getListConstructionLevels() As DataTable
        Dim sql As String = "Select * from ConstructionLevels order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function
    Public Function getListPerformanceUnit() As DataTable
        Dim sql As String = "Select * from Units Where Type='CSLD'"
        Return Me.getTableSQL(sql)
    End Function
    Public Function getListLengthUnit() As DataTable
        Dim sql As String = "Select * from Units Where Type='CDDN'"
        Return Me.getTableSQL(sql)
    End Function
End Class
