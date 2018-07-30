Imports System.Data.SqlClient
Public Class DAL_ConfigProgram
    Inherits DALSQL

    Public Function UPDATEDB(ByVal m As Model.MConfigProgram) As Boolean
        Me.BeginTranstion()

        If Not Me.DELETEDB() Then
            Return False
        End If

        Dim sql As String = ""
        Dim sVal As String = ""

        sql = "Insert into [tblConfig]([s_CompanyName], [s_Alias], [s_TaxNo], [s_Account], [s_Address], [s_Phone1],"
        sql += " [s_Phone2], [s_Fax],[s_Email], [s_Website], [i_FormatCur], [i_FormatNum], [PathToSave], [DeadLineAlert]"

        sVal = " values(@s_CompanyName, @s_Alias, @s_TaxNo, @s_Account, @s_Address, @s_Phone1, "
        sVal += " @s_Phone2, @s_Fax, @s_Email, @s_Website, @i_FormatCur, @i_FormatNum, @PathToSave, @DeadLineAlert"

        If Not m.im_Logo Is Nothing Then
            sql += ", [im_Logo]"
            sVal += ", @im_Logo"
        End If

        sql = sql & ")" & sVal & ")"

        Dim p(15) As SqlParameter
        p(0) = New SqlParameter("@s_CompanyName", m.s_CompanyName)
        p(1) = New SqlParameter("@i_FormatNum", m.i_FormatNum)
        p(3) = New SqlParameter("@s_TaxNo", m.s_TaxNo)
        p(4) = New SqlParameter("@s_Account", m.s_Account)
        p(5) = New SqlParameter("@s_Address", m.s_Address)
        p(6) = New SqlParameter("@s_Phone1", m.s_Phone1)
        p(7) = New SqlParameter("@s_Phone2", m.s_Phone2)
        p(8) = New SqlParameter("@s_Fax", m.s_Fax)
        p(9) = New SqlParameter("@s_Email", m.s_Email)
        p(10) = New SqlParameter("@s_Website", m.s_Website)
        p(11) = New SqlParameter("@i_FormatCur", m.i_FormatCur)
        p(12) = New SqlParameter("@im_Logo", m.im_Logo)
        p(13) = New SqlParameter("@PathToSave", m.PathToSave)
        p(14) = New SqlParameter("@s_Alias", m.s_Alias)
        p(15) = New SqlParameter("@DeadLineAlert", m.DeadLineAlert)

        If Not Me.execSQL(sql, p) Then
            Return False
        End If

        Me.CommitTranstion()
        Return True
    End Function

    Public Function DELETEDB() As Boolean
        Return Me.execSQL("Delete from tblConfig")
    End Function
    Public Function GetConfigReport() As DataTable
        Return getTableSQL("Select *,'' as test from [ConfigReport]")
    End Function
    Public Function UpdateConfigReport(ByVal tb As DataTable) As Boolean
        execSQL("Delete from ConfigReport")
        Dim sql As String = "Insert into [ConfigReport](ID ,R ,G ,B ,[Note]) values(@ID ,@R ,@G ,@B ,@Note)"
        For Each dr As DataRow In tb.Rows
            If dr.RowState <> DataRowState.Deleted Then
                Dim pr(4) As SqlParameter
                pr(0) = New SqlParameter("@ID", dr("ID"))
                pr(1) = New SqlParameter("@G", dr("G"))
                pr(2) = New SqlParameter("@B", dr("B"))
                pr(3) = New SqlParameter("@Note", IsNull(dr("Note"), ""))
                pr(4) = New SqlParameter("@R", dr("R"))
                If Not execSQL(sql, pr) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Function getInfo() As Model.MConfigProgram
        Dim m As New Model.MConfigProgram
        Dim sql As String = "Select * From tblConfig"
        Dim tb As DataTable = Me.getTableSQL(sql)

        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.i_ID = IsNull(tb.Rows(0)("i_ID"), 0)
            m.s_CompanyName = IsNull(tb.Rows(0)("s_CompanyName"), "")
            m.s_Alias = IsNull(tb.Rows(0)("s_Alias"), "")
            m.im_Logo = IsNull(tb.Rows(0)("im_Logo"), Nothing)
            m.s_TaxNo = IsNull(tb.Rows(0)("s_TaxNo"), "")
            m.s_Account = IsNull(tb.Rows(0)("s_Account"), "")
            m.s_Address = IsNull(tb.Rows(0)("s_Address"), "")
            m.s_Phone1 = IsNull(tb.Rows(0)("s_Phone1"), "")
            m.s_Phone2 = IsNull(tb.Rows(0)("s_Phone2"), "")
            m.s_Fax = IsNull(tb.Rows(0)("s_Fax"), "")
            m.s_Email = IsNull(tb.Rows(0)("s_Email"), "")
            m.s_Website = IsNull(tb.Rows(0)("s_Website"), "")
            m.i_FormatCur = IsNull(tb.Rows(0)("i_FormatCur"), 0)
            m.i_FormatNum = IsNull(tb.Rows(0)("i_FormatNum"), 0)
            m.PathToSave = IsNull(tb.Rows(0)("PathToSave"), "")
            m.DeadLineAlert = IsNull(tb.Rows(0)("DeadLineAlert"), 0)
        End If
        Return m
    End Function
End Class
