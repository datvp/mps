Imports System.Data.SqlClient
Public Class DAL_Items
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_Items
    Public Shared ReadOnly Property Instance() As DAL_Items
        Get
            If obj Is Nothing Then
                obj = New DAL_Items
            End If
            Return obj
        End Get
    End Property

    Public Function isExist(ByVal ID As String) As Boolean
        Dim sql = "Select ItemId from Items where ItemId=@ID"
        Dim tb = getTableSQL(sql, New SqlParameter("@ID", ID))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function updateDB(ByVal m As Model.MItem) As Boolean
        Dim sql = ""

        If isExist(m.ItemId) Then
            sql = "Update Items set ItemName=@ItemName,Note=@Note,UpdatedAt=getdate()"
            sql += " where ItemId=@ItemId"
        Else
            sql = "Insert into Items(ItemId,ItemName,Note,CreatedAt)"
            sql += "values(@ItemId,@ItemName,@Note,getdate())"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(2) As SqlParameter
        p(0) = New SqlParameter("@ItemId", m.ItemId)
        p(1) = New SqlParameter("@ItemName", m.ItemName)
        p(2) = New SqlParameter("@Note", m.Note)
        Return execSQL(sql, p)
    End Function

    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk = True
        Dim sql = "select count(*)as C from ContractDetails where ItemId=@ItemId"

        Dim tb = Me.getTableSQL(sql, New SqlParameter("@ItemId", ID))
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

    Public Function deleteDB(ByVal ItemId As String) As Boolean
        If Not isDelete(ItemId) Then
            Return False
        End If
        Dim sql = "Delete from Items where ItemId=@ItemId"
        Return Me.execSQL(sql, New SqlParameter("@ItemId", ItemId))
    End Function

    Public Function getListItems() As DataTable
        Dim sql As String = "Select *,'' as Choose from Items order by CreatedAt"
        Return Me.getTableSQL(sql)
    End Function

    Public Function getItemDetailById(ByVal ItemId As String) As Model.MItem
        Dim m As New Model.MItem
        Dim sql = "select * from Items where ItemId=@ItemId"
        Dim tb = getTableSQL(sql, New SqlParameter("@ItemId", ItemId))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.ItemId = IsNull(tb.Rows(0)("ItemId"), "")
            m.ItemName = IsNull(tb.Rows(0)("ItemName"), "")
            m.Note = IsNull(tb.Rows(0)("Note"), "")
        End If
        Return m
    End Function
End Class
