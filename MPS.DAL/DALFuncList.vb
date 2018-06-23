Imports System.Data.SqlClient
Public Class DALFuncList
    Inherits DALSQL

    'THÊM MỚI, HIỆU CHỈNH CHỨC NĂNG NGHIỆP VỤ**********
    Public Function UPDATEDB(ByVal m As Model.MFuncList, ByVal isUpdate As Boolean) As Boolean
        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@ID", m.ID)
        p(1) = New SqlParameter("@Name", m.Name)
        p(2) = New SqlParameter("@Note", m.Note)
        p(3) = New SqlParameter("@Uplevel", m.Uplevel)
        p(4) = New SqlParameter("@valid", m.valid)

        Dim sql As String = ""
        If Not isUpdate Then
            sql = "Insert into LS_FUN([i_ID],s_Name,i_Uplevel,b_valid,s_Note)VALUES(@ID,@Name,@Uplevel,@valid,@Note)"
        Else
            sql = "Update LS_FUN set s_Name=@Name,i_Uplevel=@Uplevel,b_valid=@valid,s_Note=@Note where [i_ID]=@ID"
        End If
        Return Me.execSQL(sql, p)
    End Function
    Public Function CheckDul(ByVal ID As Double) As Boolean
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        Dim sql As String = "Select count(*) as C from LS_FUN where [i_ID]=@ID"
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb.Rows(0)("C") > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function getNextID() As Double
        
        Dim sql As String = "Select isnull(Max([i_ID]),0) +1 as M from LS_FUN"
        Dim tb As DataTable = Me.getTableSQL(sql)
        Return tb.Rows(0)("M")
    End Function

    'XÓA CHỨC NĂNG NGHIỆP VỤ***********
    Public Function DELETEDB(ByVal ID As Double) As Boolean
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        Dim sql As String = "exec sp_DeleteFunc @ID"

        Return Me.execSQL(sql, p)
    End Function

    'LOAD DANH SÁCH CHỨC NĂNG*****************
    Public Function getList(ByVal nCase As Integer) As DataTable
        Dim sql As String = "exec sp_getListFunc @nCase"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@nCase", nCase)
        Return Me.getTableSQL(sql, p)
    End Function

    'LOAD DANH SACH CHỨC NĂNG CÓ RELATION**************
    Public Function getList() As DataSet
        Dim ds As New DataSet
        Dim tbParent As DataTable = getList(1)
        tbParent.TableName = "tbParent"
        Dim tbChild As DataTable = getList(2)
        tbChild.Columns.Add("isChild", GetType(Boolean))
        tbChild.TableName = "tbChild"
        ds.Tables.Add(tbParent.Copy)
        ds.Tables.Add(tbChild.Copy)
        ds.Relations.Add("Parent_Child", ds.Tables("tbParent").Columns("i_ID"), ds.Tables("tbChild").Columns("i_Uplevel"))
        Return ds
    End Function

    'LẤY THÔNG TIN CHI TIẾT CHỨC NĂNG************
    Public Function getInfo(ByVal ID As Integer) As Model.MFuncList
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        Dim sql As String = "Exec sp_getInfoFunc @ID"
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        Dim m As New Model.MFuncList
        If Not tb Is Nothing Then
            If tb.Rows.Count > 0 Then
                m.ID = tb.Rows(0)("i_ID")
                m.Name = tb.Rows(0)("s_Name")
                m.Note = IsNull(tb.Rows(0)("s_Note"), "")
                m.Uplevel = IsNull(tb.Rows(0)("i_Uplevel"), 0)
                m.valid = IsNull(tb.Rows(0)("b_valid"), False)
            End If
        End If
        Return m
    End Function

End Class
