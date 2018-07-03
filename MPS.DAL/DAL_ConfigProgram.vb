Imports System.Data.SqlClient
Public Class DAL_ConfigProgram
    Inherits DALSQL

    Public Function CheckUpdate() As Boolean
        Dim sql As String = ""
        Dim str As String = ""

        sql = "s_CompanyName,s_Initials,"
        sql += "s_TaxNo,s_Account,s_Address,s_Phone1,s_Phone2,s_Fax,s_Email,"
        sql += "s_Website,i_FormatCur,i_FormatNum,b_SysDiscountBeforeTax,s_SysCur,"
        sql += "b_SysCommission,b_isTrackPurchaseOrder,b_CheckInstock,i_ConfigID,"
        sql += "b_ShowLogo,b_ShowName,b_ShowAdd,"
        sql += "b_ShowEmailWeb,"
        sql += "b_isEDiscount,b_isEProgressive,i_CountPrint,"
        sql += "b_ApplyPrice,b_PriceObject,b_Method,b_EmployLogin,b_PriceLevel_Order,"
        sql += "im_Logo,s_MethodHH,s_MethodCL,s_MethodTU,s_MethodImport,s_MethodOrder,b_Purchase,"
        sql += "isSendHQ,URLHQ,StoreID,i_ShowForm,i_Prepayment,i_QtyPrint,s_Item,b_ChooseTypePrint,i_NumColExchange,s_MethodExchange,IsView"
        Dim D() As String = sql.Split(",")

        For Each s As String In D
            str = "Select count(*) as c from sysobjects s, syscolumns c where s.id=c.id and s.[name]='tblConfig' and c.[name]='" & s & "'"
            Dim tb As DataTable = getTableSQL(str)
            If Not tb Is Nothing Then
                If tb.Rows(0)("c") = 0 Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Public Function UpdateAlerTimeDownload(ByVal AutoCheckHQ As Boolean, ByVal nMinute As Integer) As Boolean
        Dim sql As String = "Update tblConfig set AutoCheckHQ=@AutoCheckHQ, i_TimeAlertDown=@nMinute"
        Return execSQL(sql, New SqlParameter() {New SqlParameter("@AutoCheckHQ", nMinute), New SqlParameter("@nMinute", nMinute)})
    End Function
    Public Function UPDATEDB(ByVal m As Model.MConfigProgram) As Boolean
        Me.BeginTranstion()

        If Not Me.DELETEDB() Then
            Return False
        End If

        Dim sql As String = ""
        Dim sVal As String = ""

        sql = "Insert into [tblConfig](PortWeight,BaudRate,sokytumahang,kytunhandien,sokytusoluong,Quidoisoluong,SmsContent,DoanhSoQuiDoiDiem,AutoCheckHQ,nRow,VATDefault,IsView,IsPriceVAT,nCharTax,symbolTax,[s_CompanyName], [s_Initials], "
        sql += " [s_TaxNo], [s_Account], [s_Address], [s_Phone1], [s_Phone2], [s_Fax],[s_Email], "
        sql += "  [s_Website], [i_FormatCur], [i_FormatNum], [b_SysDiscountBeforeTax],[s_SysCur],"
        sql += "  [b_SysCommission], [b_isTrackPurchaseOrder], [b_CheckInstock],[i_ConfigID],"
        sql += "  [b_ShowLogo], [b_ShowName],[b_ShowAdd], "
        sql += "  [b_ShowPhoneFax],[b_ShowEmailWeb],"
        sql += "  [b_isEDiscount],[b_isEProgressive],[i_CountPrint], "
        sql += "  [b_ApplyPrice],[b_PriceObject],[b_Method],[b_EmployLogin],[b_PriceLevel_Order],[b_Purchase],  "
        sql += "  [isSendHQ],[URLHQ],[StoreID],[b_PriceObGroup], [b_isMultiStore], [b_isCheckBeforeTurnOut],[i_ShowForm],[i_Prepayment],[i_TimeAlertDown],"
        sql += " i_QtyPrint,s_Item,b_ChooseTypePrint,i_NumColExchange,s_MethodExchange"

        sVal = " values(@PortWeight,@BaudRate,@sokytumahang,@kytunhandien,@sokytusoluong,@Quidoisoluong,@SmsContent,@DoanhSoQuiDoiDiem,@AutoCheckHQ,@nRow,@VATDefault,@IsView,@IsPriceVAT,@nCharTax,@symbolTax,@s_CompanyName, @s_Initials, @s_TaxNo, @s_Account, "
        sVal += " @s_Address, @s_Phone1, @s_Phone2, @s_Fax, @s_Email, @s_Website, @i_FormatCur, "
        sVal += " @i_FormatNum, @b_SysDiscountBeforeTax, @s_SysCur, @b_SysCommission, "
        sVal += " @b_isTrackPurchaseOrder, @b_CheckInstock, @i_ConfigID,"
        sVal += " @b_ShowLogo, @b_ShowName, @b_ShowAdd, @b_ShowPhoneFax,@b_ShowEmailWeb,"
        sVal += " @b_isEDiscount,@b_isEProgressive ,@i_CountPrint, "
        sVal += " @b_ApplyPrice,@b_PriceObject,@b_Method,@b_EmployLogin,@b_PriceLevel_Order,@b_Purchase, "
        sVal += " @isSendHQ,@URLHQ,@StoreID,@b_PriceObGroup, @b_isMultiStore, @b_isCheckBeforeTurnOut,@i_ShowForm,@i_Prepayment,@i_TimeAlertDown,"
        sVal += " @i_QtyPrint,@s_Item,@b_ChooseTypePrint,@i_NumColExchange,@s_MethodExchange"

        Dim p(69) As SqlParameter
        If Not m.im_Logo Is Nothing Then
            sql += ", [im_Logo]"
            sVal += ", @im_Logo"
            p(2) = New SqlParameter("@im_Logo", m.im_Logo)
        End If

        If m.s_MethodHH <> "" Then
            sql += ", [s_MethodHH]"
            sVal += ", @s_MethodHH"
            p(24) = New SqlParameter("@s_MethodHH", m.s_MethodHH)
        End If

        If m.s_MethodCL <> "" Then
            sql += ", [s_MethodCL]"
            sVal += ", @s_MethodCL"
            p(25) = New SqlParameter("@s_MethodCL", m.s_MethodCL)
        End If

        If m.s_MethodTU <> "" Then
            sql += ", [s_MethodTU]"
            sVal += ", @s_MethodTU"
            p(26) = New SqlParameter("@s_MethodTU", m.s_MethodTU)
        End If

        If m.s_MethodImport <> "" Then
            sql += ", [s_MethodImport]"
            sVal += ", @s_MethodImport"
            p(27) = New SqlParameter("@s_MethodImport", m.s_MethodImport)
        End If

        If m.s_MethodOrder <> "" Then
            sql += ", [s_MethodOrder]"
            sVal += ", @s_MethodOrder"
            p(28) = New SqlParameter("@s_MethodOrder", m.s_MethodOrder)
        End If

        If m.s_TransCurrOut <> "" Then
            sql += ", [s_TransCurrOut]"
            sVal += ", @s_TransCurrOut"
            p(38) = New SqlParameter("@s_TransCurrOut", m.s_TransCurrOut)
        End If

        If m.s_TransCurrInc <> "" Then
            sql += ", [s_TransCurrInc]"
            sVal += ", @s_TransCurrInc"
            p(39) = New SqlParameter("@s_TransCurrInc", m.s_TransCurrInc)
        End If

        If m.s_ThuTamUng <> "" Then
            sql += ", [s_ThuTamUng]"
            sVal += ", @s_ThuTamUng"
            p(43) = New SqlParameter("@s_ThuTamUng", m.s_ThuTamUng)
        End If

        sql = sql & ")" & sVal & ")"
        sql += vbCrLf
        sql += " Update Ls_Currency set b_isSys=0"
        sql += vbCrLf
        sql += " Update Ls_Currency set b_isSys=1 where IDKH_s=@s_SysCur"

        p(0) = New SqlParameter("@s_CompanyName", m.s_CompanyName)
        p(1) = New SqlParameter("@s_Initials", m.s_Initials)
        p(3) = New SqlParameter("@s_TaxNo", m.s_TaxNo)
        p(4) = New SqlParameter("@s_Account", m.s_Account)
        p(5) = New SqlParameter("@s_Address", m.s_Address)
        p(6) = New SqlParameter("@s_Phone1", m.s_Phone1)
        p(7) = New SqlParameter("@s_Phone2", m.s_Phone2)
        p(8) = New SqlParameter("@s_Fax", m.s_Fax)
        p(9) = New SqlParameter("@s_Email", m.s_Email)
        p(10) = New SqlParameter("@s_Website", m.s_Website)
        p(11) = New SqlParameter("@i_FormatCur", m.i_FormatCur)
        p(12) = New SqlParameter("@i_FormatNum", m.i_FormatNum)
        p(13) = New SqlParameter("@b_SysDiscountBeforeTax", m.b_SysDiscountBeforeTax)
        p(14) = New SqlParameter("@s_SysCur", m.s_SysCur)
        p(15) = New SqlParameter("@b_SysCommission", m.b_SysCommission)
        p(16) = New SqlParameter("@b_isTrackPurchaseOrder", m.b_isTrackPurchaseOrder)
        p(17) = New SqlParameter("@b_CheckInstock", m.b_CheckInstock)
        p(18) = New SqlParameter("@i_ConfigID", m.i_ConfigID) '
        p(19) = New SqlParameter("@b_ShowLogo", m.b_ShowLogo)
        p(20) = New SqlParameter("@b_ShowName", m.b_ShowName)
        p(21) = New SqlParameter("@b_ShowAdd", m.b_ShowAdd)
        p(22) = New SqlParameter("@b_ShowPhoneFax", m.b_ShowPhoneFax)
        p(23) = New SqlParameter("@b_ShowEmailWeb", m.b_ShowEmailWeb)
        p(29) = New SqlParameter("@b_isEDiscount", m.b_isEDiscount)
        p(30) = New SqlParameter("@b_isEProgressive", m.b_isEProgressive)
        p(31) = New SqlParameter("@i_CountPrint", m.i_Countprint)
        p(32) = New SqlParameter("@b_ApplyPrice", m.b_ApplyPrice)
        p(33) = New SqlParameter("@b_PriceObject", m.b_PriceObject)
        p(34) = New SqlParameter("@b_Method", m.b_Method)
        p(35) = New SqlParameter("@b_EmployLogin", m.b_EmployLogin)
        p(36) = New SqlParameter("@b_PriceLevel_Order", m.b_PriceLevel_Order)
        p(37) = New SqlParameter("@b_Purchase", m.b_Purchase)
        p(40) = New SqlParameter("@isSendHQ", m.isSendHQ)
        p(41) = New SqlParameter("@StoreID", m.StoreID)
        p(42) = New SqlParameter("@URLHQ", m.URLHQ)
        p(44) = New SqlParameter("@b_PriceObGroup", m.b_PriceObGroup)
        p(45) = New SqlParameter("@b_isMultiStore", m.b_isMultiStore) '26.05.10-xuat hang tu nhieu kho
        p(46) = New SqlParameter("@b_isCheckBeforeTurnOut", m.b_isCheckBeforeTurnOut) '27.05.10-kiem tra hang nhap mua truoc khi xuat tra
        p(47) = New SqlParameter("@i_ShowForm", m.i_ShowForm)
        p(48) = New SqlParameter("@i_Prepayment", m.i_Prepayment)
        p(49) = New SqlParameter("@i_TimeAlertDown", m.i_TimeAlertDown)
        p(50) = New SqlParameter("@nCharTax", m.nCharTax)
        p(51) = New SqlParameter("@symbolTax", m.symbolTax)
        p(52) = New SqlParameter("@IsPriceVAT", m.IsPriceVAT)
        p(53) = New SqlParameter("@s_Item", m.s_iItem)
        p(54) = New SqlParameter("@b_ChooseTypePrint", m.b_ChooseTypePrint)
        p(55) = New SqlParameter("@i_QtyPrint", m.i_QtyPrint)
        p(56) = New SqlParameter("@IsView", m.IsView)
        p(57) = New SqlParameter("@i_NumColExchange", m.i_NumColExchange)
        p(58) = New SqlParameter("@s_MethodExchange", m.s_MethodExchange)
        p(59) = New SqlParameter("@nRow", m.nRow)
        p(60) = New SqlParameter("@VATDefault", m.VATDefault)
        p(61) = New SqlParameter("@AutoCheckHQ", m.AutoCheckHQ)
        p(62) = New SqlParameter("@DoanhSoQuiDoiDiem", m.m_LimitRevenue)
        p(63) = New SqlParameter("@SmsContent", m.SmsContent)
        p(64) = New SqlParameter("@kytunhandien", m.kytunhandien)
        p(65) = New SqlParameter("@sokytusoluong", m.sokytusoluong)
        p(66) = New SqlParameter("@Quidoisoluong", m.Quidoisoluong)
        p(67) = New SqlParameter("@sokytumahang", m.sokytumahang)
        p(68) = New SqlParameter("@PortWeight", m.PortWeight)
        p(69) = New SqlParameter("@BaudRate", m.BaudRate)
        If Not Me.execSQL(sql, p) Then
            Return False
        End If

        Me.CommitTranstion()
        Return True
    End Function

    Public Function getisChangeCurr(ByVal sCurr As String) As Boolean
        Dim sql As String = "Select count(*) as C from v_fund where s_Currency_ID=@sCurr and i_Ordinal>=0"
        '02/02/2010n phat sinh nghiep vu nhap xuat la an
        sql += " union all Select count(*) as C from V_Orders"
        sql += " union all Select count(*) as C from V_Imports"
        Dim p(0) As SqlParameter
        p(0) = New SqlParameter("@sCurr", sCurr)
        Dim tb As DataTable = getTableSQL(sql, p)
        If Not tb Is Nothing Then
            For Each r As DataRow In tb.Rows
                If r("C") > 0 Then
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Public Function DELETEDB() As Boolean
        Dim sql As String
        sql = "Delete from tblConfig "
        Return Me.execSQL(sql)
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
    Public Function CheckSendHQOnLine(ByVal ID As Integer) As Boolean
        Dim tb As DataTable = getTableSQL("Select Isnull(Online,0) as Online from tbConfigschedule where ID=@ID", New SqlParameter() {New SqlParameter("@ID", ID)})
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return tb.Rows(0)("Online")
        End If
    End Function
    Public Function UpdateSchedule(ByVal ID As Integer, ByVal dtTime As Date) As Boolean
        Dim sql As String = ""
        sql = "Update tbConfigschedule set dtCheckpoint=@dtTime where ID=@ID"
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        p(1) = New SqlParameter("@dtTime", dtTime)
        Return execSQL(sql, p)
    End Function
    Public Function UpdateOnlineHQ(ByVal ID As Integer, ByVal Online As Boolean) As Boolean
        Dim sql As String = ""
        sql = "Update tbConfigschedule set Online=@Online where ID=@ID"
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@ID", ID)
        p(1) = New SqlParameter("@Online", Online)
        Return execSQL(sql, p)
    End Function

    Public Function GetConfigSendHQ() As DataTable
        Return getTableSQL("Select * from tbConfigschedule Order by ID")
    End Function
    Public Function getInfo() As Model.MConfigProgram
        Dim m As New Model.MConfigProgram
        Dim sql As String = "Select * From tblConfig"
        Dim tb As DataTable = Me.getTableSQL(sql)

        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Try
                m.i_ID = IsNull(tb.Rows(0)("i_ID"), 0)
                m.s_CompanyName = IsNull(tb.Rows(0)("s_CompanyName"), "")
                m.s_Initials = IsNull(tb.Rows(0)("s_Initials"), "")
                m.im_Logo = IsNull(tb.Rows(0)("im_Logo"), Nothing)
                m.s_TaxNo = IsNull(tb.Rows(0)("s_TaxNo"), "")
                m.s_Account = IsNull(tb.Rows(0)("s_Account"), "")
                m.s_Address = IsNull(tb.Rows(0)("s_Address"), "")
                m.s_Phone1 = IsNull(tb.Rows(0)("s_Phone1"), "")
                m.s_Phone2 = IsNull(tb.Rows(0)("s_Phone2"), "")
                m.s_Fax = IsNull(tb.Rows(0)("s_Fax"), "")
                m.s_Email = IsNull(tb.Rows(0)("s_Email"), "")
                m.s_Website = IsNull(tb.Rows(0)("s_Website"), "")
                m.i_FormatCur = IsNull(tb.Rows(0)("i_FormatCur"), "")
                m.i_FormatNum = IsNull(tb.Rows(0)("i_FormatNum"), "")
                m.s_SysCur = IsNull(tb.Rows(0)("s_SysCur"), "")
                m.b_SysDiscountBeforeTax = IsNull(tb.Rows(0)("b_SysDiscountBeforeTax"), False)
                m.b_SysCommission = IsNull(tb.Rows(0)("b_SysCommission"), False)
                m.b_isTrackPurchaseOrder = IsNull(tb.Rows(0)("b_isTrackPurchaseOrder"), False)
                m.b_CheckInstock = IsNull(tb.Rows(0)("b_CheckInstock"), False)
                m.s_MethodHH = IsNull(tb.Rows(0)("s_MethodHH"), "")
                m.s_MethodCL = IsNull(tb.Rows(0)("s_MethodCL"), "")
                m.s_MethodTU = IsNull(tb.Rows(0)("s_MethodTU"), "")
                m.s_TransCurrOut = IsNull(tb.Rows(0)("s_TransCurrOut"), "")
                m.s_TransCurrInc = IsNull(tb.Rows(0)("s_TransCurrInc"), "")
                m.s_ThuTamUng = IsNull(tb.Rows(0)("s_ThuTamUng"), "")
                m.s_MethodImport = IsNull(tb.Rows(0)("s_MethodImport"), "")
                m.s_MethodOrder = IsNull(tb.Rows(0)("s_MethodOrder"), "")
                m.i_ConfigID = IsNull(tb.Rows(0)("i_ConfigID"), 1)
                m.b_ShowLogo = IsNull(tb.Rows(0)("b_ShowLogo"), False)
                m.b_ShowName = IsNull(tb.Rows(0)("b_ShowName"), False)
                m.b_ShowAdd = IsNull(tb.Rows(0)("b_ShowAdd"), False)
                m.b_ShowPhoneFax = IsNull(tb.Rows(0)("b_ShowPhoneFax"), False)
                m.b_ShowEmailWeb = IsNull(tb.Rows(0)("b_ShowEmailWeb"), False)
                m.b_isEDiscount = IsNull(tb.Rows(0)("b_isEDiscount"), False)
                m.b_isEProgressive = IsNull(tb.Rows(0)("b_isEProgressive"), False)
                m.i_Countprint = IsNull(tb.Rows(0)("i_Countprint"), 1)
                m.b_ApplyPrice = IsNull(tb.Rows(0)("b_ApplyPrice"), False)
                m.b_PriceObject = IsNull(tb.Rows(0)("b_PriceObject"), False)
                m.b_Method = IsNull(tb.Rows(0)("b_Method"), False)
                m.b_EmployLogin = IsNull(tb.Rows(0)("b_EmployLogin"), False)
                m.b_PriceLevel_Order = IsNull(tb.Rows(0)("b_PriceLevel_Order"), False)
                m.b_Purchase = IsNull(tb.Rows(0)("b_Purchase"), False)
                m.isSendHQ = IsNull(tb.Rows(0)("isSendHQ"), False)
                m.StoreID = IsNull(tb.Rows(0)("StoreID"), "")
                m.URLHQ = IsNull(tb.Rows(0)("URLHQ"), "")
                m.b_PriceObGroup = IsNull(tb.Rows(0)("b_PriceObGroup"), False)
                m.b_isMultiStore = IsNull(tb.Rows(0)("b_isMultiStore"), False) '26.05.10-xuat hang tu nhieu kho
                m.b_isCheckBeforeTurnOut = IsNull(tb.Rows(0)("b_isCheckBeforeTurnOut"), False) '27.05.10-kiem tra hang nhap mua truoc khi xuat tra
                m.i_ShowForm = IsNull(tb.Rows(0)("i_ShowForm"), 0)
                m.i_Prepayment = IsNull(tb.Rows(0)("i_Prepayment"), False)
                m.i_TimeAlertDown = IsNull(tb.Rows(0)("i_TimeAlertDown"), 5)
                m.s_iItem = IsNull(tb.Rows(0)("s_Item"), "")
                m.b_ChooseTypePrint = IsNull(tb.Rows(0)("b_ChooseTypePrint"), True)
                m.i_QtyPrint = IsNull(tb.Rows(0)("i_QtyPrint"), 1)
                m.i_NumColExchange = IsNull(tb.Rows(0)("i_NumColExchange"), 2)
                m.s_MethodExchange = IsNull(tb.Rows(0)("s_MethodExchange"), "*")

                If tb.Columns.Contains("symbolTax") Then
                    m.symbolTax = IsNull(tb.Rows(0)("symbolTax"), "")
                End If

                If tb.Columns.Contains("nCharTax") Then
                    m.nCharTax = IsNull(tb.Rows(0)("nCharTax"), 5)
                End If
                If tb.Columns.Contains("IsPriceVAT") Then
                    m.IsPriceVAT = IsNull(tb.Rows(0)("IsPriceVAT"), False)
                End If
                If tb.Columns.Contains("IsView") Then
                    m.IsView = IsNull(tb.Rows(0)("IsView"), True)
                End If
                If tb.Columns.Contains("VATDefault") Then
                    m.VATDefault = IsNull(tb.Rows(0)("VATDefault"), 10)
                End If
                If tb.Columns.Contains("nRow") Then
                    m.nRow = IsNull(tb.Rows(0)("nRow"), 13)
                End If
                m.AutoCheckHQ = IsNull(tb.Rows(0)("AutoCheckHQ"), False)
                m.m_LimitRevenue = IsNull(tb.Rows(0)("DoanhSoQuiDoiDiem"), 1)
                If tb.Columns.Contains("SmsContent") Then
                    m.SmsContent = IsNull(tb.Rows(0)("SmsContent"), "")
                End If
                If tb.Columns.Contains("kytunhandien") Then
                    m.kytunhandien = IsNull(tb.Rows(0)("kytunhandien"), "")
                End If
                If tb.Columns.Contains("sokytusoluong") Then
                    m.sokytusoluong = IsNull(tb.Rows(0)("sokytusoluong"), 0)
                End If
                If tb.Columns.Contains("Quidoisoluong") Then
                    m.Quidoisoluong = IsNull(tb.Rows(0)("Quidoisoluong"), 0)
                End If
                If tb.Columns.Contains("sokytumahang") Then
                    m.sokytumahang = IsNull(tb.Rows(0)("sokytumahang"), 0)
                End If
                If tb.Columns.Contains("PortWeight") Then
                    m.PortWeight = IsNull(tb.Rows(0)("PortWeight"), "COM1")
                End If
                If tb.Columns.Contains("BaudRate") Then
                    m.BaudRate = IsNull(tb.Rows(0)("BaudRate"), 9600)
                End If
            Catch ex As Exception

            End Try

        End If
        'tb = getTableSQL("Select i_ID, s_Name from Ls_Currency where IDKH_s=N'" & m.s_SysCur.Replace("'", "''") & "'")
        'If Not tb Is Nothing Then
        '    If tb.Rows.Count > 0 Then
        '        m.s_KeySysCur = tb.Rows(0)("i_ID")
        '        m.s_SysCurChar = IsNull(tb.Rows(0)("s_Name"), "") '26.11.09
        '    End If
        'End If
        Return m

    End Function
    'Cot dung de in trong Barcode
    Public Function getCol_Bar() As DataTable
        Dim tb As DataTable = getTableSQL("select * from tblBarCode order by [i_IDSort] asc")
        Return tb
    End Function
    'update cac cot in barcode
    Public Function Update_PrintBar(ByVal tb As DataTable) As Boolean
        Dim sql As String = ""
        For Each r As DataRow In tb.Rows
            If r.RowState <> DataRowState.Deleted Then
                sql = "INSERT INTO [tblBarCode]([ID],[s_Name])VALUES(N'" & IsNull(r("ID"), "") & "',N'" & IsNull(r("s_Name"), "") & "')"
                execSQL(sql)
            End If
        Next
        Return True
    End Function
    Public Function Delete_PrintBar() As Boolean
        Return execSQL("Delete from tblBarCode")
    End Function

    'phan giai ma thue ra 14 cot
    Public Function TachVAT(ByVal s As String) As Boolean
        If s.Trim.Length = 0 Then Return False
        Dim sql As String = "Delete from tblDetailTax"

        Dim sqlin As String = ""
        Dim sqlp As String = ""
        s = s.Trim
        Dim n As Integer = 0
        n = s.Length
        Dim p(n) As SqlParameter
        For i As Integer = 0 To n - 1
            Dim h As String = ""
            h = s.Substring(i, 1)
            sqlin += "," + "s" & i + 1
            sqlp += "," + "@s" & i + 1
            p(i) = New SqlParameter("@s" & i + 1, h)
        Next
        p(n) = New SqlParameter("@s", s.Trim)
        sql += " Insert into tblDetailTax(s" & sqlin & ")"
        sql += " values (@s" & sqlp & ")"

        Return execSQL(sql, p)
    End Function
    Public Function updateLimitRevenue(ByVal limitRevenue As Double, ByVal SmsContent As String) As Boolean
        Dim sql As String = "Update tblConfig set DoanhSoQuiDoiDiem=@limitRevenue,SmsContent=@SmsContent"
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@limitRevenue", limitRevenue)
        p(1) = New SqlParameter("@SmsContent", SmsContent)
        Return execSQL(sql, p)
    End Function
End Class
