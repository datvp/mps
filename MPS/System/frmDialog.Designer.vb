<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.btnDetail = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblMsg = New Infragistics.Win.Misc.UltraLabel
        Me.lblErr = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        CType(Me.lblErr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDetail
        '
        Me.btnDetail.Location = New System.Drawing.Point(12, 78)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(75, 23)
        Me.btnDetail.TabIndex = 0
        Me.btnDetail.Text = "Chi tiết >>"
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(203, 78)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Đóng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Appearance2.TextHAlignAsString = "Center"
        Me.lblMsg.Appearance = Appearance2
        Me.lblMsg.Location = New System.Drawing.Point(12, 17)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(268, 56)
        Me.lblMsg.TabIndex = 2
        '
        'lblErr
        '
        Me.lblErr.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lblErr.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2000
        Me.lblErr.Location = New System.Drawing.Point(12, 116)
        Me.lblErr.Multiline = True
        Me.lblErr.Name = "lblErr"
        Me.lblErr.ReadOnly = True
        Me.lblErr.Scrollbars = System.Windows.Forms.ScrollBars.Vertical
        Me.lblErr.Size = New System.Drawing.Size(266, 99)
        Me.lblErr.TabIndex = 3
        Me.lblErr.UseAppStyling = False
        Me.lblErr.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'frmDialog
        '
        Me.AcceptButton = Me.btnDetail
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(292, 114)
        Me.Controls.Add(Me.lblErr)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDetail)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmShowMsg"
        CType(Me.lblErr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDetail As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblMsg As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblErr As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
