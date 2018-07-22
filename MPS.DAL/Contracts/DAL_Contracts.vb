Imports System.Data.SqlClient
Public Class DAL_Contracts
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_Contracts
    Public Shared ReadOnly Property Instance() As DAL_Contracts
        Get
            If obj Is Nothing Then
                obj = New DAL_Contracts
            End If
            Return obj
        End Get
    End Property

    Public Function isExist(ByVal ID As String) As Boolean
        Dim sql = "Select ContractId from Contracts where ContractId=@ID"
        Dim tb = getTableSQL(sql, New SqlParameter("@ID", ID))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function updateDB(ByVal m As Model.MContract) As Boolean
        Dim sql = ""

        If isExist(m.ContractId) Then
            sql = "Update Contracts set Company=@Company,ShortName=@ShortName,Address=@Address,Phone=@Phone,Email=@Email,Website=@Website,"
            sql += "ContactName=@ContactName,ContactPhone=@ContactPhone,ContactEmail=@ContactEmail,UpdatedAt=getdate()"
            sql += " where ContractId=@ContractId"
        Else
            sql = "Insert into Contracts(ContractId,Company,ShortName,Address,Phone,Email,Website,ContactName,ContactPhone,ContactEmail,CreatedAt)"
            sql += "values(@ContractId,@Company,@ShortName,@Address,@Phone,@Email,@Website,@ContactName,@ContactPhone,@ContactEmail,getdate())"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(9) As SqlParameter
        p(0) = New SqlParameter("@ContractId", m.ContractId)
        Return execSQL(sql, p)
    End Function

    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk As Boolean = True
        Dim sql As String = "Select count(*)as C from Contracts where ContractId=@ID"

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

    Public Function deleteDB(ByVal ContractId As String) As Boolean
        If Not isDelete(ContractId) Then
            Return False
        End If
        Dim sql = "Delete from Contracts where ContractId=@ContractId"
        Return Me.execSQL(sql, New SqlParameter("@ContractId", ContractId))
    End Function

    Public Function getListContracts() As DataTable
        Dim sql As String = "Select * from Contracts order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function

    Public Function getContractDetailById(ByVal ContractId As String) As Model.MContract
        Dim m As New Model.MContract
        Dim sql = "select * from Contracts where ContractId=@ContractId"
        Dim tb = getTableSQL(sql, New SqlParameter("@ContractId", ContractId))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.ContractId = IsNull(tb.Rows(0)("ContractId"), "")
        End If
        Return m
    End Function

End Class
