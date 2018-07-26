<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubContractDetail
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
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.grpBottom = New Infragistics.Win.Misc.UltraGroupBox
        Me.btnSave = New Infragistics.Win.Misc.UltraButton
        Me.btnExit = New Infragistics.Win.Misc.UltraButton
        Me.lblTitle = New Infragistics.Win.Misc.UltraLabel
        Me.grpMain = New Infragistics.Win.Misc.UltraGroupBox
        Me.lblConvertMoney = New System.Windows.Forms.Label
        Me.txtSubContractValue = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lblUnit = New System.Windows.Forms.Label
        Me.dtSubContractDeadLine = New System.Windows.Forms.DateTimePicker
        Me.txtSubContractorName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtSubContractorId = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.grpBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBottom.SuspendLayout()
        CType(Me.grpMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMain.SuspendLayout()
        CType(Me.txtSubContractValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubContractorName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubContractorId, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBottom
        '
        Me.grpBottom.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid
        Me.grpBottom.Controls.Add(Me.btnSave)
        Me.grpBottom.Controls.Add(Me.btnExit)
        Me.grpBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpBottom.Location = New System.Drawing.Point(0, 254)
        Me.grpBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.grpBottom.Name = "grpBottom"
        Me.grpBottom.Size = New System.Drawing.Size(583, 58)
        Me.grpBottom.TabIndex = 5
        Me.grpBottom.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'btnSave
        '
        Appearance63.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance63.BackColor2 = System.Drawing.Color.White
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance63.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance63.FontData.BoldAsString = "True"
        Appearance63.ForeColor = System.Drawing.Color.Black
        Appearance63.Image = Global.MPS.My.Resources.Resources.Luu_Thoat
        Me.btnSave.Appearance = Appearance63
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance64.BackColor = System.Drawing.Color.Yellow
        Appearance64.BackColor2 = System.Drawing.Color.White
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnSave.HotTrackAppearance = Appearance64
        Me.btnSave.Location = New System.Drawing.Point(295, 13)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnSave.Name = "btnSave"
        Appearance65.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance65.BackColor2 = System.Drawing.Color.White
        Appearance65.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnSave.PressedAppearance = Appearance65
        Me.btnSave.Size = New System.Drawing.Size(117, 38)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Cập nhật"
        Me.btnSave.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnSave.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnExit
        '
        Appearance66.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance66.BackColor2 = System.Drawing.Color.White
        Appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance66.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance66.FontData.BoldAsString = "True"
        Appearance66.ForeColor = System.Drawing.Color.Black
        Appearance66.Image = Global.MPS.My.Resources.Resources.cancl_32
        Me.btnExit.Appearance = Appearance66
        Me.btnExit.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance67.BackColor = System.Drawing.Color.Yellow
        Appearance67.BackColor2 = System.Drawing.Color.White
        Appearance67.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnExit.HotTrackAppearance = Appearance67
        Me.btnExit.Location = New System.Drawing.Point(422, 13)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnExit.Name = "btnExit"
        Appearance68.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance68.BackColor2 = System.Drawing.Color.White
        Appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnExit.PressedAppearance = Appearance68
        Me.btnExit.Size = New System.Drawing.Size(125, 38)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Thoát (Esc)"
        Me.btnExit.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnExit.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblTitle
        '
        Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance12.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance12.FontData.BoldAsString = "True"
        Appearance12.FontData.SizeInPoints = 14.0!
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.Image = Global.MPS.My.Resources.Resources.document_new
        Appearance12.TextHAlignAsString = "Left"
        Appearance12.TextVAlignAsString = "Middle"
        Me.lblTitle.Appearance = Appearance12
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ImageSize = New System.Drawing.Size(32, 32)
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(583, 47)
        Me.lblTitle.TabIndex = 13
        Me.lblTitle.Text = "PHỤ LỤC HỢP ĐỒNG"
        '
        'grpMain
        '
        Me.grpMain.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid
        Me.grpMain.Controls.Add(Me.lblConvertMoney)
        Me.grpMain.Controls.Add(Me.txtSubContractValue)
        Me.grpMain.Controls.Add(Me.lblUnit)
        Me.grpMain.Controls.Add(Me.dtSubContractDeadLine)
        Me.grpMain.Controls.Add(Me.txtSubContractorName)
        Me.grpMain.Controls.Add(Me.txtSubContractorId)
        Me.grpMain.Controls.Add(Me.Label5)
        Me.grpMain.Controls.Add(Me.Label4)
        Me.grpMain.Controls.Add(Me.Label3)
        Me.grpMain.Controls.Add(Me.Label2)
        Appearance16.BorderColor = System.Drawing.Color.Green
        Appearance16.FontData.BoldAsString = "True"
        Me.grpMain.HeaderAppearance = Appearance16
        Me.grpMain.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder
        Me.grpMain.Location = New System.Drawing.Point(12, 65)
        Me.grpMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(553, 186)
        Me.grpMain.TabIndex = 0
        Me.grpMain.Text = "THÔNG TIN PHỤ LỤC"
        Me.grpMain.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'lblConvertMoney
        '
        Me.lblConvertMoney.BackColor = System.Drawing.Color.Transparent
        Me.lblConvertMoney.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblConvertMoney.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConvertMoney.Location = New System.Drawing.Point(1, 147)
        Me.lblConvertMoney.Name = "lblConvertMoney"
        Me.lblConvertMoney.Size = New System.Drawing.Size(551, 38)
        Me.lblConvertMoney.TabIndex = 16
        Me.lblConvertMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSubContractValue
        '
        Appearance69.FontData.BoldAsString = "True"
        Appearance69.TextHAlignAsString = "Right"
        Me.txtSubContractValue.Appearance = Appearance69
        Me.txtSubContractValue.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtSubContractValue.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubContractValue.Location = New System.Drawing.Point(125, 108)
        Me.txtSubContractValue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSubContractValue.MaxLength = 20
        Me.txtSubContractValue.Name = "txtSubContractValue"
        Me.txtSubContractValue.Size = New System.Drawing.Size(144, 25)
        Me.txtSubContractValue.TabIndex = 2
        Me.txtSubContractValue.Text = "0"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.BackColor = System.Drawing.Color.Transparent
        Me.lblUnit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnit.Location = New System.Drawing.Point(275, 110)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(33, 16)
        Me.lblUnit.TabIndex = 15
        Me.lblUnit.Text = "VNĐ"
        '
        'dtSubContractDeadLine
        '
        Me.dtSubContractDeadLine.Location = New System.Drawing.Point(410, 75)
        Me.dtSubContractDeadLine.Name = "dtSubContractDeadLine"
        Me.dtSubContractDeadLine.Size = New System.Drawing.Size(125, 23)
        Me.dtSubContractDeadLine.TabIndex = 4
        '
        'txtSubContractorName
        '
        Me.txtSubContractorName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtSubContractorName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubContractorName.Location = New System.Drawing.Point(125, 41)
        Me.txtSubContractorName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSubContractorName.MaxLength = 255
        Me.txtSubContractorName.Name = "txtSubContractorName"
        Me.txtSubContractorName.Size = New System.Drawing.Size(410, 25)
        Me.txtSubContractorName.TabIndex = 0
        '
        'txtSubContractorId
        '
        Me.txtSubContractorId.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtSubContractorId.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubContractorId.Location = New System.Drawing.Point(125, 74)
        Me.txtSubContractorId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSubContractorId.MaxLength = 50
        Me.txtSubContractorId.Name = "txtSubContractorId"
        Me.txtSubContractorId.Size = New System.Drawing.Size(144, 25)
        Me.txtSubContractorId.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Giá trị cộng thêm"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(285, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Ngày gia hạn thêm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Tên phụ lục"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Mã phụ lục"
        '
        'frmSubContractDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(583, 312)
        Me.Controls.Add(Me.grpMain)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.grpBottom)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSubContractDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSubContractDetail"
        CType(Me.grpBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBottom.ResumeLayout(False)
        CType(Me.grpMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        CType(Me.txtSubContractValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubContractorName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubContractorId, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBottom As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnExit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblTitle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents grpMain As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSubContractorName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtSubContractorId As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtSubContractDeadLine As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSubContractValue As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents lblConvertMoney As System.Windows.Forms.Label
End Class
