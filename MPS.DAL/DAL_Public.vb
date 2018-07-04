Imports System.Data.SqlClient
Imports VsoftBMS

Public Class DAL_Public
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_Public
    Public Shared ReadOnly Property Instance() As DAL_Public
        Get
            If obj Is Nothing Then
                obj = New DAL_Public
            End If
            Return obj
        End Get
    End Property
    Public Function getServerDate() As Date
        Return getTableSQL("Select getDate() as d").Rows(0)("d")
    End Function
    Public Function getAllRecord() As DataSet
        Dim sql As String = ""
        'sql += " Select 'banhang' as sFun,count(*) as c from v_fullorder"
        'sql += " union all"
        sql += " Select 'xuatkhac' as sFun,count(*) as c from Ls_Order_Other where isnull(isConfirm,0)=1"
        sql += " union all"
        sql += " Select 'nhapkhac' as sFun,count(*) as c from Ls_Import_Other where isnull(isConfirm,0)=1"
        sql += " union all"
        sql += " Select 'nhomkhachhang' as sFun,count(*) as c from Ls_ObjectGroups"
        'sql += " union all"
        'sql += " Select 'khachhang' as sFun,count(*) as c from Ls_Objects"
        sql += " union all"
        sql += " Select 'tiente' as sFun,count(*) as c from LS_Currency"
        sql += " union all"
        sql += " Select 'taikhoan' as sFun,count(*) as c from [LS_Banks]"
        sql += " union all"
        sql += " Select 'kyhanthanhtoan' as sFun,count(*) as c from [LS_PaymentTerm]"
        sql += " union all"
        sql += " Select 'phuongthucxuat' as sFun,count(*) as c from [Ls_PaymentOrder]"
        sql += " union all"
        sql += " Select 'phuongthucnhap' as sFun,count(*) as c from [Ls_PaymentImport]"
        sql += " union all"
        sql += " Select 'phuongthucthu' as sFun,count(*) as c from [LS_OtherIncome]"
        sql += " union all"
        sql += " Select 'phuongthucchi' as sFun,count(*) as c from [LS_OtherOutcome]"
        sql += " union all"
        sql += " Select 'quocgia' as sFun,count(*) as c from [LS_Nationalities]"
        sql += " union all"
        sql += " Select 'tinhthanh' as sFun,count(*) as c from [Ls_Provinces]"
        sql += " union all"
        sql += " Select 'quanhuyen' as sFun,count(*) as c from [ls_Districts]"
        sql += " union all"
        sql += " Select 'phieuthu' as sFun,count(*) as c from [Ls_Income]"
        sql += " union all"
        sql += " Select 'phieuchi' as sFun,count(*) as c from [Ls_Outcome]"

        sql += " union all"
        sql += " Select 'baogia' as sFun,count(*) as c from [Ls_Quote]"

        sql += " union all"
        sql += " Select 'dathangxuat' as sFun,0 as c "

        sql += " union all"
        sql += " Select 'dathangnhap' as sFun,0 as c "

        sql += " union all"
        sql += " Select 'nhaphangtra' as sFun,count(*) as c from [Ls_ImportReturns]"

        sql += " union all"
        sql += " Select 'xuattrahang' as sFun,count(*) as c from [Ls_OrderReturns]"

        'sql += " union all"
        'sql += " Select 'xuattam' as sFun,count(*) as c"

        sql += " union all"
        sql += " Select 'nganhhang' as sFun,count(*) as c from [Ls_BranchProduct]"
        sql += " union all"
        sql += " Select 'nhomhang' as sFun,count(*) as c from [Ls_ProductGroups]"
        'sql += " union all"
        'sql += " Select 'hanghoa' as sFun,count(*) as c from [Ls_Products]"

        sql += " union all"
        sql += " Select 'nhanvien' as sFun,count(*) as c from [Ls_Employees]"
        sql += " union all"
        sql += " Select 'phieunhap' as sFun,count(*) as c from [Ls_Imports]"

        sql += " union all"
        sql += " Select 'baogia' as sFun,count(*) as c from [Ls_Quote]"
        sql += " union all"
        sql += " Select 'dathangxuat' as sFun,count(*) as c from [Ls_PurchaseOrders]"
        sql += " union all"
        sql += " Select 'dathangnhap' as sFun,count(*) as c from [Ls_PurchaseImports]"
        sql += " union all"
        sql += " Select 'luanchuyentien' as sFun,count(*) as c from [ls_Transcurr]"

        Return getDatasetSQL(sql)
    End Function
    Public Function RepairtViewDebt() As Boolean
        'Dim sql As String = ""
        'sql = "Select c.i_ID,s_Syscur from tblConfig t,LS_Currency c where t.s_Syscur=c.IDKH_s"
        'Dim tb As DataTable = getTableSQL(sql)
        'Dim Curr As String = ""
        'If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
        '    Curr = tb.Rows(0)("i_ID")
        'End If
        'sql = ""
        'sql = sql & " ALTER view v_NumberIncome " & Chr(13)
        'sql = sql & " as " & Chr(13)

        'sql = sql & " Select ls.s_ID as [Object_ID],ls.s_ID as NumberID,cast(null as SmallDatetime) as dayMonth, " & Chr(13)
        'sql = sql & " ls.m_FirstIncome -isnull(ct.Total,0) as Total ,cast(0 as int) as nCase ,N'Công nợ đầu kỳ' as Note " & Chr(13)
        'sql = sql & " ,N'" & Curr & "' as Curr,1 as Exchange " & Chr(13)

        'sql = sql & " from ls_Objects ls " & Chr(13)
        'sql = sql & " Left outer join  " & Chr(13)
        'sql = sql & " (Select Pr.s_NumberID as s_Object_ID,sum(pr.m_Total) as Total from pr_NumberIncome pr group by Pr.s_NumberID) as ct " & Chr(13)
        'sql = sql & " On ls.s_ID=ct.s_Object_ID   " & Chr(13)
        'sql = sql & " where b_Customer=1 " & Chr(13)

        'sql = sql & "  union all " & Chr(13)

        'sql = sql & " Select v.s_ObjectID as [Object_ID],s_ID as NumberID,v.dt_OrderDate as dayMonth,(v.m_OrderTotal -isnull(ct.Total,0)) as Total,  " & Chr(13)
        'sql = sql & " cast(1 as int) as nCase,N'Xuất bán hàng' as Note " & Chr(13)
        'sql = sql & " ,isnull(v.Curr,N'" & Curr & "') as Curr,isnull(v.Exchange,1) as Exchange " & Chr(13)
        'sql = sql & " from V_FullOrder v        " & Chr(13)
        'sql = sql & " left outer join        " & Chr(13)
        'sql = sql & " (Select s_NumberID,sum(m_Total) as Total from pr_NumberIncome group by s_NumberID) as ct " & Chr(13)
        'sql = sql & "  On v.s_ID=s_NumberID " & Chr(13)
        'If Not execSQL(sql) Then
        '    Return False
        'End If
        'sql = " ALTER VIEW V_NumberIncomeNew" & Chr(13)
        'sql = sql & "  as      " & Chr(13)
        'sql = sql & "   select v.*, v.Total-ISNULL(pr.m_totalpay,0) as TotalNew      " & Chr(13)
        'sql = sql & "   from V_NumberIncome v left outer join V_OrderImportReturnPay pr on v.numberid=pr.OrderID" & Chr(13)
        'If Not execSQL(sql) Then
        '    Return False
        'End If

        'sql = ""
        'sql = sql & " ALTER view v_NumberOutcome  " & Chr(13)
        'sql = sql & " as " & Chr(13)

        'sql = sql & "  Select ls.s_ID as [Object_ID],ls.s_ID as NumberID,cast(null as SmallDatetime) as dayMonth, " & Chr(13)
        'sql = sql & "  ls.m_FirstOutcome -isnull(ct.Total,0) as Total ,cast(0 as int) as nCase,N'Công nợ đầu kỳ' as Note  " & Chr(13)
        'sql = sql & " ,N'" & Curr & "' as Curr,1 as Exchange " & Chr(13)
        'sql = sql & "  from ls_Objects ls " & Chr(13)
        'sql = sql & "   Left outer join   " & Chr(13)
        'sql = sql & "   (Select pr.s_NumberID as s_Object_ID,sum(pr.m_Total) as Total from pr_NumberOutcome pr group by pr.s_NumberID) as ct " & Chr(13)
        'sql = sql & "   On ls.s_ID=ct.s_Object_ID " & Chr(13)

        'sql = sql & "  where b_Supplier=1 " & Chr(13)

        'sql = sql & "  union all " & Chr(13)

        'sql = sql & " Select v.s_Object_ID as [Object_ID],s_ID as NumberID,v.dt_ImportDate as dayMonth,(v.m_ImportTotal -isnull(ct.Total,0)) as Total  " & Chr(13)
        'sql = sql & " ,cast(1 as int) as nCase,N'Nhập hàng' as Note  "
        'sql = sql & " ,isnull(v.Curr,N'" & Curr & "') as Curr,isnull(v.Exchange,1) as Exchange " & Chr(13)
        'sql = sql & " from Ls_Imports v " & Chr(13)

        'sql = sql & " left outer join " & Chr(13)
        'sql = sql & " (Select s_NumberID,sum(m_Total) as Total from pr_NumberOutcome group by s_NumberID) as ct " & Chr(13)

        'sql = sql & " On v.s_ID=s_NumberID " & Chr(13)
        'If Not execSQL(sql) Then
        '    Return False
        'End If

        'sql = " ALTER VIEW V_NumberOutcomeNew    " & Chr(13)
        'sql = sql & " as    " & Chr(13)
        'sql = sql & " select v.*, v.Total-ISNULL(pr.m_totalpay,0) as TotalNew    " & Chr(13)
        'sql = sql & " from V_NumberOutcome v left outer join V_ImportOrderReturnPay pr on v.numberid=pr.importid" & Chr(13)
        'If Not execSQL(sql) Then
        '    Return False
        'End If

        Return True
    End Function

    Public Function getNumberID(ByVal iTypeNumber As Integer, ByVal dayMonth As Date, ByVal branchId As String) As String()
        Dim s(1) As String
        s(0) = ""
        s(1) = ""
        Dim sql As String = "Select top 1 * from tblConfigNumber where i_TypeNumber=@s_TypeNumber"
        Dim tb As DataTable = getTableSQL(sql, New SqlParameter("@s_TypeNumber", iTypeNumber))
        If tb.Rows.Count > 0 Then
            Dim s_Prefix As String = IsNull(tb.Rows(0)("s_Prefix"), "")
            Dim s_Format As String = IsNull(tb.Rows(0)("s_Format"), "")
            Dim i_PositionPrefix As Integer = IsNull(tb.Rows(0)("i_PositionPrefix"), 0)

            Dim Part2 As String = Format(dayMonth, s_Format).Replace("/", String.Empty)
            If s_Prefix <> "" Then
                If i_PositionPrefix = 0 Then
                    Part2 = s_Prefix & Part2
                Else
                    Part2 = Part2 & s_Prefix
                End If
            End If

            If branchId <> "" Then
                Part2 = Part2 & branchId
            End If

            Dim arrs() As String = getTableColumn(iTypeNumber)
            If arrs.Length > 1 Then
                Dim sTable As String = arrs(0).ToString()
                Dim sCol As String = arrs(1).ToString()
                sql = "Select isnull(Max(cast(left([" & sCol & "],charindex('-',[" & sCol & "],1) -1)as numeric)),0)+1 as i_MaxNumber"
                sql += " from [" & sTable & "] where charindex('-',[" & sCol & "],1)>0 and isnumeric(left([" & sCol & "],charindex('-',[" & sCol & "],1) -1))=1 "
                sql += " and Right([" & sCol & "],Len([" & sCol & "])-charindex('-',[" & sCol & "],1))=@Part2"
                tb = getTableSQL(sql, New SqlParameter("@Part2", Part2))
                If tb IsNot Nothing Then
                    s(0) = tb.Rows(0)("i_MaxNumber").ToString
                    s(1) = Part2
                End If
            End If
        End If

        Return s
    End Function
    Public Function getListConfigNumber() As DataTable
        Dim sql As String = "Select * from tblConfigNumber"
        Dim tb As DataTable = getTableSQL(sql)
        Return tb
    End Function

    Public Function getListCloseBook() As DataTable
        Dim sql As String = "Select * from tblLockBook"
        Dim tb As DataTable = getTableSQL(sql)
        Return tb
    End Function

    Public Function UpdateConfigNumber(ByVal tb As DataTable) As Boolean
        For Each dr As DataRow In tb.Rows
            Dim sql As String = ""
            Dim p(4) As SqlParameter
            p(0) = New SqlParameter("@i_TypeNumber", IsNull(dr("i_TypeNumber"), 0))
            p(1) = New SqlParameter("@s_Format", IsNull(dr("s_Format"), ""))
            p(2) = New SqlParameter("@s_Prefix", IsNull(dr("s_Prefix"), ""))
            p(3) = New SqlParameter("@i_PositionPrefix", IsNull(dr("i_PositionPrefix"), 0))
            p(4) = New SqlParameter("@s_TypeNumber", IsNull(dr("s_TypeNumber"), ""))
            sql = " Delete from tblConfigNumber where i_TypeNumber=@i_TypeNumber"
            sql += " Insert into tblConfigNumber(i_TypeNumber,s_TypeNumber,s_Format,s_Prefix,i_PositionPrefix)"
            sql += " values(@i_TypeNumber,@s_TypeNumber,@s_Format,@s_Prefix,@i_PositionPrefix)"
            If Not execSQL(sql, p) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function CheckCloseBook(ByVal ID As Integer, ByVal dayMonth As Date) As Boolean
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        p(1) = New SqlParameter("@dayMonth", dayMonth)
        Dim sql As String = "Select count(*) as C from tblLockBook where [ID]=@ID and Valid=1 and Datediff(day,toDate,@dayMonth)<=0"

        Dim tb As DataTable = getTableSQL(sql, p)
        If tb.Rows(0)("C") > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function UpdateCloseBook(ByVal ID As Integer, ByVal Name As String, ByVal valid As Boolean, ByVal toDate As Date, ByVal Note As String) As Boolean
        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        p(1) = New SqlParameter("@toDate", toDate)
        p(2) = New SqlParameter("@Name", Name)
        p(3) = New SqlParameter("@Valid", valid)
        p(4) = New SqlParameter("@Note", Note)
        Dim sql As String = "Update tblLockBook set Valid=@Valid,[Name]=@Name,toDate=@toDate,Note=@Note where [ID]=@ID"
        Return execSQL(sql, p)
    End Function
    'Public Enum TypeNumber
    '    Import = 0
    '    PurchaseImport = 1
    '    OrderReturn = 2
    '    Outcome = 3
    '    Order = 4
    '    PurchaseOrder = 5
    '    ImportReturn = 6
    '    Income = 7
    '    Quote = 8
    'End Enum
    'Private sd As Date = CDate("1900-1-1")
    Public Function getInfoDebtObject(ByVal Object_ID As String, ByVal isCustomer As Boolean, ByVal dayMonth As Date, Optional ByVal maChiNhanh As String = "") As DataTable
        Dim nDay As Integer = getPaymentTerm(Object_ID)
        Dim tb As New DataTable
        tb.Columns.Add("TotalIncome", GetType(Double))
        tb.Columns.Add("TotalOutcome", GetType(Double))
        tb.Columns.Add("Over 1-30", GetType(Double))
        tb.Columns.Add("Over 31-60", GetType(Double))
        tb.Columns.Add("Over 61-90", GetType(Double))
        tb.Columns.Add("Over 90", GetType(Double))
        tb.Columns.Add("Trade Month", GetType(Double))
        tb.Columns.Add("Trade Year", GetType(Double))
        tb.Columns.Add("Trade Last Year", GetType(Double))
        tb.Columns.Add("Trade All", GetType(Double))
        Dim drN As DataRow = tb.NewRow
        tb.Rows.Add(drN)
        For i As Integer = 0 To tb.Columns.Count - 1
            tb.Rows(0)(i) = 0
        Next
        Dim sTable As String = "V_NumberOutcomeNew"
        If isCustomer Then
            sTable = "V_NumberIncomeNew"
        End If
        Dim sql As String = ""
        Dim p(3) As SqlParameter
        Dim tbl As DataTable
        '
        p(0) = New SqlParameter("@Object_ID", Object_ID)
        p(1) = New SqlParameter("@nDay", nDay)
        p(2) = New SqlParameter("@dayMonth", dayMonth)
        p(3) = New SqlParameter("@MaChiNhanh", maChiNhanh)
        Dim sDate As String = "getdate()"
        If dayMonth.Year <> 1900 Then
            sDate = "@dayMonth"
        End If
        'Tong phai thu
        sql = " Select 0 as iCase, isnull(sum(TotalNew),0) as t from V_NumberIncomeNew where [Object_ID]=@Object_ID"
        If maChiNhanh <> "" Then
            sql += " AND MaChiNhanh=@MaChiNhanh"
        End If
        sql += " Union all"
        'tong phai tra
        sql += " Select 1 as iCase, isnull(sum(TotalNew),0) as t from V_NumberOutcomeNew where [Object_ID]=@Object_ID"
        If maChiNhanh <> "" Then
            sql += " AND MaChiNhanh=@MaChiNhanh"
        End If
        sql += " Union all"
        '1-30
        sql += " Select 2 as iCase, isnull(sum(TotalNew),0) as t from [" & sTable & "] "
        sql += " where Datediff(day,DayMonth," & sDate & ")>=@nDay+1 and Datediff(day,DayMonth," & sDate & ")<=@nDay+30 and [Object_ID]=@Object_ID"
        If maChiNhanh <> "" Then
            sql += " AND MaChiNhanh=@MaChiNhanh"
        End If
        sql += " Union all"
        '31-60
        sql += " Select 3 as iCase, isnull(sum(TotalNew),0) as t from [" & sTable & "] "
        sql += " where Datediff(day,DayMonth," & sDate & ")>=@nDay+31 and Datediff(day,DayMonth," & sDate & ")<=@nDay+60 and [Object_ID]=@Object_ID"
        If maChiNhanh <> "" Then
            sql += " AND MaChiNhanh=@MaChiNhanh"
        End If
        sql += " Union all"
        '61-90
        sql += " Select 4 as iCase, isnull(sum(TotalNew),0) as t from [" & sTable & "] "
        sql += " where Datediff(day,DayMonth," & sDate & ")>=@nDay+61 and Datediff(day,DayMonth," & sDate & ")<=@nDay+90 and [Object_ID]=@Object_ID"
        If maChiNhanh <> "" Then
            sql += " AND MaChiNhanh=@MaChiNhanh"
        End If
        sql += " Union all"
        '>90
        sql += " Select 5 as iCase, isnull(sum(TotalNew),0) as t from [" & sTable & "] "
        sql += " where Datediff(day,DayMonth," & sDate & ")>=@nDay+91 and [Object_ID]=@Object_ID"
        If maChiNhanh <> "" Then
            sql += " AND MaChiNhanh=@MaChiNhanh"
        End If

        If isCustomer Then 'ban
            sql += " Union all "
            sql += " Select 6 as iCase, isnull(sum(m_OrderTotal),0) as t from [v_fullorder] "
            sql += " where Datediff(Month,dt_OrderDate," & sDate & ")=0 and [s_ObjectID]=@Object_ID"
            If maChiNhanh <> "" Then
                sql += " AND s_Col4=@MaChiNhanh"
            End If
            sql += " Union all "
            sql += " Select 7 as iCase, isnull(sum(m_OrderTotal),0) as t from [v_fullorder] "
            sql += " where Datediff(Year,dt_OrderDate," & sDate & ")=0 and [s_ObjectID]=@Object_ID"
            If maChiNhanh <> "" Then
                sql += " AND s_Col4=@MaChiNhanh"
            End If
            sql += " Union all"
            sql += " Select 8 as iCase, isnull(sum(m_OrderTotal),0) as t from [v_fullorder]"
            sql += " where Datediff(Year,dt_OrderDate," & sDate & ")=1 and [s_ObjectID]=@Object_ID"
            If maChiNhanh <> "" Then
                sql += " AND s_Col4=@MaChiNhanh"
            End If
            sql += " Union all"
            sql += " Select 9 as iCase, isnull(sum(m_OrderTotal),0) as t from [v_fullorder]"
            sql += " where [s_ObjectID]=@Object_ID"
            If maChiNhanh <> "" Then
                sql += " AND s_Col4=@MaChiNhanh"
            End If
        Else
            sql += " Union all"
            sql += " Select 6 as iCase, isnull(sum(m_ImportTotal),0) as t from [ls_Imports]"
            sql += " where Datediff(Month,dt_ImportDate," & sDate & ")=0 and [s_Object_ID]=@Object_ID"
            If maChiNhanh <> "" Then
                sql += " AND s_Store_ID=@MaChiNhanh"
            End If
            sql += " Union all"
            sql += " Select 7 as iCase, isnull(sum(m_ImportTotal),0) as t from [ls_Imports]"
            sql += " where Datediff(Year,dt_ImportDate," & sDate & ")=0 and [s_Object_ID]=@Object_ID"
            If maChiNhanh <> "" Then
                sql += " AND s_Store_ID=@MaChiNhanh"
            End If
            sql += " Union all "
            sql += " Select 8 as iCase, isnull(sum(m_ImportTotal),0) as t from [ls_Imports]"
            sql += " where Datediff(Year,dt_ImportDate," & sDate & ")=1 and [s_Object_ID]=@Object_ID"
            If maChiNhanh <> "" Then
                sql += " AND s_Store_ID=@MaChiNhanh"
            End If
            sql += " Union all "
            sql += " Select 9 as iCase, isnull(sum(m_ImportTotal),0) as t from [ls_Imports]"
            sql += " where [s_Object_ID]=@Object_ID"
            If maChiNhanh <> "" Then
                sql += " AND s_Store_ID=@MaChiNhanh"
            End If
        End If

        tbl = getTableSQL(sql, p)
        If Not IsNothing(tbl) Then
            For Each dr As DataRow In tbl.Rows
                Select Case dr("iCase")
                    Case 0
                        tb.Rows(0)("TotalIncome") = dr("t")
                    Case 1
                        tb.Rows(0)("TotalOutcome") = dr("t")
                    Case 2
                        tb.Rows(0)("Over 1-30") = dr("t")
                    Case 3
                        tb.Rows(0)("Over 31-60") = dr("t")
                    Case 4
                        tb.Rows(0)("Over 61-90") = dr("t")
                    Case 5
                        tb.Rows(0)("Over 90") = dr("t")
                    Case 6
                        tb.Rows(0)("Trade Month") = dr("t")
                    Case 7
                        tb.Rows(0)("Trade Year") = dr("t")
                    Case 8
                        tb.Rows(0)("Trade Last Year") = dr("t")
                    Case 9
                        tb.Rows(0)("Trade All") = dr("t")
                End Select
            Next
        End If

        Return tb
    End Function
    Public Function getPaymentTerm(ByVal Object_ID As String) As Integer
        Dim sql As String = "Select isnull(t.i_DayNum,0) as n from ls_Objects ls,LS_PaymentTerm t where ls.s_PaymentTerm=t.s_ID and ls.s_ID=@Object_ID"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@Object_ID", Object_ID)
        Dim tb As DataTable = getTableSQL(sql, p)
        If tb.Rows.Count > 0 Then
            Return tb.Rows(0)("n")
        Else
            Return 0
        End If
    End Function
    Private Function FillImportInstock() As Boolean
        Dim sql As String = ""

        Dim nTimeout As Integer = CommandTimeOut
        CommandTimeOut = 10000
        sql = "Delete from His_InstockImports"
        sql += " Delete from His_InstockImportDetail"
        If Not execSQL(sql) Then
            Dim ssErr As String = ""
        End If

        sql = "Select Product_ID,sum(Exchange*(QImport-QOrder)) as Instock,Cast(0 as money) as Price from v_thekho Group by Product_ID having sum(Exchange*(QImport-QOrder))<>0"
        Dim tbInstock As DataTable = Me.getTableSQL(sql)
        sql = "Select MaNghiepvu,Cast(0 as int) as isChoose, Datediff(day,'2009-1-1',DayMonth) as nD,[ID],IDDetail,Product_ID,QImport*Exchange as QImport,Price/Exchange as Price,DayMonth ,Ordinal ,"
        sql += " i_IDSort from v_thekho where QImport>0 and MaNghiepvu<>'CK' Order by Datediff(day,'2009-1-1',DayMonth) desc,Ordinal asc,i_IDSort desc"
        Dim tbImport As DataTable = getTableSQL(sql)

        If tbInstock Is Nothing Or tbImport Is Nothing Then
            CommandTimeOut = nTimeout
            Return False
        End If
        Dim DF() As DataRow
        For Each drInstock As DataRow In tbInstock.Rows
            Dim Ton As Double = drInstock("Instock")
            DF = tbImport.Select("QImport>0 and Product_ID='" & drInstock("Product_ID").ToString.Replace("'", "''") & "'", "nD desc,Ordinal asc,i_IDSort desc")
            Dim i As Integer = 0
            Dim Total As Double = 0
            While Ton > 0 And i < DF.Length
                If Ton > DF(i)("QImport") Then
                    Total += DF(i)("Price") * DF(i)("QImport")
                    Ton -= DF(i)("QImport")
                    DF(i)("isChoose") = 1
                Else
                    Total += DF(i)("Price") * Ton
                    DF(i)("QImport") = Ton
                    DF(i)("isChoose") = 1
                    Ton = 0
                End If
                i += 1
            End While

            If Ton > 0 Then
                Dim sMsg As String = "Xem lai gia thuat ? khong phan bo het hang ton ?"
            End If
        Next
        Dim tb As New DataTable
        tb.Columns.Add("ID")
        Try
            DF = tbImport.Select("MaNghiepvu<>'DK' and isChoose=1 and QImport>0")
        Catch ex As Exception
            Return False
        End Try


        For Each dr As DataRow In DF
            Dim F() As DataRow = tb.Select("ID='" & dr("ID").ToString.Replace("'", "''") & "'")
            If F.Length = 0 Then
                Dim drN As DataRow = tb.NewRow
                drN("ID") = dr("ID")
                tb.Rows.Add(drN)
                sql = " Insert into [His_InstockImports]( [s_ID],[s_Import_ID],[i_Item_ID],[dt_ImportDate],[s_Object_ID]"
                sql += " ,[s_Object_Name],[s_EmployeeID],[f_VAT],[f_Discount],[m_Discount],[m_TotalReturn],[m_ImportTotal]"
                sql += " ,[b_is_Cash],[s_Store_ID],[s_Note],[s_InfoProduct],[s_SymbolInvoice],[s_Invoice]"
                sql += " ,[s_Word],[i_IDSort],[m_Cost],[m_Exchange],[s_Name],[s_Purchase_ID]"
                sql += " ,[dt_Create],[dt_LastUpdate],[s_UserCreate],[s_UserEdit],[PaymentTermID_s],[b_isDept]"
                sql += " ,[b_isCash],[b_isCashAll],[b_isCashPart],[b_isCashPrepay]"
                sql += " ,[m_Cash],[f_Per],[m_Per],[s_Char])"

                sql += " Select i.[s_ID],i.[s_Import_ID],i.[i_Item_ID],i.[dt_ImportDate],ls.[s_Object_ID]"
                sql += " ,ls.s_Name,i.[s_EmployeeID],i.[f_VAT],i.[f_Discount],i.[m_Discount],0,i.[m_ImportTotal]"
                sql += " ,i.[b_is_Cash],i.[s_Store_ID],i.[s_Note],i.[s_InfoProduct],i.[s_SymbolInvoice],i.[s_Invoice]"
                sql += " ,i.[s_Word],i.[i_IDSort],i.[m_Cost],i.[m_Exchange],i.[s_Name],i.[s_Purchase_ID]"
                sql += " ,i.[dt_Create],i.[dt_LastUpdate],i.[s_UserCreate],i.[s_UserEdit],i.[PaymentTermID_s],i.[b_isDept]"
                sql += " ,i.[b_isCash],i.[b_isCashAll],i.[b_isCashPart],i.[b_isCashPrepay]"
                sql += " ,i.[m_Cash],i.[f_Per],i.[m_Per],i.[s_Char] "
                sql += " from  Ls_Imports i left join Ls_Objects ls"
                sql += " ON i.s_Object_ID=ls.s_ID where i.s_ID='" & dr("ID").ToString.Replace("'", "''") & "'"
                If Not execSQL(sql) Then
                    Dim ssErr As String = ""
                End If
            End If


            sql = " INSERT INTO [His_InstockImportDetail]"
            sql += " ([s_ID],[s_Import_ID],[s_Product_ID],[s_Product_Name]"
            sql += " ,[f_Quantity],[m_Price],[s_Store_ID],[s_Unit],[f_Convert],[f_QuantityOrder]"
            sql += " ,[i_IDsort],[m_PriceUSD],[dt_OverDate],[f_Discount],[m_Discount],[s_Note],[s_Purchase_ID])"

            sql += " Select dt.[s_ID],dt.[s_Import_ID],ls.[s_Product_ID],ls.s_Name"
            sql += " ," & dr("QImport").ToString & "," & dr("Price").ToString & ",dt.[s_Store_ID],ls.[s_Unit],1,dt.[f_QuantityOrder]"
            sql += " ,dt.[i_IDsort],dt.[m_PriceUSD],dt.[dt_OverDate],dt.[f_Discount],dt.[m_Discount],dt.[s_Note],dt.[s_Purchase_ID]"
            sql += " from Pr_ImportDetail dt, Ls_Products ls"
            sql += " where dt.s_Product_ID=ls.s_ID and dt.s_ID='" & dr("IDDetail").ToString.Replace("'", "''") & "'"

            If Not execSQL(sql) Then
                Dim ssErr As String = ""
            End If

        Next

        sql = " Delete from His_StoreProductInstock"
        sql += " Insert into His_StoreProductInstock(Product_IDKey ,s_Product_ID,"
        sql += " Product_Name ,s_Unit ,Store_IDKey ,"
        sql += " s_Store_ID ,Store_Name ,Instock)"
        sql += " Select p.s_ID as Product_IDKey, p.s_Product_ID,p.s_Name as Product_Name,p.s_Unit,"
        sql += " s.s_ID as Store_IDKey,s.s_Store_ID,s.s_Name as Store_Name"
        sql += " ,sum((v.QImport-v.QOrder)*Exchange) as Instock from v_thekho v, ls_Products p, ls_Stores s"
        sql += " where v.Product_ID=p.s_ID and v.Store_ID=s.s_ID"
        sql += " Group by p.s_ID,s.s_ID,p.s_Product_ID,p.s_Name,p.s_Unit,s.s_Store_ID,s.s_Name "
        sql += " having sum((v.QImport-v.QOrder)*Exchange)<>0"
        If Not execSQL(sql) Then
            Dim ssErr As String = ""
        End If

        CommandTimeOut = nTimeout
        Return True

    End Function

    '20.08.2010n cap nhat lai so luong va gia dau ly ==>Ton > 0 : gia binh quan (nhap truoc xuat truoc) tai tat ca kho
    'Ton <=0 : gia o danh muc
    Public Function getTotalInstock(ByVal Store_ID As String, ByVal Product_ID As String, ByVal DayMonth As Date) As Double
        Dim sql As String = ""

        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", DayMonth)
        p(2) = New SqlParameter("@Product_ID", Product_ID)
        If Store_ID <> "" Then
            sql = "Select isnull(sum(Exchange*(QImport-QOrder)),0) as Instock,Store_ID  from v_thekho where Datediff(day,dayMonth,@fromDate)>0 and Store_ID=@Store_ID and Product_ID=@Product_ID Group by Store_ID"
            sql += " Select IDDetail, DayMonth,Datediff(day,'2009-1-1',DayMonth) as nDay,Ordinal,i_IDSort,QImport*Exchange as QImport,OriPrice/Exchange as Price,Store_ID " 'thay Price=OriPrice
            sql += " from v_thekho where Datediff(day,dayMonth,@fromDate)>0 and QImport<>0 and Store_ID=@Store_ID and Product_ID=@Product_ID "
            sql += " Order by Store_ID asc, Datediff(day,'2009-1-1',DayMonth) desc,Ordinal asc,i_IDSort desc"
        Else
            sql = "Select isnull(sum(Exchange*(QImport-QOrder)),0) as Instock,'' as Store_ID from v_thekho where Datediff(day,dayMonth,@fromDate)>0 and Product_ID=@Product_ID"
            sql += " Select IDDetail,DayMonth,Datediff(day,'2009-1-1',DayMonth) as  nDay,Ordinal,i_IDSort,QImport*Exchange as QImport,"
            sql += " OriPrice/Exchange as Price,'' as Store_ID from v_thekho  where Datediff(day,dayMonth,@fromDate)>0  " 'thay Price=OriPrice
            sql += " And Manghiepvu Not in ('NHCK','XHCK')"
            sql += " and QImport<>0 and Product_ID=@Product_ID Order by Datediff(day,'2009-1-1',DayMonth) "
            sql += " desc,Ordinal asc,i_IDSort desc"

        End If
        Dim ds As DataSet = getDatasetSQL(sql, p)
        If ds Is Nothing Then Return 0

        Dim tbInstock As DataTable = ds.Tables(0)

        Dim tbImport As DataTable = ds.Tables(1)

        If tbInstock Is Nothing Or tbImport Is Nothing Then
            Return 0
        End If

        Dim Total As Double = 0
        For Each dr As DataRow In tbInstock.Rows
            Dim i As Integer = 0
            Dim Ton As Double = dr("Instock")
            Dim DF() As DataRow = tbImport.Select("Store_ID='" & dr("Store_ID").ToString.Replace("'", "''") & "'", "nDay desc,Ordinal asc,i_IDSort desc")
            While Ton > 0 And i < DF.Length
                If Ton > DF(i)("QImport") Then
                    Total += DF(i)("Price") * DF(i)("QImport")
                    Ton -= DF(i)("QImport")
                    DF(i)("QImport") = 0
                Else
                    Total += DF(i)("Price") * Ton
                    DF(i)("QImport") -= Ton
                    Ton = 0
                End If
                i += 1
            End While

            If Ton > 0 Then
                Dim sMsg As String = "Xem lại giải thuật ? Không phân bổ hết hàng tồn ?"
            End If
        Next

        Return Total

    End Function

    Public Function getPriceInstock(ByVal Store_ID As String, ByVal Product_ID As String, ByVal DayMonth As Date, ByVal QtyInstock As Double) As Double
        Dim Total As Double = getTotalInstock(Store_ID, Product_ID, DayMonth)
        If QtyInstock <> 0 Then
            Return Total / QtyInstock
        Else
            Return 0
        End If
    End Function

    Public Function UpdateQty_Price_Begin13() As Boolean
        Dim sql As String = ""
        Dim DayMonth As Date = getServerDate().AddDays(1)
        'update gia hang ton >0
        sql = "Select Product_ID, sum(Exchange*(QImport-QOrder)) as Instock,Cast(0 as money) as Price "
        sql += " from v_thekho Group by Product_ID having sum(Exchange*(QImport-QOrder))>0"
        Dim tbInstock As DataTable = Me.getTableSQL(sql)

        If tbInstock Is Nothing Then
            Return False
        End If
        For Each drInstock As DataRow In tbInstock.Rows
            Dim Ton As Double = drInstock("Instock")
            'gia binh quan
            drInstock("Price") = getPriceInstock("", drInstock("Product_ID"), DayMonth, Ton)
            If Not UpdateOptionBeginProduct("", drInstock("Product_ID"), 0, drInstock("Price"), 2) Then
                Return False
            End If
        Next
        'update gia hang ton <=0
        sql = " Update PR_Product_Store set f_QuantityBegin=0, m_PriceBegin=t.Price, f_Curinstock=0,QtyOriginUnit=0, PriceOriginUnit=t.Price,s_Unit=t.s_Unit"
        sql += " from (select v.Store_ID,v.Product_ID, sum(v.Exchange*(v.QImport-v.QOrder)) as Instock,isnull(lp.m_UnitPurchase,0) as Price,lp.s_Unit "
        sql += " from v_thekho v , Ls_Products lp where v.Product_ID=lp.s_ID"
        sql += " Group by v.Store_ID,v.Product_ID,lp.m_UnitPurchase,lp.s_Unit having sum(v.Exchange*(v.QImport-v.QOrder))<=0 ) as t"
        sql += " where(PR_Product_Store.s_Product_ID = t.Product_ID And PR_Product_Store.s_Store_ID = t.Store_ID)"
        If Not execSQL(sql) Then
            Return False
        End If
        'update so luong nhung mat hang ton >0
        sql = " Update PR_Product_Store set f_QuantityBegin=t.Instock,f_Curinstock=t.Instock,QtyOriginUnit=t.Instock,s_Unit=t.s_Unit "
        sql += " from( Select v.Store_ID, v.Product_ID, isnull(sum(v.Exchange*(v.QImport-v.QOrder)),0) as Instock,lp.s_Unit "
        sql += " from v_thekho v, Ls_Products lp where v.Product_ID=lp.s_ID "
        sql += " Group by v.Store_ID,v.Product_ID,lp.s_Unit having sum(v.Exchange*(v.QImport-v.QOrder))>0 )as t"
        sql += " where(PR_Product_Store.s_Product_ID = t.Product_ID And PR_Product_Store.s_Store_ID = t.Store_ID)"
        If Not execSQL(sql) Then
            Return False
        End If

        Return True
    End Function

#Region "Doan ham cu tinh gia dau ky"
    ''03.08.2010n bo doan having sum(Exchange*(QImport-QOrder))>0
    '    sql = "Select Store_ID, Product_ID, sum(Exchange*(QImport-QOrder)) as Instock, " & _
    '            "       Cast(0 as money) as Price "
    '    sql += " from v_thekho Group by Store_ID,Product_ID "
    'Dim tbInstock As DataTable = Me.getTableSQL(Sql)

    '    sql = "Select Datediff(day,'2009-1-1',DayMonth) as nD, Store_ID, Product_ID, " & _
    '            "       QImport*Exchange as QImport, Price/Exchange as Price, DayMonth, " & _
    '            "       Ordinal, i_IDSort "
    '    sql += " from v_thekho where QImport<>0 "
    '    sql += " Order by Datediff(day,'2009-1-1',DayMonth) desc, Ordinal asc, i_IDSort desc"
    'Dim tbImport As DataTable = getTableSQL(Sql)

    '    If tbInstock Is Nothing Or tbImport Is Nothing Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    For Each drInstock As DataRow In tbInstock.Rows
    'Dim Ton As Double = drInstock("Instock")
    '        If Ton <> 0 Then 'neu Ton <>0 thi moi tinh gia
    'Dim DF() As DataRow = tbImport.Select("QImport>0 and Product_ID='" & drInstock("Product_ID").ToString.Replace("'", "''") & "' and Store_ID='" & drInstock("Store_ID").ToString.Replace("'", "''") & "'", "nD desc,Ordinal asc,i_IDSort desc")
    'Dim i As Integer = 0
    'Dim Total As Double = 0
    '            While Ton > 0 And i < DF.Length
    '                If Ton > DF(i)("QImport") Then
    '                    Total += DF(i)("Price") * DF(i)("QImport")
    '                    Ton -= DF(i)("QImport")
    '                    DF(i)("QImport") = 0
    '                Else
    '                    Total += DF(i)("Price") * Ton
    '                    DF(i)("QImport") -= Ton
    '                    Ton = 0
    '                End If
    '                i += 1
    '            End While

    '            If Ton > 0 Then
    'Dim sMsg As String = "Xem lai gia thuat ? khong phan bo het hang ton ?"
    '            End If
    '            If drInstock("Instock") > 0 Then
    '                drInstock("Price") = Total / drInstock("Instock")
    '            End If
    '        End If

    '        If Not UpdateBeginProduct(drInstock("Store_ID"), drInstock("Product_ID"), drInstock("Instock"), drInstock("Price")) Then
    '            CommandTimeOut = nTimeout
    '            Return False
    '        End If
    '    Next
#End Region

    'Public Function ClearBook() As Boolean
    '    Dim sql As String = ""
    '    'Cap nhat hang dau ky
    '    Dim nTimeout As Integer = CommandTimeOut
    '    CommandTimeOut = 10000

    '    Me.BeginTranstion()

    '    If Not FillImportInstock() Then
    '        Dim ssErr As String = ""
    '        Me.RollbackTransction()
    '        Return False
    '    End If

    '    'cap nhat gia va so luong du ky
    '    If Not UpdateQty_Price_Begin13() Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Update ls_Objects set m_FirstIncome=v.Total from "
    '    sql += " (Select [Object_ID],sum(TotalNew) as Total from V_NumberIncomeNew group by [Object_ID]) as v"
    '    sql += " where ls_Objects.s_ID=v.[Object_ID]"

    '    sql += " Update ls_Objects set m_FirstOutcome=v.Total from "
    '    sql += " (Select [Object_ID],sum(TotalNew) as Total from V_NumberOutcomeNew group by [Object_ID]) as v"
    '    sql += " where ls_Objects.s_ID=v.[Object_ID]"


    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If
    '    If Not UpdateBank(True) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If
    '    'Xoa du lieu
    '    sql = "Drop table PR_Events"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = "CREATE  TABLE [dbo].[PR_Events]("
    '    sql += " [s_ID] [nvarchar](50) DEFAULT (newid()),"
    '    sql += " [s_UID] [nvarchar](50) NULL,"
    '    sql += " [i_TypeID] [int] NULL,"
    '    sql += " [s_Desc] [nvarchar](4000) NULL,"
    '    sql += " [dt_DayMonth] [smalldatetime]  DEFAULT (getdate()),"
    '    sql += " [s_Note] [nvarchar](1024) NULL,"
    '    sql += " [i_IDSort] [numeric](18, 0) IDENTITY(1,1) NOT NULL,"
    '    sql += " [b_isDelete] bit default(0)"
    '    sql += " Primary key([s_ID]))"
    '    sql += " ALTER TABLE [PR_Events]  WITH CHECK ADD  CONSTRAINT [FK_PR_Events_Ls_TypeEvents] FOREIGN KEY([i_TypeID])"
    '    sql += " REFERENCES [dbo].[Ls_TypeEvents] ([i_ID])ON UPDATE CASCADE ON DELETE CASCADE"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_TransDetails"
    '    sql += " Delete from LS_Trans"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from ls_Discount"
    '    sql += " Delete from ls_Discount_Product"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_ImportOrderReturnPay"
    '    sql += " Delete from PR_OrderDetailReturns"
    '    sql += " Delete from LS_OrderReturns"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_OrderConsignDetail"
    '    sql += " Delete from Ls_NumberConsignIncome"
    '    sql += " Delete from Ls_ConfirmConsign"
    '    sql += " Delete from LS_OrderConsign"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_ImportConsignDetail"
    '    sql += " Delete from Ls_NumberConsignOutcome"
    '    sql += " Delete from Ls_ConfirmImportConsign"
    '    sql += " Delete from Ls_ImportConsign"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from Pr_OrderImportReturnPay"
    '    sql += " Delete from PR_ImportDetailReturn"
    '    sql += " Delete from Ls_ImportReturns"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_ImportDetail"
    '    sql += " Delete from Ls_Imports"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from Ls_IncomeReturn"
    '    sql += " Delete from Ls_OutcomeReturn"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from Ls_TransCurr "
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from pr_NumberIncome"
    '    sql += " Delete from ls_Income"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from pr_NumberOutcome"
    '    sql += " Delete from ls_outcome"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_ImportDetail_Other"
    '    sql += " Delete from ls_Import_Other"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If


    '    sql = " Delete from PR_OrderDetail_Other"
    '    sql += " Delete from Ls_Order_Other"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_importDetail_EndProduct"
    '    sql += " Delete from Ls_Import_EndProduct"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_Workers"
    '    sql += " Delete from PR_Salary"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_Quote"
    '    sql += " Delete from LS_Quote"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_PurchaseImportDetails"
    '    sql += " Delete from LS_PurchaseImports"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_PurchaseOrderDetails"
    '    sql += " Delete from LS_PurchaseOrders"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_CheckStore"
    '    sql += " Delete from ls_CheckStore"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from ls_discount_Product"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from PR_ExportDetail_EndProduct "
    '    sql += " Delete from Ls_Export_EndProduct"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If

    '    sql = " Delete from Pr_OrderTotalDetail "
    '    sql += " Delete from Ls_OrderTotal"
    '    If Not execSQL(sql) Then
    '        CommandTimeOut = nTimeout
    '        Return False
    '    End If
    '    'select *From PR_Workers 
    '    'select *From PR_Salary

    '    Dim dMax As Date = CDate("1900-1-1")
    '    Dim tblTable As DataTable = getTableSQL("Select * from tblIndexOrders")
    '    For Each dr As DataRow In tblTable.Rows
    '        If dr("dt_toDate") > dMax Then
    '            dMax = dr("dt_toDate")
    '        End If
    '        sql = " Drop table [PR_OrderDetail_Fix_" & dr("s_Ind") & "]"
    '        sql += " Drop table [PR_OrderDetails_" & dr("s_Ind") & "]"
    '        sql += " Drop table [Ls_Orders_" & dr("s_Ind") & "]"
    '        If Not execSQL(sql) Then
    '            CommandTimeOut = nTimeout
    '            Return False
    '        End If
    '    Next
    '    If dMax.Year <> 1900 Then
    '        sql = "Delete from tblIndexOrders"
    '        If Not execSQL(sql) Then
    '            CommandTimeOut = nTimeout
    '            Return False
    '        End If
    '        Dim p(0) As SqlParameter
    '        p(0) = New SqlParameter("@dt_toDate", dMax)
    '        sql = "Exec sp_CreateOrders @dt_toDate"
    '        If Not execSQL(sql, p) Then
    '            CommandTimeOut = nTimeout
    '            Return False
    '        End If
    '        sql = "Exec RepairViewOrder"
    '        If Not execSQL(sql) Then
    '            CommandTimeOut = nTimeout
    '            Return False
    '        End If
    '    End If
    '    CommandTimeOut = nTimeout
    '    Me.CommitTranstion()
    '    Return True
    'End Function
    Public Function ClearBook() As Boolean
        Dim sql As String = ""
        'Cap nhat hang dau ky
        Dim nTimeout As Integer = CommandTimeOut
        CommandTimeOut = 10000
        Dim fBegin As Boolean = BeginTranstion()

        sql = "Update PR_Product_Store set QtyOriginUnit=0, f_QuantityBegin=0,f_Curinstock=0"
        sql += " From  "
        sql += " (Select Store_ID,Product_ID,sum(Exchange*(QImport-QOrder)) as Instock,Cast(0 as money) as Price from v_thekho Group by Store_ID,Product_ID having sum(Exchange*(QImport-QOrder))=0) as t"
        sql += " where s_Product_ID=t.Product_ID and s_Store_ID=t.Store_ID"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If
        sql = "Select Store_ID,Product_ID,sum(Exchange*(QImport-QOrder)) as Instock,Cast(0 as money) as Price from v_thekho Group by Store_ID,Product_ID having sum(Exchange*(QImport-QOrder))<>0"
        Dim tbInstock As DataTable = Me.getTableSQL(sql)

        sql = "if (Select count(*) as C from sysobjects where xtype='U' and name='tmpImportDetail')=0"
        sql += " Create table tmpImportDetail(Store_ID nvarchar(50),Product_ID nvarchar(50),QImport float,Price money,Ordinal int identity(1,1))"
        If Not execSQL(sql) Then Return False

        sql = "Insert into tmpImportDetail(Store_ID,Product_ID,QImport,Price)"
        sql += " Select Store_ID,Product_ID,QImport*Exchange as QImport,Price/Exchange from v_thekho where QImport<>0 Order by Datediff(day,'2009-1-1',DayMonth) desc,Ordinal asc,i_IDSort desc"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        For Each drInstock As DataRow In tbInstock.Rows
            Dim Ton As Double = drInstock("Instock")
            Dim tbImport As DataTable = getTableSQL("Select QImport,Price from tmpImportDetail where Product_ID=@Product_ID AND Store_ID=@Store_ID Order by Ordinal asc", New SqlParameter() {New SqlParameter("@Product_ID", drInstock("Product_ID").ToString), New SqlParameter("@Store_ID", drInstock("Store_ID").ToString)})
            If tbImport Is Nothing Then
                CommandTimeOut = nTimeout
                RollbackTransction()
                Return False
            End If
            Dim i As Integer = 0
            Dim Total As Double = 0
            While Ton > 0 And i < tbImport.Rows.Count
                If Ton > tbImport.Rows(i)("QImport") Then
                    Total += tbImport.Rows(i)("Price") * tbImport.Rows(i)("QImport")
                    Ton -= tbImport.Rows(i)("QImport")
                    tbImport.Rows(i)("QImport") = 0
                Else
                    Total += tbImport.Rows(i)("Price") * Ton
                    tbImport.Rows(i)("QImport") -= Ton
                    Ton = 0
                End If
                i += 1
            End While

            If Ton > 0 Then
                Dim sMsg As String = "Xem lai gia thuat ? khong phan bo het hang ton ?"
            End If
            If drInstock("Instock") > 0 Then
                drInstock("Price") = Total / drInstock("Instock")
            Else
                drInstock("Price") = 0
            End If
            If Not UpdateBeginProduct(drInstock("Store_ID"), drInstock("Product_ID"), drInstock("Instock"), drInstock("Price")) Then
                CommandTimeOut = nTimeout
                Return False
            End If
        Next

        sql = "if (Select count(*) as C from sysobjects where xtype='U' and name='tmpImportDetail')<>0"
        sql += " Drop table tmpImportDetail"
        If Not execSQL(sql) Then Return False

        sql = "Alter table PR_Product_Store Drop column i_IDSort"
        If Not execSQL(sql) Then Return False

        sql = "Alter table PR_Product_Store Add i_IDSort numeric identity(1,1)"
        If Not execSQL(sql) Then Return False

        '-----------
        sql = " Update ls_Objects set m_FirstIncome=v.Total,m_PrepayCus=v.Total from "
        sql += " (Select [Object_ID],sum(TotalNew) as Total from V_NumberIncomeNew group by [Object_ID]) as v"
        sql += " where ls_Objects.s_ID=v.[Object_ID]"

        sql += " Update ls_Objects set m_FirstOutcome=v.Total,m_PrepaySup=v.Total from "
        sql += " (Select [Object_ID],sum(TotalNew) as Total from V_NumberOutcomeNew group by [Object_ID]) as v"
        sql += " where ls_Objects.s_ID=v.[Object_ID]"


        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If
        If Not UpdateBank(True) Then
            CommandTimeOut = nTimeout
            Return False
        End If
        'Xoa du lieu
        sql = "Drop table PR_Events"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "CREATE  TABLE [dbo].[PR_Events]("
        sql += " [s_ID] [nvarchar](50) DEFAULT (newid()),"
        sql += " [s_UID] [nvarchar](50) NULL,"
        sql += " [i_TypeID] [int] NULL,"
        sql += " [s_Desc] [nvarchar](4000) NULL,"
        sql += " [dt_DayMonth] [smalldatetime]  DEFAULT (getdate()),"
        sql += " [s_Note] [nvarchar](1024) NULL,"
        sql += " [i_IDSort] [numeric](18, 0) IDENTITY(1,1) NOT NULL,b_IsDelete bit"
        sql += " Primary key([s_ID]))"
        sql += " ALTER TABLE [PR_Events]  WITH CHECK ADD  CONSTRAINT [FK_PR_Events_Ls_TypeEvents] FOREIGN KEY([i_TypeID])"
        sql += " REFERENCES [dbo].[Ls_TypeEvents] ([i_ID])ON UPDATE CASCADE ON DELETE CASCADE"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_TransDetails"
        sql += " Delete from LS_Trans"

        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from ls_Discount"
        sql += " Delete from ls_Discount_Product"

        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_ImportOrderReturnPay"
        sql += " Delete from PR_OrderDetailReturns"
        sql += " Delete from LS_OrderReturns"

        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_OrderConsignDetail"
        sql += " Delete from Ls_NumberConsignIncome"
        sql += " Delete from Ls_ConfirmConsign"
        sql += " Delete from LS_OrderConsign"

        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_ImportConsignDetail"
        sql += " Delete from Ls_NumberConsignOutcome"
        sql += " Delete from Ls_ConfirmImportConsign"
        sql += " Delete from Ls_ImportConsign"

        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from Pr_OrderImportReturnPay"
        sql += " Delete from PR_ImportDetailReturn"
        sql += " Delete from Ls_ImportReturns"

        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_ImportDetail"
        sql += " Delete from Ls_Imports"

        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from Ls_IncomeReturn"
        sql += " Delete from Ls_OutcomeReturn"

        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from Ls_TransCurr"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from pr_NumberIncome"
        sql += " Delete from ls_Income"

        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from pr_NumberOutcome"
        sql += " Delete from ls_outcome"

        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_ImportDetail_Other"
        sql += " Delete from ls_Import_Other"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If


        sql = "Delete from PR_OrderDetail_Other"
        sql += " Delete from Ls_Order_Other"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_importDetail_EndProduct"
        sql += " Delete from Ls_Import_EndProduct"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_Workers"
        sql += " Delete from PR_Salary"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_Quote"
        sql += " Delete from LS_Quote"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_PurchaseImportDetails"
        sql += " Delete from LS_PurchaseImports"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_PurchaseOrderDetails"
        sql += " Delete from LS_PurchaseOrders"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_CheckStore"
        sql += " Delete from ls_CheckStore"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from ls_discount_Product"

        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from PR_ExportDetail_EndProduct "
        sql += " Delete from Ls_Export_EndProduct"
        sql += " DBCC CHECKIDENT('Ls_Export_EndProduct',RESEED,0)"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If

        sql = "Delete from Pr_OrderTotalDetail "
        sql += " Delete from Ls_OrderTotal"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If
       
        Dim dMax As Date = CDate("1900-1-1")
        Dim tblTable As DataTable = getTableSQL("Select * from tblIndexOrders")
        If tblTable IsNot Nothing AndAlso tblTable.Rows.Count > 0 Then
            For Each dr As DataRow In tblTable.Rows
                If dr("dt_toDate") > dMax Then
                    dMax = dr("dt_toDate")
                End If
                sql = "Drop table [PR_OrderDetails_" & dr("s_Ind") & "]"
                sql += " Drop table [Ls_Orders_" & dr("s_Ind") & "]"
                If Not execSQL(sql) Then
                    CommandTimeOut = nTimeout
                    Return False
                End If
            Next
            If dMax.Year <> 1900 Then
                sql = "Delete from tblIndexOrders"
                If Not execSQL(sql) Then
                    CommandTimeOut = nTimeout
                    Return False
                End If
                Dim p(0) As SqlParameter
                p(0) = New SqlParameter("@dt_toDate", dMax)
                sql = "Exec sp_CreateOrders @dt_toDate"
                If Not execSQL(sql, p) Then
                    CommandTimeOut = nTimeout
                    Return False
                End If
                sql = "Exec RepairViewOrder"
                If Not execSQL(sql) Then
                    CommandTimeOut = nTimeout
                    Return False
                End If
            End If
        End If


        sql = "Delete from [rptDetailNumber]"
        sql += " Delete from [rptDebtOver]"
        sql += " Delete from [rptNumber]"
        sql += " Delete from [rptFund]"
        sql += " Delete from [rptStoreCard]"
        sql += " Delete from [rptInstock]"
        sql += " Delete from [rpt_EmployeeCheckInOut]"
        sql += " Delete from [rptListProduct]"
        sql += " Delete from [rptDetailDebt_Order_Emp]"
        sql += " Delete from [rptTotalProductOrder]"
        sql += " Delete from [rptProduct_Order_ImportDetail]"
        sql += " Delete from [rptTotalOrderProduct]"
        sql += " Delete from [rptTotal]"
        sql += " Delete from [rptTotalDetail]"
        sql += " Delete from [rptVonKinhDoanh]"
        sql += " Delete from [rptCheckStore]"
        sql += " Delete from [rptProductOrder]"
        If Not execSQL(sql) Then
            CommandTimeOut = nTimeout
            Return False
        End If
        CommandTimeOut = nTimeout
        If fBegin Then
            CommitTranstion()
        End If
        ResetIdentity()
        Return True
    End Function
    Public Function ResetIdentity() As Boolean
        Dim sql As String = ""
        sql = "select c.TABLE_NAME,c.COLUMN_NAME"
        sql += " from INFORMATION_SCHEMA.COLUMNS c"
        sql += " JOIN sysobjects s On c.Table_Name=s.Name "
        sql += " where c.TABLE_SCHEMA = 'dbo' AND s.xtype='U'"
        sql += " and COLUMNPROPERTY(object_id(c.TABLE_NAME), c.COLUMN_NAME, 'IsIdentity') = 1"
        sql += " order by c.TABLE_NAME"
        Dim tb As DataTable = getTableSQL(sql)
        If Not tb Is Nothing Then
            sql = "DBCC CHECKIDENT(@tblName,RESEED,@M)"
            For Each dr As DataRow In tb.Rows
                Dim Table_Name As String = dr("TABLE_NAME").ToString
                Dim tb1 As DataTable = getTableSQL("Select isnull(Max([" & dr("COLUMN_NAME") & "]),0) as M from [" & Table_Name & "]")
                If Not tb1 Is Nothing Then
                    Dim iMax As Integer = tb1.Rows(0)("M") + 1
                    If Not execSQL(sql, New SqlParameter() {New SqlParameter("@tblName", Table_Name), New SqlParameter("@M", iMax)}) Then
                        Exit For
                    End If
                End If
            Next
        End If
        sql = "DBCC SHRINKDATABASE(@db)"
        execSQL(sql, New SqlParameter("@db", Me.Database))
        Return True
    End Function
    Public Function UpdateBeginInstockOfEmp(ByVal ThuTU As String, ByVal ChiTU As String) As Boolean
        Dim sql As String = ""
        sql = " select e.*,t.m_Inc,t2.m_Out from ls_employees e left outer join "
        sql += " (Select isnull(sum(m_Total),0) as m_Inc,s_Object_ID from Ls_Income where i_Item_ID=@ThuTU "
        sql += " or i_GroupItem_ID=@ThuTU Group by s_Object_ID) as t on e.s_ID=t.s_Object_ID "
        sql += " left outer join "
        sql += " (Select isnull(sum(m_Total),0) as m_Out,s_Object_ID from Ls_Outcome where i_Item_ID=@ChiTU "
        sql += " or i_GroupItem_ID=@ChiTU Group by s_Object_ID)  as t2 on e.s_ID=t2.s_Object_ID "

        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@ThuTU", ThuTU)
        p(1) = New SqlParameter("@ChiTU", ChiTU)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If Not IsNothing(tb) AndAlso tb.Rows.Count > 0 Then
            For Each r As DataRow In tb.Rows
                sql = "Update ls_employees set m_BeginDebt=isnull(m_BeginDebt,0)+ @m_BeginDebt where s_ID=@s_ID "
                p(0) = New SqlParameter("@m_BeginDebt", CDbl(IsNull(r("m_Out"), 0)) - CDbl(IsNull(r("m_Inc"), 0)))
                p(1) = New SqlParameter("@s_ID", r("s_ID"))
                If Not Me.execSQL(sql, p) Then
                    Return False
                End If
            Next

            Return True
        End If

        Return False
    End Function
    '20.08.2010 chi cap nhat so luong hoac gia
    Private Function UpdateOptionBeginProduct(ByVal Store_ID As String, ByVal Product_ID As String, _
                                        ByVal Qty As Double, ByVal Price As Double, ByVal nCase As Integer) As Boolean
        Dim sql As String = ""
        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@Product_ID", Product_ID)
        p(2) = New SqlParameter("@Qty", Qty)
        p(3) = New SqlParameter("@Price", Price)

        Select Case nCase
            Case 1 'update so luong
                sql = " Update PR_Product_Store " & _
                                            " set f_QuantityBegin=@Qty,f_Curinstock=@Qty,QtyOriginUnit=@Qty" & _
                                            " where s_Product_ID=@Product_ID and s_Store_ID=@Store_ID"
            Case 2 'update gia
                sql = " Update PR_Product_Store set m_PriceBegin=@Price,PriceOriginUnit=@Price "
                sql += " where s_Product_ID=@Product_ID "
            Case 3
                sql = " Update PR_Product_Store " & _
                           " set f_QuantityBegin=@Qty, m_PriceBegin=@Price, f_Curinstock=@Qty, " & _
                           "       QtyOriginUnit=@Qty, PriceOriginUnit=@Price" & _
                           " where s_Product_ID=@Product_ID and s_Store_ID=@Store_ID"
        End Select

        Return execSQL(sql, p)

    End Function
    Private Function UpdateBeginProduct(ByVal Store_ID As String, ByVal Product_ID As String, _
                                        ByVal Qty As Double, ByVal Price As Double) As Boolean
        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@Product_ID", Product_ID)
        p(2) = New SqlParameter("@Qty", Qty)
        p(3) = New SqlParameter("@Price", Price)
        '03.08.2010 update them 2 cai truong QtyOriginUnit,PriceOriginUnit
        Dim sql As String = " Update PR_Product_Store " & _
                            " set f_QuantityBegin=@Qty, m_PriceBegin=@Price, f_Curinstock=@Qty, " & _
                            "       QtyOriginUnit=@Qty, PriceOriginUnit=@Price" & _
                            " where s_Product_ID=@Product_ID and s_Store_ID=@Store_ID"
        Return execSQL(sql, p)

    End Function
  
    Public Function RepairInstock_Debt() As Boolean
        Dim sql As String = "EXEC sp_InsertProductIntoStore"
        If Not Me.execSQL(sql) Then
            Return False
        End If
        sql = " Update  PR_Product_Store set f_CurInstock=t.Instock from"
        sql += " (Select Store_ID,Product_ID,sum(Exchange*(QImport-QOrder)) as Instock from v_thekho Group by Store_ID,Product_ID)as t"
        sql += " where PR_Product_Store.s_Store_ID=t.Store_ID and PR_Product_Store.s_Product_ID=t.Product_ID"
        If Not execSQL(sql) Then
            Return False
        End If

        sql = "Update Ls_Objects set m_PrepayCus=0,m_PrepaySup=0"
        If Not execSQL(sql) Then
            Return False
        End If

        sql = "Update Ls_Objects set m_PrepayCus=t.Income"
        sql += " From (Select Object_ID,Sum(TotalNew) as Income From V_NumberIncomeNew Group by Object_ID) as t Where Ls_Objects.s_ID=t.Object_ID"
        If Not execSQL(sql) Then
            Return False
        End If

        sql = "Update Ls_Objects set m_PrepaySup=t.Outcome"
        sql += " From (Select Object_ID,Sum(TotalNew) as Outcome From V_NumberOutcomeNew Group by Object_ID) as t Where Ls_Objects.s_ID=t.Object_ID"
        If Not execSQL(sql) Then
            Return False
        End If

        Return True
    End Function


    Private Function UpdateBank(ByVal isClearBook As Boolean) As Boolean
        Dim sql As String = ""

        sql += " Update ls_Banks set m_Balance=isnull(b.Instock,0) From"
        sql += " (Select BankID_Key,isnull(Sum(([331]-[131])),0) as Instock from V_Fund"
        sql += " where isnull(BankID_Key,'')<>''"
        sql += " Group by BankID_Key ) as b Where ls_Banks.s_ID=b.BankID_Key"

        If Not execSQL(sql) Then
            Return False
        End If
        If isClearBook Then
            sql = "Update ls_Banks set m_Begin=m_Balance"
            sql += " Update ls_Currency set m_Begin=t.TT"
            sql += " from (Select i_Currency,sum([331]-[131]) AS TT from V_Fund"
            sql += " where isnull(BankID_Key,'')='' and i_PaymentDebt<>1 Group by i_Currency) as t where ls_Currency.i_ID=t.i_Currency"

            If Not execSQL(sql) Then
                Return False
            End If
        End If

        Return True
    End Function

    Public Function SaveConfigProductCode(ByVal isAuto As Boolean, ByVal nType As Integer, ByVal Prefix As String, ByVal Pos As Integer, ByVal iLen As Integer, _
                                          ByVal b_SortProduct As Boolean, ByVal i_OptionSort As Integer, ByVal i_LocationNum As Integer, ByVal i_QtyNum As Integer) As Boolean
        Dim p(8) As SqlParameter
        p(0) = New SqlParameter("@isAuto", isAuto)
        p(1) = New SqlParameter("@nType", nType)
        p(2) = New SqlParameter("@Prefix", Prefix)
        p(3) = New SqlParameter("@Pos", Pos)
        p(4) = New SqlParameter("@iLen", iLen)
        p(5) = New SqlParameter("@b_SortProduct", b_SortProduct)
        p(6) = New SqlParameter("@i_OptionSort", i_OptionSort)
        p(7) = New SqlParameter("@i_LocationNum", i_LocationNum)
        p(8) = New SqlParameter("@i_QtyNum", i_QtyNum)
        Dim sql As String = ""
        sql = " Delete from tblConfigProductCode"
        sql += " Insert into tblConfigProductCode(isAuto ,nType ,Prefix ,Pos ,iLen,b_SortProduct,i_OptionSort,i_LocationNum,i_QtyNum,i_QtyChar)"
        sql += " values (@isAuto ,@nType ,@Prefix ,@Pos ,@iLen,@b_SortProduct,@i_OptionSort,@i_LocationNum,@i_QtyNum,0)"
        Return execSQL(sql, p)
    End Function

    Public Function SaveConfigObjectCode(ByVal isAuto As Boolean, ByVal nType As Integer, ByVal Prefix As String, ByVal Pos As Integer, ByVal iLen As Integer) As Boolean
        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@isAuto", isAuto)
        p(1) = New SqlParameter("@nType", nType)
        p(2) = New SqlParameter("@Prefix", Prefix)
        p(3) = New SqlParameter("@Pos", Pos)
        p(4) = New SqlParameter("@iLen", iLen)
        Dim sql As String = ""
        sql = " Delete from tblConfigObjectCode"
        sql += " Insert into tblConfigObjectCode(isAuto ,nType ,Prefix ,Pos ,iLen) values (@isAuto ,@nType ,@Prefix ,@Pos ,@iLen)"
        Return execSQL(sql, p)
    End Function

    Public Function SaveConfigEmployeeCode(ByVal isAuto As Boolean, ByVal nType As Integer, ByVal Prefix As String, ByVal Pos As Integer, ByVal iLen As Integer) As Boolean
        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@isAuto", isAuto)
        p(1) = New SqlParameter("@nType", nType)
        p(2) = New SqlParameter("@Prefix", Prefix)
        p(3) = New SqlParameter("@Pos", Pos)
        p(4) = New SqlParameter("@iLen", iLen)
        Dim sql As String = ""
        sql = " Delete from tblConfigEmployeeCode"
        sql += " Insert into tblConfigEmployeeCode(isAuto ,nType ,Prefix ,Pos ,iLen) values (@isAuto ,@nType ,@Prefix ,@Pos ,@iLen)"
        Return execSQL(sql, p)
    End Function

    Public Function getConfigProductCode() As DataTable
        Return Me.getTableSQL("Select * from tblConfigProductCode")
    End Function

    Public Function getConfigObjectCode() As DataTable
        Return Me.getTableSQL("Select * from tblConfigObjectCode")
    End Function

    Public Function getConfigEmployeeCode() As DataTable
        Return Me.getTableSQL("Select * from tblConfigEmployeeCode")
    End Function

    Public Function getProductCode(ByVal GroupID As String) As String
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@GroupID", GroupID)
        Dim tb As DataTable = getTableSQL("Exec sp_getProductCode @GroupID", p)
        If tb Is Nothing Then Return ""
        If tb.Rows.Count = 0 Then Return ""
        Return tb.Rows(0)("ProductCode")

    End Function

    '03.12.2010 lay cau hinh Sort
    Public Function getStringSortProduct(ByVal truong As String) As String
        Dim sql As String = ""
        Dim str As String = ""
        'chu so
        'so chu
        sql = "select * from tblConfigProductCode"
        Dim tb As DataTable = getTableSQL(sql)
        If tb Is Nothing Then Return ""
        If tb.Rows.Count > 0 Then
            If IsNull(tb.Rows(0)("b_SortProduct"), False) = False Then Return ""

            Dim vtso As Integer = IsNull(tb.Rows(0)("i_LocationNum"), 0)
            Dim slso As Integer = IsNull(tb.Rows(0)("i_QtyNum"), 0)
            If vtso = 0 And slso = 0 Then Return ""

            If IsNull(tb.Rows(0)("isAuto"), False) = False And IsNull(tb.Rows(0)("b_SortProduct"), False) = True Then 'theo sort
                Select Case IsNull(tb.Rows(0)("i_OptionSort"), 1)
                    Case 1
                        str = " case when len(" & truong.ToString & ")>=" & vtso.ToString & " then left(" & truong.ToString & "," & (vtso - 1).ToString & ") else '' end as A,"
                        str += " case when len(" & truong.ToString & ")>=" & vtso.ToString & " and isnumeric(SubString(" & truong.ToString & "," & vtso.ToString & "," & slso.ToString & "))=1 then"
                        str += " cast(SubString(" & truong.ToString & "," & vtso.ToString & "," & slso.ToString & ") as float) else 0 end as B,"
                        str += " case when len(" & truong.ToString & ")>(" & vtso.ToString & "+" & slso.ToString & ") then Right(" & truong.ToString & ",len(" & truong.ToString & ")-(" & vtso.ToString & "+" & slso.ToString & ")) else '' end as C"
                    Case 2
                        str = " case when len(" & truong.ToString & ")>=" & vtso.ToString & " and isnumeric(left(" & truong.ToString & "," & slso.ToString & "))=1 then "
                        str += " cast(left(" & truong.ToString & "," & slso.ToString & ") as int) else 0 end as A, "
                        str += " case when len(" & truong.ToString & ")>" & slso.ToString & " then right(" & truong.ToString & ",len(" & truong.ToString & ")-" & slso.ToString & ") else"
                        str += " '' end as B ,'' as C"
                End Select
            End If
        End If
        Return str
    End Function

    Public Function getObjectCode(ByVal GroupID As String) As String
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@GroupID", GroupID)
        Dim tb As DataTable = getTableSQL("Exec sp_getObjectCode @GroupID", p)
        If tb Is Nothing Then Return ""
        If tb.Rows.Count = 0 Then Return ""
        Return tb.Rows(0)("ProductCode")

    End Function

    Public Function getEmployeeCode(ByVal GroupID As String) As String
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@GroupID", GroupID)
        Dim tb As DataTable = getTableSQL("Exec sp_getEmployeeCode @GroupID", p)
        If tb Is Nothing Then Return ""
        If tb.Rows.Count = 0 Then Return ""
        Return tb.Rows(0)("ProductCode")

    End Function

    'Phần cấu hình hiển thị cho từng User 12.06.09=====================================================
    Public Function GetListItem(ByVal UID As String) As DataTable '12.06.09
        Dim ds As New DataSet
        '===Master====
        Dim sql As String = ""
        sql = "Select l.s_ID,l.s_Key,l.s_Name,l.Uplevel,isnull(l.isDefault,0)as isDefault,l.i_IDSort,isnull(p.isSelect,0)as isSelect "
        sql += " from LS_ConfigMyDesk l left outer join (select * from PR_ConfigMyDeskDetail p  where p.UID=@UID)as p  "
        sql += " on l.s_ID=p.MyDeskID where Uplevel=0 order by l.i_IDSort asc"

        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@UID", UID)


        Dim dtMaster As DataTable = Me.getTableSQL(sql, p)
        Dim ParentCol As DataColumn = dtMaster.Columns("s_ID")
        ds.Tables.Add(dtMaster)

        '===Detail====
        sql = "select l.s_ID,l.s_Key,l.s_Name,l.Uplevel,isnull(l.isDefault,0)as isDefault ,l.i_IDSort,isnull(p.isSelect,0)as isSelect"
        sql += " From LS_ConfigMyDesk l left outer join (select * from PR_ConfigMyDeskDetail p  where p.UID=@UID)as p"
        sql += " on l.s_ID=p.MyDeskID  where uplevel<>0  and s_ModuleID='Home' order by l.i_IDSort asc"

        Dim pm(0) As SqlParameter
        pm(0) = New SqlParameter("@UID", UID)


        Dim dtDetail As DataTable = Me.getTableSQL(sql, pm)
        Dim ChildCol As DataColumn = dtDetail.Columns("Uplevel")
        ds.Tables.Add(dtDetail)

        '====Relation=====
        Dim relation As New DataRelation("Master_Detail", ParentCol, ChildCol)
        ds.Relations.Add(relation)

        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count = 0 Then
                Dim dset As New DataSet
                '===Master====
                sql = "Select l.s_ID,l.s_Key,l.s_Name,l.Uplevel,isnull(l.isDefault,0)as isDefault,l.i_IDSort,isnull(p.isSelect,0)as isSelect "
                sql += " from LS_ConfigMyDesk l left outer join PR_ConfigMyDeskDetail p  "
                sql += " on l.s_ID=p.MyDeskID where  Uplevel=0 order by l.i_IDSort asc"

                Dim dtM As DataTable = Me.getTableSQL(sql)
                Dim ParCol As DataColumn = dtM.Columns("s_ID")
                dset.Tables.Add(dtM)

                '===Detail====
                sql = "Select l.s_ID,l.s_Key,l.s_Name,l.Uplevel,l.isDefault,l.i_IDSort,isnull(p.isSelect,0)as isSelect "
                sql += " from LS_ConfigMyDesk l left outer join PR_ConfigMyDeskDetail p  "
                sql += " on l.s_ID=p.MyDeskID where Uplevel<>0 order by l.i_IDSort asc"

                Dim dtD As DataTable = Me.getTableSQL(sql)
                Dim ChiCol As DataColumn = dtD.Columns("Uplevel")
                dset.Tables.Add(dtD)

                '====Relation=====
                Dim re As New DataRelation("M_D", ParCol, ChiCol)
                dset.Relations.Add(re)
                Return dset.Tables(0)
            End If
        End If

        Return ds.Tables(0)
    End Function
    Public Function GetMyDesk(ByVal UID As String) As DataTable

        Dim sql As String = ""
        sql = "Select * from PR_ConfigMyDeskDetail p left outer join ls_configMyDesk l "
        sql += " on l.s_ID=p.MyDeskID where UID=@UID and isSelect=1 order by l.i_IDSort asc"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@UID", UID)

        Dim tb As DataTable = Me.getTableSQL(sql, p)

        Return tb
    End Function
    Public Function getDefaultMode_User(ByVal UID As String) As DataTable
        Dim sql As String = ""
        sql = "select * from [LS_ConfigCenterShowDefault_User] where s_UID=@UID "
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@UID", UID)

        Return Me.getTableSQL(sql, p)
    End Function
    Public Function getDefaultMode() As DataTable
        Dim sql As String = ""
        sql = "select * from [LS_ConfigCenterShowDefault]"
        Return Me.getTableSQL(sql)
    End Function
    Public Function getList(ByVal sModuleID As String) As DataTable
        Dim sql As String = "select * from ls_configmydesk where Uplevel=2 and s_ModuleID=@sModuleID"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@sModuleID", sModuleID)

        Dim tb As DataTable = Me.getTableSQL(sql, p)
        'Dim dr As DataRow
        'dr = tb.NewRow
        'dr("s_ID") = -1
        'dr("s_Name") = m_AddNew
        'tb.Rows.InsertAt(dr, 0)

        Return tb
    End Function
    Public Function DeleteMyDesk(ByVal UID As String) As Boolean '17.06.09
        Dim sql As String = ""
        sql = "Delete from [PR_ConfigMyDeskDetail] where [UID]=@UID" & vbCrLf & _
    " Delete from [LS_ConfigCenterShowDefault_User] where [s_UID]=@UID "

        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@UID", UID)

        Return execSQL(sql, p)
    End Function

    ''Phần cấu hình hiển thị mặc định chung cho những user ko có cấu hình riêng.
    Public Function DeletePublicDefault() As Boolean '18.06.09
        Dim sql As String = ""
        sql = "Delete from [Ls_ConfigCenterShowDefault] " & vbCrLf & _
    " Update [Ls_ConfigMyDesk] set [isDefault]=0 "
        Return execSQL(sql)
    End Function
    Public Function GetPublicDesk() As DataTable
        Dim sql As String = ""
        sql = "Select * from ls_configMyDesk where isDefault=1 order by i_IDSort asc"
        Return Me.getTableSQL(sql)
    End Function

    Public Function getIDMax() As Integer
        Dim idmax As Integer = -1
        Dim sql As String = ""
        sql = "Select max(s_ID)as value from ls_configMyDesk"
        Dim tb As DataTable = Me.getTableSQL(sql)
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            idmax = CInt(IsNull(tb.Rows(0)("value"), -1))
        End If
        Return idmax
    End Function
    Public Function getIDSort(ByVal uplevel As Integer) As Integer
        Dim idSort As Integer = -1
        Dim sql As String = ""
        sql = "Select max(i_IDSort)as value from ls_configMyDesk where uplevel=@uplevel"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@uplevel", uplevel)
        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            idSort = CInt(IsNull(tb.Rows(0)("value"), -1))
        End If
        Return idSort
    End Function

    Public Function getNumberSID(ByVal iTypeNumber As Integer, ByVal NumberID As String) As String

        Dim arrs() As String = getTableColumn(iTypeNumber)
        Dim sCol As String = arrs(1)
        Dim sTable As String = arrs(0)

        Dim sql As String = "Select s_ID from [" & sTable & "] where [" & sCol & "]=@NumberID"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@NumberID", NumberID)
        Dim tb As DataTable = getTableSQL(sql, p)
        If Not tb Is Nothing Then
            If tb.Rows.Count > 0 Then
                Return tb.Rows(0)("s_ID").ToString
            End If
        End If
        Return ""
    End Function
    Private Function getTableColumn(ByVal iTypeNumber) As String()
        Dim s(1) As String
        Dim sCol As String = ""
        Dim sTable As String = ""

        Select Case iTypeNumber
            Case 0
                sCol = "s_Import_ID"
                sTable = "ls_Imports"
            Case 1
                sCol = "s_Order_ID"
                sTable = "ls_PurchaseImports"
            Case 2
                sCol = "s_Order_ID"
                sTable = "ls_OrderReturns"
            Case 3
                sCol = "s_NumberID"
                sTable = "ls_Outcome"
            Case 4
                sCol = "s_Order_ID"
                sTable = "v_fullorder"
            Case 5
                sCol = "s_Order_ID"
                sTable = "ls_PurchaseOrders"
            Case 6
                sCol = "s_Import_ID"
                sTable = "ls_ImportReturns"
            Case 7
                sCol = "s_NumberID"
                sTable = "ls_Income"
            Case 8
                sCol = "s_Order_ID"
                sTable = "ls_Quote"
            Case 9
                sCol = "s_NumberID"
                sTable = "LS_Trans"
            Case 10
                sCol = "s_Order_ID"
                sTable = "Ls_Order_Other"
            Case 11
                sCol = "s_Import_ID"
                sTable = "Ls_Import_Other"
            Case 13
                sCol = "s_Product_ID"
                sTable = "Ls_Products"
            Case 12
                sCol = "s_Object_ID"
                sTable = "Ls_Objects"
            Case 14
                sCol = "s_OrderTotal_ID"
                sTable = "Ls_OrderTotal"
            Case 15
                sCol = "s_Number_ID"
                sTable = "Ls_Import_EndProduct"
            Case 16
                sCol = "s_Number_ID"
                sTable = "Ls_Export_EndProduct"
            Case 17
                sCol = "s_Order_ID"
                sTable = "Ls_CheckOrders"
            Case 18
                sCol = "s_NumberID"
                sTable = "Ls_TransCurr"
        End Select
        s(0) = sTable
        s(1) = sCol
        Return s
    End Function
    Public Function CheckLimitRecord(ByVal iTypeNumber As Integer, ByVal nRecord As Integer) As Boolean
        If iTypeNumber = 12 Or iTypeNumber = 13 Then
            Return False
        End If

        Dim arrs() As String = getTableColumn(iTypeNumber)
        Dim sCol As String = arrs(1)
        Dim sTable As String = arrs(0)
        Dim sql As String = "Select Count(*) as c from [" & sTable & "]"
        Dim tb As DataTable = getTableSQL(sql)
        If Not tb Is Nothing Then
            If tb.Rows(0)("c") < nRecord Then
                Return False
            End If
        End If
        Return True
    End Function
    Public Function UpdateVisbleFunc(ByVal Valid As Boolean) As Boolean
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@Valid", Valid)
        Dim sql As String = ""
        sql += " Update ls_Fun set b_valid=@Valid where i_ID=69"
        sql += " Update ls_Fun set b_valid=@Valid where i_ID=68"
        sql += " Update ls_Fun set b_valid=@Valid where i_ID=33"
        sql += " Update ls_Fun set b_valid=@Valid where i_ID=34"
        sql += " Update ls_Fun set b_valid=@Valid where i_ID=43"

        sql += " Update ls_report set Valid=@Valid where [ID]=1035"
        If Not Valid Then
            sql += " Update Ls_Objects set s_PriceLevel_ID=NULL"
        End If
        Return execSQL(sql, p)

    End Function

    Public Function getCLV() As String
        Dim d As Date = getDateSrv()
        Dim sD As String = "1900-1-1 " & d.Hour & ":" & d.Minute
        Dim sql As String = "Select * from ls_shift where Datediff(minute,dt_fromTime,@sD)>=0 and Datediff(minute,dt_toTime,@sD)<=0"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@sD", sD)
        Dim tb As DataTable = getTableSQL(sql, p)
        If tb IsNot Nothing AndAlso tb.Rows.Count > 0 Then
            Return tb.Rows(0)("s_ID")
        End If
        Return "1"
    End Function
    'doc tien thanh chu
    Public Function ReadMoneyToChar(ByVal Total As Double, ByVal m_SysCurChar As String) As String
        Dim clsu As New Ulti.ClsUti
        Dim str As String = clsu.convertMoney(Total, m_SysCurChar)
        Return str
    End Function
    Public Function getStoreIdDefault() As String
        Dim s As String = ""
        Dim sql As String = "select top 1 s_ID from ls_stores"
        Dim tb As DataTable = Me.getTableSQL(sql)
        If Not IsNothing(tb) AndAlso tb.Rows.Count > 0 Then
            s = tb.Rows(0)(0)
        End If
        Return s
    End Function
    Private Function DeleteBarcodeWeight(ByVal ID As String) As Boolean
        Return Me.execSQL("Delete from BarcodeWeight where ID=@ID", New SqlParameter("@ID", ID))
    End Function
    Public Function InsertBarcodeWeight(ByVal ID As String, ByVal BarcodeID As String, ByVal BarcodeName As String, ByVal Unit As String, ByVal Price As Double, ByVal Weight As Double, ByVal InputDate As Date) As Boolean
        If DeleteBarcodeWeight(ID) Then
            Dim sql As String = "Insert into BarcodeWeight(ID,BarcodeID,BarcodeName,Unit,Price,Weight,InputDate)"
            sql += "values(@ID,@BarcodeID,@BarcodeName,@Unit,@Price,@Weight,@InputDate)"
            Dim p(6) As SqlParameter
            p(0) = New SqlParameter("@ID", ID)
            p(1) = New SqlParameter("@BarcodeID", BarcodeID)
            p(2) = New SqlParameter("@BarcodeName", BarcodeName)
            p(3) = New SqlParameter("@Unit", Unit)
            p(4) = New SqlParameter("@Price", Price)
            p(5) = New SqlParameter("@Weight", Weight)
            p(6) = New SqlParameter("@InputDate", InputDate)
            Return Me.execSQL(sql, p)
        End If
    End Function
    Public Function UpdateSmsContent(ByVal sms As String) As Boolean
        Dim sql As String = "Update tblConfig set SmsContent=@sms"
        Return Me.execSQL(sql, New SqlParameter("@sms", sms))
    End Function
    Public Function GetSmsContent() As String
        Dim sms As String = ""
        Dim sql As String = "select top 1 SmsContent from tblConfig"
        Dim tb As DataTable = Me.getTableSQL(sql)
        If Not IsNothing(tb) AndAlso tb.Rows.Count > 0 Then
            sms = IsNull(tb.Rows(0)(0), "")
        End If
        Return sms
    End Function

End Class
