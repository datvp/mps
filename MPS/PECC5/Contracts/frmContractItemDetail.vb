Public Class frmContractItemDetail
    Private item As Model.MContractDetail
    Private bSub As BLL.BSubContractors = BLL.BSubContractors.Instance
    Public Overloads Function ShowDialog(ByVal item As Model.MContractDetail) As Model.MContractDetail
        Me.item = item
        Me.ShowDialog()
        Return Me.item
    End Function
    Private Sub frmContractItemDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        End If
    End Sub
    Private Sub LoadStatus()
        Dim tb As New DataTable
        tb.Columns.Clear()
        tb.Columns.Add("Id", GetType(String))
        tb.Columns.Add("Name", GetType(String))

        Dim r As DataRow = tb.NewRow
        r("Id") = Statuses.Waiting
        r("Name") = StatusText(Statuses.Waiting)
        tb.Rows.Add(r)

        r = tb.NewRow
        r("Id") = Statuses.Completed
        r("Name") = StatusText(Statuses.Completed)
        tb.Rows.Add(r)

        r = tb.NewRow
        r("Id") = Statuses.Pending
        r("Name") = StatusText(Statuses.Pending)
        tb.Rows.Add(r)

        cboStatus.ValueMember = "Id"
        cboStatus.DisplayMember = "Name"
        cboStatus.DataSource = tb

        Dim tbSub = bSub.getListSubContractors()
        cboSubContractor.ValueMember = "SubContractorId"
        cboSubContractor.DisplayMember = "SubContractorName"
        cboSubContractor.DataSource = tbSub
    End Sub
    Private Sub LoadInfo(ByVal m As Model.MContractDetail)
        txtItemId.Text = m.ItemId
        txtItemName.Text = m.ItemName
        txtItemValue.Text = Format(m.ItemValue, ModMain.m_strFormatCur)
        cboStatus.Value = m.Status
    End Sub
    Private Function CheckOK(ByVal m As Model.MContractDetail) As Boolean
        If m.SubContractorId = "" Then
            ShowMsg("Chưa chọn nhà thầu phụ")
            cboSubContractor.Focus()
            Return False
        End If
        If m.Status = "" Then
            ShowMsg("Chưa chọn trạng thái")
            cboStatus.Focus()
            Return False
        End If
        If m.ItemValue = 0 Then
            ShowMsg("Chưa nhập tổng chi phí")
            txtItemValue.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function setInfo() As Model.MContractDetail
        Dim m As New Model.MContractDetail
        m.ItemId = txtItemId.Text
        m.ItemName = txtItemName.Text
        m.ItemValue = CDbl(txtItemValue.Text)
        If cboStatus.Value IsNot Nothing Then
            m.Status = cboStatus.Value
        End If
        If cboSubContractor.Value IsNot Nothing Then
            m.SubContractorId = cboSubContractor.Value
            m.SubContractorName = cboSubContractor.Text
        End If
        Return m
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

    Private Sub txtSubContractValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemValue.KeyPress
        ModMain.UltraTextBox_KeyPress(sender, e)
    End Sub

    Private Sub txtSubContractValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemValue.Leave
        ModMain.UltraTextBox_LostFocus(sender)
    End Sub

    Private Sub txtSubContractValue_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemValue.ValueChanged
        ModMain.UltraTextBox_ValueChanged(sender)
        If txtItemValue.Text = "" Then Exit Sub
        lblConvertMoney.Text = ModMain.convertMoney(CDbl(txtItemValue.Text))
    End Sub

    Private Sub cboStatus_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboStatus.InitializeLayout
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