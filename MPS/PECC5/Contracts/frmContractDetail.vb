Public Class frmContractDetail

    Private Sub frmContractDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me)
        ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
    End Sub

    Private Sub txtContractValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContractValue.KeyPress
        ModMain.UltraTextBox_KeyPress(sender, e)
    End Sub

    Private Sub txtContractValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContractValue.Leave
        ModMain.UltraTextBox_LostFocus(sender)
    End Sub

    Private Sub txtContractValue_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContractValue.ValueChanged
        ModMain.UltraTextBox_ValueChanged(sender)
        If txtContractValue.Text = "" Then Exit Sub
        lblConvertMoney.Text = ModMain.convertMoney(CDbl(txtContractValue.Text))
    End Sub
End Class