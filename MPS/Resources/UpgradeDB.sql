alter VIEW dbo.V_Orders    
AS    
SELECT   v.s_IDFromHQ,  e.s_Name AS EmployeeName, o.s_Name AS ObjectName, c.s_Name AS ContactName,o.s_Object_ID as ObjectID,    
q.s_Order_ID AS QuoteID, p.s_Order_ID AS PurchaseID, t.s_Name AS TermName, v.s_ID,    
v.s_Order_ID, v.s_Char, v.i_ItemID, v.dt_OrderDate, v.s_EmployeeID, v.s_ObjectID,    
v.s_DeliverableAddresss, v.s_PayabbleAddress, v.s_ContactID, v.m_Ordertotal, v.s_Note,    
v.f_VAT, v.m_VAT, v.f_Discount, v.m_OrderTotalDiscount, v.f_Per, v.m_Per, v.i_IDSort,    
v.s_Word, v.s_GroupProduct, v.s_FullOrderDate, v.s_SymbolInvoice, v.s_Invoice,    
v.m_Exchange, v.s_PurchaseID, v.s_Quote_ID, v.b_isDiscount, v.b_isDiscountProduct,    
v.i_TermID, v.s_Creator, v.s_Editor, v.dt_Create, v.dt_Edit, v.f_Commission, v.m_Commission,    
v.b_isDept, v.b_isCash, v.b_isCashAll, v.b_isCashPart, v.b_isCashPrepay, v.m_Cash,  
v.s_Col1,v.s_Col2,v.s_Col3,v.s_Col4,v.s_Col5, v.b_Col1,v.b_Col2,v.b1,v.b2,v.b3,v.s1,v.s2,v.s3,    
v.d1,v.d2 ,v.d3, isnull(v.v1,0) as m_MoneyBack,v.v2,v.v3,isnull(v.v4,0) as f_DiscountEmp,isnull(v.v5,0) as m_DiscountEmp
,Cash=(select sum(pr.m_Total)as m_Total from ls_income i join Pr_NumberIncome pr on i.s_ID=pr.s_IncomeID where isnull(i.s_Bank_ID,'')='' and pr.s_NumberID=v.s_ID)
,ChuyenKhoan=(select sum(pr.m_Total)as m_Total from ls_income i join Pr_NumberIncome pr on i.s_ID=pr.s_IncomeID where i.s_Bank_ID<>'' and s_CardType='' and pr.s_NumberID=v.s_ID)
,CaThe=(select sum(pr.m_Total)as m_Total from ls_income i join Pr_NumberIncome pr on i.s_ID=pr.s_IncomeID where i.s_Bank_ID<>'' and s_CardType<>'' and pr.s_NumberID=v.s_ID)
,v.[Transfer],v.Bank_ID,v.ScandCard,v.CardNumber,v.NationID,v.ObjID,v.ObjectName as ObjName,v.Address,v.MST,v.Company,v.ObjIDVAT,v.ObjectNameVAT,    
v.AddressVAT,v.MSTVAT, case when v.f_VAT=-1 then 0 else v.f_VAT end as f_VAT1    
, cast(ltrim(rtrim(str(year(v.dt_OrderDate))))+'-'+ ltrim(rtrim(str(month(v.dt_OrderDate))))+'-'+    
ltrim(rtrim(str(day(v.dt_OrderDate)))) as smalldatetime) as OrderDate,v.f_Point,v.m_RevenueRoundPoint,''as isDebt
FROM   V_FullOrder  v LEFT OUTER JOIN    
LS_PaymentTerm t ON v.i_TermID = t.s_ID LEFT OUTER JOIN    
LS_PurchaseOrders p ON v.s_PurchaseID = p.s_ID LEFT OUTER JOIN    
Ls_Quote q ON v.s_Quote_ID = q.s_ID LEFT OUTER JOIN    
LS_Contacts c ON v.s_ContactID = c.s_ID LEFT OUTER JOIN    
LS_Objects  o ON v.s_ObjectID = o.s_ID LEFT OUTER JOIN    
LS_Employees  e ON v.s_EmployeeID = e.s_ID
GO
