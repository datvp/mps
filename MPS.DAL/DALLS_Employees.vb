Imports System.Data.SqlClient
Public Class DALLS_Employees
    Inherits DALSQL
    Public Function CheckExist(ByVal s_ID As String, ByVal isCode As Boolean) As Boolean
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@s_ID", s_ID)
        Dim sql As String = "Select count(*) as c from LS_Employees where s_Employee_ID=@s_ID"
        If Not isCode Then
            sql = "Select count(*) as c from LS_Employees where s_ID=@s_ID"
        End If
        Dim tb As DataTable = getTableSQL(sql, p)
        If Not tb Is Nothing Then
            If tb.Rows(0)("c") = 0 Then
                Return False
            End If
        End If
        Return True
    End Function
    Public Function UPDATEDB_HQ(ByVal m As Model.MLS_Employees, ByVal isCheckCode As Boolean) As Boolean
        Dim sql As String = ""
        Dim sVal As String = ""

        Dim p(27) As SqlParameter
        Dim fExist As Boolean
        If isCheckCode Then
            fExist = CheckExist(m.s_Employee_ID, isCheckCode)
        Else
            fExist = CheckExist(m.s_ID, isCheckCode)
        End If

        If Not fExist Then
            If m.s_ID = "" Then m.s_ID = Me.getNewID
            sql = "Insert into [LS_Employees]([s_ID], [s_Employee_ID], [s_Name], [s_Address], [s_Phone1], "
            sql += " [s_Phone2], [s_Note], [s_Email], [b_Sex],[s_Reason], [m_BasicSalary],  "
            sql += " [i_NofDay], [m_SalaryOf],[s_Currency1],[s_Currency2],[b_IsActive],[b_IsSales],"
            sql += "  [s_UserCreate], [dt_Create], [s_UserEdit], [dt_LastUpdate] "
            sVal = " VALUES(@s_ID, @s_Employee_ID, @s_Name, @s_Address, @s_Phone1,@s_Phone2, @s_Note,"
            sVal += " @s_Email, @b_Sex,@s_Reason, @m_BasicSalary, @i_NofDay, @m_SalaryOf, "
            sVal += " @s_Currency1,@s_Currency2, @b_IsActive,@b_IsSales,"
            sVal += " @s_UserCreate, @dt_Create, @s_UserEdit, @dt_LastUpdate"

            If Not m.im_Photo Is Nothing Then
                sql += ", [im_Photo]"
                sVal += ", @im_Photo"
                p(11) = New SqlParameter("@im_Photo", m.im_Photo)
            End If

            If m.dt_DOB.Year <> 1900 Then
                sql += ", [dt_DOB]"
                sVal += ", @dt_DOB"
            End If

            If m.i_Position <> 0 Then
                sql += ", [i_Position]"
                sVal += ", @i_Position"
            End If

            If m.dt_DaysToWork.Year <> 1900 Then
                sql += ", [dt_DaysToWork]"
                sVal += ", @dt_DaysToWork"
            End If

            If m.dt_Holidays.Year <> 1900 Then
                sql += ", [dt_Holidays]"
                sVal += ", @dt_Holidays"
            End If

            sql = sql & ")" & sVal & ")"
        Else
            Dim s As String = ""
            If Not m.im_Photo Is Nothing Then
                s += ",[im_Photo]=@im_Photo"
                p(11) = New SqlParameter("@im_Photo", m.im_Photo)
            Else
                s += ",[im_Photo]=null"
            End If

            If m.i_Position <> 0 Then
                s += ", [i_Position]=@i_Position"
            End If

            If m.dt_DOB.Year <> 1900 Then
                s += ",[dt_DOB]=@dt_DOB"
            Else
                s += ",[dt_DOB]=null"
            End If

            If m.dt_DaysToWork.Year <> 1900 Then
                s += ",[dt_DaysToWork]=@dt_DaysToWork"
            Else
                s += ",[dt_DaysToWork]=null"
            End If

            If m.dt_Holidays.Year <> 1900 Then
                s += ",[dt_Holidays]=@dt_Holidays"
            Else
                s += ",[dt_Holidays]=null"
            End If

            sql = "Update [LS_Employees] set [s_Employee_ID]=@s_Employee_ID, [s_Name]=@s_Name,"
            sql += " [s_Address]=@s_Address, [s_Phone1]=@s_Phone1, [s_Phone2]=@s_Phone2, [s_Note]=@s_Note,"
            sql += " [s_Email]=@s_Email, [b_Sex]=@b_Sex,[b_IsSales]=@b_IsSales" & s & ","
            sql += " [s_Reason]=@s_Reason, [m_BasicSalary]=@m_BasicSalary, [i_NofDay]=@i_NofDay,"
            sql += " [m_SalaryOf]=@m_SalaryOf,[s_Currency1]=@s_Currency1,[s_Currency2]=@s_Currency2,[b_IsActive]=@b_IsActive, "
            sql += " [s_UserCreate]=@s_UserCreate,[s_UserEdit]=@s_UserEdit, [dt_LastUpdate]=getdate()"

            If isCheckCode Then
                sql += ",s_ID=@s_ID"
                sql += " where [s_Employee_ID]=@s_Employee_ID "
            Else
                sql += "  where s_ID=@s_ID "
            End If
        End If


        p(0) = New SqlParameter("@s_ID", m.s_ID)
        p(1) = New SqlParameter("@s_Employee_ID", m.s_Employee_ID)
        p(2) = New SqlParameter("@s_Name", m.s_Name)
        p(3) = New SqlParameter("@s_Address", m.s_Address)
        p(4) = New SqlParameter("@s_Phone1", m.s_Phone1)
        p(5) = New SqlParameter("@s_Phone2", m.s_Phone2)
        p(6) = New SqlParameter("@s_Note", m.s_Note)
        p(7) = New SqlParameter("@i_Ordinal", m.i_Ordinal)
        p(8) = New SqlParameter("@s_Email", m.s_Email) '26.05.09        p(9) = New SqlParameter("@i_Position", m.i_Position)        p(10) = New SqlParameter("@b_Sex", m.b_Sex)        If Not m.im_Photo Is Nothing Then
            p(11) = New SqlParameter("@im_Photo", m.im_Photo)
        End If        p(12) = New SqlParameter("@dt_DOB", m.dt_DOB)
        p(13) = New SqlParameter("@dt_DaysToWork", m.dt_DaysToWork)
        p(14) = New SqlParameter("@dt_Holidays", m.dt_Holidays)        p(15) = New SqlParameter("@s_Reason", m.s_Reason)        p(16) = New SqlParameter("@m_BasicSalary", m.m_BasicSalary)        p(17) = New SqlParameter("@i_NofDay", m.i_NofDay)        p(18) = New SqlParameter("@m_SalaryOf", m.m_SalaryOf)        p(19) = New SqlParameter("@s_Currency1", m.s_Currency1)        p(20) = New SqlParameter("@s_Currency2", m.s_Currency2)        p(21) = New SqlParameter("@b_IsActive", m.b_IsActive)        p(22) = New SqlParameter("@s_UserCreate", m.s_UserCreate)        p(23) = New SqlParameter("@dt_Create", m.dt_Create)        p(24) = New SqlParameter("@s_UserEdit", m.s_UserEdit)        p(25) = New SqlParameter("@dt_LastUpdate", m.dt_LastUpdate)
        p(26) = New SqlParameter("@b_IsSales", m.b_IsSales)

        Return Me.execSQL(sql, p)
    End Function
    Public Function UPDATEDB(ByVal m As Model.MLS_Employees) As Boolean
        Dim sql As String = ""
        Dim sVal As String = ""

        If CheckDulicate(m.s_Employee_ID, m.s_ID) Then
            Return False
        End If

        Dim p(30) As SqlParameter

        If m.s_ID = "" Then
            m.s_ID = Me.getNewID
            sql = "Insert into [LS_Employees](IsCTV, ReferrerId, [s_ID], [s_Employee_ID], [s_Name], [s_Address], [s_Phone1], "
            sql += " [s_Phone2], [s_Note], [s_Email], [b_Sex],[s_Reason], [m_BasicSalary],  "
            sql += " [i_NofDay], [m_SalaryOf],[s_Currency1],[s_Currency2],[b_IsActive],[b_IsSales],"
            sql += "  [s_UserCreate], [dt_Create], [s_UserEdit], [dt_LastUpdate],[s_AccountID] "
            sVal = " VALUES(@IsCTV, @ReferrerId, @s_ID, @s_Employee_ID, @s_Name, @s_Address, @s_Phone1,@s_Phone2, @s_Note,"
            sVal += " @s_Email, @b_Sex,@s_Reason, @m_BasicSalary, @i_NofDay, @m_SalaryOf, "
            sVal += " @s_Currency1,@s_Currency2, @b_IsActive,@b_IsSales,"
            sVal += " @s_UserCreate, @dt_Create, @s_UserEdit, @dt_LastUpdate,@s_AccountID"

            If Not m.im_Photo Is Nothing Then
                sql += ", [im_Photo]"
                sVal += ", @im_Photo"
                p(11) = New SqlParameter("@im_Photo", m.im_Photo)
            End If

            If m.dt_DOB.Year <> 1900 Then
                sql += ", [dt_DOB]"
                sVal += ", @dt_DOB"
            End If

            If m.i_Position <> 0 Then
                sql += ", [i_Position]"
                sVal += ", @i_Position"
            End If

            If m.dt_DaysToWork.Year <> 1900 Then
                sql += ", [dt_DaysToWork]"
                sVal += ", @dt_DaysToWork"
            End If

            If m.dt_Holidays.Year <> 1900 Then
                sql += ", [dt_Holidays]"
                sVal += ", @dt_Holidays"
            End If

            If m.s_Bank_ID <> "" Then
                sql += ", [s_Bank_ID]"
                sVal += ", @s_Bank_ID"
            End If

            sql = sql & ")" & sVal & ")"
        Else
            Dim s As String = ""
            If Not m.im_Photo Is Nothing Then
                s += ",[im_Photo]=@im_Photo"
                p(11) = New SqlParameter("@im_Photo", m.im_Photo)
            Else
                s += ",[im_Photo]=null"
            End If

            If m.i_Position <> 0 Then
                s += ", [i_Position]=@i_Position"
            End If

            If m.dt_DOB.Year <> 1900 Then
                s += ",[dt_DOB]=@dt_DOB"
            Else
                s += ",[dt_DOB]=null"
            End If

            If m.dt_DaysToWork.Year <> 1900 Then
                s += ",[dt_DaysToWork]=@dt_DaysToWork"
            Else
                s += ",[dt_DaysToWork]=null"
            End If

            If m.dt_Holidays.Year <> 1900 Then
                s += ",[dt_Holidays]=@dt_Holidays"
            Else
                s += ",[dt_Holidays]=null"
            End If
            If m.s_Bank_ID <> "" Then
                s += ",[s_Bank_ID]=@s_Bank_ID"
            Else
                s += ",[s_Bank_ID]=null"
            End If

            sql = "Update [LS_Employees] set IsCTV=@IsCTV, ReferrerId=@ReferrerId, [s_Employee_ID]=@s_Employee_ID, [s_Name]=@s_Name,"
            sql += " [s_Address]=@s_Address, [s_Phone1]=@s_Phone1, [s_Phone2]=@s_Phone2, [s_Note]=@s_Note,"
            sql += " [s_Email]=@s_Email, [b_Sex]=@b_Sex,[b_IsSales]=@b_IsSales" & s & ","
            sql += " [s_Reason]=@s_Reason, [m_BasicSalary]=@m_BasicSalary, [i_NofDay]=@i_NofDay,"
            sql += " [m_SalaryOf]=@m_SalaryOf,[s_Currency1]=@s_Currency1,[s_Currency2]=@s_Currency2,[b_IsActive]=@b_IsActive, "
            sql += " [s_UserCreate]=@s_UserCreate,[s_UserEdit]=@s_UserEdit, [dt_LastUpdate]=getdate(),[s_AccountID]=@s_AccountID"
            sql += " where [s_ID]=@s_ID"
        End If

        p(0) = New SqlParameter("@s_ID", m.s_ID)
        p(1) = New SqlParameter("@s_Employee_ID", m.s_Employee_ID)
        p(2) = New SqlParameter("@s_Name", m.s_Name)
        p(3) = New SqlParameter("@s_Address", m.s_Address)
        p(4) = New SqlParameter("@s_Phone1", m.s_Phone1)
        p(5) = New SqlParameter("@s_Phone2", m.s_Phone2)
        p(6) = New SqlParameter("@s_Note", m.s_Note)
        p(7) = New SqlParameter("@i_Ordinal", m.i_Ordinal)
        p(8) = New SqlParameter("@s_Email", m.s_Email) '26.05.09        p(9) = New SqlParameter("@i_Position", m.i_Position)        p(10) = New SqlParameter("@b_Sex", m.b_Sex)        If Not m.im_Photo Is Nothing Then
            p(11) = New SqlParameter("@im_Photo", m.im_Photo)
        End If        p(12) = New SqlParameter("@dt_DOB", m.dt_DOB)
        p(13) = New SqlParameter("@dt_DaysToWork", m.dt_DaysToWork)
        p(14) = New SqlParameter("@dt_Holidays", m.dt_Holidays)        p(15) = New SqlParameter("@s_Reason", m.s_Reason)        p(16) = New SqlParameter("@m_BasicSalary", m.m_BasicSalary)        p(17) = New SqlParameter("@i_NofDay", m.i_NofDay)        p(18) = New SqlParameter("@m_SalaryOf", m.m_SalaryOf)        p(19) = New SqlParameter("@s_Currency1", m.s_Currency1)        p(20) = New SqlParameter("@s_Currency2", m.s_Currency2)        p(21) = New SqlParameter("@b_IsActive", m.b_IsActive)        p(22) = New SqlParameter("@s_UserCreate", m.s_UserCreate)        p(23) = New SqlParameter("@dt_Create", m.dt_Create)        p(24) = New SqlParameter("@s_UserEdit", m.s_UserEdit)        p(25) = New SqlParameter("@dt_LastUpdate", m.dt_LastUpdate)
        p(26) = New SqlParameter("@b_IsSales", m.b_IsSales)
        p(27) = New SqlParameter("@s_Bank_ID", m.s_Bank_ID)
        p(28) = New SqlParameter("@s_AccountID", m.s_AccountID)
        p(29) = New SqlParameter("@IsCTV", m.IsCTV)
        p(30) = New SqlParameter("@ReferrerId", m.ReferrerId)
        Return Me.execSQL(sql, p)
    End Function
    Public Function DELETEDB(ByVal ID As String) As Boolean
        If Not isDelete(ID) Then
            Return False
        End If
        Dim sql As String
        sql = "Exec sp_Delete_Employees @s_ID"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@s_ID", ID)
        Return Me.execSQL(sql, p)

    End Function

    Public Function CheckDulicate(ByVal ID As String, ByVal s_ID As String) As Boolean
        Dim sql As String = "Exec sp_CheckDulicate_Employees @s_ID,@ID"


        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        p(1) = New SqlParameter("@s_ID", s_ID)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb Is Nothing Then Return False
        If tb.Rows(0)("c") > 0 Then
            Return True
        End If

    End Function
    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk As Boolean = True
        Dim sql As String = "Exec sp_CheckDelete_Employees @s_ID"

        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@s_ID", ID)
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

    Public Function getList() As DataTable
        Dim sql As String = "Exec sp_getList_Employees"
        Return Me.getTableSQL(sql)
    End Function
    Public Function getListReferrer(ByVal empId As String) As DataTable
        Dim sql As String = "select s_ID,s_Employee_ID,s_Name from Ls_Employees where isnull(isCTV,0)=0"
        If empId <> "" Then
            sql += " and s_ID<>@empId"
        End If
        Return Me.getTableSQL(sql, New SqlParameter("@empId", empId))
    End Function
    Public Function getListCTV(ByVal empId As String) As DataTable
        Dim sql As String = "select s_ID,s_Employee_ID,s_Name from Ls_Employees where isnull(isCTV,0)=1"
        If empId <> "" Then
            sql += " and ReferrerId=@empId"
        End If
        Return Me.getTableSQL(sql, New SqlParameter("@empId", empId))
        Return Me.getTableSQL(sql)
    End Function


    Public Function getListActive() As DataTable
        Dim sql As String = "select * from ls_Employees where dt_Holidays is null and b_isActive=1"
        Dim tb = Me.getTableSQL(sql)
        If Not IsNothing(tb) Then
            tb.DefaultView.Sort = "s_Name asc"
        End If
        Return tb
    End Function
    Public Function getItemUpload(ByVal ID As String) As DataTable
        Dim sql As String = "Select e.*,p.s_Name as Position from LS_Employees e left join  Ls_Position p on e.i_Position=p.i_ID where e.s_ID=@ID Order by e.s_Employee_ID asc"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        Return Me.getTableSQL(sql, p)
    End Function
    Public Function getList(ByVal dayMonth As Date) As DataTable
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@dayMonth", dayMonth)
        Dim sql As String = "Exec sp_getList_Employees_Active @dayMonth"
        Return Me.getTableSQL(sql, p)
    End Function

    Public Function getInfo(ByVal ID As String) As Model.MLS_Employees
        Dim m As New Model.MLS_Employees
        Dim sql As String = "Exec sp_getInfo_Employees @s_ID"

        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@s_ID", ID)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If Not tb Is Nothing Then
            If tb.Rows.Count > 0 Then
                m.s_ID = IsNull(tb.Rows(0)("s_ID"), "")
                m.s_Employee_ID = IsNull(tb.Rows(0)("s_Employee_ID"), "")
                m.s_Name = IsNull(tb.Rows(0)("s_Name"), "")
                m.s_Address = IsNull(tb.Rows(0)("s_Address"), "")
                m.s_Phone1 = IsNull(tb.Rows(0)("s_Phone1"), "")
                m.s_Phone2 = IsNull(tb.Rows(0)("s_Phone2"), "")
                m.s_Note = IsNull(tb.Rows(0)("s_Note"), "")
                m.i_Ordinal = IsNull(tb.Rows(0)("i_Ordinal"), 0)
                m.s_Email = IsNull(tb.Rows(0)("s_Email"), "") '26.05.09->tu day xuong duoi
                m.i_Position = IsNull(tb.Rows(0)("i_Position"), 0)
                m.b_Sex = IsNull(tb.Rows(0)("b_Sex"), False)
                m.im_Photo = IsNull(tb.Rows(0)("im_Photo"), Nothing)
                m.dt_DOB = IsNull(tb.Rows(0)("dt_DOB"), CDate("1900-1-1"))
                m.dt_DaysToWork = IsNull(tb.Rows(0)("dt_DaysToWork"), CDate("1900-1-1"))
                m.dt_Holidays = IsNull(tb.Rows(0)("dt_Holidays"), CDate("1900-1-1"))
                m.s_Reason = IsNull(tb.Rows(0)("s_Reason"), "")
                m.m_BasicSalary = IsNull(tb.Rows(0)("m_BasicSalary"), 0)
                m.i_NofDay = IsNull(tb.Rows(0)("i_NofDay"), 0)
                m.m_SalaryOf = IsNull(tb.Rows(0)("m_SalaryOf"), 0)
                m.s_Currency1 = IsNull(tb.Rows(0)("s_Currency1"), "")
                m.s_Currency2 = IsNull(tb.Rows(0)("s_Currency2"), "")
                m.b_IsActive = IsNull(tb.Rows(0)("b_IsActive"), False)
                m.s_UserCreate = IsNull(tb.Rows(0)("s_UserCreate"), "")
                m.dt_Create = IsNull(tb.Rows(0)("dt_Create"), CDate("1900-1-1"))
                m.s_UserEdit = IsNull(tb.Rows(0)("s_UserEdit"), "")
                m.dt_LastUpdate = IsNull(tb.Rows(0)("dt_LastUpdate"), CDate("1900-1-1"))
                m.b_IsSales = IsNull(tb.Rows(0)("b_IsSales"), False)
                m.s_Bank_ID = IsNull(tb.Rows(0)("s_Bank_ID"), "")
                m.s_AccountID = IsNull(tb.Rows(0)("s_AccountID"), "")
                m.IsCTV = IsNull(tb.Rows(0)("IsCTV"), False)
                m.ReferrerId = IsNull(tb.Rows(0)("ReferrerId"), "")
            End If
        End If
        Return m
    End Function

    'LẤY MÃ HÀNG THEO ĐIỀU KIỆN DUYỆT: ĐẦU, CUỐI, TRƯỚC ĐÓ, KẾ TIẾP
    Public Function getIDItem(ByVal IDSort As Double, ByVal nCase As Integer) As String
        Dim s_ID As String = ""
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@IDSort", IDSort)
        p(1) = New SqlParameter("@nCase", nCase)

        Dim sql As String = "Exec sp_getIDItem_Employees @IDSort,@nCase"

        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If Not tb Is Nothing Then
            If tb.Rows.Count > 0 Then
                s_ID = tb.Rows(0)("s_ID")
            End If
        End If
        Return s_ID

    End Function
    Public Function getCode(ByVal CodeID As String) As String
        Dim sql As String = "Select s_ID from LS_Employees where s_Employee_ID=@CodeID"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@CodeID", CodeID)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb.Rows.Count > 0 Then
            Return tb.Rows(0)("s_ID").ToString
        Else
            Return ""
        End If
    End Function

    Public Function GetName(ByVal CodeID As String) As String
        Dim sql As String = "Select s_Name from LS_Employees where s_ID=@CodeID"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@CodeID", CodeID)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb.Rows.Count > 0 Then
            Return tb.Rows(0)("s_Name").ToString
        Else
            Return ""
        End If
    End Function

    '05/09/09 kiem tra neu nhan vien con phu trach khach hang thi kh cho nghi viec
    Public Function CheckHoliday(ByVal s_ID As String) As Boolean
        Dim sql As String = "select count(s_Employee_ID) as c from LS_Objects where s_Employee_ID=@s_ID"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@s_ID", s_ID)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If tb Is Nothing Then Return False
        If tb.Rows(0)("c") > 0 Then
            Return True 'kh duoc nghi viec
        End If
        Return False
    End Function

    Public Function countItem() As Integer
        Dim sql As String = "SELECT count(*) as c FROM LS_Employees  "
        Dim tb As DataTable = getTableSQL(sql)
        If Not IsNothing(tb) AndAlso tb.Rows.Count > 0 Then
            Return tb.Rows(0)(0)
        End If
        Return 0
    End Function
End Class