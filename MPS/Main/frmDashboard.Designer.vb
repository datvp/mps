<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
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
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim PaintElement1 As Infragistics.UltraChart.Resources.Appearance.PaintElement = New Infragistics.UltraChart.Resources.Appearance.PaintElement
        Dim GradientEffect1 As Infragistics.UltraChart.Resources.Appearance.GradientEffect = New Infragistics.UltraChart.Resources.Appearance.GradientEffect
        Dim PieChartAppearance1 As Infragistics.UltraChart.Resources.Appearance.PieChartAppearance = New Infragistics.UltraChart.Resources.Appearance.PieChartAppearance
        Dim GridBagConstraint2 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim PaintElement2 As Infragistics.UltraChart.Resources.Appearance.PaintElement = New Infragistics.UltraChart.Resources.Appearance.PaintElement
        Dim ColumnChartAppearance1 As Infragistics.UltraChart.Resources.Appearance.ColumnChartAppearance = New Infragistics.UltraChart.Resources.Appearance.ColumnChartAppearance
        Dim GradientEffect2 As Infragistics.UltraChart.Resources.Appearance.GradientEffect = New Infragistics.UltraChart.Resources.Appearance.GradientEffect
        Dim GridBagConstraint3 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim PaintElement3 As Infragistics.UltraChart.Resources.Appearance.PaintElement = New Infragistics.UltraChart.Resources.Appearance.PaintElement
        Dim ColumnChartAppearance2 As Infragistics.UltraChart.Resources.Appearance.ColumnChartAppearance = New Infragistics.UltraChart.Resources.Appearance.ColumnChartAppearance
        Dim ChartLayerAppearance1 As Infragistics.UltraChart.Resources.Appearance.ChartLayerAppearance = New Infragistics.UltraChart.Resources.Appearance.ChartLayerAppearance
        Dim ChartLayerAppearance2 As Infragistics.UltraChart.Resources.Appearance.ChartLayerAppearance = New Infragistics.UltraChart.Resources.Appearance.ChartLayerAppearance
        Dim GradientEffect3 As Infragistics.UltraChart.Resources.Appearance.GradientEffect = New Infragistics.UltraChart.Resources.Appearance.GradientEffect
        Dim GridBagConstraint4 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim GridBagConstraint5 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim GridBagConstraint6 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim PaintElement4 As Infragistics.UltraChart.Resources.Appearance.PaintElement = New Infragistics.UltraChart.Resources.Appearance.PaintElement
        Dim DoughnutChartAppearance1 As Infragistics.UltraChart.Resources.Appearance.DoughnutChartAppearance = New Infragistics.UltraChart.Resources.Appearance.DoughnutChartAppearance
        Dim GradientEffect4 As Infragistics.UltraChart.Resources.Appearance.GradientEffect = New Infragistics.UltraChart.Resources.Appearance.GradientEffect
        Me.GridBagLayout = New Infragistics.Win.Misc.UltraGridBagLayoutPanel
        Me.grpRevenueByClientGroup = New Infragistics.Win.Misc.UltraGroupBox
        Me.ChartByClientGroup = New Infragistics.Win.UltraWinChart.UltraChart
        Me.grpRevenueByItem = New Infragistics.Win.Misc.UltraGroupBox
        Me.ChartBySubContractor = New Infragistics.Win.UltraWinChart.UltraChart
        Me.grpTotalSaleChart = New Infragistics.Win.Misc.UltraGroupBox
        Me.ChartByItem = New Infragistics.Win.UltraWinChart.UltraChart
        Me.grpItemSaleToday = New Infragistics.Win.Misc.UltraGroupBox
        Me.GridProduct = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.grpTotalBranch = New Infragistics.Win.Misc.UltraGroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblTienThuVe = New Infragistics.Win.Misc.UltraLabel
        Me.lblLoiNhuan = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.grpRevenueByProject = New Infragistics.Win.Misc.UltraGroupBox
        Me.ChartByProject = New Infragistics.Win.UltraWinChart.UltraChart
        CType(Me.GridBagLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GridBagLayout.SuspendLayout()
        CType(Me.grpRevenueByClientGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRevenueByClientGroup.SuspendLayout()
        CType(Me.ChartByClientGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpRevenueByItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRevenueByItem.SuspendLayout()
        CType(Me.ChartBySubContractor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpTotalSaleChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTotalSaleChart.SuspendLayout()
        CType(Me.ChartByItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpItemSaleToday, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpItemSaleToday.SuspendLayout()
        CType(Me.GridProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpTotalBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTotalBranch.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grpRevenueByProject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRevenueByProject.SuspendLayout()
        CType(Me.ChartByProject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridBagLayout
        '
        Me.GridBagLayout.Controls.Add(Me.grpRevenueByClientGroup)
        Me.GridBagLayout.Controls.Add(Me.grpRevenueByItem)
        Me.GridBagLayout.Controls.Add(Me.grpTotalSaleChart)
        Me.GridBagLayout.Controls.Add(Me.grpItemSaleToday)
        Me.GridBagLayout.Controls.Add(Me.grpTotalBranch)
        Me.GridBagLayout.Controls.Add(Me.grpRevenueByProject)
        Me.GridBagLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridBagLayout.ExpandToFitHeight = True
        Me.GridBagLayout.ExpandToFitWidth = True
        Me.GridBagLayout.Location = New System.Drawing.Point(0, 0)
        Me.GridBagLayout.Name = "GridBagLayout"
        Me.GridBagLayout.Size = New System.Drawing.Size(1002, 496)
        Me.GridBagLayout.TabIndex = 0
        '
        'grpRevenueByClientGroup
        '
        Me.grpRevenueByClientGroup.Controls.Add(Me.ChartByClientGroup)
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.OriginX = 1
        GridBagConstraint1.OriginY = 0
        Me.GridBagLayout.SetGridBagConstraint(Me.grpRevenueByClientGroup, GridBagConstraint1)
        Appearance2.FontData.BoldAsString = "True"
        Me.grpRevenueByClientGroup.HeaderAppearance = Appearance2
        Me.grpRevenueByClientGroup.Location = New System.Drawing.Point(461, 0)
        Me.grpRevenueByClientGroup.Name = "grpRevenueByClientGroup"
        Me.GridBagLayout.SetPreferredSize(Me.grpRevenueByClientGroup, New System.Drawing.Size(222, 110))
        Me.grpRevenueByClientGroup.Size = New System.Drawing.Size(255, 226)
        Me.grpRevenueByClientGroup.TabIndex = 2
        Me.grpRevenueByClientGroup.Text = "Doanh thu theo nhóm khách hàng"
        Me.grpRevenueByClientGroup.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        '			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
        '			'ChartType' must be persisted ahead of any Axes change made in design time.
        '		
        Me.ChartByClientGroup.ChartType = Infragistics.UltraChart.[Shared].Styles.ChartType.PieChart
        '
        'ChartByClientGroup
        '
        Me.ChartByClientGroup.Axis.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        PaintElement1.ElementType = Infragistics.UltraChart.[Shared].Styles.PaintElementType.None
        PaintElement1.Fill = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ChartByClientGroup.Axis.PE = PaintElement1
        Me.ChartByClientGroup.Axis.X.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByClientGroup.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.ChartByClientGroup.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.X.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.X.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByClientGroup.Axis.X.Labels.SeriesLabels.FormatString = ""
        Me.ChartByClientGroup.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.X.LineThickness = 1
        Me.ChartByClientGroup.Axis.X.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByClientGroup.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.X.MajorGridLines.Visible = True
        Me.ChartByClientGroup.Axis.X.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByClientGroup.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.X.MinorGridLines.Visible = False
        Me.ChartByClientGroup.Axis.X.TickmarkIntervalType = Infragistics.UltraChart.[Shared].Styles.AxisIntervalType.Hours
        Me.ChartByClientGroup.Axis.X.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByClientGroup.Axis.X.Visible = True
        Me.ChartByClientGroup.Axis.X2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartByClientGroup.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.X2.Labels.ItemFormatString = ""
        Me.ChartByClientGroup.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.X2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.X2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartByClientGroup.Axis.X2.Labels.SeriesLabels.FormatString = ""
        Me.ChartByClientGroup.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.X2.LineThickness = 1
        Me.ChartByClientGroup.Axis.X2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByClientGroup.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.X2.MajorGridLines.Visible = True
        Me.ChartByClientGroup.Axis.X2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByClientGroup.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.X2.MinorGridLines.Visible = False
        Me.ChartByClientGroup.Axis.X2.TickmarkIntervalType = Infragistics.UltraChart.[Shared].Styles.AxisIntervalType.Hours
        Me.ChartByClientGroup.Axis.X2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByClientGroup.Axis.X2.Visible = False
        Me.ChartByClientGroup.Axis.Y.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByClientGroup.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>"
        Me.ChartByClientGroup.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.Y.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.Y.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByClientGroup.Axis.Y.Labels.SeriesLabels.FormatString = ""
        Me.ChartByClientGroup.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.Y.LineThickness = 1
        Me.ChartByClientGroup.Axis.Y.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByClientGroup.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.Y.MajorGridLines.Visible = True
        Me.ChartByClientGroup.Axis.Y.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByClientGroup.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.Y.MinorGridLines.Visible = False
        Me.ChartByClientGroup.Axis.Y.TickmarkInterval = 20
        Me.ChartByClientGroup.Axis.Y.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByClientGroup.Axis.Y.Visible = True
        Me.ChartByClientGroup.Axis.Y2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartByClientGroup.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.Y2.Labels.ItemFormatString = ""
        Me.ChartByClientGroup.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.Y2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartByClientGroup.Axis.Y2.Labels.SeriesLabels.FormatString = ""
        Me.ChartByClientGroup.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.Y2.LineThickness = 1
        Me.ChartByClientGroup.Axis.Y2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByClientGroup.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.Y2.MajorGridLines.Visible = True
        Me.ChartByClientGroup.Axis.Y2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByClientGroup.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.Y2.MinorGridLines.Visible = False
        Me.ChartByClientGroup.Axis.Y2.TickmarkInterval = 20
        Me.ChartByClientGroup.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByClientGroup.Axis.Y2.Visible = False
        Me.ChartByClientGroup.Axis.Z.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByClientGroup.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.ChartByClientGroup.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.Z.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.Z.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByClientGroup.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.Z.LineThickness = 1
        Me.ChartByClientGroup.Axis.Z.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByClientGroup.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.Z.MajorGridLines.Visible = True
        Me.ChartByClientGroup.Axis.Z.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByClientGroup.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.Z.MinorGridLines.Visible = False
        Me.ChartByClientGroup.Axis.Z.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByClientGroup.Axis.Z.Visible = False
        Me.ChartByClientGroup.Axis.Z2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartByClientGroup.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.Z2.Labels.ItemFormatString = ""
        Me.ChartByClientGroup.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.Z2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByClientGroup.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartByClientGroup.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByClientGroup.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByClientGroup.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByClientGroup.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByClientGroup.Axis.Z2.LineThickness = 1
        Me.ChartByClientGroup.Axis.Z2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByClientGroup.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.Z2.MajorGridLines.Visible = True
        Me.ChartByClientGroup.Axis.Z2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByClientGroup.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByClientGroup.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByClientGroup.Axis.Z2.MinorGridLines.Visible = False
        Me.ChartByClientGroup.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByClientGroup.Axis.Z2.Visible = False
        Me.ChartByClientGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ChartByClientGroup.Border.Thickness = 0
        Me.ChartByClientGroup.ColorModel.AlphaLevel = CType(150, Byte)
        Me.ChartByClientGroup.ColorModel.ColorBegin = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChartByClientGroup.ColorModel.ColorEnd = System.Drawing.Color.Green
        Me.ChartByClientGroup.ColorModel.ModelStyle = Infragistics.UltraChart.[Shared].Styles.ColorModels.CustomLinear
        Me.ChartByClientGroup.Dock = System.Windows.Forms.DockStyle.Fill
        GradientEffect1.Coloring = Infragistics.UltraChart.[Shared].Styles.GradientColoringStyle.Lighten
        GradientEffect1.Style = Infragistics.UltraChart.[Shared].Styles.GradientStyle.HorizontalBump
        Me.ChartByClientGroup.Effects.Effects.Add(GradientEffect1)
        Me.ChartByClientGroup.Location = New System.Drawing.Point(3, 17)
        Me.ChartByClientGroup.Name = "ChartByClientGroup"
        PieChartAppearance1.Labels.FormatString = "<ITEM_LABEL>" & Global.Microsoft.VisualBasic.ChrW(10) & "<PERCENT_VALUE:#0.00>%"
        Me.ChartByClientGroup.PieChart = PieChartAppearance1
        Me.ChartByClientGroup.Size = New System.Drawing.Size(249, 206)
        Me.ChartByClientGroup.TabIndex = 2
        Me.ChartByClientGroup.Tooltips.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartByClientGroup.Tooltips.FormatString = "<DATA_VALUE:#,###>"
        Me.ChartByClientGroup.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray
        Me.ChartByClientGroup.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray
        '
        'grpRevenueByItem
        '
        Me.grpRevenueByItem.Controls.Add(Me.ChartBySubContractor)
        GridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint2.OriginX = 2
        GridBagConstraint2.OriginY = 1
        Me.GridBagLayout.SetGridBagConstraint(Me.grpRevenueByItem, GridBagConstraint2)
        Appearance61.FontData.BoldAsString = "True"
        Me.grpRevenueByItem.HeaderAppearance = Appearance61
        Me.grpRevenueByItem.Location = New System.Drawing.Point(716, 226)
        Me.grpRevenueByItem.Name = "grpRevenueByItem"
        Me.GridBagLayout.SetPreferredSize(Me.grpRevenueByItem, New System.Drawing.Size(246, 131))
        Me.grpRevenueByItem.Size = New System.Drawing.Size(286, 270)
        Me.grpRevenueByItem.TabIndex = 4
        Me.grpRevenueByItem.Text = "Doanh thu theo...(coming soon...)"
        Me.grpRevenueByItem.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ChartBySubContractor
        '
        Me.ChartBySubContractor.Axis.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        PaintElement2.ElementType = Infragistics.UltraChart.[Shared].Styles.PaintElementType.None
        PaintElement2.Fill = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ChartBySubContractor.Axis.PE = PaintElement2
        Me.ChartBySubContractor.Axis.X.Labels.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartBySubContractor.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray
        Me.ChartBySubContractor.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartBySubContractor.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.ChartBySubContractor.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.X.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.ChartBySubContractor.Axis.X.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartBySubContractor.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.ChartBySubContractor.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartBySubContractor.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.X.LineColor = System.Drawing.Color.Blue
        Me.ChartBySubContractor.Axis.X.LineDrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.X.LineEndCapStyle = Infragistics.UltraChart.[Shared].Styles.LineCapStyle.ArrowAnchor
        Me.ChartBySubContractor.Axis.X.LineThickness = 1
        Me.ChartBySubContractor.Axis.X.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartBySubContractor.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.X.MajorGridLines.Visible = False
        Me.ChartBySubContractor.Axis.X.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartBySubContractor.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.X.MinorGridLines.Visible = False
        Me.ChartBySubContractor.Axis.X.TickmarkIntervalType = Infragistics.UltraChart.[Shared].Styles.AxisIntervalType.Hours
        Me.ChartBySubContractor.Axis.X.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartBySubContractor.Axis.X.Visible = True
        Me.ChartBySubContractor.Axis.X2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartBySubContractor.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartBySubContractor.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.ChartBySubContractor.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.ChartBySubContractor.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.X2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.ChartBySubContractor.Axis.X2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartBySubContractor.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartBySubContractor.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartBySubContractor.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.X2.LineThickness = 1
        Me.ChartBySubContractor.Axis.X2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartBySubContractor.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.X2.MajorGridLines.Visible = True
        Me.ChartBySubContractor.Axis.X2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartBySubContractor.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.X2.MinorGridLines.Visible = False
        Me.ChartBySubContractor.Axis.X2.TickmarkIntervalType = Infragistics.UltraChart.[Shared].Styles.AxisIntervalType.Hours
        Me.ChartBySubContractor.Axis.X2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartBySubContractor.Axis.X2.Visible = False
        Me.ChartBySubContractor.Axis.Y.Extent = 60
        Me.ChartBySubContractor.Axis.Y.Labels.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartBySubContractor.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.ChartBySubContractor.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:#,###>"
        Me.ChartBySubContractor.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.Y.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartBySubContractor.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.ChartBySubContractor.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.ChartBySubContractor.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.Y.LineColor = System.Drawing.Color.Blue
        Me.ChartBySubContractor.Axis.Y.LineEndCapStyle = Infragistics.UltraChart.[Shared].Styles.LineCapStyle.ArrowAnchor
        Me.ChartBySubContractor.Axis.Y.LineThickness = 1
        Me.ChartBySubContractor.Axis.Y.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartBySubContractor.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.Y.MajorGridLines.Visible = False
        Me.ChartBySubContractor.Axis.Y.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartBySubContractor.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.Y.MinorGridLines.Visible = False
        Me.ChartBySubContractor.Axis.Y.TickmarkInterval = 50
        Me.ChartBySubContractor.Axis.Y.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartBySubContractor.Axis.Y.Visible = True
        Me.ChartBySubContractor.Axis.Y2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartBySubContractor.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartBySubContractor.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartBySubContractor.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>"
        Me.ChartBySubContractor.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartBySubContractor.Axis.Y2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartBySubContractor.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartBySubContractor.Axis.Y2.Labels.SeriesLabels.FormatString = ""
        Me.ChartBySubContractor.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartBySubContractor.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.ChartBySubContractor.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.Y2.LineThickness = 1
        Me.ChartBySubContractor.Axis.Y2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartBySubContractor.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.Y2.MajorGridLines.Visible = True
        Me.ChartBySubContractor.Axis.Y2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartBySubContractor.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.Y2.MinorGridLines.Visible = False
        Me.ChartBySubContractor.Axis.Y2.TickmarkInterval = 50
        Me.ChartBySubContractor.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartBySubContractor.Axis.Y2.Visible = False
        Me.ChartBySubContractor.Axis.Z.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartBySubContractor.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray
        Me.ChartBySubContractor.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartBySubContractor.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.ChartBySubContractor.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.Z.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartBySubContractor.Axis.Z.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartBySubContractor.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.ChartBySubContractor.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartBySubContractor.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartBySubContractor.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.Z.LineThickness = 1
        Me.ChartBySubContractor.Axis.Z.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartBySubContractor.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.Z.MajorGridLines.Visible = True
        Me.ChartBySubContractor.Axis.Z.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartBySubContractor.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.Z.MinorGridLines.Visible = False
        Me.ChartBySubContractor.Axis.Z.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartBySubContractor.Axis.Z.Visible = False
        Me.ChartBySubContractor.Axis.Z2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartBySubContractor.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartBySubContractor.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartBySubContractor.Axis.Z2.Labels.ItemFormatString = ""
        Me.ChartBySubContractor.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartBySubContractor.Axis.Z2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartBySubContractor.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartBySubContractor.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartBySubContractor.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartBySubContractor.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartBySubContractor.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartBySubContractor.Axis.Z2.LineThickness = 1
        Me.ChartBySubContractor.Axis.Z2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartBySubContractor.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.Z2.MajorGridLines.Visible = True
        Me.ChartBySubContractor.Axis.Z2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartBySubContractor.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartBySubContractor.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartBySubContractor.Axis.Z2.MinorGridLines.Visible = False
        Me.ChartBySubContractor.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartBySubContractor.Axis.Z2.Visible = False
        Me.ChartBySubContractor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ChartBySubContractor.Border.Thickness = 0
        Me.ChartBySubContractor.ColorModel.AlphaLevel = CType(150, Byte)
        Me.ChartBySubContractor.ColorModel.ColorBegin = System.Drawing.Color.Pink
        Me.ChartBySubContractor.ColorModel.ColorEnd = System.Drawing.Color.DarkRed
        Me.ChartBySubContractor.ColorModel.ModelStyle = Infragistics.UltraChart.[Shared].Styles.ColorModels.CustomLinear
        ColumnChartAppearance1.SeriesSpacing = 0
        Me.ChartBySubContractor.ColumnChart = ColumnChartAppearance1
        Me.ChartBySubContractor.Data.EmptyStyle.PointStyle.IconSize = Infragistics.UltraChart.[Shared].Styles.SymbolIconSize.Small
        Me.ChartBySubContractor.Data.EmptyStyle.ShowInLegend = True
        Me.ChartBySubContractor.Data.RowLabelsColumn = 0
        Me.ChartBySubContractor.Data.UseMinMax = True
        Me.ChartBySubContractor.Data.UseRowLabelsColumn = True
        Me.ChartBySubContractor.Data.ZeroAligned = True
        Me.ChartBySubContractor.Dock = System.Windows.Forms.DockStyle.Fill
        GradientEffect2.Coloring = Infragistics.UltraChart.[Shared].Styles.GradientColoringStyle.Lighten
        GradientEffect2.Style = Infragistics.UltraChart.[Shared].Styles.GradientStyle.HorizontalBump
        Me.ChartBySubContractor.Effects.Effects.Add(GradientEffect2)
        Me.ChartBySubContractor.Location = New System.Drawing.Point(3, 17)
        Me.ChartBySubContractor.Name = "ChartBySubContractor"
        Me.ChartBySubContractor.Size = New System.Drawing.Size(280, 250)
        Me.ChartBySubContractor.TabIndex = 2
        Me.ChartBySubContractor.TitleLeft.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartBySubContractor.Tooltips.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartBySubContractor.Tooltips.FormatString = "<DATA_VALUE:#,###>"
        Me.ChartBySubContractor.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray
        Me.ChartBySubContractor.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray
        '
        'grpTotalSaleChart
        '
        Me.grpTotalSaleChart.Controls.Add(Me.ChartByItem)
        GridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint3.OriginX = 0
        GridBagConstraint3.OriginY = 0
        Me.GridBagLayout.SetGridBagConstraint(Me.grpTotalSaleChart, GridBagConstraint3)
        Appearance62.FontData.BoldAsString = "True"
        Me.grpTotalSaleChart.HeaderAppearance = Appearance62
        Me.grpTotalSaleChart.Location = New System.Drawing.Point(0, 0)
        Me.grpTotalSaleChart.Name = "grpTotalSaleChart"
        Me.GridBagLayout.SetPreferredSize(Me.grpTotalSaleChart, New System.Drawing.Size(337, 110))
        Me.grpTotalSaleChart.Size = New System.Drawing.Size(461, 226)
        Me.grpTotalSaleChart.TabIndex = 2
        Me.grpTotalSaleChart.Text = "Doanh thu theo hạng mục"
        Me.grpTotalSaleChart.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        '			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
        '			'ChartType' must be persisted ahead of any Axes change made in design time.
        '		
        ChartLayerAppearance1.ChartType = Infragistics.UltraChart.[Shared].Styles.ChartType.ColumnChart
        '
        'ChartByItem
        '
        Me.ChartByItem.Axis.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        PaintElement3.ElementType = Infragistics.UltraChart.[Shared].Styles.PaintElementType.None
        PaintElement3.Fill = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ChartByItem.Axis.PE = PaintElement3
        Me.ChartByItem.Axis.X.Labels.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartByItem.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByItem.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByItem.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.ChartByItem.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.X.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.ChartByItem.Axis.X.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByItem.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByItem.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByItem.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.X.LineColor = System.Drawing.Color.Blue
        Me.ChartByItem.Axis.X.LineDrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.X.LineEndCapStyle = Infragistics.UltraChart.[Shared].Styles.LineCapStyle.ArrowAnchor
        Me.ChartByItem.Axis.X.LineThickness = 1
        Me.ChartByItem.Axis.X.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByItem.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.X.MajorGridLines.Visible = False
        Me.ChartByItem.Axis.X.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByItem.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.X.MinorGridLines.Visible = False
        Me.ChartByItem.Axis.X.TickmarkIntervalType = Infragistics.UltraChart.[Shared].Styles.AxisIntervalType.Hours
        Me.ChartByItem.Axis.X.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByItem.Axis.X.Visible = True
        Me.ChartByItem.Axis.X2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByItem.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartByItem.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.ChartByItem.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.ChartByItem.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.X2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.ChartByItem.Axis.X2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByItem.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartByItem.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByItem.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.X2.LineThickness = 1
        Me.ChartByItem.Axis.X2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByItem.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.X2.MajorGridLines.Visible = True
        Me.ChartByItem.Axis.X2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByItem.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.X2.MinorGridLines.Visible = False
        Me.ChartByItem.Axis.X2.TickmarkIntervalType = Infragistics.UltraChart.[Shared].Styles.AxisIntervalType.Hours
        Me.ChartByItem.Axis.X2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByItem.Axis.X2.Visible = False
        Me.ChartByItem.Axis.Y.Extent = 60
        Me.ChartByItem.Axis.Y.Labels.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartByItem.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.ChartByItem.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:#,###>"
        Me.ChartByItem.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.Y.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByItem.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far
        Me.ChartByItem.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.ChartByItem.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.Y.LineColor = System.Drawing.Color.Blue
        Me.ChartByItem.Axis.Y.LineEndCapStyle = Infragistics.UltraChart.[Shared].Styles.LineCapStyle.ArrowAnchor
        Me.ChartByItem.Axis.Y.LineThickness = 1
        Me.ChartByItem.Axis.Y.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByItem.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.Y.MajorGridLines.Visible = False
        Me.ChartByItem.Axis.Y.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByItem.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.Y.MinorGridLines.Visible = False
        Me.ChartByItem.Axis.Y.TickmarkInterval = 100
        Me.ChartByItem.Axis.Y.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByItem.Axis.Y.Visible = True
        Me.ChartByItem.Axis.Y2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByItem.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartByItem.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByItem.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>"
        Me.ChartByItem.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByItem.Axis.Y2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByItem.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartByItem.Axis.Y2.Labels.SeriesLabels.FormatString = ""
        Me.ChartByItem.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByItem.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.VerticalLeftFacing
        Me.ChartByItem.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.Y2.LineThickness = 1
        Me.ChartByItem.Axis.Y2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByItem.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.Y2.MajorGridLines.Visible = True
        Me.ChartByItem.Axis.Y2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByItem.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.Y2.MinorGridLines.Visible = False
        Me.ChartByItem.Axis.Y2.TickmarkInterval = 100
        Me.ChartByItem.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByItem.Axis.Y2.Visible = False
        Me.ChartByItem.Axis.Z.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByItem.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByItem.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByItem.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.ChartByItem.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.Z.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByItem.Axis.Z.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByItem.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByItem.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByItem.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByItem.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.Z.LineThickness = 1
        Me.ChartByItem.Axis.Z.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByItem.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.Z.MajorGridLines.Visible = True
        Me.ChartByItem.Axis.Z.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByItem.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.Z.MinorGridLines.Visible = False
        Me.ChartByItem.Axis.Z.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByItem.Axis.Z.Visible = False
        Me.ChartByItem.Axis.Z2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByItem.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartByItem.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByItem.Axis.Z2.Labels.ItemFormatString = ""
        Me.ChartByItem.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByItem.Axis.Z2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByItem.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartByItem.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByItem.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByItem.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByItem.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByItem.Axis.Z2.LineThickness = 1
        Me.ChartByItem.Axis.Z2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByItem.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.Z2.MajorGridLines.Visible = True
        Me.ChartByItem.Axis.Z2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByItem.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByItem.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByItem.Axis.Z2.MinorGridLines.Visible = False
        Me.ChartByItem.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByItem.Axis.Z2.Visible = False
        Me.ChartByItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ChartByItem.Border.Thickness = 0
        Me.ChartByItem.ColorModel.AlphaLevel = CType(150, Byte)
        Me.ChartByItem.ColorModel.ColorBegin = System.Drawing.Color.Pink
        Me.ChartByItem.ColorModel.ColorEnd = System.Drawing.Color.DarkRed
        Me.ChartByItem.ColorModel.ModelStyle = Infragistics.UltraChart.[Shared].Styles.ColorModels.DataValueCustomLinear
        ColumnChartAppearance2.SeriesSpacing = 0
        Me.ChartByItem.ColumnChart = ColumnChartAppearance2
        ChartLayerAppearance1.Key = "chartLayer1"
        ChartLayerAppearance2.ChartType = Infragistics.UltraChart.[Shared].Styles.ChartType.ColumnChart
        ChartLayerAppearance2.Key = "chartLayer2"
        Me.ChartByItem.CompositeChart.ChartLayers.AddRange(New Infragistics.UltraChart.Resources.Appearance.ChartLayerAppearance() {ChartLayerAppearance1, ChartLayerAppearance2})
        Me.ChartByItem.Data.EmptyStyle.PointStyle.IconSize = Infragistics.UltraChart.[Shared].Styles.SymbolIconSize.Small
        Me.ChartByItem.Data.EmptyStyle.ShowInLegend = True
        Me.ChartByItem.Data.RowLabelsColumn = 0
        Me.ChartByItem.Data.UseMinMax = True
        Me.ChartByItem.Data.UseRowLabelsColumn = True
        Me.ChartByItem.Data.ZeroAligned = True
        Me.ChartByItem.Dock = System.Windows.Forms.DockStyle.Fill
        GradientEffect3.Coloring = Infragistics.UltraChart.[Shared].Styles.GradientColoringStyle.Lighten
        GradientEffect3.Style = Infragistics.UltraChart.[Shared].Styles.GradientStyle.HorizontalBump
        Me.ChartByItem.Effects.Effects.Add(GradientEffect3)
        Me.ChartByItem.Location = New System.Drawing.Point(3, 17)
        Me.ChartByItem.Name = "ChartByItem"
        Me.ChartByItem.Size = New System.Drawing.Size(455, 206)
        Me.ChartByItem.TabIndex = 0
        Me.ChartByItem.TitleLeft.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartByItem.Tooltips.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartByItem.Tooltips.FormatString = "<DATA_VALUE:#,###>"
        Me.ChartByItem.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray
        Me.ChartByItem.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray
        '
        'grpItemSaleToday
        '
        Me.grpItemSaleToday.Controls.Add(Me.GridProduct)
        GridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint4.OriginX = 2
        GridBagConstraint4.OriginY = 0
        Me.GridBagLayout.SetGridBagConstraint(Me.grpItemSaleToday, GridBagConstraint4)
        Appearance3.FontData.BoldAsString = "True"
        Me.grpItemSaleToday.HeaderAppearance = Appearance3
        Me.grpItemSaleToday.Location = New System.Drawing.Point(716, 0)
        Me.grpItemSaleToday.Name = "grpItemSaleToday"
        Me.GridBagLayout.SetPreferredSize(Me.grpItemSaleToday, New System.Drawing.Size(249, 107))
        Me.grpItemSaleToday.Size = New System.Drawing.Size(286, 226)
        Me.grpItemSaleToday.TabIndex = 4
        Me.grpItemSaleToday.Text = "Hợp đồng sắp hết hạn (coming soon...)"
        Me.grpItemSaleToday.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'GridProduct
        '
        Appearance5.BackColor = System.Drawing.Color.White
        Me.GridProduct.DisplayLayout.Appearance = Appearance5
        Me.GridProduct.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridBand1.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid
        UltraGridBand1.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance6.BorderColor = System.Drawing.SystemColors.InactiveCaption
        UltraGridBand1.Override.RowAppearance = Appearance6
        Me.GridProduct.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridProduct.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.GridProduct.DisplayLayout.EmptyRowSettings.ShowEmptyRows = True
        Me.GridProduct.DisplayLayout.GroupByBox.Hidden = True
        Me.GridProduct.DisplayLayout.InterBandSpacing = 10
        Me.GridProduct.DisplayLayout.MaxColScrollRegions = 1
        Me.GridProduct.DisplayLayout.MaxRowScrollRegions = 1
        Appearance13.BackColor = System.Drawing.Color.White
        Me.GridProduct.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.GridProduct.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.GridProduct.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridProduct.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridProduct.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.GridProduct.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.GridProduct.DisplayLayout.Override.CardAreaAppearance = Appearance4
        Me.GridProduct.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.GridProduct.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.GridProduct.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.GridProduct.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.[Like]
        Me.GridProduct.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance56.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridProduct.DisplayLayout.Override.FilterRowAppearance = Appearance56
        Me.GridProduct.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance57.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(250, Byte), Integer))
        Appearance57.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance57.FontData.BoldAsString = "True"
        Appearance57.TextHAlignAsString = "Left"
        Appearance57.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.GridProduct.DisplayLayout.Override.HeaderAppearance = Appearance57
        Me.GridProduct.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.GridProduct.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.GridProduct.DisplayLayout.Override.RowSelectorWidth = 12
        Me.GridProduct.DisplayLayout.Override.RowSpacingBefore = 0
        Appearance60.BackColor = System.Drawing.Color.White
        Appearance60.ForeColor = System.Drawing.Color.Black
        Me.GridProduct.DisplayLayout.Override.SelectedRowAppearance = Appearance60
        Me.GridProduct.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridProduct.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.GridProduct.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridProduct.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridProduct.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.GridProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridProduct.Location = New System.Drawing.Point(3, 17)
        Me.GridProduct.Name = "GridProduct"
        Me.GridProduct.Size = New System.Drawing.Size(280, 206)
        Me.GridProduct.TabIndex = 3
        '
        'grpTotalBranch
        '
        Me.grpTotalBranch.Controls.Add(Me.Panel1)
        GridBagConstraint5.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint5.OriginX = 0
        GridBagConstraint5.OriginY = 1
        Me.GridBagLayout.SetGridBagConstraint(Me.grpTotalBranch, GridBagConstraint5)
        Appearance1.FontData.BoldAsString = "True"
        Me.grpTotalBranch.HeaderAppearance = Appearance1
        Me.grpTotalBranch.Location = New System.Drawing.Point(0, 226)
        Me.grpTotalBranch.Name = "grpTotalBranch"
        Me.GridBagLayout.SetPreferredSize(Me.grpTotalBranch, New System.Drawing.Size(402, 131))
        Me.grpTotalBranch.Size = New System.Drawing.Size(461, 270)
        Me.grpTotalBranch.TabIndex = 2
        Me.grpTotalBranch.Text = "Tổng doanh thu theo ...(coming soon...)"
        Me.grpTotalBranch.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblTienThuVe)
        Me.Panel1.Controls.Add(Me.lblLoiNhuan)
        Me.Panel1.Controls.Add(Me.UltraLabel8)
        Me.Panel1.Controls.Add(Me.UltraLabel7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(455, 250)
        Me.Panel1.TabIndex = 1
        '
        'lblTienThuVe
        '
        Appearance38.BackColor = System.Drawing.Color.Transparent
        Appearance38.FontData.SizeInPoints = 20.0!
        Appearance38.ForeColor = System.Drawing.Color.Red
        Appearance38.TextHAlignAsString = "Center"
        Appearance38.TextVAlignAsString = "Middle"
        Me.lblTienThuVe.Appearance = Appearance38
        Me.lblTienThuVe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTienThuVe.Location = New System.Drawing.Point(7, 17)
        Me.lblTienThuVe.Name = "lblTienThuVe"
        Me.lblTienThuVe.Size = New System.Drawing.Size(274, 40)
        Me.lblTienThuVe.TabIndex = 0
        Me.lblTienThuVe.Text = "..."
        '
        'lblLoiNhuan
        '
        Appearance39.BackColor = System.Drawing.Color.Transparent
        Appearance39.FontData.SizeInPoints = 20.0!
        Appearance39.ForeColor = System.Drawing.Color.Gold
        Appearance39.TextHAlignAsString = "Center"
        Appearance39.TextVAlignAsString = "Middle"
        Me.lblLoiNhuan.Appearance = Appearance39
        Me.lblLoiNhuan.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoiNhuan.Location = New System.Drawing.Point(7, 119)
        Me.lblLoiNhuan.Name = "lblLoiNhuan"
        Me.lblLoiNhuan.Size = New System.Drawing.Size(274, 40)
        Me.lblLoiNhuan.TabIndex = 0
        Me.lblLoiNhuan.Text = "..."
        '
        'UltraLabel8
        '
        Appearance40.BackColor = System.Drawing.Color.Transparent
        Appearance40.TextHAlignAsString = "Center"
        Appearance40.TextVAlignAsString = "Middle"
        Me.UltraLabel8.Appearance = Appearance40
        Me.UltraLabel8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel8.Location = New System.Drawing.Point(7, 162)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(274, 23)
        Me.UltraLabel8.TabIndex = 0
        Me.UltraLabel8.Text = "Revenue of ..."
        '
        'UltraLabel7
        '
        Appearance41.BackColor = System.Drawing.Color.Transparent
        Appearance41.TextHAlignAsString = "Center"
        Appearance41.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance41
        Me.UltraLabel7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel7.Location = New System.Drawing.Point(7, 63)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(274, 23)
        Me.UltraLabel7.TabIndex = 0
        Me.UltraLabel7.Text = "Revenue of ..."
        '
        'grpRevenueByProject
        '
        Me.grpRevenueByProject.Controls.Add(Me.ChartByProject)
        GridBagConstraint6.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint6.OriginX = 1
        GridBagConstraint6.OriginY = 1
        Me.GridBagLayout.SetGridBagConstraint(Me.grpRevenueByProject, GridBagConstraint6)
        Appearance55.FontData.BoldAsString = "True"
        Me.grpRevenueByProject.HeaderAppearance = Appearance55
        Me.grpRevenueByProject.Location = New System.Drawing.Point(461, 226)
        Me.grpRevenueByProject.Name = "grpRevenueByProject"
        Me.GridBagLayout.SetPreferredSize(Me.grpRevenueByProject, New System.Drawing.Size(222, 110))
        Me.grpRevenueByProject.Size = New System.Drawing.Size(255, 270)
        Me.grpRevenueByProject.TabIndex = 2
        Me.grpRevenueByProject.Text = "Doanh thu theo dự án"
        Me.grpRevenueByProject.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        '			'UltraChart' properties's serialization: Since 'ChartType' changes the way axes look,
        '			'ChartType' must be persisted ahead of any Axes change made in design time.
        '		
        Me.ChartByProject.ChartType = Infragistics.UltraChart.[Shared].Styles.ChartType.DoughnutChart
        '
        'ChartByProject
        '
        Me.ChartByProject.Axis.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        PaintElement4.ElementType = Infragistics.UltraChart.[Shared].Styles.PaintElementType.None
        PaintElement4.Fill = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ChartByProject.Axis.PE = PaintElement4
        Me.ChartByProject.Axis.X.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByProject.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.ChartByProject.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.X.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.X.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByProject.Axis.X.Labels.SeriesLabels.FormatString = ""
        Me.ChartByProject.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.X.LineThickness = 1
        Me.ChartByProject.Axis.X.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByProject.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.X.MajorGridLines.Visible = True
        Me.ChartByProject.Axis.X.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByProject.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.X.MinorGridLines.Visible = False
        Me.ChartByProject.Axis.X.TickmarkIntervalType = Infragistics.UltraChart.[Shared].Styles.AxisIntervalType.Hours
        Me.ChartByProject.Axis.X.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByProject.Axis.X.Visible = False
        Me.ChartByProject.Axis.X2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartByProject.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.X2.Labels.ItemFormatString = ""
        Me.ChartByProject.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.X2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.X2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartByProject.Axis.X2.Labels.SeriesLabels.FormatString = ""
        Me.ChartByProject.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.X2.LineThickness = 1
        Me.ChartByProject.Axis.X2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByProject.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.X2.MajorGridLines.Visible = True
        Me.ChartByProject.Axis.X2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByProject.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.X2.MinorGridLines.Visible = False
        Me.ChartByProject.Axis.X2.TickmarkIntervalType = Infragistics.UltraChart.[Shared].Styles.AxisIntervalType.Hours
        Me.ChartByProject.Axis.X2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByProject.Axis.X2.Visible = False
        Me.ChartByProject.Axis.Y.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByProject.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>"
        Me.ChartByProject.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.Y.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.Y.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByProject.Axis.Y.Labels.SeriesLabels.FormatString = ""
        Me.ChartByProject.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.Y.LineThickness = 1
        Me.ChartByProject.Axis.Y.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByProject.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.Y.MajorGridLines.Visible = True
        Me.ChartByProject.Axis.Y.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByProject.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.Y.MinorGridLines.Visible = False
        Me.ChartByProject.Axis.Y.TickmarkInterval = 100
        Me.ChartByProject.Axis.Y.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByProject.Axis.Y.Visible = False
        Me.ChartByProject.Axis.Y2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartByProject.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.Y2.Labels.ItemFormatString = ""
        Me.ChartByProject.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.Y2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartByProject.Axis.Y2.Labels.SeriesLabels.FormatString = ""
        Me.ChartByProject.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.Y2.LineThickness = 1
        Me.ChartByProject.Axis.Y2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByProject.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.Y2.MajorGridLines.Visible = True
        Me.ChartByProject.Axis.Y2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByProject.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.Y2.MinorGridLines.Visible = False
        Me.ChartByProject.Axis.Y2.TickmarkInterval = 100
        Me.ChartByProject.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByProject.Axis.Y2.Visible = False
        Me.ChartByProject.Axis.Z.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByProject.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.Z.Labels.ItemFormatString = "<ITEM_LABEL>"
        Me.ChartByProject.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.Z.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.Z.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray
        Me.ChartByProject.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.Z.LineThickness = 1
        Me.ChartByProject.Axis.Z.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByProject.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.Z.MajorGridLines.Visible = True
        Me.ChartByProject.Axis.Z.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByProject.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.Z.MinorGridLines.Visible = False
        Me.ChartByProject.Axis.Z.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByProject.Axis.Z.Visible = False
        Me.ChartByProject.Axis.Z2.Labels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray
        Me.ChartByProject.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.Z2.Labels.ItemFormatString = ""
        Me.ChartByProject.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.Z2.Labels.SeriesLabels.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.ChartByProject.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray
        Me.ChartByProject.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near
        Me.ChartByProject.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.[Shared].Styles.AxisLabelLayoutBehaviors.[Auto]
        Me.ChartByProject.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.[Shared].Styles.TextOrientation.Horizontal
        Me.ChartByProject.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center
        Me.ChartByProject.Axis.Z2.LineThickness = 1
        Me.ChartByProject.Axis.Z2.MajorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro
        Me.ChartByProject.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.Z2.MajorGridLines.Visible = True
        Me.ChartByProject.Axis.Z2.MinorGridLines.AlphaLevel = CType(255, Byte)
        Me.ChartByProject.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray
        Me.ChartByProject.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.[Shared].Styles.LineDrawStyle.Dot
        Me.ChartByProject.Axis.Z2.MinorGridLines.Visible = False
        Me.ChartByProject.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.[Shared].Styles.AxisTickStyle.Smart
        Me.ChartByProject.Axis.Z2.Visible = False
        Me.ChartByProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ChartByProject.Border.Thickness = 0
        Me.ChartByProject.ColorModel.AlphaLevel = CType(150, Byte)
        Me.ChartByProject.ColorModel.ColorBegin = System.Drawing.Color.Pink
        Me.ChartByProject.ColorModel.ColorEnd = System.Drawing.Color.DarkRed
        Me.ChartByProject.ColorModel.ModelStyle = Infragistics.UltraChart.[Shared].Styles.ColorModels.CustomLinear
        Me.ChartByProject.Dock = System.Windows.Forms.DockStyle.Fill
        DoughnutChartAppearance1.Labels.FormatString = "<ITEM_LABEL>" & Global.Microsoft.VisualBasic.ChrW(10) & "<PERCENT_VALUE:#0.00>%"
        Me.ChartByProject.DoughnutChart = DoughnutChartAppearance1
        GradientEffect4.Coloring = Infragistics.UltraChart.[Shared].Styles.GradientColoringStyle.Lighten
        GradientEffect4.Style = Infragistics.UltraChart.[Shared].Styles.GradientStyle.HorizontalBump
        Me.ChartByProject.Effects.Effects.Add(GradientEffect4)
        Me.ChartByProject.Location = New System.Drawing.Point(3, 17)
        Me.ChartByProject.Name = "ChartByProject"
        Me.ChartByProject.Size = New System.Drawing.Size(249, 250)
        Me.ChartByProject.TabIndex = 2
        Me.ChartByProject.Tooltips.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartByProject.Tooltips.FormatString = "<DATA_VALUE:#,###>"
        Me.ChartByProject.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray
        Me.ChartByProject.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 496)
        Me.Controls.Add(Me.GridBagLayout)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmDashboard"
        CType(Me.GridBagLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GridBagLayout.ResumeLayout(False)
        CType(Me.grpRevenueByClientGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRevenueByClientGroup.ResumeLayout(False)
        CType(Me.ChartByClientGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpRevenueByItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRevenueByItem.ResumeLayout(False)
        CType(Me.ChartBySubContractor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpTotalSaleChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTotalSaleChart.ResumeLayout(False)
        CType(Me.ChartByItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpItemSaleToday, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpItemSaleToday.ResumeLayout(False)
        CType(Me.GridProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpTotalBranch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTotalBranch.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grpRevenueByProject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRevenueByProject.ResumeLayout(False)
        CType(Me.ChartByProject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridBagLayout As Infragistics.Win.Misc.UltraGridBagLayoutPanel
    Friend WithEvents grpTotalSaleChart As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grpRevenueByClientGroup As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grpTotalBranch As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grpRevenueByProject As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents ChartByItem As Infragistics.Win.UltraWinChart.UltraChart
    Private WithEvents ChartByClientGroup As Infragistics.Win.UltraWinChart.UltraChart
    Private WithEvents ChartByProject As Infragistics.Win.UltraWinChart.UltraChart
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTienThuVe As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblLoiNhuan As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents grpItemSaleToday As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GridProduct As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpRevenueByItem As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents ChartBySubContractor As Infragistics.Win.UltraWinChart.UltraChart
End Class
