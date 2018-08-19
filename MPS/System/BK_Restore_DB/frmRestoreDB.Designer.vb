<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRestoreDB
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
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFileBK = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtdirData = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton
        Me.btnApply = New Infragistics.Win.Misc.UltraButton
        Me.btnBrown1 = New Infragistics.Win.Misc.UltraButton
        Me.btnBrown2 = New Infragistics.Win.Misc.UltraButton
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.RMDF = New System.Windows.Forms.RadioButton
        Me.RBK = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.grpAction = New Infragistics.Win.Misc.UltraGroupBox
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.grpAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAction.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File dữ liệu dự phòng"
        '
        'txtFileBK
        '
        Me.txtFileBK.Location = New System.Drawing.Point(156, 49)
        Me.txtFileBK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFileBK.Name = "txtFileBK"
        Me.txtFileBK.Size = New System.Drawing.Size(256, 23)
        Me.txtFileBK.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Thu mực chứa dữ liệu"
        '
        'txtdirData
        '
        Me.txtdirData.Location = New System.Drawing.Point(156, 84)
        Me.txtdirData.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtdirData.Name = "txtdirData"
        Me.txtdirData.Size = New System.Drawing.Size(256, 23)
        Me.txtdirData.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(19, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(407, 58)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Ghi chú : Hãy dự phòng dữ liệu trước khi thực hiện phục hồi (Phục hồi dữ liệu có " & _
            "thể bị mất dữ liệu hiện tại)"
        '
        'btnCancel
        '
        Appearance11.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance11.BackColor2 = System.Drawing.Color.White
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance11.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance11.FontData.BoldAsString = "True"
        Appearance11.ForeColor = System.Drawing.Color.Black
        Appearance11.Image = Global.MPS.My.Resources.Resources.exit1
        Me.btnCancel.Appearance = Appearance11
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance12.BackColor = System.Drawing.Color.Yellow
        Appearance12.BackColor2 = System.Drawing.Color.White
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnCancel.HotTrackAppearance = Appearance12
        Me.btnCancel.Location = New System.Drawing.Point(368, 11)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Appearance16.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance16.BackColor2 = System.Drawing.Color.White
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnCancel.PressedAppearance = Appearance16
        Me.btnCancel.Size = New System.Drawing.Size(115, 34)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Thoát (Esc)"
        Me.btnCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnApply
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance4.BackColor2 = System.Drawing.Color.White
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance4.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.Image = Global.MPS.My.Resources.Resources.check
        Me.btnApply.Appearance = Appearance4
        Me.btnApply.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnApply.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance17.BackColor = System.Drawing.Color.Yellow
        Appearance17.BackColor2 = System.Drawing.Color.White
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnApply.HotTrackAppearance = Appearance17
        Me.btnApply.Location = New System.Drawing.Point(247, 11)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnApply.Name = "btnApply"
        Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance18.BackColor2 = System.Drawing.Color.White
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnApply.PressedAppearance = Appearance18
        Me.btnApply.Size = New System.Drawing.Size(115, 34)
        Me.btnApply.TabIndex = 7
        Me.btnApply.Text = "Thực hiện"
        Me.btnApply.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnApply.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnBrown1
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance7.BackColor2 = System.Drawing.Color.White
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance7.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance7.FontData.BoldAsString = "True"
        Appearance7.ForeColor = System.Drawing.Color.Black
        Me.btnBrown1.Appearance = Appearance7
        Me.btnBrown1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnBrown1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance8.BackColor = System.Drawing.Color.Yellow
        Appearance8.BackColor2 = System.Drawing.Color.White
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnBrown1.HotTrackAppearance = Appearance8
        Me.btnBrown1.Location = New System.Drawing.Point(420, 49)
        Me.btnBrown1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrown1.Name = "btnBrown1"
        Appearance19.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance19.BackColor2 = System.Drawing.Color.White
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnBrown1.PressedAppearance = Appearance19
        Me.btnBrown1.Size = New System.Drawing.Size(31, 23)
        Me.btnBrown1.TabIndex = 2
        Me.btnBrown1.Text = "..."
        Me.btnBrown1.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnBrown1.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnBrown2
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance1.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.ForeColor = System.Drawing.Color.Black
        Me.btnBrown2.Appearance = Appearance1
        Me.btnBrown2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnBrown2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance20.BackColor = System.Drawing.Color.Yellow
        Appearance20.BackColor2 = System.Drawing.Color.White
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnBrown2.HotTrackAppearance = Appearance20
        Me.btnBrown2.Location = New System.Drawing.Point(420, 84)
        Me.btnBrown2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrown2.Name = "btnBrown2"
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnBrown2.PressedAppearance = Appearance3
        Me.btnBrown2.Size = New System.Drawing.Size(31, 23)
        Me.btnBrown2.TabIndex = 5
        Me.btnBrown2.Text = "..."
        Me.btnBrown2.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnBrown2.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraLabel1
        '
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 14.0!
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.Image = Global.MPS.My.Resources.Resources.data
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.ImageSize = New System.Drawing.Size(32, 32)
        Me.UltraLabel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraLabel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(498, 57)
        Me.UltraLabel1.TabIndex = 26
        Me.UltraLabel1.Text = "PHỤC HỒI DỮ LIỆU"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rectangular3D
        Me.UltraGroupBox1.Controls.Add(Me.RMDF)
        Me.UltraGroupBox1.Controls.Add(Me.RBK)
        Me.UltraGroupBox1.Controls.Add(Me.Label4)
        Me.UltraGroupBox1.Controls.Add(Me.txtdirData)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.btnBrown2)
        Me.UltraGroupBox1.Controls.Add(Me.txtFileBK)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Controls.Add(Me.btnBrown1)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(11, 66)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(472, 213)
        Me.UltraGroupBox1.TabIndex = 27
        '
        'RMDF
        '
        Me.RMDF.AutoSize = True
        Me.RMDF.Location = New System.Drawing.Point(206, 7)
        Me.RMDF.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RMDF.Name = "RMDF"
        Me.RMDF.Size = New System.Drawing.Size(129, 20)
        Me.RMDF.TabIndex = 9
        Me.RMDF.Text = "File dữ liệu (.mdf)"
        Me.RMDF.UseVisualStyleBackColor = True
        '
        'RBK
        '
        Me.RBK.AutoSize = True
        Me.RBK.Checked = True
        Me.RBK.Location = New System.Drawing.Point(22, 7)
        Me.RBK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RBK.Name = "RBK"
        Me.RBK.Size = New System.Drawing.Size(124, 20)
        Me.RBK.TabIndex = 8
        Me.RBK.TabStop = True
        Me.RBK.Text = "File backup(.bak)"
        Me.RBK.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(153, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Ví dụ :  *. bak , *. mdf"
        '
        'grpAction
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Me.grpAction.Appearance = Appearance15
        Me.grpAction.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Header3D
        Me.grpAction.Controls.Add(Me.btnCancel)
        Me.grpAction.Controls.Add(Me.btnApply)
        Me.grpAction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpAction.Location = New System.Drawing.Point(0, 287)
        Me.grpAction.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpAction.Name = "grpAction"
        Me.grpAction.Size = New System.Drawing.Size(498, 58)
        Me.grpAction.TabIndex = 28
        Me.grpAction.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'frmRestoreDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(498, 345)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.grpAction)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRestoreDB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.grpAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAction.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFileBK As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdirData As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnApply As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnBrown1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnBrown2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grpAction As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RMDF As System.Windows.Forms.RadioButton
    Friend WithEvents RBK As System.Windows.Forms.RadioButton
End Class
