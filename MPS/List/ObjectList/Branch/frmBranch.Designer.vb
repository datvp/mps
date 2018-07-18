<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBranch
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("tool1")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnAdd")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnEdit")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnDel")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnAdd")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnEdit")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnDel")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Grid = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LabelBottom = New Infragistics.Win.Misc.UltraLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me._Panel2_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.tbManager = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._Panel2_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._Panel2_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._Panel2_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.ctMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.T_Add = New System.Windows.Forms.ToolStripMenuItem
        Me.T_Edit = New System.Windows.Forms.ToolStripMenuItem
        Me.T_DEL = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.T_Refresh = New System.Windows.Forms.ToolStripMenuItem
        Me.T_SelectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.T_Layout = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.T_Export = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.tbManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.Grid.DisplayLayout.Appearance = Appearance1
        UltraGridBand1.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid
        UltraGridBand1.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption
        UltraGridBand1.Override.RowAppearance = Appearance8
        Me.Grid.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.Grid.DisplayLayout.EmptyRowSettings.ShowEmptyRows = True
        Me.Grid.DisplayLayout.GroupByBox.Hidden = True
        Me.Grid.DisplayLayout.InterBandSpacing = 10
        Me.Grid.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid.DisplayLayout.MaxRowScrollRegions = 1
        Appearance25.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid.DisplayLayout.Override.ActiveCellAppearance = Appearance25
        Appearance7.BackColor = System.Drawing.Color.RoyalBlue
        Appearance7.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.FontData.BoldAsString = "True"
        Appearance7.ForeColor = System.Drawing.Color.White
        Me.Grid.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.Grid.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.Grid.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.Grid.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.Grid.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.DisplayLayout.Override.FilterRowAppearance = Appearance10
        Me.Grid.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance3.BackColor = System.Drawing.Color.AliceBlue
        Appearance3.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.TextHAlignAsString = "Left"
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.Grid.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance9.BackColor = System.Drawing.Color.AliceBlue
        Me.Grid.DisplayLayout.Override.RowAlternateAppearance = Appearance9
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
        Me.Grid.Location = New System.Drawing.Point(0, 26)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(604, 335)
        Me.Grid.TabIndex = 27
        '
        'UltraLabel1
        '
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.SizeInPoints = 12.0!
        Appearance4.Image = Global.MPS.My.Resources.Resources.label_red
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance4
        Me.UltraLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraLabel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(604, 23)
        Me.UltraLabel1.TabIndex = 34
        Me.UltraLabel1.Text = "Chi nhánh"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(604, 23)
        Me.Panel1.TabIndex = 35
        '
        'LabelBottom
        '
        Appearance43.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance43.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance43.FontData.BoldAsString = "True"
        Appearance43.FontData.SizeInPoints = 8.0!
        Appearance43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance43.TextHAlignAsString = "Left"
        Appearance43.TextVAlignAsString = "Middle"
        Me.LabelBottom.Appearance = Appearance43
        Me.LabelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelBottom.Location = New System.Drawing.Point(0, 384)
        Me.LabelBottom.Name = "LabelBottom"
        Me.LabelBottom.Size = New System.Drawing.Size(604, 30)
        Me.LabelBottom.TabIndex = 41
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Grid)
        Me.Panel2.Controls.Add(Me._Panel2_Toolbars_Dock_Area_Left)
        Me.Panel2.Controls.Add(Me._Panel2_Toolbars_Dock_Area_Right)
        Me.Panel2.Controls.Add(Me._Panel2_Toolbars_Dock_Area_Top)
        Me.Panel2.Controls.Add(Me._Panel2_Toolbars_Dock_Area_Bottom)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 23)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(604, 361)
        Me.Panel2.TabIndex = 42
        '
        '_Panel2_Toolbars_Dock_Area_Left
        '
        Me._Panel2_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Panel2_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._Panel2_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 26)
        Me._Panel2_Toolbars_Dock_Area_Left.Name = "_Panel2_Toolbars_Dock_Area_Left"
        Me._Panel2_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 335)
        Me._Panel2_Toolbars_Dock_Area_Left.ToolbarsManager = Me.tbManager
        '
        'tbManager
        '
        Me.tbManager.AlwaysShowMenusExpanded = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.FontData.BoldAsString = "True"
        Me.tbManager.Appearance = Appearance24
        Me.tbManager.DesignerFlags = 1
        Me.tbManager.DockWithinContainer = Me.Panel2
        Me.tbManager.LockToolbars = True
        Me.tbManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None
        Me.tbManager.ShowFullMenusDelay = 500
        Me.tbManager.ShowQuickCustomizeButton = False
        Me.tbManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool2, ButtonTool3})
        UltraToolbar1.Text = "tool1"
        Me.tbManager.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Me.tbManager.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.[False]
        Me.tbManager.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.[False]
        Me.tbManager.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.[True]
        Appearance21.Image = Global.MPS.My.Resources.Resources.document_new
        Appearance21.TextHAlignAsString = "Left"
        ButtonTool4.SharedProps.AppearancesSmall.Appearance = Appearance21
        ButtonTool4.SharedProps.Caption = "Thêm mới (Ctrl+T)"
        ButtonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance22.Image = Global.MPS.My.Resources.Resources.edit1
        Appearance22.TextHAlignAsString = "Left"
        ButtonTool5.SharedProps.AppearancesSmall.Appearance = Appearance22
        ButtonTool5.SharedProps.Caption = "Hiệu chỉnh (F6)"
        ButtonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance23.Image = Global.MPS.My.Resources.Resources.exit_child
        Appearance23.TextHAlignAsString = "Left"
        ButtonTool6.SharedProps.AppearancesSmall.Appearance = Appearance23
        ButtonTool6.SharedProps.Caption = "Xóa (Del)"
        ButtonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Me.tbManager.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool4, ButtonTool5, ButtonTool6})
        '
        '_Panel2_Toolbars_Dock_Area_Right
        '
        Me._Panel2_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Panel2_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._Panel2_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(604, 26)
        Me._Panel2_Toolbars_Dock_Area_Right.Name = "_Panel2_Toolbars_Dock_Area_Right"
        Me._Panel2_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 335)
        Me._Panel2_Toolbars_Dock_Area_Right.ToolbarsManager = Me.tbManager
        '
        '_Panel2_Toolbars_Dock_Area_Top
        '
        Me._Panel2_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Panel2_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._Panel2_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._Panel2_Toolbars_Dock_Area_Top.Name = "_Panel2_Toolbars_Dock_Area_Top"
        Me._Panel2_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(604, 26)
        Me._Panel2_Toolbars_Dock_Area_Top.ToolbarsManager = Me.tbManager
        '
        '_Panel2_Toolbars_Dock_Area_Bottom
        '
        Me._Panel2_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._Panel2_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._Panel2_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._Panel2_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Panel2_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 361)
        Me._Panel2_Toolbars_Dock_Area_Bottom.Name = "_Panel2_Toolbars_Dock_Area_Bottom"
        Me._Panel2_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(604, 0)
        Me._Panel2_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.tbManager
        '
        'ctMenu
        '
        Me.ctMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.T_Add, Me.T_Edit, Me.T_DEL, Me.ToolStripSeparator3, Me.T_Refresh, Me.T_SelectAll, Me.ToolStripSeparator1, Me.T_Layout, Me.ToolStripSeparator2, Me.T_Export})
        Me.ctMenu.Name = "ContextMenuStrip1"
        Me.ctMenu.Size = New System.Drawing.Size(201, 176)
        '
        'T_Add
        '
        Me.T_Add.ForeColor = System.Drawing.Color.Navy
        Me.T_Add.Image = Global.MPS.My.Resources.Resources.document_add
        Me.T_Add.Name = "T_Add"
        Me.T_Add.ShortcutKeyDisplayString = "Ctrl+T"
        Me.T_Add.Size = New System.Drawing.Size(200, 22)
        Me.T_Add.Text = "Thêm mới"
        '
        'T_Edit
        '
        Me.T_Edit.ForeColor = System.Drawing.Color.Navy
        Me.T_Edit.Image = Global.MPS.My.Resources.Resources.edit1
        Me.T_Edit.Name = "T_Edit"
        Me.T_Edit.ShortcutKeyDisplayString = "F6"
        Me.T_Edit.Size = New System.Drawing.Size(200, 22)
        Me.T_Edit.Text = "Hiệu chỉnh"
        '
        'T_DEL
        '
        Me.T_DEL.ForeColor = System.Drawing.Color.Navy
        Me.T_DEL.Image = Global.MPS.My.Resources.Resources.exit_child
        Me.T_DEL.Name = "T_DEL"
        Me.T_DEL.ShortcutKeyDisplayString = "Del"
        Me.T_DEL.Size = New System.Drawing.Size(200, 22)
        Me.T_DEL.Text = "Xóa"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(197, 6)
        '
        'T_Refresh
        '
        Me.T_Refresh.ForeColor = System.Drawing.Color.Navy
        Me.T_Refresh.Image = Global.MPS.My.Resources.Resources.refresh
        Me.T_Refresh.Name = "T_Refresh"
        Me.T_Refresh.ShortcutKeyDisplayString = "F5"
        Me.T_Refresh.Size = New System.Drawing.Size(200, 22)
        Me.T_Refresh.Text = "Refresh"
        '
        'T_SelectAll
        '
        Me.T_SelectAll.ForeColor = System.Drawing.Color.Navy
        Me.T_SelectAll.Image = Global.MPS.My.Resources.Resources.ok
        Me.T_SelectAll.Name = "T_SelectAll"
        Me.T_SelectAll.ShortcutKeyDisplayString = "Ctrl+A"
        Me.T_SelectAll.Size = New System.Drawing.Size(200, 22)
        Me.T_SelectAll.Text = "Chọn tất cả"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(197, 6)
        '
        'T_Layout
        '
        Me.T_Layout.ForeColor = System.Drawing.Color.Navy
        Me.T_Layout.Image = Global.MPS.My.Resources.Resources.table_sql_check
        Me.T_Layout.Name = "T_Layout"
        Me.T_Layout.ShortcutKeyDisplayString = "Ctrl+V"
        Me.T_Layout.Size = New System.Drawing.Size(200, 22)
        Me.T_Layout.Text = "Điều chỉnh hiển thị"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(197, 6)
        '
        'T_Export
        '
        Me.T_Export.ForeColor = System.Drawing.Color.Navy
        Me.T_Export.Image = Global.MPS.My.Resources.Resources.Excel2002
        Me.T_Export.Name = "T_Export"
        Me.T_Export.ShortcutKeyDisplayString = "Ctrl+E"
        Me.T_Export.Size = New System.Drawing.Size(200, 22)
        Me.T_Export.Text = "Xuất ra Excel"
        '
        'frmBranch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(604, 414)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LabelBottom)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBranch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.tbManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grid As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelBottom As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tbManager As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _Panel2_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _Panel2_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _Panel2_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _Panel2_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents ctMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents T_Add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents T_Edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents T_DEL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents T_Layout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents T_Export As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents T_SelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents T_Refresh As System.Windows.Forms.ToolStripMenuItem
End Class
