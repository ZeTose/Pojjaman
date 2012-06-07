<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResponseForm
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
    Me.ListView1 = New System.Windows.Forms.ListView()
    Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ListView2 = New System.Windows.Forms.ListView()
    Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.SuspendLayout()
    '
    'ListView1
    '
    Me.ListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader5})
    Me.ListView1.FullRowSelect = True
    Me.ListView1.Location = New System.Drawing.Point(-1, 0)
    Me.ListView1.Name = "ListView1"
    Me.ListView1.Size = New System.Drawing.Size(554, 208)
    Me.ListView1.TabIndex = 0
    Me.ListView1.UseCompatibleStateImageBehavior = False
    Me.ListView1.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader1
    '
    Me.ColumnHeader1.Text = ""
    Me.ColumnHeader1.Width = 25
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Text = "รายการ Export เช็คไปที่ธนาคาร"
    Me.ColumnHeader2.Width = 400
    '
    'ListView2
    '
    Me.ListView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader6})
    Me.ListView2.FullRowSelect = True
    Me.ListView2.Location = New System.Drawing.Point(-1, 207)
    Me.ListView2.Name = "ListView2"
    Me.ListView2.Size = New System.Drawing.Size(554, 208)
    Me.ListView2.TabIndex = 0
    Me.ListView2.UseCompatibleStateImageBehavior = False
    Me.ListView2.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader3
    '
    Me.ColumnHeader3.Text = ""
    Me.ColumnHeader3.Width = 25
    '
    'ColumnHeader4
    '
    Me.ColumnHeader4.Text = "รายการที่ Builk.com ตอบรับแล้ว"
    Me.ColumnHeader4.Width = 400
    '
    'ColumnHeader5
    '
    Me.ColumnHeader5.Text = "มูลค่า"
    Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.ColumnHeader5.Width = 120
    '
    'ColumnHeader6
    '
    Me.ColumnHeader6.Text = "มูลค่า"
    Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.ColumnHeader6.Width = 120
    '
    'ResponseForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(555, 417)
    Me.Controls.Add(Me.ListView2)
    Me.Controls.Add(Me.ListView1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    Me.Name = "ResponseForm"
    Me.Text = "รายการ Export เช็คและการตอบรับจาก Builk.com"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents ListView1 As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ListView2 As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
End Class
