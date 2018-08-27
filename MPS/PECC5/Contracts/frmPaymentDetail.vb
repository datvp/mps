Imports Infragistics.Win.UltraWinGrid

Public Class frmPaymentDetail
    Private clsuf As New VsoftBMS.Ulti.ClsFormatUltraGrid
    Private item As Model.MContractPayment
    Dim dtCreated As Date
    Public Overloads Function ShowDialog(ByVal item As Model.MContractPayment, ByVal dtCreated As Date) As Model.MContractPayment
        Me.item = item
        Me.dtCreated = dtCreated
        Me.ShowDialog()
        Return Me.item
    End Function

    Private Sub frmPaymentDetail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub
    Private Sub frmPaymentDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        Me.LoadStatus()
        If Me.item IsNot Nothing Then
            Me.LoadInfo(Me.item)
            ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
            btnSave.Text = ModMain.m_Update
        Else
            ModMain.BlueButton(btnSave, ModMain.m_AddIcon)
            btnSave.Text = ModMain.m_Add
            If cboStatus.DataSource IsNot Nothing AndAlso cboStatus.Rows.Count > 0 Then
                cboStatus.Rows(0).Activate()
            End If
            grdPaidItems.DataSource = New List(Of Model.MContractPaymentDetail)
        End If
    End Sub
    Private Sub LoadStatus()
        Dim tb As New DataTable
        tb.Columns.Clear()
        tb.Columns.Add("Id", GetType(String))
        tb.Columns.Add("Name", GetType(String))

        Dim r As DataRow = tb.NewRow
        r("Id") = Statuses.WaitForPay
        r("Name") = StatusText(Statuses.WaitForPay)
        tb.Rows.Add(r)

        r = tb.NewRow
        r("Id") = Statuses.Paid
        r("Name") = StatusText(Statuses.Paid)
        tb.Rows.Add(r)

        cboStatus.ValueMember = "Id"
        cboStatus.DisplayMember = "Name"
        cboStatus.DataSource = tb
    End Sub
    Private Sub LoadInfo(ByVal m As Model.MContractPayment)
        txtPaymentId.Text = m.PaymentId
        txtPaymentName.Text = m.PaymentName
        txtPaymentTotal.Text = Format(m.PaymentTotal, ModMain.m_strFormatCur)
        dtPaymentDate.Value = m.PaymentDate
        cboStatus.Value = m.PaymentStatus
        grdPaidItems.DataSource = m.arrPaidItem
    End Sub
    Private Function setInfo() As Model.MContractPayment
        Dim m As New Model.MContractPayment
        m.PaymentId = txtPaymentId.Text
        m.PaymentName = txtPaymentName.Text
        m.PaymentTotal = CDbl(txtPaymentTotal.Text)
        m.PaymentDate = dtPaymentDate.Value
        m.PaymentStatus = cboStatus.Value
        For Each r In grdPaidItems.Rows
            Dim item As New Model.MContractPaymentDetail
            item.PaymentId = r.Cells("PaymentId").Value
            item.ItemId = r.Cells("ItemId").Value
            item.ItemName = r.Cells("ItemName").Value
            item.PaidValue = CDbl(r.Cells("PaidValue").Value)
            m.arrPaidItem.Add(item)
        Next
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MContractPayment) As Boolean
        If m.PaymentName = "" Then
            ShowMsg("Chưa nhập tên đợt thanh toán")
            txtPaymentName.Focus()
            Return False
        End If
        If m.PaymentId = "" Then
            ShowMsg("Chưa nhập mã đợt thanh toán")
            txtPaymentId.Focus()
            Return False
        End If
        If m.PaymentTotal = 0 Then
            ShowMsg("Chưa nhập giá trị thanh toán")
            txtPaymentTotal.Focus()
            Return False
        End If
        If m.arrPaidItem.Count = 0 Then
            ShowMsg("Chưa chọn hạng mục cần nghiệm thu")
            lnkAddPaidItem.Focus()
            Return False
        End If
        If DateDiffM("day", Me.dtCreated, dtPaymentDate.Value) < 0 Then
            ShowMsg("Ngày thanh toán thêm phải lớn hơn hoặc bằng Ngày ký của Hợp đồng.")
            dtPaymentDate.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim m = Me.setInfo()
        If Not Me.CheckOK(m) Then Exit Sub
        Me.item = m
        Me.Close()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.item = Nothing
        Me.Close()
    End Sub

    Private Sub txtSubContractValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaymentTotal.KeyPress
        ModMain.UltraTextBox_KeyPress(sender, e)
    End Sub

    Private Sub txtSubContractValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaymentTotal.Leave
        ModMain.UltraTextBox_LostFocus(sender)
    End Sub

    Private Sub txtSubContractValue_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaymentTotal.ValueChanged
        ModMain.UltraTextBox_ValueChanged(sender)
        If txtPaymentTotal.Text = "" Then Exit Sub
        lblConvertMoney.Text = ModMain.convertMoney(CDbl(txtPaymentTotal.Text))
    End Sub

    Private Sub cboStatus_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboStatus.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("Name").Hidden = False
    End Sub

    Private Function findItem(ByVal item As Model.MContractPaymentDetail, ByVal arr As IList(Of Model.MContractPaymentDetail), Optional ByVal isUpdate As Boolean = True) As Model.MContractPaymentDetail
        Dim foundItem As Model.MContractPaymentDetail = Nothing
        Dim i = 0
        While i < arr.Count And foundItem Is Nothing
            If arr.Item(i).ItemId = item.ItemId Then
                foundItem = arr.Item(i)
            End If
            i = i + 1
        End While

        Return foundItem
    End Function
    Public Sub SubTotal()
        f_CellUpdate = False
        Dim total As Double = 0
        grdPaidItems.UpdateData()
        For Each r In grdPaidItems.Rows
            total += CDbl(r.Cells("PaidValue").Value)
        Next
        txtPaymentTotal.Text = Format(total, ModMain.m_strFormatCur)
        f_CellUpdate = True
    End Sub
    Private Sub lnkAddPaidItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkAddPaidItem.Click
        Dim frm As New frmItems
        Dim selectedObj = frm.ShowDialog(True)
        If selectedObj IsNot Nothing Then
            Dim arr As IList(Of Model.MContractPaymentDetail) = grdPaidItems.DataSource
            If arr IsNot Nothing Then
                Dim item As New Model.MContractPaymentDetail
                item.PaymentId = txtPaymentId.Text
                item.ItemId = selectedObj.ItemId
                item.ItemName = selectedObj.ItemName
                item.PaidValue = 0
                Dim foundItem = Me.findItem(item, arr)
                If foundItem Is Nothing Then
                    arr.Insert(arr.Count, item)
                    grdPaidItems.Rows.Refresh(RefreshRow.RefreshDisplay)
                End If
            End If
        End If
    End Sub
    Dim f_CellUpdate As Boolean = True
    Private Sub grdPaidItems_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdPaidItems.AfterCellUpdate
        If Not f_CellUpdate Then Exit Sub
        Me.SubTotal()
    End Sub

    Private Sub grdPaidItems_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdPaidItems.CellChange
        Dim r As UltraGridRow = grdPaidItems.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub

        Select Case grdPaidItems.ActiveCell.Column.Key
            Case "PaidValue"
                If e.Cell.Text <> "" Then
                    If Not IsNumeric(e.Cell.Text) Then
                        e.Cell.Value = 0
                    Else
                        If CDbl(e.Cell.Text) < 0 Then e.Cell.Value = 0
                    End If
                End If
        End Select
    End Sub

    Private Sub grdPaidItems_CellDataError(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs) Handles grdPaidItems.CellDataError
        e.RaiseErrorEvent = False
        ShowMsg("Dữ liệu không hợp lệ !")
        e.RestoreOriginalValue = True
    End Sub

    Private Sub grdPaidItems_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdPaidItems.ClickCellButton
        Dim r As UltraGridRow = grdPaidItems.ActiveRow
        If r IsNot Nothing Then
            Dim arr As IList(Of Model.MContractPaymentDetail) = grdPaidItems.DataSource
            If arr IsNot Nothing Then
                Dim item = arr.Item(r.Index)
                If item Is Nothing Then Exit Sub
                arr.Remove(item)
                grdPaidItems.Rows.Refresh(RefreshRow.RefreshDisplay)
                Me.SubTotal()
            End If
        End If
    End Sub
    Dim fgrdPaidItems As Boolean = False
    Private Sub grdPaidItems_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPaidItems.InitializeLayout
        If fgrdPaidItems Then Exit Sub
        fgrdPaidItems = True
        grdPaidItems.DisplayLayout.Override.RowAlternateAppearance.BackColor = ModMain.m_sysColor
        clsuf.FormatGridFromDB(Me.Name, grdPaidItems, m_Lang)
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

    Private Sub grdPaidItems_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdPaidItems.KeyUp
        If e.Control Then
            If e.KeyCode = Keys.Z Then
                Dim frm As New VsoftBMS.Ulti.FrmFormatUltraGrid(Me.Name, grdPaidItems, m_Lang)
                frm.ShowDialog()
                Exit Sub
            End If
        End If

        If e.KeyCode = 37 Then
            grdPaidItems.PerformAction(UltraGridAction.AboveCell)
        End If
        If e.KeyCode = 39 Then
            grdPaidItems.PerformAction(UltraGridAction.BelowCell)
        End If
        If e.KeyCode = 38 Then
            grdPaidItems.PerformAction(UltraGridAction.AboveCell)
        End If
        If e.KeyCode = 40 Then
            grdPaidItems.PerformAction(UltraGridAction.BelowCell)
        End If
        If e.KeyCode = 37 OrElse e.KeyCode = 38 OrElse e.KeyCode = 39 OrElse e.KeyCode = 40 Then
            grdPaidItems.PerformAction(UltraGridAction.EnterEditMode)
        End If

        Dim r As UltraGridRow = grdPaidItems.ActiveRow
        If r Is Nothing Then Exit Sub
        If r.Index = -1 Then Exit Sub
        If grdPaidItems.ActiveCell Is Nothing Then Exit Sub
        Dim sCol = grdPaidItems.ActiveCell.Column.Key

        If e.KeyCode = Keys.Enter Then
            Dim fNext As Boolean = grdPaidItems.PerformAction(UltraGridAction.NextCell)
            If Not fNext Then
                Exit Sub
            End If

            If grdPaidItems.ActiveCell.CanEnterEditMode Then
                grdPaidItems.PerformAction(UltraGridAction.EnterEditMode)
                r.Cells(sCol).IsInEditMode = True
            End If
        ElseIf e.KeyCode <> 37 And e.KeyCode <> 38 And e.KeyCode <> 39 And e.KeyCode <> 40 And e.KeyCode <> Keys.Delete _
            And e.KeyCode <> Keys.F2 And e.KeyCode <> Keys.Escape And e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.F9 Then

            If sCol = "PaidValue" Then
                grdPaidItems.PerformAction(UltraGridAction.EnterEditMode)
                r.Cells(sCol).IsInEditMode = True
            End If
        End If
    End Sub
End Class