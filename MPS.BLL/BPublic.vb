Public Class BPublic
    Private WithEvents cls As DAL.DAL_Public = DAL.DAL_Public.Instance
    Event _errorRaise(ByVal messege As String)
    Private Sub New()
    End Sub
    Private Shared obj As BPublic
    Public Shared ReadOnly Property Instance() As BPublic
        Get
            If obj Is Nothing Then
                obj = New BPublic
            End If
            Return obj
        End Get
    End Property
    Private Sub cls__error(ByVal message As String) Handles cls._error
        RaiseEvent _errorRaise(message)
    End Sub
    Public Function RepairtViewDebt() As Boolean
        Return cls.RepairtViewDebt
    End Function
    Public Function getServerDate() As Date
        Return cls.getServerDate
    End Function
    'Public Function getNumberID(ByVal iTypeNumber As TypeNumber) As String()
    '    Dim d As Date = Me.getServerDate()
    '    Return cls.getNumberID(iTypeNumber, d)
    'End Function
    Public Function getNumberID(ByVal iTypeNumber As TypeNumber, ByVal dayMonth As Date, ByVal branchId As String) As String()
        Return cls.getNumberID(iTypeNumber, dayMonth, branchId)
    End Function

    Public Function getNumberSID(ByVal iTypeNumber As TypeNumber, ByVal NumberID As String) As String
        Return cls.getNumberSID(iTypeNumber, NumberID)
    End Function
    Public Function getListConfigNumber() As DataTable
        Return cls.getListConfigNumber
    End Function

    Public Function getListCloseBook() As DataTable
        Return cls.getListCloseBook
    End Function

    Public Function UpdateConfigNumber(ByVal tb As DataTable) As Boolean
        Return cls.UpdateConfigNumber(tb)
    End Function

    Public Function CheckCloseBook(ByVal iTypeNumber As TypeNumber, ByVal dayMonth As Date, ByVal UID As String) As Boolean
        Dim clsr As New DAL.DALFuncRight
        Dim tb As DataTable = clsr.getFuncRight(UID, 49)
        If tb.Rows(0)("R") Then
            Return False
        Else
            Return cls.CheckCloseBook(iTypeNumber, dayMonth)
        End If

    End Function
    Public Function UpdateCloseBook(ByVal iTypeNumber As TypeNumber, ByVal Name As String, ByVal valid As Boolean, ByVal toDate As Date, ByVal Note As String) As Boolean
        Return cls.UpdateCloseBook(iTypeNumber, Name, valid, toDate, Note)
    End Function
    Public Function getInfoDebtObject(ByVal Object_ID As String, ByVal isCustomer As Boolean) As DataTable
        Return cls.getInfoDebtObject(Object_ID, isCustomer, CDate("1900-1-1"))
    End Function
    Public Function UpdateBeginInstockOfEmp(ByVal ThuTU As String, ByVal ChiTU As String) As Boolean
        Return cls.UpdateBeginInstockOfEmp(ThuTU, ChiTU)
    End Function
    Public Function ClearBook() As Boolean
        Return cls.ClearBook
    End Function
    Public Function RepairInstock_Debt() As Boolean
        Return cls.RepairInstock_Debt
    End Function
    Public Function SaveConfigProductCode(ByVal isAuto As Boolean, ByVal nType As Integer, ByVal Prefix As String, ByVal Pos As Integer, ByVal iLen As Integer, _
                                          ByVal b_SortProduct As Boolean, ByVal i_OptionSort As Integer, ByVal i_LocationNum As Integer, ByVal i_QtyNum As Integer) As Boolean
        Return cls.SaveConfigProductCode(isAuto, nType, Prefix, Pos, iLen, b_SortProduct, i_OptionSort, i_LocationNum, i_QtyNum)
    End Function

    Public Function SaveConfigObjectCode(ByVal isAuto As Boolean, ByVal nType As Integer, ByVal Prefix As String, ByVal Pos As Integer, ByVal iLen As Integer) As Boolean
        Return cls.SaveConfigObjectCode(isAuto, nType, Prefix, Pos, iLen)
    End Function

    Public Function SaveConfigEmployeeCode(ByVal isAuto As Boolean, ByVal nType As Integer, ByVal Prefix As String, ByVal Pos As Integer, ByVal iLen As Integer) As Boolean
        Return cls.SaveConfigEmployeeCode(isAuto, nType, Prefix, Pos, iLen)
    End Function

    Public Function getConfigProductCode() As DataTable
        Return cls.getConfigProductCode
    End Function
    '03.12.2010 lay cau hinh Sort
    Public Function getStringSortProduct(ByVal truong As String) As String
        Return cls.getStringSortProduct(truong)
    End Function
    Public Function getConfigObjectCode() As DataTable
        Return cls.getConfigObjectCode
    End Function

    Public Function getConfigEmployeeCode() As DataTable
        Return cls.getConfigEmployeeCode
    End Function

    Public Function getProductCode(ByVal GroupID As String) As String
        Return cls.getProductCode(GroupID)
    End Function

    Public Function getObjectCode(ByVal GroupID As String) As String
        Return cls.getObjectCode(GroupID)
    End Function

    Public Function getEmployeeCode(ByVal GroupID As String) As String
        Return cls.getEmployeeCode(GroupID)
    End Function

    Public Enum TypeNumber
        Import = 0
        PurchaseImport = 1
        OrderReturn = 2
        Outcome = 3
        Order = 4
        PurchaseOrder = 5
        ImportReturn = 6
        Income = 7
        Quote = 8
        TransStore = 9
        OtherOrder = 10
        OtherImport = 11
        Objects = 12
        Product = 13
        OrderTotal = 14
        Install = 15
        UnInstall = 16
        Control = 17
        TransCurr = 18
    End Enum
    'Phần cấu hình hiển thị cho từng User 12.06.09
    Public Function GetListItem(ByVal UID As String) As DataTable
        Return cls.GetListItem(UID)
    End Function
    Public Function GetMyDesk(ByVal UID As String) As DataTable
        Return cls.GetMyDesk(UID)
    End Function
    Public Function getDefaultMode_User(ByVal UID As String) As DataTable
        Return cls.getDefaultMode_User(UID)
    End Function
    Public Function getDefaultMode() As DataTable
        Return cls.getDefaultMode()
    End Function
    Public Function getList(ByVal sModuleID As String) As DataTable
        Return cls.getList(sModuleID)
    End Function
    Public Function DeleteMyDesk(ByVal UID As String) As Boolean
        Return cls.DeleteMyDesk(UID)
    End Function
    ''Phần cấu hình hiển thị mặc định chung cho những user ko có cấu hình riêng.
    Public Function DeletePublicDefault() As Boolean '18.06.09
        Return cls.DeletePublicDefault
    End Function
    Public Function GetPublicDesk() As DataTable
        Return cls.GetPublicDesk
    End Function

    Public Function getIDMax() As Integer
        Return cls.getIDMax()
    End Function
    Public Function getIDSort(ByVal uplevel As Integer) As Integer
        Return cls.getIDSort(uplevel)
    End Function

    Public Function CheckLimitRecord(ByVal iTypeNumber As TypeNumber, ByVal nRecord As Integer) As Boolean
        Return cls.CheckLimitRecord(iTypeNumber, nRecord)
    End Function
    Public Function UpdateVisbleFunc(ByVal Valid As Boolean) As Boolean
        Return cls.UpdateVisbleFunc(Valid)
    End Function

    Public Function getCLV() As String
        Return cls.getCLV
    End Function

    Public Function InsertBarcodeWeight(ByVal ID As String, ByVal BarcodeID As String, ByVal BarcodeName As String, ByVal Unit As String, ByVal Price As Double, ByVal Weight As Double, ByVal InputDate As Date) As Boolean
        Return cls.InsertBarcodeWeight(ID, BarcodeID, BarcodeName, Unit, Price, Weight, InputDate)
    End Function

    Public Function UpdateSmsContent(ByVal sms As String) As Boolean
        Return cls.UpdateSmsContent(sms)
    End Function
    Public Function GetSmsContent() As String
        Return cls.GetSmsContent()
    End Function

    Public Function getChart_TotalSale(ByVal thang As Date) As DataTable
        Return cls.getChart_TotalSale(thang)
    End Function
    ''' <summary>
    ''' doanh số theo trạng thái hợp đồng
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getChart_StateSale() As DataTable
        Return cls.getChart_StateSale()
    End Function

    ''' <summary>
    ''' tổng hợp các hợp đồng sắp hết hạn
    ''' </summary>
    ''' <param name="deadline">số ngày hết hạn so với ngày hiện tại</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getListDeadlineContracts(ByVal deadline As Integer) As DataTable
        Return cls.getListDeadlineContracts(deadline)
    End Function
    Public Function getChartByProject() As DataTable
        Return cls.getChartByProject()
    End Function

    Public Function getListReports() As DataTable
        Return cls.getListReports()
    End Function
End Class
