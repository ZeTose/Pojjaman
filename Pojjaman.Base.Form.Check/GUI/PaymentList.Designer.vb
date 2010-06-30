<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentList
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaymentList))
    Me.RadSplitContainer1 = New Telerik.WinControls.UI.RadSplitContainer()
    Me.SplitPanel1 = New Telerik.WinControls.UI.SplitPanel()
    Me.btnSearch = New System.Windows.Forms.Button()
    Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
    Me.txtDocDateStart = New System.Windows.Forms.TextBox()
    Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
    Me.lblDocDateStart = New System.Windows.Forms.Label()
    Me.lblDocDateEnd = New System.Windows.Forms.Label()
    Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
    Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
    Me.btnSupplierFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.txtSupplierCode = New System.Windows.Forms.TextBox()
    Me.lblSupplier = New System.Windows.Forms.Label()
    Me.txtSupplierName = New System.Windows.Forms.TextBox()
    Me.SplitPanel2 = New Telerik.WinControls.UI.SplitPanel()
    Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
    Me.SplitPanel3 = New Telerik.WinControls.UI.SplitPanel()
    Me.RadGridView2 = New Telerik.WinControls.UI.RadGridView()
    Me.ibtnDelete = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.ibtnAdd = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.ibtnClear = New Longkong.Pojjaman.Gui.Components.ImageButton()
    CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.RadSplitContainer1.SuspendLayout()
    CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitPanel1.SuspendLayout()
    Me.grbDocDate.SuspendLayout()
    CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitPanel2.SuspendLayout()
    CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SplitPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitPanel3.SuspendLayout()
    CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'RadSplitContainer1
    '
    Me.RadSplitContainer1.Controls.Add(Me.SplitPanel1)
    Me.RadSplitContainer1.Controls.Add(Me.SplitPanel2)
    Me.RadSplitContainer1.Controls.Add(Me.SplitPanel3)
    Me.RadSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.RadSplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.RadSplitContainer1.Name = "RadSplitContainer1"
    Me.RadSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    '
    '
    Me.RadSplitContainer1.RootElement.MinSize = New System.Drawing.Size(25, 25)
    Me.RadSplitContainer1.Size = New System.Drawing.Size(827, 462)
    Me.RadSplitContainer1.TabIndex = 0
    Me.RadSplitContainer1.TabStop = False
    Me.RadSplitContainer1.Text = "RadSplitContainer1"
    '
    'SplitPanel1
    '
    Me.SplitPanel1.Controls.Add(Me.btnSearch)
    Me.SplitPanel1.Controls.Add(Me.grbDocDate)
    Me.SplitPanel1.Controls.Add(Me.btnSupplierFind)
    Me.SplitPanel1.Controls.Add(Me.txtSupplierCode)
    Me.SplitPanel1.Controls.Add(Me.lblSupplier)
    Me.SplitPanel1.Controls.Add(Me.txtSupplierName)
    Me.SplitPanel1.Location = New System.Drawing.Point(0, 0)
    Me.SplitPanel1.Name = "SplitPanel1"
    '
    '
    '
    Me.SplitPanel1.RootElement.MinSize = New System.Drawing.Size(25, 25)
    Me.SplitPanel1.Size = New System.Drawing.Size(827, 111)
    Me.SplitPanel1.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, -0.08991229!)
    Me.SplitPanel1.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, -41)
    Me.SplitPanel1.TabIndex = 0
    Me.SplitPanel1.TabStop = False
    Me.SplitPanel1.Text = "SplitPanel1"
    '
    'btnSearch
    '
    Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.btnSearch.Location = New System.Drawing.Point(352, 84)
    Me.btnSearch.Name = "btnSearch"
    Me.btnSearch.Size = New System.Drawing.Size(75, 23)
    Me.btnSearch.TabIndex = 21
    Me.btnSearch.Text = "ค้นหา"
    '
    'grbDocDate
    '
    Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
    Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
    Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
    Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
    Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
    Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
    Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.grbDocDate.Location = New System.Drawing.Point(118, 39)
    Me.grbDocDate.Name = "grbDocDate"
    Me.grbDocDate.Size = New System.Drawing.Size(228, 68)
    Me.grbDocDate.TabIndex = 19
    Me.grbDocDate.TabStop = False
    Me.grbDocDate.Text = "วันที่เอกสาร"
    '
    'txtDocDateStart
    '
    Me.txtDocDateStart.BackColor = System.Drawing.SystemColors.Window
    Me.txtDocDateStart.Location = New System.Drawing.Point(74, 17)
    Me.txtDocDateStart.Name = "txtDocDateStart"
    Me.txtDocDateStart.Size = New System.Drawing.Size(116, 20)
    Me.txtDocDateStart.TabIndex = 20
    '
    'txtDocDateEnd
    '
    Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
    Me.txtDocDateEnd.Location = New System.Drawing.Point(74, 41)
    Me.txtDocDateEnd.Name = "txtDocDateEnd"
    Me.txtDocDateEnd.Size = New System.Drawing.Size(116, 20)
    Me.txtDocDateEnd.TabIndex = 21
    '
    'lblDocDateStart
    '
    Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
    Me.lblDocDateStart.Location = New System.Drawing.Point(12, 17)
    Me.lblDocDateStart.Name = "lblDocDateStart"
    Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
    Me.lblDocDateStart.TabIndex = 0
    Me.lblDocDateStart.Text = "ตั้งแต่"
    Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblDocDateEnd
    '
    Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
    Me.lblDocDateEnd.Location = New System.Drawing.Point(12, 41)
    Me.lblDocDateEnd.Name = "lblDocDateEnd"
    Me.lblDocDateEnd.Size = New System.Drawing.Size(56, 18)
    Me.lblDocDateEnd.TabIndex = 2
    Me.lblDocDateEnd.Text = "ถึง"
    Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'dtpDocDateStart
    '
    Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpDocDateStart.Location = New System.Drawing.Point(74, 17)
    Me.dtpDocDateStart.Name = "dtpDocDateStart"
    Me.dtpDocDateStart.Size = New System.Drawing.Size(144, 20)
    Me.dtpDocDateStart.TabIndex = 1
    '
    'dtpDocDateEnd
    '
    Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpDocDateEnd.Location = New System.Drawing.Point(74, 41)
    Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
    Me.dtpDocDateEnd.Size = New System.Drawing.Size(144, 20)
    Me.dtpDocDateEnd.TabIndex = 3
    '
    'btnSupplierFind
    '
    Me.btnSupplierFind.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.btnSupplierFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.btnSupplierFind.ForeColor = System.Drawing.SystemColors.Control
    Me.btnSupplierFind.Location = New System.Drawing.Point(374, 12)
    Me.btnSupplierFind.Name = "btnSupplierFind"
    Me.btnSupplierFind.Size = New System.Drawing.Size(24, 23)
    Me.btnSupplierFind.TabIndex = 15
    Me.btnSupplierFind.TabStop = False
    Me.btnSupplierFind.ThemedImage = CType(resources.GetObject("btnSupplierFind.ThemedImage"), System.Drawing.Bitmap)
    '
    'txtSupplierCode
    '
    Me.txtSupplierCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.txtSupplierCode.Location = New System.Drawing.Point(118, 12)
    Me.txtSupplierCode.Name = "txtSupplierCode"
    Me.txtSupplierCode.Size = New System.Drawing.Size(88, 21)
    Me.txtSupplierCode.TabIndex = 13
    '
    'lblSupplier
    '
    Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblSupplier.ForeColor = System.Drawing.Color.Black
    Me.lblSupplier.Location = New System.Drawing.Point(14, 12)
    Me.lblSupplier.Name = "lblSupplier"
    Me.lblSupplier.Size = New System.Drawing.Size(96, 18)
    Me.lblSupplier.TabIndex = 12
    Me.lblSupplier.Text = "Supplier:"
    Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtSupplierName
    '
    Me.txtSupplierName.BackColor = System.Drawing.SystemColors.Control
    Me.txtSupplierName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.txtSupplierName.Location = New System.Drawing.Point(206, 12)
    Me.txtSupplierName.Name = "txtSupplierName"
    Me.txtSupplierName.ReadOnly = True
    Me.txtSupplierName.Size = New System.Drawing.Size(168, 21)
    Me.txtSupplierName.TabIndex = 14
    '
    'SplitPanel2
    '
    Me.SplitPanel2.Controls.Add(Me.RadGridView1)
    Me.SplitPanel2.Location = New System.Drawing.Point(0, 114)
    Me.SplitPanel2.Name = "SplitPanel2"
    '
    '
    '
    Me.SplitPanel2.RootElement.MinSize = New System.Drawing.Size(25, 25)
    Me.SplitPanel2.Size = New System.Drawing.Size(827, 195)
    Me.SplitPanel2.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, 0.09429824!)
    Me.SplitPanel2.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, 43)
    Me.SplitPanel2.TabIndex = 1
    Me.SplitPanel2.TabStop = False
    Me.SplitPanel2.Text = "SplitPanel2"
    '
    'RadGridView1
    '
    Me.RadGridView1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.RadGridView1.Location = New System.Drawing.Point(0, 0)
    Me.RadGridView1.Name = "RadGridView1"
    Me.RadGridView1.Size = New System.Drawing.Size(827, 195)
    Me.RadGridView1.TabIndex = 0
    '
    'SplitPanel3
    '
    Me.SplitPanel3.Controls.Add(Me.ibtnDelete)
    Me.SplitPanel3.Controls.Add(Me.ibtnAdd)
    Me.SplitPanel3.Controls.Add(Me.ibtnClear)
    Me.SplitPanel3.Controls.Add(Me.RadGridView2)
    Me.SplitPanel3.Location = New System.Drawing.Point(0, 312)
    Me.SplitPanel3.Name = "SplitPanel3"
    '
    '
    '
    Me.SplitPanel3.RootElement.MinSize = New System.Drawing.Size(25, 25)
    Me.SplitPanel3.Size = New System.Drawing.Size(827, 150)
    Me.SplitPanel3.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, -0.004385975!)
    Me.SplitPanel3.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, -2)
    Me.SplitPanel3.TabIndex = 2
    Me.SplitPanel3.TabStop = False
    Me.SplitPanel3.Text = "SplitPanel3"
    '
    'RadGridView2
    '
    Me.RadGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.RadGridView2.Location = New System.Drawing.Point(0, 39)
    Me.RadGridView2.Name = "RadGridView2"
    Me.RadGridView2.Size = New System.Drawing.Size(827, 111)
    Me.RadGridView2.TabIndex = 1
    '
    'ibtnDelete
    '
    Me.ibtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ibtnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.ibtnDelete.Location = New System.Drawing.Point(44, 3)
    Me.ibtnDelete.Name = "ibtnDelete"
    Me.ibtnDelete.Size = New System.Drawing.Size(32, 32)
    Me.ibtnDelete.TabIndex = 210
    Me.ibtnDelete.TabStop = False
    Me.ibtnDelete.ThemedImage = CType(resources.GetObject("ibtnDelete.ThemedImage"), System.Drawing.Bitmap)
    '
    'ibtnAdd
    '
    Me.ibtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ibtnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.ibtnAdd.ForeColor = System.Drawing.SystemColors.Control
    Me.ibtnAdd.Location = New System.Drawing.Point(12, 3)
    Me.ibtnAdd.Name = "ibtnAdd"
    Me.ibtnAdd.Size = New System.Drawing.Size(32, 32)
    Me.ibtnAdd.TabIndex = 211
    Me.ibtnAdd.TabStop = False
    Me.ibtnAdd.ThemedImage = CType(resources.GetObject("ibtnAdd.ThemedImage"), System.Drawing.Bitmap)
    '
    'ibtnClear
    '
    Me.ibtnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.ibtnClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.ibtnClear.Location = New System.Drawing.Point(76, 3)
    Me.ibtnClear.Name = "ibtnClear"
    Me.ibtnClear.Size = New System.Drawing.Size(32, 32)
    Me.ibtnClear.TabIndex = 209
    Me.ibtnClear.TabStop = False
    Me.ibtnClear.ThemedImage = CType(resources.GetObject("ibtnClear.ThemedImage"), System.Drawing.Bitmap)
    '
    'PaymentList
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(827, 462)
    Me.Controls.Add(Me.RadSplitContainer1)
    Me.Name = "PaymentList"
    Me.Text = "PaymentList"
    CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.RadSplitContainer1.ResumeLayout(False)
    CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitPanel1.ResumeLayout(False)
    Me.SplitPanel1.PerformLayout()
    Me.grbDocDate.ResumeLayout(False)
    Me.grbDocDate.PerformLayout()
    CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitPanel2.ResumeLayout(False)
    CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SplitPanel3, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitPanel3.ResumeLayout(False)
    CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents RadSplitContainer1 As Telerik.WinControls.UI.RadSplitContainer
  Friend WithEvents SplitPanel1 As Telerik.WinControls.UI.SplitPanel
  Friend WithEvents SplitPanel2 As Telerik.WinControls.UI.SplitPanel
  Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
  Friend WithEvents SplitPanel3 As Telerik.WinControls.UI.SplitPanel
  Friend WithEvents RadGridView2 As Telerik.WinControls.UI.RadGridView
  Friend WithEvents btnSupplierFind As Longkong.Pojjaman.Gui.Components.ImageButton
  Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
  Friend WithEvents lblSupplier As System.Windows.Forms.Label
  Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
  Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
  Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
  Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
  Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
  Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
  Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
  Friend WithEvents btnSearch As System.Windows.Forms.Button
  Friend WithEvents ibtnDelete As Longkong.Pojjaman.Gui.Components.ImageButton
  Friend WithEvents ibtnAdd As Longkong.Pojjaman.Gui.Components.ImageButton
  Friend WithEvents ibtnClear As Longkong.Pojjaman.Gui.Components.ImageButton
End Class
