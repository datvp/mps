<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFuncRight
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
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Override1 As Infragistics.Win.UltraWinTree.Override = New Infragistics.Win.UltraWinTree.Override
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFuncRight))
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnu_Add = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_layout = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.GridUser = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.TV = New Infragistics.Win.UltraWinTree.UltraTree
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.Grid = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ctMenuUser = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.T_view = New System.Windows.Forms.ToolStripMenuItem
        Me.T_Add = New System.Windows.Forms.ToolStripMenuItem
        Me.T_Del = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        CType(Me.GridUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctMenuUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.AliceBlue
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_Add, Me.mnu_layout, Me.mnuRefresh})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 25)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(757, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnu_Add
        '
        Me.mnu_Add.Image = Global.MPS.My.Resources.Resources.disk_blue
        Me.mnu_Add.Name = "mnu_Add"
        Me.mnu_Add.Size = New System.Drawing.Size(76, 20)
        Me.mnu_Add.Text = "Lưu (F2)"
        '
        'mnu_layout
        '
        Me.mnu_layout.Image = Global.MPS.My.Resources.Resources.table_sql_check
        Me.mnu_layout.Name = "mnu_layout"
        Me.mnu_layout.Size = New System.Drawing.Size(123, 20)
        Me.mnu_layout.Text = "Điều chỉnh hiển thị"
        Me.mnu_layout.Visible = False
        '
        'mnuRefresh
        '
        Me.mnuRefresh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuRefresh.Image = Global.MPS.My.Resources.Resources.refresh
        Me.mnuRefresh.Name = "mnuRefresh"
        Me.mnuRefresh.Size = New System.Drawing.Size(96, 20)
        Me.mnuRefresh.Text = "Refresh (F5)"
        '
        'GridUser
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.GridUser.DisplayLayout.Appearance = Appearance1
        Me.GridUser.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid
        UltraGridBand1.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption
        UltraGridBand1.Override.RowAppearance = Appearance8
        Me.GridUser.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridUser.DisplayLayout.GroupByBox.Hidden = True
        Me.GridUser.DisplayLayout.InterBandSpacing = 10
        Me.GridUser.DisplayLayout.MaxColScrollRegions = 1
        Me.GridUser.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.Color.RoyalBlue
        Appearance7.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.FontData.BoldAsString = "True"
        Appearance7.ForeColor = System.Drawing.Color.White
        Me.GridUser.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.GridUser.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridUser.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.GridUser.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.GridUser.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.GridUser.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.GridUser.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.GridUser.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.[Like]
        Me.GridUser.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridUser.DisplayLayout.Override.FilterRowAppearance = Appearance10
        Me.GridUser.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance3.BackColor = System.Drawing.Color.AliceBlue
        Appearance3.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.TextHAlignAsString = "Left"
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.GridUser.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.GridUser.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance9.BackColor = System.Drawing.Color.AliceBlue
        Me.GridUser.DisplayLayout.Override.RowAlternateAppearance = Appearance9
        Appearance5.BackColor = System.Drawing.Color.AliceBlue
        Appearance5.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.GridUser.DisplayLayout.Override.RowSelectorAppearance = Appearance5
        Me.GridUser.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridUser.DisplayLayout.Override.RowSelectorWidth = 12
        Me.GridUser.DisplayLayout.Override.RowSpacingBefore = 0
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.ForeColor = System.Drawing.Color.Black
        Me.GridUser.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.GridUser.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.GridUser.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridUser.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridUser.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridUser.Location = New System.Drawing.Point(48, 105)
        Me.GridUser.Name = "GridUser"
        Me.GridUser.Size = New System.Drawing.Size(95, 179)
        Me.GridUser.TabIndex = 35
        Me.GridUser.Visible = False
        '
        'UltraLabel1
        '
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.SizeInPoints = 12.0!
        Appearance4.Image = Global.MPS.My.Resources.Resources.check
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance4
        Me.UltraLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraLabel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(757, 25)
        Me.UltraLabel1.TabIndex = 36
        Me.UltraLabel1.Text = "Cấp quyền"
        '
        'TV
        '
        Me.TV.Dock = System.Windows.Forms.DockStyle.Left
        Me.TV.FullRowSelect = True
        Me.TV.HideSelection = False
        Me.TV.ImageList = Me.ImageList1
        Me.TV.Location = New System.Drawing.Point(0, 49)
        Me.TV.Name = "TV"
        Appearance21.Image = "ok.png"
        Override1.SelectedNodeAppearance = Appearance21
        Me.TV.Override = Override1
        Me.TV.Size = New System.Drawing.Size(188, 434)
        Me.TV.TabIndex = 37
        Me.TV.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.Standard
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "businessmen.png")
        Me.ImageList1.Images.SetKeyName(1, "businessman.png")
        Me.ImageList1.Images.SetKeyName(2, "ok.png")
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.Splitter1.Location = New System.Drawing.Point(188, 49)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(10, 434)
        Me.Splitter1.TabIndex = 38
        Me.Splitter1.TabStop = False
        '
        'Grid
        '
        Appearance19.BackColor = System.Drawing.Color.White
        Me.Grid.DisplayLayout.Appearance = Appearance19
        Me.Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand2.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid
        UltraGridBand2.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance11.BorderColor = System.Drawing.SystemColors.InactiveCaption
        UltraGridBand2.Override.RowAppearance = Appearance11
        Me.Grid.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.Grid.DisplayLayout.EmptyRowSettings.ShowEmptyRows = True
        Me.Grid.DisplayLayout.GroupByBox.Hidden = True
        Me.Grid.DisplayLayout.InterBandSpacing = 10
        Me.Grid.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.Color.RoyalBlue
        Appearance12.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance12.FontData.BoldAsString = "True"
        Appearance12.ForeColor = System.Drawing.Color.White
        Me.Grid.DisplayLayout.Override.ActiveRowAppearance = Appearance12
        Me.Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.Grid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Me.Grid.DisplayLayout.Override.CardAreaAppearance = Appearance13
        Me.Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.Grid.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.Grid.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.[Like]
        Me.Grid.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.DisplayLayout.Override.FilterRowAppearance = Appearance14
        Me.Grid.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance15.BackColor = System.Drawing.Color.AliceBlue
        Appearance15.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.FontData.BoldAsString = "True"
        Appearance15.TextHAlignAsString = "Left"
        Appearance15.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.Grid.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance16.BackColor = System.Drawing.Color.AliceBlue
        Me.Grid.DisplayLayout.Override.RowAlternateAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.AliceBlue
        Appearance17.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.Grid.DisplayLayout.Override.RowSelectorAppearance = Appearance17
        Me.Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid.DisplayLayout.Override.RowSelectorWidth = 12
        Me.Grid.DisplayLayout.Override.RowSpacingBefore = 0
        Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance18.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance18.ForeColor = System.Drawing.Color.Black
        Me.Grid.DisplayLayout.Override.SelectedRowAppearance = Appearance18
        Me.Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid.Location = New System.Drawing.Point(198, 49)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(559, 434)
        Me.Grid.TabIndex = 39
        '
        'ctMenuUser
        '
        Me.ctMenuUser.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.T_view, Me.T_Add, Me.T_Del})
        Me.ctMenuUser.Name = "ctMenuUser"
        Me.ctMenuUser.Size = New System.Drawing.Size(209, 70)
        '
        'T_view
        '
        Me.T_view.ForeColor = System.Drawing.Color.Navy
        Me.T_view.Image = Global.MPS.My.Resources.Resources.view
        Me.T_view.Name = "T_view"
        Me.T_view.ShortcutKeyDisplayString = "Ctrl+X"
        Me.T_view.Size = New System.Drawing.Size(208, 22)
        Me.T_view.Text = "Xem / Hiệu chỉnh"
        '
        'T_Add
        '
        Me.T_Add.ForeColor = System.Drawing.Color.Navy
        Me.T_Add.Image = Global.MPS.My.Resources.Resources.document_new
        Me.T_Add.Name = "T_Add"
        Me.T_Add.ShortcutKeyDisplayString = "Ctrl+T"
        Me.T_Add.Size = New System.Drawing.Size(208, 22)
        Me.T_Add.Text = "Thêm mới"
        '
        'T_Del
        '
        Me.T_Del.ForeColor = System.Drawing.Color.Navy
        Me.T_Del.Image = Global.MPS.My.Resources.Resources.exit_child
        Me.T_Del.Name = "T_Del"
        Me.T_Del.ShortcutKeyDisplayString = "Del"
        Me.T_Del.Size = New System.Drawing.Size(208, 22)
        Me.T_Del.Text = "Xóa"
        '
        'FrmFuncRight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 483)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.TV)
        Me.Controls.Add(Me.GridUser)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "FrmFuncRight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.GridUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctMenuUser.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnu_Add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_layout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridUser As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TV As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Grid As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ctMenuUser As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents T_Add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents T_view As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents T_Del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRefresh As System.Windows.Forms.ToolStripMenuItem
End Class
