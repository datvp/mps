Imports System.Data.SqlClient
Public Class DALLs_Branchs
    Inherits DALSQL
    Private Sub New()

    End Sub
    Private Shared obj As DALLs_Branchs
    Public Shared ReadOnly Property Instance() As DALLs_Branchs
        Get
            If obj Is Nothing Then
                obj = New DALLs_Branchs
            End If
            Return obj
        End Get
    End Property
    Public Function UPDATEDB(ByVal m As Model.MLs_Branchs) As Boolean
        Dim sql As String
        If m.s_ID = "" Then
            m.s_ID = Me.getNewID
            sql = "Insert into [LS_Branchs]([s_ID], [s_Branch_ID], [s_Name], [s_Address], [s_Phone], [s_Note]) values(@s_ID,@s_Branch_ID, @s_Name, @s_Address, @s_Phone, @s_Note)"
        Else
            sql = "Update [LS_Branchs] set [s_Branch_ID]=@s_Branch_ID, [s_Name]=@s_Name, [s_Address]=@s_Address, [s_Phone]=@s_Phone, [s_Note]=@s_Note where [s_ID]=@s_ID"
        End If

        Dim p(6) As SqlParameter
        p(0) = New SqlParameter("@s_ID", m.s_ID)
        p(1) = New SqlParameter("@s_Branch_ID", m.s_Branch_ID)
        p(2) = New SqlParameter("@s_Name", m.s_Name)
        p(3) = New SqlParameter("@s_Address", m.s_Address)
        p(4) = New SqlParameter("@s_Phone", m.s_Phone)
        p(5) = New SqlParameter("@s_Note", m.s_Note)
        p(6) = New SqlParameter("@i_Ordinal", m.i_Ordinal)
        Return Me.execSQL(sql, p)

    End Function
    Public Function DELETEDB(ByVal ID As String) As Boolean
        Dim sql As String = "Delete from Ls_Branchs where s_ID= @s_ID"

        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@s_ID", ID)
        Return Me.execSQL(sql, p)

    End Function

    Public Function getList() As DataTable
        Dim sql As String = "Select * from Ls_Branchs order by s_Name"

        Return Me.getTableSQL(sql)
    End Function
    ''' <summary>
    ''' lấy ds chi nhánh để xem danh sách
    ''' </summary>
    ''' <param name="UID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getListByRight(ByVal UID As String) As DataTable
        Dim sql As String = "Select b.* from Ls_Branchs b"
        sql += " where Exists(select top 1 1 from Pr_FunRight_Ext where FuncID=b.s_ID and [UID]=@UID and R=1)"
        sql += " order by b.s_Name"
        Return Me.getTableSQL(sql, New SqlParameter("@UID", UID))
    End Function
    ''' <summary>
    ''' lấy ds chi nhánh để thực hiện nghiệp vụ (load tại mh login)
    ''' </summary>
    ''' <param name="UID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getListByRightToExecute(ByVal UID As String) As DataTable
        Dim sql As String = "Select b.* from Ls_Branchs b"
        sql += " where Exists(select top 1 1 from Pr_FunRight_Ext where FuncID=b.s_ID and [UID]=@UID and A=1)"
        sql += " order by b.s_Name"
        Return Me.getTableSQL(sql, New SqlParameter("@UID", UID))
    End Function
    'KIỂM TRA TRƯỚC KHI LƯU HÀNG HÓA***********
    Public Function CheckDulicate(ByVal IDNew As String, ByVal s_ID As String) As Boolean
        Dim sql As String = "Exec sp_CheckDulicate_Branch @s_ID,@ID"

        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@ID", IDNew)
        p(1) = New SqlParameter("@s_ID", s_ID)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If Not tb Is Nothing Then
            If tb.Rows(0)("C") > 0 Then
                Return True
            Else
                Return False
            End If
        End If

    End Function

    'KIỂM TRA TRƯỚC KHI XÓA HÀNG HÓA*******

    Public Function checkDelete(ByVal ID As String) As Boolean
        'Dim sql As String = "Exec sp_CheckDelete_Branch @s_ID"

        'Dim p(0) As SqlParameter
        'p(0) = New SqlParameter("@s_ID", ID)
        'Dim tb As DataTable = Me.getTableSQL(sql, p)
        'If tb Is Nothing Then Return False
        'For Each dr As DataRow In tb.Rows
        '    If dr("C") > 0 Then
        '        Return True
        '    End If
        'Next
        Return False
    End Function
    Public Function getInfo(ByVal ID As String) As Model.MLs_Branchs
        Dim m As New Model.MLs_Branchs
        Dim sql As String
        sql = "SELECT * FROM Ls_Branchs where s_ID=@s_ID"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@s_ID", ID)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If Not tb Is Nothing Then
            If tb.Rows.Count > 0 Then
                m.s_ID = IsNull(tb.Rows(0)("s_ID"), "")
                m.s_Branch_ID = IsNull(tb.Rows(0)("s_Branch_ID"), "")
                m.s_Name = IsNull(tb.Rows(0)("s_Name"), "")
                m.s_Address = IsNull(tb.Rows(0)("s_Address"), "")
                m.s_Phone = IsNull(tb.Rows(0)("s_Phone"), "")
                m.s_Note = IsNull(tb.Rows(0)("s_Note"), "")
                m.i_Ordinal = IsNull(tb.Rows(0)("i_Ordinal"), 0)

            End If
        End If
        Return m
    End Function

    Public Function getCode(ByVal CodeID As String) As String
        Dim sql As String = "Select s_ID from ls_Branchs where s_Branch_ID=@CodeID"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@CodeID", CodeID)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb.Rows.Count > 0 Then
            Return tb.Rows(0)("s_ID").ToString
        Else
            Return ""
        End If
    End Function
End Class
