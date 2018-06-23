Public Class B_Report
    Private WithEvents cls As New Reports.DAL_ReportOfStore
    'Private WithEvents clsCounter As New Reports.DAL_ReportOfCounter
    Event _errorRaise(ByVal messege As String)
    Property IsStoreSelectOption() As Boolean
        Get
            Return cls.IsStoreSelectOption
        End Get
        Set(ByVal value As Boolean)
            cls.IsStoreSelectOption = value
        End Set
    End Property
    Property IsGroupOption() As Boolean
        Get
            Return cls.IsGroupOption
        End Get
        Set(ByVal value As Boolean)
            cls.IsGroupOption = value
        End Set
    End Property
   
    ''' <summary>
    ''' lấy ds tên kho đang chọn
    ''' </summary>
    ''' <param name="CPUID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getListStoreNameSelect(ByVal CPUID As String) As String
        Return cls.getListStoreSelect(CPUID)
    End Function
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub
    Public Function UpdateImageReport(ByVal ID As String, ByVal ArrIM As Byte()) As Boolean
        Return cls.UpdateImageReport(ID, ArrIM)
    End Function
    Public Function LoadImageReport(ByVal ID As String) As Byte()
        Return cls.LoadImageReport(ID)
    End Function
    Private Function Line() As String
        Return "________________"
    End Function
    Private Sub AddItem(ByVal tb As DataTable, ByVal ID As Integer, ByVal formName As String, ByVal Name As String)
        Dim dr As DataRow = tb.NewRow
        dr("FormName") = formName
        dr("ID") = ID
        dr("Name") = Name
        tb.Rows.Add(dr)
    End Sub
    Public Enum DefaultUnit
        Order = 0
        Import = 1
        Instock = 2
        MainUnit = 3
    End Enum

    Public Function rptStoreCard(ByVal CPUID As String, ByVal Store_ID As String, ByVal Product_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Double, ByVal s_Unit As String, ByVal branchId As String) As DataTable
        Return cls.rptStoreCard(CPUID, Store_ID, Product_ID, fromDate, toDate, Unit, s_Unit, branchId)
    End Function

    Public Function rptInstock(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal dayMonth As Date, ByVal Unit As DefaultUnit) As DataTable
        Return cls.rptInstock(CPUID, Store_ID, Group_ID, dayMonth, Unit)
    End Function
    Public Function rptOfNXT(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                             ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As DefaultUnit, ByVal isAll As Boolean, Optional ByVal isTotal As Boolean = True) As DataTable
        Return cls.rptOfNXT(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, isAll, isTotal)
    End Function
    Public Function rptNhapXuatTon_new(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                           ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal isAll As Boolean, Optional ByVal isTotal As Boolean = True) As DataTable
        Return cls.rptNhapXuatTon_new(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, isAll, isTotal)
    End Function
    Public Function prtCheckStore(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal dayMonth As Date, ByVal Unit As DefaultUnit) As DataTable
        Return cls.prtCheckStore(CPUID, Store_ID, Group_ID, dayMonth, Unit)
    End Function

#Region "BÁO CÁO KHO HÀNG"
    'Danh sách báo cáo kho hàng
    Public Function AddReportFunc() As DataTable
        'Dim tb As New DataTable
        'tb.Columns.Add("FormName", GetType(String))
        'tb.Columns.Add("ID", GetType(Integer))
        'tb.Columns.Add("Name")

        'Dim Line1 As String = Line()
        'Dim Line2 As String = Line1 & Line1
        'AddItem(tb, 0, "Store", Line1 & "Kho hàng" & Line2)

        'AddItem(tb, 1001, "Store", "Thẻ kho")
        'AddItem(tb, 1002, "Store", "Hàng tồn")
        'AddItem(tb, 1003, "Store", "Nhập xuất tồn")
        'AddItem(tb, 1004, "Store", "Hàng kiểm thực tế")
        'AddItem(tb, 0, "Store-Order", Line1 & "Xuất hàng" & Line2)
        'AddItem(tb, 1005, "Store-Order", "Chi tiết hàng xuất")
        'AddItem(tb, 1006, "Store-Order", "Tổng hợp hàng xuất")

        'AddItem(tb, 0, "Store-Import", Line1 & "Xuất hàng" & Line2)
        'AddItem(tb, 1007, "Store-Import", "Chi tiết hàng nhập")
        'AddItem(tb, 1008, "Store-Import", "Tổng hợp hàng nhập")

        'AddItem(tb, 0, "Store-Trans", Line1 & "Chuyển kho" & Line2)
        'AddItem(tb, 1009, "Store-Trans", "Chi tiết hàng xuất luân chuyển")
        'AddItem(tb, 1010, "Store-Trans", "Tổng hợp hàng xuất luân chuyển")

        'AddItem(tb, 1011, "Store-Trans", "Chi tiết hàng nhập luân chuyển")
        'AddItem(tb, 1012, "Store-Trans", "Tổng hợp hàng nhập luân chuyển")

        'AddItem(tb, 0, "Store-Import-Return", Line1 & "Trả hàng" & Line2)
        'AddItem(tb, 1013, "Store-Import-Return", "Chi tiết hàng nhập trả")
        'AddItem(tb, 1014, "Store-Import-Return", "Tổng hợp hàng nhập trả")

        'AddItem(tb, 1015, "Store-Order-Return", "Chi tiết hàng xuất trả")
        'AddItem(tb, 1016, "Store-Order-Return", "Tổng hợp hàng xuất trả")


        'Return tb

        Return cls.getListReport
    End Function
    'chi tiet xuat
    Public Function rptDetailOrder(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As DefaultUnit) As DataSet
        Return cls.rptDetailOrder(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    'tong hop xuat
    Public Function rptTotalOrder(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        Return cls.rptTotalOrder(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    'chi tiet nhap
    Public Function rptDetailImport(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As DefaultUnit) As DataSet
        Return cls.rptDetailImport(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    'tong hop nhap
    Public Function rptTotalImport(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        Return cls.rptTotalImport(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    'chi tiet xuat luan chuyen kho
    Public Function rptDetailOrderChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                   ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        Return cls.rptDetailOrderChange(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    'tong hop xuat luan chuyen kho
    Public Function rptTotalOrderChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        Return cls.rptTotalOrderChange(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    'chi tiet nhap luan chuyen kho
    Public Function rptDetailImportChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                   ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        Return cls.rptDetailImportChange(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    'tong hop nhap luan chuyen kho
    Public Function rptTotalImportChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        Return cls.rptTotalImportChange(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    'chi tiet nhap tra
    Public Function rptDetailImportReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As DefaultUnit) As DataSet
        Return cls.rptDetailImportReturn(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    'tong hop nhap tra
    Public Function rptTotalImportReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        Return cls.rptTotalImportReturn(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    'chi tiet xuat trả
    Public Function rptDetailOrderReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As DefaultUnit) As DataSet
        Return cls.rptDetailOrderReturn(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    'tong hop xuat tra
    Public Function rptTotalOrderReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataSet
        Return cls.rptTotalOrderReturn(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit)
    End Function
    '--------Xuat khac
    Public Function rptDetailOrderOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_PayMent As String) As DataSet
        Return cls.rptDetailOrderOther(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, s_PayMent)
    End Function
    Public Function rptTotalOrderOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_PayMent As String) As DataSet
        Return cls.rptTotalOrderOther(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, s_PayMent)
    End Function
    '---Nhap khac
    Public Function rptDetailImportOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_Payment As String) As DataSet
        Return cls.rptDetailImportOther(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, s_Payment)
    End Function
    Public Function rptTotalImportOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_Payment As String) As DataSet
        Return cls.rptTotalImportOther(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, s_Payment)
    End Function
    Public Function rptInstallTotal(ByVal dtFrom As Date, ByVal dtTo As Date) As DataSet
        Return cls.rptInstallTotal(dtFrom, dtTo)
    End Function
    Public Function rptUnInstallTotal(ByVal dtFrom As Date, ByVal dtTo As Date) As DataSet
        Return cls.rptUnInstallTotal(dtFrom, dtTo)
    End Function

    Public Function rptStockAgingReport(ByVal CPUID As String, ByVal Store_ID As String, ByVal Branch_ID As String, ByVal Group_ID As String, _
                                         ByVal ProductID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer) As DataTable
        Return cls.rptStockAgingReport(CPUID, Store_ID, Branch_ID, Group_ID, ProductID, fromDate, toDate, Unit)
    End Function
#End Region

    '#Region "Bao Cao Counter"
    '    Public Function getListCounter() As DataTable
    '        Return clsCounter.getListCounter
    '    End Function
    '    Public Function getListShift() As DataTable
    '        Return cls.getListShift
    '    End Function
    '    Public Function rptBangKeDoanhThuBanHang(ByVal CPUID As String, ByVal dtDate As Date, ByVal ShiftID As String, ByVal CounterID As String) As DataTable
    '        Return cls.rptBangKeDoanhThuBanHang(CPUID, dtDate, ShiftID, CounterID)
    '    End Function
    '    'chi tiet xuat
    '    Public Function rptDetailOrderCounter(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As DefaultUnit, ByVal Counter As String) As DataSet
    '        Return clsCounter.rptDetailOrder(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, Counter)
    '    End Function
    '    'tong hop xuat
    '    Public Function rptTotalOrderCounter(ByVal CPUID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Counter As String) As DataSet
    '        Return clsCounter.rptTotalOrder(CPUID, fromDate, toDate, Counter)
    '    End Function
    '    Public Function rptCompareCheck_SALE(ByVal CPUID As String, _
    '                                 ByVal fromDate As Date, ByVal toDate As Date, ByVal CounterID As String) As DataTable
    '        Return clsCounter.rptCompareCheck_SALE(CPUID, fromDate, toDate, CounterID)
    '    End Function
    '    Public Function rptTotalCounter(ByVal CPUID As String, ByVal fromDate As Date, ByVal toDate As Date) As DataSet
    '        Return clsCounter.rptTotalCounter(CPUID, fromDate, toDate)
    '    End Function
    '    Public Function CounterTable(ByVal Str As String) As DataTable
    '        Return clsCounter.getCounterTable(Str)
    '    End Function
    '#End Region

    Public Function rptInstockOfSupplier(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                             ByVal dayMonth As Date, ByVal Product_ID As String, ByVal Object_ID As String) As DataSet
        Return cls.rptInstockOfSupplier(CPUID, Store_ID, Group_ID, dayMonth, Product_ID, Object_ID)
    End Function
    Public Function rptInstockOfProductSupplier(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
                             ByVal dayMonth As Date, ByVal Product_ID As String, ByVal Object_ID As String) As DataSet
        Return cls.rptInstockOfProductSupplier(CPUID, Store_ID, Group_ID, dayMonth, Product_ID, Object_ID)
    End Function

    '#Region "Bao cao kho hang SMS "
    '    Public Function rptInstock(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal dayMonth As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataTable
    '        Return cls.rptInstock(CPUID, Store_ID, Group_ID, dayMonth, Unit, sLevel, iLevel)
    '    End Function
    '    Public Function rptOfNXT(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                            ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, _
    '                            ByVal isAll As Boolean, ByVal s_Level As String, ByVal iLevel As Integer, Optional ByVal isTotal As Boolean = True) As DataTable
    '        Return cls.rptOfNXT(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, isAll, s_Level, iLevel, isTotal)
    '    End Function

    '    Public Function prtCheckStore(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal dayMonth As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataTable
    '        Return cls.prtCheckStore(CPUID, Store_ID, Group_ID, dayMonth, Unit, sLevel, iLevel)
    '    End Function
    '    'chi tiet xuat
    '    Public Function rptDetailOrder(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                   ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptDetailOrder(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function
    '    'tong xuat
    '    Public Function rptTotalOrder(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptTotalOrder(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function

    '    'chi tiet  nhap
    '    Public Function rptDetailImport(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                   ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptDetailImport(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function

    '    '5.6.09-TỔNG HỢP HÀNG NHẬP
    '    Public Function rptTotalImport(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptTotalImport(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function
    '    '8.6.09-CHI TIẾT HÀNG XUẤT LUÂN CHUYỂN KHO
    '    Public Function rptDetailOrderChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptDetailOrderChange(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function

    '    '8.6.09-TỔNG HỢP HÀNG XUẤT LUÂN CHUYỂN
    '    Public Function rptTotalOrderChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptTotalOrderChange(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function
    '    '8.6.09-CHI TIẾT HÀNG NHẬP LUÂN CHUYỂN KHO
    '    Public Function rptDetailImportChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptDetailImportChange(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function
    '    '8.6.09-TỔNG HỢP HÀNG NHẬP LUÂN CHUYỂN
    '    Public Function rptTotalImportChange(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptTotalImportChange(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function
    '    '8.6.09-CHI TIẾT HÀNG NHẬP trả
    '    Public Function rptDetailImportReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptDetailImportReturn(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function
    '    '8.6.09-TỔNG HỢP HÀNG NHẬP trả
    '    '16.06.2009 - Thao bo sung truong dt_OverDate=[rptProductOrder].dt_OrderDate
    '    Public Function rptTotalImportReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptTotalImportReturn(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function
    '    'chi tiet xuat trả
    '    Public Function rptDetailOrderReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As DefaultUnit, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptDetailOrderReturn(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function
    '    'tong hop xuat tra
    '    Public Function rptTotalOrderReturn(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptTotalOrderReturn(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, sLevel, iLevel)
    '    End Function
    '    '--------Xuat khac
    '    Public Function rptDetailOrderOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_PayMent As String, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptDetailOrderOther(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, s_PayMent, sLevel, iLevel)
    '    End Function
    '    Public Function rptTotalOrderOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_PayMent As String, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptTotalOrderOther(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, s_PayMent, sLevel, iLevel)
    '    End Function
    '    '---Nhap khac
    '    Public Function rptDetailImportOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                    ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_Payment As String, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptDetailImportOther(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, s_Payment, sLevel, iLevel)
    '    End Function
    '    Public Function rptTotalImportOther(ByVal CPUID As String, ByVal Store_ID As String, ByVal Group_ID As String, _
    '                                  ByVal fromDate As Date, ByVal toDate As Date, ByVal Unit As Integer, ByVal s_Payment As String, ByVal sLevel As String, ByVal iLevel As Integer) As DataSet
    '        Return cls.rptTotalImportOther(CPUID, Store_ID, Group_ID, fromDate, toDate, Unit, s_Payment, sLevel, iLevel)
    '    End Function
    '#End Region

End Class
