<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportBarcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportBarcode))
        Me.rpt = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton
        Me.SuspendLayout()
        '
        'rpt
        '
        Me.rpt.ActiveViewIndex = -1
        Me.rpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rpt.DisplayGroupTree = False
        Me.rpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt.Location = New System.Drawing.Point(0, 0)
        Me.rpt.Name = "rpt"
        Me.rpt.SelectionFormula = ""
        Me.rpt.Size = New System.Drawing.Size(617, 499)
        Me.rpt.TabIndex = 0
        Me.rpt.ViewTimeSelectionFormula = ""
        '
        'UltraButton1
        '
        Me.UltraButton1.Location = New System.Drawing.Point(376, 2)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(75, 23)
        Me.UltraButton1.TabIndex = 1
        Me.UltraButton1.Text = "View design"
        Me.UltraButton1.Visible = False
        '
        'FrmReportBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 499)
        Me.Controls.Add(Me.UltraButton1)
        Me.Controls.Add(Me.rpt)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmReportBarcode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IN MÃ VẠCH"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
End Class
