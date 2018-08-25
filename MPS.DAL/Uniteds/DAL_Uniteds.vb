Imports System.Data.SqlClient
Public Class DAL_Uniteds
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_Uniteds
    Public Shared ReadOnly Property Instance() As DAL_Uniteds
        Get
            If obj Is Nothing Then
                obj = New DAL_Uniteds
            End If
            Return obj
        End Get
    End Property

    Public Function isExist(ByVal ID As String) As Boolean
        Dim sql = "Select UnitedId from Uniteds where UnitedId=@ID"
        Dim tb = getTableSQL(sql, New SqlParameter("@ID", ID))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function updateDB(ByVal m As Model.MUnited) As Boolean
        Dim sql = ""

        If isExist(m.UnitedId) Then
            sql = "Update Uniteds set UnitedName=@UnitedName,ShortName=@ShortName,Address=@Address,Phone=@Phone,Email=@Email,Website=@Website,"
            sql += "ContactName=@ContactName,ContactPhone=@ContactPhone,ContactEmail=@ContactEmail,UpdatedAt=getdate(),Note=@Note"
            sql += " where UnitedId=@UnitedId"
        Else
            sql = "Insert into Uniteds(UnitedId,UnitedName,ShortName,Address,Phone,Email,Website,ContactName,ContactPhone,ContactEmail,CreatedAt,Note)"
            sql += "values(@UnitedId,@UnitedName,@ShortName,@Address,@Phone,@Email,@Website,@ContactName,@ContactPhone,@ContactEmail,getdate(),@Note)"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(10) As SqlParameter
        p(0) = New SqlParameter("@UnitedId", m.UnitedId)
        p(1) = New SqlParameter("@UnitedName", m.UnitedName)
        p(2) = New SqlParameter("@ShortName", m.ShortName)
        p(3) = New SqlParameter("@Address", m.Address)
        p(4) = New SqlParameter("@Phone", m.Phone)
        p(5) = New SqlParameter("@Email", m.Email)
        p(6) = New SqlParameter("@Website", m.Website)
        p(7) = New SqlParameter("@ContactName", m.ContactName)
        p(8) = New SqlParameter("@ContactPhone", m.ContactPhone)        p(9) = New SqlParameter("@ContactEmail", m.ContactEmail)
        p(10) = New SqlParameter("@Note", m.Note)
        Return execSQL(sql, p)
    End Function

    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk As Boolean = True
        Dim sql As String = "Select count(*)as C from Clients where UnitedId=@ID"

        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb Is Nothing Then Return False
        For Each r As DataRow In tb.Rows
            If r("C") > 0 Then
                isOk = False
                Exit For
            End If
        Next
        Return isOk
    End Function

    Public Function deleteDB(ByVal UnitedId As String) As Boolean
        If Not isDelete(UnitedId) Then
            Return False
        End If
        Dim sql = "Delete from Uniteds where UnitedId=@UnitedId"
        Return Me.execSQL(sql, New SqlParameter("@UnitedId", UnitedId))
    End Function

    Public Function getListUniteds() As DataTable
        Dim sql As String = "Select * from Uniteds order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function

    Public Function getUnitedDetailById(ByVal UnitedId As String) As Model.MUnited
        Dim m As New Model.MUnited
        Dim sql = "select * from Uniteds where UnitedId=@UnitedId"
        Dim tb = getTableSQL(sql, New SqlParameter("@UnitedId", UnitedId))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.UnitedId = IsNull(tb.Rows(0)("UnitedId"), "")
            m.UnitedName = IsNull(tb.Rows(0)("UnitedName"), "")
            m.ShortName = IsNull(tb.Rows(0)("ShortName"), "")
            m.Address = IsNull(tb.Rows(0)("Address"), "")
            m.Email = IsNull(tb.Rows(0)("Email"), "")
            m.Phone = IsNull(tb.Rows(0)("Phone"), "")
            m.Website = IsNull(tb.Rows(0)("Website"), "")
            m.ContactName = IsNull(tb.Rows(0)("ContactName"), "")
            m.ContactPhone = IsNull(tb.Rows(0)("ContactPhone"), "")
            m.ContactEmail = IsNull(tb.Rows(0)("ContactEmail"), "")
            m.Note = IsNull(tb.Rows(0)("Note"), "")
        End If
        Return m
    End Function
End Class
