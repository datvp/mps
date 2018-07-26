Imports System.Data.SqlClient
Public Class DAL_Clients
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_Clients
    Public Shared ReadOnly Property Instance() As DAL_Clients
        Get
            If obj Is Nothing Then
                obj = New DAL_Clients
            End If
            Return obj
        End Get
    End Property

    Public Function isExist(ByVal ID As String) As Boolean
        Dim sql = "Select ClientId from Clients where ClientId=@ID"
        Dim tb = getTableSQL(sql, New SqlParameter("@ID", ID))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function updateDB(ByVal m As Model.MClient) As Boolean
        Dim sql = ""

        If isExist(m.ClientId) Then
            sql = "Update Clients set ClientName=@ClientName,ShortName=@ShortName,Address=@Address,Phone=@Phone,Email=@Email,Website=@Website,"
            sql += "ContactName=@ContactName,ContactPhone=@ContactPhone,ContactEmail=@ContactEmail,UpdatedAt=getdate(),ClientGroupId=@ClientGroupId,"
            sql += "Status=@Status where ClientId=@ClientId"
        Else
            sql = "Insert into Clients(ClientId,ClientName,ShortName,Address,Phone,Email,Website,ContactName,ContactPhone,ContactEmail,CreatedAt,ClientGroupId,Status)"
            sql += "values(@ClientId,@ClientName,@ShortName,@Address,@Phone,@Email,@Website,@ContactName,@ContactPhone,@ContactEmail,getdate(),@ClientGroupId,@Status)"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(11) As SqlParameter
        p(0) = New SqlParameter("@ClientId", m.ClientId)
        p(1) = New SqlParameter("@ClientName", m.ClientName)
        p(2) = New SqlParameter("@ShortName", m.ShortName)
        p(3) = New SqlParameter("@Address", m.Address)
        p(4) = New SqlParameter("@Phone", m.Phone)
        p(5) = New SqlParameter("@Email", m.Email)
        p(6) = New SqlParameter("@Website", m.Website)
        p(7) = New SqlParameter("@ContactName", m.ContactName)
        p(8) = New SqlParameter("@ContactPhone", m.ContactPhone)        p(9) = New SqlParameter("@ContactEmail", m.ContactEmail)
        p(10) = New SqlParameter("@ClientGroupId", m.ClientGroupId)
        p(11) = New SqlParameter("@Status", m.Status)
        Return execSQL(sql, p)
    End Function

    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk = True
        Dim sql = "Select count(*) as C from Projects where ClientId=@ClientId"
        Dim tb = Me.getTableSQL(sql, New SqlParameter("@ClientId", ID))
        If tb Is Nothing Then Return False
        For Each r As DataRow In tb.Rows
            If r("C") > 0 Then
                isOk = False
                Exit For
            End If
        Next
        Return isOk
    End Function

    Public Function deleteDB(ByVal ClientId As String) As Boolean
        If Not isDelete(ClientId) Then
            Return False
        End If
        Dim sql = "Update Clients set Status='Deleted' where ClientId=@ClientId"
        Return Me.execSQL(sql, New SqlParameter("@ClientId", ClientId))
    End Function

    Public Function getListClients() As DataTable
        Dim sql As String = "Select c.*, g.ClientGroupName from Clients c inner join ClientGroups g on c.ClientGroupId=g.ClientGroupId where c.Status<>'Deleted' order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function

    Public Function getClientDetailById(ByVal ClientId As String) As Model.MClient
        Dim m As New Model.MClient
        Dim sql = "select * from Clients where ClientId=@ClientId"
        Dim tb = getTableSQL(sql, New SqlParameter("@ClientId", ClientId))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.ClientId = IsNull(tb.Rows(0)("ClientId"), "")
            m.ClientName = IsNull(tb.Rows(0)("ClientName"), "")
            m.ShortName = IsNull(tb.Rows(0)("ShortName"), "")
            m.Address = IsNull(tb.Rows(0)("Address"), "")
            m.Email = IsNull(tb.Rows(0)("Email"), "")
            m.Phone = IsNull(tb.Rows(0)("Phone"), "")
            m.Website = IsNull(tb.Rows(0)("Website"), "")
            m.ContactName = IsNull(tb.Rows(0)("ContactName"), "")
            m.ContactPhone = IsNull(tb.Rows(0)("ContactPhone"), "")
            m.ContactEmail = IsNull(tb.Rows(0)("ContactEmail"), "")
            m.ClientGroupId = IsNull(tb.Rows(0)("ClientGroupId"), "")
            m.Status = IsNull(tb.Rows(0)("Status"), "")
        End If
        Return m
    End Function

    Public Function getListClientGroups() As DataTable
        Dim sql As String = "Select * from ClientGroups order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function
End Class
