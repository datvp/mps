Public Class DALSecUser
    Inherits DALSQL
    Public Function getList() As DataTable
        Return Me.getTableSQL("Exec sp_getList_USER")
    End Function
    '25/5/09
    Public Function getListUser(ByVal IDGroup As String) As DataTable
        Dim sql As String = "Exec sp_getList_USER_new @IDGroup"
        Dim p(0) As SqlClient.SqlParameter
        p(0) = New SqlClient.SqlParameter("@IDGroup", IDGroup)
        Return Me.getTableSQL(sql, p)
    End Function

    'THÊM MỚI-HIỆU CHỈNH NGƯỜI DÙNG**************
    Public Function UPDATEDB(ByVal m As Model.MSecUser) As Boolean
        If CheckDulicate(m.UID, m.IDSort) Then
            Return False
        End If
        Dim p(11) As SqlClient.SqlParameter
        p(0) = New SqlClient.SqlParameter("@UID", m.UID)
        p(1) = New SqlClient.SqlParameter("@CreateDate", m.CreateDate)
        p(2) = New SqlClient.SqlParameter("@IDSort", m.IDSort)
        p(3) = New SqlClient.SqlParameter("@isAdmin", m.isAdmin)
        p(4) = New SqlClient.SqlParameter("@Note", m.Note)
        p(5) = New SqlClient.SqlParameter("@PWD", m.PWD)
        p(6) = New SqlClient.SqlParameter("@Valid", m.Valid)
        p(7) = New SqlClient.SqlParameter("@GroupUser", m.GroupUser)
        p(8) = New SqlClient.SqlParameter("@Employees", m.Employees)
        p(9) = New SqlClient.SqlParameter("@isViewAllBranch", m.isViewAllBranch)
        p(10) = New SqlClient.SqlParameter("@isViewAllStore", m.isViewAllStore)

        Dim sql As String = ""
        If m.IDSort = 0 Then
            sql = "Insert into LS_USER(isViewAllBranch,isViewAllStore,s_UID,b_Valid,dt_CreateDate,s_PWD,s_Note,b_isAdmin,s_Group_ID,s_Employee_ID)"
            sql += "values(@isViewAllBranch,@isViewAllStore,@UID,@Valid,getdate(),@PWD,@Note,@isAdmin,@GroupUser,@Employees)"
        Else
            sql = "Update LS_USER set isViewAllBranch=@isViewAllBranch,isViewAllStore=@isViewAllStore,s_UID=@UID,b_Valid=@Valid"
            sql += ",s_Note=@Note,b_isAdmin=@isAdmin,s_Group_ID=@GroupUser,s_Employee_ID=@Employees where i_IDSort=@IDSort"
            Dim m1 As Model.MSecUser = getInfo(m.UID)
            If m1.UID <> "" Then
                p(11) = New SqlClient.SqlParameter("@UIDOld", m1.UID)
                sql += vbCrLf
                sql += " Update PR_Events set s_UID=@UID where s_UID=@UIDOld"
            End If
            m1 = Nothing
        End If
        Return Me.execSQL(sql, p)
    End Function

    'XÓA NGƯỜI DÙNG
    Public Function DeleteDB(ByVal UID As String) As Boolean
        Dim p(0) As SqlClient.SqlParameter
        p(0) = New SqlClient.SqlParameter("@UID", UID)
        Dim sql As String = "Exec sp_Delete_USER @UID" 
        Return Me.execSQL(sql, p)
    End Function

    'KIỂM TRA TRƯỚC KHI LƯU**************
    'Kiểm tra mã người dùng khi thêm mới/hiệu chỉnh
    Public Function CheckDulicate(ByVal UID As String, ByVal IDSort As Integer) As Boolean
        Dim p(1) As SqlClient.SqlParameter
        p(0) = New SqlClient.SqlParameter("@UID", UID)
        p(1) = New SqlClient.SqlParameter("@IDSort", IDSort)
        Dim sql As String = "Exec sp_CheckDulicate_USER @IDSort,@UID"
        
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb Is Nothing Then
            Return True
        Else
            If tb.Rows.Count > 0 Then
                Return True
            End If
        End If
        Return False
    End Function

    'THAY ĐỔI MẬT KHẨU NGƯỜI DÙNG***************
    Public Function ChangePWD(ByVal UID As String, ByVal PWD As String) As Boolean
        Dim p(1) As SqlClient.SqlParameter
        p(0) = New SqlClient.SqlParameter("@UID", UID)
        p(1) = New SqlClient.SqlParameter("@PWD", PWD)
        Dim sql As String = "Exec sp_ChangePWD_USER @UID,@PWD"

        Return Me.execSQL(sql, p)
    End Function

    'LẤY THÔNG TIN CHI TIẾT NGƯỜI DÙNG**************
    Public Function getInfo(ByVal UID As String) As Model.MSecUser
        Dim m As New Model.MSecUser
        Dim p(0) As SqlClient.SqlParameter
        p(0) = New SqlClient.SqlParameter("@UID", UID)
        Dim sql As String = "Exec sp_getInfo_USER @UID"
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If Not tb Is Nothing Then
            If tb.Rows.Count > 0 Then
                m.isAdmin = IsNull(tb.Rows(0)("b_isAdmin"), False)
                m.UID = IsNull(tb.Rows(0)("s_UID"), "")
                m.Valid = IsNull(tb.Rows(0)("b_Valid"), False)
                m.CreateDate = IsNull(tb.Rows(0)("dt_CreateDate"), Now)
                m.PWD = IsNull(tb.Rows(0)("s_PWD"), "")
                m.Note = IsNull(tb.Rows(0)("s_Note"), "")
                m.IDSort = IsNull(tb.Rows(0)("i_IDSort"), 0)
                m.GroupUser = IsNull(tb.Rows(0)("s_Group_ID"), "")
                m.Employees = IsNull(tb.Rows(0)("s_Employee_ID"), "")
                m.isViewAllBranch = IsNull(tb.Rows(0)("isViewAllBranch"), False)
                m.isViewAllStore = IsNull(tb.Rows(0)("isViewAllStore"), False)
            End If
        End If
        Return m
    End Function
    'Lấy thông tin nhóm người dùng
    Public Function getListGroupUser() As DataTable
        Dim clsgroup As New DALLs_GroupUser
        Dim tb As DataTable = clsgroup.Getlist
        If Not IsNothing(tb) Then
            Dim dr As DataRow
            dr = tb.NewRow
            dr("s_ID") = "-1"
            dr("s_Group_ID") = m_AddNew
            dr("s_Group_Name") = " "
            tb.Rows.InsertAt(dr, 0)
        End If


        Return tb
    End Function

    'Lấy thông tin nhân viên
    Public Function getListEmployees() As DataTable
        Dim clsEmployees As New DALLS_Employees
        Dim tb As DataTable = clsEmployees.getList
        If Not IsNothing(tb) Then
            Dim dr As DataRow
            dr = tb.NewRow
            dr("s_ID") = "-1"
            dr("s_Employee_ID") = m_AddNew
            dr("s_Name") = " "
            tb.Rows.InsertAt(dr, 0)
            tb.DefaultView.RowFilter = "dt_Holidays is null"
        End If

        Return tb
    End Function
End Class
