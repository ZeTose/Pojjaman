<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentList
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
    Me.components = New System.ComponentModel.Container()
    Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("PO-9111", 0)
    Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("PO-12121", 0)
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentList))
    Me.lvItem = New System.Windows.Forms.ListView()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'lvItem
    '
    Me.lvItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lvItem.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
    Me.lvItem.LargeImageList = Me.ImageList1
    Me.lvItem.Location = New System.Drawing.Point(3, 28)
    Me.lvItem.Name = "lvItem"
    Me.lvItem.Size = New System.Drawing.Size(519, 80)
    Me.lvItem.TabIndex = 0
    Me.lvItem.UseCompatibleStateImageBehavior = False
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "bt.jpg")
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripTextBox1})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.Size = New System.Drawing.Size(525, 25)
    Me.ToolStrip1.TabIndex = 1
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'ToolStripButton1
    '
    Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
    Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1.Name = "ToolStripButton1"
    Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton1.Text = "ToolStripButton1"
    '
    'ToolStripTextBox1
    '
    Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
    Me.ToolStripTextBox1.Size = New System.Drawing.Size(200, 25)
    '
    'DocumentList
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.ToolStrip1)
    Me.Controls.Add(Me.lvItem)
    Me.Name = "DocumentList"
    Me.Size = New System.Drawing.Size(525, 121)
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lvItem As System.Windows.Forms.ListView
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
  Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton

End Class
