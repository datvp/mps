<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChangePWD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.btnExit = New Infragistics.Win.Misc.UltraButton
        Me.btnSave = New Infragistics.Win.Misc.UltraButton
        Me.btnReset = New Infragistics.Win.Misc.UltraButton
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtConfirm = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPWD = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtPWDOld = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.txtConfirm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPWD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPWDOld, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid
        Me.UltraGroupBox1.Controls.Add(Me.btnExit)
        Me.UltraGroupBox1.Controls.Add(Me.btnSave)
        Me.UltraGroupBox1.Controls.Add(Me.btnReset)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 262)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(492, 44)
        Me.UltraGroupBox1.TabIndex = 9
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'btnExit
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance3.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.Image = Global.MPS.My.Resources.Resources.exit1
        Me.btnExit.Appearance = Appearance3
        Me.btnExit.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Appearance11.BackColor = System.Drawing.Color.Yellow
        Appearance11.BackColor2 = System.Drawing.Color.White
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnExit.HotTrackAppearance = Appearance11
        Me.btnExit.Location = New System.Drawing.Point(349, 8)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExit.Name = "btnExit"
        Appearance12.BackColor = System.Drawing.Color.Yellow
        Appearance12.BackColor2 = System.Drawing.Color.White
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnExit.PressedAppearance = Appearance12
        Me.btnExit.Size = New System.Drawing.Size(118, 31)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Thoát (ESC)"
        Me.ToolTip1.SetToolTip(Me.btnExit, "Esc")
        Me.btnExit.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnExit.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnSave
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance4.BackColor2 = System.Drawing.Color.White
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance4.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.Image = Global.MPS.My.Resources.Resources.disk_blue
        Me.btnSave.Appearance = Appearance4
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Appearance9.BackColor = System.Drawing.Color.Yellow
        Appearance9.BackColor2 = System.Drawing.Color.White
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnSave.HotTrackAppearance = Appearance9
        Me.btnSave.Location = New System.Drawing.Point(256, 8)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance10.BackColor2 = System.Drawing.Color.White
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnSave.PressedAppearance = Appearance10
        Me.btnSave.Size = New System.Drawing.Size(89, 31)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Lưu(F2)"
        Me.ToolTip1.SetToolTip(Me.btnSave, "F2")
        Me.btnSave.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnSave.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnReset
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance5.BackColor2 = System.Drawing.Color.White
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance5.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.Image = Global.MPS.My.Resources.Resources.refresh1
        Me.btnReset.Appearance = Appearance5
        Me.btnReset.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Appearance7.BackColor = System.Drawing.Color.Yellow
        Appearance7.BackColor2 = System.Drawing.Color.White
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnReset.HotTrackAppearance = Appearance7
        Me.btnReset.Location = New System.Drawing.Point(158, 8)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReset.Name = "btnReset"
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance8.BackColor2 = System.Drawing.Color.White
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnReset.PressedAppearance = Appearance8
        Me.btnReset.Size = New System.Drawing.Size(93, 31)
        Me.btnReset.TabIndex = 2
        Me.btnReset.Text = "Làm mới"
        Me.ToolTip1.SetToolTip(Me.btnReset, "Reset")
        Me.btnReset.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnReset.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        Me.btnReset.Visible = False
        '
        'UltraLabel1
        '
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 14.0!
        Appearance2.Image = Global.MPS.My.Resources.Resources.key1
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraLabel1.ImageSize = New System.Drawing.Size(32, 32)
        Me.UltraLabel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraLabel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(492, 57)
        Me.UltraLabel1.TabIndex = 0
        Me.UltraLabel1.Text = "ĐỔI MẬT KHẨU"
        '
        'UltraGroupBox2
        '
        Appearance6.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.UltraGroupBox2.Appearance = Appearance6
        Me.UltraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid
        Me.UltraGroupBox2.Controls.Add(Me.txtConfirm)
        Me.UltraGroupBox2.Controls.Add(Me.Label4)
        Me.UltraGroupBox2.Controls.Add(Me.txtPWD)
        Me.UltraGroupBox2.Controls.Add(Me.txtPWDOld)
        Me.UltraGroupBox2.Controls.Add(Me.Label1)
        Me.UltraGroupBox2.Controls.Add(Me.txtUID)
        Me.UltraGroupBox2.Controls.Add(Me.Label2)
        Me.UltraGroupBox2.Controls.Add(Me.Label3)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(24, 77)
        Me.UltraGroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(443, 167)
        Me.UltraGroupBox2.TabIndex = 10
        '
        'txtConfirm
        '
        Me.txtConfirm.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirm.Location = New System.Drawing.Point(152, 120)
        Me.txtConfirm.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtConfirm.MaxLength = 255
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirm.Size = New System.Drawing.Size(262, 25)
        Me.txtConfirm.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Xác nhận (*)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPWD
        '
        Me.txtPWD.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPWD.Location = New System.Drawing.Point(152, 86)
        Me.txtPWD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPWD.MaxLength = 255
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWD.Size = New System.Drawing.Size(262, 25)
        Me.txtPWD.TabIndex = 14
        '
        'txtPWDOld
        '
        Me.txtPWDOld.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPWDOld.Location = New System.Drawing.Point(152, 52)
        Me.txtPWDOld.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPWDOld.MaxLength = 255
        Me.txtPWDOld.Name = "txtPWDOld"
        Me.txtPWDOld.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWDOld.Size = New System.Drawing.Size(262, 25)
        Me.txtPWDOld.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Tên người dùng (*)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUID
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.txtUID.Appearance = Appearance1
        Me.txtUID.BackColor = System.Drawing.Color.White
        Me.txtUID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUID.Location = New System.Drawing.Point(152, 18)
        Me.txtUID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtUID.MaxLength = 50
        Me.txtUID.Name = "txtUID"
        Me.txtUID.ReadOnly = True
        Me.txtUID.Size = New System.Drawing.Size(262, 25)
        Me.txtUID.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Mật khẩu cũ (*)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Mật khẩu mới (*)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmChangePWD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(492, 306)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmChangePWD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.txtConfirm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPWD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPWDOld, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnExit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnReset As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtConfirm As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPWD As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtPWDOld As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
