Public Class frmPaymentDetail
    Private item As Model.MContractPayment
    Dim dtCreated As Date
    Public Overloads Function ShowDialog(ByVal item As Model.MContractPayment, ByVal dtCreated As Date) As Model.MContractPayment
        Me.item = item
        Me.dtCreated = dtCreated
        Me.ShowDialog()
        Return Me.item
    End Function
    Private Sub frmPaymentDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ModMain.SetTitle(Me, lblTitle.Text)
        ModMain.GreenButton(btnExit, ModMain.m_CancelIcon)
        If Me.item IsNot Nothing Then
            Me.LoadInfo(Me.item)
            ModMain.BlueButton(btnSave, ModMain.m_SaveIcon)
            btnSave.Text = "Cập nhật"
        Else
            ModMain.BlueButton(btnSave, ModMain.m_AddIcon)
            btnSave.Text = "Thêm"
        End If
    End Sub
    Private Sub LoadInfo(ByVal m As Model.MContractPayment)
        txtPaymentId.Text = m.PaymentId
        txtPaymentName.Text = m.PaymentName
        txtPaymentTotal.Text = Format(m.PaymentTotal, ModMain.m_strFormatCur)
        dtPaymentDate.Value = m.PaymentDate
        lblStatus.Text = m.PaymentStatus
    End Sub
    Private Function setInfo() As Model.MContractPayment
        Dim m As New Model.MContractPayment
        m.PaymentId = txtPaymentId.Text
        m.PaymentName = txtPaymentName.Text
        m.PaymentTotal = CDbl(txtPaymentTotal.Text)
        m.PaymentDate = dtPaymentDate.Value
        m.PaymentStatus = "Waiting"
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
End Class