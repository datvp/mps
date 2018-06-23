Imports System.Data.SqlClient
Imports MPS.DAL
Public Class DAL_ReportOfStore
    Inherits DALSQL
    Private b_StoreProSelectOption As Boolean = False
    Private b_GroupOption As Boolean = False

    Property IsGroupOption() As Boolean
        Get
            Return b_GroupOption
        End Get
        Set(ByVal value As Boolean)
            b_GroupOption = value
        End Set
    End Property
    Property IsStoreSelectOption() As Boolean
        Get
            Return b_StoreProSelectOption
        End Get
        Set(ByVal value As Boolean)
            b_StoreProSelectOption = value
        End Set
    End Property
   

    Private Function DanhSachChonKho_PhanQuyen(ByVal m_UIDLogin As String) As String
        Dim s As String = ""
        Dim tb As DataTable = getTableSQL("Select FuncID from PR_FunRight_EXT where [R]=1 AND UID=@m_UIDLogin", New SqlParameter("@m_UIDLogin", m_UIDLogin))
        If Not tb Is Nothing Then
            For Each dr As DataRow In tb.Rows
                If s = "" Then
                    s = "N'" & dr("FuncID").ToString & "'"
                Else
                    s = s & ",N'" & dr("FuncID").ToString & "'"
                End If
            Next
        End If
        If s = "" Then
            s = "('-1')"
        Else
            s = "(" & s & ")"
        End If
        Return s
    End Function
    Private Function DanhSachChonKho(ByVal CPUID As String) As String
        Dim s As String = ""
        Dim tb As DataTable = getTableSQL("Select Store_ID from tmpStoreSelected where [ID]=@CPUID", New SqlParameter("@CPUID", CPUID))
        If Not tb Is Nothing Then
            For Each dr As DataRow In tb.Rows
                If s = "" Then
                    s = "N'" & dr("Store_ID").ToString & "'"
                Else
                    s = s & ",N'" & dr("Store_ID").ToString & "'"
                End If
            Next
        End If
        If s = "" Then
            s = "('-1')"
        Else
            s = "(" & s & ")"
        End If
        Return s
    End Function

    Private Function DanhSachChonNhom(ByVal CPUID As String) As String
        Dim s As String = ""
        Dim tb As DataTable = getTableSQL("Select ProductGroup_ID from tmpProductGroupSelected where [ID]=@CPUID", New SqlParameter("@CPUID", CPUID))
        If Not tb Is Nothing Then
            For Each dr As DataRow In tb.Rows
                If s = "" Then
                    s = "N'" & dr("ProductGroup_ID").ToString & "'"
                Else
                    s = s & ",N'" & dr("ProductGroup_ID").ToString & "'"
                End If
            Next
        End If
        If s = "" Then
            s = "('-1')"
        Else
            s = "(" & s & ")"
        End If
        Return s
    End Function

    Public Function getListStoreSelect(ByVal CPUID As String) As String
        Dim ten As String = ""
        Dim sql As String = "select s.s_Name from Ls_Stores s inner join tmpStoreSelected t on s.s_ID=t.Store_ID and t.ID=@CPUID"
        Dim tb As DataTable = Me.getTableSQL(sql, New SqlParameter("@CPUID", CPUID))
        If Not IsNothing(tb) AndAlso tb.Rows.Count > 0 Then
            For Each r As DataRow In tb.Rows
                If ten <> "" Then
                    ten += "," & r(0).ToString
                Else
                    ten += r(0).ToString
                End If
            Next
        End If
        Return ten
    End Function

    Public Function getListReport() As DataTable
        Return getTableSQL("Select * from Ls_Report where Valid=1 Order by IDSort asc")
    End Function

    Public Function UpdateImageReport(ByVal ID As String, ByVal ArrIM As Byte()) As Boolean
        '
        Dim sql As String = ""
        sql = " Delete from PR_ImageReport where [ID]=@ID"
        sql += " Insert into PR_ImageReport(ID,IM)values (@ID,@IM)"
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        p(1) = New SqlParameter("@IM", ArrIM)
        Return execSQL(sql, p)
    End Function
    Public Function LoadImageReport(ByVal ID As String) As Byte()
        '
        Dim sql As String = ""
        sql = "Select * from PR_ImageReport where [ID]=@ID Order by IDSort desc"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        Dim tb As DataTable = getTableSQL(sql, p)
        If tb.Rows.Count > 0 Then
            If Not IsDBNull(tb.Rows(0)("IM")) Then
                Return tb.Rows(0)("IM")
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function


    Private Function InsertImportDetail(ByVal CPUID As String, ByVal ImportDetailID As String, ByVal Product_ID As String, ByVal Qty As Double) As Boolean
        If Not isInsertImportDetail Then Return True
        Dim sql As String = "Insert into rptTotalOrderProduct(ID,Product_ID,s_ID,Qty)values(@ID,@Product_ID,@s_ID,@Qty)"

        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@ID", CPUID)
        p(1) = New SqlParameter("@s_ID", ImportDetailID)
        p(2) = New SqlParameter("@Product_ID", Product_ID)
        p(3) = New SqlParameter("@Qty", Qty)
        Return execSQL(sql, p)
    End Function
    Dim isInsertImportDetail As Boolean = False
    Public Function getTotalInstock(ByVal Store_ID As String, ByVal Product_ID As String, ByVal dayMonh As Date) As Double
        Dim sql As String = ""

        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", dayMonh)
        p(2) = New SqlParameter("@Product_ID", Product_ID)
        '23.02.2011n thay doi Ordinal asc===desc
        If Store_ID <> "" Then
            sql = "Select isnull(sum(Exchange*(QImport-QOrder)),0) as Instock,Store_ID  from v_thekho where Datediff(day,dayMonth,@fromDate)>0 and Store_ID=@Store_ID and Product_ID=@Product_ID Group by Store_ID"
            sql += " Select IDDetail, DayMonth,Datediff(day,'2009-1-1',DayMonth) as nDay,Ordinal,i_IDSort,QImport*Exchange as QImport,OriPrice/Exchange as Price,Store_ID " 'thay Price=OriPrice
            sql += " from v_thekho where Datediff(day,dayMonth,@fromDate)>0 and QImport<>0 and Store_ID=@Store_ID and Product_ID=@Product_ID "
            sql += " Order by Store_ID asc, Datediff(day,'2009-1-1',DayMonth) desc,Ordinal desc,i_IDSort desc"
        Else
            sql = "Select isnull(sum(Exchange*(QImport-QOrder)),0) as Instock,'' as Store_ID from v_thekho where Datediff(day,dayMonth,@fromDate)>0 and Product_ID=@Product_ID"
            sql += " Select IDDetail,DayMonth,Datediff(day,'2009-1-1',DayMonth) as  nDay,Ordinal,i_IDSort,QImport*Exchange as QImport,"
            sql += " OriPrice/Exchange as Price,'' as Store_ID from v_thekho  where Datediff(day,dayMonth,@fromDate)>0  " 'thay Price=OriPrice
            sql += " And Manghiepvu Not in ('NHCK','XHCK')"
            sql += " and QImport<>0 and Product_ID=@Product_ID Order by Datediff(day,'2009-1-1',DayMonth) "
            sql += " desc,Ordinal desc,i_IDSort desc"

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
            Dim DF() As DataRow = tbImport.Select("Store_ID='" & dr("Store_ID").ToString.Replace("'", "''") & "'", "nDay desc,Ordinal desc,i_IDSort desc")
            While Ton > 0 And i < DF.Length
                If Ton > DF(i)("QImport") Then
                    Total += DF(i)("Price") * DF(i)("QImport")
                    InsertImportDetail(sCPUID, DF(i)("IDDetail"), Product_ID, DF(i)("QImport"))
                    Ton -= DF(i)("QImport")
                    DF(i)("QImport") = 0
                Else
                    InsertImportDetail(sCPUID, DF(i)("IDDetail"), Product_ID, Ton)

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
    Public Function getPriceInstock(ByVal Store_ID As String, ByVal Product_ID As String, ByVal dayMonh As Date, ByVal QtyInstock As Double) As Double

        Dim Total As Double = getTotalInstock(Store_ID, Product_ID, dayMonh)
        If QtyInstock <> 0 Then
            Return Total / QtyInstock
        Else
            Return 0
        End If


    End Function
    Private Function InsertStoreCard(ByVal sID As String, ByVal ID As String, ByVal Ordinal As Integer, _
                                     ByVal NumberID As String, ByVal DayMonth As Date, ByVal Note As String, _
                                     ByVal Price As Double, ByVal QImport As Double, ByVal QOrder As Double, _
                                     ByVal QInstock As Double, ByVal Exchange As Double, ByVal ObjectName As String) As Boolean
        '26.05.10-bo sung ObjectName
        Dim sql As String = ""
        Dim p(11) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        p(1) = New SqlParameter("@Ordinal", Ordinal)
        p(2) = New SqlParameter("@NumberID", NumberID)
        p(3) = New SqlParameter("@DayMonth", DayMonth)
        p(4) = New SqlParameter("@Note", Note)
        p(5) = New SqlParameter("@Price", Price)
        p(6) = New SqlParameter("@QImport", QImport)
        p(7) = New SqlParameter("@QOrder", QOrder)
        p(8) = New SqlParameter("@Exchange", Exchange)
        p(9) = New SqlParameter("@QInstock", QInstock)
        p(10) = New SqlParameter("@sID", sID)
        p(11) = New SqlParameter("@ObjectName", ObjectName)

        If NumberID <> "" Then
            sql = "Insert into rptStoreCard([s_NumberID], [ID], Ordinal, NumberID, DayMonth, Note, Price, "
            sql += "QImport, QOrder, Exchange, QInstock, ObjectName)"
            sql += " values(@sID, @ID, @Ordinal, @NumberID, @DayMonth, @Note, @Price, @QImport, @QOrder, "
            sql += "@Exchange, @QInstock, @ObjectName)"
        Else
            sql = "Insert into rptStoreCard([s_NumberID], [ID], Ordinal, Note, Price, QImport, QOrder, "
            sql += "Exchange, QInstock, ObjectName)"
            sql += " values(@sID, @ID, @Ordinal, @Note, @Price, @QImport, @QOrder, @Exchange, @QInstock, @ObjectName)"
        End If
        Return execSQL(sql, p)
    End Function
    Public Function getMsgRpt(ByVal str As String) As String
        Return str
    End Function
    Public Function rptStoreCard(ByVal CPUID As String, ByVal Store_ID As String, ByVal Product_ID As String, _
                                 ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Double, _
                                 ByVal s_Unit As String, ByVal branchId As String) As DataTable

        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@toDate", toDate)
        p(3) = New SqlParameter("@Product_ID", Product_ID)

        Dim sql As String
        If Not execSQL("Delete from rptStoreCard where [ID]=N'" & CPUID.Replace("'", "''") & "'") Then
            Return Nothing
        End If
        sql = "Select isnull(sum(ExChange*(QImport-QOrder)),0) as Q from V_OLD_Thekho where Datediff(day,dayMonth,@fromDate)>0 and Product_ID=@Product_ID"
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And Store_ID=@Store_ID"
            End If
        Else
            sql += " AND Store_ID in " & DanhSachChonKho(CPUID)
        End If
        Dim tb As DataTable = getTableSQL(sql, p)

        Dim instock As Double = tb.Rows(0)("Q")
        Dim PriceBegin As Double = getPriceInstock(Store_ID, Product_ID, fromDate, instock)

        If Not InsertStoreCard("", CPUID, 1, "", CDate("1900-1-1"), getMsgRpt("Đầu kỳ"), PriceBegin, 0, 0, instock, 1, "") Then
            Return Nothing
        End If

        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@toDate", toDate)
        p(3) = New SqlParameter("@Product_ID", Product_ID)
        sql = "Select * from V_OLD_Thekho where Product_ID=@Product_ID and " & getQueryDate(fromDate, toDate, "dayMonth")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And Store_ID=@Store_ID"
            Else
                sql += " And Manghiepvu not in ('XHCK','NHCK')"
            End If
        Else
            sql += " AND Store_ID in " & DanhSachChonKho(CPUID)
        End If

        sql += " Order by Datediff(day,'2009-1-1',DayMonth) asc,Ordinal asc,i_IDSort asc"
        tb = getTableSQL(sql, p)
        Dim i As Integer = 2
        For Each dr As DataRow In tb.Rows
            '25.08.2009-MInh Tam------------------------
            Dim QImport As Double = CDbl(dr("QImport"))
            Dim QOrder As Double = CDbl(dr("QOrder"))
            Dim QExchange As Double = CDbl(dr("Exchange"))
            Dim Price As Double = CDbl(dr("Price"))
            If QExchange <> 0 Then
                QImport = QImport * QExchange
                QOrder = QOrder * QExchange
                Price = Price / QExchange
            End If
            instock += QImport - QOrder
            '26.05.10-bo sung ObjectName
            If Not InsertStoreCard(dr("ID"), CPUID, i, dr("NumberID"), dr("dayMonth"), getMsgRpt(dr("Note")), Price, _
                                   QImport, QOrder, instock, 1, IsNull(dr("ObjectName"), "")) Then
                Return Nothing
            End If
            '=============================================
            i += 1
        Next

        p(0) = New SqlParameter("@s_Unit", s_Unit)
        p(1) = New SqlParameter("@Unit", Unit)
        p(2) = New SqlParameter("@ID", CPUID)
        p(3) = Nothing
        sql = "Update rptStoreCard set Exchange=@Unit, Unit=@s_Unit, Price=Price*@Unit,QImport=QImport/@Unit,QOrder=QOrder/@Unit,QInstock=QInstock/@Unit where [ID]=@ID"
        If Not execSQL(sql, p) Then
            Return Nothing
        End If

        sql = "Select * from rptStoreCard where [ID]=N'" & CPUID.Replace("'", "''") & "' Order by [Ordinal] asc"
        tb = getTableSQL(sql)

        Return tb
    End Function

    Private Function getTableNameUnit(ByVal Unit As String) As String
        Dim sTableNameUnit As String = "V_DefaultUnitOrder"
        Select Case Unit
            Case 0
                sTableNameUnit = "V_DefaultUnitOrder"
            Case 1
                sTableNameUnit = "V_DefaultUnitImport"
            Case 2
                sTableNameUnit = "V_DefaultUnitInstock"
            Case 3
                sTableNameUnit = "V_UnitMain"
        End Select
        Return sTableNameUnit
    End Function

    Private sCPUID, sStore_ID, sGroup_ID, m_sLevel As String
    Private m_iLevel As Integer = -9

    Private dfromDate, dtoDate As Date
    Private nCaseProcess As Integer = -1
    Private tbProcess As DataTable
    Private m_isNXTTotal As Boolean = True
    Private Sub TinhNXT()
        If Not InstockAt(sCPUID, sStore_ID, sGroup_ID, dfromDate.AddDays(-1)) Then
            Exit Sub
        End If

        If Not execSQL("Update [rptInstock] set CBegin=0,QImport=0,CImport=0,QOrder=0,COrder=0 where [ID]=N'" & sCPUID.Replace("'", "''") & "'") Then
            Exit Sub
        End If
        Dim p(5) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", sStore_ID)
        p(1) = New SqlParameter("@fromDate", dfromDate)
        p(2) = New SqlParameter("@toDate", dtoDate)
        p(3) = New SqlParameter("@Group_ID", sGroup_ID)
        p(4) = New SqlParameter("@ID", sCPUID)
        p(5) = Nothing
        Dim sql As String = ""
        sql += " Update rptInstock set QOrder=t.QO,QImport=t.QI,CImport=t.CI from "
        sql += " (Select v.Product_ID,sum(v.Exchange*v.QOrder) as QO,sum(v.Exchange*v.QImport) as QI,sum(v.QImport*v.OriPrice) as CI from V_thekho v,rptInstock r " 'thay v.Price = v.OriPrice trong nhap
        sql += " WHERE v.Product_ID=r.Product_ID and r.[ID]=@ID And " & getQueryDate(dfromDate, dtoDate, "v.dayMonth")
        If Not IsStoreSelectOption Then
            If sStore_ID <> "" Then
                sql += " And v.Store_ID=@Store_ID"
            Else
                sql += " and v.manghiepvu not in ('NHCK','XHCK')"
            End If
        Else
            sql += " AND v.Store_ID in " & DanhSachChonKho(sCPUID)
        End If
        sql += " Group by v.Product_ID) as t where rptInstock.Product_ID=t.Product_ID"

        If Not m_isNXTTotal Then

            'Chi tiet nhap
            sql += " Update rptInstock set QMainImport=t.Qty from "
            sql += " (Select v.Product_ID,sum(v.Exchange*v.QImport) as Qty from V_thekho v,rptInstock r "
            sql += " where v.Product_ID=r.Product_ID and r.[ID]=@ID And v.Manghiepvu='NH' And " & getQueryDate(dfromDate, dtoDate, "v.dayMonth")
            If Not IsStoreSelectOption Then
                If sStore_ID <> "" Then
                    sql += " And v.Store_ID=@Store_ID"
                End If
            Else
                sql += " AND v.Store_ID in " & DanhSachChonKho(sCPUID)
            End If
            sql += " Group by v.Product_ID) as t where rptInstock.Product_ID=t.Product_ID"

            sql += " Update rptInstock set QImportReturn=t.Qty from "
            sql += " (Select v.Product_ID,sum(v.Exchange*v.QImport) as Qty from V_thekho v,rptInstock r "
            sql += " where v.Product_ID=r.Product_ID and r.[ID]=@ID And v.Manghiepvu='NHT' And " & getQueryDate(dfromDate, dtoDate, "v.dayMonth")
            If Not IsStoreSelectOption Then
                If sStore_ID <> "" Then
                    sql += " And v.Store_ID=@Store_ID"
                End If
            Else
                sql += " AND v.Store_ID in " & DanhSachChonKho(sCPUID)
            End If
            sql += " Group by v.Product_ID) as t where rptInstock.Product_ID=t.Product_ID"

            'Chi tiet xuat
            sql += " Update rptInstock set QMainOrder=t.Qty from " 'xuat ban hang
            sql += " (Select v.Product_ID,sum(v.Exchange*v.QOrder) as Qty from V_thekho v,rptInstock r "
            sql += " where v.Product_ID=r.Product_ID and r.[ID]=@ID And v.Manghiepvu='XH' And " & getQueryDate(dfromDate, dtoDate, "v.dayMonth")
            If Not IsStoreSelectOption Then
                If sStore_ID <> "" Then
                    sql += " And v.Store_ID=@Store_ID"
                End If
            Else
                sql += " AND v.Store_ID in " & DanhSachChonKho(sCPUID)
            End If
            sql += " Group by v.Product_ID) as t where rptInstock.Product_ID=t.Product_ID"

            sql += " Update rptInstock set QOrderReturn=t.Qty from " 'xuat ban hang
            sql += " (Select v.Product_ID,sum(v.Exchange*v.QOrder) as Qty from V_thekho v,rptInstock r "
            sql += " where v.Product_ID=r.Product_ID and r.[ID]=@ID And v.Manghiepvu='XHT' And " & getQueryDate(dfromDate, dtoDate, "v.dayMonth")
            If Not IsStoreSelectOption Then
                If sStore_ID <> "" Then
                    sql += " And v.Store_ID=@Store_ID"
                End If
            Else
                sql += " AND v.Store_ID in " & DanhSachChonKho(sCPUID)
            End If
            sql += " Group by v.Product_ID) as t where rptInstock.Product_ID=t.Product_ID"

            sql += " Update rptInstock set QImportOther=isnull(QImport,0) -isnull(QMainImport,0)-isnull(QImportReturn,0)"
            sql += " ,QOrderOther=isnull(QOrder,0) -isnull(QMainOrder,0)-isnull(QOrderReturn,0) where [ID]=@ID"

        End If

        If Not execSQL(sql, p) Then
            Exit Sub
        End If

        Dim tb As DataTable = getTableSQL("Select * from [rptInstock] where [ID]=N'" & sCPUID.Replace("'", "''") & "'")
        If Not IsNothing(tb) Then
            For Each dr As DataRow In tb.Rows
                Dim CBegin As Double = 0
                If dr("QBegin") > 0 Then
                    CBegin = getTotalInstock(sStore_ID, dr("Product_ID"), dfromDate)
                End If

                Dim CImport As Double = dr("CImport")
                Dim CInstock As Double = 0
                If dr("QBegin") + dr("QImport") > dr("QOrder") Then
                    CInstock = getTotalInstock(sStore_ID, dr("Product_ID"), dtoDate.AddDays(1))
                End If
                Dim COrder As Double = CBegin + CImport - CInstock
                p(0) = New SqlParameter("@Product_ID", dr("Product_ID"))
                p(1) = New SqlParameter("@COrder", COrder)
                p(2) = New SqlParameter("@CBegin", CBegin)
                p(3) = New SqlParameter("@ID", sCPUID)
                p(4) = Nothing
                p(5) = Nothing

                If CImport <> 0 Or COrder <> 0 Or CBegin <> 0 Then
                    sql = "Update rptInstock set CBegin=@CBegin, COrder=@COrder where Product_ID=@Product_ID and [ID]=@ID"
                    If Not execSQL(sql, p) Then
                        Exit Sub
                    End If
                End If
            Next
        End If

    End Sub

    Public Sub TinhNXT(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                       ByVal fromDate As Date, ByVal toDate As Date)
        sCPUID = CPUID : sStore_ID = Store_ID : sGroup_ID = Group_ID : dfromDate = fromDate : dtoDate = toDate
        TinhNXT()
    End Sub

    Public Function rptInstockOfProductSupplier(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                             ByVal dayMonth As Date, ByVal Product_ID As String, ByVal Object_ID As String) As DataSet

        isInsertImportDetail = True
        sCPUID = CPUID
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@s_ProductGroupID", Group_ID)
        p(1) = New SqlParameter("@Product_ID", Product_ID)
        Dim sql As String = ""
        'Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptTotalOrderProduct where [ID]=N'" & CPUID.Replace("'", "''") & "'" & vbCrLf
        sql += " Select s_ID from ls_Products where 1=1 "
        If Product_ID <> "" Then
            sql += " and s_ID=@Product_ID"
        Else
            If Not IsGroupOption Then
                If Group_ID <> "" Then
                    sql += " and s_ProductGroupID=@s_ProductGroupID"
                End If
            Else
                sql += " AND s_ProductGroupID in " & DanhSachChonNhom(CPUID)
            End If
        End If
        Dim d As Date = dayMonth.AddDays(1)
        Dim tb As DataTable = getTableSQL(sql, p)
        For Each dr As DataRow In tb.Rows
            Dim t As Double = getTotalInstock(Store_ID, dr("s_ID"), d)
        Next
        Dim pr(1) As SqlParameter
        pr(0) = New SqlParameter("@Object_ID", Object_ID)
        pr(1) = New SqlParameter("@CPUID", CPUID)

        sql = "Select ls.s_ID, ls.s_Product_ID,ls.s_Name as Product_Name,ls.s_Unit,cast(0 as float) as Qty from ls_Products ls "
        sql += " where ls.s_ID in ( Select rpt.Product_ID from  rptTotalOrderProduct rpt where rpt.ID=@CPUID) Order by ls.s_Name asc"

        If Object_ID <> "" Then

            sql += " Select dt.s_Product_ID, ls.s_Object_ID, ls.s_Name as Object_Name, "
            sql += " sum(rpt.Qty) as Qty, sum(dt.m_Price*rpt.Qty/dt.f_Convert) as Total "
            sql += " from LS_Imports i, PR_ImportDetail dt,rptTotalOrderProduct rpt,Ls_Objects ls "
            sql += " where dt.s_ID=rpt.s_ID and i.s_ID=dt.s_Import_ID and ls.s_ID=i.s_Object_ID "
            sql += " and i.s_Object_ID=@Object_ID  and rpt.[ID]=@CPUID"
            sql += " group by dt.s_Product_ID, ls.s_Object_ID, ls.s_Name"
            sql += " Order by ls.s_Name asc"
        Else
            sql += " Select dt.s_Product_ID, ls.s_Object_ID, ls.s_Name as Object_Name, "
            sql += " sum(rpt.Qty) as Qty, sum(dt.m_Price*rpt.Qty/dt.f_Convert) as Total "
            sql += " from LS_Imports i, PR_ImportDetail dt,rptTotalOrderProduct rpt,Ls_Objects ls "
            sql += " where dt.s_ID=rpt.s_ID and i.s_ID=dt.s_Import_ID and ls.s_ID=i.s_Object_ID "
            sql += " and rpt.[ID]=@CPUID"
            sql += " group by dt.s_Product_ID, ls.s_Object_ID, ls.s_Name"
            sql += " Order by ls.s_Name asc"

        End If

        Dim ds As DataSet = getDatasetSQL(sql, pr)

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim t As Double = 0
            Dim df() As DataRow = ds.Tables(1).Select("s_Product_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
            For Each dr1 As DataRow In df
                t += dr1("Qty")
            Next
            dr("Qty") = t
        Next
        ds.Relations.Add("Ref11", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("s_Product_ID"))
        Return ds
    End Function

    Public Function rptInstockOfSupplier(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                             ByVal dayMonth As Date, ByVal Product_ID As String, ByVal Object_ID As String) As DataSet

        isInsertImportDetail = True
        sCPUID = CPUID
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@s_ProductGroupID", Group_ID)
        p(1) = New SqlParameter("@Product_ID", Product_ID)
        Dim sql As String = ""
        'Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptTotalOrderProduct where [ID]=N'" & CPUID.Replace("'", "''") & "'" & vbCrLf
        sql += " Select s_ID from ls_Products where 1=1 "
        If Product_ID <> "" Then
            sql += " and s_ID=@Product_ID"
        Else
            If Not IsGroupOption Then
                If Group_ID <> "" Then
                    sql += " and s_ProductGroupID=@s_ProductGroupID"
                End If
            Else
                sql += " AND s_ProductGroupID in " & DanhSachChonNhom(CPUID)
            End If
        End If
        Dim d As Date = dayMonth.AddDays(1)
        Dim tb As DataTable = getTableSQL(sql, p)
        For Each dr As DataRow In tb.Rows
            Dim t As Double = getTotalInstock(Store_ID, dr("s_ID"), d)
        Next
        Dim pr(1) As SqlParameter
        pr(0) = New SqlParameter("@Object_ID", Object_ID)
        pr(1) = New SqlParameter("@CPUID", CPUID)

        If Object_ID <> "" Then
            sql = "Select * from ls_Objects where s_ID=@Object_ID"
            sql += " Select i.s_Object_ID, ls.s_Product_ID,ls.s_Name as Product_Name,ls.s_Unit, sum(rpt.Qty) as Qty, sum(dt.m_Price*rpt.Qty/dt.f_Convert) as Total from LS_Imports i, PR_ImportDetail dt,ls_Products ls,rptTotalOrderProduct rpt "
            sql += " where dt.s_ID=rpt.s_ID and dt.s_Product_ID=ls.s_ID and i.s_ID=dt.s_Import_ID "
            sql += " and i.s_Object_ID=@Object_ID  and rpt.[ID]=@CPUID"
            sql += " group by i.s_Object_ID, ls.s_Product_ID,ls.s_Name,ls.s_Unit"
            sql += " Order by ls.s_Name asc"
        Else
            sql = "Select * from ls_Objects where b_Supplier=1 Order by s_Name asc"
            sql += " Select i.s_Object_ID, ls.s_Product_ID,ls.s_Name as Product_Name,ls.s_Unit, sum(rpt.Qty) as Qty, sum(dt.m_Price*rpt.Qty/dt.f_Convert) as Total from LS_Imports i, PR_ImportDetail dt,ls_Products ls,rptTotalOrderProduct rpt "
            sql += " where dt.s_ID=rpt.s_ID and dt.s_Product_ID=ls.s_ID and i.s_ID=dt.s_Import_ID "
            sql += "  and rpt.[ID]=@CPUID"
            sql += " group by i.s_Object_ID, ls.s_Product_ID,ls.s_Name,ls.s_Unit"
            sql += " Order by ls.s_Name asc"
        End If

        Dim ds As DataSet = getDatasetSQL(sql, pr)
        If Not ds.Tables(0).Columns.Contains("Total") Then
            ds.Tables(0).Columns.Add("Total", GetType(Double))
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim DF() As DataRow = ds.Tables(1).Select("s_Object_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
            If DF.Length = 0 Then
                dr.Delete()
            Else
                Dim t As Double = 0
                For Each r As DataRow In DF
                    t += r("Total")
                Next
                dr("Total") = t
            End If
        Next
        ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("s_Object_ID"))
        Return ds
    End Function

    Public Function rptOfNXT(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                             ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal isAll As Boolean, Optional ByVal isTotal As Boolean = True) As DataTable
        sCPUID = CPUID : sStore_ID = Store_ID : sGroup_ID = Group_ID : dfromDate = fromDate : dtoDate = toDate : m_isNXTTotal = isTotal

        TinhNXT()

        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@toDate", toDate)
        p(3) = New SqlParameter("@Group_ID", Group_ID)

        Dim sql As String = ""

        Dim sDetail As String = ""
        If Not isTotal Then
            sDetail = ",QMainImport/ls.Exchange as QMainImport,QImportOther/ls.Exchange as QImportOther,"
            sDetail += " QImportReturn/ls.Exchange as QImportReturn,QMainOrder/ls.Exchange as QMainOrder,QOrderOther/ls.Exchange as QOrderOther,QOrderReturn/ls.Exchange as QOrderReturn"
        End If
        Dim sTableUnit As String = getTableNameUnit(Unit)
        sql = "Delete from rptInstock where QBegin=0 and QImport=0 and QOrder=0 and [ID]=N'" & CPUID.Replace("'", "''") & "'"
        sql += " Select ls.Product_ID,ls.Product_Name,ls.Unit,ls.Exchange, t.QBegin/ls.Exchange as QBegin,"
        sql += " t.CBegin ,t.QImport/ls.Exchange as QImport,t.CImport,t.QOrder/ls.Exchange as QOrder,"
        sql += " t.COrder, (t.QBegin+t.QImport-t.QOrder)/ls.Exchange as QInstock,(t.CBegin+t.CImport-t.COrder) as CInstock"
        sql += sDetail
        sql += " from rptInstock t Join [" & sTableUnit & "] ls "
        sql += " On t.Product_ID=ls.Product_Key "
        sql += " where t.[ID] = N'" & CPUID.Replace("'", "''") & "' "
        If isAll = False Then 'hang co phat sinh xuat nhap
            sql += " and (t.QImport/ls.Exchange<>0 or t.QOrder/ls.Exchange<>0)"
        End If
        sql += " Order by ls.Product_Name asc"

        Dim tb As DataTable = getTableSQL(sql)

        Return tb
    End Function
    ''' <summary>
    ''' báo cáo customize thêm
    ''' </summary>
    ''' <param name="CPUID"></param>
    ''' <param name="Store_ID"></param>
    ''' <param name="Group_ID"></param>
    ''' <param name="fromDate"></param>
    ''' <param name="toDate"></param>
    ''' <param name="Unit"></param>
    ''' <param name="isAll"></param>
    ''' <param name="isTotal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function rptNhapXuatTon_new(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                             ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal isAll As Boolean, Optional ByVal isTotal As Boolean = True) As DataTable
        sCPUID = CPUID : sStore_ID = Store_ID : sGroup_ID = Group_ID : dfromDate = fromDate : dtoDate = toDate : m_isNXTTotal = isTotal

        If Not InstockAt_2(sCPUID, sStore_ID, sGroup_ID, dfromDate.AddDays(-1)) Then
            Return Nothing
        End If
        If Not execSQL("Update [rptInstock] set CBegin=0,QImport=0,CImport=0,QOrder=0,COrder=0 where [ID]=@CPUID", New SqlParameter("@CPUID", CPUID)) Then
            Return Nothing
        End If
        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", sStore_ID)
        p(1) = New SqlParameter("@fromDate", dfromDate)
        p(2) = New SqlParameter("@toDate", dtoDate)
        p(3) = New SqlParameter("@Group_ID", sGroup_ID)
        p(4) = New SqlParameter("@ID", sCPUID)

        Dim sql As String = ""
        sql += " Update rptInstock set QOrder=t.QO,QImport=t.QI,CImport=t.CI from "
        sql += " (Select v.Product_ID,sum(v.Exchange*v.QOrder) as QO,sum(v.Exchange*v.QImport) as QI,sum(v.QImport*v.OriPrice) as CI from V_thekho v,rptInstock r " 'thay v.Price = v.OriPrice trong nhap
        sql += " WHERE v.Product_ID=r.Product_ID and r.[ID]=@ID And " & getQueryDate(fromDate, toDate, "v.dayMonth")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And v.Store_ID=@Store_ID"
            End If
        Else
            sql += " AND v.Store_ID in " & DanhSachChonKho(CPUID)
        End If
        sql += " and v.manghiepvu not in ('NHCK','XHCK','NK','XK')"
        sql += " Group by v.Product_ID) as t where rptInstock.Product_ID=t.Product_ID"

        If Not m_isNXTTotal Then
            'Chi tiet nhap
            sql += " Update rptInstock set QMainImport=t.Qty from "
            sql += " (Select v.Product_ID,sum(v.Exchange*v.QImport) as Qty from V_thekho v,rptInstock r "
            sql += " where v.Product_ID=r.Product_ID and r.[ID]=@ID And v.Manghiepvu='NH' And " & getQueryDate(fromDate, toDate, "v.dayMonth")
            If Not IsStoreSelectOption Then
                If Store_ID <> "" Then
                    sql += " And v.Store_ID=@Store_ID"
                End If
            Else
                sql += " AND v.Store_ID in " & DanhSachChonKho(CPUID)
            End If
            sql += " and v.manghiepvu not in ('NHCK','XHCK','NK','XK')"
            sql += " Group by v.Product_ID) as t where rptInstock.Product_ID=t.Product_ID"
            sql += vbCrLf
            sql += " Update rptInstock set QImportReturn=t.Qty from "
            sql += " (Select v.Product_ID,sum(v.Exchange*v.QImport) as Qty from V_thekho v,rptInstock r "
            sql += " where v.Product_ID=r.Product_ID and r.[ID]=@ID And v.Manghiepvu='NHT' And " & getQueryDate(fromDate, toDate, "v.dayMonth")
            If Not IsStoreSelectOption Then
                If Store_ID <> "" Then
                    sql += " And v.Store_ID=@Store_ID"
                End If
            Else
                sql += " AND v.Store_ID in " & DanhSachChonKho(CPUID)
            End If
            sql += " and v.manghiepvu not in ('NHCK','XHCK','NK','XK')"
            sql += " Group by v.Product_ID) as t where rptInstock.Product_ID=t.Product_ID"

            'Chi tiet xuat
            sql += " Update rptInstock set QMainOrder=t.Qty from " 'xuat ban hang
            sql += " (Select v.Product_ID,sum(v.Exchange*v.QOrder) as Qty from V_thekho v,rptInstock r "
            sql += " where v.Product_ID=r.Product_ID and r.[ID]=@ID And v.Manghiepvu='XH' And " & getQueryDate(fromDate, toDate, "v.dayMonth")
            If Not IsStoreSelectOption Then
                If Store_ID <> "" Then
                    sql += " And v.Store_ID=@Store_ID"
                End If
            Else
                sql += " AND v.Store_ID in " & DanhSachChonKho(CPUID)
            End If
            sql += " and v.manghiepvu not in ('NHCK','XHCK','NK','XK')"
            sql += " Group by v.Product_ID) as t where rptInstock.Product_ID=t.Product_ID"
            sql += vbCrLf
            sql += " Update rptInstock set QOrderReturn=t.Qty from " 'xuat ban hang
            sql += " (Select v.Product_ID,sum(v.Exchange*v.QOrder) as Qty from V_thekho v,rptInstock r "
            sql += " where v.Product_ID=r.Product_ID and r.[ID]=@ID And v.Manghiepvu='XHT' And " & getQueryDate(fromDate, toDate, "v.dayMonth")
            If Not IsStoreSelectOption Then
                If Store_ID <> "" Then
                    sql += " And v.Store_ID=@Store_ID"
                End If
            Else
                sql += " AND v.Store_ID in " & DanhSachChonKho(CPUID)
            End If
            sql += " and v.manghiepvu not in ('NHCK','XHCK','NK','XK')"
            sql += " Group by v.Product_ID) as t where rptInstock.Product_ID=t.Product_ID"
            sql += vbCrLf
            sql += " Update rptInstock set QImportOther=isnull(QImport,0) -isnull(QMainImport,0)-isnull(QImportReturn,0)"
            sql += " ,QOrderOther=isnull(QOrder,0) -isnull(QMainOrder,0)-isnull(QOrderReturn,0) where [ID]=@ID"

        End If

        If Not execSQL(sql, p) Then
            Return Nothing
        End If


        Dim tb As DataTable = getTableSQL("Select * from [rptInstock] where [ID]=@CPUID", New SqlParameter("@CPUID", CPUID))
        If Not IsNothing(tb) Then
            For Each dr As DataRow In tb.Rows
                Dim CBegin As Double = 0
                If dr("QBegin") > 0 Then
                    CBegin = getTotalInstock(sStore_ID, dr("Product_ID"), dfromDate)
                End If

                Dim CImport As Double = dr("CImport")
                Dim CInstock As Double = 0
                If dr("QBegin") + dr("QImport") > dr("QOrder") Then
                    CInstock = getTotalInstock(sStore_ID, dr("Product_ID"), dtoDate.AddDays(1))
                End If
                Dim COrder As Double = CBegin + CImport - CInstock
                Dim pm(3) As SqlParameter
                pm(0) = New SqlParameter("@Product_ID", dr("Product_ID"))
                pm(1) = New SqlParameter("@COrder", COrder)
                pm(2) = New SqlParameter("@CBegin", CBegin)
                pm(3) = New SqlParameter("@ID", sCPUID)

                If CImport <> 0 Or COrder <> 0 Or CBegin <> 0 Then
                    sql = "Update rptInstock set CBegin=@CBegin, COrder=@COrder where Product_ID=@Product_ID and [ID]=@ID"
                    If Not execSQL(sql, pm) Then
                        Return Nothing
                    End If
                End If
            Next
        End If

        Dim sTableUnit As String = getTableNameUnit(Unit)
        sql = "Delete from rptInstock where QBegin=0 and QImport=0 and QOrder=0 and [ID]=@CPUID"
        sql += vbCrLf
        sql += " Select ls.Product_ID,ls.Product_Name,ls.Unit,ls.Exchange, t.QBegin/ls.Exchange as QBegin,"
        sql += " t.CBegin ,t.QImport/ls.Exchange as QImport,t.CImport,t.QOrder/ls.Exchange as QOrder,"
        sql += " t.COrder, (t.QBegin+t.QImport-t.QOrder)/ls.Exchange as QInstock,(t.CBegin+t.CImport-t.COrder) as CInstock"
        If Not isTotal Then
            sql += ",QMainImport/ls.Exchange as QMainImport,QImportOther/ls.Exchange as QImportOther,"
            sql += " QImportReturn/ls.Exchange as QImportReturn,QMainOrder/ls.Exchange as QMainOrder,QOrderOther/ls.Exchange as QOrderOther,QOrderReturn/ls.Exchange as QOrderReturn"
        End If
        sql += " from rptInstock t Join [" & sTableUnit & "] ls On t.Product_ID=ls.Product_Key"
        sql += " where t.[ID] =@CPUID"
        If isAll = False Then 'hang co phat sinh xuat nhap
            sql += " and (t.QImport/ls.Exchange<>0 or t.QOrder/ls.Exchange<>0)"
        End If
        sql += " Order by ls.Product_Name asc"
        Return getTableSQL(sql, New SqlParameter("@CPUID", CPUID))
    End Function
    Private Function InstockAt(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal dayMonth As Date) As Boolean
        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@dayMonth", dayMonth)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@ID", CPUID)

        Dim sql As String
        If Not execSQL("Delete from [rptInstock] where [ID]=N'" & CPUID.Replace("'", "''") & "'") Then
            Return False
        End If

        sql = "INSERT INTO [rptInstock]([ID],[Product_ID],[QBegin])"
        sql += vbCrLf
        sql += " select @ID, s_ID , 0 from ls_Products p where isnull(p.b_IsService,0)=0"
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and p.s_ProductGroupID=@Group_ID"
            End If
        Else
            sql += " AND p.s_ProductGroupID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " and not exists(Select top 1 1 from V_Thekho v where v.Product_ID=p.s_ID and Datediff(day,v.dayMonth,@dayMonth)>=0"
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And v.Store_ID=@Store_ID"
            End If
        Else
            sql += " AND v.Store_ID in " & DanhSachChonKho(CPUID)
        End If
        sql += ")"
        sql += vbCrLf
        sql += " union all "
        sql += vbCrLf
        sql += " Select @ID, ls.s_ID, isnull(sum(v.ExChange*(v.QImport-v.QOrder)),0) as Q from ls_Products ls inner join V_Thekho v"
        sql += "  On ls.s_ID=v.Product_ID and Datediff(day,v.dayMonth,@dayMonth)>=0 "
        sql += " where 1=1"
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and ls.s_ProductGroupID=@Group_ID"
            End If
        Else
            sql += " AND ls.s_ProductGroupID in " & DanhSachChonNhom(CPUID)
        End If
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And v.Store_ID=@Store_ID"
            End If
        Else
            sql += " AND v.Store_ID in " & DanhSachChonKho(CPUID)
        End If
        sql += " Group by ls.s_ID"

        If Not execSQL(sql, p) Then
            Return True
        End If
        Return True
    End Function
    ''' <summary>
    ''' tồn đầu kỳ(bỏ Nhập khác,xuất khác)
    ''' </summary>
    ''' <param name="CPUID"></param>
    ''' <param name="Store_ID"></param>
    ''' <param name="Group_ID"></param>
    ''' <param name="dayMonth"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InstockAt_2(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal dayMonth As Date) As Boolean
        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@dayMonth", dayMonth)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@ID", CPUID)

        Dim sql As String
        If Not execSQL("Delete from [rptInstock] where [ID]=N'" & CPUID.Replace("'", "''") & "'") Then
            Return False
        End If

        sql = "INSERT INTO [rptInstock]([ID],[Product_ID],[QBegin])"
        sql += vbCrLf
        sql += " select @ID,s_ID , 0 from ls_Products where 1=1"
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and s_ProductGroupID=@Group_ID"
            End If
        Else
            sql += " AND s_ProductGroupID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " and s_ID not in ("
        sql += " Select distinct ls.s_ID from ls_Products ls left join V_Thekho v"
        sql += " On ls.s_ID=v.Product_ID and Datediff(day,v.dayMonth,@dayMonth)>=0 "
        sql += " where 1=1 "
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and ls.s_ProductGroupID=@Group_ID"
            End If
        Else
            sql += " AND ls.s_ProductGroupID in " & DanhSachChonNhom(CPUID)
        End If
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And v.Store_ID=@Store_ID"
            End If
        Else
            sql += " AND v.Store_ID in " & DanhSachChonKho(CPUID)
        End If
        sql += " and v.manghiepvu not in ('NK','XK')"
        sql += ")"
        sql += vbCrLf
        sql += " union all "
        sql += vbCrLf
        sql += " Select @ID,ls.s_ID, isnull(sum(v.ExChange*(v.QImport-v.QOrder)),0) as Q from ls_Products ls left join V_Thekho v"
        sql += "  On ls.s_ID=v.Product_ID and Datediff(day,v.dayMonth,@dayMonth)>=0 "
        sql += " where 1=1"
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and ls.s_ProductGroupID=@Group_ID"
            End If
        Else
            sql += " AND ls.s_ProductGroupID in " & DanhSachChonNhom(CPUID)
        End If
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And v.Store_ID=@Store_ID"
            End If
        Else
            sql += " AND v.Store_ID in " & DanhSachChonKho(CPUID)
        End If
        sql += " and v.manghiepvu not in ('NK','XK')"
        sql += " Group by ls.s_ID "
        If Not execSQL(sql, p) Then
            Return True
        End If
        Return True
    End Function

    Public Function rptInstock(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal dayMonth As Date, ByVal Unit As Integer) As DataTable
        If Not InstockAt(CPUID, Store_ID, Group_ID, dayMonth) Then
            Return Nothing
        End If
        Dim sql As String
        Dim sTableUnit As String = getTableNameUnit(Unit)
        sql = "Delete from rptInstock where QBegin=0 and [ID]=N'" & CPUID.Replace("'", "''") & "'"
        sql += vbCrLf
        sql += " Select t.Product_ID as Product_Key, ls.Product_ID,ls.Product_Name,ls.Unit,ls.Exchange, t.QBegin/ls.Exchange as QBegin "
        sql += " from rptInstock t Join [" & sTableUnit & "] ls "
        sql += " On t.Product_ID=ls.Product_Key where t.QBegin>0 and t.[ID] = N'" & CPUID.Replace("'", "''") & "' Order by ls.Product_Name asc"

        Dim tb As DataTable = getTableSQL(sql)
        Return tb
    End Function

    Public Function prtCheckStore(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal dayMonth As Date, ByVal Unit As Integer) As DataTable
        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@dayMonth", dayMonth)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@ID", CPUID)

        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)
        If Store_ID <> "" Then
            Dim tbInstock As DataTable = Me.rptInstock(CPUID, Store_ID, "", dayMonth, Unit)
           
            sql = "Delete from rptCheckStore Where ID=@ID"
            sql += vbCrLf
            sql += " Insert into rptCheckStore(ID, Product_Key, Product_ID, Product_Name, Unit, Exchange, Qty, Instock)"
            sql += vbCrLf
            sql += "Select @ID, ls.Product_Key, ls.Product_ID,ls.Product_Name,ls.Unit,ls.Exchange,pr.f_Qty/ls.Exchange as Qty, t.QBegin / ls.Exchange as QBegin" 'them /ls.Exchange
            sql += " from Ls_CheckStore v,PR_CheckStore pr,[" & sTableUnit & "] ls, rptInstock t"
            sql += "  where pr.f_Qty>0 and v.s_ID=pr.s_IDCheck and pr.s_Product_ID=ls.Product_Key and "
            sql += " ls.Product_Key=t.Product_ID and Datediff(day,v.dt_DayMonth,@dayMonth)=0 "
            sql += "  and v.s_Store_ID=@Store_ID and t.ID=@ID"
            If Not IsGroupOption Then
                If Group_ID <> "" Then
                    sql += " and Group_ID=@Group_ID"
                End If
            Else
                sql += " AND Group_ID in " & DanhSachChonNhom(CPUID)
            End If
            sql += " Order by ls.Product_Name"

            sql += " Select Product_ID, Product_Name, Unit, Exchange, Instock, Qty From rptCheckStore Where ID=@ID"
        Else
            sql = "Select @ID, ls.Product_Key, ls.Product_ID,ls.Product_Name,ls.Unit,ls.Exchange,sum(pr.f_Qty/ls.Exchange) as Qty "
            sql += " from Ls_CheckStore v,PR_CheckStore pr,[" & sTableUnit & "] ls"
            sql += "  where v.s_ID=pr.s_IDCheck and pr.s_Product_ID=ls.Product_Key and Datediff(day,v.dt_DayMonth,@dayMonth)=0 "
            If Not IsGroupOption Then
                If Group_ID <> "" Then
                    sql += " and Group_ID=@s_ProductGroupID"
                End If
            Else
                sql += " AND Group_ID in " & DanhSachChonNhom(CPUID)
            End If
            sql += " Group by ls.Product_ID,ls.Product_Name,ls.Unit,ls.Exchange having sum(pr.f_Qty/ls.Exchange)>0 "
            sql += " Order by ls.Product_Name"
        End If

        Dim tb As DataTable = Me.getTableSQL(sql, p)
        Return tb
    End Function

#Region "BÁO CÁO KHO HÀNG"
    'CHI TIẾT HÀNG XUẤT
    Public Function rptDetailOrder(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin chi tiết hàng xuất, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)

        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, "
        sql += " Unit, Exchange, Price, Qty, s_Order_ID, dt_OrderDate, f_Discount, m_Discount, Total)"
        sql += vbCrLf
        sql += " Select @ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += " v.Unit, v.Exchange, v.Exchange*dt.m_Price/dt.f_Convert as Price, "
        sql += " dt.f_Quantity*dt.f_Convert/v.Exchange as Qty, o.s_Order_ID, o.dt_OrderDate, dt.f_Discount,"
        sql += " dt.m_Discount, (dt.m_Price-dt.m_Discount)*dt.f_Quantity*(1-dt.f_Discount/100) as Total"
        sql += " from v_fullorderDetails dt, v_fullorder o, [" & sTableUnit & "] v, ls_Stores ls"
        sql += " where dt.s_OrderID=o.s_ID and v.Product_key=dt.s_Product_ID and dt.s_Store_ID=ls.s_ID"
        sql += " and " & getQueryDate(fromDate, toDate, "o.dt_OrderDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet
        Dim tbData As DataTable = getTableSQL(sql, p)

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += CDbl(dt("Total"))
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If

        Return ds
    End Function

    'TỔNG HỢP HÀNG XUẤT
    Public Function rptTotalOrder(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin tổng hợp hàng xuất, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)
        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID], "
        If Store_ID <> "" AndAlso Store_ID <> "-1" Then
            sql += " Store_Name, s_Store_ID,"
        End If
        sql += " Group_ID, Product_ID, Product_Name,Unit, Exchange, Qty, Total)"
        sql += vbCrLf
        sql += " Select @ID, "
        If Store_ID <> "" AndAlso Store_ID <> "-1" Then
            sql += " ls.s_Name as Store_Name, ls.s_Store_ID,"
        End If
        sql += " v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += " v.Unit, v.Exchange, Sum(dt.f_Quantity*dt.f_Convert/v.Exchange) as Qty ,"
        sql += " Sum((dt.m_Price-dt.m_Discount)*dt.f_Quantity*(1-dt.f_Discount/100)) as Total"
        sql += " from v_fullorderDetails dt,v_fullorder o,[" & sTableUnit & "] v ,ls_Stores ls"
        sql += " where dt.s_OrderID=o.s_ID and v.Product_key=dt.s_Product_ID and dt.s_Store_ID=ls.s_ID"
        sql += " and " & getQueryDate(fromDate, toDate, "o.dt_OrderDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Group by "
        If Store_ID <> "" AndAlso Store_ID <> "-1" Then
            sql += " ls.s_Name,ls.s_Store_ID,"
        End If
        sql += " v.Group_ID, v.Product_ID,v.Product_Name,v.Unit, v.Exchange"
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet

        Dim tbData As DataTable = getTableSQL(sql, p)
        If tbData Is Nothing Then
            Return Nothing
        End If

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If


        Return ds
    End Function
    '5.6.09-CHI TIẾT HÀNG NHẬP
    Public Function rptDetailImport(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin chi tiết hàng nhập, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)

        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, "
        sql += "Unit, Exchange, Price, Qty, s_Order_ID, dt_OrderDate, f_Discount, m_Discount, Total)"
        sql += vbCrLf
        sql += " Select @ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += "v.Unit, v.Exchange, v.Exchange*dt.m_Price/dt.f_Convert as Price,dt.f_Quantity*dt.f_Convert/v.Exchange as Qty ,"
        sql += "o.s_Import_ID,o.dt_ImportDate,dt.f_Discount,dt.m_Discount,"
        sql += "((dt.m_Price-dt.m_Discount)*dt.f_Quantity*(1-dt.f_Discount/100) ) as Total"
        sql += " from v_importdetails dt, v_Imports o, [" & sTableUnit & "] v , ls_Stores ls"
        sql += " where dt.s_Import_ID=o.s_ID and v.Product_key=dt.s_Product_ID and dt.s_Store_ID=ls.s_ID"
        sql += " and " & getQueryDate(fromDate, toDate, "o.dt_ImportDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet
        Dim tbData As DataTable = getTableSQL(sql, p)
        
        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If

        Return ds
    End Function
    '5.6.09-TỔNG HỢP HÀNG NHẬP
    Public Function rptTotalImport(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin tổng hợp hàng nhập, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)
        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name,Unit,  Exchange, Qty, Total)"
        sql += vbCrLf
        sql += " Select @ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += " v.Unit, v.Exchange, Sum(dt.f_Quantity*dt.f_Convert/v.Exchange) as Qty ,"
        sql += " Sum((dt.m_Price-dt.m_Discount)*dt.f_Quantity*(1-dt.f_Discount/100)) as Total"
        sql += " from v_importdetails dt, v_Imports o, [" & sTableUnit & "] v, ls_Stores ls"
        sql += " where dt.s_Import_ID=o.s_ID and v.Product_key=dt.s_Product_ID and dt.s_Store_ID=ls.s_ID"
        sql += " and " & getQueryDate(fromDate, toDate, "o.dt_ImportDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Group by ls.s_Name,ls.s_Store_ID,v.Group_ID, v.Product_ID,v.Product_Name,v.Unit, v.Exchange"
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet

        Dim tbData As DataTable = getTableSQL(sql, p)
        If tbData Is Nothing Then
            Return Nothing
        End If

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += CDbl(dt("Total"))
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If

        Return ds
    End Function
    '8.6.09-CHI TIẾT HÀNG XUẤT LUÂN CHUYỂN KHO
    Public Function rptDetailOrderChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin chi tiết hàng xuất luân chuyển, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)

        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, "
        sql += "Unit, Exchange, Price, Qty, s_Order_ID, dt_OrderDate, f_Discount, m_Discount, Total, Store_Des, Store_DesID)"
        sql += vbCrLf
        sql += " Select @ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += "v.Unit, v.Exchange, v.Exchange*dt.m_Price/dt.f_Exchange as Price, "
        sql += "dt.f_Quantity*dt.f_Exchange/v.Exchange as Qty ,"
        sql += "o.s_NumberID,o.dt_DayMonth, 0, 0, (dt.m_Price*dt.f_Quantity) as Total, "
        sql += "ls2.s_Name as Store_Des, ls2.s_Store_ID as Store_DesID"
        sql += " from v_trandetail dt, v_trans o, [" & sTableUnit & "] v, ls_Stores ls, ls_Stores ls2"
        sql += " where dt.s_NumberID=o.s_ID and v.Product_key=dt.s_Product_ID and o.s_StoreSource=ls.s_ID and "
        sql += " o.s_StoreDes=ls2.s_ID and " & getQueryDate(fromDate, toDate, "o.dt_DayMonth")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " and o.s_StoreSource=@Store_ID"
            End If
        Else
            sql += " AND o.s_StoreSource in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet
        Dim tbData As DataTable = getTableSQL(sql, p)

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If


        Return ds
    End Function
    '8.6.09-TỔNG HỢP HÀNG XUẤT LUÂN CHUYỂN
    Public Function rptTotalOrderChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin tổng hợp hàng xuất luân chuyển, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)
        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, "
        sql += "Unit, Exchange, Qty, Total, Store_Des, Store_DesID)"
        sql += vbCrLf
        sql += " Select @ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += "v.Unit, v.Exchange, Sum(dt.f_Quantity*dt.f_Exchange/v.Exchange) as Qty ,"
        sql += "Sum(dt.m_Price*dt.f_Quantity) as Total, ls2.s_Name as Store_Des, ls2.s_Store_ID as Store_DesID"
        sql += " from v_trandetail dt, v_trans o, [" & sTableUnit & "] v, ls_Stores ls, ls_Stores ls2"
        sql += " where dt.s_NumberID=o.s_ID and v.Product_key=dt.s_Product_ID and o.s_StoreSource=ls.s_ID"
        sql += " and o.s_StoreDes=ls2.s_ID and " & getQueryDate(fromDate, toDate, "o.dt_DayMonth")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " and o.s_StoreSource=@Store_ID"
            End If
        Else
            sql += " AND o.s_StoreSource in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Group by ls.s_Name,ls.s_Store_ID,v.Group_ID, v.Product_ID,v.Product_Name,v.Unit, ls2.s_Name,ls2.s_Store_ID, v.Exchange"
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet

        Dim tbData As DataTable = getTableSQL(sql, p)
        If tbData Is Nothing Then
            Return Nothing
        End If

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If

        Return ds
    End Function
    '8.6.09-CHI TIẾT HÀNG NHẬP LUÂN CHUYỂN KHO
    Public Function rptDetailImportChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin chi tiết hàng xuất luân chuyển, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)

        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, "
        sql += "Unit, Price, Qty, s_Order_ID, dt_OrderDate, f_Discount, m_Discount, Total, Store_Des, Store_DesID)"
        sql += vbCrLf
        sql += " Select @ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += "v.Unit, v.Exchange*dt.m_Price/dt.f_Exchange as Price, "
        sql += "dt.f_Quantity*dt.f_Exchange/v.Exchange as Qty ,"
        sql += "o.s_NumberID,o.dt_DayMonth, 0, 0, (dt.m_Price*dt.f_Quantity) as Total, "
        sql += "ls2.s_Name as Store_Des, ls2.s_Store_ID as Store_DesID"
        sql += " from v_trandetail dt, v_trans o, [" & sTableUnit & "] v, ls_Stores ls, ls_Stores ls2"
        sql += " where dt.s_NumberID=o.s_ID and v.Product_key=dt.s_Product_ID and o.s_StoreSource=ls.s_ID and "
        sql += " o.s_StoreDes=ls2.s_ID and " & getQueryDate(fromDate, toDate, "o.dt_DayMonth")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " and o.s_StoreDes=@Store_ID"
            End If
        Else
            sql += " AND o.s_StoreDes in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet
        Dim tbData As DataTable = getTableSQL(sql, p)

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If

        Return ds
    End Function
    '8.6.09-TỔNG HỢP HÀNG NHẬP LUÂN CHUYỂN
    Public Function rptTotalImportChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin tổng hợp hàng xuất luân chuyển, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)
        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, Unit, "
        sql += "Qty, Total, Store_Des, Store_DesID)"
        sql += vbCrLf
        sql += " Select @ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, v.Unit, "
        sql += "Sum(dt.f_Quantity*dt.f_Exchange/v.Exchange) as Qty ,"
        sql += "Sum(dt.m_Price*dt.f_Quantity) as Total, ls2.s_Name as Store_Des, ls2.s_Store_ID as Store_DesID"
        sql += " from v_trandetail dt, v_trans o, [" & sTableUnit & "] v, ls_Stores ls, ls_Stores ls2"
        sql += " where dt.s_NumberID=o.s_ID and v.Product_key=dt.s_Product_ID and o.s_StoreSource=ls.s_ID"
        sql += " and o.s_StoreDes=ls2.s_ID and " & getQueryDate(fromDate, toDate, "o.dt_DayMonth")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " and o.s_StoreDes=@Store_ID"
            End If
        Else
            sql += " AND o.s_StoreDes in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Group by ls.s_Name,ls.s_Store_ID,v.Group_ID, v.Product_ID,v.Product_Name,v.Unit, ls2.s_Name,ls2.s_Store_ID"
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet

        Dim tbData As DataTable = getTableSQL(sql, p)
        If tbData Is Nothing Then
            Return Nothing
        End If

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If


        Return ds
    End Function
    '8.6.09-CHI TIẾT HÀNG NHẬP trả
    Public Function rptDetailImportReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin chi tiết hàng nhập trả, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)

        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, Unit, "
        sql += "Price, Qty, s_Order_ID, dt_OrderDate, f_Discount, m_Discount, Total,Exchange )" '08/01/10 them Exchange
        sql += vbCrLf
        sql += " Select  @ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name,"
        sql += " v.Unit, v.Exchange*dt.m_PriceImport/dt.f_Convert as Price,dt.f_Quantity*dt.f_Convert/v.Exchange as Qty ,"
        sql += " o.s_Import_ID,o.dt_ImportDate,0,0, ((dt.m_PriceImport-dt.m_Discount)*dt.f_Quantity*(1-dt.f_Discount/100) ) as Total,v.Exchange " '08/01/10 them v.Exchange
        sql += " from pr_importdetailreturn dt, Ls_ImportReturns o, [" & sTableUnit & "] v , ls_Stores ls " '[V_DefaultUnitImport] v thay bang [" & sTableUnit & "] v
        sql += " where dt.s_Import_ID = o.s_ID And v.Product_key = dt.s_Product_ID And dt.s_Store_ID = ls.s_ID"
        sql += " and " & getQueryDate(fromDate, toDate, "o.dt_ImportDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet
        Dim tbData As DataTable = getTableSQL(sql, p)

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If

        Return ds
    End Function
    '8.6.09-TỔNG HỢP HÀNG NHẬP trả
    '16.06.2009 - Thao bo sung truong dt_OverDate=[rptProductOrder].dt_OrderDate
    Public Function rptTotalImportReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin tổng hợp hàng nhập trả, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)
        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder(dt_OrderDate,[ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, "
        sql += " Unit,Qty,Total,Exchange,Price )" '08/01/10 them Exchange ,Price
        sql += vbCrLf
        sql += " Select dt_OverDate,@ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += " v.Unit,Sum(dt.f_Quantity*dt.f_Convert/v.Exchange) as Qty ,"
        sql += " Sum((dt.m_PriceImport-dt.m_Discount)*dt.f_Quantity*(1-dt.f_Discount/100)) as Total,v.Exchange,v.Exchange*dt.m_PriceImport/dt.f_Convert as Price " '08/01/10 them Exchange ,v.Exchange*dt.m_PriceImport/dt.f_Convert as Price
        sql += " from pr_importdetailreturn dt, Ls_ImportReturns o, [" & sTableUnit & "] v, ls_Stores ls"
        sql += " where dt.s_Import_ID=o.s_ID and v.Product_key=dt.s_Product_ID and dt.s_Store_ID=ls.s_ID"
        sql += " and " & getQueryDate(fromDate, toDate, "o.dt_ImportDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Group by dt_OverDate,ls.s_Name,ls.s_Store_ID,v.Group_ID, v.Product_ID,v.Product_Name,v.Unit,v.Exchange,v.Exchange*dt.m_PriceImport/dt.f_Convert "
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet

        Dim tbData As DataTable = getTableSQL(sql, p)
        If tbData Is Nothing Then
            Return Nothing
        End If

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If


        Return ds
    End Function
    'CHI TIẾT HÀNG XUẤT trả
    Public Function rptDetailOrderReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin chi tiết hàng xuất, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)

        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID],Store_Name,s_Store_ID,Group_ID,Product_ID,Product_Name,Unit,Price,Qty,s_Order_ID,dt_OrderDate,f_Discount,m_Discount,Total,Exchange )"
        sql += vbCrLf
        sql += " Select  @ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name,"
        sql += "v.Unit, v.Exchange*dt.m_Price/dt.f_Convert as Price,dt.f_Quantity*dt.f_Convert/v.Exchange as Qty ,"
        sql += "o.s_Order_ID,o.dt_OrderDate,0,0,(dt.m_Price-dt.m_Discount)*dt.f_Quantity*(1-dt.f_Discount/100) as Total ,v.Exchange "
        sql += " from PR_OrderDetailReturns dt, LS_OrderReturns o, [" & sTableUnit & "] v , ls_Stores ls "
        sql += " where dt.s_Order_ID = o.s_ID And v.Product_key = dt.s_Product_ID And dt.s_Store_ID = ls.s_ID"
        sql += " and " & getQueryDate(fromDate, toDate, "o.dt_OrderDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet
        Dim tbData As DataTable = getTableSQL(sql, p)

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If


        Return ds
    End Function
    'TỔNG HỢP HÀNG XUẤT trả
    Public Function rptTotalOrderReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin tổng hợp hàng xuất, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(4) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)
        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID],Store_Name,s_Store_ID,Group_ID,Product_ID,Product_Name,Unit,Qty,Total,Exchange,Price )"
        sql += vbCrLf
        sql += " Select @ID, ls.s_Name as Store_Name,ls.s_Store_ID,v.Group_ID, v.Product_ID,v.Product_Name,v.Unit,Sum(dt.f_Quantity*dt.f_Convert/v.Exchange) as Qty ,"
        sql += " Sum((dt.m_Price-dt.m_Discount)*dt.f_Quantity*(1-dt.f_Discount/100)) as Total,v.Exchange,v.Exchange*dt.m_Price/dt.f_Convert as Price " '08/01/10 them v.Exchange
        sql += " from PR_OrderDetailReturns dt,LS_OrderReturns o,[" & sTableUnit & "] v ,ls_Stores ls"
        sql += " where dt.s_Order_ID=o.s_ID and v.Product_key=dt.s_Product_ID and dt.s_Store_ID=ls.s_ID"
        sql += " and " & getQueryDate(fromDate, toDate, "o.dt_OrderDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        sql += " Group by ls.s_Name,ls.s_Store_ID,v.Group_ID, v.Product_ID,v.Product_Name,v.Unit,v.Exchange,v.Exchange*dt.m_Price/dt.f_Convert "
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet

        Dim tbData As DataTable = getTableSQL(sql, p)
        If tbData Is Nothing Then
            Return Nothing
        End If

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If

        Return ds
    End Function
    'Xuat khac
    Public Function rptDetailOrderOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_PayMent As String) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin chi tiết hàng xuất, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(5) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)
        p(5) = New SqlParameter("@s_PayMent", s_PayMent)
        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder(s_ItemID,s_ItemName,[ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, "
        sql += " Unit, Exchange, Price, Qty, s_Order_ID, dt_OrderDate, f_Discount, m_Discount, Total)"
        sql += vbCrLf
        sql += " Select p.IDKH_s,p.s_Name,@ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += "v.Unit, v.Exchange, v.Exchange*dt.m_Price/dt.f_Convert as Price, "
        sql += "dt.f_Quantity*dt.f_Convert/v.Exchange as Qty, o.s_Order_ID, o.dt_OrderDate, dt.f_Discount,"
        sql += "dt.m_Discount, (dt.m_Price*dt.f_Quantity*(1-dt.f_Discount/100) -dt.m_Discount) as Total"
        sql += " from PR_OrderDetail_Other dt Join ls_Order_Other o On dt.s_OrderID=o.s_ID "
        sql += " Join [" & sTableUnit & "] v ON v.Product_key=dt.s_Product_ID Join ls_Stores ls On dt.s_Store_ID=ls.s_ID "
        sql += " Left join ls_PaymentOrder p On o.i_ItemID =p.i_ID"
        sql += " where " & getQueryDate(fromDate, toDate, "o.dt_OrderDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        If s_PayMent <> "" Then
            sql += " and p.i_ID=@s_PayMent"
        End If

        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet
        Dim tbData As DataTable = getTableSQL(sql, p)

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If


        Return ds
    End Function
    Public Function rptTotalOrderOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_PayMent As String) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin tổng hợp hàng xuất, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(5) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)
        p(5) = New SqlParameter("@s_PayMent", s_PayMent)
        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, Unit, Exchange, Qty, Total)"
        sql += " Select @ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += " v.Unit, v.Exchange, Sum(dt.f_Quantity*dt.f_Convert/v.Exchange) as Qty ,"
        sql += " Sum(dt.m_Price*dt.f_Quantity*(1-dt.f_Discount/100) -dt.m_Discount) as Total"
        sql += " from PR_OrderDetail_Other dt Join ls_Order_Other o On dt.s_OrderID=o.s_ID "
        sql += " Join [" & sTableUnit & "] v On v.Product_key=dt.s_Product_ID Join  ls_Stores ls On dt.s_Store_ID=ls.s_ID"
        sql += " Left join ls_PaymentOrder p On o.i_ItemID =p.i_ID"
        sql += " where  " & getQueryDate(fromDate, toDate, "o.dt_OrderDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        If s_PayMent <> "" Then
            sql += " and p.i_ID=@s_PayMent"
        End If
        sql += " Group by ls.s_Name,ls.s_Store_ID,v.Group_ID, v.Product_ID,v.Product_Name,v.Unit, v.Exchange"
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet

        Dim tbData As DataTable = getTableSQL(sql, p)
        If tbData Is Nothing Then
            Return Nothing
        End If
        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If
        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If


        Return ds
    End Function
    '--Nhap khac
    Public Function rptDetailImportOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_Payment As String) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin chi tiết hàng nhập, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(5) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)
        p(5) = New SqlParameter("@s_PayMent", s_Payment)
        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)

        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder(s_ItemID,s_ItemName,[ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, "
        sql += "Unit, Exchange, Price, Qty, s_Order_ID, dt_OrderDate, f_Discount, m_Discount, Total)"
        sql += vbCrLf
        sql += " Select o.IDKH_s,o.NamePayment,@ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += "v.Unit, v.Exchange, v.Exchange*dt.m_Price/dt.f_Convert as Price,dt.f_Quantity*dt.f_Convert/v.Exchange as Qty ,"
        sql += "o.s_Import_ID,o.dt_ImportDate,dt.f_Discount,dt.m_Discount,"
        sql += "(dt.m_Price*dt.f_Quantity*(1-dt.f_Discount/100) -dt.m_Discount) as Total"
        sql += " from v_ImportDetail_Other dt, V_Import_Other o, [" & sTableUnit & "] v , ls_Stores ls"
        sql += " where dt.s_Import_ID=o.s_ID and v.Product_key=dt.s_Product_ID and dt.s_Store_ID=ls.s_ID"
        sql += " and " & getQueryDate(fromDate, toDate, "o.dt_ImportDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        If s_Payment <> "" Then
            sql += " and o.i_Item_ID=@s_PayMent"
        End If
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet
        Dim tbData As DataTable = getTableSQL(sql, p)

        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If


        Return ds
    End Function

    Public Function rptTotalImportOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_Payment As String) As DataSet
        '-----Chú thích-----
        '-----rptProductOrder: bảng tạm chức thông tin tổng hợp hàng nhập, lưu theo CPUID
        '-----Các bước thực hiện: Delete; Insert; Select

        Dim p(5) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@Group_ID", Group_ID)
        p(3) = New SqlParameter("@toDate", toDate)
        p(4) = New SqlParameter("@ID", CPUID)
        p(5) = New SqlParameter("@s_PayMent", s_Payment)
        Dim sql As String = ""
        Dim sTableUnit As String = getTableNameUnit(Unit)
        '
        sql = "Delete from rptProductOrder where [ID]=@ID"
        sql += vbCrLf
        sql += " Insert into rptProductOrder([ID], Store_Name, s_Store_ID, Group_ID, Product_ID, Product_Name, "
        sql += "Unit,  Exchange, Qty, Total)"
        sql += vbCrLf
        sql += " Select @ID, ls.s_Name as Store_Name, ls.s_Store_ID, v.Group_ID, v.Product_ID, v.Product_Name, "
        sql += "v.Unit, v.Exchange, Sum(dt.f_Quantity*dt.f_Convert/v.Exchange) as Qty ,"
        sql += "Sum(dt.m_Price*dt.f_Quantity*(1-dt.f_Discount/100) -dt.m_Discount) as Total"
        sql += " from v_ImportDetail_Other dt, V_Import_Other o, [" & sTableUnit & "] v, ls_Stores ls"
        sql += " where dt.s_Import_ID=o.s_ID and v.Product_key=dt.s_Product_ID and dt.s_Store_ID=ls.s_ID"
        sql += " and " & getQueryDate(fromDate, toDate, "o.dt_ImportDate")
        If Not IsStoreSelectOption Then
            If Store_ID <> "" Then
                sql += " And dt.s_Store_ID=@Store_ID"
            End If
        Else
            sql += " AND dt.s_Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" Then
                sql += " and v.Group_ID=@Group_ID"
            End If
        Else
            sql += " AND v.Group_ID in " & DanhSachChonNhom(CPUID)
        End If
        If s_Payment <> "" Then
            sql += " and o.i_Item_ID=@s_PayMent"
        End If
        sql += " Group by ls.s_Name,ls.s_Store_ID,v.Group_ID, v.Product_ID,v.Product_Name,v.Unit, v.Exchange"
        sql += " Order by v.Product_Name"
        sql += vbCrLf
        sql += " Select * from rptProductOrder where [ID]=@ID"

        Dim ds As New DataSet

        Dim tbData As DataTable = getTableSQL(sql, p)
        If tbData Is Nothing Then
            Return Nothing
        End If
        If Group_ID <> "" Then
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups where s_ID=@Group_ID Order by s_Name"
        Else
            sql = "Select s_ID,s_Name,s_ProductGroup_ID,cast(0 as money) as Total from ls_ProductGroups  Order by s_Name"
        End If

        Dim tbGroup As DataTable = getTableSQL(sql, New SqlParameter("@Group_ID", Group_ID))
        If Not IsNothing(tbGroup) Then
            For Each dr As DataRow In tbGroup.Rows
                Dim DF() As DataRow = tbData.Select("Group_ID='" & dr("s_ID").ToString.Replace("'", "''") & "'")
                If DF.Length = 0 Then
                    dr.Delete()
                Else
                    For Each dt As DataRow In DF
                        dr("Total") += dt("Total")
                    Next
                End If
            Next
            ds.Tables.Add(tbGroup.Copy)
            ds.Tables.Add(tbData.Copy)
            ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("Group_ID"))
        End If


        Return ds
    End Function

    Public Function rptInstallTotal(ByVal dtFrom As Date, ByVal dtTo As Date) As DataSet
        Dim ds As New DataSet
        Dim sql As String = "select pr.*,p.s_Product_ID as EndProID,p.s_Name as EndProName,s.s_name as StoreName "
        sql += " from PR_ImportDetail_EndProduct pr left join ls_Products p on pr.s_Product_ID=p.s_ID "
        sql += " left join ls_stores s on pr.s_Store_ID=s.s_ID "
        sql += " where s_Number_ID in (select s_ID from Ls_Import_EndProduct where DateDiff(day,dt_DayMonth,@dtFrom)<=0 and DateDiff(day,dt_DayMonth,@dtTo)>=0)"

        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@dtFrom", dtFrom)
        p(1) = New SqlParameter("@dtTo", dtTo)
        Dim tbEndPro As DataTable = Me.getTableSQL(sql, p)
        tbEndPro.TableName = "EndProduct"
        ds.Tables.Add(tbEndPro.Copy)

        sql = "select pr.*,pr.Product_ID as s_Product_ID,p.s_Product_ID as MaterialID,p.s_Name as MaterialName,s.s_name as StoreName "
        sql += " from PR_DetailMaterials pr left join Ls_Products p on pr.Product_ID=p.s_ID "
        sql += " left join ls_stores s on pr.s_Store_ID=s.s_ID "
        sql += "where ImportDetail_ID in(select s_ID from PR_ImportDetail_EndProduct where s_Number_ID in "
        sql += "(select s_ID from Ls_Import_EndProduct where DateDiff(day,dt_DayMonth,@dtFrom)<=0 and DateDiff(day,dt_DayMonth,@dtTo)>=0))"

        p(0) = New SqlParameter("@dtFrom", dtFrom)
        p(1) = New SqlParameter("@dtTo", dtTo)
        Dim tbMaterial As DataTable = Me.getTableSQL(sql, p)
        tbMaterial.TableName = "Materials"
        ds.Tables.Add(tbMaterial.Copy)

        ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("ImportDetail_ID"))
        Return ds
    End Function
    Public Function rptUnInstallTotal(ByVal dtFrom As Date, ByVal dtTo As Date) As DataSet
        Dim ds As New DataSet
        Dim sql As String = "select pr.*,p.s_Product_ID as EndProID,p.s_Name as EndProName,s.s_name as StoreName "
        sql += " from Pr_ExportDetail_EndProduct pr left join ls_Products p on pr.s_Product_ID=p.s_ID "
        sql += " left join ls_stores s on pr.s_Store_ID=s.s_ID "
        sql += " where s_Number_ID in(select s_ID from Ls_Export_EndProduct where DateDiff(day,dt_DayMonth,@dtFrom)<=0 and DateDiff(day,dt_DayMonth,@dtTo)>=0) "

        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@dtFrom", dtFrom)
        p(1) = New SqlParameter("@dtTo", dtTo)
        Dim tbEndPro As DataTable = Me.getTableSQL(sql, p)
        tbEndPro.TableName = "EndProduct"
        ds.Tables.Add(tbEndPro.Copy)

        sql = "select pr.*,pr.Product_ID as s_Product_ID,p.s_Product_ID as MaterialID,p.s_Name as MaterialName,s.s_name as StoreName "
        sql += " from Pr_ExportDetail_Materials pr left join Ls_Products p on pr.Product_ID=p.s_ID "
        sql += " left join ls_stores s on pr.s_Store_ID=s.s_ID "
        sql += "where ExportDetail_ID in(select s_ID from Pr_ExportDetail_EndProduct where s_Number_ID in"
        sql += " (select s_ID from Ls_Export_EndProduct where DateDiff(day,dt_DayMonth,@dtFrom)<=0 and DateDiff(day,dt_DayMonth,@dtTo)>=0))"

        p(0) = New SqlParameter("@dtFrom", dtFrom)
        p(1) = New SqlParameter("@dtTo", dtTo)
        Dim tbMaterial As DataTable = Me.getTableSQL(sql, p)
        tbMaterial.TableName = "Materials"
        ds.Tables.Add(tbMaterial.Copy)

        ds.Relations.Add("Ref", ds.Tables(0).Columns("s_ID"), ds.Tables(1).Columns("ExportDetail_ID"))
        Return ds
    End Function

    'nhung mat hang kh co phat sinh xuat
    Public Function rptStockAgingReport(ByVal CPUID As String, ByVal Store_ID As String, ByVal Branch_ID As String, ByVal Group_ID As String, _
                                         ByVal ProductID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataTable

        Dim sql As String
        Dim p(6) As SqlParameter
        p(0) = New SqlParameter("@ID", CPUID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@toDate", toDate)
        p(3) = New SqlParameter("@storeID", Store_ID)
        p(4) = New SqlParameter("@BranchID", Branch_ID)
        p(5) = New SqlParameter("@GroupID", Group_ID)
        p(6) = New SqlParameter("@ProductID", ProductID)

        sql = "Delete from rptListProduct where [ID]=@ID"
        sql += vbCrLf
        sql += " Delete from rptInstock where [ID]=@ID"
        sql += vbCrLf
        'nhung mat hang phat sinh xuat trong khoang thoi gian xem bao cao
        sql += " Insert into rptListProduct([ID],Product_ID)"
        sql += vbCrLf
        sql += " Select Distinct @ID,v.Product_ID"
        sql += " from v_Thekho v,ls_Products p"
        sql += " where QOrder <>0 and " & getQueryDate(fromDate, toDate, "v.DayMonth")
        
        If Not IsStoreSelectOption Then
            If Store_ID <> "" AndAlso Store_ID <> "-1" Then
                sql += " and v.Store_ID=@storeID"
            End If
        Else
            sql += " AND v.Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If ProductID <> "" AndAlso ProductID <> "-1" Then
            sql += " v.product_ID=@ProductID"
        Else
            If Not IsGroupOption Then
                If Group_ID <> "" AndAlso Group_ID <> "-1" Then
                    sql += " and p.s_ProductGroupID=@GroupID"
                End If
            Else
                sql += " AND p.s_ProductGroupID in " & DanhSachChonNhom(CPUID)
            End If
        End If
        If Not execSQL(sql, p) Then
            Return Nothing
        End If

        'tinh so luong ton tat cac cac mat hang  den ngay xem bao cao
        sql = "INSERT INTO [rptInstock]([ID],[Product_ID],[QBegin])" & vbCrLf
        sql += " Select @ID,v.Product_ID,isnull(sum(v.Exchange*(v.QImport-v.QOrder)),0) as Instock "
        sql += " from v_thekho v ,ls_Products p"
        sql += " where v.Product_ID=p.s_ID and Datediff(day,v.dayMonth,@toDate)>=0 "

        If Not IsStoreSelectOption Then
            If Store_ID <> "" AndAlso Store_ID <> "-1" Then
                sql += " and v.Store_ID=@Store_ID"
            End If
        Else
            sql += " AND v.Store_ID in " & DanhSachChonKho(CPUID)
        End If
        If Not IsGroupOption Then
            If Group_ID <> "" AndAlso Group_ID <> "-1" Then
                sql += " and p.s_ProductGroupID=@GroupID"
            End If
        Else
            sql += " AND p.s_ProductGroupID in " & DanhSachChonNhom(CPUID)
        End If
        If Not execSQL(sql, p) Then
            Return Nothing
        End If
        sql += " and v.Product_ID not in ( select Product_ID from rptListProduct where ID=@ID)"
        sql += " Group by v.Product_ID"

        Dim pm(3) As SqlParameter
        pm(0) = New SqlParameter("@ID", CPUID)
        pm(1) = New SqlParameter("@toDate", toDate)
        pm(2) = New SqlParameter("@storeID", Store_ID)
        pm(3) = New SqlParameter("@GroupID", Group_ID)
        If Not execSQL(sql, pm) Then
            Return Nothing
        End If

        Dim sTableUnit As String = getTableNameUnit(Unit)
        sql = "Delete from rptInstock where QBegin=0 and [ID]=N'" & CPUID.Replace("'", "''") & "'"
        sql += vbCrLf
        sql += " Select t.Product_ID as Product_Key, ls.Product_ID,ls.Product_Name,ls.Unit,ls.Exchange, t.QBegin/ls.Exchange as QBegin "
        sql += " from rptInstock t Join [" & sTableUnit & "] ls "
        sql += " On t.Product_ID=ls.Product_Key where t.QBegin>0 and t.[ID] = N'" & CPUID.Replace("'", "''") & "' Order by ls.Product_Name asc"
        Dim tb As DataTable = getTableSQL(sql)
        Return tb
    End Function  

#End Region

    Public Function getListShift() As DataTable
        Return getTableSQL("Select * from ls_shift")
    End Function

    Public Function rptBangKeDoanhThuBanHang(ByVal CPUID As String, ByVal dtDate As Date, ByVal ShiftID As String, ByVal CounterID As String) As DataTable
        Dim sql As String = ""
        sql = "Delete from rptFund where ID=@CPUID" & vbCrLf
        sql += " select s_Col1,c.name as CounterName,s2,s.s_name as ShiftName,sum(isnull(cash,0))as Cash,sum(isnull(Transfer,0))as Transfer,"
        sql += " sum(isnull(ScandCard,0))as ScandCard,sum(isnull(v3,0))as DoiTheGiamGia "
        sql += " from v_fullorder ls left outer join ls_Shift s on ls.s2=s.s_ID "
        sql += " left outer join ls_Counter c  on ls.s_Col1=c.s_ID "
        sql += " where datediff(day,dt_OrderDate,@dtDate)=0 and isnull(s_Col1,'')<>''"

        If ShiftID <> "" Then
            sql += " and s2=@ShiftID"

        End If

        If CounterID <> "" Then
            sql += " and s_Col1=@CounterID"
        End If

        sql += " group by s_Col1,c.name,s2,s.s_name "

        Dim p(3) As SqlParameter
        p(0) = New SqlParameter("@dtDate", dtDate)
        p(1) = New SqlParameter("@ShiftID", ShiftID)
        p(2) = New SqlParameter("@CounterID", CounterID)
        p(3) = New SqlParameter("@CPUID", CPUID)

        Dim tb As DataTable = Me.getTableSQL(sql, p)
        If Not IsNothing(tb) AndAlso tb.Rows.Count > 0 Then
            For Each r As DataRow In tb.Rows
                sql = "Insert into rptFund(ID,NumberID,Note,s_Currency,s_Payer,m_Exchange,Income,Outcome,Instock)"
                sql += " values(@CPUID,@s_Col1,@CounterName,@s2,@ShiftName,@Cash,@Transfer,@ScandCard,@DoiTheGiamGia)"
                Dim pp(8) As SqlParameter
                pp(0) = New SqlParameter("@CPUID", CPUID)
                pp(1) = New SqlParameter("@s_Col1", r("s_Col1"))
                pp(2) = New SqlParameter("@CounterName", r("CounterName"))
                pp(3) = New SqlParameter("@s2", r("s2"))
                pp(4) = New SqlParameter("@ShiftName", r("ShiftName"))
                pp(5) = New SqlParameter("@Cash", r("Cash"))
                pp(6) = New SqlParameter("@Transfer", r("Transfer"))
                pp(7) = New SqlParameter("@ScandCard", r("ScandCard"))
                pp(8) = New SqlParameter("@DoiTheGiamGia", r("DoiTheGiamGia"))
                Me.execSQL(sql, pp)
            Next
        End If
        sql = "Select Note as QuayThu,s_Payer as CaLV,m_Exchange as TienMat,Income as ChuyenKhoan,Outcome as CaThe,Instock as DoiTheGiamGia "
        sql += " from rptFund where ID=@CPUID order by NumberID asc "
        Return Me.getTableSQL(sql, New SqlParameter("@CPUID", CPUID))
    End Function
End Class
