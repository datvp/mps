Imports System.Data.SqlClient
Public Class DALFuncRight
    Inherits DALSQL

    'THÊM MỚI-HIỆU CHỈNH CẤP QUYỀN THEO CHỨC NĂNG NGHIỆP VỤ***********
    Public Function DeleteDB(ByVal UID As String) As Boolean
        Dim sql As String = ""
        sql = "Delete from PR_FunRight_EXT where UID=@UID"
        sql += vbCrLf
        sql += " Delete from PR_FunRight where uid=@UID"
        Return Me.execSQL(sql, New SqlParameter("@UID", UID))
    End Function

    Public Function UPDATEDB(ByVal m As Model.MFuncRight) As Boolean
        Dim p(7) As SqlParameter
        p(0) = New SqlParameter("@A", m.A)
        p(1) = New SqlParameter("@D", m.D)
        p(2) = New SqlParameter("@FuncID", m.FuncID)
        p(3) = New SqlParameter("@IDSort", m.IDSort)
        p(4) = New SqlParameter("@R", m.R)
        p(5) = New SqlParameter("@U", m.U)
        p(6) = New SqlParameter("@UID", m.UID)
        p(7) = New SqlParameter("@sFuncID", m.sFuncID)
        Dim sql As String
        If m.sFuncID <> "" Then
            sql = "Insert into PR_FunRight_EXT(UID,FuncID,R,U,A,D)values(@UID,@sFuncID,@R,@U,@A,@D)"
        Else
            sql = "Insert into PR_FunRight(UID,FuncID,R,U,A,D)values(@UID,@FuncID,@R,@U,@A,@D)"
        End If
        Return Me.execSQL(sql, p)
    End Function

    'LOAD THÔNG TIN CHI TIẾT CẤP QUYỀN THEO NGƯỜI DÙNG***********
    Public Function getFuncRight(ByVal UID As String) As DataSet
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@UID", UID)
        p(1) = New SqlParameter("@sVersion", "p")

        Dim sql As String = "exec sp_getFuncRight @UID,0,@sVersion"
        Dim tbParent As DataTable = Me.getTableSQL(sql, p)

        If Not tbParent Is Nothing Then
            tbParent.TableName = "tbParent"
        End If

        p(0) = New SqlParameter("@UID", UID)
        p(1) = New SqlParameter("@sVersion", "p")

        sql = "exec sp_getFuncRight @UID,1,@sVersion"
        Dim tbChild As DataTable = Me.getTableSQL(sql, p)
        If Not tbChild Is Nothing Then
            tbChild.TableName = "tbChild"
        End If

        Dim ds As New DataSet
        If Not tbParent Is Nothing And Not tbChild Is Nothing Then
            ds.Tables.Add(tbParent.Copy)
            ds.Tables.Add(tbChild.Copy)
            ds.Relations.Add("Parent_Child", ds.Tables("tbParent").Columns("i_ID"), ds.Tables("tbChild").Columns("i_Uplevel"))
        End If
        Return ds
    End Function

    'LOAD THÔNG TIN CHI TIẾT CẤP QUYỀN THEO NGƯỜI DÙNG PHAN BIET SMS ***********
    Public Function getFuncRight(ByVal UID As String, ByVal isSMS As Boolean) As DataSet
        Dim ds As New DataSet

        Dim tbParent As DataTable = GetParent(UID)
        Dim tbChild As DataTable = GetChild(UID)

        If Not tbParent Is Nothing AndAlso Not tbChild Is Nothing Then
            tbParent.TableName = "tbParent"
            tbChild.TableName = "tbChild"
            ds.Tables.Add(tbParent.Copy)
            ds.Tables.Add(tbChild.Copy)
            ds.Relations.Add("Parent_Child", ds.Tables("tbParent").Columns("i_ID"), ds.Tables("tbChild").Columns("i_Uplevel"))
        End If

        Return ds
    End Function

    Private Function GetParent(ByVal UID As String) As DataTable
        Dim sql As String = ""
        sql += "Select '' as sFunID,f.s_Name,f.i_ID,isnull(r.U,0) as U,isnull(r.A,0) as A,isnull(r.D,0) as D,isnull(r.R,0) as R,"
        sql += " f.IDSort"
        sql += " from LS_FUN f left outer join (Select * from PR_FunRight where [UID]=@UID) as r On f.i_ID=r.FuncID"
        sql += " where(IsNull(f.i_Uplevel, 0) = 0)"
        sql += " Union all"
        sql += " Select f.s_ID as sFunID,N'Danh sách Chi nhánh' as s_Name,f.i_ID,isnull(r.U,0) as U,isnull(r.A,0) as A,isnull(r.D,0) as D,isnull(r.R,0) as R,"
        sql += " isnull(r.IDSort,0) as IDSort"
        sql += " From (Select cast(-98 as int) as i_ID,'-1' as s_ID ) f"
        sql += " left outer join (Select * from PR_FunRight_EXT where [UID]=@UID) as r On f.s_ID=r.FuncID"
        sql += " order by IDSort"

        Dim tb As DataTable = getTableSQL(sql, New SqlParameter("@UID", UID))
        Return tb
    End Function

    Private Function GetChild(ByVal UID As String) As DataTable
        Dim sql As String = ""
        sql += "Select '' as sFunID,f.s_Name,f.i_ID,f.i_Uplevel,isnull(r.U,0) as U,isnull(r.A,0) as A,isnull(r.D,0) as D,isnull(r.R,0) as R,"
        sql += " f.IDSort"
        sql += " from LS_FUN f left outer join (Select * from PR_FunRight where [UID]=@UID) as r On f.i_ID=r.FuncID"
        sql += " where f.b_Valid=1 and (IsNull(f.i_Uplevel, 0) <> 0)"
        sql += " Union all"
        sql += " Select f.s_ID as sFunID,f.[s_Name] as s_Name,cast(0 as int) as i_ID,cast(-98 as int) i_Uplevel,"
        sql += " isnull(r.U,0) as U,isnull(r.A,0) as A,isnull(r.D,0) as D,isnull(r.R,0) as R,isnull(r.IDSort,0) as IDSort"
        sql += " from Ls_Branchs f"
        sql += " left outer join (Select * from PR_FunRight_EXT where [UID]=@UID) as r On f.s_ID=r.FuncID"
        sql += " order by IDSort"

        Dim tb As DataTable = getTableSQL(sql, New SqlParameter("@UID", UID))
        Return tb
    End Function


    Public Function getFuncRight(ByVal UID As String, ByVal FuncID As Double) As DataTable
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@UID", UID)
        p(1) = New SqlParameter("@FuncID", FuncID)
        Dim sql As String = "exec sp_getFuncRightUser @UID,@FuncID"
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If Not IsNothing(tb) Then
            If tb.Rows.Count = 0 Then
                Dim dr As DataRow = tb.NewRow
                dr("uid") = UID
                dr("FuncID") = FuncID
                dr("R") = False
                dr("A") = False
                dr("U") = False
                dr("D") = False
                dr("IDSort") = 0
                tb.Rows.Add(dr)
            End If
        End If

        Return tb
    End Function

    Public Function getFuncRightStore(ByVal UID As String, ByVal Store_ID As String) As DataTable
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@UID", UID)
        p(1) = New SqlParameter("@FuncID", Store_ID)
        Dim sql As String = "Select * from [dbo].[PR_FunRight_EXT] where UID=@UID and FuncID=@FuncID"
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb Is Nothing Then Return Nothing
        If tb.Rows.Count = 0 Then
            Dim dr As DataRow = tb.NewRow
            dr("uid") = UID
            dr("FuncID") = Store_ID
            dr("R") = False
            dr("A") = False
            dr("U") = False
            dr("D") = False
            dr("IDSort") = 0
            tb.Rows.Add(dr)
        End If
        Return tb
    End Function

    Public Function getListCounter(ByVal UID As String) As DataTable
        Dim sql As String
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@UID", UID)
        sql = "Select * from PR_FunRight_EXT where UID=@UID  and FuncID<>'-1' and FuncID<>'-2' "
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        Return tb
    End Function

    Public Function getStoreOfUser(ByVal UID As String) As DataTable
        Dim sql As String
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@UID", UID)
        sql = "Select s.s_ID from PR_FunRight_EXT p join ls_Stores s "
        sql += " on p.funcID=s.s_ID where UID=@UID  and FuncID<>'-1' and FuncID<>'-2' and R=1 "
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        Return tb
    End Function

    '25/01/2010 mac dinh set phan quyen cac kho =True cho tat ca user
    Public Function SetFuncStore(ByVal User As String) As Boolean
        Dim sql As String = ""
        Dim tbu As New DataTable
        Dim tbf As New DataTable
        Dim sFuncID As String = ""
        Dim UID As String = ""

        'kho
        sql = "select * from Ls_Stores"
        Dim tbs As DataTable = getTableSQL(sql)

        'phan quyen
        sql = "select * from PR_FunRight_EXT"
        tbf = getTableSQL(sql)


        If User = "" Then
            'nguoi dung
            sql = " select * from ls_User where b_Valid=1"
            tbu = getTableSQL(sql)
            
            Try
                For Each r As DataRow In tbu.Rows 'voi moi User
                    Dim Df() As DataRow = tbf.Select("UID='" & r("s_UID").ToString.Replace("'", "''") & "'")

                    If Df.Length > 0 Then 'co trong phan quyen roi 

                        For Each rs As DataRow In tbs.Rows
                            Dim Df1() As DataRow = tbf.Select("FuncID='" & rs("s_ID").ToString.Replace("'", "''") & "'" & "and UID ='" & r("s_UID").ToString.Replace("'", "''") & "'")
                            If Df1.Length = 0 Then
                                sFuncID = rs("s_ID")
                                UID = r("s_UID")
                                sql = "Insert into PR_FunRight_EXT(UID,FuncID,R,U,A,D)values(N'" & UID.Replace("'", "''") & "','" & sFuncID.Replace("'", "''") & "',1,0,0,0)"
                                execSQL(sql)
                            End If
                        Next

                        sql = "update PR_FunRight_EXT set R=1 where UID=N'" & UID.Replace("'", "''") & "'"
                        execSQL(sql)

                    Else 'chua co
                        UID = r("s_UID")
                        sql = "Insert into PR_FunRight_EXT(UID,FuncID,R,U,A,D)values(N'" & UID.Replace("'", "''") & "'," & "'-1',1,0,0,0)"
                        execSQL(sql)

                        For Each s As DataRow In tbs.Rows 'tung kho
                            sFuncID = s("s_ID")
                            sql = "Insert into PR_FunRight_EXT(UID,FuncID,R,U,A,D)values(N'" & UID.Replace("'", "''") & "','" & sFuncID.Replace("'", "''") & "',1,0,0,0)"
                            execSQL(sql)
                        Next
                    End If
                Next
            Catch ex As Exception
                MsgBox("Set quyền mặc định cho kho bi lỗi !")
                Return False
            End Try


        Else 'ap dung them moi

            Try

                For Each rs As DataRow In tbs.Rows
                    Dim Df1() As DataRow = tbf.Select("FuncID='" & rs("s_ID").ToString.Replace("'", "''") & "'" & "and UID ='" & UID.Replace("'", "''") & "'")
                    If Df1.Length = 0 Then
                        sql = "Insert into PR_FunRight_EXT(UID,FuncID,R,U,A,D)values(N'" & UID.Replace("'", "''") & "','" & sFuncID.Replace("'", "''") & "',1,0,0,0)"
                        execSQL(sql)
                    End If
                Next

                sql = "update PR_FunRight_EXT set R=1 where UID='" & User.Replace("'", "''") & "'"
                execSQL(sql)

            Catch ex As Exception
                MsgBox("Set quyền mặc định cho kho bi lỗi !")
                Return False
            End Try

        End If

        Return True
    End Function
    Public Function SetFuncBranch(ByVal User As String) As Boolean
        Dim sql As String = ""
        Dim tbu As New DataTable
        Dim tbf As New DataTable
        Dim sFuncID As String = ""
        Dim UID As String = ""

        'chi nhánh
        sql = "select * from Ls_Branchs"
        Dim tbs As DataTable = getTableSQL(sql)

        'phan quyen
        sql = "select * from PR_FunRight_EXT"
        tbf = getTableSQL(sql)


        If User = "" Then
            'nguoi dung
            sql = " select * from ls_User where b_Valid=1"
            tbu = getTableSQL(sql)

            Try
                For Each r As DataRow In tbu.Rows 'voi moi User
                    Dim Df() As DataRow = tbf.Select("UID='" & r("s_UID").ToString.Replace("'", "''") & "'")

                    If Df.Length > 0 Then 'co trong phan quyen roi 

                        For Each rs As DataRow In tbs.Rows
                            Dim Df1() As DataRow = tbf.Select("FuncID='" & rs("s_ID").ToString.Replace("'", "''") & "'" & "and UID ='" & r("s_UID").ToString.Replace("'", "''") & "'")
                            If Df1.Length = 0 Then
                                sFuncID = rs("s_ID")
                                UID = r("s_UID")
                                sql = "Insert into PR_FunRight_EXT(UID,FuncID,R,U,A,D)values(N'" & UID.Replace("'", "''") & "','" & sFuncID.Replace("'", "''") & "',1,0,0,0)"
                                execSQL(sql)
                            End If
                        Next

                        sql = "update PR_FunRight_EXT set R=1 where UID=N'" & UID.Replace("'", "''") & "'"
                        execSQL(sql)

                    Else 'chua co
                        UID = r("s_UID")
                        sql = "Insert into PR_FunRight_EXT(UID,FuncID,R,U,A,D)values(N'" & UID.Replace("'", "''") & "'," & "'-1',1,0,0,0)"
                        execSQL(sql)

                        For Each s As DataRow In tbs.Rows 'tung kho
                            sFuncID = s("s_ID")
                            sql = "Insert into PR_FunRight_EXT(UID,FuncID,R,U,A,D)values(N'" & UID.Replace("'", "''") & "','" & sFuncID.Replace("'", "''") & "',1,0,0,0)"
                            execSQL(sql)
                        Next
                    End If
                Next
            Catch ex As Exception
                MsgBox("Set quyền mặc định cho kho bi lỗi !")
                Return False
            End Try


        Else 'ap dung them moi

            Try

                For Each rs As DataRow In tbs.Rows
                    Dim Df1() As DataRow = tbf.Select("FuncID='" & rs("s_ID").ToString.Replace("'", "''") & "'" & "and UID ='" & UID.Replace("'", "''") & "'")
                    If Df1.Length = 0 Then
                        sql = "Insert into PR_FunRight_EXT(UID,FuncID,R,U,A,D)values(N'" & UID.Replace("'", "''") & "','" & sFuncID.Replace("'", "''") & "',1,0,0,0)"
                        execSQL(sql)
                    End If
                Next

                sql = "update PR_FunRight_EXT set R=1 where UID='" & User.Replace("'", "''") & "'"
                execSQL(sql)

            Catch ex As Exception
                MsgBox("Set quyền mặc định cho kho bi lỗi !")
                Return False
            End Try

        End If

        Return True
    End Function
End Class
