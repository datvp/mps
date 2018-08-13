Imports System.Data.SqlClient
Public Class DAL_SubContractors
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_SubContractors
    Public Shared ReadOnly Property Instance() As DAL_SubContractors
        Get
            If obj Is Nothing Then
                obj = New DAL_SubContractors
            End If
            Return obj
        End Get
    End Property

    Public Function isExist(ByVal ID As String) As Boolean
        Dim sql = "Select SubContractorId from SubContractors where SubContractorId=@ID"
        Dim tb = getTableSQL(sql, New SqlParameter("@ID", ID))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function updateDB(ByVal m As Model.MSubContractor) As Boolean
        Dim sql = ""

        If isExist(m.SubContractorId) Then
            sql = "Update SubContractors set SubContractorName=@SubContractorName,ShortName=@ShortName,Address=@Address,Phone=@Phone,Email=@Email,"
            sql += "ContactName=@ContactName,ContactPhone=@ContactPhone,ContactEmail=@ContactEmail,UpdatedAt=getdate(),Note=@Note"
            sql += " where SubContractorId=@SubContractorId"
        Else
            sql = "Insert into SubContractors(SubContractorId,SubContractorName,ShortName,Address,Phone,Email,ContactName,ContactPhone,ContactEmail,CreatedAt,Note)"
            sql += "values(@SubContractorId,@SubContractorName,@ShortName,@Address,@Phone,@Email,@ContactName,@ContactPhone,@ContactEmail,getdate(),@Note)"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(9) As SqlParameter
        p(0) = New SqlParameter("@SubContractorId", m.SubContractorId)
        p(1) = New SqlParameter("@SubContractorName", m.SubContractorName)
        p(2) = New SqlParameter("@ShortName", m.ShortName)
        p(3) = New SqlParameter("@Address", m.Address)
        p(4) = New SqlParameter("@Phone", m.Phone)
        p(5) = New SqlParameter("@Email", m.Email)
        p(6) = New SqlParameter("@ContactName", m.ContactName)
        p(7) = New SqlParameter("@ContactPhone", m.ContactPhone)        p(8) = New SqlParameter("@ContactEmail", m.ContactEmail)
        p(9) = New SqlParameter("@Note", m.Note)
        Return execSQL(sql, p)
    End Function

    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk As Boolean = True
        Dim sql As String = "select count(*) as C from Contract_SubContractor where SubContractorId=@SubContractorId"

        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@SubContractorId", ID)
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

    Public Function deleteDB(ByVal SubContractorId As String) As Boolean
        If Not isDelete(SubContractorId) Then
            Return False
        End If
        Dim sql = "Delete from SubContractors where SubContractorId=@SubContractorId"
        Return Me.execSQL(sql, New SqlParameter("@SubContractorId", SubContractorId))
    End Function

    Public Function getListSubContractors() As DataTable
        Dim sql As String = "Select '' as Choose,* from SubContractors order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function

    Public Function getSubContractorDetailById(ByVal SubContractorId As String) As Model.MSubContractor
        Dim m As New Model.MSubContractor
        Dim sql = "select * from SubContractors where SubContractorId=@SubContractorId"
        Dim tb = getTableSQL(sql, New SqlParameter("@SubContractorId", SubContractorId))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.SubContractorId = IsNull(tb.Rows(0)("SubContractorId"), "")
            m.SubContractorName = IsNull(tb.Rows(0)("SubContractorName"), "")
            m.ShortName = IsNull(tb.Rows(0)("ShortName"), "")
            m.Address = IsNull(tb.Rows(0)("Address"), "")
            m.Email = IsNull(tb.Rows(0)("Email"), "")
            m.Phone = IsNull(tb.Rows(0)("Phone"), "")
            m.ContactName = IsNull(tb.Rows(0)("ContactName"), "")
            m.ContactPhone = IsNull(tb.Rows(0)("ContactPhone"), "")
            m.ContactEmail = IsNull(tb.Rows(0)("ContactEmail"), "")
            m.Note = IsNull(tb.Rows(0)("Note"), "")
        End If
        Return m
    End Function

End Class
