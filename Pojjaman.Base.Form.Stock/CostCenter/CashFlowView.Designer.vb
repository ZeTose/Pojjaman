<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashFlowView
    Inherits Telerik.WinControls.UI.RadForm

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
    Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
    Me.lblProjectName = New System.Windows.Forms.Label()
    CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'RadGridView1
    '
    Me.RadGridView1.Location = New System.Drawing.Point(0, 34)
    Me.RadGridView1.Name = "RadGridView1"
    Me.RadGridView1.Size = New System.Drawing.Size(1016, 696)
    Me.RadGridView1.TabIndex = 0
    '
    'lblProjectName
    '
    Me.lblProjectName.AutoSize = True
    Me.lblProjectName.Location = New System.Drawing.Point(12, 9)
    Me.lblProjectName.Name = "lblProjectName"
    Me.lblProjectName.Size = New System.Drawing.Size(454, 13)
    Me.lblProjectName.TabIndex = 1
    Me.lblProjectName.Text = "อาคารเรียนและปฏิบัติการคณะการบัญชีและการจีดการชั้น 8-10 (มหาวิทยาลัยมหาสารคาม)  M" & _
        "K8-1"
    '
    'CashFlowView
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1016, 730)
    Me.Controls.Add(Me.lblProjectName)
    Me.Controls.Add(Me.RadGridView1)
    Me.Name = "CashFlowView"
    '
    '
    '
    Me.RootElement.ApplyShapeToControl = True
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Cashflow"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
  Friend WithEvents lblProjectName As System.Windows.Forms.Label
End Class
