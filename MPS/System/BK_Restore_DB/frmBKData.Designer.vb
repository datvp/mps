<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBKData
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBKData))
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnApply = New Infragistics.Win.Misc.UltraButton
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton
        Me.lblTitle = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtFileBK = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.txtFileBK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ico20.ico")
        Me.ImageList1.Images.SetKeyName(1, "ico31.ico")
        Me.ImageList1.Images.SetKeyName(2, "ico30_40.ico")
        Me.ImageList1.Images.SetKeyName(3, "ico35_24.ico")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tên file"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(432, 60)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Ghi chú : Dự phòng dữ liệu chỉ ghi nhận dữ liệu đến thời điểm hiện tại. Hãy ghi n" & _
            "hớ file dữ liệu dự phòng để thực hiện phục hồi khi có sự cố."
        '
        'btnApply
        '
        Appearance9.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance9.BackColor2 = System.Drawing.Color.White
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance9.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance9.FontData.BoldAsString = "True"
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.Image = Global.MPS.My.Resources.Resources.check
        Me.btnApply.Appearance = Appearance9
        Me.btnApply.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnApply.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance5.BackColor = System.Drawing.Color.Yellow
        Appearance5.BackColor2 = System.Drawing.Color.White
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnApply.HotTrackAppearance = Appearance5
        Me.btnApply.Location = New System.Drawing.Point(254, 11)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnApply.Name = "btnApply"
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.White
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnApply.PressedAppearance = Appearance6
        Me.btnApply.Size = New System.Drawing.Size(115, 34)
        Me.btnApply.TabIndex = 5
        Me.btnApply.Text = "Thực hiện"
        Me.btnApply.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnApply.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnCancel
        '
        Appearance13.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance13.BackColor2 = System.Drawing.Color.White
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance13.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance13.FontData.BoldAsString = "True"
        Appearance13.ForeColor = System.Drawing.Color.Black
        Appearance13.Image = Global.MPS.My.Resources.Resources.exit1
        Me.btnCancel.Appearance = Appearance13
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance14.BackColor = System.Drawing.Color.Yellow
        Appearance14.BackColor2 = System.Drawing.Color.White
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnCancel.HotTrackAppearance = Appearance14
        Me.btnCancel.Location = New System.Drawing.Point(376, 11)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance10.BackColor2 = System.Drawing.Color.White
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnCancel.PressedAppearance = Appearance10
        Me.btnCancel.Size = New System.Drawing.Size(115, 34)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Thoát (ESC)"
        Me.btnCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblTitle
        '
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 14.0!
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.Image = Global.MPS.My.Resources.Resources.database_list132x32_24_bit
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.lblTitle.Appearance = Appearance2
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ImageSize = New System.Drawing.Size(32, 32)
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(514, 57)
        Me.lblTitle.TabIndex = 25
        Me.lblTitle.Text = "SAO LƯU DỰ PHÒNG"
        '
        'UltraGroupBox1
        '
        Appearance15.BackColor = System.Drawing.Color.AliceBlue
        Me.UltraGroupBox1.Appearance = Appearance15
        Me.UltraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Header3D
        Me.UltraGroupBox1.Controls.Add(Me.btnCancel)
        Me.UltraGroupBox1.Controls.Add(Me.btnApply)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 261)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(514, 52)
        Me.UltraGroupBox1.TabIndex = 26
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rectangular3D
        Me.UltraGroupBox2.Controls.Add(Me.txtFileBK)
        Me.UltraGroupBox2.Controls.Add(Me.Label3)
        Me.UltraGroupBox2.Controls.Add(Me.Label1)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(21, 82)
        Me.UltraGroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(470, 156)
        Me.UltraGroupBox2.TabIndex = 27
        '
        'txtFileBK
        '
        Appearance1.TextHAlignAsString = "Center"
        EditorButton1.Appearance = Appearance1
        EditorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button
        EditorButton1.Text = "..."
        EditorButton1.Width = 30
        Me.txtFileBK.ButtonsRight.Add(EditorButton1)
        Me.txtFileBK.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtFileBK.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileBK.Location = New System.Drawing.Point(71, 17)
        Me.txtFileBK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFileBK.MaxLength = 255
        Me.txtFileBK.Name = "txtFileBK"
        Me.txtFileBK.Size = New System.Drawing.Size(373, 25)
        Me.txtFileBK.TabIndex = 11
        '
        'frmBKData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(514, 313)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBKData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.txtFileBK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnApply As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblTitle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtFileBK As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
