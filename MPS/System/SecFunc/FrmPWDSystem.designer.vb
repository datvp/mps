<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPWDSystem
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.btnExit = New Infragistics.Win.Misc.UltraButton
        Me.btnOK = New Infragistics.Win.Misc.UltraButton
        Me.lblTitle = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid
        Me.UltraGroupBox1.Controls.Add(Me.btnExit)
        Me.UltraGroupBox1.Controls.Add(Me.btnOK)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 153)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(432, 57)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'btnExit
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance1.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.Image = Global.MPS.My.Resources.Resources.exit1
        Me.btnExit.Appearance = Appearance1
        Me.btnExit.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Appearance7.BackColor = System.Drawing.Color.Yellow
        Appearance7.BackColor2 = System.Drawing.Color.White
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnExit.HotTrackAppearance = Appearance7
        Me.btnExit.Location = New System.Drawing.Point(290, 13)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExit.Name = "btnExit"
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance8.BackColor2 = System.Drawing.Color.White
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnExit.PressedAppearance = Appearance8
        Me.btnExit.Size = New System.Drawing.Size(120, 31)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Thoát(ESC)"
        Me.btnExit.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnExit.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnOK
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance3.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.Image = Global.MPS.My.Resources.Resources.ok2
        Me.btnOK.Appearance = Appearance3
        Me.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Appearance5.BackColor = System.Drawing.Color.Yellow
        Appearance5.BackColor2 = System.Drawing.Color.White
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnOK.HotTrackAppearance = Appearance5
        Me.btnOK.Location = New System.Drawing.Point(170, 13)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.White
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnOK.PressedAppearance = Appearance6
        Me.btnOK.Size = New System.Drawing.Size(113, 31)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "Xác nhận"
        Me.ToolTip1.SetToolTip(Me.btnOK, "OK")
        Me.btnOK.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnOK.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblTitle
        '
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 14.0!
        Appearance2.Image = Global.MPS.My.Resources.Resources.id_cards
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.lblTitle.Appearance = Appearance2
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(432, 53)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "XÁC NHẬN MẬT KHẨU"
        '
        'UltraGroupBox2
        '
        Appearance4.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.UltraGroupBox2.Appearance = Appearance4
        Me.UltraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid
        Me.UltraGroupBox2.Controls.Add(Me.Label1)
        Me.UltraGroupBox2.Controls.Add(Me.TextBox1)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(19, 69)
        Me.UltraGroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(391, 66)
        Me.UltraGroupBox2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nhập mật khẩu hệ thống"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(170, 20)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(209, 25)
        Me.TextBox1.TabIndex = 4
        '
        'FrmPWDSystem
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(432, 210)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPWDSystem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnExit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblTitle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
