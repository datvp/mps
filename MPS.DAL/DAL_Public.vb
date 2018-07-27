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

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max + 100)
    End Function
    ''' <summary>
    ''' Generates a random Integer with any (inclusive) minimum or (inclusive) maximum values, with full range of Int32 values.
    ''' </summary>
    ''' <param name="inMin">Inclusive Minimum value. Lowest possible return value.</param>
    ''' <param name="inMax">Inclusive Maximum value. Highest possible return value.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GenRandomInt(ByVal inMin As Integer, ByVal inMax As Integer) As Integer
        Static staticRandomGenerator As New System.Random
        If inMin > inMax Then Dim t = inMin : inMin = inMax : inMax = t
        If inMax < Integer.MaxValue Then Return staticRandomGenerator.Next(inMin, inMax + 1)
        ' now max = Int32.MaxValue, so we need to work around Microsoft's quirk of an exclusive max parameter.
        If inMin > Integer.MinValue Then Return staticRandomGenerator.Next(inMin - 1, inMax) + 1 ' okay, this was the easy one.
        ' now min and max give full range of integer, but Random.Next() does not give us an option for the full range of integer.
        ' so we need to use Random.NextBytes() to give us 4 random bytes, then convert that to our random int.
        Dim bytes(3) As Byte ' 4 bytes, 0 to 3
        staticRandomGenerator.NextBytes(bytes) ' 4 random bytes
        Return BitConverter.ToInt32(bytes, 0) ' return bytes converted to a random Int32
    End Function
    ''' <summary>
    ''' doanh số theo quý trong năm
    ''' </summary>
    ''' <param name="thang"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getChart_TotalSale(ByVal thang As Date) As DataTable
        Dim tb As New DataTable
        tb.Columns.Clear()
        tb.Columns.Add("Day", GetType(String))
        tb.Columns.Add("-", GetType(Double))
        'Dim first_day As Integer = 1
        'Dim end_day As Integer = thang.AddMonths(1).AddDays(-thang.Day).Day
        'For i = first_day To end_day
        '    Dim r = tb.NewRow
        '    r("Day") = IIf(i < 10, "0" & i.ToString, i.ToString)
        '    r("-") = GenRandomInt(500000000, 950000000)
        '    tb.Rows.Add(r)
        'Next
        'Dim year = Now.Year
        Dim quy As Integer = 3
        Dim end_day As Integer = thang.AddMonths(1).AddDays(-thang.Day).Day
        For i = 1 To 4
            Dim r = tb.NewRow
            r("Day") = quy * i & " tháng"
            r("-") = GenRandomInt(500000, 950000000)
            tb.Rows.Add(r)
        Next

        Return tb
    End Function
    ''' <summary>
    ''' doanh số theo trạng thái hợp đồng
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getChart_StateSale() As DataTable
        Dim tb As New DataTable
        tb.Columns.Clear()
        tb.Columns.Add("State", GetType(String))
        tb.Columns.Add("Value", GetType(Double))

        Dim dr = tb.NewRow
        dr("State") = "Đã ký"
        dr("Value") = 20560940000
        tb.Rows.Add(dr)

        dr = tb.NewRow
        dr("State") = "Chờ ký"
        dr("Value") = 10798686818
        tb.Rows.Add(dr)
        Return tb
    End Function

    ''' <summary>
    ''' tổng hợp các hợp đồng sắp hết hạn
    ''' </summary>
    ''' <param name="deadline">số ngày hết hạn so với ngày hiện tại</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getListDeadlineContracts(ByVal deadline As Integer) As DataTable
        Dim tb As New DataTable
        tb.Columns.Clear()
        tb.Columns.Add("ContractId", GetType(String))
        tb.Columns.Add("CreateDate", GetType(Date))
        tb.Columns.Add("ContractDeadLine", GetType(Date))
        tb.Columns.Add("DeadLine", GetType(Integer))
        tb.Columns.Add("ContractValue", GetType(Double))

        Dim dr = tb.NewRow
        dr("ContractId") = "HD-001"
        dr("CreateDate") = Now.Date.AddDays(-360)
        dr("ContractDeadLine") = Now.Date.AddDays(90)
        dr("DeadLine") = 90
        dr("ContractValue") = 1000000000
        tb.Rows.Add(dr)

        dr = tb.NewRow
        dr("ContractId") = "HD-002"
        dr("CreateDate") = Now.Date.AddDays(-720)
        dr("ContractDeadLine") = Now.Date.AddDays(60)
        dr("DeadLine") = 60
        dr("ContractValue") = 2500000000
        tb.Rows.Add(dr)

        dr = tb.NewRow
        dr("ContractId") = "HD-003"
        dr("CreateDate") = Now.Date.AddDays(-800)
        dr("ContractDeadLine") = Now.Date.AddDays(50)
        dr("DeadLine") = 50
        dr("ContractValue") = 3500000000
        tb.Rows.Add(dr)
        Return tb
    End Function

    Public Function getChartByProject() As DataTable
        Dim tb As New DataTable
        tb.Columns.Clear()
        tb.Columns.Add("Project", GetType(String))
        tb.Columns.Add("Value", GetType(Double))

        Dim dr = tb.NewRow
        dr("Project") = "DA-001"
        dr("Value") = 20560940000
        tb.Rows.Add(dr)

        dr = tb.NewRow
        dr("Project") = "DA-002"
        dr("Value") = 20000000000
        tb.Rows.Add(dr)

        dr = tb.NewRow
        dr("Project") = "DA-003"
        dr("Value") = 5000000000
        tb.Rows.Add(dr)

        dr = tb.NewRow
        dr("Project") = "DA-004"
        dr("Value") = 13000000000
        tb.Rows.Add(dr)
        Return tb
    End Function

    Public Function getListReports() As DataTable
        Return getTableSQL("Select * from Ls_Reports where Valid=1 Order by IDSort asc")
    End Function
End Class
