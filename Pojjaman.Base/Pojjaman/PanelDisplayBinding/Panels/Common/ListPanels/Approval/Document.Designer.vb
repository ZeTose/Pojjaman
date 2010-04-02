<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Document
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Document))
    Me.numPages = New System.Windows.Forms.NumericUpDown()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.txtPercent = New System.Windows.Forms.TextBox()
    Me.grbMap = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
    Me.pnlPicHolder = New System.Windows.Forms.Panel()
    Me.picMap = New System.Windows.Forms.PictureBox()
    Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton()
    CType(Me.numPages, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.grbMap.SuspendLayout()
    Me.pnlPicHolder.SuspendLayout()
    CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'numPages
    '
    Me.numPages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.numPages.Location = New System.Drawing.Point(718, 95)
    Me.numPages.Name = "numPages"
    Me.numPages.Size = New System.Drawing.Size(40, 20)
    Me.numPages.TabIndex = 1
    '
    'ListBox1
    '
    Me.ListBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ListBox1.FormattingEnabled = True
    Me.ListBox1.Items.AddRange(New Object() {"Form1", "Form2", "Form3", "Form4", "Form5"})
    Me.ListBox1.Location = New System.Drawing.Point(718, 20)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(165, 69)
    Me.ListBox1.TabIndex = 0
    '
    'txtPercent
    '
    Me.txtPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtPercent.Location = New System.Drawing.Point(818, 95)
    Me.txtPercent.Name = "txtPercent"
    Me.txtPercent.ReadOnly = True
    Me.txtPercent.Size = New System.Drawing.Size(48, 20)
    Me.txtPercent.TabIndex = 4
    '
    'grbMap
    '
    Me.grbMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.grbMap.Controls.Add(Me.pnlPicHolder)
    Me.grbMap.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.grbMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.grbMap.Location = New System.Drawing.Point(3, 3)
    Me.grbMap.Name = "grbMap"
    Me.grbMap.Size = New System.Drawing.Size(687, 495)
    Me.grbMap.TabIndex = 17
    Me.grbMap.TabStop = False
    Me.grbMap.Text = "Preview"
    '
    'pnlPicHolder
    '
    Me.pnlPicHolder.AutoScroll = True
    Me.pnlPicHolder.Controls.Add(Me.picMap)
    Me.pnlPicHolder.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pnlPicHolder.Location = New System.Drawing.Point(3, 17)
    Me.pnlPicHolder.Name = "pnlPicHolder"
    Me.pnlPicHolder.Size = New System.Drawing.Size(681, 475)
    Me.pnlPicHolder.TabIndex = 0
    '
    'picMap
    '
    Me.picMap.BackColor = System.Drawing.SystemColors.Window
    Me.picMap.Location = New System.Drawing.Point(0, 0)
    Me.picMap.Name = "picMap"
    Me.picMap.Size = New System.Drawing.Size(660, 661)
    Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.picMap.TabIndex = 6
    Me.picMap.TabStop = False
    '
    'ibtnZoomIn
    '
    Me.ibtnZoomIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ibtnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ibtnZoomIn.Location = New System.Drawing.Point(788, 95)
    Me.ibtnZoomIn.Name = "ibtnZoomIn"
    Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
    Me.ibtnZoomIn.TabIndex = 3
    Me.ibtnZoomIn.TabStop = False
    Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
    '
    'ibtnZoomOut
    '
    Me.ibtnZoomOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ibtnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ibtnZoomOut.Location = New System.Drawing.Point(764, 95)
    Me.ibtnZoomOut.Name = "ibtnZoomOut"
    Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
    Me.ibtnZoomOut.TabIndex = 2
    Me.ibtnZoomOut.TabStop = False
    Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
    '
    'Document
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.grbMap)
    Me.Controls.Add(Me.ListBox1)
    Me.Controls.Add(Me.txtPercent)
    Me.Controls.Add(Me.ibtnZoomIn)
    Me.Controls.Add(Me.ibtnZoomOut)
    Me.Controls.Add(Me.numPages)
    Me.Name = "Document"
    Me.Size = New System.Drawing.Size(886, 690)
    CType(Me.numPages, System.ComponentModel.ISupportInitialize).EndInit()
    Me.grbMap.ResumeLayout(False)
    Me.pnlPicHolder.ResumeLayout(False)
    CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents grbMap As Longkong.Pojjaman.Gui.Components.FixedGroupBox
  Friend WithEvents pnlPicHolder As System.Windows.Forms.Panel
  Friend WithEvents picMap As System.Windows.Forms.PictureBox
  Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
  Friend WithEvents numPages As System.Windows.Forms.NumericUpDown
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
  Friend WithEvents txtPercent As System.Windows.Forms.TextBox

End Class
