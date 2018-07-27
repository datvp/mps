Imports Infragistics.Win.UltraWinGrid
Public Class frmContractDetail
#Region "Declares"
    Private WithEvents b As BLL.BContracts = BLL.BContracts.Instance
    Private clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Private bItem As BLL.BItems = BLL.BItems.Instance
    Private bProject As BLL.BProjects = BLL.BProjects.Instance
    Private bLevel As BLL.BConstructionLevels = BLL.BConstructionLevels.Instance
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
    End Sub
#End Region

#Region "Subs"
    Private Sub LoadComboBox()
        Dim tbProject = bProject.getListProjects()
        cboProject.ValueMember = "ProjectId"
        cboProject.DisplayMember = "ProjectName"
        cboProject.DataSource = tbProject

        Dim tbLevel = bLevel.getListConstructionLevels()
        cboContractLevel.ValueMember = "ConstructionLevelId"
        cboContractLevel.DisplayMember = "ConstructionLevelName"
        cboContractLevel.DataSource = tbLevel

        Dim tb = bMainContractor.getListMainContractors()
        cboMainContractor.ValueMember = "Id"
        cboMainContractor.DisplayMember = "Company"
        cboMainContractor.DataSource = tb
    End Sub
    Private Sub ClearInfo()
        Dim m As New Model.MContract
        txtContractId.Text = m.ContractId
        txtContractId.Enabled = True
        txtContractName.Text = m.ContractName
        txtContractValue.Text = Format(0, ModMain.m_strFormatCur)
        cboProject.Value = Nothing
        cboContractLevel.Value = Nothing
        cboMainContractor.Value = Nothing
        grdItems.DataSource = m.arrContractDetail
        grdSubContracts.DataSource = m.arrSubContract
        grdSubContractors.DataSource = m.arrSubContractor
        grdFiles.DataSource = m.arrFile
        grdPayment.DataSource = m.arrPayment
        grdHistory.DataSource = m.arrHistory
        txtNote.Text = m.Note
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
        cboContractLevel.Value = mInfo.ContractLevelId
        lblStatus.Text = mInfo.ContractState
        txtNote.Text = mInfo.Note

        grdItems.DataSource = mInfo.arrContractDetail
        grdSubContractors.DataSource = mInfo.arrSubContractor
        grdSubContracts.DataSource = mInfo.arrSubContract
        grdFiles.DataSource = mInfo.arrFile
        grdPayment.DataSource = mInfo.arrPayment
        grdHistory.DataSource = mInfo.arrHistory
        Me.SumTotal()
    End Sub
    Private Function setInfo() As Model.MContract
        Dim m As New Model.MContract
        m.ContractId = txtContractId.Text
        m.ContractName = txtContractName.Text
        m.ContractDate = dtCreateDate.Value
        m.ContractDeadLine = dtExpireDate.Value
        m.ContractValue = CDbl(txtContractValue.Text)
        If cboProject.Value IsNot Nothing Then
            m.ProjectId = cboProject.Value
        End If
        If cboContractLevel.Value IsNot Nothing Then
            m.ContractLevelId = cboContractLevel.Value
        End If
        m.ContractState = "Waiting" ' waiting -> accepted|rejected -> completed || deleted
        If cboMainContractor.Value IsNot Nothing Then
            m.MainContractorId = cboMainContractor.Value
        End If
        m.arrContractDetail = grdItems.DataSource
        m.arrSubContract = grdSubContracts.DataSource
        m.arrSubContractor = grdSubContractors.DataSource
        m.arrFile = grdFiles.DataSource
        m.arrPayment = grdPayment.DataSource
        m.Note = txtNote.Text
        For Each it In m.arrSubContract
            If m.SubContracts = "" Then
                m.SubContracts = it.SubContractName
            Else
                m.SubContracts += " | " + it.SubContractName
            End If
        Next
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

        If m.MainContractorId = "" Then
            ShowMsg("Chọn nhà thầu chính")
            cboMainContractor.Focus()
            Return False
        End If

        If m.ContractLevelId = "" Then
            ShowMsg("Chọn phân cấp hợp đồng")
            cboContractLevel.Focus()
            Return False
        End If



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
                desc += vbCrLf & "Giá trị hợp đồng: [" + mInfo.ContractValue + "] -> [" + m.ContractValue + "]"
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
                    Dim foundItem = Me.findItem(it.ItemId, mInfo.arrContractDetail)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thêm hạng mục: [" + it.ItemName + "]"
                    End If
                Next
            ElseIf m.arrContractDetail.Count < mInfo.arrContractDetail.Count Then
                For Each it In mInfo.arrContractDetail
                    Dim foundItem = Me.findItem(it.ItemId, m.arrContractDetail)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Xóa hạng mục: [" + it.ItemName + "]"
                    End If
                Next
            Else
                For Each it In m.arrContractDetail
                    Dim foundItem = Me.findItem(it.ItemId, mInfo.arrContractDetail)
                    If foundItem Is Nothing Then
                        desc += "Thay đổi hạng mục: -> [" + it.ItemName + "]"
                    End If
                Next
            End If

            'nha thau phu
            mInfo.arrSubContractor = b.getSubContractors(mInfo.ContractId)
            If m.arrSubContractor.Count > mInfo.arrSubContractor.Count Then
                For Each it In m.arrSubContractor
                    Dim foundItem = Me.findSubContractor(it.SubContractorId, mInfo.arrSubContractor)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thêm nhà thầu phụ: [" + it.SubContractorName + "]"
                    End If
                Next
            ElseIf m.arrSubContractor.Count < mInfo.arrSubContractor.Count Then
                For Each it In mInfo.arrSubContractor
                    Dim foundItem = Me.findSubContractor(it.SubContractorId, m.arrSubContractor)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Xóa nhà thầu phụ: [" + it.SubContractorName + "]"
                    End If
                Next
            Else
                For Each it In m.arrSubContractor
                    Dim foundItem = Me.findSubContractor(it.SubContractorId, mInfo.arrSubContractor)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thay đổi nhà thầu phụ: -> [" + it.SubContractorName + "]"
                    End If
                Next
            End If

            'phu luc hop dong
            mInfo.arrSubContract = b.getSubContracts(mInfo.ContractId)
            If m.arrSubContract.Count > mInfo.arrSubContract.Count Then
                For Each it In m.arrSubContract
                    Dim foundItem = Me.findSubContract(it, mInfo.arrSubContract, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thêm phụ lục hợp đồng: [" + it.SubContractName + "]"
                    End If
                Next
            ElseIf m.arrSubContract.Count < mInfo.arrSubContract.Count Then
                For Each it In mInfo.arrSubContract
                    Dim foundItem = Me.findSubContract(it, m.arrSubContract, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Xóa phụ lục hợp đồng: [" + it.SubContractName + "]"
                    End If
                Next
            Else
                For Each it In m.arrSubContract
                    Dim foundItem = Me.findSubContract(it, mInfo.arrSubContract, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thay đổi phụ lục hợp đồng: -> [" + it.SubContractName + "]"
                    Else 'found
                        If it.SubContractName <> foundItem.SubContractName _
                            OrElse it.SubContractValue <> foundItem.SubContractValue _
                            OrElse it.SubContractDeadLine <> foundItem.SubContractDeadLine _
                        Then
                            desc += vbCrLf & "Sửa phụ lục hợp đồng [" + it.SubContractName + "]: "
                            If it.SubContractName <> foundItem.SubContractName Then
                                desc += vbCrLf & " - Tên phụ lục: [" + foundItem.SubContractName + "] -> [" + it.SubContractName + "]"
                            End If
                            If it.SubContractValue <> foundItem.SubContractValue Then
                                desc += vbCrLf & " - Giá trị phụ lục: [" + foundItem.SubContractValue + "] -> [" + it.SubContractValue + "]"
                            End If
                            If it.SubContractDeadLine <> foundItem.SubContractDeadLine Then
                                desc += vbCrLf & " - Ngày gia hạn: [" + foundItem.SubContractDeadLine.ToString("dd/MM/yyyy") + "] -> [" + it.SubContractDeadLine.ToString("dd/MM/yyyy") + "]"
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

            'các đợt thanh toán
            mInfo.arrPayment = b.getContractPayments(mInfo.ContractId)
            If m.arrPayment.Count > mInfo.arrPayment.Count Then
                For Each it In m.arrPayment
                    Dim foundItem = Me.findPayment(it, mInfo.arrPayment, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thêm đợt thanh toán: [" + it.PaymentName + "]"
                    End If
                Next
            ElseIf m.arrPayment.Count < mInfo.arrPayment.Count Then
                For Each it In mInfo.arrPayment
                    Dim foundItem = Me.findPayment(it, m.arrPayment, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Xóa đợt thanh toán: [" + it.PaymentName + "]"
                    End If
                Next
            Else
                For Each it In m.arrPayment
                    Dim foundItem = Me.findPayment(it, mInfo.arrPayment, False)
                    If foundItem Is Nothing Then
                        desc += vbCrLf & "Thay đổi đợt thanh toán: -> [" + it.PaymentName + "]"
                    Else 'found
                        If it.PaymentName <> foundItem.PaymentName _
                            OrElse it.PaymentTotal <> foundItem.PaymentTotal _
                            OrElse it.PaymentTotal <> foundItem.PaymentTotal _
                            OrElse it.PaymentDate <> foundItem.PaymentDate _
                        Then
                            desc += vbCrLf & "Sửa đợt thanh toán [" + it.PaymentName + "]: "
                            If it.PaymentName <> foundItem.PaymentName Then
                                desc += vbCrLf & " - Tên đợt thanh toán: [" + foundItem.PaymentName + "] -> [" + it.PaymentName + "]"
                            End If
                            If it.PaymentTotal <> foundItem.PaymentTotal Then
                                desc += vbCrLf & " - Giá trị thanh toán: [" + Format(foundItem.PaymentTotal, ModMain.m_strFormatCur) + "] -> [" + Format(it.PaymentTotal, ModMain.m_strFormatCur) + "]"
                            End If
                            If it.PaymentDate <> foundItem.PaymentDate Then
                                desc += vbCrLf & " - Ngày thanh toán: [" + foundItem.PaymentDate.ToString("dd/MM/yyyy") + "] -> [" + it.PaymentDate.ToString("dd/MM/yyyy") + "]"
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
            For Each it In arr
                extentValue += it.SubContractValue
            Next
            txtExtentValue.Text = Format(extentValue, ModMain.m_strFormatCur)
            total += extentValue
        End If
        txtTotalValue.Text = Format(total, ModMain.m_strFormatCur)
        lblConvertMoney.Text = ModMain.convertMoney(total)
    End Sub
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
                    m.SubContractName = item.SubContractName
                    m.SubContractValue = item.SubContractValue
                    m.SubContractDeadLine = item.SubContractDeadLine
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
                    arr.Insert(arr.Count, m)
                End If
                grdPayment.Rows.Refresh(RefreshRow.RefreshDisplay)
            End If
        End If
    End Sub
#End Region

#Region "Combobox InitializeLayout"
    Private Sub cboProject_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboProject.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("ProjectName").Hidden = False
    End Sub
    Private Sub cboMainContractor_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboMainContractor.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("Company").Hidden = False
    End Sub
    Private Sub cboContractLevel_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboContractLevel.InitializeLayout
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
    Private Function findItem(ByVal itemId As String, ByVal arr As IList(Of Model.MContractDetail)) As Model.MContractDetail
        Dim foundItem As Model.MContractDetail = Nothing
        Dim i = 0
        While i < arr.Count And foundItem Is Nothing
            If arr.Item(i).ItemId = itemId Then
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
                    arr.Item(i).SubContractName = item.SubContractName
                    arr.Item(i).SubContractValue = item.SubContractValue
                    arr.Item(i).SubContractDeadLine = item.SubContractDeadLine
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
        Dim frm As New frmItems
        Dim selectedObj = frm.ShowDialog(True)
        If selectedObj IsNot Nothing Then
            Dim arr As IList(Of Model.MContractDetail) = grdItems.DataSource
            If arr IsNot Nothing Then
                Dim foundItem = Me.findItem(selectedObj.ItemId, arr)
                If foundItem Is Nothing Then
                    Dim item As New Model.MContractDetail
                    item.ItemId = selectedObj.ItemId
                    item.ItemName = selectedObj.ItemName
                    arr.Insert(arr.Count, item)
                    grdItems.Rows.Refresh(RefreshRow.RefreshDisplay)
                Else
                    ShowMsg("Hạng mục: [" + foundItem.ItemName + "] đã được thêm.")
                End If
            End If

        End If
    End Sub

    Private Sub lnkAddSubContractor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddSubContractor.Click
        Dim frm As New frmSubContractors
        Dim selectedObj = frm.ShowDialog(True)
        If selectedObj IsNot Nothing Then
            Dim arr As IList(Of Model.MContract_SubContractor) = grdSubContractors.DataSource
            If arr IsNot Nothing Then
                Dim found = Me.findSubContractor(selectedObj.SubContractorId, arr)
                If found Is Nothing Then
                    Dim item As New Model.MContract_SubContractor
                    item.SubContractorId = selectedObj.SubContractorId
                    item.SubContractorName = selectedObj.SubContractorName
                    arr.Insert(arr.Count, item)
                    grdSubContractors.Rows.Refresh(RefreshRow.RefreshDisplay)
                Else
                    ShowMsg("Nhà thầu phụ: [" + found.SubContractorName + "] đã được thêm.")
                End If
            End If

        End If
    End Sub

    Private Sub lnkAddSubContract_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddSubContract.Click
        Me.showSubContractDetail(Nothing)
    End Sub

    Private Sub lnkAddFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddFile.Click
        Dim fd As New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
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
    Private Sub grdItems_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdItems.InitializeLayout
        If fGridIem Then Exit Sub
        fGridIem = True
        grdItems.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, grdItems, m_Lang)
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

    Private Sub grdItems_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdItems.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, grdItems, m_Lang)
                frm.ShowDialog()
            End If
        End If
    End Sub


    Private Sub grdSubContractors_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdSubContractors.ClickCellButton
        Dim r As UltraGridRow = grdSubContractors.ActiveRow
        If r IsNot Nothing Then
            Dim arr As IList(Of Model.MContract_SubContractor) = grdSubContractors.DataSource
            If arr IsNot Nothing Then
                Dim item = arr.Item(r.Index)
                If item Is Nothing Then Exit Sub
                arr.Remove(item)
                grdSubContractors.Rows.Refresh(RefreshRow.RefreshDisplay)
            End If
        End If
    End Sub

    Dim fgrdSubContractors As Boolean = False
    Private Sub grdSubContractors_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdSubContractors.InitializeLayout
        If fgrdSubContractors Then Exit Sub
        fgrdSubContractors = True
        grdSubContractors.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, grdSubContractors, m_Lang)
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

    Private Sub grdSubContractors_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdSubContractors.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, grdSubContractors, m_Lang)
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
            m.SubContractName = r.Cells("SubContractName").Value
            m.SubContractValue = CDbl(r.Cells("SubContractValue").Value)
            m.SubContractDeadLine = CDate(r.Cells("SubContractDeadLine").Value)
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
                If item.PaymentStatus = "Paid" Then
                    ShowMsg("Đợt thanh toán:" & item.PaymentName & " không thể xóa.")
                    Exit Sub
                End If
                arr.Remove(item)
                grdPayment.Rows.Refresh(RefreshRow.RefreshDisplay)
            End If
        End If
    End Sub

    Private Sub grdPayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPayment.DoubleClick
        Dim r As UltraGridRow = grdPayment.ActiveRow
        If r IsNot Nothing Then
            Dim m As New Model.MContractPayment
            m.PaymentId = r.Cells("PaymentId").Value
            m.PaymentName = r.Cells("PaymentName").Value
            m.PaymentTotal = CDbl(r.Cells("PaymentTotal").Value)
            m.PaymentDate = CDate(r.Cells("PaymentDate").Value)
            m.PaymentStatus = r.Cells("PaymentStatus").Value
            If m.PaymentStatus = "Paid" Then
                ShowMsg("Đợt thanh toán:" & m.PaymentName & " không thể hiệu chỉnh.")
                Exit Sub
            End If
            Me.showPaymentDetail(m)
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