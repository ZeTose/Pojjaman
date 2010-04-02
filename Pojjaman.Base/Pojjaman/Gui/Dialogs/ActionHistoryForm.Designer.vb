Namespace Longkong.Pojjaman.Gui.Panels
  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class ActionHistoryForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActionHistoryForm))
      Me.lstLogs = New System.Windows.Forms.ListBox()
      Me.ImageList1 = New System.Windows.Forms.ImageList()
      Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
      Me.btnPrint = New System.Windows.Forms.Button()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtPercent = New System.Windows.Forms.TextBox()
      Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ListBox1 = New System.Windows.Forms.ListBox()
      Me.numPages = New System.Windows.Forms.NumericUpDown()
      Me.grbMap = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.pnlPicHolder = New System.Windows.Forms.Panel()
      Me.picMap = New System.Windows.Forms.PictureBox()
      Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.FlowLayoutPanel1.SuspendLayout()
      CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.FixedGroupBox1.SuspendLayout()
      CType(Me.numPages, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbMap.SuspendLayout()
      Me.pnlPicHolder.SuspendLayout()
      CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lstLogs
      '
      Me.lstLogs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstLogs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
      Me.lstLogs.FormattingEnabled = True
      Me.lstLogs.Location = New System.Drawing.Point(12, 25)
      Me.lstLogs.Name = "lstLogs"
      Me.lstLogs.Size = New System.Drawing.Size(953, 19)
      Me.lstLogs.TabIndex = 1
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "Icons.32x32.approve.png")
      Me.ImageList1.Images.SetKeyName(1, "Icons.32x32.authorize.png")
      Me.ImageList1.Images.SetKeyName(2, "Icons.32x32.reject.png")
      '
      'FlowLayoutPanel1
      '
      Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.FlowLayoutPanel1.Controls.Add(Me.btnPrint)
      Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 19)
      Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
      Me.FlowLayoutPanel1.Size = New System.Drawing.Size(538, 44)
      Me.FlowLayoutPanel1.TabIndex = 6
      '
      'btnPrint
      '
      Me.btnPrint.Location = New System.Drawing.Point(3, 3)
      Me.btnPrint.Name = "btnPrint"
      Me.btnPrint.Size = New System.Drawing.Size(75, 23)
      Me.btnPrint.TabIndex = 0
      Me.btnPrint.Text = "Print"
      Me.btnPrint.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.Location = New System.Drawing.Point(9, 6)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(209, 20)
      Me.Label2.TabIndex = 0
      Me.Label2.Text = "History of this document:"
      '
      'SplitContainer1
      '
      Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.FixedGroupBox1)
      Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
      Me.SplitContainer1.Panel1.Controls.Add(Me.txtPercent)
      Me.SplitContainer1.Panel1.Controls.Add(Me.ibtnZoomOut)
      Me.SplitContainer1.Panel1.Controls.Add(Me.ListBox1)
      Me.SplitContainer1.Panel1.Controls.Add(Me.numPages)
      Me.SplitContainer1.Panel1.Controls.Add(Me.grbMap)
      Me.SplitContainer1.Panel1.Controls.Add(Me.ibtnZoomIn)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.lstLogs)
      Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
      Me.SplitContainer1.Size = New System.Drawing.Size(982, 668)
      Me.SplitContainer1.SplitterDistance = 616
      Me.SplitContainer1.TabIndex = 0
      '
      'FixedGroupBox1
      '
      Me.FixedGroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.FixedGroupBox1.Controls.Add(Me.FlowLayoutPanel1)
      Me.FixedGroupBox1.Location = New System.Drawing.Point(420, 12)
      Me.FixedGroupBox1.Name = "FixedGroupBox1"
      Me.FixedGroupBox1.Size = New System.Drawing.Size(548, 69)
      Me.FixedGroupBox1.TabIndex = 9
      Me.FixedGroupBox1.TabStop = False
      Me.FixedGroupBox1.Text = "Possible Actions:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 12)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(75, 13)
      Me.Label3.TabIndex = 8
      Me.Label3.Text = "Select a Form:"
      '
      'txtPercent
      '
      Me.txtPercent.Location = New System.Drawing.Point(296, 61)
      Me.txtPercent.Name = "txtPercent"
      Me.txtPercent.ReadOnly = True
      Me.txtPercent.Size = New System.Drawing.Size(48, 20)
      Me.txtPercent.TabIndex = 4
      '
      'ibtnZoomOut
      '
      Me.ibtnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnZoomOut.Location = New System.Drawing.Point(296, 35)
      Me.ibtnZoomOut.Name = "ibtnZoomOut"
      Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomOut.TabIndex = 2
      Me.ibtnZoomOut.TabStop = False
      Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
      '
      'ListBox1
      '
      Me.ListBox1.FormattingEnabled = True
      Me.ListBox1.Items.AddRange(New Object() {"Form1", "Form2", "Form3", "Form4", "Form5"})
      Me.ListBox1.Location = New System.Drawing.Point(93, 12)
      Me.ListBox1.Name = "ListBox1"
      Me.ListBox1.Size = New System.Drawing.Size(197, 69)
      Me.ListBox1.TabIndex = 0
      '
      'numPages
      '
      Me.numPages.Location = New System.Drawing.Point(296, 12)
      Me.numPages.Name = "numPages"
      Me.numPages.Size = New System.Drawing.Size(40, 20)
      Me.numPages.TabIndex = 1
      '
      'grbMap
      '
      Me.grbMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMap.Controls.Add(Me.pnlPicHolder)
      Me.grbMap.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMap.Location = New System.Drawing.Point(15, 87)
      Me.grbMap.Name = "grbMap"
      Me.grbMap.Size = New System.Drawing.Size(962, 515)
      Me.grbMap.TabIndex = 7
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
      Me.pnlPicHolder.Size = New System.Drawing.Size(956, 495)
      Me.pnlPicHolder.TabIndex = 0
      '
      'picMap
      '
      Me.picMap.BackColor = System.Drawing.SystemColors.Window
      Me.picMap.Location = New System.Drawing.Point(0, 0)
      Me.picMap.Name = "picMap"
      Me.picMap.Size = New System.Drawing.Size(932, 326)
      Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picMap.TabIndex = 6
      Me.picMap.TabStop = False
      '
      'ibtnZoomIn
      '
      Me.ibtnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnZoomIn.Location = New System.Drawing.Point(320, 35)
      Me.ibtnZoomIn.Name = "ibtnZoomIn"
      Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomIn.TabIndex = 3
      Me.ibtnZoomIn.TabStop = False
      Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
      '
      'ActionHistoryForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(982, 668)
      Me.Controls.Add(Me.SplitContainer1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Name = "ActionHistoryForm"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Approval/Authorization"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me.FlowLayoutPanel1.ResumeLayout(False)
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel1.PerformLayout()
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.Panel2.PerformLayout()
      CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SplitContainer1.ResumeLayout(False)
      Me.FixedGroupBox1.ResumeLayout(False)
      CType(Me.numPages, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbMap.ResumeLayout(False)
      Me.pnlPicHolder.ResumeLayout(False)
      CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstLogs As System.Windows.Forms.ListBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtPercent As System.Windows.Forms.TextBox
    Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbMap As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents pnlPicHolder As System.Windows.Forms.Panel
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents numPages As System.Windows.Forms.NumericUpDown
    Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
  End Class

End Namespace
