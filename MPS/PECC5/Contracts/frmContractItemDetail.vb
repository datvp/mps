Imports Infragistics.Win.UltraWinGrid

Public Class frmContractItemDetail
    Private item As Model.MContractDetail
    Private bSub As BLL.BSubContractors = BLL.BSubContractors.Instance
    Dim bItem As BLL.BItems = BLL.BItems.Instance
    Public Overloads Function ShowDialog(ByVal item As Model.MContractDetail) As Model.MContractDetail
        Me.item = item
        Me.ShowDialog()
        Return Me.item
    End Function

    Private Sub frmContractItemDetail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub
    Private Sub frmContractItemDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        Me.LoadCombo()
        If Me.item IsNot Nothing Then
            Me.LoadInfo(Me.item)
            ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
            btnSave.Text = ModMain.m_Update
        Else
            ModMain.BlueButton(btnSave, ModMain.m_AddIcon)
            btnSave.Text = ModMain.m_Add
        End If
    End Sub
    Dim isAddItem As Boolean
    Private Sub LoadItems()
        Dim tbItem = bItem.getListItems()
        Dim m = ModMain.getPermitFunc(ModMain.m_UIDLogin, 7)
        isAddItem = m.A
        If m.A Then
            ModMain.AddNewRow(tbItem)
        End If
        cboItem.ValueMember = "ItemId"
        cboItem.DisplayMember = "ItemName"
        cboItem.DataSource = tbItem
    End Sub
    Private Sub LoadCombo()
        Dim tbSub = bSub.getListSubContractors()
        cboSubContractor.ValueMember = "SubContractorId"
        cboSubContractor.DisplayMember = "SubContractorName"
        cboSubContractor.DataSource = tbSub

        Me.LoadItems()
    End Sub
    Private Sub LoadInfo(ByVal m As Model.MContractDetail)
        cboItem.Value = m.ItemId
        txtItemValue.Text = Format(m.ItemValue, ModMain.m_strFormatCur)
        If m.SubContractorId <> "" Then
            chkGetSubContractor.Checked = True
            cboSubContractor.Value = m.SubContractorId
            txtFee.Text = Format(m.Fee, ModMain.m_strFormatCur)
        End If
    End Sub
    Private Function CheckOK(ByVal m As Model.MContractDetail) As Boolean
        If m.ItemId = "" Then
            ShowMsg("Chưa chọn hạng mục")
            cboItem.Focus()
            Return False
        End If
        If chkGetSubContractor.Checked Then
            If m.SubContractorId = "" Then
                ShowMsg("Chưa chọn nhà thầu")
                cboSubContractor.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    Private Function setInfo() As Model.MContractDetail
        Dim m As New Model.MContractDetail
        If cboItem.Value IsNot Nothing Then
            m.ItemId = cboItem.Value
            m.ItemName = cboItem.Text
        End If
        m.ItemValue = CDbl(txtItemValue.Text)

        If chkGetSubContractor.Checked Then
            If cboSubContractor.Value IsNot Nothing Then
                m.SubContractorId = cboSubContractor.Value
                m.SubContractorName = cboSubContractor.Text
            End If
            m.Fee = CDbl(txtFee.Text)
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

    Private Sub txtSubContractValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemValue.KeyPress, txtFee.KeyPress
        ModMain.UltraTextBox_KeyPress(sender, e)
    End Sub

    Private Sub txtSubContractValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemValue.Leave, txtFee.Leave
        ModMain.UltraTextBox_LostFocus(sender)
    End Sub

    Private Sub txtSubContractValue_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemValue.ValueChanged, txtFee.ValueChanged
        ModMain.UltraTextBox_ValueChanged(sender)
        If txtItemValue.Text = "" Then Exit Sub
        lblConvertMoney.Text = ModMain.convertMoney(CDbl(txtItemValue.Text))
    End Sub

    Private Sub cboStatus_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
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

    Private Sub cboItem_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItem.AfterCloseUp
        Dim cbo As UltraCombo = sender
        ModMain.FilterOwnerCombo_CloseUp(cbo, "")
        If cbo.Value Is Nothing Then Exit Sub
        If cbo.Value = "" Then
            Dim frm As New frmItemDetail
            Dim result = frm.ShowDialog("")
            If result <> "" Then
                Me.LoadItems()
                cboItem.Value = result
            Else
                cboItem.Value = Nothing
            End If
        End If
    End Sub
    Private Sub cboItem_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboItem.InitializeLayout
        For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).Hidden = True
        Next
        e.Layout.Bands(0).Columns("ItemName").Hidden = False
        If isAddItem AndAlso cboItem.Rows.Count > 0 Then
            With cboItem.Rows(cboItem.Rows.Count - 1)
                .Appearance.BackColor = ModMain.m_AddColor
                .Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
            End With
        End If
    End Sub

    Private Sub chkGetSubContractor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGetSubContractor.CheckedChanged
        cboSubContractor.Enabled = chkGetSubContractor.Checked
        txtFee.Enabled = chkGetSubContractor.Checked
        If chkGetSubContractor.Checked Then
            cboSubContractor.Focus()
        Else
            cboSubContractor.Value = Nothing
            txtFee.Text = "0"
        End If
    End Sub
End Class