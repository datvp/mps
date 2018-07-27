Imports System.Data.SqlClient
Public Class DAL_Contracts
    Inherits DALSQL
    Private Sub New()
    End Sub
    Private Shared obj As DAL_Contracts
    Public Shared ReadOnly Property Instance() As DAL_Contracts
        Get
            If obj Is Nothing Then
                obj = New DAL_Contracts
            End If
            Return obj
        End Get
    End Property

    Public Function isExist(ByVal ID As String) As Boolean
        Dim sql = "Select ContractId from Contracts where ContractId=@ID"
        Dim tb = getTableSQL(sql, New SqlParameter("@ID", ID))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function updateDB(ByVal m As Model.MContract) As Boolean
        Dim sql = ""

        If isExist(m.ContractId) Then
            sql = "Update Contracts set BranchId=@BranchId,ContractName=@ContractName,ProjectId=@ProjectId,ContractDate=@ContractDate,"
            sql += "ContractValue=@ContractValue,ContractDeadLine=@ContractDeadLine,MainContractorId=@MainContractorId,Note=@Note,"
            sql += "ContractLevelId=@ContractLevelId,UpdatedAt=getdate(),ContractState=@ContractState,SubContracts=@SubContracts,DeadlineExt=@DeadlineExt where ContractId=@ContractId"
        Else
            sql = "Insert into Contracts(BranchId,ContractId,ContractName,ProjectId,ContractDate,ContractValue,ContractDeadLine,MainContractorId,ContractLevelId,ContractState,SubContracts,Note,DeadlineExt,CreatedAt)"
            sql += "values(@BranchId,@ContractId,@ContractName,@ProjectId,@ContractDate,@ContractValue,@ContractDeadLine,@MainContractorId,@ContractLevelId,@ContractState,@SubContracts,@Note,@DeadlineExt,getdate())"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(12) As SqlParameter
        p(0) = New SqlParameter("@ContractId", m.ContractId)
        p(1) = New SqlParameter("@ContractName", m.ContractName)
        p(2) = New SqlParameter("@ProjectId", m.ProjectId)
        p(3) = New SqlParameter("@ContractDate", m.ContractDate)
        p(4) = New SqlParameter("@ContractValue", m.ContractValue)
        p(5) = New SqlParameter("@ContractDeadLine", m.ContractDeadLine)
        p(6) = New SqlParameter("@MainContractorId", m.MainContractorId)
        p(7) = New SqlParameter("@ContractState", m.ContractState)
        p(8) = New SqlParameter("@Note", m.Note)
        p(9) = New SqlParameter("@ContractLevelId", m.ContractLevelId)
        p(10) = New SqlParameter("@SubContracts", m.SubContracts)
        p(11) = New SqlParameter("@DeadlineExt", m.DeadlineExt)
        p(12) = New SqlParameter("@BranchId", m.BranchId)

        Me.BeginTranstion()

        If Not Me.execSQL(sql, p) Then
            Me.RollbackTransction()
            Return False
        End If

        'ds hạng mục/ nội dung công việc
        If m.arrContractDetail Is Nothing OrElse m.arrContractDetail.Count = 0 Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Delete from ContractDetails where ContractId=@ContractId"
        If Not Me.execSQL(sql, New SqlParameter("@ContractId", m.ContractId)) Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Insert into ContractDetails(ContractId,ItemId,ItemName,CreatedAt)"
        sql += " values(@ContractId,@ItemId,@ItemName,getdate())"
        For Each it In m.arrContractDetail
            Dim pm(2) As SqlParameter
            pm(0) = New SqlParameter("@ContractId", m.ContractId)
            pm(1) = New SqlParameter("@ItemId", it.ItemId)
            pm(2) = New SqlParameter("@ItemName", it.ItemName)
            If Not Me.execSQL(sql, pm) Then
                Me.RollbackTransction()
                Return False
            End If
        Next

        'nhà thầu phụ
        If m.arrSubContractor Is Nothing OrElse m.arrSubContractor.Count = 0 Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Delete from Contract_SubContractor where ContractId=@ContractId"
        If Not Me.execSQL(sql, New SqlParameter("@ContractId", m.ContractId)) Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Insert into Contract_SubContractor(ContractId,SubContractorId,SubContractorName,CreatedAt)"
        sql += " values(@ContractId,@SubContractorId,@SubContractorName,getdate())"
        For Each it In m.arrSubContractor
            Dim pm(2) As SqlParameter
            pm(0) = New SqlParameter("@ContractId", m.ContractId)
            pm(1) = New SqlParameter("@SubContractorId", it.SubContractorId)
            pm(2) = New SqlParameter("@SubContractorName", it.SubContractorName)
            If Not Me.execSQL(sql, pm) Then
                Me.RollbackTransction()
                Return False
            End If
        Next

        'phụ lục hợp đồng
        If m.arrSubContract Is Nothing OrElse m.arrSubContract.Count = 0 Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Delete from SubContracts where ContractId=@ContractId"
        If Not Me.execSQL(sql, New SqlParameter("@ContractId", m.ContractId)) Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Insert into SubContracts(ContractId,SubContractId,SubContractName,SubContractDeadLine,SubContractValue,CreatedAt)"
        sql += " values(@ContractId,@SubContractId,@SubContractName,@SubContractDeadLine,@SubContractValue,getdate())"
        For Each it In m.arrSubContract
            Dim pm(4) As SqlParameter
            pm(0) = New SqlParameter("@ContractId", m.ContractId)
            pm(1) = New SqlParameter("@SubContractId", it.SubContractId)
            pm(2) = New SqlParameter("@SubContractName", it.SubContractName)
            pm(3) = New SqlParameter("@SubContractDeadLine", it.SubContractDeadLine)
            pm(4) = New SqlParameter("@SubContractValue", it.SubContractValue)
            If Not Me.execSQL(sql, pm) Then
                Me.RollbackTransction()
                Return False
            End If
        Next


        'tập tin đính kèm
        If m.arrFile Is Nothing OrElse m.arrFile.Count = 0 Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Delete from AttachFileContracts where ContractId=@ContractId"
        If Not Me.execSQL(sql, New SqlParameter("@ContractId", m.ContractId)) Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Insert into AttachFileContracts(ContractId,FileId,FileName,FilePath,FileType,CreatedAt)"
        sql += " values(@ContractId,@FileId,@FileName,@FilePath,@FileType,getdate())"
        Dim count = 1
        For Each it In m.arrFile
            Dim pm(4) As SqlParameter
            pm(0) = New SqlParameter("@ContractId", m.ContractId)
            pm(1) = New SqlParameter("@FileId", count)
            pm(2) = New SqlParameter("@FileName", it.FileName)
            pm(3) = New SqlParameter("@FilePath", it.FilePath)
            pm(4) = New SqlParameter("@FileType", it.FileType)
            If Not Me.execSQL(sql, pm) Then
                Me.RollbackTransction()
                Return False
            End If
            count += 1
        Next

        'các đợt thanh toán
        If m.arrPayment Is Nothing OrElse m.arrPayment.Count = 0 Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Delete from ContractPayments where ContractId=@ContractId"
        If Not Me.execSQL(sql, New SqlParameter("@ContractId", m.ContractId)) Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Insert into ContractPayments(ContractId,PaymentId,PaymentName,PaymentTotal,PaymentDate,PaymentStatus)"
        sql += " values(@ContractId,@PaymentId,@PaymentName,@PaymentTotal,@PaymentDate,@PaymentStatus)"
        For Each it In m.arrPayment
            Dim pm(5) As SqlParameter
            pm(0) = New SqlParameter("@ContractId", m.ContractId)
            pm(1) = New SqlParameter("@PaymentId", it.PaymentId)
            pm(2) = New SqlParameter("@PaymentName", it.PaymentName)
            pm(3) = New SqlParameter("@PaymentTotal", it.PaymentTotal)
            pm(4) = New SqlParameter("@PaymentDate", it.PaymentDate)
            pm(5) = New SqlParameter("@PaymentStatus", it.PaymentStatus)
            If Not Me.execSQL(sql, pm) Then
                Me.RollbackTransction()
                Return False
            End If
        Next


        'Lich su hoat dong
        If m.arrHistory Is Nothing OrElse m.arrHistory.Count = 0 Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Insert into ContractHistory(ContractId,UserId,Description,CreatedAt)"
        sql += " values(@ContractId,@UserId,@Description,getdate())"
        For Each it In m.arrHistory
            Dim pm(2) As SqlParameter
            pm(0) = New SqlParameter("@ContractId", m.ContractId)
            pm(1) = New SqlParameter("@UserId", it.UserId)
            pm(2) = New SqlParameter("@Description", it.Description)
            If Not Me.execSQL(sql, pm) Then
                Me.RollbackTransction()
                Return False
            End If
        Next

        Me.CommitTranstion()
        Return True
    End Function

    Public Function isDelete(ByVal ID As String) As Boolean
        Dim isOk As Boolean = True
        'Dim sql As String = "Select count(*)as C from Contracts where ContractId=@ID"

        'Dim p(0) As SqlParameter
        'p(0) = New SqlParameter("@ID", ID)
        'Dim tb As DataTable = Me.getTableSQL(sql, p)
        'If tb Is Nothing Then Return False
        'For Each r As DataRow In tb.Rows
        '    If r("C") > 0 Then
        '        isOk = False
        '        Exit For
        '    End If
        'Next
        Return isOk
    End Function

    Public Function deleteDB(ByVal ContractId As String) As Boolean
        If Not isDelete(ContractId) Then
            Return False
        End If
        Dim sql = "Update Contracts set ContractState='Deleted' where ContractId=@ContractId"
        Return Me.execSQL(sql, New SqlParameter("@ContractId", ContractId))
    End Function

    Public Function getListContracts(ByVal branchId As String) As DataTable
        Return Me.getTableSQL("Exec sp_getListContracts @branchId", New SqlParameter("@branchId", branchId))
    End Function
    Public Function getListContractsByFilter(ByVal branchId As String, ByVal perform As Integer, ByVal length As Integer) As DataTable
        Return Me.getTableSQL("Exec getListContractsByFilter @branchId,@perform,@length", New SqlParameter("@branchId", branchId), New SqlParameter("@perform", perform), New SqlParameter("@length", length))
    End Function

    Public Function getContractDetailById(ByVal ContractId As String, Optional ByVal isGetDetail As Boolean = True) As Model.MContract
        Dim m As New Model.MContract
        Dim sql = "select * from Contracts where ContractId=@ContractId"
        Dim tb = getTableSQL(sql, New SqlParameter("@ContractId", ContractId))
        If Not tb Is Nothing AndAlso tb.Rows.Count > 0 Then
            m.ContractId = IsNull(tb.Rows(0)("ContractId"), "")
            m.ProjectId = IsNull(tb.Rows(0)("ProjectId"), "")
            m.ContractName = IsNull(tb.Rows(0)("ContractName"), "")
            m.ContractState = IsNull(tb.Rows(0)("ContractState"), "")
            m.ContractValue = IsNull(tb.Rows(0)("ContractValue"), 0)
            m.ContractDate = IsNull(tb.Rows(0)("ContractDate"), CDate("2000-1-1"))
            m.ContractDeadLine = IsNull(tb.Rows(0)("ContractDeadLine"), CDate("2000-1-1"))
            m.ContractLevelId = IsNull(tb.Rows(0)("ContractLevelId"), "")
            m.MainContractorId = IsNull(tb.Rows(0)("MainContractorId"), "")
            If isGetDetail Then
                m.arrContractDetail = Me.getContractDetails(m.ContractId)
                m.arrSubContractor = Me.getSubContractors(m.ContractId)
                m.arrSubContract = Me.getSubContracts(m.ContractId)
                m.arrFile = Me.getAttachFiles(m.ContractId)
                m.arrPayment = Me.getContractPayments(m.ContractId)
                m.arrHistory = Me.getContractHistory(m.ContractId)
            End If
        End If
        Return m
    End Function

    Public Function updateStatus(ByVal contractId As String, ByVal status As String, ByVal userId As String) As Boolean
        Me.BeginTranstion()
        Dim m = Me.getContractDetailById(contractId, False)
        Dim sql = "Update Contracts set ContractState=@ContractState where ContractId=@ContractId"
        If Not Me.execSQL(sql, New SqlParameter("@ContractId", contractId)) Then
            Me.RollbackTransction()
            Return False
        End If

        'write log
        Dim desc = "Hiệu chỉnh: " + vbCrLf + "Trạng thái hợp đồng: [" + m.ContractState + "] -> [" + status + "]"
        sql = "Insert into ContractHistory(ContractId,UserId,Description,CreatedAt)"
        sql += " values(@ContractId,@UserId,@Description,getdate())"
        Dim pm(2) As SqlParameter
        pm(0) = New SqlParameter("@ContractId", m.ContractId)
        pm(1) = New SqlParameter("@UserId", userId)
        pm(2) = New SqlParameter("@Description", desc)
        If Not Me.execSQL(sql, pm) Then
            Me.RollbackTransction()
            Return False
        End If

        Me.CommitTranstion()
        Return True
    End Function
#Region "get details"
    Public Function getContractDetails(ByVal contractId As String) As IList(Of Model.MContractDetail)
        Dim arr As IList(Of Model.MContractDetail) = New List(Of Model.MContractDetail)
        Dim sql = "select * from ContractDetails where ContractId=@ContractId order by CreatedAt"
        Dim tb = getTableSQL(sql, New SqlParameter("@ContractId", contractId))
        If tb IsNot Nothing AndAlso tb.Rows.Count > 0 Then
            For Each r As DataRow In tb.Rows
                Dim m As New Model.MContractDetail
                m.ContractId = IsNull(r("ContractId"), "")
                m.ItemId = IsNull(r("ItemId"), "")
                m.ItemName = IsNull(r("ItemName"), "")
                arr.Add(m)
            Next
        End If
        Return arr
    End Function

    Public Function getSubContractors(ByVal contractId As String) As IList(Of Model.MContract_SubContractor)
        Dim arr As IList(Of Model.MContract_SubContractor) = New List(Of Model.MContract_SubContractor)
        Dim sql = "select * from Contract_SubContractor where ContractId=@ContractId order by CreatedAt"
        Dim tb = getTableSQL(sql, New SqlParameter("@ContractId", contractId))
        If tb IsNot Nothing AndAlso tb.Rows.Count > 0 Then
            For Each r As DataRow In tb.Rows
                Dim m As New Model.MContract_SubContractor
                m.ContractId = IsNull(r("ContractId"), "")
                m.SubContractorId = IsNull(r("SubContractorId"), "")
                m.SubContractorName = IsNull(r("SubContractorName"), "")
                arr.Add(m)
            Next
        End If
        Return arr
    End Function

    Public Function getSubContracts(ByVal contractId As String) As IList(Of Model.MSubContract)
        Dim arr As IList(Of Model.MSubContract) = New List(Of Model.MSubContract)
        Dim sql = "select * from SubContracts where ContractId=@ContractId order by CreatedAt"
        Dim tb = getTableSQL(sql, New SqlParameter("@ContractId", contractId))
        If tb IsNot Nothing AndAlso tb.Rows.Count > 0 Then
            For Each r As DataRow In tb.Rows
                Dim m As New Model.MSubContract
                m.ContractId = IsNull(r("ContractId"), "")
                m.SubContractId = IsNull(r("SubContractId"), "")
                m.SubContractName = IsNull(r("SubContractName"), "")
                m.SubContractDeadLine = IsNull(r("SubContractDeadLine"), CDate("2000-1-1"))
                m.SubContractValue = IsNull(r("SubContractValue"), 0)
                arr.Add(m)
            Next
        End If
        Return arr
    End Function

    Public Function getAttachFiles(ByVal contractId As String) As IList(Of Model.MAttachFileContract)
        Dim arr As IList(Of Model.MAttachFileContract) = New List(Of Model.MAttachFileContract)
        Dim sql = "select * from AttachFileContracts where ContractId=@ContractId order by CreatedAt"
        Dim tb = getTableSQL(sql, New SqlParameter("@ContractId", contractId))
        If tb IsNot Nothing AndAlso tb.Rows.Count > 0 Then
            For Each r As DataRow In tb.Rows
                Dim m As New Model.MAttachFileContract
                m.ContractId = IsNull(r("ContractId"), "")
                m.FileId = IsNull(r("FileId"), arr.Count)
                m.FileName = IsNull(r("FileName"), "")
                m.FilePath = IsNull(r("FilePath"), "")
                m.FileType = IsNull(r("FileType"), "")
                arr.Add(m)
            Next
        End If
        Return arr
    End Function

    Public Function getContractPayments(ByVal contractId As String) As IList(Of Model.MContractPayment)
        Dim arr As IList(Of Model.MContractPayment) = New List(Of Model.MContractPayment)
        Dim sql = "select * from ContractPayments where ContractId=@ContractId order by PaymentDate"
        Dim tb = getTableSQL(sql, New SqlParameter("@ContractId", contractId))
        If tb IsNot Nothing AndAlso tb.Rows.Count > 0 Then
            For Each r As DataRow In tb.Rows
                Dim m As New Model.MContractPayment
                m.ContractId = IsNull(r("ContractId"), "")
                m.PaymentId = IsNull(r("PaymentId"), "")
                m.PaymentName = IsNull(r("PaymentName"), "")
                m.PaymentStatus = IsNull(r("PaymentStatus"), "")
                m.PaymentDate = IsNull(r("PaymentDate"), "")
                m.PaymentTotal = IsNull(r("PaymentTotal"), 0)
                arr.Add(m)
            Next
        End If
        Return arr
    End Function

    Private Function getContractHistory(ByVal contractId As String) As IList(Of Model.MContractHistory)
        Dim arr As IList(Of Model.MContractHistory) = New List(Of Model.MContractHistory)
        Dim sql = "select * from ContractHistory where ContractId=@ContractId order by CreatedAt desc"
        Dim tb = getTableSQL(sql, New SqlParameter("@ContractId", contractId))
        If tb IsNot Nothing AndAlso tb.Rows.Count > 0 Then
            For Each r As DataRow In tb.Rows
                Dim m As New Model.MContractHistory
                m.ContractId = IsNull(r("ContractId"), "")
                m.UserId = IsNull(r("UserId"), "")
                m.Description = IsNull(r("Description"), "")
                m.CreatedAt = IsNull(r("CreatedAt"), "")
                arr.Add(m)
            Next
        End If
        Return arr
    End Function
#End Region
End Class
