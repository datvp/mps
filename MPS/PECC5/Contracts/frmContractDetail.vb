Imports Infragistics.Win.UltraWinGrid
Imports System.IO

Public Class frmContractDetail
#Region "Declares"
    Private WithEvents b As BLL.BContracts = BLL.BContracts.Instance
    Private clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Private bItem As BLL.BItems = BLL.BItems.Instance
    Private bProject As BLL.BProjects = BLL.BProjects.Instance
    Private bMainContractor As BLL.BMainContractors = BLL.BMainContractors.Instance
    Private bSubContractor As BLL.BSubContractors = BLL.BSubContractors.Instance
    Private mInfo As Model.MContract
    Private Sub b__errorRaise(ByVal messege As String) Handles b._errorRaise
        ShowMsg(messege)
    End Sub
#End Region

#Region "Form Load"
    Private ContractId As String = ""
    Public Overloads Function ShowDialog(ByVal ContractId As String) As String
        Me.ContractId = ContractId
        Me.ShowDialog()
        Return Me.ContractId
    End Function

    Private Sub frmContractDetail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.S Then
                Me.Save()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub frmContractDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        If Me.ContractId = "" Then
            Me.LoadComboBox()
            Me.ClearInfo()
        Else
            Me.LoadInfo(ContractId)
        End If
        ModMain.HideProcess()
    End Sub
#End Region

#Region "Subs"
    Dim isAddProject As Boolean
    Private Sub LoadProjects()
        Dim tbProject = bProject.getListProjects(ModMain.m_BranchId)
        Dim m = ModMain.getPermitFunc(ModMain.m_UIDLogin, 24)
        isAddProject = m.A
        If m.A Then
            ModMain.AddNewRow(tbProject)
        End If
        cboProject.ValueMember = "ProjectId"
        cboProject.DisplayMember = "ProjectName"
        cboProject.DataSource = tbProject
    End Sub
    Dim isAddMainContractor As Boolean
    Private Sub LoadbMainContractors()
        Dim tb = bMainContractor.getListMainContractors()
        Dim m = ModMain.getPermitFunc(ModMain.m_UIDLogin, 9)
        isAddMainContractor = m.A
        If m.A Then
            ModMain.AddNewRow(tb)
        End If
        cboMainContractor.ValueMember = "Id"
        cboMainContractor.DisplayMember = "Company"
        cboMainContractor.DataSource = tb
    End Sub
    Private Sub LoadComboBox()
        LoadProjects()
        LoadbMainContractors()
    End Sub
    Private Sub ClearInfo()
        txtContractId.Clear()
        txtContractId.Enabled = True
        txtContractName.Clear()
        txtContractValue.Text = "0"
        cboProject.Value = Nothing
        cboMainContractor.Value = Nothing
        grdItems.DataSource = New List(Of Model.MContractDetail)
        grdSubContracts.DataSource = New List(Of Model.MSubContract)
        grdFiles.DataSource = New List(Of Model.MAttachFileContract)
        grdPayment.DataSource = New List(Of Model.MContractPayment)
        grdRefund.DataSource = New List(Of Model.MContractRefund)
        grdHistory.DataSource = New List(Of Model.MContractHistory)
        txtNote.Clear()
        Me.SumTotal()
    End Sub
    Private Sub LoadInfo(ByVal ContractId As String)
        mInfo = b.getContractDetailById(ContractId)
        If mInfo.ContractId = "" Then Exit Sub
        Me.LoadComboBox()
        txtContractId.Text = mInfo.ContractId
        txtContractId.Enabled = False
        txtContractName.Text = mInfo.ContractName
        dtCreateDate.Value = mInfo.ContractDate
        dtExpireDate.Value = mInfo.ContractDeadLine
        txtContractValue.Text = Format(mInfo.ContractValue, ModMain.m_strFormatCur)
        cboProject.Value = mInfo.ProjectId
        cboMainContractor.Value = mInfo.MainContractorId
        lblStatus.Text = ModMain.StatusText(mInfo.ContractState)
        txtNote.Text = mInfo.Note

        grdItems.DataSource = mInfo.arrContractDetail
        grdSubContracts.DataSource = mInfo.arrSubContract
        grdFiles.DataSource = mInfo.arrFile
        grdPayment.DataSource = mInfo.arrPayment
        grdRefund.DataSource = mInfo.arrRefund
        grdHistory.DataSource = mInfo.arrHistory
        Me.SumTotal()
    End Sub
    Private Function setInfo() As Model.MContract
        Dim m As New Model.MContract
        m.BranchId = ModMain.m_BranchId
        m.ContractId = txtContractId.Text
        m.ContractName = txtContractName.Text
        m.ContractDate = dtCreateDate.Value
        m.ContractDeadLine = dtExpireDate.Value
        m.DeadlineExt = dtDeadlineExt.Value
        If DateDiffM("day", m.ContractDeadLine, m.DeadlineExt) < 0 Then
            m.DeadlineExt = m.ContractDeadLine
        End If
        m.ContractValue = CDbl(txtContractValue.Text)
        If cboProject.Value IsNot Nothing Then
            m.ProjectId = cboProject.Value
        End If
        If cboMainContractor.Value IsNot Nothing Then
            m.MainContractorId = cboMainContractor.Value
        End If
        m.arrContractDetail = grdItems.DataSource
        m.arrSubContract = grdSubContracts.DataSource
        m.arrFile = grdFiles.DataSource
        m.arrPayment = grdPayment.DataSource
        m.arrRefund = grdRefund.DataSource
        m.Note = txtNote.Text
        For Each it In m.arrSubContract
            If m.SubContracts = "" Then
                m.SubContracts = it.SubContractId
            Else
                m.SubContracts += " | " + it.SubContractId
            End If
            m.ValueExt += it.SubContractValue
        Next
        For Each it In m.arrPayment
            If it.PaymentStatus = Statuses.Paid Then
                m.Paid += it.PaymentTotal
            End If
        Next
        For Each it In m.arrRefund
            If it.RefundStatus = Statuses.Paid Then
                m.Refund += it.RefundTotal
            End If
        Next
        m.PathToSave = Path.Combine(mbc.PathToSave, m.ContractId)
        m.arrFileDeleted = Me.arrFileDeleted

        If mInfo IsNot Nothing Then ' edit
            m.ContractState = mInfo.ContractState
        Else 'add
            m.ContractState = Statuses.Signed
        End If
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MContract) As Boolean
        If m.ContractName = "" Then
            ShowMsg("Nhập tên hợp đồng")
            txtContractName.Focus()
            Return False
        End If

        If m.ContractId = "" Then
            ShowMsg("Nhập số hiệu hợp đồng")
            txtContractId.Focus()
            Return False
        End If

        'Add new -> check duplicate id
        If Me.ContractId = "" Then
            If b.isExist(m.ContractId) Then
                ShowMsg("Mã bị trùng, vui lòng nhập mã khác.")
                txtContractId.Focus()
                Return False
            End If
        End If

        If DateDiffM("day", m.ContractDate, m.ContractDeadLine) <= 0 Then
            ShowMsg("Ngày hết hạn thêm phải lớn hơn Ngày ký.")
            dtExpireDate.Focus()
            Return False
        End If

        If m.ProjectId = "" Then
            ShowMsg("Chọn dự án")
            cboProject.Focus()
            Return False
        End If

        If m.MainContractorId = "" Then
            ShowMsg("Chọn nhà thầu chính")
            cboMainContractor.Focus()
            Return False
        End If

        If txtContractValue.Text.Trim = "" OrElse CDbl(txtContractValue.Text) = 0 Then
            ShowMsg("Nhập giá trị hợp đồng")
            txtContractValue.Focus()
            Return False
        End If

        If m.arrContractDetail.Count = 0 Then
            ShowMsg("Chọn hạng mục")
            lnkAddItem.Focus()
            Return False
        End If

        If Not checkInvalidFeeByItem() Then
            ShowMsg("Tổng chi phí cho các hạng mục vượt quá Giá trị hợp đồng.")
            Return False
        End If

        'If mInfo IsNot Nothing Then ' edit
        '    If mInfo.ContractState <> Statuses.WaitingForApprove Then
        '        ShowMsg("Hợp đồng đang ở tình trạng: [" + StatusText(mInfo.ContractState) + "], không thể chỉnh sửa.")
        '        Return False
        '    End If
        'End If

        Return True
    End Function
    Private Function SetContractHistory(ByVal m As Model.MContract) As Boolean
        'compare before vs after to write log into history
        If mInfo IsNot Nothing Then ' edit
            Dim desc As String = ""
            If m.ContractName <> mInfo.ContractName Then
                desc += vbCrLf & "Tên hợp đồng: [" + mInfo.ContractName + "] -> [" + m.ContractName + "]"
            End If
            If m.ProjectId <> mInfo.ProjectId Then
                desc += vbCrLf & "Mã dự án: [" + mInfo.ProjectId + "] -> [" + m.ProjectId + "]"
            End If
            If m.ContractDate <> mInfo.ContractDate Then
                desc += vbCrLf & "Ngày ký: [" + mInfo.ContractDate + "] -> [" + m.ContractDate + "]"
            End If
            If m.ContractDeadLine <> mInfo.ContractDeadLine Then
                desc += vbCrLf & "Ngày hết hạn: [" + mInfo.ContractDeadLine + "] -> [" + m.ContractDeadLine + "]"
            End If
            If m.ContractValue <> mInfo.ContractValue Then
                desc += vbCrLf & "Giá trị hợp đồng: [" + Format(mInfo.ContractValue, ModMain.m_strFormatCur) + "] -> [" + Format(m.ContractValue, ModMain.m_strFormatCur) + "]"
            End If
            If m.ContractLevelId <> mInfo.ContractLevelId Then
                desc += vbCrLf & "Phân cấp hợp đồng: [" + mInfo.ContractLevelId + "] -> [" + m.ContractLevelId + "]"
            End If
            If m.MainContractorId <> mInfo.MainContractorId Then
                desc += vbCrLf & "Nhà thầu chính: [" + mInfo.MainContractorId + "] -> [" + m.MainContractorId + "]"
            End If
            If m.Note <> mInfo.Note Then
                desc += vbCrLf & "Ghi chú: [" + mInfo.Note + "] -> [" + m.Note + "]"
            End If

            'hang muc
            mInfo.arrContractDetail = b.getContractDetails(mInfo.ContractId)
            If m.arrContractDetail.Count > mInfo.arrContractDetail.Count Then
                For Each it In m.arrContractDetail
                    Dim foundItem = Me.findItem(it, mInfo.arrContractDetail, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thêm hạng mục: [" + it.ItemName + "]"
                    End If
                Next
            ElseIf m.arrContractDetail.Count < mInfo.arrContractDetail.Count Then
                For Each it In mInfo.arrContractDetail
                    Dim foundItem = Me.findItem(it, m.arrContractDetail, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Xóa hạng mục: [" + it.ItemName + "]"
                    End If
                Next
            Else
                For Each it In m.arrContractDetail
                    Dim foundItem = Me.findItem(it, mInfo.arrContractDetail, False)

                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thay đổi hạng mục: -> [" + it.ItemName + "]"
                    Else 'found
                        If it.ItemName <> foundItem.ItemName _
                            OrElse it.Status <> foundItem.Status _
                            OrElse it.ItemValue <> foundItem.ItemValue _
                            OrElse it.SubContractorId <> foundItem.SubContractorId _
                            OrElse it.Fee <> foundItem.Fee _
                        Then
                            desc += vbCrLf & "Sửa hạng mục [" + it.ItemName + "]: "
                            If it.ItemName <> foundItem.ItemName Then
                                desc += vbCrLf & " - Tên: [" + foundItem.ItemName + "] -> [" + it.ItemName + "]"
                            End If
                            If it.Status <> foundItem.Status Then
                                desc += vbCrLf & " - Trạng thái: [" + StatusText(foundItem.Status) + "] -> [" + StatusText(it.Status) + "]"
                            End If
                            If it.ItemValue <> foundItem.ItemValue Then
                                desc += vbCrLf & " - Tổng chi phí: [" + Format(foundItem.ItemValue, ModMain.m_strFormatCur) + "] -> [" + Format(it.ItemValue, ModMain.m_strFormatCur) + "]"
                            End If
                            If it.SubContractorId <> foundItem.SubContractorId Then
                                desc += vbCrLf & " - Nhà thầu phụ: [" + foundItem.SubContractorName + "] -> [" + it.SubContractorName + "]"
                            End If
                            If it.Fee <> foundItem.Fee Then
                                desc += vbCrLf & " - Chi phí thuê nhà thầu: [" + Format(foundItem.Fee, ModMain.m_strFormatCur) + "] -> [" + Format(it.Fee, ModMain.m_strFormatCur) + "]"
                            End If
                        End If
                    End If
                Next
            End If

            'phu luc hop dong
            mInfo.arrSubContract = b.getSubContracts(mInfo.ContractId)
            If m.arrSubContract.Count > mInfo.arrSubContract.Count Then
                For Each it In m.arrSubContract
                    Dim foundItem = Me.findSubContract(it, mInfo.arrSubContract, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thêm phụ lục hợp đồng: [" + it.SubContractId + "]"
                    End If
                Next
            ElseIf m.arrSubContract.Count < mInfo.arrSubContract.Count Then
                For Each it In mInfo.arrSubContract
                    Dim foundItem = Me.findSubContract(it, m.arrSubContract, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Xóa phụ lục hợp đồng: [" + it.SubContractId + "]"
                    End If
                Next
            Else
                For Each it In m.arrSubContract
                    Dim foundItem = Me.findSubContract(it, mInfo.arrSubContract, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thay đổi phụ lục hợp đồng: -> [" + it.SubContractId + "]"
                    Else 'found
                        If it.Note <> foundItem.Note _
                            OrElse it.SubContractDate <> foundItem.SubContractDate _
                            OrElse it.SubContractValue <> foundItem.SubContractValue _
                            OrElse it.SubContractDeadLine <> foundItem.SubContractDeadLine _
                        Then
                            desc += vbCrLf & "Sửa phụ lục hợp đồng [" + it.SubContractId + "]: "
                            If it.Note <> foundItem.Note Then
                                desc += vbCrLf & " - Nội dung: [" + foundItem.Note + "] -> [" + it.Note + "]"
                            End If
                            If it.SubContractDate <> foundItem.SubContractDate Then
                                desc += vbCrLf & " - Ngày gia hạn: [" + foundItem.SubContractDate.ToString("dd/MM/yyyy") + "] -> [" + it.SubContractDate.ToString("dd/MM/yyyy") + "]"
                            End If
                            If it.SubContractValue <> foundItem.SubContractValue Then
                                desc += vbCrLf & " - Thay đổi giá trị: [" + foundItem.SubContractValue + "] -> [" + it.SubContractValue + "]"
                            End If
                            If it.SubContractDeadLine <> foundItem.SubContractDeadLine Then
                                desc += vbCrLf & " - Thay đổi thời gian: [" + foundItem.SubContractDeadLine.ToString("dd/MM/yyyy") + "] -> [" + it.SubContractDeadLine.ToString("dd/MM/yyyy") + "]"
                            End If
                        End If
                    End If
                Next
            End If

            'tập tin đính kèm
            mInfo.arrFile = b.getAttachFiles(mInfo.ContractId)
            If m.arrFile.Count > mInfo.arrFile.Count Then
                For Each it In m.arrFile
                    Dim foundItem = Me.findAttachFile(it.FilePath, mInfo.arrFile)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thêm file: [" + it.FileName + "]"
                    End If
                Next
            ElseIf m.arrFile.Count < mInfo.arrFile.Count Then
                For Each it In mInfo.arrFile
                    Dim foundItem = Me.findAttachFile(it.FilePath, m.arrFile)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Xóa file: [" + it.FileName + "]"
                    End If
                Next
            Else
                For Each it In m.arrFile
                    Dim foundItem = Me.findAttachFile(it.FilePath, mInfo.arrFile)
                    If foundItem Is Nothing Then
                        desc += "Thay đổi file: -> [" + it.FileName + "]"
                    End If
                Next
            End If

            'các đợt thanh toán thu
            mInfo.arrPayment = b.getContractPayments(mInfo.ContractId)
            If m.arrPayment.Count > mInfo.arrPayment.Count Then
                For Each it In m.arrPayment
                    Dim foundItem = Me.findPayment(it, mInfo.arrPayment, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thêm đợt thanh toán thu: [" + it.PaymentName + "]"
                    End If
                Next
            ElseIf m.arrPayment.Count < mInfo.arrPayment.Count Then
                For Each it In mInfo.arrPayment
                    Dim foundItem = Me.findPayment(it, m.arrPayment, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Xóa đợt thanh toán thu: [" + it.PaymentName + "]"
                    End If
                Next
            Else
                For Each it In m.arrPayment
                    Dim foundItem = Me.findPayment(it, mInfo.arrPayment, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thay đổi đợt nghiệm thu: -> [" + it.PaymentName + "]"
                    Else 'found
                        If it.PaymentName <> foundItem.PaymentName _
                            OrElse it.PaymentTotal <> foundItem.PaymentTotal _
                            OrElse it.PaymentDate <> foundItem.PaymentDate _
                            OrElse it.PaymentStatus <> foundItem.PaymentStatus _
                        Then
                            desc += vbCrLf & "Sửa đợt nghiệm thu [" + it.PaymentName + "]: "
                            If it.PaymentName <> foundItem.PaymentName Then
                                desc += vbCrLf & " - Tên đợt nghiệm thu: [" + foundItem.PaymentName + "] -> [" + it.PaymentName + "]"
                            End If
                            If it.PaymentTotal <> foundItem.PaymentTotal Then
                                desc += vbCrLf & " - Giá trị nghiệm thu: [" + Format(foundItem.PaymentTotal, ModMain.m_strFormatCur) + "] -> [" + Format(it.PaymentTotal, ModMain.m_strFormatCur) + "]"
                            End If
                            If it.PaymentDate <> foundItem.PaymentDate Then
                                desc += vbCrLf & " - Ngày nghiệm thu: [" + foundItem.PaymentDate.ToString("dd/MM/yyyy") + "] -> [" + it.PaymentDate.ToString("dd/MM/yyyy") + "]"
                            End If
                            If it.PaymentStatus <> foundItem.PaymentStatus Then
                                desc += vbCrLf & " - Trạng thái nghiệm thu: [" + StatusText(foundItem.PaymentStatus) + "] -> [" + StatusText(it.PaymentStatus) + "]"
                            End If
                        End If
                    End If

                    'check các hạng mục nghiệm thu
                    Dim arrPaid = b.getContractPaymentDetails(mInfo.ContractId, it.PaymentId)
                    If it.arrPaidItem.Count <> arrPaid.Count Then
                        desc += vbCrLf & " - Thay đổi các hạng mục của đợt nghiệm thu: [" + it.PaymentName + "]"
                    End If
                Next
            End If

            'các đợt hạch toán chi
            mInfo.arrRefund = b.getContractRefunds(mInfo.ContractId)
            If m.arrRefund.Count > mInfo.arrRefund.Count Then
                For Each it In m.arrRefund
                    Dim foundItem = Me.findRefund(it, mInfo.arrRefund, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thêm đợt hạch toán chi: [" + it.RefundName + "]"
                    End If
                Next
            ElseIf m.arrRefund.Count < mInfo.arrRefund.Count Then
                For Each it In mInfo.arrRefund
                    Dim foundItem = Me.findRefund(it, m.arrRefund, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Xóa đợt hạch toán chi: [" + it.RefundName + "]"
                    End If
                Next
            Else
                For Each it In m.arrRefund
                    Dim foundItem = Me.findRefund(it, mInfo.arrRefund, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thay đổi đợt hạch toán chi: -> [" + it.RefundName + "]"
                    Else 'found
                        If it.RefundName <> foundItem.RefundName _
                            OrElse it.RefundTotal <> foundItem.RefundTotal _
                            OrElse it.SubContractorId <> foundItem.SubContractorId _
                            OrElse it.RefundDate <> foundItem.RefundDate _
                            OrElse it.RefundStatus <> foundItem.RefundStatus _
                        Then
                            desc += vbCrLf & "Sửa đợt hạch toán chi [" + it.RefundName + "]: "
                            If it.RefundName <> foundItem.RefundName Then
                                desc += vbCrLf & " - Tên đợt chi: [" + foundItem.RefundName + "] -> [" + it.RefundName + "]"
                            End If
                            If it.RefundTotal <> foundItem.RefundTotal Then
                                desc += vbCrLf & " - Số tiền phải chi: [" + Format(foundItem.RefundTotal, ModMain.m_strFormatCur) + "] -> [" + Format(it.RefundTotal, ModMain.m_strFormatCur) + "]"
                            End If
                            If it.RefundDate <> foundItem.RefundDate Then
                                desc += vbCrLf & " - Ngày chi dự kiến: [" + foundItem.RefundDate.ToString("dd/MM/yyyy") + "] -> [" + it.RefundDate.ToString("dd/MM/yyyy") + "]"
                            End If
                            If it.RefundStatus <> foundItem.RefundStatus Then
                                desc += vbCrLf & " - Trạng thái: [" + StatusText(foundItem.RefundStatus) + "] -> [" + StatusText(it.RefundStatus) + "]"
                            End If
                            If it.SubContractorId <> foundItem.SubContractorId Then
                                desc += vbCrLf & " - Nhà thầu phụ: [" + foundItem.SubContractorName + "] -> [" + it.SubContractorName + "]"
                            End If
                        End If
                    End If
                Next
            End If
            'if no change everything -> Save ~ Close -> exit form
            If desc = "" Then
                Return False
            End If

            desc = "Hiệu chỉnh: " & desc
            Dim history As New Model.MContractHistory
            history.UserId = ModMain.m_UIDLogin
            history.Description = desc
            m.arrHistory.Add(history)
        Else ' add
            Dim history As New Model.MContractHistory
            history.UserId = ModMain.m_UIDLogin
            history.Description = "Thêm mới hợp đồng [" + m.ContractId + "]"
            m.arrHistory.Add(history)
        End If

        Return True
    End Function
    Private Sub SumTotal()
        If txtTotalValue.Text = "" Then Exit Sub
        Dim total As Double = CDbl(txtContractValue.Text)
        Dim arr As IList(Of Model.MSubContract) = grdSubContracts.DataSource
        If arr IsNot Nothing Then
            Dim extentValue As Double = 0
            Dim extentDate As Date = dtExpireDate.Value
            For Each it In arr
                extentValue += it.SubContractValue
                If DateDiffM("day", extentDate, it.SubContractDeadLine) > 0 Then
                    extentDate = it.SubContractDeadLine
                End If
            Next
            txtExtentValue.Text = Format(extentValue, ModMain.m_strFormatCur)
            total += extentValue
            dtDeadlineExt.Value = extentDate
        End If
        txtTotalValue.Text = Format(total, ModMain.m_strFormatCur)
        lblConvertMoney.Text = ModMain.convertMoney(total)

    End Sub
    Private Function checkInvalidFeeByItem() As Boolean
        Dim total = CDbl(txtTotalValue.Text)
        Dim sumFee As Double = 0
        Dim arr As IList(Of Model.MContractDetail) = grdItems.DataSource
        If arr IsNot Nothing Then
            For Each it In arr
                sumFee += it.ItemValue
            Next
        End If
        Return sumFee <= total
    End Function
    Private Sub Save()
        Dim m = Me.setInfo()
        If Not Me.CheckOK(m) Then Exit Sub

        If Not Me.SetContractHistory(m) Then
            Me.Close()
            Exit Sub
        End If

        If b.updateDB(m) Then
            If Me.ContractId <> "" Then
                Me.Close()
            Else
                Me.ContractId = m.ContractId
                Me.ClearInfo()
            End If
            ShowMsgInfo(m_MsgSaveSuccess)
        Else
            ShowMsg(m_SaveDataError)
        End If
    End Sub

    Private Sub showItemDetail(ByVal item As Model.MContractDetail)
        Dim frm As New frmContractItemDetail
        item = frm.ShowDialog(item)
        If item IsNot Nothing Then
            Dim arr As IList(Of Model.MContractDetail) = grdItems.DataSource
            If arr IsNot Nothing Then
                Dim foundItem = Me.findItem(item, arr)
                If foundItem Is Nothing Then
                    arr.Insert(arr.Count, item)
                End If
                grdItems.Rows.Refresh(RefreshRow.RefreshDisplay)
            End If
        End If
    End Sub
    Private Sub showSubContractDetail(ByVal item As Model.MSubContract)
        Dim frm As New frmSubContractDetail
        item = frm.ShowDialog(item, dtExpireDate.Value)
        If item IsNot Nothing Then
            Dim arr As IList(Of Model.MSubContract) = grdSubContracts.DataSource
            If arr IsNot Nothing Then
                Dim found = Me.findSubContract(item, arr)
                If found Is Nothing Then
                    Dim m As New Model.MSubContract
                    m.SubContractId = item.SubContractId
                    m.Note = item.Note
                    m.SubContractValue = item.SubContractValue
                    m.SubContractDeadLine = item.SubContractDeadLine
                    m.SubContractDate = item.SubContractDate
                    arr.Insert(arr.Count, m)
                End If
                grdSubContracts.Rows.Refresh(RefreshRow.RefreshDisplay)
                Me.SumTotal()
            End If
        End If
    End Sub
    Private Sub showPaymentDetail(ByVal item As Model.MContractPayment)
        Dim frm As New frmPaymentDetail
        item = frm.ShowDialog(item, dtCreateDate.Value)
        If item IsNot Nothing Then
            Dim arr As IList(Of Model.MContractPayment) = grdPayment.DataSource
            If arr IsNot Nothing Then
                Dim found = Me.findPayment(item, arr)
                If found Is Nothing Then
                    Dim m As New Model.MContractPayment
                    m.PaymentId = item.PaymentId
                    m.PaymentName = item.PaymentName
                    m.PaymentTotal = item.PaymentTotal
                    m.PaymentDate = item.PaymentDate
                    m.PaymentStatus = item.PaymentStatus
                    m.StatusDesc = StatusText(item.PaymentStatus)
                    m.arrPaidItem = item.arrPaidItem
                    arr.Insert(arr.Count, m)
                End If
                grdPayment.Rows.Refresh(RefreshRow.RefreshDisplay)
            End If
        End If
    End Sub
    Private Sub showRefundDetail(ByVal item As Model.MContractRefund)
        Dim arrSub As IList(Of Model.MContractDetail) = grdItems.DataSource
        Dim frm As New frmRefundDetail
        item = frm.ShowDialog(item, dtCreateDate.Value, arrSub)
        If item IsNot Nothing Then
            Dim arr As IList(Of Model.MContractRefund) = grdRefund.DataSource
            If arr IsNot Nothing Then
                Dim found = Me.findRefund(item, arr)
                If found Is Nothing Then
                    Dim m As New Model.MContractRefund
                    m.RefundId = item.RefundId
                    m.RefundName = item.RefundName
                    m.RefundTotal = item.RefundTotal
                    m.RefundDate = item.RefundDate
                    m.RefundStatus = item.RefundStatus
                    m.StatusDesc = StatusText(item.RefundStatus)
                    m.SubContractorId = item.SubContractorId
                    m.SubContractorName = item.SubContractorName
                    arr.Insert(arr.Count, m)
                End If
                grdRefund.Rows.Refresh(RefreshRow.RefreshDisplay)
            End If
        End If
    End Sub
#End Region

#Region "Combobox InitializeLayout"

    Private Sub cboProject_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProject.AfterCloseUp
        Dim cbo As UltraCombo = sender
        ModMain.FilterOwnerCombo_CloseUp(cbo, "")
        If cbo.Value Is Nothing Then Exit Sub
        If cbo.Value = "" Then
            Dim frm As New frmProjectDetail
            Dim result = frm.ShowDialog("")
            If result <> "" Then
                Me.LoadProjects()
                cboProject.Value = result
            Else
                cboProject.Value = Nothing
            End If
        End If
    End Sub
    Private Sub cboProject_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboProject.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("ProjectName").Hidden = False

        If isAddProject AndAlso cboProject.Rows.Count > 0 Then
            With cboProject.Rows(cboProject.Rows.Count - 1)
                .Appearance.BackColor = ModMain.m_AddColor
                .Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            End With
        End If
    End Sub

    Private Sub cboMainContractor_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMainContractor.AfterCloseUp
        Dim cbo As UltraCombo = sender
        ModMain.FilterOwnerCombo_CloseUp(cbo, "")
        If cbo.Value Is Nothing Then Exit Sub
        If cbo.Value = "" Then
            Dim frm As New frmMainContractorDetail
            Dim result = frm.ShowDialog("")
            If result <> "" Then
                Me.LoadbMainContractors()
                cboMainContractor.Value = result
            Else
                cboMainContractor.Value = Nothing
            End If
        End If
    End Sub
    Private Sub cboMainContractor_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboMainContractor.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("Company").Hidden = False
        If isAddMainContractor AndAlso cboMainContractor.Rows.Count > 0 Then
            With cboMainContractor.Rows(cboMainContractor.Rows.Count - 1)
                .Appearance.BackColor = ModMain.m_AddColor
                .Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            End With
        End If
    End Sub
    Private Sub cboContractLevel_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("ConstructionLevelName").Hidden = False
    End Sub
#End Region

#Region "Buttons"
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.Save()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
#End Region

#Region "txtContractValue"
    Private Sub txtContractValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContractValue.KeyPress
        ModMain.UltraTextBox_KeyPress(sender, e)
    End Sub

    Private Sub txtContractValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContractValue.Leave
        ModMain.UltraTextBox_LostFocus(sender)
    End Sub

    Private Sub txtContractValue_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContractValue.ValueChanged
        ModMain.UltraTextBox_ValueChanged(sender)
        Me.SumTotal()
    End Sub
#End Region

#Region "Find item into array"
    Private Function findItem(ByVal item As Model.MContractDetail, ByVal arr As IList(Of Model.MContractDetail), Optional ByVal isUpdate As Boolean = True) As Model.MContractDetail
        Dim foundItem As Model.MContractDetail = Nothing
        Dim i = 0
        While i < arr.Count And foundItem Is Nothing
            If arr.Item(i).ItemId = item.ItemId Then
                If isUpdate Then
                    arr.Item(i).ItemValue = item.ItemValue
                    arr.Item(i).SubContractorId = item.SubContractorId
                    arr.Item(i).SubContractorName = item.SubContractorName
                    arr.Item(i).Status = item.Status
                    arr.Item(i).StatusDesc = StatusText(item.Status)
                    arr.Item(i).Fee = item.Fee
                End If
                foundItem = arr.Item(i)
            End If
            i = i + 1
        End While

        Return foundItem
    End Function

    Private Function findSubContractor(ByVal subContractorId As String, ByVal arr As IList(Of Model.MContract_SubContractor)) As Model.MContract_SubContractor
        Dim found As Model.MContract_SubContractor = Nothing
        Dim i = 0
        While i < arr.Count And found Is Nothing
            If arr.Item(i).SubContractorId = subContractorId Then
                found = arr.Item(i)
            End If
            i = i + 1
        End While

        Return found
    End Function

    Private Function findSubContract(ByVal item As Model.MSubContract, ByVal arr As IList(Of Model.MSubContract), Optional ByVal isUpdate As Boolean = True) As Model.MSubContract
        Dim found As Model.MSubContract = Nothing
        Dim i = 0
        While i < arr.Count And found Is Nothing
            If arr.Item(i).SubContractId = item.SubContractId Then
                If isUpdate Then
                    arr.Item(i).Note = item.Note
                    arr.Item(i).SubContractValue = item.SubContractValue
                    arr.Item(i).SubContractDeadLine = item.SubContractDeadLine
                    arr.Item(i).SubContractDate = item.SubContractDate
                End If
                found = arr.Item(i)
            End If
            i = i + 1
        End While

        Return found
    End Function

    Private Function findAttachFile(ByVal filePath As String, ByVal arr As IList(Of Model.MAttachFileContract)) As Model.MAttachFileContract
        Dim found As Model.MAttachFileContract = Nothing
        Dim i = 0
        While i < arr.Count And found Is Nothing
            If arr.Item(i).FilePath = filePath Then
                found = arr.Item(i)
            End If
            i = i + 1
        End While

        Return found
    End Function

    Private Function findPayment(ByVal item As Model.MContractPayment, ByVal arr As IList(Of Model.MContractPayment), Optional ByVal isUpdate As Boolean = True) As Model.MContractPayment
        Dim found As Model.MContractPayment = Nothing
        Dim i = 0
        While i < arr.Count And found Is Nothing
            If arr.Item(i).PaymentId = item.PaymentId Then
                If isUpdate Then
                    arr.Item(i).PaymentName = item.PaymentName
                    arr.Item(i).PaymentTotal = item.PaymentTotal
                    arr.Item(i).PaymentDate = item.PaymentDate
                    arr.Item(i).PaymentStatus = item.PaymentStatus
                    arr.Item(i).StatusDesc = StatusText(item.PaymentStatus)
                End If
                found = arr.Item(i)
            End If
            i = i + 1
        End While

        Return found
    End Function

    Private Function findRefund(ByVal item As Model.MContractRefund, ByVal arr As IList(Of Model.MContractRefund), Optional ByVal isUpdate As Boolean = True) As Model.MContractRefund
        Dim found As Model.MContractRefund = Nothing
        Dim i = 0
        While i < arr.Count And found Is Nothing
            If arr.Item(i).RefundId = item.RefundId Then
                If isUpdate Then
                    arr.Item(i).RefundName = item.RefundName
                    arr.Item(i).RefundTotal = item.RefundTotal
                    arr.Item(i).RefundDate = item.RefundDate
                    arr.Item(i).RefundStatus = item.RefundStatus
                    arr.Item(i).StatusDesc = StatusText(item.RefundStatus)
                    arr.Item(i).SubContractorId = item.SubContractorId
                    arr.Item(i).SubContractorName = item.SubContractorName
                End If
                found = arr.Item(i)
            End If
            i = i + 1
        End While

        Return found
    End Function
#End Region

#Region "Links"
    Private Sub lnkAddItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddItem.Click
        Me.showItemDetail(Nothing)
    End Sub

    Private Sub lnkAddSubContract_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddSubContract.Click
        Me.showSubContractDetail(Nothing)
    End Sub

    Private Sub lnkAddFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddFile.Click
        Dim fd As New OpenFileDialog()

        fd.Title = "Select Any Files Dialog"
        'fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.Multiselect = True
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Dim s = fd.FileNames
            Dim arr As IList(Of Model.MAttachFileContract) = grdFiles.DataSource
            If arr IsNot Nothing Then

                For i = 0 To s.Length - 1
                    Dim path = s(i).ToString
                    Dim fileName = System.IO.Path.GetFileName(path)
                    Dim ext = System.IO.Path.GetExtension(path)

                    Dim found = Me.findAttachFile(path, arr)
                    If found Is Nothing Then
                        Dim item As New Model.MAttachFileContract
                        item.FileId = arr.Count + 1
                        item.FileName = fileName
                        item.FileType = ext
                        item.FilePath = path
                        arr.Insert(arr.Count, item)
                    End If
                Next
                grdFiles.Rows.Refresh(RefreshRow.RefreshDisplay)
            End If

        End If
    End Sub

    Private Sub lnkAddPayment_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAddPayment.LinkClicked
        Me.showPaymentDetail(Nothing)
    End Sub

    Private Sub lnkAddRefund_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAddRefund.LinkClicked
        Me.showRefundDetail(Nothing)
    End Sub
#End Region

#Region "Grids"
    Dim fGridIem As Boolean = False

    Private Sub grdItems_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdItems.ClickCellButton
        Dim r As UltraGridRow = grdItems.ActiveRow
        If r IsNot Nothing Then
            Dim arr As IList(Of Model.MContractDetail) = grdItems.DataSource
            If arr IsNot Nothing Then
                Dim item = arr.Item(r.Index)
                If item Is Nothing Then Exit Sub
                arr.Remove(item)
                grdItems.Rows.Refresh(RefreshRow.RefreshDisplay)
            End If
        End If
    End Sub

    Private Sub grdItems_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdItems.DoubleClick
        Dim r As UltraGridRow = grdItems.ActiveRow
        If r IsNot Nothing Then
            Dim m As New Model.MContractDetail
            m.ItemId = r.Cells("ItemId").Value
            m.ItemName = r.Cells("ItemName").Value
            m.ItemValue = CDbl(r.Cells("ItemValue").Value)
            m.Status = r.Cells("Status").Value
            m.SubContractorId = r.Cells("SubContractorId").Value
            m.Fee = CDbl(IsNull(r.Cells("Fee").Value, 0))
            Me.showItemDetail(m)
        End If
    End Sub
    Private Sub grdItems_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdItems.InitializeLayout
        If fGridIem Then Exit Sub
        fGridIem = True
        grdItems.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, grdItems, m_Lang)
        With e.Layout.Bands(0).Columns("DelItem")
            .Header.VisiblePosition = 0
            .Hidden = False
            .Header.Caption = ""
            .Style = ColumnStyle.Button
            .ButtonDisplayStyle = ButtonDisplayStyle.Always
            .CellButtonAppearance.Cursor = Cursors.Hand
            .CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center
            .CellButtonAppearance.Image = ModMain.m_DeleteIcon
            .CellClickAction = CellClickAction.CellSelect
            .Width = 50
        End With

    End Sub

    Private Sub grdItems_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdItems.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, grdItems, m_Lang)
                frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub grdSubContracts_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdSubContracts.ClickCellButton
        Dim r As UltraGridRow = grdSubContracts.ActiveRow
        If r IsNot Nothing Then
            Dim arr As IList(Of Model.MSubContract) = grdSubContracts.DataSource
            If arr IsNot Nothing Then
                Dim item = arr.Item(r.Index)
                If item Is Nothing Then Exit Sub
                arr.Remove(item)
                grdSubContracts.Rows.Refresh(RefreshRow.RefreshDisplay)
                Me.SumTotal()
            End If
        End If
    End Sub

    Dim fgrdSubContracts As Boolean = False

    Private Sub grdSubContracts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSubContracts.DoubleClick
        Dim r As UltraGridRow = grdSubContracts.ActiveRow
        If r IsNot Nothing Then
            Dim m As New Model.MSubContract
            m.SubContractId = r.Cells("SubContractId").Value
            m.Note = r.Cells("Note").Value
            m.SubContractValue = CDbl(r.Cells("SubContractValue").Value)
            m.SubContractDeadLine = CDate(r.Cells("SubContractDeadLine").Value)
            m.SubContractDate = CDate(IsNull(r.Cells("SubContractDate").Value, "2000-1-1"))
            Me.showSubContractDetail(m)
        End If
    End Sub
    Private Sub grdSubContracts_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdSubContracts.InitializeLayout
        If fgrdSubContracts Then Exit Sub
        fgrdSubContracts = True
        grdSubContracts.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, grdSubContracts, m_Lang)
        With e.Layout.Bands(0).Columns("DelItem")
            .Header.VisiblePosition = 100
            .Hidden = False
            .Header.Caption = ""
            .Style = ColumnStyle.Button
            .ButtonDisplayStyle = ButtonDisplayStyle.Always
            .CellButtonAppearance.Cursor = Cursors.Hand
            .CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center
            .CellButtonAppearance.Image = ModMain.m_DeleteIcon
            .CellClickAction = CellClickAction.CellSelect
            .Width = 50
        End With
    End Sub

    Private Sub grdSubContracts_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdSubContracts.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, grdSubContracts, m_Lang)
                frm.ShowDialog()
            End If
        End If
    End Sub

    Dim fgrdFiles As Boolean = False
    Dim arrFileDeleted As IList(Of Model.MAttachFileContract) = New List(Of Model.MAttachFileContract)

    Private Sub grdFiles_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdFiles.ClickCellButton
        Dim r As UltraGridRow = grdFiles.ActiveRow
        If r IsNot Nothing Then
            Dim arr As IList(Of Model.MAttachFileContract) = grdFiles.DataSource
            If arr IsNot Nothing Then
                If e.Cell.Column.Key = "OpenFile" Then
                    Try
                        Dim item = arr.Item(r.Index)
                        'Dim P As New Process
                        'P.StartInfo.FileName = item.FilePath
                        'P.StartInfo.Verb = "Open"
                        'P.Start()
                        Process.Start(item.FilePath)
                    Catch ex As Exception
                        ShowMsg("Đã xảy ra lỗi khi mở file: " & vbCrLf & ex.Message)
                    End Try
                Else
                    Dim item = arr.Item(r.Index)

                    ' hiệu chỉnh hợp đồng
                    ' giữ lại những path file xóa này để Xóa nó trên server
                    If Me.ContractId <> "" Then
                        Dim deletedItem As New Model.MAttachFileContract
                        deletedItem.ContractId = item.ContractId
                        deletedItem.FileId = item.FileId
                        deletedItem.FileName = item.FileName
                        deletedItem.FilePath = item.FilePath
                        deletedItem.FileType = item.FileType
                        arrFileDeleted.Add(deletedItem)
                    End If

                    arr.Remove(item)
                    grdFiles.Rows.Refresh(RefreshRow.RefreshDisplay)
                End If
            End If

        End If
    End Sub
    Private Sub grdFiles_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdFiles.InitializeLayout
        If fgrdFiles Then Exit Sub
        fgrdFiles = True
        grdFiles.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, grdFiles, m_Lang)
        With e.Layout.Bands(0).Columns("OpenFile")
            .Header.VisiblePosition = 99
            .Hidden = False
            .Header.Caption = ""
            .Style = ColumnStyle.Button
            .ButtonDisplayStyle = ButtonDisplayStyle.Always
            .CellButtonAppearance.Cursor = Cursors.Hand
            '.CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center
            '.CellButtonAppearance.Image = ModMain.m_OkIcon
            .CellClickAction = CellClickAction.CellSelect
            .Width = 50
        End With
        With e.Layout.Bands(0).Columns("DelItem")
            .Header.VisiblePosition = 100
            .Hidden = False
            .Header.Caption = ""
            .Style = ColumnStyle.Button
            .ButtonDisplayStyle = ButtonDisplayStyle.Always
            .CellButtonAppearance.Cursor = Cursors.Hand
            .CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center
            .CellButtonAppearance.Image = ModMain.m_DeleteIcon
            .CellClickAction = CellClickAction.CellSelect
            .Width = 50
        End With
    End Sub

    Private Sub grdFiles_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdFiles.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, grdFiles, m_Lang)
                frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub grdPayment_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdPayment.ClickCellButton
        Dim r As UltraGridRow = grdPayment.ActiveRow
        If r IsNot Nothing Then
            Dim arr As IList(Of Model.MContractPayment) = grdPayment.DataSource
            If arr IsNot Nothing Then
                Dim item = arr.Item(r.Index)
                If item Is Nothing Then Exit Sub
                arr.Remove(item)
                grdPayment.Rows.Refresh(RefreshRow.RefreshDisplay)
            End If
        End If
    End Sub

    Private Sub grdPayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPayment.DoubleClick
        Dim r As UltraGridRow = grdPayment.ActiveRow
        If r IsNot Nothing Then
            Dim arr As IList(Of Model.MContractPayment) = grdPayment.DataSource
            If arr IsNot Nothing Then
                Dim item = arr.Item(r.Index)
                If item Is Nothing Then Exit Sub
                Me.showPaymentDetail(item)
            End If

            'Dim m As New Model.MContractPayment
            'm.PaymentId = r.Cells("PaymentId").Value
            'm.PaymentName = r.Cells("PaymentName").Value
            'm.PaymentTotal = CDbl(r.Cells("PaymentTotal").Value)
            'm.PaymentDate = CDate(r.Cells("PaymentDate").Value)
            'm.PaymentStatus = r.Cells("PaymentStatus").Value
            'm.arrPaidItem = b.getContractPaymentDetails(txtContractId.Text, m.PaymentId)
            'Me.showPaymentDetail(m)
        End If
    End Sub
    Dim fgrdPayment As Boolean = False
    Private Sub grdPayment_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPayment.InitializeLayout
        If fgrdPayment Then Exit Sub
        fgrdPayment = True
        grdPayment.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, grdPayment, m_Lang)
        With e.Layout.Bands(0).Columns("DelItem")
            .Header.VisiblePosition = 100
            .Hidden = False
            .Header.Caption = ""
            .Style = ColumnStyle.Button
            .ButtonDisplayStyle = ButtonDisplayStyle.Always
            .CellButtonAppearance.Cursor = Cursors.Hand
            .CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center
            .CellButtonAppearance.Image = ModMain.m_DeleteIcon
            .CellClickAction = CellClickAction.CellSelect
            .Width = 50
        End With
    End Sub

    Private Sub grdPayment_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdPayment.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, grdPayment, m_Lang)
                frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub grdRefund_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdRefund.ClickCellButton
        Dim r As UltraGridRow = grdRefund.ActiveRow
        If r IsNot Nothing Then
            Dim arr As IList(Of Model.MContractRefund) = grdRefund.DataSource
            If arr IsNot Nothing Then
                Dim item = arr.Item(r.Index)
                If item Is Nothing Then Exit Sub
                arr.Remove(item)
                grdRefund.Rows.Refresh(RefreshRow.RefreshDisplay)
            End If
        End If
    End Sub

    Private Sub grdRefund_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRefund.DoubleClick
        Dim r As UltraGridRow = grdRefund.ActiveRow
        If r IsNot Nothing Then
            Dim m As New Model.MContractRefund
            m.RefundId = r.Cells("RefundId").Value
            m.RefundName = r.Cells("RefundName").Value
            m.RefundTotal = CDbl(r.Cells("RefundTotal").Value)
            m.RefundDate = CDate(r.Cells("RefundDate").Value)
            m.RefundStatus = r.Cells("RefundStatus").Value
            m.SubContractorId = r.Cells("SubContractorId").Value
            Me.showRefundDetail(m)
        End If
    End Sub
    Dim fgrdRefund As Boolean = False
    Private Sub grdRefund_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdRefund.InitializeLayout
        If fgrdRefund Then Exit Sub
        fgrdRefund = True
        grdRefund.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, grdRefund, m_Lang)
        With e.Layout.Bands(0).Columns("DelItem")
            .Header.VisiblePosition = 100
            .Hidden = False
            .Header.Caption = ""
            .Style = ColumnStyle.Button
            .ButtonDisplayStyle = ButtonDisplayStyle.Always
            .CellButtonAppearance.Cursor = Cursors.Hand
            .CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center
            .CellButtonAppearance.Image = ModMain.m_DeleteIcon
            .CellClickAction = CellClickAction.CellSelect
            .Width = 50
        End With
    End Sub

    Private Sub grdRefund_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdRefund.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, grdRefund, m_Lang)
                frm.ShowDialog()
            End If
        End If
    End Sub

    Dim fgrdHistory As Boolean = False
    Private Sub grdHistory_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdHistory.InitializeLayout
        If fgrdHistory Then Exit Sub
        fgrdHistory = True
        grdHistory.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, grdHistory, m_Lang)
    End Sub

    Private Sub grdHistory_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdHistory.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, grdHistory, m_Lang)
                frm.ShowDialog()
            End If
        End If
    End Sub
#End Region
End Class