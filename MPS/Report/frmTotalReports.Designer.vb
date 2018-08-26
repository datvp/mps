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
        Me.components = New System.ComponentModel.Container
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblTitle = New Infragistics.Win.Misc.UltraLabel
        Me.pnlCondition = New System.Windows.Forms.Panel
        Me.grpLineBorder = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboObject = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.lblObject = New System.Windows.Forms.Label
        Me.cboTime = New System.Windows.Forms.ComboBox
        Me.btnView = New Infragistics.Win.Misc.UltraButton
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.lblTime = New System.Windows.Forms.Label
        Me.lstFunc = New System.Windows.Forms.ListBox
        Me.pnlListReportName = New System.Windows.Forms.Panel
        Me.CollapsibleSplitter2 = New NJFLib.Controls.CollapsibleSplitter
        Me.Grid = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ctMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.T_ExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.T_Print = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel2.SuspendLayout()
        Me.pnlCondition.SuspendLayout()
        CType(Me.grpLineBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboObject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListReportName.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtFrom
        '
        Me.dtFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtFrom.Enabled = False
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(70, 50)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(121, 23)
        Me.dtFrom.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblTitle)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(758, 24)
        Me.Panel2.TabIndex = 3
        '
        'lblTitle
        '
        Appearance95.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance95.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance95.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance95.FontData.BoldAsString = "True"
        Appearance95.FontData.SizeInPoints = 12.0!
        Appearance95.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Appearance95.Image = Global.MPS.My.Resources.Resources.statistics4
        Appearance95.TextVAlignAsString = "Middle"
        Me.lblTitle.Appearance = Appearance95
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(758, 24)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "Thống kê"
        '
        'pnlCondition
        '
        Me.pnlCondition.AutoScroll = True
        Me.pnlCondition.BackColor = System.Drawing.Color.Transparent
        Me.pnlCondition.Controls.Add(Me.grpLineBorder)
        Me.pnlCondition.Controls.Add(Me.cboObject)
        Me.pnlCondition.Controls.Add(Me.lblObject)
        Me.pnlCondition.Controls.Add(Me.cboTime)
        Me.pnlCondition.Controls.Add(Me.btnView)
        Me.pnlCondition.Controls.Add(Me.dtFrom)
        Me.pnlCondition.Controls.Add(Me.dtTo)
        Me.pnlCondition.Controls.Add(Me.lblTime)
        Me.pnlCondition.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCondition.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCondition.Location = New System.Drawing.Point(20, 300)
        Me.pnlCondition.Name = "pnlCondition"
        Me.pnlCondition.Size = New System.Drawing.Size(325, 161)
        Me.pnlCondition.TabIndex = 12
        '
        'grpLineBorder
        '
        Me.grpLineBorder.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid
        Me.grpLineBorder.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpLineBorder.Location = New System.Drawing.Point(0, 0)
        Me.grpLineBorder.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpLineBorder.Name = "grpLineBorder"
        Me.grpLineBorder.Size = New System.Drawing.Size(325, 1)
        Me.grpLineBorder.TabIndex = 70
        Me.grpLineBorder.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'cboObject
        '
        Me.cboObject.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cboObject.DisplayLayout.Appearance = Appearance49
        Me.cboObject.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.ColHeadersVisible = False
        Me.cboObject.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.cboObject.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cboObject.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance50.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance50.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance50.BorderColor = System.Drawing.SystemColors.Window
        Me.cboObject.DisplayLayout.GroupByBox.Appearance = Appearance50
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboObject.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance51
        Me.cboObject.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance52.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance52.BackColor2 = System.Drawing.SystemColors.Control
        Appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance52.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboObject.DisplayLayout.GroupByBox.PromptAppearance = Appearance52
        Me.cboObject.DisplayLayout.MaxColScrollRegions = 1
        Me.cboObject.DisplayLayout.MaxRowScrollRegions = 1
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboObject.DisplayLayout.Override.ActiveCellAppearance = Appearance53
        Appearance54.BackColor = System.Drawing.SystemColors.Highlight
        Appearance54.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cboObject.DisplayLayout.Override.ActiveRowAppearance = Appearance54
        Me.cboObject.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cboObject.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Me.cboObject.DisplayLayout.Override.CardAreaAppearance = Appearance55
        Appearance56.BorderColor = System.Drawing.Color.Silver
        Appearance56.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cboObject.DisplayLayout.Override.CellAppearance = Appearance56
        Me.cboObject.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cboObject.DisplayLayout.Override.CellPadding = 0
        Appearance57.BackColor = System.Drawing.SystemColors.Control
        Appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance57.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance57.BorderColor = System.Drawing.SystemColors.Window
        Me.cboObject.DisplayLayout.Override.GroupByRowAppearance = Appearance57
        Appearance58.TextHAlignAsString = "Left"
        Me.cboObject.DisplayLayout.Override.HeaderAppearance = Appearance58
        Me.cboObject.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cboObject.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance75.BackColor = System.Drawing.SystemColors.Window
        Appearance75.BorderColor = System.Drawing.Color.Silver
        Me.cboObject.DisplayLayout.Override.RowAppearance = Appearance75
        Me.cboObject.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance76.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cboObject.DisplayLayout.Override.TemplateAddRowAppearance = Appearance76
        Me.cboObject.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cboObject.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cboObject.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cboObject.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboObject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboObject.Location = New System.Drawing.Point(70, 80)
        Me.cboObject.Name = "cboObject"
        Me.cboObject.Size = New System.Drawing.Size(252, 23)
        Me.cboObject.TabIndex = 69
        Me.cboObject.Visible = False
        '
        'lblObject
        '
        Me.lblObject.AutoSize = True
        Me.lblObject.Location = New System.Drawing.Point(5, 82)
        Me.lblObject.Name = "lblObject"
        Me.lblObject.Size = New System.Drawing.Size(59, 16)
        Me.lblObject.TabIndex = 68
        Me.lblObject.Text = "Nhà thầu"
        Me.lblObject.Visible = False
        '
        'cboTime
        '
        Me.cboTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTime.FormattingEnabled = True
        Me.cboTime.Items.AddRange(New Object() {"Hôm nay", "Hôm qua", "Tuần này", "Tuần trước", "Tháng này", "Tháng trước", "Năm này", "Năm trước", "Tùy chọn..."})
        Me.cboTime.Location = New System.Drawing.Point(70, 19)
        Me.cboTime.Name = "cboTime"
        Me.cboTime.Size = New System.Drawing.Size(121, 24)
        Me.cboTime.TabIndex = 65
        '
        'btnView
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance4.BackColor2 = System.Drawing.Color.White
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.HorizontalBump
        Appearance4.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.Image = Global.MPS.My.Resources.Resources.view
        Me.btnView.Appearance = Appearance4
        Me.btnView.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton
        Me.btnView.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnView.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance12.BackColor = System.Drawing.Color.Yellow
        Appearance12.BackColor2 = System.Drawing.Color.White
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom37
        Me.btnView.HotTrackAppearance = Appearance12
        Me.btnView.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnView.Location = New System.Drawing.Point(70, 109)
        Me.btnView.Name = "btnView"
        Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance13.BackColor2 = System.Drawing.Color.White
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.btnView.PressedAppearance = Appearance13
        Me.btnView.Size = New System.Drawing.Size(121, 38)
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
        Me.dtTo.Location = New System.Drawing.Point(201, 50)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(121, 23)
        Me.dtTo.TabIndex = 3
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(5, 19)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(61, 16)
        Me.lblTime.TabIndex = 64
        Me.lblTime.Text = "Thời gian"
        '
        'lstFunc
        '
        Me.lstFunc.BackColor = System.Drawing.Color.White
        Me.lstFunc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstFunc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFunc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFunc.FormattingEnabled = True
        Me.lstFunc.HorizontalExtent = 325
        Me.lstFunc.HorizontalScrollbar = True
        Me.lstFunc.ItemHeight = 16
        Me.lstFunc.Location = New System.Drawing.Point(20, 10)
        Me.lstFunc.Name = "lstFunc"
        Me.lstFunc.Size = New System.Drawing.Size(325, 288)
        Me.lstFunc.TabIndex = 1
        '
        'pnlListReportName
        '
        Me.pnlListReportName.BackColor = System.Drawing.Color.Transparent
        Me.pnlListReportName.Controls.Add(Me.lstFunc)
        Me.pnlListReportName.Controls.Add(Me.pnlCondition)
        Me.pnlListReportName.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlListReportName.Location = New System.Drawing.Point(0, 24)
        Me.pnlListReportName.Name = "pnlListReportName"
        Me.pnlListReportName.Padding = New System.Windows.Forms.Padding(20, 10, 10, 0)
        Me.pnlListReportName.Size = New System.Drawing.Size(355, 461)
        Me.pnlListReportName.TabIndex = 15
        '
        'CollapsibleSplitter2
        '
        Me.CollapsibleSplitter2.AnimationDelay = 20
        Me.CollapsibleSplitter2.AnimationStep = 20
        Me.CollapsibleSplitter2.BackColor = System.Drawing.SystemColors.Control
        Me.CollapsibleSplitter2.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.CollapsibleSplitter2.ControlToHide = Me.pnlListReportName
        Me.CollapsibleSplitter2.ExpandParentForm = False
        Me.CollapsibleSplitter2.Location = New System.Drawing.Point(355, 24)
        Me.CollapsibleSplitter2.Name = "CollapsibleSplitter2"
        Me.CollapsibleSplitter2.TabIndex = 17
        Me.CollapsibleSplitter2.TabStop = False
        Me.CollapsibleSplitter2.UseAnimations = False
        Me.CollapsibleSplitter2.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'Grid
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.Color.Transparent
        Appearance1.BorderColor2 = System.Drawing.Color.Transparent
        Me.Grid.DisplayLayout.Appearance = Appearance1
        UltraGridBand2.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid
        UltraGridBand2.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption
        UltraGridBand2.Override.RowAppearance = Appearance8
        Me.Grid.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.Grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.Grid.DisplayLayout.EmptyRowSettings.ShowEmptyRows = True
        Me.Grid.DisplayLayout.GroupByBox.Hidden = True
        Me.Grid.DisplayLayout.InterBandSpacing = 10
        Me.Grid.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid.DisplayLayout.MaxRowScrollRegions = 1
        Appearance14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid.DisplayLayout.Override.ActiveCellAppearance = Appearance14
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.BackColor2 = System.Drawing.Color.Transparent
        Appearance7.FontData.BoldAsString = "True"
        Me.Grid.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.Grid.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        Me.Grid.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.Grid.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.Grid.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.DisplayLayout.Override.FilterRowAppearance = Appearance15
        Me.Grid.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance3.BackColor = System.Drawing.Color.AliceBlue
        Appearance3.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.TextHAlignAsString = "Left"
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.Grid.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.[Select]
        Appearance17.BackColor = System.Drawing.Color.AliceBlue
        Me.Grid.DisplayLayout.Override.RowAlternateAppearance = Appearance17
        Appearance5.BackColor = System.Drawing.Color.AliceBlue
        Appearance5.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.Grid.DisplayLayout.Override.RowSelectorAppearance = Appearance5
        Me.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid.DisplayLayout.Override.RowSelectorWidth = 12
        Me.Grid.DisplayLayout.Override.RowSpacingBefore = 0
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.ForeColor = System.Drawing.Color.Black
        Me.Grid.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid.Location = New System.Drawing.Point(363, 24)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(395, 461)
        Me.Grid.TabIndex = 44
        '
        'ctMenu
        '
        Me.ctMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.T_ExportExcel, Me.T_Print})
        Me.ctMenu.Name = "ctMenu"
        Me.ctMenu.Size = New System.Drawing.Size(141, 48)
        '
        'T_ExportExcel
        '
        Me.T_ExportExcel.Image = Global.MPS.My.Resources.Resources.Excel2002
        Me.T_ExportExcel.Name = "T_ExportExcel"
        Me.T_ExportExcel.Size = New System.Drawing.Size(140, 22)
        Me.T_ExportExcel.Text = "Xuất ra Excel"
        '
        'T_Print
        '
        Me.T_Print.Image = Global.MPS.My.Resources.Resources.printer
        Me.T_Print.Name = "T_Print"
        Me.T_Print.Size = New System.Drawing.Size(140, 22)
        Me.T_Print.Text = "In trực tiếp"
        '
        'frmTotalReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(758, 485)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.CollapsibleSplitter2)
        Me.Controls.Add(Me.pnlListReportName)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmTotalReports"
        Me.Text = "frmTotalReports"
        Me.Panel2.ResumeLayout(False)
        Me.pnlCondition.ResumeLayout(False)
        Me.pnlCondition.PerformLayout()
        CType(Me.grpLineBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboObject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListReportName.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents pnlCondition As System.Windows.Forms.Panel
    Friend WithEvents lstFunc As System.Windows.Forms.ListBox
    Friend WithEvents pnlListReportName As System.Windows.Forms.Panel
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnView As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboTime As System.Windows.Forms.ComboBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents cboObject As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents lblObject As System.Windows.Forms.Label
    Friend WithEvents CollapsibleSplitter2 As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents Grid As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpLineBorder As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ctMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents T_ExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents T_Print As System.Windows.Forms.ToolStripMenuItem
End Class
