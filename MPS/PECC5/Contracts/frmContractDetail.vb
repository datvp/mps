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
        txtNote.Text = m.Note
        Me.SumTotal()
    End Sub
    Private Sub LoadInfo(ByVal ContractId As String)
        Dim m = b.getContractDetailById(ContractId)
        If m.ContractId = "" Then Exit Sub
        Me.LoadComboBox()
        txtContractId.Text = m.ContractId
        txtContractId.Enabled = False
        txtContractName.Text = m.ContractName
        dtCreateDate.Value = m.ContractDate
        dtExpireDate.Value = m.ContractDeadLine
        txtContractValue.Text = Format(m.ContractValue, ModMain.m_strFormatCur)
        cboProject.Value = m.ProjectId
        grdItems.DataSource = m.arrContractDetail
        cboMainContractor.Value = m.MainContractorId
        grdSubContractors.DataSource = m.arrSubContractor
        cboContractLevel.Value = m.ContractLevelId
        grdSubContracts.DataSource = m.arrSubContract
        grdFiles.DataSource = m.arrFile
        txtNote.Text = m.Note
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
        If cboMainContractor.Value IsNot Nothing Then
            m.MainContractorId = cboMainContractor.Value
        End If
        m.arrContractDetail = grdItems.DataSource
        m.arrSubContract = grdSubContracts.DataSource
        m.arrSubContractor = grdSubContractors.DataSource
        m.arrFile = grdFiles.DataSource
        m.Note = txtNote.Text
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
        If Not CheckOK(m) Then Exit Sub

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
        item = frm.ShowDialog(item)
        If item IsNot Nothing Then
            Dim arr As IList(Of Model.MSubContract) = grdSubContracts.DataSource
            If arr IsNot Nothing Then
                Dim found = Me.findSubContract(item, arr)
                If Not found Then
                    Dim m As New Model.MSubContract
                    m.SubContractId = item.SubContractId
                    m.SubContractName = item.SubContractName
                    m.SubContractValue = item.SubContractValue
                    m.SubContractDate = m.SubContractDate
                    m.SubContractDeadLine = m.SubContractDeadLine
                    arr.Insert(arr.Count, m)
                End If
                grdSubContracts.Rows.Refresh(RefreshRow.RefreshDisplay)
                Me.SumTotal()
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
    Private Function findItem(ByVal itemId As String, ByVal arr As IList(Of Model.MContractDetail)) As Boolean
        Dim found As Boolean = False
        Dim i = 0
        While i < arr.Count And Not found
            If arr.Item(i).ItemId = itemId Then
                found = True
            End If
            i = i + 1
        End While

        Return found
    End Function

    Private Function findSubContractor(ByVal subContractorId As String, ByVal arr As IList(Of Model.MContract_SubContractor)) As Boolean
        Dim found As Boolean = False
        Dim i = 0
        While i < arr.Count And Not found
            If arr.Item(i).SubContractorId = subContractorId Then
                found = True
            End If
            i = i + 1
        End While

        Return found
    End Function

    Private Function findSubContract(ByVal item As Model.MSubContract, ByVal arr As IList(Of Model.MSubContract)) As Boolean
        Dim found As Boolean = False
        Dim i = 0
        While i < arr.Count And Not found
            If arr.Item(i).SubContractId = item.SubContractId Then
                arr.Item(i).SubContractName = item.SubContractName
                arr.Item(i).SubContractValue = item.SubContractValue
                arr.Item(i).SubContractDate = item.SubContractDate
                arr.Item(i).SubContractDeadLine = item.SubContractDeadLine
                found = True
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
                Dim found = Me.findItem(selectedObj.ItemId, arr)
                If Not found Then
                    Dim item As New Model.MContractDetail
                    item.ItemId = selectedObj.ItemId
                    item.ItemName = selectedObj.ItemName
                    arr.Insert(arr.Count, item)
                    grdItems.Rows.Refresh(RefreshRow.RefreshDisplay)
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
                If Not found Then
                    Dim item As New Model.MContract_SubContractor
                    item.SubContractorId = selectedObj.SubContractorId
                    item.SubContractorName = selectedObj.SubContractorName
                    arr.Insert(arr.Count, item)
                    grdSubContractors.Rows.Refresh(RefreshRow.RefreshDisplay)
                End If
            End If

        End If
    End Sub

    Private Sub lnkAddSubContract_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddSubContract.Click
        Me.showSubContractDetail(Nothing)
    End Sub

    Private Sub lnkAddFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAddFile.Click

    End Sub
#End Region

#Region "Grids"
    Dim fGridIem As Boolean = False

    Private Sub grdItems_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdItems.ClickCellButton
        Dim r As UltraGridRow = grdItems.ActiveRow
        If r IsNot Nothing Then
            Dim arr As IList(Of Model.MContractDetail) = grdItems.DataSource
            If arr IsNot Nothing Then
                arr.RemoveAt(r.Index)
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
                arr.RemoveAt(r.Index)
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
                arr.RemoveAt(r.Index)
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
            m.SubContractDate = CDate(r.Cells("SubContractDate").Value)
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
    Private Sub grdFiles_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdFiles.InitializeLayout
        If fgrdFiles Then Exit Sub
        fgrdFiles = True
        grdFiles.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, grdFiles, m_Lang)
    End Sub

    Private Sub grdFiles_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdFiles.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, grdFiles, m_Lang)
                frm.ShowDialog()
            End If
        End If
    End Sub
#End Region

End Class