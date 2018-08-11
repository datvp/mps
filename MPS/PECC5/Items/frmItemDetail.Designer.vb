<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemDetail
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
        Me.grpBottom = New Infragistics.Win.Misc.UltraGroupBox
        Me.btnSave = New Infragistics.Win.Misc.UltraButton
        Me.btnExit = New Infragistics.Win.Misc.UltraButton
        Me.lblTitle = New Infragistics.Win.Misc.UltraLabel
        Me.grpMain = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtNote = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtItemName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtItemId = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.grpBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBottom.SuspendLayout()
        CType(Me.grpMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMain.SuspendLayout()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItemName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItemId, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBottom
        '
        Me.grpBottom.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid
        Me.grpBottom.Controls.Add(Me.btnSave)
        Me.grpBottom.Controls.Add(Me.btnExit)
        Me.grpBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpBottom.Location = New System.Drawing.Point(0, 277)
        Me.grpBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.grpBottom.Name = "grpBottom"
        Me.grpBottom.Size = New System.Drawing.Size(485, 58)
        Me.grpBottom.TabIndex = 11
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
        Me.btnSave.Location = New System.Drawing.Point(201, 13)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnSave.Name = "btnSave"
        Appearance65.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance65.BackColor2 = System.Drawing.Color.White
        Appearance65.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnSave.PressedAppearance = Appearance65
        Me.btnSave.Size = New System.Drawing.Size(117, 38)
        Me.btnSave.TabIndex = 11
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
        Me.btnExit.Location = New System.Drawing.Point(328, 13)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnExit.Name = "btnExit"
        Appearance68.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance68.BackColor2 = System.Drawing.Color.White
        Appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnExit.PressedAppearance = Appearance68
        Me.btnExit.Size = New System.Drawing.Size(125, 38)
        Me.btnExit.TabIndex = 12
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
        Me.lblTitle.Size = New System.Drawing.Size(485, 47)
        Me.lblTitle.TabIndex = 13
        Me.lblTitle.Text = "HẠNG MỤC"
        '
        'grpMain
        '
        Me.grpMain.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid
        Me.grpMain.Controls.Add(Me.txtNote)
        Me.grpMain.Controls.Add(Me.txtItemName)
        Me.grpMain.Controls.Add(Me.txtItemId)
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
        Me.grpMain.Size = New System.Drawing.Size(461, 208)
        Me.grpMain.TabIndex = 0
        Me.grpMain.Text = "THÔNG TIN CHÍNH"
        Me.grpMain.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'txtNote
        '
        Me.txtNote.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNote.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(113, 108)
        Me.txtNote.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNote.MaxLength = 500
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(328, 77)
        Me.txtNote.TabIndex = 12
        '
        'txtItemName
        '
        Me.txtItemName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtItemName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(113, 41)
        Me.txtItemName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtItemName.MaxLength = 255
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(328, 25)
        Me.txtItemName.TabIndex = 0
        '
        'txtItemId
        '
        Me.txtItemId.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtItemId.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemId.Location = New System.Drawing.Point(113, 74)
        Me.txtItemId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtItemId.MaxLength = 50
        Me.txtItemId.Name = "txtItemId"
        Me.txtItemId.Size = New System.Drawing.Size(144, 25)
        Me.txtItemId.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Ghi chú"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Tên hạng mục"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Mã hạng mục"
        '
        'frmItemDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(485, 335)
        Me.Controls.Add(Me.grpMain)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.grpBottom)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmItemDetail"
        CType(Me.grpBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBottom.ResumeLayout(False)
        CType(Me.grpMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItemName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItemId, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBottom As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnExit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblTitle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents grpMain As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtItemId As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNote As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
