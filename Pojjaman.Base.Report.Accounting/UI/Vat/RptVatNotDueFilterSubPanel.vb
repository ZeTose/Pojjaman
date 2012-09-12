Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptVatNotDueFilterSubPanel
    'Inherits UserControl
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel

#Region " Windows Form Designer generated code "

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents KeepKeyCombo1 As Longkong.Pojjaman.Gui.Components.KeepKeyCombo
    Friend WithEvents KeepKeyCombo2 As Longkong.Pojjaman.Gui.Components.KeepKeyCombo
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
    Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
    Friend WithEvents KeepKeyCombo3 As Longkong.Pojjaman.Gui.Components.KeepKeyCombo
    Friend WithEvents txtDueDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDueDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDueDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDueDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkOnlyRemain As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcludeNoGL As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptVatNotDueFilterSubPanel))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.KeepKeyCombo3 = New Longkong.Pojjaman.Gui.Components.KeepKeyCombo()
      Me.KeepKeyCombo2 = New Longkong.Pojjaman.Gui.Components.KeepKeyCombo()
      Me.KeepKeyCombo1 = New Longkong.Pojjaman.Gui.Components.KeepKeyCombo()
      Me.txtTemp = New System.Windows.Forms.TextBox()
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkOnlyRemain = New System.Windows.Forms.CheckBox()
      Me.txtDueDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDueDocDateStart = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.dtpDueDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDueDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblSuppliEnd = New System.Windows.Forms.Label()
      Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox()
      Me.lblSuppliStart = New System.Windows.Forms.Label()
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox()
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.chkExcludeNoGL = New System.Windows.Forms.CheckBox()
      Me.grbDetail.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.KeepKeyCombo3)
      Me.grbDetail.Controls.Add(Me.KeepKeyCombo2)
      Me.grbDetail.Controls.Add(Me.KeepKeyCombo1)
      Me.grbDetail.Controls.Add(Me.txtTemp)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(519, 200)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "Incoming Vat Report"
      '
      'KeepKeyCombo3
      '
      Me.KeepKeyCombo3.FormattingEnabled = True
      Me.KeepKeyCombo3.Location = New System.Drawing.Point(196, 214)
      Me.KeepKeyCombo3.Name = "KeepKeyCombo3"
      Me.KeepKeyCombo3.Size = New System.Drawing.Size(121, 21)
      Me.KeepKeyCombo3.TabIndex = 54
      '
      'KeepKeyCombo2
      '
      Me.KeepKeyCombo2.FormattingEnabled = True
      Me.KeepKeyCombo2.Location = New System.Drawing.Point(244, 216)
      Me.KeepKeyCombo2.Name = "KeepKeyCombo2"
      Me.KeepKeyCombo2.Size = New System.Drawing.Size(121, 21)
      Me.KeepKeyCombo2.TabIndex = 53
      '
      'KeepKeyCombo1
      '
      Me.KeepKeyCombo1.FormattingEnabled = True
      Me.KeepKeyCombo1.Location = New System.Drawing.Point(35, 215)
      Me.KeepKeyCombo1.Name = "KeepKeyCombo1"
      Me.KeepKeyCombo1.Size = New System.Drawing.Size(305, 21)
      Me.KeepKeyCombo1.TabIndex = 52
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(521, 142)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtTemp, "")
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 20)
      Me.txtTemp.TabIndex = 5
      Me.txtTemp.Visible = False
      '
      'grbDocDate
      '
      Me.grbDocDate.Controls.Add(Me.chkExcludeNoGL)
      Me.grbDocDate.Controls.Add(Me.chkOnlyRemain)
      Me.grbDocDate.Controls.Add(Me.txtDueDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.txtDueDocDateStart)
      Me.grbDocDate.Controls.Add(Me.Label1)
      Me.grbDocDate.Controls.Add(Me.Label2)
      Me.grbDocDate.Controls.Add(Me.dtpDueDocDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpDueDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.btnSuppliEndFind)
      Me.grbDocDate.Controls.Add(Me.txtSuppliCodeEnd)
      Me.grbDocDate.Controls.Add(Me.lblSuppliEnd)
      Me.grbDocDate.Controls.Add(Me.btnSuppliStartFind)
      Me.grbDocDate.Controls.Add(Me.txtSuppliCodeStart)
      Me.grbDocDate.Controls.Add(Me.lblSuppliStart)
      Me.grbDocDate.Controls.Add(Me.chkIncludeChildren)
      Me.grbDocDate.Controls.Add(Me.btnCCCodeStart)
      Me.grbDocDate.Controls.Add(Me.txtCCCodeStart)
      Me.grbDocDate.Controls.Add(Me.lblCCStart)
      Me.grbDocDate.Controls.Add(Me.txtCostCenterName)
      Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDocDate.Location = New System.Drawing.Point(16, 16)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(497, 146)
      Me.grbDocDate.TabIndex = 1
      Me.grbDocDate.TabStop = False
      Me.grbDocDate.Text = "Date"
      '
      'chkOnlyRemain
      '
      Me.chkOnlyRemain.Checked = True
      Me.chkOnlyRemain.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkOnlyRemain.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkOnlyRemain.Location = New System.Drawing.Point(247, 111)
      Me.chkOnlyRemain.Name = "chkOnlyRemain"
      Me.chkOnlyRemain.Size = New System.Drawing.Size(119, 24)
      Me.chkOnlyRemain.TabIndex = 68
      Me.chkOnlyRemain.Text = "แสดงเฉพาะที่ค้าง"
      '
      'txtDueDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDueDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDueDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDueDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDueDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDueDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDueDocDateEnd.Location = New System.Drawing.Point(272, 41)
      Me.txtDueDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDueDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDueDocDateEnd, "")
      Me.txtDueDocDateEnd.Name = "txtDueDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDueDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDueDocDateEnd, False)
      Me.txtDueDocDateEnd.Size = New System.Drawing.Size(81, 20)
      Me.txtDueDocDateEnd.TabIndex = 66
      '
      'txtDueDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDueDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDueDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDueDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDueDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDueDocDateStart, System.Drawing.Color.Empty)
      Me.txtDueDocDateStart.Location = New System.Drawing.Point(123, 41)
      Me.txtDueDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDueDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDueDocDateStart, "")
      Me.txtDueDocDateStart.Name = "txtDueDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDueDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDueDocDateStart, False)
      Me.txtDueDocDateStart.Size = New System.Drawing.Size(80, 20)
      Me.txtDueDocDateStart.TabIndex = 63
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(6, 41)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(111, 18)
      Me.Label1.TabIndex = 62
      Me.Label1.Text = "วันที่เอกสารอ้างอิง"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(240, 41)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(24, 18)
      Me.Label2.TabIndex = 65
      Me.Label2.Text = "To"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'dtpDueDocDateStart
      '
      Me.dtpDueDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDocDateStart.Location = New System.Drawing.Point(123, 41)
      Me.dtpDueDocDateStart.Name = "dtpDueDocDateStart"
      Me.dtpDueDocDateStart.Size = New System.Drawing.Size(109, 20)
      Me.dtpDueDocDateStart.TabIndex = 64
      Me.dtpDueDocDateStart.TabStop = False
      '
      'dtpDueDocDateEnd
      '
      Me.dtpDueDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDueDocDateEnd.Location = New System.Drawing.Point(273, 41)
      Me.dtpDueDocDateEnd.Name = "dtpDueDocDateEnd"
      Me.dtpDueDocDateEnd.Size = New System.Drawing.Size(107, 20)
      Me.dtpDueDocDateEnd.TabIndex = 67
      Me.dtpDueDocDateEnd.TabStop = False
      '
      'btnSuppliEndFind
      '
      Me.btnSuppliEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliEndFind.Location = New System.Drawing.Point(354, 65)
      Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
      Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliEndFind.TabIndex = 61
      Me.btnSuppliEndFind.TabStop = False
      Me.btnSuppliEndFind.ThemedImage = CType(resources.GetObject("btnSuppliEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSuppliCodeEnd
      '
      Me.Validator.SetDataType(Me.txtSuppliCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
      Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(272, 65)
      Me.Validator.SetMaxValue(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
      Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
      Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(81, 21)
      Me.txtSuppliCodeEnd.TabIndex = 59
      '
      'lblSuppliEnd
      '
      Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliEnd.Location = New System.Drawing.Point(240, 65)
      Me.lblSuppliEnd.Name = "lblSuppliEnd"
      Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblSuppliEnd.TabIndex = 60
      Me.lblSuppliEnd.Text = "ถึง"
      Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSuppliStartFind
      '
      Me.btnSuppliStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSuppliStartFind.Location = New System.Drawing.Point(208, 65)
      Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
      Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnSuppliStartFind.TabIndex = 58
      Me.btnSuppliStartFind.TabStop = False
      Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtSuppliCodeStart
      '
      Me.Validator.SetDataType(Me.txtSuppliCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
      Me.txtSuppliCodeStart.Location = New System.Drawing.Point(123, 65)
      Me.Validator.SetMaxValue(Me.txtSuppliCodeStart, "")
      Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
      Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
      Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
      Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
      Me.txtSuppliCodeStart.Size = New System.Drawing.Size(85, 21)
      Me.txtSuppliCodeStart.TabIndex = 57
      '
      'lblSuppliStart
      '
      Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
      Me.lblSuppliStart.Location = New System.Drawing.Point(29, 65)
      Me.lblSuppliStart.Name = "lblSuppliStart"
      Me.lblSuppliStart.Size = New System.Drawing.Size(88, 18)
      Me.lblSuppliStart.TabIndex = 56
      Me.lblSuppliStart.Text = "Supplier:"
      Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(124, 110)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildren.TabIndex = 51
      Me.chkIncludeChildren.Text = "Include Sub CC:"
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Location = New System.Drawing.Point(208, 89)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 55
      Me.btnCCCodeStart.TabStop = False
      Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(123, 89)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(85, 21)
      Me.txtCCCodeStart.TabIndex = 54
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(45, 89)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(72, 18)
      Me.lblCCStart.TabIndex = 52
      Me.lblCCStart.Text = "Cost Center"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(232, 89)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(148, 21)
      Me.txtCostCenterName.TabIndex = 53
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(273, 18)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(80, 20)
      Me.txtDocDateEnd.TabIndex = 4
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(123, 18)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(80, 20)
      Me.txtDocDateStart.TabIndex = 1
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(29, 18)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "Start Date"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(240, 18)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "To"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(123, 18)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(109, 20)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(273, 18)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(107, 20)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(428, 168)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 3
      Me.btnSearch.Text = "Find"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(340, 168)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 2
      Me.btnReset.Text = "Reset"
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'chkExcludeNoGL
      '
      Me.chkExcludeNoGL.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkExcludeNoGL.Location = New System.Drawing.Point(372, 111)
      Me.chkExcludeNoGL.Name = "chkExcludeNoGL"
      Me.chkExcludeNoGL.Size = New System.Drawing.Size(119, 24)
      Me.chkExcludeNoGL.TabIndex = 68
      Me.chkExcludeNoGL.Text = "ไม่รวม NO-GL"
      '
      'RptVatNotDueFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "RptVatNotDueFilterSubPanel"
      Me.Size = New System.Drawing.Size(535, 208)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      Me.grbDocDate.ResumeLayout(False)
      Me.grbDocDate.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      ' Global text
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      ' Group box
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.grbDetail}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.grbDocDate}")
      'Checkbox
      Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.chkIncludeChildren}")
      Me.chkExcludeNoGL.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.chkExcludeNoGL}")
    End Sub
#End Region

#Region " Member "
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_DueDocDateStart As Date
    Private m_DueDocDateEnd As Date
    Private m_supplierstart As Supplier
    Private m_supplierend As Supplier
    Private m_cc As CostCenter
#End Region

#Region " Constructors "
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Initialize()

      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region " Properties "
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
    Public Property DueDocDateStart() As Date      Get        Return m_DueDocDateStart      End Get      Set(ByVal Value As Date)        m_DueDocDateStart = Value      End Set    End Property
    Public Property DueDocDateEnd() As Date      Get        Return m_DueDocDateEnd      End Get      Set(ByVal Value As Date)        m_DueDocDateEnd = Value      End Set    End Property
    Public Property SupplierStart() As Supplier
      Get
        Return m_supplierstart
      End Get
      Set(ByVal Value As Supplier)
        m_supplierstart = Value
      End Set
    End Property
    Public Property SupplierEnd() As Supplier
      Get
        Return m_supplierend
      End Get
      Set(ByVal Value As Supplier)
        m_supplierend = Value
      End Set
    End Property
    Public Property Costcenter() As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = Value
      End Set
    End Property
    'Public Property VatGroupStart() As VatGroup    '    Get    '        Return m_vatgstart    '    End Get    '    Set(ByVal Value As VatGroup)    '        m_vatgstart = Value    '    End Set    'End Property
    'Public Property VatGroupEnd() As VatGroup    '    Get    '        Return m_vatgend    '    End Get    '    Set(ByVal Value As VatGroup)    '        m_vatgend = Value    '    End Set    'End Property
#End Region

#Region " Methods "
    'Private Sub PopulateStatus()
    '    Dim baseDate As Date = AccountBaseDate.GetBaseDateFromDB() 'CDate(Configuration.GetConfig("BaseDate"))
    '    Dim years(9) As Date
    '    For i As Integer = 0 To 9
    '        years(i) = DateAdd(DateInterval.Year, i, baseDate)
    '    Next
    '    Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
    '    myDateTimeService.ListYearsInComboBox(Me.cmbYear, years)
    '    myDateTimeService.ListMonthsInComboBox(Me.cmbMonth, False, , False)
    'End Sub
    Private Sub Initialize()
      'PopulateStatus()
      ClearCriterias()
    End Sub
    Private Sub ClearCriterias()
      For Each grbCtrl As Control In grbDetail.Controls
        If TypeOf grbCtrl Is Pojjaman.Gui.Components.FixedGroupBox Then
          For Each Ctrl As Control In grbCtrl.Controls
            If TypeOf Ctrl Is TextBox Then
              Ctrl.Text = ""
            End If
          Next
        End If
      Next

      Me.chkExcludeNoGL.Checked = False
      Me.chkIncludeChildren.Checked = False

      Me.Costcenter = New CostCenter
      'Me.VatGroupStart = New VatGroup
      'Me.VatGroupEnd = New VatGroup
      Me.SupplierStart = New Supplier
      Me.SupplierEnd = New Supplier

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.txtDocDateStart.Text = MinDateToNull(dtStart, "")
      Me.dtpDocDateStart.Value = dtStart
      Me.DocDateStart = dtStart

      Me.txtDueDocDateStart.Text = MinDateToNull(dtStart, "")
      Me.dtpDueDocDateStart.Value = dtStart
      Me.DueDocDateStart = dtStart

      Me.txtDocDateEnd.Text = MinDateToNull(Date.Now, "")
      Me.dtpDocDateEnd.Value = Date.Now
      Me.DocDateEnd = Date.Now

      Me.txtDueDocDateEnd.Text = MinDateToNull(Date.Now, "")
      Me.dtpDueDocDateEnd.Value = Date.Now
      Me.DueDocDateEnd = Date.Now
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(10) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("SupplierCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("SupplierCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
      arr(4) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
      arr(5) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
      arr(6) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(7) = New Filter("DueDocDateStart", IIf(Me.DueDocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DueDocDateStart))
      arr(8) = New Filter("DueDocDateEnd", IIf(Me.DueDocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DueDocDateEnd))
      arr(9) = New Filter("OnlyRemain", Me.chkOnlyRemain.Checked)
      arr(10) = New Filter("ExcludeNoGL", Me.chkExcludeNoGL.Checked)

      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
#End Region

#Region " IReportFilterSubPanel "
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'Docdate Start
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateStart"
      dpi.Value = Me.txtDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate End
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = Me.txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckBox ChildInclude
      If Me.chkIncludeChildren.Checked Then
        dpi = New DocPrintingItem
        dpi.Mapping = "childincluded"
        dpi.Value = "(รวมในสังกัด)"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty Methods "
    Private Sub EventWiring()
      AddHandler dtpDocDateStart.ValueChanged, AddressOf ChangeProperty
      AddHandler txtDocDateStart.Validated, AddressOf ChangeProperty

      AddHandler dtpDueDocDateStart.ValueChanged, AddressOf ChangeProperty
      AddHandler txtDueDocDateStart.Validated, AddressOf ChangeProperty

      AddHandler dtpDocDateEnd.ValueChanged, AddressOf ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf ChangeProperty

      AddHandler dtpDueDocDateEnd.ValueChanged, AddressOf ChangeProperty
      AddHandler txtDueDocDateEnd.Validated, AddressOf ChangeProperty

      AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
      AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

    End Sub

    Private m_dateSetting As Boolean

    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower

        Case "txtcccodestart"
          Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case "dtpdocdatestart"
          If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateStart = dtpDocDateStart.Value
            End If
          End If
        Case "txtdocdatestart"
          m_dateSetting = True
          If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
            If Not Me.DocDateStart.Equals(theDate) Then
              dtpDocDateStart.Value = theDate
              Me.DocDateStart = dtpDocDateStart.Value
            End If
          Else
            Me.dtpDocDateStart.Value = Date.Now
            Me.DocDateStart = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtpdocdateend"
          If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          End If
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtpduedocdatestart"
          If Not Me.DueDocDateStart.Equals(dtpDueDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDueDocDateStart.Text = MinDateToNull(dtpDueDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DueDocDateStart = dtpDueDocDateStart.Value
            End If
          End If
        Case "txtduedocdatestart"
          m_dateSetting = True
          If Not Me.txtDueDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDueDocDateStart.Text)
            If Not Me.DueDocDateStart.Equals(theDate) Then
              dtpDueDocDateStart.Value = theDate
              Me.DueDocDateStart = dtpDueDocDateStart.Value
            End If
          Else
            Me.dtpDueDocDateStart.Value = Date.Now
            Me.DueDocDateStart = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtpduedocdateend"
          If Not Me.DueDocDateEnd.Equals(dtpDueDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDueDocDateEnd.Text = MinDateToNull(dtpDueDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DueDocDateEnd = dtpDueDocDateEnd.Value
            End If
          End If
        Case "txtduedocdateend"
          m_dateSetting = True
          If Not Me.txtDueDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDueDocDateEnd.Text)
            If Not Me.DueDocDateEnd.Equals(theDate) Then
              dtpDueDocDateEnd.Value = theDate
              Me.DueDocDateEnd = dtpDueDocDateEnd.Value
            End If
          Else
            Me.dtpDueDocDateEnd.Value = Date.Now
            Me.DueDocDateEnd = Date.MinValue
          End If
          m_dateSetting = False
        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        ' Costcenter
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcccodestart", "txtcccodeend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      ' Costcenter
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcostcentercodestart"
              Me.SetCCCodeStartDialog(entity)

            Case "txtcostcentercodeend"
              Me.SetCCCodeStartDialog(entity)

          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    ' Costcenter
    Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncccodestart"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
      End Select
    End Sub
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnsupplistartfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

        Case "btnsuppliendfind"
          myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

      End Select
    End Sub
    Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
      Me.txtSuppliCodeStart.Text = e.Code
      Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)
    End Sub
    Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
      Me.txtSuppliCodeEnd.Text = e.Code
      Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
#End Region

  End Class
End Namespace

