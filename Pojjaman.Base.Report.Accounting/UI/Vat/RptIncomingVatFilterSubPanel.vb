Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptIncomingVatFilterSubPanel
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
    Friend WithEvents grbFixValue As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents txtSubmitalDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtSubmitalDateStart As System.Windows.Forms.TextBox
    Friend WithEvents lblSubmitalDateStart As System.Windows.Forms.Label
    Friend WithEvents lblSubmitalDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpSubmitalDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpSubmitalDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtVatgCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblVatgEnd As System.Windows.Forms.Label
    Friend WithEvents txtVatgCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents btnVatgEnd As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnVatgStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblVatgStart As System.Windows.Forms.Label
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptIncomingVatFilterSubPanel))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtTemp = New System.Windows.Forms.TextBox
      Me.grbFixValue = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.cmbMonth = New System.Windows.Forms.ComboBox
      Me.lblMonth = New System.Windows.Forms.Label
      Me.cmbYear = New System.Windows.Forms.ComboBox
      Me.lblYear = New System.Windows.Forms.Label
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
      Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox
      Me.lblCCStart = New System.Windows.Forms.Label
      Me.txtCostCenterName = New System.Windows.Forms.TextBox
      Me.btnVatgEnd = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtVatgCodeEnd = New System.Windows.Forms.TextBox
      Me.lblVatgEnd = New System.Windows.Forms.Label
      Me.btnVatgStart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtVatgCodeStart = New System.Windows.Forms.TextBox
      Me.lblVatgStart = New System.Windows.Forms.Label
      Me.txtSubmitalDateEnd = New System.Windows.Forms.TextBox
      Me.txtSubmitalDateStart = New System.Windows.Forms.TextBox
      Me.lblSubmitalDateStart = New System.Windows.Forms.Label
      Me.lblSubmitalDateEnd = New System.Windows.Forms.Label
      Me.dtpSubmitalDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpSubmitalDateEnd = New System.Windows.Forms.DateTimePicker
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox
      Me.txtDocDateStart = New System.Windows.Forms.TextBox
      Me.lblDocDateStart = New System.Windows.Forms.Label
      Me.lblDocDateEnd = New System.Windows.Forms.Label
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
      Me.btnSearch = New System.Windows.Forms.Button
      Me.btnReset = New System.Windows.Forms.Button
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.grbDetail.SuspendLayout()
      Me.grbFixValue.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.txtTemp)
      Me.grbDetail.Controls.Add(Me.grbFixValue)
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(472, 240)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "Incoming Vat Report"
      '
      'txtTemp
      '
      Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTemp, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
      Me.txtTemp.Location = New System.Drawing.Point(488, 142)
      Me.txtTemp.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtTemp, "")
      Me.Validator.SetMinValue(Me.txtTemp, "")
      Me.txtTemp.Name = "txtTemp"
      Me.txtTemp.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTemp, "")
      Me.Validator.SetRequired(Me.txtTemp, False)
      Me.txtTemp.Size = New System.Drawing.Size(104, 20)
      Me.txtTemp.TabIndex = 5
      Me.txtTemp.Text = ""
      Me.txtTemp.Visible = False
      '
      'grbFixValue
      '
      Me.grbFixValue.Controls.Add(Me.cmbMonth)
      Me.grbFixValue.Controls.Add(Me.lblMonth)
      Me.grbFixValue.Controls.Add(Me.cmbYear)
      Me.grbFixValue.Controls.Add(Me.lblYear)
      Me.grbFixValue.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbFixValue.Location = New System.Drawing.Point(16, 16)
      Me.grbFixValue.Name = "grbFixValue"
      Me.grbFixValue.Size = New System.Drawing.Size(440, 48)
      Me.grbFixValue.TabIndex = 0
      Me.grbFixValue.TabStop = False
      Me.grbFixValue.Text = "Report Header"
      '
      'cmbMonth
      '
      Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMonth.Location = New System.Drawing.Point(296, 16)
      Me.cmbMonth.Name = "cmbMonth"
      Me.cmbMonth.Size = New System.Drawing.Size(120, 21)
      Me.cmbMonth.TabIndex = 3
      '
      'lblMonth
      '
      Me.lblMonth.BackColor = System.Drawing.Color.Transparent
      Me.lblMonth.Font = New System.Drawing.Font("Tahoma", 8.25!)
      Me.lblMonth.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMonth.Location = New System.Drawing.Point(232, 10)
      Me.lblMonth.Name = "lblMonth"
      Me.lblMonth.Size = New System.Drawing.Size(56, 32)
      Me.lblMonth.TabIndex = 2
      Me.lblMonth.Text = "Tax Month"
      Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbYear
      '
      Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbYear.Location = New System.Drawing.Point(112, 16)
      Me.cmbYear.Name = "cmbYear"
      Me.cmbYear.Size = New System.Drawing.Size(120, 21)
      Me.cmbYear.TabIndex = 1
      '
      'lblYear
      '
      Me.lblYear.BackColor = System.Drawing.Color.Transparent
      Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblYear.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblYear.Location = New System.Drawing.Point(32, 16)
      Me.lblYear.Name = "lblYear"
      Me.lblYear.Size = New System.Drawing.Size(72, 18)
      Me.lblYear.TabIndex = 0
      Me.lblYear.Text = "Year Tax:"
      Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDocDate
      '
      Me.grbDocDate.Controls.Add(Me.lblSubmitalDateStart)
      Me.grbDocDate.Controls.Add(Me.chkIncludeChildren)
      Me.grbDocDate.Controls.Add(Me.btnCCCodeStart)
      Me.grbDocDate.Controls.Add(Me.txtCCCodeStart)
      Me.grbDocDate.Controls.Add(Me.lblCCStart)
      Me.grbDocDate.Controls.Add(Me.txtCostCenterName)
      Me.grbDocDate.Controls.Add(Me.btnVatgEnd)
      Me.grbDocDate.Controls.Add(Me.txtVatgCodeEnd)
      Me.grbDocDate.Controls.Add(Me.lblVatgEnd)
      Me.grbDocDate.Controls.Add(Me.btnVatgStart)
      Me.grbDocDate.Controls.Add(Me.txtVatgCodeStart)
      Me.grbDocDate.Controls.Add(Me.lblVatgStart)
      Me.grbDocDate.Controls.Add(Me.txtSubmitalDateEnd)
      Me.grbDocDate.Controls.Add(Me.txtSubmitalDateStart)
      Me.grbDocDate.Controls.Add(Me.lblSubmitalDateEnd)
      Me.grbDocDate.Controls.Add(Me.dtpSubmitalDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpSubmitalDateEnd)
      Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDocDate.Location = New System.Drawing.Point(16, 64)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(440, 136)
      Me.grbDocDate.TabIndex = 1
      Me.grbDocDate.TabStop = False
      Me.grbDocDate.Text = "Date"
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(112, 109)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
      Me.chkIncludeChildren.TabIndex = 51
      Me.chkIncludeChildren.Text = "Include Sub CC:"
      '
      'btnCCCodeStart
      '
      Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
      Me.btnCCCodeStart.Location = New System.Drawing.Point(208, 85)
      Me.btnCCCodeStart.Name = "btnCCCodeStart"
      Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
      Me.btnCCCodeStart.TabIndex = 50
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
      Me.txtCCCodeStart.Location = New System.Drawing.Point(112, 85)
      Me.txtCCCodeStart.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 49
      Me.txtCCCodeStart.Text = ""
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(32, 85)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(72, 18)
      Me.lblCCStart.TabIndex = 47
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
      Me.txtCostCenterName.Location = New System.Drawing.Point(232, 85)
      Me.txtCostCenterName.MaxLength = 50
      Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(184, 21)
      Me.txtCostCenterName.TabIndex = 48
      Me.txtCostCenterName.Text = ""
      '
      'btnVatgEnd
      '
      Me.btnVatgEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnVatgEnd.ForeColor = System.Drawing.SystemColors.Control
      Me.btnVatgEnd.Image = CType(resources.GetObject("btnVatgEnd.Image"), System.Drawing.Image)
      Me.btnVatgEnd.Location = New System.Drawing.Point(392, 62)
      Me.btnVatgEnd.Name = "btnVatgEnd"
      Me.btnVatgEnd.Size = New System.Drawing.Size(24, 22)
      Me.btnVatgEnd.TabIndex = 46
      Me.btnVatgEnd.TabStop = False
      Me.btnVatgEnd.ThemedImage = CType(resources.GetObject("btnVatgEnd.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtVatgCodeEnd
      '
      Me.Validator.SetDataType(Me.txtVatgCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtVatgCodeEnd, "")
      Me.txtVatgCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtVatgCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtVatgCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtVatgCodeEnd, System.Drawing.Color.Empty)
      Me.txtVatgCodeEnd.Location = New System.Drawing.Point(296, 62)
      Me.Validator.SetMaxValue(Me.txtVatgCodeEnd, "")
      Me.Validator.SetMinValue(Me.txtVatgCodeEnd, "")
      Me.txtVatgCodeEnd.Name = "txtVatgCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtVatgCodeEnd, "")
      Me.Validator.SetRequired(Me.txtVatgCodeEnd, False)
      Me.txtVatgCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtVatgCodeEnd.TabIndex = 45
      Me.txtVatgCodeEnd.Text = ""
      '
      'lblVatgEnd
      '
      Me.lblVatgEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblVatgEnd.ForeColor = System.Drawing.Color.Black
      Me.lblVatgEnd.Location = New System.Drawing.Point(264, 62)
      Me.lblVatgEnd.Name = "lblVatgEnd"
      Me.lblVatgEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblVatgEnd.TabIndex = 44
      Me.lblVatgEnd.Text = "To"
      Me.lblVatgEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnVatgStart
      '
      Me.btnVatgStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnVatgStart.ForeColor = System.Drawing.SystemColors.Control
      Me.btnVatgStart.Image = CType(resources.GetObject("btnVatgStart.Image"), System.Drawing.Image)
      Me.btnVatgStart.Location = New System.Drawing.Point(208, 62)
      Me.btnVatgStart.Name = "btnVatgStart"
      Me.btnVatgStart.Size = New System.Drawing.Size(24, 22)
      Me.btnVatgStart.TabIndex = 43
      Me.btnVatgStart.TabStop = False
      Me.btnVatgStart.ThemedImage = CType(resources.GetObject("btnVatgStart.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtVatgCodeStart
      '
      Me.Validator.SetDataType(Me.txtVatgCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtVatgCodeStart, "")
      Me.txtVatgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtVatgCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtVatgCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtVatgCodeStart, System.Drawing.Color.Empty)
      Me.txtVatgCodeStart.Location = New System.Drawing.Point(112, 62)
      Me.Validator.SetMaxValue(Me.txtVatgCodeStart, "")
      Me.Validator.SetMinValue(Me.txtVatgCodeStart, "")
      Me.txtVatgCodeStart.Name = "txtVatgCodeStart"
      Me.Validator.SetRegularExpression(Me.txtVatgCodeStart, "")
      Me.Validator.SetRequired(Me.txtVatgCodeStart, False)
      Me.txtVatgCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtVatgCodeStart.TabIndex = 42
      Me.txtVatgCodeStart.Text = ""
      '
      'lblVatgStart
      '
      Me.lblVatgStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblVatgStart.ForeColor = System.Drawing.Color.Black
      Me.lblVatgStart.Location = New System.Drawing.Point(16, 64)
      Me.lblVatgStart.Name = "lblVatgStart"
      Me.lblVatgStart.Size = New System.Drawing.Size(88, 16)
      Me.lblVatgStart.TabIndex = 41
      Me.lblVatgStart.Text = "Start Vat Group"
      Me.lblVatgStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSubmitalDateEnd
      '
      Me.Validator.SetDataType(Me.txtSubmitalDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtSubmitalDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubmitalDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSubmitalDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSubmitalDateEnd, System.Drawing.Color.Empty)
      Me.txtSubmitalDateEnd.Location = New System.Drawing.Point(296, 40)
      Me.txtSubmitalDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtSubmitalDateEnd, "")
      Me.Validator.SetMinValue(Me.txtSubmitalDateEnd, "")
      Me.txtSubmitalDateEnd.Name = "txtSubmitalDateEnd"
      Me.Validator.SetRegularExpression(Me.txtSubmitalDateEnd, "")
      Me.Validator.SetRequired(Me.txtSubmitalDateEnd, False)
      Me.txtSubmitalDateEnd.Size = New System.Drawing.Size(99, 20)
      Me.txtSubmitalDateEnd.TabIndex = 10
      Me.txtSubmitalDateEnd.Text = ""
      '
      'txtSubmitalDateStart
      '
      Me.Validator.SetDataType(Me.txtSubmitalDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtSubmitalDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubmitalDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtSubmitalDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtSubmitalDateStart, System.Drawing.Color.Empty)
      Me.txtSubmitalDateStart.Location = New System.Drawing.Point(112, 40)
      Me.txtSubmitalDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtSubmitalDateStart, "")
      Me.Validator.SetMinValue(Me.txtSubmitalDateStart, "")
      Me.txtSubmitalDateStart.Name = "txtSubmitalDateStart"
      Me.Validator.SetRegularExpression(Me.txtSubmitalDateStart, "")
      Me.Validator.SetRequired(Me.txtSubmitalDateStart, False)
      Me.txtSubmitalDateStart.Size = New System.Drawing.Size(99, 20)
      Me.txtSubmitalDateStart.TabIndex = 7
      Me.txtSubmitalDateStart.Text = ""
      '
      'lblSubmitalDateStart
      '
      Me.lblSubmitalDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubmitalDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblSubmitalDateStart.Location = New System.Drawing.Point(8, 38)
      Me.lblSubmitalDateStart.Name = "lblSubmitalDateStart"
      Me.lblSubmitalDateStart.Size = New System.Drawing.Size(96, 24)
      Me.lblSubmitalDateStart.TabIndex = 6
      Me.lblSubmitalDateStart.Text = "Start Submital Date"
      Me.lblSubmitalDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSubmitalDateEnd
      '
      Me.lblSubmitalDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubmitalDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblSubmitalDateEnd.Location = New System.Drawing.Point(264, 40)
      Me.lblSubmitalDateEnd.Name = "lblSubmitalDateEnd"
      Me.lblSubmitalDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblSubmitalDateEnd.TabIndex = 9
      Me.lblSubmitalDateEnd.Text = "To"
      Me.lblSubmitalDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'dtpSubmitalDateStart
      '
      Me.dtpSubmitalDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpSubmitalDateStart.Location = New System.Drawing.Point(112, 40)
      Me.dtpSubmitalDateStart.Name = "dtpSubmitalDateStart"
      Me.dtpSubmitalDateStart.Size = New System.Drawing.Size(120, 20)
      Me.dtpSubmitalDateStart.TabIndex = 8
      Me.dtpSubmitalDateStart.TabStop = False
      '
      'dtpSubmitalDateEnd
      '
      Me.dtpSubmitalDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpSubmitalDateEnd.Location = New System.Drawing.Point(296, 40)
      Me.dtpSubmitalDateEnd.Name = "dtpSubmitalDateEnd"
      Me.dtpSubmitalDateEnd.Size = New System.Drawing.Size(120, 20)
      Me.dtpSubmitalDateEnd.TabIndex = 11
      Me.dtpSubmitalDateEnd.TabStop = False
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(296, 18)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 20)
      Me.txtDocDateEnd.TabIndex = 4
      Me.txtDocDateEnd.Text = ""
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(112, 18)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 20)
      Me.txtDocDateStart.TabIndex = 1
      Me.txtDocDateStart.Text = ""
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(16, 18)
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
      Me.lblDocDateEnd.Location = New System.Drawing.Point(264, 18)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 3
      Me.lblDocDateEnd.Text = "To"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 18)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 20)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(296, 18)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 20)
      Me.dtpDocDateEnd.TabIndex = 5
      Me.dtpDocDateEnd.TabStop = False
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(381, 208)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 3
      Me.btnSearch.Text = "Find"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(293, 208)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.TabIndex = 2
      Me.btnReset.Text = "Reset"
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'RptIncomingVatFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "RptIncomingVatFilterSubPanel"
      Me.Size = New System.Drawing.Size(488, 248)
      Me.grbDetail.ResumeLayout(False)
      Me.grbFixValue.ResumeLayout(False)
      Me.grbDocDate.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblSubmitalDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.lblSubmitalDateStart}")
      Me.Validator.SetDisplayName(txtSubmitalDateStart, lblSubmitalDateStart.Text)

      Me.lblYear.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.lblYear}")
      Me.lblMonth.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.lblMonth}")

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      Me.lblVatgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.lblVatgStart}")
      Me.Validator.SetDisplayName(txtVatgCodeStart, lblVatgStart.Text)

      ' Global text
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      Me.lblSubmitalDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtSubmitalDateEnd, lblSubmitalDateEnd.Text)

      Me.lblVatgEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtVatgCodeEnd, lblVatgEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      ' Group box
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.grbDetail}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.grbDocDate}")
      Me.grbFixValue.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.grbFixValue}")
      'Checkbox
      Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptIncomingVatFilterSubPanel.chkIncludeChildren}")
    End Sub
#End Region

#Region " Member "
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    Private m_SubmitalDateEnd As Date
    Private m_SubmitalDateStart As Date
    Private m_vatgstart As VatGroup
    Private m_vatgend As VatGroup
    Private m_cc As Costcenter
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
    Public Property SubmitalDateEnd() As Date      Get        Return m_SubmitalDateEnd      End Get      Set(ByVal Value As Date)        m_SubmitalDateEnd = Value      End Set    End Property    Public Property SubmitalDateStart() As Date      Get        Return m_SubmitalDateStart      End Get      Set(ByVal Value As Date)        m_SubmitalDateStart = Value      End Set    End Property
    Public Property Costcenter() As Costcenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As Costcenter)
        m_cc = Value
      End Set
    End Property
    Public Property VatGroupStart() As VatGroup      Get        Return m_vatgstart      End Get      Set(ByVal Value As VatGroup)        m_vatgstart = Value      End Set    End Property
    Public Property VatGroupEnd() As VatGroup      Get        Return m_vatgend      End Get      Set(ByVal Value As VatGroup)        m_vatgend = Value      End Set    End Property
#End Region

#Region " Methods "
    Private Sub PopulateStatus()
      Dim baseDate As Date = AccountBaseDate.GetBaseDateFromDB() 'CDate(Configuration.GetConfig("BaseDate"))
      Dim years(9) As Date
      For i As Integer = 0 To 9
        years(i) = DateAdd(DateInterval.Year, i, baseDate)
      Next
      Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
            DateTimeService.ListYearsInComboBox(Me.cmbYear, years)
            DateTimeService.ListMonthsInComboBox(Me.cmbMonth, False, , False)
    End Sub
    Private Sub Initialize()
      PopulateStatus()
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

      Me.chkIncludeChildren.Checked = False

      Me.Costcenter = New Costcenter
      Me.VatGroupStart = New VatGroup
      Me.VatGroupEnd = New VatGroup

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.txtDocDateStart.Text = MinDateToNull(dtStart, "")
      Me.dtpDocDateStart.Value = dtStart
      Me.DocDateStart = dtStart

      Me.txtDocDateEnd.Text = MinDateToNull(Date.Now, "")
      Me.dtpDocDateEnd.Value = Date.Now
      Me.DocDateEnd = Date.Now

      'Me.txtSubmitalDateStart.Text = MinDateToNull(dtStart, "")
      'Me.dtpSubmitalDateStart.Value = dtStart
      'Me.SubmitalDateStart = dtStart

      'Me.txtSubmitalDateEnd.Text = MinDateToNull(Date.Now, "")
      'Me.dtpSubmitalDateEnd.Value = Date.Now
      'Me.SubmitalDateEnd = Date.Now

      Me.cmbYear.SelectedIndex = (Date.Now.Year - AccountBaseDate.GetBaseDateFromDB().Year) ' CDate(Configuration.GetConfig("BaseDate")).Year)
      Me.cmbMonth.SelectedIndex = Date.Now.Month - 1
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(8) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
      arr(3) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
      arr(4) = New Filter("SubmitalDateStart", IIf(Me.SubmitalDateStart.Equals(Date.MinValue), DBNull.Value, Me.SubmitalDateStart))
      arr(5) = New Filter("SubmitalDateEnd", IIf(Me.SubmitalDateEnd.Equals(Date.MinValue), DBNull.Value, Me.SubmitalDateEnd))
      arr(6) = New Filter("VatgCodeStart", IIf(txtVatgCodeStart.TextLength > 0, txtVatgCodeStart.Text, DBNull.Value))
      arr(7) = New Filter("VatgCodeEnd", IIf(txtVatgCodeEnd.TextLength > 0, txtVatgCodeEnd.Text, DBNull.Value))
      arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
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

      'Month
      dpi = New DocPrintingItem
      dpi.Mapping = "Month"
      dpi.Value = Me.cmbMonth.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Year
      dpi = New DocPrintingItem
      dpi.Mapping = "Year"
      dpi.Value = Me.cmbYear.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

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

      'SubmitalDate Start
      dpi = New DocPrintingItem
      dpi.Mapping = "SubmitalDateStart"
      dpi.Value = Me.txtSubmitalDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SubmitalDate End
      dpi = New DocPrintingItem
      dpi.Mapping = "SubmitalDateEnd"
      dpi.Value = Me.txtSubmitalDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'VatGroupCode Start
      dpi = New DocPrintingItem
      dpi.Mapping = "VatGroupCodeStart"
      dpi.Value = Me.txtVatgCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'VatGroupCode End
      dpi = New DocPrintingItem
      dpi.Mapping = "VatGroupCodeEnd"
      dpi.Value = Me.txtVatgCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterStart"
      dpi.Value = Me.txtCostCenterName.Text
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

      AddHandler dtpDocDateEnd.ValueChanged, AddressOf ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf ChangeProperty

      AddHandler dtpSubmitalDateStart.ValueChanged, AddressOf ChangeProperty
      AddHandler txtSubmitalDateStart.Validated, AddressOf ChangeProperty

      AddHandler dtpSubmitalDateEnd.ValueChanged, AddressOf ChangeProperty
      AddHandler txtSubmitalDateEnd.Validated, AddressOf ChangeProperty

      AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnVatgStart.Click, AddressOf Me.btnVatgFind_Click
      AddHandler txtVatgCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler btnVatgEnd.Click, AddressOf Me.btnVatgFind_Click
      AddHandler txtVatgCodeEnd.Validated, AddressOf Me.ChangeProperty
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

        Case "dtpsubmitaldatestart"
          If Not Me.SubmitalDateStart.Equals(dtpSubmitalDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtSubmitalDateStart.Text = MinDateToNull(dtpSubmitalDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.SubmitalDateStart = dtpSubmitalDateStart.Value
            End If
          End If
        Case "txtsubmitaldatestart"
          m_dateSetting = True
          If Not Me.txtSubmitalDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtSubmitalDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtSubmitalDateStart.Text)
            If Not Me.SubmitalDateStart.Equals(theDate) Then
              dtpSubmitalDateStart.Value = theDate
              Me.SubmitalDateStart = dtpSubmitalDateStart.Value
            End If
          Else
            Me.dtpSubmitalDateStart.Value = Date.Now
            Me.SubmitalDateStart = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtpsubmitaldateend"
          If Not Me.SubmitalDateEnd.Equals(dtpSubmitalDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtSubmitalDateEnd.Text = MinDateToNull(dtpSubmitalDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.SubmitalDateEnd = dtpSubmitalDateEnd.Value
            End If
          End If
        Case "txtsubmitaldateend"
          m_dateSetting = True
          If Not Me.txtSubmitalDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtSubmitalDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtSubmitalDateEnd.Text)
            If Not Me.SubmitalDateEnd.Equals(theDate) Then
              dtpSubmitalDateEnd.Value = theDate
              Me.SubmitalDateEnd = dtpSubmitalDateEnd.Value
            End If
          Else
            Me.dtpSubmitalDateEnd.Value = Date.Now
            Me.SubmitalDateEnd = Date.MinValue
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
    Private Sub btnVatgFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnvatgstart"
          myEntityPanelService.OpenTreeDialog(New VatGroup, AddressOf SetVatgCodeStartDialog)
        Case "btnvatgend"
          myEntityPanelService.OpenTreeDialog(New VatGroup, AddressOf SetVatgCodeEndDialog)
      End Select
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtCCCodeStart.Text = e.Code
      Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub SetVatgCodeStartDialog(ByVal e As ISimpleEntity)
      Me.txtVatgCodeStart.Text = e.Code
      VatGroup.GetVatGroup(txtVatgCodeStart, txtTemp, m_vatgstart)
    End Sub
    Private Sub SetVatgCodeEndDialog(ByVal e As ISimpleEntity)
      Me.txtVatgCodeEnd.Text = e.Code
      VatGroup.GetVatGroup(txtVatgCodeEnd, txtTemp, m_vatgend)
    End Sub
#End Region

  End Class
End Namespace

