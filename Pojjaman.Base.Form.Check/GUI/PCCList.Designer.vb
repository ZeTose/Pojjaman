<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PCCList
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PCCList))
    Me.RadSplitContainer1 = New Telerik.WinControls.UI.RadSplitContainer()
    Me.SplitPanel1 = New Telerik.WinControls.UI.SplitPanel()
    Me.lblPCCode = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtPCCode = New System.Windows.Forms.TextBox()
    Me.txtCode = New System.Windows.Forms.TextBox()
    Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
    Me.txtPaymentStart = New System.Windows.Forms.TextBox()
    Me.txtPaymentEnd = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.dtpPaymentStart = New System.Windows.Forms.DateTimePicker()
    Me.dtpPaymentEnd = New System.Windows.Forms.DateTimePicker()
    Me.btnSearch = New System.Windows.Forms.Button()
    Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
    Me.txtDocDateStart = New System.Windows.Forms.TextBox()
    Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
    Me.lblDocDateStart = New System.Windows.Forms.Label()
    Me.lblDocDateEnd = New System.Windows.Forms.Label()
    Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
    Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
    Me.SplitPanel2 = New Telerik.WinControls.UI.SplitPanel()
    Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
    Me.SplitPanel3 = New Telerik.WinControls.UI.SplitPanel()
    Me.ibtnDelete = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.ibtnAdd = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.ibtnClear = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.RadGridView2 = New Telerik.WinControls.UI.RadGridView()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.txtPaymentcode = New System.Windows.Forms.TextBox()
    CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.RadSplitContainer1.SuspendLayout()
    CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitPanel1.SuspendLayout()
    Me.FixedGroupBox1.SuspendLayout()
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
    Me.RadSplitContainer1.Size = New System.Drawing.Size(926, 540)
    Me.RadSplitContainer1.TabIndex = 0
    Me.RadSplitContainer1.TabStop = False
    Me.RadSplitContainer1.Text = "RadSplitContainer1"
    '
    'SplitPanel1
    '
    Me.SplitPanel1.Controls.Add(Me.Label4)
    Me.SplitPanel1.Controls.Add(Me.txtPaymentcode)
    Me.SplitPanel1.Controls.Add(Me.lblPCCode)
    Me.SplitPanel1.Controls.Add(Me.Label3)
    Me.SplitPanel1.Controls.Add(Me.txtPCCode)
    Me.SplitPanel1.Controls.Add(Me.txtCode)
    Me.SplitPanel1.Controls.Add(Me.FixedGroupBox1)
    Me.SplitPanel1.Controls.Add(Me.btnSearch)
    Me.SplitPanel1.Controls.Add(Me.grbDocDate)
    Me.SplitPanel1.Location = New System.Drawing.Point(0, 0)
    Me.SplitPanel1.Name = "SplitPanel1"
    '
    '
    '
    Me.SplitPanel1.RootElement.MinSize = New System.Drawing.Size(25, 25)
    Me.SplitPanel1.Size = New System.Drawing.Size(926, 130)
    Me.SplitPanel1.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, -0.08988765!)
    Me.SplitPanel1.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, -41)
    Me.SplitPanel1.TabIndex = 0
    Me.SplitPanel1.TabStop = False
    Me.SplitPanel1.Text = "SplitPanel1"
    '
    'lblPCCode
    '
    Me.lblPCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblPCCode.ForeColor = System.Drawing.Color.Black
    Me.lblPCCode.Location = New System.Drawing.Point(22, 34)
    Me.lblPCCode.Name = "lblPCCode"
    Me.lblPCCode.Size = New System.Drawing.Size(83, 18)
    Me.lblPCCode.TabIndex = 26
    Me.lblPCCode.Text = "วงเงิน"
    Me.lblPCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label3.ForeColor = System.Drawing.Color.Black
    Me.Label3.Location = New System.Drawing.Point(19, 11)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(83, 18)
    Me.Label3.TabIndex = 25
    Me.Label3.Text = "เลขที่เคลม"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtPCCode
    '
    Me.txtPCCode.Location = New System.Drawing.Point(111, 34)
    Me.txtPCCode.Name = "txtPCCode"
    Me.txtPCCode.Size = New System.Drawing.Size(294, 20)
    Me.txtPCCode.TabIndex = 24
    '
    'txtCode
    '
    Me.txtCode.Location = New System.Drawing.Point(111, 8)
    Me.txtCode.Name = "txtCode"
    Me.txtCode.Size = New System.Drawing.Size(294, 20)
    Me.txtCode.TabIndex = 23
    '
    'FixedGroupBox1
    '
    Me.FixedGroupBox1.Controls.Add(Me.txtPaymentStart)
    Me.FixedGroupBox1.Controls.Add(Me.txtPaymentEnd)
    Me.FixedGroupBox1.Controls.Add(Me.Label1)
    Me.FixedGroupBox1.Controls.Add(Me.Label2)
    Me.FixedGroupBox1.Controls.Add(Me.dtpPaymentStart)
    Me.FixedGroupBox1.Controls.Add(Me.dtpPaymentEnd)
    Me.FixedGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.FixedGroupBox1.Location = New System.Drawing.Point(667, 21)
    Me.FixedGroupBox1.Name = "FixedGroupBox1"
    Me.FixedGroupBox1.Size = New System.Drawing.Size(228, 68)
    Me.FixedGroupBox1.TabIndex = 22
    Me.FixedGroupBox1.TabStop = False
    Me.FixedGroupBox1.Text = "วันที่จ่าย"
    '
    'txtPaymentStart
    '
    Me.txtPaymentStart.BackColor = System.Drawing.SystemColors.Window
    Me.txtPaymentStart.Location = New System.Drawing.Point(74, 17)
    Me.txtPaymentStart.Name = "txtPaymentStart"
    Me.txtPaymentStart.Size = New System.Drawing.Size(116, 20)
    Me.txtPaymentStart.TabIndex = 20
    '
    'txtPaymentEnd
    '
    Me.txtPaymentEnd.BackColor = System.Drawing.SystemColors.Window
    Me.txtPaymentEnd.Location = New System.Drawing.Point(74, 41)
    Me.txtPaymentEnd.Name = "txtPaymentEnd"
    Me.txtPaymentEnd.Size = New System.Drawing.Size(116, 20)
    Me.txtPaymentEnd.TabIndex = 21
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label1.ForeColor = System.Drawing.Color.Black
    Me.Label1.Location = New System.Drawing.Point(12, 17)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 18)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ตั้งแต่"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.Location = New System.Drawing.Point(12, 41)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(56, 18)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "ถึง"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'dtpPaymentStart
    '
    Me.dtpPaymentStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpPaymentStart.Location = New System.Drawing.Point(74, 17)
    Me.dtpPaymentStart.Name = "dtpPaymentStart"
    Me.dtpPaymentStart.Size = New System.Drawing.Size(144, 20)
    Me.dtpPaymentStart.TabIndex = 1
    '
    'dtpPaymentEnd
    '
    Me.dtpPaymentEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpPaymentEnd.Location = New System.Drawing.Point(74, 41)
    Me.dtpPaymentEnd.Name = "dtpPaymentEnd"
    Me.dtpPaymentEnd.Size = New System.Drawing.Size(144, 20)
    Me.dtpPaymentEnd.TabIndex = 3
    '
    'btnSearch
    '
    Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.btnSearch.Location = New System.Drawing.Point(44, 100)
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
    Me.grbDocDate.Location = New System.Drawing.Point(433, 21)
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
    'SplitPanel2
    '
    Me.SplitPanel2.Controls.Add(Me.RadGridView1)
    Me.SplitPanel2.Location = New System.Drawing.Point(0, 133)
    Me.SplitPanel2.Name = "SplitPanel2"
    '
    '
    '
    Me.SplitPanel2.RootElement.MinSize = New System.Drawing.Size(25, 25)
    Me.SplitPanel2.Size = New System.Drawing.Size(926, 166)
    Me.SplitPanel2.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, -0.02247192!)
    Me.SplitPanel2.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, -11)
    Me.SplitPanel2.TabIndex = 1
    Me.SplitPanel2.TabStop = False
    Me.SplitPanel2.Text = "SplitPanel2"
    '
    'RadGridView1
    '
    Me.RadGridView1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.RadGridView1.Location = New System.Drawing.Point(0, 0)
    Me.RadGridView1.Name = "RadGridView1"
    Me.RadGridView1.Size = New System.Drawing.Size(926, 166)
    Me.RadGridView1.TabIndex = 0
    '
    'SplitPanel3
    '
    Me.SplitPanel3.Controls.Add(Me.ibtnDelete)
    Me.SplitPanel3.Controls.Add(Me.ibtnAdd)
    Me.SplitPanel3.Controls.Add(Me.ibtnClear)
    Me.SplitPanel3.Controls.Add(Me.RadGridView2)
    Me.SplitPanel3.Location = New System.Drawing.Point(0, 302)
    Me.SplitPanel3.Name = "SplitPanel3"
    '
    '
    '
    Me.SplitPanel3.RootElement.MinSize = New System.Drawing.Size(25, 25)
    Me.SplitPanel3.Size = New System.Drawing.Size(926, 238)
    Me.SplitPanel3.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, 0.1123595!)
    Me.SplitPanel3.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, 52)
    Me.SplitPanel3.TabIndex = 2
    Me.SplitPanel3.TabStop = False
    Me.SplitPanel3.Text = "SplitPanel3"
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
    'RadGridView2
    '
    Me.RadGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.RadGridView2.Location = New System.Drawing.Point(0, 39)
    Me.RadGridView2.Name = "RadGridView2"
    Me.RadGridView2.Size = New System.Drawing.Size(926, 199)
    Me.RadGridView2.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label4.ForeColor = System.Drawing.Color.Black
    Me.Label4.Location = New System.Drawing.Point(19, 63)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(83, 18)
    Me.Label4.TabIndex = 28
    Me.Label4.Text = "เลขที่จ่าย"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtPaymentcode
    '
    Me.txtPaymentcode.Location = New System.Drawing.Point(111, 60)
    Me.txtPaymentcode.Name = "txtPaymentcode"
    Me.txtPaymentcode.Size = New System.Drawing.Size(294, 20)
    Me.txtPaymentcode.TabIndex = 27
    '
    'PCCList
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(926, 540)
    Me.Controls.Add(Me.RadSplitContainer1)
    Me.Name = "PCCList"
    Me.Text = "PaymentList"
    CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.RadSplitContainer1.ResumeLayout(False)
    CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitPanel1.ResumeLayout(False)
    Me.SplitPanel1.PerformLayout()
    Me.FixedGroupBox1.ResumeLayout(False)
    Me.FixedGroupBox1.PerformLayout()
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
  Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
  Friend WithEvents txtPaymentStart As System.Windows.Forms.TextBox
  Friend WithEvents txtPaymentEnd As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents dtpPaymentStart As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpPaymentEnd As System.Windows.Forms.DateTimePicker
  Friend WithEvents lblPCCode As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtPCCode As System.Windows.Forms.TextBox
  Friend WithEvents txtCode As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtPaymentcode As System.Windows.Forms.TextBox
End Class
