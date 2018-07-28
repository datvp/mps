Public Class frmContractItemDetail
    Private item As Model.MContractDetail
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
    End Sub
    Private Sub LoadInfo(ByVal m As Model.MContractDetail)
        txtItemId.Text = m.ItemId
        txtItemName.Text = m.ItemName
        txtPaymentTotal.Text = Format(m.ItemValue, ModMain.m_strFormatCur)
        cboStatus.Value = m.Status
    End Sub
    Private Function setInfo() As Model.MContractDetail
        Dim m As New Model.MContractDetail
        m.ItemId = txtItemId.Text
        m.ItemName = txtItemName.Text
        m.ItemValue = CDbl(txtPaymentTotal.Text)
        m.Status = cboStatus.Value
        Return m
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.item = Me.setInfo()
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
End Class