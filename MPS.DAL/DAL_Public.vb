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
    ''' doanh thu theo hạng mục
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getChartByItem() As DataTable
        Dim tb As New DataTable
        tb.Columns.Clear()
        tb.Columns.Add("Item", GetType(String))
        tb.Columns.Add("-", GetType(Double))
        Dim tbItems = Me.getTableSQL("select * from V_ChartByItem Order by ItemId")
        If tbItems IsNot Nothing AndAlso tbItems.Rows.Count > 0 Then
            For Each item In tbItems.Rows
                Dim r = tb.NewRow
                r("Item") = item("ItemId").ToString
                r("-") = CDbl(IsNull(item("Total"), 0))
                tb.Rows.Add(r)
            Next
        End If
        Return tb
    End Function
    ''' <summary>
    ''' doanh số theo trạng thái hợp đồng
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getChartByClientGroup() As DataTable
        Dim tb As New DataTable
        tb.Columns.Clear()
        tb.Columns.Add("Client", GetType(String))
        tb.Columns.Add("Value", GetType(Double))

        Dim tbItems = Me.getTableSQL("select * from V_ChartByClientGroup Order by ClientGroupName")
        If tbItems IsNot Nothing AndAlso tbItems.Rows.Count > 0 Then
            For Each item In tbItems.Rows
                Dim r = tb.NewRow
                r("Client") = item("ClientGroupName").ToString
                r("Value") = CDbl(IsNull(item("Total"), 0))
                tb.Rows.Add(r)
            Next
        End If

        Return tb
    End Function

    ''' <summary>
    ''' tổng hợp các hợp đồng sắp hết hạn
    ''' </summary>
    ''' <param name="deadline">số ngày hết hạn so với ngày hiện tại</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getListDeadlineContracts(ByVal deadline As Integer) As DataTable
        Dim sql = "Exec sp_getListContractByDeadLine @deadline"
        Dim tb = getTableSQL(sql, New SqlParameter("@deadline", deadline))
        Return tb
    End Function

    Public Function getChartByProject() As DataTable
        Dim tb As New DataTable
        tb.Columns.Clear()
        tb.Columns.Add("ProjectName", GetType(String))
        tb.Columns.Add("Value", GetType(Double))

        Dim tbItems = Me.getTableSQL("select * from V_ChartByProject Order by ProjectId")
        If tbItems IsNot Nothing AndAlso tbItems.Rows.Count > 0 Then
            For Each item In tbItems.Rows
                Dim r = tb.NewRow
                r("ProjectName") = item("ProjectId").ToString
                r("Value") = CDbl(IsNull(item("Total"), 0))
                tb.Rows.Add(r)
            Next
        End If

        Return tb
    End Function

    Public Function getListReports() As DataTable
        Return getTableSQL("Select * from Ls_Reports where Valid=1 Order by IDSort asc")
    End Function
End Class
