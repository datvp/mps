<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTotalReports
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
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance110 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance112 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance113 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance116 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.cmbStore = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.lblTo = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.cboBranch = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboTime = New System.Windows.Forms.ComboBox
        Me.btnView = New Infragistics.Win.Misc.UltraButton
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.lstFunc = New System.Windows.Forms.ListBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.pic1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.cmbStore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.cboBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbStore
        '
        Me.cmbStore.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance108.BackColor = System.Drawing.SystemColors.Window
        Appearance108.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmbStore.DisplayLayout.Appearance = Appearance108
        Me.cmbStore.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.ColHeadersVisible = False
        Me.cmbStore.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.cmbStore.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmbStore.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance109.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance109.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance109.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance109.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbStore.DisplayLayout.GroupByBox.Appearance = Appearance109
        Appearance110.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbStore.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance110
        Me.cmbStore.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance111.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance111.BackColor2 = System.Drawing.SystemColors.Control
        Appearance111.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance111.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbStore.DisplayLayout.GroupByBox.PromptAppearance = Appearance111
        Me.cmbStore.DisplayLayout.MaxColScrollRegions = 1
        Me.cmbStore.DisplayLayout.MaxRowScrollRegions = 1
        Appearance112.BackColor = System.Drawing.SystemColors.Window
        Appearance112.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbStore.DisplayLayout.Override.ActiveCellAppearance = Appearance112
        Appearance113.BackColor = System.Drawing.SystemColors.Highlight
        Appearance113.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmbStore.DisplayLayout.Override.ActiveRowAppearance = Appearance113
        Me.cmbStore.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cmbStore.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance114.BackColor = System.Drawing.SystemColors.Window
        Me.cmbStore.DisplayLayout.Override.CardAreaAppearance = Appearance114
        Appearance115.BorderColor = System.Drawing.Color.Silver
        Appearance115.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmbStore.DisplayLayout.Override.CellAppearance = Appearance115
        Me.cmbStore.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cmbStore.DisplayLayout.Override.CellPadding = 0
        Appearance116.BackColor = System.Drawing.SystemColors.Control
        Appearance116.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance116.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance116.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance116.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbStore.DisplayLayout.Override.GroupByRowAppearance = Appearance116
        Appearance117.TextHAlignAsString = "Left"
        Me.cmbStore.DisplayLayout.Override.HeaderAppearance = Appearance117
        Me.cmbStore.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbStore.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance118.BackColor = System.Drawing.SystemColors.Window
        Appearance118.BorderColor = System.Drawing.Color.Silver
        Me.cmbStore.DisplayLayout.Override.RowAppearance = Appearance118
        Me.cmbStore.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance119.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbStore.DisplayLayout.Override.TemplateAddRowAppearance = Appearance119
        Me.cmbStore.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmbStore.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmbStore.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmbStore.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cmbStore.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbStore.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStore.Location = New System.Drawing.Point(99, 66)
        Me.cmbStore.Name = "cmbStore"
        Me.cmbStore.Size = New System.Drawing.Size(260, 23)
        Me.cmbStore.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Kho hàng"
        '
        'dtFrom
        '
        Me.dtFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtFrom.Enabled = False
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(208, 10)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(100, 21)
        Me.dtFrom.TabIndex = 2
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(314, 13)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(19, 13)
        Me.lblTo.TabIndex = 1
        Me.lblTo.Text = "->"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.UltraLabel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(758, 24)
        Me.Panel2.TabIndex = 3
        '
        'UltraLabel1
        '
        Appearance95.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance95.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance95.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance95.FontData.BoldAsString = "True"
        Appearance95.FontData.SizeInPoints = 12.0!
        Appearance95.ForeColor = System.Drawing.Color.Black
        Appearance95.Image = Global.MPS.My.Resources.Resources.statistics4
        Appearance95.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance95
        Me.UltraLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(758, 24)
        Me.UltraLabel1.TabIndex = 2
        Me.UltraLabel1.Text = "Báo cáo - Thống kê"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.cmbStore)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.cboBranch)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.cboTime)
        Me.Panel4.Controls.Add(Me.btnView)
        Me.Panel4.Controls.Add(Me.dtFrom)
        Me.Panel4.Controls.Add(Me.lblTo)
        Me.Panel4.Controls.Add(Me.dtTo)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 385)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(758, 100)
        Me.Panel4.TabIndex = 12
        '
        'cboBranch
        '
        Me.cboBranch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cboBranch.DisplayLayout.Appearance = Appearance49
        Me.cboBranch.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand2.ColHeadersVisible = False
        Me.cboBranch.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.cboBranch.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cboBranch.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance50.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance50.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance50.BorderColor = System.Drawing.SystemColors.Window
        Me.cboBranch.DisplayLayout.GroupByBox.Appearance = Appearance50
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboBranch.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance51
        Me.cboBranch.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance52.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance52.BackColor2 = System.Drawing.SystemColors.Control
        Appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance52.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboBranch.DisplayLayout.GroupByBox.PromptAppearance = Appearance52
        Me.cboBranch.DisplayLayout.MaxColScrollRegions = 1
        Me.cboBranch.DisplayLayout.MaxRowScrollRegions = 1
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboBranch.DisplayLayout.Override.ActiveCellAppearance = Appearance53
        Appearance54.BackColor = System.Drawing.SystemColors.Highlight
        Appearance54.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cboBranch.DisplayLayout.Override.ActiveRowAppearance = Appearance54
        Me.cboBranch.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cboBranch.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Me.cboBranch.DisplayLayout.Override.CardAreaAppearance = Appearance55
        Appearance56.BorderColor = System.Drawing.Color.Silver
        Appearance56.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cboBranch.DisplayLayout.Override.CellAppearance = Appearance56
        Me.cboBranch.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cboBranch.DisplayLayout.Override.CellPadding = 0
        Appearance57.BackColor = System.Drawing.SystemColors.Control
        Appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance57.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance57.BorderColor = System.Drawing.SystemColors.Window
        Me.cboBranch.DisplayLayout.Override.GroupByRowAppearance = Appearance57
        Appearance58.TextHAlignAsString = "Left"
        Me.cboBranch.DisplayLayout.Override.HeaderAppearance = Appearance58
        Me.cboBranch.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cboBranch.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance75.BackColor = System.Drawing.SystemColors.Window
        Appearance75.BorderColor = System.Drawing.Color.Silver
        Me.cboBranch.DisplayLayout.Override.RowAppearance = Appearance75
        Me.cboBranch.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance76.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cboBranch.DisplayLayout.Override.TemplateAddRowAppearance = Appearance76
        Me.cboBranch.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cboBranch.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cboBranch.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cboBranch.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.cboBranch.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBranch.Location = New System.Drawing.Point(99, 37)
        Me.cboBranch.Name = "cboBranch"
        Me.cboBranch.Size = New System.Drawing.Size(260, 23)
        Me.cboBranch.TabIndex = 69
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Chi nhánh"
        '
        'cboTime
        '
        Me.cboTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTime.FormattingEnabled = True
        Me.cboTime.Items.AddRange(New Object() {"Hôm nay", "Hôm qua", "Tuần này", "Tuần trước", "Tháng này", "Tháng trước", "Năm này", "Năm trước", "Tùy chọn..."})
        Me.cboTime.Location = New System.Drawing.Point(99, 10)
        Me.cboTime.Name = "cboTime"
        Me.cboTime.Size = New System.Drawing.Size(100, 21)
        Me.cboTime.TabIndex = 65
        '
        'btnView
        '
        Appearance84.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance84.BackColor2 = System.Drawing.Color.White
        Appearance84.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance84.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance84.FontData.BoldAsString = "True"
        Appearance84.ForeColor = System.Drawing.Color.Black
        Me.btnView.Appearance = Appearance84
        Me.btnView.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnView.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnView.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance85.BackColor = System.Drawing.Color.Yellow
        Appearance85.BackColor2 = System.Drawing.Color.White
        Appearance85.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnView.HotTrackAppearance = Appearance85
        Me.btnView.Location = New System.Drawing.Point(490, 11)
        Me.btnView.Name = "btnView"
        Appearance86.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance86.BackColor2 = System.Drawing.Color.White
        Appearance86.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnView.PressedAppearance = Appearance86
        Me.btnView.Size = New System.Drawing.Size(77, 25)
        Me.btnView.TabIndex = 21
        Me.btnView.Text = "Xem"
        Me.btnView.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        Me.btnView.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'dtTo
        '
        Me.dtTo.CustomFormat = "dd/MM/yyyy"
        Me.dtTo.Enabled = False
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTo.Location = New System.Drawing.Point(339, 10)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(94, 21)
        Me.dtTo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Thời gian"
        '
        'lstFunc
        '
        Me.lstFunc.BackColor = System.Drawing.Color.White
        Me.lstFunc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstFunc.Dock = System.Windows.Forms.DockStyle.Right
        Me.lstFunc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFunc.FormattingEnabled = True
        Me.lstFunc.ItemHeight = 16
        Me.lstFunc.Location = New System.Drawing.Point(12, 0)
        Me.lstFunc.Name = "lstFunc"
        Me.lstFunc.Size = New System.Drawing.Size(274, 352)
        Me.lstFunc.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.pic1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(286, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(472, 361)
        Me.Panel3.TabIndex = 16
        '
        'pic1
        '
        Me.pic1.AllowDrop = True
        Appearance61.AlphaLevel = CType(30, Short)
        Appearance61.BackColor = System.Drawing.Color.Transparent
        Appearance61.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance61.ImageBackgroundAlpha = Infragistics.Win.Alpha.Opaque
        Appearance61.ImageBackgroundOrigin = Infragistics.Win.ImageBackgroundOrigin.Client
        Appearance61.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        Appearance61.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance61.ImageVAlign = Infragistics.Win.VAlign.Top
        Me.pic1.Appearance = Appearance61
        Me.pic1.AutoSize = True
        Me.pic1.BackColor = System.Drawing.Color.Transparent
        Me.pic1.BorderShadowColor = System.Drawing.Color.Empty
        Me.pic1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded1Etched
        Me.pic1.Cursor = System.Windows.Forms.Cursors.Default
        Me.pic1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pic1.Location = New System.Drawing.Point(0, 0)
        Me.pic1.Name = "pic1"
        Me.pic1.ScaleImage = Infragistics.Win.ScaleImage.Never
        Me.pic1.Size = New System.Drawing.Size(472, 361)
        Me.pic1.TabIndex = 18
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.lstFunc)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(286, 361)
        Me.Panel1.TabIndex = 15
        '
        'frmTotalReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(758, 485)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmTotalReports"
        Me.Text = "frmTotalReports"
        CType(Me.cmbStore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.cboBranch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbStore As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lstFunc As System.Windows.Forms.ListBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pic1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnView As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboTime As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboBranch As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
