<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrystalForm
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
    Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'CrystalReportViewer1
    '
    Me.CrystalReportViewer1.ActiveViewIndex = -1
    Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
    Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
    Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
    Me.CrystalReportViewer1.ShowCloseButton = False
    Me.CrystalReportViewer1.ShowGroupTreeButton = False
    Me.CrystalReportViewer1.ShowParameterPanelButton = False
    Me.CrystalReportViewer1.ShowRefreshButton = False
    Me.CrystalReportViewer1.ShowTextSearchButton = False
    Me.CrystalReportViewer1.Size = New System.Drawing.Size(1105, 571)
    Me.CrystalReportViewer1.TabIndex = 0
    Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    '
    'Label1
    '
    Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label1.Location = New System.Drawing.Point(325, 4)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(776, 21)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Label1"
    '
    'CrystalForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1105, 571)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.CrystalReportViewer1)
    Me.Name = "CrystalForm"
    Me.Text = "CrystalForm"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
  Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
