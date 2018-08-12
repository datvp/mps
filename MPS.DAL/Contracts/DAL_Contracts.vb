Imports System.Data.SqlClient
Imports System.IO

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
    ''' <summary>
    ''' tạo folder by ContractId trên Server để lưu file
    ''' </summary>
    ''' <param name="targetPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function createTargetPath(ByVal targetPath As String) As Boolean
        Try
            If Not Directory.Exists(targetPath) Then
                System.IO.Directory.CreateDirectory(targetPath)
            End If
            Return True
        Catch ex As Exception
            MsgBox("Create target path error." & vbCrLf & ex.Message)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Copy file lên server
    ''' </summary>
    ''' <param name="item"></param>
    ''' <param name="targetPath"></param>
    ''' <returns>a full path of destination File</returns>
    ''' <remarks></remarks>
    Private Function copyFileToServer(ByVal item As Model.MAttachFileContract, ByVal targetPath As String) As String
        Try
            Dim destFile = System.IO.Path.Combine(targetPath, item.FileName)
            'đã copy rồi -> return
            If destFile.Contains(item.FilePath) Then
                Return destFile
            End If

            File.Copy(item.FilePath, destFile, True)
            Return destFile
        Catch ex As Exception
            MsgBox("Process copy file occurs error." & vbCrLf & ex.Message)
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' xóa những file đã xóa trên server khi hiệu chỉnh
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function deleteFileAtServer(ByVal item As Model.MAttachFileContract) As Boolean
        Try
            File.Delete(item.FilePath)
            Return True
        Catch ex As Exception
            MsgBox("Process delete file occurs error." & vbCrLf & ex.Message)
            Return False
        End Try
    End Function
    Public Function updateDB(ByVal m As Model.MContract) As Boolean
        Dim sql = ""
        Dim isEdit = Me.isExist(m.ContractId)

        If isEdit Then
            sql = "Update Contracts set ContractName=@ContractName,ProjectId=@ProjectId,ContractDate=@ContractDate,"
            sql += "ContractValue=@ContractValue,ContractDeadLine=@ContractDeadLine,MainContractorId=@MainContractorId,Note=@Note,"
            sql += "ContractLevelId=@ContractLevelId,UpdatedAt=getdate(),ContractState=@ContractState,SubContracts=@SubContracts,DeadlineExt=@DeadlineExt,"
            sql += "ValueExt=@ValueExt,Refund=@Refund,Paid=@Paid,BranchId=@BranchId where ContractId=@ContractId"
        Else
            sql = "Insert into Contracts(ContractId,ContractName,ProjectId,ContractDate,ContractValue,ContractDeadLine,MainContractorId,ContractLevelId,ContractState,SubContracts,Note,DeadlineExt,CreatedAt,ValueExt,Refund,Paid,BranchId)"
            sql += "values(@ContractId,@ContractName,@ProjectId,@ContractDate,@ContractValue,@ContractDeadLine,@MainContractorId,@ContractLevelId,@ContractState,@SubContracts,@Note,@DeadlineExt,getdate(),@ValueExt,@Refund,@Paid,@BranchId)"
        End If

        If sql = "" Then
            Return False
        End If

        Dim p(15) As SqlParameter
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
        p(13) = New SqlParameter("@Paid", m.Paid)
        p(14) = New SqlParameter("@Refund", m.Refund)
        p(15) = New SqlParameter("@ValueExt", m.ValueExt)

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

        If isEdit Then
            sql = "Delete from ContractDetails where ContractId=@ContractId"
            If Not Me.execSQL(sql, New SqlParameter("@ContractId", m.ContractId)) Then
                Me.RollbackTransction()
                Return False
            End If
        End If

        sql = "Insert into ContractDetails(ContractId,ItemId,ItemName,Status,ItemValue,SubContractorId,Fee,CreatedAt)"
        sql += " values(@ContractId,@ItemId,@ItemName,@Status,@ItemValue,@SubContractorId,@Fee,getdate())"
        For Each it In m.arrContractDetail
            Dim pm(6) As SqlParameter
            pm(0) = New SqlParameter("@ContractId", m.ContractId)
            pm(1) = New SqlParameter("@ItemId", it.ItemId)
            pm(2) = New SqlParameter("@ItemName", it.ItemName)
            pm(3) = New SqlParameter("@Status", it.Status)
            pm(4) = New SqlParameter("@ItemValue", it.ItemValue)
            pm(5) = New SqlParameter("@SubContractorId", it.SubContractorId)
            pm(6) = New SqlParameter("@Fee", it.Fee)
            If Not Me.execSQL(sql, pm) Then
                Me.RollbackTransction()
                Return False
            End If
        Next

        'phụ lục hợp đồng (optional)
        If isEdit Then
            sql = "Delete from SubContracts where ContractId=@ContractId"
            If Not Me.execSQL(sql, New SqlParameter("@ContractId", m.ContractId)) Then
                Me.RollbackTransction()
                Return False
            End If
        End If

        sql = "Insert into SubContracts(ContractId,SubContractId,Note,SubContractDate,SubContractDeadLine,SubContractValue,CreatedAt)"
        sql += " values(@ContractId,@SubContractId,@Note,@SubContractDate,@SubContractDeadLine,@SubContractValue,getdate())"
        For Each it In m.arrSubContract
            Dim pm(5) As SqlParameter
            pm(0) = New SqlParameter("@ContractId", m.ContractId)
            pm(1) = New SqlParameter("@SubContractId", it.SubContractId)
            pm(2) = New SqlParameter("@Note", it.Note)
            pm(3) = New SqlParameter("@SubContractDeadLine", it.SubContractDeadLine)
            pm(4) = New SqlParameter("@SubContractValue", it.SubContractValue)
            pm(5) = New SqlParameter("@SubContractDate", it.SubContractDate)
            If Not Me.execSQL(sql, pm) Then
                Me.RollbackTransction()
                Return False
            End If
        Next

        'tập tin đính kèm (optional)
        If isEdit Then
            sql = "Delete from AttachFileContracts where ContractId=@ContractId"
            If Not Me.execSQL(sql, New SqlParameter("@ContractId", m.ContractId)) Then
                Me.RollbackTransction()
                Return False
            End If
        End If

        If Not Me.createTargetPath(m.PathToSave) Then
            Me.RollbackTransction()
            Return False
        End If

        sql = "Insert into AttachFileContracts(ContractId,FileId,FileName,FilePath,FileType,CreatedAt)"
        sql += " values(@ContractId,@FileId,@FileName,@FilePath,@FileType,getdate())"
        Dim count = 1
        For Each it In m.arrFile
            'copy file from local folder to server folder
            Dim desFile = Me.copyFileToServer(it, m.PathToSave)
            If desFile = "" Then
                Me.RollbackTransction()
                Return False
            End If
            it.FilePath = desFile
            'write path file to database
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

        'xóa các file đã xóa (nếu có)
        If isEdit Then
            For Each it In m.arrFileDeleted
                If Not Me.deleteFileAtServer(it) Then
                    Me.RollbackTransction()
                    Return False
                End If
            Next
        End If

        'các đợt thanh toán thu (optional)
        If isEdit Then
            sql = "Delete from ContractPayments where ContractId=@ContractId"
            If Not Me.execSQL(sql, New SqlParameter("@ContractId", m.ContractId)) Then
                Me.RollbackTransction()
                Return False
            End If
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

        'các đợt hach toan chi (optional)
        If isEdit Then
            sql = "Delete from ContractRefunds where ContractId=@ContractId"
            If Not Me.execSQL(sql, New SqlParameter("@ContractId", m.ContractId)) Then
                Me.RollbackTransction()
                Return False
            End If
        End If

        sql = "Insert into ContractRefunds(ContractId,RefundId,RefundName,RefundTotal,RefundDate,RefundStatus,SubContractorId)"
        sql += " values(@ContractId,@RefundId,@RefundName,@RefundTotal,@RefundDate,@RefundStatus,@SubContractorId)"
        For Each it In m.arrRefund
            Dim pm(6) As SqlParameter
            pm(0) = New SqlParameter("@ContractId", m.ContractId)
            pm(1) = New SqlParameter("@RefundId", it.RefundId)
            pm(2) = New SqlParameter("@RefundName", it.RefundName)
            pm(3) = New SqlParameter("@RefundTotal", it.RefundTotal)
            pm(4) = New SqlParameter("@RefundDate", it.RefundDate)
            pm(5) = New SqlParameter("@RefundStatus", it.RefundStatus)
            pm(6) = New SqlParameter("@SubContractorId", it.SubContractorId)
            If Not Me.execSQL(sql, pm) Then
                Me.RollbackTransction()
                Return False
            End If
        Next

        'Lich su hoat dong (optional)
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

    Public Function getListContracts(ByVal branchId As String, ByVal dateFilter As Integer) As DataTable
        Return Me.getTableSQL("Exec sp_getListContracts @branchId,@dateFilter", New SqlParameter("@branchId", branchId), New SqlParameter("@dateFilter", dateFilter))
    End Function
    Public Function getListAllContractId(ByVal branchId As String) As DataTable
        Return Me.getTableSQL("Exec getListAllContractId @branchId", New SqlParameter("@branchId", branchId))
    End Function
    Public Function getListContractsByFilter(ByVal branchId As String, ByVal perform As Integer, ByVal operatorPerform As String, ByVal length As Integer, ByVal operatorLength As String) As DataTable
        Dim pm(4) As SqlParameter
        pm(0) = New SqlParameter("@branchId", branchId)
        pm(1) = New SqlParameter("@perform", perform)
        pm(2) = New SqlParameter("@operatorPerform", operatorPerform)
        pm(3) = New SqlParameter("@length", length)
        pm(4) = New SqlParameter("@operatorLength", operatorLength)
        Return Me.getTableSQL("Exec getListContractsByFilter @branchId,@perform,@operatorPerform,@length,@operatorLength", pm)
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
                m.arrRefund = Me.getContractRefunds(m.ContractId)
                m.arrHistory = Me.getContractHistory(m.ContractId)
            End If
        End If
        Return m
    End Function

    Public Function updateStatus(ByVal contractId As String, ByVal status As String, ByVal userId As String) As Boolean
        Me.BeginTranstion()
        Dim m = Me.getContractDetailById(contractId, False)
        Dim sql = "Update Contracts set ContractState=@ContractState where ContractId=@ContractId"
        If Not Me.execSQL(sql, New SqlParameter("@ContractId", contractId), New SqlParameter("@ContractState", status)) Then
            Me.RollbackTransction()
            Return False
        End If

        'write log
        Dim desc = "Hiệu chỉnh: Trạng thái hợp đồng: [" + Me.StatusText(m.ContractState) + "] -> [" + Me.StatusText(status) + "]"
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
        Dim sql = "select dt.*, s.SubContractorName from ContractDetails dt"
        sql += " left join SubContractors s on dt.SubContractorId=s.SubContractorId"
        sql += " where dt.ContractId=@ContractId order by dt.CreatedAt"
        Dim tb = getTableSQL(sql, New SqlParameter("@ContractId", contractId))
        If tb IsNot Nothing AndAlso tb.Rows.Count > 0 Then
            For Each r As DataRow In tb.Rows
                Dim m As New Model.MContractDetail
                m.ContractId = IsNull(r("ContractId"), "")
                m.ItemId = IsNull(r("ItemId"), "")
                m.ItemName = IsNull(r("ItemName"), "")
                m.ItemValue = IsNull(r("ItemValue"), 0)
                m.SubContractorId = IsNull(r("SubContractorId"), "")
                m.SubContractorName = IsNull(r("SubContractorName"), "")
                m.Fee = IsNull(r("Fee"), 0)
                m.Status = IsNull(r("Status"), "")
                m.StatusDesc = Me.StatusText(m.Status)
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
                m.Note = IsNull(r("Note"), "")
                m.SubContractDate = IsNull(r("SubContractDate"), CDate("2000-1-1"))
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
                m.StatusDesc = Me.StatusText(m.PaymentStatus)
                m.PaymentDate = IsNull(r("PaymentDate"), CDate("2000-1-1"))
                m.PaymentTotal = IsNull(r("PaymentTotal"), 0)
                arr.Add(m)
            Next
        End If
        Return arr
    End Function
    Public Function getContractRefunds(ByVal contractId As String) As IList(Of Model.MContractRefund)
        Dim arr As IList(Of Model.MContractRefund) = New List(Of Model.MContractRefund)
        Dim sql = "select dt.*, s.SubContractorName from ContractRefunds dt"
        sql += " left join SubContractors s on dt.SubContractorId=s.SubContractorId"
        sql += " where dt.ContractId=@ContractId order by dt.RefundDate"
        Dim tb = getTableSQL(sql, New SqlParameter("@ContractId", contractId))
        If tb IsNot Nothing AndAlso tb.Rows.Count > 0 Then
            For Each r As DataRow In tb.Rows
                Dim m As New Model.MContractRefund
                m.ContractId = IsNull(r("ContractId"), "")
                m.RefundId = IsNull(r("RefundId"), "")
                m.RefundName = IsNull(r("RefundName"), "")
                m.RefundStatus = IsNull(r("RefundStatus"), "")
                m.StatusDesc = Me.StatusText(m.RefundStatus)
                m.RefundDate = IsNull(r("RefundDate"), CDate("2000-1-1"))
                m.RefundTotal = IsNull(r("RefundTotal"), 0)
                m.SubContractorId = IsNull(r("SubContractorId"), "")
                m.SubContractorName = IsNull(r("SubContractorName"), "")
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
