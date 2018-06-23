<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectTime
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.btnExit = New Infragistics.Win.Misc.UltraButton
        Me.btnSave = New Infragistics.Win.Misc.UltraButton
        Me.UltraCalendarLook1 = New Infragistics.Win.UltraWinSchedule.UltraCalendarLook(Me.components)
        Me.UltraCalendarInfo1 = New Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(Me.components)
        Me.UltraCalendarInfo2 = New Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.d_m_To = New Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.d_m_From = New Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.chEditDate = New System.Windows.Forms.CheckBox
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.d_m_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.d_m_From, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraLabel1
        '
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 14.0!
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraLabel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(408, 46)
        Me.UltraLabel1.TabIndex = 1
        Me.UltraLabel1.Text = "CHỌN THỜI GIAN"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid
        Appearance1.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance1
        Me.UltraGroupBox1.Controls.Add(Me.chEditDate)
        Me.UltraGroupBox1.Controls.Add(Me.btnExit)
        Me.UltraGroupBox1.Controls.Add(Me.btnSave)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 261)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(408, 36)
        Me.UltraGroupBox1.TabIndex = 6
        '
        'btnExit
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance4.BackColor2 = System.Drawing.Color.White
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance4.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.Image = Global.MPS.My.Resources.Resources.exit1
        Me.btnExit.Appearance = Appearance4
        Me.btnExit.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance8.BackColor = System.Drawing.Color.Yellow
        Appearance8.BackColor2 = System.Drawing.Color.White
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnExit.HotTrackAppearance = Appearance8
        Me.btnExit.Location = New System.Drawing.Point(303, 6)
        Me.btnExit.Name = "btnExit"
        Appearance11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance11.BackColor2 = System.Drawing.Color.White
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnExit.PressedAppearance = Appearance11
        Me.btnExit.Size = New System.Drawing.Size(99, 25)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Thoát(ESC)"
        Me.ToolTip1.SetToolTip(Me.btnExit, "Thoát")
        Me.btnExit.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnExit.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnSave
        '
        Appearance13.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance13.BackColor2 = System.Drawing.Color.White
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance13.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance13.FontData.BoldAsString = "True"
        Appearance13.ForeColor = System.Drawing.Color.Black
        Appearance13.Image = Global.MPS.My.Resources.Resources.ok2
        Me.btnSave.Appearance = Appearance13
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance14.BackColor = System.Drawing.Color.Yellow
        Appearance14.BackColor2 = System.Drawing.Color.White
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnSave.HotTrackAppearance = Appearance14
        Me.btnSave.Location = New System.Drawing.Point(221, 6)
        Me.btnSave.Name = "btnSave"
        Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance15.BackColor2 = System.Drawing.Color.White
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnSave.PressedAppearance = Appearance15
        Me.btnSave.Size = New System.Drawing.Size(76, 25)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Chọn"
        Me.ToolTip1.SetToolTip(Me.btnSave, "Chọn")
        Me.btnSave.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnSave.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraCalendarInfo1
        '
        Me.UltraCalendarInfo1.DataBindingsForAppointments.BindingContextControl = Me
        Me.UltraCalendarInfo1.DataBindingsForOwners.BindingContextControl = Me
        '
        'UltraCalendarInfo2
        '
        Me.UltraCalendarInfo2.DataBindingsForAppointments.BindingContextControl = Me
        Me.UltraCalendarInfo2.DataBindingsForOwners.BindingContextControl = Me
        '
        'UltraGroupBox2
        '
        Appearance5.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.UltraGroupBox2.Appearance = Appearance5
        Me.UltraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid
        Me.UltraGroupBox2.Controls.Add(Me.d_m_To)
        Me.UltraGroupBox2.Controls.Add(Me.dtTo)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox2.Controls.Add(Me.d_m_From)
        Me.UltraGroupBox2.Controls.Add(Me.dtFrom)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(6, 51)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(396, 206)
        Me.UltraGroupBox2.TabIndex = 7
        '
        'd_m_To
        '
        Me.d_m_To.AllowFocus = False
        Me.d_m_To.AllowMonthPopup = False
        Me.d_m_To.AllowMonthSelection = False
        Me.d_m_To.AllowWeekSelection = False
        Me.d_m_To.BackColor = System.Drawing.SystemColors.Window
        Me.d_m_To.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.d_m_To.CalendarInfo = Me.UltraCalendarInfo2
        Me.d_m_To.CalendarLook = Me.UltraCalendarLook1
        Me.d_m_To.Location = New System.Drawing.Point(213, 52)
        Me.d_m_To.Name = "d_m_To"
        Me.d_m_To.Size = New System.Drawing.Size(153, 138)
        Me.d_m_To.TabIndex = 18
        '
        'dtTo
        '
        Me.dtTo.CustomFormat = "dd/MM/yyyy"
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTo.Location = New System.Drawing.Point(213, 25)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(153, 21)
        Me.dtTo.TabIndex = 17
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(213, 9)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(66, 17)
        Me.UltraLabel3.TabIndex = 16
        Me.UltraLabel3.Text = "Đến ngày"
        '
        'd_m_From
        '
        Me.d_m_From.AllowFocus = False
        Me.d_m_From.AllowMonthPopup = False
        Me.d_m_From.AllowMonthSelection = False
        Me.d_m_From.AllowWeekSelection = False
        Me.d_m_From.BackColor = System.Drawing.SystemColors.Window
        Me.d_m_From.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.d_m_From.CalendarInfo = Me.UltraCalendarInfo1
        Me.d_m_From.CalendarLook = Me.UltraCalendarLook1
        Me.d_m_From.Location = New System.Drawing.Point(28, 52)
        Me.d_m_From.Name = "d_m_From"
        Me.d_m_From.Size = New System.Drawing.Size(153, 138)
        Me.d_m_From.TabIndex = 15
        '
        'dtFrom
        '
        Me.dtFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(28, 25)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(153, 21)
        Me.dtFrom.TabIndex = 14
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(28, 9)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(66, 17)
        Me.UltraLabel2.TabIndex = 13
        Me.UltraLabel2.Text = "Từ ngày"
        '
        'chEditDate
        '
        Me.chEditDate.AutoSize = True
        Me.chEditDate.Location = New System.Drawing.Point(34, 10)
        Me.chEditDate.Name = "chEditDate"
        Me.chEditDate.Size = New System.Drawing.Size(102, 17)
        Me.chEditDate.TabIndex = 7
        Me.chEditDate.Text = "Ngày hiệu chỉnh"
        Me.chEditDate.UseVisualStyleBackColor = True
        Me.chEditDate.Visible = False
        '
        'FrmSelectTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(408, 297)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelectTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VsBMS.Net"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.d_m_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.d_m_From, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnExit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraCalendarInfo1 As Infragistics.Win.UltraWinSchedule.UltraCalendarInfo
    Friend WithEvents UltraCalendarLook1 As Infragistics.Win.UltraWinSchedule.UltraCalendarLook
    Friend WithEvents UltraCalendarInfo2 As Infragistics.Win.UltraWinSchedule.UltraCalendarInfo
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents d_m_From As Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Public WithEvents d_m_To As Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti
    Public WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Public WithEvents chEditDate As System.Windows.Forms.CheckBox
End Class
