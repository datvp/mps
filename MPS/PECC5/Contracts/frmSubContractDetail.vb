Public Class frmSubContractDetail
    Private item As Model.MSubContract
    Dim deadline As Date
    Public Overloads Function ShowDialog(ByVal item As Model.MSubContract, ByVal deadline As Date) As Model.MSubContract
        Me.item = item
        Me.deadline = deadline
        Me.ShowDialog()
        Return Me.item
    End Function
    Private Sub frmSubContractDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub LoadInfo(ByVal m As Model.MSubContract)
        txtSubContractorId.Text = m.SubContractId
        txtSubContractorName.Text = m.SubContractName
        txtSubContractValue.Text = Format(m.SubContractValue, ModMain.m_strFormatCur)
        dtSubContractDeadLine.Value = m.SubContractDeadLine
    End Sub
    Private Function setInfo() As Model.MSubContract
        Dim m As New Model.MSubContract
        m.SubContractId = txtSubContractorId.Text
        m.SubContractName = txtSubContractorName.Text
        m.SubContractValue = CDbl(txtSubContractValue.Text)
        m.SubContractDeadLine = dtSubContractDeadLine.Value
        Return m
    End Function
    Private Function CheckOK(ByVal m As Model.MSubContract) As Boolean
        If m.SubContractName = "" Then
            ShowMsg("Chưa nhập tên phụ lục")
            txtSubContractorName.Focus()
            Return False
        End If
        If m.SubContractId = "" Then
            ShowMsg("Chưa nhập mã phụ lục")
            txtSubContractorId.Focus()
            Return False
        End If
        If m.SubContractValue = 0 Then
            ShowMsg("Nhập giá trị cộng thêm")
            txtSubContractValue.Focus()
            Return False
        End If
        If DateDiffM("day", Me.deadline, dtSubContractDeadLine.Value) <= 0 Then
            ShowMsg("Ngày gia hạn thêm phải lớn hơn Ngày hết hạn của Hợp đồng.")
            dtSubContractDeadLine.Focus()
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

    Private Sub txtSubContractValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubContractValue.KeyPress
        ModMain.UltraTextBox_KeyPress(sender, e)
    End Sub

    Private Sub txtSubContractValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubContractValue.Leave
        ModMain.UltraTextBox_LostFocus(sender)
    End Sub

    Private Sub txtSubContractValue_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubContractValue.ValueChanged
        ModMain.UltraTextBox_ValueChanged(sender)
        If txtSubContractValue.Text = "" Then Exit Sub
        lblConvertMoney.Text = ModMain.convertMoney(CDbl(txtSubContractValue.Text))
    End Sub

End Class