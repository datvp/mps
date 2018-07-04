<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDirDevice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDirDevice))
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TV = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton
        Me.btnChoose = New Infragistics.Win.Misc.UltraButton
        Me.lbTemp = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Lb = New System.Windows.Forms.Label
        Me.txtFile = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TV)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(659, 392)
        Me.Panel1.TabIndex = 0
        '
        'TV
        '
        Me.TV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TV.ImageIndex = 0
        Me.TV.ImageList = Me.ImageList1
        Me.TV.Location = New System.Drawing.Point(0, 0)
        Me.TV.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TV.Name = "TV"
        Me.TV.SelectedImageIndex = 0
        Me.TV.Size = New System.Drawing.Size(659, 392)
        Me.TV.TabIndex = 1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ico89.ico")
        Me.ImageList1.Images.SetKeyName(1, "ico82.ico")
        Me.ImageList1.Images.SetKeyName(2, "ico41.ico")
        Me.ImageList1.Images.SetKeyName(3, "ico58.ico")
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnChoose)
        Me.Panel2.Controls.Add(Me.lbTemp)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 470)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(659, 57)
        Me.Panel2.TabIndex = 1
        '
        'btnCancel
        '
        Appearance13.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance13.BackColor2 = System.Drawing.Color.White
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance13.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance13.FontData.BoldAsString = "True"
        Appearance13.ForeColor = System.Drawing.Color.Black
        Appearance13.Image = Global.MPS.My.Resources.Resources.check
        Me.btnCancel.Appearance = Appearance13
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance14.BackColor = System.Drawing.Color.Yellow
        Appearance14.BackColor2 = System.Drawing.Color.White
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnCancel.HotTrackAppearance = Appearance14
        Me.btnCancel.Location = New System.Drawing.Point(512, 10)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance15.BackColor2 = System.Drawing.Color.White
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnCancel.PressedAppearance = Appearance15
        Me.btnCancel.Size = New System.Drawing.Size(132, 34)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Thoát (Esc)"
        Me.btnCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnChoose
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance4.BackColor2 = System.Drawing.Color.White
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance4.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.Image = Global.MPS.My.Resources.Resources.check
        Me.btnChoose.Appearance = Appearance4
        Me.btnChoose.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnChoose.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance5.BackColor = System.Drawing.Color.Yellow
        Appearance5.BackColor2 = System.Drawing.Color.White
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnChoose.HotTrackAppearance = Appearance5
        Me.btnChoose.Location = New System.Drawing.Point(392, 10)
        Me.btnChoose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnChoose.Name = "btnChoose"
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.White
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnChoose.PressedAppearance = Appearance6
        Me.btnChoose.Size = New System.Drawing.Size(112, 34)
        Me.btnChoose.TabIndex = 3
        Me.btnChoose.Text = "Chọn"
        Me.btnChoose.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnChoose.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lbTemp
        '
        Me.lbTemp.AutoSize = True
        Me.lbTemp.Location = New System.Drawing.Point(89, 20)
        Me.lbTemp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTemp.Name = "lbTemp"
        Me.lbTemp.Size = New System.Drawing.Size(90, 16)
        Me.lbTemp.TabIndex = 2
        Me.lbTemp.Text = "Duong dan file"
        Me.lbTemp.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Lb)
        Me.Panel3.Controls.Add(Me.txtFile)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 392)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(659, 78)
        Me.Panel3.TabIndex = 2
        '
        'Lb
        '
        Me.Lb.AutoSize = True
        Me.Lb.Location = New System.Drawing.Point(88, 46)
        Me.Lb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lb.Name = "Lb"
        Me.Lb.Size = New System.Drawing.Size(91, 16)
        Me.Lb.TabIndex = 3
        Me.Lb.Text = "File dang chon"
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(92, 17)
        Me.txtFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(551, 23)
        Me.txtFile.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 47)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "File"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tên file"
        '
        'frmDirDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(659, 527)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDirDevice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lbTemp As System.Windows.Forms.Label
    Friend WithEvents Lb As System.Windows.Forms.Label
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TV As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnChoose As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
End Class
