Public Class frmRefundDetail
    Private bSub As BLL.BSubContractors = BLL.BSubContractors.Instance
    Private item As Model.MContractRefund
    Dim dtCreated As Date
    Public Overloads Function ShowDialog(ByVal item As Model.MContractRefund, ByVal dtCreated As Date) As Model.MContractRefund
        Me.item = item
        Me.dtCreated = dtCreated
        Me.ShowDialog()
        Return Me.item
    End Function
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
            If cboRefundStatus.DataSource IsNot Nothing AndAlso cboRefundStatus.Rows.Count > 0 Then
                cboRefundStatus.Rows(0).Activate()
            End If
        End If
    End Sub
    Private Sub LoadStatus()
        Dim tb As New DataTable
        tb.Columns.Clear()
        tb.Columns.Add("Id", GetType(String))
        tb.Columns.Add("Name", GetType(String))

        Dim r As DataRow = tb.NewRow
        r("Id") = Statuses.WaitForRefund
        r("Name") = StatusText(Statuses.WaitForRefund)
        tb.Rows.Add(r)

        r = tb.NewRow
        r("Id") = Statuses.Refunded
        r("Name") = StatusText(Statuses.Refunded)
        tb.Rows.Add(r)

        cboRefundStatus.ValueMember = "Id"
        cboRefundStatus.DisplayMember = "Name"
        cboRefundStatus.DataSource = tb

        Dim tbSub = bSub.getListSubContractors()
        cboSubContractor.ValueMember = "SubContractorId"
        cboSubContractor.DisplayMember = "SubContractorName"
        cboSubContractor.DataSource = tbSub
    End Sub
    Private Sub LoadInfo(ByVal m As Model.MContractRefund)
        txtRefundId.Text = m.RefundId
        txtRefundName.Text = m.RefundName
        txtRefundTotal.Text = Format(m.RefundTotal, ModMain.m_strFormatCur)
        dtRefundDate.Value = m.RefundDate
        cboRefundStatus.Value = m.RefundStatus
        cboSubContractor.Value = m.SubContractorId
    End Sub
    Private Function setInfo() As Model.MContractRefund
        Dim m As New Model.MContractRefund
        m.RefundId = txtRefundId.Text
        m.RefundName = txtRefundName.Text
        m.RefundTotal = CDbl(txtRefundTotal.Text)
        m.RefundDate = dtRefundDate.Value
        If cboRefundStatus.Value IsNot Nothing Then
            m.RefundStatus = cboRefundStatus.Value
        End If
        If cboRefundStatus.Value IsNot Nothing Then
            m.SubContractorId = cboSubContractor.Value
            m.SubContractorName = cboSubContractor.Text
        End If
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MContractRefund) As Boolean
        If m.RefundTotal = 0 Then
            ShowMsg("Chưa nhập số tiền phải chi")
            txtRefundTotal.Focus()
            Return False
        End If
        If m.RefundStatus = "" Then
            ShowMsg("Chưa chọn trạng thái")
            cboRefundStatus.Focus()
            Return False
        End If
        If m.SubContractorId = "" Then
            ShowMsg("Chưa chọn nhà thầu phụ")
            cboSubContractor.Focus()
            Return False
        End If
        If DateDiffM("day", Me.dtCreated, dtRefundDate.Value) < 0 Then
            ShowMsg("Ngày thanh toán thêm phải lớn hơn hoặc bằng Ngày ký của Hợp đồng.")
            dtRefundDate.Focus()
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

    Private Sub txtSubContractValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRefundTotal.KeyPress
        ModMain.UltraTextBox_KeyPress(sender, e)
    End Sub

    Private Sub txtSubContractValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRefundTotal.Leave
        ModMain.UltraTextBox_LostFocus(sender)
    End Sub

    Private Sub txtSubContractValue_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRefundTotal.ValueChanged
        ModMain.UltraTextBox_ValueChanged(sender)
        If txtRefundTotal.Text = "" Then Exit Sub
        lblConvertMoney.Text = ModMain.convertMoney(CDbl(txtRefundTotal.Text))
    End Sub

    Private Sub cboStatus_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboRefundStatus.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("Name").Hidden = False
    End Sub

    Private Sub cboSubContractor_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboSubContractor.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("SubContractorName").Hidden = False
    End Sub
End Class