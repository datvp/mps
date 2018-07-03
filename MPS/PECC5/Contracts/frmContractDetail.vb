Public Class frmContractDetail

    Private Sub frmContractDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me)
        ModMain.BlueButton(btnSave)
        ModMain.GreenButton(btnExit)
    End Sub
End Class