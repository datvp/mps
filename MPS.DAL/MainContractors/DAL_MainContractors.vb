Imports System.Data.SqlClient
Public Class DAL_MainContractors
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_MainContractors
    Public Shared ReadOnly Property Instance() As DAL_MainContractors
        Get
            If obj Is Nothing Then
                obj = New DAL_MainContractors
            End If
            Return obj
        End Get
    End Property

    Public Function isExist(ByVal ID As String) As Boolean
        Dim sql = "Select Id from MainContractors where Id=@ID"
        Dim tb = getTableSQL(sql, New SqlParameter("@ID", ID))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function updateDB(ByVal m As Model.MMainContractor) As Boolean
        Dim sql = ""

        If isExist(m.Id) Then
            sql = "Update MainContractors set Company=@Company,ShortName=@ShortName,Address=@Address,Phone=@Phone,Email=@Email,Website=@Website,"
            sql += "ContactName=@ContactName,ContactPhone=@ContactPhone,ContactEmail=@ContactEmail,UpdatedAt=getdate()"
            sql += " where Id=@Id"
        Else
            sql = "Insert into MainContractors(Id,Company,ShortName,Address,Phone,Email,Website,ContactName,ContactPhone,ContactEmail,CreatedAt)"
            sql += "values(@Id,@Company,@ShortName,@Address,@Phone,@Email,@Website,@ContactName,@ContactPhone,@ContactEmail,getdate())"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(9) As SqlParameter
        p(0) = New SqlParameter("@Id", m.Id)
        p(1) = New SqlParameter("@Company", m.Company)
        p(2) = New SqlParameter("@ShortName", m.ShortName)
        p(3) = New SqlParameter("@Address", m.Address)
        p(4) = New SqlParameter("@Phone", m.Phone)
        p(5) = New SqlParameter("@Email", m.Email)
        p(6) = New SqlParameter("@Website", m.Website)
        p(7) = New SqlParameter("@ContactName", m.ContactName)
        p(8) = New SqlParameter("@ContactPhone", m.ContactPhone)        p(9) = New SqlParameter("@ContactEmail", m.ContactEmail)
        Return execSQL(sql, p)
    End Function

    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk As Boolean = True
        Dim sql As String = "Select count(*)as C from Contracts where MainContractorId=@ID"

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

    Public Function deleteDB(ByVal MainContractorId As String) As Boolean
        If Not isDelete(MainContractorId) Then
            Return False
        End If
        Dim sql = "Delete from MainContractors where Id=@MainContractorId"
        Return Me.execSQL(sql, New SqlParameter("@MainContractorId", MainContractorId))
    End Function

    Public Function getListMainContractors() As DataTable
        Dim sql As String = "Select * from MainContractors order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function

    Public Function getMainContractorDetailById(ByVal MainContractorId As String) As Model.MMainContractor
        Dim m As New Model.MMainContractor
        Dim sql = "select * from MainContractors where Id=@MainContractorId"
        Dim tb = getTableSQL(sql, New SqlParameter("@MainContractorId", MainContractorId))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.Id = IsNull(tb.Rows(0)("Id"), "")
            m.Company = IsNull(tb.Rows(0)("Company"), "")
            m.ShortName = IsNull(tb.Rows(0)("ShortName"), "")
            m.Address = IsNull(tb.Rows(0)("Address"), "")
            m.Email = IsNull(tb.Rows(0)("Email"), "")
            m.Phone = IsNull(tb.Rows(0)("Phone"), "")
            m.Website = IsNull(tb.Rows(0)("Website"), "")
            m.ContactName = IsNull(tb.Rows(0)("ContactName"), "")
            m.ContactPhone = IsNull(tb.Rows(0)("ContactPhone"), "")
            m.ContactEmail = IsNull(tb.Rows(0)("ContactEmail"), "")
        End If
        Return m
    End Function
End Class
