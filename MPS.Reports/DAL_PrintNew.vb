Imports System.Data.SqlClient
Imports MPS.DAL

Public Class DAL_PrintNew
    Inherits DALSQL

    Public Sub TransferData(ByVal ViewName As String, ByVal nCol As Integer, ByVal strQuery As String, ByVal strOrder As String)
        Dim tblTmp As String = ViewName & "_Transfer"
        Dim tb As DataTable
        Dim sql As String = ""
        tb = Me.getTableSQL("Select * From sysobjects Where xtype='V' and name=N'" & tblTmp.Replace("'", "''") & "'")

        If tb.Rows.Count > 0 Then
            sql = "Drop table [" & tblTmp.Replace("'", "''") & "]"
            If Not execSQL(sql) Then
                Exit Sub
            End If
        End If

        sql = "Select c.name as cName,t.name as tName,c.length as lFrom sysobjects s,syscolumns c,systypes t"
        sql += " Where s.id=c.id and c.xtype=t.xtype and s.name=N'" & ViewName.Replace("'", "''") & "' and t.name<>'sysname'"
        tb = Me.getTableSQL(sql)
        sql = "Create table [" & tblTmp.Replace("'", "''") & "]("

        For i As Integer = 1 To nCol
            For Each dr As DataRow In tb.Rows
                sql += "[" & dr("cName").ToString.Replace("'", "''") & "_" & i.ToString & "] " & dr("tName").ToString.Replace("'", "''")
                If dr("tName").ToString.ToLower = "nvarchar" Then
                    sql += "(" & dr("l").ToString & "),"
                Else
                    sql += ","
                End If
            Next
        Next
        sql += " key_IDSort numeric)"
        If Not execSQL(sql) Then
            Exit Sub
        End If

        sql = "Select * from [" & ViewName.Replace("'", "''") & "]"
        If strQuery <> "" Then
            sql += " where " & strQuery
        End If

        If strOrder <> "" Then
            sql += " Order by " & strOrder
        End If
        Dim tbsource As DataTable = Me.getTableSQL(sql)

        'Tao bang nCol
        Dim c As Integer = 0
        Dim stt As Integer = 1
        Dim n As Integer = tbsource.Columns.Count * nCol
        While c < tbsource.Rows.Count
            If c = 0 Then
                sql = "Insert into [" & tblTmp.Replace("'", "''") & "](key_IDSort)values(" & stt.ToString & ")"
                If Not execSQL(sql) Then
                    Exit Sub
                End If
            End If
            Dim p(n) As SqlParameter
            sql = "Update [" & tblTmp.Replace("'", "''") & "] set "
            Dim sCol As String = ""
            Dim k As Integer = 0
            For i As Integer = 1 To nCol
                If c < tbsource.Rows.Count Then
                    For j As Integer = 0 To tbsource.Columns.Count - 1
                        Dim sParaName As String = "@Para_" & i.ToString & "_" & j.ToString
                        p(k) = New SqlParameter(sParaName, tbsource.Rows(c)(j))
                        sCol += "[" & tbsource.Columns(j).ColumnName.Replace("'", "''") & "_" & i.ToString & "]=" & sParaName & ","
                        k += 1
                    Next
                    c += 1
                Else
                    Exit For
                End If

            Next
            If sCol <> "" Then
                sCol = sCol.Substring(0, sCol.Length - 1)
                sql += sCol & " where key_IDSort=" & stt.ToString
                If Not execSQL(sql, p) Then
                    Exit Sub
                End If
            End If

            If c < tbsource.Rows.Count Then
                stt += 1
                sql = "Insert into [" & tblTmp.Replace("'", "''") & "](key_IDSort)values(" & stt.ToString & ")"
                If Not execSQL(sql) Then
                    Exit Sub
                End If
            End If
        End While

    End Sub

End Class
