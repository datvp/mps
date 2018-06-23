Imports System.Data.SqlClient
Public Class clsReportHQ
    Inherits DALSQL
    Public Function rptTongketbanhang() As DataTable

        'rptChitietBanHang("", Now)


        Dim sql As String = ""
        sql = "Select ls.s_ID, ls.s_Store_ID,ls.s_Name,cast(0 as money) as toDay,cast(0 as money) as toMonth "
        sql += " ,cast(0 as money) as MonthLastYear,cast(0 as money) as toYear,cast(0 as money) as LastYear,getDate() as d"
        sql += " from ls_Stores ls"
        Dim tb As DataTable = getTableSQL(sql)
        For Each dr As DataRow In tb.Rows
            Dim d As Date = dr("d")
            dr("toDay") = TinhTien(dr("s_ID"), d, "day")
            dr("toMonth") = TinhTien(dr("s_ID"), d, "month")
            dr("toYear") = TinhTien(dr("s_ID"), d, "Year")

            d = d.AddDays(1 - d.Day).AddYears(-1)
            dr("MonthLastYear") = TinhTien(dr("s_ID"), d, "month")
            dr("LastYear") = TinhTien(dr("s_ID"), d, "Year")

        Next
        Return tb
    End Function
    Private Function TinhTien(ByVal Store_ID As String, ByVal ngay As Date, ByVal DatePart As String) As Double
        Dim t As Double = 0
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@ngay", ngay)
        Dim sql As String
        sql = "Select isnull(Sum(m_OrderTotal),0) as T from v_Fullorder where s_Col4=@Store_ID and Datediff(" & DatePart & ",dt_OrderDate,@ngay)=0"
        sql += " Select isnull(sum(m_ImportTotal),0)as T from Ls_ImportReturns where datediff(" & DatePart & ",dt_ImportDate,@ngay)=0 and s_Store_ID=@Store_ID"
        Dim ds As DataSet = getDatasetSQL(sql, p)
        If Not ds Is Nothing Then
            t = ds.Tables(0).Rows(0)("T")
            t -= ds.Tables(1).Rows(0)("T")
        End If

        Return t

    End Function

    Public Function rptHangbanTheongay(ByVal Store_ID As String, ByVal fromDate As Date, ByVal toDate As Date) As DataTable
        Dim sql As String = ""
        Dim p(2) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@fromDate", fromDate)
        p(2) = New SqlParameter("@toDate", toDate)
        sql = "Select ls.s_ID as Company_ID, ls.s_Store_ID,ls.s_Name,isnull(obj.s_Object_ID,v.ObjID) as ObjID, isnull(obj.s_Name,v.ObjectName) as ObjName, v.s_Order_ID,v.dt_OrderDate,v.m_OrderTotal"
        sql += " from ls_Stores ls"
        sql += " Join V_Fullorder v ON ls.s_ID=v.s_Col4"
        sql += " left join  ls_Objects obj On v.s_ObjectID=obj.s_ID"
        sql += " where Datediff(day,v.dt_OrderDate,@fromDate)<=0 and Datediff(day,v.dt_OrderDate,@toDate)>=0"
        If Store_ID <> "" Then
            sql += " and ls.s_ID=@Store_ID"
        End If
        sql += " Order by ls.s_Store_ID asc,v.dt_OrderDate asc,v.s_Order_ID asc"
        Return getTableSQL(sql, p)
    End Function

    Public Function rptChitietBanHang(ByVal Store_ID As String, ByVal ngay As Date) As DataTable
        Dim sql As String = ""
        Dim p(1) As SqlParameter
        p(0) = New SqlParameter("@Store_ID", Store_ID)
        p(1) = New SqlParameter("@ngay", ngay)
        sql = " Select ls.s_ID as Company_ID, ls.s_Store_ID,ls.s_Name,dt.Product_IDChar as ProID,dt.Product_Name,dt.s_Unit,dt.f_Quantity,dt.m_Price,"
        sql += " dt.f_Discount,dt.m_Discount,dt.f_Quantity*(dt.m_Price-dt.m_Discount)*(1-dt.f_Discount/100) as Total"
        sql += " from V_OrderDetail dt,v_fullorder v,ls_Stores ls"
        sql += " where v.s_ID=dt.s_OrderID and v.s_Col4=ls.s_ID"
        sql += " and Datediff(day,v.dt_OrderDate,@ngay)=0"
        If Store_ID <> "" Then
            sql += " and v.s_Col4=@Store_ID"
        End If
        sql += " Order by ls.s_Store_ID asc,dt.Product_Name asc"
        Return getTableSQL(sql, p)
    End Function
End Class
